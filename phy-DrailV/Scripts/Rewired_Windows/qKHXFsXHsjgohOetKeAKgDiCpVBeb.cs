using System;
using System.Collections.Generic;

internal struct qKHXFsXHsjgohOetKeAKgDiCpVBeb<_0001> : IDisposable
{
	private XYlppfUbmbFnVvZMPgROoKVgmKwC CXrtwVFanUkAxpYoKExRvUtoJrcu;

	private _0001 LFHgWIfIRZdDjQrlSzromnntPqzw;

	private IEnumerator<ImYcJyXEscGiOzvwPCvMcIxTWFaFA<_0001>> aTevOcgmavRgZIKHOewDElZDDexab;

	private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

	public XYlppfUbmbFnVvZMPgROoKVgmKwC vsrlgSTSjYeOzPsLoppZDjQLOXjN => CXrtwVFanUkAxpYoKExRvUtoJrcu;

	public _0001 uSwyJUCsSdiGPcMJmfFpIGVFqnMMA => LFHgWIfIRZdDjQrlSzromnntPqzw;

	public qKHXFsXHsjgohOetKeAKgDiCpVBeb(IEnumerable<ImYcJyXEscGiOzvwPCvMcIxTWFaFA<_0001>> P_0)
	{
		CXrtwVFanUkAxpYoKExRvUtoJrcu = XYlppfUbmbFnVvZMPgROoKVgmKwC.Idle;
		LFHgWIfIRZdDjQrlSzromnntPqzw = default(_0001);
		aTevOcgmavRgZIKHOewDElZDDexab = P_0.GetEnumerator();
		JWXwfaUAOJsMCNExsMKmFgNcBZSc = false;
	}

	public bool TPcqcKWeqJnMdeNkqZXytbyidUBn()
	{
		if (!aTevOcgmavRgZIKHOewDElZDDexab.MoveNext())
		{
			return true;
		}
		ImYcJyXEscGiOzvwPCvMcIxTWFaFA<_0001> current = aTevOcgmavRgZIKHOewDElZDDexab.Current;
		CXrtwVFanUkAxpYoKExRvUtoJrcu = current.vsrlgSTSjYeOzPsLoppZDjQLOXjN;
		LFHgWIfIRZdDjQrlSzromnntPqzw = current.uSwyJUCsSdiGPcMJmfFpIGVFqnMMA;
		return false;
	}

	public void Dispose()
	{
		vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
		GC.SuppressFinalize(this);
	}

	private void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
	{
		if (!JWXwfaUAOJsMCNExsMKmFgNcBZSc)
		{
			JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
		}
	}
}
