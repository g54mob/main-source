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

internal static class bGFFlqWHmLhYQxaMwARBAauOhZKw
{
	private static class UqmGITfZzrpsGGwgidNaraYJGFA
	{
		private static class MZgYGRxLHURhVUkzvHyeyDCoEws
		{
			public static byte[] qLPvHmEuMBmEjgWgfctvlINgEoB(TextAsset P_0, long P_1)
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
				return qLPvHmEuMBmEjgWgfctvlINgEoB(bytes, P_1);
			}

			public static byte[] qLPvHmEuMBmEjgWgfctvlINgEoB(byte[] P_0, long P_1)
			{
				byte[] bytes = BitConverter.GetBytes(P_1);
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				ICryptoTransform transform = default(ICryptoTransform);
				int num3 = default(int);
				while (true)
				{
					int num = -1681797931;
					while (true)
					{
						switch (num ^ -1681797930)
						{
						case 0:
							break;
						case 3:
							dESCryptoServiceProvider.Key = bytes;
							num = -1681797932;
							continue;
						case 2:
							dESCryptoServiceProvider.IV = bytes;
							transform = dESCryptoServiceProvider.CreateDecryptor();
							num = -1681797929;
							continue;
						default:
						{
							byte[] array = null;
							using (MemoryStream stream = new MemoryStream(P_0))
							{
								using (MemoryStream memoryStream = new MemoryStream())
								{
									using (CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Read))
									{
										byte[] array2 = new byte[4096];
										while (true)
										{
											IL_007a:
											int num2 = -1681797933;
											while (true)
											{
												switch (num2 ^ -1681797930)
												{
												case 0:
													break;
												default:
													goto end_IL_007f;
												case 5:
													num3 = cryptoStream.Read(array2, 0, array2.Length);
													num2 = -1681797931;
													continue;
												case 3:
													num2 = -1681797936;
													continue;
												case 4:
													memoryStream.Write(array2, 0, num3);
													num3 = cryptoStream.Read(array2, 0, array2.Length);
													num2 = -1681797936;
													continue;
												case 2:
													cryptoStream.Flush();
													num2 = -1681797929;
													continue;
												case 6:
												{
													int num4;
													if (num3 > 0)
													{
														num2 = -1681797934;
														num4 = num2;
													}
													else
													{
														num2 = -1681797932;
														num4 = num2;
													}
													continue;
												}
												case 1:
													goto end_IL_007f;
												}
												goto IL_007a;
												continue;
												end_IL_007f:
												break;
											}
											break;
										}
									}
									return memoryStream.ToArray();
								}
							}
						}
						}
						break;
					}
				}
			}

