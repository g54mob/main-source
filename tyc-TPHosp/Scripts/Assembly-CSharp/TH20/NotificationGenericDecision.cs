namespace TH20
{
	public class NotificationGenericDecision : NotificationMessage
	{
		public NotificationGenericDecision(NotificationMessages.Definition definition, ResponseDelegate responseDelegate, Level level)
			: base(definition, level)
		{
			if (responseDelegate != null)
			{
				_delegate = responseDelegate;
			}
		}

		public override Character GetCharacter()
		{
			return null;
		}
	}
}
