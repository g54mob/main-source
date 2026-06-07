using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Shapes
{
	internal static class ShapesMaterialUtils
	{
		public static readonly int propZTest = Shader.PropertyToID("_ZTest");

		public static readonly int propZTestTMP = Shader.PropertyToID("unity_GUIZTestMode");

		public static readonly int propZOffsetFactor = Shader.PropertyToID("_ZOffsetFactor");

		public static readonly int propZOffsetUnits = Shader.PropertyToID("_ZOffsetUnits");

		public static readonly int propStencilComp = Shader.PropertyToID("_StencilComp");

		public static readonly int propStencilOpPass = Shader.PropertyToID("_StencilOpPass");

		public static readonly int propStencilID = Shader.PropertyToID("_StencilID");

		public static readonly int propStencilIDTMP = Shader.PropertyToID("_Stencil");

		public static readonly int propStencilReadMask = Shader.PropertyToID("_StencilReadMask");

		public static readonly int propStencilWriteMask = Shader.PropertyToID("_StencilWriteMask");

		public static readonly int propBaseColor = Shader.PropertyToID("_BaseColor");

		public static readonly int propColor = Shader.PropertyToID("_Color");

		public static readonly int propScaleMode = Shader.PropertyToID("_ScaleMode");

		public static readonly int propColorEnd = Shader.PropertyToID("_ColorEnd");

		public static readonly int propColorOuterStart = Shader.PropertyToID("_ColorOuterStart");

		public static readonly int propColorInnerEnd = Shader.PropertyToID("_ColorInnerEnd");

		public static readonly int propColorOuterEnd = Shader.PropertyToID("_ColorOuterEnd");

		public static readonly int propColorB = Shader.PropertyToID("_ColorB");

		public static readonly int propColorC = Shader.PropertyToID("_ColorC");

		public static readonly int propColorD = Shader.PropertyToID("_ColorD");

		public static readonly int propPointStart = Shader.PropertyToID("_PointStart");

		public static readonly int propPointEnd = Shader.PropertyToID("_PointEnd");

		public static readonly int propA = Shader.PropertyToID("_A");

		public static readonly int propB = Shader.PropertyToID("_B");

		public static readonly int propC = Shader.PropertyToID("_C");

		public static readonly int propD = Shader.PropertyToID("_D");

		public static readonly int propRect = Shader.PropertyToID("_Rect");

		public static readonly int propRadius = Shader.PropertyToID("_Radius");

		public static readonly int propCornerRadii = Shader.PropertyToID("_CornerRadii");

		public static readonly int propLength = Shader.PropertyToID("_Length");

		public static readonly int propBorder = Shader.PropertyToID("_Hollow");

		public static readonly int propSides = Shader.PropertyToID("_Sides");

		public static readonly int propAng = Shader.PropertyToID("_Angle");

		public static readonly int propRoundness = Shader.PropertyToID("_Roundness");

		public static readonly int propAngStart = Shader.PropertyToID("_AngleStart");

		public static readonly int propAngEnd = Shader.PropertyToID("_AngleEnd");

		public static readonly int propRoundCaps = Shader.PropertyToID("_RoundCaps");

		public static readonly int propThickness = Shader.PropertyToID("_Thickness");

		public static readonly int propThicknessSpace = Shader.PropertyToID("_ThicknessSpace");

		public static readonly int propRadiusSpace = Shader.PropertyToID("_RadiusSpace");

		public static readonly int propDashSize = Shader.PropertyToID("_DashSize");

		public static readonly int propDashOffset = Shader.PropertyToID("_DashOffset");

		public static readonly int propDashSpacing = Shader.PropertyToID("_DashSpacing");

		public static readonly int propDashType = Shader.PropertyToID("_DashType");

		public static readonly int propDashSpace = Shader.PropertyToID("_DashSpace");

		public static readonly int propDashSnap = Shader.PropertyToID("_DashSnap");

		public static readonly int propDashShapeModifier = Shader.PropertyToID("_DashShapeModifier");

		public static readonly int propSize = Shader.PropertyToID("_Size");

		public static readonly int propSizeSpace = Shader.PropertyToID("_SizeSpace");

		public static readonly int propAlignment = Shader.PropertyToID("_Alignment");

		public static readonly int propFillType = Shader.PropertyToID("_FillType");

		public static readonly int propFillStart = Shader.PropertyToID("_FillStart");

		public static readonly int propFillEnd = Shader.PropertyToID("_FillEnd");

		public static readonly int propFillSpace = Shader.PropertyToID("_FillSpace");

		public static readonly int propMainTex = Shader.PropertyToID("_MainTex");

		public static readonly int propUvs = Shader.PropertyToID("_Uvs");

		private static readonly ShapesMaterials matDisc = new ShapesMaterials("Disc");

		private static readonly ShapesMaterials matCircleSector = new ShapesMaterials("Disc", "SECTOR");

		private static readonly ShapesMaterials matRing = new ShapesMaterials("Disc", "INNER_RADIUS");

		private static readonly ShapesMaterials matRingSector = new ShapesMaterials("Disc", "INNER_RADIUS", "SECTOR");

		private static readonly ShapesMaterials matRectSimple = new ShapesMaterials("Rect");

		private static readonly ShapesMaterials matRectRounded = new ShapesMaterials("Rect", "CORNER_RADIUS");

		private static readonly ShapesMaterials matRectBorder = new ShapesMaterials("Rect", "BORDERED");

		private static readonly ShapesMaterials matRectBorderRounded = new ShapesMaterials("Rect", "CORNER_RADIUS", "BORDERED");

		public static readonly ShapesMaterials matTriangle = new ShapesMaterials("Triangle");

		public static readonly ShapesMaterials matQuad = new ShapesMaterials("Quad");

		public static readonly ShapesMaterials matSphere = new ShapesMaterials("Sphere");

		public static readonly ShapesMaterials matCone = new ShapesMaterials("Cone");

		public static readonly ShapesMaterials matCuboid = new ShapesMaterials("Cuboid");

		public static readonly ShapesMaterials matTorus = new ShapesMaterials("Torus");

		public static readonly ShapesMaterials matPolygon = new ShapesMaterials("Polygon");

		public static readonly ShapesMaterials matRegularPolygon = new ShapesMaterials("Regular Polygon");

		public static readonly ShapesMaterials matTexture = new ShapesMaterials("Texture");

		private static readonly ShapesMaterials[] matsLine = new ShapesMaterials[3]
		{
			new ShapesMaterials("Line 2D"),
			new ShapesMaterials("Line 2D", "CAP_SQUARE"),
			new ShapesMaterials("Line 2D", "CAP_ROUND")
		};

		private static readonly ShapesMaterials[] matsLine3D = new ShapesMaterials[3]
		{
			new ShapesMaterials("Line 3D"),
			new ShapesMaterials("Line 3D", "CAP_SQUARE"),
			new ShapesMaterials("Line 3D", "CAP_ROUND")
		};

		private static readonly ShapesMaterials[] matsPolyline = new ShapesMaterials[4]
		{
			new ShapesMaterials("Polyline 2D"),
			new ShapesMaterials("Polyline 2D", "JOIN_MITER"),
			new ShapesMaterials("Polyline 2D", "JOIN_ROUND"),
			new ShapesMaterials("Polyline 2D", "JOIN_BEVEL")
		};

		private static readonly ShapesMaterials[] matsPolylineJoin = new ShapesMaterials[4]
		{
			new ShapesMaterials("Polyline 2D", "IS_JOIN_MESH"),
			new ShapesMaterials("Polyline 2D", "IS_JOIN_MESH", "JOIN_MITER"),
			new ShapesMaterials("Polyline 2D", "IS_JOIN_MESH", "JOIN_ROUND"),
			new ShapesMaterials("Polyline 2D", "IS_JOIN_MESH", "JOIN_BEVEL")
		};

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ShapesMaterials GetDiscMaterial(bool hollow, bool sector)
		{
			if (hollow)
			{
				if (!sector)
				{
					return matRing;
				}
				return matRingSector;
			}
			if (!sector)
			{
				return matDisc;
			}
			return matCircleSector;
		}

		public static ShapesMaterials GetDiscMaterial(DiscType type)
		{
			return Load();
			ShapesMaterials Load()
			{
				return type switch
				{
					DiscType.Disc => matDisc, 
					DiscType.Pie => matCircleSector, 
					DiscType.Ring => matRing, 
					DiscType.Arc => matRingSector, 
					_ => throw new IndexOutOfRangeException($"Failed to get disc material, invalid enum index of {(int)type} "), 
				};
			}
		}

		public static ShapesMaterials GetRectMaterial(bool hollow, bool rounded)
		{
			if (hollow)
			{
				if (!rounded)
				{
					return matRectBorder;
				}
				return matRectBorderRounded;
			}
			if (!rounded)
			{
				return matRectSimple;
			}
			return matRectRounded;
		}

		public static ShapesMaterials GetRectMaterial(Rectangle.RectangleType type)
		{
			return type switch
			{
				Rectangle.RectangleType.HardSolid => matRectSimple, 
				Rectangle.RectangleType.RoundedSolid => matRectRounded, 
				Rectangle.RectangleType.HardBorder => matRectBorder, 
				Rectangle.RectangleType.RoundedBorder => matRectBorderRounded, 
				_ => null, 
			};
		}

		public static ShapesMaterials GetPolylineMat(PolylineJoins join)
		{
			return matsPolyline[(int)join];
		}

		public static ShapesMaterials GetPolylineJoinsMat(PolylineJoins join)
		{
			return matsPolylineJoin[(int)join];
		}

		public static ShapesMaterials GetLineMat(LineGeometry geometry, LineEndCap cap)
		{
			switch (geometry)
			{
			case LineGeometry.Flat2D:
			case LineGeometry.Billboard:
				return matsLine[(int)cap];
			case LineGeometry.Volumetric3D:
				return matsLine3D[(int)cap];
			default:
				throw new ArgumentOutOfRangeException("geometry", geometry, null);
			}
		}
	}
}
