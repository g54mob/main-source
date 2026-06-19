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
		private class ViYYOcvWLDOQQSviIDdWvjdrBHYZ : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class MWHnIRWIVhGfymmkMIcgogdAKiaD : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class fdOtjZLupUhgygObfIiHtEAsOnEI : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class FlyBpkqvddloyzoNkrVSYtcqUGzo : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class SKcIOgFyRwVHmDAjWESnEHTtkuNv : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class eJwvxaxIKAYMigqkzLqOuhFzljad : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class leWfDORmbYaDWkOXlcRVnKiXbUqnA : UnityEvent<PointerEventData>
		{
		}

		[Tooltip("If enabled, the Touch Region will be hidden when gameplay starts.")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _hideAtRuntime = true;

		private ViYYOcvWLDOQQSviIDdWvjdrBHYZ _onPointerDown = new ViYYOcvWLDOQQSviIDdWvjdrBHYZ();

		private MWHnIRWIVhGfymmkMIcgogdAKiaD _onPointerUp = new MWHnIRWIVhGfymmkMIcgogdAKiaD();

		private fdOtjZLupUhgygObfIiHtEAsOnEI _onPointerEnter = new fdOtjZLupUhgygObfIiHtEAsOnEI();

		private FlyBpkqvddloyzoNkrVSYtcqUGzo _onPointerExit = new FlyBpkqvddloyzoNkrVSYtcqUGzo();

		private SKcIOgFyRwVHmDAjWESnEHTtkuNv _onBeginDrag = new SKcIOgFyRwVHmDAjWESnEHTtkuNv();

		private eJwvxaxIKAYMigqkzLqOuhFzljad _onDrag = new eJwvxaxIKAYMigqkzLqOuhFzljad();

		private leWfDORmbYaDWkOXlcRVnKiXbUqnA _onEndDrag = new leWfDORmbYaDWkOXlcRVnKiXbUqnA();

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
					YmRcFnSGPDloZzprndIQeqXQHaodA();
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

		internal void GWsClEbnbdsezCqajKTauedpSlKf()
		{
		}

		internal void pnOsKCaqtgTSmBQITfOpCsejGqFs(PointerEventData P_0)
		{
			base.OnPointerDown(P_0);
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && FBTWPzcXpWlDMTGvkvxpkZYxUkml() && IsInteractable() && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerDown) && _onPointerDown != null)
			{
				_onPointerDown.Invoke(P_0);
			}
		}

		internal void JYtjVDRSeZrAyxeUqGKiBWsESmCN(PointerEventData P_0)
		{
			base.OnPointerUp(P_0);
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && FBTWPzcXpWlDMTGvkvxpkZYxUkml() && IsInteractable() && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerUp) && _onPointerUp != null)
			{
				_onPointerUp.Invoke(P_0);
			}
		}

		internal void cWdELpWedUceVZIsleazqKTCfVWu(PointerEventData P_0)
		{
			base.OnPointerEnter(P_0);
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && FBTWPzcXpWlDMTGvkvxpkZYxUkml() && IsInteractable() && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerEnter) && _onPointerEnter != null)
			{
				_onPointerEnter.Invoke(P_0);
			}
		}

		internal void CZBqTrFjHVdNLWWySFpmtjjqcwff(PointerEventData P_0)
		{
			base.OnPointerExit(P_0);
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && FBTWPzcXpWlDMTGvkvxpkZYxUkml() && IsInteractable() && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.PointerExit) && _onPointerExit != null)
			{
				_onPointerExit.Invoke(P_0);
			}
		}

		internal void YblUixoRaEDvqtcATkIncKLuxDwW(PointerEventData P_0)
		{
			base.OnBeginDrag(P_0);
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && FBTWPzcXpWlDMTGvkvxpkZYxUkml() && IsInteractable() && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.BeginDrag) && _onBeginDrag != null)
			{
				_onBeginDrag.Invoke(P_0);
			}
		}

		internal void moxdAGhPDqFeIDilXuTmlhqIXFKb(PointerEventData P_0)
		{
			base.OnDrag(P_0);
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && FBTWPzcXpWlDMTGvkvxpkZYxUkml() && IsInteractable() && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.Drag) && _onDrag != null)
			{
				_onDrag.Invoke(P_0);
			}
		}

		internal void OnuMyfZZxoQpBsKokJsZRJjXdwSEA(PointerEventData P_0)
		{
			base.OnEndDrag(P_0);
			if (base.kCCUxJdqnJEDkElVVvKpRTWHmWjo && FBTWPzcXpWlDMTGvkvxpkZYxUkml() && IsInteractable() && TouchInteractable.ZDZuvEMKmBsxLRSOFJrwROHkMQQc(P_0.pointerId, base.allowedMouseButtons, EventTriggerType.EndDrag) && _onEndDrag != null)
			{
				_onEndDrag.Invoke(P_0);
			}
		}
	}
}
