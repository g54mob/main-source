using NSMedieval.Water;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace NSMedieval.Fire
{
	[BurstCompile]
	public struct FireLogicJob : IJob
	{
		public NativeArray<float> FireDamageAccumulated;

		public NativeArray<float> FireDataNative;

		public NativeArray<byte> FireNeighborsArray;

		[ReadOnly]
		public NativeArray<bool> IsPlantCanopy;

		public NativeArray<int> NeighborFlameTypes;

		public NativeParallelHashSet<int> IsFireNeighbor;

		[ReadOnly]
		public int DataLength;

		[ReadOnly]
		public float RainAmount;

		[ReadOnly]
		public float SnowAmount;

		[ReadOnly]
		public float GrassFlammabilityBySeason;

		[ReadOnly]
		public float DeltaTime;

		[ReadOnly]
		public bool CanSpreadToNeighbors;

		[ReadOnly]
		public NativeArray<float> FlammabilityNative;

		[ReadOnly]
		public NativeArray<uint> SnowGrassWetness;

		[ReadOnly]
		public NativeArray<bool> Coverage;

		[WriteOnly]
		public NativeParallelHashSet<int> FireNodesAdded;

		[WriteOnly]
		public NativeParallelHashSet<int> FireNodesRemoved;

		[ReadOnly]
		public int MapSizeX;

		[ReadOnly]
		public int MapSizeY;

		[ReadOnly]
		public int MapSizeZ;

		[ReadOnly]
		public NativeArray<int> NeighborsX;

		[ReadOnly]
		public NativeArray<int> NeighborsY;

		[ReadOnly]
		public NativeArray<int> NeighborsZ;

		[ReadOnly]
		public NativeArray<int> Neighbors3dX;

		[ReadOnly]
		public NativeArray<int> Neighbors3dY;

		[ReadOnly]
		public NativeArray<int> Neighbors3dZ;

		[ReadOnly]
		public NativeArray<float> WaterDataDisplay;

		public NativeArray<int> IntProperties;

		public NativeArray<int> FlameCountByFlameType;

		public NativeArray<int> NodesOnFireArray;

		[WriteOnly]
		public NativeArray<int> OilBlobNodesArray;

		public NativeArray<byte> FlameType;

		public NativeArray<float> GridHealthOverride;

		[WriteOnly]
		public NativeArray<float> FireTemperature;

		[ReadOnly]
		public Random RandomGenerator;

		public NativeArray<float> OilBlobHealth;

		[ReadOnly]
		public NativeArray<byte> OilBlobType;

		[ReadOnly]
		public int FrameCount;

		[ReadOnly]
		public NativeArray<float> TemperatureByFlameType;

		private static readonly float[] BurnSpeedByFlameType = new float[2] { 0.2f, 1f };

		private static readonly float[] DieOutSpeedByFlameType = new float[2] { 0.5f, 0.25f };

		private static readonly float[] DamageMultiplierByFlameType = new float[2] { 0.03f, 0.3f };

		private static readonly float[] DamageMultiplierForHealthOverride = new float[2] { 0.5f, 1f };

		private static readonly float[] WaterDamageByFlameType = new float[2] { 4f, 0f };

		private static readonly float[] WetnessMultiplierByFlameType = new float[2] { 1f, 0f };

		private static readonly float[] RainDecreaseFireHp = new float[2] { 0.08f, 0f };

		private static readonly float[] SnowDecreaseFireHp = new float[2] { 0.01f, 0f };

		private static readonly byte[] SpreadFlameType = new byte[2];

		public static readonly float[] WaterFlameDecreaseOnAgents = new float[2] { 0.4f, 0.06f };

		public static readonly float[] DamageOilByFlameType = new float[2] { 0.15f, 0.05f };

		public static readonly byte[] SpreadFlameByOilType = new byte[2] { 0, 1 };

		public static readonly byte[] MaxWaterLevelSpreadByOilType = new byte[2] { 0, 1 };

		private const float GrassMinPercent = 0.6f;

		private const float FlameHealthMinimumSpread = 0.4f;

		private byte GetWaterLevelAt(int index)
		{
			float num = WaterDataDisplay[index];
			if (num <= 0f)
			{
				return 0;
			}
			if (num < WaterConstants.WaterLevelsStart[0])
			{
				return 1;
			}
			if (num < WaterConstants.WaterLevelsStart[1])
			{
				return 2;
			}
			return 3;
		}

		public int GetNodesOnFireCount()
		{
			return IntProperties[0];
		}

		public int GetOilBlobsCount()
		{
			return IntProperties[1];
		}

		public void Execute()
		{
			bool flag = false;
			int num = 0;
			int num2 = 0;
			FlameCountByFlameType[0] = 0;
			FlameCountByFlameType[1] = 0;
			for (int i = 0; i < DataLength; i++)
			{
				NeighborFlameTypes[i] = 0;
				byte b = FlameType[i];
				if (OilBlobHealth[i] > 0f)
				{
					if (FireDataNative[i] > 0f)
					{
						if (!flag)
						{
							flag = true;
						}
						OilBlobHealth[i] = math.max(OilBlobHealth[i] - FireDataNative[i] * DamageOilByFlameType[b] * DeltaTime, 0f);
					}
					OilBlobNodesArray[num2] = i;
					num2++;
				}
				FireNeighborsArray[i] = 0;
				if (FireDataNative[i] > 0f)
				{
					bool flag2 = Coverage[i];
					FireDataNative[i] = math.clamp(FireDataNative[i] + DeltaTime * GetFlameAddValue(i, flag2), 0f, 1f);
					float num3 = (flag2 ? 0f : (RainAmount * RainDecreaseFireHp[b] + SnowAmount * SnowDecreaseFireHp[b]));
					if (WaterDataDisplay[i] > 0f && WaterDamageByFlameType[b] > 0f)
					{
						num3 += WaterDamageByFlameType[b];
					}
					if (num3 > 0f)
					{
						FireDataNative[i] = math.clamp(FireDataNative[i] - DeltaTime * num3, 0f, 1f);
					}
					if (FireDataNative[i] > 0f)
					{
						NodesOnFireArray[num] = i;
						num++;
						FlameCountByFlameType[FlameType[i]]++;
						if (GetFlammability(i) > 0f)
						{
							float num4 = FireDataNative[i] * DeltaTime * (1f - GetWetness(i));
							FireDamageAccumulated[i] += DamageMultiplierByFlameType[b] * num4;
							if (GridHealthOverride[i] > 0f)
							{
								GridHealthOverride[i] -= DamageMultiplierForHealthOverride[b] * num4;
							}
						}
						FireTemperature[i] = FireDataNative[i] * TemperatureByFlameType[b];
					}
					else if (FireDataNative[i] <= 0f)
					{
						FireNodesRemoved.Add(i);
						FlameType[i] = 0;
						FireDamageAccumulated[i] = 0f;
						FireDataNative[i] = 0f;
						GridHealthOverride[i] = 0f;
					}
				}
				else
				{
					FireTemperature[i] = 0f;
				}
			}
			bool flag3 = false;
			int length = NeighborsX.Length;
			if (CanSpreadToNeighbors || flag)
			{
				for (int j = 0; j < num; j++)
				{
					int index = NodesOnFireArray[j];
					bool flag4 = OilBlobHealth[index] > 0f;
					if (!CanSpreadToNeighbors && flag && !flag4)
					{
						continue;
					}
					bool flag5 = WaterDataDisplay[index] > 0f;
					bool flag6 = FireDataNative[index] > 0.4f || (flag4 && FireDataNative[index] > 0.3f);
					if (flag6 && FlameType[index] != 1 && flag5)
					{
						flag6 = false;
					}
					if (flag6)
					{
						byte b2 = OilBlobType[index];
						byte b3 = MaxWaterLevelSpreadByOilType[b2];
						if (GetWaterLevelAt(index) > b3)
						{
							flag6 = false;
						}
					}
					if (!flag6)
					{
						continue;
					}
					byte b4 = FlameType[index];
					byte b6;
					if (flag4)
					{
						byte b5 = OilBlobType[index];
						b6 = SpreadFlameByOilType[b5];
						if (b4 != b6)
						{
							FlameType[index] = b6;
						}
					}
					else
					{
						b6 = SpreadFlameType[b4];
					}
					if (b6 == byte.MaxValue)
					{
						continue;
					}
					int x = GetX(index);
					int y = GetY(index);
					int z = GetZ(index);
					for (int k = 0; k < length; k++)
					{
						int x2 = x + NeighborsX[k];
						int y2 = y + NeighborsY[k];
						int z2 = z + NeighborsZ[k];
						if (InRangeX(x2) && InRangeZ(z2) && InRangeY(y2) && (flag4 || !(RandomGenerator.NextFloat() <= 0.25f)))
						{
							int num5 = FastTo1DIndexNoCheck(x2, y2, z2);
							if (CanSpreadTo(num5) && (!(RainAmount > 0f) || Coverage[num5] || OilBlobType[num5] == 1) && FireDataNative[num5] <= 0f && CanCatchFireHorizontal(num5))
							{
								FireNeighborsArray[num5] = 1;
								FlameType[num5] = b6;
								flag3 = true;
							}
						}
					}
				}
			}
			if (flag3)
			{
				for (int l = 0; l < DataLength; l++)
				{
					if (FireNeighborsArray[l] != 0 && FireDataNative[l] <= 0f && GetFlammability(l) >= 0.5f)
					{
						FireNodesAdded.Add(l);
						FireDataNative[l] = 0.01f;
						NodesOnFireArray[num] = l;
						num++;
					}
				}
			}
			IntProperties[0] = num;
			IntProperties[1] = num2;
			CheckIsFireNeighbor();
		}

		private bool CanSpreadTo(int neighborIndex)
		{
			if (FireNeighborsArray[neighborIndex] != 0)
			{
				return false;
			}
			if (GetFlammability(neighborIndex) <= 0f)
			{
				return false;
			}
			if (WaterDataDisplay[neighborIndex] <= 0f)
			{
				return true;
			}
			if (OilBlobHealth[neighborIndex] > 0f)
			{
				byte b = OilBlobType[neighborIndex];
				byte num = MaxWaterLevelSpreadByOilType[b];
				byte waterLevelAt = GetWaterLevelAt(neighborIndex);
				if (num >= waterLevelAt)
				{
					return true;
				}
			}
			return false;
		}

		private void CheckIsFireNeighbor()
		{
			int length = Neighbors3dX.Length;
			IsFireNeighbor.Clear();
			int nodesOnFireCount = GetNodesOnFireCount();
			for (int i = 0; i < nodesOnFireCount; i++)
			{
				int index = NodesOnFireArray[i];
				byte b = FlameType[index];
				if (!(FireDataNative[index] > 0f))
				{
					continue;
				}
				int x = GetX(index);
				int y = GetY(index);
				int z = GetZ(index);
				if (OilBlobHealth[index] > 0f)
				{
					continue;
				}
				for (int j = 0; j < length; j++)
				{
					int x2 = x + Neighbors3dX[j];
					int y2 = y + Neighbors3dY[j];
					int z2 = z + Neighbors3dZ[j];
					if (InRangeX(x2) && InRangeZ(z2) && InRangeY(y2))
					{
						int num = FastTo1DIndexNoCheck(x2, y2, z2);
						if (FireDataNative[num] <= 0f)
						{
							IsFireNeighbor.Add(num);
							NeighborFlameTypes[num] |= 1 << (int)b;
						}
					}
				}
			}
		}

		private float GetWetness(int index)
		{
			byte b = FlameType[index];
			return WetnessMultiplierByFlameType[b] * (float)((SnowGrassWetness[index] >> 8) & 0xFF) / 255f;
		}

		private byte GetSnow(int index)
		{
			return (byte)(SnowGrassWetness[index] & 0xFF);
		}

		public float GetGrassHealth(int index)
		{
			return (float)(SnowGrassWetness[index] >> 16) / 65535f;
		}

		private float GetFlameAddValue(int index, bool isCovered)
		{
			byte b = FlameType[index];
			float num = GetFlammability(index) - GetWetness(index) * 1.6f;
			float num2 = num - 0.5f;
			float num3 = BurnSpeedByFlameType[b];
			if (RainAmount > 0f && !isCovered)
			{
				num3 = math.max(num3 * 0.15f, (1f - RainAmount) * num3);
			}
			bool num4 = OilBlobHealth[index] > 0f;
			if (num4)
			{
				num3 += 11f;
			}
			float num5 = (num4 ? 1f : RandomGenerator.NextFloat());
			float num6 = ((num >= 0.5f) ? num3 : DieOutSpeedByFlameType[b]);
			return num2 * num6 * num5;
		}

		private int GetX(int index)
		{
			return index % MapSizeX;
		}

		private int GetY(int index)
		{
			return index / MapSizeX % MapSizeY;
		}

		private int GetZ(int index)
		{
			return index / (MapSizeX * MapSizeY);
		}

		private bool InRangeX(int x)
		{
			if (x >= 0)
			{
				return x < MapSizeX;
			}
			return false;
		}

		private bool InRangeY(int y)
		{
			if (y >= 0)
			{
				return y < MapSizeY;
			}
			return false;
		}

		private bool InRangeZ(int z)
		{
			if (z >= 0)
			{
				return z < MapSizeZ;
			}
			return false;
		}

		private int FastTo1DIndexNoCheck(int x, int y, int z)
		{
			return x + y * MapSizeX + z * MapSizeX * MapSizeY;
		}

		private bool CanCatchFireHorizontal(int nodeIndex)
		{
			if (IsPlantCanopy[nodeIndex] && FlammabilityNative[nodeIndex] <= 0f)
			{
				return true;
			}
			if (OilBlobHealth[nodeIndex] > 0f)
			{
				return true;
			}
			return GetFlammability(nodeIndex) - GetWetness(nodeIndex) > 0.5f;
		}

		private float GetFlammability(int index)
		{
			if (FlammabilityNative[index] <= -1f)
			{
				return 0f;
			}
			if (GridHealthOverride[index] > 0f)
			{
				return 1f;
			}
			if (IsPlantCanopy[index] && FlammabilityNative[index] <= 0f)
			{
				return 1f;
			}
			if (OilBlobHealth[index] > 0f)
			{
				return 1f;
			}
			float grassHealth = GetGrassHealth(index);
			float num = FlammabilityNative[index];
			if (grassHealth > 0f && grassHealth <= 0.6f && num > 0f)
			{
				return num;
			}
			return math.max(num, grassHealth * GrassFlammabilityBySeason);
		}
	}
}
