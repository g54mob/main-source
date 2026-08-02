using UnityEngine;

public class OutsourceInteractable : MonoBehaviour, IInteractable
{
	[SerializeField]
	private MonoBehaviour targetInteractable;

	private IInteractable Target => targetInteractable as IInteractable;

	public bool IsActive
	{
		get
		{
			if (Target == null)
			{
				return false;
			}
			return Target.IsActive;
		}
		set
		{
			if (Target != null)
			{
				Target.IsActive = value;
			}
		}
	}

	public Transform InteractionParent
	{
		get
		{
			if (Target == null)
			{
				return null;
			}
			return Target.InteractionParent;
		}
		set
		{
			if (Target != null)
			{
				Target.InteractionParent = value;
			}
		}
	}

	public float CustomInteractionDistance
	{
		get
		{
			if (Target == null)
			{
				return -1f;
			}
			return Target.CustomInteractionDistance;
		}
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (Target != null)
		{
			Target.Interact(player, hitPoint);
		}
	}

	public void StopInteract()
	{
		if (Target != null)
		{
			Target.StopInteract();
		}
	}
}
