using UnityEngine;

namespace JBooth.MicroSplat
{
	public class SnowUtilities
	{
		private static float SnowFade(float worldHeight, float snowMin, float snowMax, float snowDot, float snowDotVertex, float snowLevel, float angleRangeZ, float angleRangeW)
		{
			float num = Mathf.Clamp01((worldHeight - snowMin) / Mathf.Max(snowMax, 0.001f));
			float num2 = Mathf.Max(0f, (snowDotVertex - angleRangeZ) * 6f);
			num2 = Mathf.Clamp01(num2 * (1f - Mathf.Max(0f, (snowDotVertex - angleRangeW) * 6f)));
			return Mathf.Clamp01(snowLevel * num * num2);
		}

		public static float GetSnowCoverage(Terrain t, Vector3 worldPos, int maxDistance = 2)
		{
			MicroSplatObject component = t.GetComponent<MicroSplatTerrain>();
			if (component != null && component.keywordSO.IsKeywordEnabled("_SNOW"))
			{
				Vector3 vector = worldPos - t.transform.position;
				Vector2 vector2 = new Vector2(Mathf.InverseLerp(0f, t.terrainData.size.x, vector.x), Mathf.InverseLerp(0f, t.terrainData.size.z, vector.z));
				Vector3 interpolatedNormal = t.terrainData.GetInterpolatedNormal(vector2.x, vector2.y);
				float interpolatedHeight = t.terrainData.GetInterpolatedHeight(vector2.x, vector2.y);
				Material templateMaterial = component.templateMaterial;
				float num = ((!component.keywordSO.IsKeywordEnabled("_USEGLOBALSNOWLEVEL")) ? templateMaterial.GetFloat("_SnowAmount") : Shader.GetGlobalFloat("_Global_SnowLevel"));
				float x;
				float y;
				float z;
				float w;
				if (component.keywordSO.IsKeywordEnabled("_USEGLOBALSNOWHEIGHT"))
				{
					Vector4 globalVector = Shader.GetGlobalVector("_Global_SnowMinMaxHeight");
					x = globalVector.x;
					y = globalVector.y;
					z = globalVector.z;
					w = globalVector.w;
				}
				else
				{
					Vector4 vector3 = templateMaterial.GetVector("_SnowHeightAngleRange");
					x = vector3.x;
					y = vector3.y;
					z = vector3.z;
					w = vector3.w;
				}
				Vector4 vector4 = templateMaterial.GetVector("_SnowParams");
				Vector3 rhs = templateMaterial.GetVector("_SnowUpVector");
				float num2 = Mathf.Max(num / 2f, Vector3.Dot(interpolatedNormal, rhs));
				float snowDotVertex = num2;
				float num3 = SnowFade(interpolatedHeight, x, y, num2, snowDotVertex, num, z, w);
				float num4 = Mathf.Clamp01(0f - (1f - vector4.x));
				float num5 = Mathf.Clamp01(1f * vector4.y);
				num5 *= num5;
				float num6 = Mathf.Clamp01(num3 - num5 - num4);
				num6 = num6 * num6 * num6;
				float num7 = num6 * Mathf.Clamp01(num2 - (num4 + num5) * 0.5f);
				num7 = Mathf.Clamp01(num7 * 8f);
				if (component.keywordSO.IsKeywordEnabled("_SNOWMASK"))
				{
					Texture2D texture2D = t.materialTemplate.GetTexture("_SnowMask") as Texture2D;
					if (t != null)
					{
						Color pixelBilinear = texture2D.GetPixelBilinear(vector2.x, vector2.y);
						num7 = Mathf.Max(b: Mathf.Min(pixelBilinear.r, num7), a: pixelBilinear.g);
					}
				}
				return num7;
			}
			return 0f;
		}

		public static float GetSnowCoverage(Vector3 worldPos, int maxDistance = 2)
		{
			Terrain terrain = null;
			RaycastHit[] array = Physics.RaycastAll(worldPos + Vector3.up * 1f, Vector3.down, maxDistance + 1);
			foreach (RaycastHit raycastHit in array)
			{
				terrain = raycastHit.collider.GetComponent<Terrain>();
				if (terrain != null && terrain.GetComponent<MicroSplatTerrain>() != null)
				{
					return GetSnowCoverage(terrain, worldPos, maxDistance);
				}
			}
			return 0f;
		}
	}
}
