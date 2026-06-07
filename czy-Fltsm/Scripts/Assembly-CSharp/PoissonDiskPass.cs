using System;
using System.Collections;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PoissonDiskPass", menuName = "Flotsam/Procedural Generation/Poisson Disk Pass", order = 2)]
public class PoissonDiskPass : TileGeneratorPass
{
	[Serializable]
	public class WeightedDistanceRange
	{
		public int Minimum;

		public int Maximum;

		public int Weight;

		[NonSerialized]
		public int WeightThreshold;
	}

	public enum SampleInitialization
	{
		ZeroNode = 0,
		GeneratorNodes = 1,
		PassNodes = 2,
		StartPosition = 3
	}

	public enum Restrictions
	{
		None = 0,
		Radial = 1,
		Rect = 2
	}

	[SerializeField]
	private int _sampleCount = 1;

	[SerializeField]
	[Range(1f, 100f)]
	private int _sampleLimit = 30;

	[SerializeField]
	private WeightedDistanceRange[] _weightedDistanceRanges;

	[SerializeField]
	private SampleInitialization _sampleInitialization = SampleInitialization.PassNodes;

	[SerializeField]
	private bool _generateLeafNodes;

	[SerializeField]
	[Range(0f, 10f)]
	private int _LeafMaximum = 3;

	[Header("Ristrictions")]
	[SerializeField]
	private Restrictions _restriction;

	[ConditionalEnumHide("_restriction", 1, false, HideInInspector = true)]
	[SerializeField]
	[FormerlySerializedAs("_SampleAreaStart")]
	private float _sampleAreaStart;

	[ConditionalEnumHide("_restriction", 1, false, HideInInspector = true)]
	[SerializeField]
	[FormerlySerializedAs("_SampleAreaEnd")]
	private float _sampleAreaEnd;

	[ConditionalEnumHide("_restriction", 2, false, HideInInspector = true)]
	[SerializeField]
	private Rect _sampleRect;

	[ConditionalEnumHide("_restriction", 2, false, HideInInspector = true)]
	[SerializeField]
	private Vector2 _startAreaCenter;

	[ConditionalEnumHide("_restriction", 2, false, HideInInspector = true)]
	[SerializeField]
	private float _startAreaRadius;

	[NonSerialized]
	private int _weightedDistanceRangesTotalWeight;

	[NonSerialized]
	private float _minimumDistance;

	public Restrictions Ristriction => _restriction;

	public float SampleAreaStart => _sampleAreaStart;

	public float SampleAreaEnd => _sampleAreaEnd;

	public override IEnumerator Run(TileGenerator generator, IRegion dataRegion = null)
	{
		ListPool<TileGeneratorNode>.List list = ReturnInitialSamples(generator);
		ListPool<TileGeneratorNode>.List list2 = ReturnSamplesWithoutLeaves(list);
		InitializeWeightedInstances();
		InitializeGeneratedNodes(_sampleCount);
		int num = 1;
		int num2 = _sampleCount * 2;
		int num3 = 0;
		while (base.GeneratedNodes.Count < _sampleCount && 0 < list2.Count)
		{
			int index = UnityEngine.Random.Range(0, list2.Count);
			TileGeneratorNode tileGeneratorNode = list2[index];
			TileGeneratorNode tileGeneratorNode2 = null;
			for (int i = 0; i < _sampleLimit; i++)
			{
				Vector2 vector = tileGeneratorNode.Position + ReturnRandomOnCircle(ReturnSampleDistance());
				if (!ReturnIsValidPosition(vector))
				{
					continue;
				}
				bool flag = false;
				foreach (TileGeneratorNode item in list)
				{
					flag = vector.IsInRange(item.Position, _minimumDistance);
					if (flag)
					{
						break;
					}
				}
				if (!flag)
				{
					tileGeneratorNode2 = new TileGeneratorNode(vector, tileGeneratorNode, _generateLeafNodes);
					break;
				}
			}
			if (tileGeneratorNode2 == null)
			{
				if (base.GeneratedNodes.Remove(tileGeneratorNode))
				{
					tileGeneratorNode.Dispose();
					list.Remove(tileGeneratorNode);
					list2.Remove(tileGeneratorNode);
					num--;
				}
			}
			else
			{
				base.GeneratedNodes.Add(tileGeneratorNode2);
				list.Add(tileGeneratorNode2);
				if (_generateLeafNodes)
				{
					if (_LeafMaximum <= tileGeneratorNode.LeafCount)
					{
						list2.Remove(tileGeneratorNode);
					}
				}
				else
				{
					list2.Add(tileGeneratorNode2);
				}
				num++;
			}
			num3++;
			if (num2 < num3)
			{
				break;
			}
		}
		generator.Nodes.AddRange(base.GeneratedNodes);
		list.Dispose();
		list2.Dispose();
		yield break;
	}

