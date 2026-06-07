using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Remove Decoration")]
public class RemoveDecorationCursorProperties : CursorProperties
{
	[SerializeField]
	private LayerMask _layerMask;

	private Decoration _mouseOverDecoration;

	public override void Activate()
	{
		GameEventDispatcher.Dispatch(GameEventType.RemoveDecorationToolEnabled);
		GameManager.UIManager.ClosePanel(PanelID.DecorationCreation);
	}

	public override void DeactivateImmediately()
	{
		if (_mouseOverDecoration != null)
		{
			_mouseOverDecoration.OnRemoveCursorExit();
			_mouseOverDecoration = null;
		}
		GameEventDispatcher.Dispatch(GameEventType.RemoveDecorationToolDisabled);
	}

	public override void UpdateCursor(CursorManager cursor)
	{
		if (Physics.Raycast(CameraController.MainCamera.ScreenPointToRay(FlotsamInputManager.MousePosition), out var hitInfo, 1000f, _layerMask))
		{
			Decoration componentInParent = hitInfo.collider.GetComponentInParent<Decoration>();
			if (componentInParent != _mouseOverDecoration)
			{
				if (_mouseOverDecoration != null)
				{
					_mouseOverDecoration.OnRemoveCursorExit();
				}
				_mouseOverDecoration = componentInParent;
				if (_mouseOverDecoration != null)
				{
					_mouseOverDecoration.OnRemoveCursorEnter();
				}
			}
		}
		else if ((bool)_mouseOverDecoration)
		{
			_mouseOverDecoration.OnRemoveCursorExit();
			_mouseOverDecoration = null;
		}
		if ((bool)_mouseOverDecoration && _mouseOverDecoration.ConstructionHandler.BuildPhase == BuildPhase.Finished && GetInteract())
		{
			if (_mouseOverDecoration.Parent != null)
			{
				_mouseOverDecoration.Parent.RemoveDecoration(_mouseOverDecoration);
			}
			else
			{
				Debug.LogError($"Tryint to remove Decoration {_mouseOverDecoration.name} but it did not have a valid parent {typeof(DecorationSlots)} to remove it through! Removing deco on its own, but the town's beauty score will not be affected (among potential other things)!");
				_mouseOverDecoration.Remove();
			}
			GraphManager.RefreshNavigatorPaths();
		}
	}
}
