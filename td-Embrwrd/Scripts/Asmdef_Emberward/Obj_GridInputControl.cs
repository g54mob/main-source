using UnityEngine;

public class Obj_GridInputControl : MonoBehaviour
{
	[SerializeField]
	private Transform node_Visual;

	[SerializeField]
	private SpriteRenderer spriteRenderer_Visual;

	[SerializeField]
	private float moveSpeedPerSecond;

	[SerializeField]
	private float tweenMoveDuration;

	private Vector3 virtualPosition;

	private bool isUsingJoystick;

	private Vector3Int lastGridPosition;

	private APlayerInteractableObjects currentInteractableObject;

	private bool isInitReady;

	private Vector3Int targetPosInt;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnShowCommonIngameUI()
	{
	}

	private void OnInteractableObjectChanged(IInteractable[] Objects)
	{
	}

	private void Update()
	{
	}

	private void UpdateVisual(Vector3Int currentPosition)
	{
	}

	private void Move(Vector3Int targetPosition)
	{
	}

	public bool IsVisualOn()
	{
		return false;
	}

	public bool IsCurrentPositionOnTower(ABaseTower tower)
	{
		return false;
	}

	private void MoveToNewGridProc(Vector3Int position)
	{
	}
}
