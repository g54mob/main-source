using Assets.Scripts.Inventory.Stats;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatEntry : MonoBehaviour
{
	public RawImage icon;

	public TextMeshProUGUI t_stat;

	public TextMeshProUGUI t_value;

	private EStat stat;

	public ToolTipObject toolTipObject;

	private void OnEnable()
	{
	}

	private void RefreshValues()
	{
	}

	public void Set(EStat stat)
	{
		//IL_002e: Expected I, but got O
		//IL_0125: Expected O, but got I4
		//IL_0088: Expected O, but got I8
		//IL_0096: Expected O, but got I4
		//IL_00a6: Expected O, but got I
		//IL_00c0: Expected O, but got I8
		TextMeshProUGUI textMeshProUGUI = t_stat;
		this.stat = stat;
		string text = EnumUtility.EnumToReadable(stat);
		nint num = (nint)textMeshProUGUI;
		textMeshProUGUI.text = text;
		float num2 = PlayerStats.GetStat(stat);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317302E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		object obj = stat - 4;
		if ((nint)obj <= 37)
		{
			object obj2 = 6442450944L;
			object obj3 = stat - 4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v10+55B688+v153 @ rax_v13]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v10+55B670+v138 @ rax_v14*4]");
			object obj5 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v143 @ rcx_v14 (should have been resolved before IL gen)");
		}
		string format;
		if (stat != EStat.SilverIncreaseMultiplier)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			format = "{0:N0}";
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
			format = "{0:N1}x";
		}
		object arg = default(object);
		string text2 = string.Format(format, arg);
		t_value.text = text2;
	}
}
