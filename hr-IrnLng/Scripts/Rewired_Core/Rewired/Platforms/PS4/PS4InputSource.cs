using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Interfaces;
using Rewired.Platforms.Custom;
using Rewired.Platforms.PS4.Internal;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Platforms.PS4
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class PS4InputSource : CustomInputSource, IControllerAssigner
	{
		private class TEZCTvrddMjRUCOnElLhaEKNInfL
		{
			public struct gjLNOGYBQDbejkzWFpeJHHxspjiX
			{
				public int KcihJPqCzQKLaiJAuOEZocqkGuT;

				public int qhxbfYcEshLHnIYUOREjSbHwqfQ;

				public int BNMfzqorwyKNLmzLFOEIJJOnOHB;

				public YPEmCTKgOQXHKMuRGCMfSJbLXza.BaseControllerType VkiJVBFFvYWMkVGWArBZaTZCJAe;

				public gjLNOGYBQDbejkzWFpeJHHxspjiX(int playerId, int handle, int deviceClass, YPEmCTKgOQXHKMuRGCMfSJbLXza.BaseControllerType baseControllerType)
				{
					KcihJPqCzQKLaiJAuOEZocqkGuT = playerId;
					qhxbfYcEshLHnIYUOREjSbHwqfQ = handle;
					BNMfzqorwyKNLmzLFOEIJJOnOHB = deviceClass;
					VkiJVBFFvYWMkVGWArBZaTZCJAe = baseControllerType;
				}
			}

			public struct PkXjhsHsbhCsRDdxYKTRnWlvcEA
			{
				public int KcihJPqCzQKLaiJAuOEZocqkGuT;

				public int qhxbfYcEshLHnIYUOREjSbHwqfQ;

				public YPEmCTKgOQXHKMuRGCMfSJbLXza.BaseControllerType VkiJVBFFvYWMkVGWArBZaTZCJAe;

				public PkXjhsHsbhCsRDdxYKTRnWlvcEA(int playerId, int handle, YPEmCTKgOQXHKMuRGCMfSJbLXza.BaseControllerType baseControllerType)
				{
					KcihJPqCzQKLaiJAuOEZocqkGuT = playerId;
					qhxbfYcEshLHnIYUOREjSbHwqfQ = handle;
					VkiJVBFFvYWMkVGWArBZaTZCJAe = baseControllerType;
				}
			}

			private class kAHmDqtukfxxTxsJYNlCYIfCFDI
			{
				public readonly YPEmCTKgOQXHKMuRGCMfSJbLXza.BaseControllerType VkiJVBFFvYWMkVGWArBZaTZCJAe;

				public bool ZeteYfFQxhKQTATZXPjVisRRwhL;

				public int qhxbfYcEshLHnIYUOREjSbHwqfQ;

				public int BNMfzqorwyKNLmzLFOEIJJOnOHB;

				public kAHmDqtukfxxTxsJYNlCYIfCFDI(YPEmCTKgOQXHKMuRGCMfSJbLXza.BaseControllerType baseControllerType)
				{
					VkiJVBFFvYWMkVGWArBZaTZCJAe = baseControllerType;
					VcHhfbFqwxAmqhwBHKVJpDjlfufe();
				}

				public ChangeType gWhNFfKJksvYGKBwFgLngVyKgFw(bool P_0, int P_1, int P_2)
				{
					ChangeType changeType = ChangeType.None;
					if (ZeteYfFQxhKQTATZXPjVisRRwhL != P_0)
					{
						ZeteYfFQxhKQTATZXPjVisRRwhL = P_0;
						changeType = (ChangeType)((int)changeType | (P_0 ? 1 : 2));
						if (P_0)
						{
							qhxbfYcEshLHnIYUOREjSbHwqfQ = P_1;
							BNMfzqorwyKNLmzLFOEIJJOnOHB = P_2;
							return changeType;
						}
						VcHhfbFqwxAmqhwBHKVJpDjlfufe();
						return changeType;
					}
					if (qhxbfYcEshLHnIYUOREjSbHwqfQ != P_1)
					{
						qhxbfYcEshLHnIYUOREjSbHwqfQ = P_1;
						changeType |= ChangeType.IdentityChanged;
					}
					if (BNMfzqorwyKNLmzLFOEIJJOnOHB != P_2)
					{
						BNMfzqorwyKNLmzLFOEIJJOnOHB = P_2;
						changeType |= ChangeType.IdentityChanged;
					}
					return changeType;
				}

				private void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
				{
					ZeteYfFQxhKQTATZXPjVisRRwhL = false;
					qhxbfYcEshLHnIYUOREjSbHwqfQ = -1;
					BNMfzqorwyKNLmzLFOEIJJOnOHB = -1;
				}
			}

			[Flags]
			[CustomObfuscation(rename = false)]
			private enum ChangeType
			{
				[CustomObfuscation(rename = false)]
				None = 0,
				[CustomObfuscation(rename = false)]
				Connected = 1,
				[CustomObfuscation(rename = false)]
				Disconnected = 2,
				[CustomObfuscation(rename = false)]
				IdentityChanged = 4
			}

			private readonly int JaSaIqfuxGiVdQbtQmEHQeBxJYC;

			private readonly int[] ylLGTqAzztPjVowhOJszTFNbFfY;

			private readonly int[] EUEpaMeJPMWZrLwAcNfNfFEnThn;

			private readonly int[] AksfypmjGzFKVkzLpeHFpYZhBYoI;

			private readonly IExternalTools RMaapQeVnyNDkTiNBhoJXDxGFKK;

			private readonly kAHmDqtukfxxTxsJYNlCYIfCFDI[] kaODowBUWfiDpiPfIoFPvEcRweMb;

			private readonly kAHmDqtukfxxTxsJYNlCYIfCFDI[] MUQrfazpTigGoTusCpGObTQwfW;

			private readonly kAHmDqtukfxxTxsJYNlCYIfCFDI[] pbcMNTNhXLUHayRqmCWGbfMsrnJd;

			private readonly List<gjLNOGYBQDbejkzWFpeJHHxspjiX> ELyCQFyZeJSZnkBGiPMxXHMQnyt;

			private readonly List<PkXjhsHsbhCsRDdxYKTRnWlvcEA> pcfpMDRbCBGdDoaVUHiPkuwXspc;

			private Action<gjLNOGYBQDbejkzWFpeJHHxspjiX> WEyKCvYvgqEVUCECLWuXDXWhbqN;

			private Action<PkXjhsHsbhCsRDdxYKTRnWlvcEA> xJqUgLuTAVuPBZCeCiifdhgTGQlH;

			[CompilerGenerated]
			private static Func<kAHmDqtukfxxTxsJYNlCYIfCFDI> sPMAcpellUZLaqoZiORhMgRZWDu;

			[CompilerGenerated]
			private static Func<kAHmDqtukfxxTxsJYNlCYIfCFDI> ZyemrtlocPgopITzwWGmeAtLePxI;

			[CompilerGenerated]
			private static Func<kAHmDqtukfxxTxsJYNlCYIfCFDI> fqbZuOCzaGEtjRCXGpKkmkLnbRtb;

			public event Action<gjLNOGYBQDbejkzWFpeJHHxspjiX> ControllerConnectedEvent
			{
				add
				{
					Action<gjLNOGYBQDbejkzWFpeJHHxspjiX> action = WEyKCvYvgqEVUCECLWuXDXWhbqN;
					Action<gjLNOGYBQDbejkzWFpeJHHxspjiX> action2;
					do
					{
						action2 = action;
						Action<gjLNOGYBQDbejkzWFpeJHHxspjiX> value2 = (Action<gjLNOGYBQDbejkzWFpeJHHxspjiX>)Delegate.Combine(action2, value);
						action = Interlocked.CompareExchange(ref WEyKCvYvgqEVUCECLWuXDXWhbqN, value2, action2);
					}
					while ((object)action != action2);
				}
				remove
				{
					Action<gjLNOGYBQDbejkzWFpeJHHxspjiX> action = WEyKCvYvgqEVUCECLWuXDXWhbqN;
					Action<gjLNOGYBQDbejkzWFpeJHHxspjiX> action2;
					do
					{
						action2 = action;
						Action<gjLNOGYBQDbejkzWFpeJHHxspjiX> value2 = (Action<gjLNOGYBQDbejkzWFpeJHHxspjiX>)Delegate.Remove(action2, value);
						action = Interlocked.CompareExchange(ref WEyKCvYvgqEVUCECLWuXDXWhbqN, value2, action2);
					}
					while ((object)action != action2);
				}
			}

			public event Action<PkXjhsHsbhCsRDdxYKTRnWlvcEA> ControllerDisconnectedEvent
			{
				add
				{
					Action<PkXjhsHsbhCsRDdxYKTRnWlvcEA> action = xJqUgLuTAVuPBZCeCiifdhgTGQlH;
					Action<PkXjhsHsbhCsRDdxYKTRnWlvcEA> action2;
					do
					{
						action2 = action;
						Action<PkXjhsHsbhCsRDdxYKTRnWlvcEA> value2 = (Action<PkXjhsHsbhCsRDdxYKTRnWlvcEA>)Delegate.Combine(action2, value);
						action = Interlocked.CompareExchange(ref xJqUgLuTAVuPBZCeCiifdhgTGQlH, value2, action2);
					}
					while ((object)action != action2);
				}
				remove
				{
					Action<PkXjhsHsbhCsRDdxYKTRnWlvcEA> action = xJqUgLuTAVuPBZCeCiifdhgTGQlH;
					Action<PkXjhsHsbhCsRDdxYKTRnWlvcEA> action2;
					do
					{
						action2 = action;
						Action<PkXjhsHsbhCsRDdxYKTRnWlvcEA> value2 = (Action<PkXjhsHsbhCsRDdxYKTRnWlvcEA>)Delegate.Remove(action2, value);
						action = Interlocked.CompareExchange(ref xJqUgLuTAVuPBZCeCiifdhgTGQlH, value2, action2);
					}
					while ((object)action != action2);
				}
			}

			public TEZCTvrddMjRUCOnElLhaEKNInfL(int maxPlayers)
			{
				JaSaIqfuxGiVdQbtQmEHQeBxJYC = maxPlayers;
				ylLGTqAzztPjVowhOJszTFNbFfY = new int[maxPlayers];
				EUEpaMeJPMWZrLwAcNfNfFEnThn = new int[maxPlayers];
				AksfypmjGzFKVkzLpeHFpYZhBYoI = new int[maxPlayers];
				RMaapQeVnyNDkTiNBhoJXDxGFKK = UnityTools.externalTools;
				kaODowBUWfiDpiPfIoFPvEcRweMb = new kAHmDqtukfxxTxsJYNlCYIfCFDI[maxPlayers];
				ArrayTools.Populate(kaODowBUWfiDpiPfIoFPvEcRweMb, () => new kAHmDqtukfxxTxsJYNlCYIfCFDI(YPEmCTKgOQXHKMuRGCMfSJbLXza.BaseControllerType.Gamepad));
				MUQrfazpTigGoTusCpGObTQwfW = new kAHmDqtukfxxTxsJYNlCYIfCFDI[maxPlayers];
				ArrayTools.Populate(MUQrfazpTigGoTusCpGObTQwfW, () => new kAHmDqtukfxxTxsJYNlCYIfCFDI(YPEmCTKgOQXHKMuRGCMfSJbLXza.BaseControllerType.Special));
				pbcMNTNhXLUHayRqmCWGbfMsrnJd = new kAHmDqtukfxxTxsJYNlCYIfCFDI[maxPlayers];
				ArrayTools.Populate(pbcMNTNhXLUHayRqmCWGbfMsrnJd, () => new kAHmDqtukfxxTxsJYNlCYIfCFDI(YPEmCTKgOQXHKMuRGCMfSJbLXza.BaseControllerType.Aim));
				ELyCQFyZeJSZnkBGiPMxXHMQnyt = new List<gjLNOGYBQDbejkzWFpeJHHxspjiX>(2);
				pcfpMDRbCBGdDoaVUHiPkuwXspc = new List<PkXjhsHsbhCsRDdxYKTRnWlvcEA>(2);
			}

			public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA()
			{
				RMaapQeVnyNDkTiNBhoJXDxGFKK.PS4Input_PadGetUsersHandles2(JaSaIqfuxGiVdQbtQmEHQeBxJYC, ylLGTqAzztPjVowhOJszTFNbFfY);
				RMaapQeVnyNDkTiNBhoJXDxGFKK.PS4Input_SpecialGetUsersHandles2(JaSaIqfuxGiVdQbtQmEHQeBxJYC, EUEpaMeJPMWZrLwAcNfNfFEnThn);
				RMaapQeVnyNDkTiNBhoJXDxGFKK.PS4Input_AimGetUsersHandles2(JaSaIqfuxGiVdQbtQmEHQeBxJYC, AksfypmjGzFKVkzLpeHFpYZhBYoI);
				for (int i = 0; i < JaSaIqfuxGiVdQbtQmEHQeBxJYC; i++)
				{
					try
					{
						kAHmDqtukfxxTxsJYNlCYIfCFDI kAHmDqtukfxxTxsJYNlCYIfCFDI2 = kaODowBUWfiDpiPfIoFPvEcRweMb[i];
						bool flag = RMaapQeVnyNDkTiNBhoJXDxGFKK.PS4Input_PadIsConnected(i);
						if (kAHmDqtukfxxTxsJYNlCYIfCFDI2.ZeteYfFQxhKQTATZXPjVisRRwhL || flag)
						{
							qKgqSZDIeoRNjFDpLEuWcYBSGlYk(i, kAHmDqtukfxxTxsJYNlCYIfCFDI2, ylLGTqAzztPjVowhOJszTFNbFfY[i], flag, "Gamepad");
						}
						kAHmDqtukfxxTxsJYNlCYIfCFDI kAHmDqtukfxxTxsJYNlCYIfCFDI3 = MUQrfazpTigGoTusCpGObTQwfW[i];
						bool flag2 = RMaapQeVnyNDkTiNBhoJXDxGFKK.PS4Input_SpecialIsConnected(i);
						if (kAHmDqtukfxxTxsJYNlCYIfCFDI3.ZeteYfFQxhKQTATZXPjVisRRwhL || flag2)
						{
							qKgqSZDIeoRNjFDpLEuWcYBSGlYk(i, kAHmDqtukfxxTxsJYNlCYIfCFDI3, EUEpaMeJPMWZrLwAcNfNfFEnThn[i], flag2, "Special");
						}
						kAHmDqtukfxxTxsJYNlCYIfCFDI kAHmDqtukfxxTxsJYNlCYIfCFDI4 = pbcMNTNhXLUHayRqmCWGbfMsrnJd[i];
						bool flag3 = RMaapQeVnyNDkTiNBhoJXDxGFKK.PS4Input_AimIsConnected(i);
						if (kAHmDqtukfxxTxsJYNlCYIfCFDI4.ZeteYfFQxhKQTATZXPjVisRRwhL || flag3)
						{
							qKgqSZDIeoRNjFDpLEuWcYBSGlYk(i, kAHmDqtukfxxTxsJYNlCYIfCFDI4, AksfypmjGzFKVkzLpeHFpYZhBYoI[i], flag3, "Aim");
						}
						if (pcfpMDRbCBGdDoaVUHiPkuwXspc.Count > 0)
						{
							for (int j = 0; j < pcfpMDRbCBGdDoaVUHiPkuwXspc.Count; j++)
							{
								try
								{
									xJqUgLuTAVuPBZCeCiifdhgTGQlH(pcfpMDRbCBGdDoaVUHiPkuwXspc[j]);
								}
								catch (Exception ex)
								{
									Logger.LogError("An exception occurred in controller monitor Controller Disconnect Event callback.\n" + ex);
								}
							}
							pcfpMDRbCBGdDoaVUHiPkuwXspc.Clear();
						}
						if (ELyCQFyZeJSZnkBGiPMxXHMQnyt.Count <= 0)
						{
							continue;
						}
						for (int k = 0; k < ELyCQFyZeJSZnkBGiPMxXHMQnyt.Count; k++)
						{
							try
							{
								WEyKCvYvgqEVUCECLWuXDXWhbqN(ELyCQFyZeJSZnkBGiPMxXHMQnyt[k]);
							}
							catch (Exception ex2)
							{
								Logger.LogError("An exception occurred in controller monitor Controller Connect Event callback.\n" + ex2);
							}
						}
						ELyCQFyZeJSZnkBGiPMxXHMQnyt.Clear();
					}
					catch (Exception ex3)
					{
						Logger.LogError("An exception occurred during controller monitor update.\n" + ex3);
					}
				}
			}

			private void qKgqSZDIeoRNjFDpLEuWcYBSGlYk(int P_0, kAHmDqtukfxxTxsJYNlCYIfCFDI P_1, int P_2, bool P_3, string P_4)
			{
				int num = RMaapQeVnyNDkTiNBhoJXDxGFKK.PS4Input_GetDeviceClassForHandle(P_2);
				int qhxbfYcEshLHnIYUOREjSbHwqfQ = P_1.qhxbfYcEshLHnIYUOREjSbHwqfQ;
				ChangeType changeType = P_1.gWhNFfKJksvYGKBwFgLngVyKgFw(P_3, P_2, num);
				if (changeType != ChangeType.None)
				{
					if ((changeType & ChangeType.Disconnected) != ChangeType.None || (P_1.ZeteYfFQxhKQTATZXPjVisRRwhL && (changeType & ChangeType.IdentityChanged) != ChangeType.None))
					{
						pcfpMDRbCBGdDoaVUHiPkuwXspc.Add(new PkXjhsHsbhCsRDdxYKTRnWlvcEA(P_0, qhxbfYcEshLHnIYUOREjSbHwqfQ, P_1.VkiJVBFFvYWMkVGWArBZaTZCJAe));
					}
					if ((changeType & ChangeType.Connected) != ChangeType.None || (P_1.ZeteYfFQxhKQTATZXPjVisRRwhL && (changeType & ChangeType.IdentityChanged) != ChangeType.None))
					{
						ELyCQFyZeJSZnkBGiPMxXHMQnyt.Add(new gjLNOGYBQDbejkzWFpeJHHxspjiX(P_0, P_1.qhxbfYcEshLHnIYUOREjSbHwqfQ, P_1.BNMfzqorwyKNLmzLFOEIJJOnOHB, P_1.VkiJVBFFvYWMkVGWArBZaTZCJAe));
					}
				}
			}

			[CompilerGenerated]
			private static kAHmDqtukfxxTxsJYNlCYIfCFDI XfINNKEmUKzSsCzPHajDXqTnGNY()
			{
				return new kAHmDqtukfxxTxsJYNlCYIfCFDI(YPEmCTKgOQXHKMuRGCMfSJbLXza.BaseControllerType.Gamepad);
			}

			[CompilerGenerated]
			private static kAHmDqtukfxxTxsJYNlCYIfCFDI NqdcTKpAdLRalzDgqnwzkSilbEj()
			{
				return new kAHmDqtukfxxTxsJYNlCYIfCFDI(YPEmCTKgOQXHKMuRGCMfSJbLXza.BaseControllerType.Special);
			}

			[CompilerGenerated]
			private static kAHmDqtukfxxTxsJYNlCYIfCFDI qsNfcdCmDdxXmRWNuNAqiBfXDuaT()
			{
				return new kAHmDqtukfxxTxsJYNlCYIfCFDI(YPEmCTKgOQXHKMuRGCMfSJbLXza.BaseControllerType.Aim);
			}
		}

		private abstract class YPEmCTKgOQXHKMuRGCMfSJbLXza : Joystick, mvpKKVIFRgOLaSdVrHeNqVnjxUt, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource
		{
			[CustomObfuscation(rename = false)]
			public enum ControllerType
			{
				[CustomObfuscation(rename = false)]
				Unknown = 0,
				[CustomObfuscation(rename = false)]
				Gamepad = 1,
				[CustomObfuscation(rename = false)]
				Aim = 2,
				[CustomObfuscation(rename = false)]
				Guitar = 3,
				[CustomObfuscation(rename = false)]
				Drum = 4,
				[CustomObfuscation(rename = false)]
				DjTurntable = 5,
				[CustomObfuscation(rename = false)]
				DanceMat = 6,
				[CustomObfuscation(rename = false)]
				Navigation = 7,
				[CustomObfuscation(rename = false)]
				SteeringWheel = 8,
				[CustomObfuscation(rename = false)]
				Stick = 9,
				[CustomObfuscation(rename = false)]
				FlightStick = 10,
				[CustomObfuscation(rename = false)]
				Gun = 11
			}

			protected enum SjdsSTcRDUQgQDWXLKMUdSeMIts
			{
				aXQImphWLsNyAXlPBncGlpmgAAN = 0,
				jDiKKaMKTNBaEqSTBFANDIppQZii = 1,
				XpEzisrKaJHeXDzLgcJbqgJeFaNS = 2
			}

			[CustomObfuscation(rename = false)]
			public enum BaseControllerType
			{
				[CustomObfuscation(rename = false)]
				Gamepad = 0,
				[CustomObfuscation(rename = false)]
				Special = 1,
				[CustomObfuscation(rename = false)]
				Aim = 2
			}

			public class PQVbyPgmdcPbZFTfAQVdAYUFRNxE
			{
				public readonly int rGEuFEtJcMmFaLOCcsmbRHUjSpy;

				public readonly int qrXpdbCUzFLCBfjCDTfPHyJCus;

				public readonly float pPKwinMTfdcbZTkXdNkwrDLZYuL;

				public readonly int HSFfOkgYdavTAaqGDaWBzgNaSgu;

				public readonly int bGGYDEAvAuLfFYijCTyxEiSidnY;

				public PQVbyPgmdcPbZFTfAQVdAYUFRNxE(int axisCount, int buttonCount, float dpadDeadzone, int vibrationMotorCount, int maxTouches)
				{
					rGEuFEtJcMmFaLOCcsmbRHUjSpy = axisCount;
					qrXpdbCUzFLCBfjCDTfPHyJCus = buttonCount;
					pPKwinMTfdcbZTkXdNkwrDLZYuL = dpadDeadzone;
					HSFfOkgYdavTAaqGDaWBzgNaSgu = vibrationMotorCount;
					bGGYDEAvAuLfFYijCTyxEiSidnY = maxTouches;
				}
			}

			private static int YPVVIZUvGzxTFwAvpOAspELEAlU;

			protected readonly int EpFfrTuakcvBKacoggaztTmGfrG;

			protected readonly int mzqkVThBwmgkAAynVwhyJsGZQGbf;

			protected readonly BaseControllerType dccAdtAPWezaBevCoaUEkERWluh;

			protected readonly PQVbyPgmdcPbZFTfAQVdAYUFRNxE oVAysyflicCsfbwqntSlbYXfmydd;

			protected readonly int dCZEgzobTpHayGZtxUSftmjRvGe;

			protected readonly float[] IkTnbMskRbowWbxWPedRECvPKXw;

			private readonly LoggedInUser jGdbSRsCJtwyBdRYiStVwDlRQKd;

			protected readonly ControllerType AkkykLRVUWzqzDOfDtdSigYijIy;

			private readonly Func<int, bool> yapCVOfqvNpItdbGJOOdGIPMgwg;

			private readonly Action<int, int, int> VkHkrSRAXfFwZCiddhDOKCCETJo;

			private readonly Action<int, int, int, int> OHxGcIEBKFBMUdamgEhKdEkmmtr;

			private readonly Action<int> OuxnbrSsGPdiIxMfbKWfRshDohk;

			private Action<int, bool> hsEoMDiJZlSuqHwxydZDHSKXlsz;

			private Action<int, bool> zWBXyAkTdKygEmNnodbDAUkqGpG;

			private Action<int, bool> FxGiFbndaijHWcpFxQrVyOLsYCWV;

			private Action<int> CDCxtdwgbjEaHHJiWQmHRMJtuYd;

			private Func<int, Vector3> ugrQHtwforCyxOeIjgXfeNMzZmlB;

			private Func<int, Vector3> sZcRVrlrvPrwCHpmGnVZUxLSozZ;

			private Func<int, Vector4> OXdckGbUiwnHyFZfeHXaPVpIfwlW;

			private static int NextSystemId
			{
				get
				{
					int yPVVIZUvGzxTFwAvpOAspELEAlU = YPVVIZUvGzxTFwAvpOAspELEAlU;
					YPVVIZUvGzxTFwAvpOAspELEAlU++;
					return yPVVIZUvGzxTFwAvpOAspELEAlU;
				}
			}

			protected LoggedInUser user
			{
				get
				{
					UnityTools.externalTools.PS4Input_GetUsersDetails(EpFfrTuakcvBKacoggaztTmGfrG, jGdbSRsCJtwyBdRYiStVwDlRQKd);
					return jGdbSRsCJtwyBdRYiStVwDlRQKd;
				}
			}

			public ControllerType type => AkkykLRVUWzqzDOfDtdSigYijIy;

			public int playerId => EpFfrTuakcvBKacoggaztTmGfrG;

			public int handle => mzqkVThBwmgkAAynVwhyJsGZQGbf;

			public BaseControllerType baseControllerType => dccAdtAPWezaBevCoaUEkERWluh;

			private bool IsConnectedNow => yapCVOfqvNpItdbGJOOdGIPMgwg(EpFfrTuakcvBKacoggaztTmGfrG);

			public int vibrationMotorCount => oVAysyflicCsfbwqntSlbYXfmydd.HSFfOkgYdavTAaqGDaWBzgNaSgu;

			public static YPEmCTKgOQXHKMuRGCMfSJbLXza ikoBGVHHLVNnLaVaWGffMETVhTJw(ControllerType P_0, int P_1, int P_2, int P_3)
			{
				return P_0 switch
				{
					ControllerType.Unknown => null, 
					ControllerType.Gamepad => new NyXaqAJEajJbjWEXybQrMSMhOqDG("Controller " + (P_2 + 1), P_2, P_2 + 1, P_3), 
					ControllerType.Aim => new zBpXOJGqVtlfWqqvjVlUnsXickW("PS VR Aim Controller " + (P_2 + 1), P_2, P_2 + 13, P_3), 
					_ => oYXtzgNZhRXSYGdTqDyOIDXgwaI.ikoBGVHHLVNnLaVaWGffMETVhTJw(P_1, P_2, P_3), 
				};
			}

			protected YPEmCTKgOQXHKMuRGCMfSJbLXza(ControllerType type, BaseControllerType baseControllerType, string name, int playerId, int unityJoystickId, int handle, PQVbyPgmdcPbZFTfAQVdAYUFRNxE capabilities)
				: base(name, NextSystemId, unityJoystickId, capabilities.rGEuFEtJcMmFaLOCcsmbRHUjSpy, capabilities.qrXpdbCUzFLCBfjCDTfPHyJCus)
			{
				if (capabilities == null)
				{
					throw new ArgumentNullException("capabilities");
				}
				AkkykLRVUWzqzDOfDtdSigYijIy = type;
				dccAdtAPWezaBevCoaUEkERWluh = baseControllerType;
				EpFfrTuakcvBKacoggaztTmGfrG = playerId;
				dCZEgzobTpHayGZtxUSftmjRvGe = unityJoystickId - 1;
				oVAysyflicCsfbwqntSlbYXfmydd = capabilities;
				mzqkVThBwmgkAAynVwhyJsGZQGbf = handle;
				jGdbSRsCJtwyBdRYiStVwDlRQKd = new LoggedInUser();
				_customName = name;
				IkTnbMskRbowWbxWPedRECvPKXw = new float[capabilities.HSFfOkgYdavTAaqGDaWBzgNaSgu];
				base.supportsVibration = capabilities.HSFfOkgYdavTAaqGDaWBzgNaSgu > 0;
				switch (dccAdtAPWezaBevCoaUEkERWluh)
				{
				case BaseControllerType.Gamepad:
					yapCVOfqvNpItdbGJOOdGIPMgwg = UnityTools.externalTools.PS4Input_PadIsConnected;
					VkHkrSRAXfFwZCiddhDOKCCETJo = UnityTools.externalTools.PS4Input_PadSetVibration;
					OHxGcIEBKFBMUdamgEhKdEkmmtr = UnityTools.externalTools.PS4Input_PadSetLightBar;
					OuxnbrSsGPdiIxMfbKWfRshDohk = UnityTools.externalTools.PS4Input_PadResetLightBar;
					hsEoMDiJZlSuqHwxydZDHSKXlsz = UnityTools.externalTools.PS4Input_PadSetMotionSensorState;
					zWBXyAkTdKygEmNnodbDAUkqGpG = UnityTools.externalTools.PS4Input_PadSetTiltCorrectionState;
					FxGiFbndaijHWcpFxQrVyOLsYCWV = UnityTools.externalTools.PS4Input_PadSetAngularVelocityDeadbandState;
					CDCxtdwgbjEaHHJiWQmHRMJtuYd = UnityTools.externalTools.PS4Input_PadResetOrientation;
					ugrQHtwforCyxOeIjgXfeNMzZmlB = UnityTools.externalTools.PS4Input_GetLastAcceleration;
					sZcRVrlrvPrwCHpmGnVZUxLSozZ = UnityTools.externalTools.PS4Input_GetLastGyro;
					OXdckGbUiwnHyFZfeHXaPVpIfwlW = UnityTools.externalTools.PS4Input_GetLastOrientation;
					break;
				case BaseControllerType.Special:
					yapCVOfqvNpItdbGJOOdGIPMgwg = UnityTools.externalTools.PS4Input_SpecialIsConnected;
					VkHkrSRAXfFwZCiddhDOKCCETJo = UnityTools.externalTools.PS4Input_SpecialSetVibration;
					OHxGcIEBKFBMUdamgEhKdEkmmtr = UnityTools.externalTools.PS4Input_SpecialSetLightSphere;
					OuxnbrSsGPdiIxMfbKWfRshDohk = UnityTools.externalTools.PS4Input_SpecialResetLightSphere;
					hsEoMDiJZlSuqHwxydZDHSKXlsz = UnityTools.externalTools.PS4Input_SpecialSetMotionSensorState;
					zWBXyAkTdKygEmNnodbDAUkqGpG = UnityTools.externalTools.PS4Input_SpecialSetTiltCorrectionState;
					FxGiFbndaijHWcpFxQrVyOLsYCWV = UnityTools.externalTools.PS4Input_SpecialSetAngularVelocityDeadbandState;
					CDCxtdwgbjEaHHJiWQmHRMJtuYd = UnityTools.externalTools.PS4Input_SpecialResetOrientation;
					ugrQHtwforCyxOeIjgXfeNMzZmlB = UnityTools.externalTools.PS4Input_SpecialGetLastAcceleration;
					sZcRVrlrvPrwCHpmGnVZUxLSozZ = UnityTools.externalTools.PS4Input_SpecialGetLastGyro;
					OXdckGbUiwnHyFZfeHXaPVpIfwlW = UnityTools.externalTools.PS4Input_SpecialGetLastOrientation;
					break;
				case BaseControllerType.Aim:
					yapCVOfqvNpItdbGJOOdGIPMgwg = UnityTools.externalTools.PS4Input_AimIsConnected;
					VkHkrSRAXfFwZCiddhDOKCCETJo = UnityTools.externalTools.PS4Input_AimSetVibration;
					OHxGcIEBKFBMUdamgEhKdEkmmtr = UnityTools.externalTools.PS4Input_AimSetLightSphere;
					OuxnbrSsGPdiIxMfbKWfRshDohk = UnityTools.externalTools.PS4Input_AimResetLightSphere;
					hsEoMDiJZlSuqHwxydZDHSKXlsz = UnityTools.externalTools.PS4Input_AimSetMotionSensorState;
					zWBXyAkTdKygEmNnodbDAUkqGpG = UnityTools.externalTools.PS4Input_AimSetTiltCorrectionState;
					FxGiFbndaijHWcpFxQrVyOLsYCWV = UnityTools.externalTools.PS4Input_AimSetAngularVelocityDeadbandState;
					CDCxtdwgbjEaHHJiWQmHRMJtuYd = UnityTools.externalTools.PS4Input_AimResetOrientation;
					ugrQHtwforCyxOeIjgXfeNMzZmlB = UnityTools.externalTools.PS4Input_GetLastAcceleration;
					sZcRVrlrvPrwCHpmGnVZUxLSozZ = UnityTools.externalTools.PS4Input_GetLastGyro;
					OXdckGbUiwnHyFZfeHXaPVpIfwlW = UnityTools.externalTools.PS4Input_GetLastOrientation;
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public virtual void iAnBBfDdWbgOiFHwNWqxFDtiXzYA()
			{
				WfiRxQPmnoNQHbeBJnRqyMUekUN();
			}

			public int qSvSpwilSIMEEnCakcqNGgeZlms()
			{
				return mzqkVThBwmgkAAynVwhyJsGZQGbf;
			}

			int mvpKKVIFRgOLaSdVrHeNqVnjxUt.qSvSpwilSIMEEnCakcqNGgeZlms()
			{
				//ILSpy generated this explicit interface implementation from .override directive in qSvSpwilSIMEEnCakcqNGgeZlms
				return this.qSvSpwilSIMEEnCakcqNGgeZlms();
			}

			public int fEemFUrFxhgtZbVGaEGfAbkqaEy()
			{
				return user.userId;
			}

			int mvpKKVIFRgOLaSdVrHeNqVnjxUt.fEemFUrFxhgtZbVGaEGfAbkqaEy()
			{
				//ILSpy generated this explicit interface implementation from .override directive in fEemFUrFxhgtZbVGaEGfAbkqaEy
				return this.fEemFUrFxhgtZbVGaEGfAbkqaEy();
			}

			public int fLJQlPlGmyvobbPQtikNBBRuXkB()
			{
				return user.status;
			}

			int mvpKKVIFRgOLaSdVrHeNqVnjxUt.fLJQlPlGmyvobbPQtikNBBRuXkB()
			{
				//ILSpy generated this explicit interface implementation from .override directive in fLJQlPlGmyvobbPQtikNBBRuXkB
				return this.fLJQlPlGmyvobbPQtikNBBRuXkB();
			}

			public bool tgMbrOaGBgTosbobbMXoxlMCPIN()
			{
				return user.primaryUser;
			}

			bool mvpKKVIFRgOLaSdVrHeNqVnjxUt.tgMbrOaGBgTosbobbMXoxlMCPIN()
			{
				//ILSpy generated this explicit interface implementation from .override directive in tgMbrOaGBgTosbobbMXoxlMCPIN
				return this.tgMbrOaGBgTosbobbMXoxlMCPIN();
			}

			public Color jlJAfgcSWwRGPKnwBHLJRQTLDOjf()
			{
				LoggedInUser loggedInUser = user;
				return loggedInUser.color switch
				{
					0 => Color.blue, 
					1 => Color.red, 
					2 => Color.green, 
					3 => Color.magenta, 
					_ => Color.black, 
				};
			}

			Color mvpKKVIFRgOLaSdVrHeNqVnjxUt.jlJAfgcSWwRGPKnwBHLJRQTLDOjf()
			{
				//ILSpy generated this explicit interface implementation from .override directive in jlJAfgcSWwRGPKnwBHLJRQTLDOjf
				return this.jlJAfgcSWwRGPKnwBHLJRQTLDOjf();
			}

			public int AOaVwNDHlCiKcBqWxumSrHWQraz()
			{
				return user.color;
			}

			int mvpKKVIFRgOLaSdVrHeNqVnjxUt.AOaVwNDHlCiKcBqWxumSrHWQraz()
			{
				//ILSpy generated this explicit interface implementation from .override directive in AOaVwNDHlCiKcBqWxumSrHWQraz
				return this.AOaVwNDHlCiKcBqWxumSrHWQraz();
			}

			public string bkBFigHkpnoKrNxtkAoiGyzcOgbD()
			{
				return user.userName;
			}

			string mvpKKVIFRgOLaSdVrHeNqVnjxUt.bkBFigHkpnoKrNxtkAoiGyzcOgbD()
			{
				//ILSpy generated this explicit interface implementation from .override directive in bkBFigHkpnoKrNxtkAoiGyzcOgbD
				return this.bkBFigHkpnoKrNxtkAoiGyzcOgbD();
			}

			public void StopVibration()
			{
				Array.Clear(IkTnbMskRbowWbxWPedRECvPKXw, 0, IkTnbMskRbowWbxWPedRECvPKXw.Length);
				uvfrHqDIOOlSEQbNXIUvKtxvetj();
			}

			public void SetVibration(int motorIndex, float value)
			{
				if ((uint)motorIndex <= (uint)oVAysyflicCsfbwqntSlbYXfmydd.HSFfOkgYdavTAaqGDaWBzgNaSgu)
				{
					IkTnbMskRbowWbxWPedRECvPKXw[motorIndex] = value;
					uvfrHqDIOOlSEQbNXIUvKtxvetj();
				}
			}

			public float GetVibration(int motorIndex)
			{
				if ((uint)motorIndex > (uint)oVAysyflicCsfbwqntSlbYXfmydd.HSFfOkgYdavTAaqGDaWBzgNaSgu)
				{
					return 0f;
				}
				return IkTnbMskRbowWbxWPedRECvPKXw[motorIndex];
			}

			public void SetMotionSensorState(bool enabled)
			{
				hsEoMDiJZlSuqHwxydZDHSKXlsz(EpFfrTuakcvBKacoggaztTmGfrG, enabled);
			}

			public void SetTiltCorrectionState(bool enabled)
			{
				zWBXyAkTdKygEmNnodbDAUkqGpG(EpFfrTuakcvBKacoggaztTmGfrG, enabled);
			}

			public void SetAngularVelocityDeadbandState(bool enabled)
			{
				FxGiFbndaijHWcpFxQrVyOLsYCWV(EpFfrTuakcvBKacoggaztTmGfrG, enabled);
			}

			public void ResetOrientation()
			{
				CDCxtdwgbjEaHHJiWQmHRMJtuYd(EpFfrTuakcvBKacoggaztTmGfrG);
			}

			public Vector3 GetLastAcceleration()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				Vector3 result = ugrQHtwforCyxOeIjgXfeNMzZmlB(EpFfrTuakcvBKacoggaztTmGfrG);
				ObjaoVadkAjRNZsmweslXOdEulC(ref result);
				return result;
			}

			public Vector3 GetLastAccelerationRaw()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				return ugrQHtwforCyxOeIjgXfeNMzZmlB(EpFfrTuakcvBKacoggaztTmGfrG);
			}

			public Vector3 GetLastGyro()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				Vector3 result = sZcRVrlrvPrwCHpmGnVZUxLSozZ(EpFfrTuakcvBKacoggaztTmGfrG);
				GnnEYwfGaGGVTgrMPbzshWJKmcCs(ref result);
				return result;
			}

			public Vector3 GetLastGyroRaw()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				return sZcRVrlrvPrwCHpmGnVZUxLSozZ(EpFfrTuakcvBKacoggaztTmGfrG);
			}

			public Quaternion GetLastOrientation()
			{
				if (!IsConnectedNow)
				{
					return Quaternion.identity;
				}
				Vector4 vector = OXdckGbUiwnHyFZfeHXaPVpIfwlW(EpFfrTuakcvBKacoggaztTmGfrG);
				return new Quaternion(vector.x * -1f, vector.y, vector.z, vector.w);
			}

			public Quaternion GetLastOrientationRaw()
			{
				if (!IsConnectedNow)
				{
					return Quaternion.identity;
				}
				Vector4 vector = OXdckGbUiwnHyFZfeHXaPVpIfwlW(EpFfrTuakcvBKacoggaztTmGfrG);
				return new Quaternion(vector.x, vector.y, vector.z, vector.w);
			}

			public void SetLightColor(int red, int green, int blue)
			{
				OHxGcIEBKFBMUdamgEhKdEkmmtr(EpFfrTuakcvBKacoggaztTmGfrG, red, green, blue);
			}

			public void ResetLight()
			{
				OuxnbrSsGPdiIxMfbKWfRshDohk(EpFfrTuakcvBKacoggaztTmGfrG);
			}

			protected virtual void WfiRxQPmnoNQHbeBJnRqyMUekUN()
			{
				int joystickId = dCZEgzobTpHayGZtxUSftmjRvGe + 1;
				IList<Button> buttons = base.Buttons;
				buttons[0].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 0);
				buttons[1].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 1);
				buttons[2].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 2);
				buttons[3].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 3);
				buttons[4].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 4);
				buttons[5].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 5);
				buttons[6].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 6);
				buttons[7].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 7);
				buttons[8].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 8);
				buttons[9].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 9);
				float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 5);
				float joystickAxisValueByJoystickId2 = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 6);
				buttons[10].value = joystickAxisValueByJoystickId2 > oVAysyflicCsfbwqntSlbYXfmydd.pPKwinMTfdcbZTkXdNkwrDLZYuL;
				buttons[11].value = joystickAxisValueByJoystickId > oVAysyflicCsfbwqntSlbYXfmydd.pPKwinMTfdcbZTkXdNkwrDLZYuL;
				buttons[12].value = joystickAxisValueByJoystickId2 < 0f - oVAysyflicCsfbwqntSlbYXfmydd.pPKwinMTfdcbZTkXdNkwrDLZYuL;
				buttons[13].value = joystickAxisValueByJoystickId < 0f - oVAysyflicCsfbwqntSlbYXfmydd.pPKwinMTfdcbZTkXdNkwrDLZYuL;
				IList<Axis> axes = base.Axes;
				axes[0].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 0);
				axes[1].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 1);
				axes[2].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 3);
				axes[3].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 4);
				axes[4].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 7);
				axes[5].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 2);
			}

			protected void uvfrHqDIOOlSEQbNXIUvKtxvetj()
			{
				if (oVAysyflicCsfbwqntSlbYXfmydd.HSFfOkgYdavTAaqGDaWBzgNaSgu != 0)
				{
					VkHkrSRAXfFwZCiddhDOKCCETJo(EpFfrTuakcvBKacoggaztTmGfrG, aZhhKTnLItLxIpcwMbzmGPOQgyb(IkTnbMskRbowWbxWPedRECvPKXw[0]), aZhhKTnLItLxIpcwMbzmGPOQgyb(IkTnbMskRbowWbxWPedRECvPKXw[1]));
				}
			}

			public static int aZhhKTnLItLxIpcwMbzmGPOQgyb(float P_0)
			{
				if (P_0 <= 0f)
				{
					return 0;
				}
				if (P_0 >= 1f)
				{
					return 255;
				}
				return (int)(P_0 * 255f);
			}

			public static void ObjaoVadkAjRNZsmweslXOdEulC(ref Vector3 P_0)
			{
				P_0.x *= -1f;
				P_0.y *= -1f;
			}

			public static void GnnEYwfGaGGVTgrMPbzshWJKmcCs(ref Vector3 P_0)
			{
				P_0.x *= -1f;
				P_0.y *= -1f;
			}

			public static bool XgXgXnzyzHlGZxwyNccpFRwWuHY(int P_0, out ControllerType P_1)
			{
				string text = UnityTools.externalTools.PS4Input_GetDeviceClassString(P_0);
				if (string.IsNullOrEmpty(text))
				{
					P_1 = ControllerType.Unknown;
					return false;
				}
				if (text.Equals("Standard", StringComparison.OrdinalIgnoreCase))
				{
					P_1 = ControllerType.Gamepad;
					return true;
				}
				if (text.Equals("FlightStick", StringComparison.OrdinalIgnoreCase) || text.Equals("hotas", StringComparison.OrdinalIgnoreCase))
				{
					P_1 = ControllerType.FlightStick;
					return true;
				}
				if (text.Equals("Stick", StringComparison.OrdinalIgnoreCase) || text.Equals("hotas", StringComparison.OrdinalIgnoreCase))
				{
					P_1 = ControllerType.FlightStick;
					return true;
				}
				if (text.Equals("SteeringWheel", StringComparison.OrdinalIgnoreCase))
				{
					P_1 = ControllerType.SteeringWheel;
					return true;
				}
				if (text.Equals("Guitar", StringComparison.OrdinalIgnoreCase))
				{
					P_1 = ControllerType.Guitar;
					return true;
				}
				if (text.Equals("Drum", StringComparison.OrdinalIgnoreCase))
				{
					P_1 = ControllerType.Drum;
					return true;
				}
				if (text.Equals("Gun", StringComparison.OrdinalIgnoreCase))
				{
					P_1 = ControllerType.Gun;
					return true;
				}
				if (text.Equals("DjTurntable", StringComparison.OrdinalIgnoreCase))
				{
					P_1 = ControllerType.DjTurntable;
					return true;
				}
				if (text.Equals("Dancemat", StringComparison.OrdinalIgnoreCase))
				{
					P_1 = ControllerType.DanceMat;
					return true;
				}
				if (text.Equals("Navigation", StringComparison.OrdinalIgnoreCase))
				{
					P_1 = ControllerType.Navigation;
					return true;
				}
				P_1 = ControllerType.Unknown;
				return false;
			}
		}

		private sealed class NyXaqAJEajJbjWEXybQrMSMhOqDG : YPEmCTKgOQXHKMuRGCMfSJbLXza, mvpKKVIFRgOLaSdVrHeNqVnjxUt, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource, IPS4ControllerExtensionSourceTouchPad, IPS4GamepadExtensionSource
		{
			private const int YNIDFQWKcHJbextfHSVIzpEuFds = 6;

			private const int KEPWIVLoHsLSAdrpdXFruDkpWpy = 14;

			private const float AiHhbympqlOXXlqxvQeFsPHnqnM = 0.05f;

			private const int EfkbvIRtTeGKvcbBCDiJEjwATTCj = 2;

			private const int ifGTjIlrXkCAobGXIcnCWowYTFz = 2;

			private int gzQdXvhcIuBvTdbOaLlYnJNwMfX;

			private int RRniCshIpEBLYnqpPiFFCdROyFFp;

			private Vector2 zpDyiDqhPxnpVPAxDoVrzcJafCtG;

			private int ItNmLBbwJMPkWGzXhLcNiulvENM;

			private Vector2 dMNhejcNTeTWHPfCnpwmkupkNMw;

			private SjdsSTcRDUQgQDWXLKMUdSeMIts uIHDDcBhFTWAhQoPxXgUOzGFrlU;

			private int YfClZuKhkboYWztGHxIBEldEVVd;

			private int OeQfUcRpjDWMlwShQPOdOhXJgqm;

			private int KeWLEnQfHFqEGGoUUxWhCjRUsIn;

			private int vaDFeunrbLNgQkPCYFloZLtJwJZ;

			private float bwtauXiZAcwlpknQOMhoVhZrNYg;

			public int maxTouches => oVAysyflicCsfbwqntSlbYXfmydd.bGGYDEAvAuLfFYijCTyxEiSidnY;

			public NyXaqAJEajJbjWEXybQrMSMhOqDG(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Gamepad, BaseControllerType.Gamepad, name, playerId, unityJoystickId, handle, new PQVbyPgmdcPbZFTfAQVdAYUFRNxE(6, 14, 0.05f, 2, 2))
			{
				DHMxZDCyFTvxNsqfBoMSdIXkFSHe();
				base.extension = new PS4GamepadExtension(this);
			}

			public int GetConnectionType()
			{
				return (int)uIHDDcBhFTWAhQoPxXgUOzGFrlU;
			}

			public int GetAnalogDeadZoneLeft()
			{
				return KeWLEnQfHFqEGGoUUxWhCjRUsIn;
			}

			public int GetAnalogDeadZoneRight()
			{
				return vaDFeunrbLNgQkPCYFloZLtJwJZ;
			}

			public float GetTouchPixelDensity()
			{
				return bwtauXiZAcwlpknQOMhoVhZrNYg;
			}

			public int GetTouchpadResolutionX()
			{
				return YfClZuKhkboYWztGHxIBEldEVVd;
			}

			public int GetTouchpadResolutionY()
			{
				return OeQfUcRpjDWMlwShQPOdOhXJgqm;
			}

			public int GetTouchCount()
			{
				return gzQdXvhcIuBvTdbOaLlYnJNwMfX;
			}

			public int GetTouchId(int index)
			{
				if (index < 0 || index >= oVAysyflicCsfbwqntSlbYXfmydd.bGGYDEAvAuLfFYijCTyxEiSidnY)
				{
					return -1;
				}
				return index switch
				{
					0 => RRniCshIpEBLYnqpPiFFCdROyFFp, 
					1 => ItNmLBbwJMPkWGzXhLcNiulvENM, 
					_ => -1, 
				};
			}

			public bool GetTouchPositionAbsByIndex(int index, out Vector2 position)
			{
				if (index < 0 || index >= oVAysyflicCsfbwqntSlbYXfmydd.bGGYDEAvAuLfFYijCTyxEiSidnY || !IsTouchingByIndex(index))
				{
					position = default(Vector2);
					return false;
				}
				switch (index)
				{
				case 0:
					position = zpDyiDqhPxnpVPAxDoVrzcJafCtG;
					break;
				case 1:
					position = dMNhejcNTeTWHPfCnpwmkupkNMw;
					break;
				default:
					position = default(Vector2);
					return false;
				}
				return true;
			}

			public bool GetTouchPositionAbsByTouchId(int touchId, out Vector2 position)
			{
				int num = khtagzdkbrqhghsiEwXPbZWHxRUa(touchId);
				if (num < 0)
				{
					position = default(Vector2);
					return false;
				}
				return GetTouchPositionAbsByIndex(num, out position);
			}

			public bool GetTouchPositionByIndex(int index, out Vector2 position)
			{
				if (index < 0 || index >= oVAysyflicCsfbwqntSlbYXfmydd.bGGYDEAvAuLfFYijCTyxEiSidnY || !IsTouchingByIndex(index))
				{
					position = default(Vector2);
					return false;
				}
				switch (index)
				{
				case 0:
					position = new Vector2(zpDyiDqhPxnpVPAxDoVrzcJafCtG.x, zpDyiDqhPxnpVPAxDoVrzcJafCtG.y);
					break;
				case 1:
					position = new Vector2(dMNhejcNTeTWHPfCnpwmkupkNMw.x, dMNhejcNTeTWHPfCnpwmkupkNMw.y);
					break;
				default:
					position = default(Vector2);
					return false;
				}
				position.x /= YfClZuKhkboYWztGHxIBEldEVVd;
				position.y /= OeQfUcRpjDWMlwShQPOdOhXJgqm;
				return true;
			}

			public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
			{
				int num = khtagzdkbrqhghsiEwXPbZWHxRUa(touchId);
				if (num < 0)
				{
					position = default(Vector2);
					return false;
				}
				return GetTouchPositionByIndex(num, out position);
			}

			public bool IsTouchingByIndex(int index)
			{
				if (index < 0 || index >= oVAysyflicCsfbwqntSlbYXfmydd.bGGYDEAvAuLfFYijCTyxEiSidnY)
				{
					return false;
				}
				return index < gzQdXvhcIuBvTdbOaLlYnJNwMfX;
			}

			public bool IsTouchingByTouchId(int touchId)
			{
				if (touchId < 0)
				{
					return false;
				}
				int num = khtagzdkbrqhghsiEwXPbZWHxRUa(touchId);
				return num >= 0;
			}

			protected override void WfiRxQPmnoNQHbeBJnRqyMUekUN()
			{
				base.WfiRxQPmnoNQHbeBJnRqyMUekUN();
				UnityTools.externalTools.PS4Input_GetLastTouchData(EpFfrTuakcvBKacoggaztTmGfrG, out gzQdXvhcIuBvTdbOaLlYnJNwMfX, out var touch0x, out var touch0y, out RRniCshIpEBLYnqpPiFFCdROyFFp, out var touch1x, out var touch1y, out ItNmLBbwJMPkWGzXhLcNiulvENM);
				zpDyiDqhPxnpVPAxDoVrzcJafCtG.x = touch0x;
				zpDyiDqhPxnpVPAxDoVrzcJafCtG.y = OeQfUcRpjDWMlwShQPOdOhXJgqm - touch0y;
				dMNhejcNTeTWHPfCnpwmkupkNMw.x = touch1x;
				dMNhejcNTeTWHPfCnpwmkupkNMw.y = OeQfUcRpjDWMlwShQPOdOhXJgqm - touch1y;
			}

			private void DHMxZDCyFTvxNsqfBoMSdIXkFSHe()
			{
				IExternalTools externalTools = UnityTools.externalTools;
				externalTools.PS4Input_GetPadControllerInformation(EpFfrTuakcvBKacoggaztTmGfrG, out bwtauXiZAcwlpknQOMhoVhZrNYg, out YfClZuKhkboYWztGHxIBEldEVVd, out OeQfUcRpjDWMlwShQPOdOhXJgqm, out KeWLEnQfHFqEGGoUUxWhCjRUsIn, out vaDFeunrbLNgQkPCYFloZLtJwJZ, out var connectionType);
				uIHDDcBhFTWAhQoPxXgUOzGFrlU = (SjdsSTcRDUQgQDWXLKMUdSeMIts)connectionType;
				externalTools.PS4Input_PadResetOrientation(EpFfrTuakcvBKacoggaztTmGfrG);
			}

			private int khtagzdkbrqhghsiEwXPbZWHxRUa(int P_0)
			{
				if (P_0 < 0)
				{
					return -1;
				}
				if (gzQdXvhcIuBvTdbOaLlYnJNwMfX > 0 && RRniCshIpEBLYnqpPiFFCdROyFFp == P_0)
				{
					return 0;
				}
				if (gzQdXvhcIuBvTdbOaLlYnJNwMfX > 1 && ItNmLBbwJMPkWGzXhLcNiulvENM == P_0)
				{
					return 1;
				}
				return -1;
			}
		}

		private sealed class zBpXOJGqVtlfWqqvjVlUnsXickW : YPEmCTKgOQXHKMuRGCMfSJbLXza, mvpKKVIFRgOLaSdVrHeNqVnjxUt, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource, IPS4AimExtensionSource
		{
			private const int YNIDFQWKcHJbextfHSVIzpEuFds = 6;

			private const int KEPWIVLoHsLSAdrpdXFruDkpWpy = 14;

			private const float AiHhbympqlOXXlqxvQeFsPHnqnM = 0.05f;

			private const int EfkbvIRtTeGKvcbBCDiJEjwATTCj = 2;

			private const int ifGTjIlrXkCAobGXIcnCWowYTFz = 2;

			private int gzQdXvhcIuBvTdbOaLlYnJNwMfX;

			private int RRniCshIpEBLYnqpPiFFCdROyFFp;

			private Vector2 zpDyiDqhPxnpVPAxDoVrzcJafCtG;

			private int ItNmLBbwJMPkWGzXhLcNiulvENM;

			private Vector2 dMNhejcNTeTWHPfCnpwmkupkNMw;

			private SjdsSTcRDUQgQDWXLKMUdSeMIts uIHDDcBhFTWAhQoPxXgUOzGFrlU;

			private int YfClZuKhkboYWztGHxIBEldEVVd;

			private int OeQfUcRpjDWMlwShQPOdOhXJgqm;

			private int KeWLEnQfHFqEGGoUUxWhCjRUsIn;

			private int vaDFeunrbLNgQkPCYFloZLtJwJZ;

			private float bwtauXiZAcwlpknQOMhoVhZrNYg;

			public zBpXOJGqVtlfWqqvjVlUnsXickW(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Aim, BaseControllerType.Aim, name, playerId, unityJoystickId, handle, new PQVbyPgmdcPbZFTfAQVdAYUFRNxE(6, 14, 0.05f, 2, 2))
			{
				base.extension = new PS4AimExtension(this);
			}
		}

		private abstract class oYXtzgNZhRXSYGdTqDyOIDXgwaI : YPEmCTKgOQXHKMuRGCMfSJbLXza
		{
			protected oYXtzgNZhRXSYGdTqDyOIDXgwaI(ControllerType controllerType, string name, int playerId, int unityJoystickId, int handle, PQVbyPgmdcPbZFTfAQVdAYUFRNxE capabilities)
				: base(controllerType, BaseControllerType.Special, name, playerId, unityJoystickId, handle, capabilities)
			{
			}

			public static oYXtzgNZhRXSYGdTqDyOIDXgwaI ikoBGVHHLVNnLaVaWGffMETVhTJw(int P_0, int P_1, int P_2)
			{
				if (!YPEmCTKgOQXHKMuRGCMfSJbLXza.XgXgXnzyzHlGZxwyNccpFRwWuHY(P_0, out var controllerType))
				{
					return null;
				}
				return ikoBGVHHLVNnLaVaWGffMETVhTJw(controllerType, P_1, P_2);
			}

			public static oYXtzgNZhRXSYGdTqDyOIDXgwaI ikoBGVHHLVNnLaVaWGffMETVhTJw(ControllerType P_0, int P_1, int P_2)
			{
				int unityJoystickId = P_1 + 13;
				switch (P_0)
				{
				case ControllerType.Unknown:
				case ControllerType.Gamepad:
				case ControllerType.Aim:
					return null;
				case ControllerType.Drum:
					return new VXDWzKAFNIoSxvdFDiwacLxOqOai("Drums " + (P_1 + 1), P_1, unityJoystickId, P_2);
				case ControllerType.FlightStick:
					return new JuiiAHaQVSQYZKBMWhDkyPswFbTG("Flight Stick " + (P_1 + 1), P_1, unityJoystickId, P_2);
				case ControllerType.Guitar:
					return new PkOEfTgbhQBKaRBAlZXePNfphDT("Guitar " + (P_1 + 1), P_1, unityJoystickId, P_2);
				case ControllerType.SteeringWheel:
					return new gjngUeCNVRGPnIQWuDvTUkMnUcvC("Steering Wheel " + (P_1 + 1), P_1, unityJoystickId, P_2);
				case ControllerType.DjTurntable:
				case ControllerType.DanceMat:
				case ControllerType.Navigation:
				case ControllerType.Stick:
				case ControllerType.Gun:
					return null;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class gjngUeCNVRGPnIQWuDvTUkMnUcvC : oYXtzgNZhRXSYGdTqDyOIDXgwaI
		{
			private const int YNIDFQWKcHJbextfHSVIzpEuFds = 13;

			private const int KEPWIVLoHsLSAdrpdXFruDkpWpy = 14;

			private const float AiHhbympqlOXXlqxvQeFsPHnqnM = 0.05f;

			private const int EfkbvIRtTeGKvcbBCDiJEjwATTCj = 2;

			private const int ifGTjIlrXkCAobGXIcnCWowYTFz = 0;

			public gjngUeCNVRGPnIQWuDvTUkMnUcvC(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.SteeringWheel, name, playerId, unityJoystickId, handle, new PQVbyPgmdcPbZFTfAQVdAYUFRNxE(13, 14, 0.05f, 2, 0))
			{
				base.extension = new PS4ControllerExtension(this);
			}

			protected override void WfiRxQPmnoNQHbeBJnRqyMUekUN()
			{
				base.WfiRxQPmnoNQHbeBJnRqyMUekUN();
				int joystickId = dCZEgzobTpHayGZtxUSftmjRvGe + 1;
				IList<Axis> axes = base.Axes;
				axes[6].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 10);
				axes[7].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 11);
				axes[8].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 12);
				axes[9].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 13);
				axes[10].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 14);
				axes[11].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 15);
				axes[12].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 16);
			}
		}

		private sealed class PkOEfTgbhQBKaRBAlZXePNfphDT : oYXtzgNZhRXSYGdTqDyOIDXgwaI
		{
			private const int YNIDFQWKcHJbextfHSVIzpEuFds = 11;

			private const int KEPWIVLoHsLSAdrpdXFruDkpWpy = 14;

			private const float AiHhbympqlOXXlqxvQeFsPHnqnM = 0.05f;

			private const int EfkbvIRtTeGKvcbBCDiJEjwATTCj = 2;

			private const int ifGTjIlrXkCAobGXIcnCWowYTFz = 0;

			public PkOEfTgbhQBKaRBAlZXePNfphDT(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Guitar, name, playerId, unityJoystickId, handle, new PQVbyPgmdcPbZFTfAQVdAYUFRNxE(11, 14, 0.05f, 2, 0))
			{
				base.extension = new PS4ControllerExtension(this);
			}

			protected override void WfiRxQPmnoNQHbeBJnRqyMUekUN()
			{
				base.WfiRxQPmnoNQHbeBJnRqyMUekUN();
				int joystickId = dCZEgzobTpHayGZtxUSftmjRvGe + 1;
				IList<Axis> axes = base.Axes;
				axes[6].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 10);
				axes[7].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 11);
				axes[8].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 12);
				axes[9].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 13);
				axes[10].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 14);
			}
		}

		private sealed class VXDWzKAFNIoSxvdFDiwacLxOqOai : oYXtzgNZhRXSYGdTqDyOIDXgwaI
		{
			private const int YNIDFQWKcHJbextfHSVIzpEuFds = 13;

			private const int KEPWIVLoHsLSAdrpdXFruDkpWpy = 14;

			private const float AiHhbympqlOXXlqxvQeFsPHnqnM = 0.05f;

			private const int EfkbvIRtTeGKvcbBCDiJEjwATTCj = 2;

			private const int ifGTjIlrXkCAobGXIcnCWowYTFz = 0;

			public VXDWzKAFNIoSxvdFDiwacLxOqOai(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Drum, name, playerId, unityJoystickId, handle, new PQVbyPgmdcPbZFTfAQVdAYUFRNxE(13, 14, 0.05f, 2, 0))
			{
				base.extension = new PS4ControllerExtension(this);
			}

			protected override void WfiRxQPmnoNQHbeBJnRqyMUekUN()
			{
				base.WfiRxQPmnoNQHbeBJnRqyMUekUN();
				int joystickId = dCZEgzobTpHayGZtxUSftmjRvGe + 1;
				IList<Axis> axes = base.Axes;
				axes[6].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 10);
				axes[7].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 11);
				axes[8].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 12);
				axes[9].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 13);
				axes[10].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 14);
				axes[11].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 15);
				axes[12].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 16);
			}
		}

		private sealed class JuiiAHaQVSQYZKBMWhDkyPswFbTG : oYXtzgNZhRXSYGdTqDyOIDXgwaI
		{
			private const int YNIDFQWKcHJbextfHSVIzpEuFds = 16;

			private const int KEPWIVLoHsLSAdrpdXFruDkpWpy = 14;

			private const float AiHhbympqlOXXlqxvQeFsPHnqnM = 0.05f;

			private const int EfkbvIRtTeGKvcbBCDiJEjwATTCj = 2;

			private const int ifGTjIlrXkCAobGXIcnCWowYTFz = 0;

			public JuiiAHaQVSQYZKBMWhDkyPswFbTG(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.FlightStick, name, playerId, unityJoystickId, handle, new PQVbyPgmdcPbZFTfAQVdAYUFRNxE(16, 14, 0.05f, 2, 0))
			{
				base.extension = new PS4ControllerExtension(this);
			}

			protected override void WfiRxQPmnoNQHbeBJnRqyMUekUN()
			{
				base.WfiRxQPmnoNQHbeBJnRqyMUekUN();
				int joystickId = dCZEgzobTpHayGZtxUSftmjRvGe + 1;
				IList<Axis> axes = base.Axes;
				axes[6].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 10);
				axes[7].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 11);
				axes[8].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 12);
				axes[9].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 13);
				axes[10].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 14);
				axes[11].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 15);
				axes[12].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 16);
				axes[13].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 17);
				axes[14].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 18);
				axes[15].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 19);
			}
		}

		private TEZCTvrddMjRUCOnElLhaEKNInfL kfGchTjcUEDWvEWThmhUWyaGygyX;

		private bool KfojdQNNEMbSOIJWeIyuMnpKoZiD = true;

		private bool JtZAxieDBYjDdfBgPPJgrNSxYmS;

		public override bool isReady => true;

		bool IControllerAssigner.enabled
		{
			get
			{
				return KfojdQNNEMbSOIJWeIyuMnpKoZiD;
			}
			set
			{
				KfojdQNNEMbSOIJWeIyuMnpKoZiD = value;
			}
		}

		public PS4InputSource()
			: base(22)
		{
			ReInput.controllerAssigner = this;
			kfGchTjcUEDWvEWThmhUWyaGygyX = new TEZCTvrddMjRUCOnElLhaEKNInfL(4);
			kfGchTjcUEDWvEWThmhUWyaGygyX.ControllerConnectedEvent += ujnxqIrcMHuFmYPAwiTmtQUJkeG;
			kfGchTjcUEDWvEWThmhUWyaGygyX.ControllerDisconnectedEvent += hHyhnfvdQFjzFjCFDkNNlZdqPFQ;
		}

		public override void Update()
		{
			kfGchTjcUEDWvEWThmhUWyaGygyX.iAnBBfDdWbgOiFHwNWqxFDtiXzYA();
			IList<Joystick> joysticks = GetJoysticks();
			int count = joysticks.Count;
			for (int i = 0; i < count; i++)
			{
				try
				{
					joysticks[i].Update();
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred during source joystick update.\n" + ex);
				}
			}
		}

		private static int JvvasKvFXnSeDidrxJHxkSGOiqr(int P_0)
		{
			if (P_0 >= 13)
			{
				return P_0 - 13;
			}
			return P_0 - 1;
		}

		private void ujnxqIrcMHuFmYPAwiTmtQUJkeG(TEZCTvrddMjRUCOnElLhaEKNInfL.gjLNOGYBQDbejkzWFpeJHHxspjiX P_0)
		{
			YPEmCTKgOQXHKMuRGCMfSJbLXza yPEmCTKgOQXHKMuRGCMfSJbLXza;
			switch (P_0.VkiJVBFFvYWMkVGWArBZaTZCJAe)
			{
			case YPEmCTKgOQXHKMuRGCMfSJbLXza.BaseControllerType.Gamepad:
				yPEmCTKgOQXHKMuRGCMfSJbLXza = YPEmCTKgOQXHKMuRGCMfSJbLXza.ikoBGVHHLVNnLaVaWGffMETVhTJw(YPEmCTKgOQXHKMuRGCMfSJbLXza.ControllerType.Gamepad, P_0.BNMfzqorwyKNLmzLFOEIJJOnOHB, P_0.KcihJPqCzQKLaiJAuOEZocqkGuT, P_0.qhxbfYcEshLHnIYUOREjSbHwqfQ);
				if (yPEmCTKgOQXHKMuRGCMfSJbLXza == null)
				{
					return;
				}
				break;
			case YPEmCTKgOQXHKMuRGCMfSJbLXza.BaseControllerType.Special:
				yPEmCTKgOQXHKMuRGCMfSJbLXza = oYXtzgNZhRXSYGdTqDyOIDXgwaI.ikoBGVHHLVNnLaVaWGffMETVhTJw(P_0.BNMfzqorwyKNLmzLFOEIJJOnOHB, P_0.KcihJPqCzQKLaiJAuOEZocqkGuT, P_0.qhxbfYcEshLHnIYUOREjSbHwqfQ);
				if (yPEmCTKgOQXHKMuRGCMfSJbLXza == null)
				{
					return;
				}
				break;
			case YPEmCTKgOQXHKMuRGCMfSJbLXza.BaseControllerType.Aim:
				yPEmCTKgOQXHKMuRGCMfSJbLXza = YPEmCTKgOQXHKMuRGCMfSJbLXza.ikoBGVHHLVNnLaVaWGffMETVhTJw(YPEmCTKgOQXHKMuRGCMfSJbLXza.ControllerType.Aim, P_0.BNMfzqorwyKNLmzLFOEIJJOnOHB, P_0.KcihJPqCzQKLaiJAuOEZocqkGuT, P_0.qhxbfYcEshLHnIYUOREjSbHwqfQ);
				if (yPEmCTKgOQXHKMuRGCMfSJbLXza == null)
				{
					return;
				}
				break;
			default:
				throw new NotImplementedException();
			}
			LpQqmXrUbelbjQMoGQAhLSQTtTI(yPEmCTKgOQXHKMuRGCMfSJbLXza);
		}

		private void LpQqmXrUbelbjQMoGQAhLSQTtTI(YPEmCTKgOQXHKMuRGCMfSJbLXza P_0)
		{
			AddJoystick(P_0);
			P_0.Connect();
			OnJoystickConnected();
		}

		private void hHyhnfvdQFjzFjCFDkNNlZdqPFQ(TEZCTvrddMjRUCOnElLhaEKNInfL.PkXjhsHsbhCsRDdxYKTRnWlvcEA P_0)
		{
			IList<Joystick> joysticks = GetJoysticks();
			int count = joysticks.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				YPEmCTKgOQXHKMuRGCMfSJbLXza yPEmCTKgOQXHKMuRGCMfSJbLXza = joysticks[num] as YPEmCTKgOQXHKMuRGCMfSJbLXza;
				if (P_0.VkiJVBFFvYWMkVGWArBZaTZCJAe == yPEmCTKgOQXHKMuRGCMfSJbLXza.baseControllerType && yPEmCTKgOQXHKMuRGCMfSJbLXza.playerId == P_0.KcihJPqCzQKLaiJAuOEZocqkGuT && yPEmCTKgOQXHKMuRGCMfSJbLXza.handle == P_0.qhxbfYcEshLHnIYUOREjSbHwqfQ)
				{
					yPEmCTKgOQXHKMuRGCMfSJbLXza.Disconnect();
					RemoveJoystick(yPEmCTKgOQXHKMuRGCMfSJbLXza);
				}
			}
			OnJoystickDisconnected();
		}

		private bool soJlquRKJNcfjybzNhtJkhjuIeBb(ControllerType P_0, Rewired.Controller P_1)
		{
			if (!KfojdQNNEMbSOIJWeIyuMnpKoZiD)
			{
				return false;
			}
			if (P_0 != ControllerType.Joystick)
			{
				return false;
			}
			return ReInput.configVars.ps4_assignJoysticksByPS4JoyId;
		}

		bool IControllerAssigner.CanHandleAssignment(ControllerType P_0, Rewired.Controller P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in soJlquRKJNcfjybzNhtJkhjuIeBb
			return this.soJlquRKJNcfjybzNhtJkhjuIeBb(P_0, P_1);
		}

		private void cdLAlqnsyYogetnomawgCjgKRvsc(ControllerType P_0, Rewired.Controller P_1)
		{
			if (!((IControllerAssigner)this).CanHandleAssignment(P_0, P_1))
			{
				return;
			}
			Rewired.Joystick joystick = P_1 as Rewired.Joystick;
			if (!ReInput.controllers.IsJoystickAssigned(joystick))
			{
				int num = JvvasKvFXnSeDidrxJHxkSGOiqr(joystick.unityId);
				if (num < ReInput.players.playerCount && ReInput.players.GetPlayer(num) != null && (!ReInput.configVars.assignJoysticksToPlayingPlayersOnly || ReInput.players.GetPlayer(num).isPlaying))
				{
					ReInput.players.GetPlayer(num).controllers.AddController(joystick, removeFromOtherPlayers: true);
				}
			}
		}

		void IControllerAssigner.AssignController(ControllerType P_0, Rewired.Controller P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in cdLAlqnsyYogetnomawgCjgKRvsc
			this.cdLAlqnsyYogetnomawgCjgKRvsc(P_0, P_1);
		}

		~PS4InputSource()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (!JtZAxieDBYjDdfBgPPJgrNSxYmS)
			{
				JtZAxieDBYjDdfBgPPJgrNSxYmS = true;
			}
		}
	}
}
