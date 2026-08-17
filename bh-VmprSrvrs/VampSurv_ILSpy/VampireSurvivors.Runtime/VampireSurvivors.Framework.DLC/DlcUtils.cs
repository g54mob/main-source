using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.DLC;

public class DlcUtils
{
	private Dictionary<CharacterType, DlcType> _characterDlcDict;

	public DlcType? GetStageDlcType(StageType stageType, DataManager dataManager)
	{
		//IL_001e: Expected I, but got O
		//IL_0039: Expected I, but got O
		//IL_00e2: Expected O, but got I4
		//IL_005b: Expected I, but got O
		//IL_0060: Expected I, but got O
		DataManager dataManager2 = default(DataManager);
		bool flag = dataManager2._dlcStageData == null;
		nint num = unchecked((nint)null);
		if (!flag)
		{
			nint num2 = (nint)dataManager2._dlcStageData;
			num = 2;
			Dictionary<DlcType, Dictionary<StageType, List<VampireSurvivors.Data.Stage.StageData>>>.Enumerator enumerator = default(Dictionary<DlcType, Dictionary<StageType, List<VampireSurvivors.Data.Stage.StageData>>>.Enumerator);
			while (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				num = unchecked((nint)null);
				num2 = unchecked((nint)null);
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18699C0C0");
		object obj = default(object);
		if (obj != null)
		{
			return AdventureManager._003CCurrentAdventureDlcType_003Ek__BackingField;
		}
		return (DlcType?)(object)0;
	}

	public DlcType? GetBgmDlcType(BgmType bgmType, DataManager dataManager)
	{
		//IL_0074: Expected O, but got I4
		//IL_0066: Expected O, but got I4
		if (dataManager._dlcMusicData == null)
		{
			return (DlcType?)(object)0;
		}
		Dictionary<DlcType, Dictionary<BgmType, MusicData>>.Enumerator enumerator = default(Dictionary<DlcType, Dictionary<BgmType, MusicData>>.Enumerator);
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
		}
		return (DlcType?)(object)0;
	}

	public DlcType? GetSFXDlcType(SfxType sfxType, DataManager dataManager)
	{
		//IL_009f: Expected O, but got I4
		//IL_0091: Expected O, but got I4
		if (dataManager._dlcSfxData == null)
		{
			return (DlcType?)(object)0;
		}
		Dictionary<DlcType, HashSet<string>>.Enumerator enumerator = default(Dictionary<DlcType, HashSet<string>>.Enumerator);
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
		}
		return (DlcType?)(object)0;
	}

	public unsafe DlcType? GetCharacterDlcType(CharacterType characterType, DataManager dataManager)
	{
		//IL_0263: Expected O, but got I4
		//IL_0033: Expected O, but got I4
		//IL_01a7: Expected O, but got I
		//IL_014a: Expected O, but got I4
		//IL_0152: Expected O, but got Ref
		//IL_01fc: Expected O, but got I4
		DataManager dataManager2 = default(DataManager);
		bool flag = dataManager2 == null;
		DlcUtils dlcUtils = this;
		if (!flag)
		{
			if (dataManager2._dlcCharacterData == null)
			{
				return (DlcType?)(object)0;
			}
			DlcType? result;
			if (_characterDlcDict == null)
			{
				dlcUtils = (DlcUtils)(object)(_characterDlcDict = new Dictionary<CharacterType, DlcType>());
				if (dataManager2._dlcCharacterData == null)
				{
					goto IL_0201;
				}
				Dictionary<DlcType, Dictionary<CharacterType, List<VampireSurvivors.Data.Characters.CharacterData>>>.Enumerator enumerator = default(Dictionary<DlcType, Dictionary<CharacterType, List<VampireSurvivors.Data.Characters.CharacterData>>>.Enumerator);
				if (enumerator.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					Dictionary<System.Int32Enum, System.Int32Enum> dictionary = null;
					throw new NullReferenceException();
				}
				result = (DlcType?)(object)0;
				dlcUtils = (DlcUtils)(&enumerator);
			}
			else
			{
				result = (DlcType?)(object)0;
				dlcUtils = this;
			}
			Dictionary<CharacterType, DlcType> characterDlcDict = _characterDlcDict;
			if (_characterDlcDict != null)
			{
				int num = _characterDlcDict.FindEntry(characterType);
				if (num < 0)
				{
					return result;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdi_v10 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.Data.DlcType>)+18]");
				dlcUtils = (DlcUtils)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rdi_v10 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.CharacterType, VampireSurvivors.Data.DlcType>)+18]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v7 (VampireSurvivors.Framework.DLC.DlcUtils)+18]");
					if ((nint)num < (nint)0)
					{
						return (DlcType?)(object)1;
					}
					return (DlcType?)new IndexOutOfRangeException();
				}
			}
		}
		goto IL_0201;
		IL_0201:
		throw new NullReferenceException();
	}

	public DlcType? GetEnemyDlcType(EnemyType enemyType, DataManager dataManager)
	{
		//IL_0074: Expected O, but got I4
		//IL_0066: Expected O, but got I4
		if (dataManager._dlcEnemyData == null)
		{
			return (DlcType?)(object)0;
		}
		Dictionary<DlcType, Dictionary<EnemyType, List<VampireSurvivors.Data.Enemies.EnemyData>>>.Enumerator enumerator = default(Dictionary<DlcType, Dictionary<EnemyType, List<VampireSurvivors.Data.Enemies.EnemyData>>>.Enumerator);
		while (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
		}
		return (DlcType?)(object)0;
	}

	public unsafe string GetPersistentLabel(DlcType dlcType)
	{
		//IL_0045: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		if (text != null)
		{
			string text2 = text.ToLowerInvariant();
			return text2 + "_persistent";
		}
		return (string)(object)new NullReferenceException();
	}

	public unsafe string GetGameplayLabel(DlcType dlcType)
	{
		//IL_0045: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		if (text != null)
		{
			string text2 = text.ToLowerInvariant();
			return text2 + "_dynamic";
		}
		return (string)(object)new NullReferenceException();
	}
}
