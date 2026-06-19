using Loxodon.Framework.Messaging;

namespace Loxodon.Framework.Tutorials
{
	public class TestMessage : MessageBase
	{
		private string content;

		public string Content => content;

		public TestMessage(object sender, string content)
			: base(sender)
		{
			this.content = content;
		}
	}
}
