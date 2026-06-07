using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LORotator : MonoBehaviour
{
	[SerializeField]
	private Vector3 speed = Vector3.zero;

	[SerializeField]
	private bool isLocalSpace = true;

	private Space space;

	private Rigidbody rb;

	private void Awake()
	{
		space = (isLocalSpace ? Space.Self : Space.World);
		rb = GetComponent<Rigidbody>();
	}

	public void SetConfigurations(Vector3 speed, bool isLocalSpace)
	{
		this.speed = speed;
		this.isLocalSpace = isLocalSpace;
		space = (isLocalSpace ? Space.Self : Space.World);
	}

	private void FixedUpdate()
	{
		Quaternion quaternion = Quaternion.Euler(speed * Time.fixedDeltaTime);
		Quaternion rot = ((space == Space.Self) ? (rb.rotation * quaternion) : (quaternion * rb.rotation));
		rb.MoveRotation(rot);
	}
}
