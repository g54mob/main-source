using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class TouchControlCustomiser : MonoBehaviour
{
	[Serializable]
	public class TouchControlPrefabDictionary : UnitySerializedDictionary<VisibleJoystickType, GameObject>
	{
		public TouchControlPrefabDictionary()
		{
			((UnitySerializedDictionary<System.Int32Enum, object>)(object)this)._002Ector();
		}
	}

	private TouchControlPrefabDictionary _joystickPrefabs;

	public void SetupJoystick(PlayerOptions playerOptions)
	{
		PlayerOptionsData config = playerOptions.Config;
		int num = ((Dictionary<System.Int32Enum, object>)(object)_joystickPrefabs).FindEntry((System.Int32Enum)config._003CSelectedJoystickType_003Ek__BackingField);
		System.Int32Enum key;
		if (num < 0)
		{
			key = (System.Int32Enum)1;
		}
		else
		{
			PlayerOptionsData config2 = playerOptions.Config;
			key = (System.Int32Enum)config2._003CSelectedJoystickType_003Ek__BackingField;
		}
		object original = ((Dictionary<System.Int32Enum, object>)(object)_joystickPrefabs).get_Item(key);
		Transform parent = base.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate((GameObject)original, parent);
	}

	public TouchControlCustomiser()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
