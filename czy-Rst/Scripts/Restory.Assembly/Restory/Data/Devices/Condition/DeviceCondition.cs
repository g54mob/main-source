using System.Collections.Generic;
using Restory.Data.Elements;
using Restory.Data.InteractiveObjects;
using Restory.Gameplay.Elements;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.TextureMasks;
using UnityEngine;

namespace Restory.Data.Devices.Condition
{
	[CreateAssetMenu(menuName = "Restory/Devices/Condition/DeviceCondition", fileName = "DeviceCondition")]
	public class DeviceCondition : InteractiveObjectInfo, IDeviceCondition, IInteractiveObjectInfo
	{
		[SerializeField]
		private DeviceInfo deviceInfo;

		[SerializeField]
		private Texture2D customDirtMaskTexture;

		[SerializeField]
		private MaskPresetInfoBase dirtMaskGenerationPreset;

		[SerializeField]
		[SortableElementDataList]
		private List<ElementData> elementsConditionData = new List<ElementData>();

		[SerializeField]
		private List<QuestItemInfo> questItemsInfo = new List<QuestItemInfo>();

		[SerializeField]
		private bool isPartOfCompetition;

		public override InteractiveObject Prefab => deviceInfo.Prefab;

		public DeviceInfo DeviceInfo => deviceInfo;

		public Texture2D CustomDirtMaskTexture => customDirtMaskTexture;

		public MaskPresetInfoBase DirtMaskGenerationPreset => dirtMaskGenerationPreset;

		public bool IsPartOfCompetition => isPartOfCompetition;

		public List<ElementData> GetElementsCondition()
		{
			List<ElementData> list = new List<ElementData>();
			list.AddRange(elementsConditionData);
			foreach (QuestItemInfo item2 in questItemsInfo)
			{
				ElementData item = new ElementData
				{
					Info = item2
				};
				list.Add(item);
			}
			return list;
		}

		public bool DoesDeviceContainQuestItem()
		{
			List<QuestItemInfo> list = questItemsInfo;
			if (list != null)
			{
				return list.Count > 0;
			}
			return false;
		}

		private void AutoSyncCollections()
		{
			SyncCollections();
		}

		private void SyncCollections()
		{
			if (deviceInfo == null)
			{
				elementsConditionData.Clear();
				return;
			}
			if (elementsConditionData.Count == 0 && deviceInfo.Elements.Count > 0)
			{
				foreach (IElementInfo element in deviceInfo.Elements)
				{
					elementsConditionData.Add(new ElementData
					{
						Info = (element as ElementInfo)
					});
				}
				return;
			}
			RefreshElementsConditionData();
		}

		private void RefreshElementsConditionData()
		{
			List<ElementData> list = new List<ElementData>();
			list.AddRange(elementsConditionData);
			elementsConditionData.Clear();
			foreach (IElementInfo element in deviceInfo.Elements)
			{
				if (element is ElementInfo elementInfo)
				{
					elementsConditionData.Add(TryToFindExistingUnassignedElementData(elementInfo, list, elementsConditionData, out var existingElementData) ? existingElementData : new ElementData
					{
						Info = elementInfo
					});
				}
			}
		}

		private bool TryToFindExistingUnassignedElementData(ElementInfo elementInfo, List<ElementData> oldElementsConditionData, List<ElementData> newElementsConditionData, out ElementData existingElementData)
		{
			foreach (ElementData oldElementsConditionDatum in oldElementsConditionData)
			{
				if (oldElementsConditionDatum.Info.ID == elementInfo.ID && !newElementsConditionData.Contains(oldElementsConditionDatum))
				{
					existingElementData = oldElementsConditionDatum;
					return true;
				}
			}
			existingElementData = null;
			return false;
		}
	}
}
