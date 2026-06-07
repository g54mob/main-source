using Assets.Scripts.Design.Tools;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Design.UI.Input
{
	public class DesignerScreenInputScript : ScreenInputScript, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		private const float ResourceCleanupInterval = 15f;

		[SerializeField]
		private DesignerUIScript _designerUI;

		private bool _isPressingButtonOrTouching;

		private bool _onDesignerToolChanging;

		private bool _pointerHovering;

		private bool _pointerHoveringLastFrame;

		private float _timeOfLastResourceCleanup;

		public FingerTool FingerTool => _designerUI.FingerTool;

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
			_designerUI.DesignerScript.AddPart(part, pointerPosition);
			OnPointerDown(eventData);
		}

		public void Initialize(DesignerUIScript designerUI)
		{
			_designerUI = designerUI;
			base.Camera = _designerUI.DesignerScript.Designer.CameraController.Camera;
			_designerUI.DesignerScript.Designer.Tools.SelectedToolChanged += OnSelectedDesignerToolChanged;
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			eventData.useDragThreshold = _designerUI.DesignerScript.Designer.Tools.SelectedTool?.UseDragThreshold ?? true;
			_isPressingButtonOrTouching = true;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!_designerUI.FingerTool.Enabled)
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
					_designerUI.DesignerScript.Designer.MouseHover(new Vector2(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y));
				}
			}
			if (!_pointerHovering && _pointerHoveringLastFrame)
			{
				_designerUI.DesignerScript.Designer.MouseHover(null);
			}
			_pointerHoveringLastFrame = _pointerHovering;
		}

		private void OnSelectedDesignerToolChanged(object sender, ToolChangedEventArgs e)
		{
			if (_onDesignerToolChanging)
			{
				Debug.LogError("Prevented a stack overflow exception due to a designer tool change triggering another designer tool change.");
				return;
			}
			_onDesignerToolChanging = true;
			try
			{
				for (int num = base.TrackedInputs.Count - 1; num >= 0; num--)
				{
					TrackedInput trackedInput = base.TrackedInputs[num];
					PointerEventData eventData = new PointerEventData(EventSystem.current)
					{
						pointerId = trackedInput.Id,
						position = trackedInput.Position,
						delta = Vector2.zero
					};
					OnPointerUp(eventData);
				}
			}
			finally
			{
				_onDesignerToolChanging = false;
			}
		}

		private void PerformResourceCleanupIfNecessary()
		{
			if (Time.time - _timeOfLastResourceCleanup >= 15f)
			{
				_timeOfLastResourceCleanup = Time.time;
			}
		}
	}
}
