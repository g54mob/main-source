using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class MazerellaDancerMazeNavigation : MonoBehaviour
	{
		public enum MazerellaNavigationNodeDirection
		{
			North = 0,
			South = 1,
			East = 2,
			West = 3
		}

		[Serializable]
		public class NavigationNode
		{
			public Vector2 Position;

			public int LeftDancerWeight;

			public int RightDancerWeight;

			public NavigationNode NorthNode;

			public NavigationNode SouthNode;

			public NavigationNode EastNode;

			public NavigationNode WestNode;
		}

		private const float DistanceBetweenNodes = 5.12f;

		private const float HalfDistanceBetweenNodes = 2.56f;

		private const float FirstNodeX = 12.16f;

		private const float FirstNodeY = 12.16f;

		private const float InverseFirstNodeX = 74.88f;

		private const float InverseFirstNodeY = 74.88f;

		private const int PlayerStartNavigationNodeIndex = 84;

		private const int LeftDancerDestinationNavigationNodeIndex = 6;

		private const int RightDancerDestinationNavigationNodeIndex = 162;

		private readonly List<PathLineSegment> _lineSegmentsBetweenDanceFloors;

		public List<NavigationNode> NavigationNodes { get; }

		public float CurrentTotalNormalizedPosition { get; private set; }

		private void PrecalculateNavigationWeights()
		{
		}

		private void CachePathBetweenDanceFloors()
		{
		}

		private List<NavigationNode> GetPathToDanceFloor(NavigationNode startNode, NavigationNode targetNode, EnemyMazerellaDancer.DancerSide dancerSide)
		{
			return null;
		}

		private NavigationNode GetLowestWeightNode(NavigationNode navigationNode, EnemyMazerellaDancer.DancerSide dancerSide)
		{
			return null;
		}

		private int GetNodeWeight(NavigationNode nodeToCheck, EnemyMazerellaDancer.DancerSide dancerSide)
		{
			return 0;
		}

		private Vector3 GetNearestPositionOnPathBetweenDanceFloors(Vector3 position, out int lineSegmentIndex, out float normalizedDistanceOnLineSegment)
		{
			lineSegmentIndex = default(int);
			normalizedDistanceOnLineSegment = default(float);
			return default(Vector3);
		}

		public Vector3 GetPositionOnLineSegmentWithOffset(int lineSegmentIndex, float startPointNormalizedPosition, float offsetDistanceInWorldSpace)
		{
			return default(Vector3);
		}

		private Vector3 GetClosestPointOnLineToPoint(PathLineSegment lineSegment, Vector3 point, out float normalizedDistance)
		{
			normalizedDistance = default(float);
			return default(Vector3);
		}

		private Vector3 GetClosestPointOnLineToPoint(Vector3 lineStart, Vector3 lineEnd, Vector3 point, out float normalizedDistance)
		{
			normalizedDistance = default(float);
			return default(Vector3);
		}

		private void SetLeftDancerWeight(NavigationNode currentNode, int weightToSet)
		{
		}

		private void SetRightDancerWeight(NavigationNode currentNode, int weightToSet)
		{
		}

		public void UpdateNearestPositionToPlayer(Transform playerTransform)
		{
		}

		public bool TryGetNodeInDirection(MazerellaNavigationNodeDirection direction, NavigationNode currentNode, out NavigationNode navigationNode)
		{
			navigationNode = null;
			return false;
		}

		public void ConfigureNavigationNodes(Tilemap walls)
		{
		}

		private void CreateNodes()
		{
		}

		private void ProcessNavigationNodes(Tilemap walls)
		{
		}
	}
}
