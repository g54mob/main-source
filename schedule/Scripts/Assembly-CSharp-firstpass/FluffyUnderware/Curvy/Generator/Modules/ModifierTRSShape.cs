using System;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[ModuleInfo("Modifier/TRS Shape", ModuleName = "TRS Shape", Description = "Transform,Rotate,Scale a Shape")]
	[HelpURL("https://curvyeditor.com/doclink/cgtrsshape")]
	public class ModifierTRSShape : TRSModuleBase, IOnRequestProcessing, IPathProvider
	{
		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGShape) }, Name = "Shape A", ModifiesData = true)]
		public CGModuleInputSlot InShape;

		[HideInInspector]
		[OutputSlotInfo(typeof(CGShape))]
		public CGModuleOutputSlot OutShape;

		public bool PathIsClosed => false;

		public CGData[] OnSlotDataRequest(CGModuleInputSlot requestedBy, CGModuleOutputSlot requestedSlot, params CGDataRequestParameter[] requests)
		{
			return null;
		}
	}
}
