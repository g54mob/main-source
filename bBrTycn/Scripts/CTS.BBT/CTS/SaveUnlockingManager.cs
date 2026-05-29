namespace CTS
{
	public class SaveUnlockingManager : SaveContainer
	{
		public override void Clear()
		{
			base.Clear();
			UnlockingManager.ClearAll();
		}

		public override void Save(ES3Settings settings)
		{
			ES3.Save("Unlocks", UnlockingManager.UnlockKey, settings);
		}

		public override void LoadInit(ES3Settings settings)
		{
			EUnlockKey eUnlockKey = ES3.Load("Unlocks", (EUnlockKey)0, settings);
			if (eUnlockKey != 0)
			{
				UnlockingManager.AddUnlockKey(eUnlockKey);
			}
		}

		public override void LoadPost(ES3Settings settings)
		{
		}
	}
}
