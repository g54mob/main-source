using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RetroUIText : MaskableGraphic, ISerializationCallbackReceiver
{
	public interface ITextListener
	{
		void OnAddedLine(RetroUIText renderer, int line);

		void OnResettingTextData(RetroUIText renderer, string oldText, string newText);

		void OnRemovingLine(RetroUIText renderer, int line);

		void OnEditedLine(RetroUIText renderer, int line, string previusText);

		void OnRenderVisibleLines(RetroUIText renderer, int startLine, int endLine);
	}

	public interface IViewListener
	{
		void OnVerticalScrollChange(RetroUIText renderer);

		void OnHorizontalScrollChange(RetroUIText renderer);

		void OnCaretMoved(RetroUIText renderer);

		void OnVisibleTextChanged(RetroUIText renderer);

		void OnTextChanged(RetroUIText renderer);
	}

	public class TextData
	{
		public struct ColorInfo
		{
			public int startIndex;

			public int count;

			public Color color;

			public ColorInfo(Color color, int startIndex, int count)
			{
				this.startIndex = 0;
				this.count = 0;
				this.color = default(Color);
			}
		}

		public struct UnderlineInfo
		{
			public int startIndex;

			public int count;

			public Color color;

			public UnderlineInfo(Color color, int startIndex, int count)
			{
				this.startIndex = 0;
				this.count = 0;
				this.color = default(Color);
			}
		}

		public class Line
		{
			public int index;

			public string text;

			public List<VisibleLine> visibleLines;

			public List<ColorInfo> fgColors;

			public List<ColorInfo> bgColors;

			public List<UnderlineInfo> underlines;

			public Color? bgColor;

			public object highlightData;

			private Dictionary<Type, object> additionalData;

			public int firstVisibleIndex => 0;

			public int lastVisibleIndex => 0;

			public Line()
			{
			}

			public Line(int index, string text)
			{
			}

			public void OnTextChanged(RenderSettings renderSettings, TextData data)
			{
			}

			public VisibleLine GetVisibleLine(int column)
			{
				return null;
			}

			public void RecalculateVisibleLines(RenderSettings renderSettings)
			{
			}

			public void SetAdditionalData<T>(T data)
			{
			}

			public T GetAdditionalData<T>() where T : class
			{
				return null;
			}

			public void RefreshColors()
			{
			}

			public void RefreshFgColors()
			{
			}

			public void RefreshBgColors()
			{
			}

			public void RefreshUnderlines()
			{
			}
		}

		public class VisibleLine
		{
			public Line line;

			public int localIndex;

			public int globalIndex;

			public int startIndex;

			public int endIndex;

			public int firstVisibleIndex;

			public int lastVisibleIndex;

			public (int, int)[] charsColumnI;

			public int widthInColumns;

			public int visibleWidthInColumns;

			public List<ColorInfo> fgColors;

			public List<ColorInfo> bgColors;

			public List<UnderlineInfo> underlines;

			public VisibleLine(Line line, int localIndex)
			{
			}

			public void SetupCharsColumns(List<(int, int)> charsColumnI)
			{
			}

			public string GetText()
			{
				return null;
			}

			public int GetCharColumn(int charIndex)
			{
				return 0;
			}
		}

		public List<Line> lines;

		public List<VisibleLine> visibleLines;

		public bool dirtyVisibleLines;

		public int maxWidthInColumns;

		public RenderSettings renderSettings;

		public string GetText()
		{
			return null;
		}

		public string GetText(TextCoord start, TextCoord end)
		{
			return null;
		}

		public string GetText(int start, int end)
		{
			return null;
		}

		public string GetText(TextCoord coord, out int charIndex)
		{
			charIndex = default(int);
			return null;
		}

		public TextCoord CalculateCoordFromCharIndex(int charIndex)
		{
			return default(TextCoord);
		}

		public void RecalculateVisibleLines(RenderSettings renderSettings)
		{
		}

		public void RefreshVisibleLines()
		{
		}
	}

	public enum WrapMode
	{
		None = 0,
		Char = 1,
		Word = 2
	}

	public enum HorizontalAlignment
	{
		Left = 0,
		Center = 1,
		Right = 2
	}

	public enum VerticalAlignment
	{
		Top = 0,
		Mid = 1,
		Bottom = 2
	}

	public enum VerticalAlignmentMidMode
	{
		AscentToBaseLine = 0,
		AcentToDescentLine = 1
	}

	public enum VerticalOverflowMode
	{
		Clip = 0,
		Ellipsis = 1,
		LeftEllipsis = 2
	}

	public class RenderSettings
	{
		public TMP_FontAsset font;

		public List<Dictionary<uint, TMP_Character>> fontTables;

		public int columnHorizontalAdvance;

		public int columnsCount;

		public int tabSpacesCount;

		public WrapMode wrapMode;

		public HorizontalAlignment horizontalAlignment;

		public VerticalAlignment verticalAlignment;

		private VerticalAlignmentMidMode verticalAlignmentMidMode;

		public RenderSettings()
		{
		}

		public RenderSettings(TMP_FontAsset font, int columnHorizontalAdvance, int columnsCount, int tabSpacesCount, WrapMode wrapMode, HorizontalAlignment horizontalAlignment, VerticalAlignment verticalAlignment, VerticalAlignmentMidMode verticalAlignmentMidMode)
		{
		}

		public bool NeedVisibleLinesRefresh(RenderSettings renderSettings)
		{
			return false;
		}
	}

	[Serializable]
	public struct TextCoord : IComparable
	{
		public int line;

		public int column;

		public TextCoord(int line, int column)
		{
			this.line = 0;
			this.column = 0;
		}

		public static bool operator ==(TextCoord lhs, TextCoord rhs)
		{
			return false;
		}

		public static bool operator !=(TextCoord lhs, TextCoord rhs)
		{
			return false;
		}

		public static bool operator >(TextCoord lhs, TextCoord rhs)
		{
			return false;
		}

		public static bool operator <(TextCoord lhs, TextCoord rhs)
		{
			return false;
		}

		public static bool operator <=(TextCoord lhs, TextCoord rhs)
		{
			return false;
		}

		public static bool operator >=(TextCoord lhs, TextCoord rhs)
		{
			return false;
		}

		public static TextCoord operator +(TextCoord lhs, int rhs)
		{
			return default(TextCoord);
		}

		public static TextCoord operator -(TextCoord lhs, int rhs)
		{
			return default(TextCoord);
		}

		public int CompareTo(object obj)
		{
			return 0;
		}

		public override string ToString()
		{
			return null;
		}
	}

	[Serializable]
	public struct TextAreaCoord
	{
		public TextCoord begin;

		public TextCoord end;

		public TextAreaCoord(TextCoord begin, TextCoord end)
		{
			this.begin = default(TextCoord);
			this.end = default(TextCoord);
		}

		public bool Contains(TextCoord coord)
		{
			return false;
		}

		public static bool operator ==(TextAreaCoord obj1, TextAreaCoord obj2)
		{
			return false;
		}

		public static bool operator !=(TextAreaCoord obj1, TextAreaCoord obj2)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}
	}

	public enum CaretStyle
	{
		Line = 0,
		Block = 1
	}

	public enum CaretBlockStyle
	{
		Full = 0,
		Low = 1
	}

	public class RenderContext
	{
		public float width;

		public float height;

		public Vector2 bottomLeftCorner;

		public Vector2 topLeftCorner;

		public Rect clipRect;

		public int columnsCount;

		public float verticalAlignOffset;

		public float verticalOffset;

		public int startVisibleLine;

		public int endVisibleLine;

		public int startRenderingVisibleLine;

		public int endRenderingVisibleLine;

		public float verticalRenderOffset;
	}

	public enum CharSide
	{
		Left = 0,
		Right = 1
	}

	public struct OverlapPoinResult
	{
		public TextData.VisibleLine visibleLine;

		public int charIndex;

		public CharSide charSide;

		public bool outside;

		public bool outsideVertical;

		public bool outsideHorizontal;

		public bool outsideLeft;

		public int line => 0;
	}

	private static Dictionary<TMP_FontAsset, Material> uiMaterials;

	private Material uiMaterial;

	[SerializeField]
	private TMP_FontAsset _font;

	private TMP_Character sampleChar;

	private int charWidth;

	private int charHeight;

	private int horizontalAdvance;

	[SerializeField]
	private int _lineHeight;

	[SerializeField]
	private int _leftMargin;

	[SerializeField]
	private int _rightMargin;

	[SerializeField]
	private int _tabSpacesCount;

	[SerializeField]
	private WrapMode _wrapMode;

	[SerializeField]
	private HorizontalAlignment _horizontalAlignment;

	[SerializeField]
	private VerticalAlignment _verticalAlignment;

	[SerializeField]
	private VerticalAlignmentMidMode _verticalAlignmentMidMode;

	[SerializeField]
	private VerticalOverflowMode _verticalOverflowMode;

	[SerializeField]
	private string _text;

	[SerializeField]
	private Color _color;

	[SerializeField]
	private float _horizontalScroll;

	[SerializeField]
	private float _verticalScroll;

	private TextAreaCoord? _selectionArea;

	[SerializeField]
	private Color _selectionColor;

	[SerializeField]
	private Color _caretColor;

	public const int lineCaretWidth = 1;

	private CaretStyle _caretStyle;

	private CaretBlockStyle _caretBlockStyle;

	private bool caretPositionChanged;

	private TextCoord? _caretPosition;

	public bool autoScrollToCaret;

	private TextCoord? _autoScrollTo;

	[NonSerialized]
	[HideInInspector]
	public TextData data;

	[NonSerialized]
	[HideInInspector]
	public List<ITextListener> textListeners;

	[NonSerialized]
	[HideInInspector]
	public List<IViewListener> viewListeners;

	[NonSerialized]
	public bool inspectorApplyModifiedProperties;

	[NonSerialized]
	[HideInInspector]
	public List<MaskableGraphic> childRenderers;

	private bool textChanged;

	[NonSerialized]
	[HideInInspector]
	public RenderContext ctx;

	public override Material material
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public TMP_FontAsset font
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public int lineHeight
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int columnWidth => 0;

	public int leftMargin
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int rightMargin
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int tabSpacesCount
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public WrapMode wrapMode
	{
		get
		{
			return default(WrapMode);
		}
		set
		{
		}
	}

	public HorizontalAlignment horizontalAlignment
	{
		get
		{
			return default(HorizontalAlignment);
		}
		set
		{
		}
	}

	public VerticalAlignment verticalAlignment
	{
		get
		{
			return default(VerticalAlignment);
		}
		set
		{
		}
	}

	public VerticalAlignmentMidMode verticalAlignmentMidMode
	{
		get
		{
			return default(VerticalAlignmentMidMode);
		}
		set
		{
		}
	}

	public VerticalOverflowMode verticalOverflowMode
	{
		get
		{
			return default(VerticalOverflowMode);
		}
		set
		{
		}
	}

	public new Color color
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public float horizontalScroll
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float verticalScroll
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public TextAreaCoord? selectionArea
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Color selectionColor
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public Color caretColor
	{
		get
		{
			return default(Color);
		}
		set
		{
		}
	}

	public CaretStyle caretStyle
	{
		get
		{
			return default(CaretStyle);
		}
		set
		{
		}
	}

	public CaretBlockStyle caretBlockStyle
	{
		get
		{
			return default(CaretBlockStyle);
		}
		set
		{
		}
	}

	public TextCoord? caretPosition
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public TextData.Line caretLine => null;

	public override Texture mainTexture => null;

	public float width => 0f;

	public float height => 0f;

	public void AutoScrollTo(TextCoord destination)
	{
	}

	public TextData.Line GetLine(TextCoord coord)
	{
		return null;
	}

	private TextData.VisibleLine GetVisibleLine(TextCoord coord)
	{
		return null;
	}

	private void RefreshFontMetrics()
	{
	}

	protected override void OnRectTransformDimensionsChange()
	{
	}

	public override void SetVerticesDirty()
	{
	}

	public void OnTextDataChanged()
	{
	}

	public void SetText(string text)
	{
	}

	public string GetText()
	{
		return null;
	}

	private void _SetText(string text)
	{
	}

	public void SetTextDirty()
	{
	}

	private void AddQuad(VertexHelper vh, Vector2 corner1, Vector2 corner2, Vector2 uvCorner1, Vector2 uvCorner2, Color color, bool skipCulling = false)
	{
	}

	public void OnAfterDeserialize()
	{
	}

	public void OnBeforeSerialize()
	{
	}

	public float GetHorizontalAlignOffset(TextData.VisibleLine visibleLine)
	{
		return 0f;
	}

	private float GetVerticalAlignOffset()
	{
		return 0f;
	}

	public RangeInt CalculateVisibleColumns(TextData.VisibleLine visibleLine)
	{
		return default(RangeInt);
	}

	public FloatRange CalculateVisibleColumnsFloat(TextData.VisibleLine visibleLine)
	{
		return default(FloatRange);
	}

	private float FloorOffset(float v)
	{
		return 0f;
	}

	private float CeilOffset(float v)
	{
		return 0f;
	}

	public float GetMinHorizontalScoll()
	{
		return 0f;
	}

	public float GetMaxHorizontalScoll()
	{
		return 0f;
	}

	public float HorizontalTextSize()
	{
		return 0f;
	}

	public float GetMinVerticalScoll()
	{
		return 0f;
	}

	public float GetMaxVerticalScoll()
	{
		return 0f;
	}

	public float VerticalTextSize()
	{
		return 0f;
	}

	public void ClampHorizontalScroll()
	{
	}

	public void ClampVerticalScroll()
	{
	}

	public void ClampScroll()
	{
	}

	public bool PrepareRenderContext()
	{
		return false;
	}

	private void ScrollTo(TextCoord destination)
	{
	}

	private void CalculateRenderContextVerticalScroll()
	{
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
	}

	public OverlapPoinResult OverlapPoint(Vector2 point)
	{
		return default(OverlapPoinResult);
	}

	private TextCoord ClampSelectionCoord(TextCoord coord)
	{
		return default(TextCoord);
	}

	private TextCoord ClampCaretCoord(TextCoord coord)
	{
		return default(TextCoord);
	}

	public Vector3 GetWorldPosition(TextCoord textCoord)
	{
		return default(Vector3);
	}

	public string GetSelectedText()
	{
		return null;
	}

	public void SetLineText(int lineIndex, string text)
	{
	}

	public void MergeLineWithNext(int lineIndex)
	{
	}

	public void MergeLineWithPrevius(int lineIndex)
	{
	}

	public void DeleteText(TextCoord from, TextCoord to)
	{
	}

	public void InsertLine(int lineIndex, string text)
	{
	}

	public void DeleteLine(int lineIndex)
	{
	}

	public void SplitLine(int lineIndex, int columnIndex)
	{
	}
}
