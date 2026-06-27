using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadedMessageQueue<T> : IDisposable
	{
		private readonly int LLThndPpkapbuqOXnregDdktGjeG;

		private readonly int ZuKPNJfFLBFBthVZQqrBAjUjsPcKc;

		private readonly int hjAsVpwnnNDQYENrUYtQgmtyMEhfb;

		private readonly bool LwQAOHjgUHejniOEBvcNkvaNCckyA;

		private ThreadHelper PhkcoqjvMaOHjCKyBXGRDGWRYWeeb;

		private Queue<T> FSgDbSlotHJjrwJzjVkJOlCGFhEaA;

		private Queue<T> FjYtiUyxREjtRZRHMaVFobSpXozy;

		private bool XXcaZTMFJXbpghTFXdreGVQLPYym;

		private bool PBlMOehzgdAAxBfbTjeBfnVonAjF;

		private Action<T> qmQcSsAIziwJFYSPKqyZbitOefbf;

		private bool hUxTcGtLEnQkaqNhRhOgbyKuQIzN;

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
			LLThndPpkapbuqOXnregDdktGjeG = P_0;
			ZuKPNJfFLBFBthVZQqrBAjUjsPcKc = P_1;
			hjAsVpwnnNDQYENrUYtQgmtyMEhfb = P_2;
			LwQAOHjgUHejniOEBvcNkvaNCckyA = P_3;
			qmQcSsAIziwJFYSPKqyZbitOefbf = P_4;
			FSgDbSlotHJjrwJzjVkJOlCGFhEaA = new Queue<T>(P_0);
			FjYtiUyxREjtRZRHMaVFobSpXozy = new Queue<T>(P_0);
		}

		public void Enqueue(T message)
		{
			if (!ejWCXsyAtACVwiGjwSqZTITxqJryA())
			{
				return;
			}
			lock (FSgDbSlotHJjrwJzjVkJOlCGFhEaA)
			{
				if (LLThndPpkapbuqOXnregDdktGjeG > 0)
				{
					while (FSgDbSlotHJjrwJzjVkJOlCGFhEaA.Count >= LLThndPpkapbuqOXnregDdktGjeG)
					{
						FSgDbSlotHJjrwJzjVkJOlCGFhEaA.Dequeue();
					}
				}
				FSgDbSlotHJjrwJzjVkJOlCGFhEaA.Enqueue(message);
			}
		}

		private bool ejWCXsyAtACVwiGjwSqZTITxqJryA()
		{
			if (XXcaZTMFJXbpghTFXdreGVQLPYym)
			{
				return false;
			}
			if (!EHsQBDpyaUwoVWuWwEYwlkvlfMIL())
			{
				return false;
			}
			if (PBlMOehzgdAAxBfbTjeBfnVonAjF)
			{
				return true;
			}
			PBlMOehzgdAAxBfbTjeBfnVonAjF = true;
			return true;
		}

		private bool EHsQBDpyaUwoVWuWwEYwlkvlfMIL()
		{
			if (XXcaZTMFJXbpghTFXdreGVQLPYym)
			{
				return false;
			}
			if (PhkcoqjvMaOHjCKyBXGRDGWRYWeeb == null)
			{
				try
				{
					PhkcoqjvMaOHjCKyBXGRDGWRYWeeb = ThreadHelper.CreateFixedTimeStep(ZuKPNJfFLBFBthVZQqrBAjUjsPcKc, hjAsVpwnnNDQYENrUYtQgmtyMEhfb);
					PhkcoqjvMaOHjCKyBXGRDGWRYWeeb.ThreadUpdateEvent += QWRXicJpNmArMRzgihNURAjnqElp;
					PhkcoqjvMaOHjCKyBXGRDGWRYWeeb.Start(LwQAOHjgUHejniOEBvcNkvaNCckyA);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (PhkcoqjvMaOHjCKyBXGRDGWRYWeeb != null)
					{
						PhkcoqjvMaOHjCKyBXGRDGWRYWeeb.Stop(LwQAOHjgUHejniOEBvcNkvaNCckyA);
					}
					XXcaZTMFJXbpghTFXdreGVQLPYym = true;
					return false;
				}
			}
			if (!PhkcoqjvMaOHjCKyBXGRDGWRYWeeb.isRunning)
			{
				PhkcoqjvMaOHjCKyBXGRDGWRYWeeb.Start(LwQAOHjgUHejniOEBvcNkvaNCckyA);
			}
			else if (hjAsVpwnnNDQYENrUYtQgmtyMEhfb > 0)
			{
				PhkcoqjvMaOHjCKyBXGRDGWRYWeeb.ResetTimeout();
			}
			return true;
		}

		private void AaJaGlRIMKbfkdZEWyNeCXSGSVJu()
		{
			lock (FSgDbSlotHJjrwJzjVkJOlCGFhEaA)
			{
				lock (FjYtiUyxREjtRZRHMaVFobSpXozy)
				{
					MiscTools.Swap(ref FSgDbSlotHJjrwJzjVkJOlCGFhEaA, ref FjYtiUyxREjtRZRHMaVFobSpXozy);
				}
			}
		}

		private void QWRXicJpNmArMRzgihNURAjnqElp()
		{
			AaJaGlRIMKbfkdZEWyNeCXSGSVJu();
			lock (FjYtiUyxREjtRZRHMaVFobSpXozy)
			{
				while (FjYtiUyxREjtRZRHMaVFobSpXozy.Count > 0)
				{
					try
					{
						qmQcSsAIziwJFYSPKqyZbitOefbf(FjYtiUyxREjtRZRHMaVFobSpXozy.Dequeue());
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
			if (hUxTcGtLEnQkaqNhRhOgbyKuQIzN)
			{
				return;
			}
			if (disposing)
			{
				if (FSgDbSlotHJjrwJzjVkJOlCGFhEaA != null)
				{
					if (FjYtiUyxREjtRZRHMaVFobSpXozy != null)
					{
						lock (FSgDbSlotHJjrwJzjVkJOlCGFhEaA)
						{
							lock (FjYtiUyxREjtRZRHMaVFobSpXozy)
							{
								FSgDbSlotHJjrwJzjVkJOlCGFhEaA.Clear();
								FjYtiUyxREjtRZRHMaVFobSpXozy.Clear();
							}
						}
					}
					else
					{
						lock (FSgDbSlotHJjrwJzjVkJOlCGFhEaA)
						{
							FSgDbSlotHJjrwJzjVkJOlCGFhEaA.Clear();
						}
					}
				}
				else if (FjYtiUyxREjtRZRHMaVFobSpXozy != null)
				{
					lock (FjYtiUyxREjtRZRHMaVFobSpXozy)
					{
						FjYtiUyxREjtRZRHMaVFobSpXozy.Clear();
					}
				}
				if (PhkcoqjvMaOHjCKyBXGRDGWRYWeeb != null)
				{
					PhkcoqjvMaOHjCKyBXGRDGWRYWeeb.Dispose();
				}
			}
			hUxTcGtLEnQkaqNhRhOgbyKuQIzN = true;
		}
	}
}
