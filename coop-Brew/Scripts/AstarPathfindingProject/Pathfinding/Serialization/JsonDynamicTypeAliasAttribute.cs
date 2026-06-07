using System;

namespace Pathfinding.Serialization
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class JsonDynamicTypeAliasAttribute : Attribute
	{
		public string alias;

		public Type type;

		public JsonDynamicTypeAliasAttribute(string alias, Type type)
		{
		}
	}
}
