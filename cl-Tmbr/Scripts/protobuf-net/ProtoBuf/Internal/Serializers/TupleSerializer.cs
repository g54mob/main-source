using System;
using System.Reflection;
using ProtoBuf.Compiler;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class TupleSerializer<T> : IProtoTypeSerializer, IRuntimeProtoSerializerNode, ISerializer<T>
	{
		private readonly MemberInfo[] members;

		private readonly ConstructorInfo ctor;

		private readonly IRuntimeProtoSerializerNode[] tails;

		bool IRuntimeProtoSerializerNode.IsScalar => false;

		public SerializerFeatures Features { get; private set; } = SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessage;

		bool IProtoTypeSerializer.IsSubType => false;

		public Type ExpectedType => typeof(T);

		Type IProtoTypeSerializer.BaseType => typeof(T);

		public bool RequiresOldValue => true;

		public bool ReturnsValue => false;

		bool IProtoTypeSerializer.ShouldEmitCreateInstance => false;

		bool IProtoTypeSerializer.HasInheritance => false;

		public TupleSerializer(RuntimeTypeModel model, ConstructorInfo ctor, MemberInfo[] members, SerializerFeatures features, CompatibilityLevel compatibilityLevel)
		{
			this.ctor = ctor ?? throw new ArgumentNullException("ctor");
			this.members = members ?? throw new ArgumentNullException("members");
			tails = new IRuntimeProtoSerializerNode[members.Length];
			Features = features;
			ParameterInfo[] parameters = ctor.GetParameters();
			for (int i = 0; i < members.Length; i++)
			{
				Type parameterType = parameters[i].ParameterType;
				RepeatedSerializerStub repeatedSerializerStub = model.TryGetRepeatedProvider(parameterType);
				Type type = repeatedSerializerStub?.ItemType ?? parameterType;
				bool asReference = false;
				int num = model.FindOrAddAuto(type, demand: false, addWithContractOnly: true, addEvenIfAutoDisabled: false, compatibilityLevel);
				if (num >= 0)
				{
					asReference = model[type].AsReferenceDefault;
				}
				WireType defaultWireType;
				IRuntimeProtoSerializerNode runtimeProtoSerializerNode = ValueMember.TryGetCoreSerializer(model, DataFormat.Default, compatibilityLevel, type, out defaultWireType, asReference, dynamicType: false, overwriteList: false, allowComplexTypes: true);
				if (runtimeProtoSerializerNode == null)
				{
					ThrowHelper.NoSerializerDefined(type);
				}
				IRuntimeProtoSerializerNode runtimeProtoSerializerNode2;
				if (repeatedSerializerStub == null)
				{
					runtimeProtoSerializerNode2 = new TagDecorator(i + 1, defaultWireType, strict: false, runtimeProtoSerializerNode);
				}
				else if (repeatedSerializerStub.IsMap)
				{
					runtimeProtoSerializerNode2 = ValueMember.CreateMap(repeatedSerializerStub, model, DataFormat.Default, compatibilityLevel, DataFormat.Default, DataFormat.Default, asReference, dynamicType: false, isMap: true, overwriteList: false, i + 1, null);
				}
				else
				{
					SerializerFeatures features2 = defaultWireType.AsFeatures() | SerializerFeatures.OptionPackedDisabled;
					runtimeProtoSerializerNode2 = RepeatedDecorator.Create(repeatedSerializerStub, i + 1, features2, compatibilityLevel, DataFormat.Default);
				}
				tails[i] = runtimeProtoSerializerNode2;
			}
		}

		public bool HasCallbacks(TypeModel.CallbackType callbackType)
		{
			return false;
		}

		public void EmitCallback(CompilerContext ctx, Local valueFrom, TypeModel.CallbackType callbackType)
		{
		}

		void IProtoTypeSerializer.Callback(object value, TypeModel.CallbackType callbackType, ISerializationContext context)
		{
		}

		object IProtoTypeSerializer.CreateInstance(ISerializationContext source)
		{
			throw new NotSupportedException();
		}

		private object GetValue(object obj, int index)
		{
			if (members[index] is PropertyInfo propertyInfo)
			{
				if (obj == null)
				{
					if (!propertyInfo.PropertyType.IsValueType)
					{
						return null;
					}
					return Activator.CreateInstance(propertyInfo.PropertyType, nonPublic: true);
				}
				return propertyInfo.GetValue(obj, null);
			}
			if (members[index] is FieldInfo fieldInfo)
			{
				if (obj == null)
				{
					if (!fieldInfo.FieldType.IsValueType)
					{
						return null;
					}
					return Activator.CreateInstance(fieldInfo.FieldType, nonPublic: true);
				}
				return fieldInfo.GetValue(obj);
			}
			throw new InvalidOperationException();
		}

		T ISerializer<T>.Read(ref ProtoReader.State state, T value)
		{
			return (T)Read(ref state, value);
		}

		void ISerializer<T>.Write(ref ProtoWriter.State state, T value)
		{
			Write(ref state, value);
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			object[] array = new object[members.Length];
			bool flag = false;
			if (value == null)
			{
				flag = true;
			}
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = GetValue(value, i);
			}
			int num;
			while ((num = state.ReadFieldHeader()) > 0)
			{
				flag = true;
				if (num <= tails.Length)
				{
					IRuntimeProtoSerializerNode runtimeProtoSerializerNode = tails[num - 1];
					array[num - 1] = tails[num - 1].Read(ref state, runtimeProtoSerializerNode.RequiresOldValue ? array[num - 1] : null);
				}
				else
				{
					state.SkipField();
				}
			}
			if (!flag)
			{
				return value;
			}
			return ctor.Invoke(array);
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			for (int i = 0; i < tails.Length; i++)
			{
				object value2 = GetValue(value, i);
				if (value2 != null)
				{
					tails[i].Write(ref state, value2);
				}
			}
		}

		bool IProtoTypeSerializer.CanCreateInstance()
		{
			return false;
		}

		private Type GetMemberType(int index)
		{
			return Helpers.GetMemberType(members[index]) ?? throw new InvalidOperationException();
		}

		public void EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			using Local local = ctx.GetLocalWithValue(ctor.DeclaringType, valueFrom);
			for (int i = 0; i < tails.Length; i++)
			{
				Type memberType = GetMemberType(i);
				ctx.LoadAddress(local, ExpectedType);
				if (members[i] is FieldInfo field)
				{
					ctx.LoadValue(field);
				}
				else if (members[i] is PropertyInfo property)
				{
					ctx.LoadValue(property);
				}
				ctx.WriteNullCheckedTail(memberType, tails[i], null);
			}
		}

		void IProtoTypeSerializer.EmitCreateInstance(CompilerContext ctx, bool callNoteObject)
		{
			throw new NotSupportedException();
		}

		void IProtoTypeSerializer.EmitReadRoot(CompilerContext ctx, Local valueFrom)
		{
			EmitRead(ctx, valueFrom);
		}

		void IProtoTypeSerializer.EmitWriteRoot(CompilerContext ctx, Local valueFrom)
		{
			EmitWrite(ctx, valueFrom);
		}

		public void EmitRead(CompilerContext ctx, Local incoming)
		{
			using Local local = ctx.GetLocalWithValue(ExpectedType, incoming);
			Local[] array = new Local[members.Length];
			try
			{
				for (int i = 0; i < array.Length; i++)
				{
					Type memberType = GetMemberType(i);
					bool flag = true;
					array[i] = new Local(ctx, memberType);
					if (ExpectedType.IsValueType)
					{
						continue;
					}
					if (memberType.IsValueType)
					{
						switch (Helpers.GetTypeCode(memberType))
						{
						case ProtoTypeCode.Boolean:
						case ProtoTypeCode.SByte:
						case ProtoTypeCode.Byte:
						case ProtoTypeCode.Int16:
						case ProtoTypeCode.UInt16:
						case ProtoTypeCode.Int32:
						case ProtoTypeCode.UInt32:
							ctx.LoadValue(0);
							break;
						case ProtoTypeCode.Int64:
						case ProtoTypeCode.UInt64:
							ctx.LoadValue(0L);
							break;
						case ProtoTypeCode.Single:
							ctx.LoadValue(0f);
							break;
						case ProtoTypeCode.Double:
							ctx.LoadValue(0.0);
							break;
						case ProtoTypeCode.Decimal:
							ctx.LoadValue(0m);
							break;
						case ProtoTypeCode.Guid:
							ctx.LoadValue(Guid.Empty);
							break;
						default:
							ctx.LoadAddress(array[i], memberType);
							ctx.EmitCtor(memberType);
							flag = false;
							break;
						}
					}
					else
					{
						ctx.LoadNullRef();
					}
					if (flag)
					{
						ctx.StoreValue(array[i]);
					}
				}
				CodeLabel label = (ExpectedType.IsValueType ? default(CodeLabel) : ctx.DefineLabel());
				if (!ExpectedType.IsValueType)
				{
					ctx.LoadAddress(local, ExpectedType);
					ctx.BranchIfFalse(label, @short: false);
				}
				for (int j = 0; j < members.Length; j++)
				{
					ctx.LoadAddress(local, ExpectedType);
					if (members[j] is FieldInfo field)
					{
						ctx.LoadValue(field);
					}
					else if (members[j] is PropertyInfo property)
					{
						ctx.LoadValue(property);
					}
					ctx.StoreValue(array[j]);
				}
				if (!ExpectedType.IsValueType)
				{
					ctx.MarkLabel(label);
				}
				using (Local local2 = new Local(ctx, typeof(int)))
				{
					CodeLabel label2 = ctx.DefineLabel();
					CodeLabel label3 = ctx.DefineLabel();
					CodeLabel label4 = ctx.DefineLabel();
					ctx.Branch(label2, @short: false);
					CodeLabel[] array2 = new CodeLabel[members.Length];
					for (int k = 0; k < members.Length; k++)
					{
						array2[k] = ctx.DefineLabel();
					}
					ctx.MarkLabel(label3);
					ctx.LoadValue(local2);
					ctx.LoadValue(1);
					ctx.Subtract();
					ctx.Switch(array2);
					ctx.Branch(label4, @short: false);
					for (int l = 0; l < array2.Length; l++)
					{
						ctx.MarkLabel(array2[l]);
						IRuntimeProtoSerializerNode runtimeProtoSerializerNode = tails[l];
						Local valueFrom = (runtimeProtoSerializerNode.RequiresOldValue ? array[l] : null);
						ctx.ReadNullCheckedTail(array[l].Type, runtimeProtoSerializerNode, valueFrom);
						if (runtimeProtoSerializerNode.ReturnsValue)
						{
							if (array[l].Type.IsValueType)
							{
								ctx.StoreValue(array[l]);
							}
							else
							{
								CodeLabel label5 = ctx.DefineLabel();
								CodeLabel label6 = ctx.DefineLabel();
								ctx.CopyValue();
								ctx.BranchIfTrue(label5, @short: true);
								ctx.DiscardValue();
								ctx.Branch(label6, @short: true);
								ctx.MarkLabel(label5);
								ctx.StoreValue(array[l]);
								ctx.MarkLabel(label6);
							}
						}
						ctx.Branch(label2, @short: false);
					}
					ctx.MarkLabel(label4);
					ctx.LoadState();
					ctx.EmitCall(typeof(ProtoReader.State).GetMethod("SkipField", Type.EmptyTypes));
					ctx.MarkLabel(label2);
					ctx.EmitStateBasedRead("ReadFieldHeader", typeof(int));
					ctx.CopyValue();
					ctx.StoreValue(local2);
					ctx.LoadValue(0);
					ctx.BranchIfGreater(label3, @short: false);
				}
				for (int m = 0; m < array.Length; m++)
				{
					ctx.LoadValue(array[m]);
				}
				ctx.EmitCtor(ctor);
				ctx.StoreValue(local);
			}
			finally
			{
				for (int n = 0; n < array.Length; n++)
				{
					if (array[n] != null)
					{
						array[n].Dispose();
					}
				}
			}
		}
	}
}
