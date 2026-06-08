using System;
using Newtonsoft.Json.Linq;
using Rhizomatic.ImUI;

namespace GRP
{
	public class SceneryItem
	{
		public struct Options
		{
			public string key;

			public JToken defaultValue;

			public Action<JToken> setter;

			public Func<ImUIBuilder, JToken, ViewParam[], JToken> func;
		}

		public string key;

		public bool over;

		public JToken value;

		public JToken defaultValue;

		public Action<JToken> setter;

		public Func<ImUIBuilder, JToken, ViewParam[], JToken> func;

		public SceneryItem(Options options)
		{
		}

		public void Render()
		{
		}

		public T Get<T>()
		{
			return default(T);
		}

		public void Field(ImUIBuilder ui)
		{
		}

		public SceneryItemData Serialize()
		{
			return null;
		}

		public void Deserialize(SceneryItemData data)
		{
		}
	}
}
