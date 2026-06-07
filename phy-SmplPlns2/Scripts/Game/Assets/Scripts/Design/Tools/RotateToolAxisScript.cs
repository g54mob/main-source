using System;
using Assets.Scripts.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Shapes;
using UnityEngine;

namespace Assets.Scripts.Design.Tools
{
	public class RotateToolAxisScript : MonoBehaviour, ITransformToolGizmo
	{
		[SerializeField]
		private Vector3 _axis;

		private bool _highlighted;

		private bool _inactive;

		private float _initialRadius;

		private float _initialThickness;

		private bool _selected;

		private Torus _torus;

		private TweenerCore<float, float, FloatOptions> _tween;

		public Vector3 Axis => _axis;

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
					if (value)
					{
						Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerGizmoHover);
					}
				}
			}
		}

		public bool Inactive
		{
			get
			{
				return _inactive;
			}
			set
			{
				if (_inactive != value)
				{
					_inactive = value;
					UpdateMaterial();
				}
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
					if (value)
					{
						Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerGizmoClick);
					}
					else
					{
						Game.Instance.UserInterface.Sound.PlaySound(UISound.DesignerGizmoRelease);
					}
				}
			}
		}

		public Transform Transform => base.transform;

		public bool IsHit(Vector3 point)
		{
			Vector3 vector = base.transform.InverseTransformPoint(point);
			vector.z = 0f;
			return vector.magnitude > 0.5f;
		}

		protected virtual void Start()
		{
			_torus = GetComponentInChildren<Torus>();
			_initialThickness = _torus.Thickness;
			_initialRadius = _torus.Radius;
			UpdateMaterial();
		}

		protected void Update()
		{
			Camera main = Camera.main;
			Vector3 lhs = base.transform.InverseTransformPoint(main.transform.position);
			lhs.Normalize();
			float t = Mathf.Abs(Vector3.Dot(lhs, Vector3.forward));
			float num = Mathf.Lerp(120f, 360f, t) * (MathF.PI / 180f) / 2f;
			lhs.z = 0f;
			float num2 = Mathf.Atan2(lhs.y, lhs.x);
			_torus.AngRadiansStart = num2 - num;
			_torus.AngRadiansEnd = num2 + num;
		}

		private void UpdateMaterial()
		{
			Color color = _torus.Color;
			float initialThickness = _initialThickness;
			float initialRadius = _initialRadius;
			if (_inactive)
			{
				color.a = 0.1f;
				initialRadius = _initialRadius * 1f;
				initialThickness = _initialThickness * 1f;
			}
			else if (_selected)
			{
				color.a = 1f;
				initialRadius = _initialRadius * 1f;
				initialThickness = _initialThickness * 1.5f;
			}
			else if (_highlighted)
			{
				color.a = 0.75f;
				initialRadius = _initialRadius * 1.05f;
				initialThickness = _initialThickness * 2.5f;
			}
			else
			{
				color.a = 0.35f;
				initialRadius = _initialRadius * 1f;
				initialThickness = _initialThickness * 1f;
			}
			_torus.Color = color;
			_torus.Thickness = initialThickness;
			_tween?.Kill(complete: true);
			_tween = DOTween.To(() => _torus.Radius, delegate(float x)
			{
				_torus.Radius = x;
			}, initialRadius, 0.35f).SetEase(Ease.OutElastic);
		}
	}
}