	private void InitializeWeightedInstances()
	{
		_weightedDistanceRangesTotalWeight = 0;
		_minimumDistance = float.MaxValue;
		WeightedDistanceRange[] weightedDistanceRanges = _weightedDistanceRanges;
		foreach (WeightedDistanceRange weightedDistanceRange in weightedDistanceRanges)
		{
			_weightedDistanceRangesTotalWeight += weightedDistanceRange.Weight;
			weightedDistanceRange.WeightThreshold = _weightedDistanceRangesTotalWeight;
			if ((float)weightedDistanceRange.Minimum < _minimumDistance)
			{
				_minimumDistance = weightedDistanceRange.Minimum;
			}
		}
	}

	private int ReturnSampleDistance()
	{
		int minInclusive = int.MaxValue;
		int maxExclusive = int.MinValue;
		int num = UnityEngine.Random.Range(0, _weightedDistanceRangesTotalWeight);
		WeightedDistanceRange[] weightedDistanceRanges = _weightedDistanceRanges;
		foreach (WeightedDistanceRange weightedDistanceRange in weightedDistanceRanges)
		{
			if (num < weightedDistanceRange.WeightThreshold)
			{
				minInclusive = weightedDistanceRange.Minimum;
				maxExclusive = weightedDistanceRange.Maximum;
				break;
			}
		}
		return UnityEngine.Random.Range(minInclusive, maxExclusive);
	}

	public static Vector2 ReturnRandomOnCircle(float distance)
	{
		return Quaternion.AngleAxis(UnityEngine.Random.Range(0f, 360f), Vector3.forward) * Vector2.up * distance;
	}

	private ListPool<TileGeneratorNode>.List ReturnInitialSamples(TileGenerator generator)
	{
		ListPool<TileGeneratorNode>.List list = ListPool<TileGeneratorNode>.Get();
		switch (generator.ReturnHasNodes() ? _sampleInitialization : SampleInitialization.ZeroNode)
		{
		case SampleInitialization.ZeroNode:
		{
			TileGeneratorNode tileGeneratorNode = new TileGeneratorNode(Vector2.zero);
			tileGeneratorNode.Lock();
			list.Add(tileGeneratorNode);
			break;
		}
		case SampleInitialization.GeneratorNodes:
			list.AddRange(generator.Nodes);
			break;
		case SampleInitialization.PassNodes:
			throw new NotImplementedException();
		case SampleInitialization.StartPosition:
		{
			TileGeneratorNode tileGeneratorNode = new TileGeneratorNode(generator.StartPosition);
			tileGeneratorNode.Lock();
			list.Add(tileGeneratorNode);
			break;
		}
		}
		return list;
	}

	private ListPool<TileGeneratorNode>.List ReturnSamplesWithoutLeaves(ListPool<TileGeneratorNode>.List allSamples)
	{
		ListPool<TileGeneratorNode>.List list = ListPool<TileGeneratorNode>.Get();
		foreach (TileGeneratorNode allSample in allSamples)
		{
			if (!allSample.IsLeaf)
			{
				list.Add(allSample);
			}
		}
		return list;
	}

	private bool ReturnIsValidPosition(Vector2 generatedPosition)
	{
		switch (_restriction)
		{
		case Restrictions.None:
			return true;
		case Restrictions.Radial:
		{
			float magnitude = generatedPosition.magnitude;
			if (_sampleAreaStart < magnitude)
			{
				return magnitude < _sampleAreaEnd;
			}
			return false;
		}
		case Restrictions.Rect:
			if (_sampleRect.Contains(generatedPosition))
			{
				return !_startAreaCenter.IsInRange(generatedPosition, _startAreaRadius);
			}
			return false;
		default:
			throw new NotImplementedException();
		}
	}
}
