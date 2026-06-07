using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Gh.Tk.UI;
using I18n;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Gh.Tk
{
	public class LoadingScreenUI : SingletonMonoBehaviour<LoadingScreenUI>
	{
		public class LoadingScreenArt
		{
			public string id;

			public List<string> tags;

			public string music;

			public string ambience;

			public Sprite GetSprite()
			{
				return null;
			}
		}

		[SerializeField]
		private Image _loadingScreenBackgroundImage;

		[SerializeField]
		private Image _loadingScreenImage;

		[SerializeField]
		private Image[] _edgeEffectImages;

		[SerializeField]
		private TextMeshProUGUII18n _clickToContinueText;

		[SerializeField]
		private TextMeshProUGUII18n _loadingText;

		[SerializeField]
		private TextBlock3DUIView _loadingMessageText;

		[SerializeField]
		private Camera _loadingUICamera;

		private static DataResources.LoadingText[] _loadingTexts;

		private static readonly RollingList<DataResources.LoadingText> _previouslyUsedLoadingTexts;

		private static List<LoadingScreenArt> _loadingScreenArts;

		private List<string> _highPriorityTags;

		private Action _onContinueClicked;

		private Action _onContinueClickedTransitionFinished;

		private float _blockerTransitionInTime;

		private float _artTransitionInTime;

		private float _loadingTextTransitionInTime;

		private float _loadingMessageTransitionInTime;

		private Sequence _transitionSequence;

		private Sequence _showClickToContinueSeq;

		private Tween _clickToContinueTweenLoop;

		private const float _clickToContinueTextTransitionInTime = 1f;

		private bool _waitingToContinue;

		public bool IsOpen => false;

		public static event EventHandler Closing
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventHandler StateChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnBeforeSceneLoad()
		{
		}

		private string GetLoadingScreenTextKey()
		{
			return null;
		}

		public static void ValidateLoadingScreenArt(IEnumerable<string> tags)
		{
		}

		private LoadingScreenArt GetLoadingScreenArtForTags(List<string> tags)
		{
			return null;
		}

		public override void Awake()
		{
		}

		private void Update()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void EnableLoadingSettings(bool isEnabled)
		{
		}

		private void HideAll()
		{
		}

		public void PrepareForBoot()
		{
		}

		public void Show(Action onReadyToLoad, List<string> tags)
		{
		}

		public void OnReadyToContinue(Action onContinued = null, Action onContinuedTransitionFinished = null)
		{
		}

		public void Hide(Action onHidden = null)
		{
		}

		private void TransitionIn(Action completeCallback)
		{
		}

		private void TransitionOut(Action completeCallback)
		{
		}

		public Tween ShowBackgroundBlocker(bool skipTween = false)
		{
			return null;
		}

		private Tween HideBackgroundBlocker(bool skipTween = false)
		{
			return null;
		}

		private Tween ShowLoadingImage(bool skipTween = false)
		{
			return null;
		}

		private float GetBorderEdgeMaxAlpha()
		{
			return 0f;
		}

		private Tween HideLoadingImage(bool skipTween = false)
		{
			return null;
		}

		private Tween ShowLoadingStateText(bool skipTween = false)
		{
			return null;
		}

		private Tween HideLoadingStateText(bool skipTween = false)
		{
			return null;
		}

		private Tween ShowLoadingMessage()
		{
			return null;
		}

		private Tween HideLoadingMessage(bool skipTween = false)
		{
			return null;
		}

		private void ShowClickToContinue()
		{
		}

		private Tween HideClickToContinue(bool skipTween = false)
		{
			return null;
		}

		private void OnClickToContinue()
		{
		}

		private Tween TransitionInGraphic(Graphic transitionGraphic, float tweenTime, bool skipTween = false, float minAlpha = 0f, float maxAlpha = 1f)
		{
			return null;
		}

		private Tween TransitionOutGraphic(Graphic transitionGraphic, float tweenTime, bool skipTween = false, float minAlpha = 0f, float maxAlpha = 1f)
		{
			return null;
		}

		private Tween TransitionGraphic(Graphic transitionGraphic, float tweenTime, float startAlpha, float endAlpha, bool skipTween)
		{
			return null;
		}
	}
}
