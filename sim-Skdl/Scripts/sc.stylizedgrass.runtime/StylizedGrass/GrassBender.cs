using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace StylizedGrass
{
	[HelpURL("http://staggart.xyz/unity/stylized-grass-shader/sgs-docs/?section=using-grass-bending")]
	[AddComponentMenu("Stylized Grass/Grass Bender")]
	[ExecuteInEditMode]
	public class GrassBender : MonoBehaviour
	{
		[Tooltip("Higher layers are always drawn over lower layers. Use this to override other benders on a lower layer.")]
		[Range(0f, 4f)]
		public int sortingLayer;

		public Renderer renderer;

		[Range(-1f, 1f)]
		public float heightOffset;

		[Range(0f, 3f)]
		[FormerlySerializedAs("strength")]
		public float flattenStrength;

		[Range(0f, 3f)]
		public float pushStrength;

		[Range(0f, 3f)]
		public float scaleMultiplier;

		[Tooltip("When enabled, overlapping benders of the same type will blend together")]
		public bool alphaBlending;

		public MeshFilter meshFilter;

		public TrailRenderer trailRenderer;

		[Tooltip("Jitter the position of the trail, to force the mesh to constantly update")]
		public bool forceUpdating;

		public LineRenderer lineRenderer;

		private MaterialPropertyBlock _props;

		private Material material;

		[SerializeField]
		private Shader bendingShader;

		private readonly int paramsID;

		private readonly int _SrcFactor;

		private readonly int _DstFactor;

		private Vector3 targetPosition;

		private static Vector3 TrailRotation;

		private const string TRAIL_KEYWORD = "_TRAIL";

		public const string MESH_SHADER_OPAQUE_NAME = "Hidden/Nature/Grass Bend Mesh";

		private static Material _TrailMaterial;

		private static Material _MeshMaterial;

		public MaterialPropertyBlock props => null;

		private static Material TrailMaterial => null;

		private static Material MeshMaterial => null;

		private void Reset()
		{
		}

		public void OnEnable()
		{
		}

		private void SetupMaterial()
		{
		}

		public void UpdateProperties()
		{
		}

		public void GetRenderer()
		{
		}

		private void OnDisable()
		{
		}

		private void Update()
		{
		}

		public static Material GetMaterial(Type type)
		{
			return null;
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
