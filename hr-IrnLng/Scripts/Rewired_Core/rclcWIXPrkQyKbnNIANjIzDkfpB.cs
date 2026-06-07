using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class rclcWIXPrkQyKbnNIANjIzDkfpB
{
	public class oBQnmYCFZMuAPPRhPtknJbuLqqd
	{
		public readonly Action<InputActionEventData> hzyzSQgZhspWAcbHyINMHjYrItoh;

		public readonly UpdateLoopType ENXLJBnoaLplSRNpPerVNetoNsG;

		public readonly InputActionEventType BYUUyqVICygAsDWAOQMdcRXccCT;

		public readonly int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

		public readonly bool GYSmnmqplScFzHWsQZAyeRonGYHJ;

		public float[] xEoTseVpteZxKPpXlKjMOkOtHLj;

		public oBQnmYCFZMuAPPRhPtknJbuLqqd(Action<InputActionEventData> @delegate, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			ENXLJBnoaLplSRNpPerVNetoNsG = updateLoop;
			BYUUyqVICygAsDWAOQMdcRXccCT = eventType;
			aCGiPaCCkBbVoaUFLfEYHFYRMYCM = actionId;
			hzyzSQgZhspWAcbHyINMHjYrItoh = @delegate;
			HkxdxkBqclvNhIRHXPobfHXcwzAX(arguments);
			switch (eventType)
			{
			case InputActionEventType.Update:
			case InputActionEventType.ButtonUnpressed:
			case InputActionEventType.NegativeButtonUnpressed:
			case InputActionEventType.AxisInactive:
			case InputActionEventType.AxisRawInactive:
				GYSmnmqplScFzHWsQZAyeRonGYHJ = true;
				break;
			}
		}

		public bool hHIvEnRcryiSzSzuClsuxFaJHUC(int P_0, out float P_1)
		{
			if (xEoTseVpteZxKPpXlKjMOkOtHLj == null || xEoTseVpteZxKPpXlKjMOkOtHLj.Length <= P_0)
			{
				P_1 = 0f;
				return false;
			}
			P_1 = xEoTseVpteZxKPpXlKjMOkOtHLj[P_0];
			return true;
		}

		private void HkxdxkBqclvNhIRHXPobfHXcwzAX(object[] P_0)
		{
			switch (BYUUyqVICygAsDWAOQMdcRXccCT)
			{
			case InputActionEventType.ButtonPressedForTime:
			case InputActionEventType.ButtonPressedForTimeJustReleased:
			case InputActionEventType.NegativeButtonPressedForTime:
			case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception(string.Concat("Wrong number of arguments passed for Input event type \"", BYUUyqVICygAsDWAOQMdcRXccCT, "\". 1 required argument: time [float], 1 optional argument: expireIn [float]"));
				}
				xEoTseVpteZxKPpXlKjMOkOtHLj = new float[2];
				if (P_0[0] is float)
				{
					xEoTseVpteZxKPpXlKjMOkOtHLj[0] = (float)P_0[0];
				}
				else
				{
					if (!(P_0[0] is int))
					{
						throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", BYUUyqVICygAsDWAOQMdcRXccCT, "\". Argument 0: time [float]"));
					}
					xEoTseVpteZxKPpXlKjMOkOtHLj[0] = (int)P_0[0];
				}
				if (P_0.Length <= 1)
				{
					break;
				}
				if (P_0[1] is float)
				{
					xEoTseVpteZxKPpXlKjMOkOtHLj[1] = (float)P_0[1];
					break;
				}
				if (P_0[1] is int)
				{
					xEoTseVpteZxKPpXlKjMOkOtHLj[1] = (int)P_0[1];
					break;
				}
				throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", BYUUyqVICygAsDWAOQMdcRXccCT, "\". Argument 1 (optional): expireIn [float]"));
			case InputActionEventType.ButtonJustPressedForTime:
			case InputActionEventType.NegativeButtonJustPressedForTime:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception(string.Concat("Wrong number of arguments passed for Input event type \"", BYUUyqVICygAsDWAOQMdcRXccCT, "\". Requires 1 argument: time [float]"));
				}
				xEoTseVpteZxKPpXlKjMOkOtHLj = new float[1];
				if (P_0[0] is float)
				{
					xEoTseVpteZxKPpXlKjMOkOtHLj[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					xEoTseVpteZxKPpXlKjMOkOtHLj[0] = (int)P_0[0];
					break;
				}
				throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", BYUUyqVICygAsDWAOQMdcRXccCT, "\". Argument 0: time [float]"));
			case InputActionEventType.ButtonDoublePressed:
			case InputActionEventType.ButtonJustDoublePressed:
			case InputActionEventType.NegativeButtonDoublePressed:
			case InputActionEventType.NegativeButtonJustDoublePressed:
			case InputActionEventType.ButtonDoublePressJustReleased:
			case InputActionEventType.NegativeButtonDoublePressJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					break;
				}
				xEoTseVpteZxKPpXlKjMOkOtHLj = new float[1];
				if (P_0[0] is float)
				{
					xEoTseVpteZxKPpXlKjMOkOtHLj[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					xEoTseVpteZxKPpXlKjMOkOtHLj[0] = (int)P_0[0];
					break;
				}
				throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", BYUUyqVICygAsDWAOQMdcRXccCT, "\". Argument 0 (optional): time [float]"));
			}
		}
	}

	private sealed class ZvUnQLCtBMKUEhDkYvVxrIaVTzW
	{
		public Action<InputActionEventData> hzyzSQgZhspWAcbHyINMHjYrItoh;

		public bool bOcrJtHOGDKmnxPfmkNKnliYDtK(oBQnmYCFZMuAPPRhPtknJbuLqqd P_0)
		{
			return P_0.hzyzSQgZhspWAcbHyINMHjYrItoh == hzyzSQgZhspWAcbHyINMHjYrItoh;
		}
	}

	private sealed class VybCkneDdbhRMTwslCOeXPOzpIQQ
	{
		public Action<InputActionEventData> hzyzSQgZhspWAcbHyINMHjYrItoh;

		public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

		public bool FDAZJSjMXZWXWPgiyknowkgVIkl(oBQnmYCFZMuAPPRhPtknJbuLqqd P_0)
		{
			if (P_0.hzyzSQgZhspWAcbHyINMHjYrItoh == hzyzSQgZhspWAcbHyINMHjYrItoh)
			{
				return P_0.aCGiPaCCkBbVoaUFLfEYHFYRMYCM == aCGiPaCCkBbVoaUFLfEYHFYRMYCM;
			}
			return false;
		}
	}

	private sealed class sIgIrnJLbOOMLdnAOVvJceOzjof
	{
		public Action<InputActionEventData> hzyzSQgZhspWAcbHyINMHjYrItoh;

		public UpdateLoopType ENXLJBnoaLplSRNpPerVNetoNsG;

		public bool BDmxoysFEaBcJcAvOfXQQDzawTud(oBQnmYCFZMuAPPRhPtknJbuLqqd P_0)
		{
			if (P_0.hzyzSQgZhspWAcbHyINMHjYrItoh == hzyzSQgZhspWAcbHyINMHjYrItoh)
			{
				return P_0.ENXLJBnoaLplSRNpPerVNetoNsG == ENXLJBnoaLplSRNpPerVNetoNsG;
			}
			return false;
		}
	}

	private sealed class yraxhOTAhXwWzccaRprVBmvwgkw
	{
		public Action<InputActionEventData> hzyzSQgZhspWAcbHyINMHjYrItoh;

		public InputActionEventType BYUUyqVICygAsDWAOQMdcRXccCT;

		public bool EUzriBLdstciCcEQVsPvWrkJcYv(oBQnmYCFZMuAPPRhPtknJbuLqqd P_0)
		{
			if (P_0.hzyzSQgZhspWAcbHyINMHjYrItoh == hzyzSQgZhspWAcbHyINMHjYrItoh)
			{
				return P_0.BYUUyqVICygAsDWAOQMdcRXccCT == BYUUyqVICygAsDWAOQMdcRXccCT;
			}
			return false;
		}
	}

	private sealed class QCpYkkMsjvdGzwgEZkAeVAbYaiJ
	{
		public Action<InputActionEventData> hzyzSQgZhspWAcbHyINMHjYrItoh;

		public UpdateLoopType ENXLJBnoaLplSRNpPerVNetoNsG;

		public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

		public bool SJhcypxmSHyVHwvJtcasaJPaMeU(oBQnmYCFZMuAPPRhPtknJbuLqqd P_0)
		{
			if (P_0.hzyzSQgZhspWAcbHyINMHjYrItoh == hzyzSQgZhspWAcbHyINMHjYrItoh && P_0.ENXLJBnoaLplSRNpPerVNetoNsG == ENXLJBnoaLplSRNpPerVNetoNsG)
			{
				return P_0.aCGiPaCCkBbVoaUFLfEYHFYRMYCM == aCGiPaCCkBbVoaUFLfEYHFYRMYCM;
			}
			return false;
		}
	}

	private sealed class rAQdSeaQEYVJlXxbtpIBWOciCXN
	{
		public Action<InputActionEventData> hzyzSQgZhspWAcbHyINMHjYrItoh;

		public UpdateLoopType ENXLJBnoaLplSRNpPerVNetoNsG;

		public InputActionEventType BYUUyqVICygAsDWAOQMdcRXccCT;

		public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

		public bool nmWewnTyIQInkwtSIDTBqPitowI(oBQnmYCFZMuAPPRhPtknJbuLqqd P_0)
		{
			if (P_0.hzyzSQgZhspWAcbHyINMHjYrItoh == hzyzSQgZhspWAcbHyINMHjYrItoh && P_0.ENXLJBnoaLplSRNpPerVNetoNsG == ENXLJBnoaLplSRNpPerVNetoNsG && P_0.aCGiPaCCkBbVoaUFLfEYHFYRMYCM == aCGiPaCCkBbVoaUFLfEYHFYRMYCM)
			{
				return P_0.BYUUyqVICygAsDWAOQMdcRXccCT == BYUUyqVICygAsDWAOQMdcRXccCT;
			}
			return false;
		}
	}

	private sealed class MXJwsOPHVcwHsxsveMUKhCtmdBi
	{
		public Action<InputActionEventData> hzyzSQgZhspWAcbHyINMHjYrItoh;

		public UpdateLoopType ENXLJBnoaLplSRNpPerVNetoNsG;

		public InputActionEventType BYUUyqVICygAsDWAOQMdcRXccCT;

		public bool wGvwjRsWIyCbgtXyHNaBBuHILap(oBQnmYCFZMuAPPRhPtknJbuLqqd P_0)
		{
			if (P_0.hzyzSQgZhspWAcbHyINMHjYrItoh == hzyzSQgZhspWAcbHyINMHjYrItoh && P_0.ENXLJBnoaLplSRNpPerVNetoNsG == ENXLJBnoaLplSRNpPerVNetoNsG)
			{
				return P_0.BYUUyqVICygAsDWAOQMdcRXccCT == BYUUyqVICygAsDWAOQMdcRXccCT;
			}
			return false;
		}
	}

	private sealed class JjsgGFIUxOAkUQOBwKzXgAUjlfmn
	{
		public Action<InputActionEventData> hzyzSQgZhspWAcbHyINMHjYrItoh;

		public InputActionEventType BYUUyqVICygAsDWAOQMdcRXccCT;

		public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

		public bool epxXSCPzuAueoToxFePveSllbicK(oBQnmYCFZMuAPPRhPtknJbuLqqd P_0)
		{
			if (P_0.hzyzSQgZhspWAcbHyINMHjYrItoh == hzyzSQgZhspWAcbHyINMHjYrItoh && P_0.aCGiPaCCkBbVoaUFLfEYHFYRMYCM == aCGiPaCCkBbVoaUFLfEYHFYRMYCM)
			{
				return P_0.BYUUyqVICygAsDWAOQMdcRXccCT == BYUUyqVICygAsDWAOQMdcRXccCT;
			}
			return false;
		}
	}

	private static oBQnmYCFZMuAPPRhPtknJbuLqqd[] PxMBUnEmsGgXkDoxGLAoFEKDjFzM;

	private bool iTMWkJzAQHobYymwbflfUznXqqe;

	private AList<oBQnmYCFZMuAPPRhPtknJbuLqqd>[] jrwPvksYJUtLqDNfdFIwnxfpYiT;

	private int[] ymmoBDySCQAwBCHXCpzMQUxhnYlz;

	private int USbEcDIvsXFYuTufbiwpeIhNBlg;

	public int GWmqAqfHoBawfOQHOApVhYErCejj;

	[CompilerGenerated]
	private static Func<AList<oBQnmYCFZMuAPPRhPtknJbuLqqd>> rZGVFRgQMmptVpKQzBtcADhlKAsu;

	static rclcWIXPrkQyKbnNIANjIzDkfpB()
	{
		PxMBUnEmsGgXkDoxGLAoFEKDjFzM = new oBQnmYCFZMuAPPRhPtknJbuLqqd[100];
	}

	private void iDBXctPcOcjjzWbKaCnxuPiVNUc()
	{
		if (!iTMWkJzAQHobYymwbflfUznXqqe)
		{
			IList<InputAction> actions = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.Actions;
			int num = actions?.Count ?? 0;
			jrwPvksYJUtLqDNfdFIwnxfpYiT = new AList<oBQnmYCFZMuAPPRhPtknJbuLqqd>[num + 1];
			ymmoBDySCQAwBCHXCpzMQUxhnYlz = new int[ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.maxActionId + 1];
			ArrayTools.Populate(jrwPvksYJUtLqDNfdFIwnxfpYiT, 0, jrwPvksYJUtLqDNfdFIwnxfpYiT.Length, () => new AList<oBQnmYCFZMuAPPRhPtknJbuLqqd>());
			for (int num2 = 0; num2 < num; num2++)
			{
				ymmoBDySCQAwBCHXCpzMQUxhnYlz[actions[num2].id] = num2;
			}
			USbEcDIvsXFYuTufbiwpeIhNBlg = num;
			iTMWkJzAQHobYymwbflfUznXqqe = true;
		}
	}

	public void fRBYwVckFDGelApOqAuTpyFGMnH(VvbRiPIRRDOGFeaGvZCVmBjRfXT P_0, UpdateLoopType P_1)
	{
		AList<oBQnmYCFZMuAPPRhPtknJbuLqqd> aList = jrwPvksYJUtLqDNfdFIwnxfpYiT[ymmoBDySCQAwBCHXCpzMQUxhnYlz[P_0.CYBGYVfPDvCydagiBzJBExAfcuYb]];
		for (int i = 0; i < 2; i++)
		{
			if (i == 1)
			{
				aList = jrwPvksYJUtLqDNfdFIwnxfpYiT[USbEcDIvsXFYuTufbiwpeIhNBlg];
			}
			int count = aList._count;
			if (PxMBUnEmsGgXkDoxGLAoFEKDjFzM.Length < count)
			{
				PxMBUnEmsGgXkDoxGLAoFEKDjFzM = new oBQnmYCFZMuAPPRhPtknJbuLqqd[count + 50];
			}
			if (count > 0)
			{
				Array.Copy(aList._items, PxMBUnEmsGgXkDoxGLAoFEKDjFzM, count);
			}
			for (int j = 0; j < count; j++)
			{
				oBQnmYCFZMuAPPRhPtknJbuLqqd oBQnmYCFZMuAPPRhPtknJbuLqqd2 = PxMBUnEmsGgXkDoxGLAoFEKDjFzM[j];
				if (oBQnmYCFZMuAPPRhPtknJbuLqqd2 == null || (!P_0.IAPkqDUzQJdPHucoTqCGLiJSizt && !oBQnmYCFZMuAPPRhPtknJbuLqqd2.GYSmnmqplScFzHWsQZAyeRonGYHJ) || oBQnmYCFZMuAPPRhPtknJbuLqqd2.ENXLJBnoaLplSRNpPerVNetoNsG != P_1 || (oBQnmYCFZMuAPPRhPtknJbuLqqd2.aCGiPaCCkBbVoaUFLfEYHFYRMYCM >= 0 && oBQnmYCFZMuAPPRhPtknJbuLqqd2.aCGiPaCCkBbVoaUFLfEYHFYRMYCM != P_0.CYBGYVfPDvCydagiBzJBExAfcuYb))
				{
					continue;
				}
				bool flag = false;
				switch (oBQnmYCFZMuAPPRhPtknJbuLqqd2.BYUUyqVICygAsDWAOQMdcRXccCT)
				{
				case InputActionEventType.Update:
					flag = true;
					break;
				case InputActionEventType.ButtonPressed:
					if (P_0.JFLhhsViRZmASHFRAirmzVNMOhf())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonUnpressed:
					if (!P_0.JFLhhsViRZmASHFRAirmzVNMOhf())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonDoublePressed:
				{
					oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(0, out var num5);
					if (P_0.UUZmGlAOcRhchLoNsdBteRISnEQE(num5))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonPressedForTime:
				{
					if (!oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(0, out var num11))
					{
						continue;
					}
					oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(1, out var num12);
					if (P_0.MJFiUNuBLTbsJUlFjOVlfkwzBgo(num11, num12))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressed:
					if (P_0.TDNQHJbeFKJoDxwtrnohFGhnGia())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressed:
					if (P_0.DPQEfEAGIkMdCxLzhUjNTnVWWUN())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustPressed:
					if (P_0.CmwiIVrqfDqUrfdgDhwXnRxwqAE())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustReleased:
					if (P_0.cpecOFaBXVFHwWEOrZWGPOEkoSMP())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustDoublePressed:
				{
					oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(0, out var num9);
					if (P_0.iglKEgVKDfDRCUxquknahEhdtbQ(num9))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonDoublePressJustReleased:
				{
					oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(0, out var num6);
					if (P_0.pnzcIdXJrVISsrBwsrgSONYhjwk(num6))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustPressedForTime:
				{
					if (!oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(0, out var num4))
					{
						continue;
					}
					if (P_0.AhxzbaandODBCebugdYNafXSfVN(num4))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustShortPressed:
					if (P_0.SZLlYDUKPLfOpUVKZFqrIpeYOdq())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustLongPressed:
					if (P_0.UFEBQdeMjJKkVodijCmWCvPyPZJ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonPressedForTimeJustReleased:
				{
					if (!oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(0, out var num15))
					{
						continue;
					}
					oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(1, out var num16);
					if (P_0.JmakveFOtToTPFfcUGpGDreIVVz(num15, num16))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressJustReleased:
					if (P_0.uRjrrpPoOXyApRzAqZxwayRoyBU())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressJustReleased:
					if (P_0.UuXvkSSlJNzydOxqRRfMzGOVYQy())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonRepeating:
					if (P_0.xOVlFzhoZHfZzLUlrOuAqsoKUMU())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressed:
					if (P_0.QTLvXIaYFpPMOZfpIGILrPOecaW())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustSinglePressed:
					if (P_0.PpZWnKYAyeadsuKqJmajERczqNY())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressJustReleased:
					if (P_0.ADNfTWTmfSlOGQjlvAAfCePfsin())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressed:
					if (P_0.gjvFsQfWVLkGJLUlHHOwfcVAxgI())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonUnpressed:
					if (!P_0.gjvFsQfWVLkGJLUlHHOwfcVAxgI())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonDoublePressed:
				{
					oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(0, out var num3);
					if (P_0.agUAqgemdZpaKOMTCmtHqKZcEwxg(num3))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonPressedForTime:
				{
					if (!oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(0, out var num))
					{
						continue;
					}
					oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(1, out var num2);
					if (P_0.HgLItgBCWBsCCYWNBKmKgGDoubH(num, num2))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressed:
					if (P_0.nHowdczhJjGQpHoPuhSaxofMeXU())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressed:
					if (P_0.AoOcxpYeHjMNEyQbNoVoYGGKEYs())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustPressed:
					if (P_0.wiPVOSjfQFqDVBfmgbvuPukNqlZ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustReleased:
					if (P_0.lSoChdolRrcjvhCMgWkTNuSJzJM())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustDoublePressed:
				{
					oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(0, out var num14);
					if (P_0.wvfXZLJtMOTHRZqKjHcKgEZqIhQy(num14))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonDoublePressJustReleased:
				{
					oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(0, out var num13);
					if (P_0.KCcpdVlzpCIiXRUPqJoMFQeqdHsG(num13))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustPressedForTime:
				{
					if (!oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(0, out var num10))
					{
						continue;
					}
					if (P_0.cDGRdmSKZRTpXeZTLCaInrAktM(num10))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustShortPressed:
					if (P_0.QfazomiUZJqoaCvaEoGdIyvImmi())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustLongPressed:
					if (P_0.DDgdmSGHKLLlIOmMiTkGuXLuBNc())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				{
					if (!oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(0, out var num7))
					{
						continue;
					}
					oBQnmYCFZMuAPPRhPtknJbuLqqd2.hHIvEnRcryiSzSzuClsuxFaJHUC(1, out var num8);
					if (P_0.rwPIJlCPHsrUNNKCobpqYFjHDAa(num7, num8))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressJustReleased:
					if (P_0.RBTuBJtXUddlICbnuMOEmSITWbP())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressJustReleased:
					if (P_0.JGzwiBNdgTVqoMIKduxivCKdvVw())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonRepeating:
					if (P_0.pXXQSEbZHuROokYgEnrXGPzdGtEF())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressed:
					if (P_0.wfyKocGkSJJKuvaaDQlbFFZlulI())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustSinglePressed:
					if (P_0.rNxXdvHMHaWDHmdpbxJrhVReEuF())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressJustReleased:
					if (P_0.LzYqCFtmOAPwFtaNIIAsdeKJjuUW())
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActive:
					if (!MathTools.ApproximatelyZero(P_0.MUPgTaacHnwLRmoJOGqdcZFUrOL()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisInactive:
					if (MathTools.ApproximatelyZero(P_0.MUPgTaacHnwLRmoJOGqdcZFUrOL()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActive:
					if (!MathTools.ApproximatelyZero(P_0.TXbcHqVYmBHhznWplhLLhIEHQBL()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawInactive:
					if (MathTools.ApproximatelyZero(P_0.TXbcHqVYmBHhznWplhLLhIEHQBL()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.MUPgTaacHnwLRmoJOGqdcZFUrOL()) || !MathTools.ApproximatelyZero(P_0.yhRTsdEWjwmGOFpFVsccvsWQDxL()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.TXbcHqVYmBHhznWplhLLhIEHQBL()) || !MathTools.ApproximatelyZero(P_0.MfSnbsPnoWwCjfydtGxjRngFzAj()))
					{
						flag = true;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				try
				{
					if (flag)
					{
						InputActionEventData obj = P_0.tNawgIhQaANJOrBkRFNFPViZPhI(P_1);
						obj.eventType = oBQnmYCFZMuAPPRhPtknJbuLqqd2.BYUUyqVICygAsDWAOQMdcRXccCT;
						oBQnmYCFZMuAPPRhPtknJbuLqqd2.hzyzSQgZhspWAcbHyINMHjYrItoh(obj);
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("Player input event callback", exception);
				}
			}
		}
	}

	public void MoYefDcYehcNuEtBwCxDvPMYqtm(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
	{
		if (!iTMWkJzAQHobYymwbflfUznXqqe)
		{
			iDBXctPcOcjjzWbKaCnxuPiVNUc();
		}
		oBQnmYCFZMuAPPRhPtknJbuLqqd item;
		try
		{
			if (P_3 > ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.maxActionId)
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + P_3);
			}
			item = new oBQnmYCFZMuAPPRhPtknJbuLqqd(P_0, P_1, P_2, P_3, P_4);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (P_3 < 0)
		{
			jrwPvksYJUtLqDNfdFIwnxfpYiT[USbEcDIvsXFYuTufbiwpeIhNBlg].Add(item);
		}
		else
		{
			jrwPvksYJUtLqDNfdFIwnxfpYiT[ymmoBDySCQAwBCHXCpzMQUxhnYlz[P_3]].Add(item);
		}
		HGfiMyIflTvOZHtUqtQPiJtmAno();
	}

	public void MoYefDcYehcNuEtBwCxDvPMYqtm(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, object[] P_3)
	{
		if (!iTMWkJzAQHobYymwbflfUznXqqe)
		{
			iDBXctPcOcjjzWbKaCnxuPiVNUc();
		}
		oBQnmYCFZMuAPPRhPtknJbuLqqd item;
		try
		{
			item = new oBQnmYCFZMuAPPRhPtknJbuLqqd(P_0, P_1, P_2, -1, P_3);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		jrwPvksYJUtLqDNfdFIwnxfpYiT[USbEcDIvsXFYuTufbiwpeIhNBlg].Add(item);
		HGfiMyIflTvOZHtUqtQPiJtmAno();
	}

	public void tsiIiRnEIKEeGXdmsiYIGAemsrcr(Action<InputActionEventData> P_0)
	{
		ZvUnQLCtBMKUEhDkYvVxrIaVTzW zvUnQLCtBMKUEhDkYvVxrIaVTzW = new ZvUnQLCtBMKUEhDkYvVxrIaVTzW();
		zvUnQLCtBMKUEhDkYvVxrIaVTzW.hzyzSQgZhspWAcbHyINMHjYrItoh = P_0;
		if (iTMWkJzAQHobYymwbflfUznXqqe)
		{
			AList<oBQnmYCFZMuAPPRhPtknJbuLqqd>[] array = jrwPvksYJUtLqDNfdFIwnxfpYiT;
			foreach (AList<oBQnmYCFZMuAPPRhPtknJbuLqqd> aList in array)
			{
				aList.RemoveAll(zvUnQLCtBMKUEhDkYvVxrIaVTzW.bOcrJtHOGDKmnxPfmkNKnliYDtK);
			}
			HGfiMyIflTvOZHtUqtQPiJtmAno();
		}
	}

	public void tsiIiRnEIKEeGXdmsiYIGAemsrcr(Action<InputActionEventData> P_0, int P_1)
	{
		VybCkneDdbhRMTwslCOeXPOzpIQQ vybCkneDdbhRMTwslCOeXPOzpIQQ = new VybCkneDdbhRMTwslCOeXPOzpIQQ();
		vybCkneDdbhRMTwslCOeXPOzpIQQ.hzyzSQgZhspWAcbHyINMHjYrItoh = P_0;
		vybCkneDdbhRMTwslCOeXPOzpIQQ.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = P_1;
		if (iTMWkJzAQHobYymwbflfUznXqqe && vybCkneDdbhRMTwslCOeXPOzpIQQ.aCGiPaCCkBbVoaUFLfEYHFYRMYCM <= ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.maxActionId)
		{
			AList<oBQnmYCFZMuAPPRhPtknJbuLqqd>[] array = jrwPvksYJUtLqDNfdFIwnxfpYiT;
			foreach (AList<oBQnmYCFZMuAPPRhPtknJbuLqqd> aList in array)
			{
				aList.RemoveAll(vybCkneDdbhRMTwslCOeXPOzpIQQ.FDAZJSjMXZWXWPgiyknowkgVIkl);
			}
			HGfiMyIflTvOZHtUqtQPiJtmAno();
		}
	}

	public void tsiIiRnEIKEeGXdmsiYIGAemsrcr(Action<InputActionEventData> P_0, UpdateLoopType P_1)
	{
		sIgIrnJLbOOMLdnAOVvJceOzjof sIgIrnJLbOOMLdnAOVvJceOzjof2 = new sIgIrnJLbOOMLdnAOVvJceOzjof();
		sIgIrnJLbOOMLdnAOVvJceOzjof2.hzyzSQgZhspWAcbHyINMHjYrItoh = P_0;
		sIgIrnJLbOOMLdnAOVvJceOzjof2.ENXLJBnoaLplSRNpPerVNetoNsG = P_1;
		if (iTMWkJzAQHobYymwbflfUznXqqe)
		{
			AList<oBQnmYCFZMuAPPRhPtknJbuLqqd>[] array = jrwPvksYJUtLqDNfdFIwnxfpYiT;
			foreach (AList<oBQnmYCFZMuAPPRhPtknJbuLqqd> aList in array)
			{
				aList.RemoveAll(sIgIrnJLbOOMLdnAOVvJceOzjof2.BDmxoysFEaBcJcAvOfXQQDzawTud);
			}
			HGfiMyIflTvOZHtUqtQPiJtmAno();
		}
	}

	public void tsiIiRnEIKEeGXdmsiYIGAemsrcr(Action<InputActionEventData> P_0, InputActionEventType P_1)
	{
		yraxhOTAhXwWzccaRprVBmvwgkw yraxhOTAhXwWzccaRprVBmvwgkw2 = new yraxhOTAhXwWzccaRprVBmvwgkw();
		yraxhOTAhXwWzccaRprVBmvwgkw2.hzyzSQgZhspWAcbHyINMHjYrItoh = P_0;
		yraxhOTAhXwWzccaRprVBmvwgkw2.BYUUyqVICygAsDWAOQMdcRXccCT = P_1;
		if (iTMWkJzAQHobYymwbflfUznXqqe)
		{
			AList<oBQnmYCFZMuAPPRhPtknJbuLqqd>[] array = jrwPvksYJUtLqDNfdFIwnxfpYiT;
			foreach (AList<oBQnmYCFZMuAPPRhPtknJbuLqqd> aList in array)
			{
				aList.RemoveAll(yraxhOTAhXwWzccaRprVBmvwgkw2.EUzriBLdstciCcEQVsPvWrkJcYv);
			}
			HGfiMyIflTvOZHtUqtQPiJtmAno();
		}
	}

	public void tsiIiRnEIKEeGXdmsiYIGAemsrcr(Action<InputActionEventData> P_0, UpdateLoopType P_1, int P_2)
	{
		QCpYkkMsjvdGzwgEZkAeVAbYaiJ qCpYkkMsjvdGzwgEZkAeVAbYaiJ = new QCpYkkMsjvdGzwgEZkAeVAbYaiJ();
		qCpYkkMsjvdGzwgEZkAeVAbYaiJ.hzyzSQgZhspWAcbHyINMHjYrItoh = P_0;
		qCpYkkMsjvdGzwgEZkAeVAbYaiJ.ENXLJBnoaLplSRNpPerVNetoNsG = P_1;
		qCpYkkMsjvdGzwgEZkAeVAbYaiJ.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = P_2;
		if (iTMWkJzAQHobYymwbflfUznXqqe && qCpYkkMsjvdGzwgEZkAeVAbYaiJ.aCGiPaCCkBbVoaUFLfEYHFYRMYCM <= ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.maxActionId)
		{
			AList<oBQnmYCFZMuAPPRhPtknJbuLqqd>[] array = jrwPvksYJUtLqDNfdFIwnxfpYiT;
			foreach (AList<oBQnmYCFZMuAPPRhPtknJbuLqqd> aList in array)
			{
				aList.RemoveAll(qCpYkkMsjvdGzwgEZkAeVAbYaiJ.SJhcypxmSHyVHwvJtcasaJPaMeU);
			}
			HGfiMyIflTvOZHtUqtQPiJtmAno();
		}
	}

	public void tsiIiRnEIKEeGXdmsiYIGAemsrcr(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3)
	{
		rAQdSeaQEYVJlXxbtpIBWOciCXN rAQdSeaQEYVJlXxbtpIBWOciCXN2 = new rAQdSeaQEYVJlXxbtpIBWOciCXN();
		rAQdSeaQEYVJlXxbtpIBWOciCXN2.hzyzSQgZhspWAcbHyINMHjYrItoh = P_0;
		rAQdSeaQEYVJlXxbtpIBWOciCXN2.ENXLJBnoaLplSRNpPerVNetoNsG = P_1;
		rAQdSeaQEYVJlXxbtpIBWOciCXN2.BYUUyqVICygAsDWAOQMdcRXccCT = P_2;
		rAQdSeaQEYVJlXxbtpIBWOciCXN2.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = P_3;
		if (iTMWkJzAQHobYymwbflfUznXqqe && rAQdSeaQEYVJlXxbtpIBWOciCXN2.aCGiPaCCkBbVoaUFLfEYHFYRMYCM <= ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.maxActionId)
		{
			AList<oBQnmYCFZMuAPPRhPtknJbuLqqd>[] array = jrwPvksYJUtLqDNfdFIwnxfpYiT;
			foreach (AList<oBQnmYCFZMuAPPRhPtknJbuLqqd> aList in array)
			{
				aList.RemoveAll(rAQdSeaQEYVJlXxbtpIBWOciCXN2.nmWewnTyIQInkwtSIDTBqPitowI);
			}
			HGfiMyIflTvOZHtUqtQPiJtmAno();
		}
	}

	public void tsiIiRnEIKEeGXdmsiYIGAemsrcr(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2)
	{
		MXJwsOPHVcwHsxsveMUKhCtmdBi mXJwsOPHVcwHsxsveMUKhCtmdBi = new MXJwsOPHVcwHsxsveMUKhCtmdBi();
		mXJwsOPHVcwHsxsveMUKhCtmdBi.hzyzSQgZhspWAcbHyINMHjYrItoh = P_0;
		mXJwsOPHVcwHsxsveMUKhCtmdBi.ENXLJBnoaLplSRNpPerVNetoNsG = P_1;
		mXJwsOPHVcwHsxsveMUKhCtmdBi.BYUUyqVICygAsDWAOQMdcRXccCT = P_2;
		if (iTMWkJzAQHobYymwbflfUznXqqe)
		{
			AList<oBQnmYCFZMuAPPRhPtknJbuLqqd>[] array = jrwPvksYJUtLqDNfdFIwnxfpYiT;
			foreach (AList<oBQnmYCFZMuAPPRhPtknJbuLqqd> aList in array)
			{
				aList.RemoveAll(mXJwsOPHVcwHsxsveMUKhCtmdBi.wGvwjRsWIyCbgtXyHNaBBuHILap);
			}
			HGfiMyIflTvOZHtUqtQPiJtmAno();
		}
	}

	public void tsiIiRnEIKEeGXdmsiYIGAemsrcr(Action<InputActionEventData> P_0, InputActionEventType P_1, int P_2)
	{
		JjsgGFIUxOAkUQOBwKzXgAUjlfmn jjsgGFIUxOAkUQOBwKzXgAUjlfmn = new JjsgGFIUxOAkUQOBwKzXgAUjlfmn();
		jjsgGFIUxOAkUQOBwKzXgAUjlfmn.hzyzSQgZhspWAcbHyINMHjYrItoh = P_0;
		jjsgGFIUxOAkUQOBwKzXgAUjlfmn.BYUUyqVICygAsDWAOQMdcRXccCT = P_1;
		jjsgGFIUxOAkUQOBwKzXgAUjlfmn.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = P_2;
		if (iTMWkJzAQHobYymwbflfUznXqqe && jjsgGFIUxOAkUQOBwKzXgAUjlfmn.aCGiPaCCkBbVoaUFLfEYHFYRMYCM <= ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.maxActionId)
		{
			AList<oBQnmYCFZMuAPPRhPtknJbuLqqd>[] array = jrwPvksYJUtLqDNfdFIwnxfpYiT;
			foreach (AList<oBQnmYCFZMuAPPRhPtknJbuLqqd> aList in array)
			{
				aList.RemoveAll(jjsgGFIUxOAkUQOBwKzXgAUjlfmn.epxXSCPzuAueoToxFePveSllbicK);
			}
			HGfiMyIflTvOZHtUqtQPiJtmAno();
		}
	}

	public void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
	{
		if (iTMWkJzAQHobYymwbflfUznXqqe)
		{
			AList<oBQnmYCFZMuAPPRhPtknJbuLqqd>[] array = jrwPvksYJUtLqDNfdFIwnxfpYiT;
			foreach (AList<oBQnmYCFZMuAPPRhPtknJbuLqqd> aList in array)
			{
				aList.Clear();
			}
			HGfiMyIflTvOZHtUqtQPiJtmAno();
		}
	}

	private void HGfiMyIflTvOZHtUqtQPiJtmAno()
	{
		int num = 0;
		for (int i = 0; i < jrwPvksYJUtLqDNfdFIwnxfpYiT.Length; i++)
		{
			num += jrwPvksYJUtLqDNfdFIwnxfpYiT[i]._count;
		}
		GWmqAqfHoBawfOQHOApVhYErCejj = num;
	}

	[CompilerGenerated]
	private static AList<oBQnmYCFZMuAPPRhPtknJbuLqqd> jjomDoXqjCmcuhUNtcEelTfzuZQ()
	{
		return new AList<oBQnmYCFZMuAPPRhPtknJbuLqqd>();
	}
}
