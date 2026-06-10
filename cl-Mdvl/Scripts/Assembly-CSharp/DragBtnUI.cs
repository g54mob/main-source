using UnityEngine;

public class DragBtnUI : MonoBehaviour
{
	[SerializeField]
	private Transform objectToDrag;

	private Vector3 dragStart = Vector3.zero;

	private Vector3 objectDragStartPosition = Vector3.zero;

	private bool mouseDownPrev;

	private bool mouseDown;

	private bool dragStarted;

	private readonly RaycastHit2D[] raycastHits = new RaycastHit2D[64];

	private void Update()
	{
		int num = Physics2D.RaycastNonAlloc(Input.mousePosition, Vector2.one, raycastHits, 0.01f);
		for (int i = 0; i < num; i++)
		{
			RaycastHit2D raycastHit2D = raycastHits[i];
			if ((bool)raycastHit2D && !raycastHit2D.collider.CompareTag("Ignore"))
			{
				mouseDown = Input.GetMouseButton(0);
			}
		}
		if (mouseDown != mouseDownPrev)
		{
			if (mouseDown)
			{
				OnDown();
			}
			mouseDownPrev = mouseDown;
		}
		else if (mouseDown)
		{
			OnDrag();
		}
	}

	private void OnDown()
	{
		dragStarted = true;
		dragStart = Input.mousePosition;
		objectDragStartPosition = objectToDrag.position;
	}

	private void OnDrag()
	{
		if (dragStarted)
		{
			Vector3 vector = Input.mousePosition - dragStart;
			objectToDrag.position = objectDragStartPosition + vector;
		}
	}
}
