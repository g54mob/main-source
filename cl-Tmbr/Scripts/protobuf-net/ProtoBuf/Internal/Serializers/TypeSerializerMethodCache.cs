using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ProtoBuf.Meta;

namespace ProtoBuf.Internal.Serializers
{
	internal static class TypeSerializerMethodCache
	{
		internal static readonly Type Type_IExtensible = typeof(IExtensible);

		internal static readonly Type Type_ITypedIExtensible = typeof(ITypedExtensible);

		internal static readonly MethodInfo Method_Write_AppendExtensionData_IExtensible = typeof(ProtoWriter.State).GetMethod("AppendExtensionData", new Type[1] { typeof(IExtensible) });

		internal static readonly MethodInfo Method_Write_AppendExtensionData_ITypedExtensible = typeof(ProtoWriter.State).GetMethod("AppendExtensionData", new Type[2]
		{
			typeof(ITypedExtensible),
			typeof(Type)
		});

		internal static readonly MethodInfo Method_Read_AppendExtensionData_IExtensible = typeof(ProtoReader.State).GetMethod("AppendExtensionData", new Type[1] { typeof(IExtensible) });

		internal static readonly MethodInfo Method_Read_AppendExtensionData_ITypedExtensible = typeof(ProtoReader.State).GetMethod("AppendExtensionData", new Type[2]
		{
			typeof(ITypedExtensible),
			typeof(Type)
		});

		internal static readonly Dictionary<int, MethodInfo> ThrowUnexpectedSubtype = (from method in typeof(TypeModel).GetMethods(BindingFlags.Static | BindingFlags.Public)
			where method.Name == "ThrowUnexpectedSubtype" && method.IsGenericMethodDefinition
			where method.GetParameters().Length == 1
			let args = method.GetGenericArguments()
			select new
			{
				Count = args.Length,
				Method = method
			}).ToDictionary(x => x.Count, x => x.Method);
	}
}
