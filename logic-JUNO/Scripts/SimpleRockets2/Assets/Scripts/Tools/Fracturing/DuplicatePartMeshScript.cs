using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Tools.Fracturing
{
	public class DuplicatePartMeshScript : MonoBehaviour
	{
		[SerializeField]
		private PartScript _partScript;

		[SerializeField]
		private MeshRenderer _rendererToDuplicate;

		private static void DuplicatePartsMesh(PartScript partScript, MeshRenderer rendererToDuplicate)
		{
			Mesh mesh = rendererToDuplicate.GetComponent<MeshFilter>().mesh;
			Mesh mesh2 = new Mesh();
			mesh2.vertices = mesh.vertices;
			List<Vector4> uvs = new List<Vector4>(mesh.vertexCount);
			for (int i = 0; i < 2; i++)
			{
				mesh.GetUVs(i, uvs);
				mesh2.SetUVs(i, uvs);
			}
			mesh2.normals = mesh.normals;
			mesh2.tangents = mesh.tangents;
			mesh2.triangles = mesh.triangles;
			GameObject obj = new GameObject(partScript.name + " duplicate");
			obj.AddComponent<MeshFilter>().mesh = mesh2;
			obj.AddComponent<MeshRenderer>().material = rendererToDuplicate.sharedMaterial;
		}

		private void DuplicatePartMesh()
		{
			if (_partScript == null || _rendererToDuplicate == null || _rendererToDuplicate.GetComponentInParent<PartScript>() != _partScript)
			{
				Debug.LogError("Stuff isn't setup right...assign the part-script and a renderer that belongs to that part.");
			}
			else
			{
				DuplicatePartsMesh(_partScript, _rendererToDuplicate);
			}
		}
	}
}
