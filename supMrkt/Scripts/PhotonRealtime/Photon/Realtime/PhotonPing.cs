using System;

namespace Photon.Realtime
{
	public abstract class PhotonPing : IDisposable
	{
		public string DebugString;

		public bool Successful;

		protected internal bool GotResult;

		protected internal int PingLength;

		protected internal byte[] PingBytes;

		protected internal byte PingId;

		private static readonly Random RandomIdProvider;

		public virtual bool StartPing(string ip)
		{
			return false;
		}

		public virtual bool Done()
		{
			return false;
		}

		public virtual void Dispose()
		{
		}

		protected internal void Init()
		{
		}
	}
}
