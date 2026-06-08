using Dorfromantik.UI.Components;
using UnityEngine;

namespace Dorfromantik.UI
{
	[RequireComponent(typeof(UiIconButton))]
	public class UiIconButtonGamepadModifier : MonoBehaviour
	{
		[SerializeField]
		private bool shouldDisplayHoverVisualStateOnActive;

		[SerializeField]
		private InputRouter inputRouter;

		[SerializeField]
		private UiIconButton uiIconButton;

		private void OnValidate()
		{
			uiIconButton = GetComponent<UiIconButton>();
		}

		private void Start()
		{
			if ((bool)inputRouter && shouldDisplayHoverVisualStateOnActive)
			{
				inputRouter.OnShowRadialMenu += DisplayHoverVisualStateOnActive;
			}
		}

		private void OnDestroy()
		{
			if ((bool)inputRouter && shouldDisplayHoverVisualStateOnActive)
			{
				inputRouter.OnShowRadialMenu -= DisplayHoverVisualStateOnActive;
			}
		}

		private void DisplayHoverVisualStateOnActive(bool shouldShow, bool executeSelectedRadialMenuCommand)
		{
			uiIconButton.SetVisualStateEnabled(!shouldShow);
			uiIconButton.SetVisualStateHovered(shouldShow);
		}
	}
}
