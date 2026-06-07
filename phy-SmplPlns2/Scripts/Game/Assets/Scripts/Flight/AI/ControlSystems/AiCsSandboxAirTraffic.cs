using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight.AI.ControlFunctions;
using Assets.Scripts.Flight.AI.Guidance;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Proximity;
using Assets.Scripts.Levels;
using UnityEngine;

namespace Assets.Scripts.Flight.AI.ControlSystems
{
	public class AiCsSandboxAirTraffic : AiCsFollowCourse
	{
		public enum AiMode
		{
			Default = 0,
			AerobaticPath = 1,
			Buzz = 2,
			FollowTheLeader = 3,
			GeneralPath = 4,
			Kamakaze = 5,
			Land = 6,
			Race = 7,
			RandomLocations = 8,
			TakeOff = 9
		}

		private static readonly AiMode[] _aiModeProbabilities = new AiMode[17]
		{
			AiMode.AerobaticPath,
			AiMode.AerobaticPath,
			AiMode.Buzz,
			AiMode.FollowTheLeader,
			AiMode.FollowTheLeader,
			AiMode.FollowTheLeader,
			AiMode.GeneralPath,
			AiMode.GeneralPath,
			AiMode.Land,
			AiMode.Land,
			AiMode.Land,
			AiMode.Race,
			AiMode.Race,
			AiMode.Race,
			AiMode.RandomLocations,
			AiMode.RandomLocations,
			AiMode.RandomLocations
		};

		private static readonly AiMode[] _aiModeProbabilitiesForPlayerOnRunway = new AiMode[6]
		{
			AiMode.AerobaticPath,
			AiMode.GeneralPath,
			AiMode.Land,
			AiMode.Land,
			AiMode.Race,
			AiMode.RandomLocations
		};

		private bool _allowAutoSwitch = true;

		private float? _brake;

		private AiMode? _currentAiMode;

		private int _framesAlive;

		private bool _inWater;

		private bool? _landingGearDown;

		private float? _pitchSensitivity = 1f;

		private int? _previousWaypointNumber;

		private float? _rollSensitivity = 1f;

		private float _startingTakeOffAltitudeAbsolute;

		private float? _throttle;

		public AiCsSandboxAirTraffic()
		{
			base.NewWaypointTargeted += OnNewWaypointTargeted;
		}

		public IEnumerator AiModeSwitcher()
		{
			while (true)
			{
				if (CanSwitchAiMode())
				{
					AutoSwitchAiMode();
				}
				yield return new WaitForSeconds(UnityEngine.Random.Range(20, 180));
			}
		}

		public void BecomeAggressive()
		{
			AiCsFlyToLocationAndEngage aiCsFlyToLocationAndEngage = new AiCsFlyToLocationAndEngage();
			base.AiControlledAircraft.SetAiControlSystem(aiCsFlyToLocationAndEngage);
			aiCsFlyToLocationAndEngage.DestroyAllEnemies();
		}

		public override float GetBrake()
		{
			if (_brake.HasValue)
			{
				return _brake.Value;
			}
			return base.GetBrake();
		}

		public override float GetPitch()
		{
			if (_pitchSensitivity.HasValue)
			{
				return _pitchSensitivity.Value * base.GetPitch();
			}
			return base.GetPitch();
		}

		public override float GetRoll()
		{
			if (_rollSensitivity.HasValue)
			{
				return _rollSensitivity.Value * base.GetRoll();
			}
			return base.GetRoll();
		}

		public override float GetThrottle()
		{
			if (_throttle.HasValue)
			{
				return _throttle.Value;
			}
			return base.GetThrottle();
		}

		public override void Initialize(AiControlledAircraftScript aiControlledAircraft)
		{
			base.Initialize(aiControlledAircraft);
			base.AiControlledAircraft.UseGroundAvoidance = true;
			base.AiControlledAircraft.UseWaterAvoidance = true;
		}

		public override bool LandingGearDown()
		{
			if (_landingGearDown.HasValue)
			{
				return _landingGearDown.Value;
			}
			return base.LandingGearDown();
		}

		public override void OnFirstFrameLateUpdate()
		{
			base.OnFirstFrameLateUpdate();
			base.AiControlledAircraft.StartCoroutine(AiModeSwitcher());
			base.AiControlledAircraft.AiAircraftScript.OnPartEnteredWater += OnPartEnteredWater;
			base.AiControlledAircraft.AiAircraftScript.OnPartExitedWater += OnPartExitedWater;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			CheckForBeingFiredUpon();
			if (_framesAlive > 60 && _currentAiMode == AiMode.Land && !base.AiControlledAircraft.PreparingForDespawn && base.AiControlledAircraft.AiAircraftScript.Controls.Throttle == 0f && base.AiControlledAircraft.AiAircraftScript.AirSpeed < 0.25f)
			{
				AiManagerScript.Instance.DespawnAircraft(base.AiControlledAircraft, 10f);
			}
			if (_currentAiMode == AiMode.TakeOff && base.AiControlledAircraft.AiAircraftScript.GlobalPosition.y - _startingTakeOffAltitudeAbsolute > 200f)
			{
				AutoSwitchAiMode();
			}
			_framesAlive++;
		}

