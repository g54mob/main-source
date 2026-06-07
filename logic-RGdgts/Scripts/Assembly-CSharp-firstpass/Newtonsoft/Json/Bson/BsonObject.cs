using System.Collections;
using System.Collections.Generic;

namespace Newtonsoft.Json.Bson
{
	internal class BsonObject : Newtonsoft.Json.Bson.BsonToken, IEnumerable<Newtonsoft.Json.Bson.BsonProperty>, IEnumerable
	{
		private readonly List<Newtonsoft.Json.Bson.BsonProperty> _children;

		public override Newtonsoft.Json.Bson.BsonType Type => default(Newtonsoft.Json.Bson.BsonType);

		public void Add(string name, Newtonsoft.Json.Bson.BsonToken token)
		{
		}

		public IEnumerator<Newtonsoft.Json.Bson.BsonProperty> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
