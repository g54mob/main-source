using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne
{
	[RequireComponent(typeof(RectTransform))]
	public abstract class UIPanel : MonoBehaviour
	{
		public enum UINavigationType
		{
			ImmediateDirection = 0,
			NearestDirectionAndDistance = 1
		}

		[CompilerGenerated]
		private sealed class _003CSmoothScrollContent_003Ed__78 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIPanel _003C_003E4__this;

			public float duration;

			public Vector3 targetLocalPosition;

			private RectTransform _003Ccontent_003E5__2;

			private Vector3 _003CstartPos_003E5__3;

			private float _003Ctime_003E5__4;

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
			public _003CSmoothScrollContent_003Ed__78(int _003C_003E1__state)
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

		[SerializeField]
		[Tooltip("Manually assign the UIPanel attached to this screen in editor. Alternatively, you can use AddSelectable and RemoveSelectable to add/remove UISelectable.")]
		protected List<UISelectable> selectables;

		[SerializeField]
		[Tooltip("Default selectable to focus when the panel is selected.")]
		protected UISelectable defaultSelectable;

		[Tooltip("ScrollRect for scrolling Layout Group.")]
		[SerializeField]
		protected ScrollRect scrollRect;

		[SerializeField]
		[Tooltip("Priority value to control which panel will be selected by default by the Screen.")]
		private int priority;

		[Tooltip("When selected, the input action in the inputDescriptor list will be active")]
		[SerializeField]
		private List<InputDescriptor> inputDescriptors;

		[SerializeField]
		[Tooltip("Select this panel on Start")]
		private bool selectPanelOnStart;

		[Tooltip("Select this panel on OnEnable")]
		[SerializeField]
		private bool selectPanelOnEnable;

		[SerializeField]
		[Tooltip("Deselect this panel on OnDisable")]
		private bool deselectPanelOnDisable;

		[Tooltip("Set to true if this panel is supporting UIOptions to prevent left/right navigation of UISelectable and UIPanel")]
		[SerializeField]
		protected bool preventSideNavigation;

		[SerializeField]
		private UnityEvent OnPanelSelected;

		[SerializeField]
		private UnityEvent OnPanelDeselected;

		private UISelectable currentSelectedSelectable;

		protected int currentIndex;

		protected float navTimer;

		protected bool wasNavPressedLastFrame;

		protected float scrollSpeed;

		private Coroutine scrollCoroutine;

		private bool isDisabled;

		private bool isQuitting;

		private Vector2 scrollMargin;

		protected bool lockInputThisFrame;

		public int Priority => 0;

		public RectTransform RectTransform { get; private set; }

		public bool IsSelected { get; private set; }

		public bool IsLocked { get; set; }

		public UIScreen ParentScreen { get; private set; }

		public UISelectable CurrentSelectedSelectable
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IReadOnlyList<UISelectable> Selectables => null;

		public bool IsNavigablePanel => false;

		protected virtual void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void OnDestroy()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		protected virtual void Update()
		{
		}

		private void LateUpdate()
		{
		}

		protected virtual void EarlyUpdate()
		{
		}

		protected virtual void HandleInputDeviceChanged(GameInput.InputDeviceType type)
		{
		}

		protected virtual void DetectInput()
		{
		}

		protected void DetectScreenInputDescriptors()
		{
		}

		private void DetectSelectableInput()
		{
		}

		protected void SendClickEventToCurrentSelectedSelectable()
		{
		}

		public void SetParentScreen(UIScreen screen)
		{
		}

		internal bool IsPanelVisible()
		{
			return false;
		}

		internal bool IsAnySelectablesActive()
		{
			return false;
		}

		public UISelectable GetAValidCurrentSelectedSelectable(bool returnFirstFound = false)
		{
			return null;
		}

		public void SelectSelectable(UISelectable selectable, bool scrollToSelectable = false)
		{
		}

		public void SelectSelectable(int index, bool scrollToSelectable = false)
		{
		}

		public void SelectSelectable(bool returnFirstFound, bool scrollToSelectable = false)
		{
		}

		public bool AddSelectable(UISelectable selectable)
		{
			return false;
		}

		public void RemoveSelectable(UISelectable selectable, bool autoFallback = true)
		{
		}

		public void DeselectSelectable()
		{
		}

		public void ClearAllSelectables()
		{
		}

		private UISelectable GetFallbackSelectable(bool returnFirstFound = false)
		{
			return null;
		}

		internal UISelectable Select(UISelectable overrideSelectable = null, bool scrollToChild = true)
		{
			return null;
		}

		internal void Deselect()
		{
		}

		internal void OnReset()
		{
		}

		private void ResetCurrentSelectedSelectable()
		{
		}

		public void ScrollToCurrentSelectedSelectable()
		{
		}

		protected void ScrollToChild(RectTransform child, float duration = 0.25f)
		{
		}

		[IteratorStateMachine(typeof(_003CSmoothScrollContent_003Ed__78))]
		private IEnumerator SmoothScrollContent(Vector3 targetLocalPosition, float duration)
		{
			return null;
		}

		public void EnableSideNavigation(bool enabled)
		{
		}

		protected virtual bool Navigate(Vector2 navDir)
		{
			return false;
		}

		private void ResetNavigationData()
		{
		}

		internal void LockNavigationTemporarily()
		{
		}

		protected virtual bool NavigateUsingCyclePanel(Vector2 dir)
		{
			return false;
		}
	}
}
