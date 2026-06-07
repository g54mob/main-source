using app.ent;
using app.vis;
using haxe.lang;

namespace test.auto
{
	public class Action : Enum
	{
		protected static readonly string[] __hx_constructs;

		protected Action(int index)
			: base(0)
		{
		}

		public static Action Click(int pointerId, PointData worldPos)
		{
			return null;
		}

		public static Action Drag(int pointerId, PointData startWorldPos, PointData endWorldPos, object endHoldFrameCount)
		{
			return null;
		}

		public static Action Swipe(int pointerId, PointData startWorldPos, SwipeDir swipeDir)
		{
			return null;
		}

		public static Action Keypress(int key)
		{
			return null;
		}

		public static Action Wait(int frameCount)
		{
			return null;
		}
	}
}
