using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class WorkshopIcons
{
	public static Dictionary<string, Sprite> sprites;

	static WorkshopIcons()
	{
		sprites = Resources.LoadAll<Sprite>("MapWorkshop/MapWorkshopIcons").ToDictionary((Sprite q) => q.name, (Sprite q) => q);
	}
}
