using System;
using SettingScripts;
using UnityEngine;

namespace Utility
{
	public class LogLikeSpeciesDataArray : LogLikePresenceArray<SpeciesDataPoint>
	{
		private readonly bool absolutePreserve;

		private float simSizeFactor;

		public override byte sizeOfPoint => SpeciesDataPoint.byteSize;

		public LogLikeSpeciesDataArray(bool isTemplate)
			: base(DataLogger.SerialSpeciesConfig, (Func<SpeciesDataPoint[], Func<int, int>, int, SpeciesDataPoint>)null)
		{
			compressFunc = CompressFunction;
			absolutePreserve = isTemplate;
		}

		private SpeciesDataPoint CompressFunction(SpeciesDataPoint[] array, Func<int, int> remapFunc, int n)
		{
			SpeciesDataPoint result = default(SpeciesDataPoint);
			int num = 0;
			int num2 = 0;
			float num3 = 0f;
			Vector2 zero = Vector2.zero;
			Vector2 zero2 = Vector2.zero;
			float num4 = 0f;
			int[] array2 = new int[n];
			for (int i = 0; i < n; i++)
			{
				array2[i] = remapFunc(i);
			}
			for (int j = 0; j < n; j++)
			{
				SpeciesDataPoint speciesDataPoint = array[array2[j]];
				if (speciesDataPoint.alive)
				{
					num++;
					num2 += speciesDataPoint.count;
					num3 += speciesDataPoint.energy;
					zero += speciesDataPoint.avgPos * speciesDataPoint.energy;
					num4 += speciesDataPoint.espXY * speciesDataPoint.energy;
				}
			}
			if ((!absolutePreserve && num < (n + 1) / 2) || (absolutePreserve && num < 1))
			{
				return result;
			}
			result.count = (ushort)Mathf.Max(1, num2 / num);
			result.energy = num3 / (float)num;
			result.avgPos = zero / num3;
			for (int k = 0; k < n; k++)
			{
				SpeciesDataPoint speciesDataPoint2 = array[array2[k]];
				if (speciesDataPoint2.alive)
				{
					zero2 += speciesDataPoint2.StdDevWithPos(result.avgPos) * speciesDataPoint2.energy;
				}
			}
			result.posStdDev = new Vector2(Mathf.Sqrt(zero2.x / num3), Mathf.Sqrt(zero2.y / num3));
			result.posCor = (num4 / num3 - result.avgPos.x * result.avgPos.y) / (result.posStdDev.x * result.posStdDev.y);
			return result;
		}

		public void IncorporateSpeciesData(LogLikeSpeciesDataArray toIncorporateArray)
		{
			for (int i = toIncorporateArray.scaleOfDisappearance; i <= toIncorporateArray.scaleOfApparition; i++)
			{
				int num = toIncorporateArray.DataSizeAtScale(i);
				int num2 = ((i == toIncorporateArray.scaleOfDisappearance) ? (toIncorporateArray.indexOfDisappearance + 1) : 0);
				int num3 = ((i == toIncorporateArray.scaleOfApparition) ? toIncorporateArray.indexOfApparition : (num - 1));
				if (num2 < 0 || num3 < 0)
				{
					continue;
				}
				if (num3 == num - 1)
				{
					num3 += toIncorporateArray.feedRatios[i];
				}
				for (int j = num2; j <= num3; j++)
				{
					SpeciesDataPoint value = base[i, j];
					SpeciesDataPoint speciesDataPoint = toIncorporateArray[i, j];
					if (!speciesDataPoint.alive)
					{
						continue;
					}
					bool alive = value.alive;
					float energy = value.energy;
					float energy2 = speciesDataPoint.energy;
					float num4 = energy + energy2;
					Vector2 vector = (value.avgPos * energy + speciesDataPoint.avgPos * energy2) / num4;
					Vector2 vector2 = (value.StdDevWithPos(vector) * energy + speciesDataPoint.StdDevWithPos(vector) * energy2) / num4;
					float num5 = (value.espXY * energy + speciesDataPoint.espXY * energy2) / num4;
					value.avgPos = vector;
					value.posStdDev = new Vector2(Mathf.Sqrt(vector2.x), Mathf.Sqrt(vector2.y));
					value.posCor = (num5 - vector.x * vector.y) / (value.posStdDev.x * value.posStdDev.y);
					value.count += speciesDataPoint.count;
					value.energy = num4;
					base[i, j] = value;
					if (!alive && j <= num - 1)
					{
						if (i > scaleOfApparition || (i == scaleOfApparition && j > indexOfApparition))
						{
							scaleOfApparition = (byte)i;
							indexOfApparition = (short)j;
						}
						if (i < scaleOfDisappearance || (i == scaleOfDisappearance && j <= indexOfDisappearance))
						{
							scaleOfDisappearance = (byte)i;
							indexOfDisappearance = (short)(j - 1);
						}
					}
				}
			}
			RefreshPresentsFromIndices();
		}

