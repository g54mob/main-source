using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Doozy.Engine.Events;
using Doozy.Engine.Progress;
using Doozy.Engine.UI.Base;
using Doozy.Engine.UI.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Doozy.Engine.UI
{
	[AddComponentMenu("Doozy/UI/UIToggle", 2)]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(Toggle))]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-100)]
	public class UIToggle : UIComponentBase<UIToggle>, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, ISelectHandler, IDeselectHandler
	{
		[CompilerGenerated]
		private sealed class _003CDeselectToggleEnumerator_003Ed__70 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public UIToggle _003C_003E4__this;

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
			public _003CDeselectToggleEnumerator_003Ed__70(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CDisableToggleBehaviorEnumerator_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIToggleBehavior behavior;

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
			public _003CDisableToggleBehaviorEnumerator_003Ed__73(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CDisableToggleEnumerator_003Ed__72 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIToggle _003C_003E4__this;

			public float duration;

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
			public _003CDisableToggleEnumerator_003Ed__72(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CExecuteToggleBehaviorEnumerator_003Ed__71 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIToggleBehavior behavior;

			public UIToggle _003C_003E4__this;

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
			public _003CExecuteToggleBehaviorEnumerator_003Ed__71(int _003C_003E1__state)
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

		public static Action<UIToggle, UIToggleState, UIToggleBehaviorType> OnUIToggleAction;

		public bool AllowMultipleClicks;

		public float DisableButtonBetweenClicksInterval;

		public bool DeselectButtonAfterClick;

		public InputData InputData;

		public UIToggleBehavior OnPointerEnter;

		public UIToggleBehavior OnPointerExit;

		public UIToggleBehavior OnClick;

		public UIToggleBehavior OnSelected;

		public UIToggleBehavior OnDeselected;

		public BoolEvent OnValueChanged;

		public TargetLabel TargetLabel;

		public Text TextLabel;

		public Progressor ToggleProgressor;

		private CanvasGroup m_canvasGroup;

		private Coroutine m_disableButtonCoroutine;

		private bool m_previousValue;

		private Toggle m_toggle;

		private bool m_updateStartValuesRequired;

		private bool m_initialized;

		public CanvasGroup CanvasGroup => null;

		public bool HasLabel => false;

		public bool Interactable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsOn
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsSelected => false;

		public Toggle Toggle => null;

		public bool UpdateStartValuesRequired
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private bool DebugComponent => false;

		protected override void Reset()
		{
		}

		public override void Awake()
		{
		}

		public override void OnEnable()
		{
		}

		public override void Start()
		{
		}

		public override void OnDisable()
		{
		}

		private void Update()
		{
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
		}

		void ISelectHandler.OnSelect(BaseEventData eventData)
		{
		}

		void IDeselectHandler.OnDeselect(BaseEventData eventData)
		{
		}

		public void DeselectToggle()
		{
		}

		public void DeselectToggle(float delay)
		{
		}

		public void DisableToggle()
		{
		}

		public void DisableToggle(float duration)
		{
		}

		public void EnableToggle()
		{
		}

		public void ExecutePointerEnter(bool debug = false)
		{
		}

		public void ExecutePointerExit(bool debug = false)
		{
		}

		public void ExecuteClick(bool debug = false)
		{
		}

		public void ExecuteOnButtonDeselected(bool debug = false)
		{
		}

		public void ExecuteOnButtonSelected(bool debug = false)
		{
		}

		public void LoadPresets()
		{
		}

		public void NotifySystemOfTriggeredBehavior(UIToggleState toggleState, UIToggleBehaviorType behaviorType)
		{
		}

		public void SelectToggle()
		{
		}

		public void SetLabelText(string text)
		{
		}

		public void ToggleOff()
		{
		}

		public void ToggleOn()
		{
		}

		private void PrintBehaviorDebugMessage(UIToggleBehavior behavior, string action, bool debug = false)
		{
		}

		private void ToggleOnValueChanged(bool value)
		{
		}

		private void TriggerToggleBehavior(UIToggleBehavior behavior, bool debug = false)
		{
		}

		private bool BehaviorEnabled(UIToggleBehaviorType behaviorType)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CDeselectToggleEnumerator_003Ed__70))]
		private IEnumerator DeselectToggleEnumerator(float delay)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CExecuteToggleBehaviorEnumerator_003Ed__71))]
		private IEnumerator ExecuteToggleBehaviorEnumerator(UIToggleBehavior behavior)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDisableToggleEnumerator_003Ed__72))]
		private IEnumerator DisableToggleEnumerator(float duration)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDisableToggleBehaviorEnumerator_003Ed__73))]
		private IEnumerator DisableToggleBehaviorEnumerator(UIToggleBehavior behavior)
		{
			return null;
		}
	}
}
