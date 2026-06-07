using System.Collections;
using UnityEngine;

public class VideoAutomation : MonoBehaviour
{
	public float cursorMovementDistanceRoot;

	public float cursorMovementSpeed;

	public AnimationCurve cursorMovementCurve;

	public float cursorLateralMovement;

	public float beforeOperateDrawerDelay;

	public float drawerHandleRandomLateralDistance;

	public float drawerHandleInteractionSpeedMul;

	protected IEnumerator MoveCusrorTo(Vector2 worldPosition, bool lateralMovement = true, float movementSpeedMul = 1f)
	{
		return null;
	}

	protected IEnumerator MoveCursorRelative(Vector2 direction, bool lateralMovement = true, float movementSpeedMul = 1f)
	{
		return null;
	}

	public IEnumerator OpenDrawer(Drawer drawer)
	{
		return null;
	}

	public IEnumerator CloseDrawer(Drawer drawer)
	{
		return null;
	}

	public IEnumerator GetTool(DraggablePanel drawer)
	{
		return null;
	}

	public IEnumerator DropTool(DraggablePanel drawer)
	{
		return null;
	}

	public IEnumerator UnsolderModule(Module module)
	{
		return null;
	}

	public IEnumerator SolderModule(Motherboard motherboard, Vector2 position, int rotation)
	{
		return null;
	}

	public IEnumerator DestroyModule()
	{
		return null;
	}
}
