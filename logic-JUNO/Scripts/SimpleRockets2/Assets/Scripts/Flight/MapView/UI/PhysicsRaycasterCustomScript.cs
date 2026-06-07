using Assets.Scripts.Flight.UI;
using ModApi;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.MapView.UI
{
	[RequireComponent(typeof(Canvas))]
	[RequireComponent(typeof(GraphicRaycaster))]
	public class PhysicsRaycasterCustomScript : MonoBehaviour
	{
		[SerializeField]
		private Camera _camera;

		private ClickableGameObjectScript _currentHovered;

		private bool _dragging;

		private InputResponder _inputResponder = new InputResponder("PhysicsRaycasterCustomScript");

		private ClickableGameObjectScript _selectedObject;

		public InputResponder InputResponder => _inputResponder;

		public bool OnBeginDrag(PointerEventData eventData)
		{
			if (GetHit(eventData.position, out var _) && _selectedObject != null)
			{
				_dragging = true;
				eventData.selectedObject = _selectedObject.gameObject;
				ExecuteEvents.Execute(_selectedObject.gameObject, null, delegate(IBeginDragHandler x, BaseEventData y)
				{
					x.OnBeginDrag(eventData);
				});
			}
			return false;
		}

		public bool OnDeselect(BaseEventData eventData)
		{
			if (_selectedObject != null)
			{
				eventData.selectedObject = _selectedObject.gameObject;
				ExecuteEvents.Execute(_selectedObject.gameObject, null, delegate(IDeselectHandler x, BaseEventData y)
				{
					x.OnDeselect(eventData);
				});
			}
			return false;
		}

		public bool OnDrag(PointerEventData eventData)
		{
			_dragging = true;
			if (_selectedObject != null)
			{
				eventData.selectedObject = _selectedObject.gameObject;
				ExecuteEvents.Execute(_selectedObject.gameObject, null, delegate(IDragHandler x, BaseEventData y)
				{
					x.OnDrag(eventData);
				});
			}
			return false;
		}

		public bool OnDrop(PointerEventData eventData)
		{
			if (_selectedObject != null && GetHit(eventData.position, out var _))
			{
				eventData.selectedObject = _selectedObject.gameObject;
				ExecuteEvents.Execute(_selectedObject.gameObject, null, delegate(IDropHandler x, BaseEventData y)
				{
					x.OnDrop(eventData);
				});
			}
			return false;
		}

		public bool OnEndDrag(PointerEventData eventData)
		{
			if (_selectedObject != null)
			{
				eventData.selectedObject = _selectedObject.gameObject;
				ExecuteEvents.Execute(_selectedObject.gameObject, null, delegate(IEndDragHandler x, BaseEventData y)
				{
					x.OnEndDrag(eventData);
				});
			}
			return false;
		}

		public bool OnPointerClick(PointerEventData eventData)
		{
			if (_dragging)
			{
				_dragging = false;
				return false;
			}
			if (GetHit(eventData.position, out var clickableGameObjectScript))
			{
				if (clickableGameObjectScript.Selectable)
				{
					if (_selectedObject != null)
					{
						OnDeselect(eventData);
					}
					_selectedObject = clickableGameObjectScript;
					eventData.selectedObject = _selectedObject.gameObject;
					OnSelect(eventData);
				}
				ExecuteEvents.Execute(clickableGameObjectScript.gameObject, null, delegate(IPointerClickHandler x, BaseEventData y)
				{
					x.OnPointerClick(eventData);
				});
			}
			else if (_selectedObject != null)
			{
				OnDeselect(eventData);
				_selectedObject = null;
			}
			return false;
		}

		public bool OnPointerDown(PointerEventData eventData)
		{
			if (_selectedObject != null)
			{
				eventData.selectedObject = _selectedObject.gameObject;
				ExecuteEvents.Execute(_selectedObject.gameObject, null, delegate(IPointerDownHandler x, BaseEventData y)
				{
					x.OnPointerDown(eventData);
				});
			}
			return false;
		}

		public bool OnPointerUp(PointerEventData eventData)
		{
			if (_selectedObject != null)
			{
				eventData.selectedObject = _selectedObject.gameObject;
				ExecuteEvents.Execute(_selectedObject.gameObject, null, delegate(IPointerUpHandler x, BaseEventData y)
				{
					x.OnPointerUp(eventData);
				});
			}
			return false;
		}

		public bool OnSelect(BaseEventData eventData)
		{
			if (_selectedObject != null)
			{
				eventData.selectedObject = _selectedObject.gameObject;
				ExecuteEvents.Execute(_selectedObject.gameObject, null, delegate(ISelectHandler x, BaseEventData y)
				{
					x.OnSelect(eventData);
				});
			}
			return false;
		}

		public void Update()
		{
			DetectPointerEnterExit();
		}

		protected virtual void Awake()
		{
			_inputResponder.OnDeselect = OnDeselect;
			_inputResponder.OnDrag = OnDrag;
			_inputResponder.OnDrop = OnDrop;
			_inputResponder.OnEndDrag = OnEndDrag;
			_inputResponder.OnPointerClick = OnPointerClick;
			_inputResponder.OnPointerDown = OnPointerDown;
			_inputResponder.OnPointerUp = OnPointerUp;
			_inputResponder.OnSelect = OnSelect;
		}

		private void DetectPointerEnterExit()
		{
			if (GetHit(UnityEngine.Input.mousePosition, out var clickableGameObjectScript))
			{
				if (_currentHovered == null)
				{
					ExecuteEvents.Execute(clickableGameObjectScript.gameObject, null, delegate(IPointerEnterHandler x, BaseEventData y)
					{
						x.OnPointerEnter(new PointerEventData(EventSystem.current));
					});
				}
				else if (_currentHovered != clickableGameObjectScript)
				{
					ExecuteEvents.Execute(_currentHovered.gameObject, null, delegate(IPointerExitHandler x, BaseEventData y)
					{
						x.OnPointerExit(new PointerEventData(EventSystem.current));
					});
					ExecuteEvents.Execute(clickableGameObjectScript.gameObject, null, delegate(IPointerEnterHandler x, BaseEventData y)
					{
						x.OnPointerEnter(new PointerEventData(EventSystem.current));
					});
				}
				_currentHovered = clickableGameObjectScript;
			}
			else if (_currentHovered != null)
			{
				ExecuteEvents.Execute(_currentHovered.gameObject, null, delegate(IPointerExitHandler x, BaseEventData y)
				{
					x.OnPointerExit(new PointerEventData(EventSystem.current));
				});
				_currentHovered = null;
			}
		}

		private bool GetHit(Vector2 screenPos, out ClickableGameObjectScript clickableGameObjectScript)
		{
			clickableGameObjectScript = null;
			Ray ray = Utilities.ScreenPointToRay(_camera, screenPos);
			float num = float.MaxValue;
			RaycastHit[] array = Physics.RaycastAll(ray);
			for (int i = 0; i < array.Length; i++)
			{
				RaycastHit raycastHit = array[i];
				if (raycastHit.distance < num)
				{
					ClickableGameObjectScript componentInParent = raycastHit.collider.gameObject.GetComponentInParent<ClickableGameObjectScript>();
					if (componentInParent != null)
					{
						clickableGameObjectScript = componentInParent;
						num = raycastHit.distance;
					}
				}
			}
			return clickableGameObjectScript != null;
		}
	}
}
