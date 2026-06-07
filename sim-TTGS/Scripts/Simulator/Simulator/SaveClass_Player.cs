using System;
using System.Collections.Generic;
using Simulator.GameWorld;
using UnityEngine;

namespace Simulator
{
	[Serializable]
	public class SaveClass_Player
	{
		public Vector3 position;

		public float yRotation;

		public int productsUID;

		public int productsQuantity;

		public List<int> productsUIDs;

		public IStackable.EType stackableType;

		public SaveClass_Player()
		{
			position = Vector3.zero;
			yRotation = 0f;
		}
	}
}
