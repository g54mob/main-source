using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal static class ThreadSafeUnityInput
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Keyboard
		{
			private const int IXoasCMsBdCawyQigelghUvoTwC = 132;

			public static readonly int keyValueIndex_Escape;

			public static readonly int keyValueIndex_Menu;

			public static readonly int keyValueIndex_F2;

			public static readonly int keyValueIndex_UpArrow;

			public static readonly int keyValueIndex_RightArrow;

			public static readonly int keyValueIndex_DownArrow;

			public static readonly int keyValueIndex_LeftArrow;

			private static readonly int[] fyfjkuFDmwGYaQxBhpAQjMHOmKt;

			private readonly int oflttKRKBnGddBzPzwGiIzxYEuMQ;

			private readonly int[] kTUUBVucSwcLTEaIKJUSKCfRNHua;

			private readonly bool[] yghEffJvJbdbfbnBGqRVBOCdycJl;

			private bool gmbIkkevNmPVGSTIwKcAwoPYANrc;

			private int sGYPkzHbItlusiKtRalxlmthdZl;

			private readonly bool mXnbDodmeHqYEXAgmqSCAqLZXiZe;

			public bool enabled
			{
				get
				{
					return gmbIkkevNmPVGSTIwKcAwoPYANrc;
				}
				set
				{
					if (value == gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						goto IL_0009;
					}
					goto IL_004c;
					IL_0009:
					int num = -1009248517;
					goto IL_000e;
					IL_000e:
					while (true)
					{
						switch (num ^ -1009248519)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							return;
						case 1:
							if (!gmbIkkevNmPVGSTIwKcAwoPYANrc)
							{
								Clear();
								num = -1009248515;
								continue;
							}
							return;
						case 3:
							goto IL_004c;
						case 4:
							return;
						}
						break;
					}
					goto IL_0009;
					IL_004c:
					gmbIkkevNmPVGSTIwKcAwoPYANrc = value;
					num = -1009248520;
					goto IL_000e;
				}
			}

			public bool monitoring
			{
				get
				{
					return sGYPkzHbItlusiKtRalxlmthdZl > 0;
				}
			}

			public int keyCount
			{
				get
				{
					return 132;
				}
			}

			static Keyboard()
			{
				if (!UnityTools.isAndroidPlatform)
				{
					return;
				}
				int[] keyboardKeyValues = default(int[]);
				int[] array = default(int[]);
				while (true)
				{
					int num = 1997120178;
					while (true)
					{
						switch (num ^ 0x7709A2B3)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							keyboardKeyValues = Consts._keyboardKeyValues;
							array = new int[7];
							num = 1997120183;
							continue;
						case 4:
							array[0] = (keyValueIndex_Escape = ArrayTools.IndexOf(keyboardKeyValues, 27));
							num = 1997120177;
							continue;
						case 2:
							array[1] = (keyValueIndex_Menu = ArrayTools.IndexOf(keyboardKeyValues, 319));
							array[2] = (keyValueIndex_F2 = ArrayTools.IndexOf(keyboardKeyValues, 283));
							array[3] = (keyValueIndex_UpArrow = ArrayTools.IndexOf(keyboardKeyValues, 273));
							array[4] = (keyValueIndex_RightArrow = ArrayTools.IndexOf(keyboardKeyValues, 275));
							array[5] = (keyValueIndex_DownArrow = ArrayTools.IndexOf(keyboardKeyValues, 274));
							array[6] = (keyValueIndex_LeftArrow = ArrayTools.IndexOf(keyboardKeyValues, 276));
							fyfjkuFDmwGYaQxBhpAQjMHOmKt = array;
							num = 1997120176;
							continue;
						case 3:
							return;
						}
						break;
					}
				}
			}

			public Keyboard()
			{
				int num4 = default(int);
				int num3 = default(int);
				int[] keyboardKeyValues = default(int[]);
				int num2 = default(int);
				while (true)
				{
					int num = -310231092;
					while (true)
					{
						switch (num ^ -310231090)
						{
						case 8:
							break;
						case 1:
							num4++;
							num = -310231094;
							continue;
						case 5:
							num3 = keyboardKeyValues.Length;
							num4 = 0;
							num = -310231094;
							continue;
						case 9:
							kTUUBVucSwcLTEaIKJUSKCfRNHua[keyboardKeyValues[num2]] = num2;
							num2++;
							num = -310231096;
							continue;
						case 0:
							if (keyboardKeyValues[num4] > oflttKRKBnGddBzPzwGiIzxYEuMQ)
							{
								oflttKRKBnGddBzPzwGiIzxYEuMQ = keyboardKeyValues[num4];
								num = -310231089;
								continue;
							}
							goto case 1;
						case 3:
							ArrayTools.Fill(kTUUBVucSwcLTEaIKJUSKCfRNHua, -1);
							num2 = 0;
							num = -310231096;
							continue;
						case 7:
							kTUUBVucSwcLTEaIKJUSKCfRNHua = new int[oflttKRKBnGddBzPzwGiIzxYEuMQ + 1];
							num = -310231091;
							continue;
						case 4:
						{
							int num5;
							if (num4 >= num3)
							{
								num = -310231095;
								num5 = num;
							}
							else
							{
								num = -310231090;
								num5 = num;
							}
							continue;
						}
						case 2:
							yghEffJvJbdbfbnBGqRVBOCdycJl = new bool[132];
							keyboardKeyValues = Consts._keyboardKeyValues;
							num = -310231093;
							continue;
						default:
							if (num2 >= num3)
							{
								return;
							}
							goto case 9;
						}
						break;
					}
				}
			}

			public void Initialize()
			{
				if (sGYPkzHbItlusiKtRalxlmthdZl != 0)
				{
					while (true)
					{
						int num = -1051723510;
						while (true)
						{
							switch (num ^ -1051723509)
							{
							case 0:
								break;
							case 1:
								IIPfiHxtIvmduMEHyrjbnbrxpRz();
								num = -1051723511;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
						}
						continue;
						end_IL_0008:
						break;
					}
				}
				fdRsbcBkTGgTdtCzqFoIhThTjIkI();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (sGYPkzHbItlusiKtRalxlmthdZl == 0)
				{
					return;
				}
				int[] keyboardKeyValues = default(int[]);
				int num = default(int);
				while (true)
				{
					IL_014b:
					int num2;
					if (gmbIkkevNmPVGSTIwKcAwoPYANrc)
					{
						keyboardKeyValues = Consts._keyboardKeyValues;
						num = 0;
						num2 = -1524834063;
						goto IL_0011;
					}
					goto IL_010e;
					IL_0011:
					while (true)
					{
						switch (num2 ^ -1524834063)
						{
						case 2:
							num2 = -1524834064;
							continue;
						default:
							return;
						case 6:
							yghEffJvJbdbfbnBGqRVBOCdycJl[keyValueIndex_DownArrow] = GetKey(KeyCode.DownArrow);
							num2 = -1524834062;
							continue;
						case 5:
							yghEffJvJbdbfbnBGqRVBOCdycJl[keyValueIndex_Escape] = GetKey(KeyCode.Escape);
							yghEffJvJbdbfbnBGqRVBOCdycJl[keyValueIndex_Menu] = GetKey(KeyCode.Menu);
							yghEffJvJbdbfbnBGqRVBOCdycJl[keyValueIndex_F2] = GetKey(KeyCode.F2);
							yghEffJvJbdbfbnBGqRVBOCdycJl[keyValueIndex_UpArrow] = GetKey(KeyCode.UpArrow);
							yghEffJvJbdbfbnBGqRVBOCdycJl[keyValueIndex_RightArrow] = GetKey(KeyCode.RightArrow);
							num2 = -1524834057;
							continue;
						case 8:
							yghEffJvJbdbfbnBGqRVBOCdycJl[num] = Input.GetKey((KeyCode)keyboardKeyValues[num]);
							num++;
							num2 = -1524834063;
							continue;
						case 0:
							if (num >= 132)
							{
								return;
							}
							goto case 8;
						case 4:
							break;
						case 3:
							yghEffJvJbdbfbnBGqRVBOCdycJl[keyValueIndex_LeftArrow] = GetKey(KeyCode.LeftArrow);
							num2 = -1524834058;
							continue;
						case 1:
							goto IL_014b;
						case 7:
							return;
						}
						break;
					}
					goto IL_010e;
					IL_010e:
					int num3;
					if (mXnbDodmeHqYEXAgmqSCAqLZXiZe)
					{
						num2 = -1524834060;
						num3 = num2;
					}
					else
					{
						num2 = -1524834058;
						num3 = num2;
					}
					goto IL_0011;
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					goto IL_0006;
				}
				goto IL_0087;
				IL_0006:
				int num = -135414942;
				goto IL_000b;
				IL_000b:
				while (true)
				{
					switch (num ^ -135414941)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						sGYPkzHbItlusiKtRalxlmthdZl++;
						num = -135414938;
						continue;
					case 3:
						MEBdHwfwFCLlFRknCJdIdTOhHWCe();
						return;
					case 0:
						if (sGYPkzHbItlusiKtRalxlmthdZl == 0)
						{
							scqBeNZYtAunaCNxbqRLRHKcNmQ();
							num = -135414937;
							continue;
						}
						return;
					case 7:
						sGYPkzHbItlusiKtRalxlmthdZl = 0;
						HrNBRpeoDyTLxljTeSLBHeKAtSZg();
						num = -135414941;
						continue;
					case 6:
						goto IL_0087;
					case 5:
						goto IL_00b2;
					case 4:
						return;
					}
					break;
					IL_00b2:
					int num2;
					if (sGYPkzHbItlusiKtRalxlmthdZl != 1)
					{
						num = -135414937;
						num2 = num;
					}
					else
					{
						num = -135414944;
						num2 = num;
					}
				}
				goto IL_0006;
				IL_0087:
				sGYPkzHbItlusiKtRalxlmthdZl--;
				int num3;
				if (sGYPkzHbItlusiKtRalxlmthdZl >= 0)
				{
					num = -135414941;
					num3 = num;
				}
				else
				{
					num = -135414940;
					num3 = num;
				}
				goto IL_000b;
			}

			public bool GetKey(KeyCode keyCode)
			{
				if (sGYPkzHbItlusiKtRalxlmthdZl == 0)
				{
					nBtPddcmhIPtrLqrfcmUEQoeGsw();
					goto IL_000e;
				}
				int num;
				if ((uint)keyCode > (uint)oflttKRKBnGddBzPzwGiIzxYEuMQ)
				{
					num = -138585359;
					goto IL_0013;
				}
				return yghEffJvJbdbfbnBGqRVBOCdycJl[kTUUBVucSwcLTEaIKJUSKCfRNHua[(int)keyCode]];
				IL_000e:
				num = -138585358;
				goto IL_0013;
				IL_0013:
				switch (num ^ -138585360)
				{
				case 0:
					break;
				case 2:
					return false;
				default:
					return false;
				}
				goto IL_000e;
			}

			public void GetKeyValues(bool[] values)
			{
				if (sGYPkzHbItlusiKtRalxlmthdZl == 0)
				{
					goto IL_0008;
				}
				goto IL_0044;
				IL_0008:
				int num = -2022895093;
				goto IL_000d;
				IL_000d:
				switch (num ^ -2022895094)
				{
				case 3:
					break;
				case 1:
					nBtPddcmhIPtrLqrfcmUEQoeGsw();
					return;
				case 4:
					return;
				case 0:
					goto IL_0044;
				default:
					Array.Copy(yghEffJvJbdbfbnBGqRVBOCdycJl, values, 132);
					return;
				}
				goto IL_0008;
				IL_0044:
				if (values == null)
				{
					return;
				}
				int num2;
				if (values.Length >= 132)
				{
					num = -2022895096;
					num2 = num;
				}
				else
				{
					num = -2022895090;
					num2 = num;
				}
				goto IL_000d;
			}

			public void Clear()
			{
				if (mXnbDodmeHqYEXAgmqSCAqLZXiZe)
				{
					goto IL_0008;
				}
				goto IL_0068;
				IL_0008:
				int num = 619228200;
				goto IL_000d;
				IL_000d:
				int num2 = default(int);
				while (true)
				{
					switch (num ^ 0x24E8AC29)
					{
					case 8:
						break;
					default:
						return;
					case 2:
						return;
					case 3:
						goto IL_0049;
					case 5:
						goto IL_0068;
					case 1:
						num2 = 0;
						num = 619228206;
						continue;
					case 7:
						goto IL_0089;
					case 0:
						yghEffJvJbdbfbnBGqRVBOCdycJl[num2] = false;
						num = 619228205;
						continue;
					case 4:
						num2++;
						num = 619228206;
						continue;
					case 6:
						return;
					}
					break;
					IL_0089:
					int num3;
					if (num2 >= 132)
					{
						num = 619228203;
						num3 = num;
					}
					else
					{
						num = 619228202;
						num3 = num;
					}
					continue;
					IL_0049:
					int num4;
					if (Array.IndexOf(fyfjkuFDmwGYaQxBhpAQjMHOmKt, num2) < 0)
					{
						num = 619228201;
						num4 = num;
					}
					else
					{
						num = 619228205;
						num4 = num;
					}
				}
				goto IL_0008;
				IL_0068:
				Array.Clear(yghEffJvJbdbfbnBGqRVBOCdycJl, 0, 132);
				num = 619228207;
				goto IL_000d;
			}

			private void IIPfiHxtIvmduMEHyrjbnbrxpRz()
			{
				Array.Clear(yghEffJvJbdbfbnBGqRVBOCdycJl, 0, 132);
			}

			private void fdRsbcBkTGgTdtCzqFoIhThTjIkI()
			{
				sGYPkzHbItlusiKtRalxlmthdZl = 0;
				gmbIkkevNmPVGSTIwKcAwoPYANrc = true;
			}

			private void MEBdHwfwFCLlFRknCJdIdTOhHWCe()
			{
			}

			private void scqBeNZYtAunaCNxbqRLRHKcNmQ()
			{
				IIPfiHxtIvmduMEHyrjbnbrxpRz();
			}

			private void nBtPddcmhIPtrLqrfcmUEQoeGsw()
			{
				Logger.LogWarning("You are trying to use Keyboard without incrementing the monitor count.", true);
			}

			private void HrNBRpeoDyTLxljTeSLBHeKAtSZg()
			{
				Logger.LogWarning("You are decrementing the Keyboard monitor count more than you are incrementing it.", true);
			}
		}

		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public sealed class Mouse
		{
			private const int VDaLjZYdsRIqheXEANPwCBhYDPo = 7;

			private const int XOnWiKThBydhDsxQmELHDhRZdPqb = 3;

			private readonly bool[] WXIRxjkGHEWEQMEDrfdCKrevQRBu;

			private readonly float[] zFkDvTbearAemKYGDCYZjNRbnaS;

			private int sGYPkzHbItlusiKtRalxlmthdZl;

			private Vector3 mrAVpUvWOqssYnhnOjgjGJxOlzJ;

			private bool bfmpCUQioMCtskMUzEtSEWLpWNZ;

			public bool monitoring
			{
				get
				{
					return sGYPkzHbItlusiKtRalxlmthdZl > 0;
				}
			}

			public Vector3 mousePosition
			{
				get
				{
					return mrAVpUvWOqssYnhnOjgjGJxOlzJ;
				}
			}

			public bool mousePresent
			{
				get
				{
					return bfmpCUQioMCtskMUzEtSEWLpWNZ;
				}
			}

			public Mouse()
			{
				WXIRxjkGHEWEQMEDrfdCKrevQRBu = new bool[7];
				zFkDvTbearAemKYGDCYZjNRbnaS = new float[3];
				fdRsbcBkTGgTdtCzqFoIhThTjIkI();
			}

			public void PostInitialize()
			{
				Update();
			}

			public void Update()
			{
				if (sGYPkzHbItlusiKtRalxlmthdZl == 0)
				{
					return;
				}
				int num3 = default(int);
				while (true)
				{
					int num = 0;
					int num2 = -299226241;
					while (true)
					{
						switch (num2 ^ -299226241)
						{
						case 8:
							num2 = -299226242;
							continue;
						default:
							return;
						case 1:
							break;
						case 6:
							num3++;
							num2 = -299226244;
							continue;
						case 3:
						{
							int num5;
							if (num3 >= 3)
							{
								num2 = -299226245;
								num5 = num2;
							}
							else
							{
								num2 = -299226246;
								num5 = num2;
							}
							continue;
						}
						case 9:
							num3 = 0;
							num2 = -299226244;
							continue;
						case 4:
							mrAVpUvWOqssYnhnOjgjGJxOlzJ = Input.mousePosition;
							bfmpCUQioMCtskMUzEtSEWLpWNZ = Input.mousePresent;
							num2 = -299226243;
							continue;
						case 7:
							WXIRxjkGHEWEQMEDrfdCKrevQRBu[num] = Input.GetButton(Consts.mouseButtonUnityNames[num]);
							num++;
							num2 = -299226241;
							continue;
						case 0:
						{
							int num4;
							if (num >= 7)
							{
								num2 = -299226250;
								num4 = num2;
							}
							else
							{
								num2 = -299226248;
								num4 = num2;
							}
							continue;
						}
						case 5:
							zFkDvTbearAemKYGDCYZjNRbnaS[num3] = Input.GetAxisRaw(Consts.mouseAxisUnityNames[num3]);
							num2 = -299226247;
							continue;
						case 2:
							return;
						}
						break;
					}
				}
			}

			public void Monitor(bool state)
			{
				if (state)
				{
					sGYPkzHbItlusiKtRalxlmthdZl++;
					if (sGYPkzHbItlusiKtRalxlmthdZl == 1)
					{
						MEBdHwfwFCLlFRknCJdIdTOhHWCe();
						goto IL_0020;
					}
					return;
				}
				goto IL_005f;
				IL_0084:
				int num;
				if (sGYPkzHbItlusiKtRalxlmthdZl == 0)
				{
					scqBeNZYtAunaCNxbqRLRHKcNmQ();
					num = -1565735290;
					goto IL_0025;
				}
				return;
				IL_005f:
				sGYPkzHbItlusiKtRalxlmthdZl--;
				if (sGYPkzHbItlusiKtRalxlmthdZl < 0)
				{
					sGYPkzHbItlusiKtRalxlmthdZl = 0;
					num = -1565735294;
					goto IL_0025;
				}
				goto IL_0084;
				IL_0020:
				num = -1565735295;
				goto IL_0025;
				IL_0025:
				while (true)
				{
					switch (num ^ -1565735293)
					{
					case 4:
						break;
					default:
						return;
					case 2:
						return;
					case 1:
						HrNBRpeoDyTLxljTeSLBHeKAtSZg();
						num = -1565735293;
						continue;
					case 3:
						goto IL_005f;
					case 0:
						goto IL_0084;
					case 5:
						return;
					}
					break;
				}
				goto IL_0020;
			}

			public bool GetButton(int index)
			{
				if (sGYPkzHbItlusiKtRalxlmthdZl == 0)
				{
					tGZxoJkusPcWZmBNzkotpCDkdyZ();
					return false;
				}
				if ((uint)index >= 7u)
				{
					return false;
				}
				return WXIRxjkGHEWEQMEDrfdCKrevQRBu[index];
			}

			public float GetAxisRaw(int index)
			{
				if (sGYPkzHbItlusiKtRalxlmthdZl == 0)
				{
					while (true)
					{
						int num = -1583972742;
						while (true)
						{
							switch (num ^ -1583972744)
							{
							case 0:
								break;
							case 2:
								goto IL_0026;
							default:
								return 0f;
							}
							break;
							IL_0026:
							tGZxoJkusPcWZmBNzkotpCDkdyZ();
							num = -1583972743;
						}
					}
				}
				if ((uint)index >= 3u)
				{
					return 0f;
				}
				return zFkDvTbearAemKYGDCYZjNRbnaS[index];
			}

			public void GetButtonValues(bool[] buttons)
			{
				if (sGYPkzHbItlusiKtRalxlmthdZl == 0)
				{
					tGZxoJkusPcWZmBNzkotpCDkdyZ();
					return;
				}
				while (buttons != null)
				{
					int num;
					int num2;
					if (buttons.Length >= 7)
					{
						num = 483387664;
						num2 = num;
					}
					else
					{
						num = 483387667;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x1CCFE911)
						{
						case 0:
							goto IL_000f;
						case 3:
							break;
						case 2:
							return;
						default:
							Array.Copy(WXIRxjkGHEWEQMEDrfdCKrevQRBu, buttons, 7);
							return;
						}
						break;
						IL_000f:
						num = 483387666;
					}
				}
			}

			public void GetAxisRawValues(float[] axes)
			{
				if (sGYPkzHbItlusiKtRalxlmthdZl == 0)
				{
					tGZxoJkusPcWZmBNzkotpCDkdyZ();
					return;
				}
				while (true)
				{
					int num;
					int num2;
					if (axes == null)
					{
						num = 545078077;
						num2 = num;
					}
					else
					{
						num = 545078076;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x207D3B3F)
						{
						case 0:
							num = 545078078;
							continue;
						default:
							return;
						case 2:
							return;
						case 3:
						{
							int num3;
							if (axes.Length < 3)
							{
								num = 545078077;
								num3 = num;
							}
							else
							{
								num = 545078074;
								num3 = num;
							}
							continue;
						}
						case 1:
							break;
						case 5:
							Array.Copy(zFkDvTbearAemKYGDCYZjNRbnaS, axes, 3);
							num = 545078075;
							continue;
						case 4:
							return;
						}
						break;
					}
				}
			}

			private void IIPfiHxtIvmduMEHyrjbnbrxpRz()
			{
				Array.Clear(WXIRxjkGHEWEQMEDrfdCKrevQRBu, 0, 7);
				Array.Clear(zFkDvTbearAemKYGDCYZjNRbnaS, 0, 3);
			}

			private void fdRsbcBkTGgTdtCzqFoIhThTjIkI()
			{
				sGYPkzHbItlusiKtRalxlmthdZl = 0;
				mrAVpUvWOqssYnhnOjgjGJxOlzJ = Vector3.zero;
				bfmpCUQioMCtskMUzEtSEWLpWNZ = false;
			}

			private void MEBdHwfwFCLlFRknCJdIdTOhHWCe()
			{
			}

			private void scqBeNZYtAunaCNxbqRLRHKcNmQ()
			{
				IIPfiHxtIvmduMEHyrjbnbrxpRz();
			}

			private void tGZxoJkusPcWZmBNzkotpCDkdyZ()
			{
				Logger.LogWarning("You are trying to use Mouse without incrementing the monitor count.", true);
			}

			private void HrNBRpeoDyTLxljTeSLBHeKAtSZg()
			{
				Logger.LogWarning("You are decrementing the Mouse monitor count more than you are incrementing it.", true);
			}
		}

		private static Mouse vhOaqVzjghUNBDfLLweEcJPwiVh;

		private static Keyboard MBOtiVTVDaeflzpymdPMObAIpsw;

		public static Mouse mouse
		{
			get
			{
				return vhOaqVzjghUNBDfLLweEcJPwiVh ?? (vhOaqVzjghUNBDfLLweEcJPwiVh = new Mouse());
			}
		}

		public static Keyboard keyboard
		{
			get
			{
				return MBOtiVTVDaeflzpymdPMObAIpsw ?? (MBOtiVTVDaeflzpymdPMObAIpsw = new Keyboard());
			}
		}

		public static void Initialize()
		{
		}

		public static void PostInitialize()
		{
			if (MBOtiVTVDaeflzpymdPMObAIpsw != null)
			{
				MBOtiVTVDaeflzpymdPMObAIpsw.PostInitialize();
				goto IL_0011;
			}
			goto IL_002f;
			IL_002f:
			int num;
			if (vhOaqVzjghUNBDfLLweEcJPwiVh != null)
			{
				vhOaqVzjghUNBDfLLweEcJPwiVh.PostInitialize();
				num = 1180758114;
				goto IL_0016;
			}
			return;
			IL_0011:
			num = 1180758115;
			goto IL_0016;
			IL_0016:
			switch (num ^ 0x4660F062)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_002f;
			case 0:
				return;
			}
			goto IL_0011;
		}

		public static void PostInitialize2()
		{
		}

		public static void Deinitialize()
		{
			if (MBOtiVTVDaeflzpymdPMObAIpsw != null)
			{
				MBOtiVTVDaeflzpymdPMObAIpsw = null;
				goto IL_000d;
			}
			goto IL_002b;
			IL_002b:
			int num;
			if (vhOaqVzjghUNBDfLLweEcJPwiVh != null)
			{
				vhOaqVzjghUNBDfLLweEcJPwiVh = null;
				num = -104847616;
				goto IL_0012;
			}
			return;
			IL_000d:
			num = -104847615;
			goto IL_0012;
			IL_0012:
			switch (num ^ -104847616)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_002b;
			case 0:
				return;
			}
			goto IL_000d;
		}

		public static void Update()
		{
			if (MBOtiVTVDaeflzpymdPMObAIpsw != null)
			{
				goto IL_0007;
			}
			goto IL_0053;
			IL_0007:
			int num = -512906329;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ -512906331)
				{
				case 3:
					break;
				default:
					return;
				case 2:
					MBOtiVTVDaeflzpymdPMObAIpsw.enabled = ReInput.controllers.Keyboard.enabled;
					MBOtiVTVDaeflzpymdPMObAIpsw.Update();
					num = -512906332;
					continue;
				case 1:
					goto IL_0053;
				case 0:
					return;
				}
				break;
			}
			goto IL_0007;
			IL_0053:
			if (vhOaqVzjghUNBDfLLweEcJPwiVh != null)
			{
				vhOaqVzjghUNBDfLLweEcJPwiVh.Update();
				num = -512906331;
				goto IL_000c;
			}
		}
	}
}
