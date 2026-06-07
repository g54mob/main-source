using System;
using System.Collections.Generic;

namespace JWT
{
	public static class JwtDecoderExtensions
	{
		public static T DecodeHeader<T>(this IJwtDecoder decoder, string token)
		{
			return default(T);
		}

		public static IDictionary<string, string> DecodeHeaderToDictionary(this IJwtDecoder decoder, string token)
		{
			return null;
		}

		public static string Decode(this IJwtDecoder decoder, string token, bool verify = true)
		{
			return null;
		}

		public static string Decode(this IJwtDecoder decoder, string token, byte[] key, bool verify = true)
		{
			return null;
		}

		public static string Decode(this IJwtDecoder decoder, string token, byte[][] keys, bool verify = true)
		{
			return null;
		}

		public static string Decode(this IJwtDecoder decoder, string token, string key, bool verify = true)
		{
			return null;
		}

		public static string Decode(this IJwtDecoder decoder, string token, string[] keys, bool verify = true)
		{
			return null;
		}

		public static IDictionary<string, object> DecodeToObject(this IJwtDecoder decoder, string token, bool verify = true)
		{
			return null;
		}

		public static IDictionary<string, object> DecodeToObject(this IJwtDecoder decoder, string token, string key, bool verify = true)
		{
			return null;
		}

		public static IDictionary<string, object> DecodeToObject(this IJwtDecoder decoder, string token, string[] keys, bool verify = true)
		{
			return null;
		}

		public static IDictionary<string, object> DecodeToObject(this IJwtDecoder decoder, string token, byte[] key, bool verify = true)
		{
			return null;
		}

		public static IDictionary<string, object> DecodeToObject(this IJwtDecoder decoder, string token, byte[][] keys, bool verify = true)
		{
			return null;
		}

		public static object DecodeToObject(this IJwtDecoder decoder, Type type, string token, byte[] key, bool verify = true)
		{
			return null;
		}

		public static object DecodeToObject(this IJwtDecoder decoder, Type type, string token, byte[][] keys, bool verify = true)
		{
			return null;
		}

		public static object DecodeToObject(this IJwtDecoder decoder, Type type, string token, string key, bool verify = true)
		{
			return null;
		}

		public static object DecodeToObject(this IJwtDecoder decoder, Type type, string token, string[] keys, bool verify = true)
		{
			return null;
		}

		public static T DecodeToObject<T>(this IJwtDecoder decoder, JwtParts jwt, bool verify = true)
		{
			return default(T);
		}

		public static T DecodeToObject<T>(this IJwtDecoder decoder, JwtParts jwt, byte[] key, bool verify = true)
		{
			return default(T);
		}

		public static T DecodeToObject<T>(this IJwtDecoder decoder, JwtParts jwt, byte[][] keys, bool verify = true)
		{
			return default(T);
		}

		public static T DecodeToObject<T>(this IJwtDecoder decoder, string token)
		{
			return default(T);
		}

		public static T DecodeToObject<T>(this IJwtDecoder decoder, string token, string key, bool verify = true)
		{
			return default(T);
		}

		public static T DecodeToObject<T>(this IJwtDecoder decoder, string token, byte[] key, bool verify = true)
		{
			return default(T);
		}

		public static T DecodeToObject<T>(this IJwtDecoder decoder, string token, byte[][] keys, bool verify = true)
		{
			return default(T);
		}

		public static T DecodeToObject<T>(this IJwtDecoder decoder, string token, string[] keys, bool verify = true)
		{
			return default(T);
		}
	}
}
