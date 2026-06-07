using System;
using UnityEngine;

[ExecuteInEditMode]
public class TubeRenderer : MonoBehaviour
{
	public enum NormalMode
	{
		Smooth = 0,
		Hard = 1,
		HardEdges = 2
	}

	public enum CapMode
	{
		None = 0,
		Begin = 1,
		End = 2,
		Both = 3
	}

	public delegate void Postprocess(Vector3[] vertices, Vector3[] normals, Vector4[] tangents);

	[SerializeField]
	private Vector3[] _points;

	[SerializeField]
	private float[] _radiuses;

	[SerializeField]
	private float _radius;

	[SerializeField]
	private Color32[] _pointColors;

	[SerializeField]
	private int _edgeCount;

	[SerializeField]
	private bool _calculateTangents;

	[SerializeField]
	private bool _invertMesh;

	[SerializeField]
	private NormalMode _normalMode;

	[SerializeField]
	private CapMode _caps;

	[SerializeField]
	private bool _postprocessContinously;

	[SerializeField]
	private Rect _uvRect;

	[SerializeField]
	private Rect _uvRectCap;

	[SerializeField]
	private bool _uvRectCapEndMirrored;

	[SerializeField]
	private float _forwardAngleOffset;

	[SerializeField]
	private Mesh _mesh;

	[SerializeField]
	private bool _showMeshGizmos;

	[SerializeField]
	private float _meshGizmoLength;

	[SerializeField]
	private bool _showRotationGizmos;

	[SerializeField]
	private float _rotationGizmoLength;

	[SerializeField]
	private bool _pointsFoldout;

	[SerializeField]
	private bool _radiusesFoldout;

	[SerializeField]
	private bool _colorsFoldout;

	[SerializeField]
	private bool _uvFoldout;

	private Vector3[] _vertices;

	private Vector3[] _normals;

	private int[] _triangles;

	private Vector2[] _uvs;

	private Vector4[] _tangents;

	private Color32[] _colors32;

	private Vector3[] _circlePointLookup;

	private Vector3[] _circleNormalLookup;

	private Vector3[] _circleTangentLookup;

	private Quaternion[] _rotations;

	private Vector3[] _directions;

	private float[] _lengths;

	private float[] _steepnessAngles;

	private Vector3 _pastBeginUp;

	private float _length;

	private MeshFilter _filter;

	private bool _dirtyCircle;

	private bool _dirtyRotations;

	private bool _dirtySteepnessAngles;

	private bool _dirtyVertexCount;

	private bool _redrawFlag;

	private bool _dirtyTriangles;

	private bool _dirtyUVs;

	private bool _dirtyColors;

	private const float tau = (float)Math.PI * 2f;

	private const int meshVertexCountLimit = 65000;

	private const string logPrepend = "<b>[TubeRenderer]</b> ";

	private Postprocess Postprocesses;

	public Vector3[] points
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float[] radiuses
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float radius
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public Color32[] colors
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int edgeCount
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool calculateTangents
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool invertMesh
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public NormalMode normalMode
	{
		get
		{
			return default(NormalMode);
		}
		set
		{
		}
	}

	public CapMode caps
	{
		get
		{
			return default(CapMode);
		}
		set
		{
		}
	}

	public bool postprocessContinously
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Rect uvRect
	{
		get
		{
			return default(Rect);
		}
		set
		{
		}
	}

	public Rect uvRectCap
	{
		get
		{
			return default(Rect);
		}
		set
		{
		}
	}

	public bool uvRectCapEndMirrored
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float forwardAngleOffset
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float length => 0f;

	public Mesh mesh => null;

	public bool showMeshGizmos
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float meshGizmoLength
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool showRotationGizmos
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float rotationGizmoLength
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public void ForceUpdate()
	{
	}

	public void MarkDynamic()
	{
	}

	public void AddPostprocess(Postprocess postprocess)
	{
	}

	public void RemovePostprocess(Postprocess postprocess)
	{
	}

	public Quaternion GetRotationAtPoint(int index)
	{
		return default(Quaternion);
	}

	private void Awake()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnValidate()
	{
	}

	private void OnDidApplyAnimationProperties()
	{
	}

	private void OnDrawGizmos()
	{
	}

	private void ReDraw()
	{
	}

	private void ReDrawSmoothNormals()
	{
	}

	private void ReDrawHardNormals()
	{
	}

	private void ReDrawHardNormalEdges()
	{
	}

	private void UpdateVertexCount()
	{
	}

	private void UpdateCircleLookup()
	{
	}

	private void UpdateRotations()
	{
	}

	private void UpdateSteepnessAngles()
	{
	}

	private void UpdateTriangles()
	{
	}

	private void UpdateUVs()
	{
	}

	private void UpdateColors()
	{
	}

	private static int ComputeVertexCountForProperties(int pointCount, int edgeCount, NormalMode normalMode, CapMode capMode)
	{
		return 0;
	}
}
