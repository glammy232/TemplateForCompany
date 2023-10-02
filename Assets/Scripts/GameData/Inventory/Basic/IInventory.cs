using TMPro;
using System;
using UnityEngine.UI;

namespace GameData.Basic
{
    public interface ISwithItem
    {
        public void SwitchItem(int SlotID);
    }

    //IPKarimov Показатели здоровья игрока в HUD 
    public interface IInitializeCurrentHealthHUD
    {
        public int _currentHealth { get; set; }
        public void InitializeCurrentHealthToSliderValue(int _currentHealth, Slider _healthSlider);
    }
    public interface IInitializeMaximumHealthHUD
    {
        public int _maximumHealth { get; set; }
        public void InitializeMaximumHealthToSliderValue(int _maximumHealth, Slider _healthSlider);
    }
    //IPKarimov Показатели аммуниции игрока в HUD 
    public interface IInitializeCurrentAmmoHUD
    {
        public void InitializeCurrentAmmoToText(int _currentAmmo, int _howManyAmmoToAdd, TMP_Text _AmmoTMP_Text);
    }
}