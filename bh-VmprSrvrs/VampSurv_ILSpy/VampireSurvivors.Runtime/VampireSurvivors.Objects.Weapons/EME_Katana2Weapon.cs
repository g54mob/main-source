using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class EME_Katana2Weapon : EME_Katana1Weapon
{
	protected override int GlimmerTier => 2;

	protected override int ComboIndexFinal
	{
		get
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana2Weapon>)+608]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ rdx_v1 (Il2CppClass<VampireSurvivors.Objects.Weapons.EME_Katana2Weapon>)+610]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ rax_v1 (should have been resolved before IL gen)");
			/*Error: End of method reached without returning.*/;
		}
	}

	public void OnEnteredScatteredPetalStage(ScatteredPetalsStage scatteredPetalsStage)
	{
		//IL_0032: Expected I, but got O
		//IL_0040: Expected I, but got O
		//IL_0050: Expected O, but got I
		//IL_00d0: Expected O, but got I4
		//IL_008c: Expected O, but got I
		//IL_00c2: Expected O, but got I4
		CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		if (characterController._characterType != CharacterType.EME_MECHKATANA)
		{
			return;
		}
		nint num = (nint)characterController;
		nint num2 = (nint)typeof(EME_CharacterControllerDiva);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EME_CharacterControllerDiva>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+130]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rdx_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.EME_CharacterControllerDiva>)+130]");
		object obj3;
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ r8_v2 (Il2CppClass<VampireSurvivors.Objects.Characters.CharacterController>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rax_v10+FFFFFFF8+v59 @ rax_v5*8]");
			if (0 == (nint)typeof(EME_CharacterControllerDiva))
			{
				obj3 = 1;
				goto IL_0104;
			}
		}
		obj3 = 0;
		goto IL_0104;
		IL_0104:
		bool flag = obj3 == null;
		EME_CharacterControllerDiva eME_CharacterControllerDiva = null;
		if (!flag)
		{
			eME_CharacterControllerDiva = (EME_CharacterControllerDiva)characterController;
		}
		eME_CharacterControllerDiva?.EnterScatteredPetalsStage(scatteredPetalsStage);
	}

	public EME_Katana2Weapon()
	{
		base.MaxBonus = 1f;
		base.MaxEnemies = 300f;
		((EME_Weapon)this)._002Ector();
	}
}
