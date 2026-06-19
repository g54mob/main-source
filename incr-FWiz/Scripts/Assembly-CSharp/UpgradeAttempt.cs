using System;
using System.Runtime.CompilerServices;

[Serializable]
public class UpgradeAttempt
{
	public string UpgradeDefID;

	public PaymentGroup Payment;

	public bool Active => false;

	public event Action AnnouncedCleared
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Set(string upgradeID, PaymentGroup standingPyament)
	{
	}

	public UpgradeInstance GetUpgradeInstance()
	{
		return null;
	}

	public UpgradeDef GetUpgradeDef()
	{
		return null;
	}

	public void Clear()
	{
	}
}