		public bool SetAiMode(AiMode aiMode, bool allowAutoSwitch, Vector3 pathProximityPosition, AiPath forceAiPath)
		{
			AiCfFlyToLocation aiCfFlyToLocation = base.ControlFunction as AiCfFlyToLocation;
			_allowAutoSwitch = allowAutoSwitch;
			AircraftScript aiAircraftScript = base.AiControlledAircraft.AiAircraftScript;
			if (aiCfFlyToLocation != null)
			{
				aiCfFlyToLocation.SuggestedTargetLead = null;
				switch (aiMode)
				{
				case AiMode.AerobaticPath:
					if (SetAiPathMode(AiPath.PathType.Aerobatic, pathProximityPosition, forceAiPath))
					{
						return false;
					}
					break;
				case AiMode.Buzz:
					TodoException<AiCsSandboxAirTraffic>.LogOnce("Needs updated to properly handle a missing player and aircraft");
					base.AiControlledAircraft.SetTarget(FlightSceneScript.Instance.LocalPlayer.Aircraft, mainTarget: true);
					aiCfFlyToLocation.SuggestedTargetLead = 2.5f;
					base.AutoAdvanceWaypoint = false;
					break;
				case AiMode.FollowTheLeader:
					SetCourseLocations(GetNextFollowTheLeaderLocation);
					base.AutoAdvanceWaypoint = true;
					break;
				case AiMode.TakeOff:
					base.AiControlledAircraft.UseGroundAvoidance = false;
					base.AiControlledAircraft.UseWaterAvoidance = false;
					base.AiControlledAircraft.SetTarget(aiAircraftScript.Position + aiAircraftScript.OrientedCenterOfMassRigidBodies.forward * 4000f + aiAircraftScript.OrientedCenterOfMassRigidBodies.up * 500f, mainTarget: true);
					break;
				case AiMode.GeneralPath:
					if (!SetAiPathMode(AiPath.PathType.General, pathProximityPosition, forceAiPath))
					{
						return false;
					}
					break;
				case AiMode.Kamakaze:
					ClearCourseLocations();
					TodoException<AiCsSandboxAirTraffic>.LogOnce("Needs updated to properly handle a missing player and aircraft");
					base.AiControlledAircraft.SetTarget(FlightSceneScript.Instance.LocalPlayer.Aircraft, mainTarget: true);
					aiCfFlyToLocation.SuggestedTargetLead = 1f;
					base.AutoAdvanceWaypoint = false;
					break;
				case AiMode.Land:
					if (!SetAiPathMode(AiPath.PathType.Landing, pathProximityPosition, forceAiPath))
					{
						return false;
					}
					break;
				case AiMode.Race:
					if (!SetAiPathMode(AiPath.PathType.Race, pathProximityPosition, forceAiPath))
					{
						return false;
					}
					break;
				case AiMode.RandomLocations:
					SetCourseLocations(GetNextRandomLocationNearPlayer);
					base.AutoAdvanceWaypoint = true;
					break;
				}
				_currentAiMode = aiMode;
				return true;
			}
			if (base.ControlFunction != null)
			{
				Debug.LogErrorFormat("SandboxTraffic: Can't set ai traffic mode, not using FlyToLocation control function ({0})", base.ControlFunction.GetType());
			}
			else
			{
				Debug.LogError("SandboxTraffic: Can't set ai traffic mode, current control function is null.");
			}
			return false;
		}

