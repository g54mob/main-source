using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private Transform cam;

	[SerializeField]
	private Rigidbody rb;

	[SerializeField]
	private AudioSource source;

	[SerializeField]
	private float camOffset;

	[SerializeField]
	private bool footstep = true;

	private bool lockCam;

	private bool lockMovement;

	[SerializeField]
	private float mouseSpeed;

	private float mouseX;

	private float mouseY;

	[SerializeField]
	private float walkSpeed;

	private float currentWalkSpeed;

	private bool sprint;

	private Vector3 walkAxis;

	private int lastFootstep;

	private float footstepCount;

	public bool LockCam
	{
		set
		{
			lockCam = value;
			if (lockCam)
			{
				Sprint = false;
			}
		}
	}

	public bool LockMovement
	{
		set
		{
			lockMovement = value;
			if (lockMovement)
			{
				rb.velocity = Vector3.zero;
				Sprint = false;
			}
		}
	}

	private bool Sprint
	{
		set
		{
			sprint = value;
			if (sprint)
			{
				currentWalkSpeed = walkSpeed * 1.5f;
			}
			else
			{
				currentWalkSpeed = walkSpeed;
			}
		}
	}

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		currentWalkSpeed = walkSpeed;
		mouseSpeed = PlayerPrefs.GetFloat("mouse", 5f);
	}

	private void Update()
	{
		if (!(Time.timeScale > 0f))
		{
			return;
		}
		footstepCount += Time.deltaTime;
		if (!lockCam)
		{
			GetCameraAxis();
			Look();
		}
		if (!lockMovement)
		{
			GetMovementAxis();
			if (footstep)
			{
				FootstepSound();
			}
		}
	}

	private void FixedUpdate()
	{
		if (Time.timeScale > 0f && !lockMovement)
		{
			Move();
		}
	}

	private void FootstepSound()
	{
		if (rb.velocity.magnitude > 1f && footstepCount >= (sprint ? 0.35f : 0.5f))
		{
			footstepCount = 0f;
			int num;
			do
			{
				num = Random.Range(1, 6);
			}
			while (num == lastFootstep);
			lastFootstep = num;
			source.clip = Resources.Load<AudioClip>("Sounds/Footstep/Barefoot" + num);
			source.Play();
		}
	}

	public void UpdatePosAndAngle(Vector3 pos, Vector3 angle)
	{
		base.transform.position = pos;
		if (Mathf.Abs(angle.x) >= 85f)
		{
			mouseX = angle.x - 360f;
		}
		else
		{
			mouseX = angle.x;
		}
		mouseY = angle.y;
		cam.rotation = Quaternion.Euler(new Vector3(mouseX, mouseY));
	}

	private void GetCameraAxis()
	{
		mouseY += Input.GetAxis("Mouse X") * mouseSpeed;
		mouseX -= Input.GetAxis("Mouse Y") * mouseSpeed;
		mouseX = Mathf.Clamp(mouseX, -85f, 85f);
	}

	private void GetMovementAxis()
	{
		Vector3 forward = cam.transform.forward;
		forward.y = 0f;
		walkAxis = forward * Input.GetAxisRaw("Vertical") + cam.transform.right * Input.GetAxisRaw("Horizontal");
		walkAxis = walkAxis.normalized;
		walkAxis *= currentWalkSpeed;
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			Sprint = true;
		}
		else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			Sprint = false;
		}
	}

	private void Move()
	{
		rb.velocity = new Vector3(walkAxis.x * Time.deltaTime, rb.velocity.y, walkAxis.z * Time.deltaTime);
	}

	private void Look()
	{
		cam.rotation = Quaternion.Euler(new Vector3(mouseX, mouseY));
		base.transform.rotation = Quaternion.Euler(new Vector3(0f, mouseY));
		cam.position = base.transform.position + new Vector3(0f, camOffset);
	}

	public void SetSpeed(float speed, float sen)
	{
		walkSpeed = speed;
		currentWalkSpeed = walkSpeed;
		mouseSpeed = sen;
	}

	public void SetMouseSen(float sen)
	{
		mouseSpeed = sen;
	}
}
