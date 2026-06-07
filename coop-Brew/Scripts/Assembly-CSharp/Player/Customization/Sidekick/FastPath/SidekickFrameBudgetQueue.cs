using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Player.Customization.Sidekick.FastPath
{
	public class SidekickFrameBudgetQueue : MonoBehaviour
	{
		private struct PendingJob
		{
			public IEnumerator body;

			public Action onComplete;

			public string label;
		}

		private class RunningJob
		{
			public IEnumerator body;

			public Action onComplete;

			public string label;

			public int framesUntilNextStep;
		}

		private readonly Queue<PendingJob> _waiting;

		private readonly List<RunningJob> _running;

		private readonly Stopwatch _frameTimer;

		public static SidekickFrameBudgetQueue Instance { get; private set; }

		public int JobCount => 0;

		public static SidekickFrameBudgetQueue EnsureExists()
		{
			return null;
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void Enqueue(IEnumerator job, Action onComplete = null, string label = null)
		{
		}

		private void LateUpdate()
		{
		}

		private void SafeComplete(RunningJob job)
		{
		}
	}
}
