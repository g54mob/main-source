using System.Collections.Generic;
using Restory.Data.SaveLoad.Containers;

namespace Restory.Gameplay.Elements
{
	public class PlacedElements
	{
		public bool IsEmpty
		{
			get
			{
				if (ElementsOnSurface.Count == 0)
				{
					return ElementsInBin.Count == 0;
				}
				return false;
			}
		}

		public List<ElementTransformRecord> ElementsOnSurface { get; } = new List<ElementTransformRecord>();

		public List<ElementTransformRecord> ElementsInBin { get; } = new List<ElementTransformRecord>();

		public PlacedElementsData GetData()
		{
			PlacedElementsData placedElementsData = new PlacedElementsData();
			if (IsEmpty)
			{
				return placedElementsData;
			}
			List<ElementTransformData> list = new List<ElementTransformData>();
			List<ElementTransformData> list2 = new List<ElementTransformData>();
			foreach (ElementTransformRecord item in ElementsOnSurface)
			{
				ElementTransformData elementTransformData = GetElementTransformData(item);
				list.Add(elementTransformData);
			}
			foreach (ElementTransformRecord item2 in ElementsInBin)
			{
				ElementTransformData elementTransformData2 = GetElementTransformData(item2);
				list2.Add(elementTransformData2);
			}
			placedElementsData.ElementsOnSurface = list;
			placedElementsData.ElementsInBin = list2;
			return placedElementsData;
		}

		private ElementTransformData GetElementTransformData(ElementTransformRecord transformRecord)
		{
			return new ElementTransformData
			{
				ElementData = transformRecord.Element.ConditionHandler.ElementData,
				ElementTransform = new SerializableTransform(transformRecord.Position, transformRecord.Rotation)
			};
		}
	}
}
