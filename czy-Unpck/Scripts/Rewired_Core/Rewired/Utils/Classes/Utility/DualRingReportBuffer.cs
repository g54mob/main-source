using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class DualRingReportBuffer : IDisposable
	{
		private readonly int PGQxIwPgTNdLhCbGCnYEAqYmOase;

		private readonly int TrxmuWLLUVWUdIURguCfiBGxIMbi;

		private readonly int AQalwRKuRMLyYpBOfgNfFhvQmaB;

		private NativeRingBuffer IiwCdbaRjlQVRtRCdZVcorHHWx;

		private NativeRingBuffer jzFHXhdHGqAjbnrUbBWYPxavjDIJ;

		private byte[] dxApbfTEcCttxzoIdWjxzuEvoRH;

		private byte[] oUdAvcHQOWPVhSIBlUQColKnkBl;

		private int RwoTfmHnmiacfRZAXlaJmyvqPrG;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public int BufferLength => PGQxIwPgTNdLhCbGCnYEAqYmOase;

		public int BytesInBuffer => jzFHXhdHGqAjbnrUbBWYPxavjDIJ.BytesInBuffer;

		public int EntriesInBuffer => jzFHXhdHGqAjbnrUbBWYPxavjDIJ.BytesInBuffer / TrxmuWLLUVWUdIURguCfiBGxIMbi;

		public byte[] ReadBuffer => oUdAvcHQOWPVhSIBlUQColKnkBl;

		public int LastNumBytesRead => RwoTfmHnmiacfRZAXlaJmyvqPrG;

		public DualRingReportBuffer(int entryByteLength, int entryCapacity)
		{
			if (entryByteLength <= 0)
			{
				throw new ArgumentOutOfRangeException("entryByteLength must be > 0.");
			}
			if (entryCapacity < 1)
			{
				throw new ArgumentOutOfRangeException("entryCapacity must be >= 1.");
			}
			TrxmuWLLUVWUdIURguCfiBGxIMbi = entryByteLength;
			AQalwRKuRMLyYpBOfgNfFhvQmaB = entryCapacity;
			PGQxIwPgTNdLhCbGCnYEAqYmOase = entryByteLength * entryCapacity;
			IiwCdbaRjlQVRtRCdZVcorHHWx = new NativeRingBuffer(PGQxIwPgTNdLhCbGCnYEAqYmOase);
			jzFHXhdHGqAjbnrUbBWYPxavjDIJ = new NativeRingBuffer(PGQxIwPgTNdLhCbGCnYEAqYmOase);
			dxApbfTEcCttxzoIdWjxzuEvoRH = new byte[entryByteLength];
			oUdAvcHQOWPVhSIBlUQColKnkBl = new byte[entryByteLength];
		}

		public int StartRead()
		{
			CtKxyBSLFoKhfnquZkmRNhCvxmt();
			return jzFHXhdHGqAjbnrUbBWYPxavjDIJ.BytesInBuffer;
		}

		public int Read()
		{
			int num = 0;
			lock (jzFHXhdHGqAjbnrUbBWYPxavjDIJ)
			{
				num = jzFHXhdHGqAjbnrUbBWYPxavjDIJ.Read(oUdAvcHQOWPVhSIBlUQColKnkBl, TrxmuWLLUVWUdIURguCfiBGxIMbi);
			}
			RwoTfmHnmiacfRZAXlaJmyvqPrG = num;
			return num;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				goto IL_0003;
			}
			goto IL_006c;
			IL_0003:
			int num = 990182965;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				int num2;
				switch (num ^ 0x3B04FE37)
				{
				case 0:
					break;
				case 6:
					goto IL_0031;
				case 3:
					throw new ArgumentOutOfRangeException("numBytesToWrite");
				case 2:
					throw new ArgumentNullException("buffer");
				case 1:
					goto IL_006c;
				case 5:
					num2 = 0;
					num = 990182963;
					continue;
				default:
					lock (jzFHXhdHGqAjbnrUbBWYPxavjDIJ)
					{
						num2 = jzFHXhdHGqAjbnrUbBWYPxavjDIJ.Read(buffer, numBytesToRead);
					}
					RwoTfmHnmiacfRZAXlaJmyvqPrG = num2;
					return num2;
				}
				break;
				IL_0031:
				int num3;
				if (numBytesToRead <= buffer.Length)
				{
					num = 990182962;
					num3 = num;
				}
				else
				{
					num = 990182964;
					num3 = num;
				}
			}
			goto IL_0003;
			IL_006c:
			int num4;
			if (numBytesToRead >= 0)
			{
				num = 990182961;
				num4 = num;
			}
			else
			{
				num = 990182964;
				num4 = num;
			}
			goto IL_0008;
		}

		public int Read(IntPtr buffer, int bufferLength, int numBytesToRead)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			while (bufferLength > 0)
			{
				while (true)
				{
					IL_006a:
					if (numBytesToRead >= 0)
					{
						int num;
						int num2;
						if (numBytesToRead <= bufferLength)
						{
							num = 1380509002;
							num2 = num;
						}
						else
						{
							num = 1380509006;
							num2 = num;
						}
						while (true)
						{
							int num3;
							switch (num ^ 0x5248E54A)
							{
							case 3:
								num = 1380509000;
								continue;
							case 2:
								break;
							case 4:
								goto IL_0058;
							case 1:
								goto IL_006a;
							case 0:
								num3 = 0;
								num = 1380509007;
								continue;
							default:
								lock (jzFHXhdHGqAjbnrUbBWYPxavjDIJ)
								{
									num3 = jzFHXhdHGqAjbnrUbBWYPxavjDIJ.Read(buffer, bufferLength, bufferLength);
								}
								RwoTfmHnmiacfRZAXlaJmyvqPrG = num3;
								return num3;
							}
							break;
						}
						break;
					}
					goto IL_0058;
					IL_0058:
					throw new ArgumentOutOfRangeException("numBytesToWrite");
				}
			}
			throw new ArgumentOutOfRangeException("bufferLength");
		}

		public int Write(byte[] buffer, int numBytesToWrite)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			while (numBytesToWrite >= 0)
			{
				int num;
				int num2;
				if (numBytesToWrite > buffer.Length)
				{
					num = -2106823578;
					num2 = num;
				}
				else
				{
					num = -2106823581;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -2106823582)
					{
					case 0:
						num = -2106823584;
						continue;
					case 2:
						break;
					case 1:
					{
						int num3 = 0;
						num = -2106823583;
						continue;
					}
					case 4:
						goto end_IL_0034;
					default:
						lock (IiwCdbaRjlQVRtRCdZVcorHHWx)
						{
							return IiwCdbaRjlQVRtRCdZVcorHHWx.Write(buffer, numBytesToWrite);
						}
					}
					break;
				}
				continue;
				end_IL_0034:
				break;
			}
			throw new ArgumentOutOfRangeException("numBytesToWrite");
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite)
		{
			if (buffer == IntPtr.Zero)
			{
				goto IL_000d;
			}
			goto IL_0062;
			IL_000d:
			int num = -1689341580;
			goto IL_0012;
			IL_0012:
			switch (num ^ -1689341579)
			{
			case 4:
				break;
			case 5:
				goto IL_0037;
			case 0:
				goto IL_0049;
			case 2:
				goto IL_0062;
			case 1:
				throw new ArgumentNullException("buffer");
			default:
			{
				int num2 = 0;
				lock (IiwCdbaRjlQVRtRCdZVcorHHWx)
				{
					return IiwCdbaRjlQVRtRCdZVcorHHWx.Write(buffer, bufferLength, numBytesToWrite);
				}
			}
			}
			goto IL_000d;
			IL_0037:
			throw new ArgumentOutOfRangeException("numBytesToWrite");
			IL_0062:
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength");
			}
			goto IL_0049;
			IL_0049:
			if (numBytesToWrite >= 0)
			{
				int num3;
				if (numBytesToWrite <= bufferLength)
				{
					num = -1689341578;
					num3 = num;
				}
				else
				{
					num = -1689341584;
					num3 = num;
				}
				goto IL_0012;
			}
			goto IL_0037;
		}

		public void Clear()
		{
			lock (IiwCdbaRjlQVRtRCdZVcorHHWx)
			{
				lock (jzFHXhdHGqAjbnrUbBWYPxavjDIJ)
				{
					jzFHXhdHGqAjbnrUbBWYPxavjDIJ.Reset();
					IiwCdbaRjlQVRtRCdZVcorHHWx.Reset();
				}
			}
		}

		private void CtKxyBSLFoKhfnquZkmRNhCvxmt()
		{
			lock (IiwCdbaRjlQVRtRCdZVcorHHWx)
			{
				lock (jzFHXhdHGqAjbnrUbBWYPxavjDIJ)
				{
					MiscTools.Swap(ref IiwCdbaRjlQVRtRCdZVcorHHWx, ref jzFHXhdHGqAjbnrUbBWYPxavjDIJ);
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~DualRingReportBuffer()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (!xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				xRygqjRmTtURDPiwlgMmFcdNBrr = true;
			}
		}
	}
}
