using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Craft.MeshGen;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public class AeroForcesManager : MonoBehaviour
	{
		public enum StabilisationMode
		{
			None = 0,
			KinematicSim = 1,
			SingleFramePosRot = 2,
			SingleFrameDebtBased = 3,
			TheoreticalDamperScaling = 4
		}

		[BurstCompile]
		private struct CollectDerivativeForcesJob : IJob
		{
			[ReadOnly]
			public NativeArray<IntPtr> inputPtrs;

			[WriteOnly]
			public NativeArray<ForceJacobian> result;

			public unsafe void Execute()
			{
				ForceJacobian value = default(ForceJacobian);
				for (int i = 0; i < inputPtrs.Length; i++)
				{
					value += *(ForceJacobian*)(void*)inputPtrs[i];
				}
				result[0] = value;
			}
		}

		private struct ResultState
		{
			public float3 acceleration;

			public float3 angularAcceleration;

			public float3 velocityDebt;

			public float3 angularVelocityDebt;

			public quaternion finalRotation;

			public float3 finalOffset;

			public float3 finalVelocity;

			public float3 finalAngularVelocity;

			public float3 singleFrameForce;

			public float3 singleFrameTorque;
		}

		[BurstCompile]
		private struct StabiliseForcesJob : IJob
		{
			[ReadOnly]
			public NativeArray<ForceJacobian> forces;

			[ReadOnly]
			public float3 inertiaTensor;

			[ReadOnly]
			public quaternion inertiaTensorRotation;

			[ReadOnly]
			public float dampingFactorLimit;

			[ReadOnly]
			public float deltaTime;

			[WriteOnly]
			public NativeArray<float3> result;

			public void Execute()
			{
				quaternion u;
				quaternion v;
				float3 float5 = UnitySVD.singularValuesDecomposition(math.mul(PhysicsUtils.CalculateInverseInertiaTensorMatrix(in inertiaTensor, in inertiaTensorRotation), forces[0].d_torque_ang) * deltaTime, out u, out v);
				float3 float6 = math.min(math.abs(float5), math.abs(dampingFactorLimit)) * math.sign(float5);
				float3 v2 = math.mul(math.inverse(v), forces[0].torque);
				float3 float7 = math.select(0f, float6 / float5, float5 != 0f);
				v2 *= float7;
				float3 float8 = math.mul(v, v2);
				if (math.any(math.isnan(float8)))
				{
					float8 = forces[0].torque;
				}
				result[0] = forces[0].force;
				result[1] = float8;
			}
		}

		[BurstCompile]
		private struct SimulateForcesJob : IJob
		{
			[ReadOnly]
			public float3 angVel;

			[ReadOnly]
			public NativeArray<ForceJacobian> forces;

			[ReadOnly]
			public float3 inertiaTensor;

			[ReadOnly]
			public quaternion inertiaTensorRotation;

			[ReadOnly]
			public int iterations;

			[ReadOnly]
			public float mass;

			[ReadOnly]
			public float maxAngularVelocity;

			[WriteOnly]
			public NativeArray<ResultState> result;

			[ReadOnly]
			public quaternion startRotation;

			[ReadOnly]
			public float totalDeltaTime;

			[ReadOnly]
			public float3 worldVel;

			public void Execute()
			{
				float invMass = ((mass == 0f) ? 0f : (1f / mass));
				float3x3 inverseIT = PhysicsUtils.CalculateInverseInertiaTensorMatrix(in inertiaTensor, in inertiaTensorRotation);
				float num = 1f / (float)(iterations - 1);
				float dt = totalDeltaTime * num;
				float maxAv = maxAngularVelocity;
				float3 vel = worldVel;
				float3 ang = angVel;
				float3 offset = default(float3);
				quaternion rot = startRotation;
				quaternion invRot = math.inverse(rot);
				float3 float5 = math.rotate(invRot, vel);
				float3 float6 = math.rotate(invRot, ang);
				ForceJacobian forceJacobian = forces[0];
				float3 force = forceJacobian.force;
				float3 torque = forceJacobian.torque;
				float3 float7 = force;
				float3 float8 = torque;
				for (int i = 0; i < iterations - 1; i++)
				{
					SimPhysXFrame(force, torque);
					float3 float9 = math.rotate(invRot, vel);
					float3 float10 = math.rotate(invRot, ang);
					forceJacobian.GetAdjustedValues(float9 - float5, float10 - float6, out force, out torque);
					float7 += math.rotate(rot, force);
					float8 += math.rotate(rot, torque);
				}
				float3 float11 = offset / totalDeltaTime;
				float3 float12 = PhysicsUtils.ComputeSingleFrameAngularVelocity(startRotation, rot, totalDeltaTime);
				float3 velocityDebt = vel - float11;
				float3 angularVelocityDebt = ang - float12;
				float3 float13 = (float11 - worldVel) / totalDeltaTime;
				float3 float14 = (float12 - angVel) / totalDeltaTime;
				float3x3 a = PhysicsUtils.CalculateInertiaTensorMatrix(in inertiaTensor, math.mul(startRotation, inertiaTensorRotation));
				float3 singleFrameForce = float13 * mass;
				float3 singleFrameTorque = math.mul(a, float14);
				result[0] = new ResultState
				{
					velocityDebt = velocityDebt,
					angularVelocityDebt = angularVelocityDebt,
					finalVelocity = vel,
					finalAngularVelocity = ang,
					finalOffset = offset,
					finalRotation = rot,
					acceleration = float13,
					angularAcceleration = float14,
					singleFrameForce = singleFrameForce,
					singleFrameTorque = singleFrameTorque
				};
				void SimPhysXFrame(float3 localForce, float3 localTorque)
				{
					RigidTransform transform = new RigidTransform(rot, offset);
					PhysicsUtils.IntegrateBodyLocal(invMass, in inverseIT, localForce, localTorque, dt, ref vel, ref ang, ref transform, maxAv);
					offset = transform.pos;
					rot = transform.rot;
					invRot = math.inverse(rot);
					if (math.any(math.isnan(vel)) || math.any(math.isnan(ang)))
					{
						throw new NotFiniteNumberException();
					}
				}
			}
		}

		[SerializeField]
		private bool _applyForces = true;

		[SerializeField]
		private Vector3 _debugWind;

		private bool _didIterate;

		private bool _didStabilise;

		private List<IAeroForceProducer> _forceProducers = new List<IAeroForceProducer>();

		[SerializeField]
		private int _iterations;

		[SerializeField]
		private bool _isExtrapolating;

		[SerializeField]
		private StabilisationMode _mode = StabilisationMode.TheoreticalDamperScaling;

		[SerializeField]
		private float _dampingFactorLimit = 0.5f;

		private bool _testRunning;

		private string _testData;

		private double? _testStart;

		private Vector3 _velocityDebt;

		private Vector3 _angularVelocityDebt;

		private Vector3 _scheduledVelocityLocal;

		private Vector3 _scheduledAngularVelocityLocal;

		private Quaternion _scheduledRotation;

		private Quaternion _jobStartRotation;

		private Vector3 _jobStartAngVel;

		private JobHandle? _jobHandle;

		private List<IAeroForceProducer> _queuedProducers = new List<IAeroForceProducer>();

		private Rigidbody _rb;

		private NativeList<IntPtr> _resultPtrs;

		private NativeArray<ResultState> _simResult;

		private NativeArray<ForceJacobian> _totalForces;

		private NativeArray<float3> _stabilisationResult;

		public Vector3 AngularVelocity => _rb.angularVelocity + _angularVelocityDebt;

		public Vector3 Velocity => _rb.linearVelocity + _velocityDebt - _debugWind;

		public float TotalDragForceMagnitude { get; private set; }

		public Vector3 DebugWind
		{
			get
			{
				return _debugWind;
			}
			set
			{
				_debugWind = value;
			}
		}

		public static event Action<AeroForcesManager> OnAdded;

		public Vector3 GetPointVelocity(Vector3 worldPos)
		{
			return _rb.linearVelocity + _velocityDebt + Vector3.Cross(AngularVelocity, worldPos - base.transform.TransformPoint(_rb.centerOfMass)) - _debugWind;
		}

		public void Register(IAeroForceProducer producer)
		{
			_forceProducers.Add(producer);
		}

		public void Unregister(IAeroForceProducer producer)
		{
			_forceProducers.Remove(producer);
			int num = _queuedProducers.IndexOf(producer);
			if (num != -1)
			{
				_queuedProducers[num] = null;
			}
		}

		protected void FixedUpdate()
		{
			if (_isExtrapolating && !_jobHandle.HasValue)
			{
				Quaternion obj = Quaternion.Inverse(_rb.rotation);
				Vector3 vector = obj * Velocity;
				Vector3 vector2 = obj * AngularVelocity;
				_totalForces[0].GetAdjustedValues(vector - _scheduledVelocityLocal, vector2 - _scheduledAngularVelocityLocal, out var force, out var torque);
				_rb.AddRelativeForce(force);
				_rb.AddRelativeTorque(torque);
			}
			else
			{
				CompleteJobs();
			}
		}

		protected void OnDisable()
		{
			StopAllCoroutines();
		}

		protected void OnEnable()
		{
			_rb = GetComponent<Rigidbody>();
			_velocityDebt = Vector3.zero;
			_angularVelocityDebt = Vector3.zero;
			StartCoroutine(UpdateCoroutine());
		}

		protected void Start()
		{
			_resultPtrs = new NativeList<IntPtr>(Allocator.Persistent);
			_totalForces = new NativeArray<ForceJacobian>(1, Allocator.Persistent);
			_simResult = new NativeArray<ResultState>(1, Allocator.Persistent);
			_stabilisationResult = new NativeArray<float3>(2, Allocator.Persistent);
			AeroForcesManager.OnAdded?.Invoke(this);
		}

		protected void OnDestroy()
		{
			_jobHandle?.Complete();
			Extensions.DisposeIfCreated(ref _resultPtrs);
			_totalForces.DisposeIfCreated();
			_simResult.DisposeIfCreated();
			_stabilisationResult.DisposeIfCreated();
		}

		private void CompleteJobs()
		{
			if (!_jobHandle.HasValue)
			{
				return;
			}
			_jobHandle.Value.Complete();
			_jobHandle = null;
			foreach (IAeroForceProducer queuedProducer in _queuedProducers)
			{
				queuedProducer?.OnJobsCompleted();
			}
			if (!_applyForces)
			{
				return;
			}
			if (_mode == StabilisationMode.TheoreticalDamperScaling && _didStabilise)
			{
				ApplyForces(_scheduledRotation * _stabilisationResult[0], _scheduledRotation * _stabilisationResult[1]);
				_angularVelocityDebt = Vector3.zero;
				_velocityDebt = Vector3.zero;
			}
			else if (_mode == StabilisationMode.None || !_didIterate)
			{
				_angularVelocityDebt = Vector3.zero;
				_velocityDebt = Vector3.zero;
				Vector3 vector = _scheduledRotation * _totalForces[0].force;
				Vector3 vector2 = _scheduledRotation * _totalForces[0].torque;
				ApplyForces(vector, vector2);
			}
			else if (_mode == StabilisationMode.KinematicSim)
			{
				ResultState resultState = _simResult[0];
				_angularVelocityDebt = default(Vector3);
				_velocityDebt = default(Vector3);
				_rb.position += (Vector3)resultState.finalOffset;
				_rb.rotation = resultState.finalRotation;
				_rb.isKinematic = true;
				_velocityDebt = default(Vector3);
				_angularVelocityDebt = resultState.finalAngularVelocity;
			}
			else
			{
				if (_mode != StabilisationMode.SingleFramePosRot && _mode != StabilisationMode.SingleFrameDebtBased)
				{
					throw new NotImplementedException();
				}
				ResultState resultState2 = _simResult[0];
				ApplyForces(resultState2.singleFrameForce, resultState2.singleFrameTorque);
				if (_mode != StabilisationMode.SingleFrameDebtBased)
				{
					_velocityDebt = default(Vector3);
					_angularVelocityDebt = default(Vector3);
				}
				else
				{
					ApplyForces(_velocityDebt, _angularVelocityDebt, ForceMode.Acceleration);
					_velocityDebt = resultState2.velocityDebt;
					_angularVelocityDebt = resultState2.angularVelocityDebt;
				}
			}
			if (!_testRunning)
			{
				return;
			}
			if (_testStart.HasValue)
			{
				float num = _jobStartRotation.eulerAngles.x;
				if (num > 180f)
				{
					num -= 360f;
				}
				_testData = $"{num:F10}, {_jobStartAngVel.x:F10}, {_totalForces[0].torque.x:F10}, {Time.fixedTimeAsDouble - _testStart.Value:F10}";
			}
			else
			{
				_testStart = Time.fixedTimeAsDouble;
			}
		}

		private void ApplyForces(float3 force, float3 torque, ForceMode mode = ForceMode.Force)
		{
			MathUtils.RemoveNaN(ref force);
			MathUtils.RemoveNaN(ref torque);
			_rb.AddForce(force, mode);
			_rb.AddTorque(torque, mode);
			TotalDragForceMagnitude = Mathf.Abs(Vector3.Dot(force, Velocity.normalized));
		}

		private unsafe void ScheduleJobs()
		{
			if (_isExtrapolating)
			{
				return;
			}
			_scheduledRotation = _rb.rotation;
			Quaternion quaternion2 = Quaternion.Inverse(_scheduledRotation);
			_scheduledVelocityLocal = quaternion2 * Velocity;
			_scheduledAngularVelocityLocal = quaternion2 * AngularVelocity;
			_jobStartAngVel = AngularVelocity;
			_jobStartRotation = _rb.rotation;
			if (_jobHandle.HasValue && !_jobHandle.Value.IsCompleted)
			{
				Debug.LogError("Scheduling jobs when there is already a jobhandle running");
				return;
			}
			_rb.PublishTransform();
			_resultPtrs.Clear();
			_queuedProducers.Clear();
			JobHandle* ptr = stackalloc JobHandle[_forceProducers.Count];
			int count = 0;
			foreach (IAeroForceProducer forceProducer in _forceProducers)
			{
				if (forceProducer.Enabled)
				{
					var (jobHandle, value) = forceProducer.ScheduleJobs();
					ptr[count++] = jobHandle;
					_resultPtrs.Add(in value);
					_queuedProducers.Add(forceProducer);
				}
			}
			JobHandle dependsOn = JobHandleUnsafeUtility.CombineDependencies(ptr, count);
			dependsOn = new CollectDerivativeForcesJob
			{
				inputPtrs = _resultPtrs.AsArray(),
				result = _totalForces
			}.Schedule(dependsOn);
			if (_mode == StabilisationMode.TheoreticalDamperScaling)
			{
				_didIterate = false;
				_didStabilise = true;
				dependsOn = new StabiliseForcesJob
				{
					deltaTime = Time.fixedDeltaTime,
					dampingFactorLimit = _dampingFactorLimit,
					forces = _totalForces,
					inertiaTensor = _rb.inertiaTensor,
					inertiaTensorRotation = _rb.inertiaTensorRotation,
					result = _stabilisationResult
				}.Schedule(dependsOn);
			}
			else if (_iterations > 0)
			{
				Rigidbody rb = _rb;
				dependsOn = new SimulateForcesJob
				{
					mass = rb.mass,
					inertiaTensor = rb.inertiaTensor,
					inertiaTensorRotation = rb.inertiaTensorRotation,
					startRotation = rb.rotation,
					worldVel = rb.linearVelocity,
					angVel = AngularVelocity,
					maxAngularVelocity = rb.maxAngularVelocity,
					forces = _totalForces,
					result = _simResult,
					totalDeltaTime = Time.fixedDeltaTime,
					iterations = _iterations
				}.Schedule(dependsOn);
				_didIterate = true;
			}
			else
			{
				_didIterate = false;
			}
			JobHandle.ScheduleBatchedJobs();
			_jobHandle = dependsOn;
		}

		private IEnumerator UpdateCoroutine()
		{
			WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
			while (true)
			{
				yield return waitForFixedUpdate;
				try
				{
					ScheduleJobs();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}
	}
}
