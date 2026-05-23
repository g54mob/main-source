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
		private class zvesZeCaQvmkYtvPNcZyJeBmHKwE
		{
			public struct HNifjfBuGUdHbAzCWVPgtnsZsLm
			{
				public int scFBAQRnQdoAeLFwpCuSpDlJaTC;

				public int YxCclPfBxKigbbzkHHVaRVAeXLZD;

				public int rTnZbrPKYDIxXNkXGcEHEoLSAfGD;

				public bool EDtNwfAOjJMyZDIVChTvgLQxfAi;

				public HNifjfBuGUdHbAzCWVPgtnsZsLm(int playerId, int handle, int deviceClass, bool isSpecialController)
				{
					scFBAQRnQdoAeLFwpCuSpDlJaTC = playerId;
					YxCclPfBxKigbbzkHHVaRVAeXLZD = handle;
					rTnZbrPKYDIxXNkXGcEHEoLSAfGD = deviceClass;
					EDtNwfAOjJMyZDIVChTvgLQxfAi = isSpecialController;
				}
			}

			public struct bEHqublOVrHdIYBAXVlZOGoUVQt
			{
				public int scFBAQRnQdoAeLFwpCuSpDlJaTC;

				public int YxCclPfBxKigbbzkHHVaRVAeXLZD;

				public bool EDtNwfAOjJMyZDIVChTvgLQxfAi;

				public bEHqublOVrHdIYBAXVlZOGoUVQt(int playerId, int handle, bool isSpecialController)
				{
					scFBAQRnQdoAeLFwpCuSpDlJaTC = playerId;
					YxCclPfBxKigbbzkHHVaRVAeXLZD = handle;
					EDtNwfAOjJMyZDIVChTvgLQxfAi = isSpecialController;
				}
			}

			private class MtZQKSsxTZmMxsNMTwHOSWsIdQW
			{
				public readonly bool EDtNwfAOjJMyZDIVChTvgLQxfAi;

				public bool zuOjyqcFKUCzNlZjSJNYzCMoAHG;

				public int YxCclPfBxKigbbzkHHVaRVAeXLZD;

				public int rTnZbrPKYDIxXNkXGcEHEoLSAfGD;

				public MtZQKSsxTZmMxsNMTwHOSWsIdQW(bool isSpecialController)
				{
					EDtNwfAOjJMyZDIVChTvgLQxfAi = isSpecialController;
					nympziBLtYDUiPlWNRoEGqbSPfa();
				}

				public jVyWYRMsaAhxXaPKXBprZqmmDmM IkEBDednVVXhKzTAAiBanMvrVip(bool P_0, int P_1, int P_2)
				{
					jVyWYRMsaAhxXaPKXBprZqmmDmM jVyWYRMsaAhxXaPKXBprZqmmDmM2 = jVyWYRMsaAhxXaPKXBprZqmmDmM.TCGihQKDgeeGtvEXifcuojmabzj;
					if (zuOjyqcFKUCzNlZjSJNYzCMoAHG != P_0)
					{
						zuOjyqcFKUCzNlZjSJNYzCMoAHG = P_0;
						jVyWYRMsaAhxXaPKXBprZqmmDmM2 = (jVyWYRMsaAhxXaPKXBprZqmmDmM)((int)jVyWYRMsaAhxXaPKXBprZqmmDmM2 | (P_0 ? 1 : 2));
						if (P_0)
						{
							YxCclPfBxKigbbzkHHVaRVAeXLZD = P_1;
							goto IL_0026;
						}
						nympziBLtYDUiPlWNRoEGqbSPfa();
						return jVyWYRMsaAhxXaPKXBprZqmmDmM2;
					}
					int num;
					if (YxCclPfBxKigbbzkHHVaRVAeXLZD != P_1)
					{
						YxCclPfBxKigbbzkHHVaRVAeXLZD = P_1;
						jVyWYRMsaAhxXaPKXBprZqmmDmM2 |= jVyWYRMsaAhxXaPKXBprZqmmDmM.uvXCbsBnPfRSSonxhmUFPMkpny;
						num = -256962032;
						goto IL_002b;
					}
					goto IL_0074;
					IL_0074:
					if (rTnZbrPKYDIxXNkXGcEHEoLSAfGD != P_2)
					{
						rTnZbrPKYDIxXNkXGcEHEoLSAfGD = P_2;
						jVyWYRMsaAhxXaPKXBprZqmmDmM2 |= jVyWYRMsaAhxXaPKXBprZqmmDmM.uvXCbsBnPfRSSonxhmUFPMkpny;
						num = -256962030;
						goto IL_002b;
					}
					goto IL_008f;
					IL_008f:
					return jVyWYRMsaAhxXaPKXBprZqmmDmM2;
					IL_002b:
					switch (num ^ -256962031)
					{
					case 0:
						break;
					case 2:
						rTnZbrPKYDIxXNkXGcEHEoLSAfGD = P_2;
						return jVyWYRMsaAhxXaPKXBprZqmmDmM2;
					case 1:
						goto IL_0074;
					default:
						goto IL_008f;
					}
					goto IL_0026;
					IL_0026:
					num = -256962029;
					goto IL_002b;
				}

				private void nympziBLtYDUiPlWNRoEGqbSPfa()
				{
					zuOjyqcFKUCzNlZjSJNYzCMoAHG = false;
					YxCclPfBxKigbbzkHHVaRVAeXLZD = -1;
					rTnZbrPKYDIxXNkXGcEHEoLSAfGD = -1;
				}
			}

			[Flags]
			private enum jVyWYRMsaAhxXaPKXBprZqmmDmM
			{
				TCGihQKDgeeGtvEXifcuojmabzj = 0,
				AVgeqanjsLChqjEayGcDNCMqTxtI = 1,
				dUltDdkivNhBBHvDthniWYpgMnZ = 2,
				uvXCbsBnPfRSSonxhmUFPMkpny = 4
			}

			private readonly int befEovCmOfwVvbQLFeeQKXSCVbVe;

			private readonly bool ogxHnjWMGGZmewkIwGMJmyKxrVS;

			private readonly int[] MumHAbnVWMksDVtXZHuwGhYEedR;

			private readonly IExternalTools hpLdyFVMkPBycwhCIbjEeQSvAcHD;

			private readonly MtZQKSsxTZmMxsNMTwHOSWsIdQW[] UFjksljhPIwjzmgHhRsGNTjeNWB;

			private readonly MtZQKSsxTZmMxsNMTwHOSWsIdQW[] cdvvrsHpWgwZKFBEdhWDLHWfiCH;

			private readonly List<HNifjfBuGUdHbAzCWVPgtnsZsLm> eBBPOKJgLkqjhZFqxAXgECYzbQgT;

			private readonly List<bEHqublOVrHdIYBAXVlZOGoUVQt> ThETfTsmIwvtHJBYTcFEAjxksXzo;

			private Action<HNifjfBuGUdHbAzCWVPgtnsZsLm> ebBYuizGJXicSfLqAqgKYUJATVC;

			private Action<bEHqublOVrHdIYBAXVlZOGoUVQt> PVVDIOHFhgYDLgDWNEqaaxtebvcc;

			[CompilerGenerated]
			private static Func<MtZQKSsxTZmMxsNMTwHOSWsIdQW> WCoGcdreuUiwhEhixVWoEqPFLcw;

			[CompilerGenerated]
			private static Func<MtZQKSsxTZmMxsNMTwHOSWsIdQW> WQjsegRROvQsiLjxtjVaVOQwmgj;

			public event Action<HNifjfBuGUdHbAzCWVPgtnsZsLm> ControllerConnectedEvent
			{
				add
				{
					Action<HNifjfBuGUdHbAzCWVPgtnsZsLm> action = ebBYuizGJXicSfLqAqgKYUJATVC;
					Action<HNifjfBuGUdHbAzCWVPgtnsZsLm> action2 = default(Action<HNifjfBuGUdHbAzCWVPgtnsZsLm>);
					Action<HNifjfBuGUdHbAzCWVPgtnsZsLm> value2 = default(Action<HNifjfBuGUdHbAzCWVPgtnsZsLm>);
					while (true)
					{
						int num = -1810132516;
						while (true)
						{
							switch (num ^ -1810132515)
							{
							case 0:
								break;
							default:
								return;
							case 1:
								action2 = action;
								value2 = (Action<HNifjfBuGUdHbAzCWVPgtnsZsLm>)Delegate.Combine(action2, value);
								num = -1810132519;
								continue;
							case 2:
							{
								int num2;
								if ((object)action != action2)
								{
									num = -1810132516;
									num2 = num;
								}
								else
								{
									num = -1810132514;
									num2 = num;
								}
								continue;
							}
							case 4:
								action = Interlocked.CompareExchange(ref ebBYuizGJXicSfLqAqgKYUJATVC, value2, action2);
								num = -1810132513;
								continue;
							case 3:
								return;
							}
							break;
						}
					}
				}
				remove
				{
					Action<HNifjfBuGUdHbAzCWVPgtnsZsLm> action = ebBYuizGJXicSfLqAqgKYUJATVC;
					while (true)
					{
						int num = -1048579380;
						while (true)
						{
							switch (num ^ -1048579378)
							{
							case 0:
								break;
							default:
								return;
							case 2:
							{
								Action<HNifjfBuGUdHbAzCWVPgtnsZsLm> action2 = action;
								Action<HNifjfBuGUdHbAzCWVPgtnsZsLm> value2 = (Action<HNifjfBuGUdHbAzCWVPgtnsZsLm>)Delegate.Remove(action2, value);
								action = Interlocked.CompareExchange(ref ebBYuizGJXicSfLqAqgKYUJATVC, value2, action2);
								int num2;
								if ((object)action == action2)
								{
									num = -1048579377;
									num2 = num;
								}
								else
								{
									num = -1048579380;
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
			}

			public event Action<bEHqublOVrHdIYBAXVlZOGoUVQt> ControllerDisconnectedEvent
			{
				add
				{
					Action<bEHqublOVrHdIYBAXVlZOGoUVQt> action = PVVDIOHFhgYDLgDWNEqaaxtebvcc;
					Action<bEHqublOVrHdIYBAXVlZOGoUVQt> action2 = default(Action<bEHqublOVrHdIYBAXVlZOGoUVQt>);
					while (true)
					{
						int num = -1979051937;
						while (true)
						{
							switch (num ^ -1979051939)
							{
							case 0:
								break;
							case 2:
								action2 = action;
								num = -1979051938;
								continue;
							case 3:
							{
								Action<bEHqublOVrHdIYBAXVlZOGoUVQt> value2 = (Action<bEHqublOVrHdIYBAXVlZOGoUVQt>)Delegate.Combine(action2, value);
								action = Interlocked.CompareExchange(ref PVVDIOHFhgYDLgDWNEqaaxtebvcc, value2, action2);
								num = -1979051940;
								continue;
							}
							default:
								if ((object)action == action2)
								{
									return;
								}
								goto case 2;
							}
							break;
						}
					}
				}
				remove
				{
					Action<bEHqublOVrHdIYBAXVlZOGoUVQt> action = PVVDIOHFhgYDLgDWNEqaaxtebvcc;
					Action<bEHqublOVrHdIYBAXVlZOGoUVQt> action2 = default(Action<bEHqublOVrHdIYBAXVlZOGoUVQt>);
					Action<bEHqublOVrHdIYBAXVlZOGoUVQt> value2 = default(Action<bEHqublOVrHdIYBAXVlZOGoUVQt>);
					while (true)
					{
						int num = -701029958;
						while (true)
						{
							switch (num ^ -701029957)
							{
							case 3:
								break;
							case 1:
								action2 = action;
								num = -701029957;
								continue;
							case 0:
								value2 = (Action<bEHqublOVrHdIYBAXVlZOGoUVQt>)Delegate.Remove(action2, value);
								num = -701029959;
								continue;
							default:
								action = Interlocked.CompareExchange(ref PVVDIOHFhgYDLgDWNEqaaxtebvcc, value2, action2);
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

			public zvesZeCaQvmkYtvPNcZyJeBmHKwE(int maxPlayers, bool supportSpecialControllers)
			{
				befEovCmOfwVvbQLFeeQKXSCVbVe = maxPlayers;
				ogxHnjWMGGZmewkIwGMJmyKxrVS = supportSpecialControllers;
				MumHAbnVWMksDVtXZHuwGhYEedR = new int[maxPlayers];
				hpLdyFVMkPBycwhCIbjEeQSvAcHD = UnityTools.externalTools;
				UFjksljhPIwjzmgHhRsGNTjeNWB = new MtZQKSsxTZmMxsNMTwHOSWsIdQW[maxPlayers];
				ArrayTools.Populate(UFjksljhPIwjzmgHhRsGNTjeNWB, () => new MtZQKSsxTZmMxsNMTwHOSWsIdQW(false));
				if (supportSpecialControllers)
				{
					cdvvrsHpWgwZKFBEdhWDLHWfiCH = new MtZQKSsxTZmMxsNMTwHOSWsIdQW[maxPlayers];
					ArrayTools.Populate(cdvvrsHpWgwZKFBEdhWDLHWfiCH, () => new MtZQKSsxTZmMxsNMTwHOSWsIdQW(true));
				}
				eBBPOKJgLkqjhZFqxAXgECYzbQgT = new List<HNifjfBuGUdHbAzCWVPgtnsZsLm>(2);
				ThETfTsmIwvtHJBYTcFEAjxksXzo = new List<bEHqublOVrHdIYBAXVlZOGoUVQt>(2);
			}

			public void UZSQFwoMfSAzsmmSKmseCCiJWWD()
			{
				hpLdyFVMkPBycwhCIbjEeQSvAcHD.PS4Input_PadGetUsersHandles2(befEovCmOfwVvbQLFeeQKXSCVbVe, MumHAbnVWMksDVtXZHuwGhYEedR);
				bool flag = default(bool);
				for (int i = 0; i < befEovCmOfwVvbQLFeeQKXSCVbVe; i++)
				{
					try
					{
						MtZQKSsxTZmMxsNMTwHOSWsIdQW mtZQKSsxTZmMxsNMTwHOSWsIdQW = UFjksljhPIwjzmgHhRsGNTjeNWB[i];
						while (true)
						{
							IL_0028:
							int num = -725270294;
							while (true)
							{
								int num4;
								switch (num ^ -725270296)
								{
								case 0:
									break;
								case 1:
									if (ThETfTsmIwvtHJBYTcFEAjxksXzo.Count > 0)
									{
										num = -725270293;
										continue;
									}
									goto IL_011b;
								case 4:
									GxDBCKmFHBuejoXLQueHFFCdDIHb(i, mtZQKSsxTZmMxsNMTwHOSWsIdQW, MumHAbnVWMksDVtXZHuwGhYEedR[i], flag);
									num = -725270295;
									continue;
								case 2:
									flag = hpLdyFVMkPBycwhCIbjEeQSvAcHD.PS4Input_PadIsConnected(i);
									if (!mtZQKSsxTZmMxsNMTwHOSWsIdQW.zuOjyqcFKUCzNlZjSJNYzCMoAHG)
									{
										int num6;
										if (flag)
										{
											num = -725270292;
											num6 = num;
										}
										else
										{
											num = -725270295;
											num6 = num;
										}
										continue;
									}
									goto case 4;
								default:
									{
										int num2 = 0;
										while (true)
										{
											if (num2 < ThETfTsmIwvtHJBYTcFEAjxksXzo.Count)
											{
												try
												{
													PVVDIOHFhgYDLgDWNEqaaxtebvcc(ThETfTsmIwvtHJBYTcFEAjxksXzo[num2]);
												}
												catch (Exception ex)
												{
													Logger.LogError("An exception occurred in controller monitor Controller Disconnect Event callback.\n" + ex);
												}
												num2++;
												goto IL_00dd;
											}
											ThETfTsmIwvtHJBYTcFEAjxksXzo.Clear();
											int num3 = -725270296;
											goto IL_00e2;
											IL_00e2:
											switch (num3 ^ -725270296)
											{
											case 2:
												break;
											case 1:
												continue;
											default:
												goto end_IL_00fb;
											}
											goto IL_00dd;
											IL_00dd:
											num3 = -725270295;
											goto IL_00e2;
											continue;
											end_IL_00fb:
											break;
										}
										goto IL_011b;
									}
									IL_011b:
									if (eBBPOKJgLkqjhZFqxAXgECYzbQgT.Count <= 0)
									{
										goto end_IL_002d;
									}
									num4 = 0;
									while (true)
									{
										if (num4 < eBBPOKJgLkqjhZFqxAXgECYzbQgT.Count)
										{
											try
											{
												ebBYuizGJXicSfLqAqgKYUJATVC(eBBPOKJgLkqjhZFqxAXgECYzbQgT[num4]);
											}
											catch (Exception ex2)
											{
												Logger.LogError("An exception occurred in controller monitor Controller Connect Event callback.\n" + ex2);
											}
											num4++;
											goto IL_0163;
										}
										eBBPOKJgLkqjhZFqxAXgECYzbQgT.Clear();
										int num5 = -725270295;
										goto IL_0168;
										IL_0168:
										switch (num5 ^ -725270296)
										{
										case 0:
											break;
										default:
											goto end_IL_0181;
										case 2:
											continue;
										case 1:
											goto end_IL_0181;
										}
										goto IL_0163;
										IL_0163:
										num5 = -725270294;
										goto IL_0168;
										continue;
										end_IL_0181:
										break;
									}
									goto end_IL_002d;
								}
								goto IL_0028;
								continue;
								end_IL_002d:
								break;
							}
							break;
						}
					}
					catch (Exception ex3)
					{
						Logger.LogError("An exception occurred during controller monitor update.\n" + ex3);
					}
				}
			}

			private void GxDBCKmFHBuejoXLQueHFFCdDIHb(int P_0, MtZQKSsxTZmMxsNMTwHOSWsIdQW P_1, int P_2, bool P_3)
			{
				int num = hpLdyFVMkPBycwhCIbjEeQSvAcHD.PS4Input_GetDeviceClassForHandle(P_2);
				jVyWYRMsaAhxXaPKXBprZqmmDmM jVyWYRMsaAhxXaPKXBprZqmmDmM2 = default(jVyWYRMsaAhxXaPKXBprZqmmDmM);
				int yxCclPfBxKigbbzkHHVaRVAeXLZD = default(int);
				while (true)
				{
					int num2 = -1803666882;
					while (true)
					{
						switch (num2 ^ -1803666883)
						{
						case 2:
							break;
						default:
							return;
						case 0:
							eBBPOKJgLkqjhZFqxAXgECYzbQgT.Add(new HNifjfBuGUdHbAzCWVPgtnsZsLm(P_0, P_1.YxCclPfBxKigbbzkHHVaRVAeXLZD, P_1.rTnZbrPKYDIxXNkXGcEHEoLSAfGD, P_1.EDtNwfAOjJMyZDIVChTvgLQxfAi));
							num2 = -1803666886;
							continue;
						case 4:
							if ((jVyWYRMsaAhxXaPKXBprZqmmDmM2 & jVyWYRMsaAhxXaPKXBprZqmmDmM.dUltDdkivNhBBHvDthniWYpgMnZ) != jVyWYRMsaAhxXaPKXBprZqmmDmM.TCGihQKDgeeGtvEXifcuojmabzj)
							{
								goto case 1;
							}
							if (P_1.zuOjyqcFKUCzNlZjSJNYzCMoAHG)
							{
								int num3;
								if ((jVyWYRMsaAhxXaPKXBprZqmmDmM2 & jVyWYRMsaAhxXaPKXBprZqmmDmM.uvXCbsBnPfRSSonxhmUFPMkpny) == 0)
								{
									num2 = -1803666885;
									num3 = num2;
								}
								else
								{
									num2 = -1803666884;
									num3 = num2;
								}
								continue;
							}
							goto case 6;
						case 5:
							if (jVyWYRMsaAhxXaPKXBprZqmmDmM2 == jVyWYRMsaAhxXaPKXBprZqmmDmM.TCGihQKDgeeGtvEXifcuojmabzj)
							{
								return;
							}
							goto case 4;
						case 3:
							yxCclPfBxKigbbzkHHVaRVAeXLZD = P_1.YxCclPfBxKigbbzkHHVaRVAeXLZD;
							jVyWYRMsaAhxXaPKXBprZqmmDmM2 = P_1.IkEBDednVVXhKzTAAiBanMvrVip(P_3, P_2, num);
							num2 = -1803666888;
							continue;
						case 1:
							ThETfTsmIwvtHJBYTcFEAjxksXzo.Add(new bEHqublOVrHdIYBAXVlZOGoUVQt(P_0, yxCclPfBxKigbbzkHHVaRVAeXLZD, P_1.EDtNwfAOjJMyZDIVChTvgLQxfAi));
							num2 = -1803666885;
							continue;
						case 6:
							if ((jVyWYRMsaAhxXaPKXBprZqmmDmM2 & jVyWYRMsaAhxXaPKXBprZqmmDmM.AVgeqanjsLChqjEayGcDNCMqTxtI) == 0)
							{
								if (P_1.zuOjyqcFKUCzNlZjSJNYzCMoAHG)
								{
									int num4;
									if ((jVyWYRMsaAhxXaPKXBprZqmmDmM2 & jVyWYRMsaAhxXaPKXBprZqmmDmM.uvXCbsBnPfRSSonxhmUFPMkpny) != jVyWYRMsaAhxXaPKXBprZqmmDmM.TCGihQKDgeeGtvEXifcuojmabzj)
									{
										num2 = -1803666883;
										num4 = num2;
									}
									else
									{
										num2 = -1803666886;
										num4 = num2;
									}
									continue;
								}
								return;
							}
							goto case 0;
						case 7:
							return;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static MtZQKSsxTZmMxsNMTwHOSWsIdQW fFhZiHxhrdJIizmpUjsGDMQIWtFs()
			{
				return new MtZQKSsxTZmMxsNMTwHOSWsIdQW(false);
			}

			[CompilerGenerated]
			private static MtZQKSsxTZmMxsNMTwHOSWsIdQW rjUdsJYSdwEkbBQIhWfuVpROzKko()
			{
				return new MtZQKSsxTZmMxsNMTwHOSWsIdQW(true);
			}
		}

		private abstract class gmxKuWvehhjyGxbrPSVaHzquCvx : Joystick, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource
		{
			[CustomObfuscation(rename = false)]
			public enum ControllerType
			{
				[CustomObfuscation(rename = false)]
				Unknown = 0,
				[CustomObfuscation(rename = false)]
				Gamepad = 1,
				[CustomObfuscation(rename = false)]
				Move = 2,
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

			protected enum BjhebJnWLAAQxFGXvaQIgVwiFspI
			{
				UMtjEaOogDDwQiplOLpTuwxTdbQ = 0,
				XaFUPxxCceGTABxzGrOIRyeKOen = 1,
				zWnsnIIDCeFcLAnplFouhWdNXPS = 2
			}

			public class lKNlqJxafShcjyFxIuOgbYvpgoq
			{
				public readonly int TwhUkSEboxGPsJgqbpmupSCMcvva;

				public readonly int SgYwVaEgtCZiUkgVDcTwJWbyDTtb;

				public readonly float ZpNkmGdIMOGNFcdylebfiGiHPIp;

				public readonly int dFeMnzRTSNcMYNGuAWZUeFGTLNj;

				public readonly int FZbyKZphKDpuBpoBVcVmPaNVhUHh;

				public lKNlqJxafShcjyFxIuOgbYvpgoq(int axisCount, int buttonCount, float dpadDeadzone, int vibrationMotorCount, int maxTouches)
				{
					TwhUkSEboxGPsJgqbpmupSCMcvva = axisCount;
					SgYwVaEgtCZiUkgVDcTwJWbyDTtb = buttonCount;
					ZpNkmGdIMOGNFcdylebfiGiHPIp = dpadDeadzone;
					dFeMnzRTSNcMYNGuAWZUeFGTLNj = vibrationMotorCount;
					FZbyKZphKDpuBpoBVcVmPaNVhUHh = maxTouches;
				}
			}

			public const bool VXfXjqIsprinOJhOJjwDAjHJHfqF = false;

			private static int crqoDCfQnUQSFLrNkhSrkcSduMX;

			protected readonly int iueDnAHVXVmEMnNCzSowjkddzOFv;

			protected readonly int UzBZSIQMHRDrYTcHWhDjxwBwnMg;

			protected readonly bool IUKhVvfOOzbCHepuFOEFeZALmnd;

			protected readonly lKNlqJxafShcjyFxIuOgbYvpgoq QdhsebCRgJZofRWdmUYiXIOYTpk;

			protected readonly int NwgZCoPcMAFocejfaTMgksjuPEtb;

			protected readonly float[] qyibqHFecCGFAWtgKwpILOswFqvh;

			private readonly LoggedInUser ZACIbUAVuGKNZRSufwUSAhmyuxyJ;

			protected readonly ControllerType iaFziOmGetWMviBsUmpNhLnTJKt;

			private readonly Func<int, bool> UhCfIBCMHoKYrEGmCOOyERYbiRvD;

			private readonly Action<int, int, int> tWslsRuqkCpPFnsDkkPXVODfEepc;

			private readonly Action<int, int, int, int> kWEAKBDlhqLeYCUGxFjXDcxAPGaj;

			private readonly Action<int> qJYxbirBJazSSYBwkcYqCNheIJph;

			private Action<int, bool> VOdcSKJqeUJumyeLxVrECeNkjRo;

			private Action<int, bool> XjgJXDTlOnJFWJfNfLzQPCvLYtZ;

			private Action<int, bool> hKbTeyEWTTqpOUxRmbJAJSUDnfF;

			private Action<int> quhThkNWRAcpNwrbBsSIKdFAVFu;

			private Func<int, Vector3> SGUoQgFyPQRRrhUqytNyUXJCiRe;

			private Func<int, Vector3> AeFADGEEYeOCqfoTKZtGpHgUaDoD;

			private Func<int, Vector4> ahWchJbiPNsEmiLLQZBnGroIXqw;

			private static int NextSystemId
			{
				get
				{
					int result = crqoDCfQnUQSFLrNkhSrkcSduMX;
					crqoDCfQnUQSFLrNkhSrkcSduMX++;
					return result;
				}
			}

			protected LoggedInUser user
			{
				get
				{
					UnityTools.externalTools.PS4Input_GetUsersDetails(iueDnAHVXVmEMnNCzSowjkddzOFv, ZACIbUAVuGKNZRSufwUSAhmyuxyJ);
					return ZACIbUAVuGKNZRSufwUSAhmyuxyJ;
				}
			}

			public ControllerType type
			{
				get
				{
					return iaFziOmGetWMviBsUmpNhLnTJKt;
				}
			}

			public int playerId
			{
				get
				{
					return iueDnAHVXVmEMnNCzSowjkddzOFv;
				}
			}

			public int handle
			{
				get
				{
					return UzBZSIQMHRDrYTcHWhDjxwBwnMg;
				}
			}

			public bool isSpecialController
			{
				get
				{
					return IUKhVvfOOzbCHepuFOEFeZALmnd;
				}
			}

			private bool IsConnectedNow
			{
				get
				{
					return UhCfIBCMHoKYrEGmCOOyERYbiRvD(iueDnAHVXVmEMnNCzSowjkddzOFv);
				}
			}

			public int vibrationMotorCount
			{
				get
				{
					return QdhsebCRgJZofRWdmUYiXIOYTpk.dFeMnzRTSNcMYNGuAWZUeFGTLNj;
				}
			}

			public static gmxKuWvehhjyGxbrPSVaHzquCvx MdLShCgeucAqBomYFlMaHVWokJC(ControllerType P_0, int P_1, int P_2)
			{
				if (P_0 == ControllerType.Gamepad)
				{
					return new lIoaADrjBSGqvtbbtJGuTnBKAVSd("Gamepad " + (P_1 + 1), P_1, P_1 + 1, P_2);
				}
				return null;
			}

			public static gmxKuWvehhjyGxbrPSVaHzquCvx MdLShCgeucAqBomYFlMaHVWokJC(bool P_0, int P_1, int P_2, int P_3)
			{
				if (!P_0)
				{
					return MdLShCgeucAqBomYFlMaHVWokJC(ControllerType.Gamepad, P_2, P_3);
				}
				return null;
			}

			protected gmxKuWvehhjyGxbrPSVaHzquCvx(ControllerType type, string name, int playerId, int unityJoystickId, int handle, lKNlqJxafShcjyFxIuOgbYvpgoq capabilities)
				: base(name, NextSystemId, unityJoystickId, capabilities.TwhUkSEboxGPsJgqbpmupSCMcvva, capabilities.SgYwVaEgtCZiUkgVDcTwJWbyDTtb)
			{
				while (true)
				{
					int num = 156785686;
					while (true)
					{
						switch (num ^ 0x9585C1F)
						{
						case 7:
							break;
						case 9:
							if (capabilities == null)
							{
								throw new ArgumentNullException("capabilities");
							}
							goto case 1;
						case 6:
							ZACIbUAVuGKNZRSufwUSAhmyuxyJ = new LoggedInUser();
							num = 156785691;
							continue;
						case 0:
							base.supportsVibration = capabilities.dFeMnzRTSNcMYNGuAWZUeFGTLNj > 0;
							IUKhVvfOOzbCHepuFOEFeZALmnd = false;
							UhCfIBCMHoKYrEGmCOOyERYbiRvD = UnityTools.externalTools.PS4Input_PadIsConnected;
							tWslsRuqkCpPFnsDkkPXVODfEepc = UnityTools.externalTools.PS4Input_PadSetVibration;
							kWEAKBDlhqLeYCUGxFjXDcxAPGaj = UnityTools.externalTools.PS4Input_PadSetLightBar;
							qJYxbirBJazSSYBwkcYqCNheIJph = UnityTools.externalTools.PS4Input_PadResetLightBar;
							num = 156785693;
							continue;
						case 1:
							iaFziOmGetWMviBsUmpNhLnTJKt = type;
							num = 156785687;
							continue;
						case 8:
							iueDnAHVXVmEMnNCzSowjkddzOFv = playerId;
							num = 156785690;
							continue;
						case 4:
							_customName = name;
							qyibqHFecCGFAWtgKwpILOswFqvh = new float[capabilities.dFeMnzRTSNcMYNGuAWZUeFGTLNj];
							num = 156785695;
							continue;
						case 2:
							VOdcSKJqeUJumyeLxVrECeNkjRo = UnityTools.externalTools.PS4Input_PadSetMotionSensorState;
							XjgJXDTlOnJFWJfNfLzQPCvLYtZ = UnityTools.externalTools.PS4Input_PadSetTiltCorrectionState;
							hKbTeyEWTTqpOUxRmbJAJSUDnfF = UnityTools.externalTools.PS4Input_PadSetAngularVelocityDeadbandState;
							quhThkNWRAcpNwrbBsSIKdFAVFu = UnityTools.externalTools.PS4Input_PadResetOrientation;
							num = 156785692;
							continue;
						case 5:
							NwgZCoPcMAFocejfaTMgksjuPEtb = unityJoystickId - 1;
							QdhsebCRgJZofRWdmUYiXIOYTpk = capabilities;
							UzBZSIQMHRDrYTcHWhDjxwBwnMg = handle;
							num = 156785689;
							continue;
						default:
							SGUoQgFyPQRRrhUqytNyUXJCiRe = UnityTools.externalTools.PS4Input_GetLastAcceleration;
							AeFADGEEYeOCqfoTKZtGpHgUaDoD = UnityTools.externalTools.PS4Input_GetLastGyro;
							ahWchJbiPNsEmiLLQZBnGroIXqw = UnityTools.externalTools.PS4Input_GetLastOrientation;
							return;
						}
						break;
					}
				}
			}

			public override void Update()
			{
				UpdateElementValues();
			}

			public int GetUserId()
			{
				return user.userId;
			}

			public int GetUserStatus()
			{
				return user.status;
			}

			public bool GetUserIsPrimary()
			{
				return user.primaryUser;
			}

			public Color GetUserColor()
			{
				LoggedInUser loggedInUser = user;
				switch (loggedInUser.color)
				{
				case 0:
					return Color.blue;
				case 1:
					return Color.red;
				case 2:
					return Color.green;
				case 3:
					return Color.magenta;
				default:
					return Color.black;
				}
			}

			public int GetUserColorId()
			{
				return user.color;
			}

			public string GetUserName()
			{
				return user.userName;
			}

			public void StopVibration()
			{
				Array.Clear(qyibqHFecCGFAWtgKwpILOswFqvh, 0, qyibqHFecCGFAWtgKwpILOswFqvh.Length);
				OEMCPvgbhfiSKihdAdCuwZyGDXks();
			}

			public void SetVibration(int P_0, float P_1)
			{
				if ((uint)P_0 > (uint)QdhsebCRgJZofRWdmUYiXIOYTpk.dFeMnzRTSNcMYNGuAWZUeFGTLNj)
				{
					return;
				}
				while (true)
				{
					qyibqHFecCGFAWtgKwpILOswFqvh[P_0] = P_1;
					int num = -1458849454;
					while (true)
					{
						switch (num ^ -1458849456)
						{
						case 0:
							goto IL_000f;
						case 1:
							break;
						default:
							OEMCPvgbhfiSKihdAdCuwZyGDXks();
							return;
						}
						break;
						IL_000f:
						num = -1458849455;
					}
				}
			}

			public float GetVibration(int P_0)
			{
				if ((uint)P_0 > (uint)QdhsebCRgJZofRWdmUYiXIOYTpk.dFeMnzRTSNcMYNGuAWZUeFGTLNj)
				{
					return 0f;
				}
				return qyibqHFecCGFAWtgKwpILOswFqvh[P_0];
			}

			public void SetMotionSensorState(bool P_0)
			{
				VOdcSKJqeUJumyeLxVrECeNkjRo(iueDnAHVXVmEMnNCzSowjkddzOFv, P_0);
			}

			public void SetTiltCorrectionState(bool P_0)
			{
				XjgJXDTlOnJFWJfNfLzQPCvLYtZ(iueDnAHVXVmEMnNCzSowjkddzOFv, P_0);
			}

			public void SetAngularVelocityDeadbandState(bool P_0)
			{
				hKbTeyEWTTqpOUxRmbJAJSUDnfF(iueDnAHVXVmEMnNCzSowjkddzOFv, P_0);
			}

			public void ResetOrientation()
			{
				quhThkNWRAcpNwrbBsSIKdFAVFu(iueDnAHVXVmEMnNCzSowjkddzOFv);
			}

			public Vector3 GetLastAcceleration()
			{
				if (!IsConnectedNow)
				{
					goto IL_0008;
				}
				Vector3 result = SGUoQgFyPQRRrhUqytNyUXJCiRe(iueDnAHVXVmEMnNCzSowjkddzOFv);
				gfIksWBUPneTPwaSnJsaSgelRIB(ref result);
				int num = -19517495;
				goto IL_000d;
				IL_000d:
				switch (num ^ -19517496)
				{
				case 0:
					break;
				case 2:
					return Vector3.zero;
				default:
					return result;
				}
				goto IL_0008;
				IL_0008:
				num = -19517494;
				goto IL_000d;
			}

			public Vector3 GetLastAccelerationRaw()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				return SGUoQgFyPQRRrhUqytNyUXJCiRe(iueDnAHVXVmEMnNCzSowjkddzOFv);
			}

			public Vector3 GetLastGyro()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				Vector3 result = AeFADGEEYeOCqfoTKZtGpHgUaDoD(iueDnAHVXVmEMnNCzSowjkddzOFv);
				wtISYhCRCzycHFisAlOtNIIrXDR(ref result);
				return result;
			}

			public Vector3 GetLastGyroRaw()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				return AeFADGEEYeOCqfoTKZtGpHgUaDoD(iueDnAHVXVmEMnNCzSowjkddzOFv);
			}

			public Quaternion GetLastOrientation()
			{
				if (!IsConnectedNow)
				{
					goto IL_0008;
				}
				Vector4 vector = ahWchJbiPNsEmiLLQZBnGroIXqw(iueDnAHVXVmEMnNCzSowjkddzOFv);
				int num = -28667321;
				goto IL_000d;
				IL_000d:
				switch (num ^ -28667322)
				{
				case 0:
					break;
				case 2:
					return Quaternion.identity;
				default:
					return new Quaternion(vector.x * -1f, vector.y, vector.z, vector.w);
				}
				goto IL_0008;
				IL_0008:
				num = -28667324;
				goto IL_000d;
			}

			public Quaternion GetLastOrientationRaw()
			{
				if (!IsConnectedNow)
				{
					return Quaternion.identity;
				}
				Vector4 vector = ahWchJbiPNsEmiLLQZBnGroIXqw(iueDnAHVXVmEMnNCzSowjkddzOFv);
				return new Quaternion(vector.x, vector.y, vector.z, vector.w);
			}

			public void SetLightColor(int P_0, int P_1, int P_2)
			{
				kWEAKBDlhqLeYCUGxFjXDcxAPGaj(iueDnAHVXVmEMnNCzSowjkddzOFv, P_0, P_1, P_2);
			}

			public void ResetLight()
			{
				qJYxbirBJazSSYBwkcYqCNheIJph(iueDnAHVXVmEMnNCzSowjkddzOFv);
			}

			protected virtual void UpdateElementValues()
			{
				int joystickId = NwgZCoPcMAFocejfaTMgksjuPEtb + 1;
				IList<Button> buttons = base.Buttons;
				buttons[0].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 0);
				buttons[1].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 1);
				buttons[2].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 2);
				IList<Axis> axes = default(IList<Axis>);
				float joystickAxisValueByJoystickId2 = default(float);
				while (true)
				{
					int num = -1708373666;
					while (true)
					{
						switch (num ^ -1708373665)
						{
						case 2:
							break;
						case 1:
							buttons[3].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 3);
							buttons[4].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 4);
							num = -1708373668;
							continue;
						case 4:
							axes = base.Axes;
							num = -1708373670;
							continue;
						case 6:
							buttons[9].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 9);
							joystickAxisValueByJoystickId2 = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 5);
							num = -1708373665;
							continue;
						case 7:
							buttons[13].value = joystickAxisValueByJoystickId2 < 0f - QdhsebCRgJZofRWdmUYiXIOYTpk.ZpNkmGdIMOGNFcdylebfiGiHPIp;
							num = -1708373669;
							continue;
						case 5:
							axes[0].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 0);
							axes[1].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 1);
							num = -1708373673;
							continue;
						case 0:
						{
							float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 6);
							buttons[10].value = joystickAxisValueByJoystickId > QdhsebCRgJZofRWdmUYiXIOYTpk.ZpNkmGdIMOGNFcdylebfiGiHPIp;
							buttons[11].value = joystickAxisValueByJoystickId2 > QdhsebCRgJZofRWdmUYiXIOYTpk.ZpNkmGdIMOGNFcdylebfiGiHPIp;
							buttons[12].value = joystickAxisValueByJoystickId < 0f - QdhsebCRgJZofRWdmUYiXIOYTpk.ZpNkmGdIMOGNFcdylebfiGiHPIp;
							num = -1708373672;
							continue;
						}
						case 3:
							buttons[5].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 5);
							buttons[6].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 6);
							buttons[7].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 7);
							buttons[8].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 8);
							num = -1708373671;
							continue;
						default:
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

			protected void OEMCPvgbhfiSKihdAdCuwZyGDXks()
			{
				if (QdhsebCRgJZofRWdmUYiXIOYTpk.dFeMnzRTSNcMYNGuAWZUeFGTLNj == 0)
				{
					while (true)
					{
						switch (-122785357 ^ -122785358)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				tWslsRuqkCpPFnsDkkPXVODfEepc(iueDnAHVXVmEMnNCzSowjkddzOFv, CnCIYKORzEggIUzMNrthVKHjFMk(qyibqHFecCGFAWtgKwpILOswFqvh[0]), CnCIYKORzEggIUzMNrthVKHjFMk(qyibqHFecCGFAWtgKwpILOswFqvh[1]));
			}

			protected static int CnCIYKORzEggIUzMNrthVKHjFMk(float P_0)
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

			protected static void gfIksWBUPneTPwaSnJsaSgelRIB(ref Vector3 P_0)
			{
				P_0.x *= -1f;
				P_0.y *= -1f;
			}

			protected static void wtISYhCRCzycHFisAlOtNIIrXDR(ref Vector3 P_0)
			{
				P_0.x *= -1f;
				P_0.y *= -1f;
			}

			protected static bool tfoRucQJQkdkBEjIIaooIavtweH(int P_0, out ControllerType P_1)
			{
				string text = UnityTools.externalTools.PS4Input_GetDeviceClassString(P_0);
				if (string.IsNullOrEmpty(text))
				{
					goto IL_0017;
				}
				int num;
				if (text.Equals("Standard", StringComparison.OrdinalIgnoreCase))
				{
					P_1 = ControllerType.Gamepad;
					num = -113691521;
				}
				else
				{
					if (text.Equals("FlightStick", StringComparison.OrdinalIgnoreCase))
					{
						goto IL_0060;
					}
					if (!text.Equals("hotas", StringComparison.OrdinalIgnoreCase))
					{
						if (text.Equals("Stick", StringComparison.OrdinalIgnoreCase))
						{
							goto IL_008c;
						}
						if (text.Equals("hotas", StringComparison.OrdinalIgnoreCase))
						{
							num = -113691526;
						}
						else if (text.Equals("SteeringWheel", StringComparison.OrdinalIgnoreCase))
						{
							P_1 = ControllerType.SteeringWheel;
							num = -113691523;
						}
						else if (!text.Equals("Guitar", StringComparison.OrdinalIgnoreCase))
						{
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
							if (!text.Equals("Dancemat", StringComparison.OrdinalIgnoreCase))
							{
								if (text.Equals("Navigation", StringComparison.OrdinalIgnoreCase))
								{
									num = -113691525;
								}
								else
								{
									P_1 = ControllerType.Unknown;
									num = -113691528;
								}
							}
							else
							{
								num = -113691527;
							}
						}
						else
						{
							num = -113691532;
						}
					}
					else
					{
						num = -113691536;
					}
				}
				goto IL_001c;
				IL_008c:
				P_1 = ControllerType.FlightStick;
				num = -113691533;
				goto IL_001c;
				IL_0017:
				num = -113691522;
				goto IL_001c;
				IL_0060:
				P_1 = ControllerType.FlightStick;
				return true;
				IL_001c:
				while (true)
				{
					switch (num ^ -113691528)
					{
					case 4:
						break;
					case 8:
						goto IL_0060;
					case 2:
						goto IL_008c;
					case 12:
						P_1 = ControllerType.Guitar;
						num = -113691535;
						continue;
					case 1:
						P_1 = ControllerType.DanceMat;
						return true;
					case 10:
						return false;
					case 7:
						return true;
					case 6:
						P_1 = ControllerType.Unknown;
						num = -113691534;
						continue;
					case 9:
						return true;
					case 11:
						return true;
					case 3:
						P_1 = ControllerType.Navigation;
						return true;
					case 5:
						return true;
					default:
						return false;
					}
					break;
				}
				goto IL_0017;
			}
		}

		private sealed class lIoaADrjBSGqvtbbtJGuTnBKAVSd : gmxKuWvehhjyGxbrPSVaHzquCvx, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource, IPS4ControllerExtensionSourceTouchPad, IPS4GamepadExtensionSource
		{
			private const int gkdLJJjRJqOiqMcTEZgPsjDThEz = 6;

			private const int uoEjKyevFzzSGFeoHwcdjcYUdf = 14;

			private const float gSgjaxXkFAgFFQbZmHmUzAGYaMJk = 0.05f;

			private const int wAHbHPmuiHxSpCxNXicEmvniyOL = 2;

			private const int SYjzPDGQUNVdsEgwHzgDTNtdKmw = 2;

			private int QMnDnsCRjJEmZExktpVVgYKJahK;

			private int rPEWdfYFQpesAMJJMDNQFoUrQiWj;

			private Vector2 BxgwWqJorIUJiiBvYPshoStNtmU;

			private int kGkaLKQPuvEDEdUhoOsCxbiCcmVi;

			private Vector2 PLiipqNOoBdeFFqoufzfpfeDgirW;

			private BjhebJnWLAAQxFGXvaQIgVwiFspI QVgNxriCustqvbDrikBBBmNiYhB;

			private int cGlhdzfzHYDZUSyaMnzWDmahQyy;

			private int uUbJbdaGEcffjIHHXZNorTMkGJns;

			private int ojdcBcGveyOHAUbuZtlmTNEbXHev;

			private int VcoscxOiIadXIRHsHvrvUswmigE;

			private float NnQrwQTThDbSrTHmHNlrWxWIQdt;

			public int maxTouches
			{
				get
				{
					return QdhsebCRgJZofRWdmUYiXIOYTpk.FZbyKZphKDpuBpoBVcVmPaNVhUHh;
				}
			}

			public lIoaADrjBSGqvtbbtJGuTnBKAVSd(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Gamepad, name, playerId, unityJoystickId, handle, new lKNlqJxafShcjyFxIuOgbYvpgoq(6, 14, 0.05f, 2, 2))
			{
				vrtROXlgaeUcHBHqSIqBsWVBhQv();
				base.extension = new PS4GamepadExtension(this);
			}

			public int GetConnectionType()
			{
				return (int)QVgNxriCustqvbDrikBBBmNiYhB;
			}

			public int GetAnalogDeadZoneLeft()
			{
				return ojdcBcGveyOHAUbuZtlmTNEbXHev;
			}

			public int GetAnalogDeadZoneRight()
			{
				return VcoscxOiIadXIRHsHvrvUswmigE;
			}

			public float GetTouchPixelDensity()
			{
				return NnQrwQTThDbSrTHmHNlrWxWIQdt;
			}

			public int GetTouchpadResolutionX()
			{
				return cGlhdzfzHYDZUSyaMnzWDmahQyy;
			}

			public int GetTouchpadResolutionY()
			{
				return uUbJbdaGEcffjIHHXZNorTMkGJns;
			}

			public int GetTouchCount()
			{
				return QMnDnsCRjJEmZExktpVVgYKJahK;
			}

			public int GetTouchId(int P_0)
			{
				if (P_0 >= 0)
				{
					if (P_0 < QdhsebCRgJZofRWdmUYiXIOYTpk.FZbyKZphKDpuBpoBVcVmPaNVhUHh)
					{
						switch (P_0)
						{
						case 0:
							break;
						case 1:
							return kGkaLKQPuvEDEdUhoOsCxbiCcmVi;
						default:
							return -1;
						}
						goto IL_004b;
					}
					while (true)
					{
						switch (-1819960443 ^ -1819960441)
						{
						case 0:
							break;
						case 2:
							goto end_IL_0012;
						default:
							goto IL_004b;
						}
						continue;
						end_IL_0012:
						break;
					}
				}
				return -1;
				IL_004b:
				return rPEWdfYFQpesAMJJMDNQFoUrQiWj;
			}

			public bool GetTouchPositionAbsByIndex(int P_0, out Vector2 P_1)
			{
				int num = default(int);
				int num2;
				if (P_0 >= 0 && P_0 < QdhsebCRgJZofRWdmUYiXIOYTpk.FZbyKZphKDpuBpoBVcVmPaNVhUHh)
				{
					if (!IsTouchingByIndex(P_0))
					{
						goto IL_001b;
					}
					num = P_0;
					num2 = 37947446;
					goto IL_0020;
				}
				goto IL_006f;
				IL_001b:
				num2 = 37947441;
				goto IL_0020;
				IL_0020:
				while (true)
				{
					switch (num2 ^ 0x2430832)
					{
					case 0:
						break;
					case 1:
						P_1 = BxgwWqJorIUJiiBvYPshoStNtmU;
						goto IL_009f;
					case 4:
						switch (num)
						{
						case 0:
							break;
						default:
							goto IL_0068;
						case 1:
							goto IL_0081;
						}
						goto case 1;
					case 3:
						goto IL_006f;
					case 5:
						goto IL_0081;
					default:
						{
							P_1 = default(Vector2);
							return false;
						}
						IL_0081:
						P_1 = PLiipqNOoBdeFFqoufzfpfeDgirW;
						goto IL_009f;
						IL_0068:
						num2 = 37947440;
						continue;
						IL_009f:
						return true;
					}
					break;
				}
				goto IL_001b;
				IL_006f:
				P_1 = default(Vector2);
				return false;
			}

			public bool GetTouchPositionAbsByTouchId(int P_0, out Vector2 P_1)
			{
				int num = ABSuBgFBKYWAyRgQXCDIKzRosoP(P_0);
				if (num < 0)
				{
					P_1 = default(Vector2);
					return false;
				}
				return GetTouchPositionAbsByIndex(num, out P_1);
			}

			public bool GetTouchPositionByIndex(int P_0, out Vector2 P_1)
			{
				if (P_0 >= 0)
				{
					while (true)
					{
						int num = 1280398965;
						while (true)
						{
							switch (num ^ 0x4C515674)
							{
							case 3:
								break;
							case 1:
								if (P_0 >= QdhsebCRgJZofRWdmUYiXIOYTpk.FZbyKZphKDpuBpoBVcVmPaNVhUHh)
								{
									goto end_IL_0004;
								}
								if (!IsTouchingByIndex(P_0))
								{
									num = 1280398964;
									continue;
								}
								switch (P_0)
								{
								case 1:
									break;
								default:
									goto IL_0092;
								case 0:
									goto IL_009c;
								}
								goto case 2;
							case 2:
								P_1 = new Vector2(PLiipqNOoBdeFFqoufzfpfeDgirW.x, PLiipqNOoBdeFFqoufzfpfeDgirW.y);
								goto IL_00d2;
							case 0:
								goto end_IL_0004;
							case 4:
								goto IL_009c;
							default:
								{
									P_1 = default(Vector2);
									return false;
								}
								IL_0092:
								num = 1280398961;
								continue;
								IL_00d2:
								P_1.x /= cGlhdzfzHYDZUSyaMnzWDmahQyy;
								P_1.y /= uUbJbdaGEcffjIHHXZNorTMkGJns;
								return true;
								IL_009c:
								P_1 = new Vector2(BxgwWqJorIUJiiBvYPshoStNtmU.x, BxgwWqJorIUJiiBvYPshoStNtmU.y);
								goto IL_00d2;
							}
							break;
						}
						continue;
						end_IL_0004:
						break;
					}
				}
				P_1 = default(Vector2);
				return false;
			}

			public bool GetTouchPositionByTouchId(int P_0, out Vector2 P_1)
			{
				int num = ABSuBgFBKYWAyRgQXCDIKzRosoP(P_0);
				if (num < 0)
				{
					P_1 = default(Vector2);
					return false;
				}
				return GetTouchPositionByIndex(num, out P_1);
			}

			public bool IsTouchingByIndex(int P_0)
			{
				if (P_0 < 0 || P_0 >= QdhsebCRgJZofRWdmUYiXIOYTpk.FZbyKZphKDpuBpoBVcVmPaNVhUHh)
				{
					return false;
				}
				return P_0 < QMnDnsCRjJEmZExktpVVgYKJahK;
			}

			public bool IsTouchingByTouchId(int P_0)
			{
				if (P_0 < 0)
				{
					return false;
				}
				int num = ABSuBgFBKYWAyRgQXCDIKzRosoP(P_0);
				return num >= 0;
			}

			protected override void UpdateElementValues()
			{
				base.UpdateElementValues();
				int touch0x;
				int touch0y;
				int touch1x;
				int touch1y;
				UnityTools.externalTools.PS4Input_GetLastTouchData(iueDnAHVXVmEMnNCzSowjkddzOFv, out QMnDnsCRjJEmZExktpVVgYKJahK, out touch0x, out touch0y, out rPEWdfYFQpesAMJJMDNQFoUrQiWj, out touch1x, out touch1y, out kGkaLKQPuvEDEdUhoOsCxbiCcmVi);
				BxgwWqJorIUJiiBvYPshoStNtmU.x = touch0x;
				BxgwWqJorIUJiiBvYPshoStNtmU.y = uUbJbdaGEcffjIHHXZNorTMkGJns - touch0y;
				PLiipqNOoBdeFFqoufzfpfeDgirW.x = touch1x;
				PLiipqNOoBdeFFqoufzfpfeDgirW.y = uUbJbdaGEcffjIHHXZNorTMkGJns - touch1y;
			}

			private void vrtROXlgaeUcHBHqSIqBsWVBhQv()
			{
				IExternalTools externalTools = UnityTools.externalTools;
				int connectionType;
				externalTools.PS4Input_GetPadControllerInformation(iueDnAHVXVmEMnNCzSowjkddzOFv, out NnQrwQTThDbSrTHmHNlrWxWIQdt, out cGlhdzfzHYDZUSyaMnzWDmahQyy, out uUbJbdaGEcffjIHHXZNorTMkGJns, out ojdcBcGveyOHAUbuZtlmTNEbXHev, out VcoscxOiIadXIRHsHvrvUswmigE, out connectionType);
				QVgNxriCustqvbDrikBBBmNiYhB = (BjhebJnWLAAQxFGXvaQIgVwiFspI)connectionType;
				externalTools.PS4Input_PadResetOrientation(iueDnAHVXVmEMnNCzSowjkddzOFv);
			}

			private int ABSuBgFBKYWAyRgQXCDIKzRosoP(int P_0)
			{
				if (P_0 < 0)
				{
					return -1;
				}
				if (QMnDnsCRjJEmZExktpVVgYKJahK > 0 && rPEWdfYFQpesAMJJMDNQFoUrQiWj == P_0)
				{
					return 0;
				}
				if (QMnDnsCRjJEmZExktpVVgYKJahK > 1)
				{
					while (true)
					{
						int num = 259117204;
						while (true)
						{
							switch (num ^ 0xF71D095)
							{
							case 2:
								break;
							case 1:
								goto IL_0041;
							default:
								return 1;
							}
							break;
							IL_0041:
							if (kGkaLKQPuvEDEdUhoOsCxbiCcmVi != P_0)
							{
								goto end_IL_0023;
							}
							num = 259117205;
						}
						continue;
						end_IL_0023:
						break;
					}
				}
				return -1;
			}
		}

		private zvesZeCaQvmkYtvPNcZyJeBmHKwE CbxlGMZjJrdGjfGtzzlHbyjPDNh;

		private bool sbRtkHgZnrrRKmrchailqtebcOh = true;

		private bool vsurYtRlepcrpAzAENwjqjJEZPT;

		public override bool isReady
		{
			get
			{
				return true;
			}
		}

		bool IControllerAssigner.enabled
		{
			get
			{
				return sbRtkHgZnrrRKmrchailqtebcOh;
			}
			set
			{
				sbRtkHgZnrrRKmrchailqtebcOh = flag;
			}
		}

		public PS4InputSource()
			: base(22)
		{
			ReInput.controllerAssigner = this;
			CbxlGMZjJrdGjfGtzzlHbyjPDNh = new zvesZeCaQvmkYtvPNcZyJeBmHKwE(4, false);
			CbxlGMZjJrdGjfGtzzlHbyjPDNh.ControllerConnectedEvent += CZWDtBDGjmAVgvhkbqohckLIkBLy;
			CbxlGMZjJrdGjfGtzzlHbyjPDNh.ControllerDisconnectedEvent += NyRmbmAXviMtNQzvWNLUuTuBmpV;
		}

		public override void Update()
		{
			CbxlGMZjJrdGjfGtzzlHbyjPDNh.UZSQFwoMfSAzsmmSKmseCCiJWWD();
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
						Logger.LogError("An exception occurred during source joystick update.\n" + ex);
					}
					num++;
					goto IL_0042;
				}
				int num2 = 1987688804;
				goto IL_0047;
				IL_0047:
				switch (num2 ^ 0x7679B964)
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
				goto IL_0042;
				IL_0042:
				num2 = 1987688805;
				goto IL_0047;
			}
		}

		private static int pLQqcTWZsEhjTLsPieFqpmPhbNmc(int P_0)
		{
			if (P_0 >= 13)
			{
				return P_0 - 13;
			}
			return P_0 - 1;
		}

		private void CZWDtBDGjmAVgvhkbqohckLIkBLy(zvesZeCaQvmkYtvPNcZyJeBmHKwE.HNifjfBuGUdHbAzCWVPgtnsZsLm P_0)
		{
			gmxKuWvehhjyGxbrPSVaHzquCvx gmxKuWvehhjyGxbrPSVaHzquCvx2 = gmxKuWvehhjyGxbrPSVaHzquCvx.MdLShCgeucAqBomYFlMaHVWokJC(gmxKuWvehhjyGxbrPSVaHzquCvx.ControllerType.Gamepad, P_0.scFBAQRnQdoAeLFwpCuSpDlJaTC, P_0.YxCclPfBxKigbbzkHHVaRVAeXLZD);
			if (gmxKuWvehhjyGxbrPSVaHzquCvx2 != null)
			{
				nStyutKLhVUOhnUsJaSFWeHufACh(gmxKuWvehhjyGxbrPSVaHzquCvx2);
			}
		}

		private void nStyutKLhVUOhnUsJaSFWeHufACh(gmxKuWvehhjyGxbrPSVaHzquCvx P_0)
		{
			AddJoystick(P_0);
			P_0.Connect();
			OnJoystickConnected();
		}

		private void NyRmbmAXviMtNQzvWNLUuTuBmpV(zvesZeCaQvmkYtvPNcZyJeBmHKwE.bEHqublOVrHdIYBAXVlZOGoUVQt P_0)
		{
			IList<Joystick> joysticks = GetJoysticks();
			int count = joysticks.Count;
			int num = count - 1;
			gmxKuWvehhjyGxbrPSVaHzquCvx gmxKuWvehhjyGxbrPSVaHzquCvx2 = default(gmxKuWvehhjyGxbrPSVaHzquCvx);
			while (true)
			{
				int num2;
				if (num < 0)
				{
					OnJoystickDisconnected();
					num2 = -1247354203;
					goto IL_0019;
				}
				goto IL_005d;
				IL_00a7:
				num--;
				num2 = -1247354202;
				goto IL_0019;
				IL_005d:
				gmxKuWvehhjyGxbrPSVaHzquCvx2 = joysticks[num] as gmxKuWvehhjyGxbrPSVaHzquCvx;
				if (P_0.EDtNwfAOjJMyZDIVChTvgLQxfAi == gmxKuWvehhjyGxbrPSVaHzquCvx2.isSpecialController && gmxKuWvehhjyGxbrPSVaHzquCvx2.playerId == P_0.scFBAQRnQdoAeLFwpCuSpDlJaTC && gmxKuWvehhjyGxbrPSVaHzquCvx2.handle == P_0.YxCclPfBxKigbbzkHHVaRVAeXLZD)
				{
					gmxKuWvehhjyGxbrPSVaHzquCvx2.Disconnect();
					num2 = -1247354205;
					goto IL_0019;
				}
				goto IL_00a7;
				IL_0019:
				while (true)
				{
					switch (num2 ^ -1247354201)
					{
					case 0:
						num2 = -1247354204;
						continue;
					default:
						return;
					case 1:
						break;
					case 4:
						RemoveJoystick(gmxKuWvehhjyGxbrPSVaHzquCvx2);
						num2 = -1247354206;
						continue;
					case 3:
						goto IL_005d;
					case 5:
						goto IL_00a7;
					case 2:
						return;
					}
					break;
				}
			}
		}

		bool IControllerAssigner.CanHandleAssignment(ControllerType P_0, Rewired.Controller P_1)
		{
			if (!sbRtkHgZnrrRKmrchailqtebcOh)
			{
				return false;
			}
			if (P_0 != ControllerType.Joystick)
			{
				return false;
			}
			return ReInput.configVars.ps4_assignJoysticksByPS4JoyId;
		}

		void IControllerAssigner.AssignController(ControllerType P_0, Rewired.Controller P_1)
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
					int num = pLQqcTWZsEhjTLsPieFqpmPhbNmc(joystick.unityId);
					int num2;
					int num3;
					if (num >= ReInput.players.playerCount)
					{
						num2 = -2147234592;
						num3 = num2;
					}
					else
					{
						num2 = -2147234591;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -2147234591)
						{
						case 6:
							num2 = -2147234589;
							continue;
						case 5:
							if (ReInput.configVars.assignJoysticksToPlayingPlayersOnly)
							{
								goto IL_0056;
							}
							goto default;
						case 7:
							break;
						case 2:
							goto end_IL_0079;
						case 0:
							goto IL_00c5;
						case 1:
							return;
						case 8:
							return;
						case 3:
							return;
						default:
							ReInput.players.GetPlayer(num).controllers.AddController(joystick, true);
							return;
						}
						break;
						IL_00c5:
						int num4;
						if (ReInput.players.GetPlayer(num) == null)
						{
							num2 = -2147234583;
							num4 = num2;
						}
						else
						{
							num2 = -2147234588;
							num4 = num2;
						}
						continue;
						IL_0056:
						int num5;
						if (!ReInput.players.GetPlayer(num).isPlaying)
						{
							num2 = -2147234590;
							num5 = num2;
						}
						else
						{
							num2 = -2147234587;
							num5 = num2;
						}
					}
					continue;
					end_IL_0079:
					break;
				}
			}
		}

		~PS4InputSource()
		{
			Dispose(false);
		}

		protected override void Dispose(bool disposing)
		{
			if (vsurYtRlepcrpAzAENwjqjJEZPT)
			{
				return;
			}
			while (true)
			{
				vsurYtRlepcrpAzAENwjqjJEZPT = true;
				int num = -754131601;
				while (true)
				{
					switch (num ^ -754131602)
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
					num = -754131604;
				}
			}
		}
	}
}
