using Rewired.UI;
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
		private bool _visible;

		[Tooltip("If enabled, the target angle will be determined by the transform's Local Rotation Z. Otherwise, the activation angle must be manually set.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _targetAngleFromRotation;

		[Tooltip("The joystick angle at which this object should be considered fully active.\n0 = up with negative values increase rotating clockwise. Example: -45 degrees = up-right.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, -360f)]
		private float _targetAngle;

		[Tooltip("If enabled, the color will fade in and out based on the current joystick value.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _fadeWithValue;

		[Tooltip("If enabled, the color will fade in and out based on the current joystick angle. As the angle approaches the Target Angle, the color will become more intense.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _fadeWithAngle;

		[Tooltip("The angle of rotation away from the Target Angle where the color fully fades out. If Fade with Angle is enabled, this is used to determine when the color will fully fade out when the joystick angle rotates away from the the Target Angle. This should be set to 1/2 of the complete rotation arc. Example: A value of 45 degrees would make the color fully fade out when the joystick angle is 45 degrees away from the Target Angle on either side, giving a complete arc of 90 degrees.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Range(0f, 360f)]
		private float _fadeRange;

		[Tooltip("The color when fully active.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Color _activeColor;

		[Tooltip("The color when not active.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Color _normalColor;

		private Image rTKaDieSCjkmOYVCtfvFXFRRBjfhA;

		private RectTransform mIkpnfYlMkURjWwaBdYbRucQFPqd;

		private Vector2 kyHTkVPDRUSxqbrJCKyKudgDZXSM;

		private bool TcpBazdEiuhbtkznvIqPipjIqFpP;

		private IRegistrar<TouchJoystickAngleIndicator> kTwHOjcAQLjWIfCLuxZlTXcTBJIW;

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

		internal Image BpLoMHmLHHgCNrNUvqOViqpWefwR => null;

		internal Sprite NKnHpdCCZLBcCgAiZdbChlORKhbC => null;

		internal RectTransform tLHfDIfCUMPImTRPdqIsmEjODgGQA => null;

		[CustomObfuscation(rename = false)]
		private TouchJoystickAngleIndicator()
		{
		}

		internal bool EgMHCghQaBMGpfkHKErnWFCcbPglb(out Vector2 P_0)
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

		private void GCwYHgvMyFamgKwQlXbRZlcfdXgfA(bool P_0, bool P_1)
		{
		}

		private void NHTxImtyRCPeuVkkkRItpqwCAIiq(Vector2 P_0)
		{
		}

		private void lYwlfKdiPTmoQvBXasIbancaeaAQ()
		{
		}

		private void uIKyPLJWmYwBlQoXMsnSjGCLGswz()
		{
		}

		private void OIxWElCpIIkradrBiAkOolsVDZeq()
		{
		}

		private void XexLjgKpYiaxCqTfHeiZBFxsGgwT()
		{
		}

		private void ykJGfmXxtuFfWxtlyPTivwUccaqu()
		{
		}

		public void OnVisibilityChanged(bool state)
		{
		}

		public void OnTouchJoystickStickPositionChanged(Vector2 value)
		{
		}

		void TouchJoystick.IStickPositionChangedHandler.OnStickPositionChanged(Vector2 value)
		{
		}
	}
}
