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

		internal TouchController touchController
		{
			get
			{
				return LKDXaxXfiiwGAVtjdSCKBcNgYPZ() as TouchController;
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
				while (true)
				{
					int num = -116861568;
					while (true)
					{
						switch (num ^ -116861567)
						{
						case 0:
							break;
						case 1:
							if (canvas == null)
							{
								goto IL_002e;
							}
							return canvas.transform as RectTransform;
						default:
							return null;
						}
						break;
						IL_002e:
						num = -116861565;
					}
				}
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
				return LKDXaxXfiiwGAVtjdSCKBcNgYPZ() as TouchController != null;
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
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				YUpNMWDdcElWfUDzNMGTYQRrnsV(true, false);
				int num = -1329427438;
				while (true)
				{
					switch (num ^ -1329427437)
					{
					case 0:
						goto IL_000f;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_000f:
					num = -1329427439;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal override void OnCanvasGroupChanged()
		{
			base.OnCanvasGroupChanged();
			if (!base.initialized)
			{
				while (true)
				{
					switch (-352422933 ^ -352422935)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			YUpNMWDdcElWfUDzNMGTYQRrnsV(false, true);
		}

		[CustomObfuscation(rename = false)]
		internal override void OnTransformParentChanged()
		{
			base.OnTransformParentChanged();
			while (true)
			{
				int num = -150123346;
				while (true)
				{
					switch (num ^ -150123347)
					{
					case 2:
						break;
					case 3:
					{
						int num2;
						if (base.initialized)
						{
							num = -150123348;
							num2 = num;
						}
						else
						{
							num = -150123347;
							num2 = num;
						}
						continue;
					}
					case 0:
						return;
					default:
						YUpNMWDdcElWfUDzNMGTYQRrnsV(false, true);
						return;
					}
					break;
				}
			}
		}

		internal override bool OnInitialize()
		{
			if (!base.OnInitialize())
			{
				return false;
			}
			if (!YUpNMWDdcElWfUDzNMGTYQRrnsV(true, true))
			{
				return false;
			}
			return true;
		}

		internal override void OnSetProperty()
		{
			base.OnSetProperty();
			while (true)
			{
				int num = -1468687699;
				while (true)
				{
					switch (num ^ -1468687700)
					{
					case 0:
						break;
					case 1:
					{
						int num2;
						if (base.initialized)
						{
							num = -1468687697;
							num2 = num;
						}
						else
						{
							num = -1468687698;
							num2 = num;
						}
						continue;
					}
					case 2:
						return;
					default:
						YUpNMWDdcElWfUDzNMGTYQRrnsV(true, true);
						return;
					}
					break;
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

		private bool YUpNMWDdcElWfUDzNMGTYQRrnsV(bool P_0, bool P_1)
		{
			_canvas = UnityTools.GetComponentInSelfOrParents<Canvas>(base.gameObject);
			if (_canvas == null)
			{
				goto IL_001f;
			}
			int num;
			if (_canvas.renderMode == RenderMode.WorldSpace)
			{
				int num2;
				if (P_1)
				{
					num = -2113572451;
					num2 = num;
				}
				else
				{
					num = -2113572454;
					num2 = num;
				}
				goto IL_0024;
			}
			return true;
			IL_0024:
			while (true)
			{
				switch (num ^ -2113572455)
				{
				case 0:
					break;
				case 4:
					Logger.LogError("Touch controls cannot be used with a world space Canvas. Change the canvas render mode to screen space.");
					num = -2113572454;
					continue;
				case 1:
					return false;
				case 2:
					if (P_0)
					{
						Logger.LogError("No Canvas was found. Touch controls must be a child of a Canvas.");
						num = -2113572456;
						continue;
					}
					goto case 1;
				default:
					return false;
				}
				break;
			}
			goto IL_001f;
			IL_001f:
			num = -2113572453;
			goto IL_0024;
		}
	}
}
