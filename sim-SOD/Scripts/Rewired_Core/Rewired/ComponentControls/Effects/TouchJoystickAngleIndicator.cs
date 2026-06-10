using Rewired.UI;
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
		[SerializeField]
		[Tooltip("Toggles visibility.")]
		[CustomObfuscation(rename = false)]
		private bool _visible;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the target angle will be determined by the transform's Local Rotation Z. Otherwise, the activation angle must be manually set.")]
		private bool _targetAngleFromRotation;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Range(0f, -360f)]
		[Tooltip("The joystick angle at which this object should be considered fully active.\n0 = up with negative values increase rotating clockwise. Example: -45 degrees = up-right.")]
		private float _targetAngle;

		[Tooltip("If enabled, the color will fade in and out based on the current joystick value.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _fadeWithValue;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If enabled, the color will fade in and out based on the current joystick angle. As the angle approaches the Target Angle, the color will become more intense.")]
		private bool _fadeWithAngle;

		[Range(0f, 360f)]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The angle of rotation away from the Target Angle where the color fully fades out. If Fade with Angle is enabled, this is used to determine when the color will fully fade out when the joystick angle rotates away from the the Target Angle. This should be set to 1/2 of the complete rotation arc. Example: A value of 45 degrees would make the color fully fade out when the joystick angle is 45 degrees away from the Target Angle on either side, giving a complete arc of 90 degrees.")]
		private float _fadeRange;

		[Tooltip("The color when fully active.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private Color _activeColor;

		[Tooltip("The color when not active.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Color _normalColor;

		private Image wlzmEHRRweTQKtgSSHBAZZKzmdD;

		private RectTransform NwxVgjrddvQTmUEHTrEOnbmNGns;

		private Vector2 lIjMNckazpHIvkdHWaGENRlQJFM;

		private bool HxeCDFijRZGZvoKkpeWxUSKsAQpB;

		private IRegistrar<TouchJoystickAngleIndicator> aADiUAhhLUCzJAWmuSRaWEsrKWND;

		public bool visible
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool targetAngleFromRotation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float targetAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool fadeWithValue
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool fadeWithAngle
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float fadeRange
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public Color activeColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		public Color normalColor
		{
			get
			{
				return default(Color);
			}
			set
			{
			}
		}

		internal Image image => null;

		internal Sprite currentSprite => null;

		internal RectTransform rectTransform => null;

		[CustomObfuscation(rename = false)]
		private TouchJoystickAngleIndicator()
		{
		}

		internal bool rudgzDKjSduuZtxEgmboeuUzhRX(out Vector2 P_0)
		{
			P_0 = default(Vector2);
			return false;
		}

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnDisable()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnTransformParentChanged()
		{
		}

		private void gzwPpsgHxRCLyyPctkGHOamHQYX(bool P_0, bool P_1)
		{
		}

		private void eSSjIuaoLGdlnGsjnUALQfylmvLQ(Vector2 P_0)
		{
		}

		private void EbeocBoRVXuOBhBJOHuWpNRKanm()
		{
		}

		private void AyfhvAcnUrtFhwPRMjnYEritBQA()
		{
		}

		private void ILfKseeIovFotfIwVedwwNJgiCCt()
		{
		}

		private void SaRIGhhPDKxSAjGgrCirqrHdXYuQ()
		{
		}

		private void rSQXwtjFKQDcfCjMJRAfUNGdDNw()
		{
		}

		public void OnVisibilityChanged(bool state)
		{
		}

		public void OnTouchJoystickStickPositionChanged(Vector2 value)
		{
		}

		private void iSkuRGeLdmEOVPWMERnVPqHQSKG(Vector2 P_0)
		{
		}

		void TouchJoystick.IStickPositionChangedHandler.OnStickPositionChanged(Vector2 P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in iSkuRGeLdmEOVPWMERnVPqHQSKG
			this.iSkuRGeLdmEOVPWMERnVPqHQSKG(P_0);
		}
	}
}
