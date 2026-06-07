using System;

namespace Sirenix.Serialization
{
	internal class GenericCollectionFormatterLocator : IFormatterLocator
	{
		public bool TryGetFormatter(Type type, FormatterLocationStep step, ISerializationPolicy policy, out IFormatter formatter)
		{
			Type elementType;
			if (step != FormatterLocationStep.AfterRegisteredFormatters || !GenericCollectionFormatter.CanFormat(type, out elementType))
			{
				formatter = null;
				return false;
			}
			formatter = (IFormatter)Activator.CreateInstance(typeof(GenericCollectionFormatter<, >).MakeGenericType(type, elementType));
			return true;
		}
	}
}
