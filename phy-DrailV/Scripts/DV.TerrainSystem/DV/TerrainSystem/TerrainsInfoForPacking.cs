using System;
using UnityEngine;

namespace DV.TerrainSystem
{
	[CreateAssetMenu(menuName = "DV/Terrains packing info asset")]
	public class TerrainsInfoForPacking : ScriptableObject
	{
		public TerrainInfo[] infos;

		public float terrainSizeInWorld;

		public int TerrainsPerAxis
		{
			get
			{
				int num = infos.Length;
				float num2 = Mathf.Sqrt(num);
				if (num2 != (float)(int)num2)
				{
					throw new InvalidOperationException($"Number of terrains must be a square number, got {num}");
				}
				return (int)num2;
			}
		}
	}
}
