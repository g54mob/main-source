using DV.UI;
using DV.Utils;
using Rewired;
using Rewired.UI.ControlMapper;
using UnityEngine;

namespace DV.Interaction.Inputs
{
	[ExecuteBefore(typeof(ControlMapper))]
	public class ControlMapperButtonTooltipHack : MonoBehaviour
	{
		private void Awake()
		{
			GetComponent<ControlMapper>().InputFieldCreated += delegate(ControlMapper.GUIInputField field, ControllerType type)
			{
				UIElementTooltip component = field.gameObject.transform.GetChild(1).GetComponent<UIElementTooltip>();
				switch (type)
				{
				case ControllerType.Keyboard:
					component.enabledKey = "settings/key_rebind_kb_tooltip";
					break;
				case ControllerType.Mouse:
					component.enabledKey = "settings/key_rebind_mouse_tooltip";
					break;
				case ControllerType.Joystick:
				case ControllerType.Custom:
					component.enabledKey = "settings/key_rebind_controller_tooltip";
					break;
				}
			};
		}
	}
}
