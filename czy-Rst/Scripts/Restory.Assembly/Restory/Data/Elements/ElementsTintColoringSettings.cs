using UnityEngine;

namespace Restory.Data.Elements
{
	[CreateAssetMenu(menuName = "Restory/Elements/ElementsTintColoringSettings", fileName = "ElementsTintColoringSettings")]
	public class ElementsTintColoringSettings : ScriptableObject
	{
		[SerializeField]
		private Shader shaderToColor;

		[SerializeField]
		private string tintShaderProperty;

		public Shader ShaderToColor => shaderToColor;

		public string TintShaderProperty => tintShaderProperty;
	}
}
