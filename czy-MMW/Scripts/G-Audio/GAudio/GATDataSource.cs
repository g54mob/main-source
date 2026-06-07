using System;

namespace GAudio
{
	public class GATDataSource : IDisposable
	{
		private GATData _data;

		private double _nextIndex;

		private double _loopingIndex = -1.0;

		private bool _disposed;

		public int Length => _data.Count;

		public int NextIndex => (int)_nextIndex;

		public GATDataSource(GATData data)
		{
			SetData(data);
		}

		public void Seek(int samplePos)
		{
			_nextIndex = samplePos;
			if (samplePos >= _data.Count)
			{
				_nextIndex = 0.0;
			}
		}

		public void Seek(double samplePos)
		{
			_nextIndex = samplePos;
			if ((int)samplePos >= _data.Count)
			{
				_nextIndex = 0.0;
			}
		}

		public bool SeekToLoopPoint()
		{
			if (_loopingIndex >= 0.0)
			{
				_nextIndex = _loopingIndex;
				return true;
			}
			return false;
		}

		public void SetData(GATData data)
		{
			_nextIndex = 0.0;
			_loopingIndex = -1.0;
			if (_data != null)
			{
				_data.Release();
			}
			_data = data;
			data?.Retain();
		}

		public int GetResampledData(GATData target, int targetLength, int offsetInTarget, bool loop, double pitch, ref bool endOfData, bool readOnly = false)
		{
			GATPlayer.ResampleStopwatch.Start();
			double num = _nextIndex + pitch * (double)(targetLength - 1);
			int num2 = (int)num;
			if (num2 > _data.Count - 1)
			{
				targetLength = (int)Math.Ceiling(((double)_data.Count - _nextIndex) / pitch);
				if (_data.ParentArray != null)
				{
					_loopingIndex = target.ResampleCopyFrom(_data.ParentArray, _nextIndex + (double)_data.MemOffset, targetLength, offsetInTarget, pitch, readOnly);
				}
				else
				{
					_loopingIndex = target.ResampleCopyFrom(_data.ParentArray16, _data.Count, _data.MemOffset, loop, _nextIndex + (double)_data.MemOffset, targetLength, offsetInTarget, pitch, readOnly);
				}
				_loopingIndex -= _data.Count;
				endOfData = true;
				GATPlayer.ResampleStopwatch.Stop();
				return targetLength;
			}
			if (num2 < 0)
			{
				targetLength = (int)Math.Ceiling(_nextIndex / (0.0 - pitch));
				if (_data.ParentArray != null)
				{
					_loopingIndex = target.ResampleCopyFrom(_data.ParentArray, _nextIndex + (double)_data.MemOffset, targetLength, offsetInTarget, pitch, readOnly);
				}
				else
				{
					_loopingIndex = target.ResampleCopyFrom(_data.ParentArray16, _data.Count, _data.MemOffset, loop, _nextIndex + (double)_data.MemOffset, targetLength, offsetInTarget, pitch, readOnly);
				}
				_loopingIndex += _data.Count;
				endOfData = true;
				GATPlayer.ResampleStopwatch.Stop();
				return targetLength;
			}
			if (_data.ParentArray != null)
			{
				target.ResampleCopyFrom(_data.ParentArray, _nextIndex + (double)_data.MemOffset, targetLength, offsetInTarget, pitch, readOnly);
			}
			else
			{
				target.ResampleCopyFrom(_data.ParentArray16, _data.Count, _data.MemOffset, loop, _nextIndex + (double)_data.MemOffset, targetLength, offsetInTarget, pitch, readOnly);
			}
			_loopingIndex = -1.0;
			_nextIndex = num + pitch;
			GATPlayer.ResampleStopwatch.Stop();
			return targetLength;
		}

		public int GetData(GATData target, int targetLength, int offsetInTarget, bool reverse = false, bool readOnly = false)
		{
			int num = (int)_nextIndex;
			int num2 = ((!reverse) ? 1 : (-1));
			int num3 = num + targetLength * num2;
			if (num3 >= _data.Count)
			{
				targetLength = _data.Count - num;
			}
			else if (num3 < 0)
			{
				targetLength = num + 1;
				num3 = 0;
			}
			if (!readOnly)
			{
				if (!reverse)
				{
					if (_data.ParentArray != null)
					{
						target.CopyFrom(_data.ParentArray, offsetInTarget, num + _data.MemOffset, targetLength);
					}
					else
					{
						target.CopyFrom(_data.ParentArray16, offsetInTarget, num + _data.MemOffset, targetLength);
					}
				}
				else if (_data.ParentArray != null)
				{
					target.CopyFrom(_data.ParentArray, offsetInTarget, num3 + _data.MemOffset, targetLength);
					target.Reverse(offsetInTarget, targetLength);
				}
				else
				{
					target.CopyFrom(_data.ParentArray16, offsetInTarget, num3 + _data.MemOffset, targetLength, reverse: true);
				}
			}
			_nextIndex = num3;
			_loopingIndex = -1.0;
			return targetLength;
		}

		public void Dispose()
		{
			Dispose(explicitly: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool explicitly)
		{
			if (!_disposed)
			{
				if (_data != null)
				{
					_data.Release();
				}
				_disposed = true;
			}
		}

		~GATDataSource()
		{
			Dispose(explicitly: false);
		}
	}
}
