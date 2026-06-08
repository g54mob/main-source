using Dorfromantik.UI.Components;
using UnityEngine;

namespace Dorfromantik
{
	public class CreativeModeToolToggle : MonoBehaviour
	{
		[SerializeField]
		private ToolId toolId;

		[SerializeField]
		private InputRouter inputRouter;

		[SerializeField]
		private UiIconButton toolIcon;

		private void Awake()
		{
			inputRouter.OnToolEnabled += SetToggleIsOn;
		}

		private void SetToggleIsOn(ToolId toolId, bool isOn)
		{
			if (toolId == this.toolId)
			{
				toolIcon.SetVisualStateActivated(isOn);
				if (isOn)
				{
					toolIcon.SetVisualStatePressed(shouldSetPressed: true);
				}
			}
		}

		private void OnDestroy()
		{
			inputRouter.OnToolEnabled -= SetToggleIsOn;
		}
	}
}
