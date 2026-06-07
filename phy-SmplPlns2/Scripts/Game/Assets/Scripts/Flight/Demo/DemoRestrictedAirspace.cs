using System;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Flight.Explosions;
using Assets.Scripts.Multiplayer;
using Assets.Scripts.Multiplayer.FlightObjects;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Flight.Demo
{
	[Serializable]
	public class DemoRestrictedAirspace
	{
		private enum AirspaceType
		{
			Default = 0,
			Warning = 1,
			Restricted = 2,
			InvisibleWall = 3
		}

		public class SamMissile
		{
			public GameObject GameObject { get; }

			public bool IsDestroyed { get; private set; }

			public Rigidbody RigidBody { get; }

			public float Speed { get; set; }

			public AircraftScript Target { get; }

			public float TotalFlightTime { get; private set; }

			public Transform Transform { get; }

			public SamMissile(GameObject obj, AircraftScript target)
			{
				GameObject = obj;
				Transform = obj.transform;
				RigidBody = obj.GetComponent<Rigidbody>();
				Target = target;
				float num = Vector3.Distance(Transform.position, target.Position);
				Speed = num / 5f;
				RigidBody.useGravity = false;
			}

			public void FixedUpdate(float deltaTime)
			{
				if (Target == null || Target.CriticallyDamaged)
				{
					IsDestroyed = true;
					return;
				}
				Vector3 position = Target.Position;
				Vector3 normalized = (position - Transform.position).normalized;
				float num = Vector3.Distance(Transform.position, position);
				float num2 = num / (5f - TotalFlightTime);
				if (Speed < num2)
				{
					Speed = num2;
				}
				float num3 = Speed * deltaTime;
				float num4 = ((num < num3) ? num : num3);
				Vector3 vector = normalized * num4;
				RigidBody.MovePosition(Transform.position + vector);
				RigidBody.MoveRotation(Quaternion.LookRotation(normalized, Vector3.up));
				TotalFlightTime += deltaTime;
				if (num < 1f)
				{
					IsDestroyed = true;
				}
			}
		}

		private const float MissileMaxFlightTime = 5f;

		private const float WarningAirspaceMaxTime = float.MaxValue;

		private static int _carrierId = StringUtility.GetStableHashCode("TestCarrier1");

		private List<SamMissile> _activeMissiles = new List<SamMissile>();

		private AirspaceType _currentAirspaceType;

		[SerializeField]
		private DemoData[] _demoData;

		private bool _missilesFired;

		private float _restrictedAirspaceTimer;

		public DemoRestrictedAirspace()
		{
			_demoData = Game.Instance.DemoData;
		}

		public void OnDrawGizmosSelected()
		{
			Vector3 b = new Vector3(1f, 1f, 1f);
			DemoData[] demoData = _demoData;
			foreach (DemoData demoData2 in demoData)
			{
				Gizmos.matrix = Matrix4x4.Translate(demoData2.BoundsCenter - GameWorld.Instance.FloatingOriginOffset) * Matrix4x4.Rotate(Quaternion.Euler(0f, demoData2.BoundsRotation, 0f));
				Gizmos.color = Color.green;
				Gizmos.DrawWireCube(Vector3.zero, Vector3.Scale(demoData2.BoundsWarning.Bounds.size, b));
				Gizmos.color = Color.yellow;
				Gizmos.DrawWireCube(Vector3.zero, Vector3.Scale(demoData2.BoundsRestricted.Bounds.size, b));
				Gizmos.color = Color.red;
				Gizmos.DrawWireCube(Vector3.zero, Vector3.Scale(demoData2.BoundsInvisibleWall.Bounds.size, b));
			}
		}

		public void OnFixedUpdate()
		{
			if (_activeMissiles.Count == 0)
			{
				return;
			}
			FlightScenePlayer flightScenePlayer = FlightSceneScript.Instance?.LocalPlayer;
			if (flightScenePlayer == null || !flightScenePlayer.InitialCraftLoadCompleted)
			{
				return;
			}
			_ = flightScenePlayer.FramePosition;
			for (int num = _activeMissiles.Count - 1; num >= 0; num--)
			{
				SamMissile samMissile = _activeMissiles[num];
				samMissile.FixedUpdate(Time.deltaTime);
				if (samMissile.IsDestroyed)
				{
					Vector3 position = samMissile.Transform.position;
					_activeMissiles.RemoveAt(num);
					UnityEngine.Object.Destroy(samMissile.GameObject);
					FlightSceneScript.Instance.CreateExplosion("MissileExplosion", position, 4f, Vector3.up, null, null, ExplosiveWeaponImpactType.Air);
				}
			}
			if (_activeMissiles.Count == 0)
			{
				_missilesFired = false;
				_restrictedAirspaceTimer = float.MaxValue;
			}
		}

		public void OnUpdate()
		{
			FlightSceneScript instance = FlightSceneScript.Instance;
			FlightScenePlayer flightScenePlayer = instance?.LocalPlayer;
			if (flightScenePlayer == null || !flightScenePlayer.InitialCraftLoadCompleted)
			{
				return;
			}
			FlightSceneNetworkScript flightSceneNetwork = instance.FlightSceneNetwork;
			if (flightSceneNetwork.IsServerStarted)
			{
				NetworkFlightObject flightObjectByID = flightSceneNetwork.FlightObjectsManager.GetFlightObjectByID(_carrierId);
				if (flightObjectByID != null)
				{
					Vector3 vector = Utility.ConvertFloatingOriginToAbsolutePosition(flightObjectByID.transform.position);
					if (!GetClosestDemoData(vector).BoundsInvisibleWall.Contains(vector))
					{
						flightObjectByID.DespawnObject();
					}
				}
			}
			Vector3 globalPosition = flightScenePlayer.GlobalPosition;
			DemoData closestDemoData = GetClosestDemoData(globalPosition);
			if (closestDemoData.BoundsWarning.Contains(globalPosition))
			{
				UpdateCurrentAirspace(AirspaceType.Default);
				OnUpdateDefaultAirspace();
			}
			else if (closestDemoData.BoundsRestricted.Contains(globalPosition))
			{
				UpdateCurrentAirspace(AirspaceType.Warning);
				OnUpdateWarningAirspace();
			}
			else if (closestDemoData.BoundsInvisibleWall.Contains(globalPosition))
			{
				UpdateCurrentAirspace(AirspaceType.Restricted);
				OnUpdateRestrictedAirspace();
			}
			else
			{
				UpdateCurrentAirspace(AirspaceType.InvisibleWall);
				OnUpdateInvisibleWall(closestDemoData, flightScenePlayer, globalPosition, closestDemoData.BoundsInvisibleWall.ClosestPoint(globalPosition));
			}
			if (_currentAirspaceType != AirspaceType.Default)
			{
				if (_currentAirspaceType == AirspaceType.Warning)
				{
					_restrictedAirspaceTimer -= Time.deltaTime;
				}
				else
				{
					_restrictedAirspaceTimer = 0f;
				}
				if (!_missilesFired && _restrictedAirspaceTimer <= 0f && flightScenePlayer.Aircraft != null)
				{
					_missilesFired = true;
					FireMissiles(closestDemoData, flightScenePlayer.Aircraft);
				}
			}
			else
			{
				_restrictedAirspaceTimer = float.MaxValue;
				_missilesFired = false;
			}
			KeepCamerasInBounds(closestDemoData);
		}

		private void FireMissiles(DemoData demoData, AircraftScript target)
		{
			Vector3 position = target.Position;
			Vector3 normalized = (demoData.BoundsCenter - position).normalized;
			Vector3 position2 = position - normalized * 2000f;
			position2.y = 500f;
			GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("Demo/Sam");
			gameObject.transform.SetParent(FlightSceneScript.Instance.transform, worldPositionStays: false);
			gameObject.transform.SetPositionAndRotation(position2, Quaternion.LookRotation(normalized, Vector3.up));
			_activeMissiles.Add(new SamMissile(gameObject, target));
		}

		private DemoData GetClosestDemoData(Vector3 globalPosition)
		{
			DemoData demoData = _demoData[0];
			float num = (globalPosition - demoData.BoundsCenter).sqrMagnitude;
			for (int i = 1; i < _demoData.Length; i++)
			{
				DemoData demoData2 = _demoData[i];
				float sqrMagnitude = (globalPosition - demoData2.BoundsCenter).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					demoData = demoData2;
					num = sqrMagnitude;
				}
			}
			return demoData;
		}

		private void KeepCamerasInBounds(DemoData demoData)
		{
			CameraManagerScript instance = CameraManagerScript.Instance;
			Vector3? vector = instance?.CameraFocalPosition?.position;
			bool flag = vector.HasValue && !demoData.BoundsInvisibleWall.Contains(Utility.ConvertFloatingOriginToAbsolutePosition(vector.Value));
			Vector3? vector2 = instance?.CameraTransform.position;
			bool flag2 = vector2.HasValue && !demoData.BoundsInvisibleWall.Contains(Utility.ConvertFloatingOriginToAbsolutePosition(vector2.Value));
			InteractiveCameraController interactiveCameraController = instance.Controller as InteractiveCameraController;
			bool flag3 = interactiveCameraController != null;
			bool flag4 = instance.Controller?.CameraVantage != null;
			bool flag5 = flag3 && interactiveCameraController.TargetPositionOffset.sqrMagnitude > 100f;
			if (flag || flag2)
			{
				if (flag4)
				{
					instance.SwitchToDefaultCamera();
				}
				if (flag5)
				{
					interactiveCameraController.RecenterView();
				}
			}
		}

		private void OnEnterAirspace(AirspaceType airspace)
		{
			switch (airspace)
			{
			case AirspaceType.Default:
				FlightSceneScript.Instance.FlightUI.SetDemoRestrictedAirspaceWarningVisibility();
				break;
			case AirspaceType.Warning:
				FlightSceneScript.Instance.FlightUI.SetDemoRestrictedAirspaceWarningVisibility(1);
				break;
			default:
				FlightSceneScript.Instance.FlightUI.SetDemoRestrictedAirspaceWarningVisibility(2);
				break;
			}
		}

		private void OnExitAirspace(AirspaceType airspace)
		{
		}

		private void OnUpdateDefaultAirspace()
		{
		}

		private void OnUpdateInvisibleWall(DemoData demoData, FlightScenePlayer player, Vector3 playerPosition, Vector3 pointOnBounds)
		{
			Vector3 normalized = (demoData.BoundsCenter - pointOnBounds).normalized;
			bool flag = pointOnBounds.y < demoData.BoundsCenter.y + demoData.BoundsWarning.Bounds.extents.y;
			Vector3 globalPosition = pointOnBounds + new Vector3(normalized.x * 10f, flag ? 10f : (-10f), normalized.z * 10f);
			Vector3 velocity = new Vector3(normalized.x * 500f, flag ? 100f : 0f, normalized.z * 500f);
			player.GlobalPosition = globalPosition;
			if (player.Aircraft != null)
			{
				player.Aircraft.SetVelocity(velocity);
			}
			else if (player.CharacterActor != null)
			{
				player.CharacterActor.Velocity = velocity;
			}
		}

		private void OnUpdateRestrictedAirspace()
		{
		}

		private void OnUpdateWarningAirspace()
		{
		}

		private void UpdateCurrentAirspace(AirspaceType airspaceType)
		{
			if (_currentAirspaceType != airspaceType)
			{
				OnExitAirspace(_currentAirspaceType);
				_currentAirspaceType = airspaceType;
				OnEnterAirspace(_currentAirspaceType);
			}
		}
	}
}
