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
		private class hUcFxKGSvNGoKZPSNWAHqlfqwRU : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class eHracaDdZnHQfZfDZsntynwBFpcm : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class JbkDelaepEAhuMnzqYnKpkAtHzOt : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class xRGDoMBnejXysuOstTgJDpqxadtK : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class qySJHEuoQsVVuYWOLbjkFjBaDZX : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class ATOVsKShBSlQgzWXireNlOhieKc : UnityEvent<PointerEventData>
		{
		}

		[Serializable]
		private class HawEUocJgYoVKBdgsIgWCPwQFpwW : UnityEvent<PointerEventData>
		{
		}

		[SerializeField]
		[Tooltip("If enabled, the Touch Region will be hidden when gameplay starts.")]
		[CustomObfuscation(rename = false)]
		private bool _hideAtRuntime;

		private hUcFxKGSvNGoKZPSNWAHqlfqwRU _onPointerDown;

		private eHracaDdZnHQfZfDZsntynwBFpcm _onPointerUp;

		private JbkDelaepEAhuMnzqYnKpkAtHzOt _onPointerEnter;

		private xRGDoMBnejXysuOstTgJDpqxadtK _onPointerExit;

		private qySJHEuoQsVVuYWOLbjkFjBaDZX _onBeginDrag;

		private ATOVsKShBSlQgzWXireNlOhieKc _onDrag;

		private HawEUocJgYoVKBdgsIgWCPwQFpwW _onEndDrag;

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

		internal override void iagGGZhzoHvsifYztDyhsUjnGQZ()
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
