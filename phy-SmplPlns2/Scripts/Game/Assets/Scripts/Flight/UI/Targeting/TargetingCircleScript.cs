using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Shapes;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Flight.UI.Targeting
{
	public class TargetingCircleScript : MonoBehaviour, ITargetingCircle
	{
		private float _angle;

		private Disc _disc;

		private float _distance = 1000f;

		private float _targetAngle;

		private TweenerCore<float, float, FloatOptions> _tween;

		public float Angle
		{
			get
			{
				return _angle;
			}
			set
			{
				if (_targetAngle != value)
				{
					_targetAngle = value;
					_tween?.Kill();
					_tween = DOTween.To(() => _angle, delegate(float x)
					{
						UpdateDisc(x);
					}, value, 0.25f).SetEase(Ease.OutBack).SetUpdate(isIndependentUpdate: true)
						.SetLink(base.gameObject);
				}
			}
		}

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				if (Visible != value)
				{
					base.gameObject.SetActive(value);
				}
			}
		}

		protected void Awake()
		{
			_disc = base.gameObject.AddComponent<Disc>();
			_disc.Radius = 0f;
			_disc.Type = DiscType.Ring;
			_disc.Color = Color.green;
			_disc.ThicknessSpace = ThicknessSpace.Pixels;
			_disc.Thickness = 2f;
			_disc.Dashed = true;
			_disc.DashSpace = DashSpace.FixedCount;
			_disc.DashSnap = DashSnapping.Off;
			_disc.DashType = DashType.Angled;
			_disc.ZTest = CompareFunction.Always;
		}

		private void UpdateDisc(float angle)
		{
			base.transform.localPosition = new Vector3(0f, 0f, _distance);
			_disc.Radius = _distance * Mathf.Tan(MathF.PI / 180f * angle);
			_angle = angle;
		}
	}
}
