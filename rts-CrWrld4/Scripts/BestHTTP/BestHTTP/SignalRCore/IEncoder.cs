using System;
using BestHTTP.PlatformSupport.Memory;

namespace BestHTTP.SignalRCore
{
	public interface IEncoder
	{
		BufferSegment Encode<T>(T value);

		T DecodeAs<T>(BufferSegment buffer);

		object ConvertTo(Type toType, object obj);
	}
}
