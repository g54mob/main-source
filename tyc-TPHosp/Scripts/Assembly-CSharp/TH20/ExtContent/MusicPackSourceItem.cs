namespace TH20.ExtContent
{
	public class MusicPackSourceItem
	{
		private string _fileSpec;

		private string _artistName;

		private string _trackName;

		private string _artistNameOriginal;

		private string _trackNameOriginal;

		private float _normalisationFactor;

		private int _sampleLengthPerChannel;

		public string FileSpec => _fileSpec;

		public string ArtistName
		{
			get
			{
				return _artistName;
			}
			set
			{
				_artistName = value;
			}
		}

		public string TrackName
		{
			get
			{
				return _trackName;
			}
			set
			{
				_trackName = value;
			}
		}

		public string ArtistNameOriginal
		{
			get
			{
				return _artistNameOriginal;
			}
			set
			{
				_artistNameOriginal = value;
			}
		}

		public string TrackNameOriginal
		{
			get
			{
				return _trackNameOriginal;
			}
			set
			{
				_trackNameOriginal = value;
			}
		}

		public float NormalisationFactor
		{
			get
			{
				return _normalisationFactor;
			}
			set
			{
				_normalisationFactor = value;
			}
		}

		public int SampleLengthPerChannel
		{
			get
			{
				return _sampleLengthPerChannel;
			}
			set
			{
				_sampleLengthPerChannel = value;
			}
		}

		public MusicPackSourceItem(string fileSpec, string artistName, string trackName, string artistNameOriginal, string trackNameOriginal)
		{
			_fileSpec = fileSpec;
			_artistName = artistName;
			_trackName = trackName;
			_artistNameOriginal = artistNameOriginal;
			_trackNameOriginal = trackNameOriginal;
		}

		public MusicPackSourceItem(string fileSpec, string artistName, string trackName)
		{
			_fileSpec = fileSpec;
			_artistName = artistName;
			_trackName = trackName;
			_artistNameOriginal = _artistName;
			_trackNameOriginal = _trackName;
		}

		public bool IsAudioInfoKnown()
		{
			if (_normalisationFactor > 0f)
			{
				return _sampleLengthPerChannel > 0;
			}
			return false;
		}
	}
}
