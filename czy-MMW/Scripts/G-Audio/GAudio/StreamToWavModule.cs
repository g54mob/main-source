using UnityEngine;

namespace GAudio
{
	public class StreamToWavModule : AGATStreamObserver, IGATAudioThreadStreamClient
	{
		public string path;

		public PathRelativeType pathType;

		private GATAsyncWavWriter _writer;

		private bool _writing;

		private bool _waiting;

		private string _absPath;

		private double _targetDspTime;

		private int _writtenFrames;

		private int _recFixedFrames;

		public bool IsWriting => _writing;

		public string AbsolutePath => _absPath;

		public string FileURL
		{
			get
			{
				if (_absPath == null)
				{
					return null;
				}
				return GATPathsHelper.URLFromFilePath(_absPath);
			}
		}

		protected override void Start()
		{
			base.Start();
			if (path != "")
			{
				SetPath(path, pathType);
			}
		}

		void IGATAudioThreadStreamClient.HandleAudioThreadStream(float[] data, int offset, bool emptyData, IGATAudioThreadStream stream)
		{
			int num = stream.BufferSizePerChannel;
			if (!_writing)
			{
				double dspTime = AudioSettings.dspTime;
				double num2 = dspTime + GATInfo.AudioBufferDuration;
				if (_targetDspTime < dspTime)
				{
					_targetDspTime = dspTime;
				}
				if (!(num2 > _targetDspTime) || !_waiting)
				{
					return;
				}
				_waiting = false;
				_writing = true;
				int num3 = (int)((_targetDspTime - dspTime) * (double)GATInfo.OutputSampleRate);
				offset += num3 * stream.NbOfChannels;
				num -= num3;
			}
			if (_recFixedFrames > 0 && _writtenFrames + num > _recFixedFrames)
			{
				num = _recFixedFrames - _writtenFrames;
				_writer.WriteStreamAsync(data, offset, num);
				EndWriting();
			}
			else
			{
				_writer.WriteStreamAsync(data, offset, num);
				_writtenFrames += num;
			}
		}

		private void OnDisable()
		{
			if (_writing)
			{
				_writer.StopAndFinalize();
				_writing = false;
			}
		}

		private void OnDestroy()
		{
			if (_writer != null)
			{
				_writer.Dispose();
			}
		}

		public string SetPath(string newPath, PathRelativeType newPathType)
		{
			path = newPath;
			pathType = newPathType;
			_absPath = GATPathsHelper.GetAbsolutePath(newPath, newPathType, createDirectory: true);
			return _absPath;
		}

		public void StartWriting(double targetDspTime = 0.0, int recNumFrames = -1)
		{
			if (!_writing)
			{
				_recFixedFrames = recNumFrames;
				_writtenFrames = 0;
				_waiting = true;
				_targetDspTime = targetDspTime;
				_writer = new GATAsyncWavWriter(_absPath, _stream.NbOfChannels, overwrite: true);
				_writer.PrepareToWrite();
				_stream.AddAudioThreadStreamClient(this);
			}
		}

		public void EndWriting()
		{
			if (_writing)
			{
				_writing = false;
				_stream.RemoveAudioThreadStreamClient(this);
				_writer.StopAndFinalize();
			}
		}
	}
}
