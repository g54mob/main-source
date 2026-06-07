using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_QuestStatus : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private TMP_Text text_QuestDescription;

	[SerializeField]
	private Image image_Frame;

	[SerializeField]
	private Color color_QuestInProgress;

	[SerializeField]
	private Color color_QuestSucceed;

	[SerializeField]
	private Color color_QuestFailed;

	[SerializeField]
	private RectTransform node_Layout;

	private string progressText;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnToggleQuestStatusUI(bool isOn)
	{
	}

	private void OnUpdateQuestUIProgressText(string str)
	{
	}

	private void OnLanguageChanged()
	{
	}

	private void OnQuestChanged(QuestData data)
	{
	}

	private void UpdateContent(QuestData data)
	{
	}

	private void OnQuestSuccess()
	{
	}

	private void OnQuestFailed()
	{
	}

	private void OnQuestBackToInProgress()
	{
	}

	private void OnPlayerVictory()
	{
	}

	private void OnPlayerDefeat()
	{
	}
}
