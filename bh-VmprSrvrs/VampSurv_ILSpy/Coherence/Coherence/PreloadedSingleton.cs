using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Coherence;

public abstract class PreloadedSingleton : ScriptableObject
{
	public abstract bool IsActiveInstance { get; }
}
public abstract class PreloadedSingleton<T> : PreloadedSingleton where T : ScriptableObject
{
	private static T _instance;

	public static T instance
	{
		get
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183AEDBA0");
			T result = default(T);
			return result;
		}
	}

	internal static T InstanceUnsafe
	{
		get
		{
			//IL_001b: Expected O, but got I
			//IL_0031: Expected O, but got I
			//IL_007d: Expected O, but got I
			//IL_005e: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rax_v3 (Il2CppRgctx<Coherence.PreloadedSingleton`1>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rcx_v2+135]");
			object obj2 = (nint)0 & (nint)1;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ rcx_v2+B8]");
				return (T)0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0570");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rax_v4+B8]");
			return (T)0;
		}
	}

	public static T Instance
	{
		get
		{
			//IL_001b: Expected O, but got I
			//IL_0030: Expected O, but got I
			//IL_0092: Expected O, but got I
			//IL_00a7: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ rax_v4 (Il2CppRgctx<Coherence.PreloadedSingleton`1>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v6+B8]");
			object obj2 = 0;
			object obj3 = obj2;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rbx_v1+10]");
				bool flag = (nint)0 == 0;
				nint num2 = 0;
				if (!flag)
				{
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ rax_v30 (Il2CppRgctx<Coherence.PreloadedSingleton`1>)+8]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rax_v32+B8]");
					return (T)0;
				}
			}
			else
			{
				nint num2 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003490");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002B70");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002BB0");
			RuntimeTypeHandle handle = default(RuntimeTypeHandle);
			Type typeFromHandle = Type.GetTypeFromHandle(handle);
			throw new NullReferenceException();
		}
		private set
		{
			//IL_001b: Expected O, but got I
			//IL_0030: Expected O, but got I
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ rax_v3 (Il2CppRgctx<Coherence.PreloadedSingleton`1>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v5+B8]");
			object obj2 = 0;
			obj2 = value;
		}
	}

	public override bool IsActiveInstance
	{
		get
		{
			//IL_010a: Expected O, but got I
			//IL_0015: Expected O, but got I
			//IL_013c: Expected O, but got I4
			//IL_0156: Expected O, but got I4
			//IL_00f4: Expected I4, but got O
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdx_v1 (Il2CppRgctx<Coherence.PreloadedSingleton`1>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ rax_v4+B8]");
			object obj2 = 0;
			object obj3 = obj2;
			bool flag = obj2 == null;
			bool flag2 = (object)this == null;
			object obj4 = flag2 & flag;
			bool flag3 = obj4 == null;
			object obj5 = !flag3;
			if (obj5 == null)
			{
				if ((object)this != null)
				{
					if (obj2 != null)
					{
						object obj6 = obj2 - (object)this;
						return obj6 == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.PreloadedSingleton`1<T>)+10]");
					return (nint)0 == 0;
				}
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rbx_v2+10]");
					return (nint)0 == 0;
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return true;
		}
	}

	protected virtual void OnEnable()
	{
		//IL_0102: Expected O, but got I
		//IL_0015: Expected O, but got I
		//IL_00af: Expected O, but got I
		//IL_00c4: Expected O, but got I
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ r8_v1 (Il2CppRgctx<Coherence.PreloadedSingleton`1>)+8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v4+B8]");
		object obj2 = 0;
		object obj3 = obj2;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rsi_v1+10]");
			if ((nint)0 != 0 && !((PreloadedSingleton<>)(object)this).IsActiveInstance)
			{
				UnityEngine.Object.Destroy(this, 0f);
				return;
			}
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v208 @ rdx_v3 (Il2CppRgctx<Coherence.PreloadedSingleton`1>)+8]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ rax_v16+B8]");
		object obj5 = 0;
		object obj6 = default(object);
		obj5 = obj6;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
	}

	protected virtual void OnDisable()
	{
		//IL_0112: Expected O, but got I
		//IL_0015: Expected O, but got I
		//IL_0144: Expected O, but got I4
		//IL_015e: Expected O, but got I4
		//IL_00d9: Expected O, but got I
		//IL_00ee: Expected O, but got I
		//IL_00f7: Expected O, but got I4
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ r8_v1 (Il2CppRgctx<Coherence.PreloadedSingleton`1>)+8]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v4+B8]");
		object obj2 = 0;
		object obj3 = obj2;
		bool flag = obj2 == null;
		bool flag2 = (object)this == null;
		object obj4 = flag2 & flag;
		bool flag3 = obj4 == null;
		object obj5 = !flag3;
		if (obj5 == null)
		{
			bool flag4;
			if ((object)this != null)
			{
				if (obj2 != null)
				{
					object obj6 = obj2 - (object)this;
					flag4 = obj6 == null;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Coherence.PreloadedSingleton`1<T>)+10]");
					flag4 = (nint)0 == 0;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rbx_v1+10]");
				flag4 = (nint)0 == 0;
			}
			if (!flag4)
			{
				return;
			}
		}
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ rcx_v10 (Il2CppRgctx<Coherence.PreloadedSingleton`1>)+8]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ rax_v15+B8]");
		object obj8 = 0;
		obj8 = 0;
	}
}
