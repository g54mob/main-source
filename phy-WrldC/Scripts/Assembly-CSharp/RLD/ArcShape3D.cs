using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class ArcShape3D : Shape3D
	{
		public enum WireRenderFlags
		{
			None = 0,
			ExtremitiesBorder = 1,
			ArcBorder = 2,
			All = 3
		}

		public class WireRenderDescriptor
		{
			private WireRenderFlags _wireFlags = WireRenderFlags.All;

			public WireRenderFlags WireFlags
			{
				get
				{
					return _wireFlags;
				}
				set
				{
					_wireFlags = value;
				}
			}
		}

		private WireRenderDescriptor _wireRenderDesc = new WireRenderDescriptor();

		private Vector3 _startPoint;

		private Vector3 _endPoint;

		private Vector3 _origin;

		private Plane _plane;

		private float _radius;

		private AABB _aabb;

		private float _degreeAngleFromStart;

		private bool _forceShortestArc;

		private List<Vector3> _borderPoints;

		private int _numBorderPoints = 100;

		private bool _areBorderPointsDirty = true;

		private ArcEpsilon _epsilon;

		private Shape3DRaycastMode _raycastMode;

		public float Radius
		{
			get
			{
				return _radius;
			}
			set
			{
				_radius = value;
				_startPoint = _origin + (_startPoint - _origin).normalized * _radius;
				CalculateEndPoint();
				_areBorderPointsDirty = true;
			}
		}

		public bool ForceShortestArc
		{
			get
			{
				return _forceShortestArc;
			}
			set
			{
				_forceShortestArc = value;
				CalculateEndPoint();
				_areBorderPointsDirty = true;
			}
		}

		public float DegreeAngleFromStart
		{
			get
			{
				return _degreeAngleFromStart;
			}
			set
			{
				_degreeAngleFromStart = value % 360f;
				CalculateEndPoint();
				_areBorderPointsDirty = true;
			}
		}

		public float AbsDegreeAngleFromStart => Mathf.Abs(_degreeAngleFromStart);

		public int NumBorderPoints
		{
			get
			{
				return _numBorderPoints;
			}
			set
			{
				_numBorderPoints = Mathf.Max(3, value);
				_areBorderPointsDirty = true;
			}
		}

		public Vector3 Origin
		{
			get
			{
				return _origin;
			}
			set
			{
				Vector3 normalized = (_startPoint - _origin).normalized;
				_origin = value;
				_startPoint = _origin + normalized * _radius;
				CalculateEndPoint();
				_areBorderPointsDirty = true;
			}
		}

		public Vector3 StartPoint => _startPoint;

		public Vector3 EndPoint => _endPoint;

		public Plane Plane => _plane;

		public Vector3 Normal => _plane.normal;

		public ArcEpsilon Epsilon
		{
			get
			{
				return _epsilon;
			}
			set
			{
				_epsilon = value;
			}
		}

		public float AreaEps
		{
			get
			{
				return _epsilon.AreaEps;
			}
			set
			{
				_epsilon.AreaEps = value;
			}
		}

		public float ExtrudeEps
		{
			get
			{
				return _epsilon.ExtrudeEps;
			}
			set
			{
				_epsilon.ExtrudeEps = value;
			}
		}

		public float WireEps
		{
			get
			{
				return _epsilon.WireEps;
			}
			set
			{
				_epsilon.WireEps = value;
			}
		}

		public WireRenderDescriptor WireRenderDesc => _wireRenderDesc;

		public Shape3DRaycastMode RaycastMode
		{
			get
			{
				return _raycastMode;
			}
			set
			{
				_raycastMode = value;
			}
		}

		public override void RenderSolid()
		{
			if (_areBorderPointsDirty)
			{
				OnBorderPointsFoundDirty();
			}
			GLRenderer.DrawTriangleFan3D(_origin, _borderPoints);
		}

		public override void RenderWire()
		{
			if (_areBorderPointsDirty)
			{
				OnBorderPointsFoundDirty();
			}
			if ((_wireRenderDesc.WireFlags & WireRenderFlags.ArcBorder) != WireRenderFlags.None)
			{
				GLRenderer.DrawLines3D(_borderPoints);
			}
			if ((_wireRenderDesc.WireFlags & WireRenderFlags.ExtremitiesBorder) != WireRenderFlags.None)
			{
				GLRenderer.DrawLines3D(new List<Vector3> { _origin, StartPoint, _origin, EndPoint });
			}
		}

		public void SetArcData(Plane plane, Vector3 origin, Vector3 startPoint, float radius)
		{
			_plane = plane;
			_origin = _plane.ProjectPoint(origin);
			_startPoint = _plane.ProjectPoint(startPoint);
			Radius = radius;
		}

		public override bool Raycast(Ray ray, out float t)
		{
			if (_raycastMode == Shape3DRaycastMode.Solid)
			{
				if (_forceShortestArc || AbsDegreeAngleFromStart <= 180f)
				{
					return ArcMath.RaycastShArc(ray, out t, _origin, StartPoint, Plane.normal, DegreeAngleFromStart, _epsilon);
				}
				return ArcMath.RaycastLgArc(ray, out t, _origin, StartPoint, Plane.normal, DegreeAngleFromStart, _epsilon);
			}
			if (_forceShortestArc || AbsDegreeAngleFromStart <= 180f)
			{
				return ArcMath.RaycastShArcWire(ray, out t, _origin, StartPoint, Plane.normal, DegreeAngleFromStart, _epsilon);
			}
			return ArcMath.RaycastLgArcWire(ray, out t, _origin, StartPoint, Plane.normal, DegreeAngleFromStart, _epsilon);
		}

		public override bool RaycastWire(Ray ray, out float t)
		{
			if (_forceShortestArc || AbsDegreeAngleFromStart <= 180f)
			{
				return ArcMath.RaycastShArcWire(ray, out t, _origin, StartPoint, Plane.normal, DegreeAngleFromStart, _epsilon);
			}
			return ArcMath.RaycastLgArcWire(ray, out t, _origin, StartPoint, Plane.normal, DegreeAngleFromStart, _epsilon);
		}

		public bool ContainsPoint(Vector3 point, bool checkOnPlane)
		{
			if (_forceShortestArc || AbsDegreeAngleFromStart <= 180f)
			{
				return ArcMath.ShArcContains3DPoint(point, checkOnPlane, _origin, _startPoint, _plane.normal, _degreeAngleFromStart, _epsilon);
			}
			return ArcMath.LgArcContains3DPoint(point, checkOnPlane, _origin, _startPoint, _plane.normal, _degreeAngleFromStart, _epsilon);
		}

		public override AABB GetAABB()
		{
			if (_areBorderPointsDirty)
			{
				OnBorderPointsFoundDirty();
			}
			return _aabb;
		}

		private void OnBorderPointsFoundDirty()
		{
			_borderPoints = PrimitiveFactory.Generate3DArcBorderPoints(_origin, _startPoint, _plane, _degreeAngleFromStart, _forceShortestArc, _numBorderPoints);
			_aabb = new AABB(_borderPoints);
			_aabb.Encapsulate(_origin);
			_areBorderPointsDirty = false;
		}

		private void CalculateEndPoint()
		{
			Vector3 vector = StartPoint - _origin;
			_endPoint = _origin + Quaternion.AngleAxis(DegreeAngleFromStart, Plane.normal) * vector;
		}
	}
}
