using TMPro;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
	[SerializeField]
	private TMP_Text description;

	[SerializeField]
	private TMP_Text progress;

	private PlayerController playerController;

	private void Start()
	{
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		UpdateLog();
	}

	private void Update()
	{
	}

	public void UpdateLog()
	{
		UpdateLog(playerController.GetCurrentQuest());
	}

	public void UpdateLog(Quest q)
	{
		if (q != null)
		{
			base.gameObject.SetActive(value: true);
			description.transform.parent.gameObject.SetActive(value: true);
			if (q.Completed)
			{
				description.text = "Completed!";
				return;
			}
			TMP_Text tMP_Text = description;
			string text = (description.text = q.Description + ": " + q.currentAmount + "/" + q.GoalAmount);
			tMP_Text.text = text;
		}
		else
		{
			description.transform.parent.gameObject.SetActive(value: false);
			base.gameObject.SetActive(value: false);
		}
	}
}
