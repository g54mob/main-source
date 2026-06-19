using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace MessagePack.Internal
{
	public static class AutomataKeyGen
	{
		public delegate ulong PointerDelegate<T>(ref T p, ref int rest);

		private static MethodInfo dynamicGetKeyMethod;

		private static readonly object gate = new object();

		private static DynamicAssembly dynamicAssembly;

		public static MethodInfo GetGetKeyMethod()
		{
			if (dynamicGetKeyMethod == null)
			{
				lock (gate)
				{
					if (dynamicGetKeyMethod == null)
					{
						dynamicAssembly = new DynamicAssembly("AutomataKeyGenHelper");
						TypeBuilder typeBuilder = dynamicAssembly.DefineType("AutomataKeyGen", TypeAttributes.Public | TypeAttributes.Abstract | TypeAttributes.Sealed, null);
						ILGenerator iLGenerator = typeBuilder.DefineMethod("GetKey", MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig, typeof(ulong), new Type[2]
						{
							typeof(byte).MakePointerType().MakeByRefType(),
							typeof(int).MakeByRefType()
						}).GetILGenerator();
						iLGenerator.DeclareLocal(typeof(int));
						iLGenerator.DeclareLocal(typeof(ulong));
						iLGenerator.DeclareLocal(typeof(int));
						Label label = iLGenerator.DefineLabel();
						Label label2 = iLGenerator.DefineLabel();
						Label label3 = iLGenerator.DefineLabel();
						Label label4 = iLGenerator.DefineLabel();
						Label label5 = iLGenerator.DefineLabel();
						Label label6 = iLGenerator.DefineLabel();
						Label label7 = iLGenerator.DefineLabel();
						Label label8 = iLGenerator.DefineLabel();
						Label label9 = iLGenerator.DefineLabel();
						Label label10 = iLGenerator.DefineLabel();
						iLGenerator.Emit(OpCodes.Ldarg_1);
						iLGenerator.Emit(OpCodes.Ldind_I4);
						iLGenerator.Emit(OpCodes.Ldc_I4_8);
						iLGenerator.Emit(OpCodes.Blt_S, label);
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldind_I);
						iLGenerator.Emit(OpCodes.Ldind_I8);
						iLGenerator.Emit(OpCodes.Stloc_1);
						iLGenerator.Emit(OpCodes.Ldc_I4_8);
						iLGenerator.Emit(OpCodes.Stloc_0);
						iLGenerator.Emit(OpCodes.Br, label2);
						iLGenerator.MarkLabel(label);
						iLGenerator.Emit(OpCodes.Ldarg_1);
						iLGenerator.Emit(OpCodes.Ldind_I4);
						iLGenerator.Emit(OpCodes.Stloc_2);
						iLGenerator.Emit(OpCodes.Ldloc_2);
						iLGenerator.Emit(OpCodes.Switch, new Label[8] { label3, label4, label5, label6, label7, label8, label9, label10 });
						iLGenerator.Emit(OpCodes.Br, label3);
						iLGenerator.MarkLabel(label4);
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldind_I);
						iLGenerator.Emit(OpCodes.Ldind_U1);
						iLGenerator.Emit(OpCodes.Conv_U8);
						iLGenerator.Emit(OpCodes.Stloc_1);
						iLGenerator.Emit(OpCodes.Ldc_I4_1);
						iLGenerator.Emit(OpCodes.Stloc_0);
						iLGenerator.Emit(OpCodes.Br, label2);
						iLGenerator.MarkLabel(label5);
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldind_I);
						iLGenerator.Emit(OpCodes.Ldind_U2);
						iLGenerator.Emit(OpCodes.Conv_U8);
						iLGenerator.Emit(OpCodes.Stloc_1);
						iLGenerator.Emit(OpCodes.Ldc_I4_2);
						iLGenerator.Emit(OpCodes.Stloc_0);
						iLGenerator.Emit(OpCodes.Br, label2);
						iLGenerator.MarkLabel(label6);
						iLGenerator.DeclareLocal(typeof(ushort));
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldind_I);
						iLGenerator.Emit(OpCodes.Ldind_U1);
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldind_I);
						iLGenerator.Emit(OpCodes.Ldc_I4_1);
						iLGenerator.Emit(OpCodes.Add);
						iLGenerator.Emit(OpCodes.Ldind_U2);
						iLGenerator.Emit(OpCodes.Stloc_3);
						iLGenerator.Emit(OpCodes.Conv_U8);
						iLGenerator.Emit(OpCodes.Ldloc_3);
						iLGenerator.Emit(OpCodes.Conv_U8);
						iLGenerator.Emit(OpCodes.Ldc_I4_8);
						iLGenerator.Emit(OpCodes.Shl);
						iLGenerator.Emit(OpCodes.Or);
						iLGenerator.Emit(OpCodes.Stloc_1);
						iLGenerator.Emit(OpCodes.Ldc_I4_3);
						iLGenerator.Emit(OpCodes.Stloc_0);
						iLGenerator.Emit(OpCodes.Br, label2);
						iLGenerator.MarkLabel(label7);
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldind_I);
						iLGenerator.Emit(OpCodes.Ldind_U4);
						iLGenerator.Emit(OpCodes.Conv_U8);
						iLGenerator.Emit(OpCodes.Stloc_1);
						iLGenerator.Emit(OpCodes.Ldc_I4_4);
						iLGenerator.Emit(OpCodes.Stloc_0);
						iLGenerator.Emit(OpCodes.Br, label2);
						iLGenerator.MarkLabel(label8);
						iLGenerator.DeclareLocal(typeof(uint));
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldind_I);
						iLGenerator.Emit(OpCodes.Ldind_U1);
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldind_I);
						iLGenerator.Emit(OpCodes.Ldc_I4_1);
						iLGenerator.Emit(OpCodes.Add);
						iLGenerator.Emit(OpCodes.Ldind_U4);
						iLGenerator.Emit(OpCodes.Stloc_S, 4);
						iLGenerator.Emit(OpCodes.Conv_U8);
						iLGenerator.Emit(OpCodes.Ldloc_S, 4);
						iLGenerator.Emit(OpCodes.Conv_U8);
						iLGenerator.Emit(OpCodes.Ldc_I4_8);
						iLGenerator.Emit(OpCodes.Shl);
						iLGenerator.Emit(OpCodes.Or);
						iLGenerator.Emit(OpCodes.Stloc_1);
						iLGenerator.Emit(OpCodes.Ldc_I4_5);
						iLGenerator.Emit(OpCodes.Stloc_0);
						iLGenerator.Emit(OpCodes.Br, label2);
						iLGenerator.MarkLabel(label9);
						iLGenerator.DeclareLocal(typeof(ulong));
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldind_I);
						iLGenerator.Emit(OpCodes.Ldind_U2);
						iLGenerator.Emit(OpCodes.Conv_U8);
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldind_I);
						iLGenerator.Emit(OpCodes.Ldc_I4_2);
						iLGenerator.Emit(OpCodes.Add);
						iLGenerator.Emit(OpCodes.Ldind_U4);
						iLGenerator.Emit(OpCodes.Conv_U8);
						iLGenerator.Emit(OpCodes.Stloc_S, 5);
						iLGenerator.Emit(OpCodes.Ldloc_S, 5);
						iLGenerator.Emit(OpCodes.Ldc_I4_S, 16);
						iLGenerator.Emit(OpCodes.Shl);
						iLGenerator.Emit(OpCodes.Or);
						iLGenerator.Emit(OpCodes.Stloc_1);
						iLGenerator.Emit(OpCodes.Ldc_I4_6);
						iLGenerator.Emit(OpCodes.Stloc_0);
						iLGenerator.Emit(OpCodes.Br, label2);
						iLGenerator.MarkLabel(label10);
						iLGenerator.DeclareLocal(typeof(ushort));
						iLGenerator.DeclareLocal(typeof(uint));
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldind_I);
						iLGenerator.Emit(OpCodes.Ldind_U1);
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldind_I);
						iLGenerator.Emit(OpCodes.Ldc_I4_1);
						iLGenerator.Emit(OpCodes.Add);
						iLGenerator.Emit(OpCodes.Ldind_U2);
						iLGenerator.Emit(OpCodes.Stloc_S, 6);
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldind_I);
						iLGenerator.Emit(OpCodes.Ldc_I4_3);
						iLGenerator.Emit(OpCodes.Add);
						iLGenerator.Emit(OpCodes.Ldind_U4);
						iLGenerator.Emit(OpCodes.Stloc_S, 7);
						iLGenerator.Emit(OpCodes.Conv_U8);
						iLGenerator.Emit(OpCodes.Ldloc_S, 6);
						iLGenerator.Emit(OpCodes.Conv_U8);
						iLGenerator.Emit(OpCodes.Ldc_I4_8);
						iLGenerator.Emit(OpCodes.Shl);
						iLGenerator.Emit(OpCodes.Or);
						iLGenerator.Emit(OpCodes.Ldloc_S, 7);
						iLGenerator.Emit(OpCodes.Conv_U8);
						iLGenerator.Emit(OpCodes.Ldc_I4_S, 24);
						iLGenerator.Emit(OpCodes.Shl);
						iLGenerator.Emit(OpCodes.Or);
						iLGenerator.Emit(OpCodes.Stloc_1);
						iLGenerator.Emit(OpCodes.Ldc_I4_7);
						iLGenerator.Emit(OpCodes.Stloc_0);
						iLGenerator.Emit(OpCodes.Br, label2);
						iLGenerator.MarkLabel(label3);
						iLGenerator.Emit(OpCodes.Ldstr, "Not Supported Length");
						iLGenerator.Emit(OpCodes.Newobj, typeof(InvalidOperationException).GetConstructor(new Type[1] { typeof(string) }));
						iLGenerator.Emit(OpCodes.Throw);
						iLGenerator.MarkLabel(label2);
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldarg_0);
						iLGenerator.Emit(OpCodes.Ldind_I);
						iLGenerator.Emit(OpCodes.Ldloc_0);
						iLGenerator.Emit(OpCodes.Add);
						iLGenerator.Emit(OpCodes.Stind_I);
						iLGenerator.Emit(OpCodes.Ldarg_1);
						iLGenerator.Emit(OpCodes.Ldarg_1);
						iLGenerator.Emit(OpCodes.Ldind_I4);
						iLGenerator.Emit(OpCodes.Ldloc_0);
						iLGenerator.Emit(OpCodes.Sub);
						iLGenerator.Emit(OpCodes.Stind_I4);
						iLGenerator.Emit(OpCodes.Ldloc_1);
						iLGenerator.Emit(OpCodes.Ret);
						dynamicGetKeyMethod = typeBuilder.CreateTypeInfo().AsType().GetMethods()
							.First();
					}
				}
			}
			return dynamicGetKeyMethod;
		}

		public static ulong GetKeySafe(byte[] bytes, ref int offset, ref int rest)
		{
			ulong result;
			int num;
			if (BitConverter.IsLittleEndian)
			{
				if (rest >= 8)
				{
					result = bytes[offset] | ((ulong)bytes[offset + 1] << 8) | ((ulong)bytes[offset + 2] << 16) | ((ulong)bytes[offset + 3] << 24) | ((ulong)bytes[offset + 4] << 32) | ((ulong)bytes[offset + 5] << 40) | ((ulong)bytes[offset + 6] << 48) | ((ulong)bytes[offset + 7] << 56);
					num = 8;
				}
				else
				{
					switch (rest)
					{
					case 1:
						result = bytes[offset];
						num = 1;
						break;
					case 2:
						result = bytes[offset] | ((ulong)bytes[offset + 1] << 8);
						num = 2;
						break;
					case 3:
						result = bytes[offset] | ((ulong)bytes[offset + 1] << 8) | ((ulong)bytes[offset + 2] << 16);
						num = 3;
						break;
					case 4:
						result = bytes[offset] | ((ulong)bytes[offset + 1] << 8) | ((ulong)bytes[offset + 2] << 16) | ((ulong)bytes[offset + 3] << 24);
						num = 4;
						break;
					case 5:
						result = bytes[offset] | ((ulong)bytes[offset + 1] << 8) | ((ulong)bytes[offset + 2] << 16) | ((ulong)bytes[offset + 3] << 24) | ((ulong)bytes[offset + 4] << 32);
						num = 5;
						break;
					case 6:
						result = bytes[offset] | ((ulong)bytes[offset + 1] << 8) | ((ulong)bytes[offset + 2] << 16) | ((ulong)bytes[offset + 3] << 24) | ((ulong)bytes[offset + 4] << 32) | ((ulong)bytes[offset + 5] << 40);
						num = 6;
						break;
					case 7:
						result = bytes[offset] | ((ulong)bytes[offset + 1] << 8) | ((ulong)bytes[offset + 2] << 16) | ((ulong)bytes[offset + 3] << 24) | ((ulong)bytes[offset + 4] << 32) | ((ulong)bytes[offset + 5] << 40) | ((ulong)bytes[offset + 6] << 48);
						num = 7;
						break;
					default:
						throw new InvalidOperationException("Not Supported Length");
					}
				}
				offset += num;
				rest -= num;
				return result;
			}
			if (rest >= 8)
			{
				result = ((ulong)bytes[offset] << 56) | ((ulong)bytes[offset + 1] << 48) | ((ulong)bytes[offset + 2] << 40) | ((ulong)bytes[offset + 3] << 32) | ((ulong)bytes[offset + 4] << 24) | ((ulong)bytes[offset + 5] << 16) | ((ulong)bytes[offset + 6] << 8) | bytes[offset + 7];
				num = 8;
			}
			else
			{
				switch (rest)
				{
				case 1:
					result = bytes[offset];
					num = 1;
					break;
				case 2:
					result = ((ulong)bytes[offset] << 8) | bytes[offset + 1];
					num = 2;
					break;
				case 3:
					result = ((ulong)bytes[offset] << 16) | ((ulong)bytes[offset + 1] << 8) | bytes[offset + 2];
					num = 3;
					break;
				case 4:
					result = ((ulong)bytes[offset] << 24) | ((ulong)bytes[offset + 1] << 16) | ((ulong)bytes[offset + 2] << 8) | bytes[offset + 3];
					num = 4;
					break;
				case 5:
					result = ((ulong)bytes[offset] << 32) | ((ulong)bytes[offset + 1] << 24) | ((ulong)bytes[offset + 2] << 16) | ((ulong)bytes[offset + 3] << 8) | bytes[offset + 4];
					num = 5;
					break;
				case 6:
					result = ((ulong)bytes[offset] << 40) | ((ulong)bytes[offset + 1] << 32) | ((ulong)bytes[offset + 2] << 24) | ((ulong)bytes[offset + 3] << 16) | ((ulong)bytes[offset + 4] << 8) | bytes[offset + 5];
					num = 6;
					break;
				case 7:
					result = ((ulong)bytes[offset] << 48) | ((ulong)bytes[offset + 1] << 40) | ((ulong)bytes[offset + 2] << 32) | ((ulong)bytes[offset + 3] << 24) | ((ulong)bytes[offset + 4] << 16) | ((ulong)bytes[offset + 5] << 8) | bytes[offset + 6];
					num = 7;
					break;
				default:
					throw new InvalidOperationException("Not Supported Length");
				}
			}
			offset += num;
			rest -= num;
			return result;
		}
	}
}
