using System.Collections.Generic;
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
		public bool _scale;

		[Tooltip("If enabled, the aspect ratio will be determined from the Sprite's texture.")]
		public bool _preserveSpriteAspectRatio;

		[Tooltip("The scale ratio of the indicators to the current RectTransform's height. A ratio of 0.1 means the indicator will be 0.1 times the size of the RectTransform's height. This is useful if you need to be able to scale the transform and have the indicators also scale with it.")]
		[Range(0.01f, 1f)]
		public float _scaleRatio;

		[Tooltip("The horizontal component of the desired aspect ratio of the indicator.")]
		[Range(0.01f, 10f)]
		public float _aspectRatioX;

		[Tooltip("The vertical component of the desired aspect ratio of the indicator.")]
		[Range(0.01f, 10f)]
		public float _aspectRatioY;

		[Tooltip("Offsets the indicator position up by this proportion of its height. 1.0 = 1 unit high offset.")]
		public float _offset;

		private static readonly Vector2 AcZitxQsuQQnyCOhhJTWDagPXvDp;

		private RectTransform qbiaWcgKGFBZWjgWTehzuCYCdfxBA;

		private List<TouchJoystickAngleIndicator> lZZKGBaAcPmefmaKKgqdExmNOXqU;

		public bool scale
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool preserveSpriteAspectRatio
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float scaleRatio
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float aspectRatioX
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float aspectRatioY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float offset
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private RectTransform acLAptKofVrBfnGZBirgMaVTUULjA => null;

		void IRegistrar<TouchJoystickAngleIndicator>.Register(TouchJoystickAngleIndicator registrant)
		{
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Deregister(TouchJoystickAngleIndicator registrant)
		{
		}

		[CustomObfuscation(rename = false)]
		private void Update()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnValidate()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnEnable()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnDestroy()
		{
		}

		private void JFVBgUIvelWIphwMHoieWbOEMDNkA()
		{
		}

		private void zLJpJjVEGSjxMGRDMqByfAoAJfkfB(TouchJoystickAngleIndicator P_0)
		{
		}

		private void FkLDphwqyxOLANVFsjrzjyOEZWpI()
		{
		}

		private void HiwKJuIgskZMejQKwqaqtnkHuupt()
		{
		}
	}
}
