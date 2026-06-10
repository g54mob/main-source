using System.Collections;
using Controller;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.WorldMap;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public abstract class PanelBase : MonoBehaviour, IObserver, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPauseGame
	{
		private CanvasGroup canvasGroup;

		private CanvasGroup CanvasGroup
		{
			get
			{
				if ((bool)canvasGroup)
				{
					return canvasGroup;
				}
				canvasGroup = MainPanel.GetComponent<CanvasGroup>();
				if ((bool)canvasGroup)
				{
					return canvasGroup;
				}
				canvasGroup = MainPanel.AddComponent<CanvasGroup>();
				canvasGroup.blocksRaycasts = true;
				canvasGroup.interactable = true;
				canvasGroup.alpha = 0f;
				return canvasGroup;
			}
		}

		protected bool Initialized { get; private set; }

		public virtual GameObject MainPanel => base.gameObject;

		protected virtual bool SubscribeToEscapeKey => true;

		protected abstract PanelGroupType GetGroupType();

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		protected virtual IEnumerator InitializeContent()
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(26, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Panel\\PanelBase.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Initializing PanelBase ");
				messageBuilder.AppendFormatted(base.gameObject.name);
				messageBuilder.AppendLiteral(" - ");
				messageBuilder.AppendFormatted(GetType().FullName);
			}
			Log.Debug(messageBuilder);
			yield return new WaitForSecondsRealtime(0.01f);
			Show();
		}

		protected virtual float GetInitTime()
		{
			return 0.1f;
		}

		public void OnPanelToggleTab(int tabIndex)
		{
			if (MainPanel.activeSelf)
			{
				Hide();
			}
			else
			{
				ShowTab(tabIndex);
			}
		}

		public void OnPanelToggle()
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(13, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Panel\\PanelBase.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(base.name);
				messageBuilder.AppendLiteral(" panel toggle");
			}
			Log.Debug(messageBuilder);
			if (MainPanel.activeSelf)
			{
				Hide();
			}
			else
			{
				Show();
			}
		}

		public virtual void Show()
		{
			MonoSingleton<UIController>.Instance.CloseOtherPanels(MainPanel.name, GetGroupType());
			MainPanel.SetActive(value: true);
			if (!Initialized)
			{
				Initialized = true;
				CanvasGroup.alpha = 0f;
				StartCoroutine(InitializeContent());
				return;
			}
			CanvasGroup.alpha = 1f;
			LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform as RectTransform);
			UpdatePanel();
			MonoSingleton<AnalyticsManager>.Instance.OnScreenVisit(base.name);
			if (GetGroupType() == PanelGroupType.UpperLeft && MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.IsWorldMapVisible)
			{
				MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.SetWorldMapVisible(isWorldMapVisible: false);
			}
			EscKeySubscribe();
			if (MonoSingleton<SceneUIManager>.IsInstantiated())
			{
				MonoSingleton<SceneUIManager>.Instance.NotifyPanelToggle(base.name, isOn: true);
			}
		}

		public virtual void Hide()
		{
			if (MainPanel.activeInHierarchy)
			{
				CanvasGroup.alpha = 0f;
				MainPanel.SetActive(value: false);
				MonoSingleton<SceneUIManager>.Instance.OnPanelHide(base.name);
				if (MonoSingleton<SceneUIManager>.IsInstantiated())
				{
					MonoSingleton<SceneUIManager>.Instance.NotifyPanelToggle(base.name, isOn: false);
				}
				EscKeyUnsubscribe();
			}
		}

		protected virtual void EscKeySubscribe()
		{
			if (SubscribeToEscapeKey)
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.SubscribeToEscapeKey(Hide, base.gameObject);
			}
		}

		protected virtual void EscKeyUnsubscribe()
		{
			if (SubscribeToEscapeKey)
			{
				MonoSingleton<GlobalKeybindingManager>.Instance.UnsubscribeFromEscapeKey(Hide, base.gameObject);
			}
		}

		protected abstract void UpdatePanel();

		public virtual void ShowTab(int tabIndex)
		{
		}

		protected virtual void OnOtherPanelOpened(string panelName, PanelGroupType panelGroup)
		{
			if (GetGroupType() == panelGroup && !MainPanel.name.Equals(panelName))
			{
				Hide();
			}
		}

		protected void OnHideAllPanels()
		{
			Hide();
		}

		protected virtual void Start()
		{
		}

		protected virtual void OnEnable()
		{
			MonoSingleton<UIController>.Instance.Attach(this);
			if (MonoSingleton<UIPanelManager>.IsInstantiated())
			{
				MonoSingleton<UIPanelManager>.Instance.OnPanelShow(this);
			}
		}

		protected virtual void OnDisable()
		{
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.Detach(this);
			}
			if (MonoSingleton<UIPanelManager>.IsInstantiated())
			{
				MonoSingleton<UIPanelManager>.Instance.OnPanelHide(this);
			}
		}

		protected virtual void OnDestroy()
		{
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.Detach(this);
			}
			if (MonoSingleton<UIPanelManager>.IsInstantiated())
			{
				MonoSingleton<UIPanelManager>.Instance.OnPanelHide(this);
			}
		}
	}
}
