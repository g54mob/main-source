using System;
using Rewired.Utils;
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

		internal TouchController lgVibRICIXCvkyosxfYRxInxaGjBA => jEXzKujpjLIhjTJCTTXuiKAPfKVb() as TouchController;

		internal Canvas oJQqczDhICKLxrvFLqPtRJoISnkJ => _canvas;

		internal RectTransform boAaJrcsmiHhkYkFXRgeFHFbAFmGb
		{
			get
			{
				Canvas canvas = oJQqczDhICKLxrvFLqPtRJoISnkJ;
				if (canvas == null)
				{
					return null;
				}
				return canvas.transform as RectTransform;
			}
		}

		internal RectTransform uBgsATlVNpCXLTZUrAUVBouJZPML => __rectTransform ?? (__rectTransform = GetComponent<RectTransform>());

		bool CustomControllerControl.lQbkmKnTRMhMmINePIJrIZrbBwDnA => jEXzKujpjLIhjTJCTTXuiKAPfKVb() as TouchController != null;

		[CustomObfuscation(rename = false)]
		internal TouchControl()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				qfsLyjdmcZwvIKgTdfBWbFYINZEs(true, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnCanvasGroupChanged()
		{
			base.OnCanvasGroupChanged();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				qfsLyjdmcZwvIKgTdfBWbFYINZEs(false, true);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				qfsLyjdmcZwvIKgTdfBWbFYINZEs(false, true);
			}
		}

		internal override bool qrhyEDreMhRqasASvGWwEiXwPpSPA()
		{
			if (!base.qrhyEDreMhRqasASvGWwEiXwPpSPA())
			{
				return false;
			}
			if (!qfsLyjdmcZwvIKgTdfBWbFYINZEs(true, true))
			{
				return false;
			}
			return true;
		}

		internal override void CbvCdtcgkXIqLYOKEKJdhBmfrjFcB()
		{
			base.CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
			if (base.qumTafanxrjKbDduWdypwIzXqmiP)
			{
				qfsLyjdmcZwvIKgTdfBWbFYINZEs(true, true);
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

		private bool qfsLyjdmcZwvIKgTdfBWbFYINZEs(bool P_0, bool P_1)
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
