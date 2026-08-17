using System;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Storage;

[Serializable]
public class SaveSlotMetadata(int slot, string platformSavedOn)
{
	public int slot = slot;

	public string platformSavedOn = platformSavedOn;

	public static string ToJSON(SaveSlotMetadata instance)
	{
		return JsonUtility.ToJson(instance);
	}

	public static SaveSlotMetadata FromJSON(string json)
	{
		return JsonUtility.FromJson<SaveSlotMetadata>(json);
	}

	public unsafe override string ToString()
	{
		//IL_0064: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2F71]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg, platformSavedOn);
		object obj = default(object);
		return string.FormatHelper((IFormatProvider)null, "slot={0}, platformSavedOn={1}", (System.ParamsArray)(&obj));
	}
}
