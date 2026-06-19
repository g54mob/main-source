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
		private TMPParameterTypes.TypedVector3 pivot;

		[SerializeField]
		[AutoParameter("rotationaxis", new string[] { "axis", "a" })]
		[Tooltip("The axis to rotate around.\nAliases: rotationaxis, axis, a")]
		private Vector3 rotationAxis;

		private void Animate(CharData cData, AutoParametersData data, IAnimationContext context)
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
