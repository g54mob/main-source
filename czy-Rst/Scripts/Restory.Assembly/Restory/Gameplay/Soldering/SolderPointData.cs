using System;
using Restory.Data.SaveLoad.Containers;
using UnityEngine;

namespace Restory.Gameplay.Soldering
{
	[Serializable]
	public class SolderPointData
	{
		public SolderPointState State { get; set; }

		public SerializableTransform Transform { get; set; }

		public Vector3 Deviation { get; set; }

		public float Scaling { get; set; }

		public bool IsPivot { get; set; }
	}
}
