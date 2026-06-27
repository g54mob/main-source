using UnityEngine;

namespace Restory.Data.Elements
{
	[CreateAssetMenu(menuName = "Restory/Elements/PaintingTextureHolderSettings", fileName = "PaintingTextureHolderSettings")]
	public class PaintingTextureHolderSettings : ScriptableObject
	{
		[SerializeField]
		private Shader shaderToPaint;

		[SerializeField]
		private string paintingTextureShaderProperty;

		public Shader ShaderToPaint => shaderToPaint;

		public string PaintingTextureShaderProperty => paintingTextureShaderProperty;
	}
}
