using System;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public enum SerializedControlerPropertyType
	{
		Integer = 0,
		Float = 1,
		RgbaSelector = 2,
		ColorSelector = 3,
		Boolean = 4,
		DropDownStringList = 5,
		Label = 6,
		Texture2D = 7
	}
}
