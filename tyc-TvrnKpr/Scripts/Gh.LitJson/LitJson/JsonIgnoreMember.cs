using System;
using System.Collections.Generic;

namespace LitJson
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	public class JsonIgnoreMember : Attribute
	{
		public HashSet<string> Members { get; private set; }

		public JsonIgnoreMember(params string[] members)
		{
		}

		public JsonIgnoreMember(ICollection<string> members)
		{
		}
	}
}
