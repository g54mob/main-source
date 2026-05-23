using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Rewired.ComponentControls
{
	[Serializable]
	[DisallowMultipleComponent]
	[AddComponentMenu("Rewired/Touch Controls/Touch Region")]
	public sealed class TouchRegion : TouchInteractable
	{
		[Serializable]
		private class mlsQjFNKiLiFjAWBnwWEayMwVOHw : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class nRdACbmylvuBOuqDnihivXXHEJtbA : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class GLybQozeFWCsJKqlOotZOkjpoJNEb : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class kCIMDFUMtrlELdepHcnUFLfvXDqg : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class riKrRObiIwYXXBColpjcJqasbcYe : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class LdWAfLRPjCDmDiaNYgwIpqEmCitW : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class OqucaxErOSbOhZKeKFaXRVNKLXtEA : UnityEvent<PointerEventData>
		{
		}

		[Tooltip("If enabled, the Touch Region will be hidden when gameplay starts.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _hideAtRuntime = true;

		private mlsQjFNKiLiFjAWBnwWEayMwVOHw _onPointerDown = new mlsQjFNKiLiFjAWBnwWEayMwVOHw();

		private nRdACbmylvuBOuqDnihivXXHEJtbA _onPointerUp = new nRdACbmylvuBOuqDnihivXXHEJtbA();

		private GLybQozeFWCsJKqlOotZOkjpoJNEb _onPointerEnter = new GLybQozeFWCsJKqlOotZOkjpoJNEb();

		private kCIMDFUMtrlELdepHcnUFLfvXDqg _onPointerExit = new kCIMDFUMtrlELdepHcnUFLfvXDqg();

		private riKrRObiIwYXXBColpjcJqasbcYe _onBeginDrag = new riKrRObiIwYXXBColpjcJqasbcYe();

		private LdWAfLRPjCDmDiaNYgwIpqEmCitW _onDrag = new LdWAfLRPjCDmDiaNYgwIpqEmCitW();

		private OqucaxErOSbOhZKeKFaXRVNKLXtEA _onEndDrag = new OqucaxErOSbOhZKeKFaXRVNKLXtEA();

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
					dGrkdAigHPtPsfObCbIMleiXpdpl();
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
			if (Application.isPlaying && _hideAtRuntime)
			{
				base.visible = false;
			}
		}

		public override void ClearValue()
		{
		}

		internal void pVWnPtZIvlbYSSDGQvNenKwqDqBD()
		{
		}

		internal void YHcXtfIqSqLSVHedsIzbNJFoArKM(PointerEventData P_0)
		{
			base.OnPointerDown(P_0);
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && kxzKiGOSSGHSvNhOTCCxvpjgSZtV() && IsInteractable() && TouchInteractable.iOpZffgvbBhoeXghkKyyYqndWDJU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && _onPointerDown != null)
			{
				_onPointerDown.Invoke(P_0);
			}
		}

		internal void ooRKespfJHqWXvFtFfrgAWDBprLJ(PointerEventData P_0)
		{
			base.OnPointerUp(P_0);
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && kxzKiGOSSGHSvNhOTCCxvpjgSZtV() && IsInteractable() && TouchInteractable.iOpZffgvbBhoeXghkKyyYqndWDJU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && _onPointerUp != null)
			{
				_onPointerUp.Invoke(P_0);
			}
		}

		internal void ZBcpCpaOOnrsvFFIqBnYjcRhOPab(PointerEventData P_0)
		{
			base.OnPointerEnter(P_0);
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && kxzKiGOSSGHSvNhOTCCxvpjgSZtV() && IsInteractable() && TouchInteractable.iOpZffgvbBhoeXghkKyyYqndWDJU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && _onPointerEnter != null)
			{
				_onPointerEnter.Invoke(P_0);
			}
		}

		internal void jtpXjMjuwLakoKUZpiWqkWvtzDsF(PointerEventData P_0)
		{
			base.OnPointerExit(P_0);
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && kxzKiGOSSGHSvNhOTCCxvpjgSZtV() && IsInteractable() && TouchInteractable.iOpZffgvbBhoeXghkKyyYqndWDJU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && _onPointerExit != null)
			{
				_onPointerExit.Invoke(P_0);
			}
		}

		internal void zsHvPUWDFMIANCffmpnfklgxnWbab(PointerEventData P_0)
		{
			base.OnBeginDrag(P_0);
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && kxzKiGOSSGHSvNhOTCCxvpjgSZtV() && IsInteractable() && TouchInteractable.iOpZffgvbBhoeXghkKyyYqndWDJU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag) && _onBeginDrag != null)
			{
				_onBeginDrag.Invoke(P_0);
			}
		}

		internal void FOIYjpBJqgIAVVeBqZBPsMWDRKWw(PointerEventData P_0)
		{
			base.OnDrag(P_0);
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && kxzKiGOSSGHSvNhOTCCxvpjgSZtV() && IsInteractable() && TouchInteractable.iOpZffgvbBhoeXghkKyyYqndWDJU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.Drag) && _onDrag != null)
			{
				_onDrag.Invoke(P_0);
			}
		}

		internal void bLWUHSvOAqPyasVBBSNXIHSCXzLO(PointerEventData P_0)
		{
			base.OnEndDrag(P_0);
			if (base.JwovWyXnUHPSJEoogdblYDhMeVmfA && kxzKiGOSSGHSvNhOTCCxvpjgSZtV() && IsInteractable() && TouchInteractable.iOpZffgvbBhoeXghkKyyYqndWDJU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag) && _onEndDrag != null)
			{
				_onEndDrag.Invoke(P_0);
			}
		}
	}
}
