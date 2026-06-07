namespace GAudio
{
	public static class GATStringExtensions
	{
		public static string HumanReadableBytes(this int numBytes)
		{
			double num = numBytes;
			string text;
			if (numBytes >= 1048576)
			{
				text = "MB";
				num = numBytes >> 10;
			}
			else
			{
				if (numBytes < 1024)
				{
					return numBytes.ToString("0 B");
				}
				text = "KB";
				num = numBytes;
			}
			return (num / 1024.0).ToString("0.## ") + text;
		}
	}
}
