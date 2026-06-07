using UI.Elements;
using UnityEngine;

public class SteamVotesBar : MonoBehaviour
{
	[SerializeField]
	private UIText likes;

	[SerializeField]
	private UIText unlikes;

	[SerializeField]
	private UIText positveRatio;

	[SerializeField]
	private UIText percent;

	public void Set(int limit = 1000, float positiveVotes = -1f, int likes = -1, int unlikes = -1)
	{
	}

	public void Clear(bool positiveVotes, bool likes, bool unlikes)
	{
	}
}
