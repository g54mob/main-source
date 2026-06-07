using System.Collections;
using System.Collections.Generic;
using External.Zalgo2462.VoronoiLib;
using External.Zalgo2462.VoronoiLib.Structures;
using UnityEngine;

[CreateAssetMenu(fileName = "LandmarkConnectionPass", menuName = "Flotsam/Procedural Generation/ConnectionPass", order = 3)]
public class LandmarkConnectionPass : TileGeneratorPass
{
	private class TileGeneratorNodeSite : FortuneSite
	{
		public TileGeneratorNode Node { get; private set; }

		public TileGeneratorNodeSite()
			: base(0.0, 0.0)
		{
		}

		public TileGeneratorNodeSite(TileGeneratorNode node)
			: base(node.Position.x, node.Position.y)
		{
			Node = node;
		}
	}

	public struct Connection
	{
		public TileGeneratorNode From;

		public TileGeneratorNode To;

		public int Tier;
	}

	[Header("Voronoi Settings")]
	[SerializeField]
	private RectInt _bounds;

	[Header("Landmark Settings")]
	[SerializeField]
	private float _spawnInterval = 500f;

	[SerializeField]
	private float _spawnDirectionRange = 250f;

	[SerializeField]
	private float _spawnWidthRange = 500f;

	[SerializeField]
	private int _spawnSampleLimit = 10;

	[SerializeField]
	private int _minimumClearDistance = 300;

	public override IEnumerator Run(TileGenerator generator, IRegion dataRegion = null)
	{
		ListPool<FortuneSite>.List list = ListPool<FortuneSite>.Get(generator.Nodes.Count + 1);
		list.Add(new TileGeneratorNodeSite(new TileGeneratorNode(Vector2.zero)));
		foreach (TileGeneratorNode node in generator.Nodes)
		{
			list.Add(new TileGeneratorNodeSite(node));
		}
		FortunesAlgorithm.Run(list, _bounds.xMin, _bounds.yMin, _bounds.xMax, _bounds.yMax);
		GenerateConnections(generator, list);
		GenerateNodes(generator);
		generator.Nodes.AddRange(base.GeneratedNodes);
		yield break;
	}

	private void GenerateConnections(TileGenerator generator, List<FortuneSite> sites)
	{
		ListPool<FortuneSite>.List list = ListPool<FortuneSite>.Get(sites[0]);
		ListPool<FortuneSite>.List list2 = ListPool<FortuneSite>.Get(sites.Count);
		int num = 0;
		while (0 < list.Count)
		{
			ListPool<FortuneSite>.List list3 = list;
			list = ListPool<FortuneSite>.Get();
			foreach (TileGeneratorNodeSite item in list3)
			{
				foreach (TileGeneratorNodeSite neighbor in item.Neighbors)
				{
					AddConnection(generator, item.Node, neighbor.Node, num);
					if (!list2.Contains(item))
					{
						list.Add(neighbor);
					}
				}
				list2.Add(item);
			}
			list3.Dispose();
			num++;
		}
		list.Dispose();
		list2.Dispose();
	}

	private void GenerateNodes(TileGenerator generator)
	{
		ListPool<TileGeneratorNode>.List list = ListPool<TileGeneratorNode>.Get(generator.Nodes);
		InitializeGeneratedNodes(list.Count);
		foreach (TileGeneratorConnection generatedConnection in base.GeneratedConnections)
		{
			float num = Mathf.FloorToInt(generatedConnection.Distance / _spawnInterval);
			if (num != 1f)
			{
				Vector2 vector = generatedConnection.Direction * (generatedConnection.Distance / num);
				Vector2 position = generatedConnection.From.Position;
				for (int i = 1; (float)i < num; i++)
				{
					GenerateNode(position + i * vector, generatedConnection.Direction, list, _spawnSampleLimit);
				}
			}
		}
	}

	private void GenerateNode(Vector2 position, Vector2 direction, List<TileGeneratorNode> samples, int sampleLimit)
	{
		Vector2 vector = new Vector2(0f - direction.y, direction.x);
		for (int i = 0; i < sampleLimit; i++)
		{
			Vector2 position2 = position + direction * Random.Range(0f - _spawnDirectionRange, _spawnDirectionRange) + vector * Random.Range(0f - _spawnWidthRange, _spawnWidthRange);
			if (!HasSampleInRange(samples, position2, _minimumClearDistance))
			{
				TileGeneratorNode item = new TileGeneratorNode(position2);
				base.GeneratedNodes.Add(item);
				samples.Add(item);
				break;
			}
		}
	}
}
