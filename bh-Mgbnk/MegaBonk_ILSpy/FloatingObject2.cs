using System;
using Cpp2ILInjected;
using UnityEngine;

public class FloatingObject2 : MonoBehaviour
{
	private Vector3 defaultPosition;

	public float heightOffset = 0.2f;

	public float rotationSpeed = 10f;

	public int moveSpeed = 1;

	private void Start()
	{
		//IL_002b: Expected O, but got F4
		Transform transform = base.transform;
		Vector3 position = transform.position;
		defaultPosition = (Vector3)position.x;
		_ = position.z;
	}

	private unsafe void Update()
	{
		//IL_0044: Expected O, but got Ref
		//IL_00a7: Expected I, but got O
		//IL_0098: Expected O, but got Ref
		float deltaTime = Time.deltaTime;
		Transform transform = base.transform;
		float angle = deltaTime * rotationSpeed;
		float num = default(float);
		transform.Rotate((Vector3)(&num), angle, Space.World);
		Transform transform2 = base.transform;
		float num2 = transform2.eulerAngles.y * ((float)Math.PI / 180f);
		float num3 = (float)moveSpeed * num2;
		nint num4 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
		Transform transform3 = base.transform;
		transform3.position = (Vector3)(&num);
	}
}
