using System.Collections;
using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

[CreateAssetMenu(fileName = "LandmarkPass", menuName = "Flotsam/Procedural Generation/Landmark Pass", order = 3)]
public class LandmarkPass : TileGeneratorPass
{
	public class Node
	{
		public TileGeneratorNode GeneratorNode { get; private set; }

		public List<Node> Neighbors { get; private set; }

		public LandmarkBehaviour LandmarkBehaviour { get; private set; }

		public Node(TileGeneratorNode generatorNode)
		{
			GeneratorNode = generatorNode;
			Neighbors = new List<Node>();
		}

		public void TryAddNeighbor(Node potentialNeighbor, float uniqueDistance)
		{
			if (potentialNeighbor != this && !Neighbors.Contains(potentialNeighbor) && GeneratorNode.Position.IsInRange(potentialNeighbor.GeneratorNode.Position, uniqueDistance))
			{
				Neighbors.Add(potentialNeighbor);
				potentialNeighbor.Neighbors.Add(this);
			}
		}

		public void SetLandmarkBehaviour(LandmarkBehaviour landmarkBehaviour, bool hasBearing = false)
		{
			GeneratorNode.SetSpawner(new LandmarkSpawner(landmarkBehaviour, new Vector3(GeneratorNode.Position.x, 0f, GeneratorNode.Position.y), hasBearing));
			LandmarkBehaviour = landmarkBehaviour;
		}

		public bool ReturnIsPossibleLandmark(LandmarkBehaviour landmark)
		{
			foreach (Node neighbor in Neighbors)
			{
				if (neighbor.LandmarkBehaviour == landmark)
				{
					return false;
				}
			}
			return true;
		}
	}

	[SerializeField]
	private LandmarkBehaviour[] _landmarkBehaviours;

	[SerializeField]
	private float _uniqueDistance = 500f;

	[SerializeField]
	private bool _generateWithBearing;

	public override IEnumerator Run(TileGenerator generator, IRegion dataRegion = null)
	{
		List<Node> list = ReturnNodes(generator.Nodes);
		List<LandmarkBehaviour> list2 = new List<LandmarkBehaviour>(_landmarkBehaviours);
		List<int> list3 = new List<int>();
		foreach (Node item in list)
		{
			if (list2.Count == 0)
			{
				list2.AddRange(_landmarkBehaviours);
			}
			list3.Clear();
			for (int i = 0; i < list2.Count; i++)
			{
				if (item.ReturnIsPossibleLandmark(list2[i]))
				{
					list3.Add(i);
				}
			}
			if (list3.Count == 0)
			{
				Debug.Log("No possible landmark in landmarksToDistribute, no landmark will be added to the world for this node.");
				continue;
			}
			int index = list3[Random.Range(0, list3.Count)];
			item.SetLandmarkBehaviour(list2[index], _generateWithBearing);
			list2.RemoveAt(index);
		}
		yield break;
	}

	public List<Node> ReturnNodes(List<TileGeneratorNode> generatorNodes)
	{
		List<Node> list = new List<Node>();
		foreach (TileGeneratorNode generatorNode in generatorNodes)
		{
			if (!generatorNode.Locked)
			{
				list.Add(new Node(generatorNode));
			}
		}
		foreach (Node item in list)
		{
			foreach (Node item2 in list)
			{
				item.TryAddNeighbor(item2, _uniqueDistance);
			}
		}
		return list;
	}
}
