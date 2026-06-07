using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using Steamworks;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class SaveDroneSettings : MonoBehaviour
	{
		public Camera DroneCam;

		public RenderTexture DroneTexture;

		public void OnClick()
		{
			if (DragAndDropHelper.DraggedItem != null)
			{
				return;
			}
			if (SteamManager.Initialized)
			{
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.UserId = SteamUser.GetSteamID().m_SteamID;
			}
			else
			{
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.UserId = 0uL;
			}
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.NumberOfParts = DronePartManager.Instance.ActiveNumberOfDroneParts;
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.NumberOfWeapons = DronePartManager.Instance.ActiveDrone.RootDronePart.GetNumberOfDroneParts((DronePart p) => p.DronePartType == EDronePartType.Weapon) + DronePartManager.Instance.ActiveDrone.RootDronePart.GetNumberOfDroneParts((DronePart p) => p.DronePartType == EDronePartType.DefensePart);
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.Diameter = DronePartManager.Instance.ActiveDrone.RootDronePart.GetDroneRadius(DronePartManager.Instance.ActiveDrone.RootDronePart) * 2f;
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.LastEditTime = DateTime.UtcNow;
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.LastUseTime = DateTime.UtcNow;
			if (DronePartManager.Instance.ActiveDrone.RootDronePart.GetNumberOfDroneParts((DronePart p) => p.DronePartType == EDronePartType.LogicPart) > 100)
			{
				BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.QuantumComputing);
			}
			if (SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.NumberOfParts > 100)
			{
				BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.BigBoy);
			}
			if (SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.NumberOfParts > 250)
			{
				BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.AbsoluteUnit);
			}
			if (SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.NumberOfParts > 500)
			{
				BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.LookAtTheSize);
			}
			ItemSelector.Reset();
			DronePartManager.Instance.ActiveDrone.RootDronePart.PrepareForImageRecursive();
			Bounds bounds = DronePartManager.Instance.ActiveDrone.RootDronePart.CalculateDroneBounds();
			DroneCam.targetTexture = DroneTexture;
			Vector3 position = DroneCam.transform.position;
			DroneCam.transform.position = new Vector3(bounds.center.x, bounds.center.y, position.z);
			DroneCam.orthographicSize = Math.Max(bounds.size.x / 2f, bounds.size.y / 2f);
			DroneCam.Render();
			Texture2D texture2D = new Texture2D(DroneTexture.width, DroneTexture.height, TextureFormat.ARGB32, false, true);
			RenderTexture.active = DroneTexture;
			texture2D.ReadPixels(new Rect(0f, 0f, DroneTexture.width, DroneTexture.height), 0, 0);
			texture2D.Apply(false);
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.Image = texture2D;
			List<WeaponPreset> list = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.WeaponPresets.Where((WeaponPreset ps) => ps.IsUsedInDrone(DronePartManager.Instance.ActiveDrone.RootDronePart)).ToList();
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.WeaponPresets = new List<WeaponPresetData>();
			foreach (WeaponPreset item in list)
			{
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone.WeaponPresets.Add(item.Save());
			}
			if (RuntimeGlobals.RunningMode != ERunningMode.Tutorial)
			{
				DronePartManager.Instance.SaveActiveDrone();
				SaveManager.StoreSaveGame(false, false);
			}
			BaseSingleton<AchievementManager>.Instance.UnlockAchievement(EAchievement.FirstDrone);
		}
	}
}
