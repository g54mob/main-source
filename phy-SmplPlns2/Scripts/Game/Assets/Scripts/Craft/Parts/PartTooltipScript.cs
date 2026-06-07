using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts
{
	public class PartTooltipScript : MonoBehaviour
	{
		[Serializable]
		private struct TooltipSizeInfo
		{
			public float Distance;

			public float FontSize;

			public float Height;

			public float Width;
		}

		private Transform _cameraTransform;

		private TextMeshPro _label;

		[SerializeField]
		private TooltipSizeInfo _maxDistanceSizeInfo;

		[SerializeField]
		private TooltipSizeInfo _minDistanceSizeInfo;

		private float _offset;

		private Vector3 _offsetDirection;

		private MeshRenderer _targetRenderer;

		private Transform _targetTransform;

		private Transform _transform;

		public bool IsXRTooltip { get; private set; }

		public string Text
		{
			get
			{
				return _label.text;
			}
			set
			{
				if (_label.text != value)
				{
					_label.text = value;
				}
			}
		}

		public bool Visible => base.gameObject.activeSelf;

		public void HideTooltip()
		{
			_targetTransform = null;
			_targetRenderer = null;
			_cameraTransform = null;
			base.gameObject.SetActive(value: false);
		}

		public void Initialize(bool isXRTooltip)
		{
			IsXRTooltip = isXRTooltip;
			HideTooltip();
		}

		public void ShowTooltip(string tooltipText, Camera camera, Transform transform, Vector3 offsetDirection, float offset)
		{
			_targetTransform = transform;
			_targetRenderer = null;
			ShowTooltip(tooltipText, camera, offsetDirection, offset);
		}

		public void ShowTooltip(string tooltipText, Camera camera, MeshRenderer renderer, Vector3 offsetDirection, float offset)
		{
			_targetRenderer = renderer;
			_targetTransform = null;
			ShowTooltip(tooltipText, camera, offsetDirection, offset);
		}

		protected virtual void Awake()
		{
			_transform = base.transform;
			_label = GetComponent<TextMeshPro>();
		}

		protected virtual void LateUpdate()
		{
			PositionTooltip();
		}

		private void PositionTooltip()
		{
			if (_cameraTransform == null)
			{
				HideTooltip();
				return;
			}
			Vector3 vector = Quaternion.FromToRotation(Vector3.up, _cameraTransform.up) * _offsetDirection;
			float num = _offset;
			Vector3 vector2;
			if (_targetRenderer != null)
			{
				Bounds bounds = _targetRenderer.bounds;
				vector2 = bounds.center;
				num += bounds.extents.y;
			}
			else
			{
				if (!(_targetTransform != null))
				{
					HideTooltip();
					return;
				}
				vector2 = _targetTransform.position;
			}
			vector2 += vector * num;
			float t = (Mathf.Clamp((_cameraTransform.position - vector2).magnitude, _minDistanceSizeInfo.Distance, _maxDistanceSizeInfo.Distance) - _minDistanceSizeInfo.Distance) / (_maxDistanceSizeInfo.Distance - _minDistanceSizeInfo.Distance);
			_label.fontSize = Mathf.LerpUnclamped(_minDistanceSizeInfo.FontSize, _maxDistanceSizeInfo.FontSize, t);
			_label.rectTransform.sizeDelta = new Vector2(Mathf.LerpUnclamped(_minDistanceSizeInfo.Width, _maxDistanceSizeInfo.Width, t), Mathf.LerpUnclamped(_minDistanceSizeInfo.Height, _maxDistanceSizeInfo.Height, t));
			Quaternion rotation = _cameraTransform.rotation;
			_transform.position = vector2;
			if (IsXRTooltip)
			{
				_transform.LookAt(_transform.position + (vector2 - _cameraTransform.position), _cameraTransform.parent.up);
			}
			else
			{
				_transform.LookAt(_transform.position + rotation * Vector3.forward, rotation * Vector3.up);
			}
		}

		private void ShowTooltip(string tooltipText, Camera camera, Vector3 offsetDirection, float offset)
		{
			_label.text = tooltipText;
			_cameraTransform = camera.transform;
			_offsetDirection = offsetDirection;
			_offset = offset;
			PositionTooltip();
			base.gameObject.SetActive(value: true);
		}
	}
}
