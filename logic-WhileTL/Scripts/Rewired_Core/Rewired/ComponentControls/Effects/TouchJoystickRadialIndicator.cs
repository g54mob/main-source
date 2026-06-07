using System.Collections.Generic;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls.Effects
{
	[AddComponentMenu("Rewired/Touch Joystick Radial Indicator")]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
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

		[Range(0.01f, 10f)]
		[Tooltip("The vertical component of the desired aspect ratio of the indicator.")]
		public float _aspectRatioY = 1f;

		[Tooltip("Offsets the indicator position up by this proportion of its height. 1.0 = 1 unit high offset.")]
		public float _offset;

		private static readonly Vector2 TVoDXitUkJhCmiuGxChYiDthxPLUB = new Vector2(0.5f, 0.5f);

		private RectTransform HLlUndjcbPBAjWfmKyTHloUCXtqV;

		private List<TouchJoystickAngleIndicator> LZefzaAoKNPBIjLHMuJgTDXnVWsNA = new List<TouchJoystickAngleIndicator>(8);

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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
				}
			}
		}

		private RectTransform uBgsATlVNpCXLTZUrAUVBouJZPML => HLlUndjcbPBAjWfmKyTHloUCXtqV ?? (HLlUndjcbPBAjWfmKyTHloUCXtqV = GetComponent<RectTransform>());

		void IRegistrar<TouchJoystickAngleIndicator>.Register(TouchJoystickAngleIndicator registrant)
		{
			if (!(registrant == null) && ListTools.AddIfUnique(LZefzaAoKNPBIjLHMuJgTDXnVWsNA, registrant) && base.enabled)
			{
				chGeRtbgVwWxZjiDoRoAlpLmdWSrA(registrant);
			}
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Deregister(TouchJoystickAngleIndicator registrant)
		{
			if (!(registrant == null))
			{
				LZefzaAoKNPBIjLHMuJgTDXnVWsNA.Remove(registrant);
			}
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			wOQbHThiHGeigAFQCTjFTjXvvsnpc();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (base.enabled)
			{
				ZkEpfoNBlEhGjgpWQZaVHgLXtGDnA();
				wOQbHThiHGeigAFQCTjFTjXvvsnpc();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			wOQbHThiHGeigAFQCTjFTjXvvsnpc();
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			LZefzaAoKNPBIjLHMuJgTDXnVWsNA.Clear();
		}

		private void wOQbHThiHGeigAFQCTjFTjXvvsnpc()
		{
			for (int num = LZefzaAoKNPBIjLHMuJgTDXnVWsNA.Count - 1; num >= 0; num--)
			{
				TouchJoystickAngleIndicator touchJoystickAngleIndicator = LZefzaAoKNPBIjLHMuJgTDXnVWsNA[num];
				if (touchJoystickAngleIndicator.RPwtBduEdBApXeKBhjbTfJafRCKV.IsNullOrDestroyed())
				{
					LZefzaAoKNPBIjLHMuJgTDXnVWsNA.RemoveAt(num);
				}
				else
				{
					chGeRtbgVwWxZjiDoRoAlpLmdWSrA(touchJoystickAngleIndicator);
				}
			}
		}

		private void chGeRtbgVwWxZjiDoRoAlpLmdWSrA(TouchJoystickAngleIndicator P_0)
		{
			if (!UnityTools.IsActiveAndEnabled(P_0.RPwtBduEdBApXeKBhjbTfJafRCKV))
			{
				return;
			}
			RectTransform rectTransform = P_0.uBgsATlVNpCXLTZUrAUVBouJZPML;
			if (rectTransform == uBgsATlVNpCXLTZUrAUVBouJZPML || rectTransform == null)
			{
				return;
			}
			Rect rect = uBgsATlVNpCXLTZUrAUVBouJZPML.rect;
			if (_scale)
			{
				float num = (num = _aspectRatioX / _aspectRatioY);
				if (_preserveSpriteAspectRatio && P_0.zirtMcMjzTGuWtxJpmQiswDaOSMq(out var vector))
				{
					num = vector.x / vector.y;
				}
				Vector2 sizeDelta = new Vector2(rect.height * _scaleRatio * num, rect.height * _scaleRatio);
				rectTransform.sizeDelta = sizeDelta;
			}
			float num2 = (rect.height / 2f / rectTransform.rect.height - 1f) * -1f;
			if (rectTransform.anchorMin != TVoDXitUkJhCmiuGxChYiDthxPLUB)
			{
				rectTransform.anchorMin = TVoDXitUkJhCmiuGxChYiDthxPLUB;
			}
			if (rectTransform.anchorMax != TVoDXitUkJhCmiuGxChYiDthxPLUB)
			{
				rectTransform.anchorMax = TVoDXitUkJhCmiuGxChYiDthxPLUB;
			}
			Vector2 pivot = rectTransform.pivot;
			pivot.x = 0.5f;
			pivot.y = num2 + _offset * -1f;
			rectTransform.pivot = pivot;
		}

		private void CbvCdtcgkXIqLYOKEKJdhBmfrjFcB()
		{
			wOQbHThiHGeigAFQCTjFTjXvvsnpc();
		}

		private void ZkEpfoNBlEhGjgpWQZaVHgLXtGDnA()
		{
			Transform transform = base.transform;
			LZefzaAoKNPBIjLHMuJgTDXnVWsNA.Clear();
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				TouchJoystickAngleIndicator component = transform.GetChild(i).GetComponent<TouchJoystickAngleIndicator>();
				if (component != null)
				{
					LZefzaAoKNPBIjLHMuJgTDXnVWsNA.Add(component);
				}
			}
		}
	}
}
