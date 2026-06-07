using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using CTS.UI;
using PixelCrushers.DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS
{
	public class GameOver : CTSSingleton<GameOver>
	{
		[SerializeField]
		private GameOverData _data;

		private readonly Dictionary<StringKey<GameOverUIData>, GameOverUIData> _lookupTable = new Dictionary<StringKey<GameOverUIData>, GameOverUIData>();

		[InjectScope(EGetScope.Children)]
		[SerializeField]
		[Inject(false)]
		private CanvasGroupController _gameOverCanvas;

		[SerializeField]
		private Image _backgroundImage;

		[SerializeField]
		private Image _frontImage;

		[SerializeField]
		private TMP_Text _descriptionText;

		private static GameOverUIData _currentGameOver;

		private readonly List<GameOverListener> _currentGameOvers = new List<GameOverListener>();

		private readonly List<GameOverUIData> _triggeredGameOvers = new List<GameOverUIData>();

		public float EndTimer { get; private set; }

		public float GraceTimer { get; private set; }

		public float EndTimerDuration => _data.LooseTimerDuration;

		public float GraceTimerDuration => _data.GraceTimerDuration;

		public static bool IsGameOver => (object)_currentGameOver != null;

		public bool IsTimerActive
		{
			get
			{
				if (!IsGameOver)
				{
					return _currentGameOvers.Count > 0;
				}
				return false;
			}
		}

		public static event Action<GameOverUIData> GameOverTriggered;

		public static event Action<bool> GameOverTimerTriggered;

		public static event Action OnPlayerEscape;

		protected override void SingletonAwake()
		{
			EndTimer = EndTimerDuration;
			GraceTimer = GraceTimerDuration;
			_currentGameOver = null;
			LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
			foreach (GameOverUIData gameOver in _data.GameOverList)
			{
				_lookupTable[gameOver] = gameOver;
			}
		}

		protected override void OnSingletonDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
			_currentGameOver = null;
		}

		private void Update()
		{
			if (!IsTimerActive)
			{
				return;
			}
			foreach (GameOverListener currentGameOver in _currentGameOvers)
			{
				if (currentGameOver.IsGameOverValid())
				{
					GraceTimer = GraceTimerDuration;
					EndTimer -= Time.deltaTime;
					if (EndTimer <= 0f)
					{
						EndGame(currentGameOver.GameOverType);
					}
					return;
				}
			}
			GraceTimer -= Time.deltaTime;
			if (!(GraceTimer > 0f))
			{
				for (int num = _currentGameOvers.Count - 1; num >= 0; num--)
				{
					GameOverListener gameOverType = _currentGameOvers[num];
					StopGameOver(gameOverType);
				}
			}
		}

		public void StartGameOver(GameOverListener gameOverType)
		{
			if (_currentGameOvers.Contains(gameOverType))
			{
				return;
			}
			_currentGameOvers.Add(gameOverType);
			gameOverType.enabled = false;
			if (_currentGameOvers.Count == 1)
			{
				if (!_triggeredGameOvers.Contains(gameOverType.GameOverType))
				{
					_triggeredGameOvers.Add(gameOverType.GameOverType);
					CTSSingleton<UIMessage>.Instance.ShowMessage(gameOverType.GameOverType.PopupMessage);
				}
				GameOver.GameOverTimerTriggered?.Invoke(obj: true);
			}
		}

		public void StopGameOver(GameOverListener gameOverType)
		{
			if (_currentGameOvers.Contains(gameOverType))
			{
				_currentGameOvers.Remove(gameOverType);
				gameOverType.enabled = true;
				if (_currentGameOvers.Count <= 0)
				{
					EndTimer = EndTimerDuration;
					GraceTimer = GraceTimerDuration;
					GameOver.GameOverTimerTriggered?.Invoke(obj: false);
					GameOver.OnPlayerEscape?.Invoke();
				}
			}
		}

		public void EndGame(StringKey<GameOverUIData> key)
		{
			GameOverUIData gameOverType = _lookupTable[key];
			EndGame(gameOverType);
		}

		public void EndGame(GameOverUIData gameOverType)
		{
			if (!gameOverType)
			{
				throw new NullReferenceException("Game over has no data");
			}
			if (!IsGameOver)
			{
				_currentGameOver = gameOverType;
				DialogueManager.StopAllConversations();
				MonoSingleton<TimeController>.Instance.TimeMode = ETimeModes.Pause;
				_gameOverCanvas.QuickShow();
				UpdateText();
				UpdateImages();
				GameOver.GameOverTriggered?.Invoke(_currentGameOver);
			}
		}

		private void UpdateImages()
		{
			if ((bool)_currentGameOver)
			{
				_backgroundImage.sprite = _currentGameOver.BackgroundImage;
				_frontImage.sprite = _currentGameOver.FrontImage;
			}
		}

		private void UpdateText()
		{
			if ((bool)_currentGameOver)
			{
				_descriptionText.text = _currentGameOver.Description.GetLocalizedStringSafe();
			}
		}

		private void OnLocaleChanged(Locale obj)
		{
			UpdateText();
		}
	}
}
