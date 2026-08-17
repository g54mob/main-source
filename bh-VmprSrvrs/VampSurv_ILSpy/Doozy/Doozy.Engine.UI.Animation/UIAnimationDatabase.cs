using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.UI.Animation;

[Serializable]
public class UIAnimationDatabase : ScriptableObject
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<UIAnimationData, bool> _003C_003E9__15_0;

		public static Func<UIAnimationData, string> _003C_003E9__17_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CRemoveNullEntries_003Eb__15_0(UIAnimationData data)
		{
			if ((object)data != null)
			{
				bool flag = ((UnityEngine.Object)data).m_CachedPtr == (IntPtr)0;
				return !flag;
			}
			return false;
		}

		internal string _003CSort_003Eb__17_0(UIAnimationData data)
		{
			if ((object)data != null)
			{
				return data.Name;
			}
			return (string)(object)new NullReferenceException();
		}
	}

	public List<string> AnimationNames;

	public List<UIAnimationData> Database;

	public string DatabaseName;

	public AnimationType DataType;

	private static UILanguagePack UILabels => UILanguagePack.Instance;

	public bool Add(UIAnimation animation, string animationName, bool saveAssets = true)
	{
		//IL_0214: Expected I4, but got O
		if (animationName != null)
		{
			string animationName2 = animationName.TrimWhiteSpaceHelper(string.TrimType.Both);
			if (Contains(animationName2))
			{
				return false;
			}
			UILanguagePack instance = UILanguagePack.Instance;
			if ((object)instance != null)
			{
				DoozyUtils.UndoRecordObject(this, instance.CreateAnimation);
				UIAnimationData uIAnimationData = ScriptableObject.CreateInstance<UIAnimationData>();
				if ((object)uIAnimationData != null)
				{
					uIAnimationData.Category = DatabaseName;
					uIAnimationData.Name = animationName2;
					((UnityEngine.Object)uIAnimationData).SetName(uIAnimationData.Name);
					uIAnimationData.Animation = animation;
					List<object> database = (List<object>)(object)Database;
					if (Database != null)
					{
						int version = database._version + 1;
						database._version = version;
						object[] items = database._items;
						if (database._items != null)
						{
							if (database._size >= items.Length)
							{
								((List<object>)(object)Database).AddWithResize((object)uIAnimationData);
							}
							else
							{
								int size = database._size + 1;
								database._size = size;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							}
							DoozyUtils.SetDirty(uIAnimationData, saveAssets: false);
							RefreshDatabase(saveAssets: false);
							DoozyUtils.SetDirty(this, saveAssets);
							return true;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public UIAnimationData AddDefaultData(bool saveAssets)
	{
		if (!Contains("Default"))
		{
			UIAnimationData uIAnimationData = ScriptableObject.CreateInstance<UIAnimationData>();
			if ((object)uIAnimationData != null)
			{
				uIAnimationData.Category = DatabaseName;
				uIAnimationData.Name = "Default";
				((UnityEngine.Object)uIAnimationData).SetName(uIAnimationData.Name);
				UIAnimation uIAnimation = null;
				uIAnimation.Reset(DataType);
				uIAnimationData.Animation = uIAnimation;
				DoozyUtils.SetDirty(uIAnimationData, saveAssets: false);
				DoozyUtils.SetDirty(this, saveAssets);
				return uIAnimationData;
			}
			return (UIAnimationData)(object)new NullReferenceException();
		}
		return Get("Default");
	}

	public bool Contains(string animationName)
	{
		//IL_0086: Expected I4, but got O
		UIAnimationData uIAnimationData = Get(animationName);
		if ((object)uIAnimationData != null && ((UnityEngine.Object)uIAnimationData).m_CachedPtr != (IntPtr)0)
		{
			if (Database != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B490");
				bool result = default(bool);
				return result;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public bool Contains(UIAnimationData data)
	{
		//IL_0078: Expected I4, but got O
		if ((object)data != null && ((UnityEngine.Object)data).m_CachedPtr != (IntPtr)0)
		{
			if (Database != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B490");
				bool result = default(bool);
				return result;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	public void CreatePreset(string newPresetName, UIAnimation animation, bool saveAssets = true)
	{
		UIAnimation animation2 = animation.Copy();
		bool flag = Add(animation2, newPresetName, saveAssets);
	}

	public bool Delete(string animationName, bool saveAssets)
	{
		//IL_0103: Expected I4, but got O
		UIAnimationData uIAnimationData = Get(animationName);
		if ((object)uIAnimationData != null && ((UnityEngine.Object)uIAnimationData).m_CachedPtr != (IntPtr)0)
		{
			if (Database != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B490");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_00ef;
				}
				if (Database != null)
				{
					bool flag = ((List<object>)(object)Database).Remove((object)uIAnimationData);
					UnityEngine.Object.DestroyImmediate(uIAnimationData, allowDestroyingAssets: true);
					RefreshDatabase(saveAssets: false);
					SetDirty(saveAssets);
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		goto IL_00ef;
		IL_00ef:
		return false;
	}

	public bool Delete(UIAnimationData data, bool saveAssets)
	{
		//IL_00f5: Expected I4, but got O
		if ((object)data != null && ((UnityEngine.Object)data).m_CachedPtr != (IntPtr)0)
		{
			if (Database != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049B490");
				object obj = default(object);
				if (obj == null)
				{
					goto IL_00e1;
				}
				if (Database != null)
				{
					bool flag = ((List<object>)(object)Database).Remove((object)data);
					UnityEngine.Object.DestroyImmediate(data, allowDestroyingAssets: true);
					RefreshDatabase(saveAssets: false);
					SetDirty(saveAssets);
					return true;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		goto IL_00e1;
		IL_00e1:
		return false;
	}

	public unsafe UIAnimationData Get(string animationName)
	{
		//IL_0017: Expected O, but got Ref
		List<UIAnimationData>.Enumerator enumerator = default(List<UIAnimationData>.Enumerator);
		if (enumerator.MoveNext())
		{
			UIAnimationData uIAnimationData = null;
			List<UIAnimationData>.Enumerator enumerator2 = (List<UIAnimationData>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
		return null;
	}

	public unsafe void RefreshDatabase(bool saveAssets)
	{
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected Ref, but got Unknown
		//IL_00ac: Expected I8, but got I4
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected Ref, but got Unknown
		RemoveNullEntries(saveAssets: false);
		RenameAssetFileNamesToReflectAnimationNames();
		Sort(saveAssets: false);
		string databaseName = DatabaseName;
		object obj = "Uncategorized";
		if ((object)DatabaseName == "Uncategorized")
		{
			goto IL_00ea;
		}
		if ("Uncategorized" != null)
		{
			int stringLength = databaseName._stringLength;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rdx_v5+10]");
			if ((nint)stringLength == 0)
			{
				ref byte second = ref *(byte*)("Uncategorized" + 20);
				ulong length = (ulong)(databaseName._stringLength + databaseName._stringLength);
				if (System.SpanHelpers.SequenceEqual(ref *(byte*)(DatabaseName + 20), ref second, length))
				{
					goto IL_00ea;
				}
			}
		}
		goto IL_012f;
		IL_012f:
		UpdateAnimationNames(saveAssets);
		return;
		IL_00ea:
		UIAnimationData item = AddDefaultData(saveAssets: true);
		bool flag = ((List<object>)(object)Database).Remove((object)item);
		((List<object>)(object)Database).Insert(0, (object)item);
		goto IL_012f;
	}

	public void RemoveNullEntries(bool saveAssets)
	{
		Func<UIAnimationData, bool> predicate = _003C_003Ec._003C_003E9__15_0;
		if (_003C_003Ec._003C_003E9__15_0 == null)
		{
			predicate = (_003C_003Ec._003C_003E9__15_0 = delegate(UIAnimationData data)
			{
				if ((object)data != null)
				{
					bool flag = ((UnityEngine.Object)data).m_CachedPtr == (IntPtr)0;
					return !flag;
				}
				return false;
			});
		}
		IEnumerable<UIAnimationData> enumerable = Enumerable.Where(Database, predicate);
		if (enumerable != null)
		{
			List<object> database = new List<object>(enumerable);
			Database = (List<UIAnimationData>)(object)database;
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

	public void Sort(bool saveAssets)
	{
		Func<UIAnimationData, string> keySelector = _003C_003Ec._003C_003E9__17_0;
		if (_003C_003Ec._003C_003E9__17_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__17_0 = (UIAnimationData data) => (string)(((object)data != null) ? ((object)data.Name) : ((object)new NullReferenceException())));
		}
		IOrderedEnumerable<UIAnimationData> orderedEnumerable = Enumerable.OrderBy(Database, keySelector);
		if (orderedEnumerable != null)
		{
			List<object> database = new List<object>(orderedEnumerable);
			Database = (List<UIAnimationData>)(object)database;
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

	private void UpdateAnimationNames(bool saveAssets)
	{
		//IL_0074: Expected O, but got I
		//IL_0096: Expected O, but got I
		//IL_00da: Expected O, but got I4
		if (AnimationNames == null)
		{
			List<string> animationNames = new List<string>();
			AnimationNames = animationNames;
		}
		Array array = (Array)(object)AnimationNames;
		bool flag = AnimationNames == null;
		List<object> animationNames2 = (List<object>)(object)AnimationNames;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v8 (System.Array)+1C]");
			_ = (nint)0 + (nint)1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v8 (System.Array)+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v8 (System.Array)+10]");
				array = (Array)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v8 (System.Array)+10]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rcx_v8 (System.Array)+18]");
				Array.Clear((Array)num, 0, 0);
			}
			bool flag2 = Database == null;
			animationNames2 = (List<object>)(object)array;
			if (!flag2)
			{
				List<UIAnimationData>.Enumerator enumerator = default(List<UIAnimationData>.Enumerator);
				if (enumerator.MoveNext())
				{
					animationNames2 = (List<object>)(object)AnimationNames;
					object obj = 0;
					throw new NullReferenceException();
				}
				DoozyUtils.SetDirty(this, saveAssets);
				return;
			}
		}
		throw new NullReferenceException();
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

	private void Rename(string oldAnimationName, string newAnimationName)
	{
		UIAnimationData uIAnimationData = Get(oldAnimationName);
		if ((object)uIAnimationData == null || ((UnityEngine.Object)uIAnimationData).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		string animationName = newAnimationName.TrimWhiteSpaceHelper(string.TrimType.Both);
		if (Contains(animationName))
		{
			return;
		}
		UnityEngine.Object[] array = new UnityEngine.Object[2];
		object obj = array;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		object obj2 = default(object);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			if ((object)this != null)
			{
				object obj3 = array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				object obj4 = default(object);
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			UILanguagePack instance = UILanguagePack.Instance;
			uIAnimationData.Name = animationName;
			((UnityEngine.Object)uIAnimationData).SetName(uIAnimationData.Name);
			uIAnimationData.SetDirty(saveAssets: false);
			SetDirty(saveAssets: false);
			UpdateAnimationNames(saveAssets: true);
			return;
		}
		ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
		throw ex2;
	}

	private void RenameAssetFileNamesToReflectAnimationNames()
	{
		//IL_0013: Expected O, but got I4
		List<UIAnimationData> database = Database;
		object obj = 0;
		List<UIAnimationData>.Enumerator enumerator = default(List<UIAnimationData>.Enumerator);
		while (enumerator.MoveNext())
		{
			UnityEngine.Object obj2 = null;
		}
		if (obj != null)
		{
			DoozyUtils.SetDirty(this, saveAssets: true);
		}
	}

	public UIAnimationDatabase()
	{
		List<string> animationNames = new List<string>();
		AnimationNames = animationNames;
		Database = new List<UIAnimationData>();
		base._002Ector();
	}
}
