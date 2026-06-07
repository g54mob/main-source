using System;
using I2.Loc;
using Mirror;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialInfoUI : MonoBehaviour
{
	[Header("UI References")]
	[SerializeField]
	private TextMeshProUGUI titleText;

	[SerializeField]
	private TextMeshProUGUI descriptionText;

	[SerializeField]
	private Image infoImage;

	[SerializeField]
	private GameObject infoMask;

	[SerializeField]
	private GameObject closeButton;

	[SerializeField]
	private GameObject hostWarning;

	[SerializeField]
	private GameObject inputInfoBack;

	private bool _isActive;

	public bool IsActive => _isActive;

	public event Action OnCloseRequested;

	public void Show(TutorialStep stepData, bool canClose = true)
	{
		_isActive = true;
		base.gameObject.SetActive(value: true);
		bool flag = !NetworkServer.active;
		if (closeButton != null)
		{
			closeButton.SetActive(canClose && !flag);
		}
		if (hostWarning != null)
		{
			hostWarning.SetActive(flag);
		}
		if (inputInfoBack != null)
		{
			inputInfoBack.SetActive(!flag);
		}
		if (titleText != null)
		{
			string translation = LocalizationManager.GetTranslation(stepData.stepTitle);
			titleText.text = ((!string.IsNullOrEmpty(translation)) ? translation : stepData.stepTitle);
		}
		if (descriptionText != null)
		{
			string translation2 = LocalizationManager.GetTranslation(stepData.stepDescription);
			descriptionText.text = ((!string.IsNullOrEmpty(translation2)) ? translation2 : stepData.stepDescription);
		}
		bool flag2 = stepData.stepImage != null;
		if (infoImage != null)
		{
			if (flag2)
			{
				infoImage.sprite = stepData.stepImage;
				infoImage.gameObject.SetActive(value: true);
			}
			else
			{
				infoImage.gameObject.SetActive(value: false);
			}
		}
		if (infoMask != null)
		{
			infoMask.SetActive(flag2);
		}
	}

	public void Hide()
	{
		_isActive = false;
		base.gameObject.SetActive(value: false);
	}

	public void HandleCloseClicked()
	{
		if (NetworkServer.active)
		{
			if (!_isActive)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			_isActive = false;
			base.gameObject.SetActive(value: false);
			this.OnCloseRequested?.Invoke();
		}
	}
}
