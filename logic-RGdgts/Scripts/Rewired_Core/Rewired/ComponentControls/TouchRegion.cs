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

		[CustomObfuscation]
		[SerializeField]
		private bool _hideAtRuntime;

		private njoGXJAmGpOWyPLlQuEEonMlTkJi _onPointerDown;

		private ksbitzdiXJcODFxvQYDuDdTONEhMA _onPointerUp;

		private ZlwIfqostirdWtBXnvBFwuzkeILX _onPointerEnter;

		private viEghLbBuTOiEYaWskMMhJJukCsvA _onPointerExit;

		private oMIcOTgaOAEZEFUciSXlMTefriOuc _onBeginDrag;

		private QFQnjZEjPoHGKephjVIOpbOdynliA _onDrag;

		private ZJyPhYwaccZccPWGlYPUDVGFElcc _onEndDrag;

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

		[CustomObfuscation]
		private TouchRegion()
		{
		}

		[CustomObfuscation]
		internal override void Awake()
		{
		}

		public override void ClearValue()
		{
		}

		internal override void upgGTAKdsvRzKrELaebaaupafzWBA()
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
