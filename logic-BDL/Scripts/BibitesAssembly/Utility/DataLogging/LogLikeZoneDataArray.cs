using System;

namespace Utility.DataLogging
{
	public class LogLikeZoneDataArray : LogLikePresenceArray<ZoneDataPoint>
	{
		public override byte sizeOfPoint => ZoneDataPoint.sizeOfPoint;

		public LogLikeZoneDataArray()
			: base(DataLogger.SerialSpeciesConfig, (Func<ZoneDataPoint[], Func<int, int>, int, ZoneDataPoint>)null)
		{
			compressFunc = CompressFunction;
		}

		private ZoneDataPoint CompressFunction(ZoneDataPoint[] array, Func<int, int> remapFunc, int n)
		{
			ZoneDataPoint result = default(ZoneDataPoint);
			int num = 0;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			int[] array2 = new int[n];
			for (int i = 0; i < n; i++)
			{
				array2[i] = remapFunc(i);
			}
			for (int j = 0; j < n; j++)
			{
				ZoneDataPoint point = array[array2[j]];
				if (PointIsPresent(point))
				{
					num++;
					num5 += point.fertility;
					num2 += (float)point.posX * point.fertility;
					num3 += (float)point.posY * point.fertility;
					num4 += (float)(int)point.radius * point.fertility;
					num6 += point.biomass;
				}
			}
			if (num < 1)
			{
				return result;
			}
			result.posX = (short)(num2 / num5);
			result.posY = (short)(num3 / num5);
			result.radius = (ushort)(num4 / num5);
			result.fertility = num5 / (float)num;
			result.biomass = num6 / (float)num;
			return result;
		}

		public override bool PointIsPresent(ZoneDataPoint point)
		{
			return point.present;
		}

		protected override Array[] CreateTempArrays(int nPointsSaved)
		{
			short[] array = new short[2 * nPointsSaved];
			ushort[] array2 = new ushort[nPointsSaved];
			float[] array3 = new float[nPointsSaved];
			float[] array4 = new float[nPointsSaved];
			return new Array[4] { array, array2, array3, array4 };
		}

		protected override void SavePointToArrays(Array[] arrays, ZoneDataPoint point, int arrayIndexOffset)
		{
			((short[])arrays[0])[2 * arrayIndexOffset] = point.posX;
			((short[])arrays[0])[2 * arrayIndexOffset + 1] = point.posY;
			((ushort[])arrays[1])[arrayIndexOffset] = point.radius;
			((float[])arrays[2])[arrayIndexOffset] = point.fertility;
			((float[])arrays[3])[arrayIndexOffset] = point.biomass;
		}

		protected override ZoneDataPoint LoadPointFromArrays(Array[] arrays, int arrayIndexOffset)
		{
			return new ZoneDataPoint
			{
				posX = ((short[])arrays[0])[2 * arrayIndexOffset],
				posY = ((short[])arrays[0])[2 * arrayIndexOffset + 1],
				radius = ((ushort[])arrays[1])[arrayIndexOffset],
				fertility = ((float[])arrays[2])[arrayIndexOffset],
				biomass = ((float[])arrays[3])[arrayIndexOffset]
			};
		}

		protected override void SaveArraysToBin(Array[] arrays, byte[] bytes, int offset, int nPointsSaved)
		{
			Buffer.BlockCopy(arrays[0], 0, bytes, offset, 4 * nPointsSaved);
			Buffer.BlockCopy(arrays[1], 0, bytes, offset + 4 * nPointsSaved, 2 * nPointsSaved);
			Buffer.BlockCopy(arrays[2], 0, bytes, offset + 6 * nPointsSaved, 4 * nPointsSaved);
			Buffer.BlockCopy(arrays[3], 0, bytes, offset + 10 * nPointsSaved, 4 * nPointsSaved);
		}

		protected override void LoadArraysFromBin(Array[] arrays, byte[] bytes, Version version, int offset, int nPointsSaved)
		{
			Buffer.BlockCopy(bytes, offset, arrays[0], 0, 4 * nPointsSaved);
			Buffer.BlockCopy(bytes, offset + 4 * nPointsSaved, arrays[1], 0, 2 * nPointsSaved);
			Buffer.BlockCopy(bytes, offset + 6 * nPointsSaved, arrays[2], 0, 4 * nPointsSaved);
			Buffer.BlockCopy(bytes, offset + 10 * nPointsSaved, arrays[3], 0, 4 * nPointsSaved);
		}
	}
}
