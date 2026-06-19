using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

namespace Aggro.Core
{
	public class PredictedRigidbodyGroup : NetworkEntityBehaviourBase
	{
		[Header("Motion")]
		[Min(0f)]
		public float motionSmoothingVelocityThreshold = 0.1f;

		[Min(0f)]
		public float motionSmoothingAngularVelocityThreshold = 5f;

		[Tooltip("Snap to the server state directly when velocity is < threshold. This is useful to reduce jitter/fighting effects before coming to rest.\nNote this applies position, rotation and velocity(!) so it's still smooth.")]
		public float snapThreshold = 2f;

		[Header("State History")]
		public int stateHistoryLimit = 32;

		public float recordInterval = 0.05f;

		[Tooltip("(Optional) performance optimization where FixedUpdate.RecordState() only inserts state into history if the state actually changed.\nThis is generally a good idea.")]
		public bool onlyRecordChanges = true;

		[Tooltip("(Optional) performance optimization where received state is compared to the LAST recorded state first, before sampling the whole history.\n\nThis can save significant traversal overhead for idle objects with a tiny chance of missing corrections for objects which revisisted the same position in the recent history twice.")]
		public bool compareLastFirst = true;

		[Header("Reconciliation")]
		[Tooltip("Correction threshold in meters. For example, 0.1 means that if the client is off by more than 10cm, it gets corrected.")]
		public double positionCorrectionThreshold = 0.1;

		[Tooltip("Correction threshold in degrees. For example, 5 means that if the client is off by more than 5 degrees, it gets corrected.")]
		public double rotationCorrectionThreshold = 5.0;

		[Tooltip("Applying server corrections one frame ahead gives much better results. We don't know why yet, so this is an option for now.")]
		public bool oneFrameAhead = true;

		[Header("Bandwidth")]
		[Tooltip("Reduce sends while velocity==0. Client's objects may slightly move due to gravity/physics, so we still want to send corrections occasionally even if an object is idle on the server the whole time.")]
		public bool reduceSendsWhileIdle = true;

		private Rigidbody predictedRigidbody;

		private Transform predictedRigidbodyTransform;

		private Transform tf;

		private float motionSmoothingVelocityThresholdSqr;

		private float motionSmoothingAngularVelocityThresholdSqr;

		private double positionCorrectionThresholdSqr;

		private RigidbodyGroupState lastRecorded;

		private double lastRecordTime;

		[NonSerialized]
		public ValueTypeList4<Entity> serverGroup;

		private readonly SortedList<double, RigidbodyGroupState> stateHistory = new SortedList<double, RigidbodyGroupState>();

		public float dynamicMinSyncInterval { get; set; }

		protected override void OnEntityCreated()
		{
			motionSmoothingVelocityThresholdSqr = motionSmoothingVelocityThreshold * motionSmoothingVelocityThreshold;
			motionSmoothingAngularVelocityThresholdSqr = motionSmoothingAngularVelocityThreshold * motionSmoothingAngularVelocityThreshold;
			positionCorrectionThresholdSqr = positionCorrectionThreshold * positionCorrectionThreshold;
			predictedRigidbody = base.entity.rigidbody;
			predictedRigidbodyTransform = base.entity.transform;
			tf = predictedRigidbodyTransform;
			if (base.isServer)
			{
				serverGroup.Add(base.entity);
			}
		}

		protected override void OnUpdatePresentation()
		{
			if (base.isServer)
			{
				UpdateServer();
			}
		}

