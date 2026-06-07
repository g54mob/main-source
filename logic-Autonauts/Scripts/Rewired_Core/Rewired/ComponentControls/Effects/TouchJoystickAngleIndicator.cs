using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Image))]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(RectTransform))]
	public sealed class TouchJoystickAngleIndicator : MonoBehaviour, IVisibilityChangedHandler, TouchJoystick.IStickPositionChangedHandler
	{
		[Tooltip("Toggles visibility.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _visible = true;

		[Tooltip("If enabled, the target angle will be determined by the transform's Local Rotation Z. Otherwise, the activation angle must be manually set.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _targetAngleFromRotation = true;

		[Range(0f, -360f)]
		[Tooltip("The joystick angle at which this object should be considered fully active.\n0 = up with negative values increase rotating clockwise. Example: -45 degrees = up-right.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private float _targetAngle;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the color will fade in and out based on the current joystick value.")]
		private bool _fadeWithValue = true;

		[SerializeField]
		[Tooltip("If enabled, the color will fade in and out based on the current joystick angle. As the angle approaches the Target Angle, the color will become more intense.")]
		[CustomObfuscation(rename = false)]
		private bool _fadeWithAngle = true;

		[Tooltip("The angle of rotation away from the Target Angle where the color fully fades out. If Fade with Angle is enabled, this is used to determine when the color will fully fade out when the joystick angle rotates away from the the Target Angle. This should be set to 1/2 of the complete rotation arc. Example: A value of 45 degrees would make the color fully fade out when the joystick angle is 45 degrees away from the Target Angle on either side, giving a complete arc of 90 degrees.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 360f)]
		private float _fadeRange = 45f;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The color when fully active.")]
		private Color _activeColor = new Color(1f, 1f, 1f, 1f);

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The color when not active.")]
		private Color _normalColor = new Color(1f, 1f, 1f, 0.3f);

		private Image jCgdcsJJiHDAaMDFRsiUgVoVHsWl;

		private RectTransform YncvgNpHbAbJtmjXIuIOrVLnpRs;

		private Vector2 sWmwnXelXSEFTKQCHhhIDbVgWdN;

		private bool MHjfmwwNoiUxJWnGkzcjKeiQXIq;

		private IRegistrar<TouchJoystickAngleIndicator> loYsuvdHHdCubasdjDksUFGFzTQ;

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
					fLfGNTIuzupCCAOzuPlZdWUzABYV(value, false);
					int num = 740474793;
					while (true)
					{
						switch (num ^ 0x2C22BFAB)
						{
						case 3:
							num = 740474794;
							continue;
						default:
							return;
						case 1:
							break;
						case 2:
							TzavSRkIcUdUXyGrWDQoLGzUgZXD();
							num = 740474795;
							continue;
						case 0:
							return;
						}
						break;
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
				if (_targetAngleFromRotation != value)
				{
					_targetAngleFromRotation = value;
					TzavSRkIcUdUXyGrWDQoLGzUgZXD();
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
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = -1440610616;
				goto IL_000e;
				IL_000e:
				switch (num ^ -1440610613)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					return;
				case 2:
					goto IL_0033;
				case 1:
					return;
				}
				goto IL_0009;
				IL_0033:
				_targetAngle = value;
				TzavSRkIcUdUXyGrWDQoLGzUgZXD();
				num = -1440610614;
				goto IL_000e;
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
					TzavSRkIcUdUXyGrWDQoLGzUgZXD();
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
					TzavSRkIcUdUXyGrWDQoLGzUgZXD();
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
					return;
				}
				while (true)
				{
					_fadeRange = value;
					int num = -273687753;
					while (true)
					{
						switch (num ^ -273687754)
						{
						case 0:
							goto IL_000a;
						case 2:
							break;
						default:
							TzavSRkIcUdUXyGrWDQoLGzUgZXD();
							return;
						}
						break;
						IL_000a:
						num = -273687756;
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
				TzavSRkIcUdUXyGrWDQoLGzUgZXD();
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
				TzavSRkIcUdUXyGrWDQoLGzUgZXD();
			}
		}

		internal Image image
		{
			get
			{
				return jCgdcsJJiHDAaMDFRsiUgVoVHsWl ?? (jCgdcsJJiHDAaMDFRsiUgVoVHsWl = GetComponent<Image>());
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
				if (jCgdcsJJiHDAaMDFRsiUgVoVHsWl.overrideSprite != null)
				{
					return jCgdcsJJiHDAaMDFRsiUgVoVHsWl.overrideSprite;
				}
				return jCgdcsJJiHDAaMDFRsiUgVoVHsWl.sprite;
			}
		}

		internal RectTransform rectTransform
		{
			get
			{
				return YncvgNpHbAbJtmjXIuIOrVLnpRs ?? (YncvgNpHbAbJtmjXIuIOrVLnpRs = GetComponent<RectTransform>());
			}
		}

		[CustomObfuscation(rename = false)]
		private TouchJoystickAngleIndicator()
		{
		}

		internal bool qkeYeOQbfKKvGHDcjvPfoqOTmaO(out Vector2 P_0)
		{
			P_0 = Vector2.zero;
			if (image == null)
			{
				goto IL_0019;
			}
			Sprite sprite = jCgdcsJJiHDAaMDFRsiUgVoVHsWl.overrideSprite ?? jCgdcsJJiHDAaMDFRsiUgVoVHsWl.sprite;
			int num;
			Rect textureRect = default(Rect);
			if (sprite == null)
			{
				num = -1667998325;
			}
			else
			{
				textureRect = sprite.textureRect;
				num = -1667998322;
			}
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -1667998321)
				{
				case 2:
					break;
				case 3:
					return false;
				case 1:
					goto IL_006c;
				case 4:
					return false;
				default:
					P_0.y = textureRect.height;
					return true;
				}
				break;
				IL_006c:
				P_0.x = textureRect.width;
				num = -1667998321;
			}
			goto IL_0019;
			IL_0019:
			num = -1667998324;
			goto IL_001e;
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			OnTouchJoystickStickPositionChanged(Vector2.zero);
			LDrBKgwaHyVbhFZOTGuIfdzycptJ();
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (!Application.isPlaying)
			{
				LDrBKgwaHyVbhFZOTGuIfdzycptJ();
				goto IL_000d;
			}
			goto IL_003c;
			IL_003c:
			fUNwyPiQHpCgFGVagovJrHYBssQ(sWmwnXelXSEFTKQCHhhIDbVgWdN);
			int num = 412964212;
			goto IL_0012;
			IL_000d:
			num = 412964214;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x189D5577)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					TkWQuGXYBrjLcgLpsiRxEzxVVDfg();
					num = 412964215;
					continue;
				case 0:
					goto IL_003c;
				case 3:
					return;
				}
				break;
			}
			goto IL_000d;
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			qIJpuUrFHpCGXykJEzgdUUqDiWn();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			TJyJGniZjWcyLYCUZGcAWcZXGRH();
			fUNwyPiQHpCgFGVagovJrHYBssQ(sWmwnXelXSEFTKQCHhhIDbVgWdN);
		}

		[CustomObfuscation(rename = false)]
		private void OnTransformParentChanged()
		{
			TkWQuGXYBrjLcgLpsiRxEzxVVDfg();
		}

		private void fLfGNTIuzupCCAOzuPlZdWUzABYV(bool P_0, bool P_1)
		{
			if (_visible == P_0 && !P_1)
			{
				return;
			}
			while (true)
			{
				_visible = P_0;
				if (!P_0)
				{
					break;
				}
				while (true)
				{
					IL_0067:
					fUNwyPiQHpCgFGVagovJrHYBssQ(sWmwnXelXSEFTKQCHhhIDbVgWdN);
					int num = -767849206;
					while (true)
					{
						switch (num ^ -767849208)
						{
						case 3:
							num = -767849207;
							continue;
						default:
							return;
						case 1:
							break;
						case 0:
							goto IL_0067;
						case 2:
							return;
						}
						break;
					}
					break;
				}
			}
			Color targetColor = _normalColor;
			targetColor.a = 0f;
			image.CrossFadeColor(targetColor, 0f, true, true);
		}

		private void fUNwyPiQHpCgFGVagovJrHYBssQ(Vector2 P_0)
		{
			Color targetColor = default(Color);
			if (!_visible)
			{
				targetColor = _normalColor;
				targetColor.a = 0f;
				goto IL_001e;
			}
			goto IL_0205;
			IL_0205:
			int num;
			int num2;
			if (MathTools.ApproximatelyZero(P_0.sqrMagnitude))
			{
				num = 1893669560;
				num2 = num;
			}
			else
			{
				num = 1893669565;
				num2 = num;
			}
			goto IL_0023;
			IL_001e:
			num = 1893669555;
			goto IL_0023;
			IL_0023:
			Color targetColor2 = default(Color);
			float magnitude = default(float);
			float num7 = default(float);
			float target = default(float);
			float num4 = default(float);
			float num6 = default(float);
			while (true)
			{
				float num3;
				float num8;
				switch (num ^ 0x70DF1AB9)
				{
				case 12:
					break;
				case 5:
					image.CrossFadeColor(targetColor2, 0f, true, true);
					return;
				case 4:
					magnitude = P_0.magnitude;
					num7 = Vector2.Angle(Vector2.up, P_0);
					target = (_targetAngleFromRotation ? base.transform.localEulerAngles.z : _targetAngle) * -1f;
					num = 1893669552;
					continue;
				case 6:
					goto IL_00d4;
				case 13:
					goto IL_00fb;
				case 0:
					num4 *= magnitude;
					num = 1893669556;
					continue;
				case 9:
					num6 = ((P_0.x < 0f) ? (360f - num7) : num7);
					num = 1893669567;
					continue;
				case 8:
					targetColor2 = (MathTools.AngleIsNear(num6, target, _fadeRange) ? _activeColor : _normalColor);
					num = 1893669564;
					continue;
				case 15:
					goto IL_0175;
				case 10:
					image.CrossFadeColor(targetColor, 0f, true, true);
					return;
				case 14:
				{
					float num5 = Mathf.Abs(MathTools.DeltaAngle(num6, target));
					if (_fadeRange == 0f)
					{
						num = 1893669563;
						continue;
					}
					num3 = MathTools.Clamp01(1f - num5 / _fadeRange);
					goto IL_0242;
				}
				case 3:
					targetColor2 = Color.Lerp(_normalColor, _activeColor, num4);
					num = 1893669566;
					continue;
				case 7:
					num = 1893669564;
					continue;
				case 11:
					goto IL_0205;
				case 2:
					num3 = 1f;
					goto IL_0242;
				default:
					{
						image.CrossFadeColor(_normalColor, 0f, true, true);
						return;
					}
					IL_0242:
					num8 = num3;
					num4 *= num8;
					num = 1893669562;
					continue;
				}
				break;
				IL_00fb:
				int num9;
				if (!_fadeWithAngle)
				{
					num = 1893669562;
					num9 = num;
				}
				else
				{
					num = 1893669559;
					num9 = num;
				}
				continue;
				IL_00d4:
				if (!_fadeWithAngle)
				{
					int num10;
					if (_fadeWithValue)
					{
						num = 1893669558;
						num10 = num;
					}
					else
					{
						num = 1893669553;
						num10 = num;
					}
					continue;
				}
				goto IL_0175;
				IL_0175:
				num4 = 1f;
				int num11;
				if (!_fadeWithValue)
				{
					num = 1893669556;
					num11 = num;
				}
				else
				{
					num = 1893669561;
					num11 = num;
				}
			}
			goto IL_001e;
		}

		private void LDrBKgwaHyVbhFZOTGuIfdzycptJ()
		{
			MHjfmwwNoiUxJWnGkzcjKeiQXIq = _visible;
		}

		private void TJyJGniZjWcyLYCUZGcAWcZXGRH()
		{
			if (MHjfmwwNoiUxJWnGkzcjKeiQXIq == _visible)
			{
				return;
			}
			while (true)
			{
				int num = -347870604;
				while (true)
				{
					switch (num ^ -347870603)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_002c;
					case 2:
						return;
					}
					break;
					IL_002c:
					MHjfmwwNoiUxJWnGkzcjKeiQXIq = _visible;
					fLfGNTIuzupCCAOzuPlZdWUzABYV(_visible, true);
					num = -347870601;
				}
			}
		}

		private void TzavSRkIcUdUXyGrWDQoLGzUgZXD()
		{
		}

		private void TkWQuGXYBrjLcgLpsiRxEzxVVDfg()
		{
			qIJpuUrFHpCGXykJEzgdUUqDiWn();
			IRegistrar<TouchJoystickAngleIndicator> componentInSelfOrParents = UnityTools.GetComponentInSelfOrParents<IRegistrar<TouchJoystickAngleIndicator>>(base.transform);
			while (true)
			{
				int num = -1931332901;
				while (true)
				{
					switch (num ^ -1931332903)
					{
					case 0:
						break;
					case 2:
					{
						int num2;
						if (!componentInSelfOrParents.IsNullOrDestroyed())
						{
							num = -1931332902;
							num2 = num;
						}
						else
						{
							num = -1931332904;
							num2 = num;
						}
						continue;
					}
					case 1:
						return;
					default:
						componentInSelfOrParents.Register(this);
						loYsuvdHHdCubasdjDksUFGFzTQ = componentInSelfOrParents;
						return;
					}
					break;
				}
			}
		}

		private void qIJpuUrFHpCGXykJEzgdUUqDiWn()
		{
			if (loYsuvdHHdCubasdjDksUFGFzTQ.IsNullOrDestroyed())
			{
				if (loYsuvdHHdCubasdjDksUFGFzTQ == null)
				{
					return;
				}
				while (true)
				{
					int num = 500191167;
					while (true)
					{
						switch (num ^ 0x1DD04FBE)
						{
						case 2:
							break;
						case 1:
							loYsuvdHHdCubasdjDksUFGFzTQ = null;
							num = 500191165;
							continue;
						case 3:
							return;
						default:
							goto end_IL_0015;
						}
						break;
					}
					continue;
					end_IL_0015:
					break;
				}
			}
			loYsuvdHHdCubasdjDksUFGFzTQ.Deregister(this);
			loYsuvdHHdCubasdjDksUFGFzTQ = null;
		}

		public void OnVisibilityChanged(bool state)
		{
			fLfGNTIuzupCCAOzuPlZdWUzABYV(state, false);
		}

		public void OnTouchJoystickStickPositionChanged(Vector2 value)
		{
			if (this == null)
			{
				goto IL_0009;
			}
			goto IL_005c;
			IL_0009:
			int num = 2115539969;
			goto IL_000e;
			IL_000e:
			switch (num ^ 0x7E189400)
			{
			case 2:
				break;
			case 3:
				goto IL_0033;
			case 4:
				return;
			case 1:
				return;
			case 0:
				goto IL_005c;
			default:
				fUNwyPiQHpCgFGVagovJrHYBssQ(value);
				return;
			}
			goto IL_0009;
			IL_005c:
			sWmwnXelXSEFTKQCHhhIDbVgWdN = value;
			if (!UnityTools.IsActiveAndEnabled(this))
			{
				return;
			}
			goto IL_0033;
			IL_0033:
			int num2;
			if (!_visible)
			{
				num = 2115539972;
				num2 = num;
			}
			else
			{
				num = 2115539973;
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
