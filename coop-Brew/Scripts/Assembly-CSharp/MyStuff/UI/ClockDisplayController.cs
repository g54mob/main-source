using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Calendar;
using MyStuff.Environment;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace MyStuff.UI
{
	[RequireComponent(typeof(UIDocument))]
	public class ClockDisplayController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CInitializeUICoroutine_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ClockDisplayController _003C_003E4__this;

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
			public _003CInitializeUICoroutine_003Ed__26(int _003C_003E1__state)
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
		[Tooltip("Use 24-hour format (true) or 12-hour format with AM/PM (false)")]
		[SerializeField]
		private bool use24HourFormat;

		[Tooltip("Update interval in seconds (0 = every frame)")]
		[SerializeField]
		private float updateInterval;

		[Tooltip("Show speed indicator when time scale != 1")]
		[SerializeField]
		private bool showSpeedIndicator;

		[Header("Calendar Button")]
		[Tooltip("Icon shown on the clock HUD to indicate clicking opens the calendar.")]
		[SerializeField]
		private Texture2D calendarIcon;

		[Header("Debug")]
		[SerializeField]
		private bool enableDebugLogs;

		private UIDocument uiDocument;

		private VisualElement clockRoot;

		private Label timeDisplay;

		private Label phaseIcon;

		private Label phaseText;

		private Label dayText;

		private VisualElement speedContainer;

		private Label speedText;

		private int lastHour;

		private int lastMinute;

		private TimePhase lastPhase;

		private int lastDay;

		private float lastTimeScale;

		private float timeSinceLastUpdate;

		private float displayedNormalizedTime;

		private bool isSmoothingTime;

		private const float SMOOTH_TIME_LERP_SPEED = 8f;

		private readonly (string icon, string nameKey, string cssClass)[] phaseData;

		private VisualElement _calendarPeek;

		private Label _calendarPeekTitle;

		private VisualElement _calendarPeekRows;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnLocalPlayerReady(InputReader reader)
		{
		}

		[IteratorStateMachine(typeof(_003CInitializeUICoroutine_003Ed__26))]
		private IEnumerator InitializeUICoroutine()
		{
			return null;
		}

		private void InitializeUI()
		{
		}

		private void SetupCalendarIntegration()
		{
		}

		private void BuildCalendarButton()
		{
		}

		private void ShowCalendarPeek()
		{
		}

		private void HideCalendarPeek()
		{
		}

		private void PopulateCalendarPeek()
		{
		}

		private void AddPeekRow(string label, string value, bool? positive = null)
		{
		}

		private static List<(string, string, bool)> CollectTopModifiers(DayModifierSet today, int count)
		{
			return null;
		}

		private void Update()
		{
		}

		private void UpdateClockSmooth()
		{
		}

		private void UpdateClock(bool forceUpdate = false)
		{
		}

		private void UpdateTimeDisplay(int hour, int minute)
		{
		}

		private void UpdatePhaseDisplay(TimePhase phase)
		{
		}

		private void UpdateDayDisplay(int dayIndex)
		{
		}

		private void UpdateSpeedDisplay(float timeScale)
		{
		}

		private void OnDisable()
		{
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}

		public void Toggle24HourFormat()
		{
		}
	}
}
