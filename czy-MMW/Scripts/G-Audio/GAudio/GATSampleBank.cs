using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace GAudio
{
	[ExecuteInEditMode]
	public class GATSampleBank : MonoBehaviour
	{
		[SerializeField]
		protected List<GATSoundBank> _SoundBanks = new List<GATSoundBank>();

		public int extraCapacity;

		[SerializeField]
		protected bool _loadInAwake = true;

		protected GATSoundBank _soundBank;

		[SerializeField]
		protected GATDataAllocationMode _allocationMode;

		protected string[] _allKeys;

		protected List<GATData> _allSamples;

		protected int _totalCapacity;

		protected Dictionary<string, GATData> _samplesByName;

		public GATSoundBank SoundBank => _soundBank;

		public List<GATSoundBank> SoundBanks => _SoundBanks;

		public bool LoadInAwake
		{
			get
			{
				return _loadInAwake;
			}
			set
			{
				if (_loadInAwake != value)
				{
					_loadInAwake = value;
				}
			}
		}

		public GATDataAllocationMode AllocationMode
		{
			get
			{
				return _allocationMode;
			}
			set
			{
				if (!IsLoaded)
				{
					_allocationMode = value;
				}
			}
		}

		public string[] AllSampleNames
		{
			get
			{
				if (!IsLoaded)
				{
					return null;
				}
				if (_allKeys == null)
				{
					_allKeys = new string[_samplesByName.Count];
					_samplesByName.Keys.CopyTo(_allKeys, 0);
				}
				return _allKeys;
			}
		}

		public int NumberOfSamplesInBank
		{
			get
			{
				if (_allSamples == null)
				{
					return 0;
				}
				return _allSamples.Count;
			}
		}

		public bool IsLoaded => _allSamples != null;

		public virtual void LoadAll()
		{
			if (_soundBank == null)
			{
				return;
			}
			if (_allSamples == null)
			{
				InitCollections();
			}
			foreach (KeyValuePair<string, GATData> item in _soundBank.LoadAll(_allocationMode))
			{
				AddSample(item.Value, item.Key);
			}
			_allKeys = null;
		}

		public void LoadSamplesNamed(List<string> sampleNames)
		{
			foreach (KeyValuePair<string, GATData> item in _soundBank.LoadSamplesNamed(sampleNames, _allocationMode))
			{
				AddSample(item.Value, item.Key);
			}
			_allKeys = null;
		}

		public void LoadStreamingAssetsAsync(List<string> sampleNames, OperationCompletedHandler onCompleted)
		{
			string[] fullPathsInStreamingAssets = _soundBank.GetFullPathsInStreamingAssets(sampleNames);
			GATAudioLoader.SharedInstance.LoadFilesToSampleBank(fullPathsInStreamingAssets, PathRelativeType.Absolute, this, _allocationMode, onCompleted);
		}

		public virtual void UnloadAll()
		{
			if (_allSamples == null)
			{
				return;
			}
			if (_allSamples != null)
			{
				for (int i = 0; i < _allSamples.Count; i++)
				{
					_allSamples[i].Release();
				}
			}
			_samplesByName = null;
			_allKeys = null;
			_allSamples = null;
		}

		public virtual void AddSample(GATData data, string sampleName)
		{
			if (_allSamples == null)
			{
				InitCollections();
			}
			data.SampleName = sampleName;
			_samplesByName.Add(sampleName, data);
			_allSamples.Add(data);
			data.Retain();
			_allKeys = null;
		}

		public void AddLoadedFile(GATData[] channelsData, string fileName)
		{
			if (_allSamples == null)
			{
				InitCollections();
			}
			fileName = Path.GetFileNameWithoutExtension(fileName);
			if (channelsData.Length == 1)
			{
				AddSample(channelsData[0], fileName);
				return;
			}
			for (int i = 0; i < channelsData.Length; i++)
			{
				AddSample(channelsData[i], $"{fileName}_{i.ToString()}");
			}
		}

		public virtual void RemoveSample(string sampleName)
		{
			GATData gATData = _samplesByName[sampleName];
			gATData.Release();
			_samplesByName.Remove(sampleName);
			_allSamples.Remove(gATData);
			_allKeys = null;
			if (_allSamples.Count == 0)
			{
				_allSamples = null;
				_samplesByName = null;
			}
		}

		public void RemoveSamples(List<string> sampleNames)
		{
			for (int i = 0; i < sampleNames.Count; i++)
			{
				RemoveSample(sampleNames[i]);
			}
		}

		public bool ContainsSampleNamed(string sampleName)
		{
			if (_samplesByName == null)
			{
				return false;
			}
			return _samplesByName.ContainsKey(sampleName);
		}

		public GATData GetAudioData(string sampleName)
		{
			return _samplesByName[sampleName];
		}

		public virtual GATData GetAudioData(int indexInBank)
		{
			return _allSamples[indexInBank];
		}

		public void FillWithSampleData(GATData data, string sampleName, int fromIndex, int length)
		{
			FillWithSampleData(_samplesByName[sampleName], data, fromIndex, length);
		}

		public void FillWithSampleData(GATData data, int indexInBank, int fromIndex, int length)
		{
			FillWithSampleData(_allSamples[indexInBank], data, fromIndex, length);
		}

		public void FillWithResampledData(GATData data, string sampleName, int fromIndex, int targetLength, double pitch)
		{
			FillWithResampledData(_samplesByName[sampleName], data, fromIndex, targetLength, pitch);
		}

		public void FillWithResampledData(GATData data, int indexInBank, int fromIndex, int targetLength, double pitch)
		{
			FillWithResampledData(_allSamples[indexInBank], data, fromIndex, targetLength, pitch);
		}

		public GATData GetClosestSampleForMidiCode(float midiCode, out float pitchShift)
		{
			int index = _allSamples.Count - 1;
			float num = float.MaxValue;
			for (int i = 0; i < _allSamples.Count; i++)
			{
				GATSampleInfo gATSampleInfo = _soundBank.SampleInfos[i];
				float num2 = Mathf.Abs(midiCode - (float)gATSampleInfo.MidiCode);
				if (num2 < num)
				{
					num = num2;
					continue;
				}
				index = i - 1;
				break;
			}
			pitchShift = GATMaths.GetRatioForInterval(midiCode - (float)_soundBank.SampleInfos[index].MidiCode);
			return _allSamples[index];
		}

		protected virtual void Awake()
		{
			UpdateSoundBank();
			if (_loadInAwake)
			{
				LoadAll();
			}
		}

		protected virtual void InitCollections()
		{
			int num = extraCapacity;
			if (_soundBank != null)
			{
				num += _soundBank.SampleInfos.Count;
			}
			_samplesByName = new Dictionary<string, GATData>(num);
			_allSamples = new List<GATData>(num);
			_totalCapacity = num;
		}

		public void UpdateSoundBank()
		{
			if (_soundBank == null && _SoundBanks.Count == 0)
			{
				return;
			}
			GATSoundBank gATSoundBank = null;
			for (int i = 0; i < _SoundBanks.Count; i++)
			{
				gATSoundBank = _SoundBanks[i];
				if (!(gATSoundBank == null) && gATSoundBank.SampleRate == GATInfo.OutputSampleRate)
				{
					_soundBank = gATSoundBank;
					break;
				}
			}
			_ = gATSoundBank == null;
		}

		private void OnEnable()
		{
		}

		protected virtual void OnDestroy()
		{
			UnloadAll();
		}

		protected void FillWithSampleData(GATData sourceData, GATData targetData, int fromIndex, int length)
		{
			int num = ((fromIndex + length > sourceData.Count) ? (sourceData.Count - fromIndex) : length);
			if (num >= 0)
			{
				sourceData.CopyTo(targetData, 0, fromIndex, num);
			}
		}

		protected void FillWithResampledData(GATData sourceData, GATData targetData, int fromIndex, int targetLength, double pitch)
		{
			int num = GATMaths.ClampedResampledLength(sourceData.Count - fromIndex, targetLength, pitch);
			if (num >= 0)
			{
				sourceData.ResampleCopyTo(fromIndex, targetData, num, pitch);
				if (num < targetLength)
				{
					targetData.Clear(num, targetData.Count - num);
				}
			}
		}
	}
}
