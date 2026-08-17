using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors.Tools.CheatCommand;

internal static class CheatCommandsDatabase
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<Assembly, bool> _003C_003E9__2_0;

		public static Func<Assembly, IEnumerable<Type>> _003C_003E9__2_1;

		public static Func<Type, IEnumerable<MethodInfo>> _003C_003E9__2_2;

		public static Func<MethodInfo, bool> _003C_003E9__2_3;

		public static Func<MethodInfo, string> _003C_003E9__2_4;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal bool _003CRegisterCommands_003Eb__2_0(Assembly assembly)
		{
			//IL_004c: Expected I4, but got O
			if ((object)assembly != null)
			{
				bool isDynamic = assembly.IsDynamic;
				return !isDynamic;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}

		internal IEnumerable<Type> _003CRegisterCommands_003Eb__2_1(Assembly assembly)
		{
			//IL_0025: Expected I, but got O
			//IL_0035: Expected O, but got I
			//IL_0045: Expected O, but got I
			if ((object)assembly != null)
			{
				nint num = (nint)assembly;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rdx_v1 (Il2CppClass<System.Reflection.Assembly>)+288]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rdx_v1 (Il2CppClass<System.Reflection.Assembly>)+290]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v14 @ rax_v2 (should have been resolved before IL gen)");
			}
			return (IEnumerable<Type>)new NullReferenceException();
		}

		internal IEnumerable<MethodInfo> _003CRegisterCommands_003Eb__2_2(Type type)
		{
			//IL_0025: Expected I, but got O
			//IL_0035: Expected O, but got I
			//IL_0045: Expected O, but got I
			if ((object)type != null)
			{
				nint num = (nint)type;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r8_v1 (Il2CppClass<System.Type>)+7A8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r8_v1 (Il2CppClass<System.Type>)+7B0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v15 @ rax_v2 (should have been resolved before IL gen)");
			}
			return (IEnumerable<MethodInfo>)new NullReferenceException();
		}

		internal bool _003CRegisterCommands_003Eb__2_3(MethodInfo method)
		{
			CheatAttribute customAttribute = CustomAttributeExtensions.GetCustomAttribute<CheatAttribute>(method);
			bool flag = customAttribute == null;
			return !flag;
		}

		internal string _003CRegisterCommands_003Eb__2_4(MethodInfo method)
		{
			CheatAttribute customAttribute = CustomAttributeExtensions.GetCustomAttribute<CheatAttribute>(method);
			if (customAttribute != null)
			{
				string result = customAttribute._003CAlias_003Ek__BackingField;
				if (customAttribute._003CAlias_003Ek__BackingField == null)
				{
					if ((object)method == null)
					{
						goto IL_0066;
					}
					result = method.Name;
				}
				return result;
			}
			goto IL_0066;
			IL_0066:
			return (string)(object)new NullReferenceException();
		}
	}

	private static Dictionary<string, MethodInfo> _methodInfoCache;

	public static void ExecuteCommand(string methodName, string[] args)
	{
		//IL_005d: Expected I, but got O
		//IL_00aa: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		string message;
		if (_methodInfoCache != null)
		{
			int num = _methodInfoCache.FindEntry(methodName);
			if (num >= 0)
			{
				MethodInfo methodInfo = _methodInfoCache.get_Item(methodName);
				nint num2 = (nint)methodInfo;
				ParameterInfo[] parameters = methodInfo.GetParameters();
				if (parameters.Length == args.Length)
				{
					object[] array = new object[parameters.Length];
					object obj = 0;
					object obj2 = 0;
					object obj5 = default(object);
					while (true)
					{
						if ((nint)obj2 < args.Length)
						{
							Type parameterType = parameters[obj].ParameterType;
							object obj3 = Convert.ChangeType(args[obj], parameterType, CultureInfo.invariant_culture_info);
							if (obj3 != null)
							{
								object obj4 = array;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
								if (obj5 == null)
								{
									break;
								}
							}
							array[obj] = obj3;
							obj++;
							obj2 = obj;
							continue;
						}
						object obj6 = methodInfo.Invoke(null, BindingFlags.Default, null, null, null);
						return;
					}
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				object arg2 = default(object);
				message = $"UnityConsole: Command `{methodName}` requires {arg} args, while {arg2} were provided.";
				goto IL_01f3;
			}
		}
		message = "UnityConsole: Command `" + methodName + "` is not registered in the database.";
		goto IL_01f3;
		IL_01f3:
		Debug.LogWarning(message);
	}

	internal static void RegisterCommands(Dictionary<string, MethodInfo> commands = null)
	{
		Dictionary<string, MethodInfo> dictionary = default(Dictionary<string, MethodInfo>);
		bool flag = dictionary != null;
		Dictionary<string, MethodInfo> methodInfoCache = dictionary;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC50F0");
			AppDomain appDomain;
			object obj = default(object);
			if (obj != null)
			{
				appDomain = (AppDomain)obj;
			}
			else
			{
				appDomain = null;
				obj = appDomain;
			}
			Assembly[] assemblies = appDomain.GetAssemblies();
			Func<Assembly, bool> predicate = _003C_003Ec._003C_003E9__2_0;
			if (_003C_003Ec._003C_003E9__2_0 == null)
			{
				predicate = (_003C_003Ec._003C_003E9__2_0 = delegate(Assembly assembly)
				{
					//IL_004c: Expected I4, but got O
					if ((object)assembly == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					bool isDynamic = assembly.IsDynamic;
					return !isDynamic;
				});
			}
			IEnumerable<Assembly> source = Enumerable.Where(assemblies, predicate);
			Func<Assembly, IEnumerable<Type>> selector = _003C_003Ec._003C_003E9__2_1;
			if (_003C_003Ec._003C_003E9__2_1 == null)
			{
				selector = (_003C_003Ec._003C_003E9__2_1 = delegate(Assembly assembly)
				{
					//IL_0025: Expected I, but got O
					//IL_0035: Expected O, but got I
					//IL_0045: Expected O, but got I
					if ((object)assembly != null)
					{
						nint num = (nint)assembly;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rdx_v1 (Il2CppClass<System.Reflection.Assembly>)+288]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ rdx_v1 (Il2CppClass<System.Reflection.Assembly>)+290]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v14 @ rax_v2 (should have been resolved before IL gen)");
					}
					return (IEnumerable<Type>)new NullReferenceException();
				});
			}
			IEnumerable<Type> source2 = Enumerable.SelectMany(source, selector);
			Func<Type, IEnumerable<MethodInfo>> selector2 = _003C_003Ec._003C_003E9__2_2;
			if (_003C_003Ec._003C_003E9__2_2 == null)
			{
				selector2 = (_003C_003Ec._003C_003E9__2_2 = delegate(Type type)
				{
					//IL_0025: Expected I, but got O
					//IL_0035: Expected O, but got I
					//IL_0045: Expected O, but got I
					if ((object)type != null)
					{
						nint num = (nint)type;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r8_v1 (Il2CppClass<System.Type>)+7A8]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ r8_v1 (Il2CppClass<System.Type>)+7B0]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v15 @ rax_v2 (should have been resolved before IL gen)");
					}
					return (IEnumerable<MethodInfo>)new NullReferenceException();
				});
			}
			IEnumerable<MethodInfo> source3 = Enumerable.SelectMany(source2, selector2);
			Func<MethodInfo, bool> predicate2 = _003C_003Ec._003C_003E9__2_3;
			if (_003C_003Ec._003C_003E9__2_3 == null)
			{
				predicate2 = (_003C_003Ec._003C_003E9__2_3 = delegate(MethodInfo method)
				{
					CheatAttribute customAttribute = CustomAttributeExtensions.GetCustomAttribute<CheatAttribute>(method);
					bool flag2 = customAttribute == null;
					return !flag2;
				});
			}
			IEnumerable<MethodInfo> source4 = Enumerable.Where(source3, predicate2);
			Func<object, object> keySelector = (Func<object, object>)_003C_003Ec._003C_003E9__2_4;
			if (_003C_003Ec._003C_003E9__2_4 == null)
			{
				keySelector = (Func<object, object>)(_003C_003Ec._003C_003E9__2_4 = delegate(MethodInfo method)
				{
					CheatAttribute customAttribute = CustomAttributeExtensions.GetCustomAttribute<CheatAttribute>(method);
					if (customAttribute != null)
					{
						string result = customAttribute._003CAlias_003Ek__BackingField;
						if (customAttribute._003CAlias_003Ek__BackingField == null)
						{
							if ((object)method == null)
							{
								goto IL_0066;
							}
							result = method.Name;
						}
						return result;
					}
					goto IL_0066;
					IL_0066:
					return (string)(object)new NullReferenceException();
				});
			}
			Func<object, object> instance = System.Linq.IdentityFunction<object>.Instance;
			Dictionary<object, object> dictionary2 = Enumerable.ToDictionary(source4, keySelector, instance, (IEqualityComparer<object>)(object)StringComparer.s_ordinalIgnoreCase);
			methodInfoCache = (Dictionary<string, MethodInfo>)(object)dictionary2;
		}
		_methodInfoCache = methodInfoCache;
	}

	static CheatCommandsDatabase()
	{
		Dictionary<string, MethodInfo> methodInfoCache = new Dictionary<string, MethodInfo>();
		_methodInfoCache = methodInfoCache;
	}
}
