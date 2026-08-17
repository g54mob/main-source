using UnityEngine;

public class RotateObjectRandomly : MonoBehaviour
{
	public float minSpeed;

	public float maxSpeed;

	private float speed;

	private Vector3 rotation;

	private unsafe void Start()
	{
		//IL_001c: Expected O, but got Ref
		//IL_0088: Expected O, but got F4
		Transform transform = base.transform;
		object obj = default(object);
		transform.rotation = (Quaternion)(&obj);
		float num = Random.Range(minSpeed, maxSpeed);
		speed = num;
		float num2 = Random.Range(-1f, 1f);
		float num3 = Random.Range(-1f, 1f);
		float num4 = Random.Range(-1f, 1f);
		rotation = (Vector3)num2;
	}

	public unsafe void FindNewRotation()
	{
		//IL_001c: Expected O, but got Ref
		//IL_0088: Expected O, but got F4
		Transform transform = base.transform;
		object obj = default(object);
		transform.rotation = (Quaternion)(&obj);
		float num = Random.Range(minSpeed, maxSpeed);
		speed = num;
		float num2 = Random.Range(-1f, 1f);
		float num3 = Random.Range(-1f, 1f);
		float num4 = Random.Range(-1f, 1f);
		rotation = (Vector3)num2;
	}

	private unsafe void Update()
	{
		//IL_0012: Expected O, but got Ref
		Transform transform = base.transform;
		float num = default(float);
		transform.Rotate((Vector3)(&num));
	}
}
