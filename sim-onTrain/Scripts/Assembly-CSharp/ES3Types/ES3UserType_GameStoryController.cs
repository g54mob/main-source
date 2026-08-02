using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "isStartedFirst" })]
	public class ES3UserType_GameStoryController : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_GameStoryController()
			: base(typeof(GameStoryController))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			GameStoryController gameStoryController = (GameStoryController)obj;
			writer.WriteProperty("isStartedFirst", gameStoryController.isStartedFirst, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			GameStoryController gameStoryController = (GameStoryController)obj;
			foreach (string property in reader.Properties)
			{
				if (property == "isStartedFirst")
				{
					gameStoryController.isStartedFirst = reader.Read<bool>(ES3Type_bool.Instance);
				}
				else
				{
					reader.Skip();
				}
			}
		}
	}
}
