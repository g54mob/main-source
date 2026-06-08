using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class NotificationManager : MonoBehaviour
	{
		public enum NotificationStyle
		{
			FADING = 0,
			POPUP = 1,
			SLIDING = 2
		}

		private sealed class _003CStartTimer_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NotificationManager _003C_003E4__this;

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
			public _003CStartTimer_003Ed__14(int _003C_003E1__state)
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
				NotificationManager notificationManager = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					_003C_003E2__current = new WaitForSeconds(notificationManager.timer);
					_003C_003E1__state = 1;
					return true;
				case 1:
					_003C_003E1__state = -1;
					notificationManager.notificationAnimator.Play("Out");
					notificationManager.StopCoroutine("StartTimer");
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

		public Sprite icon;

		public string title = "Notification Title";

		public string description = "Notification description";

		public Animator notificationAnimator;

		public Image iconObj;

		public TextMeshProUGUI titleObj;

		public TextMeshProUGUI descriptionObj;

		public bool enableTimer = true;

		public float timer = 3f;

		public bool useCustomContent;

		public bool useStacking;

		public NotificationStyle notificationStyle;

		private void Start()
		{
			try
			{
				if (notificationAnimator == null)
				{
					notificationAnimator = base.gameObject.GetComponent<Animator>();
				}
				if (!useCustomContent)
				{
					iconObj.sprite = icon;
					titleObj.text = title;
					descriptionObj.text = description;
				}
			}
			catch
			{
				Debug.LogError("Notification - Cannot initalize the object due to missing components.", this);
			}
			if (useStacking)
			{
				try
				{
					NotificationStacking componentInParent = base.transform.GetComponentInParent<NotificationStacking>();
					componentInParent.notifications.Add(this);
					componentInParent.enableUpdating = true;
					base.gameObject.SetActive(value: false);
				}
				catch
				{
				}
			}
		}

		private IEnumerator StartTimer()
		{
			return new _003CStartTimer_003Ed__14(0)
			{
				_003C_003E4__this = this
			};
		}

		public void OpenNotification()
		{
			notificationAnimator.Play("In");
			if (enableTimer)
			{
				StartCoroutine("StartTimer");
			}
		}

		public void CloseNotification()
		{
			notificationAnimator.Play("Out");
		}

		public void UpdateUI()
		{
			try
			{
				iconObj.sprite = icon;
				titleObj.text = title;
				descriptionObj.text = description;
			}
			catch
			{
				Debug.LogError("Notification - Cannot update the object due to missing components.", this);
			}
		}
	}
}
