using UnityEngine;

public abstract class APlayerInteractableObjects : MonoBehaviour
{
	public void RegisterInteractableObject(int priority = 0)
	{
	}

	public void UnregisterInteractableObject()
	{
	}

	public virtual void OnPlayerControlEnterProc()
	{
	}

	public virtual void OnPlayerControlStayProc()
	{
	}

	public virtual void OnPlayerControlExitProc()
	{
	}

	public virtual void OnPlayerControlClickDownProc()
	{
	}

	public virtual void OnPlayerControlClickHoldProc()
	{
	}

	public virtual void OnPlayerControlClickUpProc()
	{
	}
}
