using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int MaxHealth = 100;
    public int curHealth = 100;
    public float healthBarLenth;
	// Use this for initialization
	void Start () {
        healthBarLenth = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
	 
	}

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, healthBarLenth, 20), MaxHealth + "/" + curHealth);
    }

    public void AddjustCurrentHealth(int adj)
    {
        curHealth += adj;
        if (curHealth < 0)
        {
            curHealth = 0;
        }
        if (curHealth > MaxHealth)
        {
            curHealth = MaxHealth;
        }
        if (MaxHealth < 1)
         {
             MaxHealth = 1;
        }
        healthBarLenth = (Screen.width / 2) * (curHealth / (float)MaxHealth);
        
    }
}
