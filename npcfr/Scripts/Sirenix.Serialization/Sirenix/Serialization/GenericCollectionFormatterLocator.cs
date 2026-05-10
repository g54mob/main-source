using System;

namespace Sirenix.Serialization
{
	internal class GenericCollectionFormatterLocator : IFormatterLocator
	{
		public bool TryGetFormatter(Type type, FormatterLocationStep step, ISerializationPolicy policy, bool allowWeakFallbackFormatters, out IFormatter formatter)
		{
			formatter = null;
			return false;
		}
	}
}
