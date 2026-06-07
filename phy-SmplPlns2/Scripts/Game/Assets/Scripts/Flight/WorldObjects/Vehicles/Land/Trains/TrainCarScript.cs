using Assets.Scripts.Multiplayer.FlightObjects.Damage;
using Assets.Scripts.Multiplayer.FlightObjects.Damage.Events;
using Dreamteck.Splines;
using FishNet.Serializing;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains
{
	public class TrainCarScript : MonoBehaviour
	{
		private struct PendingStateUpdate
		{
			public Vector3 AngularVelocity { get; private set; }

			public double CurrentTrackSpeed { get; private set; }

			public bool HasPositionState { get; private set; }

			public bool HasTrackState { get; private set; }

			public bool HasVelocityState { get; private set; }

			public Vector3 LinearVelocity { get; private set; }

			public Vector3 Position { get; private set; }

			public Quaternion Rotation { get; private set; }

			public double TrackPosition { get; private set; }

			public void SetPositionState(Vector3 position, Quaternion rotation)
			{
				HasPositionState = true;
				Position = position;
				Rotation = rotation;
			}

			public void SetTrackState(double trackPosition, double currentTrackSpeed)
			{
				HasTrackState = true;
				TrackPosition = trackPosition;
				CurrentTrackSpeed = currentTrackSpeed;
			}

			public void SetVelocityState(Vector3 linearVelocity, Vector3 angularVelocity)
			{
				HasVelocityState = true;
				LinearVelocity = linearVelocity;
				AngularVelocity = angularVelocity;
			}
		}

		public static readonly TrainCarDerailedSynchronizationMethod SyncMethodDerailed = TrainCarDerailedSynchronizationMethod.Method3;

		[SerializeField]
		private Rigidbody _body;

		private double? _chainDerailmentDistance;

		private Collider[] _couplerCollidersFront;

		private Collider[] _couplerCollidersRear;

		[SerializeField]
		private Transform _couplerFront;

		[SerializeField]
		private Transform _couplerFrontJointPosition;

		[SerializeField]
		private Transform _couplerRear;

		[SerializeField]
		private Transform _couplerRearJointPosition;

		private double _currentTrackSpeed;

		private NetworkFlightObjectDamageReceiverScript _damageReceiver;

		private float _derailmentCooldownTime;

		private PendingStateUpdate? _pendingStateUpdate;

		private Transform _transform;

		private Collider[] _wheelCollidersFront;

		private Collider[] _wheelCollidersRear;

		[SerializeField]
		private Transform _wheelsFront;

		[SerializeField]
		private Transform _wheelsRear;

		public TrainCarScript AttachedFrontCar { get; private set; }

		public TrainCarScript AttachedRearCar { get; private set; }

		public Rigidbody Body => _body;

		public ConfigurableJoint CouplerFrontJoint { get; private set; }

		public Transform CouplerFrontJointPosition => _couplerFrontJointPosition;

		public ConfigurableJoint CouplerRearJoint { get; private set; }

		public Transform CouplerRearJointPosition => _couplerRearJointPosition;

		public NetworkFlightObjectDamageReceiverScript DamageReceiver => _damageReceiver;

		public bool Derailed { get; private set; }

		public float DistanceToFrontCar { get; private set; }

		public float DistanceToRearCar { get; private set; }

		[field: SerializeField]
		public double TrackPosition { get; private set; }

		public TrainScript Train { get; private set; }

		public int TrainCarIndex { get; private set; }

		public Transform Transform => _transform;

		public static void Attach(TrainCarScript frontCar, TrainCarScript rearCar)
		{
			frontCar.AttachedRearCar = rearCar;
			rearCar.AttachedFrontCar = frontCar;
			Vector3 anchor = frontCar.Transform.InverseTransformPoint(frontCar.CouplerRearJointPosition.position);
			Vector3 connectedAnchor = rearCar.Transform.InverseTransformPoint(rearCar.CouplerFrontJointPosition.position);
			float distanceToFrontCar = (frontCar.DistanceToRearCar = connectedAnchor.z - anchor.z);
			rearCar.DistanceToFrontCar = distanceToFrontCar;
			Collider[] couplerCollidersRear = frontCar._couplerCollidersRear;
			foreach (Collider collider in couplerCollidersRear)
			{
				Collider[] couplerCollidersFront = rearCar._couplerCollidersFront;
				foreach (Collider collider2 in couplerCollidersFront)
				{
					Physics.IgnoreCollision(collider, collider2);
				}
			}
			bool isOwner = frontCar.Train.NetworkFlightObject.IsOwner;
			bool flag = SyncMethodDerailed == TrainCarDerailedSynchronizationMethod.Method2 || SyncMethodDerailed == TrainCarDerailedSynchronizationMethod.Method3 || SyncMethodDerailed == TrainCarDerailedSynchronizationMethod.Method4;
			if (isOwner || flag)
			{
				ConfigurableJoint couplerFrontJoint = (frontCar.CouplerRearJoint = CreateJoint(frontCar, rearCar.Body, anchor, connectedAnchor));
				rearCar.CouplerFrontJoint = couplerFrontJoint;
			}
		}

		public static void RebuildRearJoint(TrainCarScript frontCar)
		{
			ConfigurableJoint couplerRearJoint = frontCar.CouplerRearJoint;
			if (!(couplerRearJoint == null))
			{
				Rigidbody connectedBody = couplerRearJoint.connectedBody;
				Vector3 anchor = couplerRearJoint.anchor;
				Vector3 connectedAnchor = couplerRearJoint.connectedAnchor;
				Object.Destroy(couplerRearJoint);
				CreateJoint(frontCar, connectedBody, anchor, connectedAnchor);
			}
		}

		public void AssignToTrain(TrainScript train, int trainCarIndex)
		{
			Train = train;
			TrainCarIndex = trainCarIndex;
			if (trainCarIndex == 0)
			{
				TrackPosition = train.TrainDefinition.TrackPosition;
			}
		}

		public void PositionBehindLeadingCar()
		{
			TrainCarScript attachedFrontCar = AttachedFrontCar;
			if (!(this == null) && !(attachedFrontCar == null))
			{
				if (attachedFrontCar.Derailed)
				{
					Transform transform = attachedFrontCar.Transform;
					Vector3 position = transform.position - transform.forward * DistanceToFrontCar;
					Quaternion rotation = transform.rotation;
					_transform.SetPositionAndRotation(position, rotation);
					SetDerailedState(derailed: true);
				}
				else
				{
					float moved;
					double trackPosition = Train.Track.Spline.TravelUnclampedLoop(attachedFrontCar.TrackPosition, DistanceToFrontCar, out moved, Spline.Direction.Backward);
					PositionOnTrack(Train.Track, trackPosition);
				}
			}
		}

		public void PositionOnTrack(TrainTrackScript track, double trackPosition)
		{
			SplineSample splineSample = track.Spline.Evaluate(trackPosition);
			_transform.SetPositionAndRotation(splineSample.position, splineSample.rotation);
			_body.linearVelocity = Vector3.Dot(_body.linearVelocity, splineSample.forward) * splineSample.forward;
			_chainDerailmentDistance = null;
			TrackPosition = trackPosition;
			SetDerailedState(derailed: false);
		}

		public void ReadState(PooledReader reader, TrainCarScript previousCar, in TrainStateSyncData trainSyncData)
		{
			PendingStateUpdate value = default(PendingStateUpdate);
			SetDerailedState(reader.ReadBoolean());
			if (Derailed)
			{
				Vector3 vector = reader.ReadVector3();
				Quaternion quaternion = reader.ReadQuaternion32();
				Vector3 vector2 = reader.ReadVector3();
				Vector3 vector3 = reader.ReadVector3();
				if (_body != null)
				{
					if (SyncMethodDerailed == TrainCarDerailedSynchronizationMethod.Method1)
					{
						float num = FlightSceneScript.Instance.FlightSceneNetwork.PhysicsTime - trainSyncData.PhysicsTimeRemote;
						value.SetPositionState(vector + trainSyncData.FloatingOriginOffset + num * vector2, quaternion * Quaternion.Euler(num * vector3));
						value.SetVelocityState(vector2, vector3);
					}
					else if (SyncMethodDerailed == TrainCarDerailedSynchronizationMethod.Method2)
					{
						if (trainSyncData.PhysicsTimeElapsedRemote - trainSyncData.PhysicsTimeElapsedLocal + 0.0025f > 0f)
						{
							Vector3 vector4 = vector + trainSyncData.FloatingOriginOffset;
							Quaternion quaternion2 = quaternion;
							if ((vector4 - _transform.position).sqrMagnitude > 0.0625f || Mathf.Abs(Quaternion.Dot(quaternion2, _transform.rotation)) < 0.99f)
							{
								value.SetPositionState(vector4, quaternion2);
							}
							value.SetVelocityState(vector2, vector3);
						}
					}
					else if (SyncMethodDerailed == TrainCarDerailedSynchronizationMethod.Method3)
					{
						if (trainSyncData.PhysicsTimeElapsedRemote - trainSyncData.PhysicsTimeElapsedLocal + 0.0025f > 0f)
						{
							Vector3 vector5;
							Quaternion quaternion3;
							if (previousCar != null)
							{
								vector5 = previousCar._transform.TransformPoint(vector);
								quaternion3 = quaternion * previousCar._transform.rotation;
							}
							else
							{
								vector5 = vector + trainSyncData.FloatingOriginOffset;
								quaternion3 = quaternion;
							}
							if ((vector5 - _transform.position).sqrMagnitude > 0.0625f || Mathf.Abs(Quaternion.Dot(quaternion3, _transform.rotation)) < 0.99f)
							{
								value.SetPositionState(vector5, quaternion3);
							}
							value.SetVelocityState(vector2, vector3);
						}
					}
					else if (SyncMethodDerailed == TrainCarDerailedSynchronizationMethod.Method4)
					{
						float num2 = FlightSceneScript.Instance.FlightSceneNetwork.PhysicsTime - trainSyncData.PhysicsTimeRemote;
						Vector3 position;
						Quaternion rotation;
						if (previousCar != null)
						{
							position = previousCar._transform.TransformPoint(vector);
							rotation = quaternion * previousCar._transform.rotation;
						}
						else
						{
							position = vector + trainSyncData.FloatingOriginOffset + num2 * vector2;
							rotation = quaternion * Quaternion.Euler(num2 * vector3);
						}
						value.SetPositionState(position, rotation);
						value.SetVelocityState(vector2, vector3);
					}
				}
			}
			else
			{
				double num3 = reader.ReadDouble();
				double num4 = reader.ReadDouble();
				float num5 = reader.ReadSingle();
				float num6 = FlightSceneScript.Instance.FlightSceneNetwork.PhysicsTime - trainSyncData.PhysicsTimeRemote;
				double num7 = num3 + num4 * (double)num6;
				if (num7 % 2.0 < 0.0)
				{
					num7 += 1.0;
				}
				else if (num7 % 2.0 > 1.0)
				{
					num7 -= 1.0;
				}
				if (num7 < 0.0 || num7 > 1.0)
				{
					Debug.Log($"{num7:F6} = {num3:F6} + ({num4:F6} * {num6:F4})");
				}
				value.SetTrackState(num7, num4);
				if (Train.IsTrackLoaded)
				{
					SplineSample splineSample = Train.Track.Spline.Evaluate(num7);
					value.SetPositionState(splineSample.position, splineSample.rotation);
					value.SetVelocityState(splineSample.forward * num5, Vector3.zero);
				}
			}
			_pendingStateUpdate = value;
			if (!base.isActiveAndEnabled)
			{
				ApplyPendingStateUpdate(isActive: false);
			}
		}

		public void SetDerailedState(bool derailed)
		{
			if (Derailed == derailed)
			{
				return;
			}
			Derailed = derailed;
			_derailmentCooldownTime = (derailed ? 0f : 5f);
			if (derailed && Train?.NetworkFlightObject?.IsOwner == true)
			{
				float num = 0f;
				TrainCarScript attachedRearCar = AttachedRearCar;
				while (attachedRearCar != null)
				{
					num += DistanceToRearCar;
					attachedRearCar._chainDerailmentDistance = num;
					attachedRearCar = attachedRearCar.AttachedRearCar;
				}
			}
			else
			{
				_chainDerailmentDistance = null;
			}
			Train?.UpdateDerailedState();
		}

		public void UpdateDerailedStateOnFixedUpdate()
		{
			ApplyPendingStateUpdate(isActive: true);
		}

		public void UpdateTrackPositionOnFixedUpdate(bool updateRotation)
		{
			if (!Train.IsTrackLoaded)
			{
				return;
			}
			PendingStateUpdate valueOrDefault = _pendingStateUpdate.GetValueOrDefault();
			_pendingStateUpdate = null;
			double num = ((!valueOrDefault.HasTrackState) ? TrackPosition : valueOrDefault.TrackPosition);
			Vector3 position;
			Vector3 lhs;
			if (valueOrDefault.HasPositionState)
			{
				position = valueOrDefault.Position;
				_ = valueOrDefault.Rotation;
				lhs = valueOrDefault.Rotation * Vector3.forward;
			}
			else
			{
				position = _transform.position;
				_ = _transform.rotation;
				lhs = _transform.forward;
			}
			Vector3 lhs2 = ((!valueOrDefault.HasVelocityState) ? _body.linearVelocity : valueOrDefault.LinearVelocity);
			SplineComputer spline = Train.Track.Spline;
			SplineSample splineSample = spline.Evaluate(num);
			Vector3 position2 = splineSample.position;
			Vector3 lhs3 = position - position2;
			float num2 = Vector3.Dot(lhs3, splineSample.forward);
			float num3 = Mathf.Abs(num2);
			Spline.Direction direction = ((num2 >= 0f) ? Spline.Direction.Forward : Spline.Direction.Backward);
			double num4 = num;
			float moved;
			double num5 = spline.TravelUnclampedLoop(num, num3, out moved, direction);
			double num6 = num5 - num4;
			if (direction == Spline.Direction.Forward && num6 < 0.0)
			{
				num6 += 1.0;
			}
			else if (direction == Spline.Direction.Backward && num6 > 1.0)
			{
				num6 -= 1.0;
			}
			_currentTrackSpeed = num6 / (double)Time.deltaTime;
			TrackPosition = num5;
			SplineSample splineSample2 = spline.Evaluate(num5);
			if (_chainDerailmentDistance.HasValue)
			{
				_chainDerailmentDistance -= num3;
			}
			_derailmentCooldownTime -= Time.deltaTime;
			if (_derailmentCooldownTime <= 0f && Train.NetworkFlightObject.IsOwner)
			{
				if (_chainDerailmentDistance.HasValue && _chainDerailmentDistance < 0.0)
				{
					SetDerailedState(derailed: true);
					if (TrainScript.DebugLogsEnabled)
					{
						Debug.Log($"{Time.frameCount}: Train Chain Derailment ({TrainCarIndex}): {_chainDerailmentDistance:F4}");
					}
					return;
				}
				Vector3 vector = new Vector3(Mathf.Abs(Vector3.Dot(lhs3, splineSample.right)), Mathf.Abs(Vector3.Dot(lhs3, splineSample.up)), Mathf.Abs(Vector3.Dot(lhs3, splineSample.forward)));
				if (vector.x > Train.DerailmentPositionThreshold * (splineSample2.size + 1f) || vector.y > Train.DerailmentPositionThreshold * (splineSample2.size + 1f))
				{
					SetDerailedState(derailed: true);
					if (TrainScript.DebugLogsEnabled)
					{
						Debug.Log($"{Time.frameCount}: Train Position Error ({TrainCarIndex}): {vector:F4}");
					}
					return;
				}
				Vector3 vector2 = new Vector3(Mathf.Abs(Vector3.Dot(lhs, splineSample.up)), Mathf.Abs(Vector3.Dot(lhs, splineSample.right)), Mathf.Abs(Vector3.Dot(lhs, splineSample.forward)));
				if (vector2.x > Train.DerailmentOrientationAngleXThreshold * (splineSample2.size + 1f) || vector2.y > Train.DerailmentOrientationAngleYThreshold * (splineSample2.size + 1f))
				{
					SetDerailedState(derailed: true);
					if (TrainScript.DebugLogsEnabled)
					{
						Debug.Log($"{Time.frameCount}: Train Orientation Error ({TrainCarIndex}): {vector2:F4}");
					}
					return;
				}
			}
			if (updateRotation)
			{
				_body.MovePosition(splineSample2.position);
				_body.MoveRotation(splineSample2.rotation);
			}
			else
			{
				_body.MovePosition(splineSample2.position);
			}
			_body.linearVelocity = Vector3.Dot(lhs2, splineSample2.forward) * splineSample2.forward;
			_body.angularVelocity = Vector3.zero;
		}

		public void WriteState(PooledWriter writer, TrainCarScript previousCar)
		{
			writer.WriteBoolean(Derailed);
			if (Derailed)
			{
				if ((SyncMethodDerailed == TrainCarDerailedSynchronizationMethod.Method3 || SyncMethodDerailed == TrainCarDerailedSynchronizationMethod.Method4) && previousCar != null)
				{
					Vector3 value = previousCar._transform.InverseTransformPoint(_transform.position);
					Quaternion value2 = previousCar._transform.rotation.ToRotation(_transform.rotation);
					writer.WriteVector3(value);
					writer.WriteQuaternion32(value2);
				}
				else
				{
					writer.WriteVector3(_transform.position);
					writer.WriteQuaternion32(_transform.rotation);
				}
				writer.WriteVector3(_body.linearVelocity);
				writer.WriteVector3(_body.angularVelocity);
			}
			else
			{
				writer.WriteDouble(TrackPosition);
				writer.WriteDouble(_currentTrackSpeed);
				writer.WriteSingle(_body.linearVelocity.magnitude);
			}
		}

		protected virtual void Awake()
		{
			_transform = base.transform;
			_wheelCollidersFront = ((_wheelsFront != null) ? _wheelsFront.GetComponentsInChildren<Collider>(includeInactive: true) : new Collider[0]);
			_wheelCollidersRear = ((_wheelsRear != null) ? _wheelsRear.GetComponentsInChildren<Collider>(includeInactive: true) : new Collider[0]);
			_couplerCollidersFront = ((_couplerFront != null) ? _couplerFront.GetComponentsInChildren<Collider>(includeInactive: true) : new Collider[0]);
			_couplerCollidersRear = ((_couplerRear != null) ? _couplerRear.GetComponentsInChildren<Collider>(includeInactive: true) : new Collider[0]);
			Collider[] wheelCollidersFront = _wheelCollidersFront;
			for (int i = 0; i < wheelCollidersFront.Length; i++)
			{
				wheelCollidersFront[i].hasModifiableContacts = true;
			}
			wheelCollidersFront = _wheelCollidersRear;
			for (int i = 0; i < wheelCollidersFront.Length; i++)
			{
				wheelCollidersFront[i].hasModifiableContacts = true;
			}
			ConfigureDamageHandling();
			SetDerailedState(derailed: true);
		}

		private static ConfigurableJoint CreateJoint(TrainCarScript trainCar, Rigidbody connectedBody, Vector3 anchor, Vector3 connectedAnchor)
		{
			ConfigurableJoint configurableJoint = trainCar.gameObject.AddComponent<ConfigurableJoint>();
			configurableJoint.connectedBody = connectedBody;
			configurableJoint.autoConfigureConnectedAnchor = false;
			configurableJoint.anchor = anchor;
			configurableJoint.connectedAnchor = connectedAnchor;
			configurableJoint.projectionMode = JointProjectionMode.PositionAndRotation;
			configurableJoint.projectionDistance = 0.5f;
			configurableJoint.projectionAngle = 3f;
			configurableJoint.xMotion = ConfigurableJointMotion.Locked;
			configurableJoint.yMotion = ConfigurableJointMotion.Locked;
			configurableJoint.zMotion = ConfigurableJointMotion.Locked;
			configurableJoint.angularXMotion = ConfigurableJointMotion.Limited;
			configurableJoint.angularYMotion = ConfigurableJointMotion.Limited;
			configurableJoint.angularZMotion = ConfigurableJointMotion.Limited;
			configurableJoint.lowAngularXLimit = new SoftJointLimit
			{
				limit = -15f
			};
			configurableJoint.highAngularXLimit = new SoftJointLimit
			{
				limit = 15f
			};
			configurableJoint.angularYLimit = new SoftJointLimit
			{
				limit = 25f
			};
			configurableJoint.angularZLimit = new SoftJointLimit
			{
				limit = 10f
			};
			return configurableJoint;
		}

		private void ApplyPendingStateUpdate(bool isActive)
		{
			if (!_pendingStateUpdate.HasValue)
			{
				return;
			}
			PendingStateUpdate value = _pendingStateUpdate.Value;
			_pendingStateUpdate = null;
			if (value.HasPositionState)
			{
				if (isActive)
				{
					_body.MovePosition(value.Position);
					_body.MoveRotation(value.Rotation);
				}
				else
				{
					_transform.SetPositionAndRotation(value.Position, value.Rotation);
				}
			}
			if (value.HasVelocityState)
			{
				_body.linearVelocity = value.LinearVelocity;
				_body.angularVelocity = value.AngularVelocity;
			}
			if (value.HasTrackState)
			{
				TrackPosition = value.TrackPosition;
				_currentTrackSpeed = value.CurrentTrackSpeed;
			}
		}

		private void ConfigureDamageHandling()
		{
			_damageReceiver = GetComponent<NetworkFlightObjectDamageReceiverScript>();
			_damageReceiver.DamageLevelChanged += OnDamageLevelChanged;
			_damageReceiver.SetDamageLevels(new DamageLevel[1]
			{
				new DamageLevel(1000, "Derailment")
			});
			_damageReceiver.DamageHandlers.CollisionDamage.Configure(5f, 50f);
			_damageReceiver.DamageHandlers.ExplosionDamage.Configure(10f, 50f);
			_damageReceiver.DamageHandlers.StandardBulletsDamage.Configure(1f, 10f);
			_damageReceiver.DamageHandlers.CannonProjectileDamage.Configure(1f, 50f);
		}

		[ContextMenu("Derail")]
		private void Derail()
		{
			SetDerailedState(derailed: true);
		}

		private void OnDamageLevelChanged(object sender, DamageLevelEventArgs e)
		{
			if (Train.NetworkFlightObject.IsOwner && e.NewLevel.Level > e.PreviousLevel.Level && e.NewLevel.Level == 1)
			{
				SetDerailedState(derailed: true);
				if (TrainScript.DebugLogsEnabled)
				{
					Debug.Log($"{Time.frameCount}: Train Derailment Damage ({TrainCarIndex}): {_damageReceiver.Damage.Damage}");
				}
			}
		}
	}
}
