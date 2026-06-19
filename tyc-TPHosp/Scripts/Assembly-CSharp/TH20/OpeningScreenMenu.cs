using System;
using System.Globalization;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class OpeningScreenMenu : MonoBehaviour
	{
		[SerializeField]
		private DynamicButton _continueButton;

		[SerializeField]
		private DynamicButton _newCareerButton;

		[SerializeField]
		private DynamicButton _saveSlotsButton;

		[SerializeField]
		private DynamicButton _sandboxButton;

		[SerializeField]
		private DynamicButton _settingsButton;

		[SerializeField]
		private DynamicButton _quitButton;

		[SerializeField]
		private Image _screenshotImage;

		[SerializeField]
		private TextMeshProUGUI _foundationNameText;

		[SerializeField]
		private TextMeshProUGUI _timeAndDateText;

		[SerializeField]
		private TextMeshProUGUI _totalStarsText;

		[SerializeField]
		private TextMeshProUGUI _totalSilverText;

		[SerializeField]
		private TextMeshProUGUI _totalFoundationValueText;

		private Texture2D _screenshotTexture;

		public Action OnContinue;

		public Action OnNewCareer;

		public Action OnSaveSlots;

		public Action OnSandbox;

		public Action OnSettings;

		public Action OnQuit;

		private void Start()
		{
			_continueButton.onPrimaryDown.AddListener(OnContinuePressed);
			_newCareerButton.onPrimaryDown.AddListener(OnNewCareerPressed);
			_saveSlotsButton.onPrimaryDown.AddListener(OnSaveSlotsPressed);
			_sandboxButton.onPrimaryDown.AddListener(OnSandboxPressed);
			_settingsButton.onPrimaryDown.AddListener(OnSettingsPressed);
			_quitButton.onPrimaryDown.AddListener(OnQuitPressed);
		}

		public void SetupButtonsForExistingSave(UserProfile userProfile, MetagameSaveHeader metagameSaveHeader)
		{
			_continueButton.transform.parent.gameObject.SetActive(value: true);
			_newCareerButton.transform.parent.gameObject.SetActive(value: false);
			SetupSandboxButton(userProfile);
			if (metagameSaveHeader.ThumbnailPNG != null)
			{
				if (_screenshotTexture == null)
				{
					_screenshotTexture = new Texture2D(1, 1, TextureFormat.DXT1, mipChain: false);
				}
				_screenshotTexture.LoadImage(metagameSaveHeader.ThumbnailPNG);
				_screenshotImage.overrideSprite = Sprite.Create(_screenshotTexture, new Rect(0f, 0f, _screenshotTexture.width, _screenshotTexture.height), new Vector2(0f, 0f));
				_screenshotImage.color = Color.white;
			}
			else
			{
				_screenshotImage.overrideSprite = null;
			}
			_foundationNameText.text = metagameSaveHeader.OrganisationName;
			_timeAndDateText.text = metagameSaveHeader.Date.ToString(CultureInfo.CurrentCulture);
			_totalStarsText.text = StringUtils.FormatNumber(metagameSaveHeader.TotalStars);
			_totalSilverText.text = StringUtils.FormatSilverCurrency(metagameSaveHeader.TotalSilver);
			_totalFoundationValueText.text = StringUtils.FormatCurrency(metagameSaveHeader.TotalFoundationValue);
		}

		public void SetupButtonsForNoSave(UserProfile userProfile)
		{
			_continueButton.transform.parent.gameObject.SetActive(value: false);
			_newCareerButton.transform.parent.gameObject.SetActive(value: true);
			SetupSandboxButton(userProfile);
		}

		private void SetupSandboxButton(UserProfile userProfile)
		{
			bool flag = userProfile.IsSandboxUnlocked || DebugVars.EnableSandboxMode.Value;
			ButtonAnimator componentInChildren = _sandboxButton.gameObject.GetComponentInChildren<ButtonAnimator>();
			TooltipSpawner componentInChildren2 = _sandboxButton.gameObject.GetComponentInChildren<TooltipSpawner>();
			_sandboxButton.interactable = flag;
			if (componentInChildren != null)
			{
				componentInChildren.CurrentState = ((!flag) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			}
			if (componentInChildren2 != null)
			{
				componentInChildren2.enabled = !flag;
			}
		}

		private void OnDestroy()
		{
			_continueButton.onPrimaryDown.RemoveListener(OnContinuePressed);
			_newCareerButton.onPrimaryDown.RemoveListener(OnNewCareerPressed);
			_saveSlotsButton.onPrimaryDown.RemoveListener(OnSaveSlotsPressed);
			_sandboxButton.onPrimaryDown.RemoveListener(OnSandboxPressed);
			_settingsButton.onPrimaryDown.RemoveListener(OnSettingsPressed);
			_quitButton.onPrimaryDown.RemoveListener(OnQuitPressed);
		}

		private void OnContinuePressed()
		{
			OnContinue.InvokeSafe();
		}

		private void OnNewCareerPressed()
		{
			OnNewCareer.InvokeSafe();
		}

		private void OnSaveSlotsPressed()
		{
			OnSaveSlots.InvokeSafe();
		}

		private void OnSandboxPressed()
		{
			OnSandbox.InvokeSafe();
		}

		private void OnSettingsPressed()
		{
			OnSettings.InvokeSafe();
		}

		private void OnQuitPressed()
		{
			OnQuit.InvokeSafe();
		}
	}
}
