using System.Collections;
using ManagementScripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UIScripts
{
	public class UIMeshEventHandler : MonoBehaviour
	{
		private bool wasHoveredLastFrame;

		private bool tooltipActive;

		private bool isClick;

		private bool hasTooltip;

		private Vector2[] bounds;

		private RectTransform rt;

		private string tooltipTitle;

		private string tooltipText;

		private WaitForSecondsRealtime wait = new WaitForSecondsRealtime(0.5f);

		private Coroutine waiting;

		public UnityEvent onEnter = new UnityEvent();

		public UnityEvent onExit = new UnityEvent();

		public UnityEvent<PointerEventData> onClick = new UnityEvent<PointerEventData>();

		public UnityEvent<PointerEventData> onHover = new UnityEvent<PointerEventData>();

		private void Awake()
		{
			rt = GetComponent<RectTransform>();
		}

		public void SetBounds(Vector2[] points)
		{
			bounds = points;
		}

		public void SetTooltip(string title = null, string body = null)
		{
			if (title != null)
			{
				tooltipTitle = title;
			}
			if (body != null)
			{
				tooltipText = body;
			}
			hasTooltip = true;
		}

		public void UpdateTooltip(string title = null, string body = null)
		{
			if (title != null)
			{
				tooltipTitle = title;
			}
			if (body != null)
			{
				tooltipText = body;
			}
			if (tooltipActive)
			{
				TooltipSystem.UpdateTooltip(title, tooltipText);
			}
		}

		public bool CheckInteraction(PointerEventData eventData)
		{
			if (bounds == null)
			{
				return false;
			}
			if (!CheckPointIsInsideBounds(eventData.pointerCurrentRaycast.worldPosition))
			{
				CheckExitBounds();
				return false;
			}
			if (!wasHoveredLastFrame)
			{
				wasHoveredLastFrame = true;
				onEnter.Invoke();
				if (hasTooltip)
				{
					waiting = StartCoroutine(WaitForDelay());
				}
			}
			if (isClick && Input.GetMouseButtonUp(0))
			{
				isClick = false;
				onClick.Invoke(eventData);
			}
			else
			{
				onHover.Invoke(eventData);
			}
			if (!isClick)
			{
				isClick = Input.GetMouseButtonDown(0);
			}
			return true;
		}

		private bool CheckPointIsInsideBounds(Vector2 point)
		{
			Vector3 vector = rt.InverseTransformPoint(point);
			float y = vector.y;
			int i;
			for (i = 0; i < bounds.Length / 2 && !(y < bounds[2 * i].y); i++)
			{
			}
			if (2 * i >= bounds.Length || i < 1)
			{
				return false;
			}
			Vector2 vector2 = bounds[2 * i - 2];
			Vector2 vector3 = bounds[2 * i];
			Vector2 vector4 = bounds[2 * i - 1];
			Vector2 vector5 = bounds[2 * i + 1];
			float num = (y - vector2.y) / (vector3.y - vector2.y);
			if (vector.x >= vector2.x + num * (vector3.x - vector2.x))
			{
				return vector.x <= vector4.x + num * (vector5.x - vector4.x);
			}
			return false;
		}

		public void CheckExitBounds()
		{
			if (wasHoveredLastFrame)
			{
				onExit.Invoke();
				isClick = false;
				wasHoveredLastFrame = false;
				if (hasTooltip)
				{
					HideTooltip();
				}
				if (waiting != null)
				{
					StopCoroutine(waiting);
				}
			}
		}

		private IEnumerator WaitForDelay()
		{
			yield return wait;
			tooltipActive = true;
			TooltipSystem.Show(tooltipTitle, tooltipText);
		}

		private void HideTooltip()
		{
			TooltipSystem.Hide();
			tooltipActive = false;
		}

		private void OnDisable()
		{
			if (tooltipActive)
			{
				HideTooltip();
			}
		}
	}
}
