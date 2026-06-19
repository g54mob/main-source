using Rewired.Utils;

internal class OwTObMgdIOWMHQqmXdWtBYzFETP : sQojjrjMrygwjptCpBXZpWyPgNkC
{
	public readonly int jsGdhCGSjqqXcZQQfLKbMosXWeOn;

	public readonly int QfwbQBoxGZmCgQpbeCMIJJzZfgnK;

	public readonly int mOovFgHeCbgdpcRvGscqNfWtOsd;

	public readonly int YmoDDGnDlltVOBhYREarXarkAvk;

	public readonly int TsxHkZBsIyTNrPwjJbcGOUiYVbK;

	public readonly int UjTRxRpsVmuKrcTXdwyXRHzWHvl;

	public readonly uint xgMliUjVccFrWmTmWFDbROwyEKB;

	public readonly uint ZzFjglebavtHUpjkxDqyoaOmrlB;

	public readonly int OsgKSHMRRYRCGyGDSOBqVcHKBQz;

	private readonly int DVInEjNaVgBSgibUVEvzjendcSvX;

	public uint aYGIRtcEyUWEkvIdlycgzgpxzSs;

	public int value
	{
		get
		{
			if (aYGIRtcEyUWEkvIdlycgzgpxzSs < jsGdhCGSjqqXcZQQfLKbMosXWeOn || aYGIRtcEyUWEkvIdlycgzgpxzSs > QfwbQBoxGZmCgQpbeCMIJJzZfgnK)
			{
				return -1;
			}
			int num = (int)((aYGIRtcEyUWEkvIdlycgzgpxzSs - jsGdhCGSjqqXcZQQfLKbMosXWeOn) / DVInEjNaVgBSgibUVEvzjendcSvX * 4500);
			if (num >= 36000)
			{
				num = 0;
			}
			return num;
		}
	}

	public OwTObMgdIOWMHQqmXdWtBYzFETP(byte reportId, ushort usagePage, ushort usage, int dataIndex, int bitSize, int logicalMin, int logicalMax, int physicalMin, int physicalMax, uint units, uint unitsExp, int reportIndex)
		: base(reportId, usagePage, usage, dataIndex, bitSize)
	{
		jsGdhCGSjqqXcZQQfLKbMosXWeOn = logicalMin;
		QfwbQBoxGZmCgQpbeCMIJJzZfgnK = logicalMax;
		xgMliUjVccFrWmTmWFDbROwyEKB = units;
		ZzFjglebavtHUpjkxDqyoaOmrlB = unitsExp;
		OsgKSHMRRYRCGyGDSOBqVcHKBQz = reportIndex;
		mOovFgHeCbgdpcRvGscqNfWtOsd = logicalMin - 1;
		if (mOovFgHeCbgdpcRvGscqNfWtOsd < 0)
		{
			mOovFgHeCbgdpcRvGscqNfWtOsd = logicalMax + 1;
		}
		UjTRxRpsVmuKrcTXdwyXRHzWHvl = -1;
		int num = logicalMax - logicalMin + 1;
		DVInEjNaVgBSgibUVEvzjendcSvX = MathTools.Clamp(num / 8, 1, int.MaxValue);
		rKJfCRBWFLQsKCjGykmcumzKLPwE();
	}

	public override void rKJfCRBWFLQsKCjGykmcumzKLPwE()
	{
		aYGIRtcEyUWEkvIdlycgzgpxzSs = (uint)mOovFgHeCbgdpcRvGscqNfWtOsd;
	}
}
