using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Soundy;

[Serializable]
public class SoundyDatabase : ScriptableObject
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<SoundDatabase, bool> _003C_003E9__20_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CUpdateDatabaseNames_003Eb__20_0(SoundDatabase soundDatabase)
		{
			if ((object)soundDatabase != null)
			{
				bool flag = ((UnityEngine.Object)soundDatabase).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}
	}

	public List<string> DatabaseNames;

	public List<SoundDatabase> SoundDatabases;

	private static UILanguagePack UILabels => UILanguagePack.Instance;

	public bool AddSoundDatabase(SoundDatabase database, bool saveAssets)
	{
		//IL_0188: Expected I4, but got O
		if ((object)database != null && ((UnityEngine.Object)database).m_CachedPtr != (IntPtr)0)
		{
			if (SoundDatabases == null)
			{
				List<SoundDatabase> soundDatabases = new List<SoundDatabase>();
				SoundDatabases = soundDatabases;
			}
			List<object> soundDatabases2 = (List<object>)(object)SoundDatabases;
			if (SoundDatabases != null)
			{
				int version = soundDatabases2._version + 1;
				soundDatabases2._version = version;
				object[] items = soundDatabases2._items;
				if (soundDatabases2._items != null)
				{
					if (soundDatabases2._size >= items.Length)
					{
						((List<object>)(object)SoundDatabases).AddWithResize((object)database);
					}
					else
					{
						int size = soundDatabases2._size + 1;
						soundDatabases2._size = size;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					}
					UpdateDatabaseNames();
					DoozyUtils.SetDirty(this, saveAssets);
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public bool Contains(string databaseName)
	{
		//IL_0014: Expected O, but got I4
		//IL_0022: Expected O, but got I4
		//IL_0183: Expected O, but got I4
		if (SoundDatabases != null)
		{
			object obj = 0;
			List<SoundDatabase>.Enumerator enumerator = default(List<SoundDatabase>.Enumerator);
			while (enumerator.MoveNext())
			{
				object obj2 = 0;
				obj = 1;
			}
			bool result = false;
			if (obj != null)
			{
				RemoveNullDatabases();
			}
			return result;
		}
		List<SoundDatabase> soundDatabases = new List<SoundDatabase>();
		SoundDatabases = soundDatabases;
		return false;
	}

	public bool Contains(string databaseName, string soundName)
	{
		//IL_0070: Expected I4, but got O
		bool flag = Contains(databaseName);
		if (!flag)
		{
			return flag;
		}
		SoundDatabase soundDatabase = GetSoundDatabase(databaseName);
		if ((object)soundDatabase != null)
		{
			return soundDatabase.Contains(soundName);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool CreateSoundDatabase(string databaseName, bool showDialog = false, bool saveAssets = false)
	{
		//IL_011f: Expected I4, but got O
		string dataPath = DoozyPath.GetDataPath(DoozyPath.ComponentName.Soundy);
		if (databaseName != null)
		{
			string text = databaseName.TrimWhiteSpaceHelper(string.TrimType.Both);
			if (text == null || text._stringLength <= 0 || Contains(text))
			{
				return false;
			}
			SoundDatabase soundDatabase = ScriptableObject.CreateInstance<SoundDatabase>();
			if ((object)soundDatabase != null)
			{
				soundDatabase.DatabaseName = text;
				soundDatabase.RefreshDatabase(performUndo: false, saveAssets: false);
				bool flag = AddSoundDatabase(soundDatabase, saveAssets: false);
				SetDirty(saveAssets);
				return true;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool CreateSoundDatabase(string relativePath, string databaseName, bool showDialog = false, bool saveAssets = false)
	{
		//IL_00fc: Expected I4, but got O
		if (databaseName != null)
		{
			string text = databaseName.TrimWhiteSpaceHelper(string.TrimType.Both);
			if (text == null || text._stringLength <= 0 || Contains(text))
			{
				return false;
			}
			SoundDatabase soundDatabase = ScriptableObject.CreateInstance<SoundDatabase>();
			if ((object)soundDatabase != null)
			{
				soundDatabase.DatabaseName = text;
				soundDatabase.RefreshDatabase(performUndo: false, saveAssets: false);
				bool flag = AddSoundDatabase(soundDatabase, saveAssets: false);
				bool dirty = default(bool);
				SetDirty(dirty);
				return true;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public bool DeleteDatabase(SoundDatabase database)
	{
		if ((object)database != null)
		{
			bool flag = ((UnityEngine.Object)database).m_CachedPtr == (IntPtr)0;
			return !flag;
		}
		return false;
	}

	public SoundGroupData GetAudioData(string databaseName, string soundName)
	{
		if (!Contains(databaseName))
		{
			return null;
		}
		SoundDatabase soundDatabase = GetSoundDatabase(databaseName);
		if ((object)soundDatabase != null)
		{
			return soundDatabase.GetData(soundName);
		}
		return (SoundGroupData)(object)new NullReferenceException();
	}

	public SoundDatabase GetSoundDatabase(string databaseName)
	{
		List<SoundDatabase>.Enumerator enumerator = default(List<SoundDatabase>.Enumerator);
		if (SoundDatabases == null)
		{
			List<SoundDatabase> soundDatabases = new List<SoundDatabase>();
			SoundDatabases = soundDatabases;
		}
		else if (enumerator.MoveNext())
		{
			SoundDatabase soundDatabase = null;
			throw new NullReferenceException();
		}
		return null;
	}

	public void Initialize()
	{
		RemoveNullDatabases();
		if (!Contains("General"))
		{
			SoundDatabase soundDatabase = ScriptableObject.CreateInstance<SoundDatabase>();
			bool flag = AddSoundDatabase(soundDatabase, saveAssets: true);
			soundDatabase.DatabaseName = "General";
			soundDatabase.RefreshDatabase(performUndo: false, saveAssets: true);
			UpdateDatabaseNames(saveAssets: true);
		}
	}

	public void InitializeSoundDatabases()
	{
		//IL_002b: Expected O, but got I4
		//IL_0034: Expected O, but got I4
		//IL_0123: Expected O, but got I4
		//IL_0210: Expected O, but got I4
		bool flag = (nint)SoundDatabases < 0;
		if (SoundDatabases == null)
		{
			return;
		}
		List<SoundDatabase> soundDatabases = SoundDatabases;
		int num = soundDatabases._size - 1;
		object obj = 0;
		object obj2 = 0;
		if (!flag)
		{
			object obj3;
			do
			{
				List<SoundDatabase> soundDatabases2 = SoundDatabases;
				bool flag2;
				if (num < soundDatabases2._size)
				{
					SoundDatabase[] items = soundDatabases2._items;
					SoundDatabase soundDatabase = items[num];
					if ((object)items[num] != null)
					{
						flag2 = (nint)((UnityEngine.Object)soundDatabase).m_CachedPtr < 0;
						if (((UnityEngine.Object)soundDatabase).m_CachedPtr != (IntPtr)0)
						{
							items[num].RefreshDatabase(performUndo: false, saveAssets: false);
							goto IL_01f7;
						}
					}
					flag2 = (nint)SoundDatabases < 0;
					SoundDatabases.RemoveAt(num);
					obj2 = 1;
					goto IL_01f7;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
				IL_01f7:
				num--;
				obj3 = !flag2;
				obj = obj2;
			}
			while (obj3 != null);
		}
		List<SoundDatabase> soundDatabases3 = SoundDatabases;
		if (soundDatabases3._size != 0)
		{
			if (obj != null)
			{
				DoozyUtils.SetDirty(this, saveAssets: false);
			}
		}
		else
		{
			Initialize();
		}
	}

	public void RefreshDatabase(bool performUndo = true, bool saveAssets = false)
	{
		if (performUndo)
		{
			UILanguagePack instance = UILanguagePack.Instance;
			if ((object)instance == null)
			{
				goto IL_009e;
			}
			DoozyUtils.UndoRecordObject(this, instance.RefreshDatabase);
		}
		Initialize();
		if (SoundDatabases != null)
		{
			List<SoundDatabase>.Enumerator enumerator = default(List<SoundDatabase>.Enumerator);
			if (enumerator.MoveNext())
			{
				SoundDatabase soundDatabase = null;
				throw new NullReferenceException();
			}
			DoozyUtils.SetDirty(this, saveAssets);
			return;
		}
		goto IL_009e;
		IL_009e:
		throw new NullReferenceException();
	}

	public void RemoveNullDatabases(bool saveAssets = false)
	{
		//IL_01e0: Expected O, but got I4
		if (SoundDatabases == null)
		{
			List<SoundDatabase> soundDatabases = new List<SoundDatabase>();
			SoundDatabases = soundDatabases;
			DoozyUtils.SetDirty(this, saveAssets: false);
		}
		List<SoundDatabase> soundDatabases2 = SoundDatabases;
		bool flag = (nint)SoundDatabases < 0;
		bool flag2 = SoundDatabases == null;
		int num = soundDatabases2._size - 1;
		if (!flag)
		{
			object obj;
			do
			{
				List<SoundDatabase> soundDatabases3 = SoundDatabases;
				bool flag3;
				if (num < soundDatabases3._size)
				{
					SoundDatabase[] items = soundDatabases3._items;
					SoundDatabase soundDatabase = items[num];
					if ((object)items[num] != null)
					{
						flag3 = (nint)((UnityEngine.Object)soundDatabase).m_CachedPtr < 0;
						flag2 = ((UnityEngine.Object)soundDatabase).m_CachedPtr == (IntPtr)0;
						if (((UnityEngine.Object)soundDatabase).m_CachedPtr != (IntPtr)0)
						{
							goto IL_01c7;
						}
					}
					flag3 = (nint)SoundDatabases < 0;
					flag2 = SoundDatabases == null;
					SoundDatabases.RemoveAt(num);
					goto IL_01c7;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
				IL_01c7:
				num--;
				obj = !flag3;
			}
			while (obj != null);
		}
		UpdateDatabaseNames();
		if (!flag2)
		{
			DoozyUtils.SetDirty(this, saveAssets);
		}
	}

	public bool RenameSoundDatabase(SoundDatabase soundDatabase, string newDatabaseName)
	{
		//IL_007f: Expected I4, but got O
		if ((object)soundDatabase != null && ((UnityEngine.Object)soundDatabase).m_CachedPtr != (IntPtr)0)
		{
			if (newDatabaseName != null)
			{
				string text = newDatabaseName.TrimWhiteSpaceHelper(string.TrimType.Both);
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public void SearchForUnregisteredDatabases(bool saveAssets)
	{
		//IL_006d: Expected O, but got I4
		//IL_0076: Expected O, but got I4
		//IL_012a: Expected O, but got I4
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		SoundDatabase[] array = Resources.LoadAll<SoundDatabase>("");
		if (array == null || array.Length == 0)
		{
			return;
		}
		if (SoundDatabases == null)
		{
			List<SoundDatabase> soundDatabases = new List<SoundDatabase>();
			SoundDatabases = soundDatabases;
		}
		object obj = 0;
		nint num2 = default(nint);
		nint num3;
		for (object obj2 = 0; (nint)obj2 < array.Length; obj2++, num2 = num3)
		{
			List<SoundDatabase> soundDatabases2 = SoundDatabases;
			if (soundDatabases2._size != 0)
			{
				int num = Array.IndexOf((object[])soundDatabases2._items, (object)array[obj2], 0, soundDatabases2._size);
				bool flag = num != -1;
				num2 = 0;
				num3 = 0;
				if (flag)
				{
					continue;
				}
			}
			bool flag2 = AddSoundDatabase(array[obj2], saveAssets: false);
			obj = 1;
			num3 = num2;
		}
		if (obj != null)
		{
			UpdateDatabaseNames();
			DoozyUtils.SetDirty(this, saveAssets);
		}
	}

	public void SetDirty(bool saveAssets)
	{
		DoozyUtils.SetDirty(this, saveAssets);
	}

	public void UndoRecord(string undoMessage)
	{
		DoozyUtils.UndoRecordObject(this, undoMessage);
	}

	public void UpdateDatabaseNames(bool saveAssets = false)
	{
		//IL_0118: Expected O, but got I4
		//IL_0126: Expected O, but got I4
		//IL_01a3: Expected O, but got I4
		if (DatabaseNames == null)
		{
			List<string> databaseNames = new List<string>();
			DatabaseNames = databaseNames;
		}
		if (SoundDatabases == null)
		{
			List<SoundDatabase> soundDatabases = new List<SoundDatabase>();
			SoundDatabases = soundDatabases;
		}
		List<object> databaseNames2 = (List<object>)(object)DatabaseNames;
		if (DatabaseNames != null)
		{
			int version = databaseNames2._version + 1;
			databaseNames2._version = version;
			databaseNames2._size = 0;
			if (databaseNames2._size > 0)
			{
				Array.Clear(databaseNames2._items, 0, databaseNames2._size);
				databaseNames2 = (List<object>)(object)databaseNames2._items;
			}
			if (SoundDatabases != null)
			{
				object obj = 0;
				List<SoundDatabase>.Enumerator enumerator = default(List<SoundDatabase>.Enumerator);
				while (enumerator.MoveNext())
				{
					object obj2 = 0;
					obj = 1;
				}
				if (DatabaseNames != null)
				{
					((List<object>)(object)DatabaseNames).Sort();
					if (obj != null)
					{
						Func<SoundDatabase, bool> predicate = _003C_003Ec._003C_003E9__20_0;
						if (_003C_003Ec._003C_003E9__20_0 == null)
						{
							predicate = (_003C_003Ec._003C_003E9__20_0 = delegate(SoundDatabase soundDatabase)
							{
								if ((object)soundDatabase != null)
								{
									bool flag = ((UnityEngine.Object)soundDatabase).m_CachedPtr == (IntPtr)0;
									return !flag;
								}
								return false;
							});
						}
						IEnumerable<SoundDatabase> enumerable = Enumerable.Where(SoundDatabases, predicate);
						if (enumerable == null)
						{
							Exception ex = System.Linq.Error.ArgumentNull("source");
							throw ex;
						}
						List<object> soundDatabases2 = new List<object>(enumerable);
						SoundDatabases = (List<SoundDatabase>)(object)soundDatabases2;
						DoozyUtils.SetDirty(this, saveAssets: false);
					}
					DoozyUtils.SetDirty(this, saveAssets);
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	public SoundyDatabase()
	{
		List<string> databaseNames = new List<string>();
		DatabaseNames = databaseNames;
		SoundDatabases = new List<SoundDatabase>();
		base._002Ector();
	}
}
