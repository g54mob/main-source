using Rewired;

internal sealed class fSUOfhaSaMnPmZbrSYBbJiCCNniM : RwchzpcDfTxDrohQshilLyohCKgA
{
	protected override bool uJUjODPczvYqPUUgCxDsAdZvCbmq(Pole P_0)
	{
		switch (base.ugEcvEUjcYzrLriOHSDCiapaTNEm)
		{
		case VwAEfXIfCgCiohhuMMznDzgWRhLp.Axis:
			return true;
		case VwAEfXIfCgCiohhuMMznDzgWRhLp.Button:
			switch (P_0)
			{
			case Pole.Positive:
				return false;
			case Pole.Negative:
				return true;
			default:
				return false;
			}
		default:
			return false;
		}
	}

	protected override bool faXHDBAAOZDwuwJHQrByrdTWsRQC(Pole P_0)
	{
		switch (base.ugEcvEUjcYzrLriOHSDCiapaTNEm)
		{
		case VwAEfXIfCgCiohhuMMznDzgWRhLp.Axis:
			return true;
		case VwAEfXIfCgCiohhuMMznDzgWRhLp.Button:
			if ((uint)P_0 <= 1u)
			{
				return true;
			}
			return false;
		default:
			return false;
		}
	}

	private fSUOfhaSaMnPmZbrSYBbJiCCNniM(VwAEfXIfCgCiohhuMMznDzgWRhLp P_0, bETiEQbYCrQRqCLRvbSAcJMPkrdD P_1)
		: base(P_0, P_1)
	{
	}

	private fSUOfhaSaMnPmZbrSYBbJiCCNniM(dEyHRFFHMmNkBjyccsmusjbnHemDB P_0, VwAEfXIfCgCiohhuMMznDzgWRhLp P_1, bETiEQbYCrQRqCLRvbSAcJMPkrdD P_2)
		: base(P_0, P_1, P_2)
	{
	}

	public new static fSUOfhaSaMnPmZbrSYBbJiCCNniM VxSNvmooWfTkIVcICGUZnqoUJPDW(VwAEfXIfCgCiohhuMMznDzgWRhLp P_0, bETiEQbYCrQRqCLRvbSAcJMPkrdD P_1)
	{
		return new fSUOfhaSaMnPmZbrSYBbJiCCNniM(P_0, P_1);
	}

	public new static fSUOfhaSaMnPmZbrSYBbJiCCNniM VxSNvmooWfTkIVcICGUZnqoUJPDW(dEyHRFFHMmNkBjyccsmusjbnHemDB P_0, VwAEfXIfCgCiohhuMMznDzgWRhLp P_1, bETiEQbYCrQRqCLRvbSAcJMPkrdD P_2)
	{
		fSUOfhaSaMnPmZbrSYBbJiCCNniM obj = new fSUOfhaSaMnPmZbrSYBbJiCCNniM(P_0, P_1, P_2);
		obj.TlzckGoQDITHcUYaslQXPQBOhTwq();
		return obj;
	}
}
