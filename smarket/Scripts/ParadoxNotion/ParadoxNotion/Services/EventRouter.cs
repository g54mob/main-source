using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ParadoxNotion.Services
{
	public class EventRouter : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IDragHandler, IScrollHandler, IUpdateSelectedHandler, ISelectHandler, IDeselectHandler, IMoveHandler, ISubmitHandler, IDropHandler
	{
		public delegate void EventDelegate(EventData msg);

		public delegate void EventDelegate<T>(EventData<T> msg);

		public delegate void CustomEventDelegate(string name, IEventData data);

		private EventRouterAnimatorMove _routerAnimatorMove;

		public event EventDelegate<PointerEventData> onPointerEnter
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<PointerEventData> onPointerExit
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<PointerEventData> onPointerDown
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<PointerEventData> onPointerUp
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<PointerEventData> onPointerClick
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<PointerEventData> onDrag
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<PointerEventData> onDrop
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<PointerEventData> onScroll
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<BaseEventData> onUpdateSelected
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<BaseEventData> onSelect
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<BaseEventData> onDeselect
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<AxisEventData> onMove
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<BaseEventData> onSubmit
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate onMouseDown
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate onMouseDrag
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate onMouseEnter
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate onMouseExit
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate onMouseOver
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate onMouseUp
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate onEnable
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate onDisable
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate onDestroy
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate onTransformChildrenChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate onTransformParentChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<int> onAnimatorIK
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate onAnimatorMove
		{
			add
			{
			}
			remove
			{
			}
		}

		public event EventDelegate onBecameInvisible
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate onBecameVisible
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<ControllerColliderHit> onControllerColliderHit
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<GameObject> onParticleCollision
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<Collision> onCollisionEnter
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<Collision> onCollisionExit
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<Collision> onCollisionStay
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<Collision2D> onCollisionEnter2D
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<Collision2D> onCollisionExit2D
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<Collision2D> onCollisionStay2D
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<Collider> onTriggerEnter
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<Collider> onTriggerExit
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<Collider> onTriggerStay
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<Collider2D> onTriggerEnter2D
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<Collider2D> onTriggerExit2D
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate<Collider2D> onTriggerStay2D
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<RenderTexture, RenderTexture> onRenderImage
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EventDelegate onDrawGizmos
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event CustomEventDelegate onCustomEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
		}

		void IDropHandler.OnDrop(PointerEventData eventData)
		{
		}

		void IScrollHandler.OnScroll(PointerEventData eventData)
		{
		}

		void IUpdateSelectedHandler.OnUpdateSelected(BaseEventData eventData)
		{
		}

		void ISelectHandler.OnSelect(BaseEventData eventData)
		{
		}

		void IDeselectHandler.OnDeselect(BaseEventData eventData)
		{
		}

		void IMoveHandler.OnMove(AxisEventData eventData)
		{
		}

		void ISubmitHandler.OnSubmit(BaseEventData eventData)
		{
		}

		private void OnMouseDown()
		{
		}

		private void OnMouseDrag()
		{
		}

		private void OnMouseEnter()
		{
		}

		private void OnMouseExit()
		{
		}

		private void OnMouseOver()
		{
		}

		private void OnMouseUp()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnTransformChildrenChanged()
		{
		}

		private void OnTransformParentChanged()
		{
		}

		private void OnAnimatorIK(int layerIndex)
		{
		}

		private void OnBecameInvisible()
		{
		}

		private void OnBecameVisible()
		{
		}

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
		}

		private void OnParticleCollision(GameObject other)
		{
		}

		private void OnCollisionEnter(Collision collisionInfo)
		{
		}

		private void OnCollisionExit(Collision collisionInfo)
		{
		}

		private void OnCollisionStay(Collision collisionInfo)
		{
		}

		private void OnCollisionEnter2D(Collision2D collisionInfo)
		{
		}

		private void OnCollisionExit2D(Collision2D collisionInfo)
		{
		}

		private void OnCollisionStay2D(Collision2D collisionInfo)
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}

		private void OnTriggerStay(Collider other)
		{
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
		}

		private void OnTriggerExit2D(Collider2D other)
		{
		}

		private void OnTriggerStay2D(Collider2D other)
		{
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
		}

		private void OnDrawGizmos()
		{
		}

		public void InvokeCustomEvent(string name, object value, object sender)
		{
		}

		public void InvokeCustomEvent<T>(string name, T value, object sender)
		{
		}
	}
}
