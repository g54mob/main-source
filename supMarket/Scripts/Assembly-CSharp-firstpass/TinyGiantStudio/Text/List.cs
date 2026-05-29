using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TinyGiantStudio.Modules;
using UnityEngine;
using UnityEngine.Serialization;

namespace TinyGiantStudio.Text
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Tiny Giant Studio/Modular 3D Text/List", 20007)]
	[HelpURL("https://ferdowsur.gitbook.io/modular-3d-text/ui/list")]
	public class List : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CFocusRoutine_003Ed__101 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public List _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CFocusRoutine_003Ed__101(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public int selectedItem;

		[Tooltip("If set to true, the list is focused on awake. The list is scrollable with a keyboard when focused.")]
		[SerializeField]
		private bool autoFocusOnStart;

		[Tooltip("Selects first item in the list when focused.")]
		[SerializeField]
		private bool autoFocusFirstItem;

		[SerializeField]
		private bool _useStyle;

		[SerializeField]
		private bool _useNormalItemVisual;

		[SerializeField]
		private Vector3 _normalTextSize;

		[SerializeField]
		private Material _normalTextMaterial;

		[SerializeField]
		private Material _normalBackgroundMaterial;

		[SerializeField]
		private bool _useSelectedItemVisual;

		[SerializeField]
		private Vector3 _selectedTextSize;

		[SerializeField]
		private Material _selectedTextMaterial;

		[SerializeField]
		private Material _selectedBackgroundMaterial;

		[SerializeField]
		private bool _usePressedItemVisual;

		[SerializeField]
		private Vector3 _pressedTextSize;

		[SerializeField]
		private Material _pressedTextMaterial;

		[SerializeField]
		private Material _pressedBackgroundMaterial;

		public float holdPressedVisualFor;

		[SerializeField]
		private bool _useDisabledItemVisual;

		[SerializeField]
		private Vector3 _disabledTextSize;

		[SerializeField]
		private Material _disabledTextMaterial;

		[SerializeField]
		private Material _disabledBackgroundMaterial;

		public bool useModules;

		public bool ignoreChildModules;

		[FormerlySerializedAs("unSelectModuleContainers")]
		public List<ModuleContainer> unSelectedModuleContainers;

		[FormerlySerializedAs("applyUnSelectModuleContainers")]
		public bool applyUnSelectedModuleContainers;

		[FormerlySerializedAs("ignoreChildUnSelectModuleContainers")]
		public bool ignoreChildUnSelectedModuleContainers;

		[FormerlySerializedAs("onSelectModuleContainers ")]
		public List<ModuleContainer> selectedModuleContainers;

		[FormerlySerializedAs("applyOnSelectModuleContainers")]
		public bool applySelectedModuleContainers;

		[FormerlySerializedAs("ignoreChildOnSelectModuleContainers")]
		public bool ignoreChildSelectedModuleContainers;

		[FormerlySerializedAs("onPressModuleContainers")]
		public List<ModuleContainer> beingPressedModuleContainers;

		[FormerlySerializedAs("applyOnPressModuleContainers")]
		public bool applyBeingPressedModuleContainers;

		[FormerlySerializedAs("ignoreChildOnPressModuleContainers")]
		public bool ignoreChildBeingPressedModuleContainers;

		[FormerlySerializedAs("onClickModuleContainers")]
		public List<ModuleContainer> pressCompleteModuleContainers;

		[FormerlySerializedAs("applyOnClickModuleContainers")]
		public bool applyPressCompleteModuleContainers;

		[FormerlySerializedAs("ignoreChildOnClickModuleContainers")]
		public bool ignoreChildPressCompleteModuleContainers;

		[Tooltip("If you are using the new input system, this calls the SwitchCurrentControlScheme() method in Player input, when Focus() is called.")]
		[SerializeField]
		private bool switchCurrentControlSchemeInPlayerInputWhenFocused;

		private float returnToSelectedTime;

		private bool pressed;

		public bool selected;

		private int counterToCheckIfAllItemsAreDisabledToAvoidInfiniteLoop;

		private int previousSelection;

		public bool UseStyle
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool UseNormalItemVisual
		{
			get
			{
				return false;
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

		public bool UseSelectedItemVisual
		{
			get
			{
				return false;
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

		public bool UsePressedItemVisual
		{
			get
			{
				return false;
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

		public bool UseDisabledItemVisual
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

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnDisable()
		{
		}

		[ContextMenu("Update List")]
		public void UpdateList()
		{
		}

		public void Focus()
		{
		}

		public void Focus(bool enable)
		{
		}

		public void Focus(bool enable, bool delay)
		{
		}

		[ContextMenu("Toggle Focus")]
		public void FocusToggle()
		{
		}

		[IteratorStateMachine(typeof(_003CFocusRoutine_003Ed__101))]
		private IEnumerator FocusRoutine()
		{
			return null;
		}

		public void SelectItem(int number)
		{
		}

		public void AlertSelectedItem(int number)
		{
		}

		public void UnselectItem(int i)
		{
		}

		public void UnselectEverything()
		{
		}

		public void UnselectEverythingExceptSelected()
		{
		}

		public void UnselectEverythingDontChangeSelectedItemValue()
		{
		}

		public void PressSelectedItem()
		{
		}

		public void PresstItem(int number)
		{
		}

		public void UpdateStyle()
		{
		}

		private void Scrolled()
		{
		}

		public void ScrollUp()
		{
		}

		public void ScrollDown()
		{
		}

		public void ScrollLeft()
		{
		}

		public void ScrollRight()
		{
		}

		private bool IsItemSelectable(int i)
		{
			return false;
		}

		private void AlertPressedUIItem()
		{
		}

		private void SelectTheFirstSelectableItem()
		{
		}

		public void EmptyEffect(List<ModuleContainer> moduleList)
		{
		}
	}
}
