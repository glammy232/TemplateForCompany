using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameData.Inventory
{
    public class Item : MonoBehaviour, IPointerDownHandler
    {
        public int ItemID;
        public int SlotID;

        public GameObject CurrentItem;

        public bool IsFilled;
        void Awake()
        {
            IsFilled = false;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            Inventory.Instance.EquipItem(SlotID);
        }
    }
}
