using System;
using UnityEngine;

namespace Shapes
{
	[ExecuteInEditMode]
	[AddComponentMenu("Shapes/Quad")]
	public class Quad : ShapeRenderer
	{
		public enum QuadColorMode
		{
			Single = 0,
			Horizontal = 1,
			Vertical = 2,
			PerCorner = 3
		}

		[SerializeField]
		private QuadColorMode colorMode;

		[SerializeField]
		private Vector3 a = new Vector2(-0.5f, -0.5f);

		[SerializeField]
		private Vector3 b = new Vector2(-0.5f, 0.5f);

		[SerializeField]
		private Vector3 c = new Vector2(0.5f, 0.5f);

		[SerializeField]
		private Vector3 d = new Vector2(0.5f, -0.5f);

		[SerializeField]
		private bool autoSetD;

		[SerializeField]
		[ShapesColorField(true)]
		private Color colorB = Color.white;

		[SerializeField]
		[ShapesColorField(true)]
		private Color colorC = Color.white;

		[SerializeField]
		[ShapesColorField(true)]
		private Color colorD = Color.white;

		public Vector3 this[int index]
		{
			get
			{
				return index switch
				{
					0 => A, 
					1 => B, 
					2 => C, 
					3 => D, 
					_ => throw new IndexOutOfRangeException($"Quad only has four vertices, 0 to 3, you tried to access element {index}"), 
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
				case 3:
					D = value;
					break;
				default:
					throw new IndexOutOfRangeException($"Quad only has four vertices, 0 to 3, you tried to set element {index}");
				}
			}
		}

		public QuadColorMode ColorMode
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
				CheckAutoSetD();
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
				CheckAutoSetD();
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
				CheckAutoSetD();
			}
		}

		public Vector3 D
		{
			get
			{
				return d;
			}
			set
			{
				if (autoSetD)
				{
					Debug.LogWarning("tried to set D when auto-set is enabled, you might want to turn off auto-set on this object", base.gameObject);
				}
				else
				{
					SetVector3Now(ShapesMaterialUtils.propD, d = value);
				}
			}
		}

		public Vector3 DAuto => A + (C - B);

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
				SetColor(ShapesMaterialUtils.propColorC, colorC = value);
				SetColorNow(ShapesMaterialUtils.propColorD, colorD = value);
			}
		}

		public Color ColorLeft
		{
			get
			{
				return color;
			}
			set
			{
				SetColor(ShapesMaterialUtils.propColor, color = value);
				SetColorNow(ShapesMaterialUtils.propColorB, colorB = value);
			}
		}

		public Color ColorTop
		{
			get
			{
				return colorB;
			}
			set
			{
				SetColor(ShapesMaterialUtils.propColorB, colorB = value);
				SetColorNow(ShapesMaterialUtils.propColorC, colorC = value);
			}
		}

		public Color ColorRight
		{
			get
			{
				return colorC;
			}
			set
			{
				SetColor(ShapesMaterialUtils.propColorC, colorC = value);
				SetColorNow(ShapesMaterialUtils.propColorD, colorD = value);
			}
		}

		public Color ColorBottom
		{
			get
			{
				return colorD;
			}
			set
			{
				SetColor(ShapesMaterialUtils.propColorD, colorD = value);
				SetColorNow(ShapesMaterialUtils.propColor, color = value);
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

		public Color ColorD
		{
			get
			{
				return colorD;
			}
			set
			{
				SetColorNow(ShapesMaterialUtils.propColorD, colorD = value);
			}
		}

		public override bool HasDetailLevels => false;

		public override bool HasScaleModes => false;

		public Vector3 GetQuadVertex(int index)
		{
			return this[index];
		}

		public Vector3 SetQuadVertex(int index, Vector3 value)
		{
			return this[index] = value;
		}

		public Color GetQuadColor(int index)
		{
			return index switch
			{
				0 => Color, 
				1 => ColorB, 
				2 => ColorC, 
				3 => ColorD, 
				_ => throw new IndexOutOfRangeException($"Quad only has four vertices, 0 to 3, you tried to access element {index}"), 
			};
		}

		public void SetQuadColor(int index, Color color)
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
			case 3:
				ColorD = color;
				break;
			default:
				throw new IndexOutOfRangeException($"Quad only has four vertices, 0 to 3, you tried to set element {index}");
			}
		}

		private void AutoSetD()
		{
			SetVector3(ShapesMaterialUtils.propD, DAuto);
		}

		private void CheckAutoSetD()
		{
			if (autoSetD)
			{
				AutoSetD();
			}
		}

		protected override void SetAllMaterialProperties()
		{
			SetVector3(ShapesMaterialUtils.propA, a);
			SetVector3(ShapesMaterialUtils.propB, b);
			SetVector3(ShapesMaterialUtils.propC, c);
			if (autoSetD)
			{
				AutoSetD();
			}
			else
			{
				SetVector3(ShapesMaterialUtils.propD, d);
			}
			switch (colorMode)
			{
			case QuadColorMode.Single:
				SetColor(ShapesMaterialUtils.propColorB, Color);
				SetColor(ShapesMaterialUtils.propColorC, Color);
				SetColor(ShapesMaterialUtils.propColorD, Color);
				break;
			case QuadColorMode.Horizontal:
				SetColor(ShapesMaterialUtils.propColorB, Color);
				SetColor(ShapesMaterialUtils.propColorC, colorC);
				SetColor(ShapesMaterialUtils.propColorD, colorC);
				break;
			case QuadColorMode.Vertical:
				SetColor(ShapesMaterialUtils.propColor, colorD);
				SetColor(ShapesMaterialUtils.propColorB, colorB);
				SetColor(ShapesMaterialUtils.propColorC, colorB);
				SetColor(ShapesMaterialUtils.propColorD, colorD);
				break;
			case QuadColorMode.PerCorner:
				SetColor(ShapesMaterialUtils.propColorB, colorB);
				SetColor(ShapesMaterialUtils.propColorC, colorC);
				SetColor(ShapesMaterialUtils.propColorD, colorD);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		protected override Mesh GetInitialMeshAsset()
		{
			return ShapesMeshUtils.QuadMesh[0];
		}

		protected override Material[] GetMaterials()
		{
			return new Material[1] { ShapesMaterialUtils.matQuad[base.BlendMode] };
		}

		protected override Bounds GetBounds()
		{
			Vector3 vector = Vector3.Min(Vector3.Min(a, b), c);
			Vector3 vector2 = Vector3.Max(Vector3.Max(a, b), c);
			return new Bounds((vector + vector2) / 2f, ShapesMath.Abs(vector2 - vector));
		}
	}
}
