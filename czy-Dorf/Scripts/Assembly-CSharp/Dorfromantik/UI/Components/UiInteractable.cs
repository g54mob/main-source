using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Dorfromantik.UI.Components
{
	public abstract class UiInteractable : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<UiVisualStateInfo, UiState> _003C_003E9__83_0;

			internal UiState _003CSetupVisualStateInfosDictionary_003Eb__83_0(UiVisualStateInfo x)
			{
				return x.uiState;
			}
		}

		private Dictionary<UiState, UiVisualStateInfo> visualStateInfosByUiState = new Dictionary<UiState, UiVisualStateInfo>();

		protected Sequence onInteractionSequence;

		[SerializeField]
		protected bool shouldTriggerInputItself = true;

		[SerializeField]
		protected List<UiVisualStateInfo> visualStatesInfos = new List<UiVisualStateInfo>();

		[SerializeField]
		protected UnityEvent<bool> onClick;

		[SerializeField]
		protected AudioClipOptions clickSound;

		[SerializeField]
		protected AudioClipOptions clickInvalidSound;

		[SerializeField]
		protected AudioClipOptions hoverSound;

		[SerializeField]
		protected List<UiVisualStateInfo> availableVisualStateInfos = new List<UiVisualStateInfo>();

		[SerializeField]
		private bool isEnabled;

		[SerializeField]
		private bool isDisabled;

		[SerializeField]
		private bool isHovered;

		[SerializeField]
		private bool isFocused;

		[SerializeField]
		private bool isSelected;

		[SerializeField]
		private bool isActivated;

		[SerializeField]
		private bool isPressed;

		[SerializeField]
		private bool isDragged;

		[SerializeField]
		private bool isLoading;

		[SerializeField]
		private bool isError;

		protected UiVisualStateInfo UiVisualStateInfoEnabled => visualStateInfosByUiState[UiState.Enabled];

		protected UiVisualStateInfo UiVisualStateInfoDisabled => visualStateInfosByUiState[UiState.Disabled];

		protected UiVisualStateInfo UiVisualStateInfoHovered => visualStateInfosByUiState[UiState.Hovered];

		protected UiVisualStateInfo UiVisualStateInfoFocused => visualStateInfosByUiState[UiState.Focused];

		protected UiVisualStateInfo UiVisualStateInfoSelected => visualStateInfosByUiState[UiState.Selected];

		protected UiVisualStateInfo UiVisualStateInfoActivated => visualStateInfosByUiState[UiState.Activated];

		protected UiVisualStateInfo UiVisualStateInfoPressed => visualStateInfosByUiState[UiState.Pressed];

		protected UiVisualStateInfo UiVisualStateInfoDragged => visualStateInfosByUiState[UiState.Dragged];

		protected UiVisualStateInfo UiVisualStateInfoLoading => visualStateInfosByUiState[UiState.Loading];

		protected UiVisualStateInfo UiVisualStateInfoError => visualStateInfosByUiState[UiState.Error];

		protected bool IsEnabled
		{
			get
			{
				return UiVisualStateInfoEnabled.isCurrentlyActive;
			}
			set
			{
				isEnabled = value;
				UiVisualStateInfoEnabled.isCurrentlyActive = value;
			}
		}

		protected bool IsDisabled
		{
			get
			{
				return UiVisualStateInfoDisabled.isCurrentlyActive;
			}
			set
			{
				isDisabled = value;
				UiVisualStateInfoDisabled.isCurrentlyActive = value;
			}
		}

		protected bool IsHovered
		{
			get
			{
				return UiVisualStateInfoHovered.isCurrentlyActive;
			}
			set
			{
				isHovered = value;
				UiVisualStateInfoHovered.isCurrentlyActive = value;
			}
		}

		protected bool IsFocused
		{
			get
			{
				return UiVisualStateInfoFocused.isCurrentlyActive;
			}
			set
			{
				isFocused = value;
				UiVisualStateInfoFocused.isCurrentlyActive = value;
			}
		}

		protected bool IsSelected
		{
			get
			{
				return UiVisualStateInfoSelected.isCurrentlyActive;
			}
			set
			{
				isSelected = value;
				UiVisualStateInfoSelected.isCurrentlyActive = value;
			}
		}

		protected bool IsActivated
		{
			get
			{
				return UiVisualStateInfoActivated.isCurrentlyActive;
			}
			set
			{
				isActivated = value;
				UiVisualStateInfoActivated.isCurrentlyActive = value;
			}
		}

		protected bool IsPressed
		{
			get
			{
				return UiVisualStateInfoPressed.isCurrentlyActive;
			}
			set
			{
				isPressed = value;
				UiVisualStateInfoPressed.isCurrentlyActive = value;
			}
		}

		protected bool IsDragged
		{
			get
			{
				return UiVisualStateInfoDragged.isCurrentlyActive;
			}
			set
			{
				isDragged = value;
				UiVisualStateInfoDragged.isCurrentlyActive = value;
			}
		}

		protected bool IsLoading
		{
			get
			{
				return UiVisualStateInfoLoading.isCurrentlyActive;
			}
			set
			{
				isLoading = value;
				UiVisualStateInfoLoading.isCurrentlyActive = value;
			}
		}

		protected bool IsError
		{
			get
			{
				return UiVisualStateInfoError.isCurrentlyActive;
			}
			set
			{
				isError = value;
				UiVisualStateInfoError.isCurrentlyActive = value;
			}
		}

		protected virtual void OnValidate()
		{
			ValidateVisualStateInfosList();
			UpdateAvailableVisualStateInfos();
		}

		protected virtual void Awake()
		{
			ValidateVisualStateInfosList();
			UpdateAvailableVisualStateInfos();
			SetupVisualStateInfosDictionary();
			ResetInteractionSequence();
			InitializeAvailableVisualStateInfos();
		}

		protected virtual void Start()
		{
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		protected virtual void SetState(UiState uiState, bool isCurrentlyActive)
		{
			switch (uiState)
			{
			case UiState.Enabled:
				IsEnabled = isCurrentlyActive;
				break;
			case UiState.Disabled:
				IsDisabled = isCurrentlyActive;
				break;
			case UiState.Hovered:
				IsHovered = isCurrentlyActive;
				break;
			case UiState.Focused:
				IsFocused = isCurrentlyActive;
				break;
			case UiState.Selected:
				IsSelected = isCurrentlyActive;
				break;
			case UiState.Activated:
				IsActivated = isCurrentlyActive;
				break;
			case UiState.Pressed:
				IsPressed = isCurrentlyActive;
				break;
			case UiState.Dragged:
				IsDragged = isCurrentlyActive;
				break;
			case UiState.Loading:
				IsLoading = isCurrentlyActive;
				break;
			case UiState.Error:
				IsError = isCurrentlyActive;
				break;
			default:
				throw new ArgumentOutOfRangeException("uiState", uiState, null);
			}
		}

		protected void ResetInteractionSequence()
		{
			onInteractionSequence = ResetSequence(onInteractionSequence);
		}

		protected Sequence ResetInteractionSequence(Sequence additionalSequenceToReset)
		{
			ResetInteractionSequence();
			return ResetSequence(additionalSequenceToReset);
		}

		protected Sequence ResetSequence(Sequence sequenceToReset)
		{
			if (sequenceToReset != null)
			{
				TweenExtensions.Kill(sequenceToReset, complete: true);
			}
			sequenceToReset = DOTween.Sequence();
			return sequenceToReset;
		}

		protected Sequence ResetSequence(Sequence sequenceToReset, bool shouldReturnSequence = true)
		{
			if (sequenceToReset != null)
			{
				TweenExtensions.Kill(sequenceToReset, complete: true);
			}
			sequenceToReset = DOTween.Sequence();
			return sequenceToReset;
		}

		protected void PlayAudio(AudioClipOptions audioClip)
		{
			if (!(audioClip == null))
			{
				if (AudioManager.Instance != null)
				{
					AudioManager.Instance.PlayGlobalSound(audioClip);
				}
				else
				{
					Debug.LogError($"No Sound effect played! {audioClip} could not be played, because {AudioManager.Instance} was not found!");
				}
			}
		}

		private void ValidateVisualStateInfosList()
		{
			if (visualStatesInfos.Count != Enum.GetValues(typeof(UiState)).Length)
			{
				RefreshVisualStateInfosList();
			}
		}

		private void RefreshVisualStateInfosList(bool shouldHardReset = false)
		{
			if (visualStatesInfos == null || visualStatesInfos.Count == 0 || shouldHardReset)
			{
				visualStatesInfos = new List<UiVisualStateInfo>();
				visualStatesInfos.Clear();
			}
			if (visualStatesInfos.Count != Enum.GetValues(typeof(UiState)).Length)
			{
				UpdateVisualStateInfosList();
				UpdateAvailableVisualStateInfos();
			}
		}

		private void SetupVisualStateInfosDictionary()
		{
			visualStateInfosByUiState.Clear();
			visualStateInfosByUiState = Enumerable.ToDictionary(visualStatesInfos, (UiVisualStateInfo x) => x.uiState);
		}

		private void UpdateVisualStateInfosList()
		{
			foreach (UiState value in Enum.GetValues(typeof(UiState)))
			{
				bool flag = true;
				foreach (UiVisualStateInfo visualStatesInfo in visualStatesInfos)
				{
					if (visualStatesInfo.uiState == value)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					UiVisualStateInfo item = new UiVisualStateInfo(value);
					visualStatesInfos.Add(item);
				}
			}
		}

		private void UpdateAvailableVisualStateInfos()
		{
			availableVisualStateInfos.Clear();
			foreach (UiVisualStateInfo visualStatesInfo in visualStatesInfos)
			{
				if (visualStatesInfo.isAvailable && !availableVisualStateInfos.Contains(visualStatesInfo))
				{
					availableVisualStateInfos.Add(visualStatesInfo);
				}
			}
		}

		private void InitializeAvailableVisualStateInfos()
		{
			foreach (UiVisualStateInfo availableVisualStateInfo in availableVisualStateInfos)
			{
				availableVisualStateInfo.Initialize();
			}
		}
	}
}
