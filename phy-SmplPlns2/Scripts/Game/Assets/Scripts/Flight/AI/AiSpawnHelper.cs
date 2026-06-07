using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Flight.AI.ControlSystems;
using Assets.Scripts.Flight.StartLocations;
using UnityEngine;

namespace Assets.Scripts.Flight.AI
{
	public static class AiSpawnHelper
	{
		public static void SpawnPlaneBasic(string id, bool hostile, ushort teamId, AiCsSandboxAirTraffic.AiMode mode, int minSpawnAirspeed)
		{
			AircraftScript aircraftScript = FlightSceneScript.Instance.LocalPlayer?.Aircraft;
			if (aircraftScript == null)
			{
				Debug.Log("Unable to spawn an AI craft while the local player is not in an Aircraft.");
				return;
			}
			float num = Mathf.Clamp(aircraftScript.Altitude, 200f, 7500f);
			float altitudeAgl = aircraftScript.AltitudeAgl;
			if (altitudeAgl < 200f)
			{
				num = 200f - altitudeAgl + num;
			}
			Vector3 globalPosition = aircraftScript.GlobalPosition;
			float heading = aircraftScript.InstrumentData.Heading;
			Vector3 vector = new Vector3(Mathf.Sin(heading * (MathF.PI / 180f)), 0f, Mathf.Cos(heading * (MathF.PI / 180f)));
			globalPosition += vector * 1000f;
			globalPosition.y = num + GameWorld.Instance.SeaLevel.GetValueOrDefault();
			float airSpeed = aircraftScript.AirSpeed;
			if (aircraftScript.AtmosphereSample.AirDensityRatio > 0f)
			{
				airSpeed /= Mathf.Sqrt(aircraftScript.AtmosphereSample.AirDensityRatio);
			}
			StartLocation location = new StartLocation(globalPosition, Vector3.up * heading, Mathf.Max(aircraftScript.AirSpeed, minSpawnAirspeed), null);
			AiManagerScript.Instance.SpawnSandboxAi(id, autoDespawn: false, forceSpawnEvenIfUnflyable: true, location, mode, hostile, teamId, delegate(AiControlledAircraftScript ai)
			{
				ai.CurrentControlSystem.ControlFunction.RecheckLandingGearPosition();
			});
		}

		public static void SpawnRefuelingTankerAuto()
		{
			AircraftScript aircraft = FlightSceneScript.Instance.LocalPlayer?.Aircraft;
			if (aircraft == null)
			{
				Debug.Log("Unable to spawn an AI craft while the local player is not in an Aircraft.");
				return;
			}
			float num = Mathf.Clamp(aircraft.Altitude, 300f, 7500f);
			float altitudeAgl = aircraft.AltitudeAgl;
			if (altitudeAgl < 300f)
			{
				num = 300f - altitudeAgl + num;
			}
			Vector3 globalPosition = aircraft.GlobalPosition;
			float heading = aircraft.InstrumentData.Heading;
			Vector3 vector = new Vector3(Mathf.Sin(heading * (MathF.PI / 180f)), 0f, Mathf.Cos(heading * (MathF.PI / 180f)));
			globalPosition += vector * 1000f;
			globalPosition.y = num + GameWorld.Instance.SeaLevel.GetValueOrDefault();
			float num2 = aircraft.AirSpeed;
			if (aircraft.AtmosphereSample.AirDensityRatio > 0f)
			{
				num2 /= Mathf.Sqrt(aircraft.AtmosphereSample.AirDensityRatio);
			}
			_ = aircraft.WindVelocity + vector * num2;
			float speed = Mathf.Clamp(aircraft.AirSpeed, 55f, 125f);
			StartLocation location = new StartLocation(globalPosition, Vector3.up * heading, speed, false);
			ushort teamId = 3;
			AiManagerScript.Instance.SpawnSandboxAi("Required Craft\\__aiRefuelTanker__.xml", autoDespawn: false, forceSpawnEvenIfUnflyable: true, location, AiCsSandboxAirTraffic.AiMode.Default, aggressive: false, teamId, delegate(AiControlledAircraftScript ai)
			{
				AiCsFuelTanker aiCsFuelTanker = new AiCsFuelTanker();
				aiCsFuelTanker.Initialize(ai);
				aiCsFuelTanker.TargetRoll = 0f;
				aiCsFuelTanker.TargetSpeed = aircraft.AirSpeed;
				ai.SetAiControlSystem(aiCsFuelTanker);
				foreach (PartData part in ai.AiAircraftScript.Parts)
				{
					RefuelDrogueScript modifier = part.PartScript.GetModifier<RefuelDrogueScript>();
					if (modifier != null)
					{
						modifier.AssistStrength = 1f;
					}
				}
			});
		}
	}
}
