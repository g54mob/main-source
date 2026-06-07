using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Motorways.Audio
{
	public class AudioDataBank
	{
		private List<AudioSampleData> samples = new List<AudioSampleData>();

		private Dictionary<string, int> sampleIndex = new Dictionary<string, int>();

		private const double MaxSampleAge = 30.0;

		private byte[] compressedData;

		private GCHandle compressedDataHandle;

		private int outputSampleRate;

		private float resampleFactor = 1f;

		private static int totalDecompressedSamples = 0;

		private static int maxDecompressedSamples = -1;

		private static List<short[]> freeSampleBuffers = new List<short[]>();

		public string Id { get; private set; }

		public int Frequency { get; private set; }

		public AudioDataBank(string id, int frequency)
		{
			Id = id;
			Frequency = frequency;
			outputSampleRate = AudioSettings.outputSampleRate;
			if (maxDecompressedSamples < 0)
			{
				maxDecompressedSamples = Mathf.FloorToInt(10485760f * ((float)outputSampleRate / 48000f));
			}
			if (Frequency == outputSampleRate)
			{
				resampleFactor = 1f;
				return;
			}
			if (outputSampleRate < 0)
			{
				resampleFactor = 0f;
				return;
			}
			resampleFactor = (float)outputSampleRate / (float)Frequency;
			if (resampleFactor > 1.5f)
			{
				resampleFactor = 2f;
			}
			else
			{
				resampleFactor = 1f;
			}
		}

		public void AddSampleData(string name, int offset, int length)
		{
			samples.Add(new AudioSampleData(this, name, offset, length, GetResampledLength(length)));
			sampleIndex[name] = samples.Count - 1;
		}

		public bool Load(bool async)
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			string path = Id + ".bytes";
			string text = Path.Combine(Application.streamingAssetsPath, "Sounds", Frequency.ToString(), path);
			compressedData = File.ReadAllBytes(text);
			if (compressedData == null)
			{
				AudioSystem.Log.Error("AudioBank: Failed to load compressed data from '{0}'.", text);
				return false;
			}
			compressedDataHandle = GCHandle.Alloc(compressedData, GCHandleType.Pinned);
			float realtimeSinceStartup2 = Time.realtimeSinceStartup;
			AudioSystem.Log.Info("AudioDataBank: Loaded compressed bank '{0}' in {1}s.", Id, realtimeSinceStartup2 - realtimeSinceStartup);
			return true;
		}

		public AudioSampleData GetSampleData(string name)
		{
			int value = -1;
			if (sampleIndex.TryGetValue(name, out value))
			{
				return samples[value];
			}
			return null;
		}

		public short[] DecompressSample(AudioSampleData sample)
		{
			if (totalDecompressedSamples + sample.Length > maxDecompressedSamples)
			{
				double dspTime = AudioSettings.dspTime;
				for (int i = 0; i < samples.Count; i++)
				{
					double lastUseTime = samples[i].LastUseTime;
					if (!(lastUseTime <= 0.0) && dspTime - lastUseTime > 30.0)
					{
						totalDecompressedSamples -= samples[i].Length;
						freeSampleBuffers.Add(samples[i].SampleData);
						samples[i].Release();
					}
				}
			}
			totalDecompressedSamples += sample.Length;
			short[] array = null;
			for (int j = 0; j < freeSampleBuffers.Count; j++)
			{
				short[] array2 = freeSampleBuffers[j];
				int num = array2.Length - sample.Length;
				if (num >= 0)
				{
					if (num == 0)
					{
						array = array2;
						break;
					}
					if (array == null || array.Length > array2.Length)
					{
						array = array2;
					}
				}
			}
			if (array != null)
			{
				freeSampleBuffers.Remove(array);
			}
			else if (array == null)
			{
				array = new short[sample.Length];
			}
			GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			decompressAudioSample(gCHandle.AddrOfPinnedObject(), 0, sample.NativeLength, sample.Length, outputSampleRate, compressedDataHandle.AddrOfPinnedObject(), sample.Offset, Frequency);
			gCHandle.Free();
			return array;
		}

		public static void PruneSampleBuffers()
		{
			int num = 0;
			for (int i = 0; i < freeSampleBuffers.Count; i++)
			{
				num += freeSampleBuffers[i].Length;
			}
			if (num * 2 > totalDecompressedSamples)
			{
				freeSampleBuffers.Clear();
				num = 0;
			}
			AudioSystem.Log.Info("AudioDataBank: {0} bytes allocated for playing samples, {2} bytes allocated for {1} free sample buffers.\n\t{3} bytes allocated in total.", totalDecompressedSamples * 2, freeSampleBuffers.Count, num * 2, (totalDecompressedSamples + num) * 2);
		}

		public int GetResampledLength(int nativeLength)
		{
			if (resampleFactor == 1f)
			{
				return nativeLength;
			}
			return Mathf.CeilToInt((float)nativeLength * resampleFactor);
		}

		[DllImport("decompressAudio", CallingConvention = CallingConvention.Cdecl)]
		public static extern bool decompressAudioSample(IntPtr decompressedAudio, int decompressedOffset, int decompressedLength, int resampledLength, int decompressedSampleRate, IntPtr compressedAudio, int compressedOffset, int compressedSampleRate);
	}
}
