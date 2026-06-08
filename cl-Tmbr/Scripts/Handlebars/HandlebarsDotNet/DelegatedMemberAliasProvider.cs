using System;
using System.Collections.Generic;
using System.Linq;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet
{
	public sealed class DelegatedMemberAliasProvider : IMemberAliasProvider, IMemberAliasProvider<object>
	{
		private readonly Dictionary<Type, Dictionary<string, Func<object, object>>> _aliases = new Dictionary<Type, Dictionary<string, Func<object, object>>>();

		public DelegatedMemberAliasProvider AddAlias(Type type, string alias, Func<object, object> accessor)
		{
			if (!_aliases.TryGetValue(type, out var value))
			{
				value = new Dictionary<string, Func<object, object>>(StringComparer.OrdinalIgnoreCase);
				_aliases.Add(type, value);
			}
			value.Add(alias, accessor);
			return this;
		}

		public DelegatedMemberAliasProvider AddAlias<T>(string alias, Func<T, object> accessor)
		{
			AddAlias(typeof(T), alias, (object o) => accessor((T)o));
			return this;
		}

		bool IMemberAliasProvider<object>.TryGetMemberByAlias(object instance, Type targetType, ChainSegment memberAlias, out object value)
		{
			if (_aliases.TryGetValue(targetType, out var value2) && value2.TryGetValue(memberAlias, out var value3))
			{
				value = value3(instance);
				return true;
			}
			value2 = _aliases.FirstOrDefault((KeyValuePair<Type, Dictionary<string, Func<object, object>>> o) => o.Key.IsAssignableFrom(targetType)).Value;
			if (value2 != null && value2.TryGetValue(memberAlias, out var value4))
			{
				value = value4(instance);
				return true;
			}
			value = null;
			return false;
		}
	}
}
