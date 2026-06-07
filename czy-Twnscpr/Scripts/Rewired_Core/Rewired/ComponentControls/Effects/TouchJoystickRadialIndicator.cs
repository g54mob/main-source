using System.Collections.Generic;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls.Effects
{
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public sealed class TouchJoystickRadialIndicator : MonoBehaviour, IRegistrar<TouchJoystickAngleIndicator>
	{
		public bool _scale;

		public bool _preserveSpriteAspectRatio;

		public float _scaleRatio;

		public float _aspectRatioX;

		public float _aspectRatioY;

		public float _offset;

		private static readonly Vector2 YLNCsULHMFsPIsCuetydxNjRQgU;

		private RectTransform MHMDhXFuBRbRPAWQVXOoVRSmmOn;

		private List<TouchJoystickAngleIndicator> WcFBYAKSgNVQoXKfVkUFlaBHaht;

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

		private RectTransform rectTransform => null;

		private void BuadtVIAGqnRyuxmGhIkSAwRLJCL(TouchJoystickAngleIndicator P_0)
		{
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Register(TouchJoystickAngleIndicator P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in BuadtVIAGqnRyuxmGhIkSAwRLJCL
			this.BuadtVIAGqnRyuxmGhIkSAwRLJCL(P_0);
		}

		private void maSSzCHLtjHzNZCIVkphEsXNoHj(TouchJoystickAngleIndicator P_0)
		{
		}

		void IRegistrar<TouchJoystickAngleIndicator>.Deregister(TouchJoystickAngleIndicator P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in maSSzCHLtjHzNZCIVkphEsXNoHj
			this.maSSzCHLtjHzNZCIVkphEsXNoHj(P_0);
		}

		[CustomObfuscation]
		private void Update()
		{
		}

		[CustomObfuscation]
		private void OnValidate()
		{
		}

		[CustomObfuscation]
		private void OnEnable()
		{
		}

		[CustomObfuscation]
		private void OnDestroy()
		{
		}

		private void dfpaivCQhGgfWRScAuqcRPHLoZe()
		{
		}

		private void pKfcQTGzbyqtfihxpzffLaRQzbP(TouchJoystickAngleIndicator P_0)
		{
		}

		private void DDSYIBWFCFbxtAeyTbUKilaTRGQv()
		{
		}

		private void KnhWsQnXoCBVZxoWNdieCRjxjyA()
		{
		}
	}
}
