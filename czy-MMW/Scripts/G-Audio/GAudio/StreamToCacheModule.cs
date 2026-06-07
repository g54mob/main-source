namespace GAudio
{
	public class StreamToCacheModule : AGATStreamObserver
	{
		public bool allocateCacheInStart;

		public double cacheDuration;

		public bool useManagedData;

		private GATAudioThreadStreamToCache _streamToCache;

		private int _cacheNumFrames;

		private bool _loopedCaching;

		private bool _isInited;

		public GATData[] Caches
		{
			get
			{
				if (_streamToCache == null)
				{
					return null;
				}
				return _streamToCache.Caches;
			}
			set
			{
				if (_streamToCache != null)
				{
					_streamToCache.Caches = value;
				}
			}
		}

		public bool Overdub
		{
			get
			{
				return _streamToCache.Overdub;
			}
			set
			{
				if (_streamToCache.Overdub != value)
				{
					_streamToCache.Overdub = value;
				}
			}
		}

		public int RecPosition
		{
			get
			{
				if (_streamToCache == null)
				{
					return 0;
				}
				return _streamToCache.Position;
			}
		}

		public bool LoopedRec
		{
			get
			{
				return _loopedCaching;
			}
			set
			{
				_loopedCaching = value;
				if (_streamToCache != null)
				{
					_streamToCache.Loop = value;
				}
			}
		}

		protected override void Start()
		{
			if (_isInited)
			{
				return;
			}
			base.Start();
			if (_stream == null)
			{
				base.enabled = false;
				return;
			}
			_streamToCache = new GATAudioThreadStreamToCache(_stream, null);
			_isInited = true;
			if (allocateCacheInStart)
			{
				AllocateCaches(cacheDuration, useManagedData);
			}
		}

		private void OnDestroy()
		{
			ReleaseCache();
		}

		public void AllocateCaches(double duration, bool managedData)
		{
			if (!_isInited)
			{
				Start();
			}
			if (_streamToCache != null && Caches != null)
			{
				_streamToCache.ReleaseCache();
			}
			cacheDuration = duration;
			_cacheNumFrames = (int)(cacheDuration * (double)GATInfo.OutputSampleRate);
			useManagedData = managedData;
			GATData[] array = new GATData[_stream.NbOfChannels];
			for (int i = 0; i < array.Length; i++)
			{
				if (useManagedData)
				{
					if (_cacheNumFrames > GATManager.DefaultDataAllocator.LargestFreeChunkSize)
					{
						for (int j = 0; j < i; j++)
						{
							array[i].Release();
						}
						throw new GATException("Chunk is too large to be allocated in managed memory, consider using unmanaged setting");
					}
					array[i] = GATManager.GetDataContainer(_cacheNumFrames);
				}
				else
				{
					array[i] = new GATData(new float[_cacheNumFrames]);
				}
			}
			_streamToCache.Loop = _loopedCaching;
			_streamToCache.Caches = array;
		}

		public void StartCaching(double dspTime = 0.0, GATAudioThreadStreamToCache.AtEndHandler onAtEnd = null)
		{
			if (_streamToCache == null || Caches == null)
			{
				throw new GATException("No cache is setup.");
			}
			_streamToCache.Start(dspTime, onAtEnd);
		}

		public void StopCaching()
		{
			if (_streamToCache != null)
			{
				_streamToCache.Stop();
			}
		}

		public void ReleaseCache()
		{
			if (_streamToCache != null)
			{
				_streamToCache.ReleaseCache();
			}
		}
	}
}
