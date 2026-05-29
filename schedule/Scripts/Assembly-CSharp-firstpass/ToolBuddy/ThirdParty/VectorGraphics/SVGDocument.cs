using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace ToolBuddy.ThirdParty.VectorGraphics
{
	internal class SVGDocument
	{
		private enum ViewBoxAlign
		{
			Min = 0,
			Mid = 1,
			Max = 2
		}

		private enum ViewBoxAspectRatio
		{
			DontPreserve = 0,
			FitLargestDim = 1,
			FitSmallestDim = 2
		}

		private struct ViewBoxInfo
		{
			public Rect ViewBox;

			public ViewBoxAspectRatio AspectRatio;

			public ViewBoxAlign AlignX;

			public ViewBoxAlign AlignY;

			public bool IsEmpty;
		}

		private struct HierarchyUpdate
		{
			public SceneNode Parent;

			public SceneNode NewNode;

			public SceneNode ReplaceNode;
		}

		private delegate void ElemHandler();

		private class Handlers : Dictionary<string, ElemHandler>
		{
			public Handlers(int capacity)
			{
			}
		}

		private enum DimType
		{
			Width = 0,
			Height = 1,
			Length = 2
		}

		private struct NodeGlobalSceneState
		{
			public Vector2 ContainerSize;
		}

		private class GradientExData
		{
			public bool WorldRelative;

			public Matrix2D FillTransform;
		}

		private class LinearGradientExData : GradientExData
		{
			public string X1;

			public string Y1;

			public string X2;

			public string Y2;
		}

		private class RadialGradientExData : GradientExData
		{
			public bool Parsed;

			public string Cx;

			public string Cy;

			public string Fx;

			public string Fy;

			public string R;
		}

		private struct ClipData
		{
			public bool WorldRelative;
		}

		private struct PatternData
		{
			public bool WorldRelative;

			public bool ContentWorldRelative;

			public Matrix2D PatternTransform;
		}

		private struct MaskData
		{
			public bool WorldRelative;

			public bool ContentWorldRelative;
		}

		private struct NodeWithParent
		{
			public SceneNode node;

			public SceneNode parent;
		}

		private struct NodeReferenceData
		{
			public SceneNode node;

			public Rect viewport;

			public string id;
		}

		private struct PostponedStopData
		{
			public GradientFill fill;
		}

		private struct PostponedClip
		{
			public SceneNode node;
		}

		internal const float SVGLengthFactor = 1.4142135f;

		private static char[] whiteSpaceNumberChars;

		private XmlReaderIterator docReader;

		private Scene scene;

		private float dpiScale;

		private int windowWidth;

		private int windowHeight;

		private Vector2 scenePos;

		private Vector2 sceneSize;

		private SVGDictionary svgObjects;

		private Dictionary<string, Handlers> subTags;

		private Dictionary<GradientFill, GradientExData> gradientExInfo;

		private Dictionary<SceneNode, ViewBoxInfo> symbolViewBoxes;

		private Dictionary<SceneNode, NodeGlobalSceneState> nodeGlobalSceneState;

		private Dictionary<SceneNode, float> nodeOpacity;

		private Dictionary<string, SceneNode> nodeIDs;

		private Dictionary<SceneNode, SVGStyleResolver.StyleLayer> nodeStyleLayers;

		private Dictionary<SceneNode, ClipData> clipData;

		private Dictionary<SceneNode, PatternData> patternData;

		private Dictionary<SceneNode, MaskData> maskData;

		private Dictionary<string, List<NodeReferenceData>> postponedSymbolData;

		private Dictionary<string, List<PostponedStopData>> postponedStopData;

		private Dictionary<string, List<PostponedClip>> postponedClip;

		private SVGPostponedFills postponedFills;

		private List<NodeWithParent> invisibleNodes;

		private Stack<Vector2> currentContainerSize;

		private Stack<Vector2> currentViewBoxSize;

		private Stack<SceneNode> currentSceneNode;

		private GradientFill currentGradientFill;

		private string currentGradientId;

		private string currentGradientLink;

		private ElemHandler[] allElems;

		private HashSet<ElemHandler> elemsToAddToHierarchy;

		private SVGStyleResolver styles;

		private bool applyRootViewBox;

		internal Rect sceneViewport;

		public Dictionary<SceneNode, float> NodeOpacities => null;

		public Dictionary<string, SceneNode> NodeIDs => null;

		internal static string StockBlackNonZeroFillName => null;

		internal static string StockBlackOddEvenFillName => null;

		public SVGDocument(XmlReader docReader, float dpi, Scene scene, int windowWidth, int windowHeight, bool applyRootViewBox)
		{
		}

		public void Import()
		{
		}

		private void ParseChildren(XmlReaderIterator.Node node, string nodeName)
		{
		}

		private void circle()
		{
		}

		private void defs()
		{
		}

		private void ellipse()
		{
		}

		private void g()
		{
		}

		private void image()
		{
		}

		private void line()
		{
		}

		private void linearGradient()
		{
		}

		private void path()
		{
		}

		private void polygon()
		{
		}

		private void polyline()
		{
		}

		private void radialGradient()
		{
		}

		private void clipPath()
		{
		}

		private void pattern()
		{
		}

		private void mask()
		{
		}

		private void rect()
		{
		}

		private void stop()
		{
		}

		private void svg()
		{
		}

		private void symbol()
		{
		}

		private void use()
		{
		}

		private void style()
		{
		}

		private void ResolveReferencedNode(SceneNode referencedNode, NodeReferenceData refData, bool isDeferred)
		{
		}

		private SceneNode CloneSceneNode(SceneNode node)
		{
			return null;
		}

		private Shape CloneShape(Shape shape)
		{
			return null;
		}

		private BezierContour CloneContour(BezierContour c)
		{
			return default(BezierContour);
		}

		private IFill CloneFill(IFill fill)
		{
			return null;
		}

		private PathProperties ClonePathProps(PathProperties props)
		{
			return default(PathProperties);
		}

		private GradientFill CloneGradientFill(GradientFill other)
		{
			return null;
		}

		private int AttribIntVal(string attribName)
		{
			return 0;
		}

		private int AttribIntVal(string attribName, int defaultVal)
		{
			return 0;
		}

		private float AttribFloatVal(string attribName)
		{
			return 0f;
		}

		private float AttribFloatVal(string attribName, float defaultVal)
		{
			return 0f;
		}

		private float AttribLengthVal(XmlReaderIterator.Node node, string attribName, DimType dimType)
		{
			return 0f;
		}

		private float AttribLengthVal(XmlReaderIterator.Node node, string attribName, float defaultUnitVal, DimType dimType)
		{
			return 0f;
		}

		private float AttribLengthVal(string val, XmlReaderIterator.Node node, string attribName, float defaultUnitVal, DimType dimType)
		{
			return 0f;
		}

		private void AddToSVGDictionaryIfPossible(XmlReaderIterator.Node node, object vectorElement)
		{
		}

		private Rect ParseViewport(XmlReaderIterator.Node node, SceneNode sceneNode, Vector2 defaultViewportSize)
		{
			return default(Rect);
		}

		private ViewBoxInfo ParseViewBox(XmlReaderIterator.Node node, SceneNode sceneNode, Rect sceneViewport)
		{
			return default(ViewBoxInfo);
		}

		private void ParseViewBoxAspectRatio(XmlReaderIterator.Node node, ref ViewBoxInfo viewBoxInfo)
		{
		}

		private void ApplyViewBox(SceneNode sceneNode, ViewBoxInfo viewBoxInfo, Rect sceneViewport)
		{
		}

		private Stroke ParseStrokeAttributeSet(XmlReaderIterator.Node node, out PathCorner strokeCorner, out PathEnding strokeEnding, Inheritance inheritance = Inheritance.Inherited)
		{
			strokeCorner = default(PathCorner);
			strokeEnding = default(PathEnding);
			return null;
		}

		private void ParseID(XmlReaderIterator.Node node, SceneNode sceneNode)
		{
		}

		private float ParseOpacity(SceneNode sceneNode)
		{
			return 0f;
		}

		private void ParseClipAndMask(XmlReaderIterator.Node node, SceneNode sceneNode)
		{
		}

		private void ParseClip(XmlReaderIterator.Node node, SceneNode sceneNode)
		{
		}

		private void ApplyClipper(SceneNode clipper, SceneNode target, bool worldRelative)
		{
		}

		private void ParseMask(XmlReaderIterator.Node node, SceneNode sceneNode)
		{
		}

		private Texture2D DecodeTextureData(string dataURI)
		{
			return null;
		}

		private void PostProcess(SceneNode root)
		{
		}

		private void AdjustFills(SceneNode root)
		{
		}

		private void AdjustGradientFill(SceneNode node, Matrix2D worldTransform, IFill fill, BezierContour[] contours, ref Matrix2D computedTransform)
		{
		}

		private SceneNode AdjustPatternFill(SceneNode node, Matrix2D worldTransform, Shape shape)
		{
			return null;
		}

		private void RemoveInvisibleNodes()
		{
		}

		private bool ShouldDeclareSupportedChildren(XmlReaderIterator.Node node)
		{
			return false;
		}

		private void SupportElems(XmlReaderIterator.Node node, params ElemHandler[] handlers)
		{
		}
	}
}
