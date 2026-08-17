using System;
using System.Collections.Generic;
using System.Reflection;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.Touchy;

public class SimulatedTouch
{
	private bool _003CWasModified_003Ek__BackingField;

	private const BindingFlags FLAGS = (BindingFlags)36;

	private static readonly Dictionary<string, FieldInfo> Fields;

	private readonly object m_touch;

	public bool WasModified
	{
		get
		{
			return _003CWasModified_003Ek__BackingField;
		}
		set
		{
			_003CWasModified_003Ek__BackingField = value;
		}
	}

	public int FingerId
	{
		get
		{
			//IL_0061: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_0074: Expected I4, but got O
			object touch = m_touch;
			nint num = (nint)typeof(Touch);
			nint num2 = (nint)touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppClass<UnityEngine.Touch>)+40]");
			if (num3 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ r8_v1 (System.Object)+10]");
				return 0;
			}
			InvalidCastException ex = new InvalidCastException();
			return (int)ex;
		}
		set
		{
			FieldInfo fieldInfo = Fields.get_Item("m_FingerId");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			fieldInfo.SetValue(m_touch, value2);
		}
	}

	public Vector2 Position
	{
		get
		{
			//IL_0059: Expected I, but got O
			//IL_000d: Expected I, but got O
			object touch = m_touch;
			nint num = (nint)typeof(Touch);
			nint num2 = (nint)touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppClass<UnityEngine.Touch>)+40]");
			Vector2 result = default(Vector2);
			if (num3 == 0)
			{
				return result;
			}
			return (Vector2)new InvalidCastException();
		}
		set
		{
			FieldInfo fieldInfo = Fields.get_Item("m_Position");
			object obj = default(object);
			object value2 = (Vector2)obj;
			fieldInfo.SetValue(m_touch, value2);
		}
	}

	public Vector2 RawPosition
	{
		get
		{
			//IL_0059: Expected I, but got O
			//IL_000d: Expected I, but got O
			object touch = m_touch;
			nint num = (nint)typeof(Touch);
			nint num2 = (nint)touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppClass<UnityEngine.Touch>)+40]");
			Vector2 result = default(Vector2);
			if (num3 == 0)
			{
				return result;
			}
			return (Vector2)new InvalidCastException();
		}
		set
		{
			FieldInfo fieldInfo = Fields.get_Item("m_RawPosition");
			object obj = default(object);
			object value2 = (Vector2)obj;
			fieldInfo.SetValue(m_touch, value2);
		}
	}

	public Vector2 DeltaPosition
	{
		get
		{
			//IL_0059: Expected I, but got O
			//IL_000d: Expected I, but got O
			object touch = m_touch;
			nint num = (nint)typeof(Touch);
			nint num2 = (nint)touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppClass<UnityEngine.Touch>)+40]");
			Vector2 result = default(Vector2);
			if (num3 == 0)
			{
				return result;
			}
			return (Vector2)new InvalidCastException();
		}
		set
		{
			FieldInfo fieldInfo = Fields.get_Item("m_PositionDelta");
			object obj = default(object);
			object value2 = (Vector2)obj;
			fieldInfo.SetValue(m_touch, value2);
		}
	}

	public float DeltaTime
	{
		get
		{
			//IL_0061: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_0049: Expected F4, but got I
			object touch = m_touch;
			nint num = (nint)typeof(Touch);
			nint num2 = (nint)touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppClass<UnityEngine.Touch>)+40]");
			if (num3 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ r8_v1 (System.Object)+2C]");
				return 0f;
			}
			throw new InvalidCastException();
		}
		set
		{
			FieldInfo fieldInfo = Fields.get_Item("m_TimeDelta");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			fieldInfo.SetValue(m_touch, value2);
		}
	}

	public int TapCount
	{
		get
		{
			//IL_0061: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_0074: Expected I4, but got O
			object touch = m_touch;
			nint num = (nint)typeof(Touch);
			nint num2 = (nint)touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppClass<UnityEngine.Touch>)+40]");
			if (num3 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ r8_v1 (System.Object)+30]");
				return 0;
			}
			InvalidCastException ex = new InvalidCastException();
			return (int)ex;
		}
		set
		{
			FieldInfo fieldInfo = Fields.get_Item("m_TapCount");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			fieldInfo.SetValue(m_touch, value2);
		}
	}

	public TouchPhase Phase
	{
		get
		{
			//IL_006b: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_007e: Expected I4, but got O
			object touch = m_touch;
			nint num = (nint)typeof(Touch);
			nint num2 = (nint)touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppClass<UnityEngine.Touch>)+40]");
			if (num3 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,4\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ r8_v1 (System.Object)+30]");
				return TouchPhase.Began;
			}
			InvalidCastException ex = new InvalidCastException();
			return (TouchPhase)ex;
		}
		set
		{
			//IL_0021: Expected I4, but got O
			FieldInfo fieldInfo = Fields.get_Item("m_Phase");
			object obj = default(object);
			object value2 = (TouchPhase)obj;
			fieldInfo.SetValue(m_touch, value2);
		}
	}

	public float Pressure
	{
		get
		{
			//IL_0061: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_0049: Expected F4, but got I
			object touch = m_touch;
			nint num = (nint)typeof(Touch);
			nint num2 = (nint)touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppClass<UnityEngine.Touch>)+40]");
			if (num3 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ r8_v1 (System.Object)+3C]");
				return 0f;
			}
			throw new InvalidCastException();
		}
		set
		{
			FieldInfo fieldInfo = Fields.get_Item("m_Pressure");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			fieldInfo.SetValue(m_touch, value2);
		}
	}

	public float MaximumPossiblePressure
	{
		get
		{
			//IL_0061: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_0049: Expected F4, but got I
			object touch = m_touch;
			nint num = (nint)typeof(Touch);
			nint num2 = (nint)touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppClass<UnityEngine.Touch>)+40]");
			if (num3 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ r8_v1 (System.Object)+40]");
				return 0f;
			}
			throw new InvalidCastException();
		}
		set
		{
			FieldInfo fieldInfo = Fields.get_Item("m_maximumPossiblePressure");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			fieldInfo.SetValue(m_touch, value2);
		}
	}

	public TouchType Type
	{
		get
		{
			//IL_0061: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_0074: Expected I4, but got O
			object touch = m_touch;
			nint num = (nint)typeof(Touch);
			nint num2 = (nint)touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppClass<UnityEngine.Touch>)+40]");
			if (num3 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ r8_v1 (System.Object)+38]");
				return TouchType.Direct;
			}
			InvalidCastException ex = new InvalidCastException();
			return (TouchType)ex;
		}
		set
		{
			//IL_0021: Expected I4, but got O
			FieldInfo fieldInfo = Fields.get_Item("m_Type");
			object obj = default(object);
			object value2 = (TouchType)obj;
			fieldInfo.SetValue(m_touch, value2);
		}
	}

	public float AltitudeAngle
	{
		get
		{
			//IL_0061: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_0049: Expected F4, but got I
			object touch = m_touch;
			nint num = (nint)typeof(Touch);
			nint num2 = (nint)touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppClass<UnityEngine.Touch>)+40]");
			if (num3 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ r8_v1 (System.Object)+4C]");
				return 0f;
			}
			throw new InvalidCastException();
		}
		set
		{
			FieldInfo fieldInfo = Fields.get_Item("m_AltitudeAngle");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			fieldInfo.SetValue(m_touch, value2);
		}
	}

	public float AzimuthAngle
	{
		get
		{
			//IL_0061: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_0049: Expected F4, but got I
			object touch = m_touch;
			nint num = (nint)typeof(Touch);
			nint num2 = (nint)touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppClass<UnityEngine.Touch>)+40]");
			if (num3 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ r8_v1 (System.Object)+50]");
				return 0f;
			}
			throw new InvalidCastException();
		}
		set
		{
			FieldInfo fieldInfo = Fields.get_Item("m_AzimuthAngle");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			fieldInfo.SetValue(m_touch, value2);
		}
	}

	public float Radius
	{
		get
		{
			//IL_0061: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_0049: Expected F4, but got I
			object touch = m_touch;
			nint num = (nint)typeof(Touch);
			nint num2 = (nint)touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppClass<UnityEngine.Touch>)+40]");
			if (num3 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ r8_v1 (System.Object)+44]");
				return 0f;
			}
			throw new InvalidCastException();
		}
		set
		{
			FieldInfo fieldInfo = Fields.get_Item("m_Radius");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			fieldInfo.SetValue(m_touch, value2);
		}
	}

	public float RadiusVariance
	{
		get
		{
			//IL_0061: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_0049: Expected F4, but got I
			object touch = m_touch;
			nint num = (nint)typeof(Touch);
			nint num2 = (nint)touch;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v31 @ rdx_v1 (Il2CppClass<UnityEngine.Touch>)+40]");
			if (num3 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ r8_v1 (System.Object)+48]");
				return 0f;
			}
			throw new InvalidCastException();
		}
		set
		{
			FieldInfo fieldInfo = Fields.get_Item("m_RadiusVariance");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object value2 = default(object);
			fieldInfo.SetValue(m_touch, value2);
		}
	}

	public SimulatedTouch()
	{
		object obj = default(object);
		object touch = (Touch)obj;
		m_touch = touch;
		_003CWasModified_003Ek__BackingField = false;
	}

	static SimulatedTouch()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_003e: Expected I4, but got O
		//IL_004e: Expected O, but got I
		//IL_0061: Expected O, but got I4
		//IL_006a: Expected O, but got I4
		//IL_007f: Expected O, but got I
		//IL_008c: Expected I, but got O
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		Dictionary<string, FieldInfo> fields = new Dictionary<string, FieldInfo>();
		Fields = fields;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = default(object);
		System.Collections.Generic.InsertionBehavior insertionBehavior = (System.Collections.Generic.InsertionBehavior)(int)obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ r9_v3 (System.Collections.Generic.InsertionBehavior)+6E0]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v174 @ r9_v3 (System.Collections.Generic.InsertionBehavior)+6D8] (should have been resolved before IL gen)");
		object obj5 = 0;
		object obj6 = 0;
		object key = default(object);
		while (true)
		{
			object obj7 = obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rax_v11+18]");
			if ((nint)obj7 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ rax_v11+20+v171 @ rdi_v3*8]");
				object obj8 = 0;
				nint num = (nint)obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v322 @ rdx_v8 (Il2CppClass<System.Object>)+1B8] (should have been resolved before IL gen)");
				bool flag = ((Dictionary<object, object>)(object)Fields).TryInsert(key, obj8, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
				obj5++;
				insertionBehavior = System.Collections.Generic.InsertionBehavior.ThrowOnExisting;
				obj4 = obj8;
				obj6 = obj5;
				continue;
			}
			break;
		}
	}

	public unsafe Touch Get()
	{
		//IL_00ba: Expected I, but got O
		//IL_000d: Expected I, but got O
		//IL_004c: Expected native int or pointer, but got O
		//IL_006e: Expected native int or pointer, but got O
		//IL_0088: Expected F4, but got I
		//IL_0083: Expected native int or pointer, but got O
		//IL_009d: Expected F4, but got I
		//IL_0098: Expected native int or pointer, but got O
		object touch = m_touch;
		nint num = (nint)typeof(Touch);
		nint num2 = (nint)touch;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ rcx_v4 (Il2CppClass<System.Object>)+40]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdx_v1 (Il2CppClass<UnityEngine.Touch>)+40]");
		if (num3 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Object)+10]");
			Touch touch2 = default(Touch);
			((Touch*)(nint)touch2)->m_FingerId = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Object)+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Object)+30]");
			((Touch*)(nint)touch2)->m_TapCount = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Object)+40]");
			((Touch*)(nint)touch2)->m_maximumPossiblePressure = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Object)+50]");
			((Touch*)(nint)touch2)->m_AzimuthAngle = 0f;
			return touch2;
		}
		return (Touch)new InvalidCastException();
	}
}
