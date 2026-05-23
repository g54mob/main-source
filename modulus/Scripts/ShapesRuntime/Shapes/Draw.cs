using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Shapes
{
	public static class Draw
	{
		private delegate void OnPreRenderTmpDelegate(TextMeshPro tmp);

		private const MethodImplOptions INLINE = MethodImplOptions.AggressiveInlining;

		private static MpbLine2D mpbLine;

		private static MpbPolyline2D mpbPolyline;

		private static MpbPolyline2D mpbPolylineJoins;

		private static MpbPolygon mpbPolygon;

		private static readonly MpbDisc mpbDisc;

		private static readonly MpbRegularPolygon mpbRegularPolygon;

		private static readonly MpbRect mpbRect;

		private static MpbTriangle mpbTriangle;

		private static MpbQuad mpbQuad;

		private static readonly MpbSphere metaMpbSphere;

		private static readonly MpbCone mpbCone;

		private static readonly MpbCuboid mpbCuboid;

		private static MpbTorus mpbTorus;

		private static MpbText mpbText;

		private static OnPreRenderTmpDelegate onPreRenderTmp;

		private static MpbCustomMesh mpbCustomMesh;

		private static MpbTexture mpbTexture;

		private const string OBS_DASH = "As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle";

		private const string OBS_FILL = "As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill";

		private const string OBS_REGPOLRENAME = "For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead";

		private const string OBS_TRIRENAME = "For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.TriangleBorder instead";

		private const string JOINER = ". In addition: ";

		private const string OBS_REGPOLRENAME_AND_FILL = "As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead";

		private const string OBS_DISC_GRADIENT_PREFIX = "As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.";

		private const string OBS_DISC_GRADIENT_DISC_RADIAL = "As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Radial(...) )";

		private const string OBS_DISC_GRADIENT_DISC_ANGULAR = "As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Angular(...) )";

		private const string OBS_DISC_GRADIENT_DISC_BILINEAR = "As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Bilinear(...) )";

		private const string OBS_DISC_GRADIENT_RING_RADIAL = "As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) )";

		private const string OBS_DISC_GRADIENT_RING_ANGULAR = "As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) )";

		private const string OBS_DISC_GRADIENT_RING_BILINEAR = "As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) )";

		private const string OBS_DISC_GRADIENT_PIE_RADIAL = "As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Radial(...) )";

		private const string OBS_DISC_GRADIENT_PIE_ANGULAR = "As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Angular(...) )";

		private const string OBS_DISC_GRADIENT_PIE_BILINEAR = "As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Bilinear(...) )";

		private const string OBS_DISC_GRADIENT_ARC_RADIAL = "As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )";

		private const string OBS_DISC_GRADIENT_ARC_ANGULAR = "As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )";

		private const string OBS_DISC_GRADIENT_ARC_BILINEAR = "As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )";

		private static Matrix4x4 matrix;

		internal static DrawStyle style;

		private static OnPreRenderTmpDelegate OnPreRenderTmp
		{
			get
			{
				if (onPreRenderTmp == null)
				{
					onPreRenderTmp = (OnPreRenderTmpDelegate)typeof(TextMeshPro).GetMethod("OnPreRenderObject", BindingFlags.Instance | BindingFlags.NonPublic).CreateDelegate(typeof(OnPreRenderTmpDelegate));
				}
				return onPreRenderTmp;
			}
		}

		public static StateStack Scope => new StateStack(style, matrix);

		public static Matrix4x4 Matrix
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return matrix;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				matrix = value;
			}
		}

		public static MatrixStack MatrixScope => new MatrixStack(Matrix);

		public static Vector3 Position
		{
			get
			{
				return new Vector3(matrix.m03, matrix.m13, matrix.m23);
			}
			set
			{
				matrix.m03 = value.x;
				matrix.m13 = value.y;
				matrix.m23 = value.z;
			}
		}

		public static Vector2 Position2D
		{
			get
			{
				return new Vector2(matrix.m03, matrix.m13);
			}
			set
			{
				matrix.m03 = value.x;
				matrix.m13 = value.y;
			}
		}

		[Obsolete("Please use Draw.Position instead (I done messed up, did a typo, I'm sorry~)", true)]
		public static Vector3 Postition
		{
			get
			{
				return Position;
			}
			set
			{
				Position = value;
			}
		}

		[Obsolete("Please use Draw.Position2D instead (I done messed up, did a typo, I'm sorry~)", true)]
		public static Vector2 Postition2D
		{
			get
			{
				return Position2D;
			}
			set
			{
				Position2D = value;
			}
		}

		public static Quaternion Rotation
		{
			get
			{
				return matrix.rotation;
			}
			set
			{
				MtxSetRotationKeepScale(ref matrix, value);
			}
		}

		public static float Angle2D
		{
			get
			{
				return ShapesMath.DirToAng(RightBasis);
			}
			set
			{
				MtxRotateZLhs(ref matrix, value - Angle2D);
			}
		}

		public static Vector3 Right => RightBasis.normalized;

		public static Vector3 Up => UpBasis.normalized;

		public static Vector3 Forward => ForwardBasis.normalized;

		public static Vector3 RightBasis => matrix.GetColumn(0);

		public static Vector3 UpBasis => matrix.GetColumn(1);

		public static Vector3 ForwardBasis => matrix.GetColumn(2);

		public static Vector3 LocalScale
		{
			get
			{
				return new Vector3(RightBasis.magnitude, UpBasis.magnitude, ForwardBasis.magnitude);
			}
			set
			{
				float x = value.x / RightBasis.magnitude;
				float y = value.y / UpBasis.magnitude;
				float z = value.z / ForwardBasis.magnitude;
				Scale(x, y, z);
			}
		}

		public static StyleStack StyleScope => new StyleStack(style);

		public static ColorStack ColorScope => new ColorStack(style.color);

		public static CompareFunction ZTest
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.renderState.zTest;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.renderState.zTest = value;
			}
		}

		public static float ZOffsetFactor
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.renderState.zOffsetFactor;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.renderState.zOffsetFactor = value;
			}
		}

		public static int ZOffsetUnits
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.renderState.zOffsetUnits;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.renderState.zOffsetUnits = value;
			}
		}

		public static ColorWriteMask ColorMask
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.renderState.colorMask;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.renderState.colorMask = value;
			}
		}

		public static CompareFunction StencilComp
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.renderState.stencilComp;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.renderState.stencilComp = value;
			}
		}

		public static StencilOp StencilOpPass
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.renderState.stencilOpPass;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.renderState.stencilOpPass = value;
			}
		}

		public static byte StencilRefID
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.renderState.stencilRefID;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.renderState.stencilRefID = value;
			}
		}

		public static byte StencilReadMask
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.renderState.stencilReadMask;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.renderState.stencilReadMask = value;
			}
		}

		public static byte StencilWriteMask
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.renderState.stencilWriteMask;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.renderState.stencilWriteMask = value;
			}
		}

		public static Color Color
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.color;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.color = value;
			}
		}

		public static float Opacity
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Color.a;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				Color color = Color;
				color.a = value;
				Color = color;
			}
		}

		public static ShapesBlendMode BlendMode
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.blendMode;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.blendMode = value;
			}
		}

		public static ScaleMode ScaleMode
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.scaleMode;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.scaleMode = value;
			}
		}

		public static DetailLevel DetailLevel
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.detailLevel;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.detailLevel = value;
			}
		}

		public static float Thickness
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.thickness;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.thickness = value;
			}
		}

		public static float Radius
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.radius;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.radius = value;
			}
		}

		public static ThicknessSpace ThicknessSpace
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.thicknessSpace;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.thicknessSpace = value;
			}
		}

		public static ThicknessSpace RadiusSpace
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.radiusSpace;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.radiusSpace = value;
			}
		}

		public static ThicknessSpace SizeSpace
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.sizeSpace;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.sizeSpace = value;
			}
		}

		public static bool UseGradientFill
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.useGradients;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.useGradients = value;
			}
		}

		public static GradientFill GradientFill
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.gradientFill;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.gradientFill = value;
			}
		}

		public static FillType GradientFillType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.gradientFill.type;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.gradientFill.type = value;
			}
		}

		public static FillSpace GradientFillSpace
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.gradientFill.space;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.gradientFill.space = value;
			}
		}

		public static Color GradientFillColorStart
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.gradientFill.colorStart;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.gradientFill.colorStart = value;
			}
		}

		public static Color GradientFillColorEnd
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.gradientFill.colorEnd;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.gradientFill.colorEnd = value;
			}
		}

		public static Vector3 GradientFillLinearStart
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.gradientFill.linearStart;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.gradientFill.linearStart = value;
			}
		}

		public static Vector3 GradientFillLinearEnd
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.gradientFill.linearEnd;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.gradientFill.linearEnd = value;
			}
		}

		public static Vector3 GradientFillRadialOrigin
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.gradientFill.radialOrigin;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.gradientFill.radialOrigin = value;
			}
		}

		public static float GradientFillRadialRadius
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.gradientFill.radialRadius;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.gradientFill.radialRadius = value;
			}
		}

		public static bool UseDashes
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.useDashes;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.useDashes = value;
			}
		}

		public static DashStyle DashStyle
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.dashStyle;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.dashStyle = value;
			}
		}

		public static DashType DashType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.dashStyle.type;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.dashStyle.type = value;
			}
		}

		public static DashSpace DashSpace
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.dashStyle.space;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.dashStyle.space = value;
			}
		}

		public static DashSnapping DashSnap
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.dashStyle.snap;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.dashStyle.snap = value;
			}
		}

		public static float DashSize
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.dashStyle.size;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.dashStyle.size = value;
			}
		}

		public static float DashSizeUniform
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.dashStyle.size;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.dashStyle.size = value;
				style.dashStyle.spacing = ((style.dashStyle.space == DashSpace.FixedCount) ? 0.5f : value);
			}
		}

		public static float DashSpacing
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.dashStyle.spacing;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.dashStyle.spacing = value;
			}
		}

		public static float DashOffset
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.dashStyle.offset;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.dashStyle.offset = value;
			}
		}

		public static float DashShapeModifier
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.dashStyle.shapeModifier;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.dashStyle.shapeModifier = value;
			}
		}

		public static LineEndCap LineEndCaps
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.lineEndCaps;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.lineEndCaps = value;
			}
		}

		public static LineGeometry LineGeometry
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.lineGeometry;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.lineGeometry = value;
			}
		}

		public static PolygonTriangulation PolygonTriangulation
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.polygonTriangulation;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.polygonTriangulation = value;
			}
		}

		public static PolylineGeometry PolylineGeometry
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.polylineGeometry;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.polylineGeometry = value;
			}
		}

		public static PolylineJoins PolylineJoins
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.polylineJoins;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.polylineJoins = value;
			}
		}

		public static DiscGeometry DiscGeometry
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.discGeometry;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.discGeometry = value;
			}
		}

		public static int RegularPolygonSideCount
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.regularPolygonSideCount;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.regularPolygonSideCount = value;
			}
		}

		public static RegularPolygonGeometry RegularPolygonGeometry
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.regularPolygonGeometry;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.regularPolygonGeometry = value;
			}
		}

		public static TextStyle TextStyle
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.textStyle;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.textStyle = value;
			}
		}

		public static TMP_FontAsset Font
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.textStyle.font;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.textStyle.font = value;
			}
		}

		public static float FontSize
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.textStyle.size;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.textStyle.size = value;
			}
		}

		public static FontStyles FontStyle
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.textStyle.style;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.textStyle.style = value;
			}
		}

		public static TextAlign TextAlign
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.textStyle.alignment;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.textStyle.alignment = value;
			}
		}

		public static float TextCharacterSpacing
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.textStyle.characterSpacing;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.textStyle.characterSpacing = value;
			}
		}

		public static float TextWordSpacing
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.textStyle.wordSpacing;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.textStyle.wordSpacing = value;
			}
		}

		public static float TextLineSpacing
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.textStyle.lineSpacing;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.textStyle.lineSpacing = value;
			}
		}

		public static float TextParagraphSpacing
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.textStyle.paragraphSpacing;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.textStyle.paragraphSpacing = value;
			}
		}

		public static Vector4 TextMargins
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.textStyle.margins;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.textStyle.margins = value;
			}
		}

		public static bool TextWrap
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.textStyle.wrap;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.textStyle.wrap = value;
			}
		}

		public static TextOverflowModes TextOverflow
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return style.textStyle.overflow;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				style.textStyle.overflow = value;
			}
		}

		[Obsolete("All shapes now use the same static Thickness property", true)]
		public static float LineThickness
		{
			get
			{
				return style.thickness;
			}
			set
			{
				style.thickness = value;
			}
		}

		[Obsolete("All shapes now use the same static ThicknessSpace property", true)]
		public static ThicknessSpace LineThicknessSpace
		{
			get
			{
				return style.thicknessSpace;
			}
			set
			{
				style.thicknessSpace = value;
			}
		}

		[Obsolete("All shapes now use the same static DashStyle property by default, when UseDashes is enabled", true)]
		public static DashStyle LineDashStyle
		{
			get
			{
				return style.dashStyle;
			}
			set
			{
				style.dashStyle = value;
			}
		}

		[Obsolete("All shapes now use the same static Radius property", true)]
		public static float DiscRadius
		{
			get
			{
				return style.radius;
			}
			set
			{
				style.radius = value;
			}
		}

		[Obsolete("All shapes now use the same static DashStyle property by default, when UseDashes is enabled", true)]
		public static DashStyle RingDashStyle
		{
			get
			{
				return style.dashStyle;
			}
			set
			{
				style.dashStyle = value;
			}
		}

		[Obsolete("All shapes now use the same static GradientFill property by default. If you want to override shape fill per shape, use the draw overload with a fill input", true)]
		public static GradientFill PolygonShapeFill
		{
			get
			{
				return style.gradientFill;
			}
			set
			{
				style.gradientFill = value;
			}
		}

		[Obsolete("All shapes now use the same static GradientFill property by default. If you want to override shape fill per shape, use the draw overload with a fill input", true)]
		public static GradientFill RegularPolygonShapeFill
		{
			get
			{
				return style.gradientFill;
			}
			set
			{
				style.gradientFill = value;
			}
		}

		[Obsolete("All shapes now use the same static GradientFill property by default. If you want to override shape fill per shape, use the draw overload with a fill input", true)]
		public static GradientFill RectangleShapeFill
		{
			get
			{
				return style.gradientFill;
			}
			set
			{
				style.gradientFill = value;
			}
		}

		[Obsolete("All shapes now use the same static Thickness property", true)]
		public static float RingThickness
		{
			get
			{
				return style.thickness;
			}
			set
			{
				style.thickness = value;
			}
		}

		[Obsolete("All shapes now use the same static ThicknessSpace property", true)]
		public static ThicknessSpace RingThicknessSpace
		{
			get
			{
				return style.thicknessSpace;
			}
			set
			{
				style.thicknessSpace = value;
			}
		}

		[Obsolete("All shapes now use the same static RadiusSpace property", true)]
		public static ThicknessSpace DiscRadiusSpace
		{
			get
			{
				return style.radiusSpace;
			}
			set
			{
				style.radiusSpace = value;
			}
		}

		[Obsolete("All shapes now use the same static Radius property", true)]
		public static float RegularPolygonRadius
		{
			get
			{
				return style.radius;
			}
			set
			{
				style.radius = value;
			}
		}

		[Obsolete("All shapes now use the same static Thickness property", true)]
		public static float RegularPolygonThickness
		{
			get
			{
				return style.thickness;
			}
			set
			{
				style.thickness = value;
			}
		}

		[Obsolete("All shapes now use the same static ThicknessSpace property", true)]
		public static ThicknessSpace RegularPolygonThicknessSpace
		{
			get
			{
				return style.thicknessSpace;
			}
			set
			{
				style.thicknessSpace = value;
			}
		}

		[Obsolete("All shapes now use the same static RadiusSpace property", true)]
		public static ThicknessSpace RegularPolygonRadiusSpace
		{
			get
			{
				return style.radiusSpace;
			}
			set
			{
				style.radiusSpace = value;
			}
		}

		[Obsolete("All shapes now use the same static Thickness property", true)]
		public static float RectangleThickness
		{
			get
			{
				return style.thickness;
			}
			set
			{
				style.thickness = value;
			}
		}

		[Obsolete("All shapes now use the same static ThicknessSpace property", true)]
		public static ThicknessSpace RectangleThicknessSpace
		{
			get
			{
				return style.thicknessSpace;
			}
			set
			{
				style.thicknessSpace = value;
			}
		}

		[Obsolete("All shapes now use the same static Thickness property", true)]
		public static float TriangleThickness
		{
			get
			{
				return style.thickness;
			}
			set
			{
				style.thickness = value;
			}
		}

		[Obsolete("All shapes now use the same static ThicknessSpace property", true)]
		public static ThicknessSpace TriangleThicknessSpace
		{
			get
			{
				return style.thicknessSpace;
			}
			set
			{
				style.thicknessSpace = value;
			}
		}

		[Obsolete("All shapes now use the same static Radius property", true)]
		public static float SphereRadius
		{
			get
			{
				return style.radius;
			}
			set
			{
				style.radius = value;
			}
		}

		[Obsolete("All shapes now use the same static RadiusSpace property", true)]
		public static ThicknessSpace SphereRadiusSpace
		{
			get
			{
				return style.radiusSpace;
			}
			set
			{
				style.radiusSpace = value;
			}
		}

		[Obsolete("All shapes now use the same static SizeSpace property", true)]
		public static ThicknessSpace CuboidSizeSpace
		{
			get
			{
				return style.sizeSpace;
			}
			set
			{
				style.sizeSpace = value;
			}
		}

		[Obsolete("All shapes now use the same static ThicknessSpace property", true)]
		public static ThicknessSpace TorusThicknessSpace
		{
			get
			{
				return style.thicknessSpace;
			}
			set
			{
				style.thicknessSpace = value;
			}
		}

		[Obsolete("All shapes now use the same static RadiusSpace property", true)]
		public static ThicknessSpace TorusRadiusSpace
		{
			get
			{
				return style.radiusSpace;
			}
			set
			{
				style.radiusSpace = value;
			}
		}

		[Obsolete("All shapes now use the same static SizeSpace property", true)]
		public static ThicknessSpace ConeSizeSpace
		{
			get
			{
				return style.sizeSpace;
			}
			set
			{
				style.sizeSpace = value;
			}
		}

		public static DrawCommand Command(Camera cam, RenderPassEvent cameraEvent = RenderPassEvent.BeforeRenderingPostProcessing)
		{
			return ObjectPool<DrawCommand>.Alloc().Initialize(cam, cameraEvent);
		}

		public static void PrepareForIMGUI()
		{
			float num = Screen.width;
			float num2 = Screen.height;
			float num3 = num;
			float num4 = num2;
			Shader.SetGlobalVector(value: new Vector4(num3, num4, 1f + 1f / num3, 1f + 1f / num4), nameID: ShapesMaterialUtils.propScreenParams);
		}

		[OvldGenCallTarget]
		private static void Line_Internal([OvldDefault("LineEndCaps")] LineEndCap endCaps, [OvldDefault("ThicknessSpace")] ThicknessSpace thicknessSpace, Vector3 start, Vector3 end, [OvldDefault("Color")] Color colorStart, [OvldDefault("Color")] Color colorEnd, [OvldDefault("Thickness")] float thickness)
		{
			using (new IMDrawer(mpbLine, ShapesMaterialUtils.GetLineMat(LineGeometry, endCaps)[BlendMode], ShapesMeshUtils.GetLineMesh(LineGeometry, endCaps, DetailLevel)))
			{
				MetaMpb.ApplyDashSettings(mpbLine, thickness);
				mpbLine.color.Add(colorStart.ColorSpaceAdjusted());
				mpbLine.colorEnd.Add(colorEnd.ColorSpaceAdjusted());
				mpbLine.pointStart.Add(start);
				mpbLine.pointEnd.Add(end);
				mpbLine.thickness.Add(thickness);
				mpbLine.alignment.Add((float)LineGeometry);
				mpbLine.thicknessSpace.Add((float)thicknessSpace);
				mpbLine.scaleMode.Add((float)ScaleMode);
			}
		}

		[OvldGenCallTarget]
		private static void Polyline_Internal(PolylinePath path, [OvldDefault("false")] bool closed, [OvldDefault("PolylineGeometry")] PolylineGeometry geometry, [OvldDefault("PolylineJoins")] PolylineJoins joins, [OvldDefault("Thickness")] float thickness, [OvldDefault("ThicknessSpace")] ThicknessSpace thicknessSpace, [OvldDefault("Color")] Color color)
		{
			if (!path.EnsureMeshIsReadyToRender(closed, joins, out var outMesh))
			{
				return;
			}
			switch (path.Count)
			{
			case 0:
				Debug.LogWarning("Tried to draw polyline with no points");
				return;
			case 1:
				Debug.LogWarning("Tried to draw polyline with only one point");
				return;
			}
			if (DrawCommand.IsAddingDrawCommandsToBuffer)
			{
				path.RegisterToCommandBuffer(DrawCommand.CurrentWritingCommandBuffer);
			}
			using (new IMDrawer(mpbPolyline, ShapesMaterialUtils.GetPolylineMat(joins)[BlendMode], outMesh))
			{
				ApplyToMpb(mpbPolyline);
			}
			if (!joins.HasJoinMesh())
			{
				return;
			}
			using (new IMDrawer(mpbPolylineJoins, ShapesMaterialUtils.GetPolylineJoinsMat(joins)[BlendMode], outMesh, 1))
			{
				ApplyToMpb(mpbPolylineJoins);
			}
			void ApplyToMpb(MpbPolyline2D mpb)
			{
				mpb.thickness.Add(thickness);
				mpb.thicknessSpace.Add((float)thicknessSpace);
				mpb.color.Add(color.ColorSpaceAdjusted());
				mpb.alignment.Add((float)geometry);
				mpb.scaleMode.Add((float)ScaleMode);
			}
		}

		[OvldGenCallTarget]
		private static void Polygon_Internal(PolygonPath path, [OvldDefault("PolygonTriangulation")] PolygonTriangulation triangulation, [OvldDefault("Color")] Color color)
		{
			if (!path.EnsureMeshIsReadyToRender(triangulation, out var outMesh))
			{
				return;
			}
			switch (path.Count)
			{
			case 0:
				Debug.LogWarning("Tried to draw polygon with no points");
				return;
			case 1:
				Debug.LogWarning("Tried to draw polygon with only one point");
				return;
			case 2:
				Debug.LogWarning("Tried to draw polygon with only two points");
				return;
			}
			if (DrawCommand.IsAddingDrawCommandsToBuffer)
			{
				path.RegisterToCommandBuffer(DrawCommand.CurrentWritingCommandBuffer);
			}
			using (new IMDrawer(mpbPolygon, ShapesMaterialUtils.matPolygon[BlendMode], outMesh))
			{
				MetaMpb.ApplyColorOrFill(mpbPolygon, color);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[OvldGenCallTarget]
		private static void Disc_Internal([OvldDefault("Radius")] float radius, [OvldDefault("Color")] DiscColors colors)
		{
			DiscCore(hollow: false, sector: false, radius, 0f, colors);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[OvldGenCallTarget]
		private static void Ring_Internal([OvldDefault("Radius")] float radius, [OvldDefault("Thickness")] float thickness, [OvldDefault("Color")] DiscColors colors)
		{
			DiscCore(hollow: true, sector: false, radius, thickness, colors);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[OvldGenCallTarget]
		private static void Pie_Internal([OvldDefault("Radius")] float radius, [OvldDefault("Color")] DiscColors colors, float angleRadStart, float angleRadEnd)
		{
			DiscCore(hollow: false, sector: true, radius, 0f, colors, angleRadStart, angleRadEnd);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[OvldGenCallTarget]
		private static void Arc_Internal([OvldDefault("Radius")] float radius, [OvldDefault("Thickness")] float thickness, [OvldDefault("Color")] DiscColors colors, float angleRadStart, float angleRadEnd, [OvldDefault("ArcEndCap.None")] ArcEndCap endCaps)
		{
			DiscCore(hollow: true, sector: true, radius, thickness, colors, angleRadStart, angleRadEnd, endCaps);
		}

		private static void DiscCore(bool hollow, bool sector, float radius, float thickness, DiscColors colors, float angleRadStart = 0f, float angleRadEnd = 0f, ArcEndCap arcEndCaps = ArcEndCap.None)
		{
			if (sector && Mathf.Abs(angleRadEnd - angleRadStart) < 0.0001f)
			{
				return;
			}
			using (new IMDrawer(mpbDisc, ShapesMaterialUtils.GetDiscMaterial(hollow, sector)[BlendMode], ShapesMeshUtils.QuadMesh[0]))
			{
				MetaMpb.ApplyDashSettings(mpbDisc, thickness);
				mpbDisc.radius.Add(radius);
				mpbDisc.radiusSpace.Add((float)RadiusSpace);
				mpbDisc.alignment.Add((float)DiscGeometry);
				mpbDisc.thicknessSpace.Add((float)ThicknessSpace);
				mpbDisc.thickness.Add(thickness);
				mpbDisc.scaleMode.Add((float)ScaleMode);
				mpbDisc.angleStart.Add(angleRadStart);
				mpbDisc.angleEnd.Add(angleRadEnd);
				mpbDisc.roundCaps.Add((float)arcEndCaps);
				mpbDisc.color.Add(colors.innerStart.ColorSpaceAdjusted());
				mpbDisc.colorOuterStart.Add(colors.outerStart.ColorSpaceAdjusted());
				mpbDisc.colorInnerEnd.Add(colors.innerEnd.ColorSpaceAdjusted());
				mpbDisc.colorOuterEnd.Add(colors.outerEnd.ColorSpaceAdjusted());
			}
		}

		[OvldGenCallTarget]
		private static void RegularPolygon_Internal([OvldDefault("RegularPolygonSideCount")] int sideCount, [OvldDefault("Radius")] float radius, [OvldDefault("Thickness")] float thickness, [OvldDefault("Color")] Color color, bool hollow, [OvldDefault("0f")] float roundness, [OvldDefault("0f")] float angle)
		{
			using (new IMDrawer(mpbRegularPolygon, ShapesMaterialUtils.matRegularPolygon[BlendMode], ShapesMeshUtils.QuadMesh[0]))
			{
				MetaMpb.ApplyColorOrFill(mpbRegularPolygon, color);
				MetaMpb.ApplyDashSettings(mpbRegularPolygon, thickness);
				mpbRegularPolygon.radius.Add(radius);
				mpbRegularPolygon.radiusSpace.Add((float)RadiusSpace);
				mpbRegularPolygon.alignment.Add((float)RegularPolygonGeometry);
				mpbRegularPolygon.sides.Add(Mathf.Max(3, sideCount));
				mpbRegularPolygon.angle.Add(angle);
				mpbRegularPolygon.roundness.Add(roundness);
				mpbRegularPolygon.hollow.Add(hollow.AsInt());
				mpbRegularPolygon.thicknessSpace.Add((float)ThicknessSpace);
				mpbRegularPolygon.thickness.Add(thickness);
				mpbRegularPolygon.scaleMode.Add((float)ScaleMode);
			}
		}

		[OvldGenCallTarget]
		private static void Rectangle_Internal([OvldDefault("BlendMode")] ShapesBlendMode blendMode, [OvldDefault("false")] bool hollow, Rect rect, [OvldDefault("Color")] Color color, [OvldDefault("Thickness")] float thickness, [OvldDefault("default")] Vector4 cornerRadii)
		{
			bool rounded = ShapesMath.MaxComp(cornerRadii) >= 0.0001f;
			if (rect.width < 0f)
			{
				rect.x -= (rect.width *= -1f);
			}
			if (rect.height < 0f)
			{
				rect.y -= (rect.height *= -1f);
			}
			using (new IMDrawer(mpbRect, ShapesMaterialUtils.GetRectMaterial(hollow, rounded)[blendMode], ShapesMeshUtils.QuadMesh[0]))
			{
				MetaMpb.ApplyColorOrFill(mpbRect, color);
				MetaMpb.ApplyDashSettings(mpbRect, thickness);
				mpbRect.rect.Add(rect.ToVector4());
				mpbRect.cornerRadii.Add(cornerRadii);
				mpbRect.thickness.Add(thickness);
				mpbRect.thicknessSpace.Add((float)ThicknessSpace);
				mpbRect.scaleMode.Add((float)ScaleMode);
			}
		}

		[OvldGenCallTarget]
		private static void Triangle_Internal(Vector3 a, Vector3 b, Vector3 c, bool hollow, [OvldDefault("Thickness")] float thickness, [OvldDefault("0f")] float roundness, [OvldDefault("Color")] Color colorA, [OvldDefault("Color")] Color colorB, [OvldDefault("Color")] Color colorC)
		{
			using (new IMDrawer(mpbTriangle, ShapesMaterialUtils.matTriangle[BlendMode], ShapesMeshUtils.TriangleMesh[0]))
			{
				MetaMpb.ApplyDashSettings(mpbTriangle, thickness);
				mpbTriangle.a.Add(a);
				mpbTriangle.b.Add(b);
				mpbTriangle.c.Add(c);
				mpbTriangle.color.Add(colorA.ColorSpaceAdjusted());
				mpbTriangle.colorB.Add(colorB.ColorSpaceAdjusted());
				mpbTriangle.colorC.Add(colorC.ColorSpaceAdjusted());
				mpbTriangle.roundness.Add(roundness);
				mpbTriangle.hollow.Add(hollow.AsInt());
				mpbTriangle.thicknessSpace.Add((float)ThicknessSpace);
				mpbTriangle.thickness.Add(thickness);
				mpbTriangle.scaleMode.Add((float)ScaleMode);
			}
		}

		[OvldGenCallTarget]
		private static void Quad_Internal(Vector3 a, Vector3 b, Vector3 c, [OvldDefault("a + ( c - b )")] Vector3 d, [OvldDefault("Color")] Color colorA, [OvldDefault("Color")] Color colorB, [OvldDefault("Color")] Color colorC, [OvldDefault("Color")] Color colorD)
		{
			using (new IMDrawer(mpbQuad, ShapesMaterialUtils.matQuad[BlendMode], ShapesMeshUtils.QuadMesh[0]))
			{
				mpbQuad.a.Add(a);
				mpbQuad.b.Add(b);
				mpbQuad.c.Add(c);
				mpbQuad.d.Add(d);
				mpbQuad.color.Add(colorA.ColorSpaceAdjusted());
				mpbQuad.colorB.Add(colorB.ColorSpaceAdjusted());
				mpbQuad.colorC.Add(colorC.ColorSpaceAdjusted());
				mpbQuad.colorD.Add(colorD.ColorSpaceAdjusted());
			}
		}

		[OvldGenCallTarget]
		private static void Sphere_Internal([OvldDefault("Radius")] float radius, [OvldDefault("Color")] Color color)
		{
			using (new IMDrawer(metaMpbSphere, ShapesMaterialUtils.matSphere[BlendMode], ShapesMeshUtils.SphereMesh[(int)DetailLevel]))
			{
				metaMpbSphere.color.Add(color.ColorSpaceAdjusted());
				metaMpbSphere.radius.Add(radius);
				metaMpbSphere.radiusSpace.Add((float)RadiusSpace);
			}
		}

		[OvldGenCallTarget]
		private static void Cone_Internal(float radius, float length, [OvldDefault("true")] bool fillCap, [OvldDefault("Color")] Color color)
		{
			Mesh sourceMesh = (fillCap ? ShapesMeshUtils.ConeMesh[(int)DetailLevel] : ShapesMeshUtils.ConeMeshUncapped[(int)DetailLevel]);
			using (new IMDrawer(mpbCone, ShapesMaterialUtils.matCone[BlendMode], sourceMesh))
			{
				mpbCone.color.Add(color.ColorSpaceAdjusted());
				mpbCone.radius.Add(radius);
				mpbCone.length.Add(length);
				mpbCone.sizeSpace.Add((float)SizeSpace);
			}
		}

		[OvldGenCallTarget]
		private static void Cuboid_Internal(Vector3 size, [OvldDefault("Color")] Color color)
		{
			using (new IMDrawer(mpbCuboid, ShapesMaterialUtils.matCuboid[BlendMode], ShapesMeshUtils.CuboidMesh[0]))
			{
				mpbCuboid.color.Add(color.ColorSpaceAdjusted());
				mpbCuboid.size.Add(size);
				mpbCuboid.sizeSpace.Add((float)SizeSpace);
			}
		}

		[OvldGenCallTarget]
		private static void Torus_Internal(float radius, float thickness, [OvldDefault("0")] float angleRadStart, [OvldDefault("ShapesMath.TAU")] float angleRadEnd, [OvldDefault("Color")] Color color)
		{
			if (thickness < 0.0001f)
			{
				return;
			}
			if (radius < 1E-05f)
			{
				ThicknessSpace radiusSpace = RadiusSpace;
				RadiusSpace = ThicknessSpace;
				Sphere(thickness / 2f, color);
				RadiusSpace = radiusSpace;
				return;
			}
			using (new IMDrawer(mpbTorus, ShapesMaterialUtils.matTorus[BlendMode], ShapesMeshUtils.TorusMesh[(int)DetailLevel]))
			{
				mpbTorus.color.Add(color.ColorSpaceAdjusted());
				mpbTorus.radius.Add(radius);
				mpbTorus.thickness.Add(thickness);
				mpbTorus.radiusSpace.Add((float)RadiusSpace);
				mpbTorus.thicknessSpace.Add((float)ThicknessSpace);
				mpbTorus.scaleMode.Add((float)ScaleMode);
				mpbTorus.angleStart.Add(angleRadStart);
				mpbTorus.angleEnd.Add(angleRadEnd);
			}
		}

		[OvldGenCallTarget]
		private static void TextRect_Internal(string content, [OvldDefault("null")] TextElement element, Rect rect, [OvldDefault("Font")] TMP_FontAsset font, [OvldDefault("FontSize")] float fontSize, [OvldDefault("TextAlign")] TextAlign align, [OvldDefault("Color")] Color color)
		{
			PushMatrix();
			Translate(rect.x, rect.y);
			Text_Internal(isRect: true, content, element, default(Vector2), rect.size, font, fontSize, align, color);
			PopMatrix();
		}

		[OvldGenCallTarget]
		private static void Text_Internal(bool isRect, string content, [OvldDefault("null")] TextElement element, [OvldDefault("default")] Vector2 pivot, [OvldDefault("default")] Vector2 size, [OvldDefault("Font")] TMP_FontAsset font, [OvldDefault("FontSize")] float fontSize, [OvldDefault("TextAlign")] TextAlign align, [OvldDefault("Color")] Color color)
		{
			int num;
			TextMeshPro tmp;
			IMDrawer.DrawType drawType;
			if (element == null)
			{
				num = TextElement.GetNextId();
				tmp = ShapesTextPool.Instance.AllocateElement(num);
				drawType = IMDrawer.DrawType.TextPooledAuto;
			}
			else
			{
				num = element.id;
				tmp = element.Tmp;
				drawType = IMDrawer.DrawType.TextPooledPersistent;
			}
			ApplyTextValuesToInstance(tmp, isRect, content, font, fontSize, align, pivot, size, color);
			Text_Internal(tmp, drawType, num);
		}

		private static void ApplyTextValuesToInstance(TextMeshPro tmp, bool isRect, string content, TMP_FontAsset font, float fontSize, TextAlign align, Vector2 pivot, Vector2 size, Color color)
		{
			tmp.fontStyle = FontStyle;
			tmp.characterSpacing = TextCharacterSpacing;
			tmp.wordSpacing = TextWordSpacing;
			tmp.lineSpacing = TextLineSpacing;
			tmp.paragraphSpacing = TextParagraphSpacing;
			tmp.margin = TextMargins;
			tmp.font = font;
			tmp.color = color;
			tmp.fontSize = fontSize;
			tmp.alignment = align.GetTMPAlignment();
			tmp.text = content;
			if (isRect)
			{
				tmp.enableWordWrapping = TextWrap;
				tmp.overflowMode = TextOverflow;
				tmp.rectTransform.pivot = pivot;
				tmp.rectTransform.sizeDelta = size;
			}
			else
			{
				tmp.enableWordWrapping = false;
				tmp.overflowMode = TextOverflowModes.Overflow;
				tmp.rectTransform.sizeDelta = default(Vector2);
			}
			tmp.rectTransform.position = Matrix.GetColumn(3);
			tmp.rectTransform.rotation = Matrix.rotation;
			OnPreRenderTmp(tmp);
		}

		private static void Text_Internal(TextMeshPro tmp, IMDrawer.DrawType drawType, int disposeId = -1)
		{
			using (new IMDrawer(mpbText, tmp.fontSharedMaterial, tmp.mesh, 0, drawType, allowInstancing: false, disposeId))
			{
			}
			for (int i = 0; i < tmp.transform.childCount; i++)
			{
				tmp.transform.GetChild(i).GetComponent<TMP_SubMesh>().renderer.enabled = false;
			}
			if (tmp.textInfo.materialCount <= 1)
			{
				return;
			}
			for (int j = 0; j < tmp.transform.childCount; j++)
			{
				TMP_SubMesh component = tmp.transform.GetChild(j).GetComponent<TMP_SubMesh>();
				component.renderer.enabled = false;
				if (!(component.sharedMaterial == null))
				{
					using (new IMDrawer(mpbText, component.sharedMaterial, component.mesh, 0, drawType, allowInstancing: false))
					{
					}
				}
			}
		}

		public static void Mesh(Mesh mesh, Material mat)
		{
			CustomMesh_Internal(mesh, mat, null);
		}

		public static void Mesh(Mesh mesh, Material mat, MaterialPropertyBlock mpb)
		{
			CustomMesh_Internal(mesh, mat, mpb);
		}

		private static void CustomMesh_Internal(Mesh mesh, Material mat, MaterialPropertyBlock mpb)
		{
			using (new IMDrawer(mpbCustomMesh, mat, mesh, 0, IMDrawer.DrawType.Custom, allowInstancing: false))
			{
				mpbCustomMesh.mpbOverride = mpb;
			}
		}

		[OvldGenCallTarget]
		private static void Texture_Internal(Texture texture, Rect rect, Rect uvs, [OvldDefault("Color")] Color color)
		{
			if (texture == null)
			{
				return;
			}
			Material sourceMat = ShapesMaterialUtils.matTexture[BlendMode];
			if (mpbTexture.texture != null && mpbTexture.texture != texture)
			{
				DrawCommand.CurrentWritingCommandBuffer.drawCalls.Add(mpbTexture.ExtractDrawCall());
			}
			using (new IMDrawer(mpbTexture, sourceMat, ShapesMeshUtils.QuadMesh[0]))
			{
				mpbTexture.texture = texture;
				mpbTexture.color.Add(color.ColorSpaceAdjusted());
				mpbTexture.rect.Add(rect.ToVector4());
				mpbTexture.uvs.Add(uvs.ToVector4());
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void Texture_Placement_Internal(Texture texture, (Rect rect, Rect uvs) placement, Color color)
		{
			Texture_Internal(texture, placement.rect, placement.uvs, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[OvldGenCallTarget]
		private static void Texture_RectFill_Internal(Texture texture, Rect rect, [OvldDefault("TextureFillMode.ScaleToFit")] TextureFillMode fillMode, [OvldDefault("Color")] Color color)
		{
			Texture_Placement_Internal(texture, TexturePlacement.Fit(texture, rect, fillMode), color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[OvldGenCallTarget]
		private static void Texture_PosSize_Internal(Texture texture, Vector2 center, float size, [OvldDefault("TextureSizeMode.LongestSide")] TextureSizeMode sizeMode, [OvldDefault("Color")] Color color)
		{
			Texture_Placement_Internal(texture, TexturePlacement.Size(texture, center, size, sizeMode), color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Line(Vector3 start, Vector3 end)
		{
			Line_Internal(LineEndCaps, ThicknessSpace, start, end, Color, Color, Thickness);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Line(Vector3 start, Vector3 end, Color color)
		{
			Line_Internal(LineEndCaps, ThicknessSpace, start, end, color, color, Thickness);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Line(Vector3 start, Vector3 end, Color colorStart, Color colorEnd)
		{
			Line_Internal(LineEndCaps, ThicknessSpace, start, end, colorStart, colorEnd, Thickness);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Line(Vector3 start, Vector3 end, float thickness)
		{
			Line_Internal(LineEndCaps, ThicknessSpace, start, end, Color, Color, thickness);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Line(Vector3 start, Vector3 end, float thickness, Color color)
		{
			Line_Internal(LineEndCaps, ThicknessSpace, start, end, color, color, thickness);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Line(Vector3 start, Vector3 end, float thickness, Color colorStart, Color colorEnd)
		{
			Line_Internal(LineEndCaps, ThicknessSpace, start, end, colorStart, colorEnd, thickness);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Line(Vector3 start, Vector3 end, LineEndCap endCaps)
		{
			Line_Internal(endCaps, ThicknessSpace, start, end, Color, Color, Thickness);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Line(Vector3 start, Vector3 end, LineEndCap endCaps, Color color)
		{
			Line_Internal(endCaps, ThicknessSpace, start, end, color, color, Thickness);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Line(Vector3 start, Vector3 end, LineEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Line_Internal(endCaps, ThicknessSpace, start, end, colorStart, colorEnd, Thickness);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Line(Vector3 start, Vector3 end, float thickness, LineEndCap endCaps)
		{
			Line_Internal(endCaps, ThicknessSpace, start, end, Color, Color, thickness);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Line(Vector3 start, Vector3 end, float thickness, LineEndCap endCaps, Color color)
		{
			Line_Internal(endCaps, ThicknessSpace, start, end, color, color, thickness);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Line(Vector3 start, Vector3 end, float thickness, LineEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Line_Internal(endCaps, ThicknessSpace, start, end, colorStart, colorEnd, thickness);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path)
		{
			Polyline_Internal(path, closed: false, PolylineGeometry, PolylineJoins, Thickness, ThicknessSpace, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path, bool closed)
		{
			Polyline_Internal(path, closed, PolylineGeometry, PolylineJoins, Thickness, ThicknessSpace, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path, float thickness)
		{
			Polyline_Internal(path, closed: false, PolylineGeometry, PolylineJoins, thickness, ThicknessSpace, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path, bool closed, float thickness)
		{
			Polyline_Internal(path, closed, PolylineGeometry, PolylineJoins, thickness, ThicknessSpace, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path, PolylineJoins joins)
		{
			Polyline_Internal(path, closed: false, PolylineGeometry, joins, Thickness, ThicknessSpace, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path, bool closed, PolylineJoins joins)
		{
			Polyline_Internal(path, closed, PolylineGeometry, joins, Thickness, ThicknessSpace, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path, float thickness, PolylineJoins joins)
		{
			Polyline_Internal(path, closed: false, PolylineGeometry, joins, thickness, ThicknessSpace, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path, bool closed, float thickness, PolylineJoins joins)
		{
			Polyline_Internal(path, closed, PolylineGeometry, joins, thickness, ThicknessSpace, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path, Color color)
		{
			Polyline_Internal(path, closed: false, PolylineGeometry, PolylineJoins, Thickness, ThicknessSpace, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path, bool closed, Color color)
		{
			Polyline_Internal(path, closed, PolylineGeometry, PolylineJoins, Thickness, ThicknessSpace, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path, float thickness, Color color)
		{
			Polyline_Internal(path, closed: false, PolylineGeometry, PolylineJoins, thickness, ThicknessSpace, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path, bool closed, float thickness, Color color)
		{
			Polyline_Internal(path, closed, PolylineGeometry, PolylineJoins, thickness, ThicknessSpace, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path, PolylineJoins joins, Color color)
		{
			Polyline_Internal(path, closed: false, PolylineGeometry, joins, Thickness, ThicknessSpace, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path, bool closed, PolylineJoins joins, Color color)
		{
			Polyline_Internal(path, closed, PolylineGeometry, joins, Thickness, ThicknessSpace, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path, float thickness, PolylineJoins joins, Color color)
		{
			Polyline_Internal(path, closed: false, PolylineGeometry, joins, thickness, ThicknessSpace, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polyline(PolylinePath path, bool closed, float thickness, PolylineJoins joins, Color color)
		{
			Polyline_Internal(path, closed, PolylineGeometry, joins, thickness, ThicknessSpace, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polygon(PolygonPath path)
		{
			Polygon_Internal(path, PolygonTriangulation, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polygon(PolygonPath path, Color color)
		{
			Polygon_Internal(path, PolygonTriangulation, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polygon(PolygonPath path, PolygonTriangulation triangulation)
		{
			Polygon_Internal(path, triangulation, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Polygon(PolygonPath path, PolygonTriangulation triangulation, Color color)
		{
			Polygon_Internal(path, triangulation, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, Color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, float radius)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, float radius, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, float radius, float angle)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: false, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, float radius, float angle, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: false, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, float radius, float angle, float roundness)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: false, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, float radius, float angle, float roundness, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: false, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, int sideCount)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, Radius, Thickness, Color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, int sideCount, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, Radius, Thickness, color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, int sideCount, float radius)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, int sideCount, float radius, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, int sideCount, float radius, float angle)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: false, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, int sideCount, float radius, float angle, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: false, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, int sideCount, float radius, float angle, float roundness)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: false, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, int sideCount, float radius, float angle, float roundness, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: false, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, Color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal, float radius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal, float radius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal, float radius, float angle)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: false, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal, float radius, float angle, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: false, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal, float radius, float angle, float roundness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: false, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal, float radius, float angle, float roundness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: false, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, Radius, Thickness, Color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, Radius, Thickness, color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount, float radius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount, float radius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: false, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: false, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, float roundness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: false, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, float roundness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: false, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, Color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot, float radius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot, float radius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot, float radius, float angle)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: false, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot, float radius, float angle, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: false, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot, float radius, float angle, float roundness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: false, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot, float radius, float angle, float roundness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: false, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, Radius, Thickness, Color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, Radius, Thickness, color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount, float radius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount, float radius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: false, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: false, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: false, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, float roundness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: false, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, float roundness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: false, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon()
		{
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, Color, hollow: false, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(Color color)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, color, hollow: false, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(float radius)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: false, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(float radius, Color color)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: false, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(float radius, float angle)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: false, 0f, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(float radius, float angle, Color color)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: false, 0f, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(float radius, float angle, float roundness)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: false, roundness, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(float radius, float angle, float roundness, Color color)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: false, roundness, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(int sideCount)
		{
			RegularPolygon_Internal(sideCount, Radius, Thickness, Color, hollow: false, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(int sideCount, Color color)
		{
			RegularPolygon_Internal(sideCount, Radius, Thickness, color, hollow: false, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(int sideCount, float radius)
		{
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: false, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(int sideCount, float radius, Color color)
		{
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: false, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(int sideCount, float radius, float angle)
		{
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: false, 0f, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(int sideCount, float radius, float angle, Color color)
		{
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: false, 0f, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(int sideCount, float radius, float angle, float roundness)
		{
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: false, roundness, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygon(int sideCount, float radius, float angle, float roundness, Color color)
		{
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: false, roundness, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, float radius)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, float radius, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, float radius, float thickness)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, float radius, float thickness, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, float radius, float thickness, float angle)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, float radius, float thickness, float angle, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, color, hollow: true, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, float radius, float thickness, float angle, float roundness)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, float radius, float thickness, float angle, float roundness, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, color, hollow: true, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, int sideCount)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, Radius, Thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, int sideCount, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, Radius, Thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, int sideCount, float radius)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, int sideCount, float radius, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, int sideCount, float radius, float thickness)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, radius, thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, int sideCount, float radius, float thickness, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, radius, thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, int sideCount, float radius, float thickness, float angle)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, radius, thickness, Color, hollow: true, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, int sideCount, float radius, float thickness, float angle, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, radius, thickness, color, hollow: true, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, int sideCount, float radius, float thickness, float angle, float roundness)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, radius, thickness, Color, hollow: true, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, int sideCount, float radius, float thickness, float angle, float roundness, Color color)
		{
			PushMatrix();
			Translate(pos);
			RegularPolygon_Internal(sideCount, radius, thickness, color, hollow: true, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, float radius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, float radius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, float radius, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, float radius, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, float radius, float thickness, float angle)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, color, hollow: true, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, float roundness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, float roundness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, color, hollow: true, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, int sideCount)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, Radius, Thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, int sideCount, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, Radius, Thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, int sideCount, float radius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, int sideCount, float radius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, radius, thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, radius, thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, radius, thickness, Color, hollow: true, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, radius, thickness, color, hollow: true, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, float roundness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, radius, thickness, Color, hollow: true, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, float roundness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			RegularPolygon_Internal(sideCount, radius, thickness, color, hollow: true, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, float radius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, float radius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, float radius, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, float radius, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, float radius, float thickness, float angle)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, color, hollow: true, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, float roundness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, float roundness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, color, hollow: true, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, int sideCount)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, Radius, Thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, int sideCount, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, Radius, Thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, int sideCount, float radius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, int sideCount, float radius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, radius, thickness, Color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, radius, thickness, color, hollow: true, 0f, 0f);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, radius, thickness, Color, hollow: true, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, radius, thickness, color, hollow: true, 0f, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, float roundness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, radius, thickness, Color, hollow: true, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, float roundness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			RegularPolygon_Internal(sideCount, radius, thickness, color, hollow: true, roundness, angle);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder()
		{
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, Color, hollow: true, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(Color color)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, Radius, Thickness, color, hollow: true, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(float radius)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, Color, hollow: true, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(float radius, Color color)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, radius, Thickness, color, hollow: true, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(float radius, float thickness)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(float radius, float thickness, Color color)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, color, hollow: true, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(float radius, float thickness, float angle)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(float radius, float thickness, float angle, Color color)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, color, hollow: true, 0f, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(float radius, float thickness, float angle, float roundness)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(float radius, float thickness, float angle, float roundness, Color color)
		{
			RegularPolygon_Internal(RegularPolygonSideCount, radius, thickness, color, hollow: true, roundness, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(int sideCount)
		{
			RegularPolygon_Internal(sideCount, Radius, Thickness, Color, hollow: true, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(int sideCount, Color color)
		{
			RegularPolygon_Internal(sideCount, Radius, Thickness, color, hollow: true, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(int sideCount, float radius)
		{
			RegularPolygon_Internal(sideCount, radius, Thickness, Color, hollow: true, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(int sideCount, float radius, Color color)
		{
			RegularPolygon_Internal(sideCount, radius, Thickness, color, hollow: true, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(int sideCount, float radius, float thickness)
		{
			RegularPolygon_Internal(sideCount, radius, thickness, Color, hollow: true, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(int sideCount, float radius, float thickness, Color color)
		{
			RegularPolygon_Internal(sideCount, radius, thickness, color, hollow: true, 0f, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(int sideCount, float radius, float thickness, float angle)
		{
			RegularPolygon_Internal(sideCount, radius, thickness, Color, hollow: true, 0f, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(int sideCount, float radius, float thickness, float angle, Color color)
		{
			RegularPolygon_Internal(sideCount, radius, thickness, color, hollow: true, 0f, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(int sideCount, float radius, float thickness, float angle, float roundness)
		{
			RegularPolygon_Internal(sideCount, radius, thickness, Color, hollow: true, roundness, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RegularPolygonBorder(int sideCount, float radius, float thickness, float angle, float roundness, Color color)
		{
			RegularPolygon_Internal(sideCount, radius, thickness, color, hollow: true, roundness, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc(Vector3 pos)
		{
			PushMatrix();
			Translate(pos);
			Disc_Internal(Radius, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc(Vector3 pos, DiscColors colors)
		{
			PushMatrix();
			Translate(pos);
			Disc_Internal(Radius, colors);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc(Vector3 pos, float radius)
		{
			PushMatrix();
			Translate(pos);
			Disc_Internal(radius, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc(Vector3 pos, float radius, DiscColors colors)
		{
			PushMatrix();
			Translate(pos);
			Disc_Internal(radius, colors);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc(Vector3 pos, Vector3 normal)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Disc_Internal(Radius, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc(Vector3 pos, Vector3 normal, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Disc_Internal(Radius, colors);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc(Vector3 pos, Vector3 normal, float radius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Disc_Internal(radius, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc(Vector3 pos, Vector3 normal, float radius, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Disc_Internal(radius, colors);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc(Vector3 pos, Quaternion rot)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Disc_Internal(Radius, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc(Vector3 pos, Quaternion rot, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Disc_Internal(Radius, colors);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc(Vector3 pos, Quaternion rot, float radius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Disc_Internal(radius, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc(Vector3 pos, Quaternion rot, float radius, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Disc_Internal(radius, colors);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc()
		{
			Disc_Internal(Radius, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc(DiscColors colors)
		{
			Disc_Internal(Radius, colors);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc(float radius)
		{
			Disc_Internal(radius, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Disc(float radius, DiscColors colors)
		{
			Disc_Internal(radius, colors);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos)
		{
			PushMatrix();
			Translate(pos);
			Ring_Internal(Radius, Thickness, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, DiscColors colors)
		{
			PushMatrix();
			Translate(pos);
			Ring_Internal(Radius, Thickness, colors);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, float radius)
		{
			PushMatrix();
			Translate(pos);
			Ring_Internal(radius, Thickness, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, float radius, DiscColors colors)
		{
			PushMatrix();
			Translate(pos);
			Ring_Internal(radius, Thickness, colors);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, float radius, float thickness)
		{
			PushMatrix();
			Translate(pos);
			Ring_Internal(radius, thickness, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, float radius, float thickness, DiscColors colors)
		{
			PushMatrix();
			Translate(pos);
			Ring_Internal(radius, thickness, colors);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, Vector3 normal)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Ring_Internal(Radius, Thickness, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, Vector3 normal, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Ring_Internal(Radius, Thickness, colors);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, Vector3 normal, float radius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Ring_Internal(radius, Thickness, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, Vector3 normal, float radius, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Ring_Internal(radius, Thickness, colors);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, Vector3 normal, float radius, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Ring_Internal(radius, thickness, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, Vector3 normal, float radius, float thickness, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Ring_Internal(radius, thickness, colors);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, Quaternion rot)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Ring_Internal(Radius, Thickness, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, Quaternion rot, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Ring_Internal(Radius, Thickness, colors);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, Quaternion rot, float radius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Ring_Internal(radius, Thickness, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, Quaternion rot, float radius, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Ring_Internal(radius, Thickness, colors);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, Quaternion rot, float radius, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Ring_Internal(radius, thickness, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(Vector3 pos, Quaternion rot, float radius, float thickness, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Ring_Internal(radius, thickness, colors);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring()
		{
			Ring_Internal(Radius, Thickness, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(DiscColors colors)
		{
			Ring_Internal(Radius, Thickness, colors);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(float radius)
		{
			Ring_Internal(radius, Thickness, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(float radius, DiscColors colors)
		{
			Ring_Internal(radius, Thickness, colors);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(float radius, float thickness)
		{
			Ring_Internal(radius, thickness, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Ring(float radius, float thickness, DiscColors colors)
		{
			Ring_Internal(radius, thickness, colors);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(Vector3 pos, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Translate(pos);
			Pie_Internal(Radius, Color, angleRadStart, angleRadEnd);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(Vector3 pos, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			PushMatrix();
			Translate(pos);
			Pie_Internal(Radius, colors, angleRadStart, angleRadEnd);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(Vector3 pos, float radius, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Translate(pos);
			Pie_Internal(radius, Color, angleRadStart, angleRadEnd);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			PushMatrix();
			Translate(pos);
			Pie_Internal(radius, colors, angleRadStart, angleRadEnd);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Pie_Internal(Radius, Color, angleRadStart, angleRadEnd);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Pie_Internal(Radius, colors, angleRadStart, angleRadEnd);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Pie_Internal(radius, Color, angleRadStart, angleRadEnd);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Pie_Internal(radius, colors, angleRadStart, angleRadEnd);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Pie_Internal(Radius, Color, angleRadStart, angleRadEnd);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Pie_Internal(Radius, colors, angleRadStart, angleRadEnd);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Pie_Internal(radius, Color, angleRadStart, angleRadEnd);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Pie_Internal(radius, colors, angleRadStart, angleRadEnd);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(float angleRadStart, float angleRadEnd)
		{
			Pie_Internal(Radius, Color, angleRadStart, angleRadEnd);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			Pie_Internal(Radius, colors, angleRadStart, angleRadEnd);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(float radius, float angleRadStart, float angleRadEnd)
		{
			Pie_Internal(radius, Color, angleRadStart, angleRadEnd);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pie(float radius, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			Pie_Internal(radius, colors, angleRadStart, angleRadEnd);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Translate(pos);
			Arc_Internal(Radius, Thickness, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			PushMatrix();
			Translate(pos);
			Arc_Internal(Radius, Thickness, colors, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			PushMatrix();
			Translate(pos);
			Arc_Internal(Radius, Thickness, Color, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, DiscColors colors)
		{
			PushMatrix();
			Translate(pos);
			Arc_Internal(Radius, Thickness, colors, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, float radius, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Translate(pos);
			Arc_Internal(radius, Thickness, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			PushMatrix();
			Translate(pos);
			Arc_Internal(radius, Thickness, colors, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			PushMatrix();
			Translate(pos);
			Arc_Internal(radius, Thickness, Color, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, DiscColors colors)
		{
			PushMatrix();
			Translate(pos);
			Arc_Internal(radius, Thickness, colors, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Translate(pos);
			Arc_Internal(radius, thickness, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			PushMatrix();
			Translate(pos);
			Arc_Internal(radius, thickness, colors, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			PushMatrix();
			Translate(pos);
			Arc_Internal(radius, thickness, Color, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, DiscColors colors)
		{
			PushMatrix();
			Translate(pos);
			Arc_Internal(radius, thickness, colors, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Arc_Internal(Radius, Thickness, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Arc_Internal(Radius, Thickness, colors, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Arc_Internal(Radius, Thickness, Color, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Arc_Internal(Radius, Thickness, colors, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Arc_Internal(radius, Thickness, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Arc_Internal(radius, Thickness, colors, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Arc_Internal(radius, Thickness, Color, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Arc_Internal(radius, Thickness, colors, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Arc_Internal(radius, thickness, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Arc_Internal(radius, thickness, colors, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Arc_Internal(radius, thickness, Color, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Arc_Internal(radius, thickness, colors, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Arc_Internal(Radius, Thickness, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Arc_Internal(Radius, Thickness, colors, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Arc_Internal(Radius, Thickness, Color, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Arc_Internal(Radius, Thickness, colors, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Arc_Internal(radius, Thickness, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Arc_Internal(radius, Thickness, colors, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Arc_Internal(radius, Thickness, Color, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Arc_Internal(radius, Thickness, colors, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Arc_Internal(radius, thickness, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Arc_Internal(radius, thickness, colors, angleRadStart, angleRadEnd, ArcEndCap.None);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Arc_Internal(radius, thickness, Color, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, DiscColors colors)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Arc_Internal(radius, thickness, colors, angleRadStart, angleRadEnd, endCaps);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(float angleRadStart, float angleRadEnd)
		{
			Arc_Internal(Radius, Thickness, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			Arc_Internal(Radius, Thickness, colors, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc_Internal(Radius, Thickness, Color, angleRadStart, angleRadEnd, endCaps);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(float angleRadStart, float angleRadEnd, ArcEndCap endCaps, DiscColors colors)
		{
			Arc_Internal(Radius, Thickness, colors, angleRadStart, angleRadEnd, endCaps);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(float radius, float angleRadStart, float angleRadEnd)
		{
			Arc_Internal(radius, Thickness, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(float radius, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			Arc_Internal(radius, Thickness, colors, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc_Internal(radius, Thickness, Color, angleRadStart, angleRadEnd, endCaps);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, DiscColors colors)
		{
			Arc_Internal(radius, Thickness, colors, angleRadStart, angleRadEnd, endCaps);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			Arc_Internal(radius, thickness, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(float radius, float thickness, float angleRadStart, float angleRadEnd, DiscColors colors)
		{
			Arc_Internal(radius, thickness, colors, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc_Internal(radius, thickness, Color, angleRadStart, angleRadEnd, endCaps);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Arc(float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, DiscColors colors)
		{
			Arc_Internal(radius, thickness, colors, angleRadStart, angleRadEnd, endCaps);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Rect rect)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, rect, Color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Rect rect, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, rect, color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Rect rect, float cornerRadius)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, rect, Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Rect rect, float cornerRadius, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, rect, color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Rect rect, Vector4 cornerRadii)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, rect, Color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Rect rect, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, rect, color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Rect rect)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, rect, Color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Rect rect, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, rect, color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Rect rect, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, rect, Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Rect rect, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, rect, color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Rect rect, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, rect, Color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Rect rect, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, rect, color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Rect rect)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, rect, Color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Rect rect, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, rect, color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Rect rect, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, rect, Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Rect rect, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, rect, color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Rect rect, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, rect, Color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Rect rect, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, rect, color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector2 size)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), Color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector2 size, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector2 size, float cornerRadius)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector2 size, float cornerRadius, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector2 size, Vector4 cornerRadii)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), Color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector2 size, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, float width, float height)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), Color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, float width, float height, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, float width, float height, float cornerRadius)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, float width, float height, float cornerRadius, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, float width, float height, Vector4 cornerRadii)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), Color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, float width, float height, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), Color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), Color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), Color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), Color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), Color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), Color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(size), color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), Color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), Color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, RectPivot.Center.GetRect(width, height), color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Rect rect)
		{
			Rectangle_Internal(BlendMode, hollow: false, rect, Color, Thickness, default(Vector4));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Rect rect, Color color)
		{
			Rectangle_Internal(BlendMode, hollow: false, rect, color, Thickness, default(Vector4));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Rect rect, float cornerRadius)
		{
			Rectangle_Internal(BlendMode, hollow: false, rect, Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Rect rect, float cornerRadius, Color color)
		{
			Rectangle_Internal(BlendMode, hollow: false, rect, color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Rect rect, Vector4 cornerRadii)
		{
			Rectangle_Internal(BlendMode, hollow: false, rect, Color, Thickness, cornerRadii);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Rect rect, Vector4 cornerRadii, Color color)
		{
			Rectangle_Internal(BlendMode, hollow: false, rect, color, Thickness, cornerRadii);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector2 size, RectPivot pivot)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), Color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector2 size, RectPivot pivot, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector2 size, RectPivot pivot, float cornerRadius)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector2 size, RectPivot pivot, float cornerRadius, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector2 size, RectPivot pivot, Vector4 cornerRadii)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), Color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector2 size, RectPivot pivot, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, float width, float height, RectPivot pivot)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), Color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, float width, float height, RectPivot pivot, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, float width, float height, RectPivot pivot, float cornerRadius)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, float width, float height, RectPivot pivot, float cornerRadius, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, float width, float height, RectPivot pivot, Vector4 cornerRadii)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), Color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, float width, float height, RectPivot pivot, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), Color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), Color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), Color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), Color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), Color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), Color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(size), color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), Color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), color, Thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), Color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), color, Thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), Color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: false, pivot.GetRect(width, height), color, Thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Rect rect, float thickness)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, rect, Color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Rect rect, float thickness, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, rect, color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Rect rect, float thickness, float cornerRadius)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, rect, Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Rect rect, float thickness, float cornerRadius, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, rect, color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Rect rect, float thickness, Vector4 cornerRadii)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, rect, Color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Rect rect, float thickness, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, rect, color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Rect rect, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, rect, Color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Rect rect, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, rect, color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Rect rect, float thickness, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, rect, Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Rect rect, float thickness, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, rect, color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Rect rect, float thickness, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, rect, Color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Rect rect, float thickness, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, rect, color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Rect rect, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, rect, Color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Rect rect, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, rect, color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Rect rect, float thickness, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, rect, Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Rect rect, float thickness, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, rect, color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Rect rect, float thickness, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, rect, Color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Rect rect, float thickness, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, rect, color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector2 size, float thickness)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), Color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector2 size, float thickness, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector2 size, float thickness, float cornerRadius)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector2 size, float thickness, float cornerRadius, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector2 size, float thickness, Vector4 cornerRadii)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), Color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector2 size, float thickness, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, float width, float height, float thickness)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), Color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, float width, float height, float thickness, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, float width, float height, float thickness, float cornerRadius)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, float width, float height, float thickness, float cornerRadius, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, float width, float height, float thickness, Vector4 cornerRadii)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), Color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, float width, float height, float thickness, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), Color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, float thickness, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, float thickness, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, float thickness, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), Color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, float thickness, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), Color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, float thickness, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, float thickness, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, float thickness, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), Color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, float thickness, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), Color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, float thickness, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, float thickness, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, float thickness, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), Color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, float thickness, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(size), color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), Color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, float thickness, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, float thickness, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, float thickness, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), Color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, float thickness, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, RectPivot.Center.GetRect(width, height), color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Rect rect, float thickness)
		{
			Rectangle_Internal(BlendMode, hollow: true, rect, Color, thickness, default(Vector4));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Rect rect, float thickness, Color color)
		{
			Rectangle_Internal(BlendMode, hollow: true, rect, color, thickness, default(Vector4));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Rect rect, float thickness, float cornerRadius)
		{
			Rectangle_Internal(BlendMode, hollow: true, rect, Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Rect rect, float thickness, float cornerRadius, Color color)
		{
			Rectangle_Internal(BlendMode, hollow: true, rect, color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Rect rect, float thickness, Vector4 cornerRadii)
		{
			Rectangle_Internal(BlendMode, hollow: true, rect, Color, thickness, cornerRadii);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Rect rect, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle_Internal(BlendMode, hollow: true, rect, color, thickness, cornerRadii);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector2 size, RectPivot pivot, float thickness)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), Color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector2 size, RectPivot pivot, float thickness, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector2 size, RectPivot pivot, float thickness, float cornerRadius)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector2 size, RectPivot pivot, float thickness, float cornerRadius, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), Color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, float width, float height, RectPivot pivot, float thickness)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), Color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, float width, float height, RectPivot pivot, float thickness, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, float width, float height, RectPivot pivot, float thickness, float cornerRadius)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, float width, float height, RectPivot pivot, float thickness, float cornerRadius, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), Color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Translate(pos);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), Color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), Color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), Color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), Color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), Color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), Color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(size), color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), Color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), color, thickness, default(Vector4));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness, float cornerRadius)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness, float cornerRadius, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), Color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Rectangle_Internal(BlendMode, hollow: true, pivot.GetRect(width, height), color, thickness, cornerRadii);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Triangle(Vector3 a, Vector3 b, Vector3 c)
		{
			Triangle_Internal(a, b, c, hollow: false, Thickness, 0f, Color, Color, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Triangle(Vector3 a, Vector3 b, Vector3 c, Color color)
		{
			Triangle_Internal(a, b, c, hollow: false, Thickness, 0f, color, color, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Triangle(Vector3 a, Vector3 b, Vector3 c, Color colorA, Color colorB, Color colorC)
		{
			Triangle_Internal(a, b, c, hollow: false, Thickness, 0f, colorA, colorB, colorC);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Triangle(Vector3 a, Vector3 b, Vector3 c, float roundness)
		{
			Triangle_Internal(a, b, c, hollow: false, Thickness, roundness, Color, Color, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Triangle(Vector3 a, Vector3 b, Vector3 c, float roundness, Color color)
		{
			Triangle_Internal(a, b, c, hollow: false, Thickness, roundness, color, color, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Triangle(Vector3 a, Vector3 b, Vector3 c, float roundness, Color colorA, Color colorB, Color colorC)
		{
			Triangle_Internal(a, b, c, hollow: false, Thickness, roundness, colorA, colorB, colorC);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TriangleBorder(Vector3 a, Vector3 b, Vector3 c)
		{
			Triangle_Internal(a, b, c, hollow: true, Thickness, 0f, Color, Color, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TriangleBorder(Vector3 a, Vector3 b, Vector3 c, Color color)
		{
			Triangle_Internal(a, b, c, hollow: true, Thickness, 0f, color, color, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TriangleBorder(Vector3 a, Vector3 b, Vector3 c, Color colorA, Color colorB, Color colorC)
		{
			Triangle_Internal(a, b, c, hollow: true, Thickness, 0f, colorA, colorB, colorC);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TriangleBorder(Vector3 a, Vector3 b, Vector3 c, float thickness)
		{
			Triangle_Internal(a, b, c, hollow: true, thickness, 0f, Color, Color, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TriangleBorder(Vector3 a, Vector3 b, Vector3 c, float thickness, Color color)
		{
			Triangle_Internal(a, b, c, hollow: true, thickness, 0f, color, color, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TriangleBorder(Vector3 a, Vector3 b, Vector3 c, float thickness, Color colorA, Color colorB, Color colorC)
		{
			Triangle_Internal(a, b, c, hollow: true, thickness, 0f, colorA, colorB, colorC);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TriangleBorder(Vector3 a, Vector3 b, Vector3 c, float thickness, float roundness)
		{
			Triangle_Internal(a, b, c, hollow: true, thickness, roundness, Color, Color, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TriangleBorder(Vector3 a, Vector3 b, Vector3 c, float thickness, float roundness, Color color)
		{
			Triangle_Internal(a, b, c, hollow: true, thickness, roundness, color, color, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TriangleBorder(Vector3 a, Vector3 b, Vector3 c, float thickness, float roundness, Color colorA, Color colorB, Color colorC)
		{
			Triangle_Internal(a, b, c, hollow: true, thickness, roundness, colorA, colorB, colorC);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Quad(Vector3 a, Vector3 b, Vector3 c)
		{
			Quad_Internal(a, b, c, a + (c - b), Color, Color, Color, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Quad(Vector3 a, Vector3 b, Vector3 c, Color color)
		{
			Quad_Internal(a, b, c, a + (c - b), color, color, color, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Quad(Vector3 a, Vector3 b, Vector3 c, Color colorA, Color colorB, Color colorC, Color colorD)
		{
			Quad_Internal(a, b, c, a + (c - b), colorA, colorB, colorC, colorD);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Quad(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
		{
			Quad_Internal(a, b, c, d, Color, Color, Color, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Quad(Vector3 a, Vector3 b, Vector3 c, Vector3 d, Color color)
		{
			Quad_Internal(a, b, c, d, color, color, color, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Quad(Vector3 a, Vector3 b, Vector3 c, Vector3 d, Color colorA, Color colorB, Color colorC, Color colorD)
		{
			Quad_Internal(a, b, c, d, colorA, colorB, colorC, colorD);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Sphere(Vector3 pos)
		{
			PushMatrix();
			Translate(pos);
			Sphere_Internal(Radius, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Sphere(Vector3 pos, float radius)
		{
			PushMatrix();
			Translate(pos);
			Sphere_Internal(radius, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Sphere(Vector3 pos, Color color)
		{
			PushMatrix();
			Translate(pos);
			Sphere_Internal(Radius, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Sphere(Vector3 pos, float radius, Color color)
		{
			PushMatrix();
			Translate(pos);
			Sphere_Internal(radius, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Sphere()
		{
			Sphere_Internal(Radius, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Sphere(float radius)
		{
			Sphere_Internal(radius, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Sphere(Color color)
		{
			Sphere_Internal(Radius, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Sphere(float radius, Color color)
		{
			Sphere_Internal(radius, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cuboid(Vector3 pos, Vector3 size)
		{
			PushMatrix();
			Translate(pos);
			Cuboid_Internal(size, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cuboid(Vector3 pos, Vector3 size, Color color)
		{
			PushMatrix();
			Translate(pos);
			Cuboid_Internal(size, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cuboid(Vector3 pos, Vector3 normal, Vector3 size)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Cuboid_Internal(size, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cuboid(Vector3 pos, Vector3 normal, Vector3 size, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Cuboid_Internal(size, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cuboid(Vector3 pos, Quaternion rot, Vector3 size)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Cuboid_Internal(size, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cuboid(Vector3 pos, Quaternion rot, Vector3 size, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Cuboid_Internal(size, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cuboid(Vector3 size)
		{
			Cuboid_Internal(size, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cuboid(Vector3 size, Color color)
		{
			Cuboid_Internal(size, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cube(Vector3 pos, float size)
		{
			PushMatrix();
			Translate(pos);
			Cuboid_Internal(new Vector3(size, size, size), Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cube(Vector3 pos, float size, Color color)
		{
			PushMatrix();
			Translate(pos);
			Cuboid_Internal(new Vector3(size, size, size), color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cube(Vector3 pos, Vector3 normal, float size)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Cuboid_Internal(new Vector3(size, size, size), Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cube(Vector3 pos, Vector3 normal, float size, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Cuboid_Internal(new Vector3(size, size, size), color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cube(Vector3 pos, Quaternion rot, float size)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Cuboid_Internal(new Vector3(size, size, size), Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cube(Vector3 pos, Quaternion rot, float size, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Cuboid_Internal(new Vector3(size, size, size), color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cube(float size)
		{
			Cuboid_Internal(new Vector3(size, size, size), Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cube(float size, Color color)
		{
			Cuboid_Internal(new Vector3(size, size, size), color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(Vector3 pos, float radius, float length)
		{
			PushMatrix();
			Translate(pos);
			Cone_Internal(radius, length, fillCap: true, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(Vector3 pos, float radius, float length, bool fillCap)
		{
			PushMatrix();
			Translate(pos);
			Cone_Internal(radius, length, fillCap, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(Vector3 pos, float radius, float length, Color color)
		{
			PushMatrix();
			Translate(pos);
			Cone_Internal(radius, length, fillCap: true, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(Vector3 pos, float radius, float length, bool fillCap, Color color)
		{
			PushMatrix();
			Translate(pos);
			Cone_Internal(radius, length, fillCap, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(Vector3 pos, Vector3 normal, float radius, float length)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Cone_Internal(radius, length, fillCap: true, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(Vector3 pos, Vector3 normal, float radius, float length, bool fillCap)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Cone_Internal(radius, length, fillCap, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(Vector3 pos, Vector3 normal, float radius, float length, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Cone_Internal(radius, length, fillCap: true, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(Vector3 pos, Vector3 normal, float radius, float length, bool fillCap, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Cone_Internal(radius, length, fillCap, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(Vector3 pos, Quaternion rot, float radius, float length)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Cone_Internal(radius, length, fillCap: true, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(Vector3 pos, Quaternion rot, float radius, float length, bool fillCap)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Cone_Internal(radius, length, fillCap, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(Vector3 pos, Quaternion rot, float radius, float length, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Cone_Internal(radius, length, fillCap: true, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(Vector3 pos, Quaternion rot, float radius, float length, bool fillCap, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Cone_Internal(radius, length, fillCap, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(float radius, float length)
		{
			Cone_Internal(radius, length, fillCap: true, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(float radius, float length, bool fillCap)
		{
			Cone_Internal(radius, length, fillCap, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(float radius, float length, Color color)
		{
			Cone_Internal(radius, length, fillCap: true, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Cone(float radius, float length, bool fillCap, Color color)
		{
			Cone_Internal(radius, length, fillCap, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(Vector3 pos, float radius, float thickness)
		{
			PushMatrix();
			Translate(pos);
			Torus_Internal(radius, thickness, 0f, MathF.PI * 2f, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(Vector3 pos, float radius, float thickness, Color color)
		{
			PushMatrix();
			Translate(pos);
			Torus_Internal(radius, thickness, 0f, MathF.PI * 2f, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(Vector3 pos, Vector3 normal, float radius, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Torus_Internal(radius, thickness, 0f, MathF.PI * 2f, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(Vector3 pos, Vector3 normal, float radius, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Torus_Internal(radius, thickness, 0f, MathF.PI * 2f, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(Vector3 pos, Quaternion rot, float radius, float thickness)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Torus_Internal(radius, thickness, 0f, MathF.PI * 2f, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(Vector3 pos, Quaternion rot, float radius, float thickness, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Torus_Internal(radius, thickness, 0f, MathF.PI * 2f, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(float radius, float thickness)
		{
			Torus_Internal(radius, thickness, 0f, MathF.PI * 2f, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(float radius, float thickness, Color color)
		{
			Torus_Internal(radius, thickness, 0f, MathF.PI * 2f, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Translate(pos);
			Torus_Internal(radius, thickness, angleRadStart, angleRadEnd, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
			PushMatrix();
			Translate(pos);
			Torus_Internal(radius, thickness, angleRadStart, angleRadEnd, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Torus_Internal(radius, thickness, angleRadStart, angleRadEnd, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, Quaternion.LookRotation(normal), Vector3.one);
			Torus_Internal(radius, thickness, angleRadStart, angleRadEnd, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Torus_Internal(radius, thickness, angleRadStart, angleRadEnd, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Torus_Internal(radius, thickness, angleRadStart, angleRadEnd, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			Torus_Internal(radius, thickness, angleRadStart, angleRadEnd, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Torus(float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
			Torus_Internal(radius, thickness, angleRadStart, angleRadEnd, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content, TextAlign align)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content, float fontSize)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content, TextAlign align, float fontSize)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content, TextAlign align, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content, TextAlign align, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content, float fontSize, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content, TextAlign align, float fontSize, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content, TextAlign align)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content, float fontSize)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content, TextAlign align, float fontSize)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content, TextAlign align, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content, TextAlign align, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content, float fontSize, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content, TextAlign align, float fontSize, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, Vector3 pos, Quaternion rot, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, FontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content, TextAlign align)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, FontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content, float fontSize)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, fontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content, TextAlign align, float fontSize)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, fontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content, TMP_FontAsset font)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, FontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content, TextAlign align, TMP_FontAsset font)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, FontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content, float fontSize, TMP_FontAsset font)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, fontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, fontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content, Color color)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, FontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content, TextAlign align, Color color)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, FontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content, float fontSize, Color color)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, fontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content, TextAlign align, float fontSize, Color color)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), Font, fontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, FontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, FontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, fontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(TextElement element, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: false, content, element, default(Vector2), default(Vector2), font, fontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content, TextAlign align)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content, float fontSize)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content, TextAlign align, float fontSize)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content, TextAlign align, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content, TextAlign align, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content, float fontSize, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content, TextAlign align, float fontSize, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content, float fontSize)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align, float fontSize)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content, float fontSize, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align, float fontSize, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, FontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content, TextAlign align)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, FontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content, float fontSize)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, fontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content, TextAlign align, float fontSize)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, fontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content, TMP_FontAsset font)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, FontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content, TextAlign align, TMP_FontAsset font)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, FontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content, float fontSize, TMP_FontAsset font)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, fontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, fontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content, Color color)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, FontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content, TextAlign align, Color color)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, FontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content, float fontSize, Color color)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, fontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content, TextAlign align, float fontSize, Color color)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), Font, fontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, FontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, FontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content, float fontSize, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, fontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Text(string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: false, content, null, default(Vector2), default(Vector2), font, fontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, Font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, Font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content, float fontSize)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, Font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, Font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, Font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, Font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content, float fontSize, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, Font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, Font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, element, pivot, size, font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, Font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, Font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, float fontSize)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, Font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, Font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, Font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, Font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, float fontSize, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, Font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, Font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, element, pivot, size, font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content)
		{
			Text_Internal(isRect: true, content, element, pivot, size, Font, FontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content, TextAlign align)
		{
			Text_Internal(isRect: true, content, element, pivot, size, Font, FontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content, float fontSize)
		{
			Text_Internal(isRect: true, content, element, pivot, size, Font, fontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize)
		{
			Text_Internal(isRect: true, content, element, pivot, size, Font, fontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content, TMP_FontAsset font)
		{
			Text_Internal(isRect: true, content, element, pivot, size, font, FontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content, TextAlign align, TMP_FontAsset font)
		{
			Text_Internal(isRect: true, content, element, pivot, size, font, FontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content, float fontSize, TMP_FontAsset font)
		{
			Text_Internal(isRect: true, content, element, pivot, size, font, fontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			Text_Internal(isRect: true, content, element, pivot, size, font, fontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content, Color color)
		{
			Text_Internal(isRect: true, content, element, pivot, size, Font, FontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content, TextAlign align, Color color)
		{
			Text_Internal(isRect: true, content, element, pivot, size, Font, FontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content, float fontSize, Color color)
		{
			Text_Internal(isRect: true, content, element, pivot, size, Font, fontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, Color color)
		{
			Text_Internal(isRect: true, content, element, pivot, size, Font, fontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: true, content, element, pivot, size, font, FontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: true, content, element, pivot, size, font, FontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: true, content, element, pivot, size, font, fontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: true, content, element, pivot, size, font, fontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, Font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, Font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content, float fontSize)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, Font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, Font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, Font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, Font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content, float fontSize, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, Font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, Font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Translate(pos);
			Text_Internal(isRect: true, content, null, pivot, size, font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, Font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, Font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, float fontSize)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, Font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, Font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, font, FontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, font, FontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, font, fontSize, TextAlign, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, font, fontSize, align, Color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, Font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, Font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, float fontSize, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, Font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, Font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, font, FontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, font, FontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, font, fontSize, TextAlign, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector3 pos, Quaternion rot, Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			PushMatrix();
			Matrix *= Matrix4x4.TRS(pos, rot, Vector3.one);
			Text_Internal(isRect: true, content, null, pivot, size, font, fontSize, align, color);
			PopMatrix();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content)
		{
			Text_Internal(isRect: true, content, null, pivot, size, Font, FontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content, TextAlign align)
		{
			Text_Internal(isRect: true, content, null, pivot, size, Font, FontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content, float fontSize)
		{
			Text_Internal(isRect: true, content, null, pivot, size, Font, fontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize)
		{
			Text_Internal(isRect: true, content, null, pivot, size, Font, fontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content, TMP_FontAsset font)
		{
			Text_Internal(isRect: true, content, null, pivot, size, font, FontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content, TextAlign align, TMP_FontAsset font)
		{
			Text_Internal(isRect: true, content, null, pivot, size, font, FontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content, float fontSize, TMP_FontAsset font)
		{
			Text_Internal(isRect: true, content, null, pivot, size, font, fontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			Text_Internal(isRect: true, content, null, pivot, size, font, fontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content, Color color)
		{
			Text_Internal(isRect: true, content, null, pivot, size, Font, FontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content, TextAlign align, Color color)
		{
			Text_Internal(isRect: true, content, null, pivot, size, Font, FontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content, float fontSize, Color color)
		{
			Text_Internal(isRect: true, content, null, pivot, size, Font, fontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, Color color)
		{
			Text_Internal(isRect: true, content, null, pivot, size, Font, fontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: true, content, null, pivot, size, font, FontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: true, content, null, pivot, size, font, FontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: true, content, null, pivot, size, font, fontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Vector2 pivot, Vector2 size, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			Text_Internal(isRect: true, content, null, pivot, size, font, fontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content)
		{
			TextRect_Internal(content, element, rect, Font, FontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content, TextAlign align)
		{
			TextRect_Internal(content, element, rect, Font, FontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content, float fontSize)
		{
			TextRect_Internal(content, element, rect, Font, fontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content, TextAlign align, float fontSize)
		{
			TextRect_Internal(content, element, rect, Font, fontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content, TMP_FontAsset font)
		{
			TextRect_Internal(content, element, rect, font, FontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content, TextAlign align, TMP_FontAsset font)
		{
			TextRect_Internal(content, element, rect, font, FontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content, float fontSize, TMP_FontAsset font)
		{
			TextRect_Internal(content, element, rect, font, fontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			TextRect_Internal(content, element, rect, font, fontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content, Color color)
		{
			TextRect_Internal(content, element, rect, Font, FontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content, TextAlign align, Color color)
		{
			TextRect_Internal(content, element, rect, Font, FontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content, float fontSize, Color color)
		{
			TextRect_Internal(content, element, rect, Font, fontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content, TextAlign align, float fontSize, Color color)
		{
			TextRect_Internal(content, element, rect, Font, fontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content, TMP_FontAsset font, Color color)
		{
			TextRect_Internal(content, element, rect, font, FontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			TextRect_Internal(content, element, rect, font, FontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			TextRect_Internal(content, element, rect, font, fontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(TextElement element, Rect rect, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			TextRect_Internal(content, element, rect, font, fontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content)
		{
			TextRect_Internal(content, null, rect, Font, FontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content, TextAlign align)
		{
			TextRect_Internal(content, null, rect, Font, FontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content, float fontSize)
		{
			TextRect_Internal(content, null, rect, Font, fontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content, TextAlign align, float fontSize)
		{
			TextRect_Internal(content, null, rect, Font, fontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content, TMP_FontAsset font)
		{
			TextRect_Internal(content, null, rect, font, FontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content, TextAlign align, TMP_FontAsset font)
		{
			TextRect_Internal(content, null, rect, font, FontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content, float fontSize, TMP_FontAsset font)
		{
			TextRect_Internal(content, null, rect, font, fontSize, TextAlign, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			TextRect_Internal(content, null, rect, font, fontSize, align, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content, Color color)
		{
			TextRect_Internal(content, null, rect, Font, FontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content, TextAlign align, Color color)
		{
			TextRect_Internal(content, null, rect, Font, FontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content, float fontSize, Color color)
		{
			TextRect_Internal(content, null, rect, Font, fontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content, TextAlign align, float fontSize, Color color)
		{
			TextRect_Internal(content, null, rect, Font, fontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content, TMP_FontAsset font, Color color)
		{
			TextRect_Internal(content, null, rect, font, FontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			TextRect_Internal(content, null, rect, font, FontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			TextRect_Internal(content, null, rect, font, fontSize, TextAlign, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void TextRect(Rect rect, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			TextRect_Internal(content, null, rect, font, fontSize, align, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Texture(Texture texture, Rect rect, Rect uvs)
		{
			Texture_Internal(texture, rect, uvs, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Texture(Texture texture, Rect rect, Rect uvs, Color color)
		{
			Texture_Internal(texture, rect, uvs, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Texture(Texture texture, Rect rect)
		{
			Texture_RectFill_Internal(texture, rect, TextureFillMode.ScaleToFit, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Texture(Texture texture, Rect rect, Color color)
		{
			Texture_RectFill_Internal(texture, rect, TextureFillMode.ScaleToFit, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Texture(Texture texture, Rect rect, TextureFillMode fillMode)
		{
			Texture_RectFill_Internal(texture, rect, fillMode, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Texture(Texture texture, Rect rect, TextureFillMode fillMode, Color color)
		{
			Texture_RectFill_Internal(texture, rect, fillMode, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Texture(Texture texture, Vector2 center, float size)
		{
			Texture_PosSize_Internal(texture, center, size, TextureSizeMode.LongestSide, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Texture(Texture texture, Vector2 center, float size, Color color)
		{
			Texture_PosSize_Internal(texture, center, size, TextureSizeMode.LongestSide, color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Texture(Texture texture, Vector2 center, float size, TextureSizeMode sizeMode)
		{
			Texture_PosSize_Internal(texture, center, size, sizeMode, Color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Texture(Texture texture, Vector2 center, float size, TextureSizeMode sizeMode, Color color)
		{
			Texture_PosSize_Internal(texture, center, size, sizeMode, color);
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, float thickness, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, float thickness, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, LineEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, LineEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, LineEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, float thickness, LineEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, float thickness, LineEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, float thickness, LineEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, float thickness, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, float thickness, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, LineEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, LineEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, LineEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, float thickness, LineEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, float thickness, LineEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, float thickness, LineEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void PolygonFill(PolygonPath path)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void PolygonFill(PolygonPath path, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void PolygonFill(PolygonPath path, PolygonTriangulation triangulation)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void PolygonFill(PolygonPath path, PolygonTriangulation triangulation, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void PolygonFillLinear(PolygonPath path, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void PolygonFillLinear(PolygonPath path, PolygonTriangulation triangulation, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void PolygonFillRadial(PolygonPath path, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void PolygonFillRadial(PolygonPath path, PolygonTriangulation triangulation, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, float radius)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, float radius, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, float radius, float thickness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, float radius, float thickness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, float radius, float thickness, float angle)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, float radius, float thickness, float angle, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, float radius, float thickness, float angle, float roundness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, int sideCount)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, int sideCount, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius, float thickness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius, float thickness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius, float thickness, float angle)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius, float thickness, float angle, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius, float thickness, float angle, float roundness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius, float thickness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius, float thickness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius, float thickness, float angle)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, float roundness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, float roundness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius, float thickness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius, float thickness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius, float thickness, float angle)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, float roundness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, float roundness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow()
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(float radius)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(float radius, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(float radius, float thickness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(float radius, float thickness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(float radius, float thickness, float angle)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(float radius, float thickness, float angle, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(float radius, float thickness, float angle, float roundness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(int sideCount)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(int sideCount, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(int sideCount, float radius)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(int sideCount, float radius, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(int sideCount, float radius, float thickness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(int sideCount, float radius, float thickness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(int sideCount, float radius, float thickness, float angle)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(int sideCount, float radius, float thickness, float angle, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(int sideCount, float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollow(int sideCount, float radius, float thickness, float angle, float roundness, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, float radius, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, float radius, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, float radius, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, float radius, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, int sideCount)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, int sideCount, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, int sideCount, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, int sideCount, float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, int sideCount, float radius, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, int sideCount, float radius, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, int sideCount, float radius, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, int sideCount, float radius, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, float radius, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, float radius, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, float radius, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, float radius, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount, float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, float radius, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, float radius, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, float radius, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, float radius, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount, float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill()
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(float radius, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(float radius, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(float radius, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(float radius, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(int sideCount)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(int sideCount, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(int sideCount, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(int sideCount, float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(int sideCount, float radius, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(int sideCount, float radius, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(int sideCount, float radius, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFill(int sideCount, float radius, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, float radius, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, float radius, float thickness, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, float radius, float thickness, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, float radius, float thickness, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius, float thickness, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius, float thickness, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius, float thickness, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius, float thickness, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius, float thickness, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill()
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(float radius, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(float radius, float thickness, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(float radius, float thickness, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(float radius, float thickness, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(int sideCount)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(int sideCount, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(int sideCount, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(int sideCount, float radius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(int sideCount, float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(int sideCount, float radius, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(int sideCount, float radius, float thickness, float angle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(int sideCount, float radius, float thickness, float angle, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(int sideCount, float radius, float thickness, float angle, float roundness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFill(int sideCount, float radius, float thickness, float angle, float roundness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, float radius, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, float radius, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, int sideCount, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, int sideCount, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, int sideCount, float radius, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, int sideCount, float radius, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, float radius, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, float radius, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, int sideCount, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, int sideCount, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, float radius, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, float radius, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, int sideCount, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, int sideCount, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(float radius, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(float radius, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(int sideCount, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(int sideCount, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(int sideCount, float radius, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillLinear(int sideCount, float radius, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, float radius, float thickness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, float radius, float thickness, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, float radius, float thickness, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, int sideCount, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, int sideCount, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, int sideCount, float radius, float thickness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, int sideCount, float radius, float thickness, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, int sideCount, float radius, float thickness, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, float radius, float thickness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, int sideCount, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, int sideCount, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, float radius, float thickness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, int sideCount, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, int sideCount, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(float radius, float thickness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(float radius, float thickness, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(float radius, float thickness, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(int sideCount, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(int sideCount, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(int sideCount, float radius, float thickness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(int sideCount, float radius, float thickness, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillLinear(int sideCount, float radius, float thickness, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, float radius, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, float radius, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, int sideCount, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, int sideCount, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, int sideCount, float radius, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, int sideCount, float radius, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, float radius, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, float radius, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, int sideCount, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, int sideCount, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, float radius, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, float radius, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, int sideCount, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, int sideCount, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(float radius, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(float radius, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(int sideCount, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(int sideCount, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(int sideCount, float radius, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RegularPolygonFillRadial(int sideCount, float radius, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, float radius, float thickness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, float radius, float thickness, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, float radius, float thickness, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, int sideCount, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, int sideCount, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, int sideCount, float radius, float thickness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, int sideCount, float radius, float thickness, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, int sideCount, float radius, float thickness, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, float radius, float thickness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, int sideCount, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, int sideCount, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, float radius, float thickness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, int sideCount, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, int sideCount, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(float radius, float thickness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(float radius, float thickness, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(float radius, float thickness, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(int sideCount, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(int sideCount, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(int sideCount, float radius, float thickness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(int sideCount, float radius, float thickness, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill. In addition: For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.RegularPolygonBorder instead", true)]
		public static void RegularPolygonHollowFillRadial(int sideCount, float radius, float thickness, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Radial(...) )", true)]
		public static void DiscGradientRadial(Vector3 pos, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Radial(...) )", true)]
		public static void DiscGradientRadial(Vector3 pos, float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Radial(...) )", true)]
		public static void DiscGradientRadial(Vector3 pos, Vector3 normal, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Radial(...) )", true)]
		public static void DiscGradientRadial(Vector3 pos, Vector3 normal, float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Radial(...) )", true)]
		public static void DiscGradientRadial(Vector3 pos, Quaternion rot, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Radial(...) )", true)]
		public static void DiscGradientRadial(Vector3 pos, Quaternion rot, float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Radial(...) )", true)]
		public static void DiscGradientRadial(Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Radial(...) )", true)]
		public static void DiscGradientRadial(float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Angular(...) )", true)]
		public static void DiscGradientAngular(Vector3 pos, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Angular(...) )", true)]
		public static void DiscGradientAngular(Vector3 pos, float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Angular(...) )", true)]
		public static void DiscGradientAngular(Vector3 pos, Vector3 normal, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Angular(...) )", true)]
		public static void DiscGradientAngular(Vector3 pos, Vector3 normal, float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Angular(...) )", true)]
		public static void DiscGradientAngular(Vector3 pos, Quaternion rot, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Angular(...) )", true)]
		public static void DiscGradientAngular(Vector3 pos, Quaternion rot, float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Angular(...) )", true)]
		public static void DiscGradientAngular(Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Angular(...) )", true)]
		public static void DiscGradientAngular(float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Bilinear(...) )", true)]
		public static void DiscGradientBilinear(Vector3 pos, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Bilinear(...) )", true)]
		public static void DiscGradientBilinear(Vector3 pos, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Bilinear(...) )", true)]
		public static void DiscGradientBilinear(Vector3 pos, Vector3 normal, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Bilinear(...) )", true)]
		public static void DiscGradientBilinear(Vector3 pos, Vector3 normal, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Bilinear(...) )", true)]
		public static void DiscGradientBilinear(Vector3 pos, Quaternion rot, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Bilinear(...) )", true)]
		public static void DiscGradientBilinear(Vector3 pos, Quaternion rot, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Bilinear(...) )", true)]
		public static void DiscGradientBilinear(Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Disc( ..., DiscColors.Bilinear(...) )", true)]
		public static void DiscGradientBilinear(float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, float radius, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, float radius, float thickness, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, DashStyle dashStyle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, DashStyle dashStyle, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, DashStyle dashStyle, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, DashStyle dashStyle, float radius, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Vector3 normal)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Vector3 normal, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Vector3 normal, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Vector3 normal, float radius, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Vector3 normal, float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Vector3 normal, float radius, float thickness, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Quaternion rot)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Quaternion rot, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Quaternion rot, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Quaternion rot, float radius, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Quaternion rot, float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Quaternion rot, float radius, float thickness, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed()
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(float radius, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(float radius, float thickness, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(DashStyle dashStyle)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(DashStyle dashStyle, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(DashStyle dashStyle, float radius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(DashStyle dashStyle, float radius, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(DashStyle dashStyle, float radius, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingDashed(DashStyle dashStyle, float radius, float thickness, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) )", true)]
		public static void RingGradientRadial(Vector3 pos, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) )", true)]
		public static void RingGradientRadial(Vector3 pos, float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) )", true)]
		public static void RingGradientRadial(Vector3 pos, float radius, float thickness, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) )", true)]
		public static void RingGradientRadial(Vector3 pos, Vector3 normal, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) )", true)]
		public static void RingGradientRadial(Vector3 pos, Vector3 normal, float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) )", true)]
		public static void RingGradientRadial(Vector3 pos, Vector3 normal, float radius, float thickness, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) )", true)]
		public static void RingGradientRadial(Vector3 pos, Quaternion rot, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) )", true)]
		public static void RingGradientRadial(Vector3 pos, Quaternion rot, float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) )", true)]
		public static void RingGradientRadial(Vector3 pos, Quaternion rot, float radius, float thickness, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) )", true)]
		public static void RingGradientRadial(Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) )", true)]
		public static void RingGradientRadial(float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) )", true)]
		public static void RingGradientRadial(float radius, float thickness, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, float radius, float thickness, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, DashStyle dashStyle, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, Vector3 normal, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, Vector3 normal, float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, Vector3 normal, float radius, float thickness, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, Quaternion rot, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, Quaternion rot, float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, Quaternion rot, float radius, float thickness, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(float radius, float thickness, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(DashStyle dashStyle, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(DashStyle dashStyle, float radius, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientRadialDashed(DashStyle dashStyle, float radius, float thickness, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) )", true)]
		public static void RingGradientAngular(Vector3 pos, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) )", true)]
		public static void RingGradientAngular(Vector3 pos, float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) )", true)]
		public static void RingGradientAngular(Vector3 pos, float radius, float thickness, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) )", true)]
		public static void RingGradientAngular(Vector3 pos, Vector3 normal, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) )", true)]
		public static void RingGradientAngular(Vector3 pos, Vector3 normal, float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) )", true)]
		public static void RingGradientAngular(Vector3 pos, Vector3 normal, float radius, float thickness, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) )", true)]
		public static void RingGradientAngular(Vector3 pos, Quaternion rot, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) )", true)]
		public static void RingGradientAngular(Vector3 pos, Quaternion rot, float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) )", true)]
		public static void RingGradientAngular(Vector3 pos, Quaternion rot, float radius, float thickness, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) )", true)]
		public static void RingGradientAngular(Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) )", true)]
		public static void RingGradientAngular(float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) )", true)]
		public static void RingGradientAngular(float radius, float thickness, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, float radius, float thickness, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, DashStyle dashStyle, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, Vector3 normal, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, Vector3 normal, float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, Vector3 normal, float radius, float thickness, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, Quaternion rot, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, Quaternion rot, float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, Quaternion rot, float radius, float thickness, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(float radius, float thickness, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(DashStyle dashStyle, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(DashStyle dashStyle, float radius, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientAngularDashed(DashStyle dashStyle, float radius, float thickness, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) )", true)]
		public static void RingGradientBilinear(Vector3 pos, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) )", true)]
		public static void RingGradientBilinear(Vector3 pos, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) )", true)]
		public static void RingGradientBilinear(Vector3 pos, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) )", true)]
		public static void RingGradientBilinear(Vector3 pos, Vector3 normal, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) )", true)]
		public static void RingGradientBilinear(Vector3 pos, Vector3 normal, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) )", true)]
		public static void RingGradientBilinear(Vector3 pos, Vector3 normal, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) )", true)]
		public static void RingGradientBilinear(Vector3 pos, Quaternion rot, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) )", true)]
		public static void RingGradientBilinear(Vector3 pos, Quaternion rot, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) )", true)]
		public static void RingGradientBilinear(Vector3 pos, Quaternion rot, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) )", true)]
		public static void RingGradientBilinear(Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) )", true)]
		public static void RingGradientBilinear(float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) )", true)]
		public static void RingGradientBilinear(float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, Vector3 normal, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, Vector3 normal, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, Vector3 normal, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, Quaternion rot, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, Quaternion rot, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, Quaternion rot, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(DashStyle dashStyle, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(DashStyle dashStyle, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Ring( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void RingGradientBilinearDashed(DashStyle dashStyle, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Radial(...) )", true)]
		public static void PieGradientRadial(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Radial(...) )", true)]
		public static void PieGradientRadial(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Radial(...) )", true)]
		public static void PieGradientRadial(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Radial(...) )", true)]
		public static void PieGradientRadial(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Radial(...) )", true)]
		public static void PieGradientRadial(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Radial(...) )", true)]
		public static void PieGradientRadial(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Radial(...) )", true)]
		public static void PieGradientRadial(float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Radial(...) )", true)]
		public static void PieGradientRadial(float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Angular(...) )", true)]
		public static void PieGradientAngular(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Angular(...) )", true)]
		public static void PieGradientAngular(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Angular(...) )", true)]
		public static void PieGradientAngular(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Angular(...) )", true)]
		public static void PieGradientAngular(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Angular(...) )", true)]
		public static void PieGradientAngular(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Angular(...) )", true)]
		public static void PieGradientAngular(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Angular(...) )", true)]
		public static void PieGradientAngular(float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Angular(...) )", true)]
		public static void PieGradientAngular(float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Bilinear(...) )", true)]
		public static void PieGradientBilinear(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Bilinear(...) )", true)]
		public static void PieGradientBilinear(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Bilinear(...) )", true)]
		public static void PieGradientBilinear(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Bilinear(...) )", true)]
		public static void PieGradientBilinear(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Bilinear(...) )", true)]
		public static void PieGradientBilinear(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Bilinear(...) )", true)]
		public static void PieGradientBilinear(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Bilinear(...) )", true)]
		public static void PieGradientBilinear(float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Pie( ..., DiscColors.Bilinear(...) )", true)]
		public static void PieGradientBilinear(float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(float radius, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(float radius, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(DashStyle dashStyle, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
		}

		[Obsolete("As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcDashed(DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) )", true)]
		public static void ArcGradientRadial(float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Radial(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientRadialDashed(DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) )", true)]
		public static void ArcGradientAngular(float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Angular(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientAngularDashed(DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) )", true)]
		public static void ArcGradientBilinear(float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, disc gradients are now defined using a DiscColors as the last parameter. Instead, please use Draw.Arc( ..., DiscColors.Bilinear(...) ). In addition: As of Shapes 4.0.0, dash state is now set using the global Draw.UseDashes and Draw.DashStyle", true)]
		public static void ArcGradientBilinearDashed(DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Rect rect)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Rect rect, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Rect rect, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Rect rect, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Rect rect, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Rect rect, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Rect rect)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Rect rect, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Rect rect, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Rect rect, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Rect rect, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Rect rect, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Rect rect)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Rect rect, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Rect rect, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Rect rect, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Rect rect, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Rect rect, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector2 size)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector2 size, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector2 size, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector2 size, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector2 size, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector2 size, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, float width, float height)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, float width, float height, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, float width, float height, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, float width, float height, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, float width, float height, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, float width, float height, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Vector2 size)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Vector2 size, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Vector2 size, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Vector2 size, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Vector2 size, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Vector2 size, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, float width, float height)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, float width, float height, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, float width, float height, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, float width, float height, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, float width, float height, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, float width, float height, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Vector2 size)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Vector2 size, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Vector2 size, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Vector2 size, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Vector2 size, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Vector2 size, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, float width, float height)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, float width, float height, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, float width, float height, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, float width, float height, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, float width, float height, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, float width, float height, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Rect rect)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Rect rect, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Rect rect, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Rect rect, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Rect rect, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Rect rect, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector2 size, RectPivot pivot)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector2 size, RectPivot pivot, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector2 size, RectPivot pivot, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector2 size, RectPivot pivot, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector2 size, RectPivot pivot, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector2 size, RectPivot pivot, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, float width, float height, RectPivot pivot)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, float width, float height, RectPivot pivot, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, float width, float height, RectPivot pivot, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, float width, float height, RectPivot pivot, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, float width, float height, RectPivot pivot, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, float width, float height, RectPivot pivot, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleFill(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Rect rect, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Rect rect, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Rect rect, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Rect rect, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Rect rect, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Rect rect, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Rect rect, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Rect rect, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Rect rect, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Rect rect, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Rect rect, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Rect rect, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Rect rect, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Rect rect, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Rect rect, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Rect rect, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Rect rect, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Rect rect, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector2 size, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector2 size, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector2 size, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector2 size, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector2 size, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector2 size, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, float width, float height, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, float width, float height, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, float width, float height, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, float width, float height, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, float width, float height, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, float width, float height, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Vector2 size, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Vector2 size, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Vector2 size, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Vector2 size, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Vector2 size, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Vector2 size, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, float width, float height, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, float width, float height, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, float width, float height, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, float width, float height, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, float width, float height, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, float width, float height, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Vector2 size, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Vector2 size, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Vector2 size, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Vector2 size, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Vector2 size, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Vector2 size, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, float width, float height, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, float width, float height, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, float width, float height, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, float width, float height, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, float width, float height, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, float width, float height, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Rect rect, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Rect rect, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Rect rect, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Rect rect, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Rect rect, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Rect rect, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector2 size, RectPivot pivot, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector2 size, RectPivot pivot, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector2 size, RectPivot pivot, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector2 size, RectPivot pivot, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, float width, float height, RectPivot pivot, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, float width, float height, RectPivot pivot, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, float width, float height, RectPivot pivot, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, float width, float height, RectPivot pivot, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness, float cornerRadius)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness, float cornerRadius, GradientFill fill)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
		}

		[Obsolete("As of Shapes 4.0.0, color fill is now set using the global Draw.UseGradientFill and Draw.GradientFill", true)]
		public static void RectangleBorderFill(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii, GradientFill fill)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.TriangleBorder instead", true)]
		public static void TriangleHollow(Vector3 a, Vector3 b, Vector3 c)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.TriangleBorder instead", true)]
		public static void TriangleHollow(Vector3 a, Vector3 b, Vector3 c, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.TriangleBorder instead", true)]
		public static void TriangleHollow(Vector3 a, Vector3 b, Vector3 c, Color colorA, Color colorB, Color colorC)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.TriangleBorder instead", true)]
		public static void TriangleHollow(Vector3 a, Vector3 b, Vector3 c, float thickness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.TriangleBorder instead", true)]
		public static void TriangleHollow(Vector3 a, Vector3 b, Vector3 c, float thickness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.TriangleBorder instead", true)]
		public static void TriangleHollow(Vector3 a, Vector3 b, Vector3 c, float thickness, Color colorA, Color colorB, Color colorC)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.TriangleBorder instead", true)]
		public static void TriangleHollow(Vector3 a, Vector3 b, Vector3 c, float thickness, float roundness)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.TriangleBorder instead", true)]
		public static void TriangleHollow(Vector3 a, Vector3 b, Vector3 c, float thickness, float roundness, Color color)
		{
		}

		[Obsolete("For consistency, this has been renamed as of Shapes 4.0.0. Please use Draw.TriangleBorder instead", true)]
		public static void TriangleHollow(Vector3 a, Vector3 b, Vector3 c, float thickness, float roundness, Color colorA, Color colorB, Color colorC)
		{
		}

		static Draw()
		{
			mpbLine = new MpbLine2D();
			mpbPolyline = new MpbPolyline2D();
			mpbPolylineJoins = new MpbPolyline2D();
			mpbPolygon = new MpbPolygon();
			mpbDisc = new MpbDisc();
			mpbRegularPolygon = new MpbRegularPolygon();
			mpbRect = new MpbRect();
			mpbTriangle = new MpbTriangle();
			mpbQuad = new MpbQuad();
			metaMpbSphere = new MpbSphere();
			mpbCone = new MpbCone();
			mpbCuboid = new MpbCuboid();
			mpbTorus = new MpbTorus();
			mpbText = new MpbText();
			mpbCustomMesh = new MpbCustomMesh();
			mpbTexture = new MpbTexture();
			matrix = Matrix4x4.identity;
			ResetAllDrawStates();
		}

		public static void ResetAllDrawStates()
		{
			ResetMatrix();
			ResetStyle();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Push()
		{
			StateStack.Push(style, matrix);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Pop()
		{
			StateStack.Pop();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ResetMatrix()
		{
			matrix = Matrix4x4.identity;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void PushMatrix()
		{
			MatrixStack.Push(Matrix);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void PopMatrix()
		{
			MatrixStack.Pop();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ApplyMatrix(Matrix4x4 matrix)
		{
			Matrix *= matrix;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Translate(float x, float y)
		{
			MtxTranslateXY(ref matrix, x, y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Translate(float x, float y, float z)
		{
			MtxTranslateXYZ(ref matrix, x, y, z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Translate(Vector2 displacement)
		{
			Translate(displacement.x, displacement.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Translate(Vector3 displacement)
		{
			Translate(displacement.x, displacement.y, displacement.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rotate(float angle)
		{
			MtxRotateZ(ref matrix, angle);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rotate(float x, float y, float z)
		{
			Rotate(Quaternion.Euler(x * 57.29578f, y * 57.29578f, z * 57.29578f));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rotate(float angle, Vector3 axis)
		{
			Rotate(Quaternion.AngleAxis(angle * 57.29578f, axis));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Rotate(Quaternion rotation)
		{
			matrix *= Matrix4x4.Rotate(rotation);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Scale(float uniformScale)
		{
			MtxScaleXYZ(ref matrix, uniformScale, uniformScale, uniformScale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Scale(float x, float y)
		{
			MtxScaleXY(ref matrix, x, y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Scale(float x, float y, float z)
		{
			MtxScaleXYZ(ref matrix, x, y, z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Scale(Vector2 scale)
		{
			Scale(scale.x, scale.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void Scale(Vector3 scale)
		{
			Scale(scale.x, scale.y, scale.z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMatrix(Matrix4x4 matrix)
		{
			Matrix = matrix;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMatrix(Vector3 position, Quaternion rotation, Vector3 scale)
		{
			Matrix = Matrix4x4.TRS(position, rotation, scale);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMatrix(Transform transform)
		{
			Matrix = transform.localToWorldMatrix;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void MtxSetRotationKeepScale(ref Matrix4x4 m, Quaternion rotation)
		{
			Matrix4x4 matrix4x = Matrix4x4.Rotate(rotation);
			float magnitude = ((Vector3)m.GetColumn(0)).magnitude;
			float magnitude2 = ((Vector3)m.GetColumn(1)).magnitude;
			float magnitude3 = ((Vector3)m.GetColumn(2)).magnitude;
			m.m00 = matrix4x.m00 * magnitude;
			m.m10 = matrix4x.m10 * magnitude;
			m.m20 = matrix4x.m20 * magnitude;
			m.m01 = matrix4x.m01 * magnitude2;
			m.m11 = matrix4x.m11 * magnitude2;
			m.m21 = matrix4x.m21 * magnitude2;
			m.m02 = matrix4x.m02 * magnitude3;
			m.m12 = matrix4x.m12 * magnitude3;
			m.m22 = matrix4x.m22 * magnitude3;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void MtxRotateZLhs(ref Matrix4x4 rhs, float a)
		{
			double num = Math.Cos(a);
			double num2 = Math.Sin(a);
			double num3 = rhs.m00;
			double num4 = rhs.m01;
			double num5 = rhs.m02;
			double num6 = rhs.m03;
			rhs.m00 = (float)(num * num3 - num2 * (double)rhs.m10);
			rhs.m01 = (float)(num * num4 - num2 * (double)rhs.m11);
			rhs.m02 = (float)(num * num5 - num2 * (double)rhs.m12);
			rhs.m03 = (float)(num * num6 - num2 * (double)rhs.m13);
			rhs.m10 = (float)(num2 * num3 + num * (double)rhs.m10);
			rhs.m11 = (float)(num2 * num4 + num * (double)rhs.m11);
			rhs.m12 = (float)(num2 * num5 + num * (double)rhs.m12);
			rhs.m13 = (float)(num2 * num6 + num * (double)rhs.m13);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void MtxTranslateXYZ(ref Matrix4x4 lhs, double x, double y, double z)
		{
			lhs.m03 = (float)((double)lhs.m00 * x + (double)lhs.m01 * y + (double)lhs.m02 * z + (double)lhs.m03);
			lhs.m13 = (float)((double)lhs.m10 * x + (double)lhs.m11 * y + (double)lhs.m12 * z + (double)lhs.m13);
			lhs.m23 = (float)((double)lhs.m20 * x + (double)lhs.m21 * y + (double)lhs.m22 * z + (double)lhs.m23);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void MtxTranslateXY(ref Matrix4x4 lhs, double x, double y)
		{
			lhs.m03 = (float)((double)lhs.m00 * x + (double)lhs.m01 * y + (double)lhs.m03);
			lhs.m13 = (float)((double)lhs.m10 * x + (double)lhs.m11 * y + (double)lhs.m13);
			lhs.m23 = (float)((double)lhs.m20 * x + (double)lhs.m21 * y + (double)lhs.m23);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void MtxRotateZ(ref Matrix4x4 lhs, float a)
		{
			double num = Math.Cos(a);
			double num2 = Math.Sin(a);
			float m = lhs.m00;
			float m2 = lhs.m01;
			float m3 = lhs.m10;
			float m4 = lhs.m11;
			float m5 = lhs.m20;
			float m6 = lhs.m21;
			lhs.m00 = (float)((double)m * num + (double)m2 * num2);
			lhs.m01 = (float)((double)m * (0.0 - num2) + (double)m2 * num);
			lhs.m10 = (float)((double)m3 * num + (double)m4 * num2);
			lhs.m11 = (float)((double)m3 * (0.0 - num2) + (double)m4 * num);
			lhs.m20 = (float)((double)m5 * num + (double)m6 * num2);
			lhs.m21 = (float)((double)m5 * (0.0 - num2) + (double)m6 * num);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void MtxScaleXYZ(ref Matrix4x4 m, double x, double y, double z)
		{
			m.m00 = (float)((double)m.m00 * x);
			m.m10 = (float)((double)m.m10 * x);
			m.m20 = (float)((double)m.m20 * x);
			m.m01 = (float)((double)m.m01 * y);
			m.m11 = (float)((double)m.m11 * y);
			m.m21 = (float)((double)m.m21 * y);
			m.m02 = (float)((double)m.m02 * z);
			m.m12 = (float)((double)m.m12 * z);
			m.m22 = (float)((double)m.m22 * z);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void MtxScaleXY(ref Matrix4x4 m, double x, double y)
		{
			m.m00 = (float)((double)m.m00 * x);
			m.m10 = (float)((double)m.m10 * x);
			m.m20 = (float)((double)m.m20 * x);
			m.m01 = (float)((double)m.m01 * y);
			m.m11 = (float)((double)m.m11 * y);
			m.m21 = (float)((double)m.m21 * y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void MtxResetToXYZ(out Matrix4x4 m, float x, float y, float z)
		{
			m = Matrix4x4.identity;
			m.m03 = x;
			m.m13 = y;
			m.m23 = z;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void MtxResetToXY(out Matrix4x4 m, float x, float y)
		{
			m = Matrix4x4.identity;
			m.m03 = x;
			m.m13 = y;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void MtxResetToPosXYatAngle(out Matrix4x4 lhs, float x, float y, float a)
		{
			MtxResetToXY(out lhs, x, y);
			MtxResetScaleSetAngleZ(ref lhs, a);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void MtxResetToPosXYatDirection(out Matrix4x4 lhs, float x, float y, Vector2 dir)
		{
			MtxResetToXY(out lhs, x, y);
			MtxResetScaleSetDirX(ref lhs, dir);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void MtxResetScaleSetAngleZ(ref Matrix4x4 lhs, float a)
		{
			float num = Mathf.Cos(a);
			float num2 = Mathf.Sin(a);
			lhs.m00 = num;
			lhs.m10 = num2;
			lhs.m20 = 0f;
			lhs.m01 = 0f - num2;
			lhs.m11 = num;
			lhs.m21 = 0f;
			lhs.m02 = 0f;
			lhs.m12 = 0f;
			lhs.m22 = 1f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void MtxResetScaleSetDirX(ref Matrix4x4 lhs, Vector2 dir)
		{
			dir.Normalize();
			lhs.m00 = dir.x;
			lhs.m10 = dir.y;
			lhs.m20 = 0f;
			lhs.m01 = 0f - dir.y;
			lhs.m11 = dir.x;
			lhs.m21 = 0f;
			lhs.m02 = 0f;
			lhs.m12 = 0f;
			lhs.m22 = 1f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ResetStyle()
		{
			style = DrawStyle.@default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void PushStyle()
		{
			StyleStack.Push(style);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void PopStyle()
		{
			StyleStack.Pop();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void PushColor()
		{
			ColorStack.Push(style.color);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void PopColor()
		{
			ColorStack.Pop();
		}

		public static DashStack DashedScope()
		{
			DashStack result = new DashStack(UseDashes, DashStyle);
			UseDashes = true;
			return result;
		}

		public static DashStack DashedScope(DashStyle dashStyle)
		{
			DashStack result = new DashStack(UseDashes, DashStyle);
			UseDashes = true;
			DashStyle = dashStyle;
			return result;
		}

		public static GradientFillStack GradientFillScope()
		{
			GradientFillStack result = new GradientFillStack(UseGradientFill, GradientFill);
			UseGradientFill = true;
			return result;
		}

		public static GradientFillStack GradientFillScope(GradientFill fill)
		{
			GradientFillStack result = new GradientFillStack(UseGradientFill, GradientFill);
			UseGradientFill = true;
			GradientFill = fill;
			return result;
		}
	}
}
