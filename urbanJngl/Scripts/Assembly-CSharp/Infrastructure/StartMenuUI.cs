using System;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
	public class StartMenuUI : MonoBehaviour
	{
		public Button ResumeButton;

		public Button NewGameButton;

		public Button QuitButton;

		public Action OnResumeButton;

		public Action OnNewGAmeButton;

		public Action OnQuitButton;

		public static StartMenuUI Instance { get; private set; }

		private void Awake()
		{
			Instance = this;
			ResumeButton.onClick.AddListener(delegate
			{
				OnResumeButton?.Invoke();
			});
			NewGameButton.onClick.AddListener(delegate
			{
				OnNewGAmeButton?.Invoke();
			});
			QuitButton.onClick.AddListener(delegate
			{
				OnQuitButton?.Invoke();
			});
		}

		private void OnDestroy()
		{
			ResumeButton.onClick.RemoveAllListeners();
			NewGameButton.onClick.RemoveAllListeners();
			QuitButton.onClick.RemoveAllListeners();
		}
	}
}
