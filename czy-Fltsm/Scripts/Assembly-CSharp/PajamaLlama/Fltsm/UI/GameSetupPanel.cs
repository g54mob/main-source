using M4.Session;
using UnityEngine;
using UnityEngine.UI;

namespace PajamaLlama.Fltsm.UI
{
	public class GameSetupPanel : MonoBehaviour
	{
		[SerializeField]
		private GameSetupPage[] _pages;

		[SerializeField]
		private Button _buttonContinue;

		private GameSetup _gameSetup;

		private int _activePanelIndex;

		private GameSetupPage _activePanel;

		public TileProperties SelectedTileProperties { get; set; }

		public bool IsTutorial { get; set; }

		private void OnEnable()
		{
			ActivateOptionPanel(0);
			_buttonContinue.onClick.AddListener(OnContinue);
		}

		private void Update()
		{
			_buttonContinue.interactable = _activePanel.IsCompleted;
		}

		private void OnDisable()
		{
			if ((bool)_activePanel)
			{
				_activePanel.Deactivate();
				_activePanel = null;
			}
			_buttonContinue.onClick.RemoveListener(OnContinue);
		}

		public bool Activate(GameSetup gameSetup)
		{
			if (_pages.IsNullOrEmpty())
			{
				return false;
			}
			_gameSetup = gameSetup;
			base.gameObject.SetActive(value: true);
			return true;
		}

		private void ActivateOptionPanel(int index)
		{
			if (index < _pages.Length)
			{
				if ((bool)_activePanel)
				{
					_activePanel.Deactivate();
				}
				_activePanelIndex = index;
				_activePanel = _pages[index];
				if (_activePanel.Activate())
				{
					return;
				}
			}
			OnContinue();
		}

		private void OnContinue()
		{
			int num = _activePanelIndex + 1;
			if ((bool)_activePanel)
			{
				_gameSetup = _activePanel.Apply(_gameSetup);
			}
			if (num < _pages.Length)
			{
				ActivateOptionPanel(num);
			}
			else
			{
				Session.Profile.StartRun(_gameSetup);
			}
		}
	}
}
