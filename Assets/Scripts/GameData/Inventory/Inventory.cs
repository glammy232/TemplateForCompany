using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Characters.Player;
using System;
using UnityEngine.EventSystems;
using UnityEditor.Graphs;
using TMPro;
using UnityEngine.UI;
using GameData.Basic;

namespace GameData.Inventory
{
    public class Inventory : MonoBehaviour, ISwithItem
    {
        public static Inventory Instance;

        public List<Item> Slots; //Ячейки рюкзака

        public int AmmoCount = 0; //Количество патронов в инвентаре

        private void Start()
        {
            Instance = this;
        }
        public void EquipItem(int SlotID)
        {
            if (Slots[SlotID].IsFilled == true)
            {
                SwitchItem(SlotID);
            }
            else
            {
                Debug.Log("None Item");
            }
        }

        public void SwitchItem(int SlotID)
        {
            Slots[SlotID].CurrentItem.transform.parent = PlayerMechanic.PlayerMech.ItemPoint;
            Slots[SlotID].CurrentItem.transform.position = PlayerMechanic.PlayerMech.ItemPoint.position;
            Slots[SlotID].CurrentItem.GetComponent<SpriteRenderer>().enabled = true;
            Slots[SlotID].CurrentItem.GetComponent<BoxCollider2D>().enabled = true;
        }

       /* [SerializeField]
        public Slider _healthSlider;

        HealthSlider HealthSlider = new HealthSlider();
       */
        [SerializeField]
        private List<TMP_Text> _ammoText;

        AmmoText AmmoText = new AmmoText();
        /*
        public void AddHealth()
        {
            HealthSlider.InitializeCurrentHealthToSliderValue(HealthSlider._currentHealth += 5, _healthSlider);
        }
        */
        public void AddAmmo()
        {
            for (int i = 0; i < Slots.Count; i++)
            {
                if (Slots[i].IsFilled == true)
                {
                    AmmoText.InitializeCurrentAmmoToText(0, AmmoCount, _ammoText[i]);
                }
                /*else
                {
                    AmmoText.InitializeCurrentAmmoToText(0, 0, Slots[i].GetComponentInChildren<TextMeshPro>());
                }*/
            }
        }
        public void Fire()
        {
            if (AmmoCount > 0)
            {
                AmmoCount--;
            }
            AddAmmo();
        }
    }
    class HealthSlider : IInitializeCurrentHealthHUD, IInitializeMaximumHealthHUD
    {
        public int _currentHealth { get; set; }
        public void InitializeCurrentHealthToSliderValue(int _currentHealth, Slider _healthSlider)
        {
            _healthSlider.value = _currentHealth;
        }
        //
        public int _maximumHealth { get; set; }
        public void InitializeMaximumHealthToSliderValue(int _maximumHealth, Slider _healthSlider)
        {
            _healthSlider.maxValue = _maximumHealth;
        }
    }
    //IPKarimov "Прописать отдельных класс текущих патронов"
    class AmmoText : IInitializeCurrentAmmoHUD
    {
        public void InitializeCurrentAmmoToText(int _currentAmmo, int _howManyAmmoForAdd, TMP_Text _currentAmmoTMP_Text)
        {
            _currentAmmo = Convert.ToInt32(_currentAmmoTMP_Text) - 1;

            string currentAmmo = Convert.ToString(_currentAmmo + _howManyAmmoForAdd);

            _currentAmmoTMP_Text.text = currentAmmo;

            if (Convert.ToInt32(currentAmmo) == 0)
            {
                _currentAmmoTMP_Text.text = "";
            }
        }
    }
}
