using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Bindings;

public class TestNativeSet : MonoBehaviour
{
	protected int numObjects;

	protected Transform[] objects;

	protected int mode;

	private void Start()
	{
		//IL_0030: Expected O, but got I4
		//IL_008b: Expected I, but got O
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_018f->IL010d: Incompatible stack heights: 1 vs 0
		//IL_00ae->IL00ae: Incompatible stack heights: 2 vs 1
		//IL_0108->IL0194: Incompatible stack heights: 2 vs 0
		//IL_010d->IL0132: Incompatible stack heights: 2 vs 0
		Transform[] array = new Transform[numObjects];
		objects = array;
		if (numObjects <= 0)
		{
			return;
		}
		object obj = 0;
		object obj2 = default(object);
		while (true)
		{
			Transform[] array2 = objects;
			GameObject gameObject = new GameObject();
			GameObject.Internal_CreateGameObject(gameObject, (string)null);
			if ((object)gameObject == null)
			{
				break;
			}
			bool flag = ((UnityEngine.Object)gameObject).m_CachedPtr == (IntPtr)0;
			IntPtr gcHandlePtr = GameObject.get_transform_Injected(((UnityEngine.Object)gameObject).m_CachedPtr);
			Transform transform = UnityEngine.Bindings.Unmarshal.UnmarshalUnityObject<Transform>(gcHandlePtr);
			if (objects == null)
			{
				break;
			}
			if ((object)transform != null)
			{
				nint num = (nint)array2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				bool flag2 = obj2 == null;
			}
			bool flag3 = (nint)obj >= array2.Length;
			array2[obj] = transform;
			obj++;
			if ((nint)obj >= numObjects)
			{
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void Update()
	{
		//IL_0260: Expected O, but got I4
		//IL_028b: Expected O, but got I4
		//IL_02b6: Expected O, but got I4
		//IL_0045: Expected O, but got I4
		//IL_00b1: Expected O, but got I4
		//IL_0493: Expected O, but got I
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Expected O, but got Unknown
		//IL_006e->IL02d3: Incompatible stack heights: 0 vs 1
		//IL_009a->IL02d3: Incompatible stack heights: 0 vs 1
		//IL_044b->IL0498: Incompatible stack heights: 2 vs 1
		//IL_0349->IL0479: Incompatible stack heights: 2 vs 0
		//IL_024b->IL024b: Incompatible stack heights: 2 vs 1
		//IL_01a4->IL03b7: Incompatible stack heights: 6 vs 1
		//IL_034e->IL02d3: Incompatible stack heights: 2 vs 1
		object obj = Input.GetKeyUpInt(KeyCode.Alpha1);
		if (obj != null)
		{
			mode = 0;
		}
		object obj2 = Input.GetKeyUpInt(KeyCode.Alpha2);
		if (obj2 != null)
		{
			mode = 1;
		}
		object obj3 = Input.GetKeyUpInt(KeyCode.Alpha3);
		if (obj3 != null)
		{
			mode = 2;
		}
		bool flag = mode == 0;
		Vector3 value = default(Vector3);
		bool num2;
		if (!flag)
		{
			object obj4 = mode - 1;
			if (!flag)
			{
				if ((nint)obj4 != 1)
				{
					return;
				}
				Transform[] array = objects;
				if (array.Length > 0)
				{
					int num = 0;
					object obj5 = 32;
					Transform[] array3;
					do
					{
						Transform[] array2 = objects;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ r14_v14+v836 @ rax_v69 (UnityEngine.Transform[])]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v628 @ r14_v14+v836 @ rax_v69 (UnityEngine.Transform[])]");
						bool flag2 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rsi_v23 (System.Object)+10]");
						bool flag3 = (nint)0 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rsi_v23 (System.Object)+10]");
						Transform.set_localPosition_Injected((IntPtr)0, ref value);
						array3 = objects;
						num++;
						obj5 += 8;
					}
					while (num < array3.Length);
				}
			}
			else
			{
				Transform[] array4 = objects;
				bool flag4 = objects == null;
				num2 = flag4;
				int num3 = 0;
				for (int num4 = 0; num4 < array4.Length; num4 = num3)
				{
					Transform[] array5 = objects;
					bool flag5 = objects == null;
					bool flag6 = num3 >= array5.Length;
					object obj7 = array5[num3];
					bool flag7 = (object)array5[num3] == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ rsi_v21 (System.Object)+10]");
					bool flag8 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ rsi_v21 (System.Object)+10]");
					Transform.set_position_Injected((IntPtr)0, ref value);
					array4 = objects;
					num3++;
					bool flag9 = objects == null;
				}
			}
			return;
		}
		Transform[] array6 = objects;
		bool flag10 = objects == null;
		num2 = flag10;
		int num5 = 0;
		int num6 = 0;
		while (num6 < array6.Length)
		{
			Transform[] array7 = objects;
			if (objects != null)
			{
				object obj8 = array7[num5];
				if ((object)array7[num5] != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rsi_v19 (System.Object)+10]");
					bool flag11 = (nint)0 == 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v391 @ rsi_v19 (System.Object)+10]");
					Transform.set_localPosition_Injected((IntPtr)0, ref value);
					array6 = objects;
					num5++;
					bool flag12 = objects != null;
					num6 = num5;
					if (flag12)
					{
						continue;
					}
				}
			}
			throw new NullReferenceException();
		}
	}

	private void UpdatePositionsLocalIl2Cpp()
	{
		//IL_003a: Expected O, but got I4
		//IL_0043: Expected O, but got I4
		//IL_0122: Expected O, but got I
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_00fa: Expected O, but got I
		//IL_0103->IL0108: Incompatible stack heights: 1 vs 0
		//IL_0108->IL0079: Incompatible stack heights: 1 vs 0
		Transform[] array = objects;
		if (array.Length <= 0)
		{
			return;
		}
		TestNativeSet testNativeSet = this;
		object obj = 32;
		object obj2 = 0;
		Vector3 value = default(Vector3);
		bool flag2;
		do
		{
			Transform[] array2 = objects;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rsi_v3+v131 @ rax_v4 (UnityEngine.Transform[])]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rsi_v3+v131 @ rax_v4 (UnityEngine.Transform[])]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbx_v3 (System.Object)+10]");
				bool flag = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbx_v3 (System.Object)+10]");
				Transform.set_localPosition_Injected((IntPtr)0, ref value);
				Transform[] array3 = objects;
				obj2++;
				obj += 8;
				flag2 = (nint)obj2 < array3.Length;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbx_v3 (System.Object)+10]");
				testNativeSet = (TestNativeSet)0;
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7550");
			break;
		}
		while (flag2);
	}

	private void UpdatePositionsGlobal()
	{
		//IL_0029: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0127: Expected O, but got I
		//IL_0090: Expected O, but got I
		//IL_0138->IL00ad: Incompatible stack heights: 1 vs 0
		//IL_00ac->IL013d: Incompatible stack heights: 1 vs 0
		//IL_009a->IL00b8: Incompatible stack heights: 1 vs 0
		Transform[] array = objects;
		bool flag = objects == null;
		TestNativeSet testNativeSet = this;
		object obj = 0;
		if (flag)
		{
			goto IL_00ad;
		}
		object obj2 = 0;
		object obj3 = 0;
		goto IL_013d;
		IL_00b8:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdi_v8 (System.Object)+10]");
		bool flag2 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdi_v8 (System.Object)+10]");
		Vector3 value = default(Vector3);
		Transform.set_position_Injected((IntPtr)0, ref value);
		array = objects;
		obj3++;
		bool flag3 = objects == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdi_v8 (System.Object)+10]");
		testNativeSet = (TestNativeSet)0;
		obj = obj3;
		if (flag3)
		{
			goto IL_00ad;
		}
		obj2 = obj3;
		goto IL_013d;
		IL_013d:
		if ((nint)obj2 < array.Length)
		{
			object obj4 = objects;
			object obj5 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v10 (System.Object)+18]");
			bool flag4 = (nint)obj5 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rcx_v10 (System.Object)+20+v115 @ rbx_v7*8]");
			object obj6 = 0;
			goto IL_00b8;
		}
		return;
		IL_00ad:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7550");
		goto IL_00b8;
	}

	private void UpdatePositionsLocal()
	{
		//IL_0029: Expected O, but got I4
		//IL_0040: Expected O, but got I4
		//IL_0049: Expected O, but got I4
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_0105: Expected O, but got I
		//IL_0116->IL008b: Incompatible stack heights: 1 vs 0
		//IL_008a->IL011b: Incompatible stack heights: 1 vs 0
		Transform[] array = objects;
		bool flag = objects == null;
		TestNativeSet testNativeSet = this;
		object obj = 0;
		if (flag)
		{
			goto IL_008b;
		}
		object obj2 = 0;
		object obj3 = 0;
		goto IL_011b;
		IL_0096:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdi_v8 (System.Object)+10]");
		bool flag2 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdi_v8 (System.Object)+10]");
		Vector3 value = default(Vector3);
		Transform.set_localPosition_Injected((IntPtr)0, ref value);
		array = objects;
		obj3++;
		bool flag3 = objects == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdi_v8 (System.Object)+10]");
		testNativeSet = (TestNativeSet)0;
		obj = obj3;
		if (flag3)
		{
			goto IL_008b;
		}
		obj2 = obj3;
		goto IL_011b;
		IL_011b:
		if ((nint)obj2 < array.Length)
		{
			Transform[] array2 = objects;
			object obj4 = array2[obj3];
			goto IL_0096;
		}
		return;
		IL_008b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB7550");
		goto IL_0096;
	}

	public TestNativeSet()
	{
		//IL_0020: Expected I, but got O
		numObjects = 2000;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
