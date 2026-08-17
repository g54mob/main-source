using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using VampireSurvivors.Framework.DLC.Types;
using VampireSurvivors.Graphics;

namespace VampireSurvivors.Framework.Loading;

public static class AddressableCache
{
	private static readonly List<AsyncOperationHandle> PersistentOperationHandles;

	private static readonly Dictionary<AssetReference, AsyncOperationHandle> DynamicOperationHandles;

	private static readonly Dictionary<IResourceLocation, AsyncOperationHandle> DynamicLocationOperationHandles;

	private static readonly Dictionary<string, Dictionary<string, AsyncOperationHandle>> CustomOperationHandles;

	private static readonly Dictionary<string, List<string>> TextureCache;

	public static List<AsyncOperationHandle> GetPersistentOperationHandles()
	{
		return PersistentOperationHandles;
	}

	public static Dictionary<AssetReference, AsyncOperationHandle> GetDynamicOperationHandles()
	{
		return DynamicOperationHandles;
	}

	public static Dictionary<IResourceLocation, AsyncOperationHandle> GetDynamicLocationOperationHandles()
	{
		return DynamicLocationOperationHandles;
	}

	public static Dictionary<string, Dictionary<string, AsyncOperationHandle>> GetCustomOperationHandles()
	{
		return CustomOperationHandles;
	}

	public static void ReleaseAll()
	{
		ReleaseAllCustomOperationHandles();
		ReleaseDynamicOperationHandles();
		ReleasePersistentOperationHandles();
	}

	public unsafe static void ReleaseAllCustomOperationHandles()
	{
		//IL_0031: Expected O, but got Ref
		if (CustomOperationHandles != null)
		{
			Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
			if (enumerator.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				Dictionary<string, AsyncOperationHandle> dictionary = (Dictionary<string, AsyncOperationHandle>)(&enumerator);
				throw new NullReferenceException();
			}
			if (CustomOperationHandles != null)
			{
				CustomOperationHandles.Clear();
				return;
			}
		}
		throw new NullReferenceException();
	}

	public static void ReleaseCustomOperationHandleGroups(List<string> groupNames)
	{
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		while (enumerator.MoveNext())
		{
			ReleaseCustomOperationHandleGroup(null);
		}
	}

