using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using Rewired;
using Rewired.Data;
using Rewired.Utils;
using UnityEngine;

internal static class leHaHiGKLRfwikIkRPeWBAYNSTq
{
	private static class OWlzTUhdzFfXThjsUbZSbKwGqXn
	{
		private static class yODWqcObpFaKxqyKVUPBRiJcnbB
		{
			public static byte[] mSFxroGjTJegHnGSECLkIjZvyor(TextAsset P_0, long P_1)
			{
				if (P_0 == null)
				{
					return null;
				}
				byte[] bytes = P_0.bytes;
				if (bytes.Length == 0)
				{
					return null;
				}
				return mSFxroGjTJegHnGSECLkIjZvyor(bytes, P_1);
			}

			public static byte[] mSFxroGjTJegHnGSECLkIjZvyor(byte[] P_0, long P_1)
			{
				byte[] bytes = BitConverter.GetBytes(P_1);
				ICryptoTransform transform = default(ICryptoTransform);
				int num3 = default(int);
				while (true)
				{
					int num = 2064586627;
					while (true)
					{
						switch (num ^ 0x7B0F1781)
						{
						case 0:
							break;
						case 2:
							goto IL_0025;
						default:
						{
							byte[] array = null;
							MemoryStream memoryStream = new MemoryStream(P_0);
							try
							{
								MemoryStream memoryStream2 = new MemoryStream();
								try
								{
									using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Read))
									{
										byte[] array2 = new byte[4096];
										while (true)
										{
											IL_006f:
											int num2 = 2064586624;
											while (true)
											{
												switch (num2 ^ 0x7B0F1781)
												{
												case 0:
													break;
												case 1:
													num3 = cryptoStream.Read(array2, 0, array2.Length);
													num2 = 2064586627;
													continue;
												case 3:
													memoryStream2.Write(array2, 0, num3);
													num3 = cryptoStream.Read(array2, 0, array2.Length);
													num2 = 2064586627;
													continue;
												default:
													if (num3 <= 0)
													{
														cryptoStream.Flush();
														goto end_IL_0074;
													}
													goto case 3;
												}
												goto IL_006f;
												continue;
												end_IL_0074:
												break;
											}
											break;
										}
									}
									return memoryStream2.ToArray();
								}
								finally
								{
									if (memoryStream2 != null)
									{
										while (true)
										{
											IL_00f3:
											int num4 = 2064586624;
											while (true)
											{
												switch (num4 ^ 0x7B0F1781)
												{
												case 2:
													break;
												default:
													goto end_IL_00f8;
												case 1:
													goto IL_0111;
												case 0:
													goto end_IL_00f8;
												}
												goto IL_00f3;
												IL_0111:
												((IDisposable)memoryStream2).Dispose();
												num4 = 2064586625;
												continue;
												end_IL_00f8:
												break;
											}
											break;
										}
									}
								}
							}
							finally
							{
								if (memoryStream != null)
								{
									while (true)
									{
										IL_0126:
										int num5 = 2064586627;
										while (true)
										{
											switch (num5 ^ 0x7B0F1781)
											{
											case 0:
												break;
											default:
												goto end_IL_012b;
											case 2:
												goto IL_0144;
											case 1:
												goto end_IL_012b;
											}
											goto IL_0126;
											IL_0144:
											((IDisposable)memoryStream).Dispose();
											num5 = 2064586624;
											continue;
											end_IL_012b:
											break;
										}
										break;
									}
								}
							}
						}
						}
						break;
						IL_0025:
						DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
						dESCryptoServiceProvider.Key = bytes;
						dESCryptoServiceProvider.IV = bytes;
						transform = dESCryptoServiceProvider.CreateDecryptor();
						num = 2064586624;
					}
				}
			}

