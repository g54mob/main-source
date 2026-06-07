using DigitalLegacy.UI.Sizing;
using ModApi;
using ModApi.Common.Events;
using ModApi.Ui.Inspector;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui.Inspector
{
	public class InspectorPanelScript : MonoBehaviour, IInspectorPanel, ICanvasScaleChangeHandler
	{
		private XmlElement _closeElement;

		private LayoutElement _layout;

		private int _maxHeight;

		private float _maxHeightPercentage;

		private InspectorPanel _panel;

		private XmlElement _panelElement;

		private int _panelHeight;

		private XmlElement _pinElement;

		private bool _pinned;

		private InspectorPanelCreationInfo.InspectorPanelRestoreState _restoreState;

		private bool _scrollEnabled;

		private XmlElement _scrollView;

		private TextMeshProUGUI _titleText;

		private LayoutElement _titleTextLayout;

		private XmlElement _titleTextTooltipElement;

		private bool _visible = true;

		public bool Collapsed
		{
			get
			{
				return _panel.Collapsed;
			}
			set
			{
				if (_panel.Collapsed != value)
				{
					_panel.Collapsed = value;
					if (_scrollEnabled)
					{
						_scrollView.SetActive(!_panel.Collapsed);
					}
				}
			}
		}

		public bool IsPinned
		{
			get
			{
				return _pinned;
			}
			set
			{
				if (_pinned == value)
				{
					return;
				}
				_pinned = value;
				if (_pinned && this.Pinned != null)
				{
					this.Pinned(this);
				}
				else if (!_pinned && this.Unpinned != null)
				{
					this.Unpinned(this);
				}
				if (IsPinned)
				{
					if (!_pinElement.HasClass("inspector-panel-pin-selected"))
					{
						_pinElement.AddClass("inspector-panel-pin-selected");
					}
				}
				else
				{
					_pinElement.RemoveClass("inspector-panel-pin-selected");
				}
			}
		}

		public bool IsResizable { get; private set; }

		public int MaxHeight => _maxHeight;

		public InspectorModel Model => _panel.Model;

		public Vector2 Position
		{
			get
			{
				return _panelElement.rectTransform.anchoredPosition;
			}
			set
			{
				_panelElement.rectTransform.anchoredPosition = value;
			}
		}

		public float ScrollOffset
		{
			get
			{
				if (_scrollView != null)
				{
					return _scrollView.GetComponent<ScrollRect>().content.anchoredPosition.y;
				}
				return 0f;
			}
			set
			{
				if (_scrollView != null)
				{
					ScrollRect component = _scrollView.GetComponent<ScrollRect>();
					component.content.anchoredPosition = new Vector2(component.content.anchoredPosition.x, value);
				}
			}
		}

		public RectTransform Transform => GetComponent<RectTransform>();

		public bool Visible
		{
			get
			{
				return _visible;
			}
			set
			{
				if (_visible != value)
				{
					_visible = value;
					base.gameObject.SetActive(_visible);
				}
			}
		}

		public event InspectorPanelDelegate CloseButtonClicked;

		public event InspectorPanelDelegate Closed;

		public event InspectorPanelDelegate Pinned;

		public event InspectorPanelDelegate Unpinned;

		public void Close()
		{
			_panelElement.Hide();
			if (this.Closed != null)
			{
				this.Closed(this);
			}
			_panel.Destroy();
			_panel = null;
			base.gameObject.SetActive(value: false);
			Object.Destroy(base.gameObject);
			this.Closed = null;
			this.Pinned = null;
			this.Unpinned = null;
		}

		public InspectorPanelCreationInfo.InspectorPanelRestoreState GenerateRestoreState()
		{
			return new InspectorPanelCreationInfo.InspectorPanelRestoreState
			{
				ScrollOffset = ScrollOffset,
				Position = Position
			};
		}

		public void Initialize(InspectorModel model, InspectorPanelCreationInfo creationInfo, ElementBuilder elementBuilder, XmlElement panelElement)
		{
			_panelElement = panelElement;
			_scrollView = panelElement.GetElementByInternalId("scroll-view");
			_panel = new InspectorPanel(model, elementBuilder, _panelElement.GetElementByInternalId("items-parent"));
			_restoreState = creationInfo.RestoreState;
			_scrollEnabled = creationInfo.AllowVerticalScrolling;
			if (!_scrollEnabled)
			{
				_panel.ItemsParent.transform.SetParent(_scrollView.transform.parent, worldPositionStays: false);
				_scrollView.gameObject.SetActive(value: false);
			}
			_titleText = panelElement.GetElementByInternalId<TextMeshProUGUI>("title-text");
			_titleTextTooltipElement = _titleText.transform.parent.GetComponent<XmlElement>();
			_pinElement = panelElement.GetElementByInternalId("pin-button");
			if (!creationInfo.CanPin)
			{
				_pinElement.SetAttribute("active", false.ToString());
			}
			_closeElement = panelElement.GetElementByInternalId("close-button");
			if (!creationInfo.CanClose)
			{
				_closeElement.SetAttribute("active", false.ToString());
			}
			IsResizable = creationInfo.Resizable;
			Vector2? vector = (IsResizable ? Game.Instance.Settings.UserPrefs.GetVector2OrNull(Model.UserPrefsId + ".Size") : ((Vector2?)null));
			bool flag = false;
			int num = ((int?)vector?.x) ?? creationInfo.PanelWidth;
			if (int.Parse(panelElement.GetAttribute("width")) != num)
			{
				_panelElement.SetAttribute("width", num.ToString());
				flag = true;
			}
			if (creationInfo.StartPosition == InspectorPanelCreationInfo.InspectorStartPosition.UpperLeft)
			{
				panelElement.AddClass("float-upper-left");
				flag = true;
			}
			else if (creationInfo.StartPosition == InspectorPanelCreationInfo.InspectorStartPosition.UpperRight)
			{
				panelElement.AddClass("float-upper-right");
				flag = true;
			}
			if (creationInfo.StartOffset.x != 0f || creationInfo.StartOffset.y != 0f)
			{
				panelElement.SetAttribute("offsetXY", $"{creationInfo.StartOffset.x},{creationInfo.StartOffset.y}");
				flag = true;
			}
			if (flag)
			{
				panelElement.ApplyAttributesRecursive();
			}
			InspectorPanelCreationInfo.InspectorPanelRestoreState restoreState = creationInfo.RestoreState;
			if (restoreState != null && restoreState.Position.HasValue)
			{
				Position = creationInfo.RestoreState.Position.Value;
			}
			else
			{
				Vector2 vector2 = Game.Instance.Settings.UserPrefs.GetVector2(Model.UserPrefsId + ".Position", Vector2.zero);
				if (vector2 != Vector2.zero)
				{
					Position = vector2;
				}
			}
			_maxHeightPercentage = creationInfo.PanelMaxHeight;
			CalculateMaxHeight();
			if (vector.HasValue)
			{
				_maxHeight = (int)vector.Value.y;
			}
			_layout = GetComponent<LayoutElement>();
			_titleTextLayout = _titleText.GetComponent<LayoutElement>();
			if (IsResizable)
			{
				SetupResize();
			}
			_panelElement.AddOnEndDragEvent(OnDragEnd);
			Update();
			RestrictPositionToParentElement(panelElement);
		}

		void ICanvasScaleChangeHandler.OnCanvasScaleChanged(float canvasScaleFactor)
		{
			CalculateMaxHeight();
		}

		public void OnCloseButtonClicked()
		{
			if (this.CloseButtonClicked != null)
			{
				this.CloseButtonClicked(this);
			}
			else
			{
				Close();
			}
		}

		public void OnMainHeaderClicked()
		{
			Collapsed = !Collapsed;
		}

		[ContextMenu("Rebuild Inspector Panel Elements")]
		public void RebuildModelElements()
		{
			if (Model != null)
			{
				_panel.RebuildModelElements();
				_titleText.text = Model.Title;
			}
			Update();
		}

		public void ReplaceGroup(GroupModel originalGroup, GroupModel newGroup)
		{
			_panel.ReplaceGroup(originalGroup, newGroup);
		}

		protected virtual void Start()
		{
			Model.OnInspectorPanelCreated(this);
			RebuildModelElements();
			if (_restoreState != null)
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					ScrollOffset = _restoreState.ScrollOffset;
				});
			}
		}

		protected virtual void Update()
		{
			int num = 0;
			if (Visible)
			{
				if (_titleText != null && _titleText.text != Model.Title)
				{
					_titleText.text = Model.Title;
				}
				if (_titleTextTooltipElement != null && _titleTextTooltipElement.Tooltip != Model.TitleTextTooltip)
				{
					_titleTextTooltipElement.Tooltip = Model.TitleTextTooltip;
				}
				num = _panel.Update();
			}
			if (num > _maxHeight)
			{
				num = _maxHeight;
			}
			if (_panelHeight != num)
			{
				_panelHeight = num;
				_scrollView.SetAttribute("preferredHeight", num.ToString());
				_scrollView.ApplyAttributes();
			}
		}

		private static void RestrictPositionToParentElement(XmlElement element)
		{
			RectTransform rectTransform = element.parentElement.rectTransform;
			RectTransform rectTransform2 = element.rectTransform;
			Vector3 localPosition = rectTransform2.localPosition;
			Vector3 vector = rectTransform.rect.min - rectTransform2.rect.min;
			Vector3 vector2 = rectTransform.rect.max - rectTransform2.rect.max;
			localPosition.x = Mathf.Clamp(rectTransform2.localPosition.x, vector.x, vector2.x);
			localPosition.y = Mathf.Clamp(rectTransform2.localPosition.y, vector.y, vector2.y);
			rectTransform2.localPosition = localPosition;
		}

		private void CalculateMaxHeight()
		{
			UserInterfaceScaleScript componentInParent = GetComponentInParent<UserInterfaceScaleScript>();
			_maxHeight = (int)(componentInParent.CanvasHeight * _maxHeightPercentage);
		}

		private void OnDragEnd()
		{
			SavePositionToUserPrefs();
		}

		private void OnResizeEnd()
		{
			UpdateMaxHeightOnResize();
			string key = Model.UserPrefsId + ".Size";
			Game.Instance.Settings.UserPrefs.SetVector2(key, new Vector2((int)_layout.preferredWidth, _maxHeight));
			SavePositionToUserPrefs();
			_layout.preferredHeight = -1f;
			_layout.preferredWidth = -1f;
		}

		private void OnResizeUpdate()
		{
			UpdateMaxHeightOnResize();
		}

		private void SavePositionToUserPrefs()
		{
			string key = Model.UserPrefsId + ".Position";
			Vector2 position = Position;
			Game.Instance.Settings.UserPrefs.SetVector2(key, new Vector2((int)position.x, (int)position.y));
		}

		private void SetupResize()
		{
			IResourceLoader resourceLoader = Game.Instance.ResourceLoader;
			uResize obj = base.gameObject.AddComponent<uResize>();
			obj.AllowResizeFromBottom = true;
			obj.AllowResizeFromBottomLeft = true;
			obj.AllowResizeFromBottomRight = true;
			obj.AllowResizeFromLeft = true;
			obj.AllowResizeFromRight = true;
			obj.AllowResizeFromTop = true;
			obj.AllowResizeFromTopRight = true;
			obj.AllowResizeFromTopLeft = true;
			obj.MinSize = new Vector2(200f, 250f);
			obj.ResizeListenerOffsetMin = new Vector2(-6f, -6f);
			obj.ResizeListenerOffsetMax = new Vector2(6f, 6f);
			obj.ResizeListenerThickness = 8f;
			obj.OnResizeUpdate.AddListener(OnResizeUpdate);
			obj.OnResizeEnd.AddListener(OnResizeEnd);
			uResize_CursorController obj2 = base.gameObject.AddComponent<uResize_CursorController>();
			obj2.HorizontalCursor = resourceLoader.LoadTexture("Ui/Sprites/Common/ResizeArrowHorizontal_small");
			obj2.VerticalCursor = resourceLoader.LoadTexture("Ui/Sprites/Common/ResizeArrowVertical_small");
			obj2.TopRightCursor = resourceLoader.LoadTexture("Ui/Sprites/Common/ResizeArrowDiagonal1_small");
			obj2.TopLeftCursor = resourceLoader.LoadTexture("Ui/Sprites/Common/ResizeArrowDiagonal2_small");
			obj2.BottomLeftCursor = obj2.TopRightCursor;
			obj2.BottomRightCursor = obj2.TopLeftCursor;
			base.gameObject.GetComponent<VerticalLayoutGroup>().childAlignment = TextAnchor.UpperCenter;
			_titleTextLayout.minHeight = _titleTextLayout.preferredHeight;
		}

		private void UpdateMaxHeightOnResize()
		{
			int num = (((int?)_titleTextLayout?.preferredHeight) ?? 30) + 5;
			_maxHeight = (int)_layout.preferredHeight - num;
		}
	}
}
