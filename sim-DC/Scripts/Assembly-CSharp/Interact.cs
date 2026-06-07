using UnityEngine;

public class Interact : MonoBehaviour
{
	public bool hasSecondAction;

	public int SecondActionTextUID;

	public int uid;

	public float[] saveValue;

	public int[] saveIntArray;

	public int[] saveIntArray2;

	public float timeForAction;

	public bool isOnInteractEveryFrame;

	public bool isHoldToInteract;

	public bool isHoldToSecondAction;

	public int secondActionHoldTextUID;

	public int onHoverTextUID;

	public float holdDuration;

	public virtual void Awake()
	{
	}

	public virtual void InteractOnClick()
	{
	}

	public virtual bool IsAllowedToDoSecondAction()
	{
		return false;
	}

	public virtual void SecondActionOnClick()
	{
	}

	public virtual void InteractOnHover(RaycastHit hit)
	{
	}

	public virtual void OnHoverOver()
	{
	}

	public virtual void CloseInteractionMenu()
	{
	}

	public virtual void OnLoad(InteractObjectData data)
	{
	}
}
