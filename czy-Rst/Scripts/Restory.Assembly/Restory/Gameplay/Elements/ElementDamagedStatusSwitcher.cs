using Mandragora.PWS;
using Restory.Data.Elements;
using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class ElementDamagedStatusSwitcher : MonoBehaviour
	{
		[SerializeField]
		private MeshRendererMaterialsInstantiator materialsInstantiator;

		[SerializeField]
		private ElementsDamagedStatusMaterialSettings settings;

		private int brokenStatusShaderPropertyIndex;

		private void Reset()
		{
			materialsInstantiator = GetComponentInChildren<MeshRendererMaterialsInstantiator>();
		}

		private void Awake()
		{
			brokenStatusShaderPropertyIndex = Shader.PropertyToID(settings.BrokenStatusShaderProperty);
		}

		public void SwitchDamagedStatus(bool shouldBeDamaged)
		{
			foreach (Material materialInstance in materialsInstantiator.MaterialInstances)
			{
				if (!(materialInstance.shader != settings.ShaderToAffect))
				{
					materialInstance.SetInt(brokenStatusShaderPropertyIndex, shouldBeDamaged ? 1 : 0);
				}
			}
		}
	}
}
