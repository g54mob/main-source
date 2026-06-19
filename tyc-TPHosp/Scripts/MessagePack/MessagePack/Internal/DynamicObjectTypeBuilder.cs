using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using System.Threading;
using MessagePack.Formatters;

namespace MessagePack.Internal
{
	internal static class DynamicObjectTypeBuilder
	{
		internal static class MessagePackBinaryTypeInfo
		{
			public static TypeInfo TypeInfo;

			public static readonly MethodInfo GetEncodedStringBytes;

			public static MethodInfo WriteFixedMapHeaderUnsafe;

			public static MethodInfo WriteFixedArrayHeaderUnsafe;

			public static MethodInfo WriteMapHeader;

			public static MethodInfo WriteArrayHeader;

			public static MethodInfo WritePositiveFixedIntUnsafe;

			public static MethodInfo WriteInt32;

			public static MethodInfo WriteBytes;

			public static MethodInfo WriteNil;

			public static MethodInfo ReadBytes;

			public static MethodInfo ReadInt32;

			public static MethodInfo ReadString;

			public static MethodInfo ReadStringSegment;

			public static MethodInfo IsNil;

			public static MethodInfo ReadNextBlock;

			public static MethodInfo WriteStringUnsafe;

			public static MethodInfo WriteStringBytes;

			public static MethodInfo WriteRaw;

			public static MethodInfo ReadArrayHeader;

			public static MethodInfo ReadMapHeader;

			static MessagePackBinaryTypeInfo()
			{
				TypeInfo = typeof(MessagePackBinary).GetTypeInfo();
				GetEncodedStringBytes = typeof(MessagePackBinary).GetRuntimeMethod("GetEncodedStringBytes", new Type[1] { typeof(string) });
				WriteFixedMapHeaderUnsafe = typeof(MessagePackBinary).GetRuntimeMethod("WriteFixedMapHeaderUnsafe", new Type[3]
				{
					refByte,
					typeof(int),
					typeof(int)
				});
				WriteFixedArrayHeaderUnsafe = typeof(MessagePackBinary).GetRuntimeMethod("WriteFixedArrayHeaderUnsafe", new Type[3]
				{
					refByte,
					typeof(int),
					typeof(int)
				});
				WriteMapHeader = typeof(MessagePackBinary).GetRuntimeMethod("WriteMapHeader", new Type[3]
				{
					refByte,
					typeof(int),
					typeof(int)
				});
				WriteArrayHeader = typeof(MessagePackBinary).GetRuntimeMethod("WriteArrayHeader", new Type[3]
				{
					refByte,
					typeof(int),
					typeof(int)
				});
				WritePositiveFixedIntUnsafe = typeof(MessagePackBinary).GetRuntimeMethod("WritePositiveFixedIntUnsafe", new Type[3]
				{
					refByte,
					typeof(int),
					typeof(int)
				});
				WriteInt32 = typeof(MessagePackBinary).GetRuntimeMethod("WriteInt32", new Type[3]
				{
					refByte,
					typeof(int),
					typeof(int)
				});
				WriteBytes = typeof(MessagePackBinary).GetRuntimeMethod("WriteBytes", new Type[3]
				{
					refByte,
					typeof(int),
					typeof(byte[])
				});
				WriteNil = typeof(MessagePackBinary).GetRuntimeMethod("WriteNil", new Type[2]
				{
					refByte,
					typeof(int)
				});
				ReadBytes = typeof(MessagePackBinary).GetRuntimeMethod("ReadBytes", new Type[3]
				{
					typeof(byte[]),
					typeof(int),
					refInt
				});
				ReadInt32 = typeof(MessagePackBinary).GetRuntimeMethod("ReadInt32", new Type[3]
				{
					typeof(byte[]),
					typeof(int),
					refInt
				});
				ReadString = typeof(MessagePackBinary).GetRuntimeMethod("ReadString", new Type[3]
				{
					typeof(byte[]),
					typeof(int),
					refInt
				});
				ReadStringSegment = typeof(MessagePackBinary).GetRuntimeMethod("ReadStringSegment", new Type[3]
				{
					typeof(byte[]),
					typeof(int),
					refInt
				});
				IsNil = typeof(MessagePackBinary).GetRuntimeMethod("IsNil", new Type[2]
				{
					typeof(byte[]),
					typeof(int)
				});
				ReadNextBlock = typeof(MessagePackBinary).GetRuntimeMethod("ReadNextBlock", new Type[2]
				{
					typeof(byte[]),
					typeof(int)
				});
				WriteStringUnsafe = typeof(MessagePackBinary).GetRuntimeMethod("WriteStringUnsafe", new Type[4]
				{
					refByte,
					typeof(int),
					typeof(string),
					typeof(int)
				});
				WriteStringBytes = typeof(MessagePackBinary).GetRuntimeMethod("WriteStringBytes", new Type[3]
				{
					refByte,
					typeof(int),
					typeof(byte[])
				});
				WriteRaw = typeof(MessagePackBinary).GetRuntimeMethod("WriteRaw", new Type[3]
				{
					refByte,
					typeof(int),
					typeof(byte[])
				});
				ReadArrayHeader = typeof(MessagePackBinary).GetRuntimeMethod("ReadArrayHeader", new Type[3]
				{
					typeof(byte[]),
					typeof(int),
					refInt
				});
				ReadMapHeader = typeof(MessagePackBinary).GetRuntimeMethod("ReadMapHeader", new Type[3]
				{
					typeof(byte[]),
					typeof(int),
					refInt
				});
			}
		}

