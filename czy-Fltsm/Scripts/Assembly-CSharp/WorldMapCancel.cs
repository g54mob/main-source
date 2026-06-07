using UnityEngine;

public class WorldMapCancel : CancelTriggerBase
{
	[SerializeField]
	private WorldMap _worldMap;

	public override bool TryCancel()
	{
		if (HasActiveInput() && (bool)_worldMap)
		{
			return _worldMap.Close();
		}
		return false;
	}
}
