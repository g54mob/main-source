using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using Assets.Nimbatus.Scripts.Missions;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.LocationSettings
{
	public abstract class LocationSetting : SerializedScriptableObject
	{
		public string UniqueId;

		public string LocationSceneName;

		public NimbatusMission DefaultMission;

		public bool HasCustomScale;

		[ShowIf("HasCustomScale", true)]
		public float CustomScale = 1f;

		public TranslationTerm Name;

		public Sprite LocationImage;

		public Texture2D PreviewImage;

		public Color SpecialLocationColor;

		public bool IsShopLocation;

		public GameObject CustomMapGameObject;

		[ContextMenu("Generate Unique ID")]
		public void GenerateNewUniqueId()
		{
			UniqueId = Guid.NewGuid().ToString();
		}

		public abstract LocationData CreateLocation(System.Random randomGenerator, GalaxyMapSector sector, EMissionDifficulty difficulty, EMissionComplexity complexity);
	}
}
