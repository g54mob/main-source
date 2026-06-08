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

		private class TYScNoNUMcrGDTbHRisTkJZPRfn : IDisposable
		{
			private bool ELLnXVZYtHliCDyzFKYtHCjfmUN;

			private OutputReport gqKbuxewRilKXcmQyNnrBvoFAgLF;

			private NativeBuffer RFwsiesdvuzfOJtmKvaOhRnxhoq;

			private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

			public bool HasReport => ELLnXVZYtHliCDyzFKYtHCjfmUN;

			public TYScNoNUMcrGDTbHRisTkJZPRfn()
			{
				RFwsiesdvuzfOJtmKvaOhRnxhoq = new NativeBuffer(0);
			}

			public void tjHMFUrKYfaqyjDWkjRrNWqyODl(ref OutputReport P_0)
			{
				ELLnXVZYtHliCDyzFKYtHCjfmUN = false;
				while (true)
				{
					switch (0x50B44B31 ^ 0x50B44B30)
					{
					case 0:
						continue;
					case 1:
						if (!P_0.IsValid)
						{
							return;
						}
						break;
					}
					break;
				}
				gqKbuxewRilKXcmQyNnrBvoFAgLF = P_0;
				if (RFwsiesdvuzfOJtmKvaOhRnxhoq.Length >= P_0.bufferLength || RFwsiesdvuzfOJtmKvaOhRnxhoq.Resize(P_0.bufferLength, preserveData: false))
				{
					try
					{
						RFwsiesdvuzfOJtmKvaOhRnxhoq.Write(P_0.buffer, P_0.bufferLength, P_0.bufferLength);
					}
					catch
					{
						return;
					}
					gqKbuxewRilKXcmQyNnrBvoFAgLF.buffer = RFwsiesdvuzfOJtmKvaOhRnxhoq.Pointer;
					gqKbuxewRilKXcmQyNnrBvoFAgLF.bufferLength = RFwsiesdvuzfOJtmKvaOhRnxhoq.Length;
					ELLnXVZYtHliCDyzFKYtHCjfmUN = true;
				}
			}

			public OutputReport wpMgnibPrZRESQEovOUXGqEjLiRW()
			{
				if (!ELLnXVZYtHliCDyzFKYtHCjfmUN)
				{
					return default(OutputReport);
				}
				ELLnXVZYtHliCDyzFKYtHCjfmUN = false;
				return gqKbuxewRilKXcmQyNnrBvoFAgLF;
			}

			public OutputReport jqEldRTgCqUoNamJGCYxYhseNmS()
			{
				if (!ELLnXVZYtHliCDyzFKYtHCjfmUN)
				{
					return default(OutputReport);
				}
				return gqKbuxewRilKXcmQyNnrBvoFAgLF;
			}

			public void tAgADqjTsMUxSqYXeDyJIdETYRAp()
			{
				gqKbuxewRilKXcmQyNnrBvoFAgLF.Clear();
				ELLnXVZYtHliCDyzFKYtHCjfmUN = false;
			}

			public void Dispose()
			{
				XUyPrOkreNDOTTMFamEakBsuIHM(true);
				GC.SuppressFinalize(this);
			}

			~TYScNoNUMcrGDTbHRisTkJZPRfn()
			{
				XUyPrOkreNDOTTMFamEakBsuIHM(false);
			}

			protected virtual void XUyPrOkreNDOTTMFamEakBsuIHM(bool P_0)
			{
				if (xRygqjRmTtURDPiwlgMmFcdNBrr)
				{
					return;
				}
				while (P_0 && RFwsiesdvuzfOJtmKvaOhRnxhoq != null)
				{
					RFwsiesdvuzfOJtmKvaOhRnxhoq.Dispose();
					int num = -1568067297;
					while (true)
					{
						switch (num ^ -1568067299)
						{
						case 0:
							num = -1568067300;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0027;
						}
						break;
					}
					continue;
					end_IL_0027:
					break;
				}
				xRygqjRmTtURDPiwlgMmFcdNBrr = true;
			}
		}

		private const bool ngxdncWmModROgjIpRMwKkKSzusf = false;

		private const int EddPYWSloKYuKrMmGsmwPzJdwrt = 100;

		private const int eZejvLuQpVYYRyXOumJXCNdjTJd = 10000;

		private ThreadHelper fqsCBjdBBAqwxHGTJtzpEGieeHqQ;

		private TYScNoNUMcrGDTbHRisTkJZPRfn RFwsiesdvuzfOJtmKvaOhRnxhoq;

		private TYScNoNUMcrGDTbHRisTkJZPRfn nTQCCIfJQHJuUiFowiwvcctkqMi;

		private bool HFkKVChhvESkmWpzwPLuarkiTPt;

		private bool PwPWygBTznyByBIyaAyqEfnsXBM;

		private readonly object TmXMGmwlFktQfQBgJyIPPCjxFKt;

		private WriteReportDelegate VTfVegjpfKjKiCIdVokxXgNgnWbk;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public HidOutputReportHandler(WriteReportDelegate writeReportDelegate)
		{
			if (writeReportDelegate == null)
			{
				throw new ArgumentNullException("writeReportDelegate");
			}
			VTfVegjpfKjKiCIdVokxXgNgnWbk = writeReportDelegate;
			RFwsiesdvuzfOJtmKvaOhRnxhoq = new TYScNoNUMcrGDTbHRisTkJZPRfn();
			nTQCCIfJQHJuUiFowiwvcctkqMi = new TYScNoNUMcrGDTbHRisTkJZPRfn();
			TmXMGmwlFktQfQBgJyIPPCjxFKt = new object();
		}

		public void WriteReport(OutputReport report)
		{
			lock (TmXMGmwlFktQfQBgJyIPPCjxFKt)
			{
				if (xRygqjRmTtURDPiwlgMmFcdNBrr)
				{
					return;
				}
				while (true)
				{
					int num;
					int num2;
					if (!report.IsValid)
					{
						num = 753481102;
						num2 = num;
					}
					else
					{
						num = 753481099;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x2CE9358A)
						{
						case 0:
							num = 753481103;
							continue;
						case 1:
						{
							int num3;
							if (!POOLsDGSQBqeMtHOQtJgSqyMaxe())
							{
								num = 753481097;
								num3 = num;
							}
							else
							{
								num = 753481096;
								num3 = num;
							}
							continue;
						}
						case 4:
							return;
						case 3:
							return;
						case 5:
							break;
						default:
							lock (RFwsiesdvuzfOJtmKvaOhRnxhoq)
							{
								RFwsiesdvuzfOJtmKvaOhRnxhoq.tjHMFUrKYfaqyjDWkjRrNWqyODl(ref report);
								return;
							}
						}
						break;
					}
				}
			}
		}

		public void Clear()
		{
			if (RFwsiesdvuzfOJtmKvaOhRnxhoq != null)
			{
				if (nTQCCIfJQHJuUiFowiwvcctkqMi != null)
				{
					lock (RFwsiesdvuzfOJtmKvaOhRnxhoq)
					{
						lock (nTQCCIfJQHJuUiFowiwvcctkqMi)
						{
							RFwsiesdvuzfOJtmKvaOhRnxhoq.tAgADqjTsMUxSqYXeDyJIdETYRAp();
							while (true)
							{
								int num = 285170251;
								while (true)
								{
									switch (num ^ 0x10FF5A4A)
									{
									case 2:
										break;
									default:
										return;
									case 1:
										goto IL_0056;
									case 0:
										return;
									}
									break;
									IL_0056:
									nTQCCIfJQHJuUiFowiwvcctkqMi.tAgADqjTsMUxSqYXeDyJIdETYRAp();
									num = 285170250;
								}
							}
						}
					}
				}
				lock (RFwsiesdvuzfOJtmKvaOhRnxhoq)
				{
					RFwsiesdvuzfOJtmKvaOhRnxhoq.tAgADqjTsMUxSqYXeDyJIdETYRAp();
					return;
				}
			}
			if (nTQCCIfJQHJuUiFowiwvcctkqMi != null)
			{
				lock (nTQCCIfJQHJuUiFowiwvcctkqMi)
				{
					nTQCCIfJQHJuUiFowiwvcctkqMi.tAgADqjTsMUxSqYXeDyJIdETYRAp();
				}
			}
		}

		private bool POOLsDGSQBqeMtHOQtJgSqyMaxe()
		{
			if (HFkKVChhvESkmWpzwPLuarkiTPt)
			{
				return false;
			}
			if (!BLojMYGzGzwkmTIAuatTfUggLHZd())
			{
				return false;
			}
			if (PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				return true;
			}
			PwPWygBTznyByBIyaAyqEfnsXBM = true;
			return true;
		}

		private bool BLojMYGzGzwkmTIAuatTfUggLHZd()
		{
			if (HFkKVChhvESkmWpzwPLuarkiTPt)
			{
				return false;
			}
			if (fqsCBjdBBAqwxHGTJtzpEGieeHqQ == null)
			{
				bool result = default(bool);
				try
				{
					fqsCBjdBBAqwxHGTJtzpEGieeHqQ = ThreadHelper.CreateFixedTimeStep(100, 10000);
					fqsCBjdBBAqwxHGTJtzpEGieeHqQ.ThreadUpdateEvent += ReWtOZFlieWvrDhaFtwIYbSOiVM;
					fqsCBjdBBAqwxHGTJtzpEGieeHqQ.ThreadStartedEvent += UykumIzakeWZeBPjyZBuMAybwSu;
					fqsCBjdBBAqwxHGTJtzpEGieeHqQ.ThreadPreStopEvent += QbmPovQnPabIFmjGzJtOgWWkmPa;
					fqsCBjdBBAqwxHGTJtzpEGieeHqQ.Start(wait: false);
					result = true;
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, requiredThreadSafety: true);
					while (true)
					{
						IL_0092:
						int num = -1963918126;
						while (true)
						{
							switch (num ^ -1963918128)
							{
							case 0:
								break;
							default:
								goto end_IL_0097;
							case 2:
								if (fqsCBjdBBAqwxHGTJtzpEGieeHqQ != null)
								{
									fqsCBjdBBAqwxHGTJtzpEGieeHqQ.Stop(wait: false);
									num = -1963918127;
									continue;
								}
								goto case 1;
							case 1:
								HFkKVChhvESkmWpzwPLuarkiTPt = true;
								result = false;
								num = -1963918125;
								continue;
							case 3:
								goto end_IL_0097;
							}
							goto IL_0092;
							continue;
							end_IL_0097:
							break;
						}
						break;
					}
				}
				return result;
			}
			if (!fqsCBjdBBAqwxHGTJtzpEGieeHqQ.isRunning)
			{
				fqsCBjdBBAqwxHGTJtzpEGieeHqQ.Start(wait: false);
			}
			else
			{
				while (true)
				{
					fqsCBjdBBAqwxHGTJtzpEGieeHqQ.ResetTimeout();
					int num2 = -1963918128;
					while (true)
					{
						switch (num2 ^ -1963918128)
						{
						case 2:
							num2 = -1963918127;
							continue;
						case 1:
							break;
						default:
							goto end_IL_011b;
						}
						break;
					}
					continue;
					end_IL_011b:
					break;
				}
			}
			return true;
		}

		private void sQTFNJdDjKfIMOXRzUMmxwNgaHQ()
		{
			lock (RFwsiesdvuzfOJtmKvaOhRnxhoq)
			{
				lock (nTQCCIfJQHJuUiFowiwvcctkqMi)
				{
					MiscTools.Swap(ref RFwsiesdvuzfOJtmKvaOhRnxhoq, ref nTQCCIfJQHJuUiFowiwvcctkqMi);
				}
			}
		}

		private void UykumIzakeWZeBPjyZBuMAybwSu()
		{
		}

		private void QbmPovQnPabIFmjGzJtOgWWkmPa()
		{
		}

		private void ReWtOZFlieWvrDhaFtwIYbSOiVM()
		{
			sQTFNJdDjKfIMOXRzUMmxwNgaHQ();
			lock (nTQCCIfJQHJuUiFowiwvcctkqMi)
			{
				if (!nTQCCIfJQHJuUiFowiwvcctkqMi.HasReport)
				{
					return;
				}
				try
				{
					VTfVegjpfKjKiCIdVokxXgNgnWbk(nTQCCIfJQHJuUiFowiwvcctkqMi.wpMgnibPrZRESQEovOUXGqEjLiRW());
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
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				return;
			}
			lock (TmXMGmwlFktQfQBgJyIPPCjxFKt)
			{
				if (disposing)
				{
					Clear();
					if (fqsCBjdBBAqwxHGTJtzpEGieeHqQ != null)
					{
						fqsCBjdBBAqwxHGTJtzpEGieeHqQ.Dispose();
					}
				}
				xRygqjRmTtURDPiwlgMmFcdNBrr = true;
			}
		}
	}
}
