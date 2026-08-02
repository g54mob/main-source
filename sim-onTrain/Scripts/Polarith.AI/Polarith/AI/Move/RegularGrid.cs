using System;
using System.Collections.Generic;
using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[Serializable]
	public sealed class RegularGrid
	{
		[Tooltip("Defines the number of cells along the x-axis, needs to be at least 1.")]
		[OpenRangeMin(1f)]
		public int CellCountX = 16;

		[Tooltip("Defines the number of cells along the y-axis, needs to be at least 1.")]
		[OpenRangeMin(1f)]
		public int CellCountY = 16;

		[Tooltip("Defines the number of cells along the z-axis, needs to be at least 1.")]
		[OpenRangeMin(1f)]
		public int CellCountZ = 16;

		[Tooltip("Defines the size of single cells along the x-axis in Unity units, needs to be greater than 0.")]
		[OpenRangeMin(1E-06f)]
		public float CellSizeX = 8f;

		[Tooltip("Defines the size of single cells along the y-axis in Unity units, needs to be greater than 0.")]
		[OpenRangeMin(1E-06f)]
		public float CellSizeY = 8f;

		[Tooltip("Defines the size of single cells along the z-axis in Unity units, needs to be greater than 0.")]
		[OpenRangeMin(1E-06f)]
		public float CellSizeZ = 8f;

		[Tooltip("A gizmo that displays the grid in the scene view.")]
		public GridGizmo GridGizmo = new GridGizmo();

		private Dictionary<string, int> envIdxDic;

		private List<List<SteeringPercept>[]> grid;

		private Vector3 gridCenter;

		private float gridSizeX;

		private float gridSizeY;

		private float gridSizeZ;

		private float gridExtentX;

		private float gridExtentY;

		private float gridExtentZ;

		private int envCount;

		private int envIdx;

		private int cellCountX;

		private int cellCountY;

		private int cellCountZ;

		public void DrawGizmo(Vector3 center)
		{
			GridGizmo.Draw(center, CellSizeX, CellSizeY, CellSizeZ, CellCountX, CellCountY, CellCountZ);
		}

		public void Initialize(IList<AIMEnvironment> environments)
		{
			Initialize(environments, CellCountX, CellCountY, CellCountZ);
		}

		public void Initialize(IList<AIMEnvironment> environments, int cellCountX, int cellCountY, int cellCountZ)
		{
			if (cellCountX < 1 || cellCountY < 1 || cellCountZ < 1)
			{
				Debug.LogError("(" + typeof(AIMSteeringPerceiver).Name + ") " + typeof(RegularGrid).Name + ": the specified grid size is smaller than 1 for at least one dimension, the grid was not created and agents will not perceive anything");
				return;
			}
			grid = new List<List<SteeringPercept>[]>();
			for (int i = 0; i < environments.Count; i++)
			{
				grid.Add(new List<SteeringPercept>[cellCountX * cellCountY * cellCountZ]);
			}
			for (int j = 0; j < grid.Count; j++)
			{
				for (int k = 0; k < grid[j].Length; k++)
				{
					grid[j][k] = new List<SteeringPercept>();
				}
			}
			envIdxDic = new Dictionary<string, int>();
			this.cellCountX = cellCountX;
			this.cellCountY = cellCountY;
			this.cellCountZ = cellCountZ;
		}

		public void Query(Vector3 point, float range, IList<string> environments, IList<SteeringPercept> percepts)
		{
			if (CellSizeX <= 0f || CellSizeY <= 0f || CellSizeZ <= 0f || gridSizeX <= 0f || gridSizeY <= 0f || gridSizeZ <= 0f)
			{
				Debug.LogError("(" + typeof(AIMSteeringPerceiver).Name + ") " + typeof(RegularGrid).Name + ": cannot query because the grid size for at least one axis is smaller than or equal to 0, check cell counts and sizes");
				return;
			}
			percepts.Clear();
			int num;
			int num2;
			int num3;
			float num4;
			if (range < 0f)
			{
				num = cellCountX;
				num2 = cellCountY;
				num3 = cellCountZ;
				num4 = CellSizeX * CellSizeY * CellSizeZ * (float)cellCountX * (float)cellCountY * (float)cellCountZ;
				num4 *= num4;
			}
			else
			{
				num = Mathf.CeilToInt(range / CellSizeX);
				num2 = Mathf.CeilToInt(range / CellSizeY);
				num3 = Mathf.CeilToInt(range / CellSizeZ);
				num4 = range * range;
			}
			float num5 = (point.x + gridExtentX - gridCenter.x) / gridSizeX;
			float num6 = (point.y + gridExtentY - gridCenter.y) / gridSizeY;
			float num7 = (point.z + gridExtentZ - gridCenter.z) / gridSizeZ;
			if (num5 < 0f || num5 > 1f || num6 < 0f || num6 > 1f || num7 < 0f || num7 > 1f)
			{
				return;
			}
			int num8 = (int)(num5 * (float)cellCountX);
			int num9 = (int)(num6 * (float)cellCountY);
			int num10 = (int)(num7 * (float)cellCountZ);
			for (int i = 0; i < environments.Count; i++)
			{
				int value = -1;
				if (!envIdxDic.TryGetValue(environments[i], out value))
				{
					continue;
				}
				for (int j = -num; j <= num; j++)
				{
					for (int k = -num2; k <= num2; k++)
					{
						for (int l = -num3; l <= num3; l++)
						{
							int num11 = num8 + j;
							int num12 = num9 + k;
							int num13 = num10 + l;
							if (num11 < 0 || num11 >= cellCountX || num12 < 0 || num12 >= cellCountY || num13 < 0 || num13 >= cellCountZ)
							{
								continue;
							}
							List<SteeringPercept> list = grid[value][num12 * cellCountX + num11 + num13 * cellCountX * cellCountY];
							for (int m = 0; m < list.Count; m++)
							{
								SteeringPercept steeringPercept = list[m];
								if ((steeringPercept.Position - point).sqrMagnitude < num4)
								{
									percepts.Add(steeringPercept);
									if (!steeringPercept.Received)
									{
										steeringPercept.Receive();
										steeringPercept.Received = true;
									}
								}
							}
						}
					}
				}
			}
		}

		public void PrepareUpdate(Vector3 center, IList<AIMEnvironment> environments)
		{
			if (CellCountX != cellCountX || CellCountY != cellCountY || CellCountZ != cellCountZ)
			{
				Initialize(environments, CellCountX, CellCountY, CellCountZ);
			}
			gridSizeX = (float)cellCountX * CellSizeX;
			gridSizeY = (float)cellCountY * CellSizeY;
			gridSizeZ = (float)cellCountZ * CellSizeZ;
			gridExtentX = gridSizeX * 0.5f;
			gridExtentY = gridSizeY * 0.5f;
			gridExtentZ = gridSizeZ * 0.5f;
			gridCenter = center;
			envCount = environments.Count;
			for (int i = 0; i < grid.Count; i++)
			{
				for (int j = 0; j < grid[i].Length; j++)
				{
					grid[i][j].Clear();
				}
			}
			envIdxDic.Clear();
			while (environments.Count > grid.Count)
			{
				grid.Add(new List<SteeringPercept>[cellCountX * cellCountY * cellCountZ]);
				for (int k = 0; k < grid[grid.Count - 1].Length; k++)
				{
					grid[grid.Count - 1][k] = new List<SteeringPercept>();
				}
			}
			while (environments.Count < grid.Count)
			{
				grid.RemoveAt(grid.Count - 1);
			}
		}

		public void Update(AIMEnvironment environment, IList<SteeringPercept> percepts)
		{
			int value = envIdx;
			if (!envIdxDic.TryGetValue(environment.Label, out value))
			{
				envIdxDic.Add(environment.Label, envIdx);
			}
			if (gridSizeX > 0f && gridSizeY > 0f && gridSizeZ > 0f)
			{
				UpdateGrid(environment.LayerGameObjects, percepts);
				UpdateGrid(environment.GameObjects, percepts, environment.LayerGameObjects.Count);
			}
			else
			{
				Debug.LogError("(" + typeof(AIMSteeringPerceiver).Name + ") " + typeof(RegularGrid).Name + ": cannot update because the grid size for at least one axis is smaller than or equal to 0, check cell counts and sizes");
			}
			if (++envIdx >= envCount)
			{
				envIdx = 0;
			}
		}

		private void UpdateGrid(IList<GameObject> objects, IList<SteeringPercept> percepts, int indexOffset = 0)
		{
			float num = 1f / gridSizeX;
			float num2 = 1f / gridSizeY;
			float num3 = 1f / gridSizeZ;
			for (int i = 0; i < objects.Count; i++)
			{
				if (!(objects[i] == null))
				{
					Transform transform = objects[i].transform;
					float num4 = (transform.position.x + gridExtentX - gridCenter.x) * num;
					float num5 = (transform.position.y + gridExtentY - gridCenter.y) * num2;
					float num6 = (transform.position.z + gridExtentZ - gridCenter.z) * num3;
					int num7 = ((num4 < 0f) ? (-1) : ((int)(num4 * (float)cellCountX)));
					int num8 = ((num5 < 0f) ? (-1) : ((int)(num5 * (float)cellCountY)));
					int num9 = ((num6 < 0f) ? (-1) : ((int)(num6 * (float)cellCountZ)));
					if (num7 >= 0 && num8 >= 0 && num9 >= 0 && num7 < cellCountX && num8 < cellCountY && num9 < cellCountZ)
					{
						percepts[indexOffset + i].Position = objects[i].transform.position;
						percepts[indexOffset + i].Received = false;
						percepts[indexOffset + i].SetGameObject(objects[i]);
						grid[envIdx][num8 * cellCountX + num7 + num9 * cellCountX * cellCountY].Add(percepts[indexOffset + i]);
					}
				}
			}
		}
	}
}
