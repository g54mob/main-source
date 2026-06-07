using System.Collections.Generic;

namespace Motorways.Audio
{
	public static class VoiceGroup
	{
		public static void AddVoice(this List<AudioSample> sampleList, AudioSample voice)
		{
			if (voice != null)
			{
				sampleList.Add(voice);
			}
		}

		public static void Limit(this List<AudioSample> sampleList, double fadeTime, int voiceLimit)
		{
			if (sampleList.Count == 0)
			{
				return;
			}
			while (sampleList.Count > voiceLimit)
			{
				if (fadeTime < 0.001)
				{
					sampleList[0].ElegantStop();
				}
				else
				{
					sampleList[0].FadeOutAndStop(fadeTime);
				}
				sampleList.RemoveAt(0);
			}
		}
	}
}
