using UnityEngine;

namespace Data.FactoryFloor.Resources
{
	public class ColorResource : Resource, IColorResource
	{
		public Color ColorValue { get; }

		public ColorResource(ResourceDataSO resourceData, Color color)
			: base(resourceData)
		{
			ColorValue = color;
		}

		public Color GetColor()
		{
			return ColorValue;
		}
	}
}
