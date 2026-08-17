using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.UI.Animation;

[Serializable]
public class UIAnimationsDatabase
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<UIAnimationDatabase, string> _003C_003E9__13_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal string _003CSort_003Eb__13_0(UIAnimationDatabase database)
		{
			if ((object)database != null)
			{
				return database.DatabaseName;
			}
			return (string)(object)new NullReferenceException();
		}
	}

	public List<string> DatabaseNames;

	public AnimationType DatabaseType;

	public List<UIAnimationDatabase> Databases;

	public UIAnimationsDatabase(AnimationType animationType)
	{
		DatabaseType = animationType;
		List<UIAnimationDatabase> databases = new List<UIAnimationDatabase>();
		Databases = databases;
		List<string> databaseNames = new List<string>();
		DatabaseNames = databaseNames;
	}

	public bool AddUIAnimationDatabase(UIAnimationDatabase database)
	{
		//IL_00bb: Expected I4, but got O
		if ((object)database != null && ((UnityEngine.Object)database).m_CachedPtr != (IntPtr)0 && database.DataType == DatabaseType && !Contains(database))
		{
			if (Databases != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B500");
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public bool Contains(string databaseName)
	{
		UIAnimationDatabase uIAnimationDatabase = Get(databaseName);
		if ((object)uIAnimationDatabase != null)
		{
			bool flag = ((UnityEngine.Object)uIAnimationDatabase).m_CachedPtr == (IntPtr)0;
			return !flag;
		}
		return false;
	}

	public bool Contains(UIAnimationDatabase database)
	{
		//IL_00e6: Expected I4, but got O
		//IL_00b3: Expected O, but got I4
		if ((object)database != null && ((UnityEngine.Object)database).m_CachedPtr != (IntPtr)0)
		{
			List<UIAnimationDatabase> databases = Databases;
			if (Databases == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			if (databases._size != 0)
			{
				int num = Array.IndexOf((object[])databases._items, (object)database, 0, databases._size);
				object obj = num - -1;
				bool flag = obj == null;
				return !flag;
			}
		}
		return false;
	}

	public unsafe UIAnimationDatabase Get(string databaseName)
	{
		//IL_0017: Expected O, but got Ref
		List<UIAnimationDatabase>.Enumerator enumerator = default(List<UIAnimationDatabase>.Enumerator);
		if (enumerator.MoveNext())
		{
			UIAnimationDatabase uIAnimationDatabase = null;
			List<UIAnimationDatabase>.Enumerator enumerator2 = (List<UIAnimationDatabase>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public void Update()
	{
		RemoveEmptyDatabases();
		AddTheDefaultUIAnimationDatabase();
		RenameAssetFileNamesToReflectDatabaseNames();
		Sort();
		UpdateDatabaseNames();
		UpdateDatabases();
	}

	private void AddTheDefaultUIAnimationDatabase()
	{
		UIAnimationDatabase uIAnimationDatabase = Get("Uncategorized");
		if ((object)uIAnimationDatabase == null || ((UnityEngine.Object)uIAnimationDatabase).m_CachedPtr == (IntPtr)0)
		{
			UIAnimationDatabase uIAnimationDatabase2 = ScriptableObject.CreateInstance<UIAnimationDatabase>();
			if ((object)uIAnimationDatabase2 != null && ((UnityEngine.Object)uIAnimationDatabase2).m_CachedPtr != (IntPtr)0)
			{
				uIAnimationDatabase2.DatabaseName = "Uncategorized";
				((UnityEngine.Object)uIAnimationDatabase2).SetName(uIAnimationDatabase2.DatabaseName);
				uIAnimationDatabase2.DataType = DatabaseType;
				uIAnimationDatabase2.RefreshDatabase(saveAssets: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B500");
			}
		}
	}

	private void AddUnreferencedPresets()
	{
	}

	private void RenameAssetFileNamesToReflectDatabaseNames()
	{
		List<UIAnimationDatabase> databases = Databases;
		List<UIAnimationDatabase>.Enumerator enumerator = default(List<UIAnimationDatabase>.Enumerator);
		while (enumerator.MoveNext())
		{
			UnityEngine.Object obj = null;
		}
	}

	private void RemoveEmptyDatabases()
	{
		//IL_0171: Expected O, but got I4
		List<UIAnimationDatabase> databases = Databases;
		bool flag = (nint)Databases < 0;
		int num = databases._size - 1;
		if (flag)
		{
			return;
		}
		while (true)
		{
			List<UIAnimationDatabase> databases2 = Databases;
			if (num >= databases2._size)
			{
				break;
			}
			UIAnimationDatabase[] items = databases2._items;
			UIAnimationDatabase uIAnimationDatabase = items[num];
			bool flag2;
			if ((object)items[num] != null && ((UnityEngine.Object)uIAnimationDatabase).m_CachedPtr != (IntPtr)0 && ((UnityEngine.Object)uIAnimationDatabase).m_CachedPtr != (IntPtr)0)
			{
				List<UIAnimationData> database = uIAnimationDatabase.Database;
				flag2 = database._size < 0;
				if (database._size > 0)
				{
					goto IL_0158;
				}
			}
			flag2 = (nint)Databases < 0;
			Databases.RemoveAt(num);
			goto IL_0158;
			IL_0158:
			num--;
			object obj = !flag2;
			if (obj == null)
			{
				return;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void Sort()
	{
		Func<UIAnimationDatabase, string> keySelector = _003C_003Ec._003C_003E9__13_0;
		if (_003C_003Ec._003C_003E9__13_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__13_0 = (UIAnimationDatabase database) => (string)(((object)database != null) ? ((object)database.DatabaseName) : ((object)new NullReferenceException())));
		}
		IOrderedEnumerable<UIAnimationDatabase> orderedEnumerable = Enumerable.OrderBy(Databases, keySelector);
		if (orderedEnumerable != null)
		{
			List<object> databases = new List<object>(orderedEnumerable);
			Databases = (List<UIAnimationDatabase>)(object)databases;
			return;
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private void UpdateDatabaseNames()
	{
		//IL_00af: Expected O, but got I4
		if (DatabaseNames == null)
		{
			List<string> databaseNames = new List<string>();
			DatabaseNames = databaseNames;
		}
		List<string> databaseNames2 = DatabaseNames;
		int version = databaseNames2._version + 1;
		databaseNames2._version = version;
		databaseNames2._size = 0;
		if (databaseNames2._size > 0)
		{
			Array.Clear(databaseNames2._items, 0, databaseNames2._size);
		}
		List<UIAnimationDatabase>.Enumerator enumerator = default(List<UIAnimationDatabase>.Enumerator);
		if (enumerator.MoveNext())
		{
			List<object> databaseNames3 = (List<object>)(object)DatabaseNames;
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	private void UpdateDatabases()
	{
		List<UIAnimationDatabase>.Enumerator enumerator = default(List<UIAnimationDatabase>.Enumerator);
		if (!enumerator.MoveNext())
		{
			return;
		}
		throw new NullReferenceException();
	}
}
