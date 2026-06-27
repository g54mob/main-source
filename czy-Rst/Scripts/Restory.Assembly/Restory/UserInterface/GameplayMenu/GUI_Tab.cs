using Helpers.Events;
using Restory.Infrastructure.CommonServices;
using Restory.ObjectPools;
using Restory.UserInterface.ElementPresets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

namespace Restory.UserInterface.GameplayMenu
{
	public class GUI_Tab : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler, ICleanableComponent
	{
		public readonly UnityEvent<GUI_Tab> OnClicked = new UnityEventConcrete<GUI_Tab>();

		[SerializeField]
		protected bool isChosen;

		[SerializeField]
		private bool isAvailable = true;

		[SerializeField]
		private bool isSelected;

		[SerializeField]
		private Graphic[] targetGraphics = new Graphic[0];

		[Header("General settings")]
		[SerializeField]
		protected GUI_PanelBase panelWindow;

		[Header("View settings")]
		[SerializeField]
		protected Image icon;

		[SerializeField]
		protected Image iconOutlined;

		[SerializeField]
		private GUI_ElementPresetSwitcher presetSwitcher;

		private ControlsManager controlsManager;

		public virtual bool IsChosen
		{
			get
			{
				return isChosen;
			}
			set
			{
				if (isChosen = value)
				{
					panelWindow?.Show();
				}
				else
				{
					panelWindow?.Hide();
				}
				UpdateView();
			}
		}

		public bool IsAvailable
		{
			get
			{
				return isAvailable;
			}
			set
			{
				bool flag = (base.interactable = value);
				isAvailable = flag;
				UpdateView();
			}
		}

		public bool IsSelected
		{
			get
			{
				return isSelected;
			}
			private set
			{
				isSelected = value;
				UpdateView();
			}
		}

		public GUI_PanelBase Panel => panelWindow;

		[Inject]
		private void Construct(ControlsManager controlsManager)
		{
			this.controlsManager = controlsManager;
			if (base.isActiveAndEnabled)
			{
				this.controlsManager.OnControlsTypeChanged += OnControlsTypeChanged;
				OnControlsTypeChanged(controlsManager.ControlType);
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if ((bool)panelWindow)
			{
				panelWindow.OnContentChanged.AddListener(UpdateView);
			}
			if (controlsManager != null)
			{
				controlsManager.OnControlsTypeChanged += OnControlsTypeChanged;
				OnControlsTypeChanged(controlsManager.ControlType);
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if ((bool)panelWindow)
			{
				panelWindow.OnContentChanged.RemoveListener(UpdateView);
			}
			if (controlsManager != null)
			{
				controlsManager.OnControlsTypeChanged -= OnControlsTypeChanged;
			}
		}

		public virtual void UpdateView()
		{
			Graphic[] array = targetGraphics;
			foreach (Graphic graphic in array)
			{
				if ((bool)graphic)
				{
					graphic.gameObject.SetActive(IsAvailable && IsSelected);
				}
			}
			if ((bool)iconOutlined)
			{
				iconOutlined.sprite = icon.sprite;
				iconOutlined.overrideSprite = icon.overrideSprite;
			}
			if (isChosen)
			{
				presetSwitcher.ActivatePreset(PresetName.Chosen);
			}
			else if (isSelected)
			{
				presetSwitcher.ActivatePreset(PresetName.Selected);
			}
			else
			{
				presetSwitcher.ActivatePreset(PresetName.Normal);
			}
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			if (IsAvailable)
			{
				IsSelected = true;
			}
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			if (IsAvailable)
			{
				IsSelected = false;
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (IsAvailable)
			{
				OnClicked.Invoke(this);
			}
		}

		public void OnSubmit(BaseEventData eventData)
		{
			if (IsAvailable)
			{
				OnClicked.Invoke(this);
			}
		}

		private void OnControlsTypeChanged(InputControlsType controlsType)
		{
			if (controlsType == InputControlsType.Joystick)
			{
				IsSelected = false;
			}
		}

		public virtual void Clean()
		{
			OnClicked.RemoveAllListeners();
			isChosen = false;
			isSelected = false;
			presetSwitcher.ActivatePreset(PresetName.Normal);
		}
	}
}
