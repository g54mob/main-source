using System.Collections.Generic;
using UnityEngine;

namespace BloodEffectsPack
{
	public class BloodModifier : MonoBehaviour
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
				int value = (useSpecularity ? 1 : 0);
				sharedMaterial.SetColor("_Color", color);
				sharedMaterial.SetInt("_UseSpecularity", value);
				sharedMaterial.SetFloat("_ColorIntensity", colorIntensity);
				sharedMaterial.SetFloat("_AlbedoPower", albedoPower);
				sharedMaterial.SetFloat("_AmbientColorIntensity", ambientColorIntensity);
				sharedMaterial.SetFloat("_HueShift", hueShift);
			}
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				Material sharedMaterial2 = componentsInChildren2[j].sharedMaterial;
				int value2 = (useSpecularity ? 1 : 0);
				sharedMaterial2.SetColor("_Color", color);
				sharedMaterial2.SetInt("_UseSpecularity", value2);
				sharedMaterial2.SetFloat("_Smoothness", smoothness);
				sharedMaterial2.SetFloat("_ColorIntensity", colorIntensity);
				sharedMaterial2.SetFloat("_AlbedoPower", albedoPower);
				sharedMaterial2.SetFloat("_AmbientColorIntensity", ambientColorIntensity);
				sharedMaterial2.SetFloat("_HueShift", hueShift);
			}
			Projector[] componentsInChildren3 = GetComponentsInChildren<Projector>();
			for (int k = 0; k < componentsInChildren3.Length; k++)
			{
				Material material = componentsInChildren3[k].material;
				int value3 = (useSpecularity ? 1 : 0);
				material.SetColor("_Color", color);
				material.SetInt("_UseSpecularity", value3);
				material.SetFloat("_Smoothness", smoothness);
				material.SetFloat("_ColorIntensity", colorIntensity);
				material.SetFloat("_AlbedoPower", albedoPower);
				material.SetFloat("_AmbientColorIntensity", ambientColorIntensity);
				material.SetFloat("_HueShift", hueShift);
			}
		}
	}
}
