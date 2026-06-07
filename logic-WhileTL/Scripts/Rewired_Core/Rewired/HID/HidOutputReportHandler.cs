using System;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class HidOutputReportHandler : IDisposable
	{
		[CustomObfuscation(rename = false)]
		public delegate bool WriteReportDelegate(OutputReport report);

		private class hpBpsZzTtfHfGUoBUYMDeeulaIYdA : IDisposable
		{
			private bool wDCJpyjQAEWlJWCrUsybRjEFFTuW;

			private OutputReport UzXuFQCisnMmCjGmhHhtpDDoHNmd;

			private NativeBuffer bqxkjHAQVvpAPAFoTMYIfbENRmFH;

			private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

			public bool sRCVzcNaOniwnKDODIGDooAAAiEi => wDCJpyjQAEWlJWCrUsybRjEFFTuW;

			public hpBpsZzTtfHfGUoBUYMDeeulaIYdA()
			{
				bqxkjHAQVvpAPAFoTMYIfbENRmFH = new NativeBuffer(0);
			}

			public void NlURahNHlqsRpibAjglbNPZAdkKKA(ref OutputReport P_0)
			{
				wDCJpyjQAEWlJWCrUsybRjEFFTuW = false;
				if (!P_0.IsValid)
				{
					return;
				}
				UzXuFQCisnMmCjGmhHhtpDDoHNmd = P_0;
				if (bqxkjHAQVvpAPAFoTMYIfbENRmFH.Length >= P_0.bufferLength || bqxkjHAQVvpAPAFoTMYIfbENRmFH.Resize(P_0.bufferLength, preserveData: false))
				{
					try
					{
						bqxkjHAQVvpAPAFoTMYIfbENRmFH.Write(P_0.buffer, P_0.bufferLength, P_0.bufferLength);
					}
					catch
					{
						return;
					}
					UzXuFQCisnMmCjGmhHhtpDDoHNmd.buffer = bqxkjHAQVvpAPAFoTMYIfbENRmFH.Pointer;
					UzXuFQCisnMmCjGmhHhtpDDoHNmd.bufferLength = bqxkjHAQVvpAPAFoTMYIfbENRmFH.Length;
					wDCJpyjQAEWlJWCrUsybRjEFFTuW = true;
				}
			}

			public OutputReport INabTxDQSVCZHDuqyiRcqnDDBqY()
			{
				if (!wDCJpyjQAEWlJWCrUsybRjEFFTuW)
				{
					return default(OutputReport);
				}
				wDCJpyjQAEWlJWCrUsybRjEFFTuW = false;
				return UzXuFQCisnMmCjGmhHhtpDDoHNmd;
			}

			public OutputReport VGTahqhxZbFEQtneRmuvCMYCKknKc()
			{
				if (!wDCJpyjQAEWlJWCrUsybRjEFFTuW)
				{
					return default(OutputReport);
				}
				return UzXuFQCisnMmCjGmhHhtpDDoHNmd;
			}

			public void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
			{
				UzXuFQCisnMmCjGmhHhtpDDoHNmd.Clear();
				wDCJpyjQAEWlJWCrUsybRjEFFTuW = false;
			}

			public void Dispose()
			{
				jZtwTxQjIMBZMEAKpWMmMcJOortz(true);
				GC.SuppressFinalize(this);
			}

			protected virtual void hQVInFWrTMOWfdrNDZJGjCGXxatd()
			{
				try
				{
					jZtwTxQjIMBZMEAKpWMmMcJOortz(false);
				}
				finally
				{
					base.Finalize();
				}
			}

			protected virtual void jZtwTxQjIMBZMEAKpWMmMcJOortz(bool P_0)
			{
				if (!JChPmMbeaoLOGQvosPYqDDInSiCs)
				{
					if (P_0 && bqxkjHAQVvpAPAFoTMYIfbENRmFH != null)
					{
						bqxkjHAQVvpAPAFoTMYIfbENRmFH.Dispose();
					}
					JChPmMbeaoLOGQvosPYqDDInSiCs = true;
				}
			}
		}

		private const bool BKsilTaJhlUNPuqWqCecaOduhJXs = false;

		private const int eOmoHxgeRXDADkcyDkWkpZiLiFIUA = 100;

		private const int AvzWhqMwrQCAOrnPvQSJQYkLgeKs = 10000;

		private ThreadHelper FBhTBCloRTksrXPdIRhzYVUCiBYB;

		private hpBpsZzTtfHfGUoBUYMDeeulaIYdA bqxkjHAQVvpAPAFoTMYIfbENRmFH;

		private hpBpsZzTtfHfGUoBUYMDeeulaIYdA PBNwGrFXxSDKHnyqvUedaHEAkJFu;

		private bool titAFvTkOTJqbZwzzviokBDGEiIM;

		private bool juAmOHdlEuZcdEbopfsigKMAJgtHb;

		private readonly object hFCqYLWjqvxQkBhcEcWVFsEXnfGw;

		private WriteReportDelegate feiubLNaWZOVlLLxWYVtygoItHQi;

		private bool JChPmMbeaoLOGQvosPYqDDInSiCs;

		public HidOutputReportHandler(WriteReportDelegate P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("writeReportDelegate");
			}
			feiubLNaWZOVlLLxWYVtygoItHQi = P_0;
			bqxkjHAQVvpAPAFoTMYIfbENRmFH = new hpBpsZzTtfHfGUoBUYMDeeulaIYdA();
			PBNwGrFXxSDKHnyqvUedaHEAkJFu = new hpBpsZzTtfHfGUoBUYMDeeulaIYdA();
			hFCqYLWjqvxQkBhcEcWVFsEXnfGw = new object();
		}

		public void WriteReport(OutputReport report)
		{
			lock (hFCqYLWjqvxQkBhcEcWVFsEXnfGw)
			{
				if (JChPmMbeaoLOGQvosPYqDDInSiCs || !report.IsValid || !zBFbVgFivIFkRriBBSLwgWJemDVY())
				{
					return;
				}
				lock (bqxkjHAQVvpAPAFoTMYIfbENRmFH)
				{
					bqxkjHAQVvpAPAFoTMYIfbENRmFH.NlURahNHlqsRpibAjglbNPZAdkKKA(ref report);
				}
			}
		}

		public void Clear()
		{
			if (bqxkjHAQVvpAPAFoTMYIfbENRmFH != null)
			{
				if (PBNwGrFXxSDKHnyqvUedaHEAkJFu != null)
				{
					lock (bqxkjHAQVvpAPAFoTMYIfbENRmFH)
					{
						lock (PBNwGrFXxSDKHnyqvUedaHEAkJFu)
						{
							bqxkjHAQVvpAPAFoTMYIfbENRmFH.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
							PBNwGrFXxSDKHnyqvUedaHEAkJFu.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
							return;
						}
					}
				}
				lock (bqxkjHAQVvpAPAFoTMYIfbENRmFH)
				{
					bqxkjHAQVvpAPAFoTMYIfbENRmFH.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
					return;
				}
			}
			if (PBNwGrFXxSDKHnyqvUedaHEAkJFu != null)
			{
				lock (PBNwGrFXxSDKHnyqvUedaHEAkJFu)
				{
					PBNwGrFXxSDKHnyqvUedaHEAkJFu.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
				}
			}
		}

		private bool zBFbVgFivIFkRriBBSLwgWJemDVY()
		{
			if (titAFvTkOTJqbZwzzviokBDGEiIM)
			{
				return false;
			}
			if (!nlzQIjcaveGwfYRGjIPPWvHGvgmu())
			{
				return false;
			}
			if (juAmOHdlEuZcdEbopfsigKMAJgtHb)
			{
				return true;
			}
			juAmOHdlEuZcdEbopfsigKMAJgtHb = true;
			return true;
		}

		private bool nlzQIjcaveGwfYRGjIPPWvHGvgmu()
		{
			if (titAFvTkOTJqbZwzzviokBDGEiIM)
			{
				return false;
			}
			if (FBhTBCloRTksrXPdIRhzYVUCiBYB == null)
			{
				try
				{
					FBhTBCloRTksrXPdIRhzYVUCiBYB = ThreadHelper.CreateFixedTimeStep(100, 10000);
					FBhTBCloRTksrXPdIRhzYVUCiBYB.ThreadUpdateEvent += tnVCzszeDfIDeEoeMJVWGUzaiznE;
					FBhTBCloRTksrXPdIRhzYVUCiBYB.ThreadStartedEvent += grvdqVAVZlXOMTOXrwdkFGhBKFzSA;
					FBhTBCloRTksrXPdIRhzYVUCiBYB.ThreadPreStopEvent += otfyXMsJIfElMbAAcLnWgZrAJVNP;
					FBhTBCloRTksrXPdIRhzYVUCiBYB.Start(wait: false);
					return true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					if (FBhTBCloRTksrXPdIRhzYVUCiBYB != null)
					{
						FBhTBCloRTksrXPdIRhzYVUCiBYB.Stop(wait: false);
					}
					titAFvTkOTJqbZwzzviokBDGEiIM = true;
					return false;
				}
			}
			if (!FBhTBCloRTksrXPdIRhzYVUCiBYB.isRunning)
			{
				FBhTBCloRTksrXPdIRhzYVUCiBYB.Start(wait: false);
			}
			else
			{
				FBhTBCloRTksrXPdIRhzYVUCiBYB.ResetTimeout();
			}
			return true;
		}

		private void QAGMFcLXYJqYBZHPeogwlogKVyxS()
		{
			lock (bqxkjHAQVvpAPAFoTMYIfbENRmFH)
			{
				lock (PBNwGrFXxSDKHnyqvUedaHEAkJFu)
				{
					MiscTools.Swap(ref bqxkjHAQVvpAPAFoTMYIfbENRmFH, ref PBNwGrFXxSDKHnyqvUedaHEAkJFu);
				}
			}
		}

		private void grvdqVAVZlXOMTOXrwdkFGhBKFzSA()
		{
		}

		private void otfyXMsJIfElMbAAcLnWgZrAJVNP()
		{
		}

		private void tnVCzszeDfIDeEoeMJVWGUzaiznE()
		{
			QAGMFcLXYJqYBZHPeogwlogKVyxS();
			lock (PBNwGrFXxSDKHnyqvUedaHEAkJFu)
			{
				if (!PBNwGrFXxSDKHnyqvUedaHEAkJFu.sRCVzcNaOniwnKDODIGDooAAAiEi)
				{
					return;
				}
				try
				{
					feiubLNaWZOVlLLxWYVtygoItHQi(PBNwGrFXxSDKHnyqvUedaHEAkJFu.INabTxDQSVCZHDuqyiRcqnDDBqY());
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
			if (JChPmMbeaoLOGQvosPYqDDInSiCs)
			{
				return;
			}
			lock (hFCqYLWjqvxQkBhcEcWVFsEXnfGw)
			{
				if (disposing)
				{
					Clear();
					if (FBhTBCloRTksrXPdIRhzYVUCiBYB != null)
					{
						FBhTBCloRTksrXPdIRhzYVUCiBYB.Dispose();
					}
				}
				JChPmMbeaoLOGQvosPYqDDInSiCs = true;
			}
		}
	}
}
