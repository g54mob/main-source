using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

namespace EPOOutline
{
	[VolumeComponentMenu("EPO/Outline")]
	public class OutlineCustomPass : CustomPass
	{
		private List<Outlinable> tempOutlinables;

		private static Queue<OutlineParameters> pool;

		private static Queue<OutlineParameters> parametersInUse;

		private List<Outliner> outliners;

		[SerializeField]
		[HideInInspector]
		private Camera lastSelectedCamera;

		protected override void Execute(CustomPassContext ctx)
		{
		}

		private void UpdateOutliner(ScriptableRenderContext renderContext, CommandBuffer cmd, Camera camera, Outliner outlineEffect, HDCamera hdCamera, RTHandle colorTarget, RTHandle depthTarget)
		{
		}
	}
}
