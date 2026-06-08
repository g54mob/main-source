using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class ConvertExpression : Expression
	{
		private readonly Expression right;

		private Type fromType;

		private Type target;

		public ConvertExpression(Type targetType, Expression right)
			: this(targetType, typeof(object), right)
		{
		}

		public ConvertExpression(Type targetType, Type fromType, Expression right)
		{
			target = targetType;
			this.fromType = fromType;
			this.right = right;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			right.Emit(member, gen);
			if (fromType == target)
			{
				return;
			}
			if (fromType.GetTypeInfo().IsByRef)
			{
				fromType = fromType.GetElementType();
			}
			if (target.IsByRef)
			{
				target = target.GetElementType();
			}
			if (target.GetTypeInfo().IsValueType)
			{
				if (fromType.GetTypeInfo().IsValueType)
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
			else if (fromType.GetTypeInfo().IsValueType)
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
			else if (from.GetTypeInfo().IsGenericParameter)
			{
				gen.Emit(OpCodes.Box, from);
			}
			else if (target.GetTypeInfo().IsGenericType && target != from)
			{
				gen.Emit(OpCodes.Castclass, target);
			}
			else if (target.GetTypeInfo().IsSubclassOf(from))
			{
				gen.Emit(OpCodes.Castclass, target);
			}
		}
	}
}
