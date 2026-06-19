using Rewired.Utils;

internal class wYoTldBjcmEPzkyhATJSjejWGKaQ : sQojjrjMrygwjptCpBXZpWyPgNkC
{
	public readonly bool OMQSHczCuWHHJHLmiIqLYSCOCeBk;

	private int uAbIVHWBEXeTCTJImvigFqMmwFI;

	private int PEmGTahUYxvIGCkwNhYZXHewfszP;

	private bool DVrvRKPDOfdQmwWMlTDUbMPOZnp;

	public readonly int jsGdhCGSjqqXcZQQfLKbMosXWeOn;

	public readonly int QfwbQBoxGZmCgQpbeCMIJJzZfgnK;

	public readonly int mOovFgHeCbgdpcRvGscqNfWtOsd;

	public readonly int YmoDDGnDlltVOBhYREarXarkAvk;

	public readonly int TsxHkZBsIyTNrPwjJbcGOUiYVbK;

	public readonly int UjTRxRpsVmuKrcTXdwyXRHzWHvl;

	public readonly uint xgMliUjVccFrWmTmWFDbROwyEKB;

	public readonly uint cZeMzwDrNxfmJrVXmKFtMctYcmd;

	public readonly int OsgKSHMRRYRCGyGDSOBqVcHKBQz;

	public uint aYGIRtcEyUWEkvIdlycgzgpxzSs;

	public virtual int value
	{
		get
		{
			int num = (int)aYGIRtcEyUWEkvIdlycgzgpxzSs;
			if (OMQSHczCuWHHJHLmiIqLYSCOCeBk && DVrvRKPDOfdQmwWMlTDUbMPOZnp && num > uAbIVHWBEXeTCTJImvigFqMmwFI)
			{
				num += PEmGTahUYxvIGCkwNhYZXHewfszP;
			}
			if (num == mOovFgHeCbgdpcRvGscqNfWtOsd)
			{
				return UjTRxRpsVmuKrcTXdwyXRHzWHvl;
			}
			return (int)ccWnDVmYbWIzsTJhJxofsViavav((float)num, (float)jsGdhCGSjqqXcZQQfLKbMosXWeOn, (float)QfwbQBoxGZmCgQpbeCMIJJzZfgnK, (float)YmoDDGnDlltVOBhYREarXarkAvk, (float)TsxHkZBsIyTNrPwjJbcGOUiYVbK);
		}
	}

