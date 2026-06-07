using UnityEngine;

namespace UMA
{
	[CreateAssetMenu(menuName = "UMA/Rendering/PostProcess")]
	public class UMAPostProcess : ScriptableObject
	{
		public Shader shader;

		private Material material;

		public void Process(RenderTexture source, RenderTexture destination)
		{
		}
	}
}
