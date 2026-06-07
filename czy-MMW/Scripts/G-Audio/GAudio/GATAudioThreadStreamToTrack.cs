namespace GAudio
{
	public class GATAudioThreadStreamToTrack : IGATAudioThreadStreamClient, IGATTrackContributor
	{
		private GATTrack _track;

		private IGATAudioThreadStream _stream;

		private float[] _streamBuffer;

		private int _streamOffset;

		private bool _streamDataEmpty;

		private bool _exclusive;

		public GATTrack TargetTrack
		{
			get
			{
				return _track;
			}
			set
			{
				if (!(_track == value))
				{
					if (_track != null)
					{
						_track.UnsubscribeContributor(this);
					}
					_streamBuffer = null;
					_track = value;
					if (_track != null && !_track.SubscribeContributor(this))
					{
						throw new GATException("track " + value.TrackNb + " already has a contributor");
					}
				}
			}
		}

		public bool Exclusive
		{
			get
			{
				return _exclusive;
			}
			set
			{
				if (_exclusive != value)
				{
					_exclusive = value;
				}
			}
		}

		public GATAudioThreadStreamToTrack(GATTrack track, IGATAudioThreadStream stream, bool exclusive)
		{
			_track = track;
			_stream = stream;
			_exclusive = exclusive;
		}

		public void Start()
		{
			if (!_track.SubscribeContributor(this))
			{
				throw new GATException("Track " + _track.TrackNb + " already has a contributor.");
			}
			_stream.AddAudioThreadStreamClient(this);
		}

		public void Stop()
		{
			_track.UnsubscribeContributor(this);
			_stream.RemoveAudioThreadStreamClient(this);
		}

		void IGATAudioThreadStreamClient.HandleAudioThreadStream(float[] data, int offset, bool emptyData, IGATAudioThreadStream stream)
		{
			_streamBuffer = data;
			_streamOffset = offset;
			_streamDataEmpty = emptyData;
		}

		bool IGATTrackContributor.MixToTrack(GATData trackMonoBuffer, int trackNb)
		{
			if (_streamBuffer == null || _streamDataEmpty)
			{
				return false;
			}
			if (_exclusive)
			{
				trackMonoBuffer.CopyFrom(_streamBuffer, 0, _streamOffset, GATInfo.AudioBufferSizePerChannel);
			}
			else
			{
				trackMonoBuffer.MixFrom(_streamBuffer, 0, _streamOffset, GATInfo.AudioBufferSizePerChannel);
			}
			return true;
		}
	}
}
