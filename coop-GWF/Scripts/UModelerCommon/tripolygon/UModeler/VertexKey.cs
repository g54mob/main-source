using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public struct VertexKey
	{
		public enum BORDER_MASK
		{
			XLow = 1,
			XUp = 2,
			YLow = 4,
			YUp = 8,
			ZLow = 0x10,
			ZUp = 0x20
		}

		public int x;

		public int y;

		public int z;

		public BORDER_MASK borderIndex;

		public static float KeyEpsilon = 0.01f;

		public static float KeyInverseEpsilon = 1f / KeyEpsilon;

		public static float EpsilonLowerBorder = KeyInverseEpsilon * 0.0001f;

		public static float EpsilonUpperBorder = 1f - KeyInverseEpsilon * 0.0001f;

		public VertexKey(Vector3 position)
		{
			float num = position.x * KeyInverseEpsilon;
			float num2 = position.y * KeyInverseEpsilon;
			float num3 = position.z * KeyInverseEpsilon;
			x = Mathf.FloorToInt(num);
			y = Mathf.FloorToInt(num2);
			z = Mathf.FloorToInt(num3);
			float xBorder = num - (float)x;
			float yBorder = num2 - (float)y;
			float zBorder = num3 - (float)z;
			borderIndex = (BORDER_MASK)0;
			SetBorder(xBorder, yBorder, zBorder);
		}

		private void SetBorder(float xBorder, float yBorder, float zBorder)
		{
			if (xBorder < EpsilonLowerBorder)
			{
				borderIndex |= BORDER_MASK.XLow;
			}
			else if (xBorder > EpsilonUpperBorder)
			{
				borderIndex |= BORDER_MASK.XUp;
			}
			if (yBorder < EpsilonLowerBorder)
			{
				borderIndex |= BORDER_MASK.YLow;
			}
			else if (yBorder > EpsilonUpperBorder)
			{
				borderIndex |= BORDER_MASK.YUp;
			}
			if (zBorder < EpsilonLowerBorder)
			{
				borderIndex |= BORDER_MASK.ZLow;
			}
			else if (zBorder > EpsilonUpperBorder)
			{
				borderIndex |= BORDER_MASK.ZUp;
			}
		}

		public VertexKey(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			borderIndex = (BORDER_MASK)0;
		}

		public List<VertexKey> GetAroundKeys(List<VertexKey> aroundKeyList)
		{
			if (aroundKeyList == null)
			{
				aroundKeyList = new List<VertexKey>();
			}
			else
			{
				aroundKeyList.Clear();
			}
			if (borderIndex != 0)
			{
				int i = (((borderIndex & BORDER_MASK.XLow) != 0) ? (-1) : 0);
				int num = (((borderIndex & BORDER_MASK.XUp) != 0) ? 2 : 0);
				int j = (((borderIndex & BORDER_MASK.YLow) != 0) ? (-1) : 0);
				int num2 = (((borderIndex & BORDER_MASK.YUp) != 0) ? 2 : 0);
				int k = (((borderIndex & BORDER_MASK.ZLow) != 0) ? (-1) : 0);
				int num3 = (((borderIndex & BORDER_MASK.ZUp) != 0) ? 2 : 0);
				for (; i < num; i++)
				{
					for (; j < num2; j++)
					{
						for (; k < num3; k++)
						{
							if (i != 0 || j != 0 || k != 0)
							{
								aroundKeyList.Add(new VertexKey(x + i, y + j, z + k));
							}
						}
					}
				}
			}
			return aroundKeyList;
		}
	}
}
