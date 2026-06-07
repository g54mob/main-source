using System.Threading;

namespace R3
{
	public struct BooleanDisposableCore
	{
		private int isDisposed;

		public bool IsDisposed => Volatile.Read(ref isDisposed) == 1;

		public void Dispose()
		{
			Volatile.Write(ref isDisposed, 1);
		}
	}
}
