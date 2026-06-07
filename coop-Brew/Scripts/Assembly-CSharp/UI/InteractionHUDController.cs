using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

namespace UI
{
	public class InteractionHUDController : MonoBehaviour
	{
		public enum PromptStyle
		{
			Normal = 0,
			Success = 1,
			Warning = 2,
			Error = 3
		}

		public enum MessageType
		{
			Info = 0,
			Success = 1,
			Warning = 2,
			Error = 3
		}

		[CompilerGenerated]
		private sealed class _003CAutoHideMessageCoroutine_003Ed__72 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public InteractionHUDController _003C_003E4__this;

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
			public _003CAutoHideMessageCoroutine_003Ed__72(int _003C_003E1__state)
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
		private sealed class _003CDelayedUIManagerSubscribe_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public InteractionHUDController _003C_003E4__this;

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
			public _003CDelayedUIManagerSubscribe_003Ed__43(int _003C_003E1__state)
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

		[Header("UI Document")]
		[SerializeField]
		private UIDocument uiDocument;

		[SerializeField]
		private string uxmlPath;

		[SerializeField]
		private string ussPath;

		[Header("Animation")]
		[SerializeField]
		private float showDuration;

		[SerializeField]
		private float hideDuration;

		[SerializeField]
		private float showStartScale;

		[SerializeField]
		private float hideEndScale;

		[SerializeField]
		private LeanTweenType showEaseType;

		[SerializeField]
		private LeanTweenType hideEaseType;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private VisualElement root;

		private VisualElement hudRoot;

		private VisualElement promptContainer;

		private Label promptText;

		private VisualElement progressContainer;

		private Label progressLabel;

		private ProgressBar progressBar;

		private VisualElement messageContainer;

		private Label messageText;

		private bool isPromptVisible;

		private bool isProgressVisible;

		private bool isMessageVisible;

		private PromptStyle currentPromptStyle;

		private MessageType currentMessageType;

		private object currentPromptSource;

		private Transform currentWorldAnchor;

		private Camera playerCamera;

		private bool shouldUpdatePosition;

		private int showScaleTweenId;

		private int showOpacityTweenId;

		private int hideScaleTweenId;

		private int hideOpacityTweenId;

		private bool isAnimatingShow;

		private bool isAnimatingHide;

		private Coroutine messageAutoHideCoroutine;

		public static InteractionHUDController Instance { get; private set; }

		public bool IsPromptVisible => false;

		public bool IsProgressVisible => false;

		public bool IsMessageVisible => false;

		private void Awake()
		{
		}

		private void SubscribeToUIManager()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedUIManagerSubscribe_003Ed__43))]
		private IEnumerator DelayedUIManagerSubscribe()
		{
			return null;
		}

		private void OnAnyUIOpened()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnBeginCameraRendering(ScriptableRenderContext context, Camera camera)
		{
		}

		private void InitializeUI()
		{
		}

		private void SetInitialHiddenState()
		{
		}

		public void SetWorldSpaceAnchor(Transform anchor, Camera camera = null)
		{
		}

		private void UpdateWorldSpacePosition()
		{
		}

		private void ApplyScreenPosition(Vector2 screenPosition)
		{
		}

		private void ResetToScreenSpacePosition()
		{
		}

		private void CancelAllAnimations()
		{
		}

		private void AnimateShow()
		{
		}

		private void AnimateHide(Action onComplete = null)
		{
		}

		public void ShowPrompt(string text, PromptStyle style = PromptStyle.Normal, Transform worldAnchor = null, Camera camera = null, bool transition = false, object source = null)
		{
		}

		private void ShowPromptImmediate(string text, PromptStyle style, Transform worldAnchor, Camera camera, bool animate)
		{
		}

		public void HidePrompt(object source = null, bool force = false)
		{
		}

		public void SetPromptStyle(PromptStyle style)
		{
		}

		public void ShowProgress(string label, float progress)
		{
		}

		public void UpdateProgress(float progress)
		{
		}

		public void HideProgress()
		{
		}

		public void ShowMessage(string text, MessageType type = MessageType.Info, float duration = 2.5f)
		{
		}

		[IteratorStateMachine(typeof(_003CAutoHideMessageCoroutine_003Ed__72))]
		private IEnumerator AutoHideMessageCoroutine(float delay)
		{
			return null;
		}

		public void HideMessage()
		{
		}

		private void SetMessageType(MessageType type)
		{
		}

		public void HideAll()
		{
		}
	}
}
