using UnityEngine;

public class NullWatchHost : MonoBehaviour, WatchHost
{
	public bool startingHunt
	{
		get
		{
			return false;
		}
	}

	public bool inHunt
	{
		get
		{
			return false;
		}
	}

	public bool canHunt
	{
		get
		{
			return false;
		}
	}

	public string enteringMomentId
	{
		get
		{
			return string.Empty;
		}
	}

	public void StartEnterMoment(string momentId, bool fast)
	{
	}

	public void CancelEnterMoment()
	{
	}

	public void StartHunt()
	{
	}

	public void StartInception(CorpseBox corpseBox)
	{
	}

	public void StartPullCorpse(CorpseBox corpseBox)
	{
	}
}
