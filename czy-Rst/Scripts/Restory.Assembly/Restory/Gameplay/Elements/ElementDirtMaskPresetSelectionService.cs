using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Devices.DeviceWorkTypes;
using Restory.Data.Elements.ElementTypes;
using Restory.Gameplay.TextureMasks;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;
using UnityEngine.Pool;

namespace Restory.Gameplay.Elements
{
	public class ElementDirtMaskPresetSelectionService
	{
		private readonly ElementMaterialTypesMalfunctionsTable elementMaterialTypesMalfunctionsTable;

		private readonly DirtTypesMaskPresetsTable dirtTypesMaskPresetsTable;

		private readonly AvailableDevicesWorkTypesTrackingService availableDevicesWorkTypesTracker;

		public ElementDirtMaskPresetSelectionService(ElementMaterialTypesMalfunctionsTable elementMaterialTypesMalfunctionsTable, DirtTypesMaskPresetsTable dirtTypesMaskPresetsTable, AvailableDevicesWorkTypesTrackingService availableDevicesWorkTypesTracker)
		{
			this.dirtTypesMaskPresetsTable = dirtTypesMaskPresetsTable;
			this.elementMaterialTypesMalfunctionsTable = elementMaterialTypesMalfunctionsTable;
			this.availableDevicesWorkTypesTracker = availableDevicesWorkTypesTracker;
		}

		public bool TryToGetDirtMaskCreationPreset(ElementMaterialType elementMaterialType, out MaskPresetInfoBase preset, bool restrictAllowedDirtTypes = true)
		{
			if (!elementMaterialTypesMalfunctionsTable.TryGetApplicableDirtTypesByElementType(elementMaterialType, out var dirtTypes))
			{
				preset = null;
				return false;
			}
			List<DirtType> list = CollectionPool<List<DirtType>, DirtType>.Get();
			List<DirtType> list2 = CollectionPool<List<DirtType>, DirtType>.Get();
			FillPossibleDirtTypesList(dirtTypes, list, restrictAllowedDirtTypes);
			FillSelectedDirtTypesList(GetMaxDirtTypesCount(), list, list2);
			bool result = dirtTypesMaskPresetsTable.TryGetMaskPresetByDirtTypes(list2, out preset);
			CollectionPool<List<DirtType>, DirtType>.Release(list);
			CollectionPool<List<DirtType>, DirtType>.Release(list2);
			return result;
		}

		public bool TryToGetDirtMaskCreationPreset(ElementMaterialType elementMaterialType, ICollection<DeviceWorkTypeClean> availableCleaningWorkTypes, out MaskPresetInfoBase preset, out List<DeviceWorkType> relevantWorkTypes)
		{
			relevantWorkTypes = new List<DeviceWorkType>();
			if (!elementMaterialTypesMalfunctionsTable.TryGetApplicableDirtTypesByElementType(elementMaterialType, out var dirtTypes))
			{
				preset = null;
				return false;
			}
			List<DeviceWorkTypeClean> value;
			using (CollectionPool<List<DeviceWorkTypeClean>, DeviceWorkTypeClean>.Get(out value))
			{
				HashSet<DirtType> value2;
				using (CollectionPool<HashSet<DirtType>, DirtType>.Get(out value2))
				{
					foreach (DeviceWorkTypeClean availableCleaningWorkType in availableCleaningWorkTypes)
					{
						if (dirtTypes.Contains(availableCleaningWorkType.DirtType))
						{
							value.Add(availableCleaningWorkType);
						}
					}
					for (int i = 0; i < value.Count; i++)
					{
						if (!RandomGeneratorFromWeights.TryToGetRandomObject(value, out var chosenObject))
						{
							preset = null;
							return false;
						}
						value2.Add(chosenObject.DirtType);
					}
					dirtTypesMaskPresetsTable.TryGetMaskPresetByDirtTypes(value2, out preset);
					foreach (DeviceWorkTypeClean availableCleaningWorkType2 in availableCleaningWorkTypes)
					{
						if (value2.Contains(availableCleaningWorkType2.DirtType))
						{
							relevantWorkTypes.Add(availableCleaningWorkType2);
						}
					}
				}
			}
			return true;
		}

		public IReadOnlyList<MaskPresetInfoBase> GetAllApplicableDirtMaskPresetsByElementType(ElementMaterialType elementMaterialType)
		{
			if (elementMaterialTypesMalfunctionsTable.TryGetApplicableDirtTypesByElementType(elementMaterialType, out var dirtTypes))
			{
				return dirtTypesMaskPresetsTable.GetPresetsWithAllowedDirtTypes(dirtTypes);
			}
			return Array.Empty<MaskPresetInfoBase>();
		}

		private int GetMaxDirtTypesCount()
		{
			int num = UnityEngine.Random.Range(0, 100);
			if (num >= elementMaterialTypesMalfunctionsTable.SingleDirtTypeChance)
			{
				if (num >= 100 - elementMaterialTypesMalfunctionsTable.DoubleDirtTypeChance)
				{
					return 3;
				}
				return 2;
			}
			return 1;
		}

		private void FillPossibleDirtTypesList(IReadOnlyList<DirtType> applicableDirtTypes, List<DirtType> possibleDirtTypes, bool restrictAllowedDirtTypes)
		{
			foreach (DirtType applicableDirtType in applicableDirtTypes)
			{
				if ((bool)applicableDirtType && (!restrictAllowedDirtTypes || availableDevicesWorkTypesTracker.IsCleaningWorkTypeAvailable(applicableDirtType)))
				{
					possibleDirtTypes.Add(applicableDirtType);
				}
			}
		}

		private static void FillSelectedDirtTypesList(int maxDirtTypes, List<DirtType> possibleDirtTypes, List<DirtType> selectedDirtTypes)
		{
			int num = maxDirtTypes - 1;
			while (num >= 0 && possibleDirtTypes.Count != 0)
			{
				int index = UnityEngine.Random.Range(0, possibleDirtTypes.Count);
				selectedDirtTypes.Add(possibleDirtTypes[index]);
				possibleDirtTypes.RemoveAt(index);
				num--;
			}
		}

		public IReadOnlyCollection<DirtType> GetDirtTypesInMaskPreset(MaskPresetInfoBase preset)
		{
			return dirtTypesMaskPresetsTable.GetDirtTypesInMaskPreset(preset);
		}
	}
}
