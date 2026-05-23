using System;
using System.Collections.Generic;
using Data.SaveData;
using Data.Shapes;
using Logic.Shapes;
using UnityEngine;

namespace SaveData.FactoryFloor.Versions
{
	internal class FactoryShapesSaveData_Version0 : IPreviousSaveVersion, ISaveVersion
	{
		[Serializable]
		public class ShapeDto
		{
			public ShapeHashPair Hash;

			public int[] Voxels;

			public List<Color> Colors;

			public Vector3Int Bounds;
		}

		public ShapeDto[] Shapes;

		public ISaveVersion ToNextVersion()
		{
			Data.Shapes.ShapeDto[] array = new Data.Shapes.ShapeDto[Shapes.Length * 2];
			for (int i = 0; i < Shapes.Length; i++)
			{
				array[i] = new Data.Shapes.ShapeDto
				{
					Hash = Shapes[i].Hash,
					Voxels = Shapes[i].Voxels,
					Colors = Shapes[i].Colors,
					Bounds = Shapes[i].Bounds
				};
				Shape shape = Shape.Create(array[i]);
				shape.SaveShapeData();
				array[i + Shapes.Length] = new Data.Shapes.ShapeDto
				{
					Hash = shape.GetShapeHash(),
					Voxels = Shapes[i].Voxels,
					Colors = Shapes[i].Colors,
					Bounds = Shapes[i].Bounds
				};
			}
			return new FactoryShapesSaveData(array);
		}
	}
}
