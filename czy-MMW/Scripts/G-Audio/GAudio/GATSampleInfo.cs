using System;
using System.IO;
using UnityEngine;

namespace GAudio
{
	[Serializable]
	public class GATSampleInfo
	{
		[SerializeField]
		private string _name;

		[SerializeField]
		private int _midiCode;

		[SerializeField]
		private string _pathInResources;

		[SerializeField]
		private int _numChannels;

		[SerializeField]
		private int _samplesPerChannel;

		[SerializeField]
		private string _guid;

		[SerializeField]
		private bool _isStreamingAsset;

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (!(_name == value))
				{
					_name = value;
				}
			}
		}

		public int MidiCode
		{
			get
			{
				return _midiCode;
			}
			set
			{
				if (_midiCode != value)
				{
					_midiCode = value;
				}
			}
		}

		public string PathInResources => _pathInResources;

		public int NumChannels => _numChannels;

		public int SamplesPerChannel => _samplesPerChannel;

		public string GUID => _guid;

		public bool IsStreamingAsset => _isStreamingAsset;

		public int UncompressedBytesInMemory => _numChannels * _samplesPerChannel * 4;

		public string GetStreamingAssetFullPath()
		{
			if (!_isStreamingAsset)
			{
				return null;
			}
			return Path.Combine(Application.streamingAssetsPath, _pathInResources);
		}

		public GATSampleInfo(string path, string guid, int numChannels, int samplesPerChannel, bool isStreamingAsset = false)
		{
			_isStreamingAsset = isStreamingAsset;
			_pathInResources = path;
			_guid = guid;
			_numChannels = numChannels;
			_samplesPerChannel = samplesPerChannel;
			if (!isStreamingAsset)
			{
				_name = Path.GetFileName(_pathInResources);
			}
			else
			{
				_name = Path.GetFileNameWithoutExtension(_pathInResources);
			}
		}
	}
}
