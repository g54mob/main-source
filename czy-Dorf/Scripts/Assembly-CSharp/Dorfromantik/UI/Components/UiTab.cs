using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Dorfromantik.UI.Components
{
	public class UiTab : UiInteractable
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<UiVisualStateInfo, bool> _003C_003E9__17_0;

			internal bool _003CSetInitial_003Eb__17_0(UiVisualStateInfo visualStateInfo)
			{
				return visualStateInfo.canvasGroup != null;
			}
		}

		[SerializeField]
		internal bool isDefaultActiveTab;

		[SerializeField]
		internal bool hasGameModeAssigned;

		[SerializeField]
		internal GameMode assignedGameMode;

		[SerializeField]
		internal bool hasTabContent = true;

		[SerializeField]
		internal GameObject tabContent;

		[SerializeField]
		internal bool isVisualAlternate;

		internal event Action<UiTab> OnSetActive;

		protected override void Awake()
		{
			base.Awake();
			Validate();
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			Validate();
		}

		protected override void Start()
		{
			base.Start();
			SetInitial();
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			if (base.UiVisualStateInfoHovered.isAvailable)
			{
				SetVisualStateEnabled(shouldSetEnabled: false);
				SetVisualStateHovered(shouldSetHovered: true);
				PlayAudio(hoverSound);
			}
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			SetVisualStateHovered(shouldSetHovered: false);
			SetVisualStateEnabled(shouldSetEnabled: true);
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			Submit();
		}

		protected virtual void Validate()
		{
		}

		public virtual void Submit()
		{
			if (base.IsDisabled)
			{
				PlayAudio(clickInvalidSound);
				return;
			}
			PlayAudio(clickSound);
			if (!base.IsActivated)
			{
				if (base.UiVisualStateInfoActivated.isAvailable)
				{
					SetVisualStateActivated(shouldSetActivated: true);
				}
				onClick?.Invoke(base.IsActivated);
			}
		}

		protected virtual void SetInitial()
		{
			if (tabContent == null && hasTabContent)
			{
				Debug.LogError("There is no tab-content assigned to the tab " + base.name + "!");
			}
			foreach (UiVisualStateInfo item in Enumerable.Where(availableVisualStateInfos, (UiVisualStateInfo visualStateInfo) => visualStateInfo.canvasGroup != null))
			{
				item.canvasGroup.alpha = 0f;
			}
			if (base.UiVisualStateInfoEnabled.canvasGroup != null)
			{
				base.UiVisualStateInfoEnabled.canvasGroup.alpha = 1f;
			}
			SetVisualStateEnabled(shouldSetEnabled: true);
			if (base.UiVisualStateInfoActivated.isAvailable)
			{
				SetVisualStateActivated(base.IsActivated, shouldIgnoreCurrentState: true);
			}
			if (base.UiVisualStateInfoHovered.isAvailable)
			{
				SetVisualStateHovered(base.IsHovered, shouldIgnoreCurrentState: true);
			}
			if (base.UiVisualStateInfoDisabled.isAvailable)
			{
				SetVisualStateDisabled(base.IsDisabled, shouldIgnoreCurrentState: true);
			}
		}

		protected virtual void SetVisualStateEnabled(bool shouldSetEnabled)
		{
			SetState(UiState.Enabled, shouldSetEnabled);
		}

		protected virtual void SetVisualStateHovered(bool shouldSetHovered, bool shouldIgnoreCurrentState = false)
		{
			if (base.IsHovered != shouldSetHovered || shouldIgnoreCurrentState)
			{
				SetState(UiState.Hovered, shouldSetHovered);
			}
		}

		public virtual void SetVisualStateActivated(bool shouldSetActivated, bool shouldIgnoreCurrentState = false)
		{
			if ((bool)tabContent && shouldSetActivated && Singleton<MainMenuUi>.Instance.ActiveScreen != tabContent.GetComponent<MainMenuScreen>().screenType)
			{
				Singleton<MainMenuUi>.Instance.SwitchToScreen(tabContent.GetComponent<MainMenuScreen>().screenType, animate: false);
			}
			if (shouldSetActivated)
			{
				this.OnSetActive?.Invoke(this);
			}
			SetState(UiState.Activated, shouldSetActivated);
		}

		protected virtual void SetVisualStateDisabled(bool shouldSetDisabled, bool shouldIgnoreCurrentState = false)
		{
			if (base.IsDisabled != shouldSetDisabled || shouldIgnoreCurrentState)
			{
				SetState(UiState.Disabled, shouldSetDisabled);
			}
		}
	}
}
