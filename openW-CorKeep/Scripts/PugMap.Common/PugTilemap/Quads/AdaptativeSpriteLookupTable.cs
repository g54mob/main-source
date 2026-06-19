using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PugTilemap.Quads
{
	[Serializable]
	public class AdaptativeSpriteLookupTable
	{
		[SerializeField]
		public Rect[] allSpriteCoords;

		[SerializeField]
		public int[] sublistStart;

		[SerializeField]
		public int[] sublistLength;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Rect GetSpriteCoordsForDirCombination(byte dirFlags, byte random)
		{
			return sublistLength[dirFlags] switch
			{
				0 => Rect.zero, 
				1 => allSpriteCoords[sublistStart[dirFlags]], 
				_ => allSpriteCoords[sublistStart[dirFlags] + random % sublistLength[dirFlags]], 
			};
		}

		public Rect[] GetAllSpriteCoordsForDirCombination(byte dirFlags)
		{
			int num = sublistLength[dirFlags];
			Rect[] array = new Rect[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = allSpriteCoords[sublistStart[dirFlags] + i];
			}
			return array;
		}

		public AdaptativeSpriteLookupTable(List<List<Rect>> spriteCoordTable)
		{
			int num = 0;
			if (spriteCoordTable == null)
			{
				allSpriteCoords = Array.Empty<Rect>();
				sublistStart = Array.Empty<int>();
				sublistLength = Array.Empty<int>();
				return;
			}
			for (int i = 0; i < 256; i++)
			{
				if (spriteCoordTable[i].Count > 255)
				{
					Debug.LogError("Can't have more than 255 sprites per direction mask");
				}
				num += spriteCoordTable[i].Count;
			}
			allSpriteCoords = new Rect[num];
			sublistStart = new int[256];
			sublistLength = new int[256];
			int num2 = 0;
			for (int j = 0; j < 256; j++)
			{
				sublistLength[j] = spriteCoordTable[j].Count;
				sublistStart[j] = num2;
				for (int k = 0; k < spriteCoordTable[j].Count; k++)
				{
					allSpriteCoords[num2++] = spriteCoordTable[j][k];
				}
			}
		}
	}
}
