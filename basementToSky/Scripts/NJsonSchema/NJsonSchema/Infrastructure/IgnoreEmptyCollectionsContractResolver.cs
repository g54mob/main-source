using System.Collections;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NJsonSchema.Infrastructure
{
	internal sealed class IgnoreEmptyCollectionsContractResolver : PropertyRenameAndIgnoreSerializerContractResolver
	{
		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
		{
			JsonProperty property = base.CreateProperty(member, memberSerialization);
			if ((property.Required == Required.Default || property.Required == Required.DisallowNull) && property.PropertyType != typeof(string) && typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(property.PropertyType.GetTypeInfo()))
			{
				property.ShouldSerialize = (object instance) => ((instance != null) ? (property.ValueProvider.GetValue(instance) as IEnumerable) : null)?.GetEnumerator().MoveNext() ?? true;
			}
			return property;
		}
	}
}
