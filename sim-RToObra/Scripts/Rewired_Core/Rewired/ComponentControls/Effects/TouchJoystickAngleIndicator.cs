using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(RectTransform))]
	[ExecuteInEditMode]
	[RequireComponent(typeof(Image))]
	public sealed class TouchJoystickAngleIndicator : MonoBehaviour, IVisibilityChangedHandler, TouchJoystick.IStickPositionChangedHandler
	{
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("Toggles visibility.")]
		private bool _visible = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the target angle will be determined by the transform's Local Rotation Z. Otherwise, the activation angle must be manually set.")]
		[SerializeField]
		private bool _targetAngleFromRotation = true;

		[CustomObfuscation(rename = false)]
		[Tooltip("The joystick angle at which this object should be considered fully active.\n0 = up with negative values increase rotating clockwise. Example: -45 degrees = up-right.")]
		[SerializeField]
		[Range(0f, -360f)]
		private float _targetAngle;

		[SerializeField]
		[Tooltip("If enabled, the color will fade in and out based on the current joystick value.")]
		[CustomObfuscation(rename = false)]
		private bool _fadeWithValue = true;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the color will fade in and out based on the current joystick angle. As the angle approaches the Target Angle, the color will become more intense.")]
		private bool _fadeWithAngle = true;

		[Range(0f, 360f)]
		[Tooltip("The angle of rotation away from the Target Angle where the color fully fades out. If Fade with Angle is enabled, this is used to determine when the color will fully fade out when the joystick angle rotates away from the the Target Angle. This should be set to 1/2 of the complete rotation arc. Example: A value of 45 degrees would make the color fully fade out when the joystick angle is 45 degrees away from the Target Angle on either side, giving a complete arc of 90 degrees.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _fadeRange = 45f;

		[CustomObfuscation(rename = false)]
		[Tooltip("The color when fully active.")]
		[SerializeField]
		private Color _activeColor = new Color(1f, 1f, 1f, 1f);

		[Tooltip("The color when not active.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Color _normalColor = new Color(1f, 1f, 1f, 0.3f);

		private Image UkytztfegFjxRAnWtoiQGueBHbBq;

		private RectTransform jWsAaYZljMxgOQUIkeMAAFRfBYz;

		private Vector2 XySdAOKjAJnwmJRnyfScrRwkPM;

		private bool btfgbdYZiylScewFWjvlbyDWYmd;

		private IRegistrar<TouchJoystickAngleIndicator> AbOcnoXWPhAHWAUcZjcsWpKNXSTc;

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
					SWnzUAEKhgDxxwxmMhpFBvKnnQNm(value, false);
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
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
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
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
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
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
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
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
					return;
				}
				while (true)
				{
					_fadeWithAngle = value;
					wQiEPKGVkSYAiCZoyTUamohUIKKd();
					int num = -1260814230;
					while (true)
					{
						switch (num ^ -1260814232)
						{
						case 0:
							goto IL_000a;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_000a:
						num = -1260814231;
					}
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
				if (_fadeRange == value)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = -259345778;
				goto IL_000e;
				IL_000e:
				switch (num ^ -259345780)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					return;
				case 3:
					goto IL_0033;
				case 1:
					return;
				}
				goto IL_0009;
				IL_0033:
				_fadeRange = value;
				wQiEPKGVkSYAiCZoyTUamohUIKKd();
				num = -259345779;
				goto IL_000e;
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
				wQiEPKGVkSYAiCZoyTUamohUIKKd();
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
				wQiEPKGVkSYAiCZoyTUamohUIKKd();
			}
		}

		internal Image image
		{
			get
			{
				return UkytztfegFjxRAnWtoiQGueBHbBq ?? (UkytztfegFjxRAnWtoiQGueBHbBq = GetComponent<Image>());
			}
		}

		internal Sprite currentSprite
		{
			get
			{
				if (image == null)
				{
					return null;
				}
				if (UkytztfegFjxRAnWtoiQGueBHbBq.overrideSprite != null)
				{
					return UkytztfegFjxRAnWtoiQGueBHbBq.overrideSprite;
				}
				return UkytztfegFjxRAnWtoiQGueBHbBq.sprite;
			}
		}

		internal RectTransform rectTransform
		{
			get
			{
				return jWsAaYZljMxgOQUIkeMAAFRfBYz ?? (jWsAaYZljMxgOQUIkeMAAFRfBYz = GetComponent<RectTransform>());
			}
		}

		[CustomObfuscation(rename = false)]
		private TouchJoystickAngleIndicator()
		{
		}

		internal bool FYqANZihtIgQbnChZTLtBHGRmzL(out Vector2 P_0)
		{
			P_0 = Vector2.zero;
			Rect textureRect = default(Rect);
			while (true)
			{
				int num = -2053288623;
				while (true)
				{
					Sprite sprite;
					switch (num ^ -2053288624)
					{
					case 2:
						break;
					case 1:
						if (image == null)
						{
							return false;
						}
						sprite = UkytztfegFjxRAnWtoiQGueBHbBq.overrideSprite ?? UkytztfegFjxRAnWtoiQGueBHbBq.sprite;
						if (!(sprite == null))
						{
							goto IL_005f;
						}
						return false;
					default:
						P_0.x = textureRect.width;
						P_0.y = textureRect.height;
						return true;
					}
					break;
					IL_005f:
					textureRect = sprite.textureRect;
					num = -2053288624;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			OnTouchJoystickStickPositionChanged(Vector2.zero);
			uYzFvpGmRyWWGtLVturUCJxekis();
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (!Application.isPlaying)
			{
				while (true)
				{
					int num = -903290481;
					while (true)
					{
						switch (num ^ -903290482)
						{
						case 2:
							break;
						case 1:
							uYzFvpGmRyWWGtLVturUCJxekis();
							mwAJbHrkLrwyZOsaQsXhEmbTPQk();
							num = -903290482;
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
			KRVFzSAGLbzTcEyxGHvVNUMJQtBd(XySdAOKjAJnwmJRnyfScrRwkPM);
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			DQHwWBHiVzxXqYGEuuinzLqJNOq();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			qVsMyoYBvETfokpXbIGIpiZNXPA();
			KRVFzSAGLbzTcEyxGHvVNUMJQtBd(XySdAOKjAJnwmJRnyfScrRwkPM);
		}

		[CustomObfuscation(rename = false)]
		private void OnTransformParentChanged()
		{
			mwAJbHrkLrwyZOsaQsXhEmbTPQk();
		}

		private void SWnzUAEKhgDxxwxmMhpFBvKnnQNm(bool P_0, bool P_1)
		{
			if (_visible == P_0 && !P_1)
			{
				return;
			}
			while (true)
			{
				_visible = P_0;
				int num = -1006733799;
				while (true)
				{
					switch (num ^ -1006733798)
					{
					case 0:
						num = -1006733800;
						continue;
					case 2:
						break;
					case 3:
						if (!P_0)
						{
							Color targetColor = _normalColor;
							targetColor.a = 0f;
							image.CrossFadeColor(targetColor, 0f, true, true);
							num = -1006733794;
							continue;
						}
						goto default;
					case 4:
						return;
					default:
						KRVFzSAGLbzTcEyxGHvVNUMJQtBd(XySdAOKjAJnwmJRnyfScrRwkPM);
						return;
					}
					break;
				}
			}
		}

		private void KRVFzSAGLbzTcEyxGHvVNUMJQtBd(Vector2 P_0)
		{
			if (!_visible)
			{
				goto IL_000b;
			}
			goto IL_016f;
			IL_000b:
			int num = -995372453;
			goto IL_0010;
			IL_0010:
			float num2 = default(float);
			float target = default(float);
			float num5 = default(float);
			float magnitude = default(float);
			Color targetColor2 = default(Color);
			Color targetColor = default(Color);
			while (true)
			{
				float num4;
				float num6;
				switch (num ^ -995372449)
				{
				case 5:
					break;
				case 11:
				{
					if (!_fadeWithAngle)
					{
						goto case 1;
					}
					float num3 = Mathf.Abs(MathTools.DeltaAngle(num2, target));
					if (_fadeRange == 0f)
					{
						num = -995372458;
						continue;
					}
					num4 = MathTools.Clamp01(1f - num3 / _fadeRange);
					goto IL_0116;
				}
				case 7:
					num5 = 1f;
					if (_fadeWithValue)
					{
						num5 *= magnitude;
						num = -995372460;
						continue;
					}
					goto case 11;
				case 0:
					image.CrossFadeColor(targetColor2, 0f, true, true);
					return;
				case 10:
					image.CrossFadeColor(targetColor, 0f, true, true);
					return;
				case 1:
					targetColor2 = Color.Lerp(_normalColor, _activeColor, num5);
					num = -995372449;
					continue;
				case 9:
					num4 = 1f;
					goto IL_0116;
				case 6:
					targetColor2 = (MathTools.AngleIsNear(num2, target, _fadeRange) ? _activeColor : _normalColor);
					num = -995372449;
					continue;
				case 3:
					goto IL_0153;
				case 8:
					goto IL_016f;
				case 4:
					targetColor = _normalColor;
					targetColor.a = 0f;
					num = -995372459;
					continue;
				default:
					goto IL_020f;
					IL_0116:
					num6 = num4;
					num5 *= num6;
					num = -995372450;
					continue;
				}
				break;
				IL_0153:
				int num7;
				if (_fadeWithValue)
				{
					num = -995372456;
					num7 = num;
				}
				else
				{
					num = -995372455;
					num7 = num;
				}
			}
			goto IL_000b;
			IL_020f:
			image.CrossFadeColor(_normalColor, 0f, true, true);
			return;
			IL_016f:
			if (!MathTools.ApproximatelyZero(P_0.sqrMagnitude))
			{
				magnitude = P_0.magnitude;
				float num8 = Vector2.Angle(Vector2.up, P_0);
				target = (_targetAngleFromRotation ? base.transform.localEulerAngles.z : _targetAngle) * -1f;
				num2 = ((P_0.x < 0f) ? (360f - num8) : num8);
				int num9;
				if (_fadeWithAngle)
				{
					num = -995372456;
					num9 = num;
				}
				else
				{
					num = -995372452;
					num9 = num;
				}
				goto IL_0010;
			}
			goto IL_020f;
		}

		private void uYzFvpGmRyWWGtLVturUCJxekis()
		{
			btfgbdYZiylScewFWjvlbyDWYmd = _visible;
		}

		private void qVsMyoYBvETfokpXbIGIpiZNXPA()
		{
			if (btfgbdYZiylScewFWjvlbyDWYmd == _visible)
			{
				return;
			}
			btfgbdYZiylScewFWjvlbyDWYmd = _visible;
			while (true)
			{
				int num = -780376784;
				while (true)
				{
					switch (num ^ -780376782)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0038;
					case 1:
						return;
					}
					break;
					IL_0038:
					SWnzUAEKhgDxxwxmMhpFBvKnnQNm(_visible, true);
					num = -780376781;
				}
			}
		}

		private void wQiEPKGVkSYAiCZoyTUamohUIKKd()
		{
		}

		private void mwAJbHrkLrwyZOsaQsXhEmbTPQk()
		{
			DQHwWBHiVzxXqYGEuuinzLqJNOq();
			IRegistrar<TouchJoystickAngleIndicator> componentInSelfOrParents = default(IRegistrar<TouchJoystickAngleIndicator>);
			while (true)
			{
				int num = -1951954645;
				while (true)
				{
					switch (num ^ -1951954647)
					{
					case 0:
						break;
					case 2:
					{
						componentInSelfOrParents = UnityTools.GetComponentInSelfOrParents<IRegistrar<TouchJoystickAngleIndicator>>(base.transform);
						int num2;
						if (componentInSelfOrParents.IsNullOrDestroyed())
						{
							num = -1951954646;
							num2 = num;
						}
						else
						{
							num = -1951954648;
							num2 = num;
						}
						continue;
					}
					case 3:
						return;
					default:
						componentInSelfOrParents.Register(this);
						AbOcnoXWPhAHWAUcZjcsWpKNXSTc = componentInSelfOrParents;
						return;
					}
					break;
				}
			}
		}

		private void DQHwWBHiVzxXqYGEuuinzLqJNOq()
		{
			if (AbOcnoXWPhAHWAUcZjcsWpKNXSTc.IsNullOrDestroyed())
			{
				if (AbOcnoXWPhAHWAUcZjcsWpKNXSTc != null)
				{
					AbOcnoXWPhAHWAUcZjcsWpKNXSTc = null;
					goto IL_001c;
				}
				return;
			}
			goto IL_0046;
			IL_0021:
			int num;
			switch (num ^ -955893602)
			{
			case 2:
				break;
			case 1:
				return;
			case 0:
				goto IL_0046;
			default:
				AbOcnoXWPhAHWAUcZjcsWpKNXSTc = null;
				return;
			}
			goto IL_001c;
			IL_0046:
			AbOcnoXWPhAHWAUcZjcsWpKNXSTc.Deregister(this);
			num = -955893603;
			goto IL_0021;
			IL_001c:
			num = -955893601;
			goto IL_0021;
		}

		public void OnVisibilityChanged(bool state)
		{
			SWnzUAEKhgDxxwxmMhpFBvKnnQNm(state, false);
		}

		public void OnTouchJoystickStickPositionChanged(Vector2 value)
		{
			if (this == null)
			{
				goto IL_0009;
			}
			goto IL_004d;
			IL_0009:
			int num = 98112556;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x5D9142D)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					return;
				case 5:
					KRVFzSAGLbzTcEyxGHvVNUMJQtBd(value);
					num = 98112555;
					continue;
				case 3:
					goto IL_004d;
				case 4:
					goto IL_0064;
				case 0:
					return;
				case 6:
					return;
				}
				break;
			}
			goto IL_0009;
			IL_004d:
			XySdAOKjAJnwmJRnyfScrRwkPM = value;
			if (!UnityTools.IsActiveAndEnabled(this))
			{
				return;
			}
			goto IL_0064;
			IL_0064:
			int num2;
			if (_visible)
			{
				num = 98112552;
				num2 = num;
			}
			else
			{
				num = 98112557;
				num2 = num;
			}
			goto IL_000e;
		}

		void TouchJoystick.IStickPositionChangedHandler.OnStickPositionChanged(Vector2 P_0)
		{
			OnTouchJoystickStickPositionChanged(P_0);
		}
	}
}
