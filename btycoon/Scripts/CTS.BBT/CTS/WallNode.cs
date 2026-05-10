using UnityEngine;

namespace CTS
{
	[ExecuteInEditMode]
	public class WallNode : MonoBehaviour
	{
		private enum EAxis
		{
			X = 0,
			Z = 1
		}

		[SerializeField]
		[ReadOnly]
		private WallCornerNode[] _parentNodes;

		private MeshFilter[] _meshFilters;

		private MeshRenderer[] _meshRenderers;

		private EAxis _axis;

		private static Mesh[] wallMeshes;

		private static void LoadResources()
		{
			if (wallMeshes != null)
			{
				return;
			}
			GameObject gameObject = Resources.Load<GameObject>("Construction/SM_Walls");
			if ((object)gameObject != null)
			{
				MeshFilter[] componentsInChildren = gameObject.GetComponentsInChildren<MeshFilter>();
				wallMeshes = new Mesh[componentsInChildren.Length];
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					wallMeshes[i] = componentsInChildren[i].sharedMesh;
				}
			}
		}

		private void Awake()
		{
			_meshFilters = GetComponentsInChildren<MeshFilter>();
			_meshRenderers = GetComponentsInChildren<MeshRenderer>();
		}

		public void SetParents(WallCornerNode p_firstNode, WallCornerNode p_secondNode)
		{
			_parentNodes = new WallCornerNode[2];
			_parentNodes[0] = p_firstNode;
			_parentNodes[1] = p_secondNode;
			_axis = ((_parentNodes[0].GridPosition.x == _parentNodes[1].GridPosition.x) ? EAxis.Z : EAxis.X);
			base.transform.rotation = Quaternion.Euler(0f, (_axis == EAxis.Z) ? 90f : 0f, 0f);
			BakeMesh();
		}

		private void BakeMesh()
		{
			LoadResources();
			if (_axis == EAxis.X)
			{
				BakeMeshOnX();
			}
			else
			{
				BakeMeshOnZ();
			}
		}

		private void BakeMeshOnX()
		{
			WallCornerNode wallCornerNode = ((_parentNodes[0].GridPosition.x < _parentNodes[1].GridPosition.x) ? _parentNodes[0] : _parentNodes[1]);
			WallCornerNode p_eastNode = ((wallCornerNode == _parentNodes[0]) ? _parentNodes[1] : _parentNodes[0]);
			BakeNorth(wallCornerNode, p_eastNode);
			BakeSouth(wallCornerNode, p_eastNode);
		}

		private void BakeNorth(WallCornerNode p_westNode, WallCornerNode p_eastNode)
		{
			if (p_eastNode.HasNorthCorner)
			{
				FindRightSide(0);
			}
			else if (p_eastNode.HasEastCorner)
			{
				FindRightSide(12);
			}
			else if (p_eastNode.HasSouthCorner)
			{
				FindRightSide(4);
			}
			else
			{
				FindRightSide(8);
			}
			void FindRightSide(int p_left)
			{
				if (p_westNode.HasNorthCorner)
				{
					_meshFilters[0].mesh = wallMeshes[p_left];
				}
				else if (p_westNode.HasWestCorner)
				{
					_meshFilters[0].mesh = wallMeshes[p_left + 3];
				}
				else if (p_westNode.HasSouthCorner)
				{
					_meshFilters[0].mesh = wallMeshes[p_left + 1];
				}
				else
				{
					_meshFilters[0].mesh = wallMeshes[p_left + 2];
				}
			}
		}

		private void BakeSouth(WallCornerNode p_westNode, WallCornerNode p_eastNode)
		{
			if (p_westNode.HasSouthCorner)
			{
				FindRightSide(0);
			}
			else if (p_westNode.HasWestCorner)
			{
				FindRightSide(12);
			}
			else if (p_westNode.HasNorthCorner)
			{
				FindRightSide(4);
			}
			else
			{
				FindRightSide(8);
			}
			void FindRightSide(int p_left)
			{
				if (p_eastNode.HasSouthCorner)
				{
					_meshFilters[1].mesh = wallMeshes[p_left];
				}
				else if (p_eastNode.HasEastCorner)
				{
					_meshFilters[1].mesh = wallMeshes[p_left + 3];
				}
				else if (p_eastNode.HasNorthCorner)
				{
					_meshFilters[1].mesh = wallMeshes[p_left + 1];
				}
				else
				{
					_meshFilters[1].mesh = wallMeshes[p_left + 2];
				}
			}
		}

		private void BakeMeshOnZ()
		{
			WallCornerNode wallCornerNode = ((_parentNodes[0].GridPosition.z < _parentNodes[1].GridPosition.z) ? _parentNodes[0] : _parentNodes[1]);
			WallCornerNode p_northNode = ((wallCornerNode == _parentNodes[0]) ? _parentNodes[1] : _parentNodes[0]);
			BakeWest(p_northNode, wallCornerNode);
			BakeEast(p_northNode, wallCornerNode);
		}

		private void BakeWest(WallCornerNode p_northNode, WallCornerNode p_southNode)
		{
			if (p_northNode.HasWestCorner)
			{
				FindRightSide(0);
			}
			else if (p_northNode.HasNorthCorner)
			{
				FindRightSide(12);
			}
			else if (p_northNode.HasEastCorner)
			{
				FindRightSide(4);
			}
			else
			{
				FindRightSide(8);
			}
			void FindRightSide(int p_left)
			{
				if (p_southNode.HasWestCorner)
				{
					_meshFilters[1].mesh = wallMeshes[p_left];
				}
				else if (p_southNode.HasSouthCorner)
				{
					_meshFilters[1].mesh = wallMeshes[p_left + 3];
				}
				else if (p_southNode.HasEastCorner)
				{
					_meshFilters[1].mesh = wallMeshes[p_left + 1];
				}
				else
				{
					_meshFilters[1].mesh = wallMeshes[p_left + 2];
				}
			}
		}

		private void BakeEast(WallCornerNode p_northNode, WallCornerNode p_southNode)
		{
			if (p_southNode.HasEastCorner)
			{
				FindRightSide(0);
			}
			else if (p_southNode.HasSouthCorner)
			{
				FindRightSide(12);
			}
			else if (p_southNode.HasWestCorner)
			{
				FindRightSide(4);
			}
			else
			{
				FindRightSide(8);
			}
			void FindRightSide(int p_left)
			{
				if (p_northNode.HasEastCorner)
				{
					_meshFilters[0].mesh = wallMeshes[p_left];
				}
				else if (p_northNode.HasNorthCorner)
				{
					_meshFilters[0].mesh = wallMeshes[p_left + 3];
				}
				else if (p_northNode.HasWestCorner)
				{
					_meshFilters[0].mesh = wallMeshes[p_left + 1];
				}
				else
				{
					_meshFilters[0].mesh = wallMeshes[p_left + 2];
				}
			}
		}

		private void OnDestroy()
		{
			if (_parentNodes != null)
			{
				_parentNodes[0].RemoveWall(this);
				_parentNodes[1].RemoveWall(this);
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawCube(base.transform.position + Vector3.up, Vector3.one * 0.15f);
		}
	}
}
