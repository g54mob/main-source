using System;
using UnityEngine;

namespace CritiasFoliage
{
	[Serializable]
	public class FoliageRenderSettings
	{
		[Tooltip("If we should use GPU instancing. If false, no grass will be drawn.")]
		public bool m_DrawInstanced = true;

		[Tooltip("If instancing is disabled each tree will be drawn individually and with light probes based on this setting.")]
		public bool m_UseLightProbes = true;

		[Tooltip("If we allow the usage of 'DrawMeshInstancedIndirect' as set per type in the foliage type inspector. Set to false to globally disable the indirect drawing.")]
		public bool m_AllowDrawInstancedIndirect = true;

		[Tooltip("Global grass density. Does not apply to trees.")]
		[Range(0.1f, 1f)]
		public float m_GrassDensity = 1f;

		[Tooltip("Transform used for the wind. The SpeedTree wind objects are going to be attached to this transform. Defaults to 'Camera.main.transform' if null.")]
		public Transform m_WindTransform;

		[Tooltip("Transform that we are going to use when bending the foliage. Set it to a dummy object at your character's feet.")]
		public Transform m_BendTransform;

		[Tooltip("Camera used for frustum culling. Defaults to 'Camera.main' if it is null.")]
		public Camera m_UsedCameraCulling;

		[Tooltip("Camera used for drawing. Defaults to 'null', that is everything is drawn to all cameras. Recomended option.")]
		public Camera m_UsedCameraDrawing;

		[Tooltip("Layer to use for rendering. Defaults to 'Default'")]
		public string m_UsedLayer = "Default";

		public bool m_ApplyShadowPoppingCorrection = true;

		public float m_ShadowPoppingCorrection = 40f;
	}
}
