using System;
using Dorfromantik.UI.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik
{
	public class SaveButton : TooltipTarget
	{
		[SerializeField]
		private UiIconButton button;

		[SerializeField]
		private Button unityButton;

		[SerializeField]
		private SaveFileManager saveFileManager;

		[SerializeField]
		private bool isDefaultSelectable;

		private bool shouldStayHidden;

		private bool activeGameSaved;

		private LocalizedText localizedText;

		public bool Interactable
		{
			get
			{
				if (!shouldStayHidden)
				{
					return !activeGameSaved;
				}
				return false;
			}
		}

		public Selectable Button => unityButton;

		public event Action OnStateChanged;

		public void UpdateButtonState()
		{
			activeGameSaved = saveFileManager.ActiveSaveGame != null && !string.IsNullOrWhiteSpace(saveFileManager.ActiveSaveGame.fileName);
			if ((bool)button)
			{
				button.SetVisualStateDisabled(activeGameSaved);
				button.gameObject.SetActive(!shouldStayHidden);
			}
			else if ((bool)unityButton)
			{
				unityButton.interactable = !activeGameSaved;
				if (activeGameSaved)
				{
					unityButton.animator.SetTrigger(unityButton.animationTriggers.disabledTrigger);
				}
				if (activeGameSaved)
				{
					OverwritingSingleton<IngameUi>.Instance.SelectGameOverScreenDefault();
				}
				unityButton.gameObject.SetActive(!shouldStayHidden);
			}
			if ((bool)localizedText)
			{
				localizedText.UpdateLocalizedKey(activeGameSaved ? "menu_saved" : "menu_saveGame");
			}
			this.OnStateChanged?.Invoke();
		}

		private void Awake()
		{
			localizedText = GetComponent<LocalizedText>();
			shouldStayHidden = saveFileManager.ActiveSaveGame != null && saveFileManager.ActiveSaveGame.HasSaveFile;
		}

		private void OnEnable()
		{
			saveFileManager.OnAutoSaveChanged += UpdateButtonStateFromAutosaveChanged;
		}

		private void OnDisable()
		{
			saveFileManager.OnAutoSaveChanged -= UpdateButtonStateFromAutosaveChanged;
		}

		private void UpdateButtonStateFromAutosaveChanged(GameMode gameMode)
		{
			UpdateButtonState();
		}

		protected override void Start()
		{
			base.Start();
			UpdateButtonState();
		}

		protected override string GetTooltipText()
		{
			if (!activeGameSaved)
			{
				return LocalizationManager.Instance.GetLocalizedValue("menu_saveGame");
			}
			return LocalizationManager.Instance.GetLocalizedValue("menu_saved");
		}
	}
}
