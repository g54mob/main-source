using haxe.lang;

namespace sys.thread._Thread
{
	public sealed class Thread_Impl_
	{
		public static HaxeThread _new(HaxeThread thread)
		{
			return null;
		}

		public static HaxeThread create(Function job)
		{
			return null;
		}

		public static void runWithEventLoop(Function job)
		{
		}

		public static HaxeThread createWithEventLoop(Function job)
		{
			return null;
		}

		public static HaxeThread current()
		{
			return null;
		}

		public static object readMessage(bool block)
		{
			return null;
		}

		public static void sendMessage(HaxeThread this1, object msg)
		{
		}

		public static object readMessageImpl(HaxeThread this1, bool block)
		{
			return null;
		}

		public static EventLoop get_events(HaxeThread this1)
		{
			return null;
		}

		public static void processEvents()
		{
		}
	}
}
