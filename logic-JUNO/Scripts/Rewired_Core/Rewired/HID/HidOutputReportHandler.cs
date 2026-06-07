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

		private class PYhqeNktKuekqYpiElMNtxQXwzAs : IDisposable
		{
			private bool EcNzQTVfCjcKJaDXbhmHgAscgmUq;

			private OutputReport BnIPBOzIsVkRFHCCtdMidAxDofqL;

			private NativeBuffer xVUDYrdgrCrXswTefkSTOZBWvrsI;

			private bool fqDemcjrJBWumkskYBgVEKyNGSxb;

			public bool SMHavvgcLerjBETTBlxMfnNGRxiDA => EcNzQTVfCjcKJaDXbhmHgAscgmUq;

			public PYhqeNktKuekqYpiElMNtxQXwzAs()
			{
				xVUDYrdgrCrXswTefkSTOZBWvrsI = new NativeBuffer(0);
			}

			public void sHnzJulMfySoJvZBaYNFaqcojhcC(ref OutputReport P_0)
			{
				EcNzQTVfCjcKJaDXbhmHgAscgmUq = false;
				if (!P_0.IsValid)
				{
					return;
				}
				BnIPBOzIsVkRFHCCtdMidAxDofqL = P_0;
				if (xVUDYrdgrCrXswTefkSTOZBWvrsI.Length >= P_0.bufferLength || xVUDYrdgrCrXswTefkSTOZBWvrsI.Resize(P_0.bufferLength, preserveData: false))
				{
					try
					{
						xVUDYrdgrCrXswTefkSTOZBWvrsI.Write(P_0.buffer, P_0.bufferLength, P_0.bufferLength);
					}
					catch
					{
						return;
					}
					BnIPBOzIsVkRFHCCtdMidAxDofqL.buffer = xVUDYrdgrCrXswTefkSTOZBWvrsI.Pointer;
					BnIPBOzIsVkRFHCCtdMidAxDofqL.bufferLength = xVUDYrdgrCrXswTefkSTOZBWvrsI.Length;
					EcNzQTVfCjcKJaDXbhmHgAscgmUq = true;
				}
			}

			public OutputReport VPOzFWbqyssnjmmQZlQsYjIXRAoG()
			{
				if (!EcNzQTVfCjcKJaDXbhmHgAscgmUq)
				{
					return default(OutputReport);
				}
				EcNzQTVfCjcKJaDXbhmHgAscgmUq = false;
				return BnIPBOzIsVkRFHCCtdMidAxDofqL;
			}

			public OutputReport xWwOhArWAHuShfMZWgiyarvmDfhl()
			{
				if (!EcNzQTVfCjcKJaDXbhmHgAscgmUq)
				{
					return default(OutputReport);
				}
				return BnIPBOzIsVkRFHCCtdMidAxDofqL;
			}

			public void mOcMKQUHperDPAbuFmhWTMKHRAbR()
			{
				BnIPBOzIsVkRFHCCtdMidAxDofqL.Clear();
				EcNzQTVfCjcKJaDXbhmHgAscgmUq = false;
			}

			public void Dispose()
			{
				nwHajIwgZlXHBAHuWebMgVdUectjb(true);
				GC.SuppressFinalize(this);
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			protected virtual void jclDFmoFuREtvfJYTAKYgSTmonEjb()
			{
				try
				{
					nwHajIwgZlXHBAHuWebMgVdUectjb(false);
				}
				finally
				{
					base.Finalize();
				}
			}

			protected virtual void nwHajIwgZlXHBAHuWebMgVdUectjb(bool P_0)
			{
				if (!fqDemcjrJBWumkskYBgVEKyNGSxb)
				{
					if (P_0 && xVUDYrdgrCrXswTefkSTOZBWvrsI != null)
					{
						xVUDYrdgrCrXswTefkSTOZBWvrsI.Dispose();
					}
					fqDemcjrJBWumkskYBgVEKyNGSxb = true;
				}
			}
		}

		private const bool hYqZzNPvSxkaWjPEGfrpffilVYZN = false;

		private const int VMUlblLDxqDILuSzVdZSIpGSzWNC = 100;

		private const int kapxCCVDYVGWRUsxycETlwQHEDVK = 10000;

		private ThreadHelper sezBQesspvaXMdyXJrzlRleHYPuD;

		private PYhqeNktKuekqYpiElMNtxQXwzAs cnccGLsAoBFzGSDYVAWhINwKRTen;

		private PYhqeNktKuekqYpiElMNtxQXwzAs SkZiCMjExDtQKfQEfwROpSOnQSbW;

		private bool WTJaPQBwLrgRkrobhoTnEgMvfBUaA;

		private bool YENEemoRbdbTAaVdyIJdNiAjhCxN;

		private readonly object dKCPmgrDAJfpveifhBFiXwQvulKQ;

		private WriteReportDelegate DsaaXGZlUsRrEWlPgARkvxblcqxE;

		private bool ToNvtKtlNQgAnJiWYTiEWxvnradBA;

		public HidOutputReportHandler(WriteReportDelegate P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("writeReportDelegate");
			}
			DsaaXGZlUsRrEWlPgARkvxblcqxE = P_0;
			cnccGLsAoBFzGSDYVAWhINwKRTen = new PYhqeNktKuekqYpiElMNtxQXwzAs();
			SkZiCMjExDtQKfQEfwROpSOnQSbW = new PYhqeNktKuekqYpiElMNtxQXwzAs();
			dKCPmgrDAJfpveifhBFiXwQvulKQ = new object();
		}

		public void WriteReport(OutputReport report)
		{
			lock (dKCPmgrDAJfpveifhBFiXwQvulKQ)
			{
				if (ToNvtKtlNQgAnJiWYTiEWxvnradBA || !report.IsValid || !aPzXnSUuBQPJkoObscDAipXHdAQAA())
				{
					return;
				}
				lock (cnccGLsAoBFzGSDYVAWhINwKRTen)
				{
					cnccGLsAoBFzGSDYVAWhINwKRTen.sHnzJulMfySoJvZBaYNFaqcojhcC(ref report);
				}
			}
		}

		public void Clear()
		{
			if (cnccGLsAoBFzGSDYVAWhINwKRTen != null)
			{
				if (SkZiCMjExDtQKfQEfwROpSOnQSbW != null)
				{
					lock (cnccGLsAoBFzGSDYVAWhINwKRTen)
					{
						lock (SkZiCMjExDtQKfQEfwROpSOnQSbW)
						{
							cnccGLsAoBFzGSDYVAWhINwKRTen.mOcMKQUHperDPAbuFmhWTMKHRAbR();
							SkZiCMjExDtQKfQEfwROpSOnQSbW.mOcMKQUHperDPAbuFmhWTMKHRAbR();
							return;
						}
					}
				}
				lock (cnccGLsAoBFzGSDYVAWhINwKRTen)
				{
					cnccGLsAoBFzGSDYVAWhINwKRTen.mOcMKQUHperDPAbuFmhWTMKHRAbR();
					return;
				}
			}
			if (SkZiCMjExDtQKfQEfwROpSOnQSbW != null)
			{
				lock (SkZiCMjExDtQKfQEfwROpSOnQSbW)
				{
					SkZiCMjExDtQKfQEfwROpSOnQSbW.mOcMKQUHperDPAbuFmhWTMKHRAbR();
				}
			}
		}

		private bool aPzXnSUuBQPJkoObscDAipXHdAQAA()
		{
			if (WTJaPQBwLrgRkrobhoTnEgMvfBUaA)
			{
				return false;
			}
			if (!fOjoKETMZYskcmKrTFJlEetRZJQY())
			{
				return false;
			}
			if (YENEemoRbdbTAaVdyIJdNiAjhCxN)
			{
				return true;
			}
			YENEemoRbdbTAaVdyIJdNiAjhCxN = true;
			return true;
		}

		private bool fOjoKETMZYskcmKrTFJlEetRZJQY()
		{
			if (WTJaPQBwLrgRkrobhoTnEgMvfBUaA)
			{
				return false;
			}
			if (sezBQesspvaXMdyXJrzlRleHYPuD == null)
			{
				try
				{
					sezBQesspvaXMdyXJrzlRleHYPuD = ThreadHelper.CreateFixedTimeStep(100, 10000);
					sezBQesspvaXMdyXJrzlRleHYPuD.ThreadUpdateEvent += DjctAOsTmPUocNbrCXlaIJGdfZteA;
					sezBQesspvaXMdyXJrzlRleHYPuD.ThreadStartedEvent += xlwoIheSCNISbOCickjosKtIrLsl;
					sezBQesspvaXMdyXJrzlRleHYPuD.ThreadPreStopEvent += cyalquxRedGeqBJPlGMBOZzZvRA;
					sezBQesspvaXMdyXJrzlRleHYPuD.Start(wait: false);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (sezBQesspvaXMdyXJrzlRleHYPuD != null)
					{
						sezBQesspvaXMdyXJrzlRleHYPuD.Stop(wait: false);
					}
					WTJaPQBwLrgRkrobhoTnEgMvfBUaA = true;
					return false;
				}
			}
			if (!sezBQesspvaXMdyXJrzlRleHYPuD.isRunning)
			{
				sezBQesspvaXMdyXJrzlRleHYPuD.Start(wait: false);
			}
			else
			{
				sezBQesspvaXMdyXJrzlRleHYPuD.ResetTimeout();
			}
			return true;
		}

		private void RNGcQHFsrhuXGoJufeAhNsCkVxCK()
		{
			lock (cnccGLsAoBFzGSDYVAWhINwKRTen)
			{
				lock (SkZiCMjExDtQKfQEfwROpSOnQSbW)
				{
					MiscTools.Swap(ref cnccGLsAoBFzGSDYVAWhINwKRTen, ref SkZiCMjExDtQKfQEfwROpSOnQSbW);
				}
			}
		}

		private void xlwoIheSCNISbOCickjosKtIrLsl()
		{
		}

		private void cyalquxRedGeqBJPlGMBOZzZvRA()
		{
		}

		private void DjctAOsTmPUocNbrCXlaIJGdfZteA()
		{
			RNGcQHFsrhuXGoJufeAhNsCkVxCK();
			lock (SkZiCMjExDtQKfQEfwROpSOnQSbW)
			{
				if (!SkZiCMjExDtQKfQEfwROpSOnQSbW.SMHavvgcLerjBETTBlxMfnNGRxiDA)
				{
					return;
				}
				try
				{
					DsaaXGZlUsRrEWlPgARkvxblcqxE(SkZiCMjExDtQKfQEfwROpSOnQSbW.VPOzFWbqyssnjmmQZlQsYjIXRAoG());
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

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		~HidOutputReportHandler()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (ToNvtKtlNQgAnJiWYTiEWxvnradBA)
			{
				return;
			}
			lock (dKCPmgrDAJfpveifhBFiXwQvulKQ)
			{
				if (disposing)
				{
					Clear();
					if (sezBQesspvaXMdyXJrzlRleHYPuD != null)
					{
						sezBQesspvaXMdyXJrzlRleHYPuD.Dispose();
					}
				}
				ToNvtKtlNQgAnJiWYTiEWxvnradBA = true;
			}
		}
	}
}
