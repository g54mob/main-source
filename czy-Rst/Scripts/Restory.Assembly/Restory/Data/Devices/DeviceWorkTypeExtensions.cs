using System.Collections.Generic;
using System.Text;
using Restory.Data.Devices.DeviceWorkTypes;
using Restory.Data.Elements.Condition;
using Restory.Data.Localization;
using Restory.Gameplay.Devices;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using Restory.Gameplay.InteractiveObjects;
using UnityEngine.Pool;

namespace Restory.Data.Devices
{
	public static class DeviceWorkTypeExtensions
	{
		private static StringBuilder stringBuilder = new StringBuilder();

		public static string GetTranslationForWholeCollection(this IEnumerable<DeviceWorkType> workTypes, LocalizationSystem localizationSystem)
		{
			stringBuilder.Clear();
			HashSet<string> value;
			using (CollectionPool<HashSet<string>, string>.Get(out value))
			{
				foreach (DeviceWorkType workType in workTypes)
				{
					if (!value.Contains(workType.LocalizationKey))
					{
						string value2;
						if (workType is DeviceWorkTypePaintConcretePalette deviceWorkTypePaintConcretePalette)
						{
							string translation = localizationSystem.GetTranslation(workType.LocalizationKey);
							string translation2 = localizationSystem.GetTranslation(deviceWorkTypePaintConcretePalette.ConcretePalette.NameLocalizationKey);
							value2 = translation + " (" + translation2 + ")";
						}
						else
						{
							value2 = localizationSystem.GetTranslation(workType.LocalizationKey);
						}
						stringBuilder.Append(" • ");
						stringBuilder.AppendLine(value2);
						value.Add(workType.LocalizationKey);
					}
				}
			}
			return stringBuilder.ToString().TrimEnd();
		}

		public static bool IsAllWorkTypesCompleted(DeviceContainer deviceContainer, DeviceWorkType[] requiredWorkTypes)
		{
			if (!deviceContainer || !deviceContainer.Device)
			{
				return false;
			}
			if (deviceContainer.Device.CheckAssembleStatus() != Device.AssembleStatus.Assembled)
			{
				return false;
			}
			if (requiredWorkTypes == null || requiredWorkTypes.Length == 0)
			{
				return true;
			}
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			foreach (DeviceWorkType deviceWorkType in requiredWorkTypes)
			{
				if (!(deviceWorkType is DeviceWorkTypeHacking))
				{
					if (!(deviceWorkType is DeviceWorkTypeRepair))
					{
						if (!(deviceWorkType is DeviceWorkTypeClean))
						{
							if (deviceWorkType is DeviceWorkTypePaintBase)
							{
								flag4 = true;
							}
						}
						else
						{
							flag3 = true;
						}
					}
					else
					{
						flag2 = true;
					}
				}
				else
				{
					flag = true;
				}
			}
			if (flag && !deviceContainer.AdditionalProperties.ContainsProperty<HackedObjectProperty>())
			{
				return false;
			}
			if (!flag2 && !flag3 && !flag4)
			{
				return true;
			}
			int count = deviceContainer.Device.ElementSockets.Count;
			if (count == 0)
			{
				return false;
			}
			for (int j = 0; j < count; j++)
			{
				ElementData elementData = deviceContainer.CachedInstalledElements[j];
				if (elementData == null)
				{
					return false;
				}
				if (flag2 && elementData.Condition is DamagedElementCondition)
				{
					return false;
				}
				if (flag3 && elementData.Condition is DirtyElementCondition)
				{
					return false;
				}
			}
			if (flag4)
			{
				return PaintingWorkTypeIsDone(requiredWorkTypes, deviceContainer.Device);
			}
			return true;
		}

		private static bool PaintingWorkTypeIsDone(IEnumerable<DeviceWorkType> requiredWorkTypes, Device device)
		{
			if (!device.gameObject.TryGetComponent<PaintableDevice>(out var component) || !component.AnyPaintApplied || !component.CurrentPaintingProgress.IsFullyPainted())
			{
				return false;
			}
			foreach (DeviceWorkType requiredWorkType in requiredWorkTypes)
			{
				if (requiredWorkType is DeviceWorkTypePaintConcretePalette deviceWorkTypePaintConcretePalette && !component.ContainsPalette(deviceWorkTypePaintConcretePalette.ConcretePalette))
				{
					return false;
				}
			}
			return true;
		}
	}
}
