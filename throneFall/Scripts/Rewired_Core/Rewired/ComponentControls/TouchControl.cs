using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls
{
	[Serializable]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	public abstract class TouchControl : CustomControllerControl
	{
		private Canvas _canvas;

		private RectTransform __rectTransform;

		internal TouchController ZAzdJksKZJwAHeVghDcjyDdTdBrv => BqDzxgPEIVLpZbYXMXRjqpdlsvAF() as TouchController;

		internal Canvas PeRbvjmKLXVAZwUjeMLqAywUbFwt => _canvas;

		internal RectTransform ItGEsMyMpnxlJugoabGAFlWwNpaA
		{
			get
			{
				Canvas canvas = PeRbvjmKLXVAZwUjeMLqAywUbFwt;
				if (canvas == null)
				{
					return null;
				}
				return canvas.transform as RectTransform;
			}
		}

		internal RectTransform njMzqkjgKXtAPpsbWqNrSYYvKakF => __rectTransform ?? (__rectTransform = GetComponent<RectTransform>());

		bool CustomControllerControl.OPBVHezjFVpJBDXXXJwLabYlHTYR => BqDzxgPEIVLpZbYXMXRjqpdlsvAF() as TouchController != null;

		[CustomObfuscation(rename = false)]
		internal TouchControl()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				VgjXoItBNYVIEkIPaKaFPAVbsHUj(true, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnCanvasGroupChanged()
		{
			base.OnCanvasGroupChanged();
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				VgjXoItBNYVIEkIPaKaFPAVbsHUj(false, true);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				VgjXoItBNYVIEkIPaKaFPAVbsHUj(false, true);
			}
		}

		internal virtual bool XjBzdhnktatNTyEAKEeVRBDyMEbg()
		{
			if (!base.FwgDUBYWZVAxBlviSDOiGLrhpKDhb())
			{
				return false;
			}
			if (!VgjXoItBNYVIEkIPaKaFPAVbsHUj(true, true))
			{
				return false;
			}
			return true;
		}

		internal virtual void ZmyLViQpAdhhUTlWbWHvhioUVHTo()
		{
			base.dGrkdAigHPtPsfObCbIMleiXpdpl();
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA)
			{
				VgjXoItBNYVIEkIPaKaFPAVbsHUj(true, true);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override IComponentController FindController()
		{
			return UnityTools.GetComponentInSelfOrParents<CustomController>(base.transform);
		}

		[CustomObfuscation(rename = false)]
		internal override Type GetRequiredControllerType()
		{
			return typeof(TouchController);
		}

		private bool VgjXoItBNYVIEkIPaKaFPAVbsHUj(bool P_0, bool P_1)
		{
			_canvas = UnityTools.GetComponentInSelfOrParents<Canvas>(base.gameObject);
			if (_canvas == null)
			{
				if (P_0)
				{
					Logger.LogError("No Canvas was found. Touch controls must be a child of a Canvas.");
				}
				return false;
			}
			if (_canvas.renderMode == RenderMode.WorldSpace)
			{
				if (P_1)
				{
					Logger.LogError("Touch controls cannot be used with a world space Canvas. Change the canvas render mode to screen space.");
				}
				return false;
			}
			return true;
		}
	}
}
