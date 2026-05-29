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

		internal TouchController touchController
		{
			get
			{
				return uTBWYexvbgNovlylPUvYgROmXuM() as TouchController;
			}
		}

		internal Canvas canvas
		{
			get
			{
				return _canvas;
			}
		}

		internal RectTransform canvasTransform
		{
			get
			{
				Canvas canvas = this.canvas;
				if (canvas == null)
				{
					return null;
				}
				return canvas.transform as RectTransform;
			}
		}

		internal RectTransform rectTransform
		{
			get
			{
				return __rectTransform ?? (__rectTransform = GetComponent<RectTransform>());
			}
		}

		internal override bool hasController
		{
			get
			{
				return uTBWYexvbgNovlylPUvYgROmXuM() as TouchController != null;
			}
		}

		[CustomObfuscation(rename = false)]
		internal TouchControl()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void OnValidate()
		{
			base.OnValidate();
			if (base.initialized)
			{
				lQzITVzDwIntKmhuxNCVjGJtnhE(true, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnCanvasGroupChanged()
		{
			base.OnCanvasGroupChanged();
			if (base.initialized)
			{
				lQzITVzDwIntKmhuxNCVjGJtnhE(false, true);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			if (base.initialized)
			{
				lQzITVzDwIntKmhuxNCVjGJtnhE(false, true);
			}
		}

		internal override bool OnInitialize()
		{
			if (!base.OnInitialize())
			{
				return false;
			}
			if (!lQzITVzDwIntKmhuxNCVjGJtnhE(true, true))
			{
				return false;
			}
			return true;
		}

		internal override void OnSetProperty()
		{
			base.OnSetProperty();
			if (base.initialized)
			{
				lQzITVzDwIntKmhuxNCVjGJtnhE(true, true);
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

		private bool lQzITVzDwIntKmhuxNCVjGJtnhE(bool P_0, bool P_1)
		{
			_canvas = UnityTools.GetComponentInSelfOrParents<Canvas>(base.gameObject);
			if (_canvas == null)
			{
				if (P_0)
				{
					Logger.LogError("No Canvas was found. Touch controls must be a child of a Canvas.");
					goto IL_002c;
				}
				goto IL_004e;
			}
			int num;
			if (_canvas.renderMode == RenderMode.WorldSpace)
			{
				num = 1879821581;
				goto IL_0031;
			}
			return true;
			IL_002c:
			num = 1879821582;
			goto IL_0031;
			IL_004e:
			return false;
			IL_0031:
			while (true)
			{
				switch (num ^ 0x700BCD0D)
				{
				case 2:
					break;
				case 3:
					goto IL_004e;
				case 0:
					if (P_1)
					{
						Logger.LogError("Touch controls cannot be used with a world space Canvas. Change the canvas render mode to screen space.");
						num = 1879821580;
						continue;
					}
					goto default;
				default:
					return false;
				}
				break;
			}
			goto IL_002c;
		}
	}
}
