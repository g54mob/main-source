using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls.Effects
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[AddComponentMenu("Rewired/Touch Joystick Radial Indicator")]
	[DisallowMultipleComponent]
	public sealed class TouchJoystickRadialIndicator : MonoBehaviour, IRegistrar<TouchJoystickAngleIndicator>
	{
		[Tooltip("If enabled, the indicators will be scaled based on the size of the RectTransform.")]
		public bool _scale = true;

		[Tooltip("If enabled, the aspect ratio will be determined from the Sprite's texture.")]
		public bool _preserveSpriteAspectRatio;

		[Tooltip("The scale ratio of the indicators to the current RectTransform's height. A ratio of 0.1 means the indicator will be 0.1 times the size of the RectTransform's height. This is useful if you need to be able to scale the transform and have the indicators also scale with it.")]
		[Range(0.01f, 1f)]
		public float _scaleRatio = 0.1f;

		[Tooltip("The horizontal component of the desired aspect ratio of the indicator.")]
		[Range(0.01f, 10f)]
		public float _aspectRatioX = 1f;

		[Tooltip("The vertical component of the desired aspect ratio of the indicator.")]
		[Range(0.01f, 10f)]
		public float _aspectRatioY = 1f;

		[Tooltip("Offsets the indicator position up by this proportion of its height. 1.0 = 1 unit high offset.")]
		public float _offset;

		private static readonly Vector2 vFkaAiTDgkYaVAdqNNeLbFUHABrJ = new Vector2(0.5f, 0.5f);

		private RectTransform fCnIPxDWvkGeKBoAmbQItZpkdjWX;

		private List<TouchJoystickAngleIndicator> jCmwiqWXGwvgzbkneCEjbmgFOVY = new List<TouchJoystickAngleIndicator>(8);

		public bool scale
		{
			get
			{
				return _scale;
			}
			set
			{
				if (_scale != value)
				{
					_scale = value;
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		public bool preserveSpriteAspectRatio
		{
			get
			{
				return _preserveSpriteAspectRatio;
			}
			set
			{
				if (_preserveSpriteAspectRatio != value)
				{
					_preserveSpriteAspectRatio = value;
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		public float scaleRatio
		{
			get
			{
				return _scaleRatio;
			}
			set
			{
				value = MathTools.Clamp(value, 0.01f, 1f);
				if (_scaleRatio != value)
				{
					_scaleRatio = value;
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		public float aspectRatioX
		{
			get
			{
				return _aspectRatioX;
			}
			set
			{
				value = MathTools.Clamp(value, 0.01f, 10f);
				if (_aspectRatioX != value)
				{
					_aspectRatioX = value;
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		public float aspectRatioY
		{
			get
			{
				return _aspectRatioY;
			}
			set
			{
				value = MathTools.Clamp(value, 0.01f, 10f);
				if (_aspectRatioY != value)
				{
					_aspectRatioY = value;
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		public float offset
		{
			get
			{
				return _offset;
			}
			set
			{
				if (_offset != value)
				{
					_offset = value;
					qdlBanCKskFYgFyewDKidbPGRpbJ();
				}
			}
		}

		private RectTransform rectTransform => fCnIPxDWvkGeKBoAmbQItZpkdjWX ?? (fCnIPxDWvkGeKBoAmbQItZpkdjWX = GetComponent<RectTransform>());

		private void atZaVriAmLGyxRFudBMIIGBCHyfL(TouchJoystickAngleIndicator P_0)
		{
			if (!(P_0 == null) && ListTools.AddIfUnique(jCmwiqWXGwvgzbkneCEjbmgFOVY, P_0) && base.enabled)
			{
				GFWCUxMDPDDTwDSzKvjHaLgQJCyn(P_0);
			}
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Register(TouchJoystickAngleIndicator P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in atZaVriAmLGyxRFudBMIIGBCHyfL
			this.atZaVriAmLGyxRFudBMIIGBCHyfL(P_0);
		}

		private void VftNBkBtPKdASdoMkpvRSxiNQiE(TouchJoystickAngleIndicator P_0)
		{
			if (!(P_0 == null))
			{
				jCmwiqWXGwvgzbkneCEjbmgFOVY.Remove(P_0);
			}
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Deregister(TouchJoystickAngleIndicator P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in VftNBkBtPKdASdoMkpvRSxiNQiE
			this.VftNBkBtPKdASdoMkpvRSxiNQiE(P_0);
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			MZICQZEoNrWxJlymluSUJiUHkZJ();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (base.enabled)
			{
				loIkfkfCnloOKLcygpdGSAebjUt();
				MZICQZEoNrWxJlymluSUJiUHkZJ();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			MZICQZEoNrWxJlymluSUJiUHkZJ();
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			jCmwiqWXGwvgzbkneCEjbmgFOVY.Clear();
		}

		private void MZICQZEoNrWxJlymluSUJiUHkZJ()
		{
			for (int num = jCmwiqWXGwvgzbkneCEjbmgFOVY.Count - 1; num >= 0; num--)
			{
				TouchJoystickAngleIndicator touchJoystickAngleIndicator = jCmwiqWXGwvgzbkneCEjbmgFOVY[num];
				if (touchJoystickAngleIndicator.image.IsNullOrDestroyed())
				{
					jCmwiqWXGwvgzbkneCEjbmgFOVY.RemoveAt(num);
				}
				else
				{
					GFWCUxMDPDDTwDSzKvjHaLgQJCyn(touchJoystickAngleIndicator);
				}
			}
		}

		private void GFWCUxMDPDDTwDSzKvjHaLgQJCyn(TouchJoystickAngleIndicator P_0)
		{
			if (!UnityTools.IsActiveAndEnabled(P_0.image))
			{
				return;
			}
			RectTransform rectTransform = P_0.rectTransform;
			if (rectTransform == this.rectTransform || rectTransform == null)
			{
				return;
			}
			Rect rect = this.rectTransform.rect;
			if (_scale)
			{
				float num = (num = _aspectRatioX / _aspectRatioY);
				if (_preserveSpriteAspectRatio && P_0.FFhIkgIorekMnpFdBtNdkGuCQKgg(out var vector))
				{
					num = vector.x / vector.y;
				}
				Vector2 sizeDelta = new Vector2(rect.height * _scaleRatio * num, rect.height * _scaleRatio);
				rectTransform.sizeDelta = sizeDelta;
			}
			float num2 = (rect.height / 2f / rectTransform.rect.height - 1f) * -1f;
			if (rectTransform.anchorMin != vFkaAiTDgkYaVAdqNNeLbFUHABrJ)
			{
				rectTransform.anchorMin = vFkaAiTDgkYaVAdqNNeLbFUHABrJ;
			}
			if (rectTransform.anchorMax != vFkaAiTDgkYaVAdqNNeLbFUHABrJ)
			{
				rectTransform.anchorMax = vFkaAiTDgkYaVAdqNNeLbFUHABrJ;
			}
			Vector2 pivot = rectTransform.pivot;
			pivot.x = 0.5f;
			pivot.y = num2 + _offset * -1f;
			rectTransform.pivot = pivot;
		}

		private void qdlBanCKskFYgFyewDKidbPGRpbJ()
		{
			MZICQZEoNrWxJlymluSUJiUHkZJ();
		}

		private void loIkfkfCnloOKLcygpdGSAebjUt()
		{
			Transform transform = base.transform;
			jCmwiqWXGwvgzbkneCEjbmgFOVY.Clear();
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				Transform child = transform.GetChild(i);
				TouchJoystickAngleIndicator component = child.GetComponent<TouchJoystickAngleIndicator>();
				if (component != null)
				{
					jCmwiqWXGwvgzbkneCEjbmgFOVY.Add(component);
				}
			}
		}
	}
}
