using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadedMessageQueue<T> : IDisposable
	{
		private readonly int yKhHNObapkuTeMKeUVErpXCIEInN;

		private readonly int LOKIGEyMJleKGtUndckjGIYsFUXHA;

		private readonly int vLxrmRAlKkAItDXIwcMebLnTHOud;

		private readonly bool GuqrdETiBkLtccFxTEscBbyVIdvt;

		private ThreadHelper uytkADRVWPHFEiqlxjbRBVqXkmPwA;

		private Queue<T> QkCwRsJuucmiROFHWVWxhYtQvCwc;

		private Queue<T> loDWBxUNMFdAYGxfZZijiNeRDNfo;

		private bool ORjAOkdbwJKNTryFIOLCpTaNakQDA;

		private bool UKOJIKREswByZtkIQEUQJcfFaZxF;

		private Action<T> mORhCGVlqboYOcmNDWreiMoLIGLI;

		private bool wFtxnVROnubhehGUBaPWAtQsiPAD;

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
			yKhHNObapkuTeMKeUVErpXCIEInN = P_0;
			LOKIGEyMJleKGtUndckjGIYsFUXHA = P_1;
			vLxrmRAlKkAItDXIwcMebLnTHOud = P_2;
			GuqrdETiBkLtccFxTEscBbyVIdvt = P_3;
			mORhCGVlqboYOcmNDWreiMoLIGLI = P_4;
			QkCwRsJuucmiROFHWVWxhYtQvCwc = new Queue<T>(P_0);
			loDWBxUNMFdAYGxfZZijiNeRDNfo = new Queue<T>(P_0);
		}

		public void Enqueue(T message)
		{
			if (!EfZYTxAmPOLzlDbwclhSLCyvTxPf())
			{
				return;
			}
			lock (QkCwRsJuucmiROFHWVWxhYtQvCwc)
			{
				if (yKhHNObapkuTeMKeUVErpXCIEInN > 0)
				{
					while (QkCwRsJuucmiROFHWVWxhYtQvCwc.Count >= yKhHNObapkuTeMKeUVErpXCIEInN)
					{
						QkCwRsJuucmiROFHWVWxhYtQvCwc.Dequeue();
					}
				}
				QkCwRsJuucmiROFHWVWxhYtQvCwc.Enqueue(message);
			}
		}

		private bool EfZYTxAmPOLzlDbwclhSLCyvTxPf()
		{
			if (ORjAOkdbwJKNTryFIOLCpTaNakQDA)
			{
				return false;
			}
			if (!GineJofMZilHDjloQMblZXwJFaebA())
			{
				return false;
			}
			if (UKOJIKREswByZtkIQEUQJcfFaZxF)
			{
				return true;
			}
			UKOJIKREswByZtkIQEUQJcfFaZxF = true;
			return true;
		}

		private bool GineJofMZilHDjloQMblZXwJFaebA()
		{
			if (ORjAOkdbwJKNTryFIOLCpTaNakQDA)
			{
				return false;
			}
			if (uytkADRVWPHFEiqlxjbRBVqXkmPwA == null)
			{
				try
				{
					uytkADRVWPHFEiqlxjbRBVqXkmPwA = ThreadHelper.CreateFixedTimeStep(LOKIGEyMJleKGtUndckjGIYsFUXHA, vLxrmRAlKkAItDXIwcMebLnTHOud);
					uytkADRVWPHFEiqlxjbRBVqXkmPwA.ThreadUpdateEvent += AkJxLxTMjvgtGnOMvyviVaQfyqrQ;
					uytkADRVWPHFEiqlxjbRBVqXkmPwA.Start(GuqrdETiBkLtccFxTEscBbyVIdvt);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (uytkADRVWPHFEiqlxjbRBVqXkmPwA != null)
					{
						uytkADRVWPHFEiqlxjbRBVqXkmPwA.Stop(GuqrdETiBkLtccFxTEscBbyVIdvt);
					}
					ORjAOkdbwJKNTryFIOLCpTaNakQDA = true;
					return false;
				}
			}
			if (!uytkADRVWPHFEiqlxjbRBVqXkmPwA.isRunning)
			{
				uytkADRVWPHFEiqlxjbRBVqXkmPwA.Start(GuqrdETiBkLtccFxTEscBbyVIdvt);
			}
			else if (vLxrmRAlKkAItDXIwcMebLnTHOud > 0)
			{
				uytkADRVWPHFEiqlxjbRBVqXkmPwA.ResetTimeout();
			}
			return true;
		}

		private void YxgtpKQadVDZPFoaMJMTvzNoSpdJ()
		{
			lock (QkCwRsJuucmiROFHWVWxhYtQvCwc)
			{
				lock (loDWBxUNMFdAYGxfZZijiNeRDNfo)
				{
					MiscTools.Swap(ref QkCwRsJuucmiROFHWVWxhYtQvCwc, ref loDWBxUNMFdAYGxfZZijiNeRDNfo);
				}
			}
		}

		private void AkJxLxTMjvgtGnOMvyviVaQfyqrQ()
		{
			YxgtpKQadVDZPFoaMJMTvzNoSpdJ();
			lock (loDWBxUNMFdAYGxfZZijiNeRDNfo)
			{
				while (loDWBxUNMFdAYGxfZZijiNeRDNfo.Count > 0)
				{
					try
					{
						mORhCGVlqboYOcmNDWreiMoLIGLI(loDWBxUNMFdAYGxfZZijiNeRDNfo.Dequeue());
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

		~ThreadedMessageQueue()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (wFtxnVROnubhehGUBaPWAtQsiPAD)
			{
				return;
			}
			if (disposing)
			{
				if (QkCwRsJuucmiROFHWVWxhYtQvCwc != null)
				{
					if (loDWBxUNMFdAYGxfZZijiNeRDNfo != null)
					{
						lock (QkCwRsJuucmiROFHWVWxhYtQvCwc)
						{
							lock (loDWBxUNMFdAYGxfZZijiNeRDNfo)
							{
								QkCwRsJuucmiROFHWVWxhYtQvCwc.Clear();
								loDWBxUNMFdAYGxfZZijiNeRDNfo.Clear();
							}
						}
					}
					else
					{
						lock (QkCwRsJuucmiROFHWVWxhYtQvCwc)
						{
							QkCwRsJuucmiROFHWVWxhYtQvCwc.Clear();
						}
					}
				}
				else if (loDWBxUNMFdAYGxfZZijiNeRDNfo != null)
				{
					lock (loDWBxUNMFdAYGxfZZijiNeRDNfo)
					{
						loDWBxUNMFdAYGxfZZijiNeRDNfo.Clear();
					}
				}
				if (uytkADRVWPHFEiqlxjbRBVqXkmPwA != null)
				{
					uytkADRVWPHFEiqlxjbRBVqXkmPwA.Dispose();
				}
			}
			wFtxnVROnubhehGUBaPWAtQsiPAD = true;
		}
	}
}
