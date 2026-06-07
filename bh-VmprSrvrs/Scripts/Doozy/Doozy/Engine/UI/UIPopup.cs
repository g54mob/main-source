using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Doozy.Engine.Progress;
using Doozy.Engine.Touchy;
using Doozy.Engine.UI.Animation;
using Doozy.Engine.UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.UI
{
	[AddComponentMenu("Doozy/UI/UIPopup", 2)]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(Canvas))]
	[RequireComponent(typeof(GraphicRaycaster))]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-100)]
	public class UIPopup : UIComponentBase<UIPopup>
	{
		[CompilerGenerated]
		private sealed class _003CExecuteHideDeselectButtonEnumerator_003Ed__116 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIPopup _003C_003E4__this;

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
			public _003CExecuteHideDeselectButtonEnumerator_003Ed__116(int _003C_003E1__state)
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
		private sealed class _003CExecuteShowSelectDeselectButtonEnumerator_003Ed__115 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIPopup _003C_003E4__this;

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
			public _003CExecuteShowSelectDeselectButtonEnumerator_003Ed__115(int _003C_003E1__state)
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
		private sealed class _003CHideEnumerator_003Ed__113 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIPopup _003C_003E4__this;

			public bool instantAction;

			private float _003CstartTime_003E5__2;

			private float _003CtotalDuration_003E5__3;

			private float _003CelapsedTime_003E5__4;

			private float _003CstartDelay_003E5__5;

			private bool _003CinvokedOnStart_003E5__6;

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
			public _003CHideEnumerator_003Ed__113(int _003C_003E1__state)
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
		private sealed class _003CHideWithDelayEnumerator_003Ed__114 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public UIPopup _003C_003E4__this;

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
			public _003CHideWithDelayEnumerator_003Ed__114(int _003C_003E1__state)
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
		private sealed class _003CShowEnumerator_003Ed__112 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIPopup _003C_003E4__this;

			public bool instantAction;

			private float _003CstartTime_003E5__2;

			private float _003CtotalDuration_003E5__3;

			private float _003CelapsedTime_003E5__4;

			private float _003CstartDelay_003E5__5;

			private bool _003CinvokedOnStart_003E5__6;

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
			public _003CShowEnumerator_003Ed__112(int _003C_003E1__state)
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
		private sealed class _003CTriggerShowInNextFrame_003Ed__111 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIPopup _003C_003E4__this;

			public bool instantAction;

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
			public _003CTriggerShowInNextFrame_003Ed__111(int _003C_003E1__state)
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

		public const string DEFAULT_POPUP_CANVAS_NAME = "PopupCanvas";

		public const int DEFAULT_POPUP_CANVAS_OVERLAY_SORT_ORDER = 10000;

		public static Action<UIPopup, AnimationType> OnUIPopupAction;

		public static readonly List<UIPopup> VisiblePopups;

		public bool AddToPopupQueue;

		public bool AutoHideAfterShow;

		public float AutoHideAfterShowDelay;

		public bool AutoSelectButtonAfterShow;

		public bool AutoSelectPreviouslySelectedButtonAfterHide;

		public bool BlockBackButton;

		public string CanvasName;

		public UIContainer Container;

		public bool CustomCanvasName;

		public UIPopupContentReferences Data;

		public bool DestroyAfterHide;

		public PopupDisplayOn DisplayTarget;

		public UIPopupBehavior HideBehavior;

		public bool HideOnAnyButton;

		public bool HideOnBackButton;

		public bool HideOnClickAnywhere;

		public bool HideOnClickContainer;

		public bool HideOnClickOverlay;

		public Progressor HideProgressor;

		public ProgressEvent OnInverseVisibilityChanged;

		public ProgressEvent OnVisibilityChanged;

		public UIContainer Overlay;

		public GameObject SelectedButton;

		public UIPopupBehavior ShowBehavior;

		public Progressor ShowProgressor;

		public bool UpdateHideProgressorOnShow;

		public bool UpdateShowProgressorOnHide;

		public bool UseOverlay;

		private Canvas m_canvas;

		private GraphicRaycaster m_graphicRaycaster;

		private GameObject m_previousSelectedButton;

		private float m_visibilityProgress;

		private VisibilityState m_visibilityState;

		private bool m_addedToQueue;

		private Coroutine m_showCoroutine;

		private Coroutine m_hideCoroutine;

		private Coroutine m_autoHideCoroutine;

		private Coroutine m_disableButtonClickCoroutine;

		private UIButton[] m_childUIButtons;

		private bool m_initialized;

		public static bool AnyPopupVisible => false;

		public static string DefaultPopupName => null;

		public static string DefaultTargetCanvasName => null;

		public static UIPopup LastShownPopup => null;

		private static TouchDetector Detector => null;

		public bool AddedToQueue
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Canvas Canvas => null;

		public bool DetectsTouch => false;

		public GraphicRaycaster GraphicRaycaster => null;

		public bool HasContainer => false;

		public bool HasOverlay => false;

		public float InverseVisibility => 0f;

		public bool IsHidden => false;

		public bool IsHiding => false;

		public bool IsShowing => false;

		public bool IsVisible => false;

		public string PopupName { get; private set; }

		public VisibilityState Visibility
		{
			get
			{
				return default(VisibilityState);
			}
			set
			{
			}
		}

		public float VisibilityProgress
		{
			get
			{
				return 0f;
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

		public override void OnDisable()
		{
		}

		private void Update()
		{
		}

		public void CancelAutoHide()
		{
		}

		public UICanvas GetTargetCanvas()
		{
			return null;
		}

		public void Hide(float delay)
		{
		}

		public void Hide(bool instantAction = false)
		{
		}

		public void InstantHide()
		{
		}

		public void ResetTargetCanvasToPopupCanvas(bool reparentImmediately = true)
		{
		}

		public void Show(bool instantAction = false)
		{
		}

		public void NotifySystemOfTriggeredBehavior(AnimationType animationType)
		{
		}

		public void SetPopupName(string popupName)
		{
		}

		public void SetTargetCanvasName(string canvasName, bool reparentImmediately = true)
		{
		}

		private void Initialize()
		{
		}

		private void LoadPresets()
		{
		}

		private void StopHide()
		{
		}

		private void StopShow()
		{
		}

		private void UpdateChildUIButtonsStartValues()
		{
		}

		private void UpdateOverlayAlpha(float value)
		{
		}

		private void ReparentToTargetCanvas()
		{
		}

		private void ReparentToPopupCanvas()
		{
		}

		[IteratorStateMachine(typeof(_003CTriggerShowInNextFrame_003Ed__111))]
		private IEnumerator TriggerShowInNextFrame(bool instantAction)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CShowEnumerator_003Ed__112))]
		private IEnumerator ShowEnumerator(bool instantAction)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CHideEnumerator_003Ed__113))]
		private IEnumerator HideEnumerator(bool instantAction)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CHideWithDelayEnumerator_003Ed__114))]
		private IEnumerator HideWithDelayEnumerator(float delay)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CExecuteShowSelectDeselectButtonEnumerator_003Ed__115))]
		private IEnumerator ExecuteShowSelectDeselectButtonEnumerator()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CExecuteHideDeselectButtonEnumerator_003Ed__116))]
		private IEnumerator ExecuteHideDeselectButtonEnumerator()
		{
			return null;
		}

		public static UIPopup GetPopup(string popupName)
		{
			return null;
		}

		public static UICanvas GetPopupOverlayCanvas()
		{
			return null;
		}

		public static UICanvas GetTargetCanvas(PopupDisplayOn popupDisplayOn, string targetCanvasName)
		{
			return null;
		}

		public static bool HidePopup(string popupName, bool instantAction = false)
		{
			return false;
		}

		private static void RemoveHiddenFromVisiblePopups()
		{
		}

		private static void RemoveNullsFromVisiblePopups()
		{
		}
	}
}
