using UnityEngine;

internal static class xyjPzktDSlYTkbenjOQMZQDIwEH
{
	private static int HbQEUaLGOcUtESaufhSaVdTeLqc;

	private static int RMmuzLwPyyqjZzFkavzjXDLDVyZ;

	private static float[] ADpPFVKbSajoeVGpdFKLYUpnpiV;

	private static int jAstdNMTxoobTNDWkHXifLPMyXa;

	private static float WhiEUxezLHUhCeuZlpFHEEXRflbA;

	private static int eNGUMveCImdsmFaKkaZoaRFzWflz;

	public static float smoothDeltaTime
	{
		get
		{
			return WhiEUxezLHUhCeuZlpFHEEXRflbA;
		}
	}

	public static int framesToSmooth
	{
		get
		{
			return HbQEUaLGOcUtESaufhSaVdTeLqc;
		}
		set
		{
			if (value <= 0)
			{
				value = 1;
				goto IL_0007;
			}
			goto IL_0029;
			IL_0029:
			int num;
			int num2;
			if (value != HbQEUaLGOcUtESaufhSaVdTeLqc)
			{
				num = -1443514966;
				num2 = num;
			}
			else
			{
				num = -1443514967;
				num2 = num;
			}
			goto IL_000c;
			IL_0007:
			num = -1443514965;
			goto IL_000c;
			IL_000c:
			switch (num ^ -1443514966)
			{
			case 2:
				break;
			case 1:
				goto IL_0029;
			case 3:
				return;
			default:
				HbQEUaLGOcUtESaufhSaVdTeLqc = value;
				EEGiMNPSMElaPgKQdmScoWLedfb();
				return;
			}
			goto IL_0007;
		}
	}

	static xyjPzktDSlYTkbenjOQMZQDIwEH()
	{
		HbQEUaLGOcUtESaufhSaVdTeLqc = 30;
		EEGiMNPSMElaPgKQdmScoWLedfb();
	}

	public static void UZSQFwoMfSAzsmmSKmseCCiJWWD()
	{
		int frameCount = Time.frameCount;
		int num3 = default(int);
		float num2 = default(float);
		while (true)
		{
			int num = -1266742761;
			while (true)
			{
				switch (num ^ -1266742762)
				{
				case 3:
					break;
				case 7:
					jAstdNMTxoobTNDWkHXifLPMyXa++;
					num = -1266742764;
					continue;
				case 4:
					num3 = 0;
					num = -1266742765;
					continue;
				case 5:
				{
					int num5;
					if (num3 < jAstdNMTxoobTNDWkHXifLPMyXa)
					{
						num = -1266742753;
						num5 = num;
					}
					else
					{
						num = -1266742768;
						num5 = num;
					}
					continue;
				}
				case 6:
					WhiEUxezLHUhCeuZlpFHEEXRflbA = num2 / (float)jAstdNMTxoobTNDWkHXifLPMyXa;
					RMmuzLwPyyqjZzFkavzjXDLDVyZ++;
					if (RMmuzLwPyyqjZzFkavzjXDLDVyZ >= HbQEUaLGOcUtESaufhSaVdTeLqc)
					{
						RMmuzLwPyyqjZzFkavzjXDLDVyZ = 0;
						num = -1266742754;
						continue;
					}
					goto default;
				case 0:
				{
					ADpPFVKbSajoeVGpdFKLYUpnpiV[RMmuzLwPyyqjZzFkavzjXDLDVyZ] = Time.deltaTime;
					int num4;
					if (jAstdNMTxoobTNDWkHXifLPMyXa < HbQEUaLGOcUtESaufhSaVdTeLqc)
					{
						num = -1266742767;
						num4 = num;
					}
					else
					{
						num = -1266742764;
						num4 = num;
					}
					continue;
				}
				case 1:
					if (eNGUMveCImdsmFaKkaZoaRFzWflz >= frameCount)
					{
						return;
					}
					goto case 0;
				case 9:
					num2 += ADpPFVKbSajoeVGpdFKLYUpnpiV[num3];
					num3++;
					num = -1266742765;
					continue;
				case 2:
					num2 = 0f;
					num = -1266742766;
					continue;
				default:
					eNGUMveCImdsmFaKkaZoaRFzWflz = frameCount;
					return;
				}
				break;
			}
		}
	}

	public static void EEGiMNPSMElaPgKQdmScoWLedfb()
	{
		if (ADpPFVKbSajoeVGpdFKLYUpnpiV != null)
		{
			goto IL_0007;
		}
		goto IL_004c;
		IL_0007:
		int num = 1207135387;
		goto IL_000c;
		IL_000c:
		while (true)
		{
			switch (num ^ 0x47F36C99)
			{
			case 3:
				break;
			case 2:
				goto IL_002d;
			case 4:
				goto IL_004c;
			case 0:
				jAstdNMTxoobTNDWkHXifLPMyXa = 0;
				RMmuzLwPyyqjZzFkavzjXDLDVyZ = 0;
				num = 1207135384;
				continue;
			default:
				eNGUMveCImdsmFaKkaZoaRFzWflz = 0;
				return;
			}
			break;
			IL_002d:
			int num2;
			if (ADpPFVKbSajoeVGpdFKLYUpnpiV.Length != HbQEUaLGOcUtESaufhSaVdTeLqc)
			{
				num = 1207135389;
				num2 = num;
			}
			else
			{
				num = 1207135385;
				num2 = num;
			}
		}
		goto IL_0007;
		IL_004c:
		ADpPFVKbSajoeVGpdFKLYUpnpiV = new float[HbQEUaLGOcUtESaufhSaVdTeLqc];
		num = 1207135385;
		goto IL_000c;
	}
}
