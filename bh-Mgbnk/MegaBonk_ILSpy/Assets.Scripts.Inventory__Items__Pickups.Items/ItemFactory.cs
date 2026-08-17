using System;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Items;

public static class ItemFactory
{
	public static ItemBase CreateItem(EItem eItem, ItemInventory inventory)
	{
		//IL_0012: Expected O, but got I8
		//IL_002c: Expected O, but got I8
		if (eItem <= EItem.WizardsHat)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rdx_v5+44201C+eItem @ rcx (Assets.Scripts.Inventory__Items__Pickups.Items.EItem)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v53 @ rcx_v12 (should have been resolved before IL gen)");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		string message = $"Unknown item type: {arg}";
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		ArgumentException ex = new ArgumentException(message);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex;
	}
}
