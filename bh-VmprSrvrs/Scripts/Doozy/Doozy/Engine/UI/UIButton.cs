using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Doozy.Engine.UI.Base;
using Doozy.Engine.UI.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Doozy.Engine.UI
{
	[AddComponentMenu("Doozy/UI/UIButton", 2)]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(Button))]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-100)]
	public class UIButton : UIComponentBase<UIButton>, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, ISelectHandler, IDeselectHandler
	{
		[CompilerGenerated]
		private sealed class _003CDeselectButtonEnumerator_003Ed__102 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public UIButton _003C_003E4__this;

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
			public _003CDeselectButtonEnumerator_003Ed__102(int _003C_003E1__state)
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
		private sealed class _003CDisableButtonBehaviorEnumerator_003Ed__105 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIButtonBehavior behavior;

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
			public _003CDisableButtonBehaviorEnumerator_003Ed__105(int _003C_003E1__state)
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
		private sealed class _003CDisableButtonEnumerator_003Ed__104 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIButton _003C_003E4__this;

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
			public _003CDisableButtonEnumerator_003Ed__104(int _003C_003E1__state)
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
		private sealed class _003CExecuteButtonBehaviorEnumerator_003Ed__103 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIButtonBehavior behavior;

			public UIButton _003C_003E4__this;

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
			public _003CExecuteButtonBehaviorEnumerator_003Ed__103(int _003C_003E1__state)
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
		private sealed class _003CRunOnClickEnumerator_003Ed__106 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIButton _003C_003E4__this;

			public bool debug;

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
			public _003CRunOnClickEnumerator_003Ed__106(int _003C_003E1__state)
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
		private sealed class _003CRunOnLongClickEnumerator_003Ed__107 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIButton _003C_003E4__this;

			public bool debug;

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
			public _003CRunOnLongClickEnumerator_003Ed__107(int _003C_003E1__state)
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

		public static Action<UIButton, UIButtonBehaviorType> OnUIButtonAction;

		public bool AllowMultipleClicks;

		public string ButtonCategory;

		public string ButtonName;

		public SingleClickMode ClickMode;

		public bool DeselectButtonAfterClick;

		public float DisableButtonBetweenClicksInterval;

		public float DoubleClickRegisterInterval;

		public InputData InputData;

		public float LongClickRegisterInterval;

		public UIButtonBehavior OnPointerEnter;

		public UIButtonBehavior OnPointerExit;

		public UIButtonBehavior OnPointerDown;

		public UIButtonBehavior OnPointerUp;

		public UIButtonBehavior OnClick;

		public UIButtonBehavior OnDoubleClick;

		public UIButtonBehavior OnLongClick;

		public UIButtonBehavior OnRightClick;

		public UIButtonBehavior OnSelected;

		public UIButtonBehavior OnDeselected;

		public UIButtonLoopAnimation NormalLoopAnimation;

		public UIButtonLoopAnimation SelectedLoopAnimation;

		public TargetLabel TargetLabel;

		public Text TextLabel;

		private Button m_button;

		private CanvasGroup m_canvasGroup;

		private bool m_clickedOnce;

		private Coroutine m_disableButtonCoroutine;

		private float m_doubleClickTimeoutCounter;

		private bool m_executedLongClick;

		private Coroutine m_longClickRegisterCoroutine;

		private float m_longClickTimeoutCounter;

		private bool m_updateStartValuesRequired;

		public static string BackButtonName => null;

		public static string CustomButtonCategory => null;

		public static string DefaultButtonCategory => null;

		public static string DefaultButtonName => null;

		public Button Button => null;

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

		public bool IsBackButton => false;

		public bool IsSelected => false;

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

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
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

		public void DeselectButton()
		{
		}

		public void DeselectButton(float delay)
		{
		}

		public void DisableButton()
		{
		}

		public void DisableButton(float duration)
		{
		}

		public void EnableButton()
		{
		}

		public void ExecutePointerEnter(bool debug = false)
		{
		}

		public void ExecutePointerExit(bool debug = false)
		{
		}

		public void ExecutePointerDown(bool debug = false)
		{
		}

		public void ExecutePointerUp(bool debug = false)
		{
		}

		public void ExecuteClick(bool debug = false)
		{
		}

		public void ExecuteDoubleClick(bool debug = false)
		{
		}

		public void ExecuteLongClick(bool debug = false)
		{
		}

		public void ExecuteRightClick(bool debug = false)
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

		public void NotifySystemOfTriggeredBehavior(UIButtonBehaviorType behaviorType)
		{
		}

		public void SelectButton()
		{
		}

		public void SetLabelText(string text)
		{
		}

		public void StartNormalLoopAnimation()
		{
		}

		public void StartSelectedLoopAnimation()
		{
		}

		public void StopNormalLoopAnimation()
		{
		}

		public void StopSelectedLoopAnimation()
		{
		}

		private void PrintBehaviorDebugMessage(UIButtonBehavior behavior, string action, bool debug = false)
		{
		}

		private void TriggerButtonBehavior(UIButtonBehavior behavior, bool debug = false)
		{
		}

		private void InitiateClick(bool debug = false)
		{
		}

		private void ReadyAllBehaviors()
		{
		}

		private void RegisterLongClick(bool debug = false)
		{
		}

		private void UnregisterLongClick(bool debug = false)
		{
		}

		private void ResetLongClick(bool debug = false)
		{
		}

		private bool BehaviorEnabled(UIButtonBehaviorType behaviorType)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CDeselectButtonEnumerator_003Ed__102))]
		private IEnumerator DeselectButtonEnumerator(float delay)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CExecuteButtonBehaviorEnumerator_003Ed__103))]
		private IEnumerator ExecuteButtonBehaviorEnumerator(UIButtonBehavior behavior)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDisableButtonEnumerator_003Ed__104))]
		private IEnumerator DisableButtonEnumerator(float duration)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDisableButtonBehaviorEnumerator_003Ed__105))]
		private IEnumerator DisableButtonBehaviorEnumerator(UIButtonBehavior behavior)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRunOnClickEnumerator_003Ed__106))]
		private IEnumerator RunOnClickEnumerator(bool debug = false)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRunOnLongClickEnumerator_003Ed__107))]
		private IEnumerator RunOnLongClickEnumerator(bool debug = false)
		{
			return null;
		}

		public static List<UIButton> GetButtons(string buttonCategory, string buttonName)
		{
			return null;
		}
	}
}
