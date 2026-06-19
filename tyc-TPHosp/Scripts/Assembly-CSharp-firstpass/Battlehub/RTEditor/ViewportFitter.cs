using UnityEngine;
using UnityEngine.Events;

namespace Battlehub.RTEditor
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	public class ViewportFitter : MonoBehaviour
	{
		public UnityEvent ViewportRectChanged;

		private RectTransform m_viewport;

		private Vector3 m_viewportPosition;

		private float m_viewportWidth;

		private float m_viewportHeight;

		public Camera Camera;

		private void Awake()
		{
			m_viewport = GetComponent<RectTransform>();
			if (Camera == null)
			{
				Camera = Camera.main;
			}
			if (Camera == null)
			{
				Debug.LogWarning("Set Camera");
				return;
			}
			Canvas componentInParent = m_viewport.GetComponentInParent<Canvas>();
			if (componentInParent == null)
			{
				base.gameObject.SetActive(value: false);
			}
			else if (componentInParent.renderMode != RenderMode.ScreenSpaceOverlay)
			{
				base.gameObject.SetActive(value: false);
				Debug.LogWarning("ViewportFitter requires canvas.renderMode -> RenderMode.ScreenSpaceOverlay");
			}
			else
			{
				Camera.pixelRect = new Rect(new Vector2(0f, 0f), new Vector2(Screen.width, Screen.height));
			}
		}

		private void OnEnable()
		{
			Rect rect = m_viewport.rect;
			UpdateViewport();
			m_viewportHeight = rect.height;
			m_viewportWidth = rect.width;
			m_viewportPosition = m_viewport.position;
		}

		private void Start()
		{
			Rect rect = m_viewport.rect;
			UpdateViewport();
			m_viewportHeight = rect.height;
			m_viewportWidth = rect.width;
			m_viewportPosition = m_viewport.position;
		}

		private void OnDisable()
		{
			if (Camera != null)
			{
				Camera.rect = new Rect(0f, 0f, 1f, 1f);
				ViewportRectChanged.Invoke();
			}
		}

		private void OnGUI()
		{
			if (m_viewport != null)
			{
				Rect rect = m_viewport.rect;
				if (m_viewportHeight != rect.height || m_viewportWidth != rect.width || m_viewportPosition != m_viewport.position)
				{
					UpdateViewport();
					m_viewportHeight = rect.height;
					m_viewportWidth = rect.width;
					m_viewportPosition = m_viewport.position;
				}
			}
		}

		private void UpdateViewport()
		{
			if (!(Camera == null))
			{
				Vector3[] array = new Vector3[4];
				m_viewport.GetWorldCorners(array);
				Camera.pixelRect = new Rect(array[0], new Vector2(array[2].x - array[0].x, array[1].y - array[0].y));
				ViewportRectChanged.Invoke();
			}
		}
	}
}
