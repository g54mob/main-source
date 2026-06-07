using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Spawning.PlanetSpawnSystem;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Missions
{
	public class NimbatusPlanetTheme : SerializedScriptableObject
	{
		public EThemeType ThemeType;

		public EClimateZoneType Zone;

		[ListDrawerSettings(ShowPaging = true, NumberOfItemsPerPage = 1)]
		[OdinSerialize]
		protected internal List<PlanetSpawnSetting> SpawnSettings = new List<PlanetSpawnSetting>();

		public AnimationCurve Probability = new AnimationCurve(new Keyframe(1f, 1f), new Keyframe(5f, 1f));
	}
}
