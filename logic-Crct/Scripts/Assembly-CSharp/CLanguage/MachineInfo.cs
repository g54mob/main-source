using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using CLanguage.Compiler;
using CLanguage.Interpreter;
using CLanguage.Types;

namespace CLanguage
{
	public class MachineInfo
	{
		public CInterpreter interpreter;

		public Dictionary<string, string> SystemHeadersCode;

		private static readonly MethodInfo miReadArg;

		private static readonly MethodInfo miPush;

		private static readonly MethodInfo miReadString;

		private static readonly Expression[] noExprs;

		public static readonly MachineInfo Windows32;

		public static readonly MachineInfo Mac64;

		public int CharSize { get; set; }

		public int ShortIntSize { get; set; }

		public int IntSize { get; set; }

		public int LongIntSize { get; set; }

		public int LongLongIntSize { get; set; }

		public int FloatSize { get; set; }

		public int DoubleSize { get; set; }

		public int LongDoubleSize { get; set; }

		public int PointerSize { get; set; }

		public string HeaderCode { get; set; }

		public Collection<BaseFunction> InternalFunctions { get; set; }

		public string GeneratedHeaderCode => null;

		public void AddInternalFunction(string prototype, InternalFunctionAction? action = null)
		{
		}

		public void AddGlobalMethods(object target)
		{
		}

		public void AddGlobalReference(string name, object target)
		{
		}

		private void AddTargetMethods(string? name, object target)
		{
		}

		private InternalFunctionAction MarshalMethod(object target, MethodInfo method)
		{
			return null;
		}

		private string ClrTypeToCode(Type type)
		{
			return null;
		}

		public virtual ResolvedVariable GetUnresolvedVariable(string name, CType[]? argTypes, EmitContext context)
		{
			return null;
		}
	}
}
