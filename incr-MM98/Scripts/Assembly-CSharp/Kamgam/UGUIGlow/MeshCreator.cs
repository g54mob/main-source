using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kamgam.UGUIGlow
{
	public class MeshCreator
	{
		public delegate void OnBeforeMeshWriteDelegate(MeshCreator manipulator, List<UIVertex> vertices, List<ushort> triangles, List<ushort> outerIndices, List<ushort> innerIndices, Dictionary<ushort, ushort> outerToInnerIndices);

		public GlowConfig _config;

		[NonSerialized]
		public float RectWidth;

		[NonSerialized]
		public float RectHeight;

		[NonSerialized]
		public float CornerRadius;

		[NonSerialized]
		public float? CornerRadiusTopLeft;

		[NonSerialized]
		public float? CornerRadiusTopRight;

		[NonSerialized]
		public float? CornerRadiusBottomLeft;

		[NonSerialized]
		public float? CornerRadiusBottomRight;

		public bool RemoveOnPlayModeStateChange = true;

		public OnBeforeMeshWriteDelegate OnBeforeMeshWrite;

		protected List<ushort> _outerIndices = new List<ushort>(100);

		protected List<ushort> _innerIndices = new List<ushort>(100);

		protected Dictionary<ushort, ushort> _outerToInnerIndices = new Dictionary<ushort, ushort>(100);

		protected List<UIVertex> _vertices = new List<UIVertex>(100);

		protected List<ushort> _triangles = new List<ushort>(100);

		protected bool _dirtyAnimation;

		private Rect _lastContentRect;

		protected List<UIVertex> _tmpVerticesForMeshCallback = new List<UIVertex>();

		public GlowConfig Config
		{
			get
			{
				return _config;
			}
			set
			{
				if (_config != value)
				{
					if (_config != null)
					{
						GlowConfig config = _config;
						config.OnValueChanged = (Action)Delegate.Remove(config.OnValueChanged, new Action(onValueChanged));
					}
					_config = value;
					if (_config != null)
					{
						GlowConfig config2 = _config;
						config2.OnValueChanged = (Action)Delegate.Combine(config2.OnValueChanged, new Action(onValueChanged));
					}
				}
			}
		}

		public void MarkDirtyAnimation()
		{
			_dirtyAnimation = true;
		}

		protected void RegisterCallbacksOnTarget()
		{
			if (_config != null)
			{
				GlowConfig config = _config;
				config.OnValueChanged = (Action)Delegate.Remove(config.OnValueChanged, new Action(onValueChanged));
				GlowConfig config2 = _config;
				config2.OnValueChanged = (Action)Delegate.Combine(config2.OnValueChanged, new Action(onValueChanged));
			}
		}

		protected void UnregisterCallbacksFromTarget()
		{
			if (_config != null)
			{
				GlowConfig config = _config;
				config.OnValueChanged = (Action)Delegate.Remove(config.OnValueChanged, new Action(onValueChanged));
			}
		}

		public void ModifyMesh(VertexHelper vh)
		{
			generateVisualContent(vh);
		}

		public void Clear()
		{
			_outerIndices.Clear();
			_innerIndices.Clear();
			_vertices.Clear();
			_triangles.Clear();
			_outerToInnerIndices.Clear();
			_tmpVerticesForMeshCallback.Clear();
		}

		protected void onValueChanged()
		{
			Clear();
		}

		protected void generateVisualContent(VertexHelper vh)
		{
			if (_dirtyAnimation)
			{
				Rect rect = new Rect((0f - RectWidth) * 0.5f, (0f - RectHeight) * 0.5f, RectWidth, RectHeight);
				_ = _lastContentRect;
				if (_lastContentRect != rect)
				{
					generateVisualContentFromScratch(vh);
				}
				else
				{
					generateVisualContentForAnimation(vh);
				}
				_dirtyAnimation = false;
			}
			else
			{
				generateVisualContentFromScratch(vh);
			}
		}

		protected void generateVisualContentForAnimation(VertexHelper vh)
		{
			if (OnBeforeMeshWrite != null)
			{
				copyVerticesToMeshCallbackTmp();
				OnBeforeMeshWrite?.Invoke(this, _tmpVerticesForMeshCallback, _triangles, _outerIndices, _innerIndices, _outerToInnerIndices);
				writeMeshData(_tmpVerticesForMeshCallback, _triangles, vh);
			}
		}

		protected void copyVerticesToMeshCallbackTmp()
		{
			_tmpVerticesForMeshCallback.Clear();
			int count = _vertices.Count;
			for (int i = 0; i < count; i++)
			{
				_tmpVerticesForMeshCallback.Add(_vertices[i]);
			}
		}

		protected void generateVisualContentFromScratch(VertexHelper vh)
		{
			if (Config == null)
			{
				return;
			}
			float width = Config.Width;
			if (Mathf.Approximately(width, 0f))
			{
				return;
			}
			Rect rect = (_lastContentRect = new Rect((0f - RectWidth) * 0.5f, (0f - RectHeight) * 0.5f, RectWidth, RectHeight));
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 0f;
			float num8 = 0f;
			float value = (CornerRadiusTopLeft.HasValue ? CornerRadiusTopLeft.Value : CornerRadius);
			float value2 = (CornerRadiusTopRight.HasValue ? CornerRadiusTopRight.Value : CornerRadius);
			float value3 = (CornerRadiusBottomLeft.HasValue ? CornerRadiusBottomLeft.Value : CornerRadius);
			float value4 = (CornerRadiusBottomRight.HasValue ? CornerRadiusBottomRight.Value : CornerRadius);
			Vector2 vector = new Vector2(Mathf.Clamp(value, 0f, RectWidth * 0.5f), Mathf.Clamp(value, 0f, RectHeight * 0.5f));
			Vector2 vector2 = new Vector2(Mathf.Clamp(value2, 0f, RectWidth * 0.5f), Mathf.Clamp(value2, 0f, RectHeight * 0.5f));
			Vector2 vector3 = new Vector2(Mathf.Clamp(value3, 0f, RectWidth * 0.5f), Mathf.Clamp(value3, 0f, RectHeight * 0.5f));
			Vector2 vector4 = new Vector2(Mathf.Clamp(value4, 0f, RectWidth * 0.5f), Mathf.Clamp(value4, 0f, RectHeight * 0.5f));
			float overlapWidth = Config.OverlapWidth;
			bool splitWidth = Config.SplitWidth;
			float left = Config.Widths.Left;
			float bottom = Config.Widths.Bottom;
			float right = Config.Widths.Right;
			float top = Config.Widths.Top;
			float x = Config.Offset.x;
			float y = Config.Offset.y;
			Vector2 vector5 = new Vector2(x, y);
			bool offsetEverything = Config.OffsetEverything;
			float x2 = Config.Scale.x;
			float y2 = Config.Scale.y;
			Vector2 vector6 = new Vector2(x2, y2);
			Color innerColor = Config.InnerColor;
			Color outerColor = Config.OuterColor;
			bool forceSubdivision = Config.ForceSubdivision;
			bool preserveHardCorners = Config.PreserveHardCorners;
			bool fillCenter = Config.FillCenter;
			float vertexDistance = Config.VertexDistance;
			Vector2 vector7 = new Vector2(rect.xMin - num - num5 + vector.x, rect.yMin - num3 - num7 + vector.y);
			Vector2 vector8 = new Vector2(rect.xMax + num2 + num6 - vector2.x, rect.yMin - num3 - num7 + vector2.y);
			Vector2 vector9 = new Vector2(rect.xMin - num - num5 + vector3.x, rect.yMax + num4 + num8 - vector3.y);
			Vector2 vector10 = new Vector2(rect.xMax + num2 + num6 - vector4.x, rect.yMax + num4 + num8 - vector4.y);
			vertexDistance = Mathf.Max(5f, vertexDistance);
			Color white = Color.white;
			Color white2 = Color.white;
			Color white3 = Color.white;
			Color white4 = Color.white;
			float num9 = ((!(overlapWidth < rect.width * 0.5f)) ? (rect.width * 0.5f) : overlapWidth);
			float num10 = ((!(overlapWidth < rect.height * 0.5f)) ? (rect.height * 0.5f) : overlapWidth);
			vector7.x -= Mathf.Min(0f, vector.x - num9);
			vector7.y -= Mathf.Min(0f, vector.y - num10);
			vector8.x += Mathf.Min(0f, vector2.x - num9);
			vector8.y -= Mathf.Min(0f, vector2.y - num10);
			vector10.x += Mathf.Min(0f, vector4.x - num9);
			vector10.y += Mathf.Min(0f, vector4.y - num10);
			vector9.x -= Mathf.Min(0f, vector3.x - num9);
			vector9.y += Mathf.Min(0f, vector3.y - num10);
			bool flag = vector.x <= 0f && vector.y <= 0f;
			bool flag2 = vector2.x <= 0f && vector2.y <= 0f;
			bool flag3 = vector4.x <= 0f && vector4.y <= 0f;
			bool flag4 = vector3.x <= 0f && vector3.y <= 0f;
			if (preserveHardCorners && flag)
			{
				vector.x = 0f;
				vector7.x -= Mathf.Max(0f, vector.x - num9);
			}
			else
			{
				vector.x = Mathf.Max(0f, vector.x - num9);
			}
			if (preserveHardCorners && flag)
			{
				vector.y = 0f;
				vector7.y -= Mathf.Max(0f, vector.y - num10);
			}
			else
			{
				vector.y = Mathf.Max(0f, vector.y - num10);
			}
			if (preserveHardCorners && flag2)
			{
				vector2.x = 0f;
				vector8.x += Mathf.Max(0f, vector2.x - num9);
			}
			else
			{
				vector2.x = Mathf.Max(0f, vector2.x - num9);
			}
			if (preserveHardCorners && flag2)
			{
				vector2.y = 0f;
				vector8.y -= Mathf.Max(0f, vector2.y - num10);
			}
			else
			{
				vector2.y = Mathf.Max(0f, vector2.y - num10);
			}
			if (preserveHardCorners && flag3)
			{
				vector4.x = 0f;
				vector10.x += Mathf.Max(0f, vector4.x - num9);
			}
			else
			{
				vector4.x = Mathf.Max(0f, vector4.x - num9);
			}
			if (preserveHardCorners && flag3)
			{
				vector4.y = 0f;
				vector10.y += Mathf.Max(0f, vector4.y - num10);
			}
			else
			{
				vector4.y = Mathf.Max(0f, vector4.y - num10);
			}
			if (preserveHardCorners && flag4)
			{
				vector3.x = 0f;
				vector9.x -= Mathf.Max(0f, vector3.x - num9);
			}
			else
			{
				vector3.x = Mathf.Max(0f, vector3.x - num9);
			}
			if (preserveHardCorners && flag4)
			{
				vector3.y = 0f;
				vector9.y += Mathf.Max(0f, vector3.y - num10);
			}
			else
			{
				vector3.y = Mathf.Max(0f, vector3.y - num10);
			}
			bottom = (splitWidth ? bottom : width) + overlapWidth;
			right = (splitWidth ? right : width) + overlapWidth;
			top = (splitWidth ? top : width) + overlapWidth;
			left = (splitWidth ? left : width) + overlapWidth;
			if (!Mathf.Approximately(vector6.x, 1f) || !Mathf.Approximately(vector6.y, 1f))
			{
				vector7 = rect.center + (vector7 - rect.center) * vector6;
				vector8 = rect.center + (vector8 - rect.center) * vector6;
				vector10 = rect.center + (vector10 - rect.center) * vector6;
				vector9 = rect.center + (vector9 - rect.center) * vector6;
				vector *= vector6;
				vector2 *= vector6;
				vector4 *= vector6;
				vector3 *= vector6;
				bottom *= vector6.y;
				right *= vector6.x;
				top *= vector6.y;
				left *= vector6.x;
			}
			Clear();
			ushort num11 = 0;
			ushort num12 = 1;
			createOuterSide(_vertices, _triangles, vector7, vector, vector8, vector2, 0, -1, bottom, vector5, offsetEverything, innerColor, outerColor, vertexDistance, Config.UseRadialGradients, white, num11, num12, out var innerCornerBIndex, out var outerCornerBIndex, _innerIndices, _outerIndices, _outerToInnerIndices, forceSubdivision, createSideA: true);
			if (flag && preserveHardCorners)
			{
				addToVertexPosition(1, 0f - ((splitWidth ? left : width) + overlapWidth), 0f);
			}
			createOuterCorner(verticesPerCorner: Mathf.Max(1, Mathf.CeilToInt((vector2.x + right + vector2.y + bottom) * 0.8f / vertexDistance)), vertices: _vertices, triangles: _triangles, cornerPos: vector8, cornerSize: vector2, glowWidthX: right, glowWidthY: bottom, offset: vector5, offsetEverything: offsetEverything, innerColor: innerColor, outerColor: outerColor, preserveHardCorners: preserveHardCorners && flag2, innerStartIndex: innerCornerBIndex, outerStartindex: outerCornerBIndex, borderColor: white2, quadrant: 0, innerEndIndex: out var innerEndIndex, outerEndIndex: out var outerEndIndex, innerIndices: _innerIndices, outerIndices: _outerIndices, outerToInnerIndices: _outerToInnerIndices);
			createOuterSide(_vertices, _triangles, vector8, vector2, vector10, vector4, 1, 0, right, vector5, offsetEverything, innerColor, outerColor, vertexDistance, Config.UseRadialGradients, white2, innerEndIndex, outerEndIndex, out var innerCornerBIndex2, out var outerCornerBIndex2, _innerIndices, _outerIndices, _outerToInnerIndices, forceSubdivision, createSideA: false);
			createOuterCorner(verticesPerCorner: Mathf.Max(1, Mathf.CeilToInt((vector4.x + right + vector4.y + top) * 0.8f / vertexDistance)), vertices: _vertices, triangles: _triangles, cornerPos: vector10, cornerSize: vector4, glowWidthX: right, glowWidthY: top, offset: vector5, offsetEverything: offsetEverything, innerColor: innerColor, outerColor: outerColor, preserveHardCorners: preserveHardCorners && flag3, innerStartIndex: innerCornerBIndex2, outerStartindex: outerCornerBIndex2, borderColor: white3, quadrant: 1, innerEndIndex: out var innerEndIndex2, outerEndIndex: out var outerEndIndex2, innerIndices: _innerIndices, outerIndices: _outerIndices, outerToInnerIndices: _outerToInnerIndices);
			createOuterSide(_vertices, _triangles, vector10, vector4, vector9, vector3, 0, 1, top, vector5, offsetEverything, innerColor, outerColor, vertexDistance, Config.UseRadialGradients, white3, innerEndIndex2, outerEndIndex2, out var innerCornerBIndex3, out var outerCornerBIndex3, _innerIndices, _outerIndices, _outerToInnerIndices, forceSubdivision, createSideA: false);
			createOuterCorner(verticesPerCorner: Mathf.Max(1, Mathf.CeilToInt((vector3.x + left + vector3.y + top) * 0.8f / vertexDistance)), vertices: _vertices, triangles: _triangles, cornerPos: vector9, cornerSize: vector3, glowWidthX: left, glowWidthY: top, offset: vector5, offsetEverything: offsetEverything, innerColor: innerColor, outerColor: outerColor, preserveHardCorners: preserveHardCorners && flag4, innerStartIndex: innerCornerBIndex3, outerStartindex: outerCornerBIndex3, borderColor: white4, quadrant: 2, innerEndIndex: out var innerEndIndex3, outerEndIndex: out var outerEndIndex3, innerIndices: _innerIndices, outerIndices: _outerIndices, outerToInnerIndices: _outerToInnerIndices);
			createOuterSide(_vertices, _triangles, vector9, vector3, vector7, vector, -1, 0, left, vector5, offsetEverything, innerColor, outerColor, vertexDistance, Config.UseRadialGradients, white4, innerEndIndex3, outerEndIndex3, out var innerCornerBIndex4, out var outerCornerBIndex4, _innerIndices, _outerIndices, _outerToInnerIndices, forceSubdivision, createSideA: false);
			createOuterCorner(verticesPerCorner: Mathf.Max(1, Mathf.CeilToInt((vector.x + left + vector.y + bottom) * 0.8f / vertexDistance)), vertices: _vertices, triangles: _triangles, cornerPos: vector7, cornerSize: vector, glowWidthX: left, glowWidthY: bottom, offset: vector5, offsetEverything: offsetEverything, innerColor: innerColor, outerColor: outerColor, preserveHardCorners: preserveHardCorners && flag, innerStartIndex: innerCornerBIndex4, outerStartindex: outerCornerBIndex4, borderColor: white, quadrant: 3, innerEndIndex: out var innerEndIndex4, outerEndIndex: out var outerEndIndex4, innerIndices: _innerIndices, outerIndices: _outerIndices, outerToInnerIndices: _outerToInnerIndices);
			if (Vector3.SqrMagnitude(_vertices[num11].position - _vertices[innerEndIndex4].position) > 1f)
			{
				_triangles.Add(innerEndIndex4);
				_triangles.Add(outerEndIndex4);
				_triangles.Add(num11);
			}
			if (Vector3.SqrMagnitude(_vertices[num12].position - _vertices[outerEndIndex4].position) > 1f)
			{
				_triangles.Add(innerEndIndex4);
				_triangles.Add(outerEndIndex4);
				_triangles.Add(num12);
			}
			if (fillCenter)
			{
				UIVertex item = new UIVertex
				{
					position = rect.center + (offsetEverything ? vector5 : Vector2.zero),
					color = (Config.UseRadialGradients ? Config.InnerColors.Evaluate(0f) : innerColor)
				};
				_vertices.Add(item);
				ushort item2 = (ushort)(_vertices.Count - 1);
				int num13 = _innerIndices.Count - 1;
				for (int i = 0; i < num13; i++)
				{
					_triangles.Add(item2);
					_triangles.Add(_innerIndices[i]);
					_triangles.Add(_innerIndices[i + 1]);
				}
			}
			if (Config.UseRadialGradients)
			{
				int count = _innerIndices.Count;
				float num14 = 1f / (float)(count - 1);
				for (int j = 0; j < _innerIndices.Count; j++)
				{
					UIVertex value5 = _vertices[_innerIndices[j]];
					value5.color = Config.InnerColors.Evaluate(num14 * (float)j);
					_vertices[_innerIndices[j]] = value5;
				}
				count = _outerIndices.Count;
				num14 = 1f / (float)(count - 1);
				for (int k = 0; k < count; k++)
				{
					UIVertex value6 = _vertices[_outerIndices[k]];
					value6.color = Config.OuterColors.Evaluate(num14 * (float)k);
					_vertices[_outerIndices[k]] = value6;
				}
			}
			if (OnBeforeMeshWrite != null)
			{
				copyVerticesToMeshCallbackTmp();
				OnBeforeMeshWrite?.Invoke(this, _tmpVerticesForMeshCallback, _triangles, _outerIndices, _innerIndices, _outerToInnerIndices);
				writeMeshData(_tmpVerticesForMeshCallback, _triangles, vh);
			}
			else
			{
				writeMeshData(_vertices, _triangles, vh);
			}
		}

		private void addToVertexPosition(ushort index, float x, float y)
		{
			UIVertex value = _vertices[index];
			Vector3 position = value.position;
			position.x += x;
			position.y += y;
			value.position = position;
			_vertices[index] = value;
		}

		private void writeMeshData(List<UIVertex> glowVertices, List<ushort> triangles, VertexHelper vh)
		{
			vh.Clear();
			int currentVertCount = vh.currentVertCount;
			int count = glowVertices.Count;
			int count2 = triangles.Count;
			for (int i = 0; i < count; i++)
			{
				vh.AddVert(glowVertices[i]);
			}
			for (int j = 0; j < count2; j += 3)
			{
				vh.AddTriangle(currentVertCount + triangles[j + 2], currentVertCount + triangles[j + 1], currentVertCount + triangles[j]);
			}
		}

		protected void createOuterSide(List<UIVertex> vertices, List<ushort> triangles, Vector2 cornerA, Vector2 cornerSizeA, Vector2 cornerB, Vector2 cornerSizeB, int directionX, int directionY, float glowWidth, Vector2 offset, bool offsetEverything, Color innerColor, Color outerColor, float vertexDistance, bool useRadialGradients, Color borderColor, ushort innerCornerAIndex, ushort outerCornerAIndex, out ushort innerCornerBIndex, out ushort outerCornerBIndex, List<ushort> innerIndices, List<ushort> outerIndices, Dictionary<ushort, ushort> outerToInnerIndices, bool forceSubdivision, bool createSideA)
		{
			if (createSideA)
			{
				vertices.Add(new UIVertex
				{
					position = new Vector3(cornerA.x + cornerSizeA.x * (float)directionX + (offsetEverything ? offset.x : 0f), cornerA.y + cornerSizeA.y * (float)directionY + (offsetEverything ? offset.y : 0f), 0f),
					color = innerColor * borderColor
				});
				ushort num = (ushort)(vertices.Count - 1);
				innerIndices.Add(num);
				vertices.Add(new UIVertex
				{
					position = new Vector3(cornerA.x + cornerSizeA.x * (float)directionX + glowWidth * (float)directionX + offset.x, cornerA.y + cornerSizeA.y * (float)directionY + glowWidth * (float)directionY + offset.y, 0f),
					color = outerColor * borderColor
				});
				ushort num2 = (ushort)(vertices.Count - 1);
				outerIndices.Add(num2);
				outerToInnerIndices.Add(num2, num);
			}
			Vector3 position = vertices[innerCornerAIndex].position;
			Vector3 position2 = vertices[outerCornerAIndex].position;
			Vector3 vector = new Vector3(cornerB.x + cornerSizeB.x * (float)directionX + (offsetEverything ? offset.x : 0f), cornerB.y + cornerSizeB.y * (float)directionY + (offsetEverything ? offset.y : 0f), 0f);
			Vector3 b = new Vector3(cornerB.x + cornerSizeB.x * (float)directionX + glowWidth * (float)directionX + offset.x, cornerB.y + cornerSizeB.y * (float)directionY + glowWidth * (float)directionY + offset.y, 0f);
			int num3 = 1;
			bool flag = useRadialGradients || forceSubdivision;
			if (flag)
			{
				float num4 = Vector2.Distance(position, vector);
				num3 = ((!flag) ? 1 : Mathf.Max(1, Mathf.RoundToInt(num4 / vertexDistance)));
			}
			outerCornerBIndex = 0;
			innerCornerBIndex = 0;
			ushort num5 = innerCornerAIndex;
			ushort num6 = outerCornerAIndex;
			for (int i = 1; i <= num3; i++)
			{
				vertices.Add(new UIVertex
				{
					position = Vector3.Lerp(position2, b, (float)i / (float)num3),
					color = outerColor * borderColor
				});
				outerCornerBIndex = (ushort)(vertices.Count - 1);
				outerIndices.Add(outerCornerBIndex);
				vertices.Add(new UIVertex
				{
					position = Vector3.Lerp(position, vector, (float)i / (float)num3),
					color = innerColor * borderColor
				});
				innerCornerBIndex = (ushort)(vertices.Count - 1);
				innerIndices.Add(innerCornerBIndex);
				outerToInnerIndices.Add(outerCornerBIndex, innerCornerBIndex);
				ushort item = num5;
				ushort item2 = num6;
				num5 = (ushort)(vertices.Count - 1);
				num6 = (ushort)(vertices.Count - 2);
				triangles.Add(item);
				triangles.Add(item2);
				triangles.Add(num6);
				triangles.Add(num6);
				triangles.Add(num5);
				triangles.Add(item);
			}
		}

		private void createOuterCorner(List<UIVertex> vertices, List<ushort> triangles, Vector2 cornerPos, Vector2 cornerSize, float glowWidthX, float glowWidthY, Vector2 offset, bool offsetEverything, Color innerColor, Color outerColor, bool preserveHardCorners, ushort innerStartIndex, ushort outerStartindex, int verticesPerCorner, Color borderColor, int quadrant, out ushort innerEndIndex, out ushort outerEndIndex, List<ushort> innerIndices, List<ushort> outerIndices, Dictionary<ushort, ushort> outerToInnerIndices)
		{
			bool flag = cornerSize.x > 0f && cornerSize.y > 0f;
			float num = MathF.PI / 2f * (float)(quadrant - 1);
			float num2 = 1f / (float)(verticesPerCorner + 1) * MathF.PI * 0.5f;
			ushort num3 = innerStartIndex;
			ushort num4 = outerStartindex;
			bool flag2 = preserveHardCorners && !flag;
			if (flag2)
			{
				verticesPerCorner = 0;
			}
			for (int i = 1; i < verticesPerCorner + 2; i++)
			{
				float num5 = Mathf.Cos(num + num2 * (float)i);
				float num6 = Mathf.Sin(num + num2 * (float)i);
				if (flag)
				{
					Vector3 position = new Vector3(cornerPos.x + num5 * cornerSize.x + (offsetEverything ? offset.x : 0f), cornerPos.y + num6 * cornerSize.y + (offsetEverything ? offset.y : 0f), 0f);
					vertices.Add(new UIVertex
					{
						position = position,
						color = innerColor * borderColor
					});
				}
				Vector3 position2 = ((!flag2) ? new Vector3(cornerPos.x + num5 * (cornerSize.x + glowWidthX) + offset.x, cornerPos.y + num6 * (cornerSize.y + glowWidthY) + offset.y, 0f) : new Vector3(cornerPos.x + Mathf.Sign(num5) * (cornerSize.x + glowWidthX) + offset.x, cornerPos.y + Mathf.Sign(num6) * (cornerSize.y + glowWidthY) + offset.y, 0f));
				vertices.Add(new UIVertex
				{
					position = position2,
					color = outerColor * borderColor
				});
				ushort item = num3;
				ushort item2 = num4;
				num3 = (flag ? ((ushort)(vertices.Count - 2)) : innerStartIndex);
				num4 = (ushort)(vertices.Count - 1);
				if (flag)
				{
					innerIndices.Add(num3);
				}
				outerIndices.Add(num4);
				outerToInnerIndices.Add(num4, num3);
				triangles.Add(item);
				triangles.Add(item2);
				triangles.Add(num4);
				if (flag)
				{
					triangles.Add(num4);
					triangles.Add(num3);
					triangles.Add(item);
				}
			}
			innerEndIndex = num3;
			outerEndIndex = num4;
		}

		public static Vector3 DisplaceVertexOutwardsNormalized(List<UIVertex> vertices, Dictionary<ushort, ushort> outerToInner, ushort outerVertexIndex, float displacementFactor = 1f)
		{
			UIVertex value = vertices[outerVertexIndex];
			UIVertex uIVertex = vertices[outerToInner[outerVertexIndex]];
			Vector3 vector = value.position - uIVertex.position;
			vector *= displacementFactor;
			value.position += vector;
			vertices[outerVertexIndex] = value;
			return vector;
		}

		public static void DisplaceVertex(List<UIVertex> vertices, ushort vertexIndex, Vector3 vector)
		{
			UIVertex value = vertices[vertexIndex];
			value.position += vector;
			vertices[vertexIndex] = value;
		}

		public static void DisplaceVertex(List<UIVertex> vertices, ushort vertexIndex, float x, float y)
		{
			UIVertex value = vertices[vertexIndex];
			value.position.x += x;
			value.position.y += y;
			vertices[vertexIndex] = value;
		}

		public static void SetVertexColor(List<UIVertex> vertices, ushort vertexIndex, Color color)
		{
			UIVertex value = vertices[vertexIndex];
			value.color = color;
			vertices[vertexIndex] = value;
		}

		public static void SetVertexPosition(List<UIVertex> vertices, ushort vertexIndex, Vector3 position)
		{
			UIVertex value = vertices[vertexIndex];
			value.position = position;
			vertices[vertexIndex] = value;
		}
	}
}
