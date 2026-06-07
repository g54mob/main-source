using System.Collections.Generic;

public class EnumPropertyDictionary<T>
{
	private Dictionary<T, FloatProperty> dictionary;

	public EnumPropertyDictionary(IEqualityComparer<T> equalityComparer)
	{
		dictionary = new Dictionary<T, FloatProperty>(equalityComparer);
	}
}
