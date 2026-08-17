using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Loading;

namespace VampireSurvivors.Framework.DLC;

public class LoadingManager
{
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public LoadingManager _003C_003E4__this;

		public DlcType dlcType;

		public Action callback;

		internal unsafe void _003CUnmountDlc_003Eb__0()
		{
			//IL_006f: Expected O, but got Ref
			LoadingManager loadingManager = _003C_003E4__this;
			int num = ((Dictionary<System.Int32Enum, object>)(object)loadingManager._003CMountedPaths_003Ek__BackingField).FindEntry((System.Int32Enum)dlcType);
			if (num >= 0)
			{
				LoadingManager loadingManager2 = _003C_003E4__this;
				bool flag = ((Dictionary<System.Int32Enum, object>)(object)loadingManager2._003CMountedPaths_003Ek__BackingField).Remove((System.Int32Enum)dlcType);
			}
			object obj = default(object);
			string text = ((Enum)(&obj)).ToString();
			string message = "Unmounted DLC " + text;
			DlcSystem.Log(message);
			Action action = callback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v80.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public int index;

		public LoadingManager _003C_003E4__this;

		public List<DlcType> dlcsToLoad;

		public Action callback;

		public DlcType dlcType;

		public Action<bool> _003C_003E9__1;

		internal unsafe void _003CLoadDlc_003Eb__0()
		{
			//IL_0031: Expected O, but got Ref
			//IL_009f: Expected I4, but got O
			if (AddressableLoader._currentAssetBundlePath != null)
			{
				object obj = default(object);
				string text = ((Enum)(&obj)).ToString();
				string message = "Loading DLC " + text + " from path: " + AddressableLoader._currentAssetBundlePath;
				DlcSystem.Log(message);
				Action<bool> action = _003C_003E9__1;
				if (_003C_003E9__1 == null)
				{
					Action<bool> action2 = null;
					((_003C_003Ec__DisplayClass11_0)(object)action2)._003CLoadDlc_003Eb__1((byte)(int)this != 0);
					_003C_003E9__1 = action2;
					action = action2;
				}
				_003C_003E4__this.LoadManifestDirect(dlcType, AddressableLoader._currentAssetBundlePath, action);
			}
			else
			{
				int num = ++index;
				_003C_003E4__this.LoadDlc(num, dlcsToLoad, callback);
			}
		}

		internal unsafe void _003CLoadDlc_003Eb__1(bool success)
		{
			//IL_0060: Expected O, but got Ref
			object obj = default(object);
			string text = ((Enum)(&obj)).ToString();
			string text2 = "Success loading DLC ";
			if (!success)
			{
				text2 = "Error loading DLC ";
			}
			string message = text2 + text;
			DlcSystem.Log(message);
			int num = ++index;
			_003C_003E4__this.LoadDlc(num, dlcsToLoad, callback);
		}
	}

	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public int index;

		public LoadingManager _003C_003E4__this;

		public List<DlcType> dlcsToLoad;

		public Action callback;

		public DlcType dlcType;

