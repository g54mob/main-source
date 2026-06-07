using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

[CreateAssetMenu(menuName = "Pajama Llama/Rewired/Controller Glyphs Group")]
public class RewiredControllerGlyphsGroup : RewiredControllerGlyphs
{
	[SerializeField]
	private RewiredControllerGlyphs[] _controllers;

	[SerializeField]
	private RewiredControllerGlyphs _fallback;

	public override bool SupportsGuid(Guid guid)
	{
		RewiredControllerGlyphs[] controllers = _controllers;
		for (int i = 0; i < controllers.Length; i++)
		{
			if (controllers[i].SupportsGuid(guid))
			{
				return true;
			}
		}
		return _fallback.SupportsGuid(guid);
	}

	public override bool TryGetActionNameAndIcon(Controller controller, int actionId, out string name, out Sprite icon, bool skipDisabledMaps)
	{
		RewiredControllerGlyphs[] controllers = _controllers;
		for (int i = 0; i < controllers.Length; i++)
		{
			if (controllers[i].TryGetActionNameAndIcon(controller, actionId, out name, out icon, skipDisabledMaps))
			{
				return true;
			}
		}
		return _fallback.TryGetActionNameAndIcon(controller, actionId, out name, out icon, skipDisabledMaps);
	}

	public override bool TryGetActionsParameterValue(Controller controller, List<int> actionIds, out string value, bool skipDisabledMaps)
	{
		RewiredControllerGlyphs[] controllers = _controllers;
		for (int i = 0; i < controllers.Length; i++)
		{
			if (controllers[i].TryGetActionsParameterValue(controller, actionIds, out value, skipDisabledMaps))
			{
				return true;
			}
		}
		return _fallback.TryGetActionsParameterValue(controller, actionIds, out value, skipDisabledMaps);
	}
}
