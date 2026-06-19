using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameHUDNotificationHandler : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public bool shown;

		internal void _003CHandleNotifications_003Eb__0()
		{
		}

		internal void _003CHandleNotifications_003Eb__1()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CHandleNotifications_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GameHUDNotificationHandler _003C_003E4__this;

		private _003C_003Ec__DisplayClass12_0 _003C_003E8__1;

		private GameHUDNotification _003Cnotification_003E5__2;

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
		public _003CHandleNotifications_003Ed__12(int _003C_003E1__state)
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

	private Queue<GameHUDNotification> _notifications;

	[SerializeField]
	private Transform _notificationQueueParent;

	[SerializeField]
	private Transform _notificationParent;

	[SerializeField]
	private RectTransform _shownTransform;

	[SerializeField]
	private CanvasGroup _canvasGroup;

	private bool HandlingNotifications;

	[SerializeField]
	private float _showTime;

	[SerializeField]
	private float _transitionDuration;

	[SerializeField]
	private float _bufferTime;

	public void Initiate()
	{
	}

	public void ShowAndDisposeNotification(GameHUDNotification notification)
	{
	}

	public void TryDequeue()
	{
	}

	[IteratorStateMachine(typeof(_003CHandleNotifications_003Ed__12))]
	private IEnumerator HandleNotifications()
	{
		return null;
	}
}