		public override bool PointIsPresent(SpeciesDataPoint point)
		{
			return point.alive;
		}

		protected override Array[] CreateTempArrays(int nPointsSaved)
		{
			ushort[] array = new ushort[nPointsSaved];
			float[] array2 = new float[nPointsSaved];
			short[] array3 = new short[2 * nPointsSaved];
			ushort[] array4 = new ushort[2 * nPointsSaved];
			short[] array5 = new short[nPointsSaved];
			simSizeFactor = 32767f / ScenarioIndependentSettings.Instance.SimulationSize.val / 2f;
			return new Array[5] { array, array2, array3, array4, array5 };
		}

		protected override void SavePointToArrays(Array[] arrays, SpeciesDataPoint point, int arrayIndexOffset)
		{
			((ushort[])arrays[0])[arrayIndexOffset] = point.count;
			((float[])arrays[1])[arrayIndexOffset] = point.energy;
			((short[])arrays[2])[2 * arrayIndexOffset] = (short)(point.avgPos.x * simSizeFactor);
			((short[])arrays[2])[2 * arrayIndexOffset + 1] = (short)(point.avgPos.y * simSizeFactor);
			((ushort[])arrays[3])[2 * arrayIndexOffset] = (ushort)(point.posStdDev.x * 2f * simSizeFactor);
			((ushort[])arrays[3])[2 * arrayIndexOffset + 1] = (ushort)(point.posStdDev.y * 2f * simSizeFactor);
			((short[])arrays[4])[arrayIndexOffset] = (short)(point.posCor * 32766f);
		}

		protected override SpeciesDataPoint LoadPointFromArrays(Array[] arrays, int arrayIndexOffset)
		{
			return new SpeciesDataPoint
			{
				count = ((ushort[])arrays[0])[arrayIndexOffset],
				energy = ((float[])arrays[1])[arrayIndexOffset],
				avgPos = new Vector2(((short[])arrays[2])[2 * arrayIndexOffset], ((short[])arrays[2])[2 * arrayIndexOffset + 1]) / simSizeFactor,
				posStdDev = new Vector2((int)((ushort[])arrays[3])[2 * arrayIndexOffset], (int)((ushort[])arrays[3])[2 * arrayIndexOffset + 1]) / (2f * simSizeFactor),
				posCor = (float)((short[])arrays[4])[arrayIndexOffset] / 32767f
			};
		}

		protected override void SaveArraysToBin(Array[] arrays, byte[] bytes, int offset, int nPointsSaved)
		{
			Buffer.BlockCopy(arrays[0], 0, bytes, offset, 2 * nPointsSaved);
			Buffer.BlockCopy(arrays[1], 0, bytes, offset + 2 * nPointsSaved, 4 * nPointsSaved);
			Buffer.BlockCopy(arrays[2], 0, bytes, offset + 6 * nPointsSaved, 4 * nPointsSaved);
			Buffer.BlockCopy(arrays[3], 0, bytes, offset + 10 * nPointsSaved, 4 * nPointsSaved);
			Buffer.BlockCopy(arrays[4], 0, bytes, offset + 14 * nPointsSaved, 2 * nPointsSaved);
		}

		protected override void LoadArraysFromBin(Array[] arrays, byte[] bytes, Version version, int offset, int nPointsSaved)
		{
			Buffer.BlockCopy(bytes, offset, arrays[0], 0, 2 * nPointsSaved);
			Buffer.BlockCopy(bytes, offset + 2 * nPointsSaved, arrays[1], 0, 4 * nPointsSaved);
			Buffer.BlockCopy(bytes, offset + 6 * nPointsSaved, arrays[2], 0, 4 * nPointsSaved);
			Buffer.BlockCopy(bytes, offset + 10 * nPointsSaved, arrays[3], 0, 4 * nPointsSaved);
			Buffer.BlockCopy(bytes, offset + 14 * nPointsSaved, arrays[4], 0, 2 * nPointsSaved);
		}
	}
}
