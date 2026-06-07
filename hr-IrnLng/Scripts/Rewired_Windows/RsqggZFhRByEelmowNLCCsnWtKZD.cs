using Rewired.Utils;

internal class RsqggZFhRByEelmowNLCCsnWtKZD : bARERokRPrroENPUWZfiYoNYxPs
{
	public readonly int wclPZcDBDlViZwCyCgMeHFYKuUu;

	public readonly int FVTieGbwcOPWTizhRLaruKQUAir;

	public readonly int zeZHXfFKWkTyEFYLlqQNWgtglKvA;

	public readonly int ZFXvtLkFBsytjdWMoVaMmWArVvq;

	public readonly int AnSutSUXElVFsxmsyFNtfhdFlDWF;

	public readonly int DvyrfCsGrpScKMhZGYIayLKVIPn;

	public readonly uint ycjFPPDijlTFxCYLvSjKxgtfIYHf;

	public readonly uint SuocXzhNDeDzhDKlAitRkZPfbrL;

	public readonly int PMPyyMNylNnLtKkHvQgLkSmTiQf;

	private readonly int GkrkXeEKxlEOTXWXuXBWLWQuICh;

	public uint tMdVaanieZgMNBPWABQFUSWqJtyN;

	public int value
	{
		get
		{
			if (tMdVaanieZgMNBPWABQFUSWqJtyN < wclPZcDBDlViZwCyCgMeHFYKuUu || tMdVaanieZgMNBPWABQFUSWqJtyN > FVTieGbwcOPWTizhRLaruKQUAir)
			{
				return -1;
			}
			int num = (int)((tMdVaanieZgMNBPWABQFUSWqJtyN - wclPZcDBDlViZwCyCgMeHFYKuUu) / GkrkXeEKxlEOTXWXuXBWLWQuICh * 4500);
			if (num >= 36000)
			{
				num = 0;
			}
			return num;
		}
	}

	public RsqggZFhRByEelmowNLCCsnWtKZD(byte reportId, ushort usagePage, ushort usage, int dataIndex, int bitSize, int logicalMin, int logicalMax, int physicalMin, int physicalMax, uint units, uint unitsExp, int reportIndex)
		: base(reportId, usagePage, usage, dataIndex, bitSize)
	{
		wclPZcDBDlViZwCyCgMeHFYKuUu = logicalMin;
		FVTieGbwcOPWTizhRLaruKQUAir = logicalMax;
		ycjFPPDijlTFxCYLvSjKxgtfIYHf = units;
		SuocXzhNDeDzhDKlAitRkZPfbrL = unitsExp;
		PMPyyMNylNnLtKkHvQgLkSmTiQf = reportIndex;
		zeZHXfFKWkTyEFYLlqQNWgtglKvA = logicalMin - 1;
		if (zeZHXfFKWkTyEFYLlqQNWgtglKvA < 0)
		{
			zeZHXfFKWkTyEFYLlqQNWgtglKvA = logicalMax + 1;
		}
		DvyrfCsGrpScKMhZGYIayLKVIPn = -1;
		int num = logicalMax - logicalMin + 1;
		GkrkXeEKxlEOTXWXuXBWLWQuICh = MathTools.Clamp(num / 8, 1, int.MaxValue);
		avkcOhFlGGeHrNSdTQlLZUnJDbw();
	}

	public override void avkcOhFlGGeHrNSdTQlLZUnJDbw()
	{
		tMdVaanieZgMNBPWABQFUSWqJtyN = (uint)zeZHXfFKWkTyEFYLlqQNWgtglKvA;
	}
}
