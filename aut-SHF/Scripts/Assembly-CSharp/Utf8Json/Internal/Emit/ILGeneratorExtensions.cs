using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Utf8Json.Internal.Emit
{
	internal static class ILGeneratorExtensions
	{
		public static void EmitLdloc(this ILGenerator il, int index)
		{
		}

		public static void EmitLdloc(this ILGenerator il, LocalBuilder local)
		{
		}

		public static void EmitStloc(this ILGenerator il, int index)
		{
		}

		public static void EmitStloc(this ILGenerator il, LocalBuilder local)
		{
		}

		public static void EmitLdloca(this ILGenerator il, int index)
		{
		}

		public static void EmitLdloca(this ILGenerator il, LocalBuilder local)
		{
		}

		public static void EmitTrue(this ILGenerator il)
		{
		}

		public static void EmitFalse(this ILGenerator il)
		{
		}

		public static void EmitBoolean(this ILGenerator il, bool value)
		{
		}

		public static void EmitLdc_I4(this ILGenerator il, int value)
		{
		}

		public static void EmitUnboxOrCast(this ILGenerator il, Type type)
		{
		}

		public static void EmitBoxOrDoNothing(this ILGenerator il, Type type)
		{
		}

		public static void EmitLdarg(this ILGenerator il, int index)
		{
		}

		public static void EmitLoadThis(this ILGenerator il)
		{
		}

		public static void EmitLdarga(this ILGenerator il, int index)
		{
		}

		public static void EmitStarg(this ILGenerator il, int index)
		{
		}

		public static void EmitPop(this ILGenerator il, int count)
		{
		}

		public static void EmitCall(this ILGenerator il, MethodInfo methodInfo)
		{
		}

		public static void EmitLdfld(this ILGenerator il, FieldInfo fieldInfo)
		{
		}

		public static void EmitLdsfld(this ILGenerator il, FieldInfo fieldInfo)
		{
		}

		public static void EmitRet(this ILGenerator il)
		{
		}

		public static void EmitIntZeroReturn(this ILGenerator il)
		{
		}

		public static void EmitNullReturn(this ILGenerator il)
		{
		}

		public static void EmitULong(this ILGenerator il, ulong value)
		{
		}

		public static void EmitThrowNotimplemented(this ILGenerator il)
		{
		}

		public static void EmitIncrementFor(this ILGenerator il, LocalBuilder conditionGreater, Action<LocalBuilder> emitBody)
		{
		}
	}
}
