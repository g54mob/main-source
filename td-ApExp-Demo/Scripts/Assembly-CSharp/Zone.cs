using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Zone
{
	public List<LevelData> LevelDataList { get; private set; }

	public ZoneDefinition Definition { get; private set; }

	public Vector2Int MapSize => Definition.MapSize;

	public Dictionary<string, Sprite> SpriteDict { get; private set; }

	public Zone(ZoneDefinition def)
	{
		Definition = def;
		LevelDataList = ZoneGenerator.GenerateLevelDataList(def);
		LoadZoneSprites(def.ZoneName);
	}

	private void LoadZoneSprites(string zoneName)
	{
		Sprite[] array = Resources.LoadAll<Sprite>("Zones/Backgrounds/" + zoneName);
		if (array == null || array.Length == 0)
		{
			Debug.LogError("[Zone] No sprites found at path: Zones/Backgrounds/" + zoneName);
			SpriteDict = new Dictionary<string, Sprite>();
			return;
		}
		SpriteDict = array.ToDictionary((Sprite s) => s.name, (Sprite s) => s);
		Debug.Log($"[Zone] Loaded {SpriteDict.Count} sprites for zone: {zoneName}");
	}

	public bool SetSpritesFromNextZone()
	{
		Zone getNextZone = ZoneManager.Instance.GetNextZone;
		if (getNextZone != null)
		{
			LoadZoneSprites(getNextZone.Definition.name);
			return true;
		}
		return false;
	}
}
