using GAudio;
using UnityEngine;

namespace Motorways.Audio
{
	public class AudioSampleData : IGAT16BitDataProvider
	{
		private AudioDataBank bank;

		private short[] data;

		public string Name { get; private set; }

		public int Offset { get; private set; }

		public int Length { get; private set; }

		public int NativeLength { get; private set; }

		public double LastUseTime { get; private set; }

		public GATData GATData { get; private set; }

		public short[] SampleData
		{
			get
			{
				if (LastUseTime == -1.0)
				{
					data = bank.DecompressSample(this);
				}
				LastUseTime = AudioSettings.dspTime;
				return data;
			}
		}

		public AudioSampleData(AudioDataBank bank, string name, int offset, int nativeLength, int resampledLength)
		{
			LastUseTime = -1.0;
			this.bank = bank;
			Name = name;
			Offset = offset;
			NativeLength = nativeLength;
			Length = resampledLength;
			GATData = new GATData(this);
			GATData.SampleName = name;
		}

		public void Release()
		{
			data = null;
			LastUseTime = -1.0;
		}
	}
}
