using DG.Tweening;
using Restory.Data.GuiElementTypes;
using Restory.Gameplay.Common;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface
{
	public class GUI_CanvasElement : MonoBehaviour
	{
		[Header("General settings")]
		[SerializeField]
		private bool isActive = true;

		[SerializeField]
		private bool isAffectedByUiShowHide = true;

		[SerializeField]
		private bool isAffectedByUiHide;

		[SerializeField]
		private bool autoPushElementOnEnable = true;

		[SerializeField]
		private PriorityType priority;

		[SerializeField]
		private GuiElementType guiElementType;

		[SerializeField]
		private Canvas canvas;

		[SerializeField]
		private CanvasGroup canvasGroup;

		private Tween fadeTween;

		private bool interactableChanged;

		private bool blocksRaycastsChanged;

		private CanvasOrderService canvasOrderService;

		public bool IsActive => isActive;

		public Canvas Canvas => canvas;

		public CanvasGroup CanvasGroup => canvasGroup;

		public GuiElementType GuiElementType => guiElementType;

		public bool IsAffectedByUiShowHide => isAffectedByUiShowHide;

		public bool IsAffectedByUiHide => isAffectedByUiHide;

		public int SortingOrder
		{
			get
			{
				if (!canvas)
				{
					return 0;
				}
				return canvas.sortingOrder;
			}
			set
			{
				if ((!(canvas == null) || !(this != null) || TryGetComponent<Canvas>(out canvas)) && !(canvas == null))
				{
					canvas.overrideSorting = true;
					canvas.sortingOrder = value;
				}
			}
		}

		public PriorityType Priority
		{
			get
			{
				return priority;
			}
			set
			{
				priority = value;
				Push();
			}
		}

		[Inject]
		private void Construct([Inject(Optional = true)] CanvasOrderService canvasOrderService)
		{
			this.canvasOrderService = canvasOrderService;
			if (autoPushElementOnEnable && base.isActiveAndEnabled)
			{
				Push();
			}
		}

		private void Awake()
		{
			if (!canvas)
			{
				TryGetComponent<Canvas>(out canvas);
			}
			if (canvasGroup == null)
			{
				canvasGroup = GetComponent<CanvasGroup>();
			}
		}

		private void OnEnable()
		{
			if (autoPushElementOnEnable && canvasOrderService != null)
			{
				Push();
			}
		}

		private void OnDisable()
		{
			if (canvasOrderService != null)
			{
				Pop(killTweens: true);
			}
			if (fadeTween.IsActive())
			{
				fadeTween.Kill();
			}
		}

		public void Push()
		{
			canvasOrderService.Add(this);
		}

		public void Pop(bool killTweens = false)
		{
			canvasOrderService.Remove(this, killTweens);
		}

		public virtual void Fade(bool targetActiveState)
		{
			if (!(canvasGroup == null))
			{
				if (targetActiveState)
				{
					FadeIn();
				}
				else
				{
					FadeOut();
				}
			}
		}

		protected void FadeIn()
		{
			if (fadeTween.IsActive())
			{
				fadeTween.Kill();
			}
			float num = 1f;
			if ((bool)canvasGroup && Mathf.Approximately(num, canvasGroup.alpha))
			{
				canvasGroup.alpha = num;
				OnCompleteHandle();
			}
			else
			{
				fadeTween = canvasGroup.DOFade(num, canvasOrderService.Settings.FadeDuration).SetEase(canvasOrderService.Settings.FadeInEase).OnComplete(OnCompleteHandle)
					.SetUpdate(isIndependentUpdate: true);
			}
			void OnCompleteHandle()
			{
				if (interactableChanged)
				{
					interactableChanged = false;
					canvasGroup.interactable = true;
				}
				if (blocksRaycastsChanged)
				{
					blocksRaycastsChanged = false;
					canvasGroup.blocksRaycasts = true;
				}
			}
		}

		protected void FadeOut()
		{
			if (fadeTween.IsActive())
			{
				fadeTween.Kill();
			}
			float num = 0f;
			if ((bool)canvasGroup && Mathf.Approximately(num, canvasGroup.alpha))
			{
				canvasGroup.alpha = num;
				OnStartHandle();
			}
			else
			{
				fadeTween = canvasGroup.DOFade(num, canvasOrderService.Settings.FadeDuration).SetEase(canvasOrderService.Settings.FadeOutEase).OnStart(OnStartHandle)
					.SetUpdate(isIndependentUpdate: true);
			}
			void OnStartHandle()
			{
				if (canvasGroup.interactable)
				{
					interactableChanged = true;
					canvasGroup.interactable = false;
				}
				if (canvasGroup.blocksRaycasts)
				{
					blocksRaycastsChanged = true;
					canvasGroup.blocksRaycasts = false;
				}
			}
		}
	}
}
