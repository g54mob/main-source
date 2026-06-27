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
		private class MundKyYNyXIyNJfWsERtHZgppizT : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class FCyqxMbvxpaFmpxCkixVSrvEtDRJ : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class qwvrvTmbZKmPxruaBJyeDZXoCjzV : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class AyTUlqZpGdoYruXpWPznsVfcvlOU : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class DCJwCisQcmgvrGqZmmNSkfQfKBkR : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class hpDEvmAVpMBqdjRQFvdzSaqxUKPX : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class gbnTeYoAKCrKDJajTjtoeLvHbmVi : UnityEvent<PointerEventData>
		{
		}

		[Tooltip("If enabled, the Touch Region will be hidden when gameplay starts.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _hideAtRuntime = true;

		private MundKyYNyXIyNJfWsERtHZgppizT _onPointerDown = new MundKyYNyXIyNJfWsERtHZgppizT();

		private FCyqxMbvxpaFmpxCkixVSrvEtDRJ _onPointerUp = new FCyqxMbvxpaFmpxCkixVSrvEtDRJ();

		private qwvrvTmbZKmPxruaBJyeDZXoCjzV _onPointerEnter = new qwvrvTmbZKmPxruaBJyeDZXoCjzV();

		private AyTUlqZpGdoYruXpWPznsVfcvlOU _onPointerExit = new AyTUlqZpGdoYruXpWPznsVfcvlOU();

		private DCJwCisQcmgvrGqZmmNSkfQfKBkR _onBeginDrag = new DCJwCisQcmgvrGqZmmNSkfQfKBkR();

		private hpDEvmAVpMBqdjRQFvdzSaqxUKPX _onDrag = new hpDEvmAVpMBqdjRQFvdzSaqxUKPX();

		private gbnTeYoAKCrKDJajTjtoeLvHbmVi _onEndDrag = new gbnTeYoAKCrKDJajTjtoeLvHbmVi();

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
					HAozJjtCaBQEIiVJLswvClYOjXTs();
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

		internal void FrXEEUKWQbcSeLXERyaHEzcbrtll()
		{
		}

		internal void qSfAOcNCDoehpEsxziOvcpDrZbue(PointerEventData P_0)
		{
			base.OnPointerDown(P_0);
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && GlaXMdVzEWtLRKxLWJPCCCZtpeXE() && IsInteractable() && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && _onPointerDown != null)
			{
				_onPointerDown.Invoke(P_0);
			}
		}

		internal void OdOEdJBuFRuTrtkqWSeNgffKoHpEb(PointerEventData P_0)
		{
			base.OnPointerUp(P_0);
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && GlaXMdVzEWtLRKxLWJPCCCZtpeXE() && IsInteractable() && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && _onPointerUp != null)
			{
				_onPointerUp.Invoke(P_0);
			}
		}

		internal void xLUsUnnSIOMOKKDKLRMSSnQQEatt(PointerEventData P_0)
		{
			base.OnPointerEnter(P_0);
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && GlaXMdVzEWtLRKxLWJPCCCZtpeXE() && IsInteractable() && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && _onPointerEnter != null)
			{
				_onPointerEnter.Invoke(P_0);
			}
		}

		internal void FfikgriooRAZMDwQyzrXXfiubJWU(PointerEventData P_0)
		{
			base.OnPointerExit(P_0);
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && GlaXMdVzEWtLRKxLWJPCCCZtpeXE() && IsInteractable() && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && _onPointerExit != null)
			{
				_onPointerExit.Invoke(P_0);
			}
		}

		internal void VyGelvPFVGjxNciWfkCGGIqcaRqb(PointerEventData P_0)
		{
			base.OnBeginDrag(P_0);
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && GlaXMdVzEWtLRKxLWJPCCCZtpeXE() && IsInteractable() && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag) && _onBeginDrag != null)
			{
				_onBeginDrag.Invoke(P_0);
			}
		}

		internal void fFFnrCMMcopjbKuWnIUoBcgClieY(PointerEventData P_0)
		{
			base.OnDrag(P_0);
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && GlaXMdVzEWtLRKxLWJPCCCZtpeXE() && IsInteractable() && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.Drag) && _onDrag != null)
			{
				_onDrag.Invoke(P_0);
			}
		}

		internal void TPFgfhwYFsZCohOFAYysxyDxVzxA(PointerEventData P_0)
		{
			base.OnEndDrag(P_0);
			if (base.fcnhgNSGjBrchLlUpyTOdBRVbCMd && GlaXMdVzEWtLRKxLWJPCCCZtpeXE() && IsInteractable() && TouchInteractable.QFueiYlivNoOUGWavitZpFHwnfzU(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag) && _onEndDrag != null)
			{
				_onEndDrag.Invoke(P_0);
			}
		}
	}
}
