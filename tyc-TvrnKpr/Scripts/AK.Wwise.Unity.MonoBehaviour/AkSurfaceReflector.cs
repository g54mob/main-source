using System;
using AK.Wwise;
using UnityEngine;
using UnityEngine.Serialization;

[AddComponentMenu("Wwise/Spatial Audio/AkSurfaceReflector")]
[ExecuteInEditMode]
public class AkSurfaceReflector : MonoBehaviour
{
	public struct GeometryData
	{
		public Vector3[] vertices;

		public AkTriangleArray triangles;

		public AkAcousticSurfaceArray surfaces;

		public uint numVertices;

		public uint numTriangles;

		public uint numSurfaces;
	}

	public static ulong INVALID_GEOMETRY_ID;

	[Tooltip("The mesh to send to Spatial Audio as a Geometry Set. If this GameObject has a MeshFilter component, you can leave this parameter to None to use the same mesh for Spatial Audio. Otherwise, this parameter lets you import a different mesh for Spatial Audio purposes. We recommend using a simplified mesh.")]
	public Mesh Mesh;

	[Tooltip("The acoustic texture per submesh. The acoustic texture represents the surface of the geometry. An acoustic texture is a set of absorption levels that will filter the sound reflected from the geometry.")]
	public AcousticTexture[] AcousticTextures;

	[Tooltip("The transmission loss value per submesh. The transmission loss value is a control value used to adjust sound parameters. Typically, a value of 1.0 represents total sound loss, and a value of 0.0 indicates that sound can be transmitted through the geometry without any loss. Default value : 1.0.")]
	[Range(0f, 1f)]
	public float[] TransmissionLossValues;

	[Tooltip("Enable or disable geometric diffraction for this mesh.")]
	public bool EnableDiffraction;

	[Tooltip("Enable or disable geometric diffraction on boundary edges for this mesh. Boundary edges are edges that are connected to only one triangle.")]
	public bool EnableDiffractionOnBoundaryEdges;

	[Tooltip("A solid geometry instance applies transmission loss once, over its volume. A non-solid geometry instance is one where each surface is infinitely thin, applying transmission loss at each surface.")]
	public bool Solid;

	private int PreviousTransformState;

	private int PreviousGeometryState;

	private bool isGeometrySetInWwise;

	[HideInInspector]
	[SerializeField]
	[FormerlySerializedAs("AcousticTexture")]
	private AcousticTexture AcousticTextureInternal;

	[Obsolete("This functionality is deprecated as of Wwise v2019.2.0 and will be removed in a future release.")]
	public AcousticTexture AcousticTexture
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[Obsolete("This functionality is deprecated as of Wwise v2021.1.0 and will be removed in a future release.")]
	public float[] OcclusionValues
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private int GetTransformState()
	{
		return 0;
	}

	private int GetGeometryState()
	{
		return 0;
	}

	public ulong GetID()
	{
		return 0uL;
	}

	public static bool SetGeometryFromMesh(Mesh mesh, ulong geometryID, bool enableDiffraction, bool enableDiffractionOnBoundaryEdges, AcousticTexture[] acousticTextures = null, float[] transmissionLossValues = null, string name = "")
	{
		return false;
	}

	public static void GetGeometryDataFromMesh(Mesh mesh, ref GeometryData geometryData, AcousticTexture[] acousticTextures = null, float[] transmissionLossValues = null, string name = "")
	{
	}

	public static void SetGeometryInstance(ulong geometryInstanceID, ulong geometryID, Transform transform, bool useForReflectionAndDiffraction, bool solid)
	{
	}

	public void SetGeometry()
	{
	}

	public void SetGeometryInstance()
	{
	}

	public void UpdateGeometry()
	{
	}

	public void RemoveGeometry()
	{
	}

	public void RemoveGeometryInstance()
	{
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
	}

	[Obsolete("This functionality is deprecated as of Wwise v2019.2.0 and will be removed in a future release.")]
	public static ulong GetAkGeometrySetID(MeshFilter meshFilter)
	{
		return 0uL;
	}

	[Obsolete("This functionality is deprecated as of Wwise v2019.2.0 and will be removed in a future release.")]
	public static void AddGeometrySet(AcousticTexture acousticTexture, MeshFilter meshFilter, bool enableDiffraction, bool enableDiffractionOnBoundaryEdges, bool enableTriangles)
	{
	}

	[Obsolete("This functionality is deprecated as of Wwise v2019.2.0 and will be removed in a future release.")]
	public static void RemoveGeometrySet(MeshFilter meshFilter)
	{
	}

	[Obsolete("This functionality is deprecated as of Wwise v2022.1.0 and will be removed in a future release.")]
	public static void SetGeometryFromMesh(Mesh mesh, Transform transform, ulong geometryID, bool enableDiffraction, bool enableDiffractionOnBoundaryEdges, bool enableTriangles, AcousticTexture[] acousticTextures = null, float[] transmissionLossValues = null, string name = "")
	{
	}

	[Obsolete("This functionality is deprecated as of Wwise v2023.1.0 and will be removed in a future release.")]
	public static void SetGeometryFromMesh(Mesh mesh, ulong geometryID, bool enableDiffraction, bool enableDiffractionOnBoundaryEdges, bool enableTriangles, AcousticTexture[] acousticTextures = null, float[] transmissionLossValues = null, string name = "")
	{
	}

	[Obsolete("This functionality is deprecated as of Wwise v2023.1.0 and will be removed in a future release.")]
	public static void SetGeometryInstance(ulong geometryInstanceID, ulong geometryID, Transform transform)
	{
	}
}
