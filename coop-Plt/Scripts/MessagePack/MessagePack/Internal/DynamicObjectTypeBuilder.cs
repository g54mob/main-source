using System;
using System.Buffers;
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
		internal static class MessagePackWriterTypeInfo
		{
			internal static readonly TypeInfo TypeInfo = typeof(MessagePackWriter).GetTypeInfo();

			internal static readonly MethodInfo WriteMapHeader = typeof(MessagePackWriter).GetRuntimeMethod("WriteMapHeader", new Type[1] { typeof(int) });

			internal static readonly MethodInfo WriteArrayHeader = typeof(MessagePackWriter).GetRuntimeMethod("WriteArrayHeader", new Type[1] { typeof(int) });

			internal static readonly MethodInfo WriteBytes = typeof(MessagePackWriter).GetRuntimeMethod("Write", new Type[1] { typeof(ReadOnlySpan<byte>) });

			internal static readonly MethodInfo WriteNil = typeof(MessagePackWriter).GetRuntimeMethod("WriteNil", Type.EmptyTypes);

			internal static readonly MethodInfo WriteRaw = typeof(MessagePackWriter).GetRuntimeMethod("WriteRaw", new Type[1] { typeof(ReadOnlySpan<byte>) });
		}

		internal static class MessagePackReaderTypeInfo
		{
			internal static readonly TypeInfo TypeInfo = typeof(MessagePackReader).GetTypeInfo();

			internal static readonly MethodInfo ReadArrayHeader = typeof(MessagePackReader).GetRuntimeMethod("ReadArrayHeader", Type.EmptyTypes);

			internal static readonly MethodInfo ReadMapHeader = typeof(MessagePackReader).GetRuntimeMethod("ReadMapHeader", Type.EmptyTypes);

			internal static readonly MethodInfo ReadBytes = typeof(MessagePackReader).GetRuntimeMethod("ReadBytes", Type.EmptyTypes);

			internal static readonly MethodInfo TryReadNil = typeof(MessagePackReader).GetRuntimeMethod("TryReadNil", Type.EmptyTypes);

			internal static readonly MethodInfo Skip = typeof(MessagePackReader).GetRuntimeMethod("Skip", Type.EmptyTypes);
		}

		internal static class CodeGenHelpersTypeInfo
		{
			public static readonly MethodInfo GetEncodedStringBytes = typeof(CodeGenHelpers).GetRuntimeMethod("GetEncodedStringBytes", new Type[1] { typeof(string) });
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

		private static readonly Type refMessagePackReader = typeof(MessagePackReader).MakeByRefType();

		private static readonly MethodInfo ReadOnlySpanFromByteArray = typeof(ReadOnlySpan<byte>).GetRuntimeMethod("op_Implicit", new Type[1] { typeof(byte[]) });

		private static readonly MethodInfo ReadStringSpan = typeof(CodeGenHelpers).GetRuntimeMethod("ReadStringSpan", new Type[1] { typeof(MessagePackReader).MakeByRefType() });

		private static readonly MethodInfo ArrayFromNullableReadOnlySequence = typeof(CodeGenHelpers).GetRuntimeMethod("GetArrayFromNullableSequence", new Type[1] { typeof(ReadOnlySequence<byte>?).MakeByRefType() });

		private static readonly MethodInfo getFormatterWithVerify = typeof(FormatterResolverExtensions).GetRuntimeMethods().First((MethodInfo x) => x.Name == "GetFormatterWithVerify");

		private static readonly MethodInfo getResolverFromOptions = typeof(MessagePackSerializerOptions).GetRuntimeProperty("Resolver").GetMethod;

		private static readonly MethodInfo getSecurityFromOptions = typeof(MessagePackSerializerOptions).GetRuntimeProperty("Security").GetMethod;

		private static readonly MethodInfo securityDepthStep = typeof(MessagePackSecurity).GetRuntimeMethod("DepthStep", new Type[1] { typeof(MessagePackReader).MakeByRefType() });

		private static readonly MethodInfo readerDepthGet = typeof(MessagePackReader).GetRuntimeProperty("Depth").GetMethod;

		private static readonly MethodInfo readerDepthSet = typeof(MessagePackReader).GetRuntimeProperty("Depth").SetMethod;

		private static readonly Func<Type, MethodInfo> getSerialize = (Type t) => typeof(IMessagePackFormatter<>).MakeGenericType(t).GetRuntimeMethod("Serialize", new Type[3]
		{
			typeof(MessagePackWriter).MakeByRefType(),
			t,
			typeof(MessagePackSerializerOptions)
		});

		private static readonly Func<Type, MethodInfo> getDeserialize = (Type t) => typeof(IMessagePackFormatter<>).MakeGenericType(t).GetRuntimeMethod("Deserialize", new Type[2]
		{
			refMessagePackReader,
			typeof(MessagePackSerializerOptions)
		});

		private static readonly ConstructorInfo messagePackSerializationExceptionMessageOnlyConstructor = typeof(MessagePackSerializationException).GetTypeInfo().DeclaredConstructors.First(delegate(ConstructorInfo x)
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
			if (!type.IsPublic && !type.IsNestedPublic)
			{
				throw new MessagePackSerializationException("Building dynamic formatter only allows public type. Type: " + type.FullName);
			}
			using (MonoProtection.EnterRefEmitLock())
			{
				Type type2 = typeof(IMessagePackFormatter<>).MakeGenericType(type);
				TypeBuilder typeBuilder = assembly.DefineType("MessagePack.Formatters." + SubtractFullNameRegex.Replace(type.FullName, string.Empty).Replace(".", "_") + "Formatter" + Interlocked.Increment(ref nameSequence), TypeAttributes.Public | TypeAttributes.Sealed, null, new Type[1] { type2 });
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
				MethodBuilder methodBuilder = typeBuilder.DefineMethod("Serialize", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual, null, new Type[3]
				{
					typeof(MessagePackWriter).MakeByRefType(),
					type,
					typeof(MessagePackSerializerOptions)
				});
				methodBuilder.DefineParameter(1, ParameterAttributes.None, "writer");
				methodBuilder.DefineParameter(2, ParameterAttributes.None, "value");
				methodBuilder.DefineParameter(3, ParameterAttributes.None, "options");
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
				MethodBuilder methodBuilder2 = typeBuilder.DefineMethod("Deserialize", MethodAttributes.Public | MethodAttributes.Final | MethodAttributes.Virtual, type, new Type[2]
				{
					refMessagePackReader,
					typeof(MessagePackSerializerOptions)
				});
				methodBuilder2.DefineParameter(1, ParameterAttributes.None, "reader");
				methodBuilder2.DefineParameter(2, ParameterAttributes.None, "options");
				ILGenerator il2 = methodBuilder2.GetILGenerator();
				BuildDeserialize(type, objectSerializationInfo, il2, (int index, ObjectSerializationInfo.EmittableMember member) => (!customFormatterLookup.TryGetValue(member, out var fi)) ? null : ((Action)delegate
				{
					il2.EmitLoadThis();
					il2.EmitLdfld(fi);
				}), 1);
				return typeBuilder.CreateTypeInfo();
			}
		}

		public static object BuildFormatterToDynamicMethod(Type type, bool forceStringKey, bool contractless, bool allowPrivate)
		{
			ObjectSerializationInfo objectSerializationInfo = ObjectSerializationInfo.CreateOrNull(type, forceStringKey, contractless, allowPrivate);
			if (objectSerializationInfo == null)
			{
				return null;
			}
			DynamicMethod dynamicMethod = new DynamicMethod("Serialize", null, new Type[5]
			{
				typeof(byte[][]),
				typeof(object[]),
				typeof(MessagePackWriter).MakeByRefType(),
				type,
				typeof(MessagePackSerializerOptions)
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
					list.Add(Utilities.GetWriterBytes(item3.StringKey, delegate(ref MessagePackWriter writer, string arg)
					{
						writer.Write(arg);
					}));
					num++;
				}
			}
			foreach (ObjectSerializationInfo.EmittableMember item4 in objectSerializationInfo.Members.Where((ObjectSerializationInfo.EmittableMember x) => x.IsReadable))
			{
				MessagePackFormatterAttribute messagePackFormatterAttribute = item4.GetMessagePackFormatterAttribute();
				if (messagePackFormatterAttribute != null)
				{
					object item = Activator.CreateInstance(messagePackFormatterAttribute.FormatterType, messagePackFormatterAttribute.Arguments);
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
				MessagePackFormatterAttribute messagePackFormatterAttribute2 = members[num2].GetMessagePackFormatterAttribute();
				if (messagePackFormatterAttribute2 != null)
				{
					object item2 = Activator.CreateInstance(messagePackFormatterAttribute2.FormatterType, messagePackFormatterAttribute2.Arguments);
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
				dynamicMethod2 = new DynamicMethod("Deserialize", type, new Type[3]
				{
					typeof(object[]),
					refMessagePackReader,
					typeof(MessagePackSerializerOptions)
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
				il.EmitCall(CodeGenHelpersTypeInfo.GetEncodedStringBytes);
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
				MessagePackFormatterAttribute messagePackFormatterAttribute = item.GetMessagePackFormatterAttribute();
				if (messagePackFormatterAttribute != null)
				{
					FieldBuilder fieldBuilder = builder.DefineField(item.Name + "_formatter", messagePackFormatterAttribute.FormatterType, FieldAttributes.Private | FieldAttributes.InitOnly);
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
					il.Emit(OpCodes.Castclass, messagePackFormatterAttribute.FormatterType);
					il.Emit(OpCodes.Stfld, fieldBuilder);
					dictionary.Add(item, fieldBuilder);
				}
			}
			return dictionary;
		}

		private static void BuildSerialize(Type type, ObjectSerializationInfo info, ILGenerator il, Action emitStringByteKeys, Func<int, ObjectSerializationInfo.EmittableMember, Action> tryEmitLoadCustomFormatter, int firstArgIndex)
		{
			ArgumentField argWriter = new ArgumentField(il, firstArgIndex);
			ArgumentField argValue = new ArgumentField(il, firstArgIndex + 1, type);
			ArgumentField argOptions = new ArgumentField(il, firstArgIndex + 2);
			if (type.GetTypeInfo().IsClass)
			{
				Label label = il.DefineLabel();
				argValue.EmitLoad();
				il.Emit(OpCodes.Brtrue_S, label);
				argWriter.EmitLoad();
				il.EmitCall(MessagePackWriterTypeInfo.WriteNil);
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
			LocalBuilder localBuilder = il.DeclareLocal(typeof(IFormatterResolver));
			argOptions.EmitLoad();
			il.EmitCall(getResolverFromOptions);
			il.EmitStloc(localBuilder);
			if (info.IsIntKey)
			{
				int num = (from x in info.Members
					where x.IsReadable
					select x.IntKey).DefaultIfEmpty(-1).Max();
				Dictionary<int, ObjectSerializationInfo.EmittableMember> dictionary = info.Members.Where((ObjectSerializationInfo.EmittableMember x) => x.IsReadable).ToDictionary((ObjectSerializationInfo.EmittableMember x) => x.IntKey);
				int value = num + 1;
				argWriter.EmitLoad();
				il.EmitLdc_I4(value);
				il.EmitCall(MessagePackWriterTypeInfo.WriteArrayHeader);
				int num2 = 0;
				for (int num3 = 0; num3 <= num; num3++)
				{
					if (dictionary.TryGetValue(num3, out var value2))
					{
						EmitSerializeValue(il, type.GetTypeInfo(), value2, num2++, tryEmitLoadCustomFormatter, argWriter, argValue, argOptions, localBuilder);
						continue;
					}
					argWriter.EmitLoad();
					il.EmitCall(MessagePackWriterTypeInfo.WriteNil);
				}
			}
			else
			{
				int value3 = info.Members.Count((ObjectSerializationInfo.EmittableMember x) => x.IsReadable);
				argWriter.EmitLoad();
				il.EmitLdc_I4(value3);
				il.EmitCall(MessagePackWriterTypeInfo.WriteMapHeader);
				int num4 = 0;
				foreach (ObjectSerializationInfo.EmittableMember item in info.Members.Where((ObjectSerializationInfo.EmittableMember x) => x.IsReadable))
				{
					argWriter.EmitLoad();
					emitStringByteKeys();
					il.EmitLdc_I4(num4);
					il.Emit(OpCodes.Ldelem_Ref);
					il.Emit(OpCodes.Call, ReadOnlySpanFromByteArray);
					il.EmitCall(MessagePackWriterTypeInfo.WriteRaw);
					EmitSerializeValue(il, type.GetTypeInfo(), item, num4, tryEmitLoadCustomFormatter, argWriter, argValue, argOptions, localBuilder);
					num4++;
				}
			}
			il.Emit(OpCodes.Ret);
		}

		private static void EmitSerializeValue(ILGenerator il, TypeInfo type, ObjectSerializationInfo.EmittableMember member, int index, Func<int, ObjectSerializationInfo.EmittableMember, Action> tryEmitLoadCustomFormatter, ArgumentField argWriter, ArgumentField argValue, ArgumentField argOptions, LocalBuilder localResolver)
		{
			Label label = il.DefineLabel();
			Type type2 = member.Type;
			Action action = tryEmitLoadCustomFormatter(index, member);
			if (action != null)
			{
				action();
				argWriter.EmitLoad();
				argValue.EmitLoad();
				member.EmitLoadValue(il);
				argOptions.EmitLoad();
				il.EmitCall(getSerialize(type2));
			}
			else if (IsOptimizeTargetType(type2))
			{
				if (!type2.GetTypeInfo().IsValueType)
				{
					Label label2 = il.DefineLabel();
					LocalBuilder local = il.DeclareLocal(type2);
					argValue.EmitLoad();
					member.EmitLoadValue(il);
					il.Emit(OpCodes.Dup);
					il.EmitStloc(local);
					il.Emit(OpCodes.Brtrue, label2);
					argWriter.EmitLoad();
					il.EmitCall(MessagePackWriterTypeInfo.WriteNil);
					il.Emit(OpCodes.Br, label);
					il.MarkLabel(label2);
					argWriter.EmitLoad();
					il.EmitLdloc(local);
				}
				else
				{
					argWriter.EmitLoad();
					argValue.EmitLoad();
					member.EmitLoadValue(il);
				}
				if (type2 == typeof(byte[]))
				{
					il.EmitCall(ReadOnlySpanFromByteArray);
					il.EmitCall(MessagePackWriterTypeInfo.WriteBytes);
				}
				else
				{
					il.EmitCall(typeof(MessagePackWriter).GetRuntimeMethod("Write", new Type[1] { type2 }));
				}
			}
			else
			{
				il.EmitLdloc(localResolver);
				il.Emit(OpCodes.Call, getFormatterWithVerify.MakeGenericMethod(type2));
				argWriter.EmitLoad();
				argValue.EmitLoad();
				member.EmitLoadValue(il);
				argOptions.EmitLoad();
				il.EmitCall(getSerialize(type2));
			}
			il.MarkLabel(label);
		}

		private static void BuildDeserialize(Type type, ObjectSerializationInfo info, ILGenerator il, Func<int, ObjectSerializationInfo.EmittableMember, Action> tryEmitLoadCustomFormatter, int firstArgIndex)
		{
			ArgumentField reader = new ArgumentField(il, firstArgIndex, @ref: true);
			ArgumentField argOptions = new ArgumentField(il, firstArgIndex + 1);
			Label label = il.DefineLabel();
			reader.EmitLdarg();
			il.EmitCall(MessagePackReaderTypeInfo.TryReadNil);
			il.Emit(OpCodes.Brfalse_S, label);
			if (type.GetTypeInfo().IsClass)
			{
				il.Emit(OpCodes.Ldnull);
				il.Emit(OpCodes.Ret);
			}
			else
			{
				il.Emit(OpCodes.Ldstr, "typecode is null, struct not supported");
				il.Emit(OpCodes.Newobj, messagePackSerializationExceptionMessageOnlyConstructor);
				il.Emit(OpCodes.Throw);
			}
			il.MarkLabel(label);
			argOptions.EmitLoad();
			il.EmitCall(getSecurityFromOptions);
			reader.EmitLdarg();
			il.EmitCall(securityDepthStep);
			LocalBuilder localBuilder = il.DeclareLocal(typeof(int));
			reader.EmitLdarg();
			if (info.IsIntKey)
			{
				il.EmitCall(MessagePackReaderTypeInfo.ReadArrayHeader);
			}
			else
			{
				il.EmitCall(MessagePackReaderTypeInfo.ReadMapHeader);
			}
			il.EmitStloc(localBuilder);
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
			LocalBuilder localResolver = il.DeclareLocal(typeof(IFormatterResolver));
			argOptions.EmitLoad();
			il.EmitCall(getResolverFromOptions);
			il.EmitStloc(localResolver);
			if (info.IsStringKey)
			{
				AutomataDictionary automata = new AutomataDictionary();
				for (int num = 0; num < info.Members.Length; num++)
				{
					automata.Add(info.Members[num].StringKey, num);
				}
				LocalBuilder buffer = il.DeclareLocal(typeof(ReadOnlySpan<byte>));
				LocalBuilder longKey = il.DeclareLocal(typeof(ulong));
				il.EmitIncrementFor(localBuilder, delegate
				{
					Label readNext = il.DefineLabel();
					Label loopEnd = il.DefineLabel();
					reader.EmitLdarg();
					il.EmitCall(ReadStringSpan);
					il.EmitStloc(buffer);
					automata.EmitMatch(il, buffer, longKey, delegate(KeyValuePair<string, int> x)
					{
						int value = x.Value;
						if (infoList[value].MemberInfo != null)
						{
							EmitDeserializeValue(il, infoList[value], value, tryEmitLoadCustomFormatter, reader, argOptions, localResolver);
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
					reader.EmitLdarg();
					il.EmitCall(MessagePackReaderTypeInfo.Skip);
					il.MarkLabel(loopEnd);
				});
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
					reader.EmitLdarg();
					il.EmitCall(MessagePackReaderTypeInfo.Skip);
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
							EmitDeserializeValue(il, deserializeInfo, num2++, tryEmitLoadCustomFormatter, reader, argOptions, localResolver);
							il.Emit(OpCodes.Br, label2);
						}
					}
					il.MarkLabel(label2);
				});
			}
			LocalBuilder local = EmitNewObject(il, type, info, infoList);
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
						il.EmitLdloca(local);
					}
					il.Emit(OpCodes.Call, array[0]);
				}
				else
				{
					if (info.IsStruct)
					{
						il.EmitLdloc(local);
						il.Emit(OpCodes.Box, type);
					}
					else
					{
						il.Emit(OpCodes.Dup);
					}
					il.EmitCall(onAfterDeserialize);
				}
			}
			reader.EmitLdarg();
			il.Emit(OpCodes.Dup);
			il.EmitCall(readerDepthGet);
			il.Emit(OpCodes.Ldc_I4_1);
			il.Emit(OpCodes.Sub_Ovf);
			il.EmitCall(readerDepthSet);
			if (info.IsStruct)
			{
				il.Emit(OpCodes.Ldloc, local);
			}
			il.Emit(OpCodes.Ret);
		}

		private static void EmitDeserializeValue(ILGenerator il, DeserializeInfo info, int index, Func<int, ObjectSerializationInfo.EmittableMember, Action> tryEmitLoadCustomFormatter, ArgumentField argReader, ArgumentField argOptions, LocalBuilder localResolver)
		{
			Label label = il.DefineLabel();
			ObjectSerializationInfo.EmittableMember memberInfo = info.MemberInfo;
			Type type = memberInfo.Type;
			Action action = tryEmitLoadCustomFormatter(index, memberInfo);
			if (action != null)
			{
				action();
				argReader.EmitLdarg();
				argOptions.EmitLoad();
				il.EmitCall(getDeserialize(type));
			}
			else if (IsOptimizeTargetType(type))
			{
				if (!type.GetTypeInfo().IsValueType)
				{
					Label label2 = il.DefineLabel();
					argReader.EmitLdarg();
					il.EmitCall(MessagePackReaderTypeInfo.TryReadNil);
					il.Emit(OpCodes.Brfalse_S, label2);
					il.Emit(OpCodes.Ldnull);
					il.Emit(OpCodes.Br, label);
					il.MarkLabel(label2);
				}
				argReader.EmitLdarg();
				if (type == typeof(byte[]))
				{
					LocalBuilder local = il.DeclareLocal(typeof(ReadOnlySequence<byte>?));
					il.EmitCall(MessagePackReaderTypeInfo.ReadBytes);
					il.EmitStloc(local);
					il.EmitLdloca(local);
					il.EmitCall(ArrayFromNullableReadOnlySequence);
				}
				else
				{
					il.EmitCall(MessagePackReaderTypeInfo.TypeInfo.GetDeclaredMethods("Read" + type.Name).First((MethodInfo x) => x.GetParameters().Length == 0));
				}
			}
			else
			{
				il.EmitLdloc(localResolver);
				il.EmitCall(getFormatterWithVerify.MakeGenericMethod(type));
				argReader.EmitLdarg();
				argOptions.EmitLoad();
				il.EmitCall(getDeserialize(type));
			}
			il.MarkLabel(label);
			il.EmitStloc(info.LocalField);
		}

		private static LocalBuilder EmitNewObject(ILGenerator il, Type type, ObjectSerializationInfo info, DeserializeInfo[] members)
		{
			if (info.IsClass)
			{
				EmitNewObjectConstructorArguments(il, info, members);
				il.Emit(OpCodes.Newobj, info.BestmatchConstructor);
				foreach (DeserializeInfo item in members.Where((DeserializeInfo x) => x.MemberInfo != null && x.MemberInfo.IsWritable))
				{
					il.Emit(OpCodes.Dup);
					il.EmitLdloc(item.LocalField);
					item.MemberInfo.EmitStoreValue(il);
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
				EmitNewObjectConstructorArguments(il, info, members);
				il.Emit(OpCodes.Newobj, info.BestmatchConstructor);
				il.Emit(OpCodes.Stloc, localBuilder);
			}
			foreach (DeserializeInfo item2 in members.Where((DeserializeInfo x) => x.MemberInfo != null && x.MemberInfo.IsWritable))
			{
				il.EmitLdloca(localBuilder);
				il.EmitLdloc(item2.LocalField);
				item2.MemberInfo.EmitStoreValue(il);
			}
			return localBuilder;
		}

		private static void EmitNewObjectConstructorArguments(ILGenerator il, ObjectSerializationInfo info, DeserializeInfo[] members)
		{
			ObjectSerializationInfo.EmittableMemberAndConstructorParameter[] constructorParameters = info.ConstructorParameters;
			foreach (ObjectSerializationInfo.EmittableMemberAndConstructorParameter item in constructorParameters)
			{
				DeserializeInfo deserializeInfo = members.First((DeserializeInfo x) => x.MemberInfo == item.MemberInfo);
				il.EmitLdloc(deserializeInfo.LocalField);
				if (!item.ConstructorParameter.ParameterType.IsValueType && deserializeInfo.MemberInfo.IsValueType)
				{
					il.Emit(OpCodes.Box, deserializeInfo.MemberInfo.Type);
				}
			}
		}

		private static bool IsOptimizeTargetType(Type type)
		{
			if (!(type == typeof(short)) && !(type == typeof(int)) && !(type == typeof(long)) && !(type == typeof(ushort)) && !(type == typeof(uint)) && !(type == typeof(ulong)) && !(type == typeof(float)) && !(type == typeof(double)) && !(type == typeof(bool)) && !(type == typeof(byte)) && !(type == typeof(sbyte)) && !(type == typeof(char)))
			{
				return type == typeof(byte[]);
			}
			return true;
		}

		private static bool Matches(MethodInfo m, int parameterIndex, Type desiredType)
		{
			ParameterInfo[] parameters = m.GetParameters();
			if (parameters.Length > parameterIndex && parameters[parameterIndex].ParameterType.Name == desiredType.Name)
			{
				return parameters[parameterIndex].ParameterType.Namespace == desiredType.Namespace;
			}
			return false;
		}
	}
}
