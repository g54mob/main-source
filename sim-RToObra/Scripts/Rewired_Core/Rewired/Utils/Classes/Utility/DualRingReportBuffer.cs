using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class DualRingReportBuffer : IDisposable
	{
		private readonly int JsWqLyRAcXhZNkLsxjuBXfwhmWA;

		private readonly int LnpURUNqdBexZJerDrDoTzgqArD;

		private readonly int IMsCkPUMiKIpmqJuQyxgwOBBeab;

		private NativeRingBuffer AgaeOzbnwbZTnLCldFCURFLGqBPs;

		private NativeRingBuffer tOVIzhfcpcXHPgxsMptNgxCoFTu;

		private byte[] jJSRcrVdTSEDJiIcYIAoKWwasXv;

		private byte[] yklJZkXNbOufRZLvWdjJCNuimLZL;

		private int VjumbiPgFmcOBdQukCYWmRDjfVeK;

		private bool vsurYtRlepcrpAzAENwjqjJEZPT;

		public int BufferLength
		{
			get
			{
				return JsWqLyRAcXhZNkLsxjuBXfwhmWA;
			}
		}

		public int BytesInBuffer
		{
			get
			{
				return tOVIzhfcpcXHPgxsMptNgxCoFTu.BytesInBuffer;
			}
		}

		public int EntriesInBuffer
		{
			get
			{
				return tOVIzhfcpcXHPgxsMptNgxCoFTu.BytesInBuffer / LnpURUNqdBexZJerDrDoTzgqArD;
			}
		}

		public byte[] ReadBuffer
		{
			get
			{
				return yklJZkXNbOufRZLvWdjJCNuimLZL;
			}
		}

		public int LastNumBytesRead
		{
			get
			{
				return VjumbiPgFmcOBdQukCYWmRDjfVeK;
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
			LnpURUNqdBexZJerDrDoTzgqArD = entryByteLength;
			IMsCkPUMiKIpmqJuQyxgwOBBeab = entryCapacity;
			JsWqLyRAcXhZNkLsxjuBXfwhmWA = entryByteLength * entryCapacity;
			AgaeOzbnwbZTnLCldFCURFLGqBPs = new NativeRingBuffer(JsWqLyRAcXhZNkLsxjuBXfwhmWA);
			tOVIzhfcpcXHPgxsMptNgxCoFTu = new NativeRingBuffer(JsWqLyRAcXhZNkLsxjuBXfwhmWA);
			jJSRcrVdTSEDJiIcYIAoKWwasXv = new byte[entryByteLength];
			yklJZkXNbOufRZLvWdjJCNuimLZL = new byte[entryByteLength];
		}

		public int StartRead()
		{
			GgIqVHSIgmpaDqRKoxJUqmgcpzL();
			return tOVIzhfcpcXHPgxsMptNgxCoFTu.BytesInBuffer;
		}

		public int Read()
		{
			int num = 0;
			lock (tOVIzhfcpcXHPgxsMptNgxCoFTu)
			{
				num = tOVIzhfcpcXHPgxsMptNgxCoFTu.Read(yklJZkXNbOufRZLvWdjJCNuimLZL, LnpURUNqdBexZJerDrDoTzgqArD);
			}
			VjumbiPgFmcOBdQukCYWmRDjfVeK = num;
			return num;
		}

		public int Read(byte[] buffer, int numBytesToRead)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			while (numBytesToRead >= 0)
			{
				int num;
				int num2;
				if (numBytesToRead > buffer.Length)
				{
					num = 406493263;
					num2 = num;
				}
				else
				{
					num = 406493262;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x183A984F)
					{
					case 2:
						num = 406493260;
						continue;
					case 3:
						break;
					case 0:
						goto end_IL_0030;
					default:
					{
						int num3 = 0;
						lock (tOVIzhfcpcXHPgxsMptNgxCoFTu)
						{
							num3 = tOVIzhfcpcXHPgxsMptNgxCoFTu.Read(buffer, numBytesToRead);
						}
						VjumbiPgFmcOBdQukCYWmRDjfVeK = num3;
						return num3;
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
					int num;
					int num2;
					if (numBytesToRead < 0)
					{
						num = 1776545547;
						num2 = num;
					}
					else
					{
						num = 1776545550;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x69E3EF0F)
						{
						case 2:
							num = 1776545548;
							continue;
						case 4:
							throw new ArgumentOutOfRangeException("numBytesToWrite");
						case 5:
							break;
						case 1:
							goto IL_0069;
						case 3:
							goto end_IL_0054;
						default:
						{
							int num3 = 0;
							lock (tOVIzhfcpcXHPgxsMptNgxCoFTu)
							{
								num3 = tOVIzhfcpcXHPgxsMptNgxCoFTu.Read(buffer, bufferLength, bufferLength);
							}
							VjumbiPgFmcOBdQukCYWmRDjfVeK = num3;
							return num3;
						}
						}
						break;
						IL_0069:
						int num4;
						if (numBytesToRead > bufferLength)
						{
							num = 1776545547;
							num4 = num;
						}
						else
						{
							num = 1776545551;
							num4 = num;
						}
					}
					continue;
					end_IL_0054:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("bufferLength");
		}

		public int Write(byte[] buffer, int numBytesToWrite)
		{
			if (buffer == null)
			{
				goto IL_0003;
			}
			goto IL_003f;
			IL_0003:
			int num = 1562516775;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ 0x5D221D22)
				{
				case 2:
					break;
				case 3:
					goto IL_002d;
				case 0:
					goto IL_003f;
				case 5:
					throw new ArgumentNullException("buffer");
				case 4:
				{
					int num2 = 0;
					num = 1562516771;
					continue;
				}
				default:
					lock (AgaeOzbnwbZTnLCldFCURFLGqBPs)
					{
						return AgaeOzbnwbZTnLCldFCURFLGqBPs.Write(buffer, numBytesToWrite);
					}
				}
				break;
			}
			goto IL_0003;
			IL_003f:
			if (numBytesToWrite >= 0)
			{
				int num3;
				if (numBytesToWrite > buffer.Length)
				{
					num = 1562516769;
					num3 = num;
				}
				else
				{
					num = 1562516774;
					num3 = num;
				}
				goto IL_0008;
			}
			goto IL_002d;
			IL_002d:
			throw new ArgumentOutOfRangeException("numBytesToWrite");
		}

		public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			while (bufferLength > 0)
			{
				while (true)
				{
					IL_0054:
					if (numBytesToWrite >= 0)
					{
						int num;
						int num2;
						if (numBytesToWrite <= bufferLength)
						{
							num = -1765663966;
							num2 = num;
						}
						else
						{
							num = -1765663968;
							num2 = num;
						}
						while (true)
						{
							switch (num ^ -1765663968)
							{
							case 3:
								num = -1765663964;
								continue;
							case 4:
								break;
							case 1:
								goto IL_0054;
							case 0:
								goto IL_006d;
							default:
							{
								int num3 = 0;
								lock (AgaeOzbnwbZTnLCldFCURFLGqBPs)
								{
									return AgaeOzbnwbZTnLCldFCURFLGqBPs.Write(buffer, bufferLength, numBytesToWrite);
								}
							}
							}
							break;
						}
						break;
					}
					goto IL_006d;
					IL_006d:
					throw new ArgumentOutOfRangeException("numBytesToWrite");
				}
			}
			throw new ArgumentOutOfRangeException("bufferLength");
		}

		public void Clear()
		{
			lock (AgaeOzbnwbZTnLCldFCURFLGqBPs)
			{
				lock (tOVIzhfcpcXHPgxsMptNgxCoFTu)
				{
					tOVIzhfcpcXHPgxsMptNgxCoFTu.Reset();
					AgaeOzbnwbZTnLCldFCURFLGqBPs.Reset();
				}
			}
		}

		private void GgIqVHSIgmpaDqRKoxJUqmgcpzL()
		{
			lock (AgaeOzbnwbZTnLCldFCURFLGqBPs)
			{
				lock (tOVIzhfcpcXHPgxsMptNgxCoFTu)
				{
					MiscTools.Swap(ref AgaeOzbnwbZTnLCldFCURFLGqBPs, ref tOVIzhfcpcXHPgxsMptNgxCoFTu);
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
			if (vsurYtRlepcrpAzAENwjqjJEZPT)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = 1455560829;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x56C2187E)
			{
			case 0:
				break;
			case 3:
				return;
			case 1:
				goto IL_0032;
			default:
				vsurYtRlepcrpAzAENwjqjJEZPT = true;
				return;
			}
			goto IL_0008;
			IL_0032:
			num = 1455560828;
			goto IL_000d;
		}
	}
}
