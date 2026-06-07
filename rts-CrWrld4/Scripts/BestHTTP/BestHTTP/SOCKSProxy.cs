using System;
using System.IO;
using BestHTTP.Authentication;

namespace BestHTTP
{
	public sealed class SOCKSProxy : Proxy
	{
		public SOCKSProxy(Uri address, Credentials credentials)
			: base(null, null)
		{
		}

		internal override string GetRequestPath(Uri uri)
		{
			return null;
		}

		internal override void Connect(Stream stream, HTTPRequest request)
		{
		}

		private void WriteString(byte[] buffer, ref int count, string str)
		{
		}

		private void WriteBytes(byte[] buffer, ref int count, byte[] bytes)
		{
		}

		private string BufferToHexStr(byte[] buffer, int count)
		{
			return null;
		}
	}
}
