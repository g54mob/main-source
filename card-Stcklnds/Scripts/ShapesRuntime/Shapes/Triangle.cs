using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shapes
{
	[ExecuteAlways]
	[AddComponentMenu("Shapes/Triangle")]
	public class Triangle : ShapeRenderer, IDashable
	{
		public enum TriangleColorMode
		{
			Single = 0,
			PerCorner = 1
		}

		[SerializeField]
		private TriangleColorMode colorMode;

		[SerializeField]
		private Vector3 a = Vector3.zero;

		[SerializeField]
		private Vector3 b = Vector3.up;

		[SerializeField]
		private Vector3 c = Vector3.right;

		[FormerlySerializedAs("hollow")]
		[SerializeField]
		private bool border;

		[SerializeField]
		private float thickness = 0.5f;

		[SerializeField]
		private ThicknessSpace thicknessSpace;

		[SerializeField]
		[Range(0f, 1f)]
		private float roundness;

		[SerializeField]
		[ShapesColorField(true)]
		private Color colorB = Color.white;

		[SerializeField]
		[ShapesColorField(true)]
		private Color colorC = Color.white;

		[SerializeField]
		private bool matchDashSpacingToSize = true;

		[SerializeField]
		private bool dashed;

		[SerializeField]
		private DashStyle dashStyle = DashStyle.defaultDashStyleRing;

		public Vector3 this[int index]
		{
			get
			{
				return index switch
				{
					0 => A, 
					1 => B, 
					2 => C, 
					_ => throw new IndexOutOfRangeException($"Triangle only has four vertices, 0 to 2, you tried to access element {index}"), 
				};
			}
			set
			{
				switch (index)
				{
				case 0:
					A = value;
					break;
				case 1:
					B = value;
					break;
				case 2:
					C = value;
					break;
				default:
					throw new IndexOutOfRangeException($"Triangle only has four vertices, 0 to 2, you tried to set element {index}");
				}
			}
		}

		public TriangleColorMode ColorMode
		{
			get
			{
				return colorMode;
			}
			set
			{
				colorMode = value;
				ApplyProperties();
			}
		}

		public Vector3 A
		{
			get
			{
				return a;
			}
			set
			{
				SetVector3Now(ShapesMaterialUtils.propA, a = value);
			}
		}

		public Vector3 B
		{
			get
			{
				return b;
			}
			set
			{
				SetVector3Now(ShapesMaterialUtils.propB, b = value);
			}
		}

		public Vector3 C
		{
			get
			{
				return c;
			}
			set
			{
				SetVector3Now(ShapesMaterialUtils.propC, c = value);
			}
		}

		public bool Border
		{
			get
			{
				return border;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propBorder, (border = value).AsInt());
			}
		}

		[Obsolete("Please use Triangle.Border instead", true)]
		public bool Hollow
		{
			get
			{
				return Border;
			}
			set
			{
				Border = value;
			}
		}

		public float Thickness
		{
			get
			{
				return thickness;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propThickness, thickness = Mathf.Max(0f, value));
			}
		}

		public ThicknessSpace ThicknessSpace
		{
			get
			{
				return thicknessSpace;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propThicknessSpace, (int)(thicknessSpace = value));
			}
		}

		public float Roundness
		{
			get
			{
				return roundness;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propRoundness, roundness = Mathf.Clamp01(value));
			}
		}

		public override Color Color
		{
			get
			{
				return color;
			}
			set
			{
				SetColor(ShapesMaterialUtils.propColor, color = value);
				SetColor(ShapesMaterialUtils.propColorB, colorB = value);
				SetColorNow(ShapesMaterialUtils.propColorC, colorC = value);
			}
		}

		public Color ColorA
		{
			get
			{
				return color;
			}
			set
			{
				SetColorNow(ShapesMaterialUtils.propColor, color = value);
			}
		}

		public Color ColorB
		{
			get
			{
				return colorB;
			}
			set
			{
				SetColorNow(ShapesMaterialUtils.propColorB, colorB = value);
			}
		}

		public Color ColorC
		{
			get
			{
				return colorC;
			}
			set
			{
				SetColorNow(ShapesMaterialUtils.propColorC, colorC = value);
			}
		}

		internal override bool HasDetailLevels => false;

		public bool MatchDashSpacingToSize
		{
			get
			{
				return matchDashSpacingToSize;
			}
			set
			{
				matchDashSpacingToSize = value;
				SetAllDashValues(now: true);
			}
		}

		public bool Dashed
		{
			get
			{
				return dashed;
			}
			set
			{
				dashed = value;
				SetAllDashValues(now: true);
			}
		}

		public float DashSize
		{
			get
			{
				return dashStyle.size;
			}
			set
			{
				dashStyle.size = value;
				float netAbsoluteSize = dashStyle.GetNetAbsoluteSize(dashed, thickness);
				if (matchDashSpacingToSize)
				{
					SetFloat(ShapesMaterialUtils.propDashSpacing, GetNetDashSpacing());
				}
				SetFloatNow(ShapesMaterialUtils.propDashSize, netAbsoluteSize);
			}
		}

		public float DashSpacing
		{
			get
			{
				if (!matchDashSpacingToSize)
				{
					return dashStyle.spacing;
				}
				return dashStyle.size;
			}
			set
			{
				dashStyle.spacing = value;
				SetFloatNow(ShapesMaterialUtils.propDashSpacing, GetNetDashSpacing());
			}
		}

		public float DashOffset
		{
			get
			{
				return dashStyle.offset;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propDashOffset, dashStyle.offset = value);
			}
		}

		public DashSpace DashSpace
		{
			get
			{
				return dashStyle.space;
			}
			set
			{
				SetInt(ShapesMaterialUtils.propDashSpace, (int)(dashStyle.space = value));
				SetFloatNow(ShapesMaterialUtils.propDashSize, dashStyle.GetNetAbsoluteSize(dashed, thickness));
			}
		}

		public DashSnapping DashSnap
		{
			get
			{
				return dashStyle.snap;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propDashSnap, (int)(dashStyle.snap = value));
			}
		}

		public DashType DashType
		{
			get
			{
				return dashStyle.type;
			}
			set
			{
				SetIntNow(ShapesMaterialUtils.propDashType, (int)(dashStyle.type = value));
			}
		}

		public float DashShapeModifier
		{
			get
			{
				return dashStyle.shapeModifier;
			}
			set
			{
				SetFloatNow(ShapesMaterialUtils.propDashShapeModifier, dashStyle.shapeModifier = value);
			}
		}

		public Vector3 GetTriangleVertex(int index)
		{
			return this[index];
		}

		public Vector3 SetTriangleVertex(int index, Vector3 value)
		{
			return this[index] = value;
		}

		public Color GetTriangleColor(int index)
		{
			return index switch
			{
				0 => Color, 
				1 => ColorB, 
				2 => ColorC, 
				_ => throw new IndexOutOfRangeException($"Triangle only has four vertices, 0 to 2, you tried to access element {index}"), 
			};
		}

		public void SetTriangleColor(int index, Color color)
		{
			switch (index)
			{
			case 0:
				Color = color;
				break;
			case 1:
				ColorB = color;
				break;
			case 2:
				ColorC = color;
				break;
			default:
				throw new IndexOutOfRangeException($"Triangle only has four vertices, 0 to 3, you tried to set element {index}");
			}
		}

		private protected override void SetAllMaterialProperties()
		{
			SetVector3(ShapesMaterialUtils.propA, a);
			SetVector3(ShapesMaterialUtils.propB, b);
			SetVector3(ShapesMaterialUtils.propC, c);
			if (colorMode == TriangleColorMode.Single)
			{
				SetColor(ShapesMaterialUtils.propColorB, Color);
				SetColor(ShapesMaterialUtils.propColorC, Color);
			}
			else
			{
				SetColor(ShapesMaterialUtils.propColorB, colorB);
				SetColor(ShapesMaterialUtils.propColorC, colorC);
			}
			SetFloat(ShapesMaterialUtils.propRoundness, roundness);
			SetFloat(ShapesMaterialUtils.propThickness, thickness);
			SetFloat(ShapesMaterialUtils.propThicknessSpace, (float)thicknessSpace);
			SetFloat(ShapesMaterialUtils.propBorder, border.AsInt());
			SetAllDashValues(now: false);
		}

		private protected override Mesh GetInitialMeshAsset()
		{
			return ShapesMeshUtils.TriangleMesh[0];
		}

		private protected override Material[] GetMaterials()
		{
			return new Material[1] { ShapesMaterialUtils.matTriangle[base.BlendMode] };
		}

		private protected override Bounds GetBounds_Internal()
		{
			Vector3 vector = Vector3.Min(Vector3.Min(a, b), c);
			Vector3 vector2 = Vector3.Max(Vector3.Max(a, b), c);
			return new Bounds((vector + vector2) / 2f, ShapesMath.Abs(vector2 - vector));
		}

		private void SetAllDashValues(bool now)
		{
			SetAllDashValues(dashStyle, Dashed, matchDashSpacingToSize, thickness, setType: true, now);
		}

		private float GetNetDashSpacing()
		{
			return GetNetDashSpacing(dashStyle, dashed, matchDashSpacingToSize, thickness);
		}
	}
}
