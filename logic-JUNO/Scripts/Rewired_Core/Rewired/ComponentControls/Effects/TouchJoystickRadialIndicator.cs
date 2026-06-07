using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls.Effects
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Joystick Radial Indicator")]
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

		private static readonly Vector2 QXCpGcgWDfueQDBClQaOLnlhAoYd = new Vector2(0.5f, 0.5f);

		private RectTransform kigGSZFUmmUOOJacLJwhGiXdsOwmb;

		private List<TouchJoystickAngleIndicator> jZFMIaYtCsLffpkeGEljUxxtKmjw = new List<TouchJoystickAngleIndicator>(8);

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
					FXTbBOQYIIUAKWxYeeQjtRkooliE();
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
					FXTbBOQYIIUAKWxYeeQjtRkooliE();
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
					FXTbBOQYIIUAKWxYeeQjtRkooliE();
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
					FXTbBOQYIIUAKWxYeeQjtRkooliE();
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
					FXTbBOQYIIUAKWxYeeQjtRkooliE();
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
					FXTbBOQYIIUAKWxYeeQjtRkooliE();
				}
			}
		}

		private RectTransform wiBhWKIAFuAnfXsdFcMkudGbtVUk => kigGSZFUmmUOOJacLJwhGiXdsOwmb ?? (kigGSZFUmmUOOJacLJwhGiXdsOwmb = GetComponent<RectTransform>());

		void IRegistrar<TouchJoystickAngleIndicator>.Register(TouchJoystickAngleIndicator registrant)
		{
			if (!(registrant == null) && ListTools.AddIfUnique(jZFMIaYtCsLffpkeGEljUxxtKmjw, registrant) && base.enabled)
			{
				rsPNfGvjqfiYKSfVIKGuYbppYVjj(registrant);
			}
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Deregister(TouchJoystickAngleIndicator registrant)
		{
			if (!(registrant == null))
			{
				jZFMIaYtCsLffpkeGEljUxxtKmjw.Remove(registrant);
			}
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			RuBCelRDQAsFrbFoZnxyzKXgLuGy();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (base.enabled)
			{
				JwuHMTyJEXPMmicgwBlodpfvkLmv();
				RuBCelRDQAsFrbFoZnxyzKXgLuGy();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			RuBCelRDQAsFrbFoZnxyzKXgLuGy();
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			jZFMIaYtCsLffpkeGEljUxxtKmjw.Clear();
		}

		private void RuBCelRDQAsFrbFoZnxyzKXgLuGy()
		{
			for (int num = jZFMIaYtCsLffpkeGEljUxxtKmjw.Count - 1; num >= 0; num--)
			{
				TouchJoystickAngleIndicator touchJoystickAngleIndicator = jZFMIaYtCsLffpkeGEljUxxtKmjw[num];
				if (touchJoystickAngleIndicator.BJDWtjcneXygkiJnhdHQBxKAsrBoA.IsNullOrDestroyed())
				{
					jZFMIaYtCsLffpkeGEljUxxtKmjw.RemoveAt(num);
				}
				else
				{
					rsPNfGvjqfiYKSfVIKGuYbppYVjj(touchJoystickAngleIndicator);
				}
			}
		}

		private void rsPNfGvjqfiYKSfVIKGuYbppYVjj(TouchJoystickAngleIndicator P_0)
		{
			if (!UnityTools.IsActiveAndEnabled(P_0.BJDWtjcneXygkiJnhdHQBxKAsrBoA))
			{
				return;
			}
			RectTransform rectTransform = P_0.hbDKswWFfSosPOoazjFxLlESoufs;
			if (rectTransform == wiBhWKIAFuAnfXsdFcMkudGbtVUk || rectTransform == null)
			{
				return;
			}
			Rect rect = wiBhWKIAFuAnfXsdFcMkudGbtVUk.rect;
			if (_scale)
			{
				float num = (num = _aspectRatioX / _aspectRatioY);
				if (_preserveSpriteAspectRatio && P_0.CvEklKMENPlsCpskMImaODhhVRZN(out var vector))
				{
					num = vector.x / vector.y;
				}
				Vector2 sizeDelta = new Vector2(rect.height * _scaleRatio * num, rect.height * _scaleRatio);
				rectTransform.sizeDelta = sizeDelta;
			}
			float num2 = (rect.height / 2f / rectTransform.rect.height - 1f) * -1f;
			if (rectTransform.anchorMin != QXCpGcgWDfueQDBClQaOLnlhAoYd)
			{
				rectTransform.anchorMin = QXCpGcgWDfueQDBClQaOLnlhAoYd;
			}
			if (rectTransform.anchorMax != QXCpGcgWDfueQDBClQaOLnlhAoYd)
			{
				rectTransform.anchorMax = QXCpGcgWDfueQDBClQaOLnlhAoYd;
			}
			Vector2 pivot = rectTransform.pivot;
			pivot.x = 0.5f;
			pivot.y = num2 + _offset * -1f;
			rectTransform.pivot = pivot;
		}

		private void FXTbBOQYIIUAKWxYeeQjtRkooliE()
		{
			RuBCelRDQAsFrbFoZnxyzKXgLuGy();
		}

		private void JwuHMTyJEXPMmicgwBlodpfvkLmv()
		{
			Transform transform = base.transform;
			jZFMIaYtCsLffpkeGEljUxxtKmjw.Clear();
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				TouchJoystickAngleIndicator component = transform.GetChild(i).GetComponent<TouchJoystickAngleIndicator>();
				if (component != null)
				{
					jZFMIaYtCsLffpkeGEljUxxtKmjw.Add(component);
				}
			}
		}
	}
}
