using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
	private Vector3 defaultPosition;

	public bool useMeTime = true;

	public float heightOffset = 0.2f;

	public float floatSpeed = 1f;

	public float rotationSpeed = 10f;

	private void Awake()
	{
		//IL_002b: Expected O, but got F4
		Transform transform = base.transform;
		Vector3 position = transform.position;
		defaultPosition = (Vector3)position.x;
		_ = position.z;
	}

	private unsafe void Update()
	{
		//IL_004b: Expected O, but got Ref
		//IL_0080: Expected I, but got O
		//IL_005d: Expected O, but got Ref
		float num;
		if (!useMeTime)
		{
			float deltaTime = Time.deltaTime;
			num = deltaTime;
		}
		else
		{
			num = MyTime.deltaTime;
		}
		Transform transform = base.transform;
		float angle = num * rotationSpeed;
		float num2 = default(float);
		transform.Rotate((Vector3)(&num2), angle);
		nint num3 = (nint)typeof(Vector3);
		float num4 = num * floatSpeed;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
		Transform transform2 = base.transform;
		transform2.position = (Vector3)(&num2);
	}
}
