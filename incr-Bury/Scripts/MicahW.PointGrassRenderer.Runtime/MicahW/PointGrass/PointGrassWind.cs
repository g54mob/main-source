using UnityEngine;

namespace MicahW.PointGrass
{
	[ExecuteAlways]
	public class PointGrassWind : MonoBehaviour
	{
		private struct PackedProperties
		{
			public Vector4 vecA;

			public Vector4 vecB;

			public float valA;

			public PackedProperties(Vector3 windDirection, Vector3 windScroll, Vector2 noiseRange, float windScale)
			{
				Vector4 vector = windDirection;
				vector.w = noiseRange.x;
				Vector4 vector2 = windScroll;
				vector2.w = noiseRange.y;
				vecA = vector;
				vecB = vector2;
				valA = windScale;
			}
		}

		[Tooltip("The scale of the sampled noise")]
		public float windScale;

		[Tooltip("The range of the sampled noise")]
		public Vector2 noiseRange;

		[Space]
		[Tooltip("The direction the wind will push the grass")]
		public Vector3 windDirection;

		[Tooltip("The distance the sampled noise moves each second")]
		public Vector3 windScroll;

		private Vector3 currentNoisePosition;

		private static int ID_vecA;

		private static int ID_vecB;

		private static int ID_valA;

		private void OnEnable()
		{
			GetShaderIDs();
			currentNoisePosition = Vector3.zero;
			RefreshValues();
		}

		private void LateUpdate()
		{
			currentNoisePosition += windScroll * Time.deltaTime;
			RefreshValues();
		}

		private static void GetShaderIDs()
		{
			ID_vecA = Shader.PropertyToID("_PG_VectorA");
			ID_vecB = Shader.PropertyToID("_PG_VectorB");
			ID_valA = Shader.PropertyToID("_PG_ValueA");
		}

		public void RefreshValues()
		{
			PackedProperties packedProperties = PackProperties();
			Shader.SetGlobalVector(ID_vecA, packedProperties.vecA);
			Shader.SetGlobalVector(ID_vecB, packedProperties.vecB);
			Shader.SetGlobalFloat(ID_valA, packedProperties.valA);
		}

		private PackedProperties PackProperties()
		{
			return new PackedProperties(windDirection, currentNoisePosition, noiseRange, windScale);
		}
	}
}
