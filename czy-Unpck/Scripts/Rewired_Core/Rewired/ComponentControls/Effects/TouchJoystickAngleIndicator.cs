using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(Image))]
	[AddComponentMenu("Rewired/Touch Joystick Angle Indicator")]
	public sealed class TouchJoystickAngleIndicator : MonoBehaviour, IVisibilityChangedHandler, TouchJoystick.IStickPositionChangedHandler
	{
		[CustomObfuscation(rename = false)]
		[Tooltip("Toggles visibility.")]
		[SerializeField]
		private bool _visible = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the target angle will be determined by the transform's Local Rotation Z. Otherwise, the activation angle must be manually set.")]
		private bool _targetAngleFromRotation = true;

		[Range(0f, -360f)]
		[Tooltip("The joystick angle at which this object should be considered fully active.\n0 = up with negative values increase rotating clockwise. Example: -45 degrees = up-right.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _targetAngle;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If enabled, the color will fade in and out based on the current joystick value.")]
		private bool _fadeWithValue = true;

		[Tooltip("If enabled, the color will fade in and out based on the current joystick angle. As the angle approaches the Target Angle, the color will become more intense.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _fadeWithAngle = true;

		[SerializeField]
		[Range(0f, 360f)]
		[CustomObfuscation(rename = false)]
		[Tooltip("The angle of rotation away from the Target Angle where the color fully fades out. If Fade with Angle is enabled, this is used to determine when the color will fully fade out when the joystick angle rotates away from the the Target Angle. This should be set to 1/2 of the complete rotation arc. Example: A value of 45 degrees would make the color fully fade out when the joystick angle is 45 degrees away from the Target Angle on either side, giving a complete arc of 90 degrees.")]
		private float _fadeRange = 45f;

		[CustomObfuscation(rename = false)]
		[Tooltip("The color when fully active.")]
		[SerializeField]
		private Color _activeColor = new Color(1f, 1f, 1f, 1f);

		[SerializeField]
		[Tooltip("The color when not active.")]
		[CustomObfuscation(rename = false)]
		private Color _normalColor = new Color(1f, 1f, 1f, 0.3f);

		private Image YvsBntdVDDXyvcwfUXpRFSZQjKp;

		private RectTransform tmakEQDNEGzEeRqmFezXlvluWOF;

		private Vector2 NDocXGUiSMgBAgvrCwUFcDrtaZyO;

		private bool pJnECxCueaXVEbXYjEEeYGYHSMZ;

		private IRegistrar<TouchJoystickAngleIndicator> QGjTkPNojCtuJaOonPlELiWuGx;

		public bool visible
		{
			get
			{
				return _visible;
			}
			set
			{
				if (visible == value)
				{
					return;
				}
				while (true)
				{
					KEpqQGGfOeHyBrmOlKJIMDckKQh(value, false);
					int num = -2032047475;
					while (true)
					{
						switch (num ^ -2032047476)
						{
						case 0:
							goto IL_000a;
						case 2:
							break;
						default:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
						IL_000a:
						num = -2032047474;
					}
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
				if (_targetAngleFromRotation == value)
				{
					return;
				}
				while (true)
				{
					_targetAngleFromRotation = value;
					int num = -1821108053;
					while (true)
					{
						switch (num ^ -1821108055)
						{
						case 0:
							goto IL_000a;
						case 1:
							break;
						default:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
						IL_000a:
						num = -1821108056;
					}
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
				if (_targetAngle == value)
				{
					return;
				}
				while (true)
				{
					_targetAngle = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
					int num = 68790344;
					while (true)
					{
						switch (num ^ 0x419A848)
						{
						case 2:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 0:
							return;
						}
						break;
						IL_000a:
						num = 68790345;
					}
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
				if (_fadeWithValue == value)
				{
					return;
				}
				while (true)
				{
					_fadeWithValue = value;
					wWklIWMVIReShFCdZhfAVVyDQgX();
					int num = 1730999153;
					while (true)
					{
						switch (num ^ 0x672CF370)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_000a:
						num = 1730999154;
					}
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
				if (_fadeWithAngle == value)
				{
					while (true)
					{
						switch (0x5DDF3609 ^ 0x5DDF3608)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				_fadeWithAngle = value;
				wWklIWMVIReShFCdZhfAVVyDQgX();
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
				if (_fadeRange == value)
				{
					return;
				}
				while (true)
				{
					_fadeRange = value;
					int num = -1994764021;
					while (true)
					{
						switch (num ^ -1994764023)
						{
						case 0:
							num = -1994764024;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							num = -1994764022;
							continue;
						case 3:
							return;
						}
						break;
					}
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
				while (true)
				{
					int num = 480901539;
					while (true)
					{
						switch (num ^ 0x1CA9F9A2)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0025;
						case 2:
							return;
						}
						break;
						IL_0025:
						wWklIWMVIReShFCdZhfAVVyDQgX();
						num = 480901536;
					}
				}
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
				wWklIWMVIReShFCdZhfAVVyDQgX();
			}
		}

		internal Image image => YvsBntdVDDXyvcwfUXpRFSZQjKp ?? (YvsBntdVDDXyvcwfUXpRFSZQjKp = GetComponent<Image>());

		internal Sprite currentSprite
		{
			get
			{
				if (image == null)
				{
					return null;
				}
				if (YvsBntdVDDXyvcwfUXpRFSZQjKp.overrideSprite != null)
				{
					return YvsBntdVDDXyvcwfUXpRFSZQjKp.overrideSprite;
				}
				return YvsBntdVDDXyvcwfUXpRFSZQjKp.sprite;
			}
		}

		internal RectTransform rectTransform => tmakEQDNEGzEeRqmFezXlvluWOF ?? (tmakEQDNEGzEeRqmFezXlvluWOF = GetComponent<RectTransform>());

		[CustomObfuscation(rename = false)]
		private TouchJoystickAngleIndicator()
		{
		}

		internal bool PogkjRsJMAKgTcINaikscnkYdltG(out Vector2 P_0)
		{
			P_0 = Vector2.zero;
			if (image == null)
			{
				goto IL_0019;
			}
			Sprite sprite = YvsBntdVDDXyvcwfUXpRFSZQjKp.overrideSprite ?? YvsBntdVDDXyvcwfUXpRFSZQjKp.sprite;
			int num;
			if (sprite == null)
			{
				num = -1286295440;
				goto IL_001e;
			}
			Rect textureRect = sprite.textureRect;
			P_0.x = textureRect.width;
			P_0.y = textureRect.height;
			return true;
			IL_001e:
			switch (num ^ -1286295438)
			{
			case 0:
				break;
			case 1:
				return false;
			default:
				return false;
			}
			goto IL_0019;
			IL_0019:
			num = -1286295437;
			goto IL_001e;
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			OnTouchJoystickStickPositionChanged(Vector2.zero);
			mCfqjvKuqejioobvUrFBzcZtvoG();
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (!Application.isPlaying)
			{
				while (true)
				{
					int num = -174951206;
					while (true)
					{
						switch (num ^ -174951205)
						{
						case 0:
							break;
						case 1:
							mCfqjvKuqejioobvUrFBzcZtvoG();
							num = -174951208;
							continue;
						case 3:
							cGWbXVrvszGWlPNWdroqpPBQhGCE();
							num = -174951207;
							continue;
						default:
							goto end_IL_0007;
						}
						break;
					}
					continue;
					end_IL_0007:
					break;
				}
			}
			CNXJWwWmortQRrFSlKQtjwKUrjH(NDocXGUiSMgBAgvrCwUFcDrtaZyO);
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			PHXoGZZMmnOTSHIeVqDkYNQQpLW();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			uIcmosSkKSAtGFldAPtVCIzcQLub();
			CNXJWwWmortQRrFSlKQtjwKUrjH(NDocXGUiSMgBAgvrCwUFcDrtaZyO);
		}

		[CustomObfuscation(rename = false)]
		private void OnTransformParentChanged()
		{
			cGWbXVrvszGWlPNWdroqpPBQhGCE();
		}

		private void KEpqQGGfOeHyBrmOlKJIMDckKQh(bool P_0, bool P_1)
		{
			if (_visible == P_0 && !P_1)
			{
				return;
			}
			while (true)
			{
				_visible = P_0;
				int num = 615282598;
				while (true)
				{
					switch (num ^ 0x24AC77A6)
					{
					case 2:
						goto IL_000d;
					case 1:
						break;
					case 0:
						if (!P_0)
						{
							Color targetColor = _normalColor;
							targetColor.a = 0f;
							image.CrossFadeColor(targetColor, 0f, ignoreTimeScale: true, useAlpha: true);
							return;
						}
						goto default;
					default:
						CNXJWwWmortQRrFSlKQtjwKUrjH(NDocXGUiSMgBAgvrCwUFcDrtaZyO);
						return;
					}
					break;
					IL_000d:
					num = 615282599;
				}
			}
		}

		private void CNXJWwWmortQRrFSlKQtjwKUrjH(Vector2 P_0)
		{
			Color targetColor = default(Color);
			if (!_visible)
			{
				targetColor = _normalColor;
				targetColor.a = 0f;
				goto IL_001e;
			}
			goto IL_00d7;
			IL_0181:
			image.CrossFadeColor(_normalColor, 0f, ignoreTimeScale: true, useAlpha: true);
			int num = -178759613;
			goto IL_0023;
			IL_001e:
			num = -178759609;
			goto IL_0023;
			IL_0023:
			float num2 = default(float);
			float target = default(float);
			float num5 = default(float);
			Color targetColor2 = default(Color);
			float magnitude = default(float);
			while (true)
			{
				switch (num ^ -178759612)
				{
				case 6:
					break;
				default:
					return;
				case 9:
					if (_fadeWithAngle)
					{
						float num3 = Mathf.Abs(MathTools.DeltaAngle(num2, target));
						float num4 = ((_fadeRange != 0f) ? MathTools.Clamp01(1f - num3 / _fadeRange) : 1f);
						num5 *= num4;
						num = -178759604;
						continue;
					}
					goto case 8;
				case 10:
					image.CrossFadeColor(targetColor2, 0f, ignoreTimeScale: true, useAlpha: true);
					return;
				case 5:
					goto IL_00d7;
				case 3:
					image.CrossFadeColor(targetColor, 0f, ignoreTimeScale: true, useAlpha: true);
					return;
				case 1:
					if (_fadeWithValue)
					{
						num5 *= magnitude;
						num = -178759603;
						continue;
					}
					goto case 9;
				case 11:
					goto IL_0181;
				case 8:
					targetColor2 = Color.Lerp(_normalColor, _activeColor, num5);
					num = -178759602;
					continue;
				case 0:
					num5 = 1f;
					num = -178759611;
					continue;
				case 2:
					if (_fadeWithAngle)
					{
						goto case 0;
					}
					goto IL_01da;
				case 4:
					targetColor2 = (MathTools.AngleIsNear(num2, target, _fadeRange) ? _activeColor : _normalColor);
					num = -178759602;
					continue;
				case 7:
					return;
				}
				break;
				IL_01da:
				int num6;
				if (_fadeWithValue)
				{
					num = -178759612;
					num6 = num;
				}
				else
				{
					num = -178759616;
					num6 = num;
				}
			}
			goto IL_001e;
			IL_00d7:
			if (!MathTools.ApproximatelyZero(P_0.sqrMagnitude))
			{
				magnitude = P_0.magnitude;
				float num7 = Vector2.Angle(Vector2.up, P_0);
				target = (_targetAngleFromRotation ? base.transform.localEulerAngles.z : _targetAngle) * -1f;
				num2 = ((P_0.x < 0f) ? (360f - num7) : num7);
				num = -178759610;
				goto IL_0023;
			}
			goto IL_0181;
		}

		private void mCfqjvKuqejioobvUrFBzcZtvoG()
		{
			pJnECxCueaXVEbXYjEEeYGYHSMZ = _visible;
		}

		private void uIcmosSkKSAtGFldAPtVCIzcQLub()
		{
			if (pJnECxCueaXVEbXYjEEeYGYHSMZ == _visible)
			{
				return;
			}
			while (true)
			{
				int num = 1170246247;
				while (true)
				{
					switch (num ^ 0x45C08A64)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						pJnECxCueaXVEbXYjEEeYGYHSMZ = _visible;
						num = 1170246245;
						continue;
					case 1:
						KEpqQGGfOeHyBrmOlKJIMDckKQh(_visible, true);
						num = 1170246246;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		private void wWklIWMVIReShFCdZhfAVVyDQgX()
		{
		}

		private void cGWbXVrvszGWlPNWdroqpPBQhGCE()
		{
			PHXoGZZMmnOTSHIeVqDkYNQQpLW();
			IRegistrar<TouchJoystickAngleIndicator> componentInSelfOrParents = UnityTools.GetComponentInSelfOrParents<IRegistrar<TouchJoystickAngleIndicator>>(base.transform);
			if (componentInSelfOrParents.IsNullOrDestroyed())
			{
				while (true)
				{
					switch (-947575171 ^ -947575172)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			componentInSelfOrParents.Register(this);
			QGjTkPNojCtuJaOonPlELiWuGx = componentInSelfOrParents;
		}

		private void PHXoGZZMmnOTSHIeVqDkYNQQpLW()
		{
			if (QGjTkPNojCtuJaOonPlELiWuGx.IsNullOrDestroyed())
			{
				while (true)
				{
					int num = 791174795;
					while (true)
					{
						switch (num ^ 0x2F285E88)
						{
						case 0:
							break;
						case 3:
							if (QGjTkPNojCtuJaOonPlELiWuGx != null)
							{
								QGjTkPNojCtuJaOonPlELiWuGx = null;
								num = 791174793;
								continue;
							}
							return;
						case 1:
							return;
						default:
							goto end_IL_000d;
						}
						break;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			QGjTkPNojCtuJaOonPlELiWuGx.Deregister(this);
			QGjTkPNojCtuJaOonPlELiWuGx = null;
		}

		public void OnVisibilityChanged(bool state)
		{
			KEpqQGGfOeHyBrmOlKJIMDckKQh(state, false);
		}

		public void OnTouchJoystickStickPositionChanged(Vector2 value)
		{
			if (this == null)
			{
				return;
			}
			while (true)
			{
				NDocXGUiSMgBAgvrCwUFcDrtaZyO = value;
				int num;
				int num2;
				if (!UnityTools.IsActiveAndEnabled(this))
				{
					num = -1928724099;
					num2 = num;
				}
				else
				{
					num = -1928724101;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1928724103)
					{
					case 0:
						goto IL_000a;
					case 2:
						if (!_visible)
						{
							return;
						}
						goto default;
					case 4:
						return;
					case 1:
						break;
					default:
						CNXJWwWmortQRrFSlKQtjwKUrjH(value);
						return;
					}
					break;
					IL_000a:
					num = -1928724104;
				}
			}
		}

		private void WHhNzwWxsBIroCEkCRdoNTwnKZe(Vector2 P_0)
		{
			OnTouchJoystickStickPositionChanged(P_0);
		}

		void TouchJoystick.IStickPositionChangedHandler.OnStickPositionChanged(Vector2 P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in WHhNzwWxsBIroCEkCRdoNTwnKZe
			this.WHhNzwWxsBIroCEkCRdoNTwnKZe(P_0);
		}
	}
}
