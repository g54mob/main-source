using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Props;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;

namespace VampireSurvivors.App.Scripts.Framework;

public static class CharacterSaveManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<CharacterStageData, bool> _003C_003E9__0_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CGetCharacterStageDataForSelectedStage_003Eb__0_0(CharacterStageData x)
		{
			//IL_00b6: Expected I4, but got O
			//IL_0094: Expected O, but got I4
			if (x != null)
			{
				GameManager core = GM.Core;
				if ((object)GM.Core != null && core._playerOptions != null)
				{
					PlayerOptionsData config = core._playerOptions.Config;
					if (config != null)
					{
						object obj = x._003Ctype_003Ek__BackingField - config._003CSelectedStage_003Ek__BackingField;
						return obj == null;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public unsafe static CharacterStageData GetCharacterStageDataForSelectedStage(CharacterType chara)
	{
		//IL_0015: Expected O, but got I
		//IL_004b: Expected O, but got I
		//IL_00bc: Expected O, but got I4
		//IL_01e0: Expected I, but got O
		//IL_0211: Expected O, but got I
		//IL_00d8: Expected I, but got O
		//IL_0109: Expected O, but got I
		//IL_0892: Expected I, but got O
		//IL_05a0: Expected O, but got I
		//IL_07f2: Expected I, but got O
		//IL_0808: Expected O, but got I
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Expected O, but got Unknown
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected O, but got Unknown
		//IL_093a: Expected O, but got I4
		//IL_094a: Unknown result type (might be due to invalid IL or missing references)
		//IL_094f: Expected O, but got Unknown
		//IL_0672: Expected O, but got I
		//IL_06a8: Expected O, but got I
		//IL_072b: Expected I4, but got O
		CharacterStageData characterStageData = new CharacterStageData();
		PlayerOptions core = (PlayerOptions)(object)GM.Core;
		if ((object)GM.Core != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rcx_v5 (VampireSurvivors.Objects.PlayerOptions)+90]");
			core = (PlayerOptions)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rcx_v5 (VampireSurvivors.Objects.PlayerOptions)+90]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rcx_v5 (VampireSurvivors.Objects.PlayerOptions)+90]");
				PlayerOptionsData config = ((PlayerOptions)0).Config;
				if (config != null)
				{
					bool flag = config._003CCharacterStageData_003Ek__BackingField == null;
					core = (PlayerOptions)(object)config._003CCharacterStageData_003Ek__BackingField;
					if (!flag)
					{
						int num = ((Dictionary<System.Int32Enum, object>)(object)config._003CCharacterStageData_003Ek__BackingField).FindEntry((System.Int32Enum)chara);
						object obj = !flag;
						if (obj != null)
						{
							goto IL_01d2;
						}
						nint num2 = (nint)typeof(GM);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v78 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
						nint num3 = 0;
						GameManager core2 = GM.Core;
						bool flag2 = (object)GM.Core == null;
						core = (PlayerOptions)num3;
						if (!flag2)
						{
							core = core2._playerOptions;
							if (core2._playerOptions != null)
							{
								PlayerOptionsData config2 = core2._playerOptions.Config;
								if (config2 != null)
								{
									List<CharacterStageData> list = new List<CharacterStageData>();
									bool flag3 = config2._003CCharacterStageData_003Ek__BackingField == null;
									core = (PlayerOptions)(object)list;
									if (!flag3)
									{
										bool flag4 = ((Dictionary<System.Int32Enum, object>)(object)config2._003CCharacterStageData_003Ek__BackingField).TryInsert((System.Int32Enum)chara, (object)list, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
										goto IL_01d2;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0741;
		IL_01d2:
		nint num4 = (nint)typeof(GM);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v643 @ rax_v20 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
		nint num5 = 0;
		GameManager core3 = GM.Core;
		bool flag5 = (object)GM.Core == null;
		core = (PlayerOptions)num5;
		CharacterStageData result;
		if (!flag5)
		{
			core = core3._playerOptions;
			if (core3._playerOptions != null)
			{
				PlayerOptionsData config3 = core3._playerOptions.Config;
				if (config3 != null)
				{
					bool flag6 = config3._003CCharacterStageData_003Ek__BackingField == null;
					core = (PlayerOptions)(object)config3._003CCharacterStageData_003Ek__BackingField;
					if (!flag6)
					{
						object source = ((Dictionary<System.Int32Enum, object>)(object)config3._003CCharacterStageData_003Ek__BackingField).get_Item((System.Int32Enum)chara);
						Func<CharacterStageData, bool> predicate = _003C_003Ec._003C_003E9__0_0;
						if (_003C_003Ec._003C_003E9__0_0 == null)
						{
							Func<CharacterStageData, bool> func = (_003C_003Ec._003C_003E9__0_0 = delegate(CharacterStageData x)
							{
								//IL_00b6: Expected I4, but got O
								//IL_0094: Expected O, but got I4
								if (x != null)
								{
									GameManager core5 = GM.Core;
									if ((object)GM.Core != null && core5._playerOptions != null)
									{
										PlayerOptionsData config7 = core5._playerOptions.Config;
										if (config7 != null)
										{
											object obj13 = x._003Ctype_003Ek__BackingField - config7._003CSelectedStage_003Ek__BackingField;
											return obj13 == null;
										}
									}
								}
								NullReferenceException ex = new NullReferenceException();
								return (byte)(int)ex != 0;
							});
							nint num6 = (nint)typeof(_003C_003Ec);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ rax_v67 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.CharacterSaveManager+<>c>)+B8]");
							object obj2 = (nint)0 + (nint)8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
							bool flag7 = (nint)0 == 0;
							predicate = func;
							if (!flag7)
							{
								object obj3 = obj2 >> 12;
								object obj4 = obj3 & 0x1FFFFF;
								object obj5 = obj4 >> 6;
								object obj6 = obj5 * 8;
								object obj7 = 6603577472L + obj6;
								object obj8 = obj4 & 0x3F;
								nint num8;
								do
								{
									object obj9 = 1 << (int)obj8;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ rdx_v28+462E0]");
									object obj10 = 0 | obj9;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ rdx_v28+462E0]");
									nint num7 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ rdx_v28+462E0]");
									if (num7 == 0)
									{
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ rdx_v28+462E0]");
									num8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ rdx_v28+462E0]");
								}
								while (num8 != 0);
								predicate = func;
							}
						}
						int num9 = Enumerable.Count((IEnumerable<object>)source, (Func<object, bool>)predicate);
						bool flag8 = num9 == 0;
						nint num10 = (nint)typeof(GM);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v868 @ rax_v28 (Il2CppClass<VampireSurvivors.Framework.GM>)+B8]");
						nint num11 = 0;
						GameManager core4 = GM.Core;
						if (!flag8)
						{
							if ((object)GM.Core != null && core4._playerOptions != null)
							{
								PlayerOptionsData config4 = core4._playerOptions.Config;
								if (config4 != null && config4._003CCharacterStageData_003Ek__BackingField != null)
								{
									object obj11 = ((Dictionary<System.Int32Enum, object>)(object)config4._003CCharacterStageData_003Ek__BackingField).get_Item((System.Int32Enum)chara);
									if (obj11 != null)
									{
										result = characterStageData;
										List<CharacterStageData>.Enumerator enumerator = default(List<CharacterStageData>.Enumerator);
										if (enumerator.MoveNext())
										{
											CharacterStageData characterStageData2 = null;
											nint num12 = (nint)(&enumerator);
											throw new NullReferenceException();
										}
										goto IL_073c;
									}
								}
							}
						}
						else
						{
							bool flag9 = (object)GM.Core == null;
							core = (PlayerOptions)num11;
							if (!flag9)
							{
								core = core4._playerOptions;
								if (core4._playerOptions != null)
								{
									PlayerOptionsData config5 = core4._playerOptions.Config;
									if (config5 != null && characterStageData != null)
									{
										characterStageData._003Ctype_003Ek__BackingField = config5._003CSelectedStage_003Ek__BackingField;
										core = (PlayerOptions)(object)GM.Core;
										if ((object)GM.Core != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rcx_v5 (VampireSurvivors.Objects.PlayerOptions)+90]");
											core = (PlayerOptions)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rcx_v5 (VampireSurvivors.Objects.PlayerOptions)+90]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rcx_v5 (VampireSurvivors.Objects.PlayerOptions)+90]");
												PlayerOptionsData config6 = ((PlayerOptions)0).Config;
												if (config6 != null && config6._003CCharacterStageData_003Ek__BackingField != null)
												{
													object obj12 = ((Dictionary<System.Int32Enum, object>)(object)config6._003CCharacterStageData_003Ek__BackingField).get_Item((System.Int32Enum)chara);
													if (obj12 != null)
													{
														List<CharacterStageData> list2 = ((Dictionary<CharacterType, List<CharacterStageData>>)obj12).get_Item((CharacterType)characterStageData);
														result = characterStageData;
														goto IL_073c;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0741;
		IL_0741:
		throw new NullReferenceException();
		IL_073c:
		return result;
	}

	public static List<CharacterStageData> GetAllCharacterStageData(CharacterType chara)
	{
		GameManager core = GM.Core;
		if ((object)GM.Core != null && core._playerOptions != null)
		{
			PlayerOptionsData config = core._playerOptions.Config;
			if (config != null && config._003CCharacterStageData_003Ek__BackingField != null)
			{
				int num = ((Dictionary<System.Int32Enum, object>)(object)config._003CCharacterStageData_003Ek__BackingField).FindEntry((System.Int32Enum)chara);
				if (num < 0)
				{
					return new List<CharacterStageData>();
				}
				GameManager core2 = GM.Core;
				if ((object)GM.Core != null && core2._playerOptions != null)
				{
					PlayerOptionsData config2 = core2._playerOptions.Config;
					if (config2 != null && config2._003CCharacterStageData_003Ek__BackingField != null)
					{
						return (List<CharacterStageData>)((Dictionary<System.Int32Enum, object>)(object)config2._003CCharacterStageData_003Ek__BackingField).get_Item((System.Int32Enum)chara);
					}
				}
			}
		}
		return (List<CharacterStageData>)(object)new NullReferenceException();
	}

	public unsafe static bool HasCharacterCompletedAnyStage(CharacterType chara)
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<CharacterStageData> allCharacterStageData = GetAllCharacterStageData(chara);
		List<CharacterStageData>.Enumerator enumerator = default(List<CharacterStageData>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<CharacterStageData>.Enumerator enumerator2 = (List<CharacterStageData>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	public unsafe static bool HasCharacterCompletedStage(CharacterType chara, StageType stageType)
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		List<CharacterStageData> allCharacterStageData = GetAllCharacterStageData(chara);
		List<CharacterStageData>.Enumerator enumerator = default(List<CharacterStageData>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<CharacterStageData>.Enumerator enumerator2 = (List<CharacterStageData>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return false;
	}

	public static void SetCharacterStageData(CharacterType chara, CharacterStageData stageData)
	{
		//IL_0080: Expected O, but got I
		//IL_0095: Expected O, but got I
		GameManager core = GM.Core;
		PlayerOptionsData config = core._playerOptions.Config;
		object obj = ((Dictionary<System.Int32Enum, object>)(object)config._003CCharacterStageData_003Ek__BackingField).get_Item((System.Int32Enum)chara);
		int num = 0;
		int num2 = 0;
		while (true)
		{
			int num3 = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v11 (System.Object)+18]");
			if ((nint)num3 < (nint)0)
			{
				int num4 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v11 (System.Object)+18]");
				if ((nint)num4 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rax_v11 (System.Object)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rcx_v11+20+v73 @ rbx_v5 (System.Int32)*8]");
				object obj3 = 0;
				GameManager core2 = GM.Core;
				PlayerOptionsData config2 = core2._playerOptions.Config;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ rdx_v8+20]");
				if ((nint)0 != (nint)config2._003CSelectedStage_003Ek__BackingField)
				{
					num++;
					num2 = num;
					continue;
				}
				GameManager core3 = GM.Core;
				PlayerOptionsData config3 = core3._playerOptions.Config;
				object obj4 = ((Dictionary<System.Int32Enum, object>)(object)config3._003CCharacterStageData_003Ek__BackingField).get_Item((System.Int32Enum)chara);
				((List<CharacterStageData>)obj4).set_Item(num, stageData);
				return;
			}
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}
}
