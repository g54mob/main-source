using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillTreeInnerPanel : MonoBehaviour
{
	private RectTransform rectTransform;

	private bool _isDragging;

	private Vector3 _dragOrigin;

	public InputActionReference InputRef;

	public InputActionReference InputShiftRef;

	public InputActionReference InputZoomInRef;

	public InputActionReference InputZoomOutRef;

	public List<GameObject> RedPathObjects;

	public List<GameObject> BookPathObjects;

	public List<GameObject> HiddenUntilParent;

	private float _minZoom = 0.5f;

	private float _maxZoom = 2f;

	private float _zoomSpeed = 0.1f;

	private float _zoomTo = 1f;

	private void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		_zoomTo = base.transform.localScale.x;
	}

	private void Update()
	{
		if (GameController.Instance.RedPoint.TotalAmount == 0)
		{
			foreach (GameObject redPathObject in RedPathObjects)
			{
				redPathObject.SetActive(value: false);
			}
		}
		else
		{
			foreach (GameObject redPathObject2 in RedPathObjects)
			{
				redPathObject2.SetActive(value: true);
			}
		}
		if (GameController.Instance.Book.TotalAmount == 0)
		{
			foreach (GameObject bookPathObject in BookPathObjects)
			{
				bookPathObject.SetActive(value: false);
			}
		}
		else
		{
			foreach (GameObject bookPathObject2 in BookPathObjects)
			{
				bookPathObject2.SetActive(value: true);
			}
		}
		foreach (GameObject item in HiddenUntilParent)
		{
			if (item.GetComponent<SkillTreeLine>() != null)
			{
				if (!item.GetComponent<SkillTreeLine>().ParentIcon.IsActivated())
				{
					item.SetActive(value: false);
				}
				else
				{
					item.SetActive(value: true);
				}
			}
			else if (item.GetComponent<SkillTreeIcon2>() != null)
			{
				if (!item.GetComponent<SkillTreeIcon2>().ParentIcon.IsActivated())
				{
					item.SetActive(value: false);
				}
				else
				{
					item.SetActive(value: true);
				}
			}
		}
		if (!(rectTransform != null))
		{
			return;
		}
		if (InputZoomInRef.action.IsPressed())
		{
			if (_zoomTo < _maxZoom)
			{
				if (InputShiftRef.action.inProgress)
				{
					_zoomTo += _zoomSpeed / 3f;
				}
				else
				{
					_zoomTo += _zoomSpeed / 6f;
				}
			}
		}
		else if (InputZoomOutRef.action.IsPressed() && _zoomTo > _minZoom)
		{
			if (InputShiftRef.action.inProgress)
			{
				_zoomTo -= _zoomSpeed / 3f;
			}
			else
			{
				_zoomTo -= _zoomSpeed / 6f;
			}
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
		{
			if (_zoomTo < _maxZoom)
			{
				_zoomTo += _zoomSpeed;
			}
		}
		else if (Input.GetAxis("Mouse ScrollWheel") < 0f && _zoomTo > _minZoom)
		{
			_zoomTo -= _zoomSpeed;
		}
		if (base.transform.localScale.x != _zoomTo)
		{
			float num = _zoomTo - base.transform.localScale.x;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, Camera.main, out var localPoint);
			if (MathF.Abs(num) < num * 6f * Time.deltaTime)
			{
				base.transform.localScale = new Vector3(_zoomTo, _zoomTo, 1f);
			}
			else
			{
				base.transform.localScale += new Vector3(num * 6f * Time.deltaTime, num * 6f * Time.deltaTime, 1f);
			}
			Vector3 position = rectTransform.TransformPoint(localPoint);
			Vector2 vector = Camera.main.WorldToScreenPoint(position);
			rectTransform.anchoredPosition -= (vector - (Vector2)Input.mousePosition) / 2f;
			rectTransform.anchoredPosition = new Vector2(Mathf.Clamp(rectTransform.anchoredPosition.x, -512f, 512f), Mathf.Clamp(rectTransform.anchoredPosition.y, -512f, 512f));
		}
		Vector2 vector2 = InputRef.action.ReadValue<Vector2>();
		if (vector2 != Vector2.zero)
		{
			Vector3 vector3 = Camera.main.ScreenToViewportPoint(vector2);
			Vector2 vector4 = new Vector2(vector3.x * 1000f, vector3.y * 1000f);
			if (InputShiftRef.action.inProgress)
			{
				vector4 *= 3f;
			}
			rectTransform.anchoredPosition -= vector4;
			rectTransform.anchoredPosition = new Vector2(Mathf.Clamp(rectTransform.anchoredPosition.x, -512f, 512f), Mathf.Clamp(rectTransform.anchoredPosition.y, -512f, 512f));
		}
		if ((Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) && !_isDragging)
		{
			_isDragging = true;
			_dragOrigin = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2))
		{
			_isDragging = false;
		}
		if (_isDragging)
		{
			Vector3 vector5 = _dragOrigin - Input.mousePosition;
			Vector2 vector6 = new Vector2(vector5.x, vector5.y);
			rectTransform.anchoredPosition -= vector6;
			rectTransform.anchoredPosition = new Vector2(Mathf.Clamp(rectTransform.anchoredPosition.x, -512f, 512f), Mathf.Clamp(rectTransform.anchoredPosition.y, -512f, 512f));
			_dragOrigin = Input.mousePosition;
		}
	}

	public void ResetPosition()
	{
		GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ui_nodepanel_option_click);
		rectTransform.anchoredPosition = new Vector2(0f, 0f);
		_zoomTo = 1f;
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}
}
