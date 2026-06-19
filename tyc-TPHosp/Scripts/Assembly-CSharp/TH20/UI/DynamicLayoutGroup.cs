using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	[AddComponentMenu("Layout/Dynamic Layout Group", 107)]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	public class DynamicLayoutGroup : ElementLayoutController, ILayoutGroup, ILayoutController, ILayoutSelfController, ILayoutElement, IMaxSizeLayoutElement
	{
		private struct Element
		{
			public RectTransform RectTransform;

			public ILayoutController LayoutController;

			public CachedLayoutElement CachedLayoutElement;

			public bool IgnoreLayout;

			public Vector2 Min;

			public Vector2 Preferred;

			public Vector2 Max;
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
			Middle = 1,
			Bottom = 2
		}

		public enum ResizeMode
		{
			PreferredSize = 0,
			ResizeLayoutGroupToFitContents = 1,
			ResizeContentsToFitLayoutGroup = 2
		}

		[SerializeField]
		private RectTransform.Axis _axis;

		[SerializeField]
		private HorizontalAlignment _horizontalAlignment;

		[SerializeField]
		private VerticalAlignment _verticalAlignment;

		private int _elementsCount;

		private Element[] _elements;

		[SerializeField]
		private ResizeMode _verticalResizeMode;

		[SerializeField]
		private ResizeMode _horizontalResizeMode;

		[SerializeField]
		private float _minimumSpacing;

		[SerializeField]
		private bool _justifiedSpacing;

		[SerializeField]
		private RectOffset _padding = new RectOffset();

		[SerializeField]
		private float _defaultMinHeight = -1f;

		[SerializeField]
		private float _defaultMinWidth = -1f;

		[SerializeField]
		private float _defaultPreferredHeight = 100f;

		[SerializeField]
		private float _defaultPreferredWidth = 100f;

		[SerializeField]
		private float _defaultMaxHeight = -1f;

		[SerializeField]
		private float _defaultMaxWidth = -1f;

		[SerializeField]
		private bool _nestedFixes;

		private DrivenRectTransformTracker _drivenRectTracker;

		private bool _isLayoutElementDirty = true;

		private readonly List<ILayoutElement> _layoutElementsCache = new List<ILayoutElement>();

		private readonly List<IMaxSizeLayoutElement> _maxSizeLayoutElementsCache = new List<IMaxSizeLayoutElement>();

		private readonly List<ILayoutIgnorer> _layoutIgnorersCache = new List<ILayoutIgnorer>();

		private int _numOfElementsToLayout;

		private Vector2 _totalElementMinSize = Vector2.zero;

		private Vector2 _totalElementPreferredSize = Vector2.zero;

		private Vector2 _maxElementPreferredSize = Vector2.zero;

		private Vector2 _totalElementMaxSize = Vector2.zero;

		private Vector2 _minElementSize = Vector2.zero;

		private Vector2 _maxElementSize = Vector2.zero;

		private Vector2 _layoutMinSize = Vector2.zero;

		private Vector2 _layoutPreferredSize = Vector2.zero;

		private Vector2 _layoutMaxSize = Vector2.zero;

		private bool isRootLayoutGroup
		{
			get
			{
				if (!(base.transform.parent == null))
				{
					return base.transform.parent.GetComponent<ILayoutGroup>() == null;
				}
				return true;
			}
		}

		public RectTransform.Axis axis
		{
			get
			{
				return _axis;
			}
			set
			{
				_axis = value;
				SetDirty();
			}
		}

		public float minimumSpacing
		{
			get
			{
				return _minimumSpacing;
			}
			set
			{
				_minimumSpacing = value;
				SetDirty();
			}
		}

		public bool justifiedSpacing
		{
			get
			{
				return _justifiedSpacing;
			}
			set
			{
				_justifiedSpacing = value;
				SetDirty();
			}
		}

		public RectOffset padding
		{
			get
			{
				return _padding;
			}
			set
			{
				_padding = value;
				SetDirty();
			}
		}

		public HorizontalAlignment horizontalAlignment
		{
			get
			{
				return _horizontalAlignment;
			}
			set
			{
				_horizontalAlignment = value;
				SetDirty();
			}
		}

		public VerticalAlignment verticalAlignment
		{
			get
			{
				return _verticalAlignment;
			}
			set
			{
				_verticalAlignment = value;
				SetDirty();
			}
		}

		public ResizeMode horizontalResizeMode
		{
			get
			{
				return _horizontalResizeMode;
			}
			set
			{
				_horizontalResizeMode = value;
				SetDirty();
			}
		}

		public ResizeMode verticalResizeMode
		{
			get
			{
				return _verticalResizeMode;
			}
			set
			{
				_verticalResizeMode = value;
				SetDirty();
			}
		}

		public bool nestedFixes
		{
			get
			{
				return _nestedFixes;
			}
			set
			{
				_nestedFixes = value;
				SetDirty();
			}
		}

		public float defaultMinHeight
		{
			get
			{
				return _defaultMinHeight;
			}
			set
			{
				_defaultMinHeight = value;
				SetDirty();
			}
		}

		public float defaultMinWidth
		{
			get
			{
				return _defaultMinWidth;
			}
			set
			{
				_defaultMinWidth = value;
				SetDirty();
			}
		}

		public float defaultPreferredHeight
		{
			get
			{
				return _defaultPreferredHeight;
			}
			set
			{
				_defaultPreferredHeight = value;
				SetDirty();
			}
		}

		public float defaultPreferredWidth
		{
			get
			{
				return _defaultPreferredWidth;
			}
			set
			{
				_defaultPreferredWidth = value;
				SetDirty();
			}
		}

		public float defaultMaxHeight
		{
			get
			{
				return _defaultMaxHeight;
			}
			set
			{
				_defaultMaxHeight = value;
				SetDirty();
			}
		}

		public float defaultMaxWidth
		{
			get
			{
				return _defaultMaxWidth;
			}
			set
			{
				_defaultMaxWidth = value;
				SetDirty();
			}
		}

		public int layoutPriority
		{
			get
			{
				if (!_nestedFixes)
				{
					return 0;
				}
				return 2;
			}
		}

		public float minWidth
		{
			get
			{
				CalculateLayoutElementValuesIfDirty();
				return _layoutMinSize.x;
			}
		}

		public float preferredWidth
		{
			get
			{
				CalculateLayoutElementValuesIfDirty();
				return _layoutPreferredSize.x;
			}
		}

		public float maxWidth
		{
			get
			{
				CalculateLayoutElementValuesIfDirty();
				if (_nestedFixes && _horizontalResizeMode == ResizeMode.ResizeLayoutGroupToFitContents)
				{
					return _layoutPreferredSize.x;
				}
				if (_axis == RectTransform.Axis.Horizontal && _justifiedSpacing)
				{
					return float.MaxValue;
				}
				return _layoutMaxSize.x;
			}
		}

		public float flexibleWidth => 0f;

		public float minHeight
		{
			get
			{
				CalculateLayoutElementValuesIfDirty();
				return _layoutMinSize.y;
			}
		}

		public float preferredHeight
		{
			get
			{
				CalculateLayoutElementValuesIfDirty();
				return _layoutPreferredSize.y;
			}
		}

		public float maxHeight
		{
			get
			{
				CalculateLayoutElementValuesIfDirty();
				if (_nestedFixes && _verticalResizeMode == ResizeMode.ResizeLayoutGroupToFitContents)
				{
					return _layoutPreferredSize.y;
				}
				if (_axis == RectTransform.Axis.Vertical && _justifiedSpacing)
				{
					return float.MaxValue;
				}
				return _layoutMaxSize.y;
			}
		}

		public float flexibleHeight => 0f;

		public void CalculateLayoutInputHorizontal()
		{
		}

		public void CalculateLayoutInputVertical()
		{
		}

		protected override void OnEnable()
		{
			base.OnEnable();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			_drivenRectTracker.Clear();
		}

		protected void OnTransformChildrenChanged()
		{
			CheckElementsArray(forceRefresh: true);
			SetDirty();
		}

		protected override void OnRectTransformDimensionsChange()
		{
			if (isRootLayoutGroup)
			{
				SetDirty();
			}
		}

		protected override void MarkDirty()
		{
			_isLayoutElementDirty = true;
			base.MarkDirty();
		}

		void ILayoutController.SetLayoutHorizontal()
		{
			CheckElementsArray(forceRefresh: false);
			switch (_horizontalResizeMode)
			{
			case ResizeMode.PreferredSize:
				if (_axis == RectTransform.Axis.Horizontal)
				{
					CheckElementsArray(forceRefresh: false);
					SetLayout();
				}
				break;
			case ResizeMode.ResizeContentsToFitLayoutGroup:
				CheckElementsArray(forceRefresh: false);
				SetLayout();
				SetLayoutOnChildren(RectTransform.Axis.Horizontal);
				SetLayoutOnChildren(RectTransform.Axis.Vertical);
				break;
			case ResizeMode.ResizeLayoutGroupToFitContents:
				if (_axis == RectTransform.Axis.Horizontal)
				{
					CheckElementsArray(forceRefresh: false);
					SetLayoutOnChildren(RectTransform.Axis.Horizontal);
					SetLayout();
					SetLayoutOnChildren(RectTransform.Axis.Horizontal);
					SetLayout();
				}
				break;
			}
		}

		void ILayoutController.SetLayoutVertical()
		{
			switch (_verticalResizeMode)
			{
			case ResizeMode.PreferredSize:
				if (_axis == RectTransform.Axis.Vertical)
				{
					CheckElementsArray(forceRefresh: false);
					SetLayout();
				}
				break;
			case ResizeMode.ResizeContentsToFitLayoutGroup:
				CheckElementsArray(forceRefresh: false);
				SetLayout();
				SetLayoutOnChildren(RectTransform.Axis.Horizontal);
				SetLayoutOnChildren(RectTransform.Axis.Vertical);
				break;
			case ResizeMode.ResizeLayoutGroupToFitContents:
				if (_axis == RectTransform.Axis.Vertical)
				{
					CheckElementsArray(forceRefresh: false);
					SetLayoutOnChildren(RectTransform.Axis.Vertical);
					SetLayout();
					SetLayoutOnChildren(RectTransform.Axis.Vertical);
					SetLayout();
				}
				break;
			}
		}

		private void SetLayoutOnChildren(RectTransform.Axis axis)
		{
			for (int i = 0; i < _elementsCount; i++)
			{
				RectTransform rectTransform = _elements[i].RectTransform;
				if (rectTransform == null || rectTransform.gameObject == null || !rectTransform.gameObject.activeSelf)
				{
					continue;
				}
				ILayoutController layoutController = _elements[i].LayoutController;
				if (layoutController != null && ((Behaviour)layoutController).enabled)
				{
					switch (axis)
					{
					case RectTransform.Axis.Horizontal:
						layoutController.SetLayoutHorizontal();
						break;
					case RectTransform.Axis.Vertical:
						layoutController.SetLayoutVertical();
						break;
					}
				}
			}
		}

		private void CheckElementsArray(bool forceRefresh)
		{
			RectTransform rectTransform = base.RectTransform;
			if (_elements == null || forceRefresh)
			{
				_elementsCount = rectTransform.childCount;
				if (_elements == null || _elements.Length < _elementsCount)
				{
					_elements = new Element[Mathf.NextPowerOfTwo(_elementsCount)];
				}
				for (int i = 0; i < _elementsCount; i++)
				{
					Transform child = rectTransform.GetChild(i);
					_elements[i] = new Element
					{
						RectTransform = child.GetComponent<RectTransform>(),
						LayoutController = child.GetComponent<ILayoutController>(),
						CachedLayoutElement = child.GetComponent<CachedLayoutElement>()
					};
				}
			}
		}

		private bool CollectLayoutValues(RectTransform rect, ref Vector2 min, ref Vector2 preferred, ref Vector2 max)
		{
			bool flag = false;
			_layoutElementsCache.Clear();
			_layoutIgnorersCache.Clear();
			_maxSizeLayoutElementsCache.Clear();
			rect.GetComponents(_layoutElementsCache);
			rect.GetComponents(_layoutIgnorersCache);
			rect.GetComponents(_maxSizeLayoutElementsCache);
			foreach (ILayoutIgnorer item in _layoutIgnorersCache)
			{
				if (((Behaviour)item).enabled)
				{
					flag = flag || item.ignoreLayout;
				}
			}
			float num = float.NegativeInfinity;
			foreach (ILayoutElement item2 in _layoutElementsCache)
			{
				if (((Behaviour)item2).enabled && (float)item2.layoutPriority >= num)
				{
					num = item2.layoutPriority;
					item2.CalculateLayoutInputHorizontal();
					item2.CalculateLayoutInputVertical();
					if (item2.minWidth >= 0f)
					{
						min.x = item2.minWidth;
					}
					if (item2.minHeight >= 0f)
					{
						min.y = item2.minHeight;
					}
					if (item2.preferredWidth >= 0f)
					{
						preferred.x = item2.preferredWidth;
					}
					if (item2.preferredHeight >= 0f)
					{
						preferred.y = item2.preferredHeight;
					}
				}
			}
			float num2 = float.NegativeInfinity;
			foreach (IMaxSizeLayoutElement item3 in _maxSizeLayoutElementsCache)
			{
				if (((Behaviour)item3).enabled && (float)item3.layoutPriority >= num2)
				{
					num2 = item3.layoutPriority;
					if (item3.maxWidth >= 0f)
					{
						max.x = item3.maxWidth;
					}
					if (item3.maxHeight >= 0f)
					{
						max.y = item3.maxHeight;
					}
				}
			}
			max.x = Mathf.Max(min.x, max.x);
			max.y = Mathf.Max(min.y, max.y);
			preferred.x = Mathf.Clamp(preferred.x, min.x, max.x);
			preferred.y = Mathf.Clamp(preferred.y, min.y, max.y);
			return flag;
		}

		private void SetupDefaultLayoutSizes(ref Vector2 min, ref Vector2 preferred, ref Vector2 max)
		{
			if (min.x < 0f)
			{
				min.x = 0f;
			}
			if (min.y < 0f)
			{
				min.y = 0f;
			}
			if (max.x < 0f)
			{
				max.x = 1000000f;
			}
			if (max.y < 0f)
			{
				max.y = 1000000f;
			}
		}

		private void CalculateLayoutGroupValues()
		{
			if (_numOfElementsToLayout == 0)
			{
				_layoutMinSize.x = padding.horizontal;
				_layoutMinSize.y = padding.vertical;
				_layoutPreferredSize = _layoutMinSize;
				_layoutMaxSize = _layoutMinSize;
				return;
			}
			if (_axis == RectTransform.Axis.Vertical)
			{
				_layoutMinSize.x = _minElementSize.x + (float)_padding.horizontal;
				_layoutMinSize.y = _totalElementMinSize.y + (float)_padding.vertical;
				_layoutPreferredSize.x = _maxElementPreferredSize.x + (float)_padding.horizontal;
				_layoutPreferredSize.y = _totalElementPreferredSize.y + (float)_padding.vertical;
				_layoutMaxSize.x = _maxElementSize.x + (float)_padding.horizontal;
				_layoutMaxSize.y = _totalElementMaxSize.y + (float)_padding.vertical;
			}
			else
			{
				_layoutMinSize.x = _totalElementMinSize.x + (float)_padding.horizontal;
				_layoutMinSize.y = _minElementSize.y + (float)_padding.vertical;
				_layoutPreferredSize.x = _totalElementPreferredSize.x + (float)_padding.horizontal;
				_layoutPreferredSize.y = _maxElementPreferredSize.y + (float)padding.vertical;
				_layoutMaxSize.x = _totalElementMaxSize.x + (float)_padding.horizontal;
				_layoutMaxSize.y = _maxElementSize.y + (float)_padding.vertical;
			}
			if (_axis == RectTransform.Axis.Vertical)
			{
				_layoutMinSize.y += _minimumSpacing * (float)(_numOfElementsToLayout - 1);
				_layoutPreferredSize.y += _minimumSpacing * (float)(_numOfElementsToLayout - 1);
				_layoutMaxSize.y += _minimumSpacing * (float)(_numOfElementsToLayout - 1);
			}
			else
			{
				_layoutMinSize.x += _minimumSpacing * (float)(_numOfElementsToLayout - 1);
				_layoutPreferredSize.x += _minimumSpacing * (float)(_numOfElementsToLayout - 1);
				_layoutMaxSize.x += _minimumSpacing * (float)(_numOfElementsToLayout - 1);
			}
		}

		private void CalculateLayoutElementValuesIfDirty()
		{
			if (!_isLayoutElementDirty)
			{
				return;
			}
			CheckElementsArray(_nestedFixes);
			_numOfElementsToLayout = 0;
			_totalElementMinSize = Vector2.zero;
			_totalElementPreferredSize = Vector2.zero;
			_maxElementPreferredSize = Vector2.zero;
			_totalElementMaxSize = Vector2.zero;
			_minElementSize = Vector2.zero;
			_maxElementSize = new Vector2(float.MaxValue, float.MaxValue);
			for (int i = 0; i < _elementsCount; i++)
			{
				RectTransform rectTransform = _elements[i].RectTransform;
				if (rectTransform == null || !rectTransform.gameObject.activeSelf)
				{
					continue;
				}
				if (_elements[i].CachedLayoutElement == null || _elements[i].CachedLayoutElement.IsDirty)
				{
					Vector2 min = new Vector2(_defaultMinWidth, _defaultMinHeight);
					Vector2 preferred = new Vector2(_defaultPreferredWidth, _defaultPreferredHeight);
					Vector2 max = new Vector2(_defaultMaxWidth, _defaultMaxHeight);
					SetupDefaultLayoutSizes(ref min, ref preferred, ref max);
					_elements[i].IgnoreLayout = CollectLayoutValues(rectTransform, ref min, ref preferred, ref max);
					_elements[i].Min = min;
					_elements[i].Preferred = preferred;
					_elements[i].Max = max;
					if (_elements[i].CachedLayoutElement != null)
					{
						_elements[i].CachedLayoutElement.IsDirty = false;
					}
				}
				if (!_elements[i].IgnoreLayout)
				{
					_minElementSize.x = Mathf.Max(_minElementSize.x, _elements[i].Min.x);
					_minElementSize.y = Mathf.Max(_minElementSize.y, _elements[i].Min.y);
					_maxElementSize.x = Mathf.Min(_maxElementSize.x, _elements[i].Max.x);
					_maxElementSize.y = Mathf.Min(_maxElementSize.y, _elements[i].Max.y);
					_maxElementPreferredSize.x = Mathf.Max(_maxElementPreferredSize.x, _elements[i].Preferred.x);
					_maxElementPreferredSize.y = Mathf.Max(_maxElementPreferredSize.y, _elements[i].Preferred.y);
					_totalElementMinSize += _elements[i].Min;
					_totalElementPreferredSize += _elements[i].Preferred;
					_totalElementMaxSize += _elements[i].Max;
					if (_nestedFixes)
					{
						_numOfElementsToLayout++;
					}
				}
			}
			CalculateLayoutGroupValues();
			_isLayoutElementDirty = false;
		}

		private void SetLayout()
		{
			_drivenRectTracker.Clear();
			RectTransform rectTransform = base.RectTransform;
			if (rectTransform == null)
			{
				throw new Exception("DynamicLayoutGroup RectTransform is null");
			}
			float num = _minimumSpacing;
			float num2 = 0f;
			Vector2 totalSize = Vector2.zero;
			_totalElementMinSize = Vector2.zero;
			_totalElementPreferredSize = Vector2.zero;
			_maxElementPreferredSize = Vector2.zero;
			_totalElementMaxSize = Vector2.zero;
			_minElementSize = new Vector2(0f, 0f);
			_maxElementSize = new Vector2(float.MaxValue, float.MaxValue);
			_numOfElementsToLayout = 0;
			if (_elements == null)
			{
				throw new Exception("_elements array is null");
			}
			if (_elementsCount > _elements.Length)
			{
				throw new Exception("_elementsCount exceeds _elements array length");
			}
			for (int i = 0; i < _elementsCount; i++)
			{
				RectTransform rectTransform2 = _elements[i].RectTransform;
				if (rectTransform2 == null || !rectTransform2.gameObject.activeSelf)
				{
					_elements[i].IgnoreLayout = true;
					continue;
				}
				if (_elements[i].CachedLayoutElement == null || _elements[i].CachedLayoutElement.IsDirty)
				{
					Vector2 min = new Vector2(_defaultMinWidth, _defaultMinHeight);
					Vector2 preferred = new Vector2(_defaultPreferredWidth, _defaultPreferredHeight);
					Vector2 max = new Vector2(_defaultMaxWidth, _defaultMaxHeight);
					SetupDefaultLayoutSizes(ref min, ref preferred, ref max);
					_elements[i].IgnoreLayout = CollectLayoutValues(rectTransform2, ref min, ref preferred, ref max);
					_elements[i].Min = min;
					_elements[i].Preferred = preferred;
					_elements[i].Max = max;
					if (_elements[i].CachedLayoutElement != null)
					{
						_elements[i].CachedLayoutElement.IsDirty = false;
					}
				}
				if (!_elements[i].IgnoreLayout)
				{
					if (_axis == RectTransform.Axis.Vertical)
					{
						totalSize.y += num;
					}
					else
					{
						totalSize.x += num;
					}
					_minElementSize.x = Mathf.Max(_minElementSize.x, _elements[i].Min.x);
					_minElementSize.y = Mathf.Max(_minElementSize.y, _elements[i].Min.y);
					_maxElementSize.x = Mathf.Min(_maxElementSize.x, _elements[i].Max.x);
					_maxElementSize.y = Mathf.Min(_maxElementSize.y, _elements[i].Max.y);
					_maxElementPreferredSize.x = Mathf.Max(_maxElementPreferredSize.x, _elements[i].Preferred.x);
					_maxElementPreferredSize.y = Mathf.Max(_maxElementPreferredSize.y, _elements[i].Preferred.y);
					num2 += num;
					_totalElementMinSize += _elements[i].Min;
					_totalElementPreferredSize += _elements[i].Preferred;
					_totalElementMaxSize += _elements[i].Max;
					totalSize += _elements[i].Preferred;
					_numOfElementsToLayout++;
				}
			}
			if (_axis == RectTransform.Axis.Vertical)
			{
				totalSize.y = Mathf.Max(0f, totalSize.y - num);
			}
			else
			{
				totalSize.x = Mathf.Max(0f, totalSize.x - num);
			}
			num2 = Mathf.Max(0f, num2 - num);
			totalSize.x += _padding.horizontal;
			totalSize.y += _padding.vertical;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			if (_axis == RectTransform.Axis.Vertical)
			{
				switch (_horizontalAlignment)
				{
				case HorizontalAlignment.Center:
					num3 += (float)(_padding.left - _padding.right) * 0.5f;
					break;
				case HorizontalAlignment.Left:
					num3 += (float)_padding.left;
					break;
				case HorizontalAlignment.Right:
					num3 += (float)_padding.right;
					break;
				}
				num4 += (float)_padding.top;
			}
			else
			{
				num3 += (float)_padding.left;
				switch (_verticalAlignment)
				{
				case VerticalAlignment.Middle:
					num4 += (float)(_padding.bottom - _padding.top) * 0.5f;
					break;
				case VerticalAlignment.Bottom:
					num4 += (float)_padding.bottom;
					break;
				case VerticalAlignment.Top:
					num4 += (float)_padding.top;
					break;
				}
			}
			if (_verticalResizeMode == ResizeMode.ResizeContentsToFitLayoutGroup)
			{
				ResizeContent(RectTransform.Axis.Vertical, rectTransform, num2, _totalElementMinSize, _totalElementMaxSize, _totalElementPreferredSize, ref totalSize);
			}
			if (_horizontalResizeMode == ResizeMode.ResizeContentsToFitLayoutGroup)
			{
				ResizeContent(RectTransform.Axis.Horizontal, rectTransform, num2, _totalElementMinSize, _totalElementMaxSize, _totalElementPreferredSize, ref totalSize);
			}
			if (_justifiedSpacing && _numOfElementsToLayout > 1)
			{
				float num7;
				float num8;
				if (_axis == RectTransform.Axis.Vertical)
				{
					num7 = rectTransform.rect.height - (float)_padding.vertical;
					num8 = totalSize.y - (float)_padding.vertical - num * (float)(_numOfElementsToLayout - 1);
				}
				else
				{
					num7 = rectTransform.rect.width - (float)_padding.horizontal;
					num8 = totalSize.x - (float)_padding.horizontal - num * (float)(_numOfElementsToLayout - 1);
				}
				float num9 = Mathf.Max(0f, num7 - num8);
				num = Mathf.Max(num, num9 / (float)(_numOfElementsToLayout - 1));
				totalSize[(int)_axis] = num8 + num * (float)(_numOfElementsToLayout - 1);
				if (_axis == RectTransform.Axis.Vertical)
				{
					totalSize.y += _padding.vertical;
				}
				else
				{
					totalSize.x += _padding.horizontal;
				}
			}
			DrivenTransformProperties drivenProperties = DrivenTransformProperties.Anchors | DrivenTransformProperties.AnchoredPosition | DrivenTransformProperties.SizeDelta;
			for (int j = 0; j < _elementsCount; j++)
			{
				if (_elements[j].IgnoreLayout || _elements[j].RectTransform == null)
				{
					continue;
				}
				RectTransform rectTransform3 = _elements[j].RectTransform;
				float x = _elements[j].Preferred.x;
				float y = _elements[j].Preferred.y;
				_drivenRectTracker.Add(this, rectTransform3, drivenProperties);
				switch (_horizontalAlignment)
				{
				case HorizontalAlignment.Left:
					if (_axis == RectTransform.Axis.Vertical)
					{
						rectTransform3.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Left, num3, x);
					}
					else
					{
						rectTransform3.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Left, num3, x);
					}
					break;
				case HorizontalAlignment.Center:
					if (_axis == RectTransform.Axis.Vertical)
					{
						rectTransform3.SetInsetAndSizeFromCenter(RectTransform.Axis.Horizontal, num3 - x * (1f - rectTransform3.pivot.x) + x * 0.5f, x);
					}
					else
					{
						rectTransform3.SetInsetAndSizeFromCenter(RectTransform.Axis.Horizontal, num3 + x * rectTransform3.pivot.x - totalSize.x * 0.5f, x);
					}
					break;
				case HorizontalAlignment.Right:
					if (_axis == RectTransform.Axis.Vertical)
					{
						rectTransform3.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Right, num3, x);
					}
					else
					{
						rectTransform3.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Right, totalSize.x - num3 - x, x);
					}
					break;
				}
				switch (_verticalAlignment)
				{
				case VerticalAlignment.Bottom:
					if (_axis == RectTransform.Axis.Vertical)
					{
						rectTransform3.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Bottom, totalSize.y - num4 - y, y);
					}
					else
					{
						rectTransform3.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Bottom, num4, y);
					}
					break;
				case VerticalAlignment.Middle:
					if (_axis == RectTransform.Axis.Vertical)
					{
						rectTransform3.SetInsetAndSizeFromCenter(RectTransform.Axis.Vertical, totalSize.y * 0.5f - num4 - y * (1f - rectTransform3.pivot.y), y);
					}
					else
					{
						rectTransform3.SetInsetAndSizeFromCenter(RectTransform.Axis.Vertical, num4 - y * (1f - rectTransform3.pivot.y) + y * 0.5f, y);
					}
					break;
				case VerticalAlignment.Top:
					if (_axis == RectTransform.Axis.Vertical)
					{
						rectTransform3.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Top, num4, y);
					}
					else
					{
						rectTransform3.SetInsetAndSizeFromParentEdgeSafe(RectTransform.Edge.Top, num4, y);
					}
					break;
				}
				num5 = Mathf.Max(num5, rectTransform3.sizeDelta.x);
				num6 = Mathf.Max(num6, rectTransform3.sizeDelta.y);
				if (_axis == RectTransform.Axis.Vertical)
				{
					num4 += _elements[j].Preferred.y + num;
				}
				else
				{
					num3 += _elements[j].Preferred.x + num;
				}
			}
			if (_verticalResizeMode == ResizeMode.ResizeLayoutGroupToFitContents)
			{
				if (rectTransform.parent.gameObject.GetComponent(typeof(ILayoutController)) == null)
				{
					_drivenRectTracker.Add(this, rectTransform, DrivenTransformProperties.SizeDeltaY);
				}
				if (_axis == RectTransform.Axis.Vertical)
				{
					rectTransform.SetSizeWithCurrentAnchorsSafe(RectTransform.Axis.Vertical, totalSize.y);
				}
				else
				{
					rectTransform.SetSizeWithCurrentAnchorsSafe(RectTransform.Axis.Vertical, num6 + (float)_padding.vertical);
				}
			}
			if (_horizontalResizeMode == ResizeMode.ResizeLayoutGroupToFitContents)
			{
				if (rectTransform.parent.gameObject.GetComponent(typeof(ILayoutController)) == null)
				{
					_drivenRectTracker.Add(this, rectTransform, DrivenTransformProperties.SizeDeltaX);
				}
				if (_axis == RectTransform.Axis.Vertical)
				{
					rectTransform.SetSizeWithCurrentAnchorsSafe(RectTransform.Axis.Horizontal, num5 + (float)_padding.horizontal);
				}
				else
				{
					rectTransform.SetSizeWithCurrentAnchorsSafe(RectTransform.Axis.Horizontal, totalSize.x);
				}
			}
			CalculateLayoutGroupValues();
			_isLayoutElementDirty = false;
		}

		private void ResizeContent(RectTransform.Axis mode, RectTransform rectTransform, float totalSpacing, Vector2 totalMinSize, Vector2 totalMaxSize, Vector2 totalPreferredSize, ref Vector2 totalSize)
		{
			float num = ((mode != RectTransform.Axis.Vertical) ? (rectTransform.rect.width - (float)_padding.horizontal) : (rectTransform.rect.height - (float)_padding.vertical));
			if (_axis == mode)
			{
				float num2 = num - totalSpacing;
				if (totalSize[(int)mode] >= rectTransform.rect.size[(int)mode])
				{
					float num3 = totalPreferredSize[(int)mode] - totalMinSize[(int)mode];
					float num4 = (num2 - totalMinSize[(int)mode]) / num3;
					num4 = Mathf.Clamp01(1f - num4);
					for (int i = 0; i < _elementsCount; i++)
					{
						if (!_elements[i].IgnoreLayout && !(_elements[i].RectTransform == null))
						{
							_elements[i].Preferred[(int)mode] -= (_elements[i].Preferred[(int)mode] - _elements[i].Min[(int)mode]) * num4;
						}
					}
					totalSize[(int)mode] -= (totalPreferredSize[(int)mode] - totalMinSize[(int)mode]) * num4;
					return;
				}
				double num5 = totalMaxSize[(int)mode] - totalPreferredSize[(int)mode];
				double val = (double)(totalMaxSize[(int)mode] - num2) / num5;
				val = Math.Max(val, 0.0);
				val = Math.Min(val, 1.0);
				val = 1.0 - val;
				for (int j = 0; j < _elementsCount; j++)
				{
					if (!_elements[j].IgnoreLayout && !(_elements[j].RectTransform == null))
					{
						double num6 = (double)(_elements[j].Max[(int)mode] - _elements[j].Preferred[(int)mode]) * val;
						_elements[j].Preferred[(int)mode] += (float)num6;
					}
				}
				totalSize[(int)mode] += (totalMaxSize[(int)mode] - totalPreferredSize[(int)mode]) * (float)val;
				return;
			}
			for (int k = 0; k < _elementsCount; k++)
			{
				if (!_elements[k].IgnoreLayout && !(_elements[k].RectTransform == null))
				{
					_elements[k].Preferred[(int)mode] = Mathf.Clamp(num, _elements[k].Min[(int)mode], _elements[k].Max[(int)mode]);
				}
			}
		}
	}
}
