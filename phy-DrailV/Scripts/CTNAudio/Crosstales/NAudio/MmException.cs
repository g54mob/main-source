using System;

namespace Crosstales.NAudio
{
	public class MmException : Exception
	{
		private MmResult result;

		public MmResult Result => result;

		public MmException(MmResult result, string function)
			: base(ErrorMessage(result, function))
		{
			this.result = result;
		}

		private static string ErrorMessage(MmResult result, string function)
		{
			return $"{result} calling {function}";
		}

		public static void Try(MmResult result, string function)
		{
			if (result != MmResult.NoError)
			{
				throw new MmException(result, function);
			}
		}
	}
}
