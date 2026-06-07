using System.Collections.Generic;

namespace GAudio
{
	public class FFTBinInfo
	{
		public readonly int BinIndex;

		public readonly float InterpolatedBinIndex;

		public readonly float InterpolatedFrequency;

		public readonly float InterpolatedMagnitude;

		public string Description => $"Interpolated frequency: {InterpolatedFrequency}, magnitude: {InterpolatedMagnitude}, midicode: {GetMidiCode()}";

		public FFTBinInfo(float[] magnitudes, int index, float binFreqWidth)
		{
			float num = magnitudes[index - 1];
			float num2 = magnitudes[index];
			float num3 = magnitudes[index + 1];
			float num4 = (num3 - num) / (2f * (2f * num2 - num - num3));
			InterpolatedMagnitude = num2 - (num - num3) * num4 / 4f;
			InterpolatedBinIndex = (float)index + num4;
			InterpolatedFrequency = InterpolatedBinIndex * binFreqWidth;
			BinIndex = index;
		}

		public FFTBinInfo(float[] magnitudes, int index, int sampleRate, int fftSize)
			: this(magnitudes, index, (float)sampleRate / (float)fftSize)
		{
		}

		public int GetMidiCode()
		{
			return GATMidiHelper.FrequencyToClosestMidiCode(InterpolatedFrequency);
		}

		public static List<FFTBinInfo> GetLowerMaxBins(float[] magnitudes, int fromIndex, int toIndex, float binFrequencyWidth, float magThresholdRatio)
		{
			List<FFTBinInfo> list = new List<FFTBinInfo>();
			fromIndex++;
			toIndex--;
			int indexOfMaxValue = GATMaths.GetIndexOfMaxValue(magnitudes, fromIndex, toIndex);
			FFTBinInfo fFTBinInfo = new FFTBinInfo(magnitudes, indexOfMaxValue, binFrequencyWidth);
			list.Add(fFTBinInfo);
			float num = fFTBinInfo.InterpolatedMagnitude * magThresholdRatio;
			while (true)
			{
				toIndex = fFTBinInfo.BinIndex - 1;
				if (toIndex - fromIndex < 3)
				{
					break;
				}
				indexOfMaxValue = GATMaths.GetIndexOfMaxValue(magnitudes, fromIndex, toIndex);
				fFTBinInfo = new FFTBinInfo(magnitudes, indexOfMaxValue, binFrequencyWidth);
				if (fFTBinInfo.InterpolatedMagnitude < num)
				{
					break;
				}
				list.Add(fFTBinInfo);
			}
			return list;
		}
	}
}
