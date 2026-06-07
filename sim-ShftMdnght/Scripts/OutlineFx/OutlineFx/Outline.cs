using UnityEngine;

namespace OutlineFx
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	public abstract class Outline : MonoBehaviour
	{
		internal Renderer _renderer;

		public abstract Color Color { get; set; }

		private void OnEnable()
		{
			_renderer = GetComponent<Renderer>();
		}

		private void OnWillRenderObject()
		{
			OutlineFxFeature.Render(this);
		}
	}
}
