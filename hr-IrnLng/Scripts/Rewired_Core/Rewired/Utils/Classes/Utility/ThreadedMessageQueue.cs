using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadedMessageQueue<T> : IDisposable
	{
		private readonly int LcRauzHKmKBpxtEAARdVqGhVdCbH;

		private readonly int sEexrfZtAXWkVvfZfKZLdwrloCT;

		private readonly int OjFdEclQoQsTiZfdsXWYSBgKHDq;

		private readonly bool dnYSrHeSeWfhmgPMXPOngPfSvfk;

		private ThreadHelper TOLvxyiiNhqpXirBdtAdqoJEeaJ;

		private Queue<T> fraaHHsAvClOOUcxYwiHKifDhdUE;

		private Queue<T> AWnjiCfwVvHsRUCDBMVJXNRWHNj;

		private bool jhLrtTQylzmdSwmxOgocATNSjcGf;

		private bool rXobafaxvUDrItlgWahiaYSKJqn;

		private Action<T> FChYBpitdJAIZovgVlxIRJtQCaX;

		private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

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
			LcRauzHKmKBpxtEAARdVqGhVdCbH = maxQueueSize;
			sEexrfZtAXWkVvfZfKZLdwrloCT = threadRefreshRateFPS;
			OjFdEclQoQsTiZfdsXWYSBgKHDq = threadAutoKillTimeoutMS;
			dnYSrHeSeWfhmgPMXPOngPfSvfk = threadBlockOnStartAndStop;
			FChYBpitdJAIZovgVlxIRJtQCaX = messageReceiverDelegate;
			fraaHHsAvClOOUcxYwiHKifDhdUE = new Queue<T>(maxQueueSize);
			AWnjiCfwVvHsRUCDBMVJXNRWHNj = new Queue<T>(maxQueueSize);
		}

		public void Enqueue(T message)
		{
			if (!zptlECrQiHzwILTuMWcaXVcgZFC())
			{
				return;
			}
			lock (fraaHHsAvClOOUcxYwiHKifDhdUE)
			{
				if (LcRauzHKmKBpxtEAARdVqGhVdCbH > 0)
				{
					while (fraaHHsAvClOOUcxYwiHKifDhdUE.Count >= LcRauzHKmKBpxtEAARdVqGhVdCbH)
					{
						fraaHHsAvClOOUcxYwiHKifDhdUE.Dequeue();
					}
				}
				fraaHHsAvClOOUcxYwiHKifDhdUE.Enqueue(message);
			}
		}

		private bool zptlECrQiHzwILTuMWcaXVcgZFC()
		{
			if (jhLrtTQylzmdSwmxOgocATNSjcGf)
			{
				return false;
			}
			if (!dnRqmZnjIMrsAjyACIgZsOXCkfi())
			{
				return false;
			}
			if (rXobafaxvUDrItlgWahiaYSKJqn)
			{
				return true;
			}
			rXobafaxvUDrItlgWahiaYSKJqn = true;
			return true;
		}

		private bool dnRqmZnjIMrsAjyACIgZsOXCkfi()
		{
			if (jhLrtTQylzmdSwmxOgocATNSjcGf)
			{
				return false;
			}
			if (TOLvxyiiNhqpXirBdtAdqoJEeaJ == null)
			{
				try
				{
					TOLvxyiiNhqpXirBdtAdqoJEeaJ = ThreadHelper.CreateFixedTimeStep(sEexrfZtAXWkVvfZfKZLdwrloCT, OjFdEclQoQsTiZfdsXWYSBgKHDq);
					TOLvxyiiNhqpXirBdtAdqoJEeaJ.ThreadUpdateEvent += fdflmMgrgHwHTbCydBMWJejqPcdh;
					TOLvxyiiNhqpXirBdtAdqoJEeaJ.Start(dnYSrHeSeWfhmgPMXPOngPfSvfk);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (TOLvxyiiNhqpXirBdtAdqoJEeaJ != null)
					{
						TOLvxyiiNhqpXirBdtAdqoJEeaJ.Stop(dnYSrHeSeWfhmgPMXPOngPfSvfk);
					}
					jhLrtTQylzmdSwmxOgocATNSjcGf = true;
					return false;
				}
			}
			if (!TOLvxyiiNhqpXirBdtAdqoJEeaJ.isRunning)
			{
				TOLvxyiiNhqpXirBdtAdqoJEeaJ.Start(dnYSrHeSeWfhmgPMXPOngPfSvfk);
			}
			else if (OjFdEclQoQsTiZfdsXWYSBgKHDq > 0)
			{
				TOLvxyiiNhqpXirBdtAdqoJEeaJ.ResetTimeout();
			}
			return true;
		}

		private void lICUxhtfqjIhSPYMQDspGxynQVl()
		{
			lock (fraaHHsAvClOOUcxYwiHKifDhdUE)
			{
				lock (AWnjiCfwVvHsRUCDBMVJXNRWHNj)
				{
					MiscTools.Swap(ref fraaHHsAvClOOUcxYwiHKifDhdUE, ref AWnjiCfwVvHsRUCDBMVJXNRWHNj);
				}
			}
		}

		private void fdflmMgrgHwHTbCydBMWJejqPcdh()
		{
			lICUxhtfqjIhSPYMQDspGxynQVl();
			lock (AWnjiCfwVvHsRUCDBMVJXNRWHNj)
			{
				while (AWnjiCfwVvHsRUCDBMVJXNRWHNj.Count > 0)
				{
					try
					{
						FChYBpitdJAIZovgVlxIRJtQCaX(AWnjiCfwVvHsRUCDBMVJXNRWHNj.Dequeue());
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
			if (JtZAxieDBYjDdfBgPPJgrNSxYmS)
			{
				return;
			}
			if (disposing)
			{
				if (fraaHHsAvClOOUcxYwiHKifDhdUE != null)
				{
					if (AWnjiCfwVvHsRUCDBMVJXNRWHNj != null)
					{
						lock (fraaHHsAvClOOUcxYwiHKifDhdUE)
						{
							lock (AWnjiCfwVvHsRUCDBMVJXNRWHNj)
							{
								fraaHHsAvClOOUcxYwiHKifDhdUE.Clear();
								AWnjiCfwVvHsRUCDBMVJXNRWHNj.Clear();
							}
						}
					}
					else
					{
						lock (fraaHHsAvClOOUcxYwiHKifDhdUE)
						{
							fraaHHsAvClOOUcxYwiHKifDhdUE.Clear();
						}
					}
				}
				else if (AWnjiCfwVvHsRUCDBMVJXNRWHNj != null)
				{
					lock (AWnjiCfwVvHsRUCDBMVJXNRWHNj)
					{
						AWnjiCfwVvHsRUCDBMVJXNRWHNj.Clear();
					}
				}
				if (TOLvxyiiNhqpXirBdtAdqoJEeaJ != null)
				{
					TOLvxyiiNhqpXirBdtAdqoJEeaJ.Dispose();
				}
			}
			JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
		}
	}
}
