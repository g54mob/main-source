using DV.Utils;
using DV.WorldTools;
using UnityEngine;

namespace DV.VFX
{
	public class HazmatLighting : MonoBehaviour
	{
		public GameObject prefab;

		public int range = 7;

		public int cellCoverage = 3;

		private HazmatLight[,] matrix;

		private Vector2Int[,] cellTileOrigin;

		private float cellSize;

		private Vector2Int cellOrigin = Vector2Int.zero;

		private bool initialized;

		private void Awake()
		{
			cellSize = 8f;
			matrix = new HazmatLight[range, range];
			cellTileOrigin = new Vector2Int[range, range];
			float num = ((float)range - 1f) / 2f;
			Transform originShiftParent = WorldMover.OriginShiftParent;
			for (int i = 0; i < range; i++)
			{
				for (int j = 0; j < range; j++)
				{
					float num2 = Mathf.Abs((float)i - num);
					float num3 = Mathf.Abs((float)j - num);
					if (Mathf.Sqrt(num2 * num2 + num3 * num3) <= num)
					{
						GameObject gameObject = Object.Instantiate(prefab.gameObject, originShiftParent);
						gameObject.name = "HazmatLight_X" + i.ToString("00") + "_Y" + j.ToString("00");
						matrix[i, j] = new HazmatLight(gameObject);
					}
				}
			}
			if (Camera.main != null)
			{
				Initialize();
			}
		}

		private void Initialize()
		{
			cellOrigin = GetCellCoords(Camera.main.transform.position);
			Arrange();
			initialized = true;
		}

		private void OnDrawGizmos()
		{
			if (matrix == null)
			{
				return;
			}
			for (int i = 0; i < range; i++)
			{
				for (int j = 0; j < range; j++)
				{
					if (matrix[i, j] != null)
					{
						Gizmos.color = (matrix[i, j].IsOn ? Color.yellow : Color.green);
						Gizmos.DrawWireCube(matrix[i, j].Transform.position, Vector3.one * cellSize);
					}
				}
			}
		}

		private void Arrange()
		{
			_ = SingletonBehaviour<HazmatTileManager>.Instance;
			for (int i = 0; i < range; i++)
			{
				for (int j = 0; j < range; j++)
				{
					Vector2Int cellCoords = new Vector2Int(cellOrigin.x + i - range / 2, cellOrigin.y + j - range / 2);
					if (matrix[i, j] != null)
					{
						HazmatLight hazmatLight = matrix[i, j];
						Vector3 originPoint = (matrix[i, j].Transform.localPosition = GetWorldCoords(cellCoords, worldShift: false) + Vector3.up * 3f);
						hazmatLight.originPoint = originPoint;
					}
					cellTileOrigin[i, j] = new Vector2Int(cellCoords.x * cellCoverage, cellCoords.y * cellCoverage);
				}
			}
		}

