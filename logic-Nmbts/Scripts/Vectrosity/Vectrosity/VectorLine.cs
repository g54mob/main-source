using System;
using System.Collections.Generic;
using UnityEngine;

namespace Vectrosity
{
	[Serializable]
	public class VectorLine
	{
		private enum FunctionName
		{
			SetColors = 0,
			SetColorsSmooth = 1,
			SetWidths = 2,
			MakeCurve = 3,
			MakeSpline = 4,
			MakeEllipse = 5
		}

		private const float cutoff = 0.15f;

		private GameObject m_vectorObject;

		private MeshFilter m_meshFilter;

		private Mesh m_mesh;

		private Vector3[] m_lineVertices;

		private Vector2[] m_lineUVs;

		private Color32[] m_lineColors;

		public Vector2[] points2;

		public Vector3[] points3;

		private int m_pointsLength;

		private bool m_is2D;

		private Vector3[] m_screenPoints;

		private float[] m_lineWidths;

		private float m_maxWeldDistance;

		private float[] m_distances;

		private string m_name;

		private Material m_material;

		private bool m_active = true;

		public float capLength = 0f;

		private int m_depth = 0;

		public bool smoothWidth = false;

		private int m_layer = -1;

		private bool m_continuous;

		private Joins m_joins;

		private bool m_isPoints;

		private bool m_isAutoDrawing = false;

		private int m_minDrawIndex = 0;

		private int m_maxDrawIndex = 0;

		private int m_drawStart = 0;

		private int m_drawEnd = 0;

		private bool m_useNormals = false;

		private bool m_useTangents = false;

		private bool m_normalsCalculated = false;

		private bool m_tangentsCalculated = false;

		private int m_triangleCount;

		private int m_vertexCount;

		private EndCap m_capType = EndCap.None;

		private string m_endCap;

		private bool m_continuousTexture = false;

		private Transform m_useTransform;

		private bool m_1pixelLine = false;

		private static bool m_useMeshQuads = false;

		private static bool m_useMeshLines = false;

		private static bool m_useMeshPoints = false;

		private static bool m_meshRenderMethodSet = false;

		private static Material defaultMaterial;

		private static Camera cam;

		private static Transform camTransform;

		private static Camera cam3D;

		private static Vector3 oldPosition;

		private static Vector3 oldRotation;

		private static int _vectorLayer = 31;

		private static int _vectorLayer3D = 0;

		private static float zDist;

		private static bool useOrthoCam;

		private static bool error = false;

		private static bool lineManagerCreated = false;

		private static LineManager _lineManager;

		private static int widthIdxAdd;

		private static int m_screenWidth = 0;

		private static int m_screenHeight = 0;

		private static Dictionary<string, CapInfo> capDictionary;

		private static string[] functionNames = new string[6] { "VectorLine.SetColors: Length of color", "VectorLine.SetColorsSmooth: Length of color", "VectorLine.SetWidths: Length of line widths", "MakeCurve", "MakeSpline", "MakeEllipse" };

		private static Material defaultLineMaterial;

		private static float defaultLineWidth;

		private static int defaultLineDepth;

		private static float defaultCapLength;

		private static Color defaultLineColor;

		private static LineType defaultLineType;

		private static Joins defaultJoins;

		private static bool defaultsSet = false;

		private static Vector3 v1;

		private static Vector3 v2;

		private static Vector3 v3;

		private static int endianDiff1;

		private static int endianDiff2;

		private static byte[] byteBlock;

		public GameObject vectorObject
		{
			get
			{
				if (m_vectorObject != null)
				{
					return m_vectorObject;
				}
				LogError("Vector object not set up");
				return null;
			}
		}

		public Mesh mesh
		{
			get
			{
				return m_mesh;
			}
		}

		public Color color
		{
			get
			{
				return m_lineColors[0];
			}
		}

		private int pointsLength
		{
			get
			{
				if ((m_is2D && m_pointsLength != points2.Length) || (!m_is2D && m_pointsLength != points3.Length))
				{
					LogError("The points array for \"" + name + "\" must not be resized. Use Resize if you need to change the length of the points array");
					return 0;
				}
				return m_pointsLength;
			}
		}

		public float lineWidth
		{
			get
			{
				return m_lineWidths[0] * 2f;
			}
			set
			{
				if (m_lineWidths.Length == 1)
				{
					m_lineWidths[0] = value * 0.5f;
				}
				else
				{
					float num = value * 0.5f;
					for (int i = 0; i < m_lineWidths.Length; i++)
					{
						m_lineWidths[i] = num;
					}
				}
				m_maxWeldDistance = value * 2f * (value * 2f);
				if (!m_1pixelLine && value == 1f)
				{
					RedoLine(true);
				}
				else if (m_1pixelLine && value != 1f)
				{
					RedoLine(false);
				}
			}
		}

		public float maxWeldDistance
		{
			get
			{
				return Mathf.Sqrt(m_maxWeldDistance);
			}
			set
			{
				m_maxWeldDistance = value * value;
			}
		}

		public string name
		{
			get
			{
				return m_name;
			}
			set
			{
				m_name = value;
				if (m_vectorObject != null)
				{
					m_vectorObject.name = "Vector " + value;
				}
				if (m_mesh != null)
				{
					m_mesh.name = value;
				}
			}
		}

		public Material material
		{
			get
			{
				return m_material;
			}
			set
			{
				m_material = value;
				if (m_vectorObject != null)
				{
					m_vectorObject.GetComponent<Renderer>().material = m_material;
				}
			}
		}

		public bool active
		{
			get
			{
				return m_active;
			}
			set
			{
				m_active = value;
				if (m_vectorObject != null)
				{
					m_vectorObject.GetComponent<Renderer>().enabled = m_active;
				}
			}
		}

		public int depth
		{
			get
			{
				return m_depth;
			}
			set
			{
				m_depth = Mathf.Clamp(value, 0, 100);
			}
		}

		public int layer
		{
			get
			{
				return m_layer;
			}
			set
			{
				m_layer = value;
				if (m_layer < 0)
				{
					m_layer = 0;
				}
				else if (m_layer > 31)
				{
					m_layer = 31;
				}
				if (m_vectorObject != null)
				{
					m_vectorObject.layer = m_layer;
				}
			}
		}

		public bool continuous
		{
			get
			{
				return m_continuous;
			}
		}

		public Joins joins
		{
			get
			{
				return m_joins;
			}
			set
			{
				if (!m_isPoints && (m_continuous || value != Joins.Fill))
				{
					m_joins = value;
				}
			}
		}

		public bool isAutoDrawing
		{
			get
			{
				return m_isAutoDrawing;
			}
		}

		public int minDrawIndex
		{
			get
			{
				return m_minDrawIndex;
			}
			set
			{
				m_minDrawIndex = value;
				if (!m_continuous && (m_minDrawIndex & 1) != 0)
				{
					m_minDrawIndex++;
				}
				m_minDrawIndex = Mathf.Clamp(m_minDrawIndex, 0, pointsLength - 1);
			}
		}

		public int maxDrawIndex
		{
			get
			{
				return m_maxDrawIndex;
			}
			set
			{
				m_maxDrawIndex = value;
				m_minDrawIndex = Mathf.Clamp(m_minDrawIndex, 0, pointsLength - 1);
			}
		}

		public int drawStart
		{
			get
			{
				return m_drawStart;
			}
			set
			{
				if (!m_continuous && (value & 1) != 0)
				{
					value++;
				}
				m_drawStart = Mathf.Clamp(value, 0, pointsLength - 1);
			}
		}

		public int drawEnd
		{
			get
			{
				return m_drawEnd;
			}
			set
			{
				if (!m_continuous && (value & 1) == 0)
				{
					value++;
				}
				m_drawEnd = Mathf.Clamp(value, 0, pointsLength - 1);
			}
		}

		public string endCap
		{
			get
			{
				return m_endCap;
			}
			set
			{
				if (m_isPoints)
				{
					LogError("VectorPoints can't use end caps");
					return;
				}
				if (value == null || value == "")
				{
					m_endCap = null;
					m_capType = EndCap.None;
					RemoveEndCapVertices();
					return;
				}
				if (capDictionary == null || !capDictionary.ContainsKey(value))
				{
					LogError("End cap \"" + value + "\" is not set up");
					return;
				}
				m_endCap = value;
				m_capType = capDictionary[value].capType;
				if (m_capType != EndCap.None)
				{
					AddEndCap();
				}
			}
		}

		public bool continuousTexture
		{
			get
			{
				return m_continuousTexture;
			}
			set
			{
				m_continuousTexture = value;
				if (!value)
				{
					ResetTextureScale();
				}
			}
		}

		public static bool useMeshQuads
		{
			get
			{
				return m_useMeshQuads;
			}
			set
			{
				if (!m_meshRenderMethodSet)
				{
					m_useMeshQuads = value;
				}
				else
				{
					Debug.LogWarning("useMeshQuads not changed, since a VectorLine has already been created");
				}
			}
		}

		public static bool useMeshLines
		{
			get
			{
				return m_useMeshLines;
			}
			set
			{
				if (!m_meshRenderMethodSet)
				{
					m_useMeshLines = value;
				}
				else
				{
					Debug.LogWarning("useMeshLines not changed, since a VectorLine has already been created");
				}
			}
		}

		public static bool useMeshPoints
		{
			get
			{
				return m_useMeshPoints;
			}
			set
			{
				if (!m_meshRenderMethodSet)
				{
					m_useMeshPoints = value;
				}
				else
				{
					Debug.LogWarning("useMeshPoints not changed, since a VectorLine has already been created");
				}
			}
		}

		public static Vector3 camTransformPosition
		{
			get
			{
				return camTransform.position;
			}
		}

		public static bool camTransformExists
		{
			get
			{
				return camTransform != null;
			}
		}

		public static int vectorLayer
		{
			get
			{
				return _vectorLayer;
			}
			set
			{
				_vectorLayer = value;
				if (_vectorLayer > 31)
				{
					_vectorLayer = 31;
				}
				else if (_vectorLayer < 0)
				{
					_vectorLayer = 0;
				}
			}
		}

		public static int vectorLayer3D
		{
			get
			{
				return _vectorLayer3D;
			}
			set
			{
				_vectorLayer3D = value;
				if (_vectorLayer > 31)
				{
					_vectorLayer3D = 31;
				}
				else if (_vectorLayer < 0)
				{
					_vectorLayer3D = 0;
				}
			}
		}

		public static LineManager lineManager
		{
			get
			{
				if (!lineManagerCreated)
				{
					lineManagerCreated = true;
					GameObject gameObject = new GameObject("LineManager");
					_lineManager = gameObject.AddComponent(typeof(LineManager)) as LineManager;
					_lineManager.enabled = false;
					UnityEngine.Object.DontDestroyOnLoad(_lineManager);
				}
				return _lineManager;
			}
		}

		private static int screenWidth
		{
			get
			{
				if (m_screenWidth == 0)
				{
					return Screen.width;
				}
				return m_screenWidth;
			}
		}

		private static int screenHeight
		{
			get
			{
				if (m_screenHeight == 0)
				{
					return Screen.height;
				}
				return m_screenHeight;
			}
		}

		public VectorLine(string lineName, Vector3[] linePoints, Material lineMaterial, float width)
		{
			points3 = linePoints;
			Color[] colors = SetColor(Color.white, LineType.Discrete, linePoints.Length, false);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, LineType.Discrete, Joins.None, false, false);
		}

