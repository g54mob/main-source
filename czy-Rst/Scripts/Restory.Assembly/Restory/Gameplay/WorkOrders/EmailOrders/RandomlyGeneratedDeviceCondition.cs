using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Devices;
using Restory.Data.Devices.Condition;
using Restory.Gameplay.Elements;
using Restory.Gameplay.InteractiveObjects;
using Restory.Gameplay.TextureMasks;
using UnityEngine;

namespace Restory.Gameplay.WorkOrders.EmailOrders
{
	[Serializable]
	public class RandomlyGeneratedDeviceCondition : IDeviceCondition, IInteractiveObjectInfo
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private DeviceInfo deviceInfo;

		[SerializeField]
		private MaskPresetInfoBase dirtMaskGenerationPreset;

		[SerializeField]
		private ElementData[] elementsConditionData;

		[SerializeField]
		private bool isPartOfCompetition;

		public string ID => id;

		public InteractiveObject Prefab => deviceInfo.Prefab;

		public DeviceInfo DeviceInfo => deviceInfo;

		public MaskPresetInfoBase DirtMaskGenerationPreset => dirtMaskGenerationPreset;

		public bool IsPartOfCompetition => isPartOfCompetition;

		public RandomlyGeneratedDeviceCondition(string id, DeviceInfo deviceInfo, MaskPresetInfoBase dirtMaskGenerationPreset, IEnumerable<ElementData> elements, bool isPartOfCompetition = false)
		{
			this.id = id;
			this.deviceInfo = deviceInfo;
			this.dirtMaskGenerationPreset = dirtMaskGenerationPreset;
			elementsConditionData = elements.ToArray();
			this.isPartOfCompetition = isPartOfCompetition;
		}

		public List<ElementData> GetElementsCondition()
		{
			return elementsConditionData.ToList();
		}

		public bool DoesDeviceContainQuestItem()
		{
			return false;
		}
	}
}
