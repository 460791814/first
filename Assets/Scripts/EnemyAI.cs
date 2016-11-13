using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
  
   public  class EnemyAI: MonoBehaviour 
    {
       public Transform target;
       public int moveSpeed;
       public int rotationSpeed;
       public int MaxDistance;
       private Transform myTransform;
       void Awake() {
           myTransform = transform;
       }
       void Start() {
           GameObject go = GameObject.FindGameObjectWithTag("Player");
           target = go.transform;
           MaxDistance = 2;
       }

       void Update() {
           Debug.DrawLine(target.transform.position,myTransform.position,Color.red);
          myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
          if (Vector3.Distance(target.position, myTransform.position) > MaxDistance)
          {
              myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
          }
       }
    }
}
