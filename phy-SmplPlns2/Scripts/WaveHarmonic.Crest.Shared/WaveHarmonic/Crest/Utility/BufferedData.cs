using System;

namespace WaveHarmonic.Crest.Utility
{
	internal sealed class BufferedData<T>
	{
		private readonly T[] _Buffers;

		private int _CurrentFrameIndex;

		public T Current
		{
			get
			{
				return _Buffers[_CurrentFrameIndex];
			}
			set
			{
				_Buffers[_CurrentFrameIndex] = value;
			}
		}

		public int Size => _Buffers.Length;

		public BufferedData(int size, Func<T> initialize)
		{
			_Buffers = new T[size];
			for (int i = 0; i < size; i++)
			{
				_Buffers[i] = initialize();
			}
		}

		public T Previous(int framesBack)
		{
			return _Buffers[(_CurrentFrameIndex - framesBack + _Buffers.Length) % _Buffers.Length];
		}

		public void Flip()
		{
			_CurrentFrameIndex = (_CurrentFrameIndex + 1) % _Buffers.Length;
		}

		public void RunLambda(Action<T> lambda)
		{
			T[] buffers = _Buffers;
			foreach (T obj in buffers)
			{
				lambda(obj);
			}
		}
	}
}
