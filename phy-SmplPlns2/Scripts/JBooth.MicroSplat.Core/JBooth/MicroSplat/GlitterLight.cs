using UnityEngine;

namespace JBooth.MicroSplat
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Light))]
	public class GlitterLight : MonoBehaviour
	{
		private Light lght;

		private void OnEnable()
		{
			lght = GetComponent<Light>();
		}

		private void OnDisable()
		{
			lght = GetComponent<Light>();
		}

		private void Update()
		{
			Shader.SetGlobalVector("_gGlitterLightDir", -base.transform.forward);
			Shader.SetGlobalVector("_gGlitterLightWorldPos", base.transform.position);
			if (lght != null)
			{
				Shader.SetGlobalColor("_gGlitterLightColor", lght.color);
			}
		}
	}
}
