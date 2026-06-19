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
		private class robegNEBCPaHIRZRVXUeYBtvxUL
		{
			public struct JqZFzvSsmpGjkDkBjXzvOJOtHUB
			{
				public int oiWUinLKWXyukpIwfOtSoxBWeDp;

				public int UdRaEyVNzeQmlXdePtFgUZmOqma;

				public int nZoOiWFbSzkxRviXQbGJPvfNvSl;

				public smsZnrfodXmyATytXSHkAhInxFC.BaseControllerType pAUZutcIWFLfyIuyDiNKiSukBQE;

				public JqZFzvSsmpGjkDkBjXzvOJOtHUB(int playerId, int handle, int deviceClass, smsZnrfodXmyATytXSHkAhInxFC.BaseControllerType baseControllerType)
				{
					oiWUinLKWXyukpIwfOtSoxBWeDp = playerId;
					UdRaEyVNzeQmlXdePtFgUZmOqma = handle;
					nZoOiWFbSzkxRviXQbGJPvfNvSl = deviceClass;
					pAUZutcIWFLfyIuyDiNKiSukBQE = baseControllerType;
				}
			}

			public struct dlhFbzAPwcPOvXXdtuKOCUvnSEW
			{
				public int oiWUinLKWXyukpIwfOtSoxBWeDp;

				public int UdRaEyVNzeQmlXdePtFgUZmOqma;

				public smsZnrfodXmyATytXSHkAhInxFC.BaseControllerType pAUZutcIWFLfyIuyDiNKiSukBQE;

				public dlhFbzAPwcPOvXXdtuKOCUvnSEW(int playerId, int handle, smsZnrfodXmyATytXSHkAhInxFC.BaseControllerType baseControllerType)
				{
					oiWUinLKWXyukpIwfOtSoxBWeDp = playerId;
					UdRaEyVNzeQmlXdePtFgUZmOqma = handle;
					pAUZutcIWFLfyIuyDiNKiSukBQE = baseControllerType;
				}
			}

			private class aKKMkpjPBbGirqUyQHPpIHecAuS
			{
				public readonly smsZnrfodXmyATytXSHkAhInxFC.BaseControllerType pAUZutcIWFLfyIuyDiNKiSukBQE;

				public bool voHHTveCkwpJYLrdIFQOwoGzelU;

				public int UdRaEyVNzeQmlXdePtFgUZmOqma;

				public int nZoOiWFbSzkxRviXQbGJPvfNvSl;

				public aKKMkpjPBbGirqUyQHPpIHecAuS(smsZnrfodXmyATytXSHkAhInxFC.BaseControllerType baseControllerType)
				{
					pAUZutcIWFLfyIuyDiNKiSukBQE = baseControllerType;
					dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
				}

				public ChangeType KCLFqDafPxsfUaVMOnXaCoPHqJIN(bool P_0, int P_1, int P_2)
				{
					ChangeType changeType = ChangeType.None;
					if (voHHTveCkwpJYLrdIFQOwoGzelU != P_0)
					{
						voHHTveCkwpJYLrdIFQOwoGzelU = P_0;
						changeType = (ChangeType)((int)changeType | (P_0 ? 1 : 2));
						if (P_0)
						{
							UdRaEyVNzeQmlXdePtFgUZmOqma = P_1;
							nZoOiWFbSzkxRviXQbGJPvfNvSl = P_2;
							return changeType;
						}
						dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
						return changeType;
					}
					if (UdRaEyVNzeQmlXdePtFgUZmOqma != P_1)
					{
						UdRaEyVNzeQmlXdePtFgUZmOqma = P_1;
						changeType |= ChangeType.IdentityChanged;
					}
					if (nZoOiWFbSzkxRviXQbGJPvfNvSl != P_2)
					{
						nZoOiWFbSzkxRviXQbGJPvfNvSl = P_2;
						changeType |= ChangeType.IdentityChanged;
					}
					return changeType;
				}

				private void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
				{
					voHHTveCkwpJYLrdIFQOwoGzelU = false;
					UdRaEyVNzeQmlXdePtFgUZmOqma = -1;
					nZoOiWFbSzkxRviXQbGJPvfNvSl = -1;
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

			private readonly int fesZInGMVrPlIXZTxmCdSmHFAuy;

			private readonly int[] CHfvyYrGYmAiFfvVBcDwVawJuBy;

			private readonly int[] yKkGVuFwmJFohHWmzJrYUfpNPlLG;

			private readonly int[] muMNRJVEjoqvZyEjygNYjEuNeMSq;

			private readonly IExternalTools tjCHjoFEebgaqOnGSdpCNMaozRg;

			private readonly aKKMkpjPBbGirqUyQHPpIHecAuS[] CnmpBCjuzybqfONBbDLSbAVrusmH;

			private readonly aKKMkpjPBbGirqUyQHPpIHecAuS[] ePqWtHJKUYPGEpxGbdJJSdagbNq;

			private readonly aKKMkpjPBbGirqUyQHPpIHecAuS[] JNEzczqLeWHmmIbYndUNGplaMrvS;

			private readonly List<JqZFzvSsmpGjkDkBjXzvOJOtHUB> aPSxrvTVMOpIndhwhZHyLTeqtjH;

			private readonly List<dlhFbzAPwcPOvXXdtuKOCUvnSEW> LiFQQasqKQtqZxgEHTXSiNDfgXE;

			private Action<JqZFzvSsmpGjkDkBjXzvOJOtHUB> sUMAtVCfTbIyUNDgSayGgVfDZylK;

			private Action<dlhFbzAPwcPOvXXdtuKOCUvnSEW> XCUzbTBtAITJcCWRHeyMvZMdOTi;

			[CompilerGenerated]
			private static Func<aKKMkpjPBbGirqUyQHPpIHecAuS> QdcLsRDhWBgEwdpblNLsOasvBFY;

			[CompilerGenerated]
			private static Func<aKKMkpjPBbGirqUyQHPpIHecAuS> lOQcCRGEDAZVfMHZnMEpswIpjBVD;

			[CompilerGenerated]
			private static Func<aKKMkpjPBbGirqUyQHPpIHecAuS> LDLmDsvfHVpKxKAhJlObsDuRmDN;

			public event Action<JqZFzvSsmpGjkDkBjXzvOJOtHUB> ControllerConnectedEvent
			{
				add
				{
					Action<JqZFzvSsmpGjkDkBjXzvOJOtHUB> action = sUMAtVCfTbIyUNDgSayGgVfDZylK;
					Action<JqZFzvSsmpGjkDkBjXzvOJOtHUB> action2;
					do
					{
						action2 = action;
						Action<JqZFzvSsmpGjkDkBjXzvOJOtHUB> value2 = (Action<JqZFzvSsmpGjkDkBjXzvOJOtHUB>)Delegate.Combine(action2, value);
						action = Interlocked.CompareExchange(ref sUMAtVCfTbIyUNDgSayGgVfDZylK, value2, action2);
					}
					while ((object)action != action2);
				}
				remove
				{
					Action<JqZFzvSsmpGjkDkBjXzvOJOtHUB> action = sUMAtVCfTbIyUNDgSayGgVfDZylK;
					Action<JqZFzvSsmpGjkDkBjXzvOJOtHUB> action2;
					do
					{
						action2 = action;
						Action<JqZFzvSsmpGjkDkBjXzvOJOtHUB> value2 = (Action<JqZFzvSsmpGjkDkBjXzvOJOtHUB>)Delegate.Remove(action2, value);
						action = Interlocked.CompareExchange(ref sUMAtVCfTbIyUNDgSayGgVfDZylK, value2, action2);
					}
					while ((object)action != action2);
				}
			}

			public event Action<dlhFbzAPwcPOvXXdtuKOCUvnSEW> ControllerDisconnectedEvent
			{
				add
				{
					Action<dlhFbzAPwcPOvXXdtuKOCUvnSEW> action = XCUzbTBtAITJcCWRHeyMvZMdOTi;
					Action<dlhFbzAPwcPOvXXdtuKOCUvnSEW> action2;
					do
					{
						action2 = action;
						Action<dlhFbzAPwcPOvXXdtuKOCUvnSEW> value2 = (Action<dlhFbzAPwcPOvXXdtuKOCUvnSEW>)Delegate.Combine(action2, value);
						action = Interlocked.CompareExchange(ref XCUzbTBtAITJcCWRHeyMvZMdOTi, value2, action2);
					}
					while ((object)action != action2);
				}
				remove
				{
					Action<dlhFbzAPwcPOvXXdtuKOCUvnSEW> action = XCUzbTBtAITJcCWRHeyMvZMdOTi;
					Action<dlhFbzAPwcPOvXXdtuKOCUvnSEW> action2;
					do
					{
						action2 = action;
						Action<dlhFbzAPwcPOvXXdtuKOCUvnSEW> value2 = (Action<dlhFbzAPwcPOvXXdtuKOCUvnSEW>)Delegate.Remove(action2, value);
						action = Interlocked.CompareExchange(ref XCUzbTBtAITJcCWRHeyMvZMdOTi, value2, action2);
					}
					while ((object)action != action2);
				}
			}

			public robegNEBCPaHIRZRVXUeYBtvxUL(int maxPlayers)
			{
				fesZInGMVrPlIXZTxmCdSmHFAuy = maxPlayers;
				CHfvyYrGYmAiFfvVBcDwVawJuBy = new int[maxPlayers];
				yKkGVuFwmJFohHWmzJrYUfpNPlLG = new int[maxPlayers];
				muMNRJVEjoqvZyEjygNYjEuNeMSq = new int[maxPlayers];
				tjCHjoFEebgaqOnGSdpCNMaozRg = UnityTools.externalTools;
				CnmpBCjuzybqfONBbDLSbAVrusmH = new aKKMkpjPBbGirqUyQHPpIHecAuS[maxPlayers];
				ArrayTools.Populate(CnmpBCjuzybqfONBbDLSbAVrusmH, () => new aKKMkpjPBbGirqUyQHPpIHecAuS(smsZnrfodXmyATytXSHkAhInxFC.BaseControllerType.Gamepad));
				ePqWtHJKUYPGEpxGbdJJSdagbNq = new aKKMkpjPBbGirqUyQHPpIHecAuS[maxPlayers];
				ArrayTools.Populate(ePqWtHJKUYPGEpxGbdJJSdagbNq, () => new aKKMkpjPBbGirqUyQHPpIHecAuS(smsZnrfodXmyATytXSHkAhInxFC.BaseControllerType.Special));
				JNEzczqLeWHmmIbYndUNGplaMrvS = new aKKMkpjPBbGirqUyQHPpIHecAuS[maxPlayers];
				ArrayTools.Populate(JNEzczqLeWHmmIbYndUNGplaMrvS, () => new aKKMkpjPBbGirqUyQHPpIHecAuS(smsZnrfodXmyATytXSHkAhInxFC.BaseControllerType.Aim));
				aPSxrvTVMOpIndhwhZHyLTeqtjH = new List<JqZFzvSsmpGjkDkBjXzvOJOtHUB>(2);
				LiFQQasqKQtqZxgEHTXSiNDfgXE = new List<dlhFbzAPwcPOvXXdtuKOCUvnSEW>(2);
			}

			public void QTPiZFmnRsxmyQYmMuIoBQkOtfg()
			{
				tjCHjoFEebgaqOnGSdpCNMaozRg.PS4Input_PadGetUsersHandles2(fesZInGMVrPlIXZTxmCdSmHFAuy, CHfvyYrGYmAiFfvVBcDwVawJuBy);
				tjCHjoFEebgaqOnGSdpCNMaozRg.PS4Input_SpecialGetUsersHandles2(fesZInGMVrPlIXZTxmCdSmHFAuy, yKkGVuFwmJFohHWmzJrYUfpNPlLG);
				tjCHjoFEebgaqOnGSdpCNMaozRg.PS4Input_AimGetUsersHandles2(fesZInGMVrPlIXZTxmCdSmHFAuy, muMNRJVEjoqvZyEjygNYjEuNeMSq);
				for (int i = 0; i < fesZInGMVrPlIXZTxmCdSmHFAuy; i++)
				{
					try
					{
						aKKMkpjPBbGirqUyQHPpIHecAuS aKKMkpjPBbGirqUyQHPpIHecAuS2 = CnmpBCjuzybqfONBbDLSbAVrusmH[i];
						bool flag = tjCHjoFEebgaqOnGSdpCNMaozRg.PS4Input_PadIsConnected(i);
						if (aKKMkpjPBbGirqUyQHPpIHecAuS2.voHHTveCkwpJYLrdIFQOwoGzelU || flag)
						{
							KxOdvximTjjajSWDGryHtSiatxyC(i, aKKMkpjPBbGirqUyQHPpIHecAuS2, CHfvyYrGYmAiFfvVBcDwVawJuBy[i], flag, "Gamepad");
						}
						aKKMkpjPBbGirqUyQHPpIHecAuS aKKMkpjPBbGirqUyQHPpIHecAuS3 = ePqWtHJKUYPGEpxGbdJJSdagbNq[i];
						bool flag2 = tjCHjoFEebgaqOnGSdpCNMaozRg.PS4Input_SpecialIsConnected(i);
						if (aKKMkpjPBbGirqUyQHPpIHecAuS3.voHHTveCkwpJYLrdIFQOwoGzelU || flag2)
						{
							KxOdvximTjjajSWDGryHtSiatxyC(i, aKKMkpjPBbGirqUyQHPpIHecAuS3, yKkGVuFwmJFohHWmzJrYUfpNPlLG[i], flag2, "Special");
						}
						aKKMkpjPBbGirqUyQHPpIHecAuS aKKMkpjPBbGirqUyQHPpIHecAuS4 = JNEzczqLeWHmmIbYndUNGplaMrvS[i];
						bool flag3 = tjCHjoFEebgaqOnGSdpCNMaozRg.PS4Input_AimIsConnected(i);
						if (aKKMkpjPBbGirqUyQHPpIHecAuS4.voHHTveCkwpJYLrdIFQOwoGzelU || flag3)
						{
							KxOdvximTjjajSWDGryHtSiatxyC(i, aKKMkpjPBbGirqUyQHPpIHecAuS4, muMNRJVEjoqvZyEjygNYjEuNeMSq[i], flag3, "Aim");
						}
						if (LiFQQasqKQtqZxgEHTXSiNDfgXE.Count > 0)
						{
							for (int j = 0; j < LiFQQasqKQtqZxgEHTXSiNDfgXE.Count; j++)
							{
								try
								{
									XCUzbTBtAITJcCWRHeyMvZMdOTi(LiFQQasqKQtqZxgEHTXSiNDfgXE[j]);
								}
								catch (Exception ex)
								{
									Logger.LogError("An exception occurred in controller monitor Controller Disconnect Event callback.\n" + ex);
								}
							}
							LiFQQasqKQtqZxgEHTXSiNDfgXE.Clear();
						}
						if (aPSxrvTVMOpIndhwhZHyLTeqtjH.Count <= 0)
						{
							continue;
						}
						for (int k = 0; k < aPSxrvTVMOpIndhwhZHyLTeqtjH.Count; k++)
						{
							try
							{
								sUMAtVCfTbIyUNDgSayGgVfDZylK(aPSxrvTVMOpIndhwhZHyLTeqtjH[k]);
							}
							catch (Exception ex2)
							{
								Logger.LogError("An exception occurred in controller monitor Controller Connect Event callback.\n" + ex2);
							}
						}
						aPSxrvTVMOpIndhwhZHyLTeqtjH.Clear();
					}
					catch (Exception ex3)
					{
						Logger.LogError("An exception occurred during controller monitor update.\n" + ex3);
					}
				}
			}

			private void KxOdvximTjjajSWDGryHtSiatxyC(int P_0, aKKMkpjPBbGirqUyQHPpIHecAuS P_1, int P_2, bool P_3, string P_4)
			{
				int num = tjCHjoFEebgaqOnGSdpCNMaozRg.PS4Input_GetDeviceClassForHandle(P_2);
				int udRaEyVNzeQmlXdePtFgUZmOqma = P_1.UdRaEyVNzeQmlXdePtFgUZmOqma;
				ChangeType changeType = P_1.KCLFqDafPxsfUaVMOnXaCoPHqJIN(P_3, P_2, num);
				if (changeType != ChangeType.None)
				{
					if ((changeType & ChangeType.Disconnected) != ChangeType.None || (P_1.voHHTveCkwpJYLrdIFQOwoGzelU && (changeType & ChangeType.IdentityChanged) != ChangeType.None))
					{
						LiFQQasqKQtqZxgEHTXSiNDfgXE.Add(new dlhFbzAPwcPOvXXdtuKOCUvnSEW(P_0, udRaEyVNzeQmlXdePtFgUZmOqma, P_1.pAUZutcIWFLfyIuyDiNKiSukBQE));
					}
					if ((changeType & ChangeType.Connected) != ChangeType.None || (P_1.voHHTveCkwpJYLrdIFQOwoGzelU && (changeType & ChangeType.IdentityChanged) != ChangeType.None))
					{
						aPSxrvTVMOpIndhwhZHyLTeqtjH.Add(new JqZFzvSsmpGjkDkBjXzvOJOtHUB(P_0, P_1.UdRaEyVNzeQmlXdePtFgUZmOqma, P_1.nZoOiWFbSzkxRviXQbGJPvfNvSl, P_1.pAUZutcIWFLfyIuyDiNKiSukBQE));
					}
				}
			}

			[CompilerGenerated]
			private static aKKMkpjPBbGirqUyQHPpIHecAuS bLodcsddrHTEuWTjOteQwJmDvMug()
			{
				return new aKKMkpjPBbGirqUyQHPpIHecAuS(smsZnrfodXmyATytXSHkAhInxFC.BaseControllerType.Gamepad);
			}

			[CompilerGenerated]
			private static aKKMkpjPBbGirqUyQHPpIHecAuS vdDPquUVhIygxunWnvPcgIvBxCP()
			{
				return new aKKMkpjPBbGirqUyQHPpIHecAuS(smsZnrfodXmyATytXSHkAhInxFC.BaseControllerType.Special);
			}

			[CompilerGenerated]
			private static aKKMkpjPBbGirqUyQHPpIHecAuS GVnqNLNJumCigNUfxLKlLJWjhoO()
			{
				return new aKKMkpjPBbGirqUyQHPpIHecAuS(smsZnrfodXmyATytXSHkAhInxFC.BaseControllerType.Aim);
			}
		}

		private abstract class smsZnrfodXmyATytXSHkAhInxFC : Joystick, YrXBrlhKsdGlkNpligiCaWGZnhZ, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource
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

			protected enum ktFMadchANQDttphwyRkxCqHawo
			{
				SaidbJQgZbwJIUhEOfXVjHpYIsz = 0,
				TaEYhSpCoEPTUxTzIsWIWcKXILWd = 1,
				ldcMNIWBZGgXXCgxdDXsMasYOqzl = 2
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

			public class tOZwqQFNqLyLbSZgTFzldvFGDGT
			{
				public readonly int JDyNNdOScJLywOHcbmcaJdgZeIE;

				public readonly int CtHmgLQvreiWMWnBZZLsTLZpuCY;

				public readonly float DZyFJBhZEwfIRAphmMcpnLgtcgv;

				public readonly int hFnuhMXoYvgyCariIlYOShuWnqMq;

				public readonly int RTwpGgplArsxZVIDLZhyOKhOdAg;

				public tOZwqQFNqLyLbSZgTFzldvFGDGT(int axisCount, int buttonCount, float dpadDeadzone, int vibrationMotorCount, int maxTouches)
				{
					JDyNNdOScJLywOHcbmcaJdgZeIE = axisCount;
					CtHmgLQvreiWMWnBZZLsTLZpuCY = buttonCount;
					DZyFJBhZEwfIRAphmMcpnLgtcgv = dpadDeadzone;
					hFnuhMXoYvgyCariIlYOShuWnqMq = vibrationMotorCount;
					RTwpGgplArsxZVIDLZhyOKhOdAg = maxTouches;
				}
			}

			private static int uJnimpzbdeAfRfKPoWszbjcibTo;

			protected readonly int ivfdKpZALpQIAdtIdHmkpPFkwfq;

			protected readonly int WLSYubQIFtUFMlkFACrxsVxbGSB;

			protected readonly BaseControllerType VIVjDidfzMKPvfajNsDHmoiwxBh;

			protected readonly tOZwqQFNqLyLbSZgTFzldvFGDGT UpajDMAVHhTDzrPYmQEkWoePXkN;

			protected readonly int FpdtqZZTWeqPcFFnqYkufVBjbtW;

			protected readonly float[] sQhbUuNwmsBDKfoaSHhArUOzmDCV;

			private readonly LoggedInUser ZTNASxTokmePDfysljAAoyGtCMB;

			protected readonly ControllerType wZYPyxmKgRSHjYJwEjuLiELShEK;

			private readonly Func<int, bool> YnFcpgUAVYfYxfygEAOiHMkfscGt;

			private readonly Action<int, int, int> betHAacKaqNxPZvFaVpBSBpmHVE;

			private readonly Action<int, int, int, int> ieTjsodIzAGgCsAQvWtRtFFYbhB;

			private readonly Action<int> yQFKXTdrBEGlUgeaehEoNGJxpsU;

			private Action<int, bool> BIwEbtJXakUBcFWFtkNAFufnZiT;

			private Action<int, bool> NQbwCkVCJRLBApTstzmEKRQUYug;

			private Action<int, bool> jdyYqPUEZpFoCcezeKlKDSeDSGok;

			private Action<int> kAkOrRDnFylANKcdZEUSRkpHbsP;

			private Func<int, Vector3> UtRvlVJJGePMzTcGcXoSBncXcFP;

			private Func<int, Vector3> KWYyGzOoAIEvaGZvFjjGODKbuHZ;

			private Func<int, Vector4> wGXmFclRZnDeiOyHWpFjXJIDCuH;

			private static int NextSystemId
			{
				get
				{
					int result = uJnimpzbdeAfRfKPoWszbjcibTo;
					uJnimpzbdeAfRfKPoWszbjcibTo++;
					return result;
				}
			}

			protected LoggedInUser user
			{
				get
				{
					UnityTools.externalTools.PS4Input_GetUsersDetails(ivfdKpZALpQIAdtIdHmkpPFkwfq, ZTNASxTokmePDfysljAAoyGtCMB);
					return ZTNASxTokmePDfysljAAoyGtCMB;
				}
			}

			public ControllerType type => wZYPyxmKgRSHjYJwEjuLiELShEK;

			public int playerId => ivfdKpZALpQIAdtIdHmkpPFkwfq;

			public int handle => WLSYubQIFtUFMlkFACrxsVxbGSB;

			public BaseControllerType baseControllerType => VIVjDidfzMKPvfajNsDHmoiwxBh;

			private bool IsConnectedNow => YnFcpgUAVYfYxfygEAOiHMkfscGt(ivfdKpZALpQIAdtIdHmkpPFkwfq);

			public int vibrationMotorCount => UpajDMAVHhTDzrPYmQEkWoePXkN.hFnuhMXoYvgyCariIlYOShuWnqMq;

			public static smsZnrfodXmyATytXSHkAhInxFC AxGMnpcloIAUTQTSFCdghQatHHxd(ControllerType P_0, int P_1, int P_2, int P_3)
			{
				return P_0 switch
				{
					ControllerType.Unknown => null, 
					ControllerType.Gamepad => new lHplDqxDJqXWhBVzbUSaIipFvel("Controller " + (P_2 + 1), P_2, P_2 + 1, P_3), 
					ControllerType.Aim => new VVPGbrhKwgwWMzTZkPdLdTwEjyi("PS VR Aim Controller " + (P_2 + 1), P_2, P_2 + 13, P_3), 
					_ => GLpgYCwTQSagOZhbpIyFbUkWmkeT.AxGMnpcloIAUTQTSFCdghQatHHxd(P_1, P_2, P_3), 
				};
			}

			protected smsZnrfodXmyATytXSHkAhInxFC(ControllerType type, BaseControllerType baseControllerType, string name, int playerId, int unityJoystickId, int handle, tOZwqQFNqLyLbSZgTFzldvFGDGT capabilities)
				: base(name, NextSystemId, unityJoystickId, capabilities.JDyNNdOScJLywOHcbmcaJdgZeIE, capabilities.CtHmgLQvreiWMWnBZZLsTLZpuCY)
			{
				if (capabilities == null)
				{
					throw new ArgumentNullException("capabilities");
				}
				wZYPyxmKgRSHjYJwEjuLiELShEK = type;
				VIVjDidfzMKPvfajNsDHmoiwxBh = baseControllerType;
				ivfdKpZALpQIAdtIdHmkpPFkwfq = playerId;
				FpdtqZZTWeqPcFFnqYkufVBjbtW = unityJoystickId - 1;
				UpajDMAVHhTDzrPYmQEkWoePXkN = capabilities;
				WLSYubQIFtUFMlkFACrxsVxbGSB = handle;
				ZTNASxTokmePDfysljAAoyGtCMB = new LoggedInUser();
				_customName = name;
				sQhbUuNwmsBDKfoaSHhArUOzmDCV = new float[capabilities.hFnuhMXoYvgyCariIlYOShuWnqMq];
				base.supportsVibration = capabilities.hFnuhMXoYvgyCariIlYOShuWnqMq > 0;
				switch (VIVjDidfzMKPvfajNsDHmoiwxBh)
				{
				case BaseControllerType.Gamepad:
					YnFcpgUAVYfYxfygEAOiHMkfscGt = UnityTools.externalTools.PS4Input_PadIsConnected;
					betHAacKaqNxPZvFaVpBSBpmHVE = UnityTools.externalTools.PS4Input_PadSetVibration;
					ieTjsodIzAGgCsAQvWtRtFFYbhB = UnityTools.externalTools.PS4Input_PadSetLightBar;
					yQFKXTdrBEGlUgeaehEoNGJxpsU = UnityTools.externalTools.PS4Input_PadResetLightBar;
					BIwEbtJXakUBcFWFtkNAFufnZiT = UnityTools.externalTools.PS4Input_PadSetMotionSensorState;
					NQbwCkVCJRLBApTstzmEKRQUYug = UnityTools.externalTools.PS4Input_PadSetTiltCorrectionState;
					jdyYqPUEZpFoCcezeKlKDSeDSGok = UnityTools.externalTools.PS4Input_PadSetAngularVelocityDeadbandState;
					kAkOrRDnFylANKcdZEUSRkpHbsP = UnityTools.externalTools.PS4Input_PadResetOrientation;
					UtRvlVJJGePMzTcGcXoSBncXcFP = UnityTools.externalTools.PS4Input_GetLastAcceleration;
					KWYyGzOoAIEvaGZvFjjGODKbuHZ = UnityTools.externalTools.PS4Input_GetLastGyro;
					wGXmFclRZnDeiOyHWpFjXJIDCuH = UnityTools.externalTools.PS4Input_GetLastOrientation;
					break;
				case BaseControllerType.Special:
					YnFcpgUAVYfYxfygEAOiHMkfscGt = UnityTools.externalTools.PS4Input_SpecialIsConnected;
					betHAacKaqNxPZvFaVpBSBpmHVE = UnityTools.externalTools.PS4Input_SpecialSetVibration;
					ieTjsodIzAGgCsAQvWtRtFFYbhB = UnityTools.externalTools.PS4Input_SpecialSetLightSphere;
					yQFKXTdrBEGlUgeaehEoNGJxpsU = UnityTools.externalTools.PS4Input_SpecialResetLightSphere;
					BIwEbtJXakUBcFWFtkNAFufnZiT = UnityTools.externalTools.PS4Input_SpecialSetMotionSensorState;
					NQbwCkVCJRLBApTstzmEKRQUYug = UnityTools.externalTools.PS4Input_SpecialSetTiltCorrectionState;
					jdyYqPUEZpFoCcezeKlKDSeDSGok = UnityTools.externalTools.PS4Input_SpecialSetAngularVelocityDeadbandState;
					kAkOrRDnFylANKcdZEUSRkpHbsP = UnityTools.externalTools.PS4Input_SpecialResetOrientation;
					UtRvlVJJGePMzTcGcXoSBncXcFP = UnityTools.externalTools.PS4Input_SpecialGetLastAcceleration;
					KWYyGzOoAIEvaGZvFjjGODKbuHZ = UnityTools.externalTools.PS4Input_SpecialGetLastGyro;
					wGXmFclRZnDeiOyHWpFjXJIDCuH = UnityTools.externalTools.PS4Input_SpecialGetLastOrientation;
					break;
				case BaseControllerType.Aim:
					YnFcpgUAVYfYxfygEAOiHMkfscGt = UnityTools.externalTools.PS4Input_AimIsConnected;
					betHAacKaqNxPZvFaVpBSBpmHVE = UnityTools.externalTools.PS4Input_AimSetVibration;
					ieTjsodIzAGgCsAQvWtRtFFYbhB = UnityTools.externalTools.PS4Input_AimSetLightSphere;
					yQFKXTdrBEGlUgeaehEoNGJxpsU = UnityTools.externalTools.PS4Input_AimResetLightSphere;
					BIwEbtJXakUBcFWFtkNAFufnZiT = UnityTools.externalTools.PS4Input_AimSetMotionSensorState;
					NQbwCkVCJRLBApTstzmEKRQUYug = UnityTools.externalTools.PS4Input_AimSetTiltCorrectionState;
					jdyYqPUEZpFoCcezeKlKDSeDSGok = UnityTools.externalTools.PS4Input_AimSetAngularVelocityDeadbandState;
					kAkOrRDnFylANKcdZEUSRkpHbsP = UnityTools.externalTools.PS4Input_AimResetOrientation;
					UtRvlVJJGePMzTcGcXoSBncXcFP = UnityTools.externalTools.PS4Input_GetLastAcceleration;
					KWYyGzOoAIEvaGZvFjjGODKbuHZ = UnityTools.externalTools.PS4Input_GetLastGyro;
					wGXmFclRZnDeiOyHWpFjXJIDCuH = UnityTools.externalTools.PS4Input_GetLastOrientation;
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public virtual void QTPiZFmnRsxmyQYmMuIoBQkOtfg()
			{
				eCIGQsHyQbbhZbivOlTdMelKKAxc();
			}

			public int CpDdzGPDGNInYkPAhekOSmJrapI()
			{
				return WLSYubQIFtUFMlkFACrxsVxbGSB;
			}

			int YrXBrlhKsdGlkNpligiCaWGZnhZ.CpDdzGPDGNInYkPAhekOSmJrapI()
			{
				//ILSpy generated this explicit interface implementation from .override directive in CpDdzGPDGNInYkPAhekOSmJrapI
				return this.CpDdzGPDGNInYkPAhekOSmJrapI();
			}

			public int ToSJaQUUsuXVHqyptCmZYHEKEGl()
			{
				return user.userId;
			}

			int YrXBrlhKsdGlkNpligiCaWGZnhZ.ToSJaQUUsuXVHqyptCmZYHEKEGl()
			{
				//ILSpy generated this explicit interface implementation from .override directive in ToSJaQUUsuXVHqyptCmZYHEKEGl
				return this.ToSJaQUUsuXVHqyptCmZYHEKEGl();
			}

			public int HiptkvIzblAdhsHlqeeKVnyAeJl()
			{
				return user.status;
			}

			int YrXBrlhKsdGlkNpligiCaWGZnhZ.HiptkvIzblAdhsHlqeeKVnyAeJl()
			{
				//ILSpy generated this explicit interface implementation from .override directive in HiptkvIzblAdhsHlqeeKVnyAeJl
				return this.HiptkvIzblAdhsHlqeeKVnyAeJl();
			}

			public bool NECADNTmvWmyeglKuUNEtfQuKDm()
			{
				return user.primaryUser;
			}

			bool YrXBrlhKsdGlkNpligiCaWGZnhZ.NECADNTmvWmyeglKuUNEtfQuKDm()
			{
				//ILSpy generated this explicit interface implementation from .override directive in NECADNTmvWmyeglKuUNEtfQuKDm
				return this.NECADNTmvWmyeglKuUNEtfQuKDm();
			}

			public Color HOdlKWlsfvkrVwFOSZZOMootFKL()
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

			Color YrXBrlhKsdGlkNpligiCaWGZnhZ.HOdlKWlsfvkrVwFOSZZOMootFKL()
			{
				//ILSpy generated this explicit interface implementation from .override directive in HOdlKWlsfvkrVwFOSZZOMootFKL
				return this.HOdlKWlsfvkrVwFOSZZOMootFKL();
			}

			public int mYUyKjoCcBnroCuxaeeBbfSyyDX()
			{
				return user.color;
			}

			int YrXBrlhKsdGlkNpligiCaWGZnhZ.mYUyKjoCcBnroCuxaeeBbfSyyDX()
			{
				//ILSpy generated this explicit interface implementation from .override directive in mYUyKjoCcBnroCuxaeeBbfSyyDX
				return this.mYUyKjoCcBnroCuxaeeBbfSyyDX();
			}

			public string NuvNLUNESmefzCgNbOyrZuQKOwH()
			{
				return user.userName;
			}

			string YrXBrlhKsdGlkNpligiCaWGZnhZ.NuvNLUNESmefzCgNbOyrZuQKOwH()
			{
				//ILSpy generated this explicit interface implementation from .override directive in NuvNLUNESmefzCgNbOyrZuQKOwH
				return this.NuvNLUNESmefzCgNbOyrZuQKOwH();
			}

			public void StopVibration()
			{
				Array.Clear(sQhbUuNwmsBDKfoaSHhArUOzmDCV, 0, sQhbUuNwmsBDKfoaSHhArUOzmDCV.Length);
				CSTGiOCydNlSEHNbEOOsPSCTXiTq();
			}

			public void SetVibration(int motorIndex, float value)
			{
				if ((uint)motorIndex <= (uint)UpajDMAVHhTDzrPYmQEkWoePXkN.hFnuhMXoYvgyCariIlYOShuWnqMq)
				{
					sQhbUuNwmsBDKfoaSHhArUOzmDCV[motorIndex] = value;
					CSTGiOCydNlSEHNbEOOsPSCTXiTq();
				}
			}

			public float GetVibration(int motorIndex)
			{
				if ((uint)motorIndex > (uint)UpajDMAVHhTDzrPYmQEkWoePXkN.hFnuhMXoYvgyCariIlYOShuWnqMq)
				{
					return 0f;
				}
				return sQhbUuNwmsBDKfoaSHhArUOzmDCV[motorIndex];
			}

			public void SetMotionSensorState(bool enabled)
			{
				BIwEbtJXakUBcFWFtkNAFufnZiT(ivfdKpZALpQIAdtIdHmkpPFkwfq, enabled);
			}

			public void SetTiltCorrectionState(bool enabled)
			{
				NQbwCkVCJRLBApTstzmEKRQUYug(ivfdKpZALpQIAdtIdHmkpPFkwfq, enabled);
			}

			public void SetAngularVelocityDeadbandState(bool enabled)
			{
				jdyYqPUEZpFoCcezeKlKDSeDSGok(ivfdKpZALpQIAdtIdHmkpPFkwfq, enabled);
			}

			public void ResetOrientation()
			{
				kAkOrRDnFylANKcdZEUSRkpHbsP(ivfdKpZALpQIAdtIdHmkpPFkwfq);
			}

			public Vector3 GetLastAcceleration()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				Vector3 result = UtRvlVJJGePMzTcGcXoSBncXcFP(ivfdKpZALpQIAdtIdHmkpPFkwfq);
				klPHkhJVvVcePIUQnuIeBCHkrqa(ref result);
				return result;
			}

			public Vector3 GetLastAccelerationRaw()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				return UtRvlVJJGePMzTcGcXoSBncXcFP(ivfdKpZALpQIAdtIdHmkpPFkwfq);
			}

			public Vector3 GetLastGyro()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				Vector3 result = KWYyGzOoAIEvaGZvFjjGODKbuHZ(ivfdKpZALpQIAdtIdHmkpPFkwfq);
				uAPtrWUbPXQoHhTqKhRjUbccauy(ref result);
				return result;
			}

			public Vector3 GetLastGyroRaw()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				return KWYyGzOoAIEvaGZvFjjGODKbuHZ(ivfdKpZALpQIAdtIdHmkpPFkwfq);
			}

			public Quaternion GetLastOrientation()
			{
				if (!IsConnectedNow)
				{
					return Quaternion.identity;
				}
				Vector4 vector = wGXmFclRZnDeiOyHWpFjXJIDCuH(ivfdKpZALpQIAdtIdHmkpPFkwfq);
				return new Quaternion(vector.x * -1f, vector.y, vector.z, vector.w);
			}

			public Quaternion GetLastOrientationRaw()
			{
				if (!IsConnectedNow)
				{
					return Quaternion.identity;
				}
				Vector4 vector = wGXmFclRZnDeiOyHWpFjXJIDCuH(ivfdKpZALpQIAdtIdHmkpPFkwfq);
				return new Quaternion(vector.x, vector.y, vector.z, vector.w);
			}

			public void SetLightColor(int red, int green, int blue)
			{
				ieTjsodIzAGgCsAQvWtRtFFYbhB(ivfdKpZALpQIAdtIdHmkpPFkwfq, red, green, blue);
			}

			public void ResetLight()
			{
				yQFKXTdrBEGlUgeaehEoNGJxpsU(ivfdKpZALpQIAdtIdHmkpPFkwfq);
			}

			protected virtual void eCIGQsHyQbbhZbivOlTdMelKKAxc()
			{
				int joystickId = FpdtqZZTWeqPcFFnqYkufVBjbtW + 1;
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
				buttons[10].value = joystickAxisValueByJoystickId2 > UpajDMAVHhTDzrPYmQEkWoePXkN.DZyFJBhZEwfIRAphmMcpnLgtcgv;
				buttons[11].value = joystickAxisValueByJoystickId > UpajDMAVHhTDzrPYmQEkWoePXkN.DZyFJBhZEwfIRAphmMcpnLgtcgv;
				buttons[12].value = joystickAxisValueByJoystickId2 < 0f - UpajDMAVHhTDzrPYmQEkWoePXkN.DZyFJBhZEwfIRAphmMcpnLgtcgv;
				buttons[13].value = joystickAxisValueByJoystickId < 0f - UpajDMAVHhTDzrPYmQEkWoePXkN.DZyFJBhZEwfIRAphmMcpnLgtcgv;
				IList<Axis> axes = base.Axes;
				axes[0].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 0);
				axes[1].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 1);
				axes[2].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 3);
				axes[3].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 4);
				axes[4].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 7);
				axes[5].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 2);
			}

			protected void CSTGiOCydNlSEHNbEOOsPSCTXiTq()
			{
				if (UpajDMAVHhTDzrPYmQEkWoePXkN.hFnuhMXoYvgyCariIlYOShuWnqMq != 0)
				{
					betHAacKaqNxPZvFaVpBSBpmHVE(ivfdKpZALpQIAdtIdHmkpPFkwfq, MFBXhfYbnmloGmxINMpzWIdyskL(sQhbUuNwmsBDKfoaSHhArUOzmDCV[0]), MFBXhfYbnmloGmxINMpzWIdyskL(sQhbUuNwmsBDKfoaSHhArUOzmDCV[1]));
				}
			}

			public static int MFBXhfYbnmloGmxINMpzWIdyskL(float P_0)
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

			public static void klPHkhJVvVcePIUQnuIeBCHkrqa(ref Vector3 P_0)
			{
				P_0.x *= -1f;
				P_0.y *= -1f;
			}

			public static void uAPtrWUbPXQoHhTqKhRjUbccauy(ref Vector3 P_0)
			{
				P_0.x *= -1f;
				P_0.y *= -1f;
			}

			public static bool jMxvsTIPUKkpRwAGYMwqXuJeUXy(int P_0, out ControllerType P_1)
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

		private sealed class lHplDqxDJqXWhBVzbUSaIipFvel : smsZnrfodXmyATytXSHkAhInxFC, YrXBrlhKsdGlkNpligiCaWGZnhZ, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource, IPS4ControllerExtensionSourceTouchPad, IPS4GamepadExtensionSource
		{
			private const int skotmctbDSWIawJPITTDnlfQMrI = 6;

			private const int iipHpfgLozalWqeLcbTeIaNNpzGR = 14;

			private const float sEdvWSRHRyboTkGXiuuWesiBvbm = 0.05f;

			private const int kOQKAcqOirVfliZtPgyYffXpDLq = 2;

			private const int UreenoAwOzpNisAaPCuZOeBoOFD = 2;

			private int EMmCNHMxthyPbswflJgFbmnEYIr;

			private int bIZypASdSROsUiGJIeRGjryaHTvT;

			private Vector2 FdbLJlDmsiCGVOwJSAFolGuCSUD;

			private int uftBitJEsRMBAhVxiWgISgYTrTuq;

			private Vector2 DjCYBVIsrcgJCOumTzfaZKQNaE;

			private ktFMadchANQDttphwyRkxCqHawo WpntuIiYaGJtdDvnePgVEQljkza;

			private int ogNSATzBmBTKfmkbMbCuWSMkZTI;

			private int wnsESouKBQrzOvHbJBDcSiXniaA;

			private int okqaoRdweQDLORacBZxoIUcuVwT;

			private int TJfRrKSbIYHKAbRyHbAbDeApFNp;

			private float HZZDgzTtNlGYjfkWZzCfHyLHCyK;

			public int maxTouches => UpajDMAVHhTDzrPYmQEkWoePXkN.RTwpGgplArsxZVIDLZhyOKhOdAg;

			public lHplDqxDJqXWhBVzbUSaIipFvel(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Gamepad, BaseControllerType.Gamepad, name, playerId, unityJoystickId, handle, new tOZwqQFNqLyLbSZgTFzldvFGDGT(6, 14, 0.05f, 2, 2))
			{
				zrahqzhRyQTOPrjZKnMJjcgWSGl();
				base.extension = new PS4GamepadExtension(this);
			}

			public int GetConnectionType()
			{
				return (int)WpntuIiYaGJtdDvnePgVEQljkza;
			}

			public int GetAnalogDeadZoneLeft()
			{
				return okqaoRdweQDLORacBZxoIUcuVwT;
			}

			public int GetAnalogDeadZoneRight()
			{
				return TJfRrKSbIYHKAbRyHbAbDeApFNp;
			}

			public float GetTouchPixelDensity()
			{
				return HZZDgzTtNlGYjfkWZzCfHyLHCyK;
			}

			public int GetTouchpadResolutionX()
			{
				return ogNSATzBmBTKfmkbMbCuWSMkZTI;
			}

			public int GetTouchpadResolutionY()
			{
				return wnsESouKBQrzOvHbJBDcSiXniaA;
			}

			public int GetTouchCount()
			{
				return EMmCNHMxthyPbswflJgFbmnEYIr;
			}

			public int GetTouchId(int index)
			{
				if (index < 0 || index >= UpajDMAVHhTDzrPYmQEkWoePXkN.RTwpGgplArsxZVIDLZhyOKhOdAg)
				{
					return -1;
				}
				return index switch
				{
					0 => bIZypASdSROsUiGJIeRGjryaHTvT, 
					1 => uftBitJEsRMBAhVxiWgISgYTrTuq, 
					_ => -1, 
				};
			}

			public bool GetTouchPositionAbsByIndex(int index, out Vector2 position)
			{
				if (index < 0 || index >= UpajDMAVHhTDzrPYmQEkWoePXkN.RTwpGgplArsxZVIDLZhyOKhOdAg || !IsTouchingByIndex(index))
				{
					position = default(Vector2);
					return false;
				}
				switch (index)
				{
				case 0:
					position = FdbLJlDmsiCGVOwJSAFolGuCSUD;
					break;
				case 1:
					position = DjCYBVIsrcgJCOumTzfaZKQNaE;
					break;
				default:
					position = default(Vector2);
					return false;
				}
				return true;
			}

			public bool GetTouchPositionAbsByTouchId(int touchId, out Vector2 position)
			{
				int num = UTTlJBNNCacAkzaMXbZYHFjfXFiH(touchId);
				if (num < 0)
				{
					position = default(Vector2);
					return false;
				}
				return GetTouchPositionAbsByIndex(num, out position);
			}

			public bool GetTouchPositionByIndex(int index, out Vector2 position)
			{
				if (index < 0 || index >= UpajDMAVHhTDzrPYmQEkWoePXkN.RTwpGgplArsxZVIDLZhyOKhOdAg || !IsTouchingByIndex(index))
				{
					position = default(Vector2);
					return false;
				}
				switch (index)
				{
				case 0:
					position = new Vector2(FdbLJlDmsiCGVOwJSAFolGuCSUD.x, FdbLJlDmsiCGVOwJSAFolGuCSUD.y);
					break;
				case 1:
					position = new Vector2(DjCYBVIsrcgJCOumTzfaZKQNaE.x, DjCYBVIsrcgJCOumTzfaZKQNaE.y);
					break;
				default:
					position = default(Vector2);
					return false;
				}
				position.x /= ogNSATzBmBTKfmkbMbCuWSMkZTI;
				position.y /= wnsESouKBQrzOvHbJBDcSiXniaA;
				return true;
			}

			public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
			{
				int num = UTTlJBNNCacAkzaMXbZYHFjfXFiH(touchId);
				if (num < 0)
				{
					position = default(Vector2);
					return false;
				}
				return GetTouchPositionByIndex(num, out position);
			}

			public bool IsTouchingByIndex(int index)
			{
				if (index < 0 || index >= UpajDMAVHhTDzrPYmQEkWoePXkN.RTwpGgplArsxZVIDLZhyOKhOdAg)
				{
					return false;
				}
				return index < EMmCNHMxthyPbswflJgFbmnEYIr;
			}

			public bool IsTouchingByTouchId(int touchId)
			{
				if (touchId < 0)
				{
					return false;
				}
				int num = UTTlJBNNCacAkzaMXbZYHFjfXFiH(touchId);
				return num >= 0;
			}

			protected override void eCIGQsHyQbbhZbivOlTdMelKKAxc()
			{
				base.eCIGQsHyQbbhZbivOlTdMelKKAxc();
				UnityTools.externalTools.PS4Input_GetLastTouchData(ivfdKpZALpQIAdtIdHmkpPFkwfq, out EMmCNHMxthyPbswflJgFbmnEYIr, out var touch0x, out var touch0y, out bIZypASdSROsUiGJIeRGjryaHTvT, out var touch1x, out var touch1y, out uftBitJEsRMBAhVxiWgISgYTrTuq);
				FdbLJlDmsiCGVOwJSAFolGuCSUD.x = touch0x;
				FdbLJlDmsiCGVOwJSAFolGuCSUD.y = wnsESouKBQrzOvHbJBDcSiXniaA - touch0y;
				DjCYBVIsrcgJCOumTzfaZKQNaE.x = touch1x;
				DjCYBVIsrcgJCOumTzfaZKQNaE.y = wnsESouKBQrzOvHbJBDcSiXniaA - touch1y;
			}

			private void zrahqzhRyQTOPrjZKnMJjcgWSGl()
			{
				IExternalTools externalTools = UnityTools.externalTools;
				externalTools.PS4Input_GetPadControllerInformation(ivfdKpZALpQIAdtIdHmkpPFkwfq, out HZZDgzTtNlGYjfkWZzCfHyLHCyK, out ogNSATzBmBTKfmkbMbCuWSMkZTI, out wnsESouKBQrzOvHbJBDcSiXniaA, out okqaoRdweQDLORacBZxoIUcuVwT, out TJfRrKSbIYHKAbRyHbAbDeApFNp, out var connectionType);
				WpntuIiYaGJtdDvnePgVEQljkza = (ktFMadchANQDttphwyRkxCqHawo)connectionType;
				externalTools.PS4Input_PadResetOrientation(ivfdKpZALpQIAdtIdHmkpPFkwfq);
			}

			private int UTTlJBNNCacAkzaMXbZYHFjfXFiH(int P_0)
			{
				if (P_0 < 0)
				{
					return -1;
				}
				if (EMmCNHMxthyPbswflJgFbmnEYIr > 0 && bIZypASdSROsUiGJIeRGjryaHTvT == P_0)
				{
					return 0;
				}
				if (EMmCNHMxthyPbswflJgFbmnEYIr > 1 && uftBitJEsRMBAhVxiWgISgYTrTuq == P_0)
				{
					return 1;
				}
				return -1;
			}
		}

		private sealed class VVPGbrhKwgwWMzTZkPdLdTwEjyi : smsZnrfodXmyATytXSHkAhInxFC, YrXBrlhKsdGlkNpligiCaWGZnhZ, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource, IPS4AimExtensionSource
		{
			private const int skotmctbDSWIawJPITTDnlfQMrI = 6;

			private const int iipHpfgLozalWqeLcbTeIaNNpzGR = 14;

			private const float sEdvWSRHRyboTkGXiuuWesiBvbm = 0.05f;

			private const int kOQKAcqOirVfliZtPgyYffXpDLq = 2;

			private const int UreenoAwOzpNisAaPCuZOeBoOFD = 2;

			private int EMmCNHMxthyPbswflJgFbmnEYIr;

			private int bIZypASdSROsUiGJIeRGjryaHTvT;

			private Vector2 FdbLJlDmsiCGVOwJSAFolGuCSUD;

			private int uftBitJEsRMBAhVxiWgISgYTrTuq;

			private Vector2 DjCYBVIsrcgJCOumTzfaZKQNaE;

			private ktFMadchANQDttphwyRkxCqHawo WpntuIiYaGJtdDvnePgVEQljkza;

			private int ogNSATzBmBTKfmkbMbCuWSMkZTI;

			private int wnsESouKBQrzOvHbJBDcSiXniaA;

			private int okqaoRdweQDLORacBZxoIUcuVwT;

			private int TJfRrKSbIYHKAbRyHbAbDeApFNp;

			private float HZZDgzTtNlGYjfkWZzCfHyLHCyK;

			public VVPGbrhKwgwWMzTZkPdLdTwEjyi(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Aim, BaseControllerType.Aim, name, playerId, unityJoystickId, handle, new tOZwqQFNqLyLbSZgTFzldvFGDGT(6, 14, 0.05f, 2, 2))
			{
				base.extension = new PS4AimExtension(this);
			}
		}

		private abstract class GLpgYCwTQSagOZhbpIyFbUkWmkeT : smsZnrfodXmyATytXSHkAhInxFC
		{
			protected GLpgYCwTQSagOZhbpIyFbUkWmkeT(ControllerType controllerType, string name, int playerId, int unityJoystickId, int handle, tOZwqQFNqLyLbSZgTFzldvFGDGT capabilities)
				: base(controllerType, BaseControllerType.Special, name, playerId, unityJoystickId, handle, capabilities)
			{
			}

			public static GLpgYCwTQSagOZhbpIyFbUkWmkeT AxGMnpcloIAUTQTSFCdghQatHHxd(int P_0, int P_1, int P_2)
			{
				if (!smsZnrfodXmyATytXSHkAhInxFC.jMxvsTIPUKkpRwAGYMwqXuJeUXy(P_0, out var controllerType))
				{
					return null;
				}
				return AxGMnpcloIAUTQTSFCdghQatHHxd(controllerType, P_1, P_2);
			}

			public static GLpgYCwTQSagOZhbpIyFbUkWmkeT AxGMnpcloIAUTQTSFCdghQatHHxd(ControllerType P_0, int P_1, int P_2)
			{
				int unityJoystickId = P_1 + 13;
				switch (P_0)
				{
				case ControllerType.Unknown:
				case ControllerType.Gamepad:
				case ControllerType.Aim:
					return null;
				case ControllerType.Drum:
					return new lbzkYyhMuVdbjiFtEeypHRWkzCYQ("Drums " + (P_1 + 1), P_1, unityJoystickId, P_2);
				case ControllerType.FlightStick:
					return new blCYxxXNyZfhRVQsDGXvqUNOHpd("Flight Stick " + (P_1 + 1), P_1, unityJoystickId, P_2);
				case ControllerType.Guitar:
					return new hnsbNdLUHHjIsEdwyRPnXEQXPat("Guitar " + (P_1 + 1), P_1, unityJoystickId, P_2);
				case ControllerType.SteeringWheel:
					return new OgTVbCbVgWvibVSsrdlAiwlPqqHH("Steering Wheel " + (P_1 + 1), P_1, unityJoystickId, P_2);
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

		private sealed class OgTVbCbVgWvibVSsrdlAiwlPqqHH : GLpgYCwTQSagOZhbpIyFbUkWmkeT
		{
			private const int skotmctbDSWIawJPITTDnlfQMrI = 13;

			private const int iipHpfgLozalWqeLcbTeIaNNpzGR = 14;

			private const float sEdvWSRHRyboTkGXiuuWesiBvbm = 0.05f;

			private const int kOQKAcqOirVfliZtPgyYffXpDLq = 2;

			private const int UreenoAwOzpNisAaPCuZOeBoOFD = 0;

			public OgTVbCbVgWvibVSsrdlAiwlPqqHH(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.SteeringWheel, name, playerId, unityJoystickId, handle, new tOZwqQFNqLyLbSZgTFzldvFGDGT(13, 14, 0.05f, 2, 0))
			{
				base.extension = new PS4ControllerExtension(this);
			}

			protected override void eCIGQsHyQbbhZbivOlTdMelKKAxc()
			{
				base.eCIGQsHyQbbhZbivOlTdMelKKAxc();
				int joystickId = FpdtqZZTWeqPcFFnqYkufVBjbtW + 1;
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

		private sealed class hnsbNdLUHHjIsEdwyRPnXEQXPat : GLpgYCwTQSagOZhbpIyFbUkWmkeT
		{
			private const int skotmctbDSWIawJPITTDnlfQMrI = 11;

			private const int iipHpfgLozalWqeLcbTeIaNNpzGR = 14;

			private const float sEdvWSRHRyboTkGXiuuWesiBvbm = 0.05f;

			private const int kOQKAcqOirVfliZtPgyYffXpDLq = 2;

			private const int UreenoAwOzpNisAaPCuZOeBoOFD = 0;

			public hnsbNdLUHHjIsEdwyRPnXEQXPat(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Guitar, name, playerId, unityJoystickId, handle, new tOZwqQFNqLyLbSZgTFzldvFGDGT(11, 14, 0.05f, 2, 0))
			{
				base.extension = new PS4ControllerExtension(this);
			}

			protected override void eCIGQsHyQbbhZbivOlTdMelKKAxc()
			{
				base.eCIGQsHyQbbhZbivOlTdMelKKAxc();
				int joystickId = FpdtqZZTWeqPcFFnqYkufVBjbtW + 1;
				IList<Axis> axes = base.Axes;
				axes[6].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 10);
				axes[7].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 11);
				axes[8].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 12);
				axes[9].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 13);
				axes[10].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 14);
			}
		}

		private sealed class lbzkYyhMuVdbjiFtEeypHRWkzCYQ : GLpgYCwTQSagOZhbpIyFbUkWmkeT
		{
			private const int skotmctbDSWIawJPITTDnlfQMrI = 13;

			private const int iipHpfgLozalWqeLcbTeIaNNpzGR = 14;

			private const float sEdvWSRHRyboTkGXiuuWesiBvbm = 0.05f;

			private const int kOQKAcqOirVfliZtPgyYffXpDLq = 2;

			private const int UreenoAwOzpNisAaPCuZOeBoOFD = 0;

			public lbzkYyhMuVdbjiFtEeypHRWkzCYQ(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Drum, name, playerId, unityJoystickId, handle, new tOZwqQFNqLyLbSZgTFzldvFGDGT(13, 14, 0.05f, 2, 0))
			{
				base.extension = new PS4ControllerExtension(this);
			}

			protected override void eCIGQsHyQbbhZbivOlTdMelKKAxc()
			{
				base.eCIGQsHyQbbhZbivOlTdMelKKAxc();
				int joystickId = FpdtqZZTWeqPcFFnqYkufVBjbtW + 1;
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

		private sealed class blCYxxXNyZfhRVQsDGXvqUNOHpd : GLpgYCwTQSagOZhbpIyFbUkWmkeT
		{
			private const int skotmctbDSWIawJPITTDnlfQMrI = 16;

			private const int iipHpfgLozalWqeLcbTeIaNNpzGR = 14;

			private const float sEdvWSRHRyboTkGXiuuWesiBvbm = 0.05f;

			private const int kOQKAcqOirVfliZtPgyYffXpDLq = 2;

			private const int UreenoAwOzpNisAaPCuZOeBoOFD = 0;

			public blCYxxXNyZfhRVQsDGXvqUNOHpd(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.FlightStick, name, playerId, unityJoystickId, handle, new tOZwqQFNqLyLbSZgTFzldvFGDGT(16, 14, 0.05f, 2, 0))
			{
				base.extension = new PS4ControllerExtension(this);
			}

			protected override void eCIGQsHyQbbhZbivOlTdMelKKAxc()
			{
				base.eCIGQsHyQbbhZbivOlTdMelKKAxc();
				int joystickId = FpdtqZZTWeqPcFFnqYkufVBjbtW + 1;
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

		private robegNEBCPaHIRZRVXUeYBtvxUL IOuJMzXBxREttiVddtrVDsRjGsQp;

		private bool obQXMaqjzVnnEWOwzykxfHEqSVG = true;

		private bool jgbpvYJovPcfzmcAEJzdxdrBmcm;

		public override bool isReady => true;

		bool IControllerAssigner.enabled
		{
			get
			{
				return obQXMaqjzVnnEWOwzykxfHEqSVG;
			}
			set
			{
				obQXMaqjzVnnEWOwzykxfHEqSVG = value;
			}
		}

		public PS4InputSource()
			: base(22)
		{
			ReInput.controllerAssigner = this;
			IOuJMzXBxREttiVddtrVDsRjGsQp = new robegNEBCPaHIRZRVXUeYBtvxUL(4);
			IOuJMzXBxREttiVddtrVDsRjGsQp.ControllerConnectedEvent += GZBDSiWsxKoBoRmynHghhMbxicu;
			IOuJMzXBxREttiVddtrVDsRjGsQp.ControllerDisconnectedEvent += PKWMuXMxlEGIZapxAJORxIvWFac;
		}

		public override void Update()
		{
			IOuJMzXBxREttiVddtrVDsRjGsQp.QTPiZFmnRsxmyQYmMuIoBQkOtfg();
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

		private static int byZJBaWDcuzARbQRmRJwsJfompH(int P_0)
		{
			if (P_0 >= 13)
			{
				return P_0 - 13;
			}
			return P_0 - 1;
		}

		private void GZBDSiWsxKoBoRmynHghhMbxicu(robegNEBCPaHIRZRVXUeYBtvxUL.JqZFzvSsmpGjkDkBjXzvOJOtHUB P_0)
		{
			smsZnrfodXmyATytXSHkAhInxFC smsZnrfodXmyATytXSHkAhInxFC2;
			switch (P_0.pAUZutcIWFLfyIuyDiNKiSukBQE)
			{
			case smsZnrfodXmyATytXSHkAhInxFC.BaseControllerType.Gamepad:
				smsZnrfodXmyATytXSHkAhInxFC2 = smsZnrfodXmyATytXSHkAhInxFC.AxGMnpcloIAUTQTSFCdghQatHHxd(smsZnrfodXmyATytXSHkAhInxFC.ControllerType.Gamepad, P_0.nZoOiWFbSzkxRviXQbGJPvfNvSl, P_0.oiWUinLKWXyukpIwfOtSoxBWeDp, P_0.UdRaEyVNzeQmlXdePtFgUZmOqma);
				if (smsZnrfodXmyATytXSHkAhInxFC2 == null)
				{
					return;
				}
				break;
			case smsZnrfodXmyATytXSHkAhInxFC.BaseControllerType.Special:
				smsZnrfodXmyATytXSHkAhInxFC2 = GLpgYCwTQSagOZhbpIyFbUkWmkeT.AxGMnpcloIAUTQTSFCdghQatHHxd(P_0.nZoOiWFbSzkxRviXQbGJPvfNvSl, P_0.oiWUinLKWXyukpIwfOtSoxBWeDp, P_0.UdRaEyVNzeQmlXdePtFgUZmOqma);
				if (smsZnrfodXmyATytXSHkAhInxFC2 == null)
				{
					return;
				}
				break;
			case smsZnrfodXmyATytXSHkAhInxFC.BaseControllerType.Aim:
				smsZnrfodXmyATytXSHkAhInxFC2 = smsZnrfodXmyATytXSHkAhInxFC.AxGMnpcloIAUTQTSFCdghQatHHxd(smsZnrfodXmyATytXSHkAhInxFC.ControllerType.Aim, P_0.nZoOiWFbSzkxRviXQbGJPvfNvSl, P_0.oiWUinLKWXyukpIwfOtSoxBWeDp, P_0.UdRaEyVNzeQmlXdePtFgUZmOqma);
				if (smsZnrfodXmyATytXSHkAhInxFC2 == null)
				{
					return;
				}
				break;
			default:
				throw new NotImplementedException();
			}
			zEiXvAIsntMrhNGuTISLHCbdpKf(smsZnrfodXmyATytXSHkAhInxFC2);
		}

		private void zEiXvAIsntMrhNGuTISLHCbdpKf(smsZnrfodXmyATytXSHkAhInxFC P_0)
		{
			AddJoystick(P_0);
			P_0.Connect();
			OnJoystickConnected();
		}

		private void PKWMuXMxlEGIZapxAJORxIvWFac(robegNEBCPaHIRZRVXUeYBtvxUL.dlhFbzAPwcPOvXXdtuKOCUvnSEW P_0)
		{
			IList<Joystick> joysticks = GetJoysticks();
			int count = joysticks.Count;
			for (int num = count - 1; num >= 0; num--)
			{
				smsZnrfodXmyATytXSHkAhInxFC smsZnrfodXmyATytXSHkAhInxFC2 = joysticks[num] as smsZnrfodXmyATytXSHkAhInxFC;
				if (P_0.pAUZutcIWFLfyIuyDiNKiSukBQE == smsZnrfodXmyATytXSHkAhInxFC2.baseControllerType && smsZnrfodXmyATytXSHkAhInxFC2.playerId == P_0.oiWUinLKWXyukpIwfOtSoxBWeDp && smsZnrfodXmyATytXSHkAhInxFC2.handle == P_0.UdRaEyVNzeQmlXdePtFgUZmOqma)
				{
					smsZnrfodXmyATytXSHkAhInxFC2.Disconnect();
					RemoveJoystick(smsZnrfodXmyATytXSHkAhInxFC2);
				}
			}
			OnJoystickDisconnected();
		}

		private bool EjsEWYqsSEPlpvPANdIPaQQPsrF(ControllerType P_0, Rewired.Controller P_1)
		{
			if (!obQXMaqjzVnnEWOwzykxfHEqSVG)
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
			//ILSpy generated this explicit interface implementation from .override directive in EjsEWYqsSEPlpvPANdIPaQQPsrF
			return this.EjsEWYqsSEPlpvPANdIPaQQPsrF(P_0, P_1);
		}

		private void AGdSGMMHLPDFeerInaQfheZgfzO(ControllerType P_0, Rewired.Controller P_1)
		{
			if (!((IControllerAssigner)this).CanHandleAssignment(P_0, P_1))
			{
				return;
			}
			Rewired.Joystick joystick = P_1 as Rewired.Joystick;
			if (!ReInput.controllers.IsJoystickAssigned(joystick))
			{
				int num = byZJBaWDcuzARbQRmRJwsJfompH(joystick.unityId);
				if (num < ReInput.players.playerCount && ReInput.players.GetPlayer(num) != null && (!ReInput.configVars.assignJoysticksToPlayingPlayersOnly || ReInput.players.GetPlayer(num).isPlaying))
				{
					ReInput.players.GetPlayer(num).controllers.AddController(joystick, removeFromOtherPlayers: true);
				}
			}
		}

		void IControllerAssigner.AssignController(ControllerType P_0, Rewired.Controller P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in AGdSGMMHLPDFeerInaQfheZgfzO
			this.AGdSGMMHLPDFeerInaQfheZgfzO(P_0, P_1);
		}

		~PS4InputSource()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (!jgbpvYJovPcfzmcAEJzdxdrBmcm)
			{
				jgbpvYJovPcfzmcAEJzdxdrBmcm = true;
			}
		}
	}
}
