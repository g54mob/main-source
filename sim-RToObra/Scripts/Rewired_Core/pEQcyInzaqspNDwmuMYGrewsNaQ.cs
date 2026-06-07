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

internal sealed class pEQcyInzaqspNDwmuMYGrewsNaQ
{
	internal enum bdaJzDHyzUjPDoLNWgKikXyIWEb
	{
		DmJaGFbqcvRxiLlVWnXGTCZKbEXN = 0,
		lAbGsNJnXfmjcYkPrdpDpsjnFLS = 1,
		oUspIGvJppSFjIPHXDCBiuVNAUZ = 2
	}

	private class SKECkQutNYMIhCJMbhLUCEtvhao
	{
		internal class JsBUqOgSQSNQZKdIsFDoguUzDqX
		{
			internal float AOwPMLrvfPKRDAJWfBqtARkesJy;

			private InputBehavior HihxpSdwPYsIjhCvMYCwBkdxadJ;

			internal float UNgIpSIDpIOcEEPZAipQgwXwOQn;

			internal float rrjAzCaNkwtEgTDoRtGrPyDdaSc;

			internal AxisCoordinateMode dsWWLfdILyJiugOyNuBltGXmmpi;

			internal AxisCoordinateMode ghXMdoMIYNCWktzQaJBXsbIIlaq;

			internal ButtonStateFlags zanoUePzyYulugqVhTLKoWlInDx;

			internal ButtonStateFlags CVSgRsXNUHlgVjnztwMxuTjlNwo;

			internal ButtonStateFlags JcUFwdVnLFzpOkfTmSpdvzlHOz;

			internal ButtonStateFlags EAzdfySBcYVdKgYEfqVxvdbeOHF;

			internal float KdErjvyFToFoJbJAowlBiYFsfgPc;

			internal float WPfrrEiRlQPOOXpqEdazwJczvfx;

			internal float oNOdvUURePKwNGoKnQAvXqJcGIfi;

			internal float pTVDRnjYcnQDMNrNAzMmgSXHbaUH;

			private float xBFHBukMfoJfcEzzcOryBoGqFtEl;

			private float ICLEJkAWqklVxqIOfOvzTjZEoRDL;

			internal tjVSzgCpYulTxiHPuJpvoyKcuuZ UDOjpgxxSIgKavxNRARjjzzZwoU;

			internal tjVSzgCpYulTxiHPuJpvoyKcuuZ ADfBLWQhSGxJqRogJFrBkbJTJcGS;

			internal ButtonStateRecorder kHSCpxEyvnCtiwtxVXpzlQVDWHT;

			internal ButtonStateRecorder hiJKtdXofZGPfjANHYQicuREwaj;

			internal uUrXqmpMwYhIOZLxgrbuIRkUIrQ WWifMHMFueYRJbVhHxFvlYMKHDC;

			internal uUrXqmpMwYhIOZLxgrbuIRkUIrQ YcBlJeAfzxoZjTMQfjitNvDnGIN;

			internal TimerAbs kFnuVrKAVqTfbKliMfIvrIjmigT;

			internal TimerAbs NnEeVItInZbdRyUNnBsJMoBUXcf;

			internal readonly relHYLHuZaHJcMNiFYaqgcWRfBnm pvTxooprdRDCMXRPzWBtuHmktwn = new relHYLHuZaHJcMNiFYaqgcWRfBnm();

			internal float vButtonTimePressed
			{
				get
				{
					return kHSCpxEyvnCtiwtxVXpzlQVDWHT.timePressed;
				}
			}

			internal float vButtonTimeUnpressed
			{
				get
				{
					return kHSCpxEyvnCtiwtxVXpzlQVDWHT.timeUnpressed;
				}
			}

			internal float negativeVButtonTimePressed
			{
				get
				{
					return hiJKtdXofZGPfjANHYQicuREwaj.timePressed;
				}
			}

			internal float negativeVButtonTimeUnpressed
			{
				get
				{
					return hiJKtdXofZGPfjANHYQicuREwaj.timeUnpressed;
				}
			}

			internal float vAxisTimeActive
			{
				get
				{
					if (UNgIpSIDpIOcEEPZAipQgwXwOQn == 0f)
					{
						goto IL_000d;
					}
					goto IL_006c;
					IL_000d:
					int num = 971236342;
					goto IL_0012;
					IL_0012:
					float num2 = default(float);
					while (true)
					{
						switch (num ^ 0x39E3E3F7)
						{
						case 2:
							break;
						case 0:
							num2 = 0f;
							num = 971236339;
							continue;
						case 3:
							goto IL_0040;
						case 1:
							goto IL_0059;
						default:
							return num2;
						}
						break;
						IL_0040:
						int num3;
						if (num2 < 0f)
						{
							num = 971236343;
							num3 = num;
						}
						else
						{
							num = 971236339;
							num3 = num;
						}
					}
					goto IL_000d;
					IL_006c:
					num2 = unwgQSnePmeOsXbHPocojQIZGLM - xBFHBukMfoJfcEzzcOryBoGqFtEl;
					num = 971236340;
					goto IL_0012;
					IL_0059:
					if (KdErjvyFToFoJbJAowlBiYFsfgPc == 0f)
					{
						return 0f;
					}
					goto IL_006c;
				}
			}

			internal float vAxisTimeInactive
			{
				get
				{
					float num = default(float);
					int num2;
					if (UNgIpSIDpIOcEEPZAipQgwXwOQn == 0f)
					{
						if (KdErjvyFToFoJbJAowlBiYFsfgPc != 0f)
						{
							goto IL_001a;
						}
						num = unwgQSnePmeOsXbHPocojQIZGLM - xBFHBukMfoJfcEzzcOryBoGqFtEl;
						int num3;
						if (num >= 0f)
						{
							num2 = -362930259;
							num3 = num2;
						}
						else
						{
							num2 = -362930260;
							num3 = num2;
						}
						goto IL_001f;
					}
					goto IL_003c;
					IL_001f:
					while (true)
					{
						switch (num2 ^ -362930258)
						{
						case 0:
							break;
						case 1:
							goto IL_003c;
						case 2:
							num = 0f;
							num2 = -362930259;
							continue;
						default:
							return num;
						}
						break;
					}
					goto IL_001a;
					IL_001a:
					num2 = -362930257;
					goto IL_001f;
					IL_003c:
					return 0f;
				}
			}

			internal float vAxisRawTimeActive
			{
				get
				{
					if (UNgIpSIDpIOcEEPZAipQgwXwOQn == 0f && oNOdvUURePKwNGoKnQAvXqJcGIfi == 0f)
					{
						return 0f;
					}
					float num = unwgQSnePmeOsXbHPocojQIZGLM - ICLEJkAWqklVxqIOfOvzTjZEoRDL;
					if (num < 0f)
					{
						num = 0f;
					}
					return num;
				}
			}

