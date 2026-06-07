using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform), typeof(Image))]
public class SelectionFrame : MonoBehaviour
{
	private RectTransform _rectTransform;

	private Image _image;

	private Vector3 _anchor = Vector3.zero;

	private Rect _rect = Rect.zero;

	private bool _selectionFrameActive;

	private void Awake()
	{
		_rectTransform = GetComponentInChildren<RectTransform>();
		_image = GetComponentInChildren<Image>(includeInactive: true);
	}

	private void LateUpdate()
	{
		if (_selectionFrameActive && Input.GetMouseButtonUp(0))
		{
			GameManager.UIManager.SelectionFrame.HideFrame();
			Debugger.Warning("Selection frame should have been hidden. failsafe activated.");
		}
	}

	public void InitializeFrame(Vector3 anchor)
	{
		_anchor = anchor;
		_selectionFrameActive = true;
	}

	public void DrawSelectionFrame(Vector3 mousePosition)
	{
		Vector2 vector = _anchor;
		Vector2 vector2 = mousePosition;
		float num = mousePosition.x - _anchor.x;
		float num2 = mousePosition.y - _anchor.y;
		if (num < 0f)
		{
			vector.x = mousePosition.x;
			vector2.x = _anchor.x;
		}
		if (num2 < 0f)
		{
			vector.y = mousePosition.y;
			vector2.y = _anchor.y;
		}
		_rect.min = base.transform.InverseTransformVector(vector);
		_rect.max = base.transform.InverseTransformVector(vector2);
		_rectTransform.position = (_anchor + mousePosition) / 2f;
		_rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _rect.width);
		_rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _rect.height);
		_image.enabled = Vector3.Distance(_anchor, mousePosition) > 12f;
	}

	public void HideFrame()
	{
		if (_selectionFrameActive)
		{
			_image.enabled = false;
			_selectionFrameActive = false;
		}
	}
}
