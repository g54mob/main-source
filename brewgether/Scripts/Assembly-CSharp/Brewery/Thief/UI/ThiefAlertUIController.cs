using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UI.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.Thief.UI
{
	[RequireComponent(typeof(UIDocument))]
	public class ThiefAlertUIController : MonoBehaviour
	{
		private enum AlertMessage : byte
		{
			None = 0,
			Stealing = 1,
			Escaping = 2,
			BreakingIn = 3,
			Nearby = 4
		}

		[CompilerGenerated]
		private sealed class _003CDelayedInit_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ThiefAlertUIController _003C_003E4__this;

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
			public _003CDelayedInit_003Ed__24(int _003C_003E1__state)
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

		[Header("Settings")]
		[Tooltip("Thief icon texture (Thief_Male_Icon.png).")]
		[SerializeField]
		private Texture2D thiefIcon;

		[Header("Proximity")]
		[Tooltip("Distance threshold for 'thief is nearby' message.")]
		[SerializeField]
		private float nearbyThreshold;

		[Tooltip("How often to refresh the cached thief list (seconds).")]
		[SerializeField]
		private float thiefCacheRefreshInterval;

		[Header("Animation")]
		[Tooltip("Speed of the pulsing opacity animation.")]
		[SerializeField]
		private float pulseSpeed;

		[Tooltip("Speed of the floating bob animation.")]
		[SerializeField]
		private float bobSpeed;

		[Tooltip("Amplitude of the floating bob in pixels.")]
		[SerializeField]
		private float bobAmplitude;

		private UIDocument uiDocument;

		private UIDocumentSleeper sleeper;

		private VisualElement alertContainer;

		private VisualElement iconElement;

		private Label alertText;

		private bool isShowing;

		private float animTimer;

		private bool isSubscribed;

		private ThiefCarryingController[] cachedThieves;

		private float lastThiefCacheTime;

		private AlertMessage currentMessage;

		public static ThiefAlertUIController Instance { get; private set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedInit_003Ed__24))]
		private IEnumerator DelayedInit()
		{
			return null;
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void InitUI()
		{
		}

		private void TrySubscribe()
		{
		}

		private void Unsubscribe()
		{
		}

		private void OnStealingCountChanged(int oldCount, int newCount)
		{
		}

		private void OnAlertTypeChanged(ThiefAlertType alertType)
		{
		}

		private void ShowAlert()
		{
		}

		private void HideAlert()
		{
		}

		private void Update()
		{
		}

		private void UpdateAlertMessage()
		{
		}

		private bool IsThiefNearby()
		{
			return false;
		}

		private static void SetPickingModeRecursive(VisualElement element, PickingMode mode)
		{
		}
	}
}
