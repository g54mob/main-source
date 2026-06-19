using System;
using Loxodon.Framework.Contexts;
using UI.Inventory.Describer;
using UnityEngine;
using UnityEngine.UI;

namespace UI.HUD
{
	public class WorldUIOutliner : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _frame;

		[SerializeField]
		private Canvas _canvas;

		[SerializeField]
		private float _smoothSpeed = 10f;

		[SerializeField]
		private Vector2 _sizeOffset = Vector2.zero;

		[SerializeField]
		private float _screenPadding = 10f;

		private Collider _target;

		private Vector2 _targetPosition;

		private Vector2 _targetSize;

		private Vector2 _currentVelocityPos;

		private Vector2 _currentVelocitySize;

		[SerializeField]
		private float _topRightPopupHeight;

		[SerializeField]
		private float _bottomLeftPopupHeight;

		[SerializeField]
		private RectTransform _infoCursorsRect;

		private bool _hasTopRightPopup;

		private bool _hasBottomLeftPopup;

		private float _topRightPopupWidth;

		private InfoCursorsViewModel _infoCursorsViewModel;

		private InventoryDescriberViewModel _inventoryDescriberViewModel;

		private void Start()
		{
		}

		private void OnEnable()
		{
			ApplicationContext applicationContext = Context.GetApplicationContext();
			_infoCursorsViewModel = applicationContext.GetService<InfoCursorsViewModel>();
			_inventoryDescriberViewModel = applicationContext.GetService<InventoryDescriberViewModel>();
			_inventoryDescriberViewModel.Enabled.ValueChanged += OnDescriberEnabledValueChanged;
		}

		private void OnDisable()
		{
			_inventoryDescriberViewModel.Enabled.ValueChanged -= OnDescriberEnabledValueChanged;
		}

		private void Update()
		{
			_hasTopRightPopup = _infoCursorsViewModel.Visible;
			_topRightPopupWidth = ((_hasTopRightPopup && _infoCursorsRect != null) ? _infoCursorsRect.rect.width : 0f);
		}

		private void OnDescriberEnabledValueChanged(object sender, EventArgs e)
		{
			_hasBottomLeftPopup = _inventoryDescriberViewModel.Enabled.Value;
		}

		public void EnableHighlight()
		{
			_frame.gameObject.SetActive(value: true);
		}

		public void DisableHighlight()
		{
			_frame.gameObject.SetActive(value: false);
		}

		public void SetTopRightPopupHeight(float height)
		{
			_topRightPopupHeight = height;
			_hasTopRightPopup = height > 0f;
		}

		public void SetBottomLeftPopupHeight(float height)
		{
			_bottomLeftPopupHeight = height;
			_hasBottomLeftPopup = height > 0f;
		}

		public void ClearPopups()
		{
			_topRightPopupHeight = 0f;
			_bottomLeftPopupHeight = 0f;
			_hasTopRightPopup = false;
			_hasBottomLeftPopup = false;
		}

		public void UpdateFrame(Bounds collider, Camera camera)
		{
			if (!camera)
			{
				return;
			}
			Vector3 center = collider.center;
			Vector3 extents = collider.extents;
			Vector2 vector = new Vector2(float.MaxValue, float.MaxValue);
			Vector2 vector2 = new Vector2(float.MinValue, float.MinValue);
			Vector3[] obj = new Vector3[8]
			{
				center + new Vector3(0f - extents.x, 0f - extents.y, 0f - extents.z),
				center + new Vector3(extents.x, 0f - extents.y, 0f - extents.z),
				center + new Vector3(0f - extents.x, extents.y, 0f - extents.z),
				center + new Vector3(extents.x, extents.y, 0f - extents.z),
				center + new Vector3(0f - extents.x, 0f - extents.y, extents.z),
				center + new Vector3(extents.x, 0f - extents.y, extents.z),
				center + new Vector3(0f - extents.x, extents.y, extents.z),
				center + new Vector3(extents.x, extents.y, extents.z)
			};
			bool flag = false;
			Vector3[] array = obj;
			foreach (Vector3 position in array)
			{
				Vector3 vector3 = camera.WorldToScreenPoint(position);
				if (!(vector3.z < 0f) && !float.IsNaN(vector3.x) && !float.IsNaN(vector3.y) && !float.IsInfinity(vector3.x) && !float.IsInfinity(vector3.y))
				{
					vector = Vector2.Min(vector, vector3);
					vector2 = Vector2.Max(vector2, vector3);
					flag = true;
				}
			}
			if (!flag || vector.x == float.MaxValue || vector2.x == float.MinValue)
			{
				return;
			}
			Vector2 screenPoint = (vector + vector2) * 0.5f;
			Vector2 vector4 = vector2 - vector;
			if (!float.IsNaN(screenPoint.x) && !float.IsNaN(screenPoint.y) && !float.IsNaN(vector4.x) && !float.IsNaN(vector4.y) && !float.IsInfinity(screenPoint.x) && !float.IsInfinity(screenPoint.y) && !float.IsInfinity(vector4.x) && !float.IsInfinity(vector4.y))
			{
				RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvas.transform as RectTransform, screenPoint, (_canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : camera, out var localPoint);
				if (!float.IsNaN(localPoint.x) && !float.IsNaN(localPoint.y) && !float.IsInfinity(localPoint.x) && !float.IsInfinity(localPoint.y))
				{
					_targetPosition = localPoint;
					_targetSize = vector4 + _sizeOffset;
					ApplyConstraints();
					ApplySmoothAnimation();
				}
			}
		}

