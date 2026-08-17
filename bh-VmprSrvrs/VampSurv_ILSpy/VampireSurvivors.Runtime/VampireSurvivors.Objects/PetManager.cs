using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects;

public class PetManager : GameMonoBehaviour
{
	private List<PetInstance> _pets;

	private VampireSurvivors.Objects.Characters.CharacterController _owner;

	public void Init(VampireSurvivors.Objects.Characters.CharacterController owner)
	{
		List<PetInstance> pets = new List<PetInstance>();
		_pets = pets;
		_owner = owner;
	}

	public PetInstance AddPet(Equipment baseEquipment, Equipment hiddenWeapon, SpriteRenderer petSprite, float petOffset)
	{
		//IL_0174: Expected I, but got O
		PetInstance petInstance = new PetInstance();
		petInstance._petOffset = 0.24f;
		nint num = (nint)typeof(Vector2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rax_v5 (Il2CppClass<UnityEngine.Vector2>)+B8]");
		nint num2 = 0;
		petInstance._currentDirection = Vector2.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector2>)+4]");
		_ = 0;
		float runSpeed = GameManager.PlayerPxSpeed / 1.1785715f;
		petInstance._runSpeed = runSpeed;
		petInstance._baseEquipment = baseEquipment;
		petInstance._hiddenWeapon = hiddenWeapon;
		petInstance._petSprite = petSprite;
		petInstance.Owner = _owner;
		float petOffset2 = default(float);
		petInstance._petOffset = petOffset2;
		List<object> pets = (List<object>)(object)_pets;
		if (_pets != null)
		{
			int version = pets._version + 1;
			pets._version = version;
			object[] items = pets._items;
			if (pets._items != null)
			{
				if (pets._size >= items.Length)
				{
					((List<object>)(object)_pets).AddWithResize((object)petInstance);
				}
				else
				{
					int size = pets._size + 1;
					pets._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				return petInstance;
			}
		}
		return (PetInstance)(object)new NullReferenceException();
	}

	public List<PetInstance> GetPets()
	{
		return _pets;
	}

	protected override void OnUpdate()
	{
		List<PetInstance>.Enumerator enumerator = default(List<PetInstance>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}

	public PetManager()
	{
		//IL_0020: Expected I, but got O
		base._onResumeSent = true;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
