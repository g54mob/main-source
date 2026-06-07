using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Jundroo.Common.Extensions;
using Jundroo.Common.Platform;
using Jundroo.Juicy.Widgets.Extra;
using Jundroo.Juicy.Widgets.Serialization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Jundroo.Juicy.Widgets
{
	public class Widget : MonoBehaviour, ILayoutElement, ILayoutIgnorer, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler
	{
		public enum DirtyFlags
		{
			None = 0,
			ApplyStyes = 1,
			UpdateLayout = 2,
			ReapplyNestedClasses = 4
		}

		public enum WidgetPositionConstraintType
		{
			None = 0,
			Screen = 1
		}

		public const float HoverSoundDelay = 0.05f;

		private readonly List<Widget> _widgets = new List<Widget>();

		private bool _allowDragging;

		private CanvasGroup _canvasGroup;

		[SerializeField]
		private RectTransform _childContainer;

		[SerializeField]
		private List<string> _classNames = new List<string>();

		private bool _collapsed;

		private int _columnOffset;

		private RectOffset _columnPadding = new RectOffset();

		private int _columnSpan;

		private int _columnStart = -1;

		private DirtyFlags _dirty;

		private Dictionary<string, IDynamicValue> _dynamicValues;

		private bool _flagged;

		private float? _flexibleHeight;

		private float? _flexibleWidth;

		private bool _hasError;

		private float? _height;

		private bool _ignoreLayout;

		private LayoutElement _layoutElement;

		private int? _layoutPriority;

		private RectOffset _margin = new RectOffset();

		private float? _minHeight;

		private float? _minWidth;

		private List<string> _nestedClassNames = new List<string>();

		private WidgetPositionConstraintType _positionConstraint;

		private float? _preferredHeight;

		private float? _preferredWidth;

		private bool _safeArea;

		private IWidgetScript _script;

		private bool _updatingWidget;

		private bool _useLayoutElement;

		private bool _visible = true;

		private float? _width;

		public bool AllowDragging
		{
			get
			{
				return _allowDragging;
			}
			set
			{
				_allowDragging = value;
				WidgetDragHandler component = base.gameObject.GetComponent<WidgetDragHandler>();
				if (_allowDragging)
				{
					if (component == null)
					{
						base.gameObject.AddComponent<WidgetDragHandler>();
					}
				}
				else if (component != null)
				{
					UnityEngine.Object.Destroy(component);
				}
			}
		}

		public WidgetAnimationManager Animation { get; private set; }

		public WidgetBorder Border { get; private set; }

		public RectTransform ChildContainer => _childContainer;

		public bool ChildrenLoaded { get; private set; }

		public virtual bool Collapsed
		{
			get
			{
				return _collapsed;
			}
			set
			{
				_collapsed = value;
				UpdateVisibility();
			}
		}

		public int ColumnOffset
		{
			get
			{
				return _columnOffset;
			}
			set
			{
				if (_columnOffset != value)
				{
					_columnOffset = value;
					Parent.SetDirtyFlag(DirtyFlags.UpdateLayout);
				}
			}
		}

		public RectOffset ColumnPadding
		{
			get
			{
				return _columnPadding;
			}
			set
			{
				_columnPadding = value;
				Parent.SetDirtyFlag(DirtyFlags.UpdateLayout);
			}
		}

		public int ColumnSpan
		{
			get
			{
				return _columnSpan;
			}
			set
			{
				if (_columnSpan != value)
				{
					_columnSpan = value;
					Parent.SetDirtyFlag(DirtyFlags.UpdateLayout);
				}
			}
		}

		public int ColumnStart
		{
			get
			{
				return _columnStart;
			}
			set
			{
				if (_columnStart != value)
				{
					_columnStart = value;
					Parent.SetDirtyFlag(DirtyFlags.UpdateLayout);
				}
			}
		}

		public IWidgetContext Context { get; private set; }

		public string Data { get; set; }

		public object DataModel { get; set; }

		public XElement Element { get; private set; }

		public string ErrorClass { get; set; }

		public string EventClick { get; set; }

		public string EventDeselect { get; set; }

		public object EventHandler { get; set; }

		public string EventHoverEnter { get; set; }

		public string EventHoverExit { get; set; }

		public string EventPointerDown { get; set; }

		public string EventPointerUp { get; set; }

		public string EventSelect { get; set; }

		public bool Flagged
		{
			get
			{
				return _flagged;
			}
			set
			{
				if (_flagged == value)
				{
					return;
				}
				_flagged = value;
				if (!string.IsNullOrEmpty(FlaggedClass))
				{
					if (_flagged)
					{
						AddClass(FlaggedClass);
					}
					else
					{
						RemoveClass(FlaggedClass);
					}
				}
			}
		}

		public string FlaggedClass { get; set; }

		float ILayoutElement.flexibleHeight => _flexibleHeight.GetValueOrDefault();

		public float FlexibleHeight
		{
			get
			{
				return _flexibleHeight.GetValueOrDefault();
			}
			set
			{
				_flexibleHeight = value;
				if (_useLayoutElement && _layoutElement != null)
				{
					_layoutElement.flexibleHeight = value;
				}
			}
		}

		float ILayoutElement.flexibleWidth => _flexibleWidth.GetValueOrDefault();

		public float FlexibleWidth
		{
			get
			{
				return _flexibleWidth.GetValueOrDefault();
			}
			set
			{
				_flexibleWidth = value;
				if (UseLayoutElement && _layoutElement != null)
				{
					_layoutElement.flexibleWidth = value;
				}
			}
		}

		public bool HasError
		{
			get
			{
				return _hasError;
			}
			set
			{
				if (_hasError == value)
				{
					return;
				}
				_hasError = value;
				if (!string.IsNullOrEmpty(ErrorClass))
				{
					if (_hasError)
					{
						AddClass(ErrorClass);
					}
					else
					{
						RemoveClass(ErrorClass);
					}
				}
			}
		}

		public float? Height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
				if (value.HasValue)
				{
					Rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, value.Value);
				}
			}
		}

		public string HoverClass { get; set; }

		public string Id { get; private set; }

		bool ILayoutIgnorer.ignoreLayout => _ignoreLayout;

		public bool IgnoreLayout
		{
			get
			{
				return _ignoreLayout;
			}
			set
			{
				_ignoreLayout = value;
				if (_useLayoutElement && _layoutElement != null)
				{
					_layoutElement.ignoreLayout = value;
				}
			}
		}

		public int Index => Parent._widgets.IndexOf(this);

		public virtual bool Interactable { get; set; } = true;

		public bool IsPointerInside { get; private set; }

		public bool IsPointerPressed { get; private set; }

		public bool IsSelected { get; private set; }

		int ILayoutElement.layoutPriority => _layoutPriority.GetValueOrDefault();

		public int LayoutPriority
		{
			get
			{
				return _layoutPriority.GetValueOrDefault();
			}
			set
			{
				_layoutPriority = value;
				if (_useLayoutElement && _layoutElement != null)
				{
					_layoutElement.layoutPriority = value;
				}
			}
		}

		public RectOffset Margin
		{
			get
			{
				return _margin;
			}
			set
			{
				_margin = value;
				Rect.offsetMin = new Vector2(value.left, value.bottom);
				Rect.offsetMax = new Vector2(-value.right, -value.top);
				if (Height.HasValue)
				{
					Height = _height;
				}
				if (Width.HasValue)
				{
					Width = _width;
				}
			}
		}

		float ILayoutElement.minHeight => _minHeight.GetValueOrDefault();

		public float MinHeight
		{
			get
			{
				return _minHeight.GetValueOrDefault();
			}
			set
			{
				_minHeight = value;
				if (_useLayoutElement && _layoutElement != null)
				{
					_layoutElement.minHeight = value;
				}
			}
		}

		float ILayoutElement.minWidth => _minWidth.GetValueOrDefault();

		public float MinWidth
		{
			get
			{
				return _minWidth.GetValueOrDefault();
			}
			set
			{
				_minWidth = value;
				if (_useLayoutElement && _layoutElement != null)
				{
					_layoutElement.minWidth = value;
				}
			}
		}

		public float Opacity
		{
			get
			{
				return _canvasGroup?.alpha ?? 1f;
			}
			set
			{
				if (_canvasGroup == null)
				{
					_canvasGroup = base.gameObject.AddMissingComponent<CanvasGroup>();
				}
				_canvasGroup.alpha = value;
			}
		}

		public Widget Parent { get; private set; }

		public PointerEventData PointerEventData { get; private set; }

		public Vector2 Position
		{
			get
			{
				return Rect.anchoredPosition;
			}
			set
			{
				Rect.anchoredPosition = value;
			}
		}

		public WidgetPositionConstraintType PositionConstraint
		{
			get
			{
				return _positionConstraint;
			}
			set
			{
				_positionConstraint = value;
				WidgetPositionConstraint component = base.gameObject.GetComponent<WidgetPositionConstraint>();
				if (_positionConstraint != WidgetPositionConstraintType.None)
				{
					if (component == null)
					{
						base.gameObject.AddComponent<WidgetPositionConstraint>();
					}
				}
				else if (component != null)
				{
					UnityEngine.Object.Destroy(component);
				}
			}
		}

		float ILayoutElement.preferredHeight => Height ?? _preferredHeight.GetValueOrDefault();

		public float PreferredHeight
		{
			get
			{
				return _preferredHeight.GetValueOrDefault();
			}
			set
			{
				_preferredHeight = value;
				if (_useLayoutElement && _layoutElement != null)
				{
					_layoutElement.preferredHeight = value;
				}
			}
		}

		float ILayoutElement.preferredWidth => Width ?? _preferredWidth.GetValueOrDefault();

		public float PreferredWidth
		{
			get
			{
				return _preferredWidth.GetValueOrDefault();
			}
			set
			{
				_preferredWidth = value;
				if (_useLayoutElement && _layoutElement != null)
				{
					_layoutElement.preferredWidth = value;
				}
			}
		}

		public string PressClass { get; set; }

		public RectTransform Rect { get; private set; }

		public bool SafeArea
		{
			get
			{
				return _safeArea;
			}
			set
			{
				if (_safeArea != value)
				{
					_safeArea = value;
					base.gameObject.AddMissingComponent<SafeAreaScript>().IsEnabled = value;
				}
			}
		}

		public string SelectClass { get; set; }

		public SoundData Sound { get; set; }

		public SoundData SoundClick { get; set; }

		public SoundData SoundHide { get; set; }

		public SoundData SoundHover { get; set; }

		public SoundData SoundHoverExit { get; set; }

		public SoundData SoundPress { get; set; }

		public SoundData SoundRelease { get; set; }

		public SoundData SoundShow { get; set; }

		public bool StartVisible { get; set; } = true;

		public Stylesheet Stylesheet { get; private set; }

		public string Tooltip { get; set; }

		public float? TooltipDelay { get; set; }

		public TooltipPosition TooltipPosition { get; set; }

		public bool UseLayoutElement
		{
			get
			{
				return _useLayoutElement;
			}
			set
			{
				_useLayoutElement = value;
				if (value)
				{
					if (_layoutElement == null)
					{
						_layoutElement = base.gameObject.AddComponent<LayoutElement>();
						_layoutElement.layoutPriority = _layoutPriority ?? 1;
						_layoutElement.ignoreLayout = _ignoreLayout;
						_layoutElement.minHeight = _minHeight ?? (-1f);
						_layoutElement.minWidth = _minWidth ?? (-1f);
						_layoutElement.preferredHeight = _preferredHeight ?? (-1f);
						_layoutElement.preferredWidth = _preferredWidth ?? (-1f);
						_layoutElement.flexibleHeight = _flexibleHeight ?? (-1f);
						_layoutElement.flexibleWidth = _flexibleWidth ?? (-1f);
					}
				}
				else if (_layoutElement != null)
				{
					UnityEngine.Object.Destroy(_layoutElement);
					_layoutElement = null;
				}
			}
		}

		public virtual bool Visible
		{
			get
			{
				if (!_collapsed)
				{
					return _visible;
				}
				return false;
			}
			set
			{
				_visible = value;
				UpdateVisibility();
			}
		}

		public IReadOnlyList<Widget> Widgets => _widgets;

		public float? Width
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
				if (value.HasValue)
				{
					Rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value.Value);
				}
			}
		}

		protected virtual AttributeSet AttributeSet => WidgetAttributes.Set;

		protected bool IsDestroyed { get; set; }

		protected WidgetStyle Style { get; private set; }

		public event WidgetDelegate Clicked;

		public event WidgetDelegate Destroyed;

		public event WidgetDelegate Hidden;

		public event WidgetDelegate PointerDown;

		public event WidgetDelegate PointerEnter;

		public event WidgetDelegate PointerExit;

		public event WidgetDelegate PointerUp;

		public event WidgetDelegate Shown;

		public bool AddClass(string className)
		{
			if (!HasClass(className))
			{
				_classNames.Add(className);
				SetDirtyFlag(DirtyFlags.ApplyStyes);
				WidgetStyle style = Stylesheet.GetStyle(className);
				if (style != null && style.Children.Count > 0)
				{
					_nestedClassNames.Add(className);
					SetDirtyFlag(DirtyFlags.ReapplyNestedClasses);
				}
				return true;
			}
			return false;
		}

		public virtual void AddWidget(Widget widget)
		{
			if (widget.Parent != null)
			{
				widget.Parent.RemoveWidget(widget);
			}
			widget.Rect.SetParent(ChildContainer, worldPositionStays: false);
			widget.Parent = this;
			widget.Destroyed += RemoveWidget;
			SetDirtyFlag(DirtyFlags.ReapplyNestedClasses, recursivelyApply: true);
			_widgets.Add(widget);
			Border.OnAddChildWidget();
		}

		public void AttachScript(string scriptTypeName)
		{
			try
			{
				if (_script == null && !string.IsNullOrWhiteSpace(scriptTypeName))
				{
					Type scriptType = Context.ResourceLoader.GetScriptType(scriptTypeName);
					if (scriptType == null)
					{
						throw new WidgetException("Could not find script type " + scriptTypeName);
					}
					if (Device.IsUnityEditor && (!typeof(MonoBehaviour).IsAssignableFrom(scriptType) || !typeof(IWidgetScript).IsAssignableFrom(scriptType)))
					{
						throw new WidgetException("Script type " + scriptTypeName + " must implement IWidgetScript and be a MonoBehaviour to be attached to a widget.");
					}
					_script = base.gameObject.AddComponent(scriptType) as IWidgetScript;
					if (_script.HandleChildEvents)
					{
						EventHandler = _script;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				Debug.LogError("Could not attach script '" + scriptTypeName + "' to widget '" + GetType().Name + "'.'\n" + ex.Message);
			}
		}

		void ILayoutElement.CalculateLayoutInputHorizontal()
		{
		}

		void ILayoutElement.CalculateLayoutInputVertical()
		{
		}

		public virtual void Destroy()
		{
			if (IsDestroyed)
			{
				return;
			}
			if (Tooltip != null)
			{
				Context.HideTooltip(this);
			}
			foreach (Widget item in _widgets.ToList())
			{
				item.Destroy();
			}
			IsDestroyed = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public void EnableClass(string className, bool enabled)
		{
			if (enabled)
			{
				AddClass(className);
			}
			else
			{
				RemoveClass(className);
			}
		}

		public void ExecuteOnWidgetsOfClass(string className, Action<Widget> action)
		{
			foreach (Widget item in FindWidgetsByClass(className))
			{
				action(item);
			}
		}

		public Widget FindDirectChildWidget(string id)
		{
			foreach (Widget widget in _widgets)
			{
				if (widget.Id == id)
				{
					return widget;
				}
			}
			return null;
		}

		public T FindDirectChildWidget<T>(string id) where T : Widget
		{
			return FindDirectChildWidget(id) as T;
		}

		public Widget FindDirectChildWidgetByName(string name)
		{
			foreach (Widget widget in _widgets)
			{
				if (widget.name == name)
				{
					return widget;
				}
			}
			return null;
		}

		public T FindDirectChildWidgetByName<T>(string name) where T : Widget
		{
			return FindDirectChildWidget(name) as T;
		}

		public Widget FindParentWidget(string id)
		{
			if (Id == id)
			{
				return this;
			}
			return Parent?.FindParentWidget(id) ?? null;
		}

		public Widget FindParentWidgetByClass(string className)
		{
			if (_classNames.Contains(className))
			{
				return this;
			}
			return Parent?.FindParentWidgetByClass(className) ?? null;
		}

		public Widget FindWidget(string id)
		{
			if (Id == id)
			{
				return this;
			}
			foreach (Widget widget2 in _widgets)
			{
				Widget widget = widget2.FindWidget(id);
				if (widget != null)
				{
					return widget;
				}
			}
			return null;
		}

		public T FindWidget<T>(string id) where T : Widget
		{
			return FindWidget(id) as T;
		}

		public T FindWidgetComponent<T>(string id) where T : Component
		{
			Widget widget = FindWidget(id);
			if ((object)widget == null)
			{
				return null;
			}
			return widget.GetComponent<T>();
		}

		public List<Widget> FindWidgetsByClass(string className)
		{
			List<Widget> list = new List<Widget>();
			FindWidgetsByClassRecursive(className, list);
			return list;
		}

		public string GetStyle(string name)
		{
			if (Style.Attributes.TryGetValue(name, out var value))
			{
				return value;
			}
			return null;
		}

		public bool HasClass(string className)
		{
			return _classNames.Contains(className);
		}

		public void Hide(Action action = null, bool force = false, bool skipAnimation = false)
		{
			Animation.OnHide(action, force, skipAnimation);
		}

		public virtual void Initialize(IWidgetContext context, XElement element)
		{
			Element = element;
			Id = element.GetStringAttribute("id");
			Context = context;
			Rect = GetComponent<RectTransform>();
			Animation = new WidgetAnimationManager(this);
			Border = new WidgetBorder(this);
			if (_childContainer == null)
			{
				_childContainer = Rect;
			}
		}

		public void InitializeStyles(Stylesheet stylesheet, WidgetStyle elementStyle, IEnumerable<string> classNames)
		{
			Stylesheet = stylesheet;
			Style = elementStyle;
			foreach (string className in classNames)
			{
				AddClass(className);
			}
			ApplyCombinedStyle();
			Animation.OnInitializeStyles();
			_script?.OnWidgetInitialized(this);
			if (!StartVisible)
			{
				Visible = false;
			}
		}

		public void LoadChildren(Stylesheet stylesheet = null)
		{
			if (ChildrenLoaded)
			{
				return;
			}
			ChildrenLoaded = true;
			foreach (XElement item in Element.Elements())
			{
				if (Context.PreprocessElement(item))
				{
					Context.CreateWidget(item, this, stylesheet ?? Stylesheet);
				}
			}
		}

		public virtual void OnDeselect(BaseEventData eventData)
		{
			OnDeselect();
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
			if (Interactable)
			{
				PointerEventData = eventData;
				if (!string.IsNullOrWhiteSpace(EventClick))
				{
					HandleEvent(EventClick, this);
				}
				this.Clicked?.Invoke(this);
				if (SoundClick != null)
				{
					Context.PlaySound(SoundClick);
				}
				PointerEventData = null;
			}
		}

		public virtual void OnPointerDown(PointerEventData eventData)
		{
			if (Interactable)
			{
				PointerEventData = eventData;
				IsPointerPressed = true;
				if (PressClass != null)
				{
					AddClass(PressClass);
				}
				if (!string.IsNullOrWhiteSpace(EventPointerDown))
				{
					HandleEvent(EventPointerDown, this);
				}
				if (SoundPress != null)
				{
					Context.PlaySound(SoundPress);
				}
				this.PointerDown?.Invoke(this);
				PointerEventData = null;
			}
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			PointerEventData = eventData;
			IsPointerInside = true;
			if (!string.IsNullOrWhiteSpace(Tooltip))
			{
				Context.ShowTooltip(this);
			}
			if (Interactable)
			{
				if (HoverClass != null)
				{
					AddClass(HoverClass);
				}
				if (!string.IsNullOrWhiteSpace(EventHoverEnter))
				{
					HandleEvent(EventHoverEnter, this);
				}
				if (SoundHover != null)
				{
					StartCoroutine(PlayHoverSoundDelayed());
				}
				this.PointerEnter?.Invoke(this);
			}
			PointerEventData = null;
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			if (eventData != null && !eventData.fullyExited)
			{
				return;
			}
			PointerEventData = eventData;
			IsPointerInside = false;
			if (!string.IsNullOrWhiteSpace(Tooltip))
			{
				Context.HideTooltip(this);
			}
			if (HoverClass != null)
			{
				RemoveClass(HoverClass);
			}
			if (SoundHoverExit != null)
			{
				Context.PlaySound(SoundHoverExit);
			}
			if (Interactable)
			{
				if (!string.IsNullOrWhiteSpace(EventHoverExit))
				{
					HandleEvent(EventHoverExit, this);
				}
				this.PointerExit?.Invoke(this);
			}
			PointerEventData = null;
		}

		public virtual void OnPointerUp(PointerEventData eventData)
		{
			PointerEventData = eventData;
			IsPointerPressed = false;
			if (PressClass != null)
			{
				RemoveClass(PressClass);
			}
			if (Interactable)
			{
				if (!string.IsNullOrWhiteSpace(EventPointerUp))
				{
					HandleEvent(EventPointerUp, this);
				}
				if (SoundRelease != null)
				{
					Context.PlaySound(SoundRelease);
				}
				this.PointerUp?.Invoke(this);
			}
			PointerEventData = null;
		}

		public virtual void OnSelect(BaseEventData eventData)
		{
			IsSelected = true;
			if (SelectClass != null)
			{
				AddClass(SelectClass);
			}
			if (!string.IsNullOrWhiteSpace(EventSelect))
			{
				HandleEvent(EventSelect, this);
			}
		}

		public void PlaySound()
		{
			if (Sound != null)
			{
				Context.PlaySound(Sound);
			}
		}

		public bool RemoveClass(string className)
		{
			if (HasClass(className))
			{
				_classNames.Remove(className);
				SetDirtyFlag(DirtyFlags.ApplyStyes);
				if (_nestedClassNames.Contains(className))
				{
					_nestedClassNames.Remove(className);
					WidgetStyle style = Stylesheet.GetStyle(className);
					if (style.Children.Count > 0)
					{
						foreach (WidgetStyle child in style.Children)
						{
							RemoveNestedStyle(child);
						}
					}
				}
				return true;
			}
			return false;
		}

		public void SetIndex(int index)
		{
			if (index < 0)
			{
				index = Parent._widgets.Count + index;
			}
			index = Mathf.Clamp(index, 0, Parent._widgets.Count - 1);
			if (Parent._widgets.IndexOf(this) != index)
			{
				Widget widget = Parent._widgets[index];
				Parent._widgets.Remove(this);
				Parent._widgets.Insert(index, this);
				Rect.SetSiblingIndex(widget.Rect.GetSiblingIndex());
			}
		}

		public void SetStyle(string name, string value)
		{
			Style.Attributes[name] = value;
			SetDirtyFlag(DirtyFlags.ApplyStyes);
		}

		public void SetVisible(bool visible)
		{
			Visible = visible;
		}

		public void Show(bool force = false, bool skipAnimation = false)
		{
			Animation.OnShow(force, skipAnimation);
		}

		public void ToggleClass(string className)
		{
			if (HasClass(className))
			{
				RemoveClass(className);
			}
			else
			{
				AddClass(className);
			}
		}

		public virtual void UpdateWidget(object dataModel)
		{
			if (_updatingWidget)
			{
				return;
			}
			try
			{
				_updatingWidget = true;
				dataModel = DataModel ?? dataModel;
				Dictionary<string, IDynamicValue> dynamicValues = _dynamicValues;
				if (dynamicValues != null && dynamicValues.Count > 0)
				{
					foreach (IDynamicValue value in _dynamicValues.Values)
					{
						value.UpdateValue(dataModel);
					}
				}
				if (!Visible)
				{
					if ((_dirty & DirtyFlags.ApplyStyes) > DirtyFlags.None)
					{
						ApplyCombinedStyle();
						_dirty &= (DirtyFlags)(-2);
					}
					return;
				}
				if (_dirty != DirtyFlags.None)
				{
					DirtyFlags dirty = _dirty;
					_dirty = DirtyFlags.None;
					if ((dirty & DirtyFlags.ApplyStyes) > DirtyFlags.None)
					{
						ApplyCombinedStyle();
					}
					if ((dirty & DirtyFlags.ReapplyNestedClasses) > DirtyFlags.None)
					{
						ApplyNestedStyles();
					}
					if ((dirty & DirtyFlags.UpdateLayout) > DirtyFlags.None)
					{
						UpdateLayout();
					}
				}
				foreach (Widget widget in _widgets)
				{
					widget.UpdateWidget(dataModel);
				}
			}
			finally
			{
				_updatingWidget = false;
			}
		}

		protected void ApplyStyle(string name, string value)
		{
			if (value != null && value.IndexOf('{') >= 0)
			{
				if (value != "{null}")
				{
					if (_dynamicValues == null)
					{
						_dynamicValues = new Dictionary<string, IDynamicValue>();
					}
					IDynamicValue dynamicValue = null;
					dynamicValue = ((!value.StartsWith("{|")) ? ((IDynamicValue)new DynamicExpressionValue(this, AttributeSet, name, value)) : ((IDynamicValue)new DataValueBinding(this, AttributeSet, name, value)));
					_dynamicValues[name] = dynamicValue;
				}
			}
			else
			{
				Dictionary<string, IDynamicValue> dynamicValues = _dynamicValues;
				if (dynamicValues != null && dynamicValues.Count > 0 && _dynamicValues.ContainsKey(name))
				{
					_dynamicValues.Remove(name);
				}
				AttributeSet.ApplyAttribute(this, name, value);
			}
		}

		protected virtual void Awake()
		{
		}

		protected virtual void OnDestroy()
		{
			IsDestroyed = true;
			this.Destroyed?.Invoke(this);
			this.Destroyed = null;
		}

		protected virtual void OnDisable()
		{
			if (IsPointerInside)
			{
				OnPointerExit(null);
			}
			if (IsSelected)
			{
				OnDeselect();
			}
		}

		protected virtual void OnEnable()
		{
			if (Stylesheet != null && !ChildrenLoaded)
			{
				LoadChildren(Stylesheet);
			}
			if (SoundShow != null)
			{
				Context.PlaySound(SoundShow);
			}
		}

		protected void SetDirtyFlag(DirtyFlags dirtyFlag, bool recursivelyApply = false)
		{
			_dirty |= dirtyFlag;
			if (recursivelyApply && Parent != null && (Parent._dirty & dirtyFlag) == 0)
			{
				Parent.SetDirtyFlag(dirtyFlag);
			}
		}

		protected virtual void Start()
		{
		}

		protected virtual void UpdateLayout()
		{
		}

		[ContextMenu("Apply Combined Style")]
		private void ApplyCombinedStyle()
		{
			WidgetStyle widgetStyle = CalculateCombinedStyle();
			ApplyWidgetStyle(widgetStyle);
		}

		private void ApplyNestedStyle(WidgetStyle nestedStyle)
		{
			if (HasClass(nestedStyle.NestedName))
			{
				AddClass(nestedStyle.Name);
			}
			foreach (Widget widget in _widgets)
			{
				if (widget.HasClass(nestedStyle.NestedName))
				{
					widget.AddClass(nestedStyle.Name);
				}
				widget.ApplyNestedStyle(nestedStyle);
			}
		}

		private void ApplyNestedStyles()
		{
			foreach (string nestedClassName in _nestedClassNames)
			{
				foreach (WidgetStyle child in Stylesheet.GetStyle(nestedClassName).Children)
				{
					ApplyNestedStyle(child);
				}
			}
		}

		private void ApplyWidgetStyle(WidgetStyle widgetStyle)
		{
			foreach (KeyValuePair<string, string> attribute in widgetStyle.Attributes)
			{
				try
				{
					ApplyStyle(attribute.Key, attribute.Value);
				}
				catch (Exception ex)
				{
					Debug.LogError("Could not apply widget style '" + attribute.Key + "' with value '" + attribute.Value + "' to widget '" + GetType().Name + "'\n" + ex.ToString());
				}
			}
		}

		private WidgetStyle CalculateCombinedStyle()
		{
			WidgetStyle widgetStyle = new WidgetStyle("Instance");
			if (_classNames.Count > 0)
			{
				List<WidgetStyle> list = new List<WidgetStyle>();
				foreach (string className in _classNames)
				{
					WidgetStyle style = Stylesheet.GetStyle(className);
					if (style != null)
					{
						list.Add(style);
					}
				}
				foreach (WidgetStyle item in list.OrderBy((WidgetStyle x) => x.Order).ToList())
				{
					widgetStyle.Absorb(item);
				}
				widgetStyle.Absorb(Style);
			}
			else
			{
				widgetStyle = Style;
			}
			return widgetStyle;
		}

		private object FindDataModel()
		{
			object obj = DataModel;
			if (obj == null)
			{
				Widget parent = Parent;
				if ((object)parent == null)
				{
					return null;
				}
				obj = parent.FindDataModel();
			}
			return obj;
		}

		private void FindWidgetsByClassRecursive(string className, List<Widget> list)
		{
			if (_classNames.Contains(className))
			{
				list.Add(this);
			}
			foreach (Widget widget in _widgets)
			{
				widget.FindWidgetsByClassRecursive(className, list);
			}
		}

		private void HandleEvent(string methodName, Widget source)
		{
			if (EventHandler != null)
			{
				Type type = EventHandler.GetType();
				MethodInfo methodInfo = null;
				object[] parameters = null;
				string[] array = methodName.Split(' ');
				if (array.Length == 1)
				{
					methodInfo = type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[1] { typeof(Widget) }, null);
					parameters = new object[1] { source };
				}
				else if (array.Length == 2)
				{
					string text = array[1];
					object obj = null;
					Type type2 = null;
					if (int.TryParse(text, out var result))
					{
						obj = result;
						type2 = typeof(int);
					}
					else if (text.Length > 2 && text.StartsWith("'") && text.EndsWith("'"))
					{
						obj = text.Substring(1, text.Length - 2);
						type2 = typeof(string);
					}
					if (type2 != null)
					{
						methodInfo = type.GetMethod(array[0], BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[2]
						{
							typeof(Widget),
							type2
						}, null);
						parameters = new object[2] { source, obj };
					}
				}
				if (methodInfo != null)
				{
					methodInfo.Invoke(EventHandler, parameters);
				}
				else
				{
					Debug.LogWarning("Could not find method '" + methodName + "'", base.gameObject);
				}
			}
			else if (Parent != null)
			{
				Parent.HandleEvent(methodName, source);
			}
			else
			{
				Debug.LogWarning("Could not find method '" + methodName + "'", base.gameObject);
			}
		}

		private void OnDeselect()
		{
			IsSelected = false;
			if (SelectClass != null)
			{
				RemoveClass(SelectClass);
			}
			if (!string.IsNullOrWhiteSpace(EventDeselect))
			{
				HandleEvent(EventDeselect, this);
			}
		}

		private IEnumerator PlayHoverSoundDelayed()
		{
			yield return new WaitForSeconds(0.05f);
			if (IsPointerInside)
			{
				Context.PlaySound(SoundHover);
			}
		}

		[ContextMenu("Print Style")]
		private void PrintStyle()
		{
			string text = "Widget attributes:\n";
			foreach (KeyValuePair<string, string> item in CalculateCombinedStyle().Attributes.OrderBy((KeyValuePair<string, string> x) => x.Key).ToList())
			{
				text = text + item.Key + " = " + item.Value + "\n";
			}
			Debug.Log(text);
		}

		private void RemoveNestedStyle(WidgetStyle nestedStyle)
		{
			foreach (Widget widget in _widgets)
			{
				if (widget.HasClass(nestedStyle.Name))
				{
					widget.RemoveClass(nestedStyle.Name);
				}
				widget.RemoveNestedStyle(nestedStyle);
			}
		}

		private void RemoveWidget(Widget widget)
		{
			widget.Destroyed -= RemoveWidget;
			_widgets.Remove(widget);
			widget.Parent = null;
		}

		private void ResetDirtyFlag(DirtyFlags flag)
		{
			_dirty &= ~flag;
		}

		private void UpdateVisibility()
		{
			bool visible = Visible;
			if (visible == base.gameObject.activeSelf)
			{
				return;
			}
			base.gameObject.SetActive(visible);
			if (visible)
			{
				UpdateWidget(FindDataModel());
				this.Shown?.Invoke(this);
				return;
			}
			if (Animation.HideAnimation == null && SoundHide != null)
			{
				Context.PlaySound(SoundHide);
			}
			this.Hidden?.Invoke(this);
		}
	}
}
