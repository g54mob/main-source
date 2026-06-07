using UnityEngine;

namespace Assets.Scripts.PlanetStudio.Brush
{
	public class BrushSphereFaceScript : MonoBehaviour
	{
		private static class ShaderPropertyIds
		{
			public static readonly int BrushPosition = Shader.PropertyToID("_BrushPosition");

			public static readonly int BrushRadius = Shader.PropertyToID("_BrushRadius");

			public static readonly int GradientTex = Shader.PropertyToID("_GradientTex");

			public static readonly int MainTex = Shader.PropertyToID("_MainTex");
		}

		private Material _material;

		private MeshFilter _meshFilter;

		private MeshRenderer _meshRenderer;

		public void Initialize()
		{
		}

		public void SetBrushInfo(Vector3? brushPosition, float brushRadius)
		{
			if (brushPosition.HasValue)
			{
				_material.SetVector(ShaderPropertyIds.BrushPosition, brushPosition.Value);
				_material.SetFloat(ShaderPropertyIds.BrushRadius, brushRadius);
			}
			else
			{
				_material.SetVector(ShaderPropertyIds.BrushPosition, Vector4.zero);
				_material.SetFloat(ShaderPropertyIds.BrushRadius, 0f);
			}
		}

		public void SetGradientTexture(Texture2D texture)
		{
			_material.SetTexture(ShaderPropertyIds.GradientTex, texture);
		}

		public void SetMainTexture(Texture2D texture)
		{
			_material.SetTexture(ShaderPropertyIds.MainTex, texture);
		}

		public void SetMesh(Mesh mesh)
		{
			_meshFilter.mesh = mesh;
		}

		protected virtual void Awake()
		{
			_meshFilter = GetComponent<MeshFilter>();
			_meshRenderer = GetComponent<MeshRenderer>();
			_material = _meshRenderer.material;
		}
	}
}
