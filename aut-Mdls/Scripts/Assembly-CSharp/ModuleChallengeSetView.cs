using System.Collections.Generic;
using Presentation.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModuleChallengeSetView : MonoBehaviour
{
	[SerializeField]
	private ModuleChallengeSO _moduleChallengeSO;

	[SerializeField]
	private ObjectivesPersistentSO _objectivesPersistentSO;

	[Header("Challenge Set UI")]
	[SerializeField]
	private List<ModuleChallengeCategoryView> _categoryViews = new List<ModuleChallengeCategoryView>();

	[SerializeField]
	private TextMeshProUGUI _titleText;

	[SerializeField]
	private GameObject _titleBackgroundClaimed;

	[Header("Reward")]
	[SerializeField]
	private AdvancedTextInfoPanelContent _rewardInfoPanel;

	[SerializeField]
	private Image _rewardImage;

	[SerializeField]
	private TextMeshProUGUI _earnedModuleCountText;

	[SerializeField]
	private GameObject _lockClosed;

	[SerializeField]
	private GameObject _lockOpen;

	[SerializeField]
	private GameObject _glow;

	[SerializeField]
	private GameObject _setBackground;

	[SerializeField]
	private CanvasGroup _rewardCanvasGroup;

	[SerializeField]
	private Image _rewardBorder;

	[SerializeField]
	private Color _rewardImageColorLocked;

	[SerializeField]
	private Color _rewardImageColorClaimable;

	[SerializeField]
	private Color _borderColorLocked;

	[SerializeField]
	private Color _borderColorClaimable;

	[SerializeField]
	private Color _borderColorClaimed;

	[SerializeField]
	private Color _titleColorNormal;

	[SerializeField]
	private Color _titleColorClaimed;

	public ModuleChallengeSet ChallengeSet { get; set; }

	public List<ModuleChallengeCategoryView> CategoryViews => _categoryViews;

	private void OnDestroy()
	{
		LocalizationUtility.OnLanguageUpdate -= UpdateTexts;
	}

	public void Build(ModuleChallengeSet challengeSet)
	{
		LocalizationUtility.OnLanguageUpdate += UpdateTexts;
		ChallengeSet = challengeSet;
		_rewardImage.sprite = challengeSet.RewardThumbnail;
		_rewardCanvasGroup.alpha = 0.3f;
		UpdateTexts();
		ActivateSetBackground(value: false);
	}

	private void ActivateSetBackground(bool value)
	{
		_setBackground.SetActive(value);
		for (int i = 0; i < _categoryViews.Count; i++)
		{
			_categoryViews[i].ActivateBackground(!value);
		}
	}

	private void UpdateTexts()
	{
		_titleText.SetText(LocalizationUtility.GetLocalizedText(ChallengeSet.TitleLocaKey));
		_rewardInfoPanel.UpdateContent(LocalizationUtility.GetLocalizedText("Objectives.RewardCosmeticTitle"), LocalizationUtility.GetLocalizedText(ChallengeSet.RewardNameLocaKey));
	}

	public void UpdateValues(ModuleChallengeSet challengeSet)
	{
		_earnedModuleCountText.SetText($"{challengeSet.GetTotalCompletedMetalTiers()}/3");
		if (_objectivesPersistentSO.IsModuleChallengeAwardClaimed(ChallengeSet.ID))
		{
			_lockClosed.SetActive(value: false);
			_lockOpen.SetActive(value: true);
			_rewardImage.color = _rewardImageColorClaimable;
			_rewardCanvasGroup.alpha = 1f;
			ActivateSetBackground(value: true);
			_rewardBorder.color = _borderColorClaimed;
			_glow.SetActive(value: true);
			if (challengeSet.AllTiersCompleted)
			{
				_titleBackgroundClaimed.SetActive(value: true);
				_titleText.color = _titleColorClaimed;
			}
		}
		else
		{
			ActivateSetBackground(value: false);
			_lockClosed.SetActive(value: true);
			_lockOpen.SetActive(value: false);
			_rewardBorder.color = _borderColorLocked;
			_rewardImage.color = _rewardImageColorLocked;
			_rewardCanvasGroup.alpha = 0.3f;
			_glow.SetActive(value: false);
			_titleBackgroundClaimed.SetActive(value: false);
			_titleText.color = _titleColorNormal;
		}
	}
}
