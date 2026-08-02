using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace BloodEffectsPack
{
	public class BloodModifier_URP : MonoBehaviour
	{
		public enum EffectType
		{
			Splash = 0,
			Decal = 1
		}

		public EffectType effectType;

		public Color color;

		public float colorIntensity;

		public float albedoPower;

		public float ambientColorIntensity;

		[Range(-180f, 180f)]
		public float hueShift;

		public float smoothness;

		public bool useSpecularity = true;

		public float gravityScale;

		public BloodPreset[] decalPresets;

		public BloodPreset[] splashPresets;

		private List<Material> mats = new List<Material>();

		public void Apply()
		{
			ParticleSystem[] componentsInChildren = GetComponentsInChildren<ParticleSystem>();
			MeshRenderer[] componentsInChildren2 = GetComponentsInChildren<MeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				ParticleSystem.MainModule main = componentsInChildren[i].main;
				if (effectType == EffectType.Splash)
				{
					main.gravityModifierMultiplier = gravityScale;
				}
				Material sharedMaterial = componentsInChildren[i].GetComponent<ParticleSystemRenderer>().sharedMaterial;
				sharedMaterial.SetFloat("_Smoothness", smoothness);
				int num = (useSpecularity ? 1 : 0);
				sharedMaterial.SetColor("_BaseColor", color);
				if (num == 1)
				{
					sharedMaterial.SetFloat("_Smoothness", smoothness);
				}
				else
				{
					sharedMaterial.SetFloat("_Smoothness", 0f);
				}
				sharedMaterial.SetFloat("_ColorIntensity", colorIntensity);
				sharedMaterial.SetFloat("_AlbedoPower", albedoPower);
				sharedMaterial.SetFloat("_AmbientColorIntensity", ambientColorIntensity);
				sharedMaterial.SetFloat("_HueShift", hueShift);
			}
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				Material sharedMaterial2 = componentsInChildren2[j].sharedMaterial;
				int num2 = (useSpecularity ? 1 : 0);
				sharedMaterial2.SetColor("_BaseColor", color);
				if (num2 == 1)
				{
					sharedMaterial2.SetFloat("_Smoothness", smoothness);
				}
				else
				{
					sharedMaterial2.SetFloat("_Smoothness", 0f);
				}
				sharedMaterial2.SetFloat("_ColorIntensity", colorIntensity);
				sharedMaterial2.SetFloat("_AlbedoPower", albedoPower);
				sharedMaterial2.SetFloat("_AmbientColorIntensity", ambientColorIntensity);
				sharedMaterial2.SetFloat("_HueShift", hueShift);
			}
			DecalProjector[] componentsInChildren3 = GetComponentsInChildren<DecalProjector>();
			for (int k = 0; k < componentsInChildren3.Length; k++)
			{
				Material material = componentsInChildren3[k].material;
				int num3 = (useSpecularity ? 1 : 0);
				material.SetColor("_BaseColor", color);
				if (num3 == 1)
				{
					material.SetFloat("_Smoothness", smoothness);
				}
				else
				{
					material.SetFloat("_Smoothness", 0f);
				}
				material.SetFloat("_ColorIntensity", colorIntensity);
				material.SetFloat("_AlbedoPower", albedoPower);
				material.SetFloat("_AmbientColorIntensity", ambientColorIntensity);
				material.SetFloat("_HueShift", hueShift);
			}
		}
	}
}
