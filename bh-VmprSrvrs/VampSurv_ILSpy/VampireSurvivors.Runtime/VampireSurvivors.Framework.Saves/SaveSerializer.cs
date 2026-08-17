using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Newtonsoft.Json;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Data.Props;

namespace VampireSurvivors.Framework.Saves;

public class SaveSerializer
{
	private StringWriter _stringWriter;

	private JsonTextWriter _writer;

	private PlayerOptionsData _pod;

	public SaveSerializer()
	{
		StringWriter stringWriter = new StringWriter();
		_stringWriter = stringWriter;
		JsonTextWriter writer = new JsonTextWriter(_stringWriter);
		_writer = writer;
	}

	public static string Serialize(PlayerOptionsData playerOptionsData)
	{
		SaveSerializer saveSerializer = new SaveSerializer();
		if (saveSerializer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 49 Invalid \"Jump target not found in method: 0x186B33570\"");
		}
		return (string)(object)new NullReferenceException();
	}

	public string SerializePOD(PlayerOptionsData pod, string prefix = "")
	{
		_pod = pod;
		if (_writer != null)
		{
			Dictionary<string, MethodInfo> cachedParsers = SaveUtils._cachedParsers;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v126 @ rdx_v5 (System.Collections.Generic.Dictionary`2<System.String, System.Reflection.MethodInfo>)+578] (should have been resolved before IL gen)");
			Dictionary<string, MethodInfo> cachedSerializers = SaveUtils._cachedSerializers;
			if (SaveUtils._cachedSerializers != null)
			{
				string text2 = default(string);
				string text = text2;
				Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
				if (enumerator.MoveNext())
				{
					string name = text2 + null;
					if (_writer != null)
					{
						_writer.WritePropertyName(name);
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				if (_writer != null)
				{
					Dictionary<string, MethodInfo> cachedParsers2 = SaveUtils._cachedParsers;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v584 @ rax_v21 (System.Collections.Generic.Dictionary`2<System.String, System.Reflection.MethodInfo>)+588] (should have been resolved before IL gen)");
					if (_stringWriter != null)
					{
						Dictionary<string, MethodInfo> cachedParsers3 = SaveUtils._cachedParsers;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v587 @ rdx_v11 (System.Collections.Generic.Dictionary`2<System.String, System.Reflection.MethodInfo>)+168] (should have been resolved before IL gen)");
						if (_writer != null)
						{
							Dictionary<string, MethodInfo> cachedParsers4 = SaveUtils._cachedParsers;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v202 @ r8_v7 (System.Collections.Generic.Dictionary`2<System.String, System.Reflection.MethodInfo>)+558] (should have been resolved before IL gen)");
							if (_stringWriter != null)
							{
								Dictionary<string, MethodInfo> cachedParsers5 = SaveUtils._cachedParsers;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v589 @ rax_v26 (System.Collections.Generic.Dictionary`2<System.String, System.Reflection.MethodInfo>)+1F8] (should have been resolved before IL gen)");
								string result = default(string);
								return result;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SerializeEnumArray<T>(List<T> array, List<T> exclude = null)
	{
		//IL_01b8: Expected O, but got I
		//IL_01c8: Expected O, but got I
		//IL_0139: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_0104: Expected O, but got Ref
		//IL_00c3: Expected O, but got I
		_writer.WriteStartArray();
		List<T> list = null;
		object obj3 = default(object);
		object obj4 = default(object);
		object obj6 = default(object);
		object obj10 = default(object);
		object obj11 = default(object);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ stack_20_v9+38]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v359 @ rax_v25+40]");
			object obj2 = 0;
			if (obj3 == null)
			{
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ stack_-78_v9+1C]");
			if (obj4 == null)
			{
				object obj5 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ stack_-78_v9+18]");
				if ((nint)obj5 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ stack_-78_v9+10]");
					object obj7 = 0;
					object obj8 = obj6 + 1;
					if (exclude != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ stack_20_v9+38]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804FD860");
						bool flag = obj10 != null;
						obj6 = obj8;
						if (flag)
						{
							continue;
						}
					}
					string value = ((Enum)(&obj11)).ToString();
					_writer.WriteValue(value);
					obj6 = obj8;
					continue;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ r9_v9+20]");
			list = (List<T>)0;
			if (obj3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ stack_-78_v9+1C]");
				if (obj4 == null)
				{
					_writer.WriteEndArray();
					return;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				list = null;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	private unsafe void SerializeEnumArrayAsIntArray<T>(List<T> array, List<T> exclude = null)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0028: Expected O, but got I
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_03dc: Expected O, but got I
		//IL_005a: Expected O, but got I8
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Expected O, but got Unknown
		//IL_0420: Expected O, but got Ref
		//IL_0436: Expected O, but got I
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Expected O, but got Unknown
		//IL_048d: Expected O, but got I
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Expected O, but got Unknown
		//IL_04ee: Expected O, but got I
		//IL_006c: Expected O, but got I8
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0520: Expected O, but got Unknown
		//IL_007e: Expected O, but got I8
		//IL_0090: Expected O, but got I8
		//IL_00d5: Expected O, but got I
		//IL_00e5: Expected O, but got I
		//IL_00f5: Expected O, but got I
		//IL_0110: Expected O, but got Ref
		//IL_0132: Expected O, but got Ref
		//IL_0145: Expected O, but got Ref
		//IL_0158: Expected O, but got Ref
		//IL_05e5: Expected O, but got I
		//IL_05f5: Expected O, but got I
		//IL_0605: Expected O, but got I
		//IL_0337: Expected O, but got Ref
		//IL_0351: Expected O, but got I
		//IL_0192: Expected O, but got I
		//IL_01a2: Expected O, but got I
		//IL_01b2: Expected O, but got I
		//IL_01c5: Expected O, but got Ref
		//IL_02a7: Expected O, but got I
		//IL_02b7: Expected O, but got I
		//IL_02c7: Expected O, but got I
		//IL_0218: Expected O, but got I
		//IL_0228: Expected O, but got I
		//IL_0238: Expected O, but got I
		//IL_024e: Expected O, but got I
		//IL_0268: Expected O, but got Ref
		//IL_056d: Expected O, but got I
		//IL_057d: Expected O, but got I
		//IL_0590: Expected O, but got Ref
		//IL_02fd: Expected I, but got O
		//IL_030d: Expected O, but got I
		object obj2 = default(object);
		object obj = (object)(&obj2);
		nint num = 0;
		nint num2 = 0;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rax_v4 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]");
		object obj3 = (nint)0 + (nint)16;
		object obj4 = obj3 + 15;
		object obj5;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			_ = ref obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rcx_v2 (Il2CppClass<T>)+FC]");
			obj5 = (nint)0 + (nint)15;
			object obj6 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rcx_v2 (Il2CppClass<T>)+FC]");
			if ((nint)obj6 > 0)
			{
				goto IL_0400;
			}
		}
		obj5 = 1152921504606846960L;
		goto IL_0400;
		IL_0400:
		object obj7 = obj5 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		object obj8 = (object)(&obj2);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r9_v1 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]");
		object obj9 = (nint)0 + (nint)15;
		object obj10 = obj9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r9_v1 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]");
		if ((nint)obj10 <= 0)
		{
			obj9 = 1152921504606846960L;
		}
		object obj11 = obj9 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r9_v1 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]");
		object obj12 = (nint)0 + (nint)15;
		object obj13 = obj12;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ r9_v1 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]");
		if ((nint)obj13 <= 0)
		{
			obj12 = 1152921504606846960L;
		}
		object obj14 = obj12 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		_ = ref obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rcx_v2 (Il2CppClass<T>)+FC]");
		object obj15 = (nint)0 + (nint)15;
		object obj16 = obj15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ rcx_v2 (Il2CppClass<T>)+FC]");
		bool flag = (nint)obj16 > 0;
		if (!flag)
		{
			obj15 = 1152921504606846960L;
		}
		object obj17 = obj15 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		JsonTextWriter writer = _writer;
		if (_writer != null)
		{
			_writer.WriteStartArray();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+A8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+B8]");
				object obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v256 @ rcx_v28+38]");
				object obj19 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ rax_v42+8]");
				object obj20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+8]");
				_ = 0;
				object obj21 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v258 @ rdx_v10+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				object obj22 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 184));
				object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 24));
				object obj24 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 16));
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+50]");
				_ = 0;
				object obj28 = default(object);
				object value = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+B8]");
					object obj25 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rdx_v13+38]");
					object obj26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rax_v50+38]");
					object obj27 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v383 @ rcx_v32] (should have been resolved before IL gen)");
					if (obj28 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+B8]");
					object obj29 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ rcx_v37+38]");
					object obj30 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ rax_v55+18]");
					object obj31 = 0;
					_ = ref obj2;
					object obj32 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v399 @ rdx_v16+10] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					bool flag2 = exclude == null;
					bool flag3 = flag;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+B8]");
						object obj33 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ r9_v11+38]");
						object obj34 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ rax_v65+28]");
						object obj35 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ rcx_v46+28]");
						object obj36 = (nint)0 >> 31;
						bool flag4 = obj36 != null;
						object obj37 = (object)(&obj2);
						if (!flag4)
						{
							obj37 = obj8;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v479 @ r9_v11+38]");
						object obj38 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rax_v68+30]");
						object obj39 = 0;
						obj32 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 8));
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v349 @ rdx_v23+10] (should have been resolved before IL gen)");
						flag3 = obj != null;
						obj21 = obj32;
						flag = flag3;
						if (flag3)
						{
							continue;
						}
					}
					JsonTextWriter writer2 = _writer;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+B8]");
					object obj40 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ rax_v61+38]");
					object obj41 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v497 @ rcx_v42+28]");
					writer = (JsonTextWriter)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
					if (_writer != null)
					{
						nint num4 = (nint)writer2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ r8_v15 (Il2CppClass<Newtonsoft.Json.JsonTextWriter>)+8E8]");
						obj21 = 0;
						_writer.WriteValue(value);
						flag = flag3;
						continue;
					}
					throw new NullReferenceException();
				}
				object obj42 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 40));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1831233A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+20]");
				writer = (JsonTextWriter)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ rbp_v1+20]");
				if ((nint)0 != 0)
				{
					throw writer;
				}
				writer = _writer;
				if (_writer != null)
				{
					_writer.WriteEndArray();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SerializeEnumValArray<T>(List<T> array)
	{
		//IL_0020: Expected O, but got I
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0260: Expected O, but got I
		//IL_0270: Expected O, but got I
		//IL_01b7: Expected O, but got I
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00d9: Expected O, but got Ref
		//IL_00ed: Expected O, but got I
		//IL_0145: Expected O, but got I
		//IL_0152: Expected I, but got O
		_writer.WriteStartArray();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
		JsonTextWriter jsonTextWriter = (JsonTextWriter)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj = default(object);
		jsonTextWriter = (JsonTextWriter)(obj + 32);
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type type = default(Type);
		Type enumType = type;
		object obj4 = default(object);
		object obj5 = default(object);
		object obj7 = default(object);
		object obj8 = default(object);
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ stack_18_v11+38]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ rax_v32+40]");
			object obj3 = 0;
			if (obj4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ stack_-48_v11+1C]");
				if (obj5 == null)
				{
					object obj6 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ stack_-48_v11+18]");
					if ((nint)obj6 < 0)
					{
						obj7++;
						string value = ((Enum)(&obj8)).ToString();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF08]");
						object obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v772 @ rcx_v25+E4]");
						if ((nint)0 == 0)
						{
						}
						object obj10 = Enum.Parse(enumType, value, ignoreCase: false);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
						object obj11 = 0;
						nint num = (nint)obj10;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ rdx_v23 (Il2CppClass<System.Object>)+40]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ r8_v14+40]");
						if (num2 != 0)
						{
							break;
						}
						JsonTextWriter writer = _writer;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ rax_v47 (System.Object)+10]");
						writer.WriteValue(0);
						jsonTextWriter = _writer;
						continue;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ r9_v11+20]");
				jsonTextWriter = (JsonTextWriter)0;
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ stack_-48_v11+1C]");
					if (obj5 == null)
					{
						_writer.WriteEndArray();
						return;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
					jsonTextWriter = null;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new InvalidCastException();
	}

	private void SerializeUIntArray(List<uint> array)
	{
		//IL_001f: Expected I, but got O
		//IL_0082: Expected O, but got I
		//IL_00fd: Expected I, but got O
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		_writer.WriteStartArray();
		nint num = unchecked((nint)null);
		object obj = default(object);
		object obj2 = default(object);
		object obj4 = default(object);
		while (true)
		{
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ stack_-28_v9+1C]");
				if (obj2 == null)
				{
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ stack_-28_v9+18]");
					if ((nint)obj3 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ stack_-28_v9+10]");
						object obj5 = 0;
						obj4++;
						JsonTextWriter writer = _writer;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rdx_v16+20+v522 @ rcx_v18*4]");
						writer.WriteValue(0u);
						continue;
					}
					break;
				}
				break;
			}
			throw new NullReferenceException();
		}
		bool flag = obj == null;
		num = 0;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ stack_-28_v9+1C]");
			if (obj2 == null)
			{
				_writer.WriteEndArray();
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
			num = unchecked((nint)null);
		}
		throw new NullReferenceException();
	}

	private unsafe void SerializeObjectEnumInt<T>(Dictionary<T, int> obj)
	{
		//IL_0136: Expected O, but got I
		//IL_006c: Expected O, but got Ref
		//IL_0089: Expected O, but got Ref
		//IL_009f: Expected I, but got O
		//IL_00df: Expected I, but got O
		if (_writer != null)
		{
			_writer.WriteStartObject();
			if (obj != null)
			{
				object obj3 = default(object);
				object obj4 = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ stack_18_v5+38]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184A15D20");
					if (obj3 != null)
					{
						JsonTextWriter writer = _writer;
						string name = ((Enum)(&obj4)).ToString();
						bool flag = _writer == null;
						Enum obj5 = (Enum)(&obj4);
						if (!flag)
						{
							nint num = (nint)writer;
							_writer.WritePropertyName(name);
							obj5 = (Enum)(object)_writer;
							if (_writer != null)
							{
								nint num2 = (nint)obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v404 @ r8_v8 (Il2CppClass<System.Enum>)+6A8] (should have been resolved before IL gen)");
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					break;
				}
				if (_writer != null)
				{
					_writer.WriteEndObject();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SerializeObjectEnumEnum<T1, T2>(Dictionary<T1, T2> obj)
	{
		//IL_006e: Expected O, but got I4
		//IL_017d: Expected O, but got I
		//IL_0083: Expected O, but got Ref
		//IL_00a0: Expected O, but got Ref
		//IL_013b: Expected I, but got O
		//IL_00d7: Expected O, but got Ref
		//IL_00f4: Expected O, but got Ref
		//IL_010a: Expected I, but got O
		//IL_011a: Expected O, but got I
		bool flag = _writer == null;
		Enum writer = (Enum)(object)_writer;
		if (!flag)
		{
			_writer.WriteStartObject();
			bool flag2 = obj == null;
			writer = (Enum)(object)_writer;
			if (!flag2)
			{
				object obj2 = 0;
				object obj4 = default(object);
				object obj5 = default(object);
				object obj6 = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ stack_18_v5+38]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184A15D20");
					if (obj4 != null)
					{
						string name = ((Enum)(&obj5)).ToString();
						bool flag3 = _writer == null;
						writer = (Enum)(&obj5);
						if (!flag3)
						{
							_writer.WritePropertyName(name);
							JsonTextWriter writer2 = _writer;
							string value = ((Enum)(&obj6)).ToString();
							bool flag4 = _writer == null;
							writer = (Enum)(&obj6);
							if (!flag4)
							{
								nint num = (nint)writer2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v448 @ r8_v8 (Il2CppClass<Newtonsoft.Json.JsonTextWriter>)+698]");
								obj2 = 0;
								_writer.WriteValue(value);
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					break;
				}
				writer = (Enum)(object)_writer;
				if (_writer != null)
				{
					nint num2 = (nint)writer;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v426 @ rax_v19 (Il2CppClass<System.Enum>)+588] (should have been resolved before IL gen)");
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SerializeObjectEnumEnumArray<T, T2>(Dictionary<T, List<T2>> obj)
	{
		//IL_011c: Expected O, but got I
		//IL_0075: Expected O, but got Ref
		//IL_0092: Expected O, but got Ref
		//IL_00e5: Expected I, but got O
		//IL_00bf: Expected O, but got I
		bool flag = _writer == null;
		Enum writer = (Enum)(object)_writer;
		if (!flag)
		{
			_writer.WriteStartObject();
			bool flag2 = obj == null;
			writer = (Enum)(object)_writer;
			if (!flag2)
			{
				object obj3 = default(object);
				object obj4 = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ stack_18_v4+38]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184A16D70");
					if (obj3 != null)
					{
						string name = ((Enum)(&obj4)).ToString();
						bool flag3 = _writer == null;
						writer = (Enum)(&obj4);
						if (!flag3)
						{
							_writer.WritePropertyName(name);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ stack_18_v4+38]");
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183122920");
							continue;
						}
						throw new NullReferenceException();
					}
					break;
				}
				writer = (Enum)(object)_writer;
				if (_writer != null)
				{
					nint num = (nint)writer;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v358 @ rax_v16 (Il2CppClass<System.Enum>)+588] (should have been resolved before IL gen)");
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void SerializeObjectEnumIntArray<T, T2>(Dictionary<T, List<T2>> obj)
	{
		//IL_0008: Expected O, but got Ref
		//IL_06df: Expected O, but got I
		//IL_06e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ed: Expected O, but got Unknown
		//IL_0023: Expected O, but got I
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0413: Expected O, but got I
		//IL_0055: Expected O, but got I8
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Expected O, but got Unknown
		//IL_0465: Expected O, but got I
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_0497: Expected O, but got Unknown
		//IL_04a9: Expected O, but got Ref
		//IL_04bf: Expected O, but got I
		//IL_04ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Expected O, but got Unknown
		//IL_0511: Expected O, but got I
		//IL_0067: Expected O, but got I8
		//IL_053e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Expected O, but got Unknown
		//IL_0572: Expected O, but got I
		//IL_0079: Expected O, but got I8
		//IL_059f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a4: Expected O, but got Unknown
		//IL_05ce: Expected O, but got I
		//IL_008b: Expected O, but got I8
		//IL_05fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0600: Expected O, but got Unknown
		//IL_009d: Expected O, but got I8
		//IL_00af: Expected O, but got I8
		//IL_00f4: Expected O, but got I
		//IL_0104: Expected O, but got I
		//IL_0114: Expected O, but got I
		//IL_013e: Expected O, but got Ref
		//IL_0151: Expected O, but got Ref
		//IL_0164: Expected O, but got Ref
		//IL_0191: Expected O, but got Ref
		//IL_0658: Expected O, but got I
		//IL_0668: Expected O, but got I
		//IL_0678: Expected O, but got I
		//IL_033f: Expected O, but got Ref
		//IL_0359: Expected O, but got I
		//IL_01a6: Expected O, but got I
		//IL_01b6: Expected O, but got I
		//IL_01c6: Expected O, but got I
		//IL_01ce: Expected O, but got Ref
		//IL_01f2: Expected O, but got I
		//IL_0202: Expected O, but got I
		//IL_0212: Expected O, but got I
		//IL_021a: Expected O, but got Ref
		//IL_0243: Expected O, but got I
		//IL_0253: Expected O, but got I
		//IL_0283: Expected O, but got I
		//IL_02a8: Expected O, but got I
		//IL_02b8: Expected O, but got I
		//IL_02c8: Expected O, but got I
		//IL_02d8: Expected O, but got I
		//IL_02f2: Expected O, but got I
		//IL_0302: Expected O, but got I
		//IL_0312: Expected O, but got I
		//IL_032c: Expected O, but got I
		object obj3 = default(object);
		object obj2 = (object)(&obj3);
		nint num = 0;
		nint num2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v2 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<T, System.Collections.Generic.List`1<T2>>>)+FC]");
		_ = 0;
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v3 (Il2CppClass<T>)+FC]");
		_ = 0;
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ rax_v4 (Il2CppClass<System.Collections.Generic.Dictionary`2<T, System.Collections.Generic.List`1<T2>>+Enumerator<T, System.Collections.Generic.List`1<T2>>>)+FC]");
		object obj4 = (nint)0 + (nint)16;
		object obj5 = obj4 + 15;
		object obj8;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
			_ = ref obj3;
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v14 (Il2CppClass<T>)+FC]");
			object obj6 = (nint)0 + (nint)16;
			object obj7 = obj6 + 15;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj6))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
				_ = ref obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v3 (Il2CppClass<T>)+FC]");
				obj8 = (nint)0 + (nint)15;
				object obj9 = obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v3 (Il2CppClass<T>)+FC]");
				if ((nint)obj9 > 0)
				{
					goto IL_0437;
				}
			}
			obj8 = 1152921504606846960L;
			goto IL_0437;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-B8), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
		IL_0437:
		object obj10 = obj8 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppClass<System.Collections.Generic.Dictionary`2<T, System.Collections.Generic.List`1<T2>>+Enumerator<T, System.Collections.Generic.List`1<T2>>>)+FC]");
		object obj11 = (nint)0 + (nint)15;
		object obj12 = obj11;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppClass<System.Collections.Generic.Dictionary`2<T, System.Collections.Generic.List`1<T2>>+Enumerator<T, System.Collections.Generic.List`1<T2>>>)+FC]");
		if ((nint)obj12 <= 0)
		{
			obj11 = 1152921504606846960L;
		}
		object obj13 = obj11 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		obj2 = (object)(&obj3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v2 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<T, System.Collections.Generic.List`1<T2>>>)+FC]");
		object obj14 = (nint)0 + (nint)15;
		object obj15 = obj14;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v2 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<T, System.Collections.Generic.List`1<T2>>>)+FC]");
		if ((nint)obj15 <= 0)
		{
			obj14 = 1152921504606846960L;
		}
		object obj16 = obj14 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppClass<System.Collections.Generic.Dictionary`2<T, System.Collections.Generic.List`1<T2>>+Enumerator<T, System.Collections.Generic.List`1<T2>>>)+FC]");
		object obj17 = (nint)0 + (nint)15;
		object obj18 = obj17;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ r8_v1 (Il2CppClass<System.Collections.Generic.Dictionary`2<T, System.Collections.Generic.List`1<T2>>+Enumerator<T, System.Collections.Generic.List`1<T2>>>)+FC]");
		if ((nint)obj18 <= 0)
		{
			obj17 = 1152921504606846960L;
		}
		object obj19 = obj17 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		_ = ref obj3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v2 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<T, System.Collections.Generic.List`1<T2>>>)+FC]");
		object obj20 = (nint)0 + (nint)15;
		object obj21 = obj20;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rcx_v2 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<T, System.Collections.Generic.List`1<T2>>>)+FC]");
		if ((nint)obj21 <= 0)
		{
			obj20 = 1152921504606846960L;
		}
		object obj22 = obj20 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v3 (Il2CppClass<T>)+FC]");
		object obj23 = (nint)0 + (nint)15;
		object obj24 = obj23;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rcx_v3 (Il2CppClass<T>)+FC]");
		if ((nint)obj24 <= 0)
		{
			obj23 = 1152921504606846960L;
		}
		object obj25 = obj23 & -16;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B45B70");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B765E0");
		JsonTextWriter writer = _writer;
		if (_writer != null)
		{
			_writer.WriteStartObject();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbp_v1+D8]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbp_v1+E0]");
				object obj26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ rcx_v33+38]");
				object obj27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rax_v47+8]");
				object obj28 = 0;
				obj2 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v355 @ rdx_v9+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
				object obj29 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj3, 224));
				object obj30 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj3, 24));
				object obj31 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj3, 16));
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbp_v1+58]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbp_v1+68]");
				_ = 0;
				object obj32 = (object)(&obj3);
				object obj36 = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbp_v1+E0]");
					object obj33 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ rdx_v12+38]");
					object obj34 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ rax_v55+68]");
					object obj35 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v473 @ rcx_v37] (should have been resolved before IL gen)");
					if (obj36 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbp_v1+E0]");
					object obj37 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v487 @ rcx_v42+38]");
					object obj38 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ rax_v60+18]");
					object obj39 = 0;
					obj2 = (object)(&obj3);
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v489 @ rdx_v15+10] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbp_v1+E0]");
					object obj40 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ rcx_v45+38]");
					object obj41 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ rax_v64+30]");
					object obj42 = 0;
					obj2 = (object)(&obj3);
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v502 @ rdx_v17+10] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B75F40");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbp_v1+E0]");
					object obj43 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ rcx_v48+38]");
					object obj44 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB8900");
					bool flag = _writer == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v554 @ rax_v68+40]");
					writer = (JsonTextWriter)0;
					if (!flag)
					{
						JsonTextWriter writer2 = _writer;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbp_v1+28]");
						writer2.WritePropertyName((string)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbp_v1+E0]");
						object obj45 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v579 @ rcx_v53+38]");
						object obj46 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ rax_v74+50]");
						object obj47 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v581 @ rdx_v21+10] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbp_v1+E0]");
						object obj48 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v588 @ rdx_v22+38]");
						object obj49 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ rax_v77+60]");
						object obj50 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v590 @ rcx_v55] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ rax_v77+60]");
						obj32 = 0;
						continue;
					}
					throw new NullReferenceException();
				}
				object obj51 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj3, 64));
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183124430");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbp_v1+38]");
				writer = (JsonTextWriter)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ rbp_v1+38]");
				if ((nint)0 != 0)
				{
					throw writer;
				}
				if (_writer != null)
				{
					_writer.WriteEndObject();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void saveDate()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CsaveDate_003Ek__BackingField);
	}

	private void Platform()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CPlatform_003Ek__BackingField);
	}

	private void SaveSyncPlatformAchievements()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSaveSyncPlatformAchievements_003Ek__BackingField);
	}

	private void SaveOriginalPlatform()
	{
		System.Int32Enum? int32Enum = default(System.Int32Enum?);
		string value = int32Enum.ToString();
		_writer.WriteValue(value);
	}

	private void SaveTouchedPlatforms()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CSaveTouchedPlatforms_003Ek__BackingField);
	}

	private void itemInCollection()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CitemInCollection_003Ek__BackingField);
	}

	private void itemInUnlocks()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CitemInUnlocks_003Ek__BackingField);
	}

	private void itemInSecrets()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CitemInSecrets_003Ek__BackingField);
	}

	private unsafe void SelectedCharacter()
	{
		//IL_000e: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		string value = ((Enum)(&intPtr)).ToString();
		_writer.WriteValue(value);
	}

	private unsafe void SelectedStage()
	{
		//IL_000e: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		string value = ((Enum)(&intPtr)).ToString();
		_writer.WriteValue(value);
	}

	private void SelectedHyper()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSelectedHyper_003Ek__BackingField);
	}

	private void SelectedHurry()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSelectedHurry_003Ek__BackingField);
	}

	private void AcceptedEULA()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CAcceptedEULA_003Ek__BackingField);
	}

	private void SelectedMazzo()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSelectedMazzo_003Ek__BackingField);
	}

	private void SelectedLimitBreak()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSelectedLimitBreak_003Ek__BackingField);
	}

	private void SelectedInverse()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSelectedInverse_003Ek__BackingField);
	}

	private void SelectedReapers()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSelectedReapers_003Ek__BackingField);
	}

	private void SelectedGoldenEggs()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSelectedGoldenEggs_003Ek__BackingField);
	}

	private void SelectedSharePassives()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSelectedSharePassives_003Ek__BackingField);
	}

	private void SelectedArcana()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSelectedArcana_003Ek__BackingField);
	}

	private void SelectedRandomEvents()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSelectedRandomEvents_003Ek__BackingField);
	}

	private void SelectedRandomLevels()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSelectedRandomLevels_003Ek__BackingField);
	}

	private void SelectedBGMSave()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSelectedBGMSave_003Ek__BackingField);
	}

	private unsafe void SelectedBGM()
	{
		//IL_000e: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		string value = ((Enum)(&intPtr)).ToString();
		_writer.WriteValue(value);
	}

	private unsafe void SelectedBGMMod()
	{
		//IL_000e: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		string value = ((Enum)(&intPtr)).ToString();
		_writer.WriteValue(value);
	}

	private void SelectedMaxWeapons()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSelectedMaxWeapons_003Ek__BackingField);
	}

	private void Fullscreen()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CFullscreen_003Ek__BackingField);
	}

	private void Version()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CVersion_003Ek__BackingField);
	}

	private void Coins()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		PlayerOptionsData pod = _pod;
		float value = pod._003CCoins_003Ek__BackingField;
		object obj = pod._003CCoins_003Ek__BackingField & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = pod._003CCoins_003Ek__BackingField & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				goto IL_0095;
			}
		}
		value = 3.4028235E+38f;
		goto IL_0095;
		IL_0095:
		_writer.WriteValue(value);
	}

	private void LifetimeCoins()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		PlayerOptionsData pod = _pod;
		float value = pod._003CLifetimeCoins_003Ek__BackingField;
		object obj = pod._003CLifetimeCoins_003Ek__BackingField & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = pod._003CLifetimeCoins_003Ek__BackingField & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				goto IL_0095;
			}
		}
		value = 3.4028235E+38f;
		goto IL_0095;
		IL_0095:
		_writer.WriteValue(value);
	}

	private void TotalCoins()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		PlayerOptionsData pod = _pod;
		float value = pod._003CTotalCoins_003Ek__BackingField;
		object obj = pod._003CTotalCoins_003Ek__BackingField & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = pod._003CTotalCoins_003Ek__BackingField & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				goto IL_0095;
			}
		}
		value = 3.4028235E+38f;
		goto IL_0095;
		IL_0095:
		_writer.WriteValue(value);
	}

	private void BeginnersLuck()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CBeginnersLuck_003Ek__BackingField);
	}

	private void RunFever()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CRunFever_003Ek__BackingField);
	}

	private void LifetimeSurvived()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		PlayerOptionsData pod = _pod;
		float value = pod._003CLifetimeSurvived_003Ek__BackingField;
		object obj = pod._003CLifetimeSurvived_003Ek__BackingField & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = pod._003CLifetimeSurvived_003Ek__BackingField & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				goto IL_0095;
			}
		}
		value = 3.4028235E+38f;
		goto IL_0095;
		IL_0095:
		_writer.WriteValue(value);
	}

	private void LifetimeHeal()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		PlayerOptionsData pod = _pod;
		float value = pod._003CLifetimeHeal_003Ek__BackingField;
		object obj = pod._003CLifetimeHeal_003Ek__BackingField & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = pod._003CLifetimeHeal_003Ek__BackingField & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				goto IL_0095;
			}
		}
		value = 3.4028235E+38f;
		goto IL_0095;
		IL_0095:
		_writer.WriteValue(value);
	}

	private void TrainHazardEnemiesHit()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		PlayerOptionsData pod = _pod;
		float value = pod._003CTrainHazardEnemiesHit_003Ek__BackingField;
		object obj = pod._003CTrainHazardEnemiesHit_003Ek__BackingField & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = pod._003CTrainHazardEnemiesHit_003Ek__BackingField & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				goto IL_0095;
			}
		}
		value = 3.4028235E+38f;
		goto IL_0095;
		IL_0095:
		_writer.WriteValue(value);
	}

	private void TopLapsCarlo()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CTopLapsCarlo_003Ek__BackingField);
	}

	private void TotalLapsCarlo()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CTotalLapsCarlo_003Ek__BackingField);
	}

	private void TopLapsHighway()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CTopLapsHighway_003Ek__BackingField);
	}

	private void TotalLapsHighway()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CTotalLapsHighway_003Ek__BackingField);
	}

	private void OwO()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		PlayerOptionsData pod = _pod;
		float value = pod._003COwO_003Ek__BackingField;
		object obj = pod._003COwO_003Ek__BackingField & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = pod._003COwO_003Ek__BackingField & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
				goto IL_0095;
			}
		}
		value = 3.4028235E+38f;
		goto IL_0095;
		IL_0095:
		_writer.WriteValue(value);
	}

	private void CompletedHurries()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CCompletedHurries_003Ek__BackingField);
	}

	private void ReducePhysics()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CReducePhysics_003Ek__BackingField);
	}

	private void ClassicMusic()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CClassicMusic_003Ek__BackingField);
	}

	private void VisuallyInvertStages()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CVisuallyInvertStages_003Ek__BackingField);
	}

	private void HideProgress()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CHideProgress_003Ek__BackingField);
	}

	private void SoundsEnabled()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSoundsEnabled_003Ek__BackingField);
	}

	private void MusicEnabled()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CMusicEnabled_003Ek__BackingField);
	}

	private void SoundsVolume()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSoundsVolume_003Ek__BackingField);
	}

	private void MusicVolume()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CMusicVolume_003Ek__BackingField);
	}

	private void FlashingVFXEnabled()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CFlashingVFXEnabled_003Ek__BackingField);
	}

	private void JoystickVisible()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CJoystickVisible_003Ek__BackingField);
	}

	private unsafe void SelectedJoystickType()
	{
		//IL_000e: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		string value = ((Enum)(&intPtr)).ToString();
		_writer.WriteValue(value);
	}

	private void DamageNumbersEnabled()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CDamageNumbersEnabled_003Ek__BackingField);
	}

	private void GlimmerCarouselEnabled()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CGlimmerCarouselEnabled_003Ek__BackingField);
	}

	private void StreamSafeEnabled()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CStreamSafeEnabled_003Ek__BackingField);
	}

	private void hideXPBar()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003ChideXPBar_003Ek__BackingField);
	}

	private void CheatCodeUsed()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CCheatCodeUsed_003Ek__BackingField);
	}

	private void HasKilledTheFinalBoss()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CHasKilledTheFinalBoss_003Ek__BackingField);
	}

	private void HasSeenFinalFireworks()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CHasSeenFinalFireworks_003Ek__BackingField);
	}

	private void Language()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CLanguage_003Ek__BackingField);
	}

	private void ShowQuitDescription()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CShowQuitDescription_003Ek__BackingField);
	}

	private void HideCompletedAchievements()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CHideCompletedAchievements_003Ek__BackingField);
	}

	private void PlayedRNJ()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CPlayedRNJ_003Ek__BackingField);
	}

	private void ShowPickups()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CShowPickups_003Ek__BackingField);
	}

	private void ShowSmallMapIcons()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CShowSmallMapIcons_003Ek__BackingField);
	}

	private void LongestFever()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CLongestFever_003Ek__BackingField);
	}

	private void HighestFever()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CHighestFever_003Ek__BackingField);
	}

	private void HasUsedMirror()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CHasUsedMirror_003Ek__BackingField);
	}

	private void HasUsedTrumpet()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CHasUsedTrumpet_003Ek__BackingField);
	}

	private void BoughtCharacters()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CBoughtCharacters_003Ek__BackingField);
	}

	private unsafe void BoughtPowerups()
	{
		//IL_008a: Expected O, but got I4
		//IL_0093: Expected O, but got I4
		//IL_009b: Expected O, but got Ref
		//IL_015c: Expected I, but got O
		bool flag = _writer == null;
		Enum writer = (Enum)(object)_writer;
		if (!flag)
		{
			_writer.WriteStartArray();
			PlayerOptionsData pod = _pod;
			bool flag2 = _pod == null;
			writer = (Enum)(object)_writer;
			if (!flag2)
			{
				List<PowerUpLevel> list = pod._003CBoughtPowerups_003Ek__BackingField;
				bool flag3 = pod._003CBoughtPowerups_003Ek__BackingField == null;
				writer = (Enum)(object)_writer;
				if (!flag3)
				{
					List<PowerUpLevel>.Enumerator enumerator = default(List<PowerUpLevel>.Enumerator);
					if (enumerator.MoveNext())
					{
						object obj = 0;
						object obj2 = 0;
						List<PowerUpLevel>.Enumerator enumerator2 = (List<PowerUpLevel>.Enumerator)(&enumerator);
						throw new NullReferenceException();
					}
					writer = (Enum)(object)_writer;
					if (_writer != null)
					{
						nint num = (nint)writer;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v425 @ rax_v17 (Il2CppClass<System.Enum>)+5A8] (should have been resolved before IL gen)");
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void CollectedWeapons()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CCollectedWeapons_003Ek__BackingField);
	}

	private void UnlockedWeapons()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CUnlockedWeapons_003Ek__BackingField);
	}

	private void UnlockedCharacters()
	{
		//IL_005c: Expected O, but got I
		//IL_00b6: Expected O, but got I
		//IL_0253: Expected O, but got I
		//IL_0120: Expected O, but got I
		//IL_027b: Expected O, but got I
		//IL_018a: Expected O, but got I
		//IL_02a3: Expected O, but got I
		//IL_01f4: Expected O, but got I
		PlayerOptionsData pod = _pod;
		List<CharacterType> exclude;
		List<CharacterType> array;
		if ((object)pod._003CSelectedAdventureType_003Ek__BackingField == null)
		{
			List<CharacterType> list = new List<CharacterType>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rdx_v6+18]");
			if (num >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)1);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
				object obj2 = (nint)0 + (nint)1;
				_ = 1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v8+18]");
			if (num2 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)2);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
				object obj4 = (nint)0 + (nint)1;
				_ = 2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rdx_v10+18]");
			if (num3 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)3);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
				object obj6 = (nint)0 + (nint)1;
				_ = 3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+1C]");
			_ = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+10]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rdx_v12+18]");
			if (num4 >= 0)
			{
				((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)4);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ rax_v9 (System.Collections.Generic.List`1<VampireSurvivors.Data.CharacterType>)+18]");
				object obj8 = (nint)0 + (nint)1;
				_ = 4;
			}
			exclude = list;
			array = pod._003CUnlockedCharacters_003Ek__BackingField;
		}
		else
		{
			array = pod._003CUnlockedCharacters_003Ek__BackingField;
			exclude = null;
		}
		SerializeEnumArray(array, exclude);
	}

	private void OpenedCoffins()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003COpenedCoffins_003Ek__BackingField);
	}

	private void CollectedItems()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CCollectedItems_003Ek__BackingField);
	}

	private void Achievements()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CAchievements_003Ek__BackingField);
	}

	private void Secrets()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CSecrets_003Ek__BackingField);
	}

	private void UnlockedStages()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CUnlockedStages_003Ek__BackingField);
	}

	private void UnlockedHypers()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CUnlockedHypers_003Ek__BackingField);
	}

	private void UnlockedPowerUpRanks()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CUnlockedPowerUpRanks_003Ek__BackingField);
	}

	private void DisabledPowerups()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CDisabledPowerups_003Ek__BackingField);
	}

	private void UnlockedArcanas()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumValArray(pod._003CUnlockedArcanas_003Ek__BackingField);
	}

	private void KillCount()
	{
		PlayerOptionsData pod = _pod;
		SerializeObjectEnumInt(pod._003CKillCount_003Ek__BackingField);
	}

	private void PickupCount()
	{
		PlayerOptionsData pod = _pod;
		SerializeObjectEnumInt(pod._003CPickupCount_003Ek__BackingField);
	}

	private void DestroyedCount()
	{
		PlayerOptionsData pod = _pod;
		SerializeObjectEnumInt(pod._003CDestroyedCount_003Ek__BackingField);
	}

	private void StageCompletionLog()
	{
		PlayerOptionsData pod = _pod;
		SerializeObjectEnumEnumArray(pod._003CStageCompletionLog_003Ek__BackingField);
	}

	private unsafe void CharacterStageData()
	{
		//IL_0080: Expected O, but got I4
		//IL_0098: Expected O, but got Ref
		//IL_00b5: Expected O, but got Ref
		//IL_00cb: Expected I, but got O
		//IL_00db: Expected O, but got I
		//IL_011b: Expected I, but got O
		if (_writer != null)
		{
			_writer.WriteStartObject();
			PlayerOptionsData pod = _pod;
			if (_pod != null && pod._003CCharacterStageData_003Ek__BackingField != null)
			{
				Dictionary<CharacterType, List<CharacterStageData>> dictionary = null;
				List<CharacterStageData>.Enumerator enumerator = (List<CharacterStageData>.Enumerator)2;
				Dictionary<CharacterType, List<CharacterStageData>>.Enumerator enumerator2 = default(Dictionary<CharacterType, List<CharacterStageData>>.Enumerator);
				if (enumerator2.MoveNext())
				{
					JsonTextWriter writer = _writer;
					IntPtr intPtr = default(IntPtr);
					string name = ((Enum)(&intPtr)).ToString();
					bool flag = _writer == null;
					Enum obj = (Enum)(&intPtr);
					if (!flag)
					{
						nint num = (nint)writer;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ r8_v25 (Il2CppClass<Newtonsoft.Json.JsonTextWriter>)+5E0]");
						object obj2 = 0;
						_writer.WritePropertyName(name);
						obj = (Enum)(object)_writer;
						if (_writer != null)
						{
							nint num2 = (nint)obj;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v889 @ rdx_v31 (Il2CppClass<System.Enum>)+598] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				if (_writer != null)
				{
					_writer.WriteEndObject();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void CharacterEnemiesKilled()
	{
		PlayerOptionsData pod = _pod;
		SerializeObjectEnumInt(pod._003CCharacterEnemiesKilled_003Ek__BackingField);
	}

	private void CharacterSurvivedMinutes()
	{
		PlayerOptionsData pod = _pod;
		SerializeObjectEnumInt(pod._003CCharacterSurvivedMinutes_003Ek__BackingField);
	}

	private void MusicSelectionPerStage()
	{
		_writer.WriteStartObject();
		_writer.WriteEndObject();
	}

	private void checksum()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003Cchecksum_003Ek__BackingField);
	}

	private unsafe void EggData()
	{
		//IL_007b: Expected F4, but got I4
		//IL_0084: Expected F4, but got I4
		//IL_008d: Expected F4, but got I4
		//IL_00a5: Expected O, but got Ref
		//IL_00c2: Expected O, but got Ref
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected O, but got Unknown
		//IL_00d8: Expected I, but got O
		//IL_00e8: Expected O, but got I
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		JsonTextWriter writer = _writer;
		float num;
		if (_writer != null)
		{
			_writer.WriteStartObject();
			PlayerOptionsData pod = _pod;
			if (_pod != null && pod._003CCharacterEggInfo_003Ek__BackingField != null)
			{
				num = 0f;
				float num2 = 0f;
				float num3 = 2f;
				Dictionary<CharacterType, Dictionary<string, float>>.Enumerator enumerator = default(Dictionary<CharacterType, Dictionary<string, float>>.Enumerator);
				if (enumerator.MoveNext())
				{
					JsonTextWriter writer2 = _writer;
					IntPtr intPtr = default(IntPtr);
					string name = ((Enum)(&intPtr)).ToString();
					bool flag = _writer == null;
					Enum obj = (Enum)(&intPtr);
					if (!flag)
					{
						nint num4 = (nint)writer2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v770 @ r8_v14 (Il2CppClass<Newtonsoft.Json.JsonTextWriter>)+5E0]");
						object obj2 = 0;
						_writer.WritePropertyName(name);
						Dictionary<object, float>.Enumerator writer3 = (Dictionary<object, float>.Enumerator)_writer;
						if (_writer != null)
						{
							object obj3 = writer3;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v900 @ rdx_v19+578] (should have been resolved before IL gen)");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				writer = _writer;
				if (_writer != null)
				{
					_writer.WritePropertyName("total");
					object obj4 = num & -2147483649L;
					if ((nint)obj4 != 2139095040)
					{
						object obj5 = num & -2147483649L;
						if ((nint)obj5 <= 2139095040)
						{
							goto IL_048c;
						}
					}
					num = 3.4028235E+38f;
					goto IL_048c;
				}
			}
		}
		goto IL_034f;
		IL_048c:
		writer = _writer;
		if (_writer != null)
		{
			_writer.WriteValue(num);
			writer = _writer;
			if (_writer != null)
			{
				_writer.WriteEndObject();
				return;
			}
		}
		goto IL_034f;
		IL_034f:
		throw new NullReferenceException();
	}

	private void Didit()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CDidit_003Ek__BackingField);
	}

	private void Seals()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSeals_003Ek__BackingField);
	}

	private void SealedItems()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CSealedItems_003Ek__BackingField);
	}

	private void SealedWeapons()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CSealedWeapons_003Ek__BackingField);
	}

	private void UnlockedSkins()
	{
		PlayerOptionsData pod = _pod;
		SerializeObjectEnumEnumArray(pod._003CUnlockedSkins_003Ek__BackingField);
	}

	private void UnlockedSkinsV2()
	{
		PlayerOptionsData pod = _pod;
		SerializeObjectEnumEnumArray(pod._003CUnlockedSkinsV2_003Ek__BackingField);
	}

	private void SelectedSkins()
	{
		PlayerOptionsData pod = _pod;
		SerializeObjectEnumInt(pod._003CSelectedSkins_003Ek__BackingField);
	}

	private void SelectedSkinsV2()
	{
		PlayerOptionsData pod = _pod;
		SerializeObjectEnumEnum(pod._003CSelectedSkinsV2_003Ek__BackingField);
	}

	private void HideAdsButtons()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CEnableBonusAdsMechanics_003Ek__BackingField);
	}

	private void ScreenShakeEnabled()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CScreenShakeEnabled_003Ek__BackingField);
	}

	private void ControllerVibrationEnabled()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CControllerVibrationEnabled_003Ek__BackingField);
	}

	private void AssignControllerToPlayer1()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CAssignControllerToPlayer1_003Ek__BackingField);
	}

	private void ShowPlayerIndicators()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CShowPlayerIndicators_003Ek__BackingField);
	}

	private void PermanentCoopOutlines()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CPermanentCoopOutlines_003Ek__BackingField);
	}

	private void TintUISelection()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CTintUISelection_003Ek__BackingField);
	}

	private void PlayerColours()
	{
		PlayerOptionsData pod = _pod;
		List<uint> array = new List<uint>(pod._003CPlayerColours_003Ek__BackingField);
		SerializeUIntArray(array);
	}

	private void SequentialChestMode()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CSequentialChestMode_003Ek__BackingField);
	}

	private void WriteFloat(float value)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		float num = default(float);
		object obj = num & -2147483649L;
		if ((nint)obj != 2139095040)
		{
			object obj2 = num & -2147483649L;
			if ((nint)obj2 <= 2139095040)
			{
			}
		}
		_writer.WriteValue(3.4028235E+38f);
	}

	private void DisableMovingBackground()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CDisableMovingBackground_003Ek__BackingField);
	}

	private void DisableBlood()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CDisableBlood_003Ek__BackingField);
	}

	private unsafe void BorderType()
	{
		//IL_000e: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		string value = ((Enum)(&intPtr)).ToString();
		_writer.WriteValue(value);
	}

	private void PixelFont()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CPixelFont_003Ek__BackingField);
	}

	private void DisplayDefangedEnemies()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CDisplayDefangedEnemies_003Ek__BackingField);
	}

	private void SelectedAdventureType()
	{
		System.Int32Enum? int32Enum = default(System.Int32Enum?);
		string value = int32Enum.ToString();
		_writer.WriteValue(value);
	}

	private void AdventureProgress()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CAdventureProgress_003Ek__BackingField);
	}

	private void AdventuresSaveData()
	{
		if (_writer != null)
		{
			_writer.WriteStartObject();
			PlayerOptionsData pod = _pod;
			if (_pod != null && pod._003CAdventuresSaveData_003Ek__BackingField != null)
			{
				Dictionary<AdventureType, PlayerOptionsData>.Enumerator enumerator = default(Dictionary<AdventureType, PlayerOptionsData>.Enumerator);
				while (enumerator.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
				}
				if (_writer != null)
				{
					_writer.WriteEndObject();
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void HasSeenAdventureReveal()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CHasSeenAdventureReveal_003Ek__BackingField);
	}

	private void AdventureCompletionCount()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CAdventureCompletionCount_003Ek__BackingField);
	}

	private unsafe void CollectionFilterMode()
	{
		//IL_000e: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		string value = ((Enum)(&intPtr)).ToString();
		_writer.WriteValue(value);
	}

	private void HideUnavailableAdventures()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CHideUnavailableAdventures_003Ek__BackingField);
	}

	private void TotalAdventurePlaytime()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CTotalAdventurePlaytime_003Ek__BackingField);
	}

	private void AllTimeAdventurePlaytime()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CAllTimeAdventurePlaytime_003Ek__BackingField);
	}

	private void AscensionPointsAllocation()
	{
		PlayerOptionsData pod = _pod;
		SerializeObjectEnumInt(pod._003CAscensionPointsAllocation_003Ek__BackingField);
	}

	private void HasSeenAdventuresIntroTutorial()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CHasSeenAdventuresIntroTutorial_003Ek__BackingField);
	}

	private void AdventureStars()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CAdventureStars_003Ek__BackingField);
	}

	private void HasPlayedStage3()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CHasPlayedStage3_003Ek__BackingField);
	}

	private void CompletedAdventures()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CCompletedAdventures_003Ek__BackingField);
	}

	private void HasSeenMerchantTutorial()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CHasSeenMerchantTutorial_003Ek__BackingField);
	}

	private void SeenAscensionPopups()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CSeenAscensionPopups_003Ek__BackingField);
	}

	private void StageLighting()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CStageLighting_003Ek__BackingField);
	}

	private void HasSeenDarkanaTransition()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CHasSeenDarkanaTransition_003Ek__BackingField);
	}

	private void HasFixedSkinIds()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CHasFixedSkinIds_003Ek__BackingField);
	}

	private void BoughtSkins()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CBoughtSkins_003Ek__BackingField);
	}

	private void BanishedContentGroups()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod.BanishedContentGroups);
	}

	private void ContentGroupSealedItems()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CContentGroupSealedItems_003Ek__BackingField);
	}

	private void ContentGroupSealedWeapons()
	{
		PlayerOptionsData pod = _pod;
		SerializeEnumArray(pod._003CContentGroupSealedWeapons_003Ek__BackingField);
	}

	private unsafe void SelectedBGMPlayback()
	{
		//IL_000e: Expected O, but got Ref
		IntPtr intPtr = default(IntPtr);
		string value = ((Enum)(&intPtr)).ToString();
		_writer.WriteValue(value);
	}

	private void PlayBGMOnlyDuringRun()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CPlayBGMOnlyDuringRun_003Ek__BackingField);
	}

	private void TP_FrozenShadesCount()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod.TP_FrozenShadesCount);
	}

	private void TP_AxeArmorCount()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod.TP_AxeArmorCount);
	}

	private void TP_SniperCount()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod.TP_SniperCount);
	}

	private void TP_PortraitsCount()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod.TP_PortraitsCount);
	}

	private void LibraryMerchantGoldSpent()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CLibraryMerchantGoldSpent_003Ek__BackingField);
	}

	private void EME_NextBossBiome()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CEME_NextBossBiome_003Ek__BackingField);
	}

	private void WW_ZoneProgress()
	{
		PlayerOptionsData pod = _pod;
		_writer.WriteValue(pod._003CWW_ZoneProgress_003Ek__BackingField);
	}
}
