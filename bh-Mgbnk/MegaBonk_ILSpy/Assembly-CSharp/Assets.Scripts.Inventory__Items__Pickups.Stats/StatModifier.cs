using System;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;

namespace Assets.Scripts.Inventory__Items__Pickups.Stats;

[Serializable]
public class StatModifier
{
	public EStat stat;

	public EStatModifyType modifyType;

	public float modification;

	public float GetModificationAtAmount(int amount)
	{
		return modification;
	}

	public float GetModificationTotal(int amount)
	{
		//IL_000e: Expected O, but got I4
		//IL_0107: Expected F4, but got I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_005d: Expected F4, but got I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_008b: Expected F4, but got I4
		object obj = amount + 1;
		if ((nint)obj > 1)
		{
			object obj2 = obj - 1;
			bool flag = (nint)obj2 < 8;
			int num = 1;
			float num2 = 0f;
			if (!flag)
			{
				object obj3 = obj - 7;
				num = 1;
				num2 = 0f;
				num = amount;
				float num3 = default(float);
				num2 = num3;
				do
				{
					num += 8;
					float num4 = modification + num2;
					float num5 = num4 + modification;
					float num6 = num5 + modification;
					float num7 = num6 + modification;
					float num8 = num7 + modification;
					float num9 = num8 + modification;
					float num10 = num9 + modification;
					num2 = num10 + modification;
				}
				while (num < (nint)obj3);
				if (num >= (nint)obj)
				{
					return num2;
				}
			}
			do
			{
				num++;
				num2 += modification;
			}
			while (num < (nint)obj);
			return num2;
		}
		return 0f;
	}

	public override string ToString()
	{
		//IL_002d: Expected I4, but got O
		//IL_0044: Expected I4, but got O
		object obj = default(object);
		object arg = (EStat)obj;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object obj2 = default(object);
		object arg2 = (EStatModifyType)obj2;
		object arg3 = default(object);
		return $"{arg}: {arg3} ({arg2})\n";
	}
}
