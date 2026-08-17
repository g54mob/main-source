using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Framework;

public class GameSessionData : IInitializable, IDisposable
{
	private VampireSurvivors.Objects.Characters.CharacterController _activeCharacter;

	public unsafe VampireSurvivors.Objects.Characters.CharacterController ActiveCharacter
	{
		get
		{
			return _activeCharacter;
		}
		set
		{
			//IL_01c2: Expected O, but got Ref
			//IL_00fb: Expected I4, but got F4
			//IL_024b: Expected O, but got Ref
			_activeCharacter = value;
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter = _activeCharacter;
			object arg;
			string format;
			if ((object)_activeCharacter != null && ((UnityEngine.Object)activeCharacter).m_CachedPtr != (IntPtr)0)
			{
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter2 = _activeCharacter;
				CharacterType characterType = default(CharacterType);
				arg = characterType;
				characterType = activeCharacter2._characterType;
				format = "<color=green>ACTIVE CHARACTER: {0}. ";
			}
			else
			{
				arg = "NONE";
				format = "<color=green>ACTIVE CHARACTER: {0}. ";
			}
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			System.ParamsArray paramsArray2 = default(System.ParamsArray);
			string text = string.FormatHelper((IFormatProvider)null, format, (System.ParamsArray)(&paramsArray2));
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter3 = _activeCharacter;
			object arg2;
			string format2;
			if ((object)_activeCharacter != null && ((UnityEngine.Object)activeCharacter3).m_CachedPtr != (IntPtr)0)
			{
				VampireSurvivors.Objects.Characters.CharacterController activeCharacter4 = _activeCharacter;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj = default(object);
				arg2 = obj;
				format2 = "XP: {0}. Level: {1}</color>";
				CharacterType characterType = (CharacterType)activeCharacter4._xp;
			}
			else
			{
				arg2 = "NONE";
				format2 = "XP: {0}. Level: {1}</color>";
			}
			VampireSurvivors.Objects.Characters.CharacterController activeCharacter5 = _activeCharacter;
			object arg3 = default(object);
			if ((object)_activeCharacter != null && ((UnityEngine.Object)activeCharacter5).m_CachedPtr != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			}
			else
			{
				arg3 = "NONE";
			}
			paramsArray2 = new System.ParamsArray(arg2, arg3);
			object obj2 = default(object);
			string text2 = string.FormatHelper((IFormatProvider)null, format2, (System.ParamsArray)(&obj2));
			string message = text + text2;
			Debug.Log(message);
		}
	}

	public void Initialize()
	{
	}

	public void Dispose()
	{
	}
}
