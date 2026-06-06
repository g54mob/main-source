using System;
using UnityEngine;

namespace MalbersAnimations.PathCreation
{
	[Serializable]
	public class PathCreatorData
	{
		[SerializeField]
		private BezierPath _bezierPath;

		private VertexPath _vertexPath;

		[SerializeField]
		private bool vertexPathUpToDate;

		public float vertexPathMaxAngleError = 0.3f;

		public float vertexPathMinVertexSpacing = 0.01f;

		public bool showTransformTool = true;

		public bool showPathBounds;

		public bool showPerSegmentBounds;

		public bool displayAnchorPoints = true;

		public bool displayControlPoints = true;

		public bool globalDisplaySettingsFoldout;

		public bool keepConstantHandleSize;

		public bool showNormalsInVertexMode;

		public bool showBezierPathInVertexMode;

		public bool showDisplayOptions;

		public bool showPathOptions = true;

		public bool showVertexPathDisplayOptions;

		public bool showVertexPathOptions = true;

		public bool showNormals;

		public bool showNormalsHelpInfo;

		public int tabIndex;

		public BezierPath bezierPath
		{
			get
			{
				return _bezierPath;
			}
			set
			{
				_bezierPath.OnModified -= BezierPathEdited;
				vertexPathUpToDate = false;
				_bezierPath = value;
				_bezierPath.OnModified += BezierPathEdited;
				if (this.bezierOrVertexPathModified != null)
				{
					this.bezierOrVertexPathModified();
				}
				if (this.bezierCreated != null)
				{
					this.bezierCreated();
				}
			}
		}

		public event Action bezierOrVertexPathModified;

		public event Action bezierCreated;

		public void Initialize(bool defaultIs2D)
		{
			if (_bezierPath == null)
			{
				CreateBezier(Vector3.zero, defaultIs2D);
			}
			vertexPathUpToDate = false;
			_bezierPath.OnModified -= BezierPathEdited;
			_bezierPath.OnModified += BezierPathEdited;
		}

		public void ResetBezierPath(Vector3 centre, bool defaultIs2D = false)
		{
			CreateBezier(centre, defaultIs2D);
		}

		private void CreateBezier(Vector3 centre, bool defaultIs2D = false)
		{
			if (_bezierPath != null)
			{
				_bezierPath.OnModified -= BezierPathEdited;
			}
			PathSpace space = (defaultIs2D ? PathSpace.xy : PathSpace.xyz);
			_bezierPath = new BezierPath(centre, isClosed: false, space);
			_bezierPath.OnModified += BezierPathEdited;
			vertexPathUpToDate = false;
			if (this.bezierOrVertexPathModified != null)
			{
				this.bezierOrVertexPathModified();
			}
			if (this.bezierCreated != null)
			{
				this.bezierCreated();
			}
		}

		public VertexPath GetVertexPath(Transform transform)
		{
			if (!vertexPathUpToDate || _vertexPath == null)
			{
				vertexPathUpToDate = true;
				_vertexPath = new VertexPath(bezierPath, transform, vertexPathMaxAngleError, vertexPathMinVertexSpacing);
			}
			return _vertexPath;
		}

		public void PathTransformed()
		{
			if (this.bezierOrVertexPathModified != null)
			{
				this.bezierOrVertexPathModified();
			}
		}

		public void VertexPathSettingsChanged()
		{
			vertexPathUpToDate = false;
			if (this.bezierOrVertexPathModified != null)
			{
				this.bezierOrVertexPathModified();
			}
		}

		public void PathModifiedByUndo()
		{
			vertexPathUpToDate = false;
			if (this.bezierOrVertexPathModified != null)
			{
				this.bezierOrVertexPathModified();
			}
		}

		private void BezierPathEdited()
		{
			vertexPathUpToDate = false;
			if (this.bezierOrVertexPathModified != null)
			{
				this.bezierOrVertexPathModified();
			}
		}
	}
}
