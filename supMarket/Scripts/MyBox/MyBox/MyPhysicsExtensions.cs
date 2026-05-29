using UnityEngine;

namespace MyBox
{
	public static class MyPhysicsExtensions
	{
		public static RigidbodyConstraints BitwiseToggle(this RigidbodyConstraints source, RigidbodyConstraints bitMask, bool state)
		{
			return default(RigidbodyConstraints);
		}

		public static RigidbodyConstraints2D BitwiseToggle(this RigidbodyConstraints2D source, RigidbodyConstraints2D bitMask, bool state)
		{
			return default(RigidbodyConstraints2D);
		}
	}
}
