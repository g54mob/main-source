using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	[RequireComponent(typeof(SphereCollider))]
	[ExecuteInEditMode]
	public class WallCornerNode : MonoBehaviour
	{
		[SerializeField]
		[ReadOnly]
		private WallCornerNode _westCornerNode;

		[SerializeField]
		[ReadOnly]
		private WallCornerNode _northCornerNode;

		[SerializeField]
		[ReadOnly]
		private WallCornerNode _eastCornerNode;

		[SerializeField]
		[ReadOnly]
		private WallCornerNode _southCornerNode;

		[SerializeField]
		private LayerMask _nodePhysicLayer;

		[SerializeField]
		[ReadOnly]
		private List<WallNode> _walls = new List<WallNode>();

		private static WallNode wallNodePrefab;

		private bool _dirty = true;

		public bool HasWestCorner => (object)_westCornerNode != null;

		public bool HasNorthCorner => (object)_northCornerNode != null;

		public bool HasEastCorner => (object)_eastCornerNode != null;

		public bool HasSouthCorner => (object)_southCornerNode != null;

		public Vector3Int GridPosition { get; private set; }

		public void RemoveWall(WallNode p_node)
		{
			_walls.Remove(p_node);
		}

		private static void LoadResources()
		{
			wallNodePrefab = Resources.Load<WallNode>("Construction/WallNode");
		}

		private static void TryFormConnectionsForNode(WallCornerNode p_originCornerNode, Collider[] p_collidersCache)
		{
			p_originCornerNode._westCornerNode = null;
			p_originCornerNode._eastCornerNode = null;
			p_originCornerNode._northCornerNode = null;
			p_originCornerNode._southCornerNode = null;
			Vector2Int vector2Int = p_originCornerNode.transform.position.ToHorizontal2D().RoundToInt();
			int num = Physics.OverlapSphereNonAlloc(p_originCornerNode.transform.position, 1f, p_collidersCache, p_originCornerNode._nodePhysicLayer, QueryTriggerInteraction.Collide);
			if (num <= 0)
			{
				return;
			}
			for (int i = 0; i < num; i++)
			{
				if (!p_collidersCache[i].TryGetComponent<WallCornerNode>(out var component) || component == p_originCornerNode)
				{
					continue;
				}
				Vector2Int vector2Int2 = component.transform.position.ToHorizontal2D().RoundToInt() - vector2Int;
				if (vector2Int2.x == 0 || vector2Int2.y == 0)
				{
					if (vector2Int2.x == 1)
					{
						p_originCornerNode._eastCornerNode = component;
						component._westCornerNode = p_originCornerNode;
					}
					else if (vector2Int2.x == -1)
					{
						p_originCornerNode._westCornerNode = component;
						component._eastCornerNode = p_originCornerNode;
					}
					else if (vector2Int2.y == 1)
					{
						p_originCornerNode._northCornerNode = component;
						component._southCornerNode = p_originCornerNode;
					}
					else
					{
						p_originCornerNode._southCornerNode = component;
						component._northCornerNode = p_originCornerNode;
					}
				}
			}
		}

		private static void CreateWallNodeForCorners(WallCornerNode p_originCornerNode, WallCornerNode p_node)
		{
			WallNode wallNode = Object.Instantiate(wallNodePrefab, Vector3.Lerp(p_originCornerNode.transform.position, p_node.transform.position, 0.5f), Quaternion.identity);
			p_originCornerNode._walls.Add(wallNode);
			p_node._walls.Add(wallNode);
			wallNode.SetParents(p_originCornerNode, p_node);
		}

		private static bool IsNodeValid(WallCornerNode p_cornerNode)
		{
			return p_cornerNode?._dirty ?? false;
		}

		private void OnDestroy()
		{
			if (Application.IsPlaying(this))
			{
				return;
			}
			if ((bool)_westCornerNode)
			{
				_westCornerNode._eastCornerNode = null;
			}
			if ((bool)_northCornerNode)
			{
				_northCornerNode._southCornerNode = null;
			}
			if ((bool)_eastCornerNode)
			{
				_eastCornerNode._westCornerNode = null;
			}
			if ((bool)_southCornerNode)
			{
				_southCornerNode._northCornerNode = null;
			}
			if (_walls.Count > 0)
			{
				while (_walls.Count > 0)
				{
					Object.DestroyImmediate(_walls[0].gameObject);
				}
			}
		}

		private void OnValidate()
		{
			GridPosition = base.transform.position.RoundToInt();
			base.transform.position = GridPosition;
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(base.transform.position + Vector3.up, 0.26f);
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			Vector3 vector = base.transform.position + Vector3.up;
			Gizmos.DrawSphere(vector, 0.25f);
			if ((bool)_westCornerNode)
			{
				Gizmos.DrawLine(vector, _westCornerNode.transform.position + Vector3.up);
			}
			if ((bool)_northCornerNode)
			{
				Gizmos.DrawLine(vector, _northCornerNode.transform.position + Vector3.up);
			}
			if ((bool)_eastCornerNode)
			{
				Gizmos.DrawLine(vector, _eastCornerNode.transform.position + Vector3.up);
			}
			if ((bool)_southCornerNode)
			{
				Gizmos.DrawLine(vector, _southCornerNode.transform.position + Vector3.up);
			}
		}
	}
}