		internal static class EmitInfo
		{
			internal static class MessagePackFormatterAttr
			{
				internal static readonly MethodInfo FormatterType = ExpressionUtility.GetPropertyInfo((MessagePackFormatterAttribute attr) => attr.FormatterType).GetGetMethod();

				internal static readonly MethodInfo Arguments = ExpressionUtility.GetPropertyInfo((MessagePackFormatterAttribute attr) => attr.Arguments).GetGetMethod();
			}

			public static readonly MethodInfo GetTypeFromHandle = ExpressionUtility.GetMethodInfo(() => Type.GetTypeFromHandle(default(RuntimeTypeHandle)));

			public static readonly MethodInfo TypeGetProperty = ExpressionUtility.GetMethodInfo((Type t) => t.GetTypeInfo().GetProperty(null, BindingFlags.Default));

			public static readonly MethodInfo TypeGetField = ExpressionUtility.GetMethodInfo((Type t) => t.GetTypeInfo().GetField(null, BindingFlags.Default));

			public static readonly MethodInfo GetCustomAttributeMessagePackFormatterAttribute = ExpressionUtility.GetMethodInfo(() => ((MemberInfo)null).GetCustomAttribute<MessagePackFormatterAttribute>(false));

			public static readonly MethodInfo ActivatorCreateInstance = ExpressionUtility.GetMethodInfo(() => Activator.CreateInstance((Type)null, (object[])null));
		}

		private class DeserializeInfo
		{
			public ObjectSerializationInfo.EmittableMember MemberInfo { get; set; }

			public LocalBuilder LocalField { get; set; }

			public Label SwitchLabel { get; set; }
		}

		private static readonly Regex SubtractFullNameRegex = new Regex(", Version=\\d+.\\d+.\\d+.\\d+, Culture=\\w+, PublicKeyToken=\\w+");

		private static int nameSequence = 0;

		private static HashSet<Type> ignoreTypes = new HashSet<Type>
		{
			typeof(object),
			typeof(short),
			typeof(int),
			typeof(long),
			typeof(ushort),
			typeof(uint),
			typeof(ulong),
			typeof(float),
			typeof(double),
			typeof(bool),
			typeof(byte),
			typeof(sbyte),
			typeof(decimal),
			typeof(char),
			typeof(string),
			typeof(Guid),
			typeof(TimeSpan),
			typeof(DateTime),
			typeof(DateTimeOffset),
			typeof(Nil)
		};

		private static readonly Type refByte = typeof(byte[]).MakeByRefType();

		private static readonly Type refInt = typeof(int).MakeByRefType();

		private static readonly MethodInfo getFormatterWithVerify = typeof(FormatterResolverExtensions).GetRuntimeMethods().First((MethodInfo x) => x.Name == "GetFormatterWithVerify");

		private static readonly Func<Type, MethodInfo> getSerialize = (Type t) => typeof(IMessagePackFormatter<>).MakeGenericType(t).GetRuntimeMethod("Serialize", new Type[4]
		{
			refByte,
			typeof(int),
			t,
			typeof(IFormatterResolver)
		});

		private static readonly Func<Type, MethodInfo> getDeserialize = (Type t) => typeof(IMessagePackFormatter<>).MakeGenericType(t).GetRuntimeMethod("Deserialize", new Type[4]
		{
			typeof(byte[]),
			typeof(int),
			typeof(IFormatterResolver),
			refInt
		});

		private static readonly ConstructorInfo invalidOperationExceptionConstructor = typeof(InvalidOperationException).GetTypeInfo().DeclaredConstructors.First(delegate(ConstructorInfo x)
		{
			ParameterInfo[] parameters = x.GetParameters();
			return parameters.Length == 1 && parameters[0].ParameterType == typeof(string);
		});

		private static readonly MethodInfo onBeforeSerialize = typeof(IMessagePackSerializationCallbackReceiver).GetRuntimeMethod("OnBeforeSerialize", Type.EmptyTypes);

		private static readonly MethodInfo onAfterDeserialize = typeof(IMessagePackSerializationCallbackReceiver).GetRuntimeMethod("OnAfterDeserialize", Type.EmptyTypes);

		private static readonly ConstructorInfo objectCtor = typeof(object).GetTypeInfo().DeclaredConstructors.First((ConstructorInfo x) => x.GetParameters().Length == 0);

