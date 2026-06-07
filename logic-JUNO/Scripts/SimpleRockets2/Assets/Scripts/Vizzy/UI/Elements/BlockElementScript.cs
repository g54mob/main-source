using System.Collections.Generic;
using ModApi.Craft.Program;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Vizzy.UI.Elements
{
	public class BlockElementScript : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
	{
		public enum VisualStateType
		{
			Normal = 0,
			Brighter1 = 1,
			Brighter2 = 2,
			Brighter3 = 3
		}

		[SerializeField]
		private float _childOffsetY;

		private List<BlockElementScript> _children = new List<BlockElementScript>();

		private Color _color;

		private float _dragBeginTime;

		private Vector2 _dragTotalDelta;

		private Vector2 _grabDelta;

		private Image _image;

		[SerializeField]
		private RectOffset _margins = new RectOffset();

		[SerializeField]
		private Vector2 _minSize = Vector2.zero;

		[SerializeField]
		private RectOffset _padding = new RectOffset();

		private bool _updateLayoutQueued;

		private VisualStateType _visualState;

		public virtual bool AllowEditing { get; set; } = true;

		public bool CanDrag
		{
			get
			{
				if (DragBehavior != DragBehaviorType.Disabled)
				{
					return VizzyUI.Interactable;
				}
				return false;
			}
		}

		public IReadOnlyList<BlockElementScript> ChildBlocks => _children;

		public virtual Color Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
				if (_image != null)
				{
					_image.color = value;
				}
			}
		}

		public List<ConnectionPoint> ConnectionPoints { get; set; } = new List<ConnectionPoint>();

		public DragBehaviorType DragBehavior { get; set; } = DragBehaviorType.Disabled;

		public string Error { get; protected set; }

		public string Format { get; set; }

		public bool IsDragging { get; private set; }

		public RectOffset Margins => _margins;

		public Vector2 MinSize => _minSize;

		public ProgramNode Node { get; private set; }

		public RectOffset Padding => _padding;

		public BlockElementScript Parent => RectTransform.parent?.GetComponentInParent<BlockElementScript>();

		public RectTransform RectTransform { get; private set; }

		public bool RequireHorizontalDrag { get; set; }

		public BlockElementScript Root
		{
			get
			{
				BlockElementScript parent = Parent;
				if (parent == null)
				{
					return this;
				}
				return parent.Root;
			}
		}

		public Vector2 Size { get; protected set; }

		public NodeStyle Style { get; set; }

		public bool SupportsClone { get; set; } = true;

		public VisualStateType VisualState
		{
			get
			{
				return _visualState;
			}
			set
			{
				_visualState = value;
				UpdateColor();
			}
		}

		public IVizzyUI VizzyUI { get; private set; }

		public void AddChild(BlockElementScript childBlock)
		{
			childBlock.RectTransform.SetParent(RectTransform, worldPositionStays: false);
			_children.Add(childBlock);
		}

		public virtual void Destroy()
		{
			Object.Destroy(base.gameObject);
			base.gameObject.SetActive(value: false);
		}

		public virtual void Initialize(IVizzyUI vizzyUI, ProgramNode node, string style)
		{
			VizzyUI = vizzyUI;
			Node = node;
			if (!string.IsNullOrEmpty(style))
			{
				Style = vizzyUI.Toolbox.GetStyle(style);
				if (Style == null)
				{
					string text = "Missing style " + style;
					for (int i = 0; i < node.Expressions.Count; i++)
					{
						text += $" ({i})";
					}
					Style = new NodeStyle("error", text, Color.red);
				}
				Format = Style.Format;
			}
			else
			{
				Debug.LogErrorFormat("Block {0} with node {1} has null style.", this, node);
			}
			VisualState = VisualStateType.Normal;
			if (!VizzyUI.Interactable)
			{
				Selectable[] componentsInChildren = base.gameObject.GetComponentsInChildren<Selectable>();
				for (int j = 0; j < componentsInChildren.Length; j++)
				{
					componentsInChildren[j].interactable = VizzyUI.Interactable;
				}
			}
		}

		public virtual Vector2 LayoutElement()
		{
			Vector2 zero = Vector2.zero;
			zero.x = Padding.left;
			foreach (BlockElementScript childBlock in ChildBlocks)
			{
				Vector2 vector = childBlock.LayoutElement();
				childBlock.RectTransform.anchoredPosition = new Vector3(zero.x + (float)childBlock.Margins.left, _childOffsetY);
				zero.x += vector.x + (float)childBlock.Margins.left + (float)childBlock.Margins.right;
				zero.y = Mathf.Max(zero.y, vector.y + (float)childBlock.Margins.top + (float)childBlock.Margins.bottom);
			}
			zero.x += Padding.right;
			zero.y += Padding.top + Padding.bottom;
			Size = SetBlockSize(zero);
			return Size;
		}

		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
			bool flag = false;
			_dragBeginTime = Time.unscaledTime;
			_dragTotalDelta = Vector3.zero;
			if (CanDrag && (!RequireHorizontalDrag || Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y)))
			{
				StartDrag(eventData);
				flag = true;
			}
			if (!flag)
			{
				ExecuteEvents.ExecuteHierarchy(RectTransform.parent.gameObject, eventData, ExecuteEvents.beginDragHandler);
			}
		}

		public void OnChildSizeChanged()
		{
			if (Parent != null)
			{
				Parent.OnChildSizeChanged();
			}
			else if (!_updateLayoutQueued)
			{
				_updateLayoutQueued = true;
			}
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			if (IsDragging)
			{
				VizzyUI.DragUpdate(eventData.position);
				return;
			}
			_dragTotalDelta.y += Mathf.Abs(eventData.delta.y);
			_dragTotalDelta.x += eventData.delta.x;
			float num = Time.unscaledTime - _dragBeginTime;
			if (RequireHorizontalDrag && num < 2f && _dragTotalDelta.x > _dragTotalDelta.y * 1.25f)
			{
				ExecuteEvents.ExecuteHierarchy(RectTransform.parent.gameObject, eventData, ExecuteEvents.endDragHandler);
				StartDrag(eventData);
			}
			else
			{
				ExecuteEvents.ExecuteHierarchy(RectTransform.parent.gameObject, eventData, ExecuteEvents.dragHandler);
			}
		}

		void IEndDragHandler.OnEndDrag(PointerEventData eventData)
		{
			if (IsDragging)
			{
				IsDragging = false;
				VizzyUI.DragEnd(eventData.position);
			}
			else
			{
				ExecuteEvents.ExecuteHierarchy(RectTransform.parent.gameObject, eventData, ExecuteEvents.endDragHandler);
			}
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
			if (VizzyUI.Interactable)
			{
				OnPointerClick(eventData);
			}
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
			OnPointerUp(eventData);
		}

		public virtual void OnUserConnected(ConnectionPoint thisConnection, ConnectionPoint targetConnection)
		{
		}

		public virtual void PreviewConnection(ConnectionPoint connectionPoint)
		{
		}

		public void RemoveChild(BlockElementScript child)
		{
			_children.Remove(child);
			child.RectTransform.SetParent(VizzyUI.ProgramTransform, worldPositionStays: true);
		}

		public void StartClone(PointerEventData eventData, bool cloneChain)
		{
			IsDragging = true;
			List<BlockElementScript> blocks = VizzyUI.NodeBuilder.CloneBlock(this, cloneChain);
			VizzyUI.DragBegin(blocks, eventData.position);
		}

		protected virtual void Awake()
		{
			_image = GetComponent<Image>();
			RectTransform = GetComponent<RectTransform>();
		}

		protected virtual List<BlockElementScript> DragBegin()
		{
			return new List<BlockElementScript> { this };
		}

		protected virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		protected virtual void OnPointerUp(PointerEventData eventData)
		{
		}

		protected Vector2 SetBlockSize(Vector2 size)
		{
			size.x = Mathf.Max(_minSize.x, size.x);
			size.y = Mathf.Max(_minSize.y, size.y);
			RectTransform.sizeDelta = size;
			return size;
		}

		protected virtual void Start()
		{
		}

		protected virtual void Update()
		{
			if (_updateLayoutQueued)
			{
				_updateLayoutQueued = false;
				LayoutElement();
			}
		}

		protected void UpdateColor()
		{
			if (_image != null)
			{
				float amount = 1f;
				switch (VisualState)
				{
				case VisualStateType.Normal:
					amount = 1f;
					break;
				case VisualStateType.Brighter1:
					amount = 1.1f;
					break;
				case VisualStateType.Brighter2:
					amount = 1.25f;
					break;
				case VisualStateType.Brighter3:
					amount = 1.5f;
					break;
				}
				Color color = Style.Color;
				if (Error != null)
				{
					color = Color.red;
				}
				Color = MultiplyBrightness(color, amount);
			}
		}

		private static Color MultiplyBrightness(Color color, float amount)
		{
			Color.RGBToHSV(color, out var H, out var S, out var V);
			V *= amount;
			return Color.HSVToRGB(H, S, V);
		}

		private void StartDrag(PointerEventData eventData)
		{
			VizzyUI.SelectedElement = null;
			if (SupportsClone && (DragBehavior == DragBehaviorType.Clone || eventData.button == PointerEventData.InputButton.Right))
			{
				bool key = UnityEngine.Input.GetKey(KeyCode.LeftControl);
				StartClone(eventData, key);
			}
			else
			{
				IsDragging = true;
				List<BlockElementScript> blocks = DragBegin();
				VizzyUI.DragBegin(blocks, eventData.position);
			}
		}
	}
}
