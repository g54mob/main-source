using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainScene.Scripts
{
	public class ShowIngameMenu : MonoBehaviour
	{
		public GameObject OptionsPanel;

		public TweenPosition OptionsClosePanel;

		private bool _inOptions;

		private TweenPosition _tween;

		public void Start()
		{
			_tween = GetComponent<TweenPosition>();
			ToggleOptions(false);
		}

		public void Update()
		{
			if (!RuntimeGlobals.IsGameOver && !RuntimeGlobals.IsGameLoading && Input.GetKeyDown(KeyCode.Escape))
			{
				if (_inOptions)
				{
					ToggleOptions(false);
				}
				else
				{
					RuntimeGlobals.IsGamePaused = !RuntimeGlobals.IsGamePaused;
				}
			}
			Show(RuntimeGlobals.IsGamePaused);
		}

		public void Show(bool show)
		{
			_tween.Play(show);
		}

		private void ToggleOptions(bool active)
		{
			if (!(OptionsPanel == null) && !(OptionsClosePanel == null))
			{
				OptionsPanel.SetActive(active);
				OptionsClosePanel.Play(active);
				_inOptions = active;
			}
		}

		public void ShowOptions()
		{
			ToggleOptions(true);
		}

		public void HideOptions()
		{
			ToggleOptions(false);
		}
	}
}
