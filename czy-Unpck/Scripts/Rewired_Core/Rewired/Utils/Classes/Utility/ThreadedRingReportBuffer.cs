using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadedRingReportBuffer : IDisposable
	{
		private readonly int PGQxIwPgTNdLhCbGCnYEAqYmOase;

		private readonly int TrxmuWLLUVWUdIURguCfiBGxIMbi;

		private readonly int AQalwRKuRMLyYpBOfgNfFhvQmaB;

		private readonly int UgFDRccxOgyjhNuDLEeHJsMXlni;

		private readonly int mHwabdAZablQMrebUDyEmRPykqH;

		private readonly bool DnhmbaJJCdyuFSTPhmbCGBmwJAC;

		private ThreadHelper fqsCBjdBBAqwxHGTJtzpEGieeHqQ;

		private NativeRingBuffer IiwCdbaRjlQVRtRCdZVcorHHWx;

		private NativeRingBuffer jzFHXhdHGqAjbnrUbBWYPxavjDIJ;

		private Action<byte[]> llMzphuqFxpmovihvNlsIeJkfPxg;

		private byte[] dxApbfTEcCttxzoIdWjxzuEvoRH;

		private byte[] oUdAvcHQOWPVhSIBlUQColKnkBl;

		private bool HFkKVChhvESkmWpzwPLuarkiTPt;

		private bool PwPWygBTznyByBIyaAyqEfnsXBM;

		private int RwoTfmHnmiacfRZAXlaJmyvqPrG;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public bool IsRunning => fqsCBjdBBAqwxHGTJtzpEGieeHqQ.isRunning;

		public int BufferLength => PGQxIwPgTNdLhCbGCnYEAqYmOase;

		public int BytesInBuffer => jzFHXhdHGqAjbnrUbBWYPxavjDIJ.BytesInBuffer;

		public int EntriesInBuffer => jzFHXhdHGqAjbnrUbBWYPxavjDIJ.BytesInBuffer / TrxmuWLLUVWUdIURguCfiBGxIMbi;

		public byte[] ReadBuffer => oUdAvcHQOWPVhSIBlUQColKnkBl;

		public int LastNumBytesRead => RwoTfmHnmiacfRZAXlaJmyvqPrG;

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
			TrxmuWLLUVWUdIURguCfiBGxIMbi = entryByteLength;
			AQalwRKuRMLyYpBOfgNfFhvQmaB = entryCapacity;
			PGQxIwPgTNdLhCbGCnYEAqYmOase = entryByteLength * entryCapacity;
			UgFDRccxOgyjhNuDLEeHJsMXlni = threadRefreshRateFPS;
			mHwabdAZablQMrebUDyEmRPykqH = threadAutoKillTimeoutMS;
			DnhmbaJJCdyuFSTPhmbCGBmwJAC = threadBlockOnStartAndStop;
			llMzphuqFxpmovihvNlsIeJkfPxg = threadRetrieveDataDelegate;
			IiwCdbaRjlQVRtRCdZVcorHHWx = new NativeRingBuffer(PGQxIwPgTNdLhCbGCnYEAqYmOase);
			jzFHXhdHGqAjbnrUbBWYPxavjDIJ = new NativeRingBuffer(PGQxIwPgTNdLhCbGCnYEAqYmOase);
			dxApbfTEcCttxzoIdWjxzuEvoRH = new byte[entryByteLength];
			oUdAvcHQOWPVhSIBlUQColKnkBl = new byte[entryByteLength];
			if (!POOLsDGSQBqeMtHOQtJgSqyMaxe())
			{
				throw new Exception("Could not initialize thread.");
			}
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

		public int Read(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			while (true)
			{
				int num = 0;
				int num2 = 32803836;
				while (true)
				{
					switch (num2 ^ 0x1F48BFD)
					{
					case 0:
						goto IL_000e;
					case 2:
						break;
					default:
						lock (jzFHXhdHGqAjbnrUbBWYPxavjDIJ)
						{
							num = jzFHXhdHGqAjbnrUbBWYPxavjDIJ.Read(buffer, buffer.Length);
						}
						RwoTfmHnmiacfRZAXlaJmyvqPrG = num;
						return num;
					}
					break;
					IL_000e:
					num2 = 32803839;
				}
			}
		}

		public int Read(IntPtr buffer, int bufferLength)
		{
			if (buffer == IntPtr.Zero)
			{
				throw new ArgumentNullException("buffer");
			}
			while (true)
			{
				int num;
				int num2;
				if (bufferLength > 0)
				{
					num = -1259111719;
					num2 = num;
				}
				else
				{
					num = -1259111720;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1259111717)
					{
					case 0:
						goto IL_0018;
					case 1:
						break;
					case 3:
						throw new ArgumentOutOfRangeException("bufferLength");
					default:
					{
						int num3 = 0;
						lock (jzFHXhdHGqAjbnrUbBWYPxavjDIJ)
						{
							num3 = jzFHXhdHGqAjbnrUbBWYPxavjDIJ.Read(buffer, bufferLength, bufferLength);
						}
						RwoTfmHnmiacfRZAXlaJmyvqPrG = num3;
						return num3;
					}
					}
					break;
					IL_0018:
					num = -1259111718;
				}
			}
		}

		public int StartRead()
		{
			CtKxyBSLFoKhfnquZkmRNhCvxmt();
			return jzFHXhdHGqAjbnrUbBWYPxavjDIJ.BytesInBuffer;
		}

		public void StartThread()
		{
			if (fqsCBjdBBAqwxHGTJtzpEGieeHqQ.isRunning)
			{
				return;
			}
			try
			{
				fqsCBjdBBAqwxHGTJtzpEGieeHqQ.Start(DnhmbaJJCdyuFSTPhmbCGBmwJAC);
			}
			catch
			{
			}
		}

		public void StopThread()
		{
			if (fqsCBjdBBAqwxHGTJtzpEGieeHqQ.isStopped)
			{
				return;
			}
			try
			{
				fqsCBjdBBAqwxHGTJtzpEGieeHqQ.Stop(DnhmbaJJCdyuFSTPhmbCGBmwJAC);
			}
			catch
			{
			}
		}

		private bool POOLsDGSQBqeMtHOQtJgSqyMaxe()
		{
			if (HFkKVChhvESkmWpzwPLuarkiTPt)
			{
				return false;
			}
			if (!BLojMYGzGzwkmTIAuatTfUggLHZd())
			{
				return false;
			}
			if (PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				return true;
			}
			PwPWygBTznyByBIyaAyqEfnsXBM = true;
			return true;
		}

		private bool BLojMYGzGzwkmTIAuatTfUggLHZd()
		{
			if (HFkKVChhvESkmWpzwPLuarkiTPt)
			{
				return false;
			}
			if (fqsCBjdBBAqwxHGTJtzpEGieeHqQ == null)
			{
				bool result = default(bool);
				try
				{
					fqsCBjdBBAqwxHGTJtzpEGieeHqQ = ThreadHelper.CreateFixedTimeStep(UgFDRccxOgyjhNuDLEeHJsMXlni, mHwabdAZablQMrebUDyEmRPykqH);
					fqsCBjdBBAqwxHGTJtzpEGieeHqQ.ThreadUpdateEvent += ReWtOZFlieWvrDhaFtwIYbSOiVM;
					result = true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (fqsCBjdBBAqwxHGTJtzpEGieeHqQ != null)
					{
						goto IL_0064;
					}
					goto IL_009e;
					IL_0064:
					int num = 1607486712;
					goto IL_0069;
					IL_0069:
					while (true)
					{
						switch (num ^ 0x5FD04CF9)
						{
						case 2:
							break;
						default:
							goto end_IL_004a;
						case 1:
							fqsCBjdBBAqwxHGTJtzpEGieeHqQ.Stop(DnhmbaJJCdyuFSTPhmbCGBmwJAC);
							num = 1607486713;
							continue;
						case 0:
							goto IL_009e;
						case 3:
							goto end_IL_004a;
						}
						break;
					}
					goto IL_0064;
					IL_009e:
					HFkKVChhvESkmWpzwPLuarkiTPt = true;
					result = false;
					num = 1607486714;
					goto IL_0069;
					end_IL_004a:;
				}
				return result;
			}
			if (!fqsCBjdBBAqwxHGTJtzpEGieeHqQ.isRunning)
			{
				goto IL_00bd;
			}
			goto IL_00e3;
			IL_00e3:
			int num2;
			if (mHwabdAZablQMrebUDyEmRPykqH > 0)
			{
				fqsCBjdBBAqwxHGTJtzpEGieeHqQ.ResetTimeout();
				num2 = 1607486717;
				goto IL_00c2;
			}
			goto IL_011e;
			IL_011e:
			return true;
			IL_00bd:
			num2 = 1607486712;
			goto IL_00c2;
			IL_00c2:
			while (true)
			{
				switch (num2 ^ 0x5FD04CF9)
				{
				case 3:
					break;
				case 0:
					goto IL_00e3;
				case 2:
					num2 = 1607486717;
					continue;
				case 1:
					fqsCBjdBBAqwxHGTJtzpEGieeHqQ.Start(DnhmbaJJCdyuFSTPhmbCGBmwJAC);
					num2 = 1607486715;
					continue;
				default:
					goto IL_011e;
				}
				break;
			}
			goto IL_00bd;
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

		private void ReWtOZFlieWvrDhaFtwIYbSOiVM()
		{
			try
			{
				lock (IiwCdbaRjlQVRtRCdZVcorHHWx)
				{
					llMzphuqFxpmovihvNlsIeJkfPxg(dxApbfTEcCttxzoIdWjxzuEvoRH);
					IiwCdbaRjlQVRtRCdZVcorHHWx.Write(dxApbfTEcCttxzoIdWjxzuEvoRH, TrxmuWLLUVWUdIURguCfiBGxIMbi);
				}
			}
			catch
			{
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~ThreadedRingReportBuffer()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				return;
			}
			while (disposing)
			{
				int num;
				int num2;
				if (fqsCBjdBBAqwxHGTJtzpEGieeHqQ != null)
				{
					num = 1408042126;
					num2 = num;
				}
				else
				{
					num = 1408042125;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x53ED048E)
					{
					case 2:
						num = 1408042127;
						continue;
					case 1:
						break;
					case 0:
						fqsCBjdBBAqwxHGTJtzpEGieeHqQ.Dispose();
						num = 1408042125;
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
			xRygqjRmTtURDPiwlgMmFcdNBrr = true;
		}
	}
}
