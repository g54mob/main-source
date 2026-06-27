using System.Collections.Generic;
using Restory.Data.Devices.DeviceWorkTypes;
using Restory.Data.Elements.ElementTypes;
using Restory.Data.GameConfigs;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.WorkOrders.EmailOrders
{
	public class AvailableDevicesWorkTypesTrackingService : MonoBehaviour, IInitializable
	{
		[SerializeField]
		private AvailableDeviceWorkTypesList availableDeviceWorkTypesList;

		[SerializeField]
		private AvailableDeviceWorkTypesList availableDeviceWorkTypesForDemoList;

		private readonly List<DeviceWorkType> currentList = new List<DeviceWorkType>();

		private GameConfig gameConfig;

		public IReadOnlyList<DeviceWorkType> AllDeviceWorkTypes => currentList;

		[Inject]
		private void Construct(GameConfig gameConfig)
		{
			this.gameConfig = gameConfig;
		}

		public void Initialize()
		{
			if (gameConfig.VersionType == VersionType.Demo)
			{
				InitializeList(availableDeviceWorkTypesForDemoList);
			}
			else
			{
				InitializeList(availableDeviceWorkTypesList);
			}
		}

		private void InitializeList(AvailableDeviceWorkTypesList sourceList)
		{
			currentList.Clear();
			foreach (DeviceWorkType allDeviceWorkType in sourceList.AllDeviceWorkTypes)
			{
				if (allDeviceWorkType != null && (!(allDeviceWorkType is DeviceWorkTypeClean deviceWorkTypeClean) || (bool)deviceWorkTypeClean.DirtType))
				{
					currentList.Add((DeviceWorkType)allDeviceWorkType.Clone());
				}
			}
		}

		public IEnumerable<DeviceWorkType> GetAvailableWorkTypesList()
		{
			foreach (DeviceWorkType current in currentList)
			{
				if (current.IsAvailable)
				{
					yield return current;
				}
			}
		}

		public bool IsCleaningWorkTypeAvailable(DirtType dirtTypeToCheck)
		{
			if (!dirtTypeToCheck)
			{
				return false;
			}
			foreach (DeviceWorkType current in currentList)
			{
				if (current is DeviceWorkTypeClean deviceWorkTypeClean && deviceWorkTypeClean.DirtType == dirtTypeToCheck)
				{
					return current.IsAvailable;
				}
			}
			return false;
		}

		public void MakeCleaningWorkTypeAvailable(DirtType dirtTypeToEnable)
		{
			foreach (DeviceWorkType current in currentList)
			{
				if (current is DeviceWorkTypeClean deviceWorkTypeClean && deviceWorkTypeClean.DirtType == dirtTypeToEnable)
				{
					current.IsAvailable = true;
					break;
				}
			}
		}

		public void SetAllPaintingWorkTypeAvailable(bool isAvailable)
		{
			foreach (DeviceWorkType current in currentList)
			{
				if (current is DeviceWorkTypePaintBase deviceWorkTypePaintBase)
				{
					deviceWorkTypePaintBase.IsAvailable = isAvailable;
				}
			}
		}

		public void MakeWorkTypeAvailable(DeviceWorkType workType)
		{
			if (!(workType is DeviceWorkTypeClean deviceWorkTypeClean))
			{
				if (!(workType is DeviceWorkTypeRepair))
				{
					if (!(workType is DeviceWorkTypePaintBase))
					{
						if (!(workType is DeviceWorkTypeHacking))
						{
							return;
						}
						{
							foreach (DeviceWorkType current4 in currentList)
							{
								if (current4 is DeviceWorkTypeHacking)
								{
									current4.IsAvailable = true;
									break;
								}
							}
							return;
						}
					}
					{
						foreach (DeviceWorkType current5 in currentList)
						{
							if (current5 is DeviceWorkTypePaintBase)
							{
								current5.IsAvailable = true;
								break;
							}
						}
						return;
					}
				}
				{
					foreach (DeviceWorkType current6 in currentList)
					{
						if (current6 is DeviceWorkTypeRepair)
						{
							current6.IsAvailable = true;
							break;
						}
					}
					return;
				}
			}
			foreach (DeviceWorkType current7 in currentList)
			{
				if (current7 is DeviceWorkTypeClean deviceWorkTypeClean2 && deviceWorkTypeClean2.DirtType == deviceWorkTypeClean.DirtType)
				{
					deviceWorkTypeClean2.IsAvailable = true;
					break;
				}
			}
		}
	}
}
