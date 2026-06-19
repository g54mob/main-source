using System;

namespace ModIO.Util
{
	public class SimpleMessageUnsubscribeToken
	{
		private Action unsubAction;

		public SimpleMessageUnsubscribeToken(Action unsub)
		{
			unsubAction = unsub;
		}

		public void Unsubscribe()
		{
			unsubAction();
		}
	}
}
