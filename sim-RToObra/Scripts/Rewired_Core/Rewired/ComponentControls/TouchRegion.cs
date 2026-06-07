using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	public sealed class TouchRegion : TouchInteractable
	{
		[Serializable]
		private class FYrowiwJIqsXZLMJavSNFYDKaOU : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class IhafZOHoJAtmqlsDiIYdGJOhkbs : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class jAjhXFIGhbeXtAhlTLAKBHcbBdQW : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class PxLBTabdgKFEjTiuOpPVIyMTjjny : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class IXRfaaiCWPujdcUAcQQojenUYPJv : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class kVFpLoqnDpUmrjHHDdFBbEPQyGmf : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class dZhpBWGuxrpdRZmgVBAEaiYenZc : UnityEvent<PointerEventData>
		{
		}

		[SerializeField]
		[Tooltip("If enabled, the Touch Region will be hidden when gameplay starts.")]
		[CustomObfuscation(rename = false)]
		private bool _hideAtRuntime = true;

		private FYrowiwJIqsXZLMJavSNFYDKaOU _onPointerDown = new FYrowiwJIqsXZLMJavSNFYDKaOU();

		private IhafZOHoJAtmqlsDiIYdGJOhkbs _onPointerUp = new IhafZOHoJAtmqlsDiIYdGJOhkbs();

		private jAjhXFIGhbeXtAhlTLAKBHcbBdQW _onPointerEnter = new jAjhXFIGhbeXtAhlTLAKBHcbBdQW();

		private PxLBTabdgKFEjTiuOpPVIyMTjjny _onPointerExit = new PxLBTabdgKFEjTiuOpPVIyMTjjny();

		private IXRfaaiCWPujdcUAcQQojenUYPJv _onBeginDrag = new IXRfaaiCWPujdcUAcQQojenUYPJv();

		private kVFpLoqnDpUmrjHHDdFBbEPQyGmf _onDrag = new kVFpLoqnDpUmrjHHDdFBbEPQyGmf();

		private dZhpBWGuxrpdRZmgVBAEaiYenZc _onEndDrag = new dZhpBWGuxrpdRZmgVBAEaiYenZc();

		public bool hideAtRuntime
		{
			get
			{
				return _hideAtRuntime;
			}
			set
			{
				bool flag = (_hideAtRuntime = value);
				while (true)
				{
					switch (0x369228D9 ^ 0x369228D8)
					{
					case 2:
						continue;
					case 1:
						if (flag)
						{
							return;
						}
						break;
					}
					break;
				}
				_hideAtRuntime = true;
				OnSetProperty();
			}
		}

		public event UnityAction<PointerEventData> PointerDownEvent
		{
			add
			{
				_onPointerDown.AddListener(value);
			}
			remove
			{
				_onPointerDown.RemoveListener(value);
			}
		}

		public event UnityAction<PointerEventData> PointerUpEvent
		{
			add
			{
				_onPointerUp.AddListener(value);
			}
			remove
			{
				_onPointerUp.RemoveListener(value);
			}
		}

		public event UnityAction<PointerEventData> PointerEnterEvent
		{
			add
			{
				_onPointerEnter.AddListener(value);
			}
			remove
			{
				_onPointerEnter.RemoveListener(value);
			}
		}

		public event UnityAction<PointerEventData> PointerExitEvent
		{
			add
			{
				_onPointerExit.AddListener(value);
			}
			remove
			{
				_onPointerExit.RemoveListener(value);
			}
		}

		public event UnityAction<PointerEventData> BeginDragEvent
		{
			add
			{
				_onBeginDrag.AddListener(value);
			}
			remove
			{
				_onBeginDrag.RemoveListener(value);
			}
		}

		public event UnityAction<PointerEventData> DragEvent
		{
			add
			{
				_onDrag.AddListener(value);
			}
			remove
			{
				_onDrag.RemoveListener(value);
			}
		}

		public event UnityAction<PointerEventData> EndDragEvent
		{
			add
			{
				_onEndDrag.AddListener(value);
			}
			remove
			{
				_onEndDrag.RemoveListener(value);
			}
		}

		[CustomObfuscation(rename = false)]
		private TouchRegion()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
			base.Awake();
			while (true)
			{
				int num = 161546617;
				while (true)
				{
					switch (num ^ 0x9A10178)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						if (!Application.isPlaying)
						{
							return;
						}
						goto case 3;
					case 3:
						if (_hideAtRuntime)
						{
							goto IL_003f;
						}
						return;
					case 0:
						return;
					}
					break;
					IL_003f:
					base.visible = false;
					num = 161546616;
				}
			}
		}

		public override void ClearValue()
		{
		}

		internal override void OnCustomControllerUpdate()
		{
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			if (!base.initialized)
			{
				return;
			}
			while (vWWTQEuzSAtwkwTidoREbMzaAEi())
			{
				int num;
				int num2;
				if (!IsInteractable())
				{
					num = 20733792;
					num2 = num;
				}
				else
				{
					num = 20733798;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x13C5F65)
					{
					case 0:
						num = 20733796;
						continue;
					default:
						return;
					case 1:
						break;
					case 4:
						if (_onPointerDown != null)
						{
							_onPointerDown.Invoke(eventData);
							num = 20733799;
							continue;
						}
						return;
					case 5:
						return;
					case 3:
						if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
						{
							return;
						}
						goto case 4;
					case 2:
						return;
					}
					break;
				}
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			while (true)
			{
				int num = -214911124;
				while (true)
				{
					switch (num ^ -214911123)
					{
					case 6:
						break;
					default:
						return;
					case 1:
						if (!base.initialized)
						{
							return;
						}
						goto case 5;
					case 4:
						return;
					case 2:
					{
						int num3;
						if (TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
						{
							num = -214911126;
							num3 = num;
						}
						else
						{
							num = -214911123;
							num3 = num;
						}
						continue;
					}
					case 7:
						if (_onPointerUp != null)
						{
							_onPointerUp.Invoke(eventData);
							num = -214911122;
							continue;
						}
						return;
					case 5:
					{
						if (!vWWTQEuzSAtwkwTidoREbMzaAEi())
						{
							return;
						}
						int num2;
						if (!IsInteractable())
						{
							num = -214911127;
							num2 = num;
						}
						else
						{
							num = -214911121;
							num2 = num;
						}
						continue;
					}
					case 0:
						return;
					case 3:
						return;
					}
					break;
				}
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			while (true)
			{
				int num = 1083027561;
				while (true)
				{
					switch (num ^ 0x408DB06D)
					{
					case 8:
						break;
					default:
						return;
					case 0:
						_onPointerEnter.Invoke(eventData);
						num = 1083027567;
						continue;
					case 7:
					{
						int num4;
						if (vWWTQEuzSAtwkwTidoREbMzaAEi())
						{
							num = 1083027560;
							num4 = num;
						}
						else
						{
							num = 1083027564;
							num4 = num;
						}
						continue;
					}
					case 4:
						if (!base.initialized)
						{
							return;
						}
						goto case 7;
					case 1:
						return;
					case 3:
					{
						int num3;
						if (_onPointerEnter != null)
						{
							num = 1083027565;
							num3 = num;
						}
						else
						{
							num = 1083027567;
							num3 = num;
						}
						continue;
					}
					case 5:
					{
						int num2;
						if (!IsInteractable())
						{
							num = 1083027564;
							num2 = num;
						}
						else
						{
							num = 1083027563;
							num2 = num;
						}
						continue;
					}
					case 6:
						if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
						{
							return;
						}
						goto case 3;
					case 2:
						return;
					}
					break;
				}
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			if (!base.initialized)
			{
				return;
			}
			while (vWWTQEuzSAtwkwTidoREbMzaAEi())
			{
				int num;
				int num2;
				if (!IsInteractable())
				{
					num = -1094511329;
					num2 = num;
				}
				else
				{
					num = -1094511334;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1094511333)
					{
					case 2:
						num = -1094511330;
						continue;
					default:
						return;
					case 1:
						if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
						{
							return;
						}
						goto case 0;
					case 0:
						if (_onPointerExit != null)
						{
							_onPointerExit.Invoke(eventData);
							num = -1094511336;
							continue;
						}
						return;
					case 5:
						break;
					case 4:
						return;
					case 3:
						return;
					}
					break;
				}
			}
		}

		internal override void OnBeginDrag(PointerEventData eventData)
		{
			base.OnBeginDrag(eventData);
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!vWWTQEuzSAtwkwTidoREbMzaAEi())
				{
					num = 1976603774;
					num2 = num;
				}
				else
				{
					num = 1976603771;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x75D0947C)
					{
					case 3:
						num = 1976603773;
						continue;
					default:
						return;
					case 1:
						break;
					case 7:
					{
						int num4;
						if (!IsInteractable())
						{
							num = 1976603774;
							num4 = num;
						}
						else
						{
							num = 1976603772;
							num4 = num;
						}
						continue;
					}
					case 5:
						if (_onBeginDrag != null)
						{
							_onBeginDrag.Invoke(eventData);
							num = 1976603768;
							continue;
						}
						return;
					case 6:
						return;
					case 0:
					{
						int num3;
						if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag))
						{
							num = 1976603770;
							num3 = num;
						}
						else
						{
							num = 1976603769;
							num3 = num;
						}
						continue;
					}
					case 2:
						return;
					case 4:
						return;
					}
					break;
				}
			}
		}

		internal override void OnDrag(PointerEventData eventData)
		{
			base.OnDrag(eventData);
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!vWWTQEuzSAtwkwTidoREbMzaAEi())
				{
					num = -1232229629;
					num2 = num;
				}
				else
				{
					num = -1232229632;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1232229630)
					{
					case 0:
						num = -1232229628;
						continue;
					default:
						return;
					case 6:
						break;
					case 4:
						if (_onDrag != null)
						{
							_onDrag.Invoke(eventData);
							num = -1232229625;
							continue;
						}
						return;
					case 3:
						if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.Drag))
						{
							return;
						}
						goto case 4;
					case 2:
					{
						int num3;
						if (!IsInteractable())
						{
							num = -1232229629;
							num3 = num;
						}
						else
						{
							num = -1232229631;
							num3 = num;
						}
						continue;
					}
					case 1:
						return;
					case 5:
						return;
					}
					break;
				}
			}
		}

		internal override void OnEndDrag(PointerEventData eventData)
		{
			base.OnEndDrag(eventData);
			if (!base.initialized)
			{
				goto IL_000f;
			}
			goto IL_0084;
			IL_000f:
			int num = -1111686590;
			goto IL_0014;
			IL_0014:
			while (true)
			{
				switch (num ^ -1111686585)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					if (!TouchInteractable.jxCLxvxCDOJXvcIvfAZYuiRGzsy(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag))
					{
						return;
					}
					goto case 4;
				case 3:
					_onEndDrag.Invoke(eventData);
					num = -1111686592;
					continue;
				case 6:
					return;
				case 5:
					return;
				case 1:
					goto IL_0084;
				case 4:
				{
					int num2;
					if (_onEndDrag == null)
					{
						num = -1111686592;
						num2 = num;
					}
					else
					{
						num = -1111686588;
						num2 = num;
					}
					continue;
				}
				case 7:
					return;
				}
				break;
			}
			goto IL_000f;
			IL_0084:
			if (!vWWTQEuzSAtwkwTidoREbMzaAEi())
			{
				return;
			}
			int num3;
			if (!IsInteractable())
			{
				num = -1111686591;
				num3 = num;
			}
			else
			{
				num = -1111686587;
				num3 = num;
			}
			goto IL_0014;
		}
	}
}
