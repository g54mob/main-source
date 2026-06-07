using UnityEngine;
using UnityEngine.Rendering;

namespace UMA
{
	public class UMARendererAsset : ScriptableObject
	{
		[Tooltip("The name that will be given to the object that this renderer will be added to.")]
		[SerializeField]
		private string _RendererName;

		[Tooltip("This is the layer that the renderer object will be set to.")]
		[SerializeField]
		private int _Layer;

		[SerializeField]
		private uint _RendererLayerMask;

		[SerializeField]
		private int _RendererPriority;

		[SerializeField]
		private bool _UpdateWhenOffscreen;

		[SerializeField]
		private bool _SkinnedMotionVectors;

		[SerializeField]
		private MotionVectorGenerationMode _MotionVectors;

		[SerializeField]
		private bool _DynamicOccluded;

		[Header("Lighting")]
		[SerializeField]
		private ShadowCastingMode _CastShadows;

		[SerializeField]
		private bool _ReceiveShadows;

		[Header("Cloth")]
		[Tooltip("The cloth properties asset to apply to this renderer. Use this only if planning to use the cloth component with this material.")]
		[SerializeField]
		private UMAClothProperties _ClothProperties;

		[Header("Build Options")]
		[Tooltip("If true, the normals will be recalculated on the mesh when it is created. Requires BURST option in preferences.")]
		[SerializeField]
		private bool _RecalculateNormals;

		[Tooltip("The angle to use when recalculating normals.")]
		[SerializeField]
		private float _NormalAngle;

		public string RendererName => null;

		public int Layer => 0;

		public uint RendererLayerMask => 0u;

		public int RendererPriority => 0;

		public bool UpdateWhenOffscreen => false;

		public bool SkinnedMotionVectors => false;

		public MotionVectorGenerationMode MotionVectors => default(MotionVectorGenerationMode);

		public bool DynamicOccluded => false;

		public ShadowCastingMode CastShadows => default(ShadowCastingMode);

		public bool ReceiveShadows => false;

		public UMAClothProperties ClothProperties => null;

		public bool RecalculateNormals => false;

		public float NormalAngle => 0f;

		public void ApplySettingsToRenderer(SkinnedMeshRenderer smr)
		{
		}

		public static void ResetRenderer(SkinnedMeshRenderer renderer)
		{
		}
	}
}
