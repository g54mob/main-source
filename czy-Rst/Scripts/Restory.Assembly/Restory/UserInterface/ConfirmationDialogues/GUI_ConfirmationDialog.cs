using System;
using Restory.Data.Localization;
using Restory.EventSystems;
using Restory.ObjectPools;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.ConfirmationDialogues
{
	public class GUI_ConfirmationDialog : GUI_ConfirmationDialogueBase
	{
		private float showTime;

		private float delay = 0.5f;

		private ActiveSelectionService activeSelectionService;

		private GlobalObjectPool objectPool;

		public bool IsPoolable { get; set; } = true;

		private bool IsReadyToInteract => showTime + delay <= Time.realtimeSinceStartup;

		public GameObject SourcePrefab { get; set; }

		[Inject]
		private void Construct(GlobalObjectPool objectPool, LocalizationSystem localizationSystem, ActiveSelectionService activeSelectionService)
		{
			this.objectPool = objectPool;
			LocalizationSystem = localizationSystem;
			this.activeSelectionService = activeSelectionService;
			if (base.isActiveAndEnabled)
			{
				Subscribe();
			}
		}

		private void OnEnable()
		{
			Subscribe();
		}

		private void OnDisable()
		{
			Unsubscribe();
			UnblockSelection();
		}

		private void Subscribe()
		{
			positiveButton.onClick.AddListener(base.OnSelectedPositive);
			negativeButton.onClick.AddListener(base.OnSelectedNegative);
		}

		private void Unsubscribe()
		{
			if (positiveButton.MonoShellExists())
			{
				positiveButton.onClick.RemoveListener(base.OnSelectedPositive);
			}
			if (negativeButton.MonoShellExists())
			{
				negativeButton.onClick.RemoveListener(base.OnSelectedNegative);
			}
		}

		public void ShowLocalizedMessage(string localizationKey, Action onPressPositive = null, Action onPressNegative = null)
		{
			string translation = LocalizationSystem.GetTranslation(localizationKey);
			ShowChoice(translation, onPressPositive, onPressNegative);
		}

		public void ShowChoice(string message, Action onPressPositive = null, Action onPressNegative = null)
		{
			if (!base.isActiveAndEnabled)
			{
				base.gameObject.SetActive(value: true);
			}
			showTime = Time.realtimeSinceStartup;
			BlockSelection();
			SetUpValues(message, onPressPositive, onPressNegative);
		}

		private void SetUpValues(string message, Action onPressPositive, Action onPressNegative)
		{
			base.IsActive = true;
			content.SetActive(value: true);
			description.text = message;
			OnPositiveSelection = onPressPositive;
			OnNegativeSelection = onPressNegative;
		}

		private void BlockSelection()
		{
			if (activeSelectionService != null)
			{
				activeSelectionService.CanRestoreCurrentSelection = false;
			}
		}

		private void UnblockSelection()
		{
			if (activeSelectionService != null)
			{
				activeSelectionService.CanRestoreCurrentSelection = true;
			}
		}

		public override void Close()
		{
			StopAllCoroutines();
			UnblockSelection();
			base.gameObject.SetActive(value: false);
			base.IsActive = false;
		}

		private void ClearValues()
		{
			content.SetActive(value: false);
			base.IsActive = false;
			OnPositiveSelection = null;
			OnNegativeSelection = null;
		}
	}
}
