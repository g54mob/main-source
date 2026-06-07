using System.Collections.Generic;
using Data;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using NewGameplayScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CreativeMode
{
	public class ItemCreatingSystem : MonoBehaviour
	{
		[SerializeField]
		private Transform itemsParent;

		[SerializeField]
		private Transform itemsParentSecondFloor;

		[SerializeField]
		private List<ItemsForCreativeModeSO> itemsLevel_0 = new List<ItemsForCreativeModeSO>();

		[SerializeField]
		private List<ItemsForCreativeModeSO> itemsLevel_1 = new List<ItemsForCreativeModeSO>();

		[SerializeField]
		private List<ItemsForCreativeModeSO> itemsLevel_2 = new List<ItemsForCreativeModeSO>();

		[SerializeField]
		private List<ItemsForCreativeModeSO> itemsLevel_3 = new List<ItemsForCreativeModeSO>();

		[SerializeField]
		private List<ItemsForCreativeModeSO> itemsLevel_4 = new List<ItemsForCreativeModeSO>();

		[SerializeField]
		private List<ItemsForCreativeModeSO> itemsLevel_5 = new List<ItemsForCreativeModeSO>();

		[SerializeField]
		private List<ItemsForCreativeModeSO> itemsLevel_6 = new List<ItemsForCreativeModeSO>();

		[SerializeField]
		private List<ItemsForCreativeModeSO> itemsLevel_7 = new List<ItemsForCreativeModeSO>();

		[SerializeField]
		private List<ItemsForCreativeModeSO> itemsLevel_8 = new List<ItemsForCreativeModeSO>();

		[SerializeField]
		private List<ItemsForCreativeModeSO> itemsLevel_9 = new List<ItemsForCreativeModeSO>();

		[SerializeField]
		private List<ItemsForCreativeModeSO> itemsLevel_10 = new List<ItemsForCreativeModeSO>();

		[SerializeField]
		private SwitchFloorButton switchFloorButton;

		private List<List<ItemsForCreativeModeSO>> levelItems = new List<List<ItemsForCreativeModeSO>>();

		private PlayerProgress progress;

		public static ItemCreatingSystem Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
			levelItems.Add(itemsLevel_0);
			levelItems.Add(itemsLevel_1);
			levelItems.Add(itemsLevel_2);
			levelItems.Add(itemsLevel_3);
			levelItems.Add(itemsLevel_4);
			levelItems.Add(itemsLevel_5);
			levelItems.Add(itemsLevel_6);
			levelItems.Add(itemsLevel_7);
			levelItems.Add(itemsLevel_8);
			levelItems.Add(itemsLevel_9);
			levelItems.Add(itemsLevel_10);
			progress = AllServices.Container.Single<IPersistentProgressService>().Progress;
		}

		public void CreateItem(int levelNumber, string itemGUID)
		{
			if (MovementSystem.Instance.IsMoving())
			{
				return;
			}
			ItemsForCreativeModeSO itemsForCreativeModeSO = null;
			foreach (ItemsForCreativeModeSO item in levelItems[levelNumber])
			{
				if (item.guid == itemGUID)
				{
					itemsForCreativeModeSO = item;
				}
			}
			if (!(itemsForCreativeModeSO == null))
			{
				GameObject gameObject = ((!(itemsParentSecondFloor != null) || !itemsParentSecondFloor.gameObject.activeInHierarchy) ? Object.Instantiate(itemsForCreativeModeSO.prefab, itemsParent) : Object.Instantiate(itemsForCreativeModeSO.prefab, itemsParentSecondFloor));
				Transform component = gameObject.GetComponent<Transform>();
				IMovable component2 = gameObject.GetComponent<IMovable>();
				component2.itemGUID = itemGUID;
				component2.itemLevelNumber = levelNumber;
				progress.ACH_ItemsCount++;
				if (progress.ACH_ItemsCount >= 1)
				{
					SteamIntegration.Instance.UnlockAchievement("ITEM1_12", 12);
				}
				if (progress.ACH_ItemsCount >= 50)
				{
					SteamIntegration.Instance.UnlockAchievement("ITEM50_13", 13);
				}
				MovementSystem.Instance.StartMovingTransform(component, isCreated: true, component2);
				component2.ToggleOutline(value: true);
			}
		}

		public IMovable LoadItem(int levelNumber, string itemGUID, float itemWorldPositionY)
		{
			ItemsForCreativeModeSO itemsForCreativeModeSO = null;
			foreach (ItemsForCreativeModeSO item in levelItems[levelNumber])
			{
				if (item.guid == itemGUID)
				{
					itemsForCreativeModeSO = item;
				}
			}
			if (itemsForCreativeModeSO == null)
			{
				return null;
			}
			GameObject gameObject = ((!(itemsParentSecondFloor != null) || !(itemWorldPositionY > 0f)) ? Object.Instantiate(itemsForCreativeModeSO.prefab, itemsParent) : Object.Instantiate(itemsForCreativeModeSO.prefab, itemsParentSecondFloor));
			IMovable component = gameObject.GetComponent<IMovable>();
			component.itemGUID = itemGUID;
			component.itemLevelNumber = levelNumber;
			return component;
		}

		public void ClearAllItems()
		{
			foreach (IMovable item in MovementSystem.Instance.GetAllItemsOnLevel())
			{
				item.transform.gameObject.SetActive(value: false);
				Object.Destroy(item.transform.gameObject);
			}
			foreach (Plant item2 in PlantsOnSceneCollection.Instance.collection)
			{
				item2.transform.gameObject.SetActive(value: false);
				Object.Destroy(item2.transform.gameObject);
			}
			PlantsOnSceneCollection.Instance.collection.Clear();
			AllServices.Container.Single<ISaveLoadService>().SaveProgress();
		}

		public void RestartItemsOnLevel()
		{
			ClearAllItems();
			progress.CreativeModeProgresses[SceneManager.GetActiveScene().name] = new CreativeModeProgress(AllServices.Container.Single<Loader>().currentCreativeModeSceneNumber);
			MovementSystem.Instance.LoadProgress(progress);
			if (switchFloorButton != null)
			{
				switchFloorButton.SwitchFloor();
				switchFloorButton.SwitchFloor();
			}
			AllServices.Container.Single<ISaveLoadService>().SaveProgress();
		}
	}
}
