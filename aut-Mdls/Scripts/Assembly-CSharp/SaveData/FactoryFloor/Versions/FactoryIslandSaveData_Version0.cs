using System;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveData.FactoryFloor.Versions
{
	[Serializable]
	public class FactoryIslandSaveData_Version0
	{
		[JsonProperty("s")]
		public Vector2Int Size;

		[JsonProperty("ft")]
		public Color32[] FloorTextureColors;

		[JsonProperty("ht")]
		public Color32[] HeightTextureColors;

		[JsonProperty("id")]
		public string Guid;
	}
}
