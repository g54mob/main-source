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
		[AutoParameterBundle(null)]
		[Tooltip("The wave that defines the behavior of this animation. No prefix.\nFor more information about it, see the section on Waves in the documentation.")]
		private Wave wave;

		[SerializeField]
		[AutoParameterBundle(null)]
		[Tooltip("The timing offsets used by this animation. No prefix.\nFor more information about it, see the section on OffsetProviders in the documentation.")]
		private OffsetBundle waveOffsetType;

		[SerializeField]
		[AutoParameter("growanchor", new string[] { "growanc", "ganc" })]
		[Tooltip("The anchor used for growing.\nAliases: growanchor, growanc, ganc")]
		private TMPParameterTypes.TypedVector3 growAnchor;

		[SerializeField]
		[AutoParameter("growdirection", new string[] { "growdir", "gdir" })]
		[Tooltip("The direction used for growing.\nAliases: growdirection, growdir, gdir")]
		private Vector3 growDirection;

		[SerializeField]
		[AutoParameter("shrinkanchor", new string[] { "shrinkanc", "sanc" })]
		[Tooltip("The anchor used for shrinking.\nAliases: shrinkanchor, shrinkanc, sanc")]
		private TMPParameterTypes.TypedVector3 shrinkAnchor;

		[SerializeField]
		[AutoParameter("shrinkdirection", new string[] { "shrinkdir", "sdir" })]
		[Tooltip("The direction used for shrinking.\nAliases: shrinkdirection, shrinkdir, sdir")]
		private Vector3 shrinkDirection;

		[SerializeField]
		[AutoParameter("maxpercentage", new string[] { "maxp", "max" })]
		[Tooltip("The maximum percentage to spread to, at 1 being completely shown.\nAliases: maxpercentage, maxp, max")]
		private float maxPercentage;

		[SerializeField]
		[AutoParameter("minpercentage", new string[] { "minp", "min" })]
		[Tooltip("The minimum percentage to unspread to, at 0 being completely hidden.\nAliases: minpercentage, minp, min")]
		private float minPercentage;

		private void Grow(CharData cData, IAnimationContext context, AutoParametersData d, float t)
		{
		}

		private void Shrink(CharData cData, IAnimationContext context, AutoParametersData d, float t)
		{
		}

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
