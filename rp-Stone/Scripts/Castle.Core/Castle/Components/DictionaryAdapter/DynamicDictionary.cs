using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Castle.Components.DictionaryAdapter
{
	public class DynamicDictionary : DynamicObject
	{
		private readonly IDictionary dictionary;

		public DynamicDictionary(IDictionary dictionary)
		{
			this.dictionary = dictionary;
		}

		public override IEnumerable<string> GetDynamicMemberNames()
		{
			return from object key in dictionary.Keys
				select key.ToString();
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			result = dictionary[binder.Name];
			return true;
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			dictionary[binder.Name] = value;
			return true;
		}
	}
}
