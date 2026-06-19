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
		[AutoParameterBundle(null)]
		[Tooltip("The wave that defines the behavior of this animation. No prefix.\nFor more information about it, see the section on Waves in the documentation.")]
		private Wave wave;

		[SerializeField]
		[AutoParameterBundle(null)]
		[Tooltip("The timing offsets used by this animation. No prefix.\nFor more information about it, see the section on OffsetProviders in the documentation.")]
		private OffsetBundle waveOffsetType;

		[SerializeField]
		[AutoParameter("pivot", new string[] { "pv", "p" })]
		[Tooltip("The pivot position of the rotation.\nAliases: pivot, pv, p")]
		private TMPParameterTypes.TypedVector3 pivot;

		[SerializeField]
		[AutoParameter("rotationaxis", new string[] { "axis", "a" })]
		[Tooltip("The axis to rotate around.\nAliases: rotationaxis, axis, a")]
		private Vector3 rotationAxis;

		[SerializeField]
		[AutoParameter("maxangle", new string[] { "maxa", "max" })]
		[Tooltip("The maximum angle of the rotation.\nAliases: maxangle, maxa, max")]
		private float maxAngleLimit;

		[SerializeField]
		[AutoParameter("minangle", new string[] { "mina", "min" })]
		[Tooltip("The minimum angle of the rotation.\nAliases: minangle, mina, min")]
		private float minAngleLimit;

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
