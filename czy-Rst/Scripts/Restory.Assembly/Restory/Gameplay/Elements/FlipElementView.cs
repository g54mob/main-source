using UnityEngine;

namespace Restory.Gameplay.Elements
{
	public class FlipElementView : ElementView
	{
		private FlipElement flipElement;

		protected override bool IsActivatable => true;

		private void Awake()
		{
			if (!(element is FlipElement flipElement))
			{
				Debug.LogError("element " + element.Info.ID + " is not FlipElement");
			}
			else
			{
				this.flipElement = flipElement;
			}
		}

		protected override void ResolveSelectionStateChanged()
		{
			base.IsOutlined = element.IsSelected && (!element.IsBlocked || selectableWhenBlocked || flipElement.IsInteractable);
			if (base.IsOutlined)
			{
				if (element.IsInstalling)
				{
					outlineAdapter.OverridePreset = outlineSettings.InstallingOutline;
				}
				else if (flipElement.IsInteractable)
				{
					outlineAdapter.OverridePreset = outlineSettings.ActivatableOutline;
				}
				else
				{
					OutlineSelectedElement();
				}
			}
		}
	}
}
