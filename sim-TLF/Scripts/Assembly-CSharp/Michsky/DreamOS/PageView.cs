using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[SelectionBase]
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(RectTransform))]
	public class PageView : UIBehaviour, IInitializePotentialDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IScrollHandler, ICanvasElement, ILayoutElement, ILayoutGroup, ILayoutController
	{
		[Serializable]
		public class PagingEvent : UnityEvent<int>
		{
		}

		[Header("RESOURCES")]
		[SerializeField]
		private RectTransform m_PageParent;

		[Header("PAGE LIST")]
		[SerializeField]
		private RectTransform[] m_Pages;

		[Header("SETTINGS")]
		[SerializeField]
		private bool m_Horizontal = true;

		[SerializeField]
		private bool m_Vertical = true;

		[SerializeField]
		private float m_Elasticity = 0.1f;

		[SerializeField]
		private bool m_Inertia = true;

		[SerializeField]
		private float m_DecelerationRate = 0.135f;

		[SerializeField]
		private float m_ScrollSensitivity = 1f;

		[Header("EVENTS")]
		[SerializeField]
		private PagingEvent m_OnValueChanged = new PagingEvent();

		private Vector2 m_PointerStartLocalCursor = Vector2.zero;

		private Vector2 m_ContentStartPosition = Vector2.zero;

		private RectTransform m_ViewRect;

		[NonSerialized]
		private RectTransform m_Rect;

		private Vector2 m_Velocity;

		private bool m_Dragging;

		private Bounds m_ViewBounds;

		private Bounds m_ContentBounds;

		private Bounds m_CurrentContentBounds;

		private Bounds m_PrevViewBounds;

		private Bounds m_PrevContentBounds;

		private Bounds m_PrevCurrentContentBounds;

		private Vector2 m_PrevPosition = Vector2.zero;

		private DrivenRectTransformTracker m_Tracker;

		[NonSerialized]
		private bool m_HasRebuiltLayout;

		private const float EPSILON = float.Epsilon;

		private int m_PrevContentIndex;

		private int m_ContentIndex;

		private readonly Vector3[] m_Corners = new Vector3[4];

		public RectTransform PageParent
		{
			get
			{
				return m_PageParent;
			}
			set
			{
				m_PageParent = value;
			}
		}

		public RectTransform[] Pages
		{
			get
			{
				return m_Pages;
			}
			set
			{
				m_Pages = value;
			}
		}

		public bool Horizontal
		{
			get
			{
				return m_Horizontal;
			}
			set
			{
				m_Horizontal = value;
			}
		}

		public bool Vertical
		{
			get
			{
				return m_Vertical;
			}
			set
			{
				m_Vertical = value;
			}
		}

		public float Elasticity
		{
			get
			{
				return m_Elasticity;
			}
			set
			{
				m_Elasticity = value;
			}
		}

		public bool Inertia
		{
			get
			{
				return m_Inertia;
			}
			set
			{
				m_Inertia = value;
			}
		}

		public float DecelerationRate
		{
			get
			{
				return m_DecelerationRate;
			}
			set
			{
				m_DecelerationRate = value;
			}
		}

		public float ScrollSensitivity
		{
			get
			{
				return m_ScrollSensitivity;
			}
			set
			{
				m_ScrollSensitivity = value;
			}
		}

		public PagingEvent OnValueChanged
		{
			get
			{
				return m_OnValueChanged;
			}
			set
			{
				m_OnValueChanged = value;
			}
		}

		public RectTransform ViewRect
		{
			get
			{
				if (m_ViewRect == null)
				{
					m_ViewRect = (RectTransform)base.transform;
				}
				return m_ViewRect;
			}
		}

		private RectTransform RectTransform
		{
			get
			{
				if (m_Rect == null)
				{
					m_Rect = GetComponent<RectTransform>();
				}
				return m_Rect;
			}
		}

		public Vector2 Velocity
		{
			get
			{
				return m_Velocity;
			}
			set
			{
				m_Velocity = value;
			}
		}

		public virtual float minWidth => -1f;

		public virtual float preferredWidth => -1f;

		public virtual float flexibleWidth { get; private set; }

		public virtual float minHeight => -1f;

		public virtual float preferredHeight => -1f;

		public virtual float flexibleHeight => -1f;

		public virtual int layoutPriority => -1;

		Transform ICanvasElement.transform => base.transform;

		protected PageView()
		{
			flexibleWidth = -1f;
		}

		public void Rebuild(CanvasUpdate executing)
		{
			if (executing == CanvasUpdate.PostLayout)
			{
				UpdateBounds();
				UpdatePrevData();
				m_HasRebuiltLayout = true;
			}
		}

		protected override void OnRectTransformDimensionsChange()
		{
			SetDirty();
		}

		public virtual void LayoutComplete()
		{
		}

		public virtual void GraphicUpdateComplete()
		{
		}

		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		public virtual void CalculateLayoutInputVertical()
		{
		}

		public virtual void SetLayoutHorizontal()
		{
			m_Tracker.Clear();
		}

		public virtual void SetLayoutVertical()
		{
			m_ViewBounds = new Bounds(ViewRect.rect.center, ViewRect.rect.size);
			m_ContentBounds = GetBounds(m_PageParent);
			m_CurrentContentBounds = GetBounds(m_Pages[m_ContentIndex]);
		}

		public virtual void OnScroll(PointerEventData eventData)
		{
			if (!IsActive())
			{
				return;
			}
			EnsureLayoutHasRebuilt();
			UpdateBounds();
			Vector2 scrollDelta = eventData.scrollDelta;
			scrollDelta.y *= -1f;
			if (Vertical && !Horizontal)
			{
				if (Mathf.Abs(scrollDelta.x) > Mathf.Abs(scrollDelta.y))
				{
					scrollDelta.y = scrollDelta.x;
				}
				scrollDelta.x = 0f;
			}
			if (Horizontal && !Vertical)
			{
				if (Mathf.Abs(scrollDelta.y) > Mathf.Abs(scrollDelta.x))
				{
					scrollDelta.x = scrollDelta.y;
				}
				scrollDelta.y = 0f;
			}
			Vector2 anchoredPosition = m_PageParent.anchoredPosition;
			anchoredPosition += scrollDelta * m_ScrollSensitivity;
			SetContentAnchoredPosition(anchoredPosition);
			UpdateBounds();
		}

		public void OnInitializePotentialDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				m_Velocity = Vector2.zero;
			}
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left && IsActive())
			{
				UpdateBounds();
				m_PointerStartLocalCursor = Vector2.zero;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(ViewRect, eventData.position, eventData.pressEventCamera, out m_PointerStartLocalCursor);
				m_ContentStartPosition = m_PageParent.anchoredPosition;
				m_Dragging = true;
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				m_Dragging = false;
				JudgementIndex();
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left && IsActive() && RectTransformUtility.ScreenPointToLocalPointInRectangle(ViewRect, eventData.position, eventData.pressEventCamera, out var localPoint))
			{
				UpdateBounds();
				Vector2 vector = localPoint - m_PointerStartLocalCursor;
				Vector2 vector2 = m_ContentStartPosition + vector;
				Vector2 vector3 = CalculateOffset(m_ContentBounds, vector2 - m_PageParent.anchoredPosition);
				vector2 += vector3;
				if (Math.Abs(vector3.x) > float.Epsilon)
				{
					vector2.x -= RubberDelta(vector3.x, m_ViewBounds.size.x);
				}
				if (Math.Abs(vector3.y) > float.Epsilon)
				{
					vector2.y -= RubberDelta(vector3.y, m_ViewBounds.size.y);
				}
				SetContentAnchoredPosition(vector2);
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			CanvasUpdateRegistry.RegisterCanvasElementForLayoutRebuild(this);
		}

		protected override void OnDisable()
		{
			CanvasUpdateRegistry.UnRegisterCanvasElementForRebuild(this);
			m_Tracker.Clear();
			m_Velocity = Vector2.zero;
			LayoutRebuilder.MarkLayoutForRebuild(RectTransform);
			base.OnDisable();
		}

		public override bool IsActive()
		{
			if (base.IsActive())
			{
				return m_PageParent != null;
			}
			return false;
		}

		private void LateUpdate()
		{
			if (!m_PageParent)
			{
				return;
			}
			EnsureLayoutHasRebuilt();
			UpdateBounds();
			float unscaledDeltaTime = Time.unscaledDeltaTime;
			Vector2 vector = CalculateOffset(m_CurrentContentBounds, Vector2.zero);
			if (!m_Dragging && (vector != Vector2.zero || m_Velocity != Vector2.zero))
			{
				Vector2 anchoredPosition = m_PageParent.anchoredPosition;
				for (int i = 0; i < 2; i++)
				{
					if (Math.Abs(vector[i]) > float.Epsilon)
					{
						float currentVelocity = m_Velocity[i];
						anchoredPosition[i] = Mathf.SmoothDamp(m_PageParent.anchoredPosition[i], m_PageParent.anchoredPosition[i] + vector[i], ref currentVelocity, m_Elasticity, float.PositiveInfinity, unscaledDeltaTime);
						m_Velocity[i] = currentVelocity;
					}
					else if (m_Inertia)
					{
						m_Velocity[i] *= Mathf.Pow(m_DecelerationRate, unscaledDeltaTime);
						if (Mathf.Abs(m_Velocity[i]) < 1f)
						{
							m_Velocity[i] = 0f;
						}
						anchoredPosition[i] += m_Velocity[i] * unscaledDeltaTime;
					}
					else
					{
						m_Velocity[i] = 0f;
					}
				}
				if (m_Velocity != Vector2.zero)
				{
					SetContentAnchoredPosition(anchoredPosition);
				}
			}
			if (m_Dragging && m_Inertia)
			{
				Vector3 b = (m_PageParent.anchoredPosition - m_PrevPosition) / unscaledDeltaTime;
				m_Velocity = Vector3.Lerp(m_Velocity, b, unscaledDeltaTime * 10f);
			}
			if (m_Dragging && m_Velocity != Vector2.zero)
			{
				JudgementIndex(vector);
			}
			if (!m_Dragging && m_PrevContentIndex != m_ContentIndex)
			{
				m_OnValueChanged.Invoke(m_ContentIndex);
				m_PrevContentIndex = m_ContentIndex;
			}
			if (m_ViewBounds != m_PrevViewBounds || m_ContentBounds != m_PrevContentBounds || m_ContentBounds != m_PrevCurrentContentBounds || m_PageParent.anchoredPosition != m_PrevPosition)
			{
				UpdatePrevData();
			}
		}

		public virtual void StopMovement()
		{
			m_Velocity = Vector2.zero;
		}

		protected virtual void SetContentAnchoredPosition(Vector2 position)
		{
			if (!m_Horizontal)
			{
				position.x = m_PageParent.anchoredPosition.x;
			}
			if (!m_Vertical)
			{
				position.y = m_PageParent.anchoredPosition.y;
			}
			if (position != m_PageParent.anchoredPosition)
			{
				m_PageParent.anchoredPosition = position;
				UpdateBounds();
			}
		}

		private void EnsureLayoutHasRebuilt()
		{
			if (m_HasRebuiltLayout && !CanvasUpdateRegistry.IsRebuildingLayout())
			{
				Canvas.ForceUpdateCanvases();
			}
		}

		private void UpdatePrevData()
		{
			if (m_PageParent == null)
			{
				m_PrevPosition = Vector2.zero;
			}
			else
			{
				m_PrevPosition = m_PageParent.anchoredPosition;
			}
			m_PrevViewBounds = m_ViewBounds;
			m_PrevContentBounds = m_ContentBounds;
			m_PrevCurrentContentBounds = m_ContentBounds;
		}

		private static float RubberDelta(float overStretching, float viewSize)
		{
			return (1f - 1f / (Mathf.Abs(overStretching) * 0.55f / viewSize + 1f)) * viewSize * Mathf.Sign(overStretching);
		}

		private void UpdateBounds()
		{
			m_ViewBounds = new Bounds(ViewRect.rect.center, ViewRect.rect.size);
			m_ContentBounds = GetBounds(m_PageParent);
			m_CurrentContentBounds = GetBounds(m_Pages[m_ContentIndex]);
			if (!(m_PageParent == null))
			{
				Vector3 size = m_ContentBounds.size;
				Vector3 center = m_ContentBounds.center;
				Vector3 vector = m_ViewBounds.size - size;
				if (vector.x > 0f)
				{
					center.x -= vector.x * (m_PageParent.pivot.x - 0.5f);
					size.x = m_ViewBounds.size.x;
				}
				if (vector.y > 0f)
				{
					center.y -= vector.y * (m_PageParent.pivot.y - 0.5f);
					size.y = m_ViewBounds.size.y;
				}
				m_ContentBounds.size = size;
				m_ContentBounds.center = center;
			}
		}

		private Bounds GetBounds(RectTransform PageParent)
		{
			if (m_PageParent == null)
			{
				return default(Bounds);
			}
			Vector3 vector = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
			Vector3 vector2 = new Vector3(float.MinValue, float.MinValue, float.MinValue);
			Matrix4x4 worldToLocalMatrix = ViewRect.worldToLocalMatrix;
			PageParent.GetWorldCorners(m_Corners);
			for (int i = 0; i < 4; i++)
			{
				Vector3 lhs = worldToLocalMatrix.MultiplyPoint3x4(m_Corners[i]);
				vector = Vector3.Min(lhs, vector);
				vector2 = Vector3.Max(lhs, vector2);
			}
			Bounds result = new Bounds(vector, Vector3.zero);
			result.Encapsulate(vector2);
			return result;
		}

		private Vector2 CalculateOffset(Bounds bounds, Vector2 delta)
		{
			Vector2 zero = Vector2.zero;
			Vector2 vector = bounds.min;
			Vector2 vector2 = bounds.max;
			if (m_Horizontal)
			{
				vector.x += delta.x;
				vector2.x += delta.x;
				if (vector.x > m_ViewBounds.min.x)
				{
					zero.x = m_ViewBounds.min.x - vector.x;
				}
				else if (vector2.x < m_ViewBounds.max.x)
				{
					zero.x = m_ViewBounds.max.x - vector2.x;
				}
			}
			if (m_Vertical)
			{
				vector.y += delta.y;
				vector2.y += delta.y;
				if (vector2.y < m_ViewBounds.max.y)
				{
					zero.y = m_ViewBounds.max.y - vector2.y;
				}
				else if (vector.y > m_ViewBounds.min.y)
				{
					zero.y = m_ViewBounds.min.y - vector.y;
				}
			}
			return zero;
		}

		private void JudgementIndex()
		{
			if (Horizontal)
			{
				if (0f - m_Velocity.x > m_ViewBounds.size.x)
				{
					m_ContentIndex = Mathf.Clamp(m_PrevContentIndex + 1, 0, m_Pages.Length - 1);
				}
				else if (m_Velocity.x > m_ViewBounds.size.x)
				{
					m_ContentIndex = Mathf.Clamp(m_PrevContentIndex - 1, 0, m_Pages.Length - 1);
				}
			}
			if (Vertical)
			{
				if (m_Velocity.y > m_ViewBounds.size.y)
				{
					m_ContentIndex = Mathf.Clamp(m_PrevContentIndex + 1, 0, m_Pages.Length - 1);
				}
				else if (0f - m_Velocity.y > m_ViewBounds.size.y)
				{
					m_ContentIndex = Mathf.Clamp(m_PrevContentIndex - 1, 0, m_Pages.Length - 1);
				}
			}
		}

		private void JudgementIndex(Vector2 offset)
		{
			if (Horizontal)
			{
				if (offset.x > m_ViewBounds.extents.x)
				{
					m_ContentIndex = Mathf.Clamp(m_ContentIndex + 1, 0, m_Pages.Length - 1);
				}
				else if (0f - offset.x > m_ViewBounds.extents.x)
				{
					m_ContentIndex = Mathf.Clamp(m_ContentIndex - 1, 0, m_Pages.Length - 1);
				}
			}
			if (Vertical)
			{
				if (0f - offset.y > m_ViewBounds.extents.y)
				{
					m_ContentIndex = Mathf.Clamp(m_ContentIndex + 1, 0, m_Pages.Length - 1);
				}
				else if (offset.y > m_ViewBounds.extents.y)
				{
					m_ContentIndex = Mathf.Clamp(m_ContentIndex - 1, 0, m_Pages.Length - 1);
				}
			}
		}

		protected void SetDirty()
		{
			if (IsActive())
			{
				LayoutRebuilder.MarkLayoutForRebuild(RectTransform);
			}
		}

		protected void SetDirtyCaching()
		{
			if (IsActive())
			{
				CanvasUpdateRegistry.RegisterCanvasElementForLayoutRebuild(this);
				LayoutRebuilder.MarkLayoutForRebuild(RectTransform);
			}
		}
	}
}
