using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(RectTransform))]
public class WorldspaceTextResizer : MonoBehaviour
{
	public SpriteRenderer parentRenderer;

	private RectTransform _rectTransform;

	public float verticalPadding;

	public float horizontalPadding;

	private void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
	}

	private void Update()
	{
		_rectTransform.sizeDelta = parentRenderer.size - new Vector2(horizontalPadding, verticalPadding);
	}
}
