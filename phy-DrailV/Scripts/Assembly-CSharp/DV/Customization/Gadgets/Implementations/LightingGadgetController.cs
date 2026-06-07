using UnityEngine;
using VLB;

namespace DV.Customization.Gadgets.Implementations
{
	public class LightingGadgetController : MonoBehaviour
	{
		private static readonly int PROPERTY_EMISSION = Shader.PropertyToID("_EmissionColor");

		private static readonly int PROPERTY_TINT = Shader.PropertyToID("_TintColor");

		private static readonly int PROPERTY_INTENSITY = Shader.PropertyToID("_Intensity");

		public Light[] lights;

		public float lightIntensity = 1f;

		public VolumetricLightBeam[] beams;

		public float beamIntensity = 1f;

		public MeshRenderer[] glares;

		public float glareIntensity = 1f;

		public MeshRenderer[] emissionSurfaces;

		public float emissionIntensity = 1f;

		public GameObject disableWhenOff;

		[ColorUsage(true, true)]
		public Color color = Color.white;

		public bool dontModifyGlareColor;

		private MaterialPropertyBlock mpb;

		public void UpdateColorAlpha(float a)
		{
			color.a = a;
			UpdateColor();
		}

		public void UpdateColor(Color color)
		{
			this.color = color;
			UpdateColor();
		}

		public void UpdateColor()
		{
			Color color = this.color;
			color.r *= color.a;
			color.g *= color.a;
			color.b *= color.a;
			color.a = 1f;
			disableWhenOff.SetActive(color.r != 0f || color.g != 0f || color.b != 0f);
			if (mpb == null)
			{
				mpb = new MaterialPropertyBlock();
			}
			mpb.SetColor(PROPERTY_EMISSION, color * emissionIntensity);
			if (dontModifyGlareColor)
			{
				mpb.SetFloat(PROPERTY_INTENSITY, color.a * glareIntensity);
			}
			else
			{
				mpb.SetColor(PROPERTY_TINT, color * glareIntensity);
			}
			MeshRenderer[] array = emissionSurfaces;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetPropertyBlock(mpb);
			}
			Light[] array2 = lights;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].color = color * lightIntensity;
			}
			VolumetricLightBeam[] array3 = beams;
			foreach (VolumetricLightBeam obj in array3)
			{
				obj.color = color * beamIntensity;
				obj.UpdateAfterManualPropertyChange();
			}
			array = glares;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetPropertyBlock(mpb);
			}
		}
	}
}
