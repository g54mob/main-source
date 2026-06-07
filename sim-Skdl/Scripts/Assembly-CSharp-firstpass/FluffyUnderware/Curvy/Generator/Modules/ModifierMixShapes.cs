using System;
using System.Collections.Generic;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[ModuleInfo("Modifier/Mix Shapes", ModuleName = "Mix Shapes", Description = "Interpolates between two shapes")]
	[HelpURL("https://curvyeditor.com/doclink/cgmixshapes")]
	public class ModifierMixShapes : CGModule, IOnRequestProcessing, IPathProvider
	{
		private const int MixMinValue = -1;

		private const int MixMaxValue = 1;

		[InputSlotInfo(new Type[] { typeof(CGShape) }, Name = "Shape A")]
		[HideInInspector]
		public CGModuleInputSlot InShapeA;

		[InputSlotInfo(new Type[] { typeof(CGShape) }, Name = "Shape B")]
		[HideInInspector]
		public CGModuleInputSlot InShapeB;

		[OutputSlotInfo(typeof(CGShape))]
		[HideInInspector]
		public CGModuleOutputSlot OutShape;

		[RangeEx(-1f, 1f, null, null, Tooltip = "Mix between the shapes. Values between -1 for Shape A and 1 for Shape B")]
		[SerializeField]
		private float m_Mix;

		public float Mix
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool PathIsClosed => false;

		protected override void OnEnable()
		{
		}

		public override void Reset()
		{
		}

		public CGData[] OnSlotDataRequest(CGModuleInputSlot requestedBy, CGModuleOutputSlot requestedSlot, params CGDataRequestParameter[] requests)
		{
			return null;
		}

		[CanBeNull]
		public static CGShape MixShapes([CanBeNull] CGShape shapeA, [CanBeNull] CGShape shapeB, float mix, [NotNull] List<string> warningsContainer, bool ignoreWarnings = false)
		{
			return null;
		}

		public static void InterpolateShape([NotNull] CGShape resultShape, CGShape shapeA, CGShape shapeB, float mix, [NotNull] List<string> warningsContainer, bool ignoreWarnings = false)
		{
		}
	}
}
