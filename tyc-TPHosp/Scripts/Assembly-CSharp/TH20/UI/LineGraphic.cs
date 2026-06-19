using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace TH20.UI
{
	public class LineGraphic : MaskableGraphic
	{
		private float _radiansDelta;

		private float _radiansDeltaSine;

		private float _radiansDeltaCosine;

		private const float _featherScale = 1f;

		private const float Epsilon = 0.0001f;

		[SerializeField]
		private List<Vector2> _points = new List<Vector2>();

		[SerializeField]
		private float _thickness = 0.5f;

		[SerializeField]
		private float _borderThickness = 0.5f;

		[SerializeField]
		private Color _borderColor = Color.white;

		private VertexHelper _vertexHelper;

		private List<Vector2> _cachedTransformedPoints = new List<Vector2>(128);

		private UIVertex[] _cachedQuadUIVertices = new UIVertex[4];

		private List<Component> _cachedComponents = new List<Component>(8);

		private List<Vector3> vh_Positions;

		private List<Color32> vh_Colors;

		private List<Vector2> vh_Uv0S;

		private List<Vector2> vh_Uv1S;

		private List<Vector2> vh_Uv2S;

		private List<Vector2> vh_Uv3S;

		private List<Vector3> vh_Normals;

		private List<Vector4> vh_Tangents;

		private List<int> vh_Indices;

		public List<Vector2> Points
		{
			get
			{
				return new List<Vector2>(_points);
			}
			set
			{
				_points.Clear();
				_points.AddRange(value);
				SetVerticesDirty();
			}
		}

		public float Thickness
		{
			get
			{
				return _thickness;
			}
			set
			{
				_thickness = value;
				SetVerticesDirty();
			}
		}

		public float BorderThickness
		{
			get
			{
				return _borderThickness;
			}
			set
			{
				_borderThickness = value;
				SetVerticesDirty();
			}
		}

		public Color BorderColor
		{
			get
			{
				return _borderColor;
			}
			set
			{
				_borderColor = value;
				SetVerticesDirty();
			}
		}

		protected override void UpdateGeometry()
		{
			if (_vertexHelper == null)
			{
				_vertexHelper = new VertexHelper();
				FieldInfo field = typeof(VertexHelper).GetField("m_Positions", BindingFlags.Instance | BindingFlags.NonPublic);
				FieldInfo field2 = typeof(VertexHelper).GetField("m_Colors", BindingFlags.Instance | BindingFlags.NonPublic);
				FieldInfo field3 = typeof(VertexHelper).GetField("m_Uv0S", BindingFlags.Instance | BindingFlags.NonPublic);
				FieldInfo field4 = typeof(VertexHelper).GetField("m_Uv1S", BindingFlags.Instance | BindingFlags.NonPublic);
				FieldInfo field5 = typeof(VertexHelper).GetField("m_Uv2S", BindingFlags.Instance | BindingFlags.NonPublic);
				FieldInfo field6 = typeof(VertexHelper).GetField("m_Uv3S", BindingFlags.Instance | BindingFlags.NonPublic);
				FieldInfo field7 = typeof(VertexHelper).GetField("m_Normals", BindingFlags.Instance | BindingFlags.NonPublic);
				FieldInfo field8 = typeof(VertexHelper).GetField("m_Tangents", BindingFlags.Instance | BindingFlags.NonPublic);
				FieldInfo field9 = typeof(VertexHelper).GetField("m_Indices", BindingFlags.Instance | BindingFlags.NonPublic);
				vh_Positions = field.GetValue(_vertexHelper) as List<Vector3>;
				vh_Colors = field2.GetValue(_vertexHelper) as List<Color32>;
				vh_Uv0S = field3.GetValue(_vertexHelper) as List<Vector2>;
				vh_Uv1S = field4.GetValue(_vertexHelper) as List<Vector2>;
				vh_Uv2S = field5.GetValue(_vertexHelper) as List<Vector2>;
				vh_Uv3S = field6.GetValue(_vertexHelper) as List<Vector2>;
				vh_Normals = field7.GetValue(_vertexHelper) as List<Vector3>;
				vh_Tangents = field8.GetValue(_vertexHelper) as List<Vector4>;
				vh_Indices = field9.GetValue(_vertexHelper) as List<int>;
			}
			DoMeshGeneration();
		}

		private void DoMeshGeneration()
		{
			if (Graphic.workerMesh.indexFormat != IndexFormat.UInt32)
			{
				Graphic.workerMesh.indexFormat = IndexFormat.UInt32;
			}
			_vertexHelper.Clear();
			if (base.rectTransform != null && base.rectTransform.rect.width >= 0f && base.rectTransform.rect.height >= 0f)
			{
				OnPopulateMesh(_vertexHelper);
			}
			else
			{
				_vertexHelper.Clear();
			}
			_cachedComponents.Clear();
			GetComponents(typeof(IMeshModifier), _cachedComponents);
			for (int i = 0; i < _cachedComponents.Count; i++)
			{
				((IMeshModifier)_cachedComponents[i]).ModifyMesh(_vertexHelper);
			}
			_cachedComponents.Clear();
			CustomFillMesh(_vertexHelper, Graphic.workerMesh);
			base.canvasRenderer.SetMesh(Graphic.workerMesh);
		}

		private void CustomFillMesh(VertexHelper vertexHelper, Mesh mesh)
		{
			mesh.Clear();
			mesh.SetVertices(vh_Positions);
			mesh.SetColors(vh_Colors);
			mesh.SetUVs(0, vh_Uv0S);
			mesh.SetUVs(1, vh_Uv1S);
			mesh.SetUVs(2, vh_Uv2S);
			mesh.SetUVs(3, vh_Uv3S);
			mesh.SetNormals(vh_Normals);
			mesh.SetTangents(vh_Tangents);
			mesh.SetTriangles(vh_Indices, 0);
			mesh.RecalculateBounds();
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			float num;
			if (base.canvas.renderMode == RenderMode.WorldSpace)
			{
				_radiansDelta = 0.17453292f;
				num = 1f;
			}
			else
			{
				float num2 = Mathf.Max(1f / base.canvas.scaleFactor, 4f);
				_radiansDelta = Mathf.Clamp(4f * num2 / (_thickness + _borderThickness), 0.17453292f, (float)Math.PI / 2f);
				num = 1f * num2;
			}
			_radiansDeltaSine = Mathf.Sin(_radiansDelta);
			_radiansDeltaCosine = Mathf.Cos(_radiansDelta);
			Vector2 dimensions = new Vector2(base.rectTransform.rect.width, base.rectTransform.rect.height);
			Vector2 pivot = base.rectTransform.pivot;
			Vector2 bottomLeft = new Vector2((0f - pivot.x) * dimensions.x, (0f - pivot.y) * dimensions.y);
			vh.Clear();
			_cachedTransformedPoints.Clear();
			for (int i = 0; i < _points.Count; i++)
			{
				Vector2 vector = new Vector2(bottomLeft.x + _points[i].x * dimensions.x, bottomLeft.y + _points[i].y * dimensions.y);
				if (_cachedTransformedPoints.Count == 0 || (_cachedTransformedPoints[_cachedTransformedPoints.Count - 1] - vector).sqrMagnitude > 9.999999E-09f)
				{
					_cachedTransformedPoints.Add(vector);
				}
			}
			if (_borderThickness > 0f)
			{
				CreateLineMesh(vh, _cachedTransformedPoints, bottomLeft, dimensions, _thickness + _borderThickness, _thickness + _borderThickness + num, _borderColor, new Color(_borderColor.r, _borderColor.g, _borderColor.b, 0f));
				CreateLineMesh(vh, _cachedTransformedPoints, bottomLeft, dimensions, _thickness, _thickness + _borderThickness, _borderColor, _borderColor);
				CreateLineMesh(vh, _cachedTransformedPoints, bottomLeft, dimensions, _thickness, _thickness + Mathf.Min(num, _borderThickness), color, _borderColor);
			}
			else
			{
				CreateLineMesh(vh, _cachedTransformedPoints, bottomLeft, dimensions, _thickness, _thickness + num, color, new Color(color.r, color.g, color.b, 0f));
			}
			CreateLineMesh(vh, _cachedTransformedPoints, bottomLeft, dimensions, 0f, _thickness, color, color);
		}

		private void CreateLineMesh(VertexHelper vh, List<Vector2> points, Vector2 bottomLeft, Vector2 dimensions, float innerRadius, float outerRadius, Color innerColor, Color outerColor)
		{
			_cachedQuadUIVertices[0].color = innerColor;
			_cachedQuadUIVertices[1].color = innerColor;
			_cachedQuadUIVertices[2].color = innerColor;
			_cachedQuadUIVertices[3].color = innerColor;
			for (int i = 1; i < points.Count; i++)
			{
				Vector2 vector = points[i - 1];
				Vector2 vector2 = points[i];
				Vector2 normalized = (vector2 - vector).normalized;
				Vector2 vector3 = new Vector2(0f - normalized.y, normalized.x);
				_cachedQuadUIVertices[0].position = vector + vector3 * innerRadius;
				_cachedQuadUIVertices[1].position = vector2 + vector3 * innerRadius;
				_cachedQuadUIVertices[2].position = vector2 + vector3 * outerRadius;
				_cachedQuadUIVertices[3].position = vector + vector3 * outerRadius;
				_cachedQuadUIVertices[0].color = innerColor;
				_cachedQuadUIVertices[1].color = innerColor;
				_cachedQuadUIVertices[2].color = outerColor;
				_cachedQuadUIVertices[3].color = outerColor;
				vh.AddUIVertexQuad(_cachedQuadUIVertices);
				_cachedQuadUIVertices[0].position = vector - vector3 * innerRadius;
				_cachedQuadUIVertices[1].position = vector - vector3 * outerRadius;
				_cachedQuadUIVertices[2].position = vector2 - vector3 * outerRadius;
				_cachedQuadUIVertices[3].position = vector2 - vector3 * innerRadius;
				_cachedQuadUIVertices[0].color = innerColor;
				_cachedQuadUIVertices[1].color = outerColor;
				_cachedQuadUIVertices[2].color = outerColor;
				_cachedQuadUIVertices[3].color = innerColor;
				vh.AddUIVertexQuad(_cachedQuadUIVertices);
				if (i >= points.Count - 1)
				{
					continue;
				}
				Vector2 vector4 = points[i + 1];
				Vector2 normalized2 = (vector2 - vector).normalized;
				Vector2 normalized3 = (vector4 - vector2).normalized;
				Vector2 vector5 = new Vector2(0f - normalized2.y, normalized2.x);
				Vector2 vector6 = new Vector2(0f - normalized3.y, normalized3.x);
				float num = Vector2.Dot(normalized2, vector6);
				if (num > 0.0001f)
				{
					if (innerRadius > 0.0001f)
					{
						UIMeshUtils.CreateArcMeshClockwise(vh, points[i], vector6, vector5, innerRadius, outerRadius, innerColor, outerColor, _radiansDelta, _radiansDeltaSine, _radiansDeltaCosine);
					}
					else
					{
						CreateSectorMeshClockwise(vh, points[i], vector6, vector5, outerRadius, innerColor);
					}
				}
				else if (num < -0.0001f)
				{
					UIMeshUtils.CreateArcMeshClockwise(vh, points[i], -vector5, -vector6, innerRadius, outerRadius, innerColor, outerColor, _radiansDelta, _radiansDeltaSine, _radiansDeltaCosine);
					if (innerRadius > 0.0001f)
					{
						UIMeshUtils.CreateArcMeshClockwise(vh, points[i], -vector5, -vector6, innerRadius, outerRadius, innerColor, outerColor, _radiansDelta, _radiansDeltaSine, _radiansDeltaCosine);
					}
					else
					{
						CreateSectorMeshClockwise(vh, points[i], -vector5, -vector6, outerRadius, innerColor);
					}
				}
			}
			if (points.Count > 1)
			{
				Vector2 normalized4 = (points[1] - points[0]).normalized;
				Vector2 vector7 = new Vector2(0f - normalized4.y, normalized4.x);
				UIMeshUtils.CreateArcMeshClockwise(vh, points[0], vector7, -vector7, innerRadius, outerRadius, innerColor, outerColor, _radiansDelta, _radiansDeltaSine, _radiansDeltaCosine);
				Vector2 normalized5 = (points[points.Count - 1] - points[points.Count - 2]).normalized;
				Vector2 vector8 = new Vector2(0f - normalized5.y, normalized5.x);
				UIMeshUtils.CreateArcMeshClockwise(vh, points[points.Count - 1], -vector8, vector8, innerRadius, outerRadius, innerColor, outerColor, _radiansDelta, _radiansDeltaSine, _radiansDeltaCosine);
			}
		}

		private void CreateSectorMeshClockwise(VertexHelper vh, Vector2 origin, Vector2 startDir, Vector2 endDir, float radius, Color color)
		{
			startDir *= radius;
			endDir *= radius;
			float radiansDeltaSine = _radiansDeltaSine;
			float radiansDeltaCosine = _radiansDeltaCosine;
			int num = Mathf.FloorToInt(Vector2.Angle(startDir, endDir) * ((float)Math.PI / 180f) / _radiansDelta);
			int currentVertCount = vh.currentVertCount;
			UIVertex simpleVert = UIVertex.simpleVert;
			simpleVert.color = color;
			simpleVert.position = origin;
			vh.AddVert(simpleVert);
			simpleVert.position = origin + startDir;
			vh.AddVert(simpleVert);
			Vector2 vector = startDir;
			for (int i = 0; i < num; i++)
			{
				vector = new Vector2(vector.x * radiansDeltaCosine - vector.y * radiansDeltaSine, vector.x * radiansDeltaSine + vector.y * radiansDeltaCosine);
				simpleVert.position = origin + vector;
				vh.AddVert(simpleVert);
				vh.AddTriangle(currentVertCount, vh.currentVertCount - 2, vh.currentVertCount - 1);
			}
			simpleVert.position = origin + endDir;
			vh.AddVert(simpleVert);
			vh.AddTriangle(currentVertCount, vh.currentVertCount - 2, vh.currentVertCount - 1);
		}
	}
}
