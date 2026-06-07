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
		private class MSkxNMeuonarEsrVxhKidnjihFNs : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class TIrmCkBpcPbdnMbRpflSwBuDDMdS : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class iOogfGKVxmUcnCtECxhOnIwfWZnb : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class YYObmEjVSLdRmVfkREaeAIwtFWmZA : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class HqAHnMUGkOEcylSMtCfJMkXesKAK : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class rwAcRKgzCyngoWHHOiWkurbyvOdh : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class mtuEGqYMUimaOiYcUUarQcuSBMtbA : UnityEvent<PointerEventData>
		{
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("If enabled, the Touch Region will be hidden when gameplay starts.")]
		private bool _hideAtRuntime = true;

		private MSkxNMeuonarEsrVxhKidnjihFNs _onPointerDown = new MSkxNMeuonarEsrVxhKidnjihFNs();

		private TIrmCkBpcPbdnMbRpflSwBuDDMdS _onPointerUp = new TIrmCkBpcPbdnMbRpflSwBuDDMdS();

		private iOogfGKVxmUcnCtECxhOnIwfWZnb _onPointerEnter = new iOogfGKVxmUcnCtECxhOnIwfWZnb();

		private YYObmEjVSLdRmVfkREaeAIwtFWmZA _onPointerExit = new YYObmEjVSLdRmVfkREaeAIwtFWmZA();

		private HqAHnMUGkOEcylSMtCfJMkXesKAK _onBeginDrag = new HqAHnMUGkOEcylSMtCfJMkXesKAK();

		private rwAcRKgzCyngoWHHOiWkurbyvOdh _onDrag = new rwAcRKgzCyngoWHHOiWkurbyvOdh();

		private mtuEGqYMUimaOiYcUUarQcuSBMtbA _onEndDrag = new mtuEGqYMUimaOiYcUUarQcuSBMtbA();

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
					jebsoqOBGHhJxfFgdjbRaKVujtZwA();
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

		internal override void NSaIxTLXSfKHgYqfDPqUzdSfjLOK()
		{
		}

		internal void PGwFOvjzBABNClsiikWqPSHmkSaE(PointerEventData P_0)
		{
			base.OnPointerDown(P_0);
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && uITeqmergHcifeDewaJvLHRSazjqA() && IsInteractable() && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && _onPointerDown != null)
			{
				_onPointerDown.Invoke(P_0);
			}
		}

		internal void kIuurkBaeVQXEvKeoUpHwDFvanke(PointerEventData P_0)
		{
			base.OnPointerUp(P_0);
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && uITeqmergHcifeDewaJvLHRSazjqA() && IsInteractable() && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && _onPointerUp != null)
			{
				_onPointerUp.Invoke(P_0);
			}
		}

		internal void JnpzKJYnsyfOfPwsOaQsJaDHZrbTA(PointerEventData P_0)
		{
			base.OnPointerEnter(P_0);
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && uITeqmergHcifeDewaJvLHRSazjqA() && IsInteractable() && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && _onPointerEnter != null)
			{
				_onPointerEnter.Invoke(P_0);
			}
		}

		internal void oZNXKPzrkOQGHJcuOrJBZbPcRSZn(PointerEventData P_0)
		{
			base.OnPointerExit(P_0);
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && uITeqmergHcifeDewaJvLHRSazjqA() && IsInteractable() && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && _onPointerExit != null)
			{
				_onPointerExit.Invoke(P_0);
			}
		}

		internal void ipdaaERukGdhLuzwhGwIglbtwlT(PointerEventData P_0)
		{
			base.OnBeginDrag(P_0);
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && uITeqmergHcifeDewaJvLHRSazjqA() && IsInteractable() && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag) && _onBeginDrag != null)
			{
				_onBeginDrag.Invoke(P_0);
			}
		}

		internal void xRSxtmDlpdoibPBivduBkZSMLJfO(PointerEventData P_0)
		{
			base.OnDrag(P_0);
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && uITeqmergHcifeDewaJvLHRSazjqA() && IsInteractable() && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.Drag) && _onDrag != null)
			{
				_onDrag.Invoke(P_0);
			}
		}

		internal void rDkVJzgnLccmpdPbaUZYcnygmWQcA(PointerEventData P_0)
		{
			base.OnEndDrag(P_0);
			if (base.DlyzgeEtPbGSRivIvEmZhBSIEqiU && uITeqmergHcifeDewaJvLHRSazjqA() && IsInteractable() && TouchInteractable.cWTWoPfxtFMCeZPheBprQnfcNOhy(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag) && _onEndDrag != null)
			{
				_onEndDrag.Invoke(P_0);
			}
		}
	}
}