		protected override void OnUpdateSimulationLate()
		{
			if (!base.isClientOnly || lastRecorded.group.Count == 0)
			{
				return;
			}
			if (onlyRecordChanges)
			{
				bool flag = false;
				for (int i = 0; i < lastRecorded.group.Count; i++)
				{
					RigidbodyGroupEntryState rigidbodyGroupEntryState = lastRecorded.group[i];
					if (rigidbodyGroupEntryState.entity.Exists())
					{
						rigidbodyGroupEntryState.entity.predictedRigidbodyGroup.tf.GetPositionAndRotation(out var position, out var rotation);
						if ((double)(rigidbodyGroupEntryState.position - position).sqrMagnitude >= positionCorrectionThresholdSqr || (double)Quaternion.Angle(rigidbodyGroupEntryState.rotation, rotation) >= rotationCorrectionThreshold)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					return;
				}
			}
			RecordState();
		}

		private void RecordState()
		{
			double time = NetworkTime.time;
			if (time < lastRecordTime + (double)recordInterval)
			{
				return;
			}
			lastRecordTime = time;
			double predictedTime = NetworkTime.predictedTime;
			if (predictedTime == lastRecorded.timestamp)
			{
				return;
			}
			if (stateHistory.Count >= stateHistoryLimit)
			{
				stateHistory.RemoveAt(0);
			}
			ValueTypeList4<Entity> valueTypeList = default(ValueTypeList4<Entity>);
			for (int i = 0; i < lastRecorded.group.Count; i++)
			{
				valueTypeList.Add(lastRecorded.group[i].entity);
			}
			int count = stateHistory.Count;
			RigidbodyGroupState rigidbodyGroupState = default(RigidbodyGroupState);
			if (count > 0)
			{
				rigidbodyGroupState = stateHistory.Values[count - 1];
			}
			RigidbodyGroupState value = new RigidbodyGroupState
			{
				timestamp = predictedTime
			};
			for (int j = 0; j < valueTypeList.Count; j++)
			{
				Entity entity = valueTypeList[j];
				Vector3 position = Vector3.zero;
				Quaternion rotation = Quaternion.identity;
				Vector3 vector = Vector3.zero;
				Vector3 vector2 = Vector3.zero;
				if (entity.Exists())
				{
					PredictedRigidbodyGroup predictedRigidbodyGroup = entity.predictedRigidbodyGroup;
					predictedRigidbodyGroup.tf.GetPositionAndRotation(out position, out rotation);
					vector = predictedRigidbodyGroup.predictedRigidbody.velocity;
					vector2 = predictedRigidbodyGroup.predictedRigidbody.angularVelocity;
				}
				Vector3 positionDelta = Vector3.zero;
				Vector3 velocityDelta = Vector3.zero;
				Vector3 angularVelocityDelta = Vector3.zero;
				Quaternion rotationDelta = Quaternion.identity;
				if (count > 0)
				{
					RigidbodyGroupEntryState rigidbodyGroupEntryState = rigidbodyGroupState.group[j];
					positionDelta = position - rigidbodyGroupEntryState.position;
					velocityDelta = vector - rigidbodyGroupEntryState.velocity;
					rotationDelta = (rotation * Quaternion.Inverse(rigidbodyGroupEntryState.rotation)).normalized;
					angularVelocityDelta = vector2 - rigidbodyGroupEntryState.angularVelocity;
				}
				RigidbodyGroupEntryState item = new RigidbodyGroupEntryState
				{
					entity = entity,
					positionDelta = positionDelta,
					position = position,
					rotationDelta = rotationDelta,
					rotation = rotation,
					velocityDelta = velocityDelta,
					velocity = vector,
					angularVelocityDelta = angularVelocityDelta,
					angularVelocity = vector2
				};
				value.group.Add(item);
			}
			stateHistory.Add(predictedTime, value);
			lastRecorded = value;
		}

		private void UpdateServer()
		{
			if (reduceSendsWhileIdle)
			{
				bool flag = false;
				for (int i = 0; i < serverGroup.Count; i++)
				{
					if (serverGroup[i].predictedRigidbodyGroup.IsMoving())
					{
						flag = true;
						break;
					}
				}
				syncInterval = ((flag && serverGroup.Count > 0) ? dynamicMinSyncInterval : 1f);
			}
			if (serverGroup.Count > 0)
			{
				SetDirty();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsMoving()
		{
			if (!(predictedRigidbody.velocity.sqrMagnitude >= motionSmoothingVelocityThresholdSqr))
			{
				return predictedRigidbody.angularVelocity.sqrMagnitude >= motionSmoothingAngularVelocityThresholdSqr;
			}
			return true;
		}

		public override void OnSerialize(NetworkWriter writer, bool initialState)
		{
			writer.WriteByte((byte)serverGroup.Count);
			if (serverGroup.Count <= 0)
			{
				return;
			}
			byte b = 0;
			for (int i = 0; i < serverGroup.Count; i++)
			{
				if (serverGroup[i].predictedRigidbodyGroup.IsMoving())
				{
					b |= (byte)(1 << i);
				}
			}
			writer.WriteFloat(Time.deltaTime);
			writer.WriteByte(b);
			for (int j = 0; j < serverGroup.Count; j++)
			{
				Entity entity = serverGroup[j];
				if (j > 0)
				{
					writer.WriteEntity(entity);
				}
				if (entity.Exists())
				{
					entity.predictedRigidbodyGroup.tf.GetPositionAndRotation(out var position, out var rotation);
					writer.WriteVector3(position);
					writer.WriteQuaternion(rotation);
					if ((b & (1 << j)) != 0)
					{
						Rigidbody rigidbody = entity.rigidbody;
						writer.WriteVector3(rigidbody.velocity);
						writer.WriteVector3(rigidbody.angularVelocity);
					}
				}
			}
		}

		public override void OnDeserialize(NetworkReader reader, bool initialState)
		{
			double remoteTimeStamp = NetworkClient.connection.remoteTimeStamp;
			int num = reader.ReadByte();
			if (num != lastRecorded.group.Count)
			{
				stateHistory.Clear();
				lastRecordTime = 0.0;
				lastRecorded = default(RigidbodyGroupState);
			}
			if (num <= 0)
			{
				return;
			}
			double num2 = reader.ReadFloat();
			byte b = reader.ReadByte();
			remoteTimeStamp += num2;
			if (oneFrameAhead)
			{
				remoteTimeStamp += num2;
			}
			RigidbodyGroupState groupState = new RigidbodyGroupState
			{
				timestamp = remoteTimeStamp
			};
			for (int i = 0; i < num; i++)
			{
				RigidbodyGroupEntryState item = default(RigidbodyGroupEntryState);
				if (i == 0)
				{
					item.entity = base.entity;
				}
				else
				{
					item.entity = reader.ReadEntity();
				}
				item.position = reader.ReadVector3();
				item.rotation = reader.ReadQuaternion();
				if ((b & (1 << i)) != 0)
				{
					item.velocity = reader.ReadVector3();
					item.angularVelocity = reader.ReadVector3();
				}
				groupState.group.Add(item);
			}
			bool flag = false;
			if (num == lastRecorded.group.Count)
			{
				for (int j = 0; j < num; j++)
				{
					if (groupState.group[j].entity != lastRecorded.group[j].entity)
					{
						flag = true;
						break;
					}
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				stateHistory.Clear();
				lastRecordTime = 0.0;
				for (int k = 0; k < num; k++)
				{
					RigidbodyGroupEntryState item2 = new RigidbodyGroupEntryState
					{
						entity = groupState.group[k].entity
					};
					lastRecorded.group.Add(item2);
				}
			}
			OnReceivedState(in groupState);
		}

		private void OnReceivedState(in RigidbodyGroupState groupState)
		{
			ValueTypeList4<Vector3> valueTypeList = default(ValueTypeList4<Vector3>);
			ValueTypeList4<float> valueTypeList2 = default(ValueTypeList4<float>);
			ValueTypeList4<Quaternion> valueTypeList3 = default(ValueTypeList4<Quaternion>);
			for (int i = 0; i < groupState.group.Count; i++)
			{
				RigidbodyGroupEntryState rigidbodyGroupEntryState = groupState.group[i];
				Vector3 position = Vector3.zero;
				Quaternion rotation = Quaternion.identity;
				if (rigidbodyGroupEntryState.entity.Exists())
				{
					rigidbodyGroupEntryState.entity.predictedRigidbodyGroup.predictedRigidbodyTransform.GetPositionAndRotation(out position, out rotation);
				}
				valueTypeList.Add(position);
				valueTypeList3.Add(rotation);
				valueTypeList2.Add(Vector3.SqrMagnitude(rigidbodyGroupEntryState.position - position));
			}
			if (compareLastFirst)
			{
				bool flag = true;
				for (int j = 0; j < groupState.group.Count; j++)
				{
					if ((double)valueTypeList2[j] >= positionCorrectionThresholdSqr || (double)Quaternion.Angle(groupState.group[j].rotation, valueTypeList3[j]) >= rotationCorrectionThreshold)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return;
				}
			}
			RecordState();
			if (stateHistory.Count < 2)
			{
				return;
			}
			RigidbodyGroupState rigidbodyGroupState = stateHistory.Values[0];
			RigidbodyGroupState rigidbodyGroupState2 = stateHistory.Values[stateHistory.Count - 1];
			if (groupState.timestamp < rigidbodyGroupState.timestamp)
			{
				if (stateHistory.Count >= stateHistoryLimit)
				{
					Debug.LogWarning($"Hard correcting client object {base.name} because the client is too far behind the server. History of size={stateHistory.Count} @ t={groupState.timestamp:F3} oldest={rigidbodyGroupState.timestamp:F3} newest={rigidbodyGroupState2.timestamp:F3}. This would cause the client to be out of sync as long as it's behind.");
				}
				ApplyState(in groupState);
				return;
			}
			if (rigidbodyGroupState2.timestamp < groupState.timestamp)
			{
				bool flag2 = false;
				for (int k = 0; k < valueTypeList2.Count; k++)
				{
					if ((double)valueTypeList2[k] >= positionCorrectionThresholdSqr)
					{
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					ApplyState(in groupState);
				}
				return;
			}
			if (!Prediction.Sample(stateHistory, groupState.timestamp, out var before, out var after, out var afterIndex, out var t))
			{
				Debug.LogError($"Failed to sample history of size={stateHistory.Count} @ t={groupState.timestamp:F3} oldest={rigidbodyGroupState.timestamp:F3} newest={rigidbodyGroupState2.timestamp:F3}. This should never happen because the timestamp is within history.");
				ApplyState(in groupState);
				return;
			}
			RigidbodyGroupState rigidbodyGroupState3 = RigidbodyGroupState.Interpolate(in before, in after, (float)t);
			bool flag3 = false;
			for (int l = 0; l < groupState.group.Count; l++)
			{
				RigidbodyGroupEntryState rigidbodyGroupEntryState2 = groupState.group[l];
				RigidbodyGroupEntryState rigidbodyGroupEntryState3 = rigidbodyGroupState3.group[l];
				if ((double)Vector3.SqrMagnitude(rigidbodyGroupEntryState2.position - rigidbodyGroupEntryState3.position) >= positionCorrectionThresholdSqr || (double)Quaternion.Angle(rigidbodyGroupEntryState2.rotation, rigidbodyGroupEntryState3.rotation) >= rotationCorrectionThreshold)
				{
					flag3 = true;
					break;
				}
			}
			if (flag3)
			{
				ApplyState(CorrectHistory(stateHistory, stateHistoryLimit, groupState, before, after, afterIndex));
			}
		}

		private void ApplyState(in RigidbodyGroupState groupState)
		{
			bool flag = false;
			float num = snapThreshold * snapThreshold;
			for (int i = 0; i < groupState.group.Count; i++)
			{
				Entity entity = groupState.group[i].entity;
				if (entity.Exists())
				{
					Rigidbody rigidbody = entity.predictedRigidbodyGroup.predictedRigidbody;
					if (rigidbody.velocity.sqrMagnitude <= num && rigidbody.angularVelocity.sqrMagnitude <= num)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				for (int j = 0; j < groupState.group.Count; j++)
				{
					RigidbodyGroupEntryState rigidbodyGroupEntryState = groupState.group[j];
					if (rigidbodyGroupEntryState.entity.Exists())
					{
						Rigidbody rigidbody2 = rigidbodyGroupEntryState.entity.predictedRigidbodyGroup.predictedRigidbody;
						rigidbody2.position = rigidbodyGroupEntryState.position;
						rigidbody2.rotation = rigidbodyGroupEntryState.rotation;
						if (!rigidbody2.isKinematic)
						{
							rigidbody2.velocity = rigidbodyGroupEntryState.velocity;
							rigidbody2.angularVelocity = rigidbodyGroupEntryState.angularVelocity;
						}
					}
				}
				stateHistory.Clear();
				stateHistory.Add(groupState.timestamp, groupState);
				return;
			}
			for (int k = 0; k < groupState.group.Count; k++)
			{
				RigidbodyGroupEntryState rigidbodyGroupEntryState2 = groupState.group[k];
				if (rigidbodyGroupEntryState2.entity.Exists())
				{
					Rigidbody rigidbody3 = rigidbodyGroupEntryState2.entity.predictedRigidbodyGroup.predictedRigidbody;
					rigidbody3.MovePosition(rigidbodyGroupEntryState2.position);
					rigidbody3.MoveRotation(rigidbodyGroupEntryState2.rotation);
					if (!rigidbody3.isKinematic)
					{
						rigidbody3.velocity = rigidbodyGroupEntryState2.velocity;
						rigidbody3.angularVelocity = rigidbodyGroupEntryState2.angularVelocity;
					}
				}
			}
		}

		private static RigidbodyGroupState CorrectHistory(SortedList<double, RigidbodyGroupState> history, int stateHistoryLimit, RigidbodyGroupState corrected, RigidbodyGroupState before, RigidbodyGroupState after, int afterIndex)
		{
			if (history.Count >= stateHistoryLimit)
			{
				history.RemoveAt(0);
				afterIndex--;
			}
			double num = after.timestamp - before.timestamp;
			double num2 = after.timestamp - corrected.timestamp;
			double num3 = ((num != 0.0) ? (num2 / num) : 0.0);
			for (int i = 0; i < after.group.Count; i++)
			{
				RigidbodyGroupEntryState value = after.group[i];
				value.positionDelta = Vector3.Lerp(Vector3.zero, value.positionDelta, (float)num3);
				value.velocityDelta = Vector3.Lerp(Vector3.zero, value.velocityDelta, (float)num3);
				value.angularVelocityDelta = Vector3.Lerp(Vector3.zero, value.angularVelocityDelta, (float)num3);
				value.rotationDelta = Quaternion.Slerp(Quaternion.identity, value.rotationDelta, (float)num3).normalized;
				after.group[i] = value;
			}
			history[after.timestamp] = after;
			RigidbodyGroupState result = corrected;
			for (int j = afterIndex; j < history.Count; j++)
			{
				double num4 = history.Keys[j];
				RigidbodyGroupState rigidbodyGroupState = history.Values[j];
				for (int k = 0; k < rigidbodyGroupState.group.Count; k++)
				{
					RigidbodyGroupEntryState value2 = rigidbodyGroupState.group[k];
					RigidbodyGroupEntryState rigidbodyGroupEntryState = result.group[k];
					value2.position = rigidbodyGroupEntryState.position + value2.positionDelta;
					value2.velocity = rigidbodyGroupEntryState.velocity + value2.velocityDelta;
					value2.angularVelocity = rigidbodyGroupEntryState.angularVelocity + value2.angularVelocityDelta;
					value2.rotation = (value2.rotationDelta * rigidbodyGroupEntryState.rotation).normalized;
					rigidbodyGroupState.group[k] = value2;
				}
				history[num4] = rigidbodyGroupState;
				result = rigidbodyGroupState;
			}
			return result;
		}

		[Server]
		public void ServerResetGroup()
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("[Server] function 'System.Void Aggro.Core.PredictedRigidbodyGroup::ServerResetGroup()' called when server was not active");
				return;
			}
			serverGroup.Clear();
			serverGroup.Add(base.entity);
			SetDirty();
		}

		[Server]
		public void ServerClearGroup()
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("[Server] function 'System.Void Aggro.Core.PredictedRigidbodyGroup::ServerClearGroup()' called when server was not active");
				return;
			}
			serverGroup.Clear();
			SetDirty();
		}

		[Server]
		public void ServerAddToGroup(Entity e)
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("[Server] function 'System.Void Aggro.Core.PredictedRigidbodyGroup::ServerAddToGroup(Aggro.Core.Entity)' called when server was not active");
			}
			else if (!(e == base.entity))
			{
				if (serverGroup.Count == 0)
				{
					serverGroup.Add(base.entity);
				}
				serverGroup.Add(e);
				SetDirty();
			}
		}

