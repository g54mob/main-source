using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.AbilitiesPassive;

public static class PassiveAbilityFactory
{
	public static PassiveAbility CreatePassiveAbility(PassiveData passive)
	{
		//IL_003b: Expected O, but got I4
		bool flag = passive == null;
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 92 Invalid \"Jump target not found in method: 0x18047760A\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 103 Invalid \"Jump target not found in method: 0x18047762C\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 119 Invalid \"Jump target not found in method: 0x1804775F9\"");
		return (PassiveAbility)passive.ePassive;
	}
}
