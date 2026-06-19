using UnityEngine;

namespace MyBox
{
	public static class MyPhysicsExtensions
	{
		public static RigidbodyConstraints BitwiseToggle(this RigidbodyConstraints source, RigidbodyConstraints bitMask, bool state)
		{
			if (!state)
			{
				return source & ~bitMask;
			}
			return source | bitMask;
		}

		public static RigidbodyConstraints2D BitwiseToggle(this RigidbodyConstraints2D source, RigidbodyConstraints2D bitMask, bool state)
		{
			if (!state)
			{
				return source & ~bitMask;
			}
			return source | bitMask;
		}
	}
}
