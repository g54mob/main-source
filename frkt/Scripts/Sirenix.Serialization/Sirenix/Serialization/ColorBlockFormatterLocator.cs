using System;

namespace Sirenix.Serialization
{
	public class ColorBlockFormatterLocator : IFormatterLocator
	{
		public bool TryGetFormatter(Type type, FormatterLocationStep step, ISerializationPolicy policy, bool allowWeakFallbackFormatters, out IFormatter formatter)
		{
			formatter = null;
			return false;
		}
	}
}
