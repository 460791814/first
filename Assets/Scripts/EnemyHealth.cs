using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyHealth : MonoBehaviour
    {

        public int MaxHealth = 100;
        public int curHealth = 100;
        public float healthBarLenth;
        // Use this for initialization
        void Start()
        {
            healthBarLenth = Screen.width / 2;
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnGUI()
        {
            GUI.Box(new Rect(10, 40, healthBarLenth, 20), MaxHealth + "/" + curHealth);
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
}