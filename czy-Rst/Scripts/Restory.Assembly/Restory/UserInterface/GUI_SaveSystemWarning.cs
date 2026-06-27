using System;
using Restory.Data.Localization;
using Restory.Data.SaveLoad;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface
{
	public class GUI_SaveSystemWarning : MonoBehaviour
	{
		[SerializeField]
		private bool checkWarning;

		[SerializeField]
		private SaveIssuesMessages saveIssuesMessages;

		[SerializeField]
		private TextMeshProUGUI warning;

		[SerializeField]
		private Button closeButton;

		private IDiskSpaceService diskSpaceService;

		private LocalizationSystem localizationSystem;

		public bool IsShown => base.gameObject.activeSelf;

		public event Action OnWarningShown = delegate
		{
		};

		public event Action OnWarningClosed = delegate
		{
		};

		[Inject]
		private void Construct(IDiskSpaceService diskSpaceService, LocalizationSystem localizationSystem)
		{
			this.diskSpaceService = diskSpaceService;
			this.localizationSystem = localizationSystem;
		}

		private void OnEnable()
		{
			closeButton.onClick.AddListener(OnCloseWarningClick);
		}

		private void OnDisable()
		{
			if ((bool)closeButton)
			{
				closeButton.onClick.RemoveListener(OnCloseWarningClick);
			}
		}

		public void Check()
		{
			if (!IsEnoughDiskSpace())
			{
				ShowWarning(saveIssuesMessages.NotEnoughDiskSpace);
			}
			else
			{
				Close();
			}
		}

		public void OnCloseWarningClick()
		{
			if ((bool)base.gameObject && base.gameObject.activeInHierarchy)
			{
				Close();
			}
		}

		private void ShowWarning(FallbackText text)
		{
			if (!localizationSystem.TryGetTranslation(text.Key, out var translatedValue))
			{
				translatedValue = text.FallbackValue;
			}
			warning.text = translatedValue;
			base.gameObject.SetActive(value: true);
			this.OnWarningShown();
		}

		public void Close()
		{
			base.gameObject.SetActive(value: false);
			this.OnWarningClosed();
		}

		private bool IsEnoughDiskSpace()
		{
			return diskSpaceService.IsEnoughDiskSpace();
		}
	}
}
