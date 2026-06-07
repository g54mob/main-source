using System;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public abstract class RewiredControllerGlyphs : ScriptableObject
{
	public const string SPRITE_TAG_FORMAT = "<sprite=\"{0}\" sprite name=\"{1}\">";

	public abstract bool SupportsGuid(Guid guid);

	public abstract bool TryGetActionNameAndIcon(Controller controller, int actionId, out string name, out Sprite icon, bool skipDisabledMaps);

	public abstract bool TryGetActionsParameterValue(Controller controller, List<int> actionIds, out string value, bool skipDisabledMaps);
}