		private void AutoSwitchAiMode()
		{
			bool flag = false;
			bool flag2 = true;
			int num = 0;
			Vector3 vector = FlightSceneScript.Instance.LocalPlayer?.FramePosition ?? Vector3.zero;
			GameObject proximityLoadedGameObject = ProximityLoader.Instance.GetProximityLoadedGameObject("CarCity");
			if (proximityLoadedGameObject != null && Vector3.Distance(vector, proximityLoadedGameObject.transform.position) < AiManagerScript.AiSettings.AircraftDespawnDistance)
			{
				SetAiMode(AiMode.RandomLocations, allowAutoSwitch: true, vector, null);
				return;
			}
			while (!flag && flag2)
			{
				AiMode aiMode;
				if (!IsAiOnGround() || base.ControlFunction.CarOptimized)
				{
					aiMode = ((!IsPlayerStoppedOnRunway()) ? _aiModeProbabilities[UnityEngine.Random.Range(0, _aiModeProbabilities.Length)] : _aiModeProbabilitiesForPlayerOnRunway[UnityEngine.Random.Range(0, _aiModeProbabilitiesForPlayerOnRunway.Length)]);
				}
				else
				{
					aiMode = AiMode.TakeOff;
					_startingTakeOffAltitudeAbsolute = base.AiControlledAircraft.AiAircraftScript.GlobalPosition.y;
				}
				flag = SetAiMode(aiMode, allowAutoSwitch: true, vector, null);
				if (!flag && num++ >= 50)
				{
					flag2 = false;
					Debug.LogErrorFormat("{0} - Could not auto-switch sandbox AI traffic mode after {1} attempts.", base.AiControlledAircraft.AiAircraftInfo.AircraftId, 50);
				}
			}
		}

		private bool CanSwitchAiMode()
		{
			if (_allowAutoSwitch)
			{
				if (_currentAiMode.HasValue)
				{
					if (_currentAiMode != AiMode.Land && _currentAiMode != AiMode.AerobaticPath)
					{
						return _currentAiMode != AiMode.GeneralPath;
					}
					return false;
				}
				return true;
			}
			return false;
		}

		private void CheckForBeingFiredUpon()
		{
			bool flag = false;
			if (base.AiControlledAircraft.AiAircraftScript.TargetingSystem.CurrentWarningState == TargetingSystem.WarningState.Locked)
			{
				if (UnityEngine.Random.Range(0, 2 * (int)(1f / Time.deltaTime)) == 0)
				{
					flag = true;
					FlightSceneScript.Instance.FlightUI.ShowMessage("Target aircraft has detected missile lock!");
				}
			}
			else if (base.AiControlledAircraft.AiAircraftScript.TargetingSystem.CurrentWarningState == TargetingSystem.WarningState.Acquiring && UnityEngine.Random.Range(0, 50 * (int)(1f / Time.deltaTime)) == 0)
			{
				flag = true;
				FlightSceneScript.Instance.FlightUI.ShowMessage("Target aircraft has detected missile lock acquisition.");
			}
			if (flag)
			{
				BecomeAggressive();
			}
		}

		private Vector3 GetNextFollowTheLeaderLocation()
		{
			return FlightSceneScript.Instance.LocalPlayer?.FramePosition ?? Vector3.zero;
		}

		private Vector3 GetNextRandomLocationNearPlayer()
		{
			float num = 1000f;
			float maxInclusive = Mathf.Max(AiManagerScript.AiSettings.AircraftDespawnDistance / UnityEngine.Random.Range(1f, 5f), num + 1f);
			Vector3 value = new Vector3(UnityEngine.Random.Range(num, maxInclusive) * (float)((UnityEngine.Random.value > 0.5f) ? 1 : (-1)), UnityEngine.Random.Range(-1000, 1000), UnityEngine.Random.Range(num, maxInclusive) * (float)((UnityEngine.Random.value > 0.5f) ? 1 : (-1)));
			Vector3? obj = FlightSceneScript.Instance.LocalPlayer?.FramePosition;
			Vector3 vector = (value + obj) ?? Vector3.zero;
			float elevationAboveGroundLevel = LevelBase.CurrentLevel.GetElevationAboveGroundLevel(vector);
			if (elevationAboveGroundLevel < 0f)
			{
				vector += new Vector3(0f, 0f - elevationAboveGroundLevel + 400f, 0f);
			}
			return vector;
		}

		private bool IsAiOnGround()
		{
			AircraftScript aiAircraftScript = base.AiControlledAircraft.AiAircraftScript;
			if (aiAircraftScript.AltitudeAgl < 20f)
			{
				return aiAircraftScript.AirSpeed < 10f;
			}
			return false;
		}

		private bool IsPlayerStoppedOnRunway()
		{
			AircraftScript aircraftScript = FlightSceneScript.Instance.LocalPlayer?.Aircraft;
			if (aircraftScript != null && aircraftScript.AirSpeed < 0.25f)
			{
				return aircraftScript.Controls.Throttle == 0f;
			}
			return false;
		}

