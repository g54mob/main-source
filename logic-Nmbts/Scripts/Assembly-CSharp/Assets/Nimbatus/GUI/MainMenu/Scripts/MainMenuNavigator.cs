using System.Collections;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.Tutorial;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	public class MainMenuNavigator : SerializedMonoBehaviour
	{
		public TweenPosition[] MainPageObjects;

		public TweenPosition[] OptionPageObjects;

		public TweenPosition[] CreditObjects;

		public TweenPosition[] CreateGameObjects;

		public TweenPosition[] TutorialSelectionObjects;

		public TweenPosition[] LoadingObjects;

		public TweenPosition[] LoadTutorialObjects;

		public TweenPosition[] InitialTutorialObjects;

		public TweenPosition[] AchievementsObjects;

		public TweenPosition[] PopupObjects;

		public TweenPosition[] KeybindingObjects;

		public TweenAlpha BackgroundTween;

		public TweenAlpha LoadingTween;

		public static EMainMenuPage PageToLoad;

		public static EMainMenuPage CurrentPage;

		public static MainMenuNavigator Instance;

		private float _duration;

		private bool _start;

		private static bool _skipPopup;

		protected void Awake()
		{
			Instance = this;
		}

		public void Start()
		{
			_start = true;
			LoadingTween.PlayReverse();
			if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.ExitingTutorial)
			{
				SaveManager.StartEmptyGame(EGameMode.Tutorial);
				NavigateTowards(EMainMenuPage.TutorialSelection);
				GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.ExitingTutorial = false;
			}
			else
			{
				NavigateTowards(EMainMenuPage.Main);
			}
		}

		public void NavigateTowards(EMainMenuPage page, float duration = 0.5f)
		{
			_duration = duration;
			NavigateTowardsPage(page);
		}

		private void NavigateTowardsPage(EMainMenuPage page)
		{
			if (page == EMainMenuPage.Main)
			{
				if (_start)
				{
					StartCoroutine(BackgroundReverse(0f));
				}
				else
				{
					StartCoroutine(BackgroundReverse(0.25f));
				}
			}
			else
			{
				BackgroundTween.PlayForward();
			}
			PlayBackwards(LoadingObjects);
			PlayBackwards(MainPageObjects);
			PlayBackwards(OptionPageObjects);
			PlayBackwards(CreditObjects);
			PlayBackwards(CreateGameObjects);
			PlayBackwards(TutorialSelectionObjects);
			PlayBackwards(InitialTutorialObjects);
			PlayBackwards(AchievementsObjects);
			PlayBackwards(PopupObjects);
			PlayBackwards(KeybindingObjects);
			LoadingTween.PlayReverse();
			switch (page)
			{
			case EMainMenuPage.Main:
				PlayForward(MainPageObjects);
				break;
			case EMainMenuPage.Options:
				PlayForward(OptionPageObjects);
				break;
			case EMainMenuPage.Credits:
				PlayForward(CreditObjects);
				break;
			case EMainMenuPage.CreateGame:
				PlayForward(CreateGameObjects);
				break;
			case EMainMenuPage.TutorialSelection:
				PlayForward(TutorialSelectionObjects);
				break;
			case EMainMenuPage.Loading:
				PlayForward(LoadingObjects);
				LoadingTween.PlayForward();
				break;
			case EMainMenuPage.LoadTutorial:
				PlayForward(LoadTutorialObjects);
				break;
			case EMainMenuPage.InitialTutorial:
				PlayForward(InitialTutorialObjects);
				break;
			case EMainMenuPage.Achievements:
				PlayForward(AchievementsObjects);
				break;
			case EMainMenuPage.BuyGamePopup:
				PlayForward(PopupObjects);
				break;
			case EMainMenuPage.KeyBinding:
				PlayForward(KeybindingObjects);
				break;
			}
			CurrentPage = page;
			_start = false;
		}

		private void PlayForward(TweenPosition[] positions)
		{
			if (positions == null)
			{
				return;
			}
			foreach (TweenPosition tweenPosition in positions)
			{
				if (_duration > 0f)
				{
					tweenPosition.duration = _duration;
				}
				tweenPosition.PlayForward();
			}
		}

		private void PlayBackwards(TweenPosition[] positions)
		{
			if (positions == null)
			{
				return;
			}
			foreach (TweenPosition tweenPosition in positions)
			{
				if (_duration > 0f)
				{
					tweenPosition.duration = _duration;
				}
				tweenPosition.PlayReverse();
			}
		}

		private IEnumerator BackgroundReverse(float delay)
		{
			yield return new WaitForSecondsRealtime(delay);
			BackgroundTween.PlayReverse();
		}
	}
}
