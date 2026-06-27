using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls.Effects
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Controls/Effects/Touch Joystick Radial Indicator")]
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

		private static readonly Vector2 LXgvonpERGHvxRPTFnStvCjXASkl = new Vector2(0.5f, 0.5f);

		private RectTransform tGJUEgZqhRvwFcyknPrOOtHSGWQj;

		private List<TouchJoystickAngleIndicator> aammIHJMNZiYuExooAWKFibZWsVBb = new List<TouchJoystickAngleIndicator>(8);

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
					KUchppLHghvvRQlhWTDYPFaCwOYc();
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
					KUchppLHghvvRQlhWTDYPFaCwOYc();
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
					KUchppLHghvvRQlhWTDYPFaCwOYc();
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
					KUchppLHghvvRQlhWTDYPFaCwOYc();
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
					KUchppLHghvvRQlhWTDYPFaCwOYc();
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
					KUchppLHghvvRQlhWTDYPFaCwOYc();
				}
			}
		}

		private RectTransform zaiBvlRxUJrpeLxzpNJRODIDBdqV => tGJUEgZqhRvwFcyknPrOOtHSGWQj ?? (tGJUEgZqhRvwFcyknPrOOtHSGWQj = GetComponent<RectTransform>());

		void IRegistrar<TouchJoystickAngleIndicator>.Register(TouchJoystickAngleIndicator registrant)
		{
			if (!(registrant == null) && ListTools.AddIfUnique(aammIHJMNZiYuExooAWKFibZWsVBb, registrant) && base.enabled)
			{
				awkZlTyxIOLLrYxaFjFhydTHIBZ(registrant);
			}
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Deregister(TouchJoystickAngleIndicator registrant)
		{
			if (!(registrant == null))
			{
				aammIHJMNZiYuExooAWKFibZWsVBb.Remove(registrant);
			}
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			OcwipKIuJvyHcxokzURRZPVGaxqf();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (base.enabled)
			{
				OcPTcErVNiundgorMQPyFlMDJGvB();
				OcwipKIuJvyHcxokzURRZPVGaxqf();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			OcwipKIuJvyHcxokzURRZPVGaxqf();
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			aammIHJMNZiYuExooAWKFibZWsVBb.Clear();
		}

		private void OcwipKIuJvyHcxokzURRZPVGaxqf()
		{
			for (int num = aammIHJMNZiYuExooAWKFibZWsVBb.Count - 1; num >= 0; num--)
			{
				TouchJoystickAngleIndicator touchJoystickAngleIndicator = aammIHJMNZiYuExooAWKFibZWsVBb[num];
				if (touchJoystickAngleIndicator.KRggtQdddstHrPgxNVmpLJAokdjIb.IsNullOrDestroyed())
				{
					aammIHJMNZiYuExooAWKFibZWsVBb.RemoveAt(num);
				}
				else
				{
					awkZlTyxIOLLrYxaFjFhydTHIBZ(touchJoystickAngleIndicator);
				}
			}
		}

		private void awkZlTyxIOLLrYxaFjFhydTHIBZ(TouchJoystickAngleIndicator P_0)
		{
			if (!UnityTools.IsActiveAndEnabled(P_0.KRggtQdddstHrPgxNVmpLJAokdjIb))
			{
				return;
			}
			RectTransform rectTransform = P_0.ilsncNLoyzENECtwPJkQlmEkoQJL;
			if (rectTransform == zaiBvlRxUJrpeLxzpNJRODIDBdqV || rectTransform == null)
			{
				return;
			}
			Rect rect = zaiBvlRxUJrpeLxzpNJRODIDBdqV.rect;
			if (_scale)
			{
				float num = (num = _aspectRatioX / _aspectRatioY);
				if (_preserveSpriteAspectRatio && P_0.RenObzHMQiGLVDfoyLBHCgbXrZneA(out var vector))
				{
					num = vector.x / vector.y;
				}
				Vector2 sizeDelta = new Vector2(rect.height * _scaleRatio * num, rect.height * _scaleRatio);
				rectTransform.sizeDelta = sizeDelta;
			}
			float num2 = (rect.height / 2f / rectTransform.rect.height - 1f) * -1f;
			if (rectTransform.anchorMin != LXgvonpERGHvxRPTFnStvCjXASkl)
			{
				rectTransform.anchorMin = LXgvonpERGHvxRPTFnStvCjXASkl;
			}
			if (rectTransform.anchorMax != LXgvonpERGHvxRPTFnStvCjXASkl)
			{
				rectTransform.anchorMax = LXgvonpERGHvxRPTFnStvCjXASkl;
			}
			Vector2 pivot = rectTransform.pivot;
			pivot.x = 0.5f;
			pivot.y = num2 + _offset * -1f;
			rectTransform.pivot = pivot;
		}

		private void KUchppLHghvvRQlhWTDYPFaCwOYc()
		{
			OcwipKIuJvyHcxokzURRZPVGaxqf();
		}

		private void OcPTcErVNiundgorMQPyFlMDJGvB()
		{
			Transform transform = base.transform;
			aammIHJMNZiYuExooAWKFibZWsVBb.Clear();
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				TouchJoystickAngleIndicator component = transform.GetChild(i).GetComponent<TouchJoystickAngleIndicator>();
				if (component != null)
				{
					aammIHJMNZiYuExooAWKFibZWsVBb.Add(component);
				}
			}
		}
	}
}
