using UnityEngine;

public class BuildingBox : MonoBehaviour
{
	public enum State
	{
		Idle = 0,
		NeedsMoving = 1,
		MarkedForMoving = 2
	}

	public State state;

	public Vector2 target;

	[Space]
	[SerializeField]
	private Building parentBuildingScript;

	[Space]
	[SerializeField]
	private House parentHouseScript;

	private SpriteRenderer sr;

	private void Start()
	{
		sr = GetComponentInChildren<SpriteRenderer>();
	}

	public void NeedsMovingTo(Vector3 displacement)
	{
		state = State.NeedsMoving;
		target = base.transform.position + displacement;
	}

	public void PickUpBox()
	{
		sr.enabled = false;
		GameManager.ins.boxesToMove.Remove(this);
	}

	public void PutDownBox()
	{
		state = State.Idle;
		sr.enabled = true;
		base.transform.position = target;
		if ((bool)parentBuildingScript)
		{
			parentBuildingScript.CheckIfAllBoxesHaveBeenMoved();
		}
		if ((bool)parentHouseScript)
		{
			parentHouseScript.CheckIfAllBoxesHaveBeenMoved();
		}
	}
}
