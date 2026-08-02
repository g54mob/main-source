using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float playerSpeed = 5f;

	public float jumpHeight = 1.5f;

	private float gravityValue = -9.81f;

	private CharacterController controller;

	private Vector3 playerVelocity;

	private bool groundedPlayer;

	private void Awake()
	{
		controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		groundedPlayer = controller.isGrounded;
		if (groundedPlayer && playerVelocity.y < 0f)
		{
			playerVelocity.y = 0f;
		}
		float axis = Input.GetAxis("Horizontal");
		float axis2 = Input.GetAxis("Vertical");
		Vector3 vector = new Vector3(axis, 0f, axis2);
		vector = Vector3.ClampMagnitude(vector, 1f);
		if (vector != Vector3.zero)
		{
			base.transform.forward = vector;
		}
		if (Input.GetButtonDown("Jump") && groundedPlayer)
		{
			playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
		}
		playerVelocity.y += gravityValue * Time.deltaTime;
		Vector3 vector2 = vector * playerSpeed + playerVelocity.y * Vector3.up;
		controller.Move(vector2 * Time.deltaTime);
	}
}
