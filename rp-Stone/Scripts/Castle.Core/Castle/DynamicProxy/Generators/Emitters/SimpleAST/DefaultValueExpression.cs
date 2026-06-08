using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters.SimpleAST
{
	public class DefaultValueExpression : Expression
	{
		private readonly Type type;

		public DefaultValueExpression(Type type)
		{
			this.type = type;
		}

		public override void Emit(IMemberEmitter member, ILGenerator gen)
		{
			if (IsPrimitiveOrClass(type))
			{
				OpCodeUtil.EmitLoadOpCodeForDefaultValueOfType(gen, type);
			}
			else if (type.GetTypeInfo().IsValueType || type.GetTypeInfo().IsGenericParameter)
			{
				LocalBuilder local = gen.DeclareLocal(type);
				gen.Emit(OpCodes.Ldloca_S, local);
				gen.Emit(OpCodes.Initobj, type);
				gen.Emit(OpCodes.Ldloc, local);
			}
			else
			{
				if (!type.GetTypeInfo().IsByRef)
				{
					throw new ProxyGenerationException("Can't emit default value for type " + type);
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
			if (elementType.GetTypeInfo().IsGenericParameter || elementType.GetTypeInfo().IsValueType)
			{
				gen.Emit(OpCodes.Initobj, elementType);
				return;
			}
			throw new ProxyGenerationException("Can't emit default value for reference of type " + elementType);
		}

		private bool IsPrimitiveOrClass(Type type)
		{
			if (type.GetTypeInfo().IsPrimitive && type != typeof(IntPtr))
			{
				return true;
			}
			if ((type.GetTypeInfo().IsClass || type.GetTypeInfo().IsInterface) && !type.GetTypeInfo().IsGenericParameter)
			{
				return !type.GetTypeInfo().IsByRef;
			}
			return false;
		}
	}
}
