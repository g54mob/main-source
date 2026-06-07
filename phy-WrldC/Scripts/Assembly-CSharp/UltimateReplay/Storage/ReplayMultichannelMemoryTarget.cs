using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UltimateReplay.Storage
{
	[Serializable]
	public class ReplayMultichannelMemoryTarget : ReplayTarget
	{
		private List<ReplayMemoryChannel> channels = new List<ReplayMemoryChannel>();

		private int activeChannel;

		public const int minNumberOfChannels = 1;

		[Range(0f, 60f)]
		[Tooltip("0 = RecordAll] How many seconds should be recorded in the replay. Higher values will result in higher memory consumption")]
		public float recordSeconds = 15f;

		public override float Duration
		{
			get
			{
				if (CurrentChannel.states.Count == 0)
				{
					return 0f;
				}
				ReplaySnapshot replaySnapshot = CurrentChannel.states[CurrentChannel.states.Count - 1];
				float num = replaySnapshot.TimeStamp;
				if (recordSeconds != 0f && replaySnapshot.TimeStamp > recordSeconds)
				{
					ReplaySnapshot replaySnapshot2 = CurrentChannel.states[0];
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
				foreach (ReplaySnapshot state in CurrentChannel.states)
				{
					num += state.Size;
				}
				return num;
			}
		}

		public override ReplayInitialDataBuffer InitialStateBuffer => CurrentChannel.initialStateBuffer;

		public override string TargetSceneName => CurrentChannel.sceneName;

		public int ChannelCount => channels.Count;

		public int ActiveChannel => activeChannel;

		private ReplayMemoryChannel CurrentChannel
		{
			get
			{
				return channels[activeChannel];
			}
			set
			{
				channels[activeChannel] = value;
			}
		}

		public override void Awake()
		{
			SetNumberOfChannels(1);
			base.Awake();
		}

		public override void RecordSnapshot(ReplaySnapshot state)
		{
			CurrentChannel.states.Add(state);
			ConstrainBuffer();
		}

		public override ReplaySnapshot RestoreSnapshot(float offset)
		{
			if (CurrentChannel.states.Count == 0)
			{
				return null;
			}
			if (offset > Duration)
			{
				return null;
			}
			ReplaySnapshot result = CurrentChannel.states[0];
			using (List<ReplaySnapshot>.Enumerator enumerator = CurrentChannel.states.GetEnumerator())
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
				CurrentChannel.states.Clear();
				duration = 0f;
				break;
			case ReplayTargetTask.Commit:
			{
				if (CurrentChannel.states.Count <= 0)
				{
					break;
				}
				float timeStamp = CurrentChannel.states[0].TimeStamp;
				{
					foreach (ReplaySnapshot state in CurrentChannel.states)
					{
						state.CorrectTimestamp(0f - timeStamp);
					}
					break;
				}
			}
			case ReplayTargetTask.PrepareWrite:
			{
				ReplayMemoryChannel currentChannel = CurrentChannel;
				currentChannel.sceneName = SceneManager.GetActiveScene().name;
				CurrentChannel = currentChannel;
				break;
			}
			}
		}

		public void SetNumberOfChannels(int amount)
		{
			if (base.IsRecording)
			{
				throw new InvalidOperationException("You cannot modify the number of channels during recording");
			}
			if (amount > channels.Count)
			{
				while (channels.Count < amount)
				{
					AddChannel();
				}
			}
			else
			{
				if (amount >= channels.Count)
				{
					return;
				}
				while (channels.Count > amount)
				{
					RemoveChannel();
					if (!HasChannel(activeChannel))
					{
						activeChannel = 0;
					}
				}
			}
		}

		public void SetActiveChannel(int channel)
		{
			if (base.IsRecording)
			{
				throw new InvalidOperationException("You cannot change the active channel during recording");
			}
			if (!HasChannel(channel))
			{
				throw new IndexOutOfRangeException("'channel' must map to a valid channel index");
			}
			activeChannel = channel;
		}

		public void AddChannel(bool makeActive = true)
		{
			channels.Add(new ReplayMemoryChannel
			{
				states = new List<ReplaySnapshot>(),
				initialStateBuffer = new ReplayInitialDataBuffer(),
				sceneName = string.Empty
			});
			if (makeActive)
			{
				SetActiveChannel(ChannelCount - 1);
			}
		}

		public void RemoveChannel(int channel = -1)
		{
			if (channel < 0)
			{
				channel = channels.Count - 1;
			}
			if (channels.Count <= 1)
			{
				throw new InvalidOperationException("A ReplayMultichannelMemoryTarget must have atleast 1 channel. The operation would cause all channels to be removed");
			}
			channels.RemoveAt(channel);
		}

		public bool HasChannel(int channel)
		{
			if (channel < channels.Count && channel >= 0)
			{
				return true;
			}
			return false;
		}

		public void DiscardChannel(int channel = -1)
		{
			if (channel < 0)
			{
				channel = activeChannel;
			}
			int num = activeChannel;
			SetActiveChannel(channel);
			PrepareTarget(ReplayTargetTask.Discard);
			SetActiveChannel(num);
		}

		public void DiscardChannels()
		{
			for (int i = 0; i < channels.Count; i++)
			{
				DiscardChannel(i);
			}
		}

		private void ConstrainBuffer()
		{
			if (recordSeconds == 0f || CurrentChannel.states.Count == 0)
			{
				return;
			}
			float num = 0.2f;
			float num2 = CurrentChannel.states[CurrentChannel.states.Count - 1].TimeStamp - (recordSeconds + num);
			for (int i = 0; i < CurrentChannel.states.Count; i++)
			{
				if (CurrentChannel.states[i].TimeStamp <= num2)
				{
					CurrentChannel.states.RemoveAt(i);
				}
			}
		}
	}
}
