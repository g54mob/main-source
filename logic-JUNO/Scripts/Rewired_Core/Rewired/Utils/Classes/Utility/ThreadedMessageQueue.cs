using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadedMessageQueue<T> : IDisposable
	{
		private readonly int WuibGqMqELOdTqOvDEZNfuvZCAzb;

		private readonly int MWfFFsoLOeMceNKTgKQyFzAKFdWi;

		private readonly int oHxfXUxDciQdRVvhgiClSwhAxWRo;

		private readonly bool YlhEDkwqJsEweEfWbLNeJiihiiEl;

		private ThreadHelper UaBayBByRPzsuYqirEheewGuQOMM;

		private Queue<T> UtRNzzwFemmIagHvHuNwcnGqUtws;

		private Queue<T> KlbFwbGpWfvKIeNFsOwwdKAJPuBYb;

		private bool KqZNcyJrCmKdpjbVnDGPmvWxmICw;

		private bool SwKKpnkesMvuqJbbxWmiJLlUhVDG;

		private Action<T> hmrgFiNkiDJIOKNsiFEuRsHamHNE;

		private bool ktADitIiJMOHvucrrzxHhROMdODQA;

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
			WuibGqMqELOdTqOvDEZNfuvZCAzb = P_0;
			MWfFFsoLOeMceNKTgKQyFzAKFdWi = P_1;
			oHxfXUxDciQdRVvhgiClSwhAxWRo = P_2;
			YlhEDkwqJsEweEfWbLNeJiihiiEl = P_3;
			hmrgFiNkiDJIOKNsiFEuRsHamHNE = P_4;
			UtRNzzwFemmIagHvHuNwcnGqUtws = new Queue<T>(P_0);
			KlbFwbGpWfvKIeNFsOwwdKAJPuBYb = new Queue<T>(P_0);
		}

		public void Enqueue(T message)
		{
			if (!nEzDeZjtepyqxOPpCDqkyHPXBYRI())
			{
				return;
			}
			lock (UtRNzzwFemmIagHvHuNwcnGqUtws)
			{
				if (WuibGqMqELOdTqOvDEZNfuvZCAzb > 0)
				{
					while (UtRNzzwFemmIagHvHuNwcnGqUtws.Count >= WuibGqMqELOdTqOvDEZNfuvZCAzb)
					{
						UtRNzzwFemmIagHvHuNwcnGqUtws.Dequeue();
					}
				}
				UtRNzzwFemmIagHvHuNwcnGqUtws.Enqueue(message);
			}
		}

		private bool nEzDeZjtepyqxOPpCDqkyHPXBYRI()
		{
			if (KqZNcyJrCmKdpjbVnDGPmvWxmICw)
			{
				return false;
			}
			if (!RfZKkoeblxePWWkECvxBNYdJxDkK())
			{
				return false;
			}
			if (SwKKpnkesMvuqJbbxWmiJLlUhVDG)
			{
				return true;
			}
			SwKKpnkesMvuqJbbxWmiJLlUhVDG = true;
			return true;
		}

		private bool RfZKkoeblxePWWkECvxBNYdJxDkK()
		{
			if (KqZNcyJrCmKdpjbVnDGPmvWxmICw)
			{
				return false;
			}
			if (UaBayBByRPzsuYqirEheewGuQOMM == null)
			{
				try
				{
					UaBayBByRPzsuYqirEheewGuQOMM = ThreadHelper.CreateFixedTimeStep(MWfFFsoLOeMceNKTgKQyFzAKFdWi, oHxfXUxDciQdRVvhgiClSwhAxWRo);
					UaBayBByRPzsuYqirEheewGuQOMM.ThreadUpdateEvent += VeucoVFKGPcKXjJaJWqzJrdnHIJfB;
					UaBayBByRPzsuYqirEheewGuQOMM.Start(YlhEDkwqJsEweEfWbLNeJiihiiEl);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (UaBayBByRPzsuYqirEheewGuQOMM != null)
					{
						UaBayBByRPzsuYqirEheewGuQOMM.Stop(YlhEDkwqJsEweEfWbLNeJiihiiEl);
					}
					KqZNcyJrCmKdpjbVnDGPmvWxmICw = true;
					return false;
				}
			}
			if (!UaBayBByRPzsuYqirEheewGuQOMM.isRunning)
			{
				UaBayBByRPzsuYqirEheewGuQOMM.Start(YlhEDkwqJsEweEfWbLNeJiihiiEl);
			}
			else if (oHxfXUxDciQdRVvhgiClSwhAxWRo > 0)
			{
				UaBayBByRPzsuYqirEheewGuQOMM.ResetTimeout();
			}
			return true;
		}

		private void ZZyEyGONLnIzhHOSkwbDkASoeLrQ()
		{
			lock (UtRNzzwFemmIagHvHuNwcnGqUtws)
			{
				lock (KlbFwbGpWfvKIeNFsOwwdKAJPuBYb)
				{
					MiscTools.Swap(ref UtRNzzwFemmIagHvHuNwcnGqUtws, ref KlbFwbGpWfvKIeNFsOwwdKAJPuBYb);
				}
			}
		}

		private void VeucoVFKGPcKXjJaJWqzJrdnHIJfB()
		{
			ZZyEyGONLnIzhHOSkwbDkASoeLrQ();
			lock (KlbFwbGpWfvKIeNFsOwwdKAJPuBYb)
			{
				while (KlbFwbGpWfvKIeNFsOwwdKAJPuBYb.Count > 0)
				{
					try
					{
						hmrgFiNkiDJIOKNsiFEuRsHamHNE(KlbFwbGpWfvKIeNFsOwwdKAJPuBYb.Dequeue());
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
			if (ktADitIiJMOHvucrrzxHhROMdODQA)
			{
				return;
			}
			if (disposing)
			{
				if (UtRNzzwFemmIagHvHuNwcnGqUtws != null)
				{
					if (KlbFwbGpWfvKIeNFsOwwdKAJPuBYb != null)
					{
						lock (UtRNzzwFemmIagHvHuNwcnGqUtws)
						{
							lock (KlbFwbGpWfvKIeNFsOwwdKAJPuBYb)
							{
								UtRNzzwFemmIagHvHuNwcnGqUtws.Clear();
								KlbFwbGpWfvKIeNFsOwwdKAJPuBYb.Clear();
							}
						}
					}
					else
					{
						lock (UtRNzzwFemmIagHvHuNwcnGqUtws)
						{
							UtRNzzwFemmIagHvHuNwcnGqUtws.Clear();
						}
					}
				}
				else if (KlbFwbGpWfvKIeNFsOwwdKAJPuBYb != null)
				{
					lock (KlbFwbGpWfvKIeNFsOwwdKAJPuBYb)
					{
						KlbFwbGpWfvKIeNFsOwwdKAJPuBYb.Clear();
					}
				}
				if (UaBayBByRPzsuYqirEheewGuQOMM != null)
				{
					UaBayBByRPzsuYqirEheewGuQOMM.Dispose();
				}
			}
			ktADitIiJMOHvucrrzxHhROMdODQA = true;
		}
	}
}
