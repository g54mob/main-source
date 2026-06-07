using System;
using System.Collections.Generic;

namespace LitJson
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	public class JsonIgnoreMember : Attribute
	{
		public HashSet<string> Members { get; private set; }

		public JsonIgnoreMember(IEnumerable<string> members)
		{
			Members = new HashSet<string>(members);
		}

		public JsonIgnoreMember(params string[] members)
		{
			Members = new HashSet<string>(members);
		}
	}
}
