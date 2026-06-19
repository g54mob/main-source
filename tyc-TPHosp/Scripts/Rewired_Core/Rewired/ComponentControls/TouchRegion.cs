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
		private class ZQaTFVuoASbsPchXoQvFrOpBNXd : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class QifkpKHRHqqDsVPkqCojPeacUjP : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class paRaydErTKVdMPtXpWOQxYYzYt : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class JDCaeDxsssWIjKceEhPNDfiACUUw : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class MRMXrTWgGnJlhgyGkfOidsVFTeu : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class yvIyuZafJVktzJZMNJyNDnHFnoD : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class xZggMjAYkJOjVtNoTEPIrRijEMRa : UnityEvent<PointerEventData>
		{
		}

		[SerializeField]
		[Tooltip("If enabled, the Touch Region will be hidden when gameplay starts.")]
		[CustomObfuscation(rename = false)]
		private bool _hideAtRuntime = true;

		private ZQaTFVuoASbsPchXoQvFrOpBNXd _onPointerDown = new ZQaTFVuoASbsPchXoQvFrOpBNXd();

		private QifkpKHRHqqDsVPkqCojPeacUjP _onPointerUp = new QifkpKHRHqqDsVPkqCojPeacUjP();

		private paRaydErTKVdMPtXpWOQxYYzYt _onPointerEnter = new paRaydErTKVdMPtXpWOQxYYzYt();

		private JDCaeDxsssWIjKceEhPNDfiACUUw _onPointerExit = new JDCaeDxsssWIjKceEhPNDfiACUUw();

		private MRMXrTWgGnJlhgyGkfOidsVFTeu _onBeginDrag = new MRMXrTWgGnJlhgyGkfOidsVFTeu();

		private yvIyuZafJVktzJZMNJyNDnHFnoD _onDrag = new yvIyuZafJVktzJZMNJyNDnHFnoD();

		private xZggMjAYkJOjVtNoTEPIrRijEMRa _onEndDrag = new xZggMjAYkJOjVtNoTEPIrRijEMRa();

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
					qdlBanCKskFYgFyewDKidbPGRpbJ();
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

		internal override void OnoIpIJycGHhdFNrMapnMHSEpPu()
		{
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			if (base.initialized && zCDiilIuMmyrwiYynasIRcHvrxTh() && IsInteractable() && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && _onPointerDown != null)
			{
				_onPointerDown.Invoke(eventData);
			}
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			if (base.initialized && zCDiilIuMmyrwiYynasIRcHvrxTh() && IsInteractable() && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && _onPointerUp != null)
			{
				_onPointerUp.Invoke(eventData);
			}
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			if (base.initialized && zCDiilIuMmyrwiYynasIRcHvrxTh() && IsInteractable() && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && _onPointerEnter != null)
			{
				_onPointerEnter.Invoke(eventData);
			}
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			if (base.initialized && zCDiilIuMmyrwiYynasIRcHvrxTh() && IsInteractable() && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && _onPointerExit != null)
			{
				_onPointerExit.Invoke(eventData);
			}
		}

		internal override void OnBeginDrag(PointerEventData eventData)
		{
			base.OnBeginDrag(eventData);
			if (base.initialized && zCDiilIuMmyrwiYynasIRcHvrxTh() && IsInteractable() && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag) && _onBeginDrag != null)
			{
				_onBeginDrag.Invoke(eventData);
			}
		}

		internal override void OnDrag(PointerEventData eventData)
		{
			base.OnDrag(eventData);
			if (base.initialized && zCDiilIuMmyrwiYynasIRcHvrxTh() && IsInteractable() && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.Drag) && _onDrag != null)
			{
				_onDrag.Invoke(eventData);
			}
		}

		internal override void OnEndDrag(PointerEventData eventData)
		{
			base.OnEndDrag(eventData);
			if (base.initialized && zCDiilIuMmyrwiYynasIRcHvrxTh() && IsInteractable() && TouchInteractable.tPJtiKnlJapLvOXtvbEAppvVFMJ(eventData.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag) && _onEndDrag != null)
			{
				_onEndDrag.Invoke(eventData);
			}
		}
	}
}
