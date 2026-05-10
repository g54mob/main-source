using System.Collections.Generic;
using TinyGiantStudio.Modules;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace TinyGiantStudio.Text
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Tiny Giant Studio/Modular 3D Text/Button", 20002)]
	[HelpURL("https://ferdowsur.gitbook.io/modular-3d-text/ui/button")]
	public class Button : MonoBehaviour
	{
		public AssetSettings settings;

		[FormerlySerializedAs("onUnselect")]
		public UnityEvent unselectEvent;

		[FormerlySerializedAs("onSelect")]
		public UnityEvent selectedEvent;

		[FormerlySerializedAs("whileBeingClicked")]
		public UnityEvent beingPressedEvent;

		[FormerlySerializedAs("onClick")]
		public UnityEvent pressCompleteEvent;

		public bool interactable;

		[Tooltip("Mouse or touch can select this")]
		public bool interactableByMouse;

		[SerializeField]
		private Modular3DText _text;

		[SerializeField]
		private Renderer _background;

		public bool useModules;

		[FormerlySerializedAs("unSelectModuleContainers ")]
		public List<ModuleContainer> unSelectedModuleContainers;

		[FormerlySerializedAs("applyUnSelectModuleContainers")]
		public bool applyUnSelectedModuleContainers;

		[FormerlySerializedAs("onSelectModuleContainers")]
		public List<ModuleContainer> selectedModuleContainers;

		[FormerlySerializedAs("applyOnSelectModuleContainers")]
		public bool applySelectModuleContainers;

		[FormerlySerializedAs("onPressModuleContainers")]
		public List<ModuleContainer> beingPressedModuleContainers;

		[FormerlySerializedAs("applyOnPressModuleContainers")]
		public bool applyBeingPressedModuleContainers;

		[FormerlySerializedAs("onClickModuleContainers")]
		public List<ModuleContainer> pressCompleteModuleContainers;

		[FormerlySerializedAs("applyOnClickModuleContainers")]
		public bool applyPressCompleteModuleContainers;

		public bool useStyles;

		[SerializeField]
		private Vector3 _normalTextSize;

		[SerializeField]
		private Material _normalTextMaterial;

		[SerializeField]
		private Material _normalBackgroundMaterial;

		public bool useSelectedVisual;

		[SerializeField]
		private Vector3 _selectedTextSize;

		[SerializeField]
		private Material _selectedTextMaterial;

		[SerializeField]
		private Material _selectedBackgroundMaterial;

		public bool usePressedVisual;

		[SerializeField]
		private Vector3 _pressedTextSize;

		[SerializeField]
		private Material _pressedTextMaterial;

		[SerializeField]
		private Material _pressedBackgroundMaterial;

		public float holdPressedVisualFor;

		[SerializeField]
		private bool _useDisabledVisual;

		[SerializeField]
		private Vector3 _disabledTextSize;

		[SerializeField]
		private Material _disabledTextMaterial;

		[SerializeField]
		private Material _disabledBackgroundMaterial;

		public bool isSelected;

		private float switchBackVisualTime;

		public Modular3DText Text
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Renderer Background
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 NormalTextSize
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Material NormalTextMaterial
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Material NormalBackgroundMaterial
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 SelectedTextSize
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Material SelectedTextMaterial
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Material SelectedBackgroundMaterial
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 PressedTextSize
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Material PressedTextMaterial
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Material PressedBackgroundMaterial
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool UseDisabledVisual
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Vector3 DisabledTextSize
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Material DisabledTextMaterial
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Material DisabledBackgroundMaterial
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		public void UpdateStyle()
		{
		}

		public void SelectButton()
		{
		}

		public void SelectedButtonVisualUpdate()
		{
		}

		public void SelectedButtonModuleUpdate()
		{
		}

		public void UnselectButton()
		{
		}

		public void UnselectedButtonVisualUpdate()
		{
		}

		public void UnselectButtonModuleUpdate()
		{
		}

		public void PressButton()
		{
		}

		private void ReturnToNormalVisualAfterPressing()
		{
		}

		public void PressButtonDontCallList()
		{
		}

		public void PressButtonVisualUpdate()
		{
		}

		public void ButtonBeingPressed()
		{
		}

		public void PressCompleted()
		{
		}

		public void PressCompleteButtonModuleUpdate()
		{
		}

		public void BeingPressedButtonModuleUpdate()
		{
		}

		public void DisabledButtonVisualUpdate()
		{
		}

		private void ApplyeStyle(Vector3 fontSize, Material fontMat, Material backgroundMat)
		{
		}

		public void Uninteractable()
		{
		}

		public void Interactable()
		{
		}

		public (bool, bool) ApplyNormalStyle()
		{
			return default((bool, bool));
		}

		public (bool, bool, List) ApplyOnSelectStyle()
		{
			return default((bool, bool, List));
		}

		public (bool, bool, List) ApplyPressedStyle()
		{
			return default((bool, bool, List));
		}

		public (bool, bool, List) ApplyDisabledStyle()
		{
			return default((bool, bool, List));
		}

		private void CallModules(List<ModuleContainer> moduleContainers)
		{
		}

		public (bool, bool, List) ApplyUnSelectModule()
		{
			return default((bool, bool, List));
		}

		public (bool, bool, List) ApplyOnPresstModule()
		{
			return default((bool, bool, List));
		}

		public (bool, bool, List) ApplyOnClickModule()
		{
			return default((bool, bool, List));
		}

		public (bool, bool, List) ApplyOnSelectModule()
		{
			return default((bool, bool, List));
		}

		public void EmptyEffect(List<ModuleContainer> moduleList, Module module = null)
		{
		}
	}
}
