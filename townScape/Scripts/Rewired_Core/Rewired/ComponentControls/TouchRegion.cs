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
		private class gsVVnjahunGDOPTJDcdfIAIXPwKF : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class zjYUGJBhuDTVfrZXFYKDBRccrVy : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class OpZWWhCLFygkZfpoQYccWjfMjSL : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class syfCMbfIMPDdqKiihnVzhrFOItlr : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class nQlpfzEWeEQsiCnWPODWbayTJwR : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class LVrUvjktoaDTcxPboLNfFMOFEBm : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class STFDoBGrOiUOEFpcuQXehBLvnpg : UnityEvent<PointerEventData>
		{
		}

		[CustomObfuscation]
		[SerializeField]
		private bool _hideAtRuntime;

		private gsVVnjahunGDOPTJDcdfIAIXPwKF _onPointerDown;

		private zjYUGJBhuDTVfrZXFYKDBRccrVy _onPointerUp;

		private OpZWWhCLFygkZfpoQYccWjfMjSL _onPointerEnter;

		private syfCMbfIMPDdqKiihnVzhrFOItlr _onPointerExit;

		private nQlpfzEWeEQsiCnWPODWbayTJwR _onBeginDrag;

		private LVrUvjktoaDTcxPboLNfFMOFEBm _onDrag;

		private STFDoBGrOiUOEFpcuQXehBLvnpg _onEndDrag;

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

		internal override void ttJAqkHGCfTssfJpreeBeSfOQEJn()
		{
		}

		internal override void OnPointerDown(PointerEventData eventData)
		{
		}

		internal override void OnPointerUp(PointerEventData eventData)
		{
		}

		internal override void OnPointerEnter(PointerEventData eventData)
		{
		}

		internal override void OnPointerExit(PointerEventData eventData)
		{
		}

		internal override void OnBeginDrag(PointerEventData eventData)
		{
		}

		internal override void OnDrag(PointerEventData eventData)
		{
		}

		internal override void OnEndDrag(PointerEventData eventData)
		{
		}
	}
}
