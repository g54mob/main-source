using System.Collections.Generic;
using TinyGiantStudio.Text;
using UnityEngine;

namespace TinyGiantStudio.Layout
{
	[HelpURL("https://ferdowsur.gitbook.io/layout-system/layout-group/grid-layout-group")]
	[AddComponentMenu("Tiny Giant Studio/Layout/Grid Layout Group (M3D)", 30001)]
	public class GridLayoutGroup : LayoutGroup
	{
		[SerializeField]
		private Alignment _anchor;

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
		private Vector2 _spacing;

		[SerializeField]
		private float _width;

		[SerializeField]
		private float _height;

		[SerializeField]
		private Overflow _verticalOverflow;

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

		public Vector2 Spacing
		{
			get
			{
				return default(Vector2);
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

		public Overflow VerticalOverflow
		{
			get
			{
				return default(Overflow);
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

		private void SetLocalPosition(int lineCount, int i, Vector3 targetPos)
		{
		}

		public override List<MeshLayout> GetPositions(List<MeshLayout> meshLayouts)
		{
			return null;
		}

		private void GetLayoutInformations(out float lineHeight, out int maxLine, out float y, out float z)
		{
			lineHeight = default(float);
			maxLine = default(int);
			y = default(float);
			z = default(float);
		}

		private void ProcessLine(ref float ySpace, ref float y, int lineCount, out float justiceXMultiplier, out float x)
		{
			justiceXMultiplier = default(float);
			x = default(float);
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
	}
}