		internal unsafe void _003CLoadIncludedDlc_003Eb__0(bool success)
		{
			//IL_0060: Expected O, but got Ref
			object obj = default(object);
			string text = ((Enum)(&obj)).ToString();
			string text2 = "Success loading included DLC ";
			if (!success)
			{
				text2 = "Error loading included DLC ";
			}
			string message = text2 + text;
			DlcSystem.Log(message);
			int num = ++index;
			_003C_003E4__this.LoadIncludedDlc(num, dlcsToLoad, callback);
		}
	}

	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public LoadingManager _003C_003E4__this;

		public DlcType dlcType;

		public Action<bool> callback;

		internal void _003CLoadManifestDirect_003Eb__0(BundleManifestData bmd)
		{
			DlcLoader.ResetLoader();
			if ((object)bmd != null && ((UnityEngine.Object)bmd).m_CachedPtr != (IntPtr)0)
			{
				LoadingManager loadingManager = _003C_003E4__this;
				bool flag = ((Dictionary<System.Int32Enum, object>)(object)loadingManager._003CLoadedDlc_003Ek__BackingField).TryInsert((System.Int32Enum)dlcType, (object)bmd, System.Collections.Generic.InsertionBehavior.None);
				Action<bool> action = callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v175 @ rax_v17 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
			else
			{
				Action<bool> action2 = callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v146 @ rax_v10 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public int index;

		public LoadingManager _003C_003E4__this;

		public DlcType[] dlcs;

		public Action callback;

		internal void _003CValidateVersion_003Eb__0()
		{
			int num = ++index;
			_003C_003E4__this.ValidateVersion(num, dlcs, callback);
		}
	}

	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public LoadingManager _003C_003E4__this;

		public Action callback;

		internal unsafe void _003CLoadDlcs_003Eb__0()
		{
			//IL_003f: Expected O, but got Ref
			//IL_01ac: Expected O, but got I
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_00c2: Expected I4, but got O
			//IL_00e7: Expected O, but got Ref
			List<DlcType> dlcTypesToLoad = DlcSystem.GetDlcTypesToLoad();
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			System.ParamsArray paramsArray2 = default(System.ParamsArray);
			string message = string.FormatHelper((IFormatProvider)null, "Loading selected external DLCs: {0}", (System.ParamsArray)(&paramsArray2));
			Debug.Log(message);
			object obj = default(object);
			object obj2 = default(object);
			object obj4 = default(object);
			object obj5 = default(object);
			System.ParamsArray paramsArray3 = default(System.ParamsArray);
			while (true)
			{
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_-88_v8+1C]");
					if (obj2 == null)
					{
						object obj3 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_-88_v8+18]");
						if ((nint)obj3 < 0)
						{
							obj4++;
							object arg2 = (DlcType)obj5;
							paramsArray2 = new System.ParamsArray(arg2);
							string message2 = string.FormatHelper((IFormatProvider)null, "going to load external DLC: {0}", (System.ParamsArray)(&paramsArray3));
							Debug.Log(message2);
							continue;
						}
						break;
					}
					break;
				}
				throw new NullReferenceException();
			}
			bool flag = obj == null;
			object obj6 = 0;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ stack_-88_v8+1C]");
				if (obj2 == null)
				{
					_003C_003E4__this.LoadDlc(0, dlcTypesToLoad, callback);
					return;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				obj6 = null;
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public DlcType dlcType;

		public LoadingManager _003C_003E4__this;

		public Action callback;

		internal unsafe void _003CMountDlc_003Eb__0(string path)
		{
			//IL_00e4: Expected O, but got Ref
			//IL_0063: Expected O, but got Ref
			AddressableLoader.SetInternalIdTransform();
			AddressableLoader.SetPath(path);
			object obj = default(object);
			if (path != null && path._stringLength > 0)
			{
				string text = ((Enum)(&obj)).ToString();
				string message = "Successfully mounted DLC " + text + " at path: " + path;
				DlcSystem.Log(message);
				LoadingManager loadingManager = _003C_003E4__this;
				bool flag = ((Dictionary<System.Int32Enum, object>)(object)loadingManager._003CMountedPaths_003Ek__BackingField).TryInsert((System.Int32Enum)dlcType, (object)path, System.Collections.Generic.InsertionBehavior.None);
				System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
				string text2 = path;
			}
			else
			{
				string text3 = ((Enum)(&obj)).ToString();
				string message2 = "Failed to mount DLC " + text3 + ", you may need to free up storage space.";
				DlcSystem.Log(message2);
				System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
				string text2 = ", you may need to free up storage space.";
			}
			_003C_003E4__this.LogAllMountedPaths();
			Action action = callback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v245.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public LoadingManager _003C_003E4__this;

		public Action callback;

		internal void _003CUnmountAllDlc_003Eb__0()
		{
			_003C_003E4__this.UnmountAllDlc(callback);
		}
	}

	private readonly Dictionary<DlcType, string> _003CMountedPaths_003Ek__BackingField;

	private readonly Dictionary<DlcType, BundleManifestData> _003CLoadedDlc_003Ek__BackingField;

	public Dictionary<DlcType, string> MountedPaths => _003CMountedPaths_003Ek__BackingField;

	public Dictionary<DlcType, BundleManifestData> LoadedDlc => _003CLoadedDlc_003Ek__BackingField;

	public unsafe void LoadDlcs(Action callback)
	{
		//IL_03e9: Expected O, but got I
		//IL_009e: Expected O, but got I
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_0263: Expected O, but got Ref
		//IL_010b: Expected O, but got I4
		//IL_02c8: Expected I, but got O
		//IL_02de: Expected O, but got I
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_0362: Expected I, but got O
		//IL_0122: Expected O, but got Ref
		//IL_0400: Expected O, but got I4
		//IL_0417: Expected I, but got I8
		//IL_033e: Expected I, but got I8
		//IL_01aa: Expected O, but got Ref
		_003C_003Ec__DisplayClass6_0 obj = new _003C_003Ec__DisplayClass6_0();
		obj._003C_003E4__this = this;
		obj.callback = callback;
		List<DlcType> list = new List<DlcType>();
		List<DlcType> includedDlc = DlcSystem.IncludedDlc;
		object obj2 = null;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj6 = default(object);
		IntPtr intPtr = default(IntPtr);
		IntPtr intPtr2 = default(IntPtr);
		while (true)
		{
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ stack_-A8_v13+1C]");
				if (obj4 != null)
				{
					break;
				}
				object obj5 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ stack_-A8_v13+18]");
				if ((nint)obj5 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ stack_-A8_v13+10]");
				object obj7 = 0;
				object obj8 = obj6 + 1;
				DLCSelection dlcSelection = DlcSystem._dlcSelection;
				bool flag = dlcSelection.SelectedDLCs == null;
				SelectedDLCDictionary selectedDLCs = dlcSelection.SelectedDLCs;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rbx_v17+20+v224 @ stack_-A0_v12*4]");
				int num = ((Dictionary<DlcType, bool>)selectedDLCs).FindEntry(DlcType.Moonspell);
				object obj9 = !flag;
				if (obj9 == null)
				{
					string text = ((Enum)(&intPtr)).ToString();
					string message = "Dlc  Included as not found in selected dictionary: " + text;
					Debug.Log(message);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
					obj6 = obj8;
					continue;
				}
				SelectedDLCDictionary selectedDlc = DlcSystem.SelectedDlc;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rbx_v17+20+v224 @ stack_-A0_v12*4]");
				if (!((Dictionary<System.Int32Enum, bool>)(object)selectedDlc).get_Item((System.Int32Enum)0))
				{
					string text2 = ((Enum)(&intPtr2)).ToString();
					string message2 = "Dlc Not Included as not selected: " + text2;
					Debug.Log(message2);
					obj6 = obj8;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v269 @ rbx_v17+20+v224 @ stack_-A0_v12*4]");
					bool flag2 = ((Dictionary<DlcType, bool>)(object)list).get_Item(DlcType.Moonspell);
					obj6 = obj8;
				}
				continue;
			}
			throw new NullReferenceException();
		}
		bool flag3 = obj3 == null;
		obj2 = 0;
		Action action;
		if (!flag3)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ stack_-A8_v13+1C]");
			if (obj4 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				System.ParamsArray paramsArray = new System.ParamsArray(arg);
				System.ParamsArray paramsArray2 = default(System.ParamsArray);
				string message3 = string.FormatHelper((IFormatProvider)null, "Loading selected internal DLCs: {0}", (System.ParamsArray)(&paramsArray2));
				Debug.Log(message3);
				action = null;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ r10_v1 (Il2CppMethodInfo)+8]");
				((Delegate)action).method_ptr = (IntPtr)0;
				((Delegate)action).method = (nint)__ldftn(_003C_003Ec__DisplayClass6_0._003CLoadDlcs_003Eb__0);
				((Delegate)action).m_target = obj;
				((Delegate)action).method_code = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ r10_v1 (Il2CppMethodInfo)+4C]");
				object obj10 = (nint)0 >> 4;
				object obj11 = obj10 & 1;
				nint num3;
				if (obj11 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1003 @ r10_v1 (Il2CppMethodInfo)+52]");
					if ((nint)0 == 0)
					{
						num3 = unchecked((nint)6447293664L);
						goto IL_03f7;
					}
				}
				num3 = ((Delegate)action).method_ptr;
				((Delegate)action).method_code = (IntPtr)((Delegate)action).m_target;
				goto IL_03f7;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			obj2 = null;
		}
		throw new NullReferenceException();
		IL_03f7:
		object obj12 = 24;
		((Delegate)action).extra_arg = unchecked((nint)6447293568L);
		LoadIncludedDlc(0, list, action);
	}

	public unsafe void MountDlc(DlcType dlcType, Action callback)
	{
		//IL_002a: Expected O, but got Ref
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals8.dlcType = dlcType;
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		CS_0024_003C_003E8__locals8.callback = callback;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string message = "Mounting DLC " + text;
		DlcSystem.Log(message);
		SystemPlatform sInstance = SystemPlatform.sInstance;
		Action<string> onComplete = delegate(string path)
		{
			//IL_00e4: Expected O, but got Ref
			//IL_0063: Expected O, but got Ref
			AddressableLoader.SetInternalIdTransform();
			AddressableLoader.SetPath(path);
			object obj2 = default(object);
			if (path != null && path._stringLength > 0)
			{
				string text2 = ((Enum)(&obj2)).ToString();
				string message2 = "Successfully mounted DLC " + text2 + " at path: " + path;
				DlcSystem.Log(message2);
				LoadingManager loadingManager = CS_0024_003C_003E8__locals8._003C_003E4__this;
				bool flag = ((Dictionary<System.Int32Enum, object>)(object)loadingManager._003CMountedPaths_003Ek__BackingField).TryInsert((System.Int32Enum)CS_0024_003C_003E8__locals8.dlcType, (object)path, System.Collections.Generic.InsertionBehavior.None);
				System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
				string text3 = path;
			}
			else
			{
				string text4 = ((Enum)(&obj2)).ToString();
				string message3 = "Failed to mount DLC " + text4 + ", you may need to free up storage space.";
				DlcSystem.Log(message3);
				System.Collections.Generic.InsertionBehavior insertionBehavior = System.Collections.Generic.InsertionBehavior.None;
				string text3 = ", you may need to free up storage space.";
			}
			CS_0024_003C_003E8__locals8._003C_003E4__this.LogAllMountedPaths();
			Action callback2 = CS_0024_003C_003E8__locals8.callback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v245.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		};
		sInstance.m_CurrentSystem.MountDlc(CS_0024_003C_003E8__locals8.dlcType, onComplete);
	}

	private unsafe void LogAllMountedPaths()
	{
		//IL_0064: Expected I4, but got O
		//IL_0094: Expected O, but got Ref
		StringBuilder stringBuilder = new StringBuilder();
		if (stringBuilder != null)
		{
			StringBuilder stringBuilder2 = stringBuilder.Append("All Mounted Paths:");
			string newLine = Environment.NewLine;
			StringBuilder stringBuilder3 = stringBuilder.Append(newLine);
			if (_003CMountedPaths_003Ek__BackingField != null)
			{
				Dictionary<DlcType, string>.Enumerator enumerator = default(Dictionary<DlcType, string>.Enumerator);
				object obj = default(object);
				System.ParamsArray paramsArray2 = default(System.ParamsArray);
				while (enumerator.MoveNext())
				{
					object arg = (DlcType)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
					System.ParamsArray paramsArray = new System.ParamsArray(arg, null);
					string value = string.FormatHelper((IFormatProvider)null, "{0}: {1}", (System.ParamsArray)(&paramsArray2));
					StringBuilder stringBuilder4 = stringBuilder.Append(value);
					string newLine2 = Environment.NewLine;
					StringBuilder stringBuilder5 = stringBuilder.Append(newLine2);
				}
				string message = stringBuilder.ToString();
				Debug.Log(message);
				return;
			}
		}
		throw new NullReferenceException();
	}

	public void UnmountAllDlc(Action callback)
	{
		//IL_004f: Expected O, but got I
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		CS_0024_003C_003E8__locals5.callback = callback;
		DlcSystem.Log("Unmounting All DLC");
		Dictionary<DlcType, string> dictionary = _003CMountedPaths_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v8 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.DlcType, System.String>)+20]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rcx_v8 (System.Collections.Generic.Dictionary`2<VampireSurvivors.Data.DlcType, System.String>)+28]");
		object obj = num - 0;
		if ((nint)obj <= 0)
		{
			Action callback2 = CS_0024_003C_003E8__locals5.callback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v84.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FF2590");
		Action action = delegate
		{
			CS_0024_003C_003E8__locals5._003C_003E4__this.UnmountAllDlc(CS_0024_003C_003E8__locals5.callback);
		};
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 241 Invalid \"Jump target not found in method: 0x186BAE190\"");
		throw new NullReferenceException();
	}

	public unsafe void UnmountDlc(DlcType dlcType, Action callback)
	{
		//IL_001d: Expected O, but got Ref
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals9._003C_003E4__this = this;
		CS_0024_003C_003E8__locals9.dlcType = dlcType;
		CS_0024_003C_003E8__locals9.callback = callback;
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string message = "Unmounting DLC " + text;
		DlcSystem.Log(message);
		SystemPlatform sInstance = SystemPlatform.sInstance;
		Action onComplete = delegate
		{
			//IL_006f: Expected O, but got Ref
			LoadingManager loadingManager = CS_0024_003C_003E8__locals9._003C_003E4__this;
			int num = ((Dictionary<System.Int32Enum, object>)(object)loadingManager._003CMountedPaths_003Ek__BackingField).FindEntry((System.Int32Enum)CS_0024_003C_003E8__locals9.dlcType);
			if (num >= 0)
			{
				LoadingManager loadingManager2 = CS_0024_003C_003E8__locals9._003C_003E4__this;
				bool flag = ((Dictionary<System.Int32Enum, object>)(object)loadingManager2._003CMountedPaths_003Ek__BackingField).Remove((System.Int32Enum)CS_0024_003C_003E8__locals9.dlcType);
			}
			object obj2 = default(object);
			string text2 = ((Enum)(&obj2)).ToString();
			string message2 = "Unmounted DLC " + text2;
			DlcSystem.Log(message2);
			Action callback2 = CS_0024_003C_003E8__locals9.callback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v80.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		};
		sInstance.m_CurrentSystem.UnmountDlc(CS_0024_003C_003E8__locals9.dlcType, onComplete);
	}

	private unsafe void LoadDlc(int index, List<DlcType> dlcsToLoad, Action callback)
	{
		//IL_00cd: Expected O, but got I
		//IL_012d: Expected O, but got Ref
		//IL_019e: Expected I, but got O
		int index2 = index;
		List<DlcType> list = default(List<DlcType>);
		List<DlcType> dlcsToLoad2 = list;
		Action callback2 = callback;
		nint num2 = default(nint);
		while (true)
		{
			_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals26 = new _003C_003Ec__DisplayClass11_0();
			CS_0024_003C_003E8__locals26.index = index2;
			CS_0024_003C_003E8__locals26._003C_003E4__this = this;
			CS_0024_003C_003E8__locals26.dlcsToLoad = dlcsToLoad2;
			CS_0024_003C_003E8__locals26.callback = callback2;
			List<DlcType> dlcsToLoad3 = CS_0024_003C_003E8__locals26.dlcsToLoad;
			int index3 = CS_0024_003C_003E8__locals26.index;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
			if ((nint)index3 < (nint)0)
			{
				List<DlcType> dlcsToLoad4 = CS_0024_003C_003E8__locals26.dlcsToLoad;
				int index4 = CS_0024_003C_003E8__locals26.index;
				int index5 = CS_0024_003C_003E8__locals26.index;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
				if ((nint)index5 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rcx_v14+20+v196 @ rax_v19 (System.Int32)*4]");
				CS_0024_003C_003E8__locals26.dlcType = DlcType.Moonspell;
				Dictionary<DlcType, BundleManifestData> dictionary = _003CLoadedDlc_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rcx_v14+20+v196 @ rax_v19 (System.Int32)*4]");
				int num = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry((System.Int32Enum)0);
				if (num >= 0)
				{
					string text = ((Enum)(&num2)).ToString();
					string message = "Already loaded DLC " + text;
					DlcSystem.Log(message);
					callback2 = CS_0024_003C_003E8__locals26.callback;
					index2 = CS_0024_003C_003E8__locals26.index + 1;
					dlcsToLoad2 = CS_0024_003C_003E8__locals26.dlcsToLoad;
					CS_0024_003C_003E8__locals26.index = index2;
					num2 = (nint)typeof(DlcType);
					continue;
				}
				Action callback3 = delegate
				{
					//IL_0031: Expected O, but got Ref
					//IL_009f: Expected I4, but got O
					if (AddressableLoader._currentAssetBundlePath != null)
					{
						object obj2 = default(object);
						string text2 = ((Enum)(&obj2)).ToString();
						string message2 = "Loading DLC " + text2 + " from path: " + AddressableLoader._currentAssetBundlePath;
						DlcSystem.Log(message2);
						Action<bool> callback5 = CS_0024_003C_003E8__locals26._003C_003E9__1;
						if (CS_0024_003C_003E8__locals26._003C_003E9__1 == null)
						{
							Action<bool> action = null;
							((_003C_003Ec__DisplayClass11_0)(object)action)._003CLoadDlc_003Eb__1((byte)(int)CS_0024_003C_003E8__locals26 != 0);
							CS_0024_003C_003E8__locals26._003C_003E9__1 = action;
							callback5 = action;
						}
						CS_0024_003C_003E8__locals26._003C_003E4__this.LoadManifestDirect(CS_0024_003C_003E8__locals26.dlcType, AddressableLoader._currentAssetBundlePath, callback5);
					}
					else
					{
						int index6 = ++CS_0024_003C_003E8__locals26.index;
						CS_0024_003C_003E8__locals26._003C_003E4__this.LoadDlc(index6, CS_0024_003C_003E8__locals26.dlcsToLoad, CS_0024_003C_003E8__locals26.callback);
					}
				};
				MountDlc(CS_0024_003C_003E8__locals26.dlcType, callback3);
				return;
			}
			Action callback4 = CS_0024_003C_003E8__locals26.callback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v197.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private unsafe void LoadIncludedDlc(int index, List<DlcType> dlcsToLoad, Action callback)
	{
		//IL_00cd: Expected O, but got I
		//IL_01ac: Expected O, but got Ref
		//IL_012d: Expected O, but got Ref
		//IL_01ec: Expected I4, but got O
		//IL_019e: Expected I, but got O
		int index2 = index;
		List<DlcType> list = default(List<DlcType>);
		List<DlcType> dlcsToLoad2 = list;
		Action callback2 = callback;
		nint num2 = default(nint);
		while (true)
		{
			_003C_003Ec__DisplayClass12_0 obj = new _003C_003Ec__DisplayClass12_0();
			obj.index = index2;
			obj._003C_003E4__this = this;
			obj.dlcsToLoad = dlcsToLoad2;
			obj.callback = callback2;
			List<DlcType> dlcsToLoad3 = obj.dlcsToLoad;
			int index3 = obj.index;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ rax_v14 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
			if ((nint)index3 < (nint)0)
			{
				List<DlcType> dlcsToLoad4 = obj.dlcsToLoad;
				int index4 = obj.index;
				int index5 = obj.index;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
				if ((nint)index5 >= (nint)0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v462 @ rcx_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rcx_v14+20+v196 @ rax_v19 (System.Int32)*4]");
				obj.dlcType = DlcType.Moonspell;
				Dictionary<DlcType, BundleManifestData> dictionary = _003CLoadedDlc_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rcx_v14+20+v196 @ rax_v19 (System.Int32)*4]");
				int num = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry((System.Int32Enum)0);
				if (num >= 0)
				{
					string text = ((Enum)(&num2)).ToString();
					string message = "Already loaded DLC " + text;
					DlcSystem.Log(message);
					callback2 = obj.callback;
					index2 = obj.index + 1;
					dlcsToLoad2 = obj.dlcsToLoad;
					obj.index = index2;
					num2 = (nint)typeof(DlcType);
					continue;
				}
				string text2 = ((Enum)(&num2)).ToString();
				string message2 = "Loading included DLC " + text2;
				DlcSystem.Log(message2);
				Action<bool> action = null;
				((_003C_003Ec__DisplayClass12_0)(object)action)._003CLoadIncludedDlc_003Eb__0((byte)(int)obj != 0);
				LoadManifestDirect(obj.dlcType, "", action);
				return;
			}
			Action callback3 = obj.callback;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v197.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			return;
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
	}

	private void LoadManifestDirect(DlcType dlcType, string path, Action<bool> callback)
	{
		_003C_003Ec__DisplayClass13_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass13_0();
		CS_0024_003C_003E8__locals8._003C_003E4__this = this;
		CS_0024_003C_003E8__locals8.dlcType = dlcType;
		CS_0024_003C_003E8__locals8.callback = callback;
		AddressableLoader.SetInternalIdTransform();
		AddressableLoader.SetPath(path);
		Action<BundleManifestData> onComplete = delegate(BundleManifestData bmd)
		{
			DlcLoader.ResetLoader();
			if ((object)bmd != null && ((UnityEngine.Object)bmd).m_CachedPtr != (IntPtr)0)
			{
				LoadingManager loadingManager = CS_0024_003C_003E8__locals8._003C_003E4__this;
				bool flag = ((Dictionary<System.Int32Enum, object>)(object)loadingManager._003CLoadedDlc_003Ek__BackingField).TryInsert((System.Int32Enum)CS_0024_003C_003E8__locals8.dlcType, (object)bmd, System.Collections.Generic.InsertionBehavior.None);
				Action<bool> callback2 = CS_0024_003C_003E8__locals8.callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v175 @ rax_v17 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
			else
			{
				Action<bool> callback3 = CS_0024_003C_003E8__locals8.callback;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v146 @ rax_v10 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		};
		DlcLoader.LoadDlc(CS_0024_003C_003E8__locals8.dlcType, onComplete);
	}

	public void ValidateDlcVersions(Action callback)
	{
		//IL_0013: Expected I, but got O
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007b: Expected O, but got I
		nint num = (nint)typeof(DlcType);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		if (num != 0)
		{
			object obj3 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v138 @ rdx_v6+8F8] (should have been resolved before IL gen)");
			DlcType[] array = default(DlcType[]);
			if (array != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				if (array == null)
				{
					throw new InvalidCastException();
				}
			}
			ValidateVersion(0, array, callback);
			return;
		}
		ArgumentNullException ex = new ArgumentNullException("enumType");
		throw ex;
	}

	private unsafe void ValidateVersion(int index, DlcType[] dlcs, Action callback)
	{
		//IL_00c1: Expected O, but got I
		//IL_00ea: Expected O, but got I
		//IL_0138: Expected O, but got I
		//IL_018c: Expected O, but got I
		//IL_01cb: Expected O, but got I
		//IL_01f3: Expected O, but got I
		//IL_0215: Expected O, but got I
		//IL_03e6: Expected O, but got I
		//IL_0435: Expected I4, but got O
		//IL_0435: Expected I4, but got O
		//IL_0435: Expected O, but got I4
		//IL_0302: Expected I8, but got I
		//IL_0348: Expected O, but got I8
		int num = default(int);
		int index2 = num;
		DlcType[] array = default(DlcType[]);
		DlcType[] dlcs2 = array;
		Action action = default(Action);
		Action callback2 = action;
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals17;
		bool flag6 = default(bool);
		GameObject gameObject = default(GameObject);
		string text = default(string);
		bool flag7 = default(bool);
		while (true)
		{
			CS_0024_003C_003E8__locals17 = new _003C_003Ec__DisplayClass15_0();
			CS_0024_003C_003E8__locals17.index = index2;
			CS_0024_003C_003E8__locals17._003C_003E4__this = this;
			CS_0024_003C_003E8__locals17.dlcs = dlcs2;
			CS_0024_003C_003E8__locals17.callback = callback2;
			DlcType[] dlcs3 = CS_0024_003C_003E8__locals17.dlcs;
			if (CS_0024_003C_003E8__locals17.index >= dlcs3.Length)
			{
				break;
			}
			DlcType[] dlcs4 = CS_0024_003C_003E8__locals17.dlcs;
			int index3 = CS_0024_003C_003E8__locals17.index;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186B58C00");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ rax_v19+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v11 (VampireSurvivors.Data.DlcType[])+20+v463 @ rax_v17 (System.Int32)*4]");
			int num3 = ((Dictionary<System.Int32Enum, object>)num2).FindEntry((System.Int32Enum)0);
			bool flag = num3 < 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v11 (VampireSurvivors.Data.DlcType[])+20+v463 @ rax_v17 (System.Int32)*4]");
			num = 0;
			array = (DlcType[])0;
			if (!flag)
			{
				Dictionary<DlcType, BundleManifestData> dictionary = _003CLoadedDlc_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v11 (VampireSurvivors.Data.DlcType[])+20+v463 @ rax_v17 (System.Int32)*4]");
				int num4 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).FindEntry((System.Int32Enum)0);
				bool flag2 = num4 < 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v11 (VampireSurvivors.Data.DlcType[])+20+v463 @ rax_v17 (System.Int32)*4]");
				num = 0;
				array = (DlcType[])0;
				if (!flag2)
				{
					Type typeFromHandle = typeof(DlcSystem);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v11 (VampireSurvivors.Data.DlcType[])+20+v463 @ rax_v17 (System.Int32)*4]");
					int num5 = ((Dictionary<DlcType, BundleManifestData>)(object)typeFromHandle).FindEntry(DlcType.Moonspell);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ rax_v28 (System.Int32)+18]");
					nint num6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v11 (VampireSurvivors.Data.DlcType[])+20+v463 @ rax_v17 (System.Int32)*4]");
					object obj = ((Dictionary<System.Int32Enum, object>)num6).get_Item((System.Int32Enum)0);
					Dictionary<DlcType, BundleManifestData> dictionary2 = _003CLoadedDlc_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v465 @ rcx_v11 (VampireSurvivors.Data.DlcType[])+20+v463 @ rax_v17 (System.Int32)*4]");
					object obj2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).get_Item((System.Int32Enum)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v29 (System.Object)+40]");
					string message = "Expected Version: " + (string)0;
					DlcSystem.Log(message);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v30 (System.Object)+18]");
					string message2 = "Actual Version: " + (string)0;
					DlcSystem.Log(message2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v29 (System.Object)+40]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v30 (System.Object)+18]");
					num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v29 (System.Object)+40]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v30 (System.Object)+18]");
					bool flag3 = num7 == 0;
					array = null;
					if (!flag3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v29 (System.Object)+40]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v30 (System.Object)+18]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v736 @ rcx_v23+10]");
								nint num8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ rdx_v6 (System.Int32)+10]");
								if (num8 == 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ rax_v30 (System.Object)+18]");
									ref byte reference = ref *(byte*)((nint)0 + (nint)20);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v736 @ rcx_v23+10]");
									nint num9 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v736 @ rcx_v23+10]");
									ulong num10 = (ulong)(num9 + 0);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v29 (System.Object)+40]");
									bool flag4 = System.SpanHelpers.SequenceEqual(ref *(byte*)((nint)0 + (nint)20), ref reference, num10);
									bool flag5 = !flag4;
									num = (int)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
									array = (DlcType[])num10;
									if (!flag5)
									{
										goto IL_0356;
									}
								}
							}
						}
						string translation = LocalizationManager.GetTranslation("lang/dlc_update_descriptions", FixForRTL: true, 0, ignoreRTLnumbers: true, flag6, gameObject, text, flag7);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rax_v29 (System.Object)+18]");
						string description = translation.Replace("%0", (string)0);
						Action action2 = delegate
						{
							int index4 = ++CS_0024_003C_003E8__locals17.index;
							CS_0024_003C_003E8__locals17._003C_003E4__this.ValidateVersion(index4, CS_0024_003C_003E8__locals17.dlcs, CS_0024_003C_003E8__locals17.callback);
						};
						PopupManager.CreateHelpPopup("dlc-version-error", "lang/dlc_update_title", description, "lang/dlc_update_help", (string)flag6, (string)(object)gameObject, (Action)(object)text, flag7, (byte)(int)"https://poncle.games/dlc-help" != 0, (byte)(int)"dlc-help-qr" != 0);
						return;
					}
				}
			}
			goto IL_0356;
			IL_0356:
			callback2 = CS_0024_003C_003E8__locals17.callback;
			index2 = CS_0024_003C_003E8__locals17.index + 1;
			dlcs2 = CS_0024_003C_003E8__locals17.dlcs;
			CS_0024_003C_003E8__locals17.index = index2;
		}
		Action callback3 = CS_0024_003C_003E8__locals17.callback;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v295.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
	}

	public LoadingManager()
	{
		Dictionary<DlcType, string> dictionary = new Dictionary<DlcType, string>();
		_003CMountedPaths_003Ek__BackingField = dictionary;
		Dictionary<DlcType, BundleManifestData> dictionary2 = new Dictionary<DlcType, BundleManifestData>();
		_003CLoadedDlc_003Ek__BackingField = dictionary2;
	}
}
