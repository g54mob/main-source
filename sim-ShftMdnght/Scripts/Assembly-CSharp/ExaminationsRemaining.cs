using TMPro;
using UnityEngine;

public class ExaminationsRemaining : MonoBehaviour
{
	public TextMeshProUGUI text;

	private void Start()
	{
		base.gameObject.SetActive(value: false);
	}

	private void OnEnable()
	{
		if (CurrentDayManager.Instance.curDay == 1 && CurrentDayManager.Instance.curOccurrence < 2)
		{
			text.text = "-/- [TUTORIAL]";
			return;
		}
		Invoke("CheckIfInTutorial", 1f);
		text.text = StoreManager.Instance.examinationsRemaining + "/5 remaining";
		if (StoreManager.Instance.examinationsRemaining < 1)
		{
			text.color = Color.red;
		}
		else if (StoreManager.Instance.examinationsRemaining == 1)
		{
			text.color = Color.yellow;
		}
		else
		{
			text.color = Color.white;
		}
	}
}
