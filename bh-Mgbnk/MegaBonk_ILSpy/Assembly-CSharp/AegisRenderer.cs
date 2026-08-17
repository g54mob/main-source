using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

public class AegisRenderer : MonoBehaviour
{
	public GameObject prefab;

	private List<GameObject> prefabs;

	public float forwardOffset;

	private bool inited;

	private int maxAmount;

	private void TryInit()
	{
		if (!inited)
		{
			inited = true;
			prefabs.Add(prefab);
		}
	}

	public unsafe void SetAmount(int amount)
	{
		//IL_0125: Invalid comparison between F4 and I4
		//IL_0176: Expected O, but got Ref
		//IL_0290: Expected O, but got Ref
		//IL_0290: Expected O, but got Ref
		//IL_0192: Expected O, but got Ref
		//IL_01c5: Expected O, but got Ref
		//IL_01db: Expected O, but got Ref
		//IL_0209: Expected O, but got I4
		//IL_0212: Expected O, but got I4
		int num = maxAmount;
		if (amount < maxAmount)
		{
			num = amount;
		}
		if (!inited)
		{
			inited = true;
			prefabs.Add(prefab);
		}
		HideAll();
		bool flag = num <= 0;
		int num2 = 0;
		if (flag)
		{
			return;
		}
		do
		{
			List<GameObject> list = prefabs;
			if (num2 >= list._size)
			{
				Transform parent = base.transform;
				GameObject item = UnityEngine.Object.Instantiate(prefab, parent);
				list.Add(item);
			}
			GameObject gameObject = prefabs.get_Item(num2);
			gameObject.SetActive(value: true);
			num2++;
		}
		while (num2 < num);
		int num3 = 0;
		object obj = default(object);
		float num4 = default(float);
		Vector3 forwardVector = default(Vector3);
		float num5 = default(float);
		object obj2 = default(object);
		bool flag2;
		do
		{
			if (forwardOffset > 0f)
			{
			}
			GameObject gameObject2 = prefabs.get_Item(num3);
			Transform transform = gameObject2.transform;
			Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&obj));
			Vector3 vector = (Quaternion)(&num4) * (Vector3)(&forwardVector);
			transform.localPosition = (Vector3)(&num5);
			GameObject gameObject3 = prefabs.get_Item(num3);
			Transform transform2 = gameObject3.transform;
			Quaternion quaternion2 = Quaternion.Internal_FromEulerRad((Vector3)(&obj2));
			transform2.localRotation = (Quaternion)(&num4);
			num3++;
			flag2 = num3 < num;
			forwardVector = Vector3.forwardVector;
			obj2 = 0;
			obj = 0;
		}
		while (flag2);
	}

	private unsafe void HideAll()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		GameObject gameObject = default(GameObject);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)gameObject == null)
				{
					break;
				}
				gameObject.SetActive(value: false);
				continue;
			}
			((List<GameObject>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	public AegisRenderer()
	{
		List<GameObject> list = new List<GameObject>();
		prefabs = list;
		maxAmount = 30;
		base._002Ector();
	}
}
