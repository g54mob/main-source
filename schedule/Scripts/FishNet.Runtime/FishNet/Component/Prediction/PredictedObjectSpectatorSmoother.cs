using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Transporting;
using UnityEngine;

namespace FishNet.Component.Prediction
{
	internal class PredictedObjectSpectatorSmoother
	{
		private class GoalData
		{
			public bool IsActive;

			public uint LocalTick;

			public RateData Rates;

			public TransformData Transforms;

			public void Reset()
			{
			}

			public void Update(GoalData gd)
			{
			}

			public void Update(uint localTick, RateData rd, TransformData td)
			{
			}
		}

		private class RateData
		{
			public float Position;

			public float Rotation;

			public uint TickSpan;

			internal float TimeRemaining;

			public void Reset()
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Update(RateData rd)
			{
			}

			public void Update(float position, float rotation, uint tickSpan, float timeRemaining)
			{
			}
		}

		private class TransformData
		{
			public Vector3 Position;

			public Quaternion Rotation;

			public void Reset()
			{
			}

			public void Update(TransformData copy)
			{
			}

			public void Update(Vector3 position, Quaternion rotation)
			{
			}

			public void Update(Rigidbody rigidbody)
			{
			}

			public void Update(Rigidbody2D rigidbody)
			{
			}
		}

		private GoalData _currentGoalData;

		private Transform _graphicalObject;

		private bool _smoothPosition;

		private bool _smoothRotation;

		private uint _interpolation;

		private List<GoalData> _goalDatas;

		private Rigidbody _rigidbody;

		private Rigidbody2D _rigidbody2d;

		private TransformData _preTickTransformdata;

		private RigidbodyType _rigidbodyType;

		private long _reconcileLocalTick;

		private bool _preTickReceived;

		private Vector3 _graphicalStartPosition;

		private Quaternion _graphicalStartRotation;

		private float _teleportThreshold;

		private PredictedObject _predictedObject;

		private static Stack<GoalData> _goalDataCache;

		private uint _localTick;

		private uint _ignoredTicks;

		private Vector3 _startWorldPosition;

		private const float OVERFLOW_MULTIPLIER = 0.1f;

		private const float UNDERFLOW_MULTIPLIER = 0.02f;

		public void SetGraphicalObject(Transform value)
		{
		}

		public void SetInterpolation(uint value)
		{
		}

		public void SetIgnoredTicks(uint value)
		{
		}

		internal void Initialize(PredictedObject po, RigidbodyType rbType, Rigidbody rb, Rigidbody2D rb2d, Transform graphicalObject, bool smoothPosition, bool smoothRotation, float teleportThreshold)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ManualUpdate()
		{
		}

		public void OnPreTick()
		{
		}

		public void OnPostTick()
		{
		}

		public void OnPreReplay(uint tick)
		{
		}

		public void OnPostReplay(uint tick)
		{
		}

		private bool CanSmooth()
		{
			return false;
		}

		public void SetLocalReconcileTick(long value)
		{
		}

		private void StoreGoalData(GoalData gd)
		{
		}

		private bool GraphicalObjectMatches(Vector3 localPosition, Quaternion localRotation)
		{
			return false;
		}

		private bool HasChanged(TransformData a, TransformData b)
		{
			return false;
		}

		private bool HasChanged(TransformData td)
		{
			return false;
		}

		private void SetCurrentGoalData(bool afterMove)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void MoveToTarget(float deltaOverride = -1f)
		{
		}

		private void SetInstantRates(RateData rd)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetCalculatedRates(GoalData prevGoalData, GoalData nextGoalData, Channel channel)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CreateGoalData(uint tick, bool postTick)
		{
		}

		private GoalData GetGoalData(uint tick, out int index)
		{
			index = default(int);
			return null;
		}

		private GoalData RetrieveGoalData()
		{
			return null;
		}
	}
}
