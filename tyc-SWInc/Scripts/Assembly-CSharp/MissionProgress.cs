using UnityEngine;
using UnityEngine.UI;

public class MissionProgress : MonoBehaviour
{
	public GUIProgressBar Bar;

	public Text Label;

	public Text Tip;

	public GameObject Tick;

	public GameObject TipObject;

	public GameObject TipButton;

	public void ToggleTip()
	{
		TipObject.SetActive(!TipObject.activeSelf);
	}

	public void ToggleTipOff()
	{
		if (TipObject.activeSelf)
		{
			ToggleTip();
		}
	}

	public void Set(RewardTask.Goal goal)
	{
		Label.text = Utilities.RobustStringFormat(goal.Description, false, false);
		if (!string.IsNullOrEmpty(goal.Tip))
		{
			Tip.text = Utilities.RobustStringFormat(goal.Tip, false, false);
			TipObject.SetActive(true);
			TipButton.SetActive(true);
		}
	}
}
