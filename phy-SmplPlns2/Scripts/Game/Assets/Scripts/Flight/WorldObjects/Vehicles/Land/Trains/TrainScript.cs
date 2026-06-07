using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains.Attributes;
using Assets.Scripts.Multiplayer.FlightObjects;
using Assets.Scripts.Multiplayer.FlightObjects.Damage;
using FishNet.Serializing;
using Jundroo.Common.Utils;
using Unity.Collections;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Trains
{
	public class TrainScript : NetworkFlightObjectComponent
	{
		private static class Profile
		{
			public static readonly ProfilerMarker PhysicsContactModificationCallback = new ProfilerMarker("TrainScript.PhysicsContactModificationCallback");
		}

		private AudioSource _audio;

		private NetworkFlightObjectDamageScript _damageScript;

		[SerializeField]
		private bool _deactivateEngineOnDerailment;

		[SerializeField]
		private float _derailmentOrientationAngleXThreshold;

		[SerializeField]
		private float _derailmentOrientationAngleYThreshold;

		[SerializeField]
		private float _derailmentPositionThreshold;

		[SerializeField]
		private TrainCarScript _locomotive;

		private float _physicsTimeElapsedLocal;

		private float _physicsTimeRemoteLastUpdate;

		[SerializeField]
		private float _targetSpeed;

		private List<TrainCarScript> _tempTrainCarList = new List<TrainCarScript>();

		private float _totalMass;

		[SerializeField]
		private TrainTrackScript _track;

		[SerializeField]
		private List<TrainCarScript> _trainCars;

		private Dictionary<int, TrainCarScript> _trainCarsByBodyId;

		public static bool DebugLogsEnabled { get; private set; }

		public float DerailmentOrientationAngleXThreshold => _derailmentOrientationAngleXThreshold;

		public float DerailmentOrientationAngleYThreshold => _derailmentOrientationAngleYThreshold;

		public float DerailmentPositionThreshold => _derailmentPositionThreshold;

		public bool IsDerailed { get; private set; }

		public bool IsTrackLoaded { get; private set; }

		public TrainCarScript Locomotive => _locomotive;

		public float TargetSpeed => _targetSpeed;

		public TrainTrackScript Track => _track;

		public IReadOnlyList<TrainCarScript> TrainCars => _trainCars;

		public TrainDefinition TrainDefinition { get; private set; }

		public override void Initialize(PooledReader spawnDataReader, PooledReader stateDataReader)
		{
			base.Initialize(spawnDataReader, stateDataReader);
			TrainDefinition trainDefinition = (TrainDefinition = TrainDefinition.NetworkDeserialize(spawnDataReader));
			_targetSpeed = trainDefinition.TargetSpeed;
			_derailmentPositionThreshold = trainDefinition.DerailmentPositionThreshold;
			_derailmentOrientationAngleXThreshold = Mathf.Cos((90f - trainDefinition.DerailmentOrientationAngleXThreshold) * (MathF.PI / 180f));
			_derailmentOrientationAngleYThreshold = Mathf.Cos((90f - trainDefinition.DerailmentOrientationAngleYThreshold) * (MathF.PI / 180f));
			int count = trainDefinition.TrainCars.Count;
			_trainCars = new List<TrainCarScript>(count + 1);
			InitializeTrainCar(_locomotive);
			_locomotive.Body.mass *= 0.01f;
			_totalMass = _locomotive.Body.mass;
			TrainCarScript trainCarScript = _locomotive;
			for (int i = 0; i < count; i++)
			{
				TrainCarType value = trainDefinition.TrainCars[i];
				string text = EnumUtility<TrainCarType>.GetAttribute<PrefabPathAttribute>(value)?.PrefabPath ?? value.ToString();
				string path = "Flight/WorldObjects/Vehicles/Land/Trains/TrainCars/" + text;
				TrainCarScript trainCarScript2 = Game.Instance.ResourceLoader.InstantiatePrefab<TrainCarScript>(path);
				InitializeTrainCar(trainCarScript2);
				trainCarScript2.Body.mass *= 0.01f;
				_totalMass += trainCarScript2.Body.mass;
				Vector3 vector = trainCarScript2.Transform.InverseTransformPoint(trainCarScript2.CouplerFrontJointPosition.position);
				Vector3 vector2 = trainCarScript.Transform.InverseTransformPoint(trainCarScript.CouplerRearJointPosition.position);
				Vector3 position = trainCarScript.Transform.TransformPoint(vector2 - vector);
				trainCarScript2.Transform.SetPositionAndRotation(position, trainCarScript.Transform.rotation);
				TrainCarScript.Attach(trainCarScript, trainCarScript2);
				trainCarScript = trainCarScript2;
			}
			TrainManagerScript.EnqueueAction(delegate(TrainManagerScript x)
			{
				x.RegisterTrain(this);
			});
			UpdateDerailedState();
			Physics.ContactModifyEvent += PhysicsContactModificationCallback;
		}

		public override void OnServerObservationStateChanged(bool serverIsObserver)
		{
			foreach (TrainCarScript trainCar in _trainCars)
			{
				trainCar.gameObject.SetActive(serverIsObserver);
			}
			if (serverIsObserver)
			{
				Span<Quaternion> span = stackalloc Quaternion[_trainCars.Count];
				for (int i = 0; i < _trainCars.Count; i++)
				{
					Transform transform = _trainCars[i].transform;
					span[i] = transform.rotation;
					transform.rotation = Quaternion.identity;
				}
				for (int j = 0; j < _trainCars.Count; j++)
				{
					TrainCarScript.RebuildRearJoint(_trainCars[j]);
				}
				for (int k = 0; k < _trainCars.Count; k++)
				{
					_trainCars[k].transform.rotation = span[k];
				}
			}
		}

		public override void ReadState(PooledReader reader)
		{
			base.ReadState(reader);
			Vector3 floatingOriginOffset = reader.ReadVector3() - GameWorld.Instance.FloatingOriginOffset;
			float num = reader.ReadSingle();
			float physicsTimeElapsedRemote = num - _physicsTimeRemoteLastUpdate;
			if (num < _physicsTimeRemoteLastUpdate)
			{
				return;
			}
			TrainStateSyncData trainSyncData = new TrainStateSyncData(floatingOriginOffset, num, physicsTimeElapsedRemote, _physicsTimeElapsedLocal);
			_physicsTimeRemoteLastUpdate = num;
			_physicsTimeElapsedLocal = 0f;
			if (TrainCarScript.SyncMethodDerailed == TrainCarDerailedSynchronizationMethod.Method3 || TrainCarScript.SyncMethodDerailed == TrainCarDerailedSynchronizationMethod.Method4)
			{
				byte b = reader.ReadUInt8Unpacked();
				if (b != _trainCars.Count)
				{
					Debug.LogError("Unable to sync train. Unexpected number of train cars.");
					return;
				}
				TrainCarScript trainCarScript = null;
				for (int i = 0; i < b; i++)
				{
					int index = reader.ReadUInt8Unpacked();
					TrainCarScript trainCarScript2 = _trainCars[index];
					trainCarScript2.ReadState(reader, trainCarScript, in trainSyncData);
					if (!trainCarScript2.Derailed || (TrainCarScript.SyncMethodDerailed == TrainCarDerailedSynchronizationMethod.Method4 && trainCarScript == null))
					{
						trainCarScript = trainCarScript2;
					}
				}
				return;
			}
			foreach (TrainCarScript trainCar in _trainCars)
			{
				if (trainCar != null)
				{
					trainCar.ReadState(reader, null, in trainSyncData);
				}
			}
		}

		public void SetTrack(TrainTrackScript track)
		{
			_track = track;
			IsTrackLoaded = track != null;
			if (IsTrackLoaded && _locomotive != null)
			{
				PositionTrainOnTrack(_locomotive.TrackPosition);
			}
		}

		public void UpdateDerailedState()
		{
			bool flag = (TrainCars?.Count ?? 0) == 0;
			if (TrainCars != null)
			{
				foreach (TrainCarScript trainCar in TrainCars)
				{
					if (trainCar.Derailed)
					{
						flag = true;
						break;
					}
				}
			}
			if (IsDerailed == flag)
			{
				return;
			}
			IsDerailed = flag;
			if (base.IsOwner)
			{
				if (flag)
				{
					base.NetworkFlightObject.RegisterResettableObject(base.name, 120f, null);
				}
				else
				{
					base.NetworkFlightObject.UnregisterResettableObject();
				}
			}
		}

		public override void WriteState(PooledWriter writer)
		{
			base.WriteState(writer);
			writer.WriteVector3(GameWorld.Instance.FloatingOriginOffset);
			writer.WriteSingle(FlightSceneScript.Instance.FlightSceneNetwork.PhysicsTime);
			if (TrainCarScript.SyncMethodDerailed == TrainCarDerailedSynchronizationMethod.Method3 || TrainCarScript.SyncMethodDerailed == TrainCarDerailedSynchronizationMethod.Method4)
			{
				List<TrainCarScript> tempTrainCarList = _tempTrainCarList;
				tempTrainCarList.Clear();
				for (int i = 0; i < _trainCars.Count; i++)
				{
					TrainCarScript trainCarScript = _trainCars[i];
					bool derailed = trainCarScript.Derailed;
					if (tempTrainCarList.Count == 0)
					{
						if (!derailed)
						{
							tempTrainCarList.Add(trainCarScript);
							for (int num = i - 1; num >= 0; num--)
							{
								tempTrainCarList.Add(_trainCars[num]);
							}
						}
					}
					else
					{
						tempTrainCarList.Add(trainCarScript);
					}
				}
				List<TrainCarScript> list = ((tempTrainCarList.Count == 0) ? _trainCars : tempTrainCarList);
				TrainCarScript trainCarScript2 = null;
				writer.WriteUInt8Unpacked((byte)list.Count);
				for (int j = 0; j < list.Count; j++)
				{
					TrainCarScript trainCarScript3 = list[j];
					writer.WriteUInt8Unpacked((byte)trainCarScript3.TrainCarIndex);
					trainCarScript3.WriteState(writer, trainCarScript2);
					if (!trainCarScript3.Derailed || (TrainCarScript.SyncMethodDerailed == TrainCarDerailedSynchronizationMethod.Method4 && trainCarScript2 == null))
					{
						trainCarScript2 = trainCarScript3;
					}
				}
				tempTrainCarList.Clear();
				return;
			}
			foreach (TrainCarScript trainCar in _trainCars)
			{
				if (trainCar != null)
				{
					trainCar.WriteState(writer, null);
				}
			}
		}

		protected virtual void Awake()
		{
			_locomotive = GetComponent<TrainCarScript>();
			_damageScript = GetComponent<NetworkFlightObjectDamageScript>();
			_trainCarsByBodyId = new Dictionary<int, TrainCarScript>();
		}

		protected virtual void FixedUpdate()
		{
			_physicsTimeElapsedLocal += Time.deltaTime;
			int num = 0;
			for (int i = 0; i < _trainCars.Count; i++)
			{
				TrainCarScript trainCarScript = _trainCars[i];
				if (trainCarScript.Derailed)
				{
					num++;
					trainCarScript.UpdateDerailedStateOnFixedUpdate();
				}
				else
				{
					trainCarScript.UpdateTrackPositionOnFixedUpdate(updateRotation: true);
				}
			}
			if (_audio == null)
			{
				_audio = GetComponent<AudioSource>();
			}
			if (_locomotive.Derailed)
			{
				if (_audio.isPlaying)
				{
					_audio.Stop();
				}
			}
			else if ((num <= 0 || !_deactivateEngineOnDerailment) && IsTrackLoaded)
			{
				if (!_audio.isPlaying)
				{
					_audio.Play();
				}
				float num2 = Vector3.Dot(_locomotive.Body.linearVelocity, _locomotive.Transform.forward);
				float num3 = (_targetSpeed - num2) / 1f;
				float num4 = (float)(_trainCars.Count - 1 - num) / ((float)_trainCars.Count - 1f);
				float num5 = _totalMass * num3 * num4;
				_locomotive.Body.AddForceAtPosition(num5 * _locomotive.Transform.forward, _locomotive.Transform.position, ForceMode.Force);
			}
		}

		protected virtual void OnDestroy()
		{
			Physics.ContactModifyEvent -= PhysicsContactModificationCallback;
			TrainManagerScript instance = TrainManagerScript.Instance;
			if (instance != null)
			{
				instance.UnregisterTrain(this);
			}
			foreach (TrainCarScript trainCar in TrainCars)
			{
				if (!(trainCar == null))
				{
					UnityEngine.Object.Destroy(trainCar.gameObject);
				}
			}
		}

		private bool IgnoreCollisionDamageCallback(Collision collision)
		{
			return _track?.ColliderIds?.Contains(collision.collider.GetInstanceID()) == true;
		}

		private void InitializeTrainCar(TrainCarScript trainCar)
		{
			if (_trainCars.Count >= 255)
			{
				throw new InvalidOperationException($"Too many train cars. ({_trainCars.Count})");
			}
			_trainCars.Add(trainCar);
			_trainCarsByBodyId.Add(trainCar.Body.GetInstanceID(), trainCar);
			trainCar.transform.SetParent(FlightSceneScript.Instance.transform, worldPositionStays: false);
			trainCar.AssignToTrain(this, _trainCars.Count - 1);
			trainCar.DamageReceiver.Initialize((byte)trainCar.TrainCarIndex, _damageScript, IgnoreCollisionDamageCallback);
		}

		private void PhysicsContactModificationCallback(PhysicsScene scene, NativeArray<ModifiableContactPair> contactPairs)
		{
			using (Profile.PhysicsContactModificationCallback.Auto())
			{
				HashSet<int> hashSet = _track?.ColliderIds;
				if (hashSet == null)
				{
					return;
				}
				for (int i = 0; i < contactPairs.Length; i++)
				{
					ModifiableContactPair modifiableContactPair = contactPairs[i];
					TrainCarScript value = null;
					bool flag = false;
					if (modifiableContactPair.bodyInstanceID != 0 && _trainCarsByBodyId.TryGetValue(modifiableContactPair.bodyInstanceID, out value))
					{
						if (modifiableContactPair.otherColliderInstanceID != 0 && hashSet.Contains(modifiableContactPair.otherColliderInstanceID))
						{
							flag = true;
						}
					}
					else
					{
						if (modifiableContactPair.otherBodyInstanceID == 0 || !_trainCarsByBodyId.TryGetValue(modifiableContactPair.otherBodyInstanceID, out value))
						{
							continue;
						}
						if (modifiableContactPair.colliderInstanceID != 0 && hashSet.Contains(modifiableContactPair.colliderInstanceID))
						{
							flag = true;
						}
					}
					float num = ((flag && !value.Derailed) ? 0f : 0.6f);
					for (int j = 0; j < modifiableContactPair.contactCount; j++)
					{
						if (flag && (double)modifiableContactPair.GetNormal(j).y < 0.8)
						{
							modifiableContactPair.IgnoreContact(j);
							continue;
						}
						modifiableContactPair.SetDynamicFriction(j, num);
						modifiableContactPair.SetStaticFriction(j, num);
					}
				}
			}
		}

		private void PositionTrainOnTrack(double trackPosition)
		{
			for (int i = 0; i < _trainCars.Count; i++)
			{
				if (i == 0)
				{
					_trainCars[i].PositionOnTrack(_track, trackPosition);
				}
				else
				{
					_trainCars[i].PositionBehindLeadingCar();
				}
			}
		}

		[ContextMenu("Reposition On Track")]
		private void RepositionTrainOnTrack()
		{
			PositionTrainOnTrack(_locomotive.TrackPosition);
			for (int i = 0; i < _trainCars.Count; i++)
			{
				_trainCars[i].DamageReceiver.HealDamage(null, base.NetworkFlightObject.OwnerId);
			}
		}
	}
}
