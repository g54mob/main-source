using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SessionQuestTooltip : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI titleLabel;

	[SerializeField]
	private TextMeshProUGUI descriptionLabel;

	[SerializeField]
	private TextMeshProUGUI progressLabel;

	[SerializeField]
	private RectTransform node;

	[SerializeField]
	private Vector2[] nodePositions;

	[SerializeField]
	[FormerlySerializedAs("progressBar")]
	private Image progressBarFill;

	private SessionQuest sessionQuest;

	private int level;

	public void Setup(int index, SessionQuest sessionQuest, int level)
	{
		if ((bool)this.sessionQuest)
		{
			sessionQuest.OnProgressChanged -= UpdateProgressBar;
		}
		this.sessionQuest = sessionQuest;
		this.level = level;
		node.gameObject.SetActive(index < nodePositions.Length);
		if (index < nodePositions.Length)
		{
			node.anchoredPosition = nodePositions[index];
		}
		LocalizationManager.Instance.UpdateTextMesh(titleLabel, LocalizedFontStyle.H1, sessionQuest.GetTitle(level), HorizontalAlignmentOptions.Left);
		LocalizationManager.Instance.UpdateTextMesh(descriptionLabel, LocalizedFontStyle.H2, sessionQuest.GetDescription(level), HorizontalAlignmentOptions.Left);
		UpdateProgressBar(sessionQuest.currentProgress);
		sessionQuest.OnProgressChanged += UpdateProgressBar;
	}

	private void UpdateProgressBar(int currentProgress)
	{
		progressLabel.text = $"{sessionQuest.GetCurrentProgress(level)} / {sessionQuest.TargetCount(level)}";
		DOTweenModuleUI.DOFillAmount(progressBarFill, (float)sessionQuest.GetCurrentProgress(level) / (float)sessionQuest.TargetCount(level), 0f);
	}

	private void OnDestroy()
	{
		if ((bool)sessionQuest)
		{
			sessionQuest.OnProgressChanged -= UpdateProgressBar;
		}
	}

	public void Show(bool newShow)
	{
		base.gameObject.SetActive(newShow);
	}
}
