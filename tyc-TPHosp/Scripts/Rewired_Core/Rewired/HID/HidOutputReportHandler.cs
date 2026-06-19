using System;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

namespace Rewired.HID
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class HidOutputReportHandler : IDisposable
	{
		[CustomObfuscation(rename = false)]
		public delegate bool WriteReportDelegate(OutputReport report);

		private class BuXfeFPjpQPkpeeneHFIOaPBfEm : IDisposable
		{
			private bool OIViklNQzJDykqHqXtcmdnxBJAn;

			private OutputReport aIXEvWoZqKkkbJnaLiGkPdmGUVC;

			private NativeBuffer RSxKjXmDMKxHgwqOxhLLABffNJxA;

			private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

			public bool HasReport => OIViklNQzJDykqHqXtcmdnxBJAn;

			public BuXfeFPjpQPkpeeneHFIOaPBfEm()
			{
				RSxKjXmDMKxHgwqOxhLLABffNJxA = new NativeBuffer(0);
			}

			public void ppGuQvnElTiEWUsyXvcytHcccaq(ref OutputReport P_0)
			{
				OIViklNQzJDykqHqXtcmdnxBJAn = false;
				if (!P_0.IsValid)
				{
					return;
				}
				aIXEvWoZqKkkbJnaLiGkPdmGUVC = P_0;
				if (RSxKjXmDMKxHgwqOxhLLABffNJxA.Length >= P_0.bufferLength || RSxKjXmDMKxHgwqOxhLLABffNJxA.Resize(P_0.bufferLength, preserveData: false))
				{
					try
					{
						RSxKjXmDMKxHgwqOxhLLABffNJxA.Write(P_0.buffer, P_0.bufferLength, P_0.bufferLength);
					}
					catch
					{
						return;
					}
					aIXEvWoZqKkkbJnaLiGkPdmGUVC.buffer = RSxKjXmDMKxHgwqOxhLLABffNJxA.Pointer;
					aIXEvWoZqKkkbJnaLiGkPdmGUVC.bufferLength = RSxKjXmDMKxHgwqOxhLLABffNJxA.Length;
					OIViklNQzJDykqHqXtcmdnxBJAn = true;
				}
			}

			public OutputReport ocBMgHPUEfnyyxPQUDbOUjWpaLKJ()
			{
				if (!OIViklNQzJDykqHqXtcmdnxBJAn)
				{
					return default(OutputReport);
				}
				OIViklNQzJDykqHqXtcmdnxBJAn = false;
				return aIXEvWoZqKkkbJnaLiGkPdmGUVC;
			}

			public OutputReport pXPBqaFODQsVnLzCzpUakJrysKB()
			{
				if (!OIViklNQzJDykqHqXtcmdnxBJAn)
				{
					return default(OutputReport);
				}
				return aIXEvWoZqKkkbJnaLiGkPdmGUVC;
			}

			public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
			{
				aIXEvWoZqKkkbJnaLiGkPdmGUVC.Clear();
				OIViklNQzJDykqHqXtcmdnxBJAn = false;
			}

			public void Dispose()
			{
				TKtGozqoOtxUzimyRPnpCnmqxwZ(true);
				GC.SuppressFinalize(this);
			}

			~BuXfeFPjpQPkpeeneHFIOaPBfEm()
			{
				TKtGozqoOtxUzimyRPnpCnmqxwZ(false);
			}

			protected virtual void TKtGozqoOtxUzimyRPnpCnmqxwZ(bool P_0)
			{
				if (!jgbpvYJovPcfzmcAEJzdxdrBmcm)
				{
					if (P_0 && RSxKjXmDMKxHgwqOxhLLABffNJxA != null)
					{
						RSxKjXmDMKxHgwqOxhLLABffNJxA.Dispose();
					}
					jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
				}
			}
		}

		private const bool vpssDgCzHWxccUaqAjHhGAISRxj = false;

		private const int IxiMalUHWmwXiWYInDdrrDvzZCs = 100;

		private const int ogzcRswSlduWdRvbRVWSiiRdgEk = 10000;

		private ThreadHelper byleSGZFcwgUJDntkRImTcwmoehC;

		private BuXfeFPjpQPkpeeneHFIOaPBfEm RSxKjXmDMKxHgwqOxhLLABffNJxA;

		private BuXfeFPjpQPkpeeneHFIOaPBfEm lzJFptxulxvomVaQRBBsKAveIPf;

		private bool VtteUzfdCsVSSGvXPAslsAmeQmik;

		private bool XrAXpRFFCZWxSkTUXpVlgetwinP;

		private readonly object ZVGTmZsaeONfLrORyTnKtjrbdty;

		private WriteReportDelegate JHkQrDnvOyakMfnVigDiAAHgtbi;

		private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

		public HidOutputReportHandler(WriteReportDelegate writeReportDelegate)
		{
			if (writeReportDelegate == null)
			{
				throw new ArgumentNullException("writeReportDelegate");
			}
			JHkQrDnvOyakMfnVigDiAAHgtbi = writeReportDelegate;
			RSxKjXmDMKxHgwqOxhLLABffNJxA = new BuXfeFPjpQPkpeeneHFIOaPBfEm();
			lzJFptxulxvomVaQRBBsKAveIPf = new BuXfeFPjpQPkpeeneHFIOaPBfEm();
			ZVGTmZsaeONfLrORyTnKtjrbdty = new object();
		}

		public void WriteReport(OutputReport report)
		{
			lock (ZVGTmZsaeONfLrORyTnKtjrbdty)
			{
				if (jgbpvYJovPcfzmcAEJzdxdrBmcm || !report.IsValid || !BlPUAqMlztMmaYIlhKUlkimOHBj())
				{
					return;
				}
				lock (RSxKjXmDMKxHgwqOxhLLABffNJxA)
				{
					RSxKjXmDMKxHgwqOxhLLABffNJxA.ppGuQvnElTiEWUsyXvcytHcccaq(ref report);
				}
			}
		}

		public void Clear()
		{
			if (RSxKjXmDMKxHgwqOxhLLABffNJxA != null)
			{
				if (lzJFptxulxvomVaQRBBsKAveIPf != null)
				{
					lock (RSxKjXmDMKxHgwqOxhLLABffNJxA)
					{
						lock (lzJFptxulxvomVaQRBBsKAveIPf)
						{
							RSxKjXmDMKxHgwqOxhLLABffNJxA.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
							lzJFptxulxvomVaQRBBsKAveIPf.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
							return;
						}
					}
				}
				lock (RSxKjXmDMKxHgwqOxhLLABffNJxA)
				{
					RSxKjXmDMKxHgwqOxhLLABffNJxA.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
					return;
				}
			}
			if (lzJFptxulxvomVaQRBBsKAveIPf != null)
			{
				lock (lzJFptxulxvomVaQRBBsKAveIPf)
				{
					lzJFptxulxvomVaQRBBsKAveIPf.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
				}
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
					byleSGZFcwgUJDntkRImTcwmoehC = ThreadHelper.CreateFixedTimeStep(100, 10000);
					byleSGZFcwgUJDntkRImTcwmoehC.ThreadUpdateEvent += ZpVyDeRjVCfmFgyOwuILBqYMSsP;
					byleSGZFcwgUJDntkRImTcwmoehC.ThreadStartedEvent += OUztxFpYBEsqxwtnHuJzsbStGPP;
					byleSGZFcwgUJDntkRImTcwmoehC.ThreadPreStopEvent += ErfUZAIjYKRHnRMcUwSJIVKiLsn;
					byleSGZFcwgUJDntkRImTcwmoehC.Start(wait: false);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (byleSGZFcwgUJDntkRImTcwmoehC != null)
					{
						byleSGZFcwgUJDntkRImTcwmoehC.Stop(wait: false);
					}
					VtteUzfdCsVSSGvXPAslsAmeQmik = true;
					return false;
				}
			}
			if (!byleSGZFcwgUJDntkRImTcwmoehC.isRunning)
			{
				byleSGZFcwgUJDntkRImTcwmoehC.Start(wait: false);
			}
			else
			{
				byleSGZFcwgUJDntkRImTcwmoehC.ResetTimeout();
			}
			return true;
		}

		private void gIRCwrbGepsojNlShhxbBPyTcLq()
		{
			lock (RSxKjXmDMKxHgwqOxhLLABffNJxA)
			{
				lock (lzJFptxulxvomVaQRBBsKAveIPf)
				{
					MiscTools.Swap(ref RSxKjXmDMKxHgwqOxhLLABffNJxA, ref lzJFptxulxvomVaQRBBsKAveIPf);
				}
			}
		}

		private void OUztxFpYBEsqxwtnHuJzsbStGPP()
		{
		}

		private void ErfUZAIjYKRHnRMcUwSJIVKiLsn()
		{
		}

		private void ZpVyDeRjVCfmFgyOwuILBqYMSsP()
		{
			gIRCwrbGepsojNlShhxbBPyTcLq();
			lock (lzJFptxulxvomVaQRBBsKAveIPf)
			{
				if (!lzJFptxulxvomVaQRBBsKAveIPf.HasReport)
				{
					return;
				}
				try
				{
					JHkQrDnvOyakMfnVigDiAAHgtbi(lzJFptxulxvomVaQRBBsKAveIPf.ocBMgHPUEfnyyxPQUDbOUjWpaLKJ());
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred while sending HID output report.\nMessage: " + ex.Message, requiredThreadSafety: true);
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~HidOutputReportHandler()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				return;
			}
			lock (ZVGTmZsaeONfLrORyTnKtjrbdty)
			{
				if (disposing)
				{
					Clear();
					if (byleSGZFcwgUJDntkRImTcwmoehC != null)
					{
						byleSGZFcwgUJDntkRImTcwmoehC.Dispose();
					}
				}
				jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
			}
		}
	}
}
