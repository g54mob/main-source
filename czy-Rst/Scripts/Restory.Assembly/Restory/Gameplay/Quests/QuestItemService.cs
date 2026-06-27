using System;
using System.Collections.Generic;
using Restory.Data.Elements;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.Workplace;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Quests
{
	public class QuestItemService : MonoBehaviour, IInitializable, IDisposable, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		private readonly Dictionary<QuestItem, DeviceContainer> nestedQuestItems = new Dictionary<QuestItem, DeviceContainer>();

		private DeviceRegistry deviceRegistry;

		private ElementService elementService;

		private WorkSurface workSurface;

		private QuestItem placedQuestItem;

		[Inject]
		private void Construct(DeviceRegistry deviceRegistry, ElementService elementService, WorkSurface workSurface)
		{
			this.deviceRegistry = deviceRegistry;
			this.elementService = elementService;
			this.workSurface = workSurface;
		}

		public void Initialize()
		{
			deviceRegistry.OnDeviceRegistered += ResolveDeviceRegistered;
			deviceRegistry.OnDeviceUnregistered += ResolveDeviceUnregistered;
		}

		public void Dispose()
		{
			deviceRegistry.OnDeviceRegistered -= ResolveDeviceRegistered;
			deviceRegistry.OnDeviceUnregistered -= ResolveDeviceUnregistered;
			foreach (QuestItem key in nestedQuestItems.Keys)
			{
				key.OnDiscovered -= ResolveQuestItemDiscovered;
			}
		}

		public void DestroyPlacedQuestItem(QuestItemInfo questItemInfo)
		{
			if (IsQuestItemPlaced(questItemInfo))
			{
				elementService.DestroyElement(placedQuestItem);
				placedQuestItem = null;
			}
		}

		public bool IsQuestItemPlaced(QuestItemInfo questItemInfo)
		{
			if ((bool)placedQuestItem && (bool)questItemInfo)
			{
				return placedQuestItem.Info.ID == questItemInfo.ID;
			}
			return false;
		}

		private void ResolveDeviceRegistered(DeviceContainer deviceContainer)
		{
			for (int i = deviceContainer.Device.ElementSockets.Count; i < deviceContainer.CachedInstalledElements.Length; i++)
			{
				if (deviceContainer.CachedInstalledElements[i] != null && deviceContainer.CachedInstalledElements[i].Info is QuestItemInfo questItemInfo)
				{
					CreateNestedQuestItem(questItemInfo, deviceContainer);
				}
			}
		}

		private void ResolveDeviceUnregistered(DeviceContainer deviceContainer)
		{
			if (!nestedQuestItems.ContainsValue(deviceContainer))
			{
				return;
			}
			List<QuestItem> list = new List<QuestItem>();
			foreach (KeyValuePair<QuestItem, DeviceContainer> nestedQuestItem in nestedQuestItems)
			{
				if (!(nestedQuestItem.Value != deviceContainer))
				{
					list.Add(nestedQuestItem.Key);
				}
			}
			foreach (QuestItem item in list)
			{
				item.OnDiscovered -= ResolveQuestItemDiscovered;
				nestedQuestItems.Remove(item);
			}
		}

		private void ResolveQuestItemDiscovered(QuestItem questItem)
		{
			RemoveNestedQuestItem(questItem);
			UpdatePlacedQuestItem(questItem);
		}

		private void CreateNestedQuestItem(QuestItemInfo questItemInfo, DeviceContainer deviceContainer)
		{
			QuestItem questItem = elementService.CreateQuestItem(questItemInfo, deviceContainer.Device.transform);
			questItem.transform.SetLocalPositionAndRotation(questItemInfo.LocalTransform.Position, questItemInfo.LocalTransform.Rotation);
			questItem.BehaviorSwitcher.SwitchToInstalledBehavior();
			nestedQuestItems.Add(questItem, deviceContainer);
			questItem.OnDiscovered += ResolveQuestItemDiscovered;
		}

		private void RemoveNestedQuestItem(QuestItem questItem)
		{
			questItem.OnDiscovered -= ResolveQuestItemDiscovered;
			if (!nestedQuestItems.TryGetValue(questItem, out var value))
			{
				Debug.LogError("Failed to find " + questItem.Info.ID + " entry in nestedQuestItems");
				return;
			}
			for (int i = value.Device.ElementSockets.Count; i < value.CachedInstalledElements.Length; i++)
			{
				if (value.CachedInstalledElements[i] != null && value.CachedInstalledElements[i].Info is QuestItemInfo questItemInfo && !(questItemInfo != questItem.Info))
				{
					value.CachedInstalledElements[i] = null;
					nestedQuestItems.Remove(questItem);
					return;
				}
			}
			Debug.LogError("Failed to find " + questItem.Info.ID + " item in deviceContainer");
		}

		private void UpdatePlacedQuestItem(QuestItem questItem)
		{
			if (placedQuestItem != null)
			{
				Debug.LogError(placedQuestItem.Info.ID + " item is placed already");
				elementService.DestroyElement(placedQuestItem);
			}
			placedQuestItem = questItem;
			questItem.transform.SetParent(workSurface.transform);
		}

		private void RestorePlacedQuestItem(PlacedQuestItemData placedQuestItemData)
		{
			QuestItem questItem = elementService.CreateQuestItem(placedQuestItemData.QuestItemInfo, workSurface.transform);
			questItem.transform.SetLocalPositionAndRotation(placedQuestItemData.QuestItemTransform.Position, placedQuestItemData.QuestItemTransform.Rotation);
			questItem.BehaviorSwitcher.SwitchToPlacedBehavior();
			placedQuestItem = questItem;
		}

		public void RestoreState(object state)
		{
			try
			{
				QuestItemServiceSaveData questItemServiceSaveData = DataMigrationWizard.Migrate<QuestItemServiceSaveData>(state, base.gameObject);
				if (questItemServiceSaveData.PlacedQuestItemData != null)
				{
					RestorePlacedQuestItem(questItemServiceSaveData.PlacedQuestItemData);
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public object CaptureState()
		{
			try
			{
				PlacedQuestItemData placedQuestItemData = null;
				if ((bool)placedQuestItem && placedQuestItem.Info is QuestItemInfo questItemInfo)
				{
					placedQuestItemData = new PlacedQuestItemData
					{
						QuestItemInfo = questItemInfo,
						QuestItemTransform = new SerializableTransform(placedQuestItem.transform)
					};
				}
				return new QuestItemServiceSaveData
				{
					PlacedQuestItemData = placedQuestItemData
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}
	}
}
