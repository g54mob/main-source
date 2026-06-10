using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class BasebouleSimulator : MonoBehaviour
{
	public List<BasebouleTeam> availableTeams;

	public List<BasebouleGameIntro> availableIntros;

	public List<BasebouleGameLineUpFollowUp> availableFollowUps;

	public List<BasebouleGameIntroClosingStatement> availableIntroClosingStatements;

	public List<BasebouleGameAdvert> availableAdverts;

	public BasebouleTeam homeTeam;

	public BasebouleTeam awayTeam;

	private BasebouleGameData _basebouleGame;

	public int _introSelection;

	public int _followUpSelection;

	public int _closingSelection;

	public int _homeTeamIndex;

	public int _awayTeamIndex;

	public int[] _homeRosterPlayerOrder;

	public int[] _awayRosterPlayerOrder;

	public int _adsPlayed;

	public int[] _adOrder;

	[Button(null, EButtonEnableMode.Always)]
	private void SimGame()
	{
	}

	private void RollIntroduction()
	{
	}

	private bool TryNextAd()
	{
		return false;
	}

	private void RollTeams()
	{
	}

	private void RollPlayerOrder()
	{
	}

	private void RollAdOrder()
	{
	}

	private int[] GetShuffledIndexesOfList<T>(List<T> listToShuffle)
	{
		return null;
	}
}
