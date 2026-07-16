using UnityEngine;
using UnityEngine.InputSystem;

public class SplashParallax : MonoBehaviour
{
	[SerializeField]
	private float sensitivity = 0.1f;

	private RectTransform imageRectTransform;

	private Vector2 imageStartPos;

	private Rect screenBounds;

	private void Awake()
	{
		imageRectTransform = GetComponent<RectTransform>();
		imageStartPos = imageRectTransform.anchoredPosition;
	}

	private void Start()
	{
		screenBounds = Screen.safeArea;
	}

	private void Update()
	{
		Vector2 vector = Mouse.current.position.ReadValue();
		Vector2 vector2 = new Vector2(Mathf.Clamp((vector.x - screenBounds.center.x) / screenBounds.width * 2f, -1f, 1f), Mathf.Clamp((vector.y - screenBounds.center.y) / screenBounds.height * 2f, -1f, 1f));
		Vector2 anchoredPosition = imageStartPos - vector2 * sensitivity;
		imageRectTransform.anchoredPosition = anchoredPosition;
	}
}
