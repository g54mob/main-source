using UnityEngine;

namespace Kitchen
{
	public class FadeAtNight : MonoBehaviour
	{
		public string ReplaceShader = "Simple Flat";

		public Material ReplaceWith;

		private MemoryManagerHandle Handle => this;

		public void Start()
		{
			Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				Material material = Handle.Register(renderer.material);
				if (material.shader.name == ReplaceShader)
				{
					material.shader = ReplaceWith.shader;
				}
			}
		}

		private void OnDestroy()
		{
			Handle.Dispose();
		}
	}
}
