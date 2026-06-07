using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class LdsHxqbGmxTBArOjZEjqxDHHBqlCb
{
	public class kCBhwSapkGYeQoxEcFteDpxaVwfzb
	{
		public readonly Action<InputActionEventData> wHkDVxclUtIWpoiCVRiGtCjCEWGM;

		public readonly UpdateLoopType ABsJJsQavqqEpyeKgfjreCDaVKoL;

		public readonly InputActionEventType IKPBvvpBwFzqwTogowZVidpROeCI;

		public readonly int lrMdAPkoEPjGlwCsgDIsOxoUxUtH;

		public readonly bool yZsVDUhCXAHmqRZHXfLTeiMZLjNI;

		public float[] abcvXZTICHmXwMWuLoxcskZAVnNJ;

		public kCBhwSapkGYeQoxEcFteDpxaVwfzb(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
		{
			ABsJJsQavqqEpyeKgfjreCDaVKoL = P_1;
			IKPBvvpBwFzqwTogowZVidpROeCI = P_2;
			lrMdAPkoEPjGlwCsgDIsOxoUxUtH = P_3;
			wHkDVxclUtIWpoiCVRiGtCjCEWGM = P_0;
			PLyWrqYqpsuNDckyOVjymUFolnBM(P_4);
			switch (P_2)
			{
			case InputActionEventType.Update:
			case InputActionEventType.ButtonUnpressed:
			case InputActionEventType.NegativeButtonUnpressed:
			case InputActionEventType.AxisInactive:
			case InputActionEventType.AxisRawInactive:
				yZsVDUhCXAHmqRZHXfLTeiMZLjNI = true;
				break;
			}
		}

		public bool oToRopwFlLVeJNWqLOPWTzZfDioN(int P_0, out float P_1)
		{
			if (abcvXZTICHmXwMWuLoxcskZAVnNJ == null || abcvXZTICHmXwMWuLoxcskZAVnNJ.Length <= P_0)
			{
				P_1 = 0f;
				return false;
			}
			P_1 = abcvXZTICHmXwMWuLoxcskZAVnNJ[P_0];
			return true;
		}

		private void PLyWrqYqpsuNDckyOVjymUFolnBM(object[] P_0)
		{
			switch (IKPBvvpBwFzqwTogowZVidpROeCI)
			{
			case InputActionEventType.ButtonPressedForTime:
			case InputActionEventType.ButtonPressedForTimeJustReleased:
			case InputActionEventType.NegativeButtonPressedForTime:
			case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + IKPBvvpBwFzqwTogowZVidpROeCI.ToString() + "\". 1 required argument: time [float], 1 optional argument: expireIn [float]");
				}
				abcvXZTICHmXwMWuLoxcskZAVnNJ = new float[2];
				if (P_0[0] is float)
				{
					abcvXZTICHmXwMWuLoxcskZAVnNJ[0] = (float)P_0[0];
				}
				else
				{
					if (!(P_0[0] is int))
					{
						throw new Exception("Wrong argument type passed for Input event type \"" + IKPBvvpBwFzqwTogowZVidpROeCI.ToString() + "\". Argument 0: time [float]");
					}
					abcvXZTICHmXwMWuLoxcskZAVnNJ[0] = (int)P_0[0];
				}
				if (P_0.Length <= 1)
				{
					break;
				}
				if (P_0[1] is float)
				{
					abcvXZTICHmXwMWuLoxcskZAVnNJ[1] = (float)P_0[1];
					break;
				}
				if (P_0[1] is int)
				{
					abcvXZTICHmXwMWuLoxcskZAVnNJ[1] = (int)P_0[1];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + IKPBvvpBwFzqwTogowZVidpROeCI.ToString() + "\". Argument 1 (optional): expireIn [float]");
			case InputActionEventType.ButtonJustPressedForTime:
			case InputActionEventType.NegativeButtonJustPressedForTime:
				if (P_0 == null || P_0.Length < 1)
				{
					throw new Exception("Wrong number of arguments passed for Input event type \"" + IKPBvvpBwFzqwTogowZVidpROeCI.ToString() + "\". Requires 1 argument: time [float]");
				}
				abcvXZTICHmXwMWuLoxcskZAVnNJ = new float[1];
				if (P_0[0] is float)
				{
					abcvXZTICHmXwMWuLoxcskZAVnNJ[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					abcvXZTICHmXwMWuLoxcskZAVnNJ[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + IKPBvvpBwFzqwTogowZVidpROeCI.ToString() + "\". Argument 0: time [float]");
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
				abcvXZTICHmXwMWuLoxcskZAVnNJ = new float[1];
				if (P_0[0] is float)
				{
					abcvXZTICHmXwMWuLoxcskZAVnNJ[0] = (float)P_0[0];
					break;
				}
				if (P_0[0] is int)
				{
					abcvXZTICHmXwMWuLoxcskZAVnNJ[0] = (int)P_0[0];
					break;
				}
				throw new Exception("Wrong argument type passed for Input event type \"" + IKPBvvpBwFzqwTogowZVidpROeCI.ToString() + "\". Argument 0 (optional): time [float]");
			}
		}
	}

	[Serializable]
	private sealed class fOydPnDTMqogJSZfnRDxXhtobeMU
	{
		public static readonly fOydPnDTMqogJSZfnRDxXhtobeMU _003C_003E9 = new fOydPnDTMqogJSZfnRDxXhtobeMU();

		public static Func<AList<kCBhwSapkGYeQoxEcFteDpxaVwfzb>> _003C_003E9__8_0;

		internal AList<kCBhwSapkGYeQoxEcFteDpxaVwfzb> iOXEuoZJyehPCXRfijjRCaOcjVHUA()
		{
			return new AList<kCBhwSapkGYeQoxEcFteDpxaVwfzb>();
		}
	}

	private sealed class eDVLLQtRXrbuOxHVVbvnaZNsKGaKA
	{
		public Action<InputActionEventData> nEUCVrdVGpMlWASQBecAWdwTDrWeb;

		public Predicate<kCBhwSapkGYeQoxEcFteDpxaVwfzb> QPewbvGwxxFbcLhsjvXbOXvVSZYs;

		internal bool UhWHktrmEowTwtnVsRATmLeovEdm(kCBhwSapkGYeQoxEcFteDpxaVwfzb P_0)
		{
			return P_0.wHkDVxclUtIWpoiCVRiGtCjCEWGM == nEUCVrdVGpMlWASQBecAWdwTDrWeb;
		}
	}

	private sealed class DjQQDbwiHchvhmiWyeRaufysFYRfA
	{
		public Action<InputActionEventData> cvMNiUUeUmoHPXlCJGGRkyUPkmaVA;

		public int miXXCRjyCMmHsuCtXHcTRHeHZndm;

		public Predicate<kCBhwSapkGYeQoxEcFteDpxaVwfzb> GsIhnAlAVVaNdYUwMFijqTPVmslU;

		internal bool vcjOtDYrFGZAknbQyoPRxGBaWCID(kCBhwSapkGYeQoxEcFteDpxaVwfzb P_0)
		{
			if (P_0.wHkDVxclUtIWpoiCVRiGtCjCEWGM == cvMNiUUeUmoHPXlCJGGRkyUPkmaVA)
			{
				return P_0.lrMdAPkoEPjGlwCsgDIsOxoUxUtH == miXXCRjyCMmHsuCtXHcTRHeHZndm;
			}
			return false;
		}
	}

	private sealed class cbTmDfqlpSxYsKkYtluQtIWEVKz
	{
		public Action<InputActionEventData> CisRfspnUxLeEbOfxXFBUuikHQYB;

		public UpdateLoopType AhSucKMlpFHSlWaVGewgWsovuwPh;

		public Predicate<kCBhwSapkGYeQoxEcFteDpxaVwfzb> LLptGpDNsLbXUGjYNfyMnjTKlWrL;

		internal bool crMlXSUbAQkWEwEFhinImAnwwLVT(kCBhwSapkGYeQoxEcFteDpxaVwfzb P_0)
		{
			if (P_0.wHkDVxclUtIWpoiCVRiGtCjCEWGM == CisRfspnUxLeEbOfxXFBUuikHQYB)
			{
				return P_0.ABsJJsQavqqEpyeKgfjreCDaVKoL == AhSucKMlpFHSlWaVGewgWsovuwPh;
			}
			return false;
		}
	}

	private sealed class qLNjpcUkMyzjCakBJtgyEzToRifW
	{
		public Action<InputActionEventData> rszCoCWWMZnujsVuFSHTyQIDzKQb;

		public InputActionEventType TxRxDiISNlxSwUTGahiZszBpQcdk;

		public Predicate<kCBhwSapkGYeQoxEcFteDpxaVwfzb> WdfvbHCFTBaWOSeWMBRXwLWyyJgg;

		internal bool MOoSYcRcNVqEYvdExwVWuKLJOcmh(kCBhwSapkGYeQoxEcFteDpxaVwfzb P_0)
		{
			if (P_0.wHkDVxclUtIWpoiCVRiGtCjCEWGM == rszCoCWWMZnujsVuFSHTyQIDzKQb)
			{
				return P_0.IKPBvvpBwFzqwTogowZVidpROeCI == TxRxDiISNlxSwUTGahiZszBpQcdk;
			}
			return false;
		}
	}

	private sealed class mCWyEGUbCGLjunAvYEPDFbBfCFZT
	{
		public Action<InputActionEventData> ginmjELTfuRaeNuXfsnVYkvkXCGc;

		public UpdateLoopType ZxlhigwCNoabZElVtJZFyEZrFzlFA;

		public int XQwVJfSTGfLcuEKXXKnJColKGtgH;

		public Predicate<kCBhwSapkGYeQoxEcFteDpxaVwfzb> BffoCEnLrUOklrSrHwKRGOBLgAN;

		internal bool DklcoptEwtyieAhoQtdIqpwyAeJp(kCBhwSapkGYeQoxEcFteDpxaVwfzb P_0)
		{
			if (P_0.wHkDVxclUtIWpoiCVRiGtCjCEWGM == ginmjELTfuRaeNuXfsnVYkvkXCGc && P_0.ABsJJsQavqqEpyeKgfjreCDaVKoL == ZxlhigwCNoabZElVtJZFyEZrFzlFA)
			{
				return P_0.lrMdAPkoEPjGlwCsgDIsOxoUxUtH == XQwVJfSTGfLcuEKXXKnJColKGtgH;
			}
			return false;
		}
	}

	private sealed class nzXUKwabIjEBpjtOucHvKoaYuHAJA
	{
		public Action<InputActionEventData> ddPTtkgqogAhcEWQddqjhuMFUOkPA;

		public UpdateLoopType qnJEXZmVkzLuStlksdvrMyPrfxxd;

		public int CvxqBgjPCZFKUxGtRSDAmDwqGXeE;

		public InputActionEventType vJQmfMdSNdajhqnMIMPycxDeOlNu;

		public Predicate<kCBhwSapkGYeQoxEcFteDpxaVwfzb> VZrDqdAnjWkLSvHutTXXSDkRPcYp;

		internal bool dwMquBRhRkrZvBchZDTUDHBTLzbcb(kCBhwSapkGYeQoxEcFteDpxaVwfzb P_0)
		{
			if (P_0.wHkDVxclUtIWpoiCVRiGtCjCEWGM == ddPTtkgqogAhcEWQddqjhuMFUOkPA && P_0.ABsJJsQavqqEpyeKgfjreCDaVKoL == qnJEXZmVkzLuStlksdvrMyPrfxxd && P_0.lrMdAPkoEPjGlwCsgDIsOxoUxUtH == CvxqBgjPCZFKUxGtRSDAmDwqGXeE)
			{
				return P_0.IKPBvvpBwFzqwTogowZVidpROeCI == vJQmfMdSNdajhqnMIMPycxDeOlNu;
			}
			return false;
		}
	}

	private sealed class KWhDVBgkdJOhtqpfMqJMgJsTFUIS
	{
		public Action<InputActionEventData> liPPGdHfvEIXTLrFUeMcTYmNDTBr;

		public UpdateLoopType KFalCzzkQMZMAjhQuGcqcMFHEuWq;

		public InputActionEventType vtdohnPLYfofhJrnnaibPXqKbwXA;

		public Predicate<kCBhwSapkGYeQoxEcFteDpxaVwfzb> oYGVeXMFzRRuvNcuMVflTKmtiHpA;

		internal bool YErzqjFYmtbHyylZLDuNTfoEgBJN(kCBhwSapkGYeQoxEcFteDpxaVwfzb P_0)
		{
			if (P_0.wHkDVxclUtIWpoiCVRiGtCjCEWGM == liPPGdHfvEIXTLrFUeMcTYmNDTBr && P_0.ABsJJsQavqqEpyeKgfjreCDaVKoL == KFalCzzkQMZMAjhQuGcqcMFHEuWq)
			{
				return P_0.IKPBvvpBwFzqwTogowZVidpROeCI == vtdohnPLYfofhJrnnaibPXqKbwXA;
			}
			return false;
		}
	}

	private sealed class nXoukXqfGHDuqCHGGJWswYFeSbpi
	{
		public Action<InputActionEventData> OWUJlgYsjFRXeoKyeiirEoYBgOsV;

		public int aBPhKcgtAiybuusKcQlrhSREoXwZ;

		public InputActionEventType zisJjtvjVmpeYKUUWpaefpGLwmKp;

		public Predicate<kCBhwSapkGYeQoxEcFteDpxaVwfzb> uylFAuMzAPzMgivvqgNIsTvtOHl;

		internal bool eUcsbSnGPjTTbJuvIGAuRFZrRiHA(kCBhwSapkGYeQoxEcFteDpxaVwfzb P_0)
		{
			if (P_0.wHkDVxclUtIWpoiCVRiGtCjCEWGM == OWUJlgYsjFRXeoKyeiirEoYBgOsV && P_0.lrMdAPkoEPjGlwCsgDIsOxoUxUtH == aBPhKcgtAiybuusKcQlrhSREoXwZ)
			{
				return P_0.IKPBvvpBwFzqwTogowZVidpROeCI == zisJjtvjVmpeYKUUWpaefpGLwmKp;
			}
			return false;
		}
	}

	private static kCBhwSapkGYeQoxEcFteDpxaVwfzb[] yBUaMkiPEhYYOzRJoajNdkxqNRgXA;

	private bool vZzrBAsDQPSWeMgqojpijTXyuwNG;

	private AList<kCBhwSapkGYeQoxEcFteDpxaVwfzb>[] phoPZjQLkYTxcrVWpJFfSLjvAPUF;

	private int[] lodeqiiglBjtxxjQrdUymdogsNFo;

	private int ZLQvaAKrxAYzvBannLxbtfqzsIsQ;

	public int yOnjoPaBDNywJUmXvRAZOrofPUFF;

	static LdsHxqbGmxTBArOjZEjqxDHHBqlCb()
	{
		yBUaMkiPEhYYOzRJoajNdkxqNRgXA = new kCBhwSapkGYeQoxEcFteDpxaVwfzb[100];
	}

	private void TiTzRmXIoUPBDqxFbiwdicEJDaCeA()
	{
		if (!vZzrBAsDQPSWeMgqojpijTXyuwNG)
		{
			IList<InputAction> list = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.nBhOyBMUUwEcliaRuIBSgZoZtveD;
			int num = list?.Count ?? 0;
			phoPZjQLkYTxcrVWpJFfSLjvAPUF = new AList<kCBhwSapkGYeQoxEcFteDpxaVwfzb>[num + 1];
			lodeqiiglBjtxxjQrdUymdogsNFo = new int[ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.eHkaHMARfQIlOsYaKzrQtIClDjZDb + 1];
			ArrayTools.Populate(phoPZjQLkYTxcrVWpJFfSLjvAPUF, 0, phoPZjQLkYTxcrVWpJFfSLjvAPUF.Length, fOydPnDTMqogJSZfnRDxXhtobeMU._003C_003E9.iOXEuoZJyehPCXRfijjRCaOcjVHUA);
			for (int i = 0; i < num; i++)
			{
				lodeqiiglBjtxxjQrdUymdogsNFo[list[i].id] = i;
			}
			ZLQvaAKrxAYzvBannLxbtfqzsIsQ = num;
			vZzrBAsDQPSWeMgqojpijTXyuwNG = true;
		}
	}

	public void rFtUdyOpkeEzmCkhaxJjErxppjSh(dhgRPzBCLEtjJBicagpEtUtuCThf P_0, UpdateLoopType P_1)
	{
		AList<kCBhwSapkGYeQoxEcFteDpxaVwfzb> aList = phoPZjQLkYTxcrVWpJFfSLjvAPUF[lodeqiiglBjtxxjQrdUymdogsNFo[P_0.gThDGGahVrkGVUmHdIHCQawpVmoTA]];
		for (int i = 0; i < 2; i++)
		{
			if (i == 1)
			{
				aList = phoPZjQLkYTxcrVWpJFfSLjvAPUF[ZLQvaAKrxAYzvBannLxbtfqzsIsQ];
			}
			int count = aList._count;
			if (yBUaMkiPEhYYOzRJoajNdkxqNRgXA.Length < count)
			{
				yBUaMkiPEhYYOzRJoajNdkxqNRgXA = new kCBhwSapkGYeQoxEcFteDpxaVwfzb[count + 50];
			}
			if (count > 0)
			{
				Array.Copy(aList._items, yBUaMkiPEhYYOzRJoajNdkxqNRgXA, count);
			}
			for (int j = 0; j < count; j++)
			{
				kCBhwSapkGYeQoxEcFteDpxaVwfzb kCBhwSapkGYeQoxEcFteDpxaVwfzb2 = yBUaMkiPEhYYOzRJoajNdkxqNRgXA[j];
				if (kCBhwSapkGYeQoxEcFteDpxaVwfzb2 == null || (!P_0.WmWiBISaHWdFdCGJxDekUIhZTvTl && !kCBhwSapkGYeQoxEcFteDpxaVwfzb2.yZsVDUhCXAHmqRZHXfLTeiMZLjNI) || kCBhwSapkGYeQoxEcFteDpxaVwfzb2.ABsJJsQavqqEpyeKgfjreCDaVKoL != P_1 || (kCBhwSapkGYeQoxEcFteDpxaVwfzb2.lrMdAPkoEPjGlwCsgDIsOxoUxUtH >= 0 && kCBhwSapkGYeQoxEcFteDpxaVwfzb2.lrMdAPkoEPjGlwCsgDIsOxoUxUtH != P_0.gThDGGahVrkGVUmHdIHCQawpVmoTA))
				{
					continue;
				}
				bool flag = false;
				switch (kCBhwSapkGYeQoxEcFteDpxaVwfzb2.IKPBvvpBwFzqwTogowZVidpROeCI)
				{
				case InputActionEventType.Update:
					flag = true;
					break;
				case InputActionEventType.ButtonPressed:
					if (P_0.MxEcNwtqdlIeerRnDukWeLuLhuJf())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonUnpressed:
					if (!P_0.MxEcNwtqdlIeerRnDukWeLuLhuJf())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonDoublePressed:
				{
					kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(0, out var num5);
					if (P_0.xGzEFpGsojiRndDhgKgoTOCODuKHB(num5))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonPressedForTime:
				{
					if (!kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(0, out var num11))
					{
						continue;
					}
					kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(1, out var num12);
					if (P_0.qozCBEkJHtwbCPinkrfRknkdhoqeb(num11, num12))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressed:
					if (P_0.UbUVWSbJsilCmSHGMfehdGYCIgCW())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressed:
					if (P_0.LmfrdlDnMtLuYDOWHWUteOtwwgQN())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustPressed:
					if (P_0.rXrZPQfPVJBUbrjAjiOwpsbsoMBx())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustReleased:
					if (P_0.rrhxDOjcPWqQgLfbTarpEkBOkrpI())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustDoublePressed:
				{
					kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(0, out var num9);
					if (P_0.gLJFtiAyWSigKkAxGnnnHaGHaSXZ(num9))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonDoublePressJustReleased:
				{
					kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(0, out var num6);
					if (P_0.UJzDLqngfKZfwwGFxLGcXaeidbxL(num6))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustPressedForTime:
				{
					if (!kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(0, out var num4))
					{
						continue;
					}
					if (P_0.jVjJkYKrrNEiZSHbnGbmIcYwvyOO(num4))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonJustShortPressed:
					if (P_0.GQiBxAivXCVFEsHXHZjXqdpTfmLc())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustLongPressed:
					if (P_0.fITinqfPzqbfabpxMpdpXBmDXFlv())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonPressedForTimeJustReleased:
				{
					if (!kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(0, out var num15))
					{
						continue;
					}
					kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(1, out var num16);
					if (P_0.GBgOspgmWlzNTXGUrDJdabTMgeLbb(num15, num16))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.ButtonShortPressJustReleased:
					if (P_0.qlKBOPfbpvRTxIgGgYfNUsruDPswA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonLongPressJustReleased:
					if (P_0.miaYeVbqUiWlNiWtwobHLCmPYlNd())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonRepeating:
					if (P_0.wFjQJJLAvFQAiYmkUddgklxfsbWHA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressed:
					if (P_0.IMesJCWkGWMkoFOzoNTQcWNjPzhC())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonJustSinglePressed:
					if (P_0.OIdzQJjuZVtKkZuiimJuXxTbGrpS())
					{
						flag = true;
					}
					break;
				case InputActionEventType.ButtonSinglePressJustReleased:
					if (P_0.KzdFwycHikmAYbIGeasoFGFhyGKTB())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressed:
					if (P_0.UmCYrzZMweTSJRYbCywvSFwqDXcv())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonUnpressed:
					if (!P_0.UmCYrzZMweTSJRYbCywvSFwqDXcv())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonDoublePressed:
				{
					kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(0, out var num3);
					if (P_0.IOKNZPyiJUFNvjeFKQCCUSZGeVLc(num3))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonPressedForTime:
				{
					if (!kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(0, out var num))
					{
						continue;
					}
					kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(1, out var num2);
					if (P_0.MbiGHOFuOrudkJTfefnEApGkcIcZB(num, num2))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressed:
					if (P_0.fekVflJRTBrwpLSQSFoanCIvRlAy())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressed:
					if (P_0.FRQHTzPnYughiSpCuiHJGALtWMmPA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustPressed:
					if (P_0.SXkkCHQJRMzOMmxushyoGBTkBdoIA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustReleased:
					if (P_0.TagQxdEpgEJNLcLxWDqJBKBfzXpOA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustDoublePressed:
				{
					kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(0, out var num14);
					if (P_0.WbGXiRufRLdVFrbmBJNuPjWWTCZj(num14))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonDoublePressJustReleased:
				{
					kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(0, out var num13);
					if (P_0.sJXRlomLwvumiMtlrFCyzJDlKXYd(num13))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustPressedForTime:
				{
					if (!kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(0, out var num10))
					{
						continue;
					}
					if (P_0.bCRGhyLPrIrwZcSBolJdJdKGiajh(num10))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonJustShortPressed:
					if (P_0.nwHOEJwTdZLLNSGpDtDXAvEyveRv())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustLongPressed:
					if (P_0.hOSuOVrMBzfKDtHoTIHnFcQXgnWSA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonPressedForTimeJustReleased:
				{
					if (!kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(0, out var num7))
					{
						continue;
					}
					kCBhwSapkGYeQoxEcFteDpxaVwfzb2.oToRopwFlLVeJNWqLOPWTzZfDioN(1, out var num8);
					if (P_0.YTAjZKfozgkhUNaQeJhmPdPaeWoJ(num7, num8))
					{
						flag = true;
					}
					break;
				}
				case InputActionEventType.NegativeButtonShortPressJustReleased:
					if (P_0.GaqpYWpDXSGJnuNRYvOQFpdCdgDX())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonLongPressJustReleased:
					if (P_0.SAtfgtyMVjIlidHIgorrvnAuINli())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonRepeating:
					if (P_0.hpKBlFdTbcLxxEDttXJWVHxJfGLTA())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressed:
					if (P_0.btfJMvnFgnhSOnWsOHJeYcVCLnPl())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonJustSinglePressed:
					if (P_0.NnjhgnrvOwajKeXwSEqNBRvoSlWB())
					{
						flag = true;
					}
					break;
				case InputActionEventType.NegativeButtonSinglePressJustReleased:
					if (P_0.JbBDNNzhKAhAleqsuVYMGJoVCIgj())
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActive:
					if (!MathTools.ApproximatelyZero(P_0.YUjfnjGGGnqMPGxXAPaENJeIDUqWc()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisInactive:
					if (MathTools.ApproximatelyZero(P_0.YUjfnjGGGnqMPGxXAPaENJeIDUqWc()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActive:
					if (!MathTools.ApproximatelyZero(P_0.TCDdfCbKggAPtiwQGokuKSEFYXbDA()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawInactive:
					if (MathTools.ApproximatelyZero(P_0.TCDdfCbKggAPtiwQGokuKSEFYXbDA()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.YUjfnjGGGnqMPGxXAPaENJeIDUqWc()) || !MathTools.ApproximatelyZero(P_0.gFAaxRimefDUHASXCLCgGaxeRyOBA()))
					{
						flag = true;
					}
					break;
				case InputActionEventType.AxisRawActiveOrJustInactive:
					if (!MathTools.ApproximatelyZero(P_0.TCDdfCbKggAPtiwQGokuKSEFYXbDA()) || !MathTools.ApproximatelyZero(P_0.GzjLUajTFUHUlvGsMBpskFQeAJPjA()))
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
						InputActionEventData obj = P_0.YIvfKyxmHCxjwSjaaYFPnFsnMvAH(P_1);
						obj.eventType = kCBhwSapkGYeQoxEcFteDpxaVwfzb2.IKPBvvpBwFzqwTogowZVidpROeCI;
						kCBhwSapkGYeQoxEcFteDpxaVwfzb2.wHkDVxclUtIWpoiCVRiGtCjCEWGM(obj);
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("Player input event callback", exception);
				}
			}
		}
	}

	public void OkFbXbxroeIzfdsXNnvEDSPdDhoCb(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3, object[] P_4)
	{
		if (!vZzrBAsDQPSWeMgqojpijTXyuwNG)
		{
			TiTzRmXIoUPBDqxFbiwdicEJDaCeA();
		}
		kCBhwSapkGYeQoxEcFteDpxaVwfzb item;
		try
		{
			if (P_3 > ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.eHkaHMARfQIlOsYaKzrQtIClDjZDb)
			{
				throw new ArgumentOutOfRangeException("Invalid Action Id " + P_3);
			}
			item = new kCBhwSapkGYeQoxEcFteDpxaVwfzb(P_0, P_1, P_2, P_3, P_4);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		if (P_3 < 0)
		{
			phoPZjQLkYTxcrVWpJFfSLjvAPUF[ZLQvaAKrxAYzvBannLxbtfqzsIsQ].Add(item);
		}
		else
		{
			phoPZjQLkYTxcrVWpJFfSLjvAPUF[lodeqiiglBjtxxjQrdUymdogsNFo[P_3]].Add(item);
		}
		GNaUDDREswnbsKVLytONBolgdelaA();
	}

	public void qZtChTEmlalmGAZddPoslSIGmVQab(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, object[] P_3)
	{
		if (!vZzrBAsDQPSWeMgqojpijTXyuwNG)
		{
			TiTzRmXIoUPBDqxFbiwdicEJDaCeA();
		}
		kCBhwSapkGYeQoxEcFteDpxaVwfzb item;
		try
		{
			item = new kCBhwSapkGYeQoxEcFteDpxaVwfzb(P_0, P_1, P_2, -1, P_3);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Failed to add Input Event delegate. Reason: " + ex.Message);
			return;
		}
		phoPZjQLkYTxcrVWpJFfSLjvAPUF[ZLQvaAKrxAYzvBannLxbtfqzsIsQ].Add(item);
		GNaUDDREswnbsKVLytONBolgdelaA();
	}

	public void dzrMPFHAelvClsaAHjPibyakoOJiA(Action<InputActionEventData> P_0)
	{
		eDVLLQtRXrbuOxHVVbvnaZNsKGaKA eDVLLQtRXrbuOxHVVbvnaZNsKGaKA2 = new eDVLLQtRXrbuOxHVVbvnaZNsKGaKA();
		eDVLLQtRXrbuOxHVVbvnaZNsKGaKA2.nEUCVrdVGpMlWASQBecAWdwTDrWeb = P_0;
		if (vZzrBAsDQPSWeMgqojpijTXyuwNG)
		{
			AList<kCBhwSapkGYeQoxEcFteDpxaVwfzb>[] array = phoPZjQLkYTxcrVWpJFfSLjvAPUF;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(eDVLLQtRXrbuOxHVVbvnaZNsKGaKA2.UhWHktrmEowTwtnVsRATmLeovEdm);
			}
			GNaUDDREswnbsKVLytONBolgdelaA();
		}
	}

	public void tIUdKOFJPSGeYSNSnEXuXXUCfSjy(Action<InputActionEventData> P_0, int P_1)
	{
		DjQQDbwiHchvhmiWyeRaufysFYRfA djQQDbwiHchvhmiWyeRaufysFYRfA = new DjQQDbwiHchvhmiWyeRaufysFYRfA();
		djQQDbwiHchvhmiWyeRaufysFYRfA.cvMNiUUeUmoHPXlCJGGRkyUPkmaVA = P_0;
		djQQDbwiHchvhmiWyeRaufysFYRfA.miXXCRjyCMmHsuCtXHcTRHeHZndm = P_1;
		if (vZzrBAsDQPSWeMgqojpijTXyuwNG && djQQDbwiHchvhmiWyeRaufysFYRfA.miXXCRjyCMmHsuCtXHcTRHeHZndm <= ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.eHkaHMARfQIlOsYaKzrQtIClDjZDb)
		{
			AList<kCBhwSapkGYeQoxEcFteDpxaVwfzb>[] array = phoPZjQLkYTxcrVWpJFfSLjvAPUF;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(djQQDbwiHchvhmiWyeRaufysFYRfA.vcjOtDYrFGZAknbQyoPRxGBaWCID);
			}
			GNaUDDREswnbsKVLytONBolgdelaA();
		}
	}

	public void ttKnOPeIFADyHvJSrYvlgomTBXFW(Action<InputActionEventData> P_0, UpdateLoopType P_1)
	{
		cbTmDfqlpSxYsKkYtluQtIWEVKz cbTmDfqlpSxYsKkYtluQtIWEVKz2 = new cbTmDfqlpSxYsKkYtluQtIWEVKz();
		cbTmDfqlpSxYsKkYtluQtIWEVKz2.CisRfspnUxLeEbOfxXFBUuikHQYB = P_0;
		cbTmDfqlpSxYsKkYtluQtIWEVKz2.AhSucKMlpFHSlWaVGewgWsovuwPh = P_1;
		if (vZzrBAsDQPSWeMgqojpijTXyuwNG)
		{
			AList<kCBhwSapkGYeQoxEcFteDpxaVwfzb>[] array = phoPZjQLkYTxcrVWpJFfSLjvAPUF;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(cbTmDfqlpSxYsKkYtluQtIWEVKz2.crMlXSUbAQkWEwEFhinImAnwwLVT);
			}
			GNaUDDREswnbsKVLytONBolgdelaA();
		}
	}

	public void inujYnaKUPFQaoZUpZAHdalfPRuI(Action<InputActionEventData> P_0, InputActionEventType P_1)
	{
		qLNjpcUkMyzjCakBJtgyEzToRifW qLNjpcUkMyzjCakBJtgyEzToRifW2 = new qLNjpcUkMyzjCakBJtgyEzToRifW();
		qLNjpcUkMyzjCakBJtgyEzToRifW2.rszCoCWWMZnujsVuFSHTyQIDzKQb = P_0;
		qLNjpcUkMyzjCakBJtgyEzToRifW2.TxRxDiISNlxSwUTGahiZszBpQcdk = P_1;
		if (vZzrBAsDQPSWeMgqojpijTXyuwNG)
		{
			AList<kCBhwSapkGYeQoxEcFteDpxaVwfzb>[] array = phoPZjQLkYTxcrVWpJFfSLjvAPUF;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(qLNjpcUkMyzjCakBJtgyEzToRifW2.MOoSYcRcNVqEYvdExwVWuKLJOcmh);
			}
			GNaUDDREswnbsKVLytONBolgdelaA();
		}
	}

	public void yMclJTmSJLEvvovGiNMdBeRkykdo(Action<InputActionEventData> P_0, UpdateLoopType P_1, int P_2)
	{
		mCWyEGUbCGLjunAvYEPDFbBfCFZT mCWyEGUbCGLjunAvYEPDFbBfCFZT2 = new mCWyEGUbCGLjunAvYEPDFbBfCFZT();
		mCWyEGUbCGLjunAvYEPDFbBfCFZT2.ginmjELTfuRaeNuXfsnVYkvkXCGc = P_0;
		mCWyEGUbCGLjunAvYEPDFbBfCFZT2.ZxlhigwCNoabZElVtJZFyEZrFzlFA = P_1;
		mCWyEGUbCGLjunAvYEPDFbBfCFZT2.XQwVJfSTGfLcuEKXXKnJColKGtgH = P_2;
		if (vZzrBAsDQPSWeMgqojpijTXyuwNG && mCWyEGUbCGLjunAvYEPDFbBfCFZT2.XQwVJfSTGfLcuEKXXKnJColKGtgH <= ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.eHkaHMARfQIlOsYaKzrQtIClDjZDb)
		{
			AList<kCBhwSapkGYeQoxEcFteDpxaVwfzb>[] array = phoPZjQLkYTxcrVWpJFfSLjvAPUF;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(mCWyEGUbCGLjunAvYEPDFbBfCFZT2.DklcoptEwtyieAhoQtdIqpwyAeJp);
			}
			GNaUDDREswnbsKVLytONBolgdelaA();
		}
	}

	public void gpGPsMuQHHNfcRuHRIJRfEkeFwKD(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2, int P_3)
	{
		nzXUKwabIjEBpjtOucHvKoaYuHAJA nzXUKwabIjEBpjtOucHvKoaYuHAJA2 = new nzXUKwabIjEBpjtOucHvKoaYuHAJA();
		nzXUKwabIjEBpjtOucHvKoaYuHAJA2.ddPTtkgqogAhcEWQddqjhuMFUOkPA = P_0;
		nzXUKwabIjEBpjtOucHvKoaYuHAJA2.qnJEXZmVkzLuStlksdvrMyPrfxxd = P_1;
		nzXUKwabIjEBpjtOucHvKoaYuHAJA2.CvxqBgjPCZFKUxGtRSDAmDwqGXeE = P_3;
		nzXUKwabIjEBpjtOucHvKoaYuHAJA2.vJQmfMdSNdajhqnMIMPycxDeOlNu = P_2;
		if (vZzrBAsDQPSWeMgqojpijTXyuwNG && nzXUKwabIjEBpjtOucHvKoaYuHAJA2.CvxqBgjPCZFKUxGtRSDAmDwqGXeE <= ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.eHkaHMARfQIlOsYaKzrQtIClDjZDb)
		{
			AList<kCBhwSapkGYeQoxEcFteDpxaVwfzb>[] array = phoPZjQLkYTxcrVWpJFfSLjvAPUF;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(nzXUKwabIjEBpjtOucHvKoaYuHAJA2.dwMquBRhRkrZvBchZDTUDHBTLzbcb);
			}
			GNaUDDREswnbsKVLytONBolgdelaA();
		}
	}

	public void SkkfLWREiqaruheyanJsjpsIZQrpA(Action<InputActionEventData> P_0, UpdateLoopType P_1, InputActionEventType P_2)
	{
		KWhDVBgkdJOhtqpfMqJMgJsTFUIS kWhDVBgkdJOhtqpfMqJMgJsTFUIS = new KWhDVBgkdJOhtqpfMqJMgJsTFUIS();
		kWhDVBgkdJOhtqpfMqJMgJsTFUIS.liPPGdHfvEIXTLrFUeMcTYmNDTBr = P_0;
		kWhDVBgkdJOhtqpfMqJMgJsTFUIS.KFalCzzkQMZMAjhQuGcqcMFHEuWq = P_1;
		kWhDVBgkdJOhtqpfMqJMgJsTFUIS.vtdohnPLYfofhJrnnaibPXqKbwXA = P_2;
		if (vZzrBAsDQPSWeMgqojpijTXyuwNG)
		{
			AList<kCBhwSapkGYeQoxEcFteDpxaVwfzb>[] array = phoPZjQLkYTxcrVWpJFfSLjvAPUF;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(kWhDVBgkdJOhtqpfMqJMgJsTFUIS.YErzqjFYmtbHyylZLDuNTfoEgBJN);
			}
			GNaUDDREswnbsKVLytONBolgdelaA();
		}
	}

	public void AfNJQdLHNuhJCziCkRcGoFyaTMsv(Action<InputActionEventData> P_0, InputActionEventType P_1, int P_2)
	{
		nXoukXqfGHDuqCHGGJWswYFeSbpi nXoukXqfGHDuqCHGGJWswYFeSbpi2 = new nXoukXqfGHDuqCHGGJWswYFeSbpi();
		nXoukXqfGHDuqCHGGJWswYFeSbpi2.OWUJlgYsjFRXeoKyeiirEoYBgOsV = P_0;
		nXoukXqfGHDuqCHGGJWswYFeSbpi2.aBPhKcgtAiybuusKcQlrhSREoXwZ = P_2;
		nXoukXqfGHDuqCHGGJWswYFeSbpi2.zisJjtvjVmpeYKUUWpaefpGLwmKp = P_1;
		if (vZzrBAsDQPSWeMgqojpijTXyuwNG && nXoukXqfGHDuqCHGGJWswYFeSbpi2.aBPhKcgtAiybuusKcQlrhSREoXwZ <= ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.eHkaHMARfQIlOsYaKzrQtIClDjZDb)
		{
			AList<kCBhwSapkGYeQoxEcFteDpxaVwfzb>[] array = phoPZjQLkYTxcrVWpJFfSLjvAPUF;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].RemoveAll(nXoukXqfGHDuqCHGGJWswYFeSbpi2.eUcsbSnGPjTTbJuvIGAuRFZrRiHA);
			}
			GNaUDDREswnbsKVLytONBolgdelaA();
		}
	}

	public void FRvFCFAoARGaEFKfdaJvixmXpdmnB()
	{
		if (vZzrBAsDQPSWeMgqojpijTXyuwNG)
		{
			AList<kCBhwSapkGYeQoxEcFteDpxaVwfzb>[] array = phoPZjQLkYTxcrVWpJFfSLjvAPUF;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Clear();
			}
			GNaUDDREswnbsKVLytONBolgdelaA();
		}
	}

	private void GNaUDDREswnbsKVLytONBolgdelaA()
	{
		int num = 0;
		for (int i = 0; i < phoPZjQLkYTxcrVWpJFfSLjvAPUF.Length; i++)
		{
			num += phoPZjQLkYTxcrVWpJFfSLjvAPUF[i]._count;
		}
		yOnjoPaBDNywJUmXvRAZOrofPUFF = num;
	}
}
