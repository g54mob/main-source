using UnityEngine;

namespace GAudio
{
	public class GATAudioThreadStreamToCache : IGATAudioThreadStreamClient
	{
		public delegate void AtEndHandler(GATData[] caches, bool willLoop);

		private AtEndHandler _onEnd;

		private GATData[] _caches;

		private IGATAudioThreadStream _stream;

		private volatile bool _vDoCache;

		private volatile int _vPosition;

		private bool _overdub;

		private bool _atEnd;

		private bool _waiting;

		private int _numFramesPerRead;

		private int _cacheFrames;

		private double _targetDspTime;

		public bool Loop { get; set; }

		public int Position => _vPosition;

		public GATData[] Caches
		{
			get
			{
				return _caches;
			}
			set
			{
				if (_caches == value)
				{
					return;
				}
				if (_caches != null)
				{
					if (_vDoCache)
					{
						_vDoCache = false;
						_stream.RemoveAudioThreadStreamClient(this);
					}
					ReleaseCache();
				}
				if (_stream.NbOfChannels != value.Length)
				{
					throw new GATException("The number of caches must match the stream's number of channels ( caches are mono )");
				}
				_cacheFrames = value[0].Count;
				for (int i = 1; i < value.Length; i++)
				{
					if (value[i].Count != _cacheFrames)
					{
						throw new GATException("All caches must be of equal length!");
					}
				}
				_caches = value;
				for (int i = 0; i < _caches.Length; i++)
				{
					_caches[i].Retain();
				}
			}
		}

		public bool Overdub
		{
			get
			{
				return _overdub;
			}
			set
			{
				_overdub = value;
			}
		}

		public GATAudioThreadStreamToCache(IGATAudioThreadStream stream, GATData[] caches, AtEndHandler handler = null)
		{
			_numFramesPerRead = stream.BufferSizePerChannel;
			Caches = caches;
			_stream = stream;
			_onEnd = handler;
		}

		public void Start(double targetDspTime = 0.0, AtEndHandler handler = null)
		{
			if (!_vDoCache && !_waiting)
			{
				_waiting = true;
				_vPosition = 0;
				_onEnd = handler;
				_targetDspTime = targetDspTime;
				_stream.AddAudioThreadStreamClient(this);
			}
		}

		public void Stop()
		{
			if (_vDoCache)
			{
				_vDoCache = false;
				_stream.RemoveAudioThreadStreamClient(this);
			}
		}

		public void ReleaseCache()
		{
			if (_caches != null)
			{
				for (int i = 0; i < _caches.Length; i++)
				{
					_caches[i].Release();
				}
				_caches = null;
			}
		}

		void IGATAudioThreadStreamClient.HandleAudioThreadStream(float[] data, int offset, bool emptyData, IGATAudioThreadStream stream)
		{
			int num = _vPosition;
			int num2 = _numFramesPerRead;
			int num3 = _caches.Length;
			double dspTime = AudioSettings.dspTime;
			if (!_vDoCache)
			{
				if (_targetDspTime < dspTime)
				{
					_targetDspTime = dspTime;
				}
				if (!(_targetDspTime >= dspTime) || !(_targetDspTime < dspTime + GATInfo.AudioBufferDuration) || !_waiting)
				{
					return;
				}
				_waiting = false;
				_vDoCache = true;
				int num4 = (int)((_targetDspTime - dspTime) * (double)GATInfo.OutputSampleRate);
				num2 = stream.BufferSizePerChannel - num4;
				offset += num4 * stream.NbOfChannels;
			}
			if (num + _numFramesPerRead >= _cacheFrames)
			{
				num2 = _cacheFrames - num;
				if (Loop)
				{
					for (int i = 0; i < num3; i++)
					{
						if (_overdub)
						{
							_caches[i].MixFromInterlaced(data, offset, num2, num, i, num3);
						}
						else
						{
							_caches[i].CopyFromInterlaced(data, offset, num2, num, i, num3);
						}
					}
					num = 0;
					offset += num2 * stream.NbOfChannels;
					num2 = _numFramesPerRead - num2;
				}
				else
				{
					_vDoCache = false;
					_stream.RemoveAudioThreadStreamClient(this);
				}
				if (_onEnd != null)
				{
					_onEnd(_caches, Loop);
				}
			}
			for (int i = 0; i < num3; i++)
			{
				if (_overdub)
				{
					_caches[i].MixFromInterlaced(data, offset, num2, num, i, num3);
				}
				else
				{
					_caches[i].CopyFromInterlaced(data, offset, num2, num, i, num3);
				}
			}
			num += num2;
			_vPosition = num;
		}
	}
}
