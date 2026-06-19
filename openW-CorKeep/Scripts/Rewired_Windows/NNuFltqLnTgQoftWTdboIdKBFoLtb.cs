using System;
using System.Collections.Generic;

internal struct NNuFltqLnTgQoftWTdboIdKBFoLtb<_0001> : IDisposable
{
	private gOUcPitrwJfxWYceMeToKWitmHgqA rFmBxFawRvcjEifwGDjwAgEvAHQRb;

	private _0001 yQQHxPwpYygYhHCWMsfDBXXOfukM;

	private IEnumerator<global::vbflZvwrHWUNBGNfYOIeiLqUwxgE<_0001>> cmWRcshdNRjSVaDQpzuJGQCQsUfVA;

	private bool HDcIbSMHkIIAMmMagvXToTSxIlQV;

	public gOUcPitrwJfxWYceMeToKWitmHgqA kXyRacoLqtqGwwYGCcoQtOEPTpqx => rFmBxFawRvcjEifwGDjwAgEvAHQRb;

	public _0001 rGHnwLVHhxgeQDsKSgcimOCPmRTp => yQQHxPwpYygYhHCWMsfDBXXOfukM;

	public NNuFltqLnTgQoftWTdboIdKBFoLtb(IEnumerable<global::vbflZvwrHWUNBGNfYOIeiLqUwxgE<_0001>> P_0)
	{
		rFmBxFawRvcjEifwGDjwAgEvAHQRb = gOUcPitrwJfxWYceMeToKWitmHgqA.Idle;
		yQQHxPwpYygYhHCWMsfDBXXOfukM = default(_0001);
		cmWRcshdNRjSVaDQpzuJGQCQsUfVA = P_0.GetEnumerator();
		HDcIbSMHkIIAMmMagvXToTSxIlQV = false;
	}

	public bool cIvCMecKxnIClvspXwIsenVfwSLc()
	{
		if (!cmWRcshdNRjSVaDQpzuJGQCQsUfVA.MoveNext())
		{
			return true;
		}
		global::vbflZvwrHWUNBGNfYOIeiLqUwxgE<_0001> current = cmWRcshdNRjSVaDQpzuJGQCQsUfVA.Current;
		rFmBxFawRvcjEifwGDjwAgEvAHQRb = current.RGHetddbMcdVvRipTgNOGyNhfeMAc;
		yQQHxPwpYygYhHCWMsfDBXXOfukM = current.wYrgLxFCUBNWOGgbeUKIBiZDhDMdB;
		return false;
	}

	public void Dispose()
	{
		WiSvsnqIozfQBCnscRHTpdUyvUwLA(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void WiSvsnqIozfQBCnscRHTpdUyvUwLA(bool P_0)
	{
		if (!HDcIbSMHkIIAMmMagvXToTSxIlQV)
		{
			HDcIbSMHkIIAMmMagvXToTSxIlQV = true;
		}
	}
}
