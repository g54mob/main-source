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
		private class qibfhrKCUuERylzGEhjTspFEjzRi : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class nDiOSNbRPCRRLVpMWECrhFOxTqz : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class CKvLQAkabjfcMaBirUISbigNPuHE : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class ijNWOhZPcSKpKCPlgURNFLYRxyk : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class pKDyfnuAURYEEekPQLOgDMnGBAMA : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class BRHkQnQrRlUBKFgSlGJHpULMZRv : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class IZjsaHusWxOeivHzzXqQLNWasol : UnityEvent<PointerEventData>
		{
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If enabled, the Touch Region will be hidden when gameplay starts.")]
		private bool _hideAtRuntime = true;

		private qibfhrKCUuERylzGEhjTspFEjzRi _onPointerDown = new qibfhrKCUuERylzGEhjTspFEjzRi();

		private nDiOSNbRPCRRLVpMWECrhFOxTqz _onPointerUp = new nDiOSNbRPCRRLVpMWECrhFOxTqz();

		private CKvLQAkabjfcMaBirUISbigNPuHE _onPointerEnter = new CKvLQAkabjfcMaBirUISbigNPuHE();

		private ijNWOhZPcSKpKCPlgURNFLYRxyk _onPointerExit = new ijNWOhZPcSKpKCPlgURNFLYRxyk();

		private pKDyfnuAURYEEekPQLOgDMnGBAMA _onBeginDrag = new pKDyfnuAURYEEekPQLOgDMnGBAMA();

		private BRHkQnQrRlUBKFgSlGJHpULMZRv _onDrag = new BRHkQnQrRlUBKFgSlGJHpULMZRv();

		private IZjsaHusWxOeivHzzXqQLNWasol _onEndDrag = new IZjsaHusWxOeivHzzXqQLNWasol();

		public bool hideAtRuntime
		{
			get
			{
				return _hideAtRuntime;
			}
			set
			{
				if (!(_hideAtRuntime = value))
				{
					_hideAtRuntime = true;
					OnSetProperty();
				}
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
			if (!Application.isPlaying)
			{
				return;
			}
			while (_hideAtRuntime)
			{
				base.visible = false;
				int num = 1315616591;
				while (true)
				{
					switch (num ^ 0x4E6AB74E)
					{
					case 0:
						goto IL_000e;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_000e:
					num = 1315616588;
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
				goto IL_000f;
			}
			goto IL_0068;
			IL_000f:
			int num = 514102612;
			goto IL_0014;
			IL_0014:
			while (true)
			{
				switch (num ^ 0x1EA49556)
				{
				case 4:
					break;
				default:
					return;
				case 6:
					if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
					{
						return;
					}
					goto case 0;
				case 5:
					return;
				case 7:
					goto IL_0068;
				case 0:
					if (_onPointerDown != null)
					{
						_onPointerDown.Invoke(eventData);
						num = 514102615;
						continue;
					}
					return;
				case 2:
					return;
				case 3:
					goto IL_00aa;
				case 1:
					return;
				}
				break;
				IL_00aa:
				int num2;
				if (IsInteractable())
				{
					num = 514102608;
					num2 = num;
				}
				else
				{
					num = 514102611;
					num2 = num;
				}
			}
			goto IL_000f;
			IL_0068:
			int num3;
			if (!WMOIUVAoMMEQPQHrJmvWWfvqFVh())
			{
				num = 514102611;
				num3 = num;
			}
			else
			{
				num = 514102613;
				num3 = num;
			}
			goto IL_0014;
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			if (!base.initialized)
			{
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!WMOIUVAoMMEQPQHrJmvWWfvqFVh())
				{
					num = 570856514;
					num2 = num;
				}
				else
				{
					num = 570856516;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x22069441)
					{
					case 0:
						num = 570856515;
						continue;
					default:
						return;
					case 1:
						if (_onPointerUp != null)
						{
							_onPointerUp.Invoke(eventData);
							num = 570856517;
							continue;
						}
						return;
					case 5:
					{
						int num3;
						if (!IsInteractable())
						{
							num = 570856514;
							num3 = num;
						}
						else
						{
							num = 570856519;
							num3 = num;
						}
						continue;
					}
					case 3:
						return;
					case 2:
						break;
					case 6:
						if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
						{
							return;
						}
						goto case 1;
					case 4:
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
				int num = -1436935810;
				while (true)
				{
					switch (num ^ -1436935809)
					{
					case 7:
						break;
					default:
						return;
					case 1:
						if (!base.initialized)
						{
							return;
						}
						goto case 6;
					case 5:
						return;
					case 6:
					{
						int num3;
						if (WMOIUVAoMMEQPQHrJmvWWfvqFVh())
						{
							num = -1436935813;
							num3 = num;
						}
						else
						{
							num = -1436935814;
							num3 = num;
						}
						continue;
					}
					case 2:
						if (_onPointerEnter != null)
						{
							_onPointerEnter.Invoke(eventData);
							num = -1436935812;
							continue;
						}
						return;
					case 0:
						if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
						{
							return;
						}
						goto case 2;
					case 4:
					{
						int num2;
						if (IsInteractable())
						{
							num = -1436935809;
							num2 = num;
						}
						else
						{
							num = -1436935814;
							num2 = num;
						}
						continue;
					}
					case 3:
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
			while (WMOIUVAoMMEQPQHrJmvWWfvqFVh())
			{
				int num;
				int num2;
				if (!IsInteractable())
				{
					num = 1872182049;
					num2 = num;
				}
				else
				{
					num = 1872182054;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x6F973B24)
					{
					case 4:
						num = 1872182053;
						continue;
					default:
						return;
					case 2:
						if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
						{
							return;
						}
						goto case 0;
					case 5:
						return;
					case 0:
						if (_onPointerExit != null)
						{
							_onPointerExit.Invoke(eventData);
							num = 1872182055;
							continue;
						}
						return;
					case 1:
						break;
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
			while (true)
			{
				int num = -1672916662;
				while (true)
				{
					switch (num ^ -1672916658)
					{
					case 7:
						break;
					default:
						return;
					case 0:
						if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag))
						{
							return;
						}
						goto case 8;
					case 8:
					{
						int num4;
						if (_onBeginDrag == null)
						{
							num = -1672916664;
							num4 = num;
						}
						else
						{
							num = -1672916659;
							num4 = num;
						}
						continue;
					}
					case 4:
					{
						int num3;
						if (!base.initialized)
						{
							num = -1672916660;
							num3 = num;
						}
						else
						{
							num = -1672916661;
							num3 = num;
						}
						continue;
					}
					case 3:
						_onBeginDrag.Invoke(eventData);
						num = -1672916664;
						continue;
					case 5:
						if (WMOIUVAoMMEQPQHrJmvWWfvqFVh())
						{
							int num2;
							if (!IsInteractable())
							{
								num = -1672916657;
								num2 = num;
							}
							else
							{
								num = -1672916658;
								num2 = num;
							}
							continue;
						}
						return;
					case 1:
						return;
					case 2:
						return;
					case 6:
						return;
					}
					break;
				}
			}
		}

		internal override void OnDrag(PointerEventData eventData)
		{
			base.OnDrag(eventData);
			while (true)
			{
				int num = -262766873;
				while (true)
				{
					switch (num ^ -262766874)
					{
					case 4:
						break;
					default:
						return;
					case 1:
					{
						int num3;
						if (!base.initialized)
						{
							num = -262766877;
							num3 = num;
						}
						else
						{
							num = -262766875;
							num3 = num;
						}
						continue;
					}
					case 7:
						return;
					case 3:
					{
						int num4;
						if (WMOIUVAoMMEQPQHrJmvWWfvqFVh())
						{
							num = -262766880;
							num4 = num;
						}
						else
						{
							num = -262766879;
							num4 = num;
						}
						continue;
					}
					case 8:
						if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.Drag))
						{
							return;
						}
						goto case 0;
					case 0:
						if (_onDrag != null)
						{
							_onDrag.Invoke(eventData);
							num = -262766876;
							continue;
						}
						return;
					case 6:
					{
						int num2;
						if (!IsInteractable())
						{
							num = -262766879;
							num2 = num;
						}
						else
						{
							num = -262766866;
							num2 = num;
						}
						continue;
					}
					case 5:
						return;
					case 2:
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
				goto IL_0012;
			}
			goto IL_00b6;
			IL_0012:
			int num = 942204541;
			goto IL_0017;
			IL_0017:
			while (true)
			{
				switch (num ^ 0x3828E675)
				{
				case 0:
					break;
				default:
					return;
				case 6:
					_onEndDrag.Invoke(eventData);
					num = 942204532;
					continue;
				case 2:
					goto IL_005e;
				case 3:
					goto IL_0077;
				case 8:
					return;
				case 4:
					return;
				case 7:
					goto IL_00b6;
				case 5:
					return;
				case 1:
					return;
				}
				break;
				IL_0077:
				int num2;
				if (!TouchInteractable.ULICFcJyRCkoAIPyRCsILRQGufn(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag))
				{
					num = 942204528;
					num2 = num;
				}
				else
				{
					num = 942204535;
					num2 = num;
				}
				continue;
				IL_005e:
				int num3;
				if (_onEndDrag != null)
				{
					num = 942204531;
					num3 = num;
				}
				else
				{
					num = 942204532;
					num3 = num;
				}
			}
			goto IL_0012;
			IL_00b6:
			if (!WMOIUVAoMMEQPQHrJmvWWfvqFVh())
			{
				return;
			}
			int num4;
			if (IsInteractable())
			{
				num = 942204534;
				num4 = num;
			}
			else
			{
				num = 942204529;
				num4 = num;
			}
			goto IL_0017;
		}
	}
}
