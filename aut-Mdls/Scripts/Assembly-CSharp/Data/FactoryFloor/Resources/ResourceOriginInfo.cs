using System.Collections.Generic;
using UnityEngine;

namespace Data.FactoryFloor.Resources
{
	public class ResourceOriginInfo
	{
		public string Name;

		public Color Color;

		public List<ResourceOrigin> Origins;

		public void AddOrigin(string originName, Sprite imageSprite, ResourceOriginType type)
		{
			if (Origins == null)
			{
				Origins = new List<ResourceOrigin>();
			}
			Origins.Add(new ResourceOrigin(originName, imageSprite, type));
		}
	}
}
