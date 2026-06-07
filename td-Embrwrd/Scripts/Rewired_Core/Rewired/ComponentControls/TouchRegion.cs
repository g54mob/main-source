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
		private class XcakcZybVJstfjysEhofDVVKiyWb : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class KClbRlGTqvHwGCLwDAWKuSMozvSsb : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class rIwyVuGGCOsRRTHKzOYlBxkHBteN : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class ZKURFVrhZdjCTKoLyaZqyvALwvDM : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class KnILuLUihaipNJuhAPYHHsdICLxHb : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class mpUDBJjqaMIkZOTsdAZyKULUsAUfA : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class vdazypMfTKlzhxLrxPFluCGmxBSJ : UnityEvent<PointerEventData>
		{
		}

		[CustomObfuscation(rename = false)]
		[Tooltip("If enabled, the Touch Region will be hidden when gameplay starts.")]
		[SerializeField]
		private bool _hideAtRuntime;

		private XcakcZybVJstfjysEhofDVVKiyWb _onPointerDown;

		private KClbRlGTqvHwGCLwDAWKuSMozvSsb _onPointerUp;

		private rIwyVuGGCOsRRTHKzOYlBxkHBteN _onPointerEnter;

		private ZKURFVrhZdjCTKoLyaZqyvALwvDM _onPointerExit;

		private KnILuLUihaipNJuhAPYHHsdICLxHb _onBeginDrag;

		private mpUDBJjqaMIkZOTsdAZyKULUsAUfA _onDrag;

		private vdazypMfTKlzhxLrxPFluCGmxBSJ _onEndDrag;

		public bool hideAtRuntime
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event UnityAction<PointerEventData> PointerDownEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction<PointerEventData> PointerUpEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction<PointerEventData> PointerEnterEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction<PointerEventData> PointerExitEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction<PointerEventData> BeginDragEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction<PointerEventData> DragEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction<PointerEventData> EndDragEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		[CustomObfuscation(rename = false)]
		private TouchRegion()
		{
		}

		[CustomObfuscation(rename = false)]
		internal override void Awake()
		{
		}

		public override void ClearValue()
		{
		}

		internal override void UQizGkdUUglAlSKLFhpOGRJTqnpDb()
		{
		}

		internal override void OnPointerDown(PointerEventData P_0)
		{
		}

		internal override void OnPointerUp(PointerEventData P_0)
		{
		}

		internal override void OnPointerEnter(PointerEventData P_0)
		{
		}

		internal override void OnPointerExit(PointerEventData P_0)
		{
		}

		internal override void OnBeginDrag(PointerEventData P_0)
		{
		}

		internal override void OnDrag(PointerEventData P_0)
		{
		}

		internal override void OnEndDrag(PointerEventData P_0)
		{
		}
	}
}
