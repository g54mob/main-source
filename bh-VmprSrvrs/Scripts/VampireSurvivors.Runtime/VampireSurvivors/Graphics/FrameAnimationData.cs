using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace VampireSurvivors.Graphics
{
	[Serializable]
	public class FrameAnimationData
	{
		public string _name;

		public List<Sprite> _frames;

		public int _fps;

		public bool _shouldLoop;

		[HideInInspector]
		public float _frameInterval;

		public bool _startOnRandomFrame;

		[HideInInspector]
		public bool _frameChanged;

		private int _frameIndex;

		private float _currentTime;

		private float _timeSinceFrameChange;

		private Action _onComplete;

		private bool _hasCompleted;

		public FrameAnimationData(string name, List<Sprite> frames, int fps, bool shouldLoop, bool startOnRandomFrame = false, Action onComplete = null)
		{
		}

		public void AddTime(float deltaTime)
		{
		}

		public void Reset()
		{
		}

		public Sprite GetFrame()
		{
			return null;
		}

		public int GetFrameIndex()
		{
			return 0;
		}

		public void AddCompletionCallback(Action callback)
		{
		}

		public void RemoveCompletionCallback(Action callback)
		{
		}

		public void ClearCallbacks()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetStartingFrame()
		{
		}
	}
}
