#define ENABLE_DEBUG_ERRORS
using UnityEngine;
using Utils;

[ExecuteAlways]
[RequireComponent(typeof(RectTransform))]
public class SizeCopierUI : MonoBehaviour
{
	[SerializeField]
	private RectTransform _objectToCopy;

	[SerializeField]
	private bool _affectWidth = true;

	[SerializeField]
	private bool _affectHeight = true;

	[SerializeField]
	private float _extraWidth;

	[SerializeField]
	private float _extraHeight;

	private RectTransform _rectTransform;

	private Vector2 _lastSize;

	private void Awake()
	{
		_rectTransform = GetComponent<RectTransform>();
		if (_objectToCopy == null)
		{
			this.LogError("SizeCopierUI: Object to copy is not assigned.", "Awake", 22);
		}
		if (_rectTransform == null)
		{
			this.LogError("SizeCopierUI: RectTransform is missing.", "Awake", 25);
		}
	}

	private void Start()
	{
		CopySize();
	}

	private void Update()
	{
		Vector2 size = _objectToCopy.rect.size;
		if (size != _lastSize)
		{
			CopySize();
			_lastSize = size;
		}
	}

	private void CopySize()
	{
		if (_affectWidth)
		{
			_rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _objectToCopy.rect.width + _extraWidth);
		}
		if (_affectHeight)
		{
			_rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _objectToCopy.rect.height + _extraHeight);
		}
	}
}
