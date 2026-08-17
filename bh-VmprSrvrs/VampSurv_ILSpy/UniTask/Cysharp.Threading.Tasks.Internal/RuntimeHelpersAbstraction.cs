using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Cysharp.Threading.Tasks.Internal;

internal static class RuntimeHelpersAbstraction
{
	private static class WellKnownNoReferenceContainsType<T>
	{
		public static readonly bool IsWellKnownType;

		static WellKnownNoReferenceContainsType()
		{
			//IL_0061: Expected O, but got I
			//IL_0077: Expected O, but got I
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_00c7: Expected O, but got I
			//IL_00cf: Expected O, but got I4
			//IL_00a4: Expected O, but got I
			//IL_00ac: Expected O, but got I4
			nint num = 0;
			Type t = default(Type);
			if (num != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj2 = default(object);
				object obj = obj2 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			}
			else
			{
				t = null;
			}
			bool flag = WellKnownNoReferenceContainsTypeInitialize(t);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ rax_v8 (Il2CppRgctx<Cysharp.Threading.Tasks.Internal.RuntimeHelpersAbstraction+WellKnownNoReferenceContainsType`1>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v7+135]");
			object obj4 = (nint)0 & (nint)1;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rcx_v7+B8]");
				object obj5 = 0;
				obj5 = flag;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0570");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rax_v9+B8]");
				object obj6 = 0;
				obj6 = flag;
			}
		}
	}

	public static bool IsWellKnownNoReferenceContainsType<T>()
	{
		//IL_002b: Expected O, but got I
		//IL_0068: Expected O, but got I
		//IL_006d: Expected I4, but got O
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rcx_v3 (Il2CppClass<Cysharp.Threading.Tasks.Internal.RuntimeHelpersAbstraction+WellKnownNoReferenceContainsType`1<T>>)+135]");
		object obj = (nint)0 & (nint)1;
		if (obj != null)
		{
			return WellKnownNoReferenceContainsType<T>.IsWellKnownType;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0570");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rax_v7+B8]");
		object obj2 = 0;
		return (byte)(int)obj2 != 0;
	}

	private static bool WellKnownNoReferenceContainsTypeInitialize(Type t)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_0469: Expected I4, but got O
		Type[] genericArguments = default(Type[]);
		object obj2 = default(object);
		object obj3 = default(object);
		while (true)
		{
			if (!genericArguments[0].IsPrimitiveImpl() && !genericArguments[0].IsEnum)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
				object obj = obj2 + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
				if (genericArguments[0] != obj3)
				{
					Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(DateTimeOffset));
					if ((object)genericArguments[0] != typeFromHandle)
					{
						Type typeFromHandle2 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Guid));
						if ((object)genericArguments[0] != typeFromHandle2)
						{
							Type typeFromHandle3 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(decimal));
							if ((object)genericArguments[0] != typeFromHandle3)
							{
								if (genericArguments[0].IsGenericType)
								{
									Type genericTypeDefinition = genericArguments[0].GetGenericTypeDefinition();
									Type typeFromHandle4 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Nullable<>));
									if ((object)genericTypeDefinition == typeFromHandle4)
									{
										genericArguments = genericArguments[0].GetGenericArguments();
										if (genericArguments.Length <= 0)
										{
											break;
										}
										continue;
									}
								}
								Type typeFromHandle5 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Vector2));
								if ((object)genericArguments[0] != typeFromHandle5)
								{
									Type typeFromHandle6 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Vector3));
									if ((object)genericArguments[0] != typeFromHandle6)
									{
										Type typeFromHandle7 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Vector4));
										if ((object)genericArguments[0] != typeFromHandle7)
										{
											Type typeFromHandle8 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Color));
											if ((object)genericArguments[0] != typeFromHandle8)
											{
												Type typeFromHandle9 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Rect));
												if ((object)genericArguments[0] != typeFromHandle9)
												{
													Type typeFromHandle10 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Bounds));
													if ((object)genericArguments[0] != typeFromHandle10)
													{
														Type typeFromHandle11 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Quaternion));
														if ((object)genericArguments[0] != typeFromHandle11)
														{
															Type typeFromHandle12 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Vector2Int));
															if ((object)genericArguments[0] != typeFromHandle12)
															{
																Type typeFromHandle13 = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(Vector3Int));
																if ((object)genericArguments[0] != typeFromHandle13)
																{
																	return false;
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return true;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}
}
