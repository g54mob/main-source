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

		private class vaddUbanITmsnbYVrGZJIOefkUY : IDisposable
		{
			private bool ckwRgCaudiwqyvAjhnUflgQTNiq;

			private OutputReport EOlUCkNDPBSDtOpWKGSrNEBygFcF;

			private NativeBuffer rFLAGvDUpBFmqIrakAVIcTSKRJFP;

			private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

			public bool HasReport => ckwRgCaudiwqyvAjhnUflgQTNiq;

			public vaddUbanITmsnbYVrGZJIOefkUY()
			{
				rFLAGvDUpBFmqIrakAVIcTSKRJFP = new NativeBuffer(0);
			}

			public void DjeFfRGAOYExEFPAUeuxcrHMXoCE(ref OutputReport P_0)
			{
				ckwRgCaudiwqyvAjhnUflgQTNiq = false;
				if (!P_0.IsValid)
				{
					return;
				}
				EOlUCkNDPBSDtOpWKGSrNEBygFcF = P_0;
				if (rFLAGvDUpBFmqIrakAVIcTSKRJFP.Length >= P_0.bufferLength || rFLAGvDUpBFmqIrakAVIcTSKRJFP.Resize(P_0.bufferLength, preserveData: false))
				{
					try
					{
						rFLAGvDUpBFmqIrakAVIcTSKRJFP.Write(P_0.buffer, P_0.bufferLength, P_0.bufferLength);
					}
					catch
					{
						return;
					}
					EOlUCkNDPBSDtOpWKGSrNEBygFcF.buffer = rFLAGvDUpBFmqIrakAVIcTSKRJFP.Pointer;
					EOlUCkNDPBSDtOpWKGSrNEBygFcF.bufferLength = rFLAGvDUpBFmqIrakAVIcTSKRJFP.Length;
					ckwRgCaudiwqyvAjhnUflgQTNiq = true;
				}
			}

			public OutputReport GplzPjcnnsXRyolgPJzXQbjDlZk()
			{
				if (!ckwRgCaudiwqyvAjhnUflgQTNiq)
				{
					return default(OutputReport);
				}
				ckwRgCaudiwqyvAjhnUflgQTNiq = false;
				return EOlUCkNDPBSDtOpWKGSrNEBygFcF;
			}

			public OutputReport VrhLKUcHwXVrpIiicjDvekIUwyl()
			{
				if (!ckwRgCaudiwqyvAjhnUflgQTNiq)
				{
					return default(OutputReport);
				}
				return EOlUCkNDPBSDtOpWKGSrNEBygFcF;
			}

			public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
			{
				EOlUCkNDPBSDtOpWKGSrNEBygFcF.Clear();
				ckwRgCaudiwqyvAjhnUflgQTNiq = false;
			}

			public void Dispose()
			{
				hPYtPMXxgzKzMhWWBZyeOBKCxhk(true);
				GC.SuppressFinalize(this);
			}

			~vaddUbanITmsnbYVrGZJIOefkUY()
			{
				hPYtPMXxgzKzMhWWBZyeOBKCxhk(false);
			}

			protected virtual void hPYtPMXxgzKzMhWWBZyeOBKCxhk(bool P_0)
			{
				if (!JtZAxieDBYjDdfBgPPJgrNSxYmS)
				{
					if (P_0 && rFLAGvDUpBFmqIrakAVIcTSKRJFP != null)
					{
						rFLAGvDUpBFmqIrakAVIcTSKRJFP.Dispose();
					}
					JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
				}
			}
		}

		private const bool XFEFavzvULMEsRMKXlVsKUrwThT = false;

		private const int udIBxXjbglORuFUqgeHyfpuHDXGh = 100;

		private const int ORuLSdLOJmBfsEJLUNLPqqSPwUH = 10000;

		private ThreadHelper TOLvxyiiNhqpXirBdtAdqoJEeaJ;

		private vaddUbanITmsnbYVrGZJIOefkUY rFLAGvDUpBFmqIrakAVIcTSKRJFP;

		private vaddUbanITmsnbYVrGZJIOefkUY BSvaVMWMBiIbkIqxCDwfKUCWNzF;

		private bool jhLrtTQylzmdSwmxOgocATNSjcGf;

		private bool rXobafaxvUDrItlgWahiaYSKJqn;

		private readonly object tmkyxdFfTVIaLozunrFHjAOPTvU;

		private WriteReportDelegate luGCEveAzhGZOJsddfHhrWoQCfQe;

		private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

		public HidOutputReportHandler(WriteReportDelegate writeReportDelegate)
		{
			if (writeReportDelegate == null)
			{
				throw new ArgumentNullException("writeReportDelegate");
			}
			luGCEveAzhGZOJsddfHhrWoQCfQe = writeReportDelegate;
			rFLAGvDUpBFmqIrakAVIcTSKRJFP = new vaddUbanITmsnbYVrGZJIOefkUY();
			BSvaVMWMBiIbkIqxCDwfKUCWNzF = new vaddUbanITmsnbYVrGZJIOefkUY();
			tmkyxdFfTVIaLozunrFHjAOPTvU = new object();
		}

		public void WriteReport(OutputReport report)
		{
			lock (tmkyxdFfTVIaLozunrFHjAOPTvU)
			{
				if (JtZAxieDBYjDdfBgPPJgrNSxYmS || !report.IsValid || !zptlECrQiHzwILTuMWcaXVcgZFC())
				{
					return;
				}
				lock (rFLAGvDUpBFmqIrakAVIcTSKRJFP)
				{
					rFLAGvDUpBFmqIrakAVIcTSKRJFP.DjeFfRGAOYExEFPAUeuxcrHMXoCE(ref report);
				}
			}
		}

		public void Clear()
		{
			if (rFLAGvDUpBFmqIrakAVIcTSKRJFP != null)
			{
				if (BSvaVMWMBiIbkIqxCDwfKUCWNzF != null)
				{
					lock (rFLAGvDUpBFmqIrakAVIcTSKRJFP)
					{
						lock (BSvaVMWMBiIbkIqxCDwfKUCWNzF)
						{
							rFLAGvDUpBFmqIrakAVIcTSKRJFP.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
							BSvaVMWMBiIbkIqxCDwfKUCWNzF.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
							return;
						}
					}
				}
				lock (rFLAGvDUpBFmqIrakAVIcTSKRJFP)
				{
					rFLAGvDUpBFmqIrakAVIcTSKRJFP.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
					return;
				}
			}
			if (BSvaVMWMBiIbkIqxCDwfKUCWNzF != null)
			{
				lock (BSvaVMWMBiIbkIqxCDwfKUCWNzF)
				{
					BSvaVMWMBiIbkIqxCDwfKUCWNzF.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
				}
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
					TOLvxyiiNhqpXirBdtAdqoJEeaJ = ThreadHelper.CreateFixedTimeStep(100, 10000);
					TOLvxyiiNhqpXirBdtAdqoJEeaJ.ThreadUpdateEvent += fdflmMgrgHwHTbCydBMWJejqPcdh;
					TOLvxyiiNhqpXirBdtAdqoJEeaJ.ThreadStartedEvent += uyDMjdGgmLZYbxBXIwRceTdLXYp;
					TOLvxyiiNhqpXirBdtAdqoJEeaJ.ThreadPreStopEvent += aBzdyzdePspxWSDHmGWMjWIFhH;
					TOLvxyiiNhqpXirBdtAdqoJEeaJ.Start(wait: false);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (TOLvxyiiNhqpXirBdtAdqoJEeaJ != null)
					{
						TOLvxyiiNhqpXirBdtAdqoJEeaJ.Stop(wait: false);
					}
					jhLrtTQylzmdSwmxOgocATNSjcGf = true;
					return false;
				}
			}
			if (!TOLvxyiiNhqpXirBdtAdqoJEeaJ.isRunning)
			{
				TOLvxyiiNhqpXirBdtAdqoJEeaJ.Start(wait: false);
			}
			else
			{
				TOLvxyiiNhqpXirBdtAdqoJEeaJ.ResetTimeout();
			}
			return true;
		}

		private void GPqjeISmdvXHacPLXxpqFwwKgit()
		{
			lock (rFLAGvDUpBFmqIrakAVIcTSKRJFP)
			{
				lock (BSvaVMWMBiIbkIqxCDwfKUCWNzF)
				{
					MiscTools.Swap(ref rFLAGvDUpBFmqIrakAVIcTSKRJFP, ref BSvaVMWMBiIbkIqxCDwfKUCWNzF);
				}
			}
		}

		private void uyDMjdGgmLZYbxBXIwRceTdLXYp()
		{
		}

		private void aBzdyzdePspxWSDHmGWMjWIFhH()
		{
		}

		private void fdflmMgrgHwHTbCydBMWJejqPcdh()
		{
			GPqjeISmdvXHacPLXxpqFwwKgit();
			lock (BSvaVMWMBiIbkIqxCDwfKUCWNzF)
			{
				if (!BSvaVMWMBiIbkIqxCDwfKUCWNzF.HasReport)
				{
					return;
				}
				try
				{
					luGCEveAzhGZOJsddfHhrWoQCfQe(BSvaVMWMBiIbkIqxCDwfKUCWNzF.GplzPjcnnsXRyolgPJzXQbjDlZk());
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
			if (JtZAxieDBYjDdfBgPPJgrNSxYmS)
			{
				return;
			}
			lock (tmkyxdFfTVIaLozunrFHjAOPTvU)
			{
				if (disposing)
				{
					Clear();
					if (TOLvxyiiNhqpXirBdtAdqoJEeaJ != null)
					{
						TOLvxyiiNhqpXirBdtAdqoJEeaJ.Dispose();
					}
				}
				JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
			}
		}
	}
}
