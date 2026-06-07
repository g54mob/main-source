using UnityEngine;

namespace DV.Items
{
	public class ItemTransparencyTextDisabler : ItemRendererDynamic
	{
		private Renderer textRenderer;

		protected override void Start()
		{
			textRenderer = GetComponent<Renderer>();
			if (textRenderer == null)
			{
				Debug.LogError("ItemTransparencyTextDisabler: Missing text Renderer component. Dynamic transparency will not work. Destroying self.", this);
				Object.Destroy(this);
			}
			else
			{
				base.Start();
			}
		}

		protected override void OnTransparencyChanged(bool isTransparent)
		{
			if (!(textRenderer == null))
			{
				textRenderer.enabled = !isTransparent;
			}
		}
	}
}
