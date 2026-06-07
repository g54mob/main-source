namespace GAudio
{
	public class StreamSplitterModule : AGATStreamObserver, IGATAudioThreadStreamOwner
	{
		private GATAudioThreadStreamSplitter _splitter;

		private bool _initialized;

		int IGATAudioThreadStreamOwner.NbOfStreams => _splitter.NbOfStreams;

		protected override void Start()
		{
			if (!_initialized)
			{
				base.Start();
				if (_stream == null)
				{
					base.enabled = false;
				}
				_splitter = new GATAudioThreadStreamSplitter(_stream, GATDataAllocationMode.Fixed);
				_initialized = true;
			}
		}

		private void OnDestroy()
		{
			_splitter.Dispose();
		}

		IGATAudioThreadStream IGATAudioThreadStreamOwner.GetAudioThreadStream(int index)
		{
			if (!_initialized)
			{
				Start();
			}
			return _splitter.GetAudioThreadStream(index);
		}
	}
}
