using System;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	internal class DefaultValueExpression : IExpression, IExpressionOrStatement
	{
		private readonly Type type;

		public DefaultValueExpression(Type type)
		{
			this.type = type;
		}

		public void Emit(ILGenerator gen)
		{
			if (IsPrimitiveOrClass(type))
			{
				OpCodeUtil.EmitLoadOpCodeForDefaultValueOfType(gen, type);
			}
			else if (type.IsValueType || type.IsGenericParameter)
			{
				LocalBuilder local = gen.DeclareLocal(type);
				gen.Emit(OpCodes.Ldloca_S, local);
				gen.Emit(OpCodes.Initobj, type);
				gen.Emit(OpCodes.Ldloc, local);
			}
			else
			{
				if (!type.IsByRef)
				{
					throw new NotImplementedException("Can't emit default value for type " + type);
				}
				EmitByRef(gen);
			}
		}

		private void EmitByRef(ILGenerator gen)
		{
			Type elementType = type.GetElementType();
			if (IsPrimitiveOrClass(elementType))
			{
				OpCodeUtil.EmitLoadOpCodeForDefaultValueOfType(gen, elementType);
				OpCodeUtil.EmitStoreIndirectOpCodeForType(gen, elementType);
				return;
			}
			if (elementType.IsGenericParameter || elementType.IsValueType)
			{
				gen.Emit(OpCodes.Initobj, elementType);
				return;
			}
			throw new NotImplementedException("Can't emit default value for reference of type " + elementType);
		}

		private bool IsPrimitiveOrClass(Type type)
		{
			if (type.IsPrimitive && type != typeof(IntPtr) && type != typeof(UIntPtr))
			{
				return true;
			}
			if ((type.IsClass || type.IsInterface) && !type.IsGenericParameter)
			{
				return !type.IsByRef;
			}
			return false;
		}
	}
}
