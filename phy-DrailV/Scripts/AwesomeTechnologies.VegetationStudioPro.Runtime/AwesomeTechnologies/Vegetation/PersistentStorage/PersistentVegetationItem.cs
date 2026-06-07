using System;
using UnityEngine;

namespace AwesomeTechnologies.Vegetation.PersistentStorage
{
	[Serializable]
	public struct PersistentVegetationItem
	{
		public Vector3 Position;

		public Vector3 Scale;

		public Quaternion Rotation;

		public byte VegetationSourceID;

		public float DistanceFalloff;
	}
}
