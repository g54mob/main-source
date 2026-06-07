using System;
using System.Linq;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	public class DynamicSphereMaterialScript : MonoBehaviour, IDynamicStructureMaterial
	{
		private static Vector2[] _originalUVs;

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
			if (_originalUVs == null)
			{
				_originalUVs = component.sharedMesh.uv.ToArray();
			}
			Vector2[] uv = component.mesh.uv;
			Vector3[] vertices = component.mesh.vertices;
			Vector3 lossyScale = base.transform.lossyScale;
			float num = Mathf.Max(lossyScale.x, lossyScale.y, lossyScale.z);
			float num2 = num * 2f * MathF.PI;
			for (int i = 0; i < vertices.Length; i++)
			{
				uv[i].x = _originalUVs[i].x * _baseTiling * tiling * num2;
				uv[i].y = _originalUVs[i].y * _baseTiling * tiling * num2;
			}
			component.mesh.SetUVs(0, uv);
			float num3 = Mathf.Min(lossyScale.x, lossyScale.y, lossyScale.z);
			bool flag = num3 > 0f && num / num3 <= 1.1f;
			GetComponent<SphereCollider>().enabled = flag;
			GetComponent<MeshCollider>().enabled = !flag;
		}
	}
}
