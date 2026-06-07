using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Sectors
{
	[Serializable]
	public class SolarSystemSetting : SerializedScriptableObject
	{
		public bool OnlyWithPartUnlocking;

		public int InfluenceToUnlock;

		public bool CustomClimateZone;

		[ShowIf("CustomClimateZone", true)]
		public EClimateZoneType ClimateZone;

		public List<SolarSystemLocationSetting> Locations;

		public List<Color> SunColors = new List<Color>();

		public AnimationCurve ProbabilityByGalaxyComplexity = new AnimationCurve(new Keyframe(1f, 0.1f), new Keyframe(5f, 0.9f));

		public bool IsCompatibleWithGameMode()
		{
			if (OnlyWithPartUnlocking)
			{
				return RuntimeGlobals.GameModeSettings.HasPartUnlocking;
			}
			return true;
		}
	}
}
