using System.Collections.Generic;
using UnityEngine;

namespace GAudio
{
	public class GATSoundBank : ScriptableObject
	{
		[SerializeField]
		private int _sampleRate;

		[SerializeField]
		private List<GATSampleInfo> _sampleInfos = new List<GATSampleInfo>();

		[SerializeField]
		private int _totalUncompressedBytes;

		private string _humanReadableUncompressedSize;

		public AssetBundle AssetBundle { get; set; }

		public int SampleRate => _sampleRate;

		public List<GATSampleInfo> SampleInfos => _sampleInfos;

		public int TotalUncompressedBytes => _totalUncompressedBytes;

		public string HumanReadableUncompressedSize
		{
			get
			{
				if (_humanReadableUncompressedSize == null)
				{
					_humanReadableUncompressedSize = _totalUncompressedBytes.HumanReadableBytes();
				}
				return _humanReadableUncompressedSize;
			}
		}

		public void Init(int sampleRate)
		{
			if (_sampleRate != 0)
			{
				throw new GATException("Sound Bank's sample rate is already set.");
			}
			_sampleRate = sampleRate;
		}

		public void AddSample(string pathInResources, string guid, int numChannels, int samplesPerChannel, bool isStreamingAsset)
		{
			GATSampleInfo gATSampleInfo = new GATSampleInfo(pathInResources, guid, numChannels, samplesPerChannel, isStreamingAsset);
			_sampleInfos.Add(gATSampleInfo);
			_totalUncompressedBytes += gATSampleInfo.UncompressedBytesInMemory;
			_humanReadableUncompressedSize = null;
		}

		public void RemoveSample(GATSampleInfo sampleInfo)
		{
			_sampleInfos.Remove(sampleInfo);
			_totalUncompressedBytes -= sampleInfo.UncompressedBytesInMemory;
			_humanReadableUncompressedSize = null;
		}

		public bool ContainsSampleNamed(string sampleName)
		{
			for (int i = 0; i < _sampleInfos.Count; i++)
			{
				if (_sampleInfos[i].Name == sampleName)
				{
					return true;
				}
			}
			return false;
		}

		public GATSampleInfo GetSampleInfo(string sampleName)
		{
			for (int i = 0; i < _sampleInfos.Count; i++)
			{
				if (_sampleInfos[i].Name == sampleName)
				{
					return _sampleInfos[i];
				}
			}
			return null;
		}

		public int SizeOfShortestSample()
		{
			int num = int.MaxValue;
			foreach (GATSampleInfo sampleInfo in _sampleInfos)
			{
				if (sampleInfo.SamplesPerChannel < num)
				{
					num = sampleInfo.SamplesPerChannel;
				}
			}
			return num;
		}

		public int SizeOfLongestSample()
		{
			int num = 0;
			foreach (GATSampleInfo sampleInfo in _sampleInfos)
			{
				if (sampleInfo.SamplesPerChannel > num)
				{
					num = sampleInfo.SamplesPerChannel;
				}
			}
			return num;
		}

		public Dictionary<string, GATData> LoadAll(GATDataAllocationMode allocationMode)
		{
			Dictionary<string, GATData> dictionary = new Dictionary<string, GATData>(_sampleInfos.Count);
			for (int i = 0; i < _sampleInfos.Count; i++)
			{
				LoadSample(_sampleInfos[i], dictionary, allocationMode);
			}
			return dictionary;
		}

		public Dictionary<string, GATData> LoadSamplesNamed(List<string> sampleNames, GATDataAllocationMode allocationMode)
		{
			Dictionary<string, GATData> dictionary = new Dictionary<string, GATData>(sampleNames.Count);
			for (int i = 0; i < _sampleInfos.Count; i++)
			{
				GATSampleInfo gATSampleInfo = _sampleInfos[i];
				if (sampleNames.Contains(gATSampleInfo.Name))
				{
					LoadSample(gATSampleInfo, dictionary, allocationMode);
				}
			}
			return dictionary;
		}

		public string[] GetFullPathsInStreamingAssets(List<string> sampleNames)
		{
			List<string> list = new List<string>(sampleNames.Count);
			for (int i = 0; i < _sampleInfos.Count; i++)
			{
				GATSampleInfo gATSampleInfo = _sampleInfos[i];
				if (sampleNames.Contains(gATSampleInfo.Name))
				{
					string streamingAssetFullPath = gATSampleInfo.GetStreamingAssetFullPath();
					if (streamingAssetFullPath != null)
					{
						list.Add(streamingAssetFullPath);
					}
				}
			}
			string[] array = new string[list.Count];
			list.CopyTo(array);
			return array;
		}

		private void LoadSample(GATSampleInfo info, Dictionary<string, GATData> target, GATDataAllocationMode allocationMode)
		{
			if (info.IsStreamingAsset)
			{
				LoadSampleFromStreamingAssets(allocationMode, info, target);
			}
			else
			{
				LoadSampleFromResources(allocationMode, info, target);
			}
		}

		private void LoadSampleFromResources(GATDataAllocationMode mode, GATSampleInfo info, Dictionary<string, GATData> loadedSamples)
		{
		}

		private void LoadSampleFromStreamingAssets(GATDataAllocationMode mode, GATSampleInfo info, Dictionary<string, GATData> loadedSamples)
		{
			AGATAudioFile file;
			GATData[] array;
			using (file = AGATAudioFile.OpenAudioFileAtPath(info.GetStreamingAssetFullPath()))
			{
				array = GATAudioLoader.SharedInstance.LoadSync(file, mode);
			}
			if (array.Length == 1)
			{
				loadedSamples.Add(info.Name, array[0]);
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				loadedSamples.Add($"{info.Name}_{i}", array[i]);
			}
		}
	}
}
