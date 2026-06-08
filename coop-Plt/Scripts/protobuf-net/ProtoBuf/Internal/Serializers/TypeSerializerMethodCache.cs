using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ProtoBuf.Meta;

namespace ProtoBuf.Internal.Serializers
{
	internal static class TypeSerializerMethodCache
	{
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
