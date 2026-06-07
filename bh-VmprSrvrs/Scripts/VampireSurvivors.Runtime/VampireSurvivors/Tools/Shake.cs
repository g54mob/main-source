using System;
using UnityEngine;

namespace VampireSurvivors.Tools
{
	public class Shake : MonoBehaviour
	{
		private Transform _target;

		private bool _isRunning;

		private float _duration;

		private Vector2 _intensity;

		private float _progress;

		private float _elapsed;

		private float _offsetX;

		private float _offsetY;

		private bool _force;

		private Vector2 _basePosition;

		private Action updateCallback;

		public void StartShake(float duration, Vector2 intensity, bool force = false, Action callback = null)
		{
		}

		private void Update()
		{
		}

		private void Complete()
		{
		}
	}
}
