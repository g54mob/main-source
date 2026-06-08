namespace ProtoBuf.Internal
{
	internal enum ObjectScope
	{
		Invalid = 0,
		NakedMessage = 1,
		LikeRoot = 2,
		WrappedMessage = 3,
		Scalar = 4
	}
}
