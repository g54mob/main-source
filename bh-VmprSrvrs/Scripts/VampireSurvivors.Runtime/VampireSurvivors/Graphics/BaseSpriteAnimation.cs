using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;

namespace VampireSurvivors.Graphics
{
	public abstract class BaseSpriteAnimation : GameMonoBehaviour
	{
		public List<FrameAnimationData> _defaultAnimations;

		private readonly Dictionary<string, FrameAnimationData> _animations;

		private FrameAnimationData _currentAnimation;

		private FrameAnimationData _localAnimation;

		private Action<string> _onUpdate;

		private static ProfilerMarker internalUpdateMarker;

		private static readonly ProfilerMarker MarkerAddAnimation;

		private static readonly ProfilerMarker MarkerCleanAnimations;

		public bool IsPaused { get; set; }

		public string CurrentAnim => null;

		protected virtual void Awake()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void InternalUpdate(float deltaTime)
		{
		}

		public void create(string animName, List<Sprite> frames, int frameRate, bool shouldLoop, bool startRandomFrame = false, Action onComplete = null, bool autoSetAnimation = true)
		{
		}

		public void AddAnimation(string animName, List<Sprite> frames, int fps, bool shouldLoop, bool startRandomFrame = false, Action onComplete = null, bool autoSetAnimation = true)
		{
		}

		public void SetAnimation(FrameAnimationData newAnim, string animName)
		{
		}

		public void SetLocalAnimation(FrameAnimationData newAnim, string animName)
		{
		}

		public FrameAnimationData GetCurrentAnimation()
		{
			return null;
		}

		public Sprite GetCurrentFrame()
		{
			return null;
		}

		public void SetAnimation(string animName)
		{
		}

		public void Play(string animName)
		{
		}

		public void Play(string animName, int frameRate)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public FrameAnimationData GetAnimation(string animName)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ContainsAnim(string animName)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddCompletionCallback(string animName, Action callback)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RemoveCompletionCallback(string animName, Action callback)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AddUpdateCallback(Action<string> callback)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void RemoveUpdateCallback(Action<string> callback)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ClearCallbacksForAnim(string animName)
		{
		}

		public void CleanAnimations()
		{
		}

		public void Stop()
		{
		}

		public void Pause()
		{
		}

		public void Resume()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static bool IsAnimDataValid(FrameAnimationData frameAnimationData)
		{
			return false;
		}

		protected abstract void ApplySpriteFrame(Sprite sprite);
	}
}
