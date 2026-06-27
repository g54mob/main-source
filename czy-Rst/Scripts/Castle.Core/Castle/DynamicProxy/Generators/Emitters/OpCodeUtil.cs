using System;
using System.Reflection.Emit;

namespace Castle.DynamicProxy.Generators.Emitters
{
	internal abstract class OpCodeUtil
	{
		public static void EmitLoadIndirectOpCodeForType(ILGenerator gen, Type type)
		{
			if (type.IsEnum)
			{
				EmitLoadIndirectOpCodeForType(gen, GetUnderlyingTypeOfEnum(type));
				return;
			}
			if (type.IsByRef)
			{
				throw new NotSupportedException("Cannot load ByRef values");
			}
			if (type.IsPrimitive && type != typeof(IntPtr) && type != typeof(UIntPtr))
			{
				OpCode opCode = LdindOpCodesDictionary.Instance[type];
				if (opCode == LdindOpCodesDictionary.EmptyOpCode)
				{
					throw new ArgumentException("Type " + type?.ToString() + " could not be converted to a OpCode");
				}
				gen.Emit(opCode);
			}
			else if (type.IsValueType)
			{
				gen.Emit(OpCodes.Ldobj, type);
			}
			else if (type.IsGenericParameter)
			{
				gen.Emit(OpCodes.Ldobj, type);
			}
			else
			{
				gen.Emit(OpCodes.Ldind_Ref);
			}
		}

		public static void EmitLoadOpCodeForDefaultValueOfType(ILGenerator gen, Type type)
		{
			if (type.IsPrimitive)
			{
				OpCode opcode = LdcOpCodesDictionary.Instance[type];
				switch (opcode.StackBehaviourPush)
				{
				case StackBehaviour.Pushi:
					gen.Emit(opcode, 0);
					if (Is64BitTypeLoadedAsInt32(type))
					{
						gen.Emit(OpCodes.Conv_I8);
					}
					break;
				case StackBehaviour.Pushr8:
					gen.Emit(opcode, 0.0);
					break;
				case StackBehaviour.Pushi8:
					gen.Emit(opcode, 0L);
					break;
				case StackBehaviour.Pushr4:
					gen.Emit(opcode, 0f);
					break;
				default:
					throw new NotSupportedException();
				}
			}
			else
			{
				gen.Emit(OpCodes.Ldnull);
			}
		}

		public static void EmitStoreIndirectOpCodeForType(ILGenerator gen, Type type)
		{
			if (type.IsEnum)
			{
				EmitStoreIndirectOpCodeForType(gen, GetUnderlyingTypeOfEnum(type));
				return;
			}
			if (type.IsByRef)
			{
				throw new NotSupportedException("Cannot store ByRef values");
			}
			if (type.IsPrimitive && type != typeof(IntPtr) && type != typeof(UIntPtr))
			{
				OpCode opCode = StindOpCodesDictionary.Instance[type];
				if (object.Equals(opCode, StindOpCodesDictionary.EmptyOpCode))
				{
					throw new ArgumentException("Type " + type?.ToString() + " could not be converted to a OpCode");
				}
				gen.Emit(opCode);
			}
			else if (type.IsValueType)
			{
				gen.Emit(OpCodes.Stobj, type);
			}
			else if (type.IsGenericParameter)
			{
				gen.Emit(OpCodes.Stobj, type);
			}
			else
			{
				gen.Emit(OpCodes.Stind_Ref);
			}
		}

		private static Type GetUnderlyingTypeOfEnum(Type enumType)
		{
			return ((IConvertible)Activator.CreateInstance(enumType)).GetTypeCode() switch
			{
				TypeCode.SByte => typeof(sbyte), 
				TypeCode.Byte => typeof(byte), 
				TypeCode.Int16 => typeof(short), 
				TypeCode.Int32 => typeof(int), 
				TypeCode.Int64 => typeof(long), 
				TypeCode.UInt16 => typeof(ushort), 
				TypeCode.UInt32 => typeof(uint), 
				TypeCode.UInt64 => typeof(ulong), 
				_ => throw new NotSupportedException(), 
			};
		}

		private static bool Is64BitTypeLoadedAsInt32(Type type)
		{
			if (!(type == typeof(long)))
			{
				return type == typeof(ulong);
			}
			return true;
		}
	}
}
