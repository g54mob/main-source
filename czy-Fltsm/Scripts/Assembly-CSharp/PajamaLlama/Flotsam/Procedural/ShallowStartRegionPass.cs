using System;
using PajamaLlama.Flotsam.World;
using PajamaLlama.Generic;
using UnityEngine;

namespace PajamaLlama.Flotsam.Procedural
{
	[Serializable]
	public class ShallowStartRegionPass : IRegionPass
	{
		[SerializeField]
		private WorldRegionType[] _supportedRegions = new WorldRegionType[1] { WorldRegionType.Any };

		[SerializeField]
		private RangedFloat _spawnDistanceRange = new RangedFloat(250f, 350f);

		[SerializeField]
		private Vector2 _spawnDirection = Vector2.right;

		[SerializeField]
		private float _spawnDirectionDeviationMaximum = 30f;

		[SerializeField]
		[Min(0f)]
		private float _minimumNodeDistance;

		[Tooltip("The branch chance for a given level of the tree, the last value applies to all levels following that.")]
		[SerializeField]
		[Range(0f, 100f)]
		private float[] _branchChances = new float[2] { 100f, 33f };

		[SerializeField]
		private int _maxBranchCount = 3;

		[SerializeField]
		private PointOfInterestProperties[] _firstPointsOfInterest;

		[SerializeField]
		private PointOfInterestProperties[] _randomizedPointsOfInterest;

		[NonSerialized]
		private TileGenerator _tileGenerator;

		[NonSerialized]
		private ListPool<PointOfInterestProperties>.List _poisToDistribute;

		public int SpawnCount => 0;

		public void Initialize(TileGenerator tileGenerator)
		{
			_tileGenerator = tileGenerator;
			_poisToDistribute = ListPool<PointOfInterestProperties>.Get(_firstPointsOfInterest);
		}

		public bool InitializeRegion(TileGeneratorRegion region)
		{
			return true;
		}

		public void Run(RegionPassGroup regionPasses, TileGeneratorRegion region)
		{
			if (!_tileGenerator.IsStartingTile || !SupportsRegion(region) || !region.ReturnContainsPosition(_tileGenerator.StartPosition))
			{
				return;
			}
			using ListPool<TileGeneratorNode>.List list = ListPool<TileGeneratorNode>.Get();
			region.PopulateNeighorScoutingLandmarkNodes(list);
			foreach (TileGeneratorNode item in list)
			{
				GeneratePath(region, _tileGenerator.StartPosition, item.Position);
			}
		}

		public void Uninitialize()
		{
		}

		private void GeneratePath(TileGeneratorRegion region, Vector2 position, Vector2 targetPosition)
		{
			int num = 0;
			using ListPool<Vector2>.List list = ListPool<Vector2>.Get(16);
			list.Add(position);
			while (0 < list.Count)
			{
				int num2 = list.Count;
				int num3 = 0;
				float valueClamped = _branchChances.GetValueClamped(num);
				int num4 = num2;
				while (0 < num4-- && num3 < _maxBranchCount)
				{
					int index = UnityEngine.Random.Range(0, num2 - 1);
					position = list[index];
					if (TryAddNode(out var nodePosition, region, position))
					{
						list.Add(nodePosition);
						list.RemoveAt(index);
						num2--;
						num3++;
						if (num3 < _maxBranchCount && (float)UnityEngine.Random.Range(0, 100) <= valueClamped && TryAddNode(out nodePosition, region, position))
						{
							list.Add(nodePosition);
							num3++;
						}
					}
				}
				list.RemoveRange(0, num2);
				num++;
			}
		}

		private bool TryAddNode(out Vector2 nodePosition, TileGeneratorRegion region, Vector2 position, int itterations = 5)
		{
			for (int i = 0; i < itterations; i++)
			{
				Vector2 vector = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0f - _spawnDirectionDeviationMaximum, _spawnDirectionDeviationMaximum)) * _spawnDirection;
				vector *= _spawnDistanceRange.ReturnRandom();
				nodePosition = position + vector;
				if (region.ReturnIsValidPosition(nodePosition, _minimumNodeDistance))
				{
					TileGeneratorNode tileGeneratorNode = new TileGeneratorNode(nodePosition, null, isLeaf: true);
					tileGeneratorNode.SetSpawner(new PointOfInterestSpawner(GetNextPointOfInterestProperties(), tileGeneratorNode.WorldPosition));
					region.AddNode(tileGeneratorNode);
					_tileGenerator.AddNode(tileGeneratorNode);
					return true;
				}
			}
			nodePosition = default(Vector2);
			return false;
		}

		private PointOfInterestProperties GetNextPointOfInterestProperties()
		{
			if (_poisToDistribute.Count == 0)
			{
				_poisToDistribute.AddRange(_randomizedPointsOfInterest);
				_poisToDistribute.Shuffle();
			}
			PointOfInterestProperties result = _poisToDistribute[0];
			_poisToDistribute.RemoveAt(0);
			return result;
		}

		private bool SupportsRegion(TileGeneratorRegion region)
		{
			if (!_supportedRegions.Contains(WorldRegionType.Any))
			{
				return _supportedRegions.Contains(region.Type);
			}
			return true;
		}
	}
}
