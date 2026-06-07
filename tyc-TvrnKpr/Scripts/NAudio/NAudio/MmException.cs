using System;

namespace NAudio
{
	public class MmException : Exception
	{
		private MmResult result;

		private string function;

		public MmResult Result => default(MmResult);

		public MmException(MmResult result, string function)
		{
		}

		private static string ErrorMessage(MmResult result, string function)
		{
			return null;
		}

		public static void Try(MmResult result, string function)
		{
		}
	}
}