		public static TypeInfo BuildType(DynamicAssembly assembly, Type type, bool forceStringKey, bool contractless)
		{
			if (ignoreTypes.Contains(type))
			{
				return null;
			}
			ObjectSerializationInfo objectSerializationInfo = ObjectSerializationInfo.CreateOrNull(type, forceStringKey, contractless, allowPrivate: false);
			if (objectSerializationInfo == null)
			{
				return null;
			}
			Type type2 = typeof(IMessagePackFormatter<>).MakeGenericType(type);
			TypeBuilder typeBuilder = assembly.DefineType("MessagePack.Formatters." + SubtractFullNameRegex.Replace(type.FullName, "").Replace(".", "_") + "Formatter" + Interlocked.Increment(ref nameSequence), TypeAttributes.Public | TypeAttributes.Sealed, null, new Type[1] { type2 });
			FieldBuilder stringByteKeysField = null;
			Dictionary<ObjectSerializationInfo.EmittableMember, FieldInfo> customFormatterLookup = null;
			if (objectSerializationInfo.IsStringKey)
			{
				ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes);
				stringByteKeysField = typeBuilder.DefineField("stringByteKeys", typeof(byte[][]), FieldAttributes.Private | FieldAttributes.InitOnly);
				ILGenerator iLGenerator = constructorBuilder.GetILGenerator();
				BuildConstructor(type, objectSerializationInfo, constructorBuilder, stringByteKeysField, iLGenerator);
				customFormatterLookup = BuildCustomFormatterField(typeBuilder, objectSerializationInfo, iLGenerator);
				iLGenerator.Emit(OpCodes.Ret);
			}
			else
			{
				ILGenerator iLGenerator2 = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, Type.EmptyTypes).GetILGenerator();
				iLGenerator2.EmitLoadThis();
				iLGenerator2.Emit(OpCodes.Call, objectCtor);
				customFormatterLookup = BuildCustomFormatterField(typeBuilder, objectSerializationInfo, iLGenerator2);
				iLGenerator2.Emit(OpCodes.Ret);
			}
			MethodBuilder methodBuilder = typeBuilder.DefineMethod("Serialize", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual, typeof(int), new Type[4]
			{
				typeof(byte[]).MakeByRefType(),
				typeof(int),
				type,
				typeof(IFormatterResolver)
			});
			ILGenerator il = methodBuilder.GetILGenerator();
			BuildSerialize(type, objectSerializationInfo, il, delegate
			{
				il.EmitLoadThis();
				il.EmitLdfld(stringByteKeysField);
			}, (int index, ObjectSerializationInfo.EmittableMember member) => (!customFormatterLookup.TryGetValue(member, out var fi)) ? null : ((Action)delegate
			{
				il.EmitLoadThis();
				il.EmitLdfld(fi);
			}), 1);
			MethodBuilder methodBuilder2 = typeBuilder.DefineMethod("Deserialize", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual, type, new Type[4]
			{
				typeof(byte[]),
				typeof(int),
				typeof(IFormatterResolver),
				typeof(int).MakeByRefType()
			});
			ILGenerator il2 = methodBuilder2.GetILGenerator();
			BuildDeserialize(type, objectSerializationInfo, il2, (int index, ObjectSerializationInfo.EmittableMember member) => (!customFormatterLookup.TryGetValue(member, out var fi)) ? null : ((Action)delegate
			{
				il2.EmitLoadThis();
				il2.EmitLdfld(fi);
			}), 1);
			return typeBuilder.CreateTypeInfo();
		}

		public static object BuildFormatterToDynamicMethod(Type type, bool forceStringKey, bool contractless, bool allowPrivate)
		{
			ObjectSerializationInfo objectSerializationInfo = ObjectSerializationInfo.CreateOrNull(type, forceStringKey, contractless, allowPrivate);
			if (objectSerializationInfo == null)
			{
				return null;
			}
			DynamicMethod dynamicMethod = new DynamicMethod("Serialize", typeof(int), new Type[6]
			{
				typeof(byte[][]),
				typeof(object[]),
				typeof(byte[]).MakeByRefType(),
				typeof(int),
				type,
				typeof(IFormatterResolver)
			}, type, skipVisibility: true);
			DynamicMethod dynamicMethod2 = null;
			List<byte[]> list = new List<byte[]>();
			List<object> serializeCustomFormatters = new List<object>();
			List<object> deserializeCustomFormatters = new List<object>();
			if (objectSerializationInfo.IsStringKey)
			{
				int num = 0;
				foreach (ObjectSerializationInfo.EmittableMember item3 in objectSerializationInfo.Members.Where((ObjectSerializationInfo.EmittableMember x) => x.IsReadable))
				{
					list.Add(MessagePackBinary.GetEncodedStringBytes(item3.StringKey));
					num++;
				}
			}
			foreach (ObjectSerializationInfo.EmittableMember item4 in objectSerializationInfo.Members.Where((ObjectSerializationInfo.EmittableMember x) => x.IsReadable))
			{
				MessagePackFormatterAttribute messagePackFormatterAttribtue = item4.GetMessagePackFormatterAttribtue();
				if (messagePackFormatterAttribtue != null)
				{
					object item = Activator.CreateInstance(messagePackFormatterAttribtue.FormatterType, messagePackFormatterAttribtue.Arguments);
					serializeCustomFormatters.Add(item);
				}
				else
				{
					serializeCustomFormatters.Add(null);
				}
			}
			ObjectSerializationInfo.EmittableMember[] members = objectSerializationInfo.Members;
			for (int num2 = 0; num2 < members.Length; num2++)
			{
				MessagePackFormatterAttribute messagePackFormatterAttribtue2 = members[num2].GetMessagePackFormatterAttribtue();
				if (messagePackFormatterAttribtue2 != null)
				{
					object item2 = Activator.CreateInstance(messagePackFormatterAttribtue2.FormatterType, messagePackFormatterAttribtue2.Arguments);
					deserializeCustomFormatters.Add(item2);
				}
				else
				{
					deserializeCustomFormatters.Add(null);
				}
			}
			ILGenerator il = dynamicMethod.GetILGenerator();
			BuildSerialize(type, objectSerializationInfo, il, delegate
			{
				il.EmitLdarg(0);
			}, delegate(int index, ObjectSerializationInfo.EmittableMember member)
			{
				if (serializeCustomFormatters.Count == 0)
				{
					return (Action)null;
				}
				return (serializeCustomFormatters[index] == null) ? null : ((Action)delegate
				{
					il.EmitLdarg(1);
					il.EmitLdc_I4(index);
					il.Emit(OpCodes.Ldelem_Ref);
					il.Emit(OpCodes.Castclass, serializeCustomFormatters[index].GetType());
				});
			}, 2);
			if (objectSerializationInfo.IsStruct || objectSerializationInfo.BestmatchConstructor != null)
			{
				dynamicMethod2 = new DynamicMethod("Deserialize", type, new Type[5]
				{
					typeof(object[]),
					typeof(byte[]),
					typeof(int),
					typeof(IFormatterResolver),
					typeof(int).MakeByRefType()
				}, type, skipVisibility: true);
				ILGenerator il2 = dynamicMethod2.GetILGenerator();
				BuildDeserialize(type, objectSerializationInfo, il2, delegate(int index, ObjectSerializationInfo.EmittableMember member)
				{
					if (deserializeCustomFormatters.Count == 0)
					{
						return (Action)null;
					}
					return (deserializeCustomFormatters[index] == null) ? null : ((Action)delegate
					{
						il2.EmitLdarg(0);
						il2.EmitLdc_I4(index);
						il2.Emit(OpCodes.Ldelem_Ref);
						il2.Emit(OpCodes.Castclass, deserializeCustomFormatters[index].GetType());
					});
				}, 1);
			}
			object obj = dynamicMethod.CreateDelegate(typeof(AnonymousSerializeFunc<>).MakeGenericType(type));
			object obj2 = ((dynamicMethod2 == null) ? null : dynamicMethod2.CreateDelegate(typeof(AnonymousDeserializeFunc<>).MakeGenericType(type)));
			return Activator.CreateInstance(typeof(AnonymousSerializableFormatter<>).MakeGenericType(type), list.ToArray(), serializeCustomFormatters.ToArray(), deserializeCustomFormatters.ToArray(), obj, obj2);
		}

		private static void BuildConstructor(Type type, ObjectSerializationInfo info, ConstructorInfo method, FieldBuilder stringByteKeysField, ILGenerator il)
		{
			il.EmitLoadThis();
			il.Emit(OpCodes.Call, objectCtor);
			int value = info.Members.Count((ObjectSerializationInfo.EmittableMember x) => x.IsReadable);
			il.EmitLoadThis();
			il.EmitLdc_I4(value);
			il.Emit(OpCodes.Newarr, typeof(byte[]));
			int num = 0;
			foreach (ObjectSerializationInfo.EmittableMember item in info.Members.Where((ObjectSerializationInfo.EmittableMember x) => x.IsReadable))
			{
				il.Emit(OpCodes.Dup);
				il.EmitLdc_I4(num);
				il.Emit(OpCodes.Ldstr, item.StringKey);
				il.EmitCall(MessagePackBinaryTypeInfo.GetEncodedStringBytes);
				il.Emit(OpCodes.Stelem_Ref);
				num++;
			}
			il.Emit(OpCodes.Stfld, stringByteKeysField);
		}

		private static Dictionary<ObjectSerializationInfo.EmittableMember, FieldInfo> BuildCustomFormatterField(TypeBuilder builder, ObjectSerializationInfo info, ILGenerator il)
		{
			Dictionary<ObjectSerializationInfo.EmittableMember, FieldInfo> dictionary = new Dictionary<ObjectSerializationInfo.EmittableMember, FieldInfo>();
			foreach (ObjectSerializationInfo.EmittableMember item in info.Members.Where((ObjectSerializationInfo.EmittableMember x) => x.IsReadable || x.IsWritable))
			{
				MessagePackFormatterAttribute messagePackFormatterAttribtue = item.GetMessagePackFormatterAttribtue();
				if (messagePackFormatterAttribtue != null)
				{
					FieldBuilder fieldBuilder = builder.DefineField(item.Name + "_formatter", messagePackFormatterAttribtue.FormatterType, FieldAttributes.Private | FieldAttributes.InitOnly);
					int value = 52;
					LocalBuilder local = il.DeclareLocal(typeof(MessagePackFormatterAttribute));
					il.Emit(OpCodes.Ldtoken, info.Type);
					il.EmitCall(EmitInfo.GetTypeFromHandle);
					il.Emit(OpCodes.Ldstr, item.Name);
					il.EmitLdc_I4(value);
					if (item.IsProperty)
					{
						il.EmitCall(EmitInfo.TypeGetProperty);
					}
					else
					{
						il.EmitCall(EmitInfo.TypeGetField);
					}
					il.EmitTrue();
					il.EmitCall(EmitInfo.GetCustomAttributeMessagePackFormatterAttribute);
					il.EmitStloc(local);
					il.EmitLoadThis();
					il.EmitLdloc(local);
					il.EmitCall(EmitInfo.MessagePackFormatterAttr.FormatterType);
					il.EmitLdloc(local);
					il.EmitCall(EmitInfo.MessagePackFormatterAttr.Arguments);
					il.EmitCall(EmitInfo.ActivatorCreateInstance);
					il.Emit(OpCodes.Castclass, messagePackFormatterAttribtue.FormatterType);
					il.Emit(OpCodes.Stfld, fieldBuilder);
					dictionary.Add(item, fieldBuilder);
				}
			}
			return dictionary;
		}

		private static void BuildSerialize(Type type, ObjectSerializationInfo info, ILGenerator il, Action emitStringByteKeys, Func<int, ObjectSerializationInfo.EmittableMember, Action> tryEmitLoadCustomFormatter, int firstArgIndex)
		{
			ArgumentField argBytes = new ArgumentField(il, firstArgIndex);
			ArgumentField argOffset = new ArgumentField(il, firstArgIndex + 1);
			ArgumentField argValue = new ArgumentField(il, firstArgIndex + 2, type);
			ArgumentField argResolver = new ArgumentField(il, firstArgIndex + 3);
			if (type.GetTypeInfo().IsClass)
			{
				Label label = il.DefineLabel();
				argValue.EmitLoad();
				il.Emit(OpCodes.Brtrue_S, label);
				argBytes.EmitLoad();
				argOffset.EmitLoad();
				il.EmitCall(MessagePackBinaryTypeInfo.WriteNil);
				il.Emit(OpCodes.Ret);
				il.MarkLabel(label);
			}
			if (type.GetTypeInfo().ImplementedInterfaces.Any((Type x) => x == typeof(IMessagePackSerializationCallbackReceiver)))
			{
				MethodInfo[] array = (from x in type.GetRuntimeMethods()
					where x.Name == "OnBeforeSerialize"
					select x).ToArray();
				if (array.Length == 1)
				{
					argValue.EmitLoad();
					il.Emit(OpCodes.Call, array[0]);
				}
				else
				{
					argValue.EmitLdarg();
					il.EmitBoxOrDoNothing(type);
					il.EmitCall(onBeforeSerialize);
				}
			}
			LocalBuilder local = il.DeclareLocal(typeof(int));
			argOffset.EmitLoad();
			il.EmitStloc(local);
			if (info.IsIntKey)
			{
				int maxKey = (from x in info.Members
					where x.IsReadable
					select x.IntKey).DefaultIfEmpty(-1).Max();
				Dictionary<int, ObjectSerializationInfo.EmittableMember> dictionary = info.Members.Where((ObjectSerializationInfo.EmittableMember x) => x.IsReadable).ToDictionary((ObjectSerializationInfo.EmittableMember x) => x.IntKey);
				EmitOffsetPlusEqual(il, null, delegate
				{
					int num2 = maxKey + 1;
					il.EmitLdc_I4(num2);
					if (num2 <= 15)
					{
						il.EmitCall(MessagePackBinaryTypeInfo.WriteFixedArrayHeaderUnsafe);
					}
					else
					{
						il.EmitCall(MessagePackBinaryTypeInfo.WriteArrayHeader);
					}
				}, argBytes, argOffset);
				for (int num = 0; num <= maxKey; num++)
				{
					if (dictionary.TryGetValue(num, out var value))
					{
						EmitSerializeValue(il, type.GetTypeInfo(), value, num, tryEmitLoadCustomFormatter, argBytes, argOffset, argValue, argResolver);
						continue;
					}
					EmitOffsetPlusEqual(il, null, delegate
					{
						il.EmitCall(MessagePackBinaryTypeInfo.WriteNil);
					}, argBytes, argOffset);
				}
			}
			else
			{
				int writeCount = info.Members.Count((ObjectSerializationInfo.EmittableMember x) => x.IsReadable);
				EmitOffsetPlusEqual(il, null, delegate
				{
					il.EmitLdc_I4(writeCount);
					if (writeCount <= 15)
					{
						il.EmitCall(MessagePackBinaryTypeInfo.WriteFixedMapHeaderUnsafe);
					}
					else
					{
						il.EmitCall(MessagePackBinaryTypeInfo.WriteMapHeader);
					}
				}, argBytes, argOffset);
				int index = 0;
				foreach (ObjectSerializationInfo.EmittableMember item in info.Members.Where((ObjectSerializationInfo.EmittableMember x) => x.IsReadable))
				{
					EmitOffsetPlusEqual(il, null, delegate
					{
						emitStringByteKeys();
						il.EmitLdc_I4(index);
						il.Emit(OpCodes.Ldelem_Ref);
						il.EmitCall(MessagePackBinaryTypeInfo.WriteRaw);
					}, argBytes, argOffset);
					EmitSerializeValue(il, type.GetTypeInfo(), item, index, tryEmitLoadCustomFormatter, argBytes, argOffset, argValue, argResolver);
					index++;
				}
			}
			argOffset.EmitLoad();
			il.EmitLdloc(local);
			il.Emit(OpCodes.Sub);
			il.Emit(OpCodes.Ret);
		}

		private static void EmitOffsetPlusEqual(ILGenerator il, Action loadEmit, Action emit, ArgumentField argBytes, ArgumentField argOffset)
		{
			argOffset.EmitLoad();
			loadEmit?.Invoke();
			argBytes.EmitLoad();
			argOffset.EmitLoad();
			emit();
			il.Emit(OpCodes.Add);
			argOffset.EmitStore();
		}

		private static void EmitSerializeValue(ILGenerator il, TypeInfo type, ObjectSerializationInfo.EmittableMember member, int index, Func<int, ObjectSerializationInfo.EmittableMember, Action> tryEmitLoadCustomFormatter, ArgumentField argBytes, ArgumentField argOffset, ArgumentField argValue, ArgumentField argResolver)
		{
			Type t = member.Type;
			Action emitter = tryEmitLoadCustomFormatter(index, member);
			if (emitter != null)
			{
				EmitOffsetPlusEqual(il, delegate
				{
					emitter();
				}, delegate
				{
					argValue.EmitLoad();
					member.EmitLoadValue(il);
					argResolver.EmitLoad();
					il.EmitCall(typeof(IMessagePackFormatter<>).MakeGenericType(t).GetRuntimeMethod("Serialize", new Type[4]
					{
						refByte,
						typeof(int),
						t,
						typeof(IFormatterResolver)
					}));
				}, argBytes, argOffset);
			}
			else if (IsOptimizeTargetType(t))
			{
				EmitOffsetPlusEqual(il, null, delegate
				{
					argValue.EmitLoad();
					member.EmitLoadValue(il);
					if (t == typeof(byte[]))
					{
						il.EmitCall(MessagePackBinaryTypeInfo.WriteBytes);
					}
					else
					{
						il.EmitCall((from x in MessagePackBinaryTypeInfo.TypeInfo.GetDeclaredMethods("Write" + t.Name)
							orderby x.GetParameters().Length descending
							select x).First());
					}
				}, argBytes, argOffset);
			}
			else
			{
				EmitOffsetPlusEqual(il, delegate
				{
					argResolver.EmitLoad();
					il.Emit(OpCodes.Call, getFormatterWithVerify.MakeGenericMethod(t));
				}, delegate
				{
					argValue.EmitLoad();
					member.EmitLoadValue(il);
					argResolver.EmitLoad();
					il.EmitCall(getSerialize(t));
				}, argBytes, argOffset);
			}
		}

		private unsafe static void BuildDeserialize(Type type, ObjectSerializationInfo info, ILGenerator il, Func<int, ObjectSerializationInfo.EmittableMember, Action> tryEmitLoadCustomFormatter, int firstArgIndex)
		{
			ArgumentField argBytes = new ArgumentField(il, firstArgIndex);
			ArgumentField argOffset = new ArgumentField(il, firstArgIndex + 1);
			ArgumentField argResolver = new ArgumentField(il, firstArgIndex + 2);
			ArgumentField argReadSize = new ArgumentField(il, firstArgIndex + 3);
			Label label = il.DefineLabel();
			argBytes.EmitLoad();
			argOffset.EmitLoad();
			il.EmitCall(MessagePackBinaryTypeInfo.IsNil);
			il.Emit(OpCodes.Brfalse_S, label);
			if (type.GetTypeInfo().IsClass)
			{
				argReadSize.EmitLoad();
				il.EmitLdc_I4(1);
				il.Emit(OpCodes.Stind_I4);
				il.Emit(OpCodes.Ldnull);
				il.Emit(OpCodes.Ret);
			}
			else
			{
				il.Emit(OpCodes.Ldstr, "typecode is null, struct not supported");
				il.Emit(OpCodes.Newobj, invalidOperationExceptionConstructor);
				il.Emit(OpCodes.Throw);
			}
			il.MarkLabel(label);
			LocalBuilder local = il.DeclareLocal(typeof(int));
			argOffset.EmitLoad();
			il.EmitStloc(local);
			LocalBuilder localBuilder = il.DeclareLocal(typeof(int));
			argBytes.EmitLoad();
			argOffset.EmitLoad();
			argReadSize.EmitLoad();
			if (info.IsIntKey)
			{
				il.EmitCall(MessagePackBinaryTypeInfo.ReadArrayHeader);
			}
			else
			{
				il.EmitCall(MessagePackBinaryTypeInfo.ReadMapHeader);
			}
			il.EmitStloc(localBuilder);
			EmitOffsetPlusReadSize(il, argOffset, argReadSize);
			Label? gotoDefault = null;
			DeserializeInfo[] infoList;
			if (info.IsIntKey)
			{
				int count = info.Members.Select((ObjectSerializationInfo.EmittableMember x) => x.IntKey).DefaultIfEmpty(-1).Max() + 1;
				Dictionary<int, ObjectSerializationInfo.EmittableMember> intKeyMap = info.Members.ToDictionary((ObjectSerializationInfo.EmittableMember x) => x.IntKey);
				infoList = Enumerable.Range(0, count).Select(delegate(int x)
				{
					if (intKeyMap.TryGetValue(x, out var value))
					{
						return new DeserializeInfo
						{
							MemberInfo = value,
							LocalField = il.DeclareLocal(value.Type),
							SwitchLabel = il.DefineLabel()
						};
					}
					if (!gotoDefault.HasValue)
					{
						gotoDefault = il.DefineLabel();
					}
					return new DeserializeInfo
					{
						MemberInfo = null,
						LocalField = null,
						SwitchLabel = gotoDefault.Value
					};
				}).ToArray();
			}
			else
			{
				infoList = info.Members.Select((ObjectSerializationInfo.EmittableMember item) => new DeserializeInfo
				{
					MemberInfo = item,
					LocalField = il.DeclareLocal(item.Type)
				}).ToArray();
			}
			if (info.IsStringKey)
			{
				AutomataDictionary automata = new AutomataDictionary();
				for (int num = 0; num < info.Members.Length; num++)
				{
					automata.Add(info.Members[num].StringKey, num);
				}
				LocalBuilder buffer = il.DeclareLocal(typeof(byte).MakeByRefType(), pinned: true);
				LocalBuilder keyArraySegment = il.DeclareLocal(typeof(ArraySegment<byte>));
				LocalBuilder longKey = il.DeclareLocal(typeof(ulong));
				LocalBuilder p = il.DeclareLocal(typeof(byte*));
				LocalBuilder rest = il.DeclareLocal(typeof(int));
				argBytes.EmitLoad();
				il.EmitLdc_I4(0);
				il.Emit(OpCodes.Ldelema, typeof(byte));
				il.EmitStloc(buffer);
				il.EmitIncrementFor(localBuilder, delegate
				{
					Label readNext = il.DefineLabel();
					Label loopEnd = il.DefineLabel();
					argBytes.EmitLoad();
					argOffset.EmitLoad();
					argReadSize.EmitLoad();
					il.EmitCall(MessagePackBinaryTypeInfo.ReadStringSegment);
					il.EmitStloc(keyArraySegment);
					EmitOffsetPlusReadSize(il, argOffset, argReadSize);
					il.EmitLdloc(buffer);
					il.Emit(OpCodes.Conv_I);
					il.EmitLdloca(keyArraySegment);
					il.EmitCall(typeof(ArraySegment<byte>).GetRuntimeProperty("Offset").GetGetMethod());
					il.Emit(OpCodes.Add);
					il.EmitStloc(p);
					il.EmitLdloca(keyArraySegment);
					il.EmitCall(typeof(ArraySegment<byte>).GetRuntimeProperty("Count").GetGetMethod());
					il.EmitStloc(rest);
					il.EmitLdloc(rest);
					il.Emit(OpCodes.Brfalse, readNext);
					automata.EmitMatch(il, p, rest, longKey, delegate(KeyValuePair<string, int> x)
					{
						int value = x.Value;
						if (infoList[value].MemberInfo != null)
						{
							EmitDeserializeValue(il, infoList[value], value, tryEmitLoadCustomFormatter, argBytes, argOffset, argResolver, argReadSize);
							il.Emit(OpCodes.Br, loopEnd);
						}
						else
						{
							il.Emit(OpCodes.Br, readNext);
						}
					}, delegate
					{
						il.Emit(OpCodes.Br, readNext);
					});
					il.MarkLabel(readNext);
					argReadSize.EmitLoad();
					argBytes.EmitLoad();
					argOffset.EmitLoad();
					il.EmitCall(MessagePackBinaryTypeInfo.ReadNextBlock);
					il.Emit(OpCodes.Stind_I4);
					il.MarkLabel(loopEnd);
					EmitOffsetPlusReadSize(il, argOffset, argReadSize);
				});
				il.Emit(OpCodes.Ldc_I4_0);
				il.Emit(OpCodes.Conv_U);
				il.EmitStloc(buffer);
			}
			else
			{
				LocalBuilder key = il.DeclareLocal(typeof(int));
				Label switchDefault = il.DefineLabel();
				il.EmitIncrementFor(localBuilder, delegate(LocalBuilder forILocal)
				{
					Label label2 = il.DefineLabel();
					il.EmitLdloc(forILocal);
					il.EmitStloc(key);
					il.EmitLdloc(key);
					il.Emit(OpCodes.Switch, infoList.Select((DeserializeInfo x) => x.SwitchLabel).ToArray());
					il.MarkLabel(switchDefault);
					argReadSize.EmitLoad();
					argBytes.EmitLoad();
					argOffset.EmitLoad();
					il.EmitCall(MessagePackBinaryTypeInfo.ReadNextBlock);
					il.Emit(OpCodes.Stind_I4);
					il.Emit(OpCodes.Br, label2);
					if (gotoDefault.HasValue)
					{
						il.MarkLabel(gotoDefault.Value);
						il.Emit(OpCodes.Br, switchDefault);
					}
					int num2 = 0;
					DeserializeInfo[] array2 = infoList;
					foreach (DeserializeInfo deserializeInfo in array2)
					{
						if (deserializeInfo.MemberInfo != null)
						{
							il.MarkLabel(deserializeInfo.SwitchLabel);
							EmitDeserializeValue(il, deserializeInfo, num2++, tryEmitLoadCustomFormatter, argBytes, argOffset, argResolver, argReadSize);
							il.Emit(OpCodes.Br, label2);
						}
					}
					il.MarkLabel(label2);
					EmitOffsetPlusReadSize(il, argOffset, argReadSize);
				});
			}
			argReadSize.EmitLoad();
			argOffset.EmitLoad();
			il.EmitLdloc(local);
			il.Emit(OpCodes.Sub);
			il.Emit(OpCodes.Stind_I4);
			LocalBuilder local2 = EmitNewObject(il, type, info, infoList);
			if (type.GetTypeInfo().ImplementedInterfaces.Any((Type x) => x == typeof(IMessagePackSerializationCallbackReceiver)))
			{
				MethodInfo[] array = (from x in type.GetRuntimeMethods()
					where x.Name == "OnAfterDeserialize"
					select x).ToArray();
				if (array.Length == 1)
				{
					if (info.IsClass)
					{
						il.Emit(OpCodes.Dup);
					}
					else
					{
						il.EmitLdloca(local2);
					}
					il.Emit(OpCodes.Call, array[0]);
				}
				else
				{
					if (info.IsStruct)
					{
						il.EmitLdloc(local2);
						il.Emit(OpCodes.Box, type);
					}
					else
					{
						il.Emit(OpCodes.Dup);
					}
					il.EmitCall(onAfterDeserialize);
				}
			}
			if (info.IsStruct)
			{
				il.Emit(OpCodes.Ldloc, local2);
			}
			il.Emit(OpCodes.Ret);
		}

		private static void EmitOffsetPlusReadSize(ILGenerator il, ArgumentField argOffset, ArgumentField argReadSize)
		{
			argOffset.EmitLoad();
			argReadSize.EmitLoad();
			il.Emit(OpCodes.Ldind_I4);
			il.Emit(OpCodes.Add);
			argOffset.EmitStore();
		}

		private static void EmitDeserializeValue(ILGenerator il, DeserializeInfo info, int index, Func<int, ObjectSerializationInfo.EmittableMember, Action> tryEmitLoadCustomFormatter, ArgumentField argBytes, ArgumentField argOffset, ArgumentField argResolver, ArgumentField argReadSize)
		{
			ObjectSerializationInfo.EmittableMember memberInfo = info.MemberInfo;
			Type type = memberInfo.Type;
			Action action = tryEmitLoadCustomFormatter(index, memberInfo);
			if (action != null)
			{
				action();
				argBytes.EmitLoad();
				argOffset.EmitLoad();
				argResolver.EmitLoad();
				argReadSize.EmitLoad();
				il.EmitCall(typeof(IMessagePackFormatter<>).MakeGenericType(type).GetRuntimeMethod("Deserialize", new Type[4]
				{
					typeof(byte[]),
					typeof(int),
					typeof(IFormatterResolver),
					refInt
				}));
			}
			else if (IsOptimizeTargetType(type))
			{
				il.EmitLdarg(1);
				il.EmitLdarg(2);
				il.EmitLdarg(4);
				if (type == typeof(byte[]))
				{
					il.EmitCall(MessagePackBinaryTypeInfo.ReadBytes);
				}
				else
				{
					il.EmitCall((from x in MessagePackBinaryTypeInfo.TypeInfo.GetDeclaredMethods("Read" + type.Name)
						orderby x.GetParameters().Length descending
						select x).First());
				}
			}
			else
			{
				argResolver.EmitLoad();
				il.EmitCall(getFormatterWithVerify.MakeGenericMethod(type));
				argBytes.EmitLoad();
				argOffset.EmitLoad();
				argResolver.EmitLoad();
				argReadSize.EmitLoad();
				il.EmitCall(getDeserialize(type));
			}
			il.EmitStloc(info.LocalField);
		}

		private static LocalBuilder EmitNewObject(ILGenerator il, Type type, ObjectSerializationInfo info, DeserializeInfo[] members)
		{
			if (info.IsClass)
			{
				ObjectSerializationInfo.EmittableMember[] constructorParameters = info.ConstructorParameters;
				foreach (ObjectSerializationInfo.EmittableMember item in constructorParameters)
				{
					DeserializeInfo deserializeInfo = members.First((DeserializeInfo x) => x.MemberInfo == item);
					il.EmitLdloc(deserializeInfo.LocalField);
				}
				il.Emit(OpCodes.Newobj, info.BestmatchConstructor);
				foreach (DeserializeInfo item3 in members.Where((DeserializeInfo x) => x.MemberInfo != null && x.MemberInfo.IsWritable))
				{
					il.Emit(OpCodes.Dup);
					il.EmitLdloc(item3.LocalField);
					item3.MemberInfo.EmitStoreValue(il);
				}
				return null;
			}
			LocalBuilder localBuilder = il.DeclareLocal(type);
			if (info.BestmatchConstructor == null)
			{
				il.Emit(OpCodes.Ldloca, localBuilder);
				il.Emit(OpCodes.Initobj, type);
			}
			else
			{
				ObjectSerializationInfo.EmittableMember[] constructorParameters = info.ConstructorParameters;
				foreach (ObjectSerializationInfo.EmittableMember item2 in constructorParameters)
				{
					DeserializeInfo deserializeInfo2 = members.First((DeserializeInfo x) => x.MemberInfo == item2);
					il.EmitLdloc(deserializeInfo2.LocalField);
				}
				il.Emit(OpCodes.Newobj, info.BestmatchConstructor);
				il.Emit(OpCodes.Stloc, localBuilder);
			}
			foreach (DeserializeInfo item4 in members.Where((DeserializeInfo x) => x.MemberInfo != null && x.MemberInfo.IsWritable))
			{
				il.EmitLdloca(localBuilder);
				il.EmitLdloc(item4.LocalField);
				item4.MemberInfo.EmitStoreValue(il);
			}
			return localBuilder;
		}

		private static bool IsOptimizeTargetType(Type type)
		{
			if (type == typeof(short) || type == typeof(int) || type == typeof(long) || type == typeof(ushort) || type == typeof(uint) || type == typeof(ulong) || type == typeof(float) || type == typeof(double) || type == typeof(bool) || type == typeof(byte) || type == typeof(sbyte) || type == typeof(char))
			{
				return true;
			}
			return false;
		}
	}
}
