using UnityEngine;

namespace Data.FactoryFloor.Resources
{
	public struct ResourceOrigin
	{
		public string OriginName;

		public Sprite ImageSprite;

		public ResourceOriginType Type;

		public ResourceOrigin(string name, Sprite imageSprite, ResourceOriginType type)
		{
			OriginName = name;
			ImageSprite = imageSprite;
			Type = type;
		}
	}
}
