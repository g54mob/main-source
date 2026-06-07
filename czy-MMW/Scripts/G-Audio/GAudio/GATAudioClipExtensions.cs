using UnityEngine;

namespace GAudio
{
	public static class GATAudioClipExtensions
	{
		public static GATData ToGATData(this AudioClip clip, GATDataAllocationMode mode)
		{
			float[] array = new float[clip.samples];
			clip.GetData(array, 0);
			GATData gATData;
			switch (mode)
			{
			case GATDataAllocationMode.Managed:
				gATData = GATManager.GetDataContainer(clip.samples);
				gATData.CopyFrom(array, 0, 0, clip.samples);
				break;
			case GATDataAllocationMode.Fixed:
				gATData = GATManager.GetFixedDataContainer(clip.samples, "ClipData: " + clip.name);
				gATData.CopyFrom(array, 0, 0, clip.samples);
				break;
			default:
				gATData = new GATData(array);
				break;
			}
			return gATData;
		}

		public static GATData[] ExtractChannels(this AudioClip clip, GATDataAllocationMode mode)
		{
			float[] array = new float[clip.samples * clip.channels];
			clip.GetData(array, 0);
			GATData[] array2 = new GATData[clip.channels];
			int samples = clip.samples;
			for (int i = 0; i < clip.channels; i++)
			{
				switch (mode)
				{
				case GATDataAllocationMode.Managed:
					array2[i] = GATManager.GetDataContainer(samples);
					break;
				case GATDataAllocationMode.Fixed:
					array2[i] = GATManager.GetFixedDataContainer(samples, clip.name + " channel" + i + " data");
					break;
				default:
					array2[i] = new GATData(new float[samples]);
					break;
				}
				array2[i].CopyFromInterlaced(array, samples, i, clip.channels);
			}
			return array2;
		}
	}
}
