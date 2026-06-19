namespace TH20
{
	[DontSave]
	public class DynPlaylistTrackItem
	{
		public bool _bEnabled;

		public bool _bDecodeErrors;

		public bool _bDecodeFatalError;

		public string _itemId;

		public string _parentItemId;

		public DynPlaylistSource _parentSourceType;

		public int _sampleLengthPerChannel;

		public int _internalItemIndex;

		public int _fileContentsId;

		public float _normalisationFactor;

		public string _artistName;

		public string _trackName;

		public string _updatePendingFileSpec;

		public DynPlaylistTrackItem(DynPlaylistSource type, string parentItemId, string itemId)
		{
			_itemId = itemId;
			_parentItemId = parentItemId;
			_bEnabled = true;
			_parentSourceType = type;
			_fileContentsId = 0;
			_sampleLengthPerChannel = 0;
			_normalisationFactor = 0f;
			_bDecodeErrors = false;
			_bDecodeFatalError = false;
			_artistName = string.Empty;
			_trackName = string.Empty;
			_updatePendingFileSpec = string.Empty;
		}

		public bool IsEnabled()
		{
			if (!_bDecodeFatalError)
			{
				return _bEnabled;
			}
			return false;
		}

		public void GetDurationData(ref int numSecsTotal, ref int numMins, ref int numSecs)
		{
			numSecsTotal = _sampleLengthPerChannel / 44100;
			numMins = numSecsTotal / 60;
			numSecs = numSecsTotal % 60;
		}

		public string GetDurationString()
		{
			int numSecsTotal = 0;
			int numMins = 0;
			int numSecs = 0;
			GetDurationData(ref numSecsTotal, ref numMins, ref numSecs);
			return $"{numMins:00}:{numSecs:00}";
		}

		public bool IsAudioInfoKnown()
		{
			if (_parentSourceType != DynPlaylistSource.Internal)
			{
				if (_sampleLengthPerChannel > 0 && _normalisationFactor > 0f)
				{
					return !_bDecodeFatalError;
				}
				return false;
			}
			return true;
		}
	}
}
