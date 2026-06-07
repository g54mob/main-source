using System;

namespace JWT
{
	public interface IJsonSerializer
	{
		string Serialize(object obj);

		object Deserialize(Type type, string json);
	}
}
