using System;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class GoldCounter : MonoBehaviour
{
	public TextMeshProUGUI t_silver;

	private unsafe void Start()
	{
		//IL_024a: Expected I, but got O
		//IL_0257: Expected I, but got O
		//IL_0260: Expected O, but got I4
		//IL_020c: Expected I, but got O
		//IL_0219: Expected I, but got O
		//IL_0222: Expected O, but got I4
		//IL_00e1: Expected O, but got I4
		//IL_00f7: Expected I, but got O
		//IL_0107: Expected O, but got I
		//IL_029d: Expected I, but got O
		//IL_0151: Expected O, but got Ref
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField == null || saveManager.progression == null)
		{
			goto IL_015f;
		}
		Delegate obj = (Delegate)(object)t_silver;
		SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
		nint num;
		object obj2;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null && saveManager2.progression != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			object arg = default(object);
			string text = $"<sprite name=silver> {arg:N0}";
			bool flag = (object)t_silver == null;
			obj2 = 0;
			if (!flag)
			{
				num = (nint)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v409 @ r9_v1 (Il2CppClass<System.Delegate>)+560]");
				obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v409 @ r9_v1 (Il2CppClass<System.Delegate>)+558] (should have been resolved before IL gen)");
				if ((object)t_silver != null)
				{
					Transform transform = t_silver.transform;
					nint num2 = (nint)typeof(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rcx_v32 (Il2CppClass<UnityEngine.Vector3>)+B8]");
					nint num3 = 0;
					float num4 = (float)Vector3.oneVector * 1.6f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rdx_v17 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
					float num5 = 0f * 1.6f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ rdx_v17 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
					float num6 = 0f * 1.6f;
					bool flag2 = (object)transform == null;
					float num7 = 1.6f;
					obj = (Delegate)(object)transform;
					if (!flag2)
					{
						float num8 = default(float);
						transform.localScale = (Vector3)(&num8);
						num7 = 1.6f;
						goto IL_015f;
					}
				}
			}
		}
		goto IL_0283;
		IL_0283:
		throw new NullReferenceException();
		IL_015f:
		Action<int> b = Refresh;
		Delegate obj3 = Delegate.Combine(ProgressionSaveFile.A_SilverChanged, b);
		if ((object)obj3 == null)
		{
			ProgressionSaveFile.A_SilverChanged = (Action<int>)obj3;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action = default(Action<int>);
		nint num9;
		if (action != null)
		{
			ProgressionSaveFile.A_SilverChanged = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj4 = default(object);
			bool flag3 = obj4 == null;
			num9 = (nint)typeof(Action<int>);
			obj = obj3;
			num = unchecked((nint)null);
			obj2 = 0;
			if (flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			}
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num9 = (nint)typeof(Action<int>);
		obj = obj3;
		num = unchecked((nint)null);
		obj2 = 0;
		goto IL_0283;
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<int> value = Refresh;
		Delegate obj = Delegate.Remove(ProgressionSaveFile.A_SilverChanged, value);
		if ((object)obj == null)
		{
			ProgressionSaveFile.A_SilverChanged = (Action<int>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action = default(Action<int>);
		if (action != null)
		{
			ProgressionSaveFile.A_SilverChanged = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<int>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<int>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private unsafe void Refresh(int delta)
	{
		//IL_0060: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string text = $"<sprite name=silver> {arg:N0}";
		t_silver.text = text;
		Transform transform = t_silver.transform;
		float num = default(float);
		transform.localScale = (Vector3)(&num);
	}

	private unsafe void Update()
	{
		//IL_00bf: Invalid comparison between I4 and F4
		//IL_008a: Expected F4, but got I4
		//IL_009c: Expected O, but got Ref
		Transform transform = t_silver.transform;
		Transform transform2 = t_silver.transform;
		Vector3 localScale = transform2.localScale;
		float deltaTime = Time.deltaTime;
		float num = deltaTime * 8f;
		if (!(0f > num))
		{
			if (num > 1f)
			{
				num = 1f;
			}
		}
		else
		{
			num = 0f;
		}
		float num2 = default(float);
		transform.localScale = (Vector3)(&num2);
	}
}
