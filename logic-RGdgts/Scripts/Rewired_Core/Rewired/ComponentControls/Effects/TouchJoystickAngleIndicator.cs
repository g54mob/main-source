using Rewired.UI;
using Rewired.Utils.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.ComponentControls.Effects
{
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public sealed class TouchJoystickAngleIndicator : MonoBehaviour, TouchJoystick.IStickPositionChangedHandler, IVisibilityChangedHandler
	{
		[SerializeField]
		[CustomObfuscation]
		private bool _visible;

		[SerializeField]
		[CustomObfuscation]
		private bool _targetAngleFromRotation;

		[SerializeField]
		[CustomObfuscation]
		private float _targetAngle;

		[CustomObfuscation]
		[SerializeField]
		private bool _fadeWithValue;

		[CustomObfuscation]
		[SerializeField]
		private bool _fadeWithAngle;

		[CustomObfuscation]
		[SerializeField]
		private float _fadeRange;

		[SerializeField]
		[CustomObfuscation]
		private Color _activeColor;

		[SerializeField]
		[CustomObfuscation]
		private Color _normalColor;

		private Image calXLUBskMwDuzBaLatDKNrcmWEX;

		private RectTransform HLlUndjcbPBAjWfmKyTHloUCXtqV;

		private Vector2 nufTjowxdRBNPyzhJaDABWrTmXpb;

		private bool VHeMOnaFGtBHrgWKsqenUjgffeKc;

		private IRegistrar<TouchJoystickAngleIndicator> yQPfFXchXaljjsEClOxdsUVqmzCFA;

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

		internal Image RPwtBduEdBApXeKBhjbTfJafRCKV => null;

		internal Sprite OPLJXNKQGPLjmAaRrfWHGQFMjHVcb => null;

		internal RectTransform uBgsATlVNpCXLTZUrAUVBouJZPML => null;

		[CustomObfuscation]
		private TouchJoystickAngleIndicator()
		{
		}

		internal bool zirtMcMjzTGuWtxJpmQiswDaOSMq(out Vector2 P_0)
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

		private void cmmwwvcottRDAmZIsNkUSjRSinOy(bool P_0, bool P_1)
		{
		}

		private void chGeRtbgVwWxZjiDoRoAlpLmdWSrA(Vector2 P_0)
		{
		}

		private void KNydgAkwFhcPfzydLxGZblsDNDrk()
		{
		}

		private void UlrwyDcujFnSPooxPZETSsQsaxFf()
		{
		}

		private void CbvCdtcgkXIqLYOKEKJdhBmfrjFcB()
		{
		}

		private void WlTgDwBrLkKEcOyWyUgotBqqAxtS()
		{
		}

		private void lgMGxivNJmVgPETeGfkeWxfkuWtj()
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
