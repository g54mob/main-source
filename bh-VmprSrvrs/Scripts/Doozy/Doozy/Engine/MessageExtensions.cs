namespace Doozy.Engine
{
	public static class MessageExtensions
	{
		public static void Send<T>(this T self) where T : Message
		{
		}
	}
}
