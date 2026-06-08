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

		internal TouchController touchController => TAPfjlgREenQuGvVOUpFiufnACp() as TouchController;

		internal Canvas canvas => _canvas;

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

		internal RectTransform rectTransform => __rectTransform ?? (__rectTransform = GetComponent<RectTransform>());

		internal override bool hasController => TAPfjlgREenQuGvVOUpFiufnACp() as TouchController != null;

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
				MRhoXKNRTSsrZPHrkpESjCnsadr(true, false);
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnCanvasGroupChanged()
		{
			base.OnCanvasGroupChanged();
			while (true)
			{
				switch (0x3ED371CB ^ 0x3ED371CA)
				{
				case 0:
					continue;
				case 1:
					if (!base.initialized)
					{
						return;
					}
					break;
				}
				break;
			}
			MRhoXKNRTSsrZPHrkpESjCnsadr(false, true);
		}

		[CustomObfuscation(rename = false)]
		internal override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				MRhoXKNRTSsrZPHrkpESjCnsadr(false, true);
				int num = -858087927;
				while (true)
				{
					switch (num ^ -858087927)
					{
					case 2:
						goto IL_000f;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_000f:
					num = -858087928;
				}
			}
		}

		internal override bool KeoQNyZvcuilfnGKgmHgqyJYGhr()
		{
			if (!base.KeoQNyZvcuilfnGKgmHgqyJYGhr())
			{
				return false;
			}
			if (!MRhoXKNRTSsrZPHrkpESjCnsadr(true, true))
			{
				return false;
			}
			return true;
		}

		internal override void wWklIWMVIReShFCdZhfAVVyDQgX()
		{
			base.wWklIWMVIReShFCdZhfAVVyDQgX();
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				MRhoXKNRTSsrZPHrkpESjCnsadr(true, true);
				int num = 879906151;
				while (true)
				{
					switch (num ^ 0x34724D65)
					{
					case 0:
						goto IL_000f;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_000f:
					num = 879906148;
				}
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

		private bool MRhoXKNRTSsrZPHrkpESjCnsadr(bool P_0, bool P_1)
		{
			_canvas = UnityTools.GetComponentInSelfOrParents<Canvas>(base.gameObject);
			while (true)
			{
				int num = -590684539;
				while (true)
				{
					switch (num ^ -590684540)
					{
					case 3:
						break;
					case 1:
						if (_canvas == null)
						{
							num = -590684540;
							continue;
						}
						if (_canvas.renderMode == RenderMode.WorldSpace)
						{
							if (P_1)
							{
								Logger.LogError("Touch controls cannot be used with a world space Canvas. Change the canvas render mode to screen space.");
								num = -590684543;
								continue;
							}
							goto default;
						}
						return true;
					case 0:
					{
						int num2;
						if (!P_0)
						{
							num = -590684538;
							num2 = num;
						}
						else
						{
							num = -590684544;
							num2 = num;
						}
						continue;
					}
					case 4:
						Logger.LogError("No Canvas was found. Touch controls must be a child of a Canvas.");
						num = -590684538;
						continue;
					case 2:
						return false;
					default:
						return false;
					}
					break;
				}
			}
		}
	}
}
