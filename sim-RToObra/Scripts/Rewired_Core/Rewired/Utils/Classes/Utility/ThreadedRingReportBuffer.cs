using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadedRingReportBuffer : IDisposable
	{
		private readonly int JsWqLyRAcXhZNkLsxjuBXfwhmWA;

		private readonly int LnpURUNqdBexZJerDrDoTzgqArD;

		private readonly int IMsCkPUMiKIpmqJuQyxgwOBBeab;

		private readonly int WBfvgaxdsNQFSvGwNIGecXShaC;

		private readonly int iYosAjSwJnvFygvFveTRTutbdyr;

		private readonly bool NSdSEgHftreGfBRvWNZBErWjlCaJ;

		private ThreadHelper xgExdbVyAKUPeHviEQuSfAnlZIs;

		private NativeRingBuffer AgaeOzbnwbZTnLCldFCURFLGqBPs;

		private NativeRingBuffer tOVIzhfcpcXHPgxsMptNgxCoFTu;

		private Action<byte[]> fWOLPfcJcvIHKctHYYXrxCtjNLL;

		private byte[] jJSRcrVdTSEDJiIcYIAoKWwasXv;

		private byte[] yklJZkXNbOufRZLvWdjJCNuimLZL;

		private bool ZtgCzKdfGSWUWDTDXtkdTKMjYBN;

		private bool PkVqugVNIpoYIMpSDcpjdJRrnVs;

		private int VjumbiPgFmcOBdQukCYWmRDjfVeK;

		private bool vsurYtRlepcrpAzAENwjqjJEZPT;

		public bool IsRunning
		{
			get
			{
				return xgExdbVyAKUPeHviEQuSfAnlZIs.isRunning;
			}
		}

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

		public ThreadedRingReportBuffer(int entryByteLength, int entryCapacity, int threadRefreshRateFPS, int threadAutoKillTimeoutMS, bool threadBlockOnStartAndStop, Action<byte[]> threadRetrieveDataDelegate)
		{
			if (entryByteLength <= 0)
			{
				throw new ArgumentOutOfRangeException("entryByteLength must be > 0.");
			}
			if (entryCapacity < 1)
			{
				throw new ArgumentOutOfRangeException("entryCapacity must be >= 1.");
			}
			if (threadRefreshRateFPS < 0)
			{
				threadRefreshRateFPS = 0;
			}
			if (threadAutoKillTimeoutMS < 0)
			{
				threadAutoKillTimeoutMS = 0;
			}
			if (threadRetrieveDataDelegate == null)
			{
				throw new ArgumentNullException("threadRetrieveDataDelegate");
			}
			LnpURUNqdBexZJerDrDoTzgqArD = entryByteLength;
			IMsCkPUMiKIpmqJuQyxgwOBBeab = entryCapacity;
			JsWqLyRAcXhZNkLsxjuBXfwhmWA = entryByteLength * entryCapacity;
			WBfvgaxdsNQFSvGwNIGecXShaC = threadRefreshRateFPS;
			iYosAjSwJnvFygvFveTRTutbdyr = threadAutoKillTimeoutMS;
			NSdSEgHftreGfBRvWNZBErWjlCaJ = threadBlockOnStartAndStop;
			fWOLPfcJcvIHKctHYYXrxCtjNLL = threadRetrieveDataDelegate;
			AgaeOzbnwbZTnLCldFCURFLGqBPs = new NativeRingBuffer(JsWqLyRAcXhZNkLsxjuBXfwhmWA);
			tOVIzhfcpcXHPgxsMptNgxCoFTu = new NativeRingBuffer(JsWqLyRAcXhZNkLsxjuBXfwhmWA);
			jJSRcrVdTSEDJiIcYIAoKWwasXv = new byte[entryByteLength];
			yklJZkXNbOufRZLvWdjJCNuimLZL = new byte[entryByteLength];
			if (!PQSWvFQilTgIeaqvfFMnhhGbNgSO())
			{
				throw new Exception("Could not initialize thread.");
			}
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

		public int Read(byte[] buffer)
		{
			if (buffer == null)
			{
				while (true)
				{
					switch (0x646648B7 ^ 0x646648B5)
					{
					case 0:
						continue;
					case 2:
						throw new ArgumentNullException("buffer");
					}
					break;
				}
			}
			int num = 0;
			lock (tOVIzhfcpcXHPgxsMptNgxCoFTu)
			{
				num = tOVIzhfcpcXHPgxsMptNgxCoFTu.Read(buffer, buffer.Length);
			}
			VjumbiPgFmcOBdQukCYWmRDjfVeK = num;
			return num;
		}

		public int Read(IntPtr buffer, int bufferLength)
		{
			if (buffer == IntPtr.Zero)
			{
				goto IL_000d;
			}
			goto IL_0057;
			IL_000d:
			int num = 82955094;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x4F1CB54)
			{
			case 0:
				break;
			case 2:
				throw new ArgumentNullException("buffer");
			case 4:
				throw new ArgumentOutOfRangeException("bufferLength");
			case 3:
				goto IL_0057;
			default:
			{
				int num2 = 0;
				lock (tOVIzhfcpcXHPgxsMptNgxCoFTu)
				{
					num2 = tOVIzhfcpcXHPgxsMptNgxCoFTu.Read(buffer, bufferLength, bufferLength);
				}
				VjumbiPgFmcOBdQukCYWmRDjfVeK = num2;
				return num2;
			}
			}
			goto IL_000d;
			IL_0057:
			int num3;
			if (bufferLength > 0)
			{
				num = 82955093;
				num3 = num;
			}
			else
			{
				num = 82955088;
				num3 = num;
			}
			goto IL_0012;
		}

		public int StartRead()
		{
			GgIqVHSIgmpaDqRKoxJUqmgcpzL();
			return tOVIzhfcpcXHPgxsMptNgxCoFTu.BytesInBuffer;
		}

		public void StartThread()
		{
			if (xgExdbVyAKUPeHviEQuSfAnlZIs.isRunning)
			{
				return;
			}
			try
			{
				xgExdbVyAKUPeHviEQuSfAnlZIs.Start(NSdSEgHftreGfBRvWNZBErWjlCaJ);
			}
			catch
			{
			}
		}

		public void StopThread()
		{
			if (xgExdbVyAKUPeHviEQuSfAnlZIs.isStopped)
			{
				return;
			}
			try
			{
				xgExdbVyAKUPeHviEQuSfAnlZIs.Stop(NSdSEgHftreGfBRvWNZBErWjlCaJ);
			}
			catch
			{
			}
		}

		private bool PQSWvFQilTgIeaqvfFMnhhGbNgSO()
		{
			if (ZtgCzKdfGSWUWDTDXtkdTKMjYBN)
			{
				return false;
			}
			if (!XwuqsUGexhhAYMAeLaSYinCpSZhc())
			{
				return false;
			}
			if (PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				return true;
			}
			PkVqugVNIpoYIMpSDcpjdJRrnVs = true;
			return true;
		}

		private bool XwuqsUGexhhAYMAeLaSYinCpSZhc()
		{
			if (ZtgCzKdfGSWUWDTDXtkdTKMjYBN)
			{
				return false;
			}
			if (xgExdbVyAKUPeHviEQuSfAnlZIs == null)
			{
				bool result = default(bool);
				try
				{
					xgExdbVyAKUPeHviEQuSfAnlZIs = ThreadHelper.CreateFixedTimeStep(WBfvgaxdsNQFSvGwNIGecXShaC, iYosAjSwJnvFygvFveTRTutbdyr);
					while (true)
					{
						IL_002c:
						int num = -1763539869;
						while (true)
						{
							switch (num ^ -1763539870)
							{
							case 2:
								break;
							default:
								goto end_IL_0031;
							case 1:
								goto IL_004a;
							case 0:
								goto end_IL_0031;
							}
							goto IL_002c;
							IL_004a:
							xgExdbVyAKUPeHviEQuSfAnlZIs.ThreadUpdateEvent += NdOsURLOPikvHKCYeQXLzgkLJhk;
							result = true;
							num = -1763539870;
							continue;
							end_IL_0031:
							break;
						}
						break;
					}
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, true);
					if (xgExdbVyAKUPeHviEQuSfAnlZIs != null)
					{
						xgExdbVyAKUPeHviEQuSfAnlZIs.Stop(NSdSEgHftreGfBRvWNZBErWjlCaJ);
						goto IL_009a;
					}
					goto IL_00b8;
					IL_00b8:
					ZtgCzKdfGSWUWDTDXtkdTKMjYBN = true;
					result = false;
					int num2 = -1763539869;
					goto IL_009f;
					IL_009a:
					num2 = -1763539872;
					goto IL_009f;
					IL_009f:
					switch (num2 ^ -1763539870)
					{
					case 0:
						break;
					default:
						goto end_IL_006f;
					case 2:
						goto IL_00b8;
					case 1:
						goto end_IL_006f;
					}
					goto IL_009a;
					end_IL_006f:;
				}
				return result;
			}
			if (!xgExdbVyAKUPeHviEQuSfAnlZIs.isRunning)
			{
				xgExdbVyAKUPeHviEQuSfAnlZIs.Start(NSdSEgHftreGfBRvWNZBErWjlCaJ);
			}
			else
			{
				while (iYosAjSwJnvFygvFveTRTutbdyr > 0)
				{
					xgExdbVyAKUPeHviEQuSfAnlZIs.ResetTimeout();
					int num3 = -1763539869;
					while (true)
					{
						switch (num3 ^ -1763539870)
						{
						case 0:
							num3 = -1763539872;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0109;
						}
						break;
					}
					continue;
					end_IL_0109:
					break;
				}
			}
			return true;
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

		private void NdOsURLOPikvHKCYeQXLzgkLJhk()
		{
			try
			{
				lock (AgaeOzbnwbZTnLCldFCURFLGqBPs)
				{
					fWOLPfcJcvIHKctHYYXrxCtjNLL(jJSRcrVdTSEDJiIcYIAoKWwasXv);
					AgaeOzbnwbZTnLCldFCURFLGqBPs.Write(jJSRcrVdTSEDJiIcYIAoKWwasXv, LnpURUNqdBexZJerDrDoTzgqArD);
				}
			}
			catch
			{
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~ThreadedRingReportBuffer()
		{
			Dispose(false);
		}

		protected void Dispose(bool disposing)
		{
			if (vsurYtRlepcrpAzAENwjqjJEZPT)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!disposing)
				{
					num = 168872484;
					num2 = num;
				}
				else
				{
					num = 168872485;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0xA10CA26)
					{
					case 0:
						num = 168872487;
						continue;
					case 1:
						break;
					case 3:
						if (xgExdbVyAKUPeHviEQuSfAnlZIs != null)
						{
							xgExdbVyAKUPeHviEQuSfAnlZIs.Dispose();
							num = 168872484;
							continue;
						}
						goto default;
					default:
						vsurYtRlepcrpAzAENwjqjJEZPT = true;
						return;
					}
					break;
				}
			}
		}
	}
}
