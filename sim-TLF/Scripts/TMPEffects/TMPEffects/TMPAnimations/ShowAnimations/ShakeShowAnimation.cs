using System;
using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Extensions;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.ShowAnimations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new ShakeShowAnimation", menuName = "TMPEffects/Animations/Show Animations/Built-in/Shake")]
	public class ShakeShowAnimation : TMPShowAnimation
	{
		[AutoParametersStorage]
		private class Data
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
		[AutoParameter("amplitudecurve", new string[] { "amplitudecrv", "amplitudec", "amplitudec", "ampcurve", "ampcrv", "ampc" })]
		[Tooltip("The curve that defines the falloff of the amplitude of each shake.\nAliases: amplitudecurve, amplitudecrv, amplitudec, ampcurve, ampcrv, ampc")]
		private AnimationCurve amplitudeCurve = AnimationCurveUtility.Invert(AnimationCurveUtility.Linear());

		private void InitRNGDict(IAnimationContext context)
		{
			Data data = context.CustomData as Data;
			int num = (int)(context.AnimatorContext.PassedTime * 1000f);
			data.rngDict = new Dictionary<int, System.Random>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				data.rngDict.Add(i, new System.Random(num + i));
			}
		}

		private void InitLastUpdatedDict(IAnimationContext context)
		{
			Data data = context.CustomData as Data;
			data.lastUpdatedDict = new Dictionary<int, float>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				data.lastUpdatedDict.Add(i, context.AnimatorContext.PassedTime);
			}
		}

		private void InitDelayDict(IAnimationContext context)
		{
			Data data = context.CustomData as Data;
			data.delayDict = new Dictionary<int, float>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				data.delayDict.Add(i, 0f);
			}
		}

		private void InitOffsetDict(IAnimationContext context)
		{
			Data data = context.CustomData as Data;
			data.offsetDict = new Dictionary<int, Vector2>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				data.offsetDict.Add(i, Vector2.zero);
			}
		}

		private void Animate(CharData cData, Data data, IAnimationContext context)
		{
			Data data2 = context.CustomData as Data;
			if (!data2.init)
			{
				data2.init = true;
				InitRNGDict(context);
				InitLastUpdatedDict(context);
				InitDelayDict(context);
				InitOffsetDict(context);
			}
			float num = Mathf.Lerp(0f, 1f, (context.AnimatorContext.PassedTime - context.AnimatorContext.StateTime(cData)) / data2.duration);
			float num2 = data2.waitCurve.Evaluate(num);
			float num3 = data2.amplitudeCurve.Evaluate(num);
			int key = context.SegmentData.SegmentIndexOf(cData);
			float num4 = data2.duration - (context.AnimatorContext.PassedTime - context.AnimatorContext.StateTime(cData));
			if (num == 1f)
			{
				data2.delayDict[key] = 0f;
				data2.lastUpdatedDict[key] = 0f;
				data2.offsetDict[key] = Vector2.zero;
				context.FinishAnimation(cData);
				return;
			}
			if (context.AnimatorContext.PassedTime - data2.lastUpdatedDict[key] >= data2.delayDict[key] && num4 >= data2.minWait * num2)
			{
				float num5 = ((data2.maxXAmplitude == data2.minXAmplitude) ? data2.maxXAmplitude : Mathf.Lerp(data2.minXAmplitude, data2.maxXAmplitude, (float)data2.rngDict[key].NextDouble()));
				float num6 = ((data2.maxYAmplitude == data2.minYAmplitude) ? data2.maxYAmplitude : Mathf.Lerp(data2.minYAmplitude, data2.maxYAmplitude, (float)data2.rngDict[key].NextDouble()));
				float num7 = ((data2.maxWait == data2.minWait) ? data2.maxWait : Mathf.Lerp(data2.minWait, data2.maxWait, (float)data2.rngDict[key].NextDouble()));
				num7 *= num2;
				num7 = Mathf.Clamp(num7, data2.delayDict[key], num4);
				data2.delayDict[key] = num7;
				data2.lastUpdatedDict[key] = context.AnimatorContext.PassedTime;
				float x = ((float)data2.rngDict[key].NextDouble() * 2f - 1f) * num5 * num3;
				float y = ((float)data2.rngDict[key].NextDouble() * 2f - 1f) * num6 * num3;
				data2.offsetDict[key] = new Vector3(x, y, 0f);
			}
			Vector3 vector = data2.offsetDict[key];
			cData.SetPosition(cData.InitialPosition + vector);
		}

		public override void Animate(CharData cData, IAnimationContext context)
		{
			Data data = context.CustomData as Data;
			Animate(cData, data, context);
		}

		public override object GetNewCustomData()
		{
			return new Data
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
				Data data = (Data)customData;
				if (TMPParameterUtility.TryGetFloatParameter(out var value, parameters, keywordDatabase, "duration", "dur", "d"))
				{
					data.duration = value;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value2, parameters, keywordDatabase, "maxxamplitude", "maxxamp", "maxxa", "maxx"))
				{
					data.maxXAmplitude = value2;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value3, parameters, keywordDatabase, "minxamplitude", "minxamp", "minxa", "minx"))
				{
					data.minXAmplitude = value3;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value4, parameters, keywordDatabase, "maxyamplitude", "maxyamp", "maxya", "maxy"))
				{
					data.maxYAmplitude = value4;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value5, parameters, keywordDatabase, "minyamplitude", "minyamp", "minya", "miny"))
				{
					data.minYAmplitude = value5;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value6, parameters, keywordDatabase, "minwait", "minw"))
				{
					data.minWait = value6;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value7, parameters, keywordDatabase, "maxwait", "maxw"))
				{
					data.maxWait = value7;
				}
				if (TMPParameterUtility.TryGetAnimCurveParameter(out var value8, parameters, keywordDatabase, "waitcurve", "waitcrv", "waitc"))
				{
					data.waitCurve = value8;
				}
				if (TMPParameterUtility.TryGetAnimCurveParameter(out var value9, parameters, keywordDatabase, "amplitudecurve", "amplitudecrv", "amplitudec", "amplitudec", "ampcurve", "ampcrv", "ampc"))
				{
					data.amplitudeCurve = value9;
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
			if (TMPParameterUtility.HasNonAnimCurveParameter(parameters, keywordDatabase, "amplitudecurve", "amplitudecrv", "amplitudec", "amplitudec", "ampcurve", "ampcrv", "ampc"))
			{
				return false;
			}
			return true;
		}
	}
}
