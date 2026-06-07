using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MoreMountains.Tools
{
	[RequireComponent(typeof(Text))]
	[AddComponentMenu("More Mountains/Tools/Time/MMCountdown")]
	public class MMCountdown : MMMonoBehaviour
	{
		[Serializable]
		public class MMCountdownFloor
		{
			public float FloorValue;

			[MMReadOnly]
			public float LastChangedAt;

			public UnityEvent FloorEvent;
		}

		public enum MMCountdownDirections
		{
			Ascending = 0,
			Descending = 1
		}

		public enum FormatMethods
		{
			Explicit = 0,
			Choices = 1
		}

		[MMInspectorGroup("Countdown", true, 18, false)]
		[MMInformation("You can define the bounds of the countdown (how much it should count down from, and to how much, the format it should be displayed in (standard Unity float ToString formatting).", MMInformationAttribute.InformationType.Info, false)]
		public float CountdownFrom = 60f;

		public float CountdownTo;

		public bool Infinite;

		[MMInspectorGroup("Display", true, 19, false)]
		public FormatMethods FormatMethod = FormatMethods.Choices;

		[MMEnumCondition("FormatMethod", new int[] { 0 })]
		public bool FloorValues = true;

		[MMEnumCondition("FormatMethod", new int[] { 0 })]
		public string Format = "00.00";

		[MMEnumCondition("FormatMethod", new int[] { 1 })]
		public bool Hours;

		[MMEnumCondition("FormatMethod", new int[] { 1 })]
		public bool Minutes = true;

		[MMEnumCondition("FormatMethod", new int[] { 1 })]
		public bool Seconds = true;

		[MMEnumCondition("FormatMethod", new int[] { 1 })]
		public bool Milliseconds;

		[MMInspectorGroup("Settings", true, 20, false)]
		[MMInformation("You can choose whether or not the countdown should automatically start on its Start, at what frequency (in seconds) it should refresh (0 means every frame), and the countdown's speed multiplier (2 will be twice as fast, 0.5 half normal speed, etc). Floors are used to define and trigger events when certain floors are reached. For each floor, define a floor value (in seconds). Everytime this floor gets reached, the corresponding event will be triggered.Bind events here to trigger them when the countdown reaches its To destination, or every time it gets refreshed.", MMInformationAttribute.InformationType.Info, false)]
		public bool AutoStart = true;

		public bool AutoReset;

		public bool PingPong;

		public float RefreshFrequency = 0.02f;

		public float CountdownSpeed = 1f;

		[MMInspectorGroup("Floors", true, 21, false)]
		public List<MMCountdownFloor> Floors;

		[MMInspectorGroup("Events", true, 22, false)]
		public UnityEvent CountdownCompleteEvent;

		public UnityEvent CountdownRefreshEvent;

		[MMInspectorGroup("Debug", true, 17, false)]
		[MMReadOnly]
		public float CurrentTime;

		[MMReadOnly]
		public MMCountdownDirections Direction;

		[MMInspectorButton("StopCountdown")]
		public bool StopCountdownButton;

		[MMInspectorButton("StartCountdown")]
		public bool StartCountdownButton;

		[MMInspectorButton("ResetCountdown")]
		public bool ResetCountdownButton;

		[MMInspectorButton("ChangeDirection")]
		public bool ChangeDirectionButton;

		public float DebugNewCurrentTime = 5f;

		[MMInspectorButton("DebugSetNewCurrentTime")]
		public bool DebugSetNewCurrentTimeButton;

		protected Text _text;

		protected float _lastRefreshAt;

		protected bool _countdowning;

		protected int _lastUnitValue;

		private void DebugSetNewCurrentTime()
		{
			SetCurrentTime(DebugNewCurrentTime);
		}

		protected virtual void Start()
		{
			_text = base.gameObject.GetComponent<Text>();
			Initialization();
		}

		protected virtual void Initialization()
		{
			_lastUnitValue = (int)CurrentTime;
			Direction = ((CountdownFrom > CountdownTo) ? MMCountdownDirections.Descending : MMCountdownDirections.Ascending);
			CurrentTime = CountdownFrom;
			if (AutoStart)
			{
				StartCountdown();
			}
			foreach (MMCountdownFloor floor in Floors)
			{
				floor.LastChangedAt = CountdownFrom;
			}
		}

		protected virtual void Update()
		{
			if (_countdowning)
			{
				UpdateTime();
				UpdateText();
				CheckForFloors();
				CheckForEnd();
			}
		}

		protected virtual void UpdateTime()
		{
			if (Direction == MMCountdownDirections.Descending)
			{
				CurrentTime -= Time.deltaTime * CountdownSpeed;
			}
			else
			{
				CurrentTime += Time.deltaTime * CountdownSpeed;
			}
		}

		protected virtual void UpdateText()
		{
			if (Time.time - _lastRefreshAt > RefreshFrequency)
			{
				if (_text != null)
				{
					string text = "";
					text = ((FormatMethod != FormatMethods.Explicit) ? MMTime.FloatToTimeString(CurrentTime, Hours, Minutes, Seconds, Milliseconds) : ((!FloorValues) ? CurrentTime.ToString(Format) : Mathf.Floor(CurrentTime).ToString(Format)));
					_text.text = text;
				}
				if (CountdownRefreshEvent != null)
				{
					CountdownRefreshEvent.Invoke();
				}
				_lastRefreshAt = Time.time;
			}
		}

		protected virtual void CheckForEnd()
		{
			if (!Infinite && ((Direction == MMCountdownDirections.Ascending) ? (CurrentTime >= CountdownTo) : (CurrentTime <= CountdownTo)))
			{
				if (CountdownCompleteEvent != null)
				{
					CountdownCompleteEvent.Invoke();
				}
				if (PingPong)
				{
					Direction = ((Direction == MMCountdownDirections.Ascending) ? MMCountdownDirections.Descending : MMCountdownDirections.Ascending);
					_countdowning = true;
					float countdownFrom = CountdownFrom;
					CountdownFrom = CountdownTo;
					CountdownTo = countdownFrom;
				}
				else if (AutoReset)
				{
					_countdowning = true;
					CurrentTime = CountdownFrom;
				}
				else
				{
					CurrentTime = CountdownTo;
					_countdowning = false;
				}
			}
		}

		protected virtual void CheckForFloors()
		{
			foreach (MMCountdownFloor floor in Floors)
			{
				if (!(Mathf.Abs(CurrentTime - floor.LastChangedAt) >= floor.FloorValue))
				{
					continue;
				}
				if (floor.FloorEvent != null)
				{
					floor.FloorEvent.Invoke();
				}
				if (Direction == MMCountdownDirections.Descending)
				{
					if (floor.LastChangedAt == CountdownFrom)
					{
						floor.LastChangedAt = CountdownFrom - floor.FloorValue;
					}
					else
					{
						floor.LastChangedAt -= floor.FloorValue;
					}
				}
				else if (floor.LastChangedAt == CountdownFrom)
				{
					floor.LastChangedAt = CountdownFrom + floor.FloorValue;
				}
				else
				{
					floor.LastChangedAt += floor.FloorValue;
				}
			}
		}

		public virtual void StartCountdown()
		{
			_countdowning = true;
		}

		public virtual void StopCountdown()
		{
			_countdowning = false;
		}

		public virtual void ResetCountdown()
		{
			CurrentTime = CountdownFrom;
			Initialization();
		}

		public virtual void ChangeDirection()
		{
			Direction = ((Direction != MMCountdownDirections.Descending) ? MMCountdownDirections.Descending : MMCountdownDirections.Ascending);
			float countdownTo = CountdownTo;
			float countdownFrom = CountdownFrom;
			CountdownFrom = countdownTo;
			CountdownTo = countdownFrom;
		}

		public virtual void SetCurrentTime(float newCurrentTime)
		{
			CurrentTime = newCurrentTime;
		}
	}
}
