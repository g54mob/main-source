using System.Collections;
using System.Collections.Generic;

namespace Newtonsoft.Json.Bson
{
	internal class BsonArray : Newtonsoft.Json.Bson.BsonToken, IEnumerable<Newtonsoft.Json.Bson.BsonToken>, IEnumerable
	{
		private readonly List<Newtonsoft.Json.Bson.BsonToken> _children;

		public override Newtonsoft.Json.Bson.BsonType Type => default(Newtonsoft.Json.Bson.BsonType);

		public void Add(Newtonsoft.Json.Bson.BsonToken token)
		{
		}

		public IEnumerator<Newtonsoft.Json.Bson.BsonToken> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
