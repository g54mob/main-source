using System;
using ProtoBuf.Compiler;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf.Internal.Serializers
{
	internal interface IProtoTypeSerializer : IRuntimeProtoSerializerNode
	{
		Type BaseType { get; }

		bool ShouldEmitCreateInstance { get; }

		bool HasInheritance { get; }

		bool IsSubType { get; }

		SerializerFeatures Features { get; }

		bool HasCallbacks(TypeModel.CallbackType callbackType);

		bool CanCreateInstance();

		object CreateInstance(ISerializationContext context);

		void Callback(object value, TypeModel.CallbackType callbackType, ISerializationContext context);

		void EmitCallback(CompilerContext ctx, Local valueFrom, TypeModel.CallbackType callbackType);

		void EmitCreateInstance(CompilerContext ctx, bool callNoteObject = true);

		void EmitReadRoot(CompilerContext ctx, Local entity);

		void EmitWriteRoot(CompilerContext ctx, Local entity);
	}
}
