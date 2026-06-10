using System;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(RectTransform))]
	public abstract class TouchControl : CustomControllerControl
	{
		private Canvas _canvas;

		private RectTransform __rectTransform;

		internal TouchController touchController => null;

		internal Canvas canvas => null;

		internal RectTransform canvasTransform => null;

		internal RectTransform rectTransform => null;

		internal override bool hasController => false;

		[CustomObfuscation(rename = false)]
		internal TouchControl()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnCanvasGroupChanged()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnTransformParentChanged()
		{
		}

		internal override bool kCtpTQnECPegKfokmmotHswhcCLu()
		{
			return false;
		}

		internal override void ILfKseeIovFotfIwVedwwNJgiCCt()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override IComponentController FindController()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal override Type GetRequiredControllerType()
		{
			return null;
		}

		private bool wTexrctSqtvimCbhwLxZnCxLMaL(bool P_0, bool P_1)
		{
			return false;
		}
	}
}
