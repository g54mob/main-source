using Rewired.UI;
using Rewired.Utils.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public sealed class TouchJoystickAngleIndicator : MonoBehaviour, IVisibilityChangedHandler, TouchJoystick.IStickPositionChangedHandler
	{
		[CustomObfuscation]
		[SerializeField]
		private bool _visible;

		[SerializeField]
		[CustomObfuscation]
		private bool _targetAngleFromRotation;

		[CustomObfuscation]
		[SerializeField]
		private float _targetAngle;

		[SerializeField]
		[CustomObfuscation]
		private bool _fadeWithValue;

		[SerializeField]
		[CustomObfuscation]
		private bool _fadeWithAngle;

		[SerializeField]
		[CustomObfuscation]
		private float _fadeRange;

		[CustomObfuscation]
		[SerializeField]
		private Color _activeColor;

		[CustomObfuscation]
		[SerializeField]
		private Color _normalColor;

		private Image fqKgUyxLOUYlUhqSYmUopivWxBN;

		private RectTransform MHMDhXFuBRbRPAWQVXOoVRSmmOn;

		private Vector2 sqCIuHSBLDeIzFsXWXzmnnUroJQW;

		private bool KQHDtsSbbpAEldcchJjHgwfTyKv;

		private IRegistrar<TouchJoystickAngleIndicator> hTmmvxRczeqpJGdqsEyGwgBYdAVj;

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

		[CustomObfuscation]
		private TouchJoystickAngleIndicator()
		{
		}

		internal bool yFODCWkoVTOvqndrcvHVgYDGopB(out Vector2 P_0)
		{
			P_0 = default(Vector2);
			return false;
		}

		[CustomObfuscation]
		private void Awake()
		{
		}

		[CustomObfuscation]
		private void OnEnable()
		{
		}

		[CustomObfuscation]
		private void OnDisable()
		{
		}

		[CustomObfuscation]
		private void OnValidate()
		{
		}

		[CustomObfuscation]
		private void OnTransformParentChanged()
		{
		}

		private void xPPTbJYPHhGHieHgnbzxiTVuGUP(bool P_0, bool P_1)
		{
		}

		private void pKfcQTGzbyqtfihxpzffLaRQzbP(Vector2 P_0)
		{
		}

		private void RXFSKeWuzpqbJbmNCnoaJjqhFmmh()
		{
		}

		private void BVSVBdUCXJIidkvFIsSmkeGGbXK()
		{
		}

		private void DDSYIBWFCFbxtAeyTbUKilaTRGQv()
		{
		}

		private void FmreSivlsALOtMureZRdFwSrAqh()
		{
		}

		private void gDlAhIhTrcVIrHUGLqoXKilKnHsd()
		{
		}

		public void OnVisibilityChanged(bool state)
		{
		}

		public void OnTouchJoystickStickPositionChanged(Vector2 value)
		{
		}

		private void pDZZUfIDzQBBJcXCKggFAtNzSICg(Vector2 P_0)
		{
		}

		void TouchJoystick.IStickPositionChangedHandler.OnStickPositionChanged(Vector2 P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in pDZZUfIDzQBBJcXCKggFAtNzSICg
			this.pDZZUfIDzQBBJcXCKggFAtNzSICg(P_0);
		}
	}
}
