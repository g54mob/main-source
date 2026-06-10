using UnityEngine;

public class ControllerViewRectScroll : MonoBehaviour
{
	public bool controlEnabled;

	public CustomScrollRect scrollRect;

	public float sensitivity;

	public bool ignore;

	public CanvasGroup canvasGroup;

	private ControllerViewRectScroll _previousViewRect;

	private void Awake()
	{
	}

	private void Update()
	{
	}
}