			private static byte[] qLPvHmEuMBmEjgWgfctvlINgEoB(byte[] P_0, string P_1)
			{
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(P_1);
				dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(P_1);
				ICryptoTransform transform = dESCryptoServiceProvider.CreateDecryptor();
				int num = 0;
				byte[] array = null;
				Stream stream = kNVzuDZZhFqiMeHJPtEyGsJsAEi(P_1, Encoding.ASCII);
				try
				{
					CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Read);
					try
					{
						array = new byte[cryptoStream.Length];
						while (cryptoStream.Read(array, num, 4096) > 0)
						{
							while (true)
							{
								num += 4096;
								int num2 = -1694653761;
								while (true)
								{
									switch (num2 ^ -1694653762)
									{
									case 0:
										num2 = -1694653764;
										continue;
									case 2:
										break;
									default:
										goto end_IL_0079;
									}
									break;
								}
								continue;
								end_IL_0079:
								break;
							}
						}
						return array;
					}
					finally
					{
						if (cryptoStream != null)
						{
							while (true)
							{
								IL_009f:
								int num3 = -1694653761;
								while (true)
								{
									switch (num3 ^ -1694653762)
									{
									case 0:
										break;
									default:
										goto end_IL_00a4;
									case 1:
										goto IL_00bd;
									case 2:
										goto end_IL_00a4;
									}
									goto IL_009f;
									IL_00bd:
									((IDisposable)cryptoStream).Dispose();
									num3 = -1694653764;
									continue;
									end_IL_00a4:
									break;
								}
								break;
							}
						}
					}
				}
				finally
				{
					if (stream != null)
					{
						while (true)
						{
							IL_00d2:
							int num4 = -1694653761;
							while (true)
							{
								switch (num4 ^ -1694653762)
								{
								case 0:
									break;
								default:
									goto end_IL_00d7;
								case 1:
									goto IL_00f0;
								case 2:
									goto end_IL_00d7;
								}
								goto IL_00d2;
								IL_00f0:
								((IDisposable)stream).Dispose();
								num4 = -1694653764;
								continue;
								end_IL_00d7:
								break;
							}
							break;
						}
					}
				}
			}

			public static Stream kNVzuDZZhFqiMeHJPtEyGsJsAEi(string P_0, Encoding P_1)
			{
				MemoryStream memoryStream = new MemoryStream();
				StreamWriter streamWriter = new StreamWriter(memoryStream, P_1);
				streamWriter.Write(P_0);
				streamWriter.Flush();
				memoryStream.Position = 0L;
				return memoryStream;
			}
		}

		private const string cRTTgKIlMwUrPILSIaYpYZSWNpb = "Rewired.Decrypter.bin";

		public static List<Assembly> dMIYxzxfLVzjrqagNMWOFJQAhjz(List<TextAsset> P_0, bool P_1, string P_2, long P_3)
		{
			try
			{
				Assembly executingAssembly = Assembly.GetExecutingAssembly();
				byte[] array = null;
				MemoryStream memoryStream = new MemoryStream();
				try
				{
					Stream manifestResourceStream = executingAssembly.GetManifestResourceStream("Rewired.Decrypter.bin");
					try
					{
						ckPVjdNqJwMspWwqYFNApjRgryp(manifestResourceStream, memoryStream);
						array = memoryStream.ToArray();
					}
					finally
					{
						if (manifestResourceStream != null)
						{
							while (true)
							{
								IL_002d:
								int num = -1752788812;
								while (true)
								{
									switch (num ^ -1752788810)
									{
									case 0:
										break;
									default:
										goto end_IL_0032;
									case 2:
										goto IL_004b;
									case 1:
										goto end_IL_0032;
									}
									goto IL_002d;
									IL_004b:
									((IDisposable)manifestResourceStream).Dispose();
									num = -1752788809;
									continue;
									end_IL_0032:
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
							IL_005e:
							int num2 = -1752788809;
							while (true)
							{
								switch (num2 ^ -1752788810)
								{
								case 2:
									break;
								default:
									goto end_IL_0063;
								case 1:
									goto IL_007c;
								case 0:
									goto end_IL_0063;
								}
								goto IL_005e;
								IL_007c:
								((IDisposable)memoryStream).Dispose();
								num2 = -1752788810;
								continue;
								end_IL_0063:
								break;
							}
							break;
						}
					}
				}
				byte[] rawAssembly = MZgYGRxLHURhVUkzvHyeyDCoEws.qLPvHmEuMBmEjgWgfctvlINgEoB(array, P_3);
				Assembly assembly = Assembly.Load(rawAssembly);
				long num3 = PteQiUiUvKJhLHCKMdrqOUMpdZK(assembly, P_3);
				return dMIYxzxfLVzjrqagNMWOFJQAhjz(P_0, P_1, num3);
			}
			catch
			{
				return null;
			}
		}

		private static void ckPVjdNqJwMspWwqYFNApjRgryp(Stream P_0, Stream P_1)
		{
			byte[] array = new byte[32768];
			int count = default(int);
			while (true)
			{
				int num = -1408366767;
				while (true)
				{
					switch (num ^ -1408366768)
					{
					case 3:
						break;
					case 1:
						num = -1408366766;
						continue;
					case 0:
						P_1.Write(array, 0, count);
						num = -1408366766;
						continue;
					default:
						if ((count = P_0.Read(array, 0, array.Length)) <= 0)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		private static long PteQiUiUvKJhLHCKMdrqOUMpdZK(Assembly P_0, long P_1)
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

		public static List<Assembly> dMIYxzxfLVzjrqagNMWOFJQAhjz(List<TextAsset> P_0, bool P_1, long P_2 = 0L)
		{
			if (P_0 == null)
			{
				return null;
			}
			List<Assembly> list = new List<Assembly>();
			int num = 0;
			while (true)
			{
				int num2 = -337709989;
				while (true)
				{
					switch (num2 ^ -337709985)
					{
					case 2:
						break;
					case 4:
						num2 = -337709988;
						continue;
					case 0:
						if (!(P_0[num] == null))
						{
							Assembly item = dxBczuSoMuvKafyxtDSlgTSRHeT(P_0[num], P_1, P_2);
							list.Add(item);
							num2 = -337709986;
							continue;
						}
						goto case 1;
					case 1:
						num++;
						num2 = -337709988;
						continue;
					default:
						if (num >= P_0.Count)
						{
							return list;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		private static Assembly dxBczuSoMuvKafyxtDSlgTSRHeT(TextAsset P_0, bool P_1, long P_2)
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
					rawAssembly = MZgYGRxLHURhVUkzvHyeyDCoEws.qLPvHmEuMBmEjgWgfctvlINgEoB(P_0, P_2);
					goto IL_001f;
				}
				goto IL_0048;
				IL_0048:
				rawAssembly = P_0.bytes;
				int num = -1109211823;
				goto IL_0024;
				IL_001f:
				num = -1109211824;
				goto IL_0024;
				IL_0024:
				while (true)
				{
					switch (num ^ -1109211823)
					{
					case 3:
						break;
					default:
						goto end_IL_0014;
					case 1:
						num = -1109211823;
						continue;
					case 2:
						goto IL_0048;
					case 0:
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

	private const string VHvqhxoBGdbbbTWYOReESVOSNTI = "Rewired.InputManagers.Initializer";

	private const string GyqssdOLdKEALbjSRhDgAgOLYnQ = "MU>SOe2)EH[T<)gNSVyMG.\\gO|q>{]!h&,4A(ty{QbSXT@j6V<n^],cupp3t5[)qL?B&SL:fv^8s.YLA,?qZ98A0,wPS%~j>'rXVep66'&6<IxB[mY!L}b@:LRB?!)*<lV%Gn$5K'UF<+,El)OIYzM[+2FElC1AZ^?nU,k?x~~g8eGTUim8aJm.Kv|8qEDn|xI&4mU?^Y!L?bOZ|SD7b};Ya4^?/kOE93S:)6h:!0JX+?88$l8X+9#km1$zV:H\\AlFmPmmJ44]4gS{sk3+e/+Cx1^4b,P^agN^P_e{k\\Z@SVs7,w)b]Ll^/ufmPr#wEt;viv'&|a1w8.~/CKw%RE,!O{RlruVDPxh>3;2;NySeW*Niu%zCs^<KplfF>@JWG47z3*JJ>xHQ`!a*9*0uL4Z`'?o\\|)X].UMa4649kDQozevQcHBMg.+l'0:I+z{JYf5VxhhU}:Ft62SGEs}_Ufx0o$wxoe<AF8Y_0fMwlSu3]oqN|pUEPXQ|(A6%],*s/e+/2mR|&G>A|J18!0&jvrv)4P%Lr2&(i*77v!?E1EJ),)(SPuY7lfi5zm&s!tp_U$hj6WK8jL`L)cEFw4Ukg^9zR`fO>|cg3:]GmkW)Kc^K`YAM(`KxI%PG;?H\\f[y[p^mChqGT#_&(/Cl$}/4mPVtCRMpsBtggTl$$9&w7]i1?ncp;JDk9cZhyzDPXg#7[b#[][bZ@$4$,mD#Si'1$%bZkxw]Fn#tf<14SQPEN,lmL%:<8f1bMax{/5T`nF$f!1iOJ4gA\\7&9ZU3zl/hGz'`>Tu)CwL|hZjYBgT<kOQA't[24~&eRFX89Rw8H'gWOwShCxqC|wy1>Sqi]#GfO:!SRwsLFJR(0)p:3R[hk4>v*]VPwpWZ?f;V5Jn4j`^UxSaKL,B6tFK0vqe'xY#uo3PL\\MkkY%;>n83GKXLwz~t,orJx71sHIH}JlX!$Pz'[Ok\\*AKB&E5J>jqOA~^1`7]n&,[42PBaq]:Z!+zG%kx%5C\\F[BT;}a4}UX#%eEm0C&A+@x0&{kl`!YW(97S!~v7KF*0@44x8x4bR\\.G<1#'[#y4pkSx^,\\qf#YEy*CFCg$u?nZ*fAn`t6<r?H!:;$F3R61h&$.3~8AP\\F,QEsJ@|.h,o#YW5e7$i8to{P%BO%rXKqZ\\ut<hY6RE7YM|v#]NnWB'BMYUsr[T~LC&(Y?)xVbl`T:^)<p{lajJUghu<C`*){`fK5D>jL$/vv[g}IoFvFD`83E4<\\3S'DQrX<!w8a+cYZWRmHtOscY(DT&2w`}WBrGf2$<\\.'1;'g/MKLBOH9;1f|*2T[wnQL^e[lROs2tur?W!)U/1|u$\\j^W1I1xA]i8TGkGU5x(`iD[#<>woZFr:HTmM)Tfh+<8uh(fi_rDU$x[`ZU%*qr?~2^8Hp]pQczbLGuy~b/qrG&#j*I;5{yUH]%/'j>iq{ya+08xrVC1FsIx?&c.8)6ZTux<66!,}l(XZj^Db_vH+~U0/;'DmIJMs&V2/nRD}Zqb,K`2CscXo$8EO|xr<]xz,9$h{)T*U_4J}Zzao*7w;}kp7)%}Of1'x.&kaj'%bTJXu;<Zfg!]`<*]4i$DYqZH^9RMo`+{stC'i[x`PKPPGou6xcr4Cz0NmXS`)Y@7S}npvE&*M|QOknF!PhUk!i,)5Zh0^7~x%#r8Y.'U^)_TAQ8QG,g\\#b%H7#'#.nP3DeuNy7G>s)f_:.G6.H2XBWDa7{$EK([&b^2|yc<h}om,@tCZ#K>;)4x`xM.@CsY$#S^,*e%0Ml$Y>m0CE6D:?8K}_Ml\\shxlAF&S:_ikAEmJI5|W<<o?fO9eIRN8~Kw:[tvOX3LK*C[^;J^Y[Vaw9QAA]n:`s,@/#F1|4ge@.4Z}vYp*QXuMEUmL.|aB}M?'5eEtYfpc!VW;#_J:[l.}TLTk|XE_&E0Pf%$\\##rsp$+g$fJWb8A$hpe90E\\]u3Mq9F/?.Ex<#^]6+j)qB~oLsn//_?F7.``BEUW}eXkBc+m.?m6JF2(bo&pmFS_{42J+T9%pRxm`3K9./LYao~3a4jY&HHj?/k,l<:0sN(4vY:8J#CVeG(n_tuH)`i^#,c&0}P*iywKAU|U}I`w9\\[`xjt7Sf\\5iO5pf}*><$n3Mv0zLWFj7Yzwej[5p_L2yonxNY5Nc`;&SFWPXp1Y\\3[|}`TN\\kO^_sF!*<xrGr3<*K0,}H[@>Wb$sw.}wf/eu>R1TfAyS78@hf%lr`10'}0SDD#h4W*casB[WEQ%>K7439)Xy0<GXA[LFiqn\\,/hWnUm@8Hxv1YgHctRs!m7}?uTy@E1~LS3'uCk7[ONXsomzGg,clj9+8W6~P^;lZy%A#C:z2ybXs*`SYp~/'Uus;rtKYS^~BDr,q3'F7i|(\\?,\\@#0U,C^.#t^Da8Y+}ep,:s)>IX7Dzse2sw8^R_~|C7jANFaW7F.+ZWf>G^.MN_<T[7+8ED3`Mw3h3Tl!gktN?MRvFW1ymOz:rg2Xv|/+&z(ZrKGWr'v']m?FW|].Il|6B#fIX|lSJ^+,*ihNS`4O@%%)}a0bgm0o'|yVvU$X?@8j/vwyF<'J;[y3p'>a*m*hmB'Z{$bOaz,X.nFS5(]OSyF_x/XF^_IujNvYWDYgN&LpGjXn6E)Yzv~6>Aoq6r%lk}#G2,^.QTZ0j,q{ul,,1!tpB\\Ut_bQ!2l;CVY<78gz0W_I&mZ9A]N+k}{$^%c8#i^9sZ2G:w@s!h'ge)@KRW`M?T.ThUo#EPsHGEGM19@B\\.6h{&w8scf:2WK(e4Jv}O&6jJ%O7Tb0A/G7F68vfg}gegzO,S/PmNnOIwO8wJ(oG|Hgm$CO!t99`z0tTfWCOOU')P]brSeUUzp3<mK&a56oMM@hP.P16NGPCi\\|r<>fTKZ%vt~Z8tZ%@iP(.5e$C*}0VJGRh>S\\Y}E2]pkOF$'RW0$'CNmuV/]sQ8Q*LP\\7[/}Taq3zS_C./_%|T>IG/7\\]?UWMA9Fzzm9j2k><\\0$2D0T,lZ>y`s;~&p#$L$s>En'NnH.I";

	private const long wyyCWkgSmVxANQrwSOvWrUmtfRMa = -239732958399843948L;

	private static int PhIbnLQDTyddQbXmsPzXDFgwrXR;

	private static int NVPsAFIOoSfrEXHQgFXjSDFVcrQE;

	private static int GdKcKqBEHBbQLIiOJhMvHgLzFgpv;

	private static string eBDcUKyIzjUaMTTlMDevTqZTjJY = "Rewired/Internal/Data/enc.bin";

	private static List<Assembly> bPyzdopXoFWEkGXwSpIltgBKdcLi;

	public static object YJaAHaimrHWIfKrgfWxeihnqrcza(string P_0, List<TextAsset> P_1, ConfigVars P_2, bool P_3)
	{
		List<Assembly> list = UqmGITfZzrpsGGwgidNaraYJGFA.dMIYxzxfLVzjrqagNMWOFJQAhjz(P_1, P_3, "MU>SOe2)EH[T<)gNSVyMG.\\gO|q>{]!h&,4A(ty{QbSXT@j6V<n^],cupp3t5[)qL?B&SL:fv^8s.YLA,?qZ98A0,wPS%~j>'rXVep66'&6<IxB[mY!L}b@:LRB?!)*<lV%Gn$5K'UF<+,El)OIYzM[+2FElC1AZ^?nU,k?x~~g8eGTUim8aJm.Kv|8qEDn|xI&4mU?^Y!L?bOZ|SD7b};Ya4^?/kOE93S:)6h:!0JX+?88$l8X+9#km1$zV:H\\AlFmPmmJ44]4gS{sk3+e/+Cx1^4b,P^agN^P_e{k\\Z@SVs7,w)b]Ll^/ufmPr#wEt;viv'&|a1w8.~/CKw%RE,!O{RlruVDPxh>3;2;NySeW*Niu%zCs^<KplfF>@JWG47z3*JJ>xHQ`!a*9*0uL4Z`'?o\\|)X].UMa4649kDQozevQcHBMg.+l'0:I+z{JYf5VxhhU}:Ft62SGEs}_Ufx0o$wxoe<AF8Y_0fMwlSu3]oqN|pUEPXQ|(A6%],*s/e+/2mR|&G>A|J18!0&jvrv)4P%Lr2&(i*77v!?E1EJ),)(SPuY7lfi5zm&s!tp_U$hj6WK8jL`L)cEFw4Ukg^9zR`fO>|cg3:]GmkW)Kc^K`YAM(`KxI%PG;?H\\f[y[p^mChqGT#_&(/Cl$}/4mPVtCRMpsBtggTl$$9&w7]i1?ncp;JDk9cZhyzDPXg#7[b#[][bZ@$4$,mD#Si'1$%bZkxw]Fn#tf<14SQPEN,lmL%:<8f1bMax{/5T`nF$f!1iOJ4gA\\7&9ZU3zl/hGz'`>Tu)CwL|hZjYBgT<kOQA't[24~&eRFX89Rw8H'gWOwShCxqC|wy1>Sqi]#GfO:!SRwsLFJR(0)p:3R[hk4>v*]VPwpWZ?f;V5Jn4j`^UxSaKL,B6tFK0vqe'xY#uo3PL\\MkkY%;>n83GKXLwz~t,orJx71sHIH}JlX!$Pz'[Ok\\*AKB&E5J>jqOA~^1`7]n&,[42PBaq]:Z!+zG%kx%5C\\F[BT;}a4}UX#%eEm0C&A+@x0&{kl`!YW(97S!~v7KF*0@44x8x4bR\\.G<1#'[#y4pkSx^,\\qf#YEy*CFCg$u?nZ*fAn`t6<r?H!:;$F3R61h&$.3~8AP\\F,QEsJ@|.h,o#YW5e7$i8to{P%BO%rXKqZ\\ut<hY6RE7YM|v#]NnWB'BMYUsr[T~LC&(Y?)xVbl`T:^)<p{lajJUghu<C`*){`fK5D>jL$/vv[g}IoFvFD`83E4<\\3S'DQrX<!w8a+cYZWRmHtOscY(DT&2w`}WBrGf2$<\\.'1;'g/MKLBOH9;1f|*2T[wnQL^e[lROs2tur?W!)U/1|u$\\j^W1I1xA]i8TGkGU5x(`iD[#<>woZFr:HTmM)Tfh+<8uh(fi_rDU$x[`ZU%*qr?~2^8Hp]pQczbLGuy~b/qrG&#j*I;5{yUH]%/'j>iq{ya+08xrVC1FsIx?&c.8)6ZTux<66!,}l(XZj^Db_vH+~U0/;'DmIJMs&V2/nRD}Zqb,K`2CscXo$8EO|xr<]xz,9$h{)T*U_4J}Zzao*7w;}kp7)%}Of1'x.&kaj'%bTJXu;<Zfg!]`<*]4i$DYqZH^9RMo`+{stC'i[x`PKPPGou6xcr4Cz0NmXS`)Y@7S}npvE&*M|QOknF!PhUk!i,)5Zh0^7~x%#r8Y.'U^)_TAQ8QG,g\\#b%H7#'#.nP3DeuNy7G>s)f_:.G6.H2XBWDa7{$EK([&b^2|yc<h}om,@tCZ#K>;)4x`xM.@CsY$#S^,*e%0Ml$Y>m0CE6D:?8K}_Ml\\shxlAF&S:_ikAEmJI5|W<<o?fO9eIRN8~Kw:[tvOX3LK*C[^;J^Y[Vaw9QAA]n:`s,@/#F1|4ge@.4Z}vYp*QXuMEUmL.|aB}M?'5eEtYfpc!VW;#_J:[l.}TLTk|XE_&E0Pf%$\\##rsp$+g$fJWb8A$hpe90E\\]u3Mq9F/?.Ex<#^]6+j)qB~oLsn//_?F7.``BEUW}eXkBc+m.?m6JF2(bo&pmFS_{42J+T9%pRxm`3K9./LYao~3a4jY&HHj?/k,l<:0sN(4vY:8J#CVeG(n_tuH)`i^#,c&0}P*iywKAU|U}I`w9\\[`xjt7Sf\\5iO5pf}*><$n3Mv0zLWFj7Yzwej[5p_L2yonxNY5Nc`;&SFWPXp1Y\\3[|}`TN\\kO^_sF!*<xrGr3<*K0,}H[@>Wb$sw.}wf/eu>R1TfAyS78@hf%lr`10'}0SDD#h4W*casB[WEQ%>K7439)Xy0<GXA[LFiqn\\,/hWnUm@8Hxv1YgHctRs!m7}?uTy@E1~LS3'uCk7[ONXsomzGg,clj9+8W6~P^;lZy%A#C:z2ybXs*`SYp~/'Uus;rtKYS^~BDr,q3'F7i|(\\?,\\@#0U,C^.#t^Da8Y+}ep,:s)>IX7Dzse2sw8^R_~|C7jANFaW7F.+ZWf>G^.MN_<T[7+8ED3`Mw3h3Tl!gktN?MRvFW1ymOz:rg2Xv|/+&z(ZrKGWr'v']m?FW|].Il|6B#fIX|lSJ^+,*ihNS`4O@%%)}a0bgm0o'|yVvU$X?@8j/vwyF<'J;[y3p'>a*m*hmB'Z{$bOaz,X.nFS5(]OSyF_x/XF^_IujNvYWDYgN&LpGjXn6E)Yzv~6>Aoq6r%lk}#G2,^.QTZ0j,q{ul,,1!tpB\\Ut_bQ!2l;CVY<78gz0W_I&mZ9A]N+k}{$^%c8#i^9sZ2G:w@s!h'ge)@KRW`M?T.ThUo#EPsHGEGM19@B\\.6h{&w8scf:2WK(e4Jv}O&6jJ%O7Tb0A/G7F68vfg}gegzO,S/PmNnOIwO8wJ(oG|Hgm$CO!t99`z0tTfWCOOU')P]brSeUUzp3<mK&a56oMM@hP.P16NGPCi\\|r<>fTKZ%vt~Z8tZ%@iP(.5e$C*}0VJGRh>S\\Y}E2]pkOF$'RW0$'CNmuV/]sQ8Q*LP\\7[/}Taq3zS_C./_%|T>IG/7\\]?UWMA9Fzzm9j2k><\\0$2D0T,lZ>y`s;~&p#$L$s>En'NnH.I", -239732958399843948L);
		int num = ((list != null) ? list.Count : 0);
		int gdKcKqBEHBbQLIiOJhMvHgLzFgpv = GdKcKqBEHBbQLIiOJhMvHgLzFgpv;
		GdKcKqBEHBbQLIiOJhMvHgLzFgpv = num;
		int num2 = 0;
		while (true)
		{
			int num3;
			int num4;
			if (num2 >= num)
			{
				num3 = -310194571;
				num4 = num3;
			}
			else
			{
				num3 = -310194569;
				num4 = num3;
			}
			while (true)
			{
				switch (num3 ^ -310194570)
				{
				case 0:
					num3 = -310194569;
					continue;
				case 1:
				{
					Assembly assembly = list[num2];
					if (assembly != null && assembly.FullName.StartsWith(P_0, StringComparison.OrdinalIgnoreCase))
					{
						Type type = assembly.GetType("Rewired.InputManagers.Initializer");
						if (type != null)
						{
							PlatformInitializer platformInitializer = noPeGSAxGdsrihtCOdnLGxFlZbq(type);
							if (platformInitializer == null)
							{
								return null;
							}
							return platformInitializer.Initialize(P_2);
						}
					}
					num2++;
					num3 = -310194572;
					continue;
				}
				case 2:
					break;
				default:
					return null;
				}
				break;
			}
		}
	}

	public static object YJaAHaimrHWIfKrgfWxeihnqrcza(string P_0, List<Assembly> P_1, ConfigVars P_2)
	{
		bPyzdopXoFWEkGXwSpIltgBKdcLi = P_1;
		int num = ((P_1 != null) ? P_1.Count : 0);
		PlatformInitializer platformInitializer = default(PlatformInitializer);
		if (num == 0)
		{
			platformInitializer = UnityTools.externalTools.GetPlatformInitializer() as PlatformInitializer;
			goto IL_0029;
		}
		int num2 = 0;
		int num3 = -1406480527;
		goto IL_002e;
		IL_0029:
		num3 = -1406480524;
		goto IL_002e;
		IL_002e:
		Type type = default(Type);
		while (true)
		{
			switch (num3 ^ -1406480528)
			{
			case 0:
				break;
			case 4:
				if (platformInitializer == null)
				{
					num3 = -1406480523;
					continue;
				}
				return platformInitializer.Initialize(P_2);
			case 2:
			{
				Assembly assembly = P_1[num2];
				if (assembly != null && assembly.FullName.StartsWith(P_0, StringComparison.OrdinalIgnoreCase))
				{
					type = assembly.GetType("Rewired.InputManagers.Initializer");
					num3 = -1406480525;
					continue;
				}
				goto IL_00c2;
			}
			case 5:
				return null;
			case 3:
				if (type != null)
				{
					PlatformInitializer platformInitializer2 = noPeGSAxGdsrihtCOdnLGxFlZbq(type);
					if (platformInitializer2 == null)
					{
						return null;
					}
					return platformInitializer2.Initialize(P_2);
				}
				goto IL_00c2;
			default:
				{
					if (num2 >= num)
					{
						return null;
					}
					goto case 2;
				}
				IL_00c2:
				num2++;
				num3 = -1406480527;
				continue;
			}
			break;
		}
		goto IL_0029;
	}

	public static object YRWDvqEvCTLNYmWCOoePtbzsTOva(string P_0, string P_1)
	{
		List<Assembly> list = bPyzdopXoFWEkGXwSpIltgBKdcLi;
		if (list == null)
		{
			goto IL_000c;
		}
		int num = list.Count;
		goto IL_00e0;
		IL_0091:
		PlatformInitializer platformInitializer = default(PlatformInitializer);
		if (platformInitializer == null)
		{
			return null;
		}
		return platformInitializer.CreateTool(P_1);
		IL_000c:
		int num2 = -818818242;
		goto IL_0011;
		IL_0011:
		int num3 = default(int);
		int num4 = default(int);
		while (true)
		{
			switch (num2 ^ -818818241)
			{
			case 2:
				break;
			case 6:
				goto IL_003d;
			case 5:
				goto IL_0052;
			case 3:
				goto IL_0091;
			case 4:
				goto IL_00ae;
			case 1:
				goto IL_00d7;
			default:
				return null;
			}
			break;
			IL_0052:
			Assembly assembly = list[num3];
			if (assembly != null && assembly.FullName.StartsWith(P_0, StringComparison.OrdinalIgnoreCase))
			{
				Type type = assembly.GetType("Rewired.InputManagers.Initializer");
				if (type != null)
				{
					platformInitializer = noPeGSAxGdsrihtCOdnLGxFlZbq(type);
					num2 = -818818244;
					continue;
				}
			}
			num3++;
			num2 = -818818247;
			continue;
			IL_003d:
			int num5;
			if (num3 >= num4)
			{
				num2 = -818818241;
				num5 = num2;
			}
			else
			{
				num2 = -818818246;
				num5 = num2;
			}
		}
		goto IL_000c;
		IL_00d7:
		num = 0;
		goto IL_00e0;
		IL_00e0:
		num4 = num;
		if (num4 != 0)
		{
			num3 = 0;
			num2 = -818818247;
		}
		else
		{
			num2 = -818818245;
		}
		goto IL_0011;
		IL_00ae:
		PlatformInitializer platformInitializer2 = UnityTools.externalTools.GetPlatformInitializer() as PlatformInitializer;
		if (platformInitializer2 == null)
		{
			return null;
		}
		return platformInitializer2.CreateTool(P_1);
	}

	public static PlatformInitializer noPeGSAxGdsrihtCOdnLGxFlZbq(Type P_0)
	{
		PlatformInitializer result = default(PlatformInitializer);
		try
		{
			object obj = P_0.InvokeMember("GetPlatformInitializer", BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod, null, null, null);
			while (true)
			{
				IL_0014:
				int num = -634396701;
				while (true)
				{
					switch (num ^ -634396702)
					{
					case 0:
						break;
					default:
						goto end_IL_0019;
					case 1:
						goto IL_0032;
					case 2:
						goto end_IL_0019;
					}
					goto IL_0014;
					IL_0032:
					result = obj as PlatformInitializer;
					num = -634396704;
					continue;
					end_IL_0019:
					break;
				}
				break;
			}
		}
		catch
		{
			result = null;
		}
		return result;
	}
}
