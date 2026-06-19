using Rewired.UI;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(Image))]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Controls/Effects/Touch Joystick Angle Indicator")]
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

		[Tooltip("The joystick angle at which this object should be considered fully active.\n0 = up with negative values increase rotating clockwise. Example: -45 degrees = up-right.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, -360f)]
		private float _targetAngle;

		[Tooltip("If enabled, the color will fade in and out based on the current joystick value.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _fadeWithValue = true;

		[Tooltip("If enabled, the color will fade in and out based on the current joystick angle. As the angle approaches the Target Angle, the color will become more intense.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _fadeWithAngle = true;

		[Tooltip("The angle of rotation away from the Target Angle where the color fully fades out. If Fade with Angle is enabled, this is used to determine when the color will fully fade out when the joystick angle rotates away from the the Target Angle. This should be set to 1/2 of the complete rotation arc. Example: A value of 45 degrees would make the color fully fade out when the joystick angle is 45 degrees away from the Target Angle on either side, giving a complete arc of 90 degrees.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 360f)]
		private float _fadeRange = 45f;

		[Tooltip("The color when fully active.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Color _activeColor = new Color(1f, 1f, 1f, 1f);

		[Tooltip("The color when not active.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Color _normalColor = new Color(1f, 1f, 1f, 0.3f);

		private Image tmCGinMcNYtZnKOLphbEGjfzGIJDA;

		private RectTransform wxczKgkwoXSjSCTxNqvaWuCcQyCu;

		private Vector2 yHBJJKjDAbWrXzZQYuSZfESxiEeF;

		private bool RDxNyiDjdTGSOwDyhlsSvLLyneXr;

		private IRegistrar<TouchJoystickAngleIndicator> umcJcsMGFcwfnpXGivFgStObryuu;

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
					YdooYrVzvcXvVYVWzvkGWCbDqbAh(value, false);
					QxdvCsegRrSJBzxSyuBDrjElbsGr();
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
					QxdvCsegRrSJBzxSyuBDrjElbsGr();
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
					QxdvCsegRrSJBzxSyuBDrjElbsGr();
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
					QxdvCsegRrSJBzxSyuBDrjElbsGr();
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
					QxdvCsegRrSJBzxSyuBDrjElbsGr();
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
					QxdvCsegRrSJBzxSyuBDrjElbsGr();
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
				QxdvCsegRrSJBzxSyuBDrjElbsGr();
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
				QxdvCsegRrSJBzxSyuBDrjElbsGr();
			}
		}

		internal Image FrJxqCSRGedcwfyNpYTArFTuWYWf => tmCGinMcNYtZnKOLphbEGjfzGIJDA ?? (tmCGinMcNYtZnKOLphbEGjfzGIJDA = GetComponent<Image>());

		internal Sprite XvbCmaFoFeUaLKsRLLbLjyXHntXHc
		{
			get
			{
				if (FrJxqCSRGedcwfyNpYTArFTuWYWf == null)
				{
					return null;
				}
				if (tmCGinMcNYtZnKOLphbEGjfzGIJDA.overrideSprite != null)
				{
					return tmCGinMcNYtZnKOLphbEGjfzGIJDA.overrideSprite;
				}
				return tmCGinMcNYtZnKOLphbEGjfzGIJDA.sprite;
			}
		}

		internal RectTransform nFwuNngLrHbPvXYrFUfjNBkJJwgA => wxczKgkwoXSjSCTxNqvaWuCcQyCu ?? (wxczKgkwoXSjSCTxNqvaWuCcQyCu = GetComponent<RectTransform>());

		[CustomObfuscation(rename = false)]
		private TouchJoystickAngleIndicator()
		{
		}

		internal bool CvfOkbgwjFIcCrAbCmODkHaUYj(out Vector2 P_0)
		{
			P_0 = Vector2.zero;
			if (FrJxqCSRGedcwfyNpYTArFTuWYWf == null)
			{
				return false;
			}
			Sprite sprite = tmCGinMcNYtZnKOLphbEGjfzGIJDA.overrideSprite ?? tmCGinMcNYtZnKOLphbEGjfzGIJDA.sprite;
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
			vhqUzZLRYkZmxfOkwKEwdeCWHsqj();
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			if (!Application.isPlaying)
			{
				vhqUzZLRYkZmxfOkwKEwdeCWHsqj();
				NBvRubsKVJHBtahcBluQKFVCJXKs();
			}
			XyPjszTIPrPRSPnHqCIeuMRczVME(yHBJJKjDAbWrXzZQYuSZfESxiEeF);
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
			gVLAYtfbmHeWzhAakaDbDwaYDRWqA();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			oxOkxAnpRdwPAKQBMhURqqajRhQf();
			XyPjszTIPrPRSPnHqCIeuMRczVME(yHBJJKjDAbWrXzZQYuSZfESxiEeF);
		}

		[CustomObfuscation(rename = false)]
		private void OnTransformParentChanged()
		{
			NBvRubsKVJHBtahcBluQKFVCJXKs();
		}

		private void YdooYrVzvcXvVYVWzvkGWCbDqbAh(bool P_0, bool P_1)
		{
			if (_visible != P_0 || P_1)
			{
				_visible = P_0;
				if (!P_0)
				{
					Color targetColor = _normalColor;
					targetColor.a = 0f;
					FrJxqCSRGedcwfyNpYTArFTuWYWf.CrossFadeColor(targetColor, 0f, ignoreTimeScale: true, useAlpha: true);
				}
				else
				{
					XyPjszTIPrPRSPnHqCIeuMRczVME(yHBJJKjDAbWrXzZQYuSZfESxiEeF);
				}
			}
		}

		private void XyPjszTIPrPRSPnHqCIeuMRczVME(Vector2 P_0)
		{
			if (!_visible)
			{
				Color targetColor = _normalColor;
				targetColor.a = 0f;
				FrJxqCSRGedcwfyNpYTArFTuWYWf.CrossFadeColor(targetColor, 0f, ignoreTimeScale: true, useAlpha: true);
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
				FrJxqCSRGedcwfyNpYTArFTuWYWf.CrossFadeColor(targetColor2, 0f, ignoreTimeScale: true, useAlpha: true);
			}
			else
			{
				FrJxqCSRGedcwfyNpYTArFTuWYWf.CrossFadeColor(_normalColor, 0f, ignoreTimeScale: true, useAlpha: true);
			}
		}

		private void vhqUzZLRYkZmxfOkwKEwdeCWHsqj()
		{
			RDxNyiDjdTGSOwDyhlsSvLLyneXr = _visible;
		}

		private void oxOkxAnpRdwPAKQBMhURqqajRhQf()
		{
			if (RDxNyiDjdTGSOwDyhlsSvLLyneXr != _visible)
			{
				RDxNyiDjdTGSOwDyhlsSvLLyneXr = _visible;
				YdooYrVzvcXvVYVWzvkGWCbDqbAh(_visible, true);
			}
		}

		private void QxdvCsegRrSJBzxSyuBDrjElbsGr()
		{
		}

		private void NBvRubsKVJHBtahcBluQKFVCJXKs()
		{
			gVLAYtfbmHeWzhAakaDbDwaYDRWqA();
			IRegistrar<TouchJoystickAngleIndicator> componentInSelfOrParents = UnityTools.GetComponentInSelfOrParents<IRegistrar<TouchJoystickAngleIndicator>>(base.transform);
			if (!componentInSelfOrParents.IsNullOrDestroyed())
			{
				componentInSelfOrParents.Register(this);
				umcJcsMGFcwfnpXGivFgStObryuu = componentInSelfOrParents;
			}
		}

		private void gVLAYtfbmHeWzhAakaDbDwaYDRWqA()
		{
			if (umcJcsMGFcwfnpXGivFgStObryuu.IsNullOrDestroyed())
			{
				if (umcJcsMGFcwfnpXGivFgStObryuu != null)
				{
					umcJcsMGFcwfnpXGivFgStObryuu = null;
				}
			}
			else
			{
				umcJcsMGFcwfnpXGivFgStObryuu.Deregister(this);
				umcJcsMGFcwfnpXGivFgStObryuu = null;
			}
		}

		public void OnVisibilityChanged(bool state)
		{
			YdooYrVzvcXvVYVWzvkGWCbDqbAh(state, false);
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
				yHBJJKjDAbWrXzZQYuSZfESxiEeF = value;
				if (UnityTools.IsActiveAndEnabled(this) && _visible)
				{
					XyPjszTIPrPRSPnHqCIeuMRczVME(value);
				}
			}
		}

		void TouchJoystick.IStickPositionChangedHandler.OnStickPositionChanged(Vector2 value)
		{
			OnTouchJoystickStickPositionChanged(value);
		}
	}
}
