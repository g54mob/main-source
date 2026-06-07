using UnityEngine;

namespace RLD
{
	public class GizmoSolidMaterial : Singleton<GizmoSolidMaterial>
	{
		private Material _material;

		public Material Material
		{
			get
			{
				if (_material == null)
				{
					_material = Singleton<MaterialPool>.Get.GizmoSolidHandle;
				}
				return _material;
			}
		}

		public bool IsLit => Material.GetInt("_IsLit") == 1;

		public float LightIntensity => Material.GetFloat("_LightIntensity");

		public GizmoSolidMaterial()
		{
			ResetValuesToSensibleDefaults();
		}

		public void ResetValuesToSensibleDefaults()
		{
			SetZWriteEnabled(isEnabled: false);
			SetZTestAlways();
			SetCullModeBack();
			SetLit(isLit: true);
			SetLightIntensity(1.23f);
		}

		public void SetLit(bool isLit)
		{
			Material.SetInt("_IsLit", isLit ? 1 : 0);
		}

		public void SetLightDirection(Vector3 lightDir)
		{
			Material.SetVector("_LightDir", lightDir);
		}

		public void SetLightIntensity(float intensity)
		{
			Material.SetFloat("_LightIntensity", intensity);
		}

		public void SetColor(Color color)
		{
			Material.SetColor("_Color", color);
		}

		public void SetZWriteEnabled(bool isEnabled)
		{
			Material.SetInt("_ZWrite", isEnabled ? 1 : 0);
		}

		public void SetZTestEnabled(bool isEnabled)
		{
			Material.SetInt("_ZTest", isEnabled ? 4 : 8);
		}

		public void SetZTestAlways()
		{
			Material.SetInt("_ZTest", 8);
		}

		public void SetZTestLess()
		{
			Material.SetInt("_ZTest", 2);
		}

		public void SetCullModeBack()
		{
			Material.SetInt("_CullMode", 2);
		}

		public void SetCullModeFront()
		{
			Material.SetInt("_CullMode", 1);
		}

		public void SetCullModeOff()
		{
			Material.SetInt("_CullMode", 0);
		}

		public void SetPass(int passIndex)
		{
			Material.SetPass(0);
		}
	}
}
