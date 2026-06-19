using Rewired.Utils.Classes.Data;

internal class OLAxjmdqJbHeCArvVCNIDgdBciXE : tNSBtIwTqUeWpGtNoXsrdaEOoFDcA
{
	public int fikKeNYiiVTMWfIhefXipIFSSyAr;

	public double qIeElHyzJgoXnhgbAbXuioyIUGiy;

	public readonly int jXfyYJaUgdvNFJbuWACXyQjpIbTK;

	public readonly int oesePNKKXHepmBtHjFCadNYCPbFKB;

	public readonly bool nnaSsWKmzOgsrbaVARxRBslGSenGA;

	public readonly int HFXgiFbcwLXqEPrvzObVedWGoZCvb;

	public readonly int WExaCQcqNTtQWTJXKUnUDzWaNLvQ;

	public readonly int StQCazuXPTrXxFviheQmLRjpAXYC;

	public OLAxjmdqJbHeCArvVCNIDgdBciXE(byte P_0, HIDInfo P_1, bool P_2, int P_3)
		: base(P_0, P_1)
	{
		jXfyYJaUgdvNFJbuWACXyQjpIbTK = ((P_1.bitSize > 0) ? ((P_1.bitSize + 8 - 1) / 8) : 0);
		oesePNKKXHepmBtHjFCadNYCPbFKB = P_1.dataIndex;
		nnaSsWKmzOgsrbaVARxRBslGSenGA = P_2;
		HFXgiFbcwLXqEPrvzObVedWGoZCvb = P_1.logicalMin;
		WExaCQcqNTtQWTJXKUnUDzWaNLvQ = P_1.logicalMax;
		StQCazuXPTrXxFviheQmLRjpAXYC = P_3;
	}

	public virtual void IIoUrZJQhvbXwSQsOIsLoKGJyFMw(NativeBuffer P_0, double P_1)
	{
		if (P_0 == null || P_0[0] != ZfhixqygedAFuxvJkiAMIicmaEDTA)
		{
			return;
		}
		qIeElHyzJgoXnhgbAbXuioyIUGiy = P_1;
		int num = 0;
		if (jXfyYJaUgdvNFJbuWACXyQjpIbTK > 1)
		{
			for (int i = 0; i < jXfyYJaUgdvNFJbuWACXyQjpIbTK; i++)
			{
				num |= P_0[oesePNKKXHepmBtHjFCadNYCPbFKB + i] << 8 * i;
			}
		}
		else
		{
			num = P_0[oesePNKKXHepmBtHjFCadNYCPbFKB];
		}
		fikKeNYiiVTMWfIhefXipIFSSyAr = num;
	}
}