		private void OnNewWaypointTargeted(object sender, NewWaypointTargetedEventArgs e)
		{
			if (_previousWaypointNumber.HasValue && e.WaypointNumber > 0)
			{
				_previousWaypointNumber = e.WaypointNumber - 1;
			}
			if (e.PathWaypoint != null && e.PathWaypoint.TryGetComponent<PathWaypointModifier>(out var component))
			{
				ProcessWaypointModifier(component);
			}
			if (e.PathManager != null && CanSwitchAiMode() && e.PathManager.TryGetComponent<AiPath>(out var _) && e.WaypointNumber == 0 && _previousWaypointNumber.HasValue)
			{
				AutoSwitchAiMode();
			}
			if ((_currentAiMode == AiMode.Land || _currentAiMode == AiMode.AerobaticPath || _currentAiMode == AiMode.GeneralPath || _currentAiMode == AiMode.Race) && e.WaypointNumber == 1)
			{
				base.AiControlledAircraft.UseGroundAvoidance = false;
			}
		}

		private void OnPartEnteredWater(PartScript part)
		{
			if (part == base.AiControlledAircraft.AiAircraftScript.MainCockpit)
			{
				_inWater = true;
				AiManagerScript.Instance.DespawnAircraft(base.AiControlledAircraft, 10f, () => _inWater);
			}
		}

		private void OnPartExitedWater(PartScript part)
		{
			_inWater = false;
		}

		private void ProcessWaypointModifier(PathWaypointModifier waypointModifier)
		{
			if (waypointModifier.ThrottleType == PathWaypointModifier.ModifierType.Override)
			{
				_throttle = waypointModifier.Throttle;
			}
			else if (waypointModifier.ThrottleType == PathWaypointModifier.ModifierType.NoModifier)
			{
				_throttle = null;
			}
			if (waypointModifier.BrakeType == PathWaypointModifier.ModifierType.Override)
			{
				_brake = waypointModifier.Brake;
			}
			else if (waypointModifier.BrakeType == PathWaypointModifier.ModifierType.NoModifier)
			{
				_brake = null;
			}
			if (waypointModifier.PitchSensitivityType == PathWaypointModifier.ModifierType.Override)
			{
				_pitchSensitivity = waypointModifier.PitchSensitivity;
			}
			else if (waypointModifier.PitchSensitivityType == PathWaypointModifier.ModifierType.NoModifier)
			{
				_landingGearDown = null;
			}
			if (waypointModifier.RollSensitivityType == PathWaypointModifier.ModifierType.Override)
			{
				_rollSensitivity = waypointModifier.RollSensitivity;
			}
			else if (waypointModifier.RollSensitivityType == PathWaypointModifier.ModifierType.NoModifier)
			{
				_rollSensitivity = null;
			}
			if (waypointModifier.LandingGearType == PathWaypointModifier.ModifierType.Override)
			{
				_landingGearDown = waypointModifier.LandingGearDown;
			}
			else if (waypointModifier.LandingGearType == PathWaypointModifier.ModifierType.NoModifier)
			{
				_landingGearDown = null;
			}
		}

		private bool SetAiPathMode(AiPath.PathType pathType, Vector3 proximityPosition, AiPath forceAiPath)
		{
			AiPath aiPath = ((!(forceAiPath != null)) ? AiManagerScript.Instance.GetAiFlightPath(proximityPosition, pathType, AiManagerScript.AiSettings.AircraftDespawnDistance, closest: false) : forceAiPath);
			_previousWaypointNumber = null;
			if (aiPath != null)
			{
				SetCourseLocations(aiPath.PathManager);
				base.AiControlledAircraft.UseGroundAvoidance = true;
				base.AiControlledAircraft.UseWaterAvoidance = false;
				base.AutoAdvanceWaypoint = true;
				return true;
			}
			return false;
		}

		private void UseRandomLocations()
		{
			List<Vector3> list = new List<Vector3>();
			float maxInclusive = AiManagerScript.AiSettings.AircraftDespawnDistance / (float)UnityEngine.Random.Range(1, 5);
			float minInclusive = 1000f;
			for (int i = 0; i < 20; i++)
			{
				Vector3 value = new Vector3(UnityEngine.Random.Range(minInclusive, maxInclusive) * (float)((UnityEngine.Random.value > 0.5f) ? 1 : (-1)), UnityEngine.Random.Range(-1000, 1000), UnityEngine.Random.Range(minInclusive, maxInclusive) * (float)((UnityEngine.Random.value > 0.5f) ? 1 : (-1)));
				Vector3? obj = FlightSceneScript.Instance.LocalPlayer?.FramePosition;
				Vector3 vector = (value + obj) ?? Vector3.zero;
				float elevationAboveGroundLevel = LevelBase.CurrentLevel.GetElevationAboveGroundLevel(vector);
				if (elevationAboveGroundLevel < 500f)
				{
					vector += new Vector3(0f, vector.y + elevationAboveGroundLevel + 500f, 0f);
				}
				list.Add(Utility.ConvertFloatingOriginToAbsolutePosition(vector));
			}
			SetCourseLocations(list);
		}
	}
}
