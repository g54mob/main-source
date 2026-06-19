using System.Globalization;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HospitalSaveInfoPanel : MonoBehaviour
	{
		[SerializeField]
		private GameObject _currentSavePanel;

		[SerializeField]
		private Image _currentSaveScreenshot;

		[SerializeField]
		private TMP_Text _balanceValueLabel;

		[SerializeField]
		private TMP_Text _hospitalValueLabel;

		[SerializeField]
		private ProgressBarMaskable _reputationProgressBar;

		[SerializeField]
		private ProgressBarMaskable _prestigeProgressBar;

		[SerializeField]
		private TMP_Text _prestigeValueLabel;

		[SerializeField]
		private TMP_Text _saveDateAndTimeLabel;

		[SerializeField]
		private Localize _saveDateAndTimeLabelLocalize;

		private Texture2D _saveThumbnailTexture;

		public void Initialize()
		{
			_saveThumbnailTexture = new Texture2D(1, 1, TextureFormat.DXT1, mipChain: false, linear: false);
		}

		public void SetActive(bool active)
		{
			_currentSavePanel.SetActive(active);
		}

		public void UpdateFromLevel(Level level)
		{
			_balanceValueLabel.text = StringUtils.FormatCurrencyWithoutSymbol(level.FinanceManager.Balance);
			_hospitalValueLabel.text = StringUtils.FormatCurrencyWithoutSymbol(level.LevelStatsDatabase.HospitalValue);
			_reputationProgressBar.SetProgressSmooth(level.ReputationTracker.OverallReputation);
			_prestigeProgressBar.SetProgressSmooth(level.PrestigeTracker.Progress);
			_prestigeValueLabel.text = string.Format(ScriptLocalization.Misc.PrestigeLevel_CS, level.PrestigeTracker.Level);
			_saveDateAndTimeLabelLocalize.Term = "Misc/YouArePlayingThisLevel_CS";
			_saveThumbnailTexture.LoadImage(level.ThumbnailPNG);
			_currentSaveScreenshot.overrideSprite = Sprite.Create(_saveThumbnailTexture, new Rect(0f, 0f, _saveThumbnailTexture.width, _saveThumbnailTexture.height), new Vector2(0f, 0f));
			_currentSaveScreenshot.color = Color.white;
		}

		public void UpdateFromSave(SaveFileHeader saveHeader)
		{
			_balanceValueLabel.text = StringUtils.FormatCurrencyWithoutSymbol(saveHeader.Balance);
			_hospitalValueLabel.text = StringUtils.FormatCurrencyWithoutSymbol(saveHeader.HospitalValue);
			_reputationProgressBar.SetProgressSmooth(saveHeader.Reputation);
			_prestigeProgressBar.SetProgressSmooth(saveHeader.HospitalLevelProgress);
			_prestigeValueLabel.text = string.Format(ScriptLocalization.Misc.PrestigeLevel_CS, saveHeader.HospitalLevel);
			_saveDateAndTimeLabelLocalize.Term = "-";
			_saveDateAndTimeLabel.text = saveHeader.Date.ToString(CultureInfo.CurrentCulture);
			_saveThumbnailTexture.LoadImage(saveHeader.ThumbnailPNG);
			_currentSaveScreenshot.overrideSprite = Sprite.Create(_saveThumbnailTexture, new Rect(0f, 0f, _saveThumbnailTexture.width, _saveThumbnailTexture.height), new Vector2(0f, 0f));
			_currentSaveScreenshot.color = Color.white;
		}
	}
}
