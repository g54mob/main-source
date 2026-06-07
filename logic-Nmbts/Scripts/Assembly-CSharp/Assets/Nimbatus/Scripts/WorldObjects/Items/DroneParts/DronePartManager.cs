using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts
{
	public class DronePartManager : MonoBehaviour
	{
		public NimbatusDrone ActiveDrone;

		[HideInInspector]
		public int ActiveNumberOfDroneParts;

		private Dictionary<EDronePartType, int> _numberOfDroneParts;

		public static string ReturnScene;

		public static DronePartManager Instance { get; private set; }

		public void Awake()
		{
			Instance = this;
		}

		public Vector3 CalculateCenterOfMass()
		{
			Vector3 centerOfMass = ActiveDrone.RootDronePart.GetCenterOfMass();
			float mass = ActiveDrone.RootDronePart.GetMass();
			return centerOfMass / mass;
		}

		public void Start()
		{
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				ReloadActiveDrone();
			}
			_numberOfDroneParts = new Dictionary<EDronePartType, int>();
			foreach (DronePart prefab in from d in SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<DronePart>()
				where d.IsStackable
				select d)
			{
				int numberOfDroneParts = ActiveDrone.RootDronePart.GetNumberOfDroneParts((DronePart dp) => dp.UniqueId == prefab.UniqueId);
				prefab.TemporaryUsageCount = numberOfDroneParts;
			}
			if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
			{
				StartCoroutine(UpdateDronePartCount());
				StartCoroutine(UpdateDronePartStackCount());
			}
		}

		public int GetDronePartCount(EDronePartType dronePartType)
		{
			if (_numberOfDroneParts.ContainsKey(dronePartType))
			{
				return _numberOfDroneParts[dronePartType];
			}
			int numberOfDroneParts = ActiveDrone.RootDronePart.GetNumberOfDroneParts((DronePart dp) => dp.DronePartType == dronePartType);
			_numberOfDroneParts.Add(dronePartType, numberOfDroneParts);
			return numberOfDroneParts;
		}

		private IEnumerator UpdateDronePartStackCount()
		{
			while (true)
			{
				foreach (DronePart prefab in from d in SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<DronePart>()
					where d.IsStackable
					select d)
				{
					int numberOfDroneParts = ActiveDrone.RootDronePart.GetNumberOfDroneParts((DronePart dp) => dp.UniqueId == prefab.UniqueId);
					prefab.TemporaryUsageCount = numberOfDroneParts;
					yield return true;
				}
				yield return true;
			}
		}

		private IEnumerator UpdateDronePartCount()
		{
			while (true)
			{
				ActiveNumberOfDroneParts = ActiveDrone.RootDronePart.GetNumberOfDroneParts<DronePart>();
				yield return true;
				foreach (EDronePartType value in EnumHelper.GetValues<EDronePartType>())
				{
					if (_numberOfDroneParts.ContainsKey(value))
					{
						EDronePartType droneType = value;
						_numberOfDroneParts[value] = ActiveDrone.RootDronePart.GetNumberOfDroneParts((DronePart dp) => dp.DronePartType == droneType);
					}
					else
					{
						EDronePartType droneType2 = value;
						_numberOfDroneParts.Add(droneType2, ActiveDrone.RootDronePart.GetNumberOfDroneParts((DronePart dp) => dp.DronePartType == droneType2));
					}
					yield return true;
				}
				yield return new WaitForSeconds(0.1f);
			}
		}

		public void ReloadActiveDrone()
		{
			KeyBinding.ResetUsedTags();
			ActiveDrone.Reset();
			ActiveDrone.InitDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone, true);
			if (BaseSingleton<UndoManager>.Instance != null)
			{
				BaseSingleton<UndoManager>.Instance.Store();
			}
		}

		public void SaveActiveDrone()
		{
			ActiveDrone.DroneData = SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone;
			string currentFilePath = GetCurrentFilePath(ActiveDrone.DroneData);
			NimbatusItemData rootDronePart = ActiveDrone.RootDronePart.GenerateData();
			ActiveDrone.DroneData.RootDronePart = rootDronePart;
			ActiveDrone.DroneData.Save(currentFilePath);
		}

		private string GetCurrentFilePath(DroneData data)
		{
			string uniqueId = data.UniqueId;
			return Path.Combine(SaveManager.GetActiveDroneFolderPath(), uniqueId + ".drn");
		}
	}
}
