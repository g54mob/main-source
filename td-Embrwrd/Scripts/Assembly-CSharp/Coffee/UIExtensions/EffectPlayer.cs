using System;
using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UIExtensions
{
	[Serializable]
	public class EffectPlayer
	{
		[Tooltip("Playing.")]
		public bool play;

		[Tooltip("Loop.")]
		public bool loop;

		[Tooltip("Duration.")]
		[Range(0.01f, 10f)]
		public float duration;

		[Range(0f, 10f)]
		[Tooltip("Delay before looping.")]
		public float loopDelay;

		[Tooltip("Update mode")]
		public AnimatorUpdateMode updateMode;

		private static List<Action> s_UpdateActions;

		private float _time;

		private Action<float> _callback;

		public void OnEnable(Action<float> callback = null)
		{
		}

		public void OnDisable()
		{
		}

		public void Play(Action<float> callback = null)
		{
		}

		public void Stop()
		{
		}

		private void OnWillRenderCanvases()
		{
		}
	}
}
