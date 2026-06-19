using System.Collections.Generic;
using TMPEffects.AutoParameters.Attributes;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	[AutoParameters]
	[CreateAssetMenu(fileName = "new SketchyAnimation", menuName = "TMPEffects/Animations/Basic Animations/Built-in/Sketchy")]
	public class SketchyAnimation : TMPAnimation
	{
		[AutoParametersStorage]
		private class AnimData
		{
			public Dictionary<int, ModData> modDatas;

			public Dictionary<int, float> lastUpdate;

			public float delayTime;

			public Vector3 minOffset;

			public Vector3 maxOffset;

			public Vector3 minRotation;

			public Vector3 maxRotation;

			public Vector3 minScale;

			public Vector3 maxScale;

			public Vector3 minColorShift;

			public Vector3 maxColorShift;
		}

		private struct ModData
		{
			public Vector3 rotation;

			public Vector3 scale;

			public Vector3 offset;

			public Vector3 colorshift;
		}

		[AutoParameter("delay", new string[] { "d" })]
		[SerializeField]
		[Tooltip("The delay between each change, in seconds.\nAliases: delay, d")]
		private float delayTime;

		[AutoParameter("minoffset", new string[] { "minoff" })]
		[SerializeField]
		[Tooltip("The min offset from the original position.\nAliases: minoffset, minoff")]
		private Vector3 minOffset;

		[AutoParameter("maxoffset", new string[] { "maxoff" })]
		[SerializeField]
		[Tooltip("The max offset from the original position.\nAliases: maxoffset, maxoff")]
		private Vector3 maxOffset;

		[AutoParameter("minrotation", new string[] { "minrot" })]
		[SerializeField]
		[Tooltip("The min rotation, in euler angles.\nAliases: minrotation, minrot")]
		private Vector3 minRotation;

		[AutoParameter("maxrotation", new string[] { "maxrot" })]
		[SerializeField]
		[Tooltip("The max rotation, in euler angles.\nAliases: maxrotation, maxrot")]
		private Vector3 maxRotation;

		[AutoParameter("minscale", new string[] { "minscl" })]
		[SerializeField]
		[Tooltip("The min scale.\nAliases: minscale, minscl")]
		private Vector3 minScale;

		[AutoParameter("maxscale", new string[] { "maxscl" })]
		[SerializeField]
		[Tooltip("The max scale.\nAliases: maxscale, maxscl")]
		private Vector3 maxScale;

		[AutoParameter("mincolorshift", new string[] { "minclrshift", "minclr" })]
		[SerializeField]
		[Tooltip("The min color shift, RGB.\nAliases: mincolorshift, minclrshift, minclr")]
		private Vector3 minColorShift;

		[AutoParameter("maxcolorshift", new string[] { "maxclrshift", "maxclr" })]
		[SerializeField]
		[Tooltip("The max color shift, RGB.\nAliases: maxcolorshift, maxclrshift, maxclr")]
		private Vector3 maxColorShift;

		private void Animate(CharData cData, AnimData data, IAnimationContext context)
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
