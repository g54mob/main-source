using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadedMessageQueue<T> : IDisposable
	{
		private readonly int xFYbAGEOpgEAQMtTqoiDWcMibwSfb;

		private readonly int ncNcgsiOFJreZImGRiysAcyzShMs;

		private readonly int LxHcWSlwvVdMsUCuNwlxPhDtqlZG;

		private readonly bool piVQtgioKTUQHLzHYvbcMbYQUoGl;

		private ThreadHelper zLlFdNeKWeggNHunWZNuniuFsEOH;

		private Queue<T> bGbIcpkufXABNxrkabAsjRcTJreg;

		private Queue<T> pPQDlKpVEJGlqKCVmOmtHciAONhb;

		private bool hIhquuXlLFxOOciWIKwPbcwSfyWAA;

		private bool dPsvffoZhhFbPGjkGwecMQBnGTNCA;

		private Action<T> MaXHBVBRhwLFpLUCRyfmCRGHhCBr;

		private bool TqgJbisKxFHQHneIhFLTKodLiTz;

		public ThreadedMessageQueue(int P_0, int P_1, int P_2, bool P_3, Action<T> P_4)
		{
			if (P_4 == null)
			{
				throw new ArgumentNullException("messageReceiverDelegate");
			}
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			if (P_1 < 0)
			{
				P_1 = 0;
			}
			if (P_2 < 0)
			{
				P_2 = 0;
			}
			xFYbAGEOpgEAQMtTqoiDWcMibwSfb = P_0;
			ncNcgsiOFJreZImGRiysAcyzShMs = P_1;
			LxHcWSlwvVdMsUCuNwlxPhDtqlZG = P_2;
			piVQtgioKTUQHLzHYvbcMbYQUoGl = P_3;
			MaXHBVBRhwLFpLUCRyfmCRGHhCBr = P_4;
			bGbIcpkufXABNxrkabAsjRcTJreg = new Queue<T>(P_0);
			pPQDlKpVEJGlqKCVmOmtHciAONhb = new Queue<T>(P_0);
		}

		public void Enqueue(T message)
		{
			if (!MaDQqRjUnWAwSRUmfhtepypiovLN())
			{
				return;
			}
			lock (bGbIcpkufXABNxrkabAsjRcTJreg)
			{
				if (xFYbAGEOpgEAQMtTqoiDWcMibwSfb > 0)
				{
					while (bGbIcpkufXABNxrkabAsjRcTJreg.Count >= xFYbAGEOpgEAQMtTqoiDWcMibwSfb)
					{
						bGbIcpkufXABNxrkabAsjRcTJreg.Dequeue();
					}
				}
				bGbIcpkufXABNxrkabAsjRcTJreg.Enqueue(message);
			}
		}

		private bool MaDQqRjUnWAwSRUmfhtepypiovLN()
		{
			if (hIhquuXlLFxOOciWIKwPbcwSfyWAA)
			{
				return false;
			}
			if (!yZtgzeyDuYtRjBkPxEBDWgByZNiP())
			{
				return false;
			}
			if (dPsvffoZhhFbPGjkGwecMQBnGTNCA)
			{
				return true;
			}
			dPsvffoZhhFbPGjkGwecMQBnGTNCA = true;
			return true;
		}

		private bool yZtgzeyDuYtRjBkPxEBDWgByZNiP()
		{
			if (hIhquuXlLFxOOciWIKwPbcwSfyWAA)
			{
				return false;
			}
			if (zLlFdNeKWeggNHunWZNuniuFsEOH == null)
			{
				try
				{
					zLlFdNeKWeggNHunWZNuniuFsEOH = ThreadHelper.CreateFixedTimeStep(ncNcgsiOFJreZImGRiysAcyzShMs, LxHcWSlwvVdMsUCuNwlxPhDtqlZG);
					zLlFdNeKWeggNHunWZNuniuFsEOH.ThreadUpdateEvent += cjINhTQBNaWAsAvpvOorqVYsoeXe;
					zLlFdNeKWeggNHunWZNuniuFsEOH.Start(piVQtgioKTUQHLzHYvbcMbYQUoGl);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (zLlFdNeKWeggNHunWZNuniuFsEOH != null)
					{
						zLlFdNeKWeggNHunWZNuniuFsEOH.Stop(piVQtgioKTUQHLzHYvbcMbYQUoGl);
					}
					hIhquuXlLFxOOciWIKwPbcwSfyWAA = true;
					return false;
				}
			}
			if (!zLlFdNeKWeggNHunWZNuniuFsEOH.isRunning)
			{
				zLlFdNeKWeggNHunWZNuniuFsEOH.Start(piVQtgioKTUQHLzHYvbcMbYQUoGl);
			}
			else if (LxHcWSlwvVdMsUCuNwlxPhDtqlZG > 0)
			{
				zLlFdNeKWeggNHunWZNuniuFsEOH.ResetTimeout();
			}
			return true;
		}

		private void emONfGWpCYvMCCjLNAIJHtwBNrbiA()
		{
			lock (bGbIcpkufXABNxrkabAsjRcTJreg)
			{
				lock (pPQDlKpVEJGlqKCVmOmtHciAONhb)
				{
					MiscTools.Swap(ref bGbIcpkufXABNxrkabAsjRcTJreg, ref pPQDlKpVEJGlqKCVmOmtHciAONhb);
				}
			}
		}

		private void cjINhTQBNaWAsAvpvOorqVYsoeXe()
		{
			emONfGWpCYvMCCjLNAIJHtwBNrbiA();
			lock (pPQDlKpVEJGlqKCVmOmtHciAONhb)
			{
				while (pPQDlKpVEJGlqKCVmOmtHciAONhb.Count > 0)
				{
					try
					{
						MaXHBVBRhwLFpLUCRyfmCRGHhCBr(pPQDlKpVEJGlqKCVmOmtHciAONhb.Dequeue());
					}
					catch (Exception ex)
					{
						Logger.LogError("An exception occurred while sending message.\nMessage: " + ex.Message, requiredThreadSafety: true);
					}
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~ThreadedMessageQueue()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (TqgJbisKxFHQHneIhFLTKodLiTz)
			{
				return;
			}
			if (disposing)
			{
				if (bGbIcpkufXABNxrkabAsjRcTJreg != null)
				{
					if (pPQDlKpVEJGlqKCVmOmtHciAONhb != null)
					{
						lock (bGbIcpkufXABNxrkabAsjRcTJreg)
						{
							lock (pPQDlKpVEJGlqKCVmOmtHciAONhb)
							{
								bGbIcpkufXABNxrkabAsjRcTJreg.Clear();
								pPQDlKpVEJGlqKCVmOmtHciAONhb.Clear();
							}
						}
					}
					else
					{
						lock (bGbIcpkufXABNxrkabAsjRcTJreg)
						{
							bGbIcpkufXABNxrkabAsjRcTJreg.Clear();
						}
					}
				}
				else if (pPQDlKpVEJGlqKCVmOmtHciAONhb != null)
				{
					lock (pPQDlKpVEJGlqKCVmOmtHciAONhb)
					{
						pPQDlKpVEJGlqKCVmOmtHciAONhb.Clear();
					}
				}
				if (zLlFdNeKWeggNHunWZNuniuFsEOH != null)
				{
					zLlFdNeKWeggNHunWZNuniuFsEOH.Dispose();
				}
			}
			TqgJbisKxFHQHneIhFLTKodLiTz = true;
		}
	}
}
