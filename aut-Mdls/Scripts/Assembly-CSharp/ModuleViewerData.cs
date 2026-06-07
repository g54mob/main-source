using System.Collections.Generic;
using Data.Shapes;
using UnityEngine;

public class ModuleViewerData
{
	public struct ShapeDataAndAmount
	{
		public ShapeDataSO Shape { get; }

		public int Amount { get; }

		public ShapeDataAndAmount(ShapeDataSO shapeData, int amount)
		{
			Shape = shapeData;
			Amount = amount;
		}
	}

	public string TitleLocKey { get; }

	public Sprite PreviewSprite { get; }

	public List<ShapeDataAndAmount> Modules { get; }

	public int FactoryObjectID { get; }

	public ModuleViewerData(string titleLocKey, Sprite previewSprite, List<ShapeDataAndAmount> modules, int factoryObjectID = -1)
	{
		TitleLocKey = titleLocKey;
		PreviewSprite = previewSprite;
		Modules = modules;
		FactoryObjectID = factoryObjectID;
	}
}
