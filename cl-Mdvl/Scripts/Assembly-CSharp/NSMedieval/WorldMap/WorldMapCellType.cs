using System;
using System.Collections.Generic;
using UnityEngine;

namespace NSMedieval.WorldMap
{
	[Serializable]
	public class WorldMapCellType
	{
		[SerializeField]
		private int id;

		[SerializeField]
		private string mapType;

		[SerializeField]
		private List<string> meshes;

		[SerializeField]
		private float height;

		public int Id => id;

		public string MapType => mapType;

		public List<string> Meshes => meshes;

		public float Height => height;
	}
}
