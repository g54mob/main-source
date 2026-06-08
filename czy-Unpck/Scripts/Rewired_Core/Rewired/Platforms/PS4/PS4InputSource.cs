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
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class PS4InputSource : CustomInputSource, IControllerAssigner
	{
		private class tEmrawKbhbEVmgDlgbmzqwbnQAM
		{
			public struct jwkwODhGsrrLkdyCGLEPdvKAJnm
			{
				public int wdJNnMRgnpHAWIQUEkdXEsJWDJsH;

				public int AhODPAPEiKQbFcMqyoClsiOEHsd;

				public int lnlNhzZfDvBdeKdlVfYEtzHVjqZ;

				public mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType hLFqbKsLnhVDQrSCeKaRQrimbrF;

				public jwkwODhGsrrLkdyCGLEPdvKAJnm(int playerId, int handle, int deviceClass, mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType baseControllerType)
				{
					wdJNnMRgnpHAWIQUEkdXEsJWDJsH = playerId;
					AhODPAPEiKQbFcMqyoClsiOEHsd = handle;
					lnlNhzZfDvBdeKdlVfYEtzHVjqZ = deviceClass;
					hLFqbKsLnhVDQrSCeKaRQrimbrF = baseControllerType;
				}
			}

			public struct oqBxsEIgTVkbMnXvPzSVbioQQpV
			{
				public int wdJNnMRgnpHAWIQUEkdXEsJWDJsH;

				public int AhODPAPEiKQbFcMqyoClsiOEHsd;

				public mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType hLFqbKsLnhVDQrSCeKaRQrimbrF;

				public oqBxsEIgTVkbMnXvPzSVbioQQpV(int playerId, int handle, mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType baseControllerType)
				{
					wdJNnMRgnpHAWIQUEkdXEsJWDJsH = playerId;
					AhODPAPEiKQbFcMqyoClsiOEHsd = handle;
					hLFqbKsLnhVDQrSCeKaRQrimbrF = baseControllerType;
				}
			}

			private class ksUCZMhmYYKtePKLEpTotAkqodwc
			{
				public readonly mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType hLFqbKsLnhVDQrSCeKaRQrimbrF;

				public bool zeSbCceuxMcPzqSFnKyZGvqrtXm;

				public int AhODPAPEiKQbFcMqyoClsiOEHsd;

				public int lnlNhzZfDvBdeKdlVfYEtzHVjqZ;

				public ksUCZMhmYYKtePKLEpTotAkqodwc(mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType baseControllerType)
				{
					hLFqbKsLnhVDQrSCeKaRQrimbrF = baseControllerType;
					tAgADqjTsMUxSqYXeDyJIdETYRAp();
				}

				public ChangeType QwKhzuzAsBwRyqzejHojSvPyQqJ(bool P_0, int P_1, int P_2)
				{
					ChangeType changeType = ChangeType.None;
					if (zeSbCceuxMcPzqSFnKyZGvqrtXm != P_0)
					{
						zeSbCceuxMcPzqSFnKyZGvqrtXm = P_0;
						changeType = (ChangeType)((int)changeType | (P_0 ? 1 : 2));
						if (P_0)
						{
							AhODPAPEiKQbFcMqyoClsiOEHsd = P_1;
							goto IL_0026;
						}
						tAgADqjTsMUxSqYXeDyJIdETYRAp();
						return changeType;
					}
					int num;
					if (AhODPAPEiKQbFcMqyoClsiOEHsd != P_1)
					{
						AhODPAPEiKQbFcMqyoClsiOEHsd = P_1;
						changeType |= ChangeType.IdentityChanged;
						num = -1753242943;
						goto IL_002b;
					}
					goto IL_008a;
					IL_002b:
					while (true)
					{
						switch (num ^ -1753242942)
						{
						case 4:
							break;
						case 1:
							lnlNhzZfDvBdeKdlVfYEtzHVjqZ = P_2;
							return changeType;
						case 0:
							lnlNhzZfDvBdeKdlVfYEtzHVjqZ = P_2;
							changeType |= ChangeType.IdentityChanged;
							num = -1753242944;
							continue;
						case 3:
							goto IL_008a;
						default:
							return changeType;
						}
						break;
					}
					goto IL_0026;
					IL_008a:
					int num2;
					if (lnlNhzZfDvBdeKdlVfYEtzHVjqZ == P_2)
					{
						num = -1753242944;
						num2 = num;
					}
					else
					{
						num = -1753242942;
						num2 = num;
					}
					goto IL_002b;
					IL_0026:
					num = -1753242941;
					goto IL_002b;
				}

				private void tAgADqjTsMUxSqYXeDyJIdETYRAp()
				{
					zeSbCceuxMcPzqSFnKyZGvqrtXm = false;
					AhODPAPEiKQbFcMqyoClsiOEHsd = -1;
					lnlNhzZfDvBdeKdlVfYEtzHVjqZ = -1;
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

			private readonly int lBzSRnABpnGlNyyjeRPXyIuNspn;

			private readonly int[] YlqNtdtrlWIQzbQtanojlwoZiybg;

			private readonly int[] ctdiUNPAXtVOPnKYIMIJXElXjOSh;

			private readonly int[] akHXAsVBCIaJliZXRbePicqKBhLB;

			private readonly IExternalTools fZECRaPLFYIMChwnLINJpkcikrZ;

			private readonly ksUCZMhmYYKtePKLEpTotAkqodwc[] IYpuUhdQUICMPGltEZgJbcDxURzu;

			private readonly ksUCZMhmYYKtePKLEpTotAkqodwc[] okzVKqXxUefoeCwLGYxQsyYoWgr;

			private readonly ksUCZMhmYYKtePKLEpTotAkqodwc[] PbPupOcqPoSUWGfgWJxGHDlUCWyh;

			private readonly List<jwkwODhGsrrLkdyCGLEPdvKAJnm> skLiBYDSisNeBCEYADqhpokayMW;

			private readonly List<oqBxsEIgTVkbMnXvPzSVbioQQpV> PcQRFLeCbuFKbAzakeyZGORtVgF;

			private Action<jwkwODhGsrrLkdyCGLEPdvKAJnm> udZewklpmVqAeigUvQTBxzrVLHk;

			private Action<oqBxsEIgTVkbMnXvPzSVbioQQpV> XJJqXMPYQgpontdyoDXdVwVztJI;

			[CompilerGenerated]
			private static Func<ksUCZMhmYYKtePKLEpTotAkqodwc> CPbMQcJWfrYbYKCDWctveYmzqXN;

			[CompilerGenerated]
			private static Func<ksUCZMhmYYKtePKLEpTotAkqodwc> nxRDNsQycmbjNuLzCodsWNAlkcQ;

			[CompilerGenerated]
			private static Func<ksUCZMhmYYKtePKLEpTotAkqodwc> VqWFQXijanCwPkbVsFhwOEwJgwAF;

			public event Action<jwkwODhGsrrLkdyCGLEPdvKAJnm> ControllerConnectedEvent
			{
				add
				{
					Action<jwkwODhGsrrLkdyCGLEPdvKAJnm> action = udZewklpmVqAeigUvQTBxzrVLHk;
					while (true)
					{
						int num = -255004472;
						while (true)
						{
							switch (num ^ -255004471)
							{
							case 0:
								break;
							default:
								return;
							case 1:
							{
								Action<jwkwODhGsrrLkdyCGLEPdvKAJnm> action2 = action;
								Action<jwkwODhGsrrLkdyCGLEPdvKAJnm> value2 = (Action<jwkwODhGsrrLkdyCGLEPdvKAJnm>)Delegate.Combine(action2, value);
								action = Interlocked.CompareExchange(ref udZewklpmVqAeigUvQTBxzrVLHk, value2, action2);
								int num2;
								if ((object)action == action2)
								{
									num = -255004469;
									num2 = num;
								}
								else
								{
									num = -255004472;
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
				remove
				{
					Action<jwkwODhGsrrLkdyCGLEPdvKAJnm> action = udZewklpmVqAeigUvQTBxzrVLHk;
					Action<jwkwODhGsrrLkdyCGLEPdvKAJnm> action2;
					do
					{
						action2 = action;
						Action<jwkwODhGsrrLkdyCGLEPdvKAJnm> value2 = (Action<jwkwODhGsrrLkdyCGLEPdvKAJnm>)Delegate.Remove(action2, value);
						action = Interlocked.CompareExchange(ref udZewklpmVqAeigUvQTBxzrVLHk, value2, action2);
					}
					while ((object)action != action2);
				}
			}

			public event Action<oqBxsEIgTVkbMnXvPzSVbioQQpV> ControllerDisconnectedEvent
			{
				add
				{
					Action<oqBxsEIgTVkbMnXvPzSVbioQQpV> action = XJJqXMPYQgpontdyoDXdVwVztJI;
					Action<oqBxsEIgTVkbMnXvPzSVbioQQpV> action2 = default(Action<oqBxsEIgTVkbMnXvPzSVbioQQpV>);
					Action<oqBxsEIgTVkbMnXvPzSVbioQQpV> value2 = default(Action<oqBxsEIgTVkbMnXvPzSVbioQQpV>);
					while (true)
					{
						int num = -821894847;
						while (true)
						{
							switch (num ^ -821894848)
							{
							case 2:
								break;
							default:
								return;
							case 1:
								action2 = action;
								value2 = (Action<oqBxsEIgTVkbMnXvPzSVbioQQpV>)Delegate.Combine(action2, value);
								num = -821894844;
								continue;
							case 3:
							{
								int num2;
								if ((object)action == action2)
								{
									num = -821894848;
									num2 = num;
								}
								else
								{
									num = -821894847;
									num2 = num;
								}
								continue;
							}
							case 4:
								action = Interlocked.CompareExchange(ref XJJqXMPYQgpontdyoDXdVwVztJI, value2, action2);
								num = -821894845;
								continue;
							case 0:
								return;
							}
							break;
						}
					}
				}
				remove
				{
					Action<oqBxsEIgTVkbMnXvPzSVbioQQpV> action = XJJqXMPYQgpontdyoDXdVwVztJI;
					Action<oqBxsEIgTVkbMnXvPzSVbioQQpV> action2;
					do
					{
						action2 = action;
						Action<oqBxsEIgTVkbMnXvPzSVbioQQpV> value2 = (Action<oqBxsEIgTVkbMnXvPzSVbioQQpV>)Delegate.Remove(action2, value);
						action = Interlocked.CompareExchange(ref XJJqXMPYQgpontdyoDXdVwVztJI, value2, action2);
					}
					while ((object)action != action2);
				}
			}

			public tEmrawKbhbEVmgDlgbmzqwbnQAM(int maxPlayers)
			{
				lBzSRnABpnGlNyyjeRPXyIuNspn = maxPlayers;
				YlqNtdtrlWIQzbQtanojlwoZiybg = new int[maxPlayers];
				ctdiUNPAXtVOPnKYIMIJXElXjOSh = new int[maxPlayers];
				akHXAsVBCIaJliZXRbePicqKBhLB = new int[maxPlayers];
				fZECRaPLFYIMChwnLINJpkcikrZ = UnityTools.externalTools;
				IYpuUhdQUICMPGltEZgJbcDxURzu = new ksUCZMhmYYKtePKLEpTotAkqodwc[maxPlayers];
				ArrayTools.Populate(IYpuUhdQUICMPGltEZgJbcDxURzu, () => new ksUCZMhmYYKtePKLEpTotAkqodwc(mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType.Gamepad));
				okzVKqXxUefoeCwLGYxQsyYoWgr = new ksUCZMhmYYKtePKLEpTotAkqodwc[maxPlayers];
				ArrayTools.Populate(okzVKqXxUefoeCwLGYxQsyYoWgr, () => new ksUCZMhmYYKtePKLEpTotAkqodwc(mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType.Special));
				PbPupOcqPoSUWGfgWJxGHDlUCWyh = new ksUCZMhmYYKtePKLEpTotAkqodwc[maxPlayers];
				ArrayTools.Populate(PbPupOcqPoSUWGfgWJxGHDlUCWyh, () => new ksUCZMhmYYKtePKLEpTotAkqodwc(mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType.Aim));
				skLiBYDSisNeBCEYADqhpokayMW = new List<jwkwODhGsrrLkdyCGLEPdvKAJnm>(2);
				PcQRFLeCbuFKbAzakeyZGORtVgF = new List<oqBxsEIgTVkbMnXvPzSVbioQQpV>(2);
			}

			public void GzCliicOSMFLMvKajLgvnmGSSrh()
			{
				fZECRaPLFYIMChwnLINJpkcikrZ.PS4Input_PadGetUsersHandles2(lBzSRnABpnGlNyyjeRPXyIuNspn, YlqNtdtrlWIQzbQtanojlwoZiybg);
				ksUCZMhmYYKtePKLEpTotAkqodwc ksUCZMhmYYKtePKLEpTotAkqodwc3 = default(ksUCZMhmYYKtePKLEpTotAkqodwc);
				ksUCZMhmYYKtePKLEpTotAkqodwc ksUCZMhmYYKtePKLEpTotAkqodwc4 = default(ksUCZMhmYYKtePKLEpTotAkqodwc);
				bool flag3 = default(bool);
				bool flag2 = default(bool);
				int num4 = default(int);
				int num5 = default(int);
				while (true)
				{
					int num = -1284640159;
					while (true)
					{
						switch (num ^ -1284640160)
						{
						case 2:
							break;
						case 1:
							fZECRaPLFYIMChwnLINJpkcikrZ.PS4Input_SpecialGetUsersHandles2(lBzSRnABpnGlNyyjeRPXyIuNspn, ctdiUNPAXtVOPnKYIMIJXElXjOSh);
							num = -1284640157;
							continue;
						case 3:
							fZECRaPLFYIMChwnLINJpkcikrZ.PS4Input_AimGetUsersHandles2(lBzSRnABpnGlNyyjeRPXyIuNspn, akHXAsVBCIaJliZXRbePicqKBhLB);
							num = -1284640160;
							continue;
						default:
						{
							int num2 = 0;
							while (true)
							{
								if (num2 < lBzSRnABpnGlNyyjeRPXyIuNspn)
								{
									try
									{
										ksUCZMhmYYKtePKLEpTotAkqodwc ksUCZMhmYYKtePKLEpTotAkqodwc2 = IYpuUhdQUICMPGltEZgJbcDxURzu[num2];
										bool flag = fZECRaPLFYIMChwnLINJpkcikrZ.PS4Input_PadIsConnected(num2);
										if (!ksUCZMhmYYKtePKLEpTotAkqodwc2.zeSbCceuxMcPzqSFnKyZGvqrtXm)
										{
											if (flag)
											{
												goto IL_00a6;
											}
											goto IL_0180;
										}
										goto IL_01b5;
										IL_0180:
										ksUCZMhmYYKtePKLEpTotAkqodwc3 = okzVKqXxUefoeCwLGYxQsyYoWgr[num2];
										int num3 = -1284640154;
										goto IL_00ab;
										IL_00a6:
										num3 = -1284640158;
										goto IL_00ab;
										IL_00ab:
										while (true)
										{
											int num6;
											switch (num3 ^ -1284640160)
											{
											case 5:
												break;
											case 4:
												if (!ksUCZMhmYYKtePKLEpTotAkqodwc4.zeSbCceuxMcPzqSFnKyZGvqrtXm)
												{
													goto IL_00f3;
												}
												goto case 9;
											case 10:
												ksUCZMhmYYKtePKLEpTotAkqodwc4 = PbPupOcqPoSUWGfgWJxGHDlUCWyh[num2];
												num3 = -1284640153;
												continue;
											case 7:
												flag3 = fZECRaPLFYIMChwnLINJpkcikrZ.PS4Input_AimIsConnected(num2);
												num3 = -1284640156;
												continue;
											case 1:
												OjHJyUsroJEGRpofpgPGGkwidSfb(num2, ksUCZMhmYYKtePKLEpTotAkqodwc3, ctdiUNPAXtVOPnKYIMIJXElXjOSh[num2], flag2, "Special");
												num3 = -1284640150;
												continue;
											case 6:
												flag2 = fZECRaPLFYIMChwnLINJpkcikrZ.PS4Input_SpecialIsConnected(num2);
												if (ksUCZMhmYYKtePKLEpTotAkqodwc3.zeSbCceuxMcPzqSFnKyZGvqrtXm)
												{
													goto case 1;
												}
												goto IL_0168;
											case 8:
												goto IL_0180;
											case 9:
												OjHJyUsroJEGRpofpgPGGkwidSfb(num2, ksUCZMhmYYKtePKLEpTotAkqodwc4, akHXAsVBCIaJliZXRbePicqKBhLB[num2], flag3, "Aim");
												num3 = -1284640157;
												continue;
											case 2:
												goto IL_01b5;
											case 3:
												if (PcQRFLeCbuFKbAzakeyZGORtVgF.Count > 0)
												{
													num3 = -1284640160;
													continue;
												}
												goto IL_026d;
											default:
												{
													num4 = 0;
													goto IL_024c;
												}
												IL_026d:
												if (skLiBYDSisNeBCEYADqhpokayMW.Count > 0)
												{
													num5 = 0;
													num6 = -1284640157;
													goto IL_022f;
												}
												goto end_IL_007f;
												IL_022f:
												switch (num6 ^ -1284640160)
												{
												case 2:
													break;
												case 1:
													goto IL_024c;
												case 0:
													goto IL_026d;
												default:
													while (true)
													{
														if (num5 < skLiBYDSisNeBCEYADqhpokayMW.Count)
														{
															try
															{
																udZewklpmVqAeigUvQTBxzrVLHk(skLiBYDSisNeBCEYADqhpokayMW[num5]);
															}
															catch (Exception ex)
															{
																Logger.LogError("An exception occurred in controller monitor Controller Connect Event callback.\n" + ex);
															}
															num5++;
															goto IL_02bf;
														}
														skLiBYDSisNeBCEYADqhpokayMW.Clear();
														int num7 = -1284640159;
														goto IL_02c4;
														IL_02c4:
														switch (num7 ^ -1284640160)
														{
														case 0:
															break;
														default:
															goto end_IL_02dd;
														case 2:
															continue;
														case 1:
															goto end_IL_02dd;
														}
														goto IL_02bf;
														IL_02bf:
														num7 = -1284640158;
														goto IL_02c4;
														continue;
														end_IL_02dd:
														break;
													}
													goto end_IL_007f;
												}
												goto IL_022a;
												IL_024c:
												if (num4 < PcQRFLeCbuFKbAzakeyZGORtVgF.Count)
												{
													try
													{
														XJJqXMPYQgpontdyoDXdVwVztJI(PcQRFLeCbuFKbAzakeyZGORtVgF[num4]);
													}
													catch (Exception ex2)
													{
														Logger.LogError("An exception occurred in controller monitor Controller Disconnect Event callback.\n" + ex2);
													}
													num4++;
													goto IL_022a;
												}
												PcQRFLeCbuFKbAzakeyZGORtVgF.Clear();
												num6 = -1284640160;
												goto IL_022f;
												IL_022a:
												num6 = -1284640159;
												goto IL_022f;
											}
											break;
											IL_0168:
											int num8;
											if (!flag2)
											{
												num3 = -1284640150;
												num8 = num3;
											}
											else
											{
												num3 = -1284640159;
												num8 = num3;
											}
											continue;
											IL_00f3:
											int num9;
											if (!flag3)
											{
												num3 = -1284640157;
												num9 = num3;
											}
											else
											{
												num3 = -1284640151;
												num9 = num3;
											}
										}
										goto IL_00a6;
										IL_01b5:
										OjHJyUsroJEGRpofpgPGGkwidSfb(num2, ksUCZMhmYYKtePKLEpTotAkqodwc2, YlqNtdtrlWIQzbQtanojlwoZiybg[num2], flag, "Gamepad");
										num3 = -1284640152;
										goto IL_00ab;
										end_IL_007f:;
									}
									catch (Exception ex3)
									{
										Logger.LogError("An exception occurred during controller monitor update.\n" + ex3);
									}
									num2++;
									goto IL_0319;
								}
								int num10 = -1284640160;
								goto IL_031e;
								IL_031e:
								switch (num10 ^ -1284640160)
								{
								case 2:
									break;
								default:
									return;
								case 1:
									continue;
								case 0:
									return;
								}
								goto IL_0319;
								IL_0319:
								num10 = -1284640159;
								goto IL_031e;
							}
						}
						}
						break;
					}
				}
			}

			private void OjHJyUsroJEGRpofpgPGGkwidSfb(int P_0, ksUCZMhmYYKtePKLEpTotAkqodwc P_1, int P_2, bool P_3, string P_4)
			{
				int num = fZECRaPLFYIMChwnLINJpkcikrZ.PS4Input_GetDeviceClassForHandle(P_2);
				int ahODPAPEiKQbFcMqyoClsiOEHsd = P_1.AhODPAPEiKQbFcMqyoClsiOEHsd;
				ChangeType changeType = P_1.QwKhzuzAsBwRyqzejHojSvPyQqJ(P_3, P_2, num);
				while (true)
				{
					int num2 = -1907122437;
					while (true)
					{
						switch (num2 ^ -1907122438)
						{
						case 0:
							break;
						default:
							return;
						case 4:
						{
							int num4;
							if (!P_1.zeSbCceuxMcPzqSFnKyZGvqrtXm)
							{
								num2 = -1907122433;
								num4 = num2;
							}
							else
							{
								num2 = -1907122436;
								num4 = num2;
							}
							continue;
						}
						case 5:
							if ((changeType & ChangeType.Connected) == 0)
							{
								if (P_1.zeSbCceuxMcPzqSFnKyZGvqrtXm)
								{
									int num5;
									if ((changeType & ChangeType.IdentityChanged) == 0)
									{
										num2 = -1907122440;
										num5 = num2;
									}
									else
									{
										num2 = -1907122439;
										num5 = num2;
									}
									continue;
								}
								return;
							}
							goto case 3;
						case 1:
							if (changeType == ChangeType.None)
							{
								return;
							}
							goto case 8;
						case 3:
							skLiBYDSisNeBCEYADqhpokayMW.Add(new jwkwODhGsrrLkdyCGLEPdvKAJnm(P_0, P_1.AhODPAPEiKQbFcMqyoClsiOEHsd, P_1.lnlNhzZfDvBdeKdlVfYEtzHVjqZ, P_1.hLFqbKsLnhVDQrSCeKaRQrimbrF));
							num2 = -1907122440;
							continue;
						case 6:
						{
							int num3;
							if ((changeType & ChangeType.IdentityChanged) != ChangeType.None)
							{
								num2 = -1907122435;
								num3 = num2;
							}
							else
							{
								num2 = -1907122433;
								num3 = num2;
							}
							continue;
						}
						case 8:
						{
							int num6;
							if ((changeType & ChangeType.Disconnected) != ChangeType.None)
							{
								num2 = -1907122435;
								num6 = num2;
							}
							else
							{
								num2 = -1907122434;
								num6 = num2;
							}
							continue;
						}
						case 7:
							PcQRFLeCbuFKbAzakeyZGORtVgF.Add(new oqBxsEIgTVkbMnXvPzSVbioQQpV(P_0, ahODPAPEiKQbFcMqyoClsiOEHsd, P_1.hLFqbKsLnhVDQrSCeKaRQrimbrF));
							num2 = -1907122433;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static ksUCZMhmYYKtePKLEpTotAkqodwc hfjhnHzBKtgeMgaJnUTLkpoZRlbT()
			{
				return new ksUCZMhmYYKtePKLEpTotAkqodwc(mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType.Gamepad);
			}

			[CompilerGenerated]
			private static ksUCZMhmYYKtePKLEpTotAkqodwc bOXOXMSIseINaVoIJMpRQvRRYMp()
			{
				return new ksUCZMhmYYKtePKLEpTotAkqodwc(mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType.Special);
			}

			[CompilerGenerated]
			private static ksUCZMhmYYKtePKLEpTotAkqodwc EreXIoHgZSDQKKoBEjvcjrGvsLZN()
			{
				return new ksUCZMhmYYKtePKLEpTotAkqodwc(mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType.Aim);
			}
		}

		private abstract class mOrDiYzmAbwIqufLyKjxgdKjoKL : Joystick, KTMkdEvZQPVUTmRgJNaXAYMPMBS, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource
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

			protected enum MMpEyEfjjkCltTIFZwEOOkDwSSo
			{
				AXriQuEBFZCYarVPplCATARGxpw = 0,
				JDFroxfyPmsrmWqDlUbNkPYBgkHC = 1,
				zQlgCrdAsmtlzKZXMcitzOuIKPoy = 2
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

			public class GWpMCaspiKkWlhUhKLXnyePvnIQ
			{
				public readonly int RGhWgMAfPjfICjXGWTZxnPoNdWD;

				public readonly int SeOhWaCQLSUYyhdokorrnPTrNGB;

				public readonly float BrzeGahpdAtwdxwBZYHiLKshdHi;

				public readonly int hSqMknHvfLaCaSKUtNrDJWiYQVX;

				public readonly int RGdsKBxcbNELteuziwUlifWUYzh;

				public GWpMCaspiKkWlhUhKLXnyePvnIQ(int axisCount, int buttonCount, float dpadDeadzone, int vibrationMotorCount, int maxTouches)
				{
					RGhWgMAfPjfICjXGWTZxnPoNdWD = axisCount;
					SeOhWaCQLSUYyhdokorrnPTrNGB = buttonCount;
					BrzeGahpdAtwdxwBZYHiLKshdHi = dpadDeadzone;
					hSqMknHvfLaCaSKUtNrDJWiYQVX = vibrationMotorCount;
					RGdsKBxcbNELteuziwUlifWUYzh = maxTouches;
				}
			}

			private static int yPibxUleKQqaxWXlLbSiBMqwOcf;

			protected readonly int cNcLkMBaCDcdcMeoQVAxVFVuHEv;

			protected readonly int OAVTbOWkoHlhaKHhvOEcQZrxjtM;

			protected readonly BaseControllerType PdRuOijjSPFmbOFYQYZWSbgqyYO;

			protected readonly GWpMCaspiKkWlhUhKLXnyePvnIQ AxhfQtbSsTyxTlOuVNpjukkJjHGw;

			protected readonly int FeaeSsBIvGENCmfHDJxvHHDdpYR;

			protected readonly float[] sJafVNDBNEEbecRSfeQLdaOzuaHh;

			private readonly LoggedInUser JGWBgUBZcMbGpJbIMjzNECGxrsY;

			protected readonly ControllerType mlHEPMoLvhyxVvGHhIjSYBQKMrF;

			private readonly Func<int, bool> IaScoJKkUcgPZBKbdnFtaqKePfJ;

			private readonly Action<int, int, int> tIkEmRsVBMhLzcnbFgPGuAjiKuB;

			private readonly Action<int, int, int, int> cGIiFovSarYuvZeCuCQUDNCAEGm;

			private readonly Action<int> ouEHNmdikaqPuXBGTzXdnnHbZoD;

			private Action<int, bool> FQxgoCVsRCabYzUhAewXfZxfBZS;

			private Action<int, bool> ZWcBbTPxvhGdoANtISUPyaFMhhr;

			private Action<int, bool> ryjpfkYKeFKVuTCJREUZinqCMxr;

			private Action<int> eflTfaNaWWBenzcJmfNRvMdDBlS;

			private Func<int, Vector3> UgEoXeTBeOrtPySQNcSnzWpPXSW;

			private Func<int, Vector3> EbBnKMWdvwmeQjgngKQLkySjpJC;

			private Func<int, Vector4> mwKTQDfouPZGKxLbrBgerUQHBTGH;

			private static int NextSystemId
			{
				get
				{
					int result = yPibxUleKQqaxWXlLbSiBMqwOcf;
					yPibxUleKQqaxWXlLbSiBMqwOcf++;
					return result;
				}
			}

			protected LoggedInUser user
			{
				get
				{
					UnityTools.externalTools.PS4Input_GetUsersDetails(cNcLkMBaCDcdcMeoQVAxVFVuHEv, JGWBgUBZcMbGpJbIMjzNECGxrsY);
					return JGWBgUBZcMbGpJbIMjzNECGxrsY;
				}
			}

			public ControllerType type => mlHEPMoLvhyxVvGHhIjSYBQKMrF;

			public int playerId => cNcLkMBaCDcdcMeoQVAxVFVuHEv;

			public int handle => OAVTbOWkoHlhaKHhvOEcQZrxjtM;

			public BaseControllerType baseControllerType => PdRuOijjSPFmbOFYQYZWSbgqyYO;

			private bool IsConnectedNow => IaScoJKkUcgPZBKbdnFtaqKePfJ(cNcLkMBaCDcdcMeoQVAxVFVuHEv);

			public int vibrationMotorCount => AxhfQtbSsTyxTlOuVNpjukkJjHGw.hSqMknHvfLaCaSKUtNrDJWiYQVX;

			public static mOrDiYzmAbwIqufLyKjxgdKjoKL GIHuiEkmFihgdjpqkqIhwXanlmm(ControllerType P_0, int P_1, int P_2, int P_3)
			{
				while (true)
				{
					switch (0x37CF9B99 ^ 0x37CF9B98)
					{
					case 0:
						continue;
					case 1:
						switch (P_0)
						{
						case ControllerType.Unknown:
							break;
						case ControllerType.Gamepad:
							return new nykSSJpGiEvmZwRVEUprkhvVtFw("Controller " + (P_2 + 1), P_2, P_2 + 1, P_3);
						case ControllerType.Aim:
							return new BDAFsAfwNAgkufQxLAKASDkAwXde("PS VR Aim Controller " + (P_2 + 1), P_2, P_2 + 13, P_3);
						default:
							return AaqcVzHsxirAeTeVWPZUZccOoNbi.GIHuiEkmFihgdjpqkqIhwXanlmm(P_1, P_2, P_3);
						}
						break;
					}
					break;
				}
				return null;
			}

			protected mOrDiYzmAbwIqufLyKjxgdKjoKL(ControllerType type, BaseControllerType baseControllerType, string name, int playerId, int unityJoystickId, int handle, GWpMCaspiKkWlhUhKLXnyePvnIQ capabilities)
				: base(name, NextSystemId, unityJoystickId, capabilities.RGhWgMAfPjfICjXGWTZxnPoNdWD, capabilities.SeOhWaCQLSUYyhdokorrnPTrNGB)
			{
				if (capabilities == null)
				{
					throw new ArgumentNullException("capabilities");
				}
				mlHEPMoLvhyxVvGHhIjSYBQKMrF = type;
				PdRuOijjSPFmbOFYQYZWSbgqyYO = baseControllerType;
				cNcLkMBaCDcdcMeoQVAxVFVuHEv = playerId;
				FeaeSsBIvGENCmfHDJxvHHDdpYR = unityJoystickId - 1;
				AxhfQtbSsTyxTlOuVNpjukkJjHGw = capabilities;
				OAVTbOWkoHlhaKHhvOEcQZrxjtM = handle;
				JGWBgUBZcMbGpJbIMjzNECGxrsY = new LoggedInUser();
				_customName = name;
				sJafVNDBNEEbecRSfeQLdaOzuaHh = new float[capabilities.hSqMknHvfLaCaSKUtNrDJWiYQVX];
				base.supportsVibration = capabilities.hSqMknHvfLaCaSKUtNrDJWiYQVX > 0;
				switch (PdRuOijjSPFmbOFYQYZWSbgqyYO)
				{
				case BaseControllerType.Gamepad:
					IaScoJKkUcgPZBKbdnFtaqKePfJ = UnityTools.externalTools.PS4Input_PadIsConnected;
					tIkEmRsVBMhLzcnbFgPGuAjiKuB = UnityTools.externalTools.PS4Input_PadSetVibration;
					cGIiFovSarYuvZeCuCQUDNCAEGm = UnityTools.externalTools.PS4Input_PadSetLightBar;
					ouEHNmdikaqPuXBGTzXdnnHbZoD = UnityTools.externalTools.PS4Input_PadResetLightBar;
					FQxgoCVsRCabYzUhAewXfZxfBZS = UnityTools.externalTools.PS4Input_PadSetMotionSensorState;
					ZWcBbTPxvhGdoANtISUPyaFMhhr = UnityTools.externalTools.PS4Input_PadSetTiltCorrectionState;
					ryjpfkYKeFKVuTCJREUZinqCMxr = UnityTools.externalTools.PS4Input_PadSetAngularVelocityDeadbandState;
					eflTfaNaWWBenzcJmfNRvMdDBlS = UnityTools.externalTools.PS4Input_PadResetOrientation;
					UgEoXeTBeOrtPySQNcSnzWpPXSW = UnityTools.externalTools.PS4Input_GetLastAcceleration;
					EbBnKMWdvwmeQjgngKQLkySjpJC = UnityTools.externalTools.PS4Input_GetLastGyro;
					mwKTQDfouPZGKxLbrBgerUQHBTGH = UnityTools.externalTools.PS4Input_GetLastOrientation;
					break;
				case BaseControllerType.Special:
					IaScoJKkUcgPZBKbdnFtaqKePfJ = UnityTools.externalTools.PS4Input_SpecialIsConnected;
					tIkEmRsVBMhLzcnbFgPGuAjiKuB = UnityTools.externalTools.PS4Input_SpecialSetVibration;
					cGIiFovSarYuvZeCuCQUDNCAEGm = UnityTools.externalTools.PS4Input_SpecialSetLightSphere;
					ouEHNmdikaqPuXBGTzXdnnHbZoD = UnityTools.externalTools.PS4Input_SpecialResetLightSphere;
					FQxgoCVsRCabYzUhAewXfZxfBZS = UnityTools.externalTools.PS4Input_SpecialSetMotionSensorState;
					ZWcBbTPxvhGdoANtISUPyaFMhhr = UnityTools.externalTools.PS4Input_SpecialSetTiltCorrectionState;
					ryjpfkYKeFKVuTCJREUZinqCMxr = UnityTools.externalTools.PS4Input_SpecialSetAngularVelocityDeadbandState;
					eflTfaNaWWBenzcJmfNRvMdDBlS = UnityTools.externalTools.PS4Input_SpecialResetOrientation;
					UgEoXeTBeOrtPySQNcSnzWpPXSW = UnityTools.externalTools.PS4Input_SpecialGetLastAcceleration;
					EbBnKMWdvwmeQjgngKQLkySjpJC = UnityTools.externalTools.PS4Input_SpecialGetLastGyro;
					mwKTQDfouPZGKxLbrBgerUQHBTGH = UnityTools.externalTools.PS4Input_SpecialGetLastOrientation;
					break;
				case BaseControllerType.Aim:
					IaScoJKkUcgPZBKbdnFtaqKePfJ = UnityTools.externalTools.PS4Input_AimIsConnected;
					tIkEmRsVBMhLzcnbFgPGuAjiKuB = UnityTools.externalTools.PS4Input_AimSetVibration;
					cGIiFovSarYuvZeCuCQUDNCAEGm = UnityTools.externalTools.PS4Input_AimSetLightSphere;
					ouEHNmdikaqPuXBGTzXdnnHbZoD = UnityTools.externalTools.PS4Input_AimResetLightSphere;
					FQxgoCVsRCabYzUhAewXfZxfBZS = UnityTools.externalTools.PS4Input_AimSetMotionSensorState;
					ZWcBbTPxvhGdoANtISUPyaFMhhr = UnityTools.externalTools.PS4Input_AimSetTiltCorrectionState;
					ryjpfkYKeFKVuTCJREUZinqCMxr = UnityTools.externalTools.PS4Input_AimSetAngularVelocityDeadbandState;
					eflTfaNaWWBenzcJmfNRvMdDBlS = UnityTools.externalTools.PS4Input_AimResetOrientation;
					UgEoXeTBeOrtPySQNcSnzWpPXSW = UnityTools.externalTools.PS4Input_GetLastAcceleration;
					EbBnKMWdvwmeQjgngKQLkySjpJC = UnityTools.externalTools.PS4Input_GetLastGyro;
					mwKTQDfouPZGKxLbrBgerUQHBTGH = UnityTools.externalTools.PS4Input_GetLastOrientation;
					break;
				default:
					throw new NotImplementedException();
				}
			}

			public virtual void GzCliicOSMFLMvKajLgvnmGSSrh()
			{
				keDKDZsEbNTZhRjBpesgCRfAdhw();
			}

			public int OrOuibLvsvPjyZcUWHLRgFffOID()
			{
				return OAVTbOWkoHlhaKHhvOEcQZrxjtM;
			}

			int KTMkdEvZQPVUTmRgJNaXAYMPMBS.OrOuibLvsvPjyZcUWHLRgFffOID()
			{
				//ILSpy generated this explicit interface implementation from .override directive in OrOuibLvsvPjyZcUWHLRgFffOID
				return this.OrOuibLvsvPjyZcUWHLRgFffOID();
			}

			public int FEFCWXKKrQhtfLyWQGjbsbNUprL()
			{
				return user.userId;
			}

			int KTMkdEvZQPVUTmRgJNaXAYMPMBS.FEFCWXKKrQhtfLyWQGjbsbNUprL()
			{
				//ILSpy generated this explicit interface implementation from .override directive in FEFCWXKKrQhtfLyWQGjbsbNUprL
				return this.FEFCWXKKrQhtfLyWQGjbsbNUprL();
			}

			public int TuyqAEjWTpwLXlPVeJBhmmYeiw()
			{
				return user.status;
			}

			int KTMkdEvZQPVUTmRgJNaXAYMPMBS.TuyqAEjWTpwLXlPVeJBhmmYeiw()
			{
				//ILSpy generated this explicit interface implementation from .override directive in TuyqAEjWTpwLXlPVeJBhmmYeiw
				return this.TuyqAEjWTpwLXlPVeJBhmmYeiw();
			}

			public bool TsHBUyXOxyECRHasPhTFTGGeeit()
			{
				return user.primaryUser;
			}

			bool KTMkdEvZQPVUTmRgJNaXAYMPMBS.TsHBUyXOxyECRHasPhTFTGGeeit()
			{
				//ILSpy generated this explicit interface implementation from .override directive in TsHBUyXOxyECRHasPhTFTGGeeit
				return this.TsHBUyXOxyECRHasPhTFTGGeeit();
			}

			public Color HJqsHddrOPzPrXcsxZuVgnadHlW()
			{
				LoggedInUser loggedInUser = user;
				while (true)
				{
					switch (-332978767 ^ -332978765)
					{
					case 0:
						continue;
					case 2:
						switch (loggedInUser.color)
						{
						case 0:
							break;
						case 1:
							return Color.red;
						case 2:
							return Color.green;
						case 3:
							return Color.magenta;
						default:
							return Color.black;
						}
						break;
					}
					break;
				}
				return Color.blue;
			}

			Color KTMkdEvZQPVUTmRgJNaXAYMPMBS.HJqsHddrOPzPrXcsxZuVgnadHlW()
			{
				//ILSpy generated this explicit interface implementation from .override directive in HJqsHddrOPzPrXcsxZuVgnadHlW
				return this.HJqsHddrOPzPrXcsxZuVgnadHlW();
			}

			public int aOPfKWuNjpVaOjrETNxMRtjcXsW()
			{
				return user.color;
			}

			int KTMkdEvZQPVUTmRgJNaXAYMPMBS.aOPfKWuNjpVaOjrETNxMRtjcXsW()
			{
				//ILSpy generated this explicit interface implementation from .override directive in aOPfKWuNjpVaOjrETNxMRtjcXsW
				return this.aOPfKWuNjpVaOjrETNxMRtjcXsW();
			}

			public string BkoXGvRKlYCFRLixWgByUhGAtZQ()
			{
				return user.userName;
			}

			string KTMkdEvZQPVUTmRgJNaXAYMPMBS.BkoXGvRKlYCFRLixWgByUhGAtZQ()
			{
				//ILSpy generated this explicit interface implementation from .override directive in BkoXGvRKlYCFRLixWgByUhGAtZQ
				return this.BkoXGvRKlYCFRLixWgByUhGAtZQ();
			}

			public void StopVibration()
			{
				Array.Clear(sJafVNDBNEEbecRSfeQLdaOzuaHh, 0, sJafVNDBNEEbecRSfeQLdaOzuaHh.Length);
				IuIKlhuAUpgiyegJvPnnDqSPYLYe();
			}

			public void SetVibration(int motorIndex, float value)
			{
				if ((uint)motorIndex > (uint)AxhfQtbSsTyxTlOuVNpjukkJjHGw.hSqMknHvfLaCaSKUtNrDJWiYQVX)
				{
					while (true)
					{
						switch (0x17ECD62C ^ 0x17ECD62D)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				sJafVNDBNEEbecRSfeQLdaOzuaHh[motorIndex] = value;
				IuIKlhuAUpgiyegJvPnnDqSPYLYe();
			}

			public float GetVibration(int motorIndex)
			{
				if ((uint)motorIndex > (uint)AxhfQtbSsTyxTlOuVNpjukkJjHGw.hSqMknHvfLaCaSKUtNrDJWiYQVX)
				{
					return 0f;
				}
				return sJafVNDBNEEbecRSfeQLdaOzuaHh[motorIndex];
			}

			public void SetMotionSensorState(bool enabled)
			{
				FQxgoCVsRCabYzUhAewXfZxfBZS(cNcLkMBaCDcdcMeoQVAxVFVuHEv, enabled);
			}

			public void SetTiltCorrectionState(bool enabled)
			{
				ZWcBbTPxvhGdoANtISUPyaFMhhr(cNcLkMBaCDcdcMeoQVAxVFVuHEv, enabled);
			}

			public void SetAngularVelocityDeadbandState(bool enabled)
			{
				ryjpfkYKeFKVuTCJREUZinqCMxr(cNcLkMBaCDcdcMeoQVAxVFVuHEv, enabled);
			}

			public void ResetOrientation()
			{
				eflTfaNaWWBenzcJmfNRvMdDBlS(cNcLkMBaCDcdcMeoQVAxVFVuHEv);
			}

			public Vector3 GetLastAcceleration()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				Vector3 result = UgEoXeTBeOrtPySQNcSnzWpPXSW(cNcLkMBaCDcdcMeoQVAxVFVuHEv);
				aCWFOONWkvMWdrhoSKZhhnIcKWd(ref result);
				return result;
			}

			public Vector3 GetLastAccelerationRaw()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				return UgEoXeTBeOrtPySQNcSnzWpPXSW(cNcLkMBaCDcdcMeoQVAxVFVuHEv);
			}

			public Vector3 GetLastGyro()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				Vector3 result = EbBnKMWdvwmeQjgngKQLkySjpJC(cNcLkMBaCDcdcMeoQVAxVFVuHEv);
				uLMyabGBmnAWfBQCjiYaouiwlTdk(ref result);
				return result;
			}

			public Vector3 GetLastGyroRaw()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				return EbBnKMWdvwmeQjgngKQLkySjpJC(cNcLkMBaCDcdcMeoQVAxVFVuHEv);
			}

			public Quaternion GetLastOrientation()
			{
				if (!IsConnectedNow)
				{
					return Quaternion.identity;
				}
				Vector4 vector = mwKTQDfouPZGKxLbrBgerUQHBTGH(cNcLkMBaCDcdcMeoQVAxVFVuHEv);
				return new Quaternion(vector.x * -1f, vector.y, vector.z, vector.w);
			}

			public Quaternion GetLastOrientationRaw()
			{
				if (!IsConnectedNow)
				{
					return Quaternion.identity;
				}
				Vector4 vector = mwKTQDfouPZGKxLbrBgerUQHBTGH(cNcLkMBaCDcdcMeoQVAxVFVuHEv);
				return new Quaternion(vector.x, vector.y, vector.z, vector.w);
			}

			public void SetLightColor(int red, int green, int blue)
			{
				cGIiFovSarYuvZeCuCQUDNCAEGm(cNcLkMBaCDcdcMeoQVAxVFVuHEv, red, green, blue);
			}

			public void ResetLight()
			{
				ouEHNmdikaqPuXBGTzXdnnHbZoD(cNcLkMBaCDcdcMeoQVAxVFVuHEv);
			}

			protected virtual void keDKDZsEbNTZhRjBpesgCRfAdhw()
			{
				int joystickId = FeaeSsBIvGENCmfHDJxvHHDdpYR + 1;
				IList<Button> buttons = base.Buttons;
				IList<Axis> axes = default(IList<Axis>);
				while (true)
				{
					int num = -1072241571;
					while (true)
					{
						switch (num ^ -1072241572)
						{
						case 2:
							break;
						case 6:
						{
							buttons[7].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 7);
							buttons[8].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 8);
							buttons[9].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 9);
							float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 5);
							float joystickAxisValueByJoystickId2 = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 6);
							buttons[10].value = joystickAxisValueByJoystickId2 > AxhfQtbSsTyxTlOuVNpjukkJjHGw.BrzeGahpdAtwdxwBZYHiLKshdHi;
							buttons[11].value = joystickAxisValueByJoystickId > AxhfQtbSsTyxTlOuVNpjukkJjHGw.BrzeGahpdAtwdxwBZYHiLKshdHi;
							buttons[12].value = joystickAxisValueByJoystickId2 < 0f - AxhfQtbSsTyxTlOuVNpjukkJjHGw.BrzeGahpdAtwdxwBZYHiLKshdHi;
							buttons[13].value = joystickAxisValueByJoystickId < 0f - AxhfQtbSsTyxTlOuVNpjukkJjHGw.BrzeGahpdAtwdxwBZYHiLKshdHi;
							axes = base.Axes;
							axes[0].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 0);
							num = -1072241579;
							continue;
						}
						case 5:
							buttons[6].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 6);
							num = -1072241574;
							continue;
						case 0:
							buttons[1].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 1);
							num = -1072241576;
							continue;
						case 1:
							buttons[0].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 0);
							num = -1072241572;
							continue;
						case 4:
							buttons[2].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 2);
							num = -1072241573;
							continue;
						case 8:
							buttons[4].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 4);
							num = -1072241569;
							continue;
						case 3:
							buttons[5].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 5);
							num = -1072241575;
							continue;
						case 7:
							buttons[3].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 3);
							num = -1072241580;
							continue;
						default:
							axes[1].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 1);
							axes[2].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 3);
							axes[3].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 4);
							axes[4].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 7);
							axes[5].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 2);
							return;
						}
						break;
					}
				}
			}

			protected void IuIKlhuAUpgiyegJvPnnDqSPYLYe()
			{
				if (AxhfQtbSsTyxTlOuVNpjukkJjHGw.hSqMknHvfLaCaSKUtNrDJWiYQVX == 0)
				{
					return;
				}
				while (true)
				{
					tIkEmRsVBMhLzcnbFgPGuAjiKuB(cNcLkMBaCDcdcMeoQVAxVFVuHEv, CbAqoSCBEIHOckLumTOkQwzcXHQM(sJafVNDBNEEbecRSfeQLdaOzuaHh[0]), CbAqoSCBEIHOckLumTOkQwzcXHQM(sJafVNDBNEEbecRSfeQLdaOzuaHh[1]));
					int num = -858260383;
					while (true)
					{
						switch (num ^ -858260381)
						{
						case 0:
							goto IL_000e;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_000e:
						num = -858260382;
					}
				}
			}

			public static int CbAqoSCBEIHOckLumTOkQwzcXHQM(float P_0)
			{
				if (P_0 <= 0f)
				{
					goto IL_0008;
				}
				int num;
				if (P_0 >= 1f)
				{
					num = 905515128;
					goto IL_000d;
				}
				return (int)(P_0 * 255f);
				IL_0008:
				num = 905515131;
				goto IL_000d;
				IL_000d:
				switch (num ^ 0x35F9107A)
				{
				case 0:
					break;
				case 1:
					return 0;
				default:
					return 255;
				}
				goto IL_0008;
			}

			public static void aCWFOONWkvMWdrhoSKZhhnIcKWd(ref Vector3 P_0)
			{
				P_0.x *= -1f;
				P_0.y *= -1f;
			}

			public static void uLMyabGBmnAWfBQCjiYaouiwlTdk(ref Vector3 P_0)
			{
				P_0.x *= -1f;
				P_0.y *= -1f;
			}

			public static bool nGeoziOhtwTNpPnenABvnfNyDupC(int P_0, out ControllerType P_1)
			{
				string text = UnityTools.externalTools.PS4Input_GetDeviceClassString(P_0);
				while (true)
				{
					int num = 1346677943;
					while (true)
					{
						switch (num ^ 0x5044ACB2)
						{
						case 9:
							break;
						case 7:
							P_1 = ControllerType.FlightStick;
							return true;
						case 3:
							P_1 = ControllerType.Guitar;
							num = 1346677944;
							continue;
						case 5:
							if (string.IsNullOrEmpty(text))
							{
								num = 1346677946;
								continue;
							}
							if (!text.Equals("Standard", StringComparison.OrdinalIgnoreCase))
							{
								if (text.Equals("FlightStick", StringComparison.OrdinalIgnoreCase))
								{
									goto case 7;
								}
								if (!text.Equals("hotas", StringComparison.OrdinalIgnoreCase))
								{
									if (!text.Equals("Stick", StringComparison.OrdinalIgnoreCase))
									{
										if (text.Equals("hotas", StringComparison.OrdinalIgnoreCase))
										{
											num = 1346677940;
											continue;
										}
										if (text.Equals("SteeringWheel", StringComparison.OrdinalIgnoreCase))
										{
											P_1 = ControllerType.SteeringWheel;
											return true;
										}
										if (text.Equals("Guitar", StringComparison.OrdinalIgnoreCase))
										{
											num = 1346677937;
										}
										else if (!text.Equals("Drum", StringComparison.OrdinalIgnoreCase))
										{
											if (!text.Equals("Gun", StringComparison.OrdinalIgnoreCase))
											{
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
												if (!text.Equals("Navigation", StringComparison.OrdinalIgnoreCase))
												{
													P_1 = ControllerType.Unknown;
													return false;
												}
												num = 1346677936;
											}
											else
											{
												num = 1346677942;
											}
										}
										else
										{
											num = 1346677938;
										}
										continue;
									}
									goto case 6;
								}
								num = 1346677941;
								continue;
							}
							num = 1346677945;
							continue;
						case 11:
							P_1 = ControllerType.Gamepad;
							return true;
						case 2:
							P_1 = ControllerType.Navigation;
							num = 1346677939;
							continue;
						case 6:
							P_1 = ControllerType.FlightStick;
							return true;
						case 8:
							P_1 = ControllerType.Unknown;
							return false;
						case 4:
							P_1 = ControllerType.Gun;
							return true;
						case 0:
							P_1 = ControllerType.Drum;
							return true;
						case 10:
							return true;
						default:
							return true;
						}
						break;
					}
				}
			}
		}

		private sealed class nykSSJpGiEvmZwRVEUprkhvVtFw : mOrDiYzmAbwIqufLyKjxgdKjoKL, KTMkdEvZQPVUTmRgJNaXAYMPMBS, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource, IPS4ControllerExtensionSourceTouchPad, IPS4GamepadExtensionSource
		{
			private const int ooxLfNrAogzyUTrvphoSPkzSmQV = 6;

			private const int wFuDaAjcZJRXwRVbVLebvOVVnWXe = 14;

			private const float mjcNVbJWoSqQhPezDGXHgUgNqWjS = 0.05f;

			private const int ufZjTLfmHHKBLaLJgrJDAHXfaebD = 2;

			private const int UgdtQDSIdRJcOHsYeFsMoKZgseA = 2;

			private int SabNViEiKLHOjZEMUbaCAHgMqruh;

			private int ttMOgfYAzzdGgiVbtCcDVHoqLuqi;

			private Vector2 BrefKGJHTIbydwntjuwdNRcQrpYx;

			private int sSqFhCASZnenqeMBZBFZgIAXqqld;

			private Vector2 DMoFomREFBHWfhmAZJKwIiUIBuR;

			private MMpEyEfjjkCltTIFZwEOOkDwSSo UIyLxvyLFuLRVirJJPDAcRrjiYx;

			private int kGjPhltAeQdxgTTWrJQBmPAoHeUA;

			private int aFxbFlqDlueDVhSjsmczhyyEdPHo;

			private int iCptiZlDuypaioMIiKdOieeoFAK;

			private int JzwUbzWbhaHjyQbYqjKmxZEvdyk;

			private float LVMEQKJlUTgLPOfMmWaqtsyDrMZ;

			public int maxTouches => AxhfQtbSsTyxTlOuVNpjukkJjHGw.RGdsKBxcbNELteuziwUlifWUYzh;

			public nykSSJpGiEvmZwRVEUprkhvVtFw(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Gamepad, BaseControllerType.Gamepad, name, playerId, unityJoystickId, handle, new GWpMCaspiKkWlhUhKLXnyePvnIQ(6, 14, 0.05f, 2, 2))
			{
				dHfFdAFdXwGmnUMjzIdYADgaGzoi();
				base.extension = new PS4GamepadExtension(this);
			}

			public int GetConnectionType()
			{
				return (int)UIyLxvyLFuLRVirJJPDAcRrjiYx;
			}

			public int GetAnalogDeadZoneLeft()
			{
				return iCptiZlDuypaioMIiKdOieeoFAK;
			}

			public int GetAnalogDeadZoneRight()
			{
				return JzwUbzWbhaHjyQbYqjKmxZEvdyk;
			}

			public float GetTouchPixelDensity()
			{
				return LVMEQKJlUTgLPOfMmWaqtsyDrMZ;
			}

			public int GetTouchpadResolutionX()
			{
				return kGjPhltAeQdxgTTWrJQBmPAoHeUA;
			}

			public int GetTouchpadResolutionY()
			{
				return aFxbFlqDlueDVhSjsmczhyyEdPHo;
			}

			public int GetTouchCount()
			{
				return SabNViEiKLHOjZEMUbaCAHgMqruh;
			}

			public int GetTouchId(int index)
			{
				if (index >= 0)
				{
					while (true)
					{
						int num = 393642234;
						while (true)
						{
							switch (num ^ 0x177680FB)
							{
							case 3:
								break;
							case 1:
								goto IL_0026;
							case 2:
								goto end_IL_0004;
							default:
								goto IL_0056;
							}
							break;
							IL_0026:
							if (index >= AxhfQtbSsTyxTlOuVNpjukkJjHGw.RGdsKBxcbNELteuziwUlifWUYzh)
							{
								num = 393642233;
								continue;
							}
							goto IL_003d;
						}
						continue;
						IL_0056:
						return ttMOgfYAzzdGgiVbtCcDVHoqLuqi;
						IL_003d:
						switch (index)
						{
						case 0:
							break;
						case 1:
							return sSqFhCASZnenqeMBZBFZgIAXqqld;
						default:
							return -1;
						}
						goto IL_0056;
						continue;
						end_IL_0004:
						break;
					}
				}
				return -1;
			}

			public bool GetTouchPositionAbsByIndex(int index, out Vector2 position)
			{
				int num = default(int);
				int num2;
				if (index >= 0 && index < AxhfQtbSsTyxTlOuVNpjukkJjHGw.RGdsKBxcbNELteuziwUlifWUYzh)
				{
					if (!IsTouchingByIndex(index))
					{
						goto IL_001b;
					}
					num = index;
					num2 = -880076313;
					goto IL_0020;
				}
				goto IL_0072;
				IL_001b:
				num2 = -880076317;
				goto IL_0020;
				IL_0020:
				while (true)
				{
					switch (num2 ^ -880076318)
					{
					case 0:
						break;
					case 3:
						position = BrefKGJHTIbydwntjuwdNRcQrpYx;
						num2 = -880076314;
						continue;
					case 1:
						goto IL_0072;
					case 5:
						switch (num)
						{
						case 0:
							break;
						default:
							goto IL_0092;
						case 1:
							goto IL_0099;
						}
						goto case 3;
					case 2:
						goto IL_0099;
					default:
						position = default(Vector2);
						return false;
					case 4:
					case 7:
						{
							return true;
						}
						IL_0099:
						position = DMoFomREFBHWfhmAZJKwIiUIBuR;
						num2 = -880076315;
						continue;
						IL_0092:
						num2 = -880076316;
						continue;
					}
					break;
				}
				goto IL_001b;
				IL_0072:
				position = default(Vector2);
				return false;
			}

			public bool GetTouchPositionAbsByTouchId(int touchId, out Vector2 position)
			{
				int num = UGGSMkBJlSdiQjIyeIqLGdzijqfo(touchId);
				if (num < 0)
				{
					position = default(Vector2);
					return false;
				}
				return GetTouchPositionAbsByIndex(num, out position);
			}

			public bool GetTouchPositionByIndex(int index, out Vector2 position)
			{
				if (index >= 0)
				{
					int num2 = default(int);
					while (true)
					{
						int num = 183706633;
						while (true)
						{
							switch (num ^ 0xAF32401)
							{
							case 7:
								break;
							case 4:
								switch (num2)
								{
								case 1:
									goto IL_0055;
								case 0:
									goto IL_007d;
								}
								num = 183706626;
								continue;
							case 0:
								goto IL_0055;
							case 2:
								goto IL_007d;
							case 6:
								goto end_IL_0007;
							case 3:
								position = default(Vector2);
								num = 183706624;
								continue;
							case 8:
								goto IL_00dc;
							default:
								return false;
							case 5:
								{
									position.x /= kGjPhltAeQdxgTTWrJQBmPAoHeUA;
									position.y /= aFxbFlqDlueDVhSjsmczhyyEdPHo;
									return true;
								}
								IL_007d:
								position = new Vector2(BrefKGJHTIbydwntjuwdNRcQrpYx.x, BrefKGJHTIbydwntjuwdNRcQrpYx.y);
								goto case 5;
								IL_0055:
								position = new Vector2(DMoFomREFBHWfhmAZJKwIiUIBuR.x, DMoFomREFBHWfhmAZJKwIiUIBuR.y);
								num = 183706628;
								continue;
							}
							break;
							IL_00dc:
							if (index >= AxhfQtbSsTyxTlOuVNpjukkJjHGw.RGdsKBxcbNELteuziwUlifWUYzh)
							{
								goto end_IL_0007;
							}
							if (IsTouchingByIndex(index))
							{
								num2 = index;
								num = 183706629;
							}
							else
							{
								num = 183706631;
							}
						}
						continue;
						end_IL_0007:
						break;
					}
				}
				position = default(Vector2);
				return false;
			}

			public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
			{
				int num = UGGSMkBJlSdiQjIyeIqLGdzijqfo(touchId);
				if (num < 0)
				{
					position = default(Vector2);
					return false;
				}
				return GetTouchPositionByIndex(num, out position);
			}

			public bool IsTouchingByIndex(int index)
			{
				if (index >= 0)
				{
					while (true)
					{
						int num = 1145633482;
						while (true)
						{
							switch (num ^ 0x4448FACB)
							{
							case 2:
								break;
							case 1:
								goto IL_0022;
							default:
								goto end_IL_0004;
							}
							break;
							IL_0022:
							if (index >= AxhfQtbSsTyxTlOuVNpjukkJjHGw.RGdsKBxcbNELteuziwUlifWUYzh)
							{
								num = 1145633483;
								continue;
							}
							return index < SabNViEiKLHOjZEMUbaCAHgMqruh;
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				return false;
			}

			public bool IsTouchingByTouchId(int touchId)
			{
				if (touchId < 0)
				{
					return false;
				}
				int num = UGGSMkBJlSdiQjIyeIqLGdzijqfo(touchId);
				return num >= 0;
			}

			protected override void keDKDZsEbNTZhRjBpesgCRfAdhw()
			{
				base.keDKDZsEbNTZhRjBpesgCRfAdhw();
				UnityTools.externalTools.PS4Input_GetLastTouchData(cNcLkMBaCDcdcMeoQVAxVFVuHEv, out SabNViEiKLHOjZEMUbaCAHgMqruh, out var touch0x, out var touch0y, out ttMOgfYAzzdGgiVbtCcDVHoqLuqi, out var touch1x, out var touch1y, out sSqFhCASZnenqeMBZBFZgIAXqqld);
				while (true)
				{
					int num = -403268057;
					while (true)
					{
						switch (num ^ -403268058)
						{
						case 3:
							break;
						case 1:
							BrefKGJHTIbydwntjuwdNRcQrpYx.x = touch0x;
							BrefKGJHTIbydwntjuwdNRcQrpYx.y = aFxbFlqDlueDVhSjsmczhyyEdPHo - touch0y;
							num = -403268060;
							continue;
						case 2:
							DMoFomREFBHWfhmAZJKwIiUIBuR.x = touch1x;
							num = -403268058;
							continue;
						default:
							DMoFomREFBHWfhmAZJKwIiUIBuR.y = aFxbFlqDlueDVhSjsmczhyyEdPHo - touch1y;
							return;
						}
						break;
					}
				}
			}

			private void dHfFdAFdXwGmnUMjzIdYADgaGzoi()
			{
				IExternalTools externalTools = UnityTools.externalTools;
				externalTools.PS4Input_GetPadControllerInformation(cNcLkMBaCDcdcMeoQVAxVFVuHEv, out LVMEQKJlUTgLPOfMmWaqtsyDrMZ, out kGjPhltAeQdxgTTWrJQBmPAoHeUA, out aFxbFlqDlueDVhSjsmczhyyEdPHo, out iCptiZlDuypaioMIiKdOieeoFAK, out JzwUbzWbhaHjyQbYqjKmxZEvdyk, out var connectionType);
				UIyLxvyLFuLRVirJJPDAcRrjiYx = (MMpEyEfjjkCltTIFZwEOOkDwSSo)connectionType;
				externalTools.PS4Input_PadResetOrientation(cNcLkMBaCDcdcMeoQVAxVFVuHEv);
			}

			private int UGGSMkBJlSdiQjIyeIqLGdzijqfo(int P_0)
			{
				if (P_0 < 0)
				{
					goto IL_0004;
				}
				int num;
				if (SabNViEiKLHOjZEMUbaCAHgMqruh > 0 && ttMOgfYAzzdGgiVbtCcDVHoqLuqi == P_0)
				{
					num = 2036606141;
				}
				else
				{
					if (SabNViEiKLHOjZEMUbaCAHgMqruh <= 1)
					{
						goto IL_005e;
					}
					num = 2036606142;
				}
				goto IL_0009;
				IL_0053:
				if (sSqFhCASZnenqeMBZBFZgIAXqqld == P_0)
				{
					return 1;
				}
				goto IL_005e;
				IL_0009:
				switch (num ^ 0x796424BC)
				{
				case 0:
					break;
				case 3:
					return -1;
				case 1:
					return 0;
				default:
					goto IL_0053;
				}
				goto IL_0004;
				IL_0004:
				num = 2036606143;
				goto IL_0009;
				IL_005e:
				return -1;
			}
		}

		private sealed class BDAFsAfwNAgkufQxLAKASDkAwXde : mOrDiYzmAbwIqufLyKjxgdKjoKL, KTMkdEvZQPVUTmRgJNaXAYMPMBS, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource, IPS4AimExtensionSource
		{
			private const int ooxLfNrAogzyUTrvphoSPkzSmQV = 6;

			private const int wFuDaAjcZJRXwRVbVLebvOVVnWXe = 14;

			private const float mjcNVbJWoSqQhPezDGXHgUgNqWjS = 0.05f;

			private const int ufZjTLfmHHKBLaLJgrJDAHXfaebD = 2;

			private const int UgdtQDSIdRJcOHsYeFsMoKZgseA = 2;

			private int SabNViEiKLHOjZEMUbaCAHgMqruh;

			private int ttMOgfYAzzdGgiVbtCcDVHoqLuqi;

			private Vector2 BrefKGJHTIbydwntjuwdNRcQrpYx;

			private int sSqFhCASZnenqeMBZBFZgIAXqqld;

			private Vector2 DMoFomREFBHWfhmAZJKwIiUIBuR;

			private MMpEyEfjjkCltTIFZwEOOkDwSSo UIyLxvyLFuLRVirJJPDAcRrjiYx;

			private int kGjPhltAeQdxgTTWrJQBmPAoHeUA;

			private int aFxbFlqDlueDVhSjsmczhyyEdPHo;

			private int iCptiZlDuypaioMIiKdOieeoFAK;

			private int JzwUbzWbhaHjyQbYqjKmxZEvdyk;

			private float LVMEQKJlUTgLPOfMmWaqtsyDrMZ;

			public BDAFsAfwNAgkufQxLAKASDkAwXde(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Aim, BaseControllerType.Aim, name, playerId, unityJoystickId, handle, new GWpMCaspiKkWlhUhKLXnyePvnIQ(6, 14, 0.05f, 2, 2))
			{
				base.extension = new PS4AimExtension(this);
			}
		}

		private abstract class AaqcVzHsxirAeTeVWPZUZccOoNbi : mOrDiYzmAbwIqufLyKjxgdKjoKL
		{
			protected AaqcVzHsxirAeTeVWPZUZccOoNbi(ControllerType controllerType, string name, int playerId, int unityJoystickId, int handle, GWpMCaspiKkWlhUhKLXnyePvnIQ capabilities)
				: base(controllerType, BaseControllerType.Special, name, playerId, unityJoystickId, handle, capabilities)
			{
			}

			public static AaqcVzHsxirAeTeVWPZUZccOoNbi GIHuiEkmFihgdjpqkqIhwXanlmm(int P_0, int P_1, int P_2)
			{
				if (!mOrDiYzmAbwIqufLyKjxgdKjoKL.nGeoziOhtwTNpPnenABvnfNyDupC(P_0, out var controllerType))
				{
					return null;
				}
				return GIHuiEkmFihgdjpqkqIhwXanlmm(controllerType, P_1, P_2);
			}

			public static AaqcVzHsxirAeTeVWPZUZccOoNbi GIHuiEkmFihgdjpqkqIhwXanlmm(ControllerType P_0, int P_1, int P_2)
			{
				int unityJoystickId = P_1 + 13;
				while (true)
				{
					int num = -975169382;
					while (true)
					{
						switch (num ^ -975169384)
						{
						case 0:
							break;
						case 2:
							switch (P_0)
							{
							default:
								goto IL_005f;
							case ControllerType.Unknown:
							case ControllerType.Gamepad:
							case ControllerType.Aim:
								break;
							case ControllerType.Drum:
								return new lyoeVVGlPzNTDeJDarJaDnQbmjhP("Drums " + (P_1 + 1), P_1, unityJoystickId, P_2);
							case ControllerType.FlightStick:
								return new lVJOuYVvXxpRhqzOygiyOFREsOc("Flight Stick " + (P_1 + 1), P_1, unityJoystickId, P_2);
							case ControllerType.Guitar:
								return new zJpiAQJwnbFGWrCYLaumlnGZWse("Guitar " + (P_1 + 1), P_1, unityJoystickId, P_2);
							case ControllerType.SteeringWheel:
								return new IKEOqppvPyMURuyUQImPYTnZNDO("Steering Wheel " + (P_1 + 1), P_1, unityJoystickId, P_2);
							case ControllerType.DjTurntable:
							case ControllerType.DanceMat:
							case ControllerType.Navigation:
							case ControllerType.Stick:
							case ControllerType.Gun:
								return null;
							}
							goto default;
						default:
							return null;
						case 3:
							throw new NotImplementedException();
						}
						break;
						IL_005f:
						num = -975169381;
					}
				}
			}
		}

		private sealed class IKEOqppvPyMURuyUQImPYTnZNDO : AaqcVzHsxirAeTeVWPZUZccOoNbi
		{
			private const int ooxLfNrAogzyUTrvphoSPkzSmQV = 13;

			private const int wFuDaAjcZJRXwRVbVLebvOVVnWXe = 14;

			private const float mjcNVbJWoSqQhPezDGXHgUgNqWjS = 0.05f;

			private const int ufZjTLfmHHKBLaLJgrJDAHXfaebD = 2;

			private const int UgdtQDSIdRJcOHsYeFsMoKZgseA = 0;

			public IKEOqppvPyMURuyUQImPYTnZNDO(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.SteeringWheel, name, playerId, unityJoystickId, handle, new GWpMCaspiKkWlhUhKLXnyePvnIQ(13, 14, 0.05f, 2, 0))
			{
				base.extension = new PS4ControllerExtension(this);
			}

			protected override void keDKDZsEbNTZhRjBpesgCRfAdhw()
			{
				base.keDKDZsEbNTZhRjBpesgCRfAdhw();
				int joystickId = FeaeSsBIvGENCmfHDJxvHHDdpYR + 1;
				IList<Axis> axes = base.Axes;
				axes[6].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 10);
				axes[7].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 11);
				axes[8].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 12);
				axes[9].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 13);
				while (true)
				{
					int num = -772975967;
					while (true)
					{
						switch (num ^ -772975966)
						{
						case 2:
							break;
						default:
							return;
						case 3:
							axes[10].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 14);
							axes[11].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 15);
							num = -772975966;
							continue;
						case 0:
							axes[12].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 16);
							num = -772975965;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		private sealed class zJpiAQJwnbFGWrCYLaumlnGZWse : AaqcVzHsxirAeTeVWPZUZccOoNbi
		{
			private const int ooxLfNrAogzyUTrvphoSPkzSmQV = 11;

			private const int wFuDaAjcZJRXwRVbVLebvOVVnWXe = 14;

			private const float mjcNVbJWoSqQhPezDGXHgUgNqWjS = 0.05f;

			private const int ufZjTLfmHHKBLaLJgrJDAHXfaebD = 2;

			private const int UgdtQDSIdRJcOHsYeFsMoKZgseA = 0;

			public zJpiAQJwnbFGWrCYLaumlnGZWse(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Guitar, name, playerId, unityJoystickId, handle, new GWpMCaspiKkWlhUhKLXnyePvnIQ(11, 14, 0.05f, 2, 0))
			{
				base.extension = new PS4ControllerExtension(this);
			}

			protected override void keDKDZsEbNTZhRjBpesgCRfAdhw()
			{
				base.keDKDZsEbNTZhRjBpesgCRfAdhw();
				int joystickId = FeaeSsBIvGENCmfHDJxvHHDdpYR + 1;
				IList<Axis> axes = base.Axes;
				axes[6].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 10);
				axes[7].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 11);
				axes[8].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 12);
				axes[9].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 13);
				axes[10].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 14);
			}
		}

		private sealed class lyoeVVGlPzNTDeJDarJaDnQbmjhP : AaqcVzHsxirAeTeVWPZUZccOoNbi
		{
			private const int ooxLfNrAogzyUTrvphoSPkzSmQV = 13;

			private const int wFuDaAjcZJRXwRVbVLebvOVVnWXe = 14;

			private const float mjcNVbJWoSqQhPezDGXHgUgNqWjS = 0.05f;

			private const int ufZjTLfmHHKBLaLJgrJDAHXfaebD = 2;

			private const int UgdtQDSIdRJcOHsYeFsMoKZgseA = 0;

			public lyoeVVGlPzNTDeJDarJaDnQbmjhP(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Drum, name, playerId, unityJoystickId, handle, new GWpMCaspiKkWlhUhKLXnyePvnIQ(13, 14, 0.05f, 2, 0))
			{
				base.extension = new PS4ControllerExtension(this);
			}

			protected override void keDKDZsEbNTZhRjBpesgCRfAdhw()
			{
				base.keDKDZsEbNTZhRjBpesgCRfAdhw();
				int joystickId = FeaeSsBIvGENCmfHDJxvHHDdpYR + 1;
				IList<Axis> axes = default(IList<Axis>);
				while (true)
				{
					int num = -167960295;
					while (true)
					{
						switch (num ^ -167960294)
						{
						case 0:
							break;
						case 3:
							axes = base.Axes;
							axes[6].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 10);
							axes[7].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 11);
							num = -167960290;
							continue;
						case 2:
							axes[11].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 15);
							num = -167960293;
							continue;
						case 4:
							axes[8].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 12);
							axes[9].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 13);
							axes[10].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 14);
							num = -167960296;
							continue;
						default:
							axes[12].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 16);
							return;
						}
						break;
					}
				}
			}
		}

		private sealed class lVJOuYVvXxpRhqzOygiyOFREsOc : AaqcVzHsxirAeTeVWPZUZccOoNbi
		{
			private const int ooxLfNrAogzyUTrvphoSPkzSmQV = 16;

			private const int wFuDaAjcZJRXwRVbVLebvOVVnWXe = 14;

			private const float mjcNVbJWoSqQhPezDGXHgUgNqWjS = 0.05f;

			private const int ufZjTLfmHHKBLaLJgrJDAHXfaebD = 2;

			private const int UgdtQDSIdRJcOHsYeFsMoKZgseA = 0;

			public lVJOuYVvXxpRhqzOygiyOFREsOc(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.FlightStick, name, playerId, unityJoystickId, handle, new GWpMCaspiKkWlhUhKLXnyePvnIQ(16, 14, 0.05f, 2, 0))
			{
				while (true)
				{
					int num = -1140913095;
					while (true)
					{
						switch (num ^ -1140913096)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_003b;
						case 2:
							return;
						}
						break;
						IL_003b:
						base.extension = new PS4ControllerExtension(this);
						num = -1140913094;
					}
				}
			}

			protected override void keDKDZsEbNTZhRjBpesgCRfAdhw()
			{
				base.keDKDZsEbNTZhRjBpesgCRfAdhw();
				int joystickId = FeaeSsBIvGENCmfHDJxvHHDdpYR + 1;
				IList<Axis> axes = base.Axes;
				axes[6].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 10);
				while (true)
				{
					int num = -1647427106;
					while (true)
					{
						switch (num ^ -1647427107)
						{
						case 0:
							break;
						case 3:
							axes[7].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 11);
							axes[8].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 12);
							axes[9].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 13);
							num = -1647427108;
							continue;
						case 1:
							axes[10].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 14);
							num = -1647427105;
							continue;
						default:
							axes[11].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 15);
							axes[12].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 16);
							axes[13].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 17);
							axes[14].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 18);
							axes[15].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 19);
							return;
						}
						break;
					}
				}
			}
		}

		private tEmrawKbhbEVmgDlgbmzqwbnQAM AFdIDAdBUfsHRqyFCiGUrUTAaFLv;

		private bool kfRqJPikKfSDqvTUMmXmDGSqQuX = true;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public override bool isReady => true;

		bool IControllerAssigner.enabled
		{
			get
			{
				return kfRqJPikKfSDqvTUMmXmDGSqQuX;
			}
			set
			{
				kfRqJPikKfSDqvTUMmXmDGSqQuX = value;
			}
		}

		public PS4InputSource()
			: base(22)
		{
			ReInput.controllerAssigner = this;
			AFdIDAdBUfsHRqyFCiGUrUTAaFLv = new tEmrawKbhbEVmgDlgbmzqwbnQAM(4);
			AFdIDAdBUfsHRqyFCiGUrUTAaFLv.ControllerConnectedEvent += UjMZjDWOKcxaYofEYPLyTzrvJod;
			AFdIDAdBUfsHRqyFCiGUrUTAaFLv.ControllerDisconnectedEvent += HHTLDeKmCmmufThZnyFXROYScef;
		}

		public override void Update()
		{
			AFdIDAdBUfsHRqyFCiGUrUTAaFLv.GzCliicOSMFLMvKajLgvnmGSSrh();
			IList<Joystick> joysticks = GetJoysticks();
			int count = joysticks.Count;
			int num = 0;
			while (true)
			{
				if (num < count)
				{
					try
					{
						joysticks[num].Update();
					}
					catch (Exception ex)
					{
						while (true)
						{
							IL_002c:
							int num2 = 2135193202;
							while (true)
							{
								switch (num2 ^ 0x7F447673)
								{
								case 2:
									break;
								default:
									goto end_IL_0031;
								case 1:
									goto IL_004a;
								case 0:
									goto end_IL_0031;
								}
								goto IL_002c;
								IL_004a:
								Logger.LogError("An exception occurred during source joystick update.\n" + ex);
								num2 = 2135193203;
								continue;
								end_IL_0031:
								break;
							}
							break;
						}
					}
					num++;
					goto IL_0067;
				}
				int num3 = 2135193201;
				goto IL_006c;
				IL_006c:
				switch (num3 ^ 0x7F447673)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					continue;
				case 2:
					return;
				}
				goto IL_0067;
				IL_0067:
				num3 = 2135193202;
				goto IL_006c;
			}
		}

		private static int tUUGlLGOPUFMhKBlHektGsngwDA(int P_0)
		{
			if (P_0 >= 13)
			{
				return P_0 - 13;
			}
			return P_0 - 1;
		}

		private void UjMZjDWOKcxaYofEYPLyTzrvJod(tEmrawKbhbEVmgDlgbmzqwbnQAM.jwkwODhGsrrLkdyCGLEPdvKAJnm P_0)
		{
			mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType hLFqbKsLnhVDQrSCeKaRQrimbrF = P_0.hLFqbKsLnhVDQrSCeKaRQrimbrF;
			mOrDiYzmAbwIqufLyKjxgdKjoKL mOrDiYzmAbwIqufLyKjxgdKjoKL2 = default(mOrDiYzmAbwIqufLyKjxgdKjoKL);
			while (true)
			{
				int num = -1737786870;
				while (true)
				{
					int num2;
					switch (num ^ -1737786865)
					{
					case 6:
						break;
					case 0:
						if (mOrDiYzmAbwIqufLyKjxgdKjoKL2 == null)
						{
							return;
						}
						goto default;
					case 4:
						return;
					case 5:
						switch (hLFqbKsLnhVDQrSCeKaRQrimbrF)
						{
						case mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType.Gamepad:
							goto IL_0070;
						case mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType.Aim:
							goto IL_009a;
						case mOrDiYzmAbwIqufLyKjxgdKjoKL.BaseControllerType.Special:
							goto IL_00d0;
						}
						num = -1737786868;
						continue;
					case 8:
						goto IL_0070;
					case 1:
						goto IL_009a;
					case 3:
						throw new NotImplementedException();
					case 2:
						goto IL_00d0;
					default:
						{
							xqxMYnGQaRqtFqUPaxwGtpwhQcs(mOrDiYzmAbwIqufLyKjxgdKjoKL2);
							return;
						}
						IL_00d0:
						mOrDiYzmAbwIqufLyKjxgdKjoKL2 = AaqcVzHsxirAeTeVWPZUZccOoNbi.GIHuiEkmFihgdjpqkqIhwXanlmm(P_0.lnlNhzZfDvBdeKdlVfYEtzHVjqZ, P_0.wdJNnMRgnpHAWIQUEkdXEsJWDJsH, P_0.AhODPAPEiKQbFcMqyoClsiOEHsd);
						if (mOrDiYzmAbwIqufLyKjxgdKjoKL2 != null)
						{
							num = -1737786872;
							num2 = num;
						}
						else
						{
							num = -1737786869;
							num2 = num;
						}
						continue;
						IL_009a:
						mOrDiYzmAbwIqufLyKjxgdKjoKL2 = mOrDiYzmAbwIqufLyKjxgdKjoKL.GIHuiEkmFihgdjpqkqIhwXanlmm(mOrDiYzmAbwIqufLyKjxgdKjoKL.ControllerType.Aim, P_0.lnlNhzZfDvBdeKdlVfYEtzHVjqZ, P_0.wdJNnMRgnpHAWIQUEkdXEsJWDJsH, P_0.AhODPAPEiKQbFcMqyoClsiOEHsd);
						num = -1737786865;
						continue;
						IL_0070:
						mOrDiYzmAbwIqufLyKjxgdKjoKL2 = mOrDiYzmAbwIqufLyKjxgdKjoKL.GIHuiEkmFihgdjpqkqIhwXanlmm(mOrDiYzmAbwIqufLyKjxgdKjoKL.ControllerType.Gamepad, P_0.lnlNhzZfDvBdeKdlVfYEtzHVjqZ, P_0.wdJNnMRgnpHAWIQUEkdXEsJWDJsH, P_0.AhODPAPEiKQbFcMqyoClsiOEHsd);
						if (mOrDiYzmAbwIqufLyKjxgdKjoKL2 == null)
						{
							return;
						}
						goto default;
					}
					break;
				}
			}
		}

		private void xqxMYnGQaRqtFqUPaxwGtpwhQcs(mOrDiYzmAbwIqufLyKjxgdKjoKL P_0)
		{
			AddJoystick(P_0);
			P_0.Connect();
			while (true)
			{
				int num = -2041333065;
				while (true)
				{
					switch (num ^ -2041333066)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_002b;
					case 2:
						return;
					}
					break;
					IL_002b:
					OnJoystickConnected();
					num = -2041333068;
				}
			}
		}

		private void HHTLDeKmCmmufThZnyFXROYScef(tEmrawKbhbEVmgDlgbmzqwbnQAM.oqBxsEIgTVkbMnXvPzSVbioQQpV P_0)
		{
			IList<Joystick> joysticks = GetJoysticks();
			int count = joysticks.Count;
			int num2 = default(int);
			mOrDiYzmAbwIqufLyKjxgdKjoKL mOrDiYzmAbwIqufLyKjxgdKjoKL2 = default(mOrDiYzmAbwIqufLyKjxgdKjoKL);
			while (true)
			{
				int num = 1486858578;
				while (true)
				{
					switch (num ^ 0x589FA95B)
					{
					case 4:
						break;
					default:
						return;
					case 9:
						num2 = count - 1;
						num = 1486858585;
						continue;
					case 8:
						if (mOrDiYzmAbwIqufLyKjxgdKjoKL2.playerId == P_0.wdJNnMRgnpHAWIQUEkdXEsJWDJsH && mOrDiYzmAbwIqufLyKjxgdKjoKL2.handle == P_0.AhODPAPEiKQbFcMqyoClsiOEHsd)
						{
							mOrDiYzmAbwIqufLyKjxgdKjoKL2.Disconnect();
							num = 1486858586;
							continue;
						}
						goto case 7;
					case 7:
						num2--;
						num = 1486858589;
						continue;
					case 0:
						OnJoystickDisconnected();
						num = 1486858584;
						continue;
					case 2:
						num = 1486858589;
						continue;
					case 6:
					{
						int num4;
						if (num2 >= 0)
						{
							num = 1486858590;
							num4 = num;
						}
						else
						{
							num = 1486858587;
							num4 = num;
						}
						continue;
					}
					case 5:
					{
						mOrDiYzmAbwIqufLyKjxgdKjoKL2 = joysticks[num2] as mOrDiYzmAbwIqufLyKjxgdKjoKL;
						int num3;
						if (P_0.hLFqbKsLnhVDQrSCeKaRQrimbrF == mOrDiYzmAbwIqufLyKjxgdKjoKL2.baseControllerType)
						{
							num = 1486858579;
							num3 = num;
						}
						else
						{
							num = 1486858588;
							num3 = num;
						}
						continue;
					}
					case 1:
						RemoveJoystick(mOrDiYzmAbwIqufLyKjxgdKjoKL2);
						num = 1486858588;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private bool IOoaHfaoDyYjZAmdtgSJIhGWuVa(ControllerType P_0, Rewired.Controller P_1)
		{
			if (!kfRqJPikKfSDqvTUMmXmDGSqQuX)
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
			//ILSpy generated this explicit interface implementation from .override directive in IOoaHfaoDyYjZAmdtgSJIhGWuVa
			return this.IOoaHfaoDyYjZAmdtgSJIhGWuVa(P_0, P_1);
		}

		private void ABcLPtGqklrrIBSmQXqyHCTgWIN(ControllerType P_0, Rewired.Controller P_1)
		{
			if (!((IControllerAssigner)this).CanHandleAssignment(P_0, P_1))
			{
				return;
			}
			while (true)
			{
				Rewired.Joystick joystick = P_1 as Rewired.Joystick;
				if (ReInput.controllers.IsJoystickAssigned(joystick))
				{
					break;
				}
				while (true)
				{
					IL_0087:
					int num = tUUGlLGOPUFMhKBlHektGsngwDA(joystick.unityId);
					if (num >= ReInput.players.playerCount)
					{
						return;
					}
					while (true)
					{
						IL_0072:
						if (ReInput.players.GetPlayer(num) == null)
						{
							return;
						}
						while (true)
						{
							IL_00ab:
							int num2;
							int num3;
							if (!ReInput.configVars.assignJoysticksToPlayingPlayersOnly)
							{
								num2 = -1214983866;
								num3 = num2;
							}
							else
							{
								num2 = -1214983871;
								num3 = num2;
							}
							while (true)
							{
								switch (num2 ^ -1214983870)
								{
								case 5:
									num2 = -1214983872;
									continue;
								case 2:
									break;
								case 3:
									if (!ReInput.players.GetPlayer(num).isPlaying)
									{
										return;
									}
									goto default;
								case 6:
									goto IL_0072;
								case 1:
									goto IL_0087;
								case 0:
									goto IL_00ab;
								default:
									ReInput.players.GetPlayer(num).controllers.AddController(joystick, removeFromOtherPlayers: true);
									return;
								}
								break;
							}
							break;
						}
						break;
					}
					break;
				}
			}
		}

		void IControllerAssigner.AssignController(ControllerType P_0, Rewired.Controller P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ABcLPtGqklrrIBSmQXqyHCTgWIN
			this.ABcLPtGqklrrIBSmQXqyHCTgWIN(P_0, P_1);
		}

		~PS4InputSource()
		{
			Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (!xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				xRygqjRmTtURDPiwlgMmFcdNBrr = true;
			}
		}
	}
}
