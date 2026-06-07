using System;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

namespace PajamaLlama.Flotsam.Procedural
{
	public class RegionPassCells : IDisposable
	{
		[Serializable]
		public class Settings
		{
			[SerializeField]
			[Range(0f, 1f)]
			[Tooltip("The minimum amount of overlap a cell requires to allow spawning.")]
			public float _minimumCellOverlap = 0.5f;

			[SerializeField]
			[Tooltip("Should nodes that are in the region when the cell is initialized be counted?")]
			public bool _countExistingNodes;

			[SerializeField]
			[Tooltip("The curve with spawn chances base on the amount of nodes in the cell.")]
			public AnimationCurve _spawnChangeCurve;

			[SerializeField]
			[Tooltip("Should the node count be corrected base on the amount of overlap with the region?")]
			public bool _applyOverlapCorrection = true;

			[Header("Spawning")]
			[SerializeField]
			[Tooltip("Padding used when generating a random position in a cell.")]
			public float _padding;

			[SerializeField]
			[Min(0f)]
			[Tooltip("The minimum distance spawned nodes should be apart from eachother")]
			public float _mininumNodeDistance = 100f;

			public float MinimumCellOverlap => _minimumCellOverlap;

			public bool CountExistingNodes => _countExistingNodes;

			public AnimationCurve SpawnChangeCurve => _spawnChangeCurve;

			public bool ApplyOverlapCorrection => _applyOverlapCorrection;

			public float Padding => _padding;

			public float MininumNodeDistance => _mininumNodeDistance;

			public float EvaluateSpawnChance(float nodeCount)
			{
				if (SpawnChangeCurve == null)
				{
					return 1f;
				}
				return SpawnChangeCurve.Evaluate(nodeCount);
			}
		}

		private class Cell : IDisposable
		{
			private static List<Cell> _pool;

			private float _overlap;

			private bool _applyOverlapCorrection;

			public int Row { get; private set; }

			public int Column { get; private set; }

			public Rect Rect { get; private set; }

			public float Overlap { get; private set; }

			public int NodeCount { get; private set; }

			public float Chance { get; private set; }

			public bool IsBorderCell { get; private set; }

			private Cell()
			{
			}

			public static bool TryGet(out Cell cell, IRegion region, Rect rect, Settings settings)
			{
				float num = region.ReturnOverlap(rect.GetTempPolygon()) / (rect.width * rect.height);
				cell = null;
				if (num <= 0f || num < settings.MinimumCellOverlap)
				{
					return false;
				}
				if (_pool.IsNullOrEmpty())
				{
					cell = new Cell();
				}
				else
				{
					int index = _pool.Count - 1;
					cell = _pool[index];
					_pool.RemoveAt(index);
				}
				cell.Rect = rect;
				cell.NodeCount = 0;
				cell.Overlap = num;
				cell.ApplySpawnChanceCurve(settings.SpawnChangeCurve);
				return true;
			}

			private static void ReturnToPool(Cell cell)
			{
				if (_pool == null)
				{
					_pool = new List<Cell>(32);
				}
				_pool.Add(cell);
			}

			public void Dispose()
			{
				ReturnToPool(this);
			}

			public void SetRowAndColumn(int row, int column)
			{
				Row = row;
				Column = column;
			}

			public void AddNode(AnimationCurve spawnChanceCurve)
			{
				NodeCount++;
				ApplySpawnChanceCurve(spawnChanceCurve);
			}

			public void ApplySpawnChanceCurve(AnimationCurve spawnChanceCurve)
			{
				if (spawnChanceCurve != null)
				{
					float num = NodeCount;
					if (_applyOverlapCorrection)
					{
						num /= _overlap;
					}
					Chance = spawnChanceCurve.Evaluate(num);
				}
			}
		}

		public delegate void GenerateNode(Vector2 position);

		private static Queue<RegionPassCells> _pool = new Queue<RegionPassCells>();

		private IRegion _region;

		private List<Cell> _cells = new List<Cell>(128);

		private List<Cell> _spawnChanceCells = new List<Cell>(128);

		private AnimationCurve _spawnChanceCurve;

