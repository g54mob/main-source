using System;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[ModuleInfo("Modifier/TRS Shape", ModuleName = "TRS Shape", Description = "Transform,Rotate,Scale a Shape")]
	[HelpURL("https://curvyeditor.com/doclink/cgtrsshape")]
	public class ModifierTRSShape : TRSModuleBase, IOnRequestProcessing, IPathProvider
	{
		[InputSlotInfo(new Type[] { typeof(CGShape) }, Name = "Shape A", ModifiesData = true)]
		[HideInInspector]
		public CGModuleInputSlot InShape;

		[OutputSlotInfo(typeof(CGShape))]
		[HideInInspector]
		public CGModuleOutputSlot OutShape;

		public bool PathIsClosed => false;

		public CGData[] OnSlotDataRequest(CGModuleInputSlot requestedBy, CGModuleOutputSlot requestedSlot, params CGDataRequestParameter[] requests)
		{
			return null;
		}
	}
}
