using System;

namespace Newtonsoft.Json.Bson
{
	internal enum BsonBinaryType : byte
	{
		Binary = 0,
		Function = 1,
		[Obsolete]
		BinaryOld = 2,
		[Obsolete]
		UuidOld = 3,
		Uuid = 4,
		Md5 = 5,
		UserDefined = 128
	}
}
