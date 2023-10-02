using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameData.Inventory;

namespace Weapons
{
	public class Weapon : MonoBehaviour
	{
		private int AmmoAmmount;
		public bool IsEquipment = false;

		/// <summary>
		/// Оружие смотрит на мышку/врага
		/// 
		private Camera MainCamera;
		private Vector3 MousePos;
		/// </summary>

		/// <summary>
		/// Стрельба
		/// 
		public GameObject Bullet;
		public Transform BulletTransform;
		public bool CanFire;
		private float timer;
		public float TimeBetweenFiring;
		/// </summary>
		
		public void OnTriggerEnter2D(Collider2D collider2D)
		{
			if (collider2D.gameObject.tag == "Player")
			{
				for (int i = 0; i < Inventory.Instance.Slots.Count; i++)
				{
					if (Inventory.Instance.Slots[i].IsFilled == false)
					{
						Inventory.Instance.Slots[i].IsFilled = true;
						Inventory.Instance.Slots[i].GetComponent<Image>().sprite = this.GetComponent<SpriteRenderer>().sprite;
						Inventory.Instance.Slots[i].GetComponent<Image>().color = Color.white;
						Inventory.Instance.Slots[i].CurrentItem = this.gameObject;
						Inventory.Instance.AddAmmo();
						this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
						this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
						break;
					}
					else if(i == Inventory.Instance.Slots.Count)
					{
						break;
					}
				}
			}
		}
        private void Start()
        {
			MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }
        private void Update()
		{
			LookAtMouse();
		}
		void LookAtMouse()
		{
			if (!IsEquipment)
			{
				//MousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);

				MousePos = MainCamera.ViewportToScreenPoint(new Vector3(Input.mousePosition.x - 960, Input.mousePosition.y - 540, 0));

				Vector3 rotation = MousePos - transform.position;

				float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
				//float radic = Mathf.Tan(rotationZ);

				transform.rotation = Quaternion.Euler(0, 0, rotationZ);
            }
			else
			{
                //transform.rotation = Quaternion.Euler(0, 0, 0);
            }
		}
	}
}