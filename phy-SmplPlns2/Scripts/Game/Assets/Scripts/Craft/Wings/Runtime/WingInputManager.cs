using System;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Craft.Wings.Runtime
{
	public class WingInputManager : IDisposable
	{
		private struct InputData
		{
			public Func<float> inputFunc;

			public InputData(Func<float> func)
			{
				inputFunc = func;
			}

			public readonly float GetInput(float2 range)
			{
				float num = inputFunc();
				num = ((range.x == 0f) ? math.max(num, 0f) : (num * (0f - range.x)));
				num = ((range.y == 0f) ? math.min(num, 0f) : (num * range.y));
				return math.clamp(num, range.x, range.y);
			}
		}

		private Transform[] _controlSurfaceTransforms;

		private bool _flipY;

		private InputData[] _inputData;

		private float2[] _inputRanges;

		private NativeArray<float> _inputs;

		private (Range Inputs, Range Objects)[] _ranges;

		private NativeArray<RigidTransform> _baseTransforms;

		private NativeArray<RigidTransform> _targetTransforms;

		private NativeArray<RigidTransform> _inverseBaseTransforms;

		private NativeArray<RigidTransform> _localBaseTransforms;

		private int[] _controlSurfaceIndices;

		public NativeArray<RigidTransform> BaseTransforms => _baseTransforms;

		public NativeArray<RigidTransform> InverseBaseTransforms => _inverseBaseTransforms;

		public IControlSurfaceRuntimeData[] ControlSurfaceRuntimeData { get; private set; }

		public NativeArray<float> Inputs => _inputs;

		public NativeArray<RigidTransform> TargetTransforms => _targetTransforms;

		public WingInputManager(WingRuntimeOutput wingRuntime)
			: this(wingRuntime.MeshOutput.ControlSurfaceRootPoses, wingRuntime.ControlSurfaces, wingRuntime.MakeRuntimeData(), wingRuntime.ControlSurfaceTransforms, wingRuntime.IsFlipped)
		{
		}

		public WingInputManager(RigidTransform[] parentRootTransforms, ControlSurface[] controlSurfaces, IControlSurfaceRuntimeData[] runtimeData, Transform[] controlSurfaceTransforms, bool yFlipped)
		{
			ControlSurfaceRuntimeData = runtimeData;
			_flipY = yFlipped;
			_controlSurfaceTransforms = controlSurfaceTransforms;
			_targetTransforms = new NativeArray<RigidTransform>(controlSurfaceTransforms.Length, Allocator.Persistent);
			_baseTransforms = new NativeArray<RigidTransform>(controlSurfaceTransforms.Length, Allocator.Persistent);
			_inverseBaseTransforms = new NativeArray<RigidTransform>(controlSurfaceTransforms.Length, Allocator.Persistent);
			_localBaseTransforms = new NativeArray<RigidTransform>(controlSurfaceTransforms.Length, Allocator.Persistent);
			_controlSurfaceIndices = new int[controlSurfaceTransforms.Length];
			int num = 0;
			int num2 = 0;
			_ranges = new(Range, Range)[controlSurfaces.Length];
			for (int i = 0; i < controlSurfaces.Length; i++)
			{
				ControlSurface controlSurface = controlSurfaces[i];
				IControlSurfaceRuntimeData controlSurfaceRuntimeData = runtimeData[i];
				_ranges[i] = (Inputs: num..(num + controlSurfaceRuntimeData.InputCount), Objects: num2..(num2 + controlSurface.MeshCount));
				num += controlSurfaceRuntimeData.InputCount;
				num2 += controlSurface.MeshCount;
			}
			_inputs = new NativeArray<float>(num, Allocator.Persistent);
			_inputRanges = new float2[num];
			_inputData = new InputData[num];
			for (int j = 0; j < controlSurfaces.Length; j++)
			{
				runtimeData[j].GetInputRanges(_inputRanges.AsSpan(_ranges[j].Inputs));
				RigidTransform a = RigidTransform.identity;
				if (parentRootTransforms != null)
				{
					a = parentRootTransforms[j];
				}
				Range item = _ranges[j].Objects;
				for (int k = item.Start.Value; k < item.End.Value; k++)
				{
					_targetTransforms[k] = RigidTransform.identity;
					RigidTransform localRigidTransform = _controlSurfaceTransforms[k].GetLocalRigidTransform();
					_localBaseTransforms[k] = localRigidTransform;
					localRigidTransform = math.mul(a, localRigidTransform);
					_baseTransforms[k] = localRigidTransform;
					_inverseBaseTransforms[k] = math.inverse(localRigidTransform);
					_controlSurfaceIndices[k] = j;
				}
				item = _ranges[j].Inputs;
				for (int l = item.Start.Value; l < item.End.Value; l++)
				{
					_ = item.Start.Value;
					_inputs[l] = 0f;
					_inputData[l] = new InputData(ZeroInput);
				}
			}
		}

		public void ApplyTransforms()
		{
			for (int i = 0; i < _controlSurfaceTransforms.Length; i++)
			{
				RigidTransform rigidTransform = _targetTransforms[i];
				if (_flipY)
				{
					rigidTransform = MathUtils.GetTransformInMirroredYSpace(rigidTransform);
				}
				_controlSurfaceTransforms[i].SetLocalRigidTransform(_localBaseTransforms[i].Transform(rigidTransform));
			}
		}

		public void Dispose()
		{
			_targetTransforms.Dispose();
			_baseTransforms.Dispose();
			_inverseBaseTransforms.Dispose();
			_localBaseTransforms.Dispose();
			_inputs.Dispose();
		}

		public void GetInputs()
		{
			for (int i = 0; i < _inputs.Length; i++)
			{
				_inputs[i] = _inputData[i].GetInput(_inputRanges[i]);
			}
		}

		public float2 GetInputRange(int controlSurface, int idx)
		{
			return _inputRanges[_ranges[controlSurface].Inputs.Start.Value + idx];
		}

		public void SetInputGetter(int controlSurface, int idx, Func<float> func)
		{
			Range item = _ranges[controlSurface].Inputs;
			Span<InputData> span = _inputData.AsSpan(item);
			if (idx < span.Length)
			{
				span[idx].inputFunc = func;
			}
		}

		private static float ZeroInput()
		{
			return 0f;
		}
	}
}
