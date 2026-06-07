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
		private class LRcXBbUsAYkTJTBuoZFUNAxKEznc : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class YEKTqdnDbgIiyBpZgkinCAXftLZlB : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class dYVtskyNBJvXnnZpRjsAJRrHgTneA : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class DUbncLBOCcUGjkFiKfdDCiTHIPURA : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class MxzqTTgncxbltAQImxeicyeMzfqOA : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class iTxDcRkIzHBidGrHAJzFQYYITqNEb : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class bXRIUxqJSVxnBZCwVDlYsKRqyLJV : UnityEvent<PointerEventData>
		{
		}

		[Tooltip("If enabled, the Touch Region will be hidden when gameplay starts.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _hideAtRuntime = true;

		private LRcXBbUsAYkTJTBuoZFUNAxKEznc _onPointerDown = new LRcXBbUsAYkTJTBuoZFUNAxKEznc();

		private YEKTqdnDbgIiyBpZgkinCAXftLZlB _onPointerUp = new YEKTqdnDbgIiyBpZgkinCAXftLZlB();

		private dYVtskyNBJvXnnZpRjsAJRrHgTneA _onPointerEnter = new dYVtskyNBJvXnnZpRjsAJRrHgTneA();

		private DUbncLBOCcUGjkFiKfdDCiTHIPURA _onPointerExit = new DUbncLBOCcUGjkFiKfdDCiTHIPURA();

		private MxzqTTgncxbltAQImxeicyeMzfqOA _onBeginDrag = new MxzqTTgncxbltAQImxeicyeMzfqOA();

		private iTxDcRkIzHBidGrHAJzFQYYITqNEb _onDrag = new iTxDcRkIzHBidGrHAJzFQYYITqNEb();

		private bXRIUxqJSVxnBZCwVDlYsKRqyLJV _onEndDrag = new bXRIUxqJSVxnBZCwVDlYsKRqyLJV();

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
					GVYKMShboUeUKeoSXOyDKQsdAjHGb();
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

		internal void WJriHxULGcdKoRQTVXefGgYKcBzbA()
		{
		}

		internal void xsRZJbJZCpmllYMjrgTcoOFUhmyF(PointerEventData P_0)
		{
			base.OnPointerDown(P_0);
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && DfQIcSJUPXlHPQKgUHsgOrKCBhBG() && IsInteractable() && TouchInteractable.JGWFphEzfGdSUNCbtbtdWjvDOLzcb(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && _onPointerDown != null)
			{
				_onPointerDown.Invoke(P_0);
			}
		}

		internal void BFufikuuFQLVxeGpOjatCxTvmxpfA(PointerEventData P_0)
		{
			base.OnPointerUp(P_0);
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && DfQIcSJUPXlHPQKgUHsgOrKCBhBG() && IsInteractable() && TouchInteractable.JGWFphEzfGdSUNCbtbtdWjvDOLzcb(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && _onPointerUp != null)
			{
				_onPointerUp.Invoke(P_0);
			}
		}

		internal void gGwRBQjwSBJWEGfZLsQkYqudMIxP(PointerEventData P_0)
		{
			base.OnPointerEnter(P_0);
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && DfQIcSJUPXlHPQKgUHsgOrKCBhBG() && IsInteractable() && TouchInteractable.JGWFphEzfGdSUNCbtbtdWjvDOLzcb(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && _onPointerEnter != null)
			{
				_onPointerEnter.Invoke(P_0);
			}
		}

		internal void CIGAfOjqgMqNCoHLyeppFLMiFnQOb(PointerEventData P_0)
		{
			base.OnPointerExit(P_0);
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && DfQIcSJUPXlHPQKgUHsgOrKCBhBG() && IsInteractable() && TouchInteractable.JGWFphEzfGdSUNCbtbtdWjvDOLzcb(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && _onPointerExit != null)
			{
				_onPointerExit.Invoke(P_0);
			}
		}

		internal void IesrlWHbJDidhiUhvVagCtiLqQNP(PointerEventData P_0)
		{
			base.OnBeginDrag(P_0);
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && DfQIcSJUPXlHPQKgUHsgOrKCBhBG() && IsInteractable() && TouchInteractable.JGWFphEzfGdSUNCbtbtdWjvDOLzcb(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag) && _onBeginDrag != null)
			{
				_onBeginDrag.Invoke(P_0);
			}
		}

		internal void yBlXinQmytQlnWAPrlOMRHIxEOsGA(PointerEventData P_0)
		{
			base.OnDrag(P_0);
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && DfQIcSJUPXlHPQKgUHsgOrKCBhBG() && IsInteractable() && TouchInteractable.JGWFphEzfGdSUNCbtbtdWjvDOLzcb(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.Drag) && _onDrag != null)
			{
				_onDrag.Invoke(P_0);
			}
		}

		internal void SxpBnUsLKvNwUzdRYgCMpHOgMnho(PointerEventData P_0)
		{
			base.OnEndDrag(P_0);
			if (base.ufLiLiMyYKjqbRkyhyTivexwTJMJ && DfQIcSJUPXlHPQKgUHsgOrKCBhBG() && IsInteractable() && TouchInteractable.JGWFphEzfGdSUNCbtbtdWjvDOLzcb(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag) && _onEndDrag != null)
			{
				_onEndDrag.Invoke(P_0);
			}
		}
	}
}
