using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SLS.Widgets.Table
{
	public class Table : UIBehaviour, ILayoutGroup, ILayoutController
	{
		public enum SelectionMode
		{
			CELL = 0,
			ROW = 1,
			MULTICELL = 2,
			MULTIROW = 3
		}

		public enum MultiSelectKey
		{
			SHIFT = 0,
			CONTROL = 1
		}

		public static readonly WaitForEndOfFrame WaitForEndOfFrame;

		public static readonly decimal TicksToSecs;

		public Font font;

		public FontStyle fontStyle;

		public Material fontMaterial;

		public bool use2DMask;

		public Sprite fillerSprite;

		public int defaultFontSize;

		public int scrollSensitivity;

		public float leftMargin;

		public float rightMargin;

		public float horizontalSpacing;

		public Color bodyBackgroundColor;

		public Color columnLineColor;

		public int columnLineWidth;

		public bool min100PercentWidth;

		public bool max100PercentWidth;

		public Sprite spinnerSprite;

		public Color spinnerColor;

		public float rowAnimationDuration;

		public decimal rowAnimationDecimalDuration;

		public SelectionMode selectionMode;

		public MultiSelectKey multiSelectKey;

		public bool alwaysMultiSelect;

		public bool drawGizmos;

		public Color gizmoColor;

		public bool showHoverColors;

		public float minHeaderHeight;

		public float headerTopMargin;

		public float headerBottomMargin;

		public Color headerNormalColor;

		public Color headerHoverColor;

		public Color headerDownColor;

		public Color headerBorderColor;

		public Color headerTextColor;

		public int headerIconWidth;

		public int headerIconHeight;

		public float minFooterHeight;

		public float footerTopMargin;

		public float footerBottomMargin;

		public Color footerBackgroundColor;

		public Color footerBorderColor;

		public Color footerTextColor;

		public float minRowHeight;

		private float _minRowHeight;

		public float rowVerticalSpacing;

		public Color rowLineColor;

		public int rowLineHeight;

		public Color rowNormalColor;

		public Color rowAltColor;

		public Color rowHoverColor;

		public Color rowDownColor;

		public Color rowSelectColor;

		public Color cellHoverColor;

		public Color cellDownColor;

		public Color cellSelectColor;

		public Color rowTextColor;

		public Action<RectTransform, string> tooltipHandler;

		public Action<PointerEventData, Datum> pointerDownHandler;

		public Action<PointerEventData, Datum> pointerUpHandler;

		public Action<Element, string> onCellLongPress;

		public float extraTextWidthRatio;

		public Color extraTextBoxColor;

		public Color extraTextColor;

		public int scrollBarSize;

		public Color scrollBarBackround;

		public Color scrollBarForeground;

		public List<Column> _columns;

		private Row overRow;

		private Cell overCell;

		private bool isTouchDevice;

		private Coroutine cDoStartRenderLater;

		private Coroutine cDoSetBodyRectSizeLater;

		[HideInInspector]
		public List<Row> rows;

		[HideInInspector]
		public TableDatumList data;

		public Action<Datum> selectionCallback;

		public Action<Datum, Column> selectionCallbackWithColumn;

		public Action<Datum, Column, RectTransform> selectionCallbackWithRT;

		public Func<Column, bool> headerActiveCallback;

		public Action<Datum> deselectionCallback;

		public Action<Datum, Column> deselectionCallbackWithColumn;

		private Datum _lastSelectedDatum;

		private Column _lastSelectedColumn;

		public HashSet<Datum> selectedDatumSet;

		public Dictionary<Datum, HashSet<Column>> selectedDatumColumnDict;

		[HideInInspector]
		public RectTransform root;

		private bool _hasHeader;

		private bool _hasHeaderIcons;

		private bool _hasFooter;

		private Datum headerDatum;

		private Datum footerDatum;

		[HideInInspector]
		public RectTransform headerRect;

		[HideInInspector]
		public Row headerRow;

		[HideInInspector]
		public RectTransform footerRect;

		[HideInInspector]
		public Row footerRow;

		[HideInInspector]
		public ScrollRect bodyScroller;

		[HideInInspector]
		public ScrollWatcher bodyScrollWatcher;

		[HideInInspector]
		public BodyRect bodyRect;

		[HideInInspector]
		public RectTransform bodySizer;

		[HideInInspector]
		public RectTransform horScrollerRt;

		[HideInInspector]
		public RectTransform verScrollerRt;

		[HideInInspector]
		public CanvasGroup loadingOverlay;

		private bool _hasColumnOverlay;

		[HideInInspector]
		public RectTransform columnOverlay;

		[HideInInspector]
		public RectTransform columnOverlayContent;

		[HideInInspector]
		public List<RectTransform> columnOverlayLines;

		private Factory factory;

		private Control control;

		[HideInInspector]
		public Column extraTextColumn;

		[HideInInspector]
		public InputCell inputCell;

		private bool _isRunning;

		private bool _hasError;

		private bool doingDirtyLater;

		private Vector2 lastRootSize;

		private Dictionary<string, Sprite> _sprites;

		private bool overlayIsHiding;

		public List<Column> columns => null;

		[Obsolete]
		public Datum selectedDatum
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[Obsolete]
		public Column selectedColumn => null;

		public Datum lastSelectedDatum
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Column lastSelectedColumn => null;

		public bool hasHeader => false;

		public bool hasHeaderIcons => false;

		public bool hasFooter => false;

		public bool hasColumnOverlay => false;

		public bool isRunning => false;

		public bool hasError => false;

		public Dictionary<string, Sprite> sprites => null;

		private void Update()
		{
		}

		public void SetPointerOverRow(Row row)
		{
		}

		public void SetPointerOverCell(Cell cell)
		{
		}

		public bool IsPointerOver(Row row)
		{
			return false;
		}

		public bool IsPointerOver(Cell cell)
		{
			return false;
		}

		[Obsolete]
		public void setSelected(int x, int y, bool doCallback = true)
		{
		}

		public void SetSelected(int x, int y, bool doCallback = true, bool animate = false)
		{
		}

		[Obsolete]
		public void moveSelectionUp(bool doCallback = true)
		{
		}

		public void MoveSelectionUp(bool doCallback = true)
		{
		}

		[Obsolete]
		public void moveSelectionDown(bool doCallback = true)
		{
		}

		public void MoveSelectionDown(bool doCallback = true)
		{
		}

		[Obsolete]
		public void moveSelectionLeft(bool doCallback = true)
		{
		}

		public void MoveSelectionLeft(bool doCallback = true)
		{
		}

		[Obsolete]
		public void moveSelectionRight(bool doCallback = true)
		{
		}

		public void MoveSelectionRight(bool doCallback = true)
		{
		}

		[Obsolete]
		public void setSelected(Datum d, Column c = null, bool doCallback = true)
		{
		}

		public void SetSelected(Datum d, Column c = null, bool doCallback = true, bool animate = false, bool setFocusIfInput = true)
		{
		}

		public void SetDeselected(Datum d, Column c = null, bool doCallback = true)
		{
		}

		public List<Datum> GetSelectedDatumList()
		{
			return null;
		}

		private IEnumerator FocusLater(Cell c)
		{
			return null;
		}

		private IEnumerator DoVertScrollUntilVisible(Datum d, int focusCellIdx = -1)
		{
			return null;
		}

		[Obsolete]
		public Element getSelectedElement()
		{
			return null;
		}

		public Element GetSelectedElement()
		{
			return null;
		}

		public void error(string message)
		{
		}

		[Obsolete]
		public void reset()
		{
		}

		public void ResetTable()
		{
		}

		[Obsolete]
		public Column addTextColumn(string header = null, string footer = null, float minWidth = -1f, float maxWidth = -1f)
		{
			return null;
		}

		public Column AddTextColumn(string header = null, string footer = null, float minWidth = -1f, float maxWidth = -1f)
		{
			return null;
		}

		[Obsolete]
		public Column addInputColumn(Action<Datum, Column, string, string> changeCallback, string header = null, string footer = null, float minWidth = -1f, float maxWidth = -1f)
		{
			return null;
		}

		public Column AddInputColumn(Action<Datum, Column, string, string> changeCallback, string header = null, string footer = null, float minWidth = -1f, float maxWidth = -1f)
		{
			return null;
		}

		private Column AddTextOrInputColumn(string header = null, string footer = null, float minWidth = -1f, float maxWidth = -1f, bool isInput = false)
		{
			return null;
		}

		[Obsolete]
		public Column addImageColumn(string header = null, string footer = null, int imageWidth = 32, int imageHeight = 32)
		{
			return null;
		}

		public Column AddImageColumn(string header = null, string footer = null, int imageWidth = 32, int imageHeight = 32)
		{
			return null;
		}

		[Obsolete]
		public void initialize()
		{
		}

		public void Initialize()
		{
		}

		[Obsolete]
		public void initialize(Action<Datum, Column> selectionCallback, Dictionary<string, Sprite> sprites = null, bool hasHeaderIcons = false, Action<Column, PointerEventData> headerClickCallback = null)
		{
		}

		public void Initialize(Action<Datum, Column> selectionCallback, Dictionary<string, Sprite> sprites = null, bool hasHeaderIcons = false, Action<Column, PointerEventData> headerClickCallback = null)
		{
		}

		[Obsolete]
		public void initialize(Action<Datum> selectionCallback, Dictionary<string, Sprite> sprites = null, bool hasHeaderIcons = false, Action<Column, PointerEventData> headerClickCallback = null)
		{
		}

		public void Initialize(Action<Datum> selectionCallback, Dictionary<string, Sprite> sprites = null, bool hasHeaderIcons = false, Action<Column, PointerEventData> headerClickCallback = null)
		{
		}

		[Obsolete]
		public void initialize(Action<Datum, Column, RectTransform> selectionCallback, Dictionary<string, Sprite> sprites = null, bool hasHeaderIcons = false, Action<Column, PointerEventData> headerClickCallback = null)
		{
		}

		public void Initialize(Action<Datum, Column, RectTransform> selectionCallback, Dictionary<string, Sprite> sprites = null, bool hasHeaderIcons = false, Action<Column, PointerEventData> headerClickCallback = null)
		{
		}

		public void Initialize(Action<Datum, Column, RectTransform> selectionCallback, Dictionary<string, Sprite> sprites, bool hasHeaderIcons, Action<Column, PointerEventData> headerClickCallback, Action<Element, string> onCellLongPress)
		{
		}

		private void FinishInitialize(Dictionary<string, Sprite> sprites = null, bool hasHeaderIcons = false, Action<Column, PointerEventData> headerClickCallback = null)
		{
		}

		public void SetGameObjectActiveLater(GameObject go, bool state)
		{
		}

		private IEnumerator DoSetGameObjectActiveLater(GameObject go, bool state)
		{
			return null;
		}

		public void DirtyNow()
		{
		}

		public void DirtyLater()
		{
		}

		private IEnumerator DoDirtyLater()
		{
			return null;
		}

		public void FadeOverlay(float overTime, float v0, float v1, float delay = 0f)
		{
		}

		private IEnumerator DofadeOverlay(float overTime, float v0, float v1, float delay)
		{
			return null;
		}

		[Obsolete]
		public void startRenderEngine()
		{
		}

		public void StartRenderEngine()
		{
		}

		private IEnumerator _StartRenderEngine()
		{
			return null;
		}

		public void SetBodyRectSizeLater(float s1, float s2)
		{
		}

		private IEnumerator DoSetBodyRectSizeLater(float s1, float s2)
		{
			return null;
		}

		public void SetLayoutVertical()
		{
		}

		public void SetLayoutHorizontal()
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		private void RedrawTable()
		{
		}

		private IEnumerator DoStartRenderLater()
		{
			return null;
		}

		public Row GetRowForDatum(Datum item)
		{
			return null;
		}

		private void OnDrawGizmosSelected()
		{
		}
	}
}
