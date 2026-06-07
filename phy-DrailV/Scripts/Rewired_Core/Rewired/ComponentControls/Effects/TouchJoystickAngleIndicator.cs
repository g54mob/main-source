using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[RequireComponent(typeof(Image))]
	[AddComponentMenu("Rewired/Touch Controls/Effects/Touch Joystick Angle Indicator")]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	public sealed class TouchJoystickAngleIndicator : MonoBehaviour, TouchJoystick.IStickPositionChangedHandler, IVisibilityChangedHandler
	{
		[Tooltip("Toggles visibility.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _visible = true;

		[Tooltip("If enabled, the target angle will be determined by the transform's Local Rotation Z. Otherwise, the activation angle must be manually set.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _targetAngleFromRotation = true;

		[Tooltip("The joystick angle at which this object should be considered fully active.\n0 = up with negative values increase rotating clockwise. Example: -45 degrees = up-right.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Range(0f, -360f)]
		private float _targetAngle;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If enabled, the color will fade in and out based on the current joystick value.")]
		private bool _fadeWithValue = true;

		[Tooltip("If enabled, the color will fade in and out based on the current joystick angle. As the angle approaches the Target Angle, the color will become more intense.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _fadeWithAngle = true;

		[Range(0f, 360f)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The angle of rotation away from the Target Angle where the color fully fades out. If Fade with Angle is enabled, this is used to determine when the color will fully fade out when the joystick angle rotates away from the the Target Angle. This should be set to 1/2 of the complete rotation arc. Example: A value of 45 degrees would make the color fully fade out when the joystick angle is 45 degrees away from the Target Angle on either side, giving a complete arc of 90 degrees.")]
		private float _fadeRange = 45f;

		[SerializeField]
		[Tooltip("The color when fully active.")]
		[CustomObfuscation(rename = false)]
		private Color _activeColor = new Color(1f, 1f, 1f, 1f);

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The color when not active.")]
		private Color _normalColor = new Color(1f, 1f, 1f, 0.3f);

		private Image LQbAeLhHEIDcIOLOwtJlCcMhoSUS;

		private RectTransform sifCHyJBBTfvNJzYbCjrcyrLGlePA;

		private Vector2 YQlJAoIuHNfelDTHalSnYNpEdyDx;

		private bool qroEZPANjdgadLjgTQEMFHIiYpuX;

		private IRegistrar<TouchJoystickAngleIndicator> NuDAGSHMpokMVryaSAJXLqcfcxCO;

		public bool visible
		{
			get
			{
				return _visible;
			}
			set
			{
				if (visible != value)
				{
					RpytviYBHzgKcVevXSbeLcqZvMCm(value, false);
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
				}
			}
		}

		public bool targetAngleFromRotation
		{
			get
			{
				return _targetAngleFromRotation;
			}
			set
			{
				if (_targetAngleFromRotation != value)
				{
					_targetAngleFromRotation = value;
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
				}
			}
		}

		public float targetAngle
		{
			get
			{
				if (!_targetAngleFromRotation)
				{
					return _targetAngle;
				}
				return base.transform.localEulerAngles.z;
			}
			set
			{
				if (_targetAngle != value)
				{
					_targetAngle = value;
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
				}
			}
		}

		public bool fadeWithValue
		{
			get
			{
				return _fadeWithValue;
			}
			set
			{
				if (_fadeWithValue != value)
				{
					_fadeWithValue = value;
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
				}
			}
		}

		public bool fadeWithAngle
		{
			get
			{
				return _fadeWithAngle;
			}
			set
			{
				if (_fadeWithAngle != value)
				{
					_fadeWithAngle = value;
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
				}
			}
		}

		public float fadeRange
		{
			get
			{
				return _fadeRange;
			}
			set
			{
				if (_fadeRange != value)
				{
					_fadeRange = value;
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
				}
			}
		}

		public Color activeColor
		{
			get
			{
				return _activeColor;
			}
			set
			{
				_activeColor = value;
				jebsoqOBGHhJxfFgdjbRaKVujtZwA();
			}
		}

		public Color normalColor
		{
			get
			{
				return _normalColor;
			}
			set
			{
				_normalColor = value;
				jebsoqOBGHhJxfFgdjbRaKVujtZwA();
			}
		}

		internal Image ezmVocIYLReQdVolMZDpweBgcWSAA => LQbAeLhHEIDcIOLOwtJlCcMhoSUS ?? (LQbAeLhHEIDcIOLOwtJlCcMhoSUS = GetComponent<Image>());

		internal Sprite zSFOUrcycXIOxvjLCohmZsBJZLTb
		{
			get
			{
				if (ezmVocIYLReQdVolMZDpweBgcWSAA == null)
				{
					return null;
				}
				if (LQbAeLhHEIDcIOLOwtJlCcMhoSUS.overrideSprite != null)
				{
					return LQbAeLhHEIDcIOLOwtJlCcMhoSUS.overrideSprite;
				}
				return LQbAeLhHEIDcIOLOwtJlCcMhoSUS.sprite;
			}
		}

		internal RectTransform DSmDnIVkfzvBzeFgEbidCWTOTVMO => sifCHyJBBTfvNJzYbCjrcyrLGlePA ?? (sifCHyJBBTfvNJzYbCjrcyrLGlePA = GetComponent<RectTransform>());

		[CustomObfuscation(rename = false)]
		private TouchJoystickAngleIndicator()
		{
		}

		internal bool SfzcsjkSNJBLiYrtGecMEtuvYUCHA(out Vector2 P_0)
		{
			P_0 = Vector2.zero;
			if (ezmVocIYLReQdVolMZDpweBgcWSAA == null)
			{
				return false;
			}
			Sprite sprite = LQbAeLhHEIDcIOLOwtJlCcMhoSUS.overrideSprite ?? LQbAeLhHEIDcIOLOwtJlCcMhoSUS.sprite;
			if (sprite == null)
			{
				return false;
			}
			Rect textureRect = sprite.textureRect;
			P_0.x = textureRect.width;
			P_0.y = textureRect.height;
			return true;
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			OnTouchJoystickStickPositionChanged(Vector2.zero);
			lxmTcRQJlnoHPGdLguZvunPOJPtO();
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (!Application.isPlaying)
			{
				lxmTcRQJlnoHPGdLguZvunPOJPtO();
				lBvQjBxpkntAfpyDLwQNgZthztJA();
			}
			JkOSGoAIpuJYzXBxTYYugkozvWUN(YQlJAoIuHNfelDTHalSnYNpEdyDx);
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			AdSBDpCFjqUwjepCfJHUHPAfjozMB();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			vUjxvWQVNLVWrXPFiwzfJDxlckDW();
			JkOSGoAIpuJYzXBxTYYugkozvWUN(YQlJAoIuHNfelDTHalSnYNpEdyDx);
		}

		[CustomObfuscation(rename = false)]
		private void OnTransformParentChanged()
		{
			lBvQjBxpkntAfpyDLwQNgZthztJA();
		}

		private void RpytviYBHzgKcVevXSbeLcqZvMCm(bool P_0, bool P_1)
		{
			if (_visible != P_0 || P_1)
			{
				_visible = P_0;
				if (!P_0)
				{
					Color targetColor = _normalColor;
					targetColor.a = 0f;
					ezmVocIYLReQdVolMZDpweBgcWSAA.CrossFadeColor(targetColor, 0f, ignoreTimeScale: true, useAlpha: true);
				}
				else
				{
					JkOSGoAIpuJYzXBxTYYugkozvWUN(YQlJAoIuHNfelDTHalSnYNpEdyDx);
				}
			}
		}

		private void JkOSGoAIpuJYzXBxTYYugkozvWUN(Vector2 P_0)
		{
			if (!_visible)
			{
				Color targetColor = _normalColor;
				targetColor.a = 0f;
				ezmVocIYLReQdVolMZDpweBgcWSAA.CrossFadeColor(targetColor, 0f, ignoreTimeScale: true, useAlpha: true);
			}
			else if (!MathTools.ApproximatelyZero(P_0.sqrMagnitude))
			{
				float magnitude = P_0.magnitude;
				float num = Vector2.Angle(Vector2.up, P_0);
				float target = (_targetAngleFromRotation ? base.transform.localEulerAngles.z : _targetAngle) * -1f;
				float num2 = ((P_0.x < 0f) ? (360f - num) : num);
				Color targetColor2;
				if (_fadeWithAngle || _fadeWithValue)
				{
					float num3 = 1f;
					if (_fadeWithValue)
					{
						num3 *= magnitude;
					}
					if (_fadeWithAngle)
					{
						float num4 = Mathf.Abs(MathTools.DeltaAngle(num2, target));
						float num5 = ((_fadeRange != 0f) ? MathTools.Clamp01(1f - num4 / _fadeRange) : 1f);
						num3 *= num5;
					}
					targetColor2 = Color.Lerp(_normalColor, _activeColor, num3);
				}
				else
				{
					targetColor2 = (MathTools.AngleIsNear(num2, target, _fadeRange) ? _activeColor : _normalColor);
				}
				ezmVocIYLReQdVolMZDpweBgcWSAA.CrossFadeColor(targetColor2, 0f, ignoreTimeScale: true, useAlpha: true);
			}
			else
			{
				ezmVocIYLReQdVolMZDpweBgcWSAA.CrossFadeColor(_normalColor, 0f, ignoreTimeScale: true, useAlpha: true);
			}
		}

		private void lxmTcRQJlnoHPGdLguZvunPOJPtO()
		{
			qroEZPANjdgadLjgTQEMFHIiYpuX = _visible;
		}

		private void vUjxvWQVNLVWrXPFiwzfJDxlckDW()
		{
			if (qroEZPANjdgadLjgTQEMFHIiYpuX != _visible)
			{
				qroEZPANjdgadLjgTQEMFHIiYpuX = _visible;
				RpytviYBHzgKcVevXSbeLcqZvMCm(_visible, true);
			}
		}

		private void jebsoqOBGHhJxfFgdjbRaKVujtZwA()
		{
		}

		private void lBvQjBxpkntAfpyDLwQNgZthztJA()
		{
			AdSBDpCFjqUwjepCfJHUHPAfjozMB();
			IRegistrar<TouchJoystickAngleIndicator> componentInSelfOrParents = UnityTools.GetComponentInSelfOrParents<IRegistrar<TouchJoystickAngleIndicator>>(base.transform);
			if (!componentInSelfOrParents.IsNullOrDestroyed())
			{
				componentInSelfOrParents.Register(this);
				NuDAGSHMpokMVryaSAJXLqcfcxCO = componentInSelfOrParents;
			}
		}

		private void AdSBDpCFjqUwjepCfJHUHPAfjozMB()
		{
			if (NuDAGSHMpokMVryaSAJXLqcfcxCO.IsNullOrDestroyed())
			{
				if (NuDAGSHMpokMVryaSAJXLqcfcxCO != null)
				{
					NuDAGSHMpokMVryaSAJXLqcfcxCO = null;
				}
			}
			else
			{
				NuDAGSHMpokMVryaSAJXLqcfcxCO.Deregister(this);
				NuDAGSHMpokMVryaSAJXLqcfcxCO = null;
			}
		}

		public void OnVisibilityChanged(bool state)
		{
			RpytviYBHzgKcVevXSbeLcqZvMCm(state, false);
		}

		public void OnTouchJoystickStickPositionChanged(Vector2 value)
		{
			if (!(this == null))
			{
				YQlJAoIuHNfelDTHalSnYNpEdyDx = value;
				if (UnityTools.IsActiveAndEnabled(this) && _visible)
				{
					JkOSGoAIpuJYzXBxTYYugkozvWUN(value);
				}
			}
		}

		void TouchJoystick.IStickPositionChangedHandler.OnStickPositionChanged(Vector2 value)
		{
			OnTouchJoystickStickPositionChanged(value);
		}
	}
}
