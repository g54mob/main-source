using System;
using PajamaLlama.I2Language;
using UnityEngine;

[Serializable]
public class ItemParameter : ILocalizationParameter
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Item";

	[SerializeField]
	private ItemProperties _itemProperties;

	public string GetParameterValue(string parameter)
	{
		if ((bool)_itemProperties)
		{
			if (!(parameter == "ITEM"))
			{
				return parameter;
			}
			return _itemProperties.LocalizedName;
		}
		return parameter;
	}
}
