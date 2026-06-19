using System.Collections.Generic;
using UnityEngine;

public static class PipePathfinder
{
	public static List<Vector3> GetPipePath(Vector3 startPos, Vector3 endPos, List<List<List<ulong?>>> grid, List<List<List<ulong?>>> pipeGrid, int xMin, int xMax, int yMin, int yMax, int zMin, int zMax, bool samePen)
	{
		List<Vector3> pipePathBFS = GetPipePathBFS(startPos, endPos, grid, pipeGrid, xMin, xMax, yMin, yMax, zMin, zMax, twoD: true, samePen);
		if (pipePathBFS.Count == 0)
		{
			return GetPipePathBFS(startPos, endPos, grid, pipeGrid, xMin, xMax, yMin, yMax, zMin, zMax, twoD: false, samePen);
		}
		return pipePathBFS;
	}

	private static List<Vector3> GetLinkedPositions(Vector3 pos, Vector3 goalPos, List<List<List<ulong?>>> grid, List<List<List<ulong?>>> pipeGrid, int xMin, int xMax, int yMin, int yMax, int zMin, int zMax, bool twoD, bool goalPosAllowed)
	{
		int num = (int)pos.x;
		int num2 = (int)pos.y;
		int num3 = (int)pos.z;
		List<Vector3> list = new List<Vector3>();
		if (num + 1 < grid.Count && num + 1 <= xMax && ((goalPosAllowed && new Vector3(num + 1, num2, num3) == goalPos) || (!grid[num + 1][num2][num3].HasValue && !pipeGrid[num + 1][num2][num3].HasValue)))
		{
			list.Add(new Vector3(num + 1, num2, num3));
		}
		if (num - 1 >= 0 && num - 1 >= xMin && ((goalPosAllowed && new Vector3(num - 1, num2, num3) == goalPos) || (!grid[num - 1][num2][num3].HasValue && !pipeGrid[num - 1][num2][num3].HasValue)))
		{
			list.Add(new Vector3(num - 1, num2, num3));
		}
		if (num2 + 1 < grid[num].Count && num2 + 1 <= yMax && ((goalPosAllowed && new Vector3(num, num2 + 1, num3) == goalPos) || (!grid[num][num2 + 1][num3].HasValue && !pipeGrid[num][num2 + 1][num3].HasValue)))
		{
			list.Add(new Vector3(num, num2 + 1, num3));
		}
		if (num2 - 1 >= 0 && num2 - 1 >= yMin && ((goalPosAllowed && new Vector3(num, num2 - 1, num3) == goalPos) || (!grid[num][num2 - 1][num3].HasValue && !pipeGrid[num][num2 - 1][num3].HasValue)))
		{
			list.Add(new Vector3(num, num2 - 1, num3));
		}
		if (!twoD && num3 + 1 < grid[num][num2].Count && num3 + 1 <= zMax && ((goalPosAllowed && new Vector3(num, num2, num3 + 1) == goalPos) || (!grid[num][num2][num3 + 1].HasValue && !pipeGrid[num][num2][num3 + 1].HasValue)))
		{
			list.Add(new Vector3(num, num2, num3 + 1));
		}
		if (!twoD && num3 - 1 >= 0 && num3 - 1 >= zMin && ((goalPosAllowed && new Vector3(num, num2, num3 - 1) == goalPos) || (!grid[num][num2][num3 - 1].HasValue && !pipeGrid[num][num2][num3 - 1].HasValue)))
		{
			list.Add(new Vector3(num, num2, num3 - 1));
		}
		return list;
	}

	private static List<Vector3> GetPipePathBFS(Vector3 startPos, Vector3 endPos, List<List<List<ulong?>>> grid, List<List<List<ulong?>>> pipeGrid, int xMin, int xMax, int yMin, int yMax, int zMin, int zMax, bool twoD, bool samePen)
	{
		if (startPos == endPos)
		{
			return new List<Vector3> { startPos };
		}
		List<Vector3> list = new List<Vector3>();
		List<Vector3> list2 = new List<Vector3>();
		Dictionary<Vector3, Vector3> dictionary = new Dictionary<Vector3, Vector3>();
		list.Add(startPos);
		Vector3 vector = list[0];
		while (list.Count > 0)
		{
			vector = list[0];
			list.RemoveAt(0);
			if (vector == endPos)
			{
				return ConstructPath(vector, dictionary);
			}
			bool goalPosAllowed = vector != startPos;
			Vector3 vector2 = new Vector3(vector.x + 1f, vector.y, vector.z);
			Vector3 vector3 = new Vector3(vector.x - 1f, vector.y, vector.z);
			if (!samePen && vector == startPos && (vector2 == endPos || vector3 == endPos))
			{
				goalPosAllowed = true;
			}
			List<Vector3> linkedPositions = GetLinkedPositions(vector, endPos, grid, pipeGrid, xMin, xMax, yMin, yMax, zMin, zMax, twoD, goalPosAllowed);
			for (int i = 0; i < linkedPositions.Count; i++)
			{
				Vector3 vector4 = linkedPositions[i];
				if (!list2.Contains(vector4) && !list.Contains(vector4))
				{
					list.Add(vector4);
					dictionary[vector4] = vector;
				}
			}
			list2.Add(vector);
		}
		if (!twoD)
		{
			Debug.LogError("No complete path found.");
		}
		return new List<Vector3>();
	}

	private static List<Vector3> ConstructPath(Vector3 endPos, Dictionary<Vector3, Vector3> connections)
	{
		Vector3 vector = endPos;
		List<Vector3> list = new List<Vector3>();
		while (true)
		{
			list.Insert(0, vector);
			if (!connections.ContainsKey(vector))
			{
				break;
			}
			vector = connections[vector];
		}
		return list;
	}
}
