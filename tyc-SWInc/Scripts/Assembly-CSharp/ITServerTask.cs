using System;

public class ITServerTask : IServerItem, IReferenceFix
{
	public float Effectiveness = 1f;

	public bool UsesISP
	{
		get
		{
			return false;
		}
	}

	public IReferenceFix FixReferences()
	{
		throw new NotImplementedException();
	}

	public bool CancelOnUnload()
	{
		return false;
	}

	public float GetLoadRequirement()
	{
		return (float)GameSettings.Instance.ActiveStations() * 2f;
	}

	public void HandleLoad(float load)
	{
		Effectiveness = load;
	}

	public string GetDescription()
	{
		return "ITSupport".Loc();
	}

	public void SerializeServer(string name)
	{
		GameSettings.Instance.ITSupportServer = name;
	}
}
