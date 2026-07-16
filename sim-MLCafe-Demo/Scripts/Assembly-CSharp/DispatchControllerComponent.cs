using UnityEngine;

public class DispatchControllerComponent : MonoBehaviour
{
	[SerializeField]
	private GameStateManager.CharacterState dispatch = GameStateManager.CharacterState.BuildingMode;

	[SerializeField]
	private float movementSpeed = 5f;

	[SerializeField]
	private float rotationSpeed = 5f;

	private Vector3 movementDirection;

	private Vector3 finalDir;

	private Vector3 lastLookDirection;

	private void Update()
	{
		if (GameStateManager.ValidateCharacterState(dispatch))
		{
			Move();
			Turn();
		}
	}

	public void SetInputAxis(Vector3 inputDirection)
	{
		movementDirection = inputDirection;
		Vector3 vector = movementDirection;
		Debug.Log("INPUT: " + vector.ToString());
	}

	public void Move()
	{
		Vector3 vector = movementDirection.z * GlobalReferences.GetCameraController().pivot.forward;
		Vector3 vector2 = movementDirection.x * GlobalReferences.GetCameraController().pivot.right;
		finalDir = vector + vector2;
		base.transform.position += finalDir * movementSpeed * Time.deltaTime;
	}

	public void Turn()
	{
		if (finalDir != Vector3.zero)
		{
			lastLookDirection = base.transform.eulerAngles;
			float y = Mathf.LerpAngle(base.transform.eulerAngles.y, 57.29578f * Mathf.Atan2(finalDir.x, finalDir.z), rotationSpeed * Time.deltaTime);
			base.transform.eulerAngles = new Vector3(0f, y, 0f);
		}
		else
		{
			base.transform.eulerAngles = lastLookDirection;
		}
	}
}