		[Server]
		public void ServerRemoveFromGroup(Entity e)
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("[Server] function 'System.Void Aggro.Core.PredictedRigidbodyGroup::ServerRemoveFromGroup(Aggro.Core.Entity)' called when server was not active");
				return;
			}
			serverGroup.Remove(e);
			SetDirty();
		}

		[Server]
		public void ServerTeleport(List<Vector3> positions, List<Quaternion> rotations)
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("[Server] function 'System.Void Aggro.Core.PredictedRigidbodyGroup::ServerTeleport(System.Collections.Generic.List`1<UnityEngine.Vector3>,System.Collections.Generic.List`1<UnityEngine.Quaternion>)' called when server was not active");
				return;
			}
			ValueTypeList4<Entity> entities = default(ValueTypeList4<Entity>);
			for (int i = 0; i < serverGroup.Count; i++)
			{
				entities.Add(serverGroup[i]);
			}
			ValueTypeList4<Vector3> positions2 = new ValueTypeList4<Vector3>(positions);
			ValueTypeList4<Quaternion> rotations2 = new ValueTypeList4<Quaternion>(rotations);
			TeleportInternal(in entities, in positions2, in rotations2, default(ValueTypeList4<Vector3>));
			RpcTeleport(entities, positions2, rotations2);
		}

		[ClientRpc]
		private void RpcTeleport(ValueTypeList4<Entity> entities, ValueTypeList4<Vector3> positions, ValueTypeList4<Quaternion> rotations)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteEntityValueTypeList4(entities);
			writer.WriteVector3ValueTypeList4(positions);
			writer.WriteQuaternionValueTypeList4(rotations);
			SendRPCInternal("System.Void Aggro.Core.PredictedRigidbodyGroup::RpcTeleport(Aggro.Core.ValueTypeList4`1<Aggro.Core.Entity>,Aggro.Core.ValueTypeList4`1<UnityEngine.Vector3>,Aggro.Core.ValueTypeList4`1<UnityEngine.Quaternion>)", -1889059317, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		[Server]
		public void ServerTeleport(List<Vector3> positions, Quaternion rotation)
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("[Server] function 'System.Void Aggro.Core.PredictedRigidbodyGroup::ServerTeleport(System.Collections.Generic.List`1<UnityEngine.Vector3>,UnityEngine.Quaternion)' called when server was not active");
				return;
			}
			ValueTypeList4<Entity> entities = default(ValueTypeList4<Entity>);
			for (int i = 0; i < serverGroup.Count; i++)
			{
				entities.Add(serverGroup[i]);
			}
			ValueTypeList4<Vector3> positions2 = new ValueTypeList4<Vector3>(positions);
			ValueTypeList4<Quaternion> rotations = default(ValueTypeList4<Quaternion>);
			ValueTypeList4<Vector3> velocities = default(ValueTypeList4<Vector3>);
			for (int j = 0; j < serverGroup.Count; j++)
			{
				rotations.Add(rotation);
				velocities.Add(Vector3.zero);
			}
			TeleportInternal(in entities, in positions2, in rotations, in velocities);
			RpcTeleport(entities, positions2, rotation);
		}

		[ClientRpc]
		private void RpcTeleport(ValueTypeList4<Entity> entities, ValueTypeList4<Vector3> positions, Quaternion rotation)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteEntityValueTypeList4(entities);
			writer.WriteVector3ValueTypeList4(positions);
			writer.WriteQuaternion(rotation);
			SendRPCInternal("System.Void Aggro.Core.PredictedRigidbodyGroup::RpcTeleport(Aggro.Core.ValueTypeList4`1<Aggro.Core.Entity>,Aggro.Core.ValueTypeList4`1<UnityEngine.Vector3>,UnityEngine.Quaternion)", 1210096174, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		[Server]
		public void ServerTeleport(List<Vector3> positions, Vector3 velocity, Quaternion rotation)
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("[Server] function 'System.Void Aggro.Core.PredictedRigidbodyGroup::ServerTeleport(System.Collections.Generic.List`1<UnityEngine.Vector3>,UnityEngine.Vector3,UnityEngine.Quaternion)' called when server was not active");
				return;
			}
			ValueTypeList4<Entity> entities = default(ValueTypeList4<Entity>);
			for (int i = 0; i < serverGroup.Count; i++)
			{
				entities.Add(serverGroup[i]);
			}
			ValueTypeList4<Vector3> positions2 = new ValueTypeList4<Vector3>(positions);
			ValueTypeList4<Quaternion> rotations = default(ValueTypeList4<Quaternion>);
			ValueTypeList4<Vector3> velocities = default(ValueTypeList4<Vector3>);
			for (int j = 0; j < serverGroup.Count; j++)
			{
				rotations.Add(rotation);
				velocities.Add(velocity);
			}
			TeleportInternal(in entities, in positions2, in rotations, in velocities);
			RpcTeleport(entities, positions2, velocity, rotation);
		}

		[ClientRpc]
		private void RpcTeleport(ValueTypeList4<Entity> entities, ValueTypeList4<Vector3> positions, Vector3 velocity, Quaternion rotation)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteEntityValueTypeList4(entities);
			writer.WriteVector3ValueTypeList4(positions);
			writer.WriteVector3(velocity);
			writer.WriteQuaternion(rotation);
			SendRPCInternal("System.Void Aggro.Core.PredictedRigidbodyGroup::RpcTeleport(Aggro.Core.ValueTypeList4`1<Aggro.Core.Entity>,Aggro.Core.ValueTypeList4`1<UnityEngine.Vector3>,UnityEngine.Vector3,UnityEngine.Quaternion)", -599154421, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		[Server]
		public void ServerSnap()
		{
			if (!NetworkServer.active)
			{
				Debug.LogWarning("[Server] function 'System.Void Aggro.Core.PredictedRigidbodyGroup::ServerSnap()' called when server was not active");
				return;
			}
			Rigidbody rigidbody = base.entity.rigidbody;
			if (!rigidbody.isKinematic)
			{
				rigidbody.velocity = Vector3.zero;
				rigidbody.angularVelocity = Vector3.zero;
			}
			RpcSnap(rigidbody.position, rigidbody.rotation);
		}

		[ClientRpc]
		private void RpcSnap(Vector3 pos, Quaternion rot)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteVector3(pos);
			writer.WriteQuaternion(rot);
			SendRPCInternal("System.Void Aggro.Core.PredictedRigidbodyGroup::RpcSnap(UnityEngine.Vector3,UnityEngine.Quaternion)", -472762615, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		private void TeleportInternal(in ValueTypeList4<Entity> entities, in ValueTypeList4<Vector3> positions, in ValueTypeList4<Quaternion> rotations, in ValueTypeList4<Vector3> velocities)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				Entity entity = entities[i];
				Vector3 position = positions[i];
				Quaternion quaternion = rotations[i];
				if (entity.Exists())
				{
					Rigidbody rigidbody = entity.rigidbody;
					rigidbody.position = position;
					rigidbody.rotation = PhysicsUtil.Constrain(quaternion, rigidbody.constraints);
					if (!rigidbody.isKinematic)
					{
						rigidbody.velocity = velocities[i];
						rigidbody.angularVelocity = Vector3.zero;
						rigidbody.WakeUp();
					}
					entity.transform.SetPositionAndRotation(position, quaternion);
				}
			}
		}

		[Client]
		public void ClientClearState()
		{
			if (!NetworkClient.active)
			{
				Debug.LogWarning("[Client] function 'System.Void Aggro.Core.PredictedRigidbodyGroup::ClientClearState()' called when client was not active");
				return;
			}
			lastRecorded = default(RigidbodyGroupState);
			lastRecordTime = 0.0;
			stateHistory.Clear();
		}

		public override bool Weaved()
		{
			return true;
		}

		protected void UserCode_RpcTeleport__ValueTypeList4_00601__ValueTypeList4_00601__ValueTypeList4_00601(ValueTypeList4<Entity> entities, ValueTypeList4<Vector3> positions, ValueTypeList4<Quaternion> rotations)
		{
			if (!base.isServer)
			{
				TeleportInternal(in entities, in positions, in rotations, default(ValueTypeList4<Vector3>));
				ClientClearState();
			}
		}

		protected static void InvokeUserCode_RpcTeleport__ValueTypeList4_00601__ValueTypeList4_00601__ValueTypeList4_00601(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcTeleport called on server.");
			}
			else
			{
				((PredictedRigidbodyGroup)obj).UserCode_RpcTeleport__ValueTypeList4_00601__ValueTypeList4_00601__ValueTypeList4_00601(reader.ReadValueTypeList4(), reader.ReadVector3ValueTypeList4(), reader.ReadQuaternionValueTypeList4());
			}
		}

		protected void UserCode_RpcTeleport__ValueTypeList4_00601__ValueTypeList4_00601__Quaternion(ValueTypeList4<Entity> entities, ValueTypeList4<Vector3> positions, Quaternion rotation)
		{
			if (!base.isServer)
			{
				ValueTypeList4<Quaternion> rotations = default(ValueTypeList4<Quaternion>);
				ValueTypeList4<Vector3> velocities = default(ValueTypeList4<Vector3>);
				for (int i = 0; i < entities.Count; i++)
				{
					rotations.Add(rotation);
					velocities.Add(Vector3.zero);
				}
				TeleportInternal(in entities, in positions, in rotations, in velocities);
				ClientClearState();
			}
		}

		protected static void InvokeUserCode_RpcTeleport__ValueTypeList4_00601__ValueTypeList4_00601__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcTeleport called on server.");
			}
			else
			{
				((PredictedRigidbodyGroup)obj).UserCode_RpcTeleport__ValueTypeList4_00601__ValueTypeList4_00601__Quaternion(reader.ReadValueTypeList4(), reader.ReadVector3ValueTypeList4(), reader.ReadQuaternion());
			}
		}

		protected void UserCode_RpcTeleport__ValueTypeList4_00601__ValueTypeList4_00601__Vector3__Quaternion(ValueTypeList4<Entity> entities, ValueTypeList4<Vector3> positions, Vector3 velocity, Quaternion rotation)
		{
			if (!base.isServer)
			{
				ValueTypeList4<Quaternion> rotations = default(ValueTypeList4<Quaternion>);
				ValueTypeList4<Vector3> velocities = default(ValueTypeList4<Vector3>);
				for (int i = 0; i < entities.Count; i++)
				{
					rotations.Add(rotation);
					velocities.Add(velocity);
				}
				TeleportInternal(in entities, in positions, in rotations, in velocities);
				ClientClearState();
			}
		}

		protected static void InvokeUserCode_RpcTeleport__ValueTypeList4_00601__ValueTypeList4_00601__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcTeleport called on server.");
			}
			else
			{
				((PredictedRigidbodyGroup)obj).UserCode_RpcTeleport__ValueTypeList4_00601__ValueTypeList4_00601__Vector3__Quaternion(reader.ReadValueTypeList4(), reader.ReadVector3ValueTypeList4(), reader.ReadVector3(), reader.ReadQuaternion());
			}
		}

		protected void UserCode_RpcSnap__Vector3__Quaternion(Vector3 pos, Quaternion rot)
		{
			if (!base.isServer)
			{
				Rigidbody rigidbody = base.entity.rigidbody;
				rigidbody.position = pos;
				rigidbody.rotation = PhysicsUtil.Constrain(rot, rigidbody.constraints);
				if (!rigidbody.isKinematic)
				{
					rigidbody.velocity = Vector3.zero;
					rigidbody.angularVelocity = Vector3.zero;
					rigidbody.Sleep();
				}
				base.entity.transform.SetPositionAndRotation(pos, rot);
				ClientClearState();
			}
		}

		protected static void InvokeUserCode_RpcSnap__Vector3__Quaternion(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcSnap called on server.");
			}
			else
			{
				((PredictedRigidbodyGroup)obj).UserCode_RpcSnap__Vector3__Quaternion(reader.ReadVector3(), reader.ReadQuaternion());
			}
		}

		static PredictedRigidbodyGroup()
		{
			RemoteProcedureCalls.RegisterRpc(typeof(PredictedRigidbodyGroup), "System.Void Aggro.Core.PredictedRigidbodyGroup::RpcTeleport(Aggro.Core.ValueTypeList4`1<Aggro.Core.Entity>,Aggro.Core.ValueTypeList4`1<UnityEngine.Vector3>,Aggro.Core.ValueTypeList4`1<UnityEngine.Quaternion>)", InvokeUserCode_RpcTeleport__ValueTypeList4_00601__ValueTypeList4_00601__ValueTypeList4_00601);
			RemoteProcedureCalls.RegisterRpc(typeof(PredictedRigidbodyGroup), "System.Void Aggro.Core.PredictedRigidbodyGroup::RpcTeleport(Aggro.Core.ValueTypeList4`1<Aggro.Core.Entity>,Aggro.Core.ValueTypeList4`1<UnityEngine.Vector3>,UnityEngine.Quaternion)", InvokeUserCode_RpcTeleport__ValueTypeList4_00601__ValueTypeList4_00601__Quaternion);
			RemoteProcedureCalls.RegisterRpc(typeof(PredictedRigidbodyGroup), "System.Void Aggro.Core.PredictedRigidbodyGroup::RpcTeleport(Aggro.Core.ValueTypeList4`1<Aggro.Core.Entity>,Aggro.Core.ValueTypeList4`1<UnityEngine.Vector3>,UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_RpcTeleport__ValueTypeList4_00601__ValueTypeList4_00601__Vector3__Quaternion);
			RemoteProcedureCalls.RegisterRpc(typeof(PredictedRigidbodyGroup), "System.Void Aggro.Core.PredictedRigidbodyGroup::RpcSnap(UnityEngine.Vector3,UnityEngine.Quaternion)", InvokeUserCode_RpcSnap__Vector3__Quaternion);
		}
	}
}
