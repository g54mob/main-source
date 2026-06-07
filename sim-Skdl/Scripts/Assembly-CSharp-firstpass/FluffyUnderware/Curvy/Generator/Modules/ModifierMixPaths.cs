using System;
using System.Collections.Generic;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[ModuleInfo("Modifier/Mix Paths", ModuleName = "Mix Paths", Description = "Interpolates between two paths")]
	[HelpURL("https://curvyeditor.com/doclink/cgmixpaths")]
	public class ModifierMixPaths : CGModule, IOnRequestProcessing, IPathProvider
	{
		private const int MixMinValue = -1;

		private const int MixMaxValue = 1;

		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGPath) }, Name = "Path A")]
		public CGModuleInputSlot InPathA;

		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGPath) }, Name = "Path B")]
		public CGModuleInputSlot InPathB;

		[OutputSlotInfo(typeof(CGPath))]
		[HideInInspector]
		public CGModuleOutputSlot OutPath;

		[RangeEx(-1f, 1f, null, null, Tooltip = "Mix between the paths. Values between -1 for Path A and 1 for Path B")]
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
		public static CGPath MixPath([CanBeNull] CGPath pathA, [CanBeNull] CGPath pathB, float mix, [NotNull] List<string> warningsContainer)
		{
			return null;
		}
	}
}
