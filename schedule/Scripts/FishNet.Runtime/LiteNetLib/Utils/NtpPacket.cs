using System;

namespace LiteNetLib.Utils
{
	public class NtpPacket
	{
		private static readonly DateTime Epoch;

		public byte[] Bytes { get; }

		public NtpLeapIndicator LeapIndicator => default(NtpLeapIndicator);

		public int VersionNumber
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public NtpMode Mode
		{
			get
			{
				return default(NtpMode);
			}
			private set
			{
			}
		}

		public int Stratum => 0;

		public int Poll => 0;

		public int Precision => 0;

		public TimeSpan RootDelay => default(TimeSpan);

		public TimeSpan RootDispersion => default(TimeSpan);

		public uint ReferenceId => 0u;

		public DateTime? ReferenceTimestamp => null;

		public DateTime? OriginTimestamp => null;

		public DateTime? ReceiveTimestamp => null;

		public DateTime? TransmitTimestamp
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public DateTime? DestinationTimestamp { get; private set; }

		public TimeSpan RoundTripTime => default(TimeSpan);

		public TimeSpan CorrectionOffset => default(TimeSpan);

		public NtpPacket()
		{
		}

		internal NtpPacket(byte[] bytes)
		{
		}

		public static NtpPacket FromServerResponse(byte[] bytes, DateTime destinationTimestamp)
		{
			return null;
		}

		internal void ValidateRequest()
		{
		}

		internal void ValidateReply()
		{
		}

		private void CheckTimestamps()
		{
		}

		private DateTime? GetDateTime64(int offset)
		{
			return null;
		}

		private void SetDateTime64(int offset, DateTime? value)
		{
		}

		private TimeSpan GetTimeSpan32(int offset)
		{
			return default(TimeSpan);
		}

		private ulong GetUInt64BE(int offset)
		{
			return 0uL;
		}

		private void SetUInt64BE(int offset, ulong value)
		{
		}

		private int GetInt32BE(int offset)
		{
			return 0;
		}

		private uint GetUInt32BE(int offset)
		{
			return 0u;
		}

		private static uint SwapEndianness(uint x)
		{
			return 0u;
		}

		private static ulong SwapEndianness(ulong x)
		{
			return 0uL;
		}
	}
}
