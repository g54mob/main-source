using System;
using Data.Shapes;
using UnityEngine;

namespace SaveData.FactoryFloor
{
	[Serializable]
	public class ConfigAssemblerShapeDto
	{
		public ShapeDto ShapeDto;

		public Vector3 Position;

		public Vector3Int Rotation;
	}
}
