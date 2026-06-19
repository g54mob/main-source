using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic.Enumerable;
using System.Diagnostics.Internal;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Diagnostics
{
	internal class EnhancedStackTrace : StackTrace, IEnumerable<EnhancedStackFrame>, IEnumerable
	{
		internal enum GeneratedNameKind
		{
			None = 0,
			ThisProxyField = 52,
			HoistedLocalField = 53,
			DisplayClassLocalOrField = 56,
			LambdaMethod = 98,
			LambdaDisplayClass = 99,
			StateMachineType = 100,
			LocalFunction = 103,
			AwaiterField = 117,
			HoistedSynthesizedLocalField = 115,
			StateMachineStateField = 49,
			IteratorCurrentBackingField = 50,
			StateMachineParameterProxyField = 51,
			ReusableHoistedLocalField = 55,
			LambdaCacheField = 57,
			FixedBufferField = 101,
			AnonymousType = 102,
			TransparentIdentifier = 104,
			AnonymousTypeField = 105,
			AutoPropertyBackingField = 107,
			IteratorCurrentThreadIdField = 108,
			IteratorFinallyMethod = 109,
			BaseMethodWrapper = 110,
			AsyncBuilderField = 116,
			DynamicCallSiteContainerType = 111,
			DynamicCallSiteField = 112
		}

		private readonly List<EnhancedStackFrame> _frames;

		private static readonly Type? StackTraceHiddenAttributeType;

		private static readonly Type? AsyncIteratorStateMachineAttributeType;

		public override int FrameCount => _frames.Count;

		public static EnhancedStackTrace Current()
		{
			return new EnhancedStackTrace(new StackTrace(1, fNeedFileInfo: true));
		}

		public EnhancedStackTrace(Exception e)
		{
			if (e == null)
			{
				throw new ArgumentNullException("e");
			}
			_frames = GetFrames(e);
		}

		public EnhancedStackTrace(StackTrace stackTrace)
		{
			if (stackTrace == null)
			{
				throw new ArgumentNullException("stackTrace");
			}
			_frames = GetFrames(stackTrace);
		}

		public override StackFrame GetFrame(int index)
		{
			return _frames[index];
		}

		public override StackFrame[] GetFrames()
		{
			return _frames.ToArray();
		}

		public override string ToString()
		{
			if (_frames == null || _frames.Count == 0)
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			Append(stringBuilder);
			return stringBuilder.ToString();
		}

		internal void Append(StringBuilder sb)
		{
			List<EnhancedStackFrame> list = _frames;
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				if (i > 0)
				{
					sb.Append(Environment.NewLine);
				}
				EnhancedStackFrame enhancedStackFrame = list[i];
				sb.Append("   at ");
				enhancedStackFrame.MethodInfo.Append(sb);
				string fileName = enhancedStackFrame.GetFileName();
				if (fileName != null && !string.IsNullOrEmpty(fileName))
				{
					sb.Append(" in ");
					sb.Append(TryGetFullPath(fileName));
				}
				int fileLineNumber = enhancedStackFrame.GetFileLineNumber();
				if (fileLineNumber != 0)
				{
					sb.Append(":line ");
					sb.Append(fileLineNumber);
				}
			}
		}

		private EnumerableIList<EnhancedStackFrame> GetEnumerator()
		{
			return EnumerableIList.Create(_frames);
		}

		IEnumerator<EnhancedStackFrame> IEnumerable<EnhancedStackFrame>.GetEnumerator()
		{
			return _frames.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _frames.GetEnumerator();
		}

		public static string TryGetFullPath(string filePath)
		{
			if (Uri.TryCreate(filePath, UriKind.Absolute, out var result) && result.IsFile)
			{
				return Uri.UnescapeDataString(result.AbsolutePath);
			}
			return filePath;
		}

		static EnhancedStackTrace()
		{
			StackTraceHiddenAttributeType = Type.GetType("System.Diagnostics.StackTraceHiddenAttribute", throwOnError: false);
			AsyncIteratorStateMachineAttributeType = Type.GetType("System.Runtime.CompilerServices.AsyncIteratorStateMachineAttribute", throwOnError: false);
			if (!(AsyncIteratorStateMachineAttributeType != null))
			{
				Assembly assembly;
				try
				{
					assembly = Assembly.Load("Microsoft.Bcl.AsyncInterfaces");
				}
				catch
				{
					return;
				}
				AsyncIteratorStateMachineAttributeType = assembly.GetType("System.Runtime.CompilerServices.AsyncIteratorStateMachineAttribute", throwOnError: false);
			}
		}

		private static List<EnhancedStackFrame> GetFrames(Exception exception)
		{
			if (exception == null)
			{
				return new List<EnhancedStackFrame>();
			}
			bool fNeedFileInfo = true;
			return GetFrames(new StackTrace(exception, fNeedFileInfo));
		}

		public static List<EnhancedStackFrame> GetFrames(StackTrace stackTrace)
		{
			List<EnhancedStackFrame> list = new List<EnhancedStackFrame>();
			StackFrame[] array = stackTrace.GetFrames();
			if (array == null)
			{
				return list;
			}
			EnhancedStackFrame enhancedStackFrame = null;
			PortablePdbReader portablePdbReader = null;
			try
			{
				for (int i = 0; i < array.Length; i++)
				{
					StackFrame stackFrame = array[i];
					if (stackFrame == null)
					{
						continue;
					}
					MethodBase method = stackFrame.GetMethod();
					if (method != null && !ShowInStackTrace(method) && i < array.Length - 1)
					{
						continue;
					}
					string fileName = stackFrame.GetFileName();
					int row = stackFrame.GetFileLineNumber();
					int column = stackFrame.GetFileColumnNumber();
					int iLOffset = stackFrame.GetILOffset();
					if (method != null && string.IsNullOrEmpty(fileName) && iLOffset >= 0)
					{
						(portablePdbReader ?? (portablePdbReader = new PortablePdbReader())).PopulateStackFrame(stackFrame, method, stackFrame.GetILOffset(), out fileName, out row, out column);
					}
					if ((object)method != null)
					{
						ResolvedMethod methodDisplayString = GetMethodDisplayString(method);
						if (enhancedStackFrame != null && enhancedStackFrame.IsEquivalent(methodDisplayString, fileName, row, column))
						{
							enhancedStackFrame.IsRecursive = true;
							continue;
						}
						EnhancedStackFrame enhancedStackFrame2 = new EnhancedStackFrame(stackFrame, methodDisplayString, fileName, row, column);
						list.Add(enhancedStackFrame2);
						enhancedStackFrame = enhancedStackFrame2;
					}
				}
				return list;
			}
			finally
			{
				portablePdbReader?.Dispose();
			}
		}

		public static ResolvedMethod GetMethodDisplayString(MethodBase originMethod)
		{
			MethodBase method = originMethod;
			ResolvedMethod resolvedMethod = new ResolvedMethod
			{
				SubMethodBase = method
			};
			Type declaringType = method.DeclaringType;
			string subMethodName = method.Name;
			string methodName = method.Name;
			bool flag = typeof(IAsyncStateMachine).IsAssignableFrom(declaringType);
			if (flag || typeof(IEnumerator).IsAssignableFrom(declaringType))
			{
				resolvedMethod.IsAsync = flag;
				if (!TryResolveStateMachineMethod(ref method, out declaringType))
				{
					resolvedMethod.SubMethodBase = null;
					subMethodName = null;
				}
				methodName = method.Name;
			}
			else if (IsFSharpAsync(method))
			{
				resolvedMethod.IsAsync = true;
				resolvedMethod.SubMethodBase = null;
				subMethodName = null;
				methodName = null;
			}
			resolvedMethod.MethodBase = method;
			resolvedMethod.Name = methodName;
			if (method.Name.IndexOf("<") >= 0)
			{
				if (TryResolveGeneratedName(ref method, out declaringType, out methodName, out subMethodName, out GeneratedNameKind kind, out int? ordinal))
				{
					methodName = method.Name;
					resolvedMethod.MethodBase = method;
					resolvedMethod.Name = methodName;
					resolvedMethod.Ordinal = ordinal;
				}
				else
				{
					resolvedMethod.MethodBase = null;
				}
				resolvedMethod.IsLambda = kind == GeneratedNameKind.LambdaMethod;
				if (resolvedMethod.IsLambda && declaringType != null && methodName == ".cctor" && (!declaringType.IsGenericTypeDefinition || declaringType.IsConstructedGenericType))
				{
					FieldInfo[] fields = declaringType.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
					foreach (FieldInfo fieldInfo in fields)
					{
						if (fieldInfo.GetValue(fieldInfo) is Delegate { Target: not null } obj && obj.Method == originMethod && obj.Target.ToString() == originMethod.DeclaringType?.ToString())
						{
							resolvedMethod.Name = fieldInfo.Name;
							resolvedMethod.IsLambda = false;
							method = originMethod;
							break;
						}
					}
				}
			}
			if (subMethodName != methodName)
			{
				resolvedMethod.SubMethod = subMethodName;
			}
			if (declaringType != null)
			{
				resolvedMethod.DeclaringType = declaringType;
			}
			if (method is MethodInfo methodInfo)
			{
				if (methodInfo.ReturnParameter != null)
				{
					resolvedMethod.ReturnParameter = GetParameter(methodInfo.ReturnParameter);
				}
				else if (methodInfo.ReturnType != null)
				{
					resolvedMethod.ReturnParameter = new ResolvedParameter(methodInfo.ReturnType)
					{
						Prefix = "",
						Name = ""
					};
				}
			}
			if (method.IsGenericMethod)
			{
				Type[] genericArguments = method.GetGenericArguments();
				string text = string.Join(", ", genericArguments.Select((Type arg) => TypeNameHelper.GetTypeDisplayName(arg, fullName: false, includeGenericParameterNames: true)));
				resolvedMethod.GenericArguments = resolvedMethod.GenericArguments + "<" + text + ">";
				resolvedMethod.ResolvedGenericArguments = genericArguments;
			}
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length != 0)
			{
				List<ResolvedParameter> list = new List<ResolvedParameter>(parameters.Length);
				ParameterInfo[] array = parameters;
				foreach (ParameterInfo parameter in array)
				{
					list.Add(GetParameter(parameter));
				}
				resolvedMethod.Parameters = list;
			}
			if (resolvedMethod.SubMethodBase == resolvedMethod.MethodBase)
			{
				resolvedMethod.SubMethodBase = null;
			}
			else if (resolvedMethod.SubMethodBase != null)
			{
				parameters = resolvedMethod.SubMethodBase.GetParameters();
				if (parameters.Length != 0)
				{
					List<ResolvedParameter> list2 = new List<ResolvedParameter>(parameters.Length);
					ParameterInfo[] array = parameters;
					for (int i = 0; i < array.Length; i++)
					{
						ResolvedParameter parameter2 = GetParameter(array[i]);
						string? name = parameter2.Name;
						if (name != null && !name.StartsWith("<"))
						{
							list2.Add(parameter2);
						}
					}
					resolvedMethod.SubMethodParameters = list2;
				}
			}
			return resolvedMethod;
		}

		private static bool IsFSharpAsync(MethodBase method)
		{
			if (method is MethodInfo { ReturnType: var returnType } && returnType.Namespace == "Microsoft.FSharp.Control" && returnType.Name == "FSharpAsync`1")
			{
				return true;
			}
			return false;
		}

		private static bool TryResolveGeneratedName(ref MethodBase method, out Type? type, out string methodName, out string? subMethodName, out GeneratedNameKind kind, out int? ordinal)
		{
			kind = GeneratedNameKind.None;
			type = method.DeclaringType;
			subMethodName = null;
			ordinal = null;
			methodName = method.Name;
			string text = methodName;
			if (!TryParseGeneratedName(text, out kind, out var openBracketOffset, out var closeBracketOffset))
			{
				return false;
			}
			methodName = text.Substring(openBracketOffset + 1, closeBracketOffset - openBracketOffset - 1);
			switch (kind)
			{
			case GeneratedNameKind.LocalFunction:
			{
				int num = text.IndexOf((char)kind, closeBracketOffset + 1);
				if (num < 0)
				{
					break;
				}
				num += 3;
				if (num < text.Length)
				{
					int num2 = text.IndexOf("|", num);
					if (num2 > 0)
					{
						subMethodName = text.Substring(num, num2 - num);
					}
				}
				break;
			}
			case GeneratedNameKind.LambdaMethod:
				subMethodName = "";
				break;
			}
			Type declaringType = method.DeclaringType;
			if (declaringType == null)
			{
				return false;
			}
			string matchHint = GetMatchHint(kind, method);
			string matchName = methodName;
			if (TryResolveSourceMethod(from m in declaringType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
				where m.Name == matchName
				select m, kind, matchHint, ref method, ref type, out ordinal))
			{
				return true;
			}
			if (TryResolveSourceMethod(from m in declaringType.GetConstructors(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
				where m.Name == matchName
				select m, kind, matchHint, ref method, ref type, out ordinal))
			{
				return true;
			}
			for (int num3 = 0; num3 < 10; num3++)
			{
				declaringType = declaringType.DeclaringType;
				if (declaringType == null)
				{
					return false;
				}
				if (TryResolveSourceMethod(from m in declaringType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
					where m.Name == matchName
					select m, kind, matchHint, ref method, ref type, out ordinal))
				{
					return true;
				}
				if (TryResolveSourceMethod(from m in declaringType.GetConstructors(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
					where m.Name == matchName
					select m, kind, matchHint, ref method, ref type, out ordinal))
				{
					return true;
				}
				if (!(methodName == ".cctor"))
				{
					continue;
				}
				using IEnumerator<ConstructorInfo> enumerator = (from m in declaringType.GetConstructors(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
					where m.Name == matchName
					select m).GetEnumerator();
				if (enumerator.MoveNext())
				{
					ConstructorInfo current = enumerator.Current;
					method = current;
					type = declaringType;
					return true;
				}
			}
			return false;
		}

		private static bool TryResolveSourceMethod(IEnumerable<MethodBase> candidateMethods, GeneratedNameKind kind, string? matchHint, ref MethodBase method, ref Type? type, out int? ordinal)
		{
			ordinal = null;
			foreach (MethodBase candidateMethod in candidateMethods)
			{
				MethodBody methodBody = null;
				try
				{
					methodBody = candidateMethod.GetMethodBody();
				}
				catch
				{
				}
				if (methodBody == null)
				{
					continue;
				}
				if (kind == GeneratedNameKind.LambdaMethod)
				{
					using EnumeratorIList<LocalVariableInfo> enumeratorIList = EnumerableIList.Create(methodBody.LocalVariables).GetEnumerator();
					if (enumeratorIList.MoveNext())
					{
						if (enumeratorIList.Current.LocalType == type)
						{
							GetOrdinal(method, ref ordinal);
						}
						method = candidateMethod;
						type = method.DeclaringType;
						return true;
					}
				}
				try
				{
					byte[] iLAsByteArray = methodBody.GetILAsByteArray();
					if (iLAsByteArray == null)
					{
						continue;
					}
					ILReader iLReader = new ILReader(iLAsByteArray);
					while (iLReader.Read(candidateMethod))
					{
						if (iLReader.Operand is MethodBase methodBase && (method == methodBase || (matchHint != null && method.Name.Contains(matchHint))))
						{
							if (kind == GeneratedNameKind.LambdaMethod)
							{
								GetOrdinal(method, ref ordinal);
							}
							method = candidateMethod;
							type = method.DeclaringType;
							return true;
						}
					}
				}
				catch
				{
				}
			}
			return false;
		}

		private static void GetOrdinal(MethodBase method, ref int? ordinal)
		{
			int num = method.Name.IndexOf("b__") + 3;
			if (num <= 3)
			{
				return;
			}
			int num2 = method.Name.IndexOf("_", num) + 1;
			if (num2 > 0)
			{
				num = num2;
			}
			if (!int.TryParse(method.Name.Substring(num), out var result))
			{
				ordinal = null;
				return;
			}
			ordinal = result;
			MethodInfo[] array = method.DeclaringType?.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			int num3 = 0;
			if (array != null)
			{
				string value = method.Name.Substring(0, num);
				MethodInfo[] array2 = array;
				foreach (MethodInfo methodInfo in array2)
				{
					if (methodInfo.Name.Length > num && methodInfo.Name.StartsWith(value))
					{
						num3++;
						if (num3 > 1)
						{
							break;
						}
					}
				}
			}
			if (num3 <= 1)
			{
				ordinal = null;
			}
		}

		private static string? GetMatchHint(GeneratedNameKind kind, MethodBase method)
		{
			string name = method.Name;
			if (kind == GeneratedNameKind.LocalFunction)
			{
				int num = name.IndexOf("|");
				if (num < 1)
				{
					return null;
				}
				int num2 = name.IndexOf("_", num) + 1;
				if (num2 <= num)
				{
					return null;
				}
				return name.Substring(num, num2 - num);
			}
			return null;
		}

		internal static bool TryParseGeneratedName(string name, out GeneratedNameKind kind, out int openBracketOffset, out int closeBracketOffset)
		{
			openBracketOffset = -1;
			if (name.StartsWith("CS$<", StringComparison.Ordinal))
			{
				openBracketOffset = 3;
			}
			else if (name.StartsWith("<", StringComparison.Ordinal))
			{
				openBracketOffset = 0;
			}
			if (openBracketOffset >= 0)
			{
				closeBracketOffset = IndexOfBalancedParenthesis(name, openBracketOffset, '>');
				if (closeBracketOffset >= 0 && closeBracketOffset + 1 < name.Length)
				{
					int num = name[closeBracketOffset + 1];
					if ((num >= 49 && num <= 57) || (num >= 97 && num <= 122))
					{
						kind = (GeneratedNameKind)num;
						return true;
					}
				}
			}
			kind = GeneratedNameKind.None;
			openBracketOffset = -1;
			closeBracketOffset = -1;
			return false;
		}

		private static int IndexOfBalancedParenthesis(string str, int openingOffset, char closing)
		{
			char c = str[openingOffset];
			int num = 1;
			for (int i = openingOffset + 1; i < str.Length; i++)
			{
				char c2 = str[i];
				if (c2 == c)
				{
					num++;
				}
				else if (c2 == closing)
				{
					num--;
					if (num == 0)
					{
						return i;
					}
				}
			}
			return -1;
		}

		private static string GetPrefix(ParameterInfo parameter)
		{
			if (Attribute.IsDefined(parameter, typeof(ParamArrayAttribute), inherit: false))
			{
				return "params";
			}
			if (parameter.IsOut)
			{
				return "out";
			}
			if (parameter.IsIn)
			{
				return "in";
			}
			if (parameter.ParameterType.IsByRef)
			{
				return "ref";
			}
			return string.Empty;
		}

		private static ResolvedParameter GetParameter(ParameterInfo parameter)
		{
			string text = GetPrefix(parameter);
			Type type = parameter.ParameterType;
			if (type.IsGenericType)
			{
				IList<string> list = parameter.GetCustomAttributes(inherit: false).OfType<TupleElementNamesAttribute>().FirstOrDefault()?.TransformNames;
				if (list != null && list.Count > 0)
				{
					return GetValueTupleParameter(list, text, parameter.Name, type);
				}
			}
			if (type.IsByRef)
			{
				Type elementType = type.GetElementType();
				if ((object)elementType != null)
				{
					type = elementType;
				}
			}
			return new ResolvedParameter(type)
			{
				Prefix = text,
				Name = parameter.Name,
				IsDynamicType = parameter.IsDefined(typeof(DynamicAttribute), inherit: false)
			};
		}

		private static ResolvedParameter GetValueTupleParameter(IList<string?> tupleNames, string prefix, string? name, Type parameterType)
		{
			return new ValueTupleResolvedParameter(parameterType, tupleNames)
			{
				Prefix = prefix,
				Name = name
			};
		}

		private static string GetValueTupleParameterName(IList<string> tupleNames, Type parameterType)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("(");
			Type[] genericArguments = parameterType.GetGenericArguments();
			for (int i = 0; i < genericArguments.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(TypeNameHelper.GetTypeDisplayName(genericArguments[i], fullName: false, includeGenericParameterNames: true));
				if (i < tupleNames.Count)
				{
					string text = tupleNames[i];
					if (text != null)
					{
						stringBuilder.Append(" ");
						stringBuilder.Append(text);
					}
				}
			}
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}

		private static bool ShowInStackTrace(MethodBase method)
		{
			if ((method.MethodImplementationFlags & MethodImplAttributes.AggressiveInlining) != MethodImplAttributes.IL)
			{
				return false;
			}
			if (StackTraceHiddenAttributeType != null && IsStackTraceHidden(method))
			{
				return false;
			}
			Type declaringType = method.DeclaringType;
			if (declaringType == null)
			{
				return true;
			}
			if (StackTraceHiddenAttributeType != null && IsStackTraceHidden(declaringType))
			{
				return false;
			}
			if (declaringType == typeof(Task<>) && method.Name == "InnerInvoke")
			{
				return false;
			}
			if (declaringType == typeof(ValueTask<>) && method.Name == "get_Result")
			{
				return false;
			}
			if (method.Name.StartsWith("System.Threading.Tasks.Sources.IValueTaskSource") && method.Name.EndsWith(".GetResult"))
			{
				return false;
			}
			if (method.Name == "GetResult" && method.DeclaringType?.FullName == "System.Threading.Tasks.Sources.ManualResetValueTaskSourceCore`1")
			{
				return false;
			}
			if (declaringType == typeof(Task) || declaringType.DeclaringType == typeof(Task))
			{
				if (method.Name.Contains(".cctor"))
				{
					return false;
				}
				switch (method.Name)
				{
				case "ExecuteWithThreadLocal":
				case "Execute":
				case "ExecutionContextCallback":
				case "ExecuteEntry":
				case "InnerInvoke":
				case "ExecuteEntryUnsafe":
				case "ExecuteFromThreadPool":
					return false;
				}
			}
			if (declaringType == typeof(ExecutionContext))
			{
				if (method.Name.Contains(".cctor"))
				{
					return false;
				}
				switch (method.Name)
				{
				case "RunInternal":
				case "Run":
				case "RunFromThreadPoolDispatchLoop":
					return false;
				}
			}
			if (declaringType.Namespace == "Microsoft.FSharp.Control")
			{
				string name = declaringType.Name;
				if (name == "AsyncPrimitives" || name == "Trampoline")
				{
					return false;
				}
				if (declaringType.IsGenericType && name == "AsyncResult`1")
				{
					return false;
				}
			}
			if (declaringType.Namespace == "Ply" && declaringType.DeclaringType?.Name == "TplPrimitives")
			{
				return false;
			}
			if (declaringType == typeof(ExceptionDispatchInfo) && method.Name == "Throw")
			{
				return false;
			}
			if (declaringType == typeof(TaskAwaiter) || declaringType == typeof(TaskAwaiter<>) || declaringType == typeof(ValueTaskAwaiter) || declaringType == typeof(ValueTaskAwaiter<>) || declaringType == typeof(ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter) || declaringType == typeof(ConfiguredValueTaskAwaitable<>.ConfiguredValueTaskAwaiter) || declaringType == typeof(ConfiguredTaskAwaitable.ConfiguredTaskAwaiter) || declaringType == typeof(ConfiguredTaskAwaitable<>.ConfiguredTaskAwaiter))
			{
				switch (method.Name)
				{
				case "HandleNonSuccessAndDebuggerNotification":
				case "ThrowForNonSuccess":
				case "ValidateEnd":
				case "GetResult":
					return false;
				}
			}
			else if (declaringType.FullName == "System.ThrowHelper")
			{
				return false;
			}
			return true;
		}

		private static bool IsStackTraceHidden(MemberInfo memberInfo)
		{
			if ((object)StackTraceHiddenAttributeType != null && !memberInfo.Module.Assembly.ReflectionOnly)
			{
				return memberInfo.GetCustomAttributes(StackTraceHiddenAttributeType, inherit: false).Length != 0;
			}
			EnumerableIList<CustomAttributeData> enumerableIList;
			try
			{
				enumerableIList = EnumerableIList.Create(memberInfo.GetCustomAttributesData());
			}
			catch (NotImplementedException)
			{
				return false;
			}
			foreach (CustomAttributeData item in enumerableIList)
			{
				if (item.AttributeType.FullName == StackTraceHiddenAttributeType?.FullName)
				{
					return true;
				}
			}
			return false;
		}

		private static bool TryResolveStateMachineMethod(ref MethodBase method, out Type declaringType)
		{
			if ((object)method.DeclaringType == null)
			{
				declaringType = null;
				return false;
			}
			declaringType = method.DeclaringType;
			Type declaringType2 = declaringType.DeclaringType;
			if ((object)declaringType2 == null)
			{
				return false;
			}
			MethodInfo[] array = GetDeclaredMethods(declaringType2);
			if (array == null)
			{
				return false;
			}
			MethodInfo[] array2 = array;
			foreach (MethodInfo methodInfo in array2)
			{
				IEnumerable<StateMachineAttribute> customAttributes = methodInfo.GetCustomAttributes<StateMachineAttribute>(inherit: false);
				if (customAttributes == null)
				{
					continue;
				}
				bool flag = false;
				bool flag2 = false;
				foreach (StateMachineAttribute item in customAttributes)
				{
					if (item.StateMachineType == declaringType)
					{
						flag = true;
						flag2 |= item is IteratorStateMachineAttribute || (AsyncIteratorStateMachineAttributeType != null && AsyncIteratorStateMachineAttributeType.IsInstanceOfType(item));
					}
				}
				if (flag)
				{
					method = methodInfo;
					declaringType = methodInfo.DeclaringType;
					return flag2;
				}
			}
			return false;
			static MethodInfo[] GetDeclaredMethods(Type type)
			{
				return type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			}
		}
	}
}
