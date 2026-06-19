using System;
using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.ShowAnimations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new SpreadAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Spread")]
	public class SpreadAnimation : TMPAnimation
	{
		private class AutoParametersData
		{
			public TMPParameterTypes.TypedVector3 growAnchor;

			public Vector3 growDirection;

			public TMPParameterTypes.TypedVector3 shrinkAnchor;

			public Vector3 shrinkDirection;

			public float maxPercentage;

			public float minPercentage;

			public Wave wave;

			public OffsetBundle waveOffsetType;
		}

		[SerializeField]
		[AutoParameterBundle("")]
		[Tooltip("The wave that defines the behavior of this animation. No prefix.\nFor more information about it, see the section on Waves in the documentation.")]
		private Wave wave;

		[SerializeField]
		[AutoParameterBundle("")]
		[Tooltip("The timing offsets used by this animation. No prefix.\nFor more information about it, see the section on OffsetProviders in the documentation.")]
		private OffsetBundle waveOffsetType;

		[SerializeField]
		[AutoParameter("growanchor", new string[] { "growanc", "ganc" })]
		[Tooltip("The anchor used for growing.\nAliases: growanchor, growanc, ganc")]
		private TMPParameterTypes.TypedVector3 growAnchor = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Anchor, Vector3.zero);

		[SerializeField]
		[AutoParameter("growdirection", new string[] { "growdir", "gdir" })]
		[Tooltip("The direction used for growing.\nAliases: growdirection, growdir, gdir")]
		private Vector3 growDirection = Vector3.up;

		[SerializeField]
		[AutoParameter("shrinkanchor", new string[] { "shrinkanc", "sanc" })]
		[Tooltip("The anchor used for shrinking.\nAliases: shrinkanchor, shrinkanc, sanc")]
		private TMPParameterTypes.TypedVector3 shrinkAnchor = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Anchor, Vector3.zero);

		[SerializeField]
		[AutoParameter("shrinkdirection", new string[] { "shrinkdir", "sdir" })]
		[Tooltip("The direction used for shrinking.\nAliases: shrinkdirection, shrinkdir, sdir")]
		private Vector3 shrinkDirection = Vector3.up;

		[SerializeField]
		[AutoParameter("maxpercentage", new string[] { "maxp", "max" })]
		[Tooltip("The maximum percentage to spread to, at 1 being completely shown.\nAliases: maxpercentage, maxp, max")]
		private float maxPercentage = 1f;

		[SerializeField]
		[AutoParameter("minpercentage", new string[] { "minp", "min" })]
		[Tooltip("The minimum percentage to unspread to, at 0 being completely hidden.\nAliases: minpercentage, minp, min")]
		private float minPercentage;

		private void Grow(CharData cData, IAnimationContext context, AutoParametersData d, float t)
		{
			float t2 = Mathf.LerpUnclamped(d.minPercentage, d.maxPercentage, t);
			Vector3 vector = new Vector3(0f - d.growDirection.y, d.growDirection.x, 0f);
			Vector3 lineStart;
			Vector3 lineEnd;
			switch (d.growAnchor.type)
			{
			case TMPParameterTypes.VectorType.Offset:
				lineStart = cData.InitialPosition + (d.growAnchor.vector - vector * 2f);
				lineEnd = cData.InitialPosition + (d.growAnchor.vector + vector * 2f);
				break;
			case TMPParameterTypes.VectorType.Anchor:
				lineStart = TMPAnimationUtility.AnchorToPosition(d.growAnchor.vector - vector * 2f, cData);
				lineEnd = TMPAnimationUtility.AnchorToPosition(d.growAnchor.vector + vector * 2f, cData);
				break;
			case TMPParameterTypes.VectorType.Position:
				lineStart = d.growAnchor.vector - vector * 2f;
				lineEnd = d.growAnchor.vector + vector * 2f;
				break;
			default:
				throw new NotImplementedException("type");
			}
			for (int i = 0; i < 4; i++)
			{
				Vector3 position = Vector3.LerpUnclamped(TMPAnimationUtility.ClosestPointOnLine(lineStart, lineEnd, cData.mesh.initial.GetPosition(i)), cData.mesh.initial.GetPosition(i), t2);
				TMPAnimationUtility.SetVertexRaw(i, position, cData, context);
			}
		}

		private void Shrink(CharData cData, IAnimationContext context, AutoParametersData d, float t)
		{
			float t2 = Mathf.LerpUnclamped(d.minPercentage, d.maxPercentage, t);
			Vector3 vector = new Vector3(0f - d.shrinkDirection.y, d.shrinkDirection.x, 0f);
			Vector3 lineStart;
			Vector3 lineEnd;
			switch (d.shrinkAnchor.type)
			{
			case TMPParameterTypes.VectorType.Offset:
				lineStart = cData.InitialPosition + (d.shrinkAnchor.vector - vector * 2f);
				lineEnd = cData.InitialPosition + (d.shrinkAnchor.vector + vector * 2f);
				break;
			case TMPParameterTypes.VectorType.Anchor:
				lineStart = TMPAnimationUtility.AnchorToPosition(d.shrinkAnchor.vector - vector * 2f, cData);
				lineEnd = TMPAnimationUtility.AnchorToPosition(d.shrinkAnchor.vector + vector * 2f, cData);
				break;
			case TMPParameterTypes.VectorType.Position:
				lineStart = d.shrinkAnchor.vector - vector * 2f;
				lineEnd = d.shrinkAnchor.vector + vector * 2f;
				break;
			default:
				throw new NotImplementedException("type");
			}
			for (int i = 0; i < 4; i++)
			{
				Vector3 position = Vector3.LerpUnclamped(TMPAnimationUtility.ClosestPointOnLine(lineStart, lineEnd, cData.mesh.initial.GetPosition(i)), cData.mesh.initial.GetPosition(i), t2);
				TMPAnimationUtility.SetVertexRaw(i, position, cData, context);
			}
		}

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			(float, int) tuple = data.wave.Evaluate(context.AnimatorContext.PassedTime, data.waveOffsetType.GetOffset(cData, context));
			if (tuple.Item2 > 0)
			{
				Grow(cData, context, data, tuple.Item1);
			}
			else
			{
				Shrink(cData, context, data, tuple.Item1);
			}
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
				growAnchor = growAnchor,
				growDirection = growDirection,
				shrinkAnchor = shrinkAnchor,
				shrinkDirection = shrinkDirection,
				maxPercentage = maxPercentage,
				minPercentage = minPercentage,
				wave = wave,
				waveOffsetType = waveOffsetType
			};
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				AutoParametersData autoParametersData = (AutoParametersData)customData;
				if (TMPParameterUtility.TryGetTypedVector3Parameter(out var value, parameters, keywordDatabase, "growanchor", "growanc", "ganc"))
				{
					autoParametersData.growAnchor = value;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value2, parameters, keywordDatabase, "growdirection", "growdir", "gdir"))
				{
					autoParametersData.growDirection = value2;
				}
				if (TMPParameterUtility.TryGetTypedVector3Parameter(out var value3, parameters, keywordDatabase, "shrinkanchor", "shrinkanc", "sanc"))
				{
					autoParametersData.shrinkAnchor = value3;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value4, parameters, keywordDatabase, "shrinkdirection", "shrinkdir", "sdir"))
				{
					autoParametersData.shrinkDirection = value4;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value5, parameters, keywordDatabase, "maxpercentage", "maxp", "max"))
				{
					autoParametersData.maxPercentage = value5;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value6, parameters, keywordDatabase, "minpercentage", "minp", "min"))
				{
					autoParametersData.minPercentage = value6;
				}
				autoParametersData.wave = Wave.CreateWave(autoParametersData.wave, Wave.GetWaveParameters(parameters, keywordDatabase));
				autoParametersData.waveOffsetType = OffsetBundle.CreateOffsetBundle(autoParametersData.waveOffsetType, OffsetBundle.GetOffsetBundleParameters(parameters, keywordDatabase));
			}
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return true;
			}
			if (TMPParameterUtility.HasNonTypedVector3Parameter(parameters, keywordDatabase, "growanchor", "growanc", "ganc"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "growdirection", "growdir", "gdir"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonTypedVector3Parameter(parameters, keywordDatabase, "shrinkanchor", "shrinkanc", "sanc"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "shrinkdirection", "shrinkdir", "sdir"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "maxpercentage", "maxp", "max"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "minpercentage", "minp", "min"))
			{
				return false;
			}
			if (!Wave.ValidateWaveParameters(parameters, keywordDatabase))
			{
				return false;
			}
			if (!OffsetBundle.ValidateOffsetBundleParameters(parameters, keywordDatabase))
			{
				return false;
			}
			return true;
		}
	}
}