			private static byte[] mSFxroGjTJegHnGSECLkIjZvyor(byte[] P_0, string P_1)
			{
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				ICryptoTransform transform = default(ICryptoTransform);
				int num3 = default(int);
				while (true)
				{
					int num = -248522182;
					while (true)
					{
						switch (num ^ -248522181)
						{
						case 0:
							break;
						case 1:
							dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(P_1);
							dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(P_1);
							transform = dESCryptoServiceProvider.CreateDecryptor();
							num = -248522184;
							continue;
						case 3:
						{
							num3 = 0;
							byte[] array = null;
							num = -248522183;
							continue;
						}
						default:
						{
							using (Stream stream = mvZAeDLgMRScgdDhmgxjdzptFSM(P_1, Encoding.ASCII))
							{
								CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Read);
								try
								{
									byte[] array = new byte[cryptoStream.Length];
									while (true)
									{
										int num2 = -248522182;
										while (true)
										{
											switch (num2 ^ -248522181)
											{
											case 2:
												break;
											case 1:
												num2 = -248522184;
												continue;
											case 0:
												num3 += 4096;
												num2 = -248522184;
												continue;
											default:
												if (cryptoStream.Read(array, num3, 4096) <= 0)
												{
													return array;
												}
												goto case 0;
											}
											break;
										}
									}
								}
								finally
								{
									if (cryptoStream != null)
									{
										while (true)
										{
											IL_00d8:
											int num4 = -248522182;
											while (true)
											{
												switch (num4 ^ -248522181)
												{
												case 2:
													break;
												default:
													goto end_IL_00dd;
												case 1:
													goto IL_00f6;
												case 0:
													goto end_IL_00dd;
												}
												goto IL_00d8;
												IL_00f6:
												((IDisposable)cryptoStream).Dispose();
												num4 = -248522181;
												continue;
												end_IL_00dd:
												break;
											}
											break;
										}
									}
								}
							}
						}
						}
						break;
					}
				}
			}

			public static Stream mvZAeDLgMRScgdDhmgxjdzptFSM(string P_0, Encoding P_1)
			{
				MemoryStream memoryStream = new MemoryStream();
				StreamWriter streamWriter = default(StreamWriter);
				while (true)
				{
					int num = -855437682;
					while (true)
					{
						switch (num ^ -855437681)
						{
						case 0:
							break;
						case 1:
							goto IL_0024;
						default:
							streamWriter.Write(P_0);
							streamWriter.Flush();
							memoryStream.Position = 0L;
							return memoryStream;
						}
						break;
						IL_0024:
						streamWriter = new StreamWriter(memoryStream, P_1);
						num = -855437683;
					}
				}
			}
		}

		private const string oMFIiCMbxmVCfXFonAzujDwFkTT = "Rewired.Decrypter.bin";

		public static List<Assembly> xRQtgfnRQZCPVzHQwhxTuDbVfvR(List<TextAsset> P_0, bool P_1, string P_2, long P_3)
		{
			try
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				byte[] array = null;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (Stream stream = executingAssembly.GetManifestResourceStream("Rewired.Decrypter.bin"))
					{
						gpwBdnGDVeMuGFPYIjuIkYXDtdWo(stream, memoryStream);
						array = memoryStream.ToArray();
					}
				}
				byte[] rawAssembly = yODWqcObpFaKxqyKVUPBRiJcnbB.mSFxroGjTJegHnGSECLkIjZvyor(array, P_3);
				Assembly assembly = Assembly.Load(rawAssembly);
				long num = DmoYoWsFrOSfrEFkbRQpnhmkFbwg(assembly, P_3);
				return xRQtgfnRQZCPVzHQwhxTuDbVfvR(P_0, P_1, num);
			}
			catch
			{
				return null;
			}
		}

		private static void gpwBdnGDVeMuGFPYIjuIkYXDtdWo(Stream P_0, Stream P_1)
		{
			byte[] array = new byte[32768];
			int count;
			while ((count = P_0.Read(array, 0, array.Length)) > 0)
			{
				while (true)
				{
					P_1.Write(array, 0, count);
					int num = 2111654112;
					while (true)
					{
						switch (num ^ 0x7DDD48E2)
						{
						case 0:
							num = 2111654115;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002b;
						}
						break;
					}
					continue;
					end_IL_002b:
					break;
				}
			}
		}

		private static long DmoYoWsFrOSfrEFkbRQpnhmkFbwg(Assembly P_0, long P_1)
		{
			try
			{
				Type type = P_0.GetType("Rewired.Security.KeyDecrypter");
				return (long)type.InvokeMember("Decrypt", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, null, new object[2] { "MU>SOe2)EH[T<)gNSVyMG.\\gO|q>{]!h&,4A(ty{QbSXT@j6V<n^],cupp3t5[)qL?B&SL:fv^8s.YLA,?qZ98A0,wPS%~j>'rXVep66'&6<IxB[mY!L}b@:LRB?!)*<lV%Gn$5K'UF<+,El)OIYzM[+2FElC1AZ^?nU,k?x~~g8eGTUim8aJm.Kv|8qEDn|xI&4mU?^Y!L?bOZ|SD7b};Ya4^?/kOE93S:)6h:!0JX+?88$l8X+9#km1$zV:H\\AlFmPmmJ44]4gS{sk3+e/+Cx1^4b,P^agN^P_e{k\\Z@SVs7,w)b]Ll^/ufmPr#wEt;viv'&|a1w8.~/CKw%RE,!O{RlruVDPxh>3;2;NySeW*Niu%zCs^<KplfF>@JWG47z3*JJ>xHQ`!a*9*0uL4Z`'?o\\|)X].UMa4649kDQozevQcHBMg.+l'0:I+z{JYf5VxhhU}:Ft62SGEs}_Ufx0o$wxoe<AF8Y_0fMwlSu3]oqN|pUEPXQ|(A6%],*s/e+/2mR|&G>A|J18!0&jvrv)4P%Lr2&(i*77v!?E1EJ),)(SPuY7lfi5zm&s!tp_U$hj6WK8jL`L)cEFw4Ukg^9zR`fO>|cg3:]GmkW)Kc^K`YAM(`KxI%PG;?H\\f[y[p^mChqGT#_&(/Cl$}/4mPVtCRMpsBtggTl$$9&w7]i1?ncp;JDk9cZhyzDPXg#7[b#[][bZ@$4$,mD#Si'1$%bZkxw]Fn#tf<14SQPEN,lmL%:<8f1bMax{/5T`nF$f!1iOJ4gA\\7&9ZU3zl/hGz'`>Tu)CwL|hZjYBgT<kOQA't[24~&eRFX89Rw8H'gWOwShCxqC|wy1>Sqi]#GfO:!SRwsLFJR(0)p:3R[hk4>v*]VPwpWZ?f;V5Jn4j`^UxSaKL,B6tFK0vqe'xY#uo3PL\\MkkY%;>n83GKXLwz~t,orJx71sHIH}JlX!$Pz'[Ok\\*AKB&E5J>jqOA~^1`7]n&,[42PBaq]:Z!+zG%kx%5C\\F[BT;}a4}UX#%eEm0C&A+@x0&{kl`!YW(97S!~v7KF*0@44x8x4bR\\.G<1#'[#y4pkSx^,\\qf#YEy*CFCg$u?nZ*fAn`t6<r?H!:;$F3R61h&$.3~8AP\\F,QEsJ@|.h,o#YW5e7$i8to{P%BO%rXKqZ\\ut<hY6RE7YM|v#]NnWB'BMYUsr[T~LC&(Y?)xVbl`T:^)<p{lajJUghu<C`*){`fK5D>jL$/vv[g}IoFvFD`83E4<\\3S'DQrX<!w8a+cYZWRmHtOscY(DT&2w`}WBrGf2$<\\.'1;'g/MKLBOH9;1f|*2T[wnQL^e[lROs2tur?W!)U/1|u$\\j^W1I1xA]i8TGkGU5x(`iD[#<>woZFr:HTmM)Tfh+<8uh(fi_rDU$x[`ZU%*qr?~2^8Hp]pQczbLGuy~b/qrG&#j*I;5{yUH]%/'j>iq{ya+08xrVC1FsIx?&c.8)6ZTux<66!,}l(XZj^Db_vH+~U0/;'DmIJMs&V2/nRD}Zqb,K`2CscXo$8EO|xr<]xz,9$h{)T*U_4J}Zzao*7w;}kp7)%}Of1'x.&kaj'%bTJXu;<Zfg!]`<*]4i$DYqZH^9RMo`+{stC'i[x`PKPPGou6xcr4Cz0NmXS`)Y@7S}npvE&*M|QOknF!PhUk!i,)5Zh0^7~x%#r8Y.'U^)_TAQ8QG,g\\#b%H7#'#.nP3DeuNy7G>s)f_:.G6.H2XBWDa7{$EK([&b^2|yc<h}om,@tCZ#K>;)4x`xM.@CsY$#S^,*e%0Ml$Y>m0CE6D:?8K}_Ml\\shxlAF&S:_ikAEmJI5|W<<o?fO9eIRN8~Kw:[tvOX3LK*C[^;J^Y[Vaw9QAA]n:`s,@/#F1|4ge@.4Z}vYp*QXuMEUmL.|aB}M?'5eEtYfpc!VW;#_J:[l.}TLTk|XE_&E0Pf%$\\##rsp$+g$fJWb8A$hpe90E\\]u3Mq9F/?.Ex<#^]6+j)qB~oLsn//_?F7.``BEUW}eXkBc+m.?m6JF2(bo&pmFS_{42J+T9%pRxm`3K9./LYao~3a4jY&HHj?/k,l<:0sN(4vY:8J#CVeG(n_tuH)`i^#,c&0}P*iywKAU|U}I`w9\\[`xjt7Sf\\5iO5pf}*><$n3Mv0zLWFj7Yzwej[5p_L2yonxNY5Nc`;&SFWPXp1Y\\3[|}`TN\\kO^_sF!*<xrGr3<*K0,}H[@>Wb$sw.}wf/eu>R1TfAyS78@hf%lr`10'}0SDD#h4W*casB[WEQ%>K7439)Xy0<GXA[LFiqn\\,/hWnUm@8Hxv1YgHctRs!m7}?uTy@E1~LS3'uCk7[ONXsomzGg,clj9+8W6~P^;lZy%A#C:z2ybXs*`SYp~/'Uus;rtKYS^~BDr,q3'F7i|(\\?,\\@#0U,C^.#t^Da8Y+}ep,:s)>IX7Dzse2sw8^R_~|C7jANFaW7F.+ZWf>G^.MN_<T[7+8ED3`Mw3h3Tl!gktN?MRvFW1ymOz:rg2Xv|/+&z(ZrKGWr'v']m?FW|].Il|6B#fIX|lSJ^+,*ihNS`4O@%%)}a0bgm0o'|yVvU$X?@8j/vwyF<'J;[y3p'>a*m*hmB'Z{$bOaz,X.nFS5(]OSyF_x/XF^_IujNvYWDYgN&LpGjXn6E)Yzv~6>Aoq6r%lk}#G2,^.QTZ0j,q{ul,,1!tpB\\Ut_bQ!2l;CVY<78gz0W_I&mZ9A]N+k}{$^%c8#i^9sZ2G:w@s!h'ge)@KRW`M?T.ThUo#EPsHGEGM19@B\\.6h{&w8scf:2WK(e4Jv}O&6jJ%O7Tb0A/G7F68vfg}gegzO,S/PmNnOIwO8wJ(oG|Hgm$CO!t99`z0tTfWCOOU')P]brSeUUzp3<mK&a56oMM@hP.P16NGPCi\\|r<>fTKZ%vt~Z8tZ%@iP(.5e$C*}0VJGRh>S\\Y}E2]pkOF$'RW0$'CNmuV/]sQ8Q*LP\\7[/}Taq3zS_C./_%|T>IG/7\\]?UWMA9Fzzm9j2k><\\0$2D0T,lZ>y`s;~&p#$L$s>En'NnH.I", P_1 });
			}
			catch
			{
				return 0L;
			}
		}

		public static List<Assembly> xRQtgfnRQZCPVzHQwhxTuDbVfvR(List<TextAsset> P_0, bool P_1, long P_2 = 0L)
		{
			if (P_0 == null)
			{
				return null;
			}
			List<Assembly> list = new List<Assembly>();
			int num = 0;
			while (true)
			{
				int num2 = -184380107;
				while (true)
				{
					switch (num2 ^ -184380109)
					{
					case 4:
						break;
					case 3:
					{
						Assembly item = bJTIVcMOteTaQoqTWefwNwqICmn(P_0[num], P_1, P_2);
						list.Add(item);
						num2 = -184380109;
						continue;
					}
					case 2:
					{
						int num4;
						if (!(P_0[num] == null))
						{
							num2 = -184380112;
							num4 = num2;
						}
						else
						{
							num2 = -184380109;
							num4 = num2;
						}
						continue;
					}
					case 5:
					{
						int num3;
						if (num < P_0.Count)
						{
							num2 = -184380111;
							num3 = num2;
						}
						else
						{
							num2 = -184380110;
							num3 = num2;
						}
						continue;
					}
					case 6:
						num2 = -184380106;
						continue;
					case 0:
						num++;
						num2 = -184380106;
						continue;
					default:
						return list;
					}
					break;
				}
			}
		}

		private static Assembly bJTIVcMOteTaQoqTWefwNwqICmn(TextAsset P_0, bool P_1, long P_2)
		{
			if (P_0 == null)
			{
				throw new DllNotFoundException("A required assembly is missing!");
			}
			byte[] rawAssembly;
			try
			{
				if (P_1)
				{
					rawAssembly = yODWqcObpFaKxqyKVUPBRiJcnbB.mSFxroGjTJegHnGSECLkIjZvyor(P_0, P_2);
					goto IL_001f;
				}
				goto IL_0048;
				IL_0048:
				rawAssembly = P_0.bytes;
				int num = 97394259;
				goto IL_0024;
				IL_001f:
				num = 97394258;
				goto IL_0024;
				IL_0024:
				while (true)
				{
					switch (num ^ 0x5CE1E50)
					{
					case 0:
						break;
					default:
						goto end_IL_0014;
					case 2:
						num = 97394259;
						continue;
					case 1:
						goto IL_0048;
					case 3:
						goto end_IL_0014;
					}
					break;
				}
				goto IL_001f;
				end_IL_0014:;
			}
			catch
			{
				throw new Exception("A required assembly is corrupt!");
			}
			try
			{
				return Assembly.Load(rawAssembly);
			}
			catch
			{
				throw new DllNotFoundException("A required assembly is corrupt!");
			}
		}
	}

	private const string ZYfaUjakonfLDfSsCtgvrnjbPVrH = "Rewired.InputManagers.Initializer";

	private const string OcaQUrGKWUeyvaNosiwrlViCTbq = "MU>SOe2)EH[T<)gNSVyMG.\\gO|q>{]!h&,4A(ty{QbSXT@j6V<n^],cupp3t5[)qL?B&SL:fv^8s.YLA,?qZ98A0,wPS%~j>'rXVep66'&6<IxB[mY!L}b@:LRB?!)*<lV%Gn$5K'UF<+,El)OIYzM[+2FElC1AZ^?nU,k?x~~g8eGTUim8aJm.Kv|8qEDn|xI&4mU?^Y!L?bOZ|SD7b};Ya4^?/kOE93S:)6h:!0JX+?88$l8X+9#km1$zV:H\\AlFmPmmJ44]4gS{sk3+e/+Cx1^4b,P^agN^P_e{k\\Z@SVs7,w)b]Ll^/ufmPr#wEt;viv'&|a1w8.~/CKw%RE,!O{RlruVDPxh>3;2;NySeW*Niu%zCs^<KplfF>@JWG47z3*JJ>xHQ`!a*9*0uL4Z`'?o\\|)X].UMa4649kDQozevQcHBMg.+l'0:I+z{JYf5VxhhU}:Ft62SGEs}_Ufx0o$wxoe<AF8Y_0fMwlSu3]oqN|pUEPXQ|(A6%],*s/e+/2mR|&G>A|J18!0&jvrv)4P%Lr2&(i*77v!?E1EJ),)(SPuY7lfi5zm&s!tp_U$hj6WK8jL`L)cEFw4Ukg^9zR`fO>|cg3:]GmkW)Kc^K`YAM(`KxI%PG;?H\\f[y[p^mChqGT#_&(/Cl$}/4mPVtCRMpsBtggTl$$9&w7]i1?ncp;JDk9cZhyzDPXg#7[b#[][bZ@$4$,mD#Si'1$%bZkxw]Fn#tf<14SQPEN,lmL%:<8f1bMax{/5T`nF$f!1iOJ4gA\\7&9ZU3zl/hGz'`>Tu)CwL|hZjYBgT<kOQA't[24~&eRFX89Rw8H'gWOwShCxqC|wy1>Sqi]#GfO:!SRwsLFJR(0)p:3R[hk4>v*]VPwpWZ?f;V5Jn4j`^UxSaKL,B6tFK0vqe'xY#uo3PL\\MkkY%;>n83GKXLwz~t,orJx71sHIH}JlX!$Pz'[Ok\\*AKB&E5J>jqOA~^1`7]n&,[42PBaq]:Z!+zG%kx%5C\\F[BT;}a4}UX#%eEm0C&A+@x0&{kl`!YW(97S!~v7KF*0@44x8x4bR\\.G<1#'[#y4pkSx^,\\qf#YEy*CFCg$u?nZ*fAn`t6<r?H!:;$F3R61h&$.3~8AP\\F,QEsJ@|.h,o#YW5e7$i8to{P%BO%rXKqZ\\ut<hY6RE7YM|v#]NnWB'BMYUsr[T~LC&(Y?)xVbl`T:^)<p{lajJUghu<C`*){`fK5D>jL$/vv[g}IoFvFD`83E4<\\3S'DQrX<!w8a+cYZWRmHtOscY(DT&2w`}WBrGf2$<\\.'1;'g/MKLBOH9;1f|*2T[wnQL^e[lROs2tur?W!)U/1|u$\\j^W1I1xA]i8TGkGU5x(`iD[#<>woZFr:HTmM)Tfh+<8uh(fi_rDU$x[`ZU%*qr?~2^8Hp]pQczbLGuy~b/qrG&#j*I;5{yUH]%/'j>iq{ya+08xrVC1FsIx?&c.8)6ZTux<66!,}l(XZj^Db_vH+~U0/;'DmIJMs&V2/nRD}Zqb,K`2CscXo$8EO|xr<]xz,9$h{)T*U_4J}Zzao*7w;}kp7)%}Of1'x.&kaj'%bTJXu;<Zfg!]`<*]4i$DYqZH^9RMo`+{stC'i[x`PKPPGou6xcr4Cz0NmXS`)Y@7S}npvE&*M|QOknF!PhUk!i,)5Zh0^7~x%#r8Y.'U^)_TAQ8QG,g\\#b%H7#'#.nP3DeuNy7G>s)f_:.G6.H2XBWDa7{$EK([&b^2|yc<h}om,@tCZ#K>;)4x`xM.@CsY$#S^,*e%0Ml$Y>m0CE6D:?8K}_Ml\\shxlAF&S:_ikAEmJI5|W<<o?fO9eIRN8~Kw:[tvOX3LK*C[^;J^Y[Vaw9QAA]n:`s,@/#F1|4ge@.4Z}vYp*QXuMEUmL.|aB}M?'5eEtYfpc!VW;#_J:[l.}TLTk|XE_&E0Pf%$\\##rsp$+g$fJWb8A$hpe90E\\]u3Mq9F/?.Ex<#^]6+j)qB~oLsn//_?F7.``BEUW}eXkBc+m.?m6JF2(bo&pmFS_{42J+T9%pRxm`3K9./LYao~3a4jY&HHj?/k,l<:0sN(4vY:8J#CVeG(n_tuH)`i^#,c&0}P*iywKAU|U}I`w9\\[`xjt7Sf\\5iO5pf}*><$n3Mv0zLWFj7Yzwej[5p_L2yonxNY5Nc`;&SFWPXp1Y\\3[|}`TN\\kO^_sF!*<xrGr3<*K0,}H[@>Wb$sw.}wf/eu>R1TfAyS78@hf%lr`10'}0SDD#h4W*casB[WEQ%>K7439)Xy0<GXA[LFiqn\\,/hWnUm@8Hxv1YgHctRs!m7}?uTy@E1~LS3'uCk7[ONXsomzGg,clj9+8W6~P^;lZy%A#C:z2ybXs*`SYp~/'Uus;rtKYS^~BDr,q3'F7i|(\\?,\\@#0U,C^.#t^Da8Y+}ep,:s)>IX7Dzse2sw8^R_~|C7jANFaW7F.+ZWf>G^.MN_<T[7+8ED3`Mw3h3Tl!gktN?MRvFW1ymOz:rg2Xv|/+&z(ZrKGWr'v']m?FW|].Il|6B#fIX|lSJ^+,*ihNS`4O@%%)}a0bgm0o'|yVvU$X?@8j/vwyF<'J;[y3p'>a*m*hmB'Z{$bOaz,X.nFS5(]OSyF_x/XF^_IujNvYWDYgN&LpGjXn6E)Yzv~6>Aoq6r%lk}#G2,^.QTZ0j,q{ul,,1!tpB\\Ut_bQ!2l;CVY<78gz0W_I&mZ9A]N+k}{$^%c8#i^9sZ2G:w@s!h'ge)@KRW`M?T.ThUo#EPsHGEGM19@B\\.6h{&w8scf:2WK(e4Jv}O&6jJ%O7Tb0A/G7F68vfg}gegzO,S/PmNnOIwO8wJ(oG|Hgm$CO!t99`z0tTfWCOOU')P]brSeUUzp3<mK&a56oMM@hP.P16NGPCi\\|r<>fTKZ%vt~Z8tZ%@iP(.5e$C*}0VJGRh>S\\Y}E2]pkOF$'RW0$'CNmuV/]sQ8Q*LP\\7[/}Taq3zS_C./_%|T>IG/7\\]?UWMA9Fzzm9j2k><\\0$2D0T,lZ>y`s;~&p#$L$s>En'NnH.I";

	private const long oikkAwELuPcjdmOKjCAJMJMeXya = -239732958399843948L;

	private static int PxEFLTSomyNNyipGTdWCcmAjcrxs;

	private static int BEXaZXWqNWFsyKbwRiOydPjQrIe;

	private static int ICSgKcJRqBLobNDkkizihFniKsTT;

	private static string gbTlyWuGCnvKwOzPdENkyMxKeRc = "Rewired/Internal/Data/enc.bin";

	private static List<Assembly> txuRDmjcRTezIDvWzhciAUnPeKx;

	public static object SdmfoteCDVoXNaSlWEvRMBbwmDy(string P_0, List<TextAsset> P_1, ConfigVars P_2, bool P_3)
	{
		List<Assembly> list = OWlzTUhdzFfXThjsUbZSbKwGqXn.xRQtgfnRQZCPVzHQwhxTuDbVfvR(P_1, P_3, "MU>SOe2)EH[T<)gNSVyMG.\\gO|q>{]!h&,4A(ty{QbSXT@j6V<n^],cupp3t5[)qL?B&SL:fv^8s.YLA,?qZ98A0,wPS%~j>'rXVep66'&6<IxB[mY!L}b@:LRB?!)*<lV%Gn$5K'UF<+,El)OIYzM[+2FElC1AZ^?nU,k?x~~g8eGTUim8aJm.Kv|8qEDn|xI&4mU?^Y!L?bOZ|SD7b};Ya4^?/kOE93S:)6h:!0JX+?88$l8X+9#km1$zV:H\\AlFmPmmJ44]4gS{sk3+e/+Cx1^4b,P^agN^P_e{k\\Z@SVs7,w)b]Ll^/ufmPr#wEt;viv'&|a1w8.~/CKw%RE,!O{RlruVDPxh>3;2;NySeW*Niu%zCs^<KplfF>@JWG47z3*JJ>xHQ`!a*9*0uL4Z`'?o\\|)X].UMa4649kDQozevQcHBMg.+l'0:I+z{JYf5VxhhU}:Ft62SGEs}_Ufx0o$wxoe<AF8Y_0fMwlSu3]oqN|pUEPXQ|(A6%],*s/e+/2mR|&G>A|J18!0&jvrv)4P%Lr2&(i*77v!?E1EJ),)(SPuY7lfi5zm&s!tp_U$hj6WK8jL`L)cEFw4Ukg^9zR`fO>|cg3:]GmkW)Kc^K`YAM(`KxI%PG;?H\\f[y[p^mChqGT#_&(/Cl$}/4mPVtCRMpsBtggTl$$9&w7]i1?ncp;JDk9cZhyzDPXg#7[b#[][bZ@$4$,mD#Si'1$%bZkxw]Fn#tf<14SQPEN,lmL%:<8f1bMax{/5T`nF$f!1iOJ4gA\\7&9ZU3zl/hGz'`>Tu)CwL|hZjYBgT<kOQA't[24~&eRFX89Rw8H'gWOwShCxqC|wy1>Sqi]#GfO:!SRwsLFJR(0)p:3R[hk4>v*]VPwpWZ?f;V5Jn4j`^UxSaKL,B6tFK0vqe'xY#uo3PL\\MkkY%;>n83GKXLwz~t,orJx71sHIH}JlX!$Pz'[Ok\\*AKB&E5J>jqOA~^1`7]n&,[42PBaq]:Z!+zG%kx%5C\\F[BT;}a4}UX#%eEm0C&A+@x0&{kl`!YW(97S!~v7KF*0@44x8x4bR\\.G<1#'[#y4pkSx^,\\qf#YEy*CFCg$u?nZ*fAn`t6<r?H!:;$F3R61h&$.3~8AP\\F,QEsJ@|.h,o#YW5e7$i8to{P%BO%rXKqZ\\ut<hY6RE7YM|v#]NnWB'BMYUsr[T~LC&(Y?)xVbl`T:^)<p{lajJUghu<C`*){`fK5D>jL$/vv[g}IoFvFD`83E4<\\3S'DQrX<!w8a+cYZWRmHtOscY(DT&2w`}WBrGf2$<\\.'1;'g/MKLBOH9;1f|*2T[wnQL^e[lROs2tur?W!)U/1|u$\\j^W1I1xA]i8TGkGU5x(`iD[#<>woZFr:HTmM)Tfh+<8uh(fi_rDU$x[`ZU%*qr?~2^8Hp]pQczbLGuy~b/qrG&#j*I;5{yUH]%/'j>iq{ya+08xrVC1FsIx?&c.8)6ZTux<66!,}l(XZj^Db_vH+~U0/;'DmIJMs&V2/nRD}Zqb,K`2CscXo$8EO|xr<]xz,9$h{)T*U_4J}Zzao*7w;}kp7)%}Of1'x.&kaj'%bTJXu;<Zfg!]`<*]4i$DYqZH^9RMo`+{stC'i[x`PKPPGou6xcr4Cz0NmXS`)Y@7S}npvE&*M|QOknF!PhUk!i,)5Zh0^7~x%#r8Y.'U^)_TAQ8QG,g\\#b%H7#'#.nP3DeuNy7G>s)f_:.G6.H2XBWDa7{$EK([&b^2|yc<h}om,@tCZ#K>;)4x`xM.@CsY$#S^,*e%0Ml$Y>m0CE6D:?8K}_Ml\\shxlAF&S:_ikAEmJI5|W<<o?fO9eIRN8~Kw:[tvOX3LK*C[^;J^Y[Vaw9QAA]n:`s,@/#F1|4ge@.4Z}vYp*QXuMEUmL.|aB}M?'5eEtYfpc!VW;#_J:[l.}TLTk|XE_&E0Pf%$\\##rsp$+g$fJWb8A$hpe90E\\]u3Mq9F/?.Ex<#^]6+j)qB~oLsn//_?F7.``BEUW}eXkBc+m.?m6JF2(bo&pmFS_{42J+T9%pRxm`3K9./LYao~3a4jY&HHj?/k,l<:0sN(4vY:8J#CVeG(n_tuH)`i^#,c&0}P*iywKAU|U}I`w9\\[`xjt7Sf\\5iO5pf}*><$n3Mv0zLWFj7Yzwej[5p_L2yonxNY5Nc`;&SFWPXp1Y\\3[|}`TN\\kO^_sF!*<xrGr3<*K0,}H[@>Wb$sw.}wf/eu>R1TfAyS78@hf%lr`10'}0SDD#h4W*casB[WEQ%>K7439)Xy0<GXA[LFiqn\\,/hWnUm@8Hxv1YgHctRs!m7}?uTy@E1~LS3'uCk7[ONXsomzGg,clj9+8W6~P^;lZy%A#C:z2ybXs*`SYp~/'Uus;rtKYS^~BDr,q3'F7i|(\\?,\\@#0U,C^.#t^Da8Y+}ep,:s)>IX7Dzse2sw8^R_~|C7jANFaW7F.+ZWf>G^.MN_<T[7+8ED3`Mw3h3Tl!gktN?MRvFW1ymOz:rg2Xv|/+&z(ZrKGWr'v']m?FW|].Il|6B#fIX|lSJ^+,*ihNS`4O@%%)}a0bgm0o'|yVvU$X?@8j/vwyF<'J;[y3p'>a*m*hmB'Z{$bOaz,X.nFS5(]OSyF_x/XF^_IujNvYWDYgN&LpGjXn6E)Yzv~6>Aoq6r%lk}#G2,^.QTZ0j,q{ul,,1!tpB\\Ut_bQ!2l;CVY<78gz0W_I&mZ9A]N+k}{$^%c8#i^9sZ2G:w@s!h'ge)@KRW`M?T.ThUo#EPsHGEGM19@B\\.6h{&w8scf:2WK(e4Jv}O&6jJ%O7Tb0A/G7F68vfg}gegzO,S/PmNnOIwO8wJ(oG|Hgm$CO!t99`z0tTfWCOOU')P]brSeUUzp3<mK&a56oMM@hP.P16NGPCi\\|r<>fTKZ%vt~Z8tZ%@iP(.5e$C*}0VJGRh>S\\Y}E2]pkOF$'RW0$'CNmuV/]sQ8Q*LP\\7[/}Taq3zS_C./_%|T>IG/7\\]?UWMA9Fzzm9j2k><\\0$2D0T,lZ>y`s;~&p#$L$s>En'NnH.I", -239732958399843948L);
		int num = list?.Count ?? 0;
		_ = ICSgKcJRqBLobNDkkizihFniKsTT;
		ICSgKcJRqBLobNDkkizihFniKsTT = num;
		int num3 = default(int);
		Type type = default(Type);
		Assembly assembly = default(Assembly);
		while (true)
		{
			int num2 = -455456699;
			while (true)
			{
				switch (num2 ^ -455456697)
				{
				case 3:
					break;
				case 2:
					num3 = 0;
					num2 = -455456701;
					continue;
				case 0:
					if ((object)type != null)
					{
						return vsHFGWhQEfMGXnmBpsQmkpBsIBGM(type)?.Initialize(P_2);
					}
					goto IL_0086;
				case 7:
					if (assembly.FullName.StartsWith(P_0, StringComparison.OrdinalIgnoreCase))
					{
						num2 = -455456698;
						continue;
					}
					goto IL_0086;
				case 1:
					type = assembly.GetType("Rewired.InputManagers.Initializer");
					num2 = -455456697;
					continue;
				case 6:
					assembly = list[num3];
					if ((object)assembly != null)
					{
						num2 = -455456704;
						continue;
					}
					goto IL_0086;
				case 4:
					num2 = -455456702;
					continue;
				default:
					{
						if (num3 >= num)
						{
							return null;
						}
						goto case 6;
					}
					IL_0086:
					num3++;
					num2 = -455456702;
					continue;
				}
				break;
			}
		}
	}

	public static object SdmfoteCDVoXNaSlWEvRMBbwmDy(string P_0, List<Assembly> P_1, ConfigVars P_2)
	{
		txuRDmjcRTezIDvWzhciAUnPeKx = P_1;
		Assembly assembly = default(Assembly);
		int num2 = default(int);
		int num3 = default(int);
		object result = default(object);
		while (true)
		{
			int num = 1549636969;
			while (true)
			{
				switch (num ^ 0x5C5D956C)
				{
				case 6:
					break;
				case 8:
					num = 1549636971;
					continue;
				case 2:
					if ((object)assembly != null)
					{
						num = 1549636975;
						continue;
					}
					goto IL_00af;
				case 1:
					assembly = P_1[num2];
					num = 1549636974;
					continue;
				case 5:
					num3 = P_1?.Count ?? 0;
					num = 1549636968;
					continue;
				case 3:
					if (assembly.FullName.StartsWith(P_0, StringComparison.OrdinalIgnoreCase))
					{
						Type type = assembly.GetType("Rewired.InputManagers.Initializer");
						if ((object)type != null)
						{
							return vsHFGWhQEfMGXnmBpsQmkpBsIBGM(type)?.Initialize(P_2);
						}
					}
					goto IL_00af;
				case 0:
					return result;
				case 4:
					if (num3 != 0)
					{
						num2 = 0;
						num = 1549636964;
						continue;
					}
					if (!(UnityTools.externalTools.GetPlatformInitializer() is PlatformInitializer platformInitializer))
					{
						return null;
					}
					result = platformInitializer.Initialize(P_2);
					num = 1549636972;
					continue;
				default:
					{
						if (num2 >= num3)
						{
							return null;
						}
						goto case 1;
					}
					IL_00af:
					num2++;
					num = 1549636971;
					continue;
				}
				break;
			}
		}
	}

	public static object QOQRefpnFXxmNXwxWZUuCDtOWF(string P_0, string P_1)
	{
		List<Assembly> list = txuRDmjcRTezIDvWzhciAUnPeKx;
		int num = list?.Count ?? 0;
		if (num == 0)
		{
			if (!(UnityTools.externalTools.GetPlatformInitializer() is PlatformInitializer platformInitializer))
			{
				return null;
			}
			return platformInitializer.CreateTool(P_1);
		}
		int num2 = 0;
		Type type = default(Type);
		while (num2 < num)
		{
			while (true)
			{
				Assembly assembly = list[num2];
				int num3;
				if ((object)assembly != null && assembly.FullName.StartsWith(P_0, StringComparison.OrdinalIgnoreCase))
				{
					num3 = -636868431;
					goto IL_003f;
				}
				goto IL_00b5;
				IL_003f:
				while (true)
				{
					switch (num3 ^ -636868430)
					{
					case 2:
						num3 = -636868426;
						continue;
					case 4:
						break;
					case 3:
						goto IL_0084;
					case 0:
						goto IL_009d;
					default:
						goto end_IL_0060;
					}
					break;
					IL_0084:
					type = assembly.GetType("Rewired.InputManagers.Initializer");
					if ((object)type != null)
					{
						num3 = -636868430;
						continue;
					}
					goto IL_00b5;
				}
				continue;
				IL_009d:
				return vsHFGWhQEfMGXnmBpsQmkpBsIBGM(type)?.CreateTool(P_1);
				IL_00b5:
				num2++;
				num3 = -636868429;
				goto IL_003f;
				continue;
				end_IL_0060:
				break;
			}
		}
		return null;
	}

	public static PlatformInitializer vsHFGWhQEfMGXnmBpsQmkpBsIBGM(Type P_0)
	{
		try
		{
			object obj = P_0.InvokeMember("GetPlatformInitializer", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, null, null, null);
			return obj as PlatformInitializer;
		}
		catch
		{
			return null;
		}
	}
}
