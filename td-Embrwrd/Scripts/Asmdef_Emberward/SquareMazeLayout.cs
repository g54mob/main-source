using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SquareMazeLayout
{
	[Min(1f)]
	public int rows;

	[Min(1f)]
	public int cols;

	public List<eMazeBlockState> list_BlockState;

	public int Count => 0;

	public void EnsureSize()
	{
	}

	public eMazeBlockState GetStateAtPosition(int x, int y)
	{
		return default(eMazeBlockState);
	}

	public eMazeBlockState GetStateAtIndex(int idx)
	{
		return default(eMazeBlockState);
	}

	public void Set(int r, int c, eMazeBlockState state)
	{
	}
}
