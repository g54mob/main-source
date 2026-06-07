using System;
using System.Collections.Generic;
using System.Linq;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	public class DynamicCylinderMaterialScript : MonoBehaviour, IDynamicStructureMaterial
	{
		private static Dictionary<int, Vector2[]> _cachedUVs = new Dictionary<int, Vector2[]>();

		private static Vector3 _tangentYU = new Vector3(0f, 0f, 1f);

		private static Vector3 _tangentYV = new Vector3(1f, 0f, 0f);

		[SerializeField]
		private float _baseTiling = 1f;

		private MaterialPropertyBlock _materialPropertyBlock;

		private Vector2[] _originalUVs;

		public void UpdateMaterial(float tiling, Color color)
		{
			if (_materialPropertyBlock == null)
			{
				_materialPropertyBlock = new MaterialPropertyBlock();
			}
			_materialPropertyBlock.SetColor("_colorMultiplier", color);
			GetComponent<MeshRenderer>().SetPropertyBlock(_materialPropertyBlock);
			MeshFilter component = GetComponent<MeshFilter>();
			int key = component.mesh.vertices.Length;
			if (!_cachedUVs.TryGetValue(key, out _originalUVs))
			{
				_originalUVs = component.sharedMesh.uv.ToArray();
				_cachedUVs[key] = _originalUVs;
			}
			Vector2[] uv = component.mesh.uv;
			Vector3[] vertices = component.mesh.vertices;
			Vector3[] normals = component.mesh.normals;
			Vector3 lossyScale = base.transform.lossyScale;
			for (int i = 0; i < vertices.Length; i++)
			{
				Vector3 lhs = Vector3.Scale(vertices[i], lossyScale);
				if (Mathf.Abs(normals[i].y) > 0.9f)
				{
					Vector3 tangentYU = _tangentYU;
					Vector3 tangentYV = _tangentYV;
					uv[i].x = Vector3.Dot(lhs, tangentYU) * tiling * _baseTiling;
					uv[i].y = Vector3.Dot(lhs, tangentYV) * tiling * _baseTiling;
				}
				else
				{
					float num = Mathf.Sqrt(lhs.x * lhs.x + lhs.z * lhs.z);
					float num2 = _originalUVs[i].x * MathF.PI;
					uv[i].x = num2 * 2f * num * tiling * _baseTiling;
					uv[i].y = lhs.y * tiling * _baseTiling;
				}
			}
			component.mesh.SetUVs(0, uv);
		}
	}
}
