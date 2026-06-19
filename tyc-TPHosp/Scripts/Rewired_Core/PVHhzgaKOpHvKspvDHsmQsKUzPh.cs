using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class PVHhzgaKOpHvKspvDHsmQsKUzPh
{
	public class qlRSeLdFXBdyMFtSSEoQaxadAQI
	{
		public readonly Action<InputActionEventData> PsKJxyXhYxofEzkrjdXLrJdXdjYc;

		public readonly UpdateLoopType iTlZorELHQDCESPLUCqUXMAKNVy;

		public readonly InputActionEventType zLmhKMibflLkQSoDRCyyswPKorV;

		public readonly int KjaWgObGREamoandMdAXxTdnHIgu;

		public readonly bool cOeEGAhBSXnizEHGbXOlSBBhTGrB;

		public float[] PBQwjOaTQzoZpEbLaUfuYPNgTWt;

		public qlRSeLdFXBdyMFtSSEoQaxadAQI(Action<InputActionEventData> @delegate, UpdateLoopType updateLoop, InputActionEventType eventType, int actionId, object[] arguments)
		{
			iTlZorELHQDCESPLUCqUXMAKNVy = updateLoop;
			zLmhKMibflLkQSoDRCyyswPKorV = eventType;
			KjaWgObGREamoandMdAXxTdnHIgu = actionId;
			PsKJxyXhYxofEzkrjdXLrJdXdjYc = @delegate;
			hdJPYGLUZoggdKShQEcsFVwIFvsI(arguments);
			switch (eventType)
			{
			case InputActionEventType.Update:
			case InputActionEventType.ButtonUnpressed:
			case InputActionEventType.NegativeButtonUnpressed:
			case InputActionEventType.AxisInactive:
			case InputActionEventType.AxisRawInactive:
				cOeEGAhBSXnizEHGbXOlSBBhTGrB = true;
				break;
			}
		}

		public bool PKuQoPgGrlXffBGFJxZftXpbZgR(int P_0, out float P_1)
		{
			if (PBQwjOaTQzoZpEbLaUfuYPNgTWt == null || PBQwjOaTQzoZpEbLaUfuYPNgTWt.Length <= P_0)
			{
				P_1 = 0f;
				return false;
			}
			P_1 = PBQwjOaTQzoZpEbLaUfuYPNgTWt[P_0];
			return true;
		}

		private void hdJPYGLUZoggdKShQEcsFVwIFvsI(object[] P_0)
		{
			switch (zLmhKMibflLkQSoDRCyyswPKorV)
			{
			case InputActionEventType.ButtonPressedForTime:
			case InputActionEventType.ButtonPressedForTimeJustReleased:
			case InputActionEventType.NegativeButtonPressedForTime:
			case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception(string.Concat("Wrong number of arguments passed for Input event type \"", zLmhKMibflLkQSoDRCyyswPKorV, "\". 1 required argument: time [float], 1 optional argument: expireIn [float]"));
				}
				PBQwjOaTQzoZpEbLaUfuYPNgTWt = new float[2];
				if (P_0[0] is float)
				{
					PBQwjOaTQzoZpEbLaUfuYPNgTWt[0] = (float)P_0[0];
				}
				else
				{
					if (!(P_0[0] is int))
					{
						throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", zLmhKMibflLkQSoDRCyyswPKorV, "\". Argument 0: time [float]"));
					}
					PBQwjOaTQzoZpEbLaUfuYPNgTWt[0] = (int)P_0[0];
				}
				if (P_0.Length <= 1)
				{
					break;
				}
				if (P_0[1] is float)
				{
					PBQwjOaTQzoZpEbLaUfuYPNgTWt[1] = (float)P_0[1];
					break;
				}
				if (P_0[1] is int)
				{
					PBQwjOaTQzoZpEbLaUfuYPNgTWt[1] = (int)P_0[1];
					break;
				}
				throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", zLmhKMibflLkQSoDRCyyswPKorV, "\". Argument 1 (optional): expireIn [float]"));
			case InputActionEventType.ButtonJustPressedForTime:
			case InputActionEventType.NegativeButtonJustPressedForTime:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception(string.Concat("Wrong number of arguments passed for Input event type \"", zLmhKMibflLkQSoDRCyyswPKorV, "\". Requires 1 argument: time [float]"));
				}
				PBQwjOaTQzoZpEbLaUfuYPNgTWt = new float[1];
				if (P_0[0] is float)
				{
					PBQwjOaTQzoZpEbLaUfuYPNgTWt[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					PBQwjOaTQzoZpEbLaUfuYPNgTWt[0] = (int)P_0[0];
					break;
				}
				throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", zLmhKMibflLkQSoDRCyyswPKorV, "\". Argument 0: time [float]"));
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
				PBQwjOaTQzoZpEbLaUfuYPNgTWt = new float[1];
				if (P_0[0] is float)
				{
					PBQwjOaTQzoZpEbLaUfuYPNgTWt[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					PBQwjOaTQzoZpEbLaUfuYPNgTWt[0] = (int)P_0[0];
					break;
				}
				throw new Exception(string.Concat("Wrong argument type passed for Input event type \"", zLmhKMibflLkQSoDRCyyswPKorV, "\". Argument 0 (optional): time [float]"));
			}
		}
	}

	private sealed class cShBdtOHIZIRqfbdggfHPrZuazCO
	{
		public Action<InputActionEventData> PsKJxyXhYxofEzkrjdXLrJdXdjYc;

		public bool BVWUbHwHjOCvbaRxlsyFvKUgPVg(qlRSeLdFXBdyMFtSSEoQaxadAQI P_0)
		{
			return P_0.PsKJxyXhYxofEzkrjdXLrJdXdjYc == PsKJxyXhYxofEzkrjdXLrJdXdjYc;
		}
	}

	private sealed class ssFppbUawZfUQTSvRRblAmvskes
	{
		public Action<InputActionEventData> PsKJxyXhYxofEzkrjdXLrJdXdjYc;

		public int KjaWgObGREamoandMdAXxTdnHIgu;

		public bool nWohiuYfyUIlGAiStdzpFeDtnuTR(qlRSeLdFXBdyMFtSSEoQaxadAQI P_0)
		{
			if (P_0.PsKJxyXhYxofEzkrjdXLrJdXdjYc == PsKJxyXhYxofEzkrjdXLrJdXdjYc)
			{
				return P_0.KjaWgObGREamoandMdAXxTdnHIgu == KjaWgObGREamoandMdAXxTdnHIgu;
			}
			return false;
		}
	}

	private sealed class VvmIHMhYGbdYmCAyGPviUKNzoHJ
	{
		public Action<InputActionEventData> PsKJxyXhYxofEzkrjdXLrJdXdjYc;

		public UpdateLoopType iTlZorELHQDCESPLUCqUXMAKNVy;

		public bool rWAhHEBZzjNNNZABZtNHHrOWRSC(qlRSeLdFXBdyMFtSSEoQaxadAQI P_0)
		{
			if (P_0.PsKJxyXhYxofEzkrjdXLrJdXdjYc == PsKJxyXhYxofEzkrjdXLrJdXdjYc)
			{
				return P_0.iTlZorELHQDCESPLUCqUXMAKNVy == iTlZorELHQDCESPLUCqUXMAKNVy;
			}
			return false;
		}
	}

	private sealed class BLwimDgclCssJrgLscHbxmDQwHZ
	{
		public Action<InputActionEventData> PsKJxyXhYxofEzkrjdXLrJdXdjYc;

		public InputActionEventType zLmhKMibflLkQSoDRCyyswPKorV;

		public bool yQNcEboMDqYFMnNoAVyuAJZhtuL(qlRSeLdFXBdyMFtSSEoQaxadAQI P_0)
		{
			if (P_0.PsKJxyXhYxofEzkrjdXLrJdXdjYc == PsKJxyXhYxofEzkrjdXLrJdXdjYc)
			{
				return P_0.zLmhKMibflLkQSoDRCyyswPKorV == zLmhKMibflLkQSoDRCyyswPKorV;
			}
			return false;
		}
	}

	private sealed class FXneLWGgdpQmULibVXuifUrNEXZ
	{
		public Action<InputActionEventData> PsKJxyXhYxofEzkrjdXLrJdXdjYc;

		public UpdateLoopType iTlZorELHQDCESPLUCqUXMAKNVy;

		public int KjaWgObGREamoandMdAXxTdnHIgu;

		public bool qxTmRBAybCbcBnyzaevrmDeACoa(qlRSeLdFXBdyMFtSSEoQaxadAQI P_0)
		{
			if (P_0.PsKJxyXhYxofEzkrjdXLrJdXdjYc == PsKJxyXhYxofEzkrjdXLrJdXdjYc && P_0.iTlZorELHQDCESPLUCqUXMAKNVy == iTlZorELHQDCESPLUCqUXMAKNVy)
			{
				return P_0.KjaWgObGREamoandMdAXxTdnHIgu == KjaWgObGREamoandMdAXxTdnHIgu;
			}
			return false;
		}
	}

	private sealed class mTOAGUXIsVZUBivpQqWOpiqmLd
	{
		public Action<InputActionEventData> PsKJxyXhYxofEzkrjdXLrJdXdjYc;

		public UpdateLoopType iTlZorELHQDCESPLUCqUXMAKNVy;

		public InputActionEventType zLmhKMibflLkQSoDRCyyswPKorV;

		public int KjaWgObGREamoandMdAXxTdnHIgu;

		public bool JsqSBRsExFTEyzheBkVQiOBDRuu(qlRSeLdFXBdyMFtSSEoQaxadAQI P_0)
		{
			if (P_0.PsKJxyXhYxofEzkrjdXLrJdXdjYc == PsKJxyXhYxofEzkrjdXLrJdXdjYc && P_0.iTlZorELHQDCESPLUCqUXMAKNVy == iTlZorELHQDCESPLUCqUXMAKNVy && P_0.KjaWgObGREamoandMdAXxTdnHIgu == KjaWgObGREamoandMdAXxTdnHIgu)
			{
				return P_0.zLmhKMibflLkQSoDRCyyswPKorV == zLmhKMibflLkQSoDRCyyswPKorV;
			}
			return false;
		}
	}

	private sealed class YPIUkZOgFhFFfZxPlfDscCpYbOh
	{
		public Action<InputActionEventData> PsKJxyXhYxofEzkrjdXLrJdXdjYc;

		public UpdateLoopType iTlZorELHQDCESPLUCqUXMAKNVy;

		public InputActionEventType zLmhKMibflLkQSoDRCyyswPKorV;

		public bool SKTHIhTqbbEIagaUAWyKTWacrqP(qlRSeLdFXBdyMFtSSEoQaxadAQI P_0)
		{
			if (P_0.PsKJxyXhYxofEzkrjdXLrJdXdjYc == PsKJxyXhYxofEzkrjdXLrJdXdjYc && P_0.iTlZorELHQDCESPLUCqUXMAKNVy == iTlZorELHQDCESPLUCqUXMAKNVy)
			{
				return P_0.zLmhKMibflLkQSoDRCyyswPKorV == zLmhKMibflLkQSoDRCyyswPKorV;
			}
			return false;
		}
	}

	private sealed class EIngTljJCHODttWTFEPVruKiHSIl
	{
		public Action<InputActionEventData> PsKJxyXhYxofEzkrjdXLrJdXdjYc;

		public InputActionEventType zLmhKMibflLkQSoDRCyyswPKorV;

		public int KjaWgObGREamoandMdAXxTdnHIgu;

		public bool McNlxyuqJXUXkAvVOtXgmRUFMaK(qlRSeLdFXBdyMFtSSEoQaxadAQI P_0)
		{
			if (P_0.PsKJxyXhYxofEzkrjdXLrJdXdjYc == PsKJxyXhYxofEzkrjdXLrJdXdjYc && P_0.KjaWgObGREamoandMdAXxTdnHIgu == KjaWgObGREamoandMdAXxTdnHIgu)
			{
				return P_0.zLmhKMibflLkQSoDRCyyswPKorV == zLmhKMibflLkQSoDRCyyswPKorV;
			}
			return false;
		}
	}

	private static qlRSeLdFXBdyMFtSSEoQaxadAQI[] nQmflHvRXXeYspZqJSZbYjVNZMD;

	private bool SqipAxIcjKKBSnKUcHhsIAAfbiWH;

	private AList<qlRSeLdFXBdyMFtSSEoQaxadAQI>[] ZeUqlSFDeTGEkWqFyXWfjvKVIIp;

	private int[] YzIamneRvTaDDrOjJehLmAKNPMLG;

	private int yDxvltcTYgguGZZcwssyYRzRXC;

	public int oTMfnUFSDYkBxxDhZXhMeSpBMuJB;

	[CompilerGenerated]
	private static Func<AList<qlRSeLdFXBdyMFtSSEoQaxadAQI>> ZCwIsrHovbcKJeKasXtvDGSZlUI;

	static PVHhzgaKOpHvKspvDHsmQsKUzPh()
	{
		nQmflHvRXXeYspZqJSZbYjVNZMD = new qlRSeLdFXBdyMFtSSEoQaxadAQI[100];
	}

	private void EJpmrTgGvrhKjJnkpXbomYBpQTQ()
	{
		if (!SqipAxIcjKKBSnKUcHhsIAAfbiWH)
		{
			IList<InputAction> actions = ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.Actions;
			int num = actions?.Count ?? 0;
			ZeUqlSFDeTGEkWqFyXWfjvKVIIp = new AList<qlRSeLdFXBdyMFtSSEoQaxadAQI>[num + 1];
			YzIamneRvTaDDrOjJehLmAKNPMLG = new int[ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.maxActionId + 1];
			ArrayTools.Populate(ZeUqlSFDeTGEkWqFyXWfjvKVIIp, 0, ZeUqlSFDeTGEkWqFyXWfjvKVIIp.Length, () => new AList<qlRSeLdFXBdyMFtSSEoQaxadAQI>());
			for (int num2 = 0; num2 < num; num2++)
			{
				YzIamneRvTaDDrOjJehLmAKNPMLG[actions[num2].id] = num2;
			}
			yDxvltcTYgguGZZcwssyYRzRXC = num;
			SqipAxIcjKKBSnKUcHhsIAAfbiWH = true;
		}
	}

	public void VUnKBfDOoQrNzLmkpdEWrOcmgOpa(dSBGNfhWmOBnJhxggXIGiXSpFLdE P_0, UpdateLoopType P_1)
	{
		AList<qlRSeLdFXBdyMFtSSEoQaxadAQI> aList = ZeUqlSFDeTGEkWqFyXWfjvKVIIp[YzIamneRvTaDDrOjJehLmAKNPMLG[P_0.sRbRrhSYcsdTbzpQQADExfvLSkq]];
		for (int i = 0; i < 2; i++)
		{
			if (i == 1)
			{
				aList = ZeUqlSFDeTGEkWqFyXWfjvKVIIp[yDxvltcTYgguGZZcwssyYRzRXC];
			}
			int count = aList._count;
			if (nQmflHvRXXeYspZqJSZbYjVNZMD.Length < count)
			{
				nQmflHvRXXeYspZqJSZbYjVNZMD = new qlRSeLdFXBdyMFtSSEoQaxadAQI[count + 50];
			}
			if (count > 0)
			{
				Array.Copy(aList._items, nQmflHvRXXeYspZqJSZbYjVNZMD, count);
			}
			for (int j = 0; j < count; j++)
			{
				qlRSeLdFXBdyMFtSSEoQaxadAQI qlRSeLdFXBdyMFtSSEoQaxadAQI2 = nQmflHvRXXeYspZqJSZbYjVNZMD[j];
				if (qlRSeLdFXBdyMFtSSEoQaxadAQI2 == null || (!P_0.cnfZfltfCQiONpFEGCqZjXcevaVW && !qlRSeLdFXBdyMFtSSEoQaxadAQI2.cOeEGAhBSXnizEHGbXOlSBBhTGrB) || qlRSeLdFXBdyMFtSSEoQaxadAQI2.iTlZorELHQDCESPLUCqUXMAKNVy != P_1 || (qlRSeLdFXBdyMFtSSEoQaxadAQI2.KjaWgObGREamoandMdAXxTdnHIgu >= 0 && qlRSeLdFXBdyMFtSSEoQaxadAQI2.KjaWgObGREamoandMdAXxTdnHIgu != P_0.sRbRrhSYcsdTbzpQQADExfvLSkq))
				{
					continue;
				}
				bool flag = false;
				switch (qlRSeLdFXBdyMFtSSEoQaxadAQI2.zLmhKMibflLkQSoDRCyyswPKorV)
				{
				case InputActionEventType.Update:
					flag = true;
					break;
				case InputActionEventType.ButtonPressed:
					if (P_0.tczGrLoSLQRKAWwrReBmbHatjKF())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonUnpressed:
					if (!P_0.tczGrLoSLQRKAWwrReBmbHatjKF())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonDoublePressed:
				{
					qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(0, out var num5);
					if (P_0.whhBjVbfHOZRjSSbvvVshFrslSsJ(num5))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonPressedForTime:
				{
					if (!qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(0, out var num11))
					{
						continue;
					}
					qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(1, out var num12);
					if (P_0.aDlFclJjaCPQLDrdiNxmhIBTyMI(num11, num12))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressed:
					if (P_0.dKbahpClgHBuTgUPoelgHzAZVwQ())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressed:
					if (P_0.fgiCbahJbtQhKcuDieKIRhCuqUh())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustPressed:
					if (P_0.wyMTjzWuSYHxxwaQSHqUbLUGgKg())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustReleased:
					if (P_0.KsQmhhakoIMsmFFssFWZgAtACAmj())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustDoublePressed:
				{
					qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(0, out var num9);
					if (P_0.QdNapEezgsjcIFSIbPqrnaMZYnq(num9))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonDoublePressJustReleased:
				{
					qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(0, out var num6);
					if (P_0.TtNcTNwxGEmdaqaGhItPkYvZUdO(num6))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustPressedForTime:
				{
					if (!qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(0, out var num4))
					{
						continue;
					}
					if (P_0.sJWIGDsUFDoKbNAvyOYaskgwHl(num4))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustShortPressed:
					if (P_0.axtYUltftYAAjLPpUwFjQcEktUM())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustLongPressed:
					if (P_0.iixuPYZWCGdNerQwVyFULoIHNjd())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonPressedForTimeJustReleased:
				{
					if (!qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(0, out var num15))
					{
						continue;
					}
					qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(1, out var num16);
					if (P_0.lCGBACeaSOuNLNMWNtxBERBspZZe(num15, num16))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressJustReleased:
					if (P_0.OeXCqNiCLCaJzCiThgBniwNKGycT())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressJustReleased:
					if (P_0.gGlIKclBCWWWrDZXIZMThojjQoM())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonRepeating:
					if (P_0.FmdAkBdCmGnmfuYHekqHitZeeAud())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressed:
					if (P_0.qGdIlqXDgmmfISyLXYdCpbxYquo())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustSinglePressed:
					if (P_0.bLTbjPpppdHjbxMklgpfIqXRyYp())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressJustReleased:
					if (P_0.uTpONumFLTkWQBGLiuKkYLcPhqBe())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressed:
					if (P_0.KpRTXcEtyGlzHQYXMAstvlyskee())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonUnpressed:
					if (!P_0.KpRTXcEtyGlzHQYXMAstvlyskee())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonDoublePressed:
				{
					qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(0, out var num3);
					if (P_0.OTglXCPZGItNKXZxLhhMYgiYbsV(num3))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonPressedForTime:
				{
					if (!qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(0, out var num))
					{
						continue;
					}
					qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(1, out var num2);
					if (P_0.tmlloKqIdCfFITAoOYARyaxEtyv(num, num2))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressed:
					if (P_0.TrIFGfGydgzIrCnTzSmtpMPcFRs())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressed:
					if (P_0.ibyWTTbBqaiJKzbJQgrdCnhaOoU())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustPressed:
					if (P_0.KyvdceKirMVFNQGItYflXrFbvzb())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustReleased:
					if (P_0.ZwUMSLHJcuYAbRcebDaGJalfcRoE())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustDoublePressed:
				{
					qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(0, out var num14);
					if (P_0.WyLjqxgprRvoNWgecDgFAQkYIrgd(num14))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonDoublePressJustReleased:
				{
					qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(0, out var num13);
					if (P_0.mjCeSzCOEPPLFcKnhpcBmZPiIPEW(num13))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustPressedForTime:
				{
					if (!qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(0, out var num10))
					{
						continue;
					}
					if (P_0.YtrbEJJmdYiNtYonULizSHGocQq(num10))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustShortPressed:
					if (P_0.wUSQKFPgCYLyOVIaLcaREOOgaSd())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustLongPressed:
					if (P_0.tQKWTalcnUHuIXUuxfVFuCyQaJWa())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				{
					if (!qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(0, out var num7))
					{
						continue;
					}
					qlRSeLdFXBdyMFtSSEoQaxadAQI2.PKuQoPgGrlXffBGFJxZftXpbZgR(1, out var num8);
					if (P_0.LIllZNjOorYAJCuobbEpGHmtgLG(num7, num8))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressJustReleased:
					if (P_0.rUpFbmIxUmCKBTXGxQRfuvWzAnM())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressJustReleased:
					if (P_0.zTPDXluCTGkSgLXaycbrprdTzeO())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonRepeating:
					if (P_0.TTtEvsDAazCbegtEELzSwGKHTrig())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressed:
					if (P_0.IVMAHIftfIRpuOqIAGjgiDkkRjin())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustSinglePressed:
					if (P_0.HbNlUNgsylguLzJPkeRobqoYHepA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressJustReleased:
					if (P_0.lwafttAKnLnDHJihTAGtqqzlIeee())
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActive:
					if (!MathTools.ApproximatelyZero(P_0.aKtyyQJXaksGFdepXiicilcqmAz()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisInactive:
					if (MathTools.ApproximatelyZero(P_0.aKtyyQJXaksGFdepXiicilcqmAz()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActive:
					if (!MathTools.ApproximatelyZero(P_0.bvPTHnqrzMoGbcmasrUYlTzxMan()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawInactive:
					if (MathTools.ApproximatelyZero(P_0.bvPTHnqrzMoGbcmasrUYlTzxMan()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.aKtyyQJXaksGFdepXiicilcqmAz()) || !MathTools.ApproximatelyZero(P_0.YuvFXJjoKbLzYOyrEHknhYlkvhl()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.bvPTHnqrzMoGbcmasrUYlTzxMan()) || !MathTools.ApproximatelyZero(P_0.aaRWGOqBZbRrpeNeRAkuZFnwpBQ()))
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
						InputActionEventData obj = P_0.PDMLXCKMrRsoRqWbKVJENBgjKZm(P_1);
						obj.eventType = qlRSeLdFXBdyMFtSSEoQaxadAQI2.zLmhKMibflLkQSoDRCyyswPKorV;
						qlRSeLdFXBdyMFtSSEoQaxadAQI2.PsKJxyXhYxofEzkrjdXLrJdXdjYc(obj);
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("Player input event callback", exception);
				}
			}
		}
	}

	public void kXumKtfSBwewksMrxulEXBnmjdWG(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
	{
		if (!SqipAxIcjKKBSnKUcHhsIAAfbiWH)
		{
			EJpmrTgGvrhKjJnkpXbomYBpQTQ();
		}
		qlRSeLdFXBdyMFtSSEoQaxadAQI item;
		try
		{
			if (P_3 > ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.maxActionId)
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + P_3);
			}
			item = new qlRSeLdFXBdyMFtSSEoQaxadAQI(P_0, P_1, P_2, P_3, P_4);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (P_3 < 0)
		{
			ZeUqlSFDeTGEkWqFyXWfjvKVIIp[yDxvltcTYgguGZZcwssyYRzRXC].Add(item);
		}
		else
		{
			ZeUqlSFDeTGEkWqFyXWfjvKVIIp[YzIamneRvTaDDrOjJehLmAKNPMLG[P_3]].Add(item);
		}
		xTJRtApxOOITTEmqnbWSwAVKUAA();
	}

	public void kXumKtfSBwewksMrxulEXBnmjdWG(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, object[] P_3)
	{
		if (!SqipAxIcjKKBSnKUcHhsIAAfbiWH)
		{
			EJpmrTgGvrhKjJnkpXbomYBpQTQ();
		}
		qlRSeLdFXBdyMFtSSEoQaxadAQI item;
		try
		{
			item = new qlRSeLdFXBdyMFtSSEoQaxadAQI(P_0, P_1, P_2, -1, P_3);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		ZeUqlSFDeTGEkWqFyXWfjvKVIIp[yDxvltcTYgguGZZcwssyYRzRXC].Add(item);
		xTJRtApxOOITTEmqnbWSwAVKUAA();
	}

	public void FCOtpjOvOZFuOGQPrGDxAJbQpGR(Action<InputActionEventData> P_0)
	{
		cShBdtOHIZIRqfbdggfHPrZuazCO cShBdtOHIZIRqfbdggfHPrZuazCO2 = new cShBdtOHIZIRqfbdggfHPrZuazCO();
		cShBdtOHIZIRqfbdggfHPrZuazCO2.PsKJxyXhYxofEzkrjdXLrJdXdjYc = P_0;
		if (SqipAxIcjKKBSnKUcHhsIAAfbiWH)
		{
			AList<qlRSeLdFXBdyMFtSSEoQaxadAQI>[] zeUqlSFDeTGEkWqFyXWfjvKVIIp = ZeUqlSFDeTGEkWqFyXWfjvKVIIp;
			foreach (AList<qlRSeLdFXBdyMFtSSEoQaxadAQI> aList in zeUqlSFDeTGEkWqFyXWfjvKVIIp)
			{
				aList.RemoveAll(cShBdtOHIZIRqfbdggfHPrZuazCO2.BVWUbHwHjOCvbaRxlsyFvKUgPVg);
			}
			xTJRtApxOOITTEmqnbWSwAVKUAA();
		}
	}

	public void FCOtpjOvOZFuOGQPrGDxAJbQpGR(Action<InputActionEventData> P_0, int P_1)
	{
		ssFppbUawZfUQTSvRRblAmvskes ssFppbUawZfUQTSvRRblAmvskes2 = new ssFppbUawZfUQTSvRRblAmvskes();
		ssFppbUawZfUQTSvRRblAmvskes2.PsKJxyXhYxofEzkrjdXLrJdXdjYc = P_0;
		ssFppbUawZfUQTSvRRblAmvskes2.KjaWgObGREamoandMdAXxTdnHIgu = P_1;
		if (SqipAxIcjKKBSnKUcHhsIAAfbiWH && ssFppbUawZfUQTSvRRblAmvskes2.KjaWgObGREamoandMdAXxTdnHIgu <= ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.maxActionId)
		{
			AList<qlRSeLdFXBdyMFtSSEoQaxadAQI>[] zeUqlSFDeTGEkWqFyXWfjvKVIIp = ZeUqlSFDeTGEkWqFyXWfjvKVIIp;
			foreach (AList<qlRSeLdFXBdyMFtSSEoQaxadAQI> aList in zeUqlSFDeTGEkWqFyXWfjvKVIIp)
			{
				aList.RemoveAll(ssFppbUawZfUQTSvRRblAmvskes2.nWohiuYfyUIlGAiStdzpFeDtnuTR);
			}
			xTJRtApxOOITTEmqnbWSwAVKUAA();
		}
	}

	public void FCOtpjOvOZFuOGQPrGDxAJbQpGR(Action<InputActionEventData> P_0, UpdateLoopType P_1)
	{
		VvmIHMhYGbdYmCAyGPviUKNzoHJ vvmIHMhYGbdYmCAyGPviUKNzoHJ = new VvmIHMhYGbdYmCAyGPviUKNzoHJ();
		vvmIHMhYGbdYmCAyGPviUKNzoHJ.PsKJxyXhYxofEzkrjdXLrJdXdjYc = P_0;
		vvmIHMhYGbdYmCAyGPviUKNzoHJ.iTlZorELHQDCESPLUCqUXMAKNVy = P_1;
		if (SqipAxIcjKKBSnKUcHhsIAAfbiWH)
		{
			AList<qlRSeLdFXBdyMFtSSEoQaxadAQI>[] zeUqlSFDeTGEkWqFyXWfjvKVIIp = ZeUqlSFDeTGEkWqFyXWfjvKVIIp;
			foreach (AList<qlRSeLdFXBdyMFtSSEoQaxadAQI> aList in zeUqlSFDeTGEkWqFyXWfjvKVIIp)
			{
				aList.RemoveAll(vvmIHMhYGbdYmCAyGPviUKNzoHJ.rWAhHEBZzjNNNZABZtNHHrOWRSC);
			}
			xTJRtApxOOITTEmqnbWSwAVKUAA();
		}
	}

	public void FCOtpjOvOZFuOGQPrGDxAJbQpGR(Action<InputActionEventData> P_0, InputActionEventType P_1)
	{
		BLwimDgclCssJrgLscHbxmDQwHZ bLwimDgclCssJrgLscHbxmDQwHZ = new BLwimDgclCssJrgLscHbxmDQwHZ();
		bLwimDgclCssJrgLscHbxmDQwHZ.PsKJxyXhYxofEzkrjdXLrJdXdjYc = P_0;
		bLwimDgclCssJrgLscHbxmDQwHZ.zLmhKMibflLkQSoDRCyyswPKorV = P_1;
		if (SqipAxIcjKKBSnKUcHhsIAAfbiWH)
		{
			AList<qlRSeLdFXBdyMFtSSEoQaxadAQI>[] zeUqlSFDeTGEkWqFyXWfjvKVIIp = ZeUqlSFDeTGEkWqFyXWfjvKVIIp;
			foreach (AList<qlRSeLdFXBdyMFtSSEoQaxadAQI> aList in zeUqlSFDeTGEkWqFyXWfjvKVIIp)
			{
				aList.RemoveAll(bLwimDgclCssJrgLscHbxmDQwHZ.yQNcEboMDqYFMnNoAVyuAJZhtuL);
			}
			xTJRtApxOOITTEmqnbWSwAVKUAA();
		}
	}

	public void FCOtpjOvOZFuOGQPrGDxAJbQpGR(Action<InputActionEventData> P_0, UpdateLoopType P_1, int P_2)
	{
		FXneLWGgdpQmULibVXuifUrNEXZ fXneLWGgdpQmULibVXuifUrNEXZ = new FXneLWGgdpQmULibVXuifUrNEXZ();
		fXneLWGgdpQmULibVXuifUrNEXZ.PsKJxyXhYxofEzkrjdXLrJdXdjYc = P_0;
		fXneLWGgdpQmULibVXuifUrNEXZ.iTlZorELHQDCESPLUCqUXMAKNVy = P_1;
		fXneLWGgdpQmULibVXuifUrNEXZ.KjaWgObGREamoandMdAXxTdnHIgu = P_2;
		if (SqipAxIcjKKBSnKUcHhsIAAfbiWH && fXneLWGgdpQmULibVXuifUrNEXZ.KjaWgObGREamoandMdAXxTdnHIgu <= ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.maxActionId)
		{
			AList<qlRSeLdFXBdyMFtSSEoQaxadAQI>[] zeUqlSFDeTGEkWqFyXWfjvKVIIp = ZeUqlSFDeTGEkWqFyXWfjvKVIIp;
			foreach (AList<qlRSeLdFXBdyMFtSSEoQaxadAQI> aList in zeUqlSFDeTGEkWqFyXWfjvKVIIp)
			{
				aList.RemoveAll(fXneLWGgdpQmULibVXuifUrNEXZ.qxTmRBAybCbcBnyzaevrmDeACoa);
			}
			xTJRtApxOOITTEmqnbWSwAVKUAA();
		}
	}

	public void FCOtpjOvOZFuOGQPrGDxAJbQpGR(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3)
	{
		mTOAGUXIsVZUBivpQqWOpiqmLd mTOAGUXIsVZUBivpQqWOpiqmLd2 = new mTOAGUXIsVZUBivpQqWOpiqmLd();
		mTOAGUXIsVZUBivpQqWOpiqmLd2.PsKJxyXhYxofEzkrjdXLrJdXdjYc = P_0;
		mTOAGUXIsVZUBivpQqWOpiqmLd2.iTlZorELHQDCESPLUCqUXMAKNVy = P_1;
		mTOAGUXIsVZUBivpQqWOpiqmLd2.zLmhKMibflLkQSoDRCyyswPKorV = P_2;
		mTOAGUXIsVZUBivpQqWOpiqmLd2.KjaWgObGREamoandMdAXxTdnHIgu = P_3;
		if (SqipAxIcjKKBSnKUcHhsIAAfbiWH && mTOAGUXIsVZUBivpQqWOpiqmLd2.KjaWgObGREamoandMdAXxTdnHIgu <= ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.maxActionId)
		{
			AList<qlRSeLdFXBdyMFtSSEoQaxadAQI>[] zeUqlSFDeTGEkWqFyXWfjvKVIIp = ZeUqlSFDeTGEkWqFyXWfjvKVIIp;
			foreach (AList<qlRSeLdFXBdyMFtSSEoQaxadAQI> aList in zeUqlSFDeTGEkWqFyXWfjvKVIIp)
			{
				aList.RemoveAll(mTOAGUXIsVZUBivpQqWOpiqmLd2.JsqSBRsExFTEyzheBkVQiOBDRuu);
			}
			xTJRtApxOOITTEmqnbWSwAVKUAA();
		}
	}

	public void FCOtpjOvOZFuOGQPrGDxAJbQpGR(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2)
	{
		YPIUkZOgFhFFfZxPlfDscCpYbOh yPIUkZOgFhFFfZxPlfDscCpYbOh = new YPIUkZOgFhFFfZxPlfDscCpYbOh();
		yPIUkZOgFhFFfZxPlfDscCpYbOh.PsKJxyXhYxofEzkrjdXLrJdXdjYc = P_0;
		yPIUkZOgFhFFfZxPlfDscCpYbOh.iTlZorELHQDCESPLUCqUXMAKNVy = P_1;
		yPIUkZOgFhFFfZxPlfDscCpYbOh.zLmhKMibflLkQSoDRCyyswPKorV = P_2;
		if (SqipAxIcjKKBSnKUcHhsIAAfbiWH)
		{
			AList<qlRSeLdFXBdyMFtSSEoQaxadAQI>[] zeUqlSFDeTGEkWqFyXWfjvKVIIp = ZeUqlSFDeTGEkWqFyXWfjvKVIIp;
			foreach (AList<qlRSeLdFXBdyMFtSSEoQaxadAQI> aList in zeUqlSFDeTGEkWqFyXWfjvKVIIp)
			{
				aList.RemoveAll(yPIUkZOgFhFFfZxPlfDscCpYbOh.SKTHIhTqbbEIagaUAWyKTWacrqP);
			}
			xTJRtApxOOITTEmqnbWSwAVKUAA();
		}
	}

	public void FCOtpjOvOZFuOGQPrGDxAJbQpGR(Action<InputActionEventData> P_0, InputActionEventType P_1, int P_2)
	{
		EIngTljJCHODttWTFEPVruKiHSIl eIngTljJCHODttWTFEPVruKiHSIl = new EIngTljJCHODttWTFEPVruKiHSIl();
		eIngTljJCHODttWTFEPVruKiHSIl.PsKJxyXhYxofEzkrjdXLrJdXdjYc = P_0;
		eIngTljJCHODttWTFEPVruKiHSIl.zLmhKMibflLkQSoDRCyyswPKorV = P_1;
		eIngTljJCHODttWTFEPVruKiHSIl.KjaWgObGREamoandMdAXxTdnHIgu = P_2;
		if (SqipAxIcjKKBSnKUcHhsIAAfbiWH && eIngTljJCHODttWTFEPVruKiHSIl.KjaWgObGREamoandMdAXxTdnHIgu <= ReInput.bmLEnbkKNrTNSFrbOCrmcDPSGZKL.maxActionId)
		{
			AList<qlRSeLdFXBdyMFtSSEoQaxadAQI>[] zeUqlSFDeTGEkWqFyXWfjvKVIIp = ZeUqlSFDeTGEkWqFyXWfjvKVIIp;
			foreach (AList<qlRSeLdFXBdyMFtSSEoQaxadAQI> aList in zeUqlSFDeTGEkWqFyXWfjvKVIIp)
			{
				aList.RemoveAll(eIngTljJCHODttWTFEPVruKiHSIl.McNlxyuqJXUXkAvVOtXgmRUFMaK);
			}
			xTJRtApxOOITTEmqnbWSwAVKUAA();
		}
	}

	public void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
	{
		if (SqipAxIcjKKBSnKUcHhsIAAfbiWH)
		{
			AList<qlRSeLdFXBdyMFtSSEoQaxadAQI>[] zeUqlSFDeTGEkWqFyXWfjvKVIIp = ZeUqlSFDeTGEkWqFyXWfjvKVIIp;
			foreach (AList<qlRSeLdFXBdyMFtSSEoQaxadAQI> aList in zeUqlSFDeTGEkWqFyXWfjvKVIIp)
			{
				aList.Clear();
			}
			xTJRtApxOOITTEmqnbWSwAVKUAA();
		}
	}

	private void xTJRtApxOOITTEmqnbWSwAVKUAA()
	{
		int num = 0;
		for (int i = 0; i < ZeUqlSFDeTGEkWqFyXWfjvKVIIp.Length; i++)
		{
			num += ZeUqlSFDeTGEkWqFyXWfjvKVIIp[i]._count;
		}
		oTMfnUFSDYkBxxDhZXhMeSpBMuJB = num;
	}

	[CompilerGenerated]
	private static AList<qlRSeLdFXBdyMFtSSEoQaxadAQI> HQlXUbsSZKLuqebuHsnynGLvkkn()
	{
		return new AList<qlRSeLdFXBdyMFtSSEoQaxadAQI>();
	}
}