	public wYoTldBjcmEPzkyhATJSjejWGKaQ(byte reportId, ushort usagePage, ushort usage, int dataIndex, int bitSize, int logicalMin, int logicalMax, int physicalMin, int physicalMax, uint units, uint unitsExp, int reportIndex, bool isAxisButton)
		: base(reportId, usagePage, usage, dataIndex, bitSize)
	{
		jsGdhCGSjqqXcZQQfLKbMosXWeOn = logicalMin;
		QfwbQBoxGZmCgQpbeCMIJJzZfgnK = logicalMax;
		xgMliUjVccFrWmTmWFDbROwyEKB = units;
		cZeMzwDrNxfmJrVXmKFtMctYcmd = unitsExp;
		OsgKSHMRRYRCGyGDSOBqVcHKBQz = reportIndex;
		OMQSHczCuWHHJHLmiIqLYSCOCeBk = logicalMin < 0 || logicalMax < 0;
		if (logicalMin > logicalMax || logicalMax - logicalMin < 2)
		{
			if (logicalMin == 0 && logicalMax < 0 && physicalMin == 0 && physicalMax < 0)
			{
				OMQSHczCuWHHJHLmiIqLYSCOCeBk = false;
			}
			if (bitSize > 1 && bitSize < 32)
			{
				int num = 1 << bitSize;
				if (OMQSHczCuWHHJHLmiIqLYSCOCeBk)
				{
					mOovFgHeCbgdpcRvGscqNfWtOsd = 0;
					jsGdhCGSjqqXcZQQfLKbMosXWeOn = num * -1;
					QfwbQBoxGZmCgQpbeCMIJJzZfgnK = num - 1;
				}
				else
				{
					mOovFgHeCbgdpcRvGscqNfWtOsd = num >> 1;
					jsGdhCGSjqqXcZQQfLKbMosXWeOn = 0;
					QfwbQBoxGZmCgQpbeCMIJJzZfgnK = num - 1;
				}
			}
			else if (OMQSHczCuWHHJHLmiIqLYSCOCeBk)
			{
				mOovFgHeCbgdpcRvGscqNfWtOsd = 0;
				jsGdhCGSjqqXcZQQfLKbMosXWeOn = -32768;
				QfwbQBoxGZmCgQpbeCMIJJzZfgnK = 32767;
			}
			else
			{
				mOovFgHeCbgdpcRvGscqNfWtOsd = 32768;
				jsGdhCGSjqqXcZQQfLKbMosXWeOn = 0;
				QfwbQBoxGZmCgQpbeCMIJJzZfgnK = 65535;
			}
		}
		else
		{
			mOovFgHeCbgdpcRvGscqNfWtOsd = (QfwbQBoxGZmCgQpbeCMIJJzZfgnK - jsGdhCGSjqqXcZQQfLKbMosXWeOn) / 2;
		}
		UjTRxRpsVmuKrcTXdwyXRHzWHvl = 0;
		YmoDDGnDlltVOBhYREarXarkAvk = -65535;
		TsxHkZBsIyTNrPwjJbcGOUiYVbK = 65535;
		if (OMQSHczCuWHHJHLmiIqLYSCOCeBk)
		{
			MBUKbEGifzEgdolGdzPgVHnOGHD();
			mOovFgHeCbgdpcRvGscqNfWtOsd = logicalMax + 1 + logicalMin;
		}
		if (isAxisButton)
		{
			jsGdhCGSjqqXcZQQfLKbMosXWeOn = 0;
			mOovFgHeCbgdpcRvGscqNfWtOsd = 0;
			YmoDDGnDlltVOBhYREarXarkAvk = 0;
		}
		rKJfCRBWFLQsKCjGykmcumzKLPwE();
	}

	public override void rKJfCRBWFLQsKCjGykmcumzKLPwE()
	{
		aYGIRtcEyUWEkvIdlycgzgpxzSs = (uint)mOovFgHeCbgdpcRvGscqNfWtOsd;
	}

	private static float ccWnDVmYbWIzsTJhJxofsViavav(float P_0, float P_1, float P_2, float P_3, float P_4)
	{
		float num = P_2 - P_1;
		if (MathTools.Approximately(num, 0f))
		{
			return P_3;
		}
		float num2 = P_4 - P_3;
		return (P_0 - P_1) * num2 / num + P_3;
	}

	private static int ccWnDVmYbWIzsTJhJxofsViavav(int P_0, int P_1, int P_2, int P_3, int P_4)
	{
		int num = P_2 - P_1;
		long num2;
		if (num == 0)
		{
			num2 = P_3;
		}
		else
		{
			int num3 = P_4 - P_3;
			num2 = (long)(P_0 - P_1) * (long)num3 / num + P_3;
		}
		return (int)num2;
	}

	private void MBUKbEGifzEgdolGdzPgVHnOGHD()
	{
		if (RlgOamSMODhXErOMVExnzErogbk > 0 && RlgOamSMODhXErOMVExnzErogbk < 32)
		{
			int num = 1 << RlgOamSMODhXErOMVExnzErogbk;
			int num2 = num >> 1;
			uAbIVHWBEXeTCTJImvigFqMmwFI = num2 - 1;
			PEmGTahUYxvIGCkwNhYZXHewfszP = num * -1;
			DVrvRKPDOfdQmwWMlTDUbMPOZnp = true;
		}
	}
}
