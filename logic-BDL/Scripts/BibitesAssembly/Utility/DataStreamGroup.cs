using System;
using ScriptHelpers;

namespace Utility
{
	public abstract class DataStreamGroup<T> : ISaveableBin
	{
		public Func<bool, T> logAction;

		public LogLikeArray<T> data;

		public bool isInfinite => data.isInfinite;

		protected T CurrentData(bool peek = false)
		{
			return logAction(peek);
		}

		public T PeekCurrentData()
		{
			return logAction(arg: true);
		}

		public void Log()
		{
			data.Push(CurrentData());
		}

		public void Push(T point)
		{
			data.Push(point);
		}

		public abstract int BytesSpace();

		public abstract byte[] SaveStateBin(byte[] bytes = null, int offset = 0);

		public abstract void LoadStateBin(byte[] obj, Version version, int offset = 0, int nBytes = -1);
	}
}
