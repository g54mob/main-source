using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public TrollDialogManager trollDialogManager;

	public OverworldTrollManager overworldTrollManager;

	public Animator outlineAnimator;

	public Animator fillAnimator;

	public Rigidbody2D rb;

	public float moveSpeed;

	public bool doMouseMovement;

	public void Update()
	{
		if (!TrollDialogManager.isInDialog && !overworldTrollManager.introCutscene && !overworldTrollManager.inTitelCard)
		{
			MoveInput();
		}
	}

	public void MoveInput()
	{
		float axisRaw = Input.GetAxisRaw("Horizontal");
		float axisRaw2 = Input.GetAxisRaw("Vertical");
		Vector2 vector = new Vector2(axisRaw, axisRaw2);
		if (Input.GetMouseButton(1) && doMouseMovement)
		{
			vector = ((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)base.transform.position).normalized;
		}
		rb.velocity = vector * moveSpeed;
		UpdateAnimation();
	}

	public void StopMovement()
	{
		rb.velocity = Vector2.zero;
		UpdateAnimation();
	}

	public void UpdateAnimation()
	{
		outlineAnimator.SetFloat("X", rb.velocity.x);
		outlineAnimator.SetFloat("Y", rb.velocity.y);
		outlineAnimator.SetFloat("Speed", rb.velocity.sqrMagnitude);
	}
}
