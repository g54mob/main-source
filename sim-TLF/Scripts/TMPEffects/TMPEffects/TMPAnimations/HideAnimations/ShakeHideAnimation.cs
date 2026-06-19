using System;
using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Extensions;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.HideAnimations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new ShakeHideAnimation", menuName = "TMPEffects/Animations/Hide Animations/Built-in/Shake")]
	public class ShakeHideAnimation : TMPHideAnimation
	{
		[AutoParametersStorage]
		private class AutoParametersData
		{
			public bool init;

			public Dictionary<int, Vector2> offsetDict;

			public Dictionary<int, float> lastUpdatedDict;

			public Dictionary<int, float> delayDict;

			public Dictionary<int, System.Random> rngDict;

			public float duration;

			public float maxXAmplitude;

			public float minXAmplitude;

			public float maxYAmplitude;

			public float minYAmplitude;

			public float minWait;

			public float maxWait;

			public AnimationCurve waitCurve;

			public AnimationCurve amplitudeCurve;
		}

		[SerializeField]
		[AutoParameter("duration", new string[] { "dur", "d" })]
		[Tooltip("How long the animation will take to fully hide the character.\nAliases: duration, dur, d")]
		private float duration = 1f;

		[SerializeField]
		[AutoParameter("maxxamplitude", new string[] { "maxxamp", "maxxa", "maxx" })]
		[Tooltip("The maximum X amplitude of each shake.\nAliases: maxxamplitude, maxxamp, maxxa, maxx")]
		private float maxXAmplitude = 5f;

		[SerializeField]
		[AutoParameter("minxamplitude", new string[] { "minxamp", "minxa", "minx" })]
		[Tooltip("The minimum X amplitude of each shake.\nAliases: minxamplitude, minxamp, minxa, minx")]
		private float minXAmplitude = 5f;

		[SerializeField]
		[AutoParameter("maxyamplitude", new string[] { "maxyamp", "maxya", "maxy" })]
		[Tooltip("The maximum Y amplitude of each shake.\nAliases: maxyamplitude, maxyamp, maxya, maxy")]
		private float maxYAmplitude = 5f;

		[SerializeField]
		[AutoParameter("minyamplitude", new string[] { "minyamp", "minya", "miny" })]
		[Tooltip("The minimum Y amplitude of each shake.\nAliases: minyamplitude, minyamp, minya, miny")]
		private float minYAmplitude = 5f;

		[SerializeField]
		[AutoParameter("minwait", new string[] { "minw" })]
		[Tooltip("The minimum amount of time to wait after each shake.\nAliases: minwait, minw")]
		private float minWait = 0.1f;

		[SerializeField]
		[AutoParameter("maxwait", new string[] { "maxw" })]
		[Tooltip("The maximum amount of time to wait after each shake.\nAliases: maxwait, maxw")]
		private float maxWait = 0.1f;

		[SerializeField]
		[AutoParameter("waitcurve", new string[] { "waitcrv", "waitc" })]
		[Tooltip("The curve that defines the falloff of the wait between each shake.\nAliases: waitcurve, waitcrv, waitc")]
		private AnimationCurve waitCurve = AnimationCurveUtility.Linear();

		[SerializeField]
		[AutoParameter("amplitudecurve", new string[] { "amplitudecrv", "amplitudec", "ampcurve", "ampcrv", "ampc" })]
		[Tooltip("The curve that defines the falloff of the amplitude of each shake.\nAliases: amplitudecurve, amplitudecrv, amplitudec, ampcurve, ampcrv, ampc")]
		private AnimationCurve amplitudeCurve = AnimationCurveUtility.Invert(AnimationCurveUtility.Linear());

		private void InitRNGDict(AutoParametersData d, IAnimationContext context)
		{
			int num = (int)(context.AnimatorContext.PassedTime * 1000f);
			d.rngDict = new Dictionary<int, System.Random>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				d.rngDict.Add(i, new System.Random(num + i));
			}
		}

		private void InitLastUpdatedDict(AutoParametersData d, IAnimationContext context)
		{
			d.lastUpdatedDict = new Dictionary<int, float>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				d.lastUpdatedDict.Add(i, context.AnimatorContext.PassedTime);
			}
		}

		private void InitDelayDict(AutoParametersData d, IAnimationContext context)
		{
			d.delayDict = new Dictionary<int, float>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				d.delayDict.Add(i, 0f);
			}
		}

		private void InitOffsetDict(AutoParametersData d, IAnimationContext context)
		{
			d.offsetDict = new Dictionary<int, Vector2>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				d.offsetDict.Add(i, Vector2.zero);
			}
		}

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			if (!data.init)
			{
				data.init = true;
				InitRNGDict(data, context);
				InitLastUpdatedDict(data, context);
				InitDelayDict(data, context);
				InitOffsetDict(data, context);
			}
			float num = Mathf.Lerp(0f, 1f, (context.AnimatorContext.PassedTime - context.AnimatorContext.StateTime(cData)) / data.duration);
			float num2 = data.waitCurve.Evaluate(1f - num);
			float num3 = data.amplitudeCurve.Evaluate(1f - num);
			int key = context.SegmentData.SegmentIndexOf(cData);
			float num4 = data.duration - (context.AnimatorContext.PassedTime - context.AnimatorContext.StateTime(cData));
			if (num == 1f)
			{
				data.delayDict[key] = 0f;
				data.lastUpdatedDict[key] = 0f;
				data.offsetDict[key] = Vector2.zero;
				context.FinishAnimation(cData);
				return;
			}
			if (context.AnimatorContext.PassedTime - data.lastUpdatedDict[key] >= data.delayDict[key] && num4 >= data.minWait * num2)
			{
				float num5 = ((data.maxXAmplitude == data.minXAmplitude) ? data.maxXAmplitude : Mathf.Lerp(data.minXAmplitude, data.maxXAmplitude, (float)data.rngDict[key].NextDouble()));
				float num6 = ((data.maxYAmplitude == data.minYAmplitude) ? data.maxYAmplitude : Mathf.Lerp(data.minYAmplitude, data.maxYAmplitude, (float)data.rngDict[key].NextDouble()));
				float num7 = ((data.maxWait == data.minWait) ? data.maxWait : Mathf.Lerp(data.minWait, data.maxWait, (float)data.rngDict[key].NextDouble()));
				num7 *= num2;
				num7 = Mathf.Clamp(num7, 0f, num4);
				data.delayDict[key] = num7;
				data.lastUpdatedDict[key] = context.AnimatorContext.PassedTime;
				float x = ((float)data.rngDict[key].NextDouble() * 2f - 1f) * num5 * num3;
				float y = ((float)data.rngDict[key].NextDouble() * 2f - 1f) * num6 * num3;
				data.offsetDict[key] = new Vector3(x, y, 0f);
			}
			Vector3 vector = data.offsetDict[key];
			cData.SetPosition(cData.InitialPosition + vector);
		}

		public override void Animate(CharData cData, IAnimationContext context)
		{
			AutoParametersData data = context.CustomData as AutoParametersData;
			Animate(cData, data, context);
		}

		public override object GetNewCustomData()
		{
			return new AutoParametersData
			{
				duration = duration,
				maxXAmplitude = maxXAmplitude,
				minXAmplitude = minXAmplitude,
				maxYAmplitude = maxYAmplitude,
				minYAmplitude = minYAmplitude,
				minWait = minWait,
				maxWait = maxWait,
				waitCurve = waitCurve,
				amplitudeCurve = amplitudeCurve
			};
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				AutoParametersData autoParametersData = (AutoParametersData)customData;
				if (TMPParameterUtility.TryGetFloatParameter(out var value, parameters, keywordDatabase, "duration", "dur", "d"))
				{
					autoParametersData.duration = value;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value2, parameters, keywordDatabase, "maxxamplitude", "maxxamp", "maxxa", "maxx"))
				{
					autoParametersData.maxXAmplitude = value2;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value3, parameters, keywordDatabase, "minxamplitude", "minxamp", "minxa", "minx"))
				{
					autoParametersData.minXAmplitude = value3;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value4, parameters, keywordDatabase, "maxyamplitude", "maxyamp", "maxya", "maxy"))
				{
					autoParametersData.maxYAmplitude = value4;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value5, parameters, keywordDatabase, "minyamplitude", "minyamp", "minya", "miny"))
				{
					autoParametersData.minYAmplitude = value5;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value6, parameters, keywordDatabase, "minwait", "minw"))
				{
					autoParametersData.minWait = value6;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value7, parameters, keywordDatabase, "maxwait", "maxw"))
				{
					autoParametersData.maxWait = value7;
				}
				if (TMPParameterUtility.TryGetAnimCurveParameter(out var value8, parameters, keywordDatabase, "waitcurve", "waitcrv", "waitc"))
				{
					autoParametersData.waitCurve = value8;
				}
				if (TMPParameterUtility.TryGetAnimCurveParameter(out var value9, parameters, keywordDatabase, "amplitudecurve", "amplitudecrv", "amplitudec", "ampcurve", "ampcrv", "ampc"))
				{
					autoParametersData.amplitudeCurve = value9;
				}
			}
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return true;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "duration", "dur", "d"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "maxxamplitude", "maxxamp", "maxxa", "maxx"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "minxamplitude", "minxamp", "minxa", "minx"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "maxyamplitude", "maxyamp", "maxya", "maxy"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "minyamplitude", "minyamp", "minya", "miny"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "minwait", "minw"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "maxwait", "maxw"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonAnimCurveParameter(parameters, keywordDatabase, "waitcurve", "waitcrv", "waitc"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonAnimCurveParameter(parameters, keywordDatabase, "amplitudecurve", "amplitudecrv", "amplitudec", "ampcurve", "ampcrv", "ampc"))
			{
				return false;
			}
			return true;
		}
	}
}
