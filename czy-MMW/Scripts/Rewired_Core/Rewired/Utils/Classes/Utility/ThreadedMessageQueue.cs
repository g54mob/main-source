using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadedMessageQueue<T> : IDisposable
	{
		private readonly int SQvmPEBvrzzQckOTpzaEVhMUgomw;

		private readonly int ItgSMupLNWAVhFsAQWrbjQmJGlaBA;

		private readonly int wooSEMcQbGDASXdyQxraoAFDMshS;

		private readonly bool CswJwChQUvjtrABJPexZrCgKUyaA;

		private ThreadHelper IDYMbPvnYxPxzQYdBUlvUQijujwi;

		private Queue<T> CaKGonjpbKkxxsoazvcpRAyduVKz;

		private Queue<T> CEyrnvqYHLnlVXPYGaRnmwqMDAzW;

		private bool UKqKcxKZOPfurXSDBlUcUgiRciMA;

		private bool WCBERjzSniaQxVMsPDdlCpXRNFhPA;

		private Action<T> dImdGNQtjzwLPAuGCamtnRGvCcbL;

		private bool kWDOljvMUissumkwTfUIxssNcTxJ;

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
			SQvmPEBvrzzQckOTpzaEVhMUgomw = P_0;
			ItgSMupLNWAVhFsAQWrbjQmJGlaBA = P_1;
			wooSEMcQbGDASXdyQxraoAFDMshS = P_2;
			CswJwChQUvjtrABJPexZrCgKUyaA = P_3;
			dImdGNQtjzwLPAuGCamtnRGvCcbL = P_4;
			CaKGonjpbKkxxsoazvcpRAyduVKz = new Queue<T>(P_0);
			CEyrnvqYHLnlVXPYGaRnmwqMDAzW = new Queue<T>(P_0);
		}

		public void Enqueue(T message)
		{
			if (!ncNCJkCfJrVyEKswfolbCxUlzly())
			{
				return;
			}
			lock (CaKGonjpbKkxxsoazvcpRAyduVKz)
			{
				if (SQvmPEBvrzzQckOTpzaEVhMUgomw > 0)
				{
					while (CaKGonjpbKkxxsoazvcpRAyduVKz.Count >= SQvmPEBvrzzQckOTpzaEVhMUgomw)
					{
						CaKGonjpbKkxxsoazvcpRAyduVKz.Dequeue();
					}
				}
				CaKGonjpbKkxxsoazvcpRAyduVKz.Enqueue(message);
			}
		}

		private bool ncNCJkCfJrVyEKswfolbCxUlzly()
		{
			if (UKqKcxKZOPfurXSDBlUcUgiRciMA)
			{
				return false;
			}
			if (!FIEZPsrwiXyPnMVzkOCwnNoQVSKB())
			{
				return false;
			}
			if (WCBERjzSniaQxVMsPDdlCpXRNFhPA)
			{
				return true;
			}
			WCBERjzSniaQxVMsPDdlCpXRNFhPA = true;
			return true;
		}

		private bool FIEZPsrwiXyPnMVzkOCwnNoQVSKB()
		{
			if (UKqKcxKZOPfurXSDBlUcUgiRciMA)
			{
				return false;
			}
			if (IDYMbPvnYxPxzQYdBUlvUQijujwi == null)
			{
				try
				{
					IDYMbPvnYxPxzQYdBUlvUQijujwi = ThreadHelper.CreateFixedTimeStep(ItgSMupLNWAVhFsAQWrbjQmJGlaBA, wooSEMcQbGDASXdyQxraoAFDMshS);
					IDYMbPvnYxPxzQYdBUlvUQijujwi.ThreadUpdateEvent += HylnjZDmLlFxMbZnqNNusLZSeqbbb;
					IDYMbPvnYxPxzQYdBUlvUQijujwi.Start(CswJwChQUvjtrABJPexZrCgKUyaA);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (IDYMbPvnYxPxzQYdBUlvUQijujwi != null)
					{
						IDYMbPvnYxPxzQYdBUlvUQijujwi.Stop(CswJwChQUvjtrABJPexZrCgKUyaA);
					}
					UKqKcxKZOPfurXSDBlUcUgiRciMA = true;
					return false;
				}
			}
			if (!IDYMbPvnYxPxzQYdBUlvUQijujwi.isRunning)
			{
				IDYMbPvnYxPxzQYdBUlvUQijujwi.Start(CswJwChQUvjtrABJPexZrCgKUyaA);
			}
			else if (wooSEMcQbGDASXdyQxraoAFDMshS > 0)
			{
				IDYMbPvnYxPxzQYdBUlvUQijujwi.ResetTimeout();
			}
			return true;
		}

		private void HTbLDAFMSVnixLFHGZbUQkMzdxVD()
		{
			lock (CaKGonjpbKkxxsoazvcpRAyduVKz)
			{
				lock (CEyrnvqYHLnlVXPYGaRnmwqMDAzW)
				{
					MiscTools.Swap(ref CaKGonjpbKkxxsoazvcpRAyduVKz, ref CEyrnvqYHLnlVXPYGaRnmwqMDAzW);
				}
			}
		}

		private void HylnjZDmLlFxMbZnqNNusLZSeqbbb()
		{
			HTbLDAFMSVnixLFHGZbUQkMzdxVD();
			lock (CEyrnvqYHLnlVXPYGaRnmwqMDAzW)
			{
				while (CEyrnvqYHLnlVXPYGaRnmwqMDAzW.Count > 0)
				{
					try
					{
						dImdGNQtjzwLPAuGCamtnRGvCcbL(CEyrnvqYHLnlVXPYGaRnmwqMDAzW.Dequeue());
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
			if (kWDOljvMUissumkwTfUIxssNcTxJ)
			{
				return;
			}
			if (disposing)
			{
				if (CaKGonjpbKkxxsoazvcpRAyduVKz != null)
				{
					if (CEyrnvqYHLnlVXPYGaRnmwqMDAzW != null)
					{
						lock (CaKGonjpbKkxxsoazvcpRAyduVKz)
						{
							lock (CEyrnvqYHLnlVXPYGaRnmwqMDAzW)
							{
								CaKGonjpbKkxxsoazvcpRAyduVKz.Clear();
								CEyrnvqYHLnlVXPYGaRnmwqMDAzW.Clear();
							}
						}
					}
					else
					{
						lock (CaKGonjpbKkxxsoazvcpRAyduVKz)
						{
							CaKGonjpbKkxxsoazvcpRAyduVKz.Clear();
						}
					}
				}
				else if (CEyrnvqYHLnlVXPYGaRnmwqMDAzW != null)
				{
					lock (CEyrnvqYHLnlVXPYGaRnmwqMDAzW)
					{
						CEyrnvqYHLnlVXPYGaRnmwqMDAzW.Clear();
					}
				}
				if (IDYMbPvnYxPxzQYdBUlvUQijujwi != null)
				{
					IDYMbPvnYxPxzQYdBUlvUQijujwi.Dispose();
				}
			}
			kWDOljvMUissumkwTfUIxssNcTxJ = true;
		}
	}
}
