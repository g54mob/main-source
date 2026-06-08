using System;
using System.Collections.Generic;
using UnityEngine;

namespace RoslynCSharp.Example
{
	public abstract class MazeCrawler : MonoBehaviour
	{
		private List<GameObject> droppedBreadcrumbs = new List<GameObject>();

		private HashSet<Vector2Int> visited = new HashSet<Vector2Int>();

		private Vector2 startPosition;

		private Vector2 currentPosition;

		private Vector2 targetPosition;

		public GameObject breadcrumbPrefab;

		public float moveSpeed = 2f;

		public abstract MazeDirection DecideDirection(Vector2Int position, bool canMoveLeft, bool canMoveRight, bool canMoveUp, bool canMoveDown);

		public void Awake()
		{
			startPosition = base.transform.position;
			currentPosition = base.transform.position;
			targetPosition = base.transform.position;
		}

		public void Update()
		{
			if (HasArrived(targetPosition))
			{
				currentPosition = targetPosition;
				bool flag = CanMoveInDirection(MazeDirection.Left);
				bool flag2 = CanMoveInDirection(MazeDirection.Right);
				bool flag3 = CanMoveInDirection(MazeDirection.Up);
				bool flag4 = CanMoveInDirection(MazeDirection.Down);
				Vector2Int vector2Int = new Vector2Int(Mathf.RoundToInt(currentPosition.x), Mathf.RoundToInt(currentPosition.y));
				if (!visited.Contains(vector2Int))
				{
					visited.Add(vector2Int);
					DropBreadcrumb();
				}
				try
				{
					switch (DecideDirection(vector2Int, flag, flag2, flag3, flag4))
					{
					case MazeDirection.Up:
						if (!flag3)
						{
							throw new InvalidOperationException("Invalid decision: Cannot move up. Game will restart");
						}
						targetPosition = currentPosition + new Vector2(0f, 1f);
						base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
						break;
					case MazeDirection.Down:
						if (!flag4)
						{
							throw new InvalidOperationException("Invalid decision: Cannot move down. Game will restart");
						}
						targetPosition = currentPosition + new Vector2(0f, -1f);
						base.transform.localEulerAngles = new Vector3(0f, 0f, 180f);
						break;
					case MazeDirection.Left:
						if (!flag)
						{
							throw new InvalidOperationException("Invalid decision: Cannot move left. Game will restart");
						}
						targetPosition = currentPosition + new Vector2(-1f, 0f);
						base.transform.localEulerAngles = new Vector3(0f, 0f, 90f);
						break;
					case MazeDirection.Right:
						if (!flag2)
						{
							throw new InvalidOperationException("Invalid decision: Cannot move right. Game will restart");
						}
						targetPosition = currentPosition + new Vector2(1f, 0f);
						base.transform.localEulerAngles = new Vector3(0f, 0f, -90f);
						break;
					}
					return;
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Restart();
					return;
				}
			}
			base.transform.position = Vector2.MoveTowards(base.transform.position, targetPosition, moveSpeed * Time.deltaTime);
		}

		public void Restart()
		{
			foreach (GameObject droppedBreadcrumb in droppedBreadcrumbs)
			{
				UnityEngine.Object.Destroy(droppedBreadcrumb);
			}
			droppedBreadcrumbs.Clear();
			visited.Clear();
			base.transform.position = startPosition;
			currentPosition = base.transform.position;
			targetPosition = base.transform.position;
		}

		private bool CanMoveInDirection(MazeDirection direction)
		{
			float num = 0f;
			float num2 = 0f;
			if (direction == MazeDirection.Left)
			{
				num -= 1f;
			}
			if (direction == MazeDirection.Right)
			{
				num += 1f;
			}
			if (direction == MazeDirection.Up)
			{
				num2 += 1f;
			}
			if (direction == MazeDirection.Down)
			{
				num2 -= 1f;
			}
			RaycastHit2D raycastHit2D = Physics2D.Raycast(direction: new Vector2(num, num2), origin: base.transform.position, distance: 0.75f);
			if (raycastHit2D.collider != null)
			{
				if (raycastHit2D.collider.gameObject.name == "MazeWallFinish")
				{
					base.enabled = false;
					Debug.Log("Congratulations! Your crawler successfully escaped the maze");
					return false;
				}
				if (raycastHit2D.collider.gameObject.name == "MazeWall")
				{
					return false;
				}
			}
			return true;
		}

		private bool HasArrived(Vector2 targetPosition)
		{
			return Vector2.Distance(targetPosition, base.transform.position) < 0.05f;
		}

		private void DropBreadcrumb()
		{
			if (breadcrumbPrefab != null)
			{
				GameObject item = UnityEngine.Object.Instantiate(breadcrumbPrefab, base.transform.position, Quaternion.identity);
				droppedBreadcrumbs.Add(item);
			}
		}
	}
}
