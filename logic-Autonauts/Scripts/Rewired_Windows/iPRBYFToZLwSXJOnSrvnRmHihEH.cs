using System.Collections.Generic;
using Rewired.Utils;

internal class iPRBYFToZLwSXJOnSrvnRmHihEH : pORaxzeTYCRZPbhHycQGjGqbCdL
{
	private List<wLwPITJheYTdSwSdyTnuOtXwpVJ> WWWqLqyQwwaCmVLBUCOblJOSmhT;

	private wLwPITJheYTdSwSdyTnuOtXwpVJ[] ZDztjelLIFLuVjitQaCcDDiKRYfe;

	private bool QnzDXLUIEiUBgitKGgCxFNWSagH;

	public iPRBYFToZLwSXJOnSrvnRmHihEH()
	{
		WWWqLqyQwwaCmVLBUCOblJOSmhT = new List<wLwPITJheYTdSwSdyTnuOtXwpVJ>();
	}

	public override void AddAxis(wLwPITJheYTdSwSdyTnuOtXwpVJ P_0)
	{
		WWWqLqyQwwaCmVLBUCOblJOSmhT.Add(P_0);
	}

	public float MnqkSgUruMGpGEncQArrqhjEHzFC(int P_0)
	{
		if (P_0 < 0 || P_0 >= ZDztjelLIFLuVjitQaCcDDiKRYfe.Length)
		{
			return 0f;
		}
		return lmyenCPLmUeYnxIapmEbpOtJtXT(ZDztjelLIFLuVjitQaCcDDiKRYfe[P_0].value);
	}

	public int miBOLqVFeLojEvjoqjWpJVBWVCO(int P_0)
	{
		if (P_0 < 0 || P_0 >= ZDztjelLIFLuVjitQaCcDDiKRYfe.Length)
		{
			return 0;
		}
		return (int)ZDztjelLIFLuVjitQaCcDDiKRYfe[P_0].wmSvsDuQKkgIZvbYXgCGTuPJLgF;
	}

	public override void Finish()
	{
		if (!QnzDXLUIEiUBgitKGgCxFNWSagH)
		{
			QnzDXLUIEiUBgitKGgCxFNWSagH = true;
			ZDztjelLIFLuVjitQaCcDDiKRYfe = WWWqLqyQwwaCmVLBUCOblJOSmhT.ToArray();
			WWWqLqyQwwaCmVLBUCOblJOSmhT = null;
		}
	}

	private float lmyenCPLmUeYnxIapmEbpOtJtXT(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
