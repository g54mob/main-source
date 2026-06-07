using System;
using UnityEngine;

namespace DigitalLegacy.UI.Sizing
{
	[RequireComponent(typeof(uResize))]
	[AddComponentMenu("UI/uResize Cursor Controller")]
	public class uResize_CursorController : MonoBehaviour
	{
		[Header("Initialization")]
		public bool SetCursorOnStart;

		[Header("Cursor Types")]
		public Texture2D RegularCursor;

		public Texture2D HorizontalCursor;

		public Texture2D VerticalCursor;

		public Texture2D TopLeftCursor;

		public Texture2D TopRightCursor;

		public Texture2D BottomLeftCursor;

		public Texture2D BottomRightCursor;

		[Header("Modes & Hotspots")]
		public CursorMode CursorMode;

		public Vector2 RegularCursorHotspot = Vector2.zero;

		public Vector2 ResizeCursorHotspot = new Vector2(16f, 16f);

		private bool m_resizeInProgress;

		private eResizeListenerType m_resizeType;

		private eResizeListenerType? m_pointerOverResizeType;

		public Action OnReturnToRegularCursor;

		private void Start()
		{
			uResize component = GetComponent<uResize>();
			component.OnPointerEnterResizeListener.AddListener(OnPointerEnterListener);
			component.OnPointerExitResizeListener.AddListener(OnPointerExitListener);
			component.OnResizeBegin.AddListener(OnResizeBegin);
			component.OnResizeEnd.AddListener(OnResizeEnd);
			if (SetCursorOnStart)
			{
				SetCursor(RegularCursor, regular: true);
			}
		}

		private void OnResizeBegin(eResizeListenerType type)
		{
			m_resizeInProgress = true;
			m_resizeType = type;
		}

		private void OnResizeEnd()
		{
			m_resizeInProgress = false;
			if (m_pointerOverResizeType.HasValue)
			{
				SetCursor(GetCursorForType(m_pointerOverResizeType.Value));
			}
			else
			{
				SetCursor(RegularCursor, regular: true);
			}
		}

		private void OnPointerEnterListener(eResizeListenerType type)
		{
			m_pointerOverResizeType = type;
			if (!m_resizeInProgress)
			{
				SetCursor(GetCursorForType(type));
			}
		}

		private Texture2D GetCursorForType(eResizeListenerType type)
		{
			Texture2D result = RegularCursor;
			switch (type)
			{
			case eResizeListenerType.Top:
			case eResizeListenerType.Bottom:
				result = VerticalCursor;
				break;
			case eResizeListenerType.Left:
			case eResizeListenerType.Right:
				result = HorizontalCursor;
				break;
			case eResizeListenerType.TopLeft:
				result = TopLeftCursor;
				break;
			case eResizeListenerType.TopRight:
				result = TopRightCursor;
				break;
			case eResizeListenerType.BottomLeft:
				result = BottomLeftCursor;
				break;
			case eResizeListenerType.BottomRight:
				result = BottomRightCursor;
				break;
			}
			return result;
		}

		private void OnPointerExitListener(eResizeListenerType type)
		{
			m_pointerOverResizeType = null;
			if (!m_resizeInProgress)
			{
				SetCursor(RegularCursor, regular: true);
			}
		}

		private void SetCursor(Texture2D cursor, bool regular = false)
		{
			if (base.enabled)
			{
				Cursor.SetCursor(cursor, regular ? RegularCursorHotspot : ResizeCursorHotspot, CursorMode);
				if (regular && OnReturnToRegularCursor != null)
				{
					OnReturnToRegularCursor();
				}
			}
		}

		private void Update()
		{
			if (m_resizeInProgress)
			{
				SetCursor(GetCursorForType(m_resizeType));
			}
		}
	}
}
