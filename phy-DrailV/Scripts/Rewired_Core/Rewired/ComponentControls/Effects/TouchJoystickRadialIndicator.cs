using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls.Effects
{
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	[AddComponentMenu("Rewired/Touch Controls/Effects/Touch Joystick Radial Indicator")]
	public sealed class TouchJoystickRadialIndicator : MonoBehaviour, IRegistrar<TouchJoystickAngleIndicator>
	{
		[Tooltip("If enabled, the indicators will be scaled based on the size of the RectTransform.")]
		public bool _scale = true;

		[Tooltip("If enabled, the aspect ratio will be determined from the Sprite's texture.")]
		public bool _preserveSpriteAspectRatio;

		[Range(0.01f, 1f)]
		[Tooltip("The scale ratio of the indicators to the current RectTransform's height. A ratio of 0.1 means the indicator will be 0.1 times the size of the RectTransform's height. This is useful if you need to be able to scale the transform and have the indicators also scale with it.")]
		public float _scaleRatio = 0.1f;

		[Range(0.01f, 10f)]
		[Tooltip("The horizontal component of the desired aspect ratio of the indicator.")]
		public float _aspectRatioX = 1f;

		[Range(0.01f, 10f)]
		[Tooltip("The vertical component of the desired aspect ratio of the indicator.")]
		public float _aspectRatioY = 1f;

		[Tooltip("Offsets the indicator position up by this proportion of its height. 1.0 = 1 unit high offset.")]
		public float _offset;

		private static readonly Vector2 eMwbUtZeETrjOXmeSNRuKDKeTHBu = new Vector2(0.5f, 0.5f);

		private RectTransform sifCHyJBBTfvNJzYbCjrcyrLGlePA;

		private List<TouchJoystickAngleIndicator> cduCafUigFleootfjffKARgaFUmw = new List<TouchJoystickAngleIndicator>(8);

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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
				}
			}
		}

		private RectTransform DSmDnIVkfzvBzeFgEbidCWTOTVMO => sifCHyJBBTfvNJzYbCjrcyrLGlePA ?? (sifCHyJBBTfvNJzYbCjrcyrLGlePA = GetComponent<RectTransform>());

		void IRegistrar<TouchJoystickAngleIndicator>.Register(TouchJoystickAngleIndicator registrant)
		{
			if (!(registrant == null) && ListTools.AddIfUnique(cduCafUigFleootfjffKARgaFUmw, registrant) && base.enabled)
			{
				JkOSGoAIpuJYzXBxTYYugkozvWUN(registrant);
			}
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Deregister(TouchJoystickAngleIndicator registrant)
		{
			if (!(registrant == null))
			{
				cduCafUigFleootfjffKARgaFUmw.Remove(registrant);
			}
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			JFYQSUAbdMcLWaquwMJbqGaeRexR();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (base.enabled)
			{
				qNYsnhnXeQrQVCcKbWUpngIAEwJE();
				JFYQSUAbdMcLWaquwMJbqGaeRexR();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			JFYQSUAbdMcLWaquwMJbqGaeRexR();
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			cduCafUigFleootfjffKARgaFUmw.Clear();
		}

		private void JFYQSUAbdMcLWaquwMJbqGaeRexR()
		{
			for (int num = cduCafUigFleootfjffKARgaFUmw.Count - 1; num >= 0; num--)
			{
				TouchJoystickAngleIndicator touchJoystickAngleIndicator = cduCafUigFleootfjffKARgaFUmw[num];
				if (touchJoystickAngleIndicator.ezmVocIYLReQdVolMZDpweBgcWSAA.IsNullOrDestroyed())
				{
					cduCafUigFleootfjffKARgaFUmw.RemoveAt(num);
				}
				else
				{
					JkOSGoAIpuJYzXBxTYYugkozvWUN(touchJoystickAngleIndicator);
				}
			}
		}

		private void JkOSGoAIpuJYzXBxTYYugkozvWUN(TouchJoystickAngleIndicator P_0)
		{
			if (!UnityTools.IsActiveAndEnabled(P_0.ezmVocIYLReQdVolMZDpweBgcWSAA))
			{
				return;
			}
			RectTransform rectTransform = P_0.DSmDnIVkfzvBzeFgEbidCWTOTVMO;
			if (rectTransform == DSmDnIVkfzvBzeFgEbidCWTOTVMO || rectTransform == null)
			{
				return;
			}
			Rect rect = DSmDnIVkfzvBzeFgEbidCWTOTVMO.rect;
			if (_scale)
			{
				float num = (num = _aspectRatioX / _aspectRatioY);
				if (_preserveSpriteAspectRatio && P_0.SfzcsjkSNJBLiYrtGecMEtuvYUCHA(out var vector))
				{
					num = vector.x / vector.y;
				}
				Vector2 sizeDelta = new Vector2(rect.height * _scaleRatio * num, rect.height * _scaleRatio);
				rectTransform.sizeDelta = sizeDelta;
			}
			float num2 = (rect.height / 2f / rectTransform.rect.height - 1f) * -1f;
			if (rectTransform.anchorMin != eMwbUtZeETrjOXmeSNRuKDKeTHBu)
			{
				rectTransform.anchorMin = eMwbUtZeETrjOXmeSNRuKDKeTHBu;
			}
			if (rectTransform.anchorMax != eMwbUtZeETrjOXmeSNRuKDKeTHBu)
			{
				rectTransform.anchorMax = eMwbUtZeETrjOXmeSNRuKDKeTHBu;
			}
			Vector2 pivot = rectTransform.pivot;
			pivot.x = 0.5f;
			pivot.y = num2 + _offset * -1f;
			rectTransform.pivot = pivot;
		}

		private void jebsoqOBGHhJxfFgdjbRaKVujtZwA()
		{
			JFYQSUAbdMcLWaquwMJbqGaeRexR();
		}

		private void qNYsnhnXeQrQVCcKbWUpngIAEwJE()
		{
			Transform transform = base.transform;
			cduCafUigFleootfjffKARgaFUmw.Clear();
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				TouchJoystickAngleIndicator component = transform.GetChild(i).GetComponent<TouchJoystickAngleIndicator>();
				if (component != null)
				{
					cduCafUigFleootfjffKARgaFUmw.Add(component);
				}
			}
		}
	}
}
