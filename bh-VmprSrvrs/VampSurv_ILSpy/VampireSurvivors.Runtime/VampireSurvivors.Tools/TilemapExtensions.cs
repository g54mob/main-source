using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace VampireSurvivors.Tools;

public static class TilemapExtensions
{
	public unsafe static Tilemap RemoveTilesWithin(Tilemap tilemap, int xMin, int yMin, int width, int height)
	{
		//IL_000d: Expected O, but got I4
		//IL_0039: Expected O, but got I4
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_00ff->IL0123: Incompatible stack heights: 1 vs 0
		//IL_0104->IL0063: Incompatible stack heights: 1 vs 0
		int num = default(int);
		object obj = num + width;
		if (num < (nint)obj)
		{
			object obj2 = num + width;
			object obj4 = default(object);
			object obj3 = obj4 + yMin;
			int num2 = num;
			int position = default(int);
			do
			{
				if (yMin < (nint)obj3)
				{
					bool flag2;
					do
					{
						bool flag = ((UnityEngine.Object)tilemap).m_CachedPtr == (IntPtr)0;
						Tilemap.SetTileAsset_Injected(((UnityEngine.Object)tilemap).m_CachedPtr, ref *(Vector3Int*)(&position), (IntPtr)0);
						int num3 = yMin + 1;
						flag2 = num3 < (nint)obj3;
						position = num2;
						num = (int)(&position);
					}
					while (flag2);
				}
				num2++;
			}
			while (num2 < (nint)obj2);
		}
		return tilemap;
	}
}
