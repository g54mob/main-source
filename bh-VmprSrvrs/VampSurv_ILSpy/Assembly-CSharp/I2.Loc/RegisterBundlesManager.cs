using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace I2.Loc;

public class RegisterBundlesManager : MonoBehaviour, IResourceManager_Bundles
{
	public void OnEnable()
	{
		ResourceManager pInstance = ResourceManager.pInstance;
		List<IResourceManager_Bundles> mBundleManagers = pInstance.mBundleManagers;
		if (mBundleManagers._size != 0)
		{
			int num = Array.IndexOf((object[])mBundleManagers._items, (object)this, 0, mBundleManagers._size);
			if (num != -1)
			{
				return;
			}
		}
		ResourceManager pInstance2 = ResourceManager.pInstance;
		List<object> mBundleManagers2 = (List<object>)(object)pInstance2.mBundleManagers;
		int version = mBundleManagers2._version + 1;
		mBundleManagers2._version = version;
		object[] items = mBundleManagers2._items;
		if (mBundleManagers2._size >= items.Length)
		{
			mBundleManagers2.AddWithResize((object)this);
			return;
		}
		int size = mBundleManagers2._size + 1;
		mBundleManagers2._size = size;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
	}

	public void OnDisable()
	{
		ResourceManager pInstance = ResourceManager.pInstance;
		bool flag = ((List<object>)(object)pInstance.mBundleManagers).Remove((object)this);
	}

	public virtual UnityEngine.Object LoadFromBundle(string path, Type assetType)
	{
		return null;
	}

	public RegisterBundlesManager()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
