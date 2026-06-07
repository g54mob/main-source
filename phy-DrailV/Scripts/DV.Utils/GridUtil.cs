using System;
using System.Collections.Generic;

public static class GridUtil
{
	public static List<int> GetGridIndices(int gridSize, int subGridSize, int xOffset, int yOffset)
	{
		if (gridSize < 1)
		{
			throw new ArgumentException("gridSize must be >= 1, got " + gridSize);
		}
		if (subGridSize > gridSize)
		{
			throw new ArgumentException("subGridSize can't be larger than gridSize " + gridSize + ", got " + subGridSize);
		}
		if (xOffset < 0 || xOffset > gridSize - subGridSize)
		{
			throw new ArgumentException($"xOffset must be between 0 and (gridSize - subGridSize = {gridSize} - {subGridSize} = {gridSize - subGridSize}), got {xOffset}");
		}
		if (yOffset < 0 || yOffset > gridSize - subGridSize)
		{
			throw new ArgumentException($"yOffset must be between 0 and (gridSize - subGridSize = {gridSize} - {subGridSize} = {gridSize - subGridSize}), got {yOffset}");
		}
		List<int> list = new List<int>();
		for (int i = yOffset; i < yOffset + subGridSize; i++)
		{
			for (int j = xOffset; j < xOffset + subGridSize; j++)
			{
				int item = i * gridSize + j;
				list.Add(item);
			}
		}
		return list;
	}
}
