using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UIAutoScaleToParent : MonoBehaviour
{
	public Vector2 referenceSize = new Vector2(1920f, 1080f);

	public bool matchWidth = true;

	public bool matchHeight = true;

	private RectTransform _rect;

	private RectTransform _parent;

	private void Awake()
	{
		_rect = GetComponent<RectTransform>();
		_parent = _rect.parent as RectTransform;
	}

	private void LateUpdate()
	{
		if (!(_parent == null))
		{
			Vector2 size = _parent.rect.size;
			float a = (matchWidth ? (size.x / referenceSize.x) : 1f);
			float b = (matchHeight ? (size.y / referenceSize.y) : 1f);
			float num = Mathf.Min(a, b);
			_rect.localScale = new Vector3(num, num, 1f);
			_rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, referenceSize.x);
			_rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, referenceSize.y);
		}
	}
}
