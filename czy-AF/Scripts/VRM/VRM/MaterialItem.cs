using System;
using UnityEngine;

namespace VRM
{
	[Serializable]
	public class MaterialItem
	{
		public Material Material { get; private set; }

		public static MaterialItem Create(Material material)
		{
			return new MaterialItem
			{
				Material = material
			};
		}
	}
}
