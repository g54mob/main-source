using System;
using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

namespace Assets.Scripts.Saves___Serialization.Progression.Achievements;

public abstract class UnlockableBase : ScriptableObject, IComparable<UnlockableBase>
{
	public bool isEnabled = true;

	public bool showInUnlocks;

	public bool canAlwaysToggle;

	public string author;

	public int price;

	public int sortingPriority;

	public LocalizedString localizedName;

	public LocalizedString localizedDescription;

	public List<LocalizationKey> serializedLocalizationKeys;

	public List<LocalizationKey> serializedLocalizationKeysName;

	public virtual string GetName()
	{
		//IL_0040: Expected I, but got O
		//IL_00b2: Expected I, but got O
		//IL_00ea: Expected I, but got O
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0184: Expected I, but got O
		bool flag = localizedName == null;
		UnlockableBase unlockableBase = (UnlockableBase)(object)localizedName;
		if (!flag)
		{
			if (localizedName.IsEmpty)
			{
				return "";
			}
			Dictionary<string, string> keysName = GetKeysName();
			bool flag2 = keysName == null;
			nint num = unchecked((nint)null);
			if (!flag2)
			{
				int count = keysName.Count;
				bool flag3 = count <= 0;
				num = 0;
				if (!flag3)
				{
					object[] array = new object[1];
					Dictionary<string, string> keysName2 = GetKeysName();
					bool flag4 = array == null;
					num = unchecked((nint)null);
					unlockableBase = this;
					if (!flag4)
					{
						if (keysName2 != null)
						{
							nint num2 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rdx_v15 (Il2CppClass<System.Object[]>)+40]");
							num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
							object obj = default(object);
							bool flag5 = obj == null;
							unlockableBase = (UnlockableBase)(object)keysName2;
							if (flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
								object obj2 = default(object);
								throw obj2;
							}
						}
						if (array.Length <= 0)
						{
							return (string)(object)new IndexOutOfRangeException();
						}
						unlockableBase = (UnlockableBase)(array + 32);
						array[0] = keysName2;
						bool flag6 = localizedName == null;
						num = (nint)keysName2;
						if (!flag6)
						{
							return localizedName.GetLocalizedString(array);
						}
					}
					goto IL_01ed;
				}
			}
			bool flag7 = localizedName == null;
			unlockableBase = (UnlockableBase)(object)localizedName;
			if (!flag7)
			{
				return localizedName.GetLocalizedString();
			}
		}
		goto IL_01ed;
		IL_01ed:
		throw new NullReferenceException();
	}

	public virtual string GetDescription()
	{
		//IL_0040: Expected I, but got O
		//IL_00b2: Expected I, but got O
		//IL_00ea: Expected I, but got O
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0184: Expected I, but got O
		bool flag = localizedDescription == null;
		UnlockableBase unlockableBase = (UnlockableBase)(object)localizedDescription;
		if (!flag)
		{
			if (localizedDescription.IsEmpty)
			{
				return "";
			}
			Dictionary<string, string> keysDesc = GetKeysDesc();
			bool flag2 = keysDesc == null;
			nint num = unchecked((nint)null);
			if (!flag2)
			{
				int count = keysDesc.Count;
				bool flag3 = count <= 0;
				num = 0;
				if (!flag3)
				{
					object[] array = new object[1];
					Dictionary<string, string> keysDesc2 = GetKeysDesc();
					bool flag4 = array == null;
					num = unchecked((nint)null);
					unlockableBase = this;
					if (!flag4)
					{
						if (keysDesc2 != null)
						{
							nint num2 = (nint)array;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ rdx_v15 (Il2CppClass<System.Object[]>)+40]");
							num = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
							object obj = default(object);
							bool flag5 = obj == null;
							unlockableBase = (UnlockableBase)(object)keysDesc2;
							if (flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
								object obj2 = default(object);
								throw obj2;
							}
						}
						if (array.Length <= 0)
						{
							return (string)(object)new IndexOutOfRangeException();
						}
						unlockableBase = (UnlockableBase)(array + 32);
						array[0] = keysDesc2;
						bool flag6 = localizedDescription == null;
						num = (nint)keysDesc2;
						if (!flag6)
						{
							return localizedDescription.GetLocalizedString(array);
						}
					}
					goto IL_01ed;
				}
			}
			bool flag7 = localizedDescription == null;
			unlockableBase = (UnlockableBase)(object)localizedDescription;
			if (!flag7)
			{
				return localizedDescription.GetLocalizedString();
			}
		}
		goto IL_01ed;
		IL_01ed:
		throw new NullReferenceException();
	}

	private unsafe Dictionary<string, string> GetKeysDesc()
	{
		//IL_002c: Expected O, but got Ref
		//IL_0070: Expected O, but got I
		//IL_00aa: Expected O, but got I
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = obj == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_-30+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_-30+18]");
						string localizedString = ((LocalizedString)0).GetLocalizedString();
						if (dictionary == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_-30+10]");
						((Dictionary<object, object>)(object)dictionary).Add((object)0, (object)localizedString);
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<LocalizationKey>.Enumerator*)(&enumerator))->Dispose();
			return dictionary;
		}
		throw new NullReferenceException();
	}

	private unsafe Dictionary<string, string> GetKeysName()
	{
		//IL_002c: Expected O, but got Ref
		//IL_0070: Expected O, but got I
		//IL_00aa: Expected O, but got I
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = obj == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_-30+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_-30+18]");
						string localizedString = ((LocalizedString)0).GetLocalizedString();
						if (dictionary == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_-30+10]");
						((Dictionary<object, object>)(object)dictionary).Add((object)0, (object)localizedString);
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			((List<LocalizationKey>.Enumerator*)(&enumerator))->Dispose();
			return dictionary;
		}
		throw new NullReferenceException();
	}

	public virtual int GetPrice()
	{
		float num = (float)price * 1.75f;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331070");
		int result = default(int);
		return result;
	}

	public abstract Texture GetIcon();

	public abstract MyAchievement GetUnlockRequirement();

	public abstract UnlockableBase GetUnlockableRequirement();

	public abstract string GetUnlockableTypeDisplayString();

	public abstract string GetInternalName();

	public bool CanBuy()
	{
		//IL_00ec: Expected I4, but got O
		//IL_007c: Expected O, but got I4
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected I4, but got Unknown
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			ProgressionSaveFile progression = saveManager.progression;
			if (saveManager.progression != null)
			{
				int num = GetPrice();
				object obj = progression.silver - num;
				int num2 = progression.silver ^ num;
				int num3 = progression.silver ^ obj;
				int num4 = num2 & num3;
				bool flag = num4 < 0;
				bool flag2 = (nint)obj < 0;
				return flag2 == flag;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public unsafe virtual int CompareTo(UnlockableBase other)
	{
		//IL_009e: Expected I4, but got O
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected I4, but got Unknown
		int num = GetPrice();
		if ((object)other != null)
		{
			int value = other.GetPrice();
			int num3 = default(int);
			int num2 = num3.CompareTo(value);
			if (num2 == 0)
			{
				int num4 = this + 44;
				num2 = ((int*)num4)->CompareTo(other.sortingPriority);
			}
			return num2;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}
}
