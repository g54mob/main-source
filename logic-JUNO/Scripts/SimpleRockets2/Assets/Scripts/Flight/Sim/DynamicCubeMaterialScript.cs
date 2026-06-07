using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	public class DynamicCubeMaterialScript : MonoBehaviour, IDynamicStructureMaterial
	{
		private static Vector3 _tangentXU = new Vector3(0f, 0f, 1f);

		private static Vector3 _tangentXV = new Vector3(0f, 1f, 0f);

		private static Vector3 _tangentYU = new Vector3(0f, 0f, 1f);

		private static Vector3 _tangentYV = new Vector3(1f, 0f, 0f);

		private static Vector3 _tangentZU = new Vector3(1f, 0f, 0f);

		private static Vector3 _tangentZV = new Vector3(0f, 1f, 0f);

		[SerializeField]
		private float _baseTiling = 1f;

		private MaterialPropertyBlock _materialPropertyBlock;

		public void UpdateMaterial(float tiling, Color color)
		{
			if (_materialPropertyBlock == null)
			{
				_materialPropertyBlock = new MaterialPropertyBlock();
			}
			_materialPropertyBlock.SetColor("_colorMultiplier", color);
			GetComponent<MeshRenderer>().SetPropertyBlock(_materialPropertyBlock);
			MeshFilter component = GetComponent<MeshFilter>();
			Vector2[] uv = component.mesh.uv;
			Vector3[] vertices = component.mesh.vertices;
			Vector3[] normals = component.mesh.normals;
			Vector3 lossyScale = base.transform.lossyScale;
			for (int i = 0; i < vertices.Length; i++)
			{
				GetTangentVectors(normals[i], out var tangentU, out var tangentV);
				Vector3 lhs = Vector3.Scale(vertices[i], lossyScale);
				uv[i].x = Vector3.Dot(lhs, tangentU) * tiling * _baseTiling;
				uv[i].y = Vector3.Dot(lhs, tangentV) * tiling * _baseTiling;
			}
			component.mesh.SetUVs(0, uv);
		}

		private void GetTangentVectors(Vector3 normal, out Vector3 tangentU, out Vector3 tangentV)
		{
			if (Mathf.Abs(normal.x) > 0.9f)
			{
				tangentU = _tangentXU;
				tangentV = _tangentXV;
			}
			else if (Mathf.Abs(normal.y) > 0.9f)
			{
				tangentU = _tangentYU;
				tangentV = _tangentYV;
			}
			else
			{
				tangentU = _tangentZU;
				tangentV = _tangentZV;
			}
		}
	}
}
