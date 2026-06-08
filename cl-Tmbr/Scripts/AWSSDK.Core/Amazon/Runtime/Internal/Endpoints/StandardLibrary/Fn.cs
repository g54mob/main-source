using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Amazon.Runtime.Endpoints;
using Amazon.Util;

namespace Amazon.Runtime.Internal.Endpoints.StandardLibrary
{
	public static class Fn
	{
		private static string[] SupportedSchemas = new string[3] { "http", "https", "wss" };

		public static bool IsSet(object value)
		{
			return value != null;
		}

		public static object GetAttr(object value, string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				throw new ArgumentNullException("path");
			}
			string[] array = path.Split(new char[1] { '.' });
			object obj = value;
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				if (i == array.Length - 1)
				{
					int num = text.LastIndexOf('[');
					int num2 = text.Length - 1;
					if (num >= 0)
					{
						string propertyName = text.Substring(0, num);
						int num3 = int.Parse(text.Substring(num + 1, num2 - num - 1));
						if (num > 0)
						{
							obj = ((IPropertyBag)obj)[propertyName];
						}
						if (!(obj is IEnumerable))
						{
							throw new ArgumentException("Object addressing by pathing segment '{part}' with indexer must be IEnumerable");
						}
						List<object> list = ((IEnumerable)obj).Cast<object>().ToList();
						if (num3 < 0 || num3 > list.Count - 1)
						{
							return null;
						}
						return list[num3];
					}
				}
				if (!(obj is IPropertyBag))
				{
					throw new ArgumentException("Object addressing by pathing segment '{part}' must be IPropertyBag");
				}
				obj = ((IPropertyBag)obj)[text];
			}
			return obj;
		}

		public static Partition Partition(string region)
		{
			return Amazon.Runtime.Internal.Endpoints.StandardLibrary.Partition.GetPartitionByRegion(region);
		}

		public static Arn ParseArn(string arn)
		{
			if (!Arn.TryParse(arn, out var arn2))
			{
				return null;
			}
			return arn2;
		}

		public static bool IsValidHostLabel(string hostLabel, bool allowSubDomains)
		{
			List<string> list = new List<string>();
			if (allowSubDomains)
			{
				list.AddRange(hostLabel.Split(new char[1] { '.' }));
			}
			else
			{
				list.Add(hostLabel);
			}
			foreach (string item in list)
			{
				if (!IsVirtualHostableName(item))
				{
					return false;
				}
			}
			return true;
		}

		private static bool IsVirtualHostableName(string name)
		{
			if (string.IsNullOrEmpty(name) || name.Length < 1 || name.Length > 63)
			{
				return false;
			}
			if (!char.IsLetterOrDigit(name[0]) || !char.IsLetterOrDigit(name.Last()))
			{
				return false;
			}
			for (int i = 1; i < name.Length - 1; i++)
			{
				if (!char.IsLetterOrDigit(name[i]) && name[i] != '-')
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsVirtualHostableS3Bucket(string hostLabel, bool allowSubDomains)
		{
			if (IsIpV4Address(hostLabel))
			{
				return false;
			}
			List<string> list = new List<string>();
			if (allowSubDomains)
			{
				list.AddRange(hostLabel.Split(new char[1] { '.' }));
			}
			else
			{
				list.Add(hostLabel);
			}
			foreach (string item in list)
			{
				if (!IsVirtualHostableS3Name(item))
				{
					return false;
				}
			}
			return true;
		}

		private static bool IsVirtualHostableS3Name(string name)
		{
			if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 63)
			{
				return false;
			}
			if (char.IsUpper(name[0]) || !char.IsLetterOrDigit(name[0]) || !char.IsLetterOrDigit(name.Last()))
			{
				return false;
			}
			for (int i = 1; i < name.Length - 1; i++)
			{
				if (char.IsUpper(name[i]) || (!char.IsLetterOrDigit(name[i]) && name[i] != '-'))
				{
					return false;
				}
			}
			return true;
		}

		private static bool IsIpV4Address(string name)
		{
			string[] array = name.Split(new char[1] { '.' });
			if (array.Length != 4)
			{
				return false;
			}
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				if (!byte.TryParse(array2[i], out var _))
				{
					return false;
				}
			}
			return true;
		}

		public static string UriEncode(string value)
		{
			return AWSSDKUtils.UrlEncode(value, path: false);
		}

		public static URL ParseURL(string url)
		{
			Uri.TryCreate(url, UriKind.Absolute, out var result);
			if (!(result == null))
			{
				string query = result.Query;
				if ((query == null || query.Length <= 0) && SupportedSchemas.Contains(result.Scheme))
				{
					URL uRL = new URL
					{
						scheme = result.Scheme,
						authority = result.Authority,
						path = result.GetComponents(UriComponents.Path, UriFormat.Unescaped)
					};
					if (uRL.path.Length > 0)
					{
						uRL.path = "/" + uRL.path;
					}
					uRL.normalizedPath = result.PathAndQuery;
					if (uRL.normalizedPath.Length > 1)
					{
						uRL.normalizedPath += "/";
					}
					UriHostNameType uriHostNameType = Uri.CheckHostName(result.Host);
					uRL.isIp = uriHostNameType == UriHostNameType.IPv4 || uriHostNameType == UriHostNameType.IPv6;
					return uRL;
				}
			}
			return null;
		}

		public static string Interpolate(string template, Dictionary<string, object> refs)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < template.Length; i++)
			{
				char c = template[i];
				char c2 = ((i < template.Length - 1) ? template[i + 1] : '\0');
				if (c == '{' && c2 == '{')
				{
					stringBuilder.Append('{');
					i++;
					continue;
				}
				if (c == '}' && c2 == '}')
				{
					stringBuilder.Append('}');
					i++;
					continue;
				}
				switch (c)
				{
				case '{':
				{
					StringBuilder stringBuilder2 = new StringBuilder();
					while (i < template.Length - 1 && template[i + 1] != '}')
					{
						i++;
						stringBuilder2.Append(template[i]);
					}
					if (i == template.Length - 1)
					{
						throw new ArgumentException("template is missing closing }");
					}
					i++;
					string[] array = stringBuilder2.ToString().Split(new char[1] { '#' });
					string key = array[0];
					if (array.Length > 1)
					{
						stringBuilder.Append(GetAttr(refs[key], array[1]).ToString());
					}
					else
					{
						stringBuilder.Append(refs[key].ToString());
					}
					break;
				}
				case '}':
					throw new ArgumentException("template has non-matching closing bracket, use }} to output }");
				default:
					stringBuilder.Append(c);
					break;
				}
			}
			return stringBuilder.ToString();
		}

		public static string InterpolateJson(string json, Dictionary<string, object> refs)
		{
			if (string.IsNullOrEmpty(json))
			{
				return string.Empty;
			}
			try
			{
				using JsonDocument jsonDocument = JsonDocument.Parse(json);
				JsonElement rootElement = jsonDocument.RootElement;
				using MemoryStream memoryStream = new MemoryStream();
				using Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(memoryStream);
				InterpolateJson(rootElement, refs, utf8JsonWriter);
				utf8JsonWriter.Flush();
				return Encoding.UTF8.GetString(memoryStream.ToArray());
			}
			catch (JsonException)
			{
				return string.Empty;
			}
		}

		private static void InterpolateJson(JsonElement element, Dictionary<string, object> refs, Utf8JsonWriter writer)
		{
			switch (element.ValueKind)
			{
			case JsonValueKind.Object:
				writer.WriteStartObject();
				foreach (JsonProperty item in element.EnumerateObject())
				{
					writer.WritePropertyName(item.Name);
					InterpolateJson(item.Value, refs, writer);
				}
				writer.WriteEndObject();
				break;
			case JsonValueKind.Array:
				writer.WriteStartArray();
				foreach (JsonElement item2 in element.EnumerateArray())
				{
					InterpolateJson(item2, refs, writer);
				}
				writer.WriteEndArray();
				break;
			case JsonValueKind.String:
			{
				string value = Interpolate(element.GetString(), refs);
				writer.WriteStringValue(value);
				break;
			}
			default:
				element.WriteTo(writer);
				break;
			}
		}

		public static string Substring(string input, int start, int stop, bool reverse)
		{
			if (start >= stop || input.Length < stop)
			{
				return null;
			}
			if (input.Any((char c) => c > '\u007f'))
			{
				return null;
			}
			if (!reverse)
			{
				return input.Substring(start, stop - start);
			}
			int num = input.Length - stop;
			int num2 = input.Length - start;
			return input.Substring(num, num2 - num);
		}
	}
}
