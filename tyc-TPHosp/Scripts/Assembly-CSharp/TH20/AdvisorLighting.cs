using UnityEngine;

namespace TH20
{
	[CreateAssetMenu(menuName = "TH20/Configs/Advisor Lighting", order = 1101)]
	public class AdvisorLighting : ScriptableObjectWithID
	{
		[Header("Ambient Lighting")]
		[Range(0f, 1f)]
		public float AmbientLightIntensity = 1f;

		public Color AmbientLightColor = Color.white;

		[Range(0f, 1f)]
		public float GlossMapScale = 0.25f;

		[Space]
		[Header("Directional Lighting")]
		[Range(0f, 10f)]
		public float LightIntensity = 1f;

		public Color LightColor = Color.white;

		[Range(-1f, 1f)]
		public float LightDirectionX = -0.577f;

		[Range(-1f, 1f)]
		public float LightDirectionY = -0.577f;

		[Range(-1f, 1f)]
		public float LightDirectionZ = -0.577f;

		public void Apply(MaterialPropertyBlock materialPropertyBlock, Transform transform = null)
		{
			Vector4 vector = new Vector4(LightDirectionX, LightDirectionY, LightDirectionZ, 0f);
			if (transform != null)
			{
				vector = transform.rotation * vector;
			}
			vector = Vector4.Normalize(vector);
			materialPropertyBlock.SetFloat("_GlossMapScale", GlossMapScale);
			materialPropertyBlock.SetColor("_DirectionalRoomLightColor", LightColor);
			materialPropertyBlock.SetVector("_DirectionalRoomLightDirection", vector);
			materialPropertyBlock.SetFloat("_DirectionalRoomLightIntensity", LightIntensity);
			materialPropertyBlock.SetFloat("_AmbientRoomLightIntensity", AmbientLightIntensity);
			materialPropertyBlock.SetColor("_AmbientRoomLightColor", AmbientLightColor);
		}

		public void Apply(Material material, Transform transform = null)
		{
			Vector4 vector = new Vector4(LightDirectionX, LightDirectionY, LightDirectionZ, 0f);
			if (transform != null)
			{
				vector = transform.rotation * vector;
			}
			vector = Vector4.Normalize(vector);
			material.SetFloat("_GlossMapScale", GlossMapScale);
			material.SetColor("_DirectionalRoomLightColor", LightColor);
			material.SetVector("_DirectionalRoomLightDirection", vector);
			material.SetFloat("_DirectionalRoomLightIntensity", LightIntensity);
			material.SetFloat("_AmbientRoomLightIntensity", AmbientLightIntensity);
			material.SetColor("_AmbientRoomLightColor", AmbientLightColor);
		}
	}
}
