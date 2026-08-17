using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Cpp2ILInjected;

namespace Cysharp.Threading.Tasks.Internal;

internal static class DiagnosticsExtensions
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<ParameterInfo, string> _003C_003E9__3_0;

		public static Func<Type, string> _003C_003E9__6_0;

		public static Func<Type, string> _003C_003E9__6_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal string _003CCleanupAsyncStackTrace_003Eb__3_0(ParameterInfo p)
		{
			if (p != null)
			{
				Type parameterType = p.ParameterType;
				string text = BeautifyType(parameterType, shortName: true);
				string name = p.Name;
				return text + " " + name;
			}
			return (string)(object)new NullReferenceException();
		}

		internal string _003CBeautifyType_003Eb__6_0(Type x)
		{
			return BeautifyType(x, shortName: true);
		}

		internal string _003CBeautifyType_003Eb__6_1(Type x)
		{
			return BeautifyType(x, shortName: true);
		}
	}

	private static bool displayFilenames;

	private static readonly Regex typeBeautifyRegex;

	private static readonly Dictionary<Type, string> builtInTypeNames;

	public static string CleanupAsyncStackTrace(StackTrace stackTrace)
	{
		//IL_0127: Expected I, but got O
		//IL_0135: Expected I, but got O
		//IL_0145: Expected O, but got I
		//IL_01c5: Expected O, but got I4
		//IL_0181: Expected O, but got I
		//IL_01b7: Expected O, but got I4
		//IL_01df: Expected I, but got O
		//IL_03c5: Expected O, but got I4
		//IL_06d7: Expected I, but got O
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_0438: Expected O, but got Unknown
		if (stackTrace != null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			StackTrace stackTrace2 = stackTrace;
			Type t = default(Type);
			int num6 = default(int);
			while (true)
			{
				int frameCount = stackTrace2.FrameCount;
				StackFrame frame;
				MethodBase method;
				object obj3;
				if (num < frameCount)
				{
					frame = stackTrace2.GetFrame(num);
					if (frame == null)
					{
						break;
					}
					method = frame.GetMethod();
					if (IgnoreLine(method))
					{
						goto IL_05c8;
					}
					bool flag = IsAsync(method);
					bool flag2 = !flag;
					MethodBase method2 = method;
					if (!flag2)
					{
						if (stringBuilder == null)
						{
							break;
						}
						StringBuilder stringBuilder2 = stringBuilder.Append("async ");
						bool flag3 = TryResolveStateMachineMethod(ref method2, out var _);
					}
					if ((object)method == null)
					{
						break;
					}
					nint num2 = (nint)method;
					nint num3 = (nint)typeof(MethodInfo);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rdx_v15 (Il2CppClass<System.Reflection.MethodInfo>)+130]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v869 @ r9_v5 (Il2CppClass<System.Reflection.MethodBase>)+130]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v577 @ rdx_v15 (Il2CppClass<System.Reflection.MethodInfo>)+130]");
					if (num4 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v869 @ r9_v5 (Il2CppClass<System.Reflection.MethodBase>)+C8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ rax_v102+FFFFFFF8+v578 @ rax_v21*8]");
						if (0 == (nint)typeof(MethodInfo))
						{
							obj3 = 1;
							goto IL_0643;
						}
					}
					obj3 = 0;
					goto IL_0643;
				}
				if (stringBuilder == null)
				{
					break;
				}
				return stringBuilder.ToString();
				IL_0643:
				bool flag4 = obj3 == null;
				MethodBase methodBase = null;
				if (!flag4)
				{
					methodBase = method;
				}
				bool flag5 = (object)methodBase == null;
				MethodBase methodBase2 = method;
				if (!flag5)
				{
					nint num5 = (nint)methodBase;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v668 @ rdx_v58 (Il2CppClass<System.Reflection.MethodBase>)+3C8] (should have been resolved before IL gen)");
					string value = BeautifyType(t, shortName: false);
					if (stringBuilder == null)
					{
						break;
					}
					StringBuilder stringBuilder3 = stringBuilder.Append(value);
					StringBuilder stringBuilder4 = stringBuilder.Append(" ");
					methodBase2 = method;
				}
				if ((object)methodBase2 == null)
				{
					break;
				}
				Type declaringType2 = methodBase2.DeclaringType;
				string value2 = BeautifyType(declaringType2, shortName: false);
				if (stringBuilder == null)
				{
					break;
				}
				StringBuilder stringBuilder5 = stringBuilder.Append(value2);
				if ((object)method == null)
				{
					break;
				}
				if (!method.IsConstructor)
				{
					StringBuilder stringBuilder6 = stringBuilder.Append(".");
				}
				if ((object)method == null)
				{
					break;
				}
				string name = method.Name;
				StringBuilder stringBuilder7 = stringBuilder.Append(name);
				if ((object)method == null)
				{
					break;
				}
				if (method.IsGenericMethod)
				{
					StringBuilder stringBuilder8 = stringBuilder.Append("<");
					if ((object)method == null)
					{
						break;
					}
					Type[] genericArguments = method.GetGenericArguments();
					bool flag6 = genericArguments == null;
					object obj4 = 0;
					if (flag6)
					{
						break;
					}
					while ((nint)obj4 < genericArguments.Length)
					{
						string value3 = BeautifyType(genericArguments[obj4], shortName: true);
						StringBuilder stringBuilder9 = stringBuilder.Append(value3);
						obj4++;
					}
					StringBuilder stringBuilder10 = stringBuilder.Append(">");
				}
				StringBuilder stringBuilder11 = stringBuilder.Append("(");
				if ((object)method == null)
				{
					break;
				}
				ParameterInfo[] parameters = method.GetParameters();
				Func<ParameterInfo, string> selector = _003C_003Ec._003C_003E9__3_0;
				if (_003C_003Ec._003C_003E9__3_0 == null)
				{
					selector = (_003C_003Ec._003C_003E9__3_0 = delegate(ParameterInfo p)
					{
						if (p != null)
						{
							Type parameterType = p.ParameterType;
							string text = BeautifyType(parameterType, shortName: true);
							string name2 = p.Name;
							return text + " " + name2;
						}
						return (string)(object)new NullReferenceException();
					});
					nint num2 = unchecked((nint)null);
				}
				IEnumerable<string> values = Enumerable.Select(parameters, selector);
				string value4 = string.Join(", ", values);
				StringBuilder stringBuilder12 = stringBuilder.Append(value4);
				StringBuilder stringBuilder13 = stringBuilder.Append(")");
				if (displayFilenames)
				{
					int iLOffset = frame.GetILOffset();
					if (iLOffset != -1)
					{
						string fileName = frame.GetFileName();
						if (fileName != null)
						{
							StringBuilder stringBuilder14 = stringBuilder.Append(' ');
							CultureInfo invariantCulture = CultureInfo.InvariantCulture;
							int fileLineNumber = frame.GetFileLineNumber();
							string line = num6.ToString();
							string arg = AppendHyperLink(fileName, line);
							StringBuilder stringBuilder15 = stringBuilder.AppendFormat(invariantCulture, "(at {0})", arg);
							selector = (Func<ParameterInfo, string>)(object)invariantCulture;
						}
					}
				}
				string newLine = Environment.NewLine;
				StringBuilder stringBuilder16 = stringBuilder.Append(newLine);
				goto IL_05c8;
				IL_05c8:
				num++;
				stackTrace2 = stackTrace;
			}
			return (string)(object)new NullReferenceException();
		}
		return "";
	}

	private static bool IsAsync(MethodBase methodInfo)
	{
		//IL_00a0: Expected I4, but got O
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0078: Expected O, but got I
		//IL_0088: Expected O, but got I
		if ((object)methodInfo != null)
		{
			Type declaringType = methodInfo.DeclaringType;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj2 = default(object);
			object obj = obj2 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj3 = default(object);
			if (obj3 != null)
			{
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ r8_v1+298]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ r8_v1+2A0]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ r9_v1 (should have been resolved before IL gen)");
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe static bool TryResolveStateMachineMethod(ref MethodBase method, out Type declaringType)
	{
		//IL_007f: Expected I, but got O
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_03ba: Expected O, but got I
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Expected O, but got Unknown
		//IL_03ee: Expected I4, but got O
		//IL_017e: Expected O, but got Ref
		//IL_0302: Expected I4, but got O
		//IL_0209: Expected O, but got I
		//IL_0279: Expected O, but got I
		MethodBase methodBase = method;
		if ((object)method != null)
		{
			Type declaringType2 = method.DeclaringType;
			ref Type reference = ref *(Type*)declaringType2;
			methodBase = (MethodBase)(object)declaringType;
			if ((object)declaringType != null)
			{
				Type declaringType3 = ((MemberInfo)declaringType).DeclaringType;
				if ((object)declaringType3 != null)
				{
					nint num = (nint)declaringType3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ r8_v10 (Il2CppClass<System.Type>)+7B0]");
					bool flag = false;
					MethodBase methods = (MethodBase)(object)declaringType3.GetMethods((BindingFlags)62);
					if ((object)methods != null)
					{
						bool flag2 = false;
						Type type = null;
						methodBase = methods;
						object obj2 = default(object);
						Type type4 = default(Type);
						object obj3 = default(object);
						object obj5 = default(object);
						Type type5 = default(Type);
						while (true)
						{
							Type type2 = type;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rcx_v8 (System.Reflection.MethodBase)+18]");
							if ((nint)type2 >= 0)
							{
								break;
							}
							Type type3 = type;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rcx_v8 (System.Reflection.MethodBase)+18]");
							if ((nint)type3 < 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
								object obj = obj2 + 32;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rcx_v8 (System.Reflection.MethodBase)+20+v206 @ r15_v10 (System.Type)*8]");
								Attribute[] customAttributes = Attribute.GetCustomAttributes((MemberInfo)0, type4, inherit: false);
								if (customAttributes != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
									if (obj3 == null)
									{
										InvalidCastException ex = new InvalidCastException();
										return (byte)(int)ex != 0;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
									object obj4 = (object)(&flag2);
									methodBase = null;
									while (true)
									{
										if (flag2)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
											if (obj5 == null)
											{
												break;
											}
											bool flag3 = !flag2;
											methodBase = null;
											if (!flag3)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1809F59E0");
												bool flag4 = (object)type5 == null;
												methodBase = null;
												if (!flag4)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
													methodBase = (MethodBase)0;
													if ((object)type5._impl != declaringType)
													{
														continue;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rcx_v8 (System.Reflection.MethodBase)+20+v206 @ r15_v10 (System.Type)*8]");
													ref MethodBase reference2 = ref *(MethodBase*)null;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rcx_v8 (System.Reflection.MethodBase)+20+v206 @ r15_v10 (System.Type)*8]");
													if ((nint)0 != 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v592 @ rcx_v8 (System.Reflection.MethodBase)+20+v206 @ r15_v10 (System.Type)*8]");
														Type declaringType4 = ((MemberInfo)0).DeclaringType;
														reference = ref *(Type*)declaringType4;
														bool flag5 = (object)((object)type5).GetType() != typeof(IteratorStateMachineAttribute);
														Type type6 = null;
														if (!flag5)
														{
															type6 = type5;
														}
														bool flag6 = (object)type6 == null;
														bool result = !flag6;
														if (obj4 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
														}
														return result;
													}
												}
												throw new NullReferenceException();
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									bool flag7 = obj4 == null;
									flag = flag2;
									if (!flag7)
									{
										flag = (byte)(int)obj4 != 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
									}
									methodBase = methods;
								}
								else
								{
									flag = false;
									methodBase = methods;
								}
								type = (Type)(type + 1);
								continue;
							}
							throw new IndexOutOfRangeException();
						}
					}
				}
				return false;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe static string BeautifyType(Type t, bool shortName)
	{
		//IL_003e: Expected I, but got O
		//IL_0046: Expected O, but got Ref
		//IL_04c1: Expected O, but got I
		//IL_04d1: Expected O, but got I
		//IL_012c: Expected O, but got Ref
		//IL_0520: Expected I, but got O
		//IL_043f: Expected I, but got O
		//IL_044f: Expected O, but got I
		//IL_045f: Expected O, but got I
		//IL_046d: Expected I, but got O
		//IL_02dc: Expected O, but got I4
		//IL_0314: Expected O, but got I4
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_061f: Expected I4, but got I8
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected Ref, but got Unknown
		//IL_0259: Expected I8, but got I4
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Expected Ref, but got Unknown
		Type type = default(Type);
		string text3 = default(string);
		string text4;
		string text5;
		object obj2;
		object obj3;
		nint num3;
		if (!((Dictionary<object, object>)(object)builtInTypeNames).TryGetValue((object)type, out object value))
		{
			bool isGenericParameter = type.IsGenericParameter;
			nint num = (nint)type;
			string text = (string)(&value);
			if (isGenericParameter)
			{
				goto IL_04b1;
			}
			if (!type.IsArrayImpl())
			{
				string fullName = type.FullName;
				if (fullName != null)
				{
					bool flag = fullName.StartsWith("System.ValueTuple");
					bool flag2 = !flag;
					text = null;
					if (!flag2)
					{
						Type[] genericArguments = type.GetGenericArguments();
						Func<Type, string> selector = _003C_003Ec._003C_003E9__6_0;
						if (_003C_003Ec._003C_003E9__6_0 == null)
						{
							selector = (_003C_003Ec._003C_003E9__6_0 = (Type x) => BeautifyType(x, shortName: true));
						}
						IEnumerable<string> values = Enumerable.Select(genericArguments, selector);
						string text2 = string.Join(", ", values);
						text3 = "(" + text2 + ")";
						goto IL_058e;
					}
				}
				else
				{
					text = (string)(&value);
				}
				bool isGenericType = type.IsGenericType;
				num = (nint)type;
				if (isGenericType)
				{
					Type[] genericArguments2 = type.GetGenericArguments();
					Func<Type, string> selector2 = _003C_003Ec._003C_003E9__6_1;
					if (_003C_003Ec._003C_003E9__6_1 == null)
					{
						selector2 = (_003C_003Ec._003C_003E9__6_1 = (Type x) => BeautifyType(x, shortName: true));
					}
					IEnumerable<string> values2 = Enumerable.Select(genericArguments2, selector2);
					text4 = string.Join(", ", values2);
					Type genericTypeDefinition = type.GetGenericTypeDefinition();
					string fullName2 = genericTypeDefinition.FullName;
					object obj = "System.Threading.Tasks.Task`1";
					if ((object)fullName2 == "System.Threading.Tasks.Task`1")
					{
						goto IL_029e;
					}
					bool flag3 = fullName2 == null;
					text5 = fullName2;
					if (!flag3)
					{
						bool flag4 = "System.Threading.Tasks.Task`1" == null;
						text5 = fullName2;
						if (!flag4)
						{
							int stringLength = fullName2._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v772 @ rdx_v36+10]");
							bool flag5 = (nint)stringLength != 0;
							text5 = fullName2;
							if (!flag5)
							{
								ref byte first = ref *(byte*)(fullName2 + 20);
								ulong length = (ulong)(fullName2._stringLength + fullName2._stringLength);
								bool flag6 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("System.Threading.Tasks.Task`1" + 20), length);
								bool flag7 = !flag6;
								text5 = fullName2;
								if (!flag7)
								{
									goto IL_029e;
								}
							}
						}
					}
					goto IL_0637;
				}
				if (shortName)
				{
					goto IL_04b1;
				}
				string fullName3 = type.FullName;
				string text6 = fullName3.Replace("Cysharp.Threading.Tasks.Triggers.", "");
				string text7 = text6.Replace("Cysharp.Threading.Tasks.Internal.", "");
				text3 = text7.Replace("Cysharp.Threading.Tasks.", "");
				if (text3 == null)
				{
					nint num2 = (nint)type;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v885 @ rdx_v26 (Il2CppClass<System.Type>)+1B8]");
					obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v885 @ rdx_v26 (Il2CppClass<System.Type>)+1C0]");
					obj3 = 0;
					text = "";
					num3 = unchecked((nint)null);
					goto IL_0628;
				}
			}
			else
			{
				Type elementType = type.GetElementType();
				string text8 = BeautifyType(elementType, shortName);
				text3 = text8 + "[]";
			}
		}
		else
		{
			text3 = (string)value;
		}
		goto IL_058e;
		IL_058e:
		return text3;
		IL_0628:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v525 @ rax_v19 (should have been resolved before IL gen)");
		goto IL_058e;
		IL_029e:
		text5 = "Task";
		goto IL_0637;
		IL_04b1:
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rdx_v11 (Il2CppClass<System.Type>)+1B8]");
		obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ rdx_v11 (Il2CppClass<System.Type>)+1C0]");
		obj3 = 0;
		num3 = 0;
		goto IL_0628;
		IL_0637:
		Regex regex = typeBeautifyRegex;
		if (text5 != null)
		{
			object obj4 = regex.roptions & RegexOptions.RightToLeft;
			bool flag8 = obj4 == null;
			bool flag9 = (nint)obj4 < 0;
			bool flag10 = !flag9;
			object obj5 = !flag10;
			object obj6 = obj5 | flag8;
			if (obj6 == null)
			{
			}
			int startat = default(int);
			string text9 = regex.Replace(text5, "", -1, startat);
			string text10 = text9.Replace("Cysharp.Threading.Tasks.Triggers.", "");
			string text11 = text10.Replace("Cysharp.Threading.Tasks.Internal.", "");
			string text12 = text11.Replace("Cysharp.Threading.Tasks.", "");
			text3 = text12 + "<" + text4 + ">";
			goto IL_058e;
		}
		ArgumentNullException ex = new ArgumentNullException("input");
		ex._002Ector("input");
		throw ex;
	}

	private unsafe static bool IgnoreLine(MethodBase methodInfo)
	{
		//IL_02eb: Expected I4, but got O
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected Ref, but got Unknown
		//IL_011c: Expected I8, but got I4
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected Ref, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected Ref, but got Unknown
		//IL_0240: Expected I8, but got I4
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189993259]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if ((object)methodInfo != null)
		{
			Type declaringType = methodInfo.DeclaringType;
			if ((object)declaringType != null)
			{
				string fullName = declaringType.FullName;
				object obj = "System.Threading.ExecutionContext";
				if ((object)fullName != "System.Threading.ExecutionContext")
				{
					if (fullName == null)
					{
						goto IL_02dd;
					}
					if ("System.Threading.ExecutionContext" != null)
					{
						int stringLength = fullName._stringLength;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rdx_v6+10]");
						if ((nint)stringLength == 0)
						{
							ref byte first = ref *(byte*)(fullName + 20);
							ulong length = (ulong)(fullName._stringLength + fullName._stringLength);
							if (System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("System.Threading.ExecutionContext" + 20), length))
							{
								goto IL_02d7;
							}
							if (fullName == null)
							{
								goto IL_02dd;
							}
						}
					}
					if (!fullName.StartsWith("System.Runtime.CompilerServices") && !fullName.StartsWith("Cysharp.Threading.Tasks.CompilerServices"))
					{
						object obj2 = "System.Threading.Tasks.AwaitTaskContinuation";
						if ((object)fullName != "System.Threading.Tasks.AwaitTaskContinuation")
						{
							if ("System.Threading.Tasks.AwaitTaskContinuation" != null)
							{
								int stringLength2 = fullName._stringLength;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rdx_v11+10]");
								if ((nint)stringLength2 == 0)
								{
									ref byte first2 = ref *(byte*)(fullName + 20);
									ulong length2 = (ulong)(fullName._stringLength + fullName._stringLength);
									if (System.SpanHelpers.SequenceEqual(ref first2, ref *(byte*)("System.Threading.Tasks.AwaitTaskContinuation" + 20), length2))
									{
										goto IL_02d7;
									}
								}
							}
							if (!fullName.StartsWith("System.Threading.Tasks.Task") && !fullName.StartsWith("Cysharp.Threading.Tasks.UniTaskCompletionSourceCore"))
							{
								bool flag = fullName.StartsWith("Cysharp.Threading.Tasks.AwaiterActions");
								if (!flag)
								{
									return flag;
								}
							}
						}
					}
				}
				goto IL_02d7;
			}
		}
		goto IL_02dd;
		IL_02d7:
		return true;
		IL_02dd:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private static string AppendHyperLink(string path, string line)
	{
		//IL_001a: Expected I, but got O
		//IL_0175: Expected O, but got I
		//IL_0185: Expected O, but got I
		bool isNormalized = default(bool);
		FileInfo fileInfo = new FileInfo(path, (string)null, (string)null, isNormalized);
		if (fileInfo != null)
		{
			DirectoryInfo directory = fileInfo.Directory;
			nint num = (nint)fileInfo;
			if (directory != null)
			{
				string fullName = fileInfo.FullName;
				if (fullName != null)
				{
					string text = fullName.Replace(Path.DirectorySeparatorChar, '/');
					if (text != null)
					{
						string text2 = text.Replace(PlayerLoopHelper.applicationDataPath, "");
						string text3 = "Assets/" + text2;
						string[] array = new string[9];
						if (array != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							return string.Concat(array);
						}
					}
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdx_v4 (Il2CppClass<System.IO.FileInfo>)+1C8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rdx_v4 (Il2CppClass<System.IO.FileInfo>)+1D0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v171 @ rax_v7 (should have been resolved before IL gen)");
			}
		}
		return (string)(object)new NullReferenceException();
	}

	static DiagnosticsExtensions()
	{
		//IL_002a: Expected O, but got I
		//IL_00a3: Expected O, but got I
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_07f0: Expected O, but got I
		//IL_00c1: Expected O, but got I
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_082f: Expected O, but got I
		//IL_012b: Expected O, but got I
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_01d8: Expected O, but got I
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_088e: Expected O, but got I
		//IL_08cd: Expected O, but got I
		//IL_024b: Expected O, but got I
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_090c: Expected O, but got I
		//IL_02b5: Expected O, but got I
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		//IL_094b: Expected O, but got I
		//IL_031f: Expected O, but got I
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected O, but got Unknown
		//IL_098a: Expected O, but got I
		//IL_0389: Expected O, but got I
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected O, but got Unknown
		//IL_09c9: Expected O, but got I
		//IL_03f3: Expected O, but got I
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Expected O, but got Unknown
		//IL_0a08: Expected O, but got I
		//IL_045d: Expected O, but got I
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0491: Expected O, but got Unknown
		//IL_0a47: Expected O, but got I
		//IL_04c7: Expected O, but got I
		//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fb: Expected O, but got Unknown
		//IL_0a86: Expected O, but got I
		//IL_0531: Expected O, but got I
		//IL_0560: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Expected O, but got Unknown
		//IL_0ac5: Expected O, but got I
		//IL_059b: Expected O, but got I
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cf: Expected O, but got Unknown
		//IL_0b04: Expected O, but got I
		//IL_0605: Expected O, but got I
		//IL_0634: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Expected O, but got Unknown
		//IL_0677: Unknown result type (might be due to invalid IL or missing references)
		//IL_067c: Expected O, but got Unknown
		//IL_06ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bf: Expected O, but got Unknown
		//IL_06fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0702: Expected O, but got Unknown
		//IL_0740: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Expected O, but got Unknown
		displayFilenames = true;
		Regex regex = new Regex("`.+$", RegexOptions.Compiled);
		typeBeautifyRegex = regex;
		Dictionary<Type, string> dictionary = new Dictionary<Type, string>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE90]");
		object obj = (nint)0 + (nint)32;
		object key;
		if (obj != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj3 = default(object);
			object obj2 = obj3 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj4 = default(object);
			key = obj4;
		}
		else
		{
			key = null;
		}
		bool flag = dictionary == null;
		bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key, (object)"void", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE98]");
		object obj5 = (nint)0 + (nint)32;
		object key2;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rcx_v143+E4]");
			flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj8 = default(object);
			object obj7 = obj8 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj9 = default(object);
			key2 = obj9;
		}
		else
		{
			key2 = null;
		}
		bool flag3 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key2, (object)"bool", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE88]");
		object obj10 = (nint)0 + (nint)32;
		object key3;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rcx_v140+E4]");
			flag = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj13 = default(object);
			object obj12 = obj13 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj14 = default(object);
			key3 = obj14;
		}
		else
		{
			key3 = null;
		}
		bool flag4 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key3, (object)"byte", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF8]");
		object obj15 = (nint)0 + (nint)32;
		object key4;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj17 = default(object);
			object obj16 = obj17 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj18 = default(object);
			key4 = obj18;
		}
		else
		{
			key4 = null;
		}
		bool flag5 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key4, (object)"char", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
		object obj19 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ rcx_v134+E4]");
		bool flag6 = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj21 = default(object);
		object obj20 = obj21 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj22 = default(object);
		object key5 = obj22;
		bool flag7 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key5, (object)"decimal", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEF0]");
		object obj23 = (nint)0 + (nint)32;
		object key6;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
			object obj24 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rcx_v131+E4]");
			flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj26 = default(object);
			object obj25 = obj26 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj27 = default(object);
			key6 = obj27;
		}
		else
		{
			key6 = null;
		}
		bool flag8 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key6, (object)"double", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEE8]");
		object obj28 = (nint)0 + (nint)32;
		object key7;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
			object obj29 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rcx_v128+E4]");
			flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj31 = default(object);
			object obj30 = obj31 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj32 = default(object);
			key7 = obj32;
		}
		else
		{
			key7 = null;
		}
		bool flag9 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key7, (object)"float", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB8]");
		object obj33 = (nint)0 + (nint)32;
		object key8;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
			object obj34 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ rcx_v125+E4]");
			flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj36 = default(object);
			object obj35 = obj36 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj37 = default(object);
			key8 = obj37;
		}
		else
		{
			key8 = null;
		}
		bool flag10 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key8, (object)"int", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AED8]");
		object obj38 = (nint)0 + (nint)32;
		object key9;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
			object obj39 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v665 @ rcx_v122+E4]");
			flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj41 = default(object);
			object obj40 = obj41 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj42 = default(object);
			key9 = obj42;
		}
		else
		{
			key9 = null;
		}
		bool flag11 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key9, (object)"long", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AE80]");
		object obj43 = (nint)0 + (nint)32;
		object key10;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
			object obj44 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ rcx_v119+E4]");
			flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj46 = default(object);
			object obj45 = obj46 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj47 = default(object);
			key10 = obj47;
		}
		else
		{
			key10 = null;
		}
		bool flag12 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key10, (object)"object", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEA0]");
		object obj48 = (nint)0 + (nint)32;
		object key11;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
			object obj49 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v757 @ rcx_v116+E4]");
			flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj51 = default(object);
			object obj50 = obj51 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj52 = default(object);
			key11 = obj52;
		}
		else
		{
			key11 = null;
		}
		bool flag13 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key11, (object)"sbyte", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEA8]");
		object obj53 = (nint)0 + (nint)32;
		object key12;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
			object obj54 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v803 @ rcx_v113+E4]");
			flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj56 = default(object);
			object obj55 = obj56 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj57 = default(object);
			key12 = obj57;
		}
		else
		{
			key12 = null;
		}
		bool flag14 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key12, (object)"short", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj58 = (nint)0 + (nint)32;
		object key13;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
			object obj59 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v849 @ rcx_v110+E4]");
			flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj61 = default(object);
			object obj60 = obj61 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj62 = default(object);
			key13 = obj62;
		}
		else
		{
			key13 = null;
		}
		bool flag15 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key13, (object)"string", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEC0]");
		object obj63 = (nint)0 + (nint)32;
		object key14;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
			object obj64 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v895 @ rcx_v107+E4]");
			flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj66 = default(object);
			object obj65 = obj66 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj67 = default(object);
			key14 = obj67;
		}
		else
		{
			key14 = null;
		}
		bool flag16 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key14, (object)"uint", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEE0]");
		object obj68 = (nint)0 + (nint)32;
		object key15;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF50]");
			object obj69 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v941 @ rcx_v104+E4]");
			flag6 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj71 = default(object);
			object obj70 = obj71 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj72 = default(object);
			key15 = obj72;
		}
		else
		{
			key15 = null;
		}
		bool flag17 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key15, (object)"ulong", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AEB0]");
		object obj73 = (nint)0 + (nint)32;
		object key16;
		if (!flag6)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
			object obj75 = default(object);
			object obj74 = obj75 + 32;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
			object obj76 = default(object);
			key16 = obj76;
		}
		else
		{
			key16 = null;
		}
		bool flag18 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key16, (object)"ushort", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj78 = default(object);
		object obj77 = obj78 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj79 = default(object);
		object key17 = obj79;
		bool flag19 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key17, (object)"Task", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj81 = default(object);
		object obj80 = obj81 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj82 = default(object);
		object key18 = obj82;
		bool flag20 = ((Dictionary<object, object>)(object)dictionary).TryInsert(key18, (object)"UniTask", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		object obj83 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj85 = default(object);
		object obj84 = obj85 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		object obj86 = default(object);
		obj83 = obj86;
		bool flag21 = ((Dictionary<object, object>)(object)dictionary).TryInsert(obj83, (object)"UniTaskVoid", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		builtInTypeNames = dictionary;
	}
}