		public VectorLine(string lineName, Vector3[] linePoints, Color color, Material lineMaterial, float width)
		{
			points3 = linePoints;
			Color[] colors = SetColor(color, LineType.Discrete, linePoints.Length, false);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, LineType.Discrete, Joins.None, false, false);
		}

		public VectorLine(string lineName, Vector3[] linePoints, Color[] colors, Material lineMaterial, float width)
		{
			points3 = linePoints;
			SetupMesh(ref lineName, lineMaterial, colors, ref width, LineType.Discrete, Joins.None, false, false);
		}

		public VectorLine(string lineName, Vector3[] linePoints, Material lineMaterial, float width, LineType lineType)
		{
			points3 = linePoints;
			Color[] colors = SetColor(Color.white, lineType, linePoints.Length, false);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, lineType, Joins.None, false, false);
		}

		public VectorLine(string lineName, Vector3[] linePoints, Color color, Material lineMaterial, float width, LineType lineType)
		{
			points3 = linePoints;
			Color[] colors = SetColor(color, lineType, linePoints.Length, false);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, lineType, Joins.None, false, false);
		}

		public VectorLine(string lineName, Vector3[] linePoints, Color[] colors, Material lineMaterial, float width, LineType lineType)
		{
			points3 = linePoints;
			SetupMesh(ref lineName, lineMaterial, colors, ref width, lineType, Joins.None, false, false);
		}

		public VectorLine(string lineName, Vector3[] linePoints, Material lineMaterial, float width, LineType lineType, Joins joins)
		{
			points3 = linePoints;
			Color[] colors = SetColor(Color.white, lineType, linePoints.Length, false);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, lineType, joins, false, false);
		}

		public VectorLine(string lineName, Vector3[] linePoints, Color color, Material lineMaterial, float width, LineType lineType, Joins joins)
		{
			points3 = linePoints;
			Color[] colors = SetColor(color, lineType, linePoints.Length, false);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, lineType, joins, false, false);
		}

		public VectorLine(string lineName, Vector3[] linePoints, Color[] colors, Material lineMaterial, float width, LineType lineType, Joins joins)
		{
			points3 = linePoints;
			SetupMesh(ref lineName, lineMaterial, colors, ref width, lineType, joins, false, false);
		}

		public VectorLine(string lineName, Vector2[] linePoints, Material lineMaterial, float width)
		{
			points2 = linePoints;
			Color[] colors = SetColor(Color.white, LineType.Discrete, linePoints.Length, false);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, LineType.Discrete, Joins.None, true, false);
		}

		public VectorLine(string lineName, Vector2[] linePoints, Color color, Material lineMaterial, float width)
		{
			points2 = linePoints;
			Color[] colors = SetColor(color, LineType.Discrete, linePoints.Length, false);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, LineType.Discrete, Joins.None, true, false);
		}

		public VectorLine(string lineName, Vector2[] linePoints, Color[] colors, Material lineMaterial, float width)
		{
			points2 = linePoints;
			SetupMesh(ref lineName, lineMaterial, colors, ref width, LineType.Discrete, Joins.None, true, false);
		}

		public VectorLine(string lineName, Vector2[] linePoints, Material lineMaterial, float width, LineType lineType)
		{
			points2 = linePoints;
			Color[] colors = SetColor(Color.white, lineType, linePoints.Length, false);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, lineType, Joins.None, true, false);
		}

		public VectorLine(string lineName, Vector2[] linePoints, Color color, Material lineMaterial, float width, LineType lineType)
		{
			points2 = linePoints;
			Color[] colors = SetColor(color, lineType, linePoints.Length, false);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, lineType, Joins.None, true, false);
		}

		public VectorLine(string lineName, Vector2[] linePoints, Color[] colors, Material lineMaterial, float width, LineType lineType)
		{
			points2 = linePoints;
			SetupMesh(ref lineName, lineMaterial, colors, ref width, lineType, Joins.None, true, false);
		}

		public VectorLine(string lineName, Vector2[] linePoints, Material lineMaterial, float width, LineType lineType, Joins joins)
		{
			points2 = linePoints;
			Color[] colors = SetColor(Color.white, lineType, linePoints.Length, false);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, lineType, joins, true, false);
		}

		public VectorLine(string lineName, Vector2[] linePoints, Color color, Material lineMaterial, float width, LineType lineType, Joins joins)
		{
			points2 = linePoints;
			Color[] colors = SetColor(color, lineType, linePoints.Length, false);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, lineType, joins, true, false);
		}

		public VectorLine(string lineName, Vector2[] linePoints, Color[] colors, Material lineMaterial, float width, LineType lineType, Joins joins)
		{
			points2 = linePoints;
			SetupMesh(ref lineName, lineMaterial, colors, ref width, lineType, joins, true, false);
		}

		protected VectorLine(bool usePoints, string lineName, Vector2[] linePoints, Material lineMaterial, float width)
		{
			points2 = linePoints;
			Color[] colors = SetColor(Color.white, LineType.Continuous, linePoints.Length, true);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, LineType.Continuous, Joins.None, true, true);
		}

		protected VectorLine(bool usePoints, string lineName, Vector2[] linePoints, Color color, Material lineMaterial, float width)
		{
			points2 = linePoints;
			Color[] colors = SetColor(color, LineType.Continuous, linePoints.Length, true);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, LineType.Continuous, Joins.None, true, true);
		}

		protected VectorLine(bool usePoints, string lineName, Vector2[] linePoints, Color[] colors, Material lineMaterial, float width)
		{
			points2 = linePoints;
			SetupMesh(ref lineName, lineMaterial, colors, ref width, LineType.Continuous, Joins.None, true, true);
		}

		protected VectorLine(bool usePoints, string lineName, Vector3[] linePoints, Material lineMaterial, float width)
		{
			points3 = linePoints;
			Color[] colors = SetColor(Color.white, LineType.Continuous, linePoints.Length, true);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, LineType.Continuous, Joins.None, false, true);
		}

		protected VectorLine(bool usePoints, string lineName, Vector3[] linePoints, Color[] colors, Material lineMaterial, float width)
		{
			points3 = linePoints;
			SetupMesh(ref lineName, lineMaterial, colors, ref width, LineType.Continuous, Joins.None, false, true);
		}

		protected VectorLine(bool usePoints, string lineName, Vector3[] linePoints, Color color, Material lineMaterial, float width)
		{
			points3 = linePoints;
			Color[] colors = SetColor(color, LineType.Continuous, linePoints.Length, true);
			SetupMesh(ref lineName, lineMaterial, colors, ref width, LineType.Continuous, Joins.None, false, true);
		}

		private Color[] SetColor(Color color, LineType lineType, int size, bool usePoints)
		{
			if (size == 0)
			{
				LogError("VectorLine: Must use a points array with more than 0 entries");
				return null;
			}
			if (!usePoints)
			{
				size = ((lineType != LineType.Continuous) ? (size / 2) : (size - 1));
			}
			Color[] array = new Color[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = color;
			}
			return array;
		}

		protected void SetupMesh(ref string lineName, Material useMaterial, Color[] colors, ref float width, LineType lineType, Joins joins, bool use2Dlines, bool usePoints)
		{
			m_continuous = lineType == LineType.Continuous;
			m_is2D = use2Dlines;
			if (joins == Joins.Fill && !m_continuous)
			{
				LogError("VectorLine: Must use LineType.Continuous if using Joins.Fill for \"" + lineName + "\"");
				return;
			}
			if ((m_is2D && points2 == null) || (!m_is2D && points3 == null))
			{
				LogError("VectorLine: the points array is null for \"" + lineName + "\"");
				return;
			}
			if (colors == null)
			{
				LogError("Vectorline: the colors array is null for \"" + lineName + "\"");
				return;
			}
			m_pointsLength = ((!m_is2D) ? points3.Length : points2.Length);
			if (!usePoints && m_pointsLength < 2)
			{
				LogError("The points array must contain at least two points");
				return;
			}
			if (!m_continuous && m_pointsLength % 2 != 0)
			{
				LogError("VectorLine: Must have an even points array length for \"" + lineName + "\" when using LineType.Discrete");
				return;
			}
			m_maxWeldDistance = width * 2f * (width * 2f);
			m_drawEnd = m_pointsLength;
			m_lineWidths = new float[1];
			m_lineWidths[0] = width * 0.5f;
			m_isPoints = usePoints;
			m_joins = joins;
			bool flag = true;
			int num = 0;
			if (width == 1f && ((m_isPoints && m_useMeshPoints) || (!m_isPoints && m_useMeshLines)))
			{
				m_1pixelLine = true;
			}
			if (!usePoints)
			{
				if (m_continuous)
				{
					if (colors.Length != m_pointsLength - 1)
					{
						Debug.LogWarning("VectorLine: Length of color array for \"" + lineName + "\" must be length of points array minus one");
						flag = false;
						num = m_pointsLength - 1;
					}
				}
				else if (colors.Length != m_pointsLength / 2)
				{
					Debug.LogWarning("VectorLine: Length of color array for \"" + lineName + "\" must be exactly half the length of points array");
					flag = false;
					num = m_pointsLength / 2;
				}
			}
			else if (colors.Length != m_pointsLength)
			{
				Debug.LogWarning("VectorLine: Length of color array for \"" + lineName + "\" must be the same length as the points array");
				flag = false;
				num = m_pointsLength;
			}
			if (!flag)
			{
				colors = new Color[num];
				for (int i = 0; i < num; i++)
				{
					colors[i] = Color.white;
				}
			}
			if (useMaterial == null)
			{
				if (defaultMaterial == null)
				{
					defaultMaterial = new Material("Shader \"Vertex Colors/Alpha\" {Category{Tags {\"Queue\"=\"Transparent\" \"IgnoreProjector\"=\"True\" \"RenderType\"=\"Transparent\"}SubShader {Cull Off ZWrite On Blend SrcAlpha OneMinusSrcAlpha Pass {BindChannels {Bind \"Color\", color Bind \"Vertex\", vertex}}}}}");
				}
				m_material = defaultMaterial;
			}
			else
			{
				m_material = useMaterial;
			}
			m_vectorObject = new GameObject("Vector " + lineName, typeof(MeshRenderer));
			m_vectorObject.layer = vectorLayer;
			m_vectorObject.GetComponent<Renderer>().material = m_material;
			m_mesh = new Mesh();
			m_mesh.name = lineName;
			m_meshFilter = (MeshFilter)m_vectorObject.AddComponent(typeof(MeshFilter));
			m_meshFilter.mesh = m_mesh;
			name = lineName;
			m_meshRenderMethodSet = true;
			BuildMesh(colors);
		}

		public void Resize(Vector3[] linePoints)
		{
			if (m_is2D)
			{
				LogError("Must supply a Vector2 array instead of a Vector3 array for \"" + name + "\"");
				return;
			}
			points3 = linePoints;
			m_pointsLength = linePoints.Length;
			RebuildMesh();
		}

		public void Resize(Vector2[] linePoints)
		{
			if (!m_is2D)
			{
				LogError("Must supply a Vector3 array instead of a Vector2 array for \"" + name + "\"");
				return;
			}
			points2 = linePoints;
			m_pointsLength = linePoints.Length;
			RebuildMesh();
		}

		public void Resize(int newSize)
		{
			if (m_is2D)
			{
				points2 = new Vector2[newSize];
			}
			else
			{
				points3 = new Vector3[newSize];
			}
			m_pointsLength = newSize;
			RebuildMesh();
		}

		private void RebuildMesh()
		{
			if (!m_continuous && m_pointsLength % 2 != 0)
			{
				LogError("VectorLine.Resize: Must have an even points array length for \"" + name + "\" when using LineType.Discrete");
				return;
			}
			m_mesh.Clear();
			Color[] colors = SetColor(m_lineColors[0], (!m_continuous) ? LineType.Discrete : LineType.Continuous, m_pointsLength, m_isPoints);
			if (m_lineWidths.Length > 1)
			{
				float num = lineWidth;
				m_lineWidths = new float[m_pointsLength];
				lineWidth = num;
			}
			BuildMesh(colors);
			m_minDrawIndex = 0;
			m_maxDrawIndex = 0;
			m_drawStart = 0;
			m_drawEnd = m_pointsLength;
		}

		private void BuildMesh(Color[] colors)
		{
			if (m_1pixelLine)
			{
				m_vertexCount = ((m_continuous && !m_isPoints) ? ((m_pointsLength - 1) * 2) : m_pointsLength);
			}
			else if (m_isPoints)
			{
				m_vertexCount = m_pointsLength * 4;
			}
			else
			{
				m_vertexCount = ((!m_continuous) ? (m_pointsLength * 2) : ((m_pointsLength - 1) * 4));
			}
			if (m_vertexCount > 65534)
			{
				LogError("VectorLine: exceeded maximum vertex count of 65534 for \"" + name + "\"...use fewer points (maximum is approximately 16000 points for continuous lines and points, and approximately 32000 points for discrete lines)");
				return;
			}
			m_lineVertices = new Vector3[m_vertexCount];
			m_lineUVs = new Vector2[m_vertexCount];
			m_lineColors = new Color32[m_vertexCount];
			int num = 0;
			int num2 = 0;
			if (m_1pixelLine)
			{
				num2 = colors.Length;
				if (m_isPoints)
				{
					for (int i = 0; i < num2; i++)
					{
						m_lineColors[i] = colors[i];
					}
				}
				else
				{
					for (int j = 0; j < num2; j++)
					{
						m_lineColors[num] = colors[j];
						m_lineColors[num + 1] = colors[j];
						num += 2;
					}
				}
			}
			else
			{
				num2 = (m_isPoints ? m_pointsLength : ((!m_continuous) ? (m_pointsLength / 2) : (m_pointsLength - 1)));
				for (int k = 0; k < num2; k++)
				{
					m_lineUVs[num] = new Vector2(0f, 1f);
					m_lineUVs[num + 1] = new Vector2(0f, 0f);
					m_lineUVs[num + 2] = new Vector2(1f, 1f);
					m_lineUVs[num + 3] = new Vector2(1f, 0f);
					num += 4;
				}
				num = 0;
				for (int l = 0; l < num2; l++)
				{
					m_lineColors[num] = colors[l];
					m_lineColors[num + 1] = colors[l];
					m_lineColors[num + 2] = colors[l];
					m_lineColors[num + 3] = colors[l];
					num += 4;
				}
			}
			m_mesh.MarkDynamic();
			m_mesh.vertices = m_lineVertices;
			m_mesh.uv = m_lineUVs;
			m_mesh.colors32 = m_lineColors;
			SetupTriangles();
			if (!m_is2D)
			{
				m_screenPoints = new Vector3[m_lineVertices.Length];
			}
			if (m_useNormals)
			{
				m_normalsCalculated = false;
			}
			if (m_useTangents)
			{
				m_tangentsCalculated = false;
			}
			if (m_capType != EndCap.None)
			{
				AddEndCap();
			}
		}

		private void SetupTriangles()
		{
			bool flag = false;
			if (m_1pixelLine)
			{
				if (m_continuous)
				{
					m_triangleCount = ((!m_isPoints) ? ((m_pointsLength - 1) * 2) : m_pointsLength);
				}
				else
				{
					m_triangleCount = m_pointsLength;
				}
			}
			else
			{
				int num = ((!m_useMeshQuads) ? 6 : 4);
				if (m_continuous)
				{
					m_triangleCount = ((!m_isPoints) ? (m_triangleCount = (m_pointsLength - 1) * num) : (m_triangleCount = m_pointsLength * num));
					if (m_joins == Joins.Fill)
					{
						m_triangleCount += (m_pointsLength - 2) * num;
						if ((m_is2D && points2[0] == points2[points2.Length - 1]) || (!m_is2D && points3[0] == points3[points3.Length - 1]))
						{
							m_triangleCount += num;
							flag = true;
						}
					}
				}
				else
				{
					m_triangleCount = m_pointsLength / 2 * num;
				}
			}
			int[] array = new int[m_triangleCount];
			int num2 = 0;
			int num3 = 0;
			num2 = (m_isPoints ? (m_pointsLength * 4) : ((!m_continuous) ? (m_pointsLength * 2) : ((m_pointsLength - 1) * 4)));
			if (m_1pixelLine)
			{
				num2 = (m_isPoints ? m_pointsLength : ((!m_continuous) ? m_pointsLength : ((m_pointsLength - 1) * 2)));
				if (m_continuous)
				{
					int num4 = 0;
					if (!m_isPoints)
					{
						for (num3 = 0; num3 < num2; num3++)
						{
							array[num4] = num3;
							array[num4++] = num3;
						}
					}
					else
					{
						for (num3 = 0; num3 < num2; num3++)
						{
							array[num3] = num3;
						}
					}
				}
				else
				{
					for (num3 = 0; num3 < num2; num3++)
					{
						array[num3] = num3;
					}
				}
				m_mesh.SetIndices(array, (!m_isPoints) ? MeshTopology.Lines : MeshTopology.Points, 0);
				return;
			}
			if (m_useMeshQuads)
			{
				for (num3 = 0; num3 < num2; num3 += 4)
				{
					array[num3] = num3 + 2;
					array[num3 + 1] = num3 + 3;
					array[num3 + 2] = num3 + 1;
					array[num3 + 3] = num3;
				}
				if (m_joins == Joins.Fill)
				{
					num2 -= 2;
					int num5 = num3;
					for (num3 = 2; num3 < num2; num3 += 4)
					{
						array[num5] = num3 + 2;
						array[num5 + 1] = num3 + 3;
						array[num5 + 2] = num3 + 1;
						array[num5 + 3] = num3;
						num5 += 4;
					}
					if (flag)
					{
						array[num5] = num3;
						array[num5 + 1] = 0;
						array[num5 + 2] = 1;
						array[num5 + 3] = num3 + 1;
					}
				}
				m_mesh.SetIndices(array, MeshTopology.Quads, 0);
				return;
			}
			int num6 = 0;
			for (num3 = 0; num3 < num2; num3 += 4)
			{
				array[num6] = num3;
				array[num6 + 1] = num3 + 2;
				array[num6 + 2] = num3 + 1;
				array[num6 + 3] = num3 + 2;
				array[num6 + 4] = num3 + 3;
				array[num6 + 5] = num3 + 1;
				num6 += 6;
			}
			if (m_joins == Joins.Fill)
			{
				num2 -= 2;
				for (num3 = 2; num3 < num2; num3 += 4)
				{
					array[num6] = num3;
					array[num6 + 1] = num3 + 2;
					array[num6 + 2] = num3 + 1;
					array[num6 + 3] = num3 + 2;
					array[num6 + 4] = num3 + 3;
					array[num6 + 5] = num3 + 1;
					num6 += 6;
				}
				if (flag)
				{
					array[num6] = num3;
					array[num6 + 1] = 0;
					array[num6 + 2] = num3 + 1;
					array[num6 + 3] = 0;
					array[num6 + 4] = 1;
					array[num6 + 5] = num3 + 1;
				}
			}
			m_mesh.triangles = array;
		}

		public void AddNormals()
		{
			m_useNormals = true;
			m_normalsCalculated = false;
		}

		public void AddTangents()
		{
			m_useTangents = true;
			m_tangentsCalculated = false;
		}

		private void CalculateTangents()
		{
			if (!m_useNormals)
			{
				m_useNormals = true;
				m_mesh.RecalculateNormals();
			}
			Vector3[] array = new Vector3[m_lineVertices.Length];
			Vector3[] array2 = new Vector3[m_lineVertices.Length];
			Vector4[] array3 = new Vector4[m_lineVertices.Length];
			int[] triangles = m_mesh.triangles;
			Vector2[] uv = m_mesh.uv;
			Vector3[] normals = m_mesh.normals;
			int num = triangles.Length;
			int num2 = m_lineVertices.Length;
			for (int i = 0; i < num; i += 3)
			{
				int num3 = triangles[i];
				int num4 = triangles[i + 1];
				int num5 = triangles[i + 2];
				Vector3 vector = m_lineVertices[num3];
				Vector3 vector2 = m_lineVertices[num4];
				Vector3 vector3 = m_lineVertices[num5];
				Vector2 vector4 = uv[num3];
				Vector2 vector5 = uv[num4];
				Vector2 vector6 = uv[num5];
				float num6 = vector2.x - vector.x;
				float num7 = vector3.x - vector.x;
				float num8 = vector2.y - vector.y;
				float num9 = vector3.y - vector.y;
				float num10 = vector2.z - vector.z;
				float num11 = vector3.z - vector.z;
				float num12 = vector5.x - vector4.x;
				float num13 = vector6.x - vector4.x;
				float num14 = vector5.y - vector4.y;
				float num15 = vector6.y - vector4.y;
				float num16 = 1f / (num12 * num15 - num13 * num14);
				Vector3 vector7 = new Vector3((num15 * num6 - num14 * num7) * num16, (num15 * num8 - num14 * num9) * num16, (num15 * num10 - num14 * num11) * num16);
				Vector3 vector8 = new Vector3((num12 * num7 - num13 * num6) * num16, (num12 * num9 - num13 * num8) * num16, (num12 * num11 - num13 * num10) * num16);
				array[num3] += vector7;
				array[num4] += vector7;
				array[num5] += vector7;
				array2[num3] += vector8;
				array2[num4] += vector8;
				array2[num5] += vector8;
			}
			for (int j = 0; j < num2; j++)
			{
				Vector3 vector9 = normals[j];
				Vector3 vector10 = array[j];
				array3[j] = (vector10 - vector9 * Vector3.Dot(vector9, vector10)).normalized;
				array3[j].w = ((!(Vector3.Dot(Vector3.Cross(vector9, vector10), array2[j]) < 0f)) ? 1f : (-1f));
			}
			m_mesh.tangents = array3;
		}

		private void AddEndCap()
		{
			if (m_1pixelLine)
			{
				return;
			}
			int num = m_vertexCount + 8;
			if (num > 65534)
			{
				LogError("VectorLine: exceeded maximum vertex count of 65534 for \"" + m_name + "\"...use fewer points");
				return;
			}
			Array.Resize(ref m_lineVertices, num);
			Array.Resize(ref m_lineUVs, num);
			Array.Resize(ref m_lineColors, num);
			EndCap capType = capDictionary[m_endCap].capType;
			int[] array;
			if (m_useMeshQuads)
			{
				array = new int[8];
				int num2 = 0;
				for (int i = num - 8; i < num; i += 4)
				{
					array[num2] = i + 2;
					array[num2 + 1] = i;
					array[num2 + 2] = i + 1;
					array[num2 + 3] = i + 3;
					num2 += 4;
				}
			}
			else
			{
				array = new int[12];
				int num3 = 0;
				for (int j = num - 8; j < num; j += 4)
				{
					array[num3] = j + 2;
					array[num3 + 1] = j + 1;
					array[num3 + 2] = j;
					array[num3 + 3] = j + 2;
					array[num3 + 4] = j + 3;
					array[num3 + 5] = j + 1;
					num3 += 6;
				}
			}
			for (int k = num - 8; k < num - 4; k++)
			{
				m_lineColors[k] = m_lineColors[0];
				m_lineColors[k + 4] = m_lineColors[num - 12];
			}
			m_lineUVs[num - 8] = new Vector2(0f, 0.25f);
			m_lineUVs[num - 7] = new Vector2(0f, 0f);
			m_lineUVs[num - 6] = new Vector2(1f, 0.25f);
			m_lineUVs[num - 5] = new Vector2(1f, 0f);
			if (capType == EndCap.Mirror)
			{
				m_lineUVs[num - 4] = new Vector2(1f, 0.25f);
				m_lineUVs[num - 3] = new Vector2(1f, 0f);
				m_lineUVs[num - 2] = new Vector2(0f, 0.25f);
				m_lineUVs[num - 1] = new Vector2(0f, 0f);
			}
			else
			{
				m_lineUVs[num - 4] = new Vector2(0f, 1f);
				m_lineUVs[num - 3] = new Vector2(0f, 0.75f);
				m_lineUVs[num - 2] = new Vector2(1f, 1f);
				m_lineUVs[num - 1] = new Vector2(1f, 0.75f);
			}
			m_mesh.vertices = m_lineVertices;
			m_mesh.uv = m_lineUVs;
			m_mesh.colors32 = m_lineColors;
			m_mesh.subMeshCount = 2;
			if (m_useMeshQuads)
			{
				m_mesh.SetIndices(array, MeshTopology.Quads, 1);
			}
			else
			{
				m_mesh.SetTriangles(array, 1);
			}
			Material[] sharedMaterials = new Material[2]
			{
				m_material,
				capDictionary[m_endCap].material
			};
			m_vectorObject.GetComponent<Renderer>().sharedMaterials = sharedMaterials;
		}

		private void RemoveEndCapVertices()
		{
			Array.Resize(ref m_lineVertices, m_vertexCount);
			Array.Resize(ref m_lineUVs, m_vertexCount);
			Array.Resize(ref m_lineColors, m_vertexCount);
			m_mesh.subMeshCount = 1;
			Material[] materials = new Material[1] { m_vectorObject.GetComponent<Renderer>().materials[0] };
			m_vectorObject.GetComponent<Renderer>().materials = materials;
		}

		private static void LogError(string errorString)
		{
			Debug.LogError(errorString);
			error = true;
		}

		public static Camera SetCameraRenderTexture(RenderTexture renderTexture)
		{
			return SetCameraRenderTexture(renderTexture, Color.black, false);
		}

		public static Camera SetCameraRenderTexture(RenderTexture renderTexture, bool useOrtho)
		{
			return SetCameraRenderTexture(renderTexture, Color.black, useOrtho);
		}

		public static Camera SetCameraRenderTexture(RenderTexture renderTexture, Color color, bool useOrtho)
		{
			Camera camera;
			if (renderTexture == null)
			{
				m_screenWidth = 0;
				m_screenHeight = 0;
				camera = SetCamera(useOrtho);
				camera.aspect = (float)screenWidth / (float)screenHeight;
				camera.targetTexture = null;
				return camera;
			}
			int width = renderTexture.width;
			int height = renderTexture.height;
			m_screenWidth = width;
			m_screenHeight = height;
			camera = SetCamera(CameraClearFlags.Color, useOrtho);
			camera.aspect = (float)width / (float)height;
			camera.backgroundColor = color;
			camera.targetTexture = renderTexture;
			return camera;
		}

		public static Camera SetCamera()
		{
			return SetCamera(CameraClearFlags.Depth, false);
		}

		public static Camera SetCamera(bool useOrtho)
		{
			return SetCamera(CameraClearFlags.Depth, useOrtho);
		}

		public static Camera SetCamera(CameraClearFlags clearFlags)
		{
			return SetCamera(clearFlags, false);
		}

		public static Camera SetCamera(CameraClearFlags clearFlags, bool useOrtho)
		{
			if (Camera.main == null)
			{
				LogError("VectorLine.SetCamera: no camera tagged \"Main Camera\" found");
				return null;
			}
			return SetCamera(Camera.main, clearFlags, useOrtho);
		}

		public static Camera SetCamera(Camera thisCamera)
		{
			return SetCamera(thisCamera, CameraClearFlags.Depth, false);
		}

		public static Camera SetCamera(Camera thisCamera, bool useOrtho)
		{
			return SetCamera(thisCamera, CameraClearFlags.Depth, useOrtho);
		}

		public static Camera SetCamera(Camera thisCamera, CameraClearFlags clearFlags)
		{
			return SetCamera(thisCamera, clearFlags, false);
		}

		public static Camera SetCamera(Camera thisCamera, CameraClearFlags clearFlags, bool useOrtho)
		{
			if (!cam)
			{
				cam = new GameObject("VectorCam", typeof(Camera)).GetComponent<Camera>();
				UnityEngine.Object.DontDestroyOnLoad(cam);
			}
			cam.depth = thisCamera.depth + 1f;
			cam.clearFlags = clearFlags;
			cam.orthographic = useOrtho;
			useOrthoCam = useOrtho;
			if (useOrtho)
			{
				cam.orthographicSize = screenHeight / 2;
				cam.farClipPlane = 101.1f;
				cam.nearClipPlane = 0.9f;
			}
			else
			{
				cam.fieldOfView = 90f;
				cam.farClipPlane = (float)(screenHeight / 2) + 0.0101f;
				cam.nearClipPlane = (float)(screenHeight / 2) - 0.0001f;
			}
			cam.transform.position = new Vector3((float)(screenWidth / 2) - 0.5f, (float)(screenHeight / 2) - 0.5f, 0f);
			cam.transform.eulerAngles = Vector3.zero;
			cam.cullingMask = 1 << _vectorLayer;
			cam.backgroundColor = thisCamera.backgroundColor;
			cam.allowHDR = thisCamera.allowHDR;
			thisCamera.cullingMask &= ~(1 << _vectorLayer);
			camTransform = thisCamera.transform;
			cam3D = thisCamera;
			oldPosition = camTransform.position + Vector3.one;
			oldRotation = camTransform.eulerAngles + Vector3.one;
			return cam;
		}

		public static void SetCamera3D()
		{
			if (Camera.main == null)
			{
				LogError("VectorLine.SetCamera3D: no camera tagged \"Main Camera\" found. Please call SetCamera3D with a specific camera instead.");
			}
			else
			{
				SetCamera3D(Camera.main);
			}
		}

		public static void SetCamera3D(Camera thisCamera)
		{
			camTransform = thisCamera.transform;
			cam3D = thisCamera;
			oldPosition = camTransform.position + Vector3.one;
			oldRotation = camTransform.eulerAngles + Vector3.one;
		}

		public static bool CameraHasMoved()
		{
			return oldPosition != camTransform.position || oldRotation != camTransform.eulerAngles;
		}

		public static void UpdateCameraInfo()
		{
			oldPosition = camTransform.position;
			oldRotation = camTransform.eulerAngles;
		}

		public static Camera GetCamera()
		{
			if (!cam)
			{
				LogError("The vector cam has not been set up");
				return null;
			}
			return cam;
		}

		public static void SetVectorCamDepth(int depth)
		{
			if (!cam)
			{
				LogError("The vector cam has not been set up");
			}
			else
			{
				cam.depth = depth;
			}
		}

		public int GetSegmentNumber()
		{
			if (m_continuous)
			{
				return pointsLength - 1;
			}
			return pointsLength / 2;
		}

		private bool WrongArrayLength(int arrayLength, FunctionName functionName)
		{
			if (m_continuous)
			{
				if (arrayLength != m_pointsLength - 1)
				{
					LogError(functionNames[(int)functionName] + " array for \"" + name + "\" must be length of points array minus one for a continuous line (one entry per line segment)");
					return true;
				}
			}
			else if (arrayLength != m_pointsLength / 2)
			{
				LogError(functionNames[(int)functionName] + " array in \"" + name + "\" must be exactly half the length of points array for a discrete line (one entry per line segment)");
				return true;
			}
			return false;
		}

		private bool CheckArrayLength(FunctionName functionName, int segments, int index)
		{
			if (segments < 1)
			{
				LogError("VectorLine." + functionNames[(int)functionName] + " needs at least 1 segment");
				return false;
			}
			if (m_isPoints)
			{
				if (index + segments > m_pointsLength)
				{
					if (index == 0)
					{
						LogError("VectorLine." + functionNames[(int)functionName] + ": The number of segments cannot exceed the number of points in the array for \"" + name + "\"");
						return false;
					}
					LogError("VectorLine: Calling " + functionNames[(int)functionName] + " with an index of " + index + " would exceed the length of the Vector array for \"" + name + "\"");
					return false;
				}
				return true;
			}
			if (m_continuous)
			{
				if (index + (segments + 1) > m_pointsLength)
				{
					if (index == 0)
					{
						LogError("VectorLine." + functionNames[(int)functionName] + ": The length of the array for continuous lines needs to be at least the number of segments plus one for \"" + name + "\"");
						return false;
					}
					LogError("VectorLine: Calling " + functionNames[(int)functionName] + " with an index of " + index + " would exceed the length of the Vector array for \"" + name + "\"");
					return false;
				}
			}
			else if (index + segments * 2 > m_pointsLength)
			{
				if (index == 0)
				{
					LogError("VectorLine." + functionNames[(int)functionName] + ": The length of the array for discrete lines needs to be at least twice the number of segments for \"" + name + "\"");
					return false;
				}
				LogError("VectorLine: Calling " + functionNames[(int)functionName] + " with an index of " + index + " would exceed the length of the Vector array for \"" + name + "\"");
				return false;
			}
			return true;
		}

		private void SetEndCapColors()
		{
			if (m_1pixelLine)
			{
				return;
			}
			if (m_capType <= EndCap.Mirror)
			{
				int num = ((!m_continuous) ? (m_drawStart * 2) : (m_drawStart * 4));
				for (int i = 0; i < 4; i++)
				{
					m_lineColors[i + m_vertexCount] = m_lineColors[i + num];
				}
			}
			if (m_capType < EndCap.Both)
			{
				return;
			}
			int num2 = m_drawEnd;
			if (m_continuous)
			{
				if (m_drawEnd == pointsLength)
				{
					num2--;
				}
			}
			else if (num2 < pointsLength)
			{
				num2++;
			}
			int num3 = num2 * ((!m_continuous) ? 2 : 4) - 8;
			if (num3 < -4)
			{
				num3 = -4;
			}
			for (int j = 4; j < 8; j++)
			{
				m_lineColors[j + m_vertexCount] = m_lineColors[j + num3];
			}
		}

		public void SetColor(Color color)
		{
			SetColor(color, 0, m_pointsLength);
		}

		public void SetColor(Color color, int index)
		{
			SetColor(color, index, index);
		}

		public void SetColor(Color color, int startIndex, int endIndex)
		{
			int max = ((!m_isPoints) ? ((!m_continuous) ? (pointsLength / 2) : (pointsLength - 1)) : pointsLength);
			int num = ((!m_1pixelLine) ? 4 : (m_isPoints ? 1 : 2));
			startIndex = Mathf.Clamp(startIndex, 0, max) * num;
			endIndex = Mathf.Clamp(endIndex + 1, 1, max) * num;
			for (int i = startIndex; i < endIndex; i++)
			{
				m_lineColors[i] = color;
			}
			m_mesh.colors32 = m_lineColors;
		}

		public void SetColors(Color[] lineColors)
		{
			if (lineColors == null)
			{
				LogError("VectorLine.SetColors: line colors array must not be null");
				return;
			}
			if (!m_isPoints)
			{
				if (WrongArrayLength(lineColors.Length, FunctionName.SetColors))
				{
					return;
				}
			}
			else if (lineColors.Length != pointsLength)
			{
				LogError("VectorLine.SetColors: Length of lineColors array in \"" + name + "\" must be same length as points array");
				return;
			}
			int start = 0;
			int end = lineColors.Length;
			SetStartAndEnd(ref start, ref end);
			int num = start * 4;
			if (m_1pixelLine)
			{
				if (m_isPoints)
				{
					for (int i = start; i < end; i++)
					{
						m_lineColors[i] = lineColors[i];
					}
				}
				else
				{
					num = start * 2;
					for (int j = start; j < end; j++)
					{
						m_lineColors[num] = lineColors[j];
						m_lineColors[num + 1] = lineColors[j];
						num += 2;
					}
				}
			}
			else
			{
				for (int k = start; k < end; k++)
				{
					m_lineColors[num] = lineColors[k];
					m_lineColors[num + 1] = lineColors[k];
					m_lineColors[num + 2] = lineColors[k];
					m_lineColors[num + 3] = lineColors[k];
					num += 4;
				}
			}
			if (m_capType != EndCap.None)
			{
				SetEndCapColors();
			}
			m_mesh.colors32 = m_lineColors;
		}

		public void SetColorsSmooth(Color[] lineColors)
		{
			if (lineColors == null)
			{
				LogError("VectorLine.SetColors: line colors array must not be null");
			}
			else if (m_isPoints)
			{
				LogError("VectorLine.SetColorsSmooth must be used with a line rather than points");
			}
			else
			{
				if (WrongArrayLength(lineColors.Length, FunctionName.SetColorsSmooth))
				{
					return;
				}
				int start = 0;
				int end = lineColors.Length;
				SetStartAndEnd(ref start, ref end);
				int num = start * 4;
				if (m_1pixelLine)
				{
					num = start * 2;
					m_lineColors[num] = lineColors[start];
					m_lineColors[num + 1] = lineColors[start];
					num += 2;
					for (int i = start + 1; i < end; i++)
					{
						m_lineColors[num] = lineColors[i - 1];
						m_lineColors[num + 1] = lineColors[i];
						num += 2;
					}
				}
				else
				{
					m_lineColors[num] = lineColors[start];
					m_lineColors[num + 1] = lineColors[start];
					m_lineColors[num + 2] = lineColors[start];
					m_lineColors[num + 3] = lineColors[start];
					num += 4;
					for (int j = start + 1; j < end; j++)
					{
						m_lineColors[num] = lineColors[j - 1];
						m_lineColors[num + 1] = lineColors[j - 1];
						m_lineColors[num + 2] = lineColors[j];
						m_lineColors[num + 3] = lineColors[j];
						num += 4;
					}
				}
				m_mesh.colors32 = m_lineColors;
			}
		}

		private void SetStartAndEnd(ref int start, ref int end)
		{
			start = ((m_minDrawIndex != 0) ? ((!m_continuous) ? (m_minDrawIndex / 2) : m_minDrawIndex) : 0);
			if (m_maxDrawIndex <= 0)
			{
				return;
			}
			if (m_continuous)
			{
				end = m_maxDrawIndex;
				return;
			}
			end = m_maxDrawIndex / 2;
			if (m_maxDrawIndex % 2 != 0)
			{
				end++;
			}
		}

		public void SetWidths(float[] lineWidths)
		{
			SetWidths(lineWidths, null, lineWidths.Length, true);
		}

		public void SetWidths(int[] lineWidths)
		{
			SetWidths(null, lineWidths, lineWidths.Length, false);
		}

		private void SetWidths(float[] lineWidthsFloat, int[] lineWidthsInt, int arrayLength, bool doFloat)
		{
			if ((doFloat && lineWidthsFloat == null) || (!doFloat && lineWidthsInt == null))
			{
				LogError("VectorLine.SetWidths: line widths array must not be null");
				return;
			}
			if (m_isPoints)
			{
				if (arrayLength != pointsLength)
				{
					LogError("VectorLine.SetWidths: line widths array must be the same length as the points array for \"" + name + "\"");
					return;
				}
			}
			else if (WrongArrayLength(arrayLength, FunctionName.SetWidths))
			{
				return;
			}
			if (m_1pixelLine)
			{
				RedoLine(false);
			}
			m_lineWidths = new float[arrayLength];
			if (doFloat)
			{
				for (int i = 0; i < arrayLength; i++)
				{
					m_lineWidths[i] = lineWidthsFloat[i] * 0.5f;
				}
			}
			else
			{
				for (int j = 0; j < arrayLength; j++)
				{
					m_lineWidths[j] = (float)lineWidthsInt[j] * 0.5f;
				}
			}
		}

		private void RedoLine(bool use1Pixel)
		{
			m_1pixelLine = use1Pixel;
			int num;
			int num2;
			int num3;
			if (m_isPoints)
			{
				num = 0;
				num2 = 1;
				num3 = m_vertexCount;
			}
			else if (use1Pixel)
			{
				num = 2;
				num2 = 4;
				num3 = m_vertexCount / 4;
			}
			else
			{
				num = 1;
				num2 = 2;
				num3 = m_vertexCount / 2;
			}
			Color[] array = new Color[num3];
			int vertexCount = m_vertexCount;
			int num4 = 0;
			for (int i = num; i < vertexCount; i += num2)
			{
				array[num4++] = m_lineColors[i];
			}
			m_mesh.Clear();
			BuildMesh(array);
		}

		public static void SetLineParameters(Color color, Material material, float width, float capLength, int depth, LineType lineType, Joins joins)
		{
			defaultLineColor = color;
			defaultLineMaterial = material;
			defaultLineWidth = width;
			defaultLineDepth = depth;
			defaultCapLength = capLength;
			defaultLineType = lineType;
			defaultJoins = joins;
			defaultsSet = true;
		}

		private static void PrintMakeLineError()
		{
			LogError("VectorLine.MakeLine: Must call SetLineParameters before using MakeLine with these parameters");
		}

		public static VectorLine MakeLine(string name, Vector3[] points, Color[] colors)
		{
			if (!defaultsSet)
			{
				PrintMakeLineError();
				return null;
			}
			VectorLine vectorLine = new VectorLine(name, points, colors, defaultLineMaterial, defaultLineWidth, defaultLineType, defaultJoins);
			vectorLine.capLength = defaultCapLength;
			vectorLine.depth = defaultLineDepth;
			return vectorLine;
		}

		public static VectorLine MakeLine(string name, Vector2[] points, Color[] colors)
		{
			if (!defaultsSet)
			{
				PrintMakeLineError();
				return null;
			}
			VectorLine vectorLine = new VectorLine(name, points, colors, defaultLineMaterial, defaultLineWidth, defaultLineType, defaultJoins);
			vectorLine.capLength = defaultCapLength;
			vectorLine.depth = defaultLineDepth;
			return vectorLine;
		}

		public static VectorLine MakeLine(string name, Vector3[] points, Color color)
		{
			if (!defaultsSet)
			{
				PrintMakeLineError();
				return null;
			}
			VectorLine vectorLine = new VectorLine(name, points, color, defaultLineMaterial, defaultLineWidth, defaultLineType, defaultJoins);
			vectorLine.capLength = defaultCapLength;
			vectorLine.depth = defaultLineDepth;
			return vectorLine;
		}

		public static VectorLine MakeLine(string name, Vector2[] points, Color color)
		{
			if (!defaultsSet)
			{
				PrintMakeLineError();
				return null;
			}
			VectorLine vectorLine = new VectorLine(name, points, color, defaultLineMaterial, defaultLineWidth, defaultLineType, defaultJoins);
			vectorLine.capLength = defaultCapLength;
			vectorLine.depth = defaultLineDepth;
			return vectorLine;
		}

		public static VectorLine MakeLine(string name, Vector3[] points)
		{
			if (!defaultsSet)
			{
				PrintMakeLineError();
				return null;
			}
			VectorLine vectorLine = new VectorLine(name, points, defaultLineColor, defaultLineMaterial, defaultLineWidth, defaultLineType, defaultJoins);
			vectorLine.capLength = defaultCapLength;
			vectorLine.depth = defaultLineDepth;
			return vectorLine;
		}

		public static VectorLine MakeLine(string name, Vector2[] points)
		{
			if (!defaultsSet)
			{
				PrintMakeLineError();
				return null;
			}
			VectorLine vectorLine = new VectorLine(name, points, defaultLineColor, defaultLineMaterial, defaultLineWidth, defaultLineType, defaultJoins);
			vectorLine.capLength = defaultCapLength;
			vectorLine.depth = defaultLineDepth;
			return vectorLine;
		}

		public static VectorLine SetLine(Color color, params Vector2[] points)
		{
			return SetLine(color, 0f, points);
		}

		public static VectorLine SetLine(Color color, float time, params Vector2[] points)
		{
			if (points.Length < 2)
			{
				LogError("VectorLine.SetLine needs at least two points");
				return null;
			}
			VectorLine vectorLine = new VectorLine("Line", points, color, null, 1f, LineType.Continuous, Joins.None);
			if (time > 0f)
			{
				lineManager.DisableLine(vectorLine, time);
			}
			vectorLine.Draw();
			return vectorLine;
		}

		public static VectorLine SetLine(Color color, params Vector3[] points)
		{
			return SetLine(color, 0f, points);
		}

		public static VectorLine SetLine(Color color, float time, params Vector3[] points)
		{
			if (points.Length < 2)
			{
				LogError("VectorLine.SetLine needs at least two points");
				return null;
			}
			VectorLine vectorLine = new VectorLine("SetLine", points, color, null, 1f, LineType.Continuous, Joins.None);
			if (time > 0f)
			{
				lineManager.DisableLine(vectorLine, time);
			}
			vectorLine.Draw();
			return vectorLine;
		}

		public static VectorLine SetLine3D(Color color, params Vector3[] points)
		{
			return SetLine3D(color, 0f, points);
		}

		public static VectorLine SetLine3D(Color color, float time, params Vector3[] points)
		{
			if (points.Length < 2)
			{
				LogError("VectorLine.SetLine3D needs at least two points");
				return null;
			}
			VectorLine vectorLine = new VectorLine("SetLine3D", points, color, null, 1f, LineType.Continuous, Joins.None);
			vectorLine.Draw3DAuto(time);
			return vectorLine;
		}

		public static VectorLine SetRay(Color color, Vector3 origin, Vector3 direction)
		{
			return SetRay(color, 0f, origin, direction);
		}

		public static VectorLine SetRay(Color color, float time, Vector3 origin, Vector3 direction)
		{
			VectorLine vectorLine = new VectorLine("SetRay", new Vector3[2]
			{
				origin,
				new Ray(origin, direction).GetPoint(direction.magnitude)
			}, color, null, 1f, LineType.Continuous, Joins.None);
			if (time > 0f)
			{
				lineManager.DisableLine(vectorLine, time);
			}
			vectorLine.Draw();
			return vectorLine;
		}

		public static VectorLine SetRay3D(Color color, Vector3 origin, Vector3 direction)
		{
			return SetRay3D(color, 0f, origin, direction);
		}

		public static VectorLine SetRay3D(Color color, float time, Vector3 origin, Vector3 direction)
		{
			VectorLine vectorLine = new VectorLine("SetRay3D", new Vector3[2]
			{
				origin,
				new Ray(origin, direction).GetPoint(direction.magnitude)
			}, color, null, 1f, LineType.Continuous, Joins.None);
			vectorLine.Draw3DAuto(time);
			return vectorLine;
		}

		private bool CheckLine()
		{
			if (m_mesh == null)
			{
				LogError("VectorLine \"" + m_name + "\" seems to have been destroyed. If you have used ObjectSetup, the way to remove the VectorLine is to destroy the GameObject passed into ObjectSetup.");
				return false;
			}
			if (m_1pixelLine)
			{
				return true;
			}
			if (m_useMeshQuads)
			{
				if (m_joins != Joins.Fill)
				{
					if (m_triangleCount != m_vertexCount)
					{
						SetupTriangles();
					}
				}
				else
				{
					if (m_is2D)
					{
						if ((points2[0] != points2[m_pointsLength - 1] && m_triangleCount != m_vertexCount * 2 - 4) || (points2[0] == points2[m_pointsLength - 1] && m_triangleCount != m_vertexCount * 2))
						{
							SetupTriangles();
						}
					}
					else if ((points3[0] != points3[m_pointsLength - 1] && m_triangleCount != m_vertexCount * 2 - 4) || (points3[0] == points3[m_pointsLength - 1] && m_triangleCount != m_vertexCount * 2))
					{
						SetupTriangles();
					}
					if (m_drawStart > 0)
					{
						m_lineVertices[m_drawStart * 4 - 1] = m_lineVertices[m_drawStart * 4];
						m_lineVertices[m_drawStart * 4 - 2] = m_lineVertices[m_drawStart * 4];
					}
					if (m_drawEnd > 0 && m_drawEnd < m_pointsLength - 1)
					{
						m_lineVertices[m_drawEnd * 4] = m_lineVertices[m_drawEnd * 4 - 1];
						m_lineVertices[m_drawEnd * 4 + 1] = m_lineVertices[m_drawEnd * 4 - 1];
					}
					if (m_minDrawIndex > 0)
					{
						m_lineVertices[m_minDrawIndex * 4 - 1] = m_lineVertices[m_minDrawIndex * 4];
						m_lineVertices[m_minDrawIndex * 4 - 2] = m_lineVertices[m_minDrawIndex * 4];
					}
					if (m_maxDrawIndex > 0 && m_maxDrawIndex < m_pointsLength - 1)
					{
						m_lineVertices[m_maxDrawIndex * 4] = m_lineVertices[m_maxDrawIndex * 4 - 1];
						m_lineVertices[m_maxDrawIndex * 4 + 1] = m_lineVertices[m_maxDrawIndex * 4 - 1];
					}
				}
			}
			else if (m_joins != Joins.Fill)
			{
				if (m_triangleCount != m_vertexCount + m_vertexCount / 2)
				{
					SetupTriangles();
				}
			}
			else
			{
				if (m_is2D)
				{
					if ((points2[0] != points2[m_pointsLength - 1] && m_triangleCount != m_vertexCount * 3 - 6) || (points2[0] == points2[m_pointsLength - 1] && m_triangleCount != m_vertexCount * 3))
					{
						SetupTriangles();
					}
				}
				else if ((points3[0] != points3[m_pointsLength - 1] && m_triangleCount != m_vertexCount * 3 - 6) || (points3[0] == points3[m_pointsLength - 1] && m_triangleCount != m_vertexCount * 3))
				{
					SetupTriangles();
				}
				if (m_drawStart > 0)
				{
					m_lineVertices[m_drawStart * 4 - 1] = m_lineVertices[m_drawStart * 4];
				}
				if (m_drawEnd > 0 && m_drawEnd < m_pointsLength - 1)
				{
					m_lineVertices[m_drawEnd * 4] = m_lineVertices[m_drawEnd * 4 - 1];
				}
				if (m_minDrawIndex > 0)
				{
					m_lineVertices[m_minDrawIndex * 4 - 1] = m_lineVertices[m_minDrawIndex * 4];
				}
				if (m_maxDrawIndex > 0 && m_maxDrawIndex < m_pointsLength - 1)
				{
					m_lineVertices[m_maxDrawIndex * 4] = m_lineVertices[m_maxDrawIndex * 4 - 1];
				}
			}
			if (m_capType != EndCap.None)
			{
				if (m_capType <= EndCap.Mirror)
				{
					int num = m_drawStart * 4;
					int num2 = ((m_lineWidths.Length > 1) ? m_drawStart : 0);
					if (!m_continuous)
					{
						num2 /= 2;
						num /= 2;
					}
					if (m_is2D)
					{
						Vector3 vector = (m_lineVertices[num] - m_lineVertices[num + 2]).normalized * m_lineWidths[num2] * 2f * capDictionary[m_endCap].ratio1;
						m_lineVertices[m_vertexCount] = m_lineVertices[num] + vector;
						m_lineVertices[m_vertexCount + 1] = m_lineVertices[num + 1] + vector;
					}
					else
					{
						Vector3 vector2 = cam3D.WorldToScreenPoint(m_lineVertices[num]);
						Vector3 vector3 = (vector2 - cam3D.WorldToScreenPoint(m_lineVertices[num + 2])).normalized * m_lineWidths[num2] * 2f * capDictionary[m_endCap].ratio1;
						m_lineVertices[m_vertexCount] = cam3D.ScreenToWorldPoint(vector2 + vector3);
						m_lineVertices[m_vertexCount + 1] = cam3D.ScreenToWorldPoint(cam3D.WorldToScreenPoint(m_lineVertices[num + 1]) + vector3);
					}
					m_lineVertices[m_vertexCount + 2] = m_lineVertices[num];
					m_lineVertices[m_vertexCount + 3] = m_lineVertices[num + 1];
				}
				if (m_capType >= EndCap.Both)
				{
					int num3 = m_drawEnd;
					if (m_continuous)
					{
						if (m_drawEnd == m_pointsLength)
						{
							num3--;
						}
					}
					else if (num3 < m_pointsLength)
					{
						num3++;
					}
					int num4 = num3 * 4;
					int num5 = ((m_lineWidths.Length > 1) ? (num3 - 1) : 0);
					if (num5 < 0)
					{
						num5 = 0;
					}
					if (!m_continuous)
					{
						num5 /= 2;
						num4 /= 2;
					}
					if (num4 < 4)
					{
						num4 = 4;
					}
					m_lineVertices[m_vertexCount + 4] = m_lineVertices[num4 - 2];
					m_lineVertices[m_vertexCount + 5] = m_lineVertices[num4 - 1];
					if (m_is2D)
					{
						Vector3 vector4 = (m_lineVertices[num4 - 1] - m_lineVertices[num4 - 3]).normalized * m_lineWidths[num5] * 2f * capDictionary[m_endCap].ratio2;
						m_lineVertices[m_vertexCount + 6] = m_lineVertices[num4 - 2] + vector4;
						m_lineVertices[m_vertexCount + 7] = m_lineVertices[num4 - 1] + vector4;
					}
					else
					{
						Vector3 vector5 = cam3D.WorldToScreenPoint(m_lineVertices[num4 - 1]);
						Vector3 vector6 = (vector5 - cam3D.WorldToScreenPoint(m_lineVertices[num4 - 3])).normalized * m_lineWidths[num5] * 2f * capDictionary[m_endCap].ratio2;
						m_lineVertices[m_vertexCount + 6] = cam3D.ScreenToWorldPoint(cam3D.WorldToScreenPoint(m_lineVertices[num4 - 2]) + vector6);
						m_lineVertices[m_vertexCount + 7] = cam3D.ScreenToWorldPoint(vector5 + vector6);
					}
				}
				if (m_drawStart > 0 || m_drawEnd < m_pointsLength)
				{
					SetEndCapColors();
					m_mesh.colors32 = m_lineColors;
				}
			}
			if (m_continuousTexture)
			{
				int num6 = 0;
				float x = 0f;
				SetDistances();
				int num7 = m_distances.Length - 1;
				float num8 = m_distances[num7];
				for (int i = 0; i < num7; i++)
				{
					m_lineUVs[num6].x = x;
					m_lineUVs[num6 + 1].x = x;
					x = 1f / (num8 / m_distances[i + 1]);
					m_lineUVs[num6 + 2].x = x;
					m_lineUVs[num6 + 3].x = x;
					num6 += 4;
				}
				m_mesh.uv = m_lineUVs;
			}
			return true;
		}

		private void CheckNormals()
		{
			if (m_useNormals && !m_normalsCalculated)
			{
				m_mesh.RecalculateNormals();
				m_normalsCalculated = true;
			}
			if (m_useTangents && !m_tangentsCalculated)
			{
				CalculateTangents();
				m_tangentsCalculated = true;
			}
		}

		public void Draw()
		{
			Draw(null);
		}

		public void Draw(Transform thisTransform)
		{
			if (error || !m_active)
			{
				return;
			}
			if (!cam)
			{
				SetCamera();
				if (!cam)
				{
					LogError("VectorLine.Draw: You must call SetCamera before calling Draw for \"" + name + "\"");
					return;
				}
			}
			if (thisTransform != null)
			{
				m_useTransform = thisTransform;
			}
			if (m_isPoints)
			{
				DrawPoints(thisTransform);
				return;
			}
			if (smoothWidth && m_lineWidths.Length == 1 && pointsLength > 2)
			{
				LogError("VectorLine.Draw called with smooth line widths for \"" + name + "\", but VectorLine.SetWidths has not been used");
				return;
			}
			bool flag = !(thisTransform == null);
			Matrix4x4 thisMatrix = ((!flag) ? Matrix4x4.identity : thisTransform.localToWorldMatrix);
			zDist = ((!useOrthoCam) ? ((float)(screenHeight / 2) + (100f - (float)m_depth) * 0.0001f) : ((float)(101 - m_depth)));
			int end = 0;
			int start;
			SetupDrawStartEnd(out start, out end);
			if (m_is2D)
			{
				Line2D(start, end, thisMatrix, flag);
			}
			else if (m_continuous)
			{
				Line3DContinuous(start, end, thisMatrix, flag);
			}
			else
			{
				Line3DDiscrete(start, end, thisMatrix, flag);
			}
			if (CheckLine())
			{
				m_mesh.vertices = m_lineVertices;
				CheckNormals();
				if (m_mesh.bounds.center.x != (float)(screenWidth / 2))
				{
					SetLineMeshBounds();
				}
			}
		}

		private void Line2D(int start, int end, Matrix4x4 thisMatrix, bool useTransformMatrix)
		{
			if (m_1pixelLine)
			{
				if (m_continuous)
				{
					int num = start * 2;
					for (int i = start; i < end; i++)
					{
						Vector3 vector;
						Vector3 vector2;
						if (useTransformMatrix)
						{
							vector = thisMatrix.MultiplyPoint3x4(points2[i]);
							vector2 = thisMatrix.MultiplyPoint3x4(points2[i + 1]);
						}
						else
						{
							vector = points2[i];
							vector2 = points2[i + 1];
						}
						vector.z = zDist;
						vector2.z = zDist;
						m_lineVertices[num] = vector;
						m_lineVertices[num + 1] = vector2;
						num += 2;
					}
				}
				else
				{
					for (int j = start; j <= end; j++)
					{
						Vector3 vector = ((!useTransformMatrix) ? ((Vector3)points2[j]) : thisMatrix.MultiplyPoint3x4(points2[j]));
						vector.z = zDist;
						m_lineVertices[j] = vector;
					}
				}
				return;
			}
			int widthIdx = 0;
			widthIdxAdd = 0;
			if (m_lineWidths.Length > 1)
			{
				widthIdx = start;
				widthIdxAdd = 1;
			}
			int idx;
			int num2;
			if (m_continuous)
			{
				idx = start * 4;
				num2 = 1;
			}
			else
			{
				idx = start * 2;
				num2 = 2;
				widthIdx /= 2;
			}
			if (capLength == 0f)
			{
				Vector3 vector3 = new Vector3(0f, 0f, 0f);
				for (int k = start; k < end; k += num2)
				{
					Vector3 vector;
					Vector3 vector2;
					if (useTransformMatrix)
					{
						vector = thisMatrix.MultiplyPoint3x4(points2[k]);
						vector2 = thisMatrix.MultiplyPoint3x4(points2[k + 1]);
					}
					else
					{
						vector = points2[k];
						vector2 = points2[k + 1];
					}
					vector.z = zDist;
					if (vector.x == vector2.x && vector.y == vector2.y)
					{
						Skip(ref idx, ref widthIdx, ref vector);
						continue;
					}
					vector2.z = zDist;
					v1.x = vector2.y;
					v1.y = vector.x;
					v2.x = vector.y;
					v2.y = vector2.x;
					vector3 = v1 - v2;
					float num3 = 1f / Mathf.Sqrt(vector3.x * vector3.x + vector3.y * vector3.y);
					vector3 *= num3 * m_lineWidths[widthIdx];
					m_lineVertices[idx] = vector - vector3;
					m_lineVertices[idx + 1] = vector + vector3;
					if (smoothWidth && k < end - num2)
					{
						vector3 = v1 - v2;
						vector3 *= num3 * m_lineWidths[widthIdx + 1];
					}
					m_lineVertices[idx + 2] = vector2 - vector3;
					m_lineVertices[idx + 3] = vector2 + vector3;
					idx += 4;
					widthIdx += widthIdxAdd;
				}
				if (m_joins == Joins.Weld)
				{
					if (m_continuous)
					{
						WeldJoins(start * 4 + ((start == 0) ? 4 : 0), end * 4, Approximately2(points2[0], points2[points2.Length - 1]) && m_minDrawIndex == 0 && (m_maxDrawIndex == points2.Length - 1 || m_maxDrawIndex == 0));
					}
					else
					{
						WeldJoinsDiscrete(start + 1, end, Approximately2(points2[0], points2[points2.Length - 1]) && m_minDrawIndex == 0 && (m_maxDrawIndex == points2.Length - 1 || m_maxDrawIndex == 0));
					}
				}
				return;
			}
			Vector3 vector4 = new Vector3(0f, 0f, 0f);
			for (int l = m_minDrawIndex; l < end; l += num2)
			{
				Vector3 vector;
				Vector3 vector2;
				if (useTransformMatrix)
				{
					vector = thisMatrix.MultiplyPoint3x4(points2[l]);
					vector2 = thisMatrix.MultiplyPoint3x4(points2[l + 1]);
				}
				else
				{
					vector = points2[l];
					vector2 = points2[l + 1];
				}
				vector.z = zDist;
				if (vector.x == vector2.x && vector.y == vector2.y)
				{
					Skip(ref idx, ref widthIdx, ref vector);
					continue;
				}
				vector2.z = zDist;
				vector4 = vector2 - vector;
				vector4 *= 1f / Mathf.Sqrt(vector4.x * vector4.x + vector4.y * vector4.y);
				vector -= vector4 * capLength;
				vector2 += vector4 * capLength;
				v1.x = vector4.y;
				v1.y = 0f - vector4.x;
				vector4 = v1 * m_lineWidths[widthIdx];
				m_lineVertices[idx] = vector - vector4;
				m_lineVertices[idx + 1] = vector + vector4;
				if (smoothWidth && l < end - num2)
				{
					vector4 = v1 * m_lineWidths[widthIdx + 1];
				}
				m_lineVertices[idx + 2] = vector2 - vector4;
				m_lineVertices[idx + 3] = vector2 + vector4;
				idx += 4;
				widthIdx += widthIdxAdd;
			}
		}

		private void Line3DContinuous(int start, int end, Matrix4x4 thisMatrix, bool useTransformMatrix)
		{
			if (!cam3D)
			{
				LogError("The 3D camera no longer exists...if you have changed scenes, ensure that SetCamera3D is called in order to set it up.");
				return;
			}
			if (m_1pixelLine)
			{
				Vector3 vector = ((!useTransformMatrix) ? cam3D.WorldToScreenPoint(points3[start]) : cam3D.WorldToScreenPoint(thisMatrix.MultiplyPoint3x4(points3[start])));
				vector.z = ((!(vector.z < 0.15f)) ? zDist : (0f - zDist));
				int num = start * 2;
				for (int i = start; i < end; i++)
				{
					Vector3 vector2 = vector;
					vector = ((!useTransformMatrix) ? cam3D.WorldToScreenPoint(points3[i + 1]) : cam3D.WorldToScreenPoint(thisMatrix.MultiplyPoint3x4(points3[i + 1])));
					vector.z = ((!(vector.z < 0.15f)) ? zDist : (0f - zDist));
					m_lineVertices[num] = vector2;
					m_lineVertices[num + 1] = vector;
					num += 2;
				}
				return;
			}
			Vector3 vector3 = ((!useTransformMatrix) ? cam3D.WorldToScreenPoint(points3[start]) : cam3D.WorldToScreenPoint(thisMatrix.MultiplyPoint3x4(points3[start])));
			vector3.z = ((!(vector3.z < 0.15f)) ? zDist : (0f - zDist));
			float num2 = 0f;
			int widthIdx = 0;
			widthIdxAdd = 0;
			if (m_lineWidths.Length > 1)
			{
				widthIdx = start;
				widthIdxAdd = 1;
			}
			int idx = start * 4;
			for (int j = start; j < end; j++)
			{
				Vector3 pos = vector3;
				vector3 = ((!useTransformMatrix) ? cam3D.WorldToScreenPoint(points3[j + 1]) : cam3D.WorldToScreenPoint(thisMatrix.MultiplyPoint3x4(points3[j + 1])));
				if (pos.x == vector3.x && pos.y == vector3.y)
				{
					Skip(ref idx, ref widthIdx, ref pos);
					continue;
				}
				vector3.z = ((!(vector3.z < 0.15f)) ? zDist : (0f - zDist));
				v1.x = vector3.y;
				v1.y = pos.x;
				v2.x = pos.y;
				v2.y = vector3.x;
				Vector3 vector4 = v1 - v2;
				num2 = 1f / Mathf.Sqrt(vector4.x * vector4.x + vector4.y * vector4.y);
				vector4 *= num2 * m_lineWidths[widthIdx];
				m_lineVertices[idx] = pos - vector4;
				m_lineVertices[idx + 1] = pos + vector4;
				if (smoothWidth && j < end - 1)
				{
					vector4 = v1 - v2;
					vector4 *= num2 * m_lineWidths[widthIdx + 1];
				}
				m_lineVertices[idx + 2] = vector3 - vector4;
				m_lineVertices[idx + 3] = vector3 + vector4;
				idx += 4;
				widthIdx += widthIdxAdd;
			}
			if (m_joins == Joins.Weld)
			{
				WeldJoins(start * 4 + 4, end * 4, Approximately3(points3[0], points3[points3.Length - 1]) && m_minDrawIndex == 0 && (m_maxDrawIndex == points3.Length - 1 || m_maxDrawIndex == 0));
			}
		}

		private void Line3DDiscrete(int start, int end, Matrix4x4 thisMatrix, bool useTransformMatrix)
		{
			if (!cam3D)
			{
				LogError("The 3D camera no longer exists...if you have changed scenes, ensure that SetCamera3D is called in order to set it up.");
				return;
			}
			if (m_1pixelLine)
			{
				for (int i = start; i <= end; i++)
				{
					Vector3 vector = ((!useTransformMatrix) ? cam3D.WorldToScreenPoint(points3[i]) : cam3D.WorldToScreenPoint(thisMatrix.MultiplyPoint3x4(points3[i])));
					vector.z = ((!(vector.z < 0.15f)) ? zDist : (0f - zDist));
					m_lineVertices[i] = vector;
				}
				return;
			}
			float num = 0f;
			int widthIdx = 0;
			widthIdxAdd = 0;
			if (m_lineWidths.Length > 1)
			{
				widthIdx = start;
				widthIdxAdd = 1;
			}
			int idx = start * 2;
			for (int j = start; j < end; j += 2)
			{
				Vector3 pos;
				Vector3 vector2;
				if (useTransformMatrix)
				{
					pos = cam3D.WorldToScreenPoint(thisMatrix.MultiplyPoint3x4(points3[j]));
					vector2 = cam3D.WorldToScreenPoint(thisMatrix.MultiplyPoint3x4(points3[j + 1]));
				}
				else
				{
					pos = cam3D.WorldToScreenPoint(points3[j]);
					vector2 = cam3D.WorldToScreenPoint(points3[j + 1]);
				}
				pos.z = ((!(pos.z < 0.15f)) ? zDist : (0f - zDist));
				if (pos.x == vector2.x && pos.y == vector2.y)
				{
					Skip(ref idx, ref widthIdx, ref pos);
					continue;
				}
				vector2.z = ((!(vector2.z < 0.15f)) ? zDist : (0f - zDist));
				v1.x = vector2.y;
				v1.y = pos.x;
				v2.x = pos.y;
				v2.y = vector2.x;
				Vector3 vector3 = v1 - v2;
				num = 1f / Mathf.Sqrt(vector3.x * vector3.x + vector3.y * vector3.y);
				vector3 *= num * m_lineWidths[widthIdx];
				m_lineVertices[idx] = pos - vector3;
				m_lineVertices[idx + 1] = pos + vector3;
				if (smoothWidth && j < end - 2)
				{
					vector3 = v1 - v2;
					vector3 *= num * m_lineWidths[widthIdx + 1];
				}
				m_lineVertices[idx + 2] = vector2 - vector3;
				m_lineVertices[idx + 3] = vector2 + vector3;
				idx += 4;
				widthIdx += widthIdxAdd;
			}
			if (m_joins == Joins.Weld)
			{
				WeldJoinsDiscrete(start + 1, end, Approximately3(points3[0], points3[points3.Length - 1]) && m_minDrawIndex == 0 && (m_maxDrawIndex == points3.Length - 1 || m_maxDrawIndex == 0));
			}
		}

		public void Draw3D()
		{
			Draw3D(null);
		}

		public void Draw3D(Transform thisTransform)
		{
			if (error || !m_active)
			{
				return;
			}
			if (!cam3D)
			{
				SetCamera3D();
				if (!cam3D)
				{
					LogError("VectorLine.Draw3D: You must call SetCamera or SetCamera3D before calling Draw3D for \"" + name + "\"");
					return;
				}
			}
			if (m_is2D)
			{
				LogError("VectorLine.Draw3D can only be used with a Vector3 array, which \"" + name + "\" doesn't have");
				return;
			}
			if (thisTransform != null)
			{
				m_useTransform = thisTransform;
			}
			if (m_isPoints)
			{
				DrawPoints3D(thisTransform);
				return;
			}
			if (smoothWidth && m_lineWidths.Length == 1 && pointsLength > 2)
			{
				LogError("VectorLine.Draw3D called with smooth line widths for \"" + name + "\", but VectorLine.SetWidths has not been used");
				return;
			}
			if (layer == -1)
			{
				m_vectorObject.layer = _vectorLayer3D;
				layer = _vectorLayer3D;
			}
			int num = 0;
			int start;
			int end;
			SetupDrawStartEnd(out start, out end);
			bool flag = !(thisTransform == null);
			Matrix4x4 matrix4x = ((!flag) ? Matrix4x4.identity : thisTransform.localToWorldMatrix);
			if (m_1pixelLine)
			{
				if (m_continuous)
				{
					int num2 = start * 2;
					if (flag)
					{
						for (int i = start; i < end; i++)
						{
							m_lineVertices[num2] = matrix4x.MultiplyPoint3x4(points3[i]);
							m_lineVertices[num2 + 1] = matrix4x.MultiplyPoint3x4(points3[i + 1]);
							num2 += 2;
						}
					}
					else
					{
						for (int j = start; j < end; j++)
						{
							m_lineVertices[num2] = points3[j];
							m_lineVertices[num2 + 1] = points3[j + 1];
							num2 += 2;
						}
					}
				}
				else if (flag)
				{
					for (int k = start; k <= end; k++)
					{
						m_lineVertices[k] = matrix4x.MultiplyPoint3x4(points3[k]);
					}
				}
				else
				{
					for (int l = start; l <= end; l++)
					{
						m_lineVertices[l] = points3[l];
					}
				}
				if (CheckLine())
				{
					m_mesh.vertices = m_lineVertices;
					m_mesh.RecalculateBounds();
				}
				return;
			}
			widthIdxAdd = 0;
			if (m_lineWidths.Length > 1)
			{
				num = start;
				widthIdxAdd = 1;
			}
			int num3;
			int num4;
			if (m_continuous)
			{
				num3 = start * 4;
				num4 = 1;
			}
			else
			{
				num3 = start * 2;
				num /= 2;
				num4 = 2;
			}
			for (int m = start; m < end; m += num4)
			{
				Vector3 vector;
				Vector3 vector2;
				if (flag)
				{
					vector = cam3D.WorldToScreenPoint(matrix4x.MultiplyPoint3x4(points3[m]));
					vector2 = cam3D.WorldToScreenPoint(matrix4x.MultiplyPoint3x4(points3[m + 1]));
				}
				else
				{
					vector = cam3D.WorldToScreenPoint(points3[m]);
					vector2 = cam3D.WorldToScreenPoint(points3[m + 1]);
				}
				v1.x = vector2.y;
				v1.y = vector.x;
				v2.x = vector.y;
				v2.y = vector2.x;
				Vector3 normalized = (v1 - v2).normalized;
				Vector3 vector3 = normalized * m_lineWidths[num];
				m_screenPoints[num3] = vector - vector3;
				m_screenPoints[num3 + 1] = vector + vector3;
				m_lineVertices[num3] = cam3D.ScreenToWorldPoint(m_screenPoints[num3]);
				m_lineVertices[num3 + 1] = cam3D.ScreenToWorldPoint(m_screenPoints[num3 + 1]);
				if (smoothWidth && m < end - num4)
				{
					vector3 = normalized * m_lineWidths[num + 1];
				}
				m_screenPoints[num3 + 2] = vector2 - vector3;
				m_screenPoints[num3 + 3] = vector2 + vector3;
				m_lineVertices[num3 + 2] = cam3D.ScreenToWorldPoint(m_screenPoints[num3 + 2]);
				m_lineVertices[num3 + 3] = cam3D.ScreenToWorldPoint(m_screenPoints[num3 + 3]);
				num3 += 4;
				num += widthIdxAdd;
			}
			if (m_joins == Joins.Weld)
			{
				if (m_continuous)
				{
					WeldJoins3D(start * 4 + 4, end * 4, Approximately3(points3[0], points3[m_pointsLength - 1]) && m_minDrawIndex == 0 && (m_maxDrawIndex == points3.Length - 1 || m_maxDrawIndex == 0));
				}
				else
				{
					WeldJoinsDiscrete3D(start + 1, end, Approximately3(points3[0], points3[m_pointsLength - 1]) && m_minDrawIndex == 0 && (m_maxDrawIndex == points3.Length - 1 || m_maxDrawIndex == 0));
				}
			}
			if (CheckLine())
			{
				m_mesh.vertices = m_lineVertices;
				m_mesh.RecalculateBounds();
				CheckNormals();
			}
		}

		public void DrawViewport()
		{
			DrawViewport(null);
		}

		public void DrawViewport(Transform thisTransform)
		{
			if (error || !m_active)
			{
				return;
			}
			if (!cam)
			{
				SetCamera();
				if (!cam)
				{
					LogError("VectorLine.DrawViewport: You must call SetCamera before calling DrawViewport for \"" + name + "\"");
					return;
				}
			}
			if (m_isPoints)
			{
				LogError("VectorLine.DrawViewport can't be used with VectorPoints");
				return;
			}
			if (!m_is2D)
			{
				LogError("VectorLine.DrawViewport can only be used with a Vector2 array, which \"" + name + "\" doesn't have");
				return;
			}
			if (smoothWidth && m_lineWidths.Length == 1 && pointsLength > 2)
			{
				LogError("VectorLine.DrawViewport called with smooth line widths for \"" + name + "\", but SetWidths has not been used");
				return;
			}
			bool flag = !(thisTransform == null);
			Matrix4x4 matrix4x = ((!flag) ? Matrix4x4.identity : thisTransform.localToWorldMatrix);
			zDist = ((!useOrthoCam) ? ((float)(screenHeight / 2) + (100f - (float)m_depth) * 0.0001f) : ((float)(101 - m_depth)));
			int widthIdx = 0;
			widthIdxAdd = 0;
			int start;
			int end;
			SetupDrawStartEnd(out start, out end);
			int num = screenWidth;
			int num2 = screenHeight;
			if (m_1pixelLine)
			{
				if (m_continuous)
				{
					int num3 = start * 2;
					for (int i = start; i < end; i++)
					{
						Vector3 vector;
						Vector3 vector2;
						if (flag)
						{
							vector = matrix4x.MultiplyPoint3x4(points2[i]);
							vector2 = matrix4x.MultiplyPoint3x4(points2[i + 1]);
						}
						else
						{
							vector = points2[i];
							vector2 = points2[i + 1];
						}
						vector.z = zDist;
						vector2.z = zDist;
						vector.x *= num;
						vector.y *= num2;
						vector2.x *= num;
						vector2.y *= num2;
						m_lineVertices[num3] = vector;
						m_lineVertices[num3 + 1] = vector2;
						num3 += 2;
					}
				}
				else
				{
					for (int j = start; j <= end; j++)
					{
						Vector3 vector = ((!flag) ? ((Vector3)points2[j]) : matrix4x.MultiplyPoint3x4(points2[j]));
						vector.x *= num;
						vector.y *= num2;
						vector.z = zDist;
						m_lineVertices[j] = vector;
					}
				}
				if (CheckLine())
				{
					m_mesh.vertices = m_lineVertices;
					if (m_mesh.bounds.center.x != (float)(num / 2))
					{
						SetLineMeshBounds();
					}
				}
				return;
			}
			if (m_lineWidths.Length > 1)
			{
				widthIdx = start;
				widthIdxAdd = 1;
			}
			int idx;
			int num4;
			if (m_continuous)
			{
				idx = start * 4;
				num4 = 1;
			}
			else
			{
				idx = start * 2;
				widthIdx /= 2;
				num4 = 2;
			}
			if (capLength == 0f)
			{
				for (int k = start; k < end; k += num4)
				{
					Vector3 vector;
					Vector3 vector2;
					if (flag)
					{
						vector = matrix4x.MultiplyPoint3x4(points2[k]);
						vector2 = matrix4x.MultiplyPoint3x4(points2[k + 1]);
					}
					else
					{
						vector = points2[k];
						vector2 = points2[k + 1];
					}
					vector.z = zDist;
					if (vector.x == vector2.x && vector.y == vector2.y)
					{
						Skip(ref idx, ref widthIdx, ref vector);
						continue;
					}
					vector2.z = zDist;
					vector.x *= num;
					vector.y *= num2;
					vector2.x *= num;
					vector2.y *= num2;
					v1.x = vector2.y * (float)num;
					v1.y = vector.x * (float)num2;
					v2.x = vector.y * (float)num;
					v2.y = vector2.x * (float)num2;
					Vector3 vector3 = v1 - v2;
					float num5 = 1f / Mathf.Sqrt(vector3.x * vector3.x + vector3.y * vector3.y);
					vector3 *= num5 * m_lineWidths[widthIdx];
					m_lineVertices[idx] = vector - vector3;
					m_lineVertices[idx + 1] = vector + vector3;
					if (smoothWidth && k < end - num4)
					{
						vector3 = v1 - v2;
						vector3 *= num5 * m_lineWidths[widthIdx + 1];
					}
					m_lineVertices[idx + 2] = vector2 - vector3;
					m_lineVertices[idx + 3] = vector2 + vector3;
					idx += 4;
					widthIdx += widthIdxAdd;
				}
				if (m_joins == Joins.Weld)
				{
					if (m_continuous)
					{
						WeldJoins(start * 4 + 4, end * 4, Approximately2(points2[0], points2[m_pointsLength - 1]) && m_minDrawIndex == 0 && (m_maxDrawIndex == points2.Length - 1 || m_maxDrawIndex == 0));
					}
					else
					{
						WeldJoinsDiscrete(start + 1, end, Approximately2(points2[0], points2[m_pointsLength - 1]) && m_minDrawIndex == 0 && (m_maxDrawIndex == points2.Length - 1 || m_maxDrawIndex == 0));
					}
				}
			}
			else
			{
				for (int l = m_minDrawIndex; l < end; l += num4)
				{
					Vector3 vector;
					Vector3 vector2;
					if (flag)
					{
						vector = matrix4x.MultiplyPoint3x4(points2[l]);
						vector2 = matrix4x.MultiplyPoint3x4(points2[l + 1]);
					}
					else
					{
						vector = points2[l];
						vector2 = points2[l + 1];
					}
					vector.z = zDist;
					if (vector.x == vector2.x && vector.y == vector2.y)
					{
						Skip(ref idx, ref widthIdx, ref vector);
						continue;
					}
					vector2.z = zDist;
					vector.x *= num;
					vector.y *= num2;
					vector2.x *= num;
					vector2.y *= num2;
					Vector3 vector4 = vector2 - vector;
					vector4 *= 1f / Mathf.Sqrt(vector4.x * vector4.x + vector4.y * vector4.y);
					vector -= vector4 * capLength;
					vector2 += vector4 * capLength;
					v1.x = vector4.y;
					v1.y = 0f - vector4.x;
					vector4 = v1 * m_lineWidths[widthIdx];
					m_lineVertices[idx] = vector - vector4;
					m_lineVertices[idx + 1] = vector + vector4;
					if (smoothWidth && l < end - num4)
					{
						vector4 = v1 * m_lineWidths[widthIdx + 1];
					}
					m_lineVertices[idx + 2] = vector2 - vector4;
					m_lineVertices[idx + 3] = vector2 + vector4;
					idx += 4;
					widthIdx += widthIdxAdd;
				}
			}
			if (CheckLine())
			{
				m_mesh.vertices = m_lineVertices;
				if (m_mesh.bounds.center.x != (float)(num / 2))
				{
					SetLineMeshBounds();
				}
			}
		}

		private void DrawPoints()
		{
			DrawPoints(null);
		}

		private void DrawPoints(Transform thisTransform)
		{
			bool flag = !(thisTransform == null);
			Matrix4x4 matrix4x = ((!flag) ? Matrix4x4.identity : thisTransform.localToWorldMatrix);
			zDist = ((!useOrthoCam) ? ((float)(screenHeight / 2) + (100f - (float)m_depth) * 0.0001f) : ((float)(101 - m_depth)));
			int widthIdx = 0;
			int start;
			int end;
			SetupDrawStartEnd(out start, out end);
			if (m_1pixelLine)
			{
				if (!m_is2D)
				{
					for (int i = start; i <= end; i++)
					{
						m_lineVertices[i] = ((!flag) ? cam3D.WorldToScreenPoint(points3[i]) : cam3D.WorldToScreenPoint(matrix4x.MultiplyPoint3x4(points3[i])));
						if (m_lineVertices[i].z < 0.15f)
						{
							m_lineVertices[i] = Vector3.zero;
						}
						else
						{
							m_lineVertices[i].z = zDist;
						}
					}
				}
				else
				{
					for (int j = start; j <= end; j++)
					{
						m_lineVertices[j] = ((!flag) ? ((Vector3)points2[j]) : matrix4x.MultiplyPoint3x4(points2[j]));
						m_lineVertices[j].z = zDist;
					}
				}
				m_mesh.vertices = m_lineVertices;
				if (m_mesh.bounds.center.x != (float)(screenWidth / 2))
				{
					SetLineMeshBounds();
				}
				return;
			}
			int idx = start * 4;
			widthIdxAdd = 0;
			if (m_lineWidths.Length > 1)
			{
				widthIdx = start;
				widthIdxAdd = 1;
			}
			if (!m_is2D)
			{
				for (int k = start; k <= end; k++)
				{
					Vector3 pos = ((!flag) ? cam3D.WorldToScreenPoint(points3[k]) : cam3D.WorldToScreenPoint(matrix4x.MultiplyPoint3x4(points3[k])));
					if (pos.z < 0.15f)
					{
						Skip(ref idx, ref widthIdx, ref pos);
						continue;
					}
					pos.z = zDist;
					v1.x = (v1.y = (v2.y = m_lineWidths[widthIdx]));
					v2.x = 0f - m_lineWidths[widthIdx];
					m_lineVertices[idx] = pos + v2;
					m_lineVertices[idx + 1] = pos - v1;
					m_lineVertices[idx + 2] = pos + v1;
					m_lineVertices[idx + 3] = pos - v2;
					idx += 4;
					widthIdx += widthIdxAdd;
				}
			}
			else
			{
				for (int l = start; l <= end; l++)
				{
					Vector3 pos = ((!flag) ? ((Vector3)points2[l]) : matrix4x.MultiplyPoint3x4(points2[l]));
					pos.z = zDist;
					v1.x = (v1.y = (v2.y = m_lineWidths[widthIdx]));
					v2.x = 0f - m_lineWidths[widthIdx];
					m_lineVertices[idx] = pos + v2;
					m_lineVertices[idx + 1] = pos - v1;
					m_lineVertices[idx + 2] = pos + v1;
					m_lineVertices[idx + 3] = pos - v2;
					idx += 4;
					widthIdx += widthIdxAdd;
				}
			}
			m_mesh.vertices = m_lineVertices;
			if (m_mesh.bounds.center.x != (float)(screenWidth / 2))
			{
				SetLineMeshBounds();
			}
		}

		private void DrawPoints3D()
		{
			DrawPoints3D(null);
		}

		private void DrawPoints3D(Transform thisTransform)
		{
			if (layer == -1)
			{
				m_vectorObject.layer = _vectorLayer3D;
				layer = _vectorLayer3D;
			}
			bool flag = !(thisTransform == null);
			Matrix4x4 matrix4x = ((!flag) ? Matrix4x4.identity : thisTransform.localToWorldMatrix);
			int widthIdx = 0;
			int start;
			int end;
			SetupDrawStartEnd(out start, out end);
			if (m_1pixelLine)
			{
				if (flag)
				{
					for (int i = start; i <= end; i++)
					{
						m_lineVertices[i] = matrix4x.MultiplyPoint3x4(points3[i]);
					}
				}
				else
				{
					for (int j = start; j <= end; j++)
					{
						m_lineVertices[j] = points3[j];
					}
				}
				m_mesh.vertices = m_lineVertices;
				m_mesh.RecalculateBounds();
				return;
			}
			int idx = m_minDrawIndex * 4;
			widthIdxAdd = 0;
			if (m_lineWidths.Length > 1)
			{
				widthIdx = start;
				widthIdxAdd = 1;
			}
			for (int k = start; k <= end; k++)
			{
				Vector3 vector = ((!flag) ? cam3D.WorldToScreenPoint(points3[k]) : cam3D.WorldToScreenPoint(matrix4x.MultiplyPoint3x4(points3[k])));
				if (vector.z < 0.15f)
				{
					vector = Vector3.zero;
					Skip(ref idx, ref widthIdx, ref vector);
					continue;
				}
				v1.x = (v1.y = (v2.y = m_lineWidths[widthIdx]));
				v2.x = 0f - m_lineWidths[widthIdx];
				m_lineVertices[idx] = cam3D.ScreenToWorldPoint(vector + v2);
				m_lineVertices[idx + 1] = cam3D.ScreenToWorldPoint(vector - v1);
				m_lineVertices[idx + 2] = cam3D.ScreenToWorldPoint(vector + v1);
				m_lineVertices[idx + 3] = cam3D.ScreenToWorldPoint(vector - v2);
				idx += 4;
				widthIdx += widthIdxAdd;
			}
			m_mesh.vertices = m_lineVertices;
			m_mesh.RecalculateBounds();
			CheckNormals();
		}

		private void Skip(ref int idx, ref int widthIdx, ref Vector3 pos)
		{
			m_lineVertices[idx] = pos;
			m_lineVertices[idx + 1] = pos;
			m_lineVertices[idx + 2] = pos;
			m_lineVertices[idx + 3] = pos;
			idx += 4;
			widthIdx += widthIdxAdd;
		}

		private void SetLineMeshBounds()
		{
			Bounds bounds = default(Bounds);
			if (!useOrthoCam)
			{
				bounds.center = new Vector3(screenWidth / 2, screenHeight / 2, screenHeight / 2);
				bounds.extents = new Vector3(screenWidth * 100, screenHeight * 100, 0.1f);
			}
			else
			{
				bounds.center = new Vector3(screenWidth / 2, screenHeight / 2, 50.5f);
				bounds.extents = new Vector3(screenWidth * 100, screenHeight * 100, 51f);
			}
			m_mesh.bounds = bounds;
		}

		private void SetupDrawStartEnd(out int start, out int end)
		{
			start = m_minDrawIndex;
			end = ((m_maxDrawIndex != 0) ? m_maxDrawIndex : (m_pointsLength - 1));
			if (m_drawStart > 0)
			{
				start = m_drawStart;
				ZeroVertices(0, m_drawStart);
			}
			if (m_drawEnd < m_pointsLength)
			{
				end = m_drawEnd;
				ZeroVertices(m_drawEnd, m_pointsLength);
			}
		}

		public static void LineManagerCheckDistance()
		{
			lineManager.StartCheckDistance();
		}

		public static void LineManagerDisable()
		{
			lineManager.DisableIfUnused();
		}

		public static void LineManagerEnable()
		{
			lineManager.EnableIfUsed();
		}

		public void Draw3DAuto()
		{
			Draw3DAuto(0f, null);
		}

		public void Draw3DAuto(float time)
		{
			Draw3DAuto(time, null);
		}

		public void Draw3DAuto(Transform thisTransform)
		{
			Draw3DAuto(0f, thisTransform);
		}

		public void Draw3DAuto(float time, Transform thisTransform)
		{
			if (m_1pixelLine)
			{
				Debug.LogWarning("VectorLine: When using a 1 pixel line and useMeshLines=true (or 1 pixel points and useMeshPoints=true), Draw3DAuto is unnecessary. Use Draw3D instead for optimal performance.");
			}
			if (time < 0f)
			{
				time = 0f;
			}
			lineManager.AddLine(this, thisTransform, time);
			m_isAutoDrawing = true;
			Draw3D(thisTransform);
		}

		public void StopDrawing3DAuto()
		{
			lineManager.RemoveLine(this);
			m_isAutoDrawing = false;
		}

		private void WeldJoins(int start, int end, bool connectFirstAndLast)
		{
			if (connectFirstAndLast)
			{
				SetIntersectionPoint(m_vertexCount - 4, m_vertexCount - 2, 0, 2);
				SetIntersectionPoint(m_vertexCount - 3, m_vertexCount - 1, 1, 3);
			}
			for (int i = start; i < end; i += 4)
			{
				SetIntersectionPoint(i - 4, i - 2, i, i + 2);
				SetIntersectionPoint(i - 3, i - 1, i + 1, i + 3);
			}
		}

		private void WeldJoinsDiscrete(int start, int end, bool connectFirstAndLast)
		{
			if (connectFirstAndLast)
			{
				SetIntersectionPoint(m_vertexCount - 4, m_vertexCount - 2, 0, 2);
				SetIntersectionPoint(m_vertexCount - 3, m_vertexCount - 1, 1, 3);
			}
			int num = (start + 1) / 2 * 4;
			if (m_is2D)
			{
				for (int i = start; i < end; i += 2)
				{
					if (points2[i] == points2[i + 1])
					{
						SetIntersectionPoint(num - 4, num - 2, num, num + 2);
						SetIntersectionPoint(num - 3, num - 1, num + 1, num + 3);
					}
					num += 4;
				}
				return;
			}
			for (int j = start; j < end; j += 2)
			{
				if (points3[j] == points3[j + 1])
				{
					SetIntersectionPoint(num - 4, num - 2, num, num + 2);
					SetIntersectionPoint(num - 3, num - 1, num + 1, num + 3);
				}
				num += 4;
			}
		}

		private void SetIntersectionPoint(int p1, int p2, int p3, int p4)
		{
			Vector3 vector = m_lineVertices[p1];
			Vector3 vector2 = m_lineVertices[p2];
			Vector3 vector3 = m_lineVertices[p3];
			Vector3 vector4 = m_lineVertices[p4];
			float num = (vector4.y - vector3.y) * (vector2.x - vector.x) - (vector4.x - vector3.x) * (vector2.y - vector.y);
			if (num != 0f)
			{
				float num2 = ((vector4.x - vector3.x) * (vector.y - vector3.y) - (vector4.y - vector3.y) * (vector.x - vector3.x)) / num;
				v3.x = vector.x + num2 * (vector2.x - vector.x);
				v3.y = vector.y + num2 * (vector2.y - vector.y);
				v3.z = vector.z;
				if (!((v3 - vector2).sqrMagnitude > m_maxWeldDistance))
				{
					m_lineVertices[p2] = v3;
					m_lineVertices[p3] = v3;
				}
			}
		}

		private void WeldJoins3D(int start, int end, bool connectFirstAndLast)
		{
			if (connectFirstAndLast)
			{
				SetIntersectionPoint3D(m_vertexCount - 4, m_vertexCount - 2, 0, 2);
				SetIntersectionPoint3D(m_vertexCount - 3, m_vertexCount - 1, 1, 3);
			}
			for (int i = start; i < end; i += 4)
			{
				SetIntersectionPoint3D(i - 4, i - 2, i, i + 2);
				SetIntersectionPoint3D(i - 3, i - 1, i + 1, i + 3);
			}
		}

		private void WeldJoinsDiscrete3D(int start, int end, bool connectFirstAndLast)
		{
			if (connectFirstAndLast)
			{
				SetIntersectionPoint3D(m_vertexCount - 4, m_vertexCount - 2, 0, 2);
				SetIntersectionPoint3D(m_vertexCount - 3, m_vertexCount - 1, 1, 3);
			}
			int num = (start + 1) / 2 * 4;
			for (int i = start; i < end; i += 2)
			{
				if (points3[i] == points3[i + 1])
				{
					SetIntersectionPoint3D(num - 4, num - 2, num, num + 2);
					SetIntersectionPoint3D(num - 3, num - 1, num + 1, num + 3);
				}
				num += 4;
			}
		}

		private void SetIntersectionPoint3D(int p1, int p2, int p3, int p4)
		{
			Vector3 vector = m_screenPoints[p1];
			Vector3 vector2 = m_screenPoints[p2];
			Vector3 vector3 = m_screenPoints[p3];
			Vector3 vector4 = m_screenPoints[p4];
			float num = (vector4.y - vector3.y) * (vector2.x - vector.x) - (vector4.x - vector3.x) * (vector2.y - vector.y);
			if (num != 0f)
			{
				float num2 = ((vector4.x - vector3.x) * (vector.y - vector3.y) - (vector4.y - vector3.y) * (vector.x - vector3.x)) / num;
				v3.x = vector.x + num2 * (vector2.x - vector.x);
				v3.y = vector.y + num2 * (vector2.y - vector.y);
				v3.z = vector.z;
				if (!((v3 - vector2).sqrMagnitude > m_maxWeldDistance))
				{
					m_lineVertices[p2] = cam3D.ScreenToWorldPoint(v3);
					m_lineVertices[p3] = m_lineVertices[p2];
				}
			}
		}

		public void SetTextureScale(float textureScale)
		{
			SetTextureScale(null, textureScale, 0f);
		}

		public void SetTextureScale(Transform thisTransform, float textureScale)
		{
			SetTextureScale(thisTransform, textureScale, 0f);
		}

		public void SetTextureScale(float textureScale, float offset)
		{
			SetTextureScale(null, textureScale, offset);
		}

		public void SetTextureScale(Transform thisTransform, float textureScale, float offset)
		{
			if (m_1pixelLine)
			{
				return;
			}
			int num = ((!m_continuous) ? pointsLength : (pointsLength - 1));
			int num2 = (m_continuous ? 1 : 2);
			int num3 = 0;
			int num4 = 0;
			widthIdxAdd = ((m_lineWidths.Length != 1) ? 1 : 0);
			float num5 = 1f / textureScale;
			if (m_is2D)
			{
				for (int i = 0; i < num; i += num2)
				{
					float num6 = num5 / (m_lineWidths[num4] * 2f / (points2[i] - points2[i + 1]).magnitude);
					m_lineUVs[num3].x = offset;
					m_lineUVs[num3 + 1].x = offset;
					m_lineUVs[num3 + 2].x = num6 + offset;
					m_lineUVs[num3 + 3].x = num6 + offset;
					num3 += 4;
					offset = (offset + num6) % 1f;
					num4 += widthIdxAdd;
				}
			}
			else
			{
				if (!cam3D)
				{
					SetCamera3D();
					if (!cam3D)
					{
						LogError("VectorLine.SetTextureScale: You must call SetCamera3D before calling SetTextureScale");
						return;
					}
				}
				bool flag = !(thisTransform == null);
				Matrix4x4 matrix4x = ((!flag) ? Matrix4x4.identity : thisTransform.localToWorldMatrix);
				Vector2 zero = Vector2.zero;
				Vector2 zero2 = Vector2.zero;
				for (int j = 0; j < num; j += num2)
				{
					if (flag)
					{
						zero = cam3D.WorldToScreenPoint(matrix4x.MultiplyPoint3x4(points3[j]));
						zero2 = cam3D.WorldToScreenPoint(matrix4x.MultiplyPoint3x4(points3[j + 1]));
					}
					else
					{
						zero = cam3D.WorldToScreenPoint(points3[j]);
						zero2 = cam3D.WorldToScreenPoint(points3[j + 1]);
					}
					float num7 = num5 / (m_lineWidths[num4] * 2f / (zero - zero2).magnitude);
					m_lineUVs[num3].x = offset;
					m_lineUVs[num3 + 1].x = offset;
					m_lineUVs[num3 + 2].x = num7 + offset;
					m_lineUVs[num3 + 3].x = num7 + offset;
					num3 += 4;
					offset = (offset + num7) % 1f;
					num4 += widthIdxAdd;
				}
			}
			m_mesh.uv = m_lineUVs;
		}

		public void ResetTextureScale()
		{
			if (!m_1pixelLine)
			{
				int num = m_lineUVs.Length;
				for (int i = 0; i < num; i += 4)
				{
					m_lineUVs[i].x = 0f;
					m_lineUVs[i + 1].x = 0f;
					m_lineUVs[i + 2].x = 1f;
					m_lineUVs[i + 3].x = 1f;
				}
				m_mesh.uv = m_lineUVs;
			}
		}

		public static void SetDepth(Transform thisTransform, int depth)
		{
			depth = Mathf.Clamp(depth, 0, 100);
			thisTransform.position = new Vector3(thisTransform.position.x, thisTransform.position.y, (!useOrthoCam) ? ((float)(screenHeight / 2) + (100f - (float)depth) * 0.0001f) : ((float)(101 - depth)));
		}

		public static Vector3[] BytesToVector3Array(byte[] lineBytes)
		{
			if (lineBytes.Length % 12 != 0)
			{
				LogError("VectorLine.BytesToVector3Array: Incorrect input byte length...must be a multiple of 12");
				return null;
			}
			SetupByteBlock();
			Vector3[] array = new Vector3[lineBytes.Length / 12];
			int num = 0;
			for (int i = 0; i < lineBytes.Length; i += 12)
			{
				array[num++] = new Vector3(ConvertToFloat(lineBytes, i), ConvertToFloat(lineBytes, i + 4), ConvertToFloat(lineBytes, i + 8));
			}
			return array;
		}

		public static Vector2[] BytesToVector2Array(byte[] lineBytes)
		{
			if (lineBytes.Length % 8 != 0)
			{
				LogError("VectorLine.BytesToVector2Array: Incorrect input byte length...must be a multiple of 8");
				return null;
			}
			SetupByteBlock();
			Vector2[] array = new Vector2[lineBytes.Length / 8];
			int num = 0;
			for (int i = 0; i < lineBytes.Length; i += 8)
			{
				array[num++] = new Vector2(ConvertToFloat(lineBytes, i), ConvertToFloat(lineBytes, i + 4));
			}
			return array;
		}

		private static void SetupByteBlock()
		{
			if (byteBlock == null)
			{
				byteBlock = new byte[4];
			}
			if (BitConverter.IsLittleEndian)
			{
				endianDiff1 = 0;
				endianDiff2 = 0;
			}
			else
			{
				endianDiff1 = 3;
				endianDiff2 = 1;
			}
		}

		private static float ConvertToFloat(byte[] bytes, int i)
		{
			byteBlock[endianDiff1] = bytes[i];
			byteBlock[1 + endianDiff2] = bytes[i + 1];
			byteBlock[2 - endianDiff2] = bytes[i + 2];
			byteBlock[3 - endianDiff1] = bytes[i + 3];
			return BitConverter.ToSingle(byteBlock, 0);
		}

		public static void Destroy(ref VectorLine line)
		{
			if (line != null)
			{
				UnityEngine.Object.Destroy(line.m_mesh);
				UnityEngine.Object.Destroy(line.m_meshFilter);
				UnityEngine.Object.Destroy(line.m_vectorObject);
				if (line.isAutoDrawing)
				{
					line.StopDrawing3DAuto();
				}
				line = null;
			}
		}

		public static void Destroy(ref VectorPoints line)
		{
			if (line != null)
			{
				UnityEngine.Object.Destroy(line.m_mesh);
				UnityEngine.Object.Destroy(line.m_meshFilter);
				UnityEngine.Object.Destroy(line.m_vectorObject);
				if (line.isAutoDrawing)
				{
					line.StopDrawing3DAuto();
				}
				line = null;
			}
		}

		public static void Destroy(ref VectorLine line, GameObject go)
		{
			Destroy(ref line);
			if (go != null)
			{
				UnityEngine.Object.Destroy(go);
			}
		}

		public static void Destroy(ref VectorPoints line, GameObject go)
		{
			Destroy(ref line);
			if (go != null)
			{
				UnityEngine.Object.Destroy(go);
			}
		}

		public void MakeRect(Rect rect)
		{
			MakeRect(new Vector2(rect.x, rect.y), new Vector2(rect.x + rect.width, rect.y - rect.height), 0);
		}

		public void MakeRect(Rect rect, int index)
		{
			MakeRect(new Vector2(rect.x, rect.y), new Vector2(rect.x + rect.width, rect.y - rect.height), index);
		}

		public void MakeRect(Vector3 topLeft, Vector3 bottomRight)
		{
			MakeRect(topLeft, bottomRight, 0);
		}

		public void MakeRect(Vector3 topLeft, Vector3 bottomRight, int index)
		{
			if (m_continuous)
			{
				if (index + 5 > pointsLength)
				{
					if (index == 0)
					{
						LogError("VectorLine.MakeRect: The length of the array for continuous lines needs to be at least 5 for \"" + name + "\"");
						return;
					}
					LogError("Calling VectorLine.MakeRect with an index of " + index + " would exceed the length of the Vector2 array for \"" + name + "\"");
				}
				else if (m_is2D)
				{
					points2[index] = new Vector2(topLeft.x, topLeft.y);
					points2[index + 1] = new Vector2(bottomRight.x, topLeft.y);
					points2[index + 2] = new Vector2(bottomRight.x, bottomRight.y);
					points2[index + 3] = new Vector2(topLeft.x, bottomRight.y);
					points2[index + 4] = new Vector2(topLeft.x, topLeft.y);
				}
				else
				{
					points3[index] = new Vector3(topLeft.x, topLeft.y, topLeft.z);
					points3[index + 1] = new Vector3(bottomRight.x, topLeft.y, topLeft.z);
					points3[index + 2] = new Vector3(bottomRight.x, bottomRight.y, bottomRight.z);
					points3[index + 3] = new Vector3(topLeft.x, bottomRight.y, bottomRight.z);
					points3[index + 4] = new Vector3(topLeft.x, topLeft.y, topLeft.z);
				}
			}
			else if (index + 8 > pointsLength)
			{
				if (index == 0)
				{
					LogError("VectorLine.MakeRect: The length of the array for discrete lines needs to be at least 8 for \"" + name + "\"");
					return;
				}
				LogError("Calling VectorLine.MakeRect with an index of " + index + " would exceed the length of the Vector2 array for \"" + name + "\"");
			}
			else if (m_is2D)
			{
				points2[index] = new Vector2(topLeft.x, topLeft.y);
				points2[index + 1] = new Vector2(bottomRight.x, topLeft.y);
				points2[index + 2] = new Vector2(bottomRight.x, topLeft.y);
				points2[index + 3] = new Vector2(bottomRight.x, bottomRight.y);
				points2[index + 4] = new Vector2(bottomRight.x, bottomRight.y);
				points2[index + 5] = new Vector2(topLeft.x, bottomRight.y);
				points2[index + 6] = new Vector2(topLeft.x, bottomRight.y);
				points2[index + 7] = new Vector2(topLeft.x, topLeft.y);
			}
			else
			{
				points3[index] = new Vector3(topLeft.x, topLeft.y, topLeft.z);
				points3[index + 1] = new Vector3(bottomRight.x, topLeft.y, topLeft.z);
				points3[index + 2] = new Vector3(bottomRight.x, topLeft.y, topLeft.z);
				points3[index + 3] = new Vector3(bottomRight.x, bottomRight.y, bottomRight.z);
				points3[index + 4] = new Vector3(bottomRight.x, bottomRight.y, bottomRight.z);
				points3[index + 5] = new Vector3(topLeft.x, bottomRight.y, bottomRight.z);
				points3[index + 6] = new Vector3(topLeft.x, bottomRight.y, bottomRight.z);
				points3[index + 7] = new Vector3(topLeft.x, topLeft.y, topLeft.z);
			}
		}

		public void MakeCircle(Vector3 origin, float radius)
		{
			MakeEllipse(origin, Vector3.forward, radius, radius, GetSegmentNumber(), 0f, 0);
		}

		public void MakeCircle(Vector3 origin, float radius, int segments)
		{
			MakeEllipse(origin, Vector3.forward, radius, radius, segments, 0f, 0);
		}

		public void MakeCircle(Vector3 origin, float radius, int segments, float pointRotation)
		{
			MakeEllipse(origin, Vector3.forward, radius, radius, segments, pointRotation, 0);
		}

		public void MakeCircle(Vector3 origin, float radius, int segments, int index)
		{
			MakeEllipse(origin, Vector3.forward, radius, radius, segments, 0f, index);
		}

		public void MakeCircle(Vector3 origin, float radius, int segments, float pointRotation, int index)
		{
			MakeEllipse(origin, Vector3.forward, radius, radius, segments, pointRotation, index);
		}

		public void MakeCircle(Vector3 origin, Vector3 upVector, float radius)
		{
			MakeEllipse(origin, upVector, radius, radius, GetSegmentNumber(), 0f, 0);
		}

		public void MakeCircle(Vector3 origin, Vector3 upVector, float radius, int segments)
		{
			MakeEllipse(origin, upVector, radius, radius, segments, 0f, 0);
		}

		public void MakeCircle(Vector3 origin, Vector3 upVector, float radius, int segments, float pointRotation)
		{
			MakeEllipse(origin, upVector, radius, radius, segments, pointRotation, 0);
		}

		public void MakeCircle(Vector3 origin, Vector3 upVector, float radius, int segments, int index)
		{
			MakeEllipse(origin, upVector, radius, radius, segments, 0f, index);
		}

		public void MakeCircle(Vector3 origin, Vector3 upVector, float radius, int segments, float pointRotation, int index)
		{
			MakeEllipse(origin, upVector, radius, radius, segments, pointRotation, index);
		}

		public void MakeEllipse(Vector3 origin, float xRadius, float yRadius)
		{
			MakeEllipse(origin, Vector3.forward, xRadius, yRadius, GetSegmentNumber(), 0f, 0);
		}

		public void MakeEllipse(Vector3 origin, float xRadius, float yRadius, int segments)
		{
			MakeEllipse(origin, Vector3.forward, xRadius, yRadius, segments, 0f, 0);
		}

		public void MakeEllipse(Vector3 origin, float xRadius, float yRadius, int segments, int index)
		{
			MakeEllipse(origin, Vector3.forward, xRadius, yRadius, segments, 0f, index);
		}

		public void MakeEllipse(Vector3 origin, float xRadius, float yRadius, int segments, float pointRotation)
		{
			MakeEllipse(origin, Vector3.forward, xRadius, yRadius, segments, pointRotation, 0);
		}

		public void MakeEllipse(Vector3 origin, Vector3 upVector, float xRadius, float yRadius)
		{
			MakeEllipse(origin, upVector, xRadius, yRadius, GetSegmentNumber(), 0f, 0);
		}

		public void MakeEllipse(Vector3 origin, Vector3 upVector, float xRadius, float yRadius, int segments)
		{
			MakeEllipse(origin, upVector, xRadius, yRadius, segments, 0f, 0);
		}

		public void MakeEllipse(Vector3 origin, Vector3 upVector, float xRadius, float yRadius, int segments, int index)
		{
			MakeEllipse(origin, upVector, xRadius, yRadius, segments, 0f, index);
		}

		public void MakeEllipse(Vector3 origin, Vector3 upVector, float xRadius, float yRadius, int segments, float pointRotation)
		{
			MakeEllipse(origin, upVector, xRadius, yRadius, segments, pointRotation, 0);
		}

		public void MakeEllipse(Vector3 origin, Vector3 upVector, float xRadius, float yRadius, int segments, float pointRotation, int index)
		{
			if (segments < 3)
			{
				LogError("VectorLine.MakeEllipse needs at least 3 segments");
			}
			else
			{
				if (!CheckArrayLength(FunctionName.MakeEllipse, segments, index))
				{
					return;
				}
				float num = 360f / (float)segments * ((float)Math.PI / 180f);
				float num2 = (0f - pointRotation) * ((float)Math.PI / 180f);
				if (m_continuous)
				{
					int num3 = 0;
					if (m_is2D)
					{
						Vector2 vector = origin;
						for (num3 = 0; num3 < segments; num3++)
						{
							points2[index + num3] = vector + new Vector2(0.5f + Mathf.Cos(num2) * xRadius, 0.5f + Mathf.Sin(num2) * yRadius);
							num2 += num;
						}
						if (!m_isPoints)
						{
							points2[index + num3] = points2[index + (num3 - segments)];
						}
					}
					else
					{
						Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.zero, Quaternion.LookRotation(-upVector, upVector), Vector3.one);
						for (num3 = 0; num3 < segments; num3++)
						{
							points3[index + num3] = origin + matrix4x.MultiplyPoint3x4(new Vector3(Mathf.Cos(num2) * xRadius, Mathf.Sin(num2) * yRadius, 0f));
							num2 += num;
						}
						if (!m_isPoints)
						{
							points3[index + num3] = points3[index + (num3 - segments)];
						}
					}
				}
				else if (m_is2D)
				{
					Vector2 vector2 = origin;
					int num4;
					for (num4 = 0; num4 < segments * 2; num4++)
					{
						points2[index + num4] = vector2 + new Vector2(0.5f + Mathf.Cos(num2) * xRadius, 0.5f + Mathf.Sin(num2) * yRadius);
						num2 += num;
						num4++;
						points2[index + num4] = vector2 + new Vector2(0.5f + Mathf.Cos(num2) * xRadius, 0.5f + Mathf.Sin(num2) * yRadius);
					}
				}
				else
				{
					Matrix4x4 matrix4x2 = Matrix4x4.TRS(Vector3.zero, Quaternion.LookRotation(-upVector, upVector), Vector3.one);
					int num5;
					for (num5 = 0; num5 < segments * 2; num5++)
					{
						points3[index + num5] = origin + matrix4x2.MultiplyPoint3x4(new Vector3(Mathf.Cos(num2) * xRadius, Mathf.Sin(num2) * yRadius, 0f));
						num2 += num;
						num5++;
						points3[index + num5] = origin + matrix4x2.MultiplyPoint3x4(new Vector3(Mathf.Cos(num2) * xRadius, Mathf.Sin(num2) * yRadius, 0f));
					}
				}
			}
		}

		public void MakeCurve(Vector2[] curvePoints)
		{
			MakeCurve(curvePoints, GetSegmentNumber(), 0);
		}

		public void MakeCurve(Vector2[] curvePoints, int segments)
		{
			MakeCurve(curvePoints, segments, 0);
		}

		public void MakeCurve(Vector2[] curvePoints, int segments, int index)
		{
			if (curvePoints.Length != 4)
			{
				LogError("VectorLine.MakeCurve needs exactly 4 points in the curve points array");
			}
			else
			{
				MakeCurve(curvePoints[0], curvePoints[1], curvePoints[2], curvePoints[3], segments, index);
			}
		}

		public void MakeCurve(Vector3[] curvePoints)
		{
			MakeCurve(curvePoints, GetSegmentNumber(), 0);
		}

		public void MakeCurve(Vector3[] curvePoints, int segments)
		{
			MakeCurve(curvePoints, segments, 0);
		}

		public void MakeCurve(Vector3[] curvePoints, int segments, int index)
		{
			if (curvePoints.Length != 4)
			{
				LogError("VectorLine.MakeCurve needs exactly 4 points in the curve points array");
			}
			else
			{
				MakeCurve(curvePoints[0], curvePoints[1], curvePoints[2], curvePoints[3], segments, index);
			}
		}

		public void MakeCurve(Vector3 anchor1, Vector3 control1, Vector3 anchor2, Vector3 control2)
		{
			MakeCurve(anchor1, control1, anchor2, control2, GetSegmentNumber(), 0);
		}

		public void MakeCurve(Vector3 anchor1, Vector3 control1, Vector3 anchor2, Vector3 control2, int segments)
		{
			MakeCurve(anchor1, control1, anchor2, control2, segments, 0);
		}

		public void MakeCurve(Vector3 anchor1, Vector3 control1, Vector3 anchor2, Vector3 control2, int segments, int index)
		{
			if (!CheckArrayLength(FunctionName.MakeCurve, segments, index))
			{
				return;
			}
			if (m_continuous)
			{
				int num = ((!m_isPoints) ? (segments + 1) : segments);
				if (m_is2D)
				{
					Vector2 anchor3 = anchor1;
					Vector2 anchor4 = anchor2;
					Vector2 control3 = control1;
					Vector2 control4 = control2;
					for (int i = 0; i < num; i++)
					{
						points2[index + i] = GetBezierPoint(ref anchor3, ref control3, ref anchor4, ref control4, (float)i / (float)segments);
					}
				}
				else
				{
					for (int j = 0; j < num; j++)
					{
						points3[index + j] = GetBezierPoint3D(ref anchor1, ref control1, ref anchor2, ref control2, (float)j / (float)segments);
					}
				}
				return;
			}
			int num2 = 0;
			if (m_is2D)
			{
				Vector2 anchor5 = anchor1;
				Vector2 anchor6 = anchor2;
				Vector2 control5 = control1;
				Vector2 control6 = control2;
				for (int k = 0; k < segments; k++)
				{
					points2[index + num2++] = GetBezierPoint(ref anchor5, ref control5, ref anchor6, ref control6, (float)k / (float)segments);
					points2[index + num2++] = GetBezierPoint(ref anchor5, ref control5, ref anchor6, ref control6, (float)(k + 1) / (float)segments);
				}
			}
			else
			{
				for (int l = 0; l < segments; l++)
				{
					points3[index + num2++] = GetBezierPoint3D(ref anchor1, ref control1, ref anchor2, ref control2, (float)l / (float)segments);
					points3[index + num2++] = GetBezierPoint3D(ref anchor1, ref control1, ref anchor2, ref control2, (float)(l + 1) / (float)segments);
				}
			}
		}

		private static Vector2 GetBezierPoint(ref Vector2 anchor1, ref Vector2 control1, ref Vector2 anchor2, ref Vector2 control2, float t)
		{
			float num = 3f * (control1.x - anchor1.x);
			float num2 = 3f * (control2.x - control1.x) - num;
			float num3 = anchor2.x - anchor1.x - num - num2;
			float num4 = 3f * (control1.y - anchor1.y);
			float num5 = 3f * (control2.y - control1.y) - num4;
			float num6 = anchor2.y - anchor1.y - num4 - num5;
			return new Vector2(num3 * (t * t * t) + num2 * (t * t) + num * t + anchor1.x, num6 * (t * t * t) + num5 * (t * t) + num4 * t + anchor1.y);
		}

		private static Vector3 GetBezierPoint3D(ref Vector3 anchor1, ref Vector3 control1, ref Vector3 anchor2, ref Vector3 control2, float t)
		{
			float num = 3f * (control1.x - anchor1.x);
			float num2 = 3f * (control2.x - control1.x) - num;
			float num3 = anchor2.x - anchor1.x - num - num2;
			float num4 = 3f * (control1.y - anchor1.y);
			float num5 = 3f * (control2.y - control1.y) - num4;
			float num6 = anchor2.y - anchor1.y - num4 - num5;
			float num7 = 3f * (control1.z - anchor1.z);
			float num8 = 3f * (control2.z - control1.z) - num7;
			float num9 = anchor2.z - anchor1.z - num7 - num8;
			return new Vector3(num3 * (t * t * t) + num2 * (t * t) + num * t + anchor1.x, num6 * (t * t * t) + num5 * (t * t) + num4 * t + anchor1.y, num9 * (t * t * t) + num8 * (t * t) + num7 * t + anchor1.z);
		}

		public void MakeSpline(Vector2[] splinePoints)
		{
			MakeSpline(splinePoints, null, GetSegmentNumber(), 0, false);
		}

		public void MakeSpline(Vector2[] splinePoints, bool loop)
		{
			MakeSpline(splinePoints, null, GetSegmentNumber(), 0, loop);
		}

		public void MakeSpline(Vector2[] splinePoints, int segments)
		{
			MakeSpline(splinePoints, null, segments, 0, false);
		}

		public void MakeSpline(Vector2[] splinePoints, int segments, bool loop)
		{
			MakeSpline(splinePoints, null, segments, 0, loop);
		}

		public void MakeSpline(Vector2[] splinePoints, int segments, int index)
		{
			MakeSpline(splinePoints, null, segments, index, false);
		}

		public void MakeSpline(Vector2[] splinePoints, int segments, int index, bool loop)
		{
			MakeSpline(splinePoints, null, segments, index, loop);
		}

		public void MakeSpline(Vector3[] splinePoints)
		{
			MakeSpline(null, splinePoints, GetSegmentNumber(), 0, false);
		}

		public void MakeSpline(Vector3[] splinePoints, bool loop)
		{
			MakeSpline(null, splinePoints, GetSegmentNumber(), 0, loop);
		}

		public void MakeSpline(Vector3[] splinePoints, int segments)
		{
			MakeSpline(null, splinePoints, segments, 0, false);
		}

		public void MakeSpline(Vector3[] splinePoints, int segments, bool loop)
		{
			MakeSpline(null, splinePoints, segments, 0, loop);
		}

		public void MakeSpline(Vector3[] splinePoints, int segments, int index)
		{
			MakeSpline(null, splinePoints, segments, index, false);
		}

		public void MakeSpline(Vector3[] splinePoints, int segments, int index, bool loop)
		{
			MakeSpline(null, splinePoints, segments, index, loop);
		}

		private void MakeSpline(Vector2[] splinePoints2, Vector3[] splinePoints3, int segments, int index, bool loop)
		{
			int num = ((splinePoints2 == null) ? splinePoints3.Length : splinePoints2.Length);
			if (num < 2)
			{
				LogError("VectorLine.MakeSpline needs at least 2 spline points");
			}
			else if (splinePoints2 != null && !m_is2D)
			{
				LogError("VectorLine.MakeSpline was called with a Vector2 spline points array, but the line uses Vector3 points");
			}
			else if (splinePoints3 != null && m_is2D)
			{
				LogError("VectorLine.MakeSpline was called with a Vector3 spline points array, but the line uses Vector2 points");
			}
			else
			{
				if (!CheckArrayLength(FunctionName.MakeSpline, segments, index))
				{
					return;
				}
				int num2 = index;
				int num3 = ((!loop) ? (num - 1) : num);
				float num4 = 1f / (float)segments * (float)num3;
				float num5 = 0f;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				int i;
				for (i = 0; i < num3; i++)
				{
					num6 = i - 1;
					num7 = i + 1;
					num8 = i + 2;
					if (num6 < 0)
					{
						num6 = (loop ? (num3 - 1) : 0);
					}
					if (loop && num7 > num3 - 1)
					{
						num7 -= num3;
					}
					if (num8 > num3 - 1)
					{
						num8 = ((!loop) ? num3 : (num8 - num3));
					}
					float num9;
					if (m_continuous)
					{
						if (m_is2D)
						{
							for (num9 = num5; num9 <= 1f; num9 += num4)
							{
								points2[num2++] = GetSplinePoint(ref splinePoints2[num6], ref splinePoints2[i], ref splinePoints2[num7], ref splinePoints2[num8], num9);
							}
						}
						else
						{
							for (num9 = num5; num9 <= 1f; num9 += num4)
							{
								points3[num2++] = GetSplinePoint3D(ref splinePoints3[num6], ref splinePoints3[i], ref splinePoints3[num7], ref splinePoints3[num8], num9);
							}
						}
					}
					else if (m_is2D)
					{
						for (num9 = num5; num9 <= 1f; num9 += num4)
						{
							points2[num2++] = GetSplinePoint(ref splinePoints2[num6], ref splinePoints2[i], ref splinePoints2[num7], ref splinePoints2[num8], num9);
							if (num2 > index + 1 && num2 < index + segments * 2)
							{
								points2[num2++] = points2[num2 - 2];
							}
						}
					}
					else
					{
						for (num9 = num5; num9 <= 1f; num9 += num4)
						{
							points3[num2++] = GetSplinePoint3D(ref splinePoints3[num6], ref splinePoints3[i], ref splinePoints3[num7], ref splinePoints3[num8], num9);
							if (num2 > index + 1 && num2 < index + segments * 2)
							{
								points3[num2++] = points3[num2 - 2];
							}
						}
					}
					num5 = num9 - 1f;
				}
				if ((m_continuous && num2 < index + (segments + 1)) || (!m_continuous && num2 < index + segments * 2))
				{
					if (m_is2D)
					{
						points2[num2] = GetSplinePoint(ref splinePoints2[num6], ref splinePoints2[i - 1], ref splinePoints2[num7], ref splinePoints2[num8], 1f);
					}
					else
					{
						points3[num2] = GetSplinePoint3D(ref splinePoints3[num6], ref splinePoints3[i - 1], ref splinePoints3[num7], ref splinePoints3[num8], 1f);
					}
				}
			}
		}

		private static Vector2 GetSplinePoint(ref Vector2 p0, ref Vector2 p1, ref Vector2 p2, ref Vector2 p3, float t)
		{
			float num = t * t;
			float num2 = num * t;
			return new Vector2(0.5f * (2f * p1.x + (0f - p0.x + p2.x) * t + (2f * p0.x - 5f * p1.x + 4f * p2.x - p3.x) * num + (0f - p0.x + 3f * p1.x - 3f * p2.x + p3.x) * num2), 0.5f * (2f * p1.y + (0f - p0.y + p2.y) * t + (2f * p0.y - 5f * p1.y + 4f * p2.y - p3.y) * num + (0f - p0.y + 3f * p1.y - 3f * p2.y + p3.y) * num2));
		}

		private static Vector3 GetSplinePoint3D(ref Vector3 p0, ref Vector3 p1, ref Vector3 p2, ref Vector3 p3, float t)
		{
			float num = t * t;
			float num2 = num * t;
			return new Vector3(0.5f * (2f * p1.x + (0f - p0.x + p2.x) * t + (2f * p0.x - 5f * p1.x + 4f * p2.x - p3.x) * num + (0f - p0.x + 3f * p1.x - 3f * p2.x + p3.x) * num2), 0.5f * (2f * p1.y + (0f - p0.y + p2.y) * t + (2f * p0.y - 5f * p1.y + 4f * p2.y - p3.y) * num + (0f - p0.y + 3f * p1.y - 3f * p2.y + p3.y) * num2), 0.5f * (2f * p1.z + (0f - p0.z + p2.z) * t + (2f * p0.z - 5f * p1.z + 4f * p2.z - p3.z) * num + (0f - p0.z + 3f * p1.z - 3f * p2.z + p3.z) * num2));
		}

		public void MakeText(string text, Vector3 startPos, float size)
		{
			MakeText(text, startPos, size, 1f, 1.5f, true);
		}

		public void MakeText(string text, Vector3 startPos, float size, bool uppercaseOnly)
		{
			MakeText(text, startPos, size, 1f, 1.5f, uppercaseOnly);
		}

		public void MakeText(string text, Vector3 startPos, float size, float charSpacing, float lineSpacing)
		{
			MakeText(text, startPos, size, charSpacing, lineSpacing, true);
		}

		public void MakeText(string text, Vector3 startPos, float size, float charSpacing, float lineSpacing, bool uppercaseOnly)
		{
			if (m_continuous)
			{
				LogError("VectorLine.MakeText can only be used with a discrete line");
				return;
			}
			int num = 0;
			for (int i = 0; i < text.Length; i++)
			{
				int num2 = Convert.ToInt32(text[i]);
				if (num2 < 0 || num2 > 256)
				{
					LogError("VectorLine.MakeText: Character '" + text[i] + "' is not valid");
					return;
				}
				if (uppercaseOnly && num2 >= 97 && num2 <= 122)
				{
					num2 -= 32;
				}
				if (VectorChar.data[num2] != null)
				{
					num += VectorChar.data[num2].Length;
				}
			}
			if (num > pointsLength)
			{
				Resize(num);
			}
			else if (num < pointsLength)
			{
				ZeroPoints(num);
			}
			float num3 = 0f;
			float num4 = 0f;
			int num5 = 0;
			Vector2 vector = new Vector2(size, size);
			for (int j = 0; j < text.Length; j++)
			{
				int num6 = Convert.ToInt32(text[j]);
				switch (num6)
				{
				case 10:
					num4 -= lineSpacing;
					num3 = 0f;
					continue;
				case 32:
					num3 += charSpacing;
					continue;
				}
				if (uppercaseOnly && num6 >= 97 && num6 <= 122)
				{
					num6 -= 32;
				}
				int num7 = 0;
				if (VectorChar.data[num6] != null)
				{
					num7 = VectorChar.data[num6].Length;
					if (m_is2D)
					{
						for (int k = 0; k < num7; k++)
						{
							points2[num5++] = Vector2.Scale(VectorChar.data[num6][k] + new Vector2(num3, num4), vector) + (Vector2)startPos;
						}
					}
					else
					{
						for (int l = 0; l < num7; l++)
						{
							points3[num5++] = Vector3.Scale((Vector3)VectorChar.data[num6][l] + new Vector3(num3, num4, 0f), vector) + startPos;
						}
					}
					num3 += charSpacing;
				}
				else
				{
					num3 += charSpacing;
				}
			}
		}

		public void MakeWireframe(Mesh mesh)
		{
			if (m_continuous)
			{
				LogError("VectorLine.MakeWireframe only works with a discrete line");
				return;
			}
			if (m_is2D)
			{
				LogError("VectorLine.MakeWireframe can only be used with a Vector3 array, which \"" + name + "\" doesn't have");
				return;
			}
			if (mesh == null)
			{
				LogError("VectorLine.MakeWireframe can't use a null mesh");
				return;
			}
			int[] triangles = mesh.triangles;
			Vector3[] vertices = mesh.vertices;
			Dictionary<Vector3Pair, bool> pairs = new Dictionary<Vector3Pair, bool>();
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < triangles.Length; i += 3)
			{
				CheckPairPoints(pairs, vertices[triangles[i]], vertices[triangles[i + 1]], list);
				CheckPairPoints(pairs, vertices[triangles[i + 1]], vertices[triangles[i + 2]], list);
				CheckPairPoints(pairs, vertices[triangles[i + 2]], vertices[triangles[i]], list);
			}
			if (list.Count > points3.Length)
			{
				Array.Resize(ref points3, list.Count);
				Resize(list.Count);
			}
			else if (list.Count < points3.Length)
			{
				ZeroPoints(list.Count);
			}
			Array.Copy(list.ToArray(), points3, list.Count);
		}

		private static void CheckPairPoints(Dictionary<Vector3Pair, bool> pairs, Vector3 p1, Vector3 p2, List<Vector3> linePoints)
		{
			Vector3Pair key = new Vector3Pair(p1, p2);
			Vector3Pair key2 = new Vector3Pair(p2, p1);
			if (!pairs.ContainsKey(key) && !pairs.ContainsKey(key2))
			{
				pairs[key] = true;
				pairs[key2] = true;
				linePoints.Add(p1);
				linePoints.Add(p2);
			}
		}

		public void MakeCube(Vector3 position, float xSize, float ySize, float zSize)
		{
			MakeCube(position, xSize, ySize, zSize, 0);
		}

		public void MakeCube(Vector3 position, float xSize, float ySize, float zSize, int index)
		{
			if (m_continuous)
			{
				LogError("VectorLine.MakeCube only works with a discrete line");
				return;
			}
			if (m_is2D)
			{
				LogError("VectorLine.MakeCube can only be used with a Vector3 array, which \"" + name + "\" doesn't have");
				return;
			}
			if (index + 24 > points3.Length)
			{
				if (index == 0)
				{
					LogError("VectorLine.MakeCube: The length of the Vector3 array needs to be at least 24 for \"" + name + "\"");
					return;
				}
				LogError("Calling VectorLine.MakeCube with an index of " + index + " would exceed the length of the Vector3 array for \"" + name + "\"");
				return;
			}
			xSize /= 2f;
			ySize /= 2f;
			zSize /= 2f;
			points3[index] = position + new Vector3(0f - xSize, ySize, 0f - zSize);
			points3[index + 1] = position + new Vector3(xSize, ySize, 0f - zSize);
			points3[index + 2] = position + new Vector3(xSize, ySize, 0f - zSize);
			points3[index + 3] = position + new Vector3(xSize, ySize, zSize);
			points3[index + 4] = position + new Vector3(xSize, ySize, zSize);
			points3[index + 5] = position + new Vector3(0f - xSize, ySize, zSize);
			points3[index + 6] = position + new Vector3(0f - xSize, ySize, zSize);
			points3[index + 7] = position + new Vector3(0f - xSize, ySize, 0f - zSize);
			points3[index + 8] = position + new Vector3(0f - xSize, 0f - ySize, 0f - zSize);
			points3[index + 9] = position + new Vector3(0f - xSize, ySize, 0f - zSize);
			points3[index + 10] = position + new Vector3(xSize, 0f - ySize, 0f - zSize);
			points3[index + 11] = position + new Vector3(xSize, ySize, 0f - zSize);
			points3[index + 12] = position + new Vector3(0f - xSize, 0f - ySize, zSize);
			points3[index + 13] = position + new Vector3(0f - xSize, ySize, zSize);
			points3[index + 14] = position + new Vector3(xSize, 0f - ySize, zSize);
			points3[index + 15] = position + new Vector3(xSize, ySize, zSize);
			points3[index + 16] = position + new Vector3(0f - xSize, 0f - ySize, 0f - zSize);
			points3[index + 17] = position + new Vector3(xSize, 0f - ySize, 0f - zSize);
			points3[index + 18] = position + new Vector3(xSize, 0f - ySize, 0f - zSize);
			points3[index + 19] = position + new Vector3(xSize, 0f - ySize, zSize);
			points3[index + 20] = position + new Vector3(xSize, 0f - ySize, zSize);
			points3[index + 21] = position + new Vector3(0f - xSize, 0f - ySize, zSize);
			points3[index + 22] = position + new Vector3(0f - xSize, 0f - ySize, zSize);
			points3[index + 23] = position + new Vector3(0f - xSize, 0f - ySize, 0f - zSize);
		}

		public void SetDistances()
		{
			if (m_distances == null || m_distances.Length != ((!m_continuous) ? (m_pointsLength / 2 + 1) : m_pointsLength))
			{
				m_distances = new float[(!m_continuous) ? (m_pointsLength / 2 + 1) : m_pointsLength];
			}
			double num = 0.0;
			int num2 = pointsLength - 1;
			if (points3 != null)
			{
				if (m_continuous)
				{
					for (int i = 0; i < num2; i++)
					{
						Vector3 vector = points3[i] - points3[i + 1];
						num += Math.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
						m_distances[i + 1] = (float)num;
					}
					return;
				}
				int num3 = 1;
				for (int j = 0; j < num2; j += 2)
				{
					Vector3 vector2 = points3[j] - points3[j + 1];
					num += Math.Sqrt(vector2.x * vector2.x + vector2.y * vector2.y + vector2.z * vector2.z);
					m_distances[num3++] = (float)num;
				}
			}
			else if (m_continuous)
			{
				for (int k = 0; k < num2; k++)
				{
					Vector2 vector3 = points2[k] - points2[k + 1];
					num += Math.Sqrt(vector3.x * vector3.x + vector3.y * vector3.y);
					m_distances[k + 1] = (float)num;
				}
			}
			else
			{
				int num4 = 1;
				for (int l = 0; l < num2; l += 2)
				{
					Vector2 vector4 = points2[l] - points2[l + 1];
					num += Math.Sqrt(vector4.x * vector4.x + vector4.y * vector4.y);
					m_distances[num4++] = (float)num;
				}
			}
		}

		public float GetLength()
		{
			if (m_distances == null || m_distances.Length != ((!m_continuous) ? (pointsLength / 2 + 1) : pointsLength))
			{
				SetDistances();
			}
			return m_distances[m_distances.Length - 1];
		}

		public Vector2 GetPoint01(float distance)
		{
			return GetPoint(Mathf.Lerp(0f, GetLength(), distance));
		}

		public Vector2 GetPoint(float distance)
		{
			if (!m_is2D)
			{
				LogError("VectorLine.GetPoint only works with Vector2 points");
				return Vector2.zero;
			}
			if (points2.Length < 2)
			{
				LogError("VectorLine.GetPoint needs at least 2 points in the points2 array");
				return Vector2.zero;
			}
			if (m_distances == null)
			{
				SetDistances();
			}
			int i = m_drawStart + 1;
			if (!m_continuous)
			{
				i++;
				i /= 2;
			}
			if (i >= m_distances.Length)
			{
				i = m_distances.Length - 1;
			}
			for (int num = ((!m_continuous) ? ((m_drawEnd + 1) / 2) : m_drawEnd); distance > m_distances[i] && i < num; i++)
			{
			}
			if (m_continuous)
			{
				return Vector2.Lerp(points2[i - 1], points2[i], Mathf.InverseLerp(m_distances[i - 1], m_distances[i], distance));
			}
			return Vector2.Lerp(points2[(i - 1) * 2], points2[(i - 1) * 2 + 1], Mathf.InverseLerp(m_distances[i - 1], m_distances[i], distance));
		}

		public Vector3 GetPoint3D01(float distance)
		{
			return GetPoint3D(Mathf.Lerp(0f, GetLength(), distance));
		}

		public Vector3 GetPoint3D(float distance)
		{
			if (m_is2D)
			{
				LogError("VectorLine.GetPoint3D only works with Vector3 points");
				return Vector3.zero;
			}
			if (points3.Length < 2)
			{
				LogError("VectorLine.GetPoint3D needs at least 2 points in the points3 array");
				return Vector3.zero;
			}
			if (m_distances == null)
			{
				SetDistances();
			}
			int i = m_drawStart + 1;
			if (!m_continuous)
			{
				i++;
				i /= 2;
			}
			if (i >= m_distances.Length)
			{
				i = m_distances.Length - 1;
			}
			for (int num = ((!m_continuous) ? ((m_drawEnd + 1) / 2) : m_drawEnd); distance > m_distances[i] && i < num; i++)
			{
			}
			if (m_continuous)
			{
				return Vector3.Lerp(points3[i - 1], points3[i], Mathf.InverseLerp(m_distances[i - 1], m_distances[i], distance));
			}
			return Vector3.Lerp(points3[(i - 1) * 2], points3[(i - 1) * 2 + 1], Mathf.InverseLerp(m_distances[i - 1], m_distances[i], distance));
		}

		public static void SetEndCap(string name, EndCap capType)
		{
			SetEndCap(name, capType, (Material)null, (Texture2D[])null);
		}

		public static void SetEndCap(string name, EndCap capType, Material material, params Texture2D[] textures)
		{
			if (capDictionary == null)
			{
				capDictionary = new Dictionary<string, CapInfo>();
			}
			if (name == null || name == "")
			{
				LogError("VectorLine: must supply a name for SetEndCap");
				return;
			}
			if (capDictionary.ContainsKey(name) && capType != EndCap.None)
			{
				LogError("VectorLine: end cap \"" + name + "\" has already been set up");
				return;
			}
			if (capType == EndCap.Both)
			{
				if (textures.Length < 2)
				{
					LogError("VectorLine: must supply two textures when using SetEndCap with EndCap.Both");
					return;
				}
				if (textures[0].width != textures[1].width || textures[0].height != textures[1].height)
				{
					LogError("VectorLine: when using SetEndCap with EndCap.Both, both textures must have the same width and height");
					return;
				}
			}
			if ((capType == EndCap.Front || capType == EndCap.Back || capType == EndCap.Mirror) && textures.Length < 1)
			{
				LogError("VectorLine: must supply a texture when using SetEndCap with EndCap.Front, EndCap.Back, or EndCap.Mirror");
				return;
			}
			if (capType == EndCap.None)
			{
				if (capDictionary.ContainsKey(name))
				{
					RemoveEndCap(name);
				}
				return;
			}
			if (material == null)
			{
				LogError("VectorLine: must supply a material when using SetEndCap with any EndCap type except EndCap.None");
				return;
			}
			if (!material.HasProperty("_MainTex"))
			{
				LogError("VectorLine: the material supplied when using SetEndCap must contain a shader that has a \"_MainTex\" property");
				return;
			}
			int width = textures[0].width;
			int height = textures[0].height;
			float num = 0f;
			float ratio = 0f;
			Color[] colors = null;
			Color[] colors2 = null;
			switch (capType)
			{
			case EndCap.Front:
				colors = textures[0].GetPixels();
				colors2 = new Color[width * height];
				num = (float)textures[0].width / (float)textures[0].height;
				break;
			case EndCap.Back:
				colors = new Color[width * height];
				colors2 = textures[0].GetPixels();
				ratio = (float)textures[0].width / (float)textures[0].height;
				break;
			case EndCap.Both:
				colors = textures[0].GetPixels();
				colors2 = textures[1].GetPixels();
				num = (float)textures[0].width / (float)textures[0].height;
				ratio = (float)textures[1].width / (float)textures[1].height;
				break;
			case EndCap.Mirror:
				colors = textures[0].GetPixels();
				colors2 = new Color[width * height];
				num = (float)textures[0].width / (float)textures[0].height;
				ratio = num;
				break;
			}
			Texture2D texture2D = new Texture2D(width, height * 4, TextureFormat.ARGB32, false);
			texture2D.wrapMode = TextureWrapMode.Clamp;
			texture2D.filterMode = textures[0].filterMode;
			texture2D.SetPixels(0, 0, width, height, colors);
			texture2D.SetPixels(0, height * 3, width, height, colors2);
			texture2D.SetPixels(0, height, width, height * 2, new Color[width * (height * 2)]);
			texture2D.Apply(false, true);
			Material material2 = (Material)UnityEngine.Object.Instantiate((UnityEngine.Object)material);
			material2.name = material.name + " EndCap";
			material2.mainTexture = texture2D;
			capDictionary.Add(name, new CapInfo(capType, material2, texture2D, num, ratio));
		}

		public static void RemoveEndCap(string name)
		{
			if (!capDictionary.ContainsKey(name))
			{
				LogError("VectorLine: RemoveEndCap: \"" + name + "\" has not been set up");
				return;
			}
			UnityEngine.Object.Destroy(capDictionary[name].texture);
			UnityEngine.Object.Destroy(capDictionary[name].material);
			capDictionary.Remove(name);
		}

		public void ZeroPoints()
		{
			ZeroPoints(0, m_pointsLength);
		}

		public void ZeroPoints(int startIndex)
		{
			ZeroPoints(startIndex, m_pointsLength);
		}

		public void ZeroPoints(int startIndex, int endIndex)
		{
			if (endIndex < 0 || endIndex > pointsLength || startIndex < 0 || startIndex > pointsLength || startIndex > endIndex)
			{
				LogError("VectorLine: index out of range for \"" + name + "\" when calling ZeroPoints. StartIndex: " + startIndex + ", EndIndex: " + endIndex + ", array length: " + m_pointsLength);
			}
			else if (m_is2D)
			{
				Vector2 zero = Vector2.zero;
				for (int i = startIndex; i < endIndex; i++)
				{
					points2[i] = zero;
				}
			}
			else
			{
				Vector3 zero2 = Vector3.zero;
				for (int j = startIndex; j < endIndex; j++)
				{
					points3[j] = zero2;
				}
			}
		}

		private void ZeroVertices(int startIndex, int endIndex)
		{
			Vector3 zero = Vector3.zero;
			if (m_1pixelLine)
			{
				for (int i = startIndex; i < endIndex; i++)
				{
					m_lineVertices[i] = zero;
				}
			}
			else if (m_continuous)
			{
				startIndex *= 4;
				endIndex *= 4;
				if (endIndex > m_vertexCount)
				{
					endIndex -= 4;
				}
				for (int j = startIndex; j < endIndex; j += 4)
				{
					m_lineVertices[j] = zero;
					m_lineVertices[j + 1] = zero;
					m_lineVertices[j + 2] = zero;
					m_lineVertices[j + 3] = zero;
				}
			}
			else
			{
				startIndex *= 2;
				endIndex *= 2;
				for (int k = startIndex; k < endIndex; k += 2)
				{
					m_lineVertices[k] = zero;
					m_lineVertices[k + 1] = zero;
				}
			}
		}

		public bool Selected(Vector2 p)
		{
			int index;
			return Selected(p, 0, out index);
		}

		public bool Selected(Vector2 p, out int index)
		{
			return Selected(p, 0, out index);
		}

		public bool Selected(Vector2 p, int extraDistance, out int index)
		{
			int num = ((m_lineWidths.Length != 1) ? 1 : 0);
			int num2 = ((!m_continuous) ? (m_drawStart / 2 - num) : (m_drawStart - num));
			int num3 = m_drawEnd;
			bool flag = !(m_useTransform == null);
			Matrix4x4 matrix4x = ((!flag) ? Matrix4x4.identity : m_useTransform.localToWorldMatrix);
			if (m_isPoints)
			{
				if (num3 == pointsLength)
				{
					num3--;
				}
				if (m_is2D)
				{
					for (int i = m_drawStart; i <= num3; i++)
					{
						num2 += num;
						float num4 = m_lineWidths[num2] + (float)extraDistance;
						Vector2 vector = ((!flag) ? points2[i] : ((Vector2)matrix4x.MultiplyPoint3x4(points2[i])));
						if (p.x >= vector.x - num4 && p.x <= vector.x + num4 && p.y >= vector.y - num4 && p.y <= vector.y + num4)
						{
							index = i;
							return true;
						}
					}
					index = -1;
					return false;
				}
				for (int j = m_drawStart; j <= num3; j++)
				{
					num2 += num;
					float num5 = m_lineWidths[num2] + (float)extraDistance;
					Vector2 vector = ((!flag) ? cam3D.WorldToScreenPoint(points3[j]) : cam3D.WorldToScreenPoint(matrix4x.MultiplyPoint3x4(points3[j])));
					if (p.x >= vector.x - num5 && p.x <= vector.x + num5 && p.y >= vector.y - num5 && p.y <= vector.y + num5)
					{
						index = j;
						return true;
					}
				}
				index = -1;
				return false;
			}
			float num6 = 0f;
			int num7 = (m_continuous ? 1 : 2);
			Vector2 zero = Vector2.zero;
			if (m_continuous && m_drawEnd == pointsLength)
			{
				num3--;
			}
			Vector2 vector2 = default(Vector2);
			if (m_is2D)
			{
				for (int k = m_drawStart; k < num3; k += num7)
				{
					num2 += num;
					if (points2[k].x != points2[k + 1].x || points2[k].y != points2[k + 1].y)
					{
						if (flag)
						{
							vector2 = matrix4x.MultiplyPoint3x4(points2[k]);
							zero = matrix4x.MultiplyPoint3x4(points2[k + 1]);
						}
						else
						{
							vector2 = points2[k];
							zero = points2[k + 1];
						}
						num6 = Vector2.Dot(p - vector2, zero - vector2) / (zero - vector2).sqrMagnitude;
						if (!(num6 < 0f) && !(num6 > 1f) && (p - (vector2 + num6 * (zero - vector2))).sqrMagnitude <= (m_lineWidths[num2] + (float)extraDistance) * (m_lineWidths[num2] + (float)extraDistance))
						{
							index = ((!m_continuous) ? (k / 2) : k);
							return true;
						}
					}
				}
				index = -1;
				return false;
			}
			Vector3 zero2 = Vector3.zero;
			for (int l = m_drawStart; l < num3; l += num7)
			{
				num2 += num;
				if (points3[l].x == points3[l + 1].x && points3[l].y == points3[l + 1].y && points3[l].z == points3[l + 1].z)
				{
					continue;
				}
				Vector3 vector3;
				if (flag)
				{
					vector3 = cam3D.WorldToScreenPoint(matrix4x.MultiplyPoint3x4(points3[l]));
					zero2 = cam3D.WorldToScreenPoint(matrix4x.MultiplyPoint3x4(points3[l + 1]));
				}
				else
				{
					vector3 = cam3D.WorldToScreenPoint(points3[l]);
					zero2 = cam3D.WorldToScreenPoint(points3[l + 1]);
				}
				if (vector3.z < 0.15f || zero2.z < 0.15f)
				{
					continue;
				}
				vector2.x = (int)vector3.x;
				zero.x = (int)zero2.x;
				vector2.y = (int)vector3.y;
				zero.y = (int)zero2.y;
				if (vector2.x != zero.x || vector2.y != zero.y)
				{
					num6 = Vector2.Dot(p - vector2, zero - vector2) / (zero - vector2).sqrMagnitude;
					if (!(num6 < 0f) && !(num6 > 1f) && (p - (vector2 + num6 * (zero - vector2))).sqrMagnitude <= (m_lineWidths[num2] + (float)extraDistance) * (m_lineWidths[num2] + (float)extraDistance))
					{
						index = ((!m_continuous) ? (l / 2) : l);
						return true;
					}
				}
			}
			index = -1;
			return false;
		}

		private bool Approximately2(Vector2 p1, Vector2 p2)
		{
			return Approximately(p1.x, p2.x) && Approximately(p1.y, p2.y);
		}

		private bool Approximately3(Vector3 p1, Vector3 p2)
		{
			return Approximately(p1.x, p2.x) && Approximately(p1.y, p2.y) && Approximately(p1.z, p2.z);
		}

		private bool Approximately(float a, float b)
		{
			return Mathf.Round(a * 100f) / 100f == Mathf.Round(b * 100f) / 100f;
		}

		public static string Version()
		{
			return "Vectrosity version 2.3";
		}
	}
}
