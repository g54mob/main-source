using System.Collections;
using CTS.Core;
using CTS.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace CTS
{
	public class LevelTitle : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CanvasGroupController _canvasGroupController;

		[SerializeField]
		private float _timeBeforeTitle = 3f;

		[SerializeField]
		private float _transitionDuration = 1f;

		[SerializeField]
		private float _titleDuration = 3f;

		[SerializeField]
		private bool _playOnStart = true;

		[SerializeField]
		private LocalizedString _freemodeSubtitle;

		[Header("References")]
		[SerializeField]
		private Image _mapIcon;

		[SerializeField]
		private TMP_Text _mainTitle;

		[SerializeField]
		private TMP_Text _subTitle;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private AutomaticMapLoader _mapLoader;

		[SerializeField]
		[Inject(false)]
		private GameMode _gameMode;

		public bool IsVisible { get; private set; } = true;

		private void Start()
		{
			if (_playOnStart)
			{
				StartShowLevelTitle();
			}
		}

		public void StartShowLevelTitle()
		{
			StopAllCoroutines();
			StartCoroutine(ShowLevelTitle());
		}

		private IEnumerator ShowLevelTitle()
		{
			if ((bool)_mapLoader)
			{
				yield return new WaitUntil(() => _mapLoader.MapIsLoaded);
			}
			MapInfoSO levelInfo = _gameMode.LevelInfo;
			if ((bool)levelInfo)
			{
				UpdateVisuals(levelInfo);
			}
			yield return Coroutines.WaitForSecondsUnscaled(_timeBeforeTitle);
			_canvasGroupController.ShowCanvasGroup(show: true, _transitionDuration);
			yield return Coroutines.WaitForSecondsUnscaled(_titleDuration);
			_canvasGroupController.ShowCanvasGroup(show: false, _transitionDuration);
			IsVisible = false;
		}

		public void UpdateVisuals(MapInfoSO mapInfoSO)
		{
			_mapIcon.overrideSprite = mapInfoSO.MapIconBig;
			if (_gameMode.CurrentMode == EGameMode.FreeMode)
			{
				_mainTitle.text = mapInfoSO.LevelNameLocalizationString.GetLocalizedStringSafe();
				_subTitle.text = _freemodeSubtitle.GetLocalizedStringSafe();
			}
			else
			{
				_mainTitle.text = mapInfoSO.StoryModeTitle.GetLocalizedStringSafe();
				_subTitle.text = mapInfoSO.StoryModeSubtitle.GetLocalizedStringSafe();
			}
		}
	}
}
