using UnityEngine;

public class Collider2DRaycastFilter : MonoBehaviour, ICanvasRaycastFilter
{
	private Collider2D myCollider;

	private RectTransform rectTransform;

	private void Awake()
	{
	}

	public bool IsRaycastLocationValid(Vector2 screenPos, Camera eventCamera)
	{
		return false;
	}
}
