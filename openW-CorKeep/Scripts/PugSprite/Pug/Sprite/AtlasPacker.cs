using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace Pug.Sprite
{
	[BurstCompile]
	public struct AtlasPacker
	{
		public struct Rect
		{
			public int Width;

			public int Height;

			public override string ToString()
			{
				return $"Rect({Width}, {Height})";
			}
		}

		private struct RectIndexComparator : IComparer<int>
		{
			public NativeArray<Rect> Rects;

			public int Compare(int a, int b)
			{
				return CompareRect(Rects[a], Rects[b]);
			}
		}

		private const int MAX_UNITY_TEXTURE_SIZE = 16384;

		private const float SUB_OPTIMALITY_TOLERANCE = 0.005f;

		private NativeList<Rect> _freeSpaces;

		private NativeList<int2> _freePositions;

		private static int CompareRect(Rect a, Rect b)
		{
			if (a.Height != b.Height)
			{
				return b.Height - a.Height;
			}
			return b.Width - a.Width;
		}

		public static bool TryPack(List<SpriteData> sprites, out int size, out NativeArray<int2> packedPositions, Allocator resultAllocator = Allocator.Temp)
		{
			NativeArray<Rect> rects = new NativeArray<Rect>(sprites.Count, Allocator.Temp);
			for (int i = 0; i < sprites.Count; i++)
			{
				rects[i] = new Rect
				{
					Width = sprites[i].GetSrcTexture().width,
					Height = sprites[i].GetSrcTexture().height
				};
			}
			NativeArray<int> array = new NativeArray<int>(rects.Length, Allocator.Temp);
			for (int j = 0; j < rects.Length; j++)
			{
				array[j] = j;
			}
			array.Sort(new RectIndexComparator
			{
				Rects = rects
			});
			for (int k = 0; k < rects.Length; k++)
			{
				SpriteData spriteData = sprites[array[k]];
				rects[k] = new Rect
				{
					Width = spriteData.GetSrcTexture().width,
					Height = spriteData.GetSrcTexture().height
				};
			}
			NativeArray<int2> packedPositions2 = new NativeArray<int2>(rects.Length, Allocator.Temp);
			AtlasPacker atlasPacker = new AtlasPacker
			{
				_freeSpaces = new NativeList<Rect>(512, Allocator.Temp),
				_freePositions = new NativeList<int2>(512, Allocator.Temp)
			};
			bool flag = atlasPacker.TryPackInternal(in rects, out size, ref packedPositions2);
			if (flag)
			{
				packedPositions = new NativeArray<int2>(rects.Length, resultAllocator);
				for (int l = 0; l < rects.Length; l++)
				{
					packedPositions[array[l]] = packedPositions2[l];
				}
			}
			else
			{
				packedPositions = default(NativeArray<int2>);
			}
			packedPositions2.Dispose();
			array.Dispose();
			rects.Dispose();
			atlasPacker._freeSpaces.Dispose();
			atlasPacker._freePositions.Dispose();
			return flag;
		}

		[BurstCompile]
		private bool TryPackInternal([NoAlias] in NativeArray<Rect> rects, out int size, [NoAlias] ref NativeArray<int2> packedPositions)
		{
			if (!TryFindInitialBounds(rects, out var lowerBound, out var upperBound, ref packedPositions))
			{
				size = 0;
				return false;
			}
			while (!BoundsHaveConverged(lowerBound, upperBound))
			{
				int num = (upperBound + lowerBound) / 2;
				Rect space = new Rect
				{
					Width = num,
					Height = num
				};
				NativeArray<int2> packedPositions2 = new NativeArray<int2>(rects.Length, Allocator.Temp);
				if (TryPackIntoSpace(rects, space, ref packedPositions2))
				{
					size = num;
					packedPositions.CopyFrom(packedPositions2);
					upperBound = num;
				}
				else
				{
					lowerBound = num;
				}
			}
			size = upperBound;
			return true;
		}

		private bool TryFindInitialBounds(NativeArray<Rect> rects, out int lowerBound, out int upperBound, ref NativeArray<int2> packedPositionsAtUpperBound)
		{
			int num = math.min(SystemInfo.maxTextureSize, 16384);
			int num2 = ComputeTotalArea(rects);
			lowerBound = math.cmax(FindLargestSizePerDimension(rects));
			lowerBound = math.max(lowerBound, (int)math.ceil(math.sqrt(num2)));
			lowerBound = math.max(lowerBound, 1);
			upperBound = (int)math.ceil((float)lowerBound * 1.25f);
			upperBound = math.min(upperBound, num);
			int num3 = (int)math.ceil(math.log2((float)num / (float)upperBound)) + 1;
			new NativeArray<int2>(rects.Length, Allocator.Temp);
			for (int i = 0; i < num3; i++)
			{
				Rect space = new Rect
				{
					Width = upperBound,
					Height = upperBound
				};
				if (TryPackIntoSpace(rects, space, ref packedPositionsAtUpperBound))
				{
					return true;
				}
				lowerBound = upperBound;
				upperBound = math.min(upperBound * 2, num);
			}
			return false;
		}

		private bool TryPackIntoSpace(NativeArray<Rect> rects, Rect space, ref NativeArray<int2> packedPositions)
		{
			NativeList<Rect> freeSpaces = new NativeList<Rect>(512, Allocator.Temp);
			NativeList<int2> freePositions = new NativeList<int2>(512, Allocator.Temp);
			freeSpaces.Add(in space);
			freePositions.Add(in int2.zero);
			int i = 0;
			while (i < rects.Length)
			{
				if (!TryFindSmallestSufficientSpace(freeSpaces, rects[i], out var rectIndex))
				{
					return false;
				}
				int height = rects[i].Height;
				int num;
				for (num = 0; i < rects.Length && rects[i].Height == height && num + rects[i].Width <= freeSpaces[rectIndex].Width; i++)
				{
					packedPositions[i] = freePositions[rectIndex] + new int2(num, 0);
					num += rects[i].Width;
				}
				Rect usedSpace = new Rect
				{
					Width = num,
					Height = height
				};
				SplitAndFit(usedSpace, ref freeSpaces, ref freePositions, rectIndex);
			}
			return true;
		}

		private bool TryFindSmallestSufficientSpace(NativeList<Rect> freeSpaces, Rect rect, out int rectIndex)
		{
			for (int num = FindFirstSmallerElement(freeSpaces, 0, rect) - 1; num >= 0; num--)
			{
				if (freeSpaces[num].Width >= rect.Width)
				{
					rectIndex = num;
					return true;
				}
			}
			rectIndex = -1;
			return false;
		}

		private void SplitAndFit(Rect usedSpace, ref NativeList<Rect> freeSpaces, ref NativeList<int2> freePositions, int spaceIndex)
		{
			Rect rect = freeSpaces[spaceIndex];
			int2 int5 = freePositions[spaceIndex];
			int height = rect.Height - usedSpace.Height;
			int num = rect.Width - usedSpace.Width;
			Rect a = new Rect
			{
				Width = rect.Width,
				Height = height
			};
			int2 a2 = new int2(int5.x, int5.y + usedSpace.Height);
			Rect b = new Rect
			{
				Width = num,
				Height = usedSpace.Height
			};
			int2 b2 = new int2(int5.x + usedSpace.Width, int5.y);
			if (num == 0)
			{
				b.Height = 0;
			}
			if (CompareRect(a, b) > 0)
			{
				Swap(ref a, ref b);
				Swap(ref a2, ref b2);
			}
			int num2 = FindFirstSmallerElement(freeSpaces, spaceIndex + 1, a);
			int num3 = FindFirstSmallerElement(freeSpaces, spaceIndex + 1, b);
			freeSpaces.ResizeUninitialized(freeSpaces.Length + 1);
			freePositions.ResizeUninitialized(freePositions.Length + 1);
			ShiftLeft(freeSpaces, spaceIndex + 1, num2, 1);
			ShiftLeft(freePositions, spaceIndex + 1, num2, 1);
			freeSpaces[num2 - 1] = a;
			freePositions[num2 - 1] = a2;
			ShiftRight(freeSpaces, num3, freeSpaces.Length - 1, 1);
			ShiftRight(freePositions, num3, freePositions.Length - 1, 1);
			freeSpaces[num3] = b;
			freePositions[num3] = b2;
			while (freeSpaces.Length > 0)
			{
				if (freeSpaces[freeSpaces.Length - 1].Height == 0)
				{
					freeSpaces.RemoveAt(freeSpaces.Length - 1);
					freePositions.RemoveAt(freePositions.Length - 1);
					continue;
				}
				break;
			}
		}

		private int FindFirstSmallerElement(NativeList<Rect> list, int startIndex, Rect rect)
		{
			int num = startIndex;
			int num2 = list.Length;
			while (num < num2)
			{
				int num3 = (num + num2) / 2;
				if (CompareRect(list[num3], rect) > 0)
				{
					num2 = num3;
				}
				else
				{
					num = num3 + 1;
				}
			}
			return num;
		}

		private static bool BoundsHaveConverged(int lowerBound, int upperBound)
		{
			if (upperBound - lowerBound > 1)
			{
				return (float)upperBound / (float)lowerBound <= 1.005f;
			}
			return true;
		}

		private static int2 FindLargestSizePerDimension(NativeArray<Rect> rects)
		{
			int2 result = new int2(0, 0);
			for (int i = 0; i < rects.Length; i++)
			{
				result.x = math.max(result.x, rects[i].Width);
				result.y = math.max(result.y, rects[i].Height);
			}
			return result;
		}

		private static int ComputeTotalArea(NativeArray<Rect> rects)
		{
			int num = 0;
			for (int i = 0; i < rects.Length; i++)
			{
				num += rects[i].Width * rects[i].Height;
			}
			return num;
		}

		private void ShiftLeft<T>(NativeList<T> array, int startIndex, int endIndex, int leftShift) where T : unmanaged
		{
			for (int i = startIndex; i < endIndex; i++)
			{
				array[i - leftShift] = array[i];
			}
		}

		private void ShiftRight<T>(NativeList<T> array, int startIndex, int endIndex, int rightShift) where T : unmanaged
		{
			for (int num = endIndex - 1; num >= startIndex; num--)
			{
				array[num + rightShift] = array[num];
			}
		}

		private void Swap<T>(ref T a, ref T b) where T : unmanaged
		{
			T val = a;
			a = b;
			b = val;
		}

		private static void LogList<T>(NativeList<T> list) where T : unmanaged
		{
			for (int i = 0; i < list.Length; i++)
			{
				Debug.Log($"[{i}] = {list[i]}");
			}
		}

		private static bool CheckListSorted(NativeList<Rect> list)
		{
			for (int i = 1; i < list.Length; i++)
			{
				if (CompareRect(list[i - 1], list[i]) > 0)
				{
					Debug.LogError($"List is not sorted at index {i - 1}: {list[i - 1]} > {list[i]}");
					return false;
				}
			}
			return true;
		}

		private static bool CheckPackingIsValid(NativeArray<Rect> rects, NativeArray<int2> packedPositions, int size)
		{
			NativeArray<bool> nativeArray = new NativeArray<bool>(size * size, Allocator.Temp);
			for (int i = 0; i < rects.Length; i++)
			{
				Rect rect = rects[i];
				int2 int5 = packedPositions[i];
				if (int5.x < 0 || int5.y < 0 || int5.x + rect.Width > size || int5.y + rect.Height > size)
				{
					Debug.LogError($"Rect {i} is out of bounds: {int5.x}, {int5.y}, {rect.Width}, {rect.Height}");
					return false;
				}
				for (int j = int5.y; j < int5.y + rect.Height; j++)
				{
					for (int k = int5.x; k < int5.x + rect.Width; k++)
					{
						int index = j * size + k;
						if (nativeArray[index])
						{
							Debug.LogError($"Rect {i} overlaps with another rect at {k}, {j}");
							return false;
						}
						nativeArray[index] = true;
					}
				}
			}
			return true;
		}
	}
}
