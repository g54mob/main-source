using System;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[HelpURL("https://curvyeditor.com/doclink/cgdebugrasterizedpath")]
	[ModuleInfo("Debug/Rasterized Path", ModuleName = "Debug Rasterized Path", Description = "Shows the tangents and orientation of a rasterized path")]
	public class DebugRasterizedPath : CGModule
	{
		[HideInInspector]
		[InputSlotInfo(new Type[] { typeof(CGPath) }, DisplayName = "Rasterized Path")]
		public CGModuleInputSlot InPath;

		[Tooltip("Display the normal at each one of the path's points")]
		public bool ShowNormals;

		[Tooltip("Display the orientation at each one of the path's points")]
		public bool ShowOrientation;

		public override void Reset()
		{
		}
	}
}
