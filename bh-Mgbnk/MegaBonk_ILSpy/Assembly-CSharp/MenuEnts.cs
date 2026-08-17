using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

public class MenuEnts : MonoBehaviour
{
	private class EntData
	{
		public GameObject obj;

		public int dir;

		public float speed;
	}

	public GameObject entPrefab;

	public Transform leftPos;

	public Transform rightPos;

	private float baseSpeed = 1.4f;

	private List<EntData> ents;

	private unsafe void Start()
	{
		//IL_0045: Expected I4, but got I8
		//IL_004e: Expected O, but got I4
		//IL_007f: Invalid comparison between I4 and F4
		//IL_00cb: Expected O, but got Ref
		//IL_00cb: Expected O, but got Ref
		//IL_012d: Expected O, but got Ref
		//IL_0324: Expected O, but got Ref
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_02a3: Expected I4, but got I8
		List<EntData> list = new List<EntData>();
		ents = list;
		int num = UnityEngine.Random.Range(1, 7);
		if (num > 0)
		{
			int num2 = -1;
			object obj = 0;
			object obj2 = default(object);
			Quaternion identityQuaternion = default(Quaternion);
			float num4 = default(float);
			float num8 = default(float);
			bool flag2;
			object obj3 = default(object);
			do
			{
				float value = UnityEngine.Random.value;
				Vector3 position = leftPos.position;
				Vector3 position2 = rightPos.position;
				if (0f > value || value > 1f)
				{
				}
				GameObject gameObject = UnityEngine.Object.Instantiate(entPrefab, (Vector3)(&obj2), (Quaternion)(&identityQuaternion));
				float num3 = UnityEngine.Random.Range(0.85f, 1.5f);
				Transform transform = gameObject.transform;
				Transform transform2 = entPrefab.transform;
				Vector3 localScale = transform2.localScale;
				transform.localScale = (Vector3)(&num4);
				Transform transform3 = gameObject.transform;
				Vector3 position3 = transform3.position;
				float num5 = UnityEngine.Random.Range(0f, 50f);
				float num6 = (float)Vector3.forwardVector * num5;
				float num7 = num6 + position3.x;
				transform3.position = (Vector3)(&num8);
				Animator component = gameObject.GetComponent<Animator>();
				if (component != null)
				{
					float value2 = UnityEngine.Random.value;
					component.Play("Walking_Menu", 0, value2);
					float speed = UnityEngine.Random.Range(0.85f, 1.15f);
					component.speed = speed;
				}
				float value3 = UnityEngine.Random.value;
				bool flag = !(0.5f > value3);
				int dir = 1;
				if (!flag)
				{
					dir = num2;
				}
				Transform tr = gameObject.transform;
				FaceDirection(tr, dir);
				EntData entData = new EntData();
				entData._002Ector();
				entData.obj = gameObject;
				float speed2 = num3 * baseSpeed;
				entData.dir = dir;
				entData.speed = speed2;
				ents.Add(entData);
				obj++;
				flag2 = (nint)obj < num;
				num8 = num7;
				obj2 = obj3;
				identityQuaternion = Quaternion.identityQuaternion;
				num2 = -1;
			}
			while (flag2);
		}
		entPrefab.SetActive(value: false);
	}

	private unsafe void Update()
	{
		//IL_004a: Expected O, but got Ref
		//IL_008e: Expected O, but got I
		//IL_0318: Expected O, but got Ref
		//IL_0335: Expected O, but got I
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected O, but got Unknown
		//IL_00e7: Expected O, but got Ref
		//IL_01f8: Expected O, but got Ref
		//IL_0191: Expected O, but got I
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_0258: Expected O, but got Ref
		//IL_0169: Expected O, but got Ref
		//IL_02a2: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		object obj = default(object);
		float num = default(float);
		object obj4 = default(object);
		float num3 = default(float);
		object obj7 = default(object);
		object obj8 = default(object);
		float num5 = default(float);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = obj == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_-168+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_-168+10]");
						Transform transform = ((GameObject)0).transform;
						if ((object)transform != null)
						{
							Vector3 position = transform.position;
							float deltaTime = Time.deltaTime;
							transform.position = (Vector3)(&num);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_-168+18]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_-168+18]");
							object obj2 = num2 ^ 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_-168+18]");
							object obj3 = 0 & obj2;
							bool flag2 = (nint)obj3 < 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_-168+18]");
							bool flag3 = (nint)0 < (nint)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_-168+18]");
							if ((nint)0 > (nint)0)
							{
								Vector3 position2 = transform.position;
								bool flag4 = (object)rightPos == null;
								enumerator2 = (List<object>.Enumerator)(&obj4);
								if (flag4)
								{
									break;
								}
								Vector3 position3 = rightPos.position;
								if (position2.x > position3.x)
								{
									Vector3 position4 = leftPos.position;
									Vector3 position5 = transform.position;
									Vector3 position6 = transform.position;
									transform.position = (Vector3)(&num3);
									continue;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_-168+18]");
								nint num4 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_-168+18]");
								object obj5 = num4 ^ 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_-168+18]");
								object obj6 = 0 & obj5;
								flag2 = (nint)obj6 < 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ stack_-168+18]");
								flag3 = (nint)0 < (nint)0;
							}
							if (flag3 == flag2)
							{
								continue;
							}
							Vector3 position7 = transform.position;
							bool flag5 = (object)leftPos == null;
							enumerator2 = (List<object>.Enumerator)(&obj7);
							if (!flag5)
							{
								if (leftPos.position.x > position7.x)
								{
									bool flag6 = (object)rightPos == null;
									enumerator2 = (List<object>.Enumerator)(&obj8);
									if (flag6)
									{
										throw new NullReferenceException();
									}
									Vector3 position8 = rightPos.position;
									Vector3 position9 = transform.position;
									Vector3 position10 = transform.position;
									transform.position = (Vector3)(&num5);
								}
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<EntData>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	private unsafe void FaceDirection(Transform tr, int dir)
	{
		//IL_0041: Expected O, but got Ref
		//IL_0041: Expected O, but got Ref
		//IL_0033: Expected O, but got Ref
		Transform transform = entPrefab.transform;
		Vector3 forward = transform.forward;
		object obj = default(object);
		object obj2 = default(object);
		Quaternion quaternion = Quaternion.LookRotation((Vector3)(&obj), (Vector3)(&obj2));
		tr.rotation = (Quaternion)(&obj);
	}
}
