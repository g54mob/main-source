using UnityEngine;
using UnityEngine.InputSystem;

namespace Michsky.DreamOS
{
	[RequireComponent(typeof(RectTransform))]
	[AddComponentMenu("DreamOS/Animation/Rect Depth")]
	public class RectDepth : MonoBehaviour
	{
		[Header("Settings")]
		[SerializeField]
		[Range(0.05f, 1f)]
		private float smoothness = 0.25f;

		[SerializeField]
		[Range(0.5f, 10f)]
		private float multiplier = 2f;

		[SerializeField]
		[Range(1f, 2f)]
		private float maxRectScale = 1f;

		[Header("Resources")]
		[SerializeField]
		private RectTransform targetRect;

		[SerializeField]
		private Canvas targetCanvas;

		[SerializeField]
		private Camera targetCamera;

		private Vector2 mousePos;

		private void Awake()
		{
			if (targetRect == null)
			{
				targetRect = GetComponent<RectTransform>();
			}
			if (targetCanvas == null)
			{
				targetCanvas = GetComponentInParent<Canvas>();
			}
			if (targetCamera == null)
			{
				targetCamera = Camera.main;
			}
			targetRect.transform.localScale = new Vector3(maxRectScale, maxRectScale, maxRectScale);
		}

		private void OnEnable()
		{
			targetRect.anchoredPosition = new Vector2(0f, 0f);
		}

		private void Update()
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(targetCanvas.transform as RectTransform, Mouse.current.position.ReadValue(), targetCamera, out mousePos);
			targetRect.anchoredPosition = Vector2.Lerp(targetRect.anchoredPosition, targetCanvas.transform.TransformPoint(mousePos) * multiplier, smoothness / (multiplier * 4f));
		}
	}
}
