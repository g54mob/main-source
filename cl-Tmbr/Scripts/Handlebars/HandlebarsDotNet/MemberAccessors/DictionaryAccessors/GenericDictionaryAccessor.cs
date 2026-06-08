using System.Collections.Generic;
using System.ComponentModel;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet.MemberAccessors.DictionaryAccessors
{
	public sealed class GenericDictionaryAccessor<T, TK, TV> : IMemberAccessor where T : IDictionary<TK, TV>
	{
		private static readonly TypeConverter TypeConverter = TypeDescriptor.GetConverter(typeof(TK));

		public bool TryGetValue(object instance, ChainSegment memberName, out object value)
		{
			TK val = (TK)TypeConverter.ConvertFromString(memberName.TrimmedValue);
			T val2 = (T)instance;
			if (val != null && val2.TryGetValue(val, out var value2))
			{
				value = value2;
				return true;
			}
			value = null;
			return false;
		}
	}
}
