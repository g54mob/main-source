using System;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[ModuleInfo("Debug/VMesh", ModuleName = "Debug VMesh")]
	[HelpURL("https://curvyeditor.com/doclink/cgdebugvmesh")]
	public class DebugVMesh : CGModule
	{
		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGVMesh) }, Name = "VMesh")]
		public CGModuleInputSlot InData;

		[Tab("General")]
		public bool ShowVertices;

		public bool ShowVertexID;

		public bool ShowUV;

		public override void Reset()
		{
		}
	}
}
