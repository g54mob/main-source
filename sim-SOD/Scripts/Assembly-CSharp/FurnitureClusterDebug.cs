using System;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureClusterDebug : MonoBehaviour
{
	[Serializable]
	public class DebugFurnitureAnglePlacement
	{
		public string name;

		public int angle;

		public bool isValid;

		public List<NewNode> coversNodes;

		public List<string> log;

		[Space(7f)]
		public List<string> pathingLog;
	}

	public MeshRenderer rend;

	public FurnitureCluster cluster;

	public NewNode node;

	public List<DebugFurnitureAnglePlacement> entries;

	public Material validMaterial;

	public Material invalidMaterial;

	public void Setup(FurnitureCluster newCluster, NewNode newNode)
	{
	}

	public void AddEntry(DebugFurnitureAnglePlacement newEntry)
	{
	}
}
