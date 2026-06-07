using System;
using Assets.Scripts.Craft.MeshGen;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using UnityEngine;

namespace Assets.Scripts.Craft.Wings
{
	public struct WingBuilderInput
	{
		public delegate ProceduralPartMeshRenderer[] GetPartMeshRenderersDelegate(int number, int? controlSurfaceIndex);

		public GetPartMeshRenderersDelegate getPartMeshRenderers;

		public InputWingSlice[] inputSlices;

		public ControlSurface[] surfaces;

		public bool flipped;

		public Transform parent;

		public Transform[] surfaceParentTransforms;

		public Action<MeshRenderer, int> onCreateRenderer;

		public Action<MeshRenderer> onDestroyRenderer;

		public WingTipStyle WingtipStyle;

		public Vector3 MainMeshUV;

		public Vector3[] ControlSurfaceUVs;

		public WingDebugInfo DebugCollector;

		public bool HideMainMesh;

		public bool ThrowOnValidationFail;
	}
}
