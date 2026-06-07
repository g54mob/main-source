using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UltimateReplay.Storage
{
	[Serializable]
	public class ReplayMemoryTarget : ReplayTarget
	{
		private List<ReplaySnapshot> states = new List<ReplaySnapshot>();

		private ReplayInitialDataBuffer initialStateBuffer = new ReplayInitialDataBuffer();

		private string sceneName = string.Empty;

		[Range(0f, 60f)]
		[Tooltip("0 = RecordAll] How many seconds should be recorded in the replay. Higher values will result in higher memory consumption")]
		public float recordSeconds = 15f;

		public override float Duration
		{
			get
			{
				if (states.Count == 0)
				{
					return 0f;
				}
				ReplaySnapshot replaySnapshot = states[states.Count - 1];
				float num = replaySnapshot.TimeStamp;
				if (recordSeconds != 0f && replaySnapshot.TimeStamp > recordSeconds)
				{
					ReplaySnapshot replaySnapshot2 = states[0];
					num -= replaySnapshot2.TimeStamp;
				}
				return num;
			}
		}

		public override int MemorySize
		{
			get
			{
				int num = 0;
				foreach (ReplaySnapshot state in states)
				{
					num += state.Size;
				}
				return num;
			}
		}

		public override ReplayInitialDataBuffer InitialStateBuffer => initialStateBuffer;

		public override string TargetSceneName => sceneName;

		public override void RecordSnapshot(ReplaySnapshot state)
		{
			states.Add(state);
			ConstrainBuffer();
		}

		public override ReplaySnapshot RestoreSnapshot(float offset)
		{
			if (states.Count == 0)
			{
				return null;
			}
			if (offset > Duration)
			{
				return null;
			}
			ReplaySnapshot result = states[0];
			using (List<ReplaySnapshot>.Enumerator enumerator = states.GetEnumerator())
			{
				while (enumerator.MoveNext() && !((result = enumerator.Current).TimeStamp >= offset))
				{
				}
			}
			return result;
		}

		public override void PrepareTarget(ReplayTargetTask mode)
		{
			switch (mode)
			{
			case ReplayTargetTask.Discard:
				states.Clear();
				duration = 0f;
				break;
			case ReplayTargetTask.Commit:
			{
				if (states.Count <= 0)
				{
					break;
				}
				float timeStamp = states[0].TimeStamp;
				{
					foreach (ReplaySnapshot state in states)
					{
						state.CorrectTimestamp(0f - timeStamp);
					}
					break;
				}
			}
			case ReplayTargetTask.PrepareWrite:
				sceneName = SceneManager.GetActiveScene().name;
				break;
			}
		}

		private void ConstrainBuffer()
		{
			if (recordSeconds == 0f || states.Count == 0)
			{
				return;
			}
			float num = 0.2f;
			float num2 = states[states.Count - 1].TimeStamp - (recordSeconds + num);
			for (int i = 0; i < states.Count; i++)
			{
				if (states[i].TimeStamp <= num2)
				{
					states.RemoveAt(i);
				}
			}
		}
	}
}
