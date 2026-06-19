using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Collections;
using UnityEngine;

namespace PugTilemap.Quads
{
	public static class QuadGeneratorExtensions
	{
		public static void ResolveQuad(this QuadGenerator qg, PugMultiMap multiMap, PugMap map, PugMapLayer sourceLayer, ref Quad q, IEnumerator<TileData> tilesAtThisPosition)
		{
			bool flag = false;
			int num = 0;
			if (qg.meshFillType == QuadGenerator.FillType.CustomFill || qg.meshFillType == QuadGenerator.FillType.RandomFill || qg.meshFillType == QuadGenerator.FillType.AdaptativeFill || qg.meshFillType == QuadGenerator.FillType.RandomFillEditorOnly)
			{
				while (tilesAtThisPosition.MoveNext())
				{
					TileData current = tilesAtThisPosition.Current;
					if (current == null)
					{
						continue;
					}
					foreach (TileType item in qg.drawOn)
					{
						if (current.info.tileType == item)
						{
							flag = current.info.tileset == sourceLayer.tilesetKey;
							if (flag)
							{
								num = current.info.state;
							}
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
			}
			else
			{
				flag = false;
				foreach (TileType item2 in qg.drawOn)
				{
					bool flag2 = false;
					while (tilesAtThisPosition.MoveNext())
					{
						TileData current4 = tilesAtThisPosition.Current;
						if (current4.info.tileType == item2)
						{
							if (current4 != null && current4.info.tileset == sourceLayer.tilesetKey)
							{
								num = current4.info.state;
								flag = true;
								flag2 = true;
							}
							break;
						}
						if (flag2)
						{
							break;
						}
					}
				}
			}
			if (!flag)
			{
				q.Clear();
				return;
			}
			switch (qg.meshFillType)
			{
			case QuadGenerator.FillType.CustomFill:
				q.spriteUV = new Rect(0f, 0f, 1f, 1f);
				q.adjacentTilesMask = 0;
				break;
			case QuadGenerator.FillType.RandomFill:
			case QuadGenerator.FillType.RandomFillEditorOnly:
				q.spriteUV = qg.allSpriteUVs[num].spriteUVS[Random.Range(0, qg.allSpriteUVs[num].spriteUVS.Count)];
				q.adjacentTilesMask = 0;
				break;
			case QuadGenerator.FillType.AdaptativeFill:
			case QuadGenerator.FillType.AdaptativeExtrude:
			{
				int num2 = 0;
				Vector3 position = Vector3.zero;
				int num3 = 0;
				bool flag3 = sourceLayer.def.dontAdaptIfTilePresent == TileType.none || multiMap.IsTileTypeAt(map.ToWorldCoordF(q.pos), sourceLayer.def.dontAdaptIfTilePresent);
				NativeList<int> nativeList = new NativeList<int>(Allocator.Temp);
				if (!qg.ignoreDiagonalQuads)
				{
					nativeList.Add(128);
					nativeList.Add(32);
					nativeList.Add(2);
					nativeList.Add(8);
				}
				if (!qg.ignoreHorizontalQuads)
				{
					nativeList.Add(16);
					nativeList.Add(1);
				}
				if (!qg.ignoreVerticalQuads)
				{
					nativeList.Add(4);
					nativeList.Add(64);
				}
				for (int i = 0; i < nativeList.Length; i++)
				{
					int num4 = nativeList[i];
					Vector3Int vector3Int = q.pos + AdjacentDir.GetVector(num4);
					position = map.ToWorldCoordF(vector3Int);
					if (((!sourceLayer.def.onlyAdaptToOwnTileset && multiMap.IsTileTypeAt(position, sourceLayer.def.targetTile)) || (sourceLayer.def.onlyAdaptToOwnTileset && multiMap.IsTileTypeAt(position, sourceLayer.def.targetTile, sourceLayer.tilesetKey))) && (flag3 || !multiMap.IsTileTypeAt(position, sourceLayer.def.dontAdaptIfTilePresent)))
					{
						num2 |= num4;
						if (nativeList.Length <= 4 || i % 2 == 0)
						{
							num3++;
						}
					}
				}
				nativeList.Dispose();
				if (sourceLayer.def.targetTile.ShouldUseFenceLikeAdaption() && num3 < 2)
				{
					int num5 = 0;
					int num6 = 0;
					bool flag4 = false;
					int dir = num2 & 0x55;
					for (int j = 0; j < AdjacentDir.fourWay.Length; j++)
					{
						int num7 = AdjacentDir.fourWay[j];
						Vector3Int vector3Int = q.pos + AdjacentDir.GetVector(num7);
						position = map.ToWorldCoordF(vector3Int);
						TileData surfaceTileAt = multiMap.GetSurfaceTileAt(position);
						if (surfaceTileAt == null || !sourceLayer.def.targetTile.ShouldUseFenceLikeAdaptionTowardsTileType(surfaceTileAt.info.tileType))
						{
							continue;
						}
						num5++;
						num6 = num7;
						if (num3 == 1)
						{
							if (AdjacentDir.IsOppositeDirections(num7, dir))
							{
								num2 |= num7;
								flag4 = true;
								break;
							}
						}
						else
						{
							num2 |= num7;
						}
					}
					if (num3 == 1 && num5 == 1 && !flag4)
					{
						num2 |= num6;
					}
				}
				int num8 = PugRandom.Range(0, 256, (int)(position.x + position.z));
				if (sourceLayer.def.isUsingFullAdaptiveTexture)
				{
					num2 &= qg.generatedTextureAdaptativeDirBitsAvailable[num];
					q.spriteUV = qg.generatedTextureAdaptativeSpriteLookupTable[num].GetSpriteCoordsForDirCombination((byte)num2, (byte)num8);
				}
				else
				{
					num2 &= qg.adaptativeDirBitsAvailable[num];
					q.spriteUV = qg.adaptativeSpriteLookupTable[num].GetSpriteCoordsForDirCombination((byte)num2, (byte)num8);
				}
				q.adjacentTilesMask = num2;
				break;
			}
			}
		}
	}
}
