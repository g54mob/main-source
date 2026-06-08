using UnityEngine;

namespace Kitchen
{
	public class BrokenApplianceMaterialSwap : MonoBehaviour, IViewModifier
	{
		public Material Default;

		public Material Broken;

		public Renderer Renderer;

		private MemoryManagerHandle Handle => this;

		private void OnDestroy()
		{
			Handle.Dispose();
		}

		public void UpdateState(ApplianceView.ViewData view_data)
		{
			Handle.Register(Renderer.material);
			Renderer.material = (view_data.Broken ? Broken : Default);
		}
	}
}
