using System;
using System.Text;

namespace TwitchLib.PubSub.Common
{
	public static class Helpers
	{
		public static DateTime DateTimeStringToObject(string dateTime)
		{
			return (dateTime == null) ? default(DateTime) : Convert.ToDateTime(dateTime);
		}

		public static string Base64Encode(string plainText)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(bytes);
		}
	}
}
