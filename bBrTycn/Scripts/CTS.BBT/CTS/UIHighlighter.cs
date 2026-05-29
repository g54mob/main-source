using System;
using CTS.Core.Utilities;
using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CTS
{
	public class UIHighlighter : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _arrowRectTransform;

		[SerializeField]
		private RectTransform _rectangleRectTransform;

		[SerializeField]
		private GameObject _target;

		private HighlightChain _chainTarget;

		[SerializeField]
		[Range(0f, 0.5f)]
		private float _highlighterScreenClamp = 0.5f;

		[SerializeField]
		[Range(0f, 1f)]
		private float _highlighterScreenCenterClamp;

		[SerializeField]
		private RotationSource _rotationSource;

		private Vector3 _targetPosition;

		private Rect _targetRect;

		[SerializeField]
		[Range(0.1f, 50f)]
		private float _arrowDistanceFromObjectRect = 0.1f;

		private RectTransform _targetRectTransform;

		private Image _rectangleImage;

		[SerializeField]
		private float _defaultPixelsPerUnit = 3.5f;

		private bool TargetIsUI => _targetRectTransform;

		private void Awake()
		{
			_rectangleImage = _rectangleRectTransform.GetComponent<Image>();
		}

		public void SetTarget(GameObject p_target)
		{
			_target = p_target;
			CheckTarget();
		}

		public void SetChain(HighlightChain chain)
		{
			_target = null;
			_chainTarget = chain;
		}

		public void RefreshChain()
		{
			if (_chainTarget != null)
			{
				_target = null;
				CheckTarget();
			}
		}

		private void CheckTarget()
		{
			if ((bool)_target)
			{
				if (_target.TryGetComponent<RectTransform>(out var component))
				{
					_targetRectTransform = component;
				}
				else
				{
					_targetRectTransform = null;
				}
			}
			else if (_chainTarget != null)
			{
				GameObject target = _chainTarget.GetTarget();
				if ((bool)target)
				{
					SetTarget(target);
				}
			}
		}

		private void Start()
		{
			_rectangleRectTransform.gameObject.SetActive(value: false);
			_arrowRectTransform.gameObject.SetActive(value: false);
			_arrowRectTransform.DOScale(0.2f, 0.2f).SetRelative(isRelative: true).SetLoops(-1, LoopType.Yoyo)
				.SetUpdate(isIndependentUpdate: true);
			CheckTarget();
		}

		private Rect GetScreenRect(GameObject p_target)
		{
			Vector3 center = p_target.GetComponentInChildren<Collider>().bounds.center;
			Vector3 extents = p_target.GetComponentInChildren<Collider>().bounds.extents;
			Camera main = Camera.main;
			Vector2 vector = main.WorldToScreenPoint(new Vector3(center.x - extents.x, center.y - extents.y, center.z - extents.z));
			Vector2 vector2 = vector;
			Vector2 vector3 = vector;
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			vector3 = main.WorldToScreenPoint(new Vector3(center.x + extents.x, center.y - extents.y, center.z - extents.z));
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			vector3 = main.WorldToScreenPoint(new Vector3(center.x - extents.x, center.y - extents.y, center.z + extents.z));
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			vector3 = main.WorldToScreenPoint(new Vector3(center.x + extents.x, center.y - extents.y, center.z + extents.z));
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			vector3 = main.WorldToScreenPoint(new Vector3(center.x - extents.x, center.y + extents.y, center.z - extents.z));
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			vector3 = main.WorldToScreenPoint(new Vector3(center.x + extents.x, center.y + extents.y, center.z - extents.z));
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			vector3 = main.WorldToScreenPoint(new Vector3(center.x - extents.x, center.y + extents.y, center.z + extents.z));
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			vector3 = main.WorldToScreenPoint(new Vector3(center.x + extents.x, center.y + extents.y, center.z + extents.z));
			vector = new Vector2((vector.x >= vector3.x) ? vector3.x : vector.x, (vector.y >= vector3.y) ? vector3.y : vector.y);
			vector2 = new Vector2((vector2.x <= vector3.x) ? vector3.x : vector2.x, (vector2.y <= vector3.y) ? vector3.y : vector2.y);
			return new Rect(vector.x, vector.y, vector2.x - vector.x, vector2.y - vector.y);
		}

		private void Update()
		{
			if ((bool)_target)
			{
				if (_target.activeInHierarchy)
				{
					BoundsUpdate();
				}
				RectangleUpdate();
				ArrowPositionUpdate();
				ArrowRotationUpdate();
				float num = 1080f / (float)Screen.height;
				_rectangleImage.pixelsPerUnitMultiplier = _defaultPixelsPerUnit * num;
			}
		}

		private void BoundsUpdate()
		{
			Rect targetRect;
			if (TargetIsUI)
			{
				Vector3 localScale = _targetRectTransform.localScale;
				_targetRectTransform.localScale = new Vector3(Mathf.Abs(_targetRectTransform.localScale.x), Mathf.Abs(_targetRectTransform.localScale.y), Mathf.Abs(_targetRectTransform.localScale.z));
				targetRect = _targetRectTransform.GetWorldRect();
				_targetRectTransform.localScale = localScale;
			}
			else
			{
				targetRect = GetScreenRect(_target);
			}
			_targetRect = targetRect;
		}

		private void RectangleUpdate()
		{
			_rectangleRectTransform.gameObject.SetActive(_target.activeInHierarchy);
			_rectangleRectTransform.position = _targetRect.center;
			_rectangleRectTransform.sizeDelta = _targetRect.size;
		}

		private void ArrowRotationUpdate()
		{
			Vector3 vector = Vector3.zero;
			switch (_rotationSource)
			{
			case RotationSource.MousePosition:
				vector = Mouse.current.position.ReadValue();
				break;
			case RotationSource.ScreenCenter:
				vector = new Vector3((float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
				break;
			}
			Vector2 vector2 = _targetPosition - vector;
			_arrowRectTransform.rotation = Quaternion.Euler(0f, 0f, Vector3.SignedAngle(vector2, Vector3.up, Vector3.back));
		}

		private void ArrowPositionUpdate()
		{
			if ((bool)_targetRectTransform)
			{
				_targetPosition = _targetRectTransform.position;
			}
			else
			{
				_targetPosition = Camera.main.WorldToScreenPoint(_target.transform.position);
			}
			_arrowRectTransform.position = new Vector3((float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
			Vector2 result = default(Vector2);
			if (LineRectIntersection(_arrowRectTransform.position, _targetRect.center, _targetRect, ref result))
			{
				_arrowRectTransform.position = result;
				if (!TargetIsUI)
				{
					float num = (float)Screen.width * 0.5f;
					float num2 = (float)Screen.height * 0.5f;
					float val = Math.Abs(result.x - num) / num;
					float val2 = Math.Abs(result.y - num2) / num2;
					if (Math.Max(val, val2) < _highlighterScreenCenterClamp)
					{
						_arrowRectTransform.gameObject.SetActive(value: false);
						return;
					}
				}
				Vector2 anchoredPosition = _arrowRectTransform.anchoredPosition;
				float x = anchoredPosition.x;
				x = Mathf.Clamp(x, (float)(-Screen.width) * _highlighterScreenClamp, (float)Screen.width * _highlighterScreenClamp);
				anchoredPosition.x = x;
				float y = anchoredPosition.y;
				y = Mathf.Clamp(y, (float)(-Screen.height) * _highlighterScreenClamp, (float)Screen.height * _highlighterScreenClamp);
				anchoredPosition.y = y;
				_arrowRectTransform.anchoredPosition = anchoredPosition;
				_arrowRectTransform.gameObject.SetActive(_target.activeInHierarchy);
			}
			else
			{
				_arrowRectTransform.gameObject.SetActive(value: false);
			}
		}

		private static bool LineRectIntersection(Vector2 lineStartPoint, Vector2 lineEndPoint, Rect rectangle, ref Vector2 result)
		{
			Vector2 vector = ((lineStartPoint.x <= lineEndPoint.x) ? lineStartPoint : lineEndPoint);
			Vector2 vector2 = ((lineStartPoint.x <= lineEndPoint.x) ? lineEndPoint : lineStartPoint);
			Vector2 vector3 = ((lineStartPoint.y <= lineEndPoint.y) ? lineStartPoint : lineEndPoint);
			Vector2 vector4 = ((lineStartPoint.y <= lineEndPoint.y) ? lineEndPoint : lineStartPoint);
			double num = rectangle.xMax;
			double num2 = rectangle.xMin;
			double num3 = rectangle.yMax;
			double num4 = rectangle.yMin;
			if ((double)vector.x <= num && num <= (double)vector2.x)
			{
				double num5 = (vector2.y - vector.y) / (vector2.x - vector.x);
				double num6 = (num - (double)vector.x) * num5 + (double)vector.y;
				if ((double)vector3.y <= num6 && num6 <= (double)vector4.y && num4 <= num6 && num6 <= num3)
				{
					result = new Vector2((float)num, (float)num6);
					return true;
				}
			}
			if ((double)vector.x <= num2 && num2 <= (double)vector2.x)
			{
				double num7 = (vector2.y - vector.y) / (vector2.x - vector.x);
				double num8 = (num2 - (double)vector.x) * num7 + (double)vector.y;
				if ((double)vector3.y <= num8 && num8 <= (double)vector4.y && num4 <= num8 && num8 <= num3)
				{
					result = new Vector2((float)num2, (float)num8);
					return true;
				}
			}
			if ((double)vector3.y <= num3 && num3 <= (double)vector4.y)
			{
				double num9 = (vector4.x - vector3.x) / (vector4.y - vector3.y);
				double num10 = (num3 - (double)vector3.y) * num9 + (double)vector3.x;
				if ((double)vector.x <= num10 && num10 <= (double)vector2.x && num2 <= num10 && num10 <= num)
				{
					result = new Vector2((float)num10, (float)num3);
					return true;
				}
			}
			if ((double)vector3.y <= num4 && num4 <= (double)vector4.y)
			{
				double num11 = (vector4.x - vector3.x) / (vector4.y - vector3.y);
				double num12 = (num4 - (double)vector3.y) * num11 + (double)vector3.x;
				if ((double)vector.x <= num12 && num12 <= (double)vector2.x && num2 <= num12 && num12 <= num)
				{
					result = new Vector2((float)num12, (float)num4);
					return true;
				}
			}
			return false;
		}
	}
}
