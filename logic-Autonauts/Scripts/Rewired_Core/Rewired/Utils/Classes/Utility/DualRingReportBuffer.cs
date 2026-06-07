using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class DualRingReportBuffer : IDisposable
	{
		private readonly int uEQndjxkxJUbwArdRlQPkovlfMN;

		private readonly int enfDQHvihPANsxdorCriiuagoXOC;

		private readonly int lMcJlKmAaEcdXEoviswcNpRVEnu;

		private NativeRingBuffer bJwuPgDYwvFcAgLwJECYyGRQvMQ;

		private NativeRingBuffer CyTNewZnvsWukYkteLpLRGCiPCf;

		private byte[] KXCbCabgLUtgoCJdmfWeGryyCIkH;

		private byte[] NYvOSzxRhSqIwdQkehfFcewmJUOT;

		private int oaohcnpkZyetucohCfSAyeBtbIzh;

		private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

		public int BufferLength
		{
			get
			{
				return uEQndjxkxJUbwArdRlQPkovlfMN;
			}
		}

		public int BytesInBuffer
		{
			get
			{
				return CyTNewZnvsWukYkteLpLRGCiPCf.BytesInBuffer;
			}
		}

		public int EntriesInBuffer
		{
			get
			{
				return CyTNewZnvsWukYkteLpLRGCiPCf.BytesInBuffer / enfDQHvihPANsxdorCriiuagoXOC;
			}
		}

		public byte[] ReadBuffer
		{
			get
			{
				return NYvOSzxRhSqIwdQkehfFcewmJUOT;
			}
		}

		public int LastNumBytesRead
		{
			get
			{
				return oaohcnpkZyetucohCfSAyeBtbIzh;
			}
		}

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
			enfDQHvihPANsxdorCriiuagoXOC = entryByteLength;
			lMcJlKmAaEcdXEoviswcNpRVEnu = entryCapacity;
			uEQndjxkxJUbwArdRlQPkovlfMN = entryByteLength * entryCapacity;
			bJwuPgDYwvFcAgLwJECYyGRQvMQ = new NativeRingBuffer(uEQndjxkxJUbwArdRlQPkovlfMN);
			CyTNewZnvsWukYkteLpLRGCiPCf = new NativeRingBuffer(uEQndjxkxJUbwArdRlQPkovlfMN);
			KXCbCabgLUtgoCJdmfWeGryyCIkH = new byte[entryByteLength];
			NYvOSzxRhSqIwdQkehfFcewmJUOT = new byte[entryByteLength];
		}

		public int StartRead()
		{
			pWCjWEsMswNNwInXWADOfFywZuYe();
			return CyTNewZnvsWukYkteLpLRGCiPCf.BytesInBuffer;
		}

		public int Read()
		{
			int result = 0;
			lock (CyTNewZnvsWukYkteLpLRGCiPCf)
			{
				result = CyTNewZnvsWukYkteLpLRGCiPCf.Read(NYvOSzxRhSqIwdQkehfFcewmJUOT, enfDQHvihPANsxdorCriiuagoXOC);
			}
			oaohcnpkZyetucohCfSAyeBtbIzh = result;
			return result;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			while (true)
			{
				int num;
				int num2;
				if (numBytesToRead < 0)
				{
					num = -388301159;
					num2 = num;
				}
				else
				{
					num = -388301160;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -388301158)
					{
					case 4:
						num = -388301157;
						continue;
					case 3:
						throw new ArgumentOutOfRangeException("numBytesToWrite");
					case 2:
					{
						int num3;
						if (numBytesToRead > buffer.Length)
						{
							num = -388301159;
							num3 = num;
						}
						else
						{
							num = -388301158;
							num3 = num;
						}
						continue;
					}
					case 1:
						break;
					default:
					{
						int result = 0;
						lock (CyTNewZnvsWukYkteLpLRGCiPCf)
						{
							result = CyTNewZnvsWukYkteLpLRGCiPCf.Read(buffer, numBytesToRead);
						}
						oaohcnpkZyetucohCfSAyeBtbIzh = result;
						return result;
					}
					}
					break;
				}
			}
		}

		public int Read(IntPtr buffer, int bufferLength, int numBytesToRead)
		{
			if (buffer == IntPtr.Zero)
			{
				goto IL_000d;
			}
			goto IL_0062;
			IL_000d:
			int num = -550445537;
			goto IL_0012;
			IL_0012:
			switch (num ^ -550445541)
			{
			case 0:
				break;
			case 2:
				goto IL_0037;
			case 1:
				goto IL_0049;
			case 3:
				goto IL_0062;
			case 4:
				throw new ArgumentNullException("buffer");
			default:
			{
				int result = 0;
				lock (CyTNewZnvsWukYkteLpLRGCiPCf)
				{
					result = CyTNewZnvsWukYkteLpLRGCiPCf.Read(buffer, bufferLength, bufferLength);
				}
				oaohcnpkZyetucohCfSAyeBtbIzh = result;
				return result;
			}
			}
			goto IL_000d;
			IL_0062:
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength");
			}
			goto IL_0049;
			IL_0049:
			if (numBytesToRead >= 0)
			{
				int num2;
				if (numBytesToRead > bufferLength)
				{
					num = -550445543;
					num2 = num;
				}
				else
				{
					num = -550445538;
					num2 = num;
				}
				goto IL_0012;
			}
			goto IL_0037;
			IL_0037:
			throw new ArgumentOutOfRangeException("numBytesToWrite");
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
				if (numBytesToWrite <= buffer.Length)
				{
					num = -61024354;
					num2 = num;
				}
				else
				{
					num = -61024355;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -61024355)
					{
					case 2:
						num = -61024356;
						continue;
					case 1:
						break;
					case 0:
						goto end_IL_0030;
					default:
					{
						int num3 = 0;
						lock (bJwuPgDYwvFcAgLwJECYyGRQvMQ)
						{
							return bJwuPgDYwvFcAgLwJECYyGRQvMQ.Write(buffer, numBytesToWrite);
						}
					}
					}
					break;
				}
				continue;
				end_IL_0030:
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
			goto IL_004d;
			IL_000d:
			int num = -613301521;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -613301522)
				{
				case 5:
					break;
				case 6:
					goto IL_003b;
				case 3:
					goto IL_004d;
				case 2:
				{
					int num2 = 0;
					num = -613301522;
					continue;
				}
				case 1:
					throw new ArgumentNullException("buffer");
				case 4:
					goto IL_007e;
				default:
					lock (bJwuPgDYwvFcAgLwJECYyGRQvMQ)
					{
						return bJwuPgDYwvFcAgLwJECYyGRQvMQ.Write(buffer, bufferLength, numBytesToWrite);
					}
				}
				break;
			}
			goto IL_000d;
			IL_003b:
			throw new ArgumentOutOfRangeException("numBytesToWrite");
			IL_007e:
			if (numBytesToWrite >= 0)
			{
				int num3;
				if (numBytesToWrite > bufferLength)
				{
					num = -613301528;
					num3 = num;
				}
				else
				{
					num = -613301524;
					num3 = num;
				}
				goto IL_0012;
			}
			goto IL_003b;
			IL_004d:
			if (bufferLength <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferLength");
			}
			goto IL_007e;
		}

		public void Clear()
		{
			lock (bJwuPgDYwvFcAgLwJECYyGRQvMQ)
			{
				lock (CyTNewZnvsWukYkteLpLRGCiPCf)
				{
					CyTNewZnvsWukYkteLpLRGCiPCf.Reset();
					bJwuPgDYwvFcAgLwJECYyGRQvMQ.Reset();
				}
			}
		}

		private void pWCjWEsMswNNwInXWADOfFywZuYe()
		{
			lock (bJwuPgDYwvFcAgLwJECYyGRQvMQ)
			{
				lock (CyTNewZnvsWukYkteLpLRGCiPCf)
				{
					MiscTools.Swap(ref bJwuPgDYwvFcAgLwJECYyGRQvMQ, ref CyTNewZnvsWukYkteLpLRGCiPCf);
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~DualRingReportBuffer()
		{
			Dispose(false);
		}

		protected void Dispose(bool disposing)
		{
			if (!QQqHByfwytAJSuMZiCPjJlZYHKG)
			{
				QQqHByfwytAJSuMZiCPjJlZYHKG = true;
			}
		}
	}
}
