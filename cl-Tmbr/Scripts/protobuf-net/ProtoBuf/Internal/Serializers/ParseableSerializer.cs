using System;
using System.Reflection;
using ProtoBuf.Compiler;

namespace ProtoBuf.Internal.Serializers
{
	internal sealed class ParseableSerializer : IRuntimeProtoSerializerNode
	{
		private readonly MethodInfo parse;

		bool IRuntimeProtoSerializerNode.IsScalar => true;

		public Type ExpectedType => parse.DeclaringType;

		bool IRuntimeProtoSerializerNode.RequiresOldValue => false;

		bool IRuntimeProtoSerializerNode.ReturnsValue => true;

		public static ParseableSerializer TryCreate(Type type)
		{
			if ((object)type == null)
			{
				throw new ArgumentNullException("type");
			}
			MethodInfo method = type.GetMethod("Parse", BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public, null, new Type[1] { typeof(string) }, null);
			if ((object)method != null && method.ReturnType == type)
			{
				if (type.IsValueType)
				{
					MethodInfo customToString = GetCustomToString(type);
					if ((object)customToString == null || customToString.ReturnType != typeof(string))
					{
						return null;
					}
				}
				return new ParseableSerializer(method);
			}
			return null;
		}

		private static MethodInfo GetCustomToString(Type type)
		{
			return type.GetMethod("ToString", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public, null, Type.EmptyTypes, null);
		}

		private ParseableSerializer(MethodInfo parse)
		{
			this.parse = parse;
		}

		public object Read(ref ProtoReader.State state, object value)
		{
			return parse.Invoke(null, new object[1] { state.ReadString() });
		}

		public void Write(ref ProtoWriter.State state, object value)
		{
			state.WriteString(value.ToString());
		}

		void IRuntimeProtoSerializerNode.EmitWrite(CompilerContext ctx, Local valueFrom)
		{
			Type expectedType = ExpectedType;
			using Local local = ctx.GetLocalWithValue(ExpectedType, valueFrom);
			ctx.LoadState();
			ctx.LoadAddress(local, expectedType);
			if (expectedType.IsValueType)
			{
				ctx.EmitCall(GetCustomToString(expectedType));
			}
			else
			{
				ctx.EmitCall(typeof(object).GetMethod("ToString"));
			}
			ctx.LoadNullRef();
			ctx.EmitCall(typeof(ProtoWriter.State).GetMethod("WriteString", BindingFlags.Instance | BindingFlags.Public, null, new Type[2]
			{
				typeof(string),
				typeof(StringMap)
			}, null));
		}

		void IRuntimeProtoSerializerNode.EmitRead(CompilerContext ctx, Local entity)
		{
			ctx.LoadState();
			ctx.LoadNullRef();
			ctx.EmitCall(typeof(ProtoReader.State).GetMethod("ReadString", BindingFlags.Instance | BindingFlags.Public, null, new Type[1] { typeof(StringMap) }, null));
			ctx.EmitCall(parse);
		}
	}
}
