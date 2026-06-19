using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.Networking;

namespace OpenBLive.Runtime.Utilities
{
	public static class SignUtility
	{
		public static string accessKeySecret = "";

		public static string accessKeyId = "";

		public static string clientId = "";

		public static string secret = "";

		private static Dictionary<string, string> OrderAndMd5(string jsonParam)
		{
			return new Dictionary<string, string>
			{
				{
					"x-bili-content-md5",
					jsonParam.Md5()
				},
				{
					"x-bili-timestamp",
					DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString("f0")
				},
				{ "x-bili-signature-method", "HMAC-SHA256" },
				{
					"x-bili-signature-nonce",
					Guid.NewGuid().ToString()
				},
				{ "x-bili-accesskeyid", accessKeyId },
				{ "x-bili-signature-version", "1.0" }
			}.OrderBy((KeyValuePair<string, string> x) => x.Key).ToDictionary((KeyValuePair<string, string> x) => x.Key, (KeyValuePair<string, string> x) => x.Value);
		}

		private static string Md5(this string source)
		{
			MD5 mD = MD5.Create();
			byte[] bytes = Encoding.UTF8.GetBytes(source);
			return mD.ComputeHash(bytes).Aggregate(null, (string current, byte b) => current + b.ToString("x2"));
		}

		private static string CalculateSignature(Dictionary<string, string> keyValuePairs)
		{
			string text = string.Empty;
			foreach (KeyValuePair<string, string> keyValuePair in keyValuePairs)
			{
				text = ((!string.IsNullOrEmpty(text)) ? (text + "\n" + keyValuePair.Key + ":" + keyValuePair.Value) : (text + keyValuePair.Key + ":" + keyValuePair.Value));
			}
			return HmacSHA256(text, accessKeySecret);
		}

		private static string HmacSHA256(string message, string secret)
		{
			if (secret == null)
			{
				secret = "";
			}
			UTF8Encoding uTF8Encoding = new UTF8Encoding();
			byte[] bytes = uTF8Encoding.GetBytes(secret);
			byte[] bytes2 = uTF8Encoding.GetBytes(message);
			using HMACSHA256 hMACSHA = new HMACSHA256(bytes);
			byte[] array = hMACSHA.ComputeHash(bytes2);
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array2 = array;
			foreach (byte b in array2)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		public static void SetReqHeader(UnityWebRequest webRequest, string jsonParam, string cookie = null)
		{
			Dictionary<string, string> dictionary = OrderAndMd5(jsonParam);
			string value = CalculateSignature(dictionary);
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				webRequest.SetRequestHeader(item.Key, item.Value);
			}
			webRequest.SetRequestHeader("Authorization", value);
			webRequest.SetRequestHeader("Accept", "application/json");
			webRequest.SetRequestHeader("Content-Type", "application/json");
			if (cookie != null)
			{
				webRequest.SetRequestHeader("Cookie", cookie);
			}
			byte[] bytes = Encoding.UTF8.GetBytes(jsonParam);
			webRequest.uploadHandler = new UploadHandlerRaw(bytes);
		}
	}
}
