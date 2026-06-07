using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace AltSerialize
{
	internal static class DynamicSerializerFactory
	{
		private static Type[] streamTypes = new Type[13]
		{
			typeof(int),
			typeof(uint),
			typeof(short),
			typeof(ushort),
			typeof(long),
			typeof(ulong),
			typeof(DateTime),
			typeof(TimeSpan),
			typeof(float),
			typeof(double),
			typeof(decimal),
			typeof(Guid),
			typeof(string)
		};

		private static MethodInfo[] _serializeMethods;

		private static MethodInfo[] _deserializeMethods;

		public static MethodInfo[] SerializeMethods
		{
			get
			{
				if (_serializeMethods == null)
				{
					Methods();
				}
				return _serializeMethods;
			}
		}

		public static MethodInfo[] DeserializeMethods
		{
			get
			{
				if (_deserializeMethods == null)
				{
					Methods();
				}
				return _deserializeMethods;
			}
		}

		private static MethodInfo GetDeserializeMethod(Type type)
		{
			for (int i = 0; i < streamTypes.Length; i++)
			{
				if (type == streamTypes[i])
				{
					return DeserializeMethods[i];
				}
			}
			return null;
		}

		private static MethodInfo GetSerializerMethod(Type type)
		{
			for (int i = 0; i < streamTypes.Length; i++)
			{
				if (type == streamTypes[i])
				{
					return SerializeMethods[i];
				}
			}
			return null;
		}

		private static void Methods()
		{
			Type typeFromHandle = typeof(AltSerializer);
			_serializeMethods = new MethodInfo[streamTypes.Length];
			_deserializeMethods = new MethodInfo[streamTypes.Length];
			for (int i = 0; i < streamTypes.Length; i++)
			{
				_serializeMethods[i] = typeFromHandle.GetMethod("Write", new Type[1] { streamTypes[i] });
				if (_serializeMethods[i] == null)
				{
					throw new Exception("No write method for type '" + streamTypes[i].Name + "'.");
				}
				_deserializeMethods[i] = typeFromHandle.GetMethod("Read" + streamTypes[i].Name);
				if (_deserializeMethods[i] == null)
				{
					throw new Exception("No read method for type '" + streamTypes[i].Name + "'");
				}
			}
		}

		public static DynamicSerializer GenerateSerializer(Type objectType)
		{
			ModuleBuilder moduleBuilder = Thread.GetDomain().DefineDynamicAssembly(new AssemblyName
			{
				Name = "DynamicSerializer",
				Version = new Version(1, 0, 0, 0)
			}, AssemblyBuilderAccess.Run).DefineDynamicModule("DynamicSerializerModule");
			TypeAttributes attr = TypeAttributes.Public | TypeAttributes.Sealed;
			string name = "ser_" + objectType.Name;
			TypeBuilder typeBuilder = moduleBuilder.DefineType(name, attr, typeof(DynamicSerializer));
			Type[] parameterTypes = new Type[2]
			{
				typeof(object),
				typeof(AltSerializer)
			};
			Type[] parameterTypes2 = new Type[2]
			{
				typeof(AltSerializer),
				typeof(int)
			};
			GenerateSerializeMethod(typeBuilder.DefineMethod("Serialize", MethodAttributes.Public | MethodAttributes.Virtual, CallingConventions.HasThis, null, parameterTypes).GetILGenerator(), objectType);
			GenerateDeserializeMethod(typeBuilder.DefineMethod("Deserialize", MethodAttributes.Public | MethodAttributes.Virtual, CallingConventions.HasThis, typeof(object), parameterTypes2).GetILGenerator(), objectType);
			return (DynamicSerializer)Activator.CreateInstance(typeBuilder.CreateType());
		}

		private static void GenerateSerializeMethod(ILGenerator methodIL, Type objectType)
		{
			methodIL.DeclareLocal(objectType);
			methodIL.Emit(OpCodes.Ldarg_1);
			methodIL.Emit(OpCodes.Castclass, objectType);
			methodIL.Emit(OpCodes.Stloc_0);
			FieldInfo[] fields = objectType.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.GetCustomAttributes(typeof(DoNotSerializeAttribute), true).Length == 0 && !fieldInfo.IsNotSerialized)
				{
					MethodInfo method = typeof(Type).GetMethod("GetTypeFromHandle");
					MethodInfo method2 = typeof(AltSerializer).GetMethod("Serialize", new Type[2]
					{
						typeof(object),
						typeof(Type)
					});
					MethodInfo serializerMethod = GetSerializerMethod(fieldInfo.FieldType);
					if (serializerMethod != null)
					{
						methodIL.Emit(OpCodes.Ldarg_2);
						methodIL.Emit(OpCodes.Ldloc_0);
						methodIL.Emit(OpCodes.Ldfld, fieldInfo);
						methodIL.Emit(OpCodes.Callvirt, serializerMethod);
					}
					else if (fieldInfo.FieldType.IsValueType)
					{
						methodIL.Emit(OpCodes.Ldarg_2);
						methodIL.Emit(OpCodes.Ldloc_0);
						methodIL.Emit(OpCodes.Ldfld, fieldInfo);
						methodIL.Emit(OpCodes.Box, fieldInfo.FieldType);
						methodIL.Emit(OpCodes.Ldtoken, fieldInfo.FieldType);
						methodIL.Emit(OpCodes.Call, method);
						methodIL.Emit(OpCodes.Callvirt, method2);
					}
					else
					{
						methodIL.Emit(OpCodes.Ldarg_2);
						methodIL.Emit(OpCodes.Ldloc_0);
						methodIL.Emit(OpCodes.Ldfld, fieldInfo);
						methodIL.Emit(OpCodes.Ldtoken, fieldInfo.FieldType);
						methodIL.Emit(OpCodes.Call, method);
						methodIL.Emit(OpCodes.Callvirt, method2);
					}
				}
			}
			methodIL.Emit(OpCodes.Ret);
		}

		private static void GenerateDeserializeMethod(ILGenerator methodIL, Type objectType)
		{
			ConstructorInfo constructor = objectType.GetConstructor(new Type[0]);
			methodIL.DeclareLocal(objectType);
			methodIL.DeclareLocal(typeof(object));
			methodIL.Emit(OpCodes.Nop);
			methodIL.Emit(OpCodes.Newobj, constructor);
			methodIL.Emit(OpCodes.Stloc_0);
			Label label = methodIL.DefineLabel();
			methodIL.Emit(OpCodes.Ldarg_2);
			methodIL.Emit(OpCodes.Ldc_I4, 0);
			methodIL.Emit(OpCodes.Ceq);
			methodIL.Emit(OpCodes.Brtrue_S, label);
			methodIL.Emit(OpCodes.Ldarg_1);
			methodIL.Emit(OpCodes.Ldloc_0);
			methodIL.Emit(OpCodes.Ldarg_2);
			MethodInfo method = typeof(AltSerializer).GetMethod("SetCachedObjectID", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			methodIL.Emit(OpCodes.Callvirt, method);
			methodIL.MarkLabel(label);
			FieldInfo[] fields = objectType.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.GetCustomAttributes(typeof(DoNotSerializeAttribute), true).Length == 0 && !fieldInfo.IsNotSerialized)
				{
					MethodInfo method2 = typeof(Type).GetMethod("GetTypeFromHandle");
					MethodInfo method3 = typeof(AltSerializer).GetMethod("Deserialize", new Type[1] { typeof(Type) });
					MethodInfo deserializeMethod = GetDeserializeMethod(fieldInfo.FieldType);
					if (deserializeMethod != null)
					{
						methodIL.Emit(OpCodes.Ldloc_0);
						methodIL.Emit(OpCodes.Ldarg_1);
						methodIL.Emit(OpCodes.Callvirt, deserializeMethod);
						methodIL.Emit(OpCodes.Stfld, fieldInfo);
					}
					else if (fieldInfo.FieldType.IsValueType)
					{
						methodIL.Emit(OpCodes.Ldloc_0);
						methodIL.Emit(OpCodes.Ldarg_1);
						methodIL.Emit(OpCodes.Ldtoken, fieldInfo.FieldType);
						methodIL.Emit(OpCodes.Call, method2);
						methodIL.Emit(OpCodes.Callvirt, method3);
						methodIL.Emit(OpCodes.Unbox_Any, fieldInfo.FieldType);
						methodIL.Emit(OpCodes.Stfld, fieldInfo);
					}
					else
					{
						methodIL.Emit(OpCodes.Ldloc_0);
						methodIL.Emit(OpCodes.Ldarg_1);
						methodIL.Emit(OpCodes.Ldtoken, fieldInfo.FieldType);
						methodIL.Emit(OpCodes.Call, method2);
						methodIL.Emit(OpCodes.Callvirt, method3);
						methodIL.Emit(OpCodes.Castclass, fieldInfo.FieldType);
						methodIL.Emit(OpCodes.Stfld, fieldInfo);
					}
				}
			}
			methodIL.Emit(OpCodes.Ldloc_0);
			methodIL.Emit(OpCodes.Stloc_1);
			Label label2 = methodIL.DefineLabel();
			methodIL.Emit(OpCodes.Br_S, label2);
			methodIL.MarkLabel(label2);
			methodIL.Emit(OpCodes.Ldloc_1);
			methodIL.Emit(OpCodes.Ret);
		}
	}
}
