using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new ContPivotAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/ContPivot")]
	public class ContPivotAnimation : TMPAnimation
	{
		private class AutoParametersData
		{
			public float speed;

			public TMPParameterTypes.TypedVector3 pivot;

			public Vector3 rotationAxis;
		}

		[SerializeField]
		[AutoParameter("speed", new string[] { "sp", "s" })]
		[Tooltip("The speed of the rotation, in rotations per second.\nAliased: speed, sp, s")]
		private float speed;

		[SerializeField]
		[AutoParameter("pivot", new string[] { "pv", "p" })]
		[Tooltip("The pivot position of the rotation.\nAliases: pivot, pv, p")]
		private TMPParameterTypes.TypedVector3 pivot = new TMPParameterTypes.TypedVector3(TMPParameterTypes.VectorType.Anchor, Vector3.zero);

		[SerializeField]
		[AutoParameter("rotationaxis", new string[] { "axis", "a" })]
		[Tooltip("The axis to rotate around.\nAliases: rotationaxis, axis, a")]
		private Vector3 rotationAxis = Vector3.right;

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
		{
			float angle = context.AnimatorContext.PassedTime * data.speed * 360f % 360f;
			cData.AddRotation(Quaternion.AngleAxis(angle, data.rotationAxis).eulerAngles, data.pivot.ToPosition(cData, context));
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
				speed = speed,
				pivot = pivot,
				rotationAxis = rotationAxis
			};
		}

		public override void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters != null)
			{
				AutoParametersData autoParametersData = (AutoParametersData)customData;
				if (TMPParameterUtility.TryGetFloatParameter(out var value, parameters, keywordDatabase, "speed", "sp", "s"))
				{
					autoParametersData.speed = value;
				}
				if (TMPParameterUtility.TryGetTypedVector3Parameter(out var value2, parameters, keywordDatabase, "pivot", "pv", "p"))
				{
					autoParametersData.pivot = value2;
				}
				if (TMPParameterUtility.TryGetVector3Parameter(out var value3, parameters, keywordDatabase, "rotationaxis", "axis", "a"))
				{
					autoParametersData.rotationAxis = value3;
				}
			}
		}

		public override bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return true;
			}
			if (TMPParameterUtility.HasNonFloatParameter(parameters, keywordDatabase, "speed", "sp", "s"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonTypedVector3Parameter(parameters, keywordDatabase, "pivot", "pv", "p"))
			{
				return false;
			}
			if (TMPParameterUtility.HasNonVector3Parameter(parameters, keywordDatabase, "rotationaxis", "axis", "a"))
			{
				return false;
			}
			return true;
		}
	}
}
