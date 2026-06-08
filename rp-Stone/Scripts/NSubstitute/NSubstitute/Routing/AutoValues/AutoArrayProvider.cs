using System;

namespace NSubstitute.Routing.AutoValues
{
	public class AutoArrayProvider : IAutoValueProvider
	{
		public bool CanProvideValueFor(Type type)
		{
			return type.IsArray;
		}

		public object GetValue(Type type)
		{
			int[] lengths = new int[type.GetArrayRank()];
			return Array.CreateInstance(type.GetElementType(), lengths);
		}
	}
}
