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

		private class NaYuAwPfxeULnGFjiTTEBsrMzrV : IDisposable
		{
			private bool UNFeNXRFKZGDsJYPeadkdsFgIwjl;

			private OutputReport aJACtMesxaypFjuTTMejAATNovB;

			private NativeBuffer HaaYbekkYkVzqIEKjXoDUBlmwQE;

			private bool vsurYtRlepcrpAzAENwjqjJEZPT;

			public bool HasReport
			{
				get
				{
					return UNFeNXRFKZGDsJYPeadkdsFgIwjl;
				}
			}

			public NaYuAwPfxeULnGFjiTTEBsrMzrV()
			{
				HaaYbekkYkVzqIEKjXoDUBlmwQE = new NativeBuffer(0);
			}

			public void tvJnFGfMznSZUwwyVmauoAQjDfN(ref OutputReport P_0)
			{
				UNFeNXRFKZGDsJYPeadkdsFgIwjl = false;
				while (true)
				{
					int num = 311370039;
					while (true)
					{
						switch (num ^ 0x128F2136)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							if (!P_0.IsValid)
							{
								return;
							}
							goto case 3;
						case 3:
							aJACtMesxaypFjuTTMejAATNovB = P_0;
							if (HaaYbekkYkVzqIEKjXoDUBlmwQE.Length < P_0.bufferLength && !HaaYbekkYkVzqIEKjXoDUBlmwQE.Resize(P_0.bufferLength, false))
							{
								goto IL_006c;
							}
							try
							{
								HaaYbekkYkVzqIEKjXoDUBlmwQE.Write(P_0.buffer, P_0.bufferLength, P_0.bufferLength);
							}
							catch
							{
								return;
							}
							aJACtMesxaypFjuTTMejAATNovB.buffer = HaaYbekkYkVzqIEKjXoDUBlmwQE.Pointer;
							while (true)
							{
								int num2 = 311370039;
								while (true)
								{
									switch (num2 ^ 0x128F2136)
									{
									case 2:
										break;
									default:
										return;
									case 1:
										aJACtMesxaypFjuTTMejAATNovB.bufferLength = HaaYbekkYkVzqIEKjXoDUBlmwQE.Length;
										num2 = 311370037;
										continue;
									case 3:
										UNFeNXRFKZGDsJYPeadkdsFgIwjl = true;
										num2 = 311370038;
										continue;
									case 0:
										return;
									}
									break;
								}
							}
						case 0:
							return;
						}
						break;
						IL_006c:
						num = 311370038;
					}
				}
			}

			public OutputReport qUGDiJVQeZgsvLEbKjCEZiNygBd()
			{
				if (!UNFeNXRFKZGDsJYPeadkdsFgIwjl)
				{
					return default(OutputReport);
				}
				UNFeNXRFKZGDsJYPeadkdsFgIwjl = false;
				return aJACtMesxaypFjuTTMejAATNovB;
			}

			public OutputReport zwOcZLhRHeTkxLfUzkfcJvPfOFwH()
			{
				OutputReport result = default(OutputReport);
				if (!UNFeNXRFKZGDsJYPeadkdsFgIwjl)
				{
					while (true)
					{
						int num = -1346564292;
						while (true)
						{
							switch (num ^ -1346564290)
							{
							case 0:
								break;
							case 2:
								goto IL_0026;
							default:
								return result;
							}
							break;
							IL_0026:
							result = default(OutputReport);
							num = -1346564289;
						}
					}
				}
				return aJACtMesxaypFjuTTMejAATNovB;
			}

			public void nympziBLtYDUiPlWNRoEGqbSPfa()
			{
				aJACtMesxaypFjuTTMejAATNovB.Clear();
				UNFeNXRFKZGDsJYPeadkdsFgIwjl = false;
			}

			public void Dispose()
			{
				DJeUzQoMEVOxbEpwDFXbTBWdIKu(true);
				GC.SuppressFinalize(this);
			}

			~NaYuAwPfxeULnGFjiTTEBsrMzrV()
			{
				DJeUzQoMEVOxbEpwDFXbTBWdIKu(false);
			}

			protected virtual void DJeUzQoMEVOxbEpwDFXbTBWdIKu(bool P_0)
			{
				if (vsurYtRlepcrpAzAENwjqjJEZPT)
				{
					goto IL_0008;
				}
				goto IL_0036;
				IL_0008:
				int num = -826633800;
				goto IL_000d;
				IL_000d:
				switch (num ^ -826633797)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					return;
				case 0:
					goto IL_0036;
				case 4:
					goto IL_0053;
				case 1:
					return;
				}
				goto IL_0008;
				IL_0036:
				if (P_0 && HaaYbekkYkVzqIEKjXoDUBlmwQE != null)
				{
					HaaYbekkYkVzqIEKjXoDUBlmwQE.Dispose();
					num = -826633793;
					goto IL_000d;
				}
				goto IL_0053;
				IL_0053:
				vsurYtRlepcrpAzAENwjqjJEZPT = true;
				num = -826633798;
				goto IL_000d;
			}
		}

		private const bool rvpkJuIMzsDpafsiSsjvCJeHtkKS = false;

		private const int YezsvYCsJIsisicEzWVdiQbkFcP = 100;

		private const int yEyTPPoSdBDulfovZXNMnMhoKLJ = 10000;

		private ThreadHelper xgExdbVyAKUPeHviEQuSfAnlZIs;

		private NaYuAwPfxeULnGFjiTTEBsrMzrV HaaYbekkYkVzqIEKjXoDUBlmwQE;

		private NaYuAwPfxeULnGFjiTTEBsrMzrV rMMzoOrRlHrtgdYSRDWaPjPtcVE;

		private bool ZtgCzKdfGSWUWDTDXtkdTKMjYBN;

		private bool PkVqugVNIpoYIMpSDcpjdJRrnVs;

		private readonly object FPRLwoiTwwPULTEIijRGmjFenYV;

		private WriteReportDelegate HpfELifjYWmsKHMXiJXmZvdfSJX;

		private bool vsurYtRlepcrpAzAENwjqjJEZPT;

		public HidOutputReportHandler(WriteReportDelegate writeReportDelegate)
		{
			if (writeReportDelegate == null)
			{
				throw new ArgumentNullException("writeReportDelegate");
			}
			HpfELifjYWmsKHMXiJXmZvdfSJX = writeReportDelegate;
			HaaYbekkYkVzqIEKjXoDUBlmwQE = new NaYuAwPfxeULnGFjiTTEBsrMzrV();
			rMMzoOrRlHrtgdYSRDWaPjPtcVE = new NaYuAwPfxeULnGFjiTTEBsrMzrV();
			FPRLwoiTwwPULTEIijRGmjFenYV = new object();
		}

		public void WriteReport(OutputReport report)
		{
			lock (FPRLwoiTwwPULTEIijRGmjFenYV)
			{
				if (vsurYtRlepcrpAzAENwjqjJEZPT)
				{
					while (true)
					{
						switch (0x34A6C40C ^ 0x34A6C40D)
						{
						case 0:
							break;
						case 1:
							return;
						case 3:
							goto end_IL_0015;
						case 4:
							goto IL_0056;
						default:
							goto IL_0067;
						}
						continue;
						end_IL_0015:
						break;
					}
				}
				if (!report.IsValid)
				{
					return;
				}
				goto IL_0056;
				IL_0067:
				lock (HaaYbekkYkVzqIEKjXoDUBlmwQE)
				{
					HaaYbekkYkVzqIEKjXoDUBlmwQE.tvJnFGfMznSZUwwyVmauoAQjDfN(ref report);
					return;
				}
				IL_0056:
				if (!PQSWvFQilTgIeaqvfFMnhhGbNgSO())
				{
					return;
				}
				goto IL_0067;
			}
		}

		public void Clear()
		{
			if (HaaYbekkYkVzqIEKjXoDUBlmwQE != null)
			{
				if (rMMzoOrRlHrtgdYSRDWaPjPtcVE != null)
				{
					lock (HaaYbekkYkVzqIEKjXoDUBlmwQE)
					{
						lock (rMMzoOrRlHrtgdYSRDWaPjPtcVE)
						{
							HaaYbekkYkVzqIEKjXoDUBlmwQE.nympziBLtYDUiPlWNRoEGqbSPfa();
							rMMzoOrRlHrtgdYSRDWaPjPtcVE.nympziBLtYDUiPlWNRoEGqbSPfa();
							return;
						}
					}
				}
				lock (HaaYbekkYkVzqIEKjXoDUBlmwQE)
				{
					HaaYbekkYkVzqIEKjXoDUBlmwQE.nympziBLtYDUiPlWNRoEGqbSPfa();
					return;
				}
			}
			if (rMMzoOrRlHrtgdYSRDWaPjPtcVE != null)
			{
				lock (rMMzoOrRlHrtgdYSRDWaPjPtcVE)
				{
					rMMzoOrRlHrtgdYSRDWaPjPtcVE.nympziBLtYDUiPlWNRoEGqbSPfa();
				}
			}
		}

		private bool PQSWvFQilTgIeaqvfFMnhhGbNgSO()
		{
			if (ZtgCzKdfGSWUWDTDXtkdTKMjYBN)
			{
				return false;
			}
			if (!XwuqsUGexhhAYMAeLaSYinCpSZhc())
			{
				return false;
			}
			if (PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				return true;
			}
			PkVqugVNIpoYIMpSDcpjdJRrnVs = true;
			return true;
		}

		private bool XwuqsUGexhhAYMAeLaSYinCpSZhc()
		{
			if (ZtgCzKdfGSWUWDTDXtkdTKMjYBN)
			{
				return false;
			}
			if (xgExdbVyAKUPeHviEQuSfAnlZIs == null)
			{
				bool result = default(bool);
				try
				{
					xgExdbVyAKUPeHviEQuSfAnlZIs = ThreadHelper.CreateFixedTimeStep(100, 10000);
					xgExdbVyAKUPeHviEQuSfAnlZIs.ThreadUpdateEvent += NdOsURLOPikvHKCYeQXLzgkLJhk;
					while (true)
					{
						IL_003e:
						int num = -1192967291;
						while (true)
						{
							switch (num ^ -1192967292)
							{
							case 0:
								break;
							default:
								goto end_IL_0043;
							case 1:
								xgExdbVyAKUPeHviEQuSfAnlZIs.ThreadStartedEvent += WBajIqbpPkOmbCKzBcstzzysZcu;
								num = -1192967289;
								continue;
							case 3:
								xgExdbVyAKUPeHviEQuSfAnlZIs.ThreadPreStopEvent += QdwUptIfUkqFhpjwEdePVvwzdyAe;
								xgExdbVyAKUPeHviEQuSfAnlZIs.Start(false);
								num = -1192967290;
								continue;
							case 2:
								result = true;
								num = -1192967296;
								continue;
							case 4:
								goto end_IL_0043;
							}
							goto IL_003e;
							continue;
							end_IL_0043:
							break;
						}
						break;
					}
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while creating thread!\n" + ex, true);
					while (true)
					{
						IL_00cd:
						int num2 = -1192967289;
						while (true)
						{
							switch (num2 ^ -1192967292)
							{
							case 0:
								break;
							case 3:
								if (xgExdbVyAKUPeHviEQuSfAnlZIs != null)
								{
									xgExdbVyAKUPeHviEQuSfAnlZIs.Stop(false);
									num2 = -1192967291;
									continue;
								}
								goto case 1;
							case 1:
								ZtgCzKdfGSWUWDTDXtkdTKMjYBN = true;
								num2 = -1192967290;
								continue;
							default:
								result = false;
								goto end_IL_00d2;
							}
							goto IL_00cd;
							continue;
							end_IL_00d2:
							break;
						}
						break;
					}
				}
				return result;
			}
			if (!xgExdbVyAKUPeHviEQuSfAnlZIs.isRunning)
			{
				xgExdbVyAKUPeHviEQuSfAnlZIs.Start(false);
				goto IL_0136;
			}
			goto IL_015f;
			IL_013b:
			int num3;
			while (true)
			{
				switch (num3 ^ -1192967292)
				{
				case 0:
					break;
				case 3:
					num3 = -1192967290;
					continue;
				case 1:
					goto IL_015f;
				default:
					return true;
				}
				break;
			}
			goto IL_0136;
			IL_0136:
			num3 = -1192967289;
			goto IL_013b;
			IL_015f:
			xgExdbVyAKUPeHviEQuSfAnlZIs.ResetTimeout();
			num3 = -1192967290;
			goto IL_013b;
		}

		private void eqVixTjbGGFqkKFjUuzzIVfvFRod()
		{
			lock (HaaYbekkYkVzqIEKjXoDUBlmwQE)
			{
				lock (rMMzoOrRlHrtgdYSRDWaPjPtcVE)
				{
					MiscTools.Swap(ref HaaYbekkYkVzqIEKjXoDUBlmwQE, ref rMMzoOrRlHrtgdYSRDWaPjPtcVE);
				}
			}
		}

		private void WBajIqbpPkOmbCKzBcstzzysZcu()
		{
		}

		private void QdwUptIfUkqFhpjwEdePVvwzdyAe()
		{
		}

		private void NdOsURLOPikvHKCYeQXLzgkLJhk()
		{
			eqVixTjbGGFqkKFjUuzzIVfvFRod();
			lock (rMMzoOrRlHrtgdYSRDWaPjPtcVE)
			{
				if (!rMMzoOrRlHrtgdYSRDWaPjPtcVE.HasReport)
				{
					return;
				}
				try
				{
					HpfELifjYWmsKHMXiJXmZvdfSJX(rMMzoOrRlHrtgdYSRDWaPjPtcVE.qUGDiJVQeZgsvLEbKjCEZiNygBd());
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
			if (vsurYtRlepcrpAzAENwjqjJEZPT)
			{
				while (true)
				{
					switch (-235171028 ^ -235171026)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			lock (FPRLwoiTwwPULTEIijRGmjFenYV)
			{
				if (disposing)
				{
					Clear();
					while (true)
					{
						int num = -235171028;
						while (true)
						{
							switch (num ^ -235171026)
							{
							case 0:
								break;
							case 2:
								if (xgExdbVyAKUPeHviEQuSfAnlZIs != null)
								{
									xgExdbVyAKUPeHviEQuSfAnlZIs.Dispose();
									num = -235171025;
									continue;
								}
								goto end_IL_0044;
							default:
								goto end_IL_0044;
							}
							break;
						}
						continue;
						end_IL_0044:
						break;
					}
				}
				vsurYtRlepcrpAzAENwjqjJEZPT = true;
			}
		}
	}
}
