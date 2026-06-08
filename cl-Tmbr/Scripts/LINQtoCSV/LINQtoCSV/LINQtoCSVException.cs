using System;

namespace LINQtoCSV
{
	public class LINQtoCSVException : Exception
	{
		public LINQtoCSVException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public LINQtoCSVException(string message)
			: base(message)
		{
		}

		public static string FileNameMessage(string fileName)
		{
			if (fileName != null)
			{
				return " Reading file \"" + fileName + "\".";
			}
			return "";
		}
	}
}
