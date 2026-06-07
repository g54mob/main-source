using System;
using System.Collections.Generic;
using DG.Tweening;
using Lexone.UnityTwitchChat;
using Rewired.Integration.UnityUI;
using TMPro;
using UnityEngine;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.UI.Twitch
{
	public class TwitchLevelUpPanel : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _CountDownBackground;

		[SerializeField]
		private Transform _CountDownFill;

		[SerializeField]
		private TextMeshProUGUI _CountDownNumberText;

		[SerializeField]
		private TwitchLevelUpOption _OptionPrefab;

		[SerializeField]
		private RectTransform _PositionOption1;

		[SerializeField]
		private RectTransform _PositionOption2;

		[SerializeField]
		private RectTransform _PositionOption3;

		[SerializeField]
		private RectTransform _PositionOption4;

		[SerializeField]
		private RectTransform _PositionRerolls;

		[SerializeField]
		private RectTransform _PositionSkip;

		[SerializeField]
		private RectTransform _PositionBanish;

		[SerializeField]
		private RectTransform _PositionPass;

		[SerializeField]
		private GameObject _NavigatorsRoot;

		private CanvasGroup _canvasGroup;

		private LevelUpPage _levelUpPage;

		private bool _banishChoice;

		private bool _countdownStarted;

		private int _rerollOptionNumber;

		private int _skipOptionNumber;

		private int _banishOptionNumber;

		private int _passOptionNumber;

		private int _twitchLimitCount;

		private List<int> _twitchOptionCounter;

		private int _howManyOptions;

		private List<TwitchLevelUpOption> _twitchOptionsPool;

		private List<TwitchLevelUpOption> _twitchOptions;

		private Tween _twitchCountdownBarTween;

		private RewiredStandaloneInputModule _inputModule;

		private const int CountdownLength = 7;

		private RewiredStandaloneInputModule InputModule => null;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void InitTwitchPanel(LevelUpPage levelUpPage)
		{
		}

		public void ShowCountdown()
		{
		}

		public void EnableAllUIInteraction()
		{
		}

		private void CreateCountDownBar()
		{
		}

		private void CreateButtons()
		{
		}

		private TwitchLevelUpOption SpawnTwitchOption(Transform parent, RectTransform targetPositionTransform, Action callback)
		{
			return null;
		}

		private TwitchLevelUpOption GrabOptionFromPool()
		{
			return null;
		}

		private void AdjustOptionSpawnPosition(Transform spawnParentTransform, RectTransform targetRectTransform)
		{
		}

		private void CleanTwitchOptions()
		{
		}

		private void StartCountdown()
		{
		}

		private void EnterCountdownNumber(int num)
		{
		}

		private void ExitCountdownNumber(int num)
		{
		}

		private void EndCountDownNumber(int num)
		{
		}

		private void CountdownComplete()
		{
		}

		private void ProcessMessage(Chatter chatter)
		{
		}

		private void IncreaseTwitchOption(int num, string username)
		{
		}

		private int CalculateChoice()
		{
			return 0;
		}

		private void DisableAllUIInteraction()
		{
		}

		private void OptionZeroSelected()
		{
		}

		private void OptionOneSelected()
		{
		}

		private void OptionTwoSelected()
		{
		}

		private void OptionThreeSelected()
		{
		}

		private void OptionSelected(int num)
		{
		}

		private void OnTwitchReroll()
		{
		}

		private void OnTwitchSkip()
		{
		}

		private void OnTwitchBanish()
		{
		}

		private void SetBanishMode()
		{
		}

		private void OnTwitchPass()
		{
		}

		private void ResetTwitchOptionCounterValues()
		{
		}
	}
}
