using System;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class ConvertExpression : IExpression, IExpressionOrStatement
	{
		private readonly IExpression right;

		private Type fromType;

		private Type target;

		public ConvertExpression(Type targetType, IExpression right)
			: this(targetType, typeof(object), right)
		{
		}

		public ConvertExpression(Type targetType, Type fromType, IExpression right)
		{
			target = targetType;
			this.fromType = fromType;
			this.right = right;
		}

		public void Emit(ILGenerator gen)
		{
			right.Emit(gen);
			if (fromType == target)
			{
				return;
			}
			if (fromType.IsByRef)
			{
				fromType = fromType.GetElementType();
			}
			if (target.IsByRef)
			{
				target = target.GetElementType();
			}
			if (target.IsValueType)
			{
				if (fromType.IsValueType)
				{
					throw new NotImplementedException("Cannot convert between distinct value types");
				}
				if (LdindOpCodesDictionary.Instance[target] != LdindOpCodesDictionary.EmptyOpCode)
				{
					gen.Emit(OpCodes.Unbox, target);
					OpCodeUtil.EmitLoadIndirectOpCodeForType(gen, target);
				}
				else
				{
					gen.Emit(OpCodes.Unbox_Any, target);
				}
			}
			else if (fromType.IsValueType)
			{
				gen.Emit(OpCodes.Box, fromType);
				EmitCastIfNeeded(typeof(object), target, gen);
			}
			else
			{
				EmitCastIfNeeded(fromType, target, gen);
			}
		}

		private static void EmitCastIfNeeded(Type from, Type target, ILGenerator gen)
		{
			if (target.IsGenericParameter)
			{
				gen.Emit(OpCodes.Unbox_Any, target);
			}
			else if (from.IsGenericParameter)
			{
				gen.Emit(OpCodes.Box, from);
			}
			else if (target.IsGenericType && target != from)
			{
				gen.Emit(OpCodes.Castclass, target);
			}
			else if (target.IsSubclassOf(from))
			{
				gen.Emit(OpCodes.Castclass, target);
			}
		}
	}
}
