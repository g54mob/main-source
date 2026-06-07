using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Brewery.UI
{
	public class NotificationManager : MonoBehaviour
	{
		public enum NotificationType
		{
			Success = 0,
			Error = 1,
			Info = 2,
			Warning = 3
		}

		private class ToastNotification
		{
			public string Title { get; set; }

			public string Message { get; set; }

			public NotificationType Type { get; set; }

			public float Duration { get; set; }

			public VisualElement Element { get; set; }

			public Coroutine DismissCoroutine { get; set; }
		}

		[CompilerGenerated]
		private sealed class _003CAnimateSlideIn_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VisualElement toast;

			private float _003Celapsed_003E5__2;

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
			public _003CAnimateSlideIn_003Ed__41(int _003C_003E1__state)
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
		private sealed class _003CAnimateSlideOut_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public VisualElement toast;

			private float _003Celapsed_003E5__2;

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
			public _003CAnimateSlideOut_003Ed__42(int _003C_003E1__state)
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
		private sealed class _003CAutoDismiss_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ToastNotification notification;

			public NotificationManager _003C_003E4__this;

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
			public _003CAutoDismiss_003Ed__43(int _003C_003E1__state)
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
		private sealed class _003CDismissNotificationCoroutine_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NotificationManager _003C_003E4__this;

			public ToastNotification notification;

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
			public _003CDismissNotificationCoroutine_003Ed__45(int _003C_003E1__state)
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
		private sealed class _003CProcessNotificationQueue_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NotificationManager _003C_003E4__this;

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
			public _003CProcessNotificationQueue_003Ed__35(int _003C_003E1__state)
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

		private VisualElement notificationContainer;

		private readonly Queue<ToastNotification> notificationQueue;

		private readonly List<ToastNotification> activeNotifications;

		private const int MAX_VISIBLE_NOTIFICATIONS = 3;

		private const float DEFAULT_DURATION = 3f;

		private const float SLIDE_IN_DURATION = 0.3f;

		private const float SLIDE_OUT_DURATION = 0.2f;

		private const float RATE_LIMIT_PER_TYPE = 3f;

		private const float DUPLICATE_SUPPRESSION_TIME = 5f;

		private readonly Dictionary<NotificationType, float> _lastNotificationTimeByType;

		private readonly Dictionary<string, float> _recentNotificationHashes;

		private bool isProcessingQueue;

		public static NotificationManager Instance { get; private set; }

		private void Awake()
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

		private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		public void Initialize(VisualElement container)
		{
		}

		public void ShowSuccess(string message, float duration = 3f)
		{
		}

		public void ShowSuccess(string title, string message, float duration = 3f)
		{
		}

		public void ShowError(string message, float duration = 3f)
		{
		}

		public void ShowError(string title, string message, float duration = 3f)
		{
		}

		public void ShowInfo(string message, float duration = 3f)
		{
		}

		public void ShowInfo(string title, string message, float duration = 3f)
		{
		}

		public void ShowWarning(string message, float duration = 3f)
		{
		}

		public void ShowWarning(string title, string message, float duration = 3f)
		{
		}

		public void ShowNotification(string title, string message, NotificationType type, float duration = 3f)
		{
		}

		private void CleanupOldTrackingEntries(float currentTime)
		{
		}

		public void ClearAll()
		{
		}

		[IteratorStateMachine(typeof(_003CProcessNotificationQueue_003Ed__35))]
		private IEnumerator ProcessNotificationQueue()
		{
			return null;
		}

		private void ShowNotificationImmediate(ToastNotification notification)
		{
		}

		private void PlayNotificationSound(NotificationType type)
		{
		}

		private VisualElement CreateToastElement(ToastNotification notification)
		{
			return null;
		}

		private string GetToastTypeClass(NotificationType type)
		{
			return null;
		}

		private string GetIconForType(NotificationType type)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimateSlideIn_003Ed__41))]
		private IEnumerator AnimateSlideIn(VisualElement toast)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimateSlideOut_003Ed__42))]
		private IEnumerator AnimateSlideOut(VisualElement toast)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAutoDismiss_003Ed__43))]
		private IEnumerator AutoDismiss(ToastNotification notification)
		{
			return null;
		}

		private void DismissNotification(ToastNotification notification)
		{
		}

		[IteratorStateMachine(typeof(_003CDismissNotificationCoroutine_003Ed__45))]
		private IEnumerator DismissNotificationCoroutine(ToastNotification notification)
		{
			return null;
		}

		private void RemoveNotificationElement(ToastNotification notification)
		{
		}
	}
}
