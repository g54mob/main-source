using System.Net.Http;

namespace Google.Apis.Core.Util
{
	internal static class HttpRequestMessageExtensions
	{
		public static void SetOption<TValue>(this HttpRequestMessage request, string key, TValue value)
		{
			request.Properties[key] = value;
		}

		public static bool TryGetOption<TValue>(this HttpRequestMessage request, string key, out TValue value)
		{
			object value2 = null;
			if (request.Properties.TryGetValue(key, out value2) && value2 is TValue val)
			{
				value = val;
				return true;
			}
			value = default(TValue);
			return false;
		}
	}
}
