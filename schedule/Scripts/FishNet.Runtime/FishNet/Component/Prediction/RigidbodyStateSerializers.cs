using FishNet.Serializing;

namespace FishNet.Component.Prediction
{
	public static class RigidbodyStateSerializers
	{
		public static void WriteRigidbodyState(this Writer writer, RigidbodyState value)
		{
		}

		public static RigidbodyState ReadRigidbodyState(this Reader reader)
		{
			return default(RigidbodyState);
		}

		public static void WriteRigidbody2DState(this Writer writer, Rigidbody2DState value)
		{
		}

		public static Rigidbody2DState ReadRigidbody2DState(this Reader reader)
		{
			return default(Rigidbody2DState);
		}
	}
}
