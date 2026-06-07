using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[AddComponentMenu("Rewired/Touch Joystick Angle Indicator")]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(Image))]
	public sealed class TouchJoystickAngleIndicator : MonoBehaviour, TouchJoystick.IStickPositionChangedHandler, IVisibilityChangedHandler
	{
		[SerializeField]
		[Tooltip("Toggles visibility.")]
		[CustomObfuscation(rename = false)]
		private bool _visible = true;

		[SerializeField]
		[Tooltip("If enabled, the target angle will be determined by the transform's Local Rotation Z. Otherwise, the activation angle must be manually set.")]
		[CustomObfuscation(rename = false)]
		private bool _targetAngleFromRotation = true;

		[SerializeField]
		[Tooltip("The joystick angle at which this object should be considered fully active.\n0 = up with negative values increase rotating clockwise. Example: -45 degrees = up-right.")]
		[CustomObfuscation(rename = false)]
		[Range(0f, -360f)]
		private float _targetAngle;

		[Tooltip("If enabled, the color will fade in and out based on the current joystick value.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _fadeWithValue = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the color will fade in and out based on the current joystick angle. As the angle approaches the Target Angle, the color will become more intense.")]
		[SerializeField]
		private bool _fadeWithAngle = true;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The angle of rotation away from the Target Angle where the color fully fades out. If Fade with Angle is enabled, this is used to determine when the color will fully fade out when the joystick angle rotates away from the the Target Angle. This should be set to 1/2 of the complete rotation arc. Example: A value of 45 degrees would make the color fully fade out when the joystick angle is 45 degrees away from the Target Angle on either side, giving a complete arc of 90 degrees.")]
		[Range(0f, 360f)]
		private float _fadeRange = 45f;

		[Tooltip("The color when fully active.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Color _activeColor = new Color(1f, 1f, 1f, 1f);

		[SerializeField]
		[Tooltip("The color when not active.")]
		[CustomObfuscation(rename = false)]
		private Color _normalColor = new Color(1f, 1f, 1f, 0.3f);

		private Image calXLUBskMwDuzBaLatDKNrcmWEX;

		private RectTransform HLlUndjcbPBAjWfmKyTHloUCXtqV;

		private Vector2 nufTjowxdRBNPyzhJaDABWrTmXpb;

		private bool VHeMOnaFGtBHrgWKsqenUjgffeKc;

		private IRegistrar<TouchJoystickAngleIndicator> yQPfFXchXaljjsEClOxdsUVqmzCFA;

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
					cmmwwvcottRDAmZIsNkUSjRSinOy(value, false);
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
				CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
				CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
			}
		}

		internal Image RPwtBduEdBApXeKBhjbTfJafRCKV => calXLUBskMwDuzBaLatDKNrcmWEX ?? (calXLUBskMwDuzBaLatDKNrcmWEX = GetComponent<Image>());

		internal Sprite OPLJXNKQGPLjmAaRrfWHGQFMjHVcb
		{
			get
			{
				if (RPwtBduEdBApXeKBhjbTfJafRCKV == null)
				{
					return null;
				}
				if (calXLUBskMwDuzBaLatDKNrcmWEX.overrideSprite != null)
				{
					return calXLUBskMwDuzBaLatDKNrcmWEX.overrideSprite;
				}
				return calXLUBskMwDuzBaLatDKNrcmWEX.sprite;
			}
		}

		internal RectTransform uBgsATlVNpCXLTZUrAUVBouJZPML => HLlUndjcbPBAjWfmKyTHloUCXtqV ?? (HLlUndjcbPBAjWfmKyTHloUCXtqV = GetComponent<RectTransform>());

		[CustomObfuscation(rename = false)]
		private TouchJoystickAngleIndicator()
		{
		}

		internal bool zirtMcMjzTGuWtxJpmQiswDaOSMq(out Vector2 P_0)
		{
			P_0 = Vector2.zero;
			if (RPwtBduEdBApXeKBhjbTfJafRCKV == null)
			{
				return false;
			}
			Sprite sprite = calXLUBskMwDuzBaLatDKNrcmWEX.overrideSprite ?? calXLUBskMwDuzBaLatDKNrcmWEX.sprite;
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
			KNydgAkwFhcPfzydLxGZblsDNDrk();
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (!Application.isPlaying)
			{
				KNydgAkwFhcPfzydLxGZblsDNDrk();
				WlTgDwBrLkKEcOyWyUgotBqqAxtS();
			}
			chGeRtbgVwWxZjiDoRoAlpLmdWSrA(nufTjowxdRBNPyzhJaDABWrTmXpb);
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			lgMGxivNJmVgPETeGfkeWxfkuWtj();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			UlrwyDcujFnSPooxPZETSsQsaxFf();
			chGeRtbgVwWxZjiDoRoAlpLmdWSrA(nufTjowxdRBNPyzhJaDABWrTmXpb);
		}

		[CustomObfuscation(rename = false)]
		private void OnTransformParentChanged()
		{
			WlTgDwBrLkKEcOyWyUgotBqqAxtS();
		}

		private void cmmwwvcottRDAmZIsNkUSjRSinOy(bool P_0, bool P_1)
		{
			if (_visible != P_0 || P_1)
			{
				_visible = P_0;
				if (!P_0)
				{
					Color targetColor = _normalColor;
					targetColor.a = 0f;
					RPwtBduEdBApXeKBhjbTfJafRCKV.CrossFadeColor(targetColor, 0f, ignoreTimeScale: true, useAlpha: true);
				}
				else
				{
					chGeRtbgVwWxZjiDoRoAlpLmdWSrA(nufTjowxdRBNPyzhJaDABWrTmXpb);
				}
			}
		}

		private void chGeRtbgVwWxZjiDoRoAlpLmdWSrA(Vector2 P_0)
		{
			if (!_visible)
			{
				Color targetColor = _normalColor;
				targetColor.a = 0f;
				RPwtBduEdBApXeKBhjbTfJafRCKV.CrossFadeColor(targetColor, 0f, ignoreTimeScale: true, useAlpha: true);
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
				RPwtBduEdBApXeKBhjbTfJafRCKV.CrossFadeColor(targetColor2, 0f, ignoreTimeScale: true, useAlpha: true);
			}
			else
			{
				RPwtBduEdBApXeKBhjbTfJafRCKV.CrossFadeColor(_normalColor, 0f, ignoreTimeScale: true, useAlpha: true);
			}
		}

		private void KNydgAkwFhcPfzydLxGZblsDNDrk()
		{
			VHeMOnaFGtBHrgWKsqenUjgffeKc = _visible;
		}

		private void UlrwyDcujFnSPooxPZETSsQsaxFf()
		{
			if (VHeMOnaFGtBHrgWKsqenUjgffeKc != _visible)
			{
				VHeMOnaFGtBHrgWKsqenUjgffeKc = _visible;
				cmmwwvcottRDAmZIsNkUSjRSinOy(_visible, true);
			}
		}

		private void CbvCdtcgkXIqLYOKEKJdhBmfrjFcB()
		{
		}

		private void WlTgDwBrLkKEcOyWyUgotBqqAxtS()
		{
			lgMGxivNJmVgPETeGfkeWxfkuWtj();
			IRegistrar<TouchJoystickAngleIndicator> componentInSelfOrParents = UnityTools.GetComponentInSelfOrParents<IRegistrar<TouchJoystickAngleIndicator>>(base.transform);
			if (!componentInSelfOrParents.IsNullOrDestroyed())
			{
				componentInSelfOrParents.Register(this);
				yQPfFXchXaljjsEClOxdsUVqmzCFA = componentInSelfOrParents;
			}
		}

		private void lgMGxivNJmVgPETeGfkeWxfkuWtj()
		{
			if (yQPfFXchXaljjsEClOxdsUVqmzCFA.IsNullOrDestroyed())
			{
				if (yQPfFXchXaljjsEClOxdsUVqmzCFA != null)
				{
					yQPfFXchXaljjsEClOxdsUVqmzCFA = null;
				}
			}
			else
			{
				yQPfFXchXaljjsEClOxdsUVqmzCFA.Deregister(this);
				yQPfFXchXaljjsEClOxdsUVqmzCFA = null;
			}
		}

		public void OnVisibilityChanged(bool state)
		{
			cmmwwvcottRDAmZIsNkUSjRSinOy(state, false);
		}

		public void OnTouchJoystickStickPositionChanged(Vector2 value)
		{
			if (!(this == null))
			{
				nufTjowxdRBNPyzhJaDABWrTmXpb = value;
				if (UnityTools.IsActiveAndEnabled(this) && _visible)
				{
					chGeRtbgVwWxZjiDoRoAlpLmdWSrA(value);
				}
			}
		}

		void TouchJoystick.IStickPositionChangedHandler.OnStickPositionChanged(Vector2 value)
		{
			OnTouchJoystickStickPositionChanged(value);
		}
	}
}
