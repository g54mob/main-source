namespace Alekrus.UnivarsalPlatform.SaveLoad
{
	public class SaveLoadReceivedArgs : ResultArgs
	{
		public ILocalUserId UserId { get; }

		public SaveLoadReceivedArgs(ILocalUserId parUserId, IResult parResult)
			: base(parResult)
		{
			UserId = parUserId;
		}
	}
}
