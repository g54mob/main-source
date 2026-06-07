using MPUIKIT;
using TMPro;
using UnityEngine;

public class RevivePanel : MonoBehaviour
{
	public GameObject revivePanel;

	public TMP_Text counterText;

	public MPImage fill;

	public AutoRevive playerReviveComponent;

	private void Update()
	{
		float timeTillRevive = playerReviveComponent.TimeTillRevive;
		if (timeTillRevive > 0f && LocalGamestate.Instance.CurrentState == LocalGamestate.State.InMatch)
		{
			revivePanel.SetActive(value: true);
			counterText.text = Mathf.Floor(timeTillRevive).ToString();
			fill.fillAmount = Mathf.InverseLerp(playerReviveComponent.reviveAfterBeingKnockedOutFor, 0f, timeTillRevive);
		}
		else
		{
			revivePanel.SetActive(value: false);
		}
	}
}
