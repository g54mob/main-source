using System;
using Unity.Collections;

namespace MagicaCloth2
{
	public class ExProcessingList<T> : IDisposable, IValid where T : struct
	{
		public NativeReference<int> Counter;

		public NativeArray<T> Buffer;

		public void Dispose()
		{
		}

		public bool IsValid()
		{
			return false;
		}

		public void UpdateBuffer(int capacity)
		{
		}

		public unsafe int* GetJobSchedulePtr()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
