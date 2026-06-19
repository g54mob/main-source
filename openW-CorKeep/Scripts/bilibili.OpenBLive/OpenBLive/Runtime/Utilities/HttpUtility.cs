using System;
using System.Collections.Specialized;
using System.Text;
using UnityEngine.Networking;

namespace OpenBLive.Runtime.Utilities
{
	public static class HttpUtility
	{
		private sealed class HttpQsCollection : NameValueCollection
		{
			public override string ToString()
			{
				int count = Count;
				if (count == 0)
				{
					return "";
				}
				StringBuilder stringBuilder = new StringBuilder();
				string[] allKeys = AllKeys;
				for (int i = 0; i < count; i++)
				{
					stringBuilder.AppendFormat("{0}={1}&", allKeys[i], base[allKeys[i]]);
				}
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Length--;
				}
				return stringBuilder.ToString();
			}
		}

		public static NameValueCollection ParseQueryString(string query)
		{
			return ParseQueryString(query, Encoding.UTF8);
		}

		private static NameValueCollection ParseQueryString(string query, Encoding encoding)
		{
			if (query == null)
			{
				throw new ArgumentNullException("query");
			}
			if (encoding == null)
			{
				throw new ArgumentNullException("encoding");
			}
			if (query.Length == 0 || (query.Length == 1 && query[0] == '?'))
			{
				return new HttpQsCollection();
			}
			if (query[0] == '?')
			{
				query = query.Substring(1);
			}
			NameValueCollection result = new HttpQsCollection();
			ParseQueryString(query, encoding, result);
			return result;
		}

		private static void ParseQueryString(string query, Encoding encoding, NameValueCollection result)
		{
			if (query.Length == 0)
			{
				return;
			}
			int length = query.Length;
			int num = 0;
			bool flag = true;
			while (num <= length)
			{
				int num2 = -1;
				int num3 = -1;
				for (int i = num; i < length; i++)
				{
					if (num2 == -1 && query[i] == '=')
					{
						num2 = i + 1;
					}
					else if (query[i] == '&')
					{
						num3 = i;
						break;
					}
				}
				if (flag)
				{
					flag = false;
					if (query[num] == '?')
					{
						num++;
					}
				}
				string name;
				if (num2 == -1)
				{
					name = null;
					num2 = num;
				}
				else
				{
					name = UnityWebRequest.UnEscapeURL(query.Substring(num, num2 - num - 1), encoding);
				}
				if (num3 < 0)
				{
					num = -1;
					num3 = query.Length;
				}
				else
				{
					num = num3 + 1;
				}
				string value = UnityWebRequest.UnEscapeURL(query.Substring(num2, num3 - num2), encoding);
				result.Add(name, value);
				if (num == -1)
				{
					break;
				}
			}
		}
	}
}
