using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunWheelRadialMenuHandler : MonoBehaviour
{
	[Serializable]
	public class WeaponBase
	{
		public string name;

		public string description;

		public string key;

		public int damage = 10;

		public int roundsPerMinute = 100;

		public Sprite weaponIcon;

		public UltimateRadialButtonInfo radialButtonInfo;
	}

	private enum CurrentMenu
	{
		LightWeapons = 0,
		HeavyWeapons = 1,
		UtilityWeapons = 2
	}

	public WeaponBase[] LightWeapons;

	public WeaponBase[] HeavyWeapons;

	public WeaponBase[] UtilityWeapons;

	private Dictionary<string, WeaponBase> WeaponDictionary = new Dictionary<string, WeaponBase>();

	public GameObject backgroundPanel;

	public UltimateRadialMenu weaponRadialMenu;

	public Text radialMenuTitleText;

	public Text nameText;

	public Text descriptionText;

	public Text damageText;

	public Text roundsPerMiinute;

	public Image gunIcon;

	private float horizontalInputMin;

	private float horizontalInputMax;

	private CurrentMenu currentMenu;

	private void Start()
	{
		weaponRadialMenu.RemoveAllRadialButtons();
		for (int i = 0; i < LightWeapons.Length; i++)
		{
			LightWeapons[i].radialButtonInfo.name = LightWeapons[i].name;
			LightWeapons[i].radialButtonInfo.key = LightWeapons[i].key;
			LightWeapons[i].radialButtonInfo.description = LightWeapons[i].description;
			LightWeapons[i].radialButtonInfo.icon = LightWeapons[i].weaponIcon;
			weaponRadialMenu.RegisterToRadialMenu(ShowCurrentWeaponInfo, LightWeapons[i].radialButtonInfo);
			WeaponDictionary.Add(LightWeapons[i].key, LightWeapons[i]);
		}
		for (int j = 0; j < UtilityWeapons.Length; j++)
		{
			UtilityWeapons[j].radialButtonInfo.name = UtilityWeapons[j].name;
			UtilityWeapons[j].radialButtonInfo.key = UtilityWeapons[j].key;
			UtilityWeapons[j].radialButtonInfo.description = UtilityWeapons[j].description;
			UtilityWeapons[j].radialButtonInfo.icon = UtilityWeapons[j].weaponIcon;
			WeaponDictionary.Add(UtilityWeapons[j].key, UtilityWeapons[j]);
		}
		for (int k = 0; k < HeavyWeapons.Length; k++)
		{
			HeavyWeapons[k].radialButtonInfo.name = HeavyWeapons[k].name;
			HeavyWeapons[k].radialButtonInfo.key = HeavyWeapons[k].key;
			HeavyWeapons[k].radialButtonInfo.description = HeavyWeapons[k].description;
			HeavyWeapons[k].radialButtonInfo.icon = HeavyWeapons[k].weaponIcon;
			WeaponDictionary.Add(HeavyWeapons[k].key, HeavyWeapons[k]);
		}
		weaponRadialMenu.OnRadialMenuEnabled += OnRadialMenuEnabled;
		weaponRadialMenu.OnRadialMenuDisabled += OnRadialMenuDisabled;
		backgroundPanel.SetActive(value: false);
		horizontalInputMin = weaponRadialMenu.BasePosition.x - weaponRadialMenu.GetComponent<RectTransform>().sizeDelta.x / 2f;
		horizontalInputMax = weaponRadialMenu.BasePosition.x + weaponRadialMenu.GetComponent<RectTransform>().sizeDelta.x / 2f;
	}

	private void Update()
	{
		if (!weaponRadialMenu.RadialMenuActive || weaponRadialMenu.InputInRange || !Input.GetMouseButtonDown(0))
		{
			return;
		}
		Vector2 vector = Input.mousePosition;
		if (vector.x < horizontalInputMin)
		{
			if (currentMenu == CurrentMenu.LightWeapons)
			{
				currentMenu = CurrentMenu.UtilityWeapons;
				PopulateRadialMenu(UtilityWeapons, "Utility Weapons");
			}
			else if (currentMenu == CurrentMenu.HeavyWeapons)
			{
				currentMenu = CurrentMenu.LightWeapons;
				PopulateRadialMenu(LightWeapons, "Light Weapons");
			}
		}
		else if (vector.x > horizontalInputMax)
		{
			if (currentMenu == CurrentMenu.LightWeapons)
			{
				currentMenu = CurrentMenu.HeavyWeapons;
				PopulateRadialMenu(HeavyWeapons, "Heavy Weapons");
			}
			else if (currentMenu == CurrentMenu.UtilityWeapons)
			{
				currentMenu = CurrentMenu.LightWeapons;
				PopulateRadialMenu(LightWeapons, "Light Weapons");
			}
		}
	}

	private void PopulateRadialMenu(WeaponBase[] weapons, string menuName)
	{
		weaponRadialMenu.RemoveAllRadialButtons();
		for (int i = 0; i < weapons.Length; i++)
		{
			weaponRadialMenu.RegisterToRadialMenu(ShowCurrentWeaponInfo, weapons[i].radialButtonInfo);
		}
		radialMenuTitleText.text = menuName;
	}

	private void OnRadialMenuEnabled()
	{
		backgroundPanel.SetActive(value: true);
	}

	private void OnRadialMenuDisabled()
	{
		backgroundPanel.SetActive(value: false);
		currentMenu = CurrentMenu.LightWeapons;
		PopulateRadialMenu(LightWeapons, "Light Weapons");
	}

	private void ShowCurrentWeaponInfo(string key)
	{
		if (WeaponDictionary.ContainsKey(key))
		{
			nameText.text = WeaponDictionary[key].name;
			descriptionText.text = "Description:\n" + WeaponDictionary[key].description;
			damageText.text = "Damage: " + WeaponDictionary[key].damage;
			roundsPerMiinute.text = "Rounds Per Minute: " + WeaponDictionary[key].roundsPerMinute;
			gunIcon.sprite = WeaponDictionary[key].weaponIcon;
		}
	}
}
