using System.Collections.Generic;
using TinyGiantStudio.Text;
using UnityEngine;

namespace TinyGiantStudio.Layout
{
	[AddComponentMenu("Tiny Giant Studio/Layout/Volume Layout Group (M3D)", 30001)]
	public class VolumeLayoutGroup : LayoutGroup
	{
		[SerializeField]
		private Alignment _anchor;

		[SerializeField]
		private DepthAlignment _depthAlignment;

		[Tooltip("Elements will be split to fill the entire width")]
		[SerializeField]
		private bool _justiceHorizontal;

		[Tooltip("Justice will be only be applied if the elements hold equal/more than the % width")]
		[SerializeField]
		private float _justiceHorizontalPercent;

		[Tooltip("Elements will be split to fill the entire width")]
		[SerializeField]
		private bool _justiceVertical;

		[Tooltip("Justice will be only be applied if the elements hold equal/more than the % height")]
		[SerializeField]
		private float _justiceVerticalPercent;

		[SerializeField]
		private Vector3 _spacing;

		[SerializeField]
		private float _width;

		[SerializeField]
		private float _height;

		[SerializeField]
		private float _depth;

		[SerializeField]
		private LineSpacingStyle _lineSpacingStyle;

		private int currentLine;

		private int currentLetter;

		private int currentWord;

		private Modular3DText text;

		public List<Line> lines;

		public Alignment Anchor
		{
			get
			{
				return default(Alignment);
			}
			set
			{
			}
		}

		public DepthAlignment DepthAlignment
		{
			get
			{
				return default(DepthAlignment);
			}
			set
			{
			}
		}

		public bool JusticeHorizontal
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float JusticeHorizontalPercent
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool JusticeVertical
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float JusticeVerticalPercent
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Vector3 Spacing
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public float Width
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Height
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Depth
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public LineSpacingStyle MyLineSpacingStyle
		{
			get
			{
				return default(LineSpacingStyle);
			}
			set
			{
			}
		}

		public override void UpdateLayout(int startRepositioningFrom = 0)
		{
		}

		private void GetYandZpositionForNewDepth(float oneLineHeight, int totalAmountOfLineInOneZposition, int lineCount, ref float y, ref float z, float oneLineDepth)
		{
		}

		public override List<MeshLayout> GetPositions(List<MeshLayout> meshLayouts)
		{
			return null;
		}

		private void ProcessThisLine(ref float thisLineHeight, int lineCount, out float justiceXMultiplier, out float x)
		{
			justiceXMultiplier = default(float);
			x = default(float);
		}

		private void GetInitialYSpaceInformation(out float oneLineHeight, out int totalAmountOfLineInOneZaxis, out float oneLineDepth)
		{
			oneLineHeight = default(float);
			totalAmountOfLineInOneZaxis = default(int);
			oneLineDepth = default(float);
		}

		private void SetLocalPosition(int lineCount, int i, Vector3 targetPos)
		{
		}

		private float GetLineHeight()
		{
			return 0f;
		}

		private float GetMaxYSpace(Bounds[] bounds)
		{
			return 0f;
		}

		private float GetJusticeXMultiplier(float spaceRequired)
		{
			return 0f;
		}

		private List<Line> GetLines(Bounds[] bounds, List<MeshLayout> meshLayouts)
		{
			return null;
		}

		private List<Line> GetLines()
		{
			return null;
		}

		private float StartingX(List<MeshLayout> meshlayouts, float spaceRequired)
		{
			return 0f;
		}

		private float StartingX(List<GameObject> gameObjects, float spaceRequired)
		{
			return 0f;
		}

		private float GetXSpaceRequired(Line line)
		{
			return 0f;
		}

		private float GetXSpaceRequired(List<GameObject> targets)
		{
			return 0f;
		}

		private float GetXSpaceRequired(List<MeshLayout> targets)
		{
			return 0f;
		}

		private float StartingY(float ySpace, float maxLines)
		{
			return 0f;
		}

		private float StartingYforUpperAlignment()
		{
			return 0f;
		}

		private float StartingYforMiddleAlignment(float ySpace, float maxLines)
		{
			return 0f;
		}

		private float StartingYforLowerAlignment(float ySpace, float maxLines)
		{
			return 0f;
		}

		private float GetTotalYSpaceTakenByCheckingEachLineIndividually(float maxLines)
		{
			return 0f;
		}

		private float GetAverageYSpace(Bounds[] bounds)
		{
			return 0f;
		}

		private float GetSpecificLineMaxYSpace(List<GameObject> itemsInLine)
		{
			return 0f;
		}

		private float GetZspacing()
		{
			return 0f;
		}

		private float GetAverageZSpace()
		{
			return 0f;
		}

		private float StartingZ(float oneLineDepth, int totalAmountOfLineInOneZposition)
		{
			return 0f;
		}

		private float TotalZspaceTaken(float oneLineDepth, int totalAmountOfLineInOneZposition)
		{
			return 0f;
		}

		private bool IsUpperAlignment()
		{
			return false;
		}

		private bool IsMiddleAlignment()
		{
			return false;
		}

		private bool ApplyHorizontalJustice(float spaceRequired)
		{
			return false;
		}

		private bool ItsALineBreak(List<MeshLayout> meshLayouts, List<Line> lines, ref int currentLine, ref float x, int i)
		{
			return false;
		}

		private bool ItsALineBreak(List<Line> lines, ref int currentLine, ref float x, int i)
		{
			return false;
		}

		private void IsThisAnewWord(Modular3DText text, ref bool checkedIfFits)
		{
		}

		private void MoveWordToNextLine(List<MeshLayout> meshLayouts, Bounds[] bounds, List<Line> lines, int currentLine, ref float x, Modular3DText text, int word, ref bool checkedIfFits, int i)
		{
		}

		private void MoveWordToNextLine(Bounds[] bounds, List<Line> lines, int currentLine, ref float x, Modular3DText text, int letter, int word, ref bool checkedIfFits, int i)
		{
		}

		private bool UpdateTextIfRequired()
		{
			return false;
		}

		private bool WordIsntTooBigForOneLine(Bounds[] bounds, Modular3DText text, int currentChildNumber, int word, int letter)
		{
			return false;
		}

		private List<Line> RemoveUnnecessarySpacesFromMeshLayouts(List<Line> lines)
		{
			return null;
		}

		private List<Line> RemoveUnnecessarySpaces(List<Line> lines)
		{
			return null;
		}

		private bool ThisLineDoesntFitsInCurrentZposition(int totalAmountOfLineInOneZposition, int currentLineNumberInCurrentZposition)
		{
			return false;
		}
	}
}
