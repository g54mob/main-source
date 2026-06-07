using System;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Gh.Tk
{
	public class GenericJobBasedTileSimulation : MonoBehaviour, IDisposable
	{
		[Header("simulation settings")]
		public string effectName;

		public float Loss;

		public float WallPassthroughFactor;

		public float DoorPassthroughFactor;

		public float FlowSpeed;

		public AnimationCurve transferCurve;

		public float EquilibriumBlend;

		[Header("Debug options")]
		public bool enableFreezingSimulation;

		public bool enableEquilibriumSimulation;

		[Tooltip("after how many frames of stable input, should the simulation freeze. The slower the FlowSpeed the higher this number should be.")]
		public int framesOfSameInputBeforeFreeze;

		private SampledAnimationCurve _sampledCurve;

		private JobHandle _jobHandle;

		private NativeArray<float> _bufferA;

		private NativeArray<float> _bufferB;

		private NativeArray<float> _readBuffer;

		private NativeArray<float> _writeBuffer;

		private NativeArray<sbyte> _workingEquilibriumValues;

		private NativeArray<Neighbours> _workingNeighbours;

		private NativeArray<sbyte> _workingOutputs;

		private NativeArray<float> _passThroughFactors;

		private bool _isWorking;

		private const float _simulationStep = 0.02f;

		private float _accumulator;

		private int _framesOfSameInput;

		public bool IsFrozen { get; protected set; }

		public void Unfreeze()
		{
		}

		public void Freeze()
		{
		}

		private void Start()
		{
		}

		[MakeButton(null)]
		private void RecomputeAnimationCurve()
		{
		}

		private void Update()
		{
		}

		private AtmosphereGrid GetGridData()
		{
			return null;
		}

		private bool IsInputDirty()
		{
			return false;
		}

		private void LateUpdate()
		{
		}

		private void CopyDataToLocalArrays(AtmosphereGrid gridData)
		{
		}

		private void CommitDataToGame()
		{
		}

		private void OnDestroy()
		{
		}

		public void Dispose()
		{
		}
	}
}
