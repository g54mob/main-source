using System;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public abstract class TouchControl : CustomControllerControl
	{
		private Canvas _canvas;

		private RectTransform __rectTransform;

		internal TouchController touchController => null;

		internal Canvas canvas => null;

		internal RectTransform canvasTransform => null;

		internal RectTransform rectTransform => null;

		internal override bool hasController => false;

		[CustomObfuscation]
		internal TouchControl()
		{
		}

		[CustomObfuscation]
		internal override void OnValidate()
		{
		}

		[CustomObfuscation]
		internal override void OnCanvasGroupChanged()
		{
		}

		[CustomObfuscation]
		internal override void OnTransformParentChanged()
		{
		}

		internal override bool vTErMpFqqbrJIuisyHNZEKHQiIJk()
		{
			return false;
		}

		internal override void DDSYIBWFCFbxtAeyTbUKilaTRGQv()
		{
		}

		[CustomObfuscation]
		internal override IComponentController FindController()
		{
			return null;
		}

		[CustomObfuscation]
		internal override Type GetRequiredControllerType()
		{
			return null;
		}

		private bool bWTPODPMLJvssWnAiQfrNIGyopH(bool P_0, bool P_1)
		{
			return false;
		}
	}
}
