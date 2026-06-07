using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadedRingReportBuffer : IDisposable
	{
		private readonly int uEQndjxkxJUbwArdRlQPkovlfMN;

		private readonly int enfDQHvihPANsxdorCriiuagoXOC;

		private readonly int lMcJlKmAaEcdXEoviswcNpRVEnu;

		private readonly int deLcfxQlroiAwsAsCJOMDFkGkjJ;

		private readonly int BhgKHqwvPnugDUlQDnPLiEjtppk;

		private readonly bool mplcBthrvxLxQAfoAaPHNYOjnNlQ;

		private ThreadHelper CogoXqfgoUvretoPEYaoWIkbAAZ;

		private NativeRingBuffer bJwuPgDYwvFcAgLwJECYyGRQvMQ;

		private NativeRingBuffer CyTNewZnvsWukYkteLpLRGCiPCf;

		private Action<byte[]> IeKUEsMuqhhxvOSLqIGrAelhMJI;

		private byte[] KXCbCabgLUtgoCJdmfWeGryyCIkH;

		private byte[] NYvOSzxRhSqIwdQkehfFcewmJUOT;

		private bool iGaqCHVEOQgpbvJMvjetJqAnxOU;

		private bool uvRIxvvRCxrfpiSXpAlvYqJtnEz;

		private int oaohcnpkZyetucohCfSAyeBtbIzh;

		private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

		public bool IsRunning
		{
			get
			{
				return CogoXqfgoUvretoPEYaoWIkbAAZ.isRunning;
			}
		}

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
			enfDQHvihPANsxdorCriiuagoXOC = entryByteLength;
			lMcJlKmAaEcdXEoviswcNpRVEnu = entryCapacity;
			uEQndjxkxJUbwArdRlQPkovlfMN = entryByteLength * entryCapacity;
			deLcfxQlroiAwsAsCJOMDFkGkjJ = threadRefreshRateFPS;
			BhgKHqwvPnugDUlQDnPLiEjtppk = threadAutoKillTimeoutMS;
			mplcBthrvxLxQAfoAaPHNYOjnNlQ = threadBlockOnStartAndStop;
			IeKUEsMuqhhxvOSLqIGrAelhMJI = threadRetrieveDataDelegate;
			bJwuPgDYwvFcAgLwJECYyGRQvMQ = new NativeRingBuffer(uEQndjxkxJUbwArdRlQPkovlfMN);
			CyTNewZnvsWukYkteLpLRGCiPCf = new NativeRingBuffer(uEQndjxkxJUbwArdRlQPkovlfMN);
			KXCbCabgLUtgoCJdmfWeGryyCIkH = new byte[entryByteLength];
			NYvOSzxRhSqIwdQkehfFcewmJUOT = new byte[entryByteLength];
			if (!uQEBmSjyfRHnLAGcBmMfKMKLWzNM())
			{
				throw new Exception("Could not initialize thread.");
			}
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

		public int Read(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			int result = 0;
			lock (CyTNewZnvsWukYkteLpLRGCiPCf)
			{
				result = CyTNewZnvsWukYkteLpLRGCiPCf.Read(buffer, buffer.Length);
			}
			oaohcnpkZyetucohCfSAyeBtbIzh = result;
			return result;
		}

		public int Read(IntPtr buffer, int bufferLength)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			while (bufferLength > 0)
			{
				while (true)
				{
					IL_0050:
					int result = 0;
					int num = -1537475100;
					while (true)
					{
						switch (num ^ -1537475098)
						{
						case 0:
							num = -1537475099;
							continue;
						case 3:
							break;
						case 1:
							goto IL_0050;
						default:
							lock (CyTNewZnvsWukYkteLpLRGCiPCf)
							{
								result = CyTNewZnvsWukYkteLpLRGCiPCf.Read(buffer, bufferLength, bufferLength);
							}
							oaohcnpkZyetucohCfSAyeBtbIzh = result;
							return result;
						}
						break;
					}
					break;
				}
			}
			throw new ArgumentOutOfRangeException("bufferLength");
		}

		public int StartRead()
		{
			pWCjWEsMswNNwInXWADOfFywZuYe();
			return CyTNewZnvsWukYkteLpLRGCiPCf.BytesInBuffer;
		}

		public void StartThread()
		{
			if (CogoXqfgoUvretoPEYaoWIkbAAZ.isRunning)
			{
				return;
			}
			try
			{
				CogoXqfgoUvretoPEYaoWIkbAAZ.Start(mplcBthrvxLxQAfoAaPHNYOjnNlQ);
			}
			catch
			{
			}
		}

		public void StopThread()
		{
			if (CogoXqfgoUvretoPEYaoWIkbAAZ.isStopped)
			{
				return;
			}
			try
			{
				CogoXqfgoUvretoPEYaoWIkbAAZ.Stop(mplcBthrvxLxQAfoAaPHNYOjnNlQ);
			}
			catch
			{
			}
		}

		private bool uQEBmSjyfRHnLAGcBmMfKMKLWzNM()
		{
			if (iGaqCHVEOQgpbvJMvjetJqAnxOU)
			{
				return false;
			}
			if (!ymkrTVsttbjnneijraQGWqGdeWaf())
			{
				return false;
			}
			if (uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				return true;
			}
			uvRIxvvRCxrfpiSXpAlvYqJtnEz = true;
			return true;
		}

		private bool ymkrTVsttbjnneijraQGWqGdeWaf()
		{
			if (iGaqCHVEOQgpbvJMvjetJqAnxOU)
			{
				return false;
			}
			if (CogoXqfgoUvretoPEYaoWIkbAAZ == null)
			{
				bool result = default(bool);
				try
				{
					CogoXqfgoUvretoPEYaoWIkbAAZ = ThreadHelper.CreateFixedTimeStep(deLcfxQlroiAwsAsCJOMDFkGkjJ, BhgKHqwvPnugDUlQDnPLiEjtppk);
					CogoXqfgoUvretoPEYaoWIkbAAZ.ThreadUpdateEvent += eASDrYzhBmVRwaVPOObNEmaDUuh;
					result = true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, true);
					if (CogoXqfgoUvretoPEYaoWIkbAAZ != null)
					{
						CogoXqfgoUvretoPEYaoWIkbAAZ.Stop(mplcBthrvxLxQAfoAaPHNYOjnNlQ);
						goto IL_0075;
					}
					goto IL_0097;
					IL_0097:
					iGaqCHVEOQgpbvJMvjetJqAnxOU = true;
					int num = 2053036426;
					goto IL_007a;
					IL_0075:
					num = 2053036425;
					goto IL_007a;
					IL_007a:
					while (true)
					{
						switch (num ^ 0x7A5ED98A)
						{
						case 2:
							break;
						default:
							goto end_IL_004a;
						case 3:
							goto IL_0097;
						case 0:
							result = false;
							num = 2053036427;
							continue;
						case 1:
							goto end_IL_004a;
						}
						break;
					}
					goto IL_0075;
					end_IL_004a:;
				}
				return result;
			}
			if (!CogoXqfgoUvretoPEYaoWIkbAAZ.isRunning)
			{
				CogoXqfgoUvretoPEYaoWIkbAAZ.Start(mplcBthrvxLxQAfoAaPHNYOjnNlQ);
			}
			else
			{
				while (BhgKHqwvPnugDUlQDnPLiEjtppk > 0)
				{
					CogoXqfgoUvretoPEYaoWIkbAAZ.ResetTimeout();
					int num2 = 2053036424;
					while (true)
					{
						switch (num2 ^ 0x7A5ED98A)
						{
						case 0:
							num2 = 2053036427;
							continue;
						case 1:
							break;
						default:
							goto end_IL_00ef;
						}
						break;
					}
					continue;
					end_IL_00ef:
					break;
				}
			}
			return true;
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

		private void eASDrYzhBmVRwaVPOObNEmaDUuh()
		{
			try
			{
				lock (bJwuPgDYwvFcAgLwJECYyGRQvMQ)
				{
					IeKUEsMuqhhxvOSLqIGrAelhMJI(KXCbCabgLUtgoCJdmfWeGryyCIkH);
					bJwuPgDYwvFcAgLwJECYyGRQvMQ.Write(KXCbCabgLUtgoCJdmfWeGryyCIkH, enfDQHvihPANsxdorCriiuagoXOC);
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
			if (QQqHByfwytAJSuMZiCPjJlZYHKG)
			{
				return;
			}
			while (disposing)
			{
				int num;
				int num2;
				if (CogoXqfgoUvretoPEYaoWIkbAAZ != null)
				{
					num = -1334321857;
					num2 = num;
				}
				else
				{
					num = -1334321859;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1334321860)
					{
					case 0:
						num = -1334321858;
						continue;
					case 2:
						break;
					case 3:
						CogoXqfgoUvretoPEYaoWIkbAAZ.Dispose();
						num = -1334321859;
						continue;
					default:
						goto end_IL_002b;
					}
					break;
				}
				continue;
				end_IL_002b:
				break;
			}
			QQqHByfwytAJSuMZiCPjJlZYHKG = true;
		}
	}
}
