using System;

namespace VampireSurvivors.Framework.Platforms
{
	public struct ErroInfo
	{
		public static readonly ErroInfo NonError;

		public readonly int NativeErrorCode;

		public readonly Exception NativeException;

		public readonly string Message;

		public ErroInfo(int nativeErrorCode, string msg = null)
		{
			NativeErrorCode = 0;
			NativeException = null;
			Message = null;
		}

		public ErroInfo(Exception ex, string msg = null)
		{
			NativeErrorCode = 0;
			NativeException = null;
			Message = null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
