using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Region")]
	public sealed class TouchRegion : TouchInteractable
	{
		[Serializable]
		private class PmbmQogSnmfSfKtlPJMIuOhTpym : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class SEgAvANNgKrOEqaxRttsrbqgppM : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class plhjIZMGMdgjPsmBstvTsmWSCzo : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class HhXfokfVMSeVedOGbcaYTwzItBJ : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class YDXQcoChXXPTHDyQDfhBRDEZHip : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class isFhFggCatkCDwBlyceKedjNsMMN : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class pGhEDKBEPxPFfhEEkPyFlHebMjWz : UnityEvent<PointerEventData>
		{
		}

		[Tooltip("If enabled, the Touch Region will be hidden when gameplay starts.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _hideAtRuntime = true;

		private PmbmQogSnmfSfKtlPJMIuOhTpym _onPointerDown = new PmbmQogSnmfSfKtlPJMIuOhTpym();

		private SEgAvANNgKrOEqaxRttsrbqgppM _onPointerUp = new SEgAvANNgKrOEqaxRttsrbqgppM();

		private plhjIZMGMdgjPsmBstvTsmWSCzo _onPointerEnter = new plhjIZMGMdgjPsmBstvTsmWSCzo();

		private HhXfokfVMSeVedOGbcaYTwzItBJ _onPointerExit = new HhXfokfVMSeVedOGbcaYTwzItBJ();

		private YDXQcoChXXPTHDyQDfhBRDEZHip _onBeginDrag = new YDXQcoChXXPTHDyQDfhBRDEZHip();

		private isFhFggCatkCDwBlyceKedjNsMMN _onDrag = new isFhFggCatkCDwBlyceKedjNsMMN();

		private pGhEDKBEPxPFfhEEkPyFlHebMjWz _onEndDrag = new pGhEDKBEPxPFfhEEkPyFlHebMjWz();

		public bool hideAtRuntime
		{
			get
			{
				return _hideAtRuntime;
			}
			set
			{
				if (_hideAtRuntime = value)
				{
					return;
				}
				while (true)
				{
					_hideAtRuntime = true;
					int num = -515056663;
					while (true)
					{
						switch (num ^ -515056663)
						{
						case 2:
							goto IL_000d;
						case 1:
							break;
						default:
							wWklIWMVIReShFCdZhfAVVyDQgX();
							return;
						}
						break;
						IL_000d:
						num = -515056664;
					}
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
				int num = 1572465816;
				while (true)
				{
					switch (num ^ 0x5DB9EC98)
					{
					case 2:
						goto IL_000e;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_000e:
					num = 1572465817;
				}
			}
		}

		public override void ClearValue()
		{
		}

		internal override void KhATpHHLaxfVykPnYPwsOWKYpr()
		{
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			if (!base.initialized)
			{
				goto IL_0012;
			}
			goto IL_0093;
			IL_0012:
			int num = -1718938668;
			goto IL_0017;
			IL_0017:
			while (true)
			{
				switch (num ^ -1718938667)
				{
				case 4:
					break;
				default:
					return;
				case 8:
					goto IL_004b;
				case 6:
					return;
				case 5:
					return;
				case 2:
					_onPointerDown.Invoke(eventData);
					num = -1718938666;
					continue;
				case 7:
					goto IL_0093;
				case 0:
					goto IL_00b7;
				case 1:
					return;
				case 3:
					return;
				}
				break;
				IL_00b7:
				int num2;
				if (_onPointerDown != null)
				{
					num = -1718938665;
					num2 = num;
				}
				else
				{
					num = -1718938666;
					num2 = num;
				}
				continue;
				IL_004b:
				int num3;
				if (TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown))
				{
					num = -1718938667;
					num3 = num;
				}
				else
				{
					num = -1718938672;
					num3 = num;
				}
			}
			goto IL_0012;
			IL_0093:
			if (!pmYjhUyltIKROfKAKRLTAORpQYO())
			{
				return;
			}
			int num4;
			if (!IsInteractable())
			{
				num = -1718938669;
				num4 = num;
			}
			else
			{
				num = -1718938659;
				num4 = num;
			}
			goto IL_0017;
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			while (true)
			{
				int num = -229706833;
				while (true)
				{
					switch (num ^ -229706837)
					{
					case 3:
						break;
					default:
						return;
					case 7:
						if (_onPointerUp != null)
						{
							_onPointerUp.Invoke(eventData);
							num = -229706834;
							continue;
						}
						return;
					case 2:
						return;
					case 0:
					{
						int num3;
						if (IsInteractable())
						{
							num = -229706835;
							num3 = num;
						}
						else
						{
							num = -229706839;
							num3 = num;
						}
						continue;
					}
					case 1:
					{
						int num2;
						if (pmYjhUyltIKROfKAKRLTAORpQYO())
						{
							num = -229706837;
							num2 = num;
						}
						else
						{
							num = -229706839;
							num2 = num;
						}
						continue;
					}
					case 4:
						if (!base.initialized)
						{
							return;
						}
						goto case 1;
					case 6:
						if (!TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp))
						{
							return;
						}
						goto case 7;
					case 5:
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
				int num = -710942979;
				while (true)
				{
					switch (num ^ -710942980)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						if (!base.initialized)
						{
							return;
						}
						goto case 7;
					case 3:
						return;
					case 7:
					{
						int num2;
						if (!pmYjhUyltIKROfKAKRLTAORpQYO())
						{
							num = -710942977;
							num2 = num;
						}
						else
						{
							num = -710942984;
							num2 = num;
						}
						continue;
					}
					case 4:
					{
						int num3;
						if (!IsInteractable())
						{
							num = -710942977;
							num3 = num;
						}
						else
						{
							num = -710942978;
							num3 = num;
						}
						continue;
					}
					case 2:
						if (!TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter))
						{
							return;
						}
						goto case 6;
					case 6:
						if (_onPointerEnter != null)
						{
							_onPointerEnter.Invoke(eventData);
							num = -710942983;
							continue;
						}
						return;
					case 5:
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
			while (pmYjhUyltIKROfKAKRLTAORpQYO())
			{
				int num;
				int num2;
				if (IsInteractable())
				{
					num = 1552332190;
					num2 = num;
				}
				else
				{
					num = 1552332191;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x5C86B59B)
					{
					case 3:
						num = 1552332186;
						continue;
					default:
						return;
					case 2:
						if (_onPointerExit != null)
						{
							_onPointerExit.Invoke(eventData);
							num = 1552332187;
							continue;
						}
						return;
					case 6:
						return;
					case 1:
						break;
					case 4:
						return;
					case 5:
					{
						int num3;
						if (!TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit))
						{
							num = 1552332189;
							num3 = num;
						}
						else
						{
							num = 1552332185;
							num3 = num;
						}
						continue;
					}
					case 0:
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
			while (pmYjhUyltIKROfKAKRLTAORpQYO())
			{
				int num;
				int num2;
				if (!IsInteractable())
				{
					num = -973031238;
					num2 = num;
				}
				else
				{
					num = -973031235;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -973031239)
					{
					case 0:
						num = -973031237;
						continue;
					default:
						return;
					case 4:
						if (!TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag))
						{
							return;
						}
						goto case 1;
					case 1:
						if (_onBeginDrag != null)
						{
							_onBeginDrag.Invoke(eventData);
							num = -973031236;
							continue;
						}
						return;
					case 2:
						break;
					case 3:
						return;
					case 5:
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
			while (pmYjhUyltIKROfKAKRLTAORpQYO())
			{
				int num;
				int num2;
				if (!IsInteractable())
				{
					num = -1266302892;
					num2 = num;
				}
				else
				{
					num = -1266302889;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1266302891)
					{
					case 4:
						num = -1266302890;
						continue;
					default:
						return;
					case 3:
						break;
					case 2:
					{
						int num3;
						if (TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.Drag))
						{
							num = -1266302893;
							num3 = num;
						}
						else
						{
							num = -1266302891;
							num3 = num;
						}
						continue;
					}
					case 0:
						return;
					case 6:
						if (_onDrag != null)
						{
							_onDrag.Invoke(eventData);
							num = -1266302896;
							continue;
						}
						return;
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
				return;
			}
			while (pmYjhUyltIKROfKAKRLTAORpQYO())
			{
				int num;
				int num2;
				if (IsInteractable())
				{
					num = 2120320430;
					num2 = num;
				}
				else
				{
					num = 2120320428;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x7E6185AA)
					{
					case 0:
						num = 2120320431;
						continue;
					default:
						return;
					case 5:
						break;
					case 6:
						return;
					case 2:
						if (_onEndDrag != null)
						{
							_onEndDrag.Invoke(eventData);
							num = 2120320427;
							continue;
						}
						return;
					case 3:
						return;
					case 4:
					{
						int num3;
						if (!TouchInteractable.jlMLntvkuERbFtpXYbjRXNhFHnM(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag))
						{
							num = 2120320425;
							num3 = num;
						}
						else
						{
							num = 2120320424;
							num3 = num;
						}
						continue;
					}
					case 1:
						return;
					}
					break;
				}
			}
		}
	}
}
