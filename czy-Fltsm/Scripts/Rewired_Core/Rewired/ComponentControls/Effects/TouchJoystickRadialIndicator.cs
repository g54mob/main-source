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

		private static readonly Vector2 EHJbnigcWYbrAolVePSrQMkoJuTCA = new Vector2(0.5f, 0.5f);

		private RectTransform cxyQntUsAJRcwMkYSgYTxGajsfKB;

		private List<TouchJoystickAngleIndicator> nDXUxWMEPLsiZNfoLxyKDQauApuj = new List<TouchJoystickAngleIndicator>(8);

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
					VIXFnwkEUlxVibixjGsOOaEzBUzIA();
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
					VIXFnwkEUlxVibixjGsOOaEzBUzIA();
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
					VIXFnwkEUlxVibixjGsOOaEzBUzIA();
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
					VIXFnwkEUlxVibixjGsOOaEzBUzIA();
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
					VIXFnwkEUlxVibixjGsOOaEzBUzIA();
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
					VIXFnwkEUlxVibixjGsOOaEzBUzIA();
				}
			}
		}

		private RectTransform qELPrcWtLDxDTbijOmcJbnFwPBDO => cxyQntUsAJRcwMkYSgYTxGajsfKB ?? (cxyQntUsAJRcwMkYSgYTxGajsfKB = GetComponent<RectTransform>());

		void IRegistrar<TouchJoystickAngleIndicator>.Register(TouchJoystickAngleIndicator registrant)
		{
			if (!(registrant == null) && ListTools.AddIfUnique(nDXUxWMEPLsiZNfoLxyKDQauApuj, registrant) && base.enabled)
			{
				zpDXZqbgaGWhmeAlLgMPJNqmeiqtA(registrant);
			}
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Deregister(TouchJoystickAngleIndicator registrant)
		{
			if (!(registrant == null))
			{
				nDXUxWMEPLsiZNfoLxyKDQauApuj.Remove(registrant);
			}
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
			BbJJyFTjCdmULFxsAqjNqXIjNCXw();
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
			if (base.enabled)
			{
				DGkYZvqHMqNSEKjkpCvNkwiiDrhEA();
				BbJJyFTjCdmULFxsAqjNqXIjNCXw();
			}
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
			BbJJyFTjCdmULFxsAqjNqXIjNCXw();
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
			nDXUxWMEPLsiZNfoLxyKDQauApuj.Clear();
		}

		private void BbJJyFTjCdmULFxsAqjNqXIjNCXw()
		{
			for (int num = nDXUxWMEPLsiZNfoLxyKDQauApuj.Count - 1; num >= 0; num--)
			{
				TouchJoystickAngleIndicator touchJoystickAngleIndicator = nDXUxWMEPLsiZNfoLxyKDQauApuj[num];
				if (touchJoystickAngleIndicator.TmJnNDkcrgpVYKjCcFdzofZFZYQg.IsNullOrDestroyed())
				{
					nDXUxWMEPLsiZNfoLxyKDQauApuj.RemoveAt(num);
				}
				else
				{
					zpDXZqbgaGWhmeAlLgMPJNqmeiqtA(touchJoystickAngleIndicator);
				}
			}
		}

		private void zpDXZqbgaGWhmeAlLgMPJNqmeiqtA(TouchJoystickAngleIndicator P_0)
		{
			if (!UnityTools.IsActiveAndEnabled(P_0.TmJnNDkcrgpVYKjCcFdzofZFZYQg))
			{
				return;
			}
			RectTransform rectTransform = P_0.puDBkICGthUbpacgqyTIWbLVlIav;
			if (rectTransform == qELPrcWtLDxDTbijOmcJbnFwPBDO || rectTransform == null)
			{
				return;
			}
			Rect rect = qELPrcWtLDxDTbijOmcJbnFwPBDO.rect;
			if (_scale)
			{
				float num = (num = _aspectRatioX / _aspectRatioY);
				if (_preserveSpriteAspectRatio && P_0.SaKBteOkXcRboFtoZKgFNlgyPzCl(out var vector))
				{
					num = vector.x / vector.y;
				}
				Vector2 sizeDelta = new Vector2(rect.height * _scaleRatio * num, rect.height * _scaleRatio);
				rectTransform.sizeDelta = sizeDelta;
			}
			float num2 = (rect.height / 2f / rectTransform.rect.height - 1f) * -1f;
			if (rectTransform.anchorMin != EHJbnigcWYbrAolVePSrQMkoJuTCA)
			{
				rectTransform.anchorMin = EHJbnigcWYbrAolVePSrQMkoJuTCA;
			}
			if (rectTransform.anchorMax != EHJbnigcWYbrAolVePSrQMkoJuTCA)
			{
				rectTransform.anchorMax = EHJbnigcWYbrAolVePSrQMkoJuTCA;
			}
			Vector2 pivot = rectTransform.pivot;
			pivot.x = 0.5f;
			pivot.y = num2 + _offset * -1f;
			rectTransform.pivot = pivot;
		}

		private void VIXFnwkEUlxVibixjGsOOaEzBUzIA()
		{
			BbJJyFTjCdmULFxsAqjNqXIjNCXw();
		}

		private void DGkYZvqHMqNSEKjkpCvNkwiiDrhEA()
		{
			Transform transform = base.transform;
			nDXUxWMEPLsiZNfoLxyKDQauApuj.Clear();
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				TouchJoystickAngleIndicator component = transform.GetChild(i).GetComponent<TouchJoystickAngleIndicator>();
				if (component != null)
				{
					nDXUxWMEPLsiZNfoLxyKDQauApuj.Add(component);
				}
			}
		}
	}
}
