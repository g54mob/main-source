using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Loading;

public static class LoaderUtils
{
	private sealed class _003C_003Ec__DisplayClass3_0<T>
	{
		public AsyncOperationHandle<T> operationHandle;

		public string errorPrefix;

		public Action<T> onError;

		public Action<T> onComplete;

		internal unsafe void _003CWaitForAsyncLoad_003Eg__OnAsyncLoadComplete_007C0(AsyncOperationHandle<T> handle)
		{
			//IL_0031: Expected O, but got I
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_00ff: Expected O, but got I
			//IL_0095: Expected O, but got I
			//IL_0121: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v1 (Il2CppRgctx<VampireSurvivors.Framework.Loading.LoaderUtils+<>c__DisplayClass3_0`1>)+10]");
			Action<AsyncOperationHandle<object>> value = new Action<AsyncOperationHandle<object>>(this, (IntPtr)0);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v1 (Il2CppRgctx<VampireSurvivors.Framework.Loading.LoaderUtils+<>c__DisplayClass3_0`1>)+20]");
			string text = (string)0;
			AsyncOperationHandle<object> asyncOperationHandle = (AsyncOperationHandle<object>)(this + 16);
			((AsyncOperationHandle<object>*)asyncOperationHandle)->Completed -= value;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1841311C0");
			object obj = default(object);
			object obj2;
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.Loading.LoaderUtils+<>c__DisplayClass3_0`1<T>)+38]");
				obj2 = 0;
			}
			else
			{
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1841311C0");
				object obj4 = default(object);
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v174 @ rdx_v11+188] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.Loading.LoaderUtils+<>c__DisplayClass3_0`1<T>)+28]");
				string text2 = default(string);
				string message = "[" + (string)0 + "] - " + text2;
				Debug.LogError(message);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.Framework.Loading.LoaderUtils+<>c__DisplayClass3_0`1<T>)+30]");
				obj2 = 0;
				text = text2;
			}
			if (obj2 != null)
			{
				nint num5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184132A60");
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v106 @ rbx_v2+18] (should have been resolved before IL gen)");
			}
		}
	}

	public static readonly Type TEX2DType;

	public static readonly Type VideoClipType;

	public static string GetDynamicLabel(DlcType? dlcType)
	{
		if ((object)dlcType == null)
		{
			return "vs_local";
		}
		System.Int32Enum? int32Enum = default(System.Int32Enum?);
		string text = int32Enum.ToString();
		if (text != null)
		{
			string text2 = text.ToLowerInvariant();
			return text2 + "_dynamic";
		}
		return (string)(object)new NullReferenceException();
	}

	public unsafe static void WaitForAsyncLoad<T>(AsyncOperationHandle<T> operationHandle, Action<T> onComplete, Action<T> onError, string errorPrefix = "WaitForAsyncLoad", bool forceSync = false)
	{
		//IL_006f: Expected O, but got I
		//IL_00a0: Expected I, but got O
		//IL_015f: Expected O, but got I
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_0127: Expected O, but got I
		//IL_00bf: Expected O, but got I
		//IL_00de: Expected O, but got I
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_30+38]");
		if ((nint)0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_30+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC05F0");
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_30+38]");
		object obj = 0;
		object obj2 = null;
		_ = operationHandle.m_InternalOp;
		nint num = (nint)typeof(AddressableLoader);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_30+38]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ rcx_v8 (Il2CppClass<VampireSurvivors.Framework.Loading.AddressableLoader>)+E4]");
		if ((nint)0 == 0)
		{
			object obj4 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_30+38]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18330E270");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_30+38]");
			object obj6 = 0;
			object obj7 = obj2 + 16;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184131E30");
		}
		else
		{
			AsyncOperationHandle<object> asyncOperationHandle = (AsyncOperationHandle<object>)(obj2 + 16);
			object obj8 = ((AsyncOperationHandle<object>*)asyncOperationHandle)->WaitForCompletion();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v13 @ stack_30+38]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183A9C670");
		}
	}

	static LoaderUtils()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		Type tEX2DType = type;
		TEX2DType = tEX2DType;
		Type type2 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj4 = default(object);
		object obj3 = obj4 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type3 = default(Type);
		type2 = type3;
		VideoClipType = type2;
	}
}
