using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class Notifications : SelfInstancingMonoSingleton<Notifications>
	{
		public class QueuedNotice
		{
			public string title;

			public string description;

			public bool positiveAccent;
		}

		[CompilerGenerated]
		private sealed class _003CShowNextNotice_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public Notifications _003C_003E4__this;

			private List<Graphic> _003Cgraphics_003E5__2;

			private int _003CtotalIncrements_003E5__3;

			private float _003CalphaChangePerIncrement_003E5__4;

			private float _003CtimeBetweenIncrements_003E5__5;

			private float _003CverticalMovementPerIncrement_003E5__6;

			private int _003Ci_003E5__7;

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
			public _003CShowNextNotice_003Ed__15(int _003C_003E1__state)
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

		[Header("Notifications")]
		[SerializeField]
		private GameObject NotificationPanel;

		[SerializeField]
		private Image NotificationPanelImage;

		[SerializeField]
		private Image NotificationPanelIconBackgroundImage;

		[SerializeField]
		private Image NotificationPanelIconImage;

		[SerializeField]
		private TMP_Text NotificationPanelTitle;

		[SerializeField]
		private TMP_Text NotificationPanelDescription;

		[SerializeField]
		private Sprite NotificationErrorIcon;

		[SerializeField]
		private Sprite NotificationCheckmarkIcon;

		private Queue<QueuedNotice> upcomingNotices;

		private bool showingNotice;

		private Vector2 notificationOrigin;

		private void OnDisable()
		{
		}

		public void ProcessModManagementEventIntoNotification(ModManagementEventType type, ModId modId, Result result)
		{
		}

		public void AddNotificationToQueue(QueuedNotice notice)
		{
		}

		[IteratorStateMachine(typeof(_003CShowNextNotice_003Ed__15))]
		private IEnumerator ShowNextNotice()
		{
			return null;
		}
	}
}
