using System.Collections.Generic;
using Assets.Nimbatus.Scripts.GalaxyMap.Race.Tracker;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.ResourceCollection;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.SensorParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts
{
	public class NimbatusDrone : SerializedMonoBehaviour
	{
		public LayerMask CollisionLayerMask;

		public LayerMask ShieldDetectionLayer;

		public Dictionary<ESensorDetectionType, LayerMask> SensorLayerMasks = new Dictionary<ESensorDetectionType, LayerMask>();

		public int ProjectileLayer;

		public Dictionary<EGrapplingHookTarget, LayerMask> GrapplingLayerMasks = new Dictionary<EGrapplingHookTarget, LayerMask>();

		[HideInInspector]
		internal RootDronePart RootDronePart;

		public TrackerManager TrackerManager;

		[HideInInspector]
		public List<ResourceHub> DecoupledHubs = new List<ResourceHub>();

		[HideInInspector]
		public bool ShowLockedSkins;

		[HideInInspector]
		public DroneData DroneData { get; set; }

		public float CalculateDiameter()
		{
			return RootDronePart.GetDroneRadius(RootDronePart) * 2f;
		}

		public void Reset()
		{
			if (!(RootDronePart != null))
			{
				return;
			}
			foreach (DronePart child in RootDronePart.Children)
			{
				Object.Destroy(child.gameObject);
			}
			RootDronePart.Children.Clear();
		}

		public void AddDecoupledHub(ResourceHub hub)
		{
			DecoupledHubs.Add(hub);
		}

		public void Update()
		{
			foreach (ResourceHub decoupledHub in DecoupledHubs)
			{
				decoupledHub.Update();
			}
		}

		public void InitDrone(DroneData data, bool unlockWeapons = false)
		{
			DroneData = data;
			ShowLockedSkins = data.IsOpponentDrone;
			if (data.RootDronePart != null)
			{
				InitRootDronePart(data.RootDronePart, unlockWeapons);
			}
		}

		public void InitRootDronePart(NimbatusItemData data, bool unlockWeapons = false)
		{
			DroneData.RootDronePart = data;
			if (RootDronePart != null)
			{
				Object.Destroy(RootDronePart.gameObject);
			}
			foreach (WeaponPresetData weaponPreset2 in DroneData.WeaponPresets)
			{
				WeaponPreset weaponPreset = new WeaponPreset();
				weaponPreset.Load(weaponPreset2);
				if (!SaveManager.LoadedSave.Settings.HasPartUnlocking)
				{
					SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GenerateAndAddWeapon(weaponPreset, SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.WeaponTemplate, unlockWeapons);
				}
			}
			RootDronePart = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.InstantiateItemFromData(data) as RootDronePart;
			if (RootDronePart != null)
			{
				RootDronePart.SetDrone(this);
				RootDronePart.transform.parent = base.transform;
				RootDronePart.transform.localPosition = Vector3.zero;
			}
		}

		public void ActivatePhysics()
		{
			if (RootDronePart != null)
			{
				RootDronePart.ActivatePhysics(base.gameObject.layer);
			}
		}

		public void LoadFromBytes(byte[] itemDroneData, bool withoutImages = false)
		{
			DroneData data = DroneData.LoadFromBytes(itemDroneData, withoutImages);
			InitDrone(data);
		}

		public byte[] SaveToBytes(bool withoutImages = false)
		{
			NimbatusItemData rootDronePart = RootDronePart.GenerateData();
			DroneData.RootDronePart = rootDronePart;
			return DroneData.SaveToBytes(withoutImages);
		}
	}
}
