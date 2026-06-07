using System.Collections.Generic;
using UnityEngine;

namespace Brewery.Map
{
	[ExecuteAlways]
	public class BoundaryWallBuilder : MonoBehaviour
	{
		[SerializeField]
		private List<Vector3> points;

		[SerializeField]
		private float wallHeight;

		[SerializeField]
		private float wallDepth;

		[SerializeField]
		private float wallThickness;

		[SerializeField]
		private bool closedLoop;

		[SerializeField]
		private string wallLayer;

		[Header("Gizmo Appearance")]
		[SerializeField]
		private Color lineColor;

		[SerializeField]
		private Color wallPreviewColor;

		[SerializeField]
		private Color pointColor;

		public List<Vector3> Points => null;

		public float WallHeight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float WallDepth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float WallThickness
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool ClosedLoop
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string WallLayer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void AddPoint(Vector3 point)
		{
		}

		public void InsertPoint(int index, Vector3 point)
		{
		}

		public void RemovePoint(int index)
		{
		}

		public void MovePoint(int index, Vector3 newPosition)
		{
		}

		public void ClearPoints()
		{
		}

		public void GenerateWalls()
		{
		}

		public void ClearWalls()
		{
		}

		private void CreateWallSegment(Vector3 a, Vector3 b, int index)
		{
		}

		private void OnDrawGizmos()
		{
		}

		private void DrawWallPreview(Vector3 a, Vector3 b)
		{
		}
	}
}
