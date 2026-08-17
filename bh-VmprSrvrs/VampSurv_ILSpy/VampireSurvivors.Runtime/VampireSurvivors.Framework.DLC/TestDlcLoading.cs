using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Profiling;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.App.Scripts.Tools;
using VampireSurvivors.Framework.Loading;

namespace VampireSurvivors.Framework.DLC;

public class TestDlcLoading : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public AssetLabelReference labelReference;

		public TestDlcLoading _003C_003E4__this;

		internal void _003CLoadAddressableGroup_003Eb__1(Action cb)
		{
			_003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass5_1();
			CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1 = this;
			CS_0024_003C_003E8__locals5.cb = cb;
			Action<object> action = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2BBE]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				_003C_003E4__this.LogDebug("Asset finished loading");
			};
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rbx_v6 (Il2CppMethodInfo)+38]");
			if ((nint)0 == 0)
			{
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F9A6F0");
			Action<AsyncOperationHandle<IList<object>>> value = delegate
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2BC0]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				_003C_003Ec__DisplayClass5_0 obj2 = CS_0024_003C_003E8__locals5.CS_0024_003C_003E8__locals1;
				AssetLabelReference assetLabelReference = obj2.labelReference;
				string message = "Group finished loading: " + assetLabelReference.m_LabelString;
				obj2._003C_003E4__this.LogDebug(message);
				Action cb2 = CS_0024_003C_003E8__locals5.cb;
				if (CS_0024_003C_003E8__locals5.cb != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v119.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
				}
			};
			AsyncOperationBase<IList<object>> asyncOperationBase = default(AsyncOperationBase<IList<object>>);
			object obj = default(object);
			if (asyncOperationBase != null && asyncOperationBase.m_Version == (nint)obj)
			{
				asyncOperationBase.Completed += value;
				return;
			}
			Exception ex = new Exception("Attempting to use an invalid operation handle");
			ex._002Ector("Attempting to use an invalid operation handle");
			throw ex;
		}
	}

	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public Action cb;

		public _003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals1;

		internal void _003CLoadAddressableGroup_003Eb__3(AsyncOperationHandle<IList<object>> handle)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2BC0]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			_003C_003Ec__DisplayClass5_0 obj = CS_0024_003C_003E8__locals1;
			AssetLabelReference labelReference = obj.labelReference;
			string message = "Group finished loading: " + labelReference.m_LabelString;
			obj._003C_003E4__this.LogDebug(message);
			Action action = cb;
			if (cb != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v119.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	private List<AssetLabelReference> _GroupLabels;

	private long _allocatedOnBoot;

	private bool _hasLoaded;

	private void Update()
	{
		//IL_0032: Expected O, but got I4
		//IL_005d: Expected O, but got I4
		object obj = Input.GetKeyDownInt(KeyCode.Space);
		if (obj != null)
		{
			TryLoad();
		}
		object obj2 = Input.GetMouseButtonDown(0);
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 92 Invalid \"Jump target not found in method: 0x186BA9980\"");
		}
	}

	private void TryLoad()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2BBA]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!_hasLoaded)
		{
			_hasLoaded = true;
			LogDebug("Memory before loading");
			MemorySystem.LogMemoryStats();
			long totalAllocatedMemoryLong = Profiler.GetTotalAllocatedMemoryLong();
			_allocatedOnBoot = totalAllocatedMemoryLong;
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 73 Invalid \"Jump target not found in method: 0x186BA9A30\"");
		}
	}

	private unsafe void LoadAddressableGroup()
	{
		//IL_005e: Expected I, but got O
		Action onComplete = delegate
		{
			//IL_005c: Expected O, but got I8
			//IL_008c: Expected O, but got Ref
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2BBD]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			LogDebug("Memory after loading");
			MemorySystem.LogMemoryStats();
			object obj = Profiler.GetTotalAllocatedMemoryLong();
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,rax\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			object obj2 = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Those People memory allocation: {0}mb", (System.ParamsArray)(&obj2));
			LogDebug(message);
		};
		AsyncLoader asyncLoader = new AsyncLoader(onComplete);
		asyncLoader._002Ector(onComplete);
		if (_GroupLabels != null)
		{
			List<AssetLabelReference>.Enumerator enumerator = default(List<AssetLabelReference>.Enumerator);
			while (enumerator.MoveNext())
			{
				_003C_003Ec__DisplayClass5_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass5_0();
				bool flag = CS_0024_003C_003E8__locals8 == null;
				nint num = (nint)typeof(_003C_003Ec__DisplayClass5_0);
				if (!flag)
				{
					CS_0024_003C_003E8__locals8._003C_003E4__this = this;
					CS_0024_003C_003E8__locals8.labelReference = null;
					Action<Action> loadCall = delegate(Action cb)
					{
						_003C_003Ec__DisplayClass5_1 CS_0024_003C_003E8__locals11 = new _003C_003Ec__DisplayClass5_1();
						CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals8;
						CS_0024_003C_003E8__locals11.cb = cb;
						Action<object> action = delegate
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2BBE]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							CS_0024_003C_003E8__locals8._003C_003E4__this.LogDebug("Asset finished loading");
						};
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ rbx_v6 (Il2CppMethodInfo)+38]");
						if ((nint)0 == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182F9A6F0");
						Action<AsyncOperationHandle<IList<object>>> value = delegate
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2BC0]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							_003C_003Ec__DisplayClass5_0 obj2 = CS_0024_003C_003E8__locals11.CS_0024_003C_003E8__locals1;
							AssetLabelReference labelReference = obj2.labelReference;
							string message = "Group finished loading: " + labelReference.m_LabelString;
							obj2._003C_003E4__this.LogDebug(message);
							Action cb2 = CS_0024_003C_003E8__locals11.cb;
							if (CS_0024_003C_003E8__locals11.cb != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v119.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
							}
						};
						AsyncOperationBase<IList<object>> asyncOperationBase = default(AsyncOperationBase<IList<object>>);
						object obj = default(object);
						if (asyncOperationBase != null && asyncOperationBase.m_Version == (nint)obj)
						{
							asyncOperationBase.Completed += value;
							return;
						}
						Exception ex = new Exception("Attempting to use an invalid operation handle");
						ex._002Ector("Attempting to use an invalid operation handle");
						throw ex;
					};
					if (asyncLoader != null)
					{
						asyncLoader.Add(loadCall);
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			if (asyncLoader != null)
			{
				asyncLoader.Load();
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void LogDebug(string message)
	{
		string message2 = "[TestDlcLoading] " + message;
		Debug.Log(message2);
	}

	public TestDlcLoading()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}

	private unsafe void _003CLoadAddressableGroup_003Eb__5_0()
	{
		//IL_005c: Expected O, but got I8
		//IL_008c: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2BBD]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		LogDebug("Memory after loading");
		MemorySystem.LogMemoryStats();
		object obj = Profiler.GetTotalAllocatedMemoryLong();
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,rax\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj2 = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Those People memory allocation: {0}mb", (System.ParamsArray)(&obj2));
		LogDebug(message);
	}

	private void _003CLoadAddressableGroup_003Eb__5_2(object o)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2BBE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		LogDebug("Asset finished loading");
	}
}
