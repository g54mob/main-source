using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[RequireComponent(typeof(Image))]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Joystick Angle Indicator")]
	[ExecuteInEditMode]
	public sealed class TouchJoystickAngleIndicator : MonoBehaviour, IVisibilityChangedHandler, TouchJoystick.IStickPositionChangedHandler
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles visibility.")]
		private bool _visible = true;

		[Tooltip("If enabled, the target angle will be determined by the transform's Local Rotation Z. Otherwise, the activation angle must be manually set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _targetAngleFromRotation = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, -360f)]
		[Tooltip("The joystick angle at which this object should be considered fully active.\n0 = up with negative values increase rotating clockwise. Example: -45 degrees = up-right.")]
		private float _targetAngle;

		[Tooltip("If enabled, the color will fade in and out based on the current joystick value.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _fadeWithValue = true;

		[SerializeField]
		[Tooltip("If enabled, the color will fade in and out based on the current joystick angle. As the angle approaches the Target Angle, the color will become more intense.")]
		[CustomObfuscation(rename = false)]
		private bool _fadeWithAngle = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("The angle of rotation away from the Target Angle where the color fully fades out. If Fade with Angle is enabled, this is used to determine when the color will fully fade out when the joystick angle rotates away from the the Target Angle. This should be set to 1/2 of the complete rotation arc. Example: A value of 45 degrees would make the color fully fade out when the joystick angle is 45 degrees away from the Target Angle on either side, giving a complete arc of 90 degrees.")]
		[SerializeField]
		[Range(0f, 360f)]
		private float _fadeRange = 45f;

		[Tooltip("The color when fully active.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Color _activeColor = new Color(1f, 1f, 1f, 1f);

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The color when not active.")]
		private Color _normalColor = new Color(1f, 1f, 1f, 0.3f);

		private Image tpDrQUnLiNzNkJloNDjZaqIIXQyf;

		private RectTransform mdGHZPLDWrDNNnMhDLfoVxRFlnbA;

		private Vector2 ovEbOvgQlexyQMmbqkEWcLtOolHEA;

		private bool VBuCxFwWEMMyPlMDLaKNRuoDjryw;

		private IRegistrar<TouchJoystickAngleIndicator> kRhbHXvrqlJayitdGhoxkAvStTDl;

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
					EhngzGcmOfPrGmNmBfBNNmveUrvAA(value, false);
					MncEiBETuyVoAMkjOuOEEFbWTdrkA();
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
					MncEiBETuyVoAMkjOuOEEFbWTdrkA();
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
					MncEiBETuyVoAMkjOuOEEFbWTdrkA();
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
					MncEiBETuyVoAMkjOuOEEFbWTdrkA();
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
					MncEiBETuyVoAMkjOuOEEFbWTdrkA();
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
					MncEiBETuyVoAMkjOuOEEFbWTdrkA();
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
				MncEiBETuyVoAMkjOuOEEFbWTdrkA();
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
				MncEiBETuyVoAMkjOuOEEFbWTdrkA();
			}
		}

		internal Image BnMGsprPdnlJdwNqFpkFVeoLHPbgA => tpDrQUnLiNzNkJloNDjZaqIIXQyf ?? (tpDrQUnLiNzNkJloNDjZaqIIXQyf = GetComponent<Image>());

		internal Sprite NMurCTTdmnYcOpPyxFoKSNySifgi
		{
			get
			{
				if (BnMGsprPdnlJdwNqFpkFVeoLHPbgA == null)
				{
					return null;
				}
				if (tpDrQUnLiNzNkJloNDjZaqIIXQyf.overrideSprite != null)
				{
					return tpDrQUnLiNzNkJloNDjZaqIIXQyf.overrideSprite;
				}
				return tpDrQUnLiNzNkJloNDjZaqIIXQyf.sprite;
			}
		}

		internal RectTransform vhIXtcDKyoXLWUypNMoixRgJSYDM => mdGHZPLDWrDNNnMhDLfoVxRFlnbA ?? (mdGHZPLDWrDNNnMhDLfoVxRFlnbA = GetComponent<RectTransform>());

		[CustomObfuscation(rename = false)]
		private TouchJoystickAngleIndicator()
		{
		}

		internal bool GBFAoSJVOvyLZtWjsMHlwuFilnbT(out Vector2 P_0)
		{
			P_0 = Vector2.zero;
			if (BnMGsprPdnlJdwNqFpkFVeoLHPbgA == null)
			{
				return false;
			}
			Sprite sprite = tpDrQUnLiNzNkJloNDjZaqIIXQyf.overrideSprite ?? tpDrQUnLiNzNkJloNDjZaqIIXQyf.sprite;
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
			hBxgXogslhRraiepUokxLHxvIQJT();
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (!Application.isPlaying)
			{
				hBxgXogslhRraiepUokxLHxvIQJT();
				BBunvGPfaMebensNvaMDiQyleKfn();
			}
			LmQEaCCafaRdGQUOWJefEYrRIojjb(ovEbOvgQlexyQMmbqkEWcLtOolHEA);
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			cHOoXEMCTQzcqmtBGrvqIyFfmIvm();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			uKRFvzaMGaNSXcVhkLDCQKHGfShqA();
			LmQEaCCafaRdGQUOWJefEYrRIojjb(ovEbOvgQlexyQMmbqkEWcLtOolHEA);
		}

		[CustomObfuscation(rename = false)]
		private void OnTransformParentChanged()
		{
			BBunvGPfaMebensNvaMDiQyleKfn();
		}

		private void EhngzGcmOfPrGmNmBfBNNmveUrvAA(bool P_0, bool P_1)
		{
			if (_visible != P_0 || P_1)
			{
				_visible = P_0;
				if (!P_0)
				{
					Color targetColor = _normalColor;
					targetColor.a = 0f;
					BnMGsprPdnlJdwNqFpkFVeoLHPbgA.CrossFadeColor(targetColor, 0f, ignoreTimeScale: true, useAlpha: true);
				}
				else
				{
					LmQEaCCafaRdGQUOWJefEYrRIojjb(ovEbOvgQlexyQMmbqkEWcLtOolHEA);
				}
			}
		}

		private void LmQEaCCafaRdGQUOWJefEYrRIojjb(Vector2 P_0)
		{
			if (!_visible)
			{
				Color targetColor = _normalColor;
				targetColor.a = 0f;
				BnMGsprPdnlJdwNqFpkFVeoLHPbgA.CrossFadeColor(targetColor, 0f, ignoreTimeScale: true, useAlpha: true);
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
				BnMGsprPdnlJdwNqFpkFVeoLHPbgA.CrossFadeColor(targetColor2, 0f, ignoreTimeScale: true, useAlpha: true);
			}
			else
			{
				BnMGsprPdnlJdwNqFpkFVeoLHPbgA.CrossFadeColor(_normalColor, 0f, ignoreTimeScale: true, useAlpha: true);
			}
		}

		private void hBxgXogslhRraiepUokxLHxvIQJT()
		{
			VBuCxFwWEMMyPlMDLaKNRuoDjryw = _visible;
		}

		private void uKRFvzaMGaNSXcVhkLDCQKHGfShqA()
		{
			if (VBuCxFwWEMMyPlMDLaKNRuoDjryw != _visible)
			{
				VBuCxFwWEMMyPlMDLaKNRuoDjryw = _visible;
				EhngzGcmOfPrGmNmBfBNNmveUrvAA(_visible, true);
			}
		}

		private void MncEiBETuyVoAMkjOuOEEFbWTdrkA()
		{
		}

		private void BBunvGPfaMebensNvaMDiQyleKfn()
		{
			cHOoXEMCTQzcqmtBGrvqIyFfmIvm();
			IRegistrar<TouchJoystickAngleIndicator> componentInSelfOrParents = UnityTools.GetComponentInSelfOrParents<IRegistrar<TouchJoystickAngleIndicator>>(base.transform);
			if (!componentInSelfOrParents.IsNullOrDestroyed())
			{
				componentInSelfOrParents.Register(this);
				kRhbHXvrqlJayitdGhoxkAvStTDl = componentInSelfOrParents;
			}
		}

		private void cHOoXEMCTQzcqmtBGrvqIyFfmIvm()
		{
			if (kRhbHXvrqlJayitdGhoxkAvStTDl.IsNullOrDestroyed())
			{
				if (kRhbHXvrqlJayitdGhoxkAvStTDl != null)
				{
					kRhbHXvrqlJayitdGhoxkAvStTDl = null;
				}
			}
			else
			{
				kRhbHXvrqlJayitdGhoxkAvStTDl.Deregister(this);
				kRhbHXvrqlJayitdGhoxkAvStTDl = null;
			}
		}

		public void OnVisibilityChanged(bool state)
		{
			EhngzGcmOfPrGmNmBfBNNmveUrvAA(state, false);
		}

		void IVisibilityChangedHandler.OnVisibilityChanged(bool state)
		{
			//ILSpy generated this explicit interface implementation from .override directive in OnVisibilityChanged
			this.OnVisibilityChanged(state);
		}

		public void OnTouchJoystickStickPositionChanged(Vector2 value)
		{
			if (!(this == null))
			{
				ovEbOvgQlexyQMmbqkEWcLtOolHEA = value;
				if (UnityTools.IsActiveAndEnabled(this) && _visible)
				{
					LmQEaCCafaRdGQUOWJefEYrRIojjb(value);
				}
			}
		}

		void TouchJoystick.IStickPositionChangedHandler.OnStickPositionChanged(Vector2 value)
		{
			OnTouchJoystickStickPositionChanged(value);
		}
	}
}
