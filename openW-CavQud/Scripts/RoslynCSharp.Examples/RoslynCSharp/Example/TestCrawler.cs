using System;
using System.Collections.Generic;
using UnityEngine;

namespace RoslynCSharp.Example
{
	internal class TestCrawler : MazeCrawler
	{
		private Stack<MazeDirection> searchPath = new Stack<MazeDirection>();

		private List<MazeDirection> available = new List<MazeDirection>();

		private HashSet<Vector2Int> visited = new HashSet<Vector2Int>();

		public override MazeDirection DecideDirection(Vector2Int position, bool canMoveLeft, bool canMoveRight, bool canMoveUp, bool canMoveDown)
		{
			available.Clear();
			if (canMoveLeft && !visited.Contains(position + new Vector2Int(-1, 0)))
			{
				available.Add(MazeDirection.Left);
			}
			if (canMoveRight && !visited.Contains(position + new Vector2Int(1, 0)))
			{
				available.Add(MazeDirection.Right);
			}
			if (canMoveUp && !visited.Contains(position + new Vector2Int(0, 1)))
			{
				available.Add(MazeDirection.Up);
			}
			if (canMoveDown && !visited.Contains(position + new Vector2Int(0, -1)))
			{
				available.Add(MazeDirection.Down);
			}
			MazeDirection mazeDirection = MazeDirection.Up;
			bool flag = false;
			if (available.Count == 0)
			{
				if (searchPath.Count <= 0)
				{
					base.enabled = false;
					throw new Exception("Mouse crawler could not find a solution to the maze. Giving up...");
				}
				mazeDirection = searchPath.Pop();
				switch (mazeDirection)
				{
				case MazeDirection.Left:
					mazeDirection = MazeDirection.Right;
					break;
				case MazeDirection.Right:
					mazeDirection = MazeDirection.Left;
					break;
				case MazeDirection.Up:
					mazeDirection = MazeDirection.Down;
					break;
				case MazeDirection.Down:
					mazeDirection = MazeDirection.Up;
					break;
				}
				flag = true;
			}
			else
			{
				mazeDirection = available[UnityEngine.Random.Range(0, available.Count)];
			}
			if (!flag)
			{
				searchPath.Push(mazeDirection);
			}
			if (!visited.Contains(position))
			{
				visited.Add(position);
			}
			return mazeDirection;
		}
	}
}
