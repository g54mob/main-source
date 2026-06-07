using UnityEngine;

namespace RLD
{
	public class GizmoLineMaterial : Singleton<GizmoLineMaterial>
	{
		private Material _material;

		public Material Material
		{
			get
			{
				if (_material == null)
				{
					_material = Singleton<MaterialPool>.Get.SimpleColor;
				}
				return _material;
			}
		}

		public void ResetValuesToSensibleDefaults()
		{
			SetZWriteEnabled(isEnabled: false);
			SetZTestAlways();
		}

		public void SetColor(Color color)
		{
			Material.SetColor("_Color", color);
		}

		public void SetPass(int passIndex)
		{
			Material.SetPass(0);
		}

		public void SetZWriteEnabled(bool isEnabled)
		{
			Material.SetInt("_ZWrite", isEnabled ? 1 : 0);
		}

		public void SetZTestLessEqual()
		{
			Material.SetInt("_ZTest", 4);
		}

		public void SetZTestAlways()
		{
			Material.SetInt("_ZTest", 8);
		}

		public void SetZTestLess()
		{
			Material.SetInt("_ZTest", 2);
		}
	}
}
