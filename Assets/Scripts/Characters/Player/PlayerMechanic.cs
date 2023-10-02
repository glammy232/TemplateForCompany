using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters.Basic;

namespace Characters.Player
{
    public class PlayerMechanic : MonoBehaviour
    {
        public static PlayerMechanic PlayerMech; 
        public Transform ItemPoint;

        private void Start()
        {
            PlayerMech = this;
        }
    }
}