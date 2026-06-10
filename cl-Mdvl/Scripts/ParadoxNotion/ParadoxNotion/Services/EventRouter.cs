using System;
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

		public event EventDelegate<PointerEventData> onPointerEnter;

		public event EventDelegate<PointerEventData> onPointerExit;

		public event EventDelegate<PointerEventData> onPointerDown;

		public event EventDelegate<PointerEventData> onPointerUp;

		public event EventDelegate<PointerEventData> onPointerClick;

		public event EventDelegate<PointerEventData> onDrag;

		public event EventDelegate<PointerEventData> onDrop;

		public event EventDelegate<PointerEventData> onScroll;

		public event EventDelegate<BaseEventData> onUpdateSelected;

		public event EventDelegate<BaseEventData> onSelect;

		public event EventDelegate<BaseEventData> onDeselect;

		public event EventDelegate<AxisEventData> onMove;

		public event EventDelegate<BaseEventData> onSubmit;

		public event EventDelegate onMouseDown;

		public event EventDelegate onMouseDrag;

		public event EventDelegate onMouseEnter;

		public event EventDelegate onMouseExit;

		public event EventDelegate onMouseOver;

		public event EventDelegate onMouseUp;

		public event EventDelegate onEnable;

		public event EventDelegate onDisable;

		public event EventDelegate onDestroy;

		public event EventDelegate onTransformChildrenChanged;

		public event EventDelegate onTransformParentChanged;

		public event EventDelegate<int> onAnimatorIK;

		public event EventDelegate onAnimatorMove
		{
			add
			{
				if (_routerAnimatorMove == null)
				{
					_routerAnimatorMove = base.gameObject.GetAddComponent<EventRouterAnimatorMove>();
				}
				_routerAnimatorMove.onAnimatorMove += value;
			}
			remove
			{
				if (_routerAnimatorMove != null)
				{
					_routerAnimatorMove.onAnimatorMove -= value;
				}
			}
		}

		public event EventDelegate onBecameInvisible;

		public event EventDelegate onBecameVisible;

		public event EventDelegate<ControllerColliderHit> onControllerColliderHit;

		public event EventDelegate<GameObject> onParticleCollision;

		public event EventDelegate<Collision> onCollisionEnter;

		public event EventDelegate<Collision> onCollisionExit;

		public event EventDelegate<Collision> onCollisionStay;

		public event EventDelegate<Collision2D> onCollisionEnter2D;

		public event EventDelegate<Collision2D> onCollisionExit2D;

		public event EventDelegate<Collision2D> onCollisionStay2D;

		public event EventDelegate<Collider> onTriggerEnter;

		public event EventDelegate<Collider> onTriggerExit;

		public event EventDelegate<Collider> onTriggerStay;

		public event EventDelegate<Collider2D> onTriggerEnter2D;

		public event EventDelegate<Collider2D> onTriggerExit2D;

		public event EventDelegate<Collider2D> onTriggerStay2D;

		public event Action<RenderTexture, RenderTexture> onRenderImage;

		public event EventDelegate onDrawGizmos;

		public event CustomEventDelegate onCustomEvent;

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			if (this.onPointerEnter != null)
			{
				this.onPointerEnter(new EventData<PointerEventData>(eventData, base.gameObject, this));
			}
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			if (this.onPointerExit != null)
			{
				this.onPointerExit(new EventData<PointerEventData>(eventData, base.gameObject, this));
			}
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			if (this.onPointerDown != null)
			{
				this.onPointerDown(new EventData<PointerEventData>(eventData, base.gameObject, this));
			}
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
			if (this.onPointerUp != null)
			{
				this.onPointerUp(new EventData<PointerEventData>(eventData, base.gameObject, this));
			}
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
			if (this.onPointerClick != null)
			{
				this.onPointerClick(new EventData<PointerEventData>(eventData, base.gameObject, this));
			}
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
			if (this.onDrag != null)
			{
				this.onDrag(new EventData<PointerEventData>(eventData, base.gameObject, this));
			}
		}

		void IDropHandler.OnDrop(PointerEventData eventData)
		{
			if (this.onDrop != null)
			{
				this.onDrop(new EventData<PointerEventData>(eventData, base.gameObject, this));
			}
		}

		void IScrollHandler.OnScroll(PointerEventData eventData)
		{
			if (this.onScroll != null)
			{
				this.onScroll(new EventData<PointerEventData>(eventData, base.gameObject, this));
			}
		}

		void IUpdateSelectedHandler.OnUpdateSelected(BaseEventData eventData)
		{
			if (this.onUpdateSelected != null)
			{
				this.onUpdateSelected(new EventData<BaseEventData>(eventData, base.gameObject, this));
			}
		}

		void ISelectHandler.OnSelect(BaseEventData eventData)
		{
			if (this.onSelect != null)
			{
				this.onSelect(new EventData<BaseEventData>(eventData, base.gameObject, this));
			}
		}

		void IDeselectHandler.OnDeselect(BaseEventData eventData)
		{
			if (this.onDeselect != null)
			{
				this.onDeselect(new EventData<BaseEventData>(eventData, base.gameObject, this));
			}
		}

		void IMoveHandler.OnMove(AxisEventData eventData)
		{
			if (this.onMove != null)
			{
				this.onMove(new EventData<AxisEventData>(eventData, base.gameObject, this));
			}
		}

		void ISubmitHandler.OnSubmit(BaseEventData eventData)
		{
			if (this.onSubmit != null)
			{
				this.onSubmit(new EventData<BaseEventData>(eventData, base.gameObject, this));
			}
		}

		private void OnMouseDown()
		{
			if (this.onMouseDown != null)
			{
				this.onMouseDown(new EventData(base.gameObject, this));
			}
		}

		private void OnMouseDrag()
		{
			if (this.onMouseDrag != null)
			{
				this.onMouseDrag(new EventData(base.gameObject, this));
			}
		}

		private void OnMouseEnter()
		{
			if (this.onMouseEnter != null)
			{
				this.onMouseEnter(new EventData(base.gameObject, this));
			}
		}

		private void OnMouseExit()
		{
			if (this.onMouseExit != null)
			{
				this.onMouseExit(new EventData(base.gameObject, this));
			}
		}

		private void OnMouseOver()
		{
			if (this.onMouseOver != null)
			{
				this.onMouseOver(new EventData(base.gameObject, this));
			}
		}

		private void OnMouseUp()
		{
			if (this.onMouseUp != null)
			{
				this.onMouseUp(new EventData(base.gameObject, this));
			}
		}

		private void OnEnable()
		{
			if (this.onEnable != null)
			{
				this.onEnable(new EventData(base.gameObject, this));
			}
		}

		private void OnDisable()
		{
			if (this.onDisable != null)
			{
				this.onDisable(new EventData(base.gameObject, this));
			}
		}

		private void OnDestroy()
		{
			if (this.onDestroy != null)
			{
				this.onDestroy(new EventData(base.gameObject, this));
			}
		}

		private void OnTransformChildrenChanged()
		{
			if (this.onTransformChildrenChanged != null)
			{
				this.onTransformChildrenChanged(new EventData(base.gameObject, this));
			}
		}

		private void OnTransformParentChanged()
		{
			if (this.onTransformParentChanged != null)
			{
				this.onTransformParentChanged(new EventData(base.gameObject, this));
			}
		}

		private void OnAnimatorIK(int layerIndex)
		{
			if (this.onAnimatorIK != null)
			{
				this.onAnimatorIK(new EventData<int>(layerIndex, base.gameObject, this));
			}
		}

		private void OnBecameInvisible()
		{
			if (this.onBecameInvisible != null)
			{
				this.onBecameInvisible(new EventData(base.gameObject, this));
			}
		}

		private void OnBecameVisible()
		{
			if (this.onBecameVisible != null)
			{
				this.onBecameVisible(new EventData(base.gameObject, this));
			}
		}

		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			if (this.onControllerColliderHit != null)
			{
				this.onControllerColliderHit(new EventData<ControllerColliderHit>(hit, base.gameObject, this));
			}
		}

		private void OnParticleCollision(GameObject other)
		{
			if (this.onParticleCollision != null)
			{
				this.onParticleCollision(new EventData<GameObject>(other, base.gameObject, this));
			}
		}

		private void OnCollisionEnter(Collision collisionInfo)
		{
			if (this.onCollisionEnter != null)
			{
				this.onCollisionEnter(new EventData<Collision>(collisionInfo, base.gameObject, this));
			}
		}

		private void OnCollisionExit(Collision collisionInfo)
		{
			if (this.onCollisionExit != null)
			{
				this.onCollisionExit(new EventData<Collision>(collisionInfo, base.gameObject, this));
			}
		}

		private void OnCollisionStay(Collision collisionInfo)
		{
			if (this.onCollisionStay != null)
			{
				this.onCollisionStay(new EventData<Collision>(collisionInfo, base.gameObject, this));
			}
		}

		private void OnCollisionEnter2D(Collision2D collisionInfo)
		{
			if (this.onCollisionEnter2D != null)
			{
				this.onCollisionEnter2D(new EventData<Collision2D>(collisionInfo, base.gameObject, this));
			}
		}

		private void OnCollisionExit2D(Collision2D collisionInfo)
		{
			if (this.onCollisionExit2D != null)
			{
				this.onCollisionExit2D(new EventData<Collision2D>(collisionInfo, base.gameObject, this));
			}
		}

		private void OnCollisionStay2D(Collision2D collisionInfo)
		{
			if (this.onCollisionStay2D != null)
			{
				this.onCollisionStay2D(new EventData<Collision2D>(collisionInfo, base.gameObject, this));
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (this.onTriggerEnter != null)
			{
				this.onTriggerEnter(new EventData<Collider>(other, base.gameObject, this));
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (this.onTriggerExit != null)
			{
				this.onTriggerExit(new EventData<Collider>(other, base.gameObject, this));
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (this.onTriggerStay != null)
			{
				this.onTriggerStay(new EventData<Collider>(other, base.gameObject, this));
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (this.onTriggerEnter2D != null)
			{
				this.onTriggerEnter2D(new EventData<Collider2D>(other, base.gameObject, this));
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (this.onTriggerExit2D != null)
			{
				this.onTriggerExit2D(new EventData<Collider2D>(other, base.gameObject, this));
			}
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			if (this.onTriggerStay2D != null)
			{
				this.onTriggerStay2D(new EventData<Collider2D>(other, base.gameObject, this));
			}
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (this.onRenderImage != null)
			{
				this.onRenderImage(source, destination);
			}
		}

		private void OnDrawGizmos()
		{
			if (this.onDrawGizmos != null)
			{
				this.onDrawGizmos(new EventData(base.gameObject, this));
			}
		}

		public void InvokeCustomEvent(string name, object value, object sender)
		{
			if (this.onCustomEvent != null)
			{
				this.onCustomEvent(name, new EventData(value, base.gameObject, sender));
			}
		}

		public void InvokeCustomEvent<T>(string name, T value, object sender)
		{
			if (this.onCustomEvent != null)
			{
				this.onCustomEvent(name, new EventData<T>(value, base.gameObject, sender));
			}
		}
	}
}
