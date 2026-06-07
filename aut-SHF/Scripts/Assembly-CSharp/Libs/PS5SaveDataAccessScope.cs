using System;

namespace Libs
{
	public class PS5SaveDataAccessScope : IDisposable
	{
		public enum Mode
		{
			ReadOnly = 0,
			ReadWrite = 1
		}

		private readonly Mode? _mode;

		public static Mode? mountState;

		public PS5SaveDataAccessScope(Mode mode)
		{
		}

		public void Dispose()
		{
		}
	}
}