	public static void ReleaseCustomOperationHandleGroup(string groupName)
	{
		bool flag = CustomOperationHandles == null;
		int num = CustomOperationHandles.FindEntry(groupName);
		if (flag)
		{
			return;
		}
		Dictionary<string, AsyncOperationHandle> dictionary = CustomOperationHandles.get_Item(groupName);
		Dictionary<string, AsyncOperationHandle>.Enumerator enumerator = default(Dictionary<string, AsyncOperationHandle>.Enumerator);
		object obj = default(object);
		object obj2 = default(object);
		object obj3 = default(object);
		while (enumerator.MoveNext())
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj2 == obj3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					continue;
				}
			}
			Exception ex = new Exception("Attempting to use an invalid operation handle");
			ex._002Ector("Attempting to use an invalid operation handle");
			throw ex;
		}
		dictionary.Clear();
		bool flag2 = ((Dictionary<object, object>)(object)CustomOperationHandles).Remove((object)groupName);
		AudioLoader.ReleaseCachedGroup(groupName);
	}

	public unsafe static void ReleaseCustomOperationHandleGroupExcludingKeys(string groupName, List<string> excludedKeys)
	{
		//IL_008a: Expected O, but got Ref
		bool flag = CustomOperationHandles == null;
		if (!flag)
		{
			int num = CustomOperationHandles.FindEntry(groupName);
			if (flag)
			{
				return;
			}
			List<string> list = new List<string>();
			if (CustomOperationHandles != null)
			{
				Dictionary<string, AsyncOperationHandle> dictionary = CustomOperationHandles.get_Item(groupName);
				if (dictionary != null)
				{
					Dictionary<string, AsyncOperationHandle>.Enumerator enumerator = default(Dictionary<string, AsyncOperationHandle>.Enumerator);
					AsyncOperationHandle asyncOperationHandle = default(AsyncOperationHandle);
					while (enumerator.MoveNext())
					{
						bool flag2 = excludedKeys == null;
						Dictionary<string, AsyncOperationHandle>.Enumerator enumerator2 = (Dictionary<string, AsyncOperationHandle>.Enumerator)(&enumerator);
						if (!flag2)
						{
							object obj;
							if (excludedKeys._size != 0)
							{
								int num2 = Array.IndexOf((object[])excludedKeys._items, (object)null, 0, excludedKeys._size);
								if (num2 != -1)
								{
									continue;
								}
								obj = null;
							}
							else
							{
								obj = null;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm6,xmm6\"");
							asyncOperationHandle.Release();
							if (list != null)
							{
								list.Add((string)obj);
								AudioLoader.ReleaseCachedKey((string)obj);
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					if (list != null)
					{
						List<string>.Enumerator enumerator3 = default(List<string>.Enumerator);
						while (enumerator3.MoveNext())
						{
							bool flag3 = dictionary.Remove(null);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rax_v24 (System.Collections.Generic.Dictionary`2<System.String, UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>)+20]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rax_v24 (System.Collections.Generic.Dictionary`2<System.String, UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>)+28]");
						if (num3 != 0)
						{
							return;
						}
						if (CustomOperationHandles != null)
						{
							bool flag4 = ((Dictionary<object, object>)(object)CustomOperationHandles).Remove((object)groupName);
							AudioLoader.ReleaseCachedGroup(groupName);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public static void ReleaseCustomOperationHandles(string groupName, List<string> keys)
	{
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		while (enumerator.MoveNext())
		{
			ReleaseCustomOperationHandle(groupName, null);
		}
	}

	public static void ReleaseCustomOperationHandle(string groupName, string key)
	{
		//IL_00bc: Expected O, but got I
		//IL_00cf: Expected O, but got I4
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		int num = CustomOperationHandles.FindEntry(groupName);
		if (num < 0)
		{
			return;
		}
		Dictionary<string, AsyncOperationHandle> dictionary = CustomOperationHandles.get_Item(groupName);
		int num2 = dictionary.FindEntry(key);
		if (num2 < 0)
		{
			return;
		}
		int num3 = dictionary.FindEntry(key);
		if (num3 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v27 (System.Collections.Generic.Dictionary`2<System.String, UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>)+18]");
			object obj = 0;
			object obj2 = num3 * 4;
			object obj3 = num3 + obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rdx_v16+30+v423 @ rcx_v24*8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj4 = default(object);
				object obj5 = default(object);
				if (obj4 == obj5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					bool flag = dictionary.Remove(key);
					return;
				}
			}
			Exception ex = new Exception("Attempting to use an invalid operation handle");
			ex._002Ector("Attempting to use an invalid operation handle");
			throw ex;
		}
		System.ThrowHelper.ThrowKeyNotFoundException((object)key);
		throw new IndexOutOfRangeException();
	}

	public unsafe static List<string> GetCustomOperationHandleKeys(string groupName)
	{
		//IL_0075: Expected O, but got Ref
		List<string> list = new List<string>();
		Dictionary<string, Dictionary<string, AsyncOperationHandle>> customOperationHandles = CustomOperationHandles;
		bool flag = CustomOperationHandles == null;
		if (!flag)
		{
			int num = CustomOperationHandles.FindEntry(groupName);
			if (flag)
			{
				goto IL_0181;
			}
			customOperationHandles = CustomOperationHandles;
			if (CustomOperationHandles != null)
			{
				Dictionary<string, AsyncOperationHandle> dictionary = CustomOperationHandles.get_Item(groupName);
				if (dictionary != null)
				{
					Dictionary<string, AsyncOperationHandle>.Enumerator enumerator = default(Dictionary<string, AsyncOperationHandle>.Enumerator);
					while (enumerator.MoveNext())
					{
						bool flag2 = list == null;
						Dictionary<string, AsyncOperationHandle>.Enumerator enumerator2 = (Dictionary<string, AsyncOperationHandle>.Enumerator)(&enumerator);
						if (!flag2)
						{
							int version = list._version + 1;
							list._version = version;
							customOperationHandles = (Dictionary<string, Dictionary<string, AsyncOperationHandle>>)(object)list._items;
							if (list._items != null)
							{
								if (list._size >= (nint)customOperationHandles._entries)
								{
									((List<object>)(object)list).AddWithResize((object)null);
									continue;
								}
								int size = list._size + 1;
								list._size = size;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					goto IL_0181;
				}
			}
		}
		throw new NullReferenceException();
		IL_0181:
		return list;
	}

	public static void ReleasePersistentOperationHandles()
	{
		//IL_00c4: Expected O, but got I
		List<AsyncOperationHandle>.Enumerator enumerator = default(List<AsyncOperationHandle>.Enumerator);
		if (enumerator.MoveNext())
		{
			Exception ex = new Exception("Attempting to use an invalid operation handle");
			ex._002Ector("Attempting to use an invalid operation handle");
			throw ex;
		}
		List<AsyncOperationHandle> persistentOperationHandles = PersistentOperationHandles;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>)+18]");
		if ((nint)0 > (nint)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>)+10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rcx_v16 (System.Collections.Generic.List`1<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>)+18]");
			Array.Clear((Array)num, 0, 0);
		}
	}

	public static void ReleaseDynamicOperationHandles()
	{
		Dictionary<AssetReference, AsyncOperationHandle>.Enumerator enumerator = default(Dictionary<AssetReference, AsyncOperationHandle>.Enumerator);
		Dictionary<IResourceLocation, AsyncOperationHandle>.Enumerator enumerator2 = default(Dictionary<IResourceLocation, AsyncOperationHandle>.Enumerator);
		object obj = default(object);
		object obj2 = default(object);
		object obj3 = default(object);
		object obj4 = default(object);
		object obj5 = default(object);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				DynamicOperationHandles.Clear();
				while (true)
				{
					if (!enumerator2.MoveNext())
					{
						DynamicLocationOperationHandles.Clear();
						return;
					}
					if (obj == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					if (obj2 != obj3)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				Exception ex = new Exception("Attempting to use an invalid operation handle");
				throw ex;
			}
			if (obj4 == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			if (obj5 != obj3)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
		}
		Exception ex2 = new Exception("Attempting to use an invalid operation handle");
		ex2._002Ector("Attempting to use an invalid operation handle");
		throw ex2;
	}

	public unsafe static void SavePersistentHandle(AsyncOperationHandle handle)
	{
		//IL_0013: Expected O, but got Ref
		object obj = default(object);
		PersistentOperationHandles.Add((AsyncOperationHandle)(&obj));
	}

	public unsafe static AsyncOperationHandle? TryAndGetFromCache(AssetReference assetReference, AddressableType handleType, string customGroupName, string customHandleKey)
	{
		//IL_00cf: Expected O, but got Ref
		//IL_00eb: Expected O, but got I
		//IL_00ae: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_004c: Expected O, but got I4
		//IL_00f9: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		object obj2;
		string assetGUID;
		if (customGroupName != null)
		{
			if ((nint)customGroupName != 1)
			{
				goto IL_00a5;
			}
			object obj = default(object);
			AsyncOperationHandle? asyncOperationHandle = TryAndGetFromCustomCache((string)(&obj), customHandleKey);
			obj2 = asyncOperationHandle;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rax_v7 (System.Nullable`1<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>)+10]");
			assetGUID = (string)0;
		}
		else
		{
			if (DynamicOperationHandles == null)
			{
				return (AsyncOperationHandle?)new NullReferenceException();
			}
			int num = DynamicOperationHandles.FindEntry((AssetReference)handleType);
			if (num < 0)
			{
				goto IL_00a5;
			}
			int num2 = DynamicOperationHandles.FindEntry((AssetReference)handleType);
			if (num2 < 0)
			{
				System.ThrowHelper.ThrowKeyNotFoundException((object)handleType);
				throw new IndexOutOfRangeException();
			}
			obj2 = 1;
			string text = default(string);
			assetGUID = text;
		}
		AssetReference assetReference2 = (AssetReference)obj2;
		assetReference.m_AssetGUID = assetGUID;
		goto IL_016f;
		IL_00a5:
		assetReference2 = (AssetReference)0;
		assetReference.m_AssetGUID = null;
		goto IL_016f;
		IL_016f:
		return (AsyncOperationHandle?)assetReference;
	}

	public unsafe static AsyncOperationHandle? TryAndGetFromCache(IResourceLocation assetResourceLocation, AddressableType handleType, string customGroupName, string customHandleKey)
	{
		//IL_00cb: Expected O, but got Ref
		//IL_00e7: Expected O, but got I
		//IL_00ae: Expected O, but got I4
		//IL_0018: Expected O, but got I4
		//IL_004c: Expected O, but got I4
		//IL_00f5: Expected O, but got I4
		//IL_007b: Expected O, but got I4
		object obj2;
		if (customGroupName != null)
		{
			if ((nint)customGroupName != 1)
			{
				goto IL_00a5;
			}
			object obj = default(object);
			AsyncOperationHandle? asyncOperationHandle = TryAndGetFromCustomCache((string)(&obj), customHandleKey);
			obj2 = asyncOperationHandle;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ rax_v7 (System.Nullable`1<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>)+10]");
			object obj3 = 0;
		}
		else
		{
			if (DynamicLocationOperationHandles == null)
			{
				return (AsyncOperationHandle?)new NullReferenceException();
			}
			int num = DynamicLocationOperationHandles.FindEntry((IResourceLocation)handleType);
			if (num < 0)
			{
				goto IL_00a5;
			}
			int num2 = DynamicLocationOperationHandles.FindEntry((IResourceLocation)handleType);
			if (num2 < 0)
			{
				System.ThrowHelper.ThrowKeyNotFoundException((object)handleType);
				throw new IndexOutOfRangeException();
			}
			obj2 = 1;
			object obj4 = default(object);
			object obj3 = obj4;
		}
		IResourceLocation resourceLocation = (IResourceLocation)obj2;
		goto IL_0163;
		IL_00a5:
		resourceLocation = (IResourceLocation)0;
		_ = 0;
		goto IL_0163;
		IL_0163:
		return (AsyncOperationHandle?)assetResourceLocation;
	}

	public unsafe static void SaveHandle(AssetReference assetReference, AsyncOperationHandle op, AddressableType handleType, string customGroupName, string customHandleKey)
	{
		//IL_0091: Expected O, but got Ref
		//IL_003e: Expected O, but got Ref
		object obj = default(object);
		switch (handleType)
		{
		case AddressableType.DYNAMIC:
			if (assetReference != null)
			{
				bool flag = ((Dictionary<object, AsyncOperationHandle>)(object)DynamicOperationHandles).TryInsert((object)assetReference, (AsyncOperationHandle)(&obj), System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
			else
			{
				Debug.LogError("[SaveHandle] - assetReference was NULL when trying to add a dynamic handle reference.");
			}
			break;
		case AddressableType.CUSTOM:
		{
			string customHandleKey2 = default(string);
			SaveCustomHandle((AsyncOperationHandle)(&obj), customGroupName, customHandleKey2);
			break;
		}
		}
	}

	public unsafe static void SaveHandle(IResourceLocation assetResourceLocation, AsyncOperationHandle op, AddressableType handleType, string customGroupName, string customHandleKey)
	{
		//IL_0091: Expected O, but got Ref
		//IL_003e: Expected O, but got Ref
		object obj = default(object);
		switch (handleType)
		{
		case AddressableType.DYNAMIC:
			if (assetResourceLocation != null)
			{
				bool flag = ((Dictionary<object, AsyncOperationHandle>)(object)DynamicLocationOperationHandles).TryInsert((object)assetResourceLocation, (AsyncOperationHandle)(&obj), System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
			else
			{
				Debug.LogError("[SaveHandle] - assetResourceLocation was NULL when trying to add a dynamic handle reference.");
			}
			break;
		case AddressableType.CUSTOM:
		{
			string customHandleKey2 = default(string);
			SaveCustomHandle((AsyncOperationHandle)(&obj), customGroupName, customHandleKey2);
			break;
		}
		}
	}

	private static AsyncOperationHandle? TryAndGetFromCustomCache(string customGroupName, string customHandleKey)
	{
		//IL_012e: Expected O, but got I4
		//IL_005d: Expected O, but got I
		//IL_00bf: Expected O, but got I
		//IL_017b: Expected O, but got I
		//IL_0113: Expected O, but got I4
		int num = CustomOperationHandles.FindEntry(customHandleKey);
		string text;
		if (num >= 0)
		{
			Dictionary<string, AsyncOperationHandle> dictionary = CustomOperationHandles.get_Item(customHandleKey);
			IntPtr intPtr = default(IntPtr);
			int num2 = dictionary.FindEntry((string)(nint)intPtr);
			if (num2 >= 0)
			{
				if (CustomOperationHandles != null)
				{
					Dictionary<string, AsyncOperationHandle> dictionary2 = CustomOperationHandles.get_Item(customHandleKey);
					if (dictionary2 != null)
					{
						int num3 = dictionary2.FindEntry((string)(nint)intPtr);
						if (num3 < 0)
						{
							System.ThrowHelper.ThrowKeyNotFoundException((object)(nint)intPtr);
							throw new IndexOutOfRangeException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ rax_v26 (System.Collections.Generic.Dictionary`2<System.String, UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>)+18]");
						if ((nint)0 != 0)
						{
							text = (string)1;
							int stringLength = default(int);
							customGroupName._stringLength = stringLength;
							return (AsyncOperationHandle?)customGroupName;
						}
					}
				}
				return (AsyncOperationHandle?)new NullReferenceException();
			}
		}
		text = (string)0;
		customGroupName._stringLength = 0;
		return (AsyncOperationHandle?)customGroupName;
	}

	private unsafe static void SaveCustomHandle(AsyncOperationHandle op, string customGroupName, string customHandleKey)
	{
		//IL_010d: Expected O, but got Ref
		if (customHandleKey != null && customGroupName != null)
		{
			int num = CustomOperationHandles.FindEntry(customGroupName);
			if (num < 0)
			{
				Dictionary<string, AsyncOperationHandle> value = new Dictionary<string, AsyncOperationHandle>();
				bool flag = ((Dictionary<object, object>)(object)CustomOperationHandles).TryInsert((object)customGroupName, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
			Dictionary<string, AsyncOperationHandle> dictionary = CustomOperationHandles.get_Item(customGroupName);
			int num2 = dictionary.FindEntry(customGroupName);
			if (num2 >= 0)
			{
				string message = "[SaveHandle] - Trying to add a handle to group " + customGroupName + " that already exists for key " + customHandleKey;
				Debug.LogError(message);
			}
			else
			{
				object obj = default(object);
				bool flag2 = ((Dictionary<object, AsyncOperationHandle>)(object)dictionary).TryInsert((object)customHandleKey, (AsyncOperationHandle)(&obj), System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
			}
		}
		else
		{
			Debug.LogError("[SaveHandle] - GroupName or Key was NULL when trying to add a custom handle reference.");
		}
	}

	public static Dictionary<string, List<string>> GetTextureCache()
	{
		return TextureCache;
	}

	public static void SaveTexture(string cacheGroup, string textureName)
	{
		int num = TextureCache.FindEntry(cacheGroup);
		if (num < 0)
		{
			List<string> value = new List<string>();
			bool flag = ((Dictionary<object, object>)(object)TextureCache).TryInsert((object)cacheGroup, (object)value, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		}
		List<string> list = TextureCache.get_Item(cacheGroup);
		List<string> list2 = ((Dictionary<string, List<string>>)(object)list).get_Item(textureName);
		if (list2 == null)
		{
			List<string> list3 = TextureCache.get_Item(cacheGroup);
			int version = list3._version + 1;
			list3._version = version;
			string[] items = list3._items;
			if (list3._size >= items.Length)
			{
				((List<object>)(object)list3).AddWithResize((object)textureName);
				return;
			}
			int size = list3._size + 1;
			list3._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
	}

	public static bool TextureExistsInCache(string cacheGroup, string texture)
	{
		//IL_0095: Expected I4, but got O
		//IL_0082: Expected I4, but got O
		if (TextureCache != null)
		{
			int num = TextureCache.FindEntry(cacheGroup);
			if (num < 0)
			{
				return false;
			}
			if (TextureCache != null)
			{
				List<string> list = TextureCache.get_Item(cacheGroup);
				if (list != null)
				{
					return (byte)(int)((Dictionary<string, List<string>>)(object)list).get_Item(texture) != 0;
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static List<string> GetTexturesInGroup(string cacheGroup)
	{
		if (TextureCache != null)
		{
			int num = TextureCache.FindEntry(cacheGroup);
			if (num < 0)
			{
				return new List<string>();
			}
			if (TextureCache != null)
			{
				return TextureCache.get_Item(cacheGroup);
			}
		}
		return (List<string>)(object)new NullReferenceException();
	}

	public static void RemoveTexture(string cacheGroup, string texture)
	{
		int num = TextureCache.FindEntry(cacheGroup);
		if (num >= 0)
		{
			List<string> list = TextureCache.get_Item(cacheGroup);
			bool flag = ((List<object>)(object)list).Remove((object)texture);
		}
		List<string> list2 = TextureCache.get_Item(cacheGroup);
		if (list2._size == 0)
		{
			RemoveTextureGroup(cacheGroup);
		}
	}

	public static void RemoveTextures(string cacheGroup, List<string> textures)
	{
		bool flag = TextureCache == null;
		if (!flag)
		{
			int num = TextureCache.FindEntry(cacheGroup);
			if (flag)
			{
				return;
			}
			if (textures != null)
			{
				List<string>.Enumerator enumerator = default(List<string>.Enumerator);
				while (enumerator.MoveNext())
				{
					if (TextureCache != null)
					{
						List<string> list = TextureCache.get_Item(cacheGroup);
						if (list != null)
						{
							bool flag2 = ((List<object>)(object)list).Remove((object)null);
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				if (TextureCache != null)
				{
					List<string> list2 = TextureCache.get_Item(cacheGroup);
					if (list2 != null)
					{
						if (list2._size == 0)
						{
							RemoveTextureGroup(cacheGroup);
						}
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public static void RemoveTextureGroup(string cacheGroup)
	{
		bool flag = ((Dictionary<object, object>)(object)TextureCache).Remove((object)cacheGroup);
	}

	public static void RemoveTexturesFromCacheAndSpriteManager(string cacheGroup)
	{
		List<string> texturesInGroup = GetTexturesInGroup(cacheGroup);
		List<string> list = new List<string>();
		List<string>.Enumerator enumerator = default(List<string>.Enumerator);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				SpriteManager.UnregisterTexture(null);
				bool flag = list == null;
				string text = null;
				if (!flag)
				{
					int version = list._version + 1;
					list._version = version;
					text = (string)(object)list._items;
					if (list._items == null)
					{
						break;
					}
					int size = list._size;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ rcx_v7 (System.String)+18]");
					if ((nint)size >= (nint)0)
					{
						((List<object>)(object)list).AddWithResize((object)null);
						continue;
					}
					int size2 = list._size + 1;
					list._size = size2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					continue;
				}
				throw new NullReferenceException();
			}
			RemoveTextures(cacheGroup, list);
			ReleaseCustomOperationHandleGroup(cacheGroup);
			return;
		}
		throw new NullReferenceException();
	}

	static AddressableCache()
	{
		List<AsyncOperationHandle> persistentOperationHandles = new List<AsyncOperationHandle>();
		PersistentOperationHandles = persistentOperationHandles;
		Dictionary<AssetReference, AsyncOperationHandle> dynamicOperationHandles = new Dictionary<AssetReference, AsyncOperationHandle>();
		DynamicOperationHandles = dynamicOperationHandles;
		Dictionary<IResourceLocation, AsyncOperationHandle> dynamicLocationOperationHandles = new Dictionary<IResourceLocation, AsyncOperationHandle>();
		DynamicLocationOperationHandles = dynamicLocationOperationHandles;
		Dictionary<string, Dictionary<string, AsyncOperationHandle>> customOperationHandles = new Dictionary<string, Dictionary<string, AsyncOperationHandle>>();
		CustomOperationHandles = customOperationHandles;
		Dictionary<string, List<string>> textureCache = new Dictionary<string, List<string>>();
		TextureCache = textureCache;
	}
}