			internal float vAxisRawTimeInactive
			{
				get
				{
					float num = default(float);
					int num2;
					if (UNgIpSIDpIOcEEPZAipQgwXwOQn == 0f)
					{
						if (oNOdvUURePKwNGoKnQAvXqJcGIfi != 0f)
						{
							goto IL_001a;
						}
						num = unwgQSnePmeOsXbHPocojQIZGLM - ICLEJkAWqklVxqIOfOvzTjZEoRDL;
						num2 = -1454061724;
						goto IL_001f;
					}
					goto IL_003c;
					IL_001f:
					while (true)
					{
						switch (num2 ^ -1454061723)
						{
						case 0:
							break;
						case 3:
							goto IL_003c;
						case 1:
							if (num < 0f)
							{
								num = 0f;
								num2 = -1454061721;
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
					num2 = -1454061722;
					goto IL_001f;
				}
			}

			internal JsBUqOgSQSNQZKdIsFDoguUzDqX(InputBehavior inputBehavior)
			{
				HihxpSdwPYsIjhCvMYCwBkdxadJ = inputBehavior;
				if (inputBehavior.buttonDownBuffer > 0f)
				{
					kFnuVrKAVqTfbKliMfIvrIjmigT = new TimerAbs(inputBehavior.buttonDownBuffer);
					NnEeVItInZbdRyUNnBsJMoBUXcf = new TimerAbs(inputBehavior.buttonDownBuffer);
				}
				kHSCpxEyvnCtiwtxVXpzlQVDWHT = new ButtonStateRecorder();
				hiJKtdXofZGPfjANHYQicuREwaj = new ButtonStateRecorder();
				UDOjpgxxSIgKavxNRARjjzzZwoU = new tjVSzgCpYulTxiHPuJpvoyKcuuZ(inputBehavior.buttonDoublePressSpeed);
				ADfBLWQhSGxJqRogJFrBkbJTJcGS = new tjVSzgCpYulTxiHPuJpvoyKcuuZ(inputBehavior.buttonDoublePressSpeed);
				WWifMHMFueYRJbVhHxFvlYMKHDC = new uUrXqmpMwYhIOZLxgrbuIRkUIrQ(inputBehavior.buttonRepeatDelay, inputBehavior.buttonRepeatRate);
				YcBlJeAfzxoZjTMQfjitNvDnGIN = new uUrXqmpMwYhIOZLxgrbuIRkUIrQ(inputBehavior.buttonRepeatDelay, inputBehavior.buttonRepeatRate);
				PylIfTbnQolpikzyemdntCmPDTGh();
			}

			internal void uKlBQSKymMulfuqKqgZPVZpnKKFe(float P_0)
			{
				if (UNgIpSIDpIOcEEPZAipQgwXwOQn == 0f)
				{
					if (KdErjvyFToFoJbJAowlBiYFsfgPc != 0f)
					{
						goto IL_0020;
					}
					goto IL_0161;
				}
				goto IL_01a7;
				IL_00da:
				xBFHBukMfoJfcEzzcOryBoGqFtEl = unwgQSnePmeOsXbHPocojQIZGLM;
				int num = -1836230874;
				goto IL_0025;
				IL_0020:
				num = -1836230878;
				goto IL_0025;
				IL_0025:
				while (true)
				{
					switch (num ^ -1836230877)
					{
					case 9:
						break;
					default:
						return;
					case 2:
						goto IL_0069;
					case 6:
						if (WPfrrEiRlQPOOXpqEdazwJczvfx == 0f)
						{
							xBFHBukMfoJfcEzzcOryBoGqFtEl = unwgQSnePmeOsXbHPocojQIZGLM;
							num = -1836230874;
							continue;
						}
						goto IL_0110;
					case 4:
						goto IL_00b9;
					case 12:
						goto IL_00da;
					case 0:
						goto IL_00ef;
					case 5:
						goto IL_0110;
					case 3:
						ICLEJkAWqklVxqIOfOvzTjZEoRDL = unwgQSnePmeOsXbHPocojQIZGLM;
						num = -1836230871;
						continue;
					case 8:
						return;
					case 11:
						goto IL_0161;
					case 7:
						ICLEJkAWqklVxqIOfOvzTjZEoRDL = unwgQSnePmeOsXbHPocojQIZGLM;
						num = -1836230869;
						continue;
					case 1:
						goto IL_01a7;
					case 10:
						return;
					}
					break;
					IL_00ef:
					int num2;
					if (rrjAzCaNkwtEgTDoRtGrPyDdaSc == 0f)
					{
						num = -1836230873;
						num2 = num;
					}
					else
					{
						num = -1836230880;
						num2 = num;
					}
					continue;
					IL_0110:
					if (UNgIpSIDpIOcEEPZAipQgwXwOQn == 0f)
					{
						int num3;
						if (oNOdvUURePKwNGoKnQAvXqJcGIfi == 0f)
						{
							num = -1836230877;
							num3 = num;
						}
						else
						{
							num = -1836230879;
							num3 = num;
						}
						continue;
					}
					goto IL_0069;
					IL_0069:
					if (rrjAzCaNkwtEgTDoRtGrPyDdaSc == 0f)
					{
						int num4;
						if (pTVDRnjYcnQDMNrNAzMmgSXHbaUH == 0f)
						{
							num = -1836230876;
							num4 = num;
						}
						else
						{
							num = -1836230871;
							num4 = num;
						}
						continue;
					}
					return;
					IL_00b9:
					int num5;
					if (pTVDRnjYcnQDMNrNAzMmgSXHbaUH != 0f)
					{
						num = -1836230880;
						num5 = num;
					}
					else
					{
						num = -1836230871;
						num5 = num;
					}
				}
				goto IL_0020;
				IL_0161:
				if (rrjAzCaNkwtEgTDoRtGrPyDdaSc == 0f)
				{
					int num6;
					if (WPfrrEiRlQPOOXpqEdazwJczvfx != 0f)
					{
						num = -1836230865;
						num6 = num;
					}
					else
					{
						num = -1836230874;
						num6 = num;
					}
					goto IL_0025;
				}
				goto IL_00da;
				IL_01a7:
				int num7;
				if (rrjAzCaNkwtEgTDoRtGrPyDdaSc == 0f)
				{
					num = -1836230875;
					num7 = num;
				}
				else
				{
					num = -1836230874;
					num7 = num;
				}
				goto IL_0025;
			}

			internal void oDfPYEjCcaxeqmqiUlUrioIKEyJ()
			{
				if (rrjAzCaNkwtEgTDoRtGrPyDdaSc != UNgIpSIDpIOcEEPZAipQgwXwOQn)
				{
					rrjAzCaNkwtEgTDoRtGrPyDdaSc = UNgIpSIDpIOcEEPZAipQgwXwOQn;
					goto IL_001d;
				}
				goto IL_012a;
				IL_012a:
				int num;
				int num2;
				if (CVSgRsXNUHlgVjnztwMxuTjlNwo == zanoUePzyYulugqVhTLKoWlInDx)
				{
					num = -1035932940;
					num2 = num;
				}
				else
				{
					num = -1035932939;
					num2 = num;
				}
				goto IL_0022;
				IL_001d:
				num = -1035932942;
				goto IL_0022;
				IL_0022:
				while (true)
				{
					switch (num ^ -1035932940)
					{
					case 8:
						break;
					default:
						return;
					case 2:
						if (ghXMdoMIYNCWktzQaJBXsbIIlaq != dsWWLfdILyJiugOyNuBltGXmmpi)
						{
							ghXMdoMIYNCWktzQaJBXsbIIlaq = dsWWLfdILyJiugOyNuBltGXmmpi;
							num = -1035932943;
							continue;
						}
						goto case 5;
					case 0:
						if (EAzdfySBcYVdKgYEfqVxvdbeOHF != JcUFwdVnLFzpOkfTmSpdvzlHOz)
						{
							EAzdfySBcYVdKgYEfqVxvdbeOHF = JcUFwdVnLFzpOkfTmSpdvzlHOz;
							num = -1035932937;
							continue;
						}
						goto case 3;
					case 1:
						CVSgRsXNUHlgVjnztwMxuTjlNwo = zanoUePzyYulugqVhTLKoWlInDx;
						num = -1035932940;
						continue;
					case 7:
						pTVDRnjYcnQDMNrNAzMmgSXHbaUH = oNOdvUURePKwNGoKnQAvXqJcGIfi;
						num = -1035932938;
						continue;
					case 3:
						if (WPfrrEiRlQPOOXpqEdazwJczvfx != KdErjvyFToFoJbJAowlBiYFsfgPc)
						{
							WPfrrEiRlQPOOXpqEdazwJczvfx = KdErjvyFToFoJbJAowlBiYFsfgPc;
							num = -1035932931;
							continue;
						}
						goto IL_00ef;
					case 9:
						goto IL_00ef;
					case 5:
						if (dsWWLfdILyJiugOyNuBltGXmmpi != AxisCoordinateMode.Absolute)
						{
							dsWWLfdILyJiugOyNuBltGXmmpi = AxisCoordinateMode.Absolute;
							num = -1035932944;
							continue;
						}
						return;
					case 6:
						goto IL_012a;
					case 4:
						return;
					}
					break;
					IL_00ef:
					int num3;
					if (pTVDRnjYcnQDMNrNAzMmgSXHbaUH == oNOdvUURePKwNGoKnQAvXqJcGIfi)
					{
						num = -1035932938;
						num3 = num;
					}
					else
					{
						num = -1035932941;
						num3 = num;
					}
				}
				goto IL_001d;
			}

			internal void tNvGMxwBMGZiMzQvLJnBRzBjKWd()
			{
				if (kFnuVrKAVqTfbKliMfIvrIjmigT == null)
				{
					return;
				}
				kFnuVrKAVqTfbKliMfIvrIjmigT.Update();
				while (true)
				{
					int num = 1076268317;
					while (true)
					{
						switch (num ^ 0x40268D1F)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0032;
						case 1:
							return;
						}
						break;
						IL_0032:
						NnEeVItInZbdRyUNnBsJMoBUXcf.Update();
						num = 1076268318;
					}
				}
			}

			internal void bfqbuDQILhAXVmJmrjkHnCPcegW(bool P_0, bool P_1, bool P_2, bool P_3)
			{
				kHSCpxEyvnCtiwtxVXpzlQVDWHT.UZSQFwoMfSAzsmmSKmseCCiJWWD(P_0, P_1, unwgQSnePmeOsXbHPocojQIZGLM);
				float buttonDoublePressSpeed = default(float);
				float buttonRepeatDelay = default(float);
				while (true)
				{
					int num = -1960065296;
					while (true)
					{
						switch (num ^ -1960065293)
						{
						case 0:
							break;
						case 3:
							hiJKtdXofZGPfjANHYQicuREwaj.UZSQFwoMfSAzsmmSKmseCCiJWWD(P_2, P_3, unwgQSnePmeOsXbHPocojQIZGLM);
							buttonDoublePressSpeed = HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonDoublePressSpeed;
							num = -1960065295;
							continue;
						case 2:
							UDOjpgxxSIgKavxNRARjjzzZwoU.UZSQFwoMfSAzsmmSKmseCCiJWWD(buttonDoublePressSpeed, P_0, P_1);
							ADfBLWQhSGxJqRogJFrBkbJTJcGS.UZSQFwoMfSAzsmmSKmseCCiJWWD(buttonDoublePressSpeed, P_2, P_3);
							buttonRepeatDelay = HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonRepeatDelay;
							num = -1960065294;
							continue;
						default:
						{
							float buttonRepeatRate = HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonRepeatRate;
							WWifMHMFueYRJbVhHxFvlYMKHDC.UZSQFwoMfSAzsmmSKmseCCiJWWD(P_0, P_1, buttonRepeatDelay, buttonRepeatRate, unwgQSnePmeOsXbHPocojQIZGLM);
							YcBlJeAfzxoZjTMQfjitNvDnGIN.UZSQFwoMfSAzsmmSKmseCCiJWWD(P_2, P_3, buttonRepeatDelay, buttonRepeatRate, unwgQSnePmeOsXbHPocojQIZGLM);
							return;
						}
						}
						break;
					}
				}
			}

			internal bool QQKsKwXkwROfogZthICxghJqBuC()
			{
				if (unwgQSnePmeOsXbHPocojQIZGLM < AOwPMLrvfPKRDAJWfBqtARkesJy + HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonDoublePressSpeed + 2f * FtnAbdJXGXeezDMRWayldslYfCSO)
				{
					return false;
				}
				if (UNgIpSIDpIOcEEPZAipQgwXwOQn != 0f)
				{
					return false;
				}
				if (rrjAzCaNkwtEgTDoRtGrPyDdaSc != 0f)
				{
					return false;
				}
				if (zanoUePzyYulugqVhTLKoWlInDx == ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE)
				{
					return false;
				}
				if (CVSgRsXNUHlgVjnztwMxuTjlNwo == ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE)
				{
					return false;
				}
				if (JcUFwdVnLFzpOkfTmSpdvzlHOz == ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE)
				{
					goto IL_0061;
				}
				int num;
				if (EAzdfySBcYVdKgYEfqVxvdbeOHF == ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE)
				{
					num = 1548017789;
				}
				else
				{
					if (KdErjvyFToFoJbJAowlBiYFsfgPc != 0f)
					{
						return false;
					}
					if (WPfrrEiRlQPOOXpqEdazwJczvfx != 0f)
					{
						return false;
					}
					if (oNOdvUURePKwNGoKnQAvXqJcGIfi != 0f)
					{
						return false;
					}
					if (pTVDRnjYcnQDMNrNAzMmgSXHbaUH != 0f)
					{
						return false;
					}
					if (kFnuVrKAVqTfbKliMfIvrIjmigT != null && kFnuVrKAVqTfbKliMfIvrIjmigT.running)
					{
						return false;
					}
					if (NnEeVItInZbdRyUNnBsJMoBUXcf == null || !NnEeVItInZbdRyUNnBsJMoBUXcf.running)
					{
						return true;
					}
					num = 1548017788;
				}
				goto IL_0066;
				IL_0061:
				num = 1548017791;
				goto IL_0066;
				IL_0066:
				switch (num ^ 0x5C44E07E)
				{
				case 0:
					break;
				case 1:
					return false;
				case 3:
					return false;
				default:
					return false;
				}
				goto IL_0061;
			}

			internal void MiOeMekkkYgPoGSIgxUpgVSfEudK()
			{
				zanoUePzyYulugqVhTLKoWlInDx &= ~ButtonStateFlags.FRjFpveoAfCIfdseBZyzcnsVzsPH;
			}

			internal void WZzGaCOQpfHRhCqLXMXIzBuawBP()
			{
				if (UNgIpSIDpIOcEEPZAipQgwXwOQn == 0f)
				{
					if (KdErjvyFToFoJbJAowlBiYFsfgPc != 0f)
					{
						goto IL_001d;
					}
					goto IL_0080;
				}
				goto IL_015f;
				IL_0080:
				int num;
				if (UNgIpSIDpIOcEEPZAipQgwXwOQn == 0f)
				{
					int num2;
					if (oNOdvUURePKwNGoKnQAvXqJcGIfi != 0f)
					{
						num = -80737397;
						num2 = num;
					}
					else
					{
						num = -80737404;
						num2 = num;
					}
					goto IL_0022;
				}
				goto IL_006e;
				IL_001d:
				num = -80737402;
				goto IL_0022;
				IL_0022:
				while (true)
				{
					switch (num ^ -80737403)
					{
					case 12:
						break;
					default:
						return;
					case 14:
						goto IL_006e;
					case 10:
						goto IL_0080;
					case 11:
						ADfBLWQhSGxJqRogJFrBkbJTJcGS.EEGiMNPSMElaPgKQdmScoWLedfb();
						num = -80737403;
						continue;
					case 1:
						UNgIpSIDpIOcEEPZAipQgwXwOQn = 0f;
						rrjAzCaNkwtEgTDoRtGrPyDdaSc = 0f;
						num = -80737401;
						continue;
					case 7:
						NnEeVItInZbdRyUNnBsJMoBUXcf.Clear();
						num = -80737405;
						continue;
					case 13:
						WPfrrEiRlQPOOXpqEdazwJczvfx = 0f;
						oNOdvUURePKwNGoKnQAvXqJcGIfi = 0f;
						num = -80737408;
						continue;
					case 2:
						dsWWLfdILyJiugOyNuBltGXmmpi = AxisCoordinateMode.Absolute;
						zanoUePzyYulugqVhTLKoWlInDx = ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE;
						CVSgRsXNUHlgVjnztwMxuTjlNwo = ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE;
						num = -80737395;
						continue;
					case 5:
						pTVDRnjYcnQDMNrNAzMmgSXHbaUH = 0f;
						if (kFnuVrKAVqTfbKliMfIvrIjmigT != null)
						{
							kFnuVrKAVqTfbKliMfIvrIjmigT.Clear();
							num = -80737406;
							continue;
						}
						goto case 6;
					case 3:
						goto IL_015f;
					case 4:
						YcBlJeAfzxoZjTMQfjitNvDnGIN.EEGiMNPSMElaPgKQdmScoWLedfb();
						pvTxooprdRDCMXRPzWBtuHmktwn.nympziBLtYDUiPlWNRoEGqbSPfa();
						num = -80737396;
						continue;
					case 0:
						kHSCpxEyvnCtiwtxVXpzlQVDWHT.WZzGaCOQpfHRhCqLXMXIzBuawBP(unwgQSnePmeOsXbHPocojQIZGLM);
						hiJKtdXofZGPfjANHYQicuREwaj.WZzGaCOQpfHRhCqLXMXIzBuawBP(unwgQSnePmeOsXbHPocojQIZGLM);
						WWifMHMFueYRJbVhHxFvlYMKHDC.EEGiMNPSMElaPgKQdmScoWLedfb();
						num = -80737407;
						continue;
					case 6:
						UDOjpgxxSIgKavxNRARjjzzZwoU.EEGiMNPSMElaPgKQdmScoWLedfb();
						num = -80737394;
						continue;
					case 8:
						JcUFwdVnLFzpOkfTmSpdvzlHOz = ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE;
						EAzdfySBcYVdKgYEfqVxvdbeOHF = ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE;
						KdErjvyFToFoJbJAowlBiYFsfgPc = 0f;
						num = -80737400;
						continue;
					case 9:
						return;
					}
					break;
				}
				goto IL_001d;
				IL_006e:
				ICLEJkAWqklVxqIOfOvzTjZEoRDL = unwgQSnePmeOsXbHPocojQIZGLM;
				num = -80737404;
				goto IL_0022;
				IL_015f:
				xBFHBukMfoJfcEzzcOryBoGqFtEl = unwgQSnePmeOsXbHPocojQIZGLM;
				num = -80737393;
				goto IL_0022;
			}

			internal void PylIfTbnQolpikzyemdntCmPDTGh()
			{
				WZzGaCOQpfHRhCqLXMXIzBuawBP();
				kHSCpxEyvnCtiwtxVXpzlQVDWHT.EEGiMNPSMElaPgKQdmScoWLedfb();
				hiJKtdXofZGPfjANHYQicuREwaj.EEGiMNPSMElaPgKQdmScoWLedfb();
				xBFHBukMfoJfcEzzcOryBoGqFtEl = unwgQSnePmeOsXbHPocojQIZGLM;
				ICLEJkAWqklVxqIOfOvzTjZEoRDL = unwgQSnePmeOsXbHPocojQIZGLM;
			}
		}

		public JsBUqOgSQSNQZKdIsFDoguUzDqX[] gRSZlsGnOMePzdfqhIobycvdjXwm;

		private readonly int[] CHoRXFaiXpGXafiYeDBMIipZWCo;

		private int RMmuzLwPyyqjZzFkavzjXDLDVyZ;

		internal JsBUqOgSQSNQZKdIsFDoguUzDqX xbRrcEKKIAKiQkVzQCekOswVHrJ;

		internal UpdateLoopType updateLoop
		{
			set
			{
				RMmuzLwPyyqjZzFkavzjXDLDVyZ = CHoRXFaiXpGXafiYeDBMIipZWCo[(int)value];
				xbRrcEKKIAKiQkVzQCekOswVHrJ = gRSZlsGnOMePzdfqhIobycvdjXwm[RMmuzLwPyyqjZzFkavzjXDLDVyZ];
			}
		}

		internal SKECkQutNYMIhCJMbhLUCEtvhao(UpdateLoopSetting updateLoopSetting, InputBehavior inputBehavior)
		{
			CHoRXFaiXpGXafiYeDBMIipZWCo = new int[3];
			ArrayTools.Fill(CHoRXFaiXpGXafiYeDBMIipZWCo, -1);
			int num = 0;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
				for (int i = 0; i < list.Count; i++)
				{
					CHoRXFaiXpGXafiYeDBMIipZWCo[(int)list[i]] = num;
					num++;
				}
			}
			gRSZlsGnOMePzdfqhIobycvdjXwm = new JsBUqOgSQSNQZKdIsFDoguUzDqX[num];
			for (int j = 0; j < num; j++)
			{
				gRSZlsGnOMePzdfqhIobycvdjXwm[j] = new JsBUqOgSQSNQZKdIsFDoguUzDqX(inputBehavior);
			}
			xbRrcEKKIAKiQkVzQCekOswVHrJ = gRSZlsGnOMePzdfqhIobycvdjXwm[0];
		}

		internal bool QQKsKwXkwROfogZthICxghJqBuC()
		{
			int num = 0;
			while (num < 3)
			{
				while (true)
				{
					int num2;
					if (CHoRXFaiXpGXafiYeDBMIipZWCo[num] >= 0)
					{
						num2 = -1858126071;
						goto IL_0009;
					}
					goto IL_0050;
					IL_0038:
					if (!gRSZlsGnOMePzdfqhIobycvdjXwm[CHoRXFaiXpGXafiYeDBMIipZWCo[num]].QQKsKwXkwROfogZthICxghJqBuC())
					{
						return false;
					}
					goto IL_0050;
					IL_0050:
					num++;
					num2 = -1858126069;
					goto IL_0009;
					IL_0009:
					while (true)
					{
						switch (num2 ^ -1858126072)
						{
						case 0:
							num2 = -1858126070;
							continue;
						case 2:
							break;
						case 1:
							goto IL_0038;
						default:
							goto end_IL_0026;
						}
						break;
					}
					continue;
					end_IL_0026:
					break;
				}
			}
			return true;
		}

