using Rewired.Utils;

internal class MfXAfiZAimBYGiJmmzSJpifxHtLq : azzdksHseEWnAOORdUssfcTOnIwrA
{
	public readonly int DNMfyfGdHLOcthUfmEqcjEWfvuUS;

	public readonly int yvmLIicciolEbteYfeOZSaHtuXhj;

	public readonly int KryaTHHzYSZSaFvgJColAfmZgYbt;

	public readonly int unuCWvngZSYuXuLdSqnsOzRIvFui;

	public readonly int jGnIQeFUQFmmKqiVYBiDLGaojXWo;

	public readonly int cXBWGoxAdRThuZeWcYBIUDDgNJfH;

	public readonly uint RTEccpnEvFlkJFQqLmjyMqqAfQBcA;

	public readonly uint hBHDiRcXLUTQNWxYeurhlOCGhdVGA;

	public readonly int yHkTXySPhbqODLAeNHknIszcIWbl;

	private readonly int tJSvDGZIlRwvdYUxCuHknhXJCIpgA;

	public uint QGEPzKgIedvthGPliWOduwXNjWui;

	public int pWRdAJigDslyLjNIYbVMMkTWOPgC
	{
		get
		{
			if (QGEPzKgIedvthGPliWOduwXNjWui < DNMfyfGdHLOcthUfmEqcjEWfvuUS || QGEPzKgIedvthGPliWOduwXNjWui > yvmLIicciolEbteYfeOZSaHtuXhj)
			{
				return -1;
			}
			int num = (int)((QGEPzKgIedvthGPliWOduwXNjWui - DNMfyfGdHLOcthUfmEqcjEWfvuUS) / tJSvDGZIlRwvdYUxCuHknhXJCIpgA * 4500);
			if (num >= 36000)
			{
				num = 0;
			}
			return num;
		}
	}

	public MfXAfiZAimBYGiJmmzSJpifxHtLq(byte P_0, ushort P_1, ushort P_2, int P_3, int P_4, int P_5, int P_6, int P_7, int P_8, uint P_9, uint P_10, int P_11)
		: base(P_0, P_1, P_2, P_3, P_4)
	{
		DNMfyfGdHLOcthUfmEqcjEWfvuUS = P_5;
		yvmLIicciolEbteYfeOZSaHtuXhj = P_6;
		RTEccpnEvFlkJFQqLmjyMqqAfQBcA = P_9;
		hBHDiRcXLUTQNWxYeurhlOCGhdVGA = P_10;
		yHkTXySPhbqODLAeNHknIszcIWbl = P_11;
		KryaTHHzYSZSaFvgJColAfmZgYbt = P_5 - 1;
		if (KryaTHHzYSZSaFvgJColAfmZgYbt < 0)
		{
			KryaTHHzYSZSaFvgJColAfmZgYbt = P_6 + 1;
		}
		cXBWGoxAdRThuZeWcYBIUDDgNJfH = -1;
		int num = P_6 - P_5 + 1;
		tJSvDGZIlRwvdYUxCuHknhXJCIpgA = MathTools.Clamp(num / 8, 1, int.MaxValue);
		DwNKXiEShimVDUzntAObjUXyaFmo();
	}

	public override void DwNKXiEShimVDUzntAObjUXyaFmo()
	{
		QGEPzKgIedvthGPliWOduwXNjWui = (uint)KryaTHHzYSZSaFvgJColAfmZgYbt;
	}
}
