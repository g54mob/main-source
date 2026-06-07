using System;
using Data.SaveData;
using Data.Shapes;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class FactoryShapesSaveData : AbstractSaveData
	{
		public const int CurrentVersion = 1;

		public ShapeDto[] Shapes;

		public FactoryShapesSaveData(ShapeDto[] shapes)
			: base(1)
		{
			Shapes = shapes;
		}
	}
}
