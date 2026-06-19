using System;
using System.Text;

namespace TH20
{
	public static class ExceptionUtils
	{
		public static Exception NewFormat(string message, params object[] args)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (args.Length != 0)
			{
				stringBuilder.AppendFormat(message, args);
			}
			else
			{
				stringBuilder.Append(message);
			}
			return new Exception(stringBuilder.ToString());
		}
	}
}