		internal void EEGiMNPSMElaPgKQdmScoWLedfb()
		{
			int num = 0;
			while (true)
			{
				int num2 = -483100635;
				while (true)
				{
					switch (num2 ^ -483100634)
					{
					case 2:
						break;
					case 3:
						num2 = -483100633;
						continue;
					case 0:
						gRSZlsGnOMePzdfqhIobycvdjXwm[num].PylIfTbnQolpikzyemdntCmPDTGh();
						num++;
						num2 = -483100633;
						continue;
					default:
						if (num >= gRSZlsGnOMePzdfqhIobycvdjXwm.Length)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		internal void WZzGaCOQpfHRhCqLXMXIzBuawBP()
		{
			int num = 0;
			while (num < gRSZlsGnOMePzdfqhIobycvdjXwm.Length)
			{
				while (true)
				{
					gRSZlsGnOMePzdfqhIobycvdjXwm[num].WZzGaCOQpfHRhCqLXMXIzBuawBP();
					num++;
					int num2 = 1515788138;
					while (true)
					{
						switch (num2 ^ 0x5A591768)
						{
						case 0:
							num2 = 1515788137;
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

	private class McxCHKbgQLeTCXvwphPpdAMChbv
	{
		internal class LaTYtWeQiHNKnYCvGDSpCTeuEvj
		{
			internal Vector3 qTXijyhNvQlhZtLXeaYHabQJfSy;

			internal Vector3 efYhwbbjTdAuLIdSQxcnbwUIqjNb;

			internal Vector3 JfWuLmGGNdiTjqODrUmFAcpZaHb;

			internal void QqdMUzFhFyfJeuvVbValgLQazpE()
			{
				qTXijyhNvQlhZtLXeaYHabQJfSy = ReInput.controllers.Mouse.screenPosition;
				JfWuLmGGNdiTjqODrUmFAcpZaHb = qTXijyhNvQlhZtLXeaYHabQJfSy - efYhwbbjTdAuLIdSQxcnbwUIqjNb;
			}

			internal void VzfSxGrAaRXjqXjoLvCooxYxhkA()
			{
				efYhwbbjTdAuLIdSQxcnbwUIqjNb.x = qTXijyhNvQlhZtLXeaYHabQJfSy.x;
				efYhwbbjTdAuLIdSQxcnbwUIqjNb.y = qTXijyhNvQlhZtLXeaYHabQJfSy.y;
				efYhwbbjTdAuLIdSQxcnbwUIqjNb.z = qTXijyhNvQlhZtLXeaYHabQJfSy.z;
			}
		}

		private ADictionary<int, LaTYtWeQiHNKnYCvGDSpCTeuEvj> eYGHEvjfglVQjGXNohHnkDIesNr;

		private LaTYtWeQiHNKnYCvGDSpCTeuEvj eVcTAJxFZUqrXMkDoeqsaPHTsDdA;

		private UpdateLoopType xXeNJfMPHnbgrmrmtEOqQyvMFTV;

		internal LaTYtWeQiHNKnYCvGDSpCTeuEvj current
		{
			get
			{
				return eVcTAJxFZUqrXMkDoeqsaPHTsDdA;
			}
		}

		internal McxCHKbgQLeTCXvwphPpdAMChbv(UpdateLoopSetting updateLoopSetting)
		{
			eVcTAJxFZUqrXMkDoeqsaPHTsDdA = null;
			eYGHEvjfglVQjGXNohHnkDIesNr = new ADictionary<int, LaTYtWeQiHNKnYCvGDSpCTeuEvj>();
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
				for (int i = 0; i < list.Count; i++)
				{
					LaTYtWeQiHNKnYCvGDSpCTeuEvj value = new LaTYtWeQiHNKnYCvGDSpCTeuEvj();
					eYGHEvjfglVQjGXNohHnkDIesNr.Add((int)list[i], value);
					if (eVcTAJxFZUqrXMkDoeqsaPHTsDdA == null)
					{
						eVcTAJxFZUqrXMkDoeqsaPHTsDdA = value;
					}
				}
			}
		}

		internal void QqdMUzFhFyfJeuvVbValgLQazpE(UpdateLoopType P_0)
		{
			if (xXeNJfMPHnbgrmrmtEOqQyvMFTV != P_0)
			{
				xXeNJfMPHnbgrmrmtEOqQyvMFTV = P_0;
				goto IL_0010;
			}
			goto IL_002e;
			IL_002e:
			eVcTAJxFZUqrXMkDoeqsaPHTsDdA = eYGHEvjfglVQjGXNohHnkDIesNr[(int)P_0];
			eVcTAJxFZUqrXMkDoeqsaPHTsDdA.QqdMUzFhFyfJeuvVbValgLQazpE();
			int num = 41229568;
			goto IL_0015;
			IL_0010:
			num = 41229569;
			goto IL_0015;
			IL_0015:
			switch (num ^ 0x2751D00)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_002e;
			case 0:
				return;
			}
			goto IL_0010;
		}

		internal void VzfSxGrAaRXjqXjoLvCooxYxhkA()
		{
			eVcTAJxFZUqrXMkDoeqsaPHTsDdA.VzfSxGrAaRXjqXjoLvCooxYxhkA();
		}
	}

	private const int gcBcKDDTxoTGvkaEZYUOlujNduX = 4;

	internal readonly string EqppaAHmTQvmVSSZadzlNpPBbHM;

	internal readonly int mecAvOSCkKTUzDMSKLpGqHuOJBZ;

	internal readonly int iueDnAHVXVmEMnNCzSowjkddzOFv;

	private readonly int znFtIaPrJLvdjPGCwXFaaAeLKcr;

	private InputBehavior HihxpSdwPYsIjhCvMYCwBkdxadJ;

	private SKECkQutNYMIhCJMbhLUCEtvhao gEdpOQDFgIHMoPAgtBTvFPVPKxn;

	private static ConfigVars nsJgCtIfwJQZurQxCSnuqEVGIyJc;

	private static McxCHKbgQLeTCXvwphPpdAMChbv bLPaxWJSJCqpVCLqLusAATMFVk;

	private static UpdateLoopType JxkiCllALlOapFhJuteRVKXasok;

	private static float unwgQSnePmeOsXbHPocojQIZGLM;

	private static float FtnAbdJXGXeezDMRWayldslYfCSO;

	private static uint hWAnDmuqbaIKpNQdQgNkFhDtLnEn;

	private float HfZTJykLRzldxCrzDswtFQoNUkd;

	private float tUkCddoPDQBtIBhMTTLqJmANEkOm;

	private float BqSxCNcqtnGEUYQKLTosluKbCWv;

	private float GqnUeoGscYwHeyyQSYHzXmCiyUM;

	private ButtonStateFlags cVwONtxxImBBAJHPLCLcIpmkQjxq;

	private ButtonStateFlags TwTlfZOgJjAEgkShVdXEzccWNZhB;

	private float xTXnjUEgRpJSoSciGkqIwiYcoiR;

	private bool egsAOrNFIRTqDBlgUNaUcrFVsIT;

	private AxisCoordinateMode EqecLYyMfUxNkSSXzJjNucbeQLC;

	private AxisCoordinateMode ICXwTWoLJYoCGrxbHxaMHxHJCBj;

	private readonly relHYLHuZaHJcMNiFYaqgcWRfBnm ewdHJUWumaxMSrWxgtgHWZCUBVu = new relHYLHuZaHJcMNiFYaqgcWRfBnm();

	private uint htQVBCtMlWHCXynMZqmkAgjSTzF;

	private uint PNxPCjAmjiDoWHtojoxdKnxPAbRz;

	private bool HMNyFKyZGzSdooBygLuNPXBYQAV;

	private bdaJzDHyzUjPDoLNWgKikXyIWEb yBvowLMzNQNCiJpkoUVXscczfGf;

	private int ErmHUMGOYeMsbkUnQOSWpCCsoJi;

	private relHYLHuZaHJcMNiFYaqgcWRfBnm[] baFoVhGTvsLmOqRnADIvIDxcUTJ;

	private List<InputActionSourceData> SGicgFcJrXWPtFAfvaRnglZjQoYs;

	private ReadOnlyCollection<InputActionSourceData> dCupHXIvzUnqbIifHJeyoBWtAEl;

	private bool najTSAvsXJcXISVnkxWGCphYKs;

	internal bool mFczoEbROoNOTHHEQCmVfUMtAPcv;

	internal bdaJzDHyzUjPDoLNWgKikXyIWEb XErgmKvbqxuxWNjcDCZkUThgJqU = bdaJzDHyzUjPDoLNWgKikXyIWEb.oUspIGvJppSFjIPHXDCBiuVNAUZ;

	internal static readonly YELADGAuWhMAnmQvkxgchkzhIWFg mVtcFLxQSQcWKxQcbCEwTHiltDo;

	static pEQcyInzaqspNDwmuMYGrewsNaQ()
	{
		mVtcFLxQSQcWKxQcbCEwTHiltDo = new YELADGAuWhMAnmQvkxgchkzhIWFg();
	}

	internal pEQcyInzaqspNDwmuMYGrewsNaQ(int playerId, InputAction action, InputBehavior inputBehavior, ConfigVars configVars)
	{
		znFtIaPrJLvdjPGCwXFaaAeLKcr = ReInput._id;
		nsJgCtIfwJQZurQxCSnuqEVGIyJc = configVars;
		iueDnAHVXVmEMnNCzSowjkddzOFv = playerId;
		mecAvOSCkKTUzDMSKLpGqHuOJBZ = action.id;
		EqppaAHmTQvmVSSZadzlNpPBbHM = action.name;
		HihxpSdwPYsIjhCvMYCwBkdxadJ = inputBehavior;
		gEdpOQDFgIHMoPAgtBTvFPVPKxn = new SKECkQutNYMIhCJMbhLUCEtvhao(configVars.updateLoop, inputBehavior);
		baFoVhGTvsLmOqRnADIvIDxcUTJ = new relHYLHuZaHJcMNiFYaqgcWRfBnm[4];
		ArrayTools.Populate(baFoVhGTvsLmOqRnADIvIDxcUTJ);
		SGicgFcJrXWPtFAfvaRnglZjQoYs = new List<InputActionSourceData>();
		dCupHXIvzUnqbIifHJeyoBWtAEl = new ReadOnlyCollection<InputActionSourceData>(SGicgFcJrXWPtFAfvaRnglZjQoYs);
	}

	internal static void lZDnsMFoECSQYMqgYReYfmsDWvn(ConfigVars P_0)
	{
		bLPaxWJSJCqpVCLqLusAATMFVk = new McxCHKbgQLeTCXvwphPpdAMChbv(P_0.updateLoop);
	}

	internal static void qXeEpEAMmybZAuBDccxUJFBbssgZ(UpdateLoopType P_0)
	{
		JxkiCllALlOapFhJuteRVKXasok = P_0;
		unwgQSnePmeOsXbHPocojQIZGLM = ReInput.unscaledTime;
		while (true)
		{
			int num = -1549921196;
			while (true)
			{
				switch (num ^ -1549921194)
				{
				case 0:
					break;
				case 2:
					FtnAbdJXGXeezDMRWayldslYfCSO = ReInput.unscaledDeltaTime;
					num = -1549921195;
					continue;
				case 3:
					hWAnDmuqbaIKpNQdQgNkFhDtLnEn = ReInput.absFrame;
					num = -1549921193;
					continue;
				default:
					bLPaxWJSJCqpVCLqLusAATMFVk.QqdMUzFhFyfJeuvVbValgLQazpE(P_0);
					return;
				}
				break;
			}
		}
	}

	internal static void dWJJRHZImnLwizGfWdMPhVpoivW()
	{
		bLPaxWJSJCqpVCLqLusAATMFVk.VzfSxGrAaRXjqXjoLvCooxYxhkA();
	}

	private void GTzACVBoDXCMKlPFVHWxJKWPvCV()
	{
		gEdpOQDFgIHMoPAgtBTvFPVPKxn.updateLoop = JxkiCllALlOapFhJuteRVKXasok;
		while (true)
		{
			int num = 535178552;
			while (true)
			{
				switch (num ^ 0x1FE62D39)
				{
				case 11:
					break;
				default:
					return;
				case 3:
					if (TwTlfZOgJjAEgkShVdXEzccWNZhB != ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE)
					{
						TwTlfZOgJjAEgkShVdXEzccWNZhB = ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE;
						num = 535178548;
						continue;
					}
					goto case 13;
				case 0:
					if (ewdHJUWumaxMSrWxgtgHWZCUBVu.dQXcQJDbmxDlBFIlDXhsTynLjSHE)
					{
						ewdHJUWumaxMSrWxgtgHWZCUBVu.nympziBLtYDUiPlWNRoEGqbSPfa();
						num = 535178556;
						continue;
					}
					return;
				case 10:
					if (ICXwTWoLJYoCGrxbHxaMHxHJCBj != AxisCoordinateMode.Absolute)
					{
						ICXwTWoLJYoCGrxbHxaMHxHJCBj = AxisCoordinateMode.Absolute;
						num = 535178559;
						continue;
					}
					goto case 6;
				case 12:
				{
					int num3;
					if (BqSxCNcqtnGEUYQKLTosluKbCWv == 0f)
					{
						num = 535178555;
						num3 = num;
					}
					else
					{
						num = 535178550;
						num3 = num;
					}
					continue;
				}
				case 1:
					gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.oDfPYEjCcaxeqmqiUlUrioIKEyJ();
					gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.tNvGMxwBMGZiMzQvLJnBRzBjKWd();
					if (HfZTJykLRzldxCrzDswtFQoNUkd != 0f)
					{
						HfZTJykLRzldxCrzDswtFQoNUkd = 0f;
						num = 535178551;
						continue;
					}
					goto case 14;
				case 9:
					if (EqecLYyMfUxNkSSXzJjNucbeQLC != AxisCoordinateMode.Absolute)
					{
						EqecLYyMfUxNkSSXzJjNucbeQLC = AxisCoordinateMode.Absolute;
						num = 535178547;
						continue;
					}
					goto case 10;
				case 8:
					if (cVwONtxxImBBAJHPLCLcIpmkQjxq != ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE)
					{
						cVwONtxxImBBAJHPLCLcIpmkQjxq = ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE;
						num = 535178554;
						continue;
					}
					goto case 3;
				case 13:
					if (xTXnjUEgRpJSoSciGkqIwiYcoiR != 0f)
					{
						xTXnjUEgRpJSoSciGkqIwiYcoiR = 0f;
						num = 535178558;
						continue;
					}
					goto case 7;
				case 6:
					if (ErmHUMGOYeMsbkUnQOSWpCCsoJi > 0)
					{
						WNwrBesGBycPmBudREqfyBUOyQC();
						num = 535178553;
						continue;
					}
					goto case 0;
				case 14:
					if (tUkCddoPDQBtIBhMTTLqJmANEkOm != 0f)
					{
						tUkCddoPDQBtIBhMTTLqJmANEkOm = 0f;
						num = 535178545;
						continue;
					}
					goto case 8;
				case 15:
					BqSxCNcqtnGEUYQKLTosluKbCWv = 0f;
					num = 535178555;
					continue;
				case 7:
				{
					int num2;
					if (!egsAOrNFIRTqDBlgUNaUcrFVsIT)
					{
						num = 535178549;
						num2 = num;
					}
					else
					{
						num = 535178557;
						num2 = num;
					}
					continue;
				}
				case 4:
					egsAOrNFIRTqDBlgUNaUcrFVsIT = false;
					num = 535178549;
					continue;
				case 2:
					if (GqnUeoGscYwHeyyQSYHzXmCiyUM != 0f)
					{
						GqnUeoGscYwHeyyQSYHzXmCiyUM = 0f;
						num = 535178544;
						continue;
					}
					goto case 9;
				case 5:
					return;
				}
				break;
			}
		}
	}

	internal void orpBerQnpiDZwFOFKwzrggRpZeZ(bool P_0)
	{
		if (htQVBCtMlWHCXynMZqmkAgjSTzF != hWAnDmuqbaIKpNQdQgNkFhDtLnEn)
		{
			htQVBCtMlWHCXynMZqmkAgjSTzF = hWAnDmuqbaIKpNQdQgNkFhDtLnEn;
			goto IL_001b;
		}
		goto IL_0440;
		IL_06aa:
		YELADGAuWhMAnmQvkxgchkzhIWFg yELADGAuWhMAnmQvkxgchkzhIWFg = mVtcFLxQSQcWKxQcbCEwTHiltDo;
		int mMyVYAPDqUrVlKvCuSgnRJfZwdm = yELADGAuWhMAnmQvkxgchkzhIWFg.zZOKcJvuOQCLBInkTSUcrEfEQnB.mMyVYAPDqUrVlKvCuSgnRJfZwdm;
		THfyrqeAKnGTczJUseGrDoJYCOr(yELADGAuWhMAnmQvkxgchkzhIWFg.xwApvxwuWEivSrbItjIXHBzMlIz, yELADGAuWhMAnmQvkxgchkzhIWFg.NsnpsJhWvVdnFvGpHHimGkwdsno, yELADGAuWhMAnmQvkxgchkzhIWFg.zZOKcJvuOQCLBInkTSUcrEfEQnB);
		int num = 1272629016;
		goto IL_0020;
		IL_001b:
		num = 1272629026;
		goto IL_0020;
		IL_0020:
		float num3 = default(float);
		float num5 = default(float);
		ControllerType slhgqMdZzgOWWmMwSscraDibqHK = default(ControllerType);
		float num4 = default(float);
		McxCHKbgQLeTCXvwphPpdAMChbv.LaTYtWeQiHNKnYCvGDSpCTeuEvj current = default(McxCHKbgQLeTCXvwphPpdAMChbv.LaTYtWeQiHNKnYCvGDSpCTeuEvj);
		float num2 = default(float);
		while (true)
		{
			switch (num ^ 0x4BDAC732)
			{
			case 37:
				break;
			default:
				return;
			case 32:
				num3 = Screen.width;
				num5 = num3;
				num = 1272629049;
				continue;
			case 12:
				switch (slhgqMdZzgOWWmMwSscraDibqHK)
				{
				case ControllerType.Mouse:
					goto IL_041e;
				case ControllerType.Custom:
					goto IL_04a7;
				case ControllerType.Joystick:
					goto IL_062f;
				}
				num = 1272629036;
				continue;
			case 40:
				if (HihxpSdwPYsIjhCvMYCwBkdxadJ.mouseXYAxisDeltaCalc == MouseXYAxisDeltaCalc.Normal)
				{
					num3 = Screen.width;
					num5 = Screen.height;
					num = 1272629017;
					continue;
				}
				goto IL_0211;
			case 35:
				if (mFczoEbROoNOTHHEQCmVfUMtAPcv)
				{
					GTzACVBoDXCMKlPFVHWxJKWPvCV();
					num = 1272629039;
					continue;
				}
				goto case 7;
			case 25:
				if (HihxpSdwPYsIjhCvMYCwBkdxadJ.mouseXYAxisDeltaCalc == MouseXYAxisDeltaCalc.ScreenHeight)
				{
					num5 = Screen.height;
					num3 = num5;
					num = 1272629027;
					continue;
				}
				goto case 44;
			case 20:
				gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.AOwPMLrvfPKRDAJWfBqtARkesJy = unwgQSnePmeOsXbHPocojQIZGLM;
				num = 1272629023;
				continue;
			case 51:
				if (HihxpSdwPYsIjhCvMYCwBkdxadJ.mouseXYAxisMode == MouseXYAxisMode.Speed)
				{
					num4 /= FtnAbdJXGXeezDMRWayldslYfCSO;
					num = 1272629043;
					continue;
				}
				goto case 1;
			case 31:
				return;
			case 6:
				goto IL_01f5;
			case 13:
				goto IL_0211;
			case 47:
				goto IL_0233;
			case 38:
				if (yELADGAuWhMAnmQvkxgchkzhIWFg.zZOKcJvuOQCLBInkTSUcrEfEQnB._axisContribution == Pole.Positive)
				{
					AjQIUTFSzRRIZyxPPAmbfSsdwkT(ref cVwONtxxImBBAJHPLCLcIpmkQjxq, yELADGAuWhMAnmQvkxgchkzhIWFg.zanoUePzyYulugqVhTLKoWlInDx);
					num = 1272629044;
					continue;
				}
				goto case 28;
			case 4:
				if (mMyVYAPDqUrVlKvCuSgnRJfZwdm >= 2)
				{
					goto case 34;
				}
				if (HihxpSdwPYsIjhCvMYCwBkdxadJ.mouseXYAxisMode == MouseXYAxisMode.MouseAxis)
				{
					BqSxCNcqtnGEUYQKLTosluKbCWv += yELADGAuWhMAnmQvkxgchkzhIWFg.JHgsNLxiAQVnmyfVeWejfTJocIu * HihxpSdwPYsIjhCvMYCwBkdxadJ.mouseXYAxisSensitivity;
					num = 1272629025;
					continue;
				}
				goto case 50;
			case 17:
				num = 1272629049;
				continue;
			case 14:
				if (yELADGAuWhMAnmQvkxgchkzhIWFg.JHgsNLxiAQVnmyfVeWejfTJocIu != 0f)
				{
					xTXnjUEgRpJSoSciGkqIwiYcoiR += (int)(1f * MathTools.Sign(yELADGAuWhMAnmQvkxgchkzhIWFg.JHgsNLxiAQVnmyfVeWejfTJocIu));
					ewdHJUWumaxMSrWxgtgHWZCUBVu.fuLKaTfKQpOpktgPzRLpUDfEjf(yELADGAuWhMAnmQvkxgchkzhIWFg);
					num = 1272629033;
					continue;
				}
				goto IL_05dd;
			case 15:
				goto IL_030a;
			case 33:
				if (yELADGAuWhMAnmQvkxgchkzhIWFg.jtJqVgInZRaLUQAkQAhzWYXSDiZ == ControllerElementType.Axis)
				{
					slhgqMdZzgOWWmMwSscraDibqHK = yELADGAuWhMAnmQvkxgchkzhIWFg.SlhgqMdZzgOWWmMwSscraDibqHK;
					num = 1272629054;
					continue;
				}
				goto case 3;
			case 11:
				current = bLPaxWJSJCqpVCLqLusAATMFVk.current;
				num = 1272629051;
				continue;
			case 8:
				goto IL_035e;
			case 0:
				return;
			case 34:
				if (HihxpSdwPYsIjhCvMYCwBkdxadJ.mouseOtherAxisMode == MouseOtherAxisMode.MouseAxis)
				{
					BqSxCNcqtnGEUYQKLTosluKbCWv += yELADGAuWhMAnmQvkxgchkzhIWFg.JHgsNLxiAQVnmyfVeWejfTJocIu * HihxpSdwPYsIjhCvMYCwBkdxadJ.mouseOtherAxisSensitivity;
					num = 1272629025;
					continue;
				}
				goto case 19;
			case 28:
				AjQIUTFSzRRIZyxPPAmbfSsdwkT(ref TwTlfZOgJjAEgkShVdXEzccWNZhB, yELADGAuWhMAnmQvkxgchkzhIWFg.zanoUePzyYulugqVhTLKoWlInDx);
				num = 1272629044;
				continue;
			case 16:
				if (yBvowLMzNQNCiJpkoUVXscczfGf != XErgmKvbqxuxWNjcDCZkUThgJqU)
				{
					yBvowLMzNQNCiJpkoUVXscczfGf = XErgmKvbqxuxWNjcDCZkUThgJqU;
					num = 1272629009;
					continue;
				}
				goto case 35;
			case 46:
				num = 1272629025;
				continue;
			case 24:
				return;
			case 22:
				goto IL_041e;
			case 29:
				goto IL_0440;
			case 41:
				AjQIUTFSzRRIZyxPPAmbfSsdwkT(ref cVwONtxxImBBAJHPLCLcIpmkQjxq, yELADGAuWhMAnmQvkxgchkzhIWFg.zanoUePzyYulugqVhTLKoWlInDx);
				num = 1272629052;
				continue;
			case 2:
			{
				float y = current.JfWuLmGGNdiTjqODrUmFAcpZaHb.y;
				if (y != 0f)
				{
					num4 = y / num5;
					num = 1272628993;
					continue;
				}
				goto case 19;
			}
			case 44:
				throw new NotImplementedException();
			case 49:
				goto IL_04a7;
			case 21:
				HfZTJykLRzldxCrzDswtFQoNUkd += yELADGAuWhMAnmQvkxgchkzhIWFg.JHgsNLxiAQVnmyfVeWejfTJocIu;
				return;
			case 9:
			{
				if (mMyVYAPDqUrVlKvCuSgnRJfZwdm != 0)
				{
					goto case 2;
				}
				float x = current.JfWuLmGGNdiTjqODrUmFAcpZaHb.x;
				if (x == 0f)
				{
					goto case 19;
				}
				num2 = x / num3;
				if (HihxpSdwPYsIjhCvMYCwBkdxadJ.mouseXYAxisMode == MouseXYAxisMode.Speed)
				{
					num2 /= FtnAbdJXGXeezDMRWayldslYfCSO;
					num = 1272628994;
					continue;
				}
				goto case 48;
			}
			case 36:
				if (mMyVYAPDqUrVlKvCuSgnRJfZwdm <= 1 || HihxpSdwPYsIjhCvMYCwBkdxadJ.mouseOtherAxisMode != MouseOtherAxisMode.DigitalAxis)
				{
					goto case 4;
				}
				goto IL_0547;
			case 1:
				BqSxCNcqtnGEUYQKLTosluKbCWv += num4;
				num = 1272629048;
				continue;
			case 19:
				aASEOsofovJSOnzKqWanhdKWhjw(yELADGAuWhMAnmQvkxgchkzhIWFg, HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonDeadZone, false);
				num = 1272629034;
				continue;
			case 7:
				if (XErgmKvbqxuxWNjcDCZkUThgJqU == bdaJzDHyzUjPDoLNWgKikXyIWEb.oUspIGvJppSFjIPHXDCBiuVNAUZ)
				{
					XErgmKvbqxuxWNjcDCZkUThgJqU = bdaJzDHyzUjPDoLNWgKikXyIWEb.lAbGsNJnXfmjcYkPrdpDpsjnFLS;
					num = 1272629039;
					continue;
				}
				goto IL_0440;
			case 42:
				if (yELADGAuWhMAnmQvkxgchkzhIWFg.jtJqVgInZRaLUQAkQAhzWYXSDiZ != ControllerElementType.Button)
				{
					goto case 33;
				}
				goto IL_05c1;
			case 27:
				goto IL_05dd;
			case 48:
				BqSxCNcqtnGEUYQKLTosluKbCWv += num2;
				num = 1272629020;
				continue;
			case 23:
				AjQIUTFSzRRIZyxPPAmbfSsdwkT(ref TwTlfZOgJjAEgkShVdXEzccWNZhB, yELADGAuWhMAnmQvkxgchkzhIWFg.zanoUePzyYulugqVhTLKoWlInDx);
				num = 1272629052;
				continue;
			case 5:
				goto IL_062f;
			case 26:
				egsAOrNFIRTqDBlgUNaUcrFVsIT = true;
				return;
			case 30:
				throw new NotImplementedException();
			case 10:
				num = 1272629025;
				continue;
			case 50:
				if (HihxpSdwPYsIjhCvMYCwBkdxadJ.mouseXYAxisMode == MouseXYAxisMode.ScreenPositionDelta)
				{
					goto case 40;
				}
				goto IL_0688;
			case 45:
				goto IL_06aa;
			case 3:
				throw new NotImplementedException();
			case 43:
				num = 1272629049;
				continue;
			case 39:
				NkZydDENmorvpVrmCVfsQnRvDxL();
				GTzACVBoDXCMKlPFVHWxJKWPvCV();
				num = 1272629030;
				continue;
			case 18:
				return;
				IL_062f:
				eddcKOGndhFTxAZFQITcfAANxOm(yELADGAuWhMAnmQvkxgchkzhIWFg, HihxpSdwPYsIjhCvMYCwBkdxadJ.joystickAxisSensitivity);
				num = 1272629042;
				continue;
				IL_04a7:
				eddcKOGndhFTxAZFQITcfAANxOm(yELADGAuWhMAnmQvkxgchkzhIWFg, HihxpSdwPYsIjhCvMYCwBkdxadJ.customControllerAxisSensitivity);
				return;
				IL_041e:
				if (mMyVYAPDqUrVlKvCuSgnRJfZwdm >= 2)
				{
					goto case 36;
				}
				if (HihxpSdwPYsIjhCvMYCwBkdxadJ.mouseXYAxisMode != MouseXYAxisMode.DigitalAxis)
				{
					num = 1272629014;
					continue;
				}
				goto IL_0547;
				IL_0547:
				aASEOsofovJSOnzKqWanhdKWhjw(yELADGAuWhMAnmQvkxgchkzhIWFg, 0f, true);
				num = 1272629037;
				continue;
			}
			break;
			IL_05c1:
			int num6;
			if (yELADGAuWhMAnmQvkxgchkzhIWFg.cEGcoyQurZrBBtJXAAqiDVHHbLf)
			{
				num = 1272629012;
				num6 = num;
			}
			else
			{
				num = 1272629053;
				num6 = num;
			}
			continue;
			IL_0233:
			int num7;
			if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
			{
				num = 1272629013;
				num7 = num;
			}
			else
			{
				num = 1272629030;
				num7 = num;
			}
			continue;
			IL_0688:
			int num8;
			if (HihxpSdwPYsIjhCvMYCwBkdxadJ.mouseXYAxisMode == MouseXYAxisMode.Speed)
			{
				num = 1272629018;
				num8 = num;
			}
			else
			{
				num = 1272629025;
				num8 = num;
			}
			continue;
			IL_030a:
			int num9;
			if (yELADGAuWhMAnmQvkxgchkzhIWFg.zZOKcJvuOQCLBInkTSUcrEfEQnB._axisContribution == Pole.Positive)
			{
				num = 1272629019;
				num9 = num;
			}
			else
			{
				num = 1272629029;
				num9 = num;
			}
			continue;
			IL_01f5:
			int num10;
			if (EqecLYyMfUxNkSSXzJjNucbeQLC != AxisCoordinateMode.Absolute)
			{
				num = 1272629024;
				num10 = num;
			}
			else
			{
				num = 1272629031;
				num10 = num;
			}
			continue;
			IL_0211:
			int num11;
			if (HihxpSdwPYsIjhCvMYCwBkdxadJ.mouseXYAxisDeltaCalc != MouseXYAxisDeltaCalc.ScreenWidth)
			{
				num = 1272629035;
				num11 = num;
			}
			else
			{
				num = 1272629010;
				num11 = num;
			}
			continue;
			IL_05dd:
			int num12;
			if ((yELADGAuWhMAnmQvkxgchkzhIWFg.zanoUePzyYulugqVhTLKoWlInDx & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) == 0)
			{
				num = 1272629024;
				num12 = num;
			}
			else
			{
				num = 1272629032;
				num12 = num;
			}
		}
		goto IL_001b;
		IL_0440:
		if (!P_0)
		{
			return;
		}
		goto IL_035e;
		IL_035e:
		if (PNxPCjAmjiDoWHtojoxdKnxPAbRz != hWAnDmuqbaIKpNQdQgNkFhDtLnEn)
		{
			PNxPCjAmjiDoWHtojoxdKnxPAbRz = hWAnDmuqbaIKpNQdQgNkFhDtLnEn;
			num = 1272629021;
			goto IL_0020;
		}
		goto IL_06aa;
	}

	private void eddcKOGndhFTxAZFQITcfAANxOm(YELADGAuWhMAnmQvkxgchkzhIWFg P_0, float P_1)
	{
		float num = P_0.JHgsNLxiAQVnmyfVeWejfTJocIu * P_1;
		if (P_0.VeSusRwFWgIbJtaWRXkHRqlITaT)
		{
			goto IL_0014;
		}
		goto IL_014f;
		IL_0014:
		int num2 = 395555332;
		goto IL_0019;
		IL_0019:
		while (true)
		{
			switch (num2 ^ 0x1793B20E)
			{
			case 0:
				break;
			case 4:
				tUkCddoPDQBtIBhMTTLqJmANEkOm = num;
				ICXwTWoLJYoCGrxbHxaMHxHJCBj = AxisCoordinateMode.Relative;
				num2 = 395555334;
				continue;
			case 1:
				goto IL_006a;
			case 5:
				goto IL_0084;
			case 10:
				if (P_0.dsWWLfdILyJiugOyNuBltGXmmpi != AxisCoordinateMode.Absolute)
				{
					goto case 9;
				}
				if (EqecLYyMfUxNkSSXzJjNucbeQLC == AxisCoordinateMode.Absolute)
				{
					HfZTJykLRzldxCrzDswtFQoNUkd += num;
					num2 = 395555334;
					continue;
				}
				goto default;
			case 9:
				if (P_0.dsWWLfdILyJiugOyNuBltGXmmpi == AxisCoordinateMode.Relative)
				{
					if (EqecLYyMfUxNkSSXzJjNucbeQLC != AxisCoordinateMode.Relative)
					{
						HfZTJykLRzldxCrzDswtFQoNUkd = num;
						EqecLYyMfUxNkSSXzJjNucbeQLC = AxisCoordinateMode.Relative;
						num2 = 395555334;
						continue;
					}
					goto case 2;
				}
				goto default;
			case 6:
				if (ICXwTWoLJYoCGrxbHxaMHxHJCBj == AxisCoordinateMode.Absolute && MathTools.Abs(num) > MathTools.Abs(tUkCddoPDQBtIBhMTTLqJmANEkOm))
				{
					tUkCddoPDQBtIBhMTTLqJmANEkOm = num;
					num2 = 395555334;
					continue;
				}
				goto default;
			case 3:
				if (MathTools.Abs(num) > MathTools.Abs(tUkCddoPDQBtIBhMTTLqJmANEkOm))
				{
					tUkCddoPDQBtIBhMTTLqJmANEkOm = num;
					num2 = 395555334;
					continue;
				}
				goto default;
			case 7:
				goto IL_014f;
			case 2:
				HfZTJykLRzldxCrzDswtFQoNUkd = MathTools.MaxMagnitude(HfZTJykLRzldxCrzDswtFQoNUkd, num);
				num2 = 395555334;
				continue;
			default:
				aASEOsofovJSOnzKqWanhdKWhjw(P_0, HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonDeadZone, false);
				return;
			}
			break;
			IL_0084:
			int num3;
			if (ICXwTWoLJYoCGrxbHxaMHxHJCBj == AxisCoordinateMode.Relative)
			{
				num2 = 395555341;
				num3 = num2;
			}
			else
			{
				num2 = 395555338;
				num3 = num2;
			}
			continue;
			IL_006a:
			int num4;
			if (P_0.dsWWLfdILyJiugOyNuBltGXmmpi != AxisCoordinateMode.Relative)
			{
				num2 = 395555334;
				num4 = num2;
			}
			else
			{
				num2 = 395555339;
				num4 = num2;
			}
		}
		goto IL_0014;
		IL_014f:
		int num5;
		if (P_0.dsWWLfdILyJiugOyNuBltGXmmpi != AxisCoordinateMode.Absolute)
		{
			num2 = 395555343;
			num5 = num2;
		}
		else
		{
			num2 = 395555336;
			num5 = num2;
		}
		goto IL_0019;
	}

	private void aASEOsofovJSOnzKqWanhdKWhjw(YELADGAuWhMAnmQvkxgchkzhIWFg P_0, float P_1, bool P_2)
	{
		FtUOhuKrpcFhMbUykhhakrKdBrJc ftUOhuKrpcFhMbUykhhakrKdBrJc = FtUOhuKrpcFhMbUykhhakrKdBrJc.PewicdxVsQxhCAlIwGlsfgOPLTyg(P_0.zZOKcJvuOQCLBInkTSUcrEfEQnB.rOuBUzbbciWwktcpmiPWpQIKoaAa);
		ButtonStateFlags buttonStateFlags2 = default(ButtonStateFlags);
		ButtonStateFlags buttonStateFlags = default(ButtonStateFlags);
		ButtonStateFlags buttonStateFlags3 = default(ButtonStateFlags);
		while (true)
		{
			int num = -599785698;
			while (true)
			{
				switch (num ^ -599785701)
				{
				case 7:
					break;
				default:
					return;
				case 9:
				{
					int num5;
					if ((buttonStateFlags2 & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) == 0)
					{
						num = -599785703;
						num5 = num;
					}
					else
					{
						num = -599785697;
						num5 = num;
					}
					continue;
				}
				case 4:
					if (P_0.JHgsNLxiAQVnmyfVeWejfTJocIu != 0f)
					{
						xTXnjUEgRpJSoSciGkqIwiYcoiR += (int)(1f * MathTools.Sign(P_0.JHgsNLxiAQVnmyfVeWejfTJocIu));
						ewdHJUWumaxMSrWxgtgHWZCUBVu.fuLKaTfKQpOpktgPzRLpUDfEjf(P_0);
						num = -599785701;
						continue;
					}
					goto case 0;
				case 1:
					ftUOhuKrpcFhMbUykhhakrKdBrJc.qzKInJopZYwlZmElvoCFJWhBqwG(JxkiCllALlOapFhJuteRVKXasok, false);
					num = -599785711;
					continue;
				case 16:
					ftUOhuKrpcFhMbUykhhakrKdBrJc.qzKInJopZYwlZmElvoCFJWhBqwG(JxkiCllALlOapFhJuteRVKXasok, true);
					num = -599785713;
					continue;
				case 13:
				{
					int num2;
					if (P_0.zZOKcJvuOQCLBInkTSUcrEfEQnB._axisContribution != Pole.Positive)
					{
						num = -599785705;
						num2 = num;
					}
					else
					{
						num = -599785719;
						num2 = num;
					}
					continue;
				}
				case 0:
					egsAOrNFIRTqDBlgUNaUcrFVsIT = true;
					num = -599785720;
					continue;
				case 14:
					if (P_2)
					{
						int num7;
						if (P_0.JHgsNLxiAQVnmyfVeWejfTJocIu != 0f)
						{
							num = -599785712;
							num7 = num;
						}
						else
						{
							num = -599785699;
							num7 = num;
						}
						continue;
					}
					return;
				case 15:
				{
					int num4;
					if (P_2)
					{
						num = -599785704;
						num4 = num;
					}
					else
					{
						num = -599785703;
						num4 = num;
					}
					continue;
				}
				case 12:
				{
					int num8;
					if (MathTools.Abs(P_0.JHgsNLxiAQVnmyfVeWejfTJocIu) > P_1)
					{
						num = -599785702;
						num8 = num;
					}
					else
					{
						num = -599785711;
						num8 = num;
					}
					continue;
				}
				case 5:
					if (P_0.zZOKcJvuOQCLBInkTSUcrEfEQnB._axisRange != AxisRange.Full)
					{
						goto case 13;
					}
					if (MathTools.Abs(P_0.JHgsNLxiAQVnmyfVeWejfTJocIu) > P_1)
					{
						ftUOhuKrpcFhMbUykhhakrKdBrJc.qzKInJopZYwlZmElvoCFJWhBqwG(JxkiCllALlOapFhJuteRVKXasok, P_0.JHgsNLxiAQVnmyfVeWejfTJocIu > 0f);
						num = -599785709;
						continue;
					}
					goto case 8;
				case 20:
					buttonStateFlags = ftUOhuKrpcFhMbUykhhakrKdBrJc.wzdZkFvLUDTVacwFNIHOjLkeCrF(true);
					AjQIUTFSzRRIZyxPPAmbfSsdwkT(ref cVwONtxxImBBAJHPLCLcIpmkQjxq, buttonStateFlags);
					num = -599785707;
					continue;
				case 10:
					buttonStateFlags = ftUOhuKrpcFhMbUykhhakrKdBrJc.wzdZkFvLUDTVacwFNIHOjLkeCrF(false);
					AjQIUTFSzRRIZyxPPAmbfSsdwkT(ref TwTlfZOgJjAEgkShVdXEzccWNZhB, buttonStateFlags);
					num = -599785707;
					continue;
				case 3:
				{
					int num6;
					if ((buttonStateFlags3 & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) == 0)
					{
						num = -599785710;
						num6 = num;
					}
					else
					{
						num = -599785697;
						num6 = num;
					}
					continue;
				}
				case 11:
					xTXnjUEgRpJSoSciGkqIwiYcoiR += (int)(1f * MathTools.Sign(P_0.JHgsNLxiAQVnmyfVeWejfTJocIu));
					num = -599785718;
					continue;
				case 18:
				{
					int num3;
					if (P_0.JHgsNLxiAQVnmyfVeWejfTJocIu <= P_1)
					{
						num = -599785713;
						num3 = num;
					}
					else
					{
						num = -599785717;
						num3 = num;
					}
					continue;
				}
				case 17:
					ewdHJUWumaxMSrWxgtgHWZCUBVu.fuLKaTfKQpOpktgPzRLpUDfEjf(P_0);
					num = -599785699;
					continue;
				case 19:
					return;
				case 8:
					buttonStateFlags3 = ftUOhuKrpcFhMbUykhhakrKdBrJc.wzdZkFvLUDTVacwFNIHOjLkeCrF(true);
					buttonStateFlags2 = ftUOhuKrpcFhMbUykhhakrKdBrJc.wzdZkFvLUDTVacwFNIHOjLkeCrF(false);
					AjQIUTFSzRRIZyxPPAmbfSsdwkT(ref cVwONtxxImBBAJHPLCLcIpmkQjxq, buttonStateFlags3);
					AjQIUTFSzRRIZyxPPAmbfSsdwkT(ref TwTlfZOgJjAEgkShVdXEzccWNZhB, buttonStateFlags2);
					num = -599785708;
					continue;
				case 6:
					if ((buttonStateFlags & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) != ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE)
					{
						egsAOrNFIRTqDBlgUNaUcrFVsIT = true;
						num = -599785703;
						continue;
					}
					return;
				case 2:
					return;
				}
				break;
			}
		}
	}

	internal void vwpczpTUhlmFVrpnviNuDtxiWGHg()
	{
		if (htQVBCtMlWHCXynMZqmkAgjSTzF != hWAnDmuqbaIKpNQdQgNkFhDtLnEn)
		{
			WZzGaCOQpfHRhCqLXMXIzBuawBP(false);
			return;
		}
		SKECkQutNYMIhCJMbhLUCEtvhao.JsBUqOgSQSNQZKdIsFDoguUzDqX xbRrcEKKIAKiQkVzQCekOswVHrJ = default(SKECkQutNYMIhCJMbhLUCEtvhao.JsBUqOgSQSNQZKdIsFDoguUzDqX);
		float uNgIpSIDpIOcEEPZAipQgwXwOQn = default(float);
		bool flag = default(bool);
		while (true)
		{
			int num;
			int num2;
			if (XErgmKvbqxuxWNjcDCZkUThgJqU != bdaJzDHyzUjPDoLNWgKikXyIWEb.lAbGsNJnXfmjcYkPrdpDpsjnFLS)
			{
				num = 1933839884;
				num2 = num;
			}
			else
			{
				num = 1933839903;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ 0x73440E1F)
				{
				case 2:
					num = 1933839902;
					continue;
				default:
					return;
				case 13:
					xbRrcEKKIAKiQkVzQCekOswVHrJ.bfqbuDQILhAXVmJmrjkHnCPcegW(kmPAfEKnCyTirEYSWkaOedaLedN(), lvyTpewEByrJQaPpHiuasLSeNzw(), EYuDJVDMraHBZVsAfWxxjYhezKIh(), WvSmeLExuitBNiAVEhCleOWlTFR());
					num = 1933839895;
					continue;
				case 9:
				{
					int num3;
					if (tSmDbKhRjhMcuhzPgFsJmXTjbXYK())
					{
						num = 1933839892;
						num3 = num;
					}
					else
					{
						num = 1933839890;
						num3 = num;
					}
					continue;
				}
				case 4:
					if (tUkCddoPDQBtIBhMTTLqJmANEkOm != 0f)
					{
						xbRrcEKKIAKiQkVzQCekOswVHrJ.UNgIpSIDpIOcEEPZAipQgwXwOQn = tUkCddoPDQBtIBhMTTLqJmANEkOm;
						xbRrcEKKIAKiQkVzQCekOswVHrJ.dsWWLfdILyJiugOyNuBltGXmmpi = ICXwTWoLJYoCGrxbHxaMHxHJCBj;
						num = 1933839896;
						continue;
					}
					goto case 3;
				case 3:
					uNgIpSIDpIOcEEPZAipQgwXwOQn = MathTools.Clamp(HfZTJykLRzldxCrzDswtFQoNUkd, -1f, 1f);
					num = 1933839898;
					continue;
				case 18:
					xbRrcEKKIAKiQkVzQCekOswVHrJ.JcUFwdVnLFzpOkfTmSpdvzlHOz = TwTlfZOgJjAEgkShVdXEzccWNZhB;
					if (BqSxCNcqtnGEUYQKLTosluKbCWv != 0f)
					{
						xbRrcEKKIAKiQkVzQCekOswVHrJ.UNgIpSIDpIOcEEPZAipQgwXwOQn = BqSxCNcqtnGEUYQKLTosluKbCWv;
						xbRrcEKKIAKiQkVzQCekOswVHrJ.dsWWLfdILyJiugOyNuBltGXmmpi = AxisCoordinateMode.Relative;
						num = 1933839887;
						continue;
					}
					goto case 4;
				case 17:
					if (PNxPCjAmjiDoWHtojoxdKnxPAbRz != hWAnDmuqbaIKpNQdQgNkFhDtLnEn && gEdpOQDFgIHMoPAgtBTvFPVPKxn.QQKsKwXkwROfogZthICxghJqBuC())
					{
						WZzGaCOQpfHRhCqLXMXIzBuawBP(true);
						num = 1933839889;
						continue;
					}
					return;
				case 16:
					if (HMNyFKyZGzSdooBygLuNPXBYQAV)
					{
						xbRrcEKKIAKiQkVzQCekOswVHrJ.MiOeMekkkYgPoGSIgxUpgVSfEudK();
						HMNyFKyZGzSdooBygLuNPXBYQAV = false;
						num = 1933839897;
						continue;
					}
					goto case 6;
				case 12:
				{
					int num4;
					if (flag)
					{
						num = 1933839888;
						num4 = num;
					}
					else
					{
						num = 1933839894;
						num4 = num;
					}
					continue;
				}
				case 8:
					if (najTSAvsXJcXISVnkxWGCphYKs)
					{
						pbHlytOvmpZrZuXLvmhtecvyAkw();
						num = 1933839886;
						continue;
					}
					goto case 17;
				case 11:
					xbRrcEKKIAKiQkVzQCekOswVHrJ.NnEeVItInZbdRyUNnBsJMoBUXcf.Start(HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonDownBuffer);
					num = 1933839890;
					continue;
				case 15:
					xbRrcEKKIAKiQkVzQCekOswVHrJ.kFnuVrKAVqTfbKliMfIvrIjmigT.Start(HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonDownBuffer);
					num = 1933839894;
					continue;
				case 7:
					num = 1933839887;
					continue;
				case 10:
					xbRrcEKKIAKiQkVzQCekOswVHrJ.uKlBQSKymMulfuqKqgZPVZpnKKFe(unwgQSnePmeOsXbHPocojQIZGLM);
					if (xbRrcEKKIAKiQkVzQCekOswVHrJ.kFnuVrKAVqTfbKliMfIvrIjmigT != null)
					{
						flag = adErMovFWJpFWRIhDhHQHznepoS();
						num = 1933839891;
						continue;
					}
					goto case 13;
				case 0:
					return;
				case 5:
					xbRrcEKKIAKiQkVzQCekOswVHrJ.UNgIpSIDpIOcEEPZAipQgwXwOQn = uNgIpSIDpIOcEEPZAipQgwXwOQn;
					xbRrcEKKIAKiQkVzQCekOswVHrJ.dsWWLfdILyJiugOyNuBltGXmmpi = EqecLYyMfUxNkSSXzJjNucbeQLC;
					num = 1933839887;
					continue;
				case 19:
					xbRrcEKKIAKiQkVzQCekOswVHrJ = gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ;
					xbRrcEKKIAKiQkVzQCekOswVHrJ.zanoUePzyYulugqVhTLKoWlInDx = cVwONtxxImBBAJHPLCLcIpmkQjxq;
					num = 1933839885;
					continue;
				case 1:
					break;
				case 6:
					OaxjlNmtIiCpKhMvkEDHKotzEJQy();
					num = 1933839893;
					continue;
				case 14:
					return;
				}
				break;
			}
		}
	}

	internal void OaxjlNmtIiCpKhMvkEDHKotzEJQy()
	{
		if (ewdHJUWumaxMSrWxgtgHWZCUBVu.dQXcQJDbmxDlBFIlDXhsTynLjSHE)
		{
			goto IL_0010;
		}
		goto IL_025e;
		IL_0010:
		int num = 2026949923;
		goto IL_0015;
		IL_0015:
		float num5 = default(float);
		float num6 = default(float);
		float num3 = default(float);
		float digitalAxisSensitivity = default(float);
		float num2 = default(float);
		float num4 = default(float);
		while (true)
		{
			switch (num ^ 0x78D0CD34)
			{
			case 0:
				break;
			default:
				return;
			case 24:
			{
				gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc = MathTools.Clamp(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc + num5 * num6, -1f, 1f);
				relHYLHuZaHJcMNiFYaqgcWRfBnm pvTxooprdRDCMXRPzWBtuHmktwn = gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.pvTxooprdRDCMXRPzWBtuHmktwn;
				THfyrqeAKnGTczJUseGrDoJYCOr(pvTxooprdRDCMXRPzWBtuHmktwn.xwApvxwuWEivSrbItjIXHBzMlIz, pvTxooprdRDCMXRPzWBtuHmktwn.NsnpsJhWvVdnFvGpHHimGkwdsno, pvTxooprdRDCMXRPzWBtuHmktwn.zZOKcJvuOQCLBInkTSUcrEfEQnB);
				num = 2026949948;
				continue;
			}
			case 5:
				gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc = MathTools.Clamp(num3, -1f, 1f);
				num = 2026949925;
				continue;
			case 7:
				if (!egsAOrNFIRTqDBlgUNaUcrFVsIT)
				{
					goto IL_0125;
				}
				goto case 3;
			case 8:
				return;
			case 12:
				num3 += gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc;
				num = 2026949937;
				continue;
			case 20:
				gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc = gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.oNOdvUURePKwNGoKnQAvXqJcGIfi;
				num = 2026949926;
				continue;
			case 21:
				num5 = ((gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc > 0f) ? (-1f) : 1f);
				num = 2026949932;
				continue;
			case 13:
				goto IL_01d2;
			case 2:
				num3 += gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc;
				num = 2026949937;
				continue;
			case 19:
				goto IL_0212;
			case 18:
				if (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.pvTxooprdRDCMXRPzWBtuHmktwn.dQXcQJDbmxDlBFIlDXhsTynLjSHE)
				{
					gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.pvTxooprdRDCMXRPzWBtuHmktwn.nympziBLtYDUiPlWNRoEGqbSPfa();
					num = 2026949924;
					continue;
				}
				return;
			case 14:
				goto IL_025e;
			case 15:
				num3 *= digitalAxisSensitivity * FtnAbdJXGXeezDMRWayldslYfCSO;
				num = 2026949938;
				continue;
			case 11:
				gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc = 0f;
				gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.pvTxooprdRDCMXRPzWBtuHmktwn.nympziBLtYDUiPlWNRoEGqbSPfa();
				return;
			case 16:
				return;
			case 6:
				if (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc == 0f)
				{
					goto case 2;
				}
				goto IL_0315;
			case 10:
				goto IL_0332;
			case 22:
				num2 = ((gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc != 0f) ? MathTools.Sign(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc) : 0f);
				num = 2026949936;
				continue;
			case 4:
				goto IL_040d;
			case 23:
				gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.pvTxooprdRDCMXRPzWBtuHmktwn.fuLKaTfKQpOpktgPzRLpUDfEjf(ewdHJUWumaxMSrWxgtgHWZCUBVu);
				num = 2026949946;
				continue;
			case 1:
			case 9:
				goto IL_045c;
			case 3:
				num3 = MathTools.Clamp(xTXnjUEgRpJSoSciGkqIwiYcoiR, -1f, 1f);
				num4 = ((num3 != 0f) ? MathTools.Sign(num3) : 0f);
				num = 2026949922;
				continue;
			case 17:
				return;
			}
			break;
			IL_040d:
			digitalAxisSensitivity = HihxpSdwPYsIjhCvMYCwBkdxadJ.digitalAxisSensitivity;
			int num7;
			if (digitalAxisSensitivity > 0f)
			{
				num = 2026949947;
				num7 = num;
			}
			else
			{
				num = 2026949938;
				num7 = num;
			}
			continue;
			IL_01d2:
			int num8;
			if (!HihxpSdwPYsIjhCvMYCwBkdxadJ.digitalAxisSnap)
			{
				num = 2026949944;
				num8 = num;
			}
			else
			{
				num = 2026949937;
				num8 = num;
			}
			continue;
			IL_0315:
			int num9;
			if (num3 != 0f)
			{
				num = 2026949927;
				num9 = num;
			}
			else
			{
				num = 2026949941;
				num9 = num;
			}
			continue;
			IL_0332:
			float digitalAxisGravity = HihxpSdwPYsIjhCvMYCwBkdxadJ.digitalAxisGravity;
			if (digitalAxisGravity == 0f)
			{
				return;
			}
			num6 = HihxpSdwPYsIjhCvMYCwBkdxadJ.digitalAxisGravity * FtnAbdJXGXeezDMRWayldslYfCSO;
			int num10;
			if (MathTools.Abs(num6) >= MathTools.Abs(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc))
			{
				num = 2026949951;
				num10 = num;
			}
			else
			{
				num = 2026949921;
				num10 = num;
			}
			continue;
			IL_0212:
			if (num4 == num2)
			{
				num = 2026949941;
				continue;
			}
			if (true)
			{
				if (HihxpSdwPYsIjhCvMYCwBkdxadJ.digitalAxisInstantReverse)
				{
					num3 += -1f * gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc;
					num = 2026949937;
					continue;
				}
				goto IL_01d2;
			}
			goto IL_045c;
			IL_0125:
			int num11;
			if (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc == 0f)
			{
				num = 2026949948;
				num11 = num;
			}
			else
			{
				num = 2026949950;
				num11 = num;
			}
			continue;
			IL_045c:
			num3 += gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc;
			num = 2026949937;
		}
		goto IL_0010;
		IL_025e:
		gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.oNOdvUURePKwNGoKnQAvXqJcGIfi = MathTools.Clamp(xTXnjUEgRpJSoSciGkqIwiYcoiR, -1f, 1f);
		int num12;
		if (HihxpSdwPYsIjhCvMYCwBkdxadJ.digitalAxisSimulation)
		{
			num = 2026949939;
			num12 = num;
		}
		else
		{
			num = 2026949920;
			num12 = num;
		}
		goto IL_0015;
	}

	public float gsiPWtFMoYarPDgrBaZqlwGphcI()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return 0f;
		}
		if (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.dsWWLfdILyJiugOyNuBltGXmmpi == AxisCoordinateMode.Relative)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UNgIpSIDpIOcEEPZAipQgwXwOQn;
		}
		return MathTools.MaxMagnitude(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UNgIpSIDpIOcEEPZAipQgwXwOQn, gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc);
	}

	public float OBiksylQWJjQjwhzYenDgZXxIGF()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return 0f;
		}
		if (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ghXMdoMIYNCWktzQaJBXsbIIlaq == AxisCoordinateMode.Relative)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.rrjAzCaNkwtEgTDoRtGrPyDdaSc;
		}
		return MathTools.MaxMagnitude(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.rrjAzCaNkwtEgTDoRtGrPyDdaSc, gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.WPfrrEiRlQPOOXpqEdazwJczvfx);
	}

