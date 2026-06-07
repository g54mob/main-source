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

internal static class IdRpivuosRElvZpXQUPVXhgAeUF
{
	private static class LaVGTXHqNmnddoRclQRXhYvvVmZ
	{
		private static class hGuLBLUnVPJHfrncRFOFmPuNVax
		{
			public static byte[] XUFaYjEgSBhdSQKzPulrMQDsezGs(TextAsset P_0, long P_1)
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
				return XUFaYjEgSBhdSQKzPulrMQDsezGs(bytes, P_1);
			}

			public static byte[] XUFaYjEgSBhdSQKzPulrMQDsezGs(byte[] P_0, long P_1)
			{
				byte[] bytes = BitConverter.GetBytes(P_1);
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				while (true)
				{
					int num = 1951543385;
					while (true)
					{
						switch (num ^ 0x74523058)
						{
						case 2:
							break;
						case 1:
							goto IL_002b;
						default:
						{
							dESCryptoServiceProvider.IV = bytes;
							ICryptoTransform transform = dESCryptoServiceProvider.CreateDecryptor();
							byte[] array = null;
							using (MemoryStream stream = new MemoryStream(P_0))
							{
								MemoryStream memoryStream = new MemoryStream();
								try
								{
									using (CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Read))
									{
										byte[] array2 = new byte[4096];
										int num2 = cryptoStream.Read(array2, 0, array2.Length);
										while (num2 > 0)
										{
											while (true)
											{
												memoryStream.Write(array2, 0, num2);
												num2 = cryptoStream.Read(array2, 0, array2.Length);
												int num3 = 1951543386;
												while (true)
												{
													switch (num3 ^ 0x74523058)
													{
													case 0:
														num3 = 1951543385;
														continue;
													case 1:
														break;
													default:
														goto end_IL_009f;
													}
													break;
												}
												continue;
												end_IL_009f:
												break;
											}
										}
										cryptoStream.Flush();
									}
									return memoryStream.ToArray();
								}
								finally
								{
									if (memoryStream != null)
									{
										while (true)
										{
											IL_00ea:
											int num4 = 1951543386;
											while (true)
											{
												switch (num4 ^ 0x74523058)
												{
												case 0:
													break;
												default:
													goto end_IL_00ef;
												case 2:
													goto IL_0108;
												case 1:
													goto end_IL_00ef;
												}
												goto IL_00ea;
												IL_0108:
												((IDisposable)memoryStream).Dispose();
												num4 = 1951543385;
												continue;
												end_IL_00ef:
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
						IL_002b:
						dESCryptoServiceProvider.Key = bytes;
						num = 1951543384;
					}
				}
			}

			private static byte[] XUFaYjEgSBhdSQKzPulrMQDsezGs(byte[] P_0, string P_1)
			{
				DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
				ICryptoTransform transform = default(ICryptoTransform);
				while (true)
				{
					int num = 309935779;
					while (true)
					{
						switch (num ^ 0x12793EA2)
						{
						case 0:
							break;
						case 1:
							goto IL_0024;
						default:
						{
							int num2 = 0;
							byte[] array = null;
							using (Stream stream = FCDhrWiztNpDboOEdVYehiNaZVr(P_1, Encoding.ASCII))
							{
								using (CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Read))
								{
									array = new byte[cryptoStream.Length];
									while (true)
									{
										int num3 = 309935779;
										while (true)
										{
											switch (num3 ^ 0x12793EA2)
											{
											case 3:
												break;
											case 1:
												num3 = 309935778;
												continue;
											case 2:
												num2 += 4096;
												num3 = 309935778;
												continue;
											default:
												if (cryptoStream.Read(array, num2, 4096) <= 0)
												{
													return array;
												}
												goto case 2;
											}
											break;
										}
									}
								}
							}
						}
						}
						break;
						IL_0024:
						dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(P_1);
						dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(P_1);
						transform = dESCryptoServiceProvider.CreateDecryptor();
						num = 309935776;
					}
				}
			}

			public static Stream FCDhrWiztNpDboOEdVYehiNaZVr(string P_0, Encoding P_1)
			{
				MemoryStream memoryStream = new MemoryStream();
				StreamWriter streamWriter = new StreamWriter(memoryStream, P_1);
				streamWriter.Write(P_0);
				streamWriter.Flush();
				memoryStream.Position = 0L;
				return memoryStream;
			}
		}

		private const string VOZDdNDwSoRIamaXiYApanKWnAyy = "Rewired.Decrypter.bin";

		public static List<Assembly> YOaHuAFvJjGIBKfJdGQRaVREucN(List<TextAsset> P_0, bool P_1, string P_2, long P_3)
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
						XHkYTkfeNsjCHszviJVXMtnggIj(manifestResourceStream, memoryStream);
						array = memoryStream.ToArray();
					}
					finally
					{
						if (manifestResourceStream != null)
						{
							while (true)
							{
								IL_002d:
								int num = 1195276857;
								while (true)
								{
									switch (num ^ 0x473E7A3B)
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
									num = 1195276858;
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
							int num2 = 1195276858;
							while (true)
							{
								switch (num2 ^ 0x473E7A3B)
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
								num2 = 1195276859;
								continue;
								end_IL_0063:
								break;
							}
							break;
						}
					}
				}
				byte[] rawAssembly = hGuLBLUnVPJHfrncRFOFmPuNVax.XUFaYjEgSBhdSQKzPulrMQDsezGs(array, P_3);
				Assembly assembly = Assembly.Load(rawAssembly);
				long num3 = ekoRJFMSCAulgzFLmbCwhQuzicL(assembly, P_3);
				return YOaHuAFvJjGIBKfJdGQRaVREucN(P_0, P_1, num3);
			}
			catch
			{
				return null;
			}
		}

		private static void XHkYTkfeNsjCHszviJVXMtnggIj(Stream P_0, Stream P_1)
		{
			byte[] array = new byte[32768];
			int count;
			while ((count = P_0.Read(array, 0, array.Length)) > 0)
			{
				while (true)
				{
					P_1.Write(array, 0, count);
					int num = 659172196;
					while (true)
					{
						switch (num ^ 0x274A2B65)
						{
						case 0:
							num = 659172199;
							continue;
						case 2:
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

		private static long ekoRJFMSCAulgzFLmbCwhQuzicL(Assembly P_0, long P_1)
		{
			long result = default(long);
			try
			{
				Type type = P_0.GetType("Rewired.Security.KeyDecrypter");
				result = (long)type.InvokeMember("Decrypt", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, null, new object[2] { "MU>SOe2)EH[T<)gNSVyMG.\\gO|q>{]!h&,4A(ty{QbSXT@j6V<n^],cupp3t5[)qL?B&SL:fv^8s.YLA,?qZ98A0,wPS%~j>'rXVep66'&6<IxB[mY!L}b@:LRB?!)*<lV%Gn$5K'UF<+,El)OIYzM[+2FElC1AZ^?nU,k?x~~g8eGTUim8aJm.Kv|8qEDn|xI&4mU?^Y!L?bOZ|SD7b};Ya4^?/kOE93S:)6h:!0JX+?88$l8X+9#km1$zV:H\\AlFmPmmJ44]4gS{sk3+e/+Cx1^4b,P^agN^P_e{k\\Z@SVs7,w)b]Ll^/ufmPr#wEt;viv'&|a1w8.~/CKw%RE,!O{RlruVDPxh>3;2;NySeW*Niu%zCs^<KplfF>@JWG47z3*JJ>xHQ`!a*9*0uL4Z`'?o\\|)X].UMa4649kDQozevQcHBMg.+l'0:I+z{JYf5VxhhU}:Ft62SGEs}_Ufx0o$wxoe<AF8Y_0fMwlSu3]oqN|pUEPXQ|(A6%],*s/e+/2mR|&G>A|J18!0&jvrv)4P%Lr2&(i*77v!?E1EJ),)(SPuY7lfi5zm&s!tp_U$hj6WK8jL`L)cEFw4Ukg^9zR`fO>|cg3:]GmkW)Kc^K`YAM(`KxI%PG;?H\\f[y[p^mChqGT#_&(/Cl$}/4mPVtCRMpsBtggTl$$9&w7]i1?ncp;JDk9cZhyzDPXg#7[b#[][bZ@$4$,mD#Si'1$%bZkxw]Fn#tf<14SQPEN,lmL%:<8f1bMax{/5T`nF$f!1iOJ4gA\\7&9ZU3zl/hGz'`>Tu)CwL|hZjYBgT<kOQA't[24~&eRFX89Rw8H'gWOwShCxqC|wy1>Sqi]#GfO:!SRwsLFJR(0)p:3R[hk4>v*]VPwpWZ?f;V5Jn4j`^UxSaKL,B6tFK0vqe'xY#uo3PL\\MkkY%;>n83GKXLwz~t,orJx71sHIH}JlX!$Pz'[Ok\\*AKB&E5J>jqOA~^1`7]n&,[42PBaq]:Z!+zG%kx%5C\\F[BT;}a4}UX#%eEm0C&A+@x0&{kl`!YW(97S!~v7KF*0@44x8x4bR\\.G<1#'[#y4pkSx^,\\qf#YEy*CFCg$u?nZ*fAn`t6<r?H!:;$F3R61h&$.3~8AP\\F,QEsJ@|.h,o#YW5e7$i8to{P%BO%rXKqZ\\ut<hY6RE7YM|v#]NnWB'BMYUsr[T~LC&(Y?)xVbl`T:^)<p{lajJUghu<C`*){`fK5D>jL$/vv[g}IoFvFD`83E4<\\3S'DQrX<!w8a+cYZWRmHtOscY(DT&2w`}WBrGf2$<\\.'1;'g/MKLBOH9;1f|*2T[wnQL^e[lROs2tur?W!)U/1|u$\\j^W1I1xA]i8TGkGU5x(`iD[#<>woZFr:HTmM)Tfh+<8uh(fi_rDU$x[`ZU%*qr?~2^8Hp]pQczbLGuy~b/qrG&#j*I;5{yUH]%/'j>iq{ya+08xrVC1FsIx?&c.8)6ZTux<66!,}l(XZj^Db_vH+~U0/;'DmIJMs&V2/nRD}Zqb,K`2CscXo$8EO|xr<]xz,9$h{)T*U_4J}Zzao*7w;}kp7)%}Of1'x.&kaj'%bTJXu;<Zfg!]`<*]4i$DYqZH^9RMo`+{stC'i[x`PKPPGou6xcr4Cz0NmXS`)Y@7S}npvE&*M|QOknF!PhUk!i,)5Zh0^7~x%#r8Y.'U^)_TAQ8QG,g\\#b%H7#'#.nP3DeuNy7G>s)f_:.G6.H2XBWDa7{$EK([&b^2|yc<h}om,@tCZ#K>;)4x`xM.@CsY$#S^,*e%0Ml$Y>m0CE6D:?8K}_Ml\\shxlAF&S:_ikAEmJI5|W<<o?fO9eIRN8~Kw:[tvOX3LK*C[^;J^Y[Vaw9QAA]n:`s,@/#F1|4ge@.4Z}vYp*QXuMEUmL.|aB}M?'5eEtYfpc!VW;#_J:[l.}TLTk|XE_&E0Pf%$\\##rsp$+g$fJWb8A$hpe90E\\]u3Mq9F/?.Ex<#^]6+j)qB~oLsn//_?F7.``BEUW}eXkBc+m.?m6JF2(bo&pmFS_{42J+T9%pRxm`3K9./LYao~3a4jY&HHj?/k,l<:0sN(4vY:8J#CVeG(n_tuH)`i^#,c&0}P*iywKAU|U}I`w9\\[`xjt7Sf\\5iO5pf}*><$n3Mv0zLWFj7Yzwej[5p_L2yonxNY5Nc`;&SFWPXp1Y\\3[|}`TN\\kO^_sF!*<xrGr3<*K0,}H[@>Wb$sw.}wf/eu>R1TfAyS78@hf%lr`10'}0SDD#h4W*casB[WEQ%>K7439)Xy0<GXA[LFiqn\\,/hWnUm@8Hxv1YgHctRs!m7}?uTy@E1~LS3'uCk7[ONXsomzGg,clj9+8W6~P^;lZy%A#C:z2ybXs*`SYp~/'Uus;rtKYS^~BDr,q3'F7i|(\\?,\\@#0U,C^.#t^Da8Y+}ep,:s)>IX7Dzse2sw8^R_~|C7jANFaW7F.+ZWf>G^.MN_<T[7+8ED3`Mw3h3Tl!gktN?MRvFW1ymOz:rg2Xv|/+&z(ZrKGWr'v']m?FW|].Il|6B#fIX|lSJ^+,*ihNS`4O@%%)}a0bgm0o'|yVvU$X?@8j/vwyF<'J;[y3p'>a*m*hmB'Z{$bOaz,X.nFS5(]OSyF_x/XF^_IujNvYWDYgN&LpGjXn6E)Yzv~6>Aoq6r%lk}#G2,^.QTZ0j,q{ul,,1!tpB\\Ut_bQ!2l;CVY<78gz0W_I&mZ9A]N+k}{$^%c8#i^9sZ2G:w@s!h'ge)@KRW`M?T.ThUo#EPsHGEGM19@B\\.6h{&w8scf:2WK(e4Jv}O&6jJ%O7Tb0A/G7F68vfg}gegzO,S/PmNnOIwO8wJ(oG|Hgm$CO!t99`z0tTfWCOOU')P]brSeUUzp3<mK&a56oMM@hP.P16NGPCi\\|r<>fTKZ%vt~Z8tZ%@iP(.5e$C*}0VJGRh>S\\Y}E2]pkOF$'RW0$'CNmuV/]sQ8Q*LP\\7[/}Taq3zS_C./_%|T>IG/7\\]?UWMA9Fzzm9j2k><\\0$2D0T,lZ>y`s;~&p#$L$s>En'NnH.I", P_1 });
			}
			catch
			{
				while (true)
				{
					IL_0040:
					int num = 1460776969;
					while (true)
					{
						switch (num ^ 0x5711B00B)
						{
						case 0:
							break;
						default:
							goto end_IL_0045;
						case 2:
							goto IL_005e;
						case 1:
							goto end_IL_0045;
						}
						goto IL_0040;
						IL_005e:
						result = 0L;
						num = 1460776970;
						continue;
						end_IL_0045:
						break;
					}
					break;
				}
			}
			return result;
		}

		public static List<Assembly> YOaHuAFvJjGIBKfJdGQRaVREucN(List<TextAsset> P_0, bool P_1, long P_2 = 0L)
		{
			if (P_0 == null)
			{
				return null;
			}
			List<Assembly> list = new List<Assembly>();
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < P_0.Count)
				{
					num2 = 1313924888;
					num3 = num2;
				}
				else
				{
					num2 = 1313924891;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x4E50E719)
					{
					case 5:
						num2 = 1313924888;
						continue;
					case 3:
						break;
					case 4:
					{
						Assembly item = MfVqybgvEwrMLRZuPKZvJnSXzMM(P_0[num], P_1, P_2);
						list.Add(item);
						num2 = 1313924889;
						continue;
					}
					case 0:
						num++;
						num2 = 1313924890;
						continue;
					case 1:
					{
						int num4;
						if (!(P_0[num] == null))
						{
							num2 = 1313924893;
							num4 = num2;
						}
						else
						{
							num2 = 1313924889;
							num4 = num2;
						}
						continue;
					}
					default:
						return list;
					}
					break;
				}
			}
		}

		private static Assembly MfVqybgvEwrMLRZuPKZvJnSXzMM(TextAsset P_0, bool P_1, long P_2)
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
					rawAssembly = hGuLBLUnVPJHfrncRFOFmPuNVax.XUFaYjEgSBhdSQKzPulrMQDsezGs(P_0, P_2);
				}
				else
				{
					while (true)
					{
						IL_003f:
						rawAssembly = P_0.bytes;
						int num = -1535353496;
						while (true)
						{
							switch (num ^ -1535353496)
							{
							case 2:
								goto IL_0021;
							default:
								goto end_IL_0026;
							case 1:
								break;
							case 0:
								goto end_IL_0026;
							}
							goto IL_003f;
							IL_0021:
							num = -1535353495;
							continue;
							end_IL_0026:
							break;
						}
						break;
					}
				}
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

	private const string oRftqqEBJnUbIzkJiPqyjYHGObI = "Rewired.InputManagers.Initializer";

	private const string xCmbtmuopAEhaJDVzPHifvIXmeJ = "MU>SOe2)EH[T<)gNSVyMG.\\gO|q>{]!h&,4A(ty{QbSXT@j6V<n^],cupp3t5[)qL?B&SL:fv^8s.YLA,?qZ98A0,wPS%~j>'rXVep66'&6<IxB[mY!L}b@:LRB?!)*<lV%Gn$5K'UF<+,El)OIYzM[+2FElC1AZ^?nU,k?x~~g8eGTUim8aJm.Kv|8qEDn|xI&4mU?^Y!L?bOZ|SD7b};Ya4^?/kOE93S:)6h:!0JX+?88$l8X+9#km1$zV:H\\AlFmPmmJ44]4gS{sk3+e/+Cx1^4b,P^agN^P_e{k\\Z@SVs7,w)b]Ll^/ufmPr#wEt;viv'&|a1w8.~/CKw%RE,!O{RlruVDPxh>3;2;NySeW*Niu%zCs^<KplfF>@JWG47z3*JJ>xHQ`!a*9*0uL4Z`'?o\\|)X].UMa4649kDQozevQcHBMg.+l'0:I+z{JYf5VxhhU}:Ft62SGEs}_Ufx0o$wxoe<AF8Y_0fMwlSu3]oqN|pUEPXQ|(A6%],*s/e+/2mR|&G>A|J18!0&jvrv)4P%Lr2&(i*77v!?E1EJ),)(SPuY7lfi5zm&s!tp_U$hj6WK8jL`L)cEFw4Ukg^9zR`fO>|cg3:]GmkW)Kc^K`YAM(`KxI%PG;?H\\f[y[p^mChqGT#_&(/Cl$}/4mPVtCRMpsBtggTl$$9&w7]i1?ncp;JDk9cZhyzDPXg#7[b#[][bZ@$4$,mD#Si'1$%bZkxw]Fn#tf<14SQPEN,lmL%:<8f1bMax{/5T`nF$f!1iOJ4gA\\7&9ZU3zl/hGz'`>Tu)CwL|hZjYBgT<kOQA't[24~&eRFX89Rw8H'gWOwShCxqC|wy1>Sqi]#GfO:!SRwsLFJR(0)p:3R[hk4>v*]VPwpWZ?f;V5Jn4j`^UxSaKL,B6tFK0vqe'xY#uo3PL\\MkkY%;>n83GKXLwz~t,orJx71sHIH}JlX!$Pz'[Ok\\*AKB&E5J>jqOA~^1`7]n&,[42PBaq]:Z!+zG%kx%5C\\F[BT;}a4}UX#%eEm0C&A+@x0&{kl`!YW(97S!~v7KF*0@44x8x4bR\\.G<1#'[#y4pkSx^,\\qf#YEy*CFCg$u?nZ*fAn`t6<r?H!:;$F3R61h&$.3~8AP\\F,QEsJ@|.h,o#YW5e7$i8to{P%BO%rXKqZ\\ut<hY6RE7YM|v#]NnWB'BMYUsr[T~LC&(Y?)xVbl`T:^)<p{lajJUghu<C`*){`fK5D>jL$/vv[g}IoFvFD`83E4<\\3S'DQrX<!w8a+cYZWRmHtOscY(DT&2w`}WBrGf2$<\\.'1;'g/MKLBOH9;1f|*2T[wnQL^e[lROs2tur?W!)U/1|u$\\j^W1I1xA]i8TGkGU5x(`iD[#<>woZFr:HTmM)Tfh+<8uh(fi_rDU$x[`ZU%*qr?~2^8Hp]pQczbLGuy~b/qrG&#j*I;5{yUH]%/'j>iq{ya+08xrVC1FsIx?&c.8)6ZTux<66!,}l(XZj^Db_vH+~U0/;'DmIJMs&V2/nRD}Zqb,K`2CscXo$8EO|xr<]xz,9$h{)T*U_4J}Zzao*7w;}kp7)%}Of1'x.&kaj'%bTJXu;<Zfg!]`<*]4i$DYqZH^9RMo`+{stC'i[x`PKPPGou6xcr4Cz0NmXS`)Y@7S}npvE&*M|QOknF!PhUk!i,)5Zh0^7~x%#r8Y.'U^)_TAQ8QG,g\\#b%H7#'#.nP3DeuNy7G>s)f_:.G6.H2XBWDa7{$EK([&b^2|yc<h}om,@tCZ#K>;)4x`xM.@CsY$#S^,*e%0Ml$Y>m0CE6D:?8K}_Ml\\shxlAF&S:_ikAEmJI5|W<<o?fO9eIRN8~Kw:[tvOX3LK*C[^;J^Y[Vaw9QAA]n:`s,@/#F1|4ge@.4Z}vYp*QXuMEUmL.|aB}M?'5eEtYfpc!VW;#_J:[l.}TLTk|XE_&E0Pf%$\\##rsp$+g$fJWb8A$hpe90E\\]u3Mq9F/?.Ex<#^]6+j)qB~oLsn//_?F7.``BEUW}eXkBc+m.?m6JF2(bo&pmFS_{42J+T9%pRxm`3K9./LYao~3a4jY&HHj?/k,l<:0sN(4vY:8J#CVeG(n_tuH)`i^#,c&0}P*iywKAU|U}I`w9\\[`xjt7Sf\\5iO5pf}*><$n3Mv0zLWFj7Yzwej[5p_L2yonxNY5Nc`;&SFWPXp1Y\\3[|}`TN\\kO^_sF!*<xrGr3<*K0,}H[@>Wb$sw.}wf/eu>R1TfAyS78@hf%lr`10'}0SDD#h4W*casB[WEQ%>K7439)Xy0<GXA[LFiqn\\,/hWnUm@8Hxv1YgHctRs!m7}?uTy@E1~LS3'uCk7[ONXsomzGg,clj9+8W6~P^;lZy%A#C:z2ybXs*`SYp~/'Uus;rtKYS^~BDr,q3'F7i|(\\?,\\@#0U,C^.#t^Da8Y+}ep,:s)>IX7Dzse2sw8^R_~|C7jANFaW7F.+ZWf>G^.MN_<T[7+8ED3`Mw3h3Tl!gktN?MRvFW1ymOz:rg2Xv|/+&z(ZrKGWr'v']m?FW|].Il|6B#fIX|lSJ^+,*ihNS`4O@%%)}a0bgm0o'|yVvU$X?@8j/vwyF<'J;[y3p'>a*m*hmB'Z{$bOaz,X.nFS5(]OSyF_x/XF^_IujNvYWDYgN&LpGjXn6E)Yzv~6>Aoq6r%lk}#G2,^.QTZ0j,q{ul,,1!tpB\\Ut_bQ!2l;CVY<78gz0W_I&mZ9A]N+k}{$^%c8#i^9sZ2G:w@s!h'ge)@KRW`M?T.ThUo#EPsHGEGM19@B\\.6h{&w8scf:2WK(e4Jv}O&6jJ%O7Tb0A/G7F68vfg}gegzO,S/PmNnOIwO8wJ(oG|Hgm$CO!t99`z0tTfWCOOU')P]brSeUUzp3<mK&a56oMM@hP.P16NGPCi\\|r<>fTKZ%vt~Z8tZ%@iP(.5e$C*}0VJGRh>S\\Y}E2]pkOF$'RW0$'CNmuV/]sQ8Q*LP\\7[/}Taq3zS_C./_%|T>IG/7\\]?UWMA9Fzzm9j2k><\\0$2D0T,lZ>y`s;~&p#$L$s>En'NnH.I";

	private const long FpwXFhkkaHBjsbRhyFvKYGgvgYLt = -239732958399843948L;

	private static int eyAccQuUJoUUxLAdWrjDgYqimOY;

	private static int uiHKDIgvcOACxpqRUGTlrsFFSuT;

	private static int pDQvLhfVDPtveiEFdGbxBWXxnsm;

	private static string NcRLKZEZppVEjjGwuhijmJXPLIT = "Rewired/Internal/Data/enc.bin";

	private static List<Assembly> MzaEcbgTiROnDCedGiChHMHLYhYy;

	public static object dFyvOnKBbTYzKLbxHBbiIGdcrpeH(string P_0, List<TextAsset> P_1, ConfigVars P_2, bool P_3)
	{
		List<Assembly> list = LaVGTXHqNmnddoRclQRXhYvvVmZ.YOaHuAFvJjGIBKfJdGQRaVREucN(P_1, P_3, "MU>SOe2)EH[T<)gNSVyMG.\\gO|q>{]!h&,4A(ty{QbSXT@j6V<n^],cupp3t5[)qL?B&SL:fv^8s.YLA,?qZ98A0,wPS%~j>'rXVep66'&6<IxB[mY!L}b@:LRB?!)*<lV%Gn$5K'UF<+,El)OIYzM[+2FElC1AZ^?nU,k?x~~g8eGTUim8aJm.Kv|8qEDn|xI&4mU?^Y!L?bOZ|SD7b};Ya4^?/kOE93S:)6h:!0JX+?88$l8X+9#km1$zV:H\\AlFmPmmJ44]4gS{sk3+e/+Cx1^4b,P^agN^P_e{k\\Z@SVs7,w)b]Ll^/ufmPr#wEt;viv'&|a1w8.~/CKw%RE,!O{RlruVDPxh>3;2;NySeW*Niu%zCs^<KplfF>@JWG47z3*JJ>xHQ`!a*9*0uL4Z`'?o\\|)X].UMa4649kDQozevQcHBMg.+l'0:I+z{JYf5VxhhU}:Ft62SGEs}_Ufx0o$wxoe<AF8Y_0fMwlSu3]oqN|pUEPXQ|(A6%],*s/e+/2mR|&G>A|J18!0&jvrv)4P%Lr2&(i*77v!?E1EJ),)(SPuY7lfi5zm&s!tp_U$hj6WK8jL`L)cEFw4Ukg^9zR`fO>|cg3:]GmkW)Kc^K`YAM(`KxI%PG;?H\\f[y[p^mChqGT#_&(/Cl$}/4mPVtCRMpsBtggTl$$9&w7]i1?ncp;JDk9cZhyzDPXg#7[b#[][bZ@$4$,mD#Si'1$%bZkxw]Fn#tf<14SQPEN,lmL%:<8f1bMax{/5T`nF$f!1iOJ4gA\\7&9ZU3zl/hGz'`>Tu)CwL|hZjYBgT<kOQA't[24~&eRFX89Rw8H'gWOwShCxqC|wy1>Sqi]#GfO:!SRwsLFJR(0)p:3R[hk4>v*]VPwpWZ?f;V5Jn4j`^UxSaKL,B6tFK0vqe'xY#uo3PL\\MkkY%;>n83GKXLwz~t,orJx71sHIH}JlX!$Pz'[Ok\\*AKB&E5J>jqOA~^1`7]n&,[42PBaq]:Z!+zG%kx%5C\\F[BT;}a4}UX#%eEm0C&A+@x0&{kl`!YW(97S!~v7KF*0@44x8x4bR\\.G<1#'[#y4pkSx^,\\qf#YEy*CFCg$u?nZ*fAn`t6<r?H!:;$F3R61h&$.3~8AP\\F,QEsJ@|.h,o#YW5e7$i8to{P%BO%rXKqZ\\ut<hY6RE7YM|v#]NnWB'BMYUsr[T~LC&(Y?)xVbl`T:^)<p{lajJUghu<C`*){`fK5D>jL$/vv[g}IoFvFD`83E4<\\3S'DQrX<!w8a+cYZWRmHtOscY(DT&2w`}WBrGf2$<\\.'1;'g/MKLBOH9;1f|*2T[wnQL^e[lROs2tur?W!)U/1|u$\\j^W1I1xA]i8TGkGU5x(`iD[#<>woZFr:HTmM)Tfh+<8uh(fi_rDU$x[`ZU%*qr?~2^8Hp]pQczbLGuy~b/qrG&#j*I;5{yUH]%/'j>iq{ya+08xrVC1FsIx?&c.8)6ZTux<66!,}l(XZj^Db_vH+~U0/;'DmIJMs&V2/nRD}Zqb,K`2CscXo$8EO|xr<]xz,9$h{)T*U_4J}Zzao*7w;}kp7)%}Of1'x.&kaj'%bTJXu;<Zfg!]`<*]4i$DYqZH^9RMo`+{stC'i[x`PKPPGou6xcr4Cz0NmXS`)Y@7S}npvE&*M|QOknF!PhUk!i,)5Zh0^7~x%#r8Y.'U^)_TAQ8QG,g\\#b%H7#'#.nP3DeuNy7G>s)f_:.G6.H2XBWDa7{$EK([&b^2|yc<h}om,@tCZ#K>;)4x`xM.@CsY$#S^,*e%0Ml$Y>m0CE6D:?8K}_Ml\\shxlAF&S:_ikAEmJI5|W<<o?fO9eIRN8~Kw:[tvOX3LK*C[^;J^Y[Vaw9QAA]n:`s,@/#F1|4ge@.4Z}vYp*QXuMEUmL.|aB}M?'5eEtYfpc!VW;#_J:[l.}TLTk|XE_&E0Pf%$\\##rsp$+g$fJWb8A$hpe90E\\]u3Mq9F/?.Ex<#^]6+j)qB~oLsn//_?F7.``BEUW}eXkBc+m.?m6JF2(bo&pmFS_{42J+T9%pRxm`3K9./LYao~3a4jY&HHj?/k,l<:0sN(4vY:8J#CVeG(n_tuH)`i^#,c&0}P*iywKAU|U}I`w9\\[`xjt7Sf\\5iO5pf}*><$n3Mv0zLWFj7Yzwej[5p_L2yonxNY5Nc`;&SFWPXp1Y\\3[|}`TN\\kO^_sF!*<xrGr3<*K0,}H[@>Wb$sw.}wf/eu>R1TfAyS78@hf%lr`10'}0SDD#h4W*casB[WEQ%>K7439)Xy0<GXA[LFiqn\\,/hWnUm@8Hxv1YgHctRs!m7}?uTy@E1~LS3'uCk7[ONXsomzGg,clj9+8W6~P^;lZy%A#C:z2ybXs*`SYp~/'Uus;rtKYS^~BDr,q3'F7i|(\\?,\\@#0U,C^.#t^Da8Y+}ep,:s)>IX7Dzse2sw8^R_~|C7jANFaW7F.+ZWf>G^.MN_<T[7+8ED3`Mw3h3Tl!gktN?MRvFW1ymOz:rg2Xv|/+&z(ZrKGWr'v']m?FW|].Il|6B#fIX|lSJ^+,*ihNS`4O@%%)}a0bgm0o'|yVvU$X?@8j/vwyF<'J;[y3p'>a*m*hmB'Z{$bOaz,X.nFS5(]OSyF_x/XF^_IujNvYWDYgN&LpGjXn6E)Yzv~6>Aoq6r%lk}#G2,^.QTZ0j,q{ul,,1!tpB\\Ut_bQ!2l;CVY<78gz0W_I&mZ9A]N+k}{$^%c8#i^9sZ2G:w@s!h'ge)@KRW`M?T.ThUo#EPsHGEGM19@B\\.6h{&w8scf:2WK(e4Jv}O&6jJ%O7Tb0A/G7F68vfg}gegzO,S/PmNnOIwO8wJ(oG|Hgm$CO!t99`z0tTfWCOOU')P]brSeUUzp3<mK&a56oMM@hP.P16NGPCi\\|r<>fTKZ%vt~Z8tZ%@iP(.5e$C*}0VJGRh>S\\Y}E2]pkOF$'RW0$'CNmuV/]sQ8Q*LP\\7[/}Taq3zS_C./_%|T>IG/7\\]?UWMA9Fzzm9j2k><\\0$2D0T,lZ>y`s;~&p#$L$s>En'NnH.I", -239732958399843948L);
		int num = ((list != null) ? list.Count : 0);
		int pDQvLhfVDPtveiEFdGbxBWXxnsm2 = pDQvLhfVDPtveiEFdGbxBWXxnsm;
		pDQvLhfVDPtveiEFdGbxBWXxnsm = num;
		int num2 = 0;
		while (true)
		{
			int num3;
			int num4;
			if (num2 < num)
			{
				num3 = 2061333698;
				num4 = num3;
			}
			else
			{
				num3 = 2061333697;
				num4 = num3;
			}
			while (true)
			{
				switch (num3 ^ 0x7ADD74C0)
				{
				case 0:
					num3 = 2061333698;
					continue;
				case 2:
				{
					Assembly assembly = list[num2];
					if ((object)assembly != null && assembly.FullName.StartsWith(P_0, StringComparison.OrdinalIgnoreCase))
					{
						Type type = assembly.GetType("Rewired.InputManagers.Initializer");
						if ((object)type != null)
						{
							PlatformInitializer platformInitializer = SqVplPcgjfPgMZTmolKprflrGCj(type);
							if (platformInitializer == null)
							{
								return null;
							}
							return platformInitializer.Initialize(P_2);
						}
					}
					num2++;
					num3 = 2061333699;
					continue;
				}
				case 3:
					break;
				default:
					return null;
				}
				break;
			}
		}
	}

	public static object dFyvOnKBbTYzKLbxHBbiIGdcrpeH(string P_0, List<Assembly> P_1, ConfigVars P_2)
	{
		MzaEcbgTiROnDCedGiChHMHLYhYy = P_1;
		int num = ((P_1 != null) ? P_1.Count : 0);
		PlatformInitializer platformInitializer = default(PlatformInitializer);
		if (num == 0)
		{
			platformInitializer = UnityTools.externalTools.GetPlatformInitializer() as PlatformInitializer;
			goto IL_0029;
		}
		int num2 = 0;
		int num3 = -457189766;
		goto IL_002e;
		IL_0029:
		num3 = -457189769;
		goto IL_002e;
		IL_002e:
		Assembly assembly = default(Assembly);
		PlatformInitializer platformInitializer2 = default(PlatformInitializer);
		object result = default(object);
		while (true)
		{
			switch (num3 ^ -457189774)
			{
			case 7:
				break;
			case 3:
				assembly = P_1[num2];
				num3 = -457189772;
				continue;
			case 6:
				if ((object)assembly != null)
				{
					num3 = -457189773;
					continue;
				}
				goto IL_008c;
			case 4:
				if (platformInitializer2 == null)
				{
					return null;
				}
				return platformInitializer2.Initialize(P_2);
			case 1:
				if (assembly.FullName.StartsWith(P_0, StringComparison.OrdinalIgnoreCase))
				{
					num3 = -457189776;
					continue;
				}
				goto IL_008c;
			case 2:
			{
				Type type = assembly.GetType("Rewired.InputManagers.Initializer");
				if ((object)type != null)
				{
					platformInitializer2 = SqVplPcgjfPgMZTmolKprflrGCj(type);
					num3 = -457189770;
					continue;
				}
				goto IL_008c;
			}
			case 0:
				return result;
			case 5:
				if (platformInitializer == null)
				{
					return null;
				}
				result = platformInitializer.Initialize(P_2);
				num3 = -457189774;
				continue;
			default:
				{
					if (num2 >= num)
					{
						return null;
					}
					goto case 3;
				}
				IL_008c:
				num2++;
				num3 = -457189766;
				continue;
			}
			break;
		}
		goto IL_0029;
	}

	public static object lPUTufBSEBrmzgsDsKmRQblmXBu(string P_0, string P_1)
	{
		List<Assembly> mzaEcbgTiROnDCedGiChHMHLYhYy = MzaEcbgTiROnDCedGiChHMHLYhYy;
		int num = ((mzaEcbgTiROnDCedGiChHMHLYhYy != null) ? mzaEcbgTiROnDCedGiChHMHLYhYy.Count : 0);
		if (num == 0)
		{
			goto IL_0016;
		}
		int num2 = 0;
		int num3 = 583815176;
		goto IL_001b;
		IL_0016:
		num3 = 583815177;
		goto IL_001b;
		IL_001b:
		PlatformInitializer platformInitializer = default(PlatformInitializer);
		while (true)
		{
			switch (num3 ^ 0x22CC500B)
			{
			case 0:
				break;
			case 2:
			{
				PlatformInitializer platformInitializer2 = UnityTools.externalTools.GetPlatformInitializer() as PlatformInitializer;
				if (platformInitializer2 == null)
				{
					num3 = 583815183;
					continue;
				}
				return platformInitializer2.CreateTool(P_1);
			}
			case 4:
				return null;
			case 5:
			{
				Assembly assembly = mzaEcbgTiROnDCedGiChHMHLYhYy[num2];
				if ((object)assembly != null && assembly.FullName.StartsWith(P_0, StringComparison.OrdinalIgnoreCase))
				{
					Type type = assembly.GetType("Rewired.InputManagers.Initializer");
					if ((object)type != null)
					{
						platformInitializer = SqVplPcgjfPgMZTmolKprflrGCj(type);
						num3 = 583815178;
						continue;
					}
				}
				num2++;
				num3 = 583815176;
				continue;
			}
			case 1:
				if (platformInitializer == null)
				{
					return null;
				}
				return platformInitializer.CreateTool(P_1);
			default:
				if (num2 >= num)
				{
					return null;
				}
				goto case 5;
			}
			break;
		}
		goto IL_0016;
	}

	public static PlatformInitializer SqVplPcgjfPgMZTmolKprflrGCj(Type P_0)
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
