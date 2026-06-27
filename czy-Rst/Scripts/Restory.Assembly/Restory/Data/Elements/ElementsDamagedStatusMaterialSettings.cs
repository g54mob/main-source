using UnityEngine;

namespace Restory.Data.Elements
{
	[CreateAssetMenu(menuName = "Restory/Elements/ElementsDamagedStatusMaterialSettings", fileName = "ElementsDamagedStatusMaterialSettings")]
	public class ElementsDamagedStatusMaterialSettings : ScriptableObject
	{
		[SerializeField]
		private Shader shaderToAffect;

		[SerializeField]
		private string brokenStatusShaderProperty;

		public Shader ShaderToAffect => shaderToAffect;

		public string BrokenStatusShaderProperty => brokenStatusShaderProperty;
	}
}
