using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerTowController : MonoBehaviour
{
	public float walkSpeed = 5f;

	public float towSpeed = 1.8f;

	public float acceleration = 12f;

	public float gravity = 9.81f;

	public KeyCode interactKey = KeyCode.E;

	public float detectRadius = 3.5f;

	public LayerMask aircraftLayer;

	private CharacterController _cc;

	private Camera _cam;

	private Vector3 _moveVel;

	private float _yVel;

	private bool _isTowing;

	private AircraftTow _aircraft;

	private AircraftTow _nearby;

	private void Awake()
	{
		_cc = GetComponent<CharacterController>();
		_cam = Camera.main;
	}

	private void Update()
	{
		if (Input.GetKeyDown(interactKey))
		{
			Collider[] array = Physics.OverlapSphere(base.transform.position, detectRadius, aircraftLayer);
			_nearby = null;
			Collider[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i].attachedRigidbody.gameObject.TryGetComponent<AircraftTow>(out var component))
				{
					_nearby = component;
					break;
				}
			}
			if (_nearby == null && _isTowing)
			{
				StopTow();
			}
			if (_isTowing)
			{
				StopTow();
			}
			else if (_nearby != null)
			{
				StartTow(_nearby);
			}
		}
		float num = (_isTowing ? towSpeed : walkSpeed);
		Vector3 forward = _cam.transform.forward;
		forward.y = 0f;
		forward.Normalize();
		Vector3 right = _cam.transform.right;
		right.y = 0f;
		right.Normalize();
		Vector3 normalized = (forward * Input.GetAxisRaw("Vertical") + right * Input.GetAxisRaw("Horizontal")).normalized;
		_moveVel = Vector3.MoveTowards(_moveVel, normalized * num, acceleration * Time.deltaTime);
		_yVel = (_cc.isGrounded ? (-2f) : (_yVel - gravity * Time.deltaTime));
	}

	private void StartTow(AircraftTow a)
	{
		_aircraft = a;
		_isTowing = true;
		a.OnTowStart(this);
	}

	private void StopTow()
	{
		_aircraft?.OnTowStop();
		_aircraft = null;
		_isTowing = false;
	}
}
