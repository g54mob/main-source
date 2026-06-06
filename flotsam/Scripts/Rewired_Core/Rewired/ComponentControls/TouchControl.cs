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

		internal TouchController wNTOWEgAlJnYWLptNbOWgEexLbiD => wabUkEZZZJIoUMDQmjwMkPKXcLHJ() as TouchController;

		internal Canvas kNbKwHebMDAVGBqeMBbPGLFckDhW => _canvas;

		internal RectTransform prBzCSoVntaziqnoUNfbHJCyNAal
		{
			get
			{
				Canvas canvas = kNbKwHebMDAVGBqeMBbPGLFckDhW;
				if (canvas == null)
				{
					return null;
				}
				return canvas.transform as RectTransform;
			}
		}

		internal RectTransform WguQsOfFOJkmIQiZkACAIfcHMwnD => __rectTransform ?? (__rectTransform = GetComponent<RectTransform>());

		bool CustomControllerControl.lgrxeUlsSPQSCicUhAbuoUnLaBDCA => wabUkEZZZJIoUMDQmjwMkPKXcLHJ() as TouchController != null;

		[CustomObfuscation(rename = false)]
		internal TouchControl()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				ojBslifBUWMnVXvTSeAeRzkLyJVJ(true, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnCanvasGroupChanged()
		{
			base.OnCanvasGroupChanged();
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				ojBslifBUWMnVXvTSeAeRzkLyJVJ(false, true);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				ojBslifBUWMnVXvTSeAeRzkLyJVJ(false, true);
			}
		}

		internal virtual bool qpWVJdydcefUDsBsenoLiqICNaG()
		{
			if (!base.mHOefbJCUXqkQiKpeekFQZKFzWONA())
			{
				return false;
			}
			if (!ojBslifBUWMnVXvTSeAeRzkLyJVJ(true, true))
			{
				return false;
			}
			return true;
		}

		internal virtual void ooMquYENZrByXBkDLzvSbSXacNAgA()
		{
			base.KgLXihurbPinOWJqLZtFhFebpoIB();
			if (base.mGSVjCDCJJtDWhXvCjLMSqYiVZpn)
			{
				ojBslifBUWMnVXvTSeAeRzkLyJVJ(true, true);
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

		private bool ojBslifBUWMnVXvTSeAeRzkLyJVJ(bool P_0, bool P_1)
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
