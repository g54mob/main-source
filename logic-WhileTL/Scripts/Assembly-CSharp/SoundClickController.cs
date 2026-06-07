using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundClickController : ActiveComponent
{
	public List<string> clips = new List<string>();

	public List<int> RandomScore = new List<int>();

	private List<string> playList = new List<string>();

	private void Click()
	{
		int index = Random.Range(0, playList.Count);
		string text = playList[index];
		if (text.Length <= 0)
		{
			return;
		}
		if (text.ToLower().Contains("thunder"))
		{
			if (!ActiveComponent.Model.P.thunderTramborine.Contains(base.gameObject.name.GetHashCode()))
			{
				ActiveComponent.Model.P.thunderTramborine.Add(base.gameObject.name.GetHashCode());
			}
			if (ActiveComponent.Model.P.thunderTramborine.Count == Logic.GetUpgradesCouWithTag("TIMBREL"))
			{
				Steam.UnlockAchievement("ACHIEVEMENT_23");
			}
		}
		ActiveComponent.Sound.Play(playList[index]);
	}

	private void Start()
	{
		for (int i = 0; i < clips.Count; i++)
		{
			for (int j = 0; j < RandomScore[i]; j++)
			{
				playList.Add(clips[i]);
			}
		}
		GetComponent<Button>().onClick.AddListener(Click);
	}
}
