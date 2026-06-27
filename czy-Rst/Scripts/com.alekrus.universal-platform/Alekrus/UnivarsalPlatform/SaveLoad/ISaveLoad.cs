namespace Alekrus.UnivarsalPlatform.SaveLoad
{
	public interface ISaveLoad : IInitializable, IUpdatable, ISubInterface<IMain>
	{
		IUserSaveLoad GetUserSaveLoad(ILocalUserId parTargetUserId);
	}
}
