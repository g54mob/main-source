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
		private class njoGXJAmGpOWyPLlQuEEonMlTkJi : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class ksbitzdiXJcODFxvQYDuDdTONEhMA : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class ZlwIfqostirdWtBXnvBFwuzkeILX : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class viEghLbBuTOiEYaWskMMhJJukCsvA : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class oMIcOTgaOAEZEFUciSXlMTefriOuc : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class QFQnjZEjPoHGKephjVIOpbOdynliA : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class ZJyPhYwaccZccPWGlYPUDVGFElcc : UnityEvent<PointerEventData>
		{
		}

		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the Touch Region will be hidden when gameplay starts.")]
		[SerializeField]
		private bool _hideAtRuntime = true;

		private njoGXJAmGpOWyPLlQuEEonMlTkJi _onPointerDown = new njoGXJAmGpOWyPLlQuEEonMlTkJi();

		private ksbitzdiXJcODFxvQYDuDdTONEhMA _onPointerUp = new ksbitzdiXJcODFxvQYDuDdTONEhMA();

		private ZlwIfqostirdWtBXnvBFwuzkeILX _onPointerEnter = new ZlwIfqostirdWtBXnvBFwuzkeILX();

		private viEghLbBuTOiEYaWskMMhJJukCsvA _onPointerExit = new viEghLbBuTOiEYaWskMMhJJukCsvA();

		private oMIcOTgaOAEZEFUciSXlMTefriOuc _onBeginDrag = new oMIcOTgaOAEZEFUciSXlMTefriOuc();

		private QFQnjZEjPoHGKephjVIOpbOdynliA _onDrag = new QFQnjZEjPoHGKephjVIOpbOdynliA();

		private ZJyPhYwaccZccPWGlYPUDVGFElcc _onEndDrag = new ZJyPhYwaccZccPWGlYPUDVGFElcc();

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
					CbvCdtcgkXIqLYOKEKJdhBmfrjFcB();
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

		internal override void upgGTAKdsvRzKrELaebaaupafzWBA()
		{
		}

		internal void iDcPScFqPAKcaOrORDGUfYntQieUA(PointerEventData P_0)
		{
			base.OnPointerDown(P_0);
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && BmJxkhIhAZjPFwDWRTfFEWoVOzdM() && IsInteractable() && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && _onPointerDown != null)
			{
				_onPointerDown.Invoke(P_0);
			}
		}

		internal void XfcNrzdiSTbjskEuHcqpZhemQemOA(PointerEventData P_0)
		{
			base.OnPointerUp(P_0);
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && BmJxkhIhAZjPFwDWRTfFEWoVOzdM() && IsInteractable() && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && _onPointerUp != null)
			{
				_onPointerUp.Invoke(P_0);
			}
		}

		internal void sqfXmEerQmdFDqvKtyJYjfmOGrxp(PointerEventData P_0)
		{
			base.OnPointerEnter(P_0);
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && BmJxkhIhAZjPFwDWRTfFEWoVOzdM() && IsInteractable() && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && _onPointerEnter != null)
			{
				_onPointerEnter.Invoke(P_0);
			}
		}

		internal void ZCZXbSDZYKzibqAMtttvAiafEgZk(PointerEventData P_0)
		{
			base.OnPointerExit(P_0);
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && BmJxkhIhAZjPFwDWRTfFEWoVOzdM() && IsInteractable() && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && _onPointerExit != null)
			{
				_onPointerExit.Invoke(P_0);
			}
		}

		internal void RcbhndaZEkdEPcJJNBuSGFCuzoxNA(PointerEventData P_0)
		{
			base.OnBeginDrag(P_0);
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && BmJxkhIhAZjPFwDWRTfFEWoVOzdM() && IsInteractable() && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag) && _onBeginDrag != null)
			{
				_onBeginDrag.Invoke(P_0);
			}
		}

		internal void ObMYqftcBzDHXCgICDCdelbgNFbQb(PointerEventData P_0)
		{
			base.OnDrag(P_0);
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && BmJxkhIhAZjPFwDWRTfFEWoVOzdM() && IsInteractable() && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.Drag) && _onDrag != null)
			{
				_onDrag.Invoke(P_0);
			}
		}

		internal void WGcUhoCpzgJyRkoXPxXcmJJxMyKG(PointerEventData P_0)
		{
			base.OnEndDrag(P_0);
			if (base.qumTafanxrjKbDduWdypwIzXqmiP && BmJxkhIhAZjPFwDWRTfFEWoVOzdM() && IsInteractable() && TouchInteractable.HnBjzONqNNfWUkKVRBXHBwGfCLnJ(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag) && _onEndDrag != null)
			{
				_onEndDrag.Invoke(P_0);
			}
		}
	}
}
