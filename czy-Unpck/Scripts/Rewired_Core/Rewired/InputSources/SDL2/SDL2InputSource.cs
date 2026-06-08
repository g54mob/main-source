using System;
using System.Collections.Generic;
using System.Threading;
using Rewired.Config;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.InputSources.SDL2
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class SDL2InputSource : IDisposable, IInputSource
	{
		public delegate void aDrEOjIQpHjPYFBrNPHyipDKdUve(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void JCtdScWiPAAhWvVreniSGmVeEWP(int joystickIndex);

		public delegate void XGTcYrfQqNgGhusdpGrIUOpPIRvT(int joystickId);

		public delegate void rMwALjEzMyWWWNnomBOPMLTwFBz(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int hUwaEflpYjkzJbRYqJJrZeFsOld = 32;

		private bool pdMGqWoOXsknpEqFelIOnbtitYp;

		private bool yBQDRAFyzcChNxPYLhAMxAGRtfiD;

		private bool FPIFkeEGKbvpYzaMGAMgxkAoecg;

		private bool ovHxuPBnGuWLwvuhGjMIvvWhjBm;

		private bool PwPWygBTznyByBIyaAyqEfnsXBM;

		private ADictionary<int, mtPUEYnrqUFuxNtWHmDOApiJouJ> KjXmBSVldpfwjiNaozEQFsyjEtD;

		private ADictionary<int, WgHPWmXvZjeOxhHTekxmohMTAMr> qYjfpOFjFAdamjqFeUBvEsuhpKSa;

		private RlJPuDpfhAyzcNeaFBQNBYkzwNAS.RQTfINuDpVENprFCjdVWdGApYHTe JeeDedYOXXeUkcTqvwbxtDUdgET;

		private NativeBuffer gBmqzMSFplcvDWEjFNkPVRiXmat;

		private Action gQBxsIJyfDheztEWqkgPpspxufJ;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public bool initialized => PwPWygBTznyByBIyaAyqEfnsXBM;

		private event Action _DeviceChangedEvent
		{
			add
			{
				Action action = gQBxsIJyfDheztEWqkgPpspxufJ;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref gQBxsIJyfDheztEWqkgPpspxufJ, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = gQBxsIJyfDheztEWqkgPpspxufJ;
				Action action2 = default(Action);
				Action value2 = default(Action);
				while (true)
				{
					int num = -685020583;
					while (true)
					{
						switch (num ^ -685020584)
						{
						case 2:
							break;
						case 1:
							action2 = action;
							num = -685020581;
							continue;
						case 3:
							value2 = (Action)Delegate.Remove(action2, value);
							num = -685020584;
							continue;
						default:
							action = Interlocked.CompareExchange(ref gQBxsIJyfDheztEWqkgPpspxufJ, value2, action2);
							if ((object)action == action2)
							{
								return;
							}
							goto case 1;
						}
						break;
					}
				}
			}
		}

		public event Action DeviceChangedEvent
		{
			add
			{
				_DeviceChangedEvent += value;
			}
			remove
			{
				_DeviceChangedEvent -= value;
			}
		}

		public SDL2InputSource(UpdateLoopSetting updateLoop, bool handleJoysticks, bool handleGamepads, bool handleUnifiedMouse, bool handleUnifiedKeyboard)
		{
			pdMGqWoOXsknpEqFelIOnbtitYp = handleJoysticks;
			yBQDRAFyzcChNxPYLhAMxAGRtfiD = handleGamepads;
			FPIFkeEGKbvpYzaMGAMgxkAoecg = handleUnifiedMouse;
			ovHxuPBnGuWLwvuhGjMIvvWhjBm = handleUnifiedKeyboard;
			KjXmBSVldpfwjiNaozEQFsyjEtD = new ADictionary<int, mtPUEYnrqUFuxNtWHmDOApiJouJ>();
			qYjfpOFjFAdamjqFeUBvEsuhpKSa = new ADictionary<int, WgHPWmXvZjeOxhHTekxmohMTAMr>();
			int num = ((!UnityTools.isEditor || UnityTools.editorPlatform != EditorPlatform.OSX) ? 29184 : 25088);
			try
			{
				RlJPuDpfhAyzcNeaFBQNBYkzwNAS.cHDcXeXEqWiwCmelxPqkjtzWkXe(UnityTools.effectivePlatform);
				if (RlJPuDpfhAyzcNeaFBQNBYkzwNAS.eCHRtVGybaQsquXmFRmlfxYjGMr((uint)num) < 0)
				{
					throw new Exception("Failed initialize SDL2!");
				}
				PwPWygBTznyByBIyaAyqEfnsXBM = true;
				if (handleGamepads)
				{
					UrJqTbTWAPLwPMwXLGwRwWeUEuF();
				}
				KwyBlrGvlhbdjBILIAYjPUMdJsgM();
				gBmqzMSFplcvDWEjFNkPVRiXmat = new NativeBuffer(56);
			}
			catch
			{
				PwPWygBTznyByBIyaAyqEfnsXBM = false;
				Dispose();
				throw;
			}
		}

		public void SystemDeviceConnected()
		{
			throw new NotImplementedException();
		}

		public void SystemDeviceDisconnected()
		{
			throw new NotImplementedException();
		}

		public void Update()
		{
			_ = PwPWygBTznyByBIyaAyqEfnsXBM;
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			if (PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				BmTDdgCUFwRIIIXTBGCTUMboaeik();
			}
		}

		public void UpdateFinished()
		{
			_ = PwPWygBTznyByBIyaAyqEfnsXBM;
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			if (!PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				goto IL_0008;
			}
			List<pErdarFuDrLltFruMSsYCDRyarSk> list = new List<pErdarFuDrLltFruMSsYCDRyarSk>();
			int num;
			if (pdMGqWoOXsknpEqFelIOnbtitYp)
			{
				num = -1560970483;
				goto IL_000d;
			}
			goto IL_00c7;
			IL_00c7:
			if (yBQDRAFyzcChNxPYLhAMxAGRtfiD)
			{
				using (ADictionary<int, WgHPWmXvZjeOxhHTekxmohMTAMr>.Enumerator enumerator = qYjfpOFjFAdamjqFeUBvEsuhpKSa.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							KeyValuePair<int, WgHPWmXvZjeOxhHTekxmohMTAMr> current = enumerator.Current;
							int num2 = -1560970483;
							while (true)
							{
								switch (num2 ^ -1560970483)
								{
								case 2:
									num2 = -1560970482;
									continue;
								case 3:
									break;
								case 0:
								{
									WgHPWmXvZjeOxhHTekxmohMTAMr value = current.Value;
									if (value.IsValid)
									{
										list.Add(value);
										num2 = -1560970484;
										continue;
									}
									goto end_IL_0100;
								}
								default:
									goto end_IL_0100;
								}
								break;
							}
							continue;
							end_IL_0100:
							break;
						}
					}
				}
			}
			return list as IList<T>;
			IL_0040:
			using (ADictionary<int, mtPUEYnrqUFuxNtWHmDOApiJouJ>.Enumerator enumerator2 = KjXmBSVldpfwjiNaozEQFsyjEtD.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					while (true)
					{
						KeyValuePair<int, mtPUEYnrqUFuxNtWHmDOApiJouJ> current2 = enumerator2.Current;
						mtPUEYnrqUFuxNtWHmDOApiJouJ value2 = current2.Value;
						int num3;
						int num4;
						if (!value2.IsValid)
						{
							num3 = -1560970481;
							num4 = num3;
						}
						else
						{
							num3 = -1560970482;
							num4 = num3;
						}
						while (true)
						{
							switch (num3 ^ -1560970483)
							{
							case 0:
								num3 = -1560970484;
								continue;
							case 1:
								break;
							case 3:
								list.Add(current2.Value);
								num3 = -1560970481;
								continue;
							default:
								goto end_IL_0071;
							}
							break;
						}
						continue;
						end_IL_0071:
						break;
					}
				}
			}
			goto IL_00c7;
			IL_0008:
			num = -1560970484;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1560970483)
			{
			case 2:
				break;
			case 1:
				return null;
			default:
				goto IL_0040;
			}
			goto IL_0008;
		}

		private int mdMHtbCWSQBGIHEsYlxIDlLAYuhm()
		{
			if (!PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				return 0;
			}
			return Math.Min(RlJPuDpfhAyzcNeaFBQNBYkzwNAS.AbkKiPDSxOEOachGoVloiQpfpqB(), 32);
		}

		private int ocbqHGtptEixAZeqZCpfxlgkMuS()
		{
			if (!PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				return 0;
			}
			int num = mdMHtbCWSQBGIHEsYlxIDlLAYuhm();
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num2 = 362084225;
				while (true)
				{
					switch (num2 ^ 0x1594F780)
					{
					case 2:
						break;
					case 4:
						num4++;
						num2 = 362084230;
						continue;
					case 3:
						num2 = 362084224;
						continue;
					case 5:
					{
						int num5;
						if (!RlJPuDpfhAyzcNeaFBQNBYkzwNAS.rjxJPmzoaQGuoZiVnzLZQNLoKec(num3))
						{
							num2 = 362084228;
							num5 = num2;
						}
						else
						{
							num2 = 362084230;
							num5 = num2;
						}
						continue;
					}
					case 1:
						num4 = 0;
						num3 = 0;
						num2 = 362084227;
						continue;
					case 6:
						num3++;
						num2 = 362084224;
						continue;
					default:
						if (num3 >= num)
						{
							return num4;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		private mtPUEYnrqUFuxNtWHmDOApiJouJ NcGAMecnGLZbHGsyzoWDIxAndNx(int P_0)
		{
			IntPtr intPtr = RlJPuDpfhAyzcNeaFBQNBYkzwNAS.UPjtLwvklHKoytKPntqSNjfclb(P_0);
			while (true)
			{
				int num = 669564088;
				while (true)
				{
					switch (num ^ 0x27E8BCBA)
					{
					case 0:
						break;
					case 2:
					{
						if (intPtr == IntPtr.Zero)
						{
							goto IL_0032;
						}
						tsYaeJHPqrgHucWqidFogCgNPrkI tsYaeJHPqrgHucWqidFogCgNPrkI2 = new tsYaeJHPqrgHucWqidFogCgNPrkI(intPtr);
						PGcImbCrfaDBqNKhXzQpJjoCymX pGcImbCrfaDBqNKhXzQpJjoCymX = KRUNDNcNpZtCvwCRBwACKHUpefE(P_0, tsYaeJHPqrgHucWqidFogCgNPrkI2);
						if (pGcImbCrfaDBqNKhXzQpJjoCymX == null)
						{
							RlJPuDpfhAyzcNeaFBQNBYkzwNAS.LcvXldjOVqLzESRkvGOJOLKxIYo(intPtr);
							return null;
						}
						return new mtPUEYnrqUFuxNtWHmDOApiJouJ(tsYaeJHPqrgHucWqidFogCgNPrkI2, pGcImbCrfaDBqNKhXzQpJjoCymX);
					}
					default:
						return null;
					}
					break;
					IL_0032:
					num = 669564091;
				}
			}
		}

		private WgHPWmXvZjeOxhHTekxmohMTAMr vHlIoMqShUoTWYaUitSpkJofMEa(int P_0)
		{
			IntPtr intPtr = RlJPuDpfhAyzcNeaFBQNBYkzwNAS.RyvmBpdcWKFpZCrcAnOxGTcdKLLG(P_0);
			if (intPtr == IntPtr.Zero)
			{
				goto IL_0014;
			}
			gHzUXqJUMjOrYbNcIGgCGRspwkrv gHzUXqJUMjOrYbNcIGgCGRspwkrv2 = new gHzUXqJUMjOrYbNcIGgCGRspwkrv(intPtr);
			PGcImbCrfaDBqNKhXzQpJjoCymX pGcImbCrfaDBqNKhXzQpJjoCymX = CcxwftsiefWmMZcQwhTJXlyLYCw(P_0, gHzUXqJUMjOrYbNcIGgCGRspwkrv2);
			if (pGcImbCrfaDBqNKhXzQpJjoCymX == null)
			{
				return null;
			}
			int num;
			if (!pGcImbCrfaDBqNKhXzQpJjoCymX.vjfcfVekatByYfabImutjCaCGFDE)
			{
				RlJPuDpfhAyzcNeaFBQNBYkzwNAS.FEHdCvBSLJDNmRYTjTJJTTFUCxuf(intPtr);
				num = 1887355910;
				goto IL_0019;
			}
			pGcImbCrfaDBqNKhXzQpJjoCymX.IifBwgifDjJLQbtRWmfjwrERSUof = RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bPgQUUodGENyMkRbLVQnqedZKSS(gHzUXqJUMjOrYbNcIGgCGRspwkrv2);
			return new WgHPWmXvZjeOxhHTekxmohMTAMr(gHzUXqJUMjOrYbNcIGgCGRspwkrv2, pGcImbCrfaDBqNKhXzQpJjoCymX);
			IL_0019:
			switch (num ^ 0x707EC407)
			{
			case 0:
				break;
			case 2:
				return null;
			default:
				return null;
			}
			goto IL_0014;
			IL_0014:
			num = 1887355909;
			goto IL_0019;
		}

		private PGcImbCrfaDBqNKhXzQpJjoCymX KRUNDNcNpZtCvwCRBwACKHUpefE(int P_0, tsYaeJHPqrgHucWqidFogCgNPrkI P_1)
		{
			if (!PwPWygBTznyByBIyaAyqEfnsXBM)
			{
				return null;
			}
			int num;
			if (P_0 >= 0)
			{
				if (P_0 >= 32)
				{
					goto IL_0013;
				}
				int num2;
				if (P_1 != null)
				{
					num = -1796875302;
					num2 = num;
				}
				else
				{
					num = -1796875310;
					num2 = num;
				}
				goto IL_0018;
			}
			goto IL_0050;
			IL_0050:
			return null;
			IL_0013:
			num = -1796875309;
			goto IL_0018;
			IL_0018:
			PGcImbCrfaDBqNKhXzQpJjoCymX pGcImbCrfaDBqNKhXzQpJjoCymX = default(PGcImbCrfaDBqNKhXzQpJjoCymX);
			while (true)
			{
				switch (num ^ -1796875302)
				{
				case 2:
					break;
				case 9:
					goto IL_0050;
				case 1:
					pGcImbCrfaDBqNKhXzQpJjoCymX.oMdPLczizGTfYtbKPSSTJqAghXO = RlJPuDpfhAyzcNeaFBQNBYkzwNAS.CAaCcropkmhwSeXYUjjuMTOTnrm(P_1);
					num = -1796875303;
					continue;
				case 7:
					pGcImbCrfaDBqNKhXzQpJjoCymX.vjfcfVekatByYfabImutjCaCGFDE = RlJPuDpfhAyzcNeaFBQNBYkzwNAS.rjxJPmzoaQGuoZiVnzLZQNLoKec(P_0);
					pGcImbCrfaDBqNKhXzQpJjoCymX.uAdfutJYLhLaQtlGxLCJUCCaAuu = RlJPuDpfhAyzcNeaFBQNBYkzwNAS.kKHMHEeNEBovGcioKcwoyemeXag(P_1);
					num = -1796875301;
					continue;
				case 3:
					pGcImbCrfaDBqNKhXzQpJjoCymX.oHbIEDhOyMIiZACBlWVWpEnWmcq = RlJPuDpfhAyzcNeaFBQNBYkzwNAS.QphbSmYNdjdEIybHnVvfJhkowav(P_0);
					pGcImbCrfaDBqNKhXzQpJjoCymX.SeOhWaCQLSUYyhdokorrnPTrNGB = RlJPuDpfhAyzcNeaFBQNBYkzwNAS.yynlLElNDaehyflshOSLySRxdNeC(P_1);
					num = -1796875297;
					continue;
				case 0:
					goto IL_00cc;
				case 8:
					return null;
				case 6:
					pGcImbCrfaDBqNKhXzQpJjoCymX.agVDxkfWemHjQJaQAZaeOwvrWKHc = P_0;
					pGcImbCrfaDBqNKhXzQpJjoCymX.SdzTDIiDEmDeIhvMroJwWIHvnit = RlJPuDpfhAyzcNeaFBQNBYkzwNAS.qMquKrxkuYdAWoEyaFAGdXrBjAx(P_1);
					num = -1796875299;
					continue;
				case 5:
					pGcImbCrfaDBqNKhXzQpJjoCymX.RGhWgMAfPjfICjXGWTZxnPoNdWD = RlJPuDpfhAyzcNeaFBQNBYkzwNAS.KdzOHCvAeBceATeOTGVItlfeRAx(P_1);
					num = -1796875298;
					continue;
				default:
					pGcImbCrfaDBqNKhXzQpJjoCymX.ugqqWfYBExHDZxWuxQgGapMNCCx = RlJPuDpfhAyzcNeaFBQNBYkzwNAS.YhjHsQVrushtlCqdoiWzYDGuKva(P_1);
					pGcImbCrfaDBqNKhXzQpJjoCymX.wFXkhUcSxbniabfCluhOAikybNB = RlJPuDpfhAyzcNeaFBQNBYkzwNAS.ypMhAMPcMetHwzySWdTJVlPScFpf(P_1);
					return pGcImbCrfaDBqNKhXzQpJjoCymX;
				}
				break;
				IL_00cc:
				if (!P_1.IsValid)
				{
					num = -1796875310;
					continue;
				}
				pGcImbCrfaDBqNKhXzQpJjoCymX = new PGcImbCrfaDBqNKhXzQpJjoCymX();
				num = -1796875300;
			}
			goto IL_0013;
		}

		private PGcImbCrfaDBqNKhXzQpJjoCymX CcxwftsiefWmMZcQwhTJXlyLYCw(int P_0, gHzUXqJUMjOrYbNcIGgCGRspwkrv P_1)
		{
			if (P_1 != null)
			{
				tsYaeJHPqrgHucWqidFogCgNPrkI tsYaeJHPqrgHucWqidFogCgNPrkI2 = default(tsYaeJHPqrgHucWqidFogCgNPrkI);
				while (true)
				{
					int num = 92471309;
					while (true)
					{
						switch (num ^ 0x583000F)
						{
						case 3:
							break;
						case 2:
							goto IL_0025;
						case 1:
							goto end_IL_0003;
						default:
							goto IL_004e;
						}
						break;
						IL_0025:
						if (!P_1.IsValid)
						{
							num = 92471310;
							continue;
						}
						tsYaeJHPqrgHucWqidFogCgNPrkI2 = new tsYaeJHPqrgHucWqidFogCgNPrkI(RlJPuDpfhAyzcNeaFBQNBYkzwNAS.JiUgyNFHvZQKYdPdlaeYQRYprcAJ(P_1));
						num = 92471311;
					}
					continue;
					IL_004e:
					if (!tsYaeJHPqrgHucWqidFogCgNPrkI2.IsValid)
					{
						return null;
					}
					return KRUNDNcNpZtCvwCRBwACKHUpefE(P_0, tsYaeJHPqrgHucWqidFogCgNPrkI2);
					continue;
					end_IL_0003:
					break;
				}
			}
			return null;
		}

		private void KwyBlrGvlhbdjBILIAYjPUMdJsgM()
		{
			int num = 0;
			while (true)
			{
				int num2 = -802327079;
				while (true)
				{
					switch (num2 ^ -802327077)
					{
					case 6:
						break;
					case 0:
						HTKzJtWKDmkqZbNAPiKgDorFSCpp(num);
						num2 = -802327080;
						continue;
					case 1:
					{
						int num3;
						if (!pdMGqWoOXsknpEqFelIOnbtitYp)
						{
							num2 = -802327080;
							num3 = num2;
						}
						else
						{
							num2 = -802327077;
							num3 = num2;
						}
						continue;
					}
					case 3:
						if (yBQDRAFyzcChNxPYLhAMxAGRtfiD)
						{
							JRWGGdHFlGAhJANVFrfzUrNBnbyt(num);
							num2 = -802327074;
							continue;
						}
						goto case 5;
					case 2:
						num2 = -802327073;
						continue;
					case 5:
						num++;
						num2 = -802327073;
						continue;
					default:
						if (num >= mdMHtbCWSQBGIHEsYlxIDlLAYuhm())
						{
							return;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		private void aMlUiYbNJVldBMbzeMMezPoAItT()
		{
			if (yBQDRAFyzcChNxPYLhAMxAGRtfiD)
			{
				using (ADictionary<int, WgHPWmXvZjeOxhHTekxmohMTAMr>.Enumerator enumerator = qYjfpOFjFAdamjqFeUBvEsuhpKSa.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							WgHPWmXvZjeOxhHTekxmohMTAMr value = enumerator.Current.Value;
							value.zXkRFYvWKmYRnRyzULGdKkAtMGz();
							value.Dispose();
							int num = -584216610;
							while (true)
							{
								switch (num ^ -584216609)
								{
								case 0:
									num = -584216611;
									continue;
								case 2:
									break;
								default:
									goto end_IL_0035;
								}
								break;
							}
							continue;
							end_IL_0035:
							break;
						}
					}
				}
				qYjfpOFjFAdamjqFeUBvEsuhpKSa.Clear();
			}
			if (!pdMGqWoOXsknpEqFelIOnbtitYp)
			{
				return;
			}
			using (ADictionary<int, mtPUEYnrqUFuxNtWHmDOApiJouJ>.Enumerator enumerator2 = KjXmBSVldpfwjiNaozEQFsyjEtD.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					while (true)
					{
						mtPUEYnrqUFuxNtWHmDOApiJouJ value2 = enumerator2.Current.Value;
						int num2 = -584216613;
						while (true)
						{
							switch (num2 ^ -584216609)
							{
							case 0:
								num2 = -584216612;
								continue;
							case 3:
								break;
							case 2:
								value2.Dispose();
								num2 = -584216610;
								continue;
							case 4:
								value2.zXkRFYvWKmYRnRyzULGdKkAtMGz();
								num2 = -584216611;
								continue;
							default:
								goto end_IL_00bc;
							}
							break;
						}
						continue;
						end_IL_00bc:
						break;
					}
				}
			}
			KjXmBSVldpfwjiNaozEQFsyjEtD.Clear();
		}

		private bool HTKzJtWKDmkqZbNAPiKgDorFSCpp(int P_0)
		{
			mtPUEYnrqUFuxNtWHmDOApiJouJ mtPUEYnrqUFuxNtWHmDOApiJouJ2 = default(mtPUEYnrqUFuxNtWHmDOApiJouJ);
			int num;
			if (P_0 >= 0)
			{
				if (P_0 >= 32)
				{
					goto IL_0009;
				}
				if (yBQDRAFyzcChNxPYLhAMxAGRtfiD && RlJPuDpfhAyzcNeaFBQNBYkzwNAS.rjxJPmzoaQGuoZiVnzLZQNLoKec(P_0))
				{
					return false;
				}
				mtPUEYnrqUFuxNtWHmDOApiJouJ2 = NcGAMecnGLZbHGsyzoWDIxAndNx(P_0);
				num = 2034257814;
				goto IL_000e;
			}
			goto IL_0082;
			IL_0009:
			num = 2034257815;
			goto IL_000e;
			IL_0082:
			return false;
			IL_000e:
			int pRWgMlsJkOezTiVjiIDwjjnINBJ = default(int);
			while (true)
			{
				switch (num ^ 0x79404F96)
				{
				case 4:
					break;
				case 2:
					goto IL_002f;
				case 0:
					goto IL_0043;
				case 1:
					goto IL_0082;
				default:
					mtPUEYnrqUFuxNtWHmDOApiJouJ2.SdmfoteCDVoXNaSlWEvRMBbwmDy();
					return true;
				}
				break;
				IL_0043:
				if (mtPUEYnrqUFuxNtWHmDOApiJouJ2 == null)
				{
					return false;
				}
				pRWgMlsJkOezTiVjiIDwjjnINBJ = mtPUEYnrqUFuxNtWHmDOApiJouJ2.PRWgMlsJkOezTiVjiIDwjjnINBJ;
				if (KjXmBSVldpfwjiNaozEQFsyjEtD.ContainsKey(pRWgMlsJkOezTiVjiIDwjjnINBJ))
				{
					KjXmBSVldpfwjiNaozEQFsyjEtD[pRWgMlsJkOezTiVjiIDwjjnINBJ].zXkRFYvWKmYRnRyzULGdKkAtMGz();
					KjXmBSVldpfwjiNaozEQFsyjEtD[pRWgMlsJkOezTiVjiIDwjjnINBJ] = mtPUEYnrqUFuxNtWHmDOApiJouJ2;
					num = 2034257813;
					continue;
				}
				goto IL_002f;
				IL_002f:
				KjXmBSVldpfwjiNaozEQFsyjEtD.Add(pRWgMlsJkOezTiVjiIDwjjnINBJ, mtPUEYnrqUFuxNtWHmDOApiJouJ2);
				num = 2034257813;
			}
			goto IL_0009;
		}

		private void bkhdMfmQPHfhCGcFctvlbKVAspb(int P_0)
		{
			if (!KjXmBSVldpfwjiNaozEQFsyjEtD.ContainsKey(P_0))
			{
				return;
			}
			while (true)
			{
				KjXmBSVldpfwjiNaozEQFsyjEtD[P_0].zXkRFYvWKmYRnRyzULGdKkAtMGz();
				int num = -1604225318;
				while (true)
				{
					switch (num ^ -1604225317)
					{
					case 0:
						goto IL_000f;
					case 2:
						break;
					default:
						KjXmBSVldpfwjiNaozEQFsyjEtD.Remove(P_0);
						return;
					}
					break;
					IL_000f:
					num = -1604225319;
				}
			}
		}

		private bool JRWGGdHFlGAhJANVFrfzUrNBnbyt(int P_0)
		{
			int num;
			WgHPWmXvZjeOxhHTekxmohMTAMr wgHPWmXvZjeOxhHTekxmohMTAMr = default(WgHPWmXvZjeOxhHTekxmohMTAMr);
			if (P_0 >= 0)
			{
				if (P_0 >= 32)
				{
					goto IL_0009;
				}
				if (!RlJPuDpfhAyzcNeaFBQNBYkzwNAS.rjxJPmzoaQGuoZiVnzLZQNLoKec(P_0))
				{
					num = 1939403644;
				}
				else
				{
					wgHPWmXvZjeOxhHTekxmohMTAMr = vHlIoMqShUoTWYaUitSpkJofMEa(P_0);
					num = 1939403641;
				}
				goto IL_000e;
			}
			goto IL_003a;
			IL_000e:
			int pRWgMlsJkOezTiVjiIDwjjnINBJ = default(int);
			while (true)
			{
				switch (num ^ 0x7398F378)
				{
				case 5:
					break;
				case 6:
					goto IL_003a;
				case 0:
					qYjfpOFjFAdamjqFeUBvEsuhpKSa.Add(pRWgMlsJkOezTiVjiIDwjjnINBJ, wgHPWmXvZjeOxhHTekxmohMTAMr);
					num = 1939403642;
					continue;
				case 4:
					return false;
				case 1:
					goto IL_0070;
				case 3:
					qYjfpOFjFAdamjqFeUBvEsuhpKSa[pRWgMlsJkOezTiVjiIDwjjnINBJ].zXkRFYvWKmYRnRyzULGdKkAtMGz();
					qYjfpOFjFAdamjqFeUBvEsuhpKSa[pRWgMlsJkOezTiVjiIDwjjnINBJ] = wgHPWmXvZjeOxhHTekxmohMTAMr;
					num = 1939403642;
					continue;
				default:
					wgHPWmXvZjeOxhHTekxmohMTAMr.SdmfoteCDVoXNaSlWEvRMBbwmDy();
					return true;
				}
				break;
				IL_0070:
				if (wgHPWmXvZjeOxhHTekxmohMTAMr == null)
				{
					return false;
				}
				pRWgMlsJkOezTiVjiIDwjjnINBJ = wgHPWmXvZjeOxhHTekxmohMTAMr.PRWgMlsJkOezTiVjiIDwjjnINBJ;
				int num2;
				if (!qYjfpOFjFAdamjqFeUBvEsuhpKSa.ContainsKey(pRWgMlsJkOezTiVjiIDwjjnINBJ))
				{
					num = 1939403640;
					num2 = num;
				}
				else
				{
					num = 1939403643;
					num2 = num;
				}
			}
			goto IL_0009;
			IL_0009:
			num = 1939403646;
			goto IL_000e;
			IL_003a:
			return false;
		}

		private void pqgfpJGGQzyxDtoFQDNDJTswiGb(int P_0)
		{
			if (qYjfpOFjFAdamjqFeUBvEsuhpKSa.ContainsKey(P_0))
			{
				qYjfpOFjFAdamjqFeUBvEsuhpKSa[P_0].zXkRFYvWKmYRnRyzULGdKkAtMGz();
				qYjfpOFjFAdamjqFeUBvEsuhpKSa.Remove(P_0);
			}
		}

		private mtPUEYnrqUFuxNtWHmDOApiJouJ CdbgebhODSFhlPGBZmhrAoIDJbV(int P_0)
		{
			if (!KjXmBSVldpfwjiNaozEQFsyjEtD.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private WgHPWmXvZjeOxhHTekxmohMTAMr EfWmNIVDrkDHQiUhUYtoPYCokKH(int P_0)
		{
			if (!qYjfpOFjFAdamjqFeUBvEsuhpKSa.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value;
		}

		private void BmTDdgCUFwRIIIXTBGCTUMboaeik()
		{
			while (RlJPuDpfhAyzcNeaFBQNBYkzwNAS.GsNywbZybDyvpbHOnDCMCkDlcCLf(gBmqzMSFplcvDWEjFNkPVRiXmat) != 0)
			{
				while (true)
				{
					IL_0180:
					JeeDedYOXXeUkcTqvwbxtDUdgET.DAidqScVoMmRYeGYCBInmhkHBp(gBmqzMSFplcvDWEjFNkPVRiXmat);
					RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bkzAijFpFAMwXmKjeOJkhMTFMMxD rAuDIZQDIBZEHyIvPjkkNMFnwNC = JeeDedYOXXeUkcTqvwbxtDUdgET.RAuDIZQDIBZEHyIvPjkkNMFnwNC;
					double realTime = ReInput.realTime;
					int num;
					switch (rAuDIZQDIBZEHyIvPjkkNMFnwNC)
					{
					case RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bkzAijFpFAMwXmKjeOJkhMTFMMxD.PFRqTbYasGGKIysjaPIdssZAGoQ:
					case RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bkzAijFpFAMwXmKjeOJkhMTFMMxD.uJBYjAQpTQvlzcenAfjlpVuzpEm:
						pWMZrOeUUOtTEepLzAhcgiyvaRYG(ref JeeDedYOXXeUkcTqvwbxtDUdgET.HQvvfAFqDOAxijJFKbNRnwSmXVm, realTime);
						num = -1739561051;
						goto IL_000a;
					case RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bkzAijFpFAMwXmKjeOJkhMTFMMxD.nDAVmdBOirrQengGjHhDzAaNDpw:
						goto IL_0086;
					case RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bkzAijFpFAMwXmKjeOJkhMTFMMxD.WLSuhriyTBHcIPnUwBzqSGHjZqQ:
						goto IL_00a2;
					case RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bkzAijFpFAMwXmKjeOJkhMTFMMxD.pauGmeXgVCqhZVPZlUXwRsBOcCa:
						goto IL_00bd;
					case RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bkzAijFpFAMwXmKjeOJkhMTFMMxD.wmnXVmmeVKdulCzTkMNPjDvAEBth:
					case RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bkzAijFpFAMwXmKjeOJkhMTFMMxD.YHVWfNxVkLKEYDpRQRxMgbuvVUW:
						goto IL_00e2;
					case RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bkzAijFpFAMwXmKjeOJkhMTFMMxD.cpohtVoyMfMZxAjAzqQARntxvsi:
						goto IL_00fe;
					case RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bkzAijFpFAMwXmKjeOJkhMTFMMxD.ISnrGALtjyPVLeLdIfJVsTrUcGfD:
						goto IL_0119;
					case RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bkzAijFpFAMwXmKjeOJkhMTFMMxD.eNRdgPfkBSEGSVjMoeZwIBFOgjA:
						goto IL_0135;
					case RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bkzAijFpFAMwXmKjeOJkhMTFMMxD.NGRnchmnjobVbFEfUTLnjBIuPRmb:
						goto IL_0165;
					default:
						num = -1739561030;
						goto IL_000a;
					case RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bkzAijFpFAMwXmKjeOJkhMTFMMxD.UIVFcpzbuRdfCaNGetxYHkYwkrgU:
						goto IL_0200;
					case RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bkzAijFpFAMwXmKjeOJkhMTFMMxD.XgqxxzWlcOEhMYnCsYIpCDUNDItI:
						goto IL_021c;
						IL_000a:
						while (true)
						{
							switch (num ^ -1739561048)
							{
							case 9:
								num = -1739561045;
								continue;
							case 5:
								break;
							case 18:
								num = -1739561051;
								continue;
							case 8:
								goto IL_0086;
							case 12:
								goto IL_00a2;
							case 15:
								goto IL_00bd;
							case 6:
								num = -1739561051;
								continue;
							case 7:
								goto IL_00e2;
							case 16:
								goto IL_00fe;
							case 2:
								goto IL_0119;
							case 1:
								goto IL_0135;
							case 4:
								num = -1739561051;
								continue;
							case 17:
								num = -1739561051;
								continue;
							case 10:
								goto IL_0165;
							case 3:
								goto IL_0180;
							case 11:
								goto IL_0200;
							case 0:
								goto IL_021c;
							case 14:
								num = -1739561051;
								continue;
							default:
								goto end_IL_01b1;
							}
							break;
						}
						goto case RlJPuDpfhAyzcNeaFBQNBYkzwNAS.bkzAijFpFAMwXmKjeOJkhMTFMMxD.PFRqTbYasGGKIysjaPIdssZAGoQ;
						IL_021c:
						ooocxEeYnqzwdfBrAiCuBNliXySv(ref JeeDedYOXXeUkcTqvwbxtDUdgET.uFRsrBLGOJVnPoKakschUvxwqYH);
						num = -1739561051;
						goto IL_000a;
						IL_0200:
						jjjRvqzInoKUcobdqbgHHDtJZor(ref JeeDedYOXXeUkcTqvwbxtDUdgET.bNEcBMtFmyqOnGHWTOETrGVBZNI, realTime);
						num = -1739561051;
						goto IL_000a;
						IL_0165:
						YvNZoXPlklHUBDtMrKfiwSiCAgQ(ref JeeDedYOXXeUkcTqvwbxtDUdgET.UpnGjkHfQkKANllrARJbGjkbxxl);
						num = -1739561051;
						goto IL_000a;
						IL_0135:
						UeCiiXURnITVEBhwxidJSMdLKbc(ref JeeDedYOXXeUkcTqvwbxtDUdgET.pDGzJyIzmjnQpQCUbEICkMrVAnqv, realTime);
						num = -1739561051;
						goto IL_000a;
						IL_0119:
						triDMpAaPGOjQFfHBVbGEHjTKTd(ref JeeDedYOXXeUkcTqvwbxtDUdgET.HghMQddAIKjgQgMRDoMCONHmxMGE, realTime);
						num = -1739561042;
						goto IL_000a;
						IL_00fe:
						KlXYfpZZlPaCuUIJkFTGBWOTGYUg(ref JeeDedYOXXeUkcTqvwbxtDUdgET.UpnGjkHfQkKANllrARJbGjkbxxl);
						num = -1739561031;
						goto IL_000a;
						IL_00e2:
						CyFcsqAXDmCSWNelwXPpaHdbnZCc(ref JeeDedYOXXeUkcTqvwbxtDUdgET.xucMXcyVvumAiOQNXHioOzshHaa, realTime);
						num = -1739561050;
						goto IL_000a;
						IL_00bd:
						zswgNeqltZmoAexauofCrxeTtUn(ref JeeDedYOXXeUkcTqvwbxtDUdgET.uFRsrBLGOJVnPoKakschUvxwqYH);
						num = -1739561051;
						goto IL_000a;
						IL_00a2:
						BhVWDdjewbdaYaCMjPZdJoABFSr(ref JeeDedYOXXeUkcTqvwbxtDUdgET.uFRsrBLGOJVnPoKakschUvxwqYH);
						num = -1739561051;
						goto IL_000a;
						IL_0086:
						ONVhVlPFpPVfGvqAhhjaWSGKKVR(ref JeeDedYOXXeUkcTqvwbxtDUdgET.rddvHJkNhpWeWPYcHWGSpFyiUHV, realTime);
						num = -1739561044;
						goto IL_000a;
						end_IL_01b1:
						break;
					}
					break;
				}
			}
		}

		private void jjjRvqzInoKUcobdqbgHHDtJZor(ref RlJPuDpfhAyzcNeaFBQNBYkzwNAS.pxqnynLwVkSyBlTcIpoxDRNrvFM P_0, double P_1)
		{
			if (pdMGqWoOXsknpEqFelIOnbtitYp)
			{
				pyNiIHDLfGffVQqPOsJqHvioITP(P_0.iisuVriChpgDYeIDNgPOFXmzyba, zlBtsxIKzBtKROSONkChkqMshrC.LpcrQwCnqOADJDLpyeZRCfTGKCVL, P_0.dYnGNhtpFLtedbiEpFJBIIgfMmPd, P_0.ZTonADnXjOPnKfCdZaXyKwbxjUQ, P_1);
			}
		}

		private void pWMZrOeUUOtTEepLzAhcgiyvaRYG(ref RlJPuDpfhAyzcNeaFBQNBYkzwNAS.xUBwUGjnlOAAIzptAZBMVpHFBytG P_0, double P_1)
		{
			if (!pdMGqWoOXsknpEqFelIOnbtitYp)
			{
				return;
			}
			while (true)
			{
				pyNiIHDLfGffVQqPOsJqHvioITP(P_0.iisuVriChpgDYeIDNgPOFXmzyba, zlBtsxIKzBtKROSONkChkqMshrC.GjbYMEzdvPEgvfibmESwCeHANBSm, P_0.PDTxWHalGAgFOZkJyOYLrrfBbQR, P_0.nuUsaiDejZRDtBfHlGgxzzfWtr, P_1);
				int num = 1957660595;
				while (true)
				{
					switch (num ^ 0x74AF87B2)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0009:
					num = 1957660592;
				}
			}
		}

		private void UeCiiXURnITVEBhwxidJSMdLKbc(ref RlJPuDpfhAyzcNeaFBQNBYkzwNAS.DatjbhJTcaimQRwKtmCbJzhISjZo P_0, double P_1)
		{
			if (!pdMGqWoOXsknpEqFelIOnbtitYp)
			{
				return;
			}
			while (true)
			{
				pyNiIHDLfGffVQqPOsJqHvioITP(P_0.iisuVriChpgDYeIDNgPOFXmzyba, zlBtsxIKzBtKROSONkChkqMshrC.zPglMLzCsADFJkYCqzSqAjySqTv, P_0.WCYSSUNPfuiYuMBmAstsdffrHjue, P_0.ZTonADnXjOPnKfCdZaXyKwbxjUQ, P_1);
				int num = 1092389615;
				while (true)
				{
					switch (num ^ 0x411C8AED)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0009:
					num = 1092389612;
				}
			}
		}

		private void ONVhVlPFpPVfGvqAhhjaWSGKKVR(ref RlJPuDpfhAyzcNeaFBQNBYkzwNAS.DeIteJJybGuHcqQDhUhUjixLaEl P_0, double P_1)
		{
			_ = pdMGqWoOXsknpEqFelIOnbtitYp;
		}

		private void YvNZoXPlklHUBDtMrKfiwSiCAgQ(ref RlJPuDpfhAyzcNeaFBQNBYkzwNAS.UrWhIIYKSYRXGTUrdnzlHrJoplp P_0)
		{
			if (!pdMGqWoOXsknpEqFelIOnbtitYp)
			{
				goto IL_0008;
			}
			goto IL_0040;
			IL_0008:
			int num = 1562896403;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x5D27E812)
				{
				case 0:
					break;
				default:
					return;
				case 4:
					gQBxsIJyfDheztEWqkgPpspxufJ();
					num = 1562896401;
					continue;
				case 2:
					goto IL_0040;
				case 1:
					return;
				case 3:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0040:
			HTKzJtWKDmkqZbNAPiKgDorFSCpp(P_0.iisuVriChpgDYeIDNgPOFXmzyba);
			int num2;
			if (gQBxsIJyfDheztEWqkgPpspxufJ != null)
			{
				num = 1562896406;
				num2 = num;
			}
			else
			{
				num = 1562896401;
				num2 = num;
			}
			goto IL_000d;
		}

		private void KlXYfpZZlPaCuUIJkFTGBWOTGYUg(ref RlJPuDpfhAyzcNeaFBQNBYkzwNAS.UrWhIIYKSYRXGTUrdnzlHrJoplp P_0)
		{
			if (!pdMGqWoOXsknpEqFelIOnbtitYp)
			{
				return;
			}
			while (true)
			{
				bkhdMfmQPHfhCGcFctvlbKVAspb(P_0.iisuVriChpgDYeIDNgPOFXmzyba);
				if (gQBxsIJyfDheztEWqkgPpspxufJ == null)
				{
					break;
				}
				gQBxsIJyfDheztEWqkgPpspxufJ();
				int num = -824367783;
				while (true)
				{
					switch (num ^ -824367784)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0009:
					num = -824367782;
				}
			}
		}

		private void triDMpAaPGOjQFfHBVbGEHjTKTd(ref RlJPuDpfhAyzcNeaFBQNBYkzwNAS.oAzeBRUYEewTyESnwwymBVLFmEz P_0, double P_1)
		{
			if (!yBQDRAFyzcChNxPYLhAMxAGRtfiD)
			{
				return;
			}
			while (true)
			{
				byte dYnGNhtpFLtedbiEpFJBIIgfMmPd = P_0.dYnGNhtpFLtedbiEpFJBIIgfMmPd;
				if (dYnGNhtpFLtedbiEpFJBIIgfMmPd == 6)
				{
					break;
				}
				mtbhQMdMhbZThCOLtezfQldsAxeX(P_0.iisuVriChpgDYeIDNgPOFXmzyba, zlBtsxIKzBtKROSONkChkqMshrC.LpcrQwCnqOADJDLpyeZRCfTGKCVL, P_0.dYnGNhtpFLtedbiEpFJBIIgfMmPd, P_0.ZTonADnXjOPnKfCdZaXyKwbxjUQ, P_1);
				int num = -1177644023;
				while (true)
				{
					switch (num ^ -1177644021)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0009:
					num = -1177644022;
				}
			}
		}

		private void CyFcsqAXDmCSWNelwXPpaHdbnZCc(ref RlJPuDpfhAyzcNeaFBQNBYkzwNAS.qnAKIaAIQkoBbZvMUgaHJAlGaFCC P_0, double P_1)
		{
			if (!yBQDRAFyzcChNxPYLhAMxAGRtfiD)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -1847545180;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1847545179)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				return;
			case 3:
				goto IL_0032;
			case 2:
				return;
			}
			goto IL_0008;
			IL_0032:
			byte pDTxWHalGAgFOZkJyOYLrrfBbQR = P_0.PDTxWHalGAgFOZkJyOYLrrfBbQR;
			if (pDTxWHalGAgFOZkJyOYLrrfBbQR != 15)
			{
				mtbhQMdMhbZThCOLtezfQldsAxeX(P_0.iisuVriChpgDYeIDNgPOFXmzyba, zlBtsxIKzBtKROSONkChkqMshrC.GjbYMEzdvPEgvfibmESwCeHANBSm, P_0.PDTxWHalGAgFOZkJyOYLrrfBbQR, P_0.nuUsaiDejZRDtBfHlGgxzzfWtr, P_1);
				num = -1847545177;
				goto IL_000d;
			}
		}

		private void zswgNeqltZmoAexauofCrxeTtUn(ref RlJPuDpfhAyzcNeaFBQNBYkzwNAS.zRbooqQrJkmYMMGdLJRCpegpIVh P_0)
		{
			if (!yBQDRAFyzcChNxPYLhAMxAGRtfiD)
			{
				return;
			}
			while (true)
			{
				JRWGGdHFlGAhJANVFrfzUrNBnbyt(P_0.iisuVriChpgDYeIDNgPOFXmzyba);
				if (gQBxsIJyfDheztEWqkgPpspxufJ == null)
				{
					break;
				}
				gQBxsIJyfDheztEWqkgPpspxufJ();
				int num = 476713947;
				while (true)
				{
					switch (num ^ 0x1C6A13D9)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0009:
					num = 476713944;
				}
			}
		}

		private void BhVWDdjewbdaYaCMjPZdJoABFSr(ref RlJPuDpfhAyzcNeaFBQNBYkzwNAS.zRbooqQrJkmYMMGdLJRCpegpIVh P_0)
		{
			if (!yBQDRAFyzcChNxPYLhAMxAGRtfiD)
			{
				return;
			}
			while (true)
			{
				pqgfpJGGQzyxDtoFQDNDJTswiGb(P_0.iisuVriChpgDYeIDNgPOFXmzyba);
				int num = -517691682;
				while (true)
				{
					switch (num ^ -517691682)
					{
					case 4:
						num = -517691681;
						continue;
					default:
						return;
					case 1:
						break;
					case 2:
						gQBxsIJyfDheztEWqkgPpspxufJ();
						num = -517691683;
						continue;
					case 0:
					{
						int num2;
						if (gQBxsIJyfDheztEWqkgPpspxufJ != null)
						{
							num = -517691684;
							num2 = num;
						}
						else
						{
							num = -517691683;
							num2 = num;
						}
						continue;
					}
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void ooocxEeYnqzwdfBrAiCuBNliXySv(ref RlJPuDpfhAyzcNeaFBQNBYkzwNAS.zRbooqQrJkmYMMGdLJRCpegpIVh P_0)
		{
			_ = yBQDRAFyzcChNxPYLhAMxAGRtfiD;
		}

		private void pyNiIHDLfGffVQqPOsJqHvioITP(int P_0, zlBtsxIKzBtKROSONkChkqMshrC P_1, byte P_2, short P_3, double P_4)
		{
			mtPUEYnrqUFuxNtWHmDOApiJouJ mtPUEYnrqUFuxNtWHmDOApiJouJ2 = CdbgebhODSFhlPGBZmhrAoIDJbV(P_0);
			while (true)
			{
				int num = -1493799809;
				while (true)
				{
					switch (num ^ -1493799810)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						if (mtPUEYnrqUFuxNtWHmDOApiJouJ2 != null)
						{
							goto IL_0035;
						}
						return;
					case 0:
						goto IL_0035;
					case 2:
						return;
					}
					break;
					IL_0035:
					mtPUEYnrqUFuxNtWHmDOApiJouJ2.KyHpjvRkJIBKWzDbtHSSnZwunyW(P_1, P_2, P_3, P_4);
					num = -1493799812;
				}
			}
		}

		private void mtbhQMdMhbZThCOLtezfQldsAxeX(int P_0, zlBtsxIKzBtKROSONkChkqMshrC P_1, byte P_2, short P_3, double P_4)
		{
			WgHPWmXvZjeOxhHTekxmohMTAMr wgHPWmXvZjeOxhHTekxmohMTAMr = EfWmNIVDrkDHQiUhUYtoPYCokKH(P_0);
			while (true)
			{
				int num = -1902256805;
				while (true)
				{
					switch (num ^ -1902256808)
					{
					case 0:
						break;
					case 3:
					{
						int num2;
						if (wgHPWmXvZjeOxhHTekxmohMTAMr != null)
						{
							num = -1902256807;
							num2 = num;
						}
						else
						{
							num = -1902256806;
							num2 = num;
						}
						continue;
					}
					case 2:
						return;
					default:
						wgHPWmXvZjeOxhHTekxmohMTAMr.KyHpjvRkJIBKWzDbtHSSnZwunyW(P_1, P_2, P_3, P_4);
						return;
					}
					break;
				}
			}
		}

		private void UrJqTbTWAPLwPMwXLGwRwWeUEuF()
		{
			string[] array = PDkAosxRDrWGeKWGDMZUeNxRJme.yIuiMArpHczXiRFNVKvUACrafDc();
			int num2 = default(int);
			while (true)
			{
				int num = 349804301;
				while (true)
				{
					switch (num ^ 0x14D99709)
					{
					case 7:
						break;
					case 5:
						num = 349804297;
						continue;
					case 9:
					{
						int num5;
						if (array[num2].Length > 32)
						{
							num = 349804303;
							num5 = num;
						}
						else
						{
							num = 349804296;
							num5 = num;
						}
						continue;
					}
					case 2:
					{
						int num3;
						if (string.IsNullOrEmpty(array[num2]))
						{
							num = 349804296;
							num3 = num;
						}
						else
						{
							num = 349804288;
							num3 = num;
						}
						continue;
					}
					case 1:
						num2++;
						num = 349804297;
						continue;
					case 4:
					{
						int num4;
						if (array == null)
						{
							num = 349804289;
							num4 = num;
						}
						else
						{
							num = 349804298;
							num4 = num;
						}
						continue;
					}
					case 8:
						return;
					case 3:
						num2 = 0;
						num = 349804300;
						continue;
					case 6:
						if (!(RlJPuDpfhAyzcNeaFBQNBYkzwNAS.VYNhEHeKaogPzapcCQZQyVnYEmyo(new Guid(array[num2].Substring(0, 32))) != string.Empty))
						{
							RlJPuDpfhAyzcNeaFBQNBYkzwNAS.cAprljVeBVwYLnRDMbmUEAfDizi(array[num2]);
							num = 349804296;
							continue;
						}
						goto case 1;
					default:
						if (num2 >= array.Length)
						{
							return;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~SDL2InputSource()
		{
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				goto IL_0008;
			}
			goto IL_0036;
			IL_0008:
			int num = -1677415579;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1677415583)
			{
			case 0:
				break;
			case 4:
				return;
			case 1:
				goto IL_0036;
			case 2:
				goto IL_0053;
			default:
				goto IL_0060;
			}
			goto IL_0008;
			IL_0036:
			if (disposing)
			{
				if (gBmqzMSFplcvDWEjFNkPVRiXmat != null)
				{
					gBmqzMSFplcvDWEjFNkPVRiXmat.Dispose();
					num = -1677415581;
					goto IL_000d;
				}
				goto IL_0053;
			}
			goto IL_0060;
			IL_0053:
			aMlUiYbNJVldBMbzeMMezPoAItT();
			num = -1677415582;
			goto IL_000d;
			IL_0060:
			RlJPuDpfhAyzcNeaFBQNBYkzwNAS.kWSNyxkZwHDLRKnPhXXEjXHRTim();
			PwPWygBTznyByBIyaAyqEfnsXBM = false;
			xRygqjRmTtURDPiwlgMmFcdNBrr = true;
		}
	}
}
