using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DigitalLegacy.UI.Sizing
{
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[AddComponentMenu("UI/uResize")]
	public class uResize : MonoBehaviour
	{
		[Serializable]
		public class ResizeListenerTypeEvent : UnityEvent<eResizeListenerType>
		{
		}

		[SerializeField]
		[Header("Edges")]
		private bool m_AllowResizeFromLeft;

		[SerializeField]
		private bool m_AllowResizeFromRight = true;

		[SerializeField]
		private bool m_AllowResizeFromTop;

		[SerializeField]
		private bool m_AllowResizeFromBottom = true;

		[Header("Corners")]
		[SerializeField]
		private bool m_AllowResizeFromTopLeft;

		[SerializeField]
		private bool m_AllowResizeFromTopRight;

		[SerializeField]
		private bool m_AllowResizeFromBottomLeft;

		[SerializeField]
		private bool m_AllowResizeFromBottomRight = true;

		[Header("Size Restrictions")]
		public Vector2 MinSize = Vector2.zero;

		public Vector2 MaxSize = Vector2.zero;

		[SerializeField]
		private bool m_KeepWithinParent = true;

		[Header("Aspect Ratio")]
		public eAspectRatioMode AspectRatioControl;

		public Vector2 DesiredAspectRatio = Vector2.one;

		[Header("Pivot")]
		public bool AdjustPivot = true;

		[SerializeField]
		[Range(1f, 256f)]
		[Header("Resize Listeners")]
		private float m_ResizeListenerThickness = 16f;

		[Header("Listener Offsets")]
		private Vector2 m_resizeListenerOffsetMin = Vector2.zero;

		private Vector2 m_resizeListenerOffsetMax = Vector2.zero;

		[SerializeField]
		private Color m_ResizeListenerColor = Color.clear;

		[HideInInspector]
		public ResizeListenerTypeEvent OnPointerEnterResizeListener = new ResizeListenerTypeEvent();

		[HideInInspector]
		public ResizeListenerTypeEvent OnPointerExitResizeListener = new ResizeListenerTypeEvent();

		[HideInInspector]
		public ResizeListenerTypeEvent OnResizeBegin = new ResizeListenerTypeEvent();

		[HideInInspector]
		public UnityEvent OnResizeEnd = new UnityEvent();

		[HideInInspector]
		public UnityEvent OnResizeUpdate = new UnityEvent();

		private Dictionary<eResizeListenerType, uResize_ResizeListener> ResizeListeners = new Dictionary<eResizeListenerType, uResize_ResizeListener>();

		[SerializeField]
		[HideInInspector]
		private RectTransform ResizeListenerContainer;

		private RectTransform m_rectTransform;

		private Canvas m_canvas;

		private LayoutElement m_layoutElement;

		private Vector2 m_pivotBeforeResize;

		private Vector2 m_anchorMinBeforeResize;

		private Vector2 m_anchorMaxBeforeResize;

		private Vector3[] m_parentCorners = new Vector3[4];

		private Vector3[] m_thisCorners = new Vector3[4];

		private Vector3[] s_Corners = new Vector3[4];

		public bool AllowResizeFromLeft
		{
			get
			{
				return m_AllowResizeFromLeft;
			}
			set
			{
				m_AllowResizeFromLeft = value;
				UpdateListeners();
			}
		}

		public bool AllowResizeFromRight
		{
			get
			{
				return m_AllowResizeFromRight;
			}
			set
			{
				m_AllowResizeFromRight = value;
				UpdateListeners();
			}
		}

		public bool AllowResizeFromTop
		{
			get
			{
				return m_AllowResizeFromTop;
			}
			set
			{
				m_AllowResizeFromTop = value;
				UpdateListeners();
			}
		}

		public bool AllowResizeFromBottom
		{
			get
			{
				return m_AllowResizeFromBottom;
			}
			set
			{
				m_AllowResizeFromBottom = value;
				UpdateListeners();
			}
		}

		public bool AllowResizeFromTopLeft
		{
			get
			{
				return m_AllowResizeFromTopLeft;
			}
			set
			{
				m_AllowResizeFromTopLeft = value;
				UpdateListeners();
			}
		}

		public bool AllowResizeFromTopRight
		{
			get
			{
				return m_AllowResizeFromTopRight;
			}
			set
			{
				m_AllowResizeFromTopRight = value;
				UpdateListeners();
			}
		}

		public bool AllowResizeFromBottomLeft
		{
			get
			{
				return m_AllowResizeFromBottomLeft;
			}
			set
			{
				m_AllowResizeFromBottomLeft = value;
				UpdateListeners();
			}
		}

		public bool AllowResizeFromBottomRight
		{
			get
			{
				return m_AllowResizeFromBottomRight;
			}
			set
			{
				m_AllowResizeFromBottomRight = value;
				UpdateListeners();
			}
		}

		public bool KeepWithinParent
		{
			get
			{
				return m_KeepWithinParent;
			}
			set
			{
				m_KeepWithinParent = value;
			}
		}

		public float ResizeListenerThickness
		{
			get
			{
				return m_ResizeListenerThickness;
			}
			set
			{
				m_ResizeListenerThickness = value;
				UpdateListeners();
			}
		}

		public Vector2 ResizeListenerOffsetMin
		{
			get
			{
				return m_resizeListenerOffsetMin;
			}
			set
			{
				m_resizeListenerOffsetMin = value;
				UpdateListeners();
			}
		}

		public Vector2 ResizeListenerOffsetMax
		{
			get
			{
				return m_resizeListenerOffsetMax;
			}
			set
			{
				m_resizeListenerOffsetMax = value;
				UpdateListeners();
			}
		}

		public Color ResizeListenerColor
		{
			get
			{
				return m_ResizeListenerColor;
			}
			set
			{
				m_ResizeListenerColor = value;
				UpdateListeners();
			}
		}

		private RectTransform rectTransform
		{
			get
			{
				if (m_rectTransform == null)
				{
					m_rectTransform = GetComponent<RectTransform>();
				}
				return m_rectTransform;
			}
		}

		private Canvas canvas
		{
			get
			{
				if (m_canvas == null)
				{
					m_canvas = GetComponentInParent<Canvas>();
				}
				return m_canvas;
			}
		}

		private void Awake()
		{
			if (ResizeListenerContainer == null)
			{
				return;
			}
			for (int num = ResizeListenerContainer.childCount - 1; num >= 0; num--)
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(ResizeListenerContainer.GetChild(num).gameObject);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(ResizeListenerContainer.GetChild(num).gameObject);
				}
			}
		}

		private void OnEnable()
		{
			UpdateListeners();
			m_layoutElement = GetComponent<LayoutElement>();
			if (ResizeListenerContainer != null && !ResizeListenerContainer.gameObject.activeInHierarchy)
			{
				ResizeListenerContainer.gameObject.SetActive(value: true);
			}
		}

		private void OnDisable()
		{
			if (ResizeListenerContainer != null)
			{
				ResizeListenerContainer.gameObject.SetActive(value: false);
			}
		}

		public void UpdateListeners()
		{
			if (!Application.isPlaying)
			{
				return;
			}
			if (ResizeListenerContainer != null)
			{
				ResizeListenerContainer.offsetMin = ResizeListenerOffsetMin;
				ResizeListenerContainer.offsetMax = ResizeListenerOffsetMax;
			}
			UpdateListener(eResizeListenerType.Left, AllowResizeFromLeft);
			UpdateListener(eResizeListenerType.Right, AllowResizeFromRight);
			UpdateListener(eResizeListenerType.Top, AllowResizeFromTop);
			UpdateListener(eResizeListenerType.Bottom, AllowResizeFromBottom);
			UpdateListener(eResizeListenerType.TopLeft, AllowResizeFromTopLeft);
			UpdateListener(eResizeListenerType.TopRight, AllowResizeFromTopRight);
			UpdateListener(eResizeListenerType.BottomLeft, AllowResizeFromBottomLeft);
			UpdateListener(eResizeListenerType.BottomRight, AllowResizeFromBottomRight);
			List<uResize_ResizeListener> list = (from rl in ResizeListeners
				orderby rl.Key
				select rl.Value).ToList();
			int num = 0;
			foreach (uResize_ResizeListener item in list)
			{
				item.transform.SetSiblingIndex(num++);
			}
		}

		private void UpdateListener(eResizeListenerType type, bool enabled)
		{
			uResize_ResizeListener uResize_ResizeListener2 = null;
			if (ResizeListeners.ContainsKey(type))
			{
				uResize_ResizeListener2 = ResizeListeners[type];
			}
			else if (enabled)
			{
				uResize_ResizeListener2 = CreateListener(type);
				ResizeListeners.Add(type, uResize_ResizeListener2);
			}
			if (uResize_ResizeListener2 != null)
			{
				uResize_ResizeListener2.ImageComponent.color = ResizeListenerColor;
				UpdateResizeListenerPositionAndDimensions(uResize_ResizeListener2, type);
			}
			if (uResize_ResizeListener2 != null)
			{
				uResize_ResizeListener2.gameObject.SetActive(enabled);
			}
		}

		private void CreateResizeListenerContainer()
		{
			GameObject obj = new GameObject("Resize Listeners", typeof(RectTransform), typeof(LayoutElement));
			RectTransform component = obj.GetComponent<RectTransform>();
			component.SetParent(base.transform);
			component.anchorMin = Vector2.zero;
			component.anchorMax = Vector2.one;
			component.sizeDelta = Vector2.zero;
			component.anchoredPosition3D = Vector3.zero;
			component.localScale = Vector3.one;
			component.localRotation = Quaternion.identity;
			ResizeListenerContainer = component;
			obj.GetComponent<LayoutElement>().ignoreLayout = true;
		}

		private uResize_ResizeListener CreateListener(eResizeListenerType type)
		{
			GameObject obj = new GameObject(type.ToString(), typeof(uResize_ResizeListener));
			uResize_ResizeListener component = obj.GetComponent<uResize_ResizeListener>();
			RectTransform component2 = obj.GetComponent<RectTransform>();
			if (ResizeListenerContainer == null)
			{
				CreateResizeListenerContainer();
			}
			component2.SetParent(ResizeListenerContainer);
			component2.anchoredPosition3D = Vector3.zero;
			component2.offsetMin = ResizeListenerOffsetMin;
			component2.offsetMax = ResizeListenerOffsetMax;
			component2.localScale = Vector3.one;
			component2.localRotation = Quaternion.identity;
			component.OnBeginDragEvent = delegate
			{
				BeginResize(type);
			};
			component.OnEndDragEvent = EndResize;
			component.OnDragEvent = delegate(PointerEventData ev)
			{
				Resize(type, ev.delta);
			};
			component.OnPointerEnterEvent = delegate
			{
				OnPointerEnterResizeListener.Invoke(type);
			};
			component.OnPointerExitEvent = delegate
			{
				OnPointerExitResizeListener.Invoke(type);
			};
			return component;
		}

		private void UpdateResizeListenerPositionAndDimensions(uResize_ResizeListener listener, eResizeListenerType type)
		{
			RectTransform component = listener.GetComponent<RectTransform>();
			uResize_ListenerEdges edgesForListenerType = uResize_ListenerEdges.GetEdgesForListenerType(type);
			component.pivot = edgesForListenerType.pivot;
			component.SetInsetAndSizeFromParentEdge(edgesForListenerType.edgeA, 0f, ResizeListenerThickness);
			if (edgesForListenerType.isCorner)
			{
				component.SetInsetAndSizeFromParentEdge(edgesForListenerType.edgeB.Value, 0f, ResizeListenerThickness);
			}
			else if (edgesForListenerType.edgeA == RectTransform.Edge.Top || edgesForListenerType.edgeA == RectTransform.Edge.Bottom)
			{
				component.anchorMin = new Vector2(0f, component.anchorMin.y);
				component.anchorMax = new Vector2(1f, component.anchorMax.y);
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ResizeListenerContainer.rect.width);
			}
			else
			{
				component.anchorMin = new Vector2(component.anchorMin.x, 0f);
				component.anchorMax = new Vector2(component.anchorMax.x, 1f);
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, ResizeListenerContainer.rect.height);
			}
			component.anchoredPosition = Vector2.zero;
		}

		private void BeginResize(eResizeListenerType resizeType)
		{
			if (base.enabled)
			{
				if (AdjustPivot)
				{
					m_pivotBeforeResize = rectTransform.pivot;
					SetPivot(GetResizePivot(resizeType));
				}
				m_anchorMinBeforeResize = rectTransform.anchorMin;
				m_anchorMaxBeforeResize = rectTransform.anchorMax;
				SetAnchors(uResize_Vectors.MiddleCenter, uResize_Vectors.MiddleCenter);
				OnResizeBegin.Invoke(resizeType);
			}
		}

		private void EndResize()
		{
			if (base.enabled)
			{
				SetAnchors(m_anchorMinBeforeResize, m_anchorMaxBeforeResize);
				if (AdjustPivot)
				{
					SetPivot(m_pivotBeforeResize);
				}
				OnResizeEnd.Invoke();
			}
		}

		private void Resize(eResizeListenerType resizeType, Vector2 delta)
		{
			if (!base.enabled)
			{
				return;
			}
			delta *= 1f / canvas.scaleFactor;
			Vector2 vector = rectTransform.rect.size;
			bool flag = resizeType.IsHorizontal();
			bool flag2 = resizeType.IsVertical();
			bool flag3 = false;
			bool flag4 = false;
			if (flag)
			{
				flag3 = resizeType.IsInverseHorizontal();
			}
			if (flag2)
			{
				flag4 = resizeType.IsInverseVertical();
			}
			vector += new Vector2((!flag) ? 0f : (flag3 ? (0f - delta.x) : delta.x), (!flag2) ? 0f : (flag4 ? delta.y : (0f - delta.y)));
			if (AspectRatioControl != eAspectRatioMode.None)
			{
				float num = DesiredAspectRatio.x / DesiredAspectRatio.y;
				ePlane ePlane2 = ePlane.x;
				switch (AspectRatioControl)
				{
				case eAspectRatioMode.Auto:
					ePlane2 = ((!flag) ? ePlane.y : ePlane.x);
					break;
				case eAspectRatioMode.HeightControlsWidth:
					ePlane2 = ePlane.y;
					break;
				}
				vector = ((ePlane2 != ePlane.x) ? new Vector2(vector.y * num, vector.y) : new Vector2(vector.x, vector.x / num));
			}
			vector = new Vector2(Mathf.Clamp(vector.x, MinSize.x, (MaxSize.x > 0f) ? MaxSize.x : float.MaxValue), Mathf.Clamp(vector.y, MinSize.y, (MaxSize.y > 0f) ? MaxSize.y : float.MaxValue));
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, vector.x);
			rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, vector.y);
			if (KeepWithinParent)
			{
				(rectTransform.parent as RectTransform).GetWorldCorners(m_parentCorners);
				for (int i = 0; i < 4; i++)
				{
					m_parentCorners[i] = rectTransform.InverseTransformPoint(m_parentCorners[i]);
				}
				rectTransform.GetLocalCorners(m_thisCorners);
				float num2 = m_thisCorners[0].x - m_parentCorners[0].x;
				float num3 = m_parentCorners[2].x - m_thisCorners[2].x;
				float num4 = m_parentCorners[2].y - m_thisCorners[2].y;
				float num5 = m_thisCorners[0].y - m_parentCorners[0].y;
				if (num2 < 0f || num3 < 0f || num4 < 0f || num5 < 0f)
				{
					if (AspectRatioControl != eAspectRatioMode.None)
					{
						bool num6 = flag && !flag2;
						bool flag5 = flag2 && !flag;
						if (num6)
						{
							num4 *= 2f;
							num5 *= 2f;
						}
						else if (flag5)
						{
							num2 *= 2f;
							num3 *= 2f;
						}
					}
					if (num2 < 0f)
					{
						vector.x += num2;
					}
					if (num3 < 0f)
					{
						vector.x += num3;
					}
					if (num4 < 0f)
					{
						vector.y += num4;
					}
					if (num5 < 0f)
					{
						vector.y += num5;
					}
					rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, vector.x);
					rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, vector.y);
				}
			}
			if (m_layoutElement != null)
			{
				m_layoutElement.preferredWidth = vector.x;
				m_layoutElement.preferredHeight = vector.y;
			}
			OnResizeUpdate.Invoke();
		}

		private Vector2 GetResizePivot(eResizeListenerType resizeListenerType)
		{
			return resizeListenerType switch
			{
				eResizeListenerType.Right => uResize_Vectors.Left, 
				eResizeListenerType.Left => uResize_Vectors.Right, 
				eResizeListenerType.Bottom => uResize_Vectors.Top, 
				eResizeListenerType.BottomRight => uResize_Vectors.TopLeft, 
				eResizeListenerType.BottomLeft => uResize_Vectors.TopRight, 
				eResizeListenerType.TopLeft => uResize_Vectors.BottomRight, 
				eResizeListenerType.TopRight => uResize_Vectors.BottomLeft, 
				eResizeListenerType.Top => uResize_Vectors.Bottom, 
				_ => Vector2.zero, 
			};
		}

		private void SetPivot(Vector2 pivot)
		{
			if (!(rectTransform == null))
			{
				SetPivotSmart(pivot.x, 0);
				SetPivotSmart(pivot.y, 1);
			}
		}

		private void SetPivotSmart(float value, int axis)
		{
			Vector3 rectReferenceCorner = GetRectReferenceCorner();
			Vector2 pivot = rectTransform.pivot;
			pivot[axis] = value;
			rectTransform.pivot = pivot;
			Vector3 vector = GetRectReferenceCorner() - rectReferenceCorner;
			rectTransform.anchoredPosition -= (Vector2)vector;
			Vector3 position = rectTransform.transform.position;
			position.z -= vector.z;
			rectTransform.transform.position = position;
		}

		private Vector3 GetRectReferenceCorner()
		{
			rectTransform.GetWorldCorners(s_Corners);
			if ((bool)rectTransform.parent)
			{
				return rectTransform.parent.InverseTransformPoint(s_Corners[0]);
			}
			return s_Corners[0];
		}

		private void SetAnchors(Vector2 newAnchorMin, Vector2 newAnchorMax)
		{
			SetAnchorSmart(newAnchorMin.x, 0, isMax: false);
			SetAnchorSmart(newAnchorMin.y, 1, isMax: false);
			SetAnchorSmart(newAnchorMax.x, 0, isMax: true);
			SetAnchorSmart(newAnchorMax.y, 1, isMax: true);
		}

		private bool ShouldDoIntSnapping()
		{
			if (canvas != null)
			{
				return canvas.renderMode != RenderMode.WorldSpace;
			}
			return false;
		}

		private static float Round(float value)
		{
			return Mathf.Floor(0.5f + value);
		}

		public void SetAnchorSmart(float value, int axis, bool isMax)
		{
			RectTransform rectTransform = this.rectTransform.parent as RectTransform;
			value = Mathf.Clamp01(value);
			float num = 0f;
			float num2 = 0f;
			float num3 = (isMax ? this.rectTransform.anchorMax[axis] : this.rectTransform.anchorMin[axis]);
			num = (value - num3) * rectTransform.rect.size[axis];
			float num4 = 0f;
			if (ShouldDoIntSnapping())
			{
				num4 = Mathf.Round(num) - num;
			}
			num += num4;
			num2 = (isMax ? (num * this.rectTransform.pivot[axis]) : (num * (1f - this.rectTransform.pivot[axis])));
			if (isMax)
			{
				Vector2 anchorMax = this.rectTransform.anchorMax;
				anchorMax[axis] = value;
				this.rectTransform.anchorMax = anchorMax;
				Vector2 anchorMin = this.rectTransform.anchorMin;
				this.rectTransform.anchorMin = anchorMin;
			}
			else
			{
				Vector2 anchorMin2 = this.rectTransform.anchorMin;
				anchorMin2[axis] = value;
				this.rectTransform.anchorMin = anchorMin2;
				Vector2 anchorMax2 = this.rectTransform.anchorMax;
				this.rectTransform.anchorMax = anchorMax2;
			}
			Vector2 anchoredPosition = this.rectTransform.anchoredPosition;
			anchoredPosition[axis] -= num2;
			this.rectTransform.anchoredPosition = anchoredPosition;
			Vector2 sizeDelta = this.rectTransform.sizeDelta;
			sizeDelta[axis] += num * (float)((!isMax) ? 1 : (-1));
			this.rectTransform.sizeDelta = sizeDelta;
		}
	}
}
