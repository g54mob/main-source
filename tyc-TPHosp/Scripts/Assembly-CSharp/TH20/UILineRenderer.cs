#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[AddComponentMenu("UI/Extensions/Primitives/UILineRenderer")]
	public class UILineRenderer : MaskableGraphic
	{
		private enum SegmentType
		{
			Start = 0,
			Middle = 1,
			End = 2
		}

		public enum JoinType
		{
			Bevel = 0,
			Miter = 1
		}

		public enum MappingType
		{
			MapTypeNormal = 0,
			MapTypeTile = 1,
			MapTypePlanarY = 2
		}

		public enum EndType
		{
			EndTypeNormal = 0,
			EndTypeArrow = 1
		}

		private const float MIN_MITER_JOIN = (float)Math.PI / 12f;

		private const float MIN_BEVEL_NICE_JOIN = (float)Math.PI / 6f;

		private static readonly Vector2 UV_TOP_LEFT = Vector2.zero;

		private static readonly Vector2 UV_BOTTOM_LEFT = new Vector2(0f, 1f);

		private static readonly Vector2 UV_TOP_CENTER = new Vector2(0.5f, 0f);

		private static readonly Vector2 UV_BOTTOM_CENTER = new Vector2(0.5f, 1f);

		private static readonly Vector2 UV_TOP_RIGHT = new Vector2(1f, 0f);

		private static readonly Vector2 UV_BOTTOM_RIGHT = new Vector2(1f, 1f);

		private static readonly Vector2[] startUvs = new Vector2[4] { UV_TOP_LEFT, UV_BOTTOM_LEFT, UV_BOTTOM_CENTER, UV_TOP_CENTER };

		private static readonly Vector2[] middleUvs = new Vector2[4] { UV_TOP_CENTER, UV_BOTTOM_CENTER, UV_BOTTOM_CENTER, UV_TOP_CENTER };

		private static readonly Vector2[] endUvs = new Vector2[4] { UV_TOP_CENTER, UV_BOTTOM_CENTER, UV_BOTTOM_RIGHT, UV_TOP_RIGHT };

		private static readonly Vector2[] arrowUvs = new Vector2[4]
		{
			new Vector2(0f, 0.5f),
			UV_BOTTOM_LEFT,
			new Vector2(1f, 0.5f),
			UV_TOP_LEFT
		};

		[SerializeField]
		private Texture m_Texture;

		[SerializeField]
		private Rect m_UVRect = new Rect(0f, 0f, 1f, 1f);

		[SerializeField]
		private MappingType mappingType;

		public float LineThickness = 2f;

		public bool UseMargins;

		public Vector2 Margin;

		public Vector2[] Points;

		public bool relativeSize;

		public bool StartFromCentre;

		public bool LineList;

		public bool LineCaps;

		public JoinType LineJoins;

		[SerializeField]
		private EndType endType;

		private float _unOffsetY;

		private float _yMapper;

		public override Texture mainTexture => m_Texture ?? Graphic.s_WhiteTexture;

		public Texture texture
		{
			get
			{
				return m_Texture;
			}
			set
			{
				if (!(m_Texture == value))
				{
					m_Texture = value;
					SetVerticesDirty();
					SetMaterialDirty();
				}
			}
		}

		public Rect uvRect
		{
			get
			{
				return m_UVRect;
			}
			set
			{
				if (!(m_UVRect == value))
				{
					m_UVRect = value;
					SetVerticesDirty();
				}
			}
		}

		public virtual void SetPosition(int index, Vector2 position)
		{
			if (index >= Points.Length)
			{
				Array.Resize(ref Points, index + 1);
			}
			Points[index] = position;
			SetAllDirty();
		}

		public virtual void SetPositions(Vector2[] positions)
		{
			Points = positions;
			SetAllDirty();
		}

		public virtual void SetPositions(List<Vector2> positions)
		{
			Points = positions.ToArray();
			SetAllDirty();
		}

		public virtual void ClearPositions()
		{
			Points = new Vector2[0];
			SetAllDirty();
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			if (Points == null)
			{
				return;
			}
			float num = base.rectTransform.rect.width;
			float num2 = base.rectTransform.rect.height;
			float num3 = (StartFromCentre ? 0f : ((0f - base.rectTransform.pivot.x) * base.rectTransform.rect.width));
			float num4 = (StartFromCentre ? 0f : ((0f - base.rectTransform.pivot.y) * base.rectTransform.rect.height));
			if (mappingType == MappingType.MapTypePlanarY)
			{
				_unOffsetY = 0f - num4;
				_yMapper = 1f / num2;
			}
			if (!relativeSize)
			{
				num = 1f;
				num2 = 1f;
			}
			if (UseMargins)
			{
				num -= Margin.x;
				num2 -= Margin.y;
				num3 += Margin.x / 2f;
				num4 += Margin.y / 2f;
			}
			vh.Clear();
			List<UIVertex[]> list = new List<UIVertex[]>();
			if (LineList)
			{
				for (int i = 1; i < Points.Length; i += 2)
				{
					Vector2 vector = Points[i - 1];
					Vector2 vector2 = Points[i];
					vector = new Vector2(vector.x * num + num3, vector.y * num2 + num4);
					vector2 = new Vector2(vector2.x * num + num3, vector2.y * num2 + num4);
					if (LineCaps)
					{
						list.Add(CreateLineCap(vector, vector2, SegmentType.Start));
					}
					list.Add(CreateLineSegment(vector, vector2, SegmentType.Middle));
					if (LineCaps)
					{
						list.Add(CreateLineCap(vector, vector2, SegmentType.End));
					}
				}
			}
			else
			{
				for (int j = 1; j < Points.Length; j++)
				{
					Vector2 vector3 = Points[j - 1];
					Vector2 vector4 = Points[j];
					if (j == Points.Length - 1 && endType == EndType.EndTypeArrow)
					{
						Vector2 vector5 = vector4 - vector3;
						vector4 = vector3 + vector5 * 0.92f;
					}
					vector3 = new Vector2(vector3.x * num + num3, vector3.y * num2 + num4);
					vector4 = new Vector2(vector4.x * num + num3, vector4.y * num2 + num4);
					if (LineCaps && j == 1)
					{
						list.Add(CreateLineCap(vector3, vector4, SegmentType.Start));
					}
					list.Add(CreateLineSegment(vector3, vector4, SegmentType.Middle));
					if (LineCaps && j == Points.Length - 1)
					{
						list.Add(CreateLineCap(vector3, vector4, SegmentType.End));
					}
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				if (!LineList && k < list.Count - 1)
				{
					Vector3 vector6 = list[k][1].position - list[k][2].position;
					Vector3 vector7 = list[k + 1][2].position - list[k + 1][1].position;
					float num5 = Vector2.Angle(vector6, vector7) * ((float)Math.PI / 180f);
					float num6 = Mathf.Sign(Vector3.Cross(vector6.normalized, vector7.normalized).z);
					float num7 = LineThickness / (2f * Mathf.Tan(num5 / 2f));
					Vector3 position = list[k][2].position - vector6.normalized * num7 * num6;
					Vector3 position2 = list[k][3].position + vector6.normalized * num7 * num6;
					JoinType joinType = LineJoins;
					if (joinType == JoinType.Miter)
					{
						if (num7 < vector6.magnitude / 2f && num7 < vector7.magnitude / 2f && num5 > (float)Math.PI / 12f)
						{
							list[k][2].position = position;
							list[k][3].position = position2;
							list[k + 1][0].position = position2;
							list[k + 1][1].position = position;
						}
						else
						{
							joinType = JoinType.Bevel;
						}
					}
					if (joinType == JoinType.Bevel)
					{
						if (num7 < vector6.magnitude / 2f && num7 < vector7.magnitude / 2f && num5 > (float)Math.PI / 6f)
						{
							if (num6 < 0f)
							{
								list[k][2].position = position;
								list[k + 1][1].position = position;
							}
							else
							{
								list[k][3].position = position2;
								list[k + 1][0].position = position2;
							}
						}
						UIVertex[] verts = new UIVertex[4]
						{
							list[k][2],
							list[k][3],
							list[k + 1][0],
							list[k + 1][1]
						};
						vh.AddUIVertexQuad(verts);
					}
				}
				vh.AddUIVertexQuad(list[k]);
			}
			if (endType == EndType.EndTypeArrow)
			{
				vh.AddUIVertexQuad(CreateArrowHead(list.Last()));
			}
		}

		private UIVertex[] CreateLineCap(Vector2 start, Vector2 end, SegmentType type)
		{
			switch (type)
			{
			case SegmentType.Start:
			{
				Vector2 start2 = start - (end - start).normalized * LineThickness / 2f;
				return CreateLineSegment(start2, start, SegmentType.Start);
			}
			case SegmentType.End:
			{
				Vector2 end2 = end + (end - start).normalized * LineThickness / 2f;
				return CreateLineSegment(end, end2, SegmentType.End);
			}
			default:
				Logging.Error(LogChannels.GUI, "Bad SegmentType passed in to CreateLineCap. Must be SegmentType.Start or SegmentType.End");
				return null;
			}
		}

		private UIVertex[] CreateArrowHead(UIVertex[] arrowSegment)
		{
			Vector2 vector = (arrowSegment[2].position - arrowSegment[1].position).normalized;
			Vector2 vector2 = arrowSegment[2].position - arrowSegment[3].position;
			Vector2 vector3 = new Vector2(arrowSegment[2].position.x, arrowSegment[2].position.y) + vector2 * -0.5f + vector * LineThickness * 0.25f;
			vector2 = vector2.normalized;
			Vector2 vector4 = vector3 - vector * LineThickness * 0.75f;
			Vector2 vector5 = vector4 + vector2 * LineThickness * 1.25f;
			Vector2 vector6 = vector3 + vector * LineThickness * 0.75f;
			Vector2 vector7 = vector4 - vector2 * LineThickness * 1.25f;
			Vector2[] uvs = arrowUvs;
			switch (mappingType)
			{
			case MappingType.MapTypeTile:
			{
				float num = (float)texture.width / (float)texture.height;
				float x = Vector2.Distance(vector4, vector6) / (num * LineThickness);
				uvs = new Vector2[4]
				{
					new Vector2(0f, 0.5f),
					new Vector2(0f, 1.75f),
					new Vector2(x, 0.5f),
					new Vector2(x, -0.75f)
				};
				break;
			}
			case MappingType.MapTypePlanarY:
				uvs = new Vector2[4]
				{
					new Vector2(0.25f, (vector4.y + _unOffsetY) * _yMapper),
					new Vector2(0.25f, (vector5.y + _unOffsetY) * _yMapper),
					new Vector2(0.75f, (vector6.y + _unOffsetY) * _yMapper),
					new Vector2(0.75f, (vector7.y + _unOffsetY) * _yMapper)
				};
				break;
			}
			return SetVbo(new Vector2[4] { vector4, vector5, vector6, vector7 }, uvs);
		}

		private UIVertex[] CreateLineSegment(Vector2 start, Vector2 end, SegmentType type)
		{
			Vector2[] array = middleUvs;
			if (mappingType != MappingType.MapTypeNormal)
			{
				float num = (float)texture.width / (float)texture.height;
				float x = Vector2.Distance(start, end) / (num * LineThickness);
				array = new Vector2[4]
				{
					new Vector2(0f, 0f),
					new Vector2(0f, 1f),
					new Vector2(x, 1f),
					new Vector2(x, 0f)
				};
			}
			else
			{
				switch (type)
				{
				case SegmentType.Start:
					array = startUvs;
					break;
				case SegmentType.End:
					array = endUvs;
					break;
				}
			}
			Vector2 vector = new Vector2(start.y - end.y, end.x - start.x).normalized * LineThickness / 2f;
			Vector2 vector2 = start - vector;
			Vector2 vector3 = start + vector;
			Vector2 vector4 = end + vector;
			Vector2 vector5 = end - vector;
			if (mappingType == MappingType.MapTypePlanarY)
			{
				array[0].Set(0.25f, (vector2.y + _unOffsetY) * _yMapper);
				array[1].Set(0.25f, (vector3.y + _unOffsetY) * _yMapper);
				array[2].Set(0.75f, (vector4.y + _unOffsetY) * _yMapper);
				array[3].Set(0.75f, (vector5.y + _unOffsetY) * _yMapper);
			}
			return SetVbo(new Vector2[4] { vector2, vector3, vector4, vector5 }, array);
		}

		private UIVertex[] SetVbo(Vector2[] vertices, Vector2[] uvs)
		{
			UIVertex[] array = new UIVertex[4];
			for (int i = 0; i < vertices.Length; i++)
			{
				UIVertex simpleVert = UIVertex.simpleVert;
				simpleVert.color = color;
				simpleVert.position = vertices[i];
				simpleVert.uv0 = uvs[i];
				array[i] = simpleVert;
			}
			return array;
		}
	}
}