		public void UpdateFrame(Bounds collider, Camera renderCamera, RawImage rawImage, Vector2 posOffset)
		{
			if (!renderCamera || !rawImage)
			{
				return;
			}
			Vector3 center = collider.center;
			Vector3 extents = collider.extents;
			Vector2 lhs = new Vector2(float.MaxValue, float.MaxValue);
			Vector2 lhs2 = new Vector2(float.MinValue, float.MinValue);
			Vector3[] obj = new Vector3[8]
			{
				center + new Vector3(0f - extents.x, 0f - extents.y, 0f - extents.z),
				center + new Vector3(extents.x, 0f - extents.y, 0f - extents.z),
				center + new Vector3(0f - extents.x, extents.y, 0f - extents.z),
				center + new Vector3(extents.x, extents.y, 0f - extents.z),
				center + new Vector3(0f - extents.x, 0f - extents.y, extents.z),
				center + new Vector3(extents.x, 0f - extents.y, extents.z),
				center + new Vector3(0f - extents.x, extents.y, extents.z),
				center + new Vector3(extents.x, extents.y, extents.z)
			};
			bool flag = false;
			Vector3[] array = obj;
			foreach (Vector3 position in array)
			{
				Vector3 vector = renderCamera.WorldToViewportPoint(position);
				if (!(vector.z < 0f) && !float.IsNaN(vector.x) && !float.IsNaN(vector.y) && !float.IsInfinity(vector.x) && !float.IsInfinity(vector.y))
				{
					lhs = Vector2.Min(lhs, new Vector2(vector.x, vector.y));
					lhs2 = Vector2.Max(lhs2, new Vector2(vector.x, vector.y));
					flag = true;
				}
			}
			if (flag && lhs.x != float.MaxValue && lhs2.x != float.MinValue)
			{
				Rect rect = rawImage.rectTransform.rect;
				Vector2 vector2 = new Vector2(lhs.x * rect.width + rect.xMin, lhs.y * rect.height + rect.yMin);
				Vector2 vector3 = new Vector2(lhs2.x * rect.width + rect.xMin, lhs2.y * rect.height + rect.yMin);
				Vector2 vector4 = (vector2 + vector3) * 0.5f;
				Vector2 vector5 = vector3 - vector2;
				if (!float.IsNaN(vector4.x) && !float.IsNaN(vector4.y) && !float.IsNaN(vector5.x) && !float.IsNaN(vector5.y) && !float.IsInfinity(vector4.x) && !float.IsInfinity(vector4.y) && !float.IsInfinity(vector5.x) && !float.IsInfinity(vector5.y))
				{
					_targetPosition = vector4 + posOffset;
					_targetSize = vector5 + _sizeOffset;
					ApplyConstraints();
					ApplySmoothAnimation();
				}
			}
		}

