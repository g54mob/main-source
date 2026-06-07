using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using Assets.Scripts.Craft.Wings.Runtime;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Wings.Physics
{
	[Serializable]
	public class WingPhysicsManager : IAeroForceProducer
	{
		public struct DebugData
		{
			public float3 dragForce;

			public float3 forcePos;

			public float3 freeStreamDir;

			public float3 liftForce;

			public float freeStreamSpeedSq;

			public float segmentWidth;
		}

		[BurstCompile]
		private struct CopyDebugData : IJobFor
		{
			[ReadOnly]
			public NativeArray<SliceAeroData> aero;

			public float3 deltaA;

			public float3 deltaV;

			[WriteOnly]
			public NativeArray<DebugData> dest;

			[ReadOnly]
			public NativeArray<ForceJacobian> output;

			[ReadOnly]
			public NativeArray<SliceData> slices;

			public void Execute(int i)
			{
				output[i].GetAdjustedValues(deltaV + math.cross(slices[i].quarterChordPos, deltaA), deltaA, out var force, out var _);
				float3 freeStreamDirection = aero[i].freeStreamDirection;
				float3 float5 = math.project(force, freeStreamDirection);
				float3 b = force - float5;
				float3x3 airfoilBasis = slices[i].AirfoilBasis;
				dest[i] = new DebugData
				{
					liftForce = math.mul(airfoilBasis, b),
					dragForce = math.mul(airfoilBasis, float5),
					forcePos = slices[i].quarterChordPos,
					freeStreamDir = math.mul(airfoilBasis, freeStreamDirection),
					freeStreamSpeedSq = aero[i].freeStreamSpeed * aero[i].freeStreamSpeed,
					segmentWidth = slices[i].spanWidth
				};
			}
		}

		private JobHandle? _activeJobs;

		private NativeArray<SliceAeroData> _aeroData;

		private AeroForcesManager _aeroManager;

		private NativeArray<ControlSurfaceRuntimeWrapper> _controlSurfaces;

		[SerializeField]
		private bool _debug;

		private NativeArray<DebugData> _debugData;

		[SerializeField]
		private float _debugGizmosScale = 1f;

		private bool _debugDataValid;

		private string[] _debugInfo;

		private bool _drawingGizmos;

		private bool _initialised;

		private WingInputData _input;

		private WingInputManager _inputManager;

		private List<IntPtr> _mallocPtrs;

		private NativeArray<ForceJacobian> _output;

		private NativeArray<SlicePolar> _polars;

		private Rigidbody _rb;

		private MonoBehaviour _script;

		private NativeArray<ForceJacobian> _sliceOutput;

		private NativeArray<SliceData> _slices;

		private NativeArray<WingInputData> _wingInputArray;

		private LiftingLineSolver _solver;

		[SerializeField]
		private float3 _testDerivativeAng;

		[SerializeField]
		private float3 _testDerivativeVel;

		private Transform _wingTransform;

		public static bool UseSpanwiseSolver { get; set; } = true;

		public static float ViscousDragDueToLiftMultiplier { get; set; }

		public bool DebugEnable
		{
			get
			{
				return _debug;
			}
			set
			{
				_debug = value;
			}
		}

		public bool DrawingGizmos
		{
			get
			{
				return _drawingGizmos;
			}
			set
			{
				_drawingGizmos = value;
			}
		}

		public bool Enabled
		{
			get
			{
				if (_initialised && _rb != null)
				{
					return _script.isActiveAndEnabled;
				}
				return false;
			}
		}

		public float ForceScale { get; set; } = 1f;

		public float LiftScale { get; set; } = 1f;

		public float ZeroLiftDragScale { get; set; } = 1f;

		public float ViscousDragScale { get; set; } = 1f;

		public Rigidbody Rigidbody
		{
			get
			{
				return _rb;
			}
			set
			{
				if (!(_rb == value))
				{
					_rb = value;
					DecoupleFromAeroManager();
					_aeroManager = _rb.GetComponent<AeroForcesManager>();
					if (_aeroManager == null)
					{
						_aeroManager = _rb.gameObject.AddComponent<AeroForcesManager>();
					}
					_aeroManager.Register(this);
				}
			}
		}

		public Func<Vector3> WindVectorGetter { get; set; }

		public float WorldOriginAltitude { get; set; }

		public NativeArray<SliceData> SliceData => _slices;

		public NativeArray<SliceAeroData> SliceAeroData => _aeroData;

		public NativeArray<SlicePolar> SlicePolars => _polars;

		public LiftingLineSolver Solver
		{
			get
			{
				if (!UseSpanwiseSolver)
				{
					return null;
				}
				return _solver;
			}
		}

		public float WaveDragMultiplier { get; set; } = 1f;

		public NativeArray<WingInputData> WingInputData => _wingInputArray;

		public WingPhysicsManager(WingRuntimeOutput runtimeOutput, MonoBehaviour script, WingInputManager inputManager, Rigidbody rigidBody)
			: this(script, runtimeOutput.PhysicsSlices, runtimeOutput.MallocPtrs, runtimeOutput.ControlSurfaces, inputManager.ControlSurfaceRuntimeData, inputManager, rigidBody)
		{
		}

		public WingPhysicsManager(MonoBehaviour script, NativeArray<SliceData> slices, List<IntPtr> mallocPtrs, ControlSurface[] controlSurfaces, IControlSurfaceRuntimeData[] csData, WingInputManager inputManager, Rigidbody rigidbody)
		{
			StandardPhysicsFunctions.FlapPhysics.EnsureInit();
			_solver = new LiftingLineSolver(slices.Length);
			_script = script;
			_wingTransform = script.transform;
			_inputManager = inputManager;
			_rb = rigidbody;
			_initialised = true;
			_mallocPtrs = mallocPtrs;
			_slices = slices;
			_polars = new NativeArray<SlicePolar>(slices.Length, Allocator.Persistent);
			_aeroData = new NativeArray<SliceAeroData>(slices.Length, Allocator.Persistent);
			_sliceOutput = new NativeArray<ForceJacobian>(slices.Length, Allocator.Persistent);
			_output = new NativeArray<ForceJacobian>(1, Allocator.Persistent);
			_wingInputArray = new NativeArray<WingInputData>(1, Allocator.Persistent);
			_debugData = new NativeArray<DebugData>(slices.Length, Allocator.Persistent);
			_controlSurfaces = new NativeArray<ControlSurfaceRuntimeWrapper>(csData.Length, Allocator.Persistent);
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < csData.Length; i++)
			{
				ControlSurface controlSurface = controlSurfaces[i];
				IControlSurfaceRuntimeData controlSurfaceRuntimeData = csData[i];
				int num3 = -1;
				int num4 = -1;
				float firstSliceCoverage = 0f;
				float lastSliceCoverage = 0f;
				for (int j = 0; j < slices.Length; j++)
				{
					SliceData sliceData = slices[j];
					float num5 = sliceData.spanPosition - sliceData.spanWidth * 0.5f;
					float num6 = sliceData.spanPosition + sliceData.spanWidth * 0.5f;
					if (num3 == -1)
					{
						if (controlSurface.Range.x <= num6)
						{
							num3 = j;
							if (controlSurface.Range.y <= num6)
							{
								num4 = 1;
								firstSliceCoverage = (lastSliceCoverage = (controlSurface.Range.y - controlSurface.Range.x) / sliceData.spanWidth);
								break;
							}
							firstSliceCoverage = (num6 - controlSurface.Range.x) / sliceData.spanWidth;
						}
					}
					else if (controlSurface.Range.y <= num6)
					{
						num4 = j - num3 + 1;
						lastSliceCoverage = (controlSurface.Range.y - num5) / sliceData.spanWidth;
						break;
					}
				}
				if (num4 == -1)
				{
					num4 = slices.Length - num3;
					lastSliceCoverage = 1f;
				}
				if (num3 == -1 || num4 == -1)
				{
					Debug.LogError($"Control surface [{i}] {controlSurface} is out of range of the wing physics slices and will not affect physics");
					num3 = 0;
					num4 = 0;
				}
				_controlSurfaces[i] = ControlSurfaceRuntimeWrapper.Create(controlSurfaceRuntimeData, mallocPtrs, num3, num4, num, controlSurfaceRuntimeData.InputCount, num2, controlSurface.MeshCount, firstSliceCoverage, lastSliceCoverage);
				num += controlSurfaceRuntimeData.InputCount;
				num2 += controlSurface.MeshCount;
			}
			_aeroManager = _rb.GetComponent<AeroForcesManager>();
			if (_aeroManager == null)
			{
				_aeroManager = _rb.gameObject.AddComponent<AeroForcesManager>();
			}
			_aeroManager.Register(this);
		}

		public void OnDestroy()
		{
			if (_aeroManager != null)
			{
				_aeroManager.Unregister(this);
				_aeroManager = null;
			}
			Cleanup();
		}

		public NativeArray<DebugData>? GetDebugData()
		{
			if (_debugDataValid)
			{
				return _debugData;
			}
			return null;
		}

		public void OnDrawGizmos()
		{
			_drawingGizmos = true;
			if (_initialised && _debugData.IsCreated)
			{
				for (int i = 0; i < _debugData.Length; i++)
				{
					DebugData debugData = _debugData[i];
					Vector3 vector = _wingTransform.TransformPoint(debugData.forcePos);
					float num = _debugGizmosScale / (debugData.segmentWidth * debugData.freeStreamSpeedSq);
					Vector3 vector2 = vector + _wingTransform.TransformDirection(debugData.liftForce * num);
					Gizmos.color = Color.green;
					Gizmos.DrawLine(vector, vector2);
					Gizmos.color = Color.red;
					Gizmos.DrawLine(vector2, vector2 + _wingTransform.TransformDirection(debugData.dragForce) * num);
					Gizmos.color = Color.white;
					Gizmos.DrawLine(vector, vector + _wingTransform.TransformDirection(debugData.freeStreamDir) * _debugGizmosScale);
				}
			}
		}

		public void OnJobsCompleted()
		{
			_activeJobs = null;
			_inputManager.ApplyTransforms();
			_solver?.OnCompleted();
			if (_debug || _drawingGizmos)
			{
				IJobForExtensions.Run(new CopyDebugData
				{
					aero = _aeroData,
					slices = _slices,
					output = _sliceOutput,
					dest = _debugData,
					deltaV = _testDerivativeVel,
					deltaA = _testDerivativeAng
				}, _slices.Length);
				_debugDataValid = true;
			}
			else
			{
				_debugDataValid = false;
			}
			if (_debug)
			{
				if (_debugInfo == null || _debugInfo.Length != _slices.Length)
				{
					_debugInfo = new string[_slices.Length];
				}
				for (int i = 0; i < _debugInfo.Length; i++)
				{
					DebugData debugData = _debugData[i];
					float num = math.sqrt(math.lengthsq(debugData.liftForce) / math.lengthsq(debugData.dragForce));
					SliceAeroData sliceAeroData = _aeroData[i];
					SlicePolar slicePolar = _polars[i];
					slicePolar.Sample(sliceAeroData.effectiveAlpha, sliceAeroData.freeStreamMach, out var cL, out var cD, out var cM);
					_debugInfo[i] = $"LD: {num}\n\n" + $"cL: {cL.x}\n" + $"cD: {cD.x}\n" + $"cM: {cM.x}\n" + $"drag_zero: {slicePolar.dragCurve.zeroLiftDrag}\n" + $"drag_lift: {slicePolar.dragCurve.viscousDragDueToLift * cL.x * cL.x}\n\n" + $"Input Data:\n {_input}\n\n" + $"Slice Data:\n{_slices[i]} \n\n" + $"Slice Aero:\n{_aeroData[i]}\n\n" + $"Slice Output:\n{_sliceOutput[i]}\n\n" + $"Wing Output:\n{_output[0]}";
				}
			}
		}

		public unsafe (JobHandle, IntPtr) ScheduleJobs()
		{
			_inputManager.GetInputs();
			JobHandle dependsOn = default(JobHandle);
			_ = _slices.Length;
			IntPtr item = (IntPtr)_output.GetUnsafeReadOnlyPtr();
			Vector3 pointVelocity = _aeroManager.GetPointVelocity(_wingTransform.position);
			if (WindVectorGetter != null)
			{
				pointVelocity -= WindVectorGetter();
			}
			pointVelocity = _wingTransform.InverseTransformDirection(pointVelocity);
			_input = new WingInputData
			{
				altitude = _wingTransform.position.y + WorldOriginAltitude,
				velocity = pointVelocity,
				angularVelocity = _wingTransform.InverseTransformDirection(_aeroManager.AngularVelocity)
			};
			_wingInputArray[0] = _input;
			GeneratePolarsJob jobData = new GeneratePolarsJob
			{
				wingData = _wingInputArray,
				sliceData = _slices,
				sliceAero = _aeroData,
				slicePolars = _polars,
				controlSurfaces = _controlSurfaces,
				deltaTime = Time.deltaTime,
				baseTransforms = _inputManager.BaseTransforms,
				inverseBaseTransforms = _inputManager.InverseBaseTransforms,
				surfaceTransforms = _inputManager.TargetTransforms,
				controls = _inputManager.Inputs
			};
			EvaluateAndCollectJob jobData2 = new EvaluateAndCollectJob
			{
				wingData = _wingInputArray,
				sliceData = _slices,
				sliceAero = _aeroData,
				slicePolars = _polars,
				sliceOutputForces = _sliceOutput,
				wingOutputForces = _output,
				forceScale = ForceScale,
				wingPosition = _rb.transform.InverseTransformPoint(_wingTransform.position) - _rb.centerOfMass,
				wingRotation = math.float3x3(Quaternion.Inverse(_rb.transform.rotation) * _wingTransform.rotation),
				ViscousLiftDragMultiplier = ViscousDragDueToLiftMultiplier * ViscousDragScale,
				LiftScale = LiftScale,
				ZeroLiftDragScale = ZeroLiftDragScale * WaveDragMultiplier
			};
			dependsOn = IJobExtensions.ScheduleByRef(ref jobData, dependsOn);
			if (_solver != null && UseSpanwiseSolver)
			{
				dependsOn = _solver.Schedule(dependsOn, this);
			}
			dependsOn = IJobExtensions.ScheduleByRef(ref jobData2, dependsOn);
			_activeJobs = dependsOn;
			return (dependsOn, item);
		}

		private unsafe void Cleanup()
		{
			if (_activeJobs.HasValue)
			{
				_activeJobs.Value.Complete();
				_activeJobs = null;
			}
			if (_mallocPtrs != null)
			{
				foreach (IntPtr mallocPtr in _mallocPtrs)
				{
					try
					{
						UnsafeUtility.Free((void*)mallocPtr, Allocator.Persistent);
					}
					catch (Exception arg)
					{
						Debug.LogError($"Failed to free malloc ptr 0x{(ulong)(long)mallocPtr:X}: {arg}", _script);
					}
				}
				_mallocPtrs.Clear();
				_mallocPtrs = null;
			}
			_solver?.Dispose();
			_solver = null;
			_slices.DisposeIfCreated();
			_polars.DisposeIfCreated();
			_aeroData.DisposeIfCreated();
			_sliceOutput.DisposeIfCreated();
			_output.DisposeIfCreated();
			_debugData.DisposeIfCreated();
			_controlSurfaces.DisposeIfCreated();
			_wingInputArray.DisposeIfCreated();
			_initialised = false;
		}

		private void DecoupleFromAeroManager()
		{
			if (!(_aeroManager == null))
			{
				_aeroManager.Unregister(this);
				_aeroManager = null;
				if (_activeJobs.HasValue)
				{
					_activeJobs.Value.Complete();
					_activeJobs = null;
				}
			}
		}
	}
}
