using UnityEngine;

public class InteractableHandle : Interactable
{
	public bool draggable;

	private float position;

	private DraggablePanel panel;

	private float interactionStartTime;

	private float interactionOffset;

	private Vector2 interactionMousePosition;

	private bool invalidateClick;

	private float _threshold;

	public float threshold
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	public override bool InteractionEnabled()
	{
		return false;
	}

	public override void OnInteractionDown()
	{
	}

	private bool CheckThreshold()
	{
		return false;
	}

	public override void OnInteractionUp()
	{
	}

	public override void Update()
	{
	}
}
