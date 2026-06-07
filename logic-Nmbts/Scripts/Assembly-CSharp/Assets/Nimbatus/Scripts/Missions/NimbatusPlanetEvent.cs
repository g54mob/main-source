using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Missions
{
	public class NimbatusPlanetEvent : SerializedScriptableObject
	{
		public EPlanetEventType EventType;

		public bool AllZones;

		[HideIf("AllZones", true)]
		public List<EClimateZoneType> Zones = new List<EClimateZoneType>();

		public int MinStartDelay;

		public int MaxStartDelay;

		public float Duration;

		public float SpawnInterval;

		[OdinSerialize]
		[ListDrawerSettings(ShowPaging = true, NumberOfItemsPerPage = 1)]
		protected internal List<PlanetSpawnSetting> SpawnSettings = new List<PlanetSpawnSetting>();

		public AnimationCurve Probability = new AnimationCurve(new Keyframe(1f, 1f), new Keyframe(5f, 1f));
	}
}
