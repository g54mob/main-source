using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Michsky.UI.ModernUIPack
{
	public class NotificationStacking : MonoBehaviour
	{
		private sealed class _003CStartNotification_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NotificationStacking _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			public _003CStartNotification_003Ed__5(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = _003C_003E1__state;
				NotificationStacking notificationStacking = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E2__current = new WaitForSeconds(notificationStacking.notifications[notificationStacking.currentNotification].timer + notificationStacking.delay);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					UnityEngine.Object.Destroy(notificationStacking.notifications[notificationStacking.currentNotification].gameObject);
					notificationStacking.enableUpdating = true;
					notificationStacking.currentNotification++;
					notificationStacking.StopCoroutine("StartNotification");
					return false;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}

		public List<NotificationManager> notifications = new List<NotificationManager>();

		public bool enableUpdating;

		public float delay = 1f;

		private int currentNotification;

		private void Update()
		{
			if (!enableUpdating)
			{
				return;
			}
			try
			{
				notifications[currentNotification].gameObject.SetActive(value: true);
				if (notifications[currentNotification].notificationAnimator.GetCurrentAnimatorStateInfo(0).IsName("Wait"))
				{
					notifications[currentNotification].OpenNotification();
					StartCoroutine("StartNotification");
					enableUpdating = false;
				}
				if (currentNotification >= notifications.Count)
				{
					enableUpdating = false;
					currentNotification = 0;
				}
			}
			catch
			{
				enableUpdating = false;
				currentNotification = 0;
				notifications.Clear();
			}
		}

		private IEnumerator StartNotification()
		{
			return new _003CStartNotification_003Ed__5(0)
			{
				_003C_003E4__this = this
			};
		}
	}
}
