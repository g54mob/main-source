using System;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[ModuleInfo("Modifier/Path Relative Translation", ModuleName = "Path Relative Translation", Description = "Translates a path relatively to it's direction, instead of relatively to the world as does the TRS Path module.")]
	[HelpURL("https://curvyeditor.com/doclink/cgpathrelativetranslation")]
	public class ModifierPathRelativeTranslation : CGModule, IOnRequestProcessing, IPathProvider
	{
		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGPath) }, Name = "Path A", ModifiesData = true)]
		public CGModuleInputSlot InPath;

		[HideInInspector]
		[OutputSlotInfo(typeof(CGPath))]
		public CGModuleOutputSlot OutPath;

		[SerializeField]
		[Tooltip("The (base) translation distance")]
		[Label("Translation", null)]
		private float lateralTranslation;

		[AnimationCurveEx("    Multiplier", null)]
		[Tooltip("Defines translation multiplier, depending on the Relative Distance (between 0 and 1) of a point on the path")]
		[SerializeField]
		private AnimationCurve multiplier;

		[Tooltip("The translation angle, in degrees")]
		[SerializeField]
		private float angle;

		public float LateralTranslation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Angle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public AnimationCurve Multiplier
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool PathIsClosed => false;

		public CGData[] OnSlotDataRequest(CGModuleInputSlot requestedBy, CGModuleOutputSlot requestedSlot, params CGDataRequestParameter[] requests)
		{
			return null;
		}

		private static void TranslatePoint(int index, CGPath data, bool evaluateTranslationMultiplier, float translation, AnimationCurve translationMultiplier, float angle)
		{
		}

		protected override void OnEnable()
		{
		}

		public override void Reset()
		{
		}

		protected override void OnValidate()
		{
		}
	}
}