		private float _cellPadding;

		private float _minimumNodeDistance;

		public static RegionPassCells GetFromPool(Settings settings, IRegion region, Vector2 cellSize)
		{
			if (!_pool.TryDequeue(out var result))
			{
				result = new RegionPassCells();
			}
			result.Initialize(settings, region, cellSize);
			return result;
		}

		public static void ReturnToPool(RegionPassCells instance)
		{
			_pool.Enqueue(instance);
		}

		private void Initialize(Settings settings, IRegion region, Vector2 cellSize)
		{
			_region = region;
			_cellPadding = settings.Padding;
			_minimumNodeDistance = settings.MininumNodeDistance;
			int num = Mathf.RoundToInt(region.Bounds.width / cellSize.x);
			int num2 = Mathf.RoundToInt(region.Bounds.height / cellSize.y);
			cellSize.x = region.Bounds.width / (float)num;
			cellSize.y = region.Bounds.height / (float)num2;
			Rect rect = new Rect(region.Bounds.min, cellSize);
			for (int i = 0; i < num2; i++)
			{
				rect.x = region.Bounds.xMin;
				for (int j = 0; j < num; j++)
				{
					if (Cell.TryGet(out var cell, region, rect, settings))
					{
						cell.SetRowAndColumn(i, j);
						_cells.Add(cell);
					}
					rect.x += cellSize.x;
				}
				rect.y += cellSize.y;
			}
			SetSpawnChanceCurve(settings.SpawnChangeCurve);
		}

		public void CountExistingNodes(TileGeneratorRegion region)
		{
			foreach (Cell cell in _cells)
			{
				foreach (TileGeneratorNode node in region.Nodes)
				{
					if (cell.Rect.Contains(node.Position))
					{
						cell.AddNode(null);
					}
				}
			}
			SetSpawnChanceCurve(_spawnChanceCurve);
		}

		public void SetSpawnChanceCurve(AnimationCurve spawnChanceCurve)
		{
			_spawnChanceCurve = spawnChanceCurve;
			_spawnChanceCells.Clear();
			foreach (Cell cell in _cells)
			{
				cell.ApplySpawnChanceCurve(_spawnChanceCurve);
				if (0f < cell.Chance)
				{
					_spawnChanceCells.Add(cell);
				}
			}
		}

		public int DistributeNodes(TileGenerator tileGenerator, int count, GenerateNode generateNode)
		{
			int num = _spawnChanceCells.Count;
			int num2 = 0;
			float num3 = 0f;
			for (int i = 0; i < num; i++)
			{
				num3 += _spawnChanceCells[i].Chance;
			}
			while (0 < count && 0 < num)
			{
				float num4 = UnityEngine.Random.Range(0f, num3);
				float num5 = 0f;
				float num6 = 0f;
				for (int j = 0; j < num; j++)
				{
					Cell cell = _spawnChanceCells[j];
					num6 += cell.Chance;
					if (num4 < num5 || num6 < num4)
					{
						continue;
					}
					if (TryGenerateNode(tileGenerator, cell, generateNode))
					{
						num2++;
						count--;
						num3 -= cell.Chance;
						cell.AddNode(_spawnChanceCurve);
						if (0f < cell.Chance)
						{
							num3 += cell.Chance;
							break;
						}
					}
					_spawnChanceCells.RemoveAt(j);
					num--;
					break;
				}
			}
			return num2;
		}

		private bool TryGenerateNode(TileGenerator tileGenerator, Cell cell, GenerateNode generateNode, int sampleLimit = 10)
		{
			while (0 < sampleLimit)
			{
				Vector2 position = cell.Rect.RandomPosition(_cellPadding);
				if (_region.ReturnContainsPosition(position) && tileGenerator.ReturnIsValidPosition(position, _minimumNodeDistance))
				{
					generateNode(position);
					return true;
				}
				sampleLimit--;
			}
			return false;
		}

		public void Dispose()
		{
			foreach (Cell cell in _cells)
			{
				cell.Dispose();
			}
			_cells.Clear();
			_spawnChanceCells.Clear();
			ReturnToPool(this);
		}
	}
}
