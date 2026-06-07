public class PlayerDistribution : IServerItem, IReferenceFix
{
	public const float BandwidthPerSale = 0.05f;

	public float ItemSales;

	public float ActualBandwidthSales;

	public string ServerName;

	public float LastLoad = 1f;

	public float TimeToCancel;

	public float LastCut = 0.05f;

	public float Cut = 0.05f;

	public bool Open;

	public bool AutoAccept = true;

	public bool UsesISP
	{
		get
		{
			return true;
		}
	}

	public bool CancelOnUnload()
	{
		return false;
	}

	public float GetLoadRequirement()
	{
		return ActualBandwidthSales * 0.05f;
	}

	public void HandleLoad(float load)
	{
	}

	public string GetDescription()
	{
		return "Digitaldistribution".Loc();
	}

	public void SerializeServer(string name)
	{
		ServerName = name;
	}

	public IReferenceFix FixReferences()
	{
		return this;
	}
}
