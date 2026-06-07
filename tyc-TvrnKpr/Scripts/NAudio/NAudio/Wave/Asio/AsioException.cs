using System;

namespace NAudio.Wave.Asio
{
	internal class AsioException : Exception
	{
		private AsioError error;

		public AsioError Error
		{
			get
			{
				return default(AsioError);
			}
			set
			{
			}
		}

		public AsioException()
		{
		}

		public AsioException(string message)
		{
		}

		public AsioException(string message, Exception innerException)
		{
		}

		public static string getErrorName(AsioError error)
		{
			return null;
		}
	}
}
