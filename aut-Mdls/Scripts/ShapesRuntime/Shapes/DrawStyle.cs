using UnityEngine;
using UnityEngine.Rendering;

namespace Shapes
{
	internal struct DrawStyle
	{
		private const float DEFAULT_THICKNESS = 0.05f;

		private const ThicknessSpace DEFAULT_THICKNESS_SPACE = ThicknessSpace.Meters;

		public static DrawStyle @default = new DrawStyle
		{
			color = Color.white,
			renderState = new RenderState
			{
				zTest = CompareFunction.LessEqual,
				zOffsetFactor = 0f,
				zOffsetUnits = 0,
				colorMask = ColorWriteMask.All,
				stencilComp = CompareFunction.Always,
				stencilOpPass = StencilOp.Keep,
				stencilRefID = 0,
				stencilReadMask = byte.MaxValue,
				stencilWriteMask = byte.MaxValue
			},
			blendMode = ShapesBlendMode.Transparent,
			scaleMode = ScaleMode.Uniform,
			detailLevel = DetailLevel.Medium,
			useDashes = false,
			dashStyle = DashStyle.defaultDashStyle,
			useGradients = false,
			gradientFill = GradientFill.defaultFill,
			thickness = 0.05f,
			thicknessSpace = ThicknessSpace.Meters,
			radiusSpace = ThicknessSpace.Meters,
			sizeSpace = ThicknessSpace.Meters,
			radius = 1f,
			lineEndCaps = LineEndCap.Round,
			lineGeometry = LineGeometry.Billboard,
			polygonTriangulation = PolygonTriangulation.EarClipping,
			polylineGeometry = PolylineGeometry.Billboard,
			polylineJoins = PolylineJoins.Round,
			discGeometry = DiscGeometry.Flat2D,
			regularPolygonSideCount = 6,
			regularPolygonGeometry = RegularPolygonGeometry.Flat2D,
			textStyle = TextStyle.defaultTextStyle
		};

		public RenderState renderState;

		public Color color;

		public ShapesBlendMode blendMode;

		public ScaleMode scaleMode;

		public DetailLevel detailLevel;

		public bool useDashes;

		public DashStyle dashStyle;

		public bool useGradients;

		public GradientFill gradientFill;

		public float radius;

		public float thickness;

		public ThicknessSpace thicknessSpace;

		public ThicknessSpace radiusSpace;

		public ThicknessSpace sizeSpace;

		public LineEndCap lineEndCaps;

		public LineGeometry lineGeometry;

		public PolygonTriangulation polygonTriangulation;

		public PolylineGeometry polylineGeometry;

		public PolylineJoins polylineJoins;

		public DiscGeometry discGeometry;

		public int regularPolygonSideCount;

		public RegularPolygonGeometry regularPolygonGeometry;

		public TextStyle textStyle;
	}
}
