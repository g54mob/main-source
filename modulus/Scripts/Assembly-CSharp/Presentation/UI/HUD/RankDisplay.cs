using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.HUD
{
	public class RankDisplay : MonoBehaviour
	{
		[Header("Layout")]
		[SerializeField]
		private Image _icon;

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private RectTransform _bar;

		[Header("Data")]
		[SerializeField]
		private RankConfigSO _rankConfig;

		[SerializeField]
		private OnUpdatedRankEvent _onUpdatedRankEvent;

		[Header("Info")]
		[SerializeField]
		private AdvancedTextInfoPanelContent _progressInfoPanelContent;

		private string _localizedText;

		private string _localizedProgressTitle;

		private string _localizedPermitText;

		private string _localizedPermitsText;

		private RankConfig _currentRank;

		private Vector3 _barScale = Vector3.one;

		private void Awake()
		{
			ChangeLocalization();
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
			UpdateRankDisplay();
			_onUpdatedRankEvent.Register(OnUpdatedRank);
			UpdateXP(0);
			_rankConfig.OnXPChanged += UpdateXP;
		}

		private void UpdateRankDisplay()
		{
			_currentRank = _rankConfig.GetCurrentRankConfig();
			SetText();
			_icon.sprite = _currentRank.Icon;
		}

		private void SetText()
		{
			_text.SetText(string.Format(_localizedText, $"<style=Normal>{_currentRank.Rank}</style>"));
			if (_progressInfoPanelContent != null)
			{
				_rankConfig.GetProgressUntilNextRank(out var currentXPInNextRank, out var nextRankXPDelta);
				SetXPToNextRank(currentXPInNextRank, nextRankXPDelta);
			}
		}

		private void SetXPToNextRank(int currentXPInNextRank, int nextRankXPDelta)
		{
			_progressInfoPanelContent.UpdateText1(string.Format(_localizedProgressTitle, nextRankXPDelta - currentXPInNextRank));
		}

		private void UpdateXP(int xp)
		{
			_barScale.x = _rankConfig.GetProgressUntilNextRank(out var currentXPInNextRank, out var nextRankXPDelta);
			_bar.localScale = _barScale;
			if (_progressInfoPanelContent != null)
			{
				_progressInfoPanelContent.enabled = nextRankXPDelta > 0;
				SetXPToNextRank(currentXPInNextRank, nextRankXPDelta);
				int expansionPermitsRewarded = _rankConfig.GetExpansionPermitsRewarded(_rankConfig.GetNextRankConfig());
				_progressInfoPanelContent.UpdateText2("+" + string.Format((expansionPermitsRewarded == 1) ? _localizedPermitText : _localizedPermitsText, expansionPermitsRewarded));
				_progressInfoPanelContent.ForceUpdate();
			}
		}

		private void OnLanguageUpdate()
		{
			ChangeLocalization();
			SetText();
			UpdateXP(_rankConfig.CurrentXp);
		}

		private void ChangeLocalization()
		{
			_localizedText = LocalizationUtility.GetLocalizedText("Rank.Rank");
			_localizedProgressTitle = LocalizationUtility.GetLocalizedText("Rank.ProgressToNextRank");
			_localizedPermitText = LocalizationUtility.GetLocalizedText("Rank.Permit-singular");
			_localizedPermitsText = LocalizationUtility.GetLocalizedText("Rank.Permit-plural");
		}

		private void OnDestroy()
		{
			_onUpdatedRankEvent.UnRegister(OnUpdatedRank);
			_rankConfig.OnXPChanged -= UpdateXP;
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
		}

		private void OnUpdatedRank(int value)
		{
			_currentRank = _rankConfig.GetCurrentRankConfig();
			UpdateRankDisplay();
		}
	}
}
