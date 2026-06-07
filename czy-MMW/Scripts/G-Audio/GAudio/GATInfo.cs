using UnityEngine;

namespace GAudio
{
	public class GATInfo
	{
		public static GATInfo UniqueInstance { get; private set; }

		public static int NbOfChannels { get; private set; }

		public static int AudioBufferSizePerChannel { get; private set; }

		public static double AudioBufferDuration { get; private set; }

		public static int OutputSampleRate { get; private set; }

		public static float MaxGainDelta { get; private set; }

		public static double SyncDspTime { get; private set; }

		public static double PulseLatency { get; private set; }

		public static int RequestedSampleRate { get; private set; }

		public static int MaxIOChannels { get; private set; }

		private GATInfo(int inbOfChannels, int iaudioBufferSizePerChannel, double iaudioBufferDuration)
		{
			NbOfChannels = inbOfChannels;
			AudioBufferSizePerChannel = iaudioBufferSizePerChannel;
			AudioBufferDuration = iaudioBufferDuration;
			OutputSampleRate = AudioSettings.outputSampleRate;
			MaxGainDelta = 0.005f;
			UniqueInstance = this;
		}

		public static void Init()
		{
			if (UniqueInstance != null)
			{
				Debug.LogWarning("GATInfo can only be initialized once!");
				return;
			}
			int inbOfChannels = AudioSettings.speakerMode switch
			{
				AudioSpeakerMode.Mono => 1, 
				AudioSpeakerMode.Stereo => 2, 
				AudioSpeakerMode.Quad => 4, 
				AudioSpeakerMode.Surround => 5, 
				AudioSpeakerMode.Mode5point1 => 6, 
				AudioSpeakerMode.Mode7point1 => 8, 
				_ => 2, 
			};
			AudioSettings.GetDSPBufferSize(out var bufferLength, out var _);
			double iaudioBufferDuration = (double)bufferLength / (double)AudioSettings.outputSampleRate;
			UniqueInstance = new GATInfo(inbOfChannels, bufferLength, iaudioBufferDuration);
			if (RequestedSampleRate != 0 && OutputSampleRate != RequestedSampleRate)
			{
				Debug.LogWarning("Requested sample rate of " + RequestedSampleRate + " is not available on this platform.");
			}
		}

		public void SetSyncDspTime(double dspTime)
		{
			SyncDspTime = dspTime;
		}

		public void SetPulseLatency(double pulseLatency)
		{
			PulseLatency = pulseLatency;
		}

		public void SetMaxIOChannels(int maxChannels)
		{
			MaxIOChannels = maxChannels;
		}

		public static void SetRequestedSampleRate(int sampleRate)
		{
			RequestedSampleRate = sampleRate;
		}
	}
}
