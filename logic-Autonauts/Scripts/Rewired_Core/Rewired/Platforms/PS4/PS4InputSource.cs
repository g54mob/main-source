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
		private class IIqKWhcwYfTkjFaCdbDyqeTmfDbE
		{
			public struct CxpfePEvjrPvXzDxRKhzJuSoUUl
			{
				public int DERQvNdAIfJFDnFpDBYSBQlXxSHC;

				public int pjAxoGjQdUQZKLDflwZaqfSLVAC;

				public int UpbvuofvMXACqnIAqdAZtGTUAmZF;

				public bool vgzDviaSvJLFelnUoFPhPTYvfRj;

				public CxpfePEvjrPvXzDxRKhzJuSoUUl(int playerId, int handle, int deviceClass, bool isSpecialController)
				{
					DERQvNdAIfJFDnFpDBYSBQlXxSHC = playerId;
					pjAxoGjQdUQZKLDflwZaqfSLVAC = handle;
					UpbvuofvMXACqnIAqdAZtGTUAmZF = deviceClass;
					vgzDviaSvJLFelnUoFPhPTYvfRj = isSpecialController;
				}
			}

			public struct rMXeVyQRoAZEBwVRuFdxJcMiwcS
			{
				public int DERQvNdAIfJFDnFpDBYSBQlXxSHC;

				public int pjAxoGjQdUQZKLDflwZaqfSLVAC;

				public bool vgzDviaSvJLFelnUoFPhPTYvfRj;

				public rMXeVyQRoAZEBwVRuFdxJcMiwcS(int playerId, int handle, bool isSpecialController)
				{
					DERQvNdAIfJFDnFpDBYSBQlXxSHC = playerId;
					pjAxoGjQdUQZKLDflwZaqfSLVAC = handle;
					vgzDviaSvJLFelnUoFPhPTYvfRj = isSpecialController;
				}
			}

			private class jxXIuBMHDKzgzIncVDKBvGhCyUc
			{
				public readonly bool vgzDviaSvJLFelnUoFPhPTYvfRj;

				public bool MICQfhOSEKeMgZWmkgJAMVWaOIJ;

				public int pjAxoGjQdUQZKLDflwZaqfSLVAC;

				public int UpbvuofvMXACqnIAqdAZtGTUAmZF;

				public jxXIuBMHDKzgzIncVDKBvGhCyUc(bool isSpecialController)
				{
					vgzDviaSvJLFelnUoFPhPTYvfRj = isSpecialController;
					QYwkAfdRMMgAPnyPzHFUdcsKUPp();
				}

				public adjZXRKwqhKipdlJKvGxPdVPOrZ bXGKkfLvHHQrlFiPyVIyMYzrtnu(bool P_0, int P_1, int P_2)
				{
					adjZXRKwqhKipdlJKvGxPdVPOrZ adjZXRKwqhKipdlJKvGxPdVPOrZ2 = adjZXRKwqhKipdlJKvGxPdVPOrZ.iOlZgcuFwLCPNAjSgaSDuxucio;
					while (true)
					{
						int num = -1957053369;
						while (true)
						{
							switch (num ^ -1957053372)
							{
							case 4:
								break;
							case 0:
							{
								int num2;
								if (UpbvuofvMXACqnIAqdAZtGTUAmZF == P_2)
								{
									num = -1957053375;
									num2 = num;
								}
								else
								{
									num = -1957053370;
									num2 = num;
								}
								continue;
							}
							case 2:
								UpbvuofvMXACqnIAqdAZtGTUAmZF = P_2;
								adjZXRKwqhKipdlJKvGxPdVPOrZ2 |= adjZXRKwqhKipdlJKvGxPdVPOrZ.JDbGekIAZLOyvctfFteMapZcaUv;
								num = -1957053375;
								continue;
							case 1:
								return adjZXRKwqhKipdlJKvGxPdVPOrZ2;
							case 3:
								if (MICQfhOSEKeMgZWmkgJAMVWaOIJ == P_0)
								{
									if (pjAxoGjQdUQZKLDflwZaqfSLVAC != P_1)
									{
										pjAxoGjQdUQZKLDflwZaqfSLVAC = P_1;
										adjZXRKwqhKipdlJKvGxPdVPOrZ2 |= adjZXRKwqhKipdlJKvGxPdVPOrZ.JDbGekIAZLOyvctfFteMapZcaUv;
										num = -1957053372;
										continue;
									}
									goto case 0;
								}
								num = -1957053374;
								continue;
							case 6:
								MICQfhOSEKeMgZWmkgJAMVWaOIJ = P_0;
								adjZXRKwqhKipdlJKvGxPdVPOrZ2 = (adjZXRKwqhKipdlJKvGxPdVPOrZ)((int)adjZXRKwqhKipdlJKvGxPdVPOrZ2 | (P_0 ? 1 : 2));
								if (!P_0)
								{
									QYwkAfdRMMgAPnyPzHFUdcsKUPp();
									return adjZXRKwqhKipdlJKvGxPdVPOrZ2;
								}
								pjAxoGjQdUQZKLDflwZaqfSLVAC = P_1;
								UpbvuofvMXACqnIAqdAZtGTUAmZF = P_2;
								num = -1957053371;
								continue;
							default:
								return adjZXRKwqhKipdlJKvGxPdVPOrZ2;
							}
							break;
						}
					}
				}

				private void QYwkAfdRMMgAPnyPzHFUdcsKUPp()
				{
					MICQfhOSEKeMgZWmkgJAMVWaOIJ = false;
					pjAxoGjQdUQZKLDflwZaqfSLVAC = -1;
					UpbvuofvMXACqnIAqdAZtGTUAmZF = -1;
				}
			}

			[Flags]
			private enum adjZXRKwqhKipdlJKvGxPdVPOrZ
			{
				iOlZgcuFwLCPNAjSgaSDuxucio = 0,
				jikNtdRieZgCLIcbSBeRBnEBmcwg = 1,
				OlrsfcQzhPGAwvfQNjJivvrkJaM = 2,
				JDbGekIAZLOyvctfFteMapZcaUv = 4
			}

			private readonly int IFzonqkgUvtsQDZYdtkKkiUWzkU;

			private readonly bool JgzMgwyoSMxRLONFIKIRDAGjgYZ;

			private readonly int[] fHoYXaBGGUKVerUUbaHchxOWczO;

			private readonly int[] FpzfMMbvkdVoCQHvBfZAPENAVFj;

			private readonly IExternalTools CSVtdAbVaTDDPSZLuxRKdHWbfrO;

			private readonly jxXIuBMHDKzgzIncVDKBvGhCyUc[] lnincIBnfCPSsSUIJHQjshOuEOK;

			private readonly jxXIuBMHDKzgzIncVDKBvGhCyUc[] JmfAqvJtAeVwjlpZNLfXDiSzDNGI;

			private readonly List<CxpfePEvjrPvXzDxRKhzJuSoUUl> RjVfRHjcXyROCnqtZKVcbRGfQBz;

			private readonly List<rMXeVyQRoAZEBwVRuFdxJcMiwcS> yeGDeEDIKmSSaKdNpUJGMrnuxYa;

			private Action<CxpfePEvjrPvXzDxRKhzJuSoUUl> FEPTxvRGZPVgvJmrgyAMzINKESZ;

			private Action<rMXeVyQRoAZEBwVRuFdxJcMiwcS> gjXNLThJtmyygYNNjrokZppaCuh;

			[CompilerGenerated]
			private static Func<jxXIuBMHDKzgzIncVDKBvGhCyUc> viDktHuvUPMnokGPFFcrsxLUFz;

			[CompilerGenerated]
			private static Func<jxXIuBMHDKzgzIncVDKBvGhCyUc> rTpihzrNInTFNnyiZpZwuIIumpi;

			public event Action<CxpfePEvjrPvXzDxRKhzJuSoUUl> ControllerConnectedEvent
			{
				add
				{
					Action<CxpfePEvjrPvXzDxRKhzJuSoUUl> action = FEPTxvRGZPVgvJmrgyAMzINKESZ;
					Action<CxpfePEvjrPvXzDxRKhzJuSoUUl> action2 = default(Action<CxpfePEvjrPvXzDxRKhzJuSoUUl>);
					while (true)
					{
						int num = -275324404;
						while (true)
						{
							switch (num ^ -275324403)
							{
							case 2:
								break;
							case 1:
								goto IL_0025;
							default:
								if ((object)action != action2)
								{
									goto IL_0025;
								}
								return;
							}
							break;
							IL_0025:
							action2 = action;
							Action<CxpfePEvjrPvXzDxRKhzJuSoUUl> value2 = (Action<CxpfePEvjrPvXzDxRKhzJuSoUUl>)Delegate.Combine(action2, value);
							action = Interlocked.CompareExchange(ref FEPTxvRGZPVgvJmrgyAMzINKESZ, value2, action2);
							num = -275324403;
						}
					}
				}
				remove
				{
					Action<CxpfePEvjrPvXzDxRKhzJuSoUUl> action = FEPTxvRGZPVgvJmrgyAMzINKESZ;
					Action<CxpfePEvjrPvXzDxRKhzJuSoUUl> action2 = default(Action<CxpfePEvjrPvXzDxRKhzJuSoUUl>);
					while (true)
					{
						int num = -212792195;
						while (true)
						{
							switch (num ^ -212792196)
							{
							case 0:
								break;
							case 1:
								goto IL_0025;
							default:
								if ((object)action != action2)
								{
									goto IL_0025;
								}
								return;
							}
							break;
							IL_0025:
							action2 = action;
							Action<CxpfePEvjrPvXzDxRKhzJuSoUUl> value2 = (Action<CxpfePEvjrPvXzDxRKhzJuSoUUl>)Delegate.Remove(action2, value);
							action = Interlocked.CompareExchange(ref FEPTxvRGZPVgvJmrgyAMzINKESZ, value2, action2);
							num = -212792194;
						}
					}
				}
			}

			public event Action<rMXeVyQRoAZEBwVRuFdxJcMiwcS> ControllerDisconnectedEvent
			{
				add
				{
					Action<rMXeVyQRoAZEBwVRuFdxJcMiwcS> action = gjXNLThJtmyygYNNjrokZppaCuh;
					Action<rMXeVyQRoAZEBwVRuFdxJcMiwcS> action2 = default(Action<rMXeVyQRoAZEBwVRuFdxJcMiwcS>);
					while (true)
					{
						int num = -669638951;
						while (true)
						{
							switch (num ^ -669638950)
							{
							case 0:
								break;
							default:
								return;
							case 3:
								action2 = action;
								num = -669638952;
								continue;
							case 2:
							{
								Action<rMXeVyQRoAZEBwVRuFdxJcMiwcS> value2 = (Action<rMXeVyQRoAZEBwVRuFdxJcMiwcS>)Delegate.Combine(action2, value);
								action = Interlocked.CompareExchange(ref gjXNLThJtmyygYNNjrokZppaCuh, value2, action2);
								int num2;
								if ((object)action != action2)
								{
									num = -669638951;
									num2 = num;
								}
								else
								{
									num = -669638949;
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
					Action<rMXeVyQRoAZEBwVRuFdxJcMiwcS> action = gjXNLThJtmyygYNNjrokZppaCuh;
					Action<rMXeVyQRoAZEBwVRuFdxJcMiwcS> action2 = default(Action<rMXeVyQRoAZEBwVRuFdxJcMiwcS>);
					while (true)
					{
						int num = 501571382;
						while (true)
						{
							switch (num ^ 0x1DE55F37)
							{
							case 2:
								break;
							case 1:
								goto IL_0025;
							default:
								if ((object)action != action2)
								{
									goto IL_0025;
								}
								return;
							}
							break;
							IL_0025:
							action2 = action;
							Action<rMXeVyQRoAZEBwVRuFdxJcMiwcS> value2 = (Action<rMXeVyQRoAZEBwVRuFdxJcMiwcS>)Delegate.Remove(action2, value);
							action = Interlocked.CompareExchange(ref gjXNLThJtmyygYNNjrokZppaCuh, value2, action2);
							num = 501571383;
						}
					}
				}
			}

			public IIqKWhcwYfTkjFaCdbDyqeTmfDbE(int maxPlayers, bool supportSpecialControllers)
			{
				IFzonqkgUvtsQDZYdtkKkiUWzkU = maxPlayers;
				JgzMgwyoSMxRLONFIKIRDAGjgYZ = supportSpecialControllers;
				fHoYXaBGGUKVerUUbaHchxOWczO = new int[maxPlayers];
				FpzfMMbvkdVoCQHvBfZAPENAVFj = new int[maxPlayers];
				CSVtdAbVaTDDPSZLuxRKdHWbfrO = UnityTools.externalTools;
				lnincIBnfCPSsSUIJHQjshOuEOK = new jxXIuBMHDKzgzIncVDKBvGhCyUc[maxPlayers];
				ArrayTools.Populate(lnincIBnfCPSsSUIJHQjshOuEOK, () => new jxXIuBMHDKzgzIncVDKBvGhCyUc(false));
				if (supportSpecialControllers)
				{
					JmfAqvJtAeVwjlpZNLfXDiSzDNGI = new jxXIuBMHDKzgzIncVDKBvGhCyUc[maxPlayers];
					ArrayTools.Populate(JmfAqvJtAeVwjlpZNLfXDiSzDNGI, () => new jxXIuBMHDKzgzIncVDKBvGhCyUc(true));
				}
				RjVfRHjcXyROCnqtZKVcbRGfQBz = new List<CxpfePEvjrPvXzDxRKhzJuSoUUl>(2);
				yeGDeEDIKmSSaKdNpUJGMrnuxYa = new List<rMXeVyQRoAZEBwVRuFdxJcMiwcS>(2);
			}

			public void rdEJYvExbWYUXSDuseVgzyXPBhA()
			{
				CSVtdAbVaTDDPSZLuxRKdHWbfrO.PS4Input_PadGetUsersHandles2(IFzonqkgUvtsQDZYdtkKkiUWzkU, fHoYXaBGGUKVerUUbaHchxOWczO);
				int i = default(int);
				bool flag = default(bool);
				jxXIuBMHDKzgzIncVDKBvGhCyUc jxXIuBMHDKzgzIncVDKBvGhCyUc3 = default(jxXIuBMHDKzgzIncVDKBvGhCyUc);
				bool flag2 = default(bool);
				int num3 = default(int);
				int num7 = default(int);
				while (true)
				{
					int num = 346730176;
					while (true)
					{
						switch (num ^ 0x14AAAEC1)
						{
						case 0:
							break;
						case 1:
							goto IL_0036;
						default:
							for (; i < IFzonqkgUvtsQDZYdtkKkiUWzkU; i++)
							{
								try
								{
									jxXIuBMHDKzgzIncVDKBvGhCyUc jxXIuBMHDKzgzIncVDKBvGhCyUc2 = lnincIBnfCPSsSUIJHQjshOuEOK[i];
									while (true)
									{
										IL_0065:
										int num2 = 346730180;
										while (true)
										{
											int num6;
											switch (num2 ^ 0x14AAAEC1)
											{
											case 7:
												break;
											case 5:
												flag = CSVtdAbVaTDDPSZLuxRKdHWbfrO.PS4Input_PadIsConnected(i);
												num2 = 346730177;
												continue;
											case 2:
												if (!JgzMgwyoSMxRLONFIKIRDAGjgYZ)
												{
													goto case 3;
												}
												jxXIuBMHDKzgzIncVDKBvGhCyUc3 = JmfAqvJtAeVwjlpZNLfXDiSzDNGI[i];
												flag2 = CSVtdAbVaTDDPSZLuxRKdHWbfrO.PS4Input_SpecialIsConnected(i);
												if (!jxXIuBMHDKzgzIncVDKBvGhCyUc3.MICQfhOSEKeMgZWmkgJAMVWaOIJ)
												{
													int num5;
													if (flag2)
													{
														num2 = 346730176;
														num5 = num2;
													}
													else
													{
														num2 = 346730178;
														num5 = num2;
													}
													continue;
												}
												goto case 1;
											case 0:
												if (!jxXIuBMHDKzgzIncVDKBvGhCyUc2.MICQfhOSEKeMgZWmkgJAMVWaOIJ)
												{
													int num4;
													if (flag)
													{
														num2 = 346730181;
														num4 = num2;
													}
													else
													{
														num2 = 346730179;
														num4 = num2;
													}
													continue;
												}
												goto case 4;
											case 4:
												zfHXUNWrZXDJMMMKyqiRsyKlFCK(i, jxXIuBMHDKzgzIncVDKBvGhCyUc2, fHoYXaBGGUKVerUUbaHchxOWczO[i], flag);
												num2 = 346730179;
												continue;
											case 3:
												if (yeGDeEDIKmSSaKdNpUJGMrnuxYa.Count > 0)
												{
													num2 = 346730183;
													continue;
												}
												goto IL_01c2;
											case 1:
												zfHXUNWrZXDJMMMKyqiRsyKlFCK(i, jxXIuBMHDKzgzIncVDKBvGhCyUc3, FpzfMMbvkdVoCQHvBfZAPENAVFj[i], flag2);
												num2 = 346730178;
												continue;
											default:
												{
													num3 = 0;
													goto IL_01f6;
												}
												IL_01c2:
												if (RjVfRHjcXyROCnqtZKVcbRGfQBz.Count > 0)
												{
													num6 = 346730177;
													goto IL_019d;
												}
												goto end_IL_006a;
												IL_0198:
												num6 = 346730176;
												goto IL_019d;
												IL_019d:
												while (true)
												{
													switch (num6 ^ 0x14AAAEC1)
													{
													case 5:
														break;
													case 2:
														goto IL_01c2;
													case 4:
														yeGDeEDIKmSSaKdNpUJGMrnuxYa.Clear();
														num6 = 346730179;
														continue;
													case 0:
														num7 = 0;
														num6 = 346730178;
														continue;
													case 1:
														goto IL_01f6;
													default:
														while (true)
														{
															IL_0268:
															if (num7 < RjVfRHjcXyROCnqtZKVcbRGfQBz.Count)
															{
																try
																{
																	FEPTxvRGZPVgvJmrgyAMzINKESZ(RjVfRHjcXyROCnqtZKVcbRGfQBz[num7]);
																}
																catch (Exception ex)
																{
																	Logger.LogError("An exception occurred in controller monitor Controller Connect Event callback.\n" + ex);
																}
																num7++;
																goto IL_0246;
															}
															int num8 = 346730179;
															goto IL_024b;
															IL_024b:
															while (true)
															{
																switch (num8 ^ 0x14AAAEC1)
																{
																case 3:
																	break;
																default:
																	goto end_IL_0268;
																case 1:
																	goto IL_0268;
																case 2:
																	RjVfRHjcXyROCnqtZKVcbRGfQBz.Clear();
																	num8 = 346730177;
																	continue;
																case 0:
																	goto end_IL_0268;
																}
																break;
															}
															goto IL_0246;
															IL_0246:
															num8 = 346730176;
															goto IL_024b;
															continue;
															end_IL_0268:
															break;
														}
														goto end_IL_006a;
													}
													break;
												}
												goto IL_0198;
												IL_01f6:
												if (num3 < yeGDeEDIKmSSaKdNpUJGMrnuxYa.Count)
												{
													try
													{
														gjXNLThJtmyygYNNjrokZppaCuh(yeGDeEDIKmSSaKdNpUJGMrnuxYa[num3]);
													}
													catch (Exception ex2)
													{
														Logger.LogError("An exception occurred in controller monitor Controller Disconnect Event callback.\n" + ex2);
													}
													num3++;
													goto IL_0198;
												}
												num6 = 346730181;
												goto IL_019d;
											}
											goto IL_0065;
											continue;
											end_IL_006a:
											break;
										}
										break;
									}
								}
								catch (Exception ex3)
								{
									while (true)
									{
										IL_0294:
										int num9 = 346730176;
										while (true)
										{
											switch (num9 ^ 0x14AAAEC1)
											{
											case 2:
												break;
											default:
												goto end_IL_0299;
											case 1:
												goto IL_02b2;
											case 0:
												goto end_IL_0299;
											}
											goto IL_0294;
											IL_02b2:
											Logger.LogError("An exception occurred during controller monitor update.\n" + ex3);
											num9 = 346730177;
											continue;
											end_IL_0299:
											break;
										}
										break;
									}
								}
							}
							return;
						}
						break;
						IL_0036:
						CSVtdAbVaTDDPSZLuxRKdHWbfrO.PS4Input_SpecialGetUsersHandles2(IFzonqkgUvtsQDZYdtkKkiUWzkU, FpzfMMbvkdVoCQHvBfZAPENAVFj);
						i = 0;
						num = 346730179;
					}
				}
			}

			private void zfHXUNWrZXDJMMMKyqiRsyKlFCK(int P_0, jxXIuBMHDKzgzIncVDKBvGhCyUc P_1, int P_2, bool P_3)
			{
				int num = CSVtdAbVaTDDPSZLuxRKdHWbfrO.PS4Input_GetDeviceClassForHandle(P_2);
				int pjAxoGjQdUQZKLDflwZaqfSLVAC = P_1.pjAxoGjQdUQZKLDflwZaqfSLVAC;
				adjZXRKwqhKipdlJKvGxPdVPOrZ adjZXRKwqhKipdlJKvGxPdVPOrZ2 = P_1.bXGKkfLvHHQrlFiPyVIyMYzrtnu(P_3, P_2, num);
				while (true)
				{
					int num2 = -1038493551;
					while (true)
					{
						switch (num2 ^ -1038493544)
						{
						case 7:
							break;
						default:
							return;
						case 3:
						{
							int num5;
							if ((adjZXRKwqhKipdlJKvGxPdVPOrZ2 & adjZXRKwqhKipdlJKvGxPdVPOrZ.OlrsfcQzhPGAwvfQNjJivvrkJaM) == 0)
							{
								num2 = -1038493550;
								num5 = num2;
							}
							else
							{
								num2 = -1038493538;
								num5 = num2;
							}
							continue;
						}
						case 10:
							if (P_1.MICQfhOSEKeMgZWmkgJAMVWaOIJ)
							{
								int num8;
								if ((adjZXRKwqhKipdlJKvGxPdVPOrZ2 & adjZXRKwqhKipdlJKvGxPdVPOrZ.JDbGekIAZLOyvctfFteMapZcaUv) != adjZXRKwqhKipdlJKvGxPdVPOrZ.iOlZgcuFwLCPNAjSgaSDuxucio)
								{
									num2 = -1038493538;
									num8 = num2;
								}
								else
								{
									num2 = -1038493552;
									num8 = num2;
								}
								continue;
							}
							goto case 8;
						case 9:
						{
							int num4;
							if (adjZXRKwqhKipdlJKvGxPdVPOrZ2 == adjZXRKwqhKipdlJKvGxPdVPOrZ.iOlZgcuFwLCPNAjSgaSDuxucio)
							{
								num2 = -1038493540;
								num4 = num2;
							}
							else
							{
								num2 = -1038493541;
								num4 = num2;
							}
							continue;
						}
						case 5:
							RjVfRHjcXyROCnqtZKVcbRGfQBz.Add(new CxpfePEvjrPvXzDxRKhzJuSoUUl(P_0, P_1.pjAxoGjQdUQZKLDflwZaqfSLVAC, P_1.UpbvuofvMXACqnIAqdAZtGTUAmZF, P_1.vgzDviaSvJLFelnUoFPhPTYvfRj));
							num2 = -1038493544;
							continue;
						case 4:
							return;
						case 1:
						{
							int num6;
							if ((adjZXRKwqhKipdlJKvGxPdVPOrZ2 & adjZXRKwqhKipdlJKvGxPdVPOrZ.JDbGekIAZLOyvctfFteMapZcaUv) == 0)
							{
								num2 = -1038493544;
								num6 = num2;
							}
							else
							{
								num2 = -1038493539;
								num6 = num2;
							}
							continue;
						}
						case 2:
						{
							int num3;
							if (!P_1.MICQfhOSEKeMgZWmkgJAMVWaOIJ)
							{
								num2 = -1038493544;
								num3 = num2;
							}
							else
							{
								num2 = -1038493543;
								num3 = num2;
							}
							continue;
						}
						case 8:
						{
							int num7;
							if ((adjZXRKwqhKipdlJKvGxPdVPOrZ2 & adjZXRKwqhKipdlJKvGxPdVPOrZ.jikNtdRieZgCLIcbSBeRBnEBmcwg) != adjZXRKwqhKipdlJKvGxPdVPOrZ.iOlZgcuFwLCPNAjSgaSDuxucio)
							{
								num2 = -1038493539;
								num7 = num2;
							}
							else
							{
								num2 = -1038493542;
								num7 = num2;
							}
							continue;
						}
						case 6:
							yeGDeEDIKmSSaKdNpUJGMrnuxYa.Add(new rMXeVyQRoAZEBwVRuFdxJcMiwcS(P_0, pjAxoGjQdUQZKLDflwZaqfSLVAC, P_1.vgzDviaSvJLFelnUoFPhPTYvfRj));
							num2 = -1038493552;
							continue;
						case 0:
							return;
						}
						break;
					}
				}
			}

			[CompilerGenerated]
			private static jxXIuBMHDKzgzIncVDKBvGhCyUc QbjYJUHrzbbBZTgcghyGnqYCPyC()
			{
				return new jxXIuBMHDKzgzIncVDKBvGhCyUc(false);
			}

			[CompilerGenerated]
			private static jxXIuBMHDKzgzIncVDKBvGhCyUc UVQTpWqMvgFZQiYVDcnwWmBAcBdH()
			{
				return new jxXIuBMHDKzgzIncVDKBvGhCyUc(true);
			}
		}

		private abstract class VpzBxZLGxbVcbByijUsaovouNIq : Joystick, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource
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

			protected enum jEDsQXPVXYSSIJjHktJadJKsHNg
			{
				hWboZvyXoJNhfSvesxqLLWrBcgF = 0,
				kZJANmJeecesjInyioEMgsmcQbwO = 1,
				OJhdumugZiufowGkLZcaEfOXWXZ = 2
			}

			public class ZDMAdSSzCNOfLXFZcDUuBtiHxDsr
			{
				public readonly int ijxelHigybruBiYdNSiiNzGQTwsf;

				public readonly int vgSbQnhkfGJDrjOShKPojdhsCSkQ;

				public readonly float ckxvDbLCCUbCwWeiQBcdVmOmuGX;

				public readonly int QTcZLynCWHLLppDxcAAAPxKXLEc;

				public readonly int sItfPCEBAPpHkLQSrZRmeYRJSDA;

				public ZDMAdSSzCNOfLXFZcDUuBtiHxDsr(int axisCount, int buttonCount, float dpadDeadzone, int vibrationMotorCount, int maxTouches)
				{
					while (true)
					{
						int num = 324966134;
						while (true)
						{
							switch (num ^ 0x135E96F7)
							{
							case 0:
								break;
							case 1:
								goto IL_0024;
							default:
								vgSbQnhkfGJDrjOShKPojdhsCSkQ = buttonCount;
								ckxvDbLCCUbCwWeiQBcdVmOmuGX = dpadDeadzone;
								QTcZLynCWHLLppDxcAAAPxKXLEc = vibrationMotorCount;
								sItfPCEBAPpHkLQSrZRmeYRJSDA = maxTouches;
								return;
							}
							break;
							IL_0024:
							ijxelHigybruBiYdNSiiNzGQTwsf = axisCount;
							num = 324966133;
						}
					}
				}
			}

			public const bool emjfijaodztYbgxRpawPxIRXHevc = true;

			private static int POmEILBRzOrhkpVISKOrPzSjkJC;

			protected readonly int VUcYiZtcJRatratRXOokIFfcdNSg;

			protected readonly int jBTFYRozZBeTpjyGormnAXwaeCl;

			protected readonly bool rrOQOsFSAdFjoMDzrnAFHzYJmiw;

			protected readonly ZDMAdSSzCNOfLXFZcDUuBtiHxDsr zUntMgqBZVybGrvPQOncmfSIECd;

			protected readonly int yKqGDhHrAETHXtPwAnMaiBpAiBkC;

			protected readonly float[] DlmkfMpVkEoqdutpsvuIsMgalmq;

			private readonly LoggedInUser kIAYaRzOkYdkkibdNYAGMWaiySt;

			protected readonly ControllerType JNNGbJEWijctWBKzGmlLLQzaVVsi;

			private readonly Func<int, bool> fCIaDOdoPittMRqbaPGadyQgxKqa;

			private readonly Action<int, int, int> CiygzSYpeIQkkXuMAeTZggFfcjqh;

			private readonly Action<int, int, int, int> BIUvTGDCziIJbaNBNSlTDnnJURz;

			private readonly Action<int> ZwIEeniTTautbkkzUpYkVxxusEic;

			private Action<int, bool> cRvZKDxUaUybVASITHBGvNRuEwv;

			private Action<int, bool> mwqQCOfYCjJgpbNYNpdQkFxPwyU;

			private Action<int, bool> AZvACbmOXBJkreccIJrCeqIVDgSG;

			private Action<int> HmfDgzBvPKKCagMwfRIEAdJAIKzg;

			private Func<int, Vector3> pfIEXtfuJQSsIJGtEEPscrFYqYf;

			private Func<int, Vector3> bDNfEDDiQeRlXPGYlOzODggqESbL;

			private Func<int, Vector4> PMXnSkDXHlPRQEWssBzqfeERItM;

			private static int NextSystemId
			{
				get
				{
					int pOmEILBRzOrhkpVISKOrPzSjkJC = POmEILBRzOrhkpVISKOrPzSjkJC;
					while (true)
					{
						int num = -1882242926;
						while (true)
						{
							switch (num ^ -1882242928)
							{
							case 0:
								break;
							case 2:
								goto IL_0024;
							default:
								return pOmEILBRzOrhkpVISKOrPzSjkJC;
							}
							break;
							IL_0024:
							POmEILBRzOrhkpVISKOrPzSjkJC++;
							num = -1882242927;
						}
					}
				}
			}

			protected LoggedInUser user
			{
				get
				{
					UnityTools.externalTools.PS4Input_GetUsersDetails(VUcYiZtcJRatratRXOokIFfcdNSg, kIAYaRzOkYdkkibdNYAGMWaiySt);
					return kIAYaRzOkYdkkibdNYAGMWaiySt;
				}
			}

			public ControllerType type
			{
				get
				{
					return JNNGbJEWijctWBKzGmlLLQzaVVsi;
				}
			}

			public int playerId
			{
				get
				{
					return VUcYiZtcJRatratRXOokIFfcdNSg;
				}
			}

			public int handle
			{
				get
				{
					return jBTFYRozZBeTpjyGormnAXwaeCl;
				}
			}

			public bool isSpecialController
			{
				get
				{
					return rrOQOsFSAdFjoMDzrnAFHzYJmiw;
				}
			}

			private bool IsConnectedNow
			{
				get
				{
					return fCIaDOdoPittMRqbaPGadyQgxKqa(VUcYiZtcJRatratRXOokIFfcdNSg);
				}
			}

			public int vibrationMotorCount
			{
				get
				{
					return zUntMgqBZVybGrvPQOncmfSIECd.QTcZLynCWHLLppDxcAAAPxKXLEc;
				}
			}

			public static VpzBxZLGxbVcbByijUsaovouNIq rHXUBQoqejbkONabpWgwEqatBJ(ControllerType P_0, int P_1, int P_2)
			{
				while (true)
				{
					int num = 1243676463;
					while (true)
					{
						switch (num ^ 0x4A20FF2E)
						{
						case 2:
							break;
						case 1:
							if (P_0 == ControllerType.Gamepad)
							{
								goto IL_0024;
							}
							return hycqpwYCiqXRfRcaBeNXkYfLOVI.rHXUBQoqejbkONabpWgwEqatBJ(P_0, P_1, P_2);
						default:
							return new YwenCpTFUQlAHHwcJCcUqLcAIRn("Controller " + (P_1 + 1), P_1, P_1 + 1, P_2);
						}
						break;
						IL_0024:
						num = 1243676462;
					}
				}
			}

			public static VpzBxZLGxbVcbByijUsaovouNIq rHXUBQoqejbkONabpWgwEqatBJ(bool P_0, int P_1, int P_2, int P_3)
			{
				if (!P_0)
				{
					return rHXUBQoqejbkONabpWgwEqatBJ(ControllerType.Gamepad, P_2, P_3);
				}
				return hycqpwYCiqXRfRcaBeNXkYfLOVI.rHXUBQoqejbkONabpWgwEqatBJ(P_1, P_2, P_3);
			}

			protected VpzBxZLGxbVcbByijUsaovouNIq(ControllerType type, string name, int playerId, int unityJoystickId, int handle, ZDMAdSSzCNOfLXFZcDUuBtiHxDsr capabilities)
				: base(name, NextSystemId, unityJoystickId, capabilities.ijxelHigybruBiYdNSiiNzGQTwsf, capabilities.vgSbQnhkfGJDrjOShKPojdhsCSkQ)
			{
				if (capabilities == null)
				{
					throw new ArgumentNullException("capabilities");
				}
				JNNGbJEWijctWBKzGmlLLQzaVVsi = type;
				VUcYiZtcJRatratRXOokIFfcdNSg = playerId;
				yKqGDhHrAETHXtPwAnMaiBpAiBkC = unityJoystickId - 1;
				zUntMgqBZVybGrvPQOncmfSIECd = capabilities;
				jBTFYRozZBeTpjyGormnAXwaeCl = handle;
				kIAYaRzOkYdkkibdNYAGMWaiySt = new LoggedInUser();
				_customName = name;
				DlmkfMpVkEoqdutpsvuIsMgalmq = new float[capabilities.QTcZLynCWHLLppDxcAAAPxKXLEc];
				base.supportsVibration = capabilities.QTcZLynCWHLLppDxcAAAPxKXLEc > 0;
				rrOQOsFSAdFjoMDzrnAFHzYJmiw = this is hycqpwYCiqXRfRcaBeNXkYfLOVI;
				if (rrOQOsFSAdFjoMDzrnAFHzYJmiw)
				{
					fCIaDOdoPittMRqbaPGadyQgxKqa = UnityTools.externalTools.PS4Input_SpecialIsConnected;
					CiygzSYpeIQkkXuMAeTZggFfcjqh = UnityTools.externalTools.PS4Input_SpecialSetVibration;
					BIUvTGDCziIJbaNBNSlTDnnJURz = UnityTools.externalTools.PS4Input_SpecialSetLightSphere;
					ZwIEeniTTautbkkzUpYkVxxusEic = UnityTools.externalTools.PS4Input_SpecialResetLightSphere;
					cRvZKDxUaUybVASITHBGvNRuEwv = UnityTools.externalTools.PS4Input_SpecialSetMotionSensorState;
					mwqQCOfYCjJgpbNYNpdQkFxPwyU = UnityTools.externalTools.PS4Input_SpecialSetTiltCorrectionState;
					AZvACbmOXBJkreccIJrCeqIVDgSG = UnityTools.externalTools.PS4Input_SpecialSetAngularVelocityDeadbandState;
					HmfDgzBvPKKCagMwfRIEAdJAIKzg = UnityTools.externalTools.PS4Input_SpecialResetOrientation;
					pfIEXtfuJQSsIJGtEEPscrFYqYf = UnityTools.externalTools.PS4Input_SpecialGetLastAcceleration;
					bDNfEDDiQeRlXPGYlOzODggqESbL = UnityTools.externalTools.PS4Input_SpecialGetLastGyro;
					PMXnSkDXHlPRQEWssBzqfeERItM = UnityTools.externalTools.PS4Input_SpecialGetLastOrientation;
				}
				else
				{
					fCIaDOdoPittMRqbaPGadyQgxKqa = UnityTools.externalTools.PS4Input_PadIsConnected;
					CiygzSYpeIQkkXuMAeTZggFfcjqh = UnityTools.externalTools.PS4Input_PadSetVibration;
					BIUvTGDCziIJbaNBNSlTDnnJURz = UnityTools.externalTools.PS4Input_PadSetLightBar;
					ZwIEeniTTautbkkzUpYkVxxusEic = UnityTools.externalTools.PS4Input_PadResetLightBar;
					cRvZKDxUaUybVASITHBGvNRuEwv = UnityTools.externalTools.PS4Input_PadSetMotionSensorState;
					mwqQCOfYCjJgpbNYNpdQkFxPwyU = UnityTools.externalTools.PS4Input_PadSetTiltCorrectionState;
					AZvACbmOXBJkreccIJrCeqIVDgSG = UnityTools.externalTools.PS4Input_PadSetAngularVelocityDeadbandState;
					HmfDgzBvPKKCagMwfRIEAdJAIKzg = UnityTools.externalTools.PS4Input_PadResetOrientation;
					pfIEXtfuJQSsIJGtEEPscrFYqYf = UnityTools.externalTools.PS4Input_GetLastAcceleration;
					bDNfEDDiQeRlXPGYlOzODggqESbL = UnityTools.externalTools.PS4Input_GetLastGyro;
					PMXnSkDXHlPRQEWssBzqfeERItM = UnityTools.externalTools.PS4Input_GetLastOrientation;
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
				int color = loggedInUser.color;
				while (true)
				{
					switch (-1632002698 ^ -1632002700)
					{
					case 0:
						continue;
					case 2:
						switch (color)
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
				Array.Clear(DlmkfMpVkEoqdutpsvuIsMgalmq, 0, DlmkfMpVkEoqdutpsvuIsMgalmq.Length);
				dvUEbkQErvhpnNnsiFIwjwoYPIvn();
			}

			public void SetVibration(int P_0, float P_1)
			{
				if ((uint)P_0 > (uint)zUntMgqBZVybGrvPQOncmfSIECd.QTcZLynCWHLLppDxcAAAPxKXLEc)
				{
					return;
				}
				while (true)
				{
					DlmkfMpVkEoqdutpsvuIsMgalmq[P_0] = P_1;
					int num = -1686503435;
					while (true)
					{
						switch (num ^ -1686503436)
						{
						case 0:
							goto IL_000f;
						case 2:
							break;
						default:
							dvUEbkQErvhpnNnsiFIwjwoYPIvn();
							return;
						}
						break;
						IL_000f:
						num = -1686503434;
					}
				}
			}

			public float GetVibration(int P_0)
			{
				if ((uint)P_0 > (uint)zUntMgqBZVybGrvPQOncmfSIECd.QTcZLynCWHLLppDxcAAAPxKXLEc)
				{
					return 0f;
				}
				return DlmkfMpVkEoqdutpsvuIsMgalmq[P_0];
			}

			public void SetMotionSensorState(bool P_0)
			{
				cRvZKDxUaUybVASITHBGvNRuEwv(VUcYiZtcJRatratRXOokIFfcdNSg, P_0);
			}

			public void SetTiltCorrectionState(bool P_0)
			{
				mwqQCOfYCjJgpbNYNpdQkFxPwyU(VUcYiZtcJRatratRXOokIFfcdNSg, P_0);
			}

			public void SetAngularVelocityDeadbandState(bool P_0)
			{
				AZvACbmOXBJkreccIJrCeqIVDgSG(VUcYiZtcJRatratRXOokIFfcdNSg, P_0);
			}

			public void ResetOrientation()
			{
				HmfDgzBvPKKCagMwfRIEAdJAIKzg(VUcYiZtcJRatratRXOokIFfcdNSg);
			}

			public Vector3 GetLastAcceleration()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				Vector3 result = pfIEXtfuJQSsIJGtEEPscrFYqYf(VUcYiZtcJRatratRXOokIFfcdNSg);
				PBYTnLtaBlMFgIlDBgogfXizCJQ(ref result);
				return result;
			}

			public Vector3 GetLastAccelerationRaw()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				return pfIEXtfuJQSsIJGtEEPscrFYqYf(VUcYiZtcJRatratRXOokIFfcdNSg);
			}

			public Vector3 GetLastGyro()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				Vector3 result = bDNfEDDiQeRlXPGYlOzODggqESbL(VUcYiZtcJRatratRXOokIFfcdNSg);
				HJAJCeeZJhXZonzHmnhvuAKrWPO(ref result);
				return result;
			}

			public Vector3 GetLastGyroRaw()
			{
				if (!IsConnectedNow)
				{
					return Vector3.zero;
				}
				return bDNfEDDiQeRlXPGYlOzODggqESbL(VUcYiZtcJRatratRXOokIFfcdNSg);
			}

			public Quaternion GetLastOrientation()
			{
				if (!IsConnectedNow)
				{
					return Quaternion.identity;
				}
				Vector4 vector = PMXnSkDXHlPRQEWssBzqfeERItM(VUcYiZtcJRatratRXOokIFfcdNSg);
				return new Quaternion(vector.x * -1f, vector.y, vector.z, vector.w);
			}

			public Quaternion GetLastOrientationRaw()
			{
				if (!IsConnectedNow)
				{
					return Quaternion.identity;
				}
				Vector4 vector = PMXnSkDXHlPRQEWssBzqfeERItM(VUcYiZtcJRatratRXOokIFfcdNSg);
				return new Quaternion(vector.x, vector.y, vector.z, vector.w);
			}

			public void SetLightColor(int P_0, int P_1, int P_2)
			{
				BIUvTGDCziIJbaNBNSlTDnnJURz(VUcYiZtcJRatratRXOokIFfcdNSg, P_0, P_1, P_2);
			}

			public void ResetLight()
			{
				ZwIEeniTTautbkkzUpYkVxxusEic(VUcYiZtcJRatratRXOokIFfcdNSg);
			}

			protected virtual void UpdateElementValues()
			{
				int joystickId = yKqGDhHrAETHXtPwAnMaiBpAiBkC + 1;
				IList<Button> buttons = default(IList<Button>);
				IList<Axis> axes = default(IList<Axis>);
				while (true)
				{
					int num = -706948501;
					while (true)
					{
						switch (num ^ -706948499)
						{
						case 2:
							break;
						default:
							return;
						case 6:
							buttons = base.Buttons;
							buttons[0].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 0);
							buttons[1].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 1);
							buttons[2].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 2);
							buttons[3].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 3);
							buttons[4].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 4);
							buttons[5].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 5);
							buttons[6].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 6);
							num = -706948498;
							continue;
						case 1:
							axes[4].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 7);
							num = -706948504;
							continue;
						case 0:
							axes[2].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 3);
							axes[3].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 4);
							num = -706948500;
							continue;
						case 5:
							axes[5].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 2);
							num = -706948503;
							continue;
						case 3:
						{
							buttons[7].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 7);
							buttons[8].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 8);
							buttons[9].value = UnityInputHelper.GetJoystickButtonValueByJoystickId(joystickId, 9);
							float joystickAxisValueByJoystickId = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 5);
							float joystickAxisValueByJoystickId2 = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 6);
							buttons[10].value = joystickAxisValueByJoystickId2 > zUntMgqBZVybGrvPQOncmfSIECd.ckxvDbLCCUbCwWeiQBcdVmOmuGX;
							buttons[11].value = joystickAxisValueByJoystickId > zUntMgqBZVybGrvPQOncmfSIECd.ckxvDbLCCUbCwWeiQBcdVmOmuGX;
							buttons[12].value = joystickAxisValueByJoystickId2 < 0f - zUntMgqBZVybGrvPQOncmfSIECd.ckxvDbLCCUbCwWeiQBcdVmOmuGX;
							buttons[13].value = joystickAxisValueByJoystickId < 0f - zUntMgqBZVybGrvPQOncmfSIECd.ckxvDbLCCUbCwWeiQBcdVmOmuGX;
							axes = base.Axes;
							axes[0].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 0);
							axes[1].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 1);
							num = -706948499;
							continue;
						}
						case 4:
							return;
						}
						break;
					}
				}
			}

			protected void dvUEbkQErvhpnNnsiFIwjwoYPIvn()
			{
				if (zUntMgqBZVybGrvPQOncmfSIECd.QTcZLynCWHLLppDxcAAAPxKXLEc == 0)
				{
					while (true)
					{
						switch (0x388A684E ^ 0x388A684C)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				CiygzSYpeIQkkXuMAeTZggFfcjqh(VUcYiZtcJRatratRXOokIFfcdNSg, pWOTUNeirYiNjiKFhopduGJhyWp(DlmkfMpVkEoqdutpsvuIsMgalmq[0]), pWOTUNeirYiNjiKFhopduGJhyWp(DlmkfMpVkEoqdutpsvuIsMgalmq[1]));
			}

			protected static int pWOTUNeirYiNjiKFhopduGJhyWp(float P_0)
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

			protected static void PBYTnLtaBlMFgIlDBgogfXizCJQ(ref Vector3 P_0)
			{
				P_0.x *= -1f;
				P_0.y *= -1f;
			}

			protected static void HJAJCeeZJhXZonzHmnhvuAKrWPO(ref Vector3 P_0)
			{
				P_0.x *= -1f;
				P_0.y *= -1f;
			}

			protected static bool YcuIRbcfCuJAoeNHmNkkzyvzmjK(int P_0, out ControllerType P_1)
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
				int num;
				if (!text.Equals("FlightStick", StringComparison.OrdinalIgnoreCase))
				{
					if (text.Equals("hotas", StringComparison.OrdinalIgnoreCase))
					{
						goto IL_004e;
					}
					if (!text.Equals("Stick", StringComparison.OrdinalIgnoreCase))
					{
						if (!text.Equals("hotas", StringComparison.OrdinalIgnoreCase))
						{
							if (text.Equals("SteeringWheel", StringComparison.OrdinalIgnoreCase))
							{
								P_1 = ControllerType.SteeringWheel;
								return true;
							}
							if (!text.Equals("Guitar", StringComparison.OrdinalIgnoreCase))
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
									num = -22586358;
								}
								else if (text.Equals("Dancemat", StringComparison.OrdinalIgnoreCase))
								{
									num = -22586364;
								}
								else
								{
									if (!text.Equals("Navigation", StringComparison.OrdinalIgnoreCase))
									{
										P_1 = ControllerType.Unknown;
										return false;
									}
									num = -22586365;
								}
							}
							else
							{
								P_1 = ControllerType.Guitar;
								num = -22586366;
							}
						}
						else
						{
							num = -22586361;
						}
						goto IL_0053;
					}
					goto IL_0087;
				}
				goto IL_00d0;
				IL_0087:
				P_1 = ControllerType.FlightStick;
				num = -22586362;
				goto IL_0053;
				IL_0053:
				switch (num ^ -22586366)
				{
				case 3:
					break;
				case 5:
					goto IL_0087;
				case 0:
					return true;
				case 2:
					goto IL_00d0;
				case 8:
					P_1 = ControllerType.DjTurntable;
					return true;
				case 4:
					return true;
				case 6:
					P_1 = ControllerType.DanceMat;
					return true;
				case 7:
					return true;
				default:
					P_1 = ControllerType.Navigation;
					return true;
				}
				goto IL_004e;
				IL_004e:
				num = -22586368;
				goto IL_0053;
				IL_00d0:
				P_1 = ControllerType.FlightStick;
				num = -22586363;
				goto IL_0053;
			}
		}

		private sealed class YwenCpTFUQlAHHwcJCcUqLcAIRn : VpzBxZLGxbVcbByijUsaovouNIq, IPS4ControllerExtensionSourceSixAxisSensor, IPS4ControllerExtensionSourceVibrator, IPS4ControllerExtensionSourceLight, IPS4ControllerExtensionSource, IPS4ControllerExtensionSourceTouchPad, IPS4GamepadExtensionSource
		{
			private const int XOnWiKThBydhDsxQmELHDhRZdPqb = 6;

			private const int VDaLjZYdsRIqheXEANPwCBhYDPo = 14;

			private const float XkocvynAJGDJqmSGQqiUMXQKoZA = 0.05f;

			private const int PyZsPQUJwDInSkCybitITthgrMK = 2;

			private const int jIjGSOJaGZVCFVspxYiTawrnGznD = 2;

			private int hZblgvgQdThLguRvJjZDNfQBMgH;

			private int AuKAFeocGtgPngyQicFYcXWhpvLF;

			private Vector2 mJonoTzwsGtdcIbKaZVsFBSFkAd;

			private int VTcWdDkvirwyvJPkAaLCWbwExgA;

			private Vector2 iQsnudlniJgDaCOzUXddrIcJchcX;

			private jEDsQXPVXYSSIJjHktJadJKsHNg tJkOioOxaiWoOTmQCmyRwTXqZvS;

			private int VFtLwwVjNGdknsHlqAtMfwwjWrth;

			private int DJxQgyEXUuRCYzhKxgLueuMuWCiD;

			private int BfbxEvZUywqqrNNbjNlcgXWxNKt;

			private int yCenbyuEUkDyntWjnbtrhRasjfDk;

			private float yZOhzVlZbHbfUbUbxmpzpbMWCiof;

			public int maxTouches
			{
				get
				{
					return zUntMgqBZVybGrvPQOncmfSIECd.sItfPCEBAPpHkLQSrZRmeYRJSDA;
				}
			}

			public YwenCpTFUQlAHHwcJCcUqLcAIRn(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Gamepad, name, playerId, unityJoystickId, handle, new ZDMAdSSzCNOfLXFZcDUuBtiHxDsr(6, 14, 0.05f, 2, 2))
			{
				IFpGKVXFaghSybCWgGXRHKOZiWN();
				base.extension = new PS4GamepadExtension(this);
			}

			public int GetConnectionType()
			{
				return (int)tJkOioOxaiWoOTmQCmyRwTXqZvS;
			}

			public int GetAnalogDeadZoneLeft()
			{
				return BfbxEvZUywqqrNNbjNlcgXWxNKt;
			}

			public int GetAnalogDeadZoneRight()
			{
				return yCenbyuEUkDyntWjnbtrhRasjfDk;
			}

			public float GetTouchPixelDensity()
			{
				return yZOhzVlZbHbfUbUbxmpzpbMWCiof;
			}

			public int GetTouchpadResolutionX()
			{
				return VFtLwwVjNGdknsHlqAtMfwwjWrth;
			}

			public int GetTouchpadResolutionY()
			{
				return DJxQgyEXUuRCYzhKxgLueuMuWCiD;
			}

			public int GetTouchCount()
			{
				return hZblgvgQdThLguRvJjZDNfQBMgH;
			}

			public int GetTouchId(int P_0)
			{
				if (P_0 >= 0)
				{
					if (P_0 < zUntMgqBZVybGrvPQOncmfSIECd.sItfPCEBAPpHkLQSrZRmeYRJSDA)
					{
						switch (P_0)
						{
						case 0:
							break;
						case 1:
							return VTcWdDkvirwyvJPkAaLCWbwExgA;
						default:
							return -1;
						}
						goto IL_004b;
					}
					while (true)
					{
						switch (-666932864 ^ -666932863)
						{
						case 2:
							break;
						case 1:
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
				return AuKAFeocGtgPngyQicFYcXWhpvLF;
			}

			public bool GetTouchPositionAbsByIndex(int P_0, out Vector2 P_1)
			{
				int num;
				if (P_0 >= 0 && P_0 < zUntMgqBZVybGrvPQOncmfSIECd.sItfPCEBAPpHkLQSrZRmeYRJSDA)
				{
					if (!IsTouchingByIndex(P_0))
					{
						goto IL_001b;
					}
					switch (P_0)
					{
					case 1:
						goto IL_006c;
					case 0:
						goto IL_0081;
					}
					num = 471581483;
					goto IL_0020;
				}
				goto IL_0045;
				IL_006c:
				P_1 = iQsnudlniJgDaCOzUXddrIcJchcX;
				goto IL_009f;
				IL_0081:
				P_1 = mJonoTzwsGtdcIbKaZVsFBSFkAd;
				goto IL_009f;
				IL_009f:
				return true;
				IL_0045:
				P_1 = default(Vector2);
				return false;
				IL_001b:
				num = 471581482;
				goto IL_0020;
				IL_0020:
				while (true)
				{
					switch (num ^ 0x1C1BC32E)
					{
					case 0:
						break;
					case 4:
						goto IL_0045;
					case 5:
						num = 471581485;
						continue;
					case 1:
						goto IL_006c;
					case 2:
						goto IL_0081;
					default:
						P_1 = default(Vector2);
						return false;
					}
					break;
				}
				goto IL_001b;
			}

			public bool GetTouchPositionAbsByTouchId(int P_0, out Vector2 P_1)
			{
				int num = pOzlvjYYShJVjQDzLlCpgDezfQ(P_0);
				while (true)
				{
					int num2 = 857556167;
					while (true)
					{
						switch (num2 ^ 0x331D44C6)
						{
						case 0:
							break;
						case 1:
							if (num < 0)
							{
								goto IL_002a;
							}
							return GetTouchPositionAbsByIndex(num, out P_1);
						default:
							P_1 = default(Vector2);
							return false;
						}
						break;
						IL_002a:
						num2 = 857556164;
					}
				}
			}

			public bool GetTouchPositionByIndex(int P_0, out Vector2 P_1)
			{
				if (P_0 >= 0)
				{
					while (true)
					{
						int num = 533148524;
						while (true)
						{
							switch (num ^ 0x1FC73369)
							{
							case 0:
								break;
							case 7:
								P_1 = new Vector2(mJonoTzwsGtdcIbKaZVsFBSFkAd.x, mJonoTzwsGtdcIbKaZVsFBSFkAd.y);
								goto IL_0101;
							case 3:
								goto IL_0069;
							case 2:
								num = 533148520;
								continue;
							case 5:
								goto IL_00a0;
							case 6:
								goto end_IL_0007;
							case 4:
								if (IsTouchingByIndex(P_0))
								{
									switch (P_0)
									{
									case 0:
										break;
									case 1:
										goto IL_0069;
									default:
										goto IL_00db;
									}
									goto case 7;
								}
								num = 533148527;
								continue;
							default:
								{
									P_1 = default(Vector2);
									return false;
								}
								IL_0101:
								P_1.x /= VFtLwwVjNGdknsHlqAtMfwwjWrth;
								P_1.y /= DJxQgyEXUuRCYzhKxgLueuMuWCiD;
								return true;
								IL_00db:
								num = 533148523;
								continue;
								IL_0069:
								P_1 = new Vector2(iQsnudlniJgDaCOzUXddrIcJchcX.x, iQsnudlniJgDaCOzUXddrIcJchcX.y);
								goto IL_0101;
							}
							break;
							IL_00a0:
							int num2;
							if (P_0 >= zUntMgqBZVybGrvPQOncmfSIECd.sItfPCEBAPpHkLQSrZRmeYRJSDA)
							{
								num = 533148527;
								num2 = num;
							}
							else
							{
								num = 533148525;
								num2 = num;
							}
						}
						continue;
						end_IL_0007:
						break;
					}
				}
				P_1 = default(Vector2);
				return false;
			}

			public bool GetTouchPositionByTouchId(int P_0, out Vector2 P_1)
			{
				int num = pOzlvjYYShJVjQDzLlCpgDezfQ(P_0);
				if (num < 0)
				{
					P_1 = default(Vector2);
					return false;
				}
				return GetTouchPositionByIndex(num, out P_1);
			}

			public bool IsTouchingByIndex(int P_0)
			{
				if (P_0 < 0 || P_0 >= zUntMgqBZVybGrvPQOncmfSIECd.sItfPCEBAPpHkLQSrZRmeYRJSDA)
				{
					return false;
				}
				return P_0 < hZblgvgQdThLguRvJjZDNfQBMgH;
			}

			public bool IsTouchingByTouchId(int P_0)
			{
				if (P_0 < 0)
				{
					return false;
				}
				int num = pOzlvjYYShJVjQDzLlCpgDezfQ(P_0);
				return num >= 0;
			}

			protected override void UpdateElementValues()
			{
				base.UpdateElementValues();
				int touch0x;
				int touch0y;
				int touch1x;
				int touch1y;
				UnityTools.externalTools.PS4Input_GetLastTouchData(VUcYiZtcJRatratRXOokIFfcdNSg, out hZblgvgQdThLguRvJjZDNfQBMgH, out touch0x, out touch0y, out AuKAFeocGtgPngyQicFYcXWhpvLF, out touch1x, out touch1y, out VTcWdDkvirwyvJPkAaLCWbwExgA);
				mJonoTzwsGtdcIbKaZVsFBSFkAd.x = touch0x;
				mJonoTzwsGtdcIbKaZVsFBSFkAd.y = DJxQgyEXUuRCYzhKxgLueuMuWCiD - touch0y;
				iQsnudlniJgDaCOzUXddrIcJchcX.x = touch1x;
				iQsnudlniJgDaCOzUXddrIcJchcX.y = DJxQgyEXUuRCYzhKxgLueuMuWCiD - touch1y;
			}

			private void IFpGKVXFaghSybCWgGXRHKOZiWN()
			{
				IExternalTools externalTools = UnityTools.externalTools;
				int connectionType;
				externalTools.PS4Input_GetPadControllerInformation(VUcYiZtcJRatratRXOokIFfcdNSg, out yZOhzVlZbHbfUbUbxmpzpbMWCiof, out VFtLwwVjNGdknsHlqAtMfwwjWrth, out DJxQgyEXUuRCYzhKxgLueuMuWCiD, out BfbxEvZUywqqrNNbjNlcgXWxNKt, out yCenbyuEUkDyntWjnbtrhRasjfDk, out connectionType);
				tJkOioOxaiWoOTmQCmyRwTXqZvS = (jEDsQXPVXYSSIJjHktJadJKsHNg)connectionType;
				externalTools.PS4Input_PadResetOrientation(VUcYiZtcJRatratRXOokIFfcdNSg);
			}

			private int pOzlvjYYShJVjQDzLlCpgDezfQ(int P_0)
			{
				if (P_0 < 0)
				{
					goto IL_0004;
				}
				int num;
				if (hZblgvgQdThLguRvJjZDNfQBMgH > 0)
				{
					num = 28666820;
					goto IL_0009;
				}
				goto IL_0047;
				IL_003c:
				if (AuKAFeocGtgPngyQicFYcXWhpvLF == P_0)
				{
					return 0;
				}
				goto IL_0047;
				IL_0069:
				return -1;
				IL_0004:
				num = 28666818;
				goto IL_0009;
				IL_0009:
				while (true)
				{
					switch (num ^ 0x1B56BC0)
					{
					case 0:
						break;
					case 2:
						return -1;
					case 4:
						goto IL_003c;
					case 3:
						goto IL_0057;
					default:
						return 1;
					}
					break;
					IL_0057:
					if (VTcWdDkvirwyvJPkAaLCWbwExgA == P_0)
					{
						num = 28666817;
						continue;
					}
					goto IL_0069;
				}
				goto IL_0004;
				IL_0047:
				if (hZblgvgQdThLguRvJjZDNfQBMgH > 1)
				{
					num = 28666819;
					goto IL_0009;
				}
				goto IL_0069;
			}
		}

		private abstract class hycqpwYCiqXRfRcaBeNXkYfLOVI : VpzBxZLGxbVcbByijUsaovouNIq
		{
			protected hycqpwYCiqXRfRcaBeNXkYfLOVI(ControllerType controllerType, string name, int playerId, int unityJoystickId, int handle, ZDMAdSSzCNOfLXFZcDUuBtiHxDsr capabilities)
				: base(controllerType, name, playerId, unityJoystickId, handle, capabilities)
			{
			}

			public static hycqpwYCiqXRfRcaBeNXkYfLOVI rHXUBQoqejbkONabpWgwEqatBJ(int P_0, int P_1, int P_2)
			{
				ControllerType controllerType;
				if (!VpzBxZLGxbVcbByijUsaovouNIq.YcuIRbcfCuJAoeNHmNkkzyvzmjK(P_0, out controllerType))
				{
					return null;
				}
				return rHXUBQoqejbkONabpWgwEqatBJ(controllerType, P_1, P_2);
			}

			public new static hycqpwYCiqXRfRcaBeNXkYfLOVI rHXUBQoqejbkONabpWgwEqatBJ(ControllerType P_0, int P_1, int P_2)
			{
				int unityJoystickId = P_1 + 13;
				while (true)
				{
					switch (0x654B63EC ^ 0x654B63ED)
					{
					case 2:
						continue;
					case 1:
						switch (P_0)
						{
						case ControllerType.Unknown:
						case ControllerType.Gamepad:
						case ControllerType.Move:
							break;
						case ControllerType.Drum:
							return new WVieeADqxtUGWogNuuYfjqLvqDc("Drums " + (P_1 + 1), P_1, unityJoystickId, P_2);
						case ControllerType.FlightStick:
							return new IRHAXNnuefsSqDQxzfNrWNvZARR("Flight Stick " + (P_1 + 1), P_1, unityJoystickId, P_2);
						case ControllerType.Guitar:
							return new EjhePPxLYheWZeQhGkLtjvmGSzNJ("Guitar " + (P_1 + 1), P_1, unityJoystickId, P_2);
						case ControllerType.SteeringWheel:
							return new dGAZTiXaweJXKBjtRhrWWaHCZGr("Steering Wheel " + (P_1 + 1), P_1, unityJoystickId, P_2);
						case ControllerType.DjTurntable:
						case ControllerType.DanceMat:
						case ControllerType.Navigation:
						case ControllerType.Stick:
						case ControllerType.Gun:
							return null;
						default:
							throw new NotImplementedException();
						}
						break;
					}
					break;
				}
				return null;
			}
		}

		private sealed class dGAZTiXaweJXKBjtRhrWWaHCZGr : hycqpwYCiqXRfRcaBeNXkYfLOVI
		{
			private const int XOnWiKThBydhDsxQmELHDhRZdPqb = 13;

			private const int VDaLjZYdsRIqheXEANPwCBhYDPo = 14;

			private const float XkocvynAJGDJqmSGQqiUMXQKoZA = 0.05f;

			private const int PyZsPQUJwDInSkCybitITthgrMK = 2;

			private const int jIjGSOJaGZVCFVspxYiTawrnGznD = 0;

			public dGAZTiXaweJXKBjtRhrWWaHCZGr(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.SteeringWheel, name, playerId, unityJoystickId, handle, new ZDMAdSSzCNOfLXFZcDUuBtiHxDsr(13, 14, 0.05f, 2, 0))
			{
				base.extension = new PS4ControllerExtension(this);
			}

			protected override void UpdateElementValues()
			{
				base.UpdateElementValues();
				int joystickId = default(int);
				IList<Axis> axes = default(IList<Axis>);
				while (true)
				{
					int num = -1045162933;
					while (true)
					{
						switch (num ^ -1045162934)
						{
						case 3:
							break;
						case 1:
							joystickId = yKqGDhHrAETHXtPwAnMaiBpAiBkC + 1;
							axes = base.Axes;
							axes[6].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 10);
							axes[7].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 11);
							axes[8].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 12);
							axes[9].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 13);
							num = -1045162934;
							continue;
						case 0:
							axes[10].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 14);
							axes[11].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 15);
							num = -1045162936;
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

		private sealed class EjhePPxLYheWZeQhGkLtjvmGSzNJ : hycqpwYCiqXRfRcaBeNXkYfLOVI
		{
			private const int XOnWiKThBydhDsxQmELHDhRZdPqb = 11;

			private const int VDaLjZYdsRIqheXEANPwCBhYDPo = 14;

			private const float XkocvynAJGDJqmSGQqiUMXQKoZA = 0.05f;

			private const int PyZsPQUJwDInSkCybitITthgrMK = 2;

			private const int jIjGSOJaGZVCFVspxYiTawrnGznD = 0;

			public EjhePPxLYheWZeQhGkLtjvmGSzNJ(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Guitar, name, playerId, unityJoystickId, handle, new ZDMAdSSzCNOfLXFZcDUuBtiHxDsr(11, 14, 0.05f, 2, 0))
			{
				base.extension = new PS4ControllerExtension(this);
			}

			protected override void UpdateElementValues()
			{
				base.UpdateElementValues();
				int joystickId = default(int);
				IList<Axis> axes = default(IList<Axis>);
				while (true)
				{
					int num = 1751480308;
					while (true)
					{
						switch (num ^ 0x686577F0)
						{
						case 2:
							break;
						default:
							return;
						case 4:
							joystickId = yKqGDhHrAETHXtPwAnMaiBpAiBkC + 1;
							axes = base.Axes;
							axes[6].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 10);
							axes[7].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 11);
							num = 1751480304;
							continue;
						case 0:
							axes[8].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 12);
							num = 1751480307;
							continue;
						case 3:
							axes[9].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 13);
							axes[10].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 14);
							num = 1751480305;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		private sealed class WVieeADqxtUGWogNuuYfjqLvqDc : hycqpwYCiqXRfRcaBeNXkYfLOVI
		{
			private const int XOnWiKThBydhDsxQmELHDhRZdPqb = 13;

			private const int VDaLjZYdsRIqheXEANPwCBhYDPo = 14;

			private const float XkocvynAJGDJqmSGQqiUMXQKoZA = 0.05f;

			private const int PyZsPQUJwDInSkCybitITthgrMK = 2;

			private const int jIjGSOJaGZVCFVspxYiTawrnGznD = 0;

			public WVieeADqxtUGWogNuuYfjqLvqDc(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.Drum, name, playerId, unityJoystickId, handle, new ZDMAdSSzCNOfLXFZcDUuBtiHxDsr(13, 14, 0.05f, 2, 0))
			{
				while (true)
				{
					int num = 1358231544;
					while (true)
					{
						switch (num ^ 0x50F4F7F9)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_003a;
						case 2:
							return;
						}
						break;
						IL_003a:
						base.extension = new PS4ControllerExtension(this);
						num = 1358231547;
					}
				}
			}

			protected override void UpdateElementValues()
			{
				base.UpdateElementValues();
				int joystickId = default(int);
				IList<Axis> axes = default(IList<Axis>);
				while (true)
				{
					int num = 2052268276;
					while (true)
					{
						switch (num ^ 0x7A5320F6)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							joystickId = yKqGDhHrAETHXtPwAnMaiBpAiBkC + 1;
							axes = base.Axes;
							axes[6].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 10);
							axes[7].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 11);
							num = 2052268279;
							continue;
						case 1:
							axes[8].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 12);
							axes[9].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 13);
							num = 2052268277;
							continue;
						case 3:
							axes[10].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 14);
							axes[11].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 15);
							axes[12].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 16);
							num = 2052268274;
							continue;
						case 4:
							return;
						}
						break;
					}
				}
			}
		}

		private sealed class IRHAXNnuefsSqDQxzfNrWNvZARR : hycqpwYCiqXRfRcaBeNXkYfLOVI
		{
			private const int XOnWiKThBydhDsxQmELHDhRZdPqb = 16;

			private const int VDaLjZYdsRIqheXEANPwCBhYDPo = 14;

			private const float XkocvynAJGDJqmSGQqiUMXQKoZA = 0.05f;

			private const int PyZsPQUJwDInSkCybitITthgrMK = 2;

			private const int jIjGSOJaGZVCFVspxYiTawrnGznD = 0;

			public IRHAXNnuefsSqDQxzfNrWNvZARR(string name, int playerId, int unityJoystickId, int handle)
				: base(ControllerType.FlightStick, name, playerId, unityJoystickId, handle, new ZDMAdSSzCNOfLXFZcDUuBtiHxDsr(16, 14, 0.05f, 2, 0))
			{
				base.extension = new PS4ControllerExtension(this);
			}

			protected override void UpdateElementValues()
			{
				base.UpdateElementValues();
				int joystickId = yKqGDhHrAETHXtPwAnMaiBpAiBkC + 1;
				IList<Axis> axes = base.Axes;
				axes[6].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 10);
				axes[7].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 11);
				axes[8].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 12);
				while (true)
				{
					int num = 201131472;
					while (true)
					{
						switch (num ^ 0xBFD05D3)
						{
						case 2:
							break;
						case 3:
							axes[9].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 13);
							axes[10].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 14);
							num = 201131475;
							continue;
						case 0:
							axes[11].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 15);
							num = 201131478;
							continue;
						case 1:
							axes[14].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 18);
							num = 201131479;
							continue;
						case 5:
							axes[12].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 16);
							axes[13].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 17);
							num = 201131474;
							continue;
						default:
							axes[15].value = UnityInputHelper.GetJoystickAxisValueByJoystickId(joystickId, 19);
							return;
						}
						break;
					}
				}
			}
		}

		private IIqKWhcwYfTkjFaCdbDyqeTmfDbE jypeRXxDbrSLODKgRjuVSTbRIme;

		private bool NbDcgOYldhSAfOptPAqdJXqrjpeW = true;

		private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

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
				return NbDcgOYldhSAfOptPAqdJXqrjpeW;
			}
			set
			{
				NbDcgOYldhSAfOptPAqdJXqrjpeW = nbDcgOYldhSAfOptPAqdJXqrjpeW;
			}
		}

		public PS4InputSource()
			: base(22)
		{
			ReInput.controllerAssigner = this;
			jypeRXxDbrSLODKgRjuVSTbRIme = new IIqKWhcwYfTkjFaCdbDyqeTmfDbE(4, true);
			jypeRXxDbrSLODKgRjuVSTbRIme.ControllerConnectedEvent += xqQYaEknfwtcNTyjLeynHwRqaCO;
			jypeRXxDbrSLODKgRjuVSTbRIme.ControllerDisconnectedEvent += wlVEyxiJjyatqeMouiJAZIyFrhI;
		}

		public override void Update()
		{
			jypeRXxDbrSLODKgRjuVSTbRIme.rdEJYvExbWYUXSDuseVgzyXPBhA();
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
				int num2 = 79667224;
				goto IL_0047;
				IL_0047:
				switch (num2 ^ 0x4BFA019)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					continue;
				case 1:
					return;
				}
				goto IL_0042;
				IL_0042:
				num2 = 79667227;
				goto IL_0047;
			}
		}

		private static int YYWgxQiheOJUmvpASkBeKlHfbAth(int P_0)
		{
			if (P_0 >= 13)
			{
				return P_0 - 13;
			}
			return P_0 - 1;
		}

		private void xqQYaEknfwtcNTyjLeynHwRqaCO(IIqKWhcwYfTkjFaCdbDyqeTmfDbE.CxpfePEvjrPvXzDxRKhzJuSoUUl P_0)
		{
			VpzBxZLGxbVcbByijUsaovouNIq vpzBxZLGxbVcbByijUsaovouNIq;
			if (P_0.vgzDviaSvJLFelnUoFPhPTYvfRj)
			{
				vpzBxZLGxbVcbByijUsaovouNIq = VpzBxZLGxbVcbByijUsaovouNIq.rHXUBQoqejbkONabpWgwEqatBJ(true, P_0.UpbvuofvMXACqnIAqdAZtGTUAmZF, P_0.DERQvNdAIfJFDnFpDBYSBQlXxSHC, P_0.pjAxoGjQdUQZKLDflwZaqfSLVAC);
				if (vpzBxZLGxbVcbByijUsaovouNIq != null)
				{
					goto IL_0072;
				}
				while (true)
				{
					switch (-1191939351 ^ -1191939352)
					{
					case 0:
						break;
					case 1:
						return;
					case 3:
						goto end_IL_0028;
					default:
						goto IL_0072;
					}
					continue;
					end_IL_0028:
					break;
				}
			}
			vpzBxZLGxbVcbByijUsaovouNIq = VpzBxZLGxbVcbByijUsaovouNIq.rHXUBQoqejbkONabpWgwEqatBJ(VpzBxZLGxbVcbByijUsaovouNIq.ControllerType.Gamepad, P_0.DERQvNdAIfJFDnFpDBYSBQlXxSHC, P_0.pjAxoGjQdUQZKLDflwZaqfSLVAC);
			if (vpzBxZLGxbVcbByijUsaovouNIq == null)
			{
				return;
			}
			goto IL_0072;
			IL_0072:
			CXjdveDydLefWYZxjYUBGvZckJJb(vpzBxZLGxbVcbByijUsaovouNIq);
		}

		private void CXjdveDydLefWYZxjYUBGvZckJJb(VpzBxZLGxbVcbByijUsaovouNIq P_0)
		{
			AddJoystick(P_0);
			P_0.Connect();
			OnJoystickConnected();
		}

		private void wlVEyxiJjyatqeMouiJAZIyFrhI(IIqKWhcwYfTkjFaCdbDyqeTmfDbE.rMXeVyQRoAZEBwVRuFdxJcMiwcS P_0)
		{
			IList<Joystick> joysticks = GetJoysticks();
			int count = default(int);
			VpzBxZLGxbVcbByijUsaovouNIq vpzBxZLGxbVcbByijUsaovouNIq = default(VpzBxZLGxbVcbByijUsaovouNIq);
			int num2 = default(int);
			while (true)
			{
				int num = 1351937137;
				while (true)
				{
					switch (num ^ 0x5094EC77)
					{
					case 7:
						break;
					case 6:
						count = joysticks.Count;
						num = 1351937143;
						continue;
					case 5:
						vpzBxZLGxbVcbByijUsaovouNIq = joysticks[num2] as VpzBxZLGxbVcbByijUsaovouNIq;
						if (P_0.vgzDviaSvJLFelnUoFPhPTYvfRj == vpzBxZLGxbVcbByijUsaovouNIq.isSpecialController)
						{
							int num3;
							if (vpzBxZLGxbVcbByijUsaovouNIq.playerId != P_0.DERQvNdAIfJFDnFpDBYSBQlXxSHC)
							{
								num = 1351937142;
								num3 = num;
							}
							else
							{
								num = 1351937140;
								num3 = num;
							}
							continue;
						}
						goto case 1;
					case 4:
						num = 1351937141;
						continue;
					case 1:
						num2--;
						num = 1351937141;
						continue;
					case 0:
						num2 = count - 1;
						num = 1351937139;
						continue;
					case 3:
						if (vpzBxZLGxbVcbByijUsaovouNIq.handle == P_0.pjAxoGjQdUQZKLDflwZaqfSLVAC)
						{
							vpzBxZLGxbVcbByijUsaovouNIq.Disconnect();
							RemoveJoystick(vpzBxZLGxbVcbByijUsaovouNIq);
							num = 1351937142;
							continue;
						}
						goto case 1;
					default:
						if (num2 < 0)
						{
							OnJoystickDisconnected();
							return;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		bool IControllerAssigner.CanHandleAssignment(ControllerType P_0, Rewired.Controller P_1)
		{
			if (!NbDcgOYldhSAfOptPAqdJXqrjpeW)
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
			int num3 = default(int);
			while (true)
			{
				Rewired.Joystick joystick = P_1 as Rewired.Joystick;
				int num;
				int num2;
				if (!ReInput.controllers.IsJoystickAssigned(joystick))
				{
					num = -631226463;
					num2 = num;
				}
				else
				{
					num = -631226458;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -631226457)
					{
					case 4:
						num = -631226459;
						continue;
					case 5:
						if (ReInput.configVars.assignJoysticksToPlayingPlayersOnly && !ReInput.players.GetPlayer(num3).isPlaying)
						{
							return;
						}
						goto default;
					case 6:
						num3 = YYWgxQiheOJUmvpASkBeKlHfbAth(joystick.unityId);
						num = -631226464;
						continue;
					case 1:
						return;
					case 2:
						break;
					case 7:
						if (num3 >= ReInput.players.playerCount)
						{
							return;
						}
						goto case 3;
					case 3:
						if (ReInput.players.GetPlayer(num3) == null)
						{
							return;
						}
						goto case 5;
					default:
						ReInput.players.GetPlayer(num3).controllers.AddController(joystick, true);
						return;
					}
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
			if (QQqHByfwytAJSuMZiCPjJlZYHKG)
			{
				return;
			}
			while (true)
			{
				int num = 464162244;
				while (true)
				{
					switch (num ^ 0x1BAA8DC6)
					{
					case 0:
						num = 464162245;
						continue;
					default:
						return;
					case 3:
						break;
					case 2:
						QQqHByfwytAJSuMZiCPjJlZYHKG = true;
						num = 464162247;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}
	}
}
