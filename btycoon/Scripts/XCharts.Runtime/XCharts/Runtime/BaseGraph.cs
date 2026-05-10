using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	[RequireComponent(typeof(CanvasRenderer))]
	public class BaseGraph : MaskableGraphic, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IPointerClickHandler, IDragHandler, IEndDragHandler, IScrollHandler
	{
		[SerializeField]
		protected bool m_EnableTextMeshPro;

		protected Painter m_Painter;

		protected int m_SiblingIndex;

		protected float m_GraphWidth;

		protected float m_GraphHeight;

		protected float m_GraphX;

		protected float m_GraphY;

		protected Vector3 m_GraphPosition = Vector3.zero;

		protected Vector2 m_GraphMinAnchor;

		protected Vector2 m_GraphMaxAnchor;

		protected Vector2 m_GraphPivot;

		protected Vector2 m_GraphSizeDelta;

		protected Vector2 m_GraphAnchoredPosition;

		protected Rect m_GraphRect = new Rect(0f, 0f, 0f, 0f);

		protected bool m_RefreshChart;

		protected bool m_ForceOpenRaycastTarget;

		protected bool m_IsControlledByLayout;

		protected bool m_PainerDirty;

		protected bool m_IsOnValidate;

		protected Vector3 m_LastLocalPosition;

		protected PointerEventData m_PointerEventData;

		protected Action<PointerEventData, BaseGraph> m_OnPointerClick;

		protected Action<PointerEventData, BaseGraph> m_OnPointerDown;

		protected Action<PointerEventData, BaseGraph> m_OnPointerUp;

		protected Action<PointerEventData, BaseGraph> m_OnPointerEnter;

		protected Action<PointerEventData, BaseGraph> m_OnPointerExit;

		protected Action<PointerEventData, BaseGraph> m_OnBeginDrag;

		protected Action<PointerEventData, BaseGraph> m_OnDrag;

		protected Action<PointerEventData, BaseGraph> m_OnEndDrag;

		protected Action<PointerEventData, BaseGraph> m_OnScroll;

		private ScrollRect m_ScrollRect;

		public float graphX => m_GraphX;

		public float graphY => m_GraphY;

		public float graphWidth => m_GraphWidth;

		public float graphHeight => m_GraphHeight;

		public Vector3 graphPosition => m_GraphPosition;

		public Rect graphRect => m_GraphRect;

		public Vector2 graphSizeDelta => m_GraphSizeDelta;

		public Vector2 graphPivot => m_GraphPivot;

		public Vector2 graphMinAnchor => m_GraphMinAnchor;

		public Vector2 graphMaxAnchor => m_GraphMaxAnchor;

		public Vector2 graphAnchoredPosition => m_GraphAnchoredPosition;

		public Vector2 pointerPos { get; protected set; }

		public bool isPointerInChart => m_PointerEventData != null;

		public string warningInfo { get; protected set; }

		public bool forceOpenRaycastTarget
		{
			get
			{
				return m_ForceOpenRaycastTarget;
			}
			set
			{
				m_ForceOpenRaycastTarget = value;
			}
		}

		public Action<PointerEventData, BaseGraph> onPointerClick
		{
			set
			{
				m_OnPointerClick = value;
				m_ForceOpenRaycastTarget = true;
			}
		}

		public Action<PointerEventData, BaseGraph> onPointerDown
		{
			set
			{
				m_OnPointerDown = value;
				m_ForceOpenRaycastTarget = true;
			}
		}

		public Action<PointerEventData, BaseGraph> onPointerUp
		{
			set
			{
				m_OnPointerUp = value;
				m_ForceOpenRaycastTarget = true;
			}
		}

		public Action<PointerEventData, BaseGraph> onPointerEnter
		{
			set
			{
				m_OnPointerEnter = value;
				m_ForceOpenRaycastTarget = true;
			}
		}

		public Action<PointerEventData, BaseGraph> onPointerExit
		{
			set
			{
				m_OnPointerExit = value;
				m_ForceOpenRaycastTarget = true;
			}
		}

		public Action<PointerEventData, BaseGraph> onBeginDrag
		{
			set
			{
				m_OnBeginDrag = value;
				m_ForceOpenRaycastTarget = true;
			}
		}

		public Action<PointerEventData, BaseGraph> onDrag
		{
			set
			{
				m_OnDrag = value;
				m_ForceOpenRaycastTarget = true;
			}
		}

		public Action<PointerEventData, BaseGraph> onEndDrag
		{
			set
			{
				m_OnEndDrag = value;
				m_ForceOpenRaycastTarget = true;
			}
		}

		public Action<PointerEventData, BaseGraph> onScroll
		{
			set
			{
				m_OnScroll = value;
				m_ForceOpenRaycastTarget = true;
			}
		}

		public virtual HideFlags chartHideFlags => HideFlags.None;

		public Painter painter => m_Painter;

		public virtual void SetSize(float width, float height)
		{
			if (LayerHelper.IsFixedWidthHeight(base.rectTransform))
			{
				base.rectTransform.sizeDelta = new Vector2(width, height);
			}
			else
			{
				Debug.LogError("Can't set size on stretch pivot,you need to modify rectTransform by yourself.");
			}
		}

		public void SetPainterDirty()
		{
			m_PainerDirty = true;
		}

		public virtual void RefreshGraph()
		{
			m_RefreshChart = true;
		}

		public void RefreshAllComponent()
		{
			SetAllComponentDirty();
			RefreshGraph();
		}

		public string CheckWarning()
		{
			warningInfo = CheckHelper.CheckChart(this);
			return warningInfo;
		}

		public void RebuildChartObject()
		{
			ChartHelper.DestroyAllChildren(base.transform);
			SetAllComponentDirty();
		}

		public bool ScreenPointToChartPoint(Vector2 screenPoint, out Vector2 chartPoint)
		{
			Vector3 vector = Display.RelativeMouseAt(screenPoint);
			if (vector != Vector3.zero)
			{
				screenPoint = vector;
			}
			Camera cam = ((base.canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : base.canvas.worldCamera);
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, screenPoint, cam, out chartPoint))
			{
				return false;
			}
			return true;
		}

		[Since("v3.7.0")]
		public Vector2 LocalPointToScreenPoint(Vector2 localPoint)
		{
			Camera cam = ((base.canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : base.canvas.worldCamera);
			Vector3 worldPoint = base.rectTransform.TransformPoint(localPoint);
			return RectTransformUtility.WorldToScreenPoint(cam, worldPoint);
		}

		[Since("v3.7.0")]
		public Vector2 LocalPointToWorldPoint(Vector2 localPoint)
		{
			return base.rectTransform.TransformPoint(localPoint);
		}

		public void SaveAsImage(string imageType = "png", string savePath = "")
		{
			StartCoroutine(SaveAsImageSync(imageType, savePath));
		}

		private IEnumerator SaveAsImageSync(string imageType, string path)
		{
			yield return new WaitForEndOfFrame();
			ChartHelper.SaveAsImage(base.rectTransform, base.canvas, imageType, path);
		}

		protected virtual void InitComponent()
		{
			InitPainter();
		}

		protected override void Awake()
		{
			CheckTextMeshPro();
			m_SiblingIndex = 0;
			m_LastLocalPosition = base.transform.localPosition;
			UpdateSize();
			InitComponent();
			CheckIsInScrollRect();
		}

		protected override void Start()
		{
			m_RefreshChart = true;
		}

		protected virtual void Update()
		{
			CheckSize();
			if (m_IsOnValidate)
			{
				m_IsOnValidate = false;
				CheckTextMeshPro();
				InitComponent();
				RefreshGraph();
			}
			else
			{
				CheckComponent();
			}
			CheckPointerPos();
			CheckRefreshChart();
			CheckRefreshPainter();
		}

		protected virtual void SetAllComponentDirty()
		{
			m_PainerDirty = true;
		}

		protected virtual void CheckComponent()
		{
			if (m_PainerDirty)
			{
				InitPainter();
				m_PainerDirty = false;
			}
		}

		private void CheckTextMeshPro()
		{
			bool flag = false;
			if (m_EnableTextMeshPro != flag)
			{
				m_EnableTextMeshPro = flag;
				RebuildChartObject();
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			for (int num = base.transform.childCount - 1; num >= 0; num--)
			{
				UnityEngine.Object.DestroyImmediate(base.transform.GetChild(num).gameObject);
			}
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
		}

		protected virtual void InitPainter()
		{
			m_Painter = ChartHelper.AddPainterObject("painter_b", base.transform, m_GraphMinAnchor, m_GraphMaxAnchor, m_GraphPivot, new Vector2(m_GraphWidth, m_GraphHeight), chartHideFlags, 1);
			m_Painter.type = Painter.Type.Base;
			m_Painter.onPopulateMesh = OnDrawPainterBase;
			m_Painter.transform.SetSiblingIndex(0);
		}

		private void CheckSize()
		{
			float width = base.rectTransform.rect.width;
			float height = base.rectTransform.rect.height;
			if (m_GraphWidth == 0f && m_GraphHeight == 0f && (width != 0f || height != 0f))
			{
				Awake();
			}
			if (m_GraphWidth != width || m_GraphHeight != height || m_GraphMinAnchor != base.rectTransform.anchorMin || m_GraphMaxAnchor != base.rectTransform.anchorMax || m_GraphAnchoredPosition != base.rectTransform.anchoredPosition)
			{
				UpdateSize();
			}
			if (!ChartHelper.IsValueEqualsVector3(m_LastLocalPosition, base.transform.localPosition))
			{
				m_LastLocalPosition = base.transform.localPosition;
				OnLocalPositionChanged();
			}
		}

		protected void UpdateSize()
		{
			m_GraphWidth = base.rectTransform.rect.width;
			m_GraphHeight = base.rectTransform.rect.height;
			m_GraphMaxAnchor = base.rectTransform.anchorMax;
			m_GraphMinAnchor = base.rectTransform.anchorMin;
			m_GraphSizeDelta = base.rectTransform.sizeDelta;
			m_GraphAnchoredPosition = base.rectTransform.anchoredPosition;
			base.rectTransform.pivot = LayerHelper.ResetChartPositionAndPivot(m_GraphMinAnchor, m_GraphMaxAnchor, m_GraphWidth, m_GraphHeight, ref m_GraphX, ref m_GraphY);
			m_GraphPivot = base.rectTransform.pivot;
			m_GraphRect.x = m_GraphX;
			m_GraphRect.y = m_GraphY;
			m_GraphRect.width = m_GraphWidth;
			m_GraphRect.height = m_GraphHeight;
			m_GraphPosition.x = m_GraphX;
			m_GraphPosition.y = m_GraphY;
			OnSizeChanged();
		}

		private void CheckPointerPos()
		{
			if (isPointerInChart && !(base.canvas == null))
			{
				Vector2 position = m_PointerEventData.position;
				if (!ScreenPointToChartPoint(position, out var chartPoint))
				{
					pointerPos = Vector2.zero;
				}
				else
				{
					pointerPos = chartPoint;
				}
			}
		}

		protected virtual void CheckIsInScrollRect()
		{
			m_ScrollRect = GetComponentInParent<ScrollRect>();
		}

		protected virtual void CheckRefreshChart()
		{
			if (m_RefreshChart && m_Painter != null)
			{
				m_Painter.Refresh();
				m_RefreshChart = false;
			}
		}

		protected virtual void CheckRefreshPainter()
		{
			if (!(m_Painter == null))
			{
				m_Painter.CheckRefresh();
			}
		}

		internal virtual void RefreshPainter(Painter painter)
		{
			if (!(painter == null))
			{
				painter.Refresh();
			}
		}

		protected virtual void OnSizeChanged()
		{
			m_RefreshChart = true;
		}

		protected virtual void OnLocalPositionChanged()
		{
		}

		protected virtual void OnDrawPainterBase(VertexHelper vh, Painter painter)
		{
			DrawPainterBase(vh);
		}

		protected virtual void DrawPainterBase(VertexHelper vh)
		{
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
			if (m_OnPointerClick != null)
			{
				m_OnPointerClick(eventData, this);
			}
		}

		public virtual void OnPointerDown(PointerEventData eventData)
		{
			if (m_OnPointerDown != null)
			{
				m_OnPointerDown(eventData, this);
			}
		}

		public virtual void OnPointerUp(PointerEventData eventData)
		{
			if (m_OnPointerUp != null)
			{
				m_OnPointerUp(eventData, this);
			}
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
			m_PointerEventData = eventData;
			if (m_OnPointerEnter != null)
			{
				m_OnPointerEnter(eventData, this);
			}
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
			m_PointerEventData = null;
			if (m_OnPointerExit != null)
			{
				m_OnPointerExit(eventData, this);
			}
		}

		public virtual void OnBeginDrag(PointerEventData eventData)
		{
			if (m_ScrollRect != null)
			{
				m_ScrollRect.OnBeginDrag(eventData);
			}
			if (m_OnBeginDrag != null)
			{
				m_OnBeginDrag(eventData, this);
			}
		}

		public virtual void OnEndDrag(PointerEventData eventData)
		{
			if (m_ScrollRect != null)
			{
				m_ScrollRect.OnEndDrag(eventData);
			}
			if (m_OnEndDrag != null)
			{
				m_OnEndDrag(eventData, this);
			}
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
			if (m_ScrollRect != null)
			{
				m_ScrollRect.OnDrag(eventData);
			}
			if (m_OnDrag != null)
			{
				m_OnDrag(eventData, this);
			}
		}

		public virtual void OnScroll(PointerEventData eventData)
		{
			if (m_ScrollRect != null)
			{
				m_ScrollRect.OnScroll(eventData);
			}
			if (m_OnScroll != null)
			{
				m_OnScroll(eventData, this);
			}
		}
	}
}
