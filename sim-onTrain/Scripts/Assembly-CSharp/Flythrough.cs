using UnityEngine;

public class Flythrough : MonoBehaviour
{
	private float lookSpeed = 1f;

	private float moveSpeed = 0.07f;

	public GameObject sun;

	public Camera mycamera;

	private Quaternion baseSunTransform;

	public float sunX;

	public float sunY;

	public float sunZ;

	public float defaultFov;

	public float baseSpeed = 0.07f;

	public float runSpeed = 0.3f;

	public float dashSpeed = 2f;

	private void Start()
	{
		mycamera.fieldOfView = defaultFov;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = false;
		baseSunTransform = sun.transform.rotation;
	}

	private void Update()
	{
		if (Input.GetKey("e"))
		{
			sun.transform.Rotate(0f, 0.1f, 0f, Space.World);
		}
		if (Input.GetKey("q"))
		{
			sun.transform.Rotate(0f, -0.1f, 0f, Space.World);
		}
		if (Input.GetKey("z"))
		{
			sun.transform.Rotate(-0.1f, 0f, 0f, Space.World);
		}
		if (Input.GetKey("x"))
		{
			sun.transform.Rotate(0.1f, 0f, 0f, Space.World);
		}
		if (Input.GetKeyDown("t"))
		{
			sun.transform.eulerAngles = new Vector3(sunX, sunY, sunZ);
		}
		if (Input.GetKey("v"))
		{
			mycamera.fieldOfView -= 0.3f;
		}
		if (Input.GetKey("b"))
		{
			mycamera.fieldOfView += 0.3f;
		}
		if (Input.GetKeyDown("n"))
		{
			mycamera.fieldOfView = defaultFov;
		}
		if (Input.GetKey(KeyCode.LeftShift))
		{
			moveSpeed = runSpeed;
		}
		else if (Input.GetKey(KeyCode.LeftAlt))
		{
			moveSpeed = dashSpeed;
		}
		else
		{
			moveSpeed = baseSpeed;
		}
		if (Input.GetAxis("Vertical") != 0f && Input.GetAxis("Horizontal") != 0f)
		{
			base.transform.position += base.transform.forward * moveSpeed / 1.5f * Input.GetAxis("Vertical");
			base.transform.position += base.transform.right * moveSpeed / 1.5f * Input.GetAxis("Horizontal");
		}
		else
		{
			base.transform.position += base.transform.forward * moveSpeed * Input.GetAxis("Vertical");
			base.transform.position += base.transform.right * moveSpeed * Input.GetAxis("Horizontal");
		}
		if (Input.GetKey("space"))
		{
			base.transform.position += base.transform.up * moveSpeed * 0.07f;
		}
		if (Input.GetKey(KeyCode.LeftControl))
		{
			base.transform.position += base.transform.up * moveSpeed * -0.06f;
		}
	}
}
