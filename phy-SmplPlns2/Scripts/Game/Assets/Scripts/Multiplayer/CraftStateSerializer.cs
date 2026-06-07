using System;
using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Multiplayer.Extensions;
using Assets.Scripts.Multiplayer.SyncData;
using FishNet.Serializing;
using Jundroo.Common.Extensions;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class CraftStateSerializer
	{
		private static class Profile
		{
			public static readonly ProfilerMarker SerializeRead = new ProfilerMarker("CraftStateSerializer.SerializeRead");

			public static readonly ProfilerMarker SerializeWrite = new ProfilerMarker("CraftStateSerializer.SerializeWrite");
		}

		private NetworkAircraftControls _aircraftControls = new NetworkAircraftControls();

		private FlightSceneNetworkScript _fsn;

		private float _lastPhysicsTime;

		public AircraftScript AircraftScript { get; }

		public CraftStateSerializer(AircraftScript aircraft, bool isOwner)
		{
			AircraftScript = aircraft;
			_aircraftControls = new NetworkAircraftControls();
			_aircraftControls.SetControls(aircraft.Controls, !isOwner);
			_fsn = FlightSceneScript.Instance.FlightSceneNetwork;
		}

		public void SerializeRead(Reader reader, int currentState)
		{
			using (Profile.SerializeRead.Auto())
			{
				if (!AircraftScript.IsInitialized)
				{
					return;
				}
				float physicsTime = _fsn.PhysicsTime;
				if (reader.ReadInt32() != currentState)
				{
					return;
				}
				float num = reader.ReadSingle();
				Vector3 vector = reader.ReadVector3() - GameWorld.Instance.FloatingOriginOffset;
				float num2 = Mathf.Clamp(physicsTime - num, 0f, 0.25f);
				if (!(_lastPhysicsTime <= num))
				{
					return;
				}
				_lastPhysicsTime = num;
				byte b = reader.ReadUInt8Unpacked();
				for (int i = 0; i < b; i++)
				{
					int num3 = reader.ReadInt32();
					Vector3 vector2 = reader.ReadVector3();
					Quaternion quaternion = reader.ReadQuaternion32();
					Vector3 vector3 = reader.ReadVector3();
					Vector3 angularVelocity = reader.ReadVector3();
					BodyScript body = AircraftScript.GetBody(num3);
					if (!(body != null))
					{
						continue;
					}
					if (MathUtility.IsInvalid(vector2))
					{
						Debug.LogError($"Received invalid (NaN/infinity) position for Body {num3}. Discarding!");
						continue;
					}
					Vector3 vector4 = vector2 + vector + num2 * vector3;
					Vector3 position = body.RigidBody.position;
					if ((vector4 - position).sqrMagnitude > 10000f)
					{
						body.RigidBody.position = vector4;
					}
					else
					{
						float t = Mathf.Lerp(0.1f, 1f, vector3.magnitude * 0.02f);
						body.RigidBody.position = Vector3.Lerp(position, vector4, t);
					}
					Quaternion quaternion2 = quaternion;
					float num4 = angularVelocity.magnitude * num2;
					Vector3 normalized = angularVelocity.normalized;
					if (num4 > Mathf.Epsilon)
					{
						Quaternion quaternion3 = Quaternion.AngleAxis(num4 * 57.29578f, normalized);
						float t2 = 2.5f * Time.deltaTime;
						body.RigidBody.rotation = Quaternion.Slerp(body.RigidBody.rotation, quaternion2 * quaternion3, t2);
					}
					else
					{
						body.RigidBody.rotation = quaternion2;
					}
					body.SyncData.Velocity = vector3;
					body.SyncData.AngularVelocity = angularVelocity;
					body.RigidBody.velocity = body.SyncData.Velocity;
					body.RigidBody.angularVelocity = body.SyncData.AngularVelocity;
					body.SyncData.TargetPosition = null;
					body.SyncData.TargetRotation = null;
				}
				byte b2 = reader.ReadUInt8Unpacked();
				for (int j = 0; j < b2; j++)
				{
					int id = reader.ReadInt32();
					Vector3 value = reader.ReadVector3();
					Quaternion value2 = reader.ReadQuaternion32();
					BodyScript body2 = AircraftScript.GetBody(id);
					if (body2 != null)
					{
						body2.SyncData.TargetPosition = value;
						body2.SyncData.TargetRotation = value2;
						body2.SyncData.Velocity = Vector3.zero;
						body2.SyncData.AngularVelocity = Vector3.zero;
					}
				}
				_aircraftControls.SerializeRead(reader);
				TargetingSystem targetingSystem = AircraftScript.TargetingSystem;
				int value3 = reader.ReadInt32();
				targetingSystem.SetPlayerTarget(value3);
				targetingSystem.AutoTargetEnemyPlayers = reader.ReadBoolean();
				AircraftScript.VtolManagerScript.CurrentMaxDuctedEngineThrottle = reader.ReadFloatAsByte(-1f);
				byte b3 = reader.ReadUInt8Unpacked();
				for (int k = 0; k < b3; k++)
				{
					int num5 = reader.ReadInt32();
					PartData partById = AircraftScript.Aircraft.Assembly.GetPartById(num5);
					if (partById?.PartScript != null)
					{
						partById.PartScript.SyncData.SerializeRead(reader);
						continue;
					}
					Debug.LogError($"CraftStateSerializer: Could not find part with ID '{num5}'");
					break;
				}
			}
		}

		public void SerializeWrite(Writer writer, int state)
		{
			using (Profile.SerializeWrite.Auto())
			{
				float physicsTime = _fsn.PhysicsTime;
				writer.WriteInt32(state);
				writer.WriteSingle(physicsTime);
				writer.WriteVector3(GameWorld.Instance.FloatingOriginOffset);
				List<BodySyncData> value;
				using (CollectionPool<List<BodySyncData>, BodySyncData>.Get(out value))
				{
					List<BodySyncData> value2;
					using (CollectionPool<List<BodySyncData>, BodySyncData>.Get(out value2))
					{
						float physicsTime2 = physicsTime;
						foreach (BodyScript body in AircraftScript.Bodies)
						{
							if (!body.IsDebris)
							{
								body.SyncData.Update(physicsTime2);
								if (body.SyncData.ParentBody == null)
								{
									value2.Add(body.SyncData);
								}
								else if (body.SyncData.Delta > 0.1f)
								{
									value.Add(body.SyncData);
								}
							}
						}
						value2.Sort((BodySyncData a, BodySyncData b) => b.Delta.CompareTo(a.Delta));
						Span<BodySyncData> span = value2.AsSpan(0, Mathf.Min(5, value2.Count));
						writer.WriteUInt8Unpacked((byte)span.Length);
						Span<BodySyncData> span2 = span;
						for (int num = 0; num < span2.Length; num++)
						{
							BodySyncData bodySyncData = span2[num];
							bodySyncData.OnSent(physicsTime);
							writer.WriteInt32(bodySyncData.Id);
							writer.WriteVector3(bodySyncData.Position);
							writer.WriteQuaternion32(bodySyncData.Rotation);
							writer.WriteVector3(bodySyncData.Velocity);
							writer.WriteVector3(bodySyncData.AngularVelocity);
						}
						value.Sort((BodySyncData a, BodySyncData b) => b.Delta.CompareTo(a.Delta));
						Span<BodySyncData> span3 = value.AsSpan(0, Mathf.Min(5, value.Count));
						writer.WriteUInt8Unpacked((byte)span3.Length);
						span2 = span3;
						for (int num = 0; num < span2.Length; num++)
						{
							BodySyncData bodySyncData2 = span2[num];
							bodySyncData2.OnSent(physicsTime);
							writer.WriteInt32(bodySyncData2.Id);
							writer.WriteVector3(bodySyncData2.Position);
							writer.WriteQuaternion32(bodySyncData2.Rotation);
						}
						_aircraftControls.SerializeWrite(writer);
						TargetingSystem targetingSystem = AircraftScript.TargetingSystem;
						writer.WriteInt32((targetingSystem.CurrentTarget?.Player?.NetworkPlayer)?.PlayerId ?? (-1));
						writer.WriteBoolean(targetingSystem.AutoTargetEnemyPlayers);
						writer.WriteFloatAsByte(AircraftScript.VtolManagerScript.CurrentMaxDuctedEngineThrottle, -1f);
						List<PartScript> value3;
						using (CollectionPool<List<PartScript>, PartScript>.Get(out value3))
						{
							foreach (PartScript syncPart in AircraftScript.SyncParts)
							{
								syncPart.SyncData.CalculateDelta(physicsTime);
								if (syncPart.SyncData.Delta > 0.1f)
								{
									value3.Add(syncPart);
								}
							}
							value3.Sort((PartScript a, PartScript b) => b.SyncData.Delta.CompareTo(a.SyncData.Delta));
							Span<PartScript> span4 = value3.AsSpan(0, Mathf.Min(5, value3.Count));
							writer.WriteUInt8Unpacked((byte)span4.Length);
							Span<PartScript> span5 = span4;
							for (int num = 0; num < span5.Length; num++)
							{
								PartScript partScript = span5[num];
								writer.WriteInt32(partScript.Part.Id);
								partScript.SyncData.SerializeWrite(writer, physicsTime);
							}
						}
					}
				}
			}
		}
	}
}
