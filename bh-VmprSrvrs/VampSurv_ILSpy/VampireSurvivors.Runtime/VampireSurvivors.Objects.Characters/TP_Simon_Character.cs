using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Characters;

public class TP_Simon_Character : TP_Character
{
	private List<float> _critChancesArray;

	private int _critIndex;

	public override void AfterFullInitialization()
	{
		base.AfterFullInitialization();
		_critIndex = 0;
		List<float> critChancesArray = Weapon.MakeChanceArray(1000);
		_critChancesArray = critChancesArray;
	}

	public override float PPower()
	{
		//IL_0053: Expected O, but got I
		//IL_00af: Expected F4, but got I
		//IL_00c0: Invalid comparison between I and F4
		//IL_0130: Expected F4, but got I4
		//IL_00fa: Invalid comparison between I4 and F4
		//IL_010c: Expected F4, but got I4
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		List<float> critChancesArray = _critChancesArray;
		int critIndex = _critIndex + 1;
		_critIndex = critIndex;
		if (_critChancesArray != null)
		{
			int critIndex2 = _critIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
			int num = (int)((nint)critIndex2 % (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)num < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v6+18]");
					if ((nint)num >= (nint)0)
					{
						throw new IndexOutOfRangeException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v6+20+v52 @ rdx_v4 (System.Int32)*4]");
					float num2 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rcx_v6+20+v52 @ rdx_v4 (System.Int32)*4]");
					float num4;
					if (0f > 0.5f)
					{
						float num3 = base.PGrowth();
						num2--;
						bool flag = !(0f < num2);
						num4 = 0f;
						if (!flag)
						{
							num4 = num2;
						}
					}
					else
					{
						num4 = 0f;
					}
					PlayerModifierStats playerStats = _playerStats;
					if (_playerStats != null)
					{
						EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
						if (playerStats._003CPower_003Ek__BackingField != null)
						{
							float value = default(float);
							EggFloat eggFloat2 = new EggFloat(value, eggFloat._eggVal);
							value = eggFloat._val + num4;
							if (eggFloat2 != null)
							{
								float num5 = eggFloat2._eggVal + eggFloat2._val;
								object obj2 = num5 & -2147483649L;
								if ((nint)obj2 != 2139095040)
								{
									object obj3 = num5 & -2147483649L;
									if ((nint)obj3 <= 2139095040)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001876460E5h\"");
										if (num5 == -1f / 0f)
										{
											num5 = -3.4028235E+38f;
										}
										return num5;
									}
								}
								return 3.4028235E+38f;
							}
						}
					}
				}
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
		throw new NullReferenceException();
	}

	public override float PArmor()
	{
		//IL_0053: Expected O, but got I
		//IL_00b0: Invalid comparison between I and F4
		//IL_00e2: Invalid comparison between F4 and I
		//IL_0112: Expected F4, but got I
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		List<float> critChancesArray = _critChancesArray;
		int critIndex = _critIndex + 1;
		_critIndex = critIndex;
		float num3;
		float num4;
		if (_critChancesArray != null)
		{
			int critIndex2 = _critIndex;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
			int num = (int)((nint)critIndex2 % (nint)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+18]");
			if ((nint)num < (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ r8_v1 (System.Collections.Generic.List`1<System.Single>)+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v6+18]");
					if ((nint)num >= (nint)0)
					{
						throw new IndexOutOfRangeException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v6+20+v50 @ rdx_v4 (System.Int32)*4]");
					if (0f > 0.5f)
					{
						float num2 = base.PGrowth();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v6+20+v50 @ rdx_v4 (System.Int32)*4]");
						bool flag = !(1f < 0f);
						num3 = 1f;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rcx_v6+20+v50 @ rdx_v4 (System.Int32)*4]");
							num3 = 0f;
						}
					}
					else
					{
						num3 = 1f;
					}
					PlayerModifierStats playerStats = _playerStats;
					if (_playerStats != null)
					{
						EggFloat eggFloat = playerStats._003CArmor_003Ek__BackingField;
						if (playerStats._003CArmor_003Ek__BackingField != null)
						{
							num4 = eggFloat._eggVal + eggFloat._val;
							object obj2 = num4 & -2147483649L;
							if ((nint)obj2 != 2139095040)
							{
								object obj3 = num4 & -2147483649L;
								if ((nint)obj3 <= 2139095040)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000187646237h\"");
									if (num4 == -1f / 0f)
									{
										num4 = -3.4028235E+38f;
									}
									goto IL_0290;
								}
							}
							num4 = 3.4028235E+38f;
							goto IL_0290;
						}
					}
				}
			}
			else
			{
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			}
		}
		throw new NullReferenceException();
		IL_0290:
		bool flag2 = !(50f > num4);
		float num5 = 50f;
		if (!flag2)
		{
			num5 = num4;
		}
		float num6 = num5 + ArmorManualIncrease;
		return num6 * num3;
	}
}
