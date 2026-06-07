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
		private bool _hideAtRuntime;

		private ViYYOcvWLDOQQSviIDdWvjdrBHYZ _onPointerDown;

		private MWHnIRWIVhGfymmkMIcgogdAKiaD _onPointerUp;

		private fdOtjZLupUhgygObfIiHtEAsOnEI _onPointerEnter;

		private FlyBpkqvddloyzoNkrVSYtcqUGzo _onPointerExit;

		private SKcIOgFyRwVHmDAjWESnEHTtkuNv _onBeginDrag;

		private eJwvxaxIKAYMigqkzLqOuhFzljad _onDrag;

		private leWfDORmbYaDWkOXlcRVnKiXbUqnA _onEndDrag;

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

		internal override void GNCccHkqTowQUzFFJjdyvdxeUTNB()
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
