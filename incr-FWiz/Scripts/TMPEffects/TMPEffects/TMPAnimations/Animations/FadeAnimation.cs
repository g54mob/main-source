using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new FadeAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Fade")]
	public class FadeAnimation : TMPAnimation
	{
		[AutoParametersStorage]
		private class AutoParametersData
		{
			public readonly float sqrt2;

			public readonly float[] dists;

			public float maxOpacity;

			public Vector3 fadeInAnchor;

			public Vector3 fadeInDirection;

			public float minOpacity;

			public Vector3 fadeOutAnchor;

			public Vector3 fadeOutDirection;

			public Wave wave;

			public OffsetBundle waveOffset;
		}

		[SerializeField]
		[AutoParameterBundle(null)]
		[Tooltip("The wave that defines the behavior of this animation. No prefix.\nFor more information about it, see the section on Waves in the documentation.")]
		private Wave wave;

		[SerializeField]
		[AutoParameterBundle(null)]
		[Tooltip("The timing offsets used by this animation. No prefix.\nFor more information about it, see the section on OffsetProviders in the documentation.")]
		private OffsetBundle waveOffset;

		[SerializeField]
		[AutoParameter("maxopacity", new string[] { "maxop", "max" })]
		[Tooltip("The maximum opacity that is reached.\nAliases: maxopacity, maxop, max")]
		[Range(0f, 255f)]
		private float maxOpacity;

		[SerializeField]
		[AutoParameter("fadeinanchor", new string[] { "fianchor", "fianc", "fia" })]
		[Tooltip("The anchor used for fading in.\nAliases: fadeinanchor, fianchor, fianc, fia")]
		private Vector3 fadeInAnchor;

		[SerializeField]
		[AutoParameter("fadeindirection", new string[] { "fidirection", "fidir", "fid" })]
		[Tooltip("The direction to fade in in.\nAliases: fadeindirection, fidirection, fidir, fid")]
		private Vector3 fadeInDirection;

		[SerializeField]
		[AutoParameter("minopacity", new string[] { "minop", "min" })]
		[Tooltip("The minimum opacity that is reached.\nAliases: minopacity, minop, min")]
		[Range(0f, 255f)]
		private float minOpacity;

		[SerializeField]
		[AutoParameter("fadeoutanchor", new string[] { "foanchor", "foanc", "foa" })]
		[Tooltip("The anchor used for fading out.\nAliases: fadeoutanchor, foanchor, foanc, foa")]
		private Vector3 fadeOutAnchor;

		[SerializeField]
		[AutoParameter("fadeoutdirection", new string[] { "fodirection", "fodir", "fod" })]
		[Tooltip("The direction to fade out in.\nAliases: fadeoutdirection, fodirection, fodir, fod")]
		private Vector3 fadeOutDirection;

		private void FadeIn(CharData cData, IAnimationContext context, AutoParametersData d, float t)
		{
		}

		private void FadeOut(CharData cData, IAnimationContext context, AutoParametersData d, float t)
		{
		}

		private void FixAnchor(ref Vector2 v)
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
