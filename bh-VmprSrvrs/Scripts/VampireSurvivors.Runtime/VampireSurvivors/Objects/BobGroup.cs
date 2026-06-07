using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using VampireSurvivors.Graphics.Blitters;

namespace VampireSurvivors.Objects
{
	public class BobGroup : IDisposable
	{
		public enum TweenState
		{
			Showing = 0,
			Holding = 1,
			Hiding = 2,
			Completed = 3
		}

		private const int GrowAmount = 64;

		private static Stack<BobGroup> emptyGroups;

		public TweenState tweenState;

		private List<Bob> _bobs;

		private Vector2 _basePosition;

		private Vector2 _raisedPosition;

		private Vector2 _baseScale;

		private Vector2 _raisedScale;

		private Vector2 _currentScale;

		private float _progress;

		private float _currentTime;

		private float _targetTime;

		private float _showDuration;

		private float _holdDuration;

		private float _hideDuration;

		private int _intCount;

		private float _characterWidth;

		private readonly List<float> _baseXPositions;

		private readonly List<float> _xDifferences;

		private bool _disposed;

		private BobGroup()
		{
		}

		private void Reset()
		{
		}

		public static BobGroup Create()
		{
			return null;
		}

		public void SetIntCount(int num)
		{
		}

		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		public void Update(float deltaTime)
		{
		}

		public void Start(Vector2 basePos, float raise = 2f)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Show()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Hold()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Hide()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Complete()
		{
		}

		public void Dispose()
		{
		}

		public void RemoveBobs(Blitter blitter)
		{
		}

		public void AddBob(Bob bob)
		{
		}
	}
}
