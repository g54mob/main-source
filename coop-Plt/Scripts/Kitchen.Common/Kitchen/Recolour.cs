using UnityEngine;

namespace Kitchen
{
	public class Recolour : MonoBehaviour
	{
		public MeshRenderer Renderer;

		private static readonly int Property = Shader.PropertyToID("_Color0");

		private void Start()
		{
			if (!(Renderer == null))
			{
				MemoryManager.Handle(this).Register(Renderer.material).SetColor(Property, Color.HSVToRGB(Random.value, 0.25f, 0.75f));
			}
		}

		private void OnDestroy()
		{
			MemoryManager.Handle(this).Dispose();
		}
	}
}
