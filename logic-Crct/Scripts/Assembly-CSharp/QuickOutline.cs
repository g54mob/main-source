using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[DisallowMultipleComponent]
public class QuickOutline : MonoBehaviour
{
	public enum Mode
	{
		OutlineAll = 0,
		OutlineVisible = 1,
		OutlineHidden = 2,
		OutlineAndSilhouette = 3,
		SilhouetteOnly = 4
	}

	[Serializable]
	private class ListVector3
	{
		public List<Vector3> data;
	}

	private static HashSet<Mesh> registeredMeshes;

	[SerializeField]
	private Mode outlineMode;

	[SerializeField]
	private Color color;

	[SerializeField]
	[Range(0f, 10f)]
	private float outlineWidth;

	[Tooltip("Precompute enabled: Per-vertex calculations are performed in the editor and serialized with the object. Precompute disabled: Per-vertex calculations are performed at runtime in Awake(). This may cause a pause for large meshes.")]
	[SerializeField]
	[Header("Optional")]
	private bool precomputeOutline;

	[HideInInspector]
	[SerializeField]
	private List<Mesh> bakeKeys;

	[SerializeField]
	[HideInInspector]
	private List<ListVector3> bakeValues;

	private Renderer rend;

	private Material outlineMaskMaterial;

	private Material outlineFillMaterial;

	private bool needsUpdate;

	public bool dynamic;

	public bool matrixTransform;

	public bool requiresRefresh;

	private MeshFilter[] meshFilters;

	private MeshFilter mainMeshFilter;

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

	public Color Color
	{
		get
		{
			return default(Color);
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

	public void RefreshRenderers()
	{
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

	private void Update()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Bake()
	{
	}

	public void LoadSmoothNormals()
	{
	}

	private List<Vector3> SmoothNormals(Mesh mesh)
	{
		return null;
	}

	private void CombineSubmeshes(Mesh mesh, Material[] materials)
	{
	}

	private void UpdateMaterialProperties()
	{
	}
}
