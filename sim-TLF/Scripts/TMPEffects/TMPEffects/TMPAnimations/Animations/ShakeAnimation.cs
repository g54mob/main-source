using System;
using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
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

			public int updatingIndex = -1;

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
		[AutoParameter("uniformwait", new string[] { "uniwait", "uniw" })]
		[Tooltip("Whether to use uniform wait time across the text. Ignored if uniform is true.\nAliases: uniformwait, uniwait, uniw")]
		private bool uniformWait = true;

		[SerializeField]
		[AutoParameter("minwait", new string[] { "minw" })]
		[Tooltip("The minimum amount of time to wait after each shake.\nAliases: minwait, minw")]
		private float minWait = 0.1f;

		[SerializeField]
		[AutoParameter("maxwait", new string[] { "maxw" })]
		[Tooltip("The maximum amount of time to wait after each shake.\nAliases: maxwait, maxw")]
		private float maxWait = 0.1f;

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

		private void InitAutoUpdateDict(IAnimationContext context)
		{
			Data data = context.CustomData as Data;
			data.autoUpdateDict = new Dictionary<int, bool>(context.SegmentData.Length);
			for (int i = 0; i < context.SegmentData.Length; i++)
			{
				data.autoUpdateDict.Add(i, value: false);
			}
		}

		private void Animate(CharData cData, Data data, IAnimationContext context)
		{
			if (!data.init)
			{
				data.init = true;
				if (!data.uniform)
				{
					InitRNGDict(context);
					InitLastUpdatedDict(context);
					InitDelayDict(context);
					InitOffsetDict(context);
					if (data.uniformWait)
					{
						InitAutoUpdateDict(context);
					}
				}
				else
				{
					data.rng = new System.Random((int)(Time.time * 1000f));
				}
			}
			Vector3 vector;
			if (data.uniform)
			{
				if (context.AnimatorContext.PassedTime - data.lastUpdated >= data.delay)
				{
					float num = ((data.maxXAmplitude == data.minXAmplitude) ? data.maxXAmplitude : Mathf.Lerp(data.minXAmplitude, data.maxXAmplitude, (float)data.rng.NextDouble()));
					float num2 = ((data.maxYAmplitude == data.minYAmplitude) ? data.maxYAmplitude : Mathf.Lerp(data.minYAmplitude, data.maxYAmplitude, (float)data.rng.NextDouble()));
					data.delay = ((data.maxWait == data.minWait) ? data.maxWait : Mathf.Lerp(data.minWait, data.maxWait, (float)data.rng.NextDouble()));
					data.lastUpdated = context.AnimatorContext.PassedTime;
					data.xOffset = ((float)data.rng.NextDouble() * 2f - 1f) * num;
					data.yOffset = ((float)data.rng.NextDouble() * 2f - 1f) * num2;
				}
				vector = new Vector3(data.xOffset, data.yOffset, 0f);
			}
			else if (data.uniformWait)
			{
				int num3 = context.SegmentData.SegmentIndexOf(cData);
				if (data.autoUpdateDict[num3] || context.AnimatorContext.PassedTime - data.sharedLastUpdated >= data.sharedDelay)
				{
					float num4 = ((data.maxXAmplitude == data.minXAmplitude) ? data.maxXAmplitude : Mathf.Lerp(data.minXAmplitude, data.maxXAmplitude, (float)data.rngDict[num3].NextDouble()));
					float num5 = ((data.maxYAmplitude == data.minYAmplitude) ? data.maxYAmplitude : Mathf.Lerp(data.minYAmplitude, data.maxYAmplitude, (float)data.rngDict[num3].NextDouble()));
					if (data.autoUpdateDict[num3])
					{
						data.autoUpdateDict[num3] = false;
					}
					else
					{
						data.sharedDelay = ((data.maxWait == data.minWait) ? data.maxWait : Mathf.Lerp(data.minWait, data.maxWait, (float)data.rngDict[num3].NextDouble()));
						data.sharedLastUpdated = context.AnimatorContext.PassedTime;
						for (int i = 0; i < context.SegmentData.Length; i++)
						{
							if (i != num3)
							{
								data.autoUpdateDict[i] = true;
							}
						}
					}
					float x = ((float)data.rngDict[num3].NextDouble() * 2f - 1f) * num4;
					float y = ((float)data.rngDict[num3].NextDouble() * 2f - 1f) * num5;
					data.offsetDict[num3] = new Vector3(x, y, 0f);
				}
				vector = data.offsetDict[num3];
			}
			else
			{
				int key = context.SegmentData.SegmentIndexOf(cData);
				if (context.AnimatorContext.PassedTime - data.lastUpdatedDict[key] >= data.delayDict[key])
				{
					float num6 = ((data.maxXAmplitude == data.minXAmplitude) ? data.maxXAmplitude : Mathf.Lerp(data.minXAmplitude, data.maxXAmplitude, (float)data.rngDict[key].NextDouble()));
					float num7 = ((data.maxYAmplitude == data.minYAmplitude) ? data.maxYAmplitude : Mathf.Lerp(data.minYAmplitude, data.maxYAmplitude, (float)data.rngDict[key].NextDouble()));
					data.delayDict[key] = ((data.maxWait == data.minWait) ? data.maxWait : Mathf.Lerp(data.minWait, data.maxWait, (float)data.rngDict[key].NextDouble()));
					data.lastUpdatedDict[key] = context.AnimatorContext.PassedTime;
					float x2 = ((float)data.rngDict[key].NextDouble() * 2f - 1f) * num6;
					float y2 = ((float)data.rngDict[key].NextDouble() * 2f - 1f) * num7;
					data.offsetDict[key] = new Vector3(x2, y2, 0f);
				}
				vector = data.offsetDict[key];
			}
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
				uniform = uniform,
				maxXAmplitude = maxXAmplitude,
				minXAmplitude = minXAmplitude,
				maxYAmplitude = maxYAmplitude,
				minYAmplitude = minYAmplitude,
				uniformWait = uniformWait,
				minWait = minWait,
				maxWait = maxWait
			};
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				Data data = (Data)customData;
				if (TMPParameterUtility.TryGetBoolParameter(out var value, parameters, keywordDatabase, "uniform", "uni"))
				{
					data.uniform = value;
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
				if (TMPParameterUtility.TryGetBoolParameter(out var value6, parameters, keywordDatabase, "uniformwait", "uniwait", "uniw"))
				{
					data.uniformWait = value6;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value7, parameters, keywordDatabase, "minwait", "minw"))
				{
					data.minWait = value7;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value8, parameters, keywordDatabase, "maxwait", "maxw"))
				{
					data.maxWait = value8;
				}
			}
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return true;
			}
			if (TMPParameterUtility.HasNonBoolParameter(parameters, keywordDatabase, "uniform", "uni"))
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
			if (TMPParameterUtility.HasNonBoolParameter(parameters, keywordDatabase, "uniformwait", "uniwait", "uniw"))
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
			return true;
		}
	}
}
