using System;
using UnityEngine;

namespace Radio
{
	public class RadioChannelManager : MonoBehaviour
	{
		[SerializeField]
		private RadioChannel[] channels;

		[SerializeField]
		private int startChannelIndex;

		public RadioChannel CurrentChannel { get; private set; }

		public int CurrentIndex { get; private set; }

		public int ChannelCount
		{
			get
			{
				RadioChannel[] array = channels;
				if (array == null)
				{
					return 0;
				}
				return array.Length;
			}
		}

		public event Action<RadioChannel> OnChannelChanged;

		private void Awake()
		{
			CurrentIndex = Mathf.Clamp(startChannelIndex, 0, channels.Length - 1);
			CurrentChannel = channels[CurrentIndex];
		}

		public void SetChannel(int index)
		{
			if (channels != null && channels.Length != 0)
			{
				index = Mathf.Clamp(index, 0, channels.Length - 1);
				if (index != CurrentIndex)
				{
					CurrentIndex = index;
					CurrentChannel = channels[CurrentIndex];
					this.OnChannelChanged?.Invoke(CurrentChannel);
				}
			}
		}

		public void Next()
		{
			SetChannel((CurrentIndex + 1) % channels.Length);
		}

		public void Previous()
		{
			SetChannel((CurrentIndex == 0) ? (channels.Length - 1) : (CurrentIndex - 1));
		}
	}
}
