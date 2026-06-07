using DV.Common;
using DV.UserManagement.Data;
using Newtonsoft.Json.Linq;

namespace DV.UserManagement.Storage.DataPrep
{
	public class ExampleData : AUserDataPreparation
	{
		public override void PrepareDataBeforeInit(IStorageProvider storage, UserManager mgr)
		{
		}

		public override void PrepareDataAfterInit(IStorageProvider storage, UserManager mgr)
		{
			User user = mgr.CreateUser("Hansel");
			GameSession gameSession = user.StartSession("Career", "world1", "My new career");
			gameSession.SaveGame(SaveType.Manual, new JObject(), null);
			gameSession.SaveGame(SaveType.Manual, new JObject(), null);
			gameSession.SaveGame(SaveType.Auto, new JObject(), null);
			gameSession.SaveGame(SaveType.Quick, new JObject(), null);
			GameSession gameSession2 = user.StartSession("Career", "world1", "Another career");
			gameSession2.SaveGame(SaveType.Quick, new JObject(), null);
			gameSession2.SaveGame(SaveType.Auto, new JObject(), null);
			gameSession2.SaveGame(SaveType.Quick, new JObject(), null);
			GameSession gameSession3 = user.StartSession("FreeRoam", "world1", "A bit of free-roaming");
			gameSession3.SaveGame(SaveType.Auto, new JObject(), null);
			gameSession3.SaveGame(SaveType.Quick, new JObject(), null);
			GameSession gameSession4 = mgr.CreateUser("Gretel").StartSession("Career", "world1", "Gretel's career");
			gameSession4.SaveGame(SaveType.Manual, new JObject(), null);
			gameSession4.SaveGame(SaveType.Manual, new JObject(), null);
			gameSession4.SaveGame(SaveType.Auto, new JObject(), null);
			mgr.SaveAllUsers();
		}
	}
}
