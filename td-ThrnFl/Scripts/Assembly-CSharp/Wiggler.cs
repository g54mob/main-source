using UnityEngine;

public class Wiggler : MonoBehaviour
{
	public Transform parentOverride;

	[SerializeField]
	private float acceleration = 50f;

	[SerializeField]
	[Range(0f, 1f)]
	private float speedDamping = 0.5f;

	[SerializeField]
	private float positionDampingMultiplyer = 1f;

	private Vector3 parentOffset;

	public Vector3 velocity { get; set; }

	private void Start()
	{
		if (parentOverride == null)
		{
			parentOverride = base.transform.parent;
		}
		parentOffset = Quaternion.Inverse(parentOverride.rotation) * (base.transform.position - parentOverride.position);
		base.transform.SetParent(null);
	}

	private void Update()
	{
		if (!parentOverride)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Vector3 vector = parentOverride.position + parentOverride.rotation * parentOffset;
		base.transform.position = Vector3.Lerp(vector, base.transform.position, Mathf.Pow(speedDamping, Time.deltaTime * positionDampingMultiplyer));
		Vector3 vector2 = vector - base.transform.position;
		float num = Time.deltaTime * acceleration * vector2.magnitude;
		velocity += vector2.normalized * num;
		velocity *= Mathf.Pow(speedDamping, Time.deltaTime);
		base.transform.position += velocity * Time.deltaTime;
	}
}
