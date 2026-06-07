using System;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("https://curvyeditor.com/doclink/cgtrsmesh")]
	[ModuleInfo("Modifier/TRS Mesh", ModuleName = "TRS Mesh", Description = "Transform,Rotate,Scale a VMesh")]
	public class ModifierTRSMesh : TRSModuleBase
	{
		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGVMesh) }, Array = true, ModifiesData = true)]
		public CGModuleInputSlot InVMesh;

		[OutputSlotInfo(typeof(CGVMesh), Array = true)]
		[HideInInspector]
		public CGModuleOutputSlot OutVMesh;

		public override void Refresh()
		{
		}
	}
}
