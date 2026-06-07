using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.UGUIGlow
{
	public class PulseAnimation : GlowAnimation
	{
		protected float _pulseDuration = 1f;

		protected float _flashDuration = 0.05f;

		protected float _maxAlpha = 1f;

		protected float _minAlpha;

		protected float _currentTime;

		public float PulseDuration
		{
			get
			{
				return _pulseDuration;
			}
			set
			{
				if (_pulseDuration != value)
				{
					_pulseDuration = Mathf.Max(0.1f, value);
					TriggerOnValueChanged();
				}
			}
		}

		public float FlashDuration
		{
			get
			{
				return _flashDuration;
			}
			set
			{
				if (_flashDuration != value)
				{
					_flashDuration = Mathf.Max(0.01f, value);
					TriggerOnValueChanged();
				}
			}
		}

		public float MaxAlpha
		{
			get
			{
				return _maxAlpha;
			}
			set
			{
				if (_maxAlpha != value)
				{
					_maxAlpha = Mathf.Clamp01(value);
					TriggerOnValueChanged();
				}
			}
		}

		public float MinAlpha
		{
			get
			{
				return _minAlpha;
			}
			set
			{
				if (_minAlpha != value)
				{
					_minAlpha = Mathf.Clamp01(value);
					TriggerOnValueChanged();
				}
			}
		}

		public override IGlowAnimation Copy()
		{
			PulseAnimation pulseAnimation = new PulseAnimation();
			pulseAnimation.CopyValuesFrom(this);
			return pulseAnimation;
		}

		public override void CopyValuesFrom(IGlowAnimation source)
		{
			base.CopyValuesFrom(source);
			if (source is PulseAnimation pulseAnimation)
			{
				PulseDuration = pulseAnimation.PulseDuration;
				FlashDuration = pulseAnimation.FlashDuration;
				MaxAlpha = pulseAnimation.MaxAlpha;
				MinAlpha = pulseAnimation.MinAlpha;
			}
		}

		protected override void updateAnimation(float deltaTime)
		{
			_currentTime += deltaTime;
			if (_currentTime >= _pulseDuration)
			{
				_currentTime -= _pulseDuration;
			}
		}

		protected override void onUpdateMesh(MeshCreator manipulator, List<UIVertex> vertices, List<ushort> triangles, List<ushort> outerIndices, List<ushort> innerIndices, Dictionary<ushort, ushort> outerToInnerIndices)
		{
			if (manipulator != null && vertices != null)
			{
				float num;
				if (_currentTime < _flashDuration)
				{
					num = Mathf.Lerp(_minAlpha, _maxAlpha, _currentTime / _flashDuration);
				}
				else
				{
					float num2 = _currentTime - _flashDuration;
					float num3 = _pulseDuration - _flashDuration;
					num = Mathf.Lerp(_maxAlpha, _minAlpha, num2 / num3);
				}
				for (int i = 0; i < vertices.Count; i++)
				{
					UIVertex value = vertices[i];
					Color color = value.color;
					color.a *= num;
					value.color = color;
					vertices[i] = value;
				}
			}
		}
	}
}
