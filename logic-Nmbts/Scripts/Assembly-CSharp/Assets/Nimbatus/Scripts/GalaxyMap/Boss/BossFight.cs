using System;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Missions.Rewards;
using Assets.Nimbatus.Scripts.Persistence.Achievements;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Boss
{
	[Serializable]
	public class BossFight : SerializedScriptableObject
	{
		[ReadOnly]
		public string UniqueId;

		public TranslationTerm Name;

		public TranslationTerm MissionName;

		public TranslationTerm Description;

		public Texture2D PreviewImage;

		public EGravity Gravity;

		public EAirResistance AirResistance;

		public bool HasCustomGravity;

		[ShowIf("HasCustomGravity", true)]
		public Vector2 GravityCenter;

		public Gradient SkyGradient;

		public float SkyOffsetX;

		public float SkyOffsetY;

		public string BossfightScene = "BossFightScene";

		public List<RewardPool> PossiblePools;

		public EAchievement Achievement;

		[ContextMenu("Generate Unique ID")]
		public void GenerateNewUniqueId()
		{
			UniqueId = Guid.NewGuid().ToString();
		}
	}
}
