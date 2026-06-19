using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadedMessageQueue<T> : IDisposable
	{
		private readonly int bLtITXpMZLRAjDMqDFrIiMQzoQXN;

		private readonly int AiYhYTyUdUvTPqXhgEBAttAVLMj;

		private readonly int eShvfUORtFLHmKcHjFIDMuFuFLQ;

		private readonly bool VZijzTBKzRCWddelKZbNaAaukbD;

		private ThreadHelper byleSGZFcwgUJDntkRImTcwmoehC;

		private Queue<T> DEKgTbJCCZhqURRRHeyKYONrxGu;

		private Queue<T> iTPXJyKqmwjLZJyvIbTYPMakUZZ;

		private bool VtteUzfdCsVSSGvXPAslsAmeQmik;

		private bool XrAXpRFFCZWxSkTUXpVlgetwinP;

		private Action<T> hpDjiBTLAYnVJfvHQbaRBhkoDGj;

		private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

		public ThreadedMessageQueue(int maxQueueSize, int threadRefreshRateFPS, int threadAutoKillTimeoutMS, bool threadBlockOnStartAndStop, Action<T> messageReceiverDelegate)
		{
			if (messageReceiverDelegate == null)
			{
				throw new ArgumentNullException("messageReceiverDelegate");
			}
			if (maxQueueSize < 0)
			{
				maxQueueSize = 0;
			}
			if (threadRefreshRateFPS < 0)
			{
				threadRefreshRateFPS = 0;
			}
			if (threadAutoKillTimeoutMS < 0)
			{
				threadAutoKillTimeoutMS = 0;
			}
			bLtITXpMZLRAjDMqDFrIiMQzoQXN = maxQueueSize;
			AiYhYTyUdUvTPqXhgEBAttAVLMj = threadRefreshRateFPS;
			eShvfUORtFLHmKcHjFIDMuFuFLQ = threadAutoKillTimeoutMS;
			VZijzTBKzRCWddelKZbNaAaukbD = threadBlockOnStartAndStop;
			hpDjiBTLAYnVJfvHQbaRBhkoDGj = messageReceiverDelegate;
			DEKgTbJCCZhqURRRHeyKYONrxGu = new Queue<T>(maxQueueSize);
			iTPXJyKqmwjLZJyvIbTYPMakUZZ = new Queue<T>(maxQueueSize);
		}

		public void Enqueue(T message)
		{
			if (!BlPUAqMlztMmaYIlhKUlkimOHBj())
			{
				return;
			}
			lock (DEKgTbJCCZhqURRRHeyKYONrxGu)
			{
				if (bLtITXpMZLRAjDMqDFrIiMQzoQXN > 0)
				{
					while (DEKgTbJCCZhqURRRHeyKYONrxGu.Count >= bLtITXpMZLRAjDMqDFrIiMQzoQXN)
					{
						DEKgTbJCCZhqURRRHeyKYONrxGu.Dequeue();
					}
				}
				DEKgTbJCCZhqURRRHeyKYONrxGu.Enqueue(message);
			}
		}

		private bool BlPUAqMlztMmaYIlhKUlkimOHBj()
		{
			if (VtteUzfdCsVSSGvXPAslsAmeQmik)
			{
				return false;
			}
			if (!XdxHDhCKhBXYWFkaXYOIfioqteCp())
			{
				return false;
			}
			if (XrAXpRFFCZWxSkTUXpVlgetwinP)
			{
				return true;
			}
			XrAXpRFFCZWxSkTUXpVlgetwinP = true;
			return true;
		}

		private bool XdxHDhCKhBXYWFkaXYOIfioqteCp()
		{
			if (VtteUzfdCsVSSGvXPAslsAmeQmik)
			{
				return false;
			}
			if (byleSGZFcwgUJDntkRImTcwmoehC == null)
			{
				try
				{
					byleSGZFcwgUJDntkRImTcwmoehC = ThreadHelper.CreateFixedTimeStep(AiYhYTyUdUvTPqXhgEBAttAVLMj, eShvfUORtFLHmKcHjFIDMuFuFLQ);
					byleSGZFcwgUJDntkRImTcwmoehC.ThreadUpdateEvent += ZpVyDeRjVCfmFgyOwuILBqYMSsP;
					byleSGZFcwgUJDntkRImTcwmoehC.Start(VZijzTBKzRCWddelKZbNaAaukbD);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (byleSGZFcwgUJDntkRImTcwmoehC != null)
					{
						byleSGZFcwgUJDntkRImTcwmoehC.Stop(VZijzTBKzRCWddelKZbNaAaukbD);
					}
					VtteUzfdCsVSSGvXPAslsAmeQmik = true;
					return false;
				}
			}
			if (!byleSGZFcwgUJDntkRImTcwmoehC.isRunning)
			{
				byleSGZFcwgUJDntkRImTcwmoehC.Start(VZijzTBKzRCWddelKZbNaAaukbD);
			}
			else if (eShvfUORtFLHmKcHjFIDMuFuFLQ > 0)
			{
				byleSGZFcwgUJDntkRImTcwmoehC.ResetTimeout();
			}
			return true;
		}

		private void BcwpwDYRSiQGWAeKFyumQBMBIbJ()
		{
			lock (DEKgTbJCCZhqURRRHeyKYONrxGu)
			{
				lock (iTPXJyKqmwjLZJyvIbTYPMakUZZ)
				{
					MiscTools.Swap(ref DEKgTbJCCZhqURRRHeyKYONrxGu, ref iTPXJyKqmwjLZJyvIbTYPMakUZZ);
				}
			}
		}

		private void ZpVyDeRjVCfmFgyOwuILBqYMSsP()
		{
			BcwpwDYRSiQGWAeKFyumQBMBIbJ();
			lock (iTPXJyKqmwjLZJyvIbTYPMakUZZ)
			{
				while (iTPXJyKqmwjLZJyvIbTYPMakUZZ.Count > 0)
				{
					try
					{
						hpDjiBTLAYnVJfvHQbaRBhkoDGj(iTPXJyKqmwjLZJyvIbTYPMakUZZ.Dequeue());
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
			if (jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				return;
			}
			if (disposing)
			{
				if (DEKgTbJCCZhqURRRHeyKYONrxGu != null)
				{
					if (iTPXJyKqmwjLZJyvIbTYPMakUZZ != null)
					{
						lock (DEKgTbJCCZhqURRRHeyKYONrxGu)
						{
							lock (iTPXJyKqmwjLZJyvIbTYPMakUZZ)
							{
								DEKgTbJCCZhqURRRHeyKYONrxGu.Clear();
								iTPXJyKqmwjLZJyvIbTYPMakUZZ.Clear();
							}
						}
					}
					else
					{
						lock (DEKgTbJCCZhqURRRHeyKYONrxGu)
						{
							DEKgTbJCCZhqURRRHeyKYONrxGu.Clear();
						}
					}
				}
				else if (iTPXJyKqmwjLZJyvIbTYPMakUZZ != null)
				{
					lock (iTPXJyKqmwjLZJyvIbTYPMakUZZ)
					{
						iTPXJyKqmwjLZJyvIbTYPMakUZZ.Clear();
					}
				}
				if (byleSGZFcwgUJDntkRImTcwmoehC != null)
				{
					byleSGZFcwgUJDntkRImTcwmoehC.Dispose();
				}
			}
			jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
		}
	}
}
