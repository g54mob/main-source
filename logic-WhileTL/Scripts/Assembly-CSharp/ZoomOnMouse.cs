using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoomOnMouse : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	public float K = 1.1f;

	private Vector3 _scale;

	private bool _isOver;

	private Selectable _s;

	private void Start()
	{
		_scale = base.transform.localScale;
		_s = GetComponent<Selectable>();
		if (_s == null)
		{
			Object.Destroy(this);
		}
	}

	public void UpScale()
	{
		if (!_isOver)
		{
			_isOver = true;
			base.transform.localScale = _scale * K;
		}
	}

	public void DownScale()
	{
		if (_isOver)
		{
			_isOver = false;
			base.transform.localScale = _scale;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!(_s == null) && _s.interactable && !_isOver)
		{
			_isOver = true;
			base.transform.localScale = _scale * K;
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (_isOver)
		{
			_isOver = false;
			base.transform.localScale = _scale;
		}
	}

	private void OnDisable()
	{
		OnPointerExit(null);
	}
}
