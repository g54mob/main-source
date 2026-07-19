using System.Collections;
using System.Collections.Generic;

namespace UniJSON
{
	public interface IUtf8String : IEnumerable<byte>, IEnumerable
	{
		int ByteLength { get; }
	}
}
