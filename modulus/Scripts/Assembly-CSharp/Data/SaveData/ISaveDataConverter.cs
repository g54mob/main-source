using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Data.SaveData
{
	public interface ISaveDataConverter
	{
		bool CanConvert(Type type);

		object ReadJsonAlreadyRead(JObject jsonObject, JsonSerializer serializer);
	}
}
