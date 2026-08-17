using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.DLC.Types;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Framework.Loading;

public class AddressableLoader
{
	private sealed class _003C_003Ec__DisplayClass17_0<T>
	{
		public Action<T> onComplete;

		internal unsafe void _003CDoAssetLoad_003Eg__OnAssetLoadComplete_007C0(AsyncOperationHandle<T> handle)
		{
			//IL_016b: Expected O, but got F4
			nint num = 0;
			object obj = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ r9_v3 (Il2CppRgctx<VampireSurvivors.Framework.Loading.AddressableLoader+<>c__DisplayClass17_0`1>)+20]");
			Action<AsyncOperationHandle<object>> value = new Action<AsyncOperationHandle<object>>(this, (IntPtr)0);
			nint num3 = 0;
			((AsyncOperationHandle<object>*)handle)->Completed -= value;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184132A60");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1841311C0");
			object obj2 = default(object);
			if (obj2 != null)
			{
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1841311C0");
				object obj4 = default(object);
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v459 @ rdx_v16+188] (should have been resolved before IL gen)");
				string text = default(string);
				string message = "[LoadAssetAsync][LoadAssetAsync] - " + text;
				Debug.LogError(message);
			}
			if (!SimulateThrottle)
			{
				Action<T> action = onComplete;
				if (onComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v467 @ rax_v38 (System.Action`1<T>)+18] (should have been resolved before IL gen)");
				}
			}
			else
			{
				object obj5 = UnityEngine.Random.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ r8_v10 (Il2CppRgctx<VampireSurvivors.Framework.Loading.AddressableLoader+<>c__DisplayClass17_0`1>)+60]");
				Action action2 = new Action(obj, (IntPtr)0);
				nint num7 = 0;
				object obj6 = default(object);
				float duration = (float)ThrottleAmount * (float)obj6;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				Timer timer = TimerHelper.RegisterMillisAutomation(duration, action2, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_1<T>
	{
		public T result;

		public _003C_003Ec__DisplayClass17_0<T> CS_0024_003C_003E8__locals1;

		internal void _003CDoAssetLoad_003Eb__1()
		{
			_003C_003Ec__DisplayClass17_0<T> obj = CS_0024_003C_003E8__locals1;
			Action<T> onComplete = obj.onComplete;
			if (obj.onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v12 @ rax_v3 (System.Action`1<T>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	public static bool SimulateThrottle = false;

	public static int ThrottleAmount = 2500;

	public static readonly string DefaultPath = "REPLACE_ME";

	private static string _currentAssetBundlePath = "";

	public static bool UseSyncLoad = false;

	public static string CurrentPath => _currentAssetBundlePath;

	private unsafe static string ReplaceAssetBundlePaths(IResourceLocation location)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_00e8: Expected O, but got I
		//IL_00f8: Expected O, but got I
		//IL_01b0: Expected I, but got O
		//IL_0221: Expected I4, but got O
		//IL_0250: Expected I, but got O
		//IL_025d: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj3 = default(object);
		object obj4 = default(object);
		string text2 = default(string);
		string text4;
		if (obj3 == obj4)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			string text = default(string);
			if (text.StartsWith(DefaultPath))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				string path = default(string);
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
				bool flag = "_" != null;
				string separator = "_";
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v595 @ rax_v56+B8]");
					object obj6 = 0;
					separator = (string)obj6;
				}
				StringSplitOptions options = default(StringSplitOptions);
				string[] array = fileNameWithoutExtension.SplitInternal(separator, (string[])null, 2147483647, options);
				bool flag2 = array.Length == 0;
				int num = 2147483647;
				if (!flag2)
				{
					Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(DlcType));
					bool flag3 = Enum.TryParse(typeFromHandle, array[0], ignoreCase: true, out var result);
					bool flag4 = !flag3;
					num = (int)(&result);
					if (!flag4)
					{
						Dictionary<DlcType, string> mountedPaths = DlcSystem.MountedPaths;
						nint num2 = (nint)typeof(DlcType);
						int value = ((int*)(&result))->m_value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rdx_v29 (System.Int32)+40]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r8_v19 (Il2CppClass<VampireSurvivors.Data.DlcType>)+40]");
						if (num3 != 0)
						{
							return (string)(object)new InvalidCastException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_8_v9 (System.Object)+10]");
						int num4 = ((Dictionary<System.Int32Enum, object>)(object)mountedPaths).FindEntry((System.Int32Enum)0);
						bool flag5 = num4 < 0;
						num = (int)result;
						if (!flag5)
						{
							Dictionary<DlcType, string> mountedPaths2 = DlcSystem.MountedPaths;
							nint num5 = (nint)typeof(DlcType);
							nint num6 = (nint)result;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rdx_v31 (Il2CppClass<System.Object>)+40]");
							nint num7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ r10_v10 (Il2CppClass<VampireSurvivors.Data.DlcType>)+40]");
							if (num7 == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ stack_8_v9 (System.Object)+10]");
								object newValue = ((Dictionary<System.Int32Enum, object>)(object)mountedPaths2).get_Item((System.Int32Enum)0);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
								string text3 = default(string);
								text2 = text3.Replace(DefaultPath, (string)newValue);
								text4 = "ReplaceAssetBundlePaths (Auto locate DLC): ";
								goto IL_038c;
							}
							throw new InvalidCastException();
						}
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				string text5 = default(string);
				text2 = text5.Replace(DefaultPath, _currentAssetBundlePath);
				text4 = "ReplaceAssetBundlePaths: ";
				goto IL_038c;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		goto IL_03a2;
		IL_03a2:
		return text2;
		IL_038c:
		string message = text4 + text2;
		Debug.Log(message);
		goto IL_03a2;
	}

	public static void SetInternalIdTransform()
	{
		Func<IResourceLocation, string> func = ReplaceAssetBundlePaths;
		UnityEngine.AddressableAssets.AddressablesImpl addressablesInstance = Addressables.m_AddressablesInstance;
		ResourceManager resourceManager = addressablesInstance.m_ResourceManager;
		resourceManager._003CInternalIdTransformFunc_003Ek__BackingField = func;
	}

	public static void SetPath(string path)
	{
		_currentAssetBundlePath = path;
		string message = "[AddressableLoader.SetPath] CurrentAssetBundlePath: " + path;
		Debug.Log(message);
	}

	public unsafe static void PointAtDlc(DlcType dlcType)
	{
		//IL_00b3: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string message = "<AddressableLoader.PointAtDLC> pointing at " + text;
		Debug.Log(message);
		SetInternalIdTransform();
		Dictionary<DlcType, string> mountedPaths = DlcSystem.MountedPaths;
		int num = ((Dictionary<System.Int32Enum, object>)(object)mountedPaths).FindEntry((System.Int32Enum)dlcType);
		bool flag = num < 0;
		object obj2 = "";
		if (!flag)
		{
			Dictionary<DlcType, string> mountedPaths2 = DlcSystem.MountedPaths;
			object obj3 = ((Dictionary<System.Int32Enum, object>)(object)mountedPaths2).get_Item((System.Int32Enum)dlcType);
			obj2 = obj3;
		}
		bool flag2 = obj2 == null;
		string path = "";
		if (!flag2)
		{
			path = (string)obj2;
		}
		SetPath(path);
	}

	public static T LoadAsset<T>(DlcType? dlcType, AssetReferenceT<T> assetReference, AddressableType handleType = AddressableType.DYNAMIC, string customGroupName = null, string customHandleKey = null) where T : UnityEngine.Object
	{
		//IL_007b: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_30+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_30+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 69 Invalid \"Jump target not found in method: 0x182F948D0\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_30+38]");
		return (T)0;
	}

	public unsafe static T LoadAsset<T>(DlcType? dlcType, AssetReference assetReference, AddressableType handleType = AddressableType.DYNAMIC, string customGroupName = null, string customHandleKey = null)
	{
		//IL_0079: Expected O, but got I4
		//IL_0079: Expected I4, but got O
		//IL_0079: Expected O, but got Ref
		//IL_0113: Expected O, but got Ref
		//IL_0265: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ stack_30+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ stack_30+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		AsyncOperationHandle<object> asyncOperationHandle2 = default(AsyncOperationHandle<object>);
		AsyncOperationHandle? asyncOperationHandle = AddressableCache.TryAndGetFromCache((AssetReference)(&asyncOperationHandle2), (AddressableType)assetReference, (string)handleType, customGroupName);
		if (asyncOperationHandle == null)
		{
			if ((object)dlcType != null)
			{
				DlcType dlcType2 = default(DlcType);
				PointAtDlc(dlcType2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F972D0");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183C33A10");
			AsyncOperationHandle<object> asyncOperationHandle3 = default(AsyncOperationHandle<object>);
			string customHandleKey2 = default(string);
			AddressableCache.SaveHandle(assetReference, (AsyncOperationHandle)(&asyncOperationHandle3), handleType, customGroupName, customHandleKey2);
			object result = asyncOperationHandle2.WaitForCompletion();
			if ((object)asyncOperationHandle3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ stack_-88_v7 (UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle`1<System.Object>)+30]");
				if (0 == (nint)asyncOperationHandle3)
				{
					if (asyncOperationHandle3.m_LocationName != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ stack_-88_v7 (UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle`1<System.Object>)+30]");
						if (0 != (nint)asyncOperationHandle3)
						{
							Exception ex = new Exception("Attempting to use an invalid operation handle");
							ex._002Ector("Attempting to use an invalid operation handle");
							throw ex;
						}
						string text = (string)(object)((IEnumerable)asyncOperationHandle3.m_LocationName).GetEnumerator();
						string message = "[LoadAsset][LoadAssetAsync] - " + text;
						Debug.LogError(message);
					}
					return (T)result;
				}
			}
			Exception ex2 = new Exception("Attempting to use an invalid operation handle");
			ex2._002Ector("Attempting to use an invalid operation handle");
			throw ex2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
		if (asyncOperationHandle != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v3 (System.Nullable`1<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>)+10]");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ stack_30+38]");
				object obj2 = 0;
				object obj3 = default(object);
				bool flag = obj3 == null;
				T result2 = (T)null;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					T val = default(T);
					bool flag2 = val == null;
					result2 = val;
					if (flag2)
					{
						return (T)new InvalidCastException();
					}
				}
				return result2;
			}
		}
		Exception ex3 = new Exception("Attempting to use an invalid operation handle");
		throw ex3;
	}

	public unsafe static T LoadAsset<T>(DlcType? dlcType, IResourceLocation assetLocation, AddressableType handleType = AddressableType.DYNAMIC, string customGroupName = null, string customHandleKey = null)
	{
		//IL_0079: Expected O, but got I4
		//IL_0079: Expected I4, but got O
		//IL_0079: Expected O, but got Ref
		//IL_0113: Expected O, but got Ref
		//IL_0265: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ stack_30+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ stack_30+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		AsyncOperationHandle<object> asyncOperationHandle2 = default(AsyncOperationHandle<object>);
		AsyncOperationHandle? asyncOperationHandle = AddressableCache.TryAndGetFromCache((IResourceLocation)(&asyncOperationHandle2), (AddressableType)assetLocation, (string)handleType, customGroupName);
		if (asyncOperationHandle == null)
		{
			if ((object)dlcType != null)
			{
				DlcType dlcType2 = default(DlcType);
				PointAtDlc(dlcType2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F971F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183C33A10");
			AsyncOperationHandle<object> asyncOperationHandle3 = default(AsyncOperationHandle<object>);
			string customHandleKey2 = default(string);
			AddressableCache.SaveHandle(assetLocation, (AsyncOperationHandle)(&asyncOperationHandle3), handleType, customGroupName, customHandleKey2);
			object result = asyncOperationHandle2.WaitForCompletion();
			if ((object)asyncOperationHandle3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ stack_-88_v7 (UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle`1<System.Object>)+30]");
				if (0 == (nint)asyncOperationHandle3)
				{
					if (asyncOperationHandle3.m_LocationName != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ stack_-88_v7 (UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle`1<System.Object>)+30]");
						if (0 != (nint)asyncOperationHandle3)
						{
							Exception ex = new Exception("Attempting to use an invalid operation handle");
							ex._002Ector("Attempting to use an invalid operation handle");
							throw ex;
						}
						string text = (string)(object)((IEnumerable)asyncOperationHandle3.m_LocationName).GetEnumerator();
						string message = "[LoadAsset][LoadAssetAsync] - " + text;
						Debug.LogError(message);
					}
					return (T)result;
				}
			}
			Exception ex2 = new Exception("Attempting to use an invalid operation handle");
			ex2._002Ector("Attempting to use an invalid operation handle");
			throw ex2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
		if (asyncOperationHandle != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ rax_v3 (System.Nullable`1<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>)+10]");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ stack_30+38]");
				object obj2 = 0;
				object obj3 = default(object);
				bool flag = obj3 == null;
				T result2 = (T)null;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					T val = default(T);
					bool flag2 = val == null;
					result2 = val;
					if (flag2)
					{
						return (T)new InvalidCastException();
					}
				}
				return result2;
			}
		}
		Exception ex3 = new Exception("Attempting to use an invalid operation handle");
		throw ex3;
	}

	public static void LoadAssetAsync<T>(DlcType? dlcType, AssetReferenceT<T> assetReference, AddressableType handleType = AddressableType.DYNAMIC, string customGroupName = null, string customHandleKey = null, Action<T> onComplete = null) where T : UnityEngine.Object
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_38+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v11 @ stack_38+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 69 Invalid \"Jump target not found in method: 0x182F95F40\"");
	}

	public unsafe static void LoadAssetAsync<T>(DlcType? dlcType, AssetReference assetReference, AddressableType handleType = AddressableType.DYNAMIC, string customGroupName = null, string customHandleKey = null, Action<T> onComplete = null)
	{
		//IL_00a9: Expected O, but got I4
		//IL_00a9: Expected I4, but got O
		//IL_00a9: Expected O, but got Ref
		//IL_0139: Expected O, but got Ref
		//IL_014e: Expected O, but got I
		//IL_01cb: Expected O, but got I
		//IL_0254: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ stack_38+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ stack_38+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		DlcType dlcType2 = default(DlcType);
		if ((object)dlcType != null)
		{
			PointAtDlc(dlcType2);
		}
		object obj = default(object);
		AsyncOperationHandle? asyncOperationHandle = AddressableCache.TryAndGetFromCache((AssetReference)(&obj), (AddressableType)assetReference, (string)handleType, customGroupName);
		if (asyncOperationHandle == null)
		{
			if ((object)dlcType != null)
			{
				PointAtDlc(dlcType2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F972D0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183C33A10");
			string customHandleKey2 = default(string);
			AddressableCache.SaveHandle(assetReference, (AsyncOperationHandle)(&obj), handleType, customGroupName, customHandleKey2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ stack_38+38]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F2950");
		}
		else
		{
			object obj3 = default(object);
			if (obj3 == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			if (asyncOperationHandle != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v4 (System.Nullable`1<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>)+10]");
				object obj4 = default(object);
				if (obj4 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ stack_38+38]");
					object obj5 = 0;
					object obj6 = default(object);
					bool flag = obj6 == null;
					object obj7 = 0;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj8 = default(object);
						bool flag2 = obj8 == null;
						obj7 = obj8;
						if (flag2)
						{
							throw new InvalidCastException();
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v183 @ stack_30+18] (should have been resolved before IL gen)");
					return;
				}
			}
			Exception ex = new Exception("Attempting to use an invalid operation handle");
			throw ex;
		}
	}

	public unsafe static void LoadAssetAsync<T>(DlcType? dlcType, IResourceLocation assetLocation, AddressableType handleType = AddressableType.DYNAMIC, string customGroupName = null, string customHandleKey = null, Action<T> onComplete = null)
	{
		//IL_00a9: Expected O, but got I4
		//IL_00a9: Expected I4, but got O
		//IL_00a9: Expected O, but got Ref
		//IL_0139: Expected O, but got Ref
		//IL_014e: Expected O, but got I
		//IL_01cb: Expected O, but got I
		//IL_0254: Expected O, but got I4
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ stack_38+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ stack_38+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		DlcType dlcType2 = default(DlcType);
		if ((object)dlcType != null)
		{
			PointAtDlc(dlcType2);
		}
		object obj = default(object);
		AsyncOperationHandle? asyncOperationHandle = AddressableCache.TryAndGetFromCache((IResourceLocation)(&obj), (AddressableType)assetLocation, (string)handleType, customGroupName);
		if (asyncOperationHandle == null)
		{
			if ((object)dlcType != null)
			{
				PointAtDlc(dlcType2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F971F0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183C33A10");
			string customHandleKey2 = default(string);
			AddressableCache.SaveHandle(assetLocation, (AsyncOperationHandle)(&obj), handleType, customGroupName, customHandleKey2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ stack_38+38]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804F2950");
		}
		else
		{
			object obj3 = default(object);
			if (obj3 == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
			if (asyncOperationHandle != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v4 (System.Nullable`1<UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle>)+10]");
				object obj4 = default(object);
				if (obj4 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ stack_38+38]");
					object obj5 = 0;
					object obj6 = default(object);
					bool flag = obj6 == null;
					object obj7 = 0;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
						object obj8 = default(object);
						bool flag2 = obj8 == null;
						obj7 = obj8;
						if (flag2)
						{
							throw new InvalidCastException();
						}
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v183 @ stack_30+18] (should have been resolved before IL gen)");
					return;
				}
			}
			Exception ex = new Exception("Attempting to use an invalid operation handle");
			throw ex;
		}
	}

	public unsafe static void DoAssetLoad<T>(AsyncOperationHandle<T> op, Action<T> onComplete = null)
	{
		object CS_0024_003C_003E8__locals3 = null;
		Action<AsyncOperationHandle<T>> value = delegate(AsyncOperationHandle<T> handle)
		{
			//IL_016b: Expected O, but got F4
			nint num = 0;
			object obj = null;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ r9_v3 (Il2CppRgctx<VampireSurvivors.Framework.Loading.AddressableLoader+<>c__DisplayClass17_0`1>)+20]");
			Action<AsyncOperationHandle<object>> value2 = new Action<AsyncOperationHandle<object>>(CS_0024_003C_003E8__locals3, (IntPtr)0);
			nint num3 = 0;
			((AsyncOperationHandle<object>*)handle)->Completed -= value2;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184132A60");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1841311C0");
			object obj2 = default(object);
			if (obj2 != null)
			{
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1841311C0");
				object obj4 = default(object);
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v459 @ rdx_v16+188] (should have been resolved before IL gen)");
				string text = default(string);
				string message = "[LoadAssetAsync][LoadAssetAsync] - " + text;
				Debug.LogError(message);
			}
			if (!SimulateThrottle)
			{
				Action<T> onComplete2 = ((_003C_003Ec__DisplayClass17_0<T>)CS_0024_003C_003E8__locals3).onComplete;
				if (((_003C_003Ec__DisplayClass17_0<T>)CS_0024_003C_003E8__locals3).onComplete != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v467 @ rax_v38 (System.Action`1<T>)+18] (should have been resolved before IL gen)");
				}
			}
			else
			{
				object obj5 = UnityEngine.Random.value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v546 @ r8_v10 (Il2CppRgctx<VampireSurvivors.Framework.Loading.AddressableLoader+<>c__DisplayClass17_0`1>)+60]");
				Action onComplete3 = new Action(obj, (IntPtr)0);
				nint num7 = 0;
				object obj6 = default(object);
				float duration = (float)ThrottleAmount * (float)obj6;
				bool useRealTime = default(bool);
				MonoBehaviour autoDestroyOwner = default(MonoBehaviour);
				int repeat = default(int);
				Timer timer = TimerHelper.RegisterMillisAutomation(duration, onComplete3, null, isLooped: false, useRealTime, autoDestroyOwner, repeat);
			}
		};
		((AsyncOperationHandle<T>*)op)->Completed += value;
	}

	public static bool CheckValidAssetReference(AssetReference assetReference)
	{
		//IL_0057: Expected I4, but got O
		if (assetReference != null)
		{
			bool flag = assetReference.RuntimeKeyIsValid();
			bool flag2 = !flag;
			return !flag2;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}
}
