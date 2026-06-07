using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	[DisallowMultipleComponent]
	public class Outline : MonoBehaviour
	{
		public enum Mode
		{
			OutlineAll = 0,
			OutlineVisible = 1,
			OutlineDecorationEdit = 2,
			OutlineHidden = 3,
			OutlineAndSilhouette = 4,
			SilhouetteOnly = 5,
			Zoning = 6
		}

		[Serializable]
		private class ListVector3
		{
			public List<Vector3> data;
		}

		private static readonly HashSet<Mesh> RegisteredMeshes;

		public static bool ZoningActive;

		private Mode _originalMode;

		private int _rendererQueue;

		[SerializeField]
		private Mode outlineMode;

		[SerializeField]
		private Color outlineColor;

		[SerializeField]
		[Range(0f, 10f)]
		private float outlineWidth;

		[Header("Optional")]
		[SerializeField]
		[Tooltip("Precompute enabled: Per-vertex calculations are performed in the editor and serialized with the object. Precompute disabled: Per-vertex calculations are performed at runtime in Awake(). This may cause a pause for large meshes.")]
		private bool precomputeOutline;

		[SerializeField]
		private List<Mesh> bakeKeys;

		[SerializeField]
		private List<ListVector3> bakeValues;

		private Renderer[] _renderers;

		private Material _outlineMaskMaterial;

		private Material _outlineFillMaterial;

		private Material _outlineFillOccludedMaterial;

		private bool _needsUpdate;

		private Color outlineOccludedColorMult;

		private static readonly int OutlineColorShaderProperty;

		private static readonly int ZTestShaderProperty;

		private static readonly int OutlineWidthShaderProperty;

		public Mode OutlineMode
		{
			get
			{
				return default(Mode);
			}
			set
			{
			}
		}

		public Color OutlineColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public int RenderQueue
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float OutlineWidth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnValidate()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		[ContextMenu("Bake")]
		public void Bake()
		{
		}

		private void LoadSmoothNormals()
		{
		}

		private List<Vector3> SmoothNormals(Mesh mesh)
		{
			return null;
		}

		private void UpdateMaterialProperties()
		{
		}

		private Color SaturateColor(Color color, float saturationMultiplier, float valueMultiplier)
		{
			return default(Color);
		}
	}
}
