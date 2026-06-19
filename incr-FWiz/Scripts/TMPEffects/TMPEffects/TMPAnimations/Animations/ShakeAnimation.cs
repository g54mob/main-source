using System;
using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new ShakeAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Shake")]
	public class ShakeAnimation : TMPAnimation
	{
		[AutoParametersStorage]
		private class Data
		{
			public bool init;

			public System.Random rng;

			public float yOffset;

			public float xOffset;

			public float lastUpdated;

			public float delay;

			public Dictionary<int, bool> autoUpdateDict;

			public int updatingIndex;

			public float sharedDelay;

			public float sharedLastUpdated;

			public Dictionary<int, Vector2> offsetDict;

			public Dictionary<int, float> lastUpdatedDict;

			public Dictionary<int, float> delayDict;

			public Dictionary<int, System.Random> rngDict;

			public bool uniform;

			public float maxXAmplitude;

			public float minXAmplitude;

			public float maxYAmplitude;

			public float minYAmplitude;

			public bool uniformWait;

			public float minWait;

			public float maxWait;
		}

		[SerializeField]
		[AutoParameter("uniform", new string[] { "uni" })]
		[Tooltip("Whether to apply the shake uniformly across the text.\nAliases: uniform, uni")]
		private bool uniform;

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
		[AutoParameter("uniformwait", new string[] { "uniwait", "uniw" })]
		[Tooltip("Whether to use uniform wait time across the text. Ignored if uniform is true.\nAliases: uniformwait, uniwait, uniw")]
		private bool uniformWait;

		[SerializeField]
		[AutoParameter("minwait", new string[] { "minw" })]
		[Tooltip("The minimum amount of time to wait after each shake.\nAliases: minwait, minw")]
		private float minWait;

		[SerializeField]
		[AutoParameter("maxwait", new string[] { "maxw" })]
		[Tooltip("The maximum amount of time to wait after each shake.\nAliases: maxwait, maxw")]
		private float maxWait;

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

		private void InitAutoUpdateDict(IAnimationContext context)
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
