using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetting : MonoBehaviour {

  public   List<Transform> target;
  public  Transform selectedTarget;
  public Transform myTransform;
	// Use this for initialization
	void Start () {
        target = new List<Transform>();
        myTransform = transform;
        AddAllEnemies();
	}

    public void AddAllEnemies()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject item in go)
        {
            AddTarget(item.transform);
        }
    }

    private void AddTarget(Transform transform)
    {
        target.Add(transform);
    }

    private void TargetEnemy()
    {
        if (selectedTarget == null)
        {
            SortTargetsByDistance();
            selectedTarget = target[0];
        }
        else {

            int index = target.IndexOf(selectedTarget);
            if (index < target.Count - 1)
            {
                index++;
            }
            else {
                index = 0;
            }
            DeleteSelect();
            selectedTarget = target[index];
        }
        SelectTarget();
      
    }
    private void SelectTarget()
    {
        selectedTarget.renderer.material.color = Color.red;
        PlayerAttack play = (PlayerAttack)GetComponent<PlayerAttack>();
        play.target = selectedTarget.gameObject;
    } 
    private void DeleteSelect()
    {
        selectedTarget.renderer.material.color = Color.blue;
        selectedTarget = null;
    }
    private void SortTargetsByDistance()
    {
        target.Sort(delegate(Transform t1, Transform t2) { return (Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position))); });
    }
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TargetEnemy();
        }
	}
}
