using UnityEngine;

public class HierarchicalGrid
{
	public HierarchicalGridNode[,] Nodes { get; private set; }

	public Vector2 Size { get; private set; }

	public HierarchicalGrid(int mapRadius, int nodeSize = 32)
	{
		int num = mapRadius / nodeSize + 1;
		int num2 = nodeSize / 2;
		if (num % 2 == 1)
		{
			num++;
		}
		Nodes = new HierarchicalGridNode[num, num];
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num; j++)
			{
				Vector2 position = new Vector2(num2 + nodeSize * j, num2 + nodeSize);
				Nodes[j, i] = new HierarchicalGridNode(position, nodeSize);
			}
		}
		Size = new Vector2(num * nodeSize, num * nodeSize);
	}
}
