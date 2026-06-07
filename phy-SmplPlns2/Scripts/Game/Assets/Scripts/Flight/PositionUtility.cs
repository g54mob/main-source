using System;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight.Proximity;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Levels;
using Assets.Scripts.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Flight
{
	public class PositionUtility
	{
		public static bool MovingCraftToNewLocation { get; private set; }

		public static PositionResult PositionAtAvailableLocation(StartLocation startLocation, IRepositionable repositionable, bool allowRepositioning, bool floatOriginToLocation)
		{
			try
			{
				startLocation.ReadyLocationSynchronously();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				return PositionResult.Unavailable;
			}
			try
			{
				MovingCraftToNewLocation = true;
				repositionable.OnBeginReposition(startLocation.Position);
				return PositionAtLocationInternal(startLocation, repositionable, allowRepositioning, floatOriginToLocation);
			}
			finally
			{
				MovingCraftToNewLocation = false;
				repositionable.OnEndReposition(repositionable.GlobalPosition, repositionable.Rotation);
			}
		}

		public static async UniTask<PositionResult> PositionAtLocation(StartLocationData startLocationData, IRepositionable repositionable, bool allowRepositioning, bool floatOriginToLocation)
		{
			(StartLocation, CreateStartLocationResultType) obj = await FlightSceneScript.Instance.StartLocationManager.CreateStartLocation(startLocationData);
			var (startLocation, _) = obj;
			switch (obj.Item2)
			{
			case CreateStartLocationResultType.Success:
				return await PositionAtLocation(startLocation, repositionable, allowRepositioning, floatOriginToLocation);
			case CreateStartLocationResultType.Unavailable:
				return PositionResult.Unavailable;
			case CreateStartLocationResultType.NotFound:
				Debug.LogError("Reposition failed. Start location '" + startLocationData.DisplayName + "' (ID: " + startLocationData.Id + ") was not found.");
				return PositionResult.NotFound;
			default:
				Debug.LogError("Reposition failed with an unknown error. Start location '" + startLocationData.DisplayName + "' (ID: " + startLocationData.Id + ") was not found.");
				return PositionResult.NotFound;
			}
		}

		public static async UniTask<PositionResult> PositionAtLocation(StartLocation startLocation, IRepositionable repositionable, bool allowRepositioning, bool floatOriginToLocation, UniTask prerequisiteTask = default(UniTask))
		{
			_ = 1;
			try
			{
				MovingCraftToNewLocation = true;
				repositionable.OnBeginReposition(startLocation.IsDynamic ? startLocation.DynamicLocationPosition : startLocation.Position);
				if (!(await startLocation.WaitUntilReady(30000)))
				{
					Debug.LogError("An attempt to position at location '" + startLocation.Id + "' failed.");
					return PositionResult.Unavailable;
				}
				await prerequisiteTask;
				return PositionAtLocationInternal(startLocation, repositionable, allowRepositioning, floatOriginToLocation);
			}
			finally
			{
				MovingCraftToNewLocation = false;
				repositionable.OnEndReposition(repositionable.GlobalPosition, repositionable.Rotation);
			}
		}

		public static bool RepositionAircraftOnGround(AircraftScript aircraftToReposition, bool excludePartsDisconnectedFromMainCockpit, float maxDistanceToGround, bool flipIfNecessary = false)
		{
			if (!Physics.autoSyncTransforms)
			{
				Physics.SyncTransforms();
			}
			if (LevelBase.CurrentLevel.GetElevationAboveGroundLevel(aircraftToReposition.MainCockpit.transform.position) >= maxDistanceToGround)
			{
				return false;
			}
			bool result = false;
			float num = 1f;
			if (aircraftToReposition.MainCockpit == null)
			{
				Debug.LogError("Aborting reposition: No cockpit found");
			}
			else
			{
				Transform transform = aircraftToReposition.MainCockpit.transform.Find("CenterOfMass");
				Vector3 vector = -transform.TransformDirection(Vector3.up);
				bool flag = false;
				if (Vector3.Dot(vector, Vector3.up) > 0f)
				{
					vector *= -1f;
					flag = true;
				}
				RaycastHit hitInfo = default(RaycastHit);
				Physics.Raycast(transform.position, flag ? Vector3.down : (-Vector3.down), out hitInfo, float.PositiveInfinity, 9441296);
				if (Mathf.Abs(Vector3.Dot(transform.up, Vector3.up)) >= 0.95f)
				{
					return RepositionAircraftSimple(aircraftToReposition, excludePartsDisconnectedFromMainCockpit, maxDistanceToGround);
				}
				Transform transform2 = aircraftToReposition.MainCockpit.transform;
				GameObject gameObject = new GameObject("repositionObject");
				gameObject.transform.SetPositionAndRotation(transform2.position, transform.rotation);
				gameObject.transform.parent = transform2;
				Vector3 position = transform2.position;
				gameObject.transform.localPosition -= vector.normalized * num;
				aircraftToReposition.Position = gameObject.transform.position;
				float num2 = float.PositiveInfinity;
				float num3 = 0f;
				PartData partData = null;
				PartData partData2 = null;
				List<PartData> list = new List<PartData>();
				list.AddRange(aircraftToReposition.Parts);
				float maxDistance = float.PositiveInfinity;
				float maxDistance2 = maxDistanceToGround + num;
				if (!excludePartsDisconnectedFromMainCockpit)
				{
					list.AddRange(aircraftToReposition.InitiallyDisconnectedParts);
				}
				RaycastHit? raycastHit = null;
				RaycastHit? raycastHit2 = null;
				RaycastHit? raycastHit3 = null;
				Collider collider = null;
				Collider collider2 = null;
				Collider collider3 = null;
				foreach (PartData item in list)
				{
					if (excludePartsDisconnectedFromMainCockpit && !new PartGraph(item, breakOnRigidBodyBoundary: false).HasCockpit)
					{
						continue;
					}
					Collider primaryPlacementCollider = item.PartScript.PrimaryPlacementCollider;
					if (primaryPlacementCollider == null)
					{
						continue;
					}
					RaycastHit[] array = Physics.RaycastAll(primaryPlacementCollider.bounds.min, -vector, maxDistance, 9441296);
					if (array != null && array.Length != 0)
					{
						RaycastHit? raycastHit4 = null;
						float num4 = 0f;
						RaycastHit[] array2 = array;
						for (int i = 0; i < array2.Length; i++)
						{
							RaycastHit value = array2[i];
							if (value.distance > num4)
							{
								num4 = value.distance;
								raycastHit4 = value;
							}
						}
						if (num4 > Mathf.Abs(num3))
						{
							num3 = num4;
							partData2 = item;
							raycastHit2 = raycastHit4;
							collider = primaryPlacementCollider;
						}
						continue;
					}
					RaycastHit hitInfo2 = default(RaycastHit);
					float num5;
					if (Physics.Raycast(primaryPlacementCollider.bounds.center, vector, out hitInfo2, maxDistance2, 9441296))
					{
						RaycastHit hitInfo3 = default(RaycastHit);
						Physics.Raycast(hitInfo2.point, -vector, out hitInfo3, maxDistance2, 2097152);
						num5 = hitInfo3.distance;
					}
					else
					{
						num5 = float.PositiveInfinity;
					}
					float? num6 = null;
					RaycastHit hitInfo4 = default(RaycastHit);
					if (Physics.Raycast(primaryPlacementCollider.bounds.min, vector, out hitInfo4, maxDistance2, 9441296))
					{
						RaycastHit hitInfo5 = default(RaycastHit);
						if (Physics.Raycast(hitInfo4.point, -vector, out hitInfo5, maxDistance2, 2097152))
						{
							num6 = hitInfo5.distance;
						}
					}
					RaycastHit value2;
					float num7;
					if (num6.HasValue)
					{
						if (num6.Value < num5)
						{
							value2 = hitInfo4;
							num7 = num6.Value;
						}
						else
						{
							value2 = hitInfo2;
							num7 = num5;
						}
					}
					else
					{
						value2 = hitInfo2;
						num7 = num5;
					}
					if (num7 < Mathf.Abs(num2))
					{
						num2 = 0f - num7;
						partData = item;
						raycastHit = value2;
						collider2 = primaryPlacementCollider;
					}
				}
				if (partData == null && partData2 == null)
				{
					Debug.LogWarning("Aborting reposition: Raycasts didn't hit the terrain (above water, too far away).");
					aircraftToReposition.Position = position;
				}
				else
				{
					if (num3 > 0f)
					{
						raycastHit3 = raycastHit2;
						collider3 = collider;
						if (collider3 is WheelCollider)
						{
							WheelCollider wheelCollider = (WheelCollider)collider3;
							float num8 = wheelCollider.radius + wheelCollider.suspensionDistance;
							Debug.Log("Minimum collider was a wheel...drop a bit less to account for the wheel's suspension distance which is included in the bounds.min");
							num3 -= num8;
						}
						else
						{
							Debug.Log("FYI: The selected collider (below the ground) was not a wheel.");
						}
						gameObject.transform.localPosition += new Vector3(0f, num3 - num, 0f);
					}
					else
					{
						raycastHit3 = raycastHit;
						collider3 = collider2;
						if (collider3 is WheelCollider)
						{
							WheelCollider wheelCollider2 = (WheelCollider)collider3;
							float num9 = wheelCollider2.radius + wheelCollider2.suspensionDistance;
							Debug.Log("Minimum collider was a wheel...account for the wheel's suspension distance which is included in the bounds.min");
							num2 += num9;
						}
						gameObject.transform.position = transform2.position;
						gameObject.transform.localPosition += new Vector3(0f, num2, 0f);
					}
					float num10 = Vector3.Dot(raycastHit3.Value.normal, transform.transform.up);
					if (num10 < 0.9f)
					{
						if (flipIfNecessary)
						{
							Debug.Log("Flipping to reposition");
							aircraftToReposition.transform.up = -aircraftToReposition.transform.up;
							RepositionAircraftOnGround(aircraftToReposition, excludePartsDisconnectedFromMainCockpit, maxDistanceToGround);
						}
						else
						{
							Debug.LogWarning("Aborting reposition : Aircraft not aligned w/ground : " + num10);
							aircraftToReposition.Position = position;
							result = false;
						}
					}
					else
					{
						transform2.position = gameObject.transform.position;
						result = true;
					}
				}
				UnityEngine.Object.Destroy(gameObject);
			}
			return result;
		}

		public static bool RepositionAircraftSimple(AircraftScript aircraftToReposition, bool excludePartsDisconnectedFromMainCockpit, float maxDistanceToGround)
		{
			List<PartData> list = new List<PartData>();
			list.AddRange(aircraftToReposition.Parts);
			if (!excludePartsDisconnectedFromMainCockpit)
			{
				list.AddRange(aircraftToReposition.InitiallyDisconnectedParts);
			}
			float num = float.PositiveInfinity;
			float y = aircraftToReposition.Position.y + aircraftToReposition.Aircraft.Size.y * 2f;
			RaycastHit? raycastHit = null;
			Span<Vector3> span = stackalloc Vector3[4];
			foreach (PartData item in list)
			{
				Bounds? bounds = item.PartScript.PrimaryPlacementCollider?.bounds;
				if (!bounds.HasValue)
				{
					continue;
				}
				RaycastHit hitInfo = default(RaycastHit);
				Vector3 center = bounds.Value.center;
				center.y = y;
				if (!Physics.Raycast(center, Vector3.down, out hitInfo, float.PositiveInfinity, 9441296))
				{
					continue;
				}
				float num2 = bounds.Value.min.y - hitInfo.point.y;
				if (!(num2 < num))
				{
					continue;
				}
				num = num2;
				raycastHit = hitInfo;
				if (!(Vector3.Dot(hitInfo.normal, Vector3.up) < 0.95f))
				{
					continue;
				}
				span[0] = new Vector3(bounds.Value.min.x, y, bounds.Value.min.z);
				span[1] = new Vector3(bounds.Value.min.x, y, bounds.Value.max.z);
				span[2] = new Vector3(bounds.Value.max.x, y, bounds.Value.min.z);
				span[3] = new Vector3(bounds.Value.max.x, y, bounds.Value.max.z);
				for (int i = 0; i < 4; i++)
				{
					if (Physics.Raycast(span[i], Vector3.down, out hitInfo, float.PositiveInfinity, 9441296))
					{
						num2 = bounds.Value.min.y - hitInfo.point.y;
						if (num2 < num)
						{
							num = num2;
							raycastHit = hitInfo;
						}
					}
				}
			}
			if (num < maxDistanceToGround)
			{
				aircraftToReposition.Position -= new Vector3(0f, num, 0f);
				if (raycastHit.HasValue && raycastHit.Value.rigidbody != null)
				{
					aircraftToReposition.SetVelocity(raycastHit.Value.rigidbody.linearVelocity);
				}
				return true;
			}
			return false;
		}

		public static void ShowPositionResultErrorDialog(PositionResult result, string locationName)
		{
			string text = result switch
			{
				PositionResult.Success => null, 
				PositionResult.NotFound => "Unable to reposition to location '" + locationName + "' because the location could not be found.", 
				PositionResult.Unavailable => "Unable to reposition to location '" + locationName + "' because the location is unavailable right now.", 
				PositionResult.Occupied => "Unable to reposition to location '" + locationName + "' because the location is currently occupied.", 
				_ => null, 
			};
			if (text != null)
			{
				Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.Okay, text);
			}
		}

		public static void TeleportPlayer(Vector3 globalPosition, Vector3 rotation, Vector3 velocity)
		{
			TeleportPlayer(new StartLocation(globalPosition, rotation, velocity, null));
		}

		public static void TeleportPlayer(StartLocation startLocation)
		{
			GameState.Instance.RaiseMapLocationChanging("Teleport", "Teleport");
			PositionResult positionResult = PositionAtAvailableLocation(startLocation, FlightSceneScript.Instance.LocalPlayer, allowRepositioning: true, floatOriginToLocation: true);
			if (positionResult == PositionResult.Occupied)
			{
				positionResult = PositionAtAvailableLocation(startLocation, FlightSceneScript.Instance.LocalPlayer, allowRepositioning: false, floatOriginToLocation: true);
			}
			if (positionResult == PositionResult.Success)
			{
				GameState.Instance.RaiseMapLocationChanged("Teleport", "Teleport");
			}
		}

		private static bool CheckPositionForAircraftCollision(Vector3 absolutePosition, float radius, bool startOnGround)
		{
			Vector3 vector = Utility.ConvertAbsoluteToFloatingOriginPosition(absolutePosition);
			bool flag = false;
			if (startOnGround)
			{
				float num = Mathf.Max(absolutePosition.y + radius, 0f);
				return Physics.CheckCapsule(vector, vector + Vector3.down * num, radius, 67108864, QueryTriggerInteraction.Collide);
			}
			return Physics.CheckSphere(vector, radius, 67108864, QueryTriggerInteraction.Collide);
		}

		private static bool FindClosestPosition(StartLocation location, Vector3 size, Vector3 offset, out Vector3 position)
		{
			float num = size.magnitude * 0.5f;
			int num2 = 0;
			float num3 = Mathf.Max(5f, num * 0.5f);
			float num4 = 0f;
			Vector3 vector = Quaternion.Euler(location.Rotation) * location.DistributionAxis;
			position = location.Position;
			while (CheckPositionForAircraftCollision(position + offset, num, location.StartOnGround == true))
			{
				if (num4 >= location.MaxDistributionAmount || num2 > 100)
				{
					Debug.Log($"Failed to reposition after {num2} attempts. Radius: {num}");
					return false;
				}
				num2++;
				bool flag = num2 % 2 == 0;
				if (!flag)
				{
					num4 += num3;
				}
				position = location.Position + (float)((!flag) ? 1 : (-1)) * num4 * vector;
			}
			return true;
		}

		private static PositionResult PositionAtLocationInternal(StartLocation startLocation, IRepositionable repositionable, bool allowRepositioning, bool floatOriginToLocation)
		{
			if (!startLocation.StartOnGround.HasValue)
			{
				startLocation.StartOnGround = startLocation.Flags.HasFlag(StartLocationFlags.IsRunwayTakeoff) || startLocation.Velocity == Vector3.zero;
			}
			if (startLocation.StartOnGround == true)
			{
				startLocation.Rotation = new Vector3(0f, startLocation.Rotation.y, 0f);
			}
			if (allowRepositioning)
			{
				if (!Physics.autoSyncTransforms)
				{
					Physics.SyncTransforms();
				}
				(Bounds, Vector3) bounds = repositionable.GetBounds();
				if (FindClosestPosition(startLocation, bounds.Item1.size, bounds.Item2, out var position))
				{
					startLocation.Position = position;
				}
				else
				{
					if (string.IsNullOrEmpty(startLocation.OverflowLocation))
					{
						return PositionResult.Occupied;
					}
					StartLocationData startLocation2 = FlightSceneScript.Instance.StartLocationManager.GetStartLocation(startLocation.OverflowLocation);
					if (startLocation2 == null)
					{
						Debug.LogError("Overflow start location '" + startLocation.OverflowLocation + "' could not be found.");
						return PositionResult.Occupied;
					}
					StartLocation startLocation3 = null;
					try
					{
						startLocation3 = FlightSceneScript.Instance.StartLocationManager.CreateAvailableStartLocation(startLocation2);
						startLocation3.ReadyLocationSynchronously();
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
						return PositionResult.Occupied;
					}
					if (!FindClosestPosition(startLocation3, bounds.Item1.size, bounds.Item2, out position))
					{
						return PositionResult.Occupied;
					}
					startLocation3.Position = position;
					startLocation = startLocation3;
				}
			}
			repositionable.GlobalPosition = startLocation.Position;
			repositionable.Rotation = startLocation.Rotation;
			if (floatOriginToLocation)
			{
				GameWorld.Instance.RepositionWorld(startLocation.Position, 100f);
			}
			ProximityLoader.Instance.UpdateAll();
			repositionable.SetVelocity(startLocation.Velocity);
			if (!Physics.autoSyncTransforms)
			{
				Physics.SyncTransforms();
			}
			if (startLocation.StartOnGround == true)
			{
				repositionable.RepositionOnGround();
			}
			return PositionResult.Success;
		}
	}
}
