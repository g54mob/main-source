using System.Collections.Generic;
using Rewired;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Pajama Llama/Rewired/Rewired Glyphs")]
public class RewiredGlyphProvider : ScriptableObject
{
	[SerializeField]
	[FormerlySerializedAs("_joysticks")]
	private RewiredControllerGlyphs[] _controllerGlyphs;

	[SerializeField]
	private RewiredControllerGlyphs _fallbackControllerGlyphs;

	public bool SupportsJoystick(Joystick joystick)
	{
		if (_fallbackControllerGlyphs.SupportsGuid(joystick.hardwareTypeGuid))
		{
			return true;
		}
		RewiredControllerGlyphs[] controllerGlyphs = _controllerGlyphs;
		for (int i = 0; i < controllerGlyphs.Length; i++)
		{
			if (controllerGlyphs[i].SupportsGuid(joystick.hardwareTypeGuid))
			{
				return true;
			}
		}
		return false;
	}

	public bool TryGetActiveControllerActionNameAndIcon(out string name, out Sprite icon, int actionId, bool skipDisabledMaps = true)
	{
		Controller activeController = FlotsamInputManager.GetActiveController();
		if (TryGetActionNameAndIcon(activeController, actionId, out name, out icon, skipDisabledMaps))
		{
			return true;
		}
		if (_fallbackControllerGlyphs.TryGetActionNameAndIcon(activeController, actionId, out name, out icon, skipDisabledMaps))
		{
			return true;
		}
		name = null;
		icon = null;
		return false;
	}

	private bool TryGetActionNameAndIcon(Controller controller, int actionId, out string name, out Sprite icon, bool skipDisabledMaps = true)
	{
		if (controller != null)
		{
			RewiredControllerGlyphs[] controllerGlyphs = _controllerGlyphs;
			foreach (RewiredControllerGlyphs rewiredControllerGlyphs in controllerGlyphs)
			{
				if (rewiredControllerGlyphs.SupportsGuid(controller.hardwareTypeGuid))
				{
					return rewiredControllerGlyphs.TryGetActionNameAndIcon(controller, actionId, out name, out icon, skipDisabledMaps);
				}
			}
		}
		name = null;
		icon = null;
		return false;
	}

	public bool TryGetActionsParameterValue(List<int> actionIds, out string value, bool skipDisabledMaps = true)
	{
		Controller activeController = FlotsamInputManager.GetActiveController();
		if (TryGetActionParameterValue(activeController, actionIds, out value, skipDisabledMaps))
		{
			return true;
		}
		if (_fallbackControllerGlyphs.TryGetActionsParameterValue(activeController, actionIds, out value, skipDisabledMaps))
		{
			return true;
		}
		value = null;
		return false;
	}

	private bool TryGetActionParameterValue(Controller controller, List<int> actionIds, out string value, bool skipDisabledMaps = true)
	{
		if (controller != null)
		{
			RewiredControllerGlyphs[] controllerGlyphs = _controllerGlyphs;
			foreach (RewiredControllerGlyphs rewiredControllerGlyphs in controllerGlyphs)
			{
				if (rewiredControllerGlyphs.SupportsGuid(controller.hardwareTypeGuid))
				{
					return rewiredControllerGlyphs.TryGetActionsParameterValue(controller, actionIds, out value, skipDisabledMaps);
				}
			}
		}
		value = null;
		return false;
	}
}