	public float kHkiELtELGSNYqhHUvcRdAVKOAK()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return 0f;
		}
		return gsiPWtFMoYarPDgrBaZqlwGphcI() - OBiksylQWJjQjwhzYenDgZXxIGF();
	}

	public float bUaYiNmIXdjUJTjiveYBXOsUPPR()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return 0f;
		}
		return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.vAxisTimeActive;
	}

	public float psOpurpDxgftdfKhDDJAvXOrVIiN()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			while (true)
			{
				int num = 369986625;
				while (true)
				{
					switch (num ^ 0x160D8C40)
					{
					case 2:
						break;
					case 1:
						xSEGYfyMbuMQBfiJzulBnmMAfCN();
						num = 369986624;
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
		return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.vAxisTimeInactive;
	}

	public AxisCoordinateMode mHKXpTDrzdaIAFdfieNXajCPOekA()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UNgIpSIDpIOcEEPZAipQgwXwOQn) >= MathTools.Abs(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.KdErjvyFToFoJbJAowlBiYFsfgPc))
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.dsWWLfdILyJiugOyNuBltGXmmpi;
		}
		return AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode KLSupPtdLzGdSilInlpUGGnsXuxv()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.rrjAzCaNkwtEgTDoRtGrPyDdaSc) >= MathTools.Abs(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.WPfrrEiRlQPOOXpqEdazwJczvfx))
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ghXMdoMIYNCWktzQaJBXsbIIlaq;
		}
		return AxisCoordinateMode.Absolute;
	}

	public float pAQaeYoVtoBapeKmsZlYocRkDjMw()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return 0f;
		}
		if (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.dsWWLfdILyJiugOyNuBltGXmmpi == AxisCoordinateMode.Relative)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UNgIpSIDpIOcEEPZAipQgwXwOQn;
		}
		return MathTools.MaxMagnitude(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UNgIpSIDpIOcEEPZAipQgwXwOQn, gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.oNOdvUURePKwNGoKnQAvXqJcGIfi);
	}

	public float qgrhzzkMBnrVfACVsTCkWkpyeIoh()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return 0f;
		}
		if (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ghXMdoMIYNCWktzQaJBXsbIIlaq == AxisCoordinateMode.Relative)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.rrjAzCaNkwtEgTDoRtGrPyDdaSc;
		}
		return MathTools.MaxMagnitude(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.rrjAzCaNkwtEgTDoRtGrPyDdaSc, gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.pTVDRnjYcnQDMNrNAzMmgSXHbaUH);
	}

	public float BrfyKBLVGfxHnFinMTEmvoVfrMJ()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return 0f;
		}
		return pAQaeYoVtoBapeKmsZlYocRkDjMw() - qgrhzzkMBnrVfACVsTCkWkpyeIoh();
	}

	public float mOITPhTjUfqJAAcOZnvmvsEKekb()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return 0f;
		}
		return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.vAxisRawTimeActive;
	}

	public float utiQMiNlOleKIQrxVDjZdOJGPFZ()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			xSEGYfyMbuMQBfiJzulBnmMAfCN();
		}
		return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.vAxisRawTimeInactive;
	}

	public AxisCoordinateMode FUaEIRfNVTsFuwAGCOHfAQOzffEz()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UNgIpSIDpIOcEEPZAipQgwXwOQn) >= MathTools.Abs(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.oNOdvUURePKwNGoKnQAvXqJcGIfi))
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.dsWWLfdILyJiugOyNuBltGXmmpi;
		}
		return AxisCoordinateMode.Absolute;
	}

	public AxisCoordinateMode qwaTTQNPgEqFLYgJOIopoXDFCDDD()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return AxisCoordinateMode.Absolute;
		}
		if (MathTools.Abs(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.rrjAzCaNkwtEgTDoRtGrPyDdaSc) >= MathTools.Abs(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.pTVDRnjYcnQDMNrNAzMmgSXHbaUH))
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ghXMdoMIYNCWktzQaJBXsbIIlaq;
		}
		return AxisCoordinateMode.Absolute;
	}

	public bool lvyTpewEByrJQaPpHiuasLSeNzw()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		if (!nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			return (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.zanoUePzyYulugqVhTLKoWlInDx & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) != 0;
		}
		if ((gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.zanoUePzyYulugqVhTLKoWlInDx & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) == 0)
		{
			return WvSmeLExuitBNiAVEhCleOWlTFR();
		}
		return true;
	}

	public bool kmPAfEKnCyTirEYSWkaOedaLedN()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		if (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.kFnuVrKAVqTfbKliMfIvrIjmigT == null)
		{
			return adErMovFWJpFWRIhDhHQHznepoS();
		}
		if (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.kFnuVrKAVqTfbKliMfIvrIjmigT.running)
		{
			return true;
		}
		if (nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue && gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.NnEeVItInZbdRyUNnBsJMoBUXcf.running)
		{
			return true;
		}
		return false;
	}

	public bool OyXGTSwiLyydixsXoAkXTFGBrMP()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		if (!nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			return (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.zanoUePzyYulugqVhTLKoWlInDx & ButtonStateFlags.wqjwiZOyPZUdbNDdvBGdKmBHhRs) != 0;
		}
		if ((gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.zanoUePzyYulugqVhTLKoWlInDx & ButtonStateFlags.wqjwiZOyPZUdbNDdvBGdKmBHhRs) == 0 && (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.JcUFwdVnLFzpOkfTmSpdvzlHOz & ButtonStateFlags.wqjwiZOyPZUdbNDdvBGdKmBHhRs) == 0)
		{
			return false;
		}
		if ((gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.zanoUePzyYulugqVhTLKoWlInDx & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) != ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE)
		{
			return false;
		}
		if ((gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.JcUFwdVnLFzpOkfTmSpdvzlHOz & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) != ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE)
		{
			return false;
		}
		return true;
	}

	public bool oumQrJVceWMuKcaHRTCQmoJRcBFg()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		if (!nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UDOjpgxxSIgKavxNRARjjzzZwoU.singlePressHold;
		}
		if (!gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UDOjpgxxSIgKavxNRARjjzzZwoU.singlePressHold)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ADfBLWQhSGxJqRogJFrBkbJTJcGS.singlePressHold;
		}
		return true;
	}

	public bool xlSsEefXfNsXbZyirAyfPSKMcTW()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			goto IL_0008;
		}
		int num;
		bool singlePressDown = default(bool);
		bool singlePressDown2 = default(bool);
		if (!nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			num = -38359567;
		}
		else
		{
			singlePressDown = gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UDOjpgxxSIgKavxNRARjjzzZwoU.singlePressDown;
			singlePressDown2 = gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ADfBLWQhSGxJqRogJFrBkbJTJcGS.singlePressDown;
			if (singlePressDown)
			{
				goto IL_003a;
			}
			num = -38359568;
		}
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ -38359566)
			{
			case 0:
				break;
			case 2:
				goto IL_0035;
			case 5:
				goto IL_0063;
			case 4:
				return false;
			case 3:
				return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UDOjpgxxSIgKavxNRARjjzzZwoU.singlePressDown;
			default:
				return false;
			}
			break;
			IL_0063:
			if (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ADfBLWQhSGxJqRogJFrBkbJTJcGS.singlePressHold)
			{
				num = -38359565;
				continue;
			}
			goto IL_00ed;
		}
		goto IL_0008;
		IL_003a:
		if (!singlePressDown && gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UDOjpgxxSIgKavxNRARjjzzZwoU.singlePressHold)
		{
			return false;
		}
		if (!singlePressDown2)
		{
			num = -38359561;
			goto IL_000d;
		}
		goto IL_00ed;
		IL_00ed:
		return true;
		IL_0035:
		if (!singlePressDown2)
		{
			return false;
		}
		goto IL_003a;
		IL_0008:
		num = -38359562;
		goto IL_000d;
	}

	public bool iHwerJAqVfEQSCtTfkIyzFItSBcF()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			goto IL_0008;
		}
		if (!nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UDOjpgxxSIgKavxNRARjjzzZwoU.singlePressUp;
		}
		bool singlePressUp = gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UDOjpgxxSIgKavxNRARjjzzZwoU.singlePressUp;
		bool singlePressUp2 = gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ADfBLWQhSGxJqRogJFrBkbJTJcGS.singlePressUp;
		int num = -1819996838;
		goto IL_000d;
		IL_0008:
		num = -1819996835;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ -1819996834)
			{
			case 0:
				break;
			case 3:
				return false;
			case 4:
				if (!singlePressUp && !singlePressUp2)
				{
					return false;
				}
				if (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UDOjpgxxSIgKavxNRARjjzzZwoU.singlePressHold)
				{
					num = -1819996836;
					continue;
				}
				if (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ADfBLWQhSGxJqRogJFrBkbJTJcGS.singlePressHold)
				{
					num = -1819996833;
					continue;
				}
				return true;
			case 2:
				return false;
			default:
				return false;
			}
			break;
		}
		goto IL_0008;
	}

	public bool khySxihXVeHHtgPjnBNkOYPffuJ()
	{
		return khySxihXVeHHtgPjnBNkOYPffuJ(0f);
	}

	public bool khySxihXVeHHtgPjnBNkOYPffuJ(float P_0)
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		if (P_0 > 0f)
		{
			if (!nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
			{
				return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.kHSCpxEyvnCtiwtxVXpzlQVDWHT.IqTQGnJMxdgjdCDmjEaKjTBjuvfn(P_0);
			}
			if (!gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.kHSCpxEyvnCtiwtxVXpzlQVDWHT.IqTQGnJMxdgjdCDmjEaKjTBjuvfn(P_0))
			{
				return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.hiJKtdXofZGPfjANHYQicuREwaj.IqTQGnJMxdgjdCDmjEaKjTBjuvfn(P_0);
			}
			return true;
		}
		if (!nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UDOjpgxxSIgKavxNRARjjzzZwoU.doublePressHold;
		}
		if (!gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UDOjpgxxSIgKavxNRARjjzzZwoU.doublePressHold)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ADfBLWQhSGxJqRogJFrBkbJTJcGS.doublePressHold;
		}
		return true;
	}

	public bool KVYBArGysOtyKpvWvichEouJUIXn()
	{
		return KVYBArGysOtyKpvWvichEouJUIXn(0f);
	}

	public bool KVYBArGysOtyKpvWvichEouJUIXn(float P_0)
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		if (!kmPAfEKnCyTirEYSWkaOedaLedN())
		{
			goto IL_0012;
		}
		if (!nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			if (P_0 > 0f)
			{
				return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.kHSCpxEyvnCtiwtxVXpzlQVDWHT.IqTQGnJMxdgjdCDmjEaKjTBjuvfn(P_0);
			}
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UDOjpgxxSIgKavxNRARjjzzZwoU.doublePressHold;
		}
		int num;
		if (P_0 > 0f)
		{
			num = -60439449;
			goto IL_0017;
		}
		if (!gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UDOjpgxxSIgKavxNRARjjzzZwoU.doublePressHold)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ADfBLWQhSGxJqRogJFrBkbJTJcGS.doublePressHold;
		}
		return true;
		IL_0012:
		num = -60439452;
		goto IL_0017;
		IL_0017:
		switch (num ^ -60439450)
		{
		case 0:
			break;
		case 2:
			return false;
		default:
			if (!gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.kHSCpxEyvnCtiwtxVXpzlQVDWHT.IqTQGnJMxdgjdCDmjEaKjTBjuvfn(P_0))
			{
				return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.hiJKtdXofZGPfjANHYQicuREwaj.IqTQGnJMxdgjdCDmjEaKjTBjuvfn(P_0);
			}
			return true;
		}
		goto IL_0012;
	}

	public bool FTMCwioxGgIbwHAYvDlTcFPHSAlC()
	{
		return FTMCwioxGgIbwHAYvDlTcFPHSAlC(0f);
	}

	public bool FTMCwioxGgIbwHAYvDlTcFPHSAlC(float P_0)
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			goto IL_0008;
		}
		if (!OyXGTSwiLyydixsXoAkXTFGBrMP())
		{
			return false;
		}
		if (!nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			if (P_0 > 0f)
			{
				return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.kHSCpxEyvnCtiwtxVXpzlQVDWHT.IDsmTsYvsShkgJoOkNxKBilXZrS(P_0);
			}
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UDOjpgxxSIgKavxNRARjjzzZwoU.doublePressUp;
		}
		int num;
		if (P_0 > 0f)
		{
			if (!gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.kHSCpxEyvnCtiwtxVXpzlQVDWHT.IDsmTsYvsShkgJoOkNxKBilXZrS(P_0))
			{
				num = 1331284664;
				goto IL_000d;
			}
			return true;
		}
		if (!gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.UDOjpgxxSIgKavxNRARjjzzZwoU.doublePressUp)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ADfBLWQhSGxJqRogJFrBkbJTJcGS.doublePressUp;
		}
		return true;
		IL_0008:
		num = 1331284667;
		goto IL_000d;
		IL_000d:
		switch (num ^ 0x4F59CAB9)
		{
		case 0:
			break;
		case 2:
			return false;
		default:
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.hiJKtdXofZGPfjANHYQicuREwaj.IDsmTsYvsShkgJoOkNxKBilXZrS(P_0);
		}
		goto IL_0008;
	}

	public bool wxklcERvuaELJtrzqLHaclhYEDjd(float P_0)
	{
		return wxklcERvuaELJtrzqLHaclhYEDjd(P_0, 0f);
	}

	public bool wxklcERvuaELJtrzqLHaclhYEDjd(float P_0, float P_1)
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
			goto IL_0019;
		}
		goto IL_0037;
		IL_007c:
		float num = default(float);
		if (num < P_0)
		{
			return false;
		}
		if (P_1 > 0f && num >= P_0 + P_1)
		{
			return false;
		}
		return true;
		IL_0037:
		if (!lvyTpewEByrJQaPpHiuasLSeNzw())
		{
			return false;
		}
		num = gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.vButtonTimePressed;
		int num2;
		if (nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			num = MathTools.Max(num, gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.negativeVButtonTimePressed);
			num2 = -141706006;
			goto IL_001e;
		}
		goto IL_007c;
		IL_0019:
		num2 = -141706005;
		goto IL_001e;
		IL_001e:
		switch (num2 ^ -141706006)
		{
		case 2:
			break;
		case 1:
			goto IL_0037;
		default:
			goto IL_007c;
		}
		goto IL_0019;
	}

	public bool gXOEjzDoUrBmGKJUrFSCuhWtwuYK(float P_0)
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		if (P_0 <= 0f)
		{
			return adErMovFWJpFWRIhDhHQHznepoS();
		}
		if (!lvyTpewEByrJQaPpHiuasLSeNzw())
		{
			return false;
		}
		int num;
		ButtonStateRecorder hiJKtdXofZGPfjANHYQicuREwaj = default(ButtonStateRecorder);
		if (!nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			ButtonStateRecorder kHSCpxEyvnCtiwtxVXpzlQVDWHT = gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.kHSCpxEyvnCtiwtxVXpzlQVDWHT;
			if (kHSCpxEyvnCtiwtxVXpzlQVDWHT.timePressed < P_0)
			{
				goto IL_0049;
			}
			if (!(ReInput.unscaledTimePrev - kHSCpxEyvnCtiwtxVXpzlQVDWHT.lastTimeUnpressed >= P_0))
			{
				return true;
			}
			num = 1906185199;
		}
		else
		{
			ButtonStateRecorder kHSCpxEyvnCtiwtxVXpzlQVDWHT2 = gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.kHSCpxEyvnCtiwtxVXpzlQVDWHT;
			hiJKtdXofZGPfjANHYQicuREwaj = gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.hiJKtdXofZGPfjANHYQicuREwaj;
			if (kHSCpxEyvnCtiwtxVXpzlQVDWHT2.timePressed < P_0 && hiJKtdXofZGPfjANHYQicuREwaj.timePressed < P_0)
			{
				return false;
			}
			int num2;
			if (!(ReInput.unscaledTimePrev - kHSCpxEyvnCtiwtxVXpzlQVDWHT2.lastTimeUnpressed < P_0))
			{
				num = 1906185194;
				num2 = num;
			}
			else
			{
				num = 1906185197;
				num2 = num;
			}
		}
		goto IL_004e;
		IL_004e:
		while (true)
		{
			switch (num ^ 0x719E13EE)
			{
			case 0:
				break;
			case 2:
				return false;
			case 1:
				return false;
			case 3:
				if (ReInput.unscaledTimePrev - hiJKtdXofZGPfjANHYQicuREwaj.lastTimeUnpressed >= P_0)
				{
					goto IL_00f6;
				}
				return true;
			default:
				return false;
			}
			break;
			IL_00f6:
			num = 1906185194;
		}
		goto IL_0049;
		IL_0049:
		num = 1906185196;
		goto IL_004e;
	}

	public bool dVFrovmlIiHHPqBCNJnHYplrEkef(float P_0)
	{
		return dVFrovmlIiHHPqBCNJnHYplrEkef(P_0, 0f);
	}

	public bool dVFrovmlIiHHPqBCNJnHYplrEkef(float P_0, float P_1)
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
			goto IL_001c;
		}
		goto IL_00e0;
		IL_012f:
		return true;
		IL_00e0:
		if (!OyXGTSwiLyydixsXoAkXTFGBrMP())
		{
			return false;
		}
		float num = default(float);
		int num2;
		if (nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			num = ReInput.unscaledTime - MathTools.Max(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.kHSCpxEyvnCtiwtxVXpzlQVDWHT.lastTimeStateChangedToPressed, gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.hiJKtdXofZGPfjANHYQicuREwaj.lastTimeStateChangedToPressed);
			if (num < P_0)
			{
				return false;
			}
			if (!(P_1 > 0f))
			{
				goto IL_012f;
			}
			num2 = -542392268;
		}
		else
		{
			num2 = -542392266;
		}
		goto IL_0021;
		IL_001c:
		num2 = -542392267;
		goto IL_0021;
		IL_0021:
		float num3 = default(float);
		while (true)
		{
			switch (num2 ^ -542392265)
			{
			case 5:
				break;
			case 6:
				return false;
			case 1:
				goto IL_00a6;
			case 3:
				goto IL_00d0;
			case 2:
				goto IL_00e0;
			case 0:
				return false;
			case 7:
				goto IL_011a;
			default:
				return false;
			}
			break;
			IL_011a:
			if (num3 >= P_0 + P_1)
			{
				num2 = -542392271;
				continue;
			}
			goto IL_0053;
			IL_00a6:
			num3 = ReInput.unscaledTime - gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.kHSCpxEyvnCtiwtxVXpzlQVDWHT.lastTimeStateChangedToPressed;
			if (num3 < P_0)
			{
				num2 = -542392265;
				continue;
			}
			if (P_1 > 0f)
			{
				num2 = -542392272;
				continue;
			}
			goto IL_0053;
			IL_00d0:
			if (num >= P_0 + P_1)
			{
				num2 = -542392269;
				continue;
			}
			goto IL_012f;
			IL_0053:
			return true;
		}
		goto IL_001c;
	}

	public bool dJmBEWIMgftsPBEHqbpmuIkQYJxk()
	{
		return wxklcERvuaELJtrzqLHaclhYEDjd(HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonShortPressTime, HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonShortPressExpiresIn);
	}

	public bool oCihxYaxpocUbbxviEHrhZuUjztL()
	{
		return gXOEjzDoUrBmGKJUrFSCuhWtwuYK(HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonShortPressTime);
	}

	public bool SkODxaakXeCDpheFdlLpOtdzPNBu()
	{
		return dVFrovmlIiHHPqBCNJnHYplrEkef(HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonShortPressTime, HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonShortPressExpiresIn);
	}

	public bool lTpGWRDldJqfUaMTglYKLAkbshOG()
	{
		return wxklcERvuaELJtrzqLHaclhYEDjd(HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonLongPressTime, HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonLongPressExpiresIn);
	}

	public bool ssrFVmHAOuxfRJhWgmeRXJABOcY()
	{
		return gXOEjzDoUrBmGKJUrFSCuhWtwuYK(HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonLongPressTime);
	}

	public bool sMcCvPBnIygOxQxPIOLBFgBkKtzz()
	{
		return dVFrovmlIiHHPqBCNJnHYplrEkef(HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonLongPressTime, HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonLongPressExpiresIn);
	}

	public bool XMuJsoWGwkdqfiGJyXqPtcfjmlP()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		if (!nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.WWifMHMFueYRJbVhHxFvlYMKHDC.state;
		}
		if (!gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.WWifMHMFueYRJbVhHxFvlYMKHDC.state)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.YcBlJeAfzxoZjTMQfjitNvDnGIN.state;
		}
		return true;
	}

	public bool tInrXBfJiKwsRBkSagZTLPBXVbJ()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		if (!nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			return (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.CVSgRsXNUHlgVjnztwMxuTjlNwo & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) != 0;
		}
		if ((gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.CVSgRsXNUHlgVjnztwMxuTjlNwo & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) == 0)
		{
			return BlgxYmcQCnviNYPYAGDfxudXrYl();
		}
		return true;
	}

	public float SavYoOxADmATHGxsSrTLDxkRgDY()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return 0f;
		}
		if (!nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.vButtonTimePressed;
		}
		return MathTools.Max(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.vButtonTimePressed, gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.negativeVButtonTimePressed);
	}

	public float essNSlXgTdhzXVlZtlOOJFAnNtj()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			goto IL_0008;
		}
		goto IL_0037;
		IL_0008:
		int num = 1300258844;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x4D80601D)
			{
			case 0:
				break;
			case 1:
				xSEGYfyMbuMQBfiJzulBnmMAfCN();
				num = 1300258846;
				continue;
			case 3:
				goto IL_0037;
			default:
				return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.vButtonTimeUnpressed;
			}
			break;
		}
		goto IL_0008;
		IL_0037:
		if (!nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			num = 1300258847;
			goto IL_000d;
		}
		return MathTools.Min(gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.vButtonTimeUnpressed, gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.negativeVButtonTimeUnpressed);
	}

	private bool adErMovFWJpFWRIhDhHQHznepoS()
	{
		if (!nsJgCtIfwJQZurQxCSnuqEVGIyJc.activateActionButtonsOnNegativeValue)
		{
			return (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.zanoUePzyYulugqVhTLKoWlInDx & ButtonStateFlags.FRjFpveoAfCIfdseBZyzcnsVzsPH) != 0;
		}
		if ((gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.zanoUePzyYulugqVhTLKoWlInDx & ButtonStateFlags.FRjFpveoAfCIfdseBZyzcnsVzsPH) == 0 && (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.JcUFwdVnLFzpOkfTmSpdvzlHOz & ButtonStateFlags.FRjFpveoAfCIfdseBZyzcnsVzsPH) == 0)
		{
			goto IL_004d;
		}
		int num;
		if ((gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.zanoUePzyYulugqVhTLKoWlInDx & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) != ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE)
		{
			num = 864648005;
			goto IL_0052;
		}
		goto IL_009e;
		IL_0052:
		switch (num ^ 0x33897B47)
		{
		case 0:
			break;
		case 1:
			return false;
		default:
			goto IL_0088;
		}
		goto IL_004d;
		IL_0088:
		if ((gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.zanoUePzyYulugqVhTLKoWlInDx & ButtonStateFlags.FRjFpveoAfCIfdseBZyzcnsVzsPH) == 0)
		{
			return false;
		}
		goto IL_009e;
		IL_004d:
		num = 864648006;
		goto IL_0052;
		IL_009e:
		if ((gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.JcUFwdVnLFzpOkfTmSpdvzlHOz & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) != ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE && (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.JcUFwdVnLFzpOkfTmSpdvzlHOz & ButtonStateFlags.FRjFpveoAfCIfdseBZyzcnsVzsPH) == 0)
		{
			return false;
		}
		return true;
	}

	public bool WvSmeLExuitBNiAVEhCleOWlTFR()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		return (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.JcUFwdVnLFzpOkfTmSpdvzlHOz & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) != 0;
	}

	public bool EYuDJVDMraHBZVsAfWxxjYhezKIh()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			goto IL_0008;
		}
		if (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.NnEeVItInZbdRyUNnBsJMoBUXcf == null)
		{
			return tSmDbKhRjhMcuhzPgFsJmXTjbXYK();
		}
		int num;
		if (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.NnEeVItInZbdRyUNnBsJMoBUXcf.running)
		{
			num = 65218994;
			goto IL_000d;
		}
		return false;
		IL_000d:
		switch (num ^ 0x3E329B2)
		{
		case 2:
			break;
		case 1:
			return false;
		default:
			return true;
		}
		goto IL_0008;
		IL_0008:
		num = 65218995;
		goto IL_000d;
	}

	public bool RvVOlcFiiUoCnzwclOyOUWFywkR()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		return (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.JcUFwdVnLFzpOkfTmSpdvzlHOz & ButtonStateFlags.wqjwiZOyPZUdbNDdvBGdKmBHhRs) != 0;
	}

	public bool QCBwuzrcxibRyGfWCxMmKFAWaMD()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ADfBLWQhSGxJqRogJFrBkbJTJcGS.singlePressHold;
	}

	public bool HuWvifqevXgZvJHwwFePyKBJRSJ()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ADfBLWQhSGxJqRogJFrBkbJTJcGS.singlePressDown;
	}

	public bool fIhcEUGPpnDDBjOfPoKpwrBwGZXP()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ADfBLWQhSGxJqRogJFrBkbJTJcGS.singlePressUp;
	}

	public bool KZjyNrTKNgHQOrbmJvBAPWMRDOy()
	{
		return KZjyNrTKNgHQOrbmJvBAPWMRDOy(0f);
	}

	public bool KZjyNrTKNgHQOrbmJvBAPWMRDOy(float P_0)
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.hiJKtdXofZGPfjANHYQicuREwaj.IqTQGnJMxdgjdCDmjEaKjTBjuvfn(P_0);
		}
		return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ADfBLWQhSGxJqRogJFrBkbJTJcGS.doublePressHold;
	}

	public bool OrCBIqmjbhyTOgyyigLkLYAFQHD()
	{
		return OrCBIqmjbhyTOgyyigLkLYAFQHD(0f);
	}

	public bool OrCBIqmjbhyTOgyyigLkLYAFQHD(float P_0)
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			goto IL_0008;
		}
		int num;
		if (!EYuDJVDMraHBZVsAfWxxjYhezKIh())
		{
			num = 884105161;
		}
		else
		{
			if (!(P_0 > 0f))
			{
				return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ADfBLWQhSGxJqRogJFrBkbJTJcGS.doublePressHold;
			}
			num = 884105162;
		}
		goto IL_000d;
		IL_000d:
		switch (num ^ 0x34B25FC9)
		{
		case 2:
			break;
		case 1:
			return false;
		case 0:
			return false;
		default:
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.hiJKtdXofZGPfjANHYQicuREwaj.IqTQGnJMxdgjdCDmjEaKjTBjuvfn(P_0);
		}
		goto IL_0008;
		IL_0008:
		num = 884105160;
		goto IL_000d;
	}

	public bool ydVhKMKFAjcRDuehjQcVWBjVngj()
	{
		return ydVhKMKFAjcRDuehjQcVWBjVngj(0f);
	}

	public bool ydVhKMKFAjcRDuehjQcVWBjVngj(float P_0)
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		if (!RvVOlcFiiUoCnzwclOyOUWFywkR())
		{
			return false;
		}
		if (P_0 > 0f)
		{
			return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.hiJKtdXofZGPfjANHYQicuREwaj.IDsmTsYvsShkgJoOkNxKBilXZrS(P_0);
		}
		return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.ADfBLWQhSGxJqRogJFrBkbJTJcGS.doublePressUp;
	}

	public bool rZebOrKydgpDEirkUXGZClPDYFE(float P_0)
	{
		return rZebOrKydgpDEirkUXGZClPDYFE(P_0, 0f);
	}

	public bool rZebOrKydgpDEirkUXGZClPDYFE(float P_0, float P_1)
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		if (P_0 < 0f)
		{
			P_0 = 0f;
			goto IL_0019;
		}
		goto IL_003b;
		IL_003b:
		if (!WvSmeLExuitBNiAVEhCleOWlTFR())
		{
			return false;
		}
		float negativeVButtonTimePressed = gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.negativeVButtonTimePressed;
		int num;
		if (negativeVButtonTimePressed < P_0)
		{
			num = 1263540181;
		}
		else
		{
			if (!(P_1 > 0f) || !(negativeVButtonTimePressed >= P_0 + P_1))
			{
				return true;
			}
			num = 1263540182;
		}
		goto IL_001e;
		IL_001e:
		switch (num ^ 0x4B5017D6)
		{
		case 2:
			break;
		case 1:
			goto IL_003b;
		case 3:
			return false;
		default:
			return false;
		}
		goto IL_0019;
		IL_0019:
		num = 1263540183;
		goto IL_001e;
	}

	public bool SFiwEaJijuQchcXlQFVdLdqbCFZ(float P_0)
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		if (P_0 <= 0f)
		{
			return tSmDbKhRjhMcuhzPgFsJmXTjbXYK();
		}
		if (!WvSmeLExuitBNiAVEhCleOWlTFR())
		{
			return false;
		}
		ButtonStateRecorder hiJKtdXofZGPfjANHYQicuREwaj = gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.hiJKtdXofZGPfjANHYQicuREwaj;
		if (hiJKtdXofZGPfjANHYQicuREwaj.timePressed < P_0)
		{
			return false;
		}
		if (ReInput.unscaledTimePrev - hiJKtdXofZGPfjANHYQicuREwaj.lastTimeUnpressed >= P_0)
		{
			return false;
		}
		return true;
	}

	public bool HCqzYczWwBrILaUmphxfNZWkmkt(float P_0)
	{
		return HCqzYczWwBrILaUmphxfNZWkmkt(P_0, 0f);
	}

	public bool HCqzYczWwBrILaUmphxfNZWkmkt(float P_0, float P_1)
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			goto IL_0008;
		}
		int num;
		if (P_0 < 0f)
		{
			P_0 = 0f;
			num = 1542111374;
			goto IL_000d;
		}
		goto IL_0053;
		IL_0053:
		if (!RvVOlcFiiUoCnzwclOyOUWFywkR())
		{
			return false;
		}
		float num2 = ReInput.unscaledTime - gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.hiJKtdXofZGPfjANHYQicuREwaj.lastTimeStateChangedToPressed;
		if (num2 < P_0)
		{
			return false;
		}
		if (P_1 > 0f)
		{
			num = 1542111371;
			goto IL_000d;
		}
		goto IL_0093;
		IL_0093:
		return true;
		IL_0008:
		num = 1542111368;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x5BEAC08A)
			{
			case 0:
				break;
			case 2:
				return false;
			case 1:
				goto IL_0046;
			case 4:
				goto IL_0053;
			default:
				return false;
			}
			break;
			IL_0046:
			if (num2 >= P_0 + P_1)
			{
				num = 1542111369;
				continue;
			}
			goto IL_0093;
		}
		goto IL_0008;
	}

	public bool TyRKchCmgGezpurjlGIlwHyhCqPF()
	{
		return rZebOrKydgpDEirkUXGZClPDYFE(HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonShortPressTime, HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonShortPressExpiresIn);
	}

	public bool atJfdtVakiPTsxMWLswiHzqhnXh()
	{
		return SFiwEaJijuQchcXlQFVdLdqbCFZ(HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonShortPressTime);
	}

	public bool pcuMeEWadAiOMfhHbUSXCfHyYbGq()
	{
		return HCqzYczWwBrILaUmphxfNZWkmkt(HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonShortPressTime, HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonShortPressExpiresIn);
	}

	public bool sZjovgfYuOueYRjHKfaxPMBhEtfH()
	{
		return rZebOrKydgpDEirkUXGZClPDYFE(HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonLongPressTime, HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonLongPressExpiresIn);
	}

	public bool hWPFdJhnxwiqIMvmzcJTtrGXBwxy()
	{
		return SFiwEaJijuQchcXlQFVdLdqbCFZ(HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonLongPressTime);
	}

	public bool zAIHmYaXXkGasjpkiIupayFWwSbZ()
	{
		return HCqzYczWwBrILaUmphxfNZWkmkt(HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonLongPressTime, HihxpSdwPYsIjhCvMYCwBkdxadJ.buttonLongPressExpiresIn);
	}

	public bool PHyBYFIwgNChoJCUNazGaNwOIWH()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.YcBlJeAfzxoZjTMQfjitNvDnGIN.state;
	}

	public bool BlgxYmcQCnviNYPYAGDfxudXrYl()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return false;
		}
		return (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.EAzdfySBcYVdKgYEfqVxvdbeOHF & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) != 0;
	}

	public float tbxdrfiVMdWdyMEVJLnEzUAKcPdx()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			return 0f;
		}
		return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.negativeVButtonTimePressed;
	}

	public float xKMTiqFxsOOiwbjIEqDjBXbdlGs()
	{
		if (!mFczoEbROoNOTHHEQCmVfUMtAPcv)
		{
			xSEGYfyMbuMQBfiJzulBnmMAfCN();
		}
		return gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.negativeVButtonTimeUnpressed;
	}

	private bool tSmDbKhRjhMcuhzPgFsJmXTjbXYK()
	{
		return (gEdpOQDFgIHMoPAgtBTvFPVPKxn.xbRrcEKKIAKiQkVzQCekOswVHrJ.JcUFwdVnLFzpOkfTmSpdvzlHOz & ButtonStateFlags.FRjFpveoAfCIfdseBZyzcnsVzsPH) != 0;
	}

	public void lktbLjWKzWZzxPrrKTGBRQYnyBY()
	{
		int num = 0;
		while (num < gEdpOQDFgIHMoPAgtBTvFPVPKxn.gRSZlsGnOMePzdfqhIobycvdjXwm.Length)
		{
			while (true)
			{
				gEdpOQDFgIHMoPAgtBTvFPVPKxn.gRSZlsGnOMePzdfqhIobycvdjXwm[num].kFnuVrKAVqTfbKliMfIvrIjmigT.Clear();
				gEdpOQDFgIHMoPAgtBTvFPVPKxn.gRSZlsGnOMePzdfqhIobycvdjXwm[num].NnEeVItInZbdRyUNnBsJMoBUXcf.Clear();
				num++;
				int num2 = -466403972;
				while (true)
				{
					switch (num2 ^ -466403971)
					{
					case 0:
						num2 = -466403969;
						continue;
					case 2:
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

	internal InputActionEventData VrHXatCSddrmDMPxCSZACUOmCqR(UpdateLoopType P_0)
	{
		return new InputActionEventData(this, iueDnAHVXVmEMnNCzSowjkddzOFv, mecAvOSCkKTUzDMSKLpGqHuOJBZ, P_0);
	}

	public IList<InputActionSourceData> UleOkOGoxWEVCKRDCDLucxkKCqxs()
	{
		if (!najTSAvsXJcXISVnkxWGCphYKs)
		{
			pbHlytOvmpZrZuXLvmhtecvyAkw();
		}
		return dCupHXIvzUnqbIifHJeyoBWtAEl;
	}

	public bool eeTsKlpHADAPFlgMBcwMEGTPLwjj(ControllerType P_0)
	{
		if (!najTSAvsXJcXISVnkxWGCphYKs)
		{
			UleOkOGoxWEVCKRDCDLucxkKCqxs();
			goto IL_000f;
		}
		goto IL_0031;
		IL_0031:
		int num = 0;
		int num2 = 154327472;
		goto IL_0014;
		IL_000f:
		num2 = 154327475;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num2 ^ 0x932D9B1)
			{
			case 0:
				break;
			case 2:
				goto IL_0031;
			case 3:
				goto IL_003a;
			default:
				if (num >= ErmHUMGOYeMsbkUnQOSWpCCsoJi)
				{
					return false;
				}
				goto IL_003a;
			}
			break;
			IL_003a:
			if (baFoVhGTvsLmOqRnADIvIDxcUTJ[num].xwApvxwuWEivSrbItjIXHBzMlIz.type == P_0)
			{
				return true;
			}
			num++;
			num2 = 154327472;
		}
		goto IL_000f;
	}

	public bool eeTsKlpHADAPFlgMBcwMEGTPLwjj(ControllerType P_0, int P_1)
	{
		if (!najTSAvsXJcXISVnkxWGCphYKs)
		{
			UleOkOGoxWEVCKRDCDLucxkKCqxs();
			goto IL_000f;
		}
		goto IL_0035;
		IL_0035:
		int num = 0;
		int num2 = 1069432400;
		goto IL_0014;
		IL_000f:
		num2 = 1069432405;
		goto IL_0014;
		IL_0014:
		Controller xwApvxwuWEivSrbItjIXHBzMlIz = default(Controller);
		while (true)
		{
			switch (num2 ^ 0x3FBE3E51)
			{
			case 2:
				break;
			case 4:
				goto IL_0035;
			case 3:
				goto IL_003e;
			case 0:
				goto IL_005c;
			default:
				if (num >= ErmHUMGOYeMsbkUnQOSWpCCsoJi)
				{
					return false;
				}
				goto IL_003e;
			}
			break;
			IL_005c:
			if (xwApvxwuWEivSrbItjIXHBzMlIz.id == P_1)
			{
				return true;
			}
			goto IL_0067;
			IL_0067:
			num++;
			num2 = 1069432400;
			continue;
			IL_003e:
			xwApvxwuWEivSrbItjIXHBzMlIz = baFoVhGTvsLmOqRnADIvIDxcUTJ[num].xwApvxwuWEivSrbItjIXHBzMlIz;
			if (xwApvxwuWEivSrbItjIXHBzMlIz.type == P_0)
			{
				num2 = 1069432401;
				continue;
			}
			goto IL_0067;
		}
		goto IL_000f;
	}

	public bool eeTsKlpHADAPFlgMBcwMEGTPLwjj(Controller P_0)
	{
		if (!najTSAvsXJcXISVnkxWGCphYKs)
		{
			UleOkOGoxWEVCKRDCDLucxkKCqxs();
			goto IL_000f;
		}
		goto IL_0059;
		IL_0059:
		int num = 0;
		int num2 = 1111989323;
		goto IL_0014;
		IL_000f:
		num2 = 1111989320;
		goto IL_0014;
		IL_0014:
		while (true)
		{
			switch (num2 ^ 0x42479C49)
			{
			case 3:
				break;
			case 4:
				return true;
			case 0:
				goto IL_0042;
			case 1:
				goto IL_0059;
			default:
				if (num >= ErmHUMGOYeMsbkUnQOSWpCCsoJi)
				{
					return false;
				}
				goto IL_0042;
			}
			break;
			IL_0042:
			if (baFoVhGTvsLmOqRnADIvIDxcUTJ[num].xwApvxwuWEivSrbItjIXHBzMlIz != P_0)
			{
				num++;
				num2 = 1111989323;
			}
			else
			{
				num2 = 1111989325;
			}
		}
		goto IL_000f;
	}

	internal void EEGiMNPSMElaPgKQdmScoWLedfb()
	{
		gEdpOQDFgIHMoPAgtBTvFPVPKxn.EEGiMNPSMElaPgKQdmScoWLedfb();
	}

	private void NkZydDENmorvpVrmCVfsQnRvDxL()
	{
		if (yBvowLMzNQNCiJpkoUVXscczfGf == bdaJzDHyzUjPDoLNWgKikXyIWEb.oUspIGvJppSFjIPHXDCBiuVNAUZ)
		{
			HMNyFKyZGzSdooBygLuNPXBYQAV = true;
			goto IL_0010;
		}
		goto IL_002e;
		IL_002e:
		XErgmKvbqxuxWNjcDCZkUThgJqU = bdaJzDHyzUjPDoLNWgKikXyIWEb.DmJaGFbqcvRxiLlVWnXGTCZKbEXN;
		mFczoEbROoNOTHHEQCmVfUMtAPcv = true;
		int num = -150495492;
		goto IL_0015;
		IL_0010:
		num = -150495489;
		goto IL_0015;
		IL_0015:
		switch (num ^ -150495490)
		{
		case 0:
			break;
		default:
			return;
		case 1:
			goto IL_002e;
		case 2:
			return;
		}
		goto IL_0010;
	}

	private void WZzGaCOQpfHRhCqLXMXIzBuawBP(bool P_0)
	{
		gEdpOQDFgIHMoPAgtBTvFPVPKxn.WZzGaCOQpfHRhCqLXMXIzBuawBP();
		if (ErmHUMGOYeMsbkUnQOSWpCCsoJi > 0)
		{
			goto IL_0014;
		}
		goto IL_0043;
		IL_0014:
		int num = 106449492;
		goto IL_0019;
		IL_0019:
		while (true)
		{
			switch (num ^ 0x6584A56)
			{
			case 3:
				break;
			case 2:
				WNwrBesGBycPmBudREqfyBUOyQC();
				num = 106449495;
				continue;
			case 1:
				goto IL_0043;
			default:
				mFczoEbROoNOTHHEQCmVfUMtAPcv = false;
				return;
			}
			break;
		}
		goto IL_0014;
		IL_0043:
		XErgmKvbqxuxWNjcDCZkUThgJqU = (P_0 ? bdaJzDHyzUjPDoLNWgKikXyIWEb.lAbGsNJnXfmjcYkPrdpDpsjnFLS : bdaJzDHyzUjPDoLNWgKikXyIWEb.oUspIGvJppSFjIPHXDCBiuVNAUZ);
		num = 106449494;
		goto IL_0019;
	}

	private void xSEGYfyMbuMQBfiJzulBnmMAfCN()
	{
		gEdpOQDFgIHMoPAgtBTvFPVPKxn.updateLoop = JxkiCllALlOapFhJuteRVKXasok;
	}

	private void WNwrBesGBycPmBudREqfyBUOyQC()
	{
		ErmHUMGOYeMsbkUnQOSWpCCsoJi = 0;
		if (najTSAvsXJcXISVnkxWGCphYKs)
		{
			SGicgFcJrXWPtFAfvaRnglZjQoYs.Clear();
		}
	}

	private void THfyrqeAKnGTczJUseGrDoJYCOr(Controller P_0, ControllerMap P_1, ActionElementMap P_2)
	{
		if (ErmHUMGOYeMsbkUnQOSWpCCsoJi + 1 > baFoVhGTvsLmOqRnADIvIDxcUTJ.Length)
		{
			YgfJYoYnipRnFORRCDieeSSDMtGC();
		}
		relHYLHuZaHJcMNiFYaqgcWRfBnm relHYLHuZaHJcMNiFYaqgcWRfBnm2 = baFoVhGTvsLmOqRnADIvIDxcUTJ[ErmHUMGOYeMsbkUnQOSWpCCsoJi];
		relHYLHuZaHJcMNiFYaqgcWRfBnm2.dQXcQJDbmxDlBFIlDXhsTynLjSHE = true;
		relHYLHuZaHJcMNiFYaqgcWRfBnm2.xwApvxwuWEivSrbItjIXHBzMlIz = P_0;
		relHYLHuZaHJcMNiFYaqgcWRfBnm2.NsnpsJhWvVdnFvGpHHimGkwdsno = P_1;
		relHYLHuZaHJcMNiFYaqgcWRfBnm2.zZOKcJvuOQCLBInkTSUcrEfEQnB = P_2;
		ErmHUMGOYeMsbkUnQOSWpCCsoJi++;
	}

	private void YgfJYoYnipRnFORRCDieeSSDMtGC()
	{
		ArrayTools.Expand(ref baFoVhGTvsLmOqRnADIvIDxcUTJ, 4);
		int num3 = default(int);
		int num2 = default(int);
		while (true)
		{
			int num = -473810154;
			while (true)
			{
				switch (num ^ -473810155)
				{
				case 0:
					break;
				case 3:
					num3 = ErmHUMGOYeMsbkUnQOSWpCCsoJi + 4;
					num2 = ErmHUMGOYeMsbkUnQOSWpCCsoJi;
					num = -473810153;
					continue;
				case 1:
					baFoVhGTvsLmOqRnADIvIDxcUTJ[num2] = new relHYLHuZaHJcMNiFYaqgcWRfBnm();
					num2++;
					num = -473810153;
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

	private void pbHlytOvmpZrZuXLvmhtecvyAkw()
	{
		if (!najTSAvsXJcXISVnkxWGCphYKs)
		{
			goto IL_000b;
		}
		goto IL_008b;
		IL_000b:
		int num = 1513681204;
		goto IL_0010;
		IL_0010:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x5A38F130)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				num2++;
				num = 1513681206;
				continue;
			case 6:
				goto IL_0044;
			case 4:
				najTSAvsXJcXISVnkxWGCphYKs = true;
				num = 1513681200;
				continue;
			case 2:
				SGicgFcJrXWPtFAfvaRnglZjQoYs.Add(new InputActionSourceData(baFoVhGTvsLmOqRnADIvIDxcUTJ[num2]));
				num = 1513681201;
				continue;
			case 0:
				goto IL_008b;
			case 5:
				return;
			}
			break;
			IL_0044:
			int num3;
			if (num2 < ErmHUMGOYeMsbkUnQOSWpCCsoJi)
			{
				num = 1513681202;
				num3 = num;
			}
			else
			{
				num = 1513681205;
				num3 = num;
			}
		}
		goto IL_000b;
		IL_008b:
		num2 = 0;
		num = 1513681206;
		goto IL_0010;
	}

	private static void AjQIUTFSzRRIZyxPPAmbfSsdwkT(ref ButtonStateFlags P_0, ButtonStateFlags P_1)
	{
		if (P_0 == ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE)
		{
			P_0 = P_1;
			return;
		}
		while (true)
		{
			IL_0056:
			if ((P_1 & ButtonStateFlags.FRjFpveoAfCIfdseBZyzcnsVzsPH) == 0)
			{
				goto IL_0036;
			}
			if ((P_0 & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) != ButtonStateFlags.ztWMoVOElQhqQdOXUUkwdpRgLNcE && (P_0 & ButtonStateFlags.FRjFpveoAfCIfdseBZyzcnsVzsPH) == 0)
			{
				break;
			}
			goto IL_0077;
			IL_000d:
			int num;
			while (true)
			{
				switch (num ^ -967896842)
				{
				case 4:
					num = -967896841;
					continue;
				default:
					return;
				case 2:
					break;
				case 6:
					P_0 = ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf;
					num = -967896845;
					continue;
				case 1:
					goto IL_0056;
				case 3:
					return;
				case 0:
					goto IL_0077;
				case 5:
					return;
				}
				break;
			}
			goto IL_0036;
			IL_0077:
			P_0 = ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf | ButtonStateFlags.FRjFpveoAfCIfdseBZyzcnsVzsPH;
			num = -967896843;
			goto IL_000d;
			IL_0036:
			int num2;
			if ((P_1 & ButtonStateFlags.urElrcGQURaMVXYdJRHXARJLPhf) == 0)
			{
				num = -967896845;
				num2 = num;
			}
			else
			{
				num = -967896848;
				num2 = num;
			}
			goto IL_000d;
		}
	}
}
