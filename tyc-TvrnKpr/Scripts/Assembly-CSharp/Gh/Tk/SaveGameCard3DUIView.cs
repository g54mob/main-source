using System;
using System.Collections.Generic;
using I18n;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gh.Tk
{
	public class SaveGameCard3DUIView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProI18n _saveNameText;

		[SerializeField]
		private TextMeshProI18n _timeAgoText;

		[SerializeField]
		private TMP_Text _moneyText;

		[SerializeField]
		private TextMeshProI18n _approvalText;

		[SerializeField]
		private TextMeshProI18n _tavernNameText;

		[SerializeField]
		private TextMeshProI18n _saveDayText;

		[SerializeField]
		private Image[] _screenshotRenderers;

		[SerializeField]
		private Button3DUIView _continueButton;

		[SerializeField]
		private Button3DUIView _olderSavesButton;

		[SerializeField]
		private Button3DUIView _saveOptionsButton;

		[SerializeField]
		private StarVisualSocket[] _starVisuals;

		[SerializeField]
		public BaseInteractable3DUIView _bugOccurredIcon;

		[SerializeField]
		public BaseInteractable3DUIView _scenarioIcon;

		private SaveLoadManager.SaveGameHeader _saveGame;

		private List<ContextMenuItem> _optionMenuItems;

		private bool _isOptionsDirty;

		private static bool _isRetrievingShareCode;

		public SaveLoadManager.SaveGameHeader SaveGame => null;

		private void Awake()
		{
		}

		private void OnSaveHeadersCacheUpdated(object sender, EventArgs e)
		{
		}

		public void SetScreenshot(Texture2D screenshot)
		{
		}

		private void OnEnable()
		{
		}

		private void UpdateOlderSavesButton(Action<Button3DUIView> olderSavesAction)
		{
		}

		private void PopulateContextMenu()
		{
		}

		public void SetData(SaveLoadManager.SaveGameHeader saveGame, Action<Button3DUIView> olderSavesAction)
		{
		}

		private void UpdateStarBoard(float rating)
		{
		}

		public void CheckOldSaveButtonState(string tavernId)
		{
		}
	}
}
