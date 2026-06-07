using System;
using UnityEngine;

namespace Dreamteck.Splines
{
	[ExecuteInEditMode]
	[AddComponentMenu("Dreamteck/Splines/Node Connector")]
	public class Node : MonoBehaviour
	{
		[Serializable]
		public class Connection
		{
			public bool invertTangents;

			[SerializeField]
			private int _pointIndex;

			[SerializeField]
			private SplineComputer _computer;

			[SerializeField]
			[HideInInspector]
			internal SplinePoint point;

			public SplineComputer spline => null;

			public int pointIndex => 0;

			internal bool isValid => false;

			internal Connection(SplineComputer comp, int index, SplinePoint inputPoint)
			{
			}
		}

		public enum Type
		{
			Smooth = 0,
			Free = 1
		}

		[HideInInspector]
		public Type type;

		[SerializeField]
		[HideInInspector]
		protected Connection[] connections;

		[SerializeField]
		[HideInInspector]
		private bool _transformSize;

		[SerializeField]
		[HideInInspector]
		private bool _transformNormals;

		[SerializeField]
		[HideInInspector]
		private bool _transformTangents;

		private Vector3 _lastPosition;

		private Vector3 _lastScale;

		private Quaternion _lastRotation;

		private Transform _trs;

		public bool transformNormals
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool transformSize
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool transformTangents
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void LateUpdate()
		{
		}

		private void Update()
		{
		}

		private bool TransformChanged()
		{
			return false;
		}

		private void SampleTransform()
		{
		}

		private void Run()
		{
		}

		public SplinePoint GetPoint(int connectionIndex, bool swapTangents)
		{
			return default(SplinePoint);
		}

		public void SetPoint(int connectionIndex, SplinePoint worldPoint, bool swappedTangents)
		{
		}

		private void OnDestroy()
		{
		}

		public void ClearConnections()
		{
		}

		public void UpdateConnectedComputers(SplineComputer excludeComputer = null)
		{
		}

		public void UpdatePoint(SplineComputer computer, int pointIndex, SplinePoint point, bool updatePosition = true)
		{
		}

		public void UpdatePoints()
		{
		}

		protected void RemoveInvalidConnections()
		{
		}

		public virtual void AddConnection(SplineComputer computer, int pointIndex)
		{
		}

		protected SplinePoint PointToLocal(SplinePoint worldPoint)
		{
			return default(SplinePoint);
		}

		protected SplinePoint PointToWorld(SplinePoint localPoint)
		{
			return default(SplinePoint);
		}

		public virtual void RemoveConnection(SplineComputer computer, int pointIndex)
		{
		}

		private void RemoveConnection(int index)
		{
		}

		public virtual bool HasConnection(SplineComputer computer, int pointIndex)
		{
			return false;
		}

		public Connection[] GetConnections()
		{
			return null;
		}
	}
}
