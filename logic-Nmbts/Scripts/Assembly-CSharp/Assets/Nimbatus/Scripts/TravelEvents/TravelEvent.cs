using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.TravelEvents
{
	public class TravelEvent : SerializedScriptableObject
	{
		public class IntroProbability
		{
			public List<TravelEventIntroduction> Sequence = new List<TravelEventIntroduction>();

			public float Probability = 1f;
		}

		public class TravelEventMissionSettings
		{
			public EMissionType Mission;

			public string SceneName;

			public string ActionTheme;

			public string AmbientTheme;

			public DroneSettingsObject DroneSettings;

			public EGravity Gravity;

			public EAirResistance AirResistance;

			public bool OverrideEndAnimationOnFailure;

			[ShowIf("OverrideEndAnimationOnFailure", true)]
			public string EndAnimation;
		}

		public ETravelEventType EventType;

		public bool IsLocationEvent;

		[HideIf("IsLocationEvent", true)]
		[HideIf("EventType", ETravelEventType.CorpDamage, true)]
		public bool OnlyWithPartUnlocking;

		[HideIf("IsLocationEvent", true)]
		[HideIf("EventType", ETravelEventType.CorpDamage, true)]
		public bool OnlyWithHealthThreat;

		public TranslationTerm Title;

		public List<IntroProbability> PossibleIntroSequences = new List<IntroProbability>();

		public bool HasMission;

		[ShowIf("HasMission", true)]
		public TravelEventMissionSettings MissionSettings = new TravelEventMissionSettings();

		public bool ResetRemainingThreatIncrease;

		public AnimationCurve ProbabilityByThreatLevel = new AnimationCurve(new Keyframe(0f, 0.1f), new Keyframe(100f, 0.9f));

		public bool IsAllowed()
		{
			if (EventType == ETravelEventType.CorpDamage || EventType == ETravelEventType.FinalPlanet || IsLocationEvent)
			{
				return false;
			}
			if (EventType == ETravelEventType.Shop && !RuntimeGlobals.GameModeSettings.HasShops)
			{
				return false;
			}
			if (EventType == ETravelEventType.Garage && !RuntimeGlobals.GameModeSettings.HasGarages)
			{
				return false;
			}
			if (OnlyWithPartUnlocking && !RuntimeGlobals.GameModeSettings.HasPartUnlocking)
			{
				return false;
			}
			if (OnlyWithHealthThreat && !RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat)
			{
				return false;
			}
			return true;
		}
	}
}
