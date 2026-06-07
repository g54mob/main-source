using UnityEngine;

[DefaultExecutionOrder(-80)]
public class OVRMesh : MonoBehaviour
{
	public interface IOVRMeshDataProvider
	{
		MeshType GetMeshType();
	}

	public enum MeshType
	{
		None = -1,
		HandLeft = 0,
		HandRight = 1
	}

	[SerializeField]
	private IOVRMeshDataProvider _dataProvider;

	[SerializeField]
	private MeshType _meshType = MeshType.None;

	private Mesh _mesh;

	public bool IsInitialized { get; private set; }

	public Mesh Mesh => _mesh;

	private void Awake()
	{
		if (_dataProvider == null)
		{
			_dataProvider = GetComponent<IOVRMeshDataProvider>();
		}
		if (_dataProvider != null)
		{
			_meshType = _dataProvider.GetMeshType();
		}
		if (ShouldInitialize())
		{
			Initialize(_meshType);
		}
	}

	private bool ShouldInitialize()
	{
		if (IsInitialized)
		{
			return false;
		}
		if (_meshType == MeshType.None)
		{
			return false;
		}
		if (_meshType != MeshType.HandLeft)
		{
			_ = _meshType;
			_ = 1;
		}
		return true;
	}

	private void Initialize(MeshType meshType)
	{
		_mesh = new Mesh();
		OVRPlugin.Mesh mesh = new OVRPlugin.Mesh();
		if (OVRPlugin.GetMesh((OVRPlugin.MeshType)_meshType, out mesh))
		{
			Vector3[] array = new Vector3[mesh.NumVertices];
			for (int i = 0; i < mesh.NumVertices; i++)
			{
				array[i] = mesh.VertexPositions[i].FromFlippedXVector3f();
			}
			_mesh.vertices = array;
			Vector2[] array2 = new Vector2[mesh.NumVertices];
			for (int j = 0; j < mesh.NumVertices; j++)
			{
				array2[j] = new Vector2(mesh.VertexUV0[j].x, 0f - mesh.VertexUV0[j].y);
			}
			_mesh.uv = array2;
			int[] array3 = new int[mesh.NumIndices];
			for (int k = 0; k < mesh.NumIndices; k++)
			{
				array3[k] = mesh.Indices[mesh.NumIndices - k - 1];
			}
			_mesh.triangles = array3;
			Vector3[] array4 = new Vector3[mesh.NumVertices];
			for (int l = 0; l < mesh.NumVertices; l++)
			{
				array4[l] = mesh.VertexNormals[l].FromFlippedXVector3f();
			}
			_mesh.normals = array4;
			BoneWeight[] array5 = new BoneWeight[mesh.NumVertices];
			for (int m = 0; m < mesh.NumVertices; m++)
			{
				OVRPlugin.Vector4f vector4f = mesh.BlendWeights[m];
				OVRPlugin.Vector4s vector4s = mesh.BlendIndices[m];
				array5[m].boneIndex0 = vector4s.x;
				array5[m].weight0 = vector4f.x;
				array5[m].boneIndex1 = vector4s.y;
				array5[m].weight1 = vector4f.y;
				array5[m].boneIndex2 = vector4s.z;
				array5[m].weight2 = vector4f.z;
				array5[m].boneIndex3 = vector4s.w;
				array5[m].weight3 = vector4f.w;
			}
			_mesh.boneWeights = array5;
			IsInitialized = true;
		}
	}
}
