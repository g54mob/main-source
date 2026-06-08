using System;
using UnityEngine;

namespace Shapes
{
	[ExecuteInEditMode]
	[AddComponentMenu("Shapes/Triangle")]
	public class Triangle : ShapeRenderer
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

		[SerializeField]
		[ShapesColorField(true)]
		private Color colorB = Color.white;

		[SerializeField]
		[ShapesColorField(true)]
		private Color colorC = Color.white;

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

		public override bool HasDetailLevels => false;

		public override bool HasScaleModes => false;

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

		protected override void SetAllMaterialProperties()
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
		}

		protected override Mesh GetInitialMeshAsset()
		{
			return ShapesMeshUtils.TriangleMesh[0];
		}

		protected override Material[] GetMaterials()
		{
			return new Material[1] { ShapesMaterialUtils.matTriangle[base.BlendMode] };
		}

		protected override Bounds GetBounds()
		{
			Vector3 vector = Vector3.Min(Vector3.Min(a, b), c);
			Vector3 vector2 = Vector3.Max(Vector3.Max(a, b), c);
			return new Bounds((vector + vector2) / 2f, ShapesMath.Abs(vector2 - vector));
		}
	}
}
