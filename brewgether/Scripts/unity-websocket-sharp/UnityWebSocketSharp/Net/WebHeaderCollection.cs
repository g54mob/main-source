using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace UnityWebSocketSharp.Net
{
	[Serializable]
	[ComVisible(true)]
	internal class WebHeaderCollection : NameValueCollection, ISerializable
	{
		private static readonly Dictionary<string, HttpHeaderInfo> _headers;

		private bool _internallyUsed;

		private HttpHeaderType _state;

		internal HttpHeaderType State => default(HttpHeaderType);

		public override string[] AllKeys => null;

		public override int Count => 0;

		public string this[HttpRequestHeader header]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string this[HttpResponseHeader header]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override KeysCollection Keys => null;

		static WebHeaderCollection()
		{
		}

		internal WebHeaderCollection(HttpHeaderType state, bool internallyUsed)
		{
		}

		protected WebHeaderCollection(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}

		public WebHeaderCollection()
		{
		}

		private void add(string name, string value, HttpHeaderType headerType)
		{
		}

		private void checkAllowed(HttpHeaderType headerType)
		{
		}

		private static string checkName(string name, string paramName)
		{
			return null;
		}

		private void checkRestricted(string name, HttpHeaderType headerType)
		{
		}

		private static string checkValue(string value, string paramName)
		{
			return null;
		}

		private static HttpHeaderInfo getHeaderInfo(string name)
		{
			return null;
		}

		private static string getHeaderName(string key)
		{
			return null;
		}

		private static HttpHeaderType getHeaderType(string name)
		{
			return default(HttpHeaderType);
		}

		private static bool isMultiValue(string name, bool response)
		{
			return false;
		}

		private static bool isRestricted(string name, bool response)
		{
			return false;
		}

		private void set(string name, string value, HttpHeaderType headerType)
		{
		}

		internal void InternalRemove(string name)
		{
		}

		internal void InternalSet(string header, bool response)
		{
		}

		internal void InternalSet(string name, string value, bool response)
		{
		}

		internal string ToStringMultiValue(bool response)
		{
			return null;
		}

		protected void AddWithoutValidate(string headerName, string headerValue)
		{
		}

		public void Add(string header)
		{
		}

		public void Add(HttpRequestHeader header, string value)
		{
		}

		public void Add(HttpResponseHeader header, string value)
		{
		}

		public override void Add(string name, string value)
		{
		}

		public override void Clear()
		{
		}

		public override string Get(int index)
		{
			return null;
		}

		public override string Get(string name)
		{
			return null;
		}

		public override IEnumerator GetEnumerator()
		{
			return null;
		}

		public override string GetKey(int index)
		{
			return null;
		}

		public override string[] GetValues(int index)
		{
			return null;
		}

		public override string[] GetValues(string name)
		{
			return null;
		}

		public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}

		public static bool IsRestricted(string headerName)
		{
			return false;
		}

		public static bool IsRestricted(string headerName, bool response)
		{
			return false;
		}

		public override void OnDeserialization(object sender)
		{
		}

		public void Remove(HttpRequestHeader header)
		{
		}

		public void Remove(HttpResponseHeader header)
		{
		}

		public override void Remove(string name)
		{
		}

		public void Set(HttpRequestHeader header, string value)
		{
		}

		public void Set(HttpResponseHeader header, string value)
		{
		}

		public override void Set(string name, string value)
		{
		}

		public byte[] ToByteArray()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
		{
		}
	}
}
