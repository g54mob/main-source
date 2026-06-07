using System;
using UnityEngine;

namespace GAudio
{
	public class SourceToStreamModule : MonoBehaviour, IGATAudioThreadStreamOwner
	{
		public bool playThrough;

		protected AudioSource _source;

		protected GATAudioThreadStreamProxy _audioThreadStreamProxy;

		int IGATAudioThreadStreamOwner.NbOfStreams => 1;

		protected virtual void Awake()
		{
			_audioThreadStreamProxy = new GATAudioThreadStreamProxy(GATInfo.AudioBufferSizePerChannel, GATInfo.NbOfChannels, GATAudioBuffer.AudioBufferPointer, 0, "MicrophoneStream");
			_source = GetComponent<AudioSource>();
		}

		IGATAudioThreadStream IGATAudioThreadStreamOwner.GetAudioThreadStream(int index)
		{
			return _audioThreadStreamProxy;
		}

		protected virtual void OnAudioFilterRead(float[] data, int numChannels)
		{
			int length = data.Length;
			_audioThreadStreamProxy.BroadcastStream(data, 0, isEmptyData: false);
			if (!playThrough)
			{
				Array.Clear(data, 0, length);
			}
		}
	}
}
