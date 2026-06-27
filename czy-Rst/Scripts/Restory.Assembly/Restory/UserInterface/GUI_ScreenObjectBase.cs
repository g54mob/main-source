using DG.Tweening;
using Restory.ObjectPools;
using Restory.UserInterface.GameplayOverlay;
using Restory.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface
{
	[RequireComponent(typeof(GUI_CanvasElement))]
	public class GUI_ScreenObjectBase : MonoBehaviour, IModelProperty, ICleanableComponent
	{
		private static class Style
		{
			public const string FadeTweenSettings = "FadeTweenSettings";
		}

		public readonly UnityEvent OnModelChange = new UnityEvent();

		public readonly UnityEvent OnShown = new UnityEvent();

		public readonly UnityEvent OnHidden = new UnityEvent();

		public readonly UnityEvent OnClosed = new UnityEvent();

		public readonly UnityEvent OnDisposed = new UnityEvent();

		private RectTransform rectTransform;

		private RectTransform parentRectTransform;

		private GUI_CanvasElement element;

		private bool isVisible = true;

		[Header("General settings")]
		[SerializeField]
		protected CanvasGroup canvasGroup;

		[SerializeField]
		private Button closeButton;

		private bool closeButtonActiveOnInit;

		[SerializeField]
		[Tooltip("Transform should be used for tweenings. The GameObject contains the main UI-content")]
		private RectTransform windowRectTransform;

		[SerializeField]
		protected float fadeDuration = 0.125f;

		[SerializeField]
		private bool isFadeTweenIndependentFromTimescale;

		[SerializeField]
		protected Ease showEaseTween = Ease.Linear;

		[SerializeField]
		protected Ease closeEaseTween = Ease.Linear;

		protected GlobalObjectPool objectPool;

		protected TweenSequencesService tweenSequences;

		private GUI_GameplayOverlayCanvas guiGameplayOverlayCanvas;

		protected Sequence mainSequence;

		[SerializeField]
		private Transform model;

		public GameObject SourcePrefab { get; set; }

		public virtual Transform Model
		{
			get
			{
				return model;
			}
			protected set
			{
				if (model != value)
				{
					model = value;
					OnModelChange?.Invoke();
				}
			}
		}

		public RectTransform RectTransform
		{
			get
			{
				if (rectTransform == null)
				{
					rectTransform = base.transform as RectTransform;
				}
				return rectTransform;
			}
			protected set
			{
				rectTransform = value;
			}
		}

		public RectTransform ParentRectTransform
		{
			get
			{
				if (parentRectTransform == null)
				{
					parentRectTransform = base.transform as RectTransform;
				}
				return parentRectTransform;
			}
			protected set
			{
				parentRectTransform = value;
			}
		}

		public GUI_CanvasElement Element
		{
			get
			{
				if (element == null && base.gameObject != null)
				{
					TryGetComponent<GUI_CanvasElement>(out element);
				}
				return element;
			}
		}

		public virtual bool IsInParentRect => RectTransformUtility.RectangleContainsScreenPoint(ParentRectTransform, RectTransform.position);

		public bool IsOpen { get; protected set; }

		public bool IsCurrentlyTweening => mainSequence.IsActive();

		public bool IsVisible
		{
			get
			{
				return isVisible;
			}
			set
			{
				if (isVisible != value)
				{
					isVisible = value;
					PlayShowHideAnimation();
				}
			}
		}

		public bool IsInteractable
		{
			get
			{
				return canvasGroup.interactable;
			}
			set
			{
				canvasGroup.interactable = value;
			}
		}

		public bool CloseButtonActive
		{
			get
			{
				if ((bool)closeButton)
				{
					return closeButton.gameObject.activeSelf;
				}
				return false;
			}
			set
			{
				if ((bool)closeButton)
				{
					closeButton.gameObject.SetActive(value);
				}
			}
		}

		public RectTransform WindowRectTransform
		{
			get
			{
				return windowRectTransform;
			}
			protected set
			{
				windowRectTransform = value;
			}
		}

		[Inject]
		private void Construct(GlobalObjectPool objectPool, TweenSequencesService tweenSequences, GUI_GameplayOverlayCanvas guiGameplayOverlayCanvas)
		{
			this.objectPool = objectPool;
			this.tweenSequences = tweenSequences;
			this.guiGameplayOverlayCanvas = guiGameplayOverlayCanvas;
		}

		protected virtual void Awake()
		{
			closeButtonActiveOnInit = CloseButtonActive;
			if (!windowRectTransform)
			{
				windowRectTransform = RectTransform;
			}
			Init();
		}

		protected void OnEnable()
		{
			OnPreEnable();
			if (closeButton != null)
			{
				closeButton.onClick.AddListener(ResolveCloseButtonOnClick);
			}
			OnPostEnable();
		}

		protected virtual void OnPreEnable()
		{
		}

		protected virtual void OnPostEnable()
		{
		}

		protected void OnDisable()
		{
			OnPreDisable();
			if (closeButton != null)
			{
				closeButton.onClick.RemoveAllListeners();
			}
			OnPostDisable();
		}

		protected virtual void OnPreDisable()
		{
		}

		protected virtual void OnPostDisable()
		{
		}

		protected virtual void OnDestroy()
		{
			PreDestroy();
			OnModelChange.RemoveAllListeners();
			OnShown.RemoveAllListeners();
			OnHidden.RemoveAllListeners();
			OnClosed.RemoveAllListeners();
			OnDisposed.RemoveAllListeners();
			KillSequence();
		}

		protected virtual void Init()
		{
		}

		protected virtual void PreDestroy()
		{
		}

		private void KillSequence()
		{
			mainSequence?.Kill();
		}

		public virtual void Show()
		{
			if (!IsOpen)
			{
				IsOpen = true;
				PlayShowHideAnimation();
				if (Element != null)
				{
					Element.Push();
				}
				OnShown.Invoke();
			}
			else
			{
				PlayShowHideAnimation();
			}
		}

		public virtual void Hide()
		{
			if (IsOpen)
			{
				IsOpen = false;
				PlayShowHideAnimation();
				if (Element != null)
				{
					Element.Pop();
				}
				OnHidden.Invoke();
			}
			else
			{
				PlayShowHideAnimation();
			}
		}

		public virtual bool CanClose()
		{
			return true;
		}

		public void TryClose()
		{
			if (CanClose())
			{
				Close();
			}
		}

		public virtual void Close()
		{
			CloseAnimation();
			IsOpen = false;
			OnClosed.Invoke();
		}

		protected virtual void OnShowAnimationCompleted()
		{
		}

		public virtual void Dispose()
		{
			GameObject gameObject = (Model ? Model.gameObject : null);
			if (gameObject != null && (bool)guiGameplayOverlayCanvas)
			{
				guiGameplayOverlayCanvas.Remove(gameObject, this);
			}
			OnDisposed.Invoke();
		}

		public virtual void UpdateView()
		{
		}

		public void InitializeHidden()
		{
			if (Element != null)
			{
				Element.Pop();
			}
			IsOpen = false;
			InstantHideAnimation();
		}

		protected virtual void InstantHideAnimation()
		{
			WindowRectTransform.localScale = Vector3.zero;
			if (canvasGroup != null)
			{
				canvasGroup.interactable = false;
			}
		}

		private void PlayShowHideAnimation()
		{
			if (isVisible && IsOpen)
			{
				ShowAnimation();
			}
			else
			{
				HideAnimation();
			}
		}

		protected virtual void ShowAnimation()
		{
			if (mainSequence.IsActive())
			{
				mainSequence.Kill();
			}
			mainSequence = tweenSequences.Create();
			mainSequence.Append(windowRectTransform.DOScale(1f, fadeDuration).SetEase(showEaseTween)).SetUpdate(isFadeTweenIndependentFromTimescale).OnComplete(delegate
			{
				if (canvasGroup != null)
				{
					canvasGroup.interactable = true;
				}
				OnShowAnimationCompleted();
			});
		}

		protected virtual void HideAnimation()
		{
			if (tweenSequences == null)
			{
				windowRectTransform.localScale = Vector3.zero;
				return;
			}
			if (mainSequence.IsActive())
			{
				mainSequence.Kill();
			}
			mainSequence = tweenSequences.Create();
			mainSequence.Append(windowRectTransform.DOScale(0f, fadeDuration).SetEase(closeEaseTween)).SetUpdate(isFadeTweenIndependentFromTimescale).OnStart(delegate
			{
				if (canvasGroup != null)
				{
					canvasGroup.interactable = false;
				}
			});
		}

		protected virtual void CloseAnimation()
		{
			if (mainSequence.IsActive())
			{
				mainSequence.Kill();
			}
			mainSequence = tweenSequences.Create();
			mainSequence.Append(windowRectTransform.DOScale(0f, fadeDuration)).SetEase(closeEaseTween).SetUpdate(isFadeTweenIndependentFromTimescale)
				.OnStart(delegate
				{
					if (canvasGroup != null)
					{
						canvasGroup.interactable = false;
					}
				});
			mainSequence.OnComplete(Dispose);
		}

		public virtual void Clean()
		{
			CloseButtonActive = closeButtonActiveOnInit;
			OnShown.RemoveAllListeners();
			OnHidden.RemoveAllListeners();
			OnClosed.RemoveAllListeners();
			OnDisposed.RemoveAllListeners();
			mainSequence?.Kill();
			isVisible = true;
		}

		private void ResolveCloseButtonOnClick()
		{
			TryClose();
		}
	}
}
