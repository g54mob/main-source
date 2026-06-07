using System.Collections;
using UnityEngine;

namespace UMA
{
	public class GeometrySelector : MonoBehaviour
	{
		[HideInInspector]
		public MeshHideAsset meshAsset;

		public BitArray selectedTriangles;

		public bool visualizeNormals;

		public float normalsLength;

		public Color32 normalsColor;

		private Mesh _sharedMesh;

		public Color32 occlusionColor;

		public bool occlusionWireframe;

		private Mesh _occlusionMesh;

		private MeshRenderer _meshRenderer;

		private MeshCollider _meshCollider;

		private Material[] _Materials;

		private Shader _Shader;

		public Mesh sharedMesh
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Mesh occlusionMesh
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public MeshRenderer meshRenderer => null;

		public MeshCollider meshCollider => null;

		public void Initialize()
		{
		}

		public void InitializeFromMeshData(UMAMeshData meshData)
		{
		}

		public void SelectAll()
		{
		}

		public void Invert()
		{
		}

		public void ClearAll()
		{
		}

		public void UpdateSelectionMesh()
		{
		}

		public void UpdateFromTexture(Texture2D tex)
		{
		}

		public void CreateOcclusionMesh(MeshHideAsset meshHide)
		{
		}

		public void CreateOcclusionMesh(UMAMeshData meshData)
		{
		}

		public void UpdateOcclusionMesh(UMAMeshData meshData, float offset, Vector3 pos, Vector3 rot, Vector3 s)
		{
		}

		public void UpdateOcclusionMesh(MeshHideAsset meshHide, float offset, Vector3 pos, Vector3 rot, Vector3 s)
		{
		}

		private void UpdateOcclusionMesh(float offset, Vector3 pos, Vector3 rot, Vector3 s)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
