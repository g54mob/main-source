using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NotifiSystemManager : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimationShowNotification_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GameObject notification;

		private RectTransform _003CrectNotification_003E5__2;

		private RectTransform _003CrectContent_003E5__3;

		private float _003Cduration1_003E5__4;

		private float _003CtargetHeight_003E5__5;

		private float _003CelapsedTime1_003E5__6;

		private Vector2 _003CoriginalSize_003E5__7;

		private float _003Cduration2_003E5__8;

		private float _003CstartPositionX_003E5__9;

		private float _003CendPositionX_003E5__10;

		private float _003CelapsedTime2_003E5__11;

		private Vector2 _003CoriginalPosition_003E5__12;

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
		public _003CAnimationShowNotification_003Ed__7(int _003C_003E1__state)
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
	private sealed class _003CRemoveNotificationAfterTime_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public GameObject notification;

		private CanvasGroup _003CcanvasGroup_003E5__2;

		private float _003CfadeDuration_003E5__3;

		private float _003CelapsedTime_003E5__4;

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
		public _003CRemoveNotificationAfterTime_003Ed__8(int _003C_003E1__state)
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

	public PersonalizationSettings personalizationSettings;

	public GameObject notificationPrefab;

	public Transform notificationParent;

	public AudioClip notificationSound;

	public AudioSource audioSource;

	public Sprite[] logo_push;

	public void AddNotification(int logo_numer, string title, string description, bool isSoundNotify = true)
	{
	}

	[IteratorStateMachine(typeof(_003CAnimationShowNotification_003Ed__7))]
	public IEnumerator AnimationShowNotification(GameObject notification)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CRemoveNotificationAfterTime_003Ed__8))]
	private IEnumerator RemoveNotificationAfterTime(GameObject notification, float delay)
	{
		return null;
	}
}
