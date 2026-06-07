using UnityEngine;

public class TetrisClickHandler : MonoBehaviour, IInteractable
{
	[SerializeField]
	private Obj_TetrisBlock ref_Tetris;

	public Obj_TetrisBlock Ref_Tetris => null;

	public void SetReference(Obj_TetrisBlock tetris)
	{
	}

	public void OnRayEnter()
	{
	}

	public void OnRayExit()
	{
	}

	public void OnRayStay()
	{
	}

	public void OnRayClickDown()
	{
	}

	public void OnRayClickUp()
	{
	}
}
