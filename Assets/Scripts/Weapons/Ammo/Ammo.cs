using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameData.Inventory;

namespace Weapons.Ammunition
{
    public class Ammo : MonoBehaviour
    {
        public int AmmoCount;
        public void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.gameObject.tag == "Player")
            {
                Inventory.Instance.AmmoCount = Inventory.Instance.AmmoCount + AmmoCount;
                Inventory.Instance.AddAmmo();
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
