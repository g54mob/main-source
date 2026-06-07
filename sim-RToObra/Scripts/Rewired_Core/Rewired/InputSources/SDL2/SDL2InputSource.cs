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
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class SDL2InputSource : IDisposable, IInputSource
	{
		public delegate void uWraBpMWlFbAgYTMyeTvKjRoAbN(int joystickId, byte rewiredElementType, byte elementIndex, short value);

		public delegate void HSEDHGCKVJCqBQytCrCzhfECLMuO(int joystickIndex);

		public delegate void ZNqbxGfXNqVZlRSYQwJdVEMJPX(int joystickId);

		public delegate void jMyHilCGfoCguCCWFzqKwxlzEZTN(int gameControllerId, byte rewiredElementType, byte sdlElementType, short value);

		private const int hKqKitxptdmBvmisFxoqkNdlJtX = 32;

		private bool lgIWiCmutwdCNHwQPrQVIcHvAlBJ;

		private bool iGnxYwRWiTPdScoiohDdqoEntM;

		private bool JUQVxgIOnvaTgssgbzTlGcephgU;

		private bool uLrDDqgVKMsgrfbQADELDAPhHnjW;

		private bool PkVqugVNIpoYIMpSDcpjdJRrnVs;

		private ADictionary<int, yoBcmQfgFIKVVURwqaiPlYRIeyr> AVRtfMRpOzQlHvmKXxpZoBGaQUn;

		private ADictionary<int, IFRqbyNUwbeoLuQrDXlfXbkASFD> wjrDQQPBkAHSOhQfPUkoPJUaEwi;

		private VuTGCVdtQMXPEMCKcnDOxWAgDee.kSgEoVtMAiuYtdGnisCruHPEKmB NfmPtlIZoPJGQvXSYHPwMtmiNQn;

		private NativeBuffer yxgBxCUwUzJbzHnRoDAUopOAsnT;

		private Action kNXIQEVSsDEgVkqFLLuKGNvojTr;

		private bool vsurYtRlepcrpAzAENwjqjJEZPT;

		public bool initialized
		{
			get
			{
				return PkVqugVNIpoYIMpSDcpjdJRrnVs;
			}
		}

		private event Action _DeviceChangedEvent
		{
			add
			{
				Action action = kNXIQEVSsDEgVkqFLLuKGNvojTr;
				Action action2 = default(Action);
				while (true)
				{
					int num = -1255212028;
					while (true)
					{
						switch (num ^ -1255212025)
						{
						case 0:
							break;
						default:
							return;
						case 3:
						{
							action2 = action;
							Action value2 = (Action)Delegate.Combine(action2, b);
							action = Interlocked.CompareExchange(ref kNXIQEVSsDEgVkqFLLuKGNvojTr, value2, action2);
							num = -1255212027;
							continue;
						}
						case 2:
						{
							int num2;
							if ((object)action != action2)
							{
								num = -1255212028;
								num2 = num;
							}
							else
							{
								num = -1255212026;
								num2 = num;
							}
							continue;
						}
						case 1:
							return;
						}
						break;
					}
				}
			}
			remove
			{
				Action action = kNXIQEVSsDEgVkqFLLuKGNvojTr;
				while (true)
				{
					int num = 833178146;
					while (true)
					{
						switch (num ^ 0x31A94A23)
						{
						case 0:
							break;
						default:
							return;
						case 1:
						{
							Action action2 = action;
							Action value2 = (Action)Delegate.Remove(action2, value3);
							action = Interlocked.CompareExchange(ref kNXIQEVSsDEgVkqFLLuKGNvojTr, value2, action2);
							int num2;
							if ((object)action == action2)
							{
								num = 833178145;
								num2 = num;
							}
							else
							{
								num = 833178146;
								num2 = num;
							}
							continue;
						}
						case 2:
							return;
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
			while (true)
			{
				int num = 378831124;
				while (true)
				{
					int num3;
					switch (num ^ 0x16948115)
					{
					case 2:
						break;
					case 1:
						lgIWiCmutwdCNHwQPrQVIcHvAlBJ = handleJoysticks;
						iGnxYwRWiTPdScoiohDdqoEntM = handleGamepads;
						JUQVxgIOnvaTgssgbzTlGcephgU = handleUnifiedMouse;
						uLrDDqgVKMsgrfbQADELDAPhHnjW = handleUnifiedKeyboard;
						AVRtfMRpOzQlHvmKXxpZoBGaQUn = new ADictionary<int, yoBcmQfgFIKVVURwqaiPlYRIeyr>();
						num = 378831126;
						continue;
					case 0:
						num3 = 25088;
						goto IL_009f;
					case 3:
						wjrDQQPBkAHSOhQfPUkoPJUaEwi = new ADictionary<int, IFRqbyNUwbeoLuQrDXlfXbkASFD>();
						if (UnityTools.isEditor)
						{
							int num2;
							if (UnityTools.editorPlatform == EditorPlatform.OSX)
							{
								num = 378831125;
								num2 = num;
							}
							else
							{
								num = 378831121;
								num2 = num;
							}
							continue;
						}
						goto default;
					default:
						{
							num3 = 29184;
							goto IL_009f;
						}
						IL_009f:
						try
						{
							VuTGCVdtQMXPEMCKcnDOxWAgDee.etXDCcPLPGHSkjTFOdDrHIPRCBIN(UnityTools.effectivePlatform);
							if (VuTGCVdtQMXPEMCKcnDOxWAgDee.eELxvXWxBeEiSrTjahsmSfBmZUD((uint)num3) < 0)
							{
								throw new Exception("Failed initialize SDL2!");
							}
							PkVqugVNIpoYIMpSDcpjdJRrnVs = true;
							if (handleGamepads)
							{
								QqNfMxZkzRUOhLhdiVGGPCKVJml();
							}
							MFcVzabIIbDDJFvddnRqbcyQkwQ();
							yxgBxCUwUzJbzHnRoDAUopOAsnT = new NativeBuffer(56);
							return;
						}
						catch
						{
							PkVqugVNIpoYIMpSDcpjdJRrnVs = false;
							Dispose();
							throw;
						}
					}
					break;
				}
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
			bool pkVqugVNIpoYIMpSDcpjdJRrnV = PkVqugVNIpoYIMpSDcpjdJRrnVs;
		}

		public void UpdateDevices(UpdateLoopType updateLoop)
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -1636131403;
			goto IL_000d;
			IL_000d:
			switch (num ^ -1636131404)
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
			RBnFiOAcuOgwEAxBzxUVvXpnsEL();
			num = -1636131402;
			goto IL_000d;
		}

		public void UpdateFinished()
		{
			bool pkVqugVNIpoYIMpSDcpjdJRrnV = PkVqugVNIpoYIMpSDcpjdJRrnVs;
		}

		public IList<T> GetJoysticks<T>() where T : class
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				return null;
			}
			List<jubkEfPWovmVDOzYftHZlVlzvfw> list = new List<jubkEfPWovmVDOzYftHZlVlzvfw>();
			if (lgIWiCmutwdCNHwQPrQVIcHvAlBJ)
			{
				using (ADictionary<int, yoBcmQfgFIKVVURwqaiPlYRIeyr>.Enumerator enumerator = AVRtfMRpOzQlHvmKXxpZoBGaQUn.GetEnumerator())
				{
					yoBcmQfgFIKVVURwqaiPlYRIeyr value = default(yoBcmQfgFIKVVURwqaiPlYRIeyr);
					while (enumerator.MoveNext())
					{
						while (true)
						{
							KeyValuePair<int, yoBcmQfgFIKVVURwqaiPlYRIeyr> current = enumerator.Current;
							int num = -373795097;
							while (true)
							{
								switch (num ^ -373795100)
								{
								case 2:
									num = -373795104;
									continue;
								case 4:
									break;
								case 3:
									value = current.Value;
									num = -373795100;
									continue;
								case 0:
									if (value.IsValid)
									{
										list.Add(current.Value);
										num = -373795099;
										continue;
									}
									goto end_IL_0050;
								default:
									goto end_IL_0050;
								}
								break;
							}
							continue;
							end_IL_0050:
							break;
						}
					}
				}
			}
			if (iGnxYwRWiTPdScoiohDdqoEntM)
			{
				using (ADictionary<int, IFRqbyNUwbeoLuQrDXlfXbkASFD>.Enumerator enumerator2 = wjrDQQPBkAHSOhQfPUkoPJUaEwi.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							IFRqbyNUwbeoLuQrDXlfXbkASFD value2 = enumerator2.Current.Value;
							int num2;
							int num3;
							if (value2.IsValid)
							{
								num2 = -373795097;
								num3 = num2;
							}
							else
							{
								num2 = -373795099;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ -373795100)
								{
								case 0:
									num2 = -373795098;
									continue;
								case 2:
									break;
								case 3:
									list.Add(value2);
									num2 = -373795099;
									continue;
								default:
									goto end_IL_00df;
								}
								break;
							}
							continue;
							end_IL_00df:
							break;
						}
					}
				}
			}
			return list as IList<T>;
		}

		private int uzEJlKCtBKkoTNIEvKTPQjLVgZn()
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				return 0;
			}
			return Math.Min(VuTGCVdtQMXPEMCKcnDOxWAgDee.QLzdqadPpfPucWvTHjmcGTyBixWX(), 32);
		}

		private int eIdaWRzIMYAAVJOQaFxahELJzGWH()
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				goto IL_0008;
			}
			int num = uzEJlKCtBKkoTNIEvKTPQjLVgZn();
			int num2 = -1001440652;
			goto IL_000d;
			IL_000d:
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -1001440653)
				{
				case 5:
					break;
				case 1:
					num4 = 0;
					num2 = -1001440649;
					continue;
				case 7:
					num3 = 0;
					num2 = -1001440654;
					continue;
				case 6:
					if (!VuTGCVdtQMXPEMCKcnDOxWAgDee.jxfdtarrXWEKECerUYcGvQdfssG(num4))
					{
						num3++;
						num2 = -1001440653;
						continue;
					}
					goto case 0;
				case 0:
					num4++;
					num2 = -1001440649;
					continue;
				case 2:
					return 0;
				case 4:
				{
					int num5;
					if (num4 < num)
					{
						num2 = -1001440651;
						num5 = num2;
					}
					else
					{
						num2 = -1001440656;
						num5 = num2;
					}
					continue;
				}
				default:
					return num3;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1001440655;
			goto IL_000d;
		}

		private yoBcmQfgFIKVVURwqaiPlYRIeyr FgGlwiqWfHQzvDWCENiMhBqmJjL(int P_0)
		{
			IntPtr intPtr = VuTGCVdtQMXPEMCKcnDOxWAgDee.SIPCBFFaBfrfAovgcsIfKzFkckBH(P_0);
			if (intPtr == IntPtr.Zero)
			{
				goto IL_0014;
			}
			dmKUPPBTIjpWsLWFEmbcbKrKfGk dmKUPPBTIjpWsLWFEmbcbKrKfGk2 = new dmKUPPBTIjpWsLWFEmbcbKrKfGk(intPtr);
			XYitobKpIgOpWUmHymAwqjSLOet xYitobKpIgOpWUmHymAwqjSLOet = YiGGlDAmsRHTBWfmilHZwfrcLgm(P_0, dmKUPPBTIjpWsLWFEmbcbKrKfGk2);
			int num;
			if (xYitobKpIgOpWUmHymAwqjSLOet == null)
			{
				num = 235821709;
				goto IL_0019;
			}
			return new yoBcmQfgFIKVVURwqaiPlYRIeyr(dmKUPPBTIjpWsLWFEmbcbKrKfGk2, xYitobKpIgOpWUmHymAwqjSLOet);
			IL_0014:
			num = 235821710;
			goto IL_0019;
			IL_0019:
			switch (num ^ 0xE0E5A8F)
			{
			case 0:
				break;
			case 1:
				return null;
			default:
				VuTGCVdtQMXPEMCKcnDOxWAgDee.RWxViftheoJPaFBIAjvSxRggAIO(intPtr);
				return null;
			}
			goto IL_0014;
		}

		private IFRqbyNUwbeoLuQrDXlfXbkASFD tadvqQebrCqYuBUARMMoRBboQQI(int P_0)
		{
			IntPtr intPtr = VuTGCVdtQMXPEMCKcnDOxWAgDee.VhptErtvhUTLzqyGzbvckIQqHmb(P_0);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			gFpppwTpWdVCaaYhbVuNcAuyuRH gFpppwTpWdVCaaYhbVuNcAuyuRH2 = new gFpppwTpWdVCaaYhbVuNcAuyuRH(intPtr);
			XYitobKpIgOpWUmHymAwqjSLOet xYitobKpIgOpWUmHymAwqjSLOet = WhlTSdqHFdVaaIKuNisOeRWCTOS(P_0, gFpppwTpWdVCaaYhbVuNcAuyuRH2);
			if (xYitobKpIgOpWUmHymAwqjSLOet == null)
			{
				goto IL_0029;
			}
			int num;
			if (!xYitobKpIgOpWUmHymAwqjSLOet.zcjPHyuHrtGaBlPcTBcmtQyJHir)
			{
				num = -1632669045;
				goto IL_002e;
			}
			xYitobKpIgOpWUmHymAwqjSLOet.MbrQwRnmlvxaToztrCqZEslEYAm = VuTGCVdtQMXPEMCKcnDOxWAgDee.fYykGOkvfMERkhpBwpEwRaLQDEu(gFpppwTpWdVCaaYhbVuNcAuyuRH2);
			return new IFRqbyNUwbeoLuQrDXlfXbkASFD(gFpppwTpWdVCaaYhbVuNcAuyuRH2, xYitobKpIgOpWUmHymAwqjSLOet);
			IL_002e:
			switch (num ^ -1632669045)
			{
			case 2:
				break;
			case 1:
				return null;
			default:
				VuTGCVdtQMXPEMCKcnDOxWAgDee.TlitWzmLKtQNVhWMyIqWjBOvC(intPtr);
				return null;
			}
			goto IL_0029;
			IL_0029:
			num = -1632669046;
			goto IL_002e;
		}

		private XYitobKpIgOpWUmHymAwqjSLOet YiGGlDAmsRHTBWfmilHZwfrcLgm(int P_0, dmKUPPBTIjpWsLWFEmbcbKrKfGk P_1)
		{
			if (!PkVqugVNIpoYIMpSDcpjdJRrnVs)
			{
				return null;
			}
			XYitobKpIgOpWUmHymAwqjSLOet xYitobKpIgOpWUmHymAwqjSLOet = default(XYitobKpIgOpWUmHymAwqjSLOet);
			int num;
			if (P_0 >= 0)
			{
				if (P_0 >= 32)
				{
					goto IL_0019;
				}
				if (P_1 != null)
				{
					if (P_1.IsValid)
					{
						xYitobKpIgOpWUmHymAwqjSLOet = new XYitobKpIgOpWUmHymAwqjSLOet();
						num = -1670509461;
					}
					else
					{
						num = -1670509458;
					}
					goto IL_001e;
				}
				goto IL_007e;
			}
			goto IL_00e9;
			IL_00e9:
			return null;
			IL_0019:
			num = -1670509460;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -1670509464)
				{
				case 7:
					break;
				case 0:
					xYitobKpIgOpWUmHymAwqjSLOet.wRceQnAMrzPnjgfOOcFDeDiISSJA = VuTGCVdtQMXPEMCKcnDOxWAgDee.CUjMbANsNaKDVBuXRJTgbXyvYtU(P_1);
					num = -1670509463;
					continue;
				case 1:
					xYitobKpIgOpWUmHymAwqjSLOet.cAPiWvgwtlyLKeOLGzTJlhAlArba = VuTGCVdtQMXPEMCKcnDOxWAgDee.mqEgOITgruJfMcuwvcsOcRvFITF(P_1);
					num = -1670509459;
					continue;
				case 6:
					goto IL_007e;
				case 3:
					xYitobKpIgOpWUmHymAwqjSLOet.iPJHmnBZwZyyrKapRxnHtBsSkn = P_0;
					xYitobKpIgOpWUmHymAwqjSLOet.WevTdQwnzmzGusLgYZijrubkIwX = VuTGCVdtQMXPEMCKcnDOxWAgDee.mTsDOjJbRMAHasvwTeyBRMpMnfaN(P_1);
					xYitobKpIgOpWUmHymAwqjSLOet.zcjPHyuHrtGaBlPcTBcmtQyJHir = VuTGCVdtQMXPEMCKcnDOxWAgDee.jxfdtarrXWEKECerUYcGvQdfssG(P_0);
					xYitobKpIgOpWUmHymAwqjSLOet.wmbEVxLvcdfrsmoyOrwQnKujFgS = VuTGCVdtQMXPEMCKcnDOxWAgDee.qbLpeKqJtDXQmvjOjoJlXIQnmJW(P_1);
					xYitobKpIgOpWUmHymAwqjSLOet.ephVnajWTSCruaEPsIlMceKdsbuL = VuTGCVdtQMXPEMCKcnDOxWAgDee.OZeKYhqFJkeMijsunICpzMiQGdWh(P_1);
					xYitobKpIgOpWUmHymAwqjSLOet.qztnyJnmXALabDHtKLvFKEwPkuM = VuTGCVdtQMXPEMCKcnDOxWAgDee.GRlxNqSqcnGJgddfYymskSKnMiJ(P_0);
					num = -1670509462;
					continue;
				case 4:
					goto IL_00e9;
				case 2:
					xYitobKpIgOpWUmHymAwqjSLOet.SgYwVaEgtCZiUkgVDcTwJWbyDTtb = VuTGCVdtQMXPEMCKcnDOxWAgDee.mhpzaElUgqVTIuCMUjHWzGhuCLY(P_1);
					xYitobKpIgOpWUmHymAwqjSLOet.TwhUkSEboxGPsJgqbpmupSCMcvva = VuTGCVdtQMXPEMCKcnDOxWAgDee.YVfyeInXRLEGgAgoyEsFKIZlrKBL(P_1);
					num = -1670509464;
					continue;
				default:
					return xYitobKpIgOpWUmHymAwqjSLOet;
				}
				break;
			}
			goto IL_0019;
			IL_007e:
			return null;
		}

		private XYitobKpIgOpWUmHymAwqjSLOet WhlTSdqHFdVaaIKuNisOeRWCTOS(int P_0, gFpppwTpWdVCaaYhbVuNcAuyuRH P_1)
		{
			if (P_1 == null || !P_1.IsValid)
			{
				return null;
			}
			dmKUPPBTIjpWsLWFEmbcbKrKfGk dmKUPPBTIjpWsLWFEmbcbKrKfGk2 = new dmKUPPBTIjpWsLWFEmbcbKrKfGk(VuTGCVdtQMXPEMCKcnDOxWAgDee.BsMEkRNGWNcSiMDGIBSVugtyqns(P_1));
			if (!dmKUPPBTIjpWsLWFEmbcbKrKfGk2.IsValid)
			{
				return null;
			}
			return YiGGlDAmsRHTBWfmilHZwfrcLgm(P_0, dmKUPPBTIjpWsLWFEmbcbKrKfGk2);
		}

		private void MFcVzabIIbDDJFvddnRqbcyQkwQ()
		{
			int num = 0;
			while (true)
			{
				int num2 = 714668375;
				while (true)
				{
					switch (num2 ^ 0x2A98F955)
					{
					case 0:
						break;
					case 2:
						num2 = 714668371;
						continue;
					case 1:
					{
						int num3;
						if (!lgIWiCmutwdCNHwQPrQVIcHvAlBJ)
						{
							num2 = 714668369;
							num3 = num2;
						}
						else
						{
							num2 = 714668368;
							num3 = num2;
						}
						continue;
					}
					case 4:
						if (iGnxYwRWiTPdScoiohDdqoEntM)
						{
							RNMyjAFMDERbhOfQKYAiIdXsfeC(num);
							num2 = 714668374;
							continue;
						}
						goto case 3;
					case 5:
						LQGxclUaisClvyzkifGfZFVUDUD(num);
						num2 = 714668369;
						continue;
					case 3:
						num++;
						num2 = 714668371;
						continue;
					default:
						if (num >= uzEJlKCtBKkoTNIEvKTPQjLVgZn())
						{
							return;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		private void yWfWtSpcgNVVbPBMXhhbWKBJfmj()
		{
			if (iGnxYwRWiTPdScoiohDdqoEntM)
			{
				using (ADictionary<int, IFRqbyNUwbeoLuQrDXlfXbkASFD>.Enumerator enumerator = wjrDQQPBkAHSOhQfPUkoPJUaEwi.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						while (true)
						{
							IFRqbyNUwbeoLuQrDXlfXbkASFD value = enumerator.Current.Value;
							int num = 465472373;
							while (true)
							{
								switch (num ^ 0x1BBE8B76)
								{
								case 0:
									num = 465472375;
									continue;
								case 1:
									break;
								case 3:
									value.xcaJhTEntwJovIWWzEiTSzKkHUZn();
									value.Dispose();
									num = 465472372;
									continue;
								default:
									goto end_IL_0039;
								}
								break;
							}
							continue;
							end_IL_0039:
							break;
						}
					}
				}
				wjrDQQPBkAHSOhQfPUkoPJUaEwi.Clear();
			}
			if (!lgIWiCmutwdCNHwQPrQVIcHvAlBJ)
			{
				return;
			}
			using (ADictionary<int, yoBcmQfgFIKVVURwqaiPlYRIeyr>.Enumerator enumerator2 = AVRtfMRpOzQlHvmKXxpZoBGaQUn.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					while (true)
					{
						yoBcmQfgFIKVVURwqaiPlYRIeyr value2 = enumerator2.Current.Value;
						value2.xcaJhTEntwJovIWWzEiTSzKkHUZn();
						value2.Dispose();
						int num2 = 465472372;
						while (true)
						{
							switch (num2 ^ 0x1BBE8B76)
							{
							case 0:
								num2 = 465472375;
								continue;
							case 1:
								break;
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
			AVRtfMRpOzQlHvmKXxpZoBGaQUn.Clear();
		}

		private bool LQGxclUaisClvyzkifGfZFVUDUD(int P_0)
		{
			if (P_0 >= 0)
			{
				int fqCcixihNQhPjnqFZjkjMuVDgPd = default(int);
				yoBcmQfgFIKVVURwqaiPlYRIeyr yoBcmQfgFIKVVURwqaiPlYRIeyr2 = default(yoBcmQfgFIKVVURwqaiPlYRIeyr);
				while (true)
				{
					int num = -1997649483;
					while (true)
					{
						switch (num ^ -1997649481)
						{
						case 5:
							break;
						case 2:
							goto IL_0038;
						case 3:
							AVRtfMRpOzQlHvmKXxpZoBGaQUn[fqCcixihNQhPjnqFZjkjMuVDgPd].xcaJhTEntwJovIWWzEiTSzKkHUZn();
							AVRtfMRpOzQlHvmKXxpZoBGaQUn[fqCcixihNQhPjnqFZjkjMuVDgPd] = yoBcmQfgFIKVVURwqaiPlYRIeyr2;
							num = -1997649482;
							continue;
						case 0:
							goto IL_006c;
						case 4:
							AVRtfMRpOzQlHvmKXxpZoBGaQUn.Add(fqCcixihNQhPjnqFZjkjMuVDgPd, yoBcmQfgFIKVVURwqaiPlYRIeyr2);
							num = -1997649482;
							continue;
						case 6:
							goto end_IL_0007;
						default:
							yoBcmQfgFIKVVURwqaiPlYRIeyr2.YJaAHaimrHWIfKrgfWxeihnqrcza();
							return true;
						}
						break;
						IL_006c:
						if (VuTGCVdtQMXPEMCKcnDOxWAgDee.jxfdtarrXWEKECerUYcGvQdfssG(P_0))
						{
							return false;
						}
						goto IL_0076;
						IL_0076:
						yoBcmQfgFIKVVURwqaiPlYRIeyr2 = FgGlwiqWfHQzvDWCENiMhBqmJjL(P_0);
						if (yoBcmQfgFIKVVURwqaiPlYRIeyr2 == null)
						{
							return false;
						}
						fqCcixihNQhPjnqFZjkjMuVDgPd = yoBcmQfgFIKVVURwqaiPlYRIeyr2.FqCcixihNQhPjnqFZjkjMuVDgPd;
						int num2;
						if (!AVRtfMRpOzQlHvmKXxpZoBGaQUn.ContainsKey(fqCcixihNQhPjnqFZjkjMuVDgPd))
						{
							num = -1997649485;
							num2 = num;
						}
						else
						{
							num = -1997649484;
							num2 = num;
						}
						continue;
						IL_0038:
						if (P_0 >= 32)
						{
							num = -1997649487;
							continue;
						}
						if (iGnxYwRWiTPdScoiohDdqoEntM)
						{
							num = -1997649481;
							continue;
						}
						goto IL_0076;
					}
					continue;
					end_IL_0007:
					break;
				}
			}
			return false;
		}

		private void zwbHitsqiXGFqJjlZgUaENxJxbF(int P_0)
		{
			if (!AVRtfMRpOzQlHvmKXxpZoBGaQUn.ContainsKey(P_0))
			{
				return;
			}
			while (true)
			{
				AVRtfMRpOzQlHvmKXxpZoBGaQUn[P_0].xcaJhTEntwJovIWWzEiTSzKkHUZn();
				int num = 1569618242;
				while (true)
				{
					switch (num ^ 0x5D8E7940)
					{
					case 0:
						num = 1569618241;
						continue;
					default:
						return;
					case 1:
						break;
					case 2:
						AVRtfMRpOzQlHvmKXxpZoBGaQUn.Remove(P_0);
						num = 1569618243;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private bool RNMyjAFMDERbhOfQKYAiIdXsfeC(int P_0)
		{
			IFRqbyNUwbeoLuQrDXlfXbkASFD iFRqbyNUwbeoLuQrDXlfXbkASFD = default(IFRqbyNUwbeoLuQrDXlfXbkASFD);
			int num;
			int fqCcixihNQhPjnqFZjkjMuVDgPd = default(int);
			if (P_0 >= 0)
			{
				if (P_0 >= 32)
				{
					goto IL_0009;
				}
				if (VuTGCVdtQMXPEMCKcnDOxWAgDee.jxfdtarrXWEKECerUYcGvQdfssG(P_0))
				{
					iFRqbyNUwbeoLuQrDXlfXbkASFD = tadvqQebrCqYuBUARMMoRBboQQI(P_0);
					if (iFRqbyNUwbeoLuQrDXlfXbkASFD == null)
					{
						num = 1318809444;
					}
					else
					{
						fqCcixihNQhPjnqFZjkjMuVDgPd = iFRqbyNUwbeoLuQrDXlfXbkASFD.FqCcixihNQhPjnqFZjkjMuVDgPd;
						if (!wjrDQQPBkAHSOhQfPUkoPJUaEwi.ContainsKey(fqCcixihNQhPjnqFZjkjMuVDgPd))
						{
							goto IL_006c;
						}
						wjrDQQPBkAHSOhQfPUkoPJUaEwi[fqCcixihNQhPjnqFZjkjMuVDgPd].xcaJhTEntwJovIWWzEiTSzKkHUZn();
						wjrDQQPBkAHSOhQfPUkoPJUaEwi[fqCcixihNQhPjnqFZjkjMuVDgPd] = iFRqbyNUwbeoLuQrDXlfXbkASFD;
						num = 1318809440;
					}
				}
				else
				{
					num = 1318809447;
				}
				goto IL_000e;
			}
			goto IL_005b;
			IL_005b:
			return false;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x4E9B6F65)
				{
				case 4:
					break;
				case 5:
					iFRqbyNUwbeoLuQrDXlfXbkASFD.YJaAHaimrHWIfKrgfWxeihnqrcza();
					num = 1318809446;
					continue;
				case 2:
					return false;
				case 6:
					goto IL_005b;
				case 0:
					goto IL_006c;
				case 1:
					return false;
				default:
					return true;
				}
				break;
			}
			goto IL_0009;
			IL_0009:
			num = 1318809443;
			goto IL_000e;
			IL_006c:
			wjrDQQPBkAHSOhQfPUkoPJUaEwi.Add(fqCcixihNQhPjnqFZjkjMuVDgPd, iFRqbyNUwbeoLuQrDXlfXbkASFD);
			num = 1318809440;
			goto IL_000e;
		}

		private void tvgWJJOBpvvCfaqfxRqWkvYhbyZ(int P_0)
		{
			if (wjrDQQPBkAHSOhQfPUkoPJUaEwi.ContainsKey(P_0))
			{
				wjrDQQPBkAHSOhQfPUkoPJUaEwi[P_0].xcaJhTEntwJovIWWzEiTSzKkHUZn();
				wjrDQQPBkAHSOhQfPUkoPJUaEwi.Remove(P_0);
			}
		}

		private yoBcmQfgFIKVVURwqaiPlYRIeyr GwbCklYsaWTsFVpIgEOqXevIdnt(int P_0)
		{
			yoBcmQfgFIKVVURwqaiPlYRIeyr value;
			if (!AVRtfMRpOzQlHvmKXxpZoBGaQUn.TryGetValue(P_0, out value))
			{
				return null;
			}
			return value;
		}

		private IFRqbyNUwbeoLuQrDXlfXbkASFD SBOnrGLxAirXshUJrWrzagitIcj(int P_0)
		{
			IFRqbyNUwbeoLuQrDXlfXbkASFD value;
			if (!wjrDQQPBkAHSOhQfPUkoPJUaEwi.TryGetValue(P_0, out value))
			{
				return null;
			}
			return value;
		}

		private void RBnFiOAcuOgwEAxBzxUVvXpnsEL()
		{
			while (VuTGCVdtQMXPEMCKcnDOxWAgDee.QPJOyzRQwJIkHuuLUfpXjjziKLb(yxgBxCUwUzJbzHnRoDAUopOAsnT) != 0)
			{
				while (true)
				{
					NfmPtlIZoPJGQvXSYHPwMtmiNQn.LgGCSmcGeuCwzZDqnwwFPSJjlHFB(yxgBxCUwUzJbzHnRoDAUopOAsnT);
					VuTGCVdtQMXPEMCKcnDOxWAgDee.lfyPNGQasFvqgdGyEfefHiFoUoZj hdaJmHCefHXcxpAZsILnwqxwADsE = NfmPtlIZoPJGQvXSYHPwMtmiNQn.HdaJmHCefHXcxpAZsILnwqxwADsE;
					float realTime = ReInput.realTime;
					int num = 580193156;
					while (true)
					{
						switch (num ^ 0x22950B8B)
						{
						case 13:
							num = 580193160;
							continue;
						case 7:
							zqccrwcLYXjQirOCVZQVEcKSyCP(ref NfmPtlIZoPJGQvXSYHPwMtmiNQn.gbDZaVHGrJTbfnHGTEXejaTfXMn);
							num = 580193155;
							continue;
						case 15:
							switch (hdaJmHCefHXcxpAZsILnwqxwADsE)
							{
							case VuTGCVdtQMXPEMCKcnDOxWAgDee.lfyPNGQasFvqgdGyEfefHiFoUoZj.fCmayyPjkEaEpIMtWdbxLwzNPwMe:
								break;
							default:
								goto IL_00c4;
							case VuTGCVdtQMXPEMCKcnDOxWAgDee.lfyPNGQasFvqgdGyEfefHiFoUoZj.mQiDFFkkjteaZJLsQONTgNJaGnQg:
								goto IL_00ce;
							case VuTGCVdtQMXPEMCKcnDOxWAgDee.lfyPNGQasFvqgdGyEfefHiFoUoZj.rAWIIdHPUvLtWmivWUHWMMQMbgK:
								goto IL_00e9;
							case VuTGCVdtQMXPEMCKcnDOxWAgDee.lfyPNGQasFvqgdGyEfefHiFoUoZj.TbuVwtSdLWZxmVAmTbturcyGUSN:
								goto IL_0105;
							case VuTGCVdtQMXPEMCKcnDOxWAgDee.lfyPNGQasFvqgdGyEfefHiFoUoZj.VCXEplgTAihMFNoJtcigeHizLWG:
								goto IL_0120;
							case VuTGCVdtQMXPEMCKcnDOxWAgDee.lfyPNGQasFvqgdGyEfefHiFoUoZj.kuBDDFanHCcgqdWyPtHhjdrXTsgG:
								goto IL_013b;
							case VuTGCVdtQMXPEMCKcnDOxWAgDee.lfyPNGQasFvqgdGyEfefHiFoUoZj.oudbemykwSANRsLxPqxIkKRTFHL:
							case VuTGCVdtQMXPEMCKcnDOxWAgDee.lfyPNGQasFvqgdGyEfefHiFoUoZj.SfRDQJhFLToytSbaxiRqXMDgDCw:
								goto IL_0161;
							case VuTGCVdtQMXPEMCKcnDOxWAgDee.lfyPNGQasFvqgdGyEfefHiFoUoZj.ZhDDGlYzNMJusvXNXOjqPhbRNai:
							case VuTGCVdtQMXPEMCKcnDOxWAgDee.lfyPNGQasFvqgdGyEfefHiFoUoZj.yWNLkKOMmGuFHtVHdsCyAlOwIOIe:
								goto IL_017d;
							case VuTGCVdtQMXPEMCKcnDOxWAgDee.lfyPNGQasFvqgdGyEfefHiFoUoZj.CxZSnfzeVTfRwEuiBHMPHYyjUnG:
								goto IL_01cb;
							case VuTGCVdtQMXPEMCKcnDOxWAgDee.lfyPNGQasFvqgdGyEfefHiFoUoZj.ERrgQQHtOgfDfhILjGcAXSBXKQJ:
								goto IL_01f1;
							case VuTGCVdtQMXPEMCKcnDOxWAgDee.lfyPNGQasFvqgdGyEfefHiFoUoZj.UwUFQnumtPYckGsuTEEtlficoiq:
								goto IL_020d;
							}
							goto case 7;
						case 5:
							goto IL_00ce;
						case 6:
							goto IL_00e9;
						case 9:
							goto IL_0105;
						case 4:
							goto IL_0120;
						case 10:
							goto IL_013b;
						case 2:
							num = 580193155;
							continue;
						case 1:
							goto IL_0161;
						case 11:
							goto IL_017d;
						case 3:
							break;
						case 14:
							goto IL_01cb;
						case 0:
							num = 580193155;
							continue;
						case 12:
							goto IL_01f1;
						case 16:
							goto IL_020d;
						default:
							goto end_IL_0199;
							IL_020d:
							NyBRydrzJbNCmrkiOOsekHeQWET(ref NfmPtlIZoPJGQvXSYHPwMtmiNQn.gbDZaVHGrJTbfnHGTEXejaTfXMn);
							num = 580193155;
							continue;
							IL_01f1:
							bJeVbnEeFAfekgQncogVfzTUlZZV(ref NfmPtlIZoPJGQvXSYHPwMtmiNQn.PchwTbftvWUuyTRhwzsPmtjbCbc, realTime);
							num = 580193155;
							continue;
							IL_01cb:
							fwdJEkbZKcgQUriJNLaAirBUqdX(ref NfmPtlIZoPJGQvXSYHPwMtmiNQn.tzQgxGvwJohqZXysePlCQEbYGZuF, realTime);
							num = 580193155;
							continue;
							IL_017d:
							rgKLYdmjnAhwWfhlOCbOLYumXcF(ref NfmPtlIZoPJGQvXSYHPwMtmiNQn.LNzBKIRmpERfKgJhxwDMYtahNWA, realTime);
							num = 580193163;
							continue;
							IL_0161:
							EHJCqwHkpcmslhZLsesZoVasHud(ref NfmPtlIZoPJGQvXSYHPwMtmiNQn.xguxrukkEkmMALalwLZxhtSyybQ, realTime);
							num = 580193155;
							continue;
							IL_013b:
							IfIYLNQHIMazmAXAKJUYneFKPnK(ref NfmPtlIZoPJGQvXSYHPwMtmiNQn.bzInqyUfNnsKRDBeAhAFjyZAdLE, realTime);
							num = 580193155;
							continue;
							IL_0120:
							UkZshDLPIxVnxIxJIPtdTXsDMKm(ref NfmPtlIZoPJGQvXSYHPwMtmiNQn.QsxYekDnpobgdHiLdgkoojYuJbDj);
							num = 580193155;
							continue;
							IL_0105:
							guXVAOIOcpAVCFFhcnzwuXUAuy(ref NfmPtlIZoPJGQvXSYHPwMtmiNQn.gbDZaVHGrJTbfnHGTEXejaTfXMn);
							num = 580193155;
							continue;
							IL_00e9:
							MoDoHlDNUVZfmctsKoEbhKyDIUt(ref NfmPtlIZoPJGQvXSYHPwMtmiNQn.xJfbNJDeczhcwXQwcktNqCExNWbc, realTime);
							num = 580193155;
							continue;
							IL_00ce:
							EWLFujTcQRunSRhlRiSXgtsEAik(ref NfmPtlIZoPJGQvXSYHPwMtmiNQn.QsxYekDnpobgdHiLdgkoojYuJbDj);
							num = 580193161;
							continue;
							IL_00c4:
							num = 580193155;
							continue;
						}
						break;
					}
					continue;
					end_IL_0199:
					break;
				}
			}
		}

		private void fwdJEkbZKcgQUriJNLaAirBUqdX(ref VuTGCVdtQMXPEMCKcnDOxWAgDee.hlNiUlofayujfonDNKvSEQxUAqaA P_0, float P_1)
		{
			if (!lgIWiCmutwdCNHwQPrQVIcHvAlBJ)
			{
				while (true)
				{
					switch (0x16F3AE7D ^ 0x16F3AE7C)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			hmHCmTZjCAcDnTyvpEofksGfeHp(P_0.oYcmEzsnGnDUghBvuTPDuLOoYuW, rpBMVhALAXhNbPzqodBoJUcrMls.JXmeKuWrTArDlIRBTsNQYJxBCgf, P_0.bnhbrzzOkRrUVgpkSskAvPMiScr, P_0.JHgsNLxiAQVnmyfVeWejfTJocIu, P_1);
		}

		private void rgKLYdmjnAhwWfhlOCbOLYumXcF(ref VuTGCVdtQMXPEMCKcnDOxWAgDee.NyQwZYxFMzVggiFMuMbUXPHfBTz P_0, float P_1)
		{
			if (lgIWiCmutwdCNHwQPrQVIcHvAlBJ)
			{
				hmHCmTZjCAcDnTyvpEofksGfeHp(P_0.oYcmEzsnGnDUghBvuTPDuLOoYuW, rpBMVhALAXhNbPzqodBoJUcrMls.ETpgSElJMLIOBvBRNjrxZobCcDai, P_0.BzZekZsbnMlfmEHrTheCEqNUIrf, P_0.pskeOsiRTjphpRADazjneWPcqjBH, P_1);
			}
		}

		private void IfIYLNQHIMazmAXAKJUYneFKPnK(ref VuTGCVdtQMXPEMCKcnDOxWAgDee.pVhVDzpCcjaYXuhdmcyIPDjAbLA P_0, float P_1)
		{
			if (lgIWiCmutwdCNHwQPrQVIcHvAlBJ)
			{
				hmHCmTZjCAcDnTyvpEofksGfeHp(P_0.oYcmEzsnGnDUghBvuTPDuLOoYuW, rpBMVhALAXhNbPzqodBoJUcrMls.hmgqmNjVDUfwvNLmVfpnviGBwXP, P_0.IcQqsGBRUqyiQVlMnYobATJclmS, P_0.JHgsNLxiAQVnmyfVeWejfTJocIu, P_1);
			}
		}

		private void MoDoHlDNUVZfmctsKoEbhKyDIUt(ref VuTGCVdtQMXPEMCKcnDOxWAgDee.qNCUdDSRxBRQQTpHesJUIixanMF P_0, float P_1)
		{
			bool lgIWiCmutwdCNHwQPrQVIcHvAlBJ2 = lgIWiCmutwdCNHwQPrQVIcHvAlBJ;
		}

		private void UkZshDLPIxVnxIxJIPtdTXsDMKm(ref VuTGCVdtQMXPEMCKcnDOxWAgDee.kANpKLhGKskiOtFeLCCamlEzZnT P_0)
		{
			if (!lgIWiCmutwdCNHwQPrQVIcHvAlBJ)
			{
				return;
			}
			while (true)
			{
				LQGxclUaisClvyzkifGfZFVUDUD(P_0.oYcmEzsnGnDUghBvuTPDuLOoYuW);
				if (kNXIQEVSsDEgVkqFLLuKGNvojTr == null)
				{
					break;
				}
				kNXIQEVSsDEgVkqFLLuKGNvojTr();
				int num = -1630278816;
				while (true)
				{
					switch (num ^ -1630278814)
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
					num = -1630278813;
				}
			}
		}

		private void EWLFujTcQRunSRhlRiSXgtsEAik(ref VuTGCVdtQMXPEMCKcnDOxWAgDee.kANpKLhGKskiOtFeLCCamlEzZnT P_0)
		{
			if (!lgIWiCmutwdCNHwQPrQVIcHvAlBJ)
			{
				return;
			}
			while (true)
			{
				zwbHitsqiXGFqJjlZgUaENxJxbF(P_0.oYcmEzsnGnDUghBvuTPDuLOoYuW);
				int num = -890015841;
				while (true)
				{
					switch (num ^ -890015843)
					{
					case 3:
						num = -890015844;
						continue;
					default:
						return;
					case 1:
						break;
					case 2:
						if (kNXIQEVSsDEgVkqFLLuKGNvojTr != null)
						{
							kNXIQEVSsDEgVkqFLLuKGNvojTr();
							num = -890015843;
							continue;
						}
						return;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private void bJeVbnEeFAfekgQncogVfzTUlZZV(ref VuTGCVdtQMXPEMCKcnDOxWAgDee.FWoapwItDWNEWPVPidmglJJQwdV P_0, float P_1)
		{
			if (!iGnxYwRWiTPdScoiohDdqoEntM)
			{
				return;
			}
			while (true)
			{
				byte bnhbrzzOkRrUVgpkSskAvPMiScr = P_0.bnhbrzzOkRrUVgpkSskAvPMiScr;
				if (bnhbrzzOkRrUVgpkSskAvPMiScr == 6)
				{
					break;
				}
				kPjaQYCOQnfRUVrkCOmtKPDlzUh(P_0.oYcmEzsnGnDUghBvuTPDuLOoYuW, rpBMVhALAXhNbPzqodBoJUcrMls.JXmeKuWrTArDlIRBTsNQYJxBCgf, P_0.bnhbrzzOkRrUVgpkSskAvPMiScr, P_0.JHgsNLxiAQVnmyfVeWejfTJocIu, P_1);
				int num = 1374606716;
				while (true)
				{
					switch (num ^ 0x51EED57E)
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
					num = 1374606719;
				}
			}
		}

		private void EHJCqwHkpcmslhZLsesZoVasHud(ref VuTGCVdtQMXPEMCKcnDOxWAgDee.AmbscaePGugqpuYtyZfMPcSiJkU P_0, float P_1)
		{
			if (!iGnxYwRWiTPdScoiohDdqoEntM)
			{
				return;
			}
			while (true)
			{
				byte bzZekZsbnMlfmEHrTheCEqNUIrf = P_0.BzZekZsbnMlfmEHrTheCEqNUIrf;
				if (bzZekZsbnMlfmEHrTheCEqNUIrf == 15)
				{
					break;
				}
				kPjaQYCOQnfRUVrkCOmtKPDlzUh(P_0.oYcmEzsnGnDUghBvuTPDuLOoYuW, rpBMVhALAXhNbPzqodBoJUcrMls.ETpgSElJMLIOBvBRNjrxZobCcDai, P_0.BzZekZsbnMlfmEHrTheCEqNUIrf, P_0.pskeOsiRTjphpRADazjneWPcqjBH, P_1);
				int num = -740478117;
				while (true)
				{
					switch (num ^ -740478118)
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
					num = -740478120;
				}
			}
		}

		private void zqccrwcLYXjQirOCVZQVEcKSyCP(ref VuTGCVdtQMXPEMCKcnDOxWAgDee.PaVFGxMdMiCXJpsEONmGULxvpUw P_0)
		{
			if (!iGnxYwRWiTPdScoiohDdqoEntM)
			{
				return;
			}
			while (true)
			{
				RNMyjAFMDERbhOfQKYAiIdXsfeC(P_0.oYcmEzsnGnDUghBvuTPDuLOoYuW);
				int num = -1191109245;
				while (true)
				{
					switch (num ^ -1191109246)
					{
					case 3:
						num = -1191109248;
						continue;
					default:
						return;
					case 2:
						break;
					case 1:
						if (kNXIQEVSsDEgVkqFLLuKGNvojTr != null)
						{
							kNXIQEVSsDEgVkqFLLuKGNvojTr();
							num = -1191109246;
							continue;
						}
						return;
					case 0:
						return;
					}
					break;
				}
			}
		}

		private void NyBRydrzJbNCmrkiOOsekHeQWET(ref VuTGCVdtQMXPEMCKcnDOxWAgDee.PaVFGxMdMiCXJpsEONmGULxvpUw P_0)
		{
			if (!iGnxYwRWiTPdScoiohDdqoEntM)
			{
				return;
			}
			while (true)
			{
				tvgWJJOBpvvCfaqfxRqWkvYhbyZ(P_0.oYcmEzsnGnDUghBvuTPDuLOoYuW);
				int num = 346132031;
				while (true)
				{
					switch (num ^ 0x14A18E3D)
					{
					case 0:
						num = 346132030;
						continue;
					default:
						return;
					case 3:
						break;
					case 2:
						if (kNXIQEVSsDEgVkqFLLuKGNvojTr != null)
						{
							kNXIQEVSsDEgVkqFLLuKGNvojTr();
							num = 346132028;
							continue;
						}
						return;
					case 1:
						return;
					}
					break;
				}
			}
		}

		private void guXVAOIOcpAVCFFhcnzwuXUAuy(ref VuTGCVdtQMXPEMCKcnDOxWAgDee.PaVFGxMdMiCXJpsEONmGULxvpUw P_0)
		{
			bool iGnxYwRWiTPdScoiohDdqoEntM2 = iGnxYwRWiTPdScoiohDdqoEntM;
		}

		private void hmHCmTZjCAcDnTyvpEofksGfeHp(int P_0, rpBMVhALAXhNbPzqodBoJUcrMls P_1, byte P_2, short P_3, float P_4)
		{
			yoBcmQfgFIKVVURwqaiPlYRIeyr yoBcmQfgFIKVVURwqaiPlYRIeyr2 = GwbCklYsaWTsFVpIgEOqXevIdnt(P_0);
			if (yoBcmQfgFIKVVURwqaiPlYRIeyr2 != null)
			{
				yoBcmQfgFIKVVURwqaiPlYRIeyr2.MPPQJfVkqEnvckKDMacDSmlvhjwB(P_1, P_2, P_3, P_4);
			}
		}

		private void kPjaQYCOQnfRUVrkCOmtKPDlzUh(int P_0, rpBMVhALAXhNbPzqodBoJUcrMls P_1, byte P_2, short P_3, float P_4)
		{
			IFRqbyNUwbeoLuQrDXlfXbkASFD iFRqbyNUwbeoLuQrDXlfXbkASFD = SBOnrGLxAirXshUJrWrzagitIcj(P_0);
			while (true)
			{
				switch (-1645399001 ^ -1645399002)
				{
				case 2:
					continue;
				case 1:
					if (iFRqbyNUwbeoLuQrDXlfXbkASFD == null)
					{
						return;
					}
					break;
				}
				break;
			}
			iFRqbyNUwbeoLuQrDXlfXbkASFD.MPPQJfVkqEnvckKDMacDSmlvhjwB(P_1, P_2, P_3, P_4);
		}

		private void QqNfMxZkzRUOhLhdiVGGPCKVJml()
		{
			string[] array = BhwMyedFetpuGXyyislRFDBWLNY.ugMaQOBnUyKVnwYfolrychazhdbw();
			int num2 = default(int);
			while (true)
			{
				int num = 1824456373;
				while (true)
				{
					switch (num ^ 0x6CBEFEB4)
					{
					case 2:
						break;
					case 3:
					{
						int num3;
						if (!string.IsNullOrEmpty(array[num2]))
						{
							num = 1824456370;
							num3 = num;
						}
						else
						{
							num = 1824456369;
							num3 = num;
						}
						continue;
					}
					case 5:
						num2++;
						num = 1824456372;
						continue;
					case 1:
						if (array == null)
						{
							return;
						}
						goto case 4;
					case 4:
						num2 = 0;
						num = 1824456372;
						continue;
					case 6:
						if (array[num2].Length > 32 && !(VuTGCVdtQMXPEMCKcnDOxWAgDee.NMBdaPsiPidzNBcIhdmLzmHZZgMF(new Guid(array[num2].Substring(0, 32))) != string.Empty))
						{
							VuTGCVdtQMXPEMCKcnDOxWAgDee.ydtAHfHDkTOSzPsnhREVpbPGkdSL(array[num2]);
							num = 1824456369;
							continue;
						}
						goto case 5;
					default:
						if (num2 >= array.Length)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			while (true)
			{
				int num = -977361729;
				while (true)
				{
					switch (num ^ -977361731)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0025;
					case 1:
						return;
					}
					break;
					IL_0025:
					GC.SuppressFinalize(this);
					num = -977361732;
				}
			}
		}

		~SDL2InputSource()
		{
			Dispose(false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (vsurYtRlepcrpAzAENwjqjJEZPT)
			{
				return;
			}
			while (true)
			{
				IL_0056:
				if (!disposing)
				{
					goto IL_002f;
				}
				int num;
				if (yxgBxCUwUzJbzHnRoDAUopOAsnT != null)
				{
					yxgBxCUwUzJbzHnRoDAUopOAsnT.Dispose();
					num = 130462612;
					goto IL_000e;
				}
				goto IL_0049;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x7C6B396)
					{
					case 3:
						num = 130462615;
						continue;
					default:
						return;
					case 0:
						break;
					case 2:
						goto IL_0049;
					case 1:
						goto IL_0056;
					case 4:
						return;
					}
					break;
				}
				goto IL_002f;
				IL_0049:
				yWfWtSpcgNVVbPBMXhhbWKBJfmj();
				num = 130462614;
				goto IL_000e;
				IL_002f:
				VuTGCVdtQMXPEMCKcnDOxWAgDee.kISSXpipDJvdnJzrGeNFIJpEaPM();
				PkVqugVNIpoYIMpSDcpjdJRrnVs = false;
				vsurYtRlepcrpAzAENwjqjJEZPT = true;
				num = 130462610;
				goto IL_000e;
			}
		}
	}
}
