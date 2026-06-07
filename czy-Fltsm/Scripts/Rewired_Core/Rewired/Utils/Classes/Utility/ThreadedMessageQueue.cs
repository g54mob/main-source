using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadedMessageQueue<T> : IDisposable
	{
		private readonly int ETchzieUkqsHHqYIEiAkHyhMIaRrA;

		private readonly int GplLUQkCEDGlOroHbvOZMqLXCbZX;

		private readonly int yadTUqrxuBuPhdfdxfQQTrgJRiQm;

		private readonly bool SHpNSGwkRNgRWfsGygTZqWfcoGFtA;

		private ThreadHelper QcNgSpgGLqbwGslgodcPruLlqGPm;

		private Queue<T> KKFzcLwHqRDRAWxfAMHFjAFxCJjHA;

		private Queue<T> YYjggDtMFKTxurXehcbXBCBQSHQG;

		private bool QLNoHYPXMNHtZFFRkbMmxPJqpuFR;

		private bool WgUySLiKcrtgQbQzgdSTFYiVkVIhA;

		private Action<T> pxzZmhBlioHWcfaBpZFXCGpzkOWqA;

		private bool ohUeBToHUxALXGtEypPwCXJLgpWD;

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
			ETchzieUkqsHHqYIEiAkHyhMIaRrA = P_0;
			GplLUQkCEDGlOroHbvOZMqLXCbZX = P_1;
			yadTUqrxuBuPhdfdxfQQTrgJRiQm = P_2;
			SHpNSGwkRNgRWfsGygTZqWfcoGFtA = P_3;
			pxzZmhBlioHWcfaBpZFXCGpzkOWqA = P_4;
			KKFzcLwHqRDRAWxfAMHFjAFxCJjHA = new Queue<T>(P_0);
			YYjggDtMFKTxurXehcbXBCBQSHQG = new Queue<T>(P_0);
		}

		public void Enqueue(T message)
		{
			if (!hbbNPnvikUvlJkodDIPTelMUDfQCb())
			{
				return;
			}
			lock (KKFzcLwHqRDRAWxfAMHFjAFxCJjHA)
			{
				if (ETchzieUkqsHHqYIEiAkHyhMIaRrA > 0)
				{
					while (KKFzcLwHqRDRAWxfAMHFjAFxCJjHA.Count >= ETchzieUkqsHHqYIEiAkHyhMIaRrA)
					{
						KKFzcLwHqRDRAWxfAMHFjAFxCJjHA.Dequeue();
					}
				}
				KKFzcLwHqRDRAWxfAMHFjAFxCJjHA.Enqueue(message);
			}
		}

		private bool hbbNPnvikUvlJkodDIPTelMUDfQCb()
		{
			if (QLNoHYPXMNHtZFFRkbMmxPJqpuFR)
			{
				return false;
			}
			if (!NzZeMCubtKWEgsFUPFjuKIgGPPvib())
			{
				return false;
			}
			if (WgUySLiKcrtgQbQzgdSTFYiVkVIhA)
			{
				return true;
			}
			WgUySLiKcrtgQbQzgdSTFYiVkVIhA = true;
			return true;
		}

		private bool NzZeMCubtKWEgsFUPFjuKIgGPPvib()
		{
			if (QLNoHYPXMNHtZFFRkbMmxPJqpuFR)
			{
				return false;
			}
			if (QcNgSpgGLqbwGslgodcPruLlqGPm == null)
			{
				try
				{
					QcNgSpgGLqbwGslgodcPruLlqGPm = ThreadHelper.CreateFixedTimeStep(GplLUQkCEDGlOroHbvOZMqLXCbZX, yadTUqrxuBuPhdfdxfQQTrgJRiQm);
					QcNgSpgGLqbwGslgodcPruLlqGPm.ThreadUpdateEvent += FwAmbKyIsCJxtiaDTiEqMiIggUw;
					QcNgSpgGLqbwGslgodcPruLlqGPm.Start(SHpNSGwkRNgRWfsGygTZqWfcoGFtA);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (QcNgSpgGLqbwGslgodcPruLlqGPm != null)
					{
						QcNgSpgGLqbwGslgodcPruLlqGPm.Stop(SHpNSGwkRNgRWfsGygTZqWfcoGFtA);
					}
					QLNoHYPXMNHtZFFRkbMmxPJqpuFR = true;
					return false;
				}
			}
			if (!QcNgSpgGLqbwGslgodcPruLlqGPm.isRunning)
			{
				QcNgSpgGLqbwGslgodcPruLlqGPm.Start(SHpNSGwkRNgRWfsGygTZqWfcoGFtA);
			}
			else if (yadTUqrxuBuPhdfdxfQQTrgJRiQm > 0)
			{
				QcNgSpgGLqbwGslgodcPruLlqGPm.ResetTimeout();
			}
			return true;
		}

		private void ZIuQCmUaRGZVFvGUnJumtLPrhxgbA()
		{
			lock (KKFzcLwHqRDRAWxfAMHFjAFxCJjHA)
			{
				lock (YYjggDtMFKTxurXehcbXBCBQSHQG)
				{
					MiscTools.Swap(ref KKFzcLwHqRDRAWxfAMHFjAFxCJjHA, ref YYjggDtMFKTxurXehcbXBCBQSHQG);
				}
			}
		}

		private void FwAmbKyIsCJxtiaDTiEqMiIggUw()
		{
			ZIuQCmUaRGZVFvGUnJumtLPrhxgbA();
			lock (YYjggDtMFKTxurXehcbXBCBQSHQG)
			{
				while (YYjggDtMFKTxurXehcbXBCBQSHQG.Count > 0)
				{
					try
					{
						pxzZmhBlioHWcfaBpZFXCGpzkOWqA(YYjggDtMFKTxurXehcbXBCBQSHQG.Dequeue());
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
			if (ohUeBToHUxALXGtEypPwCXJLgpWD)
			{
				return;
			}
			if (disposing)
			{
				if (KKFzcLwHqRDRAWxfAMHFjAFxCJjHA != null)
				{
					if (YYjggDtMFKTxurXehcbXBCBQSHQG != null)
					{
						lock (KKFzcLwHqRDRAWxfAMHFjAFxCJjHA)
						{
							lock (YYjggDtMFKTxurXehcbXBCBQSHQG)
							{
								KKFzcLwHqRDRAWxfAMHFjAFxCJjHA.Clear();
								YYjggDtMFKTxurXehcbXBCBQSHQG.Clear();
							}
						}
					}
					else
					{
						lock (KKFzcLwHqRDRAWxfAMHFjAFxCJjHA)
						{
							KKFzcLwHqRDRAWxfAMHFjAFxCJjHA.Clear();
						}
					}
				}
				else if (YYjggDtMFKTxurXehcbXBCBQSHQG != null)
				{
					lock (YYjggDtMFKTxurXehcbXBCBQSHQG)
					{
						YYjggDtMFKTxurXehcbXBCBQSHQG.Clear();
					}
				}
				if (QcNgSpgGLqbwGslgodcPruLlqGPm != null)
				{
					QcNgSpgGLqbwGslgodcPruLlqGPm.Dispose();
				}
			}
			ohUeBToHUxALXGtEypPwCXJLgpWD = true;
		}
	}
}
