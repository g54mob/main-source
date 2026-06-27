using Mandragora.PWS;
using Restory.Data.Elements;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class ElementTintColorApplier : MonoBehaviour
	{
		[SerializeField]
		private MeshRendererMaterialsInstantiator materialsInstantiator;

		[SerializeField]
		private ElementsTintColoringSettings settings;

		private int tintShaderPropertyIndex;

		private void Reset()
		{
			materialsInstantiator = GetComponentInChildren<MeshRendererMaterialsInstantiator>();
		}

		private void Awake()
		{
			tintShaderPropertyIndex = Shader.PropertyToID(settings.TintShaderProperty);
		}

		public void ApplyColorToElement(Color color)
		{
			foreach (Material materialInstance in materialsInstantiator.MaterialInstances)
			{
				if (!(materialInstance.shader != settings.ShaderToColor))
				{
					materialInstance.SetColor(tintShaderPropertyIndex, color);
				}
			}
		}
	}
}
