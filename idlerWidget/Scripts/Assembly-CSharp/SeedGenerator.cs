using System.Collections.Generic;
using System.Text;
using LightJson;

public class SeedGenerator
{
	private static readonly byte[] SeparatorBytes = new byte[3] { 251, 45, 49 };

	public static readonly ulong FnvPrime64 = 1099511628211uL;

	public static readonly ulong FnvOffset64 = 14695981039346656037uL;

	public ulong Hash { get; private set; }

	public SeedGenerator()
	{
		Hash = FnvOffset64;
	}

	public SeedGenerator Add(string data)
	{
		if (data == null)
		{
			data = "null";
		}
		return Add(Encoding.ASCII.GetBytes(data)).Add(SeparatorBytes);
	}

	public SeedGenerator Add(object data)
	{
		return Add(data?.ToString());
	}

	public SeedGenerator Add(byte[] data)
	{
		for (int i = 0; i < data.Length; i++)
		{
			Hash ^= data[i];
			Hash *= FnvPrime64;
		}
		return this;
	}

	public SeedGenerator Add(JsonObject data)
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, JsonValue> datum in data)
		{
			list.Add(datum.Key);
		}
		list.Sort();
		foreach (string item in list)
		{
			Add("K");
			Add(item);
			Add("V");
			JsonValue jsonValue = data[item];
			if (jsonValue.IsJsonObject)
			{
				Add(jsonValue.AsJsonObject);
			}
			else if (jsonValue.IsJsonArray)
			{
				Add(jsonValue.AsJsonArray);
			}
			else
			{
				Add(jsonValue.AsString);
			}
		}
		return this;
	}

	public SeedGenerator Add(JsonArray data)
	{
		foreach (JsonValue datum in data)
		{
			if (datum.IsJsonObject)
			{
				Add(datum.AsJsonObject);
			}
			else if (datum.IsJsonArray)
			{
				Add(datum.AsJsonArray);
			}
			else
			{
				Add(datum.AsString);
			}
		}
		return this;
	}

	public SeededRandom CreateRandom()
	{
		return new SeededRandom(Hash);
	}
}
