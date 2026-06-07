namespace GAudio
{
	public class StreamToTrackModule : AGATStreamObserver
	{
		public GATPlayer player;

		public int trackNumber;

		public bool exclusive;

		protected GATAudioThreadStreamToTrack _streamToTrack;

		public GATTrack TargetTrack
		{
			get
			{
				if (_streamToTrack == null)
				{
					return null;
				}
				return _streamToTrack.TargetTrack;
			}
			set
			{
				if (_streamToTrack != null)
				{
					_streamToTrack.TargetTrack = value;
				}
			}
		}

		private void Awake()
		{
			if (player == null)
			{
				player = GATManager.DefaultPlayer;
			}
		}

		protected override void Start()
		{
			base.Start();
			if (_stream == null)
			{
				base.enabled = false;
			}
			if (_stream.NbOfChannels != 1)
			{
				base.enabled = false;
				throw new GATException("Only mono streams can be routed to a track. You may use GATAudioThreadStreamSplitter to split an interleaved stream in as many mono streams.");
			}
			GATTrack track = player.GetTrack(trackNumber);
			_streamToTrack = new GATAudioThreadStreamToTrack(track, _stream, exclusive);
			_streamToTrack.Start();
		}

		private void OnEnable()
		{
			if (_streamToTrack != null)
			{
				_streamToTrack.Start();
			}
		}

		private void OnDisable()
		{
			if (_streamToTrack != null)
			{
				_streamToTrack.Stop();
			}
		}
	}
}
