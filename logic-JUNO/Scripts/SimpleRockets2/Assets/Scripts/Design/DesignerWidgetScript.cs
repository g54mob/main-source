using Assets.Scripts.Ui;
using ModApi.Craft.Parts;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Design
{
	public class DesignerWidgetScript : ScreenInputScript, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		private const float ResourceCleanupInterval = 15f;

		[SerializeField]
		private DesignerScript _designer;

		private bool _isPressingButtonOrTouching;

		private bool _pointerHovering;

		private bool _pointerHoveringLastFrame;

		private float _timeOfLastResourceCleanup;

		public FingerTool FingerTool => _designer.DesignerUi.FingerTool as FingerTool;

		public void AddPartFinish(PointerEventData eventData)
		{
			if (FingerTool.Enabled)
			{
				FingerTool.OnAddPartFinish(eventData);
			}
			else
			{
				OnPointerUp(eventData);
			}
		}

		public void AddPartMove(PointerEventData eventData)
		{
			if (FingerTool.Enabled)
			{
				FingerTool.OnAddPartMove(eventData);
			}
			else
			{
				OnDrag(eventData);
			}
		}

		public void AddPartStart(DesignerPart part, PointerEventData eventData)
		{
			if (FingerTool.Enabled)
			{
				FingerTool.OnAddPartStart(part, eventData);
				return;
			}
			Vector2 pointerPosition = GetPointerPosition(eventData);
			_designer.AddPart(part, pointerPosition);
			OnPointerDown(eventData);
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			_isPressingButtonOrTouching = true;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!_designer.DesignerUi.FingerTool.Enabled)
			{
				_pointerHovering = true;
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_pointerHovering = false;
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			_isPressingButtonOrTouching = base.TrackedInputs.Count > 0;
		}

		protected virtual void LateUpdate()
		{
			if (!_isPressingButtonOrTouching)
			{
				PerformResourceCleanupIfNecessary();
				if (_pointerHovering)
				{
					_designer.HandleHover(new Vector2(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y));
				}
			}
			if (!_pointerHovering && _pointerHoveringLastFrame)
			{
				_designer.HandleHover(null);
			}
			_pointerHoveringLastFrame = _pointerHovering;
		}

		private void PerformResourceCleanupIfNecessary()
		{
			if (Time.time - _timeOfLastResourceCleanup >= 15f)
			{
				Resources.UnloadUnusedAssets();
				_timeOfLastResourceCleanup = Time.time;
			}
		}
	}
}
