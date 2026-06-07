using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal sealed class CvKbBDBykgOtczqdWEjAImsohWR
{
	internal enum yRVJEGLVcDQyieRzpOtUzcxwGkL
	{
		mcLvHSMYsjDYZNVSkRNAjBJWDNI = 0,
		AKrlzAhTDjmUJonCJxVBSdhjiKH = 1,
		ZPykDFRKjlWyOusQpaYNPYZXBgE = 2
	}

	private class kGJwXaTIOiUZiBkkBQQFhucmNIh
	{
		internal class rJhIQDxqRYMCcbRAhxwzwiNXrlz
		{
			internal float nkqOARDzfZjuHoAuTVbGdBigvjz;

			private InputBehavior uhxBgBGBFGVnUELmixUqJqpnwoOn;

			internal float lQuVTkcbTYttAuUkysEfHJfgNuK;

			internal float OrhmdNWisuEhZlmphsKhqFZrmVz;

			internal AxisCoordinateMode KEQXdsTLOgsSTOrMbmKfSLOsbql;

			internal AxisCoordinateMode TJvHrEoQVwzPoVmElNLgLKJYqzO;

			internal ButtonStateFlags OileThpvkAvMNYbGPcNUiZbAZKu;

			internal ButtonStateFlags zNUqKrxRILnDaRRkBaOldTffVIvu;

			internal ButtonStateFlags uVmAVvVvxJKaGooIdMLxEhzhVTg;

			internal ButtonStateFlags nhcDjmnqWihtAORPiAzSPdiPTE;

			internal float lDWmkiSjNqiToBhXEwfFSpXwJhWF;

			internal float ptbHkXOofUPlvjsbwcufTCwnGuc;

			internal float DwGqsBkuuPDTaewFNOqlaXRkLqq;

			internal float MTTYQyuEoxdgbEPIwwOoMPXXKnDB;

			private float OfHXAxaNtuzEJTXqQJpiTcOusqV;

			private float rdVZIxapoyCcUuyNBvdfEKHKdCKk;

			internal GVJXhisvcOYMeSAQXDzfXmDefQU vcGZsdBKQQjrFVJAxAPxCLxZYhX;

			internal GVJXhisvcOYMeSAQXDzfXmDefQU fzfIWLumSWkjZvFnvzqVKbLTatR;

			internal ButtonStateRecorder ZXIZggoPhfxrNYiuvgVjSKRDfNUF;

			internal ButtonStateRecorder MrRNpslzrHhMKDBYrYVaBQPElnc;

			internal JuzcrpXSmAifbBzgKFbglpqMcuZw rLiMLCuZccmsmDKilFHtCCAWnETd;

			internal JuzcrpXSmAifbBzgKFbglpqMcuZw pyBulQuhXpLYIdJpTdztorAvXQI;

			internal TimerAbs ZTthsIyWvwsmOqgEynZhYUqgpGC;

			internal TimerAbs qLWvyJPDjNEPcAoYLwGLbbPWbLy;

			internal readonly UChyDAIORuXqDhvbfagyRDSNGSiJ KURctxaNhRMfpOnYVpVxCJgmubcC = new UChyDAIORuXqDhvbfagyRDSNGSiJ();

			internal float vButtonTimePressed
			{
				get
				{
					return ZXIZggoPhfxrNYiuvgVjSKRDfNUF.timePressed;
				}
			}

			internal float vButtonTimeUnpressed
			{
				get
				{
					return ZXIZggoPhfxrNYiuvgVjSKRDfNUF.timeUnpressed;
				}
			}

			internal float negativeVButtonTimePressed
			{
				get
				{
					return MrRNpslzrHhMKDBYrYVaBQPElnc.timePressed;
				}
			}

			internal float negativeVButtonTimeUnpressed
			{
				get
				{
					return MrRNpslzrHhMKDBYrYVaBQPElnc.timeUnpressed;
				}
			}

			internal float vAxisTimeActive
			{
				get
				{
					if (lQuVTkcbTYttAuUkysEfHJfgNuK == 0f)
					{
						goto IL_000d;
					}
					goto IL_0042;
					IL_000d:
					int num = -786162048;
					goto IL_0012;
					IL_0012:
					float num2 = default(float);
					while (true)
					{
						switch (num ^ -786162047)
						{
						case 2:
							break;
						case 1:
							goto IL_002f;
						case 3:
							if (num2 < 0f)
							{
								num2 = 0f;
								num = -786162047;
								continue;
							}
							goto default;
						default:
							return num2;
						}
						break;
					}
					goto IL_000d;
					IL_002f:
					if (lDWmkiSjNqiToBhXEwfFSpXwJhWF == 0f)
					{
						return 0f;
					}
					goto IL_0042;
					IL_0042:
					num2 = ZLszVLHJDuxaDhIIlAyiUZMJSMR - OfHXAxaNtuzEJTXqQJpiTcOusqV;
					num = -786162046;
					goto IL_0012;
				}
			}

			internal float vAxisTimeInactive
			{
				get
				{
					float num = default(float);
					int num2;
					if (lQuVTkcbTYttAuUkysEfHJfgNuK == 0f)
					{
						if (lDWmkiSjNqiToBhXEwfFSpXwJhWF != 0f)
						{
							goto IL_001a;
						}
						num = ZLszVLHJDuxaDhIIlAyiUZMJSMR - OfHXAxaNtuzEJTXqQJpiTcOusqV;
						num2 = -763590500;
						goto IL_001f;
					}
					goto IL_003c;
					IL_001f:
					while (true)
					{
						switch (num2 ^ -763590497)
						{
						case 0:
							break;
						case 1:
							goto IL_003c;
						case 3:
							if (num < 0f)
							{
								num = 0f;
								num2 = -763590499;
								continue;
							}
							goto default;
						default:
							return num;
						}
						break;
					}
					goto IL_001a;
					IL_003c:
					return 0f;
					IL_001a:
					num2 = -763590498;
					goto IL_001f;
				}
			}

			internal float vAxisRawTimeActive
			{
				get
				{
					if (lQuVTkcbTYttAuUkysEfHJfgNuK == 0f)
					{
						goto IL_000d;
					}
					goto IL_003e;
					IL_000d:
					int num = -519037854;
					goto IL_0012;
					IL_0012:
					switch (num ^ -519037853)
					{
					case 2:
						break;
					case 1:
						goto IL_002b;
					default:
						goto IL_0060;
					}
					goto IL_000d;
					IL_002b:
					if (DwGqsBkuuPDTaewFNOqlaXRkLqq == 0f)
					{
						return 0f;
					}
					goto IL_003e;
					IL_003e:
					float num2 = ZLszVLHJDuxaDhIIlAyiUZMJSMR - rdVZIxapoyCcUuyNBvdfEKHKdCKk;
					if (num2 < 0f)
					{
						num2 = 0f;
						num = -519037853;
						goto IL_0012;
					}
					goto IL_0060;
					IL_0060:
					return num2;
				}
			}

			internal float vAxisRawTimeInactive
			{
				get
				{
					float num = default(float);
					int num2;
					if (lQuVTkcbTYttAuUkysEfHJfgNuK == 0f)
					{
						if (DwGqsBkuuPDTaewFNOqlaXRkLqq != 0f)
						{
							goto IL_001a;
						}
						num = ZLszVLHJDuxaDhIIlAyiUZMJSMR - rdVZIxapoyCcUuyNBvdfEKHKdCKk;
						num2 = -279533246;
						goto IL_001f;
					}
					goto IL_003c;
					IL_001f:
					while (true)
					{
						switch (num2 ^ -279533248)
						{
						case 0:
							break;
						case 1:
							goto IL_003c;
						case 2:
							if (num < 0f)
							{
								num = 0f;
								num2 = -279533245;
								continue;
							}
							goto default;
						default:
							return num;
						}
						break;
					}
					goto IL_001a;
					IL_003c:
					return 0f;
					IL_001a:
					num2 = -279533247;
					goto IL_001f;
				}
			}

			internal rJhIQDxqRYMCcbRAhxwzwiNXrlz(InputBehavior inputBehavior)
			{
				uhxBgBGBFGVnUELmixUqJqpnwoOn = inputBehavior;
				if (inputBehavior.buttonDownBuffer > 0f)
				{
					ZTthsIyWvwsmOqgEynZhYUqgpGC = new TimerAbs(inputBehavior.buttonDownBuffer);
					qLWvyJPDjNEPcAoYLwGLbbPWbLy = new TimerAbs(inputBehavior.buttonDownBuffer);
				}
				ZXIZggoPhfxrNYiuvgVjSKRDfNUF = new ButtonStateRecorder();
				MrRNpslzrHhMKDBYrYVaBQPElnc = new ButtonStateRecorder();
				vcGZsdBKQQjrFVJAxAPxCLxZYhX = new GVJXhisvcOYMeSAQXDzfXmDefQU(inputBehavior.buttonDoublePressSpeed);
				fzfIWLumSWkjZvFnvzqVKbLTatR = new GVJXhisvcOYMeSAQXDzfXmDefQU(inputBehavior.buttonDoublePressSpeed);
				rLiMLCuZccmsmDKilFHtCCAWnETd = new JuzcrpXSmAifbBzgKFbglpqMcuZw(inputBehavior.buttonRepeatDelay, inputBehavior.buttonRepeatRate);
				pyBulQuhXpLYIdJpTdztorAvXQI = new JuzcrpXSmAifbBzgKFbglpqMcuZw(inputBehavior.buttonRepeatDelay, inputBehavior.buttonRepeatRate);
				uhvPgODGWeKMFMivQPhxYtwBRAB();
			}

			internal void XAnWRZQkoUxMGIsJKoBVsqxrTkQ(float P_0)
			{
				if (lQuVTkcbTYttAuUkysEfHJfgNuK == 0f)
				{
					if (lDWmkiSjNqiToBhXEwfFSpXwJhWF != 0f)
					{
						goto IL_001d;
					}
					goto IL_0095;
				}
				goto IL_0153;
				IL_0153:
				int num;
				int num2;
				if (OrhmdNWisuEhZlmphsKhqFZrmVz != 0f)
				{
					num = -1558629389;
					num2 = num;
				}
				else
				{
					num = -1558629391;
					num2 = num;
				}
				goto IL_0022;
				IL_001d:
				num = -1558629377;
				goto IL_0022;
				IL_0022:
				while (true)
				{
					switch (num ^ -1558629384)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						if (OrhmdNWisuEhZlmphsKhqFZrmVz == 0f && MTTYQyuEoxdgbEPIwwOoMPXXKnDB == 0f)
						{
							rdVZIxapoyCcUuyNBvdfEKHKdCKk = ZLszVLHJDuxaDhIIlAyiUZMJSMR;
						}
						return;
					case 1:
						goto IL_0095;
					case 10:
						rdVZIxapoyCcUuyNBvdfEKHKdCKk = ZLszVLHJDuxaDhIIlAyiUZMJSMR;
						num = -1558629379;
						continue;
					case 9:
						goto IL_00cb;
					case 8:
						OfHXAxaNtuzEJTXqQJpiTcOusqV = ZLszVLHJDuxaDhIIlAyiUZMJSMR;
						num = -1558629389;
						continue;
					case 6:
						goto IL_0101;
					case 11:
						if (lQuVTkcbTYttAuUkysEfHJfgNuK != 0f)
						{
							goto case 3;
						}
						goto IL_0132;
					case 7:
						goto IL_0153;
					case 4:
						OfHXAxaNtuzEJTXqQJpiTcOusqV = ZLszVLHJDuxaDhIIlAyiUZMJSMR;
						num = -1558629389;
						continue;
					case 2:
						if (OrhmdNWisuEhZlmphsKhqFZrmVz != 0f)
						{
							goto case 10;
						}
						goto IL_0199;
					case 5:
						return;
					}
					break;
					IL_0199:
					int num3;
					if (MTTYQyuEoxdgbEPIwwOoMPXXKnDB != 0f)
					{
						num = -1558629390;
						num3 = num;
					}
					else
					{
						num = -1558629379;
						num3 = num;
					}
					continue;
					IL_0101:
					int num4;
					if (ptbHkXOofUPlvjsbwcufTCwnGuc == 0f)
					{
						num = -1558629389;
						num4 = num;
					}
					else
					{
						num = -1558629380;
						num4 = num;
					}
					continue;
					IL_00cb:
					int num5;
					if (ptbHkXOofUPlvjsbwcufTCwnGuc != 0f)
					{
						num = -1558629389;
						num5 = num;
					}
					else
					{
						num = -1558629392;
						num5 = num;
					}
					continue;
					IL_0132:
					int num6;
					if (DwGqsBkuuPDTaewFNOqlaXRkLqq != 0f)
					{
						num = -1558629381;
						num6 = num;
					}
					else
					{
						num = -1558629382;
						num6 = num;
					}
				}
				goto IL_001d;
				IL_0095:
				int num7;
				if (OrhmdNWisuEhZlmphsKhqFZrmVz == 0f)
				{
					num = -1558629378;
					num7 = num;
				}
				else
				{
					num = -1558629380;
					num7 = num;
				}
				goto IL_0022;
			}

			internal void HhxFXJJGqysLNWcfgpQvHOGKhxK()
			{
				if (OrhmdNWisuEhZlmphsKhqFZrmVz != lQuVTkcbTYttAuUkysEfHJfgNuK)
				{
					goto IL_0011;
				}
				goto IL_00cf;
				IL_0011:
				int num = 1620163664;
				goto IL_0016;
				IL_0016:
				while (true)
				{
					switch (num ^ 0x6091BC58)
					{
					case 0:
						break;
					default:
						return;
					case 7:
						goto IL_004a;
					case 2:
						goto IL_006e;
					case 5:
						goto IL_0087;
					case 3:
						goto IL_00ab;
					case 6:
						goto IL_00cf;
					case 8:
						OrhmdNWisuEhZlmphsKhqFZrmVz = lQuVTkcbTYttAuUkysEfHJfgNuK;
						num = 1620163678;
						continue;
					case 1:
						goto IL_010c;
					case 4:
						return;
					}
					break;
				}
				goto IL_0011;
				IL_00cf:
				if (zNUqKrxRILnDaRRkBaOldTffVIvu != OileThpvkAvMNYbGPcNUiZbAZKu)
				{
					zNUqKrxRILnDaRRkBaOldTffVIvu = OileThpvkAvMNYbGPcNUiZbAZKu;
					num = 1620163679;
					goto IL_0016;
				}
				goto IL_004a;
				IL_006e:
				if (KEQXdsTLOgsSTOrMbmKfSLOsbql != AxisCoordinateMode.Absolute)
				{
					KEQXdsTLOgsSTOrMbmKfSLOsbql = AxisCoordinateMode.Absolute;
					num = 1620163676;
					goto IL_0016;
				}
				return;
				IL_004a:
				if (nhcDjmnqWihtAORPiAzSPdiPTE != uVmAVvVvxJKaGooIdMLxEhzhVTg)
				{
					nhcDjmnqWihtAORPiAzSPdiPTE = uVmAVvVvxJKaGooIdMLxEhzhVTg;
					num = 1620163673;
					goto IL_0016;
				}
				goto IL_010c;
				IL_010c:
				if (ptbHkXOofUPlvjsbwcufTCwnGuc != lDWmkiSjNqiToBhXEwfFSpXwJhWF)
				{
					ptbHkXOofUPlvjsbwcufTCwnGuc = lDWmkiSjNqiToBhXEwfFSpXwJhWF;
					num = 1620163675;
					goto IL_0016;
				}
				goto IL_00ab;
				IL_00ab:
				if (MTTYQyuEoxdgbEPIwwOoMPXXKnDB != DwGqsBkuuPDTaewFNOqlaXRkLqq)
				{
					MTTYQyuEoxdgbEPIwwOoMPXXKnDB = DwGqsBkuuPDTaewFNOqlaXRkLqq;
					num = 1620163677;
					goto IL_0016;
				}
				goto IL_0087;
				IL_0087:
				if (TJvHrEoQVwzPoVmElNLgLKJYqzO != KEQXdsTLOgsSTOrMbmKfSLOsbql)
				{
					TJvHrEoQVwzPoVmElNLgLKJYqzO = KEQXdsTLOgsSTOrMbmKfSLOsbql;
					num = 1620163674;
					goto IL_0016;
				}
				goto IL_006e;
			}

			internal void OsdLLiAbSOUHjTBkxnrBmcHxWRy()
			{
				if (ZTthsIyWvwsmOqgEynZhYUqgpGC != null)
				{
					ZTthsIyWvwsmOqgEynZhYUqgpGC.Update();
					qLWvyJPDjNEPcAoYLwGLbbPWbLy.Update();
				}
			}

			internal void CaayQnwIGhrIaAMNFhRFGSJabhR(bool P_0, bool P_1, bool P_2, bool P_3)
			{
				ZXIZggoPhfxrNYiuvgVjSKRDfNUF.rdEJYvExbWYUXSDuseVgzyXPBhA(P_0, P_1, ZLszVLHJDuxaDhIIlAyiUZMJSMR);
				MrRNpslzrHhMKDBYrYVaBQPElnc.rdEJYvExbWYUXSDuseVgzyXPBhA(P_2, P_3, ZLszVLHJDuxaDhIIlAyiUZMJSMR);
				float buttonRepeatDelay = default(float);
				float buttonRepeatRate = default(float);
				while (true)
				{
					int num = 257715756;
					while (true)
					{
						switch (num ^ 0xF5C6E2E)
						{
						case 0:
							break;
						case 2:
						{
							float buttonDoublePressSpeed = uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonDoublePressSpeed;
							vcGZsdBKQQjrFVJAxAPxCLxZYhX.rdEJYvExbWYUXSDuseVgzyXPBhA(buttonDoublePressSpeed, P_0, P_1);
							fzfIWLumSWkjZvFnvzqVKbLTatR.rdEJYvExbWYUXSDuseVgzyXPBhA(buttonDoublePressSpeed, P_2, P_3);
							buttonRepeatDelay = uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonRepeatDelay;
							num = 257715757;
							continue;
						}
						case 3:
							buttonRepeatRate = uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonRepeatRate;
							num = 257715759;
							continue;
						default:
							rLiMLCuZccmsmDKilFHtCCAWnETd.rdEJYvExbWYUXSDuseVgzyXPBhA(P_0, P_1, buttonRepeatDelay, buttonRepeatRate, ZLszVLHJDuxaDhIIlAyiUZMJSMR);
							pyBulQuhXpLYIdJpTdztorAvXQI.rdEJYvExbWYUXSDuseVgzyXPBhA(P_2, P_3, buttonRepeatDelay, buttonRepeatRate, ZLszVLHJDuxaDhIIlAyiUZMJSMR);
							return;
						}
						break;
					}
				}
			}

			internal bool hTMiRpvIcXoGHKjaNTYlZGHmefX()
			{
				if (ZLszVLHJDuxaDhIIlAyiUZMJSMR < nkqOARDzfZjuHoAuTVbGdBigvjz + uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonDoublePressSpeed + 2f * oodscuzZOTZCQfWWmuRfPatWVPV)
				{
					goto IL_0025;
				}
				int num;
				if (lQuVTkcbTYttAuUkysEfHJfgNuK != 0f)
				{
					num = 1696093116;
				}
				else
				{
					if (OrhmdNWisuEhZlmphsKhqFZrmVz != 0f)
					{
						return false;
					}
					if (OileThpvkAvMNYbGPcNUiZbAZKu == ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr)
					{
						return false;
					}
					if (zNUqKrxRILnDaRRkBaOldTffVIvu == ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr)
					{
						return false;
					}
					if (uVmAVvVvxJKaGooIdMLxEhzhVTg != ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr)
					{
						if (nhcDjmnqWihtAORPiAzSPdiPTE == ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr)
						{
							return false;
						}
						if (lDWmkiSjNqiToBhXEwfFSpXwJhWF != 0f)
						{
							num = 1696093112;
						}
						else
						{
							if (ptbHkXOofUPlvjsbwcufTCwnGuc != 0f)
							{
								return false;
							}
							if (DwGqsBkuuPDTaewFNOqlaXRkLqq != 0f)
							{
								return false;
							}
							if (MTTYQyuEoxdgbEPIwwOoMPXXKnDB == 0f)
							{
								if (ZTthsIyWvwsmOqgEynZhYUqgpGC != null && ZTthsIyWvwsmOqgEynZhYUqgpGC.running)
								{
									return false;
								}
								if (qLWvyJPDjNEPcAoYLwGLbbPWbLy == null || !qLWvyJPDjNEPcAoYLwGLbbPWbLy.running)
								{
									return true;
								}
								num = 1696093117;
							}
							else
							{
								num = 1696093113;
							}
						}
					}
					else
					{
						num = 1696093119;
					}
				}
				goto IL_002a;
				IL_0025:
				num = 1696093114;
				goto IL_002a;
				IL_002a:
				switch (num ^ 0x651853BC)
				{
				case 2:
					break;
				case 6:
					return false;
				case 5:
					return false;
				case 3:
					return false;
				case 4:
					return false;
				case 0:
					return false;
				default:
					return false;
				}
				goto IL_0025;
			}

			internal void bAIoHrKgeGHqHImVWWOrusYtQlkv()
			{
				OileThpvkAvMNYbGPcNUiZbAZKu &= ~ButtonStateFlags.avtVkgWiQfRjAMVrjPmvYWatNrY;
			}

			internal void pnbrdZwKvfGuMdGIxtXIcSwuZSA()
			{
				if (lQuVTkcbTYttAuUkysEfHJfgNuK == 0f)
				{
					if (lDWmkiSjNqiToBhXEwfFSpXwJhWF != 0f)
					{
						goto IL_0020;
					}
					goto IL_00fe;
				}
				goto IL_012c;
				IL_00fe:
				int num;
				if (lQuVTkcbTYttAuUkysEfHJfgNuK == 0f)
				{
					int num2;
					if (DwGqsBkuuPDTaewFNOqlaXRkLqq != 0f)
					{
						num = 590382596;
						num2 = num;
					}
					else
					{
						num = 590382593;
						num2 = num;
					}
					goto IL_0025;
				}
				goto IL_00e9;
				IL_0020:
				num = 590382599;
				goto IL_0025;
				IL_0025:
				while (true)
				{
					switch (num ^ 0x23308605)
					{
					case 5:
						break;
					case 8:
						goto IL_0061;
					case 4:
						lQuVTkcbTYttAuUkysEfHJfgNuK = 0f;
						OrhmdNWisuEhZlmphsKhqFZrmVz = 0f;
						KEQXdsTLOgsSTOrMbmKfSLOsbql = AxisCoordinateMode.Absolute;
						OileThpvkAvMNYbGPcNUiZbAZKu = ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr;
						zNUqKrxRILnDaRRkBaOldTffVIvu = ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr;
						uVmAVvVvxJKaGooIdMLxEhzhVTg = ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr;
						nhcDjmnqWihtAORPiAzSPdiPTE = ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr;
						lDWmkiSjNqiToBhXEwfFSpXwJhWF = 0f;
						num = 590382605;
						continue;
					case 1:
						goto IL_00e9;
					case 3:
						goto IL_00fe;
					case 2:
						goto IL_012c;
					case 9:
						vcGZsdBKQQjrFVJAxAPxCLxZYhX.xaGVjRxEvIdELjjBskoGFDUNmrm();
						fzfIWLumSWkjZvFnvzqVKbLTatR.xaGVjRxEvIdELjjBskoGFDUNmrm();
						num = 590382595;
						continue;
					case 7:
						ZTthsIyWvwsmOqgEynZhYUqgpGC.Clear();
						qLWvyJPDjNEPcAoYLwGLbbPWbLy.Clear();
						num = 590382604;
						continue;
					case 0:
						rLiMLCuZccmsmDKilFHtCCAWnETd.xaGVjRxEvIdELjjBskoGFDUNmrm();
						pyBulQuhXpLYIdJpTdztorAvXQI.xaGVjRxEvIdELjjBskoGFDUNmrm();
						num = 590382607;
						continue;
					case 6:
						ZXIZggoPhfxrNYiuvgVjSKRDfNUF.pnbrdZwKvfGuMdGIxtXIcSwuZSA(ZLszVLHJDuxaDhIIlAyiUZMJSMR);
						MrRNpslzrHhMKDBYrYVaBQPElnc.pnbrdZwKvfGuMdGIxtXIcSwuZSA(ZLszVLHJDuxaDhIIlAyiUZMJSMR);
						num = 590382597;
						continue;
					default:
						KURctxaNhRMfpOnYVpVxCJgmubcC.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
						return;
					}
					break;
					IL_0061:
					ptbHkXOofUPlvjsbwcufTCwnGuc = 0f;
					DwGqsBkuuPDTaewFNOqlaXRkLqq = 0f;
					MTTYQyuEoxdgbEPIwwOoMPXXKnDB = 0f;
					int num3;
					if (ZTthsIyWvwsmOqgEynZhYUqgpGC != null)
					{
						num = 590382594;
						num3 = num;
					}
					else
					{
						num = 590382604;
						num3 = num;
					}
				}
				goto IL_0020;
				IL_00e9:
				rdVZIxapoyCcUuyNBvdfEKHKdCKk = ZLszVLHJDuxaDhIIlAyiUZMJSMR;
				num = 590382593;
				goto IL_0025;
				IL_012c:
				OfHXAxaNtuzEJTXqQJpiTcOusqV = ZLszVLHJDuxaDhIIlAyiUZMJSMR;
				num = 590382598;
				goto IL_0025;
			}

			internal void uhvPgODGWeKMFMivQPhxYtwBRAB()
			{
				pnbrdZwKvfGuMdGIxtXIcSwuZSA();
				ZXIZggoPhfxrNYiuvgVjSKRDfNUF.xaGVjRxEvIdELjjBskoGFDUNmrm();
				MrRNpslzrHhMKDBYrYVaBQPElnc.xaGVjRxEvIdELjjBskoGFDUNmrm();
				OfHXAxaNtuzEJTXqQJpiTcOusqV = ZLszVLHJDuxaDhIIlAyiUZMJSMR;
				rdVZIxapoyCcUuyNBvdfEKHKdCKk = ZLszVLHJDuxaDhIIlAyiUZMJSMR;
			}
		}

		public rJhIQDxqRYMCcbRAhxwzwiNXrlz[] FRUUibiOIWEsSCBxDuohaLtzlQrt;

		private readonly int[] pumYaSKRNdhQZVERULkMvjtJiLd;

		private int makeqSfOesOCmoTnKnppZmDJCnQg;

		internal rJhIQDxqRYMCcbRAhxwzwiNXrlz CLjmYleEuCraJMMUJEFwtuAaGlg;

		internal UpdateLoopType updateLoop
		{
			set
			{
				makeqSfOesOCmoTnKnppZmDJCnQg = pumYaSKRNdhQZVERULkMvjtJiLd[(int)value];
				CLjmYleEuCraJMMUJEFwtuAaGlg = FRUUibiOIWEsSCBxDuohaLtzlQrt[makeqSfOesOCmoTnKnppZmDJCnQg];
			}
		}

		internal kGJwXaTIOiUZiBkkBQQFhucmNIh(UpdateLoopSetting updateLoopSetting, InputBehavior inputBehavior)
		{
			pumYaSKRNdhQZVERULkMvjtJiLd = new int[3];
			ArrayTools.Fill(pumYaSKRNdhQZVERULkMvjtJiLd, -1);
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
				for (int i = 0; i < list.Count; i++)
				{
					pumYaSKRNdhQZVERULkMvjtJiLd[(int)list[i]] = num;
					num++;
				}
			}
			FRUUibiOIWEsSCBxDuohaLtzlQrt = new rJhIQDxqRYMCcbRAhxwzwiNXrlz[num];
			for (int j = 0; j < num; j++)
			{
				FRUUibiOIWEsSCBxDuohaLtzlQrt[j] = new rJhIQDxqRYMCcbRAhxwzwiNXrlz(inputBehavior);
			}
			CLjmYleEuCraJMMUJEFwtuAaGlg = FRUUibiOIWEsSCBxDuohaLtzlQrt[0];
		}

		internal bool hTMiRpvIcXoGHKjaNTYlZGHmefX()
		{
			int num = 0;
			while (num < 3)
			{
				while (true)
				{
					if (pumYaSKRNdhQZVERULkMvjtJiLd[num] >= 0 && !FRUUibiOIWEsSCBxDuohaLtzlQrt[pumYaSKRNdhQZVERULkMvjtJiLd[num]].hTMiRpvIcXoGHKjaNTYlZGHmefX())
					{
						return false;
					}
					num++;
					int num2 = 416663478;
					while (true)
					{
						switch (num2 ^ 0x18D5C7B6)
						{
						case 2:
							num2 = 416663479;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0022;
						}
						break;
					}
					continue;
					end_IL_0022:
					break;
				}
			}
			return true;
		}

		internal void xaGVjRxEvIdELjjBskoGFDUNmrm()
		{
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < FRUUibiOIWEsSCBxDuohaLtzlQrt.Length)
				{
					num2 = 1168196696;
					num3 = num2;
				}
				else
				{
					num2 = 1168196703;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x45A1445C)
					{
					case 0:
						num2 = 1168196696;
						continue;
					default:
						return;
					case 4:
						FRUUibiOIWEsSCBxDuohaLtzlQrt[num].uhvPgODGWeKMFMivQPhxYtwBRAB();
						num2 = 1168196702;
						continue;
					case 2:
						num++;
						num2 = 1168196701;
						continue;
					case 1:
						break;
					case 3:
						return;
					}
					break;
				}
			}
		}

		internal void pnbrdZwKvfGuMdGIxtXIcSwuZSA()
		{
			int num = 0;
			while (num < FRUUibiOIWEsSCBxDuohaLtzlQrt.Length)
			{
				while (true)
				{
					FRUUibiOIWEsSCBxDuohaLtzlQrt[num].pnbrdZwKvfGuMdGIxtXIcSwuZSA();
					num++;
					int num2 = 228904272;
					while (true)
					{
						switch (num2 ^ 0xDA4CD50)
						{
						case 2:
							num2 = 228904273;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0022;
						}
						break;
					}
					continue;
					end_IL_0022:
					break;
				}
			}
		}
	}

	private class MRHzvSpAuwCcsrZJLOpQzXkOSjE
	{
		internal class MyXTCwsSWdjRmiYZAKihKHCYyZp
		{
			internal Vector3 RqVBxpJvnQiCuLySWMmVBrGBAsf;

			internal Vector3 JDMXbeBdNdNBgVaViNivFfQERoU;

			internal Vector3 ovQzdxsBDxLwGUUMLOIPhnnFdnm;

			internal void porVqKtBFiIHDOUZRRunXULagDH()
			{
				RqVBxpJvnQiCuLySWMmVBrGBAsf = ReInput.controllers.Mouse.screenPosition;
				ovQzdxsBDxLwGUUMLOIPhnnFdnm = RqVBxpJvnQiCuLySWMmVBrGBAsf - JDMXbeBdNdNBgVaViNivFfQERoU;
			}

			internal void mInJiRTasBbwZhAfvHvmdRKzEqVf()
			{
				JDMXbeBdNdNBgVaViNivFfQERoU.x = RqVBxpJvnQiCuLySWMmVBrGBAsf.x;
				JDMXbeBdNdNBgVaViNivFfQERoU.y = RqVBxpJvnQiCuLySWMmVBrGBAsf.y;
				JDMXbeBdNdNBgVaViNivFfQERoU.z = RqVBxpJvnQiCuLySWMmVBrGBAsf.z;
			}
		}

		private ADictionary<int, MyXTCwsSWdjRmiYZAKihKHCYyZp> TLERLwPBmpTvOkzIYiLpNvIoiAa;

		private MyXTCwsSWdjRmiYZAKihKHCYyZp RniDXWRxLAeUuHqGAjkemyDPAOiH;

		private UpdateLoopType CocIKimTTrdTKSqdFISqfdbYuCW;

		internal MyXTCwsSWdjRmiYZAKihKHCYyZp current
		{
			get
			{
				return RniDXWRxLAeUuHqGAjkemyDPAOiH;
			}
		}

		internal MRHzvSpAuwCcsrZJLOpQzXkOSjE(UpdateLoopSetting updateLoopSetting)
		{
			RniDXWRxLAeUuHqGAjkemyDPAOiH = null;
			TLERLwPBmpTvOkzIYiLpNvIoiAa = new ADictionary<int, MyXTCwsSWdjRmiYZAKihKHCYyZp>();
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
				for (int i = 0; i < list.Count; i++)
				{
					MyXTCwsSWdjRmiYZAKihKHCYyZp myXTCwsSWdjRmiYZAKihKHCYyZp = new MyXTCwsSWdjRmiYZAKihKHCYyZp();
					TLERLwPBmpTvOkzIYiLpNvIoiAa.Add((int)list[i], myXTCwsSWdjRmiYZAKihKHCYyZp);
					if (RniDXWRxLAeUuHqGAjkemyDPAOiH == null)
					{
						RniDXWRxLAeUuHqGAjkemyDPAOiH = myXTCwsSWdjRmiYZAKihKHCYyZp;
					}
				}
			}
		}

		internal void porVqKtBFiIHDOUZRRunXULagDH(UpdateLoopType P_0)
		{
			if (CocIKimTTrdTKSqdFISqfdbYuCW != P_0)
			{
				goto IL_0009;
			}
			goto IL_0039;
			IL_0009:
			int num = -1073853039;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ -1073853040)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					CocIKimTTrdTKSqdFISqfdbYuCW = P_0;
					num = -1073853037;
					continue;
				case 3:
					goto IL_0039;
				case 0:
					return;
				}
				break;
			}
			goto IL_0009;
			IL_0039:
			RniDXWRxLAeUuHqGAjkemyDPAOiH = TLERLwPBmpTvOkzIYiLpNvIoiAa[(int)P_0];
			RniDXWRxLAeUuHqGAjkemyDPAOiH.porVqKtBFiIHDOUZRRunXULagDH();
			num = -1073853040;
			goto IL_000e;
		}

		internal void mInJiRTasBbwZhAfvHvmdRKzEqVf()
		{
			RniDXWRxLAeUuHqGAjkemyDPAOiH.mInJiRTasBbwZhAfvHvmdRKzEqVf();
		}
	}

	private const int LXVPyGtPvejKIOIJdBYMQEfDstW = 4;

	internal readonly string jMnuxDpeLQhKgkpKQOlnqChJgyRd;

	internal readonly int ZUoDkTcclUigIzTjeFLCXFMQOaU;

	internal readonly int VUcYiZtcJRatratRXOokIFfcdNSg;

	private readonly int SsPwhbdijXONOlkRKHOkXryZrDq;

	private InputBehavior uhxBgBGBFGVnUELmixUqJqpnwoOn;

	private kGJwXaTIOiUZiBkkBQQFhucmNIh NEroqLjuwCtLFvVbPBNzgAFFsqi;

	private static ConfigVars EVFWZcZYsJTyVuPgkpnexuXAMzA;

	private static MRHzvSpAuwCcsrZJLOpQzXkOSjE ACTQwoyXaDfCSbHZCZNqtbGAUFh;

	private static UpdateLoopType ccchNwVcItfPOfcqSbtVmUSmBvb;

	private static float ZLszVLHJDuxaDhIIlAyiUZMJSMR;

	private static float oodscuzZOTZCQfWWmuRfPatWVPV;

	private static uint YHUHApUmpiFpUrvceHJyDOLvLwBS;

	private float kGTDAtFYNtTEYOgcxSobqyeVuzwp;

	private float WhwwbeKETWbQzJABduJoRiGHDxJh;

	private float mMUamESszladhisPrPNsPYErORya;

	private float hMhAFvoqkWwFHOzBoJIzkpUcZpR;

	private ButtonStateFlags TrokSaTyUuCmhblKxgHskGumQaoR;

	private ButtonStateFlags miZgyYaVFtrdXyosbCXMBruWeKge;

	private float GfLknZuqZfsjZqipemVCDxEudwG;

	private bool VRmFggrEHJoymdtFkHWMHTbBhLU;

	private AxisCoordinateMode rSsQMTISxCgUDuCMBzwNXBhyWWZ;

	private AxisCoordinateMode dMVbWJDCRCKtzcVqhdkEKaBrBCqw;

	private readonly UChyDAIORuXqDhvbfagyRDSNGSiJ NNjBUPooowtMrXUsArfJxNYSUUt = new UChyDAIORuXqDhvbfagyRDSNGSiJ();

	private uint KUKFALZvnGChudWPnDkiaxrhCaEE;

	private uint wvlgBwupvgdRpJFfTubhlIdLccKv;

	private bool mMXnhPMMMxphLALbWPoFkWTCBQS;

	private yRVJEGLVcDQyieRzpOtUzcxwGkL HEnvbKyoHEyMDrLlACrBHhedaXe;

	private int fQyUQNcXKqrsGCvieMaYYqAsfyl;

	private UChyDAIORuXqDhvbfagyRDSNGSiJ[] WiTeWcinjumRjMqwqSJbtzjwQPY;

	private List<InputActionSourceData> zWmdyKSNbVeFGdIiFAXnWCXlFxRA;

	private ReadOnlyCollection<InputActionSourceData> KumiKCmhvIWVLkQbhLSyNRFhBOa;

	private bool MNuWEVVEgRHtaaFYNrfCpurhHyl;

	internal bool BdgIlNfBSgMruspNkDePcrIffUrj;

	internal yRVJEGLVcDQyieRzpOtUzcxwGkL cfbLtZVfchvCddmhvLrshzbsxkD = yRVJEGLVcDQyieRzpOtUzcxwGkL.ZPykDFRKjlWyOusQpaYNPYZXBgE;

	internal static readonly bfNFWLKmIfaxCAouEsisTLpvNRI BfhfQQPHIOXGnVUXLAiiulglmrb;

	static CvKbBDBykgOtczqdWEjAImsohWR()
	{
		BfhfQQPHIOXGnVUXLAiiulglmrb = new bfNFWLKmIfaxCAouEsisTLpvNRI();
	}

	internal CvKbBDBykgOtczqdWEjAImsohWR(int playerId, InputAction action, InputBehavior inputBehavior, ConfigVars configVars)
	{
		SsPwhbdijXONOlkRKHOkXryZrDq = ReInput._id;
		EVFWZcZYsJTyVuPgkpnexuXAMzA = configVars;
		VUcYiZtcJRatratRXOokIFfcdNSg = playerId;
		ZUoDkTcclUigIzTjeFLCXFMQOaU = action.id;
		jMnuxDpeLQhKgkpKQOlnqChJgyRd = action.name;
		uhxBgBGBFGVnUELmixUqJqpnwoOn = inputBehavior;
		NEroqLjuwCtLFvVbPBNzgAFFsqi = new kGJwXaTIOiUZiBkkBQQFhucmNIh(configVars.updateLoop, inputBehavior);
		WiTeWcinjumRjMqwqSJbtzjwQPY = new UChyDAIORuXqDhvbfagyRDSNGSiJ[4];
		ArrayTools.Populate(WiTeWcinjumRjMqwqSJbtzjwQPY);
		zWmdyKSNbVeFGdIiFAXnWCXlFxRA = new List<InputActionSourceData>();
		KumiKCmhvIWVLkQbhLSyNRFhBOa = new ReadOnlyCollection<InputActionSourceData>(zWmdyKSNbVeFGdIiFAXnWCXlFxRA);
	}

	internal static void WmVfzBxTSAslrcbvyfyEhCgFIqkA(ConfigVars P_0)
	{
		ACTQwoyXaDfCSbHZCZNqtbGAUFh = new MRHzvSpAuwCcsrZJLOpQzXkOSjE(P_0.updateLoop);
	}

	internal static void ZouzsHmtgkHgzpqSGEdYaTNdgrhg(UpdateLoopType P_0)
	{
		ccchNwVcItfPOfcqSbtVmUSmBvb = P_0;
		ZLszVLHJDuxaDhIIlAyiUZMJSMR = ReInput.unscaledTime;
		oodscuzZOTZCQfWWmuRfPatWVPV = ReInput.unscaledDeltaTime;
		YHUHApUmpiFpUrvceHJyDOLvLwBS = ReInput.absFrame;
		ACTQwoyXaDfCSbHZCZNqtbGAUFh.porVqKtBFiIHDOUZRRunXULagDH(P_0);
	}

	internal static void MNwIOrsKzPgPBsPiRbTUvNmUdL()
	{
		ACTQwoyXaDfCSbHZCZNqtbGAUFh.mInJiRTasBbwZhAfvHvmdRKzEqVf();
	}

	private void ppxVBStVZRvXtLeOlWBdiAYFRuK()
	{
		NEroqLjuwCtLFvVbPBNzgAFFsqi.updateLoop = ccchNwVcItfPOfcqSbtVmUSmBvb;
		while (true)
		{
			int num = -812431993;
			while (true)
			{
				switch (num ^ -812431992)
				{
				case 10:
					break;
				default:
					return;
				case 0:
				{
					int num3;
					if (VRmFggrEHJoymdtFkHWMHTbBhLU)
					{
						num = -812431997;
						num3 = num;
					}
					else
					{
						num = -812431976;
						num3 = num;
					}
					continue;
				}
				case 12:
				{
					int num5;
					if (WhwwbeKETWbQzJABduJoRiGHDxJh != 0f)
					{
						num = -812431991;
						num5 = num;
					}
					else
					{
						num = -812431994;
						num5 = num;
					}
					continue;
				}
				case 8:
					if (dMVbWJDCRCKtzcVqhdkEKaBrBCqw != AxisCoordinateMode.Absolute)
					{
						dMVbWJDCRCKtzcVqhdkEKaBrBCqw = AxisCoordinateMode.Absolute;
						num = -812431987;
						continue;
					}
					goto case 5;
				case 16:
					if (mMUamESszladhisPrPNsPYErORya != 0f)
					{
						mMUamESszladhisPrPNsPYErORya = 0f;
						num = -812431995;
						continue;
					}
					goto case 13;
				case 14:
					if (TrokSaTyUuCmhblKxgHskGumQaoR != ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr)
					{
						TrokSaTyUuCmhblKxgHskGumQaoR = ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr;
						num = -812431988;
						continue;
					}
					goto case 4;
				case 4:
					if (miZgyYaVFtrdXyosbCXMBruWeKge != ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr)
					{
						miZgyYaVFtrdXyosbCXMBruWeKge = ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr;
						num = -812431985;
						continue;
					}
					goto case 7;
				case 15:
					NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.HhxFXJJGqysLNWcfgpQvHOGKhxK();
					NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OsdLLiAbSOUHjTBkxnrBmcHxWRy();
					if (kGTDAtFYNtTEYOgcxSobqyeVuzwp != 0f)
					{
						kGTDAtFYNtTEYOgcxSobqyeVuzwp = 0f;
						num = -812431996;
						continue;
					}
					goto case 12;
				case 2:
				{
					int num2;
					if (!NNjBUPooowtMrXUsArfJxNYSUUt.YORsZWHKqfvSwofazZpoPgrtBHAK)
					{
						num = -812431986;
						num2 = num;
					}
					else
					{
						num = -812431999;
						num2 = num;
					}
					continue;
				}
				case 11:
					VRmFggrEHJoymdtFkHWMHTbBhLU = false;
					num = -812431976;
					continue;
				case 13:
					if (hMhAFvoqkWwFHOzBoJIzkpUcZpR != 0f)
					{
						hMhAFvoqkWwFHOzBoJIzkpUcZpR = 0f;
						num = -812431989;
						continue;
					}
					goto case 3;
				case 3:
					if (rSsQMTISxCgUDuCMBzwNXBhyWWZ != AxisCoordinateMode.Absolute)
					{
						rSsQMTISxCgUDuCMBzwNXBhyWWZ = AxisCoordinateMode.Absolute;
						num = -812432000;
						continue;
					}
					goto case 8;
				case 5:
				{
					int num4;
					if (fQyUQNcXKqrsGCvieMaYYqAsfyl <= 0)
					{
						num = -812431990;
						num4 = num;
					}
					else
					{
						num = -812431975;
						num4 = num;
					}
					continue;
				}
				case 7:
					if (GfLknZuqZfsjZqipemVCDxEudwG != 0f)
					{
						GfLknZuqZfsjZqipemVCDxEudwG = 0f;
						num = -812431992;
						continue;
					}
					goto case 0;
				case 17:
					lsmaodSODmykHbSmhcSxLxCQDmD();
					num = -812431990;
					continue;
				case 9:
					NNjBUPooowtMrXUsArfJxNYSUUt.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
					num = -812431986;
					continue;
				case 1:
					WhwwbeKETWbQzJABduJoRiGHDxJh = 0f;
					num = -812431994;
					continue;
				case 6:
					return;
				}
				break;
			}
		}
	}

	internal void JpdhMasUpiuyJauEolnbBVPvfvE(bool P_0)
	{
		if (KUKFALZvnGChudWPnDkiaxrhCaEE == YHUHApUmpiFpUrvceHJyDOLvLwBS)
		{
			goto IL_05e8;
		}
		KUKFALZvnGChudWPnDkiaxrhCaEE = YHUHApUmpiFpUrvceHJyDOLvLwBS;
		if (HEnvbKyoHEyMDrLlACrBHhedaXe != cfbLtZVfchvCddmhvLrshzbsxkD)
		{
			HEnvbKyoHEyMDrLlACrBHhedaXe = cfbLtZVfchvCddmhvLrshzbsxkD;
			goto IL_0038;
		}
		goto IL_06cf;
		IL_0162:
		int num;
		if (cfbLtZVfchvCddmhvLrshzbsxkD == yRVJEGLVcDQyieRzpOtUzcxwGkL.ZPykDFRKjlWyOusQpaYNPYZXBgE)
		{
			cfbLtZVfchvCddmhvLrshzbsxkD = yRVJEGLVcDQyieRzpOtUzcxwGkL.AKrlzAhTDjmUJonCJxVBSdhjiKH;
			num = 323243504;
			goto IL_003d;
		}
		goto IL_05e8;
		IL_05e8:
		if (!P_0)
		{
			return;
		}
		goto IL_05c7;
		IL_0038:
		num = 323243467;
		goto IL_003d;
		IL_003d:
		float num3 = default(float);
		float num5 = default(float);
		float num2 = default(float);
		float y = default(float);
		bfNFWLKmIfaxCAouEsisTLpvNRI bfhfQQPHIOXGnVUXLAiiulglmrb = default(bfNFWLKmIfaxCAouEsisTLpvNRI);
		float num4 = default(float);
		int zwgAVZCxcUqkUVeFEgwfcqhdLwxy = default(int);
		MRHzvSpAuwCcsrZJLOpQzXkOSjE.MyXTCwsSWdjRmiYZAKihKHCYyZp current = default(MRHzvSpAuwCcsrZJLOpQzXkOSjE.MyXTCwsSWdjRmiYZAKihKHCYyZp);
		while (true)
		{
			float x;
			switch (num ^ 0x13444DF8)
			{
			case 30:
				break;
			default:
				return;
			case 11:
				num = 323243469;
				continue;
			case 39:
				goto IL_0137;
			case 10:
				goto IL_0162;
			case 3:
				goto IL_017f;
			case 21:
				num = 323243491;
				continue;
			case 32:
				num3 = num5;
				num = 323243492;
				continue;
			case 55:
				num2 = y / num5;
				num = 323243495;
				continue;
			case 1:
				if (rSsQMTISxCgUDuCMBzwNXBhyWWZ == AxisCoordinateMode.Absolute)
				{
					kGTDAtFYNtTEYOgcxSobqyeVuzwp += bfhfQQPHIOXGnVUXLAiiulglmrb.kXoKOSZJMKwATOiGMaylYIDqdDnb;
					num = 323243493;
					continue;
				}
				return;
			case 20:
				mMUamESszladhisPrPNsPYErORya += num4;
				num = 323243483;
				continue;
			case 17:
				NNjBUPooowtMrXUsArfJxNYSUUt.KZkCmzhSYSECcInSnhPgKBxtRsI(bfhfQQPHIOXGnVUXLAiiulglmrb);
				num = 323243489;
				continue;
			case 50:
				goto IL_0221;
			case 7:
				goto IL_023e;
			case 38:
				return;
			case 40:
				if (uhxBgBGBFGVnUELmixUqJqpnwoOn.mouseXYAxisDeltaCalc == MouseXYAxisDeltaCalc.ScreenHeight)
				{
					num5 = Screen.height;
					num = 323243480;
					continue;
				}
				goto case 24;
			case 35:
				XZANdfYifjgwhXhgQQOrACAOjaf(bfhfQQPHIOXGnVUXLAiiulglmrb, uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonDeadZone, false);
				return;
			case 24:
				throw new NotImplementedException();
			case 26:
				mMUamESszladhisPrPNsPYErORya += num2;
				num = 323243483;
				continue;
			case 28:
				num = 323243491;
				continue;
			case 19:
				num5 = Screen.height;
				num = 323243501;
				continue;
			case 42:
				if (zwgAVZCxcUqkUVeFEgwfcqhdLwxy >= 2)
				{
					goto IL_037c;
				}
				if (uhxBgBGBFGVnUELmixUqJqpnwoOn.mouseXYAxisMode == MouseXYAxisMode.MouseAxis)
				{
					mMUamESszladhisPrPNsPYErORya += bfhfQQPHIOXGnVUXLAiiulglmrb.kXoKOSZJMKwATOiGMaylYIDqdDnb * uhxBgBGBFGVnUELmixUqJqpnwoOn.mouseXYAxisSensitivity;
					num = 323243481;
					continue;
				}
				goto case 16;
			case 14:
				goto IL_031d;
			case 0:
				if (bfhfQQPHIOXGnVUXLAiiulglmrb.MzATACNcsUpFsuEcdOAkGvOQVeI._axisContribution == Pole.Positive)
				{
					twUqTGxynTqdqWgYtoilShqzypY(ref TrokSaTyUuCmhblKxgHskGumQaoR, bfhfQQPHIOXGnVUXLAiiulglmrb.OileThpvkAvMNYbGPcNUiZbAZKu);
					num = 323243507;
					continue;
				}
				goto case 22;
			case 22:
				twUqTGxynTqdqWgYtoilShqzypY(ref miZgyYaVFtrdXyosbCXMBruWeKge, bfhfQQPHIOXGnVUXLAiiulglmrb.OileThpvkAvMNYbGPcNUiZbAZKu);
				num = 323243469;
				continue;
			case 36:
				goto IL_037c;
			case 33:
				num = 323243483;
				continue;
			case 34:
				throw new NotImplementedException();
			case 37:
				num = 323243504;
				continue;
			case 9:
				num5 = num3;
				num = 323243491;
				continue;
			case 15:
				num4 /= oodscuzZOTZCQfWWmuRfPatWVPV;
				num = 323243500;
				continue;
			case 27:
				current = ACTQwoyXaDfCSbHZCZNqtbGAUFh.current;
				if (zwgAVZCxcUqkUVeFEgwfcqhdLwxy != 0)
				{
					goto IL_0137;
				}
				x = current.ovQzdxsBDxLwGUUMLOIPhnnFdnm.x;
				if (x == 0f)
				{
					goto case 35;
				}
				goto IL_040f;
			case 43:
				goto IL_0438;
			case 41:
				throw new NotImplementedException();
			case 5:
				mMUamESszladhisPrPNsPYErORya += bfhfQQPHIOXGnVUXLAiiulglmrb.kXoKOSZJMKwATOiGMaylYIDqdDnb * uhxBgBGBFGVnUELmixUqJqpnwoOn.mouseOtherAxisSensitivity;
				num = 323243483;
				continue;
			case 47:
				wvlgBwupvgdRpJFfTubhlIdLccKv = YHUHApUmpiFpUrvceHJyDOLvLwBS;
				if (!BdgIlNfBSgMruspNkDePcrIffUrj)
				{
					yWHggWFuqgoCMTrtaQzkhrVzckEV();
					ppxVBStVZRvXtLeOlWBdiAYFRuK();
					num = 323243518;
					continue;
				}
				goto case 6;
			case 44:
				num3 = Screen.width;
				num = 323243505;
				continue;
			case 4:
				goto IL_04d1;
			case 13:
				if (uhxBgBGBFGVnUELmixUqJqpnwoOn.mouseXYAxisDeltaCalc == MouseXYAxisDeltaCalc.Normal)
				{
					num3 = Screen.width;
					num = 323243499;
					continue;
				}
				goto IL_0438;
			case 12:
				num = 323243513;
				continue;
			case 48:
				twUqTGxynTqdqWgYtoilShqzypY(ref miZgyYaVFtrdXyosbCXMBruWeKge, bfhfQQPHIOXGnVUXLAiiulglmrb.OileThpvkAvMNYbGPcNUiZbAZKu);
				num = 323243513;
				continue;
			case 2:
				switch (bfhfQQPHIOXGnVUXLAiiulglmrb.zuflxLDDlsAzheAbacujlNuvLMDc)
				{
				case ControllerType.Mouse:
					break;
				case ControllerType.Custom:
					goto IL_0221;
				case ControllerType.Joystick:
					goto IL_04d1;
				default:
					goto IL_0557;
				}
				goto IL_017f;
			case 54:
				bfhfQQPHIOXGnVUXLAiiulglmrb = BfhfQQPHIOXGnVUXLAiiulglmrb;
				zwgAVZCxcUqkUVeFEgwfcqhdLwxy = bfhfQQPHIOXGnVUXLAiiulglmrb.MzATACNcsUpFsuEcdOAkGvOQVeI.ZwgAVZCxcUqkUVeFEgwfcqhdLwxy;
				kvdlrvWSNbhDlFVfOcpmgDtILax(bfhfQQPHIOXGnVUXLAiiulglmrb.EnKkaiEMISMHdBHJLGCBcerSsFgw, bfhfQQPHIOXGnVUXLAiiulglmrb.eRtoQSFdzNGKcVeofCcwFdixCwlq, bfhfQQPHIOXGnVUXLAiiulglmrb.MzATACNcsUpFsuEcdOAkGvOQVeI);
				if (bfhfQQPHIOXGnVUXLAiiulglmrb.ERFGOjgLTTFXpgYjkdzhlHHCfvY != ControllerElementType.Button)
				{
					goto IL_031d;
				}
				if (!bfhfQQPHIOXGnVUXLAiiulglmrb.PvOhYxiopZcvkPpUuowyoPRTWvw)
				{
					goto case 0;
				}
				goto IL_05a6;
			case 46:
				goto IL_05c7;
			case 8:
				goto IL_05e8;
			case 31:
				if (uhxBgBGBFGVnUELmixUqJqpnwoOn.mouseXYAxisMode == MouseXYAxisMode.Speed)
				{
					num2 /= oodscuzZOTZCQfWWmuRfPatWVPV;
					num = 323243490;
					continue;
				}
				goto case 26;
			case 25:
				if ((bfhfQQPHIOXGnVUXLAiiulglmrb.OileThpvkAvMNYbGPcNUiZbAZKu & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) != ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr)
				{
					VRmFggrEHJoymdtFkHWMHTbBhLU = true;
				}
				return;
			case 45:
				XZANdfYifjgwhXhgQQOrACAOjaf(bfhfQQPHIOXGnVUXLAiiulglmrb, 0f, true);
				num = 323243486;
				continue;
			case 52:
				GfLknZuqZfsjZqipemVCDxEudwG += (int)(1f * MathTools.Sign(bfhfQQPHIOXGnVUXLAiiulglmrb.kXoKOSZJMKwATOiGMaylYIDqdDnb));
				num = 323243497;
				continue;
			case 53:
				goto IL_067b;
			case 16:
				if (uhxBgBGBFGVnUELmixUqJqpnwoOn.mouseXYAxisMode == MouseXYAxisMode.ScreenPositionDelta)
				{
					goto case 13;
				}
				goto IL_06ad;
			case 51:
				goto IL_06cf;
			case 6:
				NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.nkqOARDzfZjuHoAuTVbGdBigvjz = ZLszVLHJDuxaDhIIlAyiUZMJSMR;
				num = 323243470;
				continue;
			case 29:
				return;
			case 23:
				goto IL_0714;
			case 18:
				twUqTGxynTqdqWgYtoilShqzypY(ref TrokSaTyUuCmhblKxgHskGumQaoR, bfhfQQPHIOXGnVUXLAiiulglmrb.OileThpvkAvMNYbGPcNUiZbAZKu);
				num = 323243508;
				continue;
			case 49:
				return;
				IL_0221:
				TijpHRejjbkTicBCtIyZYuQVeKL(bfhfQQPHIOXGnVUXLAiiulglmrb, uhxBgBGBFGVnUELmixUqJqpnwoOn.customControllerAxisSensitivity);
				return;
				IL_0557:
				num = 323243473;
				continue;
				IL_04d1:
				TijpHRejjbkTicBCtIyZYuQVeKL(bfhfQQPHIOXGnVUXLAiiulglmrb, uhxBgBGBFGVnUELmixUqJqpnwoOn.joystickAxisSensitivity);
				return;
			}
			break;
			IL_0714:
			if (uhxBgBGBFGVnUELmixUqJqpnwoOn.mouseOtherAxisMode != MouseOtherAxisMode.DigitalAxis)
			{
				goto IL_072c;
			}
			goto IL_0734;
			IL_067b:
			int num6;
			if (bfhfQQPHIOXGnVUXLAiiulglmrb.kXoKOSZJMKwATOiGMaylYIDqdDnb != 0f)
			{
				num = 323243468;
				num6 = num;
			}
			else
			{
				num = 323243489;
				num6 = num;
			}
			continue;
			IL_037c:
			int num7;
			if (uhxBgBGBFGVnUELmixUqJqpnwoOn.mouseOtherAxisMode != MouseOtherAxisMode.MouseAxis)
			{
				num = 323243483;
				num7 = num;
			}
			else
			{
				num = 323243517;
				num7 = num;
			}
			continue;
			IL_0137:
			y = current.ovQzdxsBDxLwGUUMLOIPhnnFdnm.y;
			int num8;
			if (y != 0f)
			{
				num = 323243471;
				num8 = num;
			}
			else
			{
				num = 323243483;
				num8 = num;
			}
			continue;
			IL_05a6:
			int num9;
			if (bfhfQQPHIOXGnVUXLAiiulglmrb.MzATACNcsUpFsuEcdOAkGvOQVeI._axisContribution != Pole.Positive)
			{
				num = 323243464;
				num9 = num;
			}
			else
			{
				num = 323243498;
				num9 = num;
			}
			continue;
			IL_072c:
			num = 323243474;
			int num10 = num;
			continue;
			IL_017f:
			if (zwgAVZCxcUqkUVeFEgwfcqhdLwxy >= 2)
			{
				goto IL_023e;
			}
			if (uhxBgBGBFGVnUELmixUqJqpnwoOn.mouseXYAxisMode != MouseXYAxisMode.DigitalAxis)
			{
				num = 323243519;
				continue;
			}
			goto IL_0734;
			IL_040f:
			num4 = x / num3;
			int num11;
			if (uhxBgBGBFGVnUELmixUqJqpnwoOn.mouseXYAxisMode == MouseXYAxisMode.Speed)
			{
				num = 323243511;
				num11 = num;
			}
			else
			{
				num = 323243500;
				num11 = num;
			}
			continue;
			IL_06ad:
			int num12;
			if (uhxBgBGBFGVnUELmixUqJqpnwoOn.mouseXYAxisMode != MouseXYAxisMode.Speed)
			{
				num = 323243483;
				num12 = num;
			}
			else
			{
				num = 323243509;
				num12 = num;
			}
			continue;
			IL_0438:
			int num13;
			if (uhxBgBGBFGVnUELmixUqJqpnwoOn.mouseXYAxisDeltaCalc == MouseXYAxisDeltaCalc.ScreenWidth)
			{
				num = 323243476;
				num13 = num;
			}
			else
			{
				num = 323243472;
				num13 = num;
			}
			continue;
			IL_031d:
			int num14;
			if (bfhfQQPHIOXGnVUXLAiiulglmrb.ERFGOjgLTTFXpgYjkdzhlHHCfvY != ControllerElementType.Axis)
			{
				num = 323243482;
				num14 = num;
			}
			else
			{
				num = 323243514;
				num14 = num;
			}
			continue;
			IL_0734:
			num = 323243477;
			num10 = num;
			continue;
			IL_023e:
			if (zwgAVZCxcUqkUVeFEgwfcqhdLwxy > 1)
			{
				num = 323243503;
				continue;
			}
			goto IL_072c;
		}
		goto IL_0038;
		IL_05c7:
		int num15;
		if (wvlgBwupvgdRpJFfTubhlIdLccKv != YHUHApUmpiFpUrvceHJyDOLvLwBS)
		{
			num = 323243479;
			num15 = num;
		}
		else
		{
			num = 323243470;
			num15 = num;
		}
		goto IL_003d;
		IL_06cf:
		if (BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			ppxVBStVZRvXtLeOlWBdiAYFRuK();
			num = 323243485;
			goto IL_003d;
		}
		goto IL_0162;
	}

	private void TijpHRejjbkTicBCtIyZYuQVeKL(bfNFWLKmIfaxCAouEsisTLpvNRI P_0, float P_1)
	{
		float num = P_0.kXoKOSZJMKwATOiGMaylYIDqdDnb * P_1;
		if (P_0.kcUkzUUmQinWqPQVjpoRmhnIrvG)
		{
			goto IL_0011;
		}
		goto IL_008e;
		IL_0011:
		int num2 = 1639802069;
		goto IL_0016;
		IL_0016:
		while (true)
		{
			switch (num2 ^ 0x61BD64DF)
			{
			case 9:
				break;
			case 7:
				WhwwbeKETWbQzJABduJoRiGHDxJh = num;
				num2 = 1639802079;
				continue;
			case 3:
				if (P_0.KEQXdsTLOgsSTOrMbmKfSLOsbql == AxisCoordinateMode.Relative)
				{
					if (rSsQMTISxCgUDuCMBzwNXBhyWWZ != AxisCoordinateMode.Relative)
					{
						kGTDAtFYNtTEYOgcxSobqyeVuzwp = num;
						rSsQMTISxCgUDuCMBzwNXBhyWWZ = AxisCoordinateMode.Relative;
						num2 = 1639802073;
						continue;
					}
					goto case 1;
				}
				goto default;
			case 5:
				goto IL_008e;
			case 10:
				if (P_0.KEQXdsTLOgsSTOrMbmKfSLOsbql != AxisCoordinateMode.Absolute)
				{
					goto case 3;
				}
				if (rSsQMTISxCgUDuCMBzwNXBhyWWZ == AxisCoordinateMode.Absolute)
				{
					kGTDAtFYNtTEYOgcxSobqyeVuzwp += num;
					num2 = 1639802073;
					continue;
				}
				goto default;
			case 0:
				dMVbWJDCRCKtzcVqhdkEKaBrBCqw = AxisCoordinateMode.Relative;
				num2 = 1639802073;
				continue;
			case 1:
				kGTDAtFYNtTEYOgcxSobqyeVuzwp = MathTools.MaxMagnitude(kGTDAtFYNtTEYOgcxSobqyeVuzwp, num);
				num2 = 1639802071;
				continue;
			case 8:
				num2 = 1639802073;
				continue;
			case 2:
				if (P_0.KEQXdsTLOgsSTOrMbmKfSLOsbql == AxisCoordinateMode.Relative)
				{
					goto IL_0115;
				}
				goto default;
			case 11:
				if (MathTools.Abs(num) > MathTools.Abs(WhwwbeKETWbQzJABduJoRiGHDxJh))
				{
					WhwwbeKETWbQzJABduJoRiGHDxJh = num;
					num2 = 1639802073;
					continue;
				}
				goto default;
			case 4:
				if (dMVbWJDCRCKtzcVqhdkEKaBrBCqw == AxisCoordinateMode.Absolute && MathTools.Abs(num) > MathTools.Abs(WhwwbeKETWbQzJABduJoRiGHDxJh))
				{
					WhwwbeKETWbQzJABduJoRiGHDxJh = num;
					num2 = 1639802073;
					continue;
				}
				goto default;
			default:
				XZANdfYifjgwhXhgQQOrACAOjaf(P_0, uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonDeadZone, false);
				return;
			}
			break;
			IL_0115:
			int num3;
			if (dMVbWJDCRCKtzcVqhdkEKaBrBCqw != AxisCoordinateMode.Relative)
			{
				num2 = 1639802072;
				num3 = num2;
			}
			else
			{
				num2 = 1639802068;
				num3 = num2;
			}
		}
		goto IL_0011;
		IL_008e:
		int num4;
		if (P_0.KEQXdsTLOgsSTOrMbmKfSLOsbql == AxisCoordinateMode.Absolute)
		{
			num2 = 1639802075;
			num4 = num2;
		}
		else
		{
			num2 = 1639802077;
			num4 = num2;
		}
		goto IL_0016;
	}

	private void XZANdfYifjgwhXhgQQOrACAOjaf(bfNFWLKmIfaxCAouEsisTLpvNRI P_0, float P_1, bool P_2)
	{
		qTKJmxoqbugShRsjWFlkNISfBeOh qTKJmxoqbugShRsjWFlkNISfBeOh2 = qTKJmxoqbugShRsjWFlkNISfBeOh.acgYzaDYmGYvlaPXYdbaLFYHGHr(P_0.MzATACNcsUpFsuEcdOAkGvOQVeI.KAixZgRycuVSHIYaEVNGzKGIdgV);
		if (P_0.MzATACNcsUpFsuEcdOAkGvOQVeI._axisRange != AxisRange.Full)
		{
			goto IL_00d8;
		}
		if (MathTools.Abs(P_0.kXoKOSZJMKwATOiGMaylYIDqdDnb) > P_1)
		{
			goto IL_0032;
		}
		goto IL_012c;
		IL_00d8:
		if (P_0.MzATACNcsUpFsuEcdOAkGvOQVeI._axisContribution != Pole.Positive)
		{
			goto IL_0283;
		}
		int num;
		if (P_0.kXoKOSZJMKwATOiGMaylYIDqdDnb > P_1)
		{
			qTKJmxoqbugShRsjWFlkNISfBeOh2.FDUPgKMNLWXEqMouNKGVccdREbBC(ccchNwVcItfPOfcqSbtVmUSmBvb, true);
			num = 1413578298;
			goto IL_0037;
		}
		goto IL_02a5;
		IL_0032:
		num = 1413578294;
		goto IL_0037;
		IL_0037:
		ButtonStateFlags buttonStateFlags2 = default(ButtonStateFlags);
		ButtonStateFlags buttonStateFlags = default(ButtonStateFlags);
		ButtonStateFlags buttonStateFlags3 = default(ButtonStateFlags);
		while (true)
		{
			switch (num ^ 0x54417E3A)
			{
			case 6:
				break;
			default:
				return;
			case 11:
				goto IL_0097;
			case 10:
				VRmFggrEHJoymdtFkHWMHTbBhLU = true;
				num = 1413578280;
				continue;
			case 17:
				buttonStateFlags2 = qTKJmxoqbugShRsjWFlkNISfBeOh2.HBheUGHlALjcBHUEhxQKiOomeZUG(false);
				num = 1413578299;
				continue;
			case 14:
				goto IL_00d8;
			case 12:
				qTKJmxoqbugShRsjWFlkNISfBeOh2.FDUPgKMNLWXEqMouNKGVccdREbBC(ccchNwVcItfPOfcqSbtVmUSmBvb, P_0.kXoKOSZJMKwATOiGMaylYIDqdDnb > 0f);
				num = 1413578291;
				continue;
			case 9:
				goto IL_012c;
			case 7:
				VRmFggrEHJoymdtFkHWMHTbBhLU = true;
				return;
			case 8:
				qTKJmxoqbugShRsjWFlkNISfBeOh2.FDUPgKMNLWXEqMouNKGVccdREbBC(ccchNwVcItfPOfcqSbtVmUSmBvb, false);
				num = 1413578293;
				continue;
			case 19:
				GfLknZuqZfsjZqipemVCDxEudwG += (int)(1f * MathTools.Sign(P_0.kXoKOSZJMKwATOiGMaylYIDqdDnb));
				NNjBUPooowtMrXUsArfJxNYSUUt.KZkCmzhSYSECcInSnhPgKBxtRsI(P_0);
				num = 1413578297;
				continue;
			case 4:
				goto IL_019c;
			case 5:
				GfLknZuqZfsjZqipemVCDxEudwG += (int)(1f * MathTools.Sign(P_0.kXoKOSZJMKwATOiGMaylYIDqdDnb));
				num = 1413578296;
				continue;
			case 15:
				buttonStateFlags = qTKJmxoqbugShRsjWFlkNISfBeOh2.HBheUGHlALjcBHUEhxQKiOomeZUG(false);
				num = 1413578295;
				continue;
			case 3:
				goto IL_01ff;
			case 1:
				goto IL_0218;
			case 2:
				NNjBUPooowtMrXUsArfJxNYSUUt.KZkCmzhSYSECcInSnhPgKBxtRsI(P_0);
				num = 1413578301;
				continue;
			case 13:
				twUqTGxynTqdqWgYtoilShqzypY(ref miZgyYaVFtrdXyosbCXMBruWeKge, buttonStateFlags);
				num = 1413578302;
				continue;
			case 16:
				goto IL_0283;
			case 0:
				goto IL_02a5;
			case 18:
				return;
			}
			break;
			IL_0218:
			twUqTGxynTqdqWgYtoilShqzypY(ref TrokSaTyUuCmhblKxgHskGumQaoR, buttonStateFlags3);
			twUqTGxynTqdqWgYtoilShqzypY(ref miZgyYaVFtrdXyosbCXMBruWeKge, buttonStateFlags2);
			if (!P_2)
			{
				return;
			}
			if ((buttonStateFlags3 & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) == 0)
			{
				int num2;
				if ((buttonStateFlags2 & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) == 0)
				{
					num = 1413578280;
					num2 = num;
				}
				else
				{
					num = 1413578289;
					num2 = num;
				}
				continue;
			}
			goto IL_0097;
			IL_0097:
			int num3;
			if (P_0.kXoKOSZJMKwATOiGMaylYIDqdDnb != 0f)
			{
				num = 1413578303;
				num3 = num;
			}
			else
			{
				num = 1413578301;
				num3 = num;
			}
			continue;
			IL_01ff:
			int num4;
			if ((buttonStateFlags & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) != ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr)
			{
				num = 1413578288;
				num4 = num;
			}
			else
			{
				num = 1413578280;
				num4 = num;
			}
			continue;
			IL_019c:
			if (P_2)
			{
				int num5;
				if (P_0.kXoKOSZJMKwATOiGMaylYIDqdDnb != 0f)
				{
					num = 1413578281;
					num5 = num;
				}
				else
				{
					num = 1413578297;
					num5 = num;
				}
				continue;
			}
			return;
		}
		goto IL_0032;
		IL_0283:
		int num6;
		if (MathTools.Abs(P_0.kXoKOSZJMKwATOiGMaylYIDqdDnb) > P_1)
		{
			num = 1413578290;
			num6 = num;
		}
		else
		{
			num = 1413578293;
			num6 = num;
		}
		goto IL_0037;
		IL_02a5:
		buttonStateFlags = qTKJmxoqbugShRsjWFlkNISfBeOh2.HBheUGHlALjcBHUEhxQKiOomeZUG(true);
		twUqTGxynTqdqWgYtoilShqzypY(ref TrokSaTyUuCmhblKxgHskGumQaoR, buttonStateFlags);
		num = 1413578302;
		goto IL_0037;
		IL_012c:
		buttonStateFlags3 = qTKJmxoqbugShRsjWFlkNISfBeOh2.HBheUGHlALjcBHUEhxQKiOomeZUG(true);
		num = 1413578283;
		goto IL_0037;
	}

	internal void IEhczglOxbiQcBHgRNtgWwfaNlO()
	{
		if (KUKFALZvnGChudWPnDkiaxrhCaEE != YHUHApUmpiFpUrvceHJyDOLvLwBS)
		{
			goto IL_0010;
		}
		goto IL_0245;
		IL_0010:
		int num = 1700851921;
		goto IL_0015;
		IL_0015:
		kGJwXaTIOiUZiBkkBQQFhucmNIh.rJhIQDxqRYMCcbRAhxwzwiNXrlz cLjmYleEuCraJMMUJEFwtuAaGlg = default(kGJwXaTIOiUZiBkkBQQFhucmNIh.rJhIQDxqRYMCcbRAhxwzwiNXrlz);
		bool flag = default(bool);
		float lQuVTkcbTYttAuUkysEfHJfgNuK = default(float);
		while (true)
		{
			switch (num ^ 0x6560F0DE)
			{
			case 7:
				break;
			default:
				return;
			case 15:
				pnbrdZwKvfGuMdGIxtXIcSwuZSA(false);
				return;
			case 13:
				xMbriEKRUyBUtHdeADZXgZltXYZ();
				cLjmYleEuCraJMMUJEFwtuAaGlg.XAnWRZQkoUxMGIsJKoBVsqxrTkQ(ZLszVLHJDuxaDhIIlAyiUZMJSMR);
				num = 1700851922;
				continue;
			case 12:
				if (cLjmYleEuCraJMMUJEFwtuAaGlg.ZTthsIyWvwsmOqgEynZhYUqgpGC != null)
				{
					if (FDWmPtTmCBoydpMglKDYeZvgpzJ())
					{
						cLjmYleEuCraJMMUJEFwtuAaGlg.ZTthsIyWvwsmOqgEynZhYUqgpGC.Start(uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonDownBuffer);
						num = 1700851924;
						continue;
					}
					goto case 10;
				}
				goto case 2;
			case 10:
				flag = WtazeRrShpTFFLJCbcgFEqLnkKJe();
				num = 1700851914;
				continue;
			case 1:
				if (mMXnhPMMMxphLALbWPoFkWTCBQS)
				{
					cLjmYleEuCraJMMUJEFwtuAaGlg.bAIoHrKgeGHqHImVWWOrusYtQlkv();
					mMXnhPMMMxphLALbWPoFkWTCBQS = false;
					num = 1700851923;
					continue;
				}
				goto case 13;
			case 5:
				cLjmYleEuCraJMMUJEFwtuAaGlg.lQuVTkcbTYttAuUkysEfHJfgNuK = WhwwbeKETWbQzJABduJoRiGHDxJh;
				cLjmYleEuCraJMMUJEFwtuAaGlg.KEQXdsTLOgsSTOrMbmKfSLOsbql = dMVbWJDCRCKtzcVqhdkEKaBrBCqw;
				num = 1700851916;
				continue;
			case 6:
				goto IL_012a;
			case 14:
				goto IL_015b;
			case 9:
				cLjmYleEuCraJMMUJEFwtuAaGlg.lQuVTkcbTYttAuUkysEfHJfgNuK = lQuVTkcbTYttAuUkysEfHJfgNuK;
				cLjmYleEuCraJMMUJEFwtuAaGlg.KEQXdsTLOgsSTOrMbmKfSLOsbql = rSsQMTISxCgUDuCMBzwNXBhyWWZ;
				num = 1700851935;
				continue;
			case 16:
				pnbrdZwKvfGuMdGIxtXIcSwuZSA(true);
				num = 1700851926;
				continue;
			case 2:
				cLjmYleEuCraJMMUJEFwtuAaGlg.CaayQnwIGhrIaAMNFhRFGSJabhR(VoFALJiXKwwyQgLPqqsGLZcLBoM(), OMsDoddGLoMsnAOixNusrDCoKsdq(), npsYQCyKleLimEhZDAdnaxnwlFNO(), nkChpEwCeyIAcExUuFGdJLElwIA());
				num = 1700851933;
				continue;
			case 0:
				lQuVTkcbTYttAuUkysEfHJfgNuK = MathTools.Clamp(kGTDAtFYNtTEYOgcxSobqyeVuzwp, -1f, 1f);
				num = 1700851927;
				continue;
			case 4:
				KJqfacjrdEssKMCBtorPHaclNr();
				num = 1700851928;
				continue;
			case 3:
				goto IL_0202;
			case 19:
				cLjmYleEuCraJMMUJEFwtuAaGlg.lQuVTkcbTYttAuUkysEfHJfgNuK = mMUamESszladhisPrPNsPYErORya;
				cLjmYleEuCraJMMUJEFwtuAaGlg.KEQXdsTLOgsSTOrMbmKfSLOsbql = AxisCoordinateMode.Relative;
				num = 1700851935;
				continue;
			case 18:
				num = 1700851935;
				continue;
			case 17:
				goto IL_0245;
			case 20:
				if (flag)
				{
					cLjmYleEuCraJMMUJEFwtuAaGlg.qLWvyJPDjNEPcAoYLwGLbbPWbLy.Start(uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonDownBuffer);
					num = 1700851932;
					continue;
				}
				goto case 2;
			case 11:
				goto IL_027f;
			case 8:
				return;
			}
			break;
			IL_0202:
			int num2;
			if (!MNuWEVVEgRHtaaFYNrfCpurhHyl)
			{
				num = 1700851928;
				num2 = num;
			}
			else
			{
				num = 1700851930;
				num2 = num;
			}
			continue;
			IL_015b:
			int num3;
			if (WhwwbeKETWbQzJABduJoRiGHDxJh != 0f)
			{
				num = 1700851931;
				num3 = num;
			}
			else
			{
				num = 1700851934;
				num3 = num;
			}
			continue;
			IL_012a:
			if (wvlgBwupvgdRpJFfTubhlIdLccKv != YHUHApUmpiFpUrvceHJyDOLvLwBS)
			{
				int num4;
				if (NEroqLjuwCtLFvVbPBNzgAFFsqi.hTMiRpvIcXoGHKjaNTYlZGHmefX())
				{
					num = 1700851918;
					num4 = num;
				}
				else
				{
					num = 1700851926;
					num4 = num;
				}
				continue;
			}
			return;
		}
		goto IL_0010;
		IL_0245:
		if (cfbLtZVfchvCddmhvLrshzbsxkD == yRVJEGLVcDQyieRzpOtUzcxwGkL.AKrlzAhTDjmUJonCJxVBSdhjiKH)
		{
			return;
		}
		goto IL_027f;
		IL_027f:
		cLjmYleEuCraJMMUJEFwtuAaGlg = NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg;
		cLjmYleEuCraJMMUJEFwtuAaGlg.OileThpvkAvMNYbGPcNUiZbAZKu = TrokSaTyUuCmhblKxgHskGumQaoR;
		cLjmYleEuCraJMMUJEFwtuAaGlg.uVmAVvVvxJKaGooIdMLxEhzhVTg = miZgyYaVFtrdXyosbCXMBruWeKge;
		int num5;
		if (mMUamESszladhisPrPNsPYErORya != 0f)
		{
			num = 1700851917;
			num5 = num;
		}
		else
		{
			num = 1700851920;
			num5 = num;
		}
		goto IL_0015;
	}

	internal void xMbriEKRUyBUtHdeADZXgZltXYZ()
	{
		if (NNjBUPooowtMrXUsArfJxNYSUUt.YORsZWHKqfvSwofazZpoPgrtBHAK)
		{
			goto IL_0010;
		}
		goto IL_01e0;
		IL_0010:
		int num = 1721066693;
		goto IL_0015;
		IL_0015:
		float digitalAxisGravity = default(float);
		UChyDAIORuXqDhvbfagyRDSNGSiJ kURctxaNhRMfpOnYVpVxCJgmubcC = default(UChyDAIORuXqDhvbfagyRDSNGSiJ);
		float num2 = default(float);
		float num4 = default(float);
		float digitalAxisSensitivity = default(float);
		float num7 = default(float);
		float num11 = default(float);
		while (true)
		{
			switch (num ^ 0x669564D0)
			{
			case 13:
				break;
			case 7:
				goto IL_0089;
			case 10:
				digitalAxisGravity = uhxBgBGBFGVnUELmixUqJqpnwoOn.digitalAxisGravity;
				num = 1721066712;
				continue;
			case 4:
				goto IL_00b2;
			case 20:
				kURctxaNhRMfpOnYVpVxCJgmubcC = NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.KURctxaNhRMfpOnYVpVxCJgmubcC;
				num = 1721066695;
				continue;
			case 0:
				num2 += NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF;
				num = 1721066691;
				continue;
			case 2:
			case 9:
				goto IL_0106;
			case 5:
				goto IL_0125;
			case 14:
				goto IL_0149;
			case 1:
			{
				float num3 = ((NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF > 0f) ? (-1f) : 1f);
				NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF = MathTools.Clamp(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF + num3 * num4, -1f, 1f);
				num = 1721066692;
				continue;
			}
			case 24:
				goto IL_01e0;
			case 15:
				return;
			case 17:
				num2 *= digitalAxisSensitivity * oodscuzZOTZCQfWWmuRfPatWVPV;
				num = 1721066710;
				continue;
			case 6:
				if (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF == 0f)
				{
					goto case 0;
				}
				goto IL_02aa;
			case 21:
				NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.KURctxaNhRMfpOnYVpVxCJgmubcC.KZkCmzhSYSECcInSnhPgKBxtRsI(NNjBUPooowtMrXUsArfJxNYSUUt);
				num = 1721066696;
				continue;
			case 8:
				goto IL_02ec;
			case 11:
				goto IL_0308;
			case 12:
				return;
			case 16:
				goto IL_0341;
			case 3:
				goto IL_0384;
			case 18:
				goto IL_03cc;
			case 23:
				kvdlrvWSNbhDlFVfOcpmgDtILax(kURctxaNhRMfpOnYVpVxCJgmubcC.EnKkaiEMISMHdBHJLGCBcerSsFgw, kURctxaNhRMfpOnYVpVxCJgmubcC.eRtoQSFdzNGKcVeofCcwFdixCwlq, kURctxaNhRMfpOnYVpVxCJgmubcC.MzATACNcsUpFsuEcdOAkGvOQVeI);
				num = 1721066719;
				continue;
			case 22:
				NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF = 0f;
				NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.KURctxaNhRMfpOnYVpVxCJgmubcC.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
				return;
			default:
				goto IL_0491;
			}
			break;
			IL_0384:
			float num5 = 0f;
			goto IL_03a0;
			IL_0341:
			num4 = uhxBgBGBFGVnUELmixUqJqpnwoOn.digitalAxisGravity * oodscuzZOTZCQfWWmuRfPatWVPV;
			int num6;
			if (MathTools.Abs(num4) < MathTools.Abs(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF))
			{
				num = 1721066705;
				num6 = num;
			}
			else
			{
				num = 1721066694;
				num6 = num;
			}
			continue;
			IL_0491:
			NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF = MathTools.Clamp(num2, -1f, 1f);
			return;
			IL_03a0:
			num7 = num5;
			digitalAxisSensitivity = uhxBgBGBFGVnUELmixUqJqpnwoOn.digitalAxisSensitivity;
			int num8;
			if (digitalAxisSensitivity <= 0f)
			{
				num = 1721066710;
				num8 = num;
			}
			else
			{
				num = 1721066689;
				num8 = num;
			}
			continue;
			IL_02ec:
			int num9;
			if (digitalAxisGravity != 0f)
			{
				num = 1721066688;
				num9 = num;
			}
			else
			{
				num = 1721066719;
				num9 = num;
			}
			continue;
			IL_03cc:
			if (!uhxBgBGBFGVnUELmixUqJqpnwoOn.digitalAxisSnap)
			{
				num2 += NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF;
				num = 1721066691;
				continue;
			}
			goto IL_0491;
			IL_0106:
			num2 += NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF;
			num = 1721066691;
			continue;
			IL_02aa:
			int num10;
			if (num2 == 0f)
			{
				num = 1721066706;
				num10 = num;
			}
			else
			{
				num = 1721066711;
				num10 = num;
			}
			continue;
			IL_0125:
			if (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF == 0f)
			{
				num = 1721066707;
				continue;
			}
			num5 = MathTools.Sign(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF);
			goto IL_03a0;
			IL_0089:
			if (num11 == num7)
			{
				num = 1721066706;
				continue;
			}
			if (1 == 0)
			{
				goto IL_0106;
			}
			if (uhxBgBGBFGVnUELmixUqJqpnwoOn.digitalAxisInstantReverse)
			{
				num2 += -1f * NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF;
				num = 1721066691;
				continue;
			}
			goto IL_03cc;
		}
		goto IL_0010;
		IL_01e0:
		NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.DwGqsBkuuPDTaewFNOqlaXRkLqq = MathTools.Clamp(GfLknZuqZfsjZqipemVCDxEudwG, -1f, 1f);
		if (!uhxBgBGBFGVnUELmixUqJqpnwoOn.digitalAxisSimulation)
		{
			NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF = NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.DwGqsBkuuPDTaewFNOqlaXRkLqq;
			if (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.KURctxaNhRMfpOnYVpVxCJgmubcC.YORsZWHKqfvSwofazZpoPgrtBHAK)
			{
				NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.KURctxaNhRMfpOnYVpVxCJgmubcC.QYwkAfdRMMgAPnyPzHFUdcsKUPp();
				num = 1721066716;
				goto IL_0015;
			}
			return;
		}
		goto IL_0149;
		IL_0308:
		num2 = MathTools.Clamp(GfLknZuqZfsjZqipemVCDxEudwG, -1f, 1f);
		float num12;
		if (num2 != 0f)
		{
			num12 = MathTools.Sign(num2);
			goto IL_00c0;
		}
		num = 1721066708;
		goto IL_0015;
		IL_00c0:
		num11 = num12;
		num = 1721066709;
		goto IL_0015;
		IL_0149:
		if (!VRmFggrEHJoymdtFkHWMHTbBhLU)
		{
			int num13;
			if (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF == 0f)
			{
				num = 1721066719;
				num13 = num;
			}
			else
			{
				num = 1721066714;
				num13 = num;
			}
			goto IL_0015;
		}
		goto IL_0308;
		IL_00b2:
		num12 = 0f;
		goto IL_00c0;
	}

	public float BscAVytxcCBkilFutmFsULYtqRF()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return 0f;
		}
		if (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.KEQXdsTLOgsSTOrMbmKfSLOsbql == AxisCoordinateMode.Relative)
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lQuVTkcbTYttAuUkysEfHJfgNuK;
		}
		return MathTools.MaxMagnitude(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lQuVTkcbTYttAuUkysEfHJfgNuK, NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF);
	}

	public float nBcptjXKjHAyjSgEkspdFFUtFBF()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return 0f;
		}
		if (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.TJvHrEoQVwzPoVmElNLgLKJYqzO == AxisCoordinateMode.Relative)
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OrhmdNWisuEhZlmphsKhqFZrmVz;
		}
		return MathTools.MaxMagnitude(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OrhmdNWisuEhZlmphsKhqFZrmVz, NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.ptbHkXOofUPlvjsbwcufTCwnGuc);
	}

	public float FWqrdMBKKArdbCsaupQHAvMUZeZ()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return 0f;
		}
		return BscAVytxcCBkilFutmFsULYtqRF() - nBcptjXKjHAyjSgEkspdFFUtFBF();
	}

	public float QlsZJKCPPdMMezfBNiIPqeuYKCU()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return 0f;
		}
		return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vAxisTimeActive;
	}

	public float IsCKtsVajcjEGiegzADGjaKbpPrp()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			while (true)
			{
				int num = 807319431;
				while (true)
				{
					switch (num ^ 0x301EB786)
					{
					case 0:
						break;
					case 1:
						GoYJimAYxwnmYPxHNmLUKooIsMq();
						num = 807319428;
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
		return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vAxisTimeInactive;
	}

	public AxisCoordinateMode ZzCfsKahtdtlpsxqCePBmIIDunbH()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lQuVTkcbTYttAuUkysEfHJfgNuK) >= MathTools.Abs(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lDWmkiSjNqiToBhXEwfFSpXwJhWF))
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.KEQXdsTLOgsSTOrMbmKfSLOsbql;
		}
		return AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode bDEegGHDBrFOfRFVTkpQgjrgjloI()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OrhmdNWisuEhZlmphsKhqFZrmVz) >= MathTools.Abs(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.ptbHkXOofUPlvjsbwcufTCwnGuc))
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.TJvHrEoQVwzPoVmElNLgLKJYqzO;
		}
		return AxisCoordinateMode.Absolute;
	}

	public float KfAFlDbMroUFANmhWhpKpXVscgPy()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return 0f;
		}
		if (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.KEQXdsTLOgsSTOrMbmKfSLOsbql == AxisCoordinateMode.Relative)
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lQuVTkcbTYttAuUkysEfHJfgNuK;
		}
		return MathTools.MaxMagnitude(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lQuVTkcbTYttAuUkysEfHJfgNuK, NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.DwGqsBkuuPDTaewFNOqlaXRkLqq);
	}

	public float RFtmscItPvoqKaeIKqYmnAxaEFjc()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return 0f;
		}
		if (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.TJvHrEoQVwzPoVmElNLgLKJYqzO == AxisCoordinateMode.Relative)
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OrhmdNWisuEhZlmphsKhqFZrmVz;
		}
		return MathTools.MaxMagnitude(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OrhmdNWisuEhZlmphsKhqFZrmVz, NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.MTTYQyuEoxdgbEPIwwOoMPXXKnDB);
	}

	public float ovrCLOGpIbrcKBnmgOGqeGVtoJOl()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return 0f;
		}
		return KfAFlDbMroUFANmhWhpKpXVscgPy() - RFtmscItPvoqKaeIKqYmnAxaEFjc();
	}

	public float LJWSkgbzTlDfRuxelvtoMqlKbck()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return 0f;
		}
		return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vAxisRawTimeActive;
	}

	public float TrkGHhjmArHpdwqsdHfVGLRIPUA()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			GoYJimAYxwnmYPxHNmLUKooIsMq();
		}
		return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vAxisRawTimeInactive;
	}

	public AxisCoordinateMode yuyzRIpPZDneVqqZyFLhjQWxykJ()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.lQuVTkcbTYttAuUkysEfHJfgNuK) >= MathTools.Abs(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.DwGqsBkuuPDTaewFNOqlaXRkLqq))
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.KEQXdsTLOgsSTOrMbmKfSLOsbql;
		}
		return AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode LjedWJflqCBcmHyMkmozYLDVmKUF()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OrhmdNWisuEhZlmphsKhqFZrmVz) >= MathTools.Abs(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.MTTYQyuEoxdgbEPIwwOoMPXXKnDB))
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.TJvHrEoQVwzPoVmElNLgLKJYqzO;
		}
		return AxisCoordinateMode.Absolute;
	}

	public bool OMsDoddGLoMsnAOixNusrDCoKsdq()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			goto IL_0016;
		}
		int num;
		if ((NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OileThpvkAvMNYbGPcNUiZbAZKu & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) == 0)
		{
			num = 19602351;
			goto IL_001b;
		}
		return true;
		IL_001b:
		switch (num ^ 0x12B1BAE)
		{
		case 0:
			break;
		case 2:
			return (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OileThpvkAvMNYbGPcNUiZbAZKu & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) != 0;
		default:
			return nkChpEwCeyIAcExUuFGdJLElwIA();
		}
		goto IL_0016;
		IL_0016:
		num = 19602348;
		goto IL_001b;
	}

	public bool VoFALJiXKwwyQgLPqqsGLZcLBoM()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		if (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.ZTthsIyWvwsmOqgEynZhYUqgpGC == null)
		{
			return FDWmPtTmCBoydpMglKDYeZvgpzJ();
		}
		if (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.ZTthsIyWvwsmOqgEynZhYUqgpGC.running)
		{
			return true;
		}
		if (EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue && NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.qLWvyJPDjNEPcAoYLwGLbbPWbLy.running)
		{
			return true;
		}
		return false;
	}

	public bool zZfNFOMmkwRPDTjWQEBszXZnyS()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			return (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OileThpvkAvMNYbGPcNUiZbAZKu & ButtonStateFlags.VlhlJSuMVXjhWdLiRItrzCZLEub) != 0;
		}
		if ((NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OileThpvkAvMNYbGPcNUiZbAZKu & ButtonStateFlags.VlhlJSuMVXjhWdLiRItrzCZLEub) == 0 && (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.uVmAVvVvxJKaGooIdMLxEhzhVTg & ButtonStateFlags.VlhlJSuMVXjhWdLiRItrzCZLEub) == 0)
		{
			return false;
		}
		if ((NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OileThpvkAvMNYbGPcNUiZbAZKu & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) != ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr)
		{
			return false;
		}
		if ((NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.uVmAVvVvxJKaGooIdMLxEhzhVTg & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) != ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr)
		{
			return false;
		}
		return true;
	}

	public bool HSgGoWrdyQlRfGWElIYGTWJBSOK()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vcGZsdBKQQjrFVJAxAPxCLxZYhX.singlePressHold;
		}
		if (!NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vcGZsdBKQQjrFVJAxAPxCLxZYhX.singlePressHold)
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.fzfIWLumSWkjZvFnvzqVKbLTatR.singlePressHold;
		}
		return true;
	}

	public bool ODUcBxgJzPGmQZrvLHwtywMKnSVC()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			goto IL_0016;
		}
		bool singlePressDown = NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vcGZsdBKQQjrFVJAxAPxCLxZYhX.singlePressDown;
		int num = 721636887;
		goto IL_001b;
		IL_001b:
		bool singlePressDown2 = default(bool);
		while (true)
		{
			switch (num ^ 0x2B034E12)
			{
			case 0:
				break;
			case 3:
				return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vcGZsdBKQQjrFVJAxAPxCLxZYhX.singlePressDown;
			case 5:
				singlePressDown2 = NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.fzfIWLumSWkjZvFnvzqVKbLTatR.singlePressDown;
				if (!singlePressDown)
				{
					num = 721636880;
					continue;
				}
				goto IL_00c1;
			case 1:
				if (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vcGZsdBKQQjrFVJAxAPxCLxZYhX.singlePressHold)
				{
					return false;
				}
				goto IL_00af;
			case 2:
				if (!singlePressDown2)
				{
					return false;
				}
				goto IL_00c1;
			default:
				{
					if (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.fzfIWLumSWkjZvFnvzqVKbLTatR.singlePressHold)
					{
						return false;
					}
					goto IL_00e7;
				}
				IL_00c1:
				if (!singlePressDown)
				{
					num = 721636883;
					continue;
				}
				goto IL_00af;
				IL_00e7:
				return true;
				IL_00af:
				if (!singlePressDown2)
				{
					num = 721636886;
					continue;
				}
				goto IL_00e7;
			}
			break;
		}
		goto IL_0016;
		IL_0016:
		num = 721636881;
		goto IL_001b;
	}

	public bool VfgUqUOpVrAbpFtGMvSgiqUMoGr()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			goto IL_0016;
		}
		bool singlePressUp = NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vcGZsdBKQQjrFVJAxAPxCLxZYhX.singlePressUp;
		bool singlePressUp2 = NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.fzfIWLumSWkjZvFnvzqVKbLTatR.singlePressUp;
		int num;
		if (!singlePressUp && !singlePressUp2)
		{
			num = -1776650029;
		}
		else if (!NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vcGZsdBKQQjrFVJAxAPxCLxZYhX.singlePressHold)
		{
			if (!NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.fzfIWLumSWkjZvFnvzqVKbLTatR.singlePressHold)
			{
				return true;
			}
			num = -1776650025;
		}
		else
		{
			num = -1776650030;
		}
		goto IL_001b;
		IL_001b:
		switch (num ^ -1776650029)
		{
		case 2:
			break;
		case 3:
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vcGZsdBKQQjrFVJAxAPxCLxZYhX.singlePressUp;
		case 1:
			return false;
		case 0:
			return false;
		default:
			return false;
		}
		goto IL_0016;
		IL_0016:
		num = -1776650032;
		goto IL_001b;
	}

	public bool RuiZcjLOJskVOMqsJZYkxDIjyhA()
	{
		return RuiZcjLOJskVOMqsJZYkxDIjyhA(0f);
	}

	public bool RuiZcjLOJskVOMqsJZYkxDIjyhA(float P_0)
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		if (P_0 > 0f)
		{
			if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
			{
				return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.ZXIZggoPhfxrNYiuvgVjSKRDfNUF.dtHhNkdqjhiCGFdjTZiGIeVyhiqE(P_0);
			}
			if (!NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.ZXIZggoPhfxrNYiuvgVjSKRDfNUF.dtHhNkdqjhiCGFdjTZiGIeVyhiqE(P_0))
			{
				return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.MrRNpslzrHhMKDBYrYVaBQPElnc.dtHhNkdqjhiCGFdjTZiGIeVyhiqE(P_0);
			}
			return true;
		}
		if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vcGZsdBKQQjrFVJAxAPxCLxZYhX.doublePressHold;
		}
		if (!NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vcGZsdBKQQjrFVJAxAPxCLxZYhX.doublePressHold)
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.fzfIWLumSWkjZvFnvzqVKbLTatR.doublePressHold;
		}
		return true;
	}

	public bool zLExFcCVwGmJlXFXVImjVBwCEZKB()
	{
		return zLExFcCVwGmJlXFXVImjVBwCEZKB(0f);
	}

	public bool zLExFcCVwGmJlXFXVImjVBwCEZKB(float P_0)
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		if (!VoFALJiXKwwyQgLPqqsGLZcLBoM())
		{
			goto IL_0012;
		}
		int num;
		if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			num = -647109074;
		}
		else
		{
			if (!(P_0 > 0f))
			{
				if (!NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vcGZsdBKQQjrFVJAxAPxCLxZYhX.doublePressHold)
				{
					return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.fzfIWLumSWkjZvFnvzqVKbLTatR.doublePressHold;
				}
				return true;
			}
			if (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.ZXIZggoPhfxrNYiuvgVjSKRDfNUF.dtHhNkdqjhiCGFdjTZiGIeVyhiqE(P_0))
			{
				return true;
			}
			num = -647109075;
		}
		goto IL_0017;
		IL_0017:
		switch (num ^ -647109076)
		{
		case 0:
			break;
		case 3:
			return false;
		case 2:
			if (P_0 > 0f)
			{
				return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.ZXIZggoPhfxrNYiuvgVjSKRDfNUF.dtHhNkdqjhiCGFdjTZiGIeVyhiqE(P_0);
			}
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vcGZsdBKQQjrFVJAxAPxCLxZYhX.doublePressHold;
		default:
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.MrRNpslzrHhMKDBYrYVaBQPElnc.dtHhNkdqjhiCGFdjTZiGIeVyhiqE(P_0);
		}
		goto IL_0012;
		IL_0012:
		num = -647109073;
		goto IL_0017;
	}

	public bool muCXbdCwQsGYDmNJFtnRwqLKQDq()
	{
		return muCXbdCwQsGYDmNJFtnRwqLKQDq(0f);
	}

	public bool muCXbdCwQsGYDmNJFtnRwqLKQDq(float P_0)
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		if (!zZfNFOMmkwRPDTjWQEBszXZnyS())
		{
			goto IL_0012;
		}
		int num;
		if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			if (!(P_0 > 0f))
			{
				return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vcGZsdBKQQjrFVJAxAPxCLxZYhX.doublePressUp;
			}
			num = -1587104176;
		}
		else
		{
			if (!(P_0 > 0f))
			{
				if (!NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vcGZsdBKQQjrFVJAxAPxCLxZYhX.doublePressUp)
				{
					return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.fzfIWLumSWkjZvFnvzqVKbLTatR.doublePressUp;
				}
				return true;
			}
			num = -1587104175;
		}
		goto IL_0017;
		IL_0012:
		num = -1587104173;
		goto IL_0017;
		IL_0017:
		switch (num ^ -1587104176)
		{
		case 2:
			break;
		case 3:
			return false;
		case 0:
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.ZXIZggoPhfxrNYiuvgVjSKRDfNUF.hgSrbdcpCAMBqxrIsXAVaoFTMBP(P_0);
		default:
			if (!NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.ZXIZggoPhfxrNYiuvgVjSKRDfNUF.hgSrbdcpCAMBqxrIsXAVaoFTMBP(P_0))
			{
				return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.MrRNpslzrHhMKDBYrYVaBQPElnc.hgSrbdcpCAMBqxrIsXAVaoFTMBP(P_0);
			}
			return true;
		}
		goto IL_0012;
	}

	public bool LIagbRzpgaHmaNasOBJuJLfEbEmS(float P_0)
	{
		return LIagbRzpgaHmaNasOBJuJLfEbEmS(P_0, 0f);
	}

	public bool LIagbRzpgaHmaNasOBJuJLfEbEmS(float P_0, float P_1)
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			goto IL_0008;
		}
		int num;
		if (P_0 < 0f)
		{
			P_0 = 0f;
			num = 649623160;
			goto IL_000d;
		}
		goto IL_0046;
		IL_00a3:
		float num2 = default(float);
		if (num2 >= P_0 + P_1)
		{
			return false;
		}
		goto IL_00ab;
		IL_008b:
		if (num2 < P_0)
		{
			return false;
		}
		if (P_1 > 0f)
		{
			num = 649623161;
			goto IL_000d;
		}
		goto IL_00ab;
		IL_0008:
		num = 649623164;
		goto IL_000d;
		IL_000d:
		switch (num ^ 0x26B87678)
		{
		case 3:
			break;
		case 4:
			return false;
		case 0:
			goto IL_0046;
		case 2:
			goto IL_008b;
		default:
			goto IL_00a3;
		}
		goto IL_0008;
		IL_0046:
		if (!OMsDoddGLoMsnAOixNusrDCoKsdq())
		{
			return false;
		}
		num2 = NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vButtonTimePressed;
		if (EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			num2 = MathTools.Max(num2, NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.negativeVButtonTimePressed);
			num = 649623162;
			goto IL_000d;
		}
		goto IL_008b;
		IL_00ab:
		return true;
	}

	public bool TmWmkgzOAdaTdHxVZjOYtSYjapHU(float P_0)
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		if (P_0 <= 0f)
		{
			return FDWmPtTmCBoydpMglKDYeZvgpzJ();
		}
		if (!OMsDoddGLoMsnAOixNusrDCoKsdq())
		{
			return false;
		}
		if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			ButtonStateRecorder zXIZggoPhfxrNYiuvgVjSKRDfNUF = NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.ZXIZggoPhfxrNYiuvgVjSKRDfNUF;
			if (zXIZggoPhfxrNYiuvgVjSKRDfNUF.timePressed < P_0)
			{
				return false;
			}
			if (!(ReInput.unscaledTimePrev - zXIZggoPhfxrNYiuvgVjSKRDfNUF.lastTimeUnpressed >= P_0))
			{
				return true;
			}
			goto IL_005a;
		}
		ButtonStateRecorder zXIZggoPhfxrNYiuvgVjSKRDfNUF2 = NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.ZXIZggoPhfxrNYiuvgVjSKRDfNUF;
		ButtonStateRecorder mrRNpslzrHhMKDBYrYVaBQPElnc = NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.MrRNpslzrHhMKDBYrYVaBQPElnc;
		int num;
		if (zXIZggoPhfxrNYiuvgVjSKRDfNUF2.timePressed < P_0)
		{
			num = 629251108;
			goto IL_005f;
		}
		goto IL_00c8;
		IL_005a:
		num = 629251104;
		goto IL_005f;
		IL_00f0:
		return false;
		IL_005f:
		while (true)
		{
			switch (num ^ 0x25819C24)
			{
			case 3:
				break;
			case 4:
				return false;
			case 0:
				goto IL_00b6;
			case 2:
				return false;
			default:
				goto IL_00f0;
			}
			break;
			IL_00b6:
			if (mrRNpslzrHhMKDBYrYVaBQPElnc.timePressed < P_0)
			{
				num = 629251110;
				continue;
			}
			goto IL_00c8;
		}
		goto IL_005a;
		IL_00c8:
		if (!(ReInput.unscaledTimePrev - zXIZggoPhfxrNYiuvgVjSKRDfNUF2.lastTimeUnpressed >= P_0))
		{
			if (ReInput.unscaledTimePrev - mrRNpslzrHhMKDBYrYVaBQPElnc.lastTimeUnpressed >= P_0)
			{
				num = 629251109;
				goto IL_005f;
			}
			return true;
		}
		goto IL_00f0;
	}

	public bool SnZcquUjSouueUwNdDjJzfjnhdte(float P_0)
	{
		return SnZcquUjSouueUwNdDjJzfjnhdte(P_0, 0f);
	}

	public bool SnZcquUjSouueUwNdDjJzfjnhdte(float P_0, float P_1)
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			goto IL_0008;
		}
		int num;
		if (P_0 < 0f)
		{
			P_0 = 0f;
			num = 1060908464;
			goto IL_000d;
		}
		goto IL_004d;
		IL_004d:
		if (!zZfNFOMmkwRPDTjWQEBszXZnyS())
		{
			return false;
		}
		float num2 = default(float);
		if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			num = 1060908467;
		}
		else
		{
			num2 = ReInput.unscaledTime - MathTools.Max(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.ZXIZggoPhfxrNYiuvgVjSKRDfNUF.lastTimeStateChangedToPressed, NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.MrRNpslzrHhMKDBYrYVaBQPElnc.lastTimeStateChangedToPressed);
			num = 1060908466;
		}
		goto IL_000d;
		IL_0082:
		float num3 = ReInput.unscaledTime - NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.ZXIZggoPhfxrNYiuvgVjSKRDfNUF.lastTimeStateChangedToPressed;
		if (num3 < P_0)
		{
			return false;
		}
		if (P_1 > 0f && num3 >= P_0 + P_1)
		{
			return false;
		}
		return true;
		IL_0008:
		num = 1060908465;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x3F3C2DB2)
			{
			case 5:
				break;
			case 3:
				return false;
			case 2:
				goto IL_004d;
			case 0:
				goto IL_006a;
			case 1:
				goto IL_0082;
			default:
				goto IL_00f6;
			}
			break;
			IL_00f6:
			if (num2 >= P_0 + P_1)
			{
				return false;
			}
			goto IL_00fe;
			IL_00fe:
			return true;
			IL_006a:
			if (num2 < P_0)
			{
				return false;
			}
			if (P_1 > 0f)
			{
				num = 1060908470;
				continue;
			}
			goto IL_00fe;
		}
		goto IL_0008;
	}

	public bool MEkWNPeIovcPibcOIDriEloGWCek()
	{
		return LIagbRzpgaHmaNasOBJuJLfEbEmS(uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonShortPressTime, uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonShortPressExpiresIn);
	}

	public bool JFwxaZRBlqWpKNDcitBhgiyflkm()
	{
		return TmWmkgzOAdaTdHxVZjOYtSYjapHU(uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonShortPressTime);
	}

	public bool hXCuaxWdNcueYQiGLdDrJSdNZAIM()
	{
		return SnZcquUjSouueUwNdDjJzfjnhdte(uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonShortPressTime, uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonShortPressExpiresIn);
	}

	public bool EWlxTOVmbBtSlquMQaYQrQofJeT()
	{
		return LIagbRzpgaHmaNasOBJuJLfEbEmS(uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonLongPressTime, uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonLongPressExpiresIn);
	}

	public bool FklPSljcUaxKydxZYdiDkSYZolB()
	{
		return TmWmkgzOAdaTdHxVZjOYtSYjapHU(uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonLongPressTime);
	}

	public bool HvqSyQJyWgHfIBWSkTRNTFVuOsy()
	{
		return SnZcquUjSouueUwNdDjJzfjnhdte(uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonLongPressTime, uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonLongPressExpiresIn);
	}

	public bool qPoCvloGegNyKIgEIqqJKorfkQQ()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			goto IL_0008;
		}
		int num;
		if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			num = 885320519;
			goto IL_000d;
		}
		if (!NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.rLiMLCuZccmsmDKilFHtCCAWnETd.state)
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.pyBulQuhXpLYIdJpTdztorAvXQI.state;
		}
		return true;
		IL_000d:
		switch (num ^ 0x34C4EB46)
		{
		case 0:
			break;
		case 2:
			return false;
		default:
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.rLiMLCuZccmsmDKilFHtCCAWnETd.state;
		}
		goto IL_0008;
		IL_0008:
		num = 885320516;
		goto IL_000d;
	}

	public bool AAdwUYLeaIBDydaNOceNayNTDMI()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			return (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.zNUqKrxRILnDaRRkBaOldTffVIvu & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) != 0;
		}
		if ((NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.zNUqKrxRILnDaRRkBaOldTffVIvu & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) == 0)
		{
			return gzqiXpQjOddOoitBcBObUOtREys();
		}
		return true;
	}

	public float jnrghDiZPgbmyiBvsKLDzacNTQXV()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return 0f;
		}
		if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vButtonTimePressed;
		}
		return MathTools.Max(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vButtonTimePressed, NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.negativeVButtonTimePressed);
	}

	public float JEsKHudJBvOeefFUHbwCaBYpWQc()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			GoYJimAYxwnmYPxHNmLUKooIsMq();
		}
		if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vButtonTimeUnpressed;
		}
		return MathTools.Min(NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.vButtonTimeUnpressed, NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.negativeVButtonTimeUnpressed);
	}

	private bool FDWmPtTmCBoydpMglKDYeZvgpzJ()
	{
		if (!EVFWZcZYsJTyVuPgkpnexuXAMzA.activateActionButtonsOnNegativeValue)
		{
			return (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OileThpvkAvMNYbGPcNUiZbAZKu & ButtonStateFlags.avtVkgWiQfRjAMVrjPmvYWatNrY) != 0;
		}
		if ((NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OileThpvkAvMNYbGPcNUiZbAZKu & ButtonStateFlags.avtVkgWiQfRjAMVrjPmvYWatNrY) == 0)
		{
			goto IL_0039;
		}
		goto IL_006d;
		IL_006d:
		int num;
		if ((NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OileThpvkAvMNYbGPcNUiZbAZKu & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) != ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr && (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.OileThpvkAvMNYbGPcNUiZbAZKu & ButtonStateFlags.avtVkgWiQfRjAMVrjPmvYWatNrY) == 0)
		{
			num = -300291820;
			goto IL_003e;
		}
		if ((NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.uVmAVvVvxJKaGooIdMLxEhzhVTg & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) != ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr && (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.uVmAVvVvxJKaGooIdMLxEhzhVTg & ButtonStateFlags.avtVkgWiQfRjAMVrjPmvYWatNrY) == 0)
		{
			return false;
		}
		return true;
		IL_0039:
		num = -300291817;
		goto IL_003e;
		IL_003e:
		switch (num ^ -300291819)
		{
		case 0:
			break;
		case 2:
			goto IL_0057;
		default:
			return false;
		}
		goto IL_0039;
		IL_0057:
		if ((NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.uVmAVvVvxJKaGooIdMLxEhzhVTg & ButtonStateFlags.avtVkgWiQfRjAMVrjPmvYWatNrY) == 0)
		{
			return false;
		}
		goto IL_006d;
	}

	public bool nkChpEwCeyIAcExUuFGdJLElwIA()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		return (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.uVmAVvVvxJKaGooIdMLxEhzhVTg & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) != 0;
	}

	public bool npsYQCyKleLimEhZDAdnaxnwlFNO()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			goto IL_0008;
		}
		int num;
		if (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.qLWvyJPDjNEPcAoYLwGLbbPWbLy == null)
		{
			num = -1720027749;
			goto IL_000d;
		}
		if (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.qLWvyJPDjNEPcAoYLwGLbbPWbLy.running)
		{
			return true;
		}
		return false;
		IL_000d:
		switch (num ^ -1720027749)
		{
		case 2:
			break;
		case 1:
			return false;
		default:
			return WtazeRrShpTFFLJCbcgFEqLnkKJe();
		}
		goto IL_0008;
		IL_0008:
		num = -1720027750;
		goto IL_000d;
	}

	public bool sqLJephBcMrzUHldDlcYpoVsgfQC()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		return (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.uVmAVvVvxJKaGooIdMLxEhzhVTg & ButtonStateFlags.VlhlJSuMVXjhWdLiRItrzCZLEub) != 0;
	}

	public bool ngPfxaJknmSuXcFPylUatEwGRfE()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.fzfIWLumSWkjZvFnvzqVKbLTatR.singlePressHold;
	}

	public bool kLYaolUGcRNJqlKSEZFkBHCVEHX()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.fzfIWLumSWkjZvFnvzqVKbLTatR.singlePressDown;
	}

	public bool KTpXYTuqpfgzcuQcdAthQbBmJOK()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.fzfIWLumSWkjZvFnvzqVKbLTatR.singlePressUp;
	}

	public bool fdzmsdIYwqztXcolheWsrQJMyv()
	{
		return fdzmsdIYwqztXcolheWsrQJMyv(0f);
	}

	public bool fdzmsdIYwqztXcolheWsrQJMyv(float P_0)
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.MrRNpslzrHhMKDBYrYVaBQPElnc.dtHhNkdqjhiCGFdjTZiGIeVyhiqE(P_0);
		}
		return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.fzfIWLumSWkjZvFnvzqVKbLTatR.doublePressHold;
	}

	public bool dOAGKPSipdZlaAbbEokZoDIHHLC()
	{
		return dOAGKPSipdZlaAbbEokZoDIHHLC(0f);
	}

	public bool dOAGKPSipdZlaAbbEokZoDIHHLC(float P_0)
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			goto IL_0008;
		}
		int num;
		if (!npsYQCyKleLimEhZDAdnaxnwlFNO())
		{
			num = 1354070818;
		}
		else
		{
			if (!(P_0 > 0f))
			{
				return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.fzfIWLumSWkjZvFnvzqVKbLTatR.doublePressHold;
			}
			num = 1354070819;
		}
		goto IL_000d;
		IL_000d:
		switch (num ^ 0x50B57B20)
		{
		case 0:
			break;
		case 1:
			return false;
		case 2:
			return false;
		default:
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.MrRNpslzrHhMKDBYrYVaBQPElnc.dtHhNkdqjhiCGFdjTZiGIeVyhiqE(P_0);
		}
		goto IL_0008;
		IL_0008:
		num = 1354070817;
		goto IL_000d;
	}

	public bool XdNeOHquIhupqYJaJiORbbtHbhq()
	{
		return XdNeOHquIhupqYJaJiORbbtHbhq(0f);
	}

	public bool XdNeOHquIhupqYJaJiORbbtHbhq(float P_0)
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		if (!sqLJephBcMrzUHldDlcYpoVsgfQC())
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.MrRNpslzrHhMKDBYrYVaBQPElnc.hgSrbdcpCAMBqxrIsXAVaoFTMBP(P_0);
		}
		return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.fzfIWLumSWkjZvFnvzqVKbLTatR.doublePressUp;
	}

	public bool WMiTTwIKzyDqbfPtkXAZnODLxCJw(float P_0)
	{
		return WMiTTwIKzyDqbfPtkXAZnODLxCJw(P_0, 0f);
	}

	public bool WMiTTwIKzyDqbfPtkXAZnODLxCJw(float P_0, float P_1)
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			goto IL_0008;
		}
		int num;
		if (P_0 < 0f)
		{
			P_0 = 0f;
			num = -1054301494;
			goto IL_000d;
		}
		goto IL_0042;
		IL_0042:
		if (!nkChpEwCeyIAcExUuFGdJLElwIA())
		{
			return false;
		}
		float negativeVButtonTimePressed = NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.negativeVButtonTimePressed;
		if (negativeVButtonTimePressed < P_0)
		{
			return false;
		}
		if (P_1 > 0f)
		{
			num = -1054301496;
			goto IL_000d;
		}
		goto IL_007a;
		IL_0072:
		if (negativeVButtonTimePressed >= P_0 + P_1)
		{
			return false;
		}
		goto IL_007a;
		IL_0008:
		num = -1054301495;
		goto IL_000d;
		IL_000d:
		switch (num ^ -1054301496)
		{
		case 3:
			break;
		case 1:
			return false;
		case 2:
			goto IL_0042;
		default:
			goto IL_0072;
		}
		goto IL_0008;
		IL_007a:
		return true;
	}

	public bool zFcbFfEbtqAVMVOymyDrayobmQYK(float P_0)
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		if (P_0 <= 0f)
		{
			return WtazeRrShpTFFLJCbcgFEqLnkKJe();
		}
		if (!nkChpEwCeyIAcExUuFGdJLElwIA())
		{
			return false;
		}
		ButtonStateRecorder mrRNpslzrHhMKDBYrYVaBQPElnc = NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.MrRNpslzrHhMKDBYrYVaBQPElnc;
		if (mrRNpslzrHhMKDBYrYVaBQPElnc.timePressed < P_0)
		{
			return false;
		}
		if (ReInput.unscaledTimePrev - mrRNpslzrHhMKDBYrYVaBQPElnc.lastTimeUnpressed >= P_0)
		{
			return false;
		}
		return true;
	}

	public bool uEyIDtIDaHApazSzDPxtOwMsWvuF(float P_0)
	{
		return uEyIDtIDaHApazSzDPxtOwMsWvuF(P_0, 0f);
	}

	public bool uEyIDtIDaHApazSzDPxtOwMsWvuF(float P_0, float P_1)
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
			goto IL_0019;
		}
		goto IL_003b;
		IL_0085:
		return true;
		IL_007d:
		float num = default(float);
		if (num >= P_0 + P_1)
		{
			return false;
		}
		goto IL_0085;
		IL_0019:
		int num2 = -836804434;
		goto IL_001e;
		IL_001e:
		switch (num2 ^ -836804433)
		{
		case 3:
			break;
		case 1:
			goto IL_003b;
		case 0:
			return false;
		default:
			goto IL_007d;
		}
		goto IL_0019;
		IL_003b:
		if (!sqLJephBcMrzUHldDlcYpoVsgfQC())
		{
			num2 = -836804433;
		}
		else
		{
			num = ReInput.unscaledTime - NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.MrRNpslzrHhMKDBYrYVaBQPElnc.lastTimeStateChangedToPressed;
			if (num < P_0)
			{
				return false;
			}
			if (!(P_1 > 0f))
			{
				goto IL_0085;
			}
			num2 = -836804435;
		}
		goto IL_001e;
	}

	public bool miFsbiglmYCEIAQeXkMbXRqjCtSb()
	{
		return WMiTTwIKzyDqbfPtkXAZnODLxCJw(uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonShortPressTime, uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonShortPressExpiresIn);
	}

	public bool JKHpwqnigmDeLJUNtVsqeZifnYu()
	{
		return zFcbFfEbtqAVMVOymyDrayobmQYK(uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonShortPressTime);
	}

	public bool IcsRdTqDrEgjriRMBoSRZQDqaiFs()
	{
		return uEyIDtIDaHApazSzDPxtOwMsWvuF(uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonShortPressTime, uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonShortPressExpiresIn);
	}

	public bool RLljstHsoOvZfhmQakvzwAXfDac()
	{
		return WMiTTwIKzyDqbfPtkXAZnODLxCJw(uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonLongPressTime, uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonLongPressExpiresIn);
	}

	public bool SjLycOTsrePJjJUvBGJNSZOVUxa()
	{
		return zFcbFfEbtqAVMVOymyDrayobmQYK(uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonLongPressTime);
	}

	public bool KICXvNWuNoIHXBEvQauvdVBOXPcS()
	{
		return uEyIDtIDaHApazSzDPxtOwMsWvuF(uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonLongPressTime, uhxBgBGBFGVnUELmixUqJqpnwoOn.buttonLongPressExpiresIn);
	}

	public bool eTqXvIgOuFMZVnfBflDIiPcAHfM()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.pyBulQuhXpLYIdJpTdztorAvXQI.state;
	}

	public bool gzqiXpQjOddOoitBcBObUOtREys()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return false;
		}
		return (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.nhcDjmnqWihtAORPiAzSPdiPTE & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) != 0;
	}

	public float SNpTuqvaAdXSNapYjhpWziGUhCc()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			return 0f;
		}
		return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.negativeVButtonTimePressed;
	}

	public float SdYdndgjwYvDZnPLsdBngufGdHlP()
	{
		if (!BdgIlNfBSgMruspNkDePcrIffUrj)
		{
			GoYJimAYxwnmYPxHNmLUKooIsMq();
		}
		return NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.negativeVButtonTimeUnpressed;
	}

	private bool WtazeRrShpTFFLJCbcgFEqLnkKJe()
	{
		return (NEroqLjuwCtLFvVbPBNzgAFFsqi.CLjmYleEuCraJMMUJEFwtuAaGlg.uVmAVvVvxJKaGooIdMLxEhzhVTg & ButtonStateFlags.avtVkgWiQfRjAMVrjPmvYWatNrY) != 0;
	}

	public void YxnUHgeltWQEYhQywWHXgnCpYKX()
	{
		int num = 0;
		while (true)
		{
			int num2 = -1060235826;
			while (true)
			{
				switch (num2 ^ -1060235825)
				{
				case 3:
					break;
				case 1:
					num2 = -1060235827;
					continue;
				case 0:
					NEroqLjuwCtLFvVbPBNzgAFFsqi.FRUUibiOIWEsSCBxDuohaLtzlQrt[num].ZTthsIyWvwsmOqgEynZhYUqgpGC.Clear();
					NEroqLjuwCtLFvVbPBNzgAFFsqi.FRUUibiOIWEsSCBxDuohaLtzlQrt[num].qLWvyJPDjNEPcAoYLwGLbbPWbLy.Clear();
					num++;
					num2 = -1060235827;
					continue;
				default:
					if (num >= NEroqLjuwCtLFvVbPBNzgAFFsqi.FRUUibiOIWEsSCBxDuohaLtzlQrt.Length)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	internal InputActionEventData wwJCfwGwbvLLmUoumKXGXpMmmxQt(UpdateLoopType P_0)
	{
		return new InputActionEventData(this, VUcYiZtcJRatratRXOokIFfcdNSg, ZUoDkTcclUigIzTjeFLCXFMQOaU, P_0);
	}

	public IList<InputActionSourceData> ltyejBmKjAhszqAMwxRwOxaYHbi()
	{
		if (!MNuWEVVEgRHtaaFYNrfCpurhHyl)
		{
			KJqfacjrdEssKMCBtorPHaclNr();
		}
		return KumiKCmhvIWVLkQbhLSyNRFhBOa;
	}

	public bool DeJlmiFsOPqKkRgDxwnGrhHZjAk(ControllerType P_0)
	{
		if (!MNuWEVVEgRHtaaFYNrfCpurhHyl)
		{
			ltyejBmKjAhszqAMwxRwOxaYHbi();
			goto IL_000f;
		}
		goto IL_005e;
		IL_005e:
		int num = 0;
		int num2 = -1479752629;
		goto IL_0014;
		IL_000f:
		num2 = -1479752628;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num2 ^ -1479752625)
			{
			case 2:
				break;
			case 1:
				return true;
			case 0:
				goto IL_0042;
			case 3:
				goto IL_005e;
			default:
				if (num >= fQyUQNcXKqrsGCvieMaYYqAsfyl)
				{
					return false;
				}
				goto IL_0042;
			}
			break;
			IL_0042:
			if (WiTeWcinjumRjMqwqSJbtzjwQPY[num].EnKkaiEMISMHdBHJLGCBcerSsFgw.type != P_0)
			{
				num++;
				num2 = -1479752629;
			}
			else
			{
				num2 = -1479752626;
			}
		}
		goto IL_000f;
	}

	public bool DeJlmiFsOPqKkRgDxwnGrhHZjAk(ControllerType P_0, int P_1)
	{
		if (!MNuWEVVEgRHtaaFYNrfCpurhHyl)
		{
			goto IL_0008;
		}
		goto IL_005e;
		IL_0008:
		int num = 2032329470;
		goto IL_000d;
		IL_000d:
		int num2 = default(int);
		Controller enKkaiEMISMHdBHJLGCBcerSsFgw = default(Controller);
		while (true)
		{
			switch (num ^ 0x7922E2FA)
			{
			case 0:
				break;
			case 4:
				ltyejBmKjAhszqAMwxRwOxaYHbi();
				num = 2032329467;
				continue;
			case 3:
				goto IL_0040;
			case 1:
				goto IL_005e;
			case 5:
				goto IL_0067;
			default:
				if (num2 >= fQyUQNcXKqrsGCvieMaYYqAsfyl)
				{
					return false;
				}
				goto IL_0040;
			}
			break;
			IL_0067:
			if (enKkaiEMISMHdBHJLGCBcerSsFgw.id == P_1)
			{
				return true;
			}
			goto IL_0072;
			IL_0072:
			num2++;
			num = 2032329464;
			continue;
			IL_0040:
			enKkaiEMISMHdBHJLGCBcerSsFgw = WiTeWcinjumRjMqwqSJbtzjwQPY[num2].EnKkaiEMISMHdBHJLGCBcerSsFgw;
			if (enKkaiEMISMHdBHJLGCBcerSsFgw.type == P_0)
			{
				num = 2032329471;
				continue;
			}
			goto IL_0072;
		}
		goto IL_0008;
		IL_005e:
		num2 = 0;
		num = 2032329464;
		goto IL_000d;
	}

	public bool DeJlmiFsOPqKkRgDxwnGrhHZjAk(Controller P_0)
	{
		if (!MNuWEVVEgRHtaaFYNrfCpurhHyl)
		{
			ltyejBmKjAhszqAMwxRwOxaYHbi();
			goto IL_000f;
		}
		goto IL_0031;
		IL_0031:
		int num = 0;
		int num2 = -3435987;
		goto IL_0014;
		IL_000f:
		num2 = -3435985;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num2 ^ -3435987)
			{
			case 3:
				break;
			case 2:
				goto IL_0031;
			case 1:
				goto IL_003a;
			default:
				if (num >= fQyUQNcXKqrsGCvieMaYYqAsfyl)
				{
					return false;
				}
				goto IL_003a;
			}
			break;
			IL_003a:
			if (WiTeWcinjumRjMqwqSJbtzjwQPY[num].EnKkaiEMISMHdBHJLGCBcerSsFgw == P_0)
			{
				return true;
			}
			num++;
			num2 = -3435987;
		}
		goto IL_000f;
	}

	internal void xaGVjRxEvIdELjjBskoGFDUNmrm()
	{
		NEroqLjuwCtLFvVbPBNzgAFFsqi.xaGVjRxEvIdELjjBskoGFDUNmrm();
	}

	private void yWHggWFuqgoCMTrtaQzkhrVzckEV()
	{
		if (HEnvbKyoHEyMDrLlACrBHhedaXe == yRVJEGLVcDQyieRzpOtUzcxwGkL.ZPykDFRKjlWyOusQpaYNPYZXBgE)
		{
			while (true)
			{
				int num = -43504696;
				while (true)
				{
					switch (num ^ -43504695)
					{
					case 0:
						break;
					case 1:
						mMXnhPMMMxphLALbWPoFkWTCBQS = true;
						num = -43504693;
						continue;
					default:
						goto end_IL_0009;
					}
					break;
				}
				continue;
				end_IL_0009:
				break;
			}
		}
		cfbLtZVfchvCddmhvLrshzbsxkD = yRVJEGLVcDQyieRzpOtUzcxwGkL.mcLvHSMYsjDYZNVSkRNAjBJWDNI;
		BdgIlNfBSgMruspNkDePcrIffUrj = true;
	}

	private void pnbrdZwKvfGuMdGIxtXIcSwuZSA(bool P_0)
	{
		NEroqLjuwCtLFvVbPBNzgAFFsqi.pnbrdZwKvfGuMdGIxtXIcSwuZSA();
		if (fQyUQNcXKqrsGCvieMaYYqAsfyl > 0)
		{
			lsmaodSODmykHbSmhcSxLxCQDmD();
			goto IL_001a;
		}
		goto IL_0038;
		IL_0038:
		cfbLtZVfchvCddmhvLrshzbsxkD = (P_0 ? yRVJEGLVcDQyieRzpOtUzcxwGkL.AKrlzAhTDjmUJonCJxVBSdhjiKH : yRVJEGLVcDQyieRzpOtUzcxwGkL.ZPykDFRKjlWyOusQpaYNPYZXBgE);
		int num = -1246199667;
		goto IL_001f;
		IL_001a:
		num = -1246199668;
		goto IL_001f;
		IL_001f:
		switch (num ^ -1246199667)
		{
		case 2:
			break;
		case 1:
			goto IL_0038;
		default:
			BdgIlNfBSgMruspNkDePcrIffUrj = false;
			return;
		}
		goto IL_001a;
	}

	private void GoYJimAYxwnmYPxHNmLUKooIsMq()
	{
		NEroqLjuwCtLFvVbPBNzgAFFsqi.updateLoop = ccchNwVcItfPOfcqSbtVmUSmBvb;
	}

	private void lsmaodSODmykHbSmhcSxLxCQDmD()
	{
		fQyUQNcXKqrsGCvieMaYYqAsfyl = 0;
		if (MNuWEVVEgRHtaaFYNrfCpurhHyl)
		{
			zWmdyKSNbVeFGdIiFAXnWCXlFxRA.Clear();
		}
	}

	private void kvdlrvWSNbhDlFVfOcpmgDtILax(Controller P_0, ControllerMap P_1, ActionElementMap P_2)
	{
		if (fQyUQNcXKqrsGCvieMaYYqAsfyl + 1 > WiTeWcinjumRjMqwqSJbtzjwQPY.Length)
		{
			vYtQTnsQcpSAyknQqEmuFdCTpyZC();
			goto IL_0018;
		}
		goto IL_0036;
		IL_0036:
		UChyDAIORuXqDhvbfagyRDSNGSiJ uChyDAIORuXqDhvbfagyRDSNGSiJ = WiTeWcinjumRjMqwqSJbtzjwQPY[fQyUQNcXKqrsGCvieMaYYqAsfyl];
		uChyDAIORuXqDhvbfagyRDSNGSiJ.YORsZWHKqfvSwofazZpoPgrtBHAK = true;
		int num = 370659358;
		goto IL_001d;
		IL_0018:
		num = 370659357;
		goto IL_001d;
		IL_001d:
		switch (num ^ 0x1617D01F)
		{
		case 0:
			break;
		case 2:
			goto IL_0036;
		default:
			uChyDAIORuXqDhvbfagyRDSNGSiJ.EnKkaiEMISMHdBHJLGCBcerSsFgw = P_0;
			uChyDAIORuXqDhvbfagyRDSNGSiJ.eRtoQSFdzNGKcVeofCcwFdixCwlq = P_1;
			uChyDAIORuXqDhvbfagyRDSNGSiJ.MzATACNcsUpFsuEcdOAkGvOQVeI = P_2;
			fQyUQNcXKqrsGCvieMaYYqAsfyl++;
			return;
		}
		goto IL_0018;
	}

	private void vYtQTnsQcpSAyknQqEmuFdCTpyZC()
	{
		ArrayTools.Expand(ref WiTeWcinjumRjMqwqSJbtzjwQPY, 4);
		int num3 = default(int);
		int num2 = default(int);
		while (true)
		{
			int num = -863100138;
			while (true)
			{
				switch (num ^ -863100139)
				{
				case 0:
					break;
				case 3:
					num3 = fQyUQNcXKqrsGCvieMaYYqAsfyl + 4;
					num2 = fQyUQNcXKqrsGCvieMaYYqAsfyl;
					num = -863100137;
					continue;
				case 1:
					WiTeWcinjumRjMqwqSJbtzjwQPY[num2] = new UChyDAIORuXqDhvbfagyRDSNGSiJ();
					num2++;
					num = -863100137;
					continue;
				default:
					if (num2 >= num3)
					{
						return;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	private void KJqfacjrdEssKMCBtorPHaclNr()
	{
		if (!MNuWEVVEgRHtaaFYNrfCpurhHyl)
		{
			MNuWEVVEgRHtaaFYNrfCpurhHyl = true;
			goto IL_000f;
		}
		goto IL_005f;
		IL_005f:
		int num = 0;
		int num2 = 57215725;
		goto IL_0014;
		IL_000f:
		num2 = 57215724;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num2 ^ 0x3690AEF)
			{
			case 0:
				break;
			case 4:
				num++;
				num2 = 57215725;
				continue;
			case 1:
				zWmdyKSNbVeFGdIiFAXnWCXlFxRA.Add(new InputActionSourceData(WiTeWcinjumRjMqwqSJbtzjwQPY[num]));
				num2 = 57215723;
				continue;
			case 3:
				goto IL_005f;
			default:
				if (num >= fQyUQNcXKqrsGCvieMaYYqAsfyl)
				{
					return;
				}
				goto case 1;
			}
			break;
		}
		goto IL_000f;
	}

	private static void twUqTGxynTqdqWgYtoilShqzypY(ref ButtonStateFlags P_0, ButtonStateFlags P_1)
	{
		if (P_0 == ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr)
		{
			goto IL_0004;
		}
		goto IL_0052;
		IL_0004:
		int num = 1436859866;
		goto IL_0009;
		IL_0009:
		while (true)
		{
			switch (num ^ 0x55A4BDDB)
			{
			case 0:
				break;
			default:
				return;
			case 4:
				P_0 = ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy;
				num = 1436859864;
				continue;
			case 5:
				goto IL_003c;
			case 2:
				goto IL_0052;
			case 6:
				goto IL_006b;
			case 1:
				P_0 = P_1;
				return;
			case 3:
				return;
			}
			break;
		}
		goto IL_0004;
		IL_006b:
		P_0 = ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy | ButtonStateFlags.avtVkgWiQfRjAMVrjPmvYWatNrY;
		return;
		IL_0052:
		if ((P_1 & ButtonStateFlags.avtVkgWiQfRjAMVrjPmvYWatNrY) == 0)
		{
			goto IL_003c;
		}
		if ((P_0 & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) != ButtonStateFlags.KkYHvIgKzOGVlCiSkUmwNYNguCtr && (P_0 & ButtonStateFlags.avtVkgWiQfRjAMVrjPmvYWatNrY) == 0)
		{
			return;
		}
		goto IL_006b;
		IL_003c:
		int num2;
		if ((P_1 & ButtonStateFlags.LnGgshauIRruwnXutHKRlBuLqIy) == 0)
		{
			num = 1436859864;
			num2 = num;
		}
		else
		{
			num = 1436859871;
			num2 = num;
		}
		goto IL_0009;
	}
}
