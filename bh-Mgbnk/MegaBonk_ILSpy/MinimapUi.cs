using System;
using Assets.Scripts.Camera;
using Assets.Scripts.Game.MapGeneration.MapEvents;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

public class MinimapUi : MonoBehaviour
{
	public Transform border;

	public Transform[] directionLetters;

	public RawImage jammer;

	private Color jammerColor;

	private Color jammerColorClear;

	private void Awake()
	{
		//IL_0156: Expected O, but got F4
		//IL_01f2: Expected O, but got I4
		//IL_0200: Expected I, but got O
		//IL_0219: Expected O, but got I4
		//IL_025a: Expected O, but got I4
		//IL_0268: Expected I, but got O
		//IL_0281: Expected O, but got I4
		//IL_02ec: Expected O, but got I4
		//IL_02fa: Expected I, but got O
		//IL_0313: Expected O, but got I4
		//IL_0354: Expected O, but got I4
		//IL_0362: Expected I, but got O
		//IL_037b: Expected O, but got I4
		//IL_0107: Expected O, but got I4
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField == null || saveManager.config == null)
		{
			goto IL_010c;
		}
		SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
		float minimap_size;
		object obj;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ConfigSaveFile config = saveManager2.config;
			if (saveManager2.config != null)
			{
				CFGameSettings cfGameSettings = config.cfGameSettings;
				if (config.cfGameSettings != null)
				{
					minimap_size = cfGameSettings.minimap_size;
					UpdateScale(cfGameSettings.minimap_size);
					obj = 0;
					goto IL_010c;
				}
			}
		}
		goto IL_038a;
		IL_03b0:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_03a5;
		IL_010c:
		if ((object)jammer == null)
		{
			goto IL_038a;
		}
		Color color = jammer.color;
		minimap_size = color.r;
		jammerColor = (Color)color.r;
		jammerColorClear = jammerColor;
		_ = 0;
		Action<float> b = OnRotationUpdated;
		Delegate obj2 = Delegate.Combine(MinimapCamera.A_RotationUpdated, b);
		object obj6 = default(object);
		Delegate obj3;
		object obj4;
		object obj5;
		object obj7;
		nint num;
		if ((object)obj2 == null)
		{
			MinimapCamera.A_RotationUpdated = (Action<float>)obj2;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action = default(Action<float>);
			bool flag = action == null;
			obj3 = obj2;
			obj4 = 0;
			num = (nint)typeof(Action<float>);
			obj5 = obj6;
			obj7 = obj6;
			obj = 0;
			if (flag)
			{
				goto IL_03a5;
			}
			MinimapCamera.A_RotationUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj8 = default(object);
			bool flag2 = obj8 == null;
			obj3 = obj2;
			obj4 = 0;
			num = (nint)typeof(Action<float>);
			obj5 = obj6;
			obj7 = obj6;
			obj = 0;
			if (flag2)
			{
				goto IL_03b0;
			}
		}
		Action<string, object, object> b2 = OnSettingUpdated;
		Delegate obj9 = Delegate.Combine(CurrentSettings.A_SettingUpdated, b2);
		if ((object)obj9 == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj9;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action2 = default(Action<string, object, object>);
		bool flag3 = action2 == null;
		obj3 = obj9;
		obj4 = 0;
		nint num2 = (nint)typeof(Action<string, object, object>);
		obj5 = obj6;
		obj7 = obj6;
		obj = 0;
		if (!flag3)
		{
			CurrentSettings.A_SettingUpdated = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj10 = default(object);
			bool flag4 = obj10 == null;
			obj3 = obj9;
			obj4 = 0;
			num2 = (nint)typeof(Action<string, object, object>);
			obj5 = obj6;
			obj7 = obj6;
			obj = 0;
			if (!flag4)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num = num2;
		goto IL_03b0;
		IL_038a:
		throw new NullReferenceException();
		IL_03a5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_01a6: Expected I, but got O
		//IL_01b7: Expected O, but got I4
		//IL_01c0: Expected O, but got I4
		//IL_008a: Expected I, but got O
		//IL_009b: Expected O, but got I4
		//IL_00a4: Expected O, but got I4
		//IL_010c: Expected I, but got O
		//IL_011d: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_0164: Expected I, but got O
		//IL_0175: Expected O, but got I4
		//IL_017e: Expected O, but got I4
		Action<float> value = OnRotationUpdated;
		Delegate obj = Delegate.Remove(MinimapCamera.A_RotationUpdated, value);
		nint num;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num2;
		if ((object)obj == null)
		{
			MinimapCamera.A_RotationUpdated = (Action<float>)obj;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<float> action = default(Action<float>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<float>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_0230;
			}
			MinimapCamera.A_RotationUpdated = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<float>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				goto IL_01ed;
			}
		}
		Action<string, object, object> value2 = OnSettingUpdated;
		Delegate obj6 = Delegate.Remove(CurrentSettings.A_SettingUpdated, value2);
		if ((object)obj6 == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action2 = default(Action<string, object, object>);
		bool flag2 = action2 == null;
		num2 = (nint)typeof(Action<string, object, object>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_0220;
		}
		CurrentSettings.A_SettingUpdated = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag3 = obj7 == null;
		num = (nint)typeof(Action<string, object, object>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag3)
		{
			return;
		}
		goto IL_0230;
		IL_01ed:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0230:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0220;
		IL_0220:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01ed;
	}

	private unsafe void Update()
	{
		//IL_0057: Expected I, but got O
		//IL_01df: Invalid comparison between I4 and F4
		//IL_019a: Invalid comparison between I4 and F4
		//IL_0202: Expected O, but got Ref
		//IL_00af: Expected F4, but got I4
		//IL_00b8: Expected F4, but got I4
		//IL_01b6: Expected I, but got O
		if (!IsJammed() && !jammer.enabled)
		{
			return;
		}
		bool flag = IsJammed();
		Behaviour behaviour = jammer;
		if (!flag)
		{
			nint num = (nint)behaviour;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v353 @ rax_v20 (Il2CppClass<UnityEngine.Behaviour>)+298] (should have been resolved before IL gen)");
			float deltaTime = MyTime.deltaTime;
			if (!(0f > MyTime.deltaTime))
			{
				bool flag2 = !(deltaTime > 1f);
				float num2 = 1f;
				if (!flag2)
				{
					deltaTime = 1f;
					num2 = 1f;
				}
			}
			else
			{
				deltaTime = 0f;
				float num2 = 0f;
			}
			nint num3 = (nint)behaviour;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v445 @ rax_v25 (Il2CppClass<UnityEngine.Behaviour>)+2A8] (should have been resolved before IL gen)");
			if (!(0.02f < jammer.color.a))
			{
				jammer.enabled = false;
			}
		}
		else
		{
			if (!jammer.enabled)
			{
				jammer.enabled = true;
			}
			Color color = jammer.color;
			float num4 = MyTime.deltaTime * 0.3f;
			if (0f > num4 || num4 > 1f)
			{
			}
			object obj = default(object);
			jammer.color = (Color)(&obj);
		}
	}

	private bool IsJammed()
	{
		if (MapEventsDesert.isActiveStorm)
		{
			return true;
		}
		return ChallengesTracker.HasChallengeModifier("blind");
	}

	private unsafe void OnRotationUpdated(float y)
	{
		//IL_0021: Expected O, but got Ref
		//IL_0039: Expected O, but got I4
		//IL_0042: Expected O, but got I4
		//IL_006f: Expected O, but got Ref
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		Transform transform = border.transform;
		object obj = default(object);
		transform.eulerAngles = (Vector3)(&obj);
		Transform[] array = directionLetters;
		object obj2 = 0;
		object obj3 = 0;
		while ((nint)obj3 < array.Length)
		{
			Transform transform2 = array[obj2].transform;
			transform2.eulerAngles = (Vector3)(&obj);
			obj2++;
			obj3 = obj2;
		}
	}

	private unsafe void UpdateScale(float scale)
	{
		//IL_001c: Expected O, but got Ref
		Transform transform = base.transform;
		float num = default(float);
		transform.localScale = (Vector3)(&num);
	}

	private void OnSettingUpdated(string settingName, object oldValue, object newValue)
	{
		//IL_003b: Expected I, but got O
		//IL_004b: Expected O, but got I
		//IL_008e: Expected F4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172F62]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (settingName == "minimap_size")
		{
			nint num = (nint)newValue;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183185B58]");
			string text = (string)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ rcx_v5 (Il2CppClass<System.Object>)+40]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rdx_v4 (System.String)+40]");
			if (num2 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
				object obj = default(object);
				UpdateScale((float)obj);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			}
		}
	}
}
