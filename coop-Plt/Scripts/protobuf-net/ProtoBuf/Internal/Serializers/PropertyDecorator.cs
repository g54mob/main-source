using System;
using System.Reflection;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class PropertyDecorator : ProtoDecoratorBase
	{
		private readonly PropertyInfo property;

		private readonly bool readOptionsWriteValue;

		private readonly MethodInfo shadowSetter;

		public override Type ExpectedType { get; }

		public override bool RequiresOldValue => true;

		public override bool ReturnsValue => false;

		public PropertyDecorator(Type forType, PropertyInfo property, IRuntimeProtoSerializerNode tail)
			: base(tail)
		{
			if (tail == null)
			{
				ThrowHelper.ThrowArgumentNullException("tail");
			}
			if ((object)property == null)
			{
				ThrowHelper.ThrowArgumentNullException("property");
			}
			if ((object)forType == null)
			{
				ThrowHelper.ThrowArgumentNullException("forType");
			}
			ExpectedType = forType;
			this.property = property;
			SanityCheck(property, tail, out readOptionsWriteValue, nonPublic: true, allowInternal: true);
			shadowSetter = GetShadowSetter(property);
		}

		private static void SanityCheck(PropertyInfo property, IRuntimeProtoSerializerNode tail, out bool writeValue, bool nonPublic, bool allowInternal)
		{
			if ((object)property == null)
			{
				throw new ArgumentNullException("property");
			}
			writeValue = tail.ReturnsValue && ((object)GetShadowSetter(property) != null || (property.CanWrite && (object)Helpers.GetSetMethod(property, nonPublic, allowInternal) != null));
			if (!property.CanRead || (object)Helpers.GetGetMethod(property, nonPublic, allowInternal) == null)
			{
				throw new InvalidOperationException("Cannot serialize property without an accessible get accessor: " + property.DeclaringType.FullName + "." + property.Name);
			}
			if (!writeValue && (!tail.RequiresOldValue || tail.ExpectedType.IsValueType))
			{
				throw new InvalidOperationException("Cannot apply changes to property " + property.DeclaringType.FullName + "." + property.Name);
			}
		}

		private static MethodInfo GetShadowSetter(PropertyInfo property)
		{
			Type reflectedType = property.ReflectedType;
			MethodInfo instanceMethod = Helpers.GetInstanceMethod(reflectedType, "Set" + property.Name, new Type[1] { property.PropertyType });
			if ((object)instanceMethod == null || !instanceMethod.IsPublic || instanceMethod.ReturnType != typeof(void))
			{
				return null;
			}
			return instanceMethod;
		}

		public override void Write(ref ProtoWriter.State state, object value)
		{
			value = property.GetValue(value, null);
			if (value != null)
			{
				Tail.Write(ref state, value);
			}
		}

		public override object Read(ref ProtoReader.State state, object value)
		{
			object value2 = (Tail.RequiresOldValue ? property.GetValue(value, null) : null);
			object obj = Tail.Read(ref state, value2);
			if (readOptionsWriteValue && obj != null)
			{
				if ((object)shadowSetter == null)
				{
					property.SetValue(value, obj, null);
				}
				else
				{
					shadowSetter.Invoke(value, new object[1] { obj });
				}
			}
			return null;
		}

		protected override void EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			ctx.LoadAddress(valueFrom, ExpectedType);
			ctx.LoadValue(property);
			ctx.WriteNullCheckedTail(property.PropertyType, Tail, null);
		}

		internal static Type ChooseReadLocalType(Type memberType, Type tailType)
		{
			if (memberType == tailType)
			{
				return memberType;
			}
			if (memberType.IsClass && tailType.IsClass)
			{
				return tailType;
			}
			if (memberType.IsValueType && tailType.IsValueType && tailType == Nullable.GetUnderlyingType(memberType))
			{
				return memberType;
			}
			return tailType;
		}

		protected override void EmitRead(CompilerContext ctx, Local valueFrom)
		{
			SanityCheck(property, Tail, out var writeValue, ctx.NonPublic, ctx.AllowInternal(property));
			if (ExpectedType.IsValueType && valueFrom == null)
			{
				throw new InvalidOperationException("Attempt to mutate struct on the head of the stack; changes would be lost");
			}
			using Local local = ctx.GetLocalWithValue(ExpectedType, valueFrom);
			if (Tail.RequiresOldValue)
			{
				ctx.LoadAddress(local, ExpectedType);
				ctx.LoadValue(property);
			}
			Type propertyType = property.PropertyType;
			ctx.ReadNullCheckedTail(propertyType, Tail, null);
			if (writeValue)
			{
				Type type = ChooseReadLocalType(property.PropertyType, Tail.ExpectedType);
				using Local local2 = new Local(ctx, type);
				ctx.StoreValue(local2);
				CodeLabel label = default(CodeLabel);
				if (!type.IsValueType)
				{
					label = ctx.DefineLabel();
					ctx.LoadValue(local2);
					ctx.BranchIfFalse(label, @short: true);
				}
				ctx.LoadAddress(local, ExpectedType);
				ctx.LoadValue(local2);
				if (!property.PropertyType.IsValueType && !type.IsValueType && !property.PropertyType.IsAssignableFrom(type))
				{
					ctx.Cast(property.PropertyType);
				}
				if ((object)shadowSetter == null)
				{
					ctx.StoreValue(property);
				}
				else
				{
					ctx.EmitCall(shadowSetter);
				}
				if (!propertyType.IsValueType)
				{
					ctx.MarkLabel(label);
				}
				return;
			}
			if (Tail.ReturnsValue)
			{
				ctx.DiscardValue();
			}
		}
	}
}
