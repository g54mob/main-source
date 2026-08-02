using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UltimateRadialMenuExample.CharacterInventory2D
{
	public class CharacterInventoryGameManager : MonoBehaviour
	{
		[Serializable]
		public class ItemInformation
		{
			public string name;

			public Sprite itemSprite;

			public int itemCount;

			public UltimateRadialButtonInfo buttonInfo;

			public void UseItem()
			{
				Debug.Log("Using: " + name);
			}
		}

		public Text tutorialText;

		private bool hasPickedUpItems;

		private bool hasInteractedWithButton;

		public UltimateRadialMenu radialMenu;

		public GameObject pauseScreen;

		public SpriteRenderer backgroundSprite;

		private float itemSpawningTimer;

		public float itemSpawningRate = 2.5f;

		private Vector2 spawnRangeMin;

		private Vector2 spawnRangeMax;

		public GameObject itemBasePrefab;

		public ItemInformation[] items;

		private Dictionary<string, ItemInformation> itemDictionary = new Dictionary<string, ItemInformation>();

		private void Start()
		{
			backgroundSprite.size = new Vector2(Camera.main.orthographicSize * (float)Screen.width / (float)Screen.height * 2f, Camera.main.orthographicSize * 2f);
			backgroundSprite.transform.position = Vector2.zero;
			spawnRangeMin = -backgroundSprite.size / 2f * 0.95f;
			spawnRangeMax = backgroundSprite.size / 2f * 0.95f;
			itemBasePrefab.SetActive(value: false);
			for (int i = 0; i < items.Length; i++)
			{
				items[i].buttonInfo.key = items[i].name;
				items[i].buttonInfo.name = items[i].name;
				items[i].buttonInfo.icon = items[i].itemSprite;
				itemDictionary.Add(items[i].name, items[i]);
			}
			radialMenu.RemoveAllRadialButtons();
			radialMenu.OnRadialMenuEnabled += PauseGame;
			radialMenu.OnRadialMenuDisabled += ResumeGame;
			pauseScreen.SetActive(value: false);
			radialMenu.OnRadialMenuButtonCountModified += OnRadialMenuButtonCountModified;
			radialMenu.OnRadialButtonInteract += OnRadialButtonInteract;
		}

		private void Update()
		{
			itemSpawningTimer += Time.deltaTime;
			if (itemSpawningTimer >= itemSpawningRate)
			{
				itemSpawningTimer -= itemSpawningRate;
				GameObject obj = UnityEngine.Object.Instantiate(itemBasePrefab, new Vector3(UnityEngine.Random.Range(spawnRangeMin.x, spawnRangeMax.x), UnityEngine.Random.Range(spawnRangeMin.y, spawnRangeMax.y)), Quaternion.identity);
				obj.SetActive(value: true);
				ItemInformation itemInformation = items[UnityEngine.Random.Range(0, items.Length)];
				obj.GetComponent<SpriteRenderer>().sprite = itemInformation.itemSprite;
				obj.GetComponent<WorldItem>().myManager = this;
				obj.GetComponent<WorldItem>().myInformation = itemInformation;
			}
		}

		public void PickupItem(ItemInformation itemInfo)
		{
			itemInfo.itemCount++;
			if (!itemInfo.buttonInfo.ExistsOnRadialMenu())
			{
				radialMenu.RegisterToRadialMenu(UseItem, itemInfo.buttonInfo);
			}
			itemInfo.buttonInfo.UpdateText(itemInfo.itemCount.ToString());
		}

		private void UseItem(string itemKey)
		{
			if (!itemDictionary.ContainsKey(itemKey))
			{
				Debug.LogWarning("Key does not exist in the dictionary.");
				return;
			}
			itemDictionary[itemKey].itemCount--;
			itemDictionary[itemKey].buttonInfo.UpdateText(itemDictionary[itemKey].itemCount.ToString());
			itemDictionary[itemKey].UseItem();
			if (itemDictionary[itemKey].itemCount <= 0)
			{
				itemDictionary[itemKey].buttonInfo.RemoveRadialButton();
			}
		}

		private void PauseGame()
		{
			pauseScreen.SetActive(value: true);
			Time.timeScale = 0f;
		}

		private void ResumeGame()
		{
			pauseScreen.SetActive(value: false);
			Time.timeScale = 1f;
		}

		private void OnRadialMenuButtonCountModified(int i)
		{
			if (!hasPickedUpItems)
			{
				tutorialText.text = "Great! Now press the SPACE BAR to open your radial menu. Then click on the item that you want to use.";
			}
			hasPickedUpItems = true;
		}

		private void OnRadialButtonInteract(int i)
		{
			if (!hasInteractedWithButton)
			{
				tutorialText.text = "Awesome! When you interact with a radial button, check out the Console to see that the radial button called the right item.";
			}
			hasInteractedWithButton = true;
		}
	}
}
