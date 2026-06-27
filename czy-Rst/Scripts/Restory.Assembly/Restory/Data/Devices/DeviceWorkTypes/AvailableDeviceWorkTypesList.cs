using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Restory.Data.Elements.ElementTypes;
using Restory.Data.Tables.Parameters;
using UnityEngine;

namespace Restory.Data.Devices.DeviceWorkTypes
{
	[CreateAssetMenu(menuName = "Restory/Devices/AvailableDeviceWorkTypesGlobalPool", fileName = "AvailableDeviceWorkTypesGlobalPool")]
	public class AvailableDeviceWorkTypesList : ScriptableObject, IGameParametersEntity
	{
		[SerializeReference]
		private List<DeviceWorkType> entries = new List<DeviceWorkType>();

		public IReadOnlyList<DeviceWorkType> AllDeviceWorkTypes => entries;

		[UsedImplicitly]
		private bool CheckEntries()
		{
			if (entries.Count((DeviceWorkType x) => x is DeviceWorkTypePaintAnyColors) > 1)
			{
				return false;
			}
			if (entries.Count((DeviceWorkType x) => x is DeviceWorkTypePaintConcretePalette) > 1)
			{
				return false;
			}
			List<DirtType> list = (from x in entries.OfType<DeviceWorkTypeClean>()
				where true
				select x.DirtType).ToList();
			return list.Count == list.Distinct().Count();
		}
	}
}