		private void ApplyConstraints()
		{
			RectTransform rectTransform = _canvas.transform as RectTransform;
			if (rectTransform == null)
			{
				return;
			}
			Vector2 size = rectTransform.rect.size;
			if (float.IsNaN(size.x) || float.IsNaN(size.y) || size.x <= 0f || size.y <= 0f || float.IsNaN(_targetPosition.x) || float.IsNaN(_targetPosition.y) || float.IsNaN(_targetSize.x) || float.IsNaN(_targetSize.y))
			{
				return;
			}
			Vector2 vector = _targetSize * 0.5f;
			Vector2 vector2 = new Vector2(size.x * 0.5f - _screenPadding, size.y * 0.5f - _screenPadding);
			Vector2 vector3 = new Vector2((0f - size.x) * 0.5f + _screenPadding, (0f - size.y) * 0.5f + _screenPadding);
			if (_hasBottomLeftPopup && _targetSize.y < _bottomLeftPopupHeight)
			{
				_targetSize.y = _bottomLeftPopupHeight;
				vector.y = _targetSize.y * 0.5f;
			}
			float num = size.x - _screenPadding * 2f;
			float num2 = size.y - _screenPadding * 2f;
			if (_targetSize.x > num)
			{
				_targetSize.x = num;
				vector.x = _targetSize.x * 0.5f;
			}
			if (_targetSize.y > num2)
			{
				_targetSize.y = num2;
				vector.y = _targetSize.y * 0.5f;
			}
			if (_targetPosition.x + vector.x > vector2.x)
			{
				_targetPosition.x = vector2.x - vector.x;
			}
			if (_targetPosition.x - vector.x < vector3.x)
			{
				_targetPosition.x = vector3.x + vector.x;
			}
			if (_targetPosition.y + vector.y > vector2.y)
			{
				_targetPosition.y = vector2.y - vector.y;
			}
			if (_targetPosition.y - vector.y < vector3.y)
			{
				_targetPosition.y = vector3.y + vector.y;
			}
			if (_hasTopRightPopup)
			{
				float num3 = _targetPosition.y + _targetSize.y * 0.5f + _topRightPopupHeight;
				if (num3 > vector2.y)
				{
					float num4 = num3 - vector2.y;
					_targetSize.y = Mathf.Max(_targetSize.y - num4, _hasBottomLeftPopup ? _bottomLeftPopupHeight : 0f);
					vector.y = _targetSize.y * 0.5f;
					if (_targetPosition.y + vector.y > vector2.y)
					{
						_targetPosition.y = vector2.y - vector.y;
					}
					if (_targetPosition.y - vector.y < vector3.y)
					{
						_targetPosition.y = vector3.y + vector.y;
					}
				}
				if (_topRightPopupWidth > 0f)
				{
					float num5 = vector2.x - _topRightPopupWidth;
					if (_targetPosition.x + vector.x > num5)
					{
						_targetPosition.x = num5 - vector.x;
					}
					if (_targetPosition.x - vector.x < vector3.x)
					{
						_targetPosition.x = vector3.x + vector.x;
					}
				}
			}
			if (_hasBottomLeftPopup)
			{
				float num6 = _targetPosition.y - _targetSize.y * 0.5f - _bottomLeftPopupHeight;
				if (num6 < vector3.y)
				{
					float num7 = vector3.y - num6;
					float num8 = _targetPosition.y + num7;
					if (num8 + vector.y <= vector2.y)
					{
						_targetPosition.y = num8;
					}
					else
					{
						_targetSize.y = Mathf.Max(_targetSize.y - num7, _bottomLeftPopupHeight);
						vector.y = _targetSize.y * 0.5f;
						float num9 = vector2.y - vector3.y - _bottomLeftPopupHeight;
						_targetPosition.y = vector3.y + _bottomLeftPopupHeight + num9 * 0.5f;
					}
				}
			}
			if (float.IsNaN(_targetPosition.x) || float.IsNaN(_targetPosition.y) || float.IsNaN(_targetSize.x) || float.IsNaN(_targetSize.y))
			{
				Debug.LogWarning("NaN detected after constraints, resetting to safe values");
				_targetPosition = Vector2.zero;
				_targetSize = new Vector2(100f, 100f);
			}
		}

		private void ApplySmoothAnimation()
		{
			if (float.IsNaN(_frame.anchoredPosition.x) || float.IsNaN(_frame.anchoredPosition.y))
			{
				_frame.anchoredPosition = _targetPosition;
				_currentVelocityPos = Vector2.zero;
			}
			else
			{
				_frame.anchoredPosition = Vector2.SmoothDamp(_frame.anchoredPosition, _targetPosition, ref _currentVelocityPos, 1f / _smoothSpeed);
			}
			if (float.IsNaN(_frame.sizeDelta.x) || float.IsNaN(_frame.sizeDelta.y))
			{
				_frame.sizeDelta = _targetSize;
				_currentVelocitySize = Vector2.zero;
			}
			else
			{
				_frame.sizeDelta = Vector2.SmoothDamp(_frame.sizeDelta, _targetSize, ref _currentVelocitySize, 1f / _smoothSpeed);
			}
		}

		public void SetSizeOffset(Vector2 offset)
		{
			_sizeOffset = offset;
		}

		public void SetSmoothSpeed(float speed)
		{
			_smoothSpeed = speed;
		}
	}
}
