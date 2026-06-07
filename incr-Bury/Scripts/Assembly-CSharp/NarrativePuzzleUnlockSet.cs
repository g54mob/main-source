using System.Collections.Generic;
using UnityEngine;

public class NarrativePuzzleUnlockSet : MonoBehaviour
{
	public List<GameObject> solvedGroup;

	public List<GameObject> unsolvedGroup;

	public List<GameObject> pc_SolvedRewards;

	public void SolvedGroup_Show()
	{
		if (solvedGroup == null)
		{
			return;
		}
		foreach (GameObject item in solvedGroup)
		{
			item.SetActive(value: true);
		}
	}

	public void SolvedGroup_Hide()
	{
		if (solvedGroup == null)
		{
			return;
		}
		foreach (GameObject item in solvedGroup)
		{
			item.SetActive(value: false);
		}
	}

	public void UnSolvedGroup_Show()
	{
		if (unsolvedGroup == null)
		{
			return;
		}
		foreach (GameObject item in unsolvedGroup)
		{
			item.SetActive(value: true);
		}
	}

	public void UnSolvedGroup_Hide()
	{
		if (unsolvedGroup == null)
		{
			return;
		}
		foreach (GameObject item in unsolvedGroup)
		{
			item.SetActive(value: false);
		}
	}

	public void ShowHide_RelatedPcContent(bool _show)
	{
		if (pc_SolvedRewards == null || pc_SolvedRewards.Count <= 0)
		{
			return;
		}
		foreach (GameObject pc_SolvedReward in pc_SolvedRewards)
		{
			pc_SolvedReward.SetActive(_show);
		}
	}
}
