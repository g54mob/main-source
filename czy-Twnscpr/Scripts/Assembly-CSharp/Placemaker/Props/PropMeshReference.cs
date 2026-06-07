using System;
using System.Collections.Generic;
using UnityEngine;

namespace Placemaker.Props
{
	[DisallowMultipleComponent]
	public class PropMeshReference : MonoBehaviour, IPropEnable
	{
		[Serializable]
		public class Item
		{
			public MeshFilter mf;

			public BigMeshPart bigMeshPart;

			public bool shouldBeBatched;
		}

		public List<Item> items;

		public WorldMaster worldMaster;

		public float time;

		void IPropEnable.OnFirstEnable(WorldMaster master)
		{
		}

		void IPropEnable.OnEnable(WorldMaster master)
		{
		}

		void IPropEnable.OnDisable(WorldMaster master)
		{
		}

		private void Update()
		{
		}
	}
}
