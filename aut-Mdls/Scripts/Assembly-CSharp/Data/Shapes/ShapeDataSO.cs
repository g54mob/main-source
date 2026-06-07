using System;
using UnityEngine;

namespace Data.Shapes
{
	[Serializable]
	[CreateAssetMenu]
	public class ShapeDataSO : ScriptableObject
	{
		public ShapeData Data;

		public Mesh Mesh;

		public ShapeHashPair GetShapeHash()
		{
			return Data.GetShapeHash();
		}

		public bool Equals(ShapeData other)
		{
			return Data.Equals(other);
		}
	}
}
