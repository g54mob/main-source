using System;
using System.Collections.Generic;
using AwesomeTechnologies.Vegetation.Masks;

namespace AwesomeTechnologies.VegetationSystem
{
	[Serializable]
	public class TextureMaskRule
	{
		public string TextureMaskGroupID;

		public float MinDensity = 0.1f;

		public float MaxDensity = 1f;

		public float ScaleMultiplier = 1f;

		public float DensityMultiplier = 1f;

		public List<SerializedControllerProperty> TextureMaskPropertiesList = new List<SerializedControllerProperty>();

		public TextureMaskRule(TextureMaskRule sourceItem)
		{
			TextureMaskGroupID = sourceItem.TextureMaskGroupID;
			MinDensity = sourceItem.MinDensity;
			MaxDensity = sourceItem.MaxDensity;
			ScaleMultiplier = sourceItem.ScaleMultiplier;
			DensityMultiplier = sourceItem.DensityMultiplier;
			for (int i = 0; i <= sourceItem.TextureMaskPropertiesList.Count - 1; i++)
			{
				TextureMaskPropertiesList.Add(new SerializedControllerProperty(sourceItem.TextureMaskPropertiesList[i]));
			}
		}

		public TextureMaskRule(TextureMaskSettings textureMaskSettings)
		{
			for (int i = 0; i <= textureMaskSettings.ControlerPropertyList.Count - 1; i++)
			{
				TextureMaskPropertiesList.Add(new SerializedControllerProperty(textureMaskSettings.ControlerPropertyList[i]));
			}
		}

		public bool GetBooleanPropertyValue(string propertyName)
		{
			for (int i = 0; i <= TextureMaskPropertiesList.Count - 1; i++)
			{
				if (TextureMaskPropertiesList[i].PropertyName == propertyName)
				{
					return TextureMaskPropertiesList[i].BoolValue;
				}
			}
			return false;
		}

		public int GetIntPropertyValue(string propertyName)
		{
			for (int i = 0; i <= TextureMaskPropertiesList.Count - 1; i++)
			{
				if (TextureMaskPropertiesList[i].PropertyName == propertyName)
				{
					return TextureMaskPropertiesList[i].IntValue;
				}
			}
			return 0;
		}
	}
}
