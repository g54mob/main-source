using System;
using Assets.Nimbatus.Scripts.GalaxyMap.Boss;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.TravelEvents;
using Assets.Nimbatus.Scripts.Tutorial;

namespace Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings
{
	[Serializable]
	public struct NimbatusTerrainSetting
	{
		public bool IsInitialized;

		public int PlanetSize;

		public EAirResistance AirResistance;

		public EGravity Gravity;

		public EFoliageDensity FoliageDensity;

		public EAirResistance TestSimulationAirResistance;

		public float ResourceAmount;

		public ETerrainHardness TerrainStrength;

		public EGravity TestSimulationGravity;

		public float GetTerrainHardness()
		{
			switch (TerrainStrength)
			{
			case ETerrainHardness.None:
				return 0.01f;
			case ETerrainHardness.Weak:
				return 0.5f;
			case ETerrainHardness.Normal:
				return 1f;
			case ETerrainHardness.High:
				return 2f;
			case ETerrainHardness.Max:
				return 100f;
			default:
				return 1f;
			}
		}

		public float GetAirResistanceModifier()
		{
			EAirResistance eAirResistance = AirResistance;
			switch (RuntimeGlobals.RunningMode)
			{
			case ERunningMode.TestFlightPlanet:
				eAirResistance = TestSimulationAirResistance;
				break;
			case ERunningMode.TestFlight:
				eAirResistance = TestSimulationAirResistance;
				break;
			case ERunningMode.WeaponCustomization:
				eAirResistance = EAirResistance.Normal;
				break;
			case ERunningMode.Tutorial:
				eAirResistance = GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.AirResistance;
				break;
			case ERunningMode.BossFight:
				eAirResistance = BossfightManager.Instance.Settings.AirResistance;
				break;
			case ERunningMode.Space:
				if (SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent != null)
				{
					eAirResistance = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent.MissionSettings.AirResistance;
				}
				break;
			}
			switch (eAirResistance)
			{
			case EAirResistance.None:
				return 0f;
			case EAirResistance.Low:
				return 0.625f;
			case EAirResistance.Normal:
				return 1f;
			case EAirResistance.High:
				return 1.6f;
			default:
				return 1f;
			}
		}

		public float GetGravityModifier()
		{
			EGravity eGravity = Gravity;
			switch (RuntimeGlobals.RunningMode)
			{
			case ERunningMode.TestFlightPlanet:
				eGravity = TestSimulationGravity;
				break;
			case ERunningMode.TestFlight:
				eGravity = TestSimulationGravity;
				break;
			case ERunningMode.WeaponCustomization:
				eGravity = EGravity.Normal;
				break;
			case ERunningMode.Tutorial:
				eGravity = GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.Subtutorial.Gravity;
				break;
			case ERunningMode.BossFight:
				eGravity = BossfightManager.Instance.Settings.Gravity;
				break;
			case ERunningMode.Space:
				if (SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent != null)
				{
					eGravity = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent.MissionSettings.Gravity;
				}
				break;
			}
			switch (eGravity)
			{
			case EGravity.None:
				return 0f;
			case EGravity.Low:
				return 0.5f;
			case EGravity.Normal:
				return 1f;
			case EGravity.High:
				return 2f;
			default:
				return 1f;
			}
		}
	}
}
