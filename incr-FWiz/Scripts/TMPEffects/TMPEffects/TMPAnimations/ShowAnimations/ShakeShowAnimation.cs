using System;
using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
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
		private float duration;

		[SerializeField]
		[AutoParameter("maxxamplitude", new string[] { "maxxamp", "maxxa", "maxx" })]
		[Tooltip("The maximum X amplitude of each shake.\nAliases: maxxamplitude, maxxamp, maxxa, maxx")]
		private float maxXAmplitude;

		[SerializeField]
		[AutoParameter("minxamplitude", new string[] { "minxamp", "minxa", "minx" })]
		[Tooltip("The minimum X amplitude of each shake.\nAliases: minxamplitude, minxamp, minxa, minx")]
		private float minXAmplitude;

		[SerializeField]
		[AutoParameter("maxyamplitude", new string[] { "maxyamp", "maxya", "maxy" })]
		[Tooltip("The maximum Y amplitude of each shake.\nAliases: maxyamplitude, maxyamp, maxya, maxy")]
		private float maxYAmplitude;

		[SerializeField]
		[AutoParameter("minyamplitude", new string[] { "minyamp", "minya", "miny" })]
		[Tooltip("The minimum Y amplitude of each shake.\nAliases: minyamplitude, minyamp, minya, miny")]
		private float minYAmplitude;

		[SerializeField]
		[AutoParameter("minwait", new string[] { "minw" })]
		[Tooltip("The minimum amount of time to wait after each shake.\nAliases: minwait, minw")]
		private float minWait;

		[SerializeField]
		[AutoParameter("maxwait", new string[] { "maxw" })]
		[Tooltip("The maximum amount of time to wait after each shake.\nAliases: maxwait, maxw")]
		private float maxWait;

		[SerializeField]
		[AutoParameter("waitcurve", new string[] { "waitcrv", "waitc" })]
		[Tooltip("The curve that defines the falloff of the wait between each shake.\nAliases: waitcurve, waitcrv, waitc")]
		private AnimationCurve waitCurve;

		[SerializeField]
		[AutoParameter("amplitudecurve", new string[] { "amplitudecrv", "amplitudec", "amplitudec", "ampcurve", "ampcrv", "ampc" })]
		[Tooltip("The curve that defines the falloff of the amplitude of each shake.\nAliases: amplitudecurve, amplitudecrv, amplitudec, ampcurve, ampcrv, ampc")]
		private AnimationCurve amplitudeCurve;

		private void InitRNGDict(IAnimationContext context)
		{
		}

		private void InitLastUpdatedDict(IAnimationContext context)
		{
		}

		private void InitDelayDict(IAnimationContext context)
		{
		}

		private void InitOffsetDict(IAnimationContext context)
		{
		}

		private void Animate(CharData cData, Data data, IAnimationContext context)
		{
		}

		public override void Animate(CharData cData, IAnimationContext context)
		{
		}

		public override object GetNewCustomData()
		{
			return null;
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			return false;
		}
	}
}
