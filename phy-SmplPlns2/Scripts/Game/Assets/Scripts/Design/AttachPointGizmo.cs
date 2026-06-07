using Assets.Scripts.Craft.Parts;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Jundroo.Common.Settings;
using UnityEngine;

namespace Assets.Scripts.Design
{
	public class AttachPointGizmo : MonoBehaviour
	{
		private float _animationScale = 1f;

		private bool _highlighted;

		[SerializeField]
		private Color _highlightedColor = Color.yellow;

		private float _initialScale;

		[SerializeField]
		private Color _normalColor = Color.blue;

		private MeshRenderer _renderer;

		private bool _selected;

		private bool _success;

		private TweenerCore<float, float, FloatOptions> _tween;

		private NumericSetting<float> _uiScale;

		public AttachPointData AttachPoint { get; set; }

		public bool Highlighted
		{
			get
			{
				return _highlighted;
			}
			set
			{
				if (_highlighted != value)
				{
					_highlighted = value;
					UpdateMaterial();
				}
			}
		}

		public Color NormalColor
		{
			get
			{
				return _normalColor;
			}
			set
			{
				_normalColor = value;
			}
		}

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				if (_selected != value)
				{
					_selected = value;
					UpdateMaterial();
				}
			}
		}

		public bool Success
		{
			get
			{
				return _success;
			}
			set
			{
				if (_success != value)
				{
					_success = value;
					UpdateMaterial();
				}
			}
		}

		protected void LateUpdate()
		{
			Camera camera = Designer.Instance.CameraController.Camera;
			float num = 0.25f * _initialScale * _uiScale.Value;
			float num2 = Vector3.Distance(camera.transform.position, base.transform.position);
			float value;
			if (camera.orthographic)
			{
				value = num * 2f * camera.orthographicSize;
				value = Mathf.Clamp(value, 0.01f, 5f);
			}
			else
			{
				float num3 = camera.fieldOfView / 60f;
				value = num * num2 * num3;
				value = Mathf.Clamp(value, 0.01f, 2.5f);
			}
			base.transform.localScale = _animationScale * value * Vector3.one;
		}

		protected void Start()
		{
			_uiScale = Game.Instance.Settings.Gameplay.General.UserInterfaceScale;
			_initialScale = base.transform.localScale.x;
			_renderer = GetComponentInChildren<MeshRenderer>();
			UpdateMaterial();
		}

		private void UpdateMaterial()
		{
			Color normalColor = _normalColor;
			normalColor = _normalColor;
			normalColor.a = 0.6f;
			float endValue = 1f;
			if (_success)
			{
				normalColor = Color.green;
				normalColor.a = 1f;
				endValue = 1.25f;
			}
			else if (_selected)
			{
				normalColor = _normalColor;
				normalColor.a = 1f;
				endValue = 1f;
			}
			else if (_highlighted)
			{
				normalColor = _highlightedColor;
				normalColor.a = 0.8f;
				endValue = 1.25f;
			}
			_renderer.material.color = normalColor;
			_tween?.Kill(complete: true);
			_animationScale = 1f;
			_tween = DOTween.To(() => _animationScale, delegate(float x)
			{
				_animationScale = x;
			}, endValue, 0.35f).SetEase(Ease.OutElastic).SetUpdate(isIndependentUpdate: true);
		}
	}
}
