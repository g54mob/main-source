using System;
using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CozyTransitModule : CozyModule
	{
		[Serializable]
		public struct TimeWeightRelation
		{
			[MeridiemTime]
			public float time;

			[Range(0f, 360f)]
			public float sunHeight;

			[Range(0f, 1f)]
			public float weight;

			public TimeWeightRelation(float time, float sunHeight, float weight)
			{
				this.time = time;
				this.sunHeight = sunHeight;
				this.weight = weight;
			}
		}

		public enum TimeCurveSettings
		{
			linearDay = 0,
			simpleCurve = 1,
			advancedCurve = 2
		}

		[Serializable]
		public class TimeBlock
		{
			public MeridiemTime start;

			public MeridiemTime end;

			public TimeBlock(float startDayPercentage, float endDayPercentage)
			{
				start = startDayPercentage;
				end = endDayPercentage;
			}
		}

		public enum TimeBlockName
		{
			dawn = 0,
			morning = 1,
			day = 2,
			afternoon = 3,
			evening = 4,
			twilight = 5,
			night = 6
		}

		[HideInInspector]
		public AnimationCurve sunMovementCurve;

		[Tooltip("Specifies the default weight of the sunrise.")]
		[CozySearchable(new string[] { })]
		public TimeWeightRelation sunriseWeight = new TimeWeightRelation(0.25f, 90f, 0.2f);

		[Tooltip("Specifies the default weight of the day.")]
		[CozySearchable(new string[] { })]
		public TimeWeightRelation dayWeight = new TimeWeightRelation(0.5f, 180f, 0.2f);

		[Tooltip("Specifies the default weight of the sunset.")]
		[CozySearchable(new string[] { })]
		public TimeWeightRelation sunsetWeight = new TimeWeightRelation(0.75f, 270f, 0.2f);

		[Tooltip("Specifies the default weight of the night.")]
		[CozySearchable(new string[] { })]
		public TimeWeightRelation nightWeight = new TimeWeightRelation(1f, 360f, 0.2f);

		[Tooltip("Specifies the day length multiplier in the spring.")]
		[Range(-1f, 1f)]
		[CozySearchable(new string[] { })]
		public float springDayLengthOffset;

		[Tooltip("Specifies the day length multiplier in the summer.")]
		[Range(-1f, 1f)]
		[CozySearchable(new string[] { })]
		public float summerDayLengthOffset = 0.4f;

		[Tooltip("Specifies the day length multiplier in the fall.")]
		[Range(-1f, 1f)]
		[CozySearchable(new string[] { })]
		public float fallDayLengthOffset;

		[Tooltip("Specifies the day length multiplier in the winter.")]
		[Range(-1f, 1f)]
		[CozySearchable(new string[] { })]
		public float winterDayLengthOffset = -0.3f;

		[HideTitle(4f)]
		public AnimationCurve dayWeightsDisplayCurve;

		[HideTitle(4f)]
		public AnimationCurve yearWeightsCurve;

		public TimeCurveSettings timeCurveSettings;

		[CozySearchable(new string[] { })]
		public TimeBlock dawnBlock = new TimeBlock(1f / 6f, 11f / 48f);

		[CozySearchable(new string[] { })]
		public TimeBlock morningBlock = new TimeBlock(0.25f, 7f / 24f);

		[CozySearchable(new string[] { })]
		public TimeBlock dayBlock = new TimeBlock(0.3125f, 0.375f);

		[CozySearchable(new string[] { })]
		public TimeBlock afternoonBlock = new TimeBlock(13f / 24f, 7f / 12f);

		[CozySearchable(new string[] { })]
		public TimeBlock eveningBlock = new TimeBlock(2f / 3f, 0.75f);

		[CozySearchable(new string[] { })]
		public TimeBlock twilightBlock = new TimeBlock(5f / 6f, 0.875f);

		[CozySearchable(new string[] { })]
		public TimeBlock nightBlock = new TimeBlock(0.875f, 11f / 12f);

		public void GetModifiedDayPercent()
		{
			yearWeightsCurve = new AnimationCurve(new Keyframe(0f, winterDayLengthOffset, 0f, 0f), new Keyframe(0.25f, springDayLengthOffset, 0f, 0f), new Keyframe(0.5f, summerDayLengthOffset, 0f, 0f), new Keyframe(0.75f, fallDayLengthOffset, 0f, 0f), new Keyframe(1f, winterDayLengthOffset, 0f, 0f));
			float num = yearWeightsCurve.Evaluate(base.weatherSphere.timeModule.yearPercentage) / 5f;
			switch (timeCurveSettings)
			{
			case TimeCurveSettings.advancedCurve:
				sunMovementCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 0f, nightWeight.weight, nightWeight.weight), new Keyframe(sunriseWeight.time - num, sunriseWeight.sunHeight, 0f, 0f, sunriseWeight.weight, sunriseWeight.weight), new Keyframe(dayWeight.time, dayWeight.sunHeight, 0f, 0f, dayWeight.weight, dayWeight.weight), new Keyframe(sunsetWeight.time + num, sunsetWeight.sunHeight, 0f, 0f, sunsetWeight.weight, sunsetWeight.weight), new Keyframe(1f, (sunsetWeight.sunHeight > dayWeight.sunHeight) ? 360 : 0, 0f, 0f, nightWeight.weight, nightWeight.weight));
				dayWeightsDisplayCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 0f, nightWeight.weight, nightWeight.weight), new Keyframe(sunriseWeight.time - num, sunriseWeight.sunHeight, 0f, 0f, sunriseWeight.weight, sunriseWeight.weight), new Keyframe(dayWeight.time, dayWeight.sunHeight, 0f, 0f, dayWeight.weight, dayWeight.weight), new Keyframe(sunsetWeight.time + num, (sunsetWeight.sunHeight > 180f) ? (360f - sunsetWeight.sunHeight) : sunsetWeight.sunHeight, 0f, 0f, sunsetWeight.weight, sunsetWeight.weight), new Keyframe(1f, 0f, 0f, 0f, nightWeight.weight, nightWeight.weight));
				break;
			case TimeCurveSettings.simpleCurve:
				sunMovementCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 0f, nightWeight.weight, nightWeight.weight), new Keyframe(0.25f - num, 90f, 0f, 0f, sunriseWeight.weight, sunriseWeight.weight), new Keyframe(0.5f, 180f, 0f, 0f, dayWeight.weight, dayWeight.weight), new Keyframe(0.75f + num, 270f, 0f, 0f, sunsetWeight.weight, sunsetWeight.weight), new Keyframe(1f, 360f, 0f, 0f, nightWeight.weight, nightWeight.weight));
				dayWeightsDisplayCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 0f, nightWeight.weight, nightWeight.weight), new Keyframe(0.25f - num, 90f, 0f, 0f, sunriseWeight.weight, sunriseWeight.weight), new Keyframe(0.5f, 180f, 0f, 0f, dayWeight.weight, dayWeight.weight), new Keyframe(0.75f + num, 90f, 0f, 0f, sunsetWeight.weight, sunsetWeight.weight), new Keyframe(1f, 0f, 0f, 0f, nightWeight.weight, nightWeight.weight));
				break;
			case TimeCurveSettings.linearDay:
				sunMovementCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 0f, 0f, 0f), new Keyframe(0.25f - num, 90f, 0f, 0f, 0f, 0f), new Keyframe(0.5f, 180f, 0f, 0f, 0f, 0f), new Keyframe(0.75f + num, 270f, 0f, 0f, 0f, 0f), new Keyframe(1f, 360f, 0f, 0f, 0f, 0f));
				dayWeightsDisplayCurve = new AnimationCurve(new Keyframe(0f, 0f, 0f, 0f, 0f, 0f), new Keyframe(0.25f - num, 90f, 0f, 0f, 0f, 0f), new Keyframe(0.5f, 180f, 0f, 0f, 0f, 0f), new Keyframe(0.75f + num, 90f, 0f, 0f, 0f, 0f), new Keyframe(1f, 0f, 0f, 0f, 0f, 0f));
				break;
			}
		}

		public void GetSunTransitTime(out MeridiemTime sunrise, out MeridiemTime sunset)
		{
			yearWeightsCurve = new AnimationCurve(new Keyframe(0f, winterDayLengthOffset, 0f, 0f), new Keyframe(0.25f, springDayLengthOffset, 0f, 0f), new Keyframe(0.5f, summerDayLengthOffset, 0f, 0f), new Keyframe(0.75f, fallDayLengthOffset, 0f, 0f), new Keyframe(1f, winterDayLengthOffset, 0f, 0f));
			float num = yearWeightsCurve.Evaluate(base.weatherSphere.timeModule.yearPercentage) / 5f;
			sunrise = 0.25f - num;
			sunset = 0.75f + num;
			if (timeCurveSettings == TimeCurveSettings.advancedCurve)
			{
				sunrise = sunriseWeight.time - num;
				sunset = sunsetWeight.time + num;
			}
		}

		public override void InitializeModule()
		{
			base.SetupModule(new Type[1] { typeof(CozyTimeModule) });
			CozyWeather.Events.onNewDay += GetModifiedDayPercent;
			if ((bool)base.weatherSphere.timeModule)
			{
				base.weatherSphere.timeModule.transit = this;
			}
		}

		private void Start()
		{
			SetupTimeEvents();
			GetModifiedDayPercent();
		}

		private void Update()
		{
			ManageTimeEvents();
		}

		private void ManageTimeEvents()
		{
			if ((float)base.weatherSphere.timeModule.currentTime > base.weatherSphere.events.timeToCheckFor && (!((float)base.weatherSphere.timeModule.currentTime > (float)nightBlock.start) || base.weatherSphere.events.timeToCheckFor != (float)dawnBlock.start))
			{
				if ((float)base.weatherSphere.timeModule.currentTime > (float)nightBlock.start && base.weatherSphere.events.timeToCheckFor == (float)nightBlock.start)
				{
					base.weatherSphere.events.RaiseOnNight();
					base.weatherSphere.events.timeToCheckFor = dawnBlock.start;
				}
				else if ((float)base.weatherSphere.timeModule.currentTime > (float)twilightBlock.start && base.weatherSphere.events.timeToCheckFor == (float)twilightBlock.start)
				{
					base.weatherSphere.events.RaiseOnTwilight();
					base.weatherSphere.events.timeToCheckFor = nightBlock.start;
				}
				else if ((float)base.weatherSphere.timeModule.currentTime > (float)eveningBlock.start && base.weatherSphere.events.timeToCheckFor == (float)eveningBlock.start)
				{
					base.weatherSphere.events.RaiseOnEvening();
					base.weatherSphere.events.timeToCheckFor = twilightBlock.start;
				}
				else if ((float)base.weatherSphere.timeModule.currentTime > (float)afternoonBlock.start && base.weatherSphere.events.timeToCheckFor == (float)afternoonBlock.start)
				{
					base.weatherSphere.events.RaiseOnAfternoon();
					base.weatherSphere.events.timeToCheckFor = eveningBlock.start;
				}
				else if ((float)base.weatherSphere.timeModule.currentTime > (float)dayBlock.start && base.weatherSphere.events.timeToCheckFor == (float)dayBlock.start)
				{
					base.weatherSphere.events.RaiseOnDay();
					base.weatherSphere.events.timeToCheckFor = afternoonBlock.start;
				}
				else if ((float)base.weatherSphere.timeModule.currentTime > (float)morningBlock.start && base.weatherSphere.events.timeToCheckFor == (float)morningBlock.start)
				{
					base.weatherSphere.events.RaiseOnMorning();
					base.weatherSphere.events.timeToCheckFor = dayBlock.start;
				}
				else
				{
					base.weatherSphere.events.RaiseOnDawn();
					base.weatherSphere.events.timeToCheckFor = morningBlock.start;
				}
			}
			if (Mathf.FloorToInt((float)base.weatherSphere.timeModule.currentTime * 24f) != base.weatherSphere.events.currentHour)
			{
				base.weatherSphere.events.currentHour = Mathf.FloorToInt((float)base.weatherSphere.timeModule.currentTime * 24f);
				base.weatherSphere.events.RaiseOnNewHour();
			}
			if (Mathf.FloorToInt((float)base.weatherSphere.timeModule.currentTime * 1440f) != base.weatherSphere.events.currentMinute)
			{
				base.weatherSphere.events.currentMinute = Mathf.FloorToInt((float)base.weatherSphere.timeModule.currentTime * 1440f);
				base.weatherSphere.events.RaiseOnMinutePass();
			}
		}

		private void SetupTimeEvents()
		{
			base.weatherSphere.events.timeToCheckFor = dawnBlock.start;
			if ((float)base.weatherSphere.timeModule.currentTime > (float)dawnBlock.start)
			{
				base.weatherSphere.events.timeToCheckFor = morningBlock.start;
			}
			if ((float)base.weatherSphere.timeModule.currentTime > (float)morningBlock.start)
			{
				base.weatherSphere.events.timeToCheckFor = dayBlock.start;
			}
			if ((float)base.weatherSphere.timeModule.currentTime > (float)dayBlock.start)
			{
				base.weatherSphere.events.timeToCheckFor = afternoonBlock.start;
			}
			if ((float)base.weatherSphere.timeModule.currentTime > (float)afternoonBlock.start)
			{
				base.weatherSphere.events.timeToCheckFor = eveningBlock.start;
			}
			if ((float)base.weatherSphere.timeModule.currentTime > (float)eveningBlock.start)
			{
				base.weatherSphere.events.timeToCheckFor = twilightBlock.start;
			}
			if ((float)base.weatherSphere.timeModule.currentTime > (float)twilightBlock.start)
			{
				base.weatherSphere.events.timeToCheckFor = nightBlock.start;
			}
			if ((float)base.weatherSphere.timeModule.currentTime > (float)nightBlock.start)
			{
				base.weatherSphere.events.timeToCheckFor = dawnBlock.start;
			}
			base.weatherSphere.events.currentHour = Mathf.FloorToInt((float)base.weatherSphere.timeModule.currentTime * 24f);
			base.weatherSphere.events.currentMinute = Mathf.FloorToInt((float)base.weatherSphere.timeModule.currentTime * 1440f);
		}

		public float ModifyDayPercentage(float input)
		{
			return sunMovementCurve.Evaluate(input);
		}

		public TimeBlockName GetTimeBlock()
		{
			TimeBlockName result = TimeBlockName.night;
			float num = base.weatherSphere.timeModule.currentTime;
			if (num > (float)dawnBlock.start && num < (float)morningBlock.start)
			{
				result = TimeBlockName.dawn;
			}
			if (num > (float)morningBlock.start && num < (float)dayBlock.start)
			{
				result = TimeBlockName.morning;
			}
			if (num > (float)dayBlock.start && num < (float)afternoonBlock.start)
			{
				result = TimeBlockName.day;
			}
			if (num > (float)afternoonBlock.start && num < (float)eveningBlock.start)
			{
				result = TimeBlockName.afternoon;
			}
			if (num > (float)eveningBlock.start && num < (float)twilightBlock.start)
			{
				result = TimeBlockName.evening;
			}
			if (num > (float)twilightBlock.start && num < (float)nightBlock.start)
			{
				result = TimeBlockName.twilight;
			}
			return result;
		}

		public TimeBlockName GetTimeBlock(float time)
		{
			TimeBlockName result = TimeBlockName.night;
			if (time > (float)dawnBlock.start && time < (float)morningBlock.start)
			{
				result = TimeBlockName.dawn;
			}
			if (time > (float)morningBlock.start && time < (float)dayBlock.start)
			{
				result = TimeBlockName.morning;
			}
			if (time > (float)dayBlock.start && time < (float)afternoonBlock.start)
			{
				result = TimeBlockName.day;
			}
			if (time > (float)afternoonBlock.start && time < (float)eveningBlock.start)
			{
				result = TimeBlockName.afternoon;
			}
			if (time > (float)eveningBlock.start && time < (float)twilightBlock.start)
			{
				result = TimeBlockName.evening;
			}
			if (time > (float)twilightBlock.start && time < (float)nightBlock.start)
			{
				result = TimeBlockName.twilight;
			}
			return result;
		}
	}
}
