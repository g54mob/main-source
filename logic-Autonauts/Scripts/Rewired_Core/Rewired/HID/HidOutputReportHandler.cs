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

		private class yCUKZlfPtiIeEsniSUPGkHtQWiE : IDisposable
		{
			private bool zpNNGKrJELhgZkiIWidsZVZuTtoi;

			private OutputReport LNQRTcEorsTDIJhAfALgdIXLlSo;

			private NativeBuffer ugDapCqSwatVwHFNRCJxFJwpWF;

			private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

			public bool HasReport
			{
				get
				{
					return zpNNGKrJELhgZkiIWidsZVZuTtoi;
				}
			}

			public yCUKZlfPtiIeEsniSUPGkHtQWiE()
			{
				ugDapCqSwatVwHFNRCJxFJwpWF = new NativeBuffer(0);
			}

			public void AkTmoTRZtvtOnGarboEsTlSzABC(ref OutputReport P_0)
			{
				zpNNGKrJELhgZkiIWidsZVZuTtoi = false;
				if (!P_0.IsValid)
				{
					return;
				}
				while (true)
				{
					LNQRTcEorsTDIJhAfALgdIXLlSo = P_0;
					if (ugDapCqSwatVwHFNRCJxFJwpWF.Length >= P_0.bufferLength)
					{
						break;
					}
					int num = 1218375038;
					while (true)
					{
						switch (num ^ 0x489EED7C)
						{
						case 0:
							num = 1218375037;
							continue;
						case 1:
							break;
						default:
							goto IL_0054;
						}
						break;
					}
					continue;
					IL_0054:
					if (ugDapCqSwatVwHFNRCJxFJwpWF.Resize(P_0.bufferLength, false))
					{
						break;
					}
					return;
				}
				try
				{
					ugDapCqSwatVwHFNRCJxFJwpWF.Write(P_0.buffer, P_0.bufferLength, P_0.bufferLength);
				}
				catch
				{
					return;
				}
				LNQRTcEorsTDIJhAfALgdIXLlSo.buffer = ugDapCqSwatVwHFNRCJxFJwpWF.Pointer;
				while (true)
				{
					int num2 = 1218375037;
					while (true)
					{
						switch (num2 ^ 0x489EED7C)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_00c1;
						case 2:
							return;
						}
						break;
						IL_00c1:
						LNQRTcEorsTDIJhAfALgdIXLlSo.bufferLength = ugDapCqSwatVwHFNRCJxFJwpWF.Length;
						zpNNGKrJELhgZkiIWidsZVZuTtoi = true;
						num2 = 1218375038;
					}
				}
			}

			public OutputReport NiMIurfbUDZBBxgRcihSmSqsVba()
			{
				if (!zpNNGKrJELhgZkiIWidsZVZuTtoi)
				{
					return default(OutputReport);
				}
				zpNNGKrJELhgZkiIWidsZVZuTtoi = false;
				return LNQRTcEorsTDIJhAfALgdIXLlSo;
			}

			public OutputReport OsUxCOnETaFJARvTVBjokEPpLMpa()
			{
				if (!zpNNGKrJELhgZkiIWidsZVZuTtoi)
				{
					return default(OutputReport);
				}
				return LNQRTcEorsTDIJhAfALgdIXLlSo;
			}

			public void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
			{
				LNQRTcEorsTDIJhAfALgdIXLlSo.Clear();
				zpNNGKrJELhgZkiIWidsZVZuTtoi = false;
			}

			public void Dispose()
			{
				yByeqDDEKPzAKiUpxfZrBkMpiHln(true);
				GC.SuppressFinalize(this);
			}

			~yCUKZlfPtiIeEsniSUPGkHtQWiE()
			{
				yByeqDDEKPzAKiUpxfZrBkMpiHln(false);
			}

			protected virtual void yByeqDDEKPzAKiUpxfZrBkMpiHln(bool P_0)
			{
				if (QQqHByfwytAJSuMZiCPjJlZYHKG)
				{
					return;
				}
				while (true)
				{
					int num;
					int num2;
					if (!P_0)
					{
						num = -1848192632;
						num2 = num;
					}
					else
					{
						num = -1848192629;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -1848192629)
						{
						case 2:
							num = -1848192630;
							continue;
						case 1:
							break;
						case 0:
							if (ugDapCqSwatVwHFNRCJxFJwpWF != null)
							{
								ugDapCqSwatVwHFNRCJxFJwpWF.Dispose();
								num = -1848192632;
								continue;
							}
							goto default;
						default:
							QQqHByfwytAJSuMZiCPjJlZYHKG = true;
							return;
						}
						break;
					}
				}
			}
		}

		private const bool CkvrKdcqfsCIFiWhcZdzoqgHQhBP = false;

		private const int xcfIsNaYDUsDXIQFNtRdLmdodlC = 100;

		private const int DGsDSWaUpTyRIiNsxNHOaOnkeAEB = 10000;

		private ThreadHelper CogoXqfgoUvretoPEYaoWIkbAAZ;

		private yCUKZlfPtiIeEsniSUPGkHtQWiE ugDapCqSwatVwHFNRCJxFJwpWF;

		private yCUKZlfPtiIeEsniSUPGkHtQWiE AbEGtXaVjNIIHyBRbHBeNcDbafZd;

		private bool iGaqCHVEOQgpbvJMvjetJqAnxOU;

		private bool uvRIxvvRCxrfpiSXpAlvYqJtnEz;

		private readonly object mqHGztGaieMoydnLOuNWPQNgnXG;

		private WriteReportDelegate wRzXfgFSKGZnfjIbEHjacpDhXMQ;

		private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

		public HidOutputReportHandler(WriteReportDelegate writeReportDelegate)
		{
			while (true)
			{
				int num = 1518214157;
				while (true)
				{
					switch (num ^ 0x5A7E1C0F)
					{
					case 3:
						break;
					case 2:
						if (writeReportDelegate != null)
						{
							goto IL_003d;
						}
						throw new ArgumentNullException("writeReportDelegate");
					case 1:
						goto IL_003d;
					default:
						ugDapCqSwatVwHFNRCJxFJwpWF = new yCUKZlfPtiIeEsniSUPGkHtQWiE();
						AbEGtXaVjNIIHyBRbHBeNcDbafZd = new yCUKZlfPtiIeEsniSUPGkHtQWiE();
						mqHGztGaieMoydnLOuNWPQNgnXG = new object();
						return;
					}
					break;
					IL_003d:
					wRzXfgFSKGZnfjIbEHjacpDhXMQ = writeReportDelegate;
					num = 1518214159;
				}
			}
		}

		public void WriteReport(OutputReport report)
		{
			lock (mqHGztGaieMoydnLOuNWPQNgnXG)
			{
				if (QQqHByfwytAJSuMZiCPjJlZYHKG || !report.IsValid || !uQEBmSjyfRHnLAGcBmMfKMKLWzNM())
				{
					return;
				}
				lock (ugDapCqSwatVwHFNRCJxFJwpWF)
				{
					ugDapCqSwatVwHFNRCJxFJwpWF.AkTmoTRZtvtOnGarboEsTlSzABC(ref report);
				}
			}
		}

		public void Clear()
		{
			if (ugDapCqSwatVwHFNRCJxFJwpWF != null)
			{
				while (true)
				{
					int num = -791575653;
					while (true)
					{
						switch (num ^ -791575654)
						{
						case 0:
							break;
						case 1:
							if (AbEGtXaVjNIIHyBRbHBeNcDbafZd != null)
							{
								goto IL_0031;
							}
							lock (ugDapCqSwatVwHFNRCJxFJwpWF)
							{
								ugDapCqSwatVwHFNRCJxFJwpWF.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
								return;
							}
						default:
							lock (ugDapCqSwatVwHFNRCJxFJwpWF)
							{
								lock (AbEGtXaVjNIIHyBRbHBeNcDbafZd)
								{
									ugDapCqSwatVwHFNRCJxFJwpWF.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
									AbEGtXaVjNIIHyBRbHBeNcDbafZd.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
									return;
								}
							}
						}
						break;
						IL_0031:
						num = -791575656;
					}
				}
			}
			if (AbEGtXaVjNIIHyBRbHBeNcDbafZd != null)
			{
				lock (AbEGtXaVjNIIHyBRbHBeNcDbafZd)
				{
					AbEGtXaVjNIIHyBRbHBeNcDbafZd.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
				}
			}
		}

		private bool uQEBmSjyfRHnLAGcBmMfKMKLWzNM()
		{
			if (iGaqCHVEOQgpbvJMvjetJqAnxOU)
			{
				return false;
			}
			if (!ymkrTVsttbjnneijraQGWqGdeWaf())
			{
				return false;
			}
			if (uvRIxvvRCxrfpiSXpAlvYqJtnEz)
			{
				return true;
			}
			uvRIxvvRCxrfpiSXpAlvYqJtnEz = true;
			return true;
		}

		private bool ymkrTVsttbjnneijraQGWqGdeWaf()
		{
			if (iGaqCHVEOQgpbvJMvjetJqAnxOU)
			{
				return false;
			}
			if (CogoXqfgoUvretoPEYaoWIkbAAZ == null)
			{
				try
				{
					CogoXqfgoUvretoPEYaoWIkbAAZ = ThreadHelper.CreateFixedTimeStep(100, 10000);
					CogoXqfgoUvretoPEYaoWIkbAAZ.ThreadUpdateEvent += eASDrYzhBmVRwaVPOObNEmaDUuh;
					CogoXqfgoUvretoPEYaoWIkbAAZ.ThreadStartedEvent += pfozFpDZHiiBOqqinTcxKVeoblx;
					CogoXqfgoUvretoPEYaoWIkbAAZ.ThreadPreStopEvent += liqZquoBGwuiAXIjojiXcVobDlZC;
					CogoXqfgoUvretoPEYaoWIkbAAZ.Start(false);
					return true;
				}
				catch (Exception ex)
				{
					while (true)
					{
						int num = -223950439;
						while (true)
						{
							switch (num ^ -223950440)
							{
							case 0:
								break;
							case 1:
								Logger.LogError("Exception occurred while creating thread!\n" + ex, true);
								num = -223950437;
								continue;
							case 3:
								if (CogoXqfgoUvretoPEYaoWIkbAAZ != null)
								{
									CogoXqfgoUvretoPEYaoWIkbAAZ.Stop(false);
									num = -223950438;
									continue;
								}
								goto default;
							default:
								iGaqCHVEOQgpbvJMvjetJqAnxOU = true;
								return false;
							}
							break;
						}
					}
				}
			}
			if (!CogoXqfgoUvretoPEYaoWIkbAAZ.isRunning)
			{
				CogoXqfgoUvretoPEYaoWIkbAAZ.Start(false);
			}
			else
			{
				while (true)
				{
					CogoXqfgoUvretoPEYaoWIkbAAZ.ResetTimeout();
					int num2 = -223950440;
					while (true)
					{
						switch (num2 ^ -223950440)
						{
						case 2:
							num2 = -223950439;
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

		private void DqHnqQFcMCDPHHlkyNrtXvxzkApE()
		{
			lock (ugDapCqSwatVwHFNRCJxFJwpWF)
			{
				lock (AbEGtXaVjNIIHyBRbHBeNcDbafZd)
				{
					MiscTools.Swap(ref ugDapCqSwatVwHFNRCJxFJwpWF, ref AbEGtXaVjNIIHyBRbHBeNcDbafZd);
				}
			}
		}

		private void pfozFpDZHiiBOqqinTcxKVeoblx()
		{
		}

		private void liqZquoBGwuiAXIjojiXcVobDlZC()
		{
		}

		private void eASDrYzhBmVRwaVPOObNEmaDUuh()
		{
			DqHnqQFcMCDPHHlkyNrtXvxzkApE();
			lock (AbEGtXaVjNIIHyBRbHBeNcDbafZd)
			{
				if (!AbEGtXaVjNIIHyBRbHBeNcDbafZd.HasReport)
				{
					return;
				}
				try
				{
					wRzXfgFSKGZnfjIbEHjacpDhXMQ(AbEGtXaVjNIIHyBRbHBeNcDbafZd.NiMIurfbUDZBBxgRcihSmSqsVba());
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred while sending HID output report.\nMessage: " + ex.Message, true);
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~HidOutputReportHandler()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (QQqHByfwytAJSuMZiCPjJlZYHKG)
			{
				while (true)
				{
					switch (-2007190428 ^ -2007190427)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			lock (mqHGztGaieMoydnLOuNWPQNgnXG)
			{
				if (disposing)
				{
					Clear();
					if (CogoXqfgoUvretoPEYaoWIkbAAZ != null)
					{
						CogoXqfgoUvretoPEYaoWIkbAAZ.Dispose();
					}
				}
				QQqHByfwytAJSuMZiCPjJlZYHKG = true;
			}
		}
	}
}
