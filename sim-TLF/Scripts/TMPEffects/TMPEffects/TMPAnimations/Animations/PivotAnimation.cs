using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new PivotAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Pivot")]
	public class PivotAnimation : TMPAnimation
	{
		private class AutoParametersData
		{
			public TMPParameterTypes.TypedVector3 pivot;

			public Vector3 rotationAxis;

			public float maxAngleLimit;

			public float minAngleLimit;

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
		[AutoParameter("pivot", new string[] { "pv", "p" })]
		[Tooltip("The pivot position of the rotation.\nAliases: pivot, pv, p")]
		private TMPParameterTypes.TypedVector3 pivot = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Anchor, Vector3.zero);

		[SerializeField]
		[AutoParameter("rotationaxis", new string[] { "axis", "a" })]
		[Tooltip("The axis to rotate around.\nAliases: rotationaxis, axis, a")]
		private Vector3 rotationAxis = Vector3.right;

		[SerializeField]
		[AutoParameter("maxangle", new string[] { "maxa", "max" })]
		[Tooltip("The maximum angle of the rotation.\nAliases: maxangle, maxa, max")]
		private float maxAngleLimit = 180f;

		[SerializeField]
		[AutoParameter("minangle", new string[] { "mina", "min" })]
		[Tooltip("The minimum angle of the rotation.\nAliases: minangle, mina, min")]
		private float minAngleLimit = -180f;

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			(float, int) tuple = data.wave.Evaluate(context.AnimatorContext.PassedTime, data.waveOffsetType.GetOffset(cData, context));
			float angle = Mathf.LerpUnclamped(data.minAngleLimit, data.maxAngleLimit, tuple.Item1);
			cData.AddRotation(TMPAnimationUtility.NormalizeEulerAngles(Quaternion.AngleAxis(angle, data.rotationAxis).eulerAngles), data.pivot.ToPosition(cData, context));
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
				pivot = pivot,
				rotationAxis = rotationAxis,
				maxAngleLimit = maxAngleLimit,
				minAngleLimit = minAngleLimit,
				wave = wave,
				waveOffsetType = waveOffsetType
			};
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				AutoParametersData autoParametersData = (AutoParametersData)customData;
				if (TMPParameterUtility.TryGetTypedVector3Parameter(out var value, parameters, keywordDatabase, "pivot", "pv", "p"))
				{
					autoParametersData.pivot = value;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value2, parameters, keywordDatabase, "rotationaxis", "axis", "a"))
				{
					autoParametersData.rotationAxis = value2;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value3, parameters, keywordDatabase, "maxangle", "maxa", "max"))
				{
					autoParametersData.maxAngleLimit = value3;
				}
				if (TMPParameterUtility.TryGetFloatParameter(out var value4, parameters, keywordDatabase, "minangle", "mina", "min"))
				{
					autoParametersData.minAngleLimit = value4;
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
			if (TMPParameterUtility.HasNonTypedVector3Parameter(parameters, keywordDatabase, "pivot", "pv", "p"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "rotationaxis", "axis", "a"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "maxangle", "maxa", "max"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "minangle", "mina", "min"))
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
