using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace Doozy.Engine.Soundy;

[Serializable]
public class SoundDatabase : ScriptableObject
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<SoundGroupData, string> _003C_003E9__17_0;

		public static Func<IGrouping<string, SoundGroupData>, SoundGroupData> _003C_003E9__17_1;

		public static Func<SoundGroupData, bool> _003C_003E9__18_0;

		public static Func<SoundGroupData, string> _003C_003E9__20_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal string _003CRemoveDuplicateEntries_003Eb__17_0(SoundGroupData data)
		{
			if ((object)data != null)
			{
				return data.SoundName;
			}
			return (string)(object)new NullReferenceException();
		}

		internal SoundGroupData _003CRemoveDuplicateEntries_003Eb__17_1(IGrouping<string, SoundGroupData> n)
		{
			return Enumerable.First(n);
		}

		internal bool _003CRemoveUnnamedEntries_003Eb__18_0(SoundGroupData data)
		{
			//IL_00b2: Expected I4, but got O
			if ((object)data != null && data.SoundName != null)
			{
				string text = data.SoundName.TrimWhiteSpaceHelper(string.TrimType.Both);
				if (text != null && text._stringLength > 0)
				{
					return true;
				}
				return false;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal string _003CSort_003Eb__20_0(SoundGroupData data)
		{
			if ((object)data != null)
			{
				return data.SoundName;
			}
			return (string)(object)new NullReferenceException();
		}
	}

	public string DatabaseName;

	public AudioMixerGroup OutputAudioMixerGroup;

	public List<string> SoundNames;

	public List<SoundGroupData> Database;

	private static UILanguagePack UILabels => UILanguagePack.Instance;

	public bool HasSoundsWithMissingAudioClips
	{
		get
		{
			List<SoundGroupData>.Enumerator enumerator = default(List<SoundGroupData>.Enumerator);
			if (enumerator.MoveNext())
			{
				SoundGroupData soundGroupData = null;
				throw new NullReferenceException();
			}
			return false;
		}
	}

	public bool Add(SoundGroupData data, bool saveAssets)
	{
		if ((object)data != null && ((UnityEngine.Object)data).m_CachedPtr != (IntPtr)0)
		{
			data.DatabaseName = DatabaseName;
			DoozyUtils.SetDirty(this, saveAssets);
			return true;
		}
		return false;
	}

	public unsafe SoundGroupData Add(string soundName, bool performUndo, bool saveAssets)
	{
		//IL_003d: Expected O, but got I4
		//IL_0074: Expected O, but got Ref
		//IL_0185: Expected O, but got I4
		//IL_01b5: Expected O, but got I4
		if (soundName != null)
		{
			string text = soundName.TrimWhiteSpaceHelper(string.TrimType.Both);
			bool flag = Contains(text);
			bool flag2 = !flag;
			string text2 = (string)saveAssets;
			string soundName2 = text;
			if (!flag2)
			{
				int num = 0;
				object obj = default(object);
				string text4;
				do
				{
					num++;
					string text3 = System.Number.FormatInt32(num, (ReadOnlySpan<char>)(&obj), null);
					text4 = text + " (" + text3 + ")";
				}
				while (Contains(text4));
				text2 = ")";
				soundName2 = text4;
			}
			if (performUndo)
			{
				UILanguagePack instance = UILanguagePack.Instance;
				if ((object)instance == null)
				{
					goto IL_01fc;
				}
				DoozyUtils.UndoRecordObject(this, instance.AddItem);
			}
			SoundGroupData soundGroupData = ScriptableObject.CreateInstance<SoundGroupData>();
			if ((object)soundGroupData != null)
			{
				soundGroupData.DatabaseName = DatabaseName;
				soundGroupData.SoundName = soundName2;
				((UnityEngine.Object)soundGroupData).SetName(soundGroupData.SoundName);
				DoozyUtils.SetDirty(soundGroupData, saveAssets: false);
				bool flag3 = Database != null;
				object obj2 = 0;
				if (!flag3)
				{
					List<SoundGroupData> database = new List<SoundGroupData>();
					Database = database;
					obj2 = 0;
				}
				if (Database != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049C2D0");
					DoozyUtils.SetDirty(this, saveAssets);
					return soundGroupData;
				}
			}
		}
		goto IL_01fc;
		IL_01fc:
		return (SoundGroupData)(object)new NullReferenceException();
	}

	public bool Contains(string soundName)
	{
		//IL_0014: Expected O, but got I4
		List<SoundGroupData>.Enumerator enumerator = default(List<SoundGroupData>.Enumerator);
		if (Database == null)
		{
			List<SoundGroupData> database = new List<SoundGroupData>();
			Database = database;
		}
		else if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
		return false;
	}

	public bool Contains(SoundGroupData soundGroupData)
	{
		//IL_00e6: Expected I4, but got O
		//IL_00b3: Expected O, but got I4
		if ((object)soundGroupData != null && ((UnityEngine.Object)soundGroupData).m_CachedPtr != (IntPtr)0)
		{
			List<SoundGroupData> database = Database;
			if (Database == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			if (database._size != 0)
			{
				int num = Array.IndexOf((object[])database._items, (object)soundGroupData, 0, database._size);
				object obj = num - -1;
				bool flag = obj == null;
				return !flag;
			}
		}
		return false;
	}

	public unsafe SoundGroupData GetData(string soundName)
	{
		//IL_0017: Expected O, but got Ref
		List<SoundGroupData>.Enumerator enumerator = default(List<SoundGroupData>.Enumerator);
		if (enumerator.MoveNext())
		{
			SoundGroupData soundGroupData = null;
			List<SoundGroupData>.Enumerator enumerator2 = (List<SoundGroupData>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public void Initialize(bool saveAssets)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 3 Invalid \"Jump target not found in method: 0x182C1BEE0\"");
	}

	public void RefreshDatabase(bool performUndo, bool saveAssets)
	{
		//IL_0236: Expected O, but got I4
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected I4, but got Unknown
		UILanguagePack instance = UILanguagePack.Instance;
		string text = instance.SoundyDatabase + ": " + DatabaseName;
		UILanguagePack instance2 = UILanguagePack.Instance;
		if (performUndo)
		{
			UILanguagePack instance3 = UILanguagePack.Instance;
			DoozyUtils.UndoRecordObject(this, instance3.RefreshDatabase);
		}
		bool flag = AddNoSound();
		UILanguagePack instance4 = UILanguagePack.Instance;
		string text2 = instance4.SoundyDatabase + ": " + DatabaseName;
		UILanguagePack instance5 = UILanguagePack.Instance;
		RemoveUnnamedEntries(performUndo: false);
		UILanguagePack instance6 = UILanguagePack.Instance;
		string text3 = instance6.SoundyDatabase + ": " + DatabaseName;
		UILanguagePack instance7 = UILanguagePack.Instance;
		RemoveDuplicateEntries(performUndo: false);
		UILanguagePack instance8 = UILanguagePack.Instance;
		string text4 = instance8.SoundyDatabase + ": " + DatabaseName;
		UILanguagePack instance9 = UILanguagePack.Instance;
		bool flag2 = CheckAllDataForCorrectDatabaseName(saveAssets: false);
		UILanguagePack instance10 = UILanguagePack.Instance;
		string text5 = instance10.SoundyDatabase + ": " + DatabaseName;
		UILanguagePack instance11 = UILanguagePack.Instance;
		Sort(performUndo: false);
		UILanguagePack instance12 = UILanguagePack.Instance;
		string text6 = instance12.SoundyDatabase + ": " + DatabaseName;
		UILanguagePack instance13 = UILanguagePack.Instance;
		UpdateSoundNames(saveAssets: false);
		UILanguagePack instance14 = UILanguagePack.Instance;
		string text7 = instance14.SoundyDatabase + ": " + DatabaseName;
		UILanguagePack instance15 = UILanguagePack.Instance;
		object obj = flag | flag2;
		bool saveAssets2 = (byte)((obj & saveAssets) ? 1 : 0) != 0;
		DoozyUtils.SetDirty(this, saveAssets2);
		UILanguagePack instance16 = UILanguagePack.Instance;
		string text8 = instance16.SoundyDatabase + ": " + DatabaseName;
		UILanguagePack instance17 = UILanguagePack.Instance;
	}

	public bool Remove(SoundGroupData data, bool showDialog = false, bool saveAssets = false)
	{
		//IL_031c: Expected I4, but got O
		if ((object)data != null && ((UnityEngine.Object)data).m_CachedPtr != (IntPtr)0 && ((UnityEngine.Object)data).m_CachedPtr != (IntPtr)0)
		{
			List<SoundGroupData> database = Database;
			if (Database == null)
			{
				goto IL_030e;
			}
			if (database._size != 0)
			{
				int num = Array.IndexOf((object[])database._items, (object)data, 0, database._size);
				if (num != -1)
				{
					List<SoundGroupData> database2 = Database;
					bool flag = (nint)Database < 0;
					if (Database != null)
					{
						int num2 = database2._size - 1;
						if (flag)
						{
							goto IL_0226;
						}
						while (true)
						{
							List<SoundGroupData> database3 = Database;
							if (Database == null)
							{
								break;
							}
							if (num2 < database3._size)
							{
								SoundGroupData[] items = database3._items;
								if (database3._items == null)
								{
									break;
								}
								bool flag2;
								if ((object)items[num2] != null)
								{
									object obj = (object)items[num2] - (object)data;
									flag2 = obj == null;
								}
								else
								{
									flag2 = ((UnityEngine.Object)data).m_CachedPtr == (IntPtr)0;
								}
								if (!flag2)
								{
									num2--;
									if ((flag2 ? 1 : 0) >= (false ? 1 : 0))
									{
										continue;
									}
								}
								else
								{
									if (((UnityEngine.Object)data).m_CachedPtr != (IntPtr)0)
									{
										UnityEngine.Object.DestroyImmediate(data, allowDestroyingAssets: true);
									}
									if (Database == null)
									{
										break;
									}
									Database.RemoveAt(num2);
								}
								goto IL_0226;
							}
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							break;
						}
					}
					goto IL_030e;
				}
			}
		}
		return false;
		IL_030e:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0226:
		UpdateSoundNames(saveAssets: false);
		SetDirty(saveAssets);
		return true;
	}

	public unsafe void RemoveEntriesWithNoAudioClipsReferenced(bool performUndo, bool saveAssets = false)
	{
		//IL_0020: Expected I4, but got O
		//IL_0402: Expected O, but got I4
		//IL_015d: Expected I8, but got I4
		//IL_0199: Expected I8, but got I4
		//IL_028a: Expected I4, but got I8
		//IL_0292: Expected I4, but got I8
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected Ref, but got Unknown
		//IL_01cd: Expected I8, but got I4
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected Ref, but got Unknown
		//IL_0209: Expected I, but got O
		//IL_020e: Expected I, but got O
		//IL_0216: Expected I4, but got I8
		//IL_0330: Expected O, but got I4
		bool flag = !performUndo;
		bool flag2 = saveAssets;
		bool flag3 = performUndo;
		if (!flag)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			flag3 = (byte)(int)instance.RemovedEntry != 0;
			DoozyUtils.UndoRecordObject(this, instance.RemovedEntry);
			flag2 = false;
		}
		List<SoundGroupData> database = Database;
		bool flag4 = (nint)Database < 0;
		int num = database._size - 1;
		if (!flag4)
		{
			nint num3 = default(nint);
			object obj3 = default(object);
			object obj5;
			do
			{
				List<SoundGroupData> database2 = Database;
				bool flag5;
				if (num < database2._size)
				{
					SoundGroupData[] items = database2._items;
					SoundGroupData soundGroupData = items[num];
					string soundName = soundGroupData.SoundName;
					object obj = "No Sound";
					object obj2 = (object)soundGroupData.SoundName - (object)"No Sound";
					flag5 = (nint)obj2 < 0;
					if ((object)soundGroupData.SoundName != "No Sound")
					{
						bool flag6 = "No Sound" == null;
						nint num2 = num3;
						ulong num4 = (ulong)(flag2 ? 1 : 0);
						if (!flag6)
						{
							int stringLength = soundName._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v458 @ rdx_v8+10]");
							bool flag7 = (nint)stringLength != 0;
							num2 = num3;
							num4 = (ulong)(flag2 ? 1 : 0);
							if (!flag7)
							{
								ref byte second = ref *(byte*)("No Sound" + 20);
								num4 = (ulong)(soundName._stringLength + soundName._stringLength);
								bool flag8 = System.SpanHelpers.SequenceEqual(ref *(byte*)(soundGroupData.SoundName + 20), ref second, num4);
								flag5 = (flag8 ? 1 : 0) < (false ? 1 : 0);
								num2 = unchecked((nint)null);
								num3 = unchecked((nint)null);
								flag2 = (byte)num4 != 0;
								if (flag8)
								{
									goto IL_03e9;
								}
							}
						}
						bool flag9 = (nint)soundGroupData.Sounds < 0;
						bool flag10 = soundGroupData.Sounds == null;
						bool flag11 = flag3;
						if (!flag10)
						{
							List<AudioData> sounds = soundGroupData.Sounds;
							flag11 = (byte)(sounds._size - 1) != 0;
							flag2 = (byte)num4 != 0;
							bool flag12 = (byte)num4 != 0;
							bool flag13 = flag11;
							if (!flag9)
							{
								object obj4;
								do
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
									bool flag14 = (nint)obj3 < 0;
									if (obj3 == null)
									{
										flag14 = (nint)soundGroupData.Sounds < 0;
										soundGroupData.Sounds.RemoveAt(flag13 ? 1 : 0);
										flag12 = false;
									}
									flag11 = (byte)((flag13 ? 1u : 0u) - 1u) != 0;
									obj4 = !flag14;
									flag2 = flag12;
									flag13 = flag11;
								}
								while (obj4 != null);
							}
							List<AudioData> sounds2 = soundGroupData.Sounds;
							flag5 = sounds2._size < 0;
							bool flag15 = sounds2._size != 0;
							num3 = num2;
							flag3 = flag11;
							if (flag15)
							{
								goto IL_03e9;
							}
						}
						flag5 = (nint)Database < 0;
						Database.RemoveAt(num);
						num3 = num2;
						flag2 = false;
						flag3 = flag11;
					}
					goto IL_03e9;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
				IL_03e9:
				num--;
				obj5 = !flag5;
			}
			while (obj5 != null);
		}
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void RemoveDuplicateEntries(bool performUndo, bool saveAssets = false)
	{
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			DoozyUtils.UndoRecordObject(this, instance.RemovedDuplicateEntries);
		}
		Func<SoundGroupData, string> keySelector = _003C_003Ec._003C_003E9__17_0;
		if (_003C_003Ec._003C_003E9__17_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__17_0 = (SoundGroupData data) => (string)(((object)data != null) ? ((object)data.SoundName) : ((object)new NullReferenceException())));
		}
		IEnumerable<IGrouping<string, SoundGroupData>> source = Enumerable.GroupBy(Database, keySelector);
		Func<IGrouping<string, SoundGroupData>, SoundGroupData> selector = _003C_003Ec._003C_003E9__17_1;
		if (_003C_003Ec._003C_003E9__17_1 == null)
		{
			selector = (_003C_003Ec._003C_003E9__17_1 = (IGrouping<string, SoundGroupData> n) => Enumerable.First(n));
		}
		IEnumerable<SoundGroupData> enumerable = Enumerable.Select(source, selector);
		if (enumerable != null)
		{
			List<object> database = new List<object>(enumerable);
			Database = (List<SoundGroupData>)(object)database;
			DoozyUtils.SetDirty(this, saveAssets);
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public void RemoveUnnamedEntries(bool performUndo, bool saveAssets = false)
	{
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			DoozyUtils.UndoRecordObject(this, instance.RemoveEmptyEntries);
		}
		Func<SoundGroupData, bool> predicate = _003C_003Ec._003C_003E9__18_0;
		if (_003C_003Ec._003C_003E9__18_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__18_0 = delegate(SoundGroupData data)
			{
				//IL_00b2: Expected I4, but got O
				if ((object)data == null || data.SoundName == null)
				{
					NullReferenceException ex2 = new NullReferenceException();
					return (byte)(int)ex2 != 0;
				}
				string text = data.SoundName.TrimWhiteSpaceHelper(string.TrimType.Both);
				return (text != null && text._stringLength > 0) ? true : false;
			});
		}
		IEnumerable<SoundGroupData> enumerable = Enumerable.Where(Database, predicate);
		if (enumerable != null)
		{
			List<object> database = new List<object>(enumerable);
			Database = (List<SoundGroupData>)(object)database;
			DoozyUtils.SetDirty(this, saveAssets);
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public unsafe void Sort(bool performUndo, bool saveAssets = false)
	{
		//IL_0386: Expected I, but got O
		//IL_039c: Expected O, but got I
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_048c: Expected O, but got I4
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a1: Expected O, but got Unknown
		//IL_0100: Expected O, but got Ref
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			DoozyUtils.UndoRecordObject(this, instance.SortDatabase);
		}
		Func<SoundGroupData, string> keySelector = _003C_003Ec._003C_003E9__20_0;
		if (_003C_003Ec._003C_003E9__20_0 == null)
		{
			Func<SoundGroupData, string> func = (_003C_003Ec._003C_003E9__20_0 = (SoundGroupData data) => (string)(((object)data != null) ? ((object)data.SoundName) : ((object)new NullReferenceException())));
			nint num = (nint)typeof(_003C_003Ec);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ rax_v76 (Il2CppClass<Doozy.Engine.Soundy.SoundDatabase+<>c>)+B8]");
			object obj = (nint)0 + (nint)32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
			bool flag = (nint)0 == 0;
			keySelector = func;
			if (!flag)
			{
				object obj2 = obj >> 12;
				object obj3 = obj2 & 0x1FFFFF;
				object obj4 = obj3 >> 6;
				object obj5 = obj4 * 8;
				object obj6 = 6603577472L + obj5;
				object obj7 = obj3 & 0x3F;
				nint num3;
				do
				{
					object obj8 = 1 << (int)obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rdx_v28+462E0]");
					object obj9 = 0 | obj8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rdx_v28+462E0]");
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rdx_v28+462E0]");
					if (num2 == 0)
					{
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rdx_v28+462E0]");
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rdx_v28+462E0]");
				}
				while (num3 != 0);
				keySelector = func;
			}
		}
		IOrderedEnumerable<SoundGroupData> orderedEnumerable = Enumerable.OrderBy(Database, keySelector);
		if (orderedEnumerable != null)
		{
			List<object> database = new List<object>(orderedEnumerable);
			Database = (List<SoundGroupData>)(object)database;
			List<SoundGroupData>.Enumerator enumerator = default(List<SoundGroupData>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj10 = null;
				List<SoundGroupData>.Enumerator enumerator2 = (List<SoundGroupData>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			object obj11 = null;
			if (obj11 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v203 @ rdi_v9 (System.Object)+10]");
				if ((nint)0 != 0)
				{
					((List<object>)(object)Database).Insert(0, obj11);
				}
			}
			UpdateSoundNames(saveAssets: false);
			DoozyUtils.SetDirty(this, saveAssets);
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	public void UndoRecord(string undoMessage)
	{
		DoozyUtils.UndoRecordObject(this, undoMessage);
	}

	public unsafe void UpdateSoundNames(bool saveAssets)
	{
		//IL_0383: Expected O, but got Ref
		//IL_019c: Expected O, but got I4
		//IL_01a4: Expected O, but got Ref
		List<object> soundNames = (List<object>)(object)SoundNames;
		if (SoundNames != null)
		{
			int version = soundNames._version + 1;
			soundNames._version = version;
			soundNames._size = 0;
			if (soundNames._size > 0)
			{
				Array.Clear(soundNames._items, 0, soundNames._size);
			}
			soundNames = (List<object>)(object)SoundNames;
			if (SoundNames != null)
			{
				int version2 = soundNames._version + 1;
				soundNames._version = version2;
				object[] items = soundNames._items;
				if (soundNames._items != null)
				{
					if (soundNames._size >= items.Length)
					{
						((List<object>)(object)SoundNames).AddWithResize((object)"No Sound");
					}
					else
					{
						int size = soundNames._size + 1;
						soundNames._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					List<string> list = new List<string>();
					bool flag = Database == null;
					soundNames = (List<object>)(object)list;
					if (!flag)
					{
						List<SoundGroupData>.Enumerator enumerator = default(List<SoundGroupData>.Enumerator);
						if (enumerator.MoveNext())
						{
							object obj = 0;
							List<SoundGroupData>.Enumerator enumerator2 = (List<SoundGroupData>.Enumerator)(&enumerator);
							throw new NullReferenceException();
						}
						bool flag2 = list == null;
						soundNames = (List<object>)(&enumerator);
						if (!flag2)
						{
							((List<object>)(object)list).Sort();
							List<object> soundNames2 = (List<object>)(object)SoundNames;
							if (SoundNames != null)
							{
								((List<object>)(object)SoundNames).InsertRange(soundNames2._size, (IEnumerable<object>)list);
								DoozyUtils.SetDirty(this, saveAssets);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private bool AddNoSound(bool saveAssets = false)
	{
		//IL_022c: Expected I4, but got O
		//IL_01a0: Expected O, but got I4
		//IL_01d0: Expected O, but got I4
		if (!Contains("No Sound"))
		{
			if (SoundNames == null)
			{
				List<string> soundNames = new List<string>();
				SoundNames = soundNames;
			}
			List<object> soundNames2 = (List<object>)(object)SoundNames;
			if (SoundNames != null)
			{
				int version = soundNames2._version + 1;
				soundNames2._version = version;
				object[] items = soundNames2._items;
				if (soundNames2._items != null)
				{
					if (soundNames2._size >= items.Length)
					{
						((List<object>)(object)SoundNames).AddWithResize((object)"No Sound");
					}
					else
					{
						int size = soundNames2._size + 1;
						soundNames2._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					SoundGroupData soundGroupData = ScriptableObject.CreateInstance<SoundGroupData>();
					if ((object)soundGroupData != null)
					{
						soundGroupData.DatabaseName = DatabaseName;
						soundGroupData.SoundName = "No Sound";
						((UnityEngine.Object)soundGroupData).SetName(soundGroupData.SoundName);
						DoozyUtils.SetDirty(soundGroupData, saveAssets: false);
						bool flag = Database != null;
						object obj = 0;
						if (!flag)
						{
							List<SoundGroupData> database = new List<SoundGroupData>();
							Database = database;
							obj = 0;
						}
						if (Database != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049C2D0");
							DoozyUtils.SetDirty(this, saveAssets);
							return true;
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private void AddObjectToAsset(UnityEngine.Object objectToAdd)
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(DoozyUtils);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<Doozy.Engine.Utils.DoozyUtils>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private bool CheckAllDataForCorrectDatabaseName(bool saveAssets)
	{
		List<SoundGroupData> database = Database;
		bool result = false;
		List<SoundGroupData>.Enumerator enumerator = default(List<SoundGroupData>.Enumerator);
		while (enumerator.MoveNext())
		{
			SoundGroupData soundGroupData = null;
		}
		DoozyUtils.SetDirty(this, saveAssets);
		return result;
	}

	private void RemoveUnreferencedData(bool saveAssets = false)
	{
	}

	public SoundDatabase()
	{
		List<string> soundNames = new List<string>();
		SoundNames = soundNames;
		Database = new List<SoundGroupData>();
		base._002Ector();
	}
}
