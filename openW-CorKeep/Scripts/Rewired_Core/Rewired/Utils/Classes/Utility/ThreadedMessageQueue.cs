using System;
using System.Collections.Generic;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadedMessageQueue<T> : IDisposable
	{
		private readonly int MnyGdtqIQsxVzzpkPhRVjtzpszZNA;

		private readonly int SPbBiTEiJFtnkSjVuPciVBQcoWLC;

		private readonly int iUjTHbZSvLukPSTBiRudAgvwlDCe;

		private readonly bool IMxYKPCLrDwNcRIibHQuhRzDaDZGb;

		private ThreadHelper WfDmaqKtnonMmTwExqfemmFUreLK;

		private Queue<T> IFNnaSGjAJPwihuHVMtckdLOGYzh;

		private Queue<T> CDdkuSLEaEgDUIhzuIzySbRdXPKP;

		private bool GPFzDVvXeJLWraZrtVaVcJXBfhHI;

		private bool GHEnKKYjSrCwiDIVrnRgSBusGQWuA;

		private Action<T> byphuolmMotGMXKduBIoXQzOWVKS;

		private bool ygCbkMCDlhlEfzbDxscVHVNyQjOu;

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
			MnyGdtqIQsxVzzpkPhRVjtzpszZNA = P_0;
			SPbBiTEiJFtnkSjVuPciVBQcoWLC = P_1;
			iUjTHbZSvLukPSTBiRudAgvwlDCe = P_2;
			IMxYKPCLrDwNcRIibHQuhRzDaDZGb = P_3;
			byphuolmMotGMXKduBIoXQzOWVKS = P_4;
			IFNnaSGjAJPwihuHVMtckdLOGYzh = new Queue<T>(P_0);
			CDdkuSLEaEgDUIhzuIzySbRdXPKP = new Queue<T>(P_0);
		}

		public void Enqueue(T message)
		{
			if (!ryjYPmRGKIFtheRVMRUeTmQbQgQeb())
			{
				return;
			}
			lock (IFNnaSGjAJPwihuHVMtckdLOGYzh)
			{
				if (MnyGdtqIQsxVzzpkPhRVjtzpszZNA > 0)
				{
					while (IFNnaSGjAJPwihuHVMtckdLOGYzh.Count >= MnyGdtqIQsxVzzpkPhRVjtzpszZNA)
					{
						IFNnaSGjAJPwihuHVMtckdLOGYzh.Dequeue();
					}
				}
				IFNnaSGjAJPwihuHVMtckdLOGYzh.Enqueue(message);
			}
		}

		private bool ryjYPmRGKIFtheRVMRUeTmQbQgQeb()
		{
			if (GPFzDVvXeJLWraZrtVaVcJXBfhHI)
			{
				return false;
			}
			if (!FZBhOPhWJIWWYsTqYQiXgPefgMbHb())
			{
				return false;
			}
			if (GHEnKKYjSrCwiDIVrnRgSBusGQWuA)
			{
				return true;
			}
			GHEnKKYjSrCwiDIVrnRgSBusGQWuA = true;
			return true;
		}

		private bool FZBhOPhWJIWWYsTqYQiXgPefgMbHb()
		{
			if (GPFzDVvXeJLWraZrtVaVcJXBfhHI)
			{
				return false;
			}
			if (WfDmaqKtnonMmTwExqfemmFUreLK == null)
			{
				try
				{
					WfDmaqKtnonMmTwExqfemmFUreLK = ThreadHelper.CreateFixedTimeStep(SPbBiTEiJFtnkSjVuPciVBQcoWLC, iUjTHbZSvLukPSTBiRudAgvwlDCe);
					WfDmaqKtnonMmTwExqfemmFUreLK.ThreadUpdateEvent += HfecsyqjgyEZXIDEWijbvAgrqjYX;
					WfDmaqKtnonMmTwExqfemmFUreLK.Start(IMxYKPCLrDwNcRIibHQuhRzDaDZGb);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (WfDmaqKtnonMmTwExqfemmFUreLK != null)
					{
						WfDmaqKtnonMmTwExqfemmFUreLK.Stop(IMxYKPCLrDwNcRIibHQuhRzDaDZGb);
					}
					GPFzDVvXeJLWraZrtVaVcJXBfhHI = true;
					return false;
				}
			}
			if (!WfDmaqKtnonMmTwExqfemmFUreLK.isRunning)
			{
				WfDmaqKtnonMmTwExqfemmFUreLK.Start(IMxYKPCLrDwNcRIibHQuhRzDaDZGb);
			}
			else if (iUjTHbZSvLukPSTBiRudAgvwlDCe > 0)
			{
				WfDmaqKtnonMmTwExqfemmFUreLK.ResetTimeout();
			}
			return true;
		}

		private void XMiUEpqMtQWNfULycjsZuaTCGaoS()
		{
			lock (IFNnaSGjAJPwihuHVMtckdLOGYzh)
			{
				lock (CDdkuSLEaEgDUIhzuIzySbRdXPKP)
				{
					MiscTools.Swap(ref IFNnaSGjAJPwihuHVMtckdLOGYzh, ref CDdkuSLEaEgDUIhzuIzySbRdXPKP);
				}
			}
		}

		private void HfecsyqjgyEZXIDEWijbvAgrqjYX()
		{
			XMiUEpqMtQWNfULycjsZuaTCGaoS();
			lock (CDdkuSLEaEgDUIhzuIzySbRdXPKP)
			{
				while (CDdkuSLEaEgDUIhzuIzySbRdXPKP.Count > 0)
				{
					try
					{
						byphuolmMotGMXKduBIoXQzOWVKS(CDdkuSLEaEgDUIhzuIzySbRdXPKP.Dequeue());
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
			if (ygCbkMCDlhlEfzbDxscVHVNyQjOu)
			{
				return;
			}
			if (disposing)
			{
				if (IFNnaSGjAJPwihuHVMtckdLOGYzh != null)
				{
					if (CDdkuSLEaEgDUIhzuIzySbRdXPKP != null)
					{
						lock (IFNnaSGjAJPwihuHVMtckdLOGYzh)
						{
							lock (CDdkuSLEaEgDUIhzuIzySbRdXPKP)
							{
								IFNnaSGjAJPwihuHVMtckdLOGYzh.Clear();
								CDdkuSLEaEgDUIhzuIzySbRdXPKP.Clear();
							}
						}
					}
					else
					{
						lock (IFNnaSGjAJPwihuHVMtckdLOGYzh)
						{
							IFNnaSGjAJPwihuHVMtckdLOGYzh.Clear();
						}
					}
				}
				else if (CDdkuSLEaEgDUIhzuIzySbRdXPKP != null)
				{
					lock (CDdkuSLEaEgDUIhzuIzySbRdXPKP)
					{
						CDdkuSLEaEgDUIhzuIzySbRdXPKP.Clear();
					}
				}
				if (WfDmaqKtnonMmTwExqfemmFUreLK != null)
				{
					WfDmaqKtnonMmTwExqfemmFUreLK.Dispose();
				}
			}
			ygCbkMCDlhlEfzbDxscVHVNyQjOu = true;
		}
	}
}
