using TMPro;
using UnityEngine;

public class EternalTrialsStageCountDisplay : MonoBehaviour
{
	public GameObject toggleObj;

	public TextMeshProUGUI targetDisplay;

	private void OnEnable()
	{
		Refresh();
	}

	public void Refresh()
	{
		if (LocalGamestate.SelectedGameMode == LocalGamestate.GameMode.EternalTrial)
		{
			toggleObj.SetActive(value: true);
			targetDisplay.text = (EternalTrialsRunManager.CurrentRun.stage + 1).ToString();
		}
		else
		{
			toggleObj.SetActive(value: false);
		}
	}
}