		private void Update()
		{
			if (SingletonBehaviour<AppUtil>.Instance.IsTimePausedSafer)
			{
				return;
			}
			if (!initialized)
			{
				if (!(Camera.main != null))
				{
					return;
				}
				Initialize();
			}
			else if (Camera.main == null)
			{
				initialized = false;
				return;
			}
			HazmatTileManager instance = SingletonBehaviour<HazmatTileManager>.Instance;
			Vector2Int cellCoords = GetCellCoords(Camera.main.transform.position);
			if (cellCoords != cellOrigin)
			{
				Vector2Int vector2Int = cellCoords - cellOrigin;
				bool flag = vector2Int.x >= 0;
				bool flag2 = vector2Int.y >= 0;
				if (Mathf.Abs(vector2Int.x) < range && Mathf.Abs(vector2Int.y) < range)
				{
					int num = ((!flag) ? (range - 1) : 0);
					int num2 = ((!flag2) ? (range - 1) : 0);
					int num3 = (flag ? range : (-1));
					int num4 = (flag2 ? range : (-1));
					int num5 = (flag ? 1 : (-1));
					int num6 = (flag2 ? 1 : (-1));
					for (int i = num; i != num3; i += num5)
					{
						for (int j = num2; j != num4; j += num6)
						{
							if (matrix[i, j] != null)
							{
								int num7 = i + vector2Int.x;
								int num8 = j + vector2Int.y;
								if (num7 >= 0 && num7 < range && num8 >= 0 && num8 < range && matrix[num7, num8] != null)
								{
									matrix[i, j].Replicate(matrix[num7, num8]);
									cellTileOrigin[i, j] = cellTileOrigin[num7, num8];
									continue;
								}
								Vector2Int cellCoords2 = new Vector2Int(cellCoords.x + i - range / 2, cellCoords.y + j - range / 2);
								HazmatLight hazmatLight = matrix[i, j];
								Vector3 originPoint = (matrix[i, j].Transform.localPosition = GetWorldCoords(cellCoords2, worldShift: false) + Vector3.up * 3f);
								hazmatLight.originPoint = originPoint;
								cellTileOrigin[i, j] = new Vector2Int(cellCoords2.x * cellCoverage, cellCoords2.y * cellCoverage);
								matrix[i, j].Reset();
							}
						}
					}
				}
				else
				{
					Arrange();
				}
				cellOrigin = cellCoords;
				return;
			}
			Vector3 position = Camera.main.transform.position;
			float deltaTime = Time.deltaTime;
			for (int k = 0; k < range; k++)
			{
				for (int l = 0; l < range; l++)
				{
					if (matrix[k, l] == null)
					{
						continue;
					}
					int num9 = 0;
					int num10 = 0;
					int num11 = 0;
					for (int m = 0; m < cellCoverage; m++)
					{
						for (int n = 0; n < cellCoverage; n++)
						{
							HazmatGridTile tileFromCoords = instance.GetTileFromCoords(cellTileOrigin[k, l].x + m, cellTileOrigin[k, l].y + n, autoCreate: false);
							if (tileFromCoords != null && tileFromCoords.IsIgnited)
							{
								num11++;
								num9 += cellTileOrigin[k, l].x + m;
								num10 += cellTileOrigin[k, l].y + n;
							}
						}
					}
					if (num11 > 0)
					{
						Vector3 vector2 = new Vector3((float)num9 / (float)num11 * 8f, 0f, (float)num10 / (float)num11 * 8f);
						vector2.y = HeightMapProvider.GetInterpolated(vector2, usingWorldShift: false);
						vector2 += Vector3.up * 3f;
						if (matrix[k, l].IsOn)
						{
							matrix[k, l].TransitionPosition(vector2);
						}
						else
						{
							matrix[k, l].originPoint = vector2 + Vector3.up * 3f;
						}
					}
					matrix[k, l].SetIntensity((num11 > 0) ? 1f : 0f);
					matrix[k, l].multiplier = 1f - Mathf.Clamp01(Vector3.Distance(matrix[k, l].Transform.position, position) / ((float)range / 2f * ((float)cellCoverage * cellSize)));
					if (matrix[k, l].IsOn)
					{
						matrix[k, l].Tick(deltaTime);
					}
				}
			}
		}

		private Vector3 GetWorldCoords(Vector2Int cellCoords, bool worldShift = true)
		{
			return GetWorldCoords(cellCoords.x, cellCoords.y, worldShift);
		}

		private Vector3 GetWorldCoords(int x, int y, bool worldShift = true)
		{
			Vector3 vector = new Vector3((float)x * cellSize * (float)cellCoverage, 0f, (float)y * cellSize * (float)cellCoverage);
			vector.y = HeightMapProvider.GetInterpolated(vector, usingWorldShift: false);
			if (worldShift)
			{
				return vector + WorldMover.currentMove;
			}
			return vector;
		}

		private Vector2Int GetCellCoords(Vector3 worldPos)
		{
			worldPos -= WorldMover.currentMove;
			int y = Mathf.FloorToInt(worldPos.z / (cellSize * (float)cellCoverage));
			return new Vector2Int(Mathf.FloorToInt(worldPos.x / (cellSize * (float)cellCoverage)), y);
		}
	}
}
