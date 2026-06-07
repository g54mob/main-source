using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Doozy.Engine.Layouts;
using Doozy.Engine.Orientation;
using Doozy.Engine.Progress;
using Doozy.Engine.UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Engine.UI
{
	[AddComponentMenu("Doozy/UI/UIView", 2)]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(Canvas))]
	[RequireComponent(typeof(GraphicRaycaster))]
	[RequireComponent(typeof(CanvasGroup))]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-100)]
	public class UIView : UIComponentBase<UIView>
	{
		[CompilerGenerated]
		private sealed class _003CExecuteGetOrientationEnumerator_003Ed__110 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIView _003C_003E4__this;

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
			public _003CExecuteGetOrientationEnumerator_003Ed__110(int _003C_003E1__state)
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
		private sealed class _003CHideEnumerator_003Ed__108 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIView _003C_003E4__this;

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
			public _003CHideEnumerator_003Ed__108(int _003C_003E1__state)
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
		private sealed class _003CHideViewNextFrame_003Ed__106 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string viewCategory;

			public string viewName;

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
			public _003CHideViewNextFrame_003Ed__106(int _003C_003E1__state)
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
		private sealed class _003CHideWithDelayEnumerator_003Ed__109 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public UIView _003C_003E4__this;

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
			public _003CHideWithDelayEnumerator_003Ed__109(int _003C_003E1__state)
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
		private sealed class _003CShowEnumerator_003Ed__107 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public UIView _003C_003E4__this;

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
			public _003CShowEnumerator_003Ed__107(int _003C_003E1__state)
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
		private sealed class _003CShowViewNextFrame_003Ed__105 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string viewCategory;

			public string viewName;

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
			public _003CShowViewNextFrame_003Ed__105(int _003C_003E1__state)
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

		public static Action<UIView, UIViewBehaviorType> OnUIViewAction;

		public static readonly List<UIView> VisibleViews;

		public bool AutoHideAfterShow;

		public float AutoHideAfterShowDelay;

		public bool AutoSelectButtonAfterShow;

		public UIViewStartBehavior BehaviorAtStart;

		public Vector3 CustomStartAnchoredPosition;

		public bool DeselectAnyButtonSelectedOnHide;

		public bool DeselectAnyButtonSelectedOnShow;

		public bool DisableCanvasWhenHidden;

		public bool DisableGameObjectWhenHidden;

		public bool DisableGraphicRaycasterWhenHidden;

		public UIViewBehavior HideBehavior;

		public Progressor HideProgressor;

		public UIViewBehavior LoopBehavior;

		public ProgressEvent OnInverseVisibilityChanged;

		public ProgressEvent OnVisibilityChanged;

		public GameObject SelectedButton;

		public UIViewBehavior ShowBehavior;

		public Progressor ShowProgressor;

		public TargetOrientation TargetOrientation;

		public bool UpdateHideProgressorOnShow;

		public bool UpdateShowProgressorOnHide;

		public bool UseCustomStartAnchoredPosition;

		public string ViewCategory;

		public string ViewName;

		private Canvas m_canvas;

		private GraphicRaycaster m_graphicRaycaster;

		private CanvasGroup m_canvasGroup;

		private float m_visibilityProgress;

		private VisibilityState m_visibility;

		private Coroutine m_showCoroutine;

		private Coroutine m_hideCoroutine;

		private Coroutine m_autoHideCoroutine;

		private Coroutine m_disableButtonClickCoroutine;

		private UIButton[] m_childUIButtons;

		private UIView[] m_childUIViews;

		private bool m_initialized;

		private LayoutController m_layoutController;

		private bool m_hasLayoutController;

		private bool m_controlledByLayoutGroup;

		public static string DefaultViewCategory => null;

		public static string DefaultViewName => null;

		private static OrientationDetector OrientationDetector => null;

		public Canvas Canvas => null;

		public CanvasGroup CanvasGroup => null;

		public Vector3 CurrentStartPosition => default(Vector3);

		public GraphicRaycaster GraphicRaycaster => null;

		public float InverseVisibility => 0f;

		public bool IsHidden => false;

		public bool IsHiding => false;

		public bool IsShowing => false;

		public bool IsVisible => false;

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

		private bool HasChildUIViews => false;

		private bool DebugComponent => false;

		protected override void Reset()
		{
		}

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		private void CheckForLayoutController()
		{
		}

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}

		public void CancelAutoHide()
		{
		}

		public void Hide(bool instantAction = false)
		{
		}

		public void Hide(float delay)
		{
		}

		public void InstantHide()
		{
		}

		public void InstantShow()
		{
		}

		public void NotifySystemOfTriggeredBehavior(UIViewBehaviorType behaviorType)
		{
		}

		public override void ResetAlpha()
		{
		}

		public override void ResetPosition()
		{
		}

		public void SetVisibility(bool visible)
		{
		}

		public void SetVisibility(bool visible, bool instantAction)
		{
		}

		public void Show(bool instantAction = false)
		{
		}

		public void StartLoopAnimation()
		{
		}

		public void StopLoopAnimation()
		{
		}

		public void Toggle(bool instantAction = false)
		{
		}

		private void HideDeselectButton()
		{
		}

		private void Initialize()
		{
		}

		private void MoveToCustomStartPosition()
		{
		}

		private void LoadPresets()
		{
		}

		private void OnOrientationChange(DetectedOrientation newDeviceOrientation)
		{
		}

		private void ShowSelectDeselectButton()
		{
		}

		private void StopHide()
		{
		}

		private void StopShow()
		{
		}

		private void RemoveNullChildUIButtons()
		{
		}

		private void UpdateChildUIButtonsStartValues()
		{
		}

		[IteratorStateMachine(typeof(_003CShowViewNextFrame_003Ed__105))]
		public static IEnumerator ShowViewNextFrame(string viewCategory, string viewName, bool instantAction = false)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CHideViewNextFrame_003Ed__106))]
		public static IEnumerator HideViewNextFrame(string viewCategory, string viewName, bool instantAction = false)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CShowEnumerator_003Ed__107))]
		private IEnumerator ShowEnumerator(bool instantAction)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CHideEnumerator_003Ed__108))]
		private IEnumerator HideEnumerator(bool instantAction)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CHideWithDelayEnumerator_003Ed__109))]
		private IEnumerator HideWithDelayEnumerator(float delay)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CExecuteGetOrientationEnumerator_003Ed__110))]
		private IEnumerator ExecuteGetOrientationEnumerator()
		{
			return null;
		}

		public static List<UIView> GetViews(string viewCategory, string viewName)
		{
			return null;
		}

		public static void HideView(string viewName, bool instantAction = false)
		{
		}

		public static void HideView(string viewCategory, string viewName, bool instantAction = false)
		{
		}

		public static void HideViewCategory(string viewCategory, bool instantAction = false)
		{
		}

		public static bool IsViewVisible(string viewCategory, string viewName)
		{
			return false;
		}

		public static void ShowView(string viewName, bool instantAction = false)
		{
		}

		public static void ShowView(string viewCategory, string viewName, bool instantAction = false)
		{
		}

		public static void ShowViewCategory(string viewCategory, bool instantAction = false)
		{
		}

		private static void ExecuteHide(string viewCategory, string viewName, bool instantAction = false)
		{
		}

		private static void ExecuteHideCategory(string viewCategory, bool instantAction = false)
		{
		}

		private static void ExecuteShow(string viewCategory, string viewName, bool instantAction)
		{
		}

		private static void ExecuteShowCategory(string viewCategory, bool instantAction = false)
		{
		}

		private static void RemoveHiddenFromVisibleViews()
		{
		}

		private static void RemoveNullsFromVisibleViews()
		{
		}
	}
}
