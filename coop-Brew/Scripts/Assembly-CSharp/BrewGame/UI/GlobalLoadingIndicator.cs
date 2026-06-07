using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BrewGame.UI
{
	public class GlobalLoadingIndicator : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAutoHideCoroutine_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GlobalLoadingIndicator _003C_003E4__this;

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
			public _003CAutoHideCoroutine_003Ed__28(int _003C_003E1__state)
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

		[Header("UI References")]
		[SerializeField]
		private GameObject loadingPanel;

		[SerializeField]
		private Image beerIcon;

		[SerializeField]
		private TMP_Text loadingText;

		[Header("Animation Settings")]
		[Tooltip("Total duration of one barrel roll cycle")]
		[SerializeField]
		private float totalCycleDuration;

		[Tooltip("Duration of slow start phase (0° to 90°)")]
		[SerializeField]
		private float slowStartDuration;

		[Tooltip("Duration of fast middle phase (90° to 270°)")]
		[SerializeField]
		private float fastMiddleDuration;

		[Tooltip("Duration of overshoot settle phase (270° to 360°)")]
		[SerializeField]
		private float overshootDuration;

		[Header("Settings")]
		[Tooltip("Auto-hide after this many seconds (safety timeout)")]
		[SerializeField]
		private float autoHideTimeout;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private bool _isShowing;

		private Coroutine _autoHideCoroutine;

		private int _animationTweenId;

		public static GlobalLoadingIndicator Instance { get; private set; }

		public bool IsShowing => false;

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void Show(string message = "Loading...")
		{
		}

		public void Hide()
		{
		}

		public void SetMessage(string message)
		{
		}

		private void StartRotationAnimation()
		{
		}

		private void PlayBarrelRollSequence()
		{
		}

		private void StopRotationAnimation()
		{
		}

		private void StartAutoHideTimer()
		{
		}

		private void StopAutoHideTimer()
		{
		}

		[IteratorStateMachine(typeof(_003CAutoHideCoroutine_003Ed__28))]
		private IEnumerator AutoHideCoroutine()
		{
			return null;
		}

		public static void ShowLoading(string message = "Loading...")
		{
		}

		public static void HideLoading()
		{
		}
	}
}
